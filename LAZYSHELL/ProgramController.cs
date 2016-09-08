using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public class ProgramController
    {
        #region Variables

        private Program App;
        public bool DockEditors
        {
            get { return App.DockEditors; }
            set { App.DockEditors = value; }
        }

        #endregion

        // Constructor
        public ProgramController(Program app)
        {
            this.App = app;
        }

        #region Methods

        // Saving
        public void WriteToROM()
        {
            App.WriteToROM();
        }
        public bool WriteToROMAndCloseWindows()
        {
            return App.CloseAll();
        }

        #region File Managing

        public bool OpenRomFile()
        {
            if (App.OpenRomFile())
            {
                Model.ClearAll();
                State.Instance.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                State.Instance2.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                if (!VerifyRom())
                    return false;
                return true;
            }
            else
                return false;

        }
        public bool OpenRomFile(string filename)
        {
            if (App.OpenRomFile(filename))
            {
                Model.ClearAll();
                State.Instance.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                State.Instance2.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                if (!VerifyRom())
                    return false;
                return true;
            }
            else
                return false;
        }
        public bool SaveRomFile()
        {
            return App.SaveRomFile();
        }
        public bool SaveRomFileAs()
        {
            return App.SaveRomFileAs();
        }
        public void CloseRomFile()
        {
            Model.ClearAll();
            State.Instance.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
            State.Instance2.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
            App.CloseRomFile();
        }
        public bool VerifyRom()
        {
            return Model.VerifyRom();
        }
        public bool HeaderPresent()
        {
            return Model.HeaderPresent();
        }
        public string GetFileNameWithoutPath()
        {
            return Model.GetFileNameWithoutPath();
        }
        public string GetFileNameWithoutPathOrExtension()
        {
            return Model.GetFileNameWithoutPathOrExtension();
        }
        public string GetRomName()
        {
            return Model.GetRomName();
        }
        public string GetPathWithoutFileName()
        {
            return Model.GetPathWithoutFileName();
        }
        public string RomChecksum()
        {
            return Model.GetRomChecksum();
        }
        public string GameCode()
        {
            return Model.GameCode();
        }
        public long GetFileSize()
        {
            return Model.GetFileSize();
        }

        #endregion

        #region MD5 hash methods

        public void CreateNewMd5Checksum()
        {
            Model.CreateNewMD5Checksum();
        }
        public bool VerifyMD5Checksum()
        {
            return Model.VerifyMD5Checksum();
        }

        #endregion

        #region Author Stamp

        public bool Locked()
        {
            return Model.Locked;
        }
        public bool Publish()
        {
            // Ask to save rom
            if (MessageBox.Show("Publishing a ROM requires saving. Save and publish this rom now?",
                "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return App.SaveRomFileAs(); // Save
            return false;
        }

        #endregion

        #region Create Editor Windows

        public void Animations()
        {
            App.CreateAnimationsWindow();
        }
        public void Areas()
        {
            App.CreateAreasWindow();
        }
        public void Attacks()
        {
            App.CreateAttacksWindow();
        }
        public void Audio()
        {
            App.CreateAudioWindow();
        }
        public void Battlefields()
        {
            App.CreateBattlefieldsWindow();
        }
        public void Dialogues()
        {
            App.CreateDialoguesWindow();
        }
        public void Effects()
        {
            App.CreateEffectsWindow();
        }
        public void EventScripts()
        {
            App.CreateEventScriptsWindow();
        }
        public void Formations()
        {
            App.CreateFormationsWindow();
        }
        public void Fonts()
        {
            App.CreateFontsWindow();
        }
        public void Items()
        {
            App.CreateItemsWindow();
        }
        public void LevelUps()
        {
            App.CreateLevelUpsWindow();
        }
        public void Magic()
        {
            App.CreateMagicWindow();
        }
        public void MainTitle()
        {
            App.CreateIntroWindow();
        }
        public void Menus()
        {
            App.CreateMenusWindow();
        }
        public void MiniGames()
        {
            App.CreateMinecartWindow();
        }
        public void Monsters()
        {
            App.CreateMonstersWindow();
        }
        public void NewGame()
        {
            App.CreateNewGameWindow();
        }
        public void Shops()
        {
            App.CreateShopsWindow();
        }
        public void Sprites()
        {
            App.CreateSpritesWindow();
        }
        public void WorldMaps()
        {
            App.CreateWorldMapsWindow();
        }
        public void Patches()
        {
            App.CreatePatchesWindow();
        }
        public void Project()
        {
            App.CreateProjectWindow();
        }
        public void HexEditor()
        {
            App.CreateHexEditor();
        }

        #endregion

        #region Window management

        public void Dock()
        {
            App.Dock();
        }
        public void Undock()
        {
            App.Undock();
        }
        public void OpenAll()
        {
            App.OpenAll();
        }
        public void MinimizeAll()
        {
            App.MinimizeAll();
        }
        public void RestoreAll()
        {
            App.RestoreAll();
        }
        public void CloseAll(bool force = false)
        {
            App.CloseAll(force);
        }

        #endregion

        #region Data management

        public void LoadAll()
        {
            App.LoadAll();
        }
        public void ClearAll()
        {
            App.ClearAll();
        }

        #endregion

        #endregion
    }
}
