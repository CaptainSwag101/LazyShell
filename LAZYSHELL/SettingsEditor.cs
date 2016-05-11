using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class SettingsEditor : Controls.NewForm
    {
        // Variables
        private Settings settings;

        // Constructor
        public SettingsEditor()
        {
            InitializeComponent();
            InitializeVariables();
            LoadSettings();
        }

        #region Methods

        private void InitializeVariables()
        {
            settings = Settings.Default;
        }
        private void LoadSettings()
        {
            checkedListBox1.SetItemChecked(0, settings.LoadLastUsedROM);
            checkedListBox1.SetItemChecked(1, settings.LoadAllData);
            checkedListBox1.SetItemChecked(2, settings.LoadProject);
            checkedListBox1.SetItemChecked(3, settings.CreateBackupROMSave);
            checkedListBox1.SetItemChecked(4, settings.CreateBackupROM);
            checkedListBox1.SetItemChecked(5, settings.UnverifiedRomWarning);
            checkedListBox1.SetItemChecked(6, settings.ShowEncryptionWarnings);
            checkedListBox1.SetItemChecked(7, settings.RememberLastIndex);
            if (settings.BackupROMDirectory == "")
            {
                romDirectory.Checked = true;
                customDirectory.Checked = false;
            }
            else
            {
                romDirectory.Checked = false;
                customDirectory.Checked = true;
                customDirectoryTextBox.Text = settings.BackupROMDirectory;
            }

            if (visualThemeSystem.Checked)
            {
	            settings.VisualTheme = 0;
                visualThemeSystem.Checked = true;
                visualThemeSimple.Checked = false;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            }
            else
            {
				settings.VisualTheme = 1;
				visualThemeSystem.Checked = false;
                visualThemeSimple.Checked = true;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            }
           
            this.patchHTTPServer.Text = this.settings.PatchServerURL;
        }

        #endregion

        #region Event Handlers

        private void buttonCustomDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Application.StartupPath;
            folderBrowserDialog.Description = "Select directory to save backup ROMs to...";
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            customDirectoryTextBox.Text = folderBrowserDialog.SelectedPath + "\\";
        }
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "You are about to reset the application's settings. You will lose all custom settings.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                settings.Reset();
            LoadSettings();
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            settings.LoadLastUsedROM = checkedListBox1.GetItemChecked(0);
            settings.LoadAllData = checkedListBox1.GetItemChecked(1);
            settings.LoadProject = checkedListBox1.GetItemChecked(2);
            settings.CreateBackupROMSave = checkedListBox1.GetItemChecked(3);
            settings.CreateBackupROM = checkedListBox1.GetItemChecked(4);
            settings.UnverifiedRomWarning = checkedListBox1.GetItemChecked(5);
            settings.ShowEncryptionWarnings = checkedListBox1.GetItemChecked(6);
            settings.RememberLastIndex = checkedListBox1.GetItemChecked(7);
            if (customDirectory.Checked)
                settings.BackupROMDirectory = customDirectoryTextBox.Text;
            else if (romDirectory.Checked)
                settings.BackupROMDirectory = "";
	        if (visualThemeSystem.Checked)
	        {
				settings.VisualTheme = 0;
			}
			else if (visualThemeSimple.Checked)
			{
				settings.VisualTheme = 1;
			}

            settings.PatchServerURL = patchHTTPServer.Text;
            settings.Save();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonApply.PerformClick();
            this.Close();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
