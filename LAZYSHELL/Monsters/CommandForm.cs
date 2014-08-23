using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Monsters
{
    public partial class CommandForm : Controls.NewForm
    {
        #region Variables

        private Command command;
        private SortedList spellNames
        {
            get { return Magic.Model.Names; }
            set { Magic.Model.Names = value; }
        }
        private SortedList attackNames
        {
            get { return Attacks.Model.Names; }
            set { Attacks.Model.Names = value; }
        }
        private SortedList itemNames
        {
            get { return Items.Model.Names; }
            set { Items.Model.Names = value; }
        }

        #endregion

        // Constructors
        public CommandForm()
        {
            InitializeComponent();
        }
        public CommandForm(Command command)
        {
            InitializeComponent();
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y - 10;
            this.command = command;
            // Disassemble command into controls
            ReadFromCommand();
        }

        #region Methods

        // Disassembler Commands
        private void ReadFromCommand()
        {
            this.Updating = true;
            //
            panelCommand.SuspendDrawing();
            ResetControls();
            switch (command.Opcode)
            {
                case 0xE0:
                    numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                    numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
                    numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
                    //
                    this.nameA.Items.AddRange(this.attackNames.Names);
                    this.nameA.DrawMode = DrawMode.OwnerDrawFixed; this.nameA.ItemHeight = 15;
                    this.nameB.Items.AddRange(this.attackNames.Names);
                    this.nameB.DrawMode = DrawMode.OwnerDrawFixed; this.nameB.ItemHeight = 15;
                    this.nameC.Items.AddRange(this.attackNames.Names);
                    this.nameC.DrawMode = DrawMode.OwnerDrawFixed; this.nameC.ItemHeight = 15;
                    numA.Maximum = numB.Maximum = numC.Maximum = 128;
                    //
                    if (command.Param1 != 0xFB)
                        nameA.SelectedIndex = attackNames.GetSortedIndex((int)command.Param1);
                    else
                        doNothingA.Checked = true;
                    if (command.Param2 != 0xFB)
                        nameB.SelectedIndex = attackNames.GetSortedIndex((int)command.Param2);
                    else
                        doNothingB.Checked = true;
                    if (command.Param3 != 0xFB)
                        nameC.SelectedIndex = attackNames.GetSortedIndex((int)command.Param3);
                    else
                        doNothingC.Checked = true;
                    break;
                case 0xE2:
                    target.Enabled = true;
                    labelTargetA.Text = "Set target";
                    //
                    this.target.Items.AddRange(Lists.Targets);
                    //
                    this.target.SelectedIndex = command.Param1;
                    break;
                case 0xE3:
                    numA.Enabled = true; nameA.Enabled = true;
                    //
                    this.nameA.BackColor = SystemColors.Window;
                    this.nameA.DropDownWidth = 250;
                    for (int i = 0; i < Dialogues.Model.BattleDialogues.Length; i++)
                        this.nameA.Items.Add(Dialogues.Model.BattleDialogues[i].GetStub());
                    this.nameA.DrawMode = DrawMode.Normal;
                    //
                    this.nameA.SelectedIndex = command.Param1;
                    this.numA.Value = command.Param1;
                    break;
                case 0xE5:
                    numA.Enabled = true; nameA.Enabled = true;
                    //
                    this.nameA.BackColor = SystemColors.Window;
                    this.nameA.DropDownWidth = 400;
                    this.nameA.Items.AddRange(Lists.Numerize(Lists.BattleEvents));
                    this.nameA.DrawMode = DrawMode.Normal;
                    this.numA.Maximum = Lists.BattleEvents.Length;
                    //
                    nameA.SelectedIndex = command.Param1;
                    //
                    break;
                case 0xE6:
                    memory.Enabled = true;
                    labelMemoryA.Text = command.Param1 == 0 ? "Increment" : "Decrement" + " mem addr";
                    //
                    this.memory.Value = 0x7EE000 + command.Param2;
                    break;
                case 0xE7:
                    memory.Enabled = true; panelBits.Enabled = true;
                    labelMemoryA.Text = command.Param1 == 0 ? "Set" : "Clear" + " memory address";
                    labelMemoryC.Text = "Bits";
                    //
                    this.memory.Value = 0x7EE000 + command.Param2;
                    LoadBitProperties(command.Param3);
                    break;
                case 0xE8:
                    memory.Enabled = true;
                    labelMemoryA.Text = "Clear memory address";
                    //
                    this.memory.Value = 0x7EE000 + command.Param1;
                    break;
                case 0xEA:
                    target.Enabled = true;
                    labelTargetA.Text = command.Param1 == 0 ? "Remove" : "Call" + " Target";
                    //
                    this.target.Items.AddRange(Lists.Targets);
                    //
                    this.target.SelectedIndex = command.Param3;
                    break;
                case 0xEB:
                    target.Enabled = true;
                    labelTargetA.Text = command.Param1 == 0 ? "Set" : "Null" + " target invincibility";
                    //
                    this.target.Items.AddRange(Lists.Targets);
                    //
                    this.target.SelectedIndex = command.Param2;
                    break;
                case 0xED:
                    labelMemoryB.Text = "Random # less than";
                    comparison.Enabled = true;
                    //
                    this.comparison.Value = command.Param1;
                    break;
                case 0xEF:
                    numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                    //
                    this.nameA.Items.AddRange(this.spellNames.Names);
                    this.nameA.DrawMode = DrawMode.OwnerDrawFixed; this.nameA.ItemHeight = 15;
                    numA.Maximum = 127;
                    //
                    this.nameA.SelectedIndex = spellNames.GetSortedIndex(command.Param1);
                    break;
                case 0xF0:
                    numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                    numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
                    numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
                    //
                    this.nameA.Items.AddRange(this.spellNames.Names);
                    this.nameA.DrawMode = DrawMode.OwnerDrawFixed; this.nameA.ItemHeight = 15;
                    this.nameB.Items.AddRange(this.spellNames.Names);
                    this.nameB.DrawMode = DrawMode.OwnerDrawFixed; this.nameB.ItemHeight = 15;
                    this.nameC.Items.AddRange(this.spellNames.Names);
                    this.nameC.DrawMode = DrawMode.OwnerDrawFixed; this.nameC.ItemHeight = 15;
                    numA.Maximum = numB.Maximum = numC.Maximum = 127;
                    //
                    if (command.Param1 != 0xFB)
                        nameA.SelectedIndex = spellNames.GetSortedIndex((int)command.Param1);
                    else
                        doNothingA.Checked = true;
                    if (command.Param2 != 0xFB)
                        nameB.SelectedIndex = spellNames.GetSortedIndex((int)command.Param2);
                    else
                        doNothingB.Checked = true;
                    if (command.Param3 != 0xFB)
                        nameC.SelectedIndex = spellNames.GetSortedIndex((int)command.Param3);
                    else
                        doNothingC.Checked = true;
                    break;
                case 0xF1:
                    labelMemoryB.Text = "Behavior animation";
                    comparison.Enabled = true;
                    //
                    comparison.Value = command.Param1;
                    break;
                case 0xF2:
                    target.Enabled = true;
                    labelTargetA.Text = command.Param1 == 0 ? "Disable" : "Enable" + " target";
                    //
                    this.target.Items.AddRange(new object[] {
                        "self",
                        "monster 1",
                        "monster 2",
                        "monster 3",
                        "monster 4",
                        "monster 5",
                        "monster 6",
                        "monster 7",
                        "monster 8"});
                    this.target.SelectedIndex = command.Param2;
                    break;
                case 0xF3:
                    effects.Enabled = true;
                    effects.Items.AddRange(new object[] {
                        "Attack",
                        "Special",
                        "Item"});
                    //
                    effects.SetItemChecked(0, (command.Param2 & 0x01) == 0x01);
                    effects.SetItemChecked(1, (command.Param2 & 0x02) == 0x02);
                    effects.SetItemChecked(2, (command.Param2 & 0x04) == 0x04);
                    break;
                case 0xF4:
                    nameA.Enabled = true;
                    //
                    this.nameA.BackColor = SystemColors.Window;
                    this.nameA.Items.AddRange(new object[] {
                        "Remove Items",
                        "Return Items"});
                    this.nameA.DrawMode = DrawMode.Normal;
                    //
                    nameA.SelectedIndex = command.Param2;
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x01:
                            nameA.Enabled = true; nameB.Enabled = true;
                            //
                            this.nameA.BackColor = SystemColors.Window;
                            this.nameA.Items.AddRange(new object[] {
                                "Attack",
                                "Special",
                                "Item"});
                            this.nameA.DrawMode = DrawMode.Normal;
                            this.nameB.BackColor = SystemColors.Window;
                            this.nameB.Items.AddRange(new object[] {                        
                                "Attack",
                                "Special",
                                "Item"});
                            this.nameB.DrawMode = DrawMode.Normal;
                            //
                            nameA.SelectedIndex = Math.Max(0, (int)(command.Param2 - 2));
                            nameB.SelectedIndex = Math.Max(0, (int)(command.Param3 - 2));
                            break;
                        case 0x02:
                            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
                            //
                            this.nameA.Items.AddRange(this.spellNames.Names);
                            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
                            this.nameA.ItemHeight = 15;
                            this.nameB.Items.AddRange(this.spellNames.Names);
                            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
                            this.nameB.ItemHeight = 15;
                            //
                            if (command.Param2 != 0xFB)
                                nameA.SelectedIndex = spellNames.GetSortedIndex((int)command.Param2);
                            else
                                doNothingA.Checked = true;
                            if (command.Param3 != 0xFB)
                                nameB.SelectedIndex = spellNames.GetSortedIndex((int)command.Param3);
                            else
                                doNothingB.Checked = true;
                            break;
                        case 0x03:
                            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
                            //
                            this.nameA.Items.AddRange(Items.Model.Names.Names);
                            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
                            this.nameA.ItemHeight = 15;
                            this.nameB.Items.AddRange(Items.Model.Names.Names);
                            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
                            this.nameB.ItemHeight = 15;
                            //
                            if (command.Param2 != 0xFB)
                                nameA.SelectedIndex = Items.Model.Names.GetSortedIndex((int)command.Param2);
                            else
                                doNothingA.Checked = true;
                            if (command.Param3 != 0xFB)
                                nameB.SelectedIndex = Items.Model.Names.GetSortedIndex((int)command.Param3);
                            else
                                doNothingB.Checked = true;
                            break;
                        case 0x04:
                            effects.Enabled = true;
                            this.effects.Items.AddRange(new object[] {
                                "Ice",
                                "Thunder",
                                "Fire",
                                "Jump"});
                            //
                            effects.SetItemChecked(0, (command.Param2 & 0x10) == 0x10);
                            effects.SetItemChecked(1, (command.Param2 & 0x20) == 0x20);
                            effects.SetItemChecked(2, (command.Param2 & 0x40) == 0x40);
                            effects.SetItemChecked(3, (command.Param2 & 0x80) == 0x80);
                            break;
                        case 0x06:
                            target.Enabled = true; targetNum.Enabled = true;
                            labelTargetA.Text = "If Target"; labelTargetB.Text = "HP is below";
                            this.target.Items.AddRange(Lists.Targets);
                            //
                            this.target.SelectedIndex = command.Param2;
                            targetNum.Value = command.Param3 * 16;
                            break;
                        case 0x07:
                            labelMemoryB.Text = "If HP less than";
                            comparison.Enabled = true;
                            comparison.Maximum = 0xFFFF;
                            //
                            comparison.Value = Bits.GetShort(command.Data, 2);
                            break;
                        case 0x08:
                        case 0x09:
                            target.Enabled = true; effects.Enabled = true;
                            labelTargetA.Text = "If target";
                            //
                            this.target.Items.AddRange(Lists.Targets);
                            this.effects.Items.AddRange(new object[] {
                                "Mute",
                                "Sleep",
                                "Poison",
                                "Fear",
                                "Mushroom",
                                "Scarecrow",
                                "Invincibility"});
                            //
                            this.target.SelectedIndex = command.Param2;
                            effects.SetItemChecked(0, (command.Param3 & 0x01) == 0x01);
                            effects.SetItemChecked(1, (command.Param3 & 0x02) == 0x02);
                            effects.SetItemChecked(2, (command.Param3 & 0x04) == 0x04);
                            effects.SetItemChecked(3, (command.Param3 & 0x08) == 0x08);
                            effects.SetItemChecked(4, (command.Param3 & 0x20) == 0x20);
                            effects.SetItemChecked(5, (command.Param3 & 0x40) == 0x40);
                            effects.SetItemChecked(6, (command.Param3 & 0x80) == 0x80);
                            break;
                        case 0x0A:
                            comparison.Enabled = true;
                            labelMemoryB.Text = "If attack phase =";
                            //
                            this.comparison.Value = command.Param2;
                            break;
                        case 0x0C:
                            memory.Enabled = true; comparison.Enabled = true;
                            labelMemoryA.Text = "If memory address";
                            labelMemoryB.Text = "Less than";
                            //
                            this.memory.Value = 0x7EE000 + command.Param2;
                            this.comparison.Value = command.Param3;
                            break;
                        case 0x0D:
                            memory.Enabled = true; comparison.Enabled = true;
                            labelMemoryA.Text = "If memory address";
                            labelMemoryB.Text = "Greater than";
                            //
                            this.memory.Value = 0x7EE000 + command.Param2;
                            this.comparison.Value = command.Param3;
                            break;
                        case 0x10:
                            target.Enabled = true;
                            labelTargetA.Text = "If target " + (command.Param2 == 0 ? "alive" : "dead");
                            //
                            this.target.Items.AddRange(Lists.Targets);
                            //
                            this.target.SelectedIndex = command.Param3;
                            break;
                        case 0x11:
                            memory.Enabled = true; panelBits.Enabled = true;
                            labelMemoryA.Text = "If memory address";
                            labelMemoryC.Text = "Bits set";
                            //
                            this.memory.Value = 0x7EE000 + command.Param2;
                            LoadBitProperties(command.Param3);
                            break;
                        case 0x12:
                            memory.Enabled = true; panelBits.Enabled = true;
                            labelMemoryA.Text = "If memory address";
                            labelMemoryC.Text = "Bits clear";
                            //
                            this.memory.Value = 0x7EE000 + command.Param2;
                            LoadBitProperties(command.Param3);
                            break;
                        case 0x13:
                            labelMemoryB.Text = "If in formation";
                            comparison.Enabled = true;
                            comparison.Maximum = 511;
                            //
                            comparison.Value = Bits.GetShort(command.Data, 2);
                            break;
                    }
                    break;
                default:
                    if (command.Opcode >= 0xE0)
                        break;
                    numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
                    //
                    this.nameA.Items.AddRange(this.attackNames.Names);
                    this.nameA.DrawMode = DrawMode.OwnerDrawFixed; this.nameA.ItemHeight = 15;
                    numA.Maximum = 128;
                    //
                    if (command.Param1 != 0xFB)
                        nameA.SelectedIndex = attackNames.GetSortedIndex((int)command.Param1);
                    else
                        doNothingA.Checked = true;
                    break;
            }
            ArrangeControls();
            panelCommand.ResumeDrawing();
            this.Updating = false;
        }
        private void WriteToCommand()
        {
            switch (command.Opcode)
            {
                case 0xE0:
                case 0xF0:
                    if (!doNothingA.Checked)
                        command.Param1 = (byte)numA.Value;
                    else
                        command.Param1 = 0xFB;
                    if (!doNothingB.Checked)
                        command.Param2 = (byte)numB.Value;
                    else
                        command.Param2 = 0xFB;
                    if (!doNothingC.Checked)
                        command.Param3 = (byte)numC.Value;
                    else
                        command.Param3 = 0xFB;
                    break;
                case 0xE2:
                    command.Param1 = (byte)target.SelectedIndex;
                    break;
                case 0xE3:
                case 0xE5:
                case 0xEF:
                    command.Param1 = (byte)numA.Value;
                    break;
                case 0xED:
                case 0xF1:
                    command.Param1 = (byte)comparison.Value;
                    break;
                case 0xE6:
                    command.Param2 = (byte)(memory.Value - 0x7EE000);
                    break;
                case 0xE7:
                    command.Param2 = (byte)(memory.Value - 0x7EE000);
                    foreach (CheckBox bit in panelBits.Controls)
                        Bits.SetBit(command.Data, 3, bit.TabIndex, bit.Checked);
                    break;
                case 0xE8:
                    command.Param1 = (byte)(memory.Value - 0x7EE000);
                    break;
                case 0xEA:
                    command.Param3 = (byte)target.SelectedIndex;
                    break;
                case 0xEB:
                    command.Param2 = (byte)target.SelectedIndex;
                    break;
                case 0xF2:
                    command.Param2 = (byte)target.SelectedIndex;
                    break;
                case 0xF3:
                    for (int i = 0; i < 3; i++)
                        Bits.SetBit(command.Data, 2, i, effects.GetItemChecked(i));
                    break;
                case 0xF4:
                    command.Param2 = (byte)nameA.SelectedIndex;
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x01:
                            command.Param2 = (byte)(nameA.SelectedIndex + 2);
                            command.Param3 = (byte)(nameB.SelectedIndex + 2);
                            break;
                        case 0x02:
                        case 0x03:
                            command.Param2 = (byte)(doNothingA.Checked ? 0xFB : numA.Value);
                            command.Param3 = (byte)(doNothingB.Checked ? 0xFB : numB.Value);
                            break;
                        case 0x04:
                            for (int i = 0; i < 4; i++)
                                Bits.SetBit(command.Data, 2, i + 4, effects.GetItemChecked(i));
                            break;
                        case 0x06:
                            command.Param2 = (byte)target.SelectedIndex;
                            command.Param3 = (byte)(targetNum.Value / 16);
                            break;
                        case 0x08:
                        case 0x09:
                            command.Param2 = (byte)target.SelectedIndex;
                            Bits.SetBit(command.Data, 3, 0, effects.GetItemChecked(0));
                            Bits.SetBit(command.Data, 3, 1, effects.GetItemChecked(1));
                            Bits.SetBit(command.Data, 3, 2, effects.GetItemChecked(2));
                            Bits.SetBit(command.Data, 3, 3, effects.GetItemChecked(3));
                            Bits.SetBit(command.Data, 3, 5, effects.GetItemChecked(4));
                            Bits.SetBit(command.Data, 3, 6, effects.GetItemChecked(5));
                            Bits.SetBit(command.Data, 3, 7, effects.GetItemChecked(6));
                            break;
                        case 0x0A:
                            command.Param2 = (byte)comparison.Value;
                            break;
                        case 0x0C:
                        case 0x0D:
                            command.Param2 = (byte)(memory.Value - 0x7EE000);
                            command.Param3 = (byte)comparison.Value;
                            break;
                        case 0x10:
                            command.Param3 = (byte)target.SelectedIndex;
                            break;
                        case 0x11:
                        case 0x12:
                            command.Param2 = (byte)(memory.Value - 0x7EE000);
                            foreach (CheckBox bit in panelBits.Controls)
                                Bits.SetBit(command.Data, 3, bit.TabIndex, bit.Checked);
                            break;
                        case 0x07:
                        case 0x13:
                            Bits.SetShort(command.Data, 2, (ushort)comparison.Value);
                            break;
                    }
                    break;
                default:
                    if (command.Opcode < 0xE0)
                        command.Opcode = (byte)numA.Value;
                    break;
            }
        }
        private void ResetControls()
        {
            this.Updating = true;
            //
            nameA.BackColor = SystemColors.ControlDarkDark; nameA.ItemHeight = 15;
            nameA.Items.Clear(); nameA.ResetText(); nameA.DropDownWidth = nameA.Width;
            nameB.BackColor = SystemColors.ControlDarkDark; nameB.ItemHeight = 15;
            nameB.Items.Clear(); nameB.ResetText(); nameB.DropDownWidth = nameB.Width;
            nameC.BackColor = SystemColors.ControlDarkDark; nameC.ItemHeight = 15;
            nameC.Items.Clear(); nameC.ResetText(); nameC.DropDownWidth = nameC.Width;
            numA.Minimum = 0; numA.Maximum = 255; numA.Value = 0;
            numB.Minimum = 0; numB.Maximum = 255; numB.Value = 0;
            numC.Minimum = 0; numC.Maximum = 255; numC.Value = 0;
            numA.Enabled = nameA.Enabled = doNothingA.Enabled = false;
            numB.Enabled = nameB.Enabled = doNothingB.Enabled = false;
            numC.Enabled = nameC.Enabled = doNothingC.Enabled = false;
            doNothingA.Checked = false;
            doNothingB.Checked = false;
            doNothingC.Checked = false;
            //
            target.Enabled = targetNum.Enabled = effects.Enabled = false;
            target.Items.Clear(); target.ResetText(); targetNum.Value = 0;
            effects.Items.Clear(); effects.Height = 68;
            labelTargetA.Text = "";
            labelTargetB.Text = "";
            //
            memory.Enabled = comparison.Enabled = panelBits.Enabled = false;
            memory.Minimum = 0x7EE000; memory.Maximum = 0x7EE00F; memory.Value = 0x7EE000;
            comparison.Minimum = 0; comparison.Maximum = 255; comparison.Value = 0;
            labelMemoryA.Text = "";
            labelMemoryB.Text = "";
            labelMemoryC.Text = "";
            bit0.Checked = false;
            bit1.Checked = false;
            bit2.Checked = false;
            bit3.Checked = false;
            bit4.Checked = false;
            bit5.Checked = false;
            bit6.Checked = false;
            bit7.Checked = false;
            //
            this.Updating = false;
        }
        private void ArrangeControls()
        {
            panelAttack.Visible =
                nameA.Enabled || numA.Enabled || doNothingA.Enabled ||
                nameB.Enabled || numB.Enabled || doNothingB.Enabled ||
                nameC.Enabled || numC.Enabled || doNothingC.Enabled;
            panelAttackA.Visible = nameA.Enabled || numA.Enabled || doNothingA.Enabled;
            panelAttackB.Visible = nameB.Enabled || numB.Enabled || doNothingB.Enabled;
            panelAttackC.Visible = nameC.Enabled || numC.Enabled || doNothingC.Enabled;
            //
            panelTarget.Visible = target.Enabled || targetNum.Enabled || effects.Enabled;
            panelTargetA.Visible = target.Enabled;
            panelTargetB.Visible = targetNum.Enabled;
            if (effects.Items.Count < 4)
                effects.Height = effects.Items.Count * 16 + 4;
            else
                effects.Height = 68;
            effects.Visible = effects.Enabled;
            //
            panelMemory.Visible = memory.Enabled || comparison.Enabled || panelBits.Enabled;
            panelMemoryA.Visible = memory.Enabled;
            panelMemoryB.Visible = comparison.Enabled;
            panelMemoryC.Visible = panelBits.Enabled;
            //
            panelAttackA.BringToFront();
            panelAttackB.BringToFront();
            panelAttackC.BringToFront();
            panelTargetA.BringToFront();
            panelTargetB.BringToFront();
            effects.BringToFront();
            panelMemoryA.BringToFront();
            panelMemoryB.BringToFront();
            panelMemoryC.BringToFront();
            //
            this.Height = panelCommand.Bottom + panelCommand.Margin.Bottom + this.TitleHeight;
        }

        private void LoadBitProperties(byte bits)
        {
            this.Updating = true;
            //
            if ((bits & 0x01) != 0) bit0.Checked = true;
            if ((bits & 0x02) != 0) bit1.Checked = true;
            if ((bits & 0x04) != 0) bit2.Checked = true;
            if ((bits & 0x08) != 0) bit3.Checked = true;
            if ((bits & 0x10) != 0) bit4.Checked = true;
            if ((bits & 0x20) != 0) bit5.Checked = true;
            if ((bits & 0x40) != 0) bit6.Checked = true;
            if ((bits & 0x80) != 0) bit7.Checked = true;
            //
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // Command selection
        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte opcode = Lists.BattleOpcodes[listBoxCommands.SelectedIndex];
            byte param1 = Lists.BattleParams[listBoxCommands.SelectedIndex];
            byte[] commandData = new byte[Lists.BattleLengths[opcode]];
            this.command = new Command(commandData);
            this.command.Opcode = opcode;
            this.command.Param1 = param1;
            if (this.command.Opcode == 0xFC &&
                this.command.Param1 == 0x10 &&
                this.listBoxCommands.Text == "If target dead")
                this.command.Param2 = 0x01;
            ReadFromCommand();
        }

        // Command properties
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xFC:
                    if (command.Param1 == 0x02)
                        goto case 0xF0;
                    if (command.Param1 == 0x03)
                        Do.DrawName(
                            sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                            Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, false, Menus.Model.MenuBG_256x255);
                    break;
                case 0xEF:
                case 0xF0:
                    if (e.Index < 0 || e.Index >= 128)
                        break;
                    Do.DrawName(
                        sender, e, new BattleDialoguePreview(), Magic.Model.Names,
                        Magic.Model.Names.GetUnsortedIndex(e.Index) < 64 ? Fonts.Model.Menu : Fonts.Model.Dialogue,
                        Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, false, Menus.Model.MenuBG_256x255);
                    break;
                case 0xE0:
                    goto default;
                default:
                    Do.DrawName(
                        sender, e, new BattleDialoguePreview(), Attacks.Model.Names, Fonts.Model.Dialogue,
                        Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, true, Menus.Model.MenuBG_256x255);
                    break;
            }
        }
        private void numA_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    nameA.SelectedIndex = attackNames.GetSortedIndex((int)numA.Value);
                    break;
                case 0xE3:
                case 0xE5:
                    nameA.SelectedIndex = (int)numA.Value;
                    break;
                case 0xEF:
                case 0xF0:
                    nameA.SelectedIndex = spellNames.GetSortedIndex((int)numA.Value);
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x02:
                            nameA.SelectedIndex = spellNames.GetSortedIndex((int)numA.Value); break;
                        case 0x03:
                            nameA.SelectedIndex = Items.Model.Names.GetSortedIndex((int)numA.Value); break;
                    }
                    break;
                default:
                    nameA.SelectedIndex = attackNames.GetSortedIndex((int)numA.Value);
                    break;
            }
        }
        private void nameA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    numA.Value = attackNames.GetUnsortedIndex(nameA.SelectedIndex);
                    break;
                case 0xE3:
                case 0xE5:
                    numA.Value = nameA.SelectedIndex;
                    break;
                case 0xEF:
                case 0xF0:
                    numA.Value = spellNames.GetUnsortedIndex(nameA.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x02:
                            numA.Value = spellNames.GetUnsortedIndex(nameA.SelectedIndex);
                            break;
                        case 0x03:
                            numA.Value = Items.Model.Names.GetUnsortedIndex(nameA.SelectedIndex);
                            break;
                    }
                    break;
                default:
                    numA.Value = attackNames.GetUnsortedIndex(nameA.SelectedIndex);
                    break;
            }
        }
        private void numB_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    nameB.SelectedIndex = attackNames.GetSortedIndex((int)numB.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    nameB.SelectedIndex = spellNames.GetSortedIndex((int)numB.Value);
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x02:
                            nameB.SelectedIndex = spellNames.GetSortedIndex((int)numB.Value); break;
                        case 0x03:
                            nameB.SelectedIndex = Items.Model.Names.GetSortedIndex((int)numB.Value); break;
                    }
                    break;
            }
        }
        private void nameB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    numB.Value = attackNames.GetUnsortedIndex(nameB.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    numB.Value = spellNames.GetUnsortedIndex(nameB.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Param1)
                    {
                        case 0x02:
                            numB.Value = spellNames.GetUnsortedIndex(nameB.SelectedIndex);
                            break;
                        case 0x03:
                            numB.Value = Items.Model.Names.GetUnsortedIndex(nameB.SelectedIndex);
                            break;
                    }
                    break;
                default:
                    numB.Value = nameB.SelectedIndex;
                    break;
            }
        }
        private void numC_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    nameC.SelectedIndex = attackNames.GetSortedIndex((int)numC.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    nameC.SelectedIndex = spellNames.GetSortedIndex((int)numC.Value);
                    break;
            }
        }
        private void nameC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            switch (command.Opcode)
            {
                case 0xE0:
                    numC.Value = attackNames.GetUnsortedIndex(nameC.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    numC.Value = spellNames.GetUnsortedIndex(nameC.SelectedIndex);
                    break;
                default:
                    numC.Value = nameC.SelectedIndex;
                    break;
            }
        }
        private void doNothingA_CheckedChanged(object sender, EventArgs e)
        {
            doNothingA.ForeColor = doNothingA.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            if (doNothingA.Checked)
            {
                nameA.Enabled = false;
                numA.Enabled = false;
            }
            else
            {
                nameA.Enabled = true;
                numA.Enabled = true;
                numA_ValueChanged(null, null);
            }
        }
        private void doNothingB_CheckedChanged(object sender, EventArgs e)
        {
            doNothingB.ForeColor = doNothingB.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            if (doNothingB.Checked)
            {
                nameB.Enabled = false;
                numB.Enabled = false;
            }
            else
            {
                nameB.Enabled = true;
                numB.Enabled = true;
                numB_ValueChanged(null, null);
            }
        }
        private void doNothingC_CheckedChanged(object sender, EventArgs e)
        {
            doNothingC.ForeColor = doNothingC.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (this.Updating)
                return;
            if (doNothingC.Checked)
            {
                nameC.Enabled = false;
                numC.Enabled = false;
            }
            else
            {
                nameC.Enabled = true;
                numC.Enabled = true;
                numC_ValueChanged(null, null);
            }
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            WriteToCommand();
            this.command.Modified = true;
            this.Tag = this.command;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
