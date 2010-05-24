using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using SMRPGED.Properties;

namespace SMRPGED
{
    public partial class Form1 : Form, IMRUClient
    {
        #region Variables

        private ProgramController AppControl;
        //private Notes notes;
        private Settings settings;
        private bool cancelAnotherLoad;

        // MRU List manager
        private MRUManager mruManager;      // MRU list manager
        private string initialDirectory;    // Initial directory for Save/Load operations
        const string registryPath = "SOFTWARE\\SMRPGED\\LazyShell";  // Registry path to keep persistent data
        [DllImport("advapi32.dll", EntryPoint = "RegDeleteKey")]
        public static extern int RegDeleteKeyA(int hKey, string lpSubKey);

        bool invalidExe = false;
        //SMRPGED.Encryption.VerifyBeta vBeta;

        private ImportElements importElements;

        #endregion

        public Form1(ProgramController controls)
        {
            this.AppControl = controls;
            //notes = Notes.Instance;
            settings = Settings.Default;

            InitializeComponent();

            LoadInitialSettings();

            // MRU
            LoadSettingsFromRegistry();
            mruManager = new MRUManager();
            mruManager.Initialize(this, recentFilesToolStripMenuItem, registryPath);

            if (settings.LoadLastUsedROM)
            {
                try
                {
                    Open((string)mruManager.MRUList[0]);
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: " + e.Message, "LAZY SHELL");
                }
            }
        }

        #region Methods

        public static void GuiMain(ProgramController AppControl)
        {
            // Start the application.
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(AppControl));
        }

        // Loading
        private void LoadInitialSettings()
        {
            this.loadLastUsedROMToolStripMenuItem.Checked = settings.LoadLastUsedROM;

            this.undoStackSizeTextBox.Text = this.settings.UndoStackSize.ToString();
            this.serverToolStripTextBox1.Text = this.settings.patchServerURL;
            this.ignoreInvalidRomWarningToolStripMenuItem.Checked = this.settings.UnverifiedRomWarning;
            this.showEncryptionWarningsToolStripMenuItem.Checked = settings.ShowEncryptionWarnings;

            if (settings.VisualThemeSystem)
            {
                systemToolStripMenuItem.Checked = true;
                standardToolStripMenuItem.Checked = false;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            }
            else
            {
                standardToolStripMenuItem.Checked = true;
                systemToolStripMenuItem.Checked = false;
                Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            }
        }
        private void Open(string filename)
        {
            if (AppControl.AssembleAndCloseWindows())
            {
                MessageBox.Show("All of the editor's windows must be closed before loading a new ROM.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool ret;

            if (filename == null) // Load the rom
                ret = AppControl.OpenRomFile();
            else
                ret = AppControl.OpenRomFile(filename);

            if (ret && !AppControl.Locked()) // Verify it is a SMRPG rom of the correct version
            {
                if (AppControl.GameCode() != "ARWE")
                {
                    MessageBox.Show("The game code for this ROM is invalid. There would likely be problems editing the ROM.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!AppControl.HeaderPresent()) // If the rom does not have a header, we enable all the buttons
                {
                    this.openStats.Enabled = true;
                    this.openSprites.Enabled = true;
                    this.openLevels.Enabled = true;
                    this.openScripts.Enabled = true;
                    this.openPatches.Enabled = true;
                    this.openNotes.Enabled = true;
                    this.removeHeader.Enabled = false;
                    this.removeHeader.Visible = false;
                    this.saveToolStripMenuItem.Enabled = true;
                    this.saveAsToolStripMenuItem.Enabled = true;
                    this.restoreElementsToolStripMenuItem.Enabled = true;
                    this.publishRomToolStripMenuItem.Enabled = true;
                    this.viewRomSignatureToolStripMenuItem.Enabled = true;

                    AppControl.CreateNewMd5Checksum(); // Create a new checksum for a new rom
                }
                else if (AppControl.HeaderPresent()) // If the rom does have a header, we disable all the buttons and enable the Remove Header buttons
                {
                    this.openStats.Enabled = false;
                    this.openSprites.Enabled = false;
                    this.openLevels.Enabled = false;
                    this.openScripts.Enabled = false;
                    this.openPatches.Enabled = false;
                    this.openNotes.Enabled = false;

                    this.removeHeader.Enabled = true;
                    this.removeHeader.BackColor = Color.LightPink;
                    this.removeHeader.Visible = true;

                }

                UpdateRomInfo();
                LoadInitialSettings();
                AppControl.ClearLevelData();
                LoadNotes();

            }
            else if (ret)
            {
                if (AppControl.Locked())
                {
                    this.saveToolStripMenuItem.Enabled = true;
                    this.saveAsToolStripMenuItem.Enabled = true;
                    this.restoreElementsToolStripMenuItem.Enabled = true;
                    this.publishRomToolStripMenuItem.Enabled = true;
                    this.viewRomSignatureToolStripMenuItem.Enabled = true;

                    UpdateRomInfo();
                    LoadInitialSettings();
                    AppControl.ClearLevelData();
                    LoadNotes();
                }
                this.openStats.Enabled = false;
                this.removeHeader.Enabled = false;
                this.openSprites.Enabled = false;
                this.openLevels.Enabled = false;
                this.openScripts.Enabled = false;
                this.openPatches.Enabled = false;
                this.openNotes.Enabled = false;
                this.removeHeader.Visible = false;
            }
            if (ret)
                mruManager.Add(AppControl.GetPathWithoutFileName() + AppControl.GetFileNameWithoutPath());

        }
        public void UpdateRomInfo()
        {
            this.loadRomTextBox.Text = AppControl.GetFileNameWithoutPath();
            this.romInfo.Text = "ROM Path.........." + AppControl.GetPathWithoutFileName() +
                "\nROM Name.........." + AppControl.GetRomName() +
                "\nHeader............" + AppControl.HeaderPresent() +
                "\nChecksum.........." + AppControl.RomChecksum() +
                "\nGamecode.........." + AppControl.GameCode();
        }

        // Closing
        private void FinalizeAndSave(FormClosingEventArgs e, bool closingApp, int assembleFlag)
        {
            if (e == null)
                return;

            DialogResult result;

            if (AppControl.AssembleAndCloseWindows())
            {
                e.Cancel = true;
                return;
            }

            if (!AppControl.VerifyMD5Checksum())
            {
                if (assembleFlag == 1)
                    result = MessageBox.Show("There are changes to the rom that have not been saved. Would you like to save them now and quit?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                else
                    result = MessageBox.Show("There are changes to the rom that have not been saved. Would you like to save them now?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //if (notes.GetLoadNotes())
                    //    SaveNotes();
                    if (!AppControl.SaveRomFile())
                    {
                        MessageBox.Show("There was an error saving to : " + AppControl.GetFileName(), "LAZY SHELL");
                        return;
                    }
                }
                if (result == DialogResult.Cancel)
                {
                    if (closingApp)
                        e.Cancel = true;
                    cancelAnotherLoad = true;
                    AppControl.AssembleFinal(false);
                    return;
                }
                else cancelAnotherLoad = false;
            }

            if (closingApp)
            {
                this.Dispose();
                Application.Exit();
            }
        }

        // Beta
        public void BetaFailValidation()
        {
            invalidExe = true;
            //vBeta.Close();
        }

        // Notes
        private void LoadNotes()
        {
        }
        private void SaveNotes()
        {
        }
        private string GetDirectoryPath(string caption)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.SelectedPath = settings.LastDirectory;
            folderBrowserDialog1.Description = caption;

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.LastDirectory = folderBrowserDialog1.SelectedPath;
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return null;
        }

        // MRU list manager
        public void OpenMRUFile(string fileName)
        {
            try
            {
                Open(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: " + e.Message, "LAZY SHELL");
            }
        }
        private void LoadSettingsFromRegistry()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);

                initialDirectory = (string)key.GetValue(
                    "InitDir",                          // value name
                    Directory.GetCurrentDirectory());   // default value
            }
            catch
            {
                Trace.WriteLine("LoadSettingsFromRegistry failed");
            }
        }

        #endregion

        #region Event Handlers

        // Editor buttons
        private void openStats_Click(object sender, System.EventArgs e)
        {
            AppControl.StatsAndProperties();
        }
        private void openSprites_Click(object sender, System.EventArgs e)
        {
            AppControl.Sprites();
        }
        private void openLevels_Click(object sender, System.EventArgs e)
        {
            AppControl.Levels();
        }
        private void openScripts_Click(object sender, System.EventArgs e)
        {
            AppControl.Scripts();
        }
        private void openPatches_Click(object sender, EventArgs e)
        {
            AppControl.Patches();
        }

        // Main buttons
        private void loadRom_Click(object sender, System.EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
            {
                FinalizeAndSave(null, false, 0);
            }
            if (!cancelAnotherLoad)
                Open(null);
        }
        private void removeHeader_Click(object sender, System.EventArgs e)
        {
            if (AppControl.RemoveHeader())
            {
                // Enable all the editors
                this.openStats.Enabled = true;
                this.openSprites.Enabled = true;
                this.openLevels.Enabled = true;
                this.openScripts.Enabled = true;
                this.openPatches.Enabled = true;
                this.openNotes.Enabled = true;
                // Disable/hide the remove header button
                this.removeHeader.Enabled = false;
                this.removeHeader.Visible = false;

                AppControl.CreateNewMd5Checksum(); // Create a new checksum for a new rom
            }
        }

        // toolstripMenuItems : File
        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
            {
                FinalizeAndSave(null, false, 0);
            }
            if (!cancelAnotherLoad)
                Open(null);
        }
        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AppControl.SaveRomFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppControl.Assemble();
            if (AppControl.SaveRomFileAs())
                UpdateRomInfo();
            else
                MessageBox.Show("There was an error saving, try again", "LAZY SHELL");
        }
        private void publishRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppControl.Publish())
                UpdateRomInfo();
        }
        private void viewRomSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppControl.ViewSignature();
        }
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // toolstripmenuitems : Settings
        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.VisualThemeSystem = true;
            settings.Save();
            systemToolStripMenuItem.Checked = true;
            standardToolStripMenuItem.Checked = false;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
        }
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.VisualThemeSystem = false;
            settings.Save();
            systemToolStripMenuItem.Checked = false;
            standardToolStripMenuItem.Checked = true;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
        }
        private void undoStackSizeTextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                settings.UndoStackSize = System.Convert.ToInt32(this.undoStackSizeTextBox.Text, 10);
                settings.Save();
                AppControl.CreateNewLevelsCommandStack();
            }
            catch
            {

            }
        }
        private void serverToolStripTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            settings.patchServerURL = serverToolStripTextBox1.Text;
            settings.Save();
        }
        private void ignoreInvalidRomWarningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.UnverifiedRomWarning = ignoreInvalidRomWarningToolStripMenuItem.Checked;
            settings.Save();
        }
        private void showEncryptionWarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.ShowEncryptionWarnings = this.showEncryptionWarningsToolStripMenuItem.Checked;
            settings.Save();
        }

        // toolStripMenuitems : Help
        private void helpToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            string path = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\') + 1) + "helpTopics\\index.html";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("ERROR: Could not load the index help file. Try unzipping the program's files again.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }

        // other
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            FinalizeAndSave(e, true, 1);
            Settings.Default.Save();
        }

        #endregion

        private void loadLastUsedROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.LoadLastUsedROM = loadLastUsedROMToolStripMenuItem.Checked;
            settings.Save();
        }

        private void restoreElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importElements = new ImportElements(AppControl.Model);
            importElements.Show();
        }

        BaseConvertor baseConvertor;
        private void baseConvertorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseConvertor = new BaseConvertor();
            baseConvertor.Show();
        }

        private void resetSettingsToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to reset the application's settings. You will lose all custom settings such as\n" +
                "level name labels, event script labels, and the last used ROM path.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                settings.Reset();
        }

        private void saveCurrentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.Save();
        }

        private void openNotes_Click(object sender, EventArgs e)
        {
            AppControl.Notes();
        }
    }
}