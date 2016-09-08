using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.WorldMaps
{
    public partial class LocationsForm : Controls.DockForm
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Elements
        private Location[] locations
        {
            get { return Model.Locations; }
            set { Model.Locations = value; }
        }
        public Location location
        {
            get { return locations[Index]; }
            set { locations[Index] = value; }
        }
        public NumericUpDown X
        {
            get { return locationXCoord; }
            set { locationXCoord = value; }
        }
        public NumericUpDown Y
        {
            get { return locationYCoord; }
            set { locationYCoord = value; }
        }
        private OwnerForm ownerForm;
        private PictureBox picture
        {
            get { return worldMapsForm.Picture; }
            set { worldMapsForm.Picture = value; }
        }
        private WorldMapsForm worldMapsForm
        {
            get { return ownerForm.WorldMapsForm; }
            set { ownerForm.WorldMapsForm = value; }
        }
        private PaletteSet[] fontPalettes
        {
            get { return ownerForm.FontPalettes; }
            set { ownerForm.FontPalettes = value; }
        }
        private Fonts.Glyph[] fontDialogue
        {
            get { return ownerForm.FontDialogue; }
            set { ownerForm.FontDialogue = value; }
        }
        private BattleDialoguePreview drawName
        {
            get { return ownerForm.DrawName; }
            set { ownerForm.DrawName = value; }
        }
        
        #endregion

        // Constructor
        public LocationsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeListControls();
            LoadProperties();
        }

        #region Methods

        // initialize properties
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            for (int i = 0; i < locations.Length; i++)
                name.Items.Add(new string(locations[i].Name));
            name.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void LoadProperties()
        {
            this.Updating = true;
            SetLocationNames();
            this.locationXCoord.Value = location.X;
            this.locationYCoord.Value = location.Y;
            this.showCheckBit.Value = location.ShowCheckBit;
            this.showCheckAddress.Value = location.ShowCheckAddress;
            this.leadToLocation.Checked = location.GoToLocation;
            if (location.GoToLocation)
            {
                label52.Text = "If memory bit set";
                label55.Text = "lead to destination";
                label56.Text = "else lead to destination";
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                goLocationA.BringToFront();
                goLocationA.Enabled = true;
                goLocationB.Enabled = true;
                whichPointCheckAddress.Value = location.WhichLocationCheckAddress;
                whichPointCheckBit.Value = location.WhichLocationCheckBit;
                goLocationA.SelectedIndex = location.GoLocationA;
                goLocationB.SelectedIndex = location.GoLocationB;
            }
            else
            {
                runEvent.BringToFront();
                runEventEdit.BringToFront();
                label52.Text = "";
                label55.Text = "assigned event #";
                label56.Text = "";
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goLocationA.Enabled = false;
                goLocationB.Enabled = false;
                runEvent.Value = location.RunEvent;
            }
            enableEastPath.Checked = location.EnabledToEast;
            if (location.EnabledToEast)
            {
                toEastPoint.Enabled = true;
                toEastCheckAddress.Enabled = true;
                toEastCheckBit.Enabled = true;
                toEastPoint.SelectedIndex = location.LocationToEast;
                toEastCheckAddress.Value = location.CheckAddressToEast;
                toEastCheckBit.Value = location.CheckBitToEast;
            }
            else
            {
                toEastPoint.Enabled = false;
                toEastCheckAddress.Enabled = false;
                toEastCheckBit.Enabled = false;
            }
            enableSouthPath.Checked = location.EnabledToSouth;
            if (location.EnabledToSouth)
            {
                toSouthPoint.Enabled = true;
                toSouthCheckAddress.Enabled = true;
                toSouthCheckBit.Enabled = true;
                toSouthPoint.SelectedIndex = location.LocationToSouth;
                toSouthCheckAddress.Value = location.CheckAddressToSouth;
                toSouthCheckBit.Value = location.CheckBitToSouth;
            }
            else
            {
                toSouthPoint.Enabled = false;
                toSouthCheckAddress.Enabled = false;
                toSouthCheckBit.Enabled = false;
            }
            enableWestPath.Checked = location.EnabledToWest;
            if (location.EnabledToWest)
            {
                toWestPoint.Enabled = true;
                toWestCheckAddress.Enabled = true;
                toWestCheckBit.Enabled = true;
                toWestPoint.SelectedIndex = location.LocationToWest;
                toWestCheckAddress.Value = location.CheckAddressToWest;
                toWestCheckBit.Value = location.CheckBitToWest;
            }
            else
            {
                toWestPoint.Enabled = false;
                toWestCheckAddress.Enabled = false;
                toWestCheckBit.Enabled = false;
            }
            enableNorthPath.Checked = location.EnabledToNorth;
            if (location.EnabledToNorth)
            {
                toNorthPoint.Enabled = true;
                toNorthCheckAddress.Enabled = true;
                toNorthCheckBit.Enabled = true;
                toNorthPoint.SelectedIndex = location.LocationToNorth;
                toNorthCheckAddress.Value = location.CheckAddressToNorth;
                toNorthCheckBit.Value = location.CheckBitToNorth;
            }
            else
            {
                toNorthPoint.Enabled = false;
                toNorthCheckAddress.Enabled = false;
                toNorthCheckBit.Enabled = false;
            }
            textBoxLocation.Text = Do.RawToASCII(location.Name, Lists.Keystrokes);
            this.Updating = false;
        }

        // name editing
        private void SetLocationNames()
        {
            goLocationA.Items.Clear();
            goLocationB.Items.Clear();
            toEastPoint.Items.Clear();
            toSouthPoint.Items.Clear();
            toWestPoint.Items.Clear();
            toNorthPoint.Items.Clear();
            if (location.GoToLocation)
            {
                for (int i = 0; i < locations.Length; i++)
                    goLocationA.Items.Add(new string(locations[i].Name));
                for (int i = 0; i < locations.Length; i++)
                    goLocationB.Items.Add(new string(locations[i].Name));
            }
            for (int i = 0; i < locations.Length; i++)
                toEastPoint.Items.Add(new string(locations[i].Name));
            for (int i = 0; i < locations.Length; i++)
                toSouthPoint.Items.Add(new string(locations[i].Name));
            for (int i = 0; i < locations.Length; i++)
                toWestPoint.Items.Add(new string(locations[i].Name));
            for (int i = 0; i < locations.Length; i++)
                toNorthPoint.Items.Add(new string(locations[i].Name));
        }

        // Saving
        public void WriteToROM()
        {
            foreach (Location mp in locations)
                mp.WriteToROM();
            WriteNamesToROM();
        }
        public void WriteNamesToROM()
        {
            char[][] pointNames = new char[56][];
            char[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] levels = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something

            // Set duplicates
            for (int i = 0; i < locations.Length; i++)
            {
                pointNames[i] = locations[i].Name;   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < locations.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = locations[a].Name;   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (Bits.Compare(pointNames[i], tempB, b, 0)) // if tempB is a duplicate of tempA at location b of tempA
                                    {
                                        levels[a] = b;
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

            #region Write to ROM

            ushort[] pointers = new ushort[56];
            int pOffset = 0x3EFD00;
            int dOffset = 0x3EFD80;
            ushort pointer = 0;

            // Write all of the ones that aren't duplicates first (so we'll have pointers to use)
            for (int i = 0; i < locations.Length; i++)
            {
                if (!isdup[i])
                {
                    pointers[i] = pointer;
                    Bits.SetShort(Model.ROM, i * 2 + pOffset, pointers[i]);
                    Bits.SetChars(Model.ROM, dOffset, pointNames[i]);
                    dOffset += pointNames[i].Length;
                    pointer += (ushort)pointNames[i].Length;
                    Model.ROM[dOffset] = 6; dOffset++; pointer++;
                    if (i != locations.Length - 1 && !isdup[i + 1] && dOffset > 0x3EFF1F)
                        MessageBox.Show("The total compressed size of all location names is too large. Some data might not have been saved correctly. Please reduce the length of one or more location names.", "LAZY SHELL");
                }
            }

            // Write duplicates
            pOffset = 0x3EFD00;
            pointer = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                if (isdup[i])
                {
                    pointers[i] = (ushort)(pointers[duplicates[i]] + levels[i]);
                    Bits.SetShort(Model.ROM, i * 2 + pOffset, pointers[i]);
                }
            }

            #endregion
        }

        // Set images
        private void SetLocationsImage()
        {
            worldMapsForm.SetLocationsImage();
        }
        public void Reset()
        {
            if (MessageBox.Show("You're about to undo all changes to the current location. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            location = new Location(Index);
            worldMapsForm.AddLocations();
            LoadProperties();
            SetLocationsImage();
        }

        #endregion

        #region Event Handlers

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (name.SelectedIndex == num.Value)
            {
                if (!this.Updating)
                {
                    LoadProperties();
                    SetLocationsImage();
                }
            }
            else
                name.SelectedIndex = Index = (int)num.Value;
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (num.Value == (int)name.SelectedIndex)
            {
                if (!this.Updating)
                {
                    LoadProperties();
                    SetLocationsImage();
                }
            }
            else
                num.Value = Index = name.SelectedIndex;
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 55)
                return;
            // set the pixels
            int[] temp = drawName.GetPreview(fontDialogue, fontPalettes[2].Palettes[0], locations[e.Index].Name, false);
            int[] pixels = new int[256 * 32];
            for (int y = 2, c = 10; c < 32; y++, c++)
            {
                for (int x = 2, a = 8; a < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }
            Bitmap icon = Do.PixelsToImage(pixels, 256, 32);
            Bitmap bgimage = Menus.Model.MenuBG_256x255;
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

        // Name text
        private void nameText_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.Name = Do.ASCIIToRaw(textBoxLocation.Text, Lists.Keystrokes, textBoxLocation.Text.Length);
            this.Updating = true;
            name.Text = textBoxLocation.Text;
            name.Invalidate();
            this.Updating = false;
            // check total length
            char[][] pointNames = new char[56][];
            char[] tempB;
            int[] duplicates = new int[56];   // the point it is a duplicate of
            int[] levels = new int[56];    // the location within the point it is a duplicate of
            bool[] isdup = new bool[56];      // if is a duplicate of something
            // set duplicates
            for (int i = 0; i < locations.Length; i++)
            {
                pointNames[i] = locations[i].Name;   // the name we'll be comparing everything to
                if (!isdup[i])
                {
                    for (int a = 0; a < locations.Length; a++)
                    {
                        if (a != i && !isdup[a])  // last condition checks if it already has duplicate
                        {
                            tempB = locations[a].Name;   // the name that might be a duplicate of tempA
                            for (int b = 0; b < pointNames[i].Length; b++)
                            {
                                if (tempB.Length == pointNames[i].Length - b)
                                {
                                    if (Bits.Compare(pointNames[i], tempB, b, 0)) // if tempB is a duplicate of tempA at location b of tempA
                                    {
                                        levels[a] = b;
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
            // Assemble
            ushort[] pointers = new ushort[56];
            int dOffset = 0x3EFD80;
            ushort pointer = 0;
            // set all of the ones that aren't duplicates first (so we'll have pointers to use)
            for (int i = 0; i < locations.Length; i++)
            {
                if (!isdup[i])
                {
                    pointers[i] = pointer;
                    dOffset += pointNames[i].Length;
                    pointer += (ushort)pointNames[i].Length;
                    dOffset++; pointer++;
                    if (i != locations.Length - 1 && !isdup[i + 1] && dOffset > 0x3EFF1F)
                        break;
                }
            }
            dOffset--;
            nameFreeSpace.Text = (0x3EFF1F - dOffset).ToString() + " characters left";
            nameFreeSpace.BackColor = dOffset > 0x3EFF1F ? Color.Red : SystemColors.Control;
            //
            worldMapsForm.SetBannerTextImage();
        }

        // Coordinates
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.X = (byte)locationXCoord.Value;
            if (this.Updating)
                return;
            picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.Y = (byte)locationYCoord.Value;
            if (this.Updating)
                return;
            picture.Invalidate();
        }

        // Properties : Misc
        private void showCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.ShowCheckAddress = (ushort)showCheckAddress.Value;
        }
        private void showCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.ShowCheckBit = (byte)showCheckBit.Value;
        }
        private void leadToLocation_CheckedChanged(object sender, EventArgs e)
        {
            leadToLocation.ForeColor = leadToLocation.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            location.GoToLocation = leadToLocation.Checked;
            goLocationA.Items.Clear();
            goLocationB.Items.Clear();
            if (location.GoToLocation)
            {
                for (int i = 0; i < locations.Length; i++)
                {
                    goLocationA.Items.Add(locations[i].Name);
                    goLocationB.Items.Add(locations[i].Name);
                }
                whichPointCheckAddress.Enabled = true;
                whichPointCheckBit.Enabled = true;
                label52.Text = "If memory bit set";
                label55.Text = "lead to destination";
                label56.Text = "else lead to destination";
                goLocationA.Enabled = true;
                goLocationB.Enabled = true;
                goLocationA.BringToFront();
                goLocationA.SelectedIndex = location.GoLocationA;
                goLocationB.SelectedIndex = location.GoLocationB;
            }
            else
            {
                runEvent.BringToFront();
                runEventEdit.BringToFront();
                label52.Text = "";
                label55.Text = "assigned event #";
                label56.Text = "";
                whichPointCheckAddress.Enabled = false;
                whichPointCheckBit.Enabled = false;
                goLocationA.Enabled = false;
                goLocationB.Enabled = false;
                runEvent.Value = location.RunEvent;
            }
        }
        private void whichPointCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.WhichLocationCheckAddress = (ushort)whichPointCheckAddress.Value;
        }
        private void whichPointCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.WhichLocationCheckBit = (byte)whichPointCheckBit.Value;
        }
        private void goLocationA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (location.GoToLocation)
                location.GoLocationA = (byte)goLocationA.SelectedIndex;
        }
        private void runEvent_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (!location.GoToLocation)
                location.RunEvent = (ushort)runEvent.Value;
        }
        private void runEventEdit_Click(object sender, EventArgs e)
        {
            if (LazyShell.Model.Program.EventScripts == null || !LazyShell.Model.Program.EventScripts.Visible)
                LazyShell.Model.Program.CreateEventScriptsWindow();
            LazyShell.Model.Program.EventScripts.Type = 0;
            LazyShell.Model.Program.EventScripts.Index = (int)runEvent.Value;
            LazyShell.Model.Program.EventScripts.BringToFront();
        }
        private void goLocationB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.GoLocationB = (byte)goLocationB.SelectedIndex;
        }

        // Properties : Paths
        private void toEastPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.LocationToEast = (byte)toEastPoint.SelectedIndex;
        }
        private void toSouthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.LocationToSouth = (byte)toSouthPoint.SelectedIndex;
        }
        private void toWestPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.LocationToWest = (byte)toWestPoint.SelectedIndex;
        }
        private void toNorthPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.LocationToNorth = (byte)toNorthPoint.SelectedIndex;
        }
        private void toEastCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckAddressToEast = (ushort)toEastCheckAddress.Value;
        }
        private void toSouthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckAddressToSouth = (ushort)toSouthCheckAddress.Value;
        }
        private void toWestCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckAddressToWest = (ushort)toWestCheckAddress.Value;
        }
        private void toNorthCheckAddress_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckAddressToNorth = (ushort)toNorthCheckAddress.Value;
        }
        private void toEastCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckBitToEast = (byte)toEastCheckBit.Value;
        }
        private void toSouthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckBitToSouth = (byte)toSouthCheckBit.Value;
        }
        private void toWestCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckBitToWest = (byte)toWestCheckBit.Value;
        }
        private void toNorthCheckBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            location.CheckBitToNorth = (byte)toNorthCheckBit.Value;
        }
        private void enableEastPath_CheckedChanged(object sender, EventArgs e)
        {
            enableEastPath.ForeColor = enableEastPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            location.EnabledToEast = enableEastPath.Checked;
            toEastPoint.Enabled = enableEastPath.Checked;
            toEastCheckAddress.Enabled = enableEastPath.Checked;
            toEastCheckBit.Enabled = enableEastPath.Checked;
        }
        private void enableSouthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableSouthPath.ForeColor = enableSouthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            location.EnabledToSouth = enableSouthPath.Checked;
            toSouthPoint.Enabled = enableSouthPath.Checked;
            toSouthCheckAddress.Enabled = enableSouthPath.Checked;
            toSouthCheckBit.Enabled = enableSouthPath.Checked;
        }
        private void enableWestPath_CheckedChanged(object sender, EventArgs e)
        {
            enableWestPath.ForeColor = enableWestPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            location.EnabledToWest = enableWestPath.Checked;
            toWestPoint.Enabled = enableWestPath.Checked;
            toWestCheckAddress.Enabled = enableWestPath.Checked;
            toWestCheckBit.Enabled = enableWestPath.Checked;
        }
        private void enableNorthPath_CheckedChanged(object sender, EventArgs e)
        {
            enableNorthPath.ForeColor = enableNorthPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            location.EnabledToNorth = enableNorthPath.Checked;
            toNorthPoint.Enabled = enableNorthPath.Checked;
            toNorthCheckAddress.Enabled = enableNorthPath.Checked;
            toNorthCheckBit.Enabled = enableNorthPath.Checked;
        }

        #endregion
    }
}
