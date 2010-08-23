using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.Patches;
using LAZYSHELL.ScriptsEditor;

namespace LAZYSHELL
{
    public class Program
    {
        private Model model;
        private Settings settings = Settings.Default;
        private bool dockEditors;
        public bool DockEditors { get { return dockEditors; } set { dockEditors = value; } }
        #region Editor Windows
        private AlliesEditor allies; public AlliesEditor Allies { get { return allies; } }
        private AnimationScripts animations; public AnimationScripts Animations { get { return animations; } }
        private AttacksEditor attacks; public AttacksEditor Attacks { get { return attacks; } }
        private Audio audio; public Audio Audio { get { return audio; } }
        private Battlefields battlefields; public Battlefields Battlefields { get { return battlefields; } }
        private BattleScripts battleScripts; public BattleScripts BattleScripts { get { return battleScripts; } }
        private Dialogues dialogues; public Dialogues Dialogues { get { return dialogues; } }
        private Effects effects; public Effects Effects { get { return effects; } }
        private FormationsEditor formations; public FormationsEditor Formations { get { return formations; } }
        private ItemsEditor items; public ItemsEditor Items { get { return items; } }
        private Levels levels; public Levels Levels { get { return levels; } }
        private Title mainTitle; public Title MainTitle { get { return mainTitle; } }
        private Monsters monsters; public Monsters Monsters { get { return monsters; } }
        private EventScripts eventScripts; public EventScripts EventScripts { get { return eventScripts; } }
        private Sprites sprites; public Sprites Sprites { get { return sprites; } }
        private WorldMaps worldMaps; public WorldMaps WorldMaps { get { return worldMaps; } }
        private GamePatches patches;
        private Notes notes; public Notes Notes { get { return notes; } }
        private Form1 form1
        {
            get
            {
                if (Application.OpenForms.Count == 0)
                    return null;
                return (Form1)Application.OpenForms[0];
            }
            set
            {
                if (Application.OpenForms.Count == 0)
                    return;
                Form1 main = (Form1)Application.OpenForms[0];
                main = value;
            }
        }
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Program App = new Program();
        }
        // Constructor
        public Program()
        {
            model = new Model(this);
            State.Instance.Model = model;
            ProgramController controls = new ProgramController(this);
            Form1.GuiMain(controls);
        }
        #region File Managing
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
                return false;
            }
            return true;
        }
        public void Assemble()
        {
            if (allies != null && allies.Visible)
                allies.Assemble();
            if (animations != null && animations.Visible)
                animations.Assemble();
            if (attacks != null && attacks.Visible)
                attacks.Assemble();
            if (battlefields != null && battlefields.Visible)
                battlefields.Assemble();
            if (battleScripts != null && battleScripts.Visible)
                battleScripts.Assemble();
            if (dialogues != null && dialogues.Visible)
                dialogues.Assemble();
            if (eventScripts != null && eventScripts.Visible)
                eventScripts.Assemble();
            if (formations != null && formations.Visible)
                formations.Assemble();
            if (items != null && items.Visible)
                items.Assemble();
            if (levels != null && levels.Visible)
                levels.Assemble();
            if (monsters != null && monsters.Visible)
                monsters.Assemble();
            if (sprites != null && sprites.Visible)
                sprites.Assemble();
            if (mainTitle != null && mainTitle.Visible)
                mainTitle.Assemble();
            if (worldMaps != null && worldMaps.Visible)
                worldMaps.Assemble();
        }
        public void CloseRomFile()
        {
            model.DataHash = null;
        }
        #endregion
        #region Create Editor Windows
        public void CreateAlliesWindow()
        {
            if (allies == null || !allies.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                allies = new AlliesEditor();
                if (dockEditors) Do.AddControl(form1.Panel2, allies);
                else allies.Show();
                Cursor.Current = Cursors.Arrow;
            }
            allies.BringToFront();
        }
        public void CreateAnimationsWindow()
        {
            if (animations == null || !animations.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                animations = new AnimationScripts();
                if (dockEditors) Do.AddControl(form1.Panel2, animations);
                else animations.Show();
                Cursor.Current = Cursors.Arrow;
            }
            animations.BringToFront();
        }
        public void CreateAttacksWindow()
        {
            if (attacks == null || !attacks.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                attacks = new AttacksEditor();
                if (dockEditors) Do.AddControl(form1.Panel2, attacks);
                else attacks.Show();
                Cursor.Current = Cursors.Arrow;
            }
            attacks.BringToFront();
        }
        public void CreateAudioWindow()
        {
            if (audio == null || !audio.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                audio = new Audio();
                if (dockEditors) Do.AddControl(form1.Panel2, audio);
                else audio.Show();
                Cursor.Current = Cursors.Arrow;
            }
            audio.BringToFront();
        }
        public void CreateBattlefieldsWindow()
        {
            if (battlefields == null || !battlefields.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                battlefields = new Battlefields();
                if (dockEditors) Do.AddControl(form1.Panel2, battlefields);
                else battlefields.Show();
                Cursor.Current = Cursors.Arrow;
            }
            battlefields.BringToFront();
        }
        public void CreateBattleScriptsWindow()
        {
            if (battleScripts == null || !battleScripts.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                battleScripts = new BattleScripts();
                if (dockEditors) Do.AddControl(form1.Panel2, battleScripts);
                else battleScripts.Show();
                Cursor.Current = Cursors.Arrow;
            }
            battleScripts.BringToFront();
        }
        public void CreateDialoguesWindow()
        {
            if (dialogues == null || !dialogues.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                dialogues = new Dialogues();
                if (dockEditors) Do.AddControl(form1.Panel2, dialogues);
                else dialogues.Show();
                Cursor.Current = Cursors.Arrow;
            }
            dialogues.BringToFront();
        }
        public void CreateEffectsWindow()
        {
            if (effects == null || !effects.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                effects = new Effects();
                if (dockEditors) Do.AddControl(form1.Panel2, effects);
                else effects.Show();
                Cursor.Current = Cursors.Arrow;
            }
            effects.BringToFront();
        }
        public void CreateEventScriptsWindow()
        {
            if (eventScripts == null || !eventScripts.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                eventScripts = new EventScripts();
                if (dockEditors) Do.AddControl(form1.Panel2, eventScripts);
                else eventScripts.Show();
                Cursor.Current = Cursors.Arrow;
            }
            eventScripts.BringToFront();
        }
        public void CreateFormationsWindow()
        {
            if (formations == null || !formations.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                formations = new FormationsEditor();
                if (dockEditors) Do.AddControl(form1.Panel2, formations);
                else formations.Show();
                Cursor.Current = Cursors.Arrow;
            }
            formations.BringToFront();
        }
        public void CreateItemsWindow()
        {
            if (items == null || !items.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                items = new ItemsEditor();
                if (dockEditors) Do.AddControl(form1.Panel2, items);
                else items.Show();
                Cursor.Current = Cursors.Arrow;
            }
            items.BringToFront();
        }
        public void CreateLevelsWindow()
        {
            if (levels == null || !levels.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                levels = new Levels();
                if (dockEditors) Do.AddControl(form1.Panel2, levels);
                else levels.Show();
                Cursor.Current = Cursors.Arrow;
            }
            levels.BringToFront();
        }
        public void CreateMonstersWindow()
        {
            if (monsters == null || !monsters.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                monsters = new Monsters();
                if (dockEditors) Do.AddControl(form1.Panel2, monsters);
                else monsters.Show();
                Cursor.Current = Cursors.Arrow;
            }
            monsters.BringToFront();
        }
        public void CreateMainTitleWindow()
        {
            if (mainTitle == null || !mainTitle.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainTitle = new Title();
                if (dockEditors) Do.AddControl(form1.Panel2, mainTitle);
                else mainTitle.Show();
                Cursor.Current = Cursors.Arrow;
            }
            mainTitle.BringToFront();
        }
        public void CreateSpritesWindow()
        {
            if (sprites == null || !sprites.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                sprites = new Sprites();
                if (dockEditors) Do.AddControl(form1.Panel2, sprites);
                else sprites.Show();
                Cursor.Current = Cursors.Arrow;
            }
            sprites.BringToFront();
        }
        public void CreateWorldMapsWindow()
        {
            if (worldMaps == null || !worldMaps.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                worldMaps = new WorldMaps();
                if (dockEditors) Do.AddControl(form1.Panel2, worldMaps);
                else worldMaps.Show();
                Cursor.Current = Cursors.Arrow;
            }
            worldMaps.BringToFront();
        }
        public void CreatePatchesWindow()
        {
            if ((levels != null && levels.Visible) ||
                (eventScripts != null && eventScripts.Visible) ||
                (sprites != null && sprites.Visible))
            {
                DialogResult result = MessageBox.Show(
                    "It is highly recommended that you close and save any editor windows before patching.\n\n" +
                    "Would you like to save and close all current windows?",
                    "LAZY SHELL", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    CloseAll();
                else if (result == DialogResult.Cancel)
                    return;
            }
            if (patches == null || !patches.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                patches = new GamePatches();
                patches.Show();
                patches.StartDownloadingPatches();
                Cursor.Current = Cursors.Arrow;
            }
        }
        public void CreateNotesWindow()
        {
            if (notes == null || !notes.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                notes = new Notes();
                notes.Show();
                Cursor.Current = Cursors.Arrow;
            }
        }
        public void Dock()
        {
            if (allies != null && allies.Visible)
                Do.AddControl(form1.Panel2, allies);
            if (animations != null && animations.Visible)
                Do.AddControl(form1.Panel2, animations);
            if (attacks != null && attacks.Visible)
                Do.AddControl(form1.Panel2, attacks);
            if (battlefields != null && battlefields.Visible)
                Do.AddControl(form1.Panel2, battlefields);
            if (battleScripts != null && battleScripts.Visible)
                Do.AddControl(form1.Panel2, battleScripts);
            if (dialogues != null && dialogues.Visible)
                Do.AddControl(form1.Panel2, dialogues);
            if (effects != null && effects.Visible)
                Do.AddControl(form1.Panel2, effects);
            if (eventScripts != null && eventScripts.Visible)
                Do.AddControl(form1.Panel2, eventScripts);
            if (formations != null && formations.Visible)
                Do.AddControl(form1.Panel2, formations);
            if (items != null && items.Visible)
                Do.AddControl(form1.Panel2, items);
            if (levels != null && levels.Visible)
                Do.AddControl(form1.Panel2, levels);
            if (mainTitle != null && mainTitle.Visible)
                Do.AddControl(form1.Panel2, mainTitle);
            if (monsters != null && monsters.Visible)
                Do.AddControl(form1.Panel2, monsters);
            if (sprites != null && sprites.Visible)
                Do.AddControl(form1.Panel2, sprites);
            if (worldMaps != null && worldMaps.Visible)
                Do.AddControl(form1.Panel2, worldMaps);
        }
        public void Undock()
        {
            if (allies != null && allies.Visible)
                Do.RemoveControl(allies);
            if (animations != null && animations.Visible)
                Do.RemoveControl(animations);
            if (attacks != null && attacks.Visible)
                Do.RemoveControl(attacks);
            if (battlefields != null && battlefields.Visible)
                Do.RemoveControl(battlefields);
            if (battleScripts != null && battleScripts.Visible)
                Do.RemoveControl(battleScripts);
            if (dialogues != null && dialogues.Visible)
                Do.RemoveControl(dialogues);
            if (effects != null && effects.Visible)
                Do.RemoveControl(effects);
            if (eventScripts != null && eventScripts.Visible)
                Do.RemoveControl(eventScripts);
            if (formations != null && formations.Visible)
                Do.RemoveControl(formations);
            if (items != null && items.Visible)
                Do.RemoveControl(items);
            if (levels != null && levels.Visible)
                Do.RemoveControl(levels);
            if (mainTitle != null && mainTitle.Visible)
                Do.RemoveControl(mainTitle);
            if (monsters != null && monsters.Visible)
                Do.RemoveControl(monsters);
            if (sprites != null && sprites.Visible)
                Do.RemoveControl(sprites);
            if (worldMaps != null && worldMaps.Visible)
                Do.RemoveControl(worldMaps);
        }
        public void MinimizeAll()
        {
            if (allies != null && allies.Visible)
                allies.WindowState = FormWindowState.Minimized;
            if (animations != null && animations.Visible)
                animations.WindowState = FormWindowState.Minimized;
            if (attacks != null && attacks.Visible)
                attacks.WindowState = FormWindowState.Minimized;
            if (battlefields != null && battlefields.Visible)
                battlefields.WindowState = FormWindowState.Minimized;
            if (battleScripts != null && battleScripts.Visible)
                battleScripts.WindowState = FormWindowState.Minimized;
            if (dialogues != null && dialogues.Visible)
                dialogues.WindowState = FormWindowState.Minimized;
            if (effects != null && effects.Visible)
                effects.WindowState = FormWindowState.Minimized;
            if (eventScripts != null && eventScripts.Visible)
                eventScripts.WindowState = FormWindowState.Minimized;
            if (formations != null && formations.Visible)
                formations.WindowState = FormWindowState.Minimized;
            if (items != null && items.Visible)
                items.WindowState = FormWindowState.Minimized;
            if (levels != null && levels.Visible)
                levels.WindowState = FormWindowState.Minimized;
            if (mainTitle != null && mainTitle.Visible)
                mainTitle.WindowState = FormWindowState.Minimized;
            if (monsters != null && monsters.Visible)
                monsters.WindowState = FormWindowState.Minimized;
            if (sprites != null && sprites.Visible)
                sprites.WindowState = FormWindowState.Minimized;
            if (worldMaps != null && worldMaps.Visible)
                worldMaps.WindowState = FormWindowState.Minimized;
        }
        public void RestoreAll()
        {
            if (allies != null && allies.Visible)
                allies.WindowState = FormWindowState.Normal;
            if (animations != null && animations.Visible)
                animations.WindowState = FormWindowState.Normal;
            if (attacks != null && attacks.Visible)
                attacks.WindowState = FormWindowState.Normal;
            if (battlefields != null && battlefields.Visible)
                battlefields.WindowState = FormWindowState.Normal;
            if (battleScripts != null && battleScripts.Visible)
                battleScripts.WindowState = FormWindowState.Normal;
            if (dialogues != null && dialogues.Visible)
                dialogues.WindowState = FormWindowState.Normal;
            if (effects != null && effects.Visible)
                effects.WindowState = FormWindowState.Normal;
            if (eventScripts != null && eventScripts.Visible)
                eventScripts.WindowState = FormWindowState.Normal;
            if (formations != null && formations.Visible)
                formations.WindowState = FormWindowState.Normal;
            if (items != null && items.Visible)
                items.WindowState = FormWindowState.Normal;
            if (levels != null && levels.Visible)
                levels.WindowState = FormWindowState.Normal;
            if (mainTitle != null && mainTitle.Visible)
                mainTitle.WindowState = FormWindowState.Normal;
            if (monsters != null && monsters.Visible)
                monsters.WindowState = FormWindowState.Normal;
            if (sprites != null && sprites.Visible)
                sprites.WindowState = FormWindowState.Normal;
            if (worldMaps != null && worldMaps.Visible)
                worldMaps.WindowState = FormWindowState.Normal;
        }
        public bool CloseAll()
        {
            if (allies != null && allies.Visible)
                allies.Close();
            if (animations != null && animations.Visible)
                animations.Close();
            if (attacks != null && attacks.Visible)
                attacks.Close();
            if (battlefields != null && battlefields.Visible)
                battlefields.Close();
            if (battleScripts != null && battleScripts.Visible)
                battleScripts.Close();
            if (dialogues != null && dialogues.Visible)
                dialogues.Close();
            if (effects != null && effects.Visible)
                effects.Close();
            if (eventScripts != null && eventScripts.Visible)
                eventScripts.Close();
            if (formations != null && formations.Visible)
                formations.Close();
            if (items != null && items.Visible)
                items.Close();
            if (levels != null && levels.Visible)
                levels.Close();
            if (monsters != null && monsters.Visible)
                monsters.Close();
            if (sprites != null && sprites.Visible)
                sprites.Close();
            if (mainTitle != null && mainTitle.Visible)
                mainTitle.Close();
            if (worldMaps != null && worldMaps.Visible)
                worldMaps.Close();
            if ((allies != null && allies.Visible) ||
                (animations != null && animations.Visible) ||
                (attacks != null && attacks.Visible) ||
                (battlefields != null && battlefields.Visible) ||
                (battleScripts != null && battleScripts.Visible) ||
                (dialogues != null && dialogues.Visible) ||
                (effects != null && effects.Visible) ||
                (eventScripts != null && eventScripts.Visible) ||
                (formations != null && formations.Visible) ||
                (items != null && items.Visible) ||
                (levels != null && levels.Visible) ||
                (monsters != null && monsters.Visible) ||
                (sprites != null && sprites.Visible) ||
                (mainTitle != null && mainTitle.Visible) ||
                (worldMaps != null && worldMaps.Visible))
                return true;
            return false;
        }
        public void LoadAll()
        {
            model.LoadAll();
        }
        public void ClearAll()
        {
            model.ClearModel();
        }
        #endregion
    }
}