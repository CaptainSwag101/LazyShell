using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SMRPGED.Properties;

namespace SMRPGED
{
    public partial class Sprites
    {
        #region Variables

        private bool updatingSprite = false;

        private Sprite[] sprites;
        private GraphicPalette[] graphicPalettes;
        private Animation[] animations; 
        public Animation[] Animations { get { return animations; } set { animations = value; } }
        private SpritePalette[] spritePalettes;

        private byte[] spriteGraphics;
        private ArrayList sequenceImages = new ArrayList();

        private int currentSprite;
        private int currentGraphicPalette;
        private int currentColor;
        private int currentPixel;
        private int currentTile;
        private int currentSequence;
        private int currentFrame;
        private int currentMold;
        private int currentPalette;
        private int currentPaletteShift;
        private int currentAnimation;
        private int currentSubtile;
        private int currentCopy;

        private ushort currentSequenceOffset;
        private ushort currentFrameOffset;
        private ushort currentMoldOffset;
        private ushort currentTileOffset;

        private bool mouseOverTile;
        private bool mouseClickTile;
        private int mouseOverSubtile;
        private byte[] sequenceDurations;
        private int currentFrameImage = 0;

        private short delta = 0;
        private int zoomG = 1;
        private int zoomM = 1;

        private Point mouse;
        private Point previous;

        private Mold moldCopy;

        #endregion

        #region Methods

        // initialize properties
        private void InitializeSpritesEditor()
        {
            updatingSprite = true;

            this.spriteGraphics = model.SpriteGraphics;
            this.sprites = spriteModel.Sprites;
            this.graphicPalettes = spriteModel.GraphicPalettes;
            this.animations = spriteModel.Animation;
            this.spritePalettes = spriteModel.SpritePalettes;

            for (int i = 0; i < settings.SpriteNames.Count; i++)
                spriteName.Items.Add("[" + i.ToString("d4") + "]  " + settings.SpriteNames[i]);
            currentSprite = 0;
            this.spriteNum.Value = 0;
            this.spriteName.SelectedIndex = 0;

            RefreshSpritesEditor();

            updatingSprite = false;

            GC.Collect();
        }

        private void InitializeSpritePalette()
        {
            updatingSprite = true;

            currentPalette = graphicPalettes[currentGraphicPalette].PaletteNum;
            this.paletteOffset.Value = currentPalette;
            currentColor = 0;
            this.mapPaletteColor.Value = currentColor;

            updatingSprite = false;
        }
        private void InitializeSpritePaletteColor()
        {
            updatingSprite = true;

            mapPaletteRedNum.Value = spritePalettes[currentPalette].PaletteColorRed[currentColor];
            mapPaletteGreenNum.Value = spritePalettes[currentPalette].PaletteColorGreen[currentColor];
            mapPaletteBlueNum.Value = spritePalettes[currentPalette].PaletteColorBlue[currentColor];
            mapPaletteRedBar.Value = spritePalettes[currentPalette].PaletteColorRed[currentColor];
            mapPaletteGreenBar.Value = spritePalettes[currentPalette].PaletteColorGreen[currentColor];
            mapPaletteBlueBar.Value = spritePalettes[currentPalette].PaletteColorBlue[currentColor];

            this.pictureBoxColor.BackColor = Color.FromArgb((int)mapPaletteRedNum.Value, (int)mapPaletteGreenNum.Value, (int)mapPaletteBlueNum.Value);

            updatingSprite = false;
        }
        private void InitializeMolds()
        {
            updatingSprite = true;

            molds.BeginUpdate();

            currentMold = 0;
            currentTile = 0;
            currentSubtile = 0;

            this.molds.Items.Clear();
            for (int i = 0; i < animations[currentAnimation].Molds.Count; i++)
            {
                this.molds.Items.Add("Mold " + i.ToString());
                animations[currentAnimation].CurrentMold = i;
            }
            this.molds.SelectedIndex = 0;

            animations[currentAnimation].CurrentMold = currentMold;
            UpdateAllTile8x8SubTiles();

            moldFormat.SelectedIndex = animations[currentAnimation].Gridplane ? 0 : 1;

            currentMoldOffset = animations[currentAnimation].MoldOffset;

            molds.EndUpdate();

            updatingSprite = false;
        }
        private void InitializeTile()
        {
            updatingSprite = true;

            currentTile = 0;
            currentSubtile = 0;

            moldTileSize.Items.Clear();
            moldTileProperties.Items.Clear();

            if (animations[currentAnimation].Tiles.Count == 0)
            {
                insertTile.Enabled = true;
                deleteTile.Enabled = false;
                panel38.Enabled = false;
                Mold m = (Mold)animations[currentAnimation].Molds[currentMold]; // 2009-02-06
                currentTileOffset = m.TilePacketPointer;    // 2009-02-06   we need an initial offset based on the tile packet pointer
            }
            else if (animations[currentAnimation].Gridplane)
            {
                panel38.Enabled = true;

                moldTileSize.Items.AddRange(new string[] { "24x24", "24x32", "32x24", "32x32" });
                moldTileProperties.Items.AddRange(new string[] { "Mirror", "Invert", "Y++", "Y--" });
                insertTile.Enabled = false;
                deleteTile.Enabled = false;
                quadrantNW.Enabled = false;
                quadrantNE.Enabled = false;
                quadrantSW.Enabled = false;
                quadrantSE.Enabled = false;
                moldTileXCoord.Enabled = false;
                moldTileYCoord.Enabled = false;
                moldTileCopies.Enabled = false;
                moldTileCopiesOffset.Enabled = false;
                moldSubtile.Maximum = 511;

                animations[currentAnimation].CurrentTile = 0;
                animations[currentAnimation].Set8x8Tiles(
                    BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                    spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                    animations[currentAnimation].Gridplane);

                moldTileSize.Enabled = true;
                moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;
                moldTileProperties.SetItemChecked(0, animations[currentAnimation].Mirror);
                moldTileProperties.SetItemChecked(1, animations[currentAnimation].Invert);
                moldTileProperties.SetItemChecked(2, animations[currentAnimation].YPlusOne == 1);
                moldTileProperties.SetItemChecked(3, animations[currentAnimation].YMinusOne == 1);

                currentTileOffset = animations[currentAnimation].TileOffset;
            }
            else
            {
                panel38.Enabled = true;

                moldTileSize.Items.AddRange(new string[] { "Normal", "16-bit", "Copy" });
                moldTileProperties.Items.AddRange(new string[] { "Mirror", "Invert" });
                insertTile.Enabled = true;
                if (animations[currentAnimation].Tiles.Count > 1)
                    deleteTile.Enabled = true;
                else
                    deleteTile.Enabled = false;
                moldTileXCoord.Enabled = true;
                moldTileYCoord.Enabled = true;
                moldTileCopies.Enabled = true;
                moldTileCopiesOffset.Enabled = true;

                UpdateAllTile8x8SubTiles();

                moldTileProperties.SetItemChecked(0, animations[currentAnimation].Mirror);
                moldTileProperties.SetItemChecked(1, animations[currentAnimation].Invert);

                if (animations[currentAnimation].TileFormat == 2)
                {
                    quadrantNE.Enabled = false;
                    quadrantNW.Enabled = false;
                    quadrantSE.Enabled = false;
                    quadrantSW.Enabled = false;
                    moldTileProperties.Enabled = true;
                    moldTileCopies.Enabled = true;
                    moldTileCopiesOffset.Enabled = true;
                    moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;

                    moldTileXCoord.Value = animations[currentAnimation].XCoordChange;
                    moldTileYCoord.Value = animations[currentAnimation].YCoordChange;
                    moldTileCopies.Value = animations[currentAnimation].CopyAmount;
                    moldTileCopiesOffset.Value = animations[currentAnimation].CopyPacketOffset;

                    currentCopy = animations[currentAnimation].CopyAmount;
                }
                else
                {
                    quadrantNE.Enabled = true;
                    quadrantNW.Enabled = true;
                    quadrantSE.Enabled = true;
                    quadrantSW.Enabled = true;
                    if (animations[currentAnimation].TileFormat == 1)
                        moldSubtile.Maximum = 511;
                    else
                        moldSubtile.Maximum = 255;
                    moldTileProperties.Enabled = true;
                    moldTileCopies.Enabled = false;
                    moldTileCopiesOffset.Enabled = false;
                    moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;
                    quadrantNW.Checked = animations[currentAnimation].Quadrants[0];
                    quadrantNE.Checked = animations[currentAnimation].Quadrants[1];
                    quadrantSW.Checked = animations[currentAnimation].Quadrants[2];
                    quadrantSE.Checked = animations[currentAnimation].Quadrants[3];

                    moldTileXCoord.Value = animations[currentAnimation].XCoord;
                    moldTileYCoord.Value = animations[currentAnimation].YCoord;
                }

                currentTileOffset = animations[currentAnimation].TileOffset;
            }

            updatingSprite = false;
        }
        private void InitializeSubtile()
        {
            updatingSprite = true;

            if (animations[currentAnimation].Tiles.Count == 0 || animations[currentAnimation].TileOffset == 0x7FFF)
                panel38.Enabled = false;
            else if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
            {
                panel38.Enabled = true;
                moldSubtile.Enabled = false;
            }
            else if (animations[currentAnimation].SubTiles[currentSubtile] == 0)
            {
                moldSubtile.Enabled = false;
            }
            else
            {
                panel38.Enabled = true;
                moldSubtile.Value = animations[currentAnimation].SubTiles[currentSubtile];
                moldSubtile.Enabled = true;
            }

            updatingSprite = false;
        }
        private void InitializeSequences()
        {
            updatingSprite = true;

            sequences.BeginUpdate();

            this.animationVRAM.Value = animations[currentAnimation].VramAllocation;

            this.sequences.Items.Clear();
            for (int i = 0; i < animations[currentAnimation].Sequences.Count; i++)
                this.sequences.Items.Add("Sequence " + i.ToString());
            this.sequences.SelectedIndex = 0;
            animations[currentAnimation].CurrentSequence = 0;

            currentSequenceOffset = animations[currentAnimation].SequenceOffset;

            sequences.EndUpdate();

            updatingSprite = false;
        }
        private void InitializeFrames()
        {
            updatingSprite = true;

            sequenceFrames.BeginUpdate();

            this.sequenceFrames.Items.Clear();
            for (int i = 0; i < animations[currentAnimation].Frames.Count; i++)
                this.sequenceFrames.Items.Add("Frame " + i.ToString());

            if (animations[currentAnimation].Frames.Count == 0)
            {
                this.frameMold.Enabled = false;
                this.frameDuration.Enabled = false;
                this.buttonPlay.Enabled = false;
                this.buttonStop.Enabled = false;
                this.buttonFoward.Enabled = false;
                this.buttonBack.Enabled = false;
                this.deleteFrame.Enabled = false;
                if (animations[currentAnimation].FramePacketPointer == 0x7FFF)
                {
                    this.insertFrame.Enabled = false;
                    MessageBox.Show("This is a dummied sequence. It cannot contain any frames.", "NOTE: DUMMIED SEQUENCE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.insertFrame.Enabled = true;
                this.frameMoveDown.Enabled = false;
                this.frameMoveUp.Enabled = false;
            }
            else
            {
                this.frameMold.Enabled = true;
                this.frameDuration.Enabled = true;
                this.buttonPlay.Enabled = true;
                this.buttonStop.Enabled = true;
                this.buttonFoward.Enabled = true;
                this.buttonBack.Enabled = true;
                this.insertFrame.Enabled = true;
                this.deleteFrame.Enabled = true;
                this.frameMoveDown.Enabled = true;
                this.frameMoveUp.Enabled = true;

                this.sequenceFrames.SelectedIndex = 0;
                animations[currentAnimation].CurrentFrame = 0;

                this.frameMold.Value = animations[currentAnimation].FrameMold;
                this.frameDuration.Value = animations[currentAnimation].Duration;

                currentFrameOffset = animations[currentAnimation].FrameOffset;
            }

            sequenceFrames.EndUpdate();

            updatingSprite = false;
        }

        // refresh properties
        private void RefreshSpritesEditor()
        {
            updatingSprite = true;

            this.graphicPalettePacket.Value = currentGraphicPalette = sprites[currentSprite].GraphicPalettePacket;
            this.graphicPalettePacketShift.Value = currentPaletteShift = sprites[currentSprite].GraphicPalettePacketShift;
            this.animationPacket.Value = currentAnimation = sprites[currentSprite].AnimationPacket;

            this.graphicOFfset.Value = graphicPalettes[currentGraphicPalette].GraphicOffset;

            InitializeSpritePalette();
            InitializeSpritePaletteColor();
            InitializeMolds();
            InitializeTile();
            InitializeSubtile();
            InitializeSequences();
            InitializeFrames();

            SetAllImages();

            UpdateAnimationsFreeSpace();

            updatingSprite = false;

            GC.Collect();
        }

        private void RefreshMolds()
        {
            updatingSprite = true;

            currentTile = 0;
            currentSubtile = 0;

            moldFormat.SelectedIndex = animations[currentAnimation].Gridplane ? 0 : 1;

            currentMoldOffset = animations[currentAnimation].MoldOffset;

            updatingSprite = false;
        }
        private void RefreshTiles()
        {
            updatingSprite = true;

            currentSubtile = 0;

            moldTileSize.Items.Clear();
            moldTileProperties.Items.Clear();

            if (animations[currentAnimation].Tiles.Count == 0)
            {
                insertTile.Enabled = true;
                deleteTile.Enabled = false;
                panel38.Enabled = false;
            }
            else if (animations[currentAnimation].Gridplane)
            {
                panel38.Enabled = true;

                moldTileSize.Items.AddRange(new string[] { "24x24", "24x32", "32x24", "32x32" });
                moldTileProperties.Items.AddRange(new string[] { "Mirror", "Invert", "Y++", "Y--" });
                insertTile.Enabled = false;
                deleteTile.Enabled = false;
                quadrantNW.Enabled = false;
                quadrantNE.Enabled = false;
                quadrantSW.Enabled = false;
                quadrantSE.Enabled = false;
                moldTileXCoord.Enabled = false;
                moldTileYCoord.Enabled = false;
                moldTileCopies.Enabled = false;
                moldTileCopiesOffset.Enabled = false;
                moldSubtile.Maximum = 511;

                animations[currentAnimation].CurrentTile = 0;
                animations[currentAnimation].Set8x8Tiles(
                    BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                    spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                    animations[currentAnimation].Gridplane);

                moldTileSize.Enabled = true;
                moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;
                moldTileProperties.SetItemChecked(0, animations[currentAnimation].Mirror);
                moldTileProperties.SetItemChecked(1, animations[currentAnimation].Invert);
                moldTileProperties.SetItemChecked(2, animations[currentAnimation].YPlusOne == 1);
                moldTileProperties.SetItemChecked(3, animations[currentAnimation].YMinusOne == 1);

                currentTileOffset = animations[currentAnimation].TileOffset;
            }
            else
            {
                panel38.Enabled = true;

                moldTileSize.Items.AddRange(new string[] { "Normal", "16-bit", "Copy" });
                moldTileProperties.Items.AddRange(new string[] { "Mirror", "Invert" });
                insertTile.Enabled = true;
                if (animations[currentAnimation].Tiles.Count > 1)
                    deleteTile.Enabled = true;
                else
                    deleteTile.Enabled = false;
                moldTileXCoord.Enabled = true;
                moldTileYCoord.Enabled = true;
                moldTileCopies.Enabled = true;
                moldTileCopiesOffset.Enabled = true;

                UpdateAllTile8x8SubTiles();

                moldTileProperties.SetItemChecked(0, animations[currentAnimation].Mirror);
                moldTileProperties.SetItemChecked(1, animations[currentAnimation].Invert);

                if (animations[currentAnimation].TileFormat == 2)
                {
                    quadrantNE.Enabled = false;
                    quadrantNW.Enabled = false;
                    quadrantSE.Enabled = false;
                    quadrantSW.Enabled = false;
                    moldTileProperties.Enabled = true;
                    moldTileCopies.Enabled = true;
                    moldTileCopiesOffset.Enabled = true;
                    moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;

                    moldTileXCoord.Value = animations[currentAnimation].XCoordChange;
                    moldTileYCoord.Value = animations[currentAnimation].YCoordChange;
                    moldTileCopies.Value = animations[currentAnimation].CopyAmount;
                    moldTileCopiesOffset.Value = animations[currentAnimation].CopyPacketOffset;

                    currentCopy = animations[currentAnimation].CopyAmount;
                }
                else
                {
                    quadrantNE.Enabled = true;
                    quadrantNW.Enabled = true;
                    quadrantSE.Enabled = true;
                    quadrantSW.Enabled = true;
                    if (animations[currentAnimation].TileFormat == 1)
                        moldSubtile.Maximum = 511;
                    else
                        moldSubtile.Maximum = 255;
                    moldTileProperties.Enabled = true;
                    moldTileCopies.Enabled = false;
                    moldTileCopiesOffset.Enabled = false;
                    moldTileSize.SelectedIndex = animations[currentAnimation].TileFormat;
                    quadrantNW.Checked = animations[currentAnimation].Quadrants[0];
                    quadrantNE.Checked = animations[currentAnimation].Quadrants[1];
                    quadrantSW.Checked = animations[currentAnimation].Quadrants[2];
                    quadrantSE.Checked = animations[currentAnimation].Quadrants[3];

                    moldTileXCoord.Value = animations[currentAnimation].XCoord;
                    moldTileYCoord.Value = animations[currentAnimation].YCoord;
                }

                currentTileOffset = animations[currentAnimation].TileOffset;
            }

            updatingSprite = false;
        }
        private void RefreshSubtile()
        {
            updatingSprite = true;

            moldSubtile.Value = animations[currentAnimation].SubTiles[currentSubtile];

            updatingSprite = false;
        }
        private void RefreshFrames()
        {
            updatingSprite = true;

            this.frameMold.Value = animations[currentAnimation].FrameMold;
            this.frameDuration.Value = animations[currentAnimation].Duration;

            currentFrameOffset = animations[currentAnimation].FrameOffset;

            updatingSprite = false;
        }

        private void UpdateAllTile8x8SubTiles()
        {
            int tl = animations[currentAnimation].CurrentTile;
            for (int i = 0; i < animations[currentAnimation].Tiles.Count; i++)
            {
                animations[currentAnimation].CurrentTile = i;
                if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                {
                    int cp = animations[currentAnimation].CurrentCopy;
                    for (int j = 0; j < animations[currentAnimation].Copies.Count; j++)
                    {
                        animations[currentAnimation].CurrentCopy = j;
                        animations[currentAnimation].Set8x8Tiles(
                            BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                            spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                            animations[currentAnimation].Gridplane);
                    }
                    if (animations[currentAnimation].Copies.Count != 0)
                        animations[currentAnimation].CurrentCopy = cp;
                }
                else
                {
                    animations[currentAnimation].Set8x8Tiles(
                        BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                        spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                        animations[currentAnimation].Gridplane);
                }
            }
            if (animations[currentAnimation].Tiles.Count != 0)
                animations[currentAnimation].CurrentTile = tl;
        }

        private void PlaybackSequence_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; !PlaybackSequence.CancellationPending; i++)
            {
                if (PlaybackSequence.CancellationPending) break;
                if (i >= sequenceImages.Count) i = 0;
                currentFrameImage = i;
                sequenceImage = (Bitmap)sequenceImages[i];
                pictureBoxSequence.Invalidate();
                Thread.Sleep(sequenceDurations[i] * (1000 / 60));
                if (PlaybackSequence.CancellationPending) break;
            }
        }
        private void PlaybackSequence_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonPlay.Enabled = true;
            buttonBack.Enabled = true;
            buttonFoward.Enabled = true;
        }

        // set images
        private void SetAllImages()
        {
            SetPaletteImage();
            SetGraphicImage();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();
        }
        private void SetPaletteImage()
        {
            palettePixels = spritePalettes[currentPalette].GetPalettePixels();
            paletteImage = new Bitmap(DrawImageFromIntArr(palettePixels, 256, 64));
            pictureBoxPalette.Invalidate();
        }
        private void SetGraphicImage()
        {
            graphicPixels = GetGraphicPixels();
            graphicImage = new Bitmap(DrawImageFromIntArr(graphicPixels, 128, 256));
            //pictureBoxGraphics.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            pictureBoxGraphics.Invalidate();
        }
        private void SetMoldImage()
        {
            moldPixels = animations[currentAnimation].MoldPixels(!mouseClickTile);
            moldImage = new Bitmap(DrawImageFromIntArr(moldPixels, 256, 256));
            //pictureBoxMold.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            pictureBoxMold.Invalidate();
        }
        private void SetTilesetImage()
        {
            if (animations[currentAnimation].Gridplane)
            {
                pictureBoxMoldTileset.Invalidate();
                return;
            }

            tilesetPixels = animations[currentAnimation].TilesetPixels;
            tilesetImage = new Bitmap(DrawImageFromIntArr(tilesetPixels, 128, 64));
            //pictureBoxMoldTileset.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            pictureBoxMoldTileset.Invalidate();
        }
        private void SetTileImage()
        {
            if (animations[currentAnimation].Tiles.Count == 0)
            {
                pictureBoxMoldTile.Invalidate();
                return;
            }
            if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
            {
                pictureBoxMoldTile.Invalidate();
                return;
            }

            tilePixels = animations[currentAnimation].TilePixels;
            tileImage = new Bitmap(DrawImageFromIntArr(tilePixels, 32, 32));
            //pictureBoxMoldTile.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            pictureBoxMoldTile.Invalidate();
        }
        private void SetSubtileImage()
        {
            if (animations[currentAnimation].Tiles.Count == 0 || animations[currentAnimation].TileOffset == 0x7FFF)
            {
                pictureBoxMoldSubtile.Invalidate();
                return;
            }
            if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
            {
                pictureBoxMoldSubtile.Invalidate();
                return;
            }
            if (animations[currentAnimation].Subtiles[currentSubtile] == null)
            {
                pictureBoxMoldSubtile.Invalidate();
                return;
            }

            moldSubtile.Enabled = true;
            subtilePixels = animations[currentAnimation].SubtilePixels(currentSubtile);
            subtileImage = new Bitmap(DrawImageFromIntArr(subtilePixels, 32, 32));
            //pictureBoxMoldSubtile.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            pictureBoxMoldSubtile.Invalidate();
        }
        private void UpdateSequenceFrameImage()
        {
            if (sequenceImages.Count == 0) return;

            int md = animations[currentAnimation].CurrentMold;
            int fr = animations[currentAnimation].CurrentFrame;
            for (int i = 0; i < animations[currentAnimation].Frames.Count; i++)
            {
                animations[currentAnimation].CurrentFrame = i;
                if (animations[currentAnimation].FrameMold == molds.SelectedIndex)
                {
                    framePixels = animations[currentAnimation].MoldPixels(false);
                    frameImage = new Bitmap(DrawImageFromIntArr(framePixels, 256, 256));
                    sequenceImages.RemoveAt(i);
                    sequenceImages.Insert(i, new Bitmap(frameImage));
                    break;
                }
            }

            animations[currentAnimation].CurrentFrame = fr;
            animations[currentAnimation].CurrentMold = md;

            if (frameMold.Value == molds.SelectedIndex) SetSequenceFrameImage();
        }
        private void SetSequenceFrameImages()
        {
            sequenceImages.Clear();
            sequenceDurations = new byte[animations[currentAnimation].Frames.Count];
            int md = animations[currentAnimation].CurrentMold;
            int fr = animations[currentAnimation].CurrentFrame;
            for (int i = 0; i < animations[currentAnimation].Frames.Count; i++)
            {
                animations[currentAnimation].CurrentFrame = i;
                if (animations[currentAnimation].FrameMold < animations[currentAnimation].Molds.Count)
                {
                    animations[currentAnimation].CurrentMold = animations[currentAnimation].FrameMold;
                    UpdateAllTile8x8SubTiles();
                    framePixels = animations[currentAnimation].MoldPixels(false);
                    frameImage = new Bitmap(DrawImageFromIntArr(framePixels, 256, 256));
                    sequenceImages.Add(new Bitmap(frameImage));
                }
                else
                {
                    MessageBox.Show("Mold for frame #" + i.ToString() + " is not valid. Change to lower value.", "INVALID MOLD FOR FRAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sequenceImages.Add(new Bitmap(256, 256));
                }
                sequenceDurations[i] = animations[currentAnimation].Duration;
            }

            currentFrame = fr;
            if (animations[currentAnimation].Frames.Count != 0)
            {
                animations[currentAnimation].CurrentFrame = currentFrame;
                animations[currentAnimation].CurrentMold = md;
            }

            SetSequenceFrameImage();
        }
        private void SetSequenceFrameImage()
        {
            if (currentFrame < sequenceImages.Count)
            {
                sequenceImage = new Bitmap((Bitmap)sequenceImages[currentFrame]);
                pictureBoxSequence.BackColor = Color.FromArgb(spritePalettes[currentPalette].PaletteColorRed[0], spritePalettes[currentPalette].PaletteColorGreen[0], spritePalettes[currentPalette].PaletteColorBlue[0]);
            }
            pictureBoxSequence.Invalidate();
        }

        // drawing
        private int[] GetGraphicPixels()
        {
            int[] pixels = graphicPalettes[currentGraphicPalette].GetGraphicPixels(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette());
            int[] zoomed = new int[128 * 256];

            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 128; x++)
                    zoomed[y * 128 + x] = pixels[y * 128 + x];
            }

            return zoomed;
        }
        private Bitmap GridImage(Size s, int z)
        {
            int[] zoomed = new int[s.Width * z * s.Height * z];

            if (z >= 4 && graphicShowPixelGrid.Checked)
            {
                for (int y = z - 1; y < s.Height * z; y += z)  // draw the horizontal gridlines
                {
                    for (int x = 0; x < s.Width * z; x++)
                        zoomed[y * s.Width * z + x] = Color.DarkRed.ToArgb();
                }
                for (int x = z - 1; x < s.Width * z; x += z) // draw the vertical gridlines
                {
                    for (int y = 0; y < s.Height * z; y++)
                        zoomed[y * s.Width * z + x] = Color.DarkRed.ToArgb();
                }
            }

            if (graphicShowGrid.Checked)
            {
                for (int y = 8 * z - 1; y < s.Height * z; y += 8 * z)  // draw the horizontal gridlines
                {
                    for (int x = 0; x < s.Width * z; x++)
                        zoomed[y * s.Width * z + x] = Color.Gray.ToArgb();
                }
                for (int x = 8 * z - 1; x < s.Width * z; x += 8 * z) // draw the vertical gridlines
                {
                    for (int y = 0; y < s.Height * z; y++)
                        zoomed[y * s.Width * z + x] = Color.Gray.ToArgb();
                }
            }

            return DrawImageFromIntArr(zoomed, s.Width * z, s.Height * z);
        }

        // import / export
        private void ExportGraphicBlock()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "spriteGraphicBlock." + graphicPalettes[currentGraphicPalette].GraphicOffset.ToString("X6") + ".bin";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            byte[] graphicBlock = BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000);

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(graphicBlock);
                bw.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportGraphicBlock(string path)
        {
            FileStream fs;
            BinaryReader br;
            Bitmap import;

            byte[] graphicBlock = new byte[0x4000];

            try
            {
                fs = File.OpenRead(path);

                if (Path.GetExtension(path) == ".jpg" || Path.GetExtension(path) == ".gif" || Path.GetExtension(path) == ".png")
                {
                    import = new Bitmap(Image.FromFile(path));
                    graphicBlock = ArrayTo4bppTile(ImageToArray(import, new Size(128, 256)), import.Width / 8, import.Height / 8, spritePalettes[currentPalette].Get4bppPalette());
                    CopyOverGraphicBlock(
                        graphicBlock, spriteGraphics, new Size(import.Width / 8, import.Height / 8), 16, 0x20,
                        (mouseOverSubtile - 1) % 16,
                        (mouseOverSubtile - 1) / 16,
                        graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000);
                    fs.Close();
                }
                else
                {
                    br = new BinaryReader(fs);
                    graphicBlock = br.ReadBytes((int)fs.Length);
                    graphicBlock.CopyTo(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000 + ((mouseOverSubtile - 1) * 0x20));
                    br.Close();
                    fs.Close();
                }
                graphicOFfset_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }
        private void LoadSpriteNameSearch()
        {
            listBoxSpriteNames.BeginUpdate();
            listBoxSpriteNames.Items.Clear();

            for (int i = 0; i < spriteName.Items.Count; i++)
            {
                if (Contains(spriteName.Items[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxSpriteNames.Items.Add(spriteName.Items[i]);
            }
            listBoxSpriteNames.EndUpdate();
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

        // assemblers
        private void AssembleAllGraphicPalettes()
        {
            foreach (GraphicPalette gp in graphicPalettes)
                gp.Assemble();
        }
        public void AssembleAllAnimations()
        {
            foreach (Animation sm in animations)
                sm.Assemble();

            int i = 0;
            int pointer = 0x252000;
            int offset = 0x259000;
            for (; i < 42 && offset < 0x25FFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x25FFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 42)
                MessageBox.Show("The available space for animation data in bank 0x250000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 41 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x250000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            offset = 0x260000;
            for (; i < 107 && offset < 0x26FFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x26FFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 107)
                MessageBox.Show("The available space for animation data in bank 0x260000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 107 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x260000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            offset = 0x270000;
            for (; i < 249 && offset < 0x27FFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x27FFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 249)
                MessageBox.Show("The available space for animation data in bank 0x270000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 249 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x270000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            offset = 0x360000;
            for (; i < 444 && offset < 0x36FFFF; i++, pointer += 3)
            {
                if (animations[i].SM.Length + offset > 0x36FFFF)
                    break;
                BitManager.SetShort(data, pointer, (ushort)offset);
                BitManager.SetByte(data, pointer + 2, (byte)((offset >> 16) + 0xC0));
                BitManager.SetByteArray(data, offset, animations[i].SM);
                offset += animations[i].SM.Length;
            }
            if (i < 444)
                MessageBox.Show("The available space for animation data in bank 0x360000 has exceeded the alotted space.\nAnimation #'s " + i.ToString() + " through 444 will not saved. Please make sure the available animation bytes is not negative.", "WARNING: ANIMATION DATA FOR BANK 0x360000 TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void AssembleAllSpritePalettes()
        {
            foreach (SpritePalette sp in spritePalettes)
                sp.Assemble();
        }

        private void UpdateAnimationsFreeSpace()
        {
            int totalSize, min, max;
            int length = 0;

            if (currentAnimation < 42)
            {
                totalSize = 0x7000; min = 0; max = 42;
            }
            else if (currentAnimation < 107)
            {
                totalSize = 0xFFFF; min = 42; max = 107;
            }
            else if (currentAnimation < 249)
            {
                totalSize = 0xFFFF; min = 107; max = 249;
            }
            else
            {
                totalSize = 0xFFFF; min = 249; max = 444;
            }
            for (int i = min; i < max; i++)
                length += animations[i].SM.Length;

            animationAvailableBytes.Text = "AVAILABLE BYTES: " + (totalSize - length).ToString();
        }

        #endregion

        #region Eventhandlers

        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            spriteNum.Value = currentSprite = spriteName.SelectedIndex;
        }
        private void spriteNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            spriteName.SelectedIndex = currentSprite = (int)spriteNum.Value;

            RefreshSpritesEditor();
        }

        private void graphicPalettePacket_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            currentGraphicPalette = (int)this.graphicPalettePacket.Value;
            sprites[currentSprite].GraphicPalettePacket = (ushort)currentGraphicPalette;

            this.graphicOFfset.Value = graphicPalettes[currentGraphicPalette].GraphicOffset;

            InitializeSpritePalette();
            UpdateAllTile8x8SubTiles();
            SetPaletteImage();
            SetGraphicImage();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();
        }
        private void graphicPalettePacketShift_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            currentPaletteShift = (int)this.graphicPalettePacketShift.Value;
            sprites[currentSprite].GraphicPalettePacketShift = (byte)currentPaletteShift;

            UpdateAllTile8x8SubTiles();
            SetGraphicImage();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();
        }
        private void animationPacket_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            currentAnimation = (int)this.animationPacket.Value;
            sprites[currentSprite].AnimationPacket = (ushort)currentAnimation;

            InitializeMolds();
            InitializeTile();
            InitializeSubtile();
            InitializeSequences();
            InitializeFrames();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();
        }

        // Palette properties
        private void PaletteChange()
        {
            InitializeSpritePaletteColor();

            UpdateAllTile8x8SubTiles();
            SetAllImages();
        }
        private void paletteOffset_ValueChanged(object sender, EventArgs e)
        {
            colorReds.Clear();
            colorGreens.Clear();
            colorBlues.Clear();
            redoColorReds.Clear();
            redoColorGreens.Clear();
            redoColorBlues.Clear();

            if (updatingSprite) return;

            currentPalette = (int)paletteOffset.Value;
            graphicPalettes[currentGraphicPalette].PaletteNum = currentPalette;

            InitializeSpritePaletteColor();
            UpdateAllTile8x8SubTiles();
            SetAllImages();
        }
        private void pictureBoxPalette_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxPalette.Focus();

            if (e.Y >= 16) return;
            mapPaletteColor.Value = e.X / 16;
        }
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0);

            Point p = new Point(currentColor % 16 * 16, currentColor / 16 * 16);
            if (p.Y == 0) p.Y++;
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15 - (p.Y % 16)), p, 1);
        }
        private void mapPaletteColor_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            currentColor = (int)mapPaletteColor.Value;
            InitializeSpritePaletteColor();

            pictureBoxPalette.Invalidate();
        }
        private void mapPaletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteRedNum.Value -= mapPaletteRedNum.Value % 8;

            mapPaletteRedBar.Value = (int)mapPaletteRedNum.Value;
            spritePalettes[currentPalette].PaletteColorRed[currentColor] = (int)mapPaletteRedNum.Value;
            this.pictureBoxColor.BackColor = Color.FromArgb((int)mapPaletteRedNum.Value, (int)mapPaletteGreenNum.Value, (int)mapPaletteBlueNum.Value);

            UpdateAllTile8x8SubTiles();
            SetAllImages();
        }
        private void mapPaletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteGreenNum.Value -= mapPaletteGreenNum.Value % 8;

            mapPaletteGreenBar.Value = (int)mapPaletteGreenNum.Value;
            spritePalettes[currentPalette].PaletteColorGreen[currentColor] = (int)mapPaletteGreenNum.Value;
            this.pictureBoxColor.BackColor = Color.FromArgb((int)mapPaletteRedNum.Value, (int)mapPaletteGreenNum.Value, (int)mapPaletteBlueNum.Value);

            UpdateAllTile8x8SubTiles();
            SetAllImages();
        }
        private void mapPaletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteBlueNum.Value -= mapPaletteBlueNum.Value % 8;

            mapPaletteBlueBar.Value = (int)mapPaletteBlueNum.Value;
            spritePalettes[currentPalette].PaletteColorBlue[currentColor] = (int)mapPaletteBlueNum.Value;
            this.pictureBoxColor.BackColor = Color.FromArgb((int)mapPaletteRedNum.Value, (int)mapPaletteGreenNum.Value, (int)mapPaletteBlueNum.Value);

            UpdateAllTile8x8SubTiles();
            SetAllImages();
        }
        private void mapPaletteRedBar_Scroll(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteRedBar.Value -= mapPaletteRedBar.Value % 8;
            mapPaletteRedNum.Value = mapPaletteRedBar.Value;
        }
        private void mapPaletteGreenBar_Scroll(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteGreenBar.Value -= mapPaletteGreenBar.Value % 8;
            mapPaletteGreenNum.Value = mapPaletteGreenBar.Value;
        }
        private void mapPaletteBlueBar_Scroll(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            mapPaletteBlueBar.Value -= mapPaletteBlueBar.Value % 8;
            mapPaletteBlueNum.Value = mapPaletteBlueBar.Value;
        }

        // Sequence/frame properties
        private void animationVRAM_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            animations[currentAnimation].VramAllocation = (ushort)animationVRAM.Value;
        }
        private void sequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (PlaybackSequence.IsBusy) PlaybackSequence.CancelAsync();

            currentFrame = 0;
            animations[currentAnimation].CurrentSequence = currentSequence = sequences.SelectedIndex;

            currentSequenceOffset = animations[currentAnimation].SequenceOffset;

            InitializeFrames();
            SetSequenceFrameImages();
        }
        private void sequenceFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (PlaybackSequence.IsBusy) PlaybackSequence.CancelAsync();

            animations[currentAnimation].CurrentFrame = currentFrame = sequenceFrames.SelectedIndex;

            RefreshFrames();
            SetSequenceFrameImage();
        }
        private void frameMold_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (frameMold.Value >= animations[currentAnimation].Molds.Count)
            {
                frameMold.Value = animations[currentAnimation].FrameMold;
                MessageBox.Show("Mold for frame #" + currentFrame.ToString() + " is not valid. Change to lower value.", "INVALID MOLD FOR FRAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            animations[currentAnimation].FrameMold = (byte)frameMold.Value;
            SetSequenceFrameImages();
        }
        private void frameDuration_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            animations[currentAnimation].Duration = (byte)frameDuration.Value;
            SetSequenceFrameImages();
        }
        private void insertSequence_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Sequences.Count == 16)
            {
                MessageBox.Show(
                    "Sprites cannot contain more than 16 sequences total.", "CANNOT INSERT NEW SEQUENCE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = currentSequence + 1;
            animations[currentAnimation].AddNewSequence(index, currentSequenceOffset);
            delta = 2;  // 2 bytes for new sequence's frame packet pointer
            animations[currentAnimation].UpdateOffsets(delta, currentSequenceOffset);
            // if adding to only one sequence, the sequence packet pointer will need to be set back to normal
            if (animations[currentAnimation].Sequences.Count == 2)
                animations[currentAnimation].SequencePacketPointer = currentSequenceOffset;
            animations[currentAnimation].Assemble();
            InitializeSequences();
            sequences.SelectedIndex = index;
            UpdateAnimationsFreeSpace();

            insertFrame_Click(null, null);  // all sequences must have at least one frame, so add one automatically
        }
        private void deleteSequence_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Sequences.Count == 1)
            {
                MessageBox.Show(
                    "Sprites must contain at least one sequence.", "CANNOT DELETE SEQUENCE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = currentSequence;
            delta = -2; // 2 bytes for deleted sequence
            // must update offsets before deleting frames
            animations[currentAnimation].UpdateOffsets(delta, currentSequenceOffset);
            delta = 0;
            foreach (Sequence.Frame sf in animations[currentAnimation].Frames)
                delta -= 2;  // 2 bytes for each frame in sequence
            delta -= 1; // 1 byte for the termination 0x00
            animations[currentAnimation].UpdateOffsets(delta, animations[currentAnimation].FramePacketPointer);
            animations[currentAnimation].RemoveCurrentSequence();
            animations[currentAnimation].Assemble();
            InitializeSequences();
            if (index >= sequences.Items.Count)
                sequences.SelectedIndex = index - 1;
            else
                sequences.SelectedIndex = index;
            UpdateAnimationsFreeSpace();

            // need to update the variables in Sprites.cs
            currentMoldOffset = animations[currentAnimation].MoldOffset;
            currentTileOffset = animations[currentAnimation].TileOffset;
        }
        private void insertFrame_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Frames.Count == 64)
            {
                MessageBox.Show(
                    "Sequences cannot contain more than 64 frames total.", "CANNOT INSERT NEW FRAME",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index;
            if (animations[currentAnimation].Frames.Count == 0)
            {
                index = currentFrame = 0;
                currentFrameOffset = animations[currentAnimation].FramePacketPointer;
                animations[currentAnimation].AddNewFrame(index, currentFrameOffset);
                delta = 3;  // 2 bytes for new frame, 1 for the termination 0x00
                animations[currentAnimation].UpdateOffsets(delta, currentFrameOffset);
                // after updating, set back to normal
                animations[currentAnimation].FramePacketPointer = currentFrameOffset;
                ((Sequence.Frame)animations[currentAnimation].Frames[0]).FrameOffset = currentFrameOffset;
            }
            else
            {
                index = currentFrame + 1;
                animations[currentAnimation].AddNewFrame(index, currentFrameOffset);
                delta = 2;  // 2 bytes for new frame
                animations[currentAnimation].UpdateOffsets(delta, currentFrameOffset);
                // if adding to only one frame, the frame packet pointer will need to be set back to normal
                if (animations[currentAnimation].Frames.Count == 2)
                    animations[currentAnimation].FramePacketPointer = currentFrameOffset;
            }
            animations[currentAnimation].Assemble();
            InitializeFrames();
            SetSequenceFrameImages();
            sequenceFrames.SelectedIndex = index;
            UpdateAnimationsFreeSpace();

            // need to update the variables in Sprites.cs
            currentMoldOffset = animations[currentAnimation].MoldOffset;
            currentTileOffset = animations[currentAnimation].TileOffset;
        }
        private void deleteFrame_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Frames.Count == 1)
            {
                MessageBox.Show(
                    "Sequences must contain at least one frame.", "CANNOT DELETE FRAME",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = currentFrame;
            animations[currentAnimation].RemoveCurrentFrame();
            delta = -2;
            animations[currentAnimation].UpdateOffsets(delta, currentFrameOffset);
            animations[currentAnimation].Assemble();
            InitializeFrames();
            SetSequenceFrameImages();
            if (index >= sequenceFrames.Items.Count)
                sequenceFrames.SelectedIndex = index - 1;
            else
                sequenceFrames.SelectedIndex = index;
            UpdateAnimationsFreeSpace();

            // need to update the variables in Sprites.cs
            currentMoldOffset = animations[currentAnimation].MoldOffset;
            currentTileOffset = animations[currentAnimation].TileOffset;
        }
        private void frameMoveUp_Click(object sender, EventArgs e)
        {
            if (sequenceFrames.SelectedIndex == 0)
                return;

            animations[currentAnimation].FrameOffset -= 2;
            animations[currentAnimation].CurrentFrame--;
            animations[currentAnimation].FrameOffset += 2;
            animations[currentAnimation].CurrentFrame++;

            int index = sequenceFrames.SelectedIndex - 1;
            animations[currentAnimation].MoveCurrentFrame(index);

            InitializeFrames();
            SetSequenceFrameImages();
            sequenceFrames.SelectedIndex = index;
        }
        private void frameMoveDown_Click(object sender, EventArgs e)
        {
            if (sequenceFrames.SelectedIndex >= sequenceFrames.Items.Count - 1)
                return;

            animations[currentAnimation].FrameOffset += 2;
            animations[currentAnimation].CurrentFrame++;
            animations[currentAnimation].FrameOffset -= 2;
            animations[currentAnimation].CurrentFrame--;

            int index = sequenceFrames.SelectedIndex + 1;
            animations[currentAnimation].MoveCurrentFrame(index - 1);

            InitializeFrames();
            SetSequenceFrameImages();
            sequenceFrames.SelectedIndex = index;
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlaybackSequence.CancelAsync();
            buttonPlay.Enabled = false;
            buttonBack.Enabled = false;
            buttonFoward.Enabled = false;
            PlaybackSequence.RunWorkerAsync();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (PlaybackSequence.IsBusy) PlaybackSequence.CancelAsync();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentFrameImage == 0) return;
            currentFrameImage--;

            sequenceFrames.SelectedIndex = currentFrameImage;
        }
        private void buttonFoward_Click(object sender, EventArgs e)
        {
            if (currentFrameImage == animations[currentAnimation].Frames.Count - 1)
                return;
            currentFrameImage++;

            sequenceFrames.SelectedIndex = currentFrameImage;
        }
        private void pictureBoxSequence_Paint(object sender, PaintEventArgs e)
        {
            if (currentFrame >= sequenceImages.Count)
                return;

            if (sequenceImage != null)
                e.Graphics.DrawImage(sequenceImage, 0, 0);
        }

        // Mold properties
        private void molds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            int temp = currentMold;
            animations[currentAnimation].CurrentMold = currentMold = molds.SelectedIndex;

            //if (animations[currentAnimation].Tiles.Count != 0 && animations[currentAnimation].TileOffset == 0xFFF)
            //{
            //    MessageBox.Show("Mold is invalid. Fix this later.", "INVALID MOLD", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    animations[currentAnimation].CurrentMold = currentMold = temp;
            //    return;
            //}

            RefreshMolds();
            InitializeTile();
            InitializeSubtile();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
        }
        private void moldFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (animations[currentAnimation].Gridplane == (moldFormat.SelectedIndex == 0)) // if changing
                return;

            delta = 0;

            animations[currentAnimation].Gridplane = moldFormat.SelectedIndex == 0;

            if (animations[currentAnimation].Tiles.Count != 0)
            {
                animations[currentAnimation].CurrentTile = 0;

                int orig = animations[currentAnimation].TileSize;
                if (moldFormat.SelectedIndex == 0)  // if changing from tilemap to gridplane
                {
                    // reset so that there's only one tile left
                    for (int i = animations[currentAnimation].Tiles.Count - 1; i > 0; i--)
                    {
                        animations[currentAnimation].CurrentTile = i;

                        delta -= (short)animations[currentAnimation].TileSize;
                        animations[currentAnimation].RemoveCurrentTile();
                    }
                    animations[currentAnimation].CurrentTile = 0;
                    animations[currentAnimation].TileSize = 10;
                    animations[currentAnimation].SubTiles = new ushort[16];
                    for (int i = 0; i < 16; i++)
                        animations[currentAnimation].SubTiles[i] = 1;
                    delta = -1;  // for removing the 00 at the end of the tile packet
                }
                else   // if changing from gridplane to tilemap
                {
                    animations[currentAnimation].CurrentTile = 0;
                    animations[currentAnimation].TileSize = 4;
                    animations[currentAnimation].XCoord = 0x80;
                    animations[currentAnimation].YCoord = 0x80;
                    animations[currentAnimation].Quadrants[0] = true;
                    animations[currentAnimation].SubTiles = new ushort[4];
                    for (int i = 0; i < 4; i++)
                        animations[currentAnimation].SubTiles[i] = 1;
                    delta = 1;  // for the 00 at the end of the tile packet
                }
                animations[currentAnimation].TileFormat = 0;

                delta += (short)(animations[currentAnimation].TileSize - orig);
                animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
                animations[currentAnimation].Assemble();
            }

            RefreshMolds();
            InitializeTile();
            InitializeSubtile();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();

            UpdateAnimationsFreeSpace();
        }
        private void insertMold_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Molds.Count == 32)
            {
                MessageBox.Show(
                    "Sprites cannot contain more than 32 molds total.", "CANNOT INSERT NEW MOLD",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = currentMold + 1;
            animations[currentAnimation].AddNewMold(index, currentMoldOffset);
            delta = 2;  // 2 bytes for new mold's tile packet pointer
            animations[currentAnimation].UpdateOffsets(delta, currentMoldOffset);
            // if adding to only one mold, the mold packet pointer will need to be set back to normal
            if (animations[currentAnimation].Molds.Count == 2)
                animations[currentAnimation].MoldPacketPointer = currentMoldOffset;
            animations[currentAnimation].Assemble();
            InitializeMolds();
            InitializeSequences();
            InitializeFrames();
            SetSequenceFrameImages();
            molds.SelectedIndex = index;
            UpdateAnimationsFreeSpace();

            insertTile_Click(null, null);
        }
        private void deleteMold_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Molds.Count == 1)
            {
                MessageBox.Show(
                    "Sprites must contain at least one mold.", "CANNOT DELETE MOLD",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentMold == 0)
            {
                MessageBox.Show(
                    "Deleting mold #0 is not allowed.\n\n" +
                    "This is because mold #0 is often used as a template for other molds.\n" +
                    "Removing it may adversely affect other molds that reference its tiles.", "CANNOT DELETE MOLD #0",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = currentMold;
            delta = -2; // 2 bytes for deleted mold
            // must update offsets before deleting tiles
            animations[currentAnimation].UpdateOffsets(delta, currentMoldOffset);
            delta = 0;
            if (animations[currentAnimation].TilePacketPointer != 0x7FFF)
            {
                delta -= (short)(animations[currentAnimation].MoldSize + 1);
                animations[currentAnimation].UpdateOffsets(delta, animations[currentAnimation].TilePacketPointer);
                animations[currentAnimation].RemoveCurrentMold();
            }
            animations[currentAnimation].Assemble();

            InitializeMolds();
            InitializeSequences();
            InitializeFrames();
            SetMoldImage();
            SetSequenceFrameImages();

            if (index >= molds.Items.Count)
                index--;
            molds.SelectedIndex = index;

            UpdateAnimationsFreeSpace();

            currentSequenceOffset = animations[currentAnimation].SequenceOffset;
            currentFrameOffset = animations[currentAnimation].FrameOffset;
        }

        private void pictureBoxMoldTileset_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxMoldTileset.Focus();

            if (animations[currentAnimation].Gridplane)
            {
                currentTile = 0;
                return;
            }
            if (((e.X / 16) + ((e.Y / 16) * 8)) >= animations[currentAnimation].Tiles.Count)
                return;
            currentTile = (e.X / 16) + ((e.Y / 16) * 8);
            animations[currentAnimation].CurrentTile = currentTile;
            currentTileOffset = animations[currentAnimation].TileOffset;

            RefreshTiles();
            InitializeSubtile();
            SetMoldImage();
            SetTileImage();
            SetSubtileImage();

            pictureBoxMoldTileset.Invalidate();
        }
        private void pictureBoxMoldTileset_MouseEnter(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Gridplane) return;
            labelTileOffset.Visible = true;
        }
        private void pictureBoxMoldTileset_MouseLeave(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Gridplane) return;
            labelTileOffset.Visible = false;
        }
        private void pictureBoxMoldTileset_MouseMove(object sender, MouseEventArgs e)
        {
            if (animations[currentAnimation].Gridplane) return;

            if (((e.X / 16) + ((e.Y / 16) * 8)) >= animations[currentAnimation].Tiles.Count)
            {
                labelTileOffset.Visible = false;
                return;
            }
            else
            {
                labelTileOffset.BringToFront();
                labelTileOffset.Visible = true;
            }
            Mold.Tile temp = (Mold.Tile)animations[currentAnimation].Tiles[((e.X / 16) + ((e.Y / 16) * 8))];

            labelTileOffset.Location = new Point(e.X + 430, e.Y + 330);
            labelTileOffset.Text = "offset 0x" + temp.TileOffset.ToString("X4");
        }
        private void pictureBoxMoldTileset_Paint(object sender, PaintEventArgs e)
        {
            if (animations[currentAnimation].Gridplane)
                return;

            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, 0, 0);

            overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(128, 64), new Size(16, 16), 1);

            Point p = new Point(currentTile % 8 * 16 + 1, currentTile / 8 * 16 + 1);
            Point t = new Point(currentTile % 8 * 16 + 16, currentTile / 8 * 16 + 16);
            if (p.X == 1) p.X--;
            if (p.Y == 1) p.Y--;
            overlay.DrawSelectionBox(e.Graphics, t, p, 1);
        }
        private void insertTile_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Tiles.Count == 32)
            {
                MessageBox.Show(
                    "Molds cannot contain more than 32 tiles total.", "CANNOT INSERT NEW TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int index;
            if (animations[currentAnimation].Tiles.Count == 0)
            {
                currentTileOffset = animations[currentAnimation].TilePacketPointer;
                index = currentTile = 0;
                animations[currentAnimation].AddNewTile(index, currentTileOffset);
                delta = 5;  // 4 bytes for empty 24x24 type tile, 1 byte for termination 0x00
                animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
                // after updating, set back to normal
                animations[currentAnimation].TilePacketPointer = currentTileOffset;
                ((Mold.Tile)animations[currentAnimation].Tiles[0]).TileOffset = currentTileOffset;
            }
            else
            {
                index = currentTile + 1;
                animations[currentAnimation].AddNewTile(index, currentTileOffset);
                delta = 4;
                animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
                // if adding to only one tile, the tile packet pointer will need to be set back to normal
                if (animations[currentAnimation].Tiles.Count == 2)
                    animations[currentAnimation].TilePacketPointer = currentTileOffset;
            }
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();
            // since cannot do same eventhandler as listbox, must set current tile this way
            animations[currentAnimation].CurrentTile = currentTile = index;
            RefreshTiles();
            InitializeSubtile();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();

            UpdateAnimationsFreeSpace();

            currentSequenceOffset = animations[currentAnimation].SequenceOffset;
            currentFrameOffset = animations[currentAnimation].FrameOffset;
        }
        private void deleteTile_Click(object sender, EventArgs e)
        {
            if (animations[currentAnimation].Tiles.Count == 1)
            {
                MessageBox.Show(
                    "Molds must contain at least one tile.", "CANNOT DELETE TILE",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int index = currentTile;
            animations[currentAnimation].RemoveCurrentTile();
            delta = (short)-animations[currentAnimation].TileSize;
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            if (index >= animations[currentAnimation].Tiles.Count)
                animations[currentAnimation].CurrentTile = currentTile = index - 1;
            else
                animations[currentAnimation].CurrentTile = currentTile = index;

            RefreshTiles();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();

            UpdateAnimationsFreeSpace();

            currentSequenceOffset = animations[currentAnimation].SequenceOffset;
            currentFrameOffset = animations[currentAnimation].FrameOffset;
        }

        private void pictureBoxMold_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / zoomM;
            int y = e.Y / zoomM;
            Point p;
            if ((moldZoomIn.Checked && e.Button == MouseButtons.Left) || (moldZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomM < 8)
                {
                    zoomM *= 2;

                    p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxMold.Width = 256 * zoomM;
                    pictureBoxMold.Height = 256 * zoomM;
                    panel52.AutoScrollPosition = p;
                    pictureBoxMold.Invalidate();
                    return;
                }
                return;
            }
            else if ((moldZoomOut.Checked && e.Button == MouseButtons.Left) || (moldZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomM > 1)
                {
                    zoomM /= 2;

                    p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxMold.Width = 256 * zoomM;
                    pictureBoxMold.Height = 256 * zoomM;
                    panel52.AutoScrollPosition = p;
                    pictureBoxMold.Invalidate();
                    return;
                }
                return;
            }

            if (animations[currentAnimation].Gridplane) return;
            if (animations[currentAnimation].Tiles.Count == 0) return;
            if (!mouseOverTile) return;

            mouseClickTile = true;

            if (animations[currentAnimation].TileFormat != 2)
            {
                diffX = (int)(x - moldTileXCoord.Value);
                diffY = (int)(y - moldTileYCoord.Value);
            }
            else
            {
                diffX = (byte)(x - (byte)moldTileXCoord.Value);
                diffY = (byte)(y - (byte)moldTileYCoord.Value);
            }
        }
        private void pictureBoxMold_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseClickTile)
            {
                animations[currentAnimation].Assemble();
                animations[currentAnimation].ResetCopies();

                UpdateAllTile8x8SubTiles();
                UpdateSequenceFrameImage();

                mouseClickTile = false;

                SetMoldImage();
            }
        }
        private void pictureBoxMold_MouseMove(object sender, MouseEventArgs e)
        {
            moldCoordLabel.Text = "(" + e.X / zoomM + ", " + e.Y / zoomM + ")  Pixel Coord";

            previous = mouse;
            mouse = e.Location;

            if (!waitForChange)
                waitForChange = Math.Abs(previous.X - mouse.X) > 2 || Math.Abs(previous.Y - mouse.Y) > 2;

            if (moldZoomIn.Checked || moldZoomOut.Checked)
                return;

            if (animations[currentAnimation].Gridplane) return;
            if (animations[currentAnimation].Tiles.Count == 0) return;

            int x = e.X / zoomM; int y = e.Y / zoomM;

            if (e.Button == MouseButtons.Left)
            {
                if (mouseOverTile)
                {
                    if (animations[currentAnimation].TileFormat != 2)
                    {
                        x -= diffX; y -= diffY;
                        if (x > 255) x = 255; if (x < 0) x = 0;
                        if (y > 255) y = 255; if (y < 0) y = 0;
                    }
                    else
                    {
                        x = (byte)(x - diffX); y = (byte)(y - diffY);
                    }
                    if (waitForChange)
                    {
                        waitForChange = false;
                        return;
                    }
                    if (moldTileXCoord.Value != x && moldTileYCoord.Value != y)
                        waitBothCoords = true;
                    moldTileXCoord.Value = x;
                    waitBothCoords = false;
                    moldTileYCoord.Value = y;

                    previous = new Point(x, y);
                }
            }
            else
            {
                if (animations[currentAnimation].TileFormat != 2 &&
                    x > animations[currentAnimation].XCoord &&
                    x < animations[currentAnimation].XCoord + 16 &&
                    y > animations[currentAnimation].YCoord &&
                    y < animations[currentAnimation].YCoord + 16)
                {
                    mouseOverTile = true; this.pictureBoxMold.Cursor = Cursors.Hand;
                }
                else if (animations[currentAnimation].TileFormat == 2 && CheckIfOverCopy(e))
                {
                    mouseOverTile = true; this.pictureBoxMold.Cursor = Cursors.Hand;
                }
                else
                {
                    mouseOverTile = false; this.pictureBoxMold.Cursor = Cursors.Arrow;
                }
            }
        }
        private void pictureBoxMold_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Rectangle rdst = new Rectangle(0, 0, 256 * zoomM, 256 * zoomM);

            if (moldImage != null)
                e.Graphics.DrawImage(moldImage, rdst, 0, 0, 256, 256, GraphicsUnit.Pixel);

            Size s = new Size(moldImage.Width * zoomM, moldImage.Height * zoomM);
            if (zoomM >= 4 && showMoldPixelGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoomM);

        }
        private void moldZoomIn_Click(object sender, EventArgs e)
        {
            moldZoomOut.Checked = false;
            if (moldZoomIn.Checked)
                pictureBoxMold.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxMold.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void moldZoomOut_Click(object sender, EventArgs e)
        {
            moldZoomIn.Checked = false;
            if (moldZoomOut.Checked)
                pictureBoxMold.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxMold.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void showMoldPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxMold.Invalidate();
        }
        private void panel52_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxMold.Invalidate();
        }
        private void pictureBoxMoldZoomed_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Bitmap image = new Bitmap(128, 20);
            Graphics g = Graphics.FromImage(image);
            Rectangle rsrc = new Rectangle(mouse.X - 64, mouse.Y - 10, 128, 20);
            g.DrawImage(moldImage, 0, 0, rsrc, GraphicsUnit.Pixel);
            g.Dispose();

            Rectangle rdst = new Rectangle(0, 0, 256, 40);
            e.Graphics.DrawImage(image, rdst, 0, 0, 128, 20, GraphicsUnit.Pixel);
        }
        private bool CheckIfOverCopy(MouseEventArgs e)
        {
            int x, y, lx, ly, hx, hy;
            lx = ly = 256;
            hx = hy = 0;
            foreach (Mold.Tile t in animations[currentAnimation].Copies)
            {
                x = (byte)(t.XCoord + (byte)moldTileXCoord.Value);
                y = (byte)(t.YCoord + (byte)moldTileYCoord.Value);
                if (x < lx) lx = x;
                if (x > hx) hx = x;
                if (y < ly) ly = y;
                if (y > hy) hy = y;
            }

            if (e.X / zoomM > lx && e.X / zoomM < hx + 16 && e.Y / zoomM > ly && e.Y / zoomM < hy + 16)
                return true;

            return false;
        }

        // Tile properties
        private void moldTileSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (animations[currentAnimation].TileFormat == moldTileSize.SelectedIndex)
                return;

            animations[currentAnimation].TileFormat = (byte)moldTileSize.SelectedIndex;

            int orig = animations[currentAnimation].TileSize;
            if (animations[currentAnimation].Gridplane)
            {
                switch (moldTileSize.SelectedIndex)
                {
                    case 0: animations[currentAnimation].TileSize = 10; break;
                    case 1:
                    case 2: animations[currentAnimation].TileSize = 13; break;
                    case 3: animations[currentAnimation].TileSize = 17; break;
                }
            }
            else
            {
                animations[currentAnimation].TileSize = 3;
                int mult = 1;   // for 8-bit or 16-bit subtiles
                switch (moldTileSize.SelectedIndex)
                {
                    case 0: mult = 1; goto default;
                    case 1: mult = 2; goto default;
                    case 2:
                        animations[currentAnimation].TileSize += 2;
                        animations[currentAnimation].CopyAmount = 1;
                        animations[currentAnimation].AddNewCopies(currentTileOffset);
                        animations[currentAnimation].CurrentCopy = 0;
                        currentCopy = 0;
                        break;
                    default:
                        animations[currentAnimation].TileSize += quadrantNW.Checked ? mult : 0;
                        animations[currentAnimation].TileSize += quadrantNE.Checked ? mult : 0;
                        animations[currentAnimation].TileSize += quadrantSW.Checked ? mult : 0;
                        animations[currentAnimation].TileSize += quadrantSE.Checked ? mult : 0;
                        break;
                }
            }
            delta = (short)(animations[currentAnimation].TileSize - orig);
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);

            RefreshTiles();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }
        private void quadrantNW_CheckedChanged(object sender, EventArgs e)
        {
            quadrantNW.ForeColor = quadrantNW.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingSprite) return;

            if (animations[currentAnimation].Gridplane)
                return;

            animations[currentAnimation].Quadrants[0] = quadrantNW.Checked;

            if (!quadrantNW.Checked) delta = -1;
            else delta = 1;
            animations[currentAnimation].TileSize += delta;
            if (animations[currentAnimation].SubTiles[0] == 0)
                animations[currentAnimation].SubTiles[0] = 1;
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);

            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }
        private void quadrantNE_CheckedChanged(object sender, EventArgs e)
        {
            quadrantNE.ForeColor = quadrantNE.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingSprite) return;

            animations[currentAnimation].Quadrants[1] = quadrantNE.Checked;

            if (!quadrantNE.Checked) delta = -1;
            else delta = 1;
            animations[currentAnimation].TileSize += delta;
            if (animations[currentAnimation].SubTiles[1] == 0)
                animations[currentAnimation].SubTiles[1] = 1;
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);

            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }
        private void quadrantSW_CheckedChanged(object sender, EventArgs e)
        {
            quadrantSW.ForeColor = quadrantSW.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingSprite) return;

            animations[currentAnimation].Quadrants[2] = quadrantSW.Checked;

            if (!quadrantSW.Checked) delta = -1;
            else delta = 1;
            animations[currentAnimation].TileSize += delta;
            if (animations[currentAnimation].SubTiles[2] == 0)
                animations[currentAnimation].SubTiles[2] = 1;
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);

            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }
        private void quadrantSE_CheckedChanged(object sender, EventArgs e)
        {
            quadrantSE.ForeColor = quadrantSE.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingSprite) return;

            animations[currentAnimation].Quadrants[3] = quadrantSE.Checked;

            if (!quadrantSE.Checked) delta = -1;
            else delta = 1;
            animations[currentAnimation].TileSize += delta;
            if (animations[currentAnimation].SubTiles[3] == 0)
                animations[currentAnimation].SubTiles[3] = 1;
            animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);

            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }
        private void moldTileProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (animations[currentAnimation].Gridplane)
            {
                animations[currentAnimation].Mirror = moldTileProperties.GetItemChecked(0);
                animations[currentAnimation].Invert = moldTileProperties.GetItemChecked(1);
                animations[currentAnimation].YPlusOne = moldTileProperties.GetItemChecked(2) ? (byte)1 : (byte)0;
                animations[currentAnimation].YMinusOne = moldTileProperties.GetItemChecked(3) ? (byte)1 : (byte)0;

                animations[currentAnimation].Assemble();
                animations[currentAnimation].ResetCopies();

                SetMoldImage();
                SetSequenceFrameImages();
            }
            else
            {
                animations[currentAnimation].Mirror = moldTileProperties.GetItemChecked(0);
                animations[currentAnimation].Invert = moldTileProperties.GetItemChecked(1);

                animations[currentAnimation].Assemble();
                animations[currentAnimation].ResetCopies();

                UpdateAllTile8x8SubTiles();

                SetMoldImage();
                SetTilesetImage();
                UpdateSequenceFrameImage();
            }
        }
        private void moldTileXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                animations[currentAnimation].XCoordChange = (byte)moldTileXCoord.Value;
            else
                animations[currentAnimation].XCoord = (byte)moldTileXCoord.Value;

            if (!mouseClickTile)
            {
                animations[currentAnimation].Assemble();
                animations[currentAnimation].ResetCopies();
            }

            if (waitBothCoords) return;

            UpdateAllTile8x8SubTiles();

            SetMoldImage();

            if (!mouseClickTile)
                UpdateSequenceFrameImage();
        }
        private void moldTileYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                animations[currentAnimation].YCoordChange = (byte)moldTileYCoord.Value;
            else
                animations[currentAnimation].YCoord = (byte)moldTileYCoord.Value;

            if (!mouseClickTile)
            {
                animations[currentAnimation].Assemble();
                animations[currentAnimation].ResetCopies();
            }

            if (waitBothCoords) return;

            UpdateAllTile8x8SubTiles();

            SetMoldImage();

            if (!mouseClickTile)
                UpdateSequenceFrameImage();
        }
        private void moldTileCopies_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            if (moldTileCopies.Value == currentCopy)
                return;

            animations[currentAnimation].CopyAmount = (byte)moldTileCopies.Value;

            if (moldTileCopies.Value > currentCopy)
            {
                animations[currentAnimation].AddNewCopies((int)moldTileCopiesOffset.Value);
                animations[currentAnimation].CurrentCopy = 0;
                currentCopy++;
            }
            else
            {
                animations[currentAnimation].RemoveCurrentCopy();
                if (animations[currentAnimation].Copies.Count > 0)
                    animations[currentAnimation].CurrentCopy = 0;
                currentCopy--;
            }
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            UpdateAllTile8x8SubTiles();

            SetMoldImage();
            UpdateSequenceFrameImage();
        }
        private void moldTileCopiesOffset_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            animations[currentAnimation].CopyPacketOffset = (ushort)moldTileCopiesOffset.Value;

            animations[currentAnimation].AddNewCopies((int)moldTileCopiesOffset.Value);

            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            try
            {
                UpdateAllTile8x8SubTiles();
                SetMoldImage();
                UpdateSequenceFrameImage();
            }
            catch
            {
                MessageBox.Show("This copy packet offset is bad. Change it to another value.", "WARNING: BAD COPY PACKET OFFSET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetMoldImage();
            }
        }
        private void moldSubtile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            bool one16bit = false;

            animations[currentAnimation].SubTiles[currentSubtile] = (ushort)moldSubtile.Value;
            if (animations[currentAnimation].Gridplane)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (animations[currentAnimation].SubTiles[i] >= 0x100)
                    {
                        one16bit = true; break;
                    }
                }
                if (animations[currentAnimation].Is16bit != one16bit)
                    delta = one16bit ? (short)2 : (short)-2;
                animations[currentAnimation].UpdateOffsets(delta, currentTileOffset);
            }
            animations[currentAnimation].Assemble();
            animations[currentAnimation].ResetCopies();

            UpdateAllTile8x8SubTiles();

            SetSubtileImage();
            SetTileImage();
            SetTilesetImage();
            SetMoldImage();
            UpdateSequenceFrameImage();

            UpdateAnimationsFreeSpace();
        }

        private void pictureBoxMoldTile_MouseClick(object sender, MouseEventArgs e)
        {
            if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                return;

            if (animations[currentAnimation].Gridplane)
            {
                switch (animations[currentAnimation].TileFormat)
                {
                    case 0: if (e.X < 24 && e.Y < 24) currentSubtile = (e.X / 8) + ((e.Y / 8) * 3); break;
                    case 1: if (e.X < 24) currentSubtile = (e.X / 8) + ((e.Y / 8) * 3); break;
                    case 2: if (e.Y < 24) currentSubtile = (e.X / 8) + ((e.Y / 8) * 4); break;
                    case 3: currentSubtile = (e.X / 8) + ((e.Y / 8) * 4); break;
                }
            }
            else
            {
                if (animations[currentAnimation].Subtiles[(e.X / 16) + ((e.Y / 16) * 2)] == null)
                    return;
                currentSubtile = (e.X / 16) + ((e.Y / 16) * 2);
            }
            RefreshSubtile();
            SetSubtileImage();
        }
        private void pictureBoxMoldTile_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (animations[currentAnimation].Tiles.Count == 0)
                    return;
                if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                    return;
            }
            catch
            {
                return;
            }
            if (tileImage != null)
                e.Graphics.DrawImage(tileImage, 0, 0);

            Size u = animations[currentAnimation].Gridplane ? new Size(8, 8) : new Size(16, 16);
            overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(32, 32), u, 1);
        }
        private void pictureBoxMoldSubtile_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (animations[currentAnimation].Tiles.Count == 0 || animations[currentAnimation].TileOffset == 0x7FFF)
                    return;
                if (!animations[currentAnimation].Gridplane && animations[currentAnimation].TileFormat == 2)
                    return;
                if (animations[currentAnimation].Subtiles[currentSubtile] == null)
                    return;
            }
            catch
            {
                return;
            }

            if (subtileImage != null)
                e.Graphics.DrawImage(subtileImage, 0, 0);
        }

        // other
        private void pictureBoxGraphics_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        private void pictureBoxGraphics_Click(object sender, EventArgs e)
        {
        }
        private void pictureBoxGraphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (graphicZoomIn.Checked || graphicZoomOut.Checked)
                return;

            setAsSubtileToolStripMenuItem_Click(null, null);
        }
        private void pictureBoxGraphics_MouseEnter(object sender, EventArgs e)
        {
        }
        private void pictureBoxGraphics_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverControl = pictureBoxGraphics.Name;
            mouseOverSubtile = (e.Y / (8 * zoomG)) * 16 + (e.X / (8 * zoomG)); mouseOverSubtile++;
            this.coordsLabel.Text = "subtile " + mouseOverSubtile.ToString("d4");

            // editing
            if (e.X > pictureBoxGraphics.Width || e.Y > pictureBoxGraphics.Height || e.X < 0 || e.Y < 0) return;

            byte row = (byte)(e.Y / zoomG % 8);
            byte col = (byte)(e.X / zoomG % 8);
            byte bit = (byte)(col ^ 7);
            int offset = (mouseOverSubtile - 1) * 0x20;
            offset += graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000;
            offset += row * 2;

            int r, g, b;
            int temp = 0;
            if (e.Button == MouseButtons.Left)
            {
                //if (currentPixel == (e.X / zoomG) + (e.Y / zoomG)) 
                //    return;
                if (subtileDraw.Checked)
                {
                    r = spritePalettes[currentPalette].PaletteColorRed[currentColor];
                    g = spritePalettes[currentPalette].PaletteColorGreen[currentColor];
                    b = spritePalettes[currentPalette].PaletteColorBlue[currentColor];
                    Rectangle n = new Rectangle(new Point(e.X - (e.X % zoomG), e.Y - (e.Y % zoomG)), new Size(zoomG, zoomG));
                    BitManager.SetBit(spriteGraphics, offset, bit, (currentColor & 1) == 1);
                    BitManager.SetBit(spriteGraphics, offset + 1, bit, (currentColor & 2) == 2);
                    BitManager.SetBit(spriteGraphics, offset + 16, bit, (currentColor & 4) == 4);
                    BitManager.SetBit(spriteGraphics, offset + 17, bit, (currentColor & 8) == 8);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileErase.Checked)
                {
                    r = spritePalettes[currentPalette].PaletteColorRed[0];
                    g = spritePalettes[currentPalette].PaletteColorGreen[0];
                    b = spritePalettes[currentPalette].PaletteColorBlue[0];
                    BitManager.SetBit(spriteGraphics, offset, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 1, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 16, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 17, bit, false);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileDropper.Checked)
                {
                    if (BitManager.GetBit(spriteGraphics, offset, bit)) temp |= 1;
                    if (BitManager.GetBit(spriteGraphics, offset + 1, bit)) temp |= 2;
                    if (BitManager.GetBit(spriteGraphics, offset + 16, bit)) temp |= 4;
                    if (BitManager.GetBit(spriteGraphics, offset + 17, bit)) temp |= 8;
                    mapPaletteColor.Value = temp;
                }
                currentPixel = (e.X / zoomG) + (e.Y / zoomG);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (currentPixel == (e.X / zoomG) + (e.Y / zoomG)) return;
                if (subtileDraw.Checked)
                {
                    r = spritePalettes[currentPalette].PaletteColorRed[0];
                    g = spritePalettes[currentPalette].PaletteColorGreen[0];
                    b = spritePalettes[currentPalette].PaletteColorBlue[0];
                    BitManager.SetBit(spriteGraphics, offset, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 1, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 16, bit, false);
                    BitManager.SetBit(spriteGraphics, offset + 17, bit, false);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphics.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileDropper.Checked)
                {
                    if (BitManager.GetBit(spriteGraphics, offset, bit)) temp |= 1;
                    if (BitManager.GetBit(spriteGraphics, offset + 1, bit)) temp |= 2;
                    if (BitManager.GetBit(spriteGraphics, offset + 16, bit)) temp |= 4;
                    if (BitManager.GetBit(spriteGraphics, offset + 17, bit)) temp |= 8;
                    mapPaletteColor.Value = temp;
                }
                currentPixel = (e.X / zoomG) + (e.Y / zoomG);
            }
        }
        private void pictureBoxGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            panel37.Enabled = false;
            pictureBoxGraphics.Focus();
            panel37.Enabled = true;

            Point p;
            if ((graphicZoomIn.Checked && e.Button == MouseButtons.Left) || (graphicZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomG < 8)
                {
                    zoomG *= 2;

                    p = new Point(Math.Abs(pictureBoxGraphics.Left), Math.Abs(pictureBoxGraphics.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxGraphics.Width = 128 * zoomG;
                    pictureBoxGraphics.Height = 256 * zoomG;
                    panel37.AutoScrollPosition = p;
                    pictureBoxGraphics.Invalidate();
                    return;
                }
                return;
            }
            else if ((graphicZoomOut.Checked && e.Button == MouseButtons.Left) || (graphicZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomG > 1)
                {
                    zoomG /= 2;

                    p = new Point(Math.Abs(pictureBoxGraphics.Left), Math.Abs(pictureBoxGraphics.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxGraphics.Width = 128 * zoomG;
                    pictureBoxGraphics.Height = 256 * zoomG;
                    panel37.AutoScrollPosition = p;
                    pictureBoxGraphics.Invalidate();
                    return;
                }
                return;
            }

            pictureBoxGraphics_MouseMove(sender, e);
        }
        private void pictureBoxGraphics_MouseUp(object sender, MouseEventArgs e)
        {
            if (!subtileDraw.Checked && !subtileErase.Checked) return;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                UpdateAllTile8x8SubTiles();
                SetGraphicImage();
                SetMoldImage();
                SetTileImage();
                SetTilesetImage();
                animations[currentAnimation].Set8x8Tiles(
                    BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                    spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                    animations[currentAnimation].Gridplane);
                SetSubtileImage();
                SetSequenceFrameImages();
            }
        }
        private void pictureBoxGraphics_MouseLeave(object sender, EventArgs e)
        {
        }
        private void pictureBoxGraphics_Paint(object sender, PaintEventArgs e)
        {
            if (graphicImage == null) return;
            Rectangle rsrc = new Rectangle(0, 0, graphicImage.Width, graphicImage.Height);
            Rectangle rdst = new Rectangle(0, 0, graphicImage.Width * zoomG, graphicImage.Height * zoomG);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(graphicImage, rdst, rsrc, GraphicsUnit.Pixel);

            Size s = new Size(graphicImage.Width * zoomG, graphicImage.Height * zoomG);
            if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoomG);
            if (graphicShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, s, new Size(8, 8), zoomG);
        }
        private void panel37_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxGraphics.Invalidate();
        }
        private void graphicShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphics.Invalidate();
        }
        private void graphicShowPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphics.Invalidate();
        }
        private void graphicOFfset_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSprite) return;

            graphicPalettes[currentGraphicPalette].GraphicOffset = (int)graphicOFfset.Value;
            UpdateAllTile8x8SubTiles();
            SetGraphicImage();
            SetMoldImage();
            SetTilesetImage();
            SetTileImage();
            SetSubtileImage();
            SetSequenceFrameImages();
        }

        private void graphicZoomIn_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            graphicZoomOut.Checked = false;
            if (graphicZoomIn.Checked)
                pictureBoxGraphics.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxGraphics.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomIn.Checked)
                pictureBoxGraphics.ContextMenuStrip = null;
            else
                pictureBoxGraphics.ContextMenuStrip = contextMenuStripGR;
        }
        private void graphicZoomOut_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            graphicZoomIn.Checked = false;
            if (graphicZoomOut.Checked)
                pictureBoxGraphics.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxGraphics.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomOut.Checked)
                pictureBoxGraphics.ContextMenuStrip = null;
            else
                pictureBoxGraphics.ContextMenuStrip = contextMenuStripGR;
        }
        private void subtileDraw_Click(object sender, EventArgs e)
        {
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileDraw.Checked)
                pictureBoxGraphics.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDraw.cur");
        }
        private void subtileErase_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileDropper.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileErase.Checked)
                pictureBoxGraphics.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorErase.cur");
        }
        private void subtileDropper_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileDropper.Checked)
                pictureBoxGraphics.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphics.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (contextMenuStripSI.SourceControl == pictureBoxSequence)
            {
                saveFileDialog.FileName = "sprite." + currentSprite.ToString("d4") + "." + currentSequence.ToString("d2") + "." + currentFrame.ToString("d3") + ".png";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    sequenceImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (contextMenuStripSI.SourceControl == pictureBoxE_Sequence)
            {
                saveFileDialog.FileName = "effect." + currentEffect.ToString("d4") + "." + e_currentFrame.ToString("d3") + ".png";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    e_sequenceImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void searchSpriteNames_Click(object sender, EventArgs e)
        {
            panelSearchSpriteNames.Visible = !panelSearchSpriteNames.Visible;
            if (panelSearchSpriteNames.Visible)
            {
                panelSearchSpriteNames.BringToFront();
                nameTextBox.Focus();
            }
        }
        private void listBoxSpriteNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                spriteName.SelectedItem = listBoxSpriteNames.SelectedItem;
            }
            catch
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSpriteNameSearch();
        }
        private void listBoxSpriteNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }

        #endregion
    }
}
