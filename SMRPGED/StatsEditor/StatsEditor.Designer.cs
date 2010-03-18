using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsEditor));
            this.panelSearchFormationNames = new System.Windows.Forms.Panel();
            this.listBoxFormationNames = new System.Windows.Forms.ListBox();
            this.panel200 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attackAtkLevel = new System.Windows.Forms.NumericUpDown();
            this.attackHitRate = new System.Windows.Forms.NumericUpDown();
            this.attackNum = new System.Windows.Forms.NumericUpDown();
            this.attackStatusEffect = new System.Windows.Forms.CheckedListBox();
            this.attackStatusUp = new System.Windows.Forms.CheckedListBox();
            this.buttonItemDescriptionBreak = new System.Windows.Forms.Button();
            this.buttonItemDescriptionEnd = new System.Windows.Forms.Button();
            this.CheckboxMonsterEfecNull = new System.Windows.Forms.CheckedListBox();
            this.CheckboxMonsterElemNull = new System.Windows.Forms.CheckedListBox();
            this.CheckboxMonsterElemWeak = new System.Windows.Forms.CheckedListBox();
            this.CheckboxMonsterProp = new System.Windows.Forms.CheckedListBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableHelpTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAttack = new System.Windows.Forms.NumericUpDown();
            this.itemAttackRange = new System.Windows.Forms.NumericUpDown();
            this.itemCoinValue = new System.Windows.Forms.NumericUpDown();
            this.itemCursorRestore = new System.Windows.Forms.CheckedListBox();
            this.itemDefense = new System.Windows.Forms.NumericUpDown();
            this.itemElemNull = new System.Windows.Forms.CheckedListBox();
            this.itemElemWeak = new System.Windows.Forms.CheckedListBox();
            this.itemMagicAttack = new System.Windows.Forms.NumericUpDown();
            this.itemMagicDefense = new System.Windows.Forms.NumericUpDown();
            this.itemNameIcon = new System.Windows.Forms.ComboBox();
            this.itemNum = new System.Windows.Forms.NumericUpDown();
            this.itemPower = new System.Windows.Forms.NumericUpDown();
            this.itemSpeed = new System.Windows.Forms.NumericUpDown();
            this.itemUsage = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.label185 = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.label197 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.LabelMonster = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monsterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formationPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.allComponentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monstersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialoguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battleDialoguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellTimingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.allComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MonsterNumber = new System.Windows.Forms.NumericUpDown();
            this.MonsterSoundOther = new System.Windows.Forms.ComboBox();
            this.MonsterSoundStrike = new System.Windows.Forms.ComboBox();
            this.numericUpDown100 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown103 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown104 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown107 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown108 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown110 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown111 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown112 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown113 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown114 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown117 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown118 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown119 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown120 = new System.Windows.Forms.NumericUpDown();
            this.startingCoins = new System.Windows.Forms.NumericUpDown();
            this.startingFrogCoins = new System.Windows.Forms.NumericUpDown();
            this.startingMaximumFP = new System.Windows.Forms.NumericUpDown();
            this.startingCurrentFP = new System.Windows.Forms.NumericUpDown();
            this.defensePlusBonus = new System.Windows.Forms.NumericUpDown();
            this.hpPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.attackPlus = new System.Windows.Forms.NumericUpDown();
            this.mgAttackPlus = new System.Windows.Forms.NumericUpDown();
            this.mgDefensePlus = new System.Windows.Forms.NumericUpDown();
            this.defensePlus = new System.Windows.Forms.NumericUpDown();
            this.hpPlus = new System.Windows.Forms.NumericUpDown();
            this.expNeeded = new System.Windows.Forms.NumericUpDown();
            this.mgDefensePlusBonus = new System.Windows.Forms.NumericUpDown();
            this.startingMgDefense = new System.Windows.Forms.NumericUpDown();
            this.startingDefense = new System.Windows.Forms.NumericUpDown();
            this.startingExperience = new System.Windows.Forms.NumericUpDown();
            this.startingSpeed = new System.Windows.Forms.NumericUpDown();
            this.startingMaximumHP = new System.Windows.Forms.NumericUpDown();
            this.startingCurrentHP = new System.Windows.Forms.NumericUpDown();
            this.attackPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.startingMgAttack = new System.Windows.Forms.NumericUpDown();
            this.mgAttackPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.packFormation1 = new System.Windows.Forms.NumericUpDown();
            this.packFormation2 = new System.Windows.Forms.NumericUpDown();
            this.packFormation3 = new System.Windows.Forms.NumericUpDown();
            this.packFormationButton1 = new System.Windows.Forms.Button();
            this.packFormationButton2 = new System.Windows.Forms.Button();
            this.packFormationButton3 = new System.Windows.Forms.Button();
            this.pictureBoxMonster = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel64 = new System.Windows.Forms.Panel();
            this.TextboxMonsterName = new System.Windows.Forms.TextBox();
            this.panel63 = new System.Windows.Forms.Panel();
            this.monsterName = new System.Windows.Forms.ComboBox();
            this.panel55 = new System.Windows.Forms.Panel();
            this.MonsterValFlowerOdds = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.MonsterFlowerBonus = new System.Windows.Forms.ComboBox();
            this.label209 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.LabelMonsterName = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.TextboxMonsterPsychoMsg = new System.Windows.Forms.RichTextBox();
            this.panel41 = new System.Windows.Forms.Panel();
            this.monsterNotesTextBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonPreviousFrame = new System.Windows.Forms.Button();
            this.label126 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonNextFrame = new System.Windows.Forms.Button();
            this.panel29 = new System.Windows.Forms.Panel();
            this.LabelMonsterValMgDef = new System.Windows.Forms.Label();
            this.LabelMonsterValSpeed = new System.Windows.Forms.Label();
            this.LabelMonsterValMgAtk = new System.Windows.Forms.Label();
            this.LabelMonsterValAtk = new System.Windows.Forms.Label();
            this.LabelMonsterValDef = new System.Windows.Forms.Label();
            this.LabelMonsterVitalStats = new System.Windows.Forms.Label();
            this.MonsterValAtk = new System.Windows.Forms.NumericUpDown();
            this.MonsterValMgDef = new System.Windows.Forms.NumericUpDown();
            this.MonsterValSpeed = new System.Windows.Forms.NumericUpDown();
            this.MonsterValFP = new System.Windows.Forms.NumericUpDown();
            this.MonsterValHP = new System.Windows.Forms.NumericUpDown();
            this.MonsterValMgAtk = new System.Windows.Forms.NumericUpDown();
            this.MonsterValDef = new System.Windows.Forms.NumericUpDown();
            this.LabelMonsterValFP = new System.Windows.Forms.Label();
            this.LabelMonsterValHP = new System.Windows.Forms.Label();
            this.LabelMonsterValEvd = new System.Windows.Forms.Label();
            this.MonsterValEvd = new System.Windows.Forms.NumericUpDown();
            this.LabelMonsterValMgEvd = new System.Windows.Forms.Label();
            this.MonsterValMgEvd = new System.Windows.Forms.NumericUpDown();
            this.panel62 = new System.Windows.Forms.Panel();
            this.MonsterYoshiCookie = new System.Windows.Forms.ComboBox();
            this.LabelMonsterYoshiCookie = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel72 = new System.Windows.Forms.Panel();
            this.ItemWinB = new System.Windows.Forms.ComboBox();
            this.panel73 = new System.Windows.Forms.Panel();
            this.ItemWinA = new System.Windows.Forms.ComboBox();
            this.LabelMonsterRewardStats = new System.Windows.Forms.Label();
            this.MonsterValExp = new System.Windows.Forms.NumericUpDown();
            this.MonsterValCoins = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel68 = new System.Windows.Forms.Panel();
            this.panel67 = new System.Windows.Forms.Panel();
            this.MonsterBehavior = new System.Windows.Forms.ComboBox();
            this.panel69 = new System.Windows.Forms.Panel();
            this.panel70 = new System.Windows.Forms.Panel();
            this.MonsterEntranceStyle = new System.Windows.Forms.ComboBox();
            this.panel71 = new System.Windows.Forms.Panel();
            this.MonsterCoinSize = new System.Windows.Forms.ComboBox();
            this.MonsterValElevation = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.panel65 = new System.Windows.Forms.Panel();
            this.MonsterMorphSuccess = new System.Windows.Forms.ComboBox();
            this.label216 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.pictureBoxPsychopath = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.panel201 = new System.Windows.Forms.Panel();
            this.searchFormationPacks = new System.Windows.Forms.Button();
            this.packNum = new System.Windows.Forms.NumericUpDown();
            this.label178 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.panel81 = new System.Windows.Forms.Panel();
            this.formationSet = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.panel39 = new System.Windows.Forms.Panel();
            this.battlefieldName = new System.Windows.Forms.ComboBox();
            this.panel37 = new System.Windows.Forms.Panel();
            this.formationNameList = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.formationNum = new System.Windows.Forms.NumericUpDown();
            this.panel36 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.formationName8 = new System.Windows.Forms.ComboBox();
            this.panel51 = new System.Windows.Forms.Panel();
            this.formationName7 = new System.Windows.Forms.ComboBox();
            this.panel75 = new System.Windows.Forms.Panel();
            this.formationName6 = new System.Windows.Forms.ComboBox();
            this.panel76 = new System.Windows.Forms.Panel();
            this.formationName5 = new System.Windows.Forms.ComboBox();
            this.panel77 = new System.Windows.Forms.Panel();
            this.formationName4 = new System.Windows.Forms.ComboBox();
            this.panel78 = new System.Windows.Forms.Panel();
            this.formationName3 = new System.Windows.Forms.ComboBox();
            this.panel79 = new System.Windows.Forms.Panel();
            this.formationName2 = new System.Windows.Forms.ComboBox();
            this.panel80 = new System.Windows.Forms.Panel();
            this.formationName1 = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.formationByte1 = new System.Windows.Forms.NumericUpDown();
            this.formationByte2 = new System.Windows.Forms.NumericUpDown();
            this.formationByte3 = new System.Windows.Forms.NumericUpDown();
            this.formationByte8 = new System.Windows.Forms.NumericUpDown();
            this.formationByte5 = new System.Windows.Forms.NumericUpDown();
            this.formationByte7 = new System.Windows.Forms.NumericUpDown();
            this.formationByte6 = new System.Windows.Forms.NumericUpDown();
            this.formationByte4 = new System.Windows.Forms.NumericUpDown();
            this.panelFormationUse = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panelFormationHide = new System.Windows.Forms.Panel();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.formationCoordY1 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY2 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY3 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY8 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY5 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY7 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY6 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordY4 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX1 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX2 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX3 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX8 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX5 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX7 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX6 = new System.Windows.Forms.NumericUpDown();
            this.formationCoordX4 = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxFormation = new System.Windows.Forms.PictureBox();
            this.panel52 = new System.Windows.Forms.Panel();
            this.formationCantRun = new System.Windows.Forms.CheckBox();
            this.panel82 = new System.Windows.Forms.Panel();
            this.formationMusic = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.formationUnknown = new System.Windows.Forms.NumericUpDown();
            this.label176 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.pictureBoxSpellDesc = new System.Windows.Forms.PictureBox();
            this.button33 = new System.Windows.Forms.Button();
            this.panelSpellDescription = new System.Windows.Forms.Panel();
            this.textBoxSpellDescription = new System.Windows.Forms.RichTextBox();
            this.button34 = new System.Windows.Forms.Button();
            this.panel92 = new System.Windows.Forms.Panel();
            this.textBoxAttackName = new System.Windows.Forms.TextBox();
            this.panel86 = new System.Windows.Forms.Panel();
            this.attackName = new System.Windows.Forms.ComboBox();
            this.panel85 = new System.Windows.Forms.Panel();
            this.panel87 = new System.Windows.Forms.Panel();
            this.textBoxSpellName = new System.Windows.Forms.TextBox();
            this.panel88 = new System.Windows.Forms.Panel();
            this.spellName = new System.Windows.Forms.ComboBox();
            this.attackAtkType = new System.Windows.Forms.CheckedListBox();
            this.label54 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.spellHitRate = new System.Windows.Forms.NumericUpDown();
            this.spellFPCost = new System.Windows.Forms.NumericUpDown();
            this.spellMagPower = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.spellStatusEffect = new System.Windows.Forms.CheckedListBox();
            this.spellStatusChange = new System.Windows.Forms.CheckedListBox();
            this.spellTargetting = new System.Windows.Forms.CheckedListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel218 = new System.Windows.Forms.Panel();
            this.panel219 = new System.Windows.Forms.Panel();
            this.panel171 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panelSpellNotes = new System.Windows.Forms.Panel();
            this.textBoxAttackNotes = new System.Windows.Forms.RichTextBox();
            this.panel170 = new System.Windows.Forms.Panel();
            this.label68 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.richTextBox9 = new System.Windows.Forms.RichTextBox();
            this.panel169 = new System.Windows.Forms.Panel();
            this.panel166 = new System.Windows.Forms.Panel();
            this.panel168 = new System.Windows.Forms.Panel();
            this.panel165 = new System.Windows.Forms.Panel();
            this.panel167 = new System.Windows.Forms.Panel();
            this.panel164 = new System.Windows.Forms.Panel();
            this.panel163 = new System.Windows.Forms.Panel();
            this.panel162 = new System.Windows.Forms.Panel();
            this.panel161 = new System.Windows.Forms.Panel();
            this.spellNum = new System.Windows.Forms.NumericUpDown();
            this.panel160 = new System.Windows.Forms.Panel();
            this.panel156 = new System.Windows.Forms.Panel();
            this.panel159 = new System.Windows.Forms.Panel();
            this.panel155 = new System.Windows.Forms.Panel();
            this.spellAttackProp = new System.Windows.Forms.CheckedListBox();
            this.panel158 = new System.Windows.Forms.Panel();
            this.panel154 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.panel157 = new System.Windows.Forms.Panel();
            this.panel153 = new System.Windows.Forms.Panel();
            this.label62 = new System.Windows.Forms.Label();
            this.panel152 = new System.Windows.Forms.Panel();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel89 = new System.Windows.Forms.Panel();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.panel90 = new System.Windows.Forms.Panel();
            this.spellFunction = new System.Windows.Forms.ComboBox();
            this.panel91 = new System.Windows.Forms.Panel();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel151 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.panel94 = new System.Windows.Forms.Panel();
            this.itemName = new System.Windows.Forms.ComboBox();
            this.panel100 = new System.Windows.Forms.Panel();
            this.shopName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.panel61 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.panel103 = new System.Windows.Forms.Panel();
            this.shopItem14 = new System.Windows.Forms.ComboBox();
            this.panel104 = new System.Windows.Forms.Panel();
            this.shopItem13 = new System.Windows.Forms.ComboBox();
            this.panel102 = new System.Windows.Forms.Panel();
            this.shopItem15 = new System.Windows.Forms.ComboBox();
            this.panel105 = new System.Windows.Forms.Panel();
            this.shopItem12 = new System.Windows.Forms.ComboBox();
            this.panel106 = new System.Windows.Forms.Panel();
            this.shopItem11 = new System.Windows.Forms.ComboBox();
            this.panel107 = new System.Windows.Forms.Panel();
            this.shopItem10 = new System.Windows.Forms.ComboBox();
            this.panel108 = new System.Windows.Forms.Panel();
            this.shopItem9 = new System.Windows.Forms.ComboBox();
            this.panel109 = new System.Windows.Forms.Panel();
            this.shopItem8 = new System.Windows.Forms.ComboBox();
            this.panel110 = new System.Windows.Forms.Panel();
            this.shopItem7 = new System.Windows.Forms.ComboBox();
            this.panel111 = new System.Windows.Forms.Panel();
            this.shopItem6 = new System.Windows.Forms.ComboBox();
            this.panel112 = new System.Windows.Forms.Panel();
            this.shopItem5 = new System.Windows.Forms.ComboBox();
            this.panel113 = new System.Windows.Forms.Panel();
            this.shopItem4 = new System.Windows.Forms.ComboBox();
            this.panel114 = new System.Windows.Forms.Panel();
            this.shopItem3 = new System.Windows.Forms.ComboBox();
            this.panel115 = new System.Windows.Forms.Panel();
            this.shopItem2 = new System.Windows.Forms.ComboBox();
            this.panel116 = new System.Windows.Forms.Panel();
            this.shopItem1 = new System.Windows.Forms.ComboBox();
            this.label180 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.shopNum = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelItemDesc = new System.Windows.Forms.Panel();
            this.label195 = new System.Windows.Forms.Label();
            this.pictureBoxItemDesc = new System.Windows.Forms.PictureBox();
            this.panel228 = new System.Windows.Forms.Panel();
            this.panel229 = new System.Windows.Forms.Panel();
            this.panel226 = new System.Windows.Forms.Panel();
            this.panel227 = new System.Windows.Forms.Panel();
            this.panel195 = new System.Windows.Forms.Panel();
            this.panel192 = new System.Windows.Forms.Panel();
            this.shopDiscounts = new System.Windows.Forms.CheckedListBox();
            this.panel193 = new System.Windows.Forms.Panel();
            this.panel194 = new System.Windows.Forms.Panel();
            this.shopBuyOptions = new System.Windows.Forms.CheckedListBox();
            this.panel191 = new System.Windows.Forms.Panel();
            this.label190 = new System.Windows.Forms.Label();
            this.labelShopLabel = new System.Windows.Forms.Label();
            this.panel223 = new System.Windows.Forms.Panel();
            this.shopLabel = new System.Windows.Forms.TextBox();
            this.panel190 = new System.Windows.Forms.Panel();
            this.panel189 = new System.Windows.Forms.Panel();
            this.label89 = new System.Windows.Forms.Label();
            this.panel187 = new System.Windows.Forms.Panel();
            this.panel181 = new System.Windows.Forms.Panel();
            this.label101 = new System.Windows.Forms.Label();
            this.itemStatusEffect = new System.Windows.Forms.CheckedListBox();
            this.panel185 = new System.Windows.Forms.Panel();
            this.panel180 = new System.Windows.Forms.Panel();
            this.label99 = new System.Windows.Forms.Label();
            this.itemStatusChange = new System.Windows.Forms.CheckedListBox();
            this.panel188 = new System.Windows.Forms.Panel();
            this.panel183 = new System.Windows.Forms.Panel();
            this.label67 = new System.Windows.Forms.Label();
            this.panel186 = new System.Windows.Forms.Panel();
            this.panel182 = new System.Windows.Forms.Panel();
            this.label86 = new System.Windows.Forms.Label();
            this.itemWhoEquip = new System.Windows.Forms.CheckedListBox();
            this.panel184 = new System.Windows.Forms.Panel();
            this.panel179 = new System.Windows.Forms.Panel();
            this.label85 = new System.Windows.Forms.Label();
            this.itemTargetting = new System.Windows.Forms.CheckedListBox();
            this.panel178 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.panel177 = new System.Windows.Forms.Panel();
            this.panel176 = new System.Windows.Forms.Panel();
            this.buttonPreviewItemDesc = new System.Windows.Forms.Button();
            this.panelItemDescription = new System.Windows.Forms.Panel();
            this.textBoxItemDescription = new System.Windows.Forms.RichTextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.panel175 = new System.Windows.Forms.Panel();
            this.panel60 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.panel95 = new System.Windows.Forms.Panel();
            this.itemCursor = new System.Windows.Forms.ComboBox();
            this.panel174 = new System.Windows.Forms.Panel();
            this.panel173 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel96 = new System.Windows.Forms.Panel();
            this.itemType = new System.Windows.Forms.ComboBox();
            this.panel97 = new System.Windows.Forms.Panel();
            this.itemAttackType = new System.Windows.Forms.ComboBox();
            this.panel98 = new System.Windows.Forms.Panel();
            this.itemFunction = new System.Windows.Forms.ComboBox();
            this.panel99 = new System.Windows.Forms.Panel();
            this.itemElemAttack = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.panel172 = new System.Windows.Forms.Panel();
            this.panel93 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel117 = new System.Windows.Forms.Panel();
            this.textBoxCharacterName = new System.Windows.Forms.TextBox();
            this.panel118 = new System.Windows.Forms.Panel();
            this.label188 = new System.Windows.Forms.Label();
            this.startingAttack = new System.Windows.Forms.NumericUpDown();
            this.startingLevel = new System.Windows.Forms.NumericUpDown();
            this.panel28 = new System.Windows.Forms.Panel();
            this.startingWeapon = new System.Windows.Forms.ComboBox();
            this.panel120 = new System.Windows.Forms.Panel();
            this.startingAccessory = new System.Windows.Forms.ComboBox();
            this.panel119 = new System.Windows.Forms.Panel();
            this.startingArmor = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.startingMagic = new System.Windows.Forms.CheckedListBox();
            this.panel121 = new System.Windows.Forms.Panel();
            this.slotNum = new System.Windows.Forms.NumericUpDown();
            this.label92 = new System.Windows.Forms.Label();
            this.panel122 = new System.Windows.Forms.Panel();
            this.startingItem = new System.Windows.Forms.ComboBox();
            this.panel124 = new System.Windows.Forms.Panel();
            this.startingSpecialItem = new System.Windows.Forms.ComboBox();
            this.panel123 = new System.Windows.Forms.Panel();
            this.startingEquipment = new System.Windows.Forms.ComboBox();
            this.panel47 = new System.Windows.Forms.Panel();
            this.characterName = new System.Windows.Forms.ComboBox();
            this.label94 = new System.Windows.Forms.Label();
            this.characterNum = new System.Windows.Forms.NumericUpDown();
            this.panel46 = new System.Windows.Forms.Panel();
            this.panel230 = new System.Windows.Forms.Panel();
            this.panel231 = new System.Windows.Forms.Panel();
            this.label192 = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.panel232 = new System.Windows.Forms.Panel();
            this.levelUpSpellLearned = new System.Windows.Forms.ComboBox();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.panel48 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.label136 = new System.Windows.Forms.Label();
            this.panel125 = new System.Windows.Forms.Panel();
            this.panel126 = new System.Windows.Forms.Panel();
            this.panel224 = new System.Windows.Forms.Panel();
            this.panel225 = new System.Windows.Forms.Panel();
            this.panel199 = new System.Windows.Forms.Panel();
            this.panel198 = new System.Windows.Forms.Panel();
            this.panel197 = new System.Windows.Forms.Panel();
            this.panel101 = new System.Windows.Forms.Panel();
            this.levelNum = new System.Windows.Forms.NumericUpDown();
            this.panel196 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label194 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label202 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.instanceNumberName = new System.Windows.Forms.ComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.multipleTimingSpellName = new System.Windows.Forms.ComboBox();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel220 = new System.Windows.Forms.Panel();
            this.panel221 = new System.Windows.Forms.Panel();
            this.panel211 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label184 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.numericUpDown102 = new System.Windows.Forms.NumericUpDown();
            this.panel210 = new System.Windows.Forms.Panel();
            this.panel209 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label183 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.padRotationSpellName = new System.Windows.Forms.ComboBox();
            this.panel208 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label186 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.fireballName = new System.Windows.Forms.ComboBox();
            this.numericUpDown106 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown105 = new System.Windows.Forms.NumericUpDown();
            this.label145 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.panel207 = new System.Windows.Forms.Panel();
            this.panel129 = new System.Windows.Forms.Panel();
            this.GenoChargeOverflow = new System.Windows.Forms.TrackBar();
            this.label167 = new System.Windows.Forms.Label();
            this.GenoLevel4Frame = new System.Windows.Forms.TrackBar();
            this.GenoLevel3Frame = new System.Windows.Forms.TrackBar();
            this.GenoLevel2Frame = new System.Windows.Forms.TrackBar();
            this.panel206 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.spell2Level1FrameEnd = new System.Windows.Forms.TrackBar();
            this.panel130 = new System.Windows.Forms.Panel();
            this.level2TimingSpellName = new System.Windows.Forms.ComboBox();
            this.spell2Level2FrameEnd = new System.Windows.Forms.TrackBar();
            this.label123 = new System.Windows.Forms.Label();
            this.spell2Level2FrameStart = new System.Windows.Forms.TrackBar();
            this.panel205 = new System.Windows.Forms.Panel();
            this.panel128 = new System.Windows.Forms.Panel();
            this.panel131 = new System.Windows.Forms.Panel();
            this.level1TimingSpellName = new System.Windows.Forms.ComboBox();
            this.spell1TimingFrameSpan = new System.Windows.Forms.TrackBar();
            this.panel204 = new System.Windows.Forms.Panel();
            this.panel50 = new System.Windows.Forms.Panel();
            this.lvl1TimingEnd = new System.Windows.Forms.TrackBar();
            this.lvl2TimingStart = new System.Windows.Forms.TrackBar();
            this.lvl2TimingEnd = new System.Windows.Forms.TrackBar();
            this.panel132 = new System.Windows.Forms.Panel();
            this.weaponName = new System.Windows.Forms.ComboBox();
            this.lvl1TimingStart = new System.Windows.Forms.TrackBar();
            this.label111 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label112 = new System.Windows.Forms.Label();
            this.panel127 = new System.Windows.Forms.Panel();
            this.weaponOrDefense = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel214 = new System.Windows.Forms.Panel();
            this.panel215 = new System.Windows.Forms.Panel();
            this.panel212 = new System.Windows.Forms.Panel();
            this.panel213 = new System.Windows.Forms.Panel();
            this.panel141 = new System.Windows.Forms.Panel();
            this.panel140 = new System.Windows.Forms.Panel();
            this.panel139 = new System.Windows.Forms.Panel();
            this.panel138 = new System.Windows.Forms.Panel();
            this.panel133 = new System.Windows.Forms.Panel();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panel137 = new System.Windows.Forms.Panel();
            this.panel53 = new System.Windows.Forms.Panel();
            this.panel136 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel135 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel134 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel202 = new System.Windows.Forms.Panel();
            this.panel222 = new System.Windows.Forms.Panel();
            this.monsterTargetArrowY = new System.Windows.Forms.NumericUpDown();
            this.monsterTargetArrowX = new System.Windows.Forms.NumericUpDown();
            this.label110 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label187 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel142 = new System.Windows.Forms.Panel();
            this.panel150 = new System.Windows.Forms.Panel();
            this.panel149 = new System.Windows.Forms.Panel();
            this.panel148 = new System.Windows.Forms.Panel();
            this.panel147 = new System.Windows.Forms.Panel();
            this.panel146 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel145 = new System.Windows.Forms.Panel();
            this.panel144 = new System.Windows.Forms.Panel();
            this.searchFormationNames = new System.Windows.Forms.Button();
            this.panel143 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panelSearchFormationPacks = new System.Windows.Forms.Panel();
            this.treeViewPackNames = new System.Windows.Forms.TreeView();
            this.panel203 = new System.Windows.Forms.Panel();
            this.packNameTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelToolTip = new System.Windows.Forms.Label();
            this.formationBattleEvent = new System.Windows.Forms.NumericUpDown();
            this.label140 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.panel74 = new System.Windows.Forms.Panel();
            this.musicTrack = new System.Windows.Forms.ComboBox();
            this.panel216 = new System.Windows.Forms.Panel();
            this.panel217 = new System.Windows.Forms.Panel();
            this.panelSearchFormationNames.SuspendLayout();
            this.panel200.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackAtkLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackHitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemAttackRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCoinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMagicAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMagicDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpeed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCoins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingFrogCoins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMaximumFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCurrentFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expNeeded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMgDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingExperience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMaximumHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCurrentHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMgAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).BeginInit();
            this.panel64.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValFlowerOdds)).BeginInit();
            this.panel66.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValAtk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgAtk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValEvd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgEvd)).BeginInit();
            this.panel62.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panel73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValCoins)).BeginInit();
            this.panel56.SuspendLayout();
            this.panel68.SuspendLayout();
            this.panel67.SuspendLayout();
            this.panel69.SuspendLayout();
            this.panel70.SuspendLayout();
            this.panel71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValElevation)).BeginInit();
            this.panel65.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsychopath)).BeginInit();
            this.panel83.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packNum)).BeginInit();
            this.panel81.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formationNum)).BeginInit();
            this.panel36.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel75.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel80.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte4)).BeginInit();
            this.panelFormationUse.SuspendLayout();
            this.panelFormationHide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormation)).BeginInit();
            this.panel52.SuspendLayout();
            this.panel82.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formationUnknown)).BeginInit();
            this.panel45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpellDesc)).BeginInit();
            this.panelSpellDescription.SuspendLayout();
            this.panel92.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel88.SuspendLayout();
            this.panel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellHitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spellFPCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spellMagPower)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel218.SuspendLayout();
            this.panel171.SuspendLayout();
            this.panelSpellNotes.SuspendLayout();
            this.panel170.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel169.SuspendLayout();
            this.panel166.SuspendLayout();
            this.panel168.SuspendLayout();
            this.panel165.SuspendLayout();
            this.panel167.SuspendLayout();
            this.panel164.SuspendLayout();
            this.panel163.SuspendLayout();
            this.panel162.SuspendLayout();
            this.panel161.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellNum)).BeginInit();
            this.panel160.SuspendLayout();
            this.panel156.SuspendLayout();
            this.panel159.SuspendLayout();
            this.panel155.SuspendLayout();
            this.panel158.SuspendLayout();
            this.panel154.SuspendLayout();
            this.panel157.SuspendLayout();
            this.panel153.SuspendLayout();
            this.panel152.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel89.SuspendLayout();
            this.panel90.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel84.SuspendLayout();
            this.panel151.SuspendLayout();
            this.panel94.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel61.SuspendLayout();
            this.panel59.SuspendLayout();
            this.panel103.SuspendLayout();
            this.panel104.SuspendLayout();
            this.panel102.SuspendLayout();
            this.panel105.SuspendLayout();
            this.panel106.SuspendLayout();
            this.panel107.SuspendLayout();
            this.panel108.SuspendLayout();
            this.panel109.SuspendLayout();
            this.panel110.SuspendLayout();
            this.panel111.SuspendLayout();
            this.panel112.SuspendLayout();
            this.panel113.SuspendLayout();
            this.panel114.SuspendLayout();
            this.panel115.SuspendLayout();
            this.panel116.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopNum)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelItemDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemDesc)).BeginInit();
            this.panel228.SuspendLayout();
            this.panel226.SuspendLayout();
            this.panel195.SuspendLayout();
            this.panel192.SuspendLayout();
            this.panel193.SuspendLayout();
            this.panel194.SuspendLayout();
            this.panel191.SuspendLayout();
            this.panel223.SuspendLayout();
            this.panel190.SuspendLayout();
            this.panel189.SuspendLayout();
            this.panel187.SuspendLayout();
            this.panel181.SuspendLayout();
            this.panel185.SuspendLayout();
            this.panel180.SuspendLayout();
            this.panel188.SuspendLayout();
            this.panel183.SuspendLayout();
            this.panel186.SuspendLayout();
            this.panel182.SuspendLayout();
            this.panel184.SuspendLayout();
            this.panel179.SuspendLayout();
            this.panel178.SuspendLayout();
            this.panel177.SuspendLayout();
            this.panel176.SuspendLayout();
            this.panelItemDescription.SuspendLayout();
            this.panel175.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel95.SuspendLayout();
            this.panel174.SuspendLayout();
            this.panel173.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel96.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panel99.SuspendLayout();
            this.panel172.SuspendLayout();
            this.panel93.SuspendLayout();
            this.panel117.SuspendLayout();
            this.panel118.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startingAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingLevel)).BeginInit();
            this.panel28.SuspendLayout();
            this.panel120.SuspendLayout();
            this.panel119.SuspendLayout();
            this.panel121.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotNum)).BeginInit();
            this.panel122.SuspendLayout();
            this.panel124.SuspendLayout();
            this.panel123.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterNum)).BeginInit();
            this.panel46.SuspendLayout();
            this.panel230.SuspendLayout();
            this.panel231.SuspendLayout();
            this.panel232.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel125.SuspendLayout();
            this.panel224.SuspendLayout();
            this.panel199.SuspendLayout();
            this.panel198.SuspendLayout();
            this.panel197.SuspendLayout();
            this.panel101.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).BeginInit();
            this.panel196.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel220.SuspendLayout();
            this.panel211.SuspendLayout();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown102)).BeginInit();
            this.panel210.SuspendLayout();
            this.panel209.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel208.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown105)).BeginInit();
            this.panel207.SuspendLayout();
            this.panel129.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GenoChargeOverflow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel4Frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel3Frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel2Frame)).BeginInit();
            this.panel206.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level1FrameEnd)).BeginInit();
            this.panel130.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level2FrameEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level2FrameStart)).BeginInit();
            this.panel205.SuspendLayout();
            this.panel128.SuspendLayout();
            this.panel131.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spell1TimingFrameSpan)).BeginInit();
            this.panel204.SuspendLayout();
            this.panel50.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvl1TimingEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2TimingStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2TimingEnd)).BeginInit();
            this.panel132.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvl1TimingStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.panel127.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel214.SuspendLayout();
            this.panel212.SuspendLayout();
            this.panel141.SuspendLayout();
            this.panel140.SuspendLayout();
            this.panel139.SuspendLayout();
            this.panel138.SuspendLayout();
            this.panel133.SuspendLayout();
            this.panel137.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel136.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel135.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel134.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel202.SuspendLayout();
            this.panel222.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterTargetArrowY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterTargetArrowX)).BeginInit();
            this.panel23.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel142.SuspendLayout();
            this.panel150.SuspendLayout();
            this.panel149.SuspendLayout();
            this.panel148.SuspendLayout();
            this.panel147.SuspendLayout();
            this.panel146.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel145.SuspendLayout();
            this.panel144.SuspendLayout();
            this.panel143.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panelSearchFormationPacks.SuspendLayout();
            this.panel203.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formationBattleEvent)).BeginInit();
            this.panel74.SuspendLayout();
            this.panel216.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearchFormationNames
            // 
            this.panelSearchFormationNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchFormationNames.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchFormationNames.Controls.Add(this.listBoxFormationNames);
            this.panelSearchFormationNames.Controls.Add(this.panel200);
            this.panelSearchFormationNames.Location = new System.Drawing.Point(6, 25);
            this.panelSearchFormationNames.Name = "panelSearchFormationNames";
            this.panelSearchFormationNames.Size = new System.Drawing.Size(454, 426);
            this.panelSearchFormationNames.TabIndex = 551;
            this.panelSearchFormationNames.Visible = false;
            // 
            // listBoxFormationNames
            // 
            this.listBoxFormationNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFormationNames.FormattingEnabled = true;
            this.listBoxFormationNames.Location = new System.Drawing.Point(2, 21);
            this.listBoxFormationNames.Name = "listBoxFormationNames";
            this.listBoxFormationNames.Size = new System.Drawing.Size(450, 403);
            this.listBoxFormationNames.TabIndex = 194;
            this.listBoxFormationNames.SelectedIndexChanged += new System.EventHandler(this.listBoxFormationNames_SelectedIndexChanged);
            this.listBoxFormationNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxFormationNames_KeyDown);
            // 
            // panel200
            // 
            this.panel200.BackColor = System.Drawing.SystemColors.Window;
            this.panel200.Controls.Add(this.nameTextBox);
            this.panel200.Location = new System.Drawing.Point(2, 2);
            this.panel200.Name = "panel200";
            this.panel200.Size = new System.Drawing.Size(450, 17);
            this.panel200.TabIndex = 193;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Location = new System.Drawing.Point(4, 2);
            this.nameTextBox.MaxLength = 128;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(444, 14);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // attackAtkLevel
            // 
            this.attackAtkLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackAtkLevel.Location = new System.Drawing.Point(100, 37);
            this.attackAtkLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.attackAtkLevel.Name = "attackAtkLevel";
            this.attackAtkLevel.Size = new System.Drawing.Size(96, 17);
            this.attackAtkLevel.TabIndex = 124;
            this.attackAtkLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackAtkLevel.ValueChanged += new System.EventHandler(this.attackAtkLevel_ValueChanged);
            // 
            // attackHitRate
            // 
            this.attackHitRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackHitRate.Location = new System.Drawing.Point(100, 19);
            this.attackHitRate.Name = "attackHitRate";
            this.attackHitRate.Size = new System.Drawing.Size(96, 17);
            this.attackHitRate.TabIndex = 123;
            this.attackHitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackHitRate.ValueChanged += new System.EventHandler(this.attackHitRate_ValueChanged);
            // 
            // attackNum
            // 
            this.attackNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attackNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackNum.ForeColor = System.Drawing.SystemColors.Control;
            this.attackNum.Location = new System.Drawing.Point(102, 2);
            this.attackNum.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.attackNum.Name = "attackNum";
            this.attackNum.Size = new System.Drawing.Size(96, 17);
            this.attackNum.TabIndex = 0;
            this.attackNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackNum.ValueChanged += new System.EventHandler(this.attackNum_ValueChanged);
            // 
            // attackStatusEffect
            // 
            this.attackStatusEffect.BackColor = System.Drawing.SystemColors.Window;
            this.attackStatusEffect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackStatusEffect.CheckOnClick = true;
            this.attackStatusEffect.ColumnWidth = 97;
            this.attackStatusEffect.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincible"});
            this.attackStatusEffect.Location = new System.Drawing.Point(0, 19);
            this.attackStatusEffect.Name = "attackStatusEffect";
            this.attackStatusEffect.Size = new System.Drawing.Size(195, 112);
            this.attackStatusEffect.TabIndex = 125;
            this.attackStatusEffect.SelectedIndexChanged += new System.EventHandler(this.attackStatusEffect_SelectedIndexChanged);
            // 
            // attackStatusUp
            // 
            this.attackStatusUp.BackColor = System.Drawing.SystemColors.Window;
            this.attackStatusUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackStatusUp.CheckOnClick = true;
            this.attackStatusUp.Items.AddRange(new object[] {
            "Attack",
            "Defense",
            "Magic Attack",
            "Magic Defense"});
            this.attackStatusUp.Location = new System.Drawing.Point(0, 19);
            this.attackStatusUp.Name = "attackStatusUp";
            this.attackStatusUp.Size = new System.Drawing.Size(195, 64);
            this.attackStatusUp.TabIndex = 126;
            this.attackStatusUp.SelectedIndexChanged += new System.EventHandler(this.attackStatusUp_SelectedIndexChanged);
            // 
            // buttonItemDescriptionBreak
            // 
            this.buttonItemDescriptionBreak.BackColor = System.Drawing.SystemColors.Window;
            this.buttonItemDescriptionBreak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemDescriptionBreak.Location = new System.Drawing.Point(-1, 110);
            this.buttonItemDescriptionBreak.Name = "buttonItemDescriptionBreak";
            this.buttonItemDescriptionBreak.Size = new System.Drawing.Size(99, 19);
            this.buttonItemDescriptionBreak.TabIndex = 154;
            this.buttonItemDescriptionBreak.Text = "NEW LINE";
            this.buttonItemDescriptionBreak.UseCompatibleTextRendering = true;
            this.buttonItemDescriptionBreak.UseVisualStyleBackColor = false;
            this.buttonItemDescriptionBreak.Click += new System.EventHandler(this.buttonItemDescriptionBreak_Click);
            // 
            // buttonItemDescriptionEnd
            // 
            this.buttonItemDescriptionEnd.BackColor = System.Drawing.SystemColors.Window;
            this.buttonItemDescriptionEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemDescriptionEnd.Location = new System.Drawing.Point(97, 110);
            this.buttonItemDescriptionEnd.Name = "buttonItemDescriptionEnd";
            this.buttonItemDescriptionEnd.Size = new System.Drawing.Size(100, 19);
            this.buttonItemDescriptionEnd.TabIndex = 155;
            this.buttonItemDescriptionEnd.Text = "END";
            this.buttonItemDescriptionEnd.UseCompatibleTextRendering = true;
            this.buttonItemDescriptionEnd.UseVisualStyleBackColor = false;
            this.buttonItemDescriptionEnd.Click += new System.EventHandler(this.buttonItemDescriptionEnd_Click);
            // 
            // CheckboxMonsterEfecNull
            // 
            this.CheckboxMonsterEfecNull.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckboxMonsterEfecNull.CheckOnClick = true;
            this.CheckboxMonsterEfecNull.ColumnWidth = 96;
            this.CheckboxMonsterEfecNull.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincibility"});
            this.CheckboxMonsterEfecNull.Location = new System.Drawing.Point(0, 19);
            this.CheckboxMonsterEfecNull.MultiColumn = true;
            this.CheckboxMonsterEfecNull.Name = "CheckboxMonsterEfecNull";
            this.CheckboxMonsterEfecNull.Size = new System.Drawing.Size(194, 112);
            this.CheckboxMonsterEfecNull.TabIndex = 30;
            this.CheckboxMonsterEfecNull.SelectedIndexChanged += new System.EventHandler(this.CheckboxMonsterEfecNull_SelectedIndexChanged);
            // 
            // CheckboxMonsterElemNull
            // 
            this.CheckboxMonsterElemNull.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckboxMonsterElemNull.CheckOnClick = true;
            this.CheckboxMonsterElemNull.Items.AddRange(new object[] {
            "Ice",
            "Fire",
            "Thunder",
            "Jump"});
            this.CheckboxMonsterElemNull.Location = new System.Drawing.Point(0, 19);
            this.CheckboxMonsterElemNull.Name = "CheckboxMonsterElemNull";
            this.CheckboxMonsterElemNull.Size = new System.Drawing.Size(194, 64);
            this.CheckboxMonsterElemNull.TabIndex = 28;
            this.CheckboxMonsterElemNull.SelectedIndexChanged += new System.EventHandler(this.CheckboxMonsterElemNull_SelectedIndexChanged);
            // 
            // CheckboxMonsterElemWeak
            // 
            this.CheckboxMonsterElemWeak.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckboxMonsterElemWeak.CheckOnClick = true;
            this.CheckboxMonsterElemWeak.Items.AddRange(new object[] {
            "Ice",
            "Fire",
            "Thunder",
            "Jump"});
            this.CheckboxMonsterElemWeak.Location = new System.Drawing.Point(0, 19);
            this.CheckboxMonsterElemWeak.Name = "CheckboxMonsterElemWeak";
            this.CheckboxMonsterElemWeak.Size = new System.Drawing.Size(194, 64);
            this.CheckboxMonsterElemWeak.TabIndex = 27;
            this.CheckboxMonsterElemWeak.SelectedIndexChanged += new System.EventHandler(this.CheckboxMonsterElemWeak_SelectedIndexChanged);
            // 
            // CheckboxMonsterProp
            // 
            this.CheckboxMonsterProp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckboxMonsterProp.CheckOnClick = true;
            this.CheckboxMonsterProp.Items.AddRange(new object[] {
            "Invincible",
            "Mortality Protection",
            "Disable Auto-Death",
            "Share palette"});
            this.CheckboxMonsterProp.Location = new System.Drawing.Point(0, 19);
            this.CheckboxMonsterProp.Name = "CheckboxMonsterProp";
            this.CheckboxMonsterProp.Size = new System.Drawing.Size(194, 64);
            this.CheckboxMonsterProp.TabIndex = 29;
            this.CheckboxMonsterProp.SelectedIndexChanged += new System.EventHandler(this.CheckboxMonsterProp_SelectedIndexChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableHelpTipsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // enableHelpTipsToolStripMenuItem
            // 
            this.enableHelpTipsToolStripMenuItem.AutoSize = false;
            this.enableHelpTipsToolStripMenuItem.CheckOnClick = true;
            this.enableHelpTipsToolStripMenuItem.Name = "enableHelpTipsToolStripMenuItem";
            this.enableHelpTipsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.enableHelpTipsToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.enableHelpTipsToolStripMenuItem.Text = "Enable Help Tips";
            // 
            // itemAttack
            // 
            this.itemAttack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemAttack.Location = new System.Drawing.Point(99, 91);
            this.itemAttack.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.itemAttack.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.itemAttack.Name = "itemAttack";
            this.itemAttack.Size = new System.Drawing.Size(98, 17);
            this.itemAttack.TabIndex = 139;
            this.itemAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemAttack.ValueChanged += new System.EventHandler(this.itemAttack_ValueChanged);
            // 
            // itemAttackRange
            // 
            this.itemAttackRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemAttackRange.Location = new System.Drawing.Point(99, 55);
            this.itemAttackRange.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.itemAttackRange.Name = "itemAttackRange";
            this.itemAttackRange.Size = new System.Drawing.Size(98, 17);
            this.itemAttackRange.TabIndex = 137;
            this.itemAttackRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemAttackRange.ValueChanged += new System.EventHandler(this.itemAttackRange_ValueChanged);
            // 
            // itemCoinValue
            // 
            this.itemCoinValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemCoinValue.Location = new System.Drawing.Point(99, 19);
            this.itemCoinValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.itemCoinValue.Name = "itemCoinValue";
            this.itemCoinValue.Size = new System.Drawing.Size(98, 17);
            this.itemCoinValue.TabIndex = 135;
            this.itemCoinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemCoinValue.ValueChanged += new System.EventHandler(this.itemCoinValue_ValueChanged);
            // 
            // itemCursorRestore
            // 
            this.itemCursorRestore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemCursorRestore.CheckOnClick = true;
            this.itemCursorRestore.ColumnWidth = 96;
            this.itemCursorRestore.Items.AddRange(new object[] {
            "Restore Only if FP less than max",
            "Restore Only if HP less than max"});
            this.itemCursorRestore.Location = new System.Drawing.Point(0, 37);
            this.itemCursorRestore.Name = "itemCursorRestore";
            this.itemCursorRestore.Size = new System.Drawing.Size(204, 32);
            this.itemCursorRestore.TabIndex = 158;
            this.itemCursorRestore.SelectedIndexChanged += new System.EventHandler(this.itemCursorRestore_SelectedIndexChanged);
            // 
            // itemDefense
            // 
            this.itemDefense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemDefense.Location = new System.Drawing.Point(99, 109);
            this.itemDefense.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.itemDefense.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.itemDefense.Name = "itemDefense";
            this.itemDefense.Size = new System.Drawing.Size(98, 17);
            this.itemDefense.TabIndex = 140;
            this.itemDefense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemDefense.ValueChanged += new System.EventHandler(this.itemDefense_ValueChanged);
            // 
            // itemElemNull
            // 
            this.itemElemNull.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemElemNull.CheckOnClick = true;
            this.itemElemNull.ColumnWidth = 100;
            this.itemElemNull.Items.AddRange(new object[] {
            "Ice",
            "Fire",
            "Thunder",
            "Jump"});
            this.itemElemNull.Location = new System.Drawing.Point(0, 19);
            this.itemElemNull.MultiColumn = true;
            this.itemElemNull.Name = "itemElemNull";
            this.itemElemNull.Size = new System.Drawing.Size(204, 32);
            this.itemElemNull.TabIndex = 147;
            this.itemElemNull.SelectedIndexChanged += new System.EventHandler(this.itemElemNull_SelectedIndexChanged);
            // 
            // itemElemWeak
            // 
            this.itemElemWeak.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemElemWeak.CheckOnClick = true;
            this.itemElemWeak.ColumnWidth = 100;
            this.itemElemWeak.Items.AddRange(new object[] {
            "Ice",
            "Fire",
            "Thunder",
            "Jump"});
            this.itemElemWeak.Location = new System.Drawing.Point(0, 19);
            this.itemElemWeak.MultiColumn = true;
            this.itemElemWeak.Name = "itemElemWeak";
            this.itemElemWeak.Size = new System.Drawing.Size(204, 32);
            this.itemElemWeak.TabIndex = 148;
            this.itemElemWeak.SelectedIndexChanged += new System.EventHandler(this.itemElemWeak_SelectedIndexChanged);
            // 
            // itemMagicAttack
            // 
            this.itemMagicAttack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemMagicAttack.Location = new System.Drawing.Point(99, 127);
            this.itemMagicAttack.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.itemMagicAttack.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.itemMagicAttack.Name = "itemMagicAttack";
            this.itemMagicAttack.Size = new System.Drawing.Size(98, 17);
            this.itemMagicAttack.TabIndex = 141;
            this.itemMagicAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemMagicAttack.ValueChanged += new System.EventHandler(this.itemMagicAttack_ValueChanged);
            // 
            // itemMagicDefense
            // 
            this.itemMagicDefense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemMagicDefense.Location = new System.Drawing.Point(99, 145);
            this.itemMagicDefense.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.itemMagicDefense.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.itemMagicDefense.Name = "itemMagicDefense";
            this.itemMagicDefense.Size = new System.Drawing.Size(98, 17);
            this.itemMagicDefense.TabIndex = 142;
            this.itemMagicDefense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemMagicDefense.ValueChanged += new System.EventHandler(this.itemMagicDefense_ValueChanged);
            // 
            // itemNameIcon
            // 
            this.itemNameIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.itemNameIcon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.itemNameIcon.DropDownHeight = 250;
            this.itemNameIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemNameIcon.IntegralHeight = false;
            this.itemNameIcon.Location = new System.Drawing.Point(-2, -2);
            this.itemNameIcon.Name = "itemNameIcon";
            this.itemNameIcon.Size = new System.Drawing.Size(102, 22);
            this.itemNameIcon.TabIndex = 326;
            this.itemNameIcon.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemNameIcon_DrawItem);
            this.itemNameIcon.SelectedIndexChanged += new System.EventHandler(this.itemNameIcon_SelectedIndexChanged);
            // 
            // itemNum
            // 
            this.itemNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNum.ForeColor = System.Drawing.SystemColors.Control;
            this.itemNum.Location = new System.Drawing.Point(102, 2);
            this.itemNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.itemNum.Name = "itemNum";
            this.itemNum.Size = new System.Drawing.Size(97, 17);
            this.itemNum.TabIndex = 0;
            this.itemNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemNum.ValueChanged += new System.EventHandler(this.itemNum_ValueChanged);
            // 
            // itemPower
            // 
            this.itemPower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemPower.Location = new System.Drawing.Point(99, 73);
            this.itemPower.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.itemPower.Name = "itemPower";
            this.itemPower.Size = new System.Drawing.Size(98, 17);
            this.itemPower.TabIndex = 138;
            this.itemPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemPower.ValueChanged += new System.EventHandler(this.itemPower_ValueChanged);
            // 
            // itemSpeed
            // 
            this.itemSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemSpeed.Location = new System.Drawing.Point(99, 37);
            this.itemSpeed.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.itemSpeed.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.itemSpeed.Name = "itemSpeed";
            this.itemSpeed.Size = new System.Drawing.Size(98, 17);
            this.itemSpeed.TabIndex = 136;
            this.itemSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemSpeed.ValueChanged += new System.EventHandler(this.itemSpeed_ValueChanged);
            // 
            // itemUsage
            // 
            this.itemUsage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemUsage.CheckOnClick = true;
            this.itemUsage.Items.AddRange(new object[] {
            "Mortality Protection",
            "Hide Battle Numerals",
            "Usable in Battle Menu",
            "Usable Overworld Menu",
            "Reusable"});
            this.itemUsage.Location = new System.Drawing.Point(0, 91);
            this.itemUsage.Name = "itemUsage";
            this.itemUsage.Size = new System.Drawing.Size(196, 80);
            this.itemUsage.TabIndex = 146;
            this.itemUsage.SelectedIndexChanged += new System.EventHandler(this.itemUsage_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label10.Size = new System.Drawing.Size(197, 17);
            this.label10.TabIndex = 160;
            this.label10.Text = "STATS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label11.Size = new System.Drawing.Size(195, 17);
            this.label11.TabIndex = 190;
            this.label11.Text = "STATS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label113.Location = new System.Drawing.Point(0, 91);
            this.label113.Name = "label113";
            this.label113.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label113.Size = new System.Drawing.Size(96, 17);
            this.label113.TabIndex = 247;
            this.label113.Text = "Mg. Defense+";
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label114.Location = new System.Drawing.Point(0, 55);
            this.label114.Name = "label114";
            this.label114.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label114.Size = new System.Drawing.Size(96, 17);
            this.label114.TabIndex = 246;
            this.label114.Text = "Defense+";
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label115.Location = new System.Drawing.Point(0, 37);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label115.Size = new System.Drawing.Size(96, 17);
            this.label115.TabIndex = 245;
            this.label115.Text = "Attack+";
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label116.Location = new System.Drawing.Point(0, 19);
            this.label116.Name = "label116";
            this.label116.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label116.Size = new System.Drawing.Size(96, 17);
            this.label116.TabIndex = 244;
            this.label116.Text = "HP+";
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label117.Location = new System.Drawing.Point(0, 73);
            this.label117.Name = "label117";
            this.label117.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label117.Size = new System.Drawing.Size(96, 17);
            this.label117.TabIndex = 150;
            this.label117.Text = "Mg. Attack+";
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label118.Location = new System.Drawing.Point(0, 91);
            this.label118.Name = "label118";
            this.label118.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label118.Size = new System.Drawing.Size(96, 17);
            this.label118.TabIndex = 149;
            this.label118.Text = "Mg. Defense+";
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label120.Location = new System.Drawing.Point(0, 55);
            this.label120.Name = "label120";
            this.label120.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label120.Size = new System.Drawing.Size(96, 17);
            this.label120.TabIndex = 148;
            this.label120.Text = "Defense+";
            // 
            // label121
            // 
            this.label121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label121.Location = new System.Drawing.Point(0, 37);
            this.label121.Name = "label121";
            this.label121.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label121.Size = new System.Drawing.Size(96, 17);
            this.label121.TabIndex = 147;
            this.label121.Text = "Attack+";
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label122.Location = new System.Drawing.Point(0, 19);
            this.label122.Name = "label122";
            this.label122.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label122.Size = new System.Drawing.Size(96, 17);
            this.label122.TabIndex = 146;
            this.label122.Text = "HP+";
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label124.Location = new System.Drawing.Point(0, 19);
            this.label124.Name = "label124";
            this.label124.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label124.Size = new System.Drawing.Size(96, 17);
            this.label124.TabIndex = 231;
            this.label124.Text = "EXP Needed";
            // 
            // label125
            // 
            this.label125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label125.Location = new System.Drawing.Point(0, 72);
            this.label125.Name = "label125";
            this.label125.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label125.Size = new System.Drawing.Size(101, 17);
            this.label125.TabIndex = 103;
            this.label125.Text = "Magic Defense";
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label127.Location = new System.Drawing.Point(0, 36);
            this.label127.Name = "label127";
            this.label127.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label127.Size = new System.Drawing.Size(101, 17);
            this.label127.TabIndex = 102;
            this.label127.Text = "Defense";
            // 
            // label128
            // 
            this.label128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label128.Location = new System.Drawing.Point(0, 180);
            this.label128.Name = "label128";
            this.label128.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label128.Size = new System.Drawing.Size(101, 17);
            this.label128.TabIndex = 98;
            this.label128.Text = "Current HP";
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label129.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.ForeColor = System.Drawing.SystemColors.Control;
            this.label129.Location = new System.Drawing.Point(0, 0);
            this.label129.Name = "label129";
            this.label129.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label129.Size = new System.Drawing.Size(96, 17);
            this.label129.TabIndex = 101;
            this.label129.Text = "LEVEL #";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label130.Location = new System.Drawing.Point(0, 198);
            this.label130.Name = "label130";
            this.label130.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label130.Size = new System.Drawing.Size(101, 17);
            this.label130.TabIndex = 99;
            this.label130.Text = "Maximum HP";
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label131.Location = new System.Drawing.Point(0, 90);
            this.label131.Name = "label131";
            this.label131.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label131.Size = new System.Drawing.Size(101, 17);
            this.label131.TabIndex = 100;
            this.label131.Text = "Speed";
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label132.Location = new System.Drawing.Point(0, 162);
            this.label132.Name = "label132";
            this.label132.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label132.Size = new System.Drawing.Size(101, 17);
            this.label132.TabIndex = 104;
            this.label132.Text = "Experience";
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label133.Location = new System.Drawing.Point(0, 144);
            this.label133.Name = "label133";
            this.label133.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label133.Size = new System.Drawing.Size(101, 17);
            this.label133.TabIndex = 111;
            this.label133.Text = "Accessory";
            // 
            // label134
            // 
            this.label134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label134.Location = new System.Drawing.Point(0, 126);
            this.label134.Name = "label134";
            this.label134.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label134.Size = new System.Drawing.Size(101, 17);
            this.label134.TabIndex = 110;
            this.label134.Text = "Armor";
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label135.Location = new System.Drawing.Point(0, 108);
            this.label135.Name = "label135";
            this.label135.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label135.Size = new System.Drawing.Size(101, 17);
            this.label135.TabIndex = 109;
            this.label135.Text = "Weapon";
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label137.Location = new System.Drawing.Point(0, 73);
            this.label137.Name = "label137";
            this.label137.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label137.Size = new System.Drawing.Size(96, 17);
            this.label137.TabIndex = 248;
            this.label137.Text = "Mg. Attack+";
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label138.Location = new System.Drawing.Point(0, 54);
            this.label138.Name = "label138";
            this.label138.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label138.Size = new System.Drawing.Size(101, 17);
            this.label138.TabIndex = 105;
            this.label138.Text = "Magic Attack";
            // 
            // label139
            // 
            this.label139.BackColor = System.Drawing.SystemColors.Control;
            this.label139.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label139.Location = new System.Drawing.Point(0, 0);
            this.label139.Name = "label139";
            this.label139.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label139.Size = new System.Drawing.Size(216, 17);
            this.label139.TabIndex = 163;
            this.label139.Text = "LEVEL UP BONUS INCREMENTS...";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label141.Location = new System.Drawing.Point(0, 37);
            this.label141.Name = "label141";
            this.label141.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label141.Size = new System.Drawing.Size(163, 17);
            this.label141.TabIndex = 310;
            this.label141.Text = "Max Number of Quarter Rotations";
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label142.Location = new System.Drawing.Point(0, 19);
            this.label142.Name = "label142";
            this.label142.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label142.Size = new System.Drawing.Size(163, 17);
            this.label142.TabIndex = 309;
            this.label142.Text = "Timing Frame Start";
            // 
            // label144
            // 
            this.label144.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label144.Location = new System.Drawing.Point(0, 19);
            this.label144.Name = "label144";
            this.label144.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label144.Size = new System.Drawing.Size(117, 17);
            this.label144.TabIndex = 317;
            this.label144.Text = "Timing Frame Span";
            // 
            // label147
            // 
            this.label147.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label147.Location = new System.Drawing.Point(0, 55);
            this.label147.Name = "label147";
            this.label147.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label147.Size = new System.Drawing.Size(117, 17);
            this.label147.TabIndex = 32;
            this.label147.Text = "LV1 Timing END";
            // 
            // label148
            // 
            this.label148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label148.Location = new System.Drawing.Point(0, 37);
            this.label148.Name = "label148";
            this.label148.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label148.Size = new System.Drawing.Size(117, 17);
            this.label148.TabIndex = 31;
            this.label148.Text = "LV2 Timing END";
            // 
            // label149
            // 
            this.label149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label149.Location = new System.Drawing.Point(0, 19);
            this.label149.Name = "label149";
            this.label149.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label149.Size = new System.Drawing.Size(117, 17);
            this.label149.TabIndex = 30;
            this.label149.Text = "LV2 Timing START";
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label151.Location = new System.Drawing.Point(0, 73);
            this.label151.Name = "label151";
            this.label151.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label151.Size = new System.Drawing.Size(117, 17);
            this.label151.TabIndex = 40;
            this.label151.Text = "Charge Overflow";
            // 
            // label152
            // 
            this.label152.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label152.Location = new System.Drawing.Point(0, 55);
            this.label152.Name = "label152";
            this.label152.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label152.Size = new System.Drawing.Size(117, 17);
            this.label152.TabIndex = 39;
            this.label152.Text = "Level 4 Frame";
            // 
            // label153
            // 
            this.label153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label153.Location = new System.Drawing.Point(0, 37);
            this.label153.Name = "label153";
            this.label153.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label153.Size = new System.Drawing.Size(117, 17);
            this.label153.TabIndex = 38;
            this.label153.Text = "Level 3 Frame";
            // 
            // label154
            // 
            this.label154.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label154.Location = new System.Drawing.Point(0, 19);
            this.label154.Name = "label154";
            this.label154.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label154.Size = new System.Drawing.Size(117, 17);
            this.label154.TabIndex = 37;
            this.label154.Text = "Level 2 Frame";
            // 
            // label157
            // 
            this.label157.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label157.Location = new System.Drawing.Point(0, 73);
            this.label157.Name = "label157";
            this.label157.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label157.Size = new System.Drawing.Size(117, 17);
            this.label157.TabIndex = 265;
            this.label157.Text = "LV1 Timing END";
            // 
            // label158
            // 
            this.label158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label158.Location = new System.Drawing.Point(0, 19);
            this.label158.Name = "label158";
            this.label158.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label158.Size = new System.Drawing.Size(117, 17);
            this.label158.TabIndex = 262;
            this.label158.Text = "LV1 Timing START";
            // 
            // label159
            // 
            this.label159.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label159.Location = new System.Drawing.Point(0, 55);
            this.label159.Name = "label159";
            this.label159.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label159.Size = new System.Drawing.Size(117, 17);
            this.label159.TabIndex = 264;
            this.label159.Text = "LV2 Timing END";
            // 
            // label160
            // 
            this.label160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label160.Location = new System.Drawing.Point(0, 37);
            this.label160.Name = "label160";
            this.label160.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label160.Size = new System.Drawing.Size(117, 17);
            this.label160.TabIndex = 263;
            this.label160.Text = "LV2 Timing START";
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label162.Location = new System.Drawing.Point(0, 54);
            this.label162.Name = "label162";
            this.label162.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label162.Size = new System.Drawing.Size(96, 17);
            this.label162.TabIndex = 328;
            this.label162.Text = "Equipment";
            // 
            // label163
            // 
            this.label163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label163.Location = new System.Drawing.Point(0, 0);
            this.label163.Name = "label163";
            this.label163.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label163.Size = new System.Drawing.Size(96, 17);
            this.label163.TabIndex = 329;
            this.label163.Text = "Coins";
            // 
            // label164
            // 
            this.label164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label164.Location = new System.Drawing.Point(0, 18);
            this.label164.Name = "label164";
            this.label164.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label164.Size = new System.Drawing.Size(96, 17);
            this.label164.TabIndex = 330;
            this.label164.Text = "Frog Coins";
            // 
            // label165
            // 
            this.label165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label165.Location = new System.Drawing.Point(0, 36);
            this.label165.Name = "label165";
            this.label165.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label165.Size = new System.Drawing.Size(96, 17);
            this.label165.TabIndex = 331;
            this.label165.Text = "Current FP";
            // 
            // label166
            // 
            this.label166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label166.Location = new System.Drawing.Point(0, 54);
            this.label166.Name = "label166";
            this.label166.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label166.Size = new System.Drawing.Size(96, 17);
            this.label166.TabIndex = 332;
            this.label166.Text = "Max FP";
            // 
            // label168
            // 
            this.label168.BackColor = System.Drawing.SystemColors.Control;
            this.label168.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label168.Location = new System.Drawing.Point(2, 40);
            this.label168.Name = "label168";
            this.label168.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label168.Size = new System.Drawing.Size(101, 17);
            this.label168.TabIndex = 123;
            this.label168.Text = "NAME";
            // 
            // label170
            // 
            this.label170.BackColor = System.Drawing.SystemColors.Control;
            this.label170.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label170.Location = new System.Drawing.Point(0, 0);
            this.label170.Name = "label170";
            this.label170.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label170.Size = new System.Drawing.Size(120, 17);
            this.label170.TabIndex = 165;
            this.label170.Text = "TARGETTING";
            this.label170.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label171
            // 
            this.label171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label171.Location = new System.Drawing.Point(0, 54);
            this.label171.Name = "label171";
            this.label171.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label171.Size = new System.Drawing.Size(101, 17);
            this.label171.TabIndex = 167;
            this.label171.Text = "Inflict Function";
            // 
            // label172
            // 
            this.label172.BackColor = System.Drawing.SystemColors.Control;
            this.label172.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label172.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label172.Location = new System.Drawing.Point(0, -1);
            this.label172.Name = "label172";
            this.label172.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label172.Size = new System.Drawing.Size(197, 17);
            this.label172.TabIndex = 168;
            this.label172.Text = "ATTACK PROPERTIES";
            this.label172.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label185
            // 
            this.label185.BackColor = System.Drawing.SystemColors.Control;
            this.label185.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label185.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label185.Location = new System.Drawing.Point(2, 40);
            this.label185.Name = "label185";
            this.label185.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label185.Size = new System.Drawing.Size(96, 17);
            this.label185.TabIndex = 229;
            this.label185.Text = "NAME";
            // 
            // label189
            // 
            this.label189.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label189.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label189.ForeColor = System.Drawing.SystemColors.Control;
            this.label189.Location = new System.Drawing.Point(2, 2);
            this.label189.Name = "label189";
            this.label189.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label189.Size = new System.Drawing.Size(216, 17);
            this.label189.TabIndex = 166;
            this.label189.Text = "CHARACTER LEVEL UPS";
            this.label189.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label193
            // 
            this.label193.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label193.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label193.ForeColor = System.Drawing.SystemColors.Control;
            this.label193.Location = new System.Drawing.Point(2, 2);
            this.label193.Name = "label193";
            this.label193.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label193.Size = new System.Drawing.Size(209, 17);
            this.label193.TabIndex = 340;
            this.label193.Text = "STARTING STATISTICS...";
            this.label193.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label197
            // 
            this.label197.BackColor = System.Drawing.SystemColors.Control;
            this.label197.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label197.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label197.Location = new System.Drawing.Point(0, 0);
            this.label197.Name = "label197";
            this.label197.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label197.Size = new System.Drawing.Size(501, 17);
            this.label197.TabIndex = 318;
            this.label197.Text = "1-LEVEL TIMING SPELLS";
            this.label197.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label208
            // 
            this.label208.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label208.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label208.ForeColor = System.Drawing.SystemColors.Control;
            this.label208.Location = new System.Drawing.Point(2, 2);
            this.label208.Name = "label208";
            this.label208.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label208.Size = new System.Drawing.Size(664, 17);
            this.label208.TabIndex = 278;
            this.label208.Text = "WEAPON / DEFENSE TIMING...";
            this.label208.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label235
            // 
            this.label235.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label235.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label235.ForeColor = System.Drawing.SystemColors.Control;
            this.label235.Location = new System.Drawing.Point(2, 2);
            this.label235.Name = "label235";
            this.label235.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label235.Size = new System.Drawing.Size(219, 17);
            this.label235.TabIndex = 261;
            this.label235.Text = "CHARACTER STARTING STATS";
            this.label235.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label32.Location = new System.Drawing.Point(0, 0);
            this.label32.Name = "label32";
            this.label32.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label32.Size = new System.Drawing.Size(256, 17);
            this.label32.TabIndex = 162;
            this.label32.Text = "PSYCHOPATH MESSAGE...";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label41.Location = new System.Drawing.Point(133, 38);
            this.label41.Name = "label41";
            this.label41.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label41.Size = new System.Drawing.Size(84, 17);
            this.label41.TabIndex = 277;
            this.label41.Text = "Formation 2";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label42.Location = new System.Drawing.Point(0, 38);
            this.label42.Name = "label42";
            this.label42.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label42.Size = new System.Drawing.Size(84, 17);
            this.label42.TabIndex = 270;
            this.label42.Text = "Formation 1";
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label43.Location = new System.Drawing.Point(267, 38);
            this.label43.Name = "label43";
            this.label43.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label43.Size = new System.Drawing.Size(83, 17);
            this.label43.TabIndex = 279;
            this.label43.Text = "Formation 3";
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.SystemColors.Control;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label52.Location = new System.Drawing.Point(0, 0);
            this.label52.Name = "label52";
            this.label52.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label52.Size = new System.Drawing.Size(195, 17);
            this.label52.TabIndex = 187;
            this.label52.Text = "EFFECT INFLICT";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.SystemColors.Control;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label53.Location = new System.Drawing.Point(0, 0);
            this.label53.Name = "label53";
            this.label53.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label53.Size = new System.Drawing.Size(195, 17);
            this.label53.TabIndex = 188;
            this.label53.Text = "STATUS UP";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.SystemColors.Control;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label55.Location = new System.Drawing.Point(0, 0);
            this.label55.Name = "label55";
            this.label55.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label55.Size = new System.Drawing.Size(120, 17);
            this.label55.TabIndex = 172;
            this.label55.Text = "DESCRIPTION";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label56.Location = new System.Drawing.Point(0, 55);
            this.label56.Name = "label56";
            this.label56.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label56.Size = new System.Drawing.Size(101, 17);
            this.label56.TabIndex = 147;
            this.label56.Text = "Hit Rate%";
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label57.Location = new System.Drawing.Point(0, 37);
            this.label57.Name = "label57";
            this.label57.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label57.Size = new System.Drawing.Size(99, 17);
            this.label57.TabIndex = 182;
            this.label57.Text = "Attack Level";
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label58.Location = new System.Drawing.Point(0, 19);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label58.Size = new System.Drawing.Size(99, 17);
            this.label58.TabIndex = 181;
            this.label58.Text = "Hit Rate%";
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.Control;
            this.label59.Location = new System.Drawing.Point(2, 2);
            this.label59.Name = "label59";
            this.label59.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label59.Size = new System.Drawing.Size(99, 17);
            this.label59.TabIndex = 180;
            this.label59.Text = "ATTACK #";
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.SystemColors.Control;
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label60.Location = new System.Drawing.Point(2, 40);
            this.label60.Name = "label60";
            this.label60.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label60.Size = new System.Drawing.Size(99, 17);
            this.label60.TabIndex = 177;
            this.label60.Text = "NAME";
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label64.Location = new System.Drawing.Point(0, 37);
            this.label64.Name = "label64";
            this.label64.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label64.Size = new System.Drawing.Size(101, 17);
            this.label64.TabIndex = 146;
            this.label64.Text = "Magic Power";
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label65.Location = new System.Drawing.Point(0, 19);
            this.label65.Name = "label65";
            this.label65.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label65.Size = new System.Drawing.Size(101, 17);
            this.label65.TabIndex = 145;
            this.label65.Text = "FP Cost";
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.Control;
            this.label66.Location = new System.Drawing.Point(2, 2);
            this.label66.Name = "label66";
            this.label66.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label66.Size = new System.Drawing.Size(101, 17);
            this.label66.TabIndex = 158;
            this.label66.Text = "SPELL #";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label7.Size = new System.Drawing.Size(398, 17);
            this.label7.TabIndex = 288;
            this.label7.Text = "PACK FORMATIONS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label84.Location = new System.Drawing.Point(0, 18);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label84.Size = new System.Drawing.Size(96, 17);
            this.label84.TabIndex = 326;
            this.label84.Text = "Item";
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label88.Location = new System.Drawing.Point(0, 36);
            this.label88.Name = "label88";
            this.label88.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label88.Size = new System.Drawing.Size(96, 17);
            this.label88.TabIndex = 327;
            this.label88.Text = "Special Item ";
            // 
            // LabelMonster
            // 
            this.LabelMonster.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelMonster.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMonster.ForeColor = System.Drawing.SystemColors.Control;
            this.LabelMonster.Location = new System.Drawing.Point(0, 0);
            this.LabelMonster.Name = "LabelMonster";
            this.LabelMonster.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LabelMonster.Size = new System.Drawing.Size(97, 17);
            this.LabelMonster.TabIndex = 0;
            this.LabelMonster.Text = "MONSTER #";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStatsToolStripMenuItem,
            this.toolStripSeparator1,
            this.importAllToolStripMenuItem,
            this.exportAllToolStripMenuItem,
            this.toolStripSeparator5,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveStatsToolStripMenuItem
            // 
            this.saveStatsToolStripMenuItem.AutoSize = false;
            this.saveStatsToolStripMenuItem.Name = "saveStatsToolStripMenuItem";
            this.saveStatsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveStatsToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.saveStatsToolStripMenuItem.Text = "Save Stats";
            this.saveStatsToolStripMenuItem.Click += new System.EventHandler(this.saveStatsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // importAllToolStripMenuItem
            // 
            this.importAllToolStripMenuItem.AutoSize = false;
            this.importAllToolStripMenuItem.Name = "importAllToolStripMenuItem";
            this.importAllToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.importAllToolStripMenuItem.Text = "Import All...";
            this.importAllToolStripMenuItem.Click += new System.EventHandler(this.importAllToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.AutoSize = false;
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.exportAllToolStripMenuItem.Text = "Export All...";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.AutoSize = false;
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monsterToolStripMenuItem,
            this.formationToolStripMenuItem,
            this.formationPackToolStripMenuItem,
            this.spellToolStripMenuItem,
            this.attackToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.shopToolStripMenuItem,
            this.characterToolStripMenuItem,
            this.weaponToolStripMenuItem,
            this.toolStripSeparator4,
            this.allComponentsToolStripMenuItem1});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.clearToolStripMenuItem.Text = "Clear Current";
            // 
            // monsterToolStripMenuItem
            // 
            this.monsterToolStripMenuItem.AutoSize = false;
            this.monsterToolStripMenuItem.Name = "monsterToolStripMenuItem";
            this.monsterToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.monsterToolStripMenuItem.Text = "Monster";
            // 
            // formationToolStripMenuItem
            // 
            this.formationToolStripMenuItem.AutoSize = false;
            this.formationToolStripMenuItem.Name = "formationToolStripMenuItem";
            this.formationToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.formationToolStripMenuItem.Text = "Formation";
            // 
            // formationPackToolStripMenuItem
            // 
            this.formationPackToolStripMenuItem.AutoSize = false;
            this.formationPackToolStripMenuItem.Name = "formationPackToolStripMenuItem";
            this.formationPackToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.formationPackToolStripMenuItem.Text = "Pack";
            // 
            // spellToolStripMenuItem
            // 
            this.spellToolStripMenuItem.AutoSize = false;
            this.spellToolStripMenuItem.Name = "spellToolStripMenuItem";
            this.spellToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.spellToolStripMenuItem.Text = "Spell";
            // 
            // attackToolStripMenuItem
            // 
            this.attackToolStripMenuItem.AutoSize = false;
            this.attackToolStripMenuItem.Name = "attackToolStripMenuItem";
            this.attackToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.attackToolStripMenuItem.Text = "Attack";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.AutoSize = false;
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // shopToolStripMenuItem
            // 
            this.shopToolStripMenuItem.AutoSize = false;
            this.shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            this.shopToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.shopToolStripMenuItem.Text = "Shop";
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.AutoSize = false;
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.characterToolStripMenuItem.Text = "Character";
            // 
            // weaponToolStripMenuItem
            // 
            this.weaponToolStripMenuItem.AutoSize = false;
            this.weaponToolStripMenuItem.Name = "weaponToolStripMenuItem";
            this.weaponToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.weaponToolStripMenuItem.Text = "Weapon Timing";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // allComponentsToolStripMenuItem1
            // 
            this.allComponentsToolStripMenuItem1.Name = "allComponentsToolStripMenuItem1";
            this.allComponentsToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.allComponentsToolStripMenuItem1.Text = "All Components";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monstersToolStripMenuItem,
            this.formationsToolStripMenuItem,
            this.packsToolStripMenuItem,
            this.spellsToolStripMenuItem,
            this.attacksToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.shopsToolStripMenuItem,
            this.charactersToolStripMenuItem,
            this.dialoguesToolStripMenuItem,
            this.battleDialoguesToolStripMenuItem,
            this.spellTimingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.allComponentsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 20);
            this.toolStripMenuItem1.Text = "Clear All";
            // 
            // monstersToolStripMenuItem
            // 
            this.monstersToolStripMenuItem.AutoSize = false;
            this.monstersToolStripMenuItem.Name = "monstersToolStripMenuItem";
            this.monstersToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.monstersToolStripMenuItem.Text = "Monsters";
            // 
            // formationsToolStripMenuItem
            // 
            this.formationsToolStripMenuItem.AutoSize = false;
            this.formationsToolStripMenuItem.Name = "formationsToolStripMenuItem";
            this.formationsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.formationsToolStripMenuItem.Text = "Formations";
            // 
            // packsToolStripMenuItem
            // 
            this.packsToolStripMenuItem.AutoSize = false;
            this.packsToolStripMenuItem.Name = "packsToolStripMenuItem";
            this.packsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.packsToolStripMenuItem.Text = "Packs";
            // 
            // spellsToolStripMenuItem
            // 
            this.spellsToolStripMenuItem.AutoSize = false;
            this.spellsToolStripMenuItem.Name = "spellsToolStripMenuItem";
            this.spellsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.spellsToolStripMenuItem.Text = "Spells";
            // 
            // attacksToolStripMenuItem
            // 
            this.attacksToolStripMenuItem.AutoSize = false;
            this.attacksToolStripMenuItem.Name = "attacksToolStripMenuItem";
            this.attacksToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.attacksToolStripMenuItem.Text = "Attacks";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.AutoSize = false;
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // shopsToolStripMenuItem
            // 
            this.shopsToolStripMenuItem.AutoSize = false;
            this.shopsToolStripMenuItem.Name = "shopsToolStripMenuItem";
            this.shopsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.shopsToolStripMenuItem.Text = "Shops";
            // 
            // charactersToolStripMenuItem
            // 
            this.charactersToolStripMenuItem.AutoSize = false;
            this.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            this.charactersToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.charactersToolStripMenuItem.Text = "Characters/Inventories";
            // 
            // dialoguesToolStripMenuItem
            // 
            this.dialoguesToolStripMenuItem.AutoSize = false;
            this.dialoguesToolStripMenuItem.Name = "dialoguesToolStripMenuItem";
            this.dialoguesToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.dialoguesToolStripMenuItem.Text = "Dialogues";
            // 
            // battleDialoguesToolStripMenuItem
            // 
            this.battleDialoguesToolStripMenuItem.AutoSize = false;
            this.battleDialoguesToolStripMenuItem.Name = "battleDialoguesToolStripMenuItem";
            this.battleDialoguesToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.battleDialoguesToolStripMenuItem.Text = "Battle Dialogues";
            // 
            // spellTimingsToolStripMenuItem
            // 
            this.spellTimingsToolStripMenuItem.AutoSize = false;
            this.spellTimingsToolStripMenuItem.Name = "spellTimingsToolStripMenuItem";
            this.spellTimingsToolStripMenuItem.Size = new System.Drawing.Size(186, 20);
            this.spellTimingsToolStripMenuItem.Text = "Weapon/Spell Timings";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // allComponentsToolStripMenuItem
            // 
            this.allComponentsToolStripMenuItem.Name = "allComponentsToolStripMenuItem";
            this.allComponentsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.allComponentsToolStripMenuItem.Text = "All Components";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MonsterNumber
            // 
            this.MonsterNumber.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MonsterNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonsterNumber.ForeColor = System.Drawing.SystemColors.Control;
            this.MonsterNumber.Location = new System.Drawing.Point(98, 0);
            this.MonsterNumber.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterNumber.Name = "MonsterNumber";
            this.MonsterNumber.Size = new System.Drawing.Size(97, 17);
            this.MonsterNumber.TabIndex = 1;
            this.MonsterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterNumber.ValueChanged += new System.EventHandler(this.MonsterNumber_ValueChanged);
            // 
            // MonsterSoundOther
            // 
            this.MonsterSoundOther.DropDownHeight = 180;
            this.MonsterSoundOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterSoundOther.DropDownWidth = 150;
            this.MonsterSoundOther.IntegralHeight = false;
            this.MonsterSoundOther.Items.AddRange(new object[] {
            "none",
            "Starslap, Spikey, Enigma",
            "Sparky, Goomba, Birdy",
            "Amanita, Terrapin",
            "Guerilla",
            "Pulsar",
            "Dry Bones",
            "Torte"});
            this.MonsterSoundOther.Location = new System.Drawing.Point(-2, -2);
            this.MonsterSoundOther.Name = "MonsterSoundOther";
            this.MonsterSoundOther.Size = new System.Drawing.Size(101, 21);
            this.MonsterSoundOther.TabIndex = 0;
            this.MonsterSoundOther.SelectedIndexChanged += new System.EventHandler(this.MonsterSoundOther_SelectedIndexChanged);
            // 
            // MonsterSoundStrike
            // 
            this.MonsterSoundStrike.DropDownHeight = 184;
            this.MonsterSoundStrike.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterSoundStrike.IntegralHeight = false;
            this.MonsterSoundStrike.Items.AddRange(new object[] {
            "bite",
            "pierce",
            "claw",
            "jab",
            "slap",
            "knock",
            "smash",
            "deep knock",
            "punch",
            "bonk",
            "flopping",
            "deep jab",
            "blast",
            "blast"});
            this.MonsterSoundStrike.Location = new System.Drawing.Point(-2, -2);
            this.MonsterSoundStrike.Name = "MonsterSoundStrike";
            this.MonsterSoundStrike.Size = new System.Drawing.Size(101, 21);
            this.MonsterSoundStrike.TabIndex = 0;
            this.MonsterSoundStrike.SelectedIndexChanged += new System.EventHandler(this.MonsterSoundStrike_SelectedIndexChanged);
            // 
            // numericUpDown100
            // 
            this.numericUpDown100.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown100.Location = new System.Drawing.Point(118, 19);
            this.numericUpDown100.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown100.Name = "numericUpDown100";
            this.numericUpDown100.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown100.TabIndex = 279;
            this.numericUpDown100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown100.ValueChanged += new System.EventHandler(this.numericUpDown100_ValueChanged);
            // 
            // numericUpDown103
            // 
            this.numericUpDown103.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown103.Location = new System.Drawing.Point(164, 37);
            this.numericUpDown103.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown103.Name = "numericUpDown103";
            this.numericUpDown103.Size = new System.Drawing.Size(168, 17);
            this.numericUpDown103.TabIndex = 304;
            this.numericUpDown103.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown103.ValueChanged += new System.EventHandler(this.numericUpDown103_ValueChanged);
            // 
            // numericUpDown104
            // 
            this.numericUpDown104.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown104.Location = new System.Drawing.Point(164, 19);
            this.numericUpDown104.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown104.Name = "numericUpDown104";
            this.numericUpDown104.Size = new System.Drawing.Size(168, 17);
            this.numericUpDown104.TabIndex = 303;
            this.numericUpDown104.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown104.ValueChanged += new System.EventHandler(this.numericUpDown104_ValueChanged);
            // 
            // numericUpDown107
            // 
            this.numericUpDown107.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown107.Location = new System.Drawing.Point(118, 19);
            this.numericUpDown107.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown107.Name = "numericUpDown107";
            this.numericUpDown107.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown107.TabIndex = 284;
            this.numericUpDown107.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown107.ValueChanged += new System.EventHandler(this.numericUpDown107_ValueChanged);
            // 
            // numericUpDown108
            // 
            this.numericUpDown108.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown108.Location = new System.Drawing.Point(118, 55);
            this.numericUpDown108.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown108.Name = "numericUpDown108";
            this.numericUpDown108.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown108.TabIndex = 288;
            this.numericUpDown108.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown108.ValueChanged += new System.EventHandler(this.numericUpDown108_ValueChanged);
            // 
            // numericUpDown110
            // 
            this.numericUpDown110.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown110.Location = new System.Drawing.Point(118, 37);
            this.numericUpDown110.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown110.Name = "numericUpDown110";
            this.numericUpDown110.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown110.TabIndex = 286;
            this.numericUpDown110.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown110.ValueChanged += new System.EventHandler(this.numericUpDown110_ValueChanged);
            // 
            // numericUpDown111
            // 
            this.numericUpDown111.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown111.Location = new System.Drawing.Point(118, 37);
            this.numericUpDown111.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown111.Name = "numericUpDown111";
            this.numericUpDown111.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown111.TabIndex = 292;
            this.numericUpDown111.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown111.ValueChanged += new System.EventHandler(this.numericUpDown111_ValueChanged);
            // 
            // numericUpDown112
            // 
            this.numericUpDown112.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown112.Location = new System.Drawing.Point(118, 73);
            this.numericUpDown112.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown112.Name = "numericUpDown112";
            this.numericUpDown112.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown112.TabIndex = 296;
            this.numericUpDown112.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown112.ValueChanged += new System.EventHandler(this.numericUpDown112_ValueChanged);
            // 
            // numericUpDown113
            // 
            this.numericUpDown113.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown113.Location = new System.Drawing.Point(118, 19);
            this.numericUpDown113.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown113.Name = "numericUpDown113";
            this.numericUpDown113.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown113.TabIndex = 290;
            this.numericUpDown113.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown113.ValueChanged += new System.EventHandler(this.numericUpDown113_ValueChanged);
            // 
            // numericUpDown114
            // 
            this.numericUpDown114.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown114.Location = new System.Drawing.Point(118, 55);
            this.numericUpDown114.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown114.Name = "numericUpDown114";
            this.numericUpDown114.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown114.TabIndex = 294;
            this.numericUpDown114.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown114.ValueChanged += new System.EventHandler(this.numericUpDown114_ValueChanged);
            // 
            // numericUpDown117
            // 
            this.numericUpDown117.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown117.Location = new System.Drawing.Point(118, 55);
            this.numericUpDown117.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown117.Name = "numericUpDown117";
            this.numericUpDown117.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown117.TabIndex = 272;
            this.numericUpDown117.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown117.ValueChanged += new System.EventHandler(this.numericUpDown117_ValueChanged);
            // 
            // numericUpDown118
            // 
            this.numericUpDown118.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown118.Location = new System.Drawing.Point(118, 19);
            this.numericUpDown118.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown118.Name = "numericUpDown118";
            this.numericUpDown118.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown118.TabIndex = 268;
            this.numericUpDown118.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown118.ValueChanged += new System.EventHandler(this.numericUpDown118_ValueChanged);
            // 
            // numericUpDown119
            // 
            this.numericUpDown119.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown119.Location = new System.Drawing.Point(118, 73);
            this.numericUpDown119.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown119.Name = "numericUpDown119";
            this.numericUpDown119.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown119.TabIndex = 274;
            this.numericUpDown119.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown119.ValueChanged += new System.EventHandler(this.numericUpDown119_ValueChanged);
            // 
            // numericUpDown120
            // 
            this.numericUpDown120.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown120.Location = new System.Drawing.Point(118, 37);
            this.numericUpDown120.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown120.Name = "numericUpDown120";
            this.numericUpDown120.Size = new System.Drawing.Size(45, 17);
            this.numericUpDown120.TabIndex = 270;
            this.numericUpDown120.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown120.ValueChanged += new System.EventHandler(this.numericUpDown120_ValueChanged);
            // 
            // startingCoins
            // 
            this.startingCoins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingCoins.Location = new System.Drawing.Point(97, 0);
            this.startingCoins.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.startingCoins.Name = "startingCoins";
            this.startingCoins.Size = new System.Drawing.Size(113, 17);
            this.startingCoins.TabIndex = 206;
            this.startingCoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingCoins.ValueChanged += new System.EventHandler(this.startingCoins_ValueChanged);
            // 
            // startingFrogCoins
            // 
            this.startingFrogCoins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingFrogCoins.Location = new System.Drawing.Point(97, 18);
            this.startingFrogCoins.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.startingFrogCoins.Name = "startingFrogCoins";
            this.startingFrogCoins.Size = new System.Drawing.Size(113, 17);
            this.startingFrogCoins.TabIndex = 207;
            this.startingFrogCoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingFrogCoins.ValueChanged += new System.EventHandler(this.startingFrogCoins_ValueChanged);
            // 
            // startingMaximumFP
            // 
            this.startingMaximumFP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingMaximumFP.Location = new System.Drawing.Point(97, 54);
            this.startingMaximumFP.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.startingMaximumFP.Name = "startingMaximumFP";
            this.startingMaximumFP.Size = new System.Drawing.Size(113, 17);
            this.startingMaximumFP.TabIndex = 209;
            this.startingMaximumFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingMaximumFP.ValueChanged += new System.EventHandler(this.startingMaximumFP_ValueChanged);
            // 
            // startingCurrentFP
            // 
            this.startingCurrentFP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingCurrentFP.Location = new System.Drawing.Point(97, 36);
            this.startingCurrentFP.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.startingCurrentFP.Name = "startingCurrentFP";
            this.startingCurrentFP.Size = new System.Drawing.Size(113, 17);
            this.startingCurrentFP.TabIndex = 208;
            this.startingCurrentFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingCurrentFP.ValueChanged += new System.EventHandler(this.startingCurrentFP_ValueChanged);
            // 
            // defensePlusBonus
            // 
            this.defensePlusBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.defensePlusBonus.Location = new System.Drawing.Point(97, 55);
            this.defensePlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.defensePlusBonus.Name = "defensePlusBonus";
            this.defensePlusBonus.Size = new System.Drawing.Size(120, 17);
            this.defensePlusBonus.TabIndex = 190;
            this.defensePlusBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.defensePlusBonus.ValueChanged += new System.EventHandler(this.defensePlusBonus_ValueChanged);
            // 
            // hpPlusBonus
            // 
            this.hpPlusBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hpPlusBonus.Location = new System.Drawing.Point(97, 19);
            this.hpPlusBonus.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hpPlusBonus.Name = "hpPlusBonus";
            this.hpPlusBonus.Size = new System.Drawing.Size(120, 17);
            this.hpPlusBonus.TabIndex = 188;
            this.hpPlusBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hpPlusBonus.ValueChanged += new System.EventHandler(this.hpPlusBonus_ValueChanged);
            // 
            // attackPlus
            // 
            this.attackPlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackPlus.Location = new System.Drawing.Point(97, 37);
            this.attackPlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attackPlus.Name = "attackPlus";
            this.attackPlus.Size = new System.Drawing.Size(120, 17);
            this.attackPlus.TabIndex = 184;
            this.attackPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackPlus.ValueChanged += new System.EventHandler(this.attackPlus_ValueChanged);
            // 
            // mgAttackPlus
            // 
            this.mgAttackPlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgAttackPlus.Location = new System.Drawing.Point(97, 73);
            this.mgAttackPlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgAttackPlus.Name = "mgAttackPlus";
            this.mgAttackPlus.Size = new System.Drawing.Size(120, 17);
            this.mgAttackPlus.TabIndex = 186;
            this.mgAttackPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mgAttackPlus.ValueChanged += new System.EventHandler(this.mgAttackPlus_ValueChanged);
            // 
            // mgDefensePlus
            // 
            this.mgDefensePlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgDefensePlus.Location = new System.Drawing.Point(97, 91);
            this.mgDefensePlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgDefensePlus.Name = "mgDefensePlus";
            this.mgDefensePlus.Size = new System.Drawing.Size(120, 17);
            this.mgDefensePlus.TabIndex = 187;
            this.mgDefensePlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mgDefensePlus.ValueChanged += new System.EventHandler(this.mgDefensePlus_ValueChanged);
            // 
            // defensePlus
            // 
            this.defensePlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.defensePlus.Location = new System.Drawing.Point(97, 55);
            this.defensePlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.defensePlus.Name = "defensePlus";
            this.defensePlus.Size = new System.Drawing.Size(120, 17);
            this.defensePlus.TabIndex = 185;
            this.defensePlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.defensePlus.ValueChanged += new System.EventHandler(this.defensePlus_ValueChanged);
            // 
            // hpPlus
            // 
            this.hpPlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hpPlus.Location = new System.Drawing.Point(97, 19);
            this.hpPlus.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hpPlus.Name = "hpPlus";
            this.hpPlus.Size = new System.Drawing.Size(120, 17);
            this.hpPlus.TabIndex = 183;
            this.hpPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hpPlus.ValueChanged += new System.EventHandler(this.hpPlus_ValueChanged);
            // 
            // expNeeded
            // 
            this.expNeeded.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.expNeeded.Location = new System.Drawing.Point(97, 19);
            this.expNeeded.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.expNeeded.Name = "expNeeded";
            this.expNeeded.Size = new System.Drawing.Size(120, 17);
            this.expNeeded.TabIndex = 182;
            this.expNeeded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.expNeeded.ValueChanged += new System.EventHandler(this.expNeeded_ValueChanged);
            // 
            // mgDefensePlusBonus
            // 
            this.mgDefensePlusBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgDefensePlusBonus.Location = new System.Drawing.Point(97, 91);
            this.mgDefensePlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgDefensePlusBonus.Name = "mgDefensePlusBonus";
            this.mgDefensePlusBonus.Size = new System.Drawing.Size(120, 17);
            this.mgDefensePlusBonus.TabIndex = 192;
            this.mgDefensePlusBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mgDefensePlusBonus.ValueChanged += new System.EventHandler(this.mgDefensePlusBonus_ValueChanged);
            // 
            // startingMgDefense
            // 
            this.startingMgDefense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingMgDefense.Location = new System.Drawing.Point(102, 72);
            this.startingMgDefense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.startingMgDefense.Name = "startingMgDefense";
            this.startingMgDefense.Size = new System.Drawing.Size(118, 17);
            this.startingMgDefense.TabIndex = 197;
            this.startingMgDefense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingMgDefense.ValueChanged += new System.EventHandler(this.startingMgDefense_ValueChanged);
            // 
            // startingDefense
            // 
            this.startingDefense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingDefense.Location = new System.Drawing.Point(102, 36);
            this.startingDefense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.startingDefense.Name = "startingDefense";
            this.startingDefense.Size = new System.Drawing.Size(118, 17);
            this.startingDefense.TabIndex = 195;
            this.startingDefense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingDefense.ValueChanged += new System.EventHandler(this.startingDefense_ValueChanged);
            // 
            // startingExperience
            // 
            this.startingExperience.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingExperience.Location = new System.Drawing.Point(102, 162);
            this.startingExperience.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.startingExperience.Name = "startingExperience";
            this.startingExperience.Size = new System.Drawing.Size(118, 17);
            this.startingExperience.TabIndex = 202;
            this.startingExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingExperience.ValueChanged += new System.EventHandler(this.startingExperience_ValueChanged);
            // 
            // startingSpeed
            // 
            this.startingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingSpeed.Location = new System.Drawing.Point(102, 90);
            this.startingSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.startingSpeed.Name = "startingSpeed";
            this.startingSpeed.Size = new System.Drawing.Size(118, 17);
            this.startingSpeed.TabIndex = 198;
            this.startingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingSpeed.ValueChanged += new System.EventHandler(this.startingSpeed_ValueChanged);
            // 
            // startingMaximumHP
            // 
            this.startingMaximumHP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingMaximumHP.Location = new System.Drawing.Point(102, 198);
            this.startingMaximumHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.startingMaximumHP.Name = "startingMaximumHP";
            this.startingMaximumHP.Size = new System.Drawing.Size(118, 17);
            this.startingMaximumHP.TabIndex = 204;
            this.startingMaximumHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingMaximumHP.ValueChanged += new System.EventHandler(this.startingMaximumHP_ValueChanged);
            // 
            // startingCurrentHP
            // 
            this.startingCurrentHP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingCurrentHP.Location = new System.Drawing.Point(102, 180);
            this.startingCurrentHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.startingCurrentHP.Name = "startingCurrentHP";
            this.startingCurrentHP.Size = new System.Drawing.Size(118, 17);
            this.startingCurrentHP.TabIndex = 203;
            this.startingCurrentHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingCurrentHP.ValueChanged += new System.EventHandler(this.startingCurrentHP_ValueChanged);
            // 
            // attackPlusBonus
            // 
            this.attackPlusBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackPlusBonus.Location = new System.Drawing.Point(97, 37);
            this.attackPlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attackPlusBonus.Name = "attackPlusBonus";
            this.attackPlusBonus.Size = new System.Drawing.Size(120, 17);
            this.attackPlusBonus.TabIndex = 189;
            this.attackPlusBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackPlusBonus.ValueChanged += new System.EventHandler(this.attackPlusBonus_ValueChanged);
            // 
            // startingMgAttack
            // 
            this.startingMgAttack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingMgAttack.Location = new System.Drawing.Point(102, 54);
            this.startingMgAttack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.startingMgAttack.Name = "startingMgAttack";
            this.startingMgAttack.Size = new System.Drawing.Size(118, 17);
            this.startingMgAttack.TabIndex = 196;
            this.startingMgAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingMgAttack.ValueChanged += new System.EventHandler(this.startingMgAttack_ValueChanged);
            // 
            // mgAttackPlusBonus
            // 
            this.mgAttackPlusBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgAttackPlusBonus.Location = new System.Drawing.Point(97, 73);
            this.mgAttackPlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgAttackPlusBonus.Name = "mgAttackPlusBonus";
            this.mgAttackPlusBonus.Size = new System.Drawing.Size(120, 17);
            this.mgAttackPlusBonus.TabIndex = 191;
            this.mgAttackPlusBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mgAttackPlusBonus.ValueChanged += new System.EventHandler(this.mgAttackPlusBonus_ValueChanged);
            // 
            // packFormation1
            // 
            this.packFormation1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packFormation1.Location = new System.Drawing.Point(85, 38);
            this.packFormation1.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.packFormation1.Name = "packFormation1";
            this.packFormation1.Size = new System.Drawing.Size(47, 17);
            this.packFormation1.TabIndex = 87;
            this.packFormation1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.packFormation1.ValueChanged += new System.EventHandler(this.packFormation1_ValueChanged);
            // 
            // packFormation2
            // 
            this.packFormation2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packFormation2.Location = new System.Drawing.Point(218, 38);
            this.packFormation2.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.packFormation2.Name = "packFormation2";
            this.packFormation2.Size = new System.Drawing.Size(48, 17);
            this.packFormation2.TabIndex = 90;
            this.packFormation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.packFormation2.ValueChanged += new System.EventHandler(this.packFormation2_ValueChanged);
            // 
            // packFormation3
            // 
            this.packFormation3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packFormation3.Location = new System.Drawing.Point(351, 38);
            this.packFormation3.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.packFormation3.Name = "packFormation3";
            this.packFormation3.Size = new System.Drawing.Size(48, 17);
            this.packFormation3.TabIndex = 94;
            this.packFormation3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.packFormation3.ValueChanged += new System.EventHandler(this.packFormation3_ValueChanged);
            // 
            // packFormationButton1
            // 
            this.packFormationButton1.BackColor = System.Drawing.SystemColors.Window;
            this.packFormationButton1.FlatAppearance.BorderSize = 0;
            this.packFormationButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.packFormationButton1.Location = new System.Drawing.Point(0, 169);
            this.packFormationButton1.Name = "packFormationButton1";
            this.packFormationButton1.Size = new System.Drawing.Size(132, 17);
            this.packFormationButton1.TabIndex = 89;
            this.packFormationButton1.Text = "LOAD";
            this.packFormationButton1.UseCompatibleTextRendering = true;
            this.packFormationButton1.UseVisualStyleBackColor = false;
            this.packFormationButton1.Click += new System.EventHandler(this.packFormationButton1_Click);
            // 
            // packFormationButton2
            // 
            this.packFormationButton2.BackColor = System.Drawing.SystemColors.Window;
            this.packFormationButton2.FlatAppearance.BorderSize = 0;
            this.packFormationButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.packFormationButton2.Location = new System.Drawing.Point(133, 169);
            this.packFormationButton2.Name = "packFormationButton2";
            this.packFormationButton2.Size = new System.Drawing.Size(132, 17);
            this.packFormationButton2.TabIndex = 93;
            this.packFormationButton2.Text = "LOAD";
            this.packFormationButton2.UseCompatibleTextRendering = true;
            this.packFormationButton2.UseVisualStyleBackColor = false;
            this.packFormationButton2.Click += new System.EventHandler(this.packFormationButton2_Click);
            // 
            // packFormationButton3
            // 
            this.packFormationButton3.BackColor = System.Drawing.SystemColors.Window;
            this.packFormationButton3.FlatAppearance.BorderSize = 0;
            this.packFormationButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.packFormationButton3.Location = new System.Drawing.Point(266, 169);
            this.packFormationButton3.Name = "packFormationButton3";
            this.packFormationButton3.Size = new System.Drawing.Size(132, 17);
            this.packFormationButton3.TabIndex = 96;
            this.packFormationButton3.Text = "LOAD";
            this.packFormationButton3.UseCompatibleTextRendering = true;
            this.packFormationButton3.UseVisualStyleBackColor = false;
            this.packFormationButton3.Click += new System.EventHandler(this.packFormationButton3_Click);
            // 
            // pictureBoxMonster
            // 
            this.pictureBoxMonster.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxMonster.Location = new System.Drawing.Point(2, 21);
            this.pictureBoxMonster.Name = "pictureBoxMonster";
            this.pictureBoxMonster.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMonster.TabIndex = 220;
            this.pictureBoxMonster.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxMonster, "Click and drag the cursor arrow");
            this.pictureBoxMonster.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMonster_MouseMove);
            this.pictureBoxMonster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMonster_MouseDown);
            this.pictureBoxMonster.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMonster_Paint);
            this.pictureBoxMonster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMonster_MouseUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(2, 2);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label9.Size = new System.Drawing.Size(256, 17);
            this.label9.TabIndex = 344;
            this.label9.Text = "MONSTER SPRITE...";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.SystemColors.Window;
            this.panel64.Controls.Add(this.TextboxMonsterName);
            this.panel64.Location = new System.Drawing.Point(98, 38);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(96, 17);
            this.panel64.TabIndex = 4;
            // 
            // TextboxMonsterName
            // 
            this.TextboxMonsterName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextboxMonsterName.Location = new System.Drawing.Point(4, 1);
            this.TextboxMonsterName.MaxLength = 13;
            this.TextboxMonsterName.Name = "TextboxMonsterName";
            this.TextboxMonsterName.Size = new System.Drawing.Size(88, 14);
            this.TextboxMonsterName.TabIndex = 0;
            this.TextboxMonsterName.TextChanged += new System.EventHandler(this.TextboxMonsterName_TextChanged);
            this.TextboxMonsterName.Leave += new System.EventHandler(this.TextboxMonsterName_Leave);
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.monsterName);
            this.panel63.Location = new System.Drawing.Point(0, 19);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(195, 17);
            this.panel63.TabIndex = 2;
            // 
            // monsterName
            // 
            this.monsterName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.monsterName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.monsterName.DropDownHeight = 522;
            this.monsterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monsterName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monsterName.ForeColor = System.Drawing.SystemColors.Control;
            this.monsterName.IntegralHeight = false;
            this.monsterName.Location = new System.Drawing.Point(-2, -2);
            this.monsterName.Name = "monsterName";
            this.monsterName.Size = new System.Drawing.Size(199, 22);
            this.monsterName.TabIndex = 0;
            this.monsterName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.monsterName.SelectedIndexChanged += new System.EventHandler(this.monsterName_SelectedIndexChanged);
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel55.Controls.Add(this.MonsterValFlowerOdds);
            this.panel55.Controls.Add(this.label34);
            this.panel55.Controls.Add(this.label30);
            this.panel55.Controls.Add(this.label1);
            this.panel55.Controls.Add(this.panel66);
            this.panel55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel55.Location = new System.Drawing.Point(2, 2);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(194, 53);
            this.panel55.TabIndex = 18;
            // 
            // MonsterValFlowerOdds
            // 
            this.MonsterValFlowerOdds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValFlowerOdds.Location = new System.Drawing.Point(98, 36);
            this.MonsterValFlowerOdds.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.MonsterValFlowerOdds.Name = "MonsterValFlowerOdds";
            this.MonsterValFlowerOdds.Size = new System.Drawing.Size(97, 17);
            this.MonsterValFlowerOdds.TabIndex = 4;
            this.MonsterValFlowerOdds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValFlowerOdds.ValueChanged += new System.EventHandler(this.MonsterValFlowerOdds_ValueChanged);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label34.Location = new System.Drawing.Point(0, 18);
            this.label34.Name = "label34";
            this.label34.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label34.Size = new System.Drawing.Size(97, 17);
            this.label34.TabIndex = 1;
            this.label34.Text = "Flower Bonus";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label30.Location = new System.Drawing.Point(0, 36);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label30.Size = new System.Drawing.Size(97, 17);
            this.label30.TabIndex = 2;
            this.label30.Text = "Odds";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "FLOWER BONUS...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.MonsterFlowerBonus);
            this.panel66.Location = new System.Drawing.Point(98, 18);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(97, 17);
            this.panel66.TabIndex = 3;
            // 
            // MonsterFlowerBonus
            // 
            this.MonsterFlowerBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterFlowerBonus.DropDownWidth = 100;
            this.MonsterFlowerBonus.IntegralHeight = false;
            this.MonsterFlowerBonus.Items.AddRange(new object[] {
            "Attack Up",
            "Defense Up",
            "HP Max",
            "Once Again",
            "Lucky"});
            this.MonsterFlowerBonus.Location = new System.Drawing.Point(-2, -2);
            this.MonsterFlowerBonus.Name = "MonsterFlowerBonus";
            this.MonsterFlowerBonus.Size = new System.Drawing.Size(101, 21);
            this.MonsterFlowerBonus.TabIndex = 0;
            this.MonsterFlowerBonus.SelectedIndexChanged += new System.EventHandler(this.MonsterFlowerBonus_SelectedIndexChanged);
            // 
            // label209
            // 
            this.label209.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label209.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label209.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label209.ForeColor = System.Drawing.SystemColors.Control;
            this.label209.Location = new System.Drawing.Point(0, 0);
            this.label209.Name = "label209";
            this.label209.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label209.Size = new System.Drawing.Size(256, 17);
            this.label209.TabIndex = 406;
            this.label209.Text = "MONSTER NOTES...";
            this.label209.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.SystemColors.Control;
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label87.Location = new System.Drawing.Point(0, 0);
            this.label87.Name = "label87";
            this.label87.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label87.Size = new System.Drawing.Size(194, 17);
            this.label87.TabIndex = 400;
            this.label87.Text = "SPECIAL STATUS...";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label96.Location = new System.Drawing.Point(0, 0);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label96.Size = new System.Drawing.Size(194, 17);
            this.label96.TabIndex = 402;
            this.label96.Text = "ELEMENT WEAKNESSES...";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label169
            // 
            this.label169.BackColor = System.Drawing.SystemColors.Control;
            this.label169.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label169.Location = new System.Drawing.Point(0, 0);
            this.label169.Name = "label169";
            this.label169.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label169.Size = new System.Drawing.Size(194, 17);
            this.label169.TabIndex = 401;
            this.label169.Text = "ELEMENT NULLIFICATION...";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label182
            // 
            this.label182.BackColor = System.Drawing.SystemColors.Control;
            this.label182.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label182.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label182.Location = new System.Drawing.Point(0, 0);
            this.label182.Name = "label182";
            this.label182.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label182.Size = new System.Drawing.Size(194, 17);
            this.label182.TabIndex = 399;
            this.label182.Text = "EFFECT NULLIFICATION...";
            this.label182.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelMonsterName
            // 
            this.LabelMonsterName.BackColor = System.Drawing.SystemColors.Control;
            this.LabelMonsterName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMonsterName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelMonsterName.Location = new System.Drawing.Point(0, 38);
            this.LabelMonsterName.Name = "LabelMonsterName";
            this.LabelMonsterName.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LabelMonsterName.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterName.TabIndex = 3;
            this.LabelMonsterName.Text = "NAME";
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.SystemColors.Window;
            this.panel42.Controls.Add(this.TextboxMonsterPsychoMsg);
            this.panel42.Location = new System.Drawing.Point(0, 67);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(179, 65);
            this.panel42.TabIndex = 35;
            // 
            // TextboxMonsterPsychoMsg
            // 
            this.TextboxMonsterPsychoMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextboxMonsterPsychoMsg.Location = new System.Drawing.Point(4, 4);
            this.TextboxMonsterPsychoMsg.Name = "TextboxMonsterPsychoMsg";
            this.TextboxMonsterPsychoMsg.Size = new System.Drawing.Size(171, 57);
            this.TextboxMonsterPsychoMsg.TabIndex = 35;
            this.TextboxMonsterPsychoMsg.Text = "";
            this.TextboxMonsterPsychoMsg.TextChanged += new System.EventHandler(this.TextboxMonsterPsychoMsg_TextChanged);
            // 
            // panel41
            // 
            this.panel41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel41.BackColor = System.Drawing.SystemColors.Window;
            this.panel41.Controls.Add(this.monsterNotesTextBox);
            this.panel41.Location = new System.Drawing.Point(0, 19);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(256, 73);
            this.panel41.TabIndex = 42;
            // 
            // monsterNotesTextBox
            // 
            this.monsterNotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.monsterNotesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.monsterNotesTextBox.Location = new System.Drawing.Point(4, 4);
            this.monsterNotesTextBox.Name = "monsterNotesTextBox";
            this.monsterNotesTextBox.Size = new System.Drawing.Size(248, 65);
            this.monsterNotesTextBox.TabIndex = 42;
            this.monsterNotesTextBox.Text = "";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::SMRPGED.Properties.Resources.back;
            this.button2.Location = new System.Drawing.Point(0, 49);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.button2.Size = new System.Drawing.Size(22, 17);
            this.button2.TabIndex = 33;
            this.toolTip1.SetToolTip(this.button2, "View previous page");
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonPreviousFrame
            // 
            this.buttonPreviousFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonPreviousFrame.FlatAppearance.BorderSize = 0;
            this.buttonPreviousFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreviousFrame.Image = global::SMRPGED.Properties.Resources.back;
            this.buttonPreviousFrame.Location = new System.Drawing.Point(2, 260);
            this.buttonPreviousFrame.Name = "buttonPreviousFrame";
            this.buttonPreviousFrame.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.buttonPreviousFrame.Size = new System.Drawing.Size(22, 17);
            this.buttonPreviousFrame.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonPreviousFrame, "View previous image");
            this.buttonPreviousFrame.UseCompatibleTextRendering = true;
            this.buttonPreviousFrame.UseVisualStyleBackColor = false;
            this.buttonPreviousFrame.Click += new System.EventHandler(this.buttonPreviousFrame_Click);
            // 
            // label126
            // 
            this.label126.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label126.Location = new System.Drawing.Point(24, 49);
            this.label126.Name = "label126";
            this.label126.Padding = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.label126.Size = new System.Drawing.Size(208, 17);
            this.label126.TabIndex = 219;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::SMRPGED.Properties.Resources.foward;
            this.button1.Location = new System.Drawing.Point(234, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 17);
            this.button1.TabIndex = 34;
            this.toolTip1.SetToolTip(this.button1, "View next page");
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNextFrame
            // 
            this.buttonNextFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonNextFrame.FlatAppearance.BorderSize = 0;
            this.buttonNextFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextFrame.Image = global::SMRPGED.Properties.Resources.foward;
            this.buttonNextFrame.Location = new System.Drawing.Point(25, 260);
            this.buttonNextFrame.Name = "buttonNextFrame";
            this.buttonNextFrame.Size = new System.Drawing.Size(22, 17);
            this.buttonNextFrame.TabIndex = 10;
            this.toolTip1.SetToolTip(this.buttonNextFrame, "View next image");
            this.buttonNextFrame.UseCompatibleTextRendering = true;
            this.buttonNextFrame.UseVisualStyleBackColor = false;
            this.buttonNextFrame.Click += new System.EventHandler(this.buttonNextFrame_Click);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel29.Controls.Add(this.LabelMonsterValMgDef);
            this.panel29.Controls.Add(this.LabelMonsterValSpeed);
            this.panel29.Controls.Add(this.LabelMonsterValMgAtk);
            this.panel29.Controls.Add(this.LabelMonsterValAtk);
            this.panel29.Controls.Add(this.LabelMonsterValDef);
            this.panel29.Controls.Add(this.LabelMonsterVitalStats);
            this.panel29.Controls.Add(this.MonsterValAtk);
            this.panel29.Controls.Add(this.MonsterValMgDef);
            this.panel29.Controls.Add(this.MonsterValSpeed);
            this.panel29.Controls.Add(this.MonsterValFP);
            this.panel29.Controls.Add(this.MonsterValHP);
            this.panel29.Controls.Add(this.MonsterValMgAtk);
            this.panel29.Controls.Add(this.MonsterValDef);
            this.panel29.Controls.Add(this.LabelMonsterValFP);
            this.panel29.Controls.Add(this.LabelMonsterValHP);
            this.panel29.Controls.Add(this.LabelMonsterValEvd);
            this.panel29.Controls.Add(this.MonsterValEvd);
            this.panel29.Controls.Add(this.LabelMonsterValMgEvd);
            this.panel29.Controls.Add(this.MonsterValMgEvd);
            this.panel29.Location = new System.Drawing.Point(2, 2);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(194, 180);
            this.panel29.TabIndex = 5;
            // 
            // LabelMonsterValMgDef
            // 
            this.LabelMonsterValMgDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValMgDef.Location = new System.Drawing.Point(0, 109);
            this.LabelMonsterValMgDef.Name = "LabelMonsterValMgDef";
            this.LabelMonsterValMgDef.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValMgDef.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValMgDef.TabIndex = 6;
            this.LabelMonsterValMgDef.Text = "Magic Defense";
            // 
            // LabelMonsterValSpeed
            // 
            this.LabelMonsterValSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValSpeed.Location = new System.Drawing.Point(0, 127);
            this.LabelMonsterValSpeed.Name = "LabelMonsterValSpeed";
            this.LabelMonsterValSpeed.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValSpeed.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValSpeed.TabIndex = 7;
            this.LabelMonsterValSpeed.Text = "Speed";
            // 
            // LabelMonsterValMgAtk
            // 
            this.LabelMonsterValMgAtk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValMgAtk.Location = new System.Drawing.Point(0, 91);
            this.LabelMonsterValMgAtk.Name = "LabelMonsterValMgAtk";
            this.LabelMonsterValMgAtk.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValMgAtk.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValMgAtk.TabIndex = 5;
            this.LabelMonsterValMgAtk.Text = "Magic Attack";
            // 
            // LabelMonsterValAtk
            // 
            this.LabelMonsterValAtk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValAtk.Location = new System.Drawing.Point(0, 55);
            this.LabelMonsterValAtk.Name = "LabelMonsterValAtk";
            this.LabelMonsterValAtk.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValAtk.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValAtk.TabIndex = 3;
            this.LabelMonsterValAtk.Text = "Attack";
            // 
            // LabelMonsterValDef
            // 
            this.LabelMonsterValDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValDef.Location = new System.Drawing.Point(0, 73);
            this.LabelMonsterValDef.Name = "LabelMonsterValDef";
            this.LabelMonsterValDef.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValDef.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValDef.TabIndex = 4;
            this.LabelMonsterValDef.Text = "Defense";
            // 
            // LabelMonsterVitalStats
            // 
            this.LabelMonsterVitalStats.BackColor = System.Drawing.SystemColors.Control;
            this.LabelMonsterVitalStats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMonsterVitalStats.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelMonsterVitalStats.Location = new System.Drawing.Point(0, 0);
            this.LabelMonsterVitalStats.Name = "LabelMonsterVitalStats";
            this.LabelMonsterVitalStats.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LabelMonsterVitalStats.Size = new System.Drawing.Size(195, 17);
            this.LabelMonsterVitalStats.TabIndex = 0;
            this.LabelMonsterVitalStats.Text = "VITAL STATS...";
            this.LabelMonsterVitalStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonsterValAtk
            // 
            this.MonsterValAtk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValAtk.Location = new System.Drawing.Point(98, 55);
            this.MonsterValAtk.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValAtk.Name = "MonsterValAtk";
            this.MonsterValAtk.Size = new System.Drawing.Size(97, 17);
            this.MonsterValAtk.TabIndex = 12;
            this.MonsterValAtk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValAtk.ValueChanged += new System.EventHandler(this.MonsterValAtk_ValueChanged);
            // 
            // MonsterValMgDef
            // 
            this.MonsterValMgDef.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValMgDef.Location = new System.Drawing.Point(98, 109);
            this.MonsterValMgDef.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValMgDef.Name = "MonsterValMgDef";
            this.MonsterValMgDef.Size = new System.Drawing.Size(97, 17);
            this.MonsterValMgDef.TabIndex = 15;
            this.MonsterValMgDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValMgDef.ValueChanged += new System.EventHandler(this.MonsterValMgDef_ValueChanged);
            // 
            // MonsterValSpeed
            // 
            this.MonsterValSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValSpeed.Location = new System.Drawing.Point(98, 127);
            this.MonsterValSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValSpeed.Name = "MonsterValSpeed";
            this.MonsterValSpeed.Size = new System.Drawing.Size(97, 17);
            this.MonsterValSpeed.TabIndex = 16;
            this.MonsterValSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValSpeed.ValueChanged += new System.EventHandler(this.MonsterValSpeed_ValueChanged);
            // 
            // MonsterValFP
            // 
            this.MonsterValFP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValFP.Location = new System.Drawing.Point(98, 37);
            this.MonsterValFP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValFP.Name = "MonsterValFP";
            this.MonsterValFP.Size = new System.Drawing.Size(97, 17);
            this.MonsterValFP.TabIndex = 11;
            this.MonsterValFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValFP.ValueChanged += new System.EventHandler(this.MonsterValFP_ValueChanged);
            // 
            // MonsterValHP
            // 
            this.MonsterValHP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValHP.Location = new System.Drawing.Point(98, 19);
            this.MonsterValHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MonsterValHP.Name = "MonsterValHP";
            this.MonsterValHP.Size = new System.Drawing.Size(97, 17);
            this.MonsterValHP.TabIndex = 10;
            this.MonsterValHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValHP.ValueChanged += new System.EventHandler(this.MonsterValHP_ValueChanged);
            // 
            // MonsterValMgAtk
            // 
            this.MonsterValMgAtk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValMgAtk.Location = new System.Drawing.Point(98, 91);
            this.MonsterValMgAtk.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValMgAtk.Name = "MonsterValMgAtk";
            this.MonsterValMgAtk.Size = new System.Drawing.Size(97, 17);
            this.MonsterValMgAtk.TabIndex = 14;
            this.MonsterValMgAtk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValMgAtk.ValueChanged += new System.EventHandler(this.MonsterValMgAtk_ValueChanged);
            // 
            // MonsterValDef
            // 
            this.MonsterValDef.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValDef.Location = new System.Drawing.Point(98, 73);
            this.MonsterValDef.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValDef.Name = "MonsterValDef";
            this.MonsterValDef.Size = new System.Drawing.Size(97, 17);
            this.MonsterValDef.TabIndex = 13;
            this.MonsterValDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValDef.ValueChanged += new System.EventHandler(this.MonsterValDef_ValueChanged);
            // 
            // LabelMonsterValFP
            // 
            this.LabelMonsterValFP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValFP.Location = new System.Drawing.Point(0, 37);
            this.LabelMonsterValFP.Name = "LabelMonsterValFP";
            this.LabelMonsterValFP.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValFP.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValFP.TabIndex = 2;
            this.LabelMonsterValFP.Text = "FP";
            // 
            // LabelMonsterValHP
            // 
            this.LabelMonsterValHP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValHP.Location = new System.Drawing.Point(0, 19);
            this.LabelMonsterValHP.Name = "LabelMonsterValHP";
            this.LabelMonsterValHP.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValHP.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValHP.TabIndex = 1;
            this.LabelMonsterValHP.Text = "HP";
            // 
            // LabelMonsterValEvd
            // 
            this.LabelMonsterValEvd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValEvd.Location = new System.Drawing.Point(0, 145);
            this.LabelMonsterValEvd.Name = "LabelMonsterValEvd";
            this.LabelMonsterValEvd.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValEvd.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValEvd.TabIndex = 8;
            this.LabelMonsterValEvd.Text = "Evade%";
            // 
            // MonsterValEvd
            // 
            this.MonsterValEvd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValEvd.Location = new System.Drawing.Point(98, 145);
            this.MonsterValEvd.Name = "MonsterValEvd";
            this.MonsterValEvd.Size = new System.Drawing.Size(97, 17);
            this.MonsterValEvd.TabIndex = 17;
            this.MonsterValEvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValEvd.ValueChanged += new System.EventHandler(this.MonsterValEvd_ValueChanged);
            // 
            // LabelMonsterValMgEvd
            // 
            this.LabelMonsterValMgEvd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterValMgEvd.Location = new System.Drawing.Point(0, 163);
            this.LabelMonsterValMgEvd.Name = "LabelMonsterValMgEvd";
            this.LabelMonsterValMgEvd.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterValMgEvd.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterValMgEvd.TabIndex = 9;
            this.LabelMonsterValMgEvd.Text = "Magic Evade%";
            // 
            // MonsterValMgEvd
            // 
            this.MonsterValMgEvd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValMgEvd.Location = new System.Drawing.Point(98, 163);
            this.MonsterValMgEvd.Name = "MonsterValMgEvd";
            this.MonsterValMgEvd.Size = new System.Drawing.Size(97, 17);
            this.MonsterValMgEvd.TabIndex = 18;
            this.MonsterValMgEvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValMgEvd.ValueChanged += new System.EventHandler(this.MonsterValMgEvd_ValueChanged);
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.MonsterYoshiCookie);
            this.panel62.Location = new System.Drawing.Point(98, 90);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(97, 17);
            this.panel62.TabIndex = 10;
            // 
            // MonsterYoshiCookie
            // 
            this.MonsterYoshiCookie.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MonsterYoshiCookie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MonsterYoshiCookie.DropDownHeight = 314;
            this.MonsterYoshiCookie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterYoshiCookie.DropDownWidth = 150;
            this.MonsterYoshiCookie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonsterYoshiCookie.ForeColor = System.Drawing.SystemColors.Control;
            this.MonsterYoshiCookie.IntegralHeight = false;
            this.MonsterYoshiCookie.Location = new System.Drawing.Point(-2, -2);
            this.MonsterYoshiCookie.Name = "MonsterYoshiCookie";
            this.MonsterYoshiCookie.Size = new System.Drawing.Size(101, 22);
            this.MonsterYoshiCookie.TabIndex = 0;
            this.MonsterYoshiCookie.Tag = "";
            this.MonsterYoshiCookie.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.MonsterYoshiCookie.SelectedIndexChanged += new System.EventHandler(this.MonsterYoshiCookie_SelectedIndexChanged);
            // 
            // LabelMonsterYoshiCookie
            // 
            this.LabelMonsterYoshiCookie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.LabelMonsterYoshiCookie.Location = new System.Drawing.Point(0, 90);
            this.LabelMonsterYoshiCookie.Name = "LabelMonsterYoshiCookie";
            this.LabelMonsterYoshiCookie.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterYoshiCookie.Size = new System.Drawing.Size(97, 17);
            this.LabelMonsterYoshiCookie.TabIndex = 5;
            this.LabelMonsterYoshiCookie.Text = "Yoshi Cookie";
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel54.Controls.Add(this.panel62);
            this.panel54.Controls.Add(this.panel72);
            this.panel54.Controls.Add(this.panel73);
            this.panel54.Controls.Add(this.LabelMonsterRewardStats);
            this.panel54.Controls.Add(this.MonsterValExp);
            this.panel54.Controls.Add(this.MonsterValCoins);
            this.panel54.Controls.Add(this.label22);
            this.panel54.Controls.Add(this.label21);
            this.panel54.Controls.Add(this.LabelMonsterYoshiCookie);
            this.panel54.Controls.Add(this.label31);
            this.panel54.Controls.Add(this.label24);
            this.panel54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel54.Location = new System.Drawing.Point(2, 2);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(194, 107);
            this.panel54.TabIndex = 14;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.ItemWinB);
            this.panel72.Location = new System.Drawing.Point(98, 72);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(97, 17);
            this.panel72.TabIndex = 9;
            // 
            // ItemWinB
            // 
            this.ItemWinB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemWinB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemWinB.DropDownHeight = 314;
            this.ItemWinB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemWinB.DropDownWidth = 150;
            this.ItemWinB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemWinB.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemWinB.IntegralHeight = false;
            this.ItemWinB.Location = new System.Drawing.Point(-2, -2);
            this.ItemWinB.Name = "ItemWinB";
            this.ItemWinB.Size = new System.Drawing.Size(101, 22);
            this.ItemWinB.TabIndex = 0;
            this.ItemWinB.Tag = "";
            this.ItemWinB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.ItemWinB.SelectedIndexChanged += new System.EventHandler(this.ItemWinB_SelectedIndexChanged);
            // 
            // panel73
            // 
            this.panel73.Controls.Add(this.ItemWinA);
            this.panel73.Location = new System.Drawing.Point(98, 54);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(97, 17);
            this.panel73.TabIndex = 8;
            // 
            // ItemWinA
            // 
            this.ItemWinA.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ItemWinA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemWinA.DropDownHeight = 314;
            this.ItemWinA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemWinA.DropDownWidth = 150;
            this.ItemWinA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemWinA.ForeColor = System.Drawing.SystemColors.Control;
            this.ItemWinA.IntegralHeight = false;
            this.ItemWinA.Location = new System.Drawing.Point(-2, -2);
            this.ItemWinA.Name = "ItemWinA";
            this.ItemWinA.Size = new System.Drawing.Size(101, 22);
            this.ItemWinA.TabIndex = 0;
            this.ItemWinA.Tag = "";
            this.ItemWinA.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.ItemWinA.SelectedIndexChanged += new System.EventHandler(this.ItemWinA_SelectedIndexChanged);
            // 
            // LabelMonsterRewardStats
            // 
            this.LabelMonsterRewardStats.BackColor = System.Drawing.SystemColors.Control;
            this.LabelMonsterRewardStats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMonsterRewardStats.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelMonsterRewardStats.Location = new System.Drawing.Point(0, -1);
            this.LabelMonsterRewardStats.Name = "LabelMonsterRewardStats";
            this.LabelMonsterRewardStats.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LabelMonsterRewardStats.Size = new System.Drawing.Size(195, 17);
            this.LabelMonsterRewardStats.TabIndex = 0;
            this.LabelMonsterRewardStats.Text = "REWARD STATS...";
            this.LabelMonsterRewardStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonsterValExp
            // 
            this.MonsterValExp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValExp.Location = new System.Drawing.Point(98, 18);
            this.MonsterValExp.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.MonsterValExp.Name = "MonsterValExp";
            this.MonsterValExp.Size = new System.Drawing.Size(97, 17);
            this.MonsterValExp.TabIndex = 6;
            this.MonsterValExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValExp.ValueChanged += new System.EventHandler(this.MonsterValExp_ValueChanged);
            // 
            // MonsterValCoins
            // 
            this.MonsterValCoins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValCoins.Location = new System.Drawing.Point(98, 36);
            this.MonsterValCoins.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MonsterValCoins.Name = "MonsterValCoins";
            this.MonsterValCoins.Size = new System.Drawing.Size(97, 17);
            this.MonsterValCoins.TabIndex = 7;
            this.MonsterValCoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValCoins.ValueChanged += new System.EventHandler(this.MonsterValCoins_ValueChanged);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label22.Location = new System.Drawing.Point(0, 18);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label22.Size = new System.Drawing.Size(97, 17);
            this.label22.TabIndex = 1;
            this.label22.Text = "Experience";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(0, 36);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label21.Size = new System.Drawing.Size(97, 17);
            this.label21.TabIndex = 2;
            this.label21.Text = "Coins";
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label31.Location = new System.Drawing.Point(0, 54);
            this.label31.Name = "label31";
            this.label31.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label31.Size = new System.Drawing.Size(97, 17);
            this.label31.TabIndex = 3;
            this.label31.Text = "Item Win (5%)";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label24.Location = new System.Drawing.Point(0, 72);
            this.label24.Name = "label24";
            this.label24.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label24.Size = new System.Drawing.Size(97, 17);
            this.label24.TabIndex = 4;
            this.label24.Text = "Item Win (25%)";
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel56.Controls.Add(this.panel68);
            this.panel56.Controls.Add(this.panel67);
            this.panel56.Controls.Add(this.panel69);
            this.panel56.Controls.Add(this.panel70);
            this.panel56.Controls.Add(this.panel71);
            this.panel56.Controls.Add(this.MonsterValElevation);
            this.panel56.Controls.Add(this.label2);
            this.panel56.Controls.Add(this.label211);
            this.panel56.Controls.Add(this.label191);
            this.panel56.Controls.Add(this.label210);
            this.panel56.Controls.Add(this.panel65);
            this.panel56.Controls.Add(this.label216);
            this.panel56.Controls.Add(this.label51);
            this.panel56.Controls.Add(this.label26);
            this.panel56.Controls.Add(this.label63);
            this.panel56.Location = new System.Drawing.Point(2, 2);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(194, 144);
            this.panel56.TabIndex = 20;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.MonsterSoundOther);
            this.panel68.Location = new System.Drawing.Point(98, 109);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(97, 17);
            this.panel68.TabIndex = 13;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.MonsterBehavior);
            this.panel67.Location = new System.Drawing.Point(98, 73);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(97, 17);
            this.panel67.TabIndex = 11;
            // 
            // MonsterBehavior
            // 
            this.MonsterBehavior.DropDownHeight = 236;
            this.MonsterBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterBehavior.DropDownWidth = 250;
            this.MonsterBehavior.IntegralHeight = false;
            this.MonsterBehavior.Items.AddRange(new object[] {
            "no movement for \"Escape\"",
            "slide backward when hit",
            "Bowser Clone sprite",
            "Mario Clone sprite",
            "no reaction when hit",
            "sprite shadow",
            "floating, sprite shadow",
            "floating",
            "floating, slide backward when hit",
            "floating, slide backward when hit",
            "fade out death, floating",
            "fade out death",
            "fade out death",
            "fade out death, Smithy spell cast",
            "fade out death, no \"Escape\" movement",
            "fade out death, no \"Escape\" transition",
            "(normal)",
            "no reaction when hit"});
            this.MonsterBehavior.Location = new System.Drawing.Point(-2, -2);
            this.MonsterBehavior.Name = "MonsterBehavior";
            this.MonsterBehavior.Size = new System.Drawing.Size(101, 21);
            this.MonsterBehavior.TabIndex = 0;
            this.MonsterBehavior.SelectedIndexChanged += new System.EventHandler(this.MonsterBehavior_SelectedIndexChanged);
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.MonsterSoundStrike);
            this.panel69.Location = new System.Drawing.Point(98, 91);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(97, 17);
            this.panel69.TabIndex = 12;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.MonsterEntranceStyle);
            this.panel70.Location = new System.Drawing.Point(98, 55);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(97, 17);
            this.panel70.TabIndex = 10;
            // 
            // MonsterEntranceStyle
            // 
            this.MonsterEntranceStyle.BackColor = System.Drawing.SystemColors.Window;
            this.MonsterEntranceStyle.DropDownHeight = 210;
            this.MonsterEntranceStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterEntranceStyle.DropDownWidth = 150;
            this.MonsterEntranceStyle.IntegralHeight = false;
            this.MonsterEntranceStyle.Items.AddRange(new object[] {
            "none",
            "slide in",
            "long jump",
            "hop 3 times",
            "drop from above",
            "zoom in from right",
            "zoom in from left",
            "spread out from back",
            "hover in",
            "ready to attack",
            "fade in",
            "slow drop from above",
            "wait, then appear",
            "spread from front",
            "spread from middle",
            "ready to attack"});
            this.MonsterEntranceStyle.Location = new System.Drawing.Point(-2, -2);
            this.MonsterEntranceStyle.Name = "MonsterEntranceStyle";
            this.MonsterEntranceStyle.Size = new System.Drawing.Size(101, 21);
            this.MonsterEntranceStyle.TabIndex = 0;
            this.MonsterEntranceStyle.SelectedIndexChanged += new System.EventHandler(this.MonsterEntranceStyle_SelectedIndexChanged);
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.MonsterCoinSize);
            this.panel71.Location = new System.Drawing.Point(98, 37);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(97, 17);
            this.panel71.TabIndex = 9;
            // 
            // MonsterCoinSize
            // 
            this.MonsterCoinSize.BackColor = System.Drawing.SystemColors.Window;
            this.MonsterCoinSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterCoinSize.IntegralHeight = false;
            this.MonsterCoinSize.Items.AddRange(new object[] {
            "No Coin",
            "Small Coin",
            "Big Coin"});
            this.MonsterCoinSize.Location = new System.Drawing.Point(-2, -2);
            this.MonsterCoinSize.Name = "MonsterCoinSize";
            this.MonsterCoinSize.Size = new System.Drawing.Size(101, 21);
            this.MonsterCoinSize.TabIndex = 0;
            this.MonsterCoinSize.SelectedIndexChanged += new System.EventHandler(this.MonsterCoinSize_SelectedIndexChanged);
            // 
            // MonsterValElevation
            // 
            this.MonsterValElevation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonsterValElevation.Location = new System.Drawing.Point(98, 127);
            this.MonsterValElevation.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.MonsterValElevation.Name = "MonsterValElevation";
            this.MonsterValElevation.Size = new System.Drawing.Size(97, 17);
            this.MonsterValElevation.TabIndex = 14;
            this.MonsterValElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonsterValElevation.ValueChanged += new System.EventHandler(this.MonsterValElevation_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "OTHER PROPERTIES...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label211
            // 
            this.label211.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label211.Location = new System.Drawing.Point(0, 73);
            this.label211.Name = "label211";
            this.label211.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label211.Size = new System.Drawing.Size(97, 17);
            this.label211.TabIndex = 4;
            this.label211.Text = "Sprite Behavior";
            // 
            // label191
            // 
            this.label191.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label191.Location = new System.Drawing.Point(0, 55);
            this.label191.Name = "label191";
            this.label191.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label191.Size = new System.Drawing.Size(97, 17);
            this.label191.TabIndex = 3;
            this.label191.Text = "Entrance Style";
            // 
            // label210
            // 
            this.label210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label210.Location = new System.Drawing.Point(0, 127);
            this.label210.Name = "label210";
            this.label210.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label210.Size = new System.Drawing.Size(97, 17);
            this.label210.TabIndex = 7;
            this.label210.Text = "Elevate";
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.MonsterMorphSuccess);
            this.panel65.Location = new System.Drawing.Point(98, 19);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(97, 17);
            this.panel65.TabIndex = 8;
            // 
            // MonsterMorphSuccess
            // 
            this.MonsterMorphSuccess.BackColor = System.Drawing.SystemColors.Window;
            this.MonsterMorphSuccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterMorphSuccess.IntegralHeight = false;
            this.MonsterMorphSuccess.Items.AddRange(new object[] {
            "0% success",
            "25% success",
            "75% success",
            "100% success"});
            this.MonsterMorphSuccess.Location = new System.Drawing.Point(-2, -2);
            this.MonsterMorphSuccess.Name = "MonsterMorphSuccess";
            this.MonsterMorphSuccess.Size = new System.Drawing.Size(101, 21);
            this.MonsterMorphSuccess.TabIndex = 0;
            this.MonsterMorphSuccess.SelectedIndexChanged += new System.EventHandler(this.MonsterMorphSuccess_SelectedIndexChanged);
            // 
            // label216
            // 
            this.label216.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label216.Location = new System.Drawing.Point(0, 19);
            this.label216.Name = "label216";
            this.label216.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label216.Size = new System.Drawing.Size(97, 17);
            this.label216.TabIndex = 1;
            this.label216.Text = "Morph Success";
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label51.Location = new System.Drawing.Point(0, 109);
            this.label51.Name = "label51";
            this.label51.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label51.Size = new System.Drawing.Size(97, 17);
            this.label51.TabIndex = 6;
            this.label51.Text = "Other Sound";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label26.Location = new System.Drawing.Point(0, 37);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label26.Size = new System.Drawing.Size(97, 17);
            this.label26.TabIndex = 2;
            this.label26.Text = "Coin Sprite";
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label63.Location = new System.Drawing.Point(0, 91);
            this.label63.Name = "label63";
            this.label63.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label63.Size = new System.Drawing.Size(97, 17);
            this.label63.TabIndex = 5;
            this.label63.Text = "Strike Sound";
            // 
            // pictureBoxPsychopath
            // 
            this.pictureBoxPsychopath.Location = new System.Drawing.Point(0, 17);
            this.pictureBoxPsychopath.Name = "pictureBoxPsychopath";
            this.pictureBoxPsychopath.Size = new System.Drawing.Size(256, 32);
            this.pictureBoxPsychopath.TabIndex = 343;
            this.pictureBoxPsychopath.TabStop = false;
            this.pictureBoxPsychopath.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPsychopath_Paint);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label3.Size = new System.Drawing.Size(398, 17);
            this.label3.TabIndex = 538;
            this.label3.Text = "FORMATION PACKS...";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(0, 239);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label20.Size = new System.Drawing.Size(91, 17);
            this.label20.TabIndex = 536;
            this.label20.Text = "BG Preview";
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.panel201);
            this.panel83.Controls.Add(this.searchFormationPacks);
            this.panel83.Controls.Add(this.packNum);
            this.panel83.Controls.Add(this.label178);
            this.panel83.Controls.Add(this.label3);
            this.panel83.Location = new System.Drawing.Point(6, 308);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(402, 40);
            this.panel83.TabIndex = 4;
            // 
            // panel201
            // 
            this.panel201.BackColor = System.Drawing.SystemColors.Control;
            this.panel201.Location = new System.Drawing.Point(269, 21);
            this.panel201.Name = "panel201";
            this.panel201.Size = new System.Drawing.Size(131, 17);
            this.panel201.TabIndex = 540;
            // 
            // searchFormationPacks
            // 
            this.searchFormationPacks.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchFormationPacks.BackgroundImage = global::SMRPGED.Properties.Resources.search;
            this.searchFormationPacks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchFormationPacks.FlatAppearance.BorderSize = 0;
            this.searchFormationPacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchFormationPacks.Location = new System.Drawing.Point(2, 21);
            this.searchFormationPacks.Name = "searchFormationPacks";
            this.searchFormationPacks.Size = new System.Drawing.Size(19, 17);
            this.searchFormationPacks.TabIndex = 84;
            this.toolTip1.SetToolTip(this.searchFormationPacks, "Search packs...");
            this.searchFormationPacks.UseCompatibleTextRendering = true;
            this.searchFormationPacks.UseVisualStyleBackColor = false;
            this.searchFormationPacks.Click += new System.EventHandler(this.searchFormationPacks_Click);
            // 
            // packNum
            // 
            this.packNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.packNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packNum.ForeColor = System.Drawing.SystemColors.Control;
            this.packNum.Location = new System.Drawing.Point(135, 21);
            this.packNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.packNum.Name = "packNum";
            this.packNum.Size = new System.Drawing.Size(133, 17);
            this.packNum.TabIndex = 85;
            this.packNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.packNum.ValueChanged += new System.EventHandler(this.packNum_ValueChanged);
            // 
            // label178
            // 
            this.label178.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label178.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label178.ForeColor = System.Drawing.SystemColors.Control;
            this.label178.Location = new System.Drawing.Point(23, 21);
            this.label178.Name = "label178";
            this.label178.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label178.Size = new System.Drawing.Size(111, 17);
            this.label178.TabIndex = 278;
            this.label178.Text = "PACK #";
            // 
            // label179
            // 
            this.label179.BackColor = System.Drawing.SystemColors.Control;
            this.label179.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label179.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label179.Location = new System.Drawing.Point(0, 19);
            this.label179.Name = "label179";
            this.label179.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label179.Size = new System.Drawing.Size(132, 17);
            this.label179.TabIndex = 279;
            this.label179.Text = "Formation Set";
            // 
            // panel81
            // 
            this.panel81.BackColor = System.Drawing.SystemColors.Control;
            this.panel81.Controls.Add(this.formationSet);
            this.panel81.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel81.Location = new System.Drawing.Point(133, 19);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(265, 17);
            this.panel81.TabIndex = 86;
            // 
            // formationSet
            // 
            this.formationSet.BackColor = System.Drawing.SystemColors.Window;
            this.formationSet.DropDownHeight = 420;
            this.formationSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationSet.IntegralHeight = false;
            this.formationSet.Items.AddRange(new object[] {
            "Formations 0 - 255",
            "Formations 256 - 511"});
            this.formationSet.Location = new System.Drawing.Point(-2, -2);
            this.formationSet.Name = "formationSet";
            this.formationSet.Size = new System.Drawing.Size(270, 21);
            this.formationSet.TabIndex = 86;
            this.formationSet.SelectedIndexChanged += new System.EventHandler(this.formationSet_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.richTextBox2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 112);
            this.panel3.TabIndex = 88;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(4, 4);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(124, 104);
            this.richTextBox2.TabIndex = 88;
            this.richTextBox2.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.richTextBox3);
            this.panel4.Location = new System.Drawing.Point(133, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(132, 112);
            this.panel4.TabIndex = 91;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(4, 4);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(124, 104);
            this.richTextBox3.TabIndex = 92;
            this.richTextBox3.Text = "";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.richTextBox4);
            this.panel5.Location = new System.Drawing.Point(266, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(132, 112);
            this.panel5.TabIndex = 95;
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(4, 4);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(124, 104);
            this.richTextBox4.TabIndex = 95;
            this.richTextBox4.Text = "";
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.battlefieldName);
            this.panel39.Location = new System.Drawing.Point(92, 239);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(165, 17);
            this.panel39.TabIndex = 84;
            // 
            // battlefieldName
            // 
            this.battlefieldName.BackColor = System.Drawing.SystemColors.Control;
            this.battlefieldName.DropDownHeight = 262;
            this.battlefieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldName.DropDownWidth = 220;
            this.battlefieldName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.battlefieldName.IntegralHeight = false;
            this.battlefieldName.Items.AddRange(new object[] {
            "Forest Maze",
            "Forest Maze: Bowyer\'s Pad",
            "Bean Valley: Beanstalks",
            "Sunken Ship: King Calamari\'s Cellar",
            "Sunken Ship",
            "Moleville Mines",
            "___mines",
            "Bowser\'s Keep",
            "Barrel Volcano: Czar Dragon\'s Pad",
            "Grasslands",
            "Mountains",
            "Mushroom Kingdom House",
            "Booster Tower",
            "Mushroom Kingdom Castle",
            "Kero Sewers: Underwater",
            "Mushroom Kingdom Castle",
            "Bowser\'s Keep Turret: Exor",
            "Booster Tower: Balcony",
            "Smithy Factory: Count Down\'s Pad",
            "Smithy Factory",
            "Barrel Volcano",
            "Kero Sewers",
            "Nimbus Castle",
            "Nimbus Castle: Birdo\'s Room",
            "Nimbus Land",
            "Underground",
            "___uses Mushroom Kingdom tiles",
            "___forested area with unique trees",
            "Mushroom Kingdom",
            "Bowser\'s Keep: Chandeliers",
            "Forest Maze: Path to Bowyer",
            "Level Up foreground",
            "Level Up background",
            "Grasslands",
            "___sea enclave",
            "Marrymore Chapel Sanctuary",
            "Star Hill",
            "Seaside Town Beach",
            "Sea",
            "Blade: Axem Rangers",
            "Smithy Factory: Domino & Cloaker\'s Pad",
            "Bean Valley: Grasslands",
            "Belome Temple",
            "Land\'s End Desert",
            "Factory Grounds: Smithy\'s Pad",
            "Smithy\'s Final Form",
            "Jinx\'s Dojo",
            "Culex",
            "Factory Grounds",
            "Bean Valley: Pipe Room",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____"});
            this.battlefieldName.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldName.Name = "battlefieldName";
            this.battlefieldName.Size = new System.Drawing.Size(169, 21);
            this.battlefieldName.TabIndex = 84;
            this.battlefieldName.SelectedIndexChanged += new System.EventHandler(this.battlefieldName_SelectedIndexChanged);
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.formationNameList);
            this.panel37.Location = new System.Drawing.Point(21, 0);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(202, 17);
            this.panel37.TabIndex = 43;
            // 
            // formationNameList
            // 
            this.formationNameList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationNameList.DropDownHeight = 522;
            this.formationNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationNameList.DropDownWidth = 650;
            this.formationNameList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formationNameList.ForeColor = System.Drawing.SystemColors.Control;
            this.formationNameList.IntegralHeight = false;
            this.formationNameList.Location = new System.Drawing.Point(-2, -2);
            this.formationNameList.Name = "formationNameList";
            this.formationNameList.Size = new System.Drawing.Size(206, 21);
            this.formationNameList.TabIndex = 43;
            this.formationNameList.SelectedIndexChanged += new System.EventHandler(this.formationNameList_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.Control;
            this.label19.Location = new System.Drawing.Point(2, 2);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label19.Size = new System.Drawing.Size(256, 17);
            this.label19.TabIndex = 451;
            this.label19.Text = "FORMATION NOTES...";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel34.BackColor = System.Drawing.SystemColors.Window;
            this.panel34.Controls.Add(this.richTextBox8);
            this.panel34.Location = new System.Drawing.Point(2, 21);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(256, 279);
            this.panel34.TabIndex = 98;
            // 
            // richTextBox8
            // 
            this.richTextBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox8.Location = new System.Drawing.Point(4, 4);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(248, 271);
            this.richTextBox8.TabIndex = 99;
            this.richTextBox8.Text = "";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(256, 17);
            this.label5.TabIndex = 288;
            this.label5.Text = "FORMATION BATTLE SCREENSHOT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.Control;
            this.label27.Location = new System.Drawing.Point(224, 0);
            this.label27.Name = "label27";
            this.label27.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label27.Size = new System.Drawing.Size(91, 17);
            this.label27.TabIndex = 458;
            this.label27.Text = "FORMATION #";
            // 
            // formationNum
            // 
            this.formationNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formationNum.ForeColor = System.Drawing.SystemColors.Control;
            this.formationNum.Location = new System.Drawing.Point(316, 0);
            this.formationNum.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.formationNum.Name = "formationNum";
            this.formationNum.Size = new System.Drawing.Size(83, 17);
            this.formationNum.TabIndex = 44;
            this.formationNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationNum.ValueChanged += new System.EventHandler(this.formationNum_ValueChanged);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel36.Controls.Add(this.label4);
            this.panel36.Controls.Add(this.panel6);
            this.panel36.Controls.Add(this.panel51);
            this.panel36.Controls.Add(this.panel75);
            this.panel36.Controls.Add(this.panel76);
            this.panel36.Controls.Add(this.panel77);
            this.panel36.Controls.Add(this.panel78);
            this.panel36.Controls.Add(this.panel79);
            this.panel36.Controls.Add(this.panel80);
            this.panel36.Controls.Add(this.label40);
            this.panel36.Controls.Add(this.label39);
            this.panel36.Controls.Add(this.label38);
            this.panel36.Controls.Add(this.label37);
            this.panel36.Controls.Add(this.label36);
            this.panel36.Controls.Add(this.label35);
            this.panel36.Controls.Add(this.label45);
            this.panel36.Controls.Add(this.label50);
            this.panel36.Controls.Add(this.label174);
            this.panel36.Controls.Add(this.label173);
            this.panel36.Controls.Add(this.label46);
            this.panel36.Controls.Add(this.label47);
            this.panel36.Controls.Add(this.label48);
            this.panel36.Controls.Add(this.label175);
            this.panel36.Controls.Add(this.label49);
            this.panel36.Controls.Add(this.formationByte1);
            this.panel36.Controls.Add(this.formationByte2);
            this.panel36.Controls.Add(this.formationByte3);
            this.panel36.Controls.Add(this.formationByte8);
            this.panel36.Controls.Add(this.formationByte5);
            this.panel36.Controls.Add(this.formationByte7);
            this.panel36.Controls.Add(this.formationByte6);
            this.panel36.Controls.Add(this.formationByte4);
            this.panel36.Controls.Add(this.panelFormationUse);
            this.panel36.Controls.Add(this.panelFormationHide);
            this.panel36.Controls.Add(this.formationCoordY1);
            this.panel36.Controls.Add(this.formationCoordY2);
            this.panel36.Controls.Add(this.formationCoordY3);
            this.panel36.Controls.Add(this.formationCoordY8);
            this.panel36.Controls.Add(this.formationCoordY5);
            this.panel36.Controls.Add(this.formationCoordY7);
            this.panel36.Controls.Add(this.formationCoordY6);
            this.panel36.Controls.Add(this.formationCoordY4);
            this.panel36.Controls.Add(this.formationCoordX1);
            this.panel36.Controls.Add(this.formationCoordX2);
            this.panel36.Controls.Add(this.formationCoordX3);
            this.panel36.Controls.Add(this.formationCoordX8);
            this.panel36.Controls.Add(this.formationCoordX5);
            this.panel36.Controls.Add(this.formationCoordX7);
            this.panel36.Controls.Add(this.formationCoordX6);
            this.panel36.Controls.Add(this.formationCoordX4);
            this.panel36.Location = new System.Drawing.Point(2, 2);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(398, 181);
            this.panel36.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label4.Size = new System.Drawing.Size(400, 17);
            this.label4.TabIndex = 544;
            this.label4.Text = "FORMATION MONSTERS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.formationName8);
            this.panel6.Location = new System.Drawing.Point(85, 164);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(138, 17);
            this.panel6.TabIndex = 74;
            // 
            // formationName8
            // 
            this.formationName8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName8.DropDownHeight = 418;
            this.formationName8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName8.DropDownWidth = 142;
            this.formationName8.IntegralHeight = false;
            this.formationName8.Location = new System.Drawing.Point(-2, -2);
            this.formationName8.Name = "formationName8";
            this.formationName8.Size = new System.Drawing.Size(142, 22);
            this.formationName8.TabIndex = 74;
            this.formationName8.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName8.SelectedIndexChanged += new System.EventHandler(this.formationName8_SelectedIndexChanged);
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.formationName7);
            this.panel51.Location = new System.Drawing.Point(85, 146);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(138, 17);
            this.panel51.TabIndex = 70;
            // 
            // formationName7
            // 
            this.formationName7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName7.DropDownHeight = 418;
            this.formationName7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName7.DropDownWidth = 142;
            this.formationName7.IntegralHeight = false;
            this.formationName7.Location = new System.Drawing.Point(-2, -2);
            this.formationName7.Name = "formationName7";
            this.formationName7.Size = new System.Drawing.Size(142, 22);
            this.formationName7.TabIndex = 70;
            this.formationName7.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName7.SelectedIndexChanged += new System.EventHandler(this.formationName7_SelectedIndexChanged);
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.formationName6);
            this.panel75.Location = new System.Drawing.Point(85, 128);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(138, 17);
            this.panel75.TabIndex = 66;
            // 
            // formationName6
            // 
            this.formationName6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName6.DropDownHeight = 418;
            this.formationName6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName6.DropDownWidth = 142;
            this.formationName6.IntegralHeight = false;
            this.formationName6.Location = new System.Drawing.Point(-2, -2);
            this.formationName6.Name = "formationName6";
            this.formationName6.Size = new System.Drawing.Size(142, 22);
            this.formationName6.TabIndex = 66;
            this.formationName6.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName6.SelectedIndexChanged += new System.EventHandler(this.formationName6_SelectedIndexChanged);
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.formationName5);
            this.panel76.Location = new System.Drawing.Point(85, 110);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(138, 17);
            this.panel76.TabIndex = 62;
            // 
            // formationName5
            // 
            this.formationName5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName5.DropDownHeight = 418;
            this.formationName5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName5.DropDownWidth = 142;
            this.formationName5.IntegralHeight = false;
            this.formationName5.Location = new System.Drawing.Point(-2, -2);
            this.formationName5.Name = "formationName5";
            this.formationName5.Size = new System.Drawing.Size(142, 22);
            this.formationName5.TabIndex = 62;
            this.formationName5.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName5.SelectedIndexChanged += new System.EventHandler(this.formationName5_SelectedIndexChanged);
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.formationName4);
            this.panel77.Location = new System.Drawing.Point(85, 92);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(138, 17);
            this.panel77.TabIndex = 58;
            // 
            // formationName4
            // 
            this.formationName4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName4.DropDownHeight = 418;
            this.formationName4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName4.DropDownWidth = 142;
            this.formationName4.IntegralHeight = false;
            this.formationName4.Location = new System.Drawing.Point(-2, -2);
            this.formationName4.Name = "formationName4";
            this.formationName4.Size = new System.Drawing.Size(142, 22);
            this.formationName4.TabIndex = 58;
            this.formationName4.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName4.SelectedIndexChanged += new System.EventHandler(this.formationName4_SelectedIndexChanged);
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.formationName3);
            this.panel78.Location = new System.Drawing.Point(85, 74);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(138, 17);
            this.panel78.TabIndex = 54;
            // 
            // formationName3
            // 
            this.formationName3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName3.DropDownHeight = 418;
            this.formationName3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName3.DropDownWidth = 142;
            this.formationName3.IntegralHeight = false;
            this.formationName3.Location = new System.Drawing.Point(-2, -2);
            this.formationName3.Name = "formationName3";
            this.formationName3.Size = new System.Drawing.Size(142, 22);
            this.formationName3.TabIndex = 54;
            this.formationName3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName3.SelectedIndexChanged += new System.EventHandler(this.formationName3_SelectedIndexChanged);
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.formationName2);
            this.panel79.Location = new System.Drawing.Point(85, 56);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(138, 17);
            this.panel79.TabIndex = 50;
            // 
            // formationName2
            // 
            this.formationName2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName2.DropDownHeight = 418;
            this.formationName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName2.DropDownWidth = 142;
            this.formationName2.IntegralHeight = false;
            this.formationName2.Location = new System.Drawing.Point(-2, -2);
            this.formationName2.Name = "formationName2";
            this.formationName2.Size = new System.Drawing.Size(142, 22);
            this.formationName2.TabIndex = 50;
            this.formationName2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName2.SelectedIndexChanged += new System.EventHandler(this.formationName2_SelectedIndexChanged);
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.formationName1);
            this.panel80.Location = new System.Drawing.Point(85, 38);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(138, 17);
            this.panel80.TabIndex = 46;
            // 
            // formationName1
            // 
            this.formationName1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.formationName1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.formationName1.DropDownHeight = 418;
            this.formationName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationName1.DropDownWidth = 142;
            this.formationName1.IntegralHeight = false;
            this.formationName1.Location = new System.Drawing.Point(-2, -2);
            this.formationName1.Name = "formationName1";
            this.formationName1.Size = new System.Drawing.Size(142, 22);
            this.formationName1.TabIndex = 46;
            this.formationName1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.formationName1.SelectedIndexChanged += new System.EventHandler(this.formationName1_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label40.Location = new System.Drawing.Point(0, 38);
            this.label40.Name = "label40";
            this.label40.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label40.Size = new System.Drawing.Size(38, 17);
            this.label40.TabIndex = 524;
            this.label40.Text = "1";
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label39.Location = new System.Drawing.Point(0, 56);
            this.label39.Name = "label39";
            this.label39.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label39.Size = new System.Drawing.Size(38, 17);
            this.label39.TabIndex = 525;
            this.label39.Text = "2";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label38.Location = new System.Drawing.Point(0, 74);
            this.label38.Name = "label38";
            this.label38.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label38.Size = new System.Drawing.Size(38, 17);
            this.label38.TabIndex = 526;
            this.label38.Text = "3";
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label37.Location = new System.Drawing.Point(0, 92);
            this.label37.Name = "label37";
            this.label37.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label37.Size = new System.Drawing.Size(38, 17);
            this.label37.TabIndex = 527;
            this.label37.Text = "4";
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label36.Location = new System.Drawing.Point(0, 110);
            this.label36.Name = "label36";
            this.label36.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label36.Size = new System.Drawing.Size(38, 17);
            this.label36.TabIndex = 528;
            this.label36.Text = "5";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label35.Location = new System.Drawing.Point(0, 128);
            this.label35.Name = "label35";
            this.label35.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label35.Size = new System.Drawing.Size(38, 17);
            this.label35.TabIndex = 529;
            this.label35.Text = "6";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label45.Location = new System.Drawing.Point(0, 146);
            this.label45.Name = "label45";
            this.label45.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label45.Size = new System.Drawing.Size(38, 17);
            this.label45.TabIndex = 530;
            this.label45.Text = "7";
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label50.Location = new System.Drawing.Point(0, 164);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label50.Size = new System.Drawing.Size(38, 17);
            this.label50.TabIndex = 531;
            this.label50.Text = "8";
            // 
            // label174
            // 
            this.label174.BackColor = System.Drawing.SystemColors.Control;
            this.label174.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label174.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label174.Location = new System.Drawing.Point(0, 19);
            this.label174.Name = "label174";
            this.label174.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label174.Size = new System.Drawing.Size(38, 17);
            this.label174.TabIndex = 532;
            this.label174.Text = "#";
            this.label174.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label173
            // 
            this.label173.BackColor = System.Drawing.SystemColors.Control;
            this.label173.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label173.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label173.Location = new System.Drawing.Point(39, 19);
            this.label173.Name = "label173";
            this.label173.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label173.Size = new System.Drawing.Size(45, 17);
            this.label173.TabIndex = 521;
            this.label173.Text = "BYTE";
            this.label173.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label46.Location = new System.Drawing.Point(85, 19);
            this.label46.Name = "label46";
            this.label46.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label46.Size = new System.Drawing.Size(138, 17);
            this.label46.TabIndex = 518;
            this.label46.Text = "MONSTER NAME";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label47.Location = new System.Drawing.Point(224, 19);
            this.label47.Name = "label47";
            this.label47.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label47.Size = new System.Drawing.Size(45, 17);
            this.label47.TabIndex = 519;
            this.label47.Text = "X";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label48.Location = new System.Drawing.Point(270, 19);
            this.label48.Name = "label48";
            this.label48.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label48.Size = new System.Drawing.Size(45, 17);
            this.label48.TabIndex = 520;
            this.label48.Text = "Y";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label175
            // 
            this.label175.BackColor = System.Drawing.SystemColors.Control;
            this.label175.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label175.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label175.Location = new System.Drawing.Point(316, 19);
            this.label175.Name = "label175";
            this.label175.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label175.Size = new System.Drawing.Size(41, 17);
            this.label175.TabIndex = 522;
            this.label175.Text = "USE";
            this.label175.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label49.Location = new System.Drawing.Point(358, 19);
            this.label49.Name = "label49";
            this.label49.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label49.Size = new System.Drawing.Size(40, 17);
            this.label49.TabIndex = 523;
            this.label49.Text = "HIDE";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formationByte1
            // 
            this.formationByte1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte1.Location = new System.Drawing.Point(39, 38);
            this.formationByte1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte1.Name = "formationByte1";
            this.formationByte1.Size = new System.Drawing.Size(45, 17);
            this.formationByte1.TabIndex = 45;
            this.formationByte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte1.ValueChanged += new System.EventHandler(this.formationByte1_ValueChanged);
            // 
            // formationByte2
            // 
            this.formationByte2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte2.Location = new System.Drawing.Point(39, 56);
            this.formationByte2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte2.Name = "formationByte2";
            this.formationByte2.Size = new System.Drawing.Size(45, 17);
            this.formationByte2.TabIndex = 49;
            this.formationByte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte2.ValueChanged += new System.EventHandler(this.formationByte2_ValueChanged);
            // 
            // formationByte3
            // 
            this.formationByte3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte3.Location = new System.Drawing.Point(39, 74);
            this.formationByte3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte3.Name = "formationByte3";
            this.formationByte3.Size = new System.Drawing.Size(45, 17);
            this.formationByte3.TabIndex = 53;
            this.formationByte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte3.ValueChanged += new System.EventHandler(this.formationByte3_ValueChanged);
            // 
            // formationByte8
            // 
            this.formationByte8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte8.Location = new System.Drawing.Point(39, 164);
            this.formationByte8.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte8.Name = "formationByte8";
            this.formationByte8.Size = new System.Drawing.Size(45, 17);
            this.formationByte8.TabIndex = 73;
            this.formationByte8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte8.ValueChanged += new System.EventHandler(this.formationByte8_ValueChanged);
            // 
            // formationByte5
            // 
            this.formationByte5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte5.Location = new System.Drawing.Point(39, 110);
            this.formationByte5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte5.Name = "formationByte5";
            this.formationByte5.Size = new System.Drawing.Size(45, 17);
            this.formationByte5.TabIndex = 61;
            this.formationByte5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte5.ValueChanged += new System.EventHandler(this.formationByte5_ValueChanged);
            // 
            // formationByte7
            // 
            this.formationByte7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte7.Location = new System.Drawing.Point(39, 146);
            this.formationByte7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte7.Name = "formationByte7";
            this.formationByte7.Size = new System.Drawing.Size(45, 17);
            this.formationByte7.TabIndex = 69;
            this.formationByte7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte7.ValueChanged += new System.EventHandler(this.formationByte7_ValueChanged);
            // 
            // formationByte6
            // 
            this.formationByte6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte6.Location = new System.Drawing.Point(39, 128);
            this.formationByte6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte6.Name = "formationByte6";
            this.formationByte6.Size = new System.Drawing.Size(45, 17);
            this.formationByte6.TabIndex = 65;
            this.formationByte6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte6.ValueChanged += new System.EventHandler(this.formationByte6_ValueChanged);
            // 
            // formationByte4
            // 
            this.formationByte4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationByte4.Location = new System.Drawing.Point(39, 92);
            this.formationByte4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationByte4.Name = "formationByte4";
            this.formationByte4.Size = new System.Drawing.Size(45, 17);
            this.formationByte4.TabIndex = 57;
            this.formationByte4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationByte4.ValueChanged += new System.EventHandler(this.formationByte4_ValueChanged);
            // 
            // panelFormationUse
            // 
            this.panelFormationUse.BackColor = System.Drawing.SystemColors.Window;
            this.panelFormationUse.Controls.Add(this.checkedListBox1);
            this.panelFormationUse.Location = new System.Drawing.Point(316, 38);
            this.panelFormationUse.Name = "panelFormationUse";
            this.panelFormationUse.Size = new System.Drawing.Size(41, 143);
            this.panelFormationUse.TabIndex = 517;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.checkedListBox1.Location = new System.Drawing.Point(11, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(17, 136);
            this.checkedListBox1.TabIndex = 77;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // panelFormationHide
            // 
            this.panelFormationHide.BackColor = System.Drawing.SystemColors.Window;
            this.panelFormationHide.Controls.Add(this.checkedListBox2);
            this.panelFormationHide.Location = new System.Drawing.Point(358, 38);
            this.panelFormationHide.Name = "panelFormationHide";
            this.panelFormationHide.Size = new System.Drawing.Size(40, 143);
            this.panelFormationHide.TabIndex = 516;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox2.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.checkedListBox2.Location = new System.Drawing.Point(12, 3);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(17, 136);
            this.checkedListBox2.TabIndex = 78;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // formationCoordY1
            // 
            this.formationCoordY1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY1.Location = new System.Drawing.Point(270, 38);
            this.formationCoordY1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY1.Name = "formationCoordY1";
            this.formationCoordY1.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY1.TabIndex = 48;
            this.formationCoordY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY1.ValueChanged += new System.EventHandler(this.formationCoordY1_ValueChanged);
            // 
            // formationCoordY2
            // 
            this.formationCoordY2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY2.Location = new System.Drawing.Point(270, 56);
            this.formationCoordY2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY2.Name = "formationCoordY2";
            this.formationCoordY2.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY2.TabIndex = 52;
            this.formationCoordY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY2.ValueChanged += new System.EventHandler(this.formationCoordY2_ValueChanged);
            // 
            // formationCoordY3
            // 
            this.formationCoordY3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY3.Location = new System.Drawing.Point(270, 74);
            this.formationCoordY3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY3.Name = "formationCoordY3";
            this.formationCoordY3.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY3.TabIndex = 56;
            this.formationCoordY3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY3.ValueChanged += new System.EventHandler(this.formationCoordY3_ValueChanged);
            // 
            // formationCoordY8
            // 
            this.formationCoordY8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY8.Location = new System.Drawing.Point(270, 164);
            this.formationCoordY8.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY8.Name = "formationCoordY8";
            this.formationCoordY8.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY8.TabIndex = 76;
            this.formationCoordY8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY8.ValueChanged += new System.EventHandler(this.formationCoordY8_ValueChanged);
            // 
            // formationCoordY5
            // 
            this.formationCoordY5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY5.Location = new System.Drawing.Point(270, 110);
            this.formationCoordY5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY5.Name = "formationCoordY5";
            this.formationCoordY5.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY5.TabIndex = 64;
            this.formationCoordY5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY5.ValueChanged += new System.EventHandler(this.formationCoordY5_ValueChanged);
            // 
            // formationCoordY7
            // 
            this.formationCoordY7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY7.Location = new System.Drawing.Point(270, 146);
            this.formationCoordY7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY7.Name = "formationCoordY7";
            this.formationCoordY7.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY7.TabIndex = 72;
            this.formationCoordY7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY7.ValueChanged += new System.EventHandler(this.formationCoordY7_ValueChanged);
            // 
            // formationCoordY6
            // 
            this.formationCoordY6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY6.Location = new System.Drawing.Point(270, 128);
            this.formationCoordY6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY6.Name = "formationCoordY6";
            this.formationCoordY6.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY6.TabIndex = 68;
            this.formationCoordY6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY6.ValueChanged += new System.EventHandler(this.formationCoordY6_ValueChanged);
            // 
            // formationCoordY4
            // 
            this.formationCoordY4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordY4.Location = new System.Drawing.Point(270, 92);
            this.formationCoordY4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordY4.Name = "formationCoordY4";
            this.formationCoordY4.Size = new System.Drawing.Size(45, 17);
            this.formationCoordY4.TabIndex = 60;
            this.formationCoordY4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordY4.ValueChanged += new System.EventHandler(this.formationCoordY4_ValueChanged);
            // 
            // formationCoordX1
            // 
            this.formationCoordX1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX1.Location = new System.Drawing.Point(224, 38);
            this.formationCoordX1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX1.Name = "formationCoordX1";
            this.formationCoordX1.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX1.TabIndex = 47;
            this.formationCoordX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX1.ValueChanged += new System.EventHandler(this.formationCoordX1_ValueChanged);
            // 
            // formationCoordX2
            // 
            this.formationCoordX2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX2.Location = new System.Drawing.Point(224, 56);
            this.formationCoordX2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX2.Name = "formationCoordX2";
            this.formationCoordX2.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX2.TabIndex = 51;
            this.formationCoordX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX2.ValueChanged += new System.EventHandler(this.formationCoordX2_ValueChanged);
            // 
            // formationCoordX3
            // 
            this.formationCoordX3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX3.Location = new System.Drawing.Point(224, 74);
            this.formationCoordX3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX3.Name = "formationCoordX3";
            this.formationCoordX3.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX3.TabIndex = 55;
            this.formationCoordX3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX3.ValueChanged += new System.EventHandler(this.formationCoordX3_ValueChanged);
            // 
            // formationCoordX8
            // 
            this.formationCoordX8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX8.Location = new System.Drawing.Point(224, 164);
            this.formationCoordX8.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX8.Name = "formationCoordX8";
            this.formationCoordX8.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX8.TabIndex = 75;
            this.formationCoordX8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX8.ValueChanged += new System.EventHandler(this.formationCoordX8_ValueChanged);
            // 
            // formationCoordX5
            // 
            this.formationCoordX5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX5.Location = new System.Drawing.Point(224, 110);
            this.formationCoordX5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX5.Name = "formationCoordX5";
            this.formationCoordX5.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX5.TabIndex = 63;
            this.formationCoordX5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX5.ValueChanged += new System.EventHandler(this.formationCoordX5_ValueChanged);
            // 
            // formationCoordX7
            // 
            this.formationCoordX7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX7.Location = new System.Drawing.Point(224, 146);
            this.formationCoordX7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX7.Name = "formationCoordX7";
            this.formationCoordX7.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX7.TabIndex = 71;
            this.formationCoordX7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX7.ValueChanged += new System.EventHandler(this.formationCoordX7_ValueChanged);
            // 
            // formationCoordX6
            // 
            this.formationCoordX6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX6.Location = new System.Drawing.Point(224, 128);
            this.formationCoordX6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX6.Name = "formationCoordX6";
            this.formationCoordX6.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX6.TabIndex = 67;
            this.formationCoordX6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX6.ValueChanged += new System.EventHandler(this.formationCoordX6_ValueChanged);
            // 
            // formationCoordX4
            // 
            this.formationCoordX4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationCoordX4.Location = new System.Drawing.Point(224, 92);
            this.formationCoordX4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationCoordX4.Name = "formationCoordX4";
            this.formationCoordX4.Size = new System.Drawing.Size(45, 17);
            this.formationCoordX4.TabIndex = 59;
            this.formationCoordX4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationCoordX4.ValueChanged += new System.EventHandler(this.formationCoordX4_ValueChanged);
            // 
            // pictureBoxFormation
            // 
            this.pictureBoxFormation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxFormation.Location = new System.Drawing.Point(0, -38);
            this.pictureBoxFormation.Name = "pictureBoxFormation";
            this.pictureBoxFormation.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxFormation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFormation.TabIndex = 286;
            this.pictureBoxFormation.TabStop = false;
            this.pictureBoxFormation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFormation_MouseMove);
            this.pictureBoxFormation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFormation_MouseDown);
            this.pictureBoxFormation.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFormation_Paint);
            this.pictureBoxFormation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFormation_MouseUp);
            // 
            // panel52
            // 
            this.panel52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel52.Controls.Add(this.formationCantRun);
            this.panel52.Controls.Add(this.label140);
            this.panel52.Controls.Add(this.panel74);
            this.panel52.Controls.Add(this.panel82);
            this.panel52.Controls.Add(this.label6);
            this.panel52.Controls.Add(this.formationBattleEvent);
            this.panel52.Controls.Add(this.formationUnknown);
            this.panel52.Controls.Add(this.label176);
            this.panel52.Controls.Add(this.label150);
            this.panel52.Controls.Add(this.label16);
            this.panel52.Controls.Add(this.label199);
            this.panel52.Location = new System.Drawing.Point(2, 2);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(398, 74);
            this.panel52.TabIndex = 79;
            // 
            // formationCantRun
            // 
            this.formationCantRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.formationCantRun.BackColor = System.Drawing.SystemColors.Control;
            this.formationCantRun.FlatAppearance.BorderSize = 0;
            this.formationCantRun.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.formationCantRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formationCantRun.Location = new System.Drawing.Point(316, 19);
            this.formationCantRun.Name = "formationCantRun";
            this.formationCantRun.Size = new System.Drawing.Size(82, 17);
            this.formationCantRun.TabIndex = 502;
            this.formationCantRun.Text = "CAN\'T RUN";
            this.formationCantRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.formationCantRun.UseCompatibleTextRendering = true;
            this.formationCantRun.UseVisualStyleBackColor = true;
            this.formationCantRun.CheckedChanged += new System.EventHandler(this.formationCantRun_CheckedChanged);
            // 
            // panel82
            // 
            this.panel82.BackColor = System.Drawing.SystemColors.Control;
            this.panel82.Controls.Add(this.formationMusic);
            this.panel82.Location = new System.Drawing.Point(77, 57);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(78, 17);
            this.panel82.TabIndex = 80;
            // 
            // formationMusic
            // 
            this.formationMusic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.formationMusic.BackColor = System.Drawing.SystemColors.Window;
            this.formationMusic.DropDownHeight = 150;
            this.formationMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formationMusic.DropDownWidth = 100;
            this.formationMusic.IntegralHeight = false;
            this.formationMusic.Items.AddRange(new object[] {
            "Normal",
            "Boss 1",
            "Boss 2",
            "Smithy 1",
            "Moleville Mountain",
            "Booster Hill",
            "Barrel Volcano",
            "Culex",
            "{CURRENT}"});
            this.formationMusic.Location = new System.Drawing.Point(-2, -2);
            this.formationMusic.Name = "formationMusic";
            this.formationMusic.Size = new System.Drawing.Size(82, 21);
            this.formationMusic.TabIndex = 80;
            this.formationMusic.SelectedIndexChanged += new System.EventHandler(this.formationMusic_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(156, 19);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 501;
            this.label6.Text = "??????";
            // 
            // formationUnknown
            // 
            this.formationUnknown.BackColor = System.Drawing.SystemColors.Window;
            this.formationUnknown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationUnknown.Location = new System.Drawing.Point(233, 19);
            this.formationUnknown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationUnknown.Name = "formationUnknown";
            this.formationUnknown.Size = new System.Drawing.Size(82, 17);
            this.formationUnknown.TabIndex = 81;
            this.formationUnknown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationUnknown.ValueChanged += new System.EventHandler(this.formationUnknown_ValueChanged);
            // 
            // label176
            // 
            this.label176.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label176.Location = new System.Drawing.Point(0, 19);
            this.label176.Name = "label176";
            this.label176.Padding = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.label176.Size = new System.Drawing.Size(76, 17);
            this.label176.TabIndex = 499;
            this.label176.Text = "Initial Event";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(0, 57);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.label16.Size = new System.Drawing.Size(76, 17);
            this.label16.TabIndex = 500;
            this.label16.Text = "INDEX";
            // 
            // label199
            // 
            this.label199.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label199.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.ForeColor = System.Drawing.SystemColors.Control;
            this.label199.Location = new System.Drawing.Point(0, 0);
            this.label199.Name = "label199";
            this.label199.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label199.Size = new System.Drawing.Size(400, 17);
            this.label199.TabIndex = 544;
            this.label199.Text = "FORMATION PROPERTIES";
            this.label199.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel45.Controls.Add(this.pictureBoxSpellDesc);
            this.panel45.Controls.Add(this.label55);
            this.panel45.Controls.Add(this.button33);
            this.panel45.Controls.Add(this.panelSpellDescription);
            this.panel45.Controls.Add(this.button34);
            this.panel45.Location = new System.Drawing.Point(2, 2);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(120, 236);
            this.panel45.TabIndex = 111;
            // 
            // pictureBoxSpellDesc
            // 
            this.pictureBoxSpellDesc.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxSpellDesc.Location = new System.Drawing.Point(0, 19);
            this.pictureBoxSpellDesc.Name = "pictureBoxSpellDesc";
            this.pictureBoxSpellDesc.Size = new System.Drawing.Size(120, 64);
            this.pictureBoxSpellDesc.TabIndex = 0;
            this.pictureBoxSpellDesc.TabStop = false;
            this.pictureBoxSpellDesc.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSpellDesc_Paint);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.SystemColors.Window;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Location = new System.Drawing.Point(64, 218);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(57, 19);
            this.button33.TabIndex = 113;
            this.button33.Text = "END";
            this.button33.UseCompatibleTextRendering = true;
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // panelSpellDescription
            // 
            this.panelSpellDescription.BackColor = System.Drawing.SystemColors.Window;
            this.panelSpellDescription.Controls.Add(this.textBoxSpellDescription);
            this.panelSpellDescription.Location = new System.Drawing.Point(0, 84);
            this.panelSpellDescription.Name = "panelSpellDescription";
            this.panelSpellDescription.Size = new System.Drawing.Size(120, 134);
            this.panelSpellDescription.TabIndex = 111;
            // 
            // textBoxSpellDescription
            // 
            this.textBoxSpellDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSpellDescription.Location = new System.Drawing.Point(4, 4);
            this.textBoxSpellDescription.MaxLength = 255;
            this.textBoxSpellDescription.Name = "textBoxSpellDescription";
            this.textBoxSpellDescription.Size = new System.Drawing.Size(112, 126);
            this.textBoxSpellDescription.TabIndex = 170;
            this.textBoxSpellDescription.Text = "";
            this.textBoxSpellDescription.TextChanged += new System.EventHandler(this.textBoxSpellDescription_TextChanged);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.SystemColors.Window;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Location = new System.Drawing.Point(-1, 218);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(66, 19);
            this.button34.TabIndex = 112;
            this.button34.Text = "NEW LINE";
            this.button34.UseCompatibleTextRendering = true;
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // panel92
            // 
            this.panel92.BackColor = System.Drawing.SystemColors.Window;
            this.panel92.Controls.Add(this.textBoxAttackName);
            this.panel92.Location = new System.Drawing.Point(102, 40);
            this.panel92.Name = "panel92";
            this.panel92.Size = new System.Drawing.Size(95, 17);
            this.panel92.TabIndex = 122;
            // 
            // textBoxAttackName
            // 
            this.textBoxAttackName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAttackName.Location = new System.Drawing.Point(4, 2);
            this.textBoxAttackName.MaxLength = 13;
            this.textBoxAttackName.Name = "textBoxAttackName";
            this.textBoxAttackName.Size = new System.Drawing.Size(87, 14);
            this.textBoxAttackName.TabIndex = 176;
            this.textBoxAttackName.TextChanged += new System.EventHandler(this.textBoxAttackName_TextChanged);
            // 
            // panel86
            // 
            this.panel86.Controls.Add(this.attackName);
            this.panel86.Location = new System.Drawing.Point(2, 21);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(196, 17);
            this.panel86.TabIndex = 120;
            // 
            // attackName
            // 
            this.attackName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attackName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.attackName.DropDownHeight = 522;
            this.attackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attackName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackName.ForeColor = System.Drawing.SystemColors.Control;
            this.attackName.IntegralHeight = false;
            this.attackName.Location = new System.Drawing.Point(-2, -2);
            this.attackName.Name = "attackName";
            this.attackName.Size = new System.Drawing.Size(200, 22);
            this.attackName.TabIndex = 453;
            this.attackName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.attackName_DrawItem);
            this.attackName.SelectedIndexChanged += new System.EventHandler(this.attackName_SelectedIndexChanged);
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel85.Controls.Add(this.label11);
            this.panel85.Controls.Add(this.attackAtkLevel);
            this.panel85.Controls.Add(this.attackHitRate);
            this.panel85.Controls.Add(this.label57);
            this.panel85.Controls.Add(this.label58);
            this.panel85.Location = new System.Drawing.Point(2, 2);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(195, 54);
            this.panel85.TabIndex = 123;
            // 
            // panel87
            // 
            this.panel87.BackColor = System.Drawing.SystemColors.Window;
            this.panel87.Controls.Add(this.textBoxSpellName);
            this.panel87.Location = new System.Drawing.Point(104, 40);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(95, 17);
            this.panel87.TabIndex = 102;
            // 
            // textBoxSpellName
            // 
            this.textBoxSpellName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSpellName.Location = new System.Drawing.Point(4, 2);
            this.textBoxSpellName.MaxLength = 15;
            this.textBoxSpellName.Name = "textBoxSpellName";
            this.textBoxSpellName.Size = new System.Drawing.Size(87, 14);
            this.textBoxSpellName.TabIndex = 121;
            this.textBoxSpellName.TextChanged += new System.EventHandler(this.textBoxSpellName_TextChanged);
            this.textBoxSpellName.Leave += new System.EventHandler(this.textBoxSpellName_Leave);
            // 
            // panel88
            // 
            this.panel88.Controls.Add(this.spellName);
            this.panel88.Location = new System.Drawing.Point(2, 21);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(198, 17);
            this.panel88.TabIndex = 0;
            // 
            // spellName
            // 
            this.spellName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spellName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.spellName.DropDownHeight = 522;
            this.spellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spellName.ForeColor = System.Drawing.SystemColors.Control;
            this.spellName.IntegralHeight = false;
            this.spellName.Location = new System.Drawing.Point(-2, -2);
            this.spellName.Name = "spellName";
            this.spellName.Size = new System.Drawing.Size(202, 22);
            this.spellName.TabIndex = 452;
            this.spellName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.spellName_DrawItem);
            this.spellName.SelectedIndexChanged += new System.EventHandler(this.spellName_SelectedIndexChanged);
            // 
            // attackAtkType
            // 
            this.attackAtkType.BackColor = System.Drawing.SystemColors.Window;
            this.attackAtkType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackAtkType.CheckOnClick = true;
            this.attackAtkType.Items.AddRange(new object[] {
            "9999 Damage",
            "No damage",
            "Hide Battle Numerals",
            "No damage"});
            this.attackAtkType.Location = new System.Drawing.Point(0, 19);
            this.attackAtkType.Name = "attackAtkType";
            this.attackAtkType.Size = new System.Drawing.Size(195, 64);
            this.attackAtkType.TabIndex = 127;
            this.attackAtkType.SelectedIndexChanged += new System.EventHandler(this.attackAtkType_SelectedIndexChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label54.Size = new System.Drawing.Size(195, 17);
            this.label54.TabIndex = 487;
            this.label54.Text = "ATTACK TYPE";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel38.Controls.Add(this.label10);
            this.panel38.Controls.Add(this.label65);
            this.panel38.Controls.Add(this.label64);
            this.panel38.Controls.Add(this.spellHitRate);
            this.panel38.Controls.Add(this.label56);
            this.panel38.Controls.Add(this.spellFPCost);
            this.panel38.Controls.Add(this.spellMagPower);
            this.panel38.Location = new System.Drawing.Point(2, 2);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(197, 72);
            this.panel38.TabIndex = 103;
            // 
            // spellHitRate
            // 
            this.spellHitRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellHitRate.Location = new System.Drawing.Point(102, 55);
            this.spellHitRate.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spellHitRate.Name = "spellHitRate";
            this.spellHitRate.Size = new System.Drawing.Size(96, 17);
            this.spellHitRate.TabIndex = 105;
            this.spellHitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spellHitRate.ValueChanged += new System.EventHandler(this.spellHitRate_ValueChanged);
            // 
            // spellFPCost
            // 
            this.spellFPCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellFPCost.Location = new System.Drawing.Point(102, 19);
            this.spellFPCost.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.spellFPCost.Name = "spellFPCost";
            this.spellFPCost.Size = new System.Drawing.Size(96, 17);
            this.spellFPCost.TabIndex = 103;
            this.spellFPCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spellFPCost.ValueChanged += new System.EventHandler(this.spellFPCost_ValueChanged);
            // 
            // spellMagPower
            // 
            this.spellMagPower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellMagPower.Location = new System.Drawing.Point(102, 37);
            this.spellMagPower.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spellMagPower.Name = "spellMagPower";
            this.spellMagPower.Size = new System.Drawing.Size(96, 17);
            this.spellMagPower.TabIndex = 104;
            this.spellMagPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spellMagPower.ValueChanged += new System.EventHandler(this.spellMagPower_ValueChanged);
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label44.Location = new System.Drawing.Point(0, 0);
            this.label44.Name = "label44";
            this.label44.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label44.Size = new System.Drawing.Size(197, 17);
            this.label44.TabIndex = 484;
            this.label44.Text = "OTHER PROPERTIES...";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spellStatusEffect
            // 
            this.spellStatusEffect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellStatusEffect.CheckOnClick = true;
            this.spellStatusEffect.ColumnWidth = 96;
            this.spellStatusEffect.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincible"});
            this.spellStatusEffect.Location = new System.Drawing.Point(0, 19);
            this.spellStatusEffect.MultiColumn = true;
            this.spellStatusEffect.Name = "spellStatusEffect";
            this.spellStatusEffect.Size = new System.Drawing.Size(197, 64);
            this.spellStatusEffect.TabIndex = 114;
            this.spellStatusEffect.SelectedIndexChanged += new System.EventHandler(this.spellStatusEffect_SelectedIndexChanged);
            // 
            // spellStatusChange
            // 
            this.spellStatusChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellStatusChange.CheckOnClick = true;
            this.spellStatusChange.ColumnWidth = 91;
            this.spellStatusChange.Items.AddRange(new object[] {
            "Attack",
            "Defense",
            "Magic Attack",
            "Magic Defense"});
            this.spellStatusChange.Location = new System.Drawing.Point(0, 19);
            this.spellStatusChange.Name = "spellStatusChange";
            this.spellStatusChange.Size = new System.Drawing.Size(120, 64);
            this.spellStatusChange.TabIndex = 115;
            this.spellStatusChange.SelectedIndexChanged += new System.EventHandler(this.spellStatusChange_SelectedIndexChanged);
            // 
            // spellTargetting
            // 
            this.spellTargetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellTargetting.CheckOnClick = true;
            this.spellTargetting.ColumnWidth = 96;
            this.spellTargetting.Items.AddRange(new object[] {
            "Other Targets",
            "Enemy Party",
            "Entire Party",
            "Wounded Only",
            "One Party Only",
            "Not Self"});
            this.spellTargetting.Location = new System.Drawing.Point(0, 19);
            this.spellTargetting.Name = "spellTargetting";
            this.spellTargetting.Size = new System.Drawing.Size(120, 96);
            this.spellTargetting.TabIndex = 117;
            this.spellTargetting.SelectedIndexChanged += new System.EventHandler(this.spellTargetting_SelectedIndexChanged);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel8.Controls.Add(this.panel218);
            this.panel8.Controls.Add(this.panel171);
            this.panel8.Controls.Add(this.panel170);
            this.panel8.Controls.Add(this.panel169);
            this.panel8.Controls.Add(this.panel168);
            this.panel8.Controls.Add(this.panel167);
            this.panel8.Controls.Add(this.panel163);
            this.panel8.Controls.Add(this.panel162);
            this.panel8.Controls.Add(this.panel161);
            this.panel8.Controls.Add(this.panel160);
            this.panel8.Controls.Add(this.panel159);
            this.panel8.Controls.Add(this.panel158);
            this.panel8.Controls.Add(this.panel157);
            this.panel8.Controls.Add(this.panel152);
            this.panel8.Controls.Add(this.panel40);
            this.panel8.Controls.Add(this.panel151);
            this.panel8.Location = new System.Drawing.Point(2, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(681, 580);
            this.panel8.TabIndex = 483;
            // 
            // panel218
            // 
            this.panel218.Controls.Add(this.panel219);
            this.panel218.Location = new System.Drawing.Point(548, 6);
            this.panel218.Name = "panel218";
            this.panel218.Size = new System.Drawing.Size(126, 450);
            this.panel218.TabIndex = 542;
            // 
            // panel219
            // 
            this.panel219.BackColor = System.Drawing.SystemColors.Control;
            this.panel219.Location = new System.Drawing.Point(2, 2);
            this.panel219.Name = "panel219";
            this.panel219.Size = new System.Drawing.Size(122, 446);
            this.panel219.TabIndex = 540;
            // 
            // panel171
            // 
            this.panel171.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel171.Controls.Add(this.label18);
            this.panel171.Controls.Add(this.panelSpellNotes);
            this.panel171.Location = new System.Drawing.Point(343, 462);
            this.panel171.Name = "panel171";
            this.panel171.Size = new System.Drawing.Size(331, 112);
            this.panel171.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label18.Size = new System.Drawing.Size(327, 17);
            this.label18.TabIndex = 449;
            this.label18.Text = "ATTACK NOTES...";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSpellNotes
            // 
            this.panelSpellNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSpellNotes.BackColor = System.Drawing.SystemColors.Window;
            this.panelSpellNotes.Controls.Add(this.textBoxAttackNotes);
            this.panelSpellNotes.Location = new System.Drawing.Point(2, 21);
            this.panelSpellNotes.Name = "panelSpellNotes";
            this.panelSpellNotes.Size = new System.Drawing.Size(327, 89);
            this.panelSpellNotes.TabIndex = 129;
            // 
            // textBoxAttackNotes
            // 
            this.textBoxAttackNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttackNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAttackNotes.Location = new System.Drawing.Point(4, 4);
            this.textBoxAttackNotes.Name = "textBoxAttackNotes";
            this.textBoxAttackNotes.Size = new System.Drawing.Size(319, 81);
            this.textBoxAttackNotes.TabIndex = 179;
            this.textBoxAttackNotes.Text = "";
            // 
            // panel170
            // 
            this.panel170.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel170.Controls.Add(this.label68);
            this.panel170.Controls.Add(this.panel30);
            this.panel170.Location = new System.Drawing.Point(6, 470);
            this.panel170.Name = "panel170";
            this.panel170.Size = new System.Drawing.Size(331, 104);
            this.panel170.TabIndex = 8;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.Control;
            this.label68.Location = new System.Drawing.Point(2, 2);
            this.label68.Name = "label68";
            this.label68.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label68.Size = new System.Drawing.Size(327, 17);
            this.label68.TabIndex = 449;
            this.label68.Text = "SPELL NOTES...";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel30.BackColor = System.Drawing.SystemColors.Window;
            this.panel30.Controls.Add(this.richTextBox9);
            this.panel30.Location = new System.Drawing.Point(2, 21);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(327, 81);
            this.panel30.TabIndex = 119;
            // 
            // richTextBox9
            // 
            this.richTextBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox9.Location = new System.Drawing.Point(4, 4);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.Size = new System.Drawing.Size(319, 73);
            this.richTextBox9.TabIndex = 179;
            this.richTextBox9.Text = "";
            // 
            // panel169
            // 
            this.panel169.Controls.Add(this.panel166);
            this.panel169.Location = new System.Drawing.Point(343, 369);
            this.panel169.Name = "panel169";
            this.panel169.Size = new System.Drawing.Size(199, 87);
            this.panel169.TabIndex = 13;
            // 
            // panel166
            // 
            this.panel166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel166.Controls.Add(this.label54);
            this.panel166.Controls.Add(this.attackAtkType);
            this.panel166.Location = new System.Drawing.Point(2, 2);
            this.panel166.Name = "panel166";
            this.panel166.Size = new System.Drawing.Size(195, 83);
            this.panel166.TabIndex = 514;
            // 
            // panel168
            // 
            this.panel168.Controls.Add(this.panel165);
            this.panel168.Location = new System.Drawing.Point(343, 276);
            this.panel168.Name = "panel168";
            this.panel168.Size = new System.Drawing.Size(199, 87);
            this.panel168.TabIndex = 12;
            // 
            // panel165
            // 
            this.panel165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel165.Controls.Add(this.label53);
            this.panel165.Controls.Add(this.attackStatusUp);
            this.panel165.Location = new System.Drawing.Point(2, 2);
            this.panel165.Name = "panel165";
            this.panel165.Size = new System.Drawing.Size(195, 83);
            this.panel165.TabIndex = 513;
            // 
            // panel167
            // 
            this.panel167.Controls.Add(this.panel164);
            this.panel167.Location = new System.Drawing.Point(343, 135);
            this.panel167.Name = "panel167";
            this.panel167.Size = new System.Drawing.Size(199, 135);
            this.panel167.TabIndex = 11;
            // 
            // panel164
            // 
            this.panel164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel164.Controls.Add(this.label52);
            this.panel164.Controls.Add(this.attackStatusEffect);
            this.panel164.Location = new System.Drawing.Point(2, 2);
            this.panel164.Name = "panel164";
            this.panel164.Size = new System.Drawing.Size(195, 131);
            this.panel164.TabIndex = 512;
            // 
            // panel163
            // 
            this.panel163.Controls.Add(this.panel86);
            this.panel163.Controls.Add(this.label59);
            this.panel163.Controls.Add(this.attackNum);
            this.panel163.Controls.Add(this.label60);
            this.panel163.Controls.Add(this.panel92);
            this.panel163.Location = new System.Drawing.Point(343, 6);
            this.panel163.Name = "panel163";
            this.panel163.Size = new System.Drawing.Size(199, 59);
            this.panel163.TabIndex = 9;
            // 
            // panel162
            // 
            this.panel162.Controls.Add(this.panel85);
            this.panel162.Location = new System.Drawing.Point(343, 71);
            this.panel162.Name = "panel162";
            this.panel162.Size = new System.Drawing.Size(199, 58);
            this.panel162.TabIndex = 10;
            // 
            // panel161
            // 
            this.panel161.Controls.Add(this.panel88);
            this.panel161.Controls.Add(this.label66);
            this.panel161.Controls.Add(this.spellNum);
            this.panel161.Controls.Add(this.label168);
            this.panel161.Controls.Add(this.panel87);
            this.panel161.Location = new System.Drawing.Point(6, 6);
            this.panel161.Name = "panel161";
            this.panel161.Size = new System.Drawing.Size(201, 59);
            this.panel161.TabIndex = 0;
            // 
            // spellNum
            // 
            this.spellNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spellNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spellNum.ForeColor = System.Drawing.SystemColors.Control;
            this.spellNum.Location = new System.Drawing.Point(104, 2);
            this.spellNum.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.spellNum.Name = "spellNum";
            this.spellNum.Size = new System.Drawing.Size(96, 17);
            this.spellNum.TabIndex = 101;
            this.spellNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spellNum.ValueChanged += new System.EventHandler(this.spellNum_ValueChanged);
            // 
            // panel160
            // 
            this.panel160.Controls.Add(this.panel156);
            this.panel160.Location = new System.Drawing.Point(213, 252);
            this.panel160.Name = "panel160";
            this.panel160.Size = new System.Drawing.Size(124, 119);
            this.panel160.TabIndex = 5;
            // 
            // panel156
            // 
            this.panel156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel156.Controls.Add(this.label170);
            this.panel156.Controls.Add(this.spellTargetting);
            this.panel156.Location = new System.Drawing.Point(2, 2);
            this.panel156.Name = "panel156";
            this.panel156.Size = new System.Drawing.Size(120, 115);
            this.panel156.TabIndex = 504;
            // 
            // panel159
            // 
            this.panel159.Controls.Add(this.panel155);
            this.panel159.Location = new System.Drawing.Point(6, 252);
            this.panel159.Name = "panel159";
            this.panel159.Size = new System.Drawing.Size(201, 119);
            this.panel159.TabIndex = 4;
            // 
            // panel155
            // 
            this.panel155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel155.Controls.Add(this.label44);
            this.panel155.Controls.Add(this.spellAttackProp);
            this.panel155.Location = new System.Drawing.Point(2, 2);
            this.panel155.Name = "panel155";
            this.panel155.Size = new System.Drawing.Size(197, 115);
            this.panel155.TabIndex = 503;
            // 
            // spellAttackProp
            // 
            this.spellAttackProp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellAttackProp.CheckOnClick = true;
            this.spellAttackProp.Items.AddRange(new object[] {
            "Check Caster/Target Atk/Def",
            "Ignore Target\'s Defense",
            "Check Mortality Protection",
            "Usable in overworld menu",
            "9999 Damage/Heal",
            "Hide Battle Numerals"});
            this.spellAttackProp.Location = new System.Drawing.Point(0, 19);
            this.spellAttackProp.Name = "spellAttackProp";
            this.spellAttackProp.Size = new System.Drawing.Size(197, 96);
            this.spellAttackProp.TabIndex = 116;
            this.spellAttackProp.SelectedIndexChanged += new System.EventHandler(this.spellAttackProp_SelectedIndexChanged);
            // 
            // panel158
            // 
            this.panel158.Controls.Add(this.panel154);
            this.panel158.Location = new System.Drawing.Point(213, 377);
            this.panel158.Name = "panel158";
            this.panel158.Size = new System.Drawing.Size(124, 87);
            this.panel158.TabIndex = 7;
            // 
            // panel154
            // 
            this.panel154.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel154.Controls.Add(this.label61);
            this.panel154.Controls.Add(this.spellStatusChange);
            this.panel154.Location = new System.Drawing.Point(2, 2);
            this.panel154.Name = "panel154";
            this.panel154.Size = new System.Drawing.Size(120, 83);
            this.panel154.TabIndex = 502;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.Control;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label61.Size = new System.Drawing.Size(120, 17);
            this.label61.TabIndex = 362;
            this.label61.Text = "STATUS";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel157
            // 
            this.panel157.Controls.Add(this.panel153);
            this.panel157.Location = new System.Drawing.Point(6, 377);
            this.panel157.Name = "panel157";
            this.panel157.Size = new System.Drawing.Size(201, 87);
            this.panel157.TabIndex = 6;
            // 
            // panel153
            // 
            this.panel153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel153.Controls.Add(this.label62);
            this.panel153.Controls.Add(this.spellStatusEffect);
            this.panel153.Location = new System.Drawing.Point(2, 2);
            this.panel153.Name = "panel153";
            this.panel153.Size = new System.Drawing.Size(197, 83);
            this.panel153.TabIndex = 501;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.SystemColors.Control;
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label62.Location = new System.Drawing.Point(0, 0);
            this.label62.Name = "label62";
            this.label62.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label62.Size = new System.Drawing.Size(197, 17);
            this.label62.TabIndex = 358;
            this.label62.Text = "EFFECT";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel152
            // 
            this.panel152.Controls.Add(this.panel45);
            this.panel152.Location = new System.Drawing.Point(213, 6);
            this.panel152.Name = "panel152";
            this.panel152.Size = new System.Drawing.Size(124, 240);
            this.panel152.TabIndex = 3;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.panel57);
            this.panel40.Location = new System.Drawing.Point(6, 153);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(201, 93);
            this.panel40.TabIndex = 2;
            // 
            // panel57
            // 
            this.panel57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel57.Controls.Add(this.panel89);
            this.panel57.Controls.Add(this.panel90);
            this.panel57.Controls.Add(this.panel91);
            this.panel57.Controls.Add(this.label172);
            this.panel57.Controls.Add(this.label171);
            this.panel57.Controls.Add(this.label12);
            this.panel57.Controls.Add(this.label13);
            this.panel57.Controls.Add(this.label17);
            this.panel57.Controls.Add(this.panel84);
            this.panel57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel57.Location = new System.Drawing.Point(2, 2);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(197, 89);
            this.panel57.TabIndex = 106;
            // 
            // panel89
            // 
            this.panel89.Controls.Add(this.comboBox5);
            this.panel89.Location = new System.Drawing.Point(102, 72);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(96, 17);
            this.panel89.TabIndex = 110;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownHeight = 250;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.IntegralHeight = false;
            this.comboBox5.Items.AddRange(new object[] {
            "Ice",
            "Thunder",
            "Fire",
            "Jump",
            "{NONE}"});
            this.comboBox5.Location = new System.Drawing.Point(-2, -2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(100, 21);
            this.comboBox5.TabIndex = 445;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // panel90
            // 
            this.panel90.Controls.Add(this.spellFunction);
            this.panel90.Location = new System.Drawing.Point(102, 54);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(96, 17);
            this.panel90.TabIndex = 109;
            // 
            // spellFunction
            // 
            this.spellFunction.DropDownHeight = 420;
            this.spellFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellFunction.IntegralHeight = false;
            this.spellFunction.Items.AddRange(new object[] {
            "Scan/Show HP",
            "Always Miss",
            "No Damage",
            "Revive/Heal",
            "Jump Power",
            "{NONE}"});
            this.spellFunction.Location = new System.Drawing.Point(-2, -2);
            this.spellFunction.Name = "spellFunction";
            this.spellFunction.Size = new System.Drawing.Size(100, 21);
            this.spellFunction.TabIndex = 245;
            this.spellFunction.SelectedIndexChanged += new System.EventHandler(this.spellFunction_SelectedIndexChanged);
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.comboBox4);
            this.panel91.Location = new System.Drawing.Point(102, 36);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(96, 17);
            this.panel91.TabIndex = 108;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownHeight = 420;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.IntegralHeight = false;
            this.comboBox4.Items.AddRange(new object[] {
            "Inflict",
            "Nullify",
            "{NONE}"});
            this.comboBox4.Location = new System.Drawing.Point(-2, -2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 21);
            this.comboBox4.TabIndex = 245;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(0, 36);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label12.Size = new System.Drawing.Size(101, 17);
            this.label12.TabIndex = 167;
            this.label12.Text = "Effect Type";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(0, 18);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label13.Size = new System.Drawing.Size(101, 17);
            this.label13.TabIndex = 167;
            this.label13.Text = "Attack Type";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(0, 72);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label17.Size = new System.Drawing.Size(101, 17);
            this.label17.TabIndex = 444;
            this.label17.Text = "Inflict Element";
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.comboBox3);
            this.panel84.Location = new System.Drawing.Point(102, 18);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(96, 17);
            this.panel84.TabIndex = 107;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownHeight = 420;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.IntegralHeight = false;
            this.comboBox3.Items.AddRange(new object[] {
            "Damage",
            "Heal"});
            this.comboBox3.Location = new System.Drawing.Point(-2, -2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 245;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // panel151
            // 
            this.panel151.Controls.Add(this.panel38);
            this.panel151.Location = new System.Drawing.Point(6, 71);
            this.panel151.Name = "panel151";
            this.panel151.Size = new System.Drawing.Size(201, 76);
            this.panel151.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label23.Location = new System.Drawing.Point(2, 58);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label23.Size = new System.Drawing.Size(98, 17);
            this.label23.TabIndex = 508;
            this.label23.Text = "ICON";
            // 
            // panel94
            // 
            this.panel94.Controls.Add(this.itemName);
            this.panel94.Location = new System.Drawing.Point(2, 21);
            this.panel94.Name = "panel94";
            this.panel94.Size = new System.Drawing.Size(197, 17);
            this.panel94.TabIndex = 130;
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.itemName.DropDownHeight = 522;
            this.itemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.ForeColor = System.Drawing.SystemColors.Control;
            this.itemName.IntegralHeight = false;
            this.itemName.Location = new System.Drawing.Point(-2, -2);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(201, 22);
            this.itemName.TabIndex = 454;
            this.itemName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.itemName.SelectedIndexChanged += new System.EventHandler(this.itemName_SelectedIndexChanged);
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.shopName);
            this.panel100.Location = new System.Drawing.Point(2, 21);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(245, 17);
            this.panel100.TabIndex = 159;
            // 
            // shopName
            // 
            this.shopName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopName.DropDownHeight = 500;
            this.shopName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopName.DropDownWidth = 250;
            this.shopName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopName.ForeColor = System.Drawing.SystemColors.Control;
            this.shopName.IntegralHeight = false;
            this.shopName.Location = new System.Drawing.Point(-2, -2);
            this.shopName.Name = "shopName";
            this.shopName.Size = new System.Drawing.Size(249, 22);
            this.shopName.TabIndex = 431;
            this.shopName.Tag = "";
            this.shopName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.shopName_DrawItem);
            this.shopName.SelectedIndexChanged += new System.EventHandler(this.shopName_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.textBoxItemName);
            this.panel1.Location = new System.Drawing.Point(101, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 17);
            this.panel1.TabIndex = 132;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemName.Location = new System.Drawing.Point(4, 2);
            this.textBoxItemName.MaxLength = 15;
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(89, 14);
            this.textBoxItemName.TabIndex = 309;
            this.textBoxItemName.TextChanged += new System.EventHandler(this.textBoxItemName_TextChanged);
            this.textBoxItemName.Leave += new System.EventHandler(this.textBoxItemName_Leave);
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.SystemColors.Control;
            this.panel61.Controls.Add(this.itemNameIcon);
            this.panel61.Location = new System.Drawing.Point(101, 58);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(98, 17);
            this.panel61.TabIndex = 133;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(2, 2);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 455;
            this.label8.Text = "ITEM #";
            // 
            // panel59
            // 
            this.panel59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel59.Controls.Add(this.panel103);
            this.panel59.Controls.Add(this.panel104);
            this.panel59.Controls.Add(this.panel102);
            this.panel59.Controls.Add(this.panel105);
            this.panel59.Controls.Add(this.panel106);
            this.panel59.Controls.Add(this.panel107);
            this.panel59.Controls.Add(this.panel108);
            this.panel59.Controls.Add(this.panel109);
            this.panel59.Controls.Add(this.panel110);
            this.panel59.Controls.Add(this.panel111);
            this.panel59.Controls.Add(this.panel112);
            this.panel59.Controls.Add(this.panel113);
            this.panel59.Controls.Add(this.panel114);
            this.panel59.Controls.Add(this.panel115);
            this.panel59.Controls.Add(this.panel116);
            this.panel59.Controls.Add(this.label180);
            this.panel59.Controls.Add(this.label181);
            this.panel59.Controls.Add(this.label80);
            this.panel59.Controls.Add(this.label79);
            this.panel59.Controls.Add(this.label71);
            this.panel59.Controls.Add(this.label70);
            this.panel59.Controls.Add(this.label69);
            this.panel59.Controls.Add(this.label72);
            this.panel59.Controls.Add(this.label73);
            this.panel59.Controls.Add(this.label74);
            this.panel59.Controls.Add(this.label75);
            this.panel59.Controls.Add(this.label76);
            this.panel59.Controls.Add(this.label77);
            this.panel59.Controls.Add(this.label78);
            this.panel59.Controls.Add(this.label83);
            this.panel59.Controls.Add(this.label81);
            this.panel59.Controls.Add(this.label82);
            this.panel59.Location = new System.Drawing.Point(2, 2);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(244, 287);
            this.panel59.TabIndex = 161;
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.shopItem14);
            this.panel103.Location = new System.Drawing.Point(75, 252);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(170, 17);
            this.panel103.TabIndex = 174;
            // 
            // shopItem14
            // 
            this.shopItem14.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem14.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem14.DropDownHeight = 314;
            this.shopItem14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem14.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem14.IntegralHeight = false;
            this.shopItem14.Location = new System.Drawing.Point(-2, -2);
            this.shopItem14.Name = "shopItem14";
            this.shopItem14.Size = new System.Drawing.Size(174, 22);
            this.shopItem14.TabIndex = 433;
            this.shopItem14.Tag = "";
            this.shopItem14.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem14.SelectedIndexChanged += new System.EventHandler(this.shopItem14_SelectedIndexChanged);
            // 
            // panel104
            // 
            this.panel104.Controls.Add(this.shopItem13);
            this.panel104.Location = new System.Drawing.Point(75, 234);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(170, 17);
            this.panel104.TabIndex = 173;
            // 
            // shopItem13
            // 
            this.shopItem13.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem13.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem13.DropDownHeight = 314;
            this.shopItem13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem13.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem13.IntegralHeight = false;
            this.shopItem13.Location = new System.Drawing.Point(-2, -2);
            this.shopItem13.Name = "shopItem13";
            this.shopItem13.Size = new System.Drawing.Size(174, 22);
            this.shopItem13.TabIndex = 434;
            this.shopItem13.Tag = "";
            this.shopItem13.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem13.SelectedIndexChanged += new System.EventHandler(this.shopItem13_SelectedIndexChanged);
            // 
            // panel102
            // 
            this.panel102.Controls.Add(this.shopItem15);
            this.panel102.Location = new System.Drawing.Point(75, 270);
            this.panel102.Name = "panel102";
            this.panel102.Size = new System.Drawing.Size(170, 17);
            this.panel102.TabIndex = 175;
            // 
            // shopItem15
            // 
            this.shopItem15.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem15.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem15.DropDownHeight = 314;
            this.shopItem15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem15.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem15.IntegralHeight = false;
            this.shopItem15.Location = new System.Drawing.Point(-2, -2);
            this.shopItem15.Name = "shopItem15";
            this.shopItem15.Size = new System.Drawing.Size(174, 22);
            this.shopItem15.TabIndex = 435;
            this.shopItem15.Tag = "";
            this.shopItem15.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem15.SelectedIndexChanged += new System.EventHandler(this.shopItem15_SelectedIndexChanged);
            // 
            // panel105
            // 
            this.panel105.Controls.Add(this.shopItem12);
            this.panel105.Location = new System.Drawing.Point(75, 216);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(170, 17);
            this.panel105.TabIndex = 172;
            // 
            // shopItem12
            // 
            this.shopItem12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem12.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem12.DropDownHeight = 314;
            this.shopItem12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem12.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem12.IntegralHeight = false;
            this.shopItem12.Location = new System.Drawing.Point(-2, -2);
            this.shopItem12.Name = "shopItem12";
            this.shopItem12.Size = new System.Drawing.Size(174, 22);
            this.shopItem12.TabIndex = 431;
            this.shopItem12.Tag = "";
            this.shopItem12.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem12.SelectedIndexChanged += new System.EventHandler(this.shopItem12_SelectedIndexChanged);
            // 
            // panel106
            // 
            this.panel106.Controls.Add(this.shopItem11);
            this.panel106.Location = new System.Drawing.Point(75, 198);
            this.panel106.Name = "panel106";
            this.panel106.Size = new System.Drawing.Size(170, 17);
            this.panel106.TabIndex = 171;
            // 
            // shopItem11
            // 
            this.shopItem11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem11.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem11.DropDownHeight = 314;
            this.shopItem11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem11.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem11.IntegralHeight = false;
            this.shopItem11.Location = new System.Drawing.Point(-2, -2);
            this.shopItem11.Name = "shopItem11";
            this.shopItem11.Size = new System.Drawing.Size(174, 22);
            this.shopItem11.TabIndex = 432;
            this.shopItem11.Tag = "";
            this.shopItem11.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem11.SelectedIndexChanged += new System.EventHandler(this.shopItem11_SelectedIndexChanged);
            // 
            // panel107
            // 
            this.panel107.Controls.Add(this.shopItem10);
            this.panel107.Location = new System.Drawing.Point(75, 180);
            this.panel107.Name = "panel107";
            this.panel107.Size = new System.Drawing.Size(170, 17);
            this.panel107.TabIndex = 170;
            // 
            // shopItem10
            // 
            this.shopItem10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem10.DropDownHeight = 314;
            this.shopItem10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem10.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem10.IntegralHeight = false;
            this.shopItem10.Location = new System.Drawing.Point(-2, -2);
            this.shopItem10.Name = "shopItem10";
            this.shopItem10.Size = new System.Drawing.Size(174, 22);
            this.shopItem10.TabIndex = 429;
            this.shopItem10.Tag = "";
            this.shopItem10.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem10.SelectedIndexChanged += new System.EventHandler(this.shopItem10_SelectedIndexChanged);
            // 
            // panel108
            // 
            this.panel108.Controls.Add(this.shopItem9);
            this.panel108.Location = new System.Drawing.Point(75, 162);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(170, 17);
            this.panel108.TabIndex = 169;
            // 
            // shopItem9
            // 
            this.shopItem9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem9.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem9.DropDownHeight = 314;
            this.shopItem9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem9.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem9.IntegralHeight = false;
            this.shopItem9.Location = new System.Drawing.Point(-2, -2);
            this.shopItem9.Name = "shopItem9";
            this.shopItem9.Size = new System.Drawing.Size(174, 22);
            this.shopItem9.TabIndex = 430;
            this.shopItem9.Tag = "";
            this.shopItem9.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem9.SelectedIndexChanged += new System.EventHandler(this.shopItem9_SelectedIndexChanged);
            // 
            // panel109
            // 
            this.panel109.Controls.Add(this.shopItem8);
            this.panel109.Location = new System.Drawing.Point(75, 144);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(170, 17);
            this.panel109.TabIndex = 168;
            // 
            // shopItem8
            // 
            this.shopItem8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem8.DropDownHeight = 314;
            this.shopItem8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem8.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem8.IntegralHeight = false;
            this.shopItem8.Location = new System.Drawing.Point(-2, -2);
            this.shopItem8.Name = "shopItem8";
            this.shopItem8.Size = new System.Drawing.Size(174, 22);
            this.shopItem8.TabIndex = 427;
            this.shopItem8.Tag = "";
            this.shopItem8.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem8.SelectedIndexChanged += new System.EventHandler(this.shopItem8_SelectedIndexChanged);
            // 
            // panel110
            // 
            this.panel110.Controls.Add(this.shopItem7);
            this.panel110.Location = new System.Drawing.Point(75, 126);
            this.panel110.Name = "panel110";
            this.panel110.Size = new System.Drawing.Size(170, 17);
            this.panel110.TabIndex = 167;
            // 
            // shopItem7
            // 
            this.shopItem7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem7.DropDownHeight = 314;
            this.shopItem7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem7.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem7.IntegralHeight = false;
            this.shopItem7.Location = new System.Drawing.Point(-2, -2);
            this.shopItem7.Name = "shopItem7";
            this.shopItem7.Size = new System.Drawing.Size(174, 22);
            this.shopItem7.TabIndex = 428;
            this.shopItem7.Tag = "";
            this.shopItem7.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem7.SelectedIndexChanged += new System.EventHandler(this.shopItem7_SelectedIndexChanged);
            // 
            // panel111
            // 
            this.panel111.Controls.Add(this.shopItem6);
            this.panel111.Location = new System.Drawing.Point(75, 108);
            this.panel111.Name = "panel111";
            this.panel111.Size = new System.Drawing.Size(170, 17);
            this.panel111.TabIndex = 166;
            // 
            // shopItem6
            // 
            this.shopItem6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem6.DropDownHeight = 314;
            this.shopItem6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem6.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem6.IntegralHeight = false;
            this.shopItem6.Location = new System.Drawing.Point(-2, -2);
            this.shopItem6.Name = "shopItem6";
            this.shopItem6.Size = new System.Drawing.Size(174, 22);
            this.shopItem6.TabIndex = 425;
            this.shopItem6.Tag = "";
            this.shopItem6.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem6.SelectedIndexChanged += new System.EventHandler(this.shopItem6_SelectedIndexChanged);
            // 
            // panel112
            // 
            this.panel112.Controls.Add(this.shopItem5);
            this.panel112.Location = new System.Drawing.Point(75, 90);
            this.panel112.Name = "panel112";
            this.panel112.Size = new System.Drawing.Size(170, 17);
            this.panel112.TabIndex = 165;
            // 
            // shopItem5
            // 
            this.shopItem5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem5.DropDownHeight = 314;
            this.shopItem5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem5.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem5.IntegralHeight = false;
            this.shopItem5.Location = new System.Drawing.Point(-2, -2);
            this.shopItem5.Name = "shopItem5";
            this.shopItem5.Size = new System.Drawing.Size(174, 22);
            this.shopItem5.TabIndex = 426;
            this.shopItem5.Tag = "";
            this.shopItem5.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem5.SelectedIndexChanged += new System.EventHandler(this.shopItem5_SelectedIndexChanged);
            // 
            // panel113
            // 
            this.panel113.Controls.Add(this.shopItem4);
            this.panel113.Location = new System.Drawing.Point(75, 72);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(170, 17);
            this.panel113.TabIndex = 164;
            // 
            // shopItem4
            // 
            this.shopItem4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem4.DropDownHeight = 314;
            this.shopItem4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem4.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem4.IntegralHeight = false;
            this.shopItem4.Location = new System.Drawing.Point(-2, -2);
            this.shopItem4.Name = "shopItem4";
            this.shopItem4.Size = new System.Drawing.Size(174, 22);
            this.shopItem4.TabIndex = 423;
            this.shopItem4.Tag = "";
            this.shopItem4.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem4.SelectedIndexChanged += new System.EventHandler(this.shopItem4_SelectedIndexChanged);
            // 
            // panel114
            // 
            this.panel114.Controls.Add(this.shopItem3);
            this.panel114.Location = new System.Drawing.Point(75, 54);
            this.panel114.Name = "panel114";
            this.panel114.Size = new System.Drawing.Size(170, 17);
            this.panel114.TabIndex = 163;
            // 
            // shopItem3
            // 
            this.shopItem3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem3.DropDownHeight = 314;
            this.shopItem3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem3.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem3.IntegralHeight = false;
            this.shopItem3.Location = new System.Drawing.Point(-2, -2);
            this.shopItem3.Name = "shopItem3";
            this.shopItem3.Size = new System.Drawing.Size(174, 22);
            this.shopItem3.TabIndex = 424;
            this.shopItem3.Tag = "";
            this.shopItem3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem3.SelectedIndexChanged += new System.EventHandler(this.shopItem3_SelectedIndexChanged);
            // 
            // panel115
            // 
            this.panel115.Controls.Add(this.shopItem2);
            this.panel115.Location = new System.Drawing.Point(75, 36);
            this.panel115.Name = "panel115";
            this.panel115.Size = new System.Drawing.Size(170, 17);
            this.panel115.TabIndex = 162;
            // 
            // shopItem2
            // 
            this.shopItem2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem2.DropDownHeight = 314;
            this.shopItem2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem2.IntegralHeight = false;
            this.shopItem2.Location = new System.Drawing.Point(-2, -2);
            this.shopItem2.Name = "shopItem2";
            this.shopItem2.Size = new System.Drawing.Size(174, 22);
            this.shopItem2.TabIndex = 421;
            this.shopItem2.Tag = "";
            this.shopItem2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem2.SelectedIndexChanged += new System.EventHandler(this.shopItem2_SelectedIndexChanged);
            // 
            // panel116
            // 
            this.panel116.Controls.Add(this.shopItem1);
            this.panel116.Location = new System.Drawing.Point(75, 18);
            this.panel116.Name = "panel116";
            this.panel116.Size = new System.Drawing.Size(170, 17);
            this.panel116.TabIndex = 161;
            // 
            // shopItem1
            // 
            this.shopItem1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.shopItem1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem1.DropDownHeight = 314;
            this.shopItem1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.shopItem1.IntegralHeight = false;
            this.shopItem1.Location = new System.Drawing.Point(-2, -2);
            this.shopItem1.Name = "shopItem1";
            this.shopItem1.Size = new System.Drawing.Size(174, 22);
            this.shopItem1.TabIndex = 422;
            this.shopItem1.Tag = "";
            this.shopItem1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem1.SelectedIndexChanged += new System.EventHandler(this.shopItem1_SelectedIndexChanged);
            // 
            // label180
            // 
            this.label180.BackColor = System.Drawing.SystemColors.Control;
            this.label180.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label180.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label180.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label180.Location = new System.Drawing.Point(0, 0);
            this.label180.Name = "label180";
            this.label180.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label180.Size = new System.Drawing.Size(74, 17);
            this.label180.TabIndex = 499;
            this.label180.Text = "###";
            this.label180.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label181
            // 
            this.label181.BackColor = System.Drawing.SystemColors.Control;
            this.label181.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label181.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label181.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label181.Location = new System.Drawing.Point(75, 0);
            this.label181.Name = "label181";
            this.label181.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label181.Size = new System.Drawing.Size(169, 17);
            this.label181.TabIndex = 498;
            this.label181.Text = "ITEM";
            this.label181.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label80.Location = new System.Drawing.Point(0, 72);
            this.label80.Name = "label80";
            this.label80.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label80.Size = new System.Drawing.Size(74, 17);
            this.label80.TabIndex = 486;
            this.label80.Text = "Item 4";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label79.Location = new System.Drawing.Point(0, 90);
            this.label79.Name = "label79";
            this.label79.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label79.Size = new System.Drawing.Size(74, 17);
            this.label79.TabIndex = 487;
            this.label79.Text = "Item 5";
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label71.Location = new System.Drawing.Point(0, 234);
            this.label71.Name = "label71";
            this.label71.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label71.Size = new System.Drawing.Size(74, 17);
            this.label71.TabIndex = 495;
            this.label71.Text = "Item 13";
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label70.Location = new System.Drawing.Point(0, 252);
            this.label70.Name = "label70";
            this.label70.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label70.Size = new System.Drawing.Size(74, 17);
            this.label70.TabIndex = 496;
            this.label70.Text = "Item 14";
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label69.Location = new System.Drawing.Point(0, 270);
            this.label69.Name = "label69";
            this.label69.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label69.Size = new System.Drawing.Size(74, 17);
            this.label69.TabIndex = 497;
            this.label69.Text = "Item 15";
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label72.Location = new System.Drawing.Point(0, 216);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label72.Size = new System.Drawing.Size(74, 17);
            this.label72.TabIndex = 494;
            this.label72.Text = "Item 12";
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label73.Location = new System.Drawing.Point(0, 198);
            this.label73.Name = "label73";
            this.label73.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label73.Size = new System.Drawing.Size(74, 17);
            this.label73.TabIndex = 493;
            this.label73.Text = "Item 11";
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label74.Location = new System.Drawing.Point(0, 180);
            this.label74.Name = "label74";
            this.label74.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label74.Size = new System.Drawing.Size(74, 17);
            this.label74.TabIndex = 492;
            this.label74.Text = "Item 10";
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label75.Location = new System.Drawing.Point(0, 162);
            this.label75.Name = "label75";
            this.label75.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label75.Size = new System.Drawing.Size(74, 17);
            this.label75.TabIndex = 491;
            this.label75.Text = "Item 9";
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label76.Location = new System.Drawing.Point(0, 144);
            this.label76.Name = "label76";
            this.label76.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label76.Size = new System.Drawing.Size(74, 17);
            this.label76.TabIndex = 490;
            this.label76.Text = "Item 8";
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label77.Location = new System.Drawing.Point(0, 126);
            this.label77.Name = "label77";
            this.label77.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label77.Size = new System.Drawing.Size(74, 17);
            this.label77.TabIndex = 489;
            this.label77.Text = "Item 7";
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label78.Location = new System.Drawing.Point(0, 108);
            this.label78.Name = "label78";
            this.label78.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label78.Size = new System.Drawing.Size(74, 17);
            this.label78.TabIndex = 488;
            this.label78.Text = "Item 6";
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label83.Location = new System.Drawing.Point(0, 18);
            this.label83.Name = "label83";
            this.label83.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label83.Size = new System.Drawing.Size(74, 17);
            this.label83.TabIndex = 483;
            this.label83.Text = "Item 1";
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label81.Location = new System.Drawing.Point(0, 54);
            this.label81.Name = "label81";
            this.label81.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label81.Size = new System.Drawing.Size(74, 17);
            this.label81.TabIndex = 485;
            this.label81.Text = "Item 3";
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label82.Location = new System.Drawing.Point(0, 36);
            this.label82.Name = "label82";
            this.label82.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label82.Size = new System.Drawing.Size(74, 17);
            this.label82.TabIndex = 484;
            this.label82.Text = "Item 2";
            // 
            // label161
            // 
            this.label161.BackColor = System.Drawing.SystemColors.Control;
            this.label161.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label161.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label161.Location = new System.Drawing.Point(0, 0);
            this.label161.Name = "label161";
            this.label161.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label161.Size = new System.Drawing.Size(244, 17);
            this.label161.TabIndex = 501;
            this.label161.Text = "SHOP OPTIONS";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.SystemColors.Control;
            this.label102.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label102.Location = new System.Drawing.Point(0, 0);
            this.label102.Name = "label102";
            this.label102.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label102.Size = new System.Drawing.Size(244, 17);
            this.label102.TabIndex = 500;
            this.label102.Text = "PURCHASE DISCOUNTS (can combine +)";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shopNum
            // 
            this.shopNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shopNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopNum.ForeColor = System.Drawing.SystemColors.Control;
            this.shopNum.Location = new System.Drawing.Point(124, 2);
            this.shopNum.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.shopNum.Name = "shopNum";
            this.shopNum.Size = new System.Drawing.Size(123, 17);
            this.shopNum.TabIndex = 0;
            this.shopNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.shopNum.ValueChanged += new System.EventHandler(this.shopNum_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel2.Controls.Add(this.panelItemDesc);
            this.panel2.Controls.Add(this.panel228);
            this.panel2.Controls.Add(this.panel226);
            this.panel2.Controls.Add(this.panel195);
            this.panel2.Controls.Add(this.panel193);
            this.panel2.Controls.Add(this.panel191);
            this.panel2.Controls.Add(this.panel190);
            this.panel2.Controls.Add(this.panel187);
            this.panel2.Controls.Add(this.panel185);
            this.panel2.Controls.Add(this.panel188);
            this.panel2.Controls.Add(this.panel186);
            this.panel2.Controls.Add(this.panel184);
            this.panel2.Controls.Add(this.panel178);
            this.panel2.Controls.Add(this.panel177);
            this.panel2.Controls.Add(this.panel175);
            this.panel2.Controls.Add(this.panel174);
            this.panel2.Controls.Add(this.panel173);
            this.panel2.Controls.Add(this.panel172);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(681, 580);
            this.panel2.TabIndex = 482;
            // 
            // panelItemDesc
            // 
            this.panelItemDesc.Controls.Add(this.label195);
            this.panelItemDesc.Controls.Add(this.pictureBoxItemDesc);
            this.panelItemDesc.Location = new System.Drawing.Point(204, 442);
            this.panelItemDesc.Name = "panelItemDesc";
            this.panelItemDesc.Size = new System.Drawing.Size(140, 87);
            this.panelItemDesc.TabIndex = 544;
            this.panelItemDesc.Visible = false;
            // 
            // label195
            // 
            this.label195.BackColor = System.Drawing.SystemColors.Control;
            this.label195.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label195.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label195.Location = new System.Drawing.Point(2, 2);
            this.label195.Name = "label195";
            this.label195.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label195.Size = new System.Drawing.Size(136, 17);
            this.label195.TabIndex = 173;
            this.label195.Text = "PREVIEW";
            this.label195.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxItemDesc
            // 
            this.pictureBoxItemDesc.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxItemDesc.Location = new System.Drawing.Point(2, 21);
            this.pictureBoxItemDesc.Name = "pictureBoxItemDesc";
            this.pictureBoxItemDesc.Size = new System.Drawing.Size(136, 64);
            this.pictureBoxItemDesc.TabIndex = 0;
            this.pictureBoxItemDesc.TabStop = false;
            this.pictureBoxItemDesc.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxItemDesc_Paint);
            // 
            // panel228
            // 
            this.panel228.Controls.Add(this.panel229);
            this.panel228.Location = new System.Drawing.Point(426, 554);
            this.panel228.Name = "panel228";
            this.panel228.Size = new System.Drawing.Size(248, 20);
            this.panel228.TabIndex = 543;
            // 
            // panel229
            // 
            this.panel229.BackColor = System.Drawing.SystemColors.Control;
            this.panel229.Location = new System.Drawing.Point(2, 2);
            this.panel229.Name = "panel229";
            this.panel229.Size = new System.Drawing.Size(244, 16);
            this.panel229.TabIndex = 540;
            // 
            // panel226
            // 
            this.panel226.Controls.Add(this.panel227);
            this.panel226.Location = new System.Drawing.Point(212, 546);
            this.panel226.Name = "panel226";
            this.panel226.Size = new System.Drawing.Size(208, 28);
            this.panel226.TabIndex = 542;
            // 
            // panel227
            // 
            this.panel227.BackColor = System.Drawing.SystemColors.Control;
            this.panel227.Location = new System.Drawing.Point(2, 2);
            this.panel227.Name = "panel227";
            this.panel227.Size = new System.Drawing.Size(204, 24);
            this.panel227.TabIndex = 540;
            // 
            // panel195
            // 
            this.panel195.Controls.Add(this.panel192);
            this.panel195.Location = new System.Drawing.Point(426, 461);
            this.panel195.Name = "panel195";
            this.panel195.Size = new System.Drawing.Size(248, 87);
            this.panel195.TabIndex = 14;
            // 
            // panel192
            // 
            this.panel192.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel192.Controls.Add(this.label102);
            this.panel192.Controls.Add(this.shopDiscounts);
            this.panel192.Location = new System.Drawing.Point(2, 2);
            this.panel192.Name = "panel192";
            this.panel192.Size = new System.Drawing.Size(244, 83);
            this.panel192.TabIndex = 537;
            // 
            // shopDiscounts
            // 
            this.shopDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shopDiscounts.CheckOnClick = true;
            this.shopDiscounts.ColumnWidth = 110;
            this.shopDiscounts.Items.AddRange(new object[] {
            "6% discount",
            "12% discount",
            "25% discount",
            "50% discount"});
            this.shopDiscounts.Location = new System.Drawing.Point(0, 19);
            this.shopDiscounts.MultiColumn = true;
            this.shopDiscounts.Name = "shopDiscounts";
            this.shopDiscounts.Size = new System.Drawing.Size(244, 64);
            this.shopDiscounts.TabIndex = 177;
            this.shopDiscounts.SelectedIndexChanged += new System.EventHandler(this.shopDiscounts_SelectedIndexChanged);
            // 
            // panel193
            // 
            this.panel193.Controls.Add(this.panel194);
            this.panel193.Location = new System.Drawing.Point(426, 368);
            this.panel193.Name = "panel193";
            this.panel193.Size = new System.Drawing.Size(248, 87);
            this.panel193.TabIndex = 13;
            // 
            // panel194
            // 
            this.panel194.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel194.Controls.Add(this.label161);
            this.panel194.Controls.Add(this.shopBuyOptions);
            this.panel194.Location = new System.Drawing.Point(2, 2);
            this.panel194.Name = "panel194";
            this.panel194.Size = new System.Drawing.Size(244, 83);
            this.panel194.TabIndex = 538;
            // 
            // shopBuyOptions
            // 
            this.shopBuyOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shopBuyOptions.CheckOnClick = true;
            this.shopBuyOptions.Items.AddRange(new object[] {
            "Buy with Frog Coins, one product each",
            "Buy with Frog Coins",
            "Buy only, no selling",
            "Buy only, no selling"});
            this.shopBuyOptions.Location = new System.Drawing.Point(0, 19);
            this.shopBuyOptions.Name = "shopBuyOptions";
            this.shopBuyOptions.Size = new System.Drawing.Size(244, 64);
            this.shopBuyOptions.TabIndex = 176;
            this.shopBuyOptions.SelectedIndexChanged += new System.EventHandler(this.shopBuyOptions_SelectedIndexChanged);
            // 
            // panel191
            // 
            this.panel191.Controls.Add(this.panel100);
            this.panel191.Controls.Add(this.label190);
            this.panel191.Controls.Add(this.shopNum);
            this.panel191.Controls.Add(this.labelShopLabel);
            this.panel191.Controls.Add(this.panel223);
            this.panel191.Location = new System.Drawing.Point(426, 6);
            this.panel191.Name = "panel191";
            this.panel191.Size = new System.Drawing.Size(248, 59);
            this.panel191.TabIndex = 11;
            // 
            // label190
            // 
            this.label190.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label190.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label190.ForeColor = System.Drawing.SystemColors.Control;
            this.label190.Location = new System.Drawing.Point(2, 2);
            this.label190.Name = "label190";
            this.label190.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label190.Size = new System.Drawing.Size(121, 17);
            this.label190.TabIndex = 455;
            this.label190.Text = "SHOP #";
            // 
            // labelShopLabel
            // 
            this.labelShopLabel.BackColor = System.Drawing.SystemColors.Control;
            this.labelShopLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShopLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelShopLabel.Location = new System.Drawing.Point(2, 40);
            this.labelShopLabel.Name = "labelShopLabel";
            this.labelShopLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelShopLabel.Size = new System.Drawing.Size(74, 17);
            this.labelShopLabel.TabIndex = 458;
            this.labelShopLabel.Text = "LABEL";
            // 
            // panel223
            // 
            this.panel223.BackColor = System.Drawing.SystemColors.Window;
            this.panel223.Controls.Add(this.shopLabel);
            this.panel223.Location = new System.Drawing.Point(77, 40);
            this.panel223.Name = "panel223";
            this.panel223.Size = new System.Drawing.Size(169, 17);
            this.panel223.TabIndex = 132;
            // 
            // shopLabel
            // 
            this.shopLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shopLabel.Location = new System.Drawing.Point(4, 2);
            this.shopLabel.Name = "shopLabel";
            this.shopLabel.Size = new System.Drawing.Size(161, 14);
            this.shopLabel.TabIndex = 309;
            this.shopLabel.TextChanged += new System.EventHandler(this.shopLabel_TextChanged);
            this.shopLabel.Leave += new System.EventHandler(this.shopLabel_Leave);
            // 
            // panel190
            // 
            this.panel190.Controls.Add(this.panel189);
            this.panel190.Location = new System.Drawing.Point(212, 160);
            this.panel190.Name = "panel190";
            this.panel190.Size = new System.Drawing.Size(208, 55);
            this.panel190.TabIndex = 6;
            // 
            // panel189
            // 
            this.panel189.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel189.Controls.Add(this.label89);
            this.panel189.Controls.Add(this.itemElemWeak);
            this.panel189.Location = new System.Drawing.Point(2, 2);
            this.panel189.Name = "panel189";
            this.panel189.Size = new System.Drawing.Size(204, 51);
            this.panel189.TabIndex = 534;
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.SystemColors.Control;
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label89.Location = new System.Drawing.Point(0, 0);
            this.label89.Name = "label89";
            this.label89.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label89.Size = new System.Drawing.Size(204, 17);
            this.label89.TabIndex = 473;
            this.label89.Text = "ELEMENT WEAKNESSES...";
            // 
            // panel187
            // 
            this.panel187.Controls.Add(this.panel181);
            this.panel187.Location = new System.Drawing.Point(212, 6);
            this.panel187.Name = "panel187";
            this.panel187.Size = new System.Drawing.Size(208, 87);
            this.panel187.TabIndex = 4;
            // 
            // panel181
            // 
            this.panel181.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel181.Controls.Add(this.label101);
            this.panel181.Controls.Add(this.itemStatusEffect);
            this.panel181.Location = new System.Drawing.Point(2, 2);
            this.panel181.Name = "panel181";
            this.panel181.Size = new System.Drawing.Size(204, 83);
            this.panel181.TabIndex = 526;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.SystemColors.Control;
            this.label101.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label101.Location = new System.Drawing.Point(0, 0);
            this.label101.Name = "label101";
            this.label101.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label101.Size = new System.Drawing.Size(204, 17);
            this.label101.TabIndex = 474;
            this.label101.Text = "EFFECT";
            // 
            // itemStatusEffect
            // 
            this.itemStatusEffect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemStatusEffect.CheckOnClick = true;
            this.itemStatusEffect.ColumnWidth = 100;
            this.itemStatusEffect.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincible"});
            this.itemStatusEffect.Location = new System.Drawing.Point(0, 19);
            this.itemStatusEffect.MultiColumn = true;
            this.itemStatusEffect.Name = "itemStatusEffect";
            this.itemStatusEffect.Size = new System.Drawing.Size(204, 64);
            this.itemStatusEffect.TabIndex = 149;
            this.itemStatusEffect.SelectedIndexChanged += new System.EventHandler(this.itemStatusEffect_SelectedIndexChanged);
            // 
            // panel185
            // 
            this.panel185.Controls.Add(this.panel180);
            this.panel185.Location = new System.Drawing.Point(212, 221);
            this.panel185.Name = "panel185";
            this.panel185.Size = new System.Drawing.Size(208, 87);
            this.panel185.TabIndex = 7;
            // 
            // panel180
            // 
            this.panel180.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel180.Controls.Add(this.label99);
            this.panel180.Controls.Add(this.itemStatusChange);
            this.panel180.Location = new System.Drawing.Point(2, 2);
            this.panel180.Name = "panel180";
            this.panel180.Size = new System.Drawing.Size(204, 83);
            this.panel180.TabIndex = 525;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.SystemColors.Control;
            this.label99.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label99.Location = new System.Drawing.Point(0, 0);
            this.label99.Name = "label99";
            this.label99.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label99.Size = new System.Drawing.Size(204, 17);
            this.label99.TabIndex = 475;
            this.label99.Text = "STATUS CHANGE...";
            // 
            // itemStatusChange
            // 
            this.itemStatusChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemStatusChange.CheckOnClick = true;
            this.itemStatusChange.Items.AddRange(new object[] {
            "Attack",
            "Defense",
            "Magic Attack",
            "Magic Defense"});
            this.itemStatusChange.Location = new System.Drawing.Point(0, 19);
            this.itemStatusChange.Name = "itemStatusChange";
            this.itemStatusChange.Size = new System.Drawing.Size(204, 64);
            this.itemStatusChange.TabIndex = 150;
            this.itemStatusChange.SelectedIndexChanged += new System.EventHandler(this.itemStatusChange_SelectedIndexChanged);
            // 
            // panel188
            // 
            this.panel188.Controls.Add(this.panel183);
            this.panel188.Location = new System.Drawing.Point(212, 99);
            this.panel188.Name = "panel188";
            this.panel188.Size = new System.Drawing.Size(208, 55);
            this.panel188.TabIndex = 5;
            // 
            // panel183
            // 
            this.panel183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel183.Controls.Add(this.label67);
            this.panel183.Controls.Add(this.itemElemNull);
            this.panel183.Location = new System.Drawing.Point(2, 2);
            this.panel183.Name = "panel183";
            this.panel183.Size = new System.Drawing.Size(204, 51);
            this.panel183.TabIndex = 528;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.SystemColors.Control;
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label67.Location = new System.Drawing.Point(0, 0);
            this.label67.Name = "label67";
            this.label67.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label67.Size = new System.Drawing.Size(204, 17);
            this.label67.TabIndex = 472;
            this.label67.Text = "ELEMENT NULLIFICATION...";
            // 
            // panel186
            // 
            this.panel186.Controls.Add(this.panel182);
            this.panel186.Location = new System.Drawing.Point(212, 314);
            this.panel186.Name = "panel186";
            this.panel186.Size = new System.Drawing.Size(208, 71);
            this.panel186.TabIndex = 8;
            // 
            // panel182
            // 
            this.panel182.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel182.Controls.Add(this.label86);
            this.panel182.Controls.Add(this.itemWhoEquip);
            this.panel182.Location = new System.Drawing.Point(2, 2);
            this.panel182.Name = "panel182";
            this.panel182.Size = new System.Drawing.Size(204, 67);
            this.panel182.TabIndex = 527;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.SystemColors.Control;
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label86.Location = new System.Drawing.Point(0, 0);
            this.label86.Name = "label86";
            this.label86.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label86.Size = new System.Drawing.Size(204, 17);
            this.label86.TabIndex = 476;
            this.label86.Text = "WHO CAN EQUIP";
            // 
            // itemWhoEquip
            // 
            this.itemWhoEquip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemWhoEquip.CheckOnClick = true;
            this.itemWhoEquip.ColumnWidth = 100;
            this.itemWhoEquip.Items.AddRange(new object[] {
            "Mario",
            "Toadstool",
            "Bowser",
            "Geno",
            "Mallow"});
            this.itemWhoEquip.Location = new System.Drawing.Point(0, 19);
            this.itemWhoEquip.MultiColumn = true;
            this.itemWhoEquip.Name = "itemWhoEquip";
            this.itemWhoEquip.Size = new System.Drawing.Size(204, 48);
            this.itemWhoEquip.TabIndex = 151;
            this.itemWhoEquip.SelectedIndexChanged += new System.EventHandler(this.itemWhoEquip_SelectedIndexChanged);
            // 
            // panel184
            // 
            this.panel184.Controls.Add(this.panel179);
            this.panel184.Location = new System.Drawing.Point(212, 391);
            this.panel184.Name = "panel184";
            this.panel184.Size = new System.Drawing.Size(208, 71);
            this.panel184.TabIndex = 9;
            // 
            // panel179
            // 
            this.panel179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel179.Controls.Add(this.label85);
            this.panel179.Controls.Add(this.itemTargetting);
            this.panel179.Location = new System.Drawing.Point(2, 2);
            this.panel179.Name = "panel179";
            this.panel179.Size = new System.Drawing.Size(204, 67);
            this.panel179.TabIndex = 524;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.SystemColors.Control;
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label85.Location = new System.Drawing.Point(0, 0);
            this.label85.Name = "label85";
            this.label85.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label85.Size = new System.Drawing.Size(204, 17);
            this.label85.TabIndex = 477;
            this.label85.Text = "TARGETTING...";
            // 
            // itemTargetting
            // 
            this.itemTargetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemTargetting.CheckOnClick = true;
            this.itemTargetting.ColumnWidth = 100;
            this.itemTargetting.Items.AddRange(new object[] {
            "Other Targets",
            "Enemy Party",
            "Entire Party",
            "Wounded Only",
            "One Party Only",
            "Not Self"});
            this.itemTargetting.Location = new System.Drawing.Point(0, 19);
            this.itemTargetting.MultiColumn = true;
            this.itemTargetting.Name = "itemTargetting";
            this.itemTargetting.Size = new System.Drawing.Size(204, 48);
            this.itemTargetting.TabIndex = 152;
            this.itemTargetting.SelectedIndexChanged += new System.EventHandler(this.itemTargetting_SelectedIndexChanged);
            // 
            // panel178
            // 
            this.panel178.Controls.Add(this.panel94);
            this.panel178.Controls.Add(this.label8);
            this.panel178.Controls.Add(this.itemNum);
            this.panel178.Controls.Add(this.label25);
            this.panel178.Controls.Add(this.panel61);
            this.panel178.Controls.Add(this.panel1);
            this.panel178.Controls.Add(this.label23);
            this.panel178.Location = new System.Drawing.Point(6, 6);
            this.panel178.Name = "panel178";
            this.panel178.Size = new System.Drawing.Size(200, 77);
            this.panel178.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label25.Location = new System.Drawing.Point(2, 40);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label25.Size = new System.Drawing.Size(98, 17);
            this.label25.TabIndex = 458;
            this.label25.Text = "NAME";
            // 
            // panel177
            // 
            this.panel177.Controls.Add(this.panel176);
            this.panel177.Location = new System.Drawing.Point(6, 442);
            this.panel177.Name = "panel177";
            this.panel177.Size = new System.Drawing.Size(200, 132);
            this.panel177.TabIndex = 3;
            // 
            // panel176
            // 
            this.panel176.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel176.Controls.Add(this.buttonPreviewItemDesc);
            this.panel176.Controls.Add(this.panelItemDescription);
            this.panel176.Controls.Add(this.buttonItemDescriptionBreak);
            this.panel176.Controls.Add(this.buttonItemDescriptionEnd);
            this.panel176.Controls.Add(this.label98);
            this.panel176.Location = new System.Drawing.Point(2, 2);
            this.panel176.Name = "panel176";
            this.panel176.Size = new System.Drawing.Size(196, 128);
            this.panel176.TabIndex = 521;
            // 
            // buttonPreviewItemDesc
            // 
            this.buttonPreviewItemDesc.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPreviewItemDesc.FlatAppearance.BorderSize = 0;
            this.buttonPreviewItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreviewItemDesc.Image = global::SMRPGED.Properties.Resources.foward;
            this.buttonPreviewItemDesc.Location = new System.Drawing.Point(172, 0);
            this.buttonPreviewItemDesc.Name = "buttonPreviewItemDesc";
            this.buttonPreviewItemDesc.Size = new System.Drawing.Size(24, 17);
            this.buttonPreviewItemDesc.TabIndex = 480;
            this.toolTip1.SetToolTip(this.buttonPreviewItemDesc, "Show / hide preview");
            this.buttonPreviewItemDesc.UseCompatibleTextRendering = true;
            this.buttonPreviewItemDesc.UseVisualStyleBackColor = false;
            this.buttonPreviewItemDesc.Click += new System.EventHandler(this.buttonPreviewItemDesc_Click);
            // 
            // panelItemDescription
            // 
            this.panelItemDescription.BackColor = System.Drawing.SystemColors.Window;
            this.panelItemDescription.Controls.Add(this.textBoxItemDescription);
            this.panelItemDescription.Location = new System.Drawing.Point(0, 19);
            this.panelItemDescription.Name = "panelItemDescription";
            this.panelItemDescription.Size = new System.Drawing.Size(196, 91);
            this.panelItemDescription.TabIndex = 153;
            // 
            // textBoxItemDescription
            // 
            this.textBoxItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemDescription.Location = new System.Drawing.Point(4, 4);
            this.textBoxItemDescription.MaxLength = 127;
            this.textBoxItemDescription.Name = "textBoxItemDescription";
            this.textBoxItemDescription.Size = new System.Drawing.Size(188, 83);
            this.textBoxItemDescription.TabIndex = 1;
            this.textBoxItemDescription.Text = "";
            this.textBoxItemDescription.TextChanged += new System.EventHandler(this.textBoxItemDescription_TextChanged);
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label98.Location = new System.Drawing.Point(0, 0);
            this.label98.Name = "label98";
            this.label98.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label98.Size = new System.Drawing.Size(172, 17);
            this.label98.TabIndex = 479;
            this.label98.Text = "DESCRIPTION";
            // 
            // panel175
            // 
            this.panel175.Controls.Add(this.panel60);
            this.panel175.Location = new System.Drawing.Point(212, 468);
            this.panel175.Name = "panel175";
            this.panel175.Size = new System.Drawing.Size(208, 73);
            this.panel175.TabIndex = 10;
            // 
            // panel60
            // 
            this.panel60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel60.Controls.Add(this.label14);
            this.panel60.Controls.Add(this.label95);
            this.panel60.Controls.Add(this.itemCursorRestore);
            this.panel60.Controls.Add(this.panel95);
            this.panel60.Location = new System.Drawing.Point(2, 2);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(204, 69);
            this.panel60.TabIndex = 156;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(0, 19);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label14.Size = new System.Drawing.Size(88, 17);
            this.label14.TabIndex = 483;
            this.label14.Text = "Direct Cursor To...";
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.SystemColors.Control;
            this.label95.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label95.Location = new System.Drawing.Point(0, 0);
            this.label95.Name = "label95";
            this.label95.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label95.Size = new System.Drawing.Size(204, 17);
            this.label95.TabIndex = 482;
            this.label95.Text = "MENU CURSOR BEHAVIOR...";
            // 
            // panel95
            // 
            this.panel95.Controls.Add(this.itemCursor);
            this.panel95.Location = new System.Drawing.Point(89, 19);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(116, 17);
            this.panel95.TabIndex = 157;
            // 
            // itemCursor
            // 
            this.itemCursor.DropDownHeight = 250;
            this.itemCursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemCursor.IntegralHeight = false;
            this.itemCursor.Items.AddRange(new object[] {
            "to HP",
            "to FP"});
            this.itemCursor.Location = new System.Drawing.Point(-2, -2);
            this.itemCursor.Name = "itemCursor";
            this.itemCursor.Size = new System.Drawing.Size(120, 21);
            this.itemCursor.TabIndex = 481;
            this.itemCursor.SelectedIndexChanged += new System.EventHandler(this.itemCursor_SelectedIndexChanged);
            // 
            // panel174
            // 
            this.panel174.Controls.Add(this.panel59);
            this.panel174.Location = new System.Drawing.Point(426, 71);
            this.panel174.Name = "panel174";
            this.panel174.Size = new System.Drawing.Size(248, 291);
            this.panel174.TabIndex = 12;
            // 
            // panel173
            // 
            this.panel173.Controls.Add(this.panel58);
            this.panel173.Location = new System.Drawing.Point(6, 261);
            this.panel173.Name = "panel173";
            this.panel173.Size = new System.Drawing.Size(200, 175);
            this.panel173.TabIndex = 2;
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel58.Controls.Add(this.itemUsage);
            this.panel58.Controls.Add(this.panel96);
            this.panel58.Controls.Add(this.panel97);
            this.panel58.Controls.Add(this.panel98);
            this.panel58.Controls.Add(this.panel99);
            this.panel58.Controls.Add(this.label15);
            this.panel58.Controls.Add(this.label109);
            this.panel58.Controls.Add(this.label107);
            this.panel58.Controls.Add(this.label100);
            this.panel58.Controls.Add(this.label97);
            this.panel58.Location = new System.Drawing.Point(1, 1);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(198, 173);
            this.panel58.TabIndex = 142;
            // 
            // panel96
            // 
            this.panel96.Controls.Add(this.itemType);
            this.panel96.Location = new System.Drawing.Point(99, 18);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(98, 17);
            this.panel96.TabIndex = 142;
            // 
            // itemType
            // 
            this.itemType.DropDownHeight = 250;
            this.itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemType.IntegralHeight = false;
            this.itemType.Items.AddRange(new object[] {
            "Weapon",
            "Armor",
            "Accessory",
            "Item"});
            this.itemType.Location = new System.Drawing.Point(-2, -2);
            this.itemType.Name = "itemType";
            this.itemType.Size = new System.Drawing.Size(102, 21);
            this.itemType.TabIndex = 435;
            this.itemType.SelectedIndexChanged += new System.EventHandler(this.itemType_SelectedIndexChanged);
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.itemAttackType);
            this.panel97.Location = new System.Drawing.Point(99, 36);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(98, 17);
            this.panel97.TabIndex = 143;
            // 
            // itemAttackType
            // 
            this.itemAttackType.DropDownHeight = 250;
            this.itemAttackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemAttackType.IntegralHeight = false;
            this.itemAttackType.Items.AddRange(new object[] {
            "Infliction",
            "Protection",
            "Nullification",
            "{NONE}"});
            this.itemAttackType.Location = new System.Drawing.Point(-2, -2);
            this.itemAttackType.Name = "itemAttackType";
            this.itemAttackType.Size = new System.Drawing.Size(102, 21);
            this.itemAttackType.TabIndex = 436;
            this.itemAttackType.SelectedIndexChanged += new System.EventHandler(this.itemAttackType_SelectedIndexChanged);
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.itemFunction);
            this.panel98.Location = new System.Drawing.Point(99, 54);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(98, 17);
            this.panel98.TabIndex = 144;
            // 
            // itemFunction
            // 
            this.itemFunction.DropDownHeight = 250;
            this.itemFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemFunction.IntegralHeight = false;
            this.itemFunction.Items.AddRange(new object[] {
            "Item Morph",
            "Revive",
            "Restore FP",
            "Restore HP",
            "Restore all HP/FP",
            "Raise Max FP",
            "Instant Death",
            "{NONE}"});
            this.itemFunction.Location = new System.Drawing.Point(-2, -2);
            this.itemFunction.Name = "itemFunction";
            this.itemFunction.Size = new System.Drawing.Size(102, 21);
            this.itemFunction.TabIndex = 428;
            this.itemFunction.SelectedIndexChanged += new System.EventHandler(this.itemFunction_SelectedIndexChanged);
            // 
            // panel99
            // 
            this.panel99.Controls.Add(this.itemElemAttack);
            this.panel99.Location = new System.Drawing.Point(99, 72);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(98, 17);
            this.panel99.TabIndex = 145;
            // 
            // itemElemAttack
            // 
            this.itemElemAttack.DropDownHeight = 250;
            this.itemElemAttack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemElemAttack.IntegralHeight = false;
            this.itemElemAttack.Items.AddRange(new object[] {
            "Ice",
            "Thunder",
            "Fire",
            "Jump",
            "{NONE}"});
            this.itemElemAttack.Location = new System.Drawing.Point(-2, -2);
            this.itemElemAttack.Name = "itemElemAttack";
            this.itemElemAttack.Size = new System.Drawing.Size(102, 21);
            this.itemElemAttack.TabIndex = 443;
            this.itemElemAttack.SelectedIndexChanged += new System.EventHandler(this.itemElemAttack_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label15.Location = new System.Drawing.Point(0, -1);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label15.Size = new System.Drawing.Size(196, 17);
            this.label15.TabIndex = 471;
            this.label15.Text = "ITEM PROPERTIES";
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label109.Location = new System.Drawing.Point(0, 18);
            this.label109.Name = "label109";
            this.label109.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label109.Size = new System.Drawing.Size(98, 17);
            this.label109.TabIndex = 469;
            this.label109.Text = "Item Type";
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label107.Location = new System.Drawing.Point(0, 36);
            this.label107.Name = "label107";
            this.label107.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label107.Size = new System.Drawing.Size(98, 17);
            this.label107.TabIndex = 470;
            this.label107.Text = "Effect Type";
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label100.Location = new System.Drawing.Point(0, 72);
            this.label100.Name = "label100";
            this.label100.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label100.Size = new System.Drawing.Size(98, 17);
            this.label100.TabIndex = 467;
            this.label100.Text = "Inflict Element";
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label97.Location = new System.Drawing.Point(0, 54);
            this.label97.Name = "label97";
            this.label97.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label97.Size = new System.Drawing.Size(98, 17);
            this.label97.TabIndex = 468;
            this.label97.Text = "Inflict Function";
            // 
            // panel172
            // 
            this.panel172.Controls.Add(this.panel93);
            this.panel172.Location = new System.Drawing.Point(6, 89);
            this.panel172.Name = "panel172";
            this.panel172.Size = new System.Drawing.Size(200, 166);
            this.panel172.TabIndex = 1;
            // 
            // panel93
            // 
            this.panel93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel93.Controls.Add(this.label28);
            this.panel93.Controls.Add(this.label104);
            this.panel93.Controls.Add(this.itemSpeed);
            this.panel93.Controls.Add(this.itemAttack);
            this.panel93.Controls.Add(this.itemDefense);
            this.panel93.Controls.Add(this.itemMagicDefense);
            this.panel93.Controls.Add(this.itemAttackRange);
            this.panel93.Controls.Add(this.itemMagicAttack);
            this.panel93.Controls.Add(this.itemPower);
            this.panel93.Controls.Add(this.itemCoinValue);
            this.panel93.Controls.Add(this.label108);
            this.panel93.Controls.Add(this.label106);
            this.panel93.Controls.Add(this.label105);
            this.panel93.Controls.Add(this.label103);
            this.panel93.Controls.Add(this.label93);
            this.panel93.Controls.Add(this.label33);
            this.panel93.Controls.Add(this.label29);
            this.panel93.Location = new System.Drawing.Point(2, 2);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(196, 162);
            this.panel93.TabIndex = 134;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label28.Size = new System.Drawing.Size(196, 17);
            this.label28.TabIndex = 457;
            this.label28.Text = "STATISTICS";
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label104.Location = new System.Drawing.Point(0, 19);
            this.label104.Name = "label104";
            this.label104.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label104.Size = new System.Drawing.Size(98, 17);
            this.label104.TabIndex = 459;
            this.label104.Text = "Coin Value";
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label108.Location = new System.Drawing.Point(0, 37);
            this.label108.Name = "label108";
            this.label108.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label108.Size = new System.Drawing.Size(98, 17);
            this.label108.TabIndex = 460;
            this.label108.Text = "Speed";
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label106.Location = new System.Drawing.Point(0, 55);
            this.label106.Name = "label106";
            this.label106.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label106.Size = new System.Drawing.Size(98, 17);
            this.label106.TabIndex = 465;
            this.label106.Text = "Attack Range";
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label105.Location = new System.Drawing.Point(0, 73);
            this.label105.Name = "label105";
            this.label105.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label105.Size = new System.Drawing.Size(98, 17);
            this.label105.TabIndex = 466;
            this.label105.Text = "Infliction Amount";
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label103.Location = new System.Drawing.Point(0, 109);
            this.label103.Name = "label103";
            this.label103.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label103.Size = new System.Drawing.Size(98, 17);
            this.label103.TabIndex = 462;
            this.label103.Text = "Defense";
            // 
            // label93
            // 
            this.label93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label93.Location = new System.Drawing.Point(0, 91);
            this.label93.Name = "label93";
            this.label93.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label93.Size = new System.Drawing.Size(98, 17);
            this.label93.TabIndex = 461;
            this.label93.Text = "Attack";
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label33.Location = new System.Drawing.Point(0, 127);
            this.label33.Name = "label33";
            this.label33.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label33.Size = new System.Drawing.Size(98, 17);
            this.label33.TabIndex = 463;
            this.label33.Text = "Magic Attack";
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label29.Location = new System.Drawing.Point(0, 145);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label29.Size = new System.Drawing.Size(98, 17);
            this.label29.TabIndex = 464;
            this.label29.Text = "Magic Defense";
            // 
            // panel117
            // 
            this.panel117.BackColor = System.Drawing.SystemColors.Window;
            this.panel117.Controls.Add(this.textBoxCharacterName);
            this.panel117.Location = new System.Drawing.Point(99, 40);
            this.panel117.Name = "panel117";
            this.panel117.Size = new System.Drawing.Size(119, 17);
            this.panel117.TabIndex = 180;
            // 
            // textBoxCharacterName
            // 
            this.textBoxCharacterName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCharacterName.Location = new System.Drawing.Point(4, 2);
            this.textBoxCharacterName.MaxLength = 10;
            this.textBoxCharacterName.Name = "textBoxCharacterName";
            this.textBoxCharacterName.Size = new System.Drawing.Size(111, 14);
            this.textBoxCharacterName.TabIndex = 228;
            this.textBoxCharacterName.TextChanged += new System.EventHandler(this.textBoxCharacterName_TextChanged);
            this.textBoxCharacterName.Leave += new System.EventHandler(this.textBoxCharacterName_Leave);
            // 
            // panel118
            // 
            this.panel118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel118.Controls.Add(this.label188);
            this.panel118.Controls.Add(this.label132);
            this.panel118.Controls.Add(this.startingMgAttack);
            this.panel118.Controls.Add(this.startingMgDefense);
            this.panel118.Controls.Add(this.startingExperience);
            this.panel118.Controls.Add(this.startingDefense);
            this.panel118.Controls.Add(this.startingAttack);
            this.panel118.Controls.Add(this.startingLevel);
            this.panel118.Controls.Add(this.label128);
            this.panel118.Controls.Add(this.label131);
            this.panel118.Controls.Add(this.panel28);
            this.panel118.Controls.Add(this.label133);
            this.panel118.Controls.Add(this.startingMaximumHP);
            this.panel118.Controls.Add(this.panel120);
            this.panel118.Controls.Add(this.panel119);
            this.panel118.Controls.Add(this.label130);
            this.panel118.Controls.Add(this.startingSpeed);
            this.panel118.Controls.Add(this.label138);
            this.panel118.Controls.Add(this.startingCurrentHP);
            this.panel118.Controls.Add(this.label125);
            this.panel118.Controls.Add(this.label127);
            this.panel118.Controls.Add(this.label90);
            this.panel118.Controls.Add(this.label91);
            this.panel118.Controls.Add(this.label135);
            this.panel118.Controls.Add(this.label134);
            this.panel118.Controls.Add(this.startingMagic);
            this.panel118.Location = new System.Drawing.Point(2, 21);
            this.panel118.Name = "panel118";
            this.panel118.Size = new System.Drawing.Size(219, 544);
            this.panel118.TabIndex = 193;
            // 
            // label188
            // 
            this.label188.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label188.Location = new System.Drawing.Point(0, 0);
            this.label188.Name = "label188";
            this.label188.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label188.Size = new System.Drawing.Size(101, 17);
            this.label188.TabIndex = 102;
            this.label188.Text = "Level";
            // 
            // startingAttack
            // 
            this.startingAttack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingAttack.Location = new System.Drawing.Point(102, 18);
            this.startingAttack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.startingAttack.Name = "startingAttack";
            this.startingAttack.Size = new System.Drawing.Size(118, 17);
            this.startingAttack.TabIndex = 194;
            this.startingAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingAttack.ValueChanged += new System.EventHandler(this.startingAttack_ValueChanged);
            // 
            // startingLevel
            // 
            this.startingLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingLevel.Location = new System.Drawing.Point(102, 0);
            this.startingLevel.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.startingLevel.Name = "startingLevel";
            this.startingLevel.Size = new System.Drawing.Size(118, 17);
            this.startingLevel.TabIndex = 193;
            this.startingLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startingLevel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.startingLevel.ValueChanged += new System.EventHandler(this.startingLevel_ValueChanged);
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.startingWeapon);
            this.panel28.Location = new System.Drawing.Point(102, 108);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(118, 17);
            this.panel28.TabIndex = 199;
            // 
            // startingWeapon
            // 
            this.startingWeapon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingWeapon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingWeapon.DropDownHeight = 314;
            this.startingWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingWeapon.DropDownWidth = 150;
            this.startingWeapon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingWeapon.ForeColor = System.Drawing.SystemColors.Control;
            this.startingWeapon.IntegralHeight = false;
            this.startingWeapon.Location = new System.Drawing.Point(-2, -2);
            this.startingWeapon.Name = "startingWeapon";
            this.startingWeapon.Size = new System.Drawing.Size(122, 22);
            this.startingWeapon.TabIndex = 109;
            this.startingWeapon.Tag = "";
            this.startingWeapon.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingWeapon.SelectedIndexChanged += new System.EventHandler(this.startingWeapon_SelectedIndexChanged);
            // 
            // panel120
            // 
            this.panel120.Controls.Add(this.startingAccessory);
            this.panel120.Location = new System.Drawing.Point(102, 144);
            this.panel120.Name = "panel120";
            this.panel120.Size = new System.Drawing.Size(118, 17);
            this.panel120.TabIndex = 201;
            // 
            // startingAccessory
            // 
            this.startingAccessory.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingAccessory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingAccessory.DropDownHeight = 314;
            this.startingAccessory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingAccessory.DropDownWidth = 150;
            this.startingAccessory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingAccessory.ForeColor = System.Drawing.SystemColors.Control;
            this.startingAccessory.IntegralHeight = false;
            this.startingAccessory.Location = new System.Drawing.Point(-2, -2);
            this.startingAccessory.Name = "startingAccessory";
            this.startingAccessory.Size = new System.Drawing.Size(122, 22);
            this.startingAccessory.TabIndex = 111;
            this.startingAccessory.Tag = "";
            this.startingAccessory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingAccessory.SelectedIndexChanged += new System.EventHandler(this.startingAccessory_SelectedIndexChanged);
            // 
            // panel119
            // 
            this.panel119.Controls.Add(this.startingArmor);
            this.panel119.Location = new System.Drawing.Point(102, 126);
            this.panel119.Name = "panel119";
            this.panel119.Size = new System.Drawing.Size(118, 17);
            this.panel119.TabIndex = 200;
            // 
            // startingArmor
            // 
            this.startingArmor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingArmor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingArmor.DropDownHeight = 314;
            this.startingArmor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingArmor.DropDownWidth = 150;
            this.startingArmor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingArmor.ForeColor = System.Drawing.SystemColors.Control;
            this.startingArmor.IntegralHeight = false;
            this.startingArmor.Location = new System.Drawing.Point(-2, -2);
            this.startingArmor.Name = "startingArmor";
            this.startingArmor.Size = new System.Drawing.Size(122, 22);
            this.startingArmor.TabIndex = 110;
            this.startingArmor.Tag = "";
            this.startingArmor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingArmor.SelectedIndexChanged += new System.EventHandler(this.startingArmor_SelectedIndexChanged);
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label90.Location = new System.Drawing.Point(0, 18);
            this.label90.Name = "label90";
            this.label90.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label90.Size = new System.Drawing.Size(101, 17);
            this.label90.TabIndex = 102;
            this.label90.Text = "Attack";
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.SystemColors.Control;
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label91.Location = new System.Drawing.Point(0, 217);
            this.label91.Name = "label91";
            this.label91.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label91.Size = new System.Drawing.Size(219, 17);
            this.label91.TabIndex = 261;
            this.label91.Text = "STARTING MAGIC...";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startingMagic
            // 
            this.startingMagic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingMagic.CheckOnClick = true;
            this.startingMagic.ColumnWidth = 95;
            this.startingMagic.IntegralHeight = false;
            this.startingMagic.Location = new System.Drawing.Point(0, 236);
            this.startingMagic.Name = "startingMagic";
            this.startingMagic.Size = new System.Drawing.Size(219, 308);
            this.startingMagic.TabIndex = 205;
            this.startingMagic.SelectedIndexChanged += new System.EventHandler(this.startingMagic_SelectedIndexChanged);
            // 
            // panel121
            // 
            this.panel121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel121.Controls.Add(this.label163);
            this.panel121.Controls.Add(this.startingMaximumFP);
            this.panel121.Controls.Add(this.startingCurrentFP);
            this.panel121.Controls.Add(this.startingFrogCoins);
            this.panel121.Controls.Add(this.startingCoins);
            this.panel121.Controls.Add(this.label165);
            this.panel121.Controls.Add(this.label166);
            this.panel121.Controls.Add(this.label164);
            this.panel121.Location = new System.Drawing.Point(2, 21);
            this.panel121.Name = "panel121";
            this.panel121.Size = new System.Drawing.Size(209, 71);
            this.panel121.TabIndex = 206;
            // 
            // slotNum
            // 
            this.slotNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.slotNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.slotNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotNum.ForeColor = System.Drawing.SystemColors.Control;
            this.slotNum.Location = new System.Drawing.Point(97, 0);
            this.slotNum.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.slotNum.Name = "slotNum";
            this.slotNum.Size = new System.Drawing.Size(113, 17);
            this.slotNum.TabIndex = 210;
            this.slotNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.slotNum.ValueChanged += new System.EventHandler(this.slotNum_ValueChanged);
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label92.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.ForeColor = System.Drawing.SystemColors.Control;
            this.label92.Location = new System.Drawing.Point(0, 0);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label92.Size = new System.Drawing.Size(96, 17);
            this.label92.TabIndex = 329;
            this.label92.Text = "SLOT #";
            // 
            // panel122
            // 
            this.panel122.Controls.Add(this.startingItem);
            this.panel122.Location = new System.Drawing.Point(97, 18);
            this.panel122.Name = "panel122";
            this.panel122.Size = new System.Drawing.Size(113, 17);
            this.panel122.TabIndex = 211;
            // 
            // startingItem
            // 
            this.startingItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingItem.DropDownHeight = 314;
            this.startingItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingItem.DropDownWidth = 150;
            this.startingItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startingItem.IntegralHeight = false;
            this.startingItem.Location = new System.Drawing.Point(-2, -2);
            this.startingItem.Name = "startingItem";
            this.startingItem.Size = new System.Drawing.Size(117, 22);
            this.startingItem.TabIndex = 322;
            this.startingItem.Tag = "";
            this.startingItem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingItem.SelectedIndexChanged += new System.EventHandler(this.startingItem_SelectedIndexChanged);
            // 
            // panel124
            // 
            this.panel124.Controls.Add(this.startingSpecialItem);
            this.panel124.Location = new System.Drawing.Point(97, 36);
            this.panel124.Name = "panel124";
            this.panel124.Size = new System.Drawing.Size(113, 17);
            this.panel124.TabIndex = 212;
            // 
            // startingSpecialItem
            // 
            this.startingSpecialItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingSpecialItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingSpecialItem.DropDownHeight = 314;
            this.startingSpecialItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingSpecialItem.DropDownWidth = 150;
            this.startingSpecialItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingSpecialItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startingSpecialItem.IntegralHeight = false;
            this.startingSpecialItem.Location = new System.Drawing.Point(-2, -2);
            this.startingSpecialItem.Name = "startingSpecialItem";
            this.startingSpecialItem.Size = new System.Drawing.Size(117, 22);
            this.startingSpecialItem.TabIndex = 323;
            this.startingSpecialItem.Tag = "";
            this.startingSpecialItem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingSpecialItem.SelectedIndexChanged += new System.EventHandler(this.startingSpecialItem_SelectedIndexChanged);
            // 
            // panel123
            // 
            this.panel123.Controls.Add(this.startingEquipment);
            this.panel123.Location = new System.Drawing.Point(97, 54);
            this.panel123.Name = "panel123";
            this.panel123.Size = new System.Drawing.Size(113, 17);
            this.panel123.TabIndex = 213;
            // 
            // startingEquipment
            // 
            this.startingEquipment.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startingEquipment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.startingEquipment.DropDownHeight = 314;
            this.startingEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startingEquipment.DropDownWidth = 150;
            this.startingEquipment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingEquipment.ForeColor = System.Drawing.SystemColors.Control;
            this.startingEquipment.IntegralHeight = false;
            this.startingEquipment.Location = new System.Drawing.Point(-2, -2);
            this.startingEquipment.Name = "startingEquipment";
            this.startingEquipment.Size = new System.Drawing.Size(117, 22);
            this.startingEquipment.TabIndex = 324;
            this.startingEquipment.Tag = "";
            this.startingEquipment.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.startingEquipment.SelectedIndexChanged += new System.EventHandler(this.startingEquipment_SelectedIndexChanged);
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.characterName);
            this.panel47.Location = new System.Drawing.Point(2, 21);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(217, 17);
            this.panel47.TabIndex = 178;
            // 
            // characterName
            // 
            this.characterName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.characterName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.characterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterName.ForeColor = System.Drawing.SystemColors.Control;
            this.characterName.Location = new System.Drawing.Point(-2, -2);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(221, 22);
            this.characterName.TabIndex = 359;
            this.characterName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.characterName_DrawItem);
            this.characterName.SelectedIndexChanged += new System.EventHandler(this.characterName_SelectedIndexChanged);
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label94.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.SystemColors.Control;
            this.label94.Location = new System.Drawing.Point(2, 2);
            this.label94.Name = "label94";
            this.label94.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label94.Size = new System.Drawing.Size(96, 17);
            this.label94.TabIndex = 533;
            this.label94.Text = "CHARACTER #";
            // 
            // characterNum
            // 
            this.characterNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.characterNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.characterNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterNum.ForeColor = System.Drawing.SystemColors.Control;
            this.characterNum.Location = new System.Drawing.Point(99, 2);
            this.characterNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.characterNum.Name = "characterNum";
            this.characterNum.Size = new System.Drawing.Size(120, 17);
            this.characterNum.TabIndex = 0;
            this.characterNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.characterNum.ValueChanged += new System.EventHandler(this.characterNum_ValueChanged);
            // 
            // panel46
            // 
            this.panel46.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel46.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel46.Controls.Add(this.panel230);
            this.panel46.Controls.Add(this.panel49);
            this.panel46.Controls.Add(this.panel48);
            this.panel46.Controls.Add(this.panel125);
            this.panel46.Controls.Add(this.panel224);
            this.panel46.Controls.Add(this.panel199);
            this.panel46.Controls.Add(this.panel198);
            this.panel46.Controls.Add(this.panel197);
            this.panel46.Controls.Add(this.panel196);
            this.panel46.Controls.Add(this.panel22);
            this.panel46.Location = new System.Drawing.Point(2, 2);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(681, 580);
            this.panel46.TabIndex = 483;
            // 
            // panel230
            // 
            this.panel230.Controls.Add(this.panel231);
            this.panel230.Location = new System.Drawing.Point(6, 372);
            this.panel230.Name = "panel230";
            this.panel230.Size = new System.Drawing.Size(220, 40);
            this.panel230.TabIndex = 3;
            // 
            // panel231
            // 
            this.panel231.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel231.Controls.Add(this.label192);
            this.panel231.Controls.Add(this.label201);
            this.panel231.Controls.Add(this.panel232);
            this.panel231.Location = new System.Drawing.Point(2, 2);
            this.panel231.Name = "panel231";
            this.panel231.Size = new System.Drawing.Size(216, 36);
            this.panel231.TabIndex = 551;
            // 
            // label192
            // 
            this.label192.BackColor = System.Drawing.SystemColors.Control;
            this.label192.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label192.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label192.Location = new System.Drawing.Point(0, 0);
            this.label192.Name = "label192";
            this.label192.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label192.Size = new System.Drawing.Size(216, 17);
            this.label192.TabIndex = 163;
            this.label192.Text = "LEVEL UP SPELL LEARNING...";
            this.label192.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label201
            // 
            this.label201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label201.Location = new System.Drawing.Point(0, 19);
            this.label201.Name = "label201";
            this.label201.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label201.Size = new System.Drawing.Size(96, 17);
            this.label201.TabIndex = 244;
            this.label201.Text = "Learned Spell";
            // 
            // panel232
            // 
            this.panel232.Controls.Add(this.levelUpSpellLearned);
            this.panel232.Location = new System.Drawing.Point(98, 19);
            this.panel232.Name = "panel232";
            this.panel232.Size = new System.Drawing.Size(119, 17);
            this.panel232.TabIndex = 199;
            // 
            // levelUpSpellLearned
            // 
            this.levelUpSpellLearned.BackColor = System.Drawing.SystemColors.ControlDark;
            this.levelUpSpellLearned.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.levelUpSpellLearned.DropDownHeight = 314;
            this.levelUpSpellLearned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelUpSpellLearned.DropDownWidth = 150;
            this.levelUpSpellLearned.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelUpSpellLearned.ForeColor = System.Drawing.SystemColors.Control;
            this.levelUpSpellLearned.IntegralHeight = false;
            this.levelUpSpellLearned.Location = new System.Drawing.Point(-2, -2);
            this.levelUpSpellLearned.Name = "levelUpSpellLearned";
            this.levelUpSpellLearned.Size = new System.Drawing.Size(123, 22);
            this.levelUpSpellLearned.TabIndex = 109;
            this.levelUpSpellLearned.Tag = "";
            this.levelUpSpellLearned.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.levelUpSpellLearned_DrawItem);
            this.levelUpSpellLearned.SelectedIndexChanged += new System.EventHandler(this.levelUpSpellLearned_SelectedIndexChanged);
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.panel44);
            this.panel49.Location = new System.Drawing.Point(6, 254);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(220, 112);
            this.panel49.TabIndex = 3;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel44.Controls.Add(this.label139);
            this.panel44.Controls.Add(this.label137);
            this.panel44.Controls.Add(this.hpPlusBonus);
            this.panel44.Controls.Add(this.label113);
            this.panel44.Controls.Add(this.defensePlusBonus);
            this.panel44.Controls.Add(this.attackPlusBonus);
            this.panel44.Controls.Add(this.label114);
            this.panel44.Controls.Add(this.label116);
            this.panel44.Controls.Add(this.mgDefensePlusBonus);
            this.panel44.Controls.Add(this.mgAttackPlusBonus);
            this.panel44.Controls.Add(this.label115);
            this.panel44.Location = new System.Drawing.Point(2, 2);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(216, 108);
            this.panel44.TabIndex = 551;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.panel43);
            this.panel48.Location = new System.Drawing.Point(6, 136);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(220, 112);
            this.panel48.TabIndex = 2;
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel43.Controls.Add(this.label136);
            this.panel43.Controls.Add(this.hpPlus);
            this.panel43.Controls.Add(this.attackPlus);
            this.panel43.Controls.Add(this.label122);
            this.panel43.Controls.Add(this.label121);
            this.panel43.Controls.Add(this.mgAttackPlus);
            this.panel43.Controls.Add(this.label120);
            this.panel43.Controls.Add(this.label117);
            this.panel43.Controls.Add(this.defensePlus);
            this.panel43.Controls.Add(this.mgDefensePlus);
            this.panel43.Controls.Add(this.label118);
            this.panel43.Location = new System.Drawing.Point(2, 2);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(216, 108);
            this.panel43.TabIndex = 550;
            // 
            // label136
            // 
            this.label136.BackColor = System.Drawing.SystemColors.Control;
            this.label136.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label136.Location = new System.Drawing.Point(0, 0);
            this.label136.Name = "label136";
            this.label136.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label136.Size = new System.Drawing.Size(216, 17);
            this.label136.TabIndex = 162;
            this.label136.Text = "LEVEL UP STAT INCREMENTS...";
            this.label136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel125
            // 
            this.panel125.Controls.Add(this.panel126);
            this.panel125.Location = new System.Drawing.Point(461, 206);
            this.panel125.Name = "panel125";
            this.panel125.Size = new System.Drawing.Size(213, 367);
            this.panel125.TabIndex = 549;
            // 
            // panel126
            // 
            this.panel126.BackColor = System.Drawing.SystemColors.Control;
            this.panel126.Location = new System.Drawing.Point(2, 2);
            this.panel126.Name = "panel126";
            this.panel126.Size = new System.Drawing.Size(209, 363);
            this.panel126.TabIndex = 540;
            // 
            // panel224
            // 
            this.panel224.Controls.Add(this.panel225);
            this.panel224.Location = new System.Drawing.Point(6, 418);
            this.panel224.Name = "panel224";
            this.panel224.Size = new System.Drawing.Size(220, 155);
            this.panel224.TabIndex = 549;
            // 
            // panel225
            // 
            this.panel225.BackColor = System.Drawing.SystemColors.Control;
            this.panel225.Location = new System.Drawing.Point(2, 2);
            this.panel225.Name = "panel225";
            this.panel225.Size = new System.Drawing.Size(216, 151);
            this.panel225.TabIndex = 540;
            // 
            // panel199
            // 
            this.panel199.Controls.Add(this.panel47);
            this.panel199.Controls.Add(this.label94);
            this.panel199.Controls.Add(this.characterNum);
            this.panel199.Controls.Add(this.label185);
            this.panel199.Controls.Add(this.panel117);
            this.panel199.Location = new System.Drawing.Point(6, 6);
            this.panel199.Name = "panel199";
            this.panel199.Size = new System.Drawing.Size(220, 59);
            this.panel199.TabIndex = 0;
            // 
            // panel198
            // 
            this.panel198.Controls.Add(this.label235);
            this.panel198.Controls.Add(this.panel118);
            this.panel198.Location = new System.Drawing.Point(232, 6);
            this.panel198.Name = "panel198";
            this.panel198.Size = new System.Drawing.Size(223, 567);
            this.panel198.TabIndex = 4;
            // 
            // panel197
            // 
            this.panel197.Controls.Add(this.panel101);
            this.panel197.Controls.Add(this.label189);
            this.panel197.Location = new System.Drawing.Point(6, 71);
            this.panel197.Name = "panel197";
            this.panel197.Size = new System.Drawing.Size(220, 59);
            this.panel197.TabIndex = 1;
            // 
            // panel101
            // 
            this.panel101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel101.Controls.Add(this.label129);
            this.panel101.Controls.Add(this.expNeeded);
            this.panel101.Controls.Add(this.levelNum);
            this.panel101.Controls.Add(this.label124);
            this.panel101.Location = new System.Drawing.Point(2, 21);
            this.panel101.Name = "panel101";
            this.panel101.Size = new System.Drawing.Size(216, 36);
            this.panel101.TabIndex = 181;
            // 
            // levelNum
            // 
            this.levelNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.levelNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.levelNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNum.ForeColor = System.Drawing.SystemColors.Control;
            this.levelNum.Location = new System.Drawing.Point(97, 0);
            this.levelNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.levelNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(120, 17);
            this.levelNum.TabIndex = 181;
            this.levelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.levelNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.levelNum.ValueChanged += new System.EventHandler(this.levelNum_ValueChanged);
            // 
            // panel196
            // 
            this.panel196.Controls.Add(this.panel11);
            this.panel196.Controls.Add(this.label194);
            this.panel196.Location = new System.Drawing.Point(461, 106);
            this.panel196.Name = "panel196";
            this.panel196.Size = new System.Drawing.Size(213, 94);
            this.panel196.TabIndex = 6;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel11.Controls.Add(this.label92);
            this.panel11.Controls.Add(this.panel123);
            this.panel11.Controls.Add(this.panel124);
            this.panel11.Controls.Add(this.panel122);
            this.panel11.Controls.Add(this.label84);
            this.panel11.Controls.Add(this.label88);
            this.panel11.Controls.Add(this.label162);
            this.panel11.Controls.Add(this.slotNum);
            this.panel11.Location = new System.Drawing.Point(2, 21);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(209, 71);
            this.panel11.TabIndex = 538;
            // 
            // label194
            // 
            this.label194.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label194.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label194.ForeColor = System.Drawing.SystemColors.Control;
            this.label194.Location = new System.Drawing.Point(2, 2);
            this.label194.Name = "label194";
            this.label194.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label194.Size = new System.Drawing.Size(209, 17);
            this.label194.TabIndex = 340;
            this.label194.Text = "STARTING ITEMS...";
            this.label194.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.label193);
            this.panel22.Controls.Add(this.panel121);
            this.panel22.Location = new System.Drawing.Point(461, 6);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(213, 94);
            this.panel22.TabIndex = 5;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel15.Controls.Add(this.label202);
            this.panel15.Controls.Add(this.panel18);
            this.panel15.Controls.Add(this.panel17);
            this.panel15.Controls.Add(this.numericUpDown7);
            this.panel15.Controls.Add(this.numericUpDown8);
            this.panel15.Controls.Add(this.label155);
            this.panel15.Controls.Add(this.label156);
            this.panel15.Controls.Add(this.label177);
            this.panel15.Location = new System.Drawing.Point(2, 2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(323, 72);
            this.panel15.TabIndex = 305;
            // 
            // label202
            // 
            this.label202.BackColor = System.Drawing.SystemColors.Control;
            this.label202.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label202.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label202.Location = new System.Drawing.Point(0, 0);
            this.label202.Name = "label202";
            this.label202.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label202.Size = new System.Drawing.Size(160, 17);
            this.label202.TabIndex = 239;
            this.label202.Text = "MULTIPLE TIMING";
            this.label202.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.instanceNumberName);
            this.panel18.Location = new System.Drawing.Point(161, 37);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(163, 17);
            this.panel18.TabIndex = 307;
            // 
            // instanceNumberName
            // 
            this.instanceNumberName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.instanceNumberName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.instanceNumberName.DropDownHeight = 223;
            this.instanceNumberName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instanceNumberName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instanceNumberName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.instanceNumberName.IntegralHeight = false;
            this.instanceNumberName.Location = new System.Drawing.Point(-2, -2);
            this.instanceNumberName.Name = "instanceNumberName";
            this.instanceNumberName.Size = new System.Drawing.Size(167, 22);
            this.instanceNumberName.TabIndex = 353;
            this.instanceNumberName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.instanceNumberName_DrawItem);
            this.instanceNumberName.SelectedIndexChanged += new System.EventHandler(this.instanceNumberName_SelectedIndexChanged);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.multipleTimingSpellName);
            this.panel17.Location = new System.Drawing.Point(161, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(163, 17);
            this.panel17.TabIndex = 305;
            // 
            // multipleTimingSpellName
            // 
            this.multipleTimingSpellName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.multipleTimingSpellName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.multipleTimingSpellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multipleTimingSpellName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multipleTimingSpellName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.multipleTimingSpellName.Location = new System.Drawing.Point(-2, -2);
            this.multipleTimingSpellName.Name = "multipleTimingSpellName";
            this.multipleTimingSpellName.Size = new System.Drawing.Size(167, 22);
            this.multipleTimingSpellName.TabIndex = 353;
            this.multipleTimingSpellName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.multipleTimingSpellName_DrawItem);
            this.multipleTimingSpellName.SelectedIndexChanged += new System.EventHandler(this.multipleTimingSpellName_SelectedIndexChanged);
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown7.Location = new System.Drawing.Point(161, 19);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(163, 17);
            this.numericUpDown7.TabIndex = 306;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown7.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown8.Location = new System.Drawing.Point(161, 55);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(163, 17);
            this.numericUpDown8.TabIndex = 308;
            this.numericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // label155
            // 
            this.label155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label155.Location = new System.Drawing.Point(0, 55);
            this.label155.Name = "label155";
            this.label155.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label155.Size = new System.Drawing.Size(160, 17);
            this.label155.TabIndex = 40;
            this.label155.Text = "Instance Frame Duration";
            // 
            // label156
            // 
            this.label156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label156.Location = new System.Drawing.Point(0, 19);
            this.label156.Name = "label156";
            this.label156.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label156.Size = new System.Drawing.Size(160, 17);
            this.label156.TabIndex = 39;
            this.label156.Text = "Number of Multiple Instances";
            // 
            // label177
            // 
            this.label177.BackColor = System.Drawing.SystemColors.Control;
            this.label177.Location = new System.Drawing.Point(0, 37);
            this.label177.Name = "label177";
            this.label177.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label177.Size = new System.Drawing.Size(160, 17);
            this.label177.TabIndex = 39;
            this.label177.Text = "Instance Number";
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel19.Controls.Add(this.panel220);
            this.panel19.Controls.Add(this.panel211);
            this.panel19.Controls.Add(this.panel210);
            this.panel19.Controls.Add(this.panel209);
            this.panel19.Controls.Add(this.panel208);
            this.panel19.Controls.Add(this.panel207);
            this.panel19.Controls.Add(this.panel206);
            this.panel19.Controls.Add(this.panel205);
            this.panel19.Controls.Add(this.panel204);
            this.panel19.Location = new System.Drawing.Point(2, 2);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(681, 580);
            this.panel19.TabIndex = 485;
            // 
            // panel220
            // 
            this.panel220.Controls.Add(this.panel221);
            this.panel220.Location = new System.Drawing.Point(6, 481);
            this.panel220.Name = "panel220";
            this.panel220.Size = new System.Drawing.Size(668, 93);
            this.panel220.TabIndex = 546;
            // 
            // panel221
            // 
            this.panel221.BackColor = System.Drawing.SystemColors.Control;
            this.panel221.Location = new System.Drawing.Point(2, 2);
            this.panel221.Name = "panel221";
            this.panel221.Size = new System.Drawing.Size(664, 89);
            this.panel221.TabIndex = 540;
            // 
            // panel211
            // 
            this.panel211.Controls.Add(this.panel21);
            this.panel211.Location = new System.Drawing.Point(347, 435);
            this.panel211.Name = "panel211";
            this.panel211.Size = new System.Drawing.Size(327, 40);
            this.panel211.TabIndex = 6;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel21.Controls.Add(this.label184);
            this.panel21.Controls.Add(this.label143);
            this.panel21.Controls.Add(this.numericUpDown102);
            this.panel21.Location = new System.Drawing.Point(2, 2);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(323, 36);
            this.panel21.TabIndex = 309;
            // 
            // label184
            // 
            this.label184.BackColor = System.Drawing.SystemColors.Control;
            this.label184.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label184.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label184.Location = new System.Drawing.Point(0, 0);
            this.label184.Name = "label184";
            this.label184.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label184.Size = new System.Drawing.Size(323, 17);
            this.label184.TabIndex = 239;
            this.label184.Text = "PSYCH BOMB / BOWSER CRUSH";
            this.label184.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label143.Location = new System.Drawing.Point(0, 19);
            this.label143.Name = "label143";
            this.label143.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label143.Size = new System.Drawing.Size(160, 17);
            this.label143.TabIndex = 303;
            this.label143.Text = "Maximum number of power-ups";
            // 
            // numericUpDown102
            // 
            this.numericUpDown102.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown102.Location = new System.Drawing.Point(161, 19);
            this.numericUpDown102.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown102.Name = "numericUpDown102";
            this.numericUpDown102.Size = new System.Drawing.Size(163, 17);
            this.numericUpDown102.TabIndex = 309;
            this.numericUpDown102.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown102.ValueChanged += new System.EventHandler(this.numericUpDown102_ValueChanged);
            // 
            // panel210
            // 
            this.panel210.Controls.Add(this.panel15);
            this.panel210.Location = new System.Drawing.Point(347, 353);
            this.panel210.Name = "panel210";
            this.panel210.Size = new System.Drawing.Size(327, 76);
            this.panel210.TabIndex = 6;
            // 
            // panel209
            // 
            this.panel209.Controls.Add(this.panel13);
            this.panel209.Location = new System.Drawing.Point(6, 417);
            this.panel209.Name = "panel209";
            this.panel209.Size = new System.Drawing.Size(335, 58);
            this.panel209.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel13.Controls.Add(this.label183);
            this.panel13.Controls.Add(this.panel20);
            this.panel13.Controls.Add(this.label142);
            this.panel13.Controls.Add(this.label141);
            this.panel13.Controls.Add(this.numericUpDown104);
            this.panel13.Controls.Add(this.numericUpDown103);
            this.panel13.Location = new System.Drawing.Point(2, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(331, 54);
            this.panel13.TabIndex = 302;
            // 
            // label183
            // 
            this.label183.BackColor = System.Drawing.SystemColors.Control;
            this.label183.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label183.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label183.Location = new System.Drawing.Point(0, 0);
            this.label183.Name = "label183";
            this.label183.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label183.Size = new System.Drawing.Size(163, 17);
            this.label183.TabIndex = 239;
            this.label183.Text = "PAD ROTATION SPELLS";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.padRotationSpellName);
            this.panel20.Location = new System.Drawing.Point(164, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(168, 17);
            this.panel20.TabIndex = 302;
            // 
            // padRotationSpellName
            // 
            this.padRotationSpellName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.padRotationSpellName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.padRotationSpellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.padRotationSpellName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.padRotationSpellName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.padRotationSpellName.Location = new System.Drawing.Point(-2, -2);
            this.padRotationSpellName.Name = "padRotationSpellName";
            this.padRotationSpellName.Size = new System.Drawing.Size(172, 22);
            this.padRotationSpellName.TabIndex = 353;
            this.padRotationSpellName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.padRotationSpellName_DrawItem);
            this.padRotationSpellName.SelectedIndexChanged += new System.EventHandler(this.padRotationSpellName_SelectedIndexChanged);
            // 
            // panel208
            // 
            this.panel208.Controls.Add(this.panel9);
            this.panel208.Location = new System.Drawing.Point(6, 353);
            this.panel208.Name = "panel208";
            this.panel208.Size = new System.Drawing.Size(335, 58);
            this.panel208.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel9.Controls.Add(this.label186);
            this.panel9.Controls.Add(this.panel16);
            this.panel9.Controls.Add(this.numericUpDown106);
            this.panel9.Controls.Add(this.numericUpDown105);
            this.panel9.Controls.Add(this.label145);
            this.panel9.Controls.Add(this.label146);
            this.panel9.Location = new System.Drawing.Point(2, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(331, 54);
            this.panel9.TabIndex = 298;
            // 
            // label186
            // 
            this.label186.BackColor = System.Drawing.SystemColors.Control;
            this.label186.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label186.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label186.Location = new System.Drawing.Point(0, 0);
            this.label186.Name = "label186";
            this.label186.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label186.Size = new System.Drawing.Size(163, 17);
            this.label186.TabIndex = 239;
            this.label186.Text = "FIREBALL SPELLS";
            this.label186.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.fireballName);
            this.panel16.Location = new System.Drawing.Point(164, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(168, 17);
            this.panel16.TabIndex = 299;
            // 
            // fireballName
            // 
            this.fireballName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fireballName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fireballName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fireballName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireballName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fireballName.Location = new System.Drawing.Point(-2, -2);
            this.fireballName.Name = "fireballName";
            this.fireballName.Size = new System.Drawing.Size(172, 22);
            this.fireballName.TabIndex = 353;
            this.fireballName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fireballName_DrawItem);
            this.fireballName.SelectedIndexChanged += new System.EventHandler(this.fireballName_SelectedIndexChanged);
            // 
            // numericUpDown106
            // 
            this.numericUpDown106.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown106.Location = new System.Drawing.Point(164, 19);
            this.numericUpDown106.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown106.Name = "numericUpDown106";
            this.numericUpDown106.Size = new System.Drawing.Size(168, 17);
            this.numericUpDown106.TabIndex = 300;
            this.numericUpDown106.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown106.ValueChanged += new System.EventHandler(this.numericUpDown106_ValueChanged);
            // 
            // numericUpDown105
            // 
            this.numericUpDown105.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown105.Location = new System.Drawing.Point(164, 37);
            this.numericUpDown105.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown105.Name = "numericUpDown105";
            this.numericUpDown105.Size = new System.Drawing.Size(168, 17);
            this.numericUpDown105.TabIndex = 301;
            this.numericUpDown105.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown105.ValueChanged += new System.EventHandler(this.numericUpDown105_ValueChanged);
            // 
            // label145
            // 
            this.label145.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label145.Location = new System.Drawing.Point(0, 37);
            this.label145.Name = "label145";
            this.label145.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label145.Size = new System.Drawing.Size(163, 17);
            this.label145.TabIndex = 302;
            this.label145.Text = "Maximum Number of Orbs";
            // 
            // label146
            // 
            this.label146.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label146.Location = new System.Drawing.Point(0, 19);
            this.label146.Name = "label146";
            this.label146.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label146.Size = new System.Drawing.Size(163, 17);
            this.label146.TabIndex = 301;
            this.label146.Text = "Frame Range Between Orbs";
            // 
            // panel207
            // 
            this.panel207.Controls.Add(this.panel129);
            this.panel207.Location = new System.Drawing.Point(6, 253);
            this.panel207.Name = "panel207";
            this.panel207.Size = new System.Drawing.Size(668, 94);
            this.panel207.TabIndex = 3;
            // 
            // panel129
            // 
            this.panel129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel129.Controls.Add(this.GenoChargeOverflow);
            this.panel129.Controls.Add(this.label167);
            this.panel129.Controls.Add(this.GenoLevel4Frame);
            this.panel129.Controls.Add(this.label151);
            this.panel129.Controls.Add(this.GenoLevel3Frame);
            this.panel129.Controls.Add(this.label154);
            this.panel129.Controls.Add(this.GenoLevel2Frame);
            this.panel129.Controls.Add(this.label152);
            this.panel129.Controls.Add(this.numericUpDown114);
            this.panel129.Controls.Add(this.numericUpDown113);
            this.panel129.Controls.Add(this.label153);
            this.panel129.Controls.Add(this.numericUpDown112);
            this.panel129.Controls.Add(this.numericUpDown111);
            this.panel129.Location = new System.Drawing.Point(2, 2);
            this.panel129.Name = "panel129";
            this.panel129.Size = new System.Drawing.Size(664, 90);
            this.panel129.TabIndex = 290;
            // 
            // GenoChargeOverflow
            // 
            this.GenoChargeOverflow.AutoSize = false;
            this.GenoChargeOverflow.BackColor = System.Drawing.SystemColors.Control;
            this.GenoChargeOverflow.Location = new System.Drawing.Point(164, 73);
            this.GenoChargeOverflow.Maximum = 128;
            this.GenoChargeOverflow.Name = "GenoChargeOverflow";
            this.GenoChargeOverflow.Size = new System.Drawing.Size(500, 17);
            this.GenoChargeOverflow.TabIndex = 297;
            this.GenoChargeOverflow.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GenoChargeOverflow.Scroll += new System.EventHandler(this.GenoChargeOverflow_Scroll);
            // 
            // label167
            // 
            this.label167.BackColor = System.Drawing.SystemColors.Control;
            this.label167.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label167.Location = new System.Drawing.Point(0, 0);
            this.label167.Name = "label167";
            this.label167.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label167.Size = new System.Drawing.Size(664, 17);
            this.label167.TabIndex = 318;
            this.label167.Text = "GENO\'S CHARGE SPELLS";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenoLevel4Frame
            // 
            this.GenoLevel4Frame.AutoSize = false;
            this.GenoLevel4Frame.BackColor = System.Drawing.SystemColors.Control;
            this.GenoLevel4Frame.Location = new System.Drawing.Point(164, 55);
            this.GenoLevel4Frame.Maximum = 128;
            this.GenoLevel4Frame.Name = "GenoLevel4Frame";
            this.GenoLevel4Frame.Size = new System.Drawing.Size(500, 17);
            this.GenoLevel4Frame.TabIndex = 295;
            this.GenoLevel4Frame.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GenoLevel4Frame.Scroll += new System.EventHandler(this.GenoLevel4Frame_Scroll);
            // 
            // GenoLevel3Frame
            // 
            this.GenoLevel3Frame.AutoSize = false;
            this.GenoLevel3Frame.BackColor = System.Drawing.SystemColors.Control;
            this.GenoLevel3Frame.Location = new System.Drawing.Point(164, 37);
            this.GenoLevel3Frame.Maximum = 128;
            this.GenoLevel3Frame.Name = "GenoLevel3Frame";
            this.GenoLevel3Frame.Size = new System.Drawing.Size(500, 17);
            this.GenoLevel3Frame.TabIndex = 293;
            this.GenoLevel3Frame.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GenoLevel3Frame.Scroll += new System.EventHandler(this.GenoLevel3Frame_Scroll);
            // 
            // GenoLevel2Frame
            // 
            this.GenoLevel2Frame.AutoSize = false;
            this.GenoLevel2Frame.BackColor = System.Drawing.SystemColors.Control;
            this.GenoLevel2Frame.Location = new System.Drawing.Point(164, 19);
            this.GenoLevel2Frame.Maximum = 128;
            this.GenoLevel2Frame.Name = "GenoLevel2Frame";
            this.GenoLevel2Frame.Size = new System.Drawing.Size(500, 17);
            this.GenoLevel2Frame.TabIndex = 291;
            this.GenoLevel2Frame.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GenoLevel2Frame.Scroll += new System.EventHandler(this.GenoLevel2Frame_Scroll);
            // 
            // panel206
            // 
            this.panel206.Controls.Add(this.panel14);
            this.panel206.Location = new System.Drawing.Point(6, 171);
            this.panel206.Name = "panel206";
            this.panel206.Size = new System.Drawing.Size(668, 76);
            this.panel206.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel14.Controls.Add(this.spell2Level1FrameEnd);
            this.panel14.Controls.Add(this.panel130);
            this.panel14.Controls.Add(this.spell2Level2FrameEnd);
            this.panel14.Controls.Add(this.label123);
            this.panel14.Controls.Add(this.spell2Level2FrameStart);
            this.panel14.Controls.Add(this.label147);
            this.panel14.Controls.Add(this.label148);
            this.panel14.Controls.Add(this.label149);
            this.panel14.Controls.Add(this.numericUpDown107);
            this.panel14.Controls.Add(this.numericUpDown108);
            this.panel14.Controls.Add(this.numericUpDown110);
            this.panel14.Location = new System.Drawing.Point(2, 2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(664, 72);
            this.panel14.TabIndex = 281;
            // 
            // spell2Level1FrameEnd
            // 
            this.spell2Level1FrameEnd.AutoSize = false;
            this.spell2Level1FrameEnd.BackColor = System.Drawing.SystemColors.Control;
            this.spell2Level1FrameEnd.Location = new System.Drawing.Point(164, 55);
            this.spell2Level1FrameEnd.Maximum = 128;
            this.spell2Level1FrameEnd.Name = "spell2Level1FrameEnd";
            this.spell2Level1FrameEnd.Size = new System.Drawing.Size(500, 17);
            this.spell2Level1FrameEnd.TabIndex = 289;
            this.spell2Level1FrameEnd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spell2Level1FrameEnd.Scroll += new System.EventHandler(this.spell2Level1FrameEnd_Scroll);
            // 
            // panel130
            // 
            this.panel130.Controls.Add(this.level2TimingSpellName);
            this.panel130.Location = new System.Drawing.Point(502, 0);
            this.panel130.Name = "panel130";
            this.panel130.Size = new System.Drawing.Size(163, 17);
            this.panel130.TabIndex = 281;
            // 
            // level2TimingSpellName
            // 
            this.level2TimingSpellName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.level2TimingSpellName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.level2TimingSpellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level2TimingSpellName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level2TimingSpellName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.level2TimingSpellName.Location = new System.Drawing.Point(-2, -2);
            this.level2TimingSpellName.Name = "level2TimingSpellName";
            this.level2TimingSpellName.Size = new System.Drawing.Size(167, 22);
            this.level2TimingSpellName.TabIndex = 353;
            this.level2TimingSpellName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.level2TimingSpellName_DrawItem);
            this.level2TimingSpellName.SelectedIndexChanged += new System.EventHandler(this.level2TimingSpellName_SelectedIndexChanged);
            // 
            // spell2Level2FrameEnd
            // 
            this.spell2Level2FrameEnd.AutoSize = false;
            this.spell2Level2FrameEnd.BackColor = System.Drawing.SystemColors.Control;
            this.spell2Level2FrameEnd.Location = new System.Drawing.Point(164, 37);
            this.spell2Level2FrameEnd.Maximum = 128;
            this.spell2Level2FrameEnd.Name = "spell2Level2FrameEnd";
            this.spell2Level2FrameEnd.Size = new System.Drawing.Size(500, 17);
            this.spell2Level2FrameEnd.TabIndex = 287;
            this.spell2Level2FrameEnd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spell2Level2FrameEnd.Scroll += new System.EventHandler(this.spell2Level2FrameEnd_Scroll);
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.SystemColors.Control;
            this.label123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label123.Location = new System.Drawing.Point(0, 0);
            this.label123.Name = "label123";
            this.label123.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label123.Size = new System.Drawing.Size(501, 17);
            this.label123.TabIndex = 318;
            this.label123.Text = "2-LEVEL TIMING SPELLS";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spell2Level2FrameStart
            // 
            this.spell2Level2FrameStart.AutoSize = false;
            this.spell2Level2FrameStart.BackColor = System.Drawing.SystemColors.Control;
            this.spell2Level2FrameStart.Location = new System.Drawing.Point(164, 19);
            this.spell2Level2FrameStart.Maximum = 128;
            this.spell2Level2FrameStart.Name = "spell2Level2FrameStart";
            this.spell2Level2FrameStart.Size = new System.Drawing.Size(500, 17);
            this.spell2Level2FrameStart.TabIndex = 285;
            this.spell2Level2FrameStart.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spell2Level2FrameStart.Scroll += new System.EventHandler(this.spell2Level2FrameStart_Scroll);
            // 
            // panel205
            // 
            this.panel205.Controls.Add(this.panel128);
            this.panel205.Location = new System.Drawing.Point(6, 125);
            this.panel205.Name = "panel205";
            this.panel205.Size = new System.Drawing.Size(668, 40);
            this.panel205.TabIndex = 1;
            // 
            // panel128
            // 
            this.panel128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel128.Controls.Add(this.panel131);
            this.panel128.Controls.Add(this.spell1TimingFrameSpan);
            this.panel128.Controls.Add(this.label197);
            this.panel128.Controls.Add(this.numericUpDown100);
            this.panel128.Controls.Add(this.label144);
            this.panel128.Location = new System.Drawing.Point(2, 2);
            this.panel128.Name = "panel128";
            this.panel128.Size = new System.Drawing.Size(664, 36);
            this.panel128.TabIndex = 276;
            // 
            // panel131
            // 
            this.panel131.Controls.Add(this.level1TimingSpellName);
            this.panel131.Location = new System.Drawing.Point(502, 0);
            this.panel131.Name = "panel131";
            this.panel131.Size = new System.Drawing.Size(163, 17);
            this.panel131.TabIndex = 276;
            // 
            // level1TimingSpellName
            // 
            this.level1TimingSpellName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.level1TimingSpellName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.level1TimingSpellName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level1TimingSpellName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level1TimingSpellName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.level1TimingSpellName.Location = new System.Drawing.Point(-2, -2);
            this.level1TimingSpellName.Name = "level1TimingSpellName";
            this.level1TimingSpellName.Size = new System.Drawing.Size(167, 22);
            this.level1TimingSpellName.TabIndex = 353;
            this.level1TimingSpellName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.level1TimingSpellName_DrawItem);
            this.level1TimingSpellName.SelectedIndexChanged += new System.EventHandler(this.level1TimingSpellName_SelectedIndexChanged);
            // 
            // spell1TimingFrameSpan
            // 
            this.spell1TimingFrameSpan.AutoSize = false;
            this.spell1TimingFrameSpan.BackColor = System.Drawing.SystemColors.Control;
            this.spell1TimingFrameSpan.Location = new System.Drawing.Point(164, 19);
            this.spell1TimingFrameSpan.Maximum = 128;
            this.spell1TimingFrameSpan.Name = "spell1TimingFrameSpan";
            this.spell1TimingFrameSpan.Size = new System.Drawing.Size(500, 17);
            this.spell1TimingFrameSpan.TabIndex = 280;
            this.spell1TimingFrameSpan.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spell1TimingFrameSpan.Scroll += new System.EventHandler(this.spell1TimingFrameSpan_Scroll);
            // 
            // panel204
            // 
            this.panel204.Controls.Add(this.label208);
            this.panel204.Controls.Add(this.panel50);
            this.panel204.Location = new System.Drawing.Point(6, 6);
            this.panel204.Name = "panel204";
            this.panel204.Size = new System.Drawing.Size(668, 113);
            this.panel204.TabIndex = 0;
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel50.Controls.Add(this.lvl1TimingEnd);
            this.panel50.Controls.Add(this.lvl2TimingStart);
            this.panel50.Controls.Add(this.lvl2TimingEnd);
            this.panel50.Controls.Add(this.panel132);
            this.panel50.Controls.Add(this.lvl1TimingStart);
            this.panel50.Controls.Add(this.label111);
            this.panel50.Controls.Add(this.numericUpDown6);
            this.panel50.Controls.Add(this.label112);
            this.panel50.Controls.Add(this.label157);
            this.panel50.Controls.Add(this.label158);
            this.panel50.Controls.Add(this.label159);
            this.panel50.Controls.Add(this.numericUpDown117);
            this.panel50.Controls.Add(this.numericUpDown118);
            this.panel50.Controls.Add(this.label160);
            this.panel50.Controls.Add(this.numericUpDown119);
            this.panel50.Controls.Add(this.numericUpDown120);
            this.panel50.Controls.Add(this.panel127);
            this.panel50.Location = new System.Drawing.Point(2, 21);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(664, 90);
            this.panel50.TabIndex = 268;
            // 
            // lvl1TimingEnd
            // 
            this.lvl1TimingEnd.AutoSize = false;
            this.lvl1TimingEnd.BackColor = System.Drawing.SystemColors.Control;
            this.lvl1TimingEnd.Location = new System.Drawing.Point(164, 73);
            this.lvl1TimingEnd.Maximum = 128;
            this.lvl1TimingEnd.Name = "lvl1TimingEnd";
            this.lvl1TimingEnd.Size = new System.Drawing.Size(500, 17);
            this.lvl1TimingEnd.TabIndex = 275;
            this.lvl1TimingEnd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lvl1TimingEnd.Scroll += new System.EventHandler(this.lvl1TimingEnd_Scroll);
            // 
            // lvl2TimingStart
            // 
            this.lvl2TimingStart.AutoSize = false;
            this.lvl2TimingStart.BackColor = System.Drawing.SystemColors.Control;
            this.lvl2TimingStart.Location = new System.Drawing.Point(164, 37);
            this.lvl2TimingStart.Maximum = 128;
            this.lvl2TimingStart.Name = "lvl2TimingStart";
            this.lvl2TimingStart.Size = new System.Drawing.Size(500, 17);
            this.lvl2TimingStart.TabIndex = 271;
            this.lvl2TimingStart.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lvl2TimingStart.Scroll += new System.EventHandler(this.lvl2TimingStart_Scroll);
            // 
            // lvl2TimingEnd
            // 
            this.lvl2TimingEnd.AutoSize = false;
            this.lvl2TimingEnd.BackColor = System.Drawing.SystemColors.Control;
            this.lvl2TimingEnd.Location = new System.Drawing.Point(164, 55);
            this.lvl2TimingEnd.Maximum = 128;
            this.lvl2TimingEnd.Name = "lvl2TimingEnd";
            this.lvl2TimingEnd.Size = new System.Drawing.Size(500, 17);
            this.lvl2TimingEnd.TabIndex = 273;
            this.lvl2TimingEnd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lvl2TimingEnd.Scroll += new System.EventHandler(this.lvl2TimingEnd_Scroll);
            // 
            // panel132
            // 
            this.panel132.Controls.Add(this.weaponName);
            this.panel132.Location = new System.Drawing.Point(274, 0);
            this.panel132.Name = "panel132";
            this.panel132.Size = new System.Drawing.Size(163, 17);
            this.panel132.TabIndex = 1;
            // 
            // weaponName
            // 
            this.weaponName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.weaponName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.weaponName.DropDownHeight = 522;
            this.weaponName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weaponName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weaponName.ForeColor = System.Drawing.SystemColors.Control;
            this.weaponName.IntegralHeight = false;
            this.weaponName.Location = new System.Drawing.Point(-2, -2);
            this.weaponName.Name = "weaponName";
            this.weaponName.Size = new System.Drawing.Size(167, 22);
            this.weaponName.TabIndex = 353;
            this.weaponName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.weaponName_DrawItem);
            this.weaponName.SelectedIndexChanged += new System.EventHandler(this.weaponName_SelectedIndexChanged);
            // 
            // lvl1TimingStart
            // 
            this.lvl1TimingStart.AutoSize = false;
            this.lvl1TimingStart.BackColor = System.Drawing.SystemColors.Control;
            this.lvl1TimingStart.Location = new System.Drawing.Point(164, 19);
            this.lvl1TimingStart.Maximum = 128;
            this.lvl1TimingStart.Name = "lvl1TimingStart";
            this.lvl1TimingStart.Size = new System.Drawing.Size(500, 17);
            this.lvl1TimingStart.TabIndex = 269;
            this.lvl1TimingStart.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lvl1TimingStart.Scroll += new System.EventHandler(this.lvl1TimingStart_Scroll);
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.SystemColors.Control;
            this.label111.Location = new System.Drawing.Point(164, 0);
            this.label111.Name = "label111";
            this.label111.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label111.Size = new System.Drawing.Size(109, 17);
            this.label111.TabIndex = 318;
            this.label111.Text = "WEAPON";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.numericUpDown6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown6.ForeColor = System.Drawing.SystemColors.Control;
            this.numericUpDown6.Location = new System.Drawing.Point(583, 0);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(82, 17);
            this.numericUpDown6.TabIndex = 267;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.SystemColors.Control;
            this.label112.Location = new System.Drawing.Point(438, 0);
            this.label112.Name = "label112";
            this.label112.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label112.Size = new System.Drawing.Size(144, 17);
            this.label112.TabIndex = 262;
            this.label112.Text = "WEAPON #";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel127
            // 
            this.panel127.Controls.Add(this.weaponOrDefense);
            this.panel127.Location = new System.Drawing.Point(0, 0);
            this.panel127.Name = "panel127";
            this.panel127.Size = new System.Drawing.Size(163, 17);
            this.panel127.TabIndex = 0;
            // 
            // weaponOrDefense
            // 
            this.weaponOrDefense.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.weaponOrDefense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weaponOrDefense.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weaponOrDefense.ForeColor = System.Drawing.SystemColors.Control;
            this.weaponOrDefense.Items.AddRange(new object[] {
            "WEAPON",
            "DEFENSE"});
            this.weaponOrDefense.Location = new System.Drawing.Point(-2, -2);
            this.weaponOrDefense.Name = "weaponOrDefense";
            this.weaponOrDefense.Size = new System.Drawing.Size(167, 21);
            this.weaponOrDefense.TabIndex = 353;
            this.weaponOrDefense.SelectedIndexChanged += new System.EventHandler(this.weaponOrDefense_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(26, 166);
            this.tabControl1.Location = new System.Drawing.Point(8, 30);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 592);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Controls.Add(this.panel33);
            this.tabPage1.Location = new System.Drawing.Point(175, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(685, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MONSTERS";
            // 
            // panel33
            // 
            this.panel33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel33.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel33.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel33.Controls.Add(this.panel214);
            this.panel33.Controls.Add(this.panel212);
            this.panel33.Controls.Add(this.panel141);
            this.panel33.Controls.Add(this.panel140);
            this.panel33.Controls.Add(this.panel138);
            this.panel33.Controls.Add(this.panel137);
            this.panel33.Controls.Add(this.panel136);
            this.panel33.Controls.Add(this.panel135);
            this.panel33.Controls.Add(this.panel134);
            this.panel33.Controls.Add(this.panel27);
            this.panel33.Controls.Add(this.panel202);
            this.panel33.Controls.Add(this.panel23);
            this.panel33.Controls.Add(this.panel25);
            this.panel33.Controls.Add(this.panel24);
            this.panel33.Controls.Add(this.panel7);
            this.panel33.Location = new System.Drawing.Point(2, 2);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(681, 580);
            this.panel33.TabIndex = 513;
            // 
            // panel214
            // 
            this.panel214.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel214.Controls.Add(this.panel215);
            this.panel214.Location = new System.Drawing.Point(6, 532);
            this.panel214.Name = "panel214";
            this.panel214.Size = new System.Drawing.Size(198, 42);
            this.panel214.TabIndex = 541;
            // 
            // panel215
            // 
            this.panel215.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel215.BackColor = System.Drawing.SystemColors.Control;
            this.panel215.Location = new System.Drawing.Point(2, 2);
            this.panel215.Name = "panel215";
            this.panel215.Size = new System.Drawing.Size(194, 38);
            this.panel215.TabIndex = 540;
            // 
            // panel212
            // 
            this.panel212.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel212.Controls.Add(this.panel213);
            this.panel212.Location = new System.Drawing.Point(210, 489);
            this.panel212.Name = "panel212";
            this.panel212.Size = new System.Drawing.Size(198, 85);
            this.panel212.TabIndex = 540;
            // 
            // panel213
            // 
            this.panel213.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel213.BackColor = System.Drawing.SystemColors.Control;
            this.panel213.Location = new System.Drawing.Point(2, 2);
            this.panel213.Name = "panel213";
            this.panel213.Size = new System.Drawing.Size(194, 81);
            this.panel213.TabIndex = 540;
            // 
            // panel141
            // 
            this.panel141.Controls.Add(this.label9);
            this.panel141.Controls.Add(this.buttonPreviousFrame);
            this.panel141.Controls.Add(this.buttonNextFrame);
            this.panel141.Controls.Add(this.pictureBoxMonster);
            this.panel141.Location = new System.Drawing.Point(414, 6);
            this.panel141.Name = "panel141";
            this.panel141.Size = new System.Drawing.Size(260, 279);
            this.panel141.TabIndex = 9;
            // 
            // panel140
            // 
            this.panel140.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel140.Controls.Add(this.panel139);
            this.panel140.Location = new System.Drawing.Point(414, 478);
            this.panel140.Name = "panel140";
            this.panel140.Size = new System.Drawing.Size(260, 96);
            this.panel140.TabIndex = 14;
            // 
            // panel139
            // 
            this.panel139.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel139.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel139.Controls.Add(this.label209);
            this.panel139.Controls.Add(this.panel41);
            this.panel139.Location = new System.Drawing.Point(2, 2);
            this.panel139.Name = "panel139";
            this.panel139.Size = new System.Drawing.Size(256, 92);
            this.panel139.TabIndex = 500;
            // 
            // panel138
            // 
            this.panel138.Controls.Add(this.panel133);
            this.panel138.Location = new System.Drawing.Point(414, 336);
            this.panel138.Name = "panel138";
            this.panel138.Size = new System.Drawing.Size(260, 136);
            this.panel138.TabIndex = 13;
            // 
            // panel133
            // 
            this.panel133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel133.Controls.Add(this.label32);
            this.panel133.Controls.Add(this.label126);
            this.panel133.Controls.Add(this.button1);
            this.panel133.Controls.Add(this.button2);
            this.panel133.Controls.Add(this.pictureBoxPsychopath);
            this.panel133.Controls.Add(this.panel42);
            this.panel133.Controls.Add(this.listBox3);
            this.panel133.Location = new System.Drawing.Point(2, 2);
            this.panel133.Name = "panel133";
            this.panel133.Size = new System.Drawing.Size(256, 132);
            this.panel133.TabIndex = 494;
            // 
            // listBox3
            // 
            this.listBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Items.AddRange(new object[] {
            "End string",
            "New line",
            "Pause (A)",
            "Delay (A)",
            "Delay"});
            this.listBox3.Location = new System.Drawing.Point(180, 67);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(76, 65);
            this.listBox3.TabIndex = 36;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.listBox3.Click += new System.EventHandler(this.listBox3_Click);
            // 
            // panel137
            // 
            this.panel137.Controls.Add(this.panel53);
            this.panel137.Location = new System.Drawing.Point(210, 333);
            this.panel137.Name = "panel137";
            this.panel137.Size = new System.Drawing.Size(198, 87);
            this.panel137.TabIndex = 7;
            // 
            // panel53
            // 
            this.panel53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel53.Controls.Add(this.label87);
            this.panel53.Controls.Add(this.CheckboxMonsterProp);
            this.panel53.Location = new System.Drawing.Point(2, 2);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(194, 83);
            this.panel53.TabIndex = 493;
            // 
            // panel136
            // 
            this.panel136.Controls.Add(this.panel31);
            this.panel136.Location = new System.Drawing.Point(210, 147);
            this.panel136.Name = "panel136";
            this.panel136.Size = new System.Drawing.Size(198, 87);
            this.panel136.TabIndex = 5;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel31.Controls.Add(this.label96);
            this.panel31.Controls.Add(this.CheckboxMonsterElemWeak);
            this.panel31.Location = new System.Drawing.Point(2, 2);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(194, 83);
            this.panel31.TabIndex = 490;
            // 
            // panel135
            // 
            this.panel135.Controls.Add(this.panel35);
            this.panel135.Location = new System.Drawing.Point(210, 6);
            this.panel135.Name = "panel135";
            this.panel135.Size = new System.Drawing.Size(198, 135);
            this.panel135.TabIndex = 4;
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel35.Controls.Add(this.label182);
            this.panel35.Controls.Add(this.CheckboxMonsterEfecNull);
            this.panel35.Location = new System.Drawing.Point(2, 2);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(194, 131);
            this.panel35.TabIndex = 492;
            // 
            // panel134
            // 
            this.panel134.Controls.Add(this.panel32);
            this.panel134.Location = new System.Drawing.Point(210, 240);
            this.panel134.Name = "panel134";
            this.panel134.Size = new System.Drawing.Size(198, 87);
            this.panel134.TabIndex = 6;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel32.Controls.Add(this.label169);
            this.panel32.Controls.Add(this.CheckboxMonsterElemNull);
            this.panel32.Location = new System.Drawing.Point(2, 2);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(194, 83);
            this.panel32.TabIndex = 491;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel27.Controls.Add(this.panel26);
            this.panel27.Location = new System.Drawing.Point(6, 6);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(198, 59);
            this.panel27.TabIndex = 0;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.panel63);
            this.panel26.Controls.Add(this.LabelMonster);
            this.panel26.Controls.Add(this.MonsterNumber);
            this.panel26.Controls.Add(this.LabelMonsterName);
            this.panel26.Controls.Add(this.panel64);
            this.panel26.Location = new System.Drawing.Point(2, 2);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(195, 55);
            this.panel26.TabIndex = 488;
            // 
            // panel202
            // 
            this.panel202.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel202.Controls.Add(this.panel222);
            this.panel202.Location = new System.Drawing.Point(414, 291);
            this.panel202.Name = "panel202";
            this.panel202.Size = new System.Drawing.Size(260, 39);
            this.panel202.TabIndex = 12;
            // 
            // panel222
            // 
            this.panel222.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel222.Controls.Add(this.monsterTargetArrowY);
            this.panel222.Controls.Add(this.monsterTargetArrowX);
            this.panel222.Controls.Add(this.label110);
            this.panel222.Controls.Add(this.label119);
            this.panel222.Controls.Add(this.label187);
            this.panel222.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel222.Location = new System.Drawing.Point(2, 2);
            this.panel222.Name = "panel222";
            this.panel222.Size = new System.Drawing.Size(256, 35);
            this.panel222.TabIndex = 18;
            // 
            // monsterTargetArrowY
            // 
            this.monsterTargetArrowY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.monsterTargetArrowY.Location = new System.Drawing.Point(187, 18);
            this.monsterTargetArrowY.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.monsterTargetArrowY.Name = "monsterTargetArrowY";
            this.monsterTargetArrowY.Size = new System.Drawing.Size(70, 17);
            this.monsterTargetArrowY.TabIndex = 20;
            this.monsterTargetArrowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.monsterTargetArrowY.ValueChanged += new System.EventHandler(this.monsterTargetArrowY_ValueChanged);
            // 
            // monsterTargetArrowX
            // 
            this.monsterTargetArrowX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.monsterTargetArrowX.Location = new System.Drawing.Point(58, 18);
            this.monsterTargetArrowX.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.monsterTargetArrowX.Name = "monsterTargetArrowX";
            this.monsterTargetArrowX.Size = new System.Drawing.Size(70, 17);
            this.monsterTargetArrowX.TabIndex = 19;
            this.monsterTargetArrowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.monsterTargetArrowX.ValueChanged += new System.EventHandler(this.monsterTargetArrowX_ValueChanged);
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label110.Location = new System.Drawing.Point(129, 18);
            this.label110.Name = "label110";
            this.label110.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label110.Size = new System.Drawing.Size(57, 17);
            this.label110.TabIndex = 391;
            this.label110.Text = "Y shift";
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label119.Location = new System.Drawing.Point(0, 18);
            this.label119.Name = "label119";
            this.label119.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label119.Size = new System.Drawing.Size(57, 17);
            this.label119.TabIndex = 391;
            this.label119.Text = "X shift";
            // 
            // label187
            // 
            this.label187.BackColor = System.Drawing.SystemColors.Control;
            this.label187.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label187.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label187.Location = new System.Drawing.Point(0, -1);
            this.label187.Name = "label187";
            this.label187.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label187.Size = new System.Drawing.Size(256, 17);
            this.label187.TabIndex = 385;
            this.label187.Text = "TARGET ARROW...";
            this.label187.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel23.Controls.Add(this.panel55);
            this.panel23.Location = new System.Drawing.Point(210, 426);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(198, 57);
            this.panel23.TabIndex = 8;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel25.Controls.Add(this.panel29);
            this.panel25.Location = new System.Drawing.Point(6, 71);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(198, 184);
            this.panel25.TabIndex = 1;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel24.Controls.Add(this.panel54);
            this.panel24.Location = new System.Drawing.Point(6, 261);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(198, 111);
            this.panel24.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel7.Controls.Add(this.panel56);
            this.panel7.Location = new System.Drawing.Point(6, 378);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 148);
            this.panel7.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Controls.Add(this.panel142);
            this.tabPage2.Location = new System.Drawing.Point(175, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FORMATIONS";
            // 
            // panel142
            // 
            this.panel142.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel142.BackgroundImage = global::SMRPGED.Properties.Resources._bg;
            this.panel142.Controls.Add(this.panel216);
            this.panel142.Controls.Add(this.panel150);
            this.panel142.Controls.Add(this.panel148);
            this.panel142.Controls.Add(this.panel147);
            this.panel142.Controls.Add(this.panel145);
            this.panel142.Controls.Add(this.panel143);
            this.panel142.Controls.Add(this.panel12);
            this.panel142.Controls.Add(this.panel83);
            this.panel142.Controls.Add(this.panelSearchFormationNames);
            this.panel142.Controls.Add(this.panelSearchFormationPacks);
            this.panel142.Location = new System.Drawing.Point(2, 2);
            this.panel142.Name = "panel142";
            this.panel142.Size = new System.Drawing.Size(681, 580);
            this.panel142.TabIndex = 541;
            // 
            // panel150
            // 
            this.panel150.Controls.Add(this.panel149);
            this.panel150.Location = new System.Drawing.Point(6, 354);
            this.panel150.Name = "panel150";
            this.panel150.Size = new System.Drawing.Size(402, 190);
            this.panel150.TabIndex = 5;
            // 
            // panel149
            // 
            this.panel149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel149.Controls.Add(this.label179);
            this.panel149.Controls.Add(this.label7);
            this.panel149.Controls.Add(this.packFormation3);
            this.panel149.Controls.Add(this.panel81);
            this.panel149.Controls.Add(this.label41);
            this.panel149.Controls.Add(this.label42);
            this.panel149.Controls.Add(this.label43);
            this.panel149.Controls.Add(this.packFormation1);
            this.panel149.Controls.Add(this.packFormation2);
            this.panel149.Controls.Add(this.packFormationButton1);
            this.panel149.Controls.Add(this.panel5);
            this.panel149.Controls.Add(this.packFormationButton2);
            this.panel149.Controls.Add(this.panel4);
            this.panel149.Controls.Add(this.packFormationButton3);
            this.panel149.Controls.Add(this.panel3);
            this.panel149.Location = new System.Drawing.Point(2, 2);
            this.panel149.Name = "panel149";
            this.panel149.Size = new System.Drawing.Size(398, 186);
            this.panel149.TabIndex = 547;
            // 
            // panel148
            // 
            this.panel148.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel148.Controls.Add(this.label19);
            this.panel148.Controls.Add(this.panel34);
            this.panel148.Location = new System.Drawing.Point(414, 272);
            this.panel148.Name = "panel148";
            this.panel148.Size = new System.Drawing.Size(260, 302);
            this.panel148.TabIndex = 6;
            // 
            // panel147
            // 
            this.panel147.Controls.Add(this.panel146);
            this.panel147.Location = new System.Drawing.Point(414, 6);
            this.panel147.Name = "panel147";
            this.panel147.Size = new System.Drawing.Size(260, 260);
            this.panel147.TabIndex = 3;
            // 
            // panel146
            // 
            this.panel146.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel146.Controls.Add(this.label5);
            this.panel146.Controls.Add(this.panel39);
            this.panel146.Controls.Add(this.label20);
            this.panel146.Controls.Add(this.panel10);
            this.panel146.Location = new System.Drawing.Point(2, 2);
            this.panel146.Name = "panel146";
            this.panel146.Size = new System.Drawing.Size(256, 256);
            this.panel146.TabIndex = 544;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Window;
            this.panel10.Controls.Add(this.pictureBoxFormation);
            this.panel10.Location = new System.Drawing.Point(0, 19);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(256, 218);
            this.panel10.TabIndex = 539;
            // 
            // panel145
            // 
            this.panel145.Controls.Add(this.panel144);
            this.panel145.Location = new System.Drawing.Point(6, 6);
            this.panel145.Name = "panel145";
            this.panel145.Size = new System.Drawing.Size(402, 21);
            this.panel145.TabIndex = 0;
            // 
            // panel144
            // 
            this.panel144.Controls.Add(this.searchFormationNames);
            this.panel144.Controls.Add(this.panel37);
            this.panel144.Controls.Add(this.formationNum);
            this.panel144.Controls.Add(this.label27);
            this.panel144.Location = new System.Drawing.Point(2, 2);
            this.panel144.Name = "panel144";
            this.panel144.Size = new System.Drawing.Size(398, 17);
            this.panel144.TabIndex = 542;
            // 
            // searchFormationNames
            // 
            this.searchFormationNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchFormationNames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchFormationNames.BackgroundImage = global::SMRPGED.Properties.Resources.search;
            this.searchFormationNames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchFormationNames.FlatAppearance.BorderSize = 0;
            this.searchFormationNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchFormationNames.Location = new System.Drawing.Point(0, 0);
            this.searchFormationNames.Name = "searchFormationNames";
            this.searchFormationNames.Size = new System.Drawing.Size(19, 17);
            this.searchFormationNames.TabIndex = 42;
            this.toolTip1.SetToolTip(this.searchFormationNames, "Search formations...");
            this.searchFormationNames.UseCompatibleTextRendering = true;
            this.searchFormationNames.UseVisualStyleBackColor = false;
            this.searchFormationNames.Click += new System.EventHandler(this.searchFormationNames_Click);
            // 
            // panel143
            // 
            this.panel143.Controls.Add(this.panel52);
            this.panel143.Location = new System.Drawing.Point(6, 224);
            this.panel143.Name = "panel143";
            this.panel143.Size = new System.Drawing.Size(402, 78);
            this.panel143.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel36);
            this.panel12.Location = new System.Drawing.Point(6, 33);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(402, 185);
            this.panel12.TabIndex = 1;
            // 
            // panelSearchFormationPacks
            // 
            this.panelSearchFormationPacks.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchFormationPacks.Controls.Add(this.treeViewPackNames);
            this.panelSearchFormationPacks.Controls.Add(this.panel203);
            this.panelSearchFormationPacks.Location = new System.Drawing.Point(6, 6);
            this.panelSearchFormationPacks.Name = "panelSearchFormationPacks";
            this.panelSearchFormationPacks.Size = new System.Drawing.Size(668, 303);
            this.panelSearchFormationPacks.TabIndex = 552;
            this.panelSearchFormationPacks.Visible = false;
            // 
            // treeViewPackNames
            // 
            this.treeViewPackNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewPackNames.FullRowSelect = true;
            this.treeViewPackNames.HotTracking = true;
            this.treeViewPackNames.Location = new System.Drawing.Point(2, 21);
            this.treeViewPackNames.Name = "treeViewPackNames";
            this.treeViewPackNames.ShowLines = false;
            this.treeViewPackNames.ShowPlusMinus = false;
            this.treeViewPackNames.ShowRootLines = false;
            this.treeViewPackNames.Size = new System.Drawing.Size(664, 280);
            this.treeViewPackNames.TabIndex = 194;
            this.treeViewPackNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPackNames_AfterSelect);
            this.treeViewPackNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewPackNames_KeyDown);
            // 
            // panel203
            // 
            this.panel203.BackColor = System.Drawing.SystemColors.Window;
            this.panel203.Controls.Add(this.packNameTextBox);
            this.panel203.Location = new System.Drawing.Point(2, 2);
            this.panel203.Name = "panel203";
            this.panel203.Size = new System.Drawing.Size(664, 17);
            this.panel203.TabIndex = 193;
            // 
            // packNameTextBox
            // 
            this.packNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.packNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packNameTextBox.Location = new System.Drawing.Point(4, 2);
            this.packNameTextBox.MaxLength = 128;
            this.packNameTextBox.Name = "packNameTextBox";
            this.packNameTextBox.Size = new System.Drawing.Size(658, 14);
            this.packNameTextBox.TabIndex = 4;
            this.packNameTextBox.TextChanged += new System.EventHandler(this.packNameTextBox_TextChanged);
            this.packNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.packNameTextBox_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Location = new System.Drawing.Point(175, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(685, 584);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SPELLS / ATTACKS";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Location = new System.Drawing.Point(175, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(685, 584);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ITEMS / SHOPS";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage5.Controls.Add(this.panel46);
            this.tabPage5.Location = new System.Drawing.Point(175, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(685, 584);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "LEVEL-UPS / START STATS";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage6.Controls.Add(this.panel19);
            this.tabPage6.Location = new System.Drawing.Point(175, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(685, 584);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "WEAPON / SPELL TIMING";
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // labelToolTip
            // 
            this.labelToolTip.AutoSize = true;
            this.labelToolTip.BackColor = System.Drawing.SystemColors.Info;
            this.labelToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelToolTip.Location = new System.Drawing.Point(183, 0);
            this.labelToolTip.Name = "labelToolTip";
            this.labelToolTip.Size = new System.Drawing.Size(2, 15);
            this.labelToolTip.TabIndex = 0;
            this.labelToolTip.Visible = false;
            // 
            // formationBattleEvent
            // 
            this.formationBattleEvent.BackColor = System.Drawing.SystemColors.Window;
            this.formationBattleEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formationBattleEvent.Location = new System.Drawing.Point(77, 19);
            this.formationBattleEvent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.formationBattleEvent.Name = "formationBattleEvent";
            this.formationBattleEvent.Size = new System.Drawing.Size(78, 17);
            this.formationBattleEvent.TabIndex = 81;
            this.formationBattleEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.formationBattleEvent.ValueChanged += new System.EventHandler(this.formationBattleEvent_ValueChanged);
            // 
            // label140
            // 
            this.label140.BackColor = System.Drawing.SystemColors.Control;
            this.label140.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label140.Location = new System.Drawing.Point(0, 38);
            this.label140.Name = "label140";
            this.label140.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label140.Size = new System.Drawing.Size(398, 17);
            this.label140.TabIndex = 288;
            this.label140.Text = "FORMATION MUSIC";
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label150.Location = new System.Drawing.Point(156, 57);
            this.label150.Name = "label150";
            this.label150.Padding = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.label150.Size = new System.Drawing.Size(76, 17);
            this.label150.TabIndex = 500;
            this.label150.Text = "Music Track";
            // 
            // panel74
            // 
            this.panel74.BackColor = System.Drawing.SystemColors.Control;
            this.panel74.Controls.Add(this.musicTrack);
            this.panel74.Location = new System.Drawing.Point(233, 57);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(166, 17);
            this.panel74.TabIndex = 80;
            // 
            // musicTrack
            // 
            this.musicTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.musicTrack.BackColor = System.Drawing.SystemColors.Window;
            this.musicTrack.DropDownHeight = 262;
            this.musicTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.musicTrack.DropDownWidth = 250;
            this.musicTrack.IntegralHeight = false;
            this.musicTrack.Items.AddRange(new object[] {
            "[00]  {CURRENT}",
            "[01]  Dodo\'s Coming",
            "[02]  Mushroom Kingdom",
            "[03]  Fight Against Stronger Monster",
            "[04]  Yo\'ster Island",
            "[05]  Seaside Town",
            "[06]  Fight Against Monsters",
            "[07]  Pipe Vault",
            "[08]  Invincible Star",
            "[09]  Victory",
            "[0A]  In The Flower Garden",
            "[0B]  Bowser\'s Castle (1st time)",
            "[0C]  Fight Against Bowser",
            "[0D]  Road Is Full Of Dangers",
            "[0E]  Mario\'s Pad",
            "[0F]  Here\'s Some Weapons",
            "[10]  Let\'s Race",
            "[11]  Tadpole Pond",
            "[12]  Rose Town",
            "[13]  Race Training",
            "[14]  Shock!",
            "[15]  Sad Song",
            "[16]  Midas River",
            "[17]  Got A Star Piece (part 1)",
            "[18]  Got A Star Piece (part 2)",
            "[19]  Fight Against An Armed Boss",
            "[1A]  Forest Maze",
            "[1B]  Dungeon Is Full Of Monsters",
            "[1C]  Let\'s Play Geno",
            "[1D]  Start Slot Menu",
            "[1E]  Long Long Ago",
            "[1F]  Booster\'s Tower",
            "[20]  And My Name\'s Booster",
            "[21]  Moleville",
            "[22]  Star Hill",
            "[23]  Mountain Railroad",
            "[24]  Explanation",
            "[25]  Booster Hill (start)",
            "[26]  Booster Hill",
            "[27]  Marrymore",
            "[28]  New Partner",
            "[29]  Sunken Ship",
            "[2A]  Still The Road Is Full Of Monsters",
            "[2B]  {SILENCE}",
            "[2C]  Sea",
            "[2D]  Heart Beating A Little Faster (part 1)",
            "[2E]  Heart Beating A Little Faster (part 2)",
            "[2F]  Grate Guy\'s Casino",
            "[30]  Geno Awakens",
            "[31]  Celebrational",
            "[32]  Nimbus Land",
            "[33]  Monstro Town",
            "[34]  Toadofsky",
            "[35]  {SILENCE}",
            "[36]  Happy Adventure, Delighful Adventure",
            "[37]  World Map",
            "[38]  Factory",
            "[39]  Sword Crashes And Stars Scatter",
            "[3A]  Conversation With Culex",
            "[3B]  Fight Against Culex",
            "[3C]  Victory Against Culex",
            "[3D]  Valentina",
            "[3E]  Barrel Volcano",
            "[3F]  Axem Rangers Drop In",
            "[40]  The End",
            "[41]  Gate",
            "[42]  Bowser\'s Castle (2nd time)",
            "[43]  Weapons Factory",
            "[44]  Fight Against Smithy 1",
            "[45]  Fight Against Smithy 2",
            "[46]  Ending Part 1",
            "[47]  Ending Part 2",
            "[48]  Ending Part 3",
            "[49]  Ending Part 4",
            "[4A]  {SILENCE}",
            "[4B]  {SILENCE}",
            "[4C]  {SILENCE}",
            "[4D]  {SILENCE}",
            "[4E]  {SILENCE}",
            "[4F]  {SILENCE}"});
            this.musicTrack.Location = new System.Drawing.Point(-2, -2);
            this.musicTrack.Name = "musicTrack";
            this.musicTrack.Size = new System.Drawing.Size(170, 21);
            this.musicTrack.TabIndex = 80;
            this.musicTrack.SelectedIndexChanged += new System.EventHandler(this.musicTrack_SelectedIndexChanged);
            // 
            // panel216
            // 
            this.panel216.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel216.Controls.Add(this.panel217);
            this.panel216.Location = new System.Drawing.Point(6, 550);
            this.panel216.Name = "panel216";
            this.panel216.Size = new System.Drawing.Size(402, 24);
            this.panel216.TabIndex = 553;
            // 
            // panel217
            // 
            this.panel217.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel217.BackColor = System.Drawing.SystemColors.Control;
            this.panel217.Location = new System.Drawing.Point(2, 2);
            this.panel217.Name = "panel217";
            this.panel217.Size = new System.Drawing.Size(398, 20);
            this.panel217.TabIndex = 540;
            // 
            // StatsEditor
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(881, 630);
            this.Controls.Add(this.labelToolTip);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "StatsEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EDITING STATS...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatsEditor_FormClosing);
            this.panelSearchFormationNames.ResumeLayout(false);
            this.panel200.ResumeLayout(false);
            this.panel200.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackAtkLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackHitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemAttackRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCoinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMagicAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMagicDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSpeed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCoins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingFrogCoins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMaximumFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCurrentFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expNeeded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMgDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingExperience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMaximumHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingCurrentHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingMgAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packFormation3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).EndInit();
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            this.panel63.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValFlowerOdds)).EndInit();
            this.panel66.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValAtk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgAtk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValEvd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValMgEvd)).EndInit();
            this.panel62.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValCoins)).EndInit();
            this.panel56.ResumeLayout(false);
            this.panel68.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            this.panel71.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonsterValElevation)).EndInit();
            this.panel65.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsychopath)).EndInit();
            this.panel83.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.packNum)).EndInit();
            this.panel81.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formationNum)).EndInit();
            this.panel36.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel77.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formationByte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationByte4)).EndInit();
            this.panelFormationUse.ResumeLayout(false);
            this.panelFormationHide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formationCoordX4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormation)).EndInit();
            this.panel52.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formationUnknown)).EndInit();
            this.panel45.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpellDesc)).EndInit();
            this.panelSpellDescription.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            this.panel92.PerformLayout();
            this.panel86.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            this.panel87.PerformLayout();
            this.panel88.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spellHitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spellFPCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spellMagPower)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel218.ResumeLayout(false);
            this.panel171.ResumeLayout(false);
            this.panelSpellNotes.ResumeLayout(false);
            this.panel170.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel169.ResumeLayout(false);
            this.panel166.ResumeLayout(false);
            this.panel168.ResumeLayout(false);
            this.panel165.ResumeLayout(false);
            this.panel167.ResumeLayout(false);
            this.panel164.ResumeLayout(false);
            this.panel163.ResumeLayout(false);
            this.panel162.ResumeLayout(false);
            this.panel161.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spellNum)).EndInit();
            this.panel160.ResumeLayout(false);
            this.panel156.ResumeLayout(false);
            this.panel159.ResumeLayout(false);
            this.panel155.ResumeLayout(false);
            this.panel158.ResumeLayout(false);
            this.panel154.ResumeLayout(false);
            this.panel157.ResumeLayout(false);
            this.panel153.ResumeLayout(false);
            this.panel152.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel89.ResumeLayout(false);
            this.panel90.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            this.panel151.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel61.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.panel103.ResumeLayout(false);
            this.panel104.ResumeLayout(false);
            this.panel102.ResumeLayout(false);
            this.panel105.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            this.panel107.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.panel109.ResumeLayout(false);
            this.panel110.ResumeLayout(false);
            this.panel111.ResumeLayout(false);
            this.panel112.ResumeLayout(false);
            this.panel113.ResumeLayout(false);
            this.panel114.ResumeLayout(false);
            this.panel115.ResumeLayout(false);
            this.panel116.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shopNum)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelItemDesc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemDesc)).EndInit();
            this.panel228.ResumeLayout(false);
            this.panel226.ResumeLayout(false);
            this.panel195.ResumeLayout(false);
            this.panel192.ResumeLayout(false);
            this.panel193.ResumeLayout(false);
            this.panel194.ResumeLayout(false);
            this.panel191.ResumeLayout(false);
            this.panel223.ResumeLayout(false);
            this.panel223.PerformLayout();
            this.panel190.ResumeLayout(false);
            this.panel189.ResumeLayout(false);
            this.panel187.ResumeLayout(false);
            this.panel181.ResumeLayout(false);
            this.panel185.ResumeLayout(false);
            this.panel180.ResumeLayout(false);
            this.panel188.ResumeLayout(false);
            this.panel183.ResumeLayout(false);
            this.panel186.ResumeLayout(false);
            this.panel182.ResumeLayout(false);
            this.panel184.ResumeLayout(false);
            this.panel179.ResumeLayout(false);
            this.panel178.ResumeLayout(false);
            this.panel177.ResumeLayout(false);
            this.panel176.ResumeLayout(false);
            this.panelItemDescription.ResumeLayout(false);
            this.panel175.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel95.ResumeLayout(false);
            this.panel174.ResumeLayout(false);
            this.panel173.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel96.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            this.panel172.ResumeLayout(false);
            this.panel93.ResumeLayout(false);
            this.panel117.ResumeLayout(false);
            this.panel117.PerformLayout();
            this.panel118.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startingAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingLevel)).EndInit();
            this.panel28.ResumeLayout(false);
            this.panel120.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            this.panel121.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slotNum)).EndInit();
            this.panel122.ResumeLayout(false);
            this.panel124.ResumeLayout(false);
            this.panel123.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.characterNum)).EndInit();
            this.panel46.ResumeLayout(false);
            this.panel230.ResumeLayout(false);
            this.panel231.ResumeLayout(false);
            this.panel232.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel125.ResumeLayout(false);
            this.panel224.ResumeLayout(false);
            this.panel199.ResumeLayout(false);
            this.panel198.ResumeLayout(false);
            this.panel197.ResumeLayout(false);
            this.panel101.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).EndInit();
            this.panel196.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel220.ResumeLayout(false);
            this.panel211.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown102)).EndInit();
            this.panel210.ResumeLayout(false);
            this.panel209.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel208.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown105)).EndInit();
            this.panel207.ResumeLayout(false);
            this.panel129.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GenoChargeOverflow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel4Frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel3Frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenoLevel2Frame)).EndInit();
            this.panel206.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level1FrameEnd)).EndInit();
            this.panel130.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level2FrameEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spell2Level2FrameStart)).EndInit();
            this.panel205.ResumeLayout(false);
            this.panel128.ResumeLayout(false);
            this.panel131.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spell1TimingFrameSpan)).EndInit();
            this.panel204.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvl1TimingEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2TimingStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2TimingEnd)).EndInit();
            this.panel132.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvl1TimingStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.panel127.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel214.ResumeLayout(false);
            this.panel212.ResumeLayout(false);
            this.panel141.ResumeLayout(false);
            this.panel140.ResumeLayout(false);
            this.panel139.ResumeLayout(false);
            this.panel138.ResumeLayout(false);
            this.panel133.ResumeLayout(false);
            this.panel137.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panel136.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel135.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel134.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel202.ResumeLayout(false);
            this.panel222.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monsterTargetArrowY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterTargetArrowX)).EndInit();
            this.panel23.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel142.ResumeLayout(false);
            this.panel150.ResumeLayout(false);
            this.panel149.ResumeLayout(false);
            this.panel148.ResumeLayout(false);
            this.panel147.ResumeLayout(false);
            this.panel146.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel145.ResumeLayout(false);
            this.panel144.ResumeLayout(false);
            this.panel143.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panelSearchFormationPacks.ResumeLayout(false);
            this.panel203.ResumeLayout(false);
            this.panel203.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formationBattleEvent)).EndInit();
            this.panel74.ResumeLayout(false);
            this.panel216.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Added
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem allComponentsToolStripMenuItem;
        private ToolStripMenuItem allComponentsToolStripMenuItem1;
        private NumericUpDown attackAtkLevel;
        private CheckedListBox attackAtkType;
        private NumericUpDown attackHitRate;
        private ComboBox attackName;
        private NumericUpDown attackNum;
        private NumericUpDown attackPlus;
        private NumericUpDown attackPlusBonus;
        private CheckedListBox attackStatusEffect;
        private CheckedListBox attackStatusUp;
        private ToolStripMenuItem attacksToolStripMenuItem;
        private ToolStripMenuItem attackToolStripMenuItem;
        private ToolStripMenuItem battleDialoguesToolStripMenuItem;
        private ComboBox battlefieldName;
        private Button button1;
        private Button button2;
        private Button button33;
        private Button button34;
        private Button buttonItemDescriptionBreak;
        private Button buttonItemDescriptionEnd;
        private Button buttonNextFrame;
        private Button buttonPreviousFrame;
        private ComboBox characterName;
        private NumericUpDown characterNum;
        private ToolStripMenuItem charactersToolStripMenuItem;
        private ToolStripMenuItem characterToolStripMenuItem;
        private CheckedListBox CheckboxMonsterEfecNull;
        private CheckedListBox CheckboxMonsterElemNull;
        private CheckedListBox CheckboxMonsterElemWeak;
        private CheckedListBox CheckboxMonsterProp;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private NumericUpDown defensePlus;
        private NumericUpDown defensePlusBonus;
        private ToolStripMenuItem dialoguesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private NumericUpDown expNeeded;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ComboBox fireballName;
        private NumericUpDown formationByte1;
        private NumericUpDown formationByte2;
        private NumericUpDown formationByte3;
        private NumericUpDown formationByte4;
        private NumericUpDown formationByte5;
        private NumericUpDown formationByte6;
        private NumericUpDown formationByte7;
        private NumericUpDown formationByte8;
        private NumericUpDown formationCoordX1;
        private NumericUpDown formationCoordX2;
        private NumericUpDown formationCoordX3;
        private NumericUpDown formationCoordX4;
        private NumericUpDown formationCoordX5;
        private NumericUpDown formationCoordX6;
        private NumericUpDown formationCoordX7;
        private NumericUpDown formationCoordX8;
        private NumericUpDown formationCoordY1;
        private NumericUpDown formationCoordY2;
        private NumericUpDown formationCoordY3;
        private NumericUpDown formationCoordY4;
        private NumericUpDown formationCoordY5;
        private NumericUpDown formationCoordY6;
        private NumericUpDown formationCoordY7;
        private NumericUpDown formationCoordY8;
        private ComboBox formationMusic;
        private ComboBox formationName1;
        private ComboBox formationName2;
        private ComboBox formationName3;
        private ComboBox formationName4;
        private ComboBox formationName5;
        private ComboBox formationName6;
        private ComboBox formationName7;
        private ComboBox formationName8;
        private ComboBox formationNameList;
        private NumericUpDown formationNum;
        private ToolStripMenuItem formationPackToolStripMenuItem;
        private ComboBox formationSet;
        private ToolStripMenuItem formationsToolStripMenuItem;
        private ToolStripMenuItem formationToolStripMenuItem;
        private NumericUpDown formationUnknown;
        private TrackBar GenoChargeOverflow;
        private TrackBar GenoLevel2Frame;
        private TrackBar GenoLevel3Frame;
        private TrackBar GenoLevel4Frame;
        private ToolStripMenuItem helpToolStripMenuItem;
        private NumericUpDown hpPlus;
        private NumericUpDown hpPlusBonus;
        private ComboBox instanceNumberName;
        private NumericUpDown itemAttack;
        private NumericUpDown itemAttackRange;
        private ComboBox itemAttackType;
        private NumericUpDown itemCoinValue;
        private ComboBox itemCursor;
        private CheckedListBox itemCursorRestore;
        private NumericUpDown itemDefense;
        private ComboBox itemElemAttack;
        private CheckedListBox itemElemNull;
        private CheckedListBox itemElemWeak;
        private ComboBox itemFunction;
        private NumericUpDown itemMagicAttack;
        private NumericUpDown itemMagicDefense;
        private ComboBox itemName;
        private ComboBox itemNameIcon;
        private NumericUpDown itemNum;
        private NumericUpDown itemPower;
        private NumericUpDown itemSpeed;
        private CheckedListBox itemStatusChange;
        private CheckedListBox itemStatusEffect;
        private ToolStripMenuItem itemsToolStripMenuItem;
        private CheckedListBox itemTargetting;
        private ToolStripMenuItem itemToolStripMenuItem;
        private ComboBox itemType;
        private CheckedListBox itemUsage;
        private CheckedListBox itemWhoEquip;
        private ComboBox ItemWinA;
        private ComboBox ItemWinB;
        private ComboBox level1TimingSpellName;
        private ComboBox level2TimingSpellName;
        private NumericUpDown levelNum;
        private TrackBar lvl1TimingEnd;
        private TrackBar lvl1TimingStart;
        private TrackBar lvl2TimingEnd;
        private TrackBar lvl2TimingStart;
        private MenuStrip menuStrip1;
        private NumericUpDown mgAttackPlus;
        private NumericUpDown mgAttackPlusBonus;
        private NumericUpDown mgDefensePlus;
        private NumericUpDown mgDefensePlusBonus;
        private ComboBox MonsterBehavior;
        private ComboBox MonsterCoinSize;
        private ComboBox MonsterEntranceStyle;
        private ComboBox MonsterFlowerBonus;
        private ComboBox MonsterMorphSuccess;
        private ComboBox monsterName;
        private RichTextBox monsterNotesTextBox;
        private NumericUpDown MonsterNumber;
        private ComboBox MonsterSoundOther;
        private ComboBox MonsterSoundStrike;
        private ToolStripMenuItem monstersToolStripMenuItem;
        private ToolStripMenuItem monsterToolStripMenuItem;
        private NumericUpDown MonsterValAtk;
        private NumericUpDown MonsterValCoins;
        private NumericUpDown MonsterValDef;
        private NumericUpDown MonsterValElevation;
        private NumericUpDown MonsterValEvd;
        private NumericUpDown MonsterValExp;
        private NumericUpDown MonsterValFlowerOdds;
        private NumericUpDown MonsterValFP;
        private NumericUpDown MonsterValHP;
        private NumericUpDown MonsterValMgAtk;
        private NumericUpDown MonsterValMgDef;
        private NumericUpDown MonsterValMgEvd;
        private NumericUpDown MonsterValSpeed;
        private ComboBox MonsterYoshiCookie;
        private ComboBox multipleTimingSpellName;
        private NumericUpDown numericUpDown100;
        private NumericUpDown numericUpDown102;
        private NumericUpDown numericUpDown103;
        private NumericUpDown numericUpDown104;
        private NumericUpDown numericUpDown105;
        private NumericUpDown numericUpDown106;
        private NumericUpDown numericUpDown107;
        private NumericUpDown numericUpDown108;
        private NumericUpDown numericUpDown110;
        private NumericUpDown numericUpDown111;
        private NumericUpDown numericUpDown112;
        private NumericUpDown numericUpDown113;
        private NumericUpDown numericUpDown114;
        private NumericUpDown numericUpDown117;
        private NumericUpDown numericUpDown118;
        private NumericUpDown numericUpDown119;
        private NumericUpDown numericUpDown120;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown packFormation1;
        private NumericUpDown packFormation2;
        private NumericUpDown packFormation3;
        private Button packFormationButton1;
        private Button packFormationButton2;
        private Button packFormationButton3;
        private NumericUpDown packNum;
        private ToolStripMenuItem packsToolStripMenuItem;
        private ComboBox padRotationSpellName;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private RichTextBox richTextBox8;
        private RichTextBox richTextBox9;
        private ToolStripMenuItem saveStatsToolStripMenuItem;
        private CheckedListBox shopBuyOptions;
        private CheckedListBox shopDiscounts;
        private ComboBox shopItem1;
        private ComboBox shopItem10;
        private ComboBox shopItem11;
        private ComboBox shopItem12;
        private ComboBox shopItem13;
        private ComboBox shopItem14;
        private ComboBox shopItem15;
        private ComboBox shopItem2;
        private ComboBox shopItem3;
        private ComboBox shopItem4;
        private ComboBox shopItem5;
        private ComboBox shopItem6;
        private ComboBox shopItem7;
        private ComboBox shopItem8;
        private ComboBox shopItem9;
        private ComboBox shopName;
        private NumericUpDown shopNum;
        private ToolStripMenuItem shopsToolStripMenuItem;
        private ToolStripMenuItem shopToolStripMenuItem;
        private NumericUpDown slotNum;
        private TrackBar spell1TimingFrameSpan;
        private TrackBar spell2Level1FrameEnd;
        private TrackBar spell2Level2FrameEnd;
        private TrackBar spell2Level2FrameStart;
        private CheckedListBox spellAttackProp;
        private NumericUpDown spellFPCost;
        private ComboBox spellFunction;
        private NumericUpDown spellHitRate;
        private NumericUpDown spellMagPower;
        private ComboBox spellName;
        private NumericUpDown spellNum;
        private CheckedListBox spellStatusChange;
        private CheckedListBox spellStatusEffect;
        private ToolStripMenuItem spellsToolStripMenuItem;
        private CheckedListBox spellTargetting;
        private ToolStripMenuItem spellTimingsToolStripMenuItem;
        private ToolStripMenuItem spellToolStripMenuItem;
        private ComboBox startingAccessory;
        private ComboBox startingArmor;
        private NumericUpDown startingAttack;
        private NumericUpDown startingCoins;
        private NumericUpDown startingCurrentFP;
        private NumericUpDown startingCurrentHP;
        private NumericUpDown startingDefense;
        private ComboBox startingEquipment;
        private NumericUpDown startingExperience;
        private NumericUpDown startingFrogCoins;
        private ComboBox startingItem;
        private NumericUpDown startingLevel;
        private CheckedListBox startingMagic;
        private NumericUpDown startingMaximumFP;
        private NumericUpDown startingMaximumHP;
        private NumericUpDown startingMgAttack;
        private NumericUpDown startingMgDefense;
        private ComboBox startingSpecialItem;
        private NumericUpDown startingSpeed;
        private ComboBox startingWeapon;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TextBox textBoxAttackName;
        private RichTextBox textBoxAttackNotes;
        private TextBox textBoxCharacterName;
        private RichTextBox textBoxItemDescription;
        private TextBox textBoxItemName;
        private TextBox TextboxMonsterName;
        private RichTextBox TextboxMonsterPsychoMsg;
        private RichTextBox textBoxSpellDescription;
        private TextBox textBoxSpellName;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ComboBox weaponName;
        private ComboBox weaponOrDefense;
        private ToolStripMenuItem weaponToolStripMenuItem;

        private Label label1;
        private Label label10;
        private Label label100;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label106;
        private Label label107;
        private Label label108;
        private Label label109;
        private Label label11;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label114;
        private Label label115;
        private Label label116;
        private Label label117;
        private Label label118;
        private Label label12;
        private Label label120;
        private Label label121;
        private Label label122;
        private Label label123;
        private Label label124;
        private Label label125;
        private Label label126;
        private Label label127;
        private Label label128;
        private Label label129;
        private Label label13;
        private Label label130;
        private Label label131;
        private Label label132;
        private Label label133;
        private Label label134;
        private Label label135;
        private Label label136;
        private Label label137;
        private Label label138;
        private Label label139;
        private Label label14;
        private Label label141;
        private Label label142;
        private Label label143;
        private Label label144;
        private Label label145;
        private Label label146;
        private Label label147;
        private Label label148;
        private Label label149;
        private Label label15;
        private Label label151;
        private Label label152;
        private Label label153;
        private Label label154;
        private Label label155;
        private Label label156;
        private Label label157;
        private Label label158;
        private Label label159;
        private Label label16;
        private Label label160;
        private Label label161;
        private Label label162;
        private Label label163;
        private Label label164;
        private Label label165;
        private Label label166;
        private Label label167;
        private Label label168;
        private Label label169;
        private Label label17;
        private Label label170;
        private Label label171;
        private Label label172;
        private Label label173;
        private Label label175;
        private Label label176;
        private Label label177;
        private Label label178;
        private Label label179;
        private Label label18;
        private Label label180;
        private Label label181;
        private Label label182;
        private Label label183;
        private Label label184;
        private Label label185;
        private Label label186;
        private Label label188;
        private Label label189;
        private Label label19;
        private Label label191;
        private Label label193;
        private Label label194;
        private Label label197;
        private Label label2;
        private Label label20;
        private Label label202;
        private Label label208;
        private Label label209;
        private Label label21;
        private Label label210;
        private Label label211;
        private Label label216;
        private Label label22;
        private Label label23;
        private Label label235;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label4;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label9;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label94;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label98;
        private Label label99;
        private Label LabelMonster;
        private Label LabelMonsterName;
        private Label LabelMonsterRewardStats;
        private Label LabelMonsterValAtk;
        private Label LabelMonsterValDef;
        private Label LabelMonsterValEvd;
        private Label LabelMonsterValFP;
        private Label LabelMonsterValHP;
        private Label LabelMonsterValMgAtk;
        private Label LabelMonsterValMgDef;
        private Label LabelMonsterValMgEvd;
        private Label LabelMonsterValSpeed;
        private Label LabelMonsterVitalStats;
        private Label LabelMonsterYoshiCookie;
        private Panel panel1;
        private Panel panel100;
        private Panel panel101;
        private Panel panel102;
        private Panel panel103;
        private Panel panel104;
        private Panel panel105;
        private Panel panel106;
        private Panel panel107;
        private Panel panel108;
        private Panel panel109;
        private Panel panel110;
        private Panel panel111;
        private Panel panel112;
        private Panel panel113;
        private Panel panel114;
        private Panel panel115;
        private Panel panel116;
        private Panel panel117;
        private Panel panel118;
        private Panel panel119;
        private Panel panel120;
        private Panel panel121;
        private Panel panel122;
        private Panel panel123;
        private Panel panel124;
        private Panel panel127;
        private Panel panel128;
        private Panel panel129;
        private Panel panel13;
        private Panel panel130;
        private Panel panel131;
        private Panel panel132;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel28;
        private Panel panel29;
        private Panel panel3;
        private Panel panel30;
        private Panel panel34;
        private Panel panel36;
        private Panel panel37;
        private Panel panel38;
        private Panel panel39;
        private Panel panel4;
        private Panel panel41;
        private Panel panel42;
        private Panel panel45;
        private Panel panel46;
        private Panel panel47;
        private Panel panel5;
        private Panel panel50;
        private Panel panel51;
        private Panel panel52;
        private Panel panel54;
        private Panel panel55;
        private Panel panel56;
        private Panel panel57;
        private Panel panel58;
        private Panel panel59;
        private Panel panel6;
        private Panel panel60;
        private Panel panel61;
        private Panel panel62;
        private Panel panel63;
        private Panel panel64;
        private Panel panel65;
        private Panel panel66;
        private Panel panel67;
        private Panel panel68;
        private Panel panel69;
        private Panel panel70;
        private Panel panel71;
        private Panel panel72;
        private Panel panel73;
        private Panel panel75;
        private Panel panel76;
        private Panel panel77;
        private Panel panel78;
        private Panel panel79;
        private Panel panel8;
        private Panel panel80;
        private Panel panel81;
        private Panel panel82;
        private Panel panel83;
        private Panel panel84;
        private Panel panel85;
        private Panel panel86;
        private Panel panel87;
        private Panel panel88;
        private Panel panel89;
        private Panel panel9;
        private Panel panel90;
        private Panel panel91;
        private Panel panel92;
        private Panel panel93;
        private Panel panel94;
        private Panel panel95;
        private Panel panel96;
        private Panel panel97;
        private Panel panel98;
        private Panel panel99;
        private Panel panelFormationHide;
        private Panel panelFormationUse;
        private Panel panelItemDescription;
        private Panel panelSpellDescription;
        private Panel panelSpellNotes;
        private PictureBox pictureBoxFormation;
        private PictureBox pictureBoxMonster;
        private PictureBox pictureBoxPsychopath;
        private CheckBox formationCantRun;
        private ToolTip toolTip1;
        private ListBox listBox3;
        private ToolStripMenuItem importAllToolStripMenuItem;
        private ToolStripMenuItem exportAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private Panel panel10;
        private Label label40;
        private Label label39;
        private Label label38;
        private Label label37;
        private Label label36;
        private Label label35;
        private Label label45;
        private Label label50;
        private Label label174;
        private Panel panel7;
        private Panel panel33;
        private Panel panel141;
        private Panel panel140;
        private Panel panel139;
        private Panel panel138;
        private Panel panel133;
        private Panel panel137;
        private Panel panel53;
        private Panel panel136;
        private Panel panel31;
        private Panel panel135;
        private Panel panel35;
        private Panel panel134;
        private Panel panel32;
        private Panel panel27;
        private Panel panel26;
        private Panel panel23;
        private Panel panel25;
        private Panel panel24;
        private Label label199;
        private Panel panel142;
        private Panel panel150;
        private Panel panel149;
        private Panel panel148;
        private Panel panel147;
        private Panel panel146;
        private Panel panel145;
        private Panel panel144;
        private Panel panel143;
        private Panel panel12;
        private Panel panel171;
        private Panel panel170;
        private Panel panel169;
        private Panel panel166;
        private Panel panel168;
        private Panel panel165;
        private Panel panel167;
        private Panel panel164;
        private Panel panel163;
        private Panel panel162;
        private Panel panel161;
        private Panel panel160;
        private Panel panel156;
        private Panel panel159;
        private Panel panel155;
        private Panel panel158;
        private Panel panel154;
        private Panel panel157;
        private Panel panel153;
        private Panel panel152;
        private Panel panel40;
        private Panel panel151;
        private Panel panel174;
        private Panel panel173;
        private Panel panel172;
        private Panel panel177;
        private Panel panel176;
        private Panel panel175;
        private Panel panel179;
        private Panel panel178;
        private Panel panel190;
        private Panel panel189;
        private Panel panel188;
        private Panel panel183;
        private Panel panel187;
        private Panel panel181;
        private Panel panel186;
        private Panel panel182;
        private Panel panel185;
        private Panel panel180;
        private Panel panel184;
        private Panel panel195;
        private Panel panel192;
        private Panel panel193;
        private Panel panel194;
        private Panel panel191;
        private Label label190;
        private Panel panel199;
        private Panel panel198;
        private Panel panel197;
        private Panel panel196;
        private Panel panel11;
        private Panel panel22;
        private Panel panel211;
        private Panel panel210;
        private Panel panel209;
        private Panel panel208;
        private Panel panel207;
        private Panel panel206;
        private Panel panel205;
        private Panel panel204;
        private Panel panel218;
        private Panel panel219;
        private Panel panel214;
        private Panel panel215;
        private Panel panel212;
        private Panel panel213;
        private Panel panel220;
        private Panel panel221;
        private Panel panel224;
        private Panel panel225;
        private Panel panel228;
        private Panel panel229;
        private Panel panel226;
        private Panel panel227;
        private Panel panel49;
        private Panel panel44;
        private Panel panel48;
        private Panel panel43;
        private Panel panel125;
        private Panel panel126;
        private ListBox listBoxFormationNames;
        private Panel panel200;
        private TextBox nameTextBox;
        private Button searchFormationNames;
        private Panel panelSearchFormationNames;
        private Panel panel201;
        private Button searchFormationPacks;
        private Panel panel203;
        private TreeView treeViewPackNames;
        private TextBox packNameTextBox;
        private Panel panelSearchFormationPacks;
        private Panel panel202;
        private Panel panel222;
        private NumericUpDown monsterTargetArrowX;
        private Label label110;
        private Label label119;
        private Label label187;
        private NumericUpDown monsterTargetArrowY;
        private PictureBox pictureBoxSpellDesc;
        private PictureBox pictureBoxItemDesc;
        private Panel panelItemDesc;
        private Label label195;
        private Button buttonPreviewItemDesc;
        private Panel panel223;
        private TextBox shopLabel;
        private Label labelShopLabel;
        private Panel panel230;
        private Panel panel231;
        private Label label192;
        private Label label201;
        private Panel panel232;
        private ComboBox levelUpSpellLearned;
        private Label labelToolTip;
        private ToolStripMenuItem enableHelpTipsToolStripMenuItem;
        private NumericUpDown formationBattleEvent;
        private Label label140;
        private Panel panel74;
        private ComboBox musicTrack;
        private Label label150;
        private Panel panel216;
        private Panel panel217;
    }
}


