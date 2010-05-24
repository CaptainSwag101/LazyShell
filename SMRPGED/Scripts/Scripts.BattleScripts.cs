using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SMRPGED.Properties;
using SMRPGED.ScriptsEditor;
using SMRPGED.ScriptsEditor.Commands;

namespace SMRPGED.ScriptsEditor
{
    public partial class Scripts : Form
    {
        #region Variables
        private int currentBattleScript = 0;
        private BattleScript[] battleScripts;
        public BattleScript[] BattleScripts { get { return battleScripts; } set { battleScripts = value; } }

        private NPCProperties npcProperties;
        private Bitmap spriteImage;
        private int[] spritePixels;
        private int imageWidth;
        private int imageHeight;

        private string[] targetNames = new string[0x30];
        private string[] battleEventNames = new string[0x67];

        private BattleScriptCommand command;
        private ArrayList battleCommands = new ArrayList();

        private int treeCounter;
        private int currentDepth;
        private bool counterCmd;
        private ArrayList copiedCmds;
        private TreeNode selectedNode;
        private TreeNode editedBatNode;

        // Get / set the scrollbar position of the treeview
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        #endregion

        #region Methods
        private void InitializeBattleScriptsEditor()
        {
            BattleScriptTree.BeginUpdate();

            ParseBattleScript(battleScripts[currentBattleScript]);

            BattleScriptTree.Nodes.Clear();
            counterCmd = false;

            for (treeCounter = 0; treeCounter < battleCommands.Count; treeCounter++)
            {
                currentDepth = 1;
                BattleScriptTree.Nodes.Add(AddNode());
            }

            BattleScriptTree.ExpandAll();

            UpdateBattleScriptsFreeSpace();

            npcProperties = new NPCProperties(data, 0);

            spritePixels = npcProperties.CreateImage(3, true, (int)(monsterNumber.Value + 0x100));
            imageWidth = npcProperties.ImageWidth;
            imageHeight = npcProperties.ImageHeight;
            if (spritePixels.Length == 0) { spritePixels = new int[2]; imageWidth = 1; imageHeight = 1; }
            spriteImage = new Bitmap(DrawImageFromIntArr(spritePixels, imageWidth, imageHeight));
            pictureBoxMonster.Invalidate();

            BattleScriptTree.EndUpdate();
        }
        private void RefreshBattleScriptsEditor()
        {
            Point p = GetTreeViewScrollPos(BattleScriptTree);
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
            SetTreeViewScrollPos(BattleScriptTree, p);
        }

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
                treeNode.BackColor = Color.Yellow;
            }

            else if (bsc.CommandID == 0xFE)
            {
                treeNode.BackColor = Color.Yellow;
                if (counterCmd) currentDepth = 1;
                else currentDepth = 0;
            }

            else if (bsc.CommandID == 0xFF)
            {
                treeNode.BackColor = Color.FromArgb(255, 0, 255, 0);

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
        private void ParseBattleScript(BattleScript source)
        {
            try
            {
                byte[] commandData;
                battleCommands.Clear();

                while (true)
                {
                    commandData = source.NextCommand();
                    battleCommands.Add(CreateCommand(commandData));
                }
            }
            catch
            {
                // done parsing Battle Script
                source.CommandIndex = 0;
            }
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
                    cmd = new BattleCommandE2(commandData, targetNames);
                    break;
                case 0xE3:
                    cmd = new BattleCommandE3(commandData, universal.BattleDialogues);
                    break;
                case 0xE5:
                    cmd = new BattleCommandE5(commandData, battleEventNames);
                    break;
                case 0xE8:
                    cmd = new BattleCommandE8(commandData);
                    break;
                case 0xED:
                    cmd = new BattleCommandED(commandData);
                    break;
                case 0xEF:
                    cmd = new BattleCommandEF(commandData, universal.SpellNames);
                    break;
                case 0xF1:
                    cmd = new BattleCommandF1(commandData);
                    break;
                case 0xE6:
                    cmd = new BattleCommandE6(commandData);
                    break;
                case 0xEB:
                    cmd = new BattleCommandEB(commandData, targetNames);
                    break;
                case 0xF2:
                    cmd = new BattleCommandF2(commandData);
                    break;
                case 0xF3:
                    cmd = new BattleCommandF3(commandData);
                    break;
                case 0xE0:
                    cmd = new BattleCommandE0(commandData, universal.AttackNames);
                    break;
                case 0xE7:
                    cmd = new BattleCommandE7(commandData);
                    break;
                case 0xEA:
                    cmd = new BattleCommandEA(commandData, targetNames);
                    break;
                case 0xF0:
                    cmd = new BattleCommandF0(commandData, universal.SpellNames);
                    break;
                case 0xF4:
                    cmd = new BattleCommandF4(commandData);
                    break;
                case 0xFC:
                    cmd = new BattleCommandFC(commandData, universal.SpellNames, universal.ItemNames, targetNames);
                    break;
                default:
                    if (opcode < 0xE0)
                        cmd = new BattleCommandLE0(commandData, universal.AttackNames);
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

            int selectedNode = GetFullNodeIndex(BattleScriptTree.SelectedNode, BattleScriptTree.Nodes);
            if (selectedNode + 1 < this.BattleScriptTree.GetNodeCount(true))
                battleCommands.Insert(selectedNode + 1, cmd);
            else if (selectedNode + 1 == this.BattleScriptTree.GetNodeCount(true))
                battleCommands.Insert(selectedNode, cmd);
            else
                battleCommands.Insert(0, cmd);
            cmd.Set = true;

            AssembleBattleScript(battleScripts[currentBattleScript]);
            RefreshBattleScriptsEditor();
        }
        private void ReplaceCommand(BattleScriptCommand cmd)
        {
            foreach (BattleScriptCommand bsc in battleCommands)
                bsc.Set = false;

            cmd = (BattleScriptCommand)editedBatNode.Tag;
            cmd.Set = true;

            AssembleBattleScript(battleScripts[currentBattleScript]);
            RefreshBattleScriptsEditor();
        }
        private void EditCurrentCommand()
        {
            this.command.editable = true;

            button2.Enabled = true;
            button3.Enabled = true;

            switch (command.CommandID)
            {
                case 0xEC: BatScrExitBattle_Click(command); break;
                case 0xFD: BatScrWaitOneTurn_Click(command); break;
                case 0xFE: BatScrWaitOneTurnRestart_Click(command); break;
                case 0xFF: break;
                case 0xE2: BatScrTargetSet_Click(command); break;
                case 0xE3: BatScrRunBattleDialogue_Click(command); break;
                case 0xE5: BatScrRunBattleEvent_Click(command); break;
                case 0xE8: BatScrMemoryClear_Click(command); break;
                case 0xED: BatScrGenerateRandomNumber_Click(command); break;
                case 0xEF: BatScrDoOneSpell_Click(command); break;
                case 0xF1: BatScrRunObjectSequence_Click(command); break;
                case 0xE6:
                    if (command.Option == 0x00)
                        BatScrMemoryIncrement_Click(command);
                    else if (command.Option == 0x01)
                        BatScrMemoryDecrement_Click(command);
                    break;
                case 0xEB:
                    if (command.Option == 0x01)
                        BatScrTargetNullInvincibility_Click(command);
                    if (command.Option == 0x00)
                        BatScrTargetSetInvincibility_Click(command);
                    break;
                case 0xF2:
                    if (command.Option == 0x00)
                        BatScrTargetDisable_Click(command);
                    else if (command.Option == 0x01)
                        BatScrTargetEnable_Click(command);
                    break;
                case 0xF3:
                    if (command.Option == 0x01)
                        BatScrCommandDisable_Click(command);
                    else if (command.Option == 0x00)
                        BatScrCommandEnable_Click(command);
                    break;
                case 0xE0: BatScrDoOneOfThreeAttacks_Click(command); break;
                case 0xE7:
                    if (command.Option == 0x01)
                        BatScrMemoryClearBits_Click(command);
                    else if (command.Option == 0x00)
                        BatScrMemorySetBits_Click(command);
                    break;
                case 0xEA:
                    if (command.Option == 0x00)
                        BatScrTargetRemove_Click(command);
                    else if (command.Option == 0x01)
                        BatScrTargetCall_Click(command);
                    break;
                case 0xF0: BatScrDoOneOfThreeSpells_Click(command); break;
                case 0xF4: BatScrSetItems_Click(command); break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01: BatScrIfAttackedByCommand_Click(command); break;
                        case 0x02: BatScrIfAttackedBySpell_Click(command); break;
                        case 0x03: BatScrIfAttackedByItem_Click(command); break;
                        case 0x04: BatScrIfAttackedByElement_Click(command); break;
                        case 0x05: BatScrIfAttacked_Click(command); break;
                        case 0x06: BatScrIfTargetHPIsBelow_Click(command); break;
                        case 0x07: BatScrIfHPIsBelow_Click(command); break;
                        case 0x08: BatScrIfTargetAffectedBy_Click(command); break;
                        case 0x09: BatScrIfTargetNotAffectedBy_Click(command); break;
                        case 0x0A: BatScrIfAttackPhaseEqualTo_Click(command); break;
                        case 0x0C: BatScrIfMemoryLessThan_Click(command); break;
                        case 0x0D: BatScrIfMemoryGreaterThan_Click(command); break;
                        case 0x10:
                            if (command.CommandData[2] == 0x00)
                                BatScrIfTargetAlive_Click(command);
                            else if (command.CommandData[2] == 0x01)
                                BatScrIfTargetDead_Click(command); break;
                        case 0x11: BatScrIfMemoryBitsSet_Click(command); break;
                        case 0x12: BatScrIfMemoryBitsClear_Click(command); break;
                        case 0x13: BatScrIfInFormation_Click(command); break;
                        case 0x14: BatScrIfOnlyOneAlive_Click(command); break;
                        default: break;
                    }
                    break;
                default:
                    if (command.CommandID < 0xE0 || command.CommandID == 0xFB)
                        BatScrDoOneAttack_Click(command);
                    else
                        throw new Exception("Invalid Opcode");
                    break;
            }
        }
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

            AssembleBattleScript(battleScripts[currentBattleScript]);
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

        private void UpdateBattleScriptsFreeSpace()
        {
            this.BatScrLabel3.Text = "AVAILABLE BYTES: " + CalculateBattleScriptsLength().ToString();
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

        private string[] GetBattleEventNames()
        {
            System.Collections.Specialized.StringCollection batEvtNames = settings.BattleEventNames;
            string[] names = new string[batEvtNames.Count];

            for (int i = 0; i < batEvtNames.Count; i++)
            {
                names[i] = "[" + i.ToString("d3") + "]  " + batEvtNames[i];
            }

            return names;
        }
        private string[] GetTargetNames()
        {
            System.Collections.Specialized.StringCollection tgtNames = settings.TargetNames;
            string[] names = new string[tgtNames.Count];

            for (int i = 0; i < tgtNames.Count; i++)
            {
                names[i] = tgtNames[i];
            }

            return names;
        }

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

            nameA.Items.Clear(); nameA.ResetText();
            nameB.Items.Clear(); nameB.ResetText();
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

        private Point GetTreeViewScrollPos(TreeView treeView)
        {
            return new Point(
                GetScrollPos((int)treeView.Handle, SB_HORZ),
                GetScrollPos((int)treeView.Handle, SB_VERT));
        }
        private void SetTreeViewScrollPos(TreeView treeView, Point scrollPosition)
        {
            SetScrollPos((IntPtr)treeView.Handle, SB_HORZ, scrollPosition.X, true);
            SetScrollPos((IntPtr)treeView.Handle, SB_VERT, scrollPosition.Y, true);
        }

        // Importing / Exporting
        private void ExportBattleScript(int start, int count, string path)
        {
            this.scriptsModel.AssembleAllBattleScripts();

            path += "\\" + model.GetFileNameWithoutPath() + " - Battle Scripts\\";

            // Create Level Data directory
            if (!CreateDir(path))
                return;

            FileStream fs;
            BinaryWriter bw;
            try
            {
                for (int i = start; i < start + count; i++)
                {
                    // Create the file to store the level data
                    fs = new FileStream(path + "battleScript." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(battleScripts[i].Script);
                    bw.Close();
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("There was a problem exporting.", "PROBLEM EXPORTING",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImportBattleScript(int start, int count, string path)
        {
            FileStream fs;
            BinaryReader br;

            if (count == 1)
            {
                try
                {
                    fs = File.OpenRead(path);
                    br = new BinaryReader(fs);
                    battleScripts[start].Script = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo(battleScripts[start].Script, 0);
                    br.Close();
                    fs.Close();

                    monsterNumber_ValueChanged(null, null);
                }
                catch
                {
                    MessageBox.Show("There was a problem importing.", "PROBLEM IMPORTING",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    for (int i = start; i < start + count; i++)
                    {
                        if (!File.Exists(path + "battleScript." + i.ToString("d3") + ".bin"))
                            continue;
                        fs = File.OpenRead(path + "battleScript." + i.ToString("d3") + ".bin");
                        br = new BinaryReader(fs);
                        battleScripts[i].Script = new byte[fs.Length];
                        br.ReadBytes((int)fs.Length).CopyTo(battleScripts[i].Script, 0);
                        br.Close();
                        fs.Close();
                    }
                    monsterNumber_ValueChanged(null, null);
                }
                catch
                {
                    MessageBox.Show("There was a problem importing.", "PROBLEM IMPORTING",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Event Handlers
        private void monsterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            monsterNumber.Value = universal.MonsterNames.GetNum(monsterName.SelectedIndex);
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 255)
                return;

            char[] arr = universal.MonsterNames.GetName(e.Index).ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '.') arr[i] = (char)0x2A;
                if (arr[i] == '!') arr[i] = (char)0x7B;
                if (arr[i] == '-') arr[i] = (char)0x7D;
                if (arr[i] == '\'') arr[i] = (char)0x7E;
            }

            // set the palette
            int[] palette = new int[16];
            ushort color = 0; int r, g, b;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x01EF40);
                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);
                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }

            // set the pixels
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, arr, true);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void monsterNumber_ValueChanged(object sender, EventArgs e)
        {
            // Test code
            currentBattleScript = (int)monsterNumber.Value;
            monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum(currentBattleScript);

            button2.Enabled = false;
            button3.Enabled = false;
            panelDoOneOfThree.Enabled = false;
            panelIfTargetValue.Enabled = false;
            panelMemoryCompare.Enabled = false;
            ResetAllControls();

            InitializeBattleScriptsEditor();
        }
        private void pictureBoxMonster_Paint(object sender, PaintEventArgs e)
        {
            if (spriteImage != null)
                e.Graphics.DrawImage(spriteImage, 128 - (spriteImage.Width / 2), 128 - (spriteImage.Height / 2));
        }

        private void BattleScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BattleScriptCommand bsc = (BattleScriptCommand)e.Node.Tag;

            label1.Text = "HEX:  " + BitConverter.ToString(bsc.CommandData);
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
        }

        // Command properties
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            ResetAllControls();

            switch (listBox1.SelectedIndex)
            {
                case 0: BatScrDoOneAttack_Click(new BattleCommandLE0(new byte[] { 0x00 }, this.universal.AttackNames)); break;
                case 1: BatScrDoOneOfThreeAttacks_Click(new BattleCommandE0(new byte[] { 0xE0, 0x00, 0x00, 0x00 }, this.universal.AttackNames)); break;
                case 2: BatScrDoOneSpell_Click(new BattleCommandEF(new byte[] { 0xEF, 0x00 }, this.universal.SpellNames)); break;
                case 3: BatScrDoOneOfThreeSpells_Click(new BattleCommandF0(new byte[] { 0xF0, 0x00, 0x00, 0x00 }, this.universal.SpellNames)); break;
                case 4: BatScrRunBattleDialogue_Click(new BattleCommandE3(new byte[] { 0xE3, 0x00 }, universal.BattleDialogues)); break;
                case 5: BatScrRunBattleEvent_Click(new BattleCommandE5(new byte[] { 0xE5, 0x00 }, this.battleEventNames)); break;
                case 6: BatScrRunObjectSequence_Click(new BattleCommandF1(new byte[] { 0xF1, 0x00 })); break;
                case 7: BatScrTargetSet_Click(new BattleCommandE2(new byte[] { 0xE2, 0x00 }, this.targetNames)); break;
                case 8: BatScrTargetDisable_Click(new BattleCommandF2(new byte[] { 0xF2, 0x00, 0x00 })); break;
                case 9: BatScrTargetEnable_Click(new BattleCommandF2(new byte[] { 0xF2, 0x01, 0x00 })); break;
                case 10: BatScrTargetRemove_Click(new BattleCommandEA(new byte[] { 0xEA, 0x00, 0x00, 0x00 }, this.targetNames)); break;
                case 11: BatScrTargetCall_Click(new BattleCommandEA(new byte[] { 0xEA, 0x01, 0x00, 0x00 }, this.targetNames)); break;
                case 12: BatScrTargetSetInvincibility_Click(new BattleCommandEB(new byte[] { 0xEB, 0x00, 0x00 }, this.targetNames)); break;
                case 13: BatScrTargetNullInvincibility_Click(new BattleCommandEB(new byte[] { 0xEB, 0x01, 0x00 }, this.targetNames)); break;
                case 14: BatScrCommandDisable_Click(new BattleCommandF3(new byte[] { 0xF3, 0x01, 0x00 })); break;
                case 15: BatScrCommandEnable_Click(new BattleCommandF3(new byte[] { 0xF3, 0x00, 0x00 })); break;
                case 16: BatScrSetItems_Click(new BattleCommandF4(new byte[] { 0xF4, 0x00, 0x00, 0x00 })); break;
                case 17: BatScrGenerateRandomNumber_Click(new BattleCommandED(new byte[] { 0xED, 0x00 })); break;
                case 18: BatScrMemoryIncrement_Click(new BattleCommandE6(new byte[] { 0xE6, 0x00, 0x00 })); break;
                case 19: BatScrMemoryDecrement_Click(new BattleCommandE6(new byte[] { 0xE6, 0x01, 0x00 })); break;
                case 20: BatScrMemorySetBits_Click(new BattleCommandE7(new byte[] { 0xE7, 0x00, 0x00, 0x00 })); break;
                case 21: BatScrMemoryClearBits_Click(new BattleCommandE7(new byte[] { 0xE7, 0x01, 0x00, 0x00 })); break;
                case 22: BatScrMemoryClear_Click(new BattleCommandE8(new byte[] { 0xE8, 0x00 })); break;
                case 23: BatScrExitBattle_Click(new BattleCommandEC(new byte[] { 0xEC })); break;
                case 24: BatScrWaitOneTurn_Click(new BattleCommandFD(new byte[] { 0xFD })); break;
                case 25: BatScrWaitOneTurnRestart_Click(new BattleCommandFE(new byte[] { 0xFE })); break;
                case 26: BatScrIfAttackedByCommand_Click(new BattleCommandFC(new byte[] { 0xFC, 0x01, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 27: BatScrIfAttackedBySpell_Click(new BattleCommandFC(new byte[] { 0xFC, 0x02, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 28: BatScrIfAttackedByItem_Click(new BattleCommandFC(new byte[] { 0xFC, 0x03, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 29: BatScrIfAttackedByElement_Click(new BattleCommandFC(new byte[] { 0xFC, 0x04, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 30: BatScrIfAttacked_Click(new BattleCommandFC(new byte[] { 0xFC, 0x05, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 31: BatScrIfTargetHPIsBelow_Click(new BattleCommandFC(new byte[] { 0xFC, 0x06, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 32: BatScrIfTargetAffectedBy_Click(new BattleCommandFC(new byte[] { 0xFC, 0x08, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 33: BatScrIfTargetNotAffectedBy_Click(new BattleCommandFC(new byte[] { 0xFC, 0x09, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 34: BatScrIfTargetAlive_Click(new BattleCommandFC(new byte[] { 0xFC, 0x10, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 35: BatScrIfTargetDead_Click(new BattleCommandFC(new byte[] { 0xFC, 0x10, 0x01, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 36: BatScrIfHPIsBelow_Click(new BattleCommandFC(new byte[] { 0xFC, 0x07, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 37: BatScrIfInFormation_Click(new BattleCommandFC(new byte[] { 0xFC, 0x13, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 38: BatScrIfOnlyOneAlive_Click(new BattleCommandFC(new byte[] { 0xFC, 0x14, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 39: BatScrIfMemoryGreaterThan_Click(new BattleCommandFC(new byte[] { 0xFC, 0x0D, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 40: BatScrIfMemoryLessThan_Click(new BattleCommandFC(new byte[] { 0xFC, 0x0C, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 41: BatScrIfMemoryBitsSet_Click(new BattleCommandFC(new byte[] { 0xFC, 0x11, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 42: BatScrIfMemoryBitsClear_Click(new BattleCommandFC(new byte[] { 0xFC, 0x12, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                case 43: BatScrIfAttackPhaseEqualTo_Click(new BattleCommandFC(new byte[] { 0xFC, 0x0A, 0x00, 0x00 }, this.universal.SpellNames, this.universal.ItemNames, this.targetNames)); break;
                default: ; break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] commandData = new byte[command.Length];
            command.CommandData.CopyTo(commandData, 0);
            AddCommand(CreateCommand(commandData));
            listBox1.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (editedBatNode == null) return;
            ReplaceCommand(command);
            BattleScriptTree.Focus();
            BatScrEditCommand_Click(sender, e);
            button3.Focus();
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
                    nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numA.Value);
                    break;
                case 0xE3:
                case 0xE5:
                    command.ModifyCommand(1, (byte)numA.Value);
                    nameA.SelectedIndex = (int)numA.Value;
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numA.Value);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x02:
                            command.ModifyCommand(2, (byte)numA.Value);
                            nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numA.Value); break;
                        case 0x03:
                            command.ModifyCommand(2, (byte)numA.Value);
                            nameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)numA.Value); break;
                        case 0x07:
                        case 0x13:
                            BitManager.SetShort(command.CommandData, 2, (ushort)numA.Value);
                            break;
                    }
                    break;
                default:
                    command.ModifyCommand(0, (byte)numA.Value);
                    nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numA.Value);
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
                    numA.Value = universal.AttackNames.GetNumFromIndex(nameA.SelectedIndex);
                    break;
                case 0xE3:
                case 0xE5:
                    command.ModifyCommand(1, (byte)numA.Value);
                    numA.Value = nameA.SelectedIndex;
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(1, (byte)numA.Value);
                    numA.Value = universal.SpellNames.GetNumFromIndex(nameA.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01:
                            command.ModifyCommand(2, (byte)(nameA.SelectedIndex + 2));
                            break;
                        case 0x02:
                            command.ModifyCommand(2, (byte)numA.Value);
                            numA.Value = universal.SpellNames.GetNumFromIndex(nameA.SelectedIndex);
                            break;
                        case 0x03:
                            command.ModifyCommand(2, (byte)numA.Value);
                            numA.Value = universal.ItemNames.GetNumFromIndex(nameA.SelectedIndex);
                            break;
                    }
                    break;
                default:
                    command.ModifyCommand(0, (byte)numA.Value);
                    numA.Value = universal.AttackNames.GetNumFromIndex(nameA.SelectedIndex);
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
                    nameB.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numB.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numB.Value);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x02:
                            command.ModifyCommand(3, (byte)numB.Value);
                            nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numB.Value); break;
                        case 0x03:
                            command.ModifyCommand(3, (byte)numB.Value);
                            nameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)numB.Value); break;
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
                    numB.Value = universal.AttackNames.GetNumFromIndex(nameB.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(2, (byte)numB.Value);
                    numB.Value = universal.SpellNames.GetNumFromIndex(nameB.SelectedIndex);
                    break;
                case 0xFC:
                    switch (command.Option)
                    {
                        case 0x01:
                            command.ModifyCommand(3, (byte)(nameB.SelectedIndex + 2));
                            break;
                        case 0x02:
                            command.ModifyCommand(3, (byte)numB.Value);
                            numB.Value = universal.SpellNames.GetNumFromIndex(nameB.SelectedIndex);
                            break;
                        case 0x03:
                            command.ModifyCommand(3, (byte)numB.Value);
                            numB.Value = universal.ItemNames.GetNumFromIndex(nameB.SelectedIndex);
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
                    nameC.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numC.Value);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    nameC.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numC.Value);
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
                    numC.Value = universal.AttackNames.GetNumFromIndex(nameC.SelectedIndex);
                    break;
                case 0xEF:
                case 0xF0:
                    command.ModifyCommand(3, (byte)numC.Value);
                    numC.Value = universal.SpellNames.GetNumFromIndex(nameC.SelectedIndex);
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

                AssembleBattleScript(battleScripts[currentBattleScript]);
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

                AssembleBattleScript(battleScripts[currentBattleScript]);
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

            AssembleBattleScript(battleScripts[currentBattleScript]);
            RefreshBattleScriptsEditor();
        }
        private void BatScrDeleteCommand_Click(object sender, EventArgs e)
        {
            ResetAllControls();
            button2.Enabled = false;
            button3.Enabled = false;
            panelDoOneOfThree.Enabled = false;
            panelIfTargetValue.Enabled = false;
            panelMemoryCompare.Enabled = false;

            BattleScriptTree.ExpandAll();

            RemoveCommand(BattleScriptTree.Nodes, BattleScriptTree.GetNodeCount(true) - 1);

            AssembleBattleScript(battleScripts[currentBattleScript]);
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
                    "Cannot modify this command. The two counter command barriers are necessary\nfor all battle scripts and cannot be removed, modified, or moved.",
                    "WARNING: CANNOT MODIFY COMMAND",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                "Delete all commands in the current monster's battle script?",
                "DELETE ALL COMMANDS",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                RemoveAllCommands();

            BattleScriptTree.Focus();
        }
        private void battlePreview_Click(object sender, EventArgs e)
        {
            PreviewBattle();
        }

        // Disassembler Commands
        private void BatScrDoOneAttack_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Attack..."; labelDoB.Text = "Number...";

            this.nameA.Items.AddRange(this.universal.AttackNames.GetNames());
            numA.Maximum = 128;

            this.command = cmd;

            if (cmd.editable)
            {
                if (cmd.CommandData[0] != 0xFB)
                    nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)cmd.CommandData[0]);
                else
                    doNothingA.Checked = true;
            }
            else
                nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numA.Value);
        }
        private void BatScrDoOneOfThreeAttacks_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Attack..."; labelDoB.Text = "Number...";

            this.nameA.Items.AddRange(this.universal.AttackNames.GetNames());
            this.nameB.Items.AddRange(this.universal.AttackNames.GetNames());
            this.nameC.Items.AddRange(this.universal.AttackNames.GetNames());
            numA.Maximum = numB.Maximum = numC.Maximum = 128;

            this.command = cmd;

            if (cmd.editable)
            {
                if (cmd.CommandData[1] != 0xFB)
                    nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)cmd.CommandData[1]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[2] != 0xFB)
                    nameB.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingB.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameC.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingC.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numB.Value);
                nameC.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)numC.Value);
            }
        }
        private void BatScrDoOneSpell_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Spell..."; labelDoB.Text = "Number...";

            this.command = cmd;

            this.nameA.Items.AddRange(this.universal.SpellNames.GetNames());
            numA.Maximum = 127;
            if (cmd.editable)
                this.nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum(cmd.CommandData[1]);
            else
                nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numA.Value);
        }
        private void BatScrDoOneOfThreeSpells_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = true; nameC.Enabled = true; doNothingC.Enabled = true;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Spell..."; labelDoB.Text = "Number...";

            this.command = cmd;

            this.nameA.Items.AddRange(this.universal.SpellNames.GetNames());
            this.nameB.Items.AddRange(this.universal.SpellNames.GetNames());
            this.nameC.Items.AddRange(this.universal.SpellNames.GetNames());
            numA.Maximum = numB.Maximum = numC.Maximum = 127;

            if (cmd.editable)
            {
                if (cmd.CommandData[1] != 0xFB)
                    nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)cmd.CommandData[1]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[2] != 0xFB)
                    nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingB.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameC.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingC.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numB.Value);
                nameC.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numC.Value);
            }
        }
        private void BatScrGenerateRandomNumber_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = ""; labelDoB.Text = "Number...";

            this.command = cmd;

            if (cmd.editable)
                this.numA.Value = cmd.CommandData[1];
        }
        private void BatScrRunBattleDialogue_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Battle Dialogue..."; labelDoB.Text = "Number...";

            this.command = cmd;

            this.nameA.DropDownWidth = 256;
            this.nameA.Items.AddRange(cmd.GetBattleDialogueNames());
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
        private void BatScrRunBattleEvent_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Battle Event..."; labelDoB.Text = "Number...";

            this.command = cmd;

            this.nameA.Items.AddRange(cmd.GetBattleEventNames());
            this.numA.Maximum = 0x66;
            if (cmd.editable)
                nameA.SelectedIndex = cmd.CommandData[1];
            else
                this.nameA.SelectedIndex = 0;
        }
        private void BatScrRunObjectSequence_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = ""; labelDoB.Text = "Object sequence...";

            this.command = cmd;

            if (cmd.editable)
                numA.Value = cmd.CommandData[1];
        }
        private void BatScrSetItems_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = false; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "Set Items..."; labelDoB.Text = "";

            this.command = cmd;

            nameA.Items.AddRange(new object[] {
                        "Remove Items",
                        "Return Items"});
            if (cmd.editable)
                nameA.SelectedIndex = cmd.CommandData[2];
            else
                nameA.SelectedIndex = 0;
        }
        private void BatScrIfAttackedByCommand_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = false; nameA.Enabled = true; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = true; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "If attacked by CMD..."; labelDoB.Text = "";

            this.command = cmd;

            nameA.Items.AddRange(new object[] {
                        "Attack",
                        "Special",
                        "Item"});
            nameB.Items.AddRange(new object[] {
                        "Attack",
                        "Special",
                        "Item"});

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
        private void BatScrIfAttackedByItem_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "If attacked by item..."; labelDoB.Text = "Number";

            this.command = cmd;

            this.nameA.Items.AddRange(this.universal.ItemNames.GetNames());
            this.nameB.Items.AddRange(this.universal.ItemNames.GetNames());
            if (cmd.editable)
            {
                if (cmd.CommandData[2] != 0xFB)
                    nameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingB.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)numB.Value);
            }
        }
        private void BatScrIfAttackedBySpell_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = true; doNothingA.Enabled = true;
            numB.Enabled = true; nameB.Enabled = true; doNothingB.Enabled = true;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = "If attacked by spell..."; labelDoB.Text = "Number";

            this.command = cmd;

            this.nameA.Items.AddRange(this.universal.SpellNames.GetNames());
            this.nameB.Items.AddRange(this.universal.SpellNames.GetNames());

            if (cmd.editable)
            {
                if (cmd.CommandData[2] != 0xFB)
                    nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)cmd.CommandData[2]);
                else
                    doNothingA.Checked = true;
                if (cmd.CommandData[3] != 0xFB)
                    nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)cmd.CommandData[3]);
                else
                    doNothingB.Checked = true;
            }
            else
            {
                nameA.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numA.Value);
                nameB.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)numB.Value);
            }
        }
        private void BatScrIfHPIsBelow_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = ""; labelDoB.Text = "HP...";

            this.command = cmd;

            numA.Maximum = 0xFFFF;

            if (cmd.editable)
                numA.Value = BitManager.GetShort(cmd.CommandData, 2);
        }
        private void BatScrIfInFormation_Click(BattleScriptCommand cmd)
        {
            numA.Enabled = true; nameA.Enabled = false; doNothingA.Enabled = false;
            numB.Enabled = false; nameB.Enabled = false; doNothingB.Enabled = false;
            numC.Enabled = false; nameC.Enabled = false; doNothingC.Enabled = false;
            panelDoOneOfThree.Enabled = true; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            labelDoA.Text = ""; labelDoB.Text = "Formation...";

            this.command = cmd;

            numA.Maximum = 0x1FF;

            if (cmd.editable)
                numA.Value = BitManager.GetShort(cmd.CommandData, 2);
        }

        private void BatScrTargetCall_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "Call Target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[3];
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetDisable_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
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
        private void BatScrTargetEnable_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
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
        private void BatScrTargetNullInvincibility_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "Null target invincibility"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetRemove_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "Remove target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetSet_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "Set target"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[1];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrTargetSetInvincibility_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "Set target invincibility"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());
            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[2];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetAffectedBy_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "If target"; labelTargetB.Text = ""; labelTargetC.Text = "...is affected by";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());
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
        private void BatScrIfTargetAlive_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "If target alive"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetDead_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "If target dead"; labelTargetB.Text = ""; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());

            if (cmd.editable)
                this.target.SelectedIndex = cmd.CommandData[3];
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetHPIsBelow_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = true; effects.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "If Target"; labelTargetB.Text = "HP is below"; labelTargetC.Text = "";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());

            if (cmd.editable)
            {
                this.target.SelectedIndex = cmd.CommandData[2];
                targetNum.Value = cmd.CommandData[3] * 16;
            }
            else
                this.target.SelectedIndex = 0;
        }
        private void BatScrIfTargetNotAffectedBy_Click(BattleScriptCommand cmd)
        {
            target.Enabled = true; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
            labelTargetA.Text = "If target"; labelTargetB.Text = ""; labelTargetC.Text = "...is not affected by";

            this.command = cmd;

            this.target.Items.AddRange(cmd.GetTargetNames());
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
        private void BatScrIfAttackedByElement_Click(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
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
        private void BatScrCommandDisable_Click(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
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
        private void BatScrCommandEnable_Click(BattleScriptCommand cmd)
        {
            target.Enabled = false; targetNum.Enabled = false; effects.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = true; panelMemoryCompare.Enabled = false;
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

        private void BatScrMemoryClear_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "Clear memory address";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[1];
        }
        private void BatScrMemoryDecrement_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "Decrement memory address";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
        }
        private void BatScrMemoryIncrement_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "Increment memory address";
            if (cmd.editable)
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
        }
        private void BatScrIfMemoryGreaterThan_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryB.Text = "Greater than";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                this.comparison.Value = cmd.CommandData[3];
            }
        }
        private void BatScrIfMemoryLessThan_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryB.Text = "Less than";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                this.comparison.Value = cmd.CommandData[3];
            }
        }
        private void BatScrIfAttackPhaseEqualTo_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = false; comparison.Enabled = true; panelBits.Enabled = false;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryB.Text = "If attack phase (7EE006) equals";

            if (cmd.editable)
                comparison.Value = cmd.CommandData[2];
            else
                comparison.Value = 0;
        }
        private void BatScrMemoryClearBits_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "Clear memory address";
            labelMemoryC.Text = "Bits";

            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrMemorySetBits_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "Set memory address";
            labelMemoryC.Text = "Bits";

            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrIfMemoryBitsClear_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryC.Text = "Bits clear";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }
        private void BatScrIfMemoryBitsSet_Click(BattleScriptCommand cmd)
        {
            memory.Enabled = true; comparison.Enabled = false; panelBits.Enabled = true;
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = true;
            this.command = cmd;

            labelMemoryA.Text = "If memory address";
            labelMemoryC.Text = "Bits set";
            if (cmd.editable)
            {
                this.memory.Value = 0x7EE000 + cmd.CommandData[2];
                SetInitialBits(cmd.CommandData[3]);
            }
        }

        private void BatScrExitBattle_Click(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            this.command = cmd;
        }
        private void BatScrIfAttacked_Click(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            this.command = cmd;
        }
        private void BatScrIfOnlyOneAlive_Click(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            this.command = cmd;
        }
        private void BatScrWaitOneTurn_Click(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            this.command = cmd;
        }
        private void BatScrWaitOneTurnRestart_Click(BattleScriptCommand cmd)
        {
            panelDoOneOfThree.Enabled = false; panelIfTargetValue.Enabled = false; panelMemoryCompare.Enabled = false;
            this.command = cmd;
        }
        #endregion
    }
}
