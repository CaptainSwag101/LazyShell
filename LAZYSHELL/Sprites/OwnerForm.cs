using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LAZYSHELL.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LAZYSHELL.Sprites
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Settings
        private Settings settings;

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Elements
        private Sprite[] sprites
        {
            get { return Model.Sprites; }
            set { Model.Sprites = value; }
        }
        private Animation[] animations
        {
            get { return Model.Animations; }
            set { Model.Animations = value; }
        }
        private PaletteSet[] palettes
        {
            get { return Model.PaletteSets; }
            set { Model.PaletteSets = value; }
        }
        private ImagePacket[] images
        {
            get { return Model.ImagePackets; }
            set { Model.ImagePackets = value; }
        }
        public Sprite Sprite
        {
            get { return sprites[Index]; }
            set { sprites[Index] = value; }
        }
        public ImagePacket Image
        {
            get { return images[Sprite.ImageNum]; }
            set { images[Sprite.ImageNum] = value; }
        }
        public Animation Animation
        {
            get { return animations[Sprite.AnimationPacket]; }
            set { animations[Sprite.AnimationPacket] = value; }
        }
        public PaletteSet PaletteSet
        {
            get { return palettes[Image.PaletteNum + Sprite.PaletteIndex]; }
            set { palettes[Image.PaletteNum + Sprite.PaletteIndex] = value; }
        }
        public int[] Palette
        {
            get { return PaletteSet.Palette; }
        }
        private byte[] graphics;
        public byte[] Graphics
        {
            get { return graphics; }
            set
            {
                graphics = value;
                graphics.CopyTo(Model.Graphics, Image.GraphicOffset - 0x280000);
            }
        }
        private byte[] spriteGraphics
        {
            get { return Model.Graphics; }
        }
        public int AvailableBytes
        {
            get { return PropertiesForm.AvailableBytes; }
            set { PropertiesForm.AvailableBytes = value; }
        }

        // Forms
        public PropertiesForm PropertiesForm;
        public MoldsForm MoldsForm;
        public SequencesForm SequencesForm;
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private Search searchWindow;
        private EditLabel labelWindow;
        private NPCPacketsForm npcPacketsForm;
        private FindReferences findReferencesForm;
        private delegate void UpdateFunction();
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            InitializeForms();
            CreateShortcuts();
            CreateHelperForms();
            UpdateAnimationBuffers();
            LoadProperties();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        // Initialization
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
            {
                name.SelectedIndex = settings.LastSprite;
                num.Value = settings.LastSprite;
            }
            else
                name.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void InitializeListControls()
        {
            for (int i = 0; i < Lists.Sprites.Length; i++)
            {
                string itemName = Lists.Sprites[i];
                if (i >= 256 && i <= 511)
                {
                    string monsterName = Do.RawToASCII(Monsters.Model.Monsters[i - 256].Name, Lists.KeystrokesMenu);
                    if (monsterName.Trim() != "")
                        itemName = Lists.ToTitleCase(monsterName);
                }
                name.Items.Add(Lists.Numerize(itemName, i, 4));
            }
        }
        private void InitializeVariables()
        {
            settings = Settings.Default;
            graphics = Image.Graphics(spriteGraphics);
        }
        private void InitializeForms()
        {
            // PropertiesForm
            PropertiesForm = new PropertiesForm(this);
            PropertiesForm.ToggleButton = toggleProperties;
			DockPanel = new DockPanel();
			DockPanel = dockPanel;
			DockPanel.Theme = new VS2013BlueTheme();
			dockPanel = DockPanel;
			PropertiesForm.Show(dockPanel, DockState.DockLeft);

            // MoldsForm, SequencesForm
            MoldsForm = new MoldsForm(this);
            MoldsForm.ToggleButton = toggleMolds;
            MoldsForm.Show(dockPanel, DockState.Document);
            SequencesForm = new SequencesForm(this);
            SequencesForm.ToggleButton = toggleSequences;
            SequencesForm.Show(MoldsForm.Pane, DockAlignment.Bottom, 0.50);
        }
        private void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Updating = true;
            graphics = Image.Graphics(spriteGraphics);
            PropertiesForm.InitializeProperties();
            MoldsForm.Reload();
            SequencesForm.Reload();
            SetFreeBytesLabel();
            this.Updating = false;
            GC.Collect();
            Cursor.Current = Cursors.Arrow;
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(num, searchEffectNames, name.Items);
            labelWindow = new EditLabel(name, num, "Sprites", true);
            new ToolTipLabel(this, baseConvertor, helpTips);
            toolTip1.InitialDelay = 0;
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
        }

        // Free bytes
        public void SetFreeBytesLabel()
        {
            PropertiesForm.SetFreeBytesLabel();
        }

        // Saving
        public void WriteToROM()
        {
            ProgressBar progressBar = new ProgressBar("ASSEMBLING ANIMATIONS...", animations.Length);
            progressBar.Show();
            int i = 0;
            foreach (Animation sm in animations)
            {
                sm.WriteToBuffer();
                progressBar.PerformStep("ASSEMBLING ANIMATION #" + i);
                i++;
            }
            progressBar.Close();
            i = 0;
            int pointer = 0x252000;
            int offset = 0x259000;
            for (; i < 42 && offset < 0x25FFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x25FFFF)
                    break;
                Bits.SetShort(rom, pointer, (ushort)offset);
                rom[pointer + 2] = (byte)((offset >> 16) + 0xC0);
                Bits.SetBytes(rom, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }
            if (i < 42)
                MessageBox.Show("The available space for animation data in bank 0x250000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 41 were not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
            offset = 0x260000;
            for (; i < 107 && offset < 0x26FFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x26FFFF)
                    break;
                Bits.SetShort(rom, pointer, (ushort)offset);
                rom[pointer + 2] = (byte)((offset >> 16) + 0xC0);
                Bits.SetBytes(rom, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }
            if (i < 107)
                MessageBox.Show("The available space for animation data in bank 0x260000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 107 were not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
            offset = 0x270000;
            for (; i < 249 && offset < 0x27FFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x27FFFF)
                    break;
                Bits.SetShort(rom, pointer, (ushort)offset);
                rom[pointer + 2] = (byte)((offset >> 16) + 0xC0);
                Bits.SetBytes(rom, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }
            if (i < 249)
                MessageBox.Show("The available space for animation data in bank 0x270000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 249 will not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
            offset = 0x360000;
            for (; i < 444 && offset < 0x36FFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x36FFFF)
                    break;
                Bits.SetShort(rom, pointer, (ushort)offset);
                rom[pointer + 2] = (byte)((offset >> 16) + 0xC0);
                Bits.SetBytes(rom, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }
            if (i < 444)
                MessageBox.Show("The available space for animation data in bank 0x360000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 444 will not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
            foreach (var sprite in sprites)
                sprite.WriteToROM();
            foreach (var imagePacket in images)
                imagePacket.WriteToROM();
            foreach (var palette in palettes)
                palette.WriteToBuffer(0);
            Buffer.BlockCopy(Model.Graphics, 0, rom, 0x280000, 0xB4000);
            LAZYSHELL.Model.HexEditor.SetOffset(Animation.AnimationOffset);
            LAZYSHELL.Model.HexEditor.HighlightChanges();
            MoldsForm.Modified = false;
            SequencesForm.Modified = false;
            this.Modified = false;
        }
        private void UpdateAnimationBuffers()
        {
            foreach (var animation in animations)
                animation.WriteToBuffer();
        }

        /// <summary>
        /// Enables or disables controls based on the playback status of a sequence's animation.
        /// </summary>
        /// <param name="enable"></param>
        public void EnableOnPlayback(bool enable)
        {
            foreach (Control control in this.Controls)
                if (control != SequencesForm)
                    control.Enabled = enable;
                else
                    foreach (Control parent in SequencesForm.Controls)
                        if (parent != SequencesForm)
                            parent.Enabled = enable;
                        else
                            foreach (Control child in parent.Controls)
                                if (child.Name != "toolStrip1")
                                    child.Enabled = enable;
                                else
                                    foreach (ToolStripItem item in ((ToolStrip)child).Items)
                                        if (item.Name != "pause")
                                            item.Enabled = enable;
        }

        // Search
        private void FindReferences(TreeView treeView)
        {
            // Search through NPCs
            var npcResults = new TreeNode();
            foreach (var npc in Areas.Model.NPCProperties)
            {
                if (npc.Sprite == this.Index)
                    npcResults.Nodes.Add("NPC #" + npc.Index);
            }
            if (npcResults.Nodes.Count > 0)
            {
                npcResults.Text = "NPCS — found " + npcResults.Nodes.Count + " results";
                treeView.Nodes.Add(npcResults);
            }
            // Search through NPC packets
            var npcPacketResults = new TreeNode();
            foreach (var npcPacket in Model.NPCPackets)
            {
                if (npcPacket.Sprite == this.Index)
                    npcPacketResults.Nodes.Add("NPC PACKET #" + npcPacket.Index);
            }
            if (npcPacketResults.Nodes.Count > 0)
            {
                npcPacketResults.Text = "NPC PACKETS — found " + npcPacketResults.Nodes.Count + " results";
                treeView.Nodes.Add(npcPacketResults);
            }
        }

        // Forms
        public void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new PaletteUpdater(), PaletteSet, 1, 0, 1);
                paletteEditor.Owner = this;
            }
            else
                ReloadPaletteEditor();
        }
        public void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new GraphicUpdater(),
                    graphics, graphics.Length, 0, PaletteSet, 0, 0x20, 1);
                graphicEditor.Owner = this;
            }
            else
                ReloadGraphicEditor();
        }
        private void ReloadPaletteEditor()
        {
            if (paletteEditor != null)
                paletteEditor.Reload(PaletteSet, 1, 0, 1);
        }
        private void ReloadGraphicEditor()
        {
            if (graphicEditor != null)
                graphicEditor.Reload(graphics, graphics.Length, 0, PaletteSet, 0, 0x20, 1);
        }
        private void ShowEditorForm(Form form)
        {
            if (!form.Visible)
                form.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
            form.Show();
        }
        public void UpdatePalette()
        {
            foreach (Mold mold in Animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, PaletteSet.Palette, tile.Gridplane);
            }
            MoldsForm.SetTilesetImage();
            MoldsForm.SetTilemapImage();
            SequencesForm.SetFrameImages();
            SequencesForm.InvalidateFrameImages();
            LoadGraphicEditor();
            this.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            foreach (var mold in Animation.Molds)
            {
                foreach (var tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, PaletteSet.Palette, tile.Gridplane);
            }
            MoldsForm.SetTilesetImage();
            MoldsForm.SetTilemapImage();
            SequencesForm.SetFrameImages();
            SequencesForm.InvalidateFrameImages();
            graphics.CopyTo(Model.Graphics, Image.GraphicOffset - 0x280000);
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified && !MoldsForm.Modified && !SequencesForm.Modified)
                return;
            var result = MessageBox.Show(
                "Sprites have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            name.SelectedIndex = (int)num.Value;
            Animation.WriteToBuffer();
            LoadProperties();
            settings.LastSprite = Index;
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            num.Value = name.SelectedIndex;
        }

        // Forms
        private void openNPCPackets_Click(object sender, EventArgs e)
        {
            if (npcPacketsForm == null || !npcPacketsForm.Visible)
                npcPacketsForm = new NPCPacketsForm();
            npcPacketsForm.Show();
            npcPacketsForm.BringToFront();
        }
        private void openPalettes_Click(object sender, EventArgs e)
        {
            LoadPaletteEditor();
            ShowEditorForm(paletteEditor);
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            LoadGraphicEditor();
            ShowEditorForm(graphicEditor);
        }
        private void openSequences_Click(object sender, EventArgs e)
        {
            SequencesForm.Visible = toggleSequences.Checked;
        }
        private void openMolds_Click(object sender, EventArgs e)
        {
            MoldsForm.Visible = toggleMolds.Checked;
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WriteToROM();
            Cursor.Current = Cursors.Arrow;
        }
        private void import_Click(object sender, EventArgs e)
        {
            var ioelements = new IOElements(animations, IOMode.Import, Sprite.ImageNum, "IMPORT SPRITE ANIMATIONS...");
            if (ioelements.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (var animation in animations)
                animation.WriteToBuffer();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(animations, IOMode.Export, Sprite.ImageNum, "EXPORT SPRITE ANIMATIONS...").ShowDialog();
        }
        private void exportMoldImages_Click(object sender, EventArgs e)
        {
            var exportImages = new ExportImages(Index, ElementType.Sprite);
            exportImages.ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            var clearElements = new ClearElements(animations, Sprite.ImageNum, "CLEAR SPRITE ANIMATIONS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            foreach (var animation in animations)
                animation.WriteToBuffer();
            LoadProperties();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current sprite and animation index. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Animation = new Animation(Sprite.AnimationPacket);
            Image = new ImagePacket(Sprite.ImageNum);
            Sprite = new Sprite(Index);
            for (int i = Image.PaletteNum; i < Image.PaletteNum + 8; i++)
                palettes[i] = new PaletteSet(Model.ROM, i, 0x252FFE + (i * 30), 1, 16, 30);
            Buffer.BlockCopy(Model.ROM, Image.GraphicOffset, Model.Graphics, Image.GraphicOffset - 0x280000, 0x4000);
            num_ValueChanged(null, null);
        }
        private void hexViewer_Click(object sender, EventArgs e)
        {
            LAZYSHELL.Model.HexEditor.SetOffset(Animation.AnimationOffset);
            LAZYSHELL.Model.HexEditor.HighlightChanges();
            LAZYSHELL.Model.HexEditor.Show();
        }

        #endregion
    }
}