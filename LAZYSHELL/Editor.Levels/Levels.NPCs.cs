using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        public LevelNPCs npcs { get { return level.LevelNPCs; } set { level.LevelNPCs = value; } }
        private Object copyNPC;
        public NumericUpDown NpcXCoord { get { return npcX; } set { npcX = value; } }
        public NumericUpDown NpcYCoord { get { return npcY; } set { npcY = value; } }
        public TreeView NpcObjectTree { get { return npcObjectTree; } set { npcObjectTree = value; } }
        private NPCEditor findNPCNumber;
        private Form sp;
        #endregion
        #region Methods

        private void InitializeNPCProperties()
        {
            updatingProperties = true;
            this.npcMapHeader.Value = npcs.MapHeader;
            this.npcObjectTree.Nodes.Clear();
            for (int i = 0, a = 0; i < npcs.Count; i++, a++)
            {
                this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + (a).ToString()));
                npcs.CurrentNPC = i;
                for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                    this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
            }
            if (npcs.Count > 0)
            {
                npcs.CurrentNPC = 0;
                npcs.SelectedNPC = 0;
            }
            this.npcObjectTree.ExpandAll();
            if (npcObjectTree.Nodes.Count > 0)
                npcObjectTree.SelectedNode = npcObjectTree.Nodes[0];

            if (npcs.Count != 0 && this.npcObjectTree.SelectedNode != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                this.npcEngageType.SelectedIndex = npcs.EngageType;
                if (npcs.Count != 0 && this.npcObjectTree.SelectedNode.Parent != null) // if there are multiple instances
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertInstance.Enabled = true;
                    this.npcInsertObject.Enabled = false;
                    this.npcCopy.Enabled = true;
                    this.npcDuplicate.Enabled = true;
                    this.npcMoveDown.Enabled = true;
                    this.npcMoveUp.Enabled = true;

                    this.npcEngageType.Enabled = false;

                    this.npcX.Enabled = true;
                    this.npcY.Enabled = true;
                    this.npcZ.Enabled = true;
                    this.npcFace.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcVisible.Enabled = true;
                    this.npcZ_half.Enabled = true;

                    this.npcAttributes.Enabled = false;
                    this.npcAfterBattle.Enabled = false;
                    this.npcEngageTrigger.Enabled = false;
                    this.npcMovement.Enabled = false;
                    this.npcID.Enabled = false;
                    this.npcEventORPack.Enabled = false;
                    this.npcSpeedPlus.Enabled = false;

                    this.npcX.Value = npcs.InstanceCoordX;
                    this.npcY.Value = npcs.InstanceCoordY;
                    this.npcZ.Value = npcs.InstanceCoordZ;
                    this.npcFace.SelectedIndex = npcs.InstanceFace;
                    this.npcVisible.Checked = npcs.InstanceCoordXBit7;
                    this.npcZ_half.Checked = npcs.InstanceCoordYBit7;

                    if (this.npcEngageType.SelectedIndex == 0)
                    {
                        this.label104.Text = "NPC #+";
                        this.label31.Text = "Event #+";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "Action #+";
                        this.npcPropertyA.Maximum = 7;
                        this.npcPropertyB.Maximum = 7;
                        this.npcPropertyC.Enabled = true;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 1)
                    {
                        this.label104.Text = "$70A7 = ";
                        this.label31.Text = "{N/A}";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 255;
                        this.npcPropertyB.Enabled = false;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 2)
                    {
                        this.label104.Text = "Action #+";
                        this.label31.Text = "Pack #+";
                        this.buttonGotoA.Text = "Pack #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 255;
                    }
                    this.npcPropertyA.Value = npcs.InstancePropertyA;
                    this.npcPropertyB.Value = npcs.InstancePropertyB;
                    this.npcPropertyC.Value = npcs.InstancePropertyC;

                    this.buttonGotoA.Enabled = false;
                    this.buttonGotoB.Enabled = false;
                }
                else // there is only one root npc
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertObject.Enabled = true;
                    this.npcInsertInstance.Enabled = true;
                    this.npcCopy.Enabled = true;
                    this.npcDuplicate.Enabled = true;
                    this.npcMoveDown.Enabled = true;
                    this.npcMoveUp.Enabled = true;

                    this.npcEngageType.Enabled = true;

                    this.npcX.Enabled = true;
                    this.npcY.Enabled = true;
                    this.npcZ.Enabled = true;
                    this.npcFace.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcVisible.Enabled = true;
                    this.npcZ_half.Enabled = true;

                    this.npcAttributes.Enabled = true;
                    this.npcAfterBattle.Enabled = npcs.EngageType == 2;
                    this.npcEngageTrigger.Enabled = true;
                    this.npcMovement.Enabled = true;
                    this.npcID.Enabled = true;
                    this.npcEventORPack.Enabled = true;
                    this.npcSpeedPlus.Enabled = true;

                    this.npcX.Value = npcs.X;
                    this.npcY.Value = npcs.Y;
                    this.npcZ.Value = npcs.Z;
                    this.npcFace.SelectedIndex = npcs.Face;
                    this.npcVisible.Checked = npcs.CoordXBit7;
                    this.npcZ_half.Checked = npcs.CoordYBit7;

                    this.npcAttributes.SetItemChecked(0, npcs.B2b3);
                    this.npcAttributes.SetItemChecked(1, npcs.B2b4);
                    this.npcAttributes.SetItemChecked(2, npcs.B2b5);
                    this.npcAttributes.SetItemChecked(3, npcs.B2b6);
                    this.npcAttributes.SetItemChecked(4, npcs.B2b7);
                    this.npcAttributes.SetItemChecked(5, npcs.B3b0);
                    this.npcAttributes.SetItemChecked(6, npcs.B3b1);
                    this.npcAttributes.SetItemChecked(7, npcs.B3b2);
                    this.npcAttributes.SetItemChecked(8, npcs.B3b3);
                    this.npcAttributes.SetItemChecked(9, npcs.B3b4);
                    this.npcAttributes.SetItemChecked(10, npcs.B3b5);
                    this.npcAttributes.SetItemChecked(11, npcs.B3b6);
                    this.npcAttributes.SetItemChecked(12, npcs.B3b7);
                    this.npcAttributes.SetItemChecked(13, npcs.B4b0);
                    this.npcAttributes.SetItemChecked(14, npcs.B4b1);

                    this.npcAfterBattle.SelectedIndex = npcs.AfterBattle;

                    this.npcEngageTrigger.SelectedIndex = npcs.EngageTrigger;
                    this.npcMovement.Value = npcs.Movement;
                    this.npcID.Value = npcs.NPCID;
                    this.npcSpeedPlus.Value = npcs.SpeedPlus;

                    if (this.npcEngageType.SelectedIndex == 0)
                    {
                        this.label104.Text = "NPC #+";
                        this.label31.Text = "Event #+";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "Action #+";
                        this.npcPropertyA.Maximum = 7;
                        this.npcPropertyB.Maximum = 7;
                        this.npcPropertyC.Enabled = true;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 1)
                    {
                        this.label104.Text = "$70A7 = ";
                        this.label31.Text = "{N/A}";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 255;
                        this.npcPropertyB.Enabled = false;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 2)
                    {
                        this.label104.Text = "Action #+";
                        this.label31.Text = "Pack #+";
                        this.buttonGotoA.Text = "Pack #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 255;
                    }
                    this.npcPropertyA.Value = npcs.PropertyA;
                    this.npcPropertyB.Value = npcs.PropertyB;
                    this.npcPropertyC.Value = npcs.PropertyC;
                    this.npcEventORPack.Value = npcs.EventORpack;

                    this.buttonGotoA.Enabled = true;
                    this.buttonGotoB.Enabled = true;
                }
            }
            else // there are no npcs
            {
                this.npcMapHeader.Enabled = false;
                this.npcRemoveObject.Enabled = false;
                this.npcInsertInstance.Enabled = false;
                this.npcInsertObject.Enabled = true;
                this.npcCopy.Enabled = false;
                this.npcDuplicate.Enabled = false;
                this.npcMoveDown.Enabled = false;
                this.npcMoveUp.Enabled = false;

                this.npcEngageType.Enabled = false;

                this.npcX.Enabled = false;
                this.npcY.Enabled = false;
                this.npcZ.Enabled = false;
                this.npcFace.Enabled = false;
                this.npcPropertyA.Enabled = false;
                this.npcPropertyB.Enabled = false;
                this.npcPropertyC.Enabled = false;
                this.npcVisible.Enabled = false;
                this.npcZ_half.Enabled = false;

                this.npcAttributes.Enabled = false;
                this.npcAfterBattle.Enabled = false;
                this.npcEngageTrigger.Enabled = false;
                this.npcMovement.Enabled = false;
                this.npcID.Enabled = false;
                this.npcEventORPack.Enabled = false;
                this.npcSpeedPlus.Enabled = false;

                this.npcX.Value = 0;
                this.npcY.Value = 0;
                this.npcZ.Value = 0;
                this.npcFace.SelectedIndex = 0;
                this.npcVisible.Checked = false;
                this.npcZ_half.Checked = false;

                for (int i = 0; i < npcAttributes.Items.Count; i++)
                    npcAttributes.SetItemChecked(i, false);
                npcAfterBattle.SelectedIndex = 0;

                this.npcEngageTrigger.SelectedIndex = 0;
                this.npcMovement.Value = 0;
                this.npcID.Value = 0;
                this.npcSpeedPlus.Value = 0;

                this.label104.Text = "";
                this.label31.Text = "";
                this.buttonGotoA.Text = "";
                this.label116.Text = "";
                this.npcPropertyA.Value = 0;
                this.npcPropertyB.Value = 0;
                this.npcPropertyC.Value = 0;
                this.npcEventORPack.Value = 0;

                this.buttonGotoA.Enabled = false;
                this.buttonGotoB.Enabled = false;
            }

            npcsBytesLeft.Text = CalculateFreeNPCSpace() + " bytes left";
            npcsBytesLeft.BackColor = CalculateFreeNPCSpace() >= 0 ? SystemColors.Control : Color.Red;

            updatingProperties = false;
        }
        private void RefreshNPCProperties()
        {
            updatingProperties = true;

            if (npcs.Count != 0 && this.npcObjectTree.SelectedNode != null)
            {
                this.npcEngageType.SelectedIndex = npcs.EngageType;
                if (npcs.Count != 0 && this.npcObjectTree.SelectedNode.Parent != null) // if there are multiple instances
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertObject.Enabled = false;
                    this.npcInsertInstance.Enabled = true;
                    this.npcCopy.Enabled = true;
                    this.npcDuplicate.Enabled = true;
                    this.npcMoveDown.Enabled = true;
                    this.npcMoveUp.Enabled = true;

                    this.npcEngageType.Enabled = false;

                    this.npcX.Enabled = true;
                    this.npcY.Enabled = true;
                    this.npcZ.Enabled = true;
                    this.npcFace.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcPropertyC.Enabled = true;
                    this.npcVisible.Enabled = true;
                    this.npcZ_half.Enabled = true;

                    this.npcAttributes.Enabled = false;
                    this.npcAfterBattle.Enabled = false;
                    this.npcEngageTrigger.Enabled = false;
                    this.npcMovement.Enabled = false;
                    this.npcID.Enabled = false;
                    this.npcEventORPack.Enabled = false;
                    this.npcSpeedPlus.Enabled = false;

                    this.npcX.Value = npcs.InstanceCoordX;
                    this.npcY.Value = npcs.InstanceCoordY;
                    this.npcZ.Value = npcs.InstanceCoordZ;
                    this.npcFace.SelectedIndex = npcs.InstanceFace;
                    this.npcVisible.Checked = npcs.InstanceCoordXBit7;
                    this.npcZ_half.Checked = npcs.InstanceCoordYBit7;

                    if (this.npcEngageType.SelectedIndex == 0)
                    {
                        this.label104.Text = "NPC #+";
                        this.label31.Text = "Event #+";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "Action #+";
                        this.npcPropertyA.Maximum = 7;
                        this.npcPropertyB.Maximum = 7;
                        this.npcPropertyC.Enabled = true;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 1)
                    {
                        this.label104.Text = "$70A7 = ";
                        this.label31.Text = "{N/A}";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 255;
                        this.npcPropertyB.Enabled = false;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 2)
                    {
                        this.label104.Text = "Action #+";
                        this.label31.Text = "Pack #+";
                        this.buttonGotoA.Text = "Pack #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 255;
                    }
                    this.npcPropertyA.Value = npcs.InstancePropertyA;
                    this.npcPropertyB.Value = npcs.InstancePropertyB;
                    this.npcPropertyC.Value = npcs.InstancePropertyC;

                    this.buttonGotoA.Enabled = false;
                    this.buttonGotoB.Enabled = false;
                }
                else // there is only one root npc
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertObject.Enabled = true;
                    this.npcInsertInstance.Enabled = true;
                    this.npcCopy.Enabled = true;
                    this.npcDuplicate.Enabled = true;
                    this.npcMoveDown.Enabled = true;
                    this.npcMoveUp.Enabled = true;

                    this.npcEngageType.Enabled = true;

                    this.npcX.Enabled = true;
                    this.npcY.Enabled = true;
                    this.npcZ.Enabled = true;
                    this.npcFace.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcPropertyC.Enabled = true;
                    this.npcVisible.Enabled = true;
                    this.npcZ_half.Enabled = true;

                    this.npcAttributes.Enabled = true;
                    this.npcAfterBattle.Enabled = npcs.EngageType == 2;
                    this.npcEngageTrigger.Enabled = true;
                    this.npcMovement.Enabled = true;
                    this.npcID.Enabled = true;
                    this.npcEventORPack.Enabled = true;
                    this.npcSpeedPlus.Enabled = true;

                    this.npcX.Value = npcs.X;
                    this.npcY.Value = npcs.Y;
                    this.npcZ.Value = npcs.Z;
                    this.npcFace.SelectedIndex = npcs.Face;
                    this.npcVisible.Checked = npcs.CoordXBit7;
                    this.npcZ_half.Checked = npcs.CoordYBit7;

                    this.npcAttributes.SetItemChecked(0, npcs.B2b3);
                    this.npcAttributes.SetItemChecked(1, npcs.B2b4);
                    this.npcAttributes.SetItemChecked(2, npcs.B2b5);
                    this.npcAttributes.SetItemChecked(3, npcs.B2b6);
                    this.npcAttributes.SetItemChecked(4, npcs.B2b7);
                    this.npcAttributes.SetItemChecked(5, npcs.B3b0);
                    this.npcAttributes.SetItemChecked(6, npcs.B3b1);
                    this.npcAttributes.SetItemChecked(7, npcs.B3b2);
                    this.npcAttributes.SetItemChecked(8, npcs.B3b3);
                    this.npcAttributes.SetItemChecked(9, npcs.B3b4);
                    this.npcAttributes.SetItemChecked(10, npcs.B3b5);
                    this.npcAttributes.SetItemChecked(11, npcs.B3b6);
                    this.npcAttributes.SetItemChecked(12, npcs.B3b7);
                    this.npcAttributes.SetItemChecked(13, npcs.B4b0);
                    this.npcAttributes.SetItemChecked(14, npcs.B4b1);
                    this.npcAfterBattle.SelectedIndex = npcs.AfterBattle;

                    this.npcEngageTrigger.SelectedIndex = npcs.EngageTrigger;
                    this.npcMovement.Value = npcs.Movement;
                    this.npcID.Value = npcs.NPCID;
                    this.npcSpeedPlus.Value = npcs.SpeedPlus;

                    if (this.npcEngageType.SelectedIndex == 0)
                    {
                        this.label104.Text = "NPC #+";
                        this.label31.Text = "Event #+";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "Action #+";
                        this.npcPropertyA.Maximum = 7;
                        this.npcPropertyB.Maximum = 7;
                        this.npcPropertyC.Enabled = true;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 1)
                    {
                        this.label104.Text = "$70A7 = ";
                        this.label31.Text = "{N/A}";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 255;
                        this.npcPropertyB.Enabled = false;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 4095;
                    }
                    else if (this.npcEngageType.SelectedIndex == 2)
                    {
                        this.label104.Text = "Action #+";
                        this.label31.Text = "Pack #+";
                        this.buttonGotoA.Text = "Pack #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
                        this.npcPropertyC.Enabled = false;
                        this.npcEventORPack.Maximum = 255;
                    }
                    this.npcEventORPack.Value = npcs.EventORpack;
                    this.npcPropertyA.Value = npcs.PropertyA;
                    this.npcPropertyB.Value = npcs.PropertyB;
                    this.npcPropertyC.Value = npcs.PropertyC;

                    this.buttonGotoA.Enabled = true;
                    this.buttonGotoB.Enabled = true;
                }
            }
            else // there are no npcs
            {
                this.npcMapHeader.Enabled = false;
                this.npcRemoveObject.Enabled = false;
                this.npcInsertInstance.Enabled = false;
                this.npcCopy.Enabled = false;
                this.npcDuplicate.Enabled = false;
                this.npcMoveDown.Enabled = false;
                this.npcMoveUp.Enabled = false;

                this.npcEngageType.Enabled = false;

                this.npcX.Enabled = false;
                this.npcY.Enabled = false;
                this.npcZ.Enabled = false;
                this.npcFace.Enabled = false;
                this.npcPropertyA.Enabled = false;
                this.npcPropertyB.Enabled = false;
                this.npcPropertyC.Enabled = false;
                this.npcVisible.Enabled = false;
                this.npcZ_half.Enabled = false;

                this.npcAttributes.Enabled = false;
                this.npcAfterBattle.Enabled = false;
                this.npcEngageTrigger.Enabled = false;
                this.npcMovement.Enabled = false;
                this.npcID.Enabled = false;
                this.npcEventORPack.Enabled = false;
                this.npcSpeedPlus.Enabled = false;

                this.npcX.Value = 0;
                this.npcY.Value = 0;
                this.npcZ.Value = 0;
                this.npcFace.SelectedIndex = 0;
                this.npcVisible.Checked = false;
                this.npcZ_half.Checked = false;

                for (int i = 0; i < npcAttributes.Items.Count; i++)
                    npcAttributes.SetItemChecked(i, false);
                npcAfterBattle.SelectedIndex = 0;

                this.npcEngageTrigger.SelectedIndex = 0;
                this.npcMovement.Value = 0;
                this.npcID.Value = 0;
                this.npcSpeedPlus.Value = 0;

                this.label104.Text = "";
                this.label31.Text = "";
                this.buttonGotoA.Text = "";
                this.label116.Text = "";
                this.npcPropertyA.Value = 0;
                this.npcPropertyB.Value = 0;
                this.npcPropertyC.Value = 0;
                this.npcEventORPack.Value = 0;

                this.buttonGotoA.Enabled = false;
                this.buttonGotoB.Enabled = false;
            }

            npcsBytesLeft.Text = CalculateFreeNPCSpace() + " bytes left";
            npcsBytesLeft.BackColor = CalculateFreeNPCSpace() >= 0 ? SystemColors.Control : Color.Red;

            updatingProperties = false;
            if (npcEngageType.SelectedIndex == 0)
                findNPCNumber.Reload(npcID.Value + npcPropertyA.Value);
            else
                findNPCNumber.Reload(npcID.Value);
        }
        private int CalculateFreeNPCSpace()
        {
            int used = 0;
            foreach (Level level in levels)
            {
                if (level.LevelNPCs.Count > 0)
                    used++;   // for the map header
                foreach (NPC npc in level.LevelNPCs.Npcs)
                {
                    used += 12;
                    foreach (NPC.Instance instance in npc.Instances)
                        used += 4;
                }
            }
            return 0x7BFF - used;
        }
        //
        private void AddNewNPC()
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeNPCSpace() >= 12)
            {
                if (npcObjectTree.GetNodeCount(true) < 28)
                {
                    if (npcObjectTree.Nodes.Count > 0)
                        npcs.AddNewNPC(npcObjectTree.SelectedNode.Index + 1, p);
                    else
                        npcs.AddNewNPC(0, p);

                    int reselect;

                    if (npcObjectTree.Nodes.Count > 0)
                        reselect = npcObjectTree.SelectedNode.Index;
                    else
                        reselect = -1;

                    npcObjectTree.BeginUpdate();

                    this.npcObjectTree.Nodes.Clear();
                    for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                    {
                        this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                        npcs.CurrentNPC = i;

                        for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                            this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                    }

                    this.npcObjectTree.ExpandAll();
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselect + 1];

                    npcObjectTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. The total number of NPCs for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddNewInstance()
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeNPCSpace() >= 4)
            {
                if (npcObjectTree.SelectedNode.Parent != null)
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Parent.Index;
                else
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Index;

                this.npcObjectTree.Focus();
                int totalNumberOfNodes = npcObjectTree.GetNodeCount(true);

                if (totalNumberOfNodes < 28)
                {
                    if (npcObjectTree.SelectedNode.Parent != null)
                        npcs.AddNewInstance(npcObjectTree.SelectedNode.Index + 1, p);
                    else
                        npcs.AddNewInstance(0, p);

                    int reselectP = npcObjectTree.SelectedNode.Parent != null ?
                        npcObjectTree.SelectedNode.Parent.Index : npcObjectTree.SelectedNode.Index;
                    int reselectC = npcObjectTree.SelectedNode.Parent != null ?
                        npcObjectTree.SelectedNode.Index : -1;

                    this.npcObjectTree.BeginUpdate();

                    this.npcObjectTree.Nodes.Clear();
                    for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                    {
                        this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                        npcs.CurrentNPC = i;

                        for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                            this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                    }

                    this.npcObjectTree.ExpandAll();
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP].Nodes[reselectC + 1];

                    npcObjectTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. The total number of NPCs for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddNewNPC(NPC e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeNPCSpace() >= 12)
            {
                if (npcObjectTree.GetNodeCount(true) < 28)
                {
                    if (npcObjectTree.Nodes.Count > 0)
                        npcs.AddNewNPC(npcObjectTree.SelectedNode.Index + 1, e);
                    else
                        npcs.AddNewNPC(0, e);

                    int reselect;

                    if (npcObjectTree.Nodes.Count > 0)
                        reselect = npcObjectTree.SelectedNode.Index;
                    else
                        reselect = -1;

                    npcObjectTree.BeginUpdate();

                    this.npcObjectTree.Nodes.Clear();
                    for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                    {
                        this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                        npcs.CurrentNPC = i;

                        for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                            this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                    }

                    this.npcObjectTree.ExpandAll();
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselect + 1];

                    npcObjectTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. The total number of NPCs for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddNewInstance(NPC.Instance e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeNPCSpace() >= 4)
            {
                if (npcObjectTree.SelectedNode.Parent != null)
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Parent.Index;
                else
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Index;

                this.npcObjectTree.Focus();
                int totalNumberOfNodes = npcObjectTree.GetNodeCount(true);

                if (totalNumberOfNodes < 28)
                {
                    if (npcObjectTree.SelectedNode.Parent != null)
                        npcs.AddNewInstance(npcObjectTree.SelectedNode.Index + 1, e);
                    else
                        npcs.AddNewInstance(0, e);

                    int reselectP = npcObjectTree.SelectedNode.Parent != null ?
                        npcObjectTree.SelectedNode.Parent.Index : npcObjectTree.SelectedNode.Index;
                    int reselectC = npcObjectTree.SelectedNode.Parent != null ?
                        npcObjectTree.SelectedNode.Index : -1;

                    this.npcObjectTree.BeginUpdate();

                    this.npcObjectTree.Nodes.Clear();
                    for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                    {
                        this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                        npcs.CurrentNPC = i;

                        for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                            this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                    }

                    this.npcObjectTree.ExpandAll();
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP].Nodes[reselectC + 1];

                    npcObjectTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. The total number of NPCs for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Event Handlers

        private void npcObjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (updatingProperties) return;

            if (this.npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.SelectedNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.SelectedInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.IsInstanceSelected = true;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.SelectedNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.IsInstanceSelected = false;
            }

            if (this.npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;

            RefreshNPCProperties();
            picture.Invalidate();
        }
        private void npcInsertObject_Click(object sender, System.EventArgs e)
        {
            AddNewNPC();
            overlay.NPCImages = null;
        }
        private void npcRemoveObject_Click(object sender, System.EventArgs e)
        {
            this.npcObjectTree.Focus();
            if (this.npcObjectTree.SelectedNode == null) return;
            if (this.npcObjectTree.SelectedNode.Parent == null &&
                npcs.CurrentNPC == this.npcObjectTree.SelectedNode.Index)
            {
                npcs.RemoveCurrentNPC();
                int reselect = npcObjectTree.SelectedNode.Index;
                if (reselect == npcObjectTree.Nodes.Count - 1)
                    reselect--;
                npcObjectTree.BeginUpdate();
                this.npcObjectTree.Nodes.Clear();
                for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                {
                    this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                    npcs.CurrentNPC = i;

                    for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                        this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                }
                this.npcObjectTree.ExpandAll();
                if (this.npcObjectTree.Nodes.Count > 0)
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselect];
                else
                {
                    this.npcObjectTree.SelectedNode = null;
                    RefreshNPCProperties();
                }
                npcObjectTree.EndUpdate();
            }
            else if (this.npcObjectTree.SelectedNode.Parent != null &&
                npcs.CurrentInstance == this.npcObjectTree.SelectedNode.Index)
            {
                npcs.RemoveCurrentInstance();
                int reselectP = npcObjectTree.SelectedNode.Parent.Index;
                int reselectC = npcObjectTree.SelectedNode.Index;
                if (reselectC == npcObjectTree.SelectedNode.Parent.Nodes.Count - 1)
                    reselectC--;
                this.npcObjectTree.BeginUpdate();
                this.npcObjectTree.Nodes.Clear();
                for (int i = 0, a = 0; i < npcs.Count; i++, a++)
                {
                    this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                    npcs.CurrentNPC = i;
                    for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                        this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
                }
                this.npcObjectTree.ExpandAll();
                if (this.npcObjectTree.Nodes[reselectP].Nodes.Count > 0)
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP].Nodes[reselectC];
                else
                    this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP];
                this.npcObjectTree.EndUpdate();
            }
            overlay.NPCImages = null;
            picture.Invalidate();
        }
        private void npcInsertInstance_Click(object sender, System.EventArgs e)
        {
            AddNewInstance();
            overlay.NPCImages = null;
        }
        //
        private void openPartitions_Click(object sender, System.EventArgs e)
        {
            if (sp != null && sp.Visible)
                sp.BringToFront();
            else
                sp = new SpritePartitions(this, npcSpritePartitions);
            sp.Show();
        }
        private void findNPCNum_Click(object sender, EventArgs e)
        {
            findNPCNumber.Show();
            findNPCNumber.BringToFront();
        }
        //
        private void npcEngageType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;
            npcs.EngageType = (byte)this.npcEngageType.SelectedIndex;
            if (this.npcEngageType.SelectedIndex == 0)
            {
                this.label104.Text = "NPC #+";  //propertyA
                this.label31.Text = "Event #+"; //propertyB
                this.buttonGotoA.Text = "Event #"; //eventorpack
                this.label116.Text = "Action #+";//propertyC
                this.npcPropertyA.Maximum = 7;
                this.npcPropertyA.Enabled = true;
                this.npcPropertyB.Maximum = 7;
                this.npcPropertyB.Enabled = true;
                this.npcPropertyC.Enabled = true;
                this.npcEventORPack.Maximum = 4095;
                this.npcAfterBattle.Enabled = false;
            }
            else if (this.npcEngageType.SelectedIndex == 1)
            {
                this.label104.Text = "$70A7 = "; //propertyA
                this.label31.Text = "{N/A}"; //propertyB
                this.buttonGotoA.Text = "Event #"; //eventorpack
                this.label116.Text = "{N/A}";   //propertyC
                this.npcPropertyA.Maximum = 255;
                this.npcPropertyA.Enabled = true;
                this.npcPropertyB.Enabled = false;
                this.npcPropertyC.Enabled = false;
                this.npcEventORPack.Maximum = 4095;
                this.npcAfterBattle.Enabled = false;
            }
            else if (this.npcEngageType.SelectedIndex == 2)
            {
                this.label104.Text = "Action #+";   //propertyA
                this.label31.Text = "Pack #+";      //propertyB
                this.buttonGotoA.Text = "Pack #";      //eventorpack
                this.label116.Text = "{N/A}";       //propertyC
                this.npcPropertyA.Maximum = 15;
                this.npcPropertyA.Enabled = true;
                this.npcPropertyB.Maximum = 15;
                this.npcPropertyB.Enabled = true;
                this.npcPropertyC.Enabled = false;
                this.npcEventORPack.Maximum = 255;
                this.npcAfterBattle.Enabled = true;
            }
            if (!updatingLevel && state.NPCs)
                overlay.NPCImages = null;
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            overlay.NPCImages = null;
            picture.Invalidate();
        }
        private void npcSpeedPlus_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            npcs.SpeedPlus = (byte)this.npcSpeedPlus.Value;
        }
        private void npcEventORPack_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            npcs.EventORpack = (ushort)this.npcEventORPack.Value;
            picture.Invalidate();
        }
        public void npcID_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;
            npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            npcs.NPCID = (ushort)this.npcID.Value;
            npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            overlay.NPCImages = null;
            picture.Invalidate();
        }
        private void npcMovement_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            npcs.Movement = (ushort)this.npcMovement.Value;
        }
        private void npcEngageTrigger_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            npcs.EngageTrigger = (byte)this.npcEngageTrigger.SelectedIndex;
        }
        private void npcPropertyA_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstancePropertyA = (byte)this.npcPropertyA.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.PropertyA = (byte)this.npcPropertyA.Value;
            }
            overlay.NPCImages = null;
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcPropertyB_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
                npcs.InstancePropertyB = (byte)this.npcPropertyB.Value;
            else
                npcs.PropertyB = (byte)this.npcPropertyB.Value;
            picture.Invalidate();
        }
        private void npcPropertyC_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
                npcs.InstancePropertyC = (byte)this.npcPropertyC.Value;
            else
                npcs.PropertyC = (byte)this.npcPropertyC.Value;
        }
        private void npcRadialPosition_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceFace = (byte)this.npcFace.SelectedIndex;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.Face = (byte)this.npcFace.SelectedIndex;
            }
            overlay.NPCImages = null;
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcZCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordZ = (byte)this.npcZ.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.Z = (byte)this.npcZ.Value;
            }
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcYCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordY = (byte)this.npcY.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.Y = (byte)this.npcY.Value;
            }
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcXCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordX = (byte)this.npcX.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.X = (byte)this.npcX.Value;
            }
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcsShowNPC_CheckedChanged(object sender, System.EventArgs e)
        {
            if (npcVisible.Checked) npcVisible.ForeColor = Color.Black;
            else npcVisible.ForeColor = Color.Gray;
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordXBit7 = this.npcVisible.Checked;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordXBit7 = this.npcVisible.Checked;
            }
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcsZCoordPlusHalf_CheckedChanged(object sender, System.EventArgs e)
        {
            if (npcZ_half.Checked) npcZ_half.ForeColor = Color.Black;
            else npcZ_half.ForeColor = Color.Gray;
            if (updatingProperties) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordYBit7 = this.npcZ_half.Checked;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordYBit7 = this.npcZ_half.Checked;
            }
            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            picture.Invalidate();
        }
        private void npcMapHeader_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            npcs.MapHeader = (byte)this.npcMapHeader.Value;
        }
        private void npcAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            npcs.B2b3 = this.npcAttributes.GetItemChecked(0);
            npcs.B2b4 = this.npcAttributes.GetItemChecked(1);
            npcs.B2b5 = this.npcAttributes.GetItemChecked(2);
            npcs.B2b6 = this.npcAttributes.GetItemChecked(3);
            npcs.B2b7 = this.npcAttributes.GetItemChecked(4);
            npcs.B3b0 = this.npcAttributes.GetItemChecked(5);
            npcs.B3b1 = this.npcAttributes.GetItemChecked(6);
            npcs.B3b2 = this.npcAttributes.GetItemChecked(7);
            npcs.B3b3 = this.npcAttributes.GetItemChecked(8);
            npcs.B3b4 = this.npcAttributes.GetItemChecked(9);
            npcs.B3b5 = this.npcAttributes.GetItemChecked(10);
            npcs.B3b6 = this.npcAttributes.GetItemChecked(11);
            npcs.B3b7 = this.npcAttributes.GetItemChecked(12);
            npcs.B4b0 = this.npcAttributes.GetItemChecked(13);
            npcs.B4b1 = this.npcAttributes.GetItemChecked(14);
        }
        //
        private void npcMoveUp_Click(object sender, EventArgs e)
        {
            if (this.npcObjectTree.SelectedNode == null) return;

            int reselectP = 0;
            int reselectC = 0;
            bool instanceSelected = false;

            if (this.npcObjectTree.SelectedNode.Parent != null && npcs.CurrentInstance > 0)
            {
                instanceSelected = true;
                reselectP = npcObjectTree.SelectedNode.Parent.Index;
                reselectC = npcObjectTree.SelectedNode.Index - 1;
                npcs.ReverseInstance(npcs.CurrentInstance - 1);
            }
            else if (this.npcObjectTree.SelectedNode.Parent == null && npcs.CurrentNPC > 0)
            {
                reselectP = npcObjectTree.SelectedNode.Index - 1;
                npcs.ReverseNPC(npcs.CurrentNPC - 1);
            }
            else return;

            this.npcObjectTree.BeginUpdate();

            this.npcObjectTree.Nodes.Clear();
            for (int i = 0, a = 0; i < npcs.Count; i++, a++)
            {
                this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                npcs.CurrentNPC = i;

                for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                    this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
            }

            this.npcObjectTree.ExpandAll();

            if (instanceSelected)
                this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP].Nodes[reselectC];
            else
                this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP];

            this.npcObjectTree.EndUpdate();
        }
        private void npcMoveDown_Click(object sender, EventArgs e)
        {
            if (this.npcObjectTree.SelectedNode == null) return;

            int reselectP = 0;
            int reselectC = 0;
            bool instanceSelected = false;

            if (this.npcObjectTree.SelectedNode.Parent != null && npcs.CurrentInstance < npcs.InstanceCount - 1)
            {
                instanceSelected = true;
                reselectP = npcObjectTree.SelectedNode.Parent.Index;
                reselectC = npcObjectTree.SelectedNode.Index + 1;
                npcs.ReverseInstance(npcs.CurrentInstance);
            }
            else if (this.npcObjectTree.SelectedNode.Parent == null && npcs.CurrentNPC < npcs.Count - 1)
            {
                reselectP = npcObjectTree.SelectedNode.Index + 1;
                npcs.ReverseNPC(npcs.CurrentNPC);
            }
            else return;

            this.npcObjectTree.BeginUpdate();

            this.npcObjectTree.Nodes.Clear();
            for (int i = 0, a = 0; i < npcs.Count; i++, a++)
            {
                this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + a.ToString()));
                npcs.CurrentNPC = i;

                for (int j = 0; j < npcs.InstanceAmount; j++, a++)
                    this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (a + 1).ToString()));
            }

            this.npcObjectTree.ExpandAll();

            if (instanceSelected)
                this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP].Nodes[reselectC];
            else
                this.npcObjectTree.SelectedNode = this.npcObjectTree.Nodes[reselectP];

            this.npcObjectTree.EndUpdate();
        }
        private void npcCopy_Click(object sender, EventArgs e)
        {
            if (npcObjectTree.SelectedNode != null)
            {
                if (npcObjectTree.SelectedNode.Parent != null)
                    copyNPC = npcs.Npc.Instance_;
                else
                    copyNPC = npcs.Npc;
            }
        }
        private void npcPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (npcObjectTree.SelectedNode.Parent != null)
                    AddNewInstance((NPC.Instance)copyNPC);
                else
                    AddNewNPC((NPC)copyNPC);
            }
            catch
            {
                MessageBox.Show("Cannot paste an NPC into another NPC's instance collection.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void npcDuplicate_Click(object sender, EventArgs e)
        {
            if (npcObjectTree.SelectedNode.Parent != null)
                AddNewInstance(npcs.Npc.Instance_);
            else
                AddNewNPC(npcs.Npc);
        }
        //
        private void buttonGotoA_Click(object sender, EventArgs e)
        {
            if (npcEngageType.SelectedIndex == 2)
                return;
            if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                Model.Program.CreateEventScriptsWindow();

            Model.Program.EventScripts.EventName.SelectedIndex = 0;
            Model.Program.EventScripts.EventNum.Value = npcEventORPack.Value;
            Model.Program.EventScripts.BringToFront();
        }
        private void buttonGotoB_Click(object sender, EventArgs e)
        {
            if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                Model.Program.CreateEventScriptsWindow();

            Model.Program.EventScripts.EventName.SelectedIndex = 1;
            Model.Program.EventScripts.EventNum.Value = npcMovement.Value;
            Model.Program.EventScripts.BringToFront();
        }
        //
        private void npcAfterBattle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            npcs.AfterBattle = (byte)npcAfterBattle.SelectedIndex;
        }

        #endregion
    }
}
