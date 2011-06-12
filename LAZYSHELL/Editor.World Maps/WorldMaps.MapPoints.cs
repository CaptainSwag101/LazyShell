using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Previewer;

namespace LAZYSHELL
{
    public partial class WorldMaps
    {
        #region Variables
        // main
        private bool updatingMapPoints;
        private MapPoint[] mapPoints { get { return Model.MapPoints; } set { Model.MapPoints = value; } }
        private MapPoint mapPoint { get { return mapPoints[index_l]; } set { mapPoints[index_l] = value; } }
        private int index_l;
        public int Index_l { get { return (int)mapPointNum.Value; } set { mapPointNum.Value = value; } }
        private PaletteSet[] fontPalettes = new PaletteSet[3];
        private FontCharacter[] fontDialogue = new FontCharacter[128];
        private BattleDialoguePreview drawName = new BattleDialoguePreview();
        // special controls
        #endregion
        #region Methods

        // initialize properties
        private void InitializeMapPointEditor()
        {
            updatingMapPoints = true;

            index_l = 0;
            this.mapPointNum.Value = 0;

            for (int i = 0; i < mapPoints.Length; i++)
                mapPointName.Items.Add(new string(mapPoints[i].Name));

            RefreshMapPointEditor();

            updatingMapPoints = false;
        }
        private void RefreshMapPointEditor()
        {
            updatingMapPoints = true;

            SetMapPointNames();

            mapPointName.SelectedIndex = index_l = (int)mapPointNum.Value;

            this.mapPointXCoord.Value = mapPoint.X;
            this.mapPointYCoord.Value = mapPoint.Y;
            this.showCheckBit.Value = mapPoint.ShowCheckBit;
            this.showCheckAddress.Value = mapPoint.ShowCheckAddress;
            this.leadToMapPoint.Checked = mapPoint.GoMapPoint;

            if (mapPoint.GoMapPoint)
            {
                label55.Text = "lead to destination";
                label56.Text = "else lead to destination";
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                goMapPointA.BringToFront();
                goMapPointA.Enabled = true;
                goMapPointB.Enabled = true;
                whichPointCheckAddress.Value = mapPoint.WhichPointCheckAddress;
                whichPointCheckBit.Value = mapPoint.WhichPointCheckBit;
                goMapPointA.SelectedIndex = mapPoint.GoMapPointA;
                goMapPointB.SelectedIndex = mapPoint.GoMapPointB;
            }
            else
            {
                runEvent.BringToFront();
                runEventEdit.BringToFront();
                label55.Text = "assigned event #";
                label56.Text = "";
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goMapPointA.Enabled = false;
                goMapPointB.Enabled = false;
                runEvent.Value = mapPoint.RunEvent;
            }

            enableEastPath.Checked = mapPoint.ToEastEnabled;
            if (mapPoint.ToEastEnabled)
            {
                toEastPoint.Enabled = true;
                toEastCheckAddress.Enabled = true;
                toEastCheckBit.Enabled = true;
                toEastPoint.SelectedIndex = mapPoint.ToEastPoint;
                toEastCheckAddress.Value = mapPoint.ToEastCheckAddress;
                toEastCheckBit.Value = mapPoint.ToEastCheckBit;
            }
            else
            {
                toEastPoint.Enabled = false;
                toEastCheckAddress.Enabled = false;
                toEastCheckBit.Enabled = false;
            }

            enableSouthPath.Checked = mapPoint.ToSouthEnabled;
            if (mapPoint.ToSouthEnabled)
            {
                toSouthPoint.Enabled = true;
                toSouthCheckAddress.Enabled = true;
                toSouthCheckBit.Enabled = true;
                toSouthPoint.SelectedIndex = mapPoint.ToSouthPoint;
                toSouthCheckAddress.Value = mapPoint.ToSouthCheckAddress;
                toSouthCheckBit.Value = mapPoint.ToSouthCheckBit;
            }
            else
            {
                toSouthPoint.Enabled = false;
                toSouthCheckAddress.Enabled = false;
                toSouthCheckBit.Enabled = false;
            }

            enableWestPath.Checked = mapPoint.ToWestEnabled;
            if (mapPoint.ToWestEnabled)
            {
                toWestPoint.Enabled = true;
                toWestCheckAddress.Enabled = true;
                toWestCheckBit.Enabled = true;
                toWestPoint.SelectedIndex = mapPoint.ToWestPoint;
                toWestCheckAddress.Value = mapPoint.ToWestCheckAddress;
                toWestCheckBit.Value = mapPoint.ToWestCheckBit;
            }
            else
            {
                toWestPoint.Enabled = false;
                toWestCheckAddress.Enabled = false;
                toWestCheckBit.Enabled = false;
            }

            enableNorthPath.Checked = mapPoint.ToNorthEnabled;
            if (mapPoint.ToNorthEnabled)
            {
                toNorthPoint.Enabled = true;
                toNorthCheckAddress.Enabled = true;
                toNorthCheckBit.Enabled = true;
                toNorthPoint.SelectedIndex = mapPoint.ToNorthPoint;
                toNorthCheckAddress.Value = mapPoint.ToNorthCheckAddress;
                toNorthCheckBit.Value = mapPoint.ToNorthCheckBit;
            }
            else
            {
                toNorthPoint.Enabled = false;
                toNorthCheckAddress.Enabled = false;
                toNorthCheckBit.Enabled = false;
            }

            textBoxMapPoint.Text = Do.RawToASCII(mapPoint.Name, settings.Keystrokes);

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

            if (mapPoint.GoMapPoint)
            {
                for (int i = 0; i < mapPoints.Length; i++)
                    goMapPointA.Items.Add(new string(mapPoints[i].Name));
                for (int i = 0; i < mapPoints.Length; i++)
                    goMapPointB.Items.Add(new string(mapPoints[i].Name));
            }
            for (int i = 0; i < mapPoints.Length; i++)
                toEastPoint.Items.Add(new string(mapPoints[i].Name));
            for (int i = 0; i < mapPoints.Length; i++)
                toSouthPoint.Items.Add(new string(mapPoints[i].Name));
            for (int i = 0; i < mapPoints.Length; i++)
                toWestPoint.Items.Add(new string(mapPoints[i].Name));
            for (int i = 0; i < mapPoints.Length; i++)
                toNorthPoint.Items.Add(new string(mapPoints[i].Name));
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

        private void AssembleAllMapPointTexts()
        {
            char[][] pointNames = new char[56][];
            char[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] locations = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something
            // set duplicates
            for (int i = 0; i < mapPoints.Length; i++)
            {
                pointNames[i] = mapPoints[i].Name;   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < mapPoints.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = mapPoints[a].Name;   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (Bits.Compare(pointNames[i], tempB, b, 0)) // if tempB is a duplicate of tempA at location b of tempA
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
                    Bits.SetShort(Model.Data, i * 2 + pOffset, pointers[i]);
                    Bits.SetCharArray(Model.Data, dOffset, pointNames[i]);
                    dOffset += pointNames[i].Length;
                    pointer += (ushort)pointNames[i].Length;
                    Model.Data[dOffset] = 6; dOffset++; pointer++;
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
                    Bits.SetShort(Model.Data, i * 2 + pOffset, pointers[i]);
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
                mapPointName.SelectedIndex = index_l = (int)mapPointNum.Value;
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
                mapPointNum.Value = index_l = mapPointName.SelectedIndex;
        }
        private void mapPointName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 55)
                return;

            // set the palette
            int[] palette = new int[16];
            for (int i = 0; i < 16; i++) // 16 colors in palette
                palette[i] = Color.FromArgb(fontPalettes[2].Palettes[0][i]).ToArgb();

            // set the pixels
            int[] temp = drawName.GetPreview(fontDialogue, palette, mapPoints[e.Index].Name, false);
            int[] pixels = new int[256 * 32];

            for (int y = 2, c = 10; c < 32; y++, c++)
            {
                for (int x = 2, a = 8; a < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(Do.PixelsToImage(pixels, 256, 32));
            Bitmap bgimage = Model.MenuBackground_;
            if (bgimage != null)
            {
                Rectangle background = new Rectangle(0, e.Index * 15 % bgimage.Height, bgimage.Width, 15);
                e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(icon), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void textBoxMapPoint_TextChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.Name = Do.ASCIIToRaw(textBoxMapPoint.Text, settings.Keystrokes, textBoxMapPoint.Text.Length);

            updatingMapPoints = true;
            mapPointName.Items.RemoveAt(index_l);
            mapPointName.Items.Insert(index_l, textBoxMapPoint.Text);
            mapPointName.Text = textBoxMapPoint.Text;
            mapPointName.Invalidate();
            updatingMapPoints = false;

            // check total length
            char[][] pointNames = new char[56][];
            char[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] locations = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something
            // set duplicates
            for (int i = 0; i < mapPoints.Length; i++)
            {
                pointNames[i] = mapPoints[i].Name;   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < mapPoints.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = mapPoints[a].Name;   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (Bits.Compare(pointNames[i], tempB, b, 0)) // if tempB is a duplicate of tempA at location b of tempA
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
                        MessageBox.Show("The total size of all map point names is too large.\nPlease reduce the length of one or more map point names.", "LAZY SHELL");
                        break;
                    }
                }
            }
        }
        private void mapPointXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.X = (byte)mapPointXCoord.Value;

            if (updating) return;

            SetWorldMapPointsImage();
        }
        private void mapPointYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.Y = (byte)mapPointYCoord.Value;

            if (updating) return;

            SetWorldMapPointsImage();
        }
        private void showCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ShowCheckAddress = (ushort)showCheckAddress.Value;
        }
        private void showCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ShowCheckBit = (byte)showCheckBit.Value;
        }
        private void leadToMapPoint_CheckedChanged(object sender, EventArgs e)
        {
            leadToMapPoint.ForeColor = leadToMapPoint.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoint.GoMapPoint = leadToMapPoint.Checked;
            goMapPointA.Items.Clear();
            goMapPointB.Items.Clear();
            if (mapPoint.GoMapPoint)
            {
                for (int i = 0; i < mapPoints.Length; i++)
                {
                    goMapPointA.Items.Add(mapPoints[i].Name);
                    goMapPointB.Items.Add(mapPoints[i].Name);
                }
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                label55.Text = "lead to destination";
                label56.Text = "else lead to destination";
                goMapPointA.Enabled = true;
                goMapPointB.Enabled = true;
                goMapPointA.BringToFront();
                goMapPointA.SelectedIndex = mapPoint.GoMapPointA;
                goMapPointB.SelectedIndex = mapPoint.GoMapPointB;
            }
            else
            {
                runEvent.BringToFront();
                runEventEdit.BringToFront();
                label55.Text = "assigned event #";
                label56.Text = "";
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goMapPointA.Enabled = false;
                goMapPointB.Enabled = false;
                runEvent.Value = mapPoint.RunEvent;
            }
        }
        private void whichPointCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.WhichPointCheckAddress = (ushort)whichPointCheckAddress.Value;
        }
        private void whichPointCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.WhichPointCheckBit = (byte)whichPointCheckBit.Value;
        }
        private void goMapPointA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            if (mapPoint.GoMapPoint)
                mapPoint.GoMapPointA = (byte)goMapPointA.SelectedIndex;
        }
        private void runEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            if (!mapPoint.GoMapPoint)
                mapPoint.RunEvent = (ushort)runEvent.Value;
        }
        private void runEventEdit_Click(object sender, EventArgs e)
        {
            if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                Model.Program.CreateEventScriptsWindow();

            Model.Program.EventScripts.EventName.SelectedIndex = 0;
            Model.Program.EventScripts.EventNum.Value = runEvent.Value;
            Model.Program.EventScripts.BringToFront();
        }
        private void goMapPointB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.GoMapPointB = (byte)goMapPointB.SelectedIndex;
        }
        private void toEastPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToEastPoint = (byte)toEastPoint.SelectedIndex;
        }
        private void toSouthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToSouthPoint = (byte)toSouthPoint.SelectedIndex;
        }
        private void toWestPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToWestPoint = (byte)toWestPoint.SelectedIndex;
        }
        private void toNorthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToNorthPoint = (byte)toNorthPoint.SelectedIndex;
        }
        private void toEastCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToEastCheckAddress = (ushort)toEastCheckAddress.Value;
        }
        private void toSouthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToSouthCheckAddress = (ushort)toSouthCheckAddress.Value;
        }
        private void toWestCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToWestCheckAddress = (ushort)toWestCheckAddress.Value;
        }
        private void toNorthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToNorthCheckAddress = (ushort)toNorthCheckAddress.Value;
        }
        private void toEastCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToEastCheckBit = (byte)toEastCheckBit.Value;
        }
        private void toSouthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToSouthCheckBit = (byte)toSouthCheckBit.Value;
        }
        private void toWestCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToWestCheckBit = (byte)toWestCheckBit.Value;
        }
        private void toNorthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (updatingMapPoints) return;

            mapPoint.ToNorthCheckBit = (byte)toNorthCheckBit.Value;
        }
        private void enableEastPath_CheckedChanged(object sender, EventArgs e)
        {
            enableEastPath.ForeColor = enableEastPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoint.ToEastEnabled = enableEastPath.Checked;

            toEastPoint.Enabled = enableEastPath.Checked;
            toEastCheckAddress.Enabled = enableEastPath.Checked;
            toEastCheckBit.Enabled = enableEastPath.Checked;
        }
        private void enableSouthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableSouthPath.ForeColor = enableSouthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoint.ToSouthEnabled = enableSouthPath.Checked;

            toSouthPoint.Enabled = enableSouthPath.Checked;
            toSouthCheckAddress.Enabled = enableSouthPath.Checked;
            toSouthCheckBit.Enabled = enableSouthPath.Checked;
        }
        private void enableWestPath_CheckedChanged(object sender, EventArgs e)
        {
            enableWestPath.ForeColor = enableWestPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoint.ToWestEnabled = enableWestPath.Checked;

            toWestPoint.Enabled = enableWestPath.Checked;
            toWestCheckAddress.Enabled = enableWestPath.Checked;
            toWestCheckBit.Enabled = enableWestPath.Checked;
        }
        private void enableNorthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableNorthPath.ForeColor = enableNorthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingMapPoints) return;

            mapPoint.ToNorthEnabled = enableNorthPath.Checked;

            toNorthPoint.Enabled = enableNorthPath.Checked;
            toNorthCheckAddress.Enabled = enableNorthPath.Checked;
            toNorthCheckBit.Enabled = enableNorthPath.Checked;
        }

        #endregion
    }
}
