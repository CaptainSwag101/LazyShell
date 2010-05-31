using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingFormations = false;
        private bool updatingFormationPacks = false;

        private Bitmap formationImage;
        private Bitmap formationBGImage;

        private void InitializeFormations()
        {
            this.formationNameList.SelectedIndex = 0;

            if (model.TileSetsBF[0] == null)
                DecompressBattlefields();

            RefreshFormationTab();

            battlefieldName.SelectedIndex = 7;
        }
        private void InitializeFormationStrings()
        {
            updatingFormations = true;

            this.formationNameList.Items.Clear();
            this.formationNameList.Items.AddRange(statsModel.Formations);
            this.formationNameList.SelectedIndex = (int)formationNum.Value;

            this.battlefieldName.SelectedIndex = 0;

            updatingFormations = false;
        }
        private void RefreshFormationTab()
        {
            RefreshFormations();
            RefreshFormationPacks();
        }
        private void RefreshFormations()
        {
            if (!updatingFormations)
            {
                updatingFormations = true;
                this.formationNameList.SelectedIndex = (int)this.formationNum.Value;
                this.formationByte1.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[0];
                this.formationByte2.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[1];
                this.formationByte3.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[2];
                this.formationByte4.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[3];
                this.formationByte5.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[4];
                this.formationByte6.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[5];
                this.formationByte7.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[6];
                this.formationByte8.Value = statsModel.Formations[(int)this.formationNum.Value].FormationMonster[7];
                this.formationName1.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[0]);
                this.formationName2.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[1]);
                this.formationName3.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[2]);
                this.formationName4.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[3]);
                this.formationName5.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[4]);
                this.formationName6.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[5]);
                this.formationName7.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[6]);
                this.formationName8.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)this.formationNum.Value].FormationMonster[7]);
                this.formationCoordX1.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[0];
                this.formationCoordX2.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[1];
                this.formationCoordX3.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[2];
                this.formationCoordX4.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[3];
                this.formationCoordX5.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[4];
                this.formationCoordX6.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[5];
                this.formationCoordX7.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[6];
                this.formationCoordX8.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[7];
                this.formationCoordY1.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[0];
                this.formationCoordY2.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[1];
                this.formationCoordY3.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[2];
                this.formationCoordY4.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[3];
                this.formationCoordY5.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[4];
                this.formationCoordY6.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[5];
                this.formationCoordY7.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[6];
                this.formationCoordY8.Value = statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[7];
                this.formationMusic.SelectedIndex = statsModel.Formations[(int)this.formationNum.Value].FormationMusic;
                this.formationBattleEvent.Value = statsModel.Formations[(int)this.formationNum.Value].FormationBattleEvent;
                this.formationUnknown.Value = statsModel.Formations[(int)this.formationNum.Value].FormationUnknown;
                this.formationCantRun.Checked = statsModel.Formations[(int)this.formationNum.Value].FormationCantRun;
                this.checkedListBox1.SetItemChecked(0, statsModel.Formations[(int)this.formationNum.Value].FormationUse[0]);
                this.checkedListBox1.SetItemChecked(1, statsModel.Formations[(int)this.formationNum.Value].FormationUse[1]);
                this.checkedListBox1.SetItemChecked(2, statsModel.Formations[(int)this.formationNum.Value].FormationUse[2]);
                this.checkedListBox1.SetItemChecked(3, statsModel.Formations[(int)this.formationNum.Value].FormationUse[3]);
                this.checkedListBox1.SetItemChecked(4, statsModel.Formations[(int)this.formationNum.Value].FormationUse[4]);
                this.checkedListBox1.SetItemChecked(5, statsModel.Formations[(int)this.formationNum.Value].FormationUse[5]);
                this.checkedListBox1.SetItemChecked(6, statsModel.Formations[(int)this.formationNum.Value].FormationUse[6]);
                this.checkedListBox1.SetItemChecked(7, statsModel.Formations[(int)this.formationNum.Value].FormationUse[7]);
                this.checkedListBox2.SetItemChecked(0, statsModel.Formations[(int)this.formationNum.Value].FormationHide[0]);
                this.checkedListBox2.SetItemChecked(1, statsModel.Formations[(int)this.formationNum.Value].FormationHide[1]);
                this.checkedListBox2.SetItemChecked(2, statsModel.Formations[(int)this.formationNum.Value].FormationHide[2]);
                this.checkedListBox2.SetItemChecked(3, statsModel.Formations[(int)this.formationNum.Value].FormationHide[3]);
                this.checkedListBox2.SetItemChecked(4, statsModel.Formations[(int)this.formationNum.Value].FormationHide[4]);
                this.checkedListBox2.SetItemChecked(5, statsModel.Formations[(int)this.formationNum.Value].FormationHide[5]);
                this.checkedListBox2.SetItemChecked(6, statsModel.Formations[(int)this.formationNum.Value].FormationHide[6]);
                this.checkedListBox2.SetItemChecked(7, statsModel.Formations[(int)this.formationNum.Value].FormationHide[7]);

                this.musicTrack.Enabled = formationMusic.SelectedIndex != 8;
                if (formationMusic.SelectedIndex != 8)
                    this.musicTrack.SelectedIndex = statsModel.FormationMusics[formationMusic.SelectedIndex];
                else
                    this.musicTrack.SelectedIndex = 0;

                formationImage = new Bitmap(statsModel.Formations[(int)this.formationNum.Value].FormationImage);
                pictureBoxFormation.Invalidate();

                updatingFormations = false;
            }
        }
        private void RefreshFormationPacks()
        {
            if (!updatingFormationPacks)
            {
                updatingFormationPacks = true;

                this.formationSet.SelectedIndex = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackSet;
                this.packFormation1.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
                this.packFormation2.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
                this.packFormation3.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
                this.packFormation1.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
                this.packFormation2.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
                this.packFormation3.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
                if (formationSet.SelectedIndex == 0)
                {
                    this.packFormation1.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[0];
                    this.packFormation2.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[1];
                    this.packFormation3.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[2];
                }
                else
                {
                    this.packFormation1.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[0] + 256;
                    this.packFormation2.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[1] + 256;
                    this.packFormation3.Value = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[2] + 256;
                }

                RefreshFormationPackStrings();

                updatingFormationPacks = false;
            }

        }
        private void RefreshFormationPackStrings()
        {
            int a = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[0];
            int b = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[1];
            int c = statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[2];
            if (formationSet.SelectedIndex == 1)
            {
                a += 256;
                b += 256;
                c += 256;
            }
            this.richTextBox2.Text = statsModel.Formations[a].FormationListSet;
            this.richTextBox3.Text = statsModel.Formations[b].FormationListSet;
            this.richTextBox4.Text = statsModel.Formations[c].FormationListSet;
        }
        private void RefreshFormationBattlefield()
        {
            PaletteSet paletteSet = statsModel.PaletteSets[statsModel.Battlefields[battlefieldName.SelectedIndex].PaletteSet];
            BattlefieldTileSet bts = new BattlefieldTileSet(statsModel.Battlefields[battlefieldName.SelectedIndex], paletteSet, model);

            formationBGImage = new Bitmap(DrawImageFromIntArr(bts.GetTilesetPixelArray(true), 512, 512));

            pictureBoxFormation.Invalidate();
        }
        private void DecompressBattlefields()
        {
            ProgressBar pBar = new ProgressBar(this.model, model.Data, "DECOMPRESSING BATTLEFIELD DATA...", 336);
            pBar.Show();

            int bank = 0;
            int pointer = 0;
            int offset = 0;
            int temp = 0;
            string labelText;

            temp = BitManager.GetShort(model.Data, 0x0A0000);
            for (int i = 0, j = 0; i < 272; i++)
            {
                j = i * 2;
                for (int k = 0x0A0000; k < 0x150000; k += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, k);
                    if (j >= temp) j -= temp;
                    else { bank = k; break; }
                }

                pointer = BitManager.GetShort(model.Data, bank + j);
                offset = bank + pointer + 1;
                if (model.GraphicSets[i] == null)
                    model.GraphicSets[i] = model.Decompress(offset, 0x2000);

                labelText = "DECOMPRESSING GRAPHIC SET 0x" + i.ToString("d3");
                pBar.PerformStep(labelText);
            }

            for (int i = 0; i < 64; i++)
            {
                bank = 0x150000;

                pointer = BitManager.GetShort(model.Data, bank + (i * 2));
                offset = bank + pointer + 1;
                if (model.TileSetsBF[i] == null)
                    model.TileSetsBF[i] = model.Decompress(offset, 0x2000);

                labelText = "DECOMPRESSING BATTLEFIELD 0x" + i.ToString("d3");
                pBar.PerformStep(labelText);
            }
            pBar.Close();
        }
        private void SaveFormationNotes()
        {
        }

        #region Formations Event Handlers
        private void formationNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationNum.Value = this.formationNameList.SelectedIndex;
        }
        private void formationNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            RefreshFormationTab();
        }
        private void formationByte1_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[0] = (byte)this.formationByte1.Value;
            this.formationName1.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte1.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte2_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[1] = (byte)this.formationByte2.Value;
            this.formationName2.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte2.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte3_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[2] = (byte)this.formationByte3.Value;
            this.formationName3.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte3.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte4_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[3] = (byte)this.formationByte4.Value;
            this.formationName4.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte4.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte5_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[4] = (byte)this.formationByte5.Value;
            this.formationName5.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte5.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte6_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[5] = (byte)this.formationByte6.Value;
            this.formationName6.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte6.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte7_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[6] = (byte)this.formationByte7.Value;
            this.formationName7.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte7.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte8_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationMonster[7] = (byte)this.formationByte8.Value;
            this.formationName8.SelectedIndex = this.universal.MonsterNames.GetIndexFromNum((byte)formationByte8.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = statsModel.Formations[(int)this.formationNum.Value];

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte1.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName1.SelectedIndex);
        }
        private void formationName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte2.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName2.SelectedIndex);
        }
        private void formationName3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte3.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName3.SelectedIndex);
        }
        private void formationName4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte4.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName4.SelectedIndex);
        }
        private void formationName5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte5.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName5.SelectedIndex);
        }
        private void formationName6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte6.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName6.SelectedIndex);
        }
        private void formationName7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte7.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName7.SelectedIndex);
        }
        private void formationName8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.formationByte8.Value = this.universal.MonsterNames.GetNumFromIndex(this.formationName8.SelectedIndex);
        }
        private void formationCoordX1_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[0] = (byte)this.formationCoordX1.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX2_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[1] = (byte)this.formationCoordX2.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX3_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[2] = (byte)this.formationCoordX3.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX4_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[3] = (byte)this.formationCoordX4.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX5_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[4] = (byte)this.formationCoordX5.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX6_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[5] = (byte)this.formationCoordX6.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX7_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[6] = (byte)this.formationCoordX7.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX8_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordX[7] = (byte)this.formationCoordX8.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY1_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[0] = (byte)this.formationCoordY1.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY2_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[1] = (byte)this.formationCoordY2.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY3_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[2] = (byte)this.formationCoordY3.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY4_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[3] = (byte)this.formationCoordY4.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY5_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[4] = (byte)this.formationCoordY5.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY6_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[5] = (byte)this.formationCoordY6.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY7_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[6] = (byte)this.formationCoordY7.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY8_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            this.statsModel.Formations[(int)this.formationNum.Value].FormationCoordY[7] = (byte)this.formationCoordY8.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            for (int i = 0; i < 8; i++)
                this.statsModel.Formations[(int)this.formationNum.Value].FormationUse[i] = checkedListBox1.GetItemChecked(i);

            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            for (int i = 0; i < 8; i++)
                this.statsModel.Formations[(int)this.formationNum.Value].FormationHide[i] = checkedListBox2.GetItemChecked(i);
        }
        private void formationMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            statsModel.Formations[(int)this.formationNum.Value].FormationMusic = (byte)formationMusic.SelectedIndex;

            updatingFormations = true;
            this.musicTrack.Enabled = formationMusic.SelectedIndex != 8;
            if (formationMusic.SelectedIndex != 8)
                this.musicTrack.SelectedIndex = statsModel.FormationMusics[formationMusic.SelectedIndex];
            else
                this.musicTrack.SelectedIndex = 0;
            updatingFormations = false;
        }
        private void formationUnknown_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            statsModel.Formations[(int)this.formationNum.Value].FormationUnknown = (byte)formationUnknown.Value;
        }
        private void formationCantRun_CheckedChanged(object sender, EventArgs e)
        {
            formationCantRun.ForeColor = formationCantRun.Checked ? Color.Black : SystemColors.ControlDark;

            if (updatingFormations) return;

            statsModel.Formations[(int)this.formationNum.Value].FormationCantRun = formationCantRun.Checked;
        }
        private void battlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            RefreshFormationBattlefield();
        }

        private void formationBattleEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            statsModel.Formations[(int)this.formationNum.Value].FormationBattleEvent = (byte)formationBattleEvent.Value;
        }
        private void musicTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormations) return;

            statsModel.FormationMusics[formationMusic.SelectedIndex] = (byte)musicTrack.SelectedIndex;
        }

        private void pictureBoxFormation_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            switch (overFM)
            {
                case 1: diffX = (int)(x - formationCoordX1.Value); diffY = (int)(y - formationCoordY1.Value); break;
                case 2: diffX = (int)(x - formationCoordX2.Value); diffY = (int)(y - formationCoordY2.Value); break;
                case 3: diffX = (int)(x - formationCoordX3.Value); diffY = (int)(y - formationCoordY3.Value); break;
                case 4: diffX = (int)(x - formationCoordX4.Value); diffY = (int)(y - formationCoordY4.Value); break;
                case 5: diffX = (int)(x - formationCoordX5.Value); diffY = (int)(y - formationCoordY5.Value); break;
                case 6: diffX = (int)(x - formationCoordX6.Value); diffY = (int)(y - formationCoordY6.Value); break;
                case 7: diffX = (int)(x - formationCoordX7.Value); diffY = (int)(y - formationCoordY7.Value); break;
                case 8: diffX = (int)(x - formationCoordX8.Value); diffY = (int)(y - formationCoordY8.Value); break;
            }
        }
        private void pictureBoxFormation_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - diffX; int y = e.Y - diffY;
            if (x > 255) x = 255; if (x < 0) x = 0;
            if (y > 255) y = 255; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left)
            {
                switch (overFM)
                {
                    case 1:
                        if (formationCoordX1.Value != x && formationCoordY1.Value != y) waitBothCoords = true;
                        formationCoordX1.Value = x;
                        waitBothCoords = false;
                        formationCoordY1.Value = y; break;
                    case 2:
                        if (formationCoordX2.Value != x && formationCoordY2.Value != y) waitBothCoords = true;
                        formationCoordX2.Value = x;
                        waitBothCoords = false;
                        formationCoordY2.Value = y; break;
                    case 3:
                        if (formationCoordX3.Value != x && formationCoordY3.Value != y) waitBothCoords = true;
                        formationCoordX3.Value = x;
                        waitBothCoords = false;
                        formationCoordY3.Value = y; break;
                    case 4:
                        if (formationCoordX4.Value != x && formationCoordY4.Value != y) waitBothCoords = true;
                        formationCoordX4.Value = x;
                        waitBothCoords = false;
                        formationCoordY4.Value = y; break;
                    case 5:
                        if (formationCoordX5.Value != x && formationCoordY5.Value != y) waitBothCoords = true;
                        formationCoordX5.Value = x;
                        waitBothCoords = false;
                        formationCoordY5.Value = y; break;
                    case 6:
                        if (formationCoordX6.Value != x && formationCoordY6.Value != y) waitBothCoords = true;
                        formationCoordX6.Value = x;
                        waitBothCoords = false;
                        formationCoordY6.Value = y; break;
                    case 7:
                        if (formationCoordX7.Value != x && formationCoordY7.Value != y) waitBothCoords = true;
                        formationCoordX7.Value = x;
                        waitBothCoords = false;
                        formationCoordY7.Value = y; break;
                    case 8:
                        if (formationCoordX8.Value != x && formationCoordY8.Value != y) waitBothCoords = true;
                        formationCoordX8.Value = x;
                        waitBothCoords = false;
                        formationCoordY8.Value = y; break;
                }
            }
            else
            {
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > 0 && e.X < 256 && e.Y > 0 && e.Y < 256 &&
                        this.statsModel.Formations[(int)this.formationNum.Value].PixelAssn[e.Y * 256 + e.X] == (int)(j + 1))
                    {
                        pictureBoxFormation.Cursor = Cursors.Hand;
                        overFM = j + 1;
                        break;
                    }
                    else
                    {
                        pictureBoxFormation.Cursor = Cursors.Arrow;
                        overFM = 0;
                    }
                }
            }
        }
        private void pictureBoxFormation_MouseUp(object sender, MouseEventArgs e)
        {
            formationImage = new Bitmap(this.statsModel.Formations[(int)this.formationNum.Value].FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void pictureBoxFormation_Paint(object sender, PaintEventArgs e)
        {
            if (formationBGImage != null)
                e.Graphics.DrawImage(formationBGImage, 0, 0);
            if (formationImage != null)
                e.Graphics.DrawImage(formationImage, 0, 0);
        }

        // search formations...
        private void searchFormationNames_Click(object sender, EventArgs e)
        {
            panelSearchFormationNames.Visible = !panelSearchFormationNames.Visible;
            if (panelSearchFormationNames.Visible)
            {
                panelSearchFormationNames.BringToFront();
                nameTextBox.Focus();
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadFormationNameSearch();
        }
        private void listBoxFormationNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                formationNameList.SelectedItem = listBoxFormationNames.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchFormationNames.Visible = false;
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadFormationNameSearch();
        }
        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchFormationNames.Visible = false;
        }
        private void listBoxFormationNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchFormationNames.Visible = false;
        }
        private void LoadFormationNameSearch()
        {
            listBoxFormationNames.BeginUpdate();
            listBoxFormationNames.Items.Clear();

            for (int i = 0; i < formationNameList.Items.Count; i++)
            {
                if (Contains(formationNameList.Items[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxFormationNames.Items.Add(formationNameList.Items[i]);
            }
            listBoxFormationNames.EndUpdate();
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }
        //
        #endregion
        #region FormationPack Event Handlers
        private void packNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshFormationPacks();
        }
        private void formationSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFormationPacks) return;

            statsModel.FormationPacks[(int)this.packNum.Value].FormationPackSet = (byte)formationSet.SelectedIndex;

            RefreshFormationPacks();
        }
        private void packFormation1_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormationPacks) return;

            statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[0] = (byte)((ushort)packFormation1.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormation2_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormationPacks) return;

            statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[1] = (byte)((ushort)packFormation2.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormation3_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFormationPacks) return;

            statsModel.FormationPacks[(int)this.packNum.Value].FormationPackForm[2] = (byte)((ushort)packFormation3.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormationButton1_Click(object sender, EventArgs e)
        {
            formationNum.Value = packFormation1.Value;
        }
        private void packFormationButton2_Click(object sender, EventArgs e)
        {
            formationNum.Value = packFormation2.Value;
        }
        private void packFormationButton3_Click(object sender, EventArgs e)
        {
            formationNum.Value = packFormation3.Value;
        }

        // search formation packs...
        private void searchFormationPacks_Click(object sender, EventArgs e)
        {
            panelSearchFormationPacks.Visible = !panelSearchFormationPacks.Visible;
            if (panelSearchFormationPacks.Visible)
            {
                panelSearchFormationPacks.BringToFront();
                packNameTextBox.Focus();
            }
        }
        private void treeViewPackNames_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                packNum.Value = (int)treeViewPackNames.SelectedNode.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void treeViewPackNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchFormationPacks.Visible = false;
        }
        private void packNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchFormationPacks.Visible = false;
        }
        private void packNameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadFormationPackSearch();
        }
        private void LoadFormationPackSearch()
        {
            treeViewPackNames.BeginUpdate();
            treeViewPackNames.Nodes.Clear();

            TreeNode tn;
            TreeNode cn;
            int set = 0;
            foreach (LAZYSHELL.StatsEditor.Stats.FormationPack fp in statsModel.FormationPacks)
            {
                set = fp.FormationPackSet == 1 ? 256 : 0;

                if (Contains(
                    formationNameList.Items[fp.FormationPackForm[0] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase) ||
                    Contains(
                    formationNameList.Items[fp.FormationPackForm[1] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase) ||
                    Contains(
                    formationNameList.Items[fp.FormationPackForm[2] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    tn = treeViewPackNames.Nodes.Add("PACK #" + fp.FormationPackNum);
                    tn.Tag = (int)fp.FormationPackNum;

                    if (Contains(
                        formationNameList.Items[fp.FormationPackForm[0] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formationNameList.Items[fp.FormationPackForm[0] + set].ToString());
                        cn.Tag = (int)fp.FormationPackNum;
                    }
                    if (Contains(
                        formationNameList.Items[fp.FormationPackForm[1] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formationNameList.Items[fp.FormationPackForm[1] + set].ToString());
                        cn.Tag = (int)fp.FormationPackNum;
                    }
                    if (Contains(
                        formationNameList.Items[fp.FormationPackForm[2] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formationNameList.Items[fp.FormationPackForm[2] + set].ToString());
                        cn.Tag = (int)fp.FormationPackNum;
                    }
                }
            }
            treeViewPackNames.ExpandAll();
            treeViewPackNames.EndUpdate();
        }
        #endregion
    }
}
