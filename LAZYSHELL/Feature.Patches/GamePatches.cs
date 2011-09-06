using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Patches
{
    public partial class GamePatches : Form
    {
        private Settings settings = Settings.Default;
        private string verifyType = "LAZYSHELL PATCH INFORMATION";
        private WebClient client = new WebClient();
        private WebClient IPSClient = new WebClient();
        private ArrayList patches = new ArrayList();
        private Timer clock;
        private bool downloadingIPS = false;
        private float red, green, blue;
        private bool colorDirection = true; // darker
        // constructor
        public GamePatches()
        {
            InitializeComponent();
        }
        // functions
        public void StartDownloadingPatches()
        {
            this.Update();

            this.downloadingLabel.Text = "            ...DOWNLOADING...            ";
            clock = new Timer();
            clock.Interval = 1000 / 30;
            clock.Tick += new EventHandler(clock_Tick);
            clock.Start();

            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            IPSClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(IPSClient_DownloadDataCompleted);

            DownloadPatches(1);

            //clock.Stop();
            //this.downloadingLabel.Visible = false;
        }
        private void DownloadPatches(int pn)
        {
            try
            {
                Uri link = new Uri(settings.patchServerURL + "patch" + pn.ToString() + "/patch" + pn.ToString() + ".bin");
                WebRequest.DefaultWebProxy = null;
                client.DownloadDataAsync(link);
            }
            catch
            {
                PatchListBox.Items.Add("(no patches available)");
            }
        }
        private void AddNewDownload(byte[] data)
        {
            Patch patch = new Patch(patches.Count + 1, data);

            patches.Add(patch);
            PatchListBox.Items.Add((patch.PatchName));

            if (PatchListBox.SelectedIndex == -1)
                PatchListBox.SelectedIndex = 0;

            if (patches.Count == 1)
                DisplayPatchInfo();

        }
        private void DisplayPatchInfo()
        {
            try
            {
                Patch patch = (Patch)patches[PatchListBox.SelectedIndex];

                DescriptionTextBox.Text = "Name: " + patch.PatchName + "\r\n";
                DescriptionTextBox.Text += "Author: " + patch.Author + "\r\n";
                DescriptionTextBox.Text += "Date: " + patch.CreationDate + "\r\n";
                DescriptionTextBox.Text += "Size: " + patch.Size + "\r\n\r\n";
                DescriptionTextBox.Text += "Description:\r\n";
                DescriptionTextBox.Text += patch.Description + "\r\n\r\n";
                if (patch.Extra != "")
                    DescriptionTextBox.Text += patch.Extra + "\r\n\r\n";
                DescriptionTextBox.Text += "Direct Link:\r\n";
                DescriptionTextBox.Text += patch.PatchURI;
                AssemblyHackLabel.Visible = patch.AssemblyHack;
                GameHackLabel.Visible = patch.GameHack;
                FreshRomLabel.Visible = patch.FreshRom;
                ImagePictureBox.Image = new Bitmap(patch.PatchImage);
            }
            catch
            {
                return;
            }
        }
        private void StartIPSDownload()
        {
            downloadingIPS = true;
            this.downloadingLabel.Visible = true;
            clock.Start();

            this.applyButton.Text = "CANCEL PATCH";
            IPSClient.DownloadDataAsync(((Patch)patches[PatchListBox.SelectedIndex]).PatchURI);
        }
        private void StopIPSDownload()
        {
            downloadingIPS = false;
            clock.Stop();
            this.downloadingLabel.Visible = false;
            this.applyButton.Text = "APPLY PATCH";
            IPSClient.CancelAsync();
        }
        // event handlers
        private void clock_Tick(object sender, EventArgs e)
        {
            if (red > 185 || red < 89)
            {
                if (colorDirection)
                {
                    red = 89;
                    green = 99;
                    blue = 219;
                    colorDirection = false;
                }
                else
                {
                    red = 185;
                    green = 189;
                    blue = 240;
                    colorDirection = true;
                }
            }

            if (colorDirection) // get darker
            {
                red -= 96 / 30;
                green -= 90 / 30;
                blue -= 21 / 30;
            }
            else // Get Lighter
            {
                red += 96 / 30;
                green += 90 / 30;
                blue += 21 / 30;
            }

            this.downloadingLabel.BackColor = Color.FromArgb((int)red, (int)green, (int)blue);
        }
        private void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                char[] temp = verifyType.ToCharArray();
                for (int i = 0; i < 0x1B; i++)
                {
                    if (e.Result[i] != temp[i])
                        throw new Exception();
                }
                AddNewDownload(e.Result);
                DownloadPatches(patches.Count + 1);
            }
            catch
            {
                clock.Stop();
                this.downloadingLabel.Visible = false;
                return;
            }
        }
        private void PatchListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DisplayPatchInfo();
        }
        private void IPSClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                clock.Stop();
                this.downloadingLabel.Visible = false;
                this.applyButton.Text = "APPLY PATCH";

                if (!downloadingIPS)
                    return;
                downloadingIPS = false;

                IPSPatch ips = new IPSPatch(e.Result);

                if (ips.Verified)
                {
                    DialogResult result = MessageBox.Show(
                        "Apply this patch to the currently open ROM image?\n\n" +
                        "Note: This will modify the current rom image, and cannot be undone. " +
                        "You may want to save the patched ROM image to disk once done.",
                        "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (ips.ApplyTo(Model.Data))
                        {
                            // Needed to reset state for new rom image
                            Model.ClearModel();
                            State.Instance.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                            MessageBox.Show("Patch Applied Succesfully", "LAZY SHELL");
                        }
                        else
                            throw new Exception();
                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("There was an error downloading or applying the IPS patch. Please try to download and apply it manually with LunarIPS.", "LAZY SHELL");
                return;
            }
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (!downloadingIPS)
                StartIPSDownload();
            else
                StopIPSDownload();
        }
        private void DescriptionTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}