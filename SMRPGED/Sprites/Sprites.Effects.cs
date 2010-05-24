using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Sprites
    {
        #region Variables

        private bool updatingEffect = false;

        private Effect[] effects;
        private E_Animation[] e_animations; 
        public E_Animation[] E_animations { get { return e_animations; } set { e_animations = value; } }
        private E_Tileset e_tileset;

        private ArrayList e_sequenceImages = new ArrayList();

        private int currentEffect;
        private int e_currentColor;
        private int e_currentPixel;
        private int e_currentTile;
        private int e_currentFrame;
        private int e_currentMold;
        private int e_currentPaletteShift;
        private int e_currentAnimation;
        private int e_currentTilesetTile;
        private int e_currentSubtile;

        private ushort e_currentFrameOffset;
        private ushort e_currentMoldOffset;
        private ushort e_currentTileOffset;

        private ushort e_currentTileSetSize;
        private ushort e_currentGraphicSetSize;
        private ushort e_currentPaletteSetSize;

        private int e_availableBytesNum;

        private int e_zoomG = 1;
        private int e_zoomM = 1;

        private byte[] e_sequenceDurations;
        private int e_currentFrameImage = 0;

        private int[]
            e_palettePixels,
            e_tilesetPixels,
            e_tilePixels,
            e_subtilePixels,
            e_moldPixels,
            e_graphicPixels,
            e_framePixels;
        private Bitmap
            e_paletteImage,
            e_tilesetImage,
            e_tileImage,
            e_subtileImage,
            e_moldImage,
            e_graphicImage,
            e_sequenceImage,
            e_frameImage;

        // palette effects
        private Stack<int[]> colorReds = new Stack<int[]>();
        private Stack<int[]> colorGreens = new Stack<int[]>();
        private Stack<int[]> colorBlues = new Stack<int[]>();
        private Stack<int[]> redoColorReds = new Stack<int[]>();
        private Stack<int[]> redoColorGreens = new Stack<int[]>();
        private Stack<int[]> redoColorBlues = new Stack<int[]>();
        private bool e_colEdit = false;
        private Stack<int[]> e_colorReds = new Stack<int[]>();
        private Stack<int[]> e_colorGreens = new Stack<int[]>();
        private Stack<int[]> e_colorBlues = new Stack<int[]>();
        private Stack<int[]> e_redoColorReds = new Stack<int[]>();
        private Stack<int[]> e_redoColorGreens = new Stack<int[]>();
        private Stack<int[]> e_redoColorBlues = new Stack<int[]>();

        #endregion

        #region Methods

        // initialize properties
        private void InitializeEffectsEditor()
        {
            updatingEffect = true;

            this.effects = spriteModel.Effects;
            this.e_animations = spriteModel.E_animations;

            currentEffect = 0;
            this.effectNum.Value = 0;
            this.effectName.SelectedIndex = 0;

            RefreshEffectsEditor();

            updatingEffect = false;

            GC.Collect();
        }
        private void InitializeE_Animation()
        {
            updatingEffect = true;

            e_codec.SelectedIndex = e_animations[e_currentAnimation].Codec;
            e_graphicSetSize.Increment = e_codec.SelectedIndex == 1 ? 0x10 : 0x20;
            e_graphicSetSize.Value = e_currentGraphicSetSize = (ushort)e_animations[e_currentAnimation].GraphicSetLength;

            e_tileset = new E_Tileset(e_animations[e_currentAnimation], effects[currentEffect].PaletteIndex);
            e_tileSetSize.Value = e_currentTileSetSize = (ushort)e_animations[e_currentAnimation].TileSetLength;

            e_moldWidth.Value = e_animations[e_currentAnimation].MoldsWidth;
            e_moldHeight.Value = e_animations[e_currentAnimation].MoldsHeight;

            e_animations[e_currentAnimation].CurrentSequence = 0;

            e_currentTilesetTile = 0;
            e_currentSubtile = 0;

            InitializeE_Subtile();
            InitializeE_Palette();
            InitializeE_PaletteColor();
            InitializeE_Subtile();
            InitializeE_Molds();
            InitializeE_Tiles();
            InitializeE_Frames();

            SetE_AllImages();

            UpdateE_AnimationsFreeSpace();

            updatingEffect = false;
        }
        private void InitializeE_Palette()
        {
            updatingEffect = true;

            e_paletteSetSize.Value = e_currentPaletteSetSize = e_animations[e_currentAnimation].PaletteSetLength;
            e_paletteColor.Maximum = (e_animations[e_currentAnimation].PaletteSetLength / 2) - 1;

            e_currentColor = 0;
            this.e_paletteColor.Value = currentColor;

            updatingEffect = false;
        }
        private void InitializeE_PaletteColor()
        {
            updatingEffect = true;

            e_paletteRedNum.Value = e_animations[e_currentAnimation].PaletteColorRed[e_currentColor];
            e_paletteGreenNum.Value = e_animations[e_currentAnimation].PaletteColorGreen[e_currentColor];
            e_paletteBlueNum.Value = e_animations[e_currentAnimation].PaletteColorBlue[e_currentColor];
            e_paletteRedBar.Value = e_animations[e_currentAnimation].PaletteColorRed[e_currentColor];
            e_paletteGreenBar.Value = e_animations[e_currentAnimation].PaletteColorGreen[e_currentColor];
            e_paletteBlueBar.Value = e_animations[e_currentAnimation].PaletteColorBlue[e_currentColor];

            this.pictureBoxE_Color.BackColor = Color.FromArgb((int)e_paletteRedNum.Value, (int)e_paletteGreenNum.Value, (int)e_paletteBlueNum.Value);

            updatingEffect = false;
        }
        private void InitializeE_Molds()
        {
            updatingEffect = true;

            e_molds.BeginUpdate();

            e_currentMold = 0;
            e_currentTile = 0;

            this.e_molds.Items.Clear();
            for (int i = 0; i < e_animations[e_currentAnimation].Molds.Count; i++)
            {
                this.e_molds.Items.Add("Mold " + i.ToString());
                e_animations[e_currentAnimation].CurrentMold = i;
            }
            this.e_molds.SelectedIndex = 0;

            e_animations[e_currentAnimation].CurrentMold = e_currentMold;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;

            e_molds.EndUpdate();

            updatingEffect = false;
        }
        private void InitializeE_Tiles()
        {
            updatingEffect = true;
            e_tiles.BeginUpdate();
            e_currentTile = 0;
            this.e_tiles.Items.Clear();
            for (int i = 0; i < e_animations[e_currentAnimation].Tiles.Count; i++)
            {
                this.e_tiles.Items.Add("Tile " + i.ToString());
                e_animations[e_currentAnimation].CurrentTile = i;
            }
            if (this.e_tiles.Items.Count != 0)
            {
                this.e_tiles.SelectedIndex = 0;
                e_animations[e_currentAnimation].CurrentTile = e_currentTile;
                e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
                RefreshE_Tiles();
            }
            e_tiles.EndUpdate();
            updatingEffect = false;
        }
        private void InitializeE_Frames()
        {
            updatingEffect = true;

            e_frames.BeginUpdate();

            this.e_frames.Items.Clear();
            for (int i = 0; i < e_animations[e_currentAnimation].Frames.Count; i++)
                this.e_frames.Items.Add("Frame " + i.ToString());

            if (e_animations[e_currentAnimation].Frames.Count == 0)
            {
                this.e_frameMold.Enabled = false;
                this.e_duration.Enabled = false;
                this.e_playSequence.Enabled = false;
                this.e_pauseSequence.Enabled = false;
                this.e_moveFoward.Enabled = false;
                this.e_moveBack.Enabled = false;
                this.e_deleteFrame.Enabled = false;
                if (e_animations[e_currentAnimation].FramePacketPointer == 0xFFFF)
                {
                    this.e_insertFrame.Enabled = false;
                    MessageBox.Show("This is a dummied sequence. It cannot contain any frames.", "NOTE: DUMMIED SEQUENCE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.e_insertFrame.Enabled = true;
                this.e_moveFrameDown.Enabled = false;
                this.e_moveFrameUp.Enabled = false;
            }
            else
            {
                this.e_frameMold.Enabled = true;
                this.e_duration.Enabled = true;
                this.e_playSequence.Enabled = true;
                this.e_pauseSequence.Enabled = true;
                this.e_moveFoward.Enabled = true;
                this.e_moveBack.Enabled = true;
                this.e_insertFrame.Enabled = true;
                this.e_deleteFrame.Enabled = true;
                this.e_moveFrameDown.Enabled = true;
                this.e_moveFrameUp.Enabled = true;

                this.e_frames.SelectedIndex = 0;
                e_animations[e_currentAnimation].CurrentFrame = 0;

                this.e_frameMold.Value = e_animations[e_currentAnimation].FrameMold;
                this.e_duration.Value = e_animations[e_currentAnimation].Duration;

                e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            }

            e_frames.EndUpdate();

            updatingEffect = false;
        }
        private void InitializeE_Subtile()
        {
            updatingEffect = true;

            e_tileSubtile.Value = e_tileset.Tileset[e_currentTilesetTile].GetSubtile(e_currentSubtile).TileNum;

            updatingEffect = false;
        }

        // refresh properties
        private void RefreshEffectsEditor()
        {
            updatingEffect = true;

            e_animation.Value = e_currentAnimation = effects[currentEffect].AnimationPacket;
            e_paletteIndex.Value = e_currentPaletteShift = effects[currentEffect].PaletteIndex;
            xNegShift.Value = effects[currentEffect].XNegShift;
            yNegShift.Value = effects[currentEffect].YNegShift;

            InitializeE_Animation();

            updatingEffect = false;

            GC.Collect();
        }
        private void RefreshE_Molds()
        {
            updatingEffect = true;

            e_currentTile = 0;
            InitializeE_Tiles();

            updatingEffect = false;
        }
        private void RefreshE_Frames()
        {
            updatingEffect = true;

            this.e_frameMold.Value = e_animations[e_currentAnimation].FrameMold;
            this.e_duration.Value = e_animations[e_currentAnimation].Duration;

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;

            updatingEffect = false;
        }
        private void RefreshE_Tiles()
        {
            updatingEffect = true;

            if (e_animations[e_currentAnimation].Filler)
            {
                moldTileFormat.SelectedIndex = 1;
                moldFillAmount.Enabled = true;
                moldFillAmount.Value = e_animations[e_currentAnimation].FillAmount;
            }
            else
            {
                moldTileFormat.SelectedIndex = 0;
                moldFillAmount.Enabled = false;
                moldFillAmount.Value = 0;
            }
            if (e_animations[e_currentAnimation].Empty)
            {
                moldTileIndex.Enabled = false;
                moldTileIndex.Value = 0;
            }
            else
            {
                moldTileIndex.Enabled = true;
                moldTileIndex.Value = e_animations[e_currentAnimation].TileIndex;
            }
            moldTileEmpty.Checked = e_animations[e_currentAnimation].Empty;
            moldTileProp.SetItemChecked(0, e_animations[e_currentAnimation].Mirrored);
            moldTileProp.SetItemChecked(1, e_animations[e_currentAnimation].Inverted);

            updatingEffect = false;
        }

        private void PlaybackE_Sequence_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; !PlaybackE_Sequence.CancellationPending; i++)
            {
                if (PlaybackE_Sequence.CancellationPending) break;
                if (i >= e_sequenceImages.Count) i = 0;
                e_currentFrameImage = i;
                e_sequenceImage = (Bitmap)e_sequenceImages[i];
                pictureBoxE_Sequence.Invalidate();
                Thread.Sleep(e_sequenceDurations[i] * (1000 / 60));
                if (PlaybackE_Sequence.CancellationPending) break;
            }
        }
        private void PlaybackE_Sequence_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            e_playSequence.Enabled = true;
            e_moveBack.Enabled = true;
            e_moveFoward.Enabled = true;
        }

        // set images
        private void SetE_AllImages()
        {
            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void SetE_PaletteImage()
        {
            e_palettePixels = e_animations[e_currentAnimation].GetPaletteSetPixels();
            e_paletteImage = new Bitmap(DrawImageFromIntArr(e_palettePixels, 256, 128));
            pictureBoxE_Palette.Invalidate();
        }
        private void SetE_GraphicImage()
        {
            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            e_graphicPixels = GetE_GraphicPixels();
            e_graphicImage = new Bitmap(DrawImageFromIntArr(e_graphicPixels, 128, 128));
            //pictureBoxE_Graphics.BackColor = Color.FromArgb(r, g, b);
            pictureBoxE_Graphics.Invalidate();
        }
        private void SetE_MoldImage()
        {
            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            e_moldPixels = e_animations[e_currentAnimation].MoldPixels(e_animations[e_currentAnimation], e_tileset, true);
            e_moldImage = new Bitmap(DrawImageFromIntArr(e_moldPixels, 256, 256));
            //pictureBoxE_Mold.BackColor = Color.FromArgb(r, g, b);
            pictureBoxE_Mold.Invalidate();
        }
        private void SetE_TilesetImage()
        {
            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            e_tilesetPixels = e_tileset.TilesetPixels(e_tileset.Tileset, e_animations[e_currentAnimation].TileSetLength);
            e_tilesetImage = new Bitmap(DrawImageFromIntArr(e_tilesetPixels, 128, 128));
            //pictureBoxEffectTileset.BackColor = Color.FromArgb(r, g, b);
            pictureBoxEffectTileset.Invalidate();
        }
        private void SetE_TileImage()
        {
            if (e_animations[e_currentAnimation].Tiles.Count == 0)
            {
                pictureBoxE_Tile.Invalidate();
                return;
            }

            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            Tile16x16 e_tile = (Tile16x16)e_tileset.Tileset[e_currentTilesetTile];
            int[] temp = new int[16 * 16];
            e_tilePixels = new int[32 * 32];

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                    CopyOverTile8x8(e_tile.GetSubtile(y * 2 + x), temp, 16, x, y);
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    e_tilePixels[y * 32 + x] = temp[y / 2 * 16 + (x / 2)];
            }
            e_tileImage = new Bitmap(DrawImageFromIntArr(e_tilePixels, 32, 32));
            //pictureBoxE_Tile.BackColor = Color.FromArgb(r, g, b);
            pictureBoxE_Tile.Invalidate();
        }
        private void SetE_SubtileImage()
        {
            if (animations[currentAnimation].Tiles.Count == 0 || animations[currentAnimation].TileOffset == 0x7FFF)
            {
                pictureBoxE_Subtile.Invalidate();
                return;
            }

            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            Tile16x16 e_tile = (Tile16x16)e_tileset.Tileset[e_currentTilesetTile];
            int[] temp = new int[8 * 8];
            e_subtilePixels = new int[32 * 32];

            CopyOverTile8x8(e_tile.GetSubtile(e_currentSubtile), temp, 8, 0, 0);

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    e_subtilePixels[y * 32 + x] = temp[y / 4 * 8 + (x / 4)];
            }

            e_subtileImage = new Bitmap(DrawImageFromIntArr(e_subtilePixels, 32, 32));
            //pictureBoxE_Subtile.BackColor = Color.FromArgb(r, g, b);
            pictureBoxE_Subtile.Invalidate();
        }
        private void SetE_SequenceFrameImages()
        {
            e_sequenceImages.Clear();
            e_sequenceDurations = new byte[e_animations[e_currentAnimation].Frames.Count];
            int md = e_animations[e_currentAnimation].CurrentMold;
            int fr = e_animations[e_currentAnimation].CurrentFrame;
            for (int i = 0; i < e_animations[e_currentAnimation].Frames.Count; i++)
            {
                e_animations[e_currentAnimation].CurrentFrame = i;
                if (e_animations[e_currentAnimation].FrameMold < e_animations[e_currentAnimation].Molds.Count)
                {
                    e_animations[e_currentAnimation].CurrentMold = e_animations[e_currentAnimation].FrameMold;
                    e_framePixels = e_animations[e_currentAnimation].MoldPixels(e_animations[e_currentAnimation], e_tileset, false);
                    e_frameImage = new Bitmap(DrawImageFromIntArr(e_framePixels, 256, 256));
                    e_sequenceImages.Add(new Bitmap(e_frameImage));
                }
                else
                {
                    MessageBox.Show("Mold for frame #" + i.ToString() + " is not valid. Change to lower value.", "INVALID MOLD FOR FRAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e_sequenceImages.Add(new Bitmap(256, 256));
                }
                e_sequenceDurations[i] = e_animations[e_currentAnimation].Duration;
            }

            e_currentFrame = fr;
            if (e_animations[e_currentAnimation].Frames.Count != 0)
            {
                e_animations[e_currentAnimation].CurrentFrame = e_currentFrame;
                e_animations[e_currentAnimation].CurrentMold = md;
            }

            SetE_SequenceFrameImage();
        }
        private void SetE_SequenceFrameImage()
        {
            int r = e_animations[e_currentAnimation].PaletteColorRed[0];
            int g = e_animations[e_currentAnimation].PaletteColorGreen[0];
            int b = e_animations[e_currentAnimation].PaletteColorBlue[0];

            if (e_currentFrame < e_sequenceImages.Count)
            {
                e_sequenceImage = new Bitmap((Bitmap)e_sequenceImages[e_currentFrame]);
                //pictureBoxE_Sequence.BackColor = Color.FromArgb(r, g, b);
            }
            pictureBoxE_Sequence.Invalidate();
        }
        private void UpdateE_SequenceFrameImage()
        {
            if (e_sequenceImages.Count == 0) return;

            int md = e_animations[e_currentAnimation].CurrentMold;
            int fr = e_animations[e_currentAnimation].CurrentFrame;
            for (int i = 0; i < e_animations[e_currentAnimation].Frames.Count; i++)
            {
                e_animations[e_currentAnimation].CurrentFrame = i;
                if (e_animations[e_currentAnimation].FrameMold == e_molds.SelectedIndex)
                {
                    e_framePixels = e_animations[e_currentAnimation].MoldPixels(e_animations[e_currentAnimation], e_tileset, false);
                    e_frameImage = new Bitmap(DrawImageFromIntArr(e_framePixels, 256, 256));
                    e_sequenceImages.RemoveAt(i);
                    e_sequenceImages.Insert(i, new Bitmap(e_frameImage));
                    break;
                }
            }

            e_animations[e_currentAnimation].CurrentFrame = fr;
            e_animations[e_currentAnimation].CurrentMold = md;

            if (e_frameMold.Value == e_molds.SelectedIndex) SetE_SequenceFrameImage();
        }

        // drawing
        private int[] GetE_GraphicPixels()
        {
            int[] pixels = e_animations[e_currentAnimation].GetGraphicPixels(effects[currentEffect].PaletteIndex);
            int[] zoomed = new int[128 * 128];

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                    zoomed[y * 128 + x] = pixels[y * 128 + x];
            }

            return zoomed;
        }
        private Tile8x8 CreateNewE_Subtile()
        {
            if (e_animations[e_currentAnimation].Codec == 1)
                return Draw2bppTile8x8((byte)e_tileSubtile.Value, 0);
            else
                return Draw4bppTile8x8((byte)e_tileSubtile.Value, 0);
        }
        private Tile8x8 Draw2bppTile8x8(byte tile, byte temp)
        {
            int offset = tile * 0x10;

            Tile8x8 tempTile;

            if (tile != 0xFF)
            {
                if (offset + 0x10 > e_animations[e_currentAnimation].GraphicSet.Length)
                    tempTile = new Tile8x8(tile, new byte[0x10], 0, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, true);
                else
                    tempTile = new Tile8x8(tile, e_animations[e_currentAnimation].GraphicSet, offset, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, true);
            }
            else
                tempTile = new Tile8x8(tile, new byte[0x10], 0, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, true);

            tempTile.PaletteSetIndex = effects[currentEffect].PaletteIndex;
            return tempTile;
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            int offset = tile * 0x20;

            Tile8x8 tempTile;

            if (tile != 0xFF)
            {
                if (offset + 0x20 > e_animations[e_currentAnimation].GraphicSet.Length)
                    tempTile = new Tile8x8(tile, new byte[0x20], 0, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, false);
                else
                    tempTile = new Tile8x8(tile, e_animations[e_currentAnimation].GraphicSet, offset, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, false);
            }
            else
                tempTile = new Tile8x8(tile, new byte[0x20], 0, e_animations[e_currentAnimation].GetPaletteSet(effects[currentEffect].PaletteIndex), false, false, false, false);

            tempTile.PaletteSetIndex = effects[currentEffect].PaletteIndex;
            return tempTile;
        }
        private byte[] CopyOverGraphicBlockOpt(byte[] src, byte[] dest, Size s, int colspan, int tileSize, int offset)
        {
            byte[] tempTileset = new byte[s.Width * s.Height];
            for (int i = 0; i < tempTileset.Length; i++)
                tempTileset[i] = 0xFF;

            int o = 0;
            bool notEmpty = false;
            for (int b = 0; b < s.Height; b++, o++)
            {
                for (int a = 0; a < s.Width; a++, o++)
                {
                    for (int i = 0; i < tileSize; i++)
                    {
                        if (o * tileSize + i + offset >= dest.Length) return tempTileset;
                        dest[o * tileSize + i + offset] = src[b * s.Width * tileSize + (a * tileSize) + i];

                        if (!notEmpty)
                            notEmpty = dest[o * tileSize + i + offset] != 0;
                    }
                    if (!notEmpty)
                        o--;
                    else
                    {
                        tempTileset[b * s.Width + a] = (byte)o;
                        byte tmp = SearchForDuplicateSubtile(dest, (byte)o, s, tileSize, offset);
                        if (tempTileset[b * s.Width + a] != tmp)
                        {
                            tempTileset[b * s.Width + a] = tmp;
                            o--;
                        }
                    }

                    notEmpty = false;
                }
                o--;
            }

            return tempTileset;
        }
        private byte SearchForDuplicateSubtile(byte[] ts, byte index, Size s, int tileSize, int offset)
        {
            int o = 0;
            bool equal = true;
            for (int b = 0; b < s.Height; b++, o++)
            {
                for (int a = 0; a < s.Width; a++, o++)
                {
                    if (o == index)
                        return index;

                    for (int i = 0; i < tileSize; i++)
                    {
                        if (ts[o * tileSize + i + offset] != ts[index * tileSize + i + offset])
                        {
                            equal = false;
                            break;
                        }
                    }
                    if (equal)
                        return (byte)o;
                    equal = true;
                }
                o--;
            }
            return index;
        }
        private void CopyOverTileset(byte[] tempTileset, Size s)
        {
            int m = 0;
            if (tempTileset != null)
            {
                Tile16x16 e_tile;
                for (int i = 0, n = 0; n < e_tileset.Tileset.Length && (i * 2) + 1 + s.Width + m < tempTileset.Length; i++, n++)
                {
                    m = (i * 2) / s.Width * s.Width;

                    e_tile = (Tile16x16)e_tileset.Tileset[n];
                    if (e_animations[e_currentAnimation].Codec == 1)
                    {
                        e_tile.SetSubtile(Draw2bppTile8x8(tempTileset[(i * 2) + m], 0), 0);
                        e_tile.SetSubtile(Draw2bppTile8x8(tempTileset[(i * 2) + 1 + m], 0), 1);
                        e_tile.SetSubtile(Draw2bppTile8x8(tempTileset[(i * 2) + s.Width + m], 0), 2);
                        e_tile.SetSubtile(Draw2bppTile8x8(tempTileset[(i * 2) + 1 + s.Width + m], 0), 3);
                    }
                    else
                    {
                        e_tile.SetSubtile(Draw4bppTile8x8(tempTileset[(i * 2) + m], 0), 0);
                        e_tile.SetSubtile(Draw4bppTile8x8(tempTileset[(i * 2) + 1 + m], 0), 1);
                        e_tile.SetSubtile(Draw4bppTile8x8(tempTileset[(i * 2) + s.Width + m], 0), 2);
                        e_tile.SetSubtile(Draw4bppTile8x8(tempTileset[(i * 2) + 1 + s.Width + m], 0), 3);
                    }
                    if (tempTileset[(i * 2) + m] == 0xFF &&
                        tempTileset[(i * 2) + 1 + m] == 0xFF &&
                        tempTileset[(i * 2) + s.Width + m] == 0xFF &&
                        tempTileset[(i * 2) + 1 + s.Width + m] == 0xFF)
                        n--;
                    else if (SearchForDuplicateTile(tempTileset, n, i, m, s))
                        n--;
                }
            }
        }
        private bool SearchForDuplicateTile(byte[] ts, int n_, int i_, int m_, Size s)
        {
            int m = 0;
            for (int i = 0, n = 0; n < e_tileset.Tileset.Length && (i * 2) + 1 + s.Width + m < ts.Length; i++, n++)
            {
                if (n == n_) return false;

                m = (i * 2) / s.Width * s.Width;
                if (ts[(i * 2) + m] == ts[(i_ * 2) + m_] &&
                    ts[(i * 2) + 1 + m] == ts[(i_ * 2) + 1 + m_] &&
                    ts[(i * 2) + s.Width + m] == ts[(i_ * 2) + s.Width + m_] &&
                    ts[(i * 2) + 1 + s.Width + m] == ts[(i_ * 2) + 1 + s.Width + m_])
                    return true;

                if (ts[(i * 2) + m] == 0xFF &&
                    ts[(i * 2) + 1 + m] == 0xFF &&
                    ts[(i * 2) + s.Width + m] == 0xFF &&
                    ts[(i * 2) + 1 + s.Width + m] == 0xFF)
                    n--;
            }
            return false;
        }

        // import / export
        private void ExportE_GraphicBlock()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "effectGraphicBlock." + e_currentAnimation.ToString("d3") + ".bin";
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(e_animations[e_currentAnimation].GraphicSet);
                bw.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportE_GraphicBlock(string path)
        {
            int size = e_codec.SelectedIndex == 1 ? 0x10 : 0x20;

            FileStream fs;
            BinaryReader br;
            Bitmap import;

            byte[] graphicBlock = new byte[size * 0x100];

            try
            {
                fs = File.OpenRead(path);

                if (Path.GetExtension(path) == ".jpg" || Path.GetExtension(path) == ".gif" || Path.GetExtension(path) == ".png")
                {
                    import = new Bitmap(Image.FromFile(path));

                    if (e_codec.SelectedIndex == 1)
                        graphicBlock = ArrayTo2bppTile(
                            ImageToArray(import, new Size(128, 128)),
                            import.Width / 8, import.Height / 8,
                            e_animations[e_currentAnimation].GetPaletteSet((int)e_paletteIndex.Value));
                    else
                        graphicBlock = ArrayTo4bppTile(
                            ImageToArray(import, new Size(128, 128)),
                            import.Width / 8, import.Height / 8,
                            e_animations[e_currentAnimation].GetPaletteSet((int)e_paletteIndex.Value));

                    CopyOverGraphicBlock(
                        graphicBlock, e_animations[e_currentAnimation].GraphicSet, new Size(import.Width / 8, import.Height / 8), 16, size,
                        mouseOverSubtile % 16,
                        mouseOverSubtile / 16,
                        0);
                    e_animations[e_currentAnimation].GraphicSet.CopyTo(e_animations[e_currentAnimation].GraphicSetBuffer, 0);
                }
                else
                {
                    br = new BinaryReader(fs);
                    graphicBlock = br.ReadBytes((int)fs.Length);
                    graphicBlock.CopyTo(e_animations[e_currentAnimation].GraphicSet, mouseOverSubtile * size);
                    graphicBlock.CopyTo(e_animations[e_currentAnimation].GraphicSetBuffer, mouseOverSubtile * size);
                    br.Close();
                }

                fs.Close();

                e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

                SetE_GraphicImage();
                SetE_TilesetImage();
                SetE_TileImage();
                SetE_SubtileImage();
                SetE_MoldImage();
                SetE_SequenceFrameImages();
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }
        private void LoadEffectNameSearch()
        {
            listBoxEffectNames.BeginUpdate();
            listBoxEffectNames.Items.Clear();

            for (int i = 0; i < effectName.Items.Count; i++)
            {
                if (Contains(effectName.Items[i].ToString(), nameTextBoxEffects.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxEffectNames.Items.Add(effectName.Items[i]);
            }
            listBoxEffectNames.EndUpdate();
        }

        public void AssembleAllE_Animations()
        {
            e_animations[e_currentAnimation].Assemble(e_tileset);

            int i = 0;
            int pointer = 0x252C00;
            int offset = 0x330000;
            for (; i < 39 && offset < 0x33FFFF; i++, pointer += 3)
            {
                if (e_animations[i].SM.Length + offset > 0x33FFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, e_animations[i].SM);
                offset += e_animations[i].SM.Length;
            }
            if (i < 39)
                MessageBox.Show("The available space for animation data in bank 0x330000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 38 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x330000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            offset = 0x340000;
            for (; i < 64 && offset < 0x34CFFF; i++, pointer += 3)
            {
                if (e_animations[i].SM.Length + offset > 0x34CFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, e_animations[i].SM);
                offset += e_animations[i].SM.Length;
            }
            if (i < 64)
                MessageBox.Show("The available space for animation data in bank 0x340000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 63 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x340000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UpdateE_AnimationsFreeSpace()
        {
            int totalSize, min, max;
            int length = 0;

            if (e_currentAnimation < 39)
            {
                totalSize = 0xFFFF; min = 0; max = 39;
            }
            else
            {
                totalSize = 0xCFFF; min = 39; max = 64;
            }
            for (int i = min; i < max; i++)
                length += e_animations[i].SM.Length;

            e_availableBytesNum = totalSize - length;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }

        #endregion

        #region Event Handlers

        private void effectNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            effectName.SelectedIndex = currentEffect = (int)effectNum.Value;

            e_animations[e_currentAnimation].Assemble(e_tileset);

            RefreshEffectsEditor();
        }
        private void effectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            effectNum.Value = currentEffect = effectName.SelectedIndex;
        }

        private void e_animation_ValueChanged(object sender, EventArgs e)
        {
            e_colorReds.Clear();
            e_colorGreens.Clear();
            e_colorBlues.Clear();
            e_redoColorReds.Clear();
            e_redoColorGreens.Clear();
            e_redoColorBlues.Clear();

            if (updatingEffect) return;

            e_animations[e_currentAnimation].Assemble(e_tileset);

            e_currentAnimation = (int)e_animation.Value;
            effects[currentEffect].AnimationPacket = (byte)e_currentAnimation;
            InitializeE_Animation();
        }
        private void e_paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_currentPaletteShift = (int)e_paletteIndex.Value;
            effects[currentEffect].PaletteIndex = (byte)e_paletteIndex.Value;

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, (int)e_paletteIndex.Value, e_animations[e_currentAnimation].TileSetLength);

            SetE_GraphicImage();
            SetE_MoldImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_SequenceFrameImages();
        }
        private void xNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            effects[currentEffect].XNegShift = (byte)xNegShift.Value;
        }
        private void yNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            effects[currentEffect].YNegShift = (byte)yNegShift.Value;
        }

        private void e_moldWidth_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].MoldsWidth = (byte)e_moldWidth.Value;

            SetE_MoldImage();
            SetE_SequenceFrameImages();

            CalculateTotalTiles(e_moldWidth, 7);
        }
        private void e_moldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].MoldsHeight = (byte)e_moldHeight.Value;

            SetE_MoldImage();
            SetE_SequenceFrameImages();

            CalculateTotalTiles(e_moldHeight, 7);
        }

        // tileset properties
        private void e_tileSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            delta = (short)(e_tileSetSize.Value - e_currentTileSetSize);

            if (e_availableBytesNum - delta < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INCREASE TILESET SIZE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                updatingEffect = true;
                e_tileSetSize.Value = e_currentTileSetSize;
                updatingEffect = false;

                return;
            }

            e_animations[e_currentAnimation].TileSetLength = e_currentTileSetSize = (ushort)e_tileSetSize.Value;

            e_animations[e_currentAnimation].UpdateOffsets(delta, e_animations[e_currentAnimation].TileSetPointer);

            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }
        private void pictureBoxEffectTileset_Paint(object sender, PaintEventArgs e)
        {
            if (e_tilesetImage != null)
                e.Graphics.DrawImage(e_tilesetImage, 0, 0);

            overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(128, 128), new Size(16, 16), 1);

            Point p = new Point(e_currentTilesetTile % 8 * 16 + 1, e_currentTilesetTile / 8 * 16 + 1);
            Point t = new Point(e_currentTilesetTile % 8 * 16 + 16, e_currentTilesetTile / 8 * 16 + 16);
            if (p.X == 1) p.X--;
            if (p.Y == 1) p.Y--;
            overlay.DrawSelectionBox(e.Graphics, t, p, 1);
        }
        private void pictureBoxEffectTileset_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverSubtile = ((e.Y / 16) * 8) + (e.X / 16);
        }
        private void pictureBoxEffectTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e_animations[e_currentAnimation].TileSetLength / 8 <= (e.Y / 16) * 8)
                return;

            e_currentTilesetTile = ((e.Y / 16) * 8) + (e.X / 16);
            pictureBoxEffectTileset.Invalidate();

            e_currentSubtile = 0;

            InitializeE_Subtile();
            SetE_TileImage();
            SetE_SubtileImage();
        }
        private void pictureBoxEffectTileset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e_animations[e_currentAnimation].TileSetLength / 8 <= mouseOverSubtile)
                return;

            if (moldTileEmpty.Checked)
                moldTileEmpty.Checked = false;
            moldTileIndex.Value = mouseOverSubtile;
        }
        private void pictureBoxE_Tile_MouseDown(object sender, MouseEventArgs e)
        {
            e_currentSubtile = (e.X / 16) + ((e.Y / 16) * 2);

            InitializeE_Subtile();
            SetE_SubtileImage();
        }
        private void e_tileSubtile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            Tile16x16 e_tile = (Tile16x16)e_tileset.Tileset[e_currentTilesetTile];
            e_tile.SetSubtile(CreateNewE_Subtile(), e_currentSubtile);

            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void pictureBoxE_Tile_Paint(object sender, PaintEventArgs e)
        {
            if (e_tileImage != null)
                e.Graphics.DrawImage(e_tileImage, 0, 0);

            Size u = new Size(16, 16);
            overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(32, 32), u, 1);
        }
        private void pictureBoxE_Subtile_Paint(object sender, PaintEventArgs e)
        {
            if (e_subtileImage != null)
                e.Graphics.DrawImage(e_subtileImage, 0, 0);
        }
        private void setMoldTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].TileSetLength / 8 <= mouseOverSubtile)
                return;

            if (moldTileEmpty.Checked)
                moldTileEmpty.Checked = false;
            moldTileIndex.Value = mouseOverSubtile;
        }
        private void importImageAsTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select the image to import", "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|All files (*.*)|*.*", 1);
            if (path == null) return;

            int size = e_codec.SelectedIndex == 1 ? 0x10 : 0x20;

            FileStream fs;
            Bitmap import;

            byte[] graphicBlock = new byte[size * 0x100];

            //try
            //{
            fs = File.OpenRead(path);

            import = new Bitmap(Image.FromFile(path));

            if (import.Width % 16 != 0 || import.Height % 16 != 0)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be a multiple of 16." +
                    "Examples: 16x16, 32x128, 48x16, 256x64, etc...",
                    "WARNING: IMPROPER IMAGE SIZE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e_codec.SelectedIndex == 1)
                graphicBlock = ArrayTo2bppTile(
                    ImageToArray(import, new Size(256, 256)),
                    import.Width / 8, import.Height / 8,
                    e_animations[e_currentAnimation].GetPaletteSet((int)e_paletteIndex.Value));
            else
                graphicBlock = ArrayTo4bppTile(
                    ImageToArray(import, new Size(256, 256)),
                    import.Width / 8, import.Height / 8,
                    e_animations[e_currentAnimation].GetPaletteSet((int)e_paletteIndex.Value));

            byte[] tempTileset = CopyOverGraphicBlockOpt(
                graphicBlock, e_animations[e_currentAnimation].GraphicSet, new Size(import.Width / 8, import.Height / 8), 16, size, 0);
            e_animations[e_currentAnimation].GraphicSet.CopyTo(e_animations[e_currentAnimation].GraphicSetBuffer, 0);

            CopyOverTileset(tempTileset, new Size(import.Width / 8, import.Height / 8));

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_MoldImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_SequenceFrameImages();
            //}
            //catch
            //{
            //    MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
            //    return;
            //}
            fs.Close();
        }

        // palette properties
        private void E_PaletteChange()
        {
            InitializeE_PaletteColor();

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void e_paletteSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            delta = (short)(e_paletteSetSize.Value - e_currentPaletteSetSize);

            if (e_availableBytesNum - delta < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INCREASE PALETTE SET SIZE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                updatingEffect = true;
                e_paletteSetSize.Value = e_currentPaletteSetSize;
                updatingEffect = false;

                return;
            }

            e_animations[e_currentAnimation].PaletteSetLength = e_currentPaletteSetSize = (ushort)e_paletteSetSize.Value;
            e_paletteColor.Maximum = (e_animations[e_currentAnimation].PaletteSetLength / 2) - 1;

            e_animations[e_currentAnimation].UpdateOffsets(delta, e_animations[e_currentAnimation].PaletteSetPointer);

            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }
        private void e_paletteColor_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_currentColor = (int)e_paletteColor.Value;
            InitializeE_PaletteColor();

            pictureBoxE_Palette.Invalidate();
        }
        private void e_paletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteRedNum.Value -= e_paletteRedNum.Value % 8;

            e_paletteRedBar.Value = (int)e_paletteRedNum.Value;
            e_animations[e_currentAnimation].PaletteColorRed[e_currentColor] = (int)e_paletteRedNum.Value;
            this.pictureBoxE_Color.BackColor = Color.FromArgb((int)e_paletteRedNum.Value, (int)e_paletteGreenNum.Value, (int)e_paletteBlueNum.Value);

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void e_paletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteGreenNum.Value -= e_paletteGreenNum.Value % 8;

            e_paletteGreenBar.Value = (int)e_paletteGreenNum.Value;
            e_animations[e_currentAnimation].PaletteColorGreen[e_currentColor] = (int)e_paletteGreenNum.Value;
            this.pictureBoxE_Color.BackColor = Color.FromArgb((int)e_paletteRedNum.Value, (int)e_paletteGreenNum.Value, (int)e_paletteBlueNum.Value);

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void e_paletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteBlueNum.Value -= e_paletteBlueNum.Value % 8;

            e_paletteBlueBar.Value = (int)e_paletteBlueNum.Value;
            e_animations[e_currentAnimation].PaletteColorBlue[e_currentColor] = (int)e_paletteBlueNum.Value;
            this.pictureBoxE_Color.BackColor = Color.FromArgb((int)e_paletteRedNum.Value, (int)e_paletteGreenNum.Value, (int)e_paletteBlueNum.Value);

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_PaletteImage();
            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void e_paletteRedBar_Scroll(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteRedBar.Value -= e_paletteRedBar.Value % 8;
            e_paletteRedNum.Value = e_paletteRedBar.Value;
        }
        private void e_paletteGreenBar_Scroll(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteGreenBar.Value -= e_paletteGreenBar.Value % 8;
            e_paletteGreenNum.Value = e_paletteGreenBar.Value;
        }
        private void e_paletteBlueBar_Scroll(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_paletteBlueBar.Value -= e_paletteBlueBar.Value % 8;
            e_paletteBlueNum.Value = e_paletteBlueBar.Value;
        }
        private void pictureBoxE_Palette_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxE_Palette.Focus();

            if (e.Y >= e_animations[e_currentAnimation].PaletteSetLength / 2) return;
            e_paletteColor.Value = (e.Y / 16) * 16 + (e.X / 16);
        }
        private void pictureBoxE_Palette_Paint(object sender, PaintEventArgs e)
        {
            if (e_paletteImage != null)
                e.Graphics.DrawImage(e_paletteImage, 0, 0);

            Point p = new Point(e_currentColor % 16 * 16, e_currentColor / 16 * 16);
            if (p.Y == 0) p.Y++;
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15 - (p.Y % 16)), p, 1);
        }

        // sequence / frame properties
        private void e_frames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            if (PlaybackE_Sequence.IsBusy) PlaybackE_Sequence.CancelAsync();

            e_animations[e_currentAnimation].CurrentFrame = e_currentFrame = e_frames.SelectedIndex;

            RefreshE_Frames();
            SetE_SequenceFrameImage();
        }
        private void e_insertFrame_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Frames.Count == 64)
            {
                MessageBox.Show(
                    "Sequences cannot contain more than 64 frames total.", "CANNOT INSERT NEW FRAME",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e_availableBytesNum - 2 < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW FRAME",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = e_animations[e_currentAnimation].Frames.Count == 0 ? 0 : e_currentFrame + 1;

            delta = 2;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentFrameOffset);
            e_animations[e_currentAnimation].AddNewFrame(index, e_currentFrameOffset);

            InitializeE_Frames();
            SetE_SequenceFrameImages();

            e_frames.SelectedIndex = index;

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void e_deleteFrame_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Frames.Count == 1)
            {
                MessageBox.Show(
                    "Sequences must contain at least one frame.", "CANNOT DELETE FRAME",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = e_currentFrame;

            delta = -2;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentFrameOffset);
            e_animations[e_currentAnimation].RemoveCurrentFrame();

            InitializeE_Frames();
            SetE_SequenceFrameImages();

            if (index >= e_frames.Items.Count)
                e_frames.SelectedIndex = index - 1;
            else
                e_frames.SelectedIndex = index;

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void e_frameMold_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            if (e_frameMold.Value >= e_animations[e_currentAnimation].Molds.Count)
            {
                e_frameMold.Value = e_animations[e_currentAnimation].FrameMold;
                MessageBox.Show("Mold for frame #" + e_currentFrame.ToString() + " is not valid. Change to lower value.", "INVALID MOLD FOR FRAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            e_animations[e_currentAnimation].FrameMold = (byte)e_frameMold.Value;
            SetE_SequenceFrameImages();
        }
        private void e_duration_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].Duration = (byte)e_duration.Value;
            SetE_SequenceFrameImages();
        }
        private void e_moveFrameUp_Click(object sender, EventArgs e)
        {
            if (e_frames.SelectedIndex == 0)
                return;

            e_animations[e_currentAnimation].FrameOffset -= 2;
            e_animations[e_currentAnimation].CurrentFrame--;
            e_animations[e_currentAnimation].FrameOffset += 2;
            e_animations[e_currentAnimation].CurrentFrame++;

            int index = e_frames.SelectedIndex - 1;
            e_animations[e_currentAnimation].MoveCurrentFrame(index);

            InitializeE_Frames();
            SetE_SequenceFrameImages();
            e_frames.SelectedIndex = index;
        }
        private void e_moveFrameDown_Click(object sender, EventArgs e)
        {
            if (e_frames.SelectedIndex >= e_frames.Items.Count - 1)
                return;

            e_animations[e_currentAnimation].FrameOffset += 2;
            e_animations[e_currentAnimation].CurrentFrame++;
            e_animations[e_currentAnimation].FrameOffset -= 2;
            e_animations[e_currentAnimation].CurrentFrame--;

            int index = e_frames.SelectedIndex + 1;
            e_animations[e_currentAnimation].MoveCurrentFrame(index - 1);

            InitializeE_Frames();
            SetE_SequenceFrameImages();
            e_frames.SelectedIndex = index;
        }
        private void e_playSequence_Click(object sender, EventArgs e)
        {
            PlaybackE_Sequence.CancelAsync();
            e_playSequence.Enabled = false;
            e_moveBack.Enabled = false;
            e_moveFoward.Enabled = false;
            PlaybackE_Sequence.RunWorkerAsync();
        }
        private void e_pauseSequence_Click(object sender, EventArgs e)
        {
            if (PlaybackE_Sequence.IsBusy) PlaybackE_Sequence.CancelAsync();
        }
        private void e_moveBack_Click(object sender, EventArgs e)
        {
            if (e_currentFrameImage == 0) return;
            e_currentFrameImage--;

            e_frames.SelectedIndex = e_currentFrameImage;
        }
        private void e_moveFoward_Click(object sender, EventArgs e)
        {
            if (e_currentFrameImage == e_animations[e_currentAnimation].Frames.Count - 1)
                return;
            e_currentFrameImage++;

            e_frames.SelectedIndex = e_currentFrameImage;
        }
        private void pictureBoxE_Sequence_Paint(object sender, PaintEventArgs e)
        {
            if (e_currentFrame >= e_sequenceImages.Count)
                return;

            if (e_sequenceImage != null)
                e.Graphics.DrawImage(e_sequenceImage, 0, 0);
        }

        // mold properties
        private void e_molds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            int temp = e_currentMold;
            e_animations[e_currentAnimation].CurrentMold = e_currentMold = e_molds.SelectedIndex;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;  // 2009-06-09: why wasn't this here before?

            //if (animations[currentAnimation].Tiles.Count != 0 && animations[currentAnimation].TileOffset == 0xFFF)
            //{
            //    MessageBox.Show("Mold is invalid. Fix this later.", "INVALID MOLD", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    animations[currentAnimation].CurrentMold = currentMold = temp;
            //    return;
            //}

            RefreshE_Molds();
            InitializeE_Tiles();

            SetE_MoldImage();
        }
        private void e_insertMold_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Molds.Count == 32)
            {
                MessageBox.Show(
                    "Effects cannot contain more than 32 molds total.", "CANNOT INSERT NEW MOLD",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e_availableBytesNum - 2 < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW MOLD",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = e_currentMold + 1;
            e_animations[e_currentAnimation].AddNewMold(index, e_currentMoldOffset);
            delta = 2;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentMoldOffset);
            // if adding to only one mold, the mold packet pointer will need to be set back to normal
            if (e_animations[e_currentAnimation].Molds.Count == 2)
                e_animations[e_currentAnimation].MoldPacketPointer = e_currentMoldOffset;
            InitializeE_Molds();
            InitializeE_Frames();
            SetE_SequenceFrameImages();
            e_molds.SelectedIndex = index;
            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();

            moldInsertTile_Click(null, null);

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void e_deleteMold_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Molds.Count == 1)
            {
                MessageBox.Show(
                    "Effects must contain at least one mold.", "CANNOT DELETE MOLD",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = e_currentMold;
            delta = -2;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentMoldOffset);
            delta = (short)-e_animations[e_currentAnimation].MoldSize;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_animations[e_currentAnimation].TilePacketPointer);
            e_animations[e_currentAnimation].RemoveCurrentMold();

            e_availableBytesNum += 2 + e_animations[e_currentAnimation].MoldSize;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
            
            InitializeE_Molds();
            InitializeE_Frames();
            SetE_MoldImage();
            SetE_SequenceFrameImages();

            if (index >= e_molds.Items.Count)
                index--;
            e_molds.SelectedIndex = index;

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void pictureBoxE_Mold_Paint(object sender, PaintEventArgs e)
        {
            if (e_moldImage == null) return;
            Rectangle rsrc = new Rectangle(0, 0, e_moldImage.Width, e_moldImage.Height);
            Rectangle rdst = new Rectangle(0, 0, e_moldImage.Width * e_zoomM, e_moldImage.Height * e_zoomM);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(e_moldImage, rdst, rsrc, GraphicsUnit.Pixel);

            Size s = new Size(e_moldImage.Width * e_zoomM, e_moldImage.Height * e_zoomM);
            //if (e_zoomM >= 4 && e_graphicShowPixelGrid.Checked)
            //    overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), e_zoomM);
            if (e_moldShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, s, new Size(16, 16), e_zoomM);
        }
        private void pictureBoxE_Mold_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / e_zoomM;
            int y = e.Y / e_zoomM;
            Point p;
            if ((e_moldZoomIn.Checked && e.Button == MouseButtons.Left) || (e_moldZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (e_zoomM < 8)
                {
                    e_zoomM *= 2;

                    p = new Point(Math.Abs(pictureBoxE_Mold.Left), Math.Abs(pictureBoxE_Mold.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxE_Mold.Width = 256 * e_zoomM;
                    pictureBoxE_Mold.Height = 256 * e_zoomM;
                    panel101.AutoScrollPosition = p;
                    pictureBoxE_Mold.Invalidate();
                    return;
                }
                return;
            }
            else if ((e_moldZoomOut.Checked && e.Button == MouseButtons.Left) || (e_moldZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (e_zoomM > 1)
                {
                    e_zoomM /= 2;

                    p = new Point(Math.Abs(pictureBoxE_Mold.Left), Math.Abs(pictureBoxE_Mold.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxE_Mold.Width = 256 * e_zoomM;
                    pictureBoxE_Mold.Height = 256 * e_zoomM;
                    panel101.AutoScrollPosition = p;
                    pictureBoxE_Mold.Invalidate();
                    return;
                }
                return;
            }
        }
        private void e_moldShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxE_Mold.Invalidate();
        }
        private void e_moldZoomIn_Click(object sender, EventArgs e)
        {
            e_moldZoomOut.Checked = false;
            if (e_moldZoomIn.Checked)
                pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxE_Mold.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void e_moldZoomOut_Click(object sender, EventArgs e)
        {
            e_moldZoomIn.Checked = false;
            if (e_moldZoomOut.Checked)
                pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxE_Mold.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void panel101_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxE_Mold.Invalidate();
        }

        // tile properties
        private void e_tiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].CurrentTile = e_currentTile = e_tiles.SelectedIndex;

            RefreshE_Tiles();
            SetE_MoldImage();
        }
        private void moldInsertTile_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Tiles.Count == 256)
            {
                MessageBox.Show(
                    "Effects cannot contain more than 256 tiles total.", "CANNOT INSERT NEW TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e_availableBytesNum - 1 < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index;
            if (e_animations[e_currentAnimation].Tiles.Count == 0)
            {
                e_currentTileOffset = e_animations[e_currentAnimation].TilePacketPointer;
                index = e_currentTile = 0;
                e_animations[e_currentAnimation].AddNewTile(index, e_currentTileOffset);
                delta = 1;
                e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                // after updating, set back to normal
                e_animations[e_currentAnimation].TilePacketPointer = e_currentTileOffset;
                ((E_Mold.Tile)e_animations[e_currentAnimation].Tiles[0]).TileOffset = e_currentTileOffset;
            }
            else
            {
                index = e_currentTile + 1;
                e_animations[e_currentAnimation].AddNewTile(index, e_currentTileOffset);
                delta = 1;
                e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                if (e_animations[e_currentAnimation].Tiles.Count == 2)
                    e_animations[e_currentAnimation].TilePacketPointer = e_currentTileOffset;
            }
            InitializeE_Tiles();
            SetE_MoldImage();
            UpdateE_SequenceFrameImage();
            e_tiles.SelectedIndex = index;
            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
            CalculateTotalTiles(moldInsertTile, 7);

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void moldDeleteTile_Click(object sender, EventArgs e)
        {
            if (e_animations[e_currentAnimation].Tiles.Count == 1)
            {
                MessageBox.Show(
                    "Molds must contain at least one tile.", "CANNOT DELETE TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = e_currentTile;
            e_animations[e_currentAnimation].RemoveCurrentTile();
            if (e_animations[e_currentAnimation].Filler)
                delta = -3;
            else
                delta = -1;
            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);

            InitializeE_Tiles();
            SetE_MoldImage();
            UpdateE_SequenceFrameImage();

            if (index >= e_tiles.Items.Count)
                index--;
            e_tiles.SelectedIndex = index;

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();

            CalculateTotalTiles(moldDeleteTile, 7);

            e_currentFrameOffset = e_animations[e_currentAnimation].FrameOffset;
            e_currentMoldOffset = e_animations[e_currentAnimation].MoldOffset;
            e_currentTileOffset = e_animations[e_currentAnimation].TileOffset;
        }
        private void e_moveTileUp_Click(object sender, EventArgs e)
        {
            if (e_tiles.SelectedIndex == 0)
                return;

            e_animations[e_currentAnimation].TileOffset -= 2;
            e_animations[e_currentAnimation].CurrentTile--;
            e_animations[e_currentAnimation].TileOffset += 2;
            e_animations[e_currentAnimation].CurrentTile++;

            int index = e_tiles.SelectedIndex - 1;
            e_animations[e_currentAnimation].MoveCurrentTile(index);

            InitializeE_Tiles();
            SetE_SequenceFrameImages();
            e_tiles.SelectedIndex = index;
        }
        private void e_moveTileDown_Click(object sender, EventArgs e)
        {
            if (e_tiles.SelectedIndex >= e_tiles.Items.Count - 1)
                return;

            e_animations[e_currentAnimation].TileOffset += 2;
            e_animations[e_currentAnimation].CurrentTile++;
            e_animations[e_currentAnimation].TileOffset -= 2;
            e_animations[e_currentAnimation].CurrentTile--;

            int index = e_tiles.SelectedIndex + 1;
            e_animations[e_currentAnimation].MoveCurrentTile(index - 1);

            InitializeE_Tiles();
            SetE_SequenceFrameImages();
            e_tiles.SelectedIndex = index;
        }
        private void moldTileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            if (e_animations[e_currentAnimation].Filler == (moldTileFormat.SelectedIndex == 1))
                return;

            if (moldTileFormat.SelectedIndex == 1)
                delta = 2;
            else
                delta = -2;

            if (e_availableBytesNum - delta < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                moldTileFormat.SelectedIndex = 0;
                return;
            }

            e_animations[e_currentAnimation].Filler = moldTileFormat.SelectedIndex == 1;
            moldFillAmount.Enabled = moldTileFormat.SelectedIndex == 1;

            e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);

            SetE_MoldImage();
            UpdateE_SequenceFrameImage();

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }
        private void moldTileIndex_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].TileIndex = (byte)moldTileIndex.Value;

            SetE_MoldImage();
            UpdateE_SequenceFrameImage();
        }
        private void moldFillAmount_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].FillAmount = (byte)moldFillAmount.Value;

            SetE_MoldImage();
            UpdateE_SequenceFrameImage();

            CalculateTotalTiles(moldFillAmount, 7);
        }
        private void moldTileEmpty_CheckedChanged(object sender, EventArgs e)
        {
            moldTileEmpty.ForeColor = moldTileEmpty.Checked ? SystemColors.ControlText : SystemColors.ControlDark;

            if (updatingEffect) return;

            e_animations[e_currentAnimation].Empty = moldTileEmpty.Checked;
            moldTileIndex.Enabled = !moldTileEmpty.Checked;

            if (moldTileEmpty.Checked)
                e_animations[e_currentAnimation].TileIndex = (byte)0xFF;
            else
                e_animations[e_currentAnimation].TileIndex = (byte)moldTileIndex.Value;

            SetE_MoldImage();
            UpdateE_SequenceFrameImage();
        }
        private void moldTileProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].Mirrored = moldTileProp.GetItemChecked(0);
            e_animations[e_currentAnimation].Inverted = moldTileProp.GetItemChecked(1);

            SetE_MoldImage();
            UpdateE_SequenceFrameImage();
        }

        private void clearAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (e_animations[e_currentAnimation].Tiles.Count > 1)
            {
                e_animations[e_currentAnimation].CurrentTile = 1;

                if (e_animations[e_currentAnimation].Filler)
                    delta = -3;
                else
                    delta = -1;

                e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                e_animations[e_currentAnimation].RemoveCurrentTile();

                e_availableBytesNum -= delta;
            }

            InitializeE_Tiles();
            SetE_MoldImage();
            UpdateE_SequenceFrameImage();

            e_tiles.SelectedIndex = 0;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }
        private void insertTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTileType.SelectedIndex = 0;

            panelInsertTile.BringToFront();
            panelInsertTile.Visible = true;
        }
        private void insertTileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            insertTileAmount.Enabled = insertTileType.SelectedIndex != 3;
            insertTileWidth.Enabled = insertTileType.SelectedIndex >= 2;
            insertTileHeight.Enabled = insertTileType.SelectedIndex == 3;
        }
        private void insertTileAmount_ValueChanged(object sender, EventArgs e)
        {

        }
        private void insertTileOK_Click(object sender, EventArgs e)
        {
            int max;
            if (insertTileType.SelectedIndex == 1) // ordered
            {
                max = (int)(insertTileAmount.Value * insertTileWidth.Value);
                for (int i = e_currentTile, size = 0, line = 0; i < insertTileAmount.Value; i++, size++, line++)
                {
                    if (e_availableBytesNum - 2 < 0)
                    {
                        int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                        MessageBox.Show(
                            "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    delta = 1;
                    e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                    e_animations[e_currentAnimation].AddNewTile(i, e_currentTileOffset);
                    e_availableBytesNum -= delta;
                    e_animations[e_currentAnimation].CurrentTile = i + 1;

                    e_animations[e_currentAnimation].TileIndex = (byte)i;
                }
            }
            else if (insertTileType.SelectedIndex == 2) // pattern
            {
                for (int i = e_currentTile, w = 0; i < insertTileAmount.Value * insertTileWidth.Value && i < 255; i++, w++)
                {
                    if (w == insertTileWidth.Value) w = 0;

                    if (e_availableBytesNum - 2 < 0)
                    {
                        int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                        MessageBox.Show(
                            "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    delta = 1;
                    e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                    e_animations[e_currentAnimation].AddNewTile(i + 1, e_currentTileOffset);
                    e_availableBytesNum -= delta;
                    e_animations[e_currentAnimation].CurrentTile = i + 1;

                    e_animations[e_currentAnimation].TileIndex = (byte)w;
                }
            }
            else if (insertTileType.SelectedIndex == 3) // wallpaper
            {
                clearAllTilesToolStripMenuItem_Click(null, null);

                int i = 0, h = 0;
                for (int y = 0; y < e_moldHeight.Value && i < 255; y++, i++, h++)
                {
                    if (h == insertTileHeight.Value) h = 0;
                    for (int x = 0, w = 0; x < e_moldWidth.Value && i < 255; x++, i++, w++)
                    {
                        if (w == insertTileWidth.Value) w = 0;
                        if (e_availableBytesNum - 2 < 0)
                        {
                            int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                            MessageBox.Show(
                                "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        delta = 1;
                        e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                        e_animations[e_currentAnimation].AddNewTile(i, e_currentTileOffset);
                        e_availableBytesNum -= delta;
                        e_animations[e_currentAnimation].CurrentTile = i;

                        e_animations[e_currentAnimation].TileIndex = (byte)(h * insertTileWidth.Value + w);
                    }
                    i--;
                }
            }
            else // empty
            {
                for (int i = e_currentTile, size = 0, line = 0; i < insertTileAmount.Value; i++, size++, line++)
                {
                    if (e_availableBytesNum - 2 < 0)
                    {
                        int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                        MessageBox.Show(
                            "Not enough available bytes in bank 0x" + bank.ToString("X6") + ".", "CANNOT INSERT NEW TILE",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    delta = 1;
                    e_animations[e_currentAnimation].UpdateOffsets(delta, e_currentTileOffset);
                    e_animations[e_currentAnimation].AddNewTile(i, e_currentTileOffset);
                    e_availableBytesNum -= delta;
                    e_animations[e_currentAnimation].CurrentTile = i + 1;

                    e_animations[e_currentAnimation].Empty = true;
                    e_animations[e_currentAnimation].TileIndex = (byte)0xFF;
                }
            }
            InitializeE_Tiles();
            SetE_MoldImage();
            UpdateE_SequenceFrameImage();

            e_tiles.SelectedIndex = 0;

            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();

            panelInsertTile.Visible = false;
            panelInsertTile.SendToBack();
        }
        private void insertTileCancel_Click(object sender, EventArgs e)
        {
            panelInsertTile.Visible = false;
            panelInsertTile.SendToBack();
        }

        // graphics properties
        private void e_graphicSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            delta = (short)(e_graphicSetSize.Value - e_currentGraphicSetSize);

            if (e_availableBytesNum - delta < 0)
            {
                int bank = effects[currentEffect].AnimationPacket < 39 ? 0x330000 : 0x340000;
                MessageBox.Show(
                    "Not enough available bytes in bank " + bank.ToString("X6") + ".", "CANNOT INCREASE GRAPHIC SET SIZE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                updatingEffect = true;
                e_graphicSetSize.Value = e_currentGraphicSetSize;
                updatingEffect = false;

                return;
            }

            e_animations[e_currentAnimation].GraphicSetLength = e_currentGraphicSetSize = (ushort)e_graphicSetSize.Value;

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            e_animations[e_currentAnimation].UpdateOffsets(delta, e_animations[e_currentAnimation].GraphicSetPointer);

            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();

            e_availableBytesNum -= delta;
            e_availableBytes.Text = "AVAILABLE BYTES: " + e_availableBytesNum.ToString();
        }
        private void e_codec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingEffect) return;

            e_animations[e_currentAnimation].Codec = (ushort)e_codec.SelectedIndex;
            e_graphicSetSize.Increment = e_codec.SelectedIndex == 1 ? 0x10 : 0x20;
            if (e_codec.SelectedIndex == 0)
            {
                e_animations[e_currentAnimation].GraphicSetLength &= 0xFFE0;
                e_graphicSetSize.Value = e_animations[e_currentAnimation].GraphicSetLength;
            }

            e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, effects[currentEffect].PaletteIndex, e_animations[e_currentAnimation].TileSetLength);

            SetE_GraphicImage();
            SetE_TilesetImage();
            SetE_TileImage();
            SetE_SubtileImage();
            SetE_MoldImage();
            SetE_SequenceFrameImages();
        }
        private void pictureBoxE_Graphics_Paint(object sender, PaintEventArgs e)
        {
            if (e_graphicImage == null) return;
            Rectangle rsrc = new Rectangle(0, 0, e_graphicImage.Width, e_graphicImage.Height);
            Rectangle rdst = new Rectangle(0, 0, e_graphicImage.Width * e_zoomG, e_graphicImage.Height * e_zoomG);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(e_graphicImage, rdst, rsrc, GraphicsUnit.Pixel);

            Size s = new Size(e_graphicImage.Width * e_zoomG, e_graphicImage.Height * e_zoomG);
            if (e_zoomG >= 4 && e_graphicShowPixelGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), e_zoomG);
            if (e_graphicShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, s, new Size(8, 8), e_zoomG);
        }
        private void e_graphicShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxE_Graphics.Invalidate();
        }
        private void e_graphicShowPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxE_Graphics.Invalidate();
        }
        private void e_subtileDraw_Click(object sender, EventArgs e)
        {
            e_subtileErase.Checked = false;
            e_subtileDropper.Checked = false;
            e_graphicZoomIn.Checked = false;
            e_graphicZoomOut.Checked = false;

            if (!e_subtileDraw.Checked)
                pictureBoxE_Graphics.Cursor = Cursors.Arrow;
            else
                pictureBoxE_Graphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDraw.cur");
        }
        private void e_subtileErase_Click(object sender, EventArgs e)
        {
            e_subtileDraw.Checked = false;
            e_subtileDropper.Checked = false;
            e_graphicZoomIn.Checked = false;
            e_graphicZoomOut.Checked = false;

            if (!e_subtileErase.Checked)
                pictureBoxE_Graphics.Cursor = Cursors.Arrow;
            else
                pictureBoxE_Graphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorErase.cur");
        }
        private void e_subtileDropper_Click(object sender, EventArgs e)
        {
            e_subtileDraw.Checked = false;
            e_subtileErase.Checked = false;
            e_graphicZoomIn.Checked = false;
            e_graphicZoomOut.Checked = false;

            if (!e_subtileDropper.Checked)
                pictureBoxE_Graphics.Cursor = Cursors.Arrow;
            else
                pictureBoxE_Graphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
        }
        private void e_graphicZoomIn_Click(object sender, EventArgs e)
        {
            e_subtileDraw.Checked = false;
            e_subtileErase.Checked = false;
            e_subtileDropper.Checked = false;
            e_graphicZoomOut.Checked = false;
            if (e_graphicZoomIn.Checked)
                pictureBoxE_Graphics.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxE_Graphics.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (e_graphicZoomIn.Checked)
                pictureBoxE_Graphics.ContextMenuStrip = null;
            else
                pictureBoxE_Graphics.ContextMenuStrip = contextMenuStripGR;
        }
        private void e_graphicZoomOut_Click(object sender, EventArgs e)
        {
            e_subtileDraw.Checked = false;
            e_subtileErase.Checked = false;
            e_subtileDropper.Checked = false;
            e_graphicZoomIn.Checked = false;
            if (e_graphicZoomOut.Checked)
                pictureBoxE_Graphics.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxE_Graphics.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (e_graphicZoomOut.Checked)
                pictureBoxE_Graphics.ContextMenuStrip = null;
            else
                pictureBoxE_Graphics.ContextMenuStrip = contextMenuStripGR;
        }

        private void pictureBoxE_Graphics_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxE_Graphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e_graphicZoomIn.Checked || e_graphicZoomIn.Checked)
                return;

            setAsSubtileToolStripMenuItem_Click(null, null);
        }
        private void pictureBoxE_Graphics_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
        private void pictureBoxE_Graphics_MouseDown(object sender, MouseEventArgs e)
        {
            panel89.Enabled = false;
            pictureBoxE_Graphics.Focus();
            panel89.Enabled = true;

            Point p;
            if ((e_graphicZoomIn.Checked && e.Button == MouseButtons.Left) || (e_graphicZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (e_zoomG < 8)
                {
                    e_zoomG *= 2;

                    p = new Point(Math.Abs(pictureBoxE_Graphics.Left), Math.Abs(pictureBoxE_Graphics.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxE_Graphics.Width = 128 * e_zoomG;
                    pictureBoxE_Graphics.Height = 128 * e_zoomG;
                    panel89.AutoScrollPosition = p;
                    pictureBoxE_Graphics.Invalidate();
                    return;
                }
                return;
            }
            else if ((e_graphicZoomOut.Checked && e.Button == MouseButtons.Left) || (e_graphicZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (e_zoomG > 1)
                {
                    e_zoomG /= 2;

                    p = new Point(Math.Abs(pictureBoxE_Graphics.Left), Math.Abs(pictureBoxE_Graphics.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxE_Graphics.Width = 128 * e_zoomG;
                    pictureBoxE_Graphics.Height = 128 * e_zoomG;
                    panel89.AutoScrollPosition = p;
                    pictureBoxE_Graphics.Invalidate();
                    return;
                }
                return;
            }

            pictureBoxE_Graphics_MouseMove(sender, e);
        }
        private void pictureBoxE_Graphics_MouseEnter(object sender, EventArgs e)
        {

        }
        private void pictureBoxE_Graphics_MouseLeave(object sender, EventArgs e)
        {

        }
        private void pictureBoxE_Graphics_MouseMove(object sender, MouseEventArgs e)
        {
            byte[] graphicSet = e_animations[e_currentAnimation].GraphicSet;

            mouseOverControl = pictureBoxE_Graphics.Name;
            mouseOverSubtile = (e.Y / (8 * e_zoomG)) * 16 + (e.X / (8 * e_zoomG));
            this.e_coordsLabel.Text = "subtile " + mouseOverSubtile.ToString("d4");

            // editing
            if (e.X > pictureBoxE_Graphics.Width || e.Y > pictureBoxE_Graphics.Height || e.X < 0 || e.Y < 0) return;

            byte row = (byte)(e.Y / e_zoomG % 8);
            byte col = (byte)(e.X / e_zoomG % 8);
            byte bit = (byte)(col ^ 7);
            int offset;
            if (e_codec.SelectedIndex == 1)
                offset = mouseOverSubtile * 0x10;
            else
                offset = mouseOverSubtile * 0x20;
            offset += row * 2;

            int r, g, b;
            int temp = 0;
            if (e.Button == MouseButtons.Left)
            {
                //if (e_currentPixels == (e.X / e_zoomG) + (e.Y / e_zoomG)) 
                //    return;
                if (e_subtileDraw.Checked)
                {
                    r = e_animations[e_currentAnimation].PaletteColorRed[e_currentColor];
                    g = e_animations[e_currentAnimation].PaletteColorGreen[e_currentColor];
                    b = e_animations[e_currentAnimation].PaletteColorBlue[e_currentColor];
                    Rectangle n = new Rectangle(new Point(e.X - (e.X % e_zoomG), e.Y - (e.Y % e_zoomG)), new Size(e_zoomG, e_zoomG));

                    if (e_codec.SelectedIndex == 1)
                    {
                        BitManager.SetBit(graphicSet, offset, bit, (e_currentColor & 1) == 1);
                        BitManager.SetBit(graphicSet, offset + 1, bit, (e_currentColor & 2) == 2);
                    }
                    else
                    {
                        BitManager.SetBit(graphicSet, offset, bit, (e_currentColor & 1) == 1);
                        BitManager.SetBit(graphicSet, offset + 1, bit, (e_currentColor & 2) == 2);
                        BitManager.SetBit(graphicSet, offset + 16, bit, (e_currentColor & 4) == 4);
                        BitManager.SetBit(graphicSet, offset + 17, bit, (e_currentColor & 8) == 8);
                    }

                    Point p = new Point(e.X / e_zoomG * e_zoomG, e.Y / e_zoomG * e_zoomG);
                    Rectangle c;
                    if (e_zoomG >= 4 && e_graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(e_zoomG - 1, e_zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(e_zoomG, e_zoomG));
                    pictureBoxE_Graphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (e_subtileErase.Checked)
                {
                    r = e_animations[e_currentAnimation].PaletteColorRed[0];
                    g = e_animations[e_currentAnimation].PaletteColorGreen[0];
                    b = e_animations[e_currentAnimation].PaletteColorBlue[0];

                    if (e_codec.SelectedIndex == 1)
                    {
                        BitManager.SetBit(graphicSet, offset, bit, false);
                        BitManager.SetBit(graphicSet, offset + 1, bit, false);
                    }
                    else
                    {
                        BitManager.SetBit(graphicSet, offset, bit, false);
                        BitManager.SetBit(graphicSet, offset + 1, bit, false);
                        BitManager.SetBit(graphicSet, offset + 16, bit, false);
                        BitManager.SetBit(graphicSet, offset + 17, bit, false);
                    }

                    Point p = new Point(e.X / e_zoomG * e_zoomG, e.Y / e_zoomG * e_zoomG);
                    Rectangle c;
                    if (e_zoomG >= 4 && e_graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(e_zoomG - 1, e_zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(e_zoomG, e_zoomG));
                    pictureBoxE_Graphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (e_subtileDropper.Checked)
                {
                    if (e_codec.SelectedIndex == 1)
                    {
                        if (BitManager.GetBit(graphicSet, offset, bit)) temp |= 1;
                        if (BitManager.GetBit(graphicSet, offset + 1, bit)) temp |= 2;
                    }
                    else
                    {
                        if (BitManager.GetBit(graphicSet, offset, bit)) temp |= 1;
                        if (BitManager.GetBit(graphicSet, offset + 1, bit)) temp |= 2;
                        if (BitManager.GetBit(graphicSet, offset + 16, bit)) temp |= 4;
                        if (BitManager.GetBit(graphicSet, offset + 17, bit)) temp |= 8;
                    }

                    temp += (int)e_paletteIndex.Value * 16;
                    e_paletteColor.Value = temp;
                }
                e_currentPixel = (e.X / e_zoomG) + (e.Y / e_zoomG);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (e_currentPixel == (e.X / e_zoomG) + (e.Y / e_zoomG)) return;
                if (e_subtileDraw.Checked)
                {
                    r = e_animations[e_currentAnimation].PaletteColorRed[0];
                    g = e_animations[e_currentAnimation].PaletteColorGreen[0];
                    b = e_animations[e_currentAnimation].PaletteColorBlue[0];

                    if (e_codec.SelectedIndex == 1)
                    {
                        BitManager.SetBit(graphicSet, offset, bit, (e_currentColor & 1) == 1);
                        BitManager.SetBit(graphicSet, offset + 1, bit, (e_currentColor & 2) == 2);
                    }
                    else
                    {
                        BitManager.SetBit(graphicSet, offset, bit, false);
                        BitManager.SetBit(graphicSet, offset + 1, bit, false);
                        BitManager.SetBit(graphicSet, offset + 16, bit, false);
                        BitManager.SetBit(graphicSet, offset + 17, bit, false);
                    }

                    Point p = new Point(e.X / e_zoomG * e_zoomG, e.Y / e_zoomG * e_zoomG);
                    Rectangle c;
                    if (e_zoomG >= 4 && e_graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(e_zoomG - 1, e_zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(e_zoomG, e_zoomG));
                    pictureBoxE_Graphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (e_subtileDropper.Checked)
                {
                    if (e_codec.SelectedIndex == 1)
                    {
                        if (BitManager.GetBit(graphicSet, offset, bit)) temp |= 1;
                        if (BitManager.GetBit(graphicSet, offset + 1, bit)) temp |= 2;
                    }
                    else
                    {
                        if (BitManager.GetBit(graphicSet, offset, bit)) temp |= 1;
                        if (BitManager.GetBit(graphicSet, offset + 1, bit)) temp |= 2;
                        if (BitManager.GetBit(graphicSet, offset + 16, bit)) temp |= 4;
                        if (BitManager.GetBit(graphicSet, offset + 17, bit)) temp |= 8;
                    }

                    temp += (int)e_paletteIndex.Value * 16;
                    e_paletteColor.Value = temp;
                }
                e_currentPixel = (e.X / e_zoomG) + (e.Y / e_zoomG);
            }
        }
        private void pictureBoxE_Graphics_MouseUp(object sender, MouseEventArgs e)
        {
            if (!e_subtileDraw.Checked && !e_subtileErase.Checked) return;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                e_animations[e_currentAnimation].GraphicSet.CopyTo(e_animations[e_currentAnimation].GraphicSetBuffer, 0);
                e_tileset.RedrawTileset(e_animations[e_currentAnimation].GraphicSet, (int)e_paletteIndex.Value, e_animations[e_currentAnimation].TileSetLength);
                SetE_GraphicImage();
                SetE_MoldImage();
                SetE_TilesetImage();
                SetE_TileImage();
                SetE_SubtileImage();
                SetE_SequenceFrameImages();
            }
        }

        private void panel89_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxE_Graphics.Invalidate();
        }

        private void CalculateTotalTiles(Control control, int lines)
        {
            //int total = 0;
            //foreach (E_Mold m in e_animations[e_currentAnimation].Molds)
            //{
            //    // calculate the total # of tiles in each mold
            //    foreach (E_Mold.Tile t in m.Tiles)
            //        total += t.Filler ? t.FillAmount : 1;

            //    // if less than width * height, we must fill up with empty tiles
            //    if (total < e_animations[e_currentAnimation].MoldsWidth * e_animations[e_currentAnimation].MoldsHeight)
            //    {
            //        if (toolTipName == control.Name)
            //        {
            //            toolTip2.Hide(control);
            //            return;
            //        }
            //        toolTip2.Show(
            //            "The mold dimensions exceed the number of tiles needed to\n" +
            //            "fill the remaining space. There may be problems in-game\n" +
            //            "when the mold is displayed.\n\n" +
            //            "Try inserting another tile, setting its format to \"filler\", and\n" +
            //            "setting the fill amount to a value large enough to fill the\n" +
            //            "remaing space. Or, decrease the mold width or height.",
            //            control, control.Width - 16, -((lines * 13) + 62));
            //        toolTipName = control.Name;
            //    }
            //    else
            //    {
            //        toolTip2.Hide(control);
            //        toolTipName = "";
            //    }
            //}
        }

        private void searchEffectNames_Click(object sender, EventArgs e)
        {
            panelSearchEffectNames.Visible = !panelSearchEffectNames.Visible;
            if (panelSearchEffectNames.Visible)
            {
                panelSearchEffectNames.BringToFront();
                nameTextBoxEffects.Focus();
            }
        }
        private void listBoxEffectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                effectName.SelectedItem = listBoxEffectNames.SelectedItem;
            }
            catch
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void listBoxEffectNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchEffectNames.Visible = false;
        }
        private void nameTextBoxEffects_TextChanged(object sender, EventArgs e)
        {
            LoadEffectNameSearch();
        }
        private void nameTextBoxEffects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchEffectNames.Visible = false;
        }

        // color math
        private void colorBalance_Click(object sender, EventArgs e)
        {
            e_colEdit = false;
            panelColorBalance.BringToFront();
            panelColorBalance.Visible = !panelColorBalance.Visible;
        }
        private void coleditSelectCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            colEditComboBoxA.Enabled = false;
            colEditComboBoxB.Enabled = false;
            colEditValueA.Enabled = false;
            colEditReds.Enabled = false;
            colEditGreens.Enabled = false;
            colEditBlues.Enabled = false;
            colEditLabelA.Text = "";
            colEditLabelB.Text = "";
            colEditLabelC.Text = "";
            colEditLabelD.Text = "";

            switch (coleditSelectCommand.SelectedIndex)
            {
                case 0:
                    colEditComboBoxA.Enabled = true;
                    colEditComboBoxB.Enabled = true;
                    if (coleditSelectCommand.SelectedIndex == 0)
                        colEditLabelA.Text = "Switch";
                    colEditLabelB.Text = "with";
                    colEditComboBoxA.SelectedIndex = 0;
                    colEditComboBoxB.SelectedIndex = 0;
                    break;
                case 1: colEditLabelC.Text = "Add"; goto case 4;
                case 2: colEditLabelC.Text = "Subtract"; goto case 4;
                case 3: colEditLabelC.Text = "Multiply by"; goto case 4;
                case 4:
                    if (coleditSelectCommand.SelectedIndex == 4)
                        colEditLabelC.Text = "Divide by";
                    colEditLabelD.Text = "for";
                    colEditValueA.Enabled = true;
                    colEditReds.Enabled = true;
                    colEditGreens.Enabled = true;
                    colEditBlues.Enabled = true;
                    break;
                case 5: colEditLabelA.Text = "Equate"; goto case 0;
                case 6: colEditLabelC.Text = "Set to"; goto case 4;
            }
        }
        private void colEditReds_CheckedChanged(object sender, EventArgs e)
        {
            colEditReds.ForeColor = colEditReds.Checked ? Color.Black : Color.Gray;
        }
        private void colEditGreens_CheckedChanged(object sender, EventArgs e)
        {
            colEditGreens.ForeColor = colEditGreens.Checked ? Color.Black : Color.Gray;
        }
        private void colEditBlues_CheckedChanged(object sender, EventArgs e)
        {
            colEditBlues.ForeColor = colEditBlues.Checked ? Color.Black : Color.Gray;
        }
        private void colEditSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colEditColors.Items.Count; i++)
                colEditColors.SetItemChecked(i, false);
        }
        private void colEditSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colEditColors.Items.Count; i++)
                colEditColors.SetItemChecked(i, true);
        }
        private void colEditRowSelectAll_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < 16; i++)
                colEditColors.SetItemChecked(i, e.Index == 0);
            e.NewValue = CheckState.Unchecked;
        }
        private void colEditApply_Click(object sender, EventArgs e)
        {
            int[] temp;
            int[] reds, greens, blues;
            if (e_colEdit)
            {
                reds = e_animations[e_currentAnimation].PaletteColorRed;
                greens = e_animations[e_currentAnimation].PaletteColorGreen;
                blues = e_animations[e_currentAnimation].PaletteColorBlue;
            }
            else
            {
                reds = spritePalettes[currentPalette].PaletteColorRed;
                greens = spritePalettes[currentPalette].PaletteColorGreen;
                blues = spritePalettes[currentPalette].PaletteColorBlue;
            }
            temp = new int[reds.Length];
            reds.CopyTo(temp, 0);
            if (e_colEdit)
                e_colorReds.Push(temp);
            else colorReds.Push(temp);
            temp = new int[greens.Length];
            greens.CopyTo(temp, 0);
            if (e_colEdit)
                e_colorGreens.Push(temp);
            else colorGreens.Push(temp);
            temp = new int[blues.Length];
            blues.CopyTo(temp, 0);
            if (e_colEdit)
                e_colorBlues.Push(temp);
            else colorBlues.Push(temp);

            int tempA = 0;
            int tempB = 0;
            for (int i = 0; i < 16; i++)
            {
                int index = i;
                if (colEditColors.GetItemChecked(index))
                {
                    switch (coleditSelectCommand.SelectedIndex)
                    {
                        case 0:
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: tempA = reds[i]; break;
                                case 1: tempA = greens[i]; break;
                                case 2: tempA = blues[i]; break;
                            }
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: tempB = reds[i]; break;
                                case 1: tempB = greens[i]; break;
                                case 2: tempB = blues[i]; break;
                            }
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: reds[i] = tempB; break;
                                case 1: greens[i] = tempB; break;
                                case 2: blues[i] = tempB; break;
                            }
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: reds[i] = tempA; break;
                                case 1: greens[i] = tempA; break;
                                case 2: blues[i] = tempA; break;
                            }
                            break;
                        case 1:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Min(248, reds[i] + colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Min(248, greens[i] + colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Min(248, blues[i] + colEditValueA.Value);
                            break;
                        case 2:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Max(0, reds[i] - colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Max(0, greens[i] - colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Max(0, blues[i] - colEditValueA.Value);
                            break;
                        case 3:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Min(248, reds[i] * colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Min(248, greens[i] * colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Min(248, blues[i] * colEditValueA.Value);
                            break;
                        case 4:
                            if (colEditReds.Checked)
                                reds[i] /= (int)colEditValueA.Value;
                            if (colEditGreens.Checked)
                                greens[i] /= (int)colEditValueA.Value;
                            if (colEditBlues.Checked)
                                blues[i] /= (int)colEditValueA.Value;
                            break;
                        case 5:
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: tempA = reds[i]; break;
                                case 1: tempA = greens[i]; break;
                                case 2: tempA = blues[i]; break;
                            }
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: reds[i] = tempA; break;
                                case 1: greens[i] = tempA; break;
                                case 2: blues[i] = tempA; break;
                            }
                            break;
                        case 6:
                            if (colEditReds.Checked)
                                reds[i] = (int)colEditValueA.Value;
                            if (colEditGreens.Checked)
                                greens[i] = (int)colEditValueA.Value;
                            if (colEditBlues.Checked)
                                blues[i] = (int)colEditValueA.Value;
                            break;
                    }
                }
            }
            if (e_colEdit)
                E_PaletteChange();
            else
                PaletteChange();
        }
        private void colEditReset_Click(object sender, EventArgs e)
        {
            if (e_colEdit)
            {
                if (e_colorReds.Count == 0)
                    return;
                for (int i = 0; i < e_colorReds.Count; i++)
                {
                    e_redoColorReds.Push(e_animations[e_currentAnimation].PaletteColorRed);
                    e_redoColorGreens.Push(e_animations[e_currentAnimation].PaletteColorGreen);
                    e_redoColorBlues.Push(e_animations[e_currentAnimation].PaletteColorBlue);

                    e_animations[e_currentAnimation].PaletteColorRed = e_colorReds.Peek();
                    e_animations[e_currentAnimation].PaletteColorGreen = e_colorGreens.Peek();
                    e_animations[e_currentAnimation].PaletteColorBlue = e_colorBlues.Peek();

                    e_colorReds.Pop();
                    e_colorGreens.Pop();
                    e_colorBlues.Pop();
                }

                E_PaletteChange();
            }
            else
            {
                if (colorReds.Count == 0)
                    return;
                for (int i = 0; i < colorReds.Count; i++)
                {
                    redoColorReds.Push(spritePalettes[currentPalette].PaletteColorRed);
                    redoColorGreens.Push(spritePalettes[currentPalette].PaletteColorGreen);
                    redoColorBlues.Push(spritePalettes[currentPalette].PaletteColorBlue);

                    spritePalettes[currentPalette].PaletteColorRed = colorReds.Peek();
                    spritePalettes[currentPalette].PaletteColorGreen = colorGreens.Peek();
                    spritePalettes[currentPalette].PaletteColorBlue = colorBlues.Peek();

                    colorReds.Pop();
                    colorGreens.Pop();
                    colorBlues.Pop();
                }

                PaletteChange();
            }
        }
        private void colEditUndo_Click(object sender, EventArgs e)
        {
            if (e_colEdit)
            {
                if (e_colorReds.Count == 0)
                    return;

                e_redoColorReds.Push(e_animations[e_currentAnimation].PaletteColorRed);
                e_redoColorGreens.Push(e_animations[e_currentAnimation].PaletteColorGreen);
                e_redoColorBlues.Push(e_animations[e_currentAnimation].PaletteColorBlue);

                e_animations[e_currentAnimation].PaletteColorRed = e_colorReds.Peek();
                e_animations[e_currentAnimation].PaletteColorGreen = e_colorGreens.Peek();
                e_animations[e_currentAnimation].PaletteColorBlue = e_colorBlues.Peek();

                e_colorReds.Pop();
                e_colorGreens.Pop();
                e_colorBlues.Pop();

                E_PaletteChange();
            }
            else
            {
                if (colorReds.Count == 0)
                    return;

                redoColorReds.Push(spritePalettes[currentPalette].PaletteColorRed);
                redoColorGreens.Push(spritePalettes[currentPalette].PaletteColorGreen);
                redoColorBlues.Push(spritePalettes[currentPalette].PaletteColorBlue);

                spritePalettes[currentPalette].PaletteColorRed = colorReds.Peek();
                spritePalettes[currentPalette].PaletteColorGreen = colorGreens.Peek();
                spritePalettes[currentPalette].PaletteColorBlue = colorBlues.Peek();

                colorReds.Pop();
                colorGreens.Pop();
                colorBlues.Pop();

                PaletteChange();
            }
        }
        private void colEditRedo_Click(object sender, EventArgs e)
        {
            if (e_colEdit)
            {
                if (e_redoColorReds.Count == 0)
                    return;

                e_colorReds.Push(e_animations[e_currentAnimation].PaletteColorRed);
                e_colorGreens.Push(e_animations[e_currentAnimation].PaletteColorGreen);
                e_colorBlues.Push(e_animations[e_currentAnimation].PaletteColorBlue);

                e_animations[e_currentAnimation].PaletteColorRed = e_redoColorReds.Peek();
                e_animations[e_currentAnimation].PaletteColorGreen = e_redoColorGreens.Peek();
                e_animations[e_currentAnimation].PaletteColorBlue = e_redoColorBlues.Peek();

                e_redoColorReds.Pop();
                e_redoColorGreens.Pop();
                e_redoColorBlues.Pop();

                E_PaletteChange();
            }
            else
            {
                if (redoColorReds.Count == 0)
                    return;

                colorReds.Push(spritePalettes[currentPalette].PaletteColorRed);
                colorGreens.Push(spritePalettes[currentPalette].PaletteColorGreen);
                colorBlues.Push(spritePalettes[currentPalette].PaletteColorBlue);

                spritePalettes[currentPalette].PaletteColorRed = redoColorReds.Peek();
                spritePalettes[currentPalette].PaletteColorGreen = redoColorGreens.Peek();
                spritePalettes[currentPalette].PaletteColorBlue = redoColorBlues.Peek();

                redoColorReds.Pop();
                redoColorGreens.Pop();
                redoColorBlues.Pop();

                PaletteChange();
            }
        }

        private void e_ColorBalance_Click(object sender, EventArgs e)
        {
            e_colEdit = true;
            panelColorBalance.BringToFront();
            panelColorBalance.Visible = !panelColorBalance.Visible;
        }

        #endregion
    }
}
