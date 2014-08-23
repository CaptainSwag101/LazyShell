using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using LAZYSHELL.Properties;
using LAZYSHELL.Patches;
using LAZYSHELL.EventScripts;

namespace LAZYSHELL
{
    public class Program
    {
        #region Variables

        private Settings settings = Settings.Default;
        public bool DockEditors { get; set; }

        #region Editor Windows

        private List<Form> loadedForms = new List<Form>();
        public Animations.OwnerForm Animations { get; set; }
        public Areas.OwnerForm Areas { get; set; }
        public Attacks.OwnerForm Attacks { get; set; }
        public Audio.OwnerForm Audio { get; set; }
        public Battlefields.OwnerForm Battlefields { get; set; }
        public Dialogues.OwnerForm Dialogues { get; set; }
        public Effects.OwnerForm Effects { get; set; }
        public EventScripts.OwnerForm EventScripts { get; set; }
        public Fonts.OwnerForm Fonts { get; set; }
        public Formations.OwnerForm Formations { get; set; }
        public Intro.OwnerForm Intro { get; set; }
        public Items.OwnerForm Items { get; set; }
        public LevelUps.OwnerForm LevelUps { get; set; }
        public Magic.OwnerForm Magic { get; set; }
        public Menus.OwnerForm Menus { get; set; }
        public Minecart.OwnerForm Minecart { get; set; }
        public Monsters.OwnerForm Monsters { get; set; }
        public NewGame.OwnerForm NewGame { get; set; }
        public Shops.OwnerForm Shops { get; set; }
        public Sprites.OwnerForm Sprites { get; set; }
        public WorldMaps.OwnerForm WorldMaps { get; set; }
        public PatchesForm Patches { get; set; }
        public ProjectForm Project { get; set; }
        public HexEditor HexEditor { get; set; }
        public MainForm MainForm
        {
            get
            {
                if (Application.OpenForms.Count == 0)
                    return null;
                return Application.OpenForms[0] as MainForm;
            }
            set
            {
                if (Application.OpenForms.Count == 0)
                    return;
                var main = Application.OpenForms[0] as MainForm;
                main = value;
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Program App = new Program();
        }

        #region Methods

        // Custom exception form
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Model.History += "***EXCEPTION*** " + e.Exception.Message + ")\n";
            new NewExceptionForm(e.Exception).ShowDialog();
        }

        // Constructor
        public Program()
        {
            LAZYSHELL.Model.Program = this;
            ProgramController controls = new ProgramController(this);
            MainForm.GuiMain(controls);
        }

        // File Managing
        public bool OpenRomFile()
        {
            string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Select a SMRPG ROM";
            openFileDialog1.Filter = "SMC files (*.SMC)|*.SMC|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            //
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                filename = openFileDialog1.FileName;
                Model.FileName = filename;
                if (Model.ReadRom())
                {
                    settings.LastRomPath = Model.GetPathWithoutFileName();
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
            Model.FileName = filename;
            if (Model.ReadRom())
            {
                settings.LastRomPath = Model.GetPathWithoutFileName();
                settings.Save();
                return true;
            }
            return false;
        }
        public bool SaveRomFile()
        {
            WriteToROM();
            if (Model.WriteRom())
            {
                Model.CreateNewMD5Checksum();
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
                Model.FileName = saveFileDialog1.FileName;
                // Assemble all changes
                WriteToROM();
                if (Model.WriteRom())
                {
                    settings.LastRomPath = Model.GetPathWithoutFileName();
                    settings.Save();
                    Model.CreateNewMD5Checksum();
                    return true;
                }
                return false;
            }
            return true;
        }
        public void WriteToROM()
        {
            if (NewGame != null && NewGame.Visible)
                NewGame.WriteToROM();
            if (Animations != null && Animations.Visible)
                Animations.WriteToROM();
            if (Attacks != null && Attacks.Visible)
                Attacks.WriteToROM();
            if (Battlefields != null && Battlefields.Visible)
                Battlefields.WriteToROM();
            if (Dialogues != null && Dialogues.Visible)
                Dialogues.WriteToROM();
            if (EventScripts != null && EventScripts.Visible)
                EventScripts.WriteToROM();
            if (Fonts != null && Fonts.Visible)
                Fonts.WriteToROM();
            if (Formations != null && Formations.Visible)
                Formations.WriteToROM();
            if (Items != null && Items.Visible)
                Items.WriteToROM();
            if (Areas != null && Areas.Visible)
                Areas.WriteToROM();
            if (Monsters != null && Monsters.Visible)
                Monsters.WriteToROM();
            if (Sprites != null && Sprites.Visible)
                Sprites.WriteToROM();
            if (Intro != null && Intro.Visible)
                Intro.WriteToROM();
            if (WorldMaps != null && WorldMaps.Visible)
                WorldMaps.WriteToROM();
        }
        public void CloseRomFile()
        {
            Model.ROMHash = null;
        }

        #region Create Editor Windows

        // Editors
        public void CreateAnimationsWindow()
        {
            if (Animations == null || !Animations.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Animations = new Animations.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Animations);
                else
                    Animations.Show();
                loadedForms.Add(Animations);
                Cursor.Current = Cursors.Arrow;
            }
            Animations.KeyDown += new KeyEventHandler(editor_KeyDown);
            Animations.BringToFront();
        }
        public void CreateAreasWindow()
        {
            if (Areas == null || !Areas.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Areas = new Areas.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Areas);
                else
                    Areas.Show();
                loadedForms.Add(Areas);
                Cursor.Current = Cursors.Arrow;
            }
            Areas.KeyDown += new KeyEventHandler(editor_KeyDown);
            Areas.BringToFront();
        }
        public void CreateAttacksWindow()
        {
            if (Attacks == null || !Attacks.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Attacks = new Attacks.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Attacks);
                else
                    Attacks.Show();
                loadedForms.Add(Attacks);
                Cursor.Current = Cursors.Arrow;
            }
            Attacks.KeyDown += new KeyEventHandler(editor_KeyDown);
            Attacks.BringToFront();
        }
        public void CreateAudioWindow()
        {
            if (Audio == null || !Audio.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Audio = new Audio.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Audio);
                else
                    Audio.Show();
                loadedForms.Add(Audio);
                Cursor.Current = Cursors.Arrow;
            }
            Audio.KeyDown += new KeyEventHandler(editor_KeyDown);
            Audio.BringToFront();
        }
        public void CreateBattlefieldsWindow()
        {
            if (Battlefields == null || !Battlefields.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Battlefields = new Battlefields.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Battlefields);
                else
                    Battlefields.Show();
                loadedForms.Add(Battlefields);
                Cursor.Current = Cursors.Arrow;
            }
            Battlefields.KeyDown += new KeyEventHandler(editor_KeyDown);
            Battlefields.BringToFront();
        }
        public void CreateDialoguesWindow()
        {
            if (Dialogues == null || !Dialogues.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Dialogues = new Dialogues.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Dialogues);
                else
                    Dialogues.Show();
                loadedForms.Add(Dialogues);
                Cursor.Current = Cursors.Arrow;
            }
            Dialogues.KeyDown += new KeyEventHandler(editor_KeyDown);
            Dialogues.BringToFront();
        }
        public void CreateEffectsWindow()
        {
            if (Effects == null || !Effects.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Effects = new Effects.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Effects);
                else
                    Effects.Show();
                loadedForms.Add(Effects);
                Cursor.Current = Cursors.Arrow;
            }
            Effects.KeyDown += new KeyEventHandler(editor_KeyDown);
            Effects.BringToFront();
        }
        public void CreateEventScriptsWindow()
        {
            if (EventScripts == null || !EventScripts.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                EventScripts = new OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, EventScripts);
                else
                    EventScripts.Show();
                loadedForms.Add(EventScripts);
                Cursor.Current = Cursors.Arrow;
            }
            EventScripts.KeyDown += new KeyEventHandler(editor_KeyDown);
            EventScripts.BringToFront();
        }
        public void CreateFontsWindow()
        {
            if (Fonts == null || !Fonts.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Fonts = new Fonts.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Fonts);
                else
                    Fonts.Show();
                loadedForms.Add(Fonts);
                Cursor.Current = Cursors.Arrow;
            }
            Fonts.KeyDown += new KeyEventHandler(editor_KeyDown);
            Fonts.BringToFront();
        }
        public void CreateFormationsWindow()
        {
            if (Formations == null || !Formations.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Formations = new Formations.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Formations);
                else
                    Formations.Show();
                loadedForms.Add(Formations);
                Cursor.Current = Cursors.Arrow;
            }
            Formations.KeyDown += new KeyEventHandler(editor_KeyDown);
            Formations.BringToFront();
        }
        public void CreateIntroWindow()
        {
            if (Intro == null || !Intro.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Intro = new Intro.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Intro);
                else
                    Intro.Show();
                loadedForms.Add(Intro);
                Cursor.Current = Cursors.Arrow;
            }
            Intro.KeyDown += new KeyEventHandler(editor_KeyDown);
            Intro.BringToFront();
        }
        public void CreateItemsWindow()
        {
            if (Items == null || !Items.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Items = new Items.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Items);
                else
                    Items.Show();
                loadedForms.Add(Items);
                Cursor.Current = Cursors.Arrow;
            }
            Items.KeyDown += new KeyEventHandler(editor_KeyDown);
            Items.BringToFront();
        }
        public void CreateLevelUpsWindow()
        {
            if (LevelUps == null || !LevelUps.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                LevelUps = new LevelUps.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, LevelUps);
                else
                    LevelUps.Show();
                loadedForms.Add(LevelUps);
                Cursor.Current = Cursors.Arrow;
            }
            LevelUps.KeyDown += new KeyEventHandler(editor_KeyDown);
            LevelUps.BringToFront();
        }
        public void CreateMagicWindow()
        {
            if (Magic == null || !Magic.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Magic = new Magic.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Magic);
                else
                    Magic.Show();
                loadedForms.Add(Magic);
                Cursor.Current = Cursors.Arrow;
            }
            Magic.KeyDown += new KeyEventHandler(editor_KeyDown);
            Magic.BringToFront();
        }
        public void CreateMonstersWindow()
        {
            if (Monsters == null || !Monsters.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Monsters = new Monsters.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Monsters);
                else
                    Monsters.Show();
                loadedForms.Add(Monsters);
                Cursor.Current = Cursors.Arrow;
            }
            Monsters.KeyDown += new KeyEventHandler(editor_KeyDown);
            Monsters.BringToFront();
        }
        public void CreateNewGameWindow()
        {
            if (NewGame == null || !NewGame.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                NewGame = new NewGame.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, NewGame);
                else
                    NewGame.Show();
                loadedForms.Add(NewGame);
                Cursor.Current = Cursors.Arrow;
            }
            NewGame.KeyDown += new KeyEventHandler(editor_KeyDown);
            NewGame.BringToFront();
        }
        public void CreateMenusWindow()
        {
            if (Menus == null || !Menus.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Menus = new Menus.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Menus);
                else
                    Menus.Show();
                loadedForms.Add(Menus);
                Cursor.Current = Cursors.Arrow;
            }
            Menus.KeyDown += new KeyEventHandler(editor_KeyDown);
            Menus.BringToFront();
        }
        public void CreateMinecartWindow()
        {
            if (Minecart == null || !Minecart.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Minecart = new Minecart.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Minecart);
                else
                    Minecart.Show();
                loadedForms.Add(Minecart);
                Cursor.Current = Cursors.Arrow;
            }
            Minecart.KeyDown += new KeyEventHandler(editor_KeyDown);
            Minecart.BringToFront();
        }
        public void CreateShopsWindow()
        {
            if (Shops == null || !Shops.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Shops = new Shops.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Shops);
                else
                    Shops.Show();
                loadedForms.Add(Shops);
                Cursor.Current = Cursors.Arrow;
            }
            Shops.KeyDown += new KeyEventHandler(editor_KeyDown);
            Shops.BringToFront();
        }
        public void CreateSpritesWindow()
        {
            if (Sprites == null || !Sprites.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Sprites = new Sprites.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, Sprites);
                else
                    Sprites.Show();
                loadedForms.Add(Sprites);
                Cursor.Current = Cursors.Arrow;
            }
            Sprites.KeyDown += new KeyEventHandler(editor_KeyDown);
            Sprites.BringToFront();
        }
        public void CreateWorldMapsWindow()
        {
            if (WorldMaps == null || !WorldMaps.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                WorldMaps = new WorldMaps.OwnerForm();
                if (DockEditors)
                    Do.AddControl(MainForm.PanelForms, WorldMaps);
                else
                    WorldMaps.Show();
                loadedForms.Add(WorldMaps);
                Cursor.Current = Cursors.Arrow;
            }
            WorldMaps.KeyDown += new KeyEventHandler(editor_KeyDown);
            WorldMaps.BringToFront();
        }

        // Non-editors
        public void CreatePatchesWindow()
        {
            if ((Areas != null && Areas.Visible) ||
                (EventScripts != null && EventScripts.Visible) ||
                (Sprites != null && Sprites.Visible))
            {
                var result = MessageBox.Show(
                    "It is highly recommended that you close and save any editor windows before patching.\n\n" +
                    "Would you like to save and close all current windows?",
                    "LAZY SHELL", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    CloseAll();
                else
                    if (result == DialogResult.Cancel)
                        return;
            }
            if (Patches == null || !Patches.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Patches = new PatchesForm();
                Patches.Show();
                Patches.StartDownloadingPatches();
                Cursor.Current = Cursors.Arrow;
            }
        }
        public void CreateProjectWindow()
        {
            if (Project == null || !Project.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                Project = new ProjectForm();
                Project.Show();
                Cursor.Current = Cursors.Arrow;
            }
        }
        public void CreateHexEditor()
        {
            if (HexEditor == null || !HexEditor.Visible)
            {
                HexEditor = new HexEditor(Model.ROM, Bits.Copy(Model.ROM));
                HexEditor.Owner = MainForm;
            }
        }

        #endregion

        // Window management
        public void Dock()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    Do.AddControl(MainForm.PanelForms, form);
            }
        }
        public void Undock()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    Do.RemoveControl(form);
            }
        }
        public void OpenAll()
        {
            CreateAnimationsWindow();
            CreateAreasWindow();
            CreateAttacksWindow();
            CreateAudioWindow();
            CreateBattlefieldsWindow();
            CreateDialoguesWindow();
            CreateEffectsWindow();
            CreateEventScriptsWindow();
            CreateFontsWindow();
            CreateFormationsWindow();
            CreateItemsWindow();
            CreateIntroWindow();
            CreateMagicWindow();
            CreateMenusWindow();
            CreateMinecartWindow();
            CreateNewGameWindow();
            CreateMonstersWindow();
            CreateShopsWindow();
            CreateSpritesWindow();
            CreateWorldMapsWindow();
        }
        public void MinimizeAll()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    form.WindowState = FormWindowState.Minimized;
            }
        }
        public void RestoreAll()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    form.WindowState = FormWindowState.Normal;
            }
        }
        public bool CloseAll()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (i >= Application.OpenForms.Count)
                    continue;
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    form.Close();
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (i >= Application.OpenForms.Count)
                    continue;
                var form = Application.OpenForms[i];
                if (form != MainForm && form.Owner == null)
                    return true;
            }
            return false;
        }
        public void ScreencapHotkeys()
        {

        }

        // Data management
        public void LoadAll()
        {
            Model.LoadAll();
        }
        public void ClearAll()
        {
            Model.ClearAll();
        }

        // Event Handlers
        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            Form editor = sender as Form;
            if (e.KeyData == Keys.F3)
                Do.CaptureScreens(editor);
        }

        #endregion
    }
}