/*	Licensed under GNU AGPLv3
	
	LAZY SHELL, a Super Mario RPG Editor
    Copyright (C) 2009-2014  giangurgolo & Omega, (C) 2016 CaptainSwag101

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
	public partial class MainForm : Controls.NewForm, IMRUClient
	{
		#region Variables

		// AppControl
		private ProgramController AppControl;

		// Miscellaneous
		private Settings settings = Settings.Default;
		private bool cancelAnotherLoad;

		// MRU List manager
		private MRUManager mruManager;      // MRU list manager
		private string initialDirectory;    // Initial directory for Save/Load operations
		const string registryPath = "SOFTWARE\\LAZYSHELL\\LazyShell";  // Registry path to keep persistent data
		[DllImport("advapi32.dll", EntryPoint = "RegDeleteKey")]
		public static extern int RegDeleteKeyA(int hKey, string lpSubKey);

		// Forms
		private Restore restore;
		public Panel PanelForms
		{
			get { return panel2; }
			set { panel2 = value; }
		}

		#endregion

		// Constructor
		public MainForm(ProgramController controls)
		{
			this.AppControl = controls;
			//
			InitializeComponent();
			InitializeControls();
			CreateShortcuts();
			LoadSettingsFromRegistry();
			InitializeMRUManager();
			// Create backup list collections BEFORE loading project
			Model.CreateListCollections();
			LoadProjectFile();
			//
			if (!settings.FirstLoad)
				Help.CreateHelp(Model.LAZYSHELL_xml, true);
			settings.FirstLoad = true;

			switch (settings.VisualTheme)
			{
				case 0:
					Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
					Do.UseSystemTheme();
					break;
				case 1:
					Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
					Do.UseSimpleTheme();
					break;
				case 2:
					Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
					Do.UseBlueTheme();
					break;
			}
			//
			this.History = new History(this);
		}

		#region Methods

		// GuiMain
		public static void GuiMain(ProgramController AppControl)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(AppControl));
		}

		// Initialization
		private void InitializeControls()
		{
			loadRomTextBox.Width = toolStrip1.Width - 108;
		}
		private void InitializeMRUManager()
		{
			// MRU
			mruManager = new MRUManager();
			mruManager.Initialize(this, recentFiles, registryPath);
			//
			if (settings.LoadLastUsedROM && mruManager.MRUList.Count > 0)
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
		}
		private void CreateShortcuts()
		{
			Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(saveROM_Click));
		}
		private void LoadProjectFile()
		{
			if (settings.LoadProject && settings.ProjectPathCustom != "")
			{
				try
				{
					OpenProject(settings.ProjectPathCustom);
				}
				catch (Exception e)
				{
					MessageBox.Show("Could not load most recently used project database.\n\n" + e.Message,
						"LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void LoadWebpage()
		{
			XmlDocument LAZYSHELL_help = Model.LAZYSHELL_xml;
			XmlNodeList nodes = LAZYSHELL_help.SelectNodes("//section");
			string documentText = "<html><head><style>";
			documentText += Resources.LAZYSHELL_css;
			documentText += "</style></head>";
			documentText += "<body>";
			foreach (XmlNode node in nodes)
			{
				XmlNode header = node.SelectSingleNode(".//header");
				documentText += "<h1 class=\"subwindow\">" + header.InnerText + "</h1>";
				documentText += "<div class=\"subwindow\">";
				documentText += "<p class=\"subwindow\">";
				XmlNode body = node.SelectSingleNode(".//body");
				documentText += body.InnerText.Replace("\r\n", "<br/>");
				documentText += "</p></div>";
			}
			documentText += "<br/></body></html>";
		}

		// Opening ROM
		private void Open(string filename)
		{
			if (AppControl.WriteToROMAndCloseWindows())
			{
				MessageBox.Show("All of the editor's windows must be closed before loading a new ROM.",
					"LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
					if (MessageBox.Show("The game code for this ROM is invalid. There will likely be problems editing the ROM.\n\nLoad anyways?",
						"LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						return;
				}
				toolStrip2.Enabled = true;
				foreach (ToolStripItem item in toolStrip4.Items)
					if (item != recentFiles && item != openSettings)
						item.Enabled = true;
				this.saveROM.Enabled = true;
				this.saveROMAs.Enabled = true;
				this.restoreElements.Enabled = true;
				AppControl.CreateNewMd5Checksum(); // Create a new checksum for a new rom
				UpdateRomInfo();
			}
			else if (ret)
			{
				if (AppControl.Locked())
				{
					this.saveROM.Enabled = true;
					this.saveROMAs.Enabled = true;
					this.restoreElements.Enabled = true;
					UpdateRomInfo();
				}
				toolStrip2.Enabled = false;
				foreach (ToolStripItem item in toolStrip4.Items)
					if (item != recentFiles && item != openSettings)
						item.Enabled = false;
			}
			if (ret)
			{
				mruManager.Add(AppControl.GetPathWithoutFileName() + AppControl.GetFileNameWithoutPath());
				settings.Save();
			}
			if (toolStrip2.Enabled && settings.LoadAllData)
				AppControl.LoadAll();
		}
		private void OpenProject(string filename)
		{
			if (!File.Exists(filename))
			{
				MessageBox.Show("Error loading last used database. The file has been moved, renamed, or no longer exists.",
					"LAZY SHELL");
				return;
			}
			Stream s = File.OpenRead(filename);
			BinaryFormatter b = new BinaryFormatter();
			Model.Project = (ProjectDB)b.Deserialize(s);
			Model.RefreshListCollections();
			s.Close();
		}
		private void CloseROM()
		{
			if (AppControl.WriteToROMAndCloseWindows())
				return;
			AppControl.CloseRomFile();
			toolStrip2.Enabled = false;
			foreach (ToolStripItem item in toolStrip4.Items)
				if (item != recentFiles && item != openSettings && item != info)
					item.Enabled = false;
			this.loadRomTextBox.Text = "";
			this.romInfo.Text = "";
		}
		public void UpdateRomInfo()
		{
			this.loadRomTextBox.Text = Model.FileName;
			this.romInfo.Text =
				AppControl.GetRomName() + "\n" +
				AppControl.HeaderPresent() + "\n" +
				AppControl.RomChecksum() + "\n" +
				AppControl.GameCode();
		}

		// Closing ROM
		private void FinalizeAndSave(FormClosingEventArgs e, int assembleFlag)
		{
			DialogResult result;
			if (e != null && AppControl.WriteToROMAndCloseWindows())
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
							"There was an error saving to \"" + Model.FileName + "\"",
							"LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				if (result == DialogResult.Cancel)
				{
					if (e != null)
						e.Cancel = true;
					cancelAnotherLoad = true;
					AppControl.WriteToROM();
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

		// MainForm
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Model.Crashing)
				return;
			FinalizeAndSave(e, 1);
			settings.Save();
		}

		// Main buttons
		private void loadRom_Click(object sender, System.EventArgs e)
		{
			if (saveROM.Enabled)
				FinalizeAndSave(null, 0);
			if (!cancelAnotherLoad)
				Open(null);
		}
		private void toolStrip1_SizeChanged(object sender, EventArgs e)
		{
			loadRomTextBox.Width = toolStrip1.Width - 108;
		}

		// ToolStrip : File
		private void refreshROM_Click(object sender, EventArgs e)
		{
			if (saveROM.Enabled)
				FinalizeAndSave(null, 0);
			if (!cancelAnotherLoad)
				Open(loadRomTextBox.Text);
		}
		private void closeROM_Click(object sender, EventArgs e)
		{
			if (saveROM.Enabled)
				FinalizeAndSave(null, 0);
			if (!cancelAnotherLoad)
				CloseROM();
		}
		private void showROMInfo_Click(object sender, EventArgs e)
		{
			panel4.Visible = showROMInfo.Checked;
		}
		private void saveROM_Click(object sender, System.EventArgs e)
		{
			// Check if read only, if it is do a "Save As" routine
			FileInfo file = new FileInfo(Model.FileName);
			if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				saveROMAs.PerformClick();
				return;
			}
			// Check if currently in use by another application
			FileStream fs = null;
			try
			{
				fs = File.Open(Model.FileName, FileMode.Open);
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
		private void saveROMAs_Click(object sender, EventArgs e)
		{
			AppControl.WriteToROM();
			if (AppControl.SaveRomFileAs())
			{
				UpdateRomInfo();
				mruManager.Add(AppControl.GetPathWithoutFileName() + AppControl.GetFileNameWithoutPath());
				settings.Save();
			}
			else
				MessageBox.Show("Lazy Shell could not save the ROM.\n\nMake sure that the file is not currently in use by another appliaction.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void restoreElements_Click(object sender, EventArgs e)
		{
			if (AppControl.WriteToROMAndCloseWindows())
			{
				MessageBox.Show("All of the editor's windows must be closed before importing data from another ROM.", "LAZY SHELL");
				return;
			}
			restore = new Restore();
			restore.ShowDialog();
		}
		private void publishROM_Click(object sender, EventArgs e)
		{
			if (AppControl.Publish())
				UpdateRomInfo();
		}
		private void openSettings_Click(object sender, EventArgs e)
		{
			new SettingsEditor().ShowDialog();
		}

		// ToolStrip : Help
		private void openHistoryLog_Click(object sender, EventArgs e)
		{
			NewMessage.Show("EVENT HISTORY - Lazy Shell",
				"This is a list of past actions performed by the user exclusively within the Lazy Shell application. " +
				"This is to be used for debugging purposes, chiefly for reproducing bugs and other defects encountered by the user.",
				Model.History, 600, 600, true);
		}
		private void openHexEditor_Click(object sender, EventArgs e)
		{
			AppControl.HexEditor();
			Model.HexEditor.Show();
			Model.HexEditor.BringToFront();
		}
		private void help_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(
				"Open the help database as a navigable web page?\n\n" +
				"Selecting \"No\" will open the help file as a raw text file.",
				"LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (result == DialogResult.Cancel)
				return;
			XmlDocument LAZYSHELL_xml = Model.LAZYSHELL_xml;
			if (result == DialogResult.No)
			{
				Help.CreateHelp(LAZYSHELL_xml, false);
				return;
			}
			XmlNodeList icons = LAZYSHELL_xml.SelectNodes(".//*[@icon != '']");
			if (!Directory.Exists("help"))
				Directory.CreateDirectory("help");
			if (!Directory.Exists("help//icons"))
				Directory.CreateDirectory("help//icons");
			File.WriteAllText("help//LAZYSHELL_xml.xml", Resources.LAZYSHELL_xml);
			File.WriteAllText("help//LAZYSHELL_xsl.xsl", Resources.LAZYSHELL_xsl);
			File.WriteAllText("help//LAZYSHELL_css.css", Resources.LAZYSHELL_css);
			foreach (XmlNode icon in icons)
			{
				string path = icon.Attributes["icon"].Value;
				string file = Path.GetFileName(path);
				string name = Path.GetFileNameWithoutExtension(path);
				Bitmap image = (Bitmap)Resources.ResourceManager.GetObject(name);
				if (image == null)
					continue;
				image.Save("help//icons//" + file);
			}
			Process.Start("help\\LAZYSHELL_xml.xml");
		}
		private void about_Click(object sender, System.EventArgs e)
		{
			Form about = new About(this);
			about.ShowDialog(this);
		}

		// ToolStrip : Editors
		private void openAnimations_Click(object sender, EventArgs e)
		{
			AppControl.Animations();
		}
		private void openAreas_Click(object sender, System.EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.Areas();
		}
		private void openAttacks_Click(object sender, EventArgs e)
		{
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
			AppControl.EventScripts();
		}
		private void openFonts_Click(object sender, EventArgs e)
		{
			AppControl.Fonts();
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
		private void openLevelUps_Click(object sender, EventArgs e)
		{
			AppControl.LevelUps();
		}
		private void openMagic_Click(object sender, EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.Magic();
		}
		private void openMainTitle_Click(object sender, EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.MainTitle();
		}
		private void openMenus_Click(object sender, EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.Menus();
		}
		private void openMiniGames_Click(object sender, EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.MiniGames();
		}
		private void openMonsters_Click(object sender, EventArgs e)
		{
			if (!Comp.LunarCompressExists())
				return;
			AppControl.Monsters();
		}
		private void openNewGame_Click(object sender, EventArgs e)
		{
			AppControl.NewGame();
		}
		private void openShops_Click(object sender, EventArgs e)
		{
			AppControl.Shops();
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

		// ToolStrip : Other
		private void openPatches_Click(object sender, EventArgs e)
		{
			AppControl.Patches();
		}
		private void openProject_Click(object sender, EventArgs e)
		{
			AppControl.Project();
		}

		// Window management
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
			if (MessageBox.Show("You are about to open all 17 editor windows.\n\nAre you sure you want to do this?",
				"LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;
			AppControl.OpenAll();
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

		// Model management
		private void resetModel_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You are about to reset the editor's memory of all elements. Continue?",
				"LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;
			AppControl.ClearAll();
			AppControl.LoadAll();
		}
		private void clearModel_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You are about to clear the editor's memory of all elements. Continue?",
				"LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;
			AppControl.ClearAll();
		}

		#endregion

	}
}