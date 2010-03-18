using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;//remove later

namespace SMRPGED
{
    public class ProgramController
    {
        private Program App;
        private Model model;
        private State state = State.Instance;

        public ProgramController(Model model, Program app)
        {
            this.model = model;
            this.App = app;
        }

        public void exit()
        {
            Application.Exit();
        }

        public bool OpenRomFile()
        {
            if (App.OpenRomFile())
            {
                model.ClearModel();
                state.Universal = new UniversalVariables(); // reset universal variables;
                state.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                if (VerifyRom())
                {
                    SMRPGED.Encryption.Stamp signature = model.DecryptRomSignature();
                    if (signature.Published)
                        model.ViewSignature(signature);
                }
                else
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
                state.Universal = new UniversalVariables();
                state.PrivateKey = null; // Clear the PrivateKey whenever we load a new rom
                if (VerifyRom())
                {
                    SMRPGED.Encryption.Stamp signature = model.DecryptRomSignature();
                    
                    if (signature.Published)
                        model.ViewSignature(signature);
                }
                else
                    return false;
                return true;
            }
            else
                return false;
        }
        public bool SaveRomFile()
        {
            // Rom Signature Check
            model.EncryptRomSignature();
            return App.SaveRomFile();
        }
        public bool SaveRomFileAs()
        {
            // Rom Signature Save
            model.EncryptRomSignature();
            return App.SaveRomFileAs();
        }
        public bool CloseRomFile()
        {
            return false;
        }
        public bool VerifyRom()
        {
            return model.VerifyRom();
        }
        public bool Locked()
        {
            return model.Locked;
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
        public void StatsAndProperties()
        {
            App.CreateStatsWindow();            
        }
        public void Sprites()
        {
            App.CreateSpritesWindow();
        }
        public void Levels()
        {
            App.CreateLevelsWindow();
        }
        public void CreateNewLevelsCommandStack()
        {
            App.CreateNewLevelsCommandStack();
        }
        public void ClearLevelData()
        {
            model.ClearLevelData();
        }
        public void Scripts()
        {
            App.CreateScriptsWindow();
        }
        public void Patches()
        {
            App.CreatePatchesWindow();
        }
        // MD5 hash methods
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
            return App.AssembleAndCloseWindows();
        }
        public void AssembleFinal(bool val)
        {
            model.AssembleFinal = val;
            if(val)
                Assemble();
        }

        // Apply Author stamp to rom
        public bool Publish()
        {
            SMRPGED.Encryption.Cipher cipher = new SMRPGED.Encryption.Cipher(model.Data, model);
            SMRPGED.Encryption.Stamp stamp = new SMRPGED.Encryption.Stamp();
            
            bool pass = false; // Open publish window?

            if (cipher.IsNewRom()) // Yes if its a new rom
                pass = true;
            else if (cipher.CheckPassword(stamp.Password)) // Yes if the default password is valid
                pass = true;

            if (!pass) // Not a new rom/default password
            {
                SMRPGED.Encryption.EnterPassword getPass = new SMRPGED.Encryption.EnterPassword(stamp); // Ask for password
                getPass.ShowDialog();
                pass = cipher.CheckPassword(stamp.Password); // Check password against entered password
            }
            if (pass) // Open Stamper
            {
                SMRPGED.Encryption.AuthorStamp stamper = new SMRPGED.Encryption.AuthorStamp(this.model, stamp);
                stamper.ShowDialog();
                
                if (!stamp.Invalidated) // We have info
                {
                    // Ask to save rom
                    if (MessageBox.Show("Publishing a ROM requires saving. Save and publish this rom now?", "Save and Publish?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cipher.EncryptSignature(stamp, true);
                        return App.SaveRomFileAs(); // Save
                    }
                }
            }
            else
                if(stamp.Password != null)
                    MessageBox.Show("Incorrect Password"); // Do Not Save
            return false;
        }
        public void ViewSignature()
        {
            model.ViewSignature();  
        }

    }
}
