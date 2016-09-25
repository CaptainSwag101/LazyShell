using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Monsters
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables
        
        // Elements
        public Monster[] Monsters
        {
            get { return Model.Monsters; }
            set { Model.Monsters = value; }
        }
        public Monster Monster
        {
            get { return Monsters[Index]; }
            set { Monsters[Index] = value; }
        }

        // Navigators
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        public Controls.NewToolStripNumericUpDown Num
        {
            get { return this.num; }
            set { this.num = value; }
        }
        public Controls.NewToolStripComboBox MonsterName
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public ToolStripTextBox NameText
        {
            get { return this.nameText; }
            set { this.nameText = value; }
        }
        private Settings settings = Settings.Default;

        // Forms
        private MonstersForm monstersForm;
        private BattleScriptForm battleScriptsForm;
        private SpriteForm spriteForm;
        private HackingTools hackingToolsWindow;
        private EditLabel labelWindow;
        private PreviewerForm previewerForm;

        // Text image
        private MenuTextPreview menuTextPreview = new MenuTextPreview();
        private Fonts.Glyph[] fontMenu
        {
            get { return Fonts.Model.Menu; }
        }
        private int[] fontPaletteBattle
        {
            get { return Fonts.Model.Palette_Battle.Palettes[0]; }
        }

        // Functions
        private delegate void UpdateFunction();

        #endregion
        
        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeNavigators();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        // Initialization
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastMonster;
            //
            this.Updating = false;
        }
        private void InitializeForms()
        {
            // Editor forms
            monstersForm = new MonstersForm(this);
            monstersForm.ToggleButton = toggleMonsters;
			DockPanel = new DockPanel();
			DockPanel = dockPanel;

			Settings settings = Settings.Default;
			if (settings.VisualTheme == 0 || settings.VisualTheme == 1)
			{
				DockPanel.Theme = new VS2005Theme();
			}
			else if (settings.VisualTheme == 2)
			{
				DockPanel.Theme = new VS2013BlueTheme();
			}

			dockPanel = DockPanel;
			monstersForm.Show(dockPanel, DockState.Document);
            spriteForm = new SpriteForm(this);
            spriteForm.ToggleButton = toggleSprite;
            spriteForm.Show(dockPanel, DockState.Document);
            battleScriptsForm = new BattleScriptForm(this);
            battleScriptsForm.ToggleButton = toggleBattleScripts;
            battleScriptsForm.Show(monstersForm.Pane, DockAlignment.Right, 0.60);

            // Hacking tools
            hackingToolsWindow = new HackingTools(new UpdateFunction(monstersForm.LoadProperties), num);
        }
        private void CreateHelperForms()
        {
            labelWindow = new EditLabel(name, num, "Monsters", false);
            toolTip1.InitialDelay = 0;
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip4, Keys.F2, baseConvertor);
        }

        // Saving
        public void WriteToROM()
        {
            int i = 0;
            int length = 0xA1D1;
            for (; i < Monsters.Length && length + Monsters[i].RawPsychopath.Length < 0xb641; i++)
                Monsters[i].WriteToROM(ref length);
            length = 0x1C2A;
            for (; i < Monsters.Length && length + Monsters[i].RawPsychopath.Length < 0x2229; i++)
                Monsters[i].WriteToROM(ref length);
            if (i != Monsters.Length)
                MessageBox.Show(
                    "The allotted space for psychopath dialogues has been exceeded. Not all psychopath dialogues have been saved.",
                    "LAZY SHELL");
            battleScriptsForm.WriteToROM();
            battleScriptsForm.Modified = false;
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified && !battleScriptsForm.Modified)
                return;
            var result = MessageBox.Show(
                "Monsters and battlescripts have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                WriteToROM();
                battleScriptsForm.WriteToROM();
            }
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                monstersForm.LoadProperties();
                battleScriptsForm.InitializeControls();
                spriteForm.LoadProperties();
                settings.LastMonster = Index;
            }
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.num.Value = Model.Names.GetUnsortedIndex(name.SelectedIndex);
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, menuTextPreview, Model.Names, fontMenu, fontPaletteBattle, true, Menus.Model.MenuBG_256x255);
        }
        private void nameText_TextChanged(object sender, EventArgs e)
        {
            if (Model.Names.GetUnsortedName(Monster.Index).CompareTo(this.nameText.Text) != 0)
            {
                Monster.Name = Do.ASCIIToRaw(this.nameText.Text, Lists.KeystrokesMenu, 13);
                Model.Names.SetName(
                    Monster.Index,
                    new string(Monster.Name));
                Model.Names.SortAlphabetically();
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Monster.Index);
            }
        }

        // Previewer
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            if (previewerForm == null || !previewerForm.Visible)
                previewerForm = new PreviewerForm(Index, ElementType.BattleScript);
            else
                previewerForm.Reload(Index, ElementType.BattleScript);
            previewerForm.Show();
            previewerForm.BringToFront();
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Monsters, IOMode.Import, Index, "IMPORT MONSTERS...").ShowDialog();
            monstersForm.LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Monsters, IOMode.Export, Index, "EXPORT MONSTERS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Monsters, Index, "CLEAR MONSTERS...").ShowDialog();
            monstersForm.LoadProperties();
        }
        private void importBattleScripts_Click(object sender, EventArgs e)
        {
            battleScriptsForm.Import();
        }
        private void exportBattleScripts_Click(object sender, EventArgs e)
        {
            battleScriptsForm.Export();
        }
        private void dumpBattleScriptText_Click(object sender, EventArgs e)
        {
            battleScriptsForm.DumpScriptText();
        }
        private void clearBattleScripts_Click(object sender, EventArgs e)
        {
            battleScriptsForm.Clear();
        }
        private void hackingTools_Click(object sender, EventArgs e)
        {
            if (!hackingToolsWindow.Visible)
                hackingToolsWindow.Show();
            hackingToolsWindow.BringToFront();
        }
        private void resetCurrentMonster_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current monster. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Monster = new Monster(Index);
            num_ValueChanged(null, null);
        }
        private void resetCurrentBattleScript_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current battle script. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            battleScriptsForm.BattleScript = new Monsters.BattleScript(battleScriptsForm.index);
            num_ValueChanged(null, null);
        }

        #endregion
    }
}
