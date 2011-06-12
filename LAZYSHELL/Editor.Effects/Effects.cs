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

namespace LAZYSHELL
{
    public partial class Effects : Form
    {
        #region Variables
        private long checksum;
        // main
        private delegate void Function();
        private Overlay overlay = new Overlay();
        private State state = State.Instance;
        private bool updating = false;
        private Effect[] effects { get { return Model.Effects; } set { Model.Effects = value; } }
        private E_Animation[] animations { get { return Model.E_animations; } set { Model.E_animations = value; } }
        private int availableBytes = 0;
        // indexed variables
        public int index { get { return (int)number.Value; } set { number.Value = value; } }
        private int palette { get { return (int)e_paletteIndex.Value; } set { e_paletteIndex.Value = value; } }
        private Effect effect { get { return effects[index]; } set { effects[index] = value; } }
        private E_Animation animation { get { return animations[(int)imageNum.Value]; } set { animations[(int)imageNum.Value] = value; } }
        // public variables
        public Effect Effect { get { return effect; } set { effect = value; } }
        public E_Animation Animation { get { return animation; } set { animation = value; } }
        public int AvailableBytes { get { return availableBytes; } set { availableBytes = value; } }
        // editors
        private EffectMolds molds;
        public EffectMolds Molds { get { return molds; } set { molds = value; } }
        private EffectSequences sequences;
        public EffectSequences Sequences { get { return sequences; } set { sequences = value; } }
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private Search searchWindow;
        // special controls
        #endregion
        #region Functions
        // main
        public Effects()
        {
            // set data
            InitializeComponent();
            Do.AddShortcut(toolStrip2, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip2, Keys.F1, enableHelpTips);
            Do.AddShortcut(toolStrip2, Keys.F2, showDecHex);
            // tooltips
            toolTip1.InitialDelay = 0;
            SetToolTips(toolTip1);
            searchWindow = new Search(number, searchText, searchEffectNames, name.Items);
            // set control values
            updating = true;
            this.animation.Tileset = new E_Tileset(animation, palette);
            this.name.Items.AddRange(Lists.Numerize(Lists.EffectNames));
            this.name.SelectedIndex = 0;
            foreach (E_Animation a in animations)
            {
                a.Tileset = new E_Tileset(a, 0);
                a.Assemble();
            }
            RefreshEffectsEditor();
            updating = false;
            GC.Collect();
            // create editors
            molds.TopLevel = false;
            molds.Dock = DockStyle.Fill;
            molds.SetToolTips(toolTip1);
            panel1.Controls.Add(molds);
            molds.BringToFront();
            openMolds.Checked = true;
            molds.Visible = true;
            sequences.TopLevel = false;
            sequences.Dock = DockStyle.Bottom;
            sequences.SetToolTips(toolTip1);
            panel1.Controls.Add(sequences);
            sequences.SendToBack();
            openSequences.Checked = true;
            sequences.Visible = true;
            new ToolTipLabel(this, toolTip1, showDecHex, enableHelpTips);
            //
            checksum = Do.GenerateChecksum(animations, effects);
        }
        private void RefreshEffectsEditor()
        {
            Cursor.Current = Cursors.WaitCursor;
            updating = true;
            // main properties
            imageNum.Value = effect.AnimationPacket;
            e_paletteIndex.Value = palette = effect.PaletteIndex;
            xNegShift.Value = effect.XNegShift;
            yNegShift.Value = effect.YNegShift;
            // image properties
            e_paletteSetSize.Value = animation.PaletteSetLength;
            e_graphicSetSize.Minimum = animation.Codec == 1 ? 16 : 32;
            e_graphicSetSize.Value = animation.GraphicSetLength;
            e_codec.SelectedIndex = animation.Codec;
            animation.Tileset = new E_Tileset(animation, palette);
            // editors
            LoadMoldEditor();
            LoadSequenceEditor();
            LoadPaletteEditor();
            LoadGraphicEditor();
            CalculateFreeSpace();
            updating = false;
            GC.Collect();
            Cursor.Current = Cursors.Arrow;
        }
        public void CalculateFreeSpace()
        {
            int totalSize, min, max, length = 0;
            if (animation.Index < 39)
            {
                totalSize = 0xFFFF; min = 0; max = 39;
            }
            else
            {
                totalSize = 0xCFFF; min = 39; max = 64;
            }
            for (int i = min; i < max; i++)
                length += animations[i].SM.Length;
            availableBytes = totalSize - length;
            e_availableBytes.BackColor = availableBytes > 0 ? Color.Lime : Color.Red;
            e_availableBytes.Text = availableBytes.ToString() + " bytes free";
        }
        private void Assemble()
        {
            animation.Assemble();

            int i = 0;
            int pointer = 0x252C00;
            int offset = 0x330000;
            for (; i < 39 && offset < 0x33FFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x33FFFF)
                    break;
                Bits.SetShort(Model.Data, pointer, (ushort)offset);
                Bits.SetByte(Model.Data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                Bits.SetByteArray(Model.Data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 39)
                MessageBox.Show("The available space for animation data in bank 0x330000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 38 will not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
            offset = 0x340000;
            for (; i < 64 && offset < 0x34CFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x34CFFF)
                    break;
                Bits.SetShort(Model.Data, pointer, (ushort)offset);
                Bits.SetByte(Model.Data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                Bits.SetByteArray(Model.Data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 64)
                MessageBox.Show("The available space for animation data in bank 0x340000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 63 will not saved. Please make sure the available animation bytes is not negative.", "LAZY SHELL");
        }
        public void EnableOnPlayback(bool enable)
        {
            foreach (Control control in this.Controls)
                if (control != panel1)
                    control.Enabled = enable;
                else
                    foreach (Control parent in panel1.Controls)
                        if (parent != sequences)
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
        // tooltips
        private void SetToolTips(ToolTip toolTip1)
        {
            // Spell effects

            this.number.ToolTipText =
                "Select the spell effect to edit by #.\n\n" +
                "A spell effect is not the entire spell animation itself, but an \n" +
                "animation sequence used in spell animations. Spell \n" +
                "animations can use more than one different spell effect, for \n" +
                "example, the \"Boulder\" spell uses spell effect 26 (boulder) \n" +
                "and 53 (black flash).";

            this.name.ToolTipText =
                "Select the spell effect to edit by name.\n\n" +
                "A spell effect is not the entire spell animation itself, but an \n" +
                "animation sequence used in spell animations. Spell \n" +
                "animations can use more than one different spell effect, for \n" +
                "example, the \"Boulder\" spell uses spell effect 26 (boulder) \n" +
                "and 53 (black flash).";

            toolTip1.SetToolTip(this.imageNum,
                "The image # of the currently selected spell effect refers to \n" +
                "the set of properties that designate the raw graphics and \n" +
                "palette set to use.\n\n" +
                "Anything in the \"IMAGE PALETTE...\", \"IMAGE \n" +
                "GRAPHICS...\" and \"IMAGE TILESET\" panels are part of the \n" +
                "spell effect's image.");

            toolTip1.SetToolTip(this.e_paletteIndex,
                "The index of the palette in the palette set the spell effect \n" +
                "uses. This is mostly used for individual spell effects that use \n" +
                "the same image (thus, the same palette set) but have a \n" +
                "different individual palette, such as the star rain and black \n" +
                "star rain.");

            toolTip1.SetToolTip(this.xNegShift,
                "The X shift is the number of pixels to shift the spell effect \n" +
                "animation to the left.");

            toolTip1.SetToolTip(this.yNegShift,
                "The Y shift is the number of pixels to shift the spell effect \n" +
                "animation up.");

            toolTip1.SetToolTip(this.e_paletteSetSize,
                "The size of the palette in bytes. The total number of \n" +
                "palettes in the spell effect image's palette set equals the \n" +
                "size divided by 32.");

            toolTip1.SetToolTip(this.e_graphicSetSize,
                "The size of the raw graphics in bytes (hexadecimal). Every \n" +
                "0x20 bytes is one or two 8x8 tiles.");

            toolTip1.SetToolTip(this.e_codec,
                "The codec refers to how the graphics are read by the game \n" +
                "engine. 4bpp uses up to 16 colors total, while 2bpp only \n" +
                "uses 4 colors total.");

        }
        // editors
        public void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), animation.PaletteSet, 8, 0);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), animation.PaletteSet, 8, 0);
        }
        public void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    animation.GraphicSet, animation.GraphicSetLength, 0, animation.PaletteSet, 0,
                    animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    animation.GraphicSet, animation.GraphicSetLength, 0, animation.PaletteSet, 0,
                    animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
        }
        private void LoadMoldEditor()
        {
            if (molds == null)
                molds = new EffectMolds(this);
            else
                molds.Reload(this);
        }
        private void LoadSequenceEditor()
        {
            if (sequences == null)
                sequences = new EffectSequences(this);
            else
                sequences.Reload(this);
        }
        private void PaletteUpdate()
        {
            animation.Tileset = new E_Tileset(animation, palette);
            molds.SetTilesetImage();
            molds.SetTilemapImage();
            sequences.SetSequenceFrameImages();
            sequences.InvalidateImages();
            LoadGraphicEditor();
            molds.LoadTileEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void GraphicUpdate()
        {
            animation.Tileset = new E_Tileset(animation, palette);
            molds.SetTilesetImage();
            molds.SetTilemapImage();
            sequences.SetSequenceFrameImages();
            sequences.InvalidateImages();
            molds.LoadTileEditor();
        }
        #endregion
        #region Event handlers
        private void Effects_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(animations, effects) == checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Effects have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Effects = null;
                Model.E_animations = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            paletteEditor.Close();
            graphicEditor.Close();
            searchWindow.Close();
            molds.tileEditor.Close();
        }
        private void number_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            name.SelectedIndex = (int)number.Value;
            if (animation.Tileset != null)
                animations[(int)imageNum.Value].Assemble();
            RefreshEffectsEditor();
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            number.Value = name.SelectedIndex;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, panel2.ClientRectangle, Border3DStyle.Raised, Border3DSide.All);
        }
        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }
        // basic
        private void e_paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            effect.PaletteIndex = (byte)e_paletteIndex.Value;
            animation.Tileset = new E_Tileset(animation, effect.PaletteIndex);
            molds.SetTilesetImage();
            molds.SetTilemapImage();
            sequences.SetSequenceFrameImages();
        }
        private void xNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            effect.XNegShift = (byte)xNegShift.Value;
        }
        private void yNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            effect.YNegShift = (byte)yNegShift.Value;
        }
        private void imageNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            effect.AnimationPacket = (byte)imageNum.Value;
            e_codec.SelectedIndex = animation.Codec;
            animation.Tileset = new E_Tileset(animation, effect.PaletteIndex);
            CalculateFreeSpace();
            LoadMoldEditor();
            LoadSequenceEditor();
        }
        private void e_paletteSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            animation.PaletteSetLength = (ushort)e_paletteSetSize.Value;
            // update free space
            animation.Assemble();
            CalculateFreeSpace();
        }
        private void e_graphicSetSize_ValueChanged(object sender, EventArgs e)
        {
            e_graphicSetSize.Value = (int)e_graphicSetSize.Value & (animation.Codec == 1 ? 0xFFFFF0 : 0xFFFFE0);
            if (updating) return;
            animation.GraphicSetLength = (int)e_graphicSetSize.Value;
            // update free space
            animation.Assemble();
            CalculateFreeSpace();
            LoadGraphicEditor();
        }
        private void e_codec_SelectedIndexChanged(object sender, EventArgs e)
        {
            e_graphicSetSize.Minimum = e_codec.SelectedIndex == 1 ? 16 : 32;
            if (updating) return;
            animation.Codec = (ushort)e_codec.SelectedIndex;
            animation.Tileset = new E_Tileset(animation, effect.PaletteIndex);
            molds.SetTilesetImage();
            molds.SetTilemapImage();
            sequences.SetSequenceFrameImages();
            sequences.DrawFrames();
        }
        // editors
        private void showMain_Click(object sender, EventArgs e)
        {
            panel2.Visible = showMain.Checked;
        }
        private void openPalettes_Click(object sender, EventArgs e)
        {
            paletteEditor.Visible = true;
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            graphicEditor.Visible = true;
        }
        private void openMolds_Click(object sender, EventArgs e)
        {
            molds.Visible = openMolds.Checked;
        }
        private void openSequences_Click(object sender, EventArgs e)
        {
            sequences.Visible = openSequences.Checked;
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        // data managing
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Assemble();
            Cursor.Current = Cursors.Arrow;
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(animations, index, "IMPORT EFFECT ANIMATIONS...").ShowDialog();
            foreach (E_Animation animation in animations)
                animation.Assemble();
            RefreshEffectsEditor();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(animations, index, "EXPORT EFFECT ANIMATIONS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements = new ClearElements(animations, index, "CLEAR EFFECT ANIMATIONS...");
            clearElements.ShowDialog();
            foreach (E_Animation animation in animations)
                animation.Assemble();
            RefreshEffectsEditor();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current effect and animation index. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            animation = new E_Animation(Model.Data, effect.AnimationPacket);
            effect = new Effect(Model.Data, index);
            number_ValueChanged(null, null);
        }
        #endregion
    }
}
