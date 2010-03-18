using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private Battlefield[] battlefields;
        private BattlefieldTileSet bts;
        private PaletteSet paletteSetBF;

        private int currentBFColor;

        private int[]
            battlefieldPixels,
            battlefieldPaletteSetPixels;
        private Bitmap
            battlefieldImage,
            battlefieldPaletteSetImage;

        private Stack<int[]> colorRedsBF = new Stack<int[]>();
        private Stack<int[]> colorGreensBF = new Stack<int[]>();
        private Stack<int[]> colorBluesBF = new Stack<int[]>();
        private Stack<int[]> redoColorRedsBF = new Stack<int[]>();
        private Stack<int[]> redoColorGreensBF = new Stack<int[]>();
        private Stack<int[]> redoColorBluesBF = new Stack<int[]>();

        #endregion

        #region Methods

        public void RefreshBattlefield()
        {
            updatingProperties = true;
            updatingLevel = true;

            currentBFColor = (int)bfPaletteColorNum.Value;

            int bf = (int)battlefieldNum.Value;
            paletteSetBF = paletteSets[battlefields[bf].PaletteSet];

            bts = new BattlefieldTileSet(battlefields[bf], paletteSetBF, model);

            battlefieldPixels = bts.GetTilesetPixelArray(false);//bts.TileSetLayer);            
            battlefieldImage = new Bitmap(DrawImageFromIntArr(battlefieldPixels, 512, 512));

            // Update fields
            battlefieldName.SelectedIndex = bf;
            battlefieldGFXSet1Name.SelectedIndex = battlefields[bf].GraphicSetA;
            battlefieldGFXSet1Num.Value = battlefields[bf].GraphicSetA;
            battlefieldGFXSet2Name.SelectedIndex = battlefields[bf].GraphicSetB;
            battlefieldGFXSet2Num.Value = battlefields[bf].GraphicSetB;
            battlefieldGFXSet3Name.SelectedIndex = battlefields[bf].GraphicSetC;
            battlefieldGFXSet3Num.Value = battlefields[bf].GraphicSetC;
            battlefieldGFXSet4Name.SelectedIndex = battlefields[bf].GraphicSetD;
            battlefieldGFXSet4Num.Value = battlefields[bf].GraphicSetD;
            battlefieldGFXSet5Name.SelectedIndex = battlefields[bf].GraphicSetE;
            battlefieldGFXSet5Num.Value = battlefields[bf].GraphicSetE;
            battlefieldTilesetName.SelectedIndex = battlefields[bf].TileSet;
            battlefieldTilesetNum.Value = battlefields[bf].TileSet;
            battlefieldPaletteSetName.SelectedIndex = battlefields[bf].PaletteSet;
            battlefieldPaletteSetNum.Value = battlefields[bf].PaletteSet;

            this.bfPaletteRedNum.Value = paletteSetBF.PaletteColorRedBF[currentBFColor];
            this.bfPaletteGreenNum.Value = paletteSetBF.PaletteColorGreenBF[currentBFColor];
            this.bfPaletteBlueNum.Value = paletteSetBF.PaletteColorBlueBF[currentBFColor];

            this.bfPaletteRedBar.Value = paletteSetBF.PaletteColorRedBF[currentBFColor];
            this.bfPaletteGreenBar.Value = paletteSetBF.PaletteColorGreenBF[currentBFColor];
            this.bfPaletteBlueBar.Value = paletteSetBF.PaletteColorBlueBF[currentBFColor];

            battlefieldPaletteSetPixels = paletteSetBF.GetBFPaletteSetPixels();
            battlefieldPaletteSetImage = new Bitmap(DrawImageFromIntArr(battlefieldPaletteSetPixels, 256, 112));

            this.pictureBoxColorBF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(bfPaletteRedNum.Value)))), ((int)(((byte)(bfPaletteGreenNum.Value)))), ((int)(((byte)(bfPaletteBlueNum.Value)))));

            updatingLevel = false;
            updatingProperties = false;
        }
        private void UpdateCurrentBFColor()
        {
            currentBFColor = (int)bfPaletteColorNum.Value;

            this.bfPaletteRedNum.Value = paletteSetBF.PaletteColorRedBF[currentBFColor];
            this.bfPaletteGreenNum.Value = paletteSetBF.PaletteColorGreenBF[currentBFColor];
            this.bfPaletteBlueNum.Value = paletteSetBF.PaletteColorBlueBF[currentBFColor];

            this.bfPaletteRedBar.Value = paletteSetBF.PaletteColorRedBF[currentBFColor];
            this.bfPaletteGreenBar.Value = paletteSetBF.PaletteColorGreenBF[currentBFColor];
            this.bfPaletteBlueBar.Value = paletteSetBF.PaletteColorBlueBF[currentBFColor];

            this.pictureBoxColorBF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(bfPaletteRedNum.Value)))), ((int)(((byte)(bfPaletteGreenNum.Value)))), ((int)(((byte)(bfPaletteBlueNum.Value)))));
        }

        #endregion

        #region Event Handlers

        private void battlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshBattlefield();
            pictureBoxBattlefield.Invalidate();
            pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
            bfPalettePictureBox.Invalidate();
            UpdateTileEditor();
        }
        private void battlefieldName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            battlefieldNum.Value = battlefieldName.SelectedIndex;
        }
        private void battlefieldGFXSet1Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet1Num.Value == battlefieldGFXSet1Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetA = (byte)battlefieldGFXSet1Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet1Name.SelectedIndex = (int)battlefieldGFXSet1Num.Value;
                }
        }
        private void battlefieldGFXSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet1Num.Value == battlefieldGFXSet1Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetA = (byte)battlefieldGFXSet1Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet1Num.Value = battlefieldGFXSet1Name.SelectedIndex;
                }
        }
        private void battlefieldGFXSet2Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet2Num.Value == battlefieldGFXSet2Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetB = (byte)battlefieldGFXSet2Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet2Name.SelectedIndex = (int)battlefieldGFXSet2Num.Value;
                }
        }
        private void battlefieldGFXSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet2Num.Value == battlefieldGFXSet2Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetB = (byte)battlefieldGFXSet2Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet2Num.Value = battlefieldGFXSet2Name.SelectedIndex;
                }
        }
        private void battlefieldGFXSet3Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet3Num.Value == battlefieldGFXSet3Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetC = (byte)battlefieldGFXSet3Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet3Name.SelectedIndex = (int)battlefieldGFXSet3Num.Value;
                }
        }
        private void battlefieldGFXSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet3Num.Value == battlefieldGFXSet3Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetC = (byte)battlefieldGFXSet3Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet3Num.Value = battlefieldGFXSet3Name.SelectedIndex;
                }
        }
        private void battlefieldGFXSet4Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet4Num.Value == battlefieldGFXSet4Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetD = (byte)battlefieldGFXSet4Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet4Name.SelectedIndex = (int)battlefieldGFXSet4Num.Value;
                }
        }
        private void battlefieldGFXSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet4Num.Value == battlefieldGFXSet4Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetD = (byte)battlefieldGFXSet4Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet4Num.Value = battlefieldGFXSet4Name.SelectedIndex;
                }
        }
        private void battlefieldGFXSet5Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet5Num.Value == battlefieldGFXSet5Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetE = (byte)battlefieldGFXSet5Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet5Name.SelectedIndex = (int)battlefieldGFXSet5Num.Value;
                }
        }
        private void battlefieldGFXSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldGFXSet5Num.Value == battlefieldGFXSet5Name.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].GraphicSetE = (byte)battlefieldGFXSet5Num.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldGFXSet5Num.Value = battlefieldGFXSet5Name.SelectedIndex;
                }
        }
        private void battlefieldTilesetNum_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldTilesetNum.Value == battlefieldTilesetName.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].TileSet = (byte)battlefieldTilesetNum.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldTilesetName.SelectedIndex = (int)battlefieldTilesetNum.Value;
                }
        }
        private void battlefieldTilesetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldTilesetNum.Value == battlefieldTilesetName.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].TileSet = (byte)battlefieldTilesetNum.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldTilesetNum.Value = battlefieldTilesetName.SelectedIndex;
                }
        }
        private void battlefieldPaletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            colorRedsBF.Clear();
            colorGreensBF.Clear();
            colorBluesBF.Clear();
            redoColorRedsBF.Clear();
            redoColorGreensBF.Clear();
            redoColorBluesBF.Clear();

            if (!updatingProperties)
                if ((int)battlefieldPaletteSetNum.Value == battlefieldPaletteSetName.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].PaletteSet = (byte)battlefieldPaletteSetNum.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldPaletteSetName.SelectedIndex = (int)battlefieldPaletteSetNum.Value;
                }
        }
        private void battlefieldPaletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if ((int)battlefieldPaletteSetNum.Value == battlefieldPaletteSetName.SelectedIndex)
                {
                    battlefields[(int)battlefieldNum.Value].PaletteSet = (byte)battlefieldPaletteSetNum.Value;
                    if (!updatingLevel)
                        battlefieldNum_ValueChanged(null, null);
                }
                else
                {
                    battlefieldPaletteSetNum.Value = battlefieldPaletteSetName.SelectedIndex;
                }
        }

        private void bfPaletteColorNum_ValueChanged(object sender, EventArgs e)
        {
            updatingProperties = true;
            UpdateCurrentBFColor();
            bfPalettePictureBox.Invalidate();
            updatingProperties = false;
        }
        private void bfPaletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteRedNum.Value -= bfPaletteRedNum.Value % 8;

            if (bfPaletteRedBar.Value == (int)bfPaletteRedNum.Value)
            {
                paletteSetBF.PaletteColorRedBF[currentBFColor] = (byte)this.bfPaletteRedNum.Value;

                if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                    paletteSetBF.PaletteColorRedBF[currentBFColor + 1] = paletteSetBF.PaletteColorRedBF[currentBFColor];
                if (currentBFColor != 0 && currentBFColor % 16 == 0)
                    paletteSetBF.PaletteColorRedBF[currentBFColor - 1] = paletteSetBF.PaletteColorRedBF[currentBFColor];

                if (!updatingLevel)
                {
                    fullUpdate = true;
                    RefreshBattlefield();
                    pictureBoxBattlefield.Invalidate();
                    pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                    bfPalettePictureBox.Invalidate();
                }
            }
            else
            {
                bfPaletteRedBar.Value = (int)bfPaletteRedNum.Value;
                bfPaletteRedBar_Scroll(null, null);
            }
        }
        private void bfPaletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteGreenNum.Value -= bfPaletteGreenNum.Value % 8;

            if (bfPaletteGreenBar.Value == (int)bfPaletteGreenNum.Value)
            {
                paletteSetBF.PaletteColorGreenBF[currentBFColor] = (byte)this.bfPaletteGreenNum.Value;

                if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                    paletteSetBF.PaletteColorGreenBF[currentBFColor + 1] = paletteSetBF.PaletteColorGreenBF[currentBFColor];
                if (currentBFColor != 0 && currentBFColor % 16 == 0)
                    paletteSetBF.PaletteColorGreenBF[currentBFColor - 1] = paletteSetBF.PaletteColorGreenBF[currentBFColor];

                if (!updatingLevel)
                {
                    fullUpdate = true;
                    RefreshBattlefield();
                    pictureBoxBattlefield.Invalidate();
                    pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                    bfPalettePictureBox.Invalidate();
                }
            }
            else
            {
                bfPaletteGreenBar.Value = (int)bfPaletteGreenNum.Value;
                bfPaletteGreenBar_Scroll(null, null);
            }
        }
        private void bfPaletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteBlueNum.Value -= bfPaletteBlueNum.Value % 8;

            if (bfPaletteBlueBar.Value == (int)bfPaletteBlueNum.Value)
            {
                paletteSetBF.PaletteColorBlueBF[currentBFColor] = (byte)this.bfPaletteBlueNum.Value;

                if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                    paletteSetBF.PaletteColorBlueBF[currentBFColor + 1] = paletteSetBF.PaletteColorBlueBF[currentBFColor];
                if (currentBFColor != 0 && currentBFColor % 16 == 0)
                    paletteSetBF.PaletteColorBlueBF[currentBFColor - 1] = paletteSetBF.PaletteColorBlueBF[currentBFColor];

                if (!updatingLevel)
                {
                    fullUpdate = true;
                    RefreshBattlefield();
                    pictureBoxBattlefield.Invalidate();
                    pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                    bfPalettePictureBox.Invalidate();
                }
            }
            else
            {
                bfPaletteBlueBar.Value = (int)bfPaletteBlueNum.Value;
                bfPaletteBlueBar_Scroll(null, null);
            }
        }
        private void bfPaletteRedBar_Scroll(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteRedBar.Value -= bfPaletteRedBar.Value % 8;

            if (bfPaletteRedNum.Value == bfPaletteRedBar.Value)
                {
                    paletteSetBF.PaletteColorRedBF[currentBFColor] = (byte)this.bfPaletteRedBar.Value;

                    if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                        paletteSetBF.PaletteColorRedBF[currentBFColor + 1] = paletteSetBF.PaletteColorRedBF[currentBFColor];
                    if (currentBFColor != 0 && currentBFColor % 16 == 0)
                        paletteSetBF.PaletteColorRedBF[currentBFColor - 1] = paletteSetBF.PaletteColorRedBF[currentBFColor];

                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        RefreshBattlefield();
                        pictureBoxBattlefield.Invalidate();
                        pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                        bfPalettePictureBox.Invalidate();
                    }
                }
                else
                {
                    bfPaletteRedNum.Value = bfPaletteRedBar.Value;
                }
        }
        private void bfPaletteGreenBar_Scroll(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteGreenBar.Value -= bfPaletteGreenBar.Value % 8;

            if (bfPaletteGreenNum.Value == bfPaletteGreenBar.Value)
                {
                    paletteSetBF.PaletteColorGreenBF[currentBFColor] = (byte)this.bfPaletteGreenBar.Value;

                    if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                        paletteSetBF.PaletteColorGreenBF[currentBFColor + 1] = paletteSetBF.PaletteColorGreenBF[currentBFColor];
                    if (currentBFColor != 0 && currentBFColor % 16 == 0)
                        paletteSetBF.PaletteColorGreenBF[currentBFColor - 1] = paletteSetBF.PaletteColorGreenBF[currentBFColor];

                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        RefreshBattlefield();
                        pictureBoxBattlefield.Invalidate();
                        pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                        bfPalettePictureBox.Invalidate();
                    }
                }
                else
                {
                    bfPaletteGreenNum.Value = bfPaletteGreenBar.Value;
                }
        }
        private void bfPaletteBlueBar_Scroll(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            bfPaletteBlueBar.Value -= bfPaletteBlueBar.Value % 8;

            if (bfPaletteBlueNum.Value == bfPaletteBlueBar.Value)
                {
                    paletteSetBF.PaletteColorBlueBF[currentBFColor] = (byte)this.bfPaletteBlueBar.Value;

                    if (currentBFColor < 111 && (currentBFColor & 15) == 15)
                        paletteSetBF.PaletteColorBlueBF[currentBFColor + 1] = paletteSetBF.PaletteColorBlueBF[currentBFColor];
                    if (currentBFColor != 0 && currentBFColor % 16 == 0)
                        paletteSetBF.PaletteColorBlueBF[currentBFColor - 1] = paletteSetBF.PaletteColorBlueBF[currentBFColor];

                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        RefreshBattlefield();
                        pictureBoxBattlefield.Invalidate();
                        pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                        bfPalettePictureBox.Invalidate();
                    }
                }
                else
                {
                    bfPaletteBlueNum.Value = bfPaletteBlueBar.Value;
                }
        }

        private void bfPalettePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            currentBFColor = (e.X / 16) + ((e.Y / 16) * 16);
            bfPaletteColorNum.Value = currentBFColor;
        }
        private void bfPalettePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (battlefieldPaletteSetImage == null)
                return;

            e.Graphics.DrawImage(new Bitmap(battlefieldPaletteSetImage), 0, 0);

            Point p = new Point(currentBFColor % 16 * 16, currentBFColor / 16 * 16);
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15), p, 1);
        }

        #endregion
    }
}
