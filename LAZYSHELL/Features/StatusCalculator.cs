using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class StatusCalculator : Form
    {
        private DDlistName itemNames { get { return Model.ItemNames; } }
        private DDlistName monsterNames { get { return Model.MonsterNames; } }
        private MenuTextPreview menuTextPreview = new MenuTextPreview();
        private FontCharacter[] fontDialogue { get { return Model.FontDialogue; } }
        private FontCharacter[] fontMenu { get { return Model.FontMenu; } }
        private int[] fontPaletteBattle { get { return Model.FontPaletteBattle.Palettes[0]; } }
        private int[] fontPaletteDialogue { get { return Model.FontPaletteDialogue.Palettes[1]; } }
        private Item[] items { get { return Model.Items; } }
        private Attack[] attacks { get { return Model.Attacks; } }
        private Spell[] spells { get { return Model.Spells; } }
        private Monster[] monsters { get { return Model.Monsters; } }
        private bool updating = false;
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        public StatusCalculator()
        {
            updating = true;
            InitializeComponent();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
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

            this.attackerWeapon.SelectedIndex = itemNames.GetNumFromIndex(0);
            this.attackerArmor.SelectedIndex = itemNames.GetNumFromIndex(0);
            this.attackerAccessory.SelectedIndex = itemNames.GetNumFromIndex(0);
            this.targetWeapon.SelectedIndex = itemNames.GetNumFromIndex(0);
            this.targetArmor.SelectedIndex = itemNames.GetNumFromIndex(0);
            this.targetAccessory.SelectedIndex = itemNames.GetNumFromIndex(0);
            // load entity
            for (int i = 0; i < Model.Characters.Length; i++)
                this.attackerName.Items.Add(new string(Model.Characters[i].Name));
            this.attackerName.SelectedIndex = 0;
            this.targetName.Items.AddRange(Model.MonsterNames.Names);
            this.targetName.SelectedIndex = monsterNames.GetIndexFromNum(0);
            this.attackerBonus.SelectedIndex = 0;
            this.targetBonus.SelectedIndex = 0;
            updating = false;

            CalculateTotal();
            CalculateSpells();

            this.attackerBonus.SelectedIndex = 0;
            this.targetBonus.SelectedIndex = 0;
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, menuTextPreview, itemNames, fontMenu, fontPaletteBattle, true, Model.MenuBackground_);
        }
        private void attackerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (radioButton3.Checked)
                Do.DrawName(
                    sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Characters),
                    Model.FontMenu, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, false, false, Model.MenuBackground_);
            else
                Do.DrawName(sender, e, menuTextPreview, Model.MonsterNames, fontMenu, fontPaletteBattle, true, Model.MenuBackground_);
        }
        private void targetName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (radioButton5.Checked)
                Do.DrawName(
                    sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Characters),
                    Model.FontMenu, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, false, false, Model.MenuBackground_);
            else
                Do.DrawName(sender, e, menuTextPreview, Model.MonsterNames, fontMenu, fontPaletteBattle, true, Model.MenuBackground_);
        }
        private void calculateTotal(object sender, EventArgs e)
        {
            if (updating) return;
            CalculateTotal();
            CalculateSpells();
        }
        private void CalculateTotal()
        {
            double high;
            double low = (double)attackerAttack.Value;
            low += items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].Attack;
            low += items[itemNames.GetNumFromIndex(attackerArmor.SelectedIndex)].Attack;
            low += items[itemNames.GetNumFromIndex(attackerAccessory.SelectedIndex)].Attack;
            low -= (double)targetDefense.Value;
            low -= (double)items[itemNames.GetNumFromIndex(targetWeapon.SelectedIndex)].MagicDefense;
            low -= (double)items[itemNames.GetNumFromIndex(targetArmor.SelectedIndex)].MagicDefense;
            low -= (double)items[itemNames.GetNumFromIndex(targetAccessory.SelectedIndex)].MagicDefense;
            high = low + items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange;
            low -= items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange;
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
            if (attackerStatus.GetItemChecked(0))
            {
                low *= 1.5;
                high *= 1.5;
            }
            if (low < 1)
                low = 1;
            if (items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange != 0)
                singleAttack.Text = Math.Ceiling(low).ToString() + " to " + Math.Ceiling(high).ToString();
            else
                singleAttack.Text = Math.Ceiling(low).ToString();
        }
        private void CalculateSpells()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (Spell spell in spells)
            {
                //double high;
                double low = spell.MagicPower;
                low += (double)attackerMgAttack.Value;
                low += items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].MagicAttack;
                low += items[itemNames.GetNumFromIndex(attackerArmor.SelectedIndex)].MagicAttack;
                low += items[itemNames.GetNumFromIndex(attackerAccessory.SelectedIndex)].MagicAttack;
                low -= (double)targetMgDefense.Value;
                low -= (double)items[itemNames.GetNumFromIndex(targetWeapon.SelectedIndex)].MagicDefense;
                low -= (double)items[itemNames.GetNumFromIndex(targetArmor.SelectedIndex)].MagicDefense;
                low -= (double)items[itemNames.GetNumFromIndex(targetAccessory.SelectedIndex)].MagicDefense;
                //high = low + items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange;
                //low -= items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange;
                if (spell.InflictElement < 4 && targetWeakness.GetItemChecked(spell.InflictElement))
                {
                    low *= 2.0;
                }
                if (timedAttackL2.Checked)
                {
                    low *= 1.5;
                    //high *= 2.0;
                }
                else if (timedAttackL1.Checked)
                {
                    low *= 1.25;
                    //high *= 1.5;
                }
                if (targetDefensePosition.Checked)
                {
                    low /= 2;
                    //high /= 2;
                }
                if (attackerStatus.GetItemChecked(2))
                {
                    low *= 1.5;
                    //high *= 1.5;
                }
                if (low < 1)
                    low = 1;
                //if (items[itemNames.GetNumFromIndex(attackerWeapon.SelectedIndex)].AttackRange != 0)
                //    singleAttack.Text = Math.Ceiling(low).ToString() + " to " + Math.Ceiling(high).ToString();
                //else
                int index = spell.Index;
                ListViewItem item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    Model.SpellNames.GetNameByNum(spell.Index).Substring(1),
                    Math.Ceiling(low).ToString()
                });
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }
        private void loadProperties(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            NumericUpDown hp_;
            NumericUpDown attack_;
            NumericUpDown defense_;
            NumericUpDown mgAttack_;
            NumericUpDown mgDefense_;
            NumericUpDown level_;
            RadioButton radioButton;
            ComboBox names;
            CheckedListBox weakness;
            if (((Control)sender).Parent == panelAttackerProperties)
            {
                hp_ = attackerHP;
                attack_ = attackerAttack;
                defense_ = attackerDefense;
                mgAttack_ = attackerMgAttack;
                mgDefense_ = attackerMgDefense;
                level_ = attackerLevel;
                radioButton = radioButton3;
                names = attackerName;
                weakness = null;
            }
            else
            {
                hp_ = targetHP;
                attack_ = targetAttack;
                defense_ = targetDefense;
                mgAttack_ = targetMgAttack;
                mgDefense_ = targetMgDefense;
                level_ = targetLevel;
                radioButton = radioButton5;
                names = targetName;
                weakness = targetWeakness;
            }
            if (radioButton.Checked)
            {
                Character character = Model.Characters[names.SelectedIndex];
                if (attackerLevel.Value == 1)
                {
                    hp_.Value = character.StartingCurrentHP;
                    attack_.Value = character.StartingAttack;
                    defense_.Value = character.StartingDefense;
                    mgAttack_.Value = character.StartingMgAttack;
                    mgDefense_.Value = character.StartingMgDefense;
                }
                else
                {
                    int hp = character.StartingCurrentHP;
                    int attack = character.StartingAttack;
                    int defense = character.StartingDefense;
                    int mgAttack = character.StartingMgAttack;
                    int mgDefense = character.StartingMgDefense;
                    foreach (Character.Level level in character.Levels)
                    {
                        if (level == null) continue;
                        if (level.Index > level_.Value) break;
                        hp += level.HpPlus;
                        attack += level.AttackPlus;
                        defense += level.DefensePlus;
                        mgAttack += level.MgAttackPlus;
                        mgDefense += level.MgDefensePlus;
                        if (attackerBonus.SelectedIndex == 0)
                        {
                            if (level.AttackPlusBonus > level.MgAttackPlusBonus)
                            {
                                attack += level.AttackPlusBonus;
                                defense += level.DefensePlusBonus;
                            }
                            else if (level.MgAttackPlusBonus > level.AttackPlusBonus)
                            {
                                mgAttack += level.MgAttackPlusBonus;
                                mgDefense += level.MgDefensePlusBonus;
                            }
                            else
                                hp += level.HpPlusBonus;
                        }
                        else if (attackerBonus.SelectedIndex == 1)
                        {
                            hp += level.HpPlusBonus;
                        }
                        else if (attackerBonus.SelectedIndex == 2)
                        {
                            mgAttack += level.MgAttackPlusBonus;
                            mgDefense += level.MgDefensePlusBonus;
                        }
                        else
                        {
                            attack += level.AttackPlusBonus;
                            defense += level.DefensePlusBonus;
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
                Monster monster = monsters[Model.MonsterNames.GetNumFromIndex(names.SelectedIndex)];
                hp_.Value = monster.HP;
                attack_.Value = monster.Attack;
                defense_.Value = monster.Defense;
                mgAttack_.Value = monster.MagicAttack;
                mgDefense_.Value = monster.MagicDefense;
                if (weakness != null)
                {
                    weakness.SetItemChecked(0, monster.ElemIceWeak);
                    weakness.SetItemChecked(1, monster.ElemThunderWeak);
                    weakness.SetItemChecked(2, monster.ElemFireWeak);
                    weakness.SetItemChecked(3, monster.ElemJumpWeak);
                }
            }
            CalculateTotal();
            CalculateSpells();
            updating = false;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            updating = true;
            if (!radioButton4.Checked)
            {
                this.attackerName.Items.Clear();
                for (int i = 0; i < Model.Characters.Length; i++)
                    this.attackerName.Items.Add(new string(Model.Characters[i].Name));
                this.attackerName.SelectedIndex = 0;
                this.attackerLevel.Enabled = true;
                this.attackerBonus.Enabled = true;
            }
            else
            {
                this.attackerName.Items.Clear();
                this.attackerName.Items.AddRange(Model.MonsterNames.Names);
                this.attackerName.SelectedIndex = monsterNames.GetIndexFromNum(0);
                this.attackerLevel.Enabled = false;
                this.attackerBonus.Enabled = false;
            }
            updating = false;
            loadProperties(sender, e);
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton6.Checked)
            {
                this.targetName.Items.Clear();
                for (int i = 0; i < Model.Characters.Length; i++)
                    this.targetName.Items.Add(new string(Model.Characters[i].Name));
                this.targetName.SelectedIndex = 0;
                this.targetLevel.Enabled = true;
                this.targetBonus.Enabled = true;
            }
            else
            {
                this.targetName.Items.Clear();
                this.targetName.Items.AddRange(Model.MonsterNames.Names);
                this.targetName.SelectedIndex = monsterNames.GetIndexFromNum(0);
                this.targetLevel.Enabled = false;
                this.targetBonus.Enabled = false;
            }
            loadProperties(sender, e);
        }
        private void comboBoxLoad(object sender, EventArgs e)
        {
            loadProperties(((Control)sender).Parent, e);
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            listView.Sort();
        }
    }
}
