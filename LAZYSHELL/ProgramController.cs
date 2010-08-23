using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;//remove later

namespace LAZYSHELL
{
    public class ProgramController
    {
        private Program App;
        private Model model = State.Instance.Model;
        private State state = State.Instance;
        public Model Model { get { return model; } }
        public bool DockEditors { get { return App.DockEditors; } set { App.DockEditors = value; } }
        // Constructor
        public ProgramController(Program app)
        {
            this.App = app;
        }
        #region File Managing
        public bool OpenRomFile()
        {
            if (App.OpenRomFile())
            {
                model.ClearModel();
                state.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
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
                model.ClearModel();
                state.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
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
            model.ClearModel();
            state.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
            App.CloseRomFile();
        }
        public bool VerifyRom()
        {
            return model.VerifyRom();
        }
        public string GetFileName()
        {
            return model.GetFileName();
        }
        public bool HeaderPresent()
        {
            return model.HeaderPresent();
        }
        public string GetFileNameWithoutPath()
        {
            return model.GetFileNameWithoutPath();
        }
        public string GetFileNameWithoutPathOrExtension()
        {
            return model.GetFileNameWithoutPathOrExtension();
        }
        public string GetRomName()
        {
            return model.GetRomName();
        }
        public string GetPathWithoutFileName()
        {
            return model.GetPathWithoutFileName();
        }
        public string RomChecksum()
        {
            return model.RomChecksum();
        }
        public string GameCode()
        {
            return model.GameCode();
        }
        public bool RemoveHeader()
        {
            return model.RemoveHeader();
        }
        public long GetFileSize()
        {
            return model.GetFileSize();
        }
        #endregion
        #region MD5 hash methods
        public void CreateNewMd5Checksum()
        {
            model.CreateNewMD5Checksum();
        }
        public bool VerifyMD5Checksum()
        {
            return model.VerifyMD5Checksum();
        }
        public void Assemble()
        {
            App.Assemble();
        }
        public bool AssembleAndCloseWindows()
        {
            return App.CloseAll();
        }
        #endregion
        #region Author Stamp
        public bool Locked()
        {
            return model.Locked;
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
        public void Allies()
        {
            App.CreateAlliesWindow();
        }
        public void Animations()
        {
            App.CreateAnimationsWindow();
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
        public void BattleScripts()
        {
            App.CreateBattleScriptsWindow();
        }
        public void Dialogues()
        {
            App.CreateDialoguesWindow();
        }
        public void Effects()
        {
            App.CreateEffectsWindow();
        }
        public void Formations()
        {
            App.CreateFormationsWindow();
        }
        public void Items()
        {
            App.CreateItemsWindow();
        }
        public void Levels()
        {
            App.CreateLevelsWindow();
        }
        public void MainTitle()
        {
            App.CreateMainTitleWindow();
        }
        public void Monsters()
        {
            App.CreateMonstersWindow();
        }
        public void Scripts()
        {
            App.CreateEventScriptsWindow();
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
        public void Notes()
        {
            App.CreateNotesWindow();
        }
        public void Dock()
        {
            App.Dock();
        }
        public void Undock()
        {
            App.Undock();
        }
        public void MinimizeAll()
        {
            App.MinimizeAll();
        }
        public void RestoreAll()
        {
            App.RestoreAll();
        }
        public void CloseAll()
        {
            App.CloseAll();
        }
        public void LoadAll()
        {
            App.LoadAll();
        }
        public void ClearAll()
        {
            App.ClearAll();
        }
        #endregion
    }
}
