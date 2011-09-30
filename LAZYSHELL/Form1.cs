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
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Form1 : Form, IMRUClient
    {
        #region Variables

        private ProgramController AppControl;
        //private Notes notes;
        private Settings settings = Settings.Default;
        private bool cancelAnotherLoad;

        // MRU List manager
        private MRUManager mruManager;      // MRU list manager
        private string initialDirectory;    // Initial directory for Save/Load operations
        const string registryPath = "SOFTWARE\\LAZYSHELL\\LazyShell";  // Registry path to keep persistent data
        [DllImport("advapi32.dll", EntryPoint = "RegDeleteKey")]
        public static extern int RegDeleteKeyA(int hKey, string lpSubKey);

        private Restore importElements;
        public Panel Panel2 { get { return panel2; } set { panel2 = value; } }
        #endregion
        // Constructor
        public Form1(ProgramController controls)
        {
            this.AppControl = controls;
            //notes = Notes.Instance;

            InitializeComponent();
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(saveToolStripMenuItem_Click));
            loadRomTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // MRU
            LoadSettingsFromRegistry();
            mruManager = new MRUManager();
            mruManager.Initialize(this, recentFiles, registryPath);

            if (settings.LoadLastUsedROM)
            {
                try
                {
                    Open((string)mruManager.MRUList[0]);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not load most recently used ROM.\n\n" + e.Message,
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            new History(this);
            Do.AddHistory("LOADED LAZY SHELL APPLICATION");
        }
        #region Function
        public static void GuiMain(ProgramController AppControl)
        {
            // Start the application.
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(AppControl));
        }
        // Loading
        private void Open(string filename)
        {
            if (AppControl.AssembleAndCloseWindows())
            {
                MessageBox.Show("All of the editor's windows must be closed before loading a new ROM.", "LAZY SHELL");
                return;
            }
            else if (Model.HexViewer != null && Model.HexViewer.Visible)
                Model.HexViewer.Close();
            bool ret;

            if (filename == null) // Load the rom
                ret = AppControl.OpenRomFile();
            else
                ret = AppControl.OpenRomFile(filename);

            if (ret && !AppControl.Locked()) // Verify it is a SMRPG rom of the correct version
            {
                if (AppControl.GameCode() != "ARWE")
                {
                    MessageBox.Show("The game code for this ROM is invalid. There will likely be problems editing the ROM.", "LAZY SHELL");
                    return;
                }

                if (!AppControl.HeaderPresent()) // If the rom does not have a header, we enable all the buttons
                {
                    toolStrip2.Enabled = true;
                    toolStrip3.Enabled = true;
                    foreach (ToolStripItem item in toolStrip4.Items)
                        if (item != recentFiles && item != openSettings)
                            item.Enabled = true;
                    this.removeHeader.Enabled = false;
                    this.removeHeader.Visible = false;
                    this.saveToolStripMenuItem.Enabled = true;
                    this.saveAsToolStripMenuItem.Enabled = true;
                    this.restoreElementsToolStripMenuItem.Enabled = true;

                    AppControl.CreateNewMd5Checksum(); // Create a new checksum for a new rom
                }
                else if (AppControl.HeaderPresent()) // If the rom does have a header, we disable all the buttons and enable the Remove Header buttons
                {
                    toolStrip2.Enabled = false;
                    toolStrip3.Enabled = false;
                    foreach (ToolStripItem item in toolStrip4.Items)
                        if (item != recentFiles && item != openSettings)
                            item.Enabled = false;
                    this.removeHeader.Enabled = true;
                    this.removeHeader.Visible = true;
                    loadRomTextBox.Width = toolStrip1.Width - 95 - removeHeader.Width;
                }
                UpdateRomInfo();
            }
            else if (ret)
            {
                if (AppControl.Locked())
                {
                    this.saveToolStripMenuItem.Enabled = true;
                    this.saveAsToolStripMenuItem.Enabled = true;
                    this.restoreElementsToolStripMenuItem.Enabled = true;
                    UpdateRomInfo();
                }
                toolStrip2.Enabled = false;
                toolStrip3.Enabled = false;
                foreach (ToolStripItem item in toolStrip4.Items)
                    if (item != recentFiles && item != openSettings)
                        item.Enabled = false;
                this.removeHeader.Visible = false;
            }
            if (ret)
            {
                mruManager.Add(AppControl.GetPathWithoutFileName() + AppControl.GetFileNameWithoutPath());
                settings.Save();
            }
            if (toolStrip2.Enabled && settings.LoadAllData)
                AppControl.LoadAll();
        }
        private void CloseROM()
        {
            if (AppControl.AssembleAndCloseWindows())
                return;
            AppControl.CloseRomFile();
            toolStrip2.Enabled = false;
            toolStrip3.Enabled = false;
            foreach (ToolStripItem item in toolStrip4.Items)
                if (item != recentFiles && item != openSettings && item != toolStripButton5)
                    item.Enabled = false;
            this.removeHeader.Visible = false;
            this.loadRomTextBox.Text = "";
            this.romInfo.Text = "";
        }
        public void UpdateRomInfo()
        {
            this.loadRomTextBox.Text = AppControl.GetFileName();
            this.romInfo.Text =
                AppControl.GetRomName() + "\n" +
                AppControl.HeaderPresent() + "\n" +
                AppControl.RomChecksum() + "\n" +
                AppControl.GameCode();
        }
        // Closing
        private void FinalizeAndSave(FormClosingEventArgs e, int assembleFlag)
        {
            DialogResult result;
            if (e != null && AppControl.AssembleAndCloseWindows())
            {
                e.Cancel = true;
                return;
            }
            if (!AppControl.VerifyMD5Checksum())
            {
                result = MessageBox.Show(
                    "There are changes to the rom that have not been saved.\n\n" +
                    "Would you like to save them now" + (assembleFlag == 1 ? " and quit?" : "?"), "LAZY SHELL",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (!AppControl.SaveRomFile())
                    {
                        MessageBox.Show(
                            "There was an error saving to \"" + AppControl.GetFileName() + "\"",
                            "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (result == DialogResult.Cancel)
                {
                    if (e != null)
                        e.Cancel = true;
                    cancelAnotherLoad = true;
                    AppControl.Assemble();
                    return;
                }
                else cancelAnotherLoad = false;
            }
            if (e != null)
            {
                this.Dispose();
                Application.Exit();
            }
        }
        // Notes
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
                MessageBox.Show("Could not load most recently used ROM.\n\n" + e.Message,
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // Main buttons
        private void loadRom_Click(object sender, System.EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
                FinalizeAndSave(null, 0);
            if (!cancelAnotherLoad)
                Open(null);
        }
        private void removeHeader_Click(object sender, System.EventArgs e)
        {
            if (AppControl.RemoveHeader())
            {
                // Enable all the editors
                toolStrip2.Enabled = true;
                toolStrip3.Enabled = true;
                foreach (ToolStripItem item in toolStrip4.Items)
                    if (item != recentFiles)
                        item.Enabled = true;
                // Disable/hide the remove header button
                this.removeHeader.Enabled = false;
                this.removeHeader.Visible = false;

                AppControl.CreateNewMd5Checksum(); // Create a new checksum for a new rom
            }
        }
        private void toolStrip1_SizeChanged(object sender, EventArgs e)
        {
            if (!removeHeader.Visible)
                loadRomTextBox.Width = toolStrip1.Width - 95;
            else
                loadRomTextBox.Width = toolStrip1.Width - 95 - removeHeader.Width;
        }
        // toolstripMenuItems : File
        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
                FinalizeAndSave(null, 0);
            if (!cancelAnotherLoad)
                Open(null);
        }
        private void refreshROM_Click(object sender, EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
                FinalizeAndSave(null, 0);
            if (!cancelAnotherLoad)
                Open(loadRomTextBox.Text);
        }
        private void closeROM_Click(object sender, EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
                FinalizeAndSave(null, 0);
            if (!cancelAnotherLoad)
                CloseROM();
        }
        private void showROMInfo_Click(object sender, EventArgs e)
        {
            panel4.Visible = showROMInfo.Checked;
        }
        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // Check if read only, if it is do a "Save As" routine
            FileInfo file = new FileInfo(AppControl.GetFileName());
            if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                saveAsToolStripMenuItem_Click(null, null);
                return;
            }
            // Check if currently in use by another application
            FileStream fs = null;
            try
            {
                fs = File.Open(AppControl.GetFileName(), FileMode.Open);
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Lazy Shell could not save the ROM.\n\nThe file is currently in use by another application.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Now, save the file
            AppControl.SaveRomFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppControl.Assemble();
            if (AppControl.SaveRomFileAs())
                UpdateRomInfo();
            else
                MessageBox.Show("Lazy Shell could not save the ROM.\n\nMake sure that the file is not currently in use by another appliaction.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void restoreElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importElements = new Restore();
            importElements.ShowDialog();
        }
        private void publishRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppControl.Publish())
                UpdateRomInfo();
        }
        private void openSettings_Click(object sender, EventArgs e)
        {
            new SettingsEditor().ShowDialog();
        }
        // toolStripMenuitems : Help
        private void history_Click(object sender, EventArgs e)
        {
            NewMessage.Show("EVENT HISTORY - Lazy Shell",
                "This is a list of past actions performed by the user exclusively within the Lazy Shell application. " +
                "This is to be used for debugging purposes, chiefly for reproducing bugs and other defects encountered by the user.",
                Model.History, 600, 600, true);
        }
        private void hexViewer_Click(object sender, EventArgs e)
        {
            Model.HexViewer.Show();
            Model.HexViewer.BringToFront();
        }
        private void helpToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            string path = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\') + 1) + "helpTopics\\index.html";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Could not load the index help file. Try unzipping the program's files again.", "LAZY SHELL");
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }
        // other
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Do.AddHistory("CLOSED LAZY SHELL APPLICATION");
            FinalizeAndSave(e, 1);
            settings.Save();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        // Editor buttons
        private void openAllies_Click(object sender, EventArgs e)
        {
            AppControl.Allies();
        }
        private void openAnimations_Click(object sender, EventArgs e)
        {
            AppControl.Animations();
        }
        private void openAttacks_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Attacks();
        }
        private void openAudio_Click(object sender, EventArgs e)
        {
            AppControl.Audio();
        }
        private void openBattlefields_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Battlefields();
        }
        private void openDialogues_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Dialogues();
        }
        private void openEffects_Click(object sender, EventArgs e)
        {
            AppControl.Effects();
        }
        private void openEventScripts_Click(object sender, System.EventArgs e)
        {
            AppControl.Scripts();
        }
        private void openFormations_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Formations();
        }
        private void openItems_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Items();
        }
        private void openLevels_Click(object sender, System.EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Levels();
        }
        private void openMainTitle_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.MainTitle();
        }
        private void openMonsters_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.Monsters();
        }
        private void openSprites_Click(object sender, System.EventArgs e)
        {
            //Do.CompareImages();
            AppControl.Sprites();
        }
        private void openWorldMaps_Click(object sender, EventArgs e)
        {
            if (!Comp.LunarCompressExists())
                return;
            AppControl.WorldMaps();
        }
        private void openPatches_Click(object sender, EventArgs e)
        {
            AppControl.Patches();
        }
        private void openNotes_Click(object sender, EventArgs e)
        {
            AppControl.Notes();
        }
        // window editing
        private void docking_Click(object sender, EventArgs e)
        {
            AppControl.DockEditors = docking.Checked;
            if (docking.Checked)
                AppControl.Dock();
            else
                AppControl.Undock();
        }
        private void openAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to open all 15 editor windows.\n\nAre you sure you want to do this?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            openAllies_Click(null, null);
            openAnimations_Click(null, null);
            openAttacks_Click(null, null);
            openBattlefields_Click(null, null);
            //openBattleScripts_Click(null, null);
            openDialogues_Click(null, null);
            openEffects_Click(null, null);
            openEventScripts_Click(null, null);
            openFormations_Click(null, null);
            openItems_Click(null, null);
            openLevels_Click(null, null);
            openMainTitle_Click(null, null);
            openMonsters_Click(null, null);
            openSprites_Click(null, null);
            openWorldMaps_Click(null, null);
        }
        private void closeAll_Click(object sender, EventArgs e)
        {
            AppControl.CloseAll();
        }
        private void minimizeAll_Click(object sender, EventArgs e)
        {
            AppControl.MinimizeAll();
        }
        private void restoreAll_Click(object sender, EventArgs e)
        {
            AppControl.RestoreAll();
        }
        private void loadAllData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "You are about to reset the editor's memory of all elements. Continue?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            AppControl.ClearAll();
            AppControl.LoadAll();
        }
        private void clearModel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "You are about to clear the editor's memory of all elements. Continue?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            AppControl.ClearAll();
        }
        #endregion
    }
}