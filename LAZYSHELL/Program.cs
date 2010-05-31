using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.Patches;
using LAZYSHELL.ScriptsEditor;

namespace LAZYSHELL
{
    public class Program
    {
        //private Form stats;
        private StatsEditor.StatsEditor stats; public StatsEditor.StatsEditor Stats { get { return stats; } set { stats = value; } }
        private Levels levels; public Levels Levels { get { return levels; } }
        private Sprites sprites; public Sprites Sprites { get { return sprites; } }
        private Scripts scripts; public Scripts Scripts { get { return scripts; } }
        private Notes notes; public Notes Notes { get { return notes; } }
        private GamePatches patches;
        private Model model;
        private Settings settings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (IntPtr.Size == 8)
            {
                DialogResult result = MessageBox.Show(
                    "You are attempting to run Lazy Shell under a 64-bit OS. Several portions\n" +
                    "of this application are incapable of running within a 64-bit environment.\n" +
                    "Open \"CorFlags.bat\" to run Lazy Shell within a 32-bit environment.\n\n" +
                    "Continue using this application anyways?",
                    "LAZY SHELL", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            
            Program App = new Program();
        }

        public Program()
        {

            model = new Model(this);
            settings = Settings.Default;

            ProgramController controls = new ProgramController(model, this);

            Form1.GuiMain(controls);

        }

        public bool OpenRomFile()
        {
            string filename;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Select a SMRPG ROM";
            openFileDialog1.Filter = "SMC files (*.SMC)|*.SMC|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                filename = openFileDialog1.FileName;
                model.SetFileName(filename);
                if (model.ReadRom())
                {
                    settings.LastRomPath = model.GetPathWithoutFileName();
                    settings.Save();
                    return true;
                }
            }
            else
                filename = "";
            return false;

        }
        public bool OpenRomFile(string filename)
        {
            model.SetFileName(filename);
            if (model.ReadRom())
            {
                settings.LastRomPath = model.GetPathWithoutFileName();
                settings.Save();
                return true;
            }
            return false;
        }
        public bool AssembleAndCloseWindows()
        {
            if (stats != null && stats.Visible)
                stats.Close();
            if (levels != null && levels.Visible)
                levels.Close();
            if (scripts != null && scripts.Visible)
                scripts.Close();
            if (sprites != null && sprites.Visible)
                sprites.Close();

            if ((stats != null && stats.Visible) ||
                (levels != null && levels.Visible) ||
                (scripts != null && scripts.Visible) ||
                (sprites != null && sprites.Visible))
                return true;

            return false;
        }
        public bool SaveRomFile()
        {
            Assemble();
            if (model.WriteRom())
            {
                model.CreateNewMD5Checksum();
                return true;
            }
            return false;
        }
        public bool SaveRomFileAs()
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "SMC files (*.SMC)|*.SMC|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                model.SetFileName(saveFileDialog1.FileName);

                // Assemble all changes
                Assemble();

                if (model.WriteRom())
                {
                    settings.LastRomPath = model.GetPathWithoutFileName();
                    settings.Save();
                    model.CreateNewMD5Checksum();
                    return true;
                }
            }
            return false;
        }
        public void Assemble()
        {
            if (stats != null && model.AssembleStats)
                stats.Assemble();
            if (levels != null && model.AssembleLevels)
                levels.Assemble();
            if (scripts != null && model.AssembleScripts)
                scripts.Assemble();
            if (sprites != null && model.AssembleSprites)
                sprites.Assemble();

        }
        public void CreateStatsWindow()
        {
            if (stats == null || !stats.Visible)
            {
                model.AssembleStats = true;
                stats = new StatsEditor.StatsEditor(model);
                stats.Show();
            }
        }
        public void CreateSpritesWindow()
        {
            if (sprites == null || !sprites.Visible)
            {
                model.AssembleSprites = true;
                sprites = new Sprites(model);
                sprites.Show();
            }
        }
        public void CreateScriptsWindow()
        {
            if (scripts == null || !scripts.Visible)
            {
                model.AssembleScripts = true;
                scripts = new Scripts(model);
                scripts.Show();
            }
        }
        public void CreateLevelsWindow()
        {
            if (levels == null || !levels.Visible)
            {
                model.AssembleLevels = true;
                levels = new Levels(model);
                levels.Show();
            }
        }
        public void CreatePatchesWindow()
        {
            if ((stats != null && stats.Visible) || (levels != null && levels.Visible) || (scripts != null && scripts.Visible) || (sprites != null && sprites.Visible))
            {
                DialogResult result = MessageBox.Show("It is highly recommended that you close and save any editor windows before patching. Would you like to save and close all current windows?", "LAZY SHELL", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    AssembleAndCloseWindows();
                else if (result == DialogResult.Cancel)
                    return;
            }

            if (patches == null || !patches.Visible)
            {
                patches = new GamePatches(model);
                patches.Show();
                patches.StartDownloadingPatches();
            }
        }
        public void CreateNotesWindow()
        {
            if (notes == null || !notes.Visible)
            {
                notes = new Notes(model);
                notes.Show();
            }
        }
        public void CreateNewLevelsCommandStack()
        {
            try
            {
                if (levels != null)
                    levels.CreateNewCommandStack();
            }
            catch (Exception ex)
            {

            }
        }
    }
}