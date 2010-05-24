﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMRPGED.ScriptsEditor;

namespace SMRPGED
{
    public partial class ClearElements : Form
    {
        private object element;
        private int currentIndex;
        private int start = 0;
        private int end = 0;
        private Type type;

        public ClearElements(object element, int currentIndex, string title)
        {
            this.element = element;
            this.currentIndex = currentIndex;
            this.type = element.GetType();
            InitializeComponent();

            this.Text = title;

            if (type != typeof(Model))
                toIndex.Value = toIndex.Maximum = ((object[])element).Length - 1;
            if (type == typeof(Model) && this.Text == "CLEAR LEVEL DATA...")
                toIndex.Value = toIndex.Maximum = ((Model)element).LevelModel.Levels.Length - 1;
            if (type == typeof(Model) && this.Text == "CLEAR TILESETS...")
                toIndex.Value = toIndex.Maximum = ((Model)element).TileSets.Length - 1;
            if (type == typeof(Model) && this.Text == "CLEAR TILEMAPS...")
                toIndex.Value = toIndex.Maximum = ((Model)element).TileMaps.Length - 1;
            if (type == typeof(Model) && this.Text == "CLEAR PHYSICAL MAPS...")
                toIndex.Value = toIndex.Maximum = ((Model)element).PhysicalMaps.Length - 1;
            if (type == typeof(Model) && this.Text == "CLEAR BATTLEFIELD TILESETS...")
                toIndex.Value = toIndex.Maximum = ((Model)element).TileSetsBF.Length - 1;
            start = end = currentIndex;
        }

        private void fromDialogue_ValueChanged(object sender, EventArgs e)
        {
            toIndex.Minimum = fromIndex.Value;
            start = (int)fromIndex.Value;
        }

        private void toDialogue_ValueChanged(object sender, EventArgs e)
        {
            fromIndex.Maximum = toIndex.Value;
            end = (int)toIndex.Value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // SPRITES
            if (type == typeof(Dialogue[]))
            {
                for (int i = start; i <= end; i++)
                    ((Dialogue[])element)[i].SetDialogue("[0]", true);
            }
            if (type == typeof(MapPoint[]))
            {
                for (int i = start; i <= end; i++)
                    ((MapPoint[])element)[i].Clear();
            }
            if (type == typeof(Animation[]))
            {
                for (int i = start; i <= end; i++)
                    ((Animation[])element)[i].Clear();
            }
            if (type == typeof(SpritePalette[]))
            {
                for (int i = start; i <= end; i++)
                    ((SpritePalette[])element)[i].Clear();
            }
            if (type == typeof(WorldMap[]))
            {
                for (int i = start; i <= end; i++)
                    ((WorldMap[])element)[i].Clear();
            }
            if (type == typeof(E_Animation[]))
            {
                for (int i = start; i <= end; i++)
                    ((E_Animation[])element)[i].Clear();
            }

            // LEVELS
            if (type == typeof(Model) && this.Text == "CLEAR LEVEL DATA...")
            {
                for (int i = start; i <= end; i++)
                {
                    ((Model)element).LevelModel.Levels[i].Layer.Clear();
                    ((Model)element).LevelModel.Levels[i].LevelEvents.Clear();
                    ((Model)element).LevelModel.Levels[i].LevelExits.Clear();
                    ((Model)element).LevelModel.Levels[i].LevelNPCs.Clear();
                    int levelMap = ((Model)element).LevelModel.Levels[i].LevelMap;
                    ((Model)element).LevelModel.LevelMaps[levelMap].Clear();
                }
            }
            if (type == typeof(Model) && this.Text == "CLEAR TILESETS...")
            {
                for (int i = start; i <= end; i++)
                {
                    if (i < 0x20)
                        ((Model)element).TileSets[i] = new byte[0x1000];
                    else
                        ((Model)element).TileSets[i] = new byte[0x2000];
                    ((Model)element).EditTileSets[i] = true;
                }
            }
            if (type == typeof(Model) && this.Text == "CLEAR TILEMAPS...")
            {
                for (int i = start; i <= end; i++)
                {
                    if (i < 0x40)
                        ((Model)element).TileMaps[i] = new byte[0x1000];
                    else
                        ((Model)element).TileMaps[i] = new byte[0x2000];
                    ((Model)element).EditTileMaps[i] = true;
                }
            }
            if (type == typeof(Model) && this.Text == "CLEAR PHYSICAL MAPS...")
            {
                for (int i = start; i < end; i++)
                {
                    ((Model)element).PhysicalMaps[i] = new byte[0x20C2];
                    ((Model)element).EditPhysicalMaps[i] = true;
                }
            }
            if (type == typeof(Model) && this.Text == "CLEAR BATTLEFIELD TILESETS...")
            {
                for (int i = start; i < end; i++)
                {
                    ((Model)element).TileSetsBF[i] = new byte[0x2000];
                    ((Model)element).EditTileSetsBF[i] = true;
                }
            }



            // STATS



            // SCRIPTS
            if (type == typeof(BattleScript[]) && this.Text == "CLEAR BATTLE SCRIPTS...")
            {
                for (int i = start; i < end; i++)
                    ((BattleScript[])element)[i].ClearAll();
            }
            if (type == typeof(EventScript[]) && this.Text == "CLEAR EVENT SCRIPTS...")
            {
                for (int i = start; i < end; i++)
                    ((EventScript[])element)[i].ClearAll();
            }
            if (type == typeof(ActionQueue[]) && this.Text == "CLEAR ACTION SCRIPTS...")
            {
                for (int i = start; i < end; i++)
                    ((ActionQueue[])element)[i].ClearAll();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                fromIndex.Enabled = false;
                toIndex.Enabled = false;
                start = end = currentIndex;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                fromIndex.Enabled = true;
                toIndex.Enabled = true;
                start = (int)fromIndex.Value;
                end = (int)toIndex.Value;
            }
        }
    }
}
