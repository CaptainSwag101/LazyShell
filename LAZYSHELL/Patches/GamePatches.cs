using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading;
using LazyShell.Properties;

namespace LazyShell.Patches
{
    public partial class PatchesForm : Controls.NewForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        private string verifyType = "LazyShell PATCH INFORMATION";
        private WebClient client = new WebClient();
        private WebClient IPSClient = new WebClient();
        private ArrayList patches = new ArrayList();
        private bool downloadingIPS = false;
        private float red, green, blue;
        private bool colorDirection = true; // darker

        #endregion

        // Constructor
        public PatchesForm()
        {
            InitializeComponent();
        }

        #region Methods

        public void StartDownloadingPatches()
        {
            this.Update();
            this.downloadingLabel.Text = "Downloading information...";
            clock.RunWorkerAsync();
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            IPSClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(IPSClient_DownloadDataCompleted);
            DownloadPatchInfo(1);
            clock.CancelAsync();
        }
        private void DownloadPatchInfo(int pn)
        {
            try
            {
                Uri link = new Uri(settings.PatchServerURL + "patch" + pn.ToString() + "/patch" + pn.ToString() + ".bin");
                WebRequest.DefaultWebProxy = null;
                client.DownloadDataAsync(link);
            }
            catch
            {
                listBox.Items.Add("(no patches available)");
            }
        }
        private void AddNewDownload(byte[] data)
        {
            Patch patch = new Patch(patches.Count + 1, data);
            patches.Add(patch);
            listBox.Items.Add((patch.PatchName));
            if (listBox.SelectedIndex == -1)
                listBox.SelectedIndex = 0;
            if (patches.Count == 1)
                DisplayPatchInfo();
        }
        private void DisplayPatchInfo()
        {
            try
            {
                var patch = (Patch)patches[listBox.SelectedIndex];
                labelName.Text = "Name: " + patch.PatchName;
                labelAuthor.Text = "Author: " + patch.Author;
                labelDate.Text = "Date: " + patch.CreationDate;
                labelSize.Text = "Size: " + patch.Size;
                textBox1.Text = patch.Description;
                if (patch.Extra != "")
                    textBox1.Text += "\n\n" + patch.Extra;
                linkLabel1.Text = patch.PatchURI.ToString();
                assemblyHack.Checked = patch.AssemblyHack;
                gameHack.Checked = patch.GameHack;
                freshROM.Checked = patch.FreshRom;
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
            this.downloadingLabel.Text = "...DOWNLOADING PATCH...";
            this.downloadingLabel.Visible = true;
            clock.RunWorkerAsync();
            this.applyButton.Text = "CANCEL PATCH";
            IPSClient.DownloadDataAsync(((Patch)patches[listBox.SelectedIndex]).PatchURI);
        }
        private void StopIPSDownload()
        {
            downloadingIPS = false;
            clock.CancelAsync();
            this.downloadingLabel.Visible = false;
            this.applyButton.Text = "APPLY PATCH";
            IPSClient.CancelAsync();
        }

        #endregion

        #region Event Handlers

        // GamePatches
        private void GamePatches_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clock.IsBusy)
                clock.CancelAsync();
        }

        // Downloading
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
                DownloadPatchInfo(patches.Count + 1);
                this.applyButton.Enabled = true;
                panelPatch.BringToFront();
            }
            catch
            {
                clock.CancelAsync();
                this.downloadingLabel.Visible = false;
                return;
            }
        }
        private void IPSClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                clock.CancelAsync();
                this.downloadingLabel.Visible = false;
                this.applyButton.Text = "APPLY PATCH";
                if (!downloadingIPS)
                    return;
                downloadingIPS = false;
                var ips = new IPSPatch(e.Result);
                if (ips.Verified)
                {
                    var result = MessageBox.Show(
                        "Apply this patch to the currently open ROM image?\n\n" +
                        "Note: This will modify the current rom image, and cannot be undone. " +
                        "You may want to save the patched ROM image to disk once done.",
                        "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (ips.ApplyToROM(Model.ROM))
                        {
                            // Needed to reset state for new rom image
                            Model.ClearAll();
                            State.Instance.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                            State.Instance2.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
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
        private void clock_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!clock.CancellationPending)
            {
                Thread.Sleep(1000 / 30);
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
                clock.ReportProgress(0);
            }
        }
        private void clock_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.downloadingLabel.BackColor = Color.FromArgb((int)red, (int)green, (int)blue);
        }
        private void clock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        // Patch collection
        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DisplayPatchInfo();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        // Buttons
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (!downloadingIPS)
                StartIPSDownload();
            else
                StopIPSDownload();
        }

        #endregion
    }
}