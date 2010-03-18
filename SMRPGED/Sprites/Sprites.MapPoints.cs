using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Sprites
    {
        #region Variables

        private bool updatingMapPoints;

        private MapPoint[] mapPoints;
        private int currentMapPoint;
        private static string[] worldMapLevels = new string[]
            {
               "Bowser's Keep (talk to Exor)",
               "Mario's Pad",
               "Mushroom Way",
               "Mushroom Kingdom",
               "Bandit's Way",
               "Kero Sewers",
               "Midas River",
               "Tadpole Pond",
               "Pipe Vault",
               "Rose Way",
               "Rose Town",
               "Forest Maze",
               "Yo'ster Island",
               "Moleville",
               "Booster Pass",
               "Booster Tower",
               "Marrymore",
               "Star Hill",
               "Seaside Town",
               "Sea",
               "Sunken Ship",
               "Land's End",
               "Monstro Town",
               "Bean Valley",
               "Nimbus Land",
               "Barrel Volcano",
               "Vista Hill",
               "Booster Hill",
               "Bowser's Keep (2nd time)",
               "Gate",
               "Grate Guy's Casino",
               "Debug Room"
            };

        #endregion

        #region Methods

        // initialize properties
        private void InitializeMapPointEditor()
        {
            updatingMapPoints = true;

            this.mapPoints = spriteModel.MapPoints;

            currentMapPoint = 0;
            this.mapPointNum.Value = 0;

            for (int i = 0; i < mapPoints.Length; i++)
                mapPointName.Items.Add(mapPoints[i].MapPointText);

            RefreshMapPointEditor();

            updatingMapPoints = false;
        }
        private void RefreshMapPointEditor()
        {
            updatingMapPoints = true;

            SetMapPointNames();

            mapPointName.SelectedIndex = currentMapPoint = (int)mapPointNum.Value;

            this.mapPointXCoord.Value = mapPoints[currentMapPoint].XCoord;
            this.mapPointYCoord.Value = mapPoints[currentMapPoint].YCoord;
            this.showCheckBit.Value = mapPoints[currentMapPoint].ShowCheckBit;
            this.showCheckAddress.Value = mapPoints[currentMapPoint].ShowCheckAddress;
            this.leadToMapPoint.Checked = mapPoints[currentMapPoint].GoMapPoint;

            if (mapPoints[currentMapPoint].GoMapPoint)
            {
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                goMapPointB.Enabled = true;
                whichPointCheckAddress.Value = mapPoints[currentMapPoint].WhichPointCheckAddress;
                whichPointCheckBit.Value = mapPoints[currentMapPoint].WhichPointCheckBit;
                goMapPointA.SelectedIndex = mapPoints[currentMapPoint].GoMapPointA;
                goMapPointB.SelectedIndex = mapPoints[currentMapPoint].GoMapPointB;
            }
            else
            {
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goMapPointB.Enabled = false;
                goMapPointA.SelectedIndex = mapPoints[currentMapPoint].Destination;
            }

            enableEastPath.Checked = mapPoints[currentMapPoint].ToEastEnabled;
            if (mapPoints[currentMapPoint].ToEastEnabled)
            {
                toEastPoint.Enabled = true;
                toEastCheckAddress.Enabled = true;
                toEastCheckBit.Enabled = true;
                toEastPoint.SelectedIndex = mapPoints[currentMapPoint].ToEastPoint;
                toEastCheckAddress.Value = mapPoints[currentMapPoint].ToEastCheckAddress;
                toEastCheckBit.Value = mapPoints[currentMapPoint].ToEastCheckBit;
            }
            else
            {
                toEastPoint.Enabled = false;
                toEastCheckAddress.Enabled = false;
                toEastCheckBit.Enabled = false;
            }

            enableSouthPath.Checked = mapPoints[currentMapPoint].ToSouthEnabled;
            if (mapPoints[currentMapPoint].ToSouthEnabled)
            {
                toSouthPoint.Enabled = true;
                toSouthCheckAddress.Enabled = true;
                toSouthCheckBit.Enabled = true;
                toSouthPoint.SelectedIndex = mapPoints[currentMapPoint].ToSouthPoint;
                toSouthCheckAddress.Value = mapPoints[currentMapPoint].ToSouthCheckAddress;
                toSouthCheckBit.Value = mapPoints[currentMapPoint].ToSouthCheckBit;
            }
            else
            {
                toSouthPoint.Enabled = false;
                toSouthCheckAddress.Enabled = false;
                toSouthCheckBit.Enabled = false;
            }

            enableWestPath.Checked = mapPoints[currentMapPoint].ToWestEnabled;
            if (mapPoints[currentMapPoint].ToWestEnabled)
            {
                toWestPoint.Enabled = true;
                toWestCheckAddress.Enabled = true;
                toWestCheckBit.Enabled = true;
                toWestPoint.SelectedIndex = mapPoints[currentMapPoint].ToWestPoint;
                toWestCheckAddress.Value = mapPoints[currentMapPoint].ToWestCheckAddress;
                toWestCheckBit.Value = mapPoints[currentMapPoint].ToWestCheckBit;
            }
            else
            {
                toWestPoint.Enabled = false;
                toWestCheckAddress.Enabled = false;
                toWestCheckBit.Enabled = false;
            }

            enableNorthPath.Checked = mapPoints[currentMapPoint].ToNorthEnabled;
            if (mapPoints[currentMapPoint].ToNorthEnabled)
            {
                toNorthPoint.Enabled = true;
                toNorthCheckAddress.Enabled = true;
                toNorthCheckBit.Enabled = true;
                toNorthPoint.SelectedIndex = mapPoints[currentMapPoint].ToNorthPoint;
                toNorthCheckAddress.Value = mapPoints[currentMapPoint].ToNorthCheckAddress;
                toNorthCheckBit.Value = mapPoints[currentMapPoint].ToNorthCheckBit;
            }
            else
            {
                toNorthPoint.Enabled = false;
                toNorthCheckAddress.Enabled = false;
                toNorthCheckBit.Enabled = false;
            }

            textBoxMapPoint.Text = mapPoints[currentMapPoint].MapPointText;

            updatingMapPoints = false;
        }

        // name editing
        private void SetMapPointNames()
        {
            goMapPointA.Items.Clear();
            goMapPointB.Items.Clear();
            toEastPoint.Items.Clear();
            toSouthPoint.Items.Clear();
            toWestPoint.Items.Clear();
            toNorthPoint.Items.Clear();

            if (!mapPoints[currentMapPoint].GoMapPoint)
                goMapPointA.Items.AddRange(worldMapLevels);
            else
            {
                for (int i = 0; i < mapPoints.Length; i++)
                    goMapPointA.Items.Add(mapPoints[i].MapPointText);
                for (int i = 0; i < mapPoints.Length; i++)
                    goMapPointB.Items.Add(mapPoints[i].MapPointText);
            }
            for (int i = 0; i < mapPoints.Length; i++)
                toEastPoint.Items.Add(mapPoints[i].MapPointText);
            for (int i = 0; i < mapPoints.Length; i++)
                toSouthPoint.Items.Add(mapPoints[i].MapPointText);
            for (int i = 0; i < mapPoints.Length; i++)
                toWestPoint.Items.Add(mapPoints[i].MapPointText);
            for (int i = 0; i < mapPoints.Length; i++)
                toNorthPoint.Items.Add(mapPoints[i].MapPointText);
        }
        private bool CompareString(byte[] stringA, byte[] stringB, int loc)
        {
            int i = 0;
            for (; i < stringB.Length; i++)
                if (stringA[loc + i] != stringB[i])
                    return false;

            return true;
        }
        public byte[] strToByte(string toByte)
        {
            byte[] arr = new byte[toByte.Length];
            char[] str = toByte.ToCharArray();

            for (int i = 0; i < str.Length; i++)
                arr[i] = (byte)str[i];

            return arr;
        }

        // assemblers
        private void AssembleAllMapPoints()
        {
            foreach (MapPoint mp in mapPoints)
                mp.Assemble();

            AssembleAllMapPointTexts();
        }
        private void AssembleAllMapPointTexts()
        {
            byte[][] pointNames = new byte[56][];
            byte[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] locations = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something
            // set duplicates
            for (int i = 0; i < mapPoints.Length; i++)
            {
                pointNames[i] = strToByte(mapPoints[i].MapPointText);   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < mapPoints.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = strToByte(mapPoints[a].MapPointText);   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (CompareString(pointNames[i], tempB, b)) // if tempB is a duplicate of tempA at location b of tempA
                                    {
                                        locations[a] = b;
                                        duplicates[a] = i;
                                        isdup[a] = true;
                                        break;
                                    }
                                }
                                else if (tempB.Length > pointNames[i].Length - b)
                                    break;
                            }
                        }
                    }
                }
            }

            // assemble
            ushort[] pointers = new ushort[56];
            int pOffset = 0x3EFD00;
            int dOffset = 0x3EFD80;
            ushort pointer = 0;
            // set all of the ones that aren't duplicates first (so we'll have pointers to use)
            for (int i = 0; i < mapPoints.Length; i++)
            {
                if (!isdup[i])
                {
                    pointers[i] = pointer;
                    BitManager.SetShort(data, i * 2 + pOffset, pointers[i]);
                    BitManager.SetByteArray(data, dOffset, pointNames[i]);
                    dOffset += pointNames[i].Length;
                    pointer += (ushort)pointNames[i].Length;
                    data[dOffset] = 6; dOffset++; pointer++;
                }
            }
            // set duplicates
            pOffset = 0x3EFD00;
            pointer = 0;
            for (int i = 0; i < mapPoints.Length; i++)
            {
                if (isdup[i])
                {
                    pointers[i] = (ushort)(pointers[duplicates[i]] + locations[i]);
                    BitManager.SetShort(data, i * 2 + pOffset, pointers[i]);
                }
            }
        }

        #endregion

        #region Eventhandlers

        private void mapPointNum_ValueChanged(object sender, EventArgs e)
        {
            if (mapPointName.SelectedIndex == mapPointNum.Value)
            {
                if (!updatingMapPoints)
                {
                    RefreshMapPointEditor();
                    SetWorldMapPointsImage();
                }
            }
            else
                mapPointName.SelectedIndex = currentMapPoint = (int)mapPointNum.Value;
        }
        private void mapPointName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapPointNum.Value == (int)mapPointName.SelectedIndex)
            {
                if (!updatingMapPoints)
                {
                    RefreshMapPointEditor();
                    SetWorldMapPointsImage();
                }
            }
            else
                mapPointNum.Value = currentMapPoint = mapPointName.SelectedIndex;
        }
        private void textBoxMapPoint_TextChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].MapPointText = textBoxMapPoint.Text;

            updatingMapPoints = true;
            mapPointName.Items.RemoveAt(currentMapPoint);
            mapPointName.Items.Insert(currentMapPoint, textBoxMapPoint.Text);
            mapPointName.Text = textBoxMapPoint.Text;
            updatingMapPoints = false;

            // check total length
            byte[][] pointNames = new byte[56][];
            byte[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] locations = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something
            // set duplicates
            for (int i = 0; i < mapPoints.Length; i++)
            {
                pointNames[i] = strToByte(mapPoints[i].MapPointText);   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < mapPoints.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = strToByte(mapPoints[a].MapPointText);   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (CompareString(pointNames[i], tempB, b)) // if tempB is a duplicate of tempA at location b of tempA
                                    {
                                        locations[a] = b;
                                        duplicates[a] = i;
                                        isdup[a] = true;
                                        break;
                                    }
                                }
                                else if (tempB.Length > pointNames[i].Length - b)
                                    break;
                            }
                        }
                    }
                }
            }

            // assemble
            ushort[] pointers = new ushort[56];
            int dOffset = 0x3EFD80;
            ushort pointer = 0;
            // set all of the ones that aren't duplicates first (so we'll have pointers to use)
            for (int i = 0; i < mapPoints.Length; i++)
            {
                if (!isdup[i])
                {
                    pointers[i] = pointer;
                    dOffset += pointNames[i].Length;
                    pointer += (ushort)pointNames[i].Length;
                    dOffset++; pointer++;
                    if (i != mapPoints.Length - 1 && !isdup[i + 1] && dOffset > 0x3EFF1F)
                    {
                        MessageBox.Show("The total size of all map point names is too large.\nPlease reduce the length of one or more map point names.", "MAP POINT NAMES TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                }
            }
        }
        private void mapPointXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].XCoord = (byte)mapPointXCoord.Value;
            
            if (waitBothCoords) return;

            SetWorldMapPointsImage();
        }
        private void mapPointYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].YCoord = (byte)mapPointYCoord.Value;

            if (waitBothCoords) return;

            SetWorldMapPointsImage();
        }
        private void showCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ShowCheckAddress = (ushort)showCheckAddress.Value;
        }
        private void showCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ShowCheckBit = (byte)showCheckBit.Value;
        }
        private void leadToMapPoint_CheckedChanged(object sender, EventArgs e)
        {
            leadToMapPoint.ForeColor = leadToMapPoint.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].GoMapPoint = leadToMapPoint.Checked;
            goMapPointA.Items.Clear();
            goMapPointB.Items.Clear();
            if (mapPoints[currentMapPoint].GoMapPoint)
            {
                for (int i = 0; i < mapPoints.Length; i++)
                {
                    goMapPointA.Items.Add(mapPoints[i].MapPointText);
                    goMapPointB.Items.Add(mapPoints[i].MapPointText);
                }
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                goMapPointB.Enabled = true;
                goMapPointA.SelectedIndex = mapPoints[currentMapPoint].GoMapPointA;
                goMapPointB.SelectedIndex = mapPoints[currentMapPoint].GoMapPointB;
            }
            else
            {
                goMapPointA.Items.AddRange(worldMapLevels);
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goMapPointB.Enabled = false;
                goMapPointA.SelectedIndex = mapPoints[currentMapPoint].Destination;
            }
        }
        private void whichPointCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].WhichPointCheckAddress = (ushort)whichPointCheckAddress.Value;
        }
        private void whichPointCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].WhichPointCheckBit = (byte)whichPointCheckBit.Value;
        }
        private void goMapPointA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            if (mapPoints[currentMapPoint].GoMapPoint)
                mapPoints[currentMapPoint].GoMapPointA = (byte)goMapPointA.SelectedIndex;
            else
                mapPoints[currentMapPoint].Destination = (byte)goMapPointA.SelectedIndex;
        }
        private void goMapPointB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].GoMapPointB = (byte)goMapPointB.SelectedIndex;
        }
        private void toEastPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToEastPoint = (byte)toEastPoint.SelectedIndex;
        }
        private void toSouthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToSouthPoint = (byte)toSouthPoint.SelectedIndex;
        }
        private void toWestPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToWestPoint = (byte)toWestPoint.SelectedIndex;
        }
        private void toNorthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToNorthPoint = (byte)toNorthPoint.SelectedIndex;
        }
        private void toEastCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToEastCheckAddress = (ushort)toEastCheckAddress.Value;
        }
        private void toSouthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToSouthCheckAddress = (ushort)toSouthCheckAddress.Value;
        }
        private void toWestCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToWestCheckAddress = (ushort)toWestCheckAddress.Value;
        }
        private void toNorthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToNorthCheckAddress = (ushort)toNorthCheckAddress.Value;
        }
        private void toEastCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToEastCheckBit = (byte)toEastCheckBit.Value;
        }
        private void toSouthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToSouthCheckBit = (byte)toSouthCheckBit.Value;
        }
        private void toWestCheckbit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToWestCheckBit = (byte)toWestCheckBit.Value;
        }
        private void toNorthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToNorthCheckBit = (byte)toNorthCheckBit.Value;
        }
        private void enableEastPath_CheckedChanged(object sender, EventArgs e)
        {
            enableEastPath.ForeColor = enableEastPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToEastEnabled = enableEastPath.Checked;

            toEastPoint.Enabled = enableEastPath.Checked;
            toEastCheckAddress.Enabled = enableEastPath.Checked;
            toEastCheckBit.Enabled = enableEastPath.Checked;
        }
        private void enableSouthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableSouthPath.ForeColor = enableSouthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToSouthEnabled = enableSouthPath.Checked;

            toSouthPoint.Enabled = enableSouthPath.Checked;
            toSouthCheckAddress.Enabled = enableSouthPath.Checked;
            toSouthCheckBit.Enabled = enableSouthPath.Checked;
        }
        private void enableWestPath_CheckedChanged(object sender, EventArgs e)
        {
            enableWestPath.ForeColor = enableWestPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToWestEnabled = enableWestPath.Checked;

            toWestPoint.Enabled = enableWestPath.Checked;
            toWestCheckAddress.Enabled = enableWestPath.Checked;
            toWestCheckBit.Enabled = enableWestPath.Checked;
        }
        private void enableNorthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableNorthPath.ForeColor = enableNorthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoints[currentMapPoint].ToNorthEnabled = enableNorthPath.Checked;

            toNorthPoint.Enabled = enableNorthPath.Checked;
            toNorthCheckAddress.Enabled = enableNorthPath.Checked;
            toNorthCheckBit.Enabled = enableNorthPath.Checked;
        }

        #endregion
    }
}
