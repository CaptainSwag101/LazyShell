using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class BattleScripts : Form
    {
        #region Variables

        private long checksum;
        private Monsters monsterEditor;
        public BattleScript[] battleScripts { get { return Model.BattleScripts; } set { Model.BattleScripts = value; } }
        private BattleScript battleScript { get { return battleScripts[index]; } set { battleScripts[index] = value; } }
        public BattleScript BattleScript { get { return battleScript; } set { battleScript = value; } }
        private DDlistName spellNames { get { return Model.SpellNames; } set { Model.SpellNames = value; } }
        private DDlistName attackNames { get { return Model.AttackNames; } set { Model.AttackNames = value; } }
        private DDlistName itemNames { get { return Model.ItemNames; } set { Model.ItemNames = value; } }
        public int index { get { return monsterEditor.Index; } set { monsterEditor.Index = value; } }
        private bool updatingProperties = false;
        private Bitmap monsterImage;
        private BattleScriptCommand command;
        private ArrayList battleCommands = new ArrayList();
        public ArrayList BattleCommands { get { return battleCommands; } }
        private int treeCounter;
        private int currentDepth;
        private bool counterCmd;
        private ArrayList copiedCmds;
        private TreeNode selectedNode;
        private TreeNode editedBatNode;
        Previewer bp;
        //
        private Monster[] monsters { get { return Model.Monsters; } set { Model.Monsters = value; } }
        private Monster monster { get { return monsters[index]; } set { monsters[index] = value; } }
        private bool waitBothCoords = false;
        private bool overTarget = false;
        #endregion
        // Constructor
        public BattleScripts(Monsters monsterEditor)
        {
            this.monsterEditor = monsterEditor;
            checksum = Do.GenerateChecksum(battleScripts);
            Settings.Default.Keystrokes[0x20] = "\x20";
            InitializeComponent();
            InitializeBattleScriptsEditor();
        }
        #region Functions
        public void InitializeBattleScriptsEditor()
        {
            buttonInsert.Enabled = false;
            buttonApply.Enabled = false;
            panelDoOneOfThree.Visible = false;
            panelIfTargetValue.Visible = false;
            panelMemoryCompare.Visible = false;
            AlignCommandGUI(null);
            ResetAllControls();

            Cursor.Current = Cursors.WaitCursor;
            BattleScriptTree.BeginUpdate();
            ParseBattleScript(battleScript);
            BattleScriptTree.Nodes.Clear();
            counterCmd = false;
            for (treeCounter = 0; treeCounter < battleCommands.Count; treeCounter++)
            {
                currentDepth = 1;
                BattleScriptTree.Nodes.Add(AddNode());
            }
            BattleScriptTree.ExpandAll();
            UpdateBattleScriptsFreeSpace();
            BattleScriptTree.EndUpdate();

            this.monsterTargetArrowX.Value = monster.CursorX;
            this.monsterTargetArrowY.Value = monster.CursorY;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
            //
            Cursor.Current = Cursors.Arrow;
        }
        public void RefreshBattleScriptsEditor()
        {
            Point p = Do.GetTreeViewScrollPos(BattleScriptTree);
            BattleScriptTree.BeginUpdate();
            BattleScriptTree.Nodes.Clear();
            counterCmd = false;
            for (treeCounter = 0; treeCounter < battleCommands.Count; treeCounter++)
            {
                currentDepth = 1;
                BattleScriptTree.Nodes.Add(AddNode());
            }
            BattleScriptTree.ExpandAll();
            UpdateBattleScriptsFreeSpace();
            BattleScriptTree.EndUpdate();
            BattleScriptTree.SelectedNode = selectedNode;
            p.X = 0;
            Do.SetTreeViewScrollPos(BattleScriptTree, p);

            this.monsterTargetArrowX.Value = monster.CursorX;
            this.monsterTargetArrowY.Value = monster.CursorY;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        //
        public TreeNode AddNode()
        {
            int thisDepth = currentDepth;
            TreeNode treeNode = new TreeNode();
            TreeNode treeNodeSub = new TreeNode();

            BattleScriptCommand bsc = (BattleScriptCommand)battleCommands[treeCounter];

            if (bsc.CommandID == 0xFF)
            {
                if (!counterCmd) treeNode = treeNodeSub.Nodes.Add("Start Counter Commands");
                else treeNode = treeNodeSub.Nodes.Add("End Counter Commands");
            }

            else treeNode = treeNodeSub.Nodes.Add(bsc.ToString());

            treeNode.Tag = bsc;
            treeNode.Checked = bsc.Set;
            if (bsc.Set)
            {
                treeNode.ForeColor = Color.Red;
                selectedNode = treeNode;
            }

            if (bsc.CommandID == 0xFC)
            {
                while (currentDepth >= thisDepth && bsc.CommandID != 0xFE && treeCounter + 1 < battleCommands.Count)
                {
                    treeCounter++;
                    bsc = (BattleScriptCommand)battleCommands[treeCounter];
                    currentDepth++; treeNode.Nodes.Add(AddNode());
                }
            }

            else if (bsc.CommandID == 0xFD)
            {
                treeNode.BackColor = Color.FromArgb(255, 255, 255, 160);
            }

            else if (bsc.CommandID == 0xFE)
            {
                treeNode.BackColor = Color.FromArgb(255, 255, 255, 160);
                if (counterCmd) currentDepth = 1;
                else currentDepth = 0;
            }

            else if (bsc.CommandID == 0xFF)
            {
                treeNode.BackColor = Color.FromArgb(255, 160, 255, 160);

                if (!counterCmd)
                {
                    while (currentDepth >= thisDepth && treeCounter + 1 < battleCommands.Count)
                    {
                        counterCmd = true;   // set to true

                        treeCounter++;
                        bsc = (BattleScriptCommand)battleCommands[treeCounter];
                        currentDepth++; treeNode.Nodes.Add(AddNode());
                    }
                }
            }

            return treeNode;
        }
        //
        public void ParseBattleScript(BattleScript source)
        {
            byte[] commandData;
            battleCommands.Clear();
            while ((commandData = source.NextCommand()) != null)
                battleCommands.Add(CreateCommand(commandData));
            // done parsing Battle Script
            source.CommandIndex = 0;
        }
        private void AssembleBattleScript(BattleScript dest)
        {
            byte[] script;
            int count = 0;
            BattleScriptCommand bsc;

            for (int i = 0; i < battleCommands.Count; i++)
            {
                bsc = (BattleScriptCommand)battleCommands[i];
                count += bsc.Length;
            }

            script = new byte[count];
            count = 0;
            for (int i = 0; i < battleCommands.Count; i++)
            {
                bsc = (BattleScriptCommand)battleCommands[i];
                bsc.CommandData.CopyTo(script, count);
                count += bsc.Length;
            }

            dest.Script = script;
        }
        private BattleScriptCommand CreateCommand(byte[] commandData)
        {
            BattleScriptCommand cmd;
            byte opcode = commandData[0];

            switch (opcode)
            {
                case 0xEC:
                    cmd = new BattleCommandEC(commandData);
                    break;
                case 0xFB:
                    cmd = new BattleCommandFB(commandData);
                    break;
                case 0xFD:
                    cmd = new BattleCommandFD(commandData);
                    break;
                case 0xFE:
                    cmd = new BattleCommandFE(commandData);
                    break;
                case 0xFF:
                    cmd = new BattleCommandFF(commandData);
                    break;
                case 0xE2:
                    cmd = new BattleCommandE2(commandData);
                    break;
                case 0xE3:
                    cmd = new BattleCommandE3(commandData, Model.BattleDialogues);
                    break;
                case 0xE5:
                    cmd = new BattleCommandE5(commandData);
                    break;
                case 0xE8:
                    cmd = new BattleCommandE8(commandData);
                    break;
                case 0xED:
                    cmd = new BattleCommandED(commandData);
                    break;
                case 0xEF:
                    cmd = new BattleCommandEF(commandData, spellNames);
                    break;
                case 0xF1:
                    cmd = new BattleCommandF1(commandData);
                    break;
                case 0xE6:
                    cmd = new BattleCommandE6(commandData);
                    break;
                case 0xEB:
                    cmd = new BattleCommandEB(commandData);
                    break;
                case 0xF2:
                    cmd = new BattleCommandF2(commandData);
                    break;
                case 0xF3:
                    cmd = new BattleCommandF3(commandData);
                    break;
                case 0xE0:
                    cmd = new BattleCommandE0(commandData, attackNames);
                    break;
                case 0xE7:
                    cmd = new BattleCommandE7(commandData);
                    break;
                case 0xEA:
                    cmd = new BattleCommandEA(commandData);
                    break;
                case 0xF0:
                    cmd = new BattleCommandF0(commandData, spellNames);
                    break;
                case 0xF4:
                    cmd = new BattleCommandF4(commandData);
                    break;
                case 0xFC:
                    cmd = new BattleCommandFC(commandData, spellNames, Model.ItemNames);
                    break;
                default:
                    if (opcode < 0xE0)
                        cmd = new BattleCommandLE0(commandData, attackNames);
                    else
                        throw new Exception("Invalid Opcode");
                    break;
            }

            return cmd;
        }
        private void AddCommand(BattleScriptCommand cmd)
        {
            foreach (BattleScriptCommand bsc in battleCommands)
                bsc.Set = false;

            BattleScriptTree.ExpandAll();

            int index = 0;
            if (!Do.GetNodeIndex(BattleScriptTree.SelectedNode, BattleScriptTree.Nodes, ref index))
            {
                MessageBox.Show("Must select a command in the command list to the left before inserting a new command.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (index + 1 < this.BattleScriptTree.GetNodeCount(true))
                battleCommands.Insert(index + 1, cmd);
            else if (index + 1 == this.BattleScriptTree.GetNodeCount(true))
                battleCommands.Insert(index, cmd);
            else
                battleCommands.Insert(0, cmd);
            cmd.Set = true;

            AssembleBattleScript(battleScript);
            RefreshBattleScriptsEditor();
        }
        private void ReplaceCommand(BattleScriptCommand cmd)
        {
            foreach (BattleScriptCommand bsc in battleCommands)
                bsc.Set = false;

            cmd = (BattleScriptCommand)editedBatNode.Tag;
            cmd.Set = true;

            AssembleBattleScript(battleScript);
            RefreshBattleScriptsEditor();
        }
        private void EditCurrentCommand()
        {
            this.command.editable = true;

            buttonInsert.Enabled = true;
            buttonApply.Enabled = true;

            switch (command.CommandID)
            {
                case 0xEC: BatScrExitBattle(command); break;
                case 0xFD: BatScrWaitOneTurn(command); break;
                case 0xFE: BatScrWaitOneTurnRestart(command); break;
                case 0xFF: break;
                case 0xE2: BatScrTargetSet(command); break;
                case 0xE3: BatScrRunBattleDialogue(command); break;
                case 0xE5: BatScrRunBattleEvent(command); break;
                case 0xE8: BatScrMemoryClear(command); break;
                case 0xED: BatScrGenerateRandomNumber(command); break;
                case 0xEF: BatScrDoOneSpell(command); break;
                case 0xF1: BatScrRunObjectSequence(command); break;
                case 0xE6:
                    if (command.Option == 0x00)
                        BatScrMemoryIncrement(command);
                    else if (command.Option == 0x01)
                        BatScrMemoryDecrement(command);
                    break;
                case 0xEB:
                    if (command.Option == 0x01)
                        BatScrTargetNullInvincibility(command);
                    if (command.Option == 0x00)
                        BatScrTargetSetInvincibility(command);
                    break;
                case 0xF2:
                    if (command.Option == 0x00)
                        BatScrTargetDisable(command);
                    else if (command.Option == 0x01)
                        BatScrTargetEnable(command);
                    break;
                case 0xF3:
                    if (command.Option == 0x01)
                        BatScrCommandDisable(command);
                    else if (command.Option == 0x00)
                        BatScrCommandEnable(command);
                    break;
                case 0xE0: BatScrDoOneOfThreeAttacks(command); break;
                case 0xE7:
                    if (command.Option == 0x01)
                        BatScrMemoryClearBits(command);
                    else if (command.Option == 0x00)
                        BatScrMemorySetBits(command);
                    break;
                case 0xEA:
                    if (command.Option == 0x00)
                        BatScrTargetRemove(command);
                    else if (command.Option == 0x01)
                        BatScrTargetCall(command);
                    break;
                case 0xF0: BatScrDoOneOfThreeSpells(command); break;
                case 0xF4: BatScrSetItems(command); break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01: BatScrIfAttackedByCommand(command); break;
                        case 0x02: BatScrIfAttackedBySpell(command); break;
                        case 0x03: BatScrIfAttackedByItem(command); break;
                        case 0x04: BatScrIfAttackedByElement(command); break;
                        case 0x05: BatScrIfAttacked(command); break;
                        case 0x06: BatScrIfTargetHPIsBelow(command); break;
                        case 0x07: BatScrIfHPIsBelow(command); break;
                        case 0x08: BatScrIfTargetAffectedBy(command); break;
                        case 0x09: BatScrIfTargetNotAffectedBy(command); break;
                        case 0x0A: BatScrIfAttackPhaseEqualTo(command); break;
                        case 0x0C: BatScrIfMemoryLessThan(command); break;
                        case 0x0D: BatScrIfMemoryGreaterThan(command); break;
                        case 0x10:
                            if (command.CommandData[2] == 0x00)
                                BatScrIfTargetAlive(command);
                            else if (command.CommandData[2] == 0x01)
                                BatScrIfTargetDead(command); break;
                        case 0x11: BatScrIfMemoryBitsSet(command); break;
                        case 0x12: BatScrIfMemoryBitsClear(command); break;
                        case 0x13: BatScrIfInFormation(command); break;
                        case 0x14: BatScrIfOnlyOneAlive(command); break;
                        default: break;
                    }
                    break;
                default:
                    if (command.CommandID < 0xE0 || command.CommandID == 0xFB)
                        BatScrDoOneAttack(command);
                    else
                        throw new Exception("Invalid Opcode");
                    break;
            }
        }
        // Disassembler Commands
        private void ControlDisassemble()
        {
            buttonInsert.Enabled = true;
            buttonApply.Enabled = false;
            ResetAllControls();

            switch (listBoxCommands.SelectedIndex)
            {
                case 0: BatScrCommandDisable(new BattleCommandF3(new byte[] { 0xF3, 0x01, 0x00 })); break;
                case 1: BatScrCommandEnable(new BattleCommandF3(new byte[] { 0xF3, 0x00, 0x00 })); break;
                case 2: BatScrDoOneAttack(new BattleCommandLE0(new byte[] { 0x00 }, this.attackNames)); break;
                case 3: BatScrDoOneOfThreeAttacks(new BattleCommandE0(new byte[] { 0xE0, 0x00, 0x00, 0x00 }, this.attackNames)); break;
                case 4: BatScrDoOneOfThreeSpells(new BattleCommandF0(new byte[] { 0xF0, 0x00, 0x00, 0x00 }, this.spellNames)); break;
                case 5: BatScrDoOneSpell(new BattleCommandEF(new byte[] { 0xEF, 0x00 }, this.spellNames)); break;
                case 6: BatScrExitBattle(new BattleCommandEC(new byte[] { 0xEC })); break;
                case 7: BatScrGenerateRandomNumber(new BattleCommandED(new byte[] { 0xED, 0x00 })); break;
                case 8: BatScrIfAttackPhaseEqualTo(new BattleCommandFC(new byte[] { 0xFC, 0x0A, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 9: BatScrIfAttacked(new BattleCommandFC(new byte[] { 0xFC, 0x05, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 10: BatScrIfAttackedByCommand(new BattleCommandFC(new byte[] { 0xFC, 0x01, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 11: BatScrIfAttackedByElement(new BattleCommandFC(new byte[] { 0xFC, 0x04, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 12: BatScrIfAttackedByItem(new BattleCommandFC(new byte[] { 0xFC, 0x03, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 13: BatScrIfAttackedBySpell(new BattleCommandFC(new byte[] { 0xFC, 0x02, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 14: BatScrIfHPIsBelow(new BattleCommandFC(new byte[] { 0xFC, 0x07, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 15: BatScrIfInFormation(new BattleCommandFC(new byte[] { 0xFC, 0x13, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 16: BatScrIfMemoryBitsClear(new BattleCommandFC(new byte[] { 0xFC, 0x12, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 17: BatScrIfMemoryBitsSet(new BattleCommandFC(new byte[] { 0xFC, 0x11, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 18: BatScrIfMemoryGreaterThan(new BattleCommandFC(new byte[] { 0xFC, 0x0D, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 19: BatScrIfMemoryLessThan(new BattleCommandFC(new byte[] { 0xFC, 0x0C, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 20: BatScrIfOnlyOneAlive(new BattleCommandFC(new byte[] { 0xFC, 0x14, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 21: BatScrIfTargetAffectedBy(new BattleCommandFC(new byte[] { 0xFC, 0x08, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 22: BatScrIfTargetAlive(new BattleCommandFC(new byte[] { 0xFC, 0x10, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 23: BatScrIfTargetDead(new BattleCommandFC(new byte[] { 0xFC, 0x10, 0x01, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 24: BatScrIfTargetHPIsBelow(new BattleCommandFC(new byte[] { 0xFC, 0x06, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 25: BatScrIfTargetNotAffectedBy(new BattleCommandFC(new byte[] { 0xFC, 0x09, 0x00, 0x00 }, this.spellNames, Model.ItemNames)); break;
                case 26: BatScrMemoryClear(new BattleCommandE8(new byte[] { 0xE8, 0x00 })); break;
                case 27: BatScrMemoryClearBits(new BattleCommandE7(new byte[] { 0xE7, 0x01, 0x00, 0x00 })); break;
                case 28: BatScrMemoryDecrement(new BattleCommandE6(new byte[] { 0xE6, 0x01, 0x00 })); break;
                case 29: BatScrMemoryIncrement(new BattleCommandE6(new byte[] { 0xE6, 0x00, 0x00 })); break;
                case 30: BatScrMemorySetBits(new BattleCommandE7(new byte[] { 0xE7, 0x00, 0x00, 0x00 })); break;
                case 31: BatScrRunBattleDialogue(new BattleCommandE3(new byte[] { 0xE3, 0x00 }, Model.BattleDialogues)); break;
                case 32: BatScrRunBattleEvent(new BattleCommandE5(new byte[] { 0xE5, 0x00 })); break;
                case 33: BatScrRunObjectSequence(new BattleCommandF1(new byte[] { 0xF1, 0x00 })); break;
                case 34: BatScrSetItems(new BattleCommandF4(new byte[] { 0xF4, 0x00, 0x00, 0x00 })); break;
                case 35: BatScrTargetCall(new BattleCommandEA(new byte[] { 0xEA, 0x01, 0x00, 0x00 })); break;
                case 36: BatScrTargetDisable(new BattleCommandF2(new byte[] { 0xF2, 0x00, 0x00 })); break;
                case 37: BatScrTargetEnable(new BattleCommandF2(new byte[] { 0xF2, 0x01, 0x00 })); break;
                case 38: BatScrTargetNullInvincibility(new BattleCommandEB(new byte[] { 0xEB, 0x01, 0x00 })); break;
                case 39: BatScrTargetRemove(new BattleCommandEA(new byte[] { 0xEA, 0x00, 0x00, 0x00 })); break;
                case 40: BatScrTargetSet(new BattleCommandE2(new byte[] { 0xE2, 0x00 })); break;
                case 41: BatScrTargetSetInvincibility(new BattleCommandEB(new byte[] { 0xEB, 0x00, 0x00 })); break;
                case 42: BatScrWaitOneTurn(new BattleCommandFD(new byte[] { 0xFD })); break;
                case 43: BatScrWaitOneTurnRestart(new BattleCommandFE(new byte[] { 0xFE })); break;
                default: AlignCommandGUI(null); break;
            }
        }
        private void ControlAssemble()
        {
        }
        private void BatScrDoOneAttack(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true;
            panelIfTargetValue.Visible = false;
            panelMemoryCompare.Visible = false;
            labelDoA.Text = "Attack..."; labelDoB.Text = "Index...";

            this.nameA.Items.AddRange(this.attackNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            numA.Maximum = 128;

            this.command = cmd;

            if (cmd.editable)
            {
                if (cmd.CommandData[0] != 0xFB)
                    nameA.SelectedIndex = attackNames.GetIndexFromNum((int)cmd.CommandData[0]);
                else
                    doNothingA.Checked = true;
            }
            else
                nameA.SelectedIndex = attackNames.GetIndexFromNum((int)numA.Value);
        }
        private void BatScrDoOneOfThreeAttacks(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Attack..."; labelDoB.Text = "Index...";

            this.nameA.Items.AddRange(this.attackNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            this.nameB.Items.AddRange(this.attackNames.GetNames());
            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameB.ItemHeight = 15;
            this.nameC.Items.AddRange(this.attackNames.GetNames());
            this.nameC.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameC.ItemHeight = 15;
            numA.Maximum = numB.Maximum = numC.Maximum = 128;

            this.command = cmd;

            if (cmd.editable)
            {
                if (cmd.CommandData[1] != 0xFB)
                    nameA.SelectedIndex = attackNames.GetIndexFromNum((int)cmd.CommandData[1]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[2] != 0xFB)
                    nameB.SelectedIndex = attackNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingB.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameC.SelectedIndex = attackNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingC.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = attackNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = attackNames.GetIndexFromNum((int)numB.Value);
                nameC.SelectedIndex = attackNames.GetIndexFromNum((int)numC.Value);
            }
        }
        private void BatScrDoOneSpell(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Spell..."; labelDoB.Text = "Index...";

            this.command = cmd;

            this.nameA.Items.AddRange(this.spellNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            numA.Maximum = 127;
            if (cmd.editable)
                this.nameA.SelectedIndex = spellNames.GetIndexFromNum(cmd.CommandData[1]);
            else
                nameA.SelectedIndex = spellNames.GetIndexFromNum((int)numA.Value);
        }
        private void BatScrDoOneOfThreeSpells(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Spell..."; labelDoB.Text = "Index...";

            this.command = cmd;

            this.nameA.Items.AddRange(this.spellNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            this.nameB.Items.AddRange(this.spellNames.GetNames());
            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameB.ItemHeight = 15;
            this.nameC.Items.AddRange(this.spellNames.GetNames());
            this.nameC.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameC.ItemHeight = 15;
            numA.Maximum = numB.Maximum = numC.Maximum = 127;

            if (cmd.editable)
            {
                if (cmd.CommandData[1] != 0xFB)
                    nameA.SelectedIndex = spellNames.GetIndexFromNum((int)cmd.CommandData[1]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[2] != 0xFB)
                    nameB.SelectedIndex = spellNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingB.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameC.SelectedIndex = spellNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingC.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = spellNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = spellNames.GetIndexFromNum((int)numB.Value);
                nameC.SelectedIndex = spellNames.GetIndexFromNum((int)numC.Value);
            }
        }
        private void BatScrGenerateRandomNumber(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = ""; labelDoB.Text = "Index...";

            this.command = cmd;

            if (cmd.editable)
                this.numA.Value = cmd.CommandData[1];
        }
        private void BatScrRunBattleDialogue(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Battle Dialogue..."; labelDoB.Text = "Index...";

            this.command = cmd;

            this.nameA.BackColor = SystemColors.Window;
            this.nameA.DropDownWidth = 256;
            this.nameA.Items.AddRange(cmd.GetBattleDialogueNames());
            this.nameA.DrawMode = DrawMode.Normal;
            if (cmd.editable)
            {
                this.nameA.SelectedIndex = cmd.CommandData[1];
                this.numA.Value = cmd.CommandData[1];
            }
            else
            {
                this.nameA.SelectedIndex = 0;
                this.numA.Value = 0;
            }
        }
        private void BatScrRunBattleEvent(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Battle Event..."; labelDoB.Text = "Index...";

            this.command = cmd;

            this.nameA.BackColor = SystemColors.Window;
            this.nameA.Items.AddRange(Lists.Numerize(Lists.BattleEventNames));
            this.nameA.DrawMode = DrawMode.Normal;
            this.numA.Maximum = 0x66;
            if (cmd.editable)
                nameA.SelectedIndex = cmd.CommandData[1];
            else
                this.nameA.SelectedIndex = 0;
        }
        private void BatScrRunObjectSequence(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = ""; labelDoB.Text = "Object sequence...";

            this.command = cmd;

            if (cmd.editable)
                numA.Value = cmd.CommandData[1];
        }
        private void BatScrSetItems(BattleScriptCommand cmd)
        {
            numA.Enabled = false; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "Set Items..."; labelDoB.Text = "";

            this.command = cmd;

            this.nameA.BackColor = SystemColors.Window;
            this.nameA.Items.AddRange(new object[] {
                        "Remove Items",
                        "Return Items"});
            this.nameA.DrawMode = DrawMode.Normal;
            if (cmd.editable)
                nameA.SelectedIndex = cmd.CommandData[2];
            else
                nameA.SelectedIndex = 0;
        }
        private void BatScrIfAttackedByCommand(BattleScriptCommand cmd)
        {
            numA.Enabled = false; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = true; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "If attacked by CMD..."; labelDoB.Text = "";

            this.command = cmd;

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

            if (cmd.editable)
            {
                nameA.SelectedIndex = (int)(cmd.CommandData[2] - 2);
                nameB.SelectedIndex = (int)(cmd.CommandData[3] - 2);
            }
            else
            {
                nameA.SelectedIndex = 0;
                nameB.SelectedIndex = 0;
            }
        }
        private void BatScrIfAttackedByItem(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "If attacked by item..."; labelDoB.Text = "Number";

            this.command = cmd;

            this.nameA.Items.AddRange(Model.ItemNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            this.nameB.Items.AddRange(Model.ItemNames.GetNames());
            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameB.ItemHeight = 15;
            if (cmd.editable)
            {
                if (cmd.CommandData[2] != 0xFB)
                    nameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingB.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)numB.Value);
            }
        }
        private void BatScrIfAttackedBySpell(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = "If attacked by spell..."; labelDoB.Text = "Number";

            this.command = cmd;

            this.nameA.Items.AddRange(this.spellNames.GetNames());
            this.nameA.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameA.ItemHeight = 15;
            this.nameB.Items.AddRange(this.spellNames.GetNames());
            this.nameB.DrawMode = DrawMode.OwnerDrawFixed;
            this.nameB.ItemHeight = 15;

            if (cmd.editable)
            {
                if (cmd.CommandData[2] != 0xFB)
                    nameA.SelectedIndex = spellNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameB.SelectedIndex = spellNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingB.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = spellNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = spellNames.GetIndexFromNum((int)numB.Value);
            }
        }
        private void BatScrIfHPIsBelow(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = ""; labelDoB.Text = "HP...";

            this.command = cmd;

            numA.Maximum = 0xFFFF;

            if (cmd.editable)
                numA.Value = Bits.GetShort(cmd.CommandData, 2);
        }
        private void BatScrIfInFormation(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Visible = true; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            labelDoA.Text = ""; labelDoB.Text = "Formation...";

            this.command = cmd;

            numA.Maximum = 0x1FF;

            if (cmd.editable)
                numA.Value = Bits.GetShort(cmd.CommandData, 2);
        }
        private void BatScrTargetCall(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Call Target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[3];
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetDisable(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Disable target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

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
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetEnable(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Enable target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

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
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetNullInvincibility(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Null target invincibility"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetRemove(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Remove target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetSet(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Set target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[1];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetSetInvincibility(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "Set target invincibility"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetAffectedBy(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "If target"; labelTargetB.Text = ""; labelTargetC.Text = "...is affected by";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);
            this.effects.Items.AddRange(new object[] {
                        "Mute",
                        "Sleep",
                        "Poison",
                        "Fear",
                        "Mushroom",
                        "Scarecrow",
                        "Invincibility"});

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[2];
                effects.SetItemChecked(0, (cmd.CommandData[3] & 0x01) == 0x01);
                effects.SetItemChecked(1, (cmd.CommandData[3] & 0x02) == 0x02);
                effects.SetItemChecked(2, (cmd.CommandData[3] & 0x04) == 0x04);
                effects.SetItemChecked(3, (cmd.CommandData[3] & 0x08) == 0x08);
                effects.SetItemChecked(4, (cmd.CommandData[3] & 0x20) == 0x20);
                effects.SetItemChecked(5, (cmd.CommandData[3] & 0x40) == 0x40);
                effects.SetItemChecked(6, (cmd.CommandData[3] & 0x80) == 0x80);
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetAlive(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "If target alive"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetDead(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "If target dead"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetHPIsBelow(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = true; effects.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "If Target"; labelTargetB.Text = "HP is below"; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[2];
                targetNum.Value = cmd.CommandData[3] * 16;
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetNotAffectedBy(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = "If target"; labelTargetB.Text = ""; labelTargetC.Text = "...is not affected by";

            this.command = cmd;

            this.target.Items.AddRange(Lists.TargetNames);
            this.effects.Items.AddRange(new object[] {
                        "Mute",
                        "Sleep",
                        "Poison",
                        "Fear",
                        "Mushroom",
                        "Scarecrow",
                        "Invincibility"});

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[2];
                effects.SetItemChecked(0, (cmd.CommandData[3] & 0x01) == 0x01);
                effects.SetItemChecked(1, (cmd.CommandData[3] & 0x02) == 0x02);
                effects.SetItemChecked(2, (cmd.CommandData[3] & 0x04) == 0x04);
                effects.SetItemChecked(3, (cmd.CommandData[3] & 0x08) == 0x08);
                effects.SetItemChecked(4, (cmd.CommandData[3] & 0x20) == 0x20);
                effects.SetItemChecked(5, (cmd.CommandData[3] & 0x40) == 0x40);
                effects.SetItemChecked(6, (cmd.CommandData[3] & 0x80) == 0x80);
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfAttackedByElement(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetA.Text = ""; labelTargetB.Text = ""; labelTargetC.Text = "If attacked by element";

            this.command = cmd;

            this.effects.Items.AddRange(new object[] {
                        "Ice",
                        "Thunder",
                        "Fire",
                        "Jump"});

            if (cmd.editable)
            {
                effects.SetItemChecked(0, (cmd.CommandData[2] & 0x10) == 0x10);
                effects.SetItemChecked(1, (cmd.CommandData[2] & 0x20) == 0x20);
                effects.SetItemChecked(2, (cmd.CommandData[2] & 0x40) == 0x40);
                effects.SetItemChecked(3, (cmd.CommandData[2] & 0x80) == 0x80);
            }
        }
        private void BatScrCommandDisable(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetC.Text = "Command disable...";

            this.command = cmd;

            effects.Items.AddRange(new object[] {
                        "Attack",
                        "Special",
                        "Item"});
            if (cmd.editable)
            {
                effects.SetItemChecked(0, (cmd.CommandData[2] & 0x01) == 0x01);
                effects.SetItemChecked(1, (cmd.CommandData[2] & 0x02) == 0x02);
                effects.SetItemChecked(2, (cmd.CommandData[2] & 0x04) == 0x04);
            }
        }
        private void BatScrCommandEnable(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = true; panelMemoryCompare.Visible = false;
            labelTargetC.Text = "Command enable...";

            this.command = cmd;

            effects.Items.AddRange(new object[] {
                        "Attack",
                        "Special",
                        "Item"});
            if (cmd.editable)
            {
                effects.SetItemChecked(0, (cmd.CommandData[2] & 0x01) == 0x01);
                effects.SetItemChecked(1, (cmd.CommandData[2] & 0x02) == 0x02);
                effects.SetItemChecked(2, (cmd.CommandData[2] & 0x04) == 0x04);
            }
        }
        private void BatScrMemoryClear(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "Clear memory address";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[1];
        }
        private void BatScrMemoryDecrement(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "Decrement mem addr";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
        }
        private void BatScrMemoryIncrement(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "Increment mem addr";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
        }
        private void BatScrIfMemoryGreaterThan(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryB.Text = "Greater than";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                this.comparison.Value = cmd.CommandData[3];
            }
        }
        private void BatScrIfMemoryLessThan(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryB.Text = "Less than";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                this.comparison.Value = cmd.CommandData[3];
            }
        }
        private void BatScrIfAttackPhaseEqualTo(BattleScriptCommand cmd)
        {
            memory.Enabled = false; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryB.Text = "If attack phase =";

            if (cmd.editable)
            {
                this.comparison.Value = cmd.CommandData[2];
            }
            else
            {
                this.comparison.Value = 0;
            }
        }
        private void BatScrMemoryClearBits(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "Clear memory address";
            labelMemoryC.Text = "Bits";

            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrMemorySetBits(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "Set memory address";
            labelMemoryC.Text = "Bits";

            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrIfMemoryBitsClear(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryC.Text = "Bits clear";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrIfMemoryBitsSet(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryC.Text = "Bits set";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrExitBattle(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            this.command = cmd;
            AlignCommandGUI(null);
        }
        private void BatScrIfAttacked(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            this.command = cmd;
            AlignCommandGUI(null);
        }
        private void BatScrIfOnlyOneAlive(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Visible = false; panelIfTargetValue.Visible = false; panelMemoryCompare.Visible = false;
            this.command = cmd;
            AlignCommandGUI(null);
        }
        private void BatScrWaitOneTurn(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Visible = false;
            panelIfTargetValue.Visible = false;
            panelMemoryCompare.Visible = false;
            this.command = cmd;
            AlignCommandGUI(null);
        }
        private void BatScrWaitOneTurnRestart(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Visible = false;
            panelIfTargetValue.Visible = false;
            panelMemoryCompare.Visible = false;
            this.command = cmd;
            AlignCommandGUI(null);
        }
        // modify commands
        private int RemoveCommand(TreeNodeCollection nodes, int count)
        {
            if (nodes.Count <= 0) return count;

            TreeNode tn;
            for (int i = nodes.Count - 1; i >= 0; i--, count--)
            {
                tn = nodes[i];
                count = RemoveCommand(tn.Nodes, count);
                if (tn.Checked)
                    battleCommands.RemoveAt(count);
            }
            return count;
        }
        private void RemoveAllCommands()
        {
            BattleScriptCommand cmd = new BattleCommandFF(new byte[] { 0xFF });
            battleCommands.Clear();
            battleCommands.Add(cmd);
            battleCommands.Add(cmd);

            AssembleBattleScript(battleScript);
            RefreshBattleScriptsEditor();
        }
        private int MoveUpCommand(TreeNodeCollection nodes, int count)
        {
            if (nodes.Count <= 0) return count;
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked)
                    battleCommands.Reverse(count - 1, 2);
                count = MoveUpCommand(tn.Nodes, count + 1);
            }
            return count;
        }
        private int MoveDownCommand(TreeNodeCollection nodes, int count)
        {
            if (nodes.Count <= 0) return count;
            TreeNode tn;
            for (int i = nodes.Count - 1; i >= 0; i--, count--)
            {
                tn = nodes[i];
                count = MoveDownCommand(tn.Nodes, count);
                if (tn.Checked)
                    battleCommands.Reverse(count, 2);
            }
            return count;
        }
        private void CopyCommands(TreeNodeCollection nodes)
        {
            BattleScriptCommand bat, batCopy;
            byte[] temp;
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked)
                {
                    bat = (BattleScriptCommand)tn.Tag;
                    temp = new byte[bat.Length]; bat.CommandData.CopyTo(temp, 0);
                    batCopy = CreateCommand(temp);
                    copiedCmds.Add(batCopy);
                }
                CopyCommands(tn.Nodes);
            }
        }
        //
        private void UpdateBattleScriptsFreeSpace()
        {
            int bytesLeft = CalculateBattleScriptsLength();
            this.BatScrLabel3.Text = " " + bytesLeft.ToString() + " bytes left";
            this.BatScrLabel3.BackColor = bytesLeft < 0 ? Color.Red : SystemColors.Control;
        }
        private int CalculateBattleScriptsLength()
        {
            int block1Size = 0x274A;//0x3959F3 - 0x3932AA;
            int block2Size = 0x0C00;//0x39FFFF - 0x39F400;
            int totalSize = block1Size + block2Size;

            int length = 0;

            int i = 0;
            for (; i < battleScripts.Length && length + battleScripts[i].ScriptLength < block1Size; i++)
                length += battleScripts[i].ScriptLength;

            if (i < battleScripts.Length - 1)
                length = block1Size;

            for (; i < battleScripts.Length; i++)
                length += battleScripts[i].ScriptLength;

            return totalSize - length - 1;
        }
        //
        private void SetInitialBits(byte bits)
        {
            updatingProperties = true;

            if ((bits & 0x01) != 0) bit0.Checked = true;
            if ((bits & 0x02) != 0) bit1.Checked = true;
            if ((bits & 0x04) != 0) bit2.Checked = true;
            if ((bits & 0x08) != 0) bit3.Checked = true;
            if ((bits & 0x10) != 0) bit4.Checked = true;
            if ((bits & 0x20) != 0) bit5.Checked = true;
            if ((bits & 0x40) != 0) bit6.Checked = true;
            if ((bits & 0x80) != 0) bit7.Checked = true;

            updatingProperties = false;
        }
        private void ResetAllControls()
        {
            updatingProperties = true;

            nameA.BackColor = SystemColors.ControlDarkDark;
            nameA.Items.Clear(); nameA.ResetText();
            nameB.BackColor = SystemColors.ControlDarkDark;
            nameB.Items.Clear(); nameB.ResetText();
            nameC.BackColor = SystemColors.ControlDarkDark;
            nameC.Items.Clear(); nameC.ResetText();
            numA.Minimum = 0; numA.Maximum = 255; numA.Value = 0;
            numB.Minimum = 0; numB.Maximum = 255; numB.Value = 0;
            numC.Minimum = 0; numC.Maximum = 255; numC.Value = 0;
            doNothingA.Checked = false;
            doNothingB.Checked = false;
            doNothingC.Checked = false;
            labelDoA.Text = "";
            labelDoB.Text = "";

            target.Items.Clear(); target.ResetText();
            targetNum.Value = 0;
            effects.Items.Clear();
            labelTargetA.Text = "";
            labelTargetB.Text = "";
            labelTargetC.Text = "";

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

            updatingProperties = false;
        }
        private void AlignCommandGUI(GroupBox panel)
        {
            if (panel == null)
            {
                panel1.Height = 28;
                panel2.Top = 0;
            }
            else if (panel.Visible)
            {
                panel1.Height = panel.Height + 28;
                panel2.Top = panel.Height;
            }
        }
        public void Assemble()
        {
            if (CalculateBattleScriptsLength() >= 0)
            {
                AssembleAllBattleScripts();
                checksum = Do.GenerateChecksum(battleScripts);
            }
            else
                MessageBox.Show("There is not enough available space to save the battle scripts to.\n\nThe battle scripts were not saved.", "LAZY SHELL");
        }
        public void AssembleAllBattleScripts()
        {
            // Assemble BattleScript Data
            // Block 1
            ushort offset = 0x32AA; // Starting point for storage
            int bank = 0x390000;
            int i = 0;

            int pointerTable = 0x3930AA;

            for (; i < battleScripts.Length && offset + battleScripts[i].ScriptLength <= 0x59F3; i++)
            {
                // write to the pointer array
                Bits.SetShort(Model.Data, pointerTable + (i * 2), offset);
                // write to the data
                offset += battleScripts[i].Assemble(bank + offset);
            }
            // Block 2
            offset = 0xF400;
            for (; i < battleScripts.Length && offset + battleScripts[i].ScriptLength <= 0xFFFF; i++)
            {
                // write to the pointer array
                Bits.SetShort(Model.Data, pointerTable + (i * 2), offset);
                // write to the data
                offset += battleScripts[i].Assemble(bank + offset);
            }

            if (i != battleScripts.Length)
                System.Windows.Forms.MessageBox.Show("Battle Scripts exceed max size, decrease total size to save correctly.\nNote: Saving stops when out of space.");
            // DONE ASSEMBLING BATTLE SCRIPT DATA
        }
        public bool ChecksumNotChanged()
        {
            if (Do.GenerateChecksum(battleScripts) == this.checksum)
                return true;
            return false;
        }
        #endregion
        #region Event Handlers
        private void BattleScripts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bp != null)
                bp.Close();
        }
        private void Scripts_KeyDown(object sender, KeyEventArgs e)
        {
            if (!BattleScriptTree.Enabled)
                return;
            if (!BattleScriptTree.Focused)
                return;

            switch (e.KeyData)
            {
                case Keys.Control | Keys.A: Do.SelectAllNodes(BattleScriptTree.Nodes, true); break;
                case Keys.Control | Keys.D: Do.SelectAllNodes(BattleScriptTree.Nodes, false); break;
                case Keys.Control | Keys.C: BatScrCopyCommand_Click(null, null); break;
                case Keys.Control | Keys.V: BatScrPasteCommand_Click(null, null); break;
                case Keys.Control | Keys.Up:
                case Keys.Shift | Keys.Up: BatScrMoveUp_Click(null, null); break;
                case Keys.Control | Keys.Down:
                case Keys.Shift | Keys.Down: BatScrMoveDown_Click(null, null); break;
                case Keys.Delete: BatScrDeleteCommand_Click(null, null); break;
            }
        }
        private void BattleScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BattleScriptCommand bsc = (BattleScriptCommand)e.Node.Tag;

            toolStripTextBox1.Text = BitConverter.ToString(bsc.CommandData);
        }
        private void BattleScriptTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BatScrEditCommand_Click(null, null);
        }
        private void BattleScriptTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            BattleScriptCommand bsc = (BattleScriptCommand)e.Node.Tag;
            if (bsc.CommandID == 0xFF && e.Node.Checked)
            {
                e.Node.Checked = false;
                bsc.Set = false;
                return;
            }
            else
                bsc.Set = e.Node.Checked;
        }
        private void BattleScriptTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Do.AddHistory(this, index, e.Node, "NodeMouseClick", true);
            //
            BattleScriptTree.SelectedNode = e.Node;
            if (e.Button != MouseButtons.Right) return;
            goToToolStripMenuItem.Click -= goToDialogue_Click;
            goToToolStripMenuItem.Click -= goToEvent_Click;
            BattleScriptCommand temp = (BattleScriptCommand)BattleScriptTree.SelectedNode.Tag;
            if (temp.CommandID == 0xE3)
            {
                e.Node.ContextMenuStrip = contextMenuStripGoto;
                goToToolStripMenuItem.Text = "Edit dialogue...";
                goToToolStripMenuItem.Click += new EventHandler(goToDialogue_Click);
            }
            else if (temp.CommandID == 0xE5)
            {
                e.Node.ContextMenuStrip = contextMenuStripGoto;
                goToToolStripMenuItem.Text = "Edit event...";
                goToToolStripMenuItem.Click += new EventHandler(goToEvent_Click);
            }
        }
        // command panels
        private void panelDoOneOfThree_VisibleChanged(object sender, EventArgs e)
        {
            AlignCommandGUI(panelDoOneOfThree);
        }
        private void panelMemoryCompare_VisibleChanged(object sender, EventArgs e)
        {
            AlignCommandGUI(panelMemoryCompare);
        }
        private void panelIfTargetValue_VisibleChanged(object sender, EventArgs e)
        {
            AlignCommandGUI(panelIfTargetValue);
        }
        // context menustrip
        private void goToDialogue_Click(object sender, EventArgs e)
        {
            if (BattleScriptTree.SelectedNode == null) return;

            BattleScriptCommand temp = (BattleScriptCommand)BattleScriptTree.SelectedNode.Tag;
            int num = temp.CommandData[1];

            if (Model.Program.Dialogues == null || !Model.Program.Dialogues.Visible)
                Model.Program.CreateDialoguesWindow();

            Model.Program.Dialogues.BattleDialogues.Index = num;
            Model.Program.Dialogues.BringToFront();
        }
        private void goToEvent_Click(object sender, EventArgs e)
        {
            if (BattleScriptTree.SelectedNode == null) return;

            BattleScriptCommand temp = (BattleScriptCommand)BattleScriptTree.SelectedNode.Tag;
            int num = temp.CommandData[1];

            if (Model.Program.Animations == null || !Model.Program.Animations.Visible)
                Model.Program.CreateAnimationsWindow();

            Model.Program.Animations.Category = 7;
            Model.Program.Animations.Index = num;
            Model.Program.Animations.BringToFront();
        }
        // Command properties
        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlDisassemble();
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            byte[] commandData = new byte[command.Length];
            command.CommandData.CopyTo(commandData, 0);
            AddCommand(CreateCommand(commandData));
            listBoxCommands.Focus();
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (editedBatNode == null) return;
            ReplaceCommand(command);
            BattleScriptTree.Focus();
            BatScrEditCommand_Click(null, null);
            buttonApply.Focus();
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xFC:
                    if (command.CommandData[1] == 0x02)
                        goto case 0xF0;
                    if (command.CommandData[1] == 0x03)
                        Do.DrawName(
                            sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                            Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, false, Model.MenuBG_);
                    break;
                case 0xEF:
                case 0xF0:
                    if (e.Index < 0 || e.Index >= 128)
                        break;
                    Do.DrawName(
                        sender, e, new BattleDialoguePreview(), Model.SpellNames,
                        Model.SpellNames.GetNumFromIndex(e.Index) < 64 ? Model.FontMenu : Model.FontDialogue,
                        Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, false, Model.MenuBG_);
                    break;
                case 0xE0:
                    goto default;
                default:
                    Do.DrawName(
                        sender, e, new BattleDialoguePreview(), Model.AttackNames, Model.FontDialogue,
                        Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, true, Model.MenuBG_);
                    break;
            }
        }
        private void numA_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xED:
                case 0xF1:
                case 0xF3:
                case 0xF4:
                    command.ModifyCommand(0, (byte)numA.Value);
                    break;
                case 0xE0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    nameA.SelectedIndex = attackNames.GetIndexFromNum((int)numA.Value);
                    break;
                case 0xE3:
                case 0xE5:
                    command.ModifyCommand(1, (byte)numA.Value);
                    nameA.SelectedIndex = (int)numA.Value;
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    nameA.SelectedIndex = spellNames.GetIndexFromNum((int)numA.Value);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x02:
                            command.ModifyCommand(2, (byte)numA.Value);
                            nameA.SelectedIndex = spellNames.GetIndexFromNum((int)numA.Value); break;
                        case 0x03:
                            command.ModifyCommand(2, (byte)numA.Value);
                            nameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)numA.Value); break;
                        case 0x07:
                        case 0x13:
                            Bits.SetShort(command.CommandData, 2, (ushort)numA.Value);
                            break;
                    }
                    break;
                default:
                    command.ModifyCommand(0, (byte)numA.Value);
                    nameA.SelectedIndex = attackNames.GetIndexFromNum((int)numA.Value);
                    break;
            }
        }
        private void nameA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    numA.Value = attackNames.GetNumFromIndex(nameA.SelectedIndex);
                    break;
                case 0xE3:
                case 0xE5:
                    command.ModifyCommand(1, (byte)numA.Value);
                    numA.Value = nameA.SelectedIndex;
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    numA.Value = spellNames.GetNumFromIndex(nameA.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01:
                            command.ModifyCommand(2, (byte)(nameA.SelectedIndex + 2));
                            break;
                        case 0x02:
                            command.ModifyCommand(2, (byte)numA.Value);
                            numA.Value = spellNames.GetNumFromIndex(nameA.SelectedIndex);
                            break;
                        case 0x03:
                            command.ModifyCommand(2, (byte)numA.Value);
                            numA.Value = Model.ItemNames.GetNumFromIndex(nameA.SelectedIndex);
                            break;
                    }
                    break;
                default:
                    command.ModifyCommand(0, (byte)numA.Value);
                    numA.Value = attackNames.GetNumFromIndex(nameA.SelectedIndex);
                    break;
            }
        }
        private void numB_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    nameB.SelectedIndex = attackNames.GetIndexFromNum((int)numB.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    nameB.SelectedIndex = spellNames.GetIndexFromNum((int)numB.Value);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x02:
                            command.ModifyCommand(3, (byte)numB.Value);
                            nameB.SelectedIndex = spellNames.GetIndexFromNum((int)numB.Value); break;
                        case 0x03:
                            command.ModifyCommand(3, (byte)numB.Value);
                            nameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)numB.Value); break;
                    }
                    break;
                default:
                    command.ModifyCommand(2, (byte)numB.Value);
                    break;
            }
        }
        private void nameB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    numB.Value = attackNames.GetNumFromIndex(nameB.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    numB.Value = spellNames.GetNumFromIndex(nameB.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01:
                            command.ModifyCommand(3, (byte)(nameB.SelectedIndex + 2));
                            break;
                        case 0x02:
                            command.ModifyCommand(3, (byte)numB.Value);
                            numB.Value = spellNames.GetNumFromIndex(nameB.SelectedIndex);
                            break;
                        case 0x03:
                            command.ModifyCommand(3, (byte)numB.Value);
                            numB.Value = Model.ItemNames.GetNumFromIndex(nameB.SelectedIndex);
                            break;
                    }
                    break;
                default:
                    command.ModifyCommand(2, (byte)numB.Value);
                    numB.Value = nameB.SelectedIndex;
                    break;
            }
        }
        private void numC_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    nameC.SelectedIndex = attackNames.GetIndexFromNum((int)numC.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    nameC.SelectedIndex = spellNames.GetIndexFromNum((int)numC.Value);
                    break;
                default:
                    command.ModifyCommand(3, (byte)numC.Value);
                    break;
            }
        }
        private void nameC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    numC.Value = attackNames.GetNumFromIndex(nameC.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    numC.Value = spellNames.GetNumFromIndex(nameC.SelectedIndex);
                    break;
                default:
                    command.ModifyCommand(3, (byte)numC.Value);
                    numC.Value = nameC.SelectedIndex;
                    break;
            }
        }
        private void doNothingA_CheckedChanged(object sender, EventArgs e)
        {
            doNothingA.ForeColor = doNothingA.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            if (doNothingA.Checked)
            {
                nameA.Enabled = false;
                numA.Enabled = false;
                switch (command.CommandID)
                {
                    case 0xE0:
                    case 0xE3:
                    case 0xE5:
                    case 0xEF:
                    case 0xF0:
                        command.ModifyCommand(1, 0xFB);
                        break;
                    case 0xFC:
                        switch (command.Option)
                        {
                            case 0x02:
                            case 0x03: command.ModifyCommand(2, 0xFB); break;
                        }
                        break;
                    default: command.ModifyCommand(0, 0xFB); break;
                }
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
            if (updatingProperties) return;
            if (doNothingB.Checked)
            {
                nameB.Enabled = false;
                numB.Enabled = false;
                switch (command.CommandID)
                {
                    case 0xFC:
                        switch (command.Option)
                        {
                            case 0x02:
                            case 0x03:
                                command.ModifyCommand(3, 0xFB); break;
                        }
                        break;
                    default: command.ModifyCommand(2, 0xFB); break;
                }
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
            if (updatingProperties) return;
            if (doNothingC.Checked)
            {
                nameC.Enabled = false;
                numC.Enabled = false;
                command.ModifyCommand(3, 0xFB);
            }
            else
            {
                nameC.Enabled = true;
                numC.Enabled = true;
                numC_ValueChanged(null, null);
            }
        }
        private void target_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE2:
                    command.ModifyCommand(1, (byte)target.SelectedIndex); break;
                case 0xEA:
                    command.ModifyCommand(3, (byte)target.SelectedIndex); break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x10: command.ModifyCommand(3, (byte)target.SelectedIndex); break;
                        default: command.ModifyCommand(2, (byte)target.SelectedIndex); break;
                    }
                    break;
                default:
                    command.ModifyCommand(2, (byte)target.SelectedIndex); break;
            }
        }
        private void targetNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            command.ModifyCommand(3, (byte)(targetNum.Value / 16));
        }
        private void effects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            byte temp = 0;

            if (command.CommandID == 0xFC && (command.Option == 0x08 || command.Option == 0x09))
            {
                if (effects.GetItemChecked(0)) temp |= 0x01;
                if (effects.GetItemChecked(1)) temp |= 0x02;
                if (effects.GetItemChecked(2)) temp |= 0x04;
                if (effects.GetItemChecked(3)) temp |= 0x08;
                if (effects.GetItemChecked(4)) temp |= 0x20;
                if (effects.GetItemChecked(5)) temp |= 0x40;
                if (effects.GetItemChecked(6)) temp |= 0x80;
                command.ModifyCommand(3, temp);
            }
            else if (command.CommandID == 0xFC && command.Option == 0x04)
            {
                if (effects.GetItemChecked(0)) temp |= 0x10;
                if (effects.GetItemChecked(1)) temp |= 0x20;
                if (effects.GetItemChecked(2)) temp |= 0x40;
                if (effects.GetItemChecked(3)) temp |= 0x80;
                command.ModifyCommand(2, temp);
            }
            else
            {
                if (effects.GetItemChecked(0)) temp |= 0x01;
                if (effects.GetItemChecked(1)) temp |= 0x02;
                if (effects.GetItemChecked(2)) temp |= 0x04;
                command.ModifyCommand(2, temp);
            }
        }
        private void memory_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            switch (command.CommandID)
            {
                case 0xE8:
                    command.ModifyCommand(1, (byte)((ulong)(memory.Value) & 0x0F)); break;
                case 0xE6:
                    command.ModifyCommand(2, (byte)((ulong)(memory.Value) & 0x0F)); break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x0A: command.ModifyCommand(2, (byte)memory.Value); break;
                        case 0x0C:
                        case 0x0D:
                            command.ModifyCommand(2, (byte)((ulong)(memory.Value) & 0x0F)); break;
                        default:
                            command.ModifyCommand(2, (byte)((ulong)(memory.Value) & 0x0F)); break;
                    }
                    break;
                default:
                    command.ModifyCommand(2, (byte)((ulong)(memory.Value) & 0x0F));
                    break;
            }
        }
        private void comparison_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            if (command.CommandID == 0xFC && command.Option == 0x0A)
                command.ModifyCommand(2, (byte)comparison.Value);
            else
                command.ModifyCommand(3, (byte)comparison.Value);
        }
        private void bit0_CheckedChanged(object sender, EventArgs e)
        {
            bit0.ForeColor = bit0.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit1_CheckedChanged(object sender, EventArgs e)
        {
            bit1.ForeColor = bit1.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit2_CheckedChanged(object sender, EventArgs e)
        {
            bit2.ForeColor = bit2.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit3_CheckedChanged(object sender, EventArgs e)
        {
            bit3.ForeColor = bit3.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit4_CheckedChanged(object sender, EventArgs e)
        {
            bit4.ForeColor = bit4.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit5_CheckedChanged(object sender, EventArgs e)
        {
            bit5.ForeColor = bit5.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit6_CheckedChanged(object sender, EventArgs e)
        {
            bit6.ForeColor = bit6.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        private void bit7_CheckedChanged(object sender, EventArgs e)
        {
            bit7.ForeColor = bit7.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (updatingProperties) return;
            byte temp = 0;
            if (bit0.Checked) temp |= 0x01; command.ModifyCommand(3, temp);
            if (bit1.Checked) temp |= 0x02; command.ModifyCommand(3, temp);
            if (bit2.Checked) temp |= 0x04; command.ModifyCommand(3, temp);
            if (bit3.Checked) temp |= 0x08; command.ModifyCommand(3, temp);
            if (bit4.Checked) temp |= 0x10; command.ModifyCommand(3, temp);
            if (bit5.Checked) temp |= 0x20; command.ModifyCommand(3, temp);
            if (bit6.Checked) temp |= 0x40; command.ModifyCommand(3, temp);
            if (bit7.Checked) temp |= 0x80; command.ModifyCommand(3, temp);
        }
        // Editing Buttons
        private void BatScrCopyCommand_Click(object sender, EventArgs e)
        {
            copiedCmds = new ArrayList();
            BattleScriptTree.ExpandAll();
            CopyCommands(BattleScriptTree.Nodes);
        }
        private void BatScrMoveUp_Click(object sender, EventArgs e)
        {
            BattleScriptCommand bat = (BattleScriptCommand)battleCommands[0];
            if (!bat.Set)
            {
                BattleScriptTree.ExpandAll();
                MoveUpCommand(BattleScriptTree.Nodes, 0);

                AssembleBattleScript(battleScript);
                RefreshBattleScriptsEditor();
            }
        }
        private void BatScrMoveDown_Click(object sender, EventArgs e)
        {
            BattleScriptCommand bat = (BattleScriptCommand)battleCommands[battleCommands.Count - 2];
            if (!bat.Set)
            {
                BattleScriptTree.ExpandAll();
                MoveDownCommand(BattleScriptTree.Nodes, BattleScriptTree.GetNodeCount(true) - 1);

                AssembleBattleScript(battleScript);
                RefreshBattleScriptsEditor();
            }
        }
        private void BatScrPasteCommand_Click(object sender, EventArgs e)
        {
            if (copiedCmds == null) return;
            byte[] commandData;
            foreach (BattleScriptCommand bat in copiedCmds)
            {
                commandData = new byte[bat.Length];
                bat.CommandData.CopyTo(commandData, 0);
                AddCommand(CreateCommand(commandData));
            }

            AssembleBattleScript(battleScript);
            RefreshBattleScriptsEditor();
        }
        private void BatScrDeleteCommand_Click(object sender, EventArgs e)
        {
            ResetAllControls();
            buttonInsert.Enabled = false;
            buttonApply.Enabled = false;
            //
            panelDoOneOfThree.Visible = false;
            panelIfTargetValue.Visible = false;
            panelMemoryCompare.Visible = false;
            AlignCommandGUI(null);
            //
            BattleScriptTree.ExpandAll();
            RemoveCommand(BattleScriptTree.Nodes, BattleScriptTree.GetNodeCount(true) - 1);
            AssembleBattleScript(battleScript);
            RefreshBattleScriptsEditor();
        }
        private void BatScrEditCommand_Click(object sender, EventArgs e)
        {
            if (BattleScriptTree.SelectedNode == null) return;

            ResetAllControls();

            this.command = (BattleScriptCommand)BattleScriptTree.SelectedNode.Tag;
            this.editedBatNode = BattleScriptTree.SelectedNode;

            // Edit Command
            if (command.CommandID != 0xFF)
            {
                BattleScriptTree.ExpandAll();
                EditCurrentCommand();
            }
            else
                MessageBox.Show(
                    "Cannot edit command(s).\n\nThe two counter command barriers cannot be removed, modified, or moved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BatScrExpandAll_Click(object sender, EventArgs e)
        {
            BattleScriptTree.ExpandAll();
            BattleScriptTree.Focus();
        }
        private void BatScrCollapseAll_Click(object sender, EventArgs e)
        {
            BattleScriptTree.CollapseAll();
            BattleScriptTree.Focus();
        }
        private void BatScrClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to clear all commands from the current script.\n\nGo ahead with process?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                RemoveAllCommands();

            BattleScriptTree.Focus();
        }
        private void battlePreview_Click(object sender, EventArgs e)
        {
            if (bp == null || !bp.Visible)
                bp = new Previewer(index, PreviewType.Battle);
            else
                bp.Reload(index, PreviewType.Battle);
            bp.Show();
            bp.BringToFront();
        }
        // image
        private void pictureBoxMonster_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void pictureBoxMonster_MouseMove(object sender, MouseEventArgs e)
        {
            int x = 15 - (e.X / 8); int y = 15 - (e.Y / 8);
            if (x > 15) x = 15; if (x < 0) x = 0;
            if (y > 15) y = 15; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left)
            {
                if (overTarget)
                {
                    if (monsterTargetArrowX.Value != x && monsterTargetArrowY.Value != y)
                        waitBothCoords = true;
                    monsterTargetArrowX.Value = x;
                    waitBothCoords = false;
                    monsterTargetArrowY.Value = y;
                }
            }
            else
            {
                if ((128 - (monsterTargetArrowX.Value * 8) > e.X && 128 - (monsterTargetArrowX.Value * 8) < e.X + 16) &&
                    (128 - (monsterTargetArrowY.Value * 8) > e.Y && 128 - (monsterTargetArrowY.Value * 8) < e.Y + 16))
                {
                    pictureBoxMonster.Cursor = Cursors.Hand;
                    overTarget = true;
                }
                else
                {
                    pictureBoxMonster.Cursor = Cursors.Arrow;
                    overTarget = false;
                }
            }
        }
        private void pictureBoxMonster_MouseUp(object sender, MouseEventArgs e)
        {
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void pictureBoxMonster_Paint(object sender, PaintEventArgs e)
        {
            if (monsterImage != null)
                e.Graphics.DrawImage(monsterImage, 0, 0);
        }
        private void monsterTargetArrowX_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorX = (byte)monsterTargetArrowX.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void monsterTargetArrowY_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorY = (byte)monsterTargetArrowY.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        // toolstrip
        public void Import()
        {
            new IOElements((Element[])Model.BattleScripts, index, "IMPORT BATTLE SCRIPTS...").ShowDialog();
            InitializeBattleScriptsEditor();
        }
        public void Export()
        {
            new IOElements((Element[])Model.BattleScripts, index, "EXPORT BATTLE SCRIPTS...").ShowDialog();
            InitializeBattleScriptsEditor();
        }
        public void Clear()
        {
            new ClearElements(Model.BattleScripts, index, "CLEAR BATTLE SCRIPTS...").ShowDialog();
            InitializeBattleScriptsEditor();
        }
        #endregion
    }
}
