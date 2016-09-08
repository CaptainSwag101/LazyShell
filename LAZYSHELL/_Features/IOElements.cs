using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public partial class IOElements : Controls.NewForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        private IOMode ioMode;
        private object element;
        private int currentIndex;
        private string fullPath;
        private object[] args;

        #endregion

        // Constructor
        public IOElements(object element, IOMode ioMode, int currentIndex, string title, params object[] args)
        {
            this.element = element;
            this.ioMode = ioMode;
            this.currentIndex = currentIndex;
            this.Text = title;
            this.args = args;
            this.TopLevel = true;
            //
            InitializeComponent();
        }

        #region Methods

        private void Export()
        {
            if (this.element is Areas.Area[])
            {
                this.Enabled = false;
                if (radioButtonCurrent.Checked)
                    Areas.Model.ExportArea(currentIndex, fullPath);
                else
                    Areas.Model.ExportAreas(fullPath);
            }
            else if (this.element is Battlefields.Battlefield[])
            {
                if (radioButtonCurrent.Checked)
                    Battlefields.Model.ExportBattlefield(currentIndex, fullPath);
                else
                    Battlefields.Model.ExportBattlefields(fullPath);
            }
            else if (this.element is Audio.BRRSample[])
            {
                if (this.Text == "EXPORT SAMPLE BRRs...")
                {
                    if (radioButtonCurrent.Checked)
                        Audio.Model.ExportBRRSample(fullPath, currentIndex);
                    else
                        Audio.Model.ExportBRRSamples(fullPath);
                }
                else if (this.Text == "EXPORT SAMPLE WAVs...")
                {
                    if (radioButtonCurrent.Checked)
                        Audio.Model.ExportWAVSample(fullPath, currentIndex, (int)args[0]);
                    else
                        Audio.Model.ExportWAVSamples(fullPath, (int)args[0]);
                }
            }
            else if (this.element is Audio.SPCTrack[])
            {
                if (radioButtonCurrent.Checked)
                    Audio.Model.ExportSPC(textBoxCurrent.Text, currentIndex);
                else
                    Audio.Model.ExportSPCs(fullPath);
            }
            else
            {
                try
                {
                    string name = this.Text.ToLower().Substring(7, this.Text.Length - 7 - 4);
                    if (this.Text.Substring(0, 6) == "EXPORT")
                    {
                        Element[] array = element as Element[];
                        if (radioButtonCurrent.Checked)
                            Do.Export(array[currentIndex], null, textBoxCurrent.Text);
                        else
                            Do.Export(array,
                                fullPath + "\\" + Model.GetFileNameWithoutPath() + " - " +
                                Lists.ToTitleCase(name) + "s" + "\\" + name,
                                name.ToUpper(), true);
                    }
                }
                catch { }
            }
        }
        private bool Import()
        {
            bool success = true;
            if (this.element is Areas.Area[])
            {
                this.Enabled = false;
                if (radioButtonCurrent.Checked)
                    success = Areas.Model.ImportArea(currentIndex, fullPath);
                else
                    success = Areas.Model.ImportAreas(fullPath);
            }
            else if (this.element is Battlefields.Battlefield[])
            {
                var battlefields = Battlefields.Model.Battlefields;
                if (radioButtonCurrent.Checked)
                    success = Battlefields.Model.ImportBattlefield(currentIndex, fullPath);
                else
                    success = Battlefields.Model.ImportBattlefields(fullPath);
            }
            else if (this.element is Audio.BRRSample[])
            {
                if (this.Text == "IMPORT SAMPLE BRRs...")
                {
                    if (radioButtonCurrent.Checked)
                        success = Audio.Model.ImportBRRSample(currentIndex, fullPath);
                    else
                        success = Audio.Model.ImportBRRSamples(fullPath);
                }
                else if (this.Text == "IMPORT SAMPLE WAVs...")
                {
                    if (radioButtonCurrent.Checked)
                        success = Audio.Model.ImportWAVSample(currentIndex, fullPath);
                    else
                        success = Audio.Model.ImportWAVSamples(fullPath);
                }
            }
            else if (this.element is Audio.SPCTrack[])
            {
                if (radioButtonCurrent.Checked)
                    success = Audio.Model.ImportSPC(currentIndex, fullPath);
                else
                    success = Audio.Model.ImportSPCs(fullPath);
            }
            else
            {
                try
                {
                    Element[] array = element as Element[];
                    string name = this.Text.ToLower().Substring(7, this.Text.Length - 7 - 4);
                    if (radioButtonCurrent.Checked)
                    {
                        try
                        {
                            array[currentIndex] = Do.Import(array[currentIndex], fullPath) as Element;
                        }
                        catch
                        {
                            MessageBox.Show("Incorrect data file type.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                        array[currentIndex].Index = currentIndex;
                    }
                    else
                    {
                        try
                        {
                            Do.Import(array, fullPath + "\\" + name, name.ToUpper(), true);
                        }
                        catch
                        {
                            MessageBox.Show("One or more files incorrect data file type.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                        for (int i = 0; i < array.Length; i++)
                            array[i].Index = i;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return success;
        }

        #endregion

        #region Event Handlers

        // Current / All
        private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
        {
            browseAll.Enabled = false;
            textBoxAll.Enabled = false;
            browseCurrent.Enabled = true;
            textBoxCurrent.Enabled = true;
            if (radioButtonCurrent.Checked)
            {
                buttonOK.Enabled = textBoxCurrent.Text != "";
            }
            fullPath = textBoxCurrent.Text;
        }
        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            browseCurrent.Enabled = false;
            textBoxCurrent.Enabled = false;
            browseAll.Enabled = true;
            textBoxAll.Enabled = true;
            buttonOK.Enabled = true;
            if (radioButtonAll.Checked)
            {
                buttonOK.Enabled = textBoxAll.Text != "";
            }
            fullPath = textBoxAll.Text;
        }

        // Browsing
        private void browseCurrent_Click(object sender, EventArgs e)
        {
            string ext = ".dat";
            string filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            if (element is Audio.BRRSample[])
            {
                if (this.Text.Contains("SAMPLE WAVs"))
                {
                    ext = ".wav";
                    filter = "WAV files (*.wav)|*.wav|All files (*.*)|*.*";
                }
                else if (this.Text.Contains("SAMPLE BRRs"))
                {
                    ext = ".brr";
                    filter = "BRR files (*.brr)|*.brr|All files (*.*)|*.*";
                }
            }
            if (this.ioMode == IOMode.Export)
            {
                string name = this.element.GetType().Name;
                name = name.Trim(new char[] { '[', ']' });
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select directory to export to";
                saveFileDialog.Filter = filter;
                try
                {
                    saveFileDialog.FileName = name + "-" + currentIndex.ToString(
                        "d" + (element as object[]).Length.ToString().Length) + ext;
                }
                catch
                {
                    saveFileDialog.FileName = name + "-" + currentIndex.ToString("d4") + ext;
                }
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxCurrent.Text = saveFileDialog.FileName;
            }
            else if (this.ioMode == IOMode.Import)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = settings.LastRomPath;
                openFileDialog.Title = "Select file to import from";
                openFileDialog.Filter = filter;
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxCurrent.Text = openFileDialog.FileName;
            }
            fullPath = textBoxCurrent.Text;
            buttonOK.Enabled = true;
        }
        private void browseAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = settings.LastDirectory;
            if (this.Text.Substring(0, 6) == "EXPORT")
                folderBrowserDialog.Description = "Select directory to export to";
            else
                folderBrowserDialog.Description = "Select directory to import from";
            // Display the openFile dialog.
            var result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            settings.LastDirectory = folderBrowserDialog.SelectedPath;
            textBoxAll.Text = folderBrowserDialog.SelectedPath;
            fullPath = textBoxAll.Text;
            buttonOK.Enabled = true;
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.ioMode == IOMode.Export)
                Export();
            else if (this.ioMode == IOMode.Import)
            {
                if (!Import())
                    return;
            }
            this.Tag = radioButtonAll.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
