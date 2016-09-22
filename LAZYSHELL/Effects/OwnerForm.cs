using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Effects
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        // main
        private delegate void UpdateFunction();
        private Overlay overlay = new Overlay();
        private Effect[] effects
        {
            get { return Model.Effects; }
            set { Model.Effects = value; }
        }
        private Animation[] animations
        {
            get { return Model.Animations; }
            set { Model.Animations = value; }
        }
        // indexed variables
        public int index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        private int palette
        {
            get { return effect.PaletteIndex; }
            set { effect.PaletteIndex = (byte)value; }
        }
        private Effect effect
        {
            get { return effects[index]; }
            set { effects[index] = value; }
        }
        private Animation animation
        {
            get { return animations[effect.ImageNum]; }
            set { animations[effect.ImageNum] = value; }
        }
        // public variables
        public Effect Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        public Animation Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        // editors
        public PropertiesForm PropertiesForm { get; set; }
        public MoldsForm MoldsForm { get; set; }
        public SequencesForm SequencesForm { get; set; }
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private Search searchWindow;
        private EditLabel labelWindow;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
            LoadProperties();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        // Initialization
        private void InitializeForms()
        {
            PropertiesForm = new PropertiesForm(this);
            PropertiesForm.ToggleButton = toggleProperties;
			DockPanel = new DockPanel();
			DockPanel = dockPanel;
			//DockPanel.Theme = new VS2013BlueTheme();
			dockPanel = DockPanel;
			PropertiesForm.Show(dockPanel, DockState.DockLeft);
            MoldsForm = new MoldsForm(this);
            MoldsForm.ToggleButton = toggleMolds;
            MoldsForm.Show(dockPanel, DockState.Document);
            SequencesForm = new SequencesForm(this);
            SequencesForm.ToggleButton = toggleSequences;
            SequencesForm.Show(MoldsForm.Pane, DockAlignment.Bottom, 0.50);
        }
        private void InitializeVariables()
        {
            this.animation.Tileset_tiles = new Tileset(animation, palette);
            foreach (var a in animations)
            {
                a.Tileset_tiles = new Tileset(a, 0);
                a.WriteToBuffer();
            }
        }
        private void InitializeListControls()
        {
            this.name.Items.AddRange(Lists.Numerize(Lists.Effects));
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            this.name.SelectedIndex = 0;
            if (settings.RememberLastIndex)
                index = settings.LastEffect;
            //
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            toolTip1.InitialDelay = 0;
            searchWindow = new Search(num, searchEffectNames, name.Items);
            labelWindow = new EditLabel(name, num, "Effects", true);
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip2, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip2, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip2, Keys.F2, baseConvertor);
        }
        private void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Updating = true;

            // Properties form
            PropertiesForm.LoadProperties();
            animation.Tileset_tiles = new Tileset(animation, palette);

            // Editors
            LoadMoldEditor();
            LoadSequenceEditor();
            PropertiesForm.SetFreeBytesLabel();

            // Finished
            this.Updating = false;
            GC.Collect();
            Cursor.Current = Cursors.Arrow;
        }

        // Saving
        private void WriteToROM()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Save effect properties
            effect.WriteToROM();

            // First, update animation buffer
            animation.WriteToBuffer();

            // Save animation buffers for bank 0x330000 to ROM
            int i = 0;
            int pointer = 0x252C00;
            int offset = 0x330000;
            for (; i < 39 && offset < 0x33FFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x33FFFF)
                    break;
                Bits.SetShort(Model.ROM, pointer, (ushort)offset);
                Bits.SetByte(Model.ROM, pointer + 2, (byte)((offset >> 16) + 0xC0));
                Bits.SetBytes(Model.ROM, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }

            // Alert user if didn't finish saving all indexes
            if (i < 39)
                MessageBox.Show("The available space for animation data in bank 0x330000 has exceeded the alotted space.\n" +
                    "Animation #'s " + i.ToString() + " through 63 were not saved. Make sure there are still free bytes available.",
                    "LAZY SHELL");

            // Save animation buffers for bank 0x340000 to ROM
            offset = 0x340000;
            for (; i < 64 && offset < 0x34CFFF; i++, pointer += 3)
            {
                if (animations[i].Buffer.Length + offset > 0x34CFFF)
                    break;
                Bits.SetShort(Model.ROM, pointer, (ushort)offset);
                Bits.SetByte(Model.ROM, pointer + 2, (byte)((offset >> 16) + 0xC0));
                Bits.SetBytes(Model.ROM, offset, animations[i].Buffer);
                offset += animations[i].Buffer.Length;
            }

            // Alert user if didn't finish saving all indexes
            if (i < 64)
                MessageBox.Show("The available space for animation data in bank 0x340000 has exceeded the alotted space.\n" +
                    "Animation #'s " + i.ToString() + " through 63 were not saved. Make sure there are still free bytes available.",
                    "LAZY SHELL");

            // Reset modification flags
            MoldsForm.Modified = false;
            SequencesForm.Modified = false;
            this.Modified = false;

            // Finished
            Cursor.Current = Cursors.Arrow;
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
            {
                if (control != SequencesForm)
                    control.Enabled = enable;
                else
                {
                    foreach (Control parent in SequencesForm.Controls)
                    {
                        if (parent != SequencesForm)
                            parent.Enabled = enable;
                        else
                        {
                            foreach (Control child in parent.Controls)
                            {
                                if (child.Name != "toolStrip1")
                                    child.Enabled = enable;
                                else
                                {
                                    foreach (ToolStripItem item in ((ToolStrip)child).Items)
                                        if (item.Name != "pause")
                                            item.Enabled = enable;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Loading forms
        public void LoadMoldEditor()
        {
            if (MoldsForm == null)
                MoldsForm = new MoldsForm(this);
            else
                MoldsForm.Reload(this);
        }
        public void LoadSequenceEditor()
        {
            if (SequencesForm == null)
                SequencesForm = new SequencesForm(this);
            else
                SequencesForm.Reload(this);
        }
        public void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new PaletteUpdater(), animation.PaletteSet, 8, 0, 8);
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
                    animation.GraphicSet, animation.GraphicSetLength, 0, animation.PaletteSet, 0,
                    animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
                graphicEditor.Owner = this;
            }
            else
                ReloadGraphicEditor();
        }
        private void ReloadPaletteEditor()
        {
            if (paletteEditor != null)
                paletteEditor.Reload(animation.PaletteSet, 8, 0, 8);
        }
        private void ReloadGraphicEditor()
        {
            if (graphicEditor != null)
                graphicEditor.Reload(animation.GraphicSet, animation.GraphicSetLength, 0, animation.PaletteSet, 0,
                    animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
        }

        // Updating
        public void UpdatePalette()
        {
            animation.Tileset_tiles = new Tileset(animation, palette);
            MoldsForm.SetTilesetImage();
            MoldsForm.SetTilemapImage();
            SequencesForm.SetFrameImages();
            SequencesForm.InvalidateFrameImages();
            LoadGraphicEditor();
            MoldsForm.LoadTileEditor();
            this.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            animation.Tileset_tiles = new Tileset(animation, palette);
            MoldsForm.SetTilesetImage();
            MoldsForm.SetTilemapImage();
            SequencesForm.SetFrameImages();
            SequencesForm.InvalidateFrameImages();
            MoldsForm.LoadTileEditor();
            this.Modified = true;   // b/c switching colors won't modify checksum
        }

        #endregion

        #region Event handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified && !MoldsForm.Modified && !SequencesForm.Modified)
                return;

            // Prompt user to save
            var result = MessageBox.Show(
                "Effects have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Save, reset, or cancel
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
            name.SelectedIndex = (int)num.Value;
            if (!this.Updating)
            {
                // Update and reload
                UpdateAnimationBuffers();
                LoadProperties();
                settings.LastEffect = index;
            }
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            num.Value = name.SelectedIndex;
        }

        // Forms
        private void openPalettes_Click(object sender, EventArgs e)
        {
            LoadPaletteEditor();
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            LoadGraphicEditor();
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(animations, IOMode.Import, effect.ImageNum, "IMPORT EFFECT ANIMATIONS...").ShowDialog();
            this.animation.PaletteSet.Buffer = Model.ROM;

            // Update and reload
            UpdateAnimationBuffers();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(animations, IOMode.Export, effect.ImageNum, "EXPORT EFFECT ANIMATIONS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements = new ClearElements(animations, effect.ImageNum, "CLEAR EFFECT ANIMATIONS...");
            clearElements.ShowDialog();

            // Update and reload
            UpdateAnimationBuffers();
            LoadProperties();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current effect and animation index. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // Reload data from ROM
            animation = new Animation(effect.ImageNum);
            effect = new Effect(index);

            // Update and reload
            UpdateAnimationBuffers();
            LoadProperties();
        }
        private void cullAnimations_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clean all unused graphics, tiles, and palettes. " +
                "It may increase the amount of free space by thousands of bytes, " +
                "but any data that is not used or referenced will be lost.\n\n" + "Go ahead with process?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // Iterate through all animations to find unused data
            foreach (var image in animations)
            {
                byte format = (byte)(image.Codec == 1 ? 0x10 : 0x20);
                int highestTile = 0;
                int highestSubtile = 0;
                int highestPalette = 0;
                int highestMold = 0;

                #region Cull tileset size

                // Find highest tile in tilemaps
                foreach (var mold in image.Molds)
                {
                    for (int a = 0; a < mold.Tiles.Length; a++)
                        if (mold.Tiles[a] < 0xFE && (mold.Tiles[a] & 0x3F) > highestTile)
                            highestTile = mold.Tiles[a] & 0x3F;
                }
                highestTile++;

                // Reduce tileset size if any unused tiles at end of tileset
                if (highestTile * 8 < image.TilesetLength)
                {
                    int temp = highestTile * 8;
                    image.TilesetLength = Math.Min(highestTile * 8, 512);
                    image.TilesetLength = image.TilesetLength / 64 * 64;
                    if (image.TilesetLength == 0)
                        image.TilesetLength += 64;
                    else if (image.TilesetLength <= 512 - 64 && temp % 64 != 0)
                        image.TilesetLength += 64;
                }

                #endregion

                #region Cull graphics size

                // Find highest subtile index in tileset
                for (int i = 0; i < image.TilesetLength; i += 2)
                    if (image.Tileset_bytes[i] < 0xFF && image.Tileset_bytes[i] > highestSubtile)
                        highestSubtile = image.Tileset_bytes[i];
                highestSubtile++;

                // Reduce graphic set size if any unused subtiles at end of graphics
                if (highestSubtile * format < image.GraphicSetLength)
                    image.GraphicSetLength = highestSubtile * format;

                #endregion

                #region Cull palette size

                // Find highest palette index in all animations
                foreach (var effect in effects)
                {
                    if (effect.ImageNum == image.Index && effect.PaletteIndex > highestPalette)
                        highestPalette = effect.PaletteIndex;
                }
                highestPalette++;

                // Reduce palette size if any unused palettes at end of set
                if (highestPalette * 32 < image.PaletteSetLength)
                {
                    int temp = highestPalette * 32;
                    image.PaletteSetLength = (ushort)Math.Min(highestPalette * 32, 256);
                    image.PaletteSetLength = (ushort)(image.PaletteSetLength / 32 * 32);
                    if (image.PaletteSetLength == 0)
                        image.PaletteSetLength += 32;
                    else if (image.PaletteSetLength <= 256 - 32 && temp % 32 != 0)
                        image.PaletteSetLength += 32;
                }

                #endregion

                #region Cull molds

                // Find highest mold index in sequence
                foreach (var frame in image.Sequences[0].Frames)
                {
                    if (frame.Mold > highestMold)
                        highestMold = frame.Mold;
                }
                highestMold++;

                // Remove any unused molds at end of collection
                if (highestMold < image.Molds.Count)
                    image.Molds.RemoveRange(highestMold, image.Molds.Count - highestMold);

                #endregion
            }

            // Finally, update animation buffers
            foreach (var animation in animations)
            {
                if (animation.Tileset_tiles != null)
                    animation.Tileset_tiles = new Tileset(animation, palette);
                animation.WriteToBuffer();
            }

            // Reload properties
            LoadProperties();
        }

        #endregion
    }
}
