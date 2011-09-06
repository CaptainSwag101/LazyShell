﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class SettingsEditor : Form
    {
        private Settings settings = Settings.Default;
        // constructor
        public SettingsEditor()
        {
            InitializeComponent();
            InitializeSettings();
        }
        // functions
        private void InitializeSettings()
        {
            checkedListBox1.SetItemChecked(0, settings.LoadLastUsedROM);
            checkedListBox1.SetItemChecked(1, settings.LoadAllData);
            checkedListBox1.SetItemChecked(2, settings.LoadNotes);
            checkedListBox1.SetItemChecked(3, settings.CreateBackupROMSave);
            checkedListBox1.SetItemChecked(4, settings.CreateBackupROM);
            checkedListBox1.SetItemChecked(5, settings.UnverifiedRomWarning);
            checkedListBox1.SetItemChecked(6, settings.ShowEncryptionWarnings);
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
            if (settings.VisualThemeSystem)
            {
                visualThemeSystem.Checked = true;
                visualThemeStandard.Checked = false;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            }
            else
            {
                visualThemeSystem.Checked = false;
                visualThemeStandard.Checked = true;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            }
            this.undoStackSize.Value = this.settings.UndoStackSize;
            this.patchHTTPServer.Text = this.settings.patchServerURL;
        }
        // event handlers
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
            DialogResult result = MessageBox.Show(
                "You are about to reset the application's settings. You will lose all custom settings.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                settings.Reset();
            InitializeSettings();
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            settings.LoadLastUsedROM = checkedListBox1.GetItemChecked(0);
            settings.LoadAllData = checkedListBox1.GetItemChecked(1);
            settings.LoadNotes = checkedListBox1.GetItemChecked(2);
            settings.CreateBackupROMSave = checkedListBox1.GetItemChecked(3);
            settings.CreateBackupROM = checkedListBox1.GetItemChecked(4);
            settings.UnverifiedRomWarning = checkedListBox1.GetItemChecked(5);
            settings.ShowEncryptionWarnings = checkedListBox1.GetItemChecked(6);
            if (customDirectory.Checked)
                settings.BackupROMDirectory = customDirectoryTextBox.Text;
            else if (romDirectory.Checked)
                settings.BackupROMDirectory = "";
            settings.VisualThemeSystem = visualThemeSystem.Checked;
            settings.UndoStackSize = (int)undoStackSize.Value;
            settings.patchServerURL = patchHTTPServer.Text;
            settings.Save();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonApply_Click(null, null);
            this.Close();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
