using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class StatusCalculator : Controls.NewForm
    {
        #region Variables

        // Elements
        private Items.Item[] items
        {
            get { return Items.Model.Items; }
        }
        private Attacks.Attack[] attacks
        {
            get { return Attacks.Model.Attacks; }
        }
        private Magic.Spell[] spells
        {
            get { return Magic.Model.Spells; }
        }
        private Monsters.Monster[] monsters
        {
            get { return Monsters.Model.Monsters; }
        }
        
        // Name lists
        private SortedList itemNames
        {
            get { return Items.Model.Names; }
        }
        private SortedList monsterNames
        {
            get { return Monsters.Model.Names; }
        }

        // Text
        private MenuTextPreview menuTextPreview = new MenuTextPreview();

        // Fonts
        private Fonts.Glyph[] fontDialogue
        {
            get { return Fonts.Model.Dialogue; }
        }
        private Fonts.Glyph[] fontMenu
        {
            get { return Fonts.Model.Menu; }
        }
        private int[] fontPaletteBattle
        {
            get { return Fonts.Model.Palette_Battle.Palettes[0]; }
        }
        private int[] fontPaletteDialogue
        {
            get { return Fonts.Model.Palette_Dialogue.Palettes[1]; }
        }

        // ListView
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

        #endregion

        // Constructor
        public StatusCalculator()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            CalculatePhysical();
            CalculateSpells();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }
        private void InitializeListControls()
        {
            this.Updating = true;

            // Equipment
            this.attackerWeapon.Items.Clear();
            this.attackerWeapon.Items.AddRange(itemNames.Names);
            this.attackerArmor.Items.Clear();
            this.attackerArmor.Items.AddRange(itemNames.Names);
            this.attackerAccessory.Items.Clear();
            this.attackerAccessory.Items.AddRange(itemNames.Names);
            this.targetWeapon.Items.Clear();
            this.targetWeapon.Items.AddRange(itemNames.Names);
            this.targetArmor.Items.Clear();
            this.targetArmor.Items.AddRange(itemNames.Names);
            this.targetAccessory.Items.Clear();
            this.targetAccessory.Items.AddRange(itemNames.Names);
            this.attackerWeapon.SelectedIndex = itemNames.GetSortedIndex(255);
            this.attackerArmor.SelectedIndex = itemNames.GetSortedIndex(255);
            this.attackerAccessory.SelectedIndex = itemNames.GetSortedIndex(255);
            this.targetWeapon.SelectedIndex = itemNames.GetSortedIndex(255);
            this.targetArmor.SelectedIndex = itemNames.GetSortedIndex(255);
            this.targetAccessory.SelectedIndex = itemNames.GetSortedIndex(255);

            // Names
            for (int i = 0; i < NewGame.Model.Allies.Length; i++)
                this.attackerName.Items.Add(new string(NewGame.Model.Allies[i].Name));
            this.attackerName.SelectedIndex = 0;
            this.targetName.Items.AddRange(Monsters.Model.Names.Names);
            this.targetName.SelectedIndex = monsterNames.GetSortedIndex(0);
            this.attackerBonus.SelectedIndex = 0;
            this.targetBonus.SelectedIndex = 0;

            // Finished
            this.Updating = false;
        }
        private void SwitchOpponents()
        {
            bool typeMonster = attackerTypeMonster.Checked;
            int name = attackerName.SelectedIndex;
            int level = (int)attackerLevel.Value;
            int bonus = attackerBonus.SelectedIndex;
            int weapon = attackerWeapon.SelectedIndex;
            int armor = attackerArmor.SelectedIndex;
            int accessory = attackerAccessory.SelectedIndex;

            this.Updating = true;
            //
            if (targetTypeMonster.Checked)
                attackerTypeMonster.Checked = true;
            else
                attackerTypeAlly.Checked = true;
            attackerName.SelectedIndex = targetName.SelectedIndex;
            attackerLevel.Value = targetLevel.Value;
            attackerBonus.SelectedIndex = targetBonus.SelectedIndex;
            attackerWeapon.SelectedIndex = targetWeapon.SelectedIndex;
            attackerArmor.SelectedIndex = targetArmor.SelectedIndex;
            attackerAccessory.SelectedIndex = targetAccessory.SelectedIndex;
            CalculateLevel(true);
            //
            if (typeMonster)
                targetTypeMonster.Checked = true;
            else
                targetTypeAlly.Checked = true;
            targetName.SelectedIndex = name;
            targetLevel.Value = level;
            targetBonus.SelectedIndex = bonus;
            targetWeapon.SelectedIndex = weapon;
            targetArmor.SelectedIndex = armor;
            targetAccessory.SelectedIndex = accessory;
            CalculateLevel(false);
            //
            this.Updating = false;
        }

        // Calculation
        private void CalculateLevel(bool attacker)
        {
            this.Updating = true;
            ComboBox bonus;
            NumericUpDown hp_;
            NumericUpDown attack_;
            NumericUpDown defense_;
            NumericUpDown mgAttack_;
            NumericUpDown mgDefense_;
            NumericUpDown level_;
            RadioButton radioButton;
            ComboBox names;
            CheckedListBox weakness;
            if (attacker)
            {
                bonus = attackerBonus;
                hp_ = attackerHP;
                attack_ = attackerAttack;
                defense_ = attackerDefense;
                mgAttack_ = attackerMgAttack;
                mgDefense_ = attackerMgDefense;
                level_ = attackerLevel;
                radioButton = attackerTypeAlly;
                names = attackerName;
                weakness = null;
            }
            else
            {
                bonus = targetBonus;
                hp_ = targetHP;
                attack_ = targetAttack;
                defense_ = targetDefense;
                mgAttack_ = targetMgAttack;
                mgDefense_ = targetMgDefense;
                level_ = targetLevel;
                radioButton = targetTypeAlly;
                names = targetName;
                weakness = targetWeakness;
            }
            if (radioButton.Checked)
            {
                var ally = NewGame.Model.Allies[names.SelectedIndex];
                if (level_.Value == 1)
                {
                    hp_.Value = ally.CurrentHP;
                    attack_.Value = ally.Attack;
                    defense_.Value = ally.Defense;
                    mgAttack_.Value = ally.MgAttack;
                    mgDefense_.Value = ally.MgDefense;
                }
                else
                {
                    int hp = ally.CurrentHP;
                    int attack = ally.Attack;
                    int defense = ally.Defense;
                    int mgAttack = ally.MgAttack;
                    int mgDefense = ally.MgDefense;
                    foreach (var level in LevelUps.Model.LevelUps)
                    {
                        if (level == null) continue;
                        if (level.Index > level_.Value) break;
                        var levelUpAlly = level.Allies[ally.Index];
                        hp += levelUpAlly.HpPlus;
                        attack += levelUpAlly.AttackPlus;
                        defense += levelUpAlly.DefensePlus;
                        mgAttack += levelUpAlly.MgAttackPlus;
                        mgDefense += levelUpAlly.MgDefensePlus;
                        if (bonus.SelectedIndex == 0)
                        {
                            if (levelUpAlly.AttackPlusBonus > levelUpAlly.MgAttackPlusBonus)
                            {
                                attack += levelUpAlly.AttackPlusBonus;
                                defense += levelUpAlly.DefensePlusBonus;
                            }
                            else if (levelUpAlly.MgAttackPlusBonus > levelUpAlly.AttackPlusBonus)
                            {
                                mgAttack += levelUpAlly.MgAttackPlusBonus;
                                mgDefense += levelUpAlly.MgDefensePlusBonus;
                            }
                            else
                                hp += levelUpAlly.HpPlusBonus;
                        }
                        else if (bonus.SelectedIndex == 1)
                        {
                            hp += levelUpAlly.HpPlusBonus;
                        }
                        else if (bonus.SelectedIndex == 2)
                        {
                            mgAttack += levelUpAlly.MgAttackPlusBonus;
                            mgDefense += levelUpAlly.MgDefensePlusBonus;
                        }
                        else
                        {
                            attack += levelUpAlly.AttackPlusBonus;
                            defense += levelUpAlly.DefensePlusBonus;
                        }
                    }
                    hp_.Value = hp;
                    attack_.Value = attack;
                    defense_.Value = defense;
                    mgAttack_.Value = mgAttack;
                    mgDefense_.Value = mgDefense;
                }
            }
            else
            {
                var monster = monsters[Monsters.Model.Names.GetUnsortedIndex(names.SelectedIndex)];
                hp_.Value = monster.HP;
                attack_.Value = monster.Attack;
                defense_.Value = monster.Defense;
                mgAttack_.Value = monster.MagicAttack;
                mgDefense_.Value = monster.MagicDefense;
                if (weakness != null)
                {
                    weakness.SetItemChecked(0, monster.ElemWeakIce);
                    weakness.SetItemChecked(1, monster.ElemWeakThunder);
                    weakness.SetItemChecked(2, monster.ElemWeakFire);
                    weakness.SetItemChecked(3, monster.ElemWeakJump);
                }
            }
            CalculatePhysical();
            CalculateSpells();
            this.Updating = false;
        }
        private void CalculatePhysical()
        {
            double high;
            double low = (double)attackerAttack.Value;
            if (attackerTypeAlly.Checked)
            {
                low += items[itemNames.GetUnsortedIndex(attackerWeapon.SelectedIndex)].Attack;
                low += items[itemNames.GetUnsortedIndex(attackerArmor.SelectedIndex)].Attack;
                low += items[itemNames.GetUnsortedIndex(attackerAccessory.SelectedIndex)].Attack;
            }
            low -= (double)targetDefense.Value;
            if (targetTypeAlly.Checked)
            {
                low -= (double)items[itemNames.GetUnsortedIndex(targetWeapon.SelectedIndex)].MagicDefense;
                low -= (double)items[itemNames.GetUnsortedIndex(targetArmor.SelectedIndex)].MagicDefense;
                low -= (double)items[itemNames.GetUnsortedIndex(targetAccessory.SelectedIndex)].MagicDefense;
            }
            if (attackerTypeAlly.Checked)
            {
                high = low + items[itemNames.GetUnsortedIndex(attackerWeapon.SelectedIndex)].AttackRange;
                low -= items[itemNames.GetUnsortedIndex(attackerWeapon.SelectedIndex)].AttackRange;
            }
            else
                high = low;
            if (timedAttackL2.Checked)
            {
                low *= 2.0;
                high *= 2.0;
            }
            else if (timedAttackL1.Checked)
            {
                low *= 1.5;
                high *= 1.5;
            }
            if (targetDefensePosition.Checked)
            {
                low /= 2;
                high /= 2;
            }
            if (attackerStatus.GetItemChecked(0) || targetStatus.GetItemChecked(2))
            {
                low *= 1.5;
                high *= 1.5;
            }
            if (attackerStatus.GetItemChecked(2) || targetStatus.GetItemChecked(0))
            {
                low /= 2.0;
                high /= 2.0;
            }
            if (low < 1)
                low = 1;
            if (items[itemNames.GetUnsortedIndex(attackerWeapon.SelectedIndex)].AttackRange != 0)
                singleAttack.Text = Math.Ceiling(low).ToString() + " to " + Math.Ceiling(high).ToString();
            else
                singleAttack.Text = Math.Ceiling(low).ToString();
        }
        private void CalculateSpells()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (var spell in spells)
            {
                //double high;
                double low = spell.MagicPower;
                low += (double)attackerMgAttack.Value;
                if (attackerTypeAlly.Checked)
                {
                    low += items[itemNames.GetUnsortedIndex(attackerWeapon.SelectedIndex)].MagicAttack;
                    low += items[itemNames.GetUnsortedIndex(attackerArmor.SelectedIndex)].MagicAttack;
                    low += items[itemNames.GetUnsortedIndex(attackerAccessory.SelectedIndex)].MagicAttack;
                }
                low -= (double)targetMgDefense.Value;
                if (targetTypeAlly.Checked)
                {
                    low -= (double)items[itemNames.GetUnsortedIndex(targetWeapon.SelectedIndex)].MagicDefense;
                    low -= (double)items[itemNames.GetUnsortedIndex(targetArmor.SelectedIndex)].MagicDefense;
                    low -= (double)items[itemNames.GetUnsortedIndex(targetAccessory.SelectedIndex)].MagicDefense;
                }
                if (spell.InflictElement < 4 && targetWeakness.GetItemChecked(spell.InflictElement))
                {
                    low *= 2.0;
                }
                if (timedAttackL2.Checked)
                {
                    low *= 1.5;
                }
                else if (timedAttackL1.Checked)
                {
                    low *= 1.25;
                }
                if (targetDefensePosition.Checked)
                {
                    low /= 2.0;
                }
                if (attackerStatus.GetItemChecked(1) || targetStatus.GetItemChecked(3))
                {
                    low *= 1.5;
                }
                if (attackerStatus.GetItemChecked(3) || targetStatus.GetItemChecked(1))
                {
                    low /= 2.0;
                }
                if (low < 1)
                    low = 1;
                int index = spell.Index;
                ListViewItem item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    Magic.Model.Names.GetUnsortedName(spell.Index).Substring(1),
                    Math.Ceiling(low).ToString()
                });
                listViewItems.Add(item);
            }
            listView1.Items.AddRange(listViewItems.ToArray());
            listView1.EndUpdate();
        }

        #endregion

        #region Event Handlers

        // Type change
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            SwitchOpponents();
        }
        private void attackerType_CheckedChanged(object sender, EventArgs e)
        {
            this.Updating = true;
            //
            if (!attackerTypeMonster.Checked)  // ally
            {
                this.attackerName.Items.Clear();
                for (int i = 0; i < NewGame.Model.Allies.Length; i++)
                    this.attackerName.Items.Add(new string(NewGame.Model.Allies[i].Name));
                this.attackerName.SelectedIndex = 0;
                this.panelAttackerProperties.Height = 69;
                this.panelAttackerStats.Height = 168;
                this.timedAttackL1.Visible = true;
                this.timedAttackL2.Visible = true;
            }
            else
            {
                this.attackerName.Items.Clear();
                this.attackerName.Items.AddRange(Monsters.Model.Names.Names);
                this.attackerName.SelectedIndex = monsterNames.GetSortedIndex(0);
                this.panelAttackerProperties.Height = 21;
                this.panelAttackerStats.Height = 105;
                this.timedAttackL1.Visible = false;
                this.timedAttackL2.Visible = false;
            }
            //
            this.Updating = false;
            loadProperties(sender, e);
        }
        private void targetType_CheckedChanged(object sender, EventArgs e)
        {
            this.Updating = true;
            //
            if (!targetTypeMonster.Checked)  // ally
            {
                this.targetName.Items.Clear();
                for (int i = 0; i < NewGame.Model.Allies.Length; i++)
                    this.targetName.Items.Add(new string(NewGame.Model.Allies[i].Name));
                this.targetName.SelectedIndex = 0;
                this.panelTargetProperties.Height = 69;
                this.panelTargetStats.Height = 168;
                this.targetDefensePosition.Visible = true;
                this.targetWeakness.Visible = false;
            }
            else
            {
                this.targetName.Items.Clear();
                this.targetName.Items.AddRange(Monsters.Model.Names.Names);
                this.targetName.SelectedIndex = monsterNames.GetSortedIndex(0);
                this.panelTargetProperties.Height = 21;
                this.panelTargetStats.Height = 105;
                this.targetDefensePosition.Visible = false;
                this.targetWeakness.Visible = true;
            }
            //
            this.Updating = false;
            loadProperties(sender, e);
        }

        // Draw text
        private void attackerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (attackerTypeAlly.Checked)
                Do.DrawName(
                    sender, e, new BattleDialoguePreview(), Lists.Convert(NewGame.Model.Allies),
                    Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, false, false, Menus.Model.MenuBG_256x255);
            else
                Do.DrawName(sender, e, menuTextPreview, Monsters.Model.Names, fontMenu, fontPaletteBattle, true, Menus.Model.MenuBG_256x255);
        }
        private void targetName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (targetTypeAlly.Checked)
                Do.DrawName(
                    sender, e, new BattleDialoguePreview(), Lists.Convert(NewGame.Model.Allies),
                    Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, false, false, Menus.Model.MenuBG_256x255);
            else
                Do.DrawName(sender, e, menuTextPreview, Monsters.Model.Names, fontMenu, fontPaletteBattle, true, Menus.Model.MenuBG_256x255);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, menuTextPreview, itemNames, fontMenu, fontPaletteBattle, true, true, Menus.Model.MenuBG_256x255);
        }

        // Properties
        private void loadProperties(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            CalculateLevel(
                sender == attackerTypeAlly ||
                sender == attackerLevel ||
                sender == attackerName ||
                sender == attackerBonus);
        }
        private void calculateTotal(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (sender == timedAttackL1 && timedAttackL1.Checked)
                timedAttackL2.Checked = false;
            if (sender == timedAttackL2 && timedAttackL2.Checked)
                timedAttackL1.Checked = false;
            CalculatePhysical();
            CalculateSpells();
        }

        // ListView
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Do.SortListView(sender as ListView, lvwColumnSorter, e.Column);
        }

        #endregion
    }
}