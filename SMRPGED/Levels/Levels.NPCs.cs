using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private LevelNPCs npcs;
        private Object npcCopy;

        private NPCSpritePartitions[] npcSpritePartitions;
        private NPCProperties[] npcProperties;

        #endregion

        #region Methods

        private void InitializeNPCProperties()
        {
            int ctr = 0;

            updatingProperties = true;

            this.npcMapHeader.Value = npcs.MapHeader;

            this.npcObjectTree.Nodes.Clear();

            for (int i = 0; i < npcs.NumberOfNPCs; i++)
            {
                this.npcObjectTree.Nodes.Add(new TreeNode("NPC #" + (ctr).ToString()));
                npcs.CurrentNPC = i;

                for (int j = 0; j < npcs.InstanceAmount; j++)
                {
                    this.npcObjectTree.Nodes[i].Nodes.Add(new TreeNode("NPC #" + (ctr + 1).ToString()));
                    ctr++;
                }

                ctr++;
            }
            if (npcs.NumberOfNPCs > 0)
            {
                npcs.CurrentNPC = 0;
                npcs.SelectedNPC = 0;
            }

            this.npcObjectTree.ExpandAll();

            if (npcObjectTree.Nodes.Count > 0)
                npcObjectTree.SelectedNode = npcObjectTree.Nodes[0];

            if (npcs.NumberOfNPCs != 0 && this.npcObjectTree.SelectedNode != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                this.npcEngageType.SelectedIndex = npcs.EngageType;
                if (npcs.NumberOfNPCs != 0 && this.npcObjectTree.SelectedNode.Parent != null) // if there are multiple instances
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveInstance.Enabled = true;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertInstance.Enabled = true;

                    this.npcEngageType.Enabled = false;

                    this.npcXCoord.Enabled = true;
                    this.npcYCoord.Enabled = true;
                    this.npcZCoord.Enabled = true;
                    this.npcRadialPosition.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcsShowNPC.Enabled = true;
                    this.npcsZCoordPlusHalf.Enabled = true;

                    this.npcAttributes.Enabled = false;
                    this.npcAttributesBattle.Enabled = false;
                    this.npcEngageTrigger.Enabled = false;
                    this.npcMovement.Enabled = false;
                    this.npcID.Enabled = false;
                    this.npcPaletteIndexPlus.Enabled = false;
                    this.npcEventORPack.Enabled = false;
                    this.npcSpeedPlus.Enabled = false;

                    this.npcXCoord.Value = npcs.InstanceCoordX;
                    this.npcYCoord.Value = npcs.InstanceCoordY;
                    this.npcZCoord.Value = npcs.InstanceCoordZ;
                    this.npcRadialPosition.SelectedIndex = npcs.InstanceRadialPosition;
                    this.npcsShowNPC.Checked = npcs.InstanceCoordXBit7;
                    this.npcsZCoordPlusHalf.Checked = npcs.InstanceCoordYBit7;

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
                        this.label104.Text = "Star XP";
                        this.label31.Text = "Treasure";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
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
                    this.npcRemoveInstance.Enabled = false;
                    this.npcRemoveObject.Enabled = true;
                    this.npcInsertInstance.Enabled = true;

                    this.npcEngageType.Enabled = true;

                    this.npcXCoord.Enabled = true;
                    this.npcYCoord.Enabled = true;
                    this.npcZCoord.Enabled = true;
                    this.npcRadialPosition.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcsShowNPC.Enabled = true;
                    this.npcsZCoordPlusHalf.Enabled = true;

                    this.npcAttributes.Enabled = true;
                    this.npcAttributesBattle.Enabled = npcs.EngageType == 2;
                    this.npcEngageTrigger.Enabled = true;
                    this.npcMovement.Enabled = true;
                    this.npcID.Enabled = true;
                    this.npcPaletteIndexPlus.Enabled = true;
                    this.npcEventORPack.Enabled = true;
                    this.npcSpeedPlus.Enabled = true;

                    this.npcXCoord.Value = npcs.CoordX;
                    this.npcYCoord.Value = npcs.CoordY;
                    this.npcZCoord.Value = npcs.CoordZ;
                    this.npcRadialPosition.SelectedIndex = npcs.RadialPosition;
                    this.npcsShowNPC.Checked = npcs.CoordXBit7;
                    this.npcsZCoordPlusHalf.Checked = npcs.CoordYBit7;

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
                    this.npcAttributesBattle.SetItemChecked(0, npcs.B8b0);
                    this.npcAttributesBattle.SetItemChecked(1, npcs.B8b1);
                    this.npcAttributesBattle.SetItemChecked(2, npcs.B8b2);
                    this.npcAttributesBattle.SetItemChecked(3, npcs.B8b3);

                    this.npcEngageTrigger.SelectedIndex = npcs.EngageTrigger;
                    this.npcMovement.Value = npcs.Movement;
                    this.npcID.Value = npcs.NPCID;
                    this.npcPaletteIndexPlus.Value = npcs.PaletteIndexPlus;
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
                        this.label104.Text = "Star XP";
                        this.label31.Text = "Treasure";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
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
                this.npcRemoveInstance.Enabled = false;
                this.npcRemoveObject.Enabled = false;
                this.npcInsertInstance.Enabled = false;

                this.npcEngageType.Enabled = false;

                this.npcXCoord.Enabled = false;
                this.npcYCoord.Enabled = false;
                this.npcZCoord.Enabled = false;
                this.npcRadialPosition.Enabled = false;
                this.npcPropertyA.Enabled = false;
                this.npcPropertyB.Enabled = false;
                this.npcPropertyC.Enabled = false;
                this.npcsShowNPC.Enabled = false;
                this.npcsZCoordPlusHalf.Enabled = false;

                this.npcAttributes.Enabled = false;
                this.npcAttributesBattle.Enabled = false;
                this.npcEngageTrigger.Enabled = false;
                this.npcMovement.Enabled = false;
                this.npcID.Enabled = false;
                this.npcPaletteIndexPlus.Enabled = false;
                this.npcEventORPack.Enabled = false;
                this.npcSpeedPlus.Enabled = false;

                this.npcXCoord.Value = 0;
                this.npcYCoord.Value = 0;
                this.npcZCoord.Value = 0;
                this.npcRadialPosition.SelectedIndex = 0;
                this.npcsShowNPC.Checked = false;
                this.npcsZCoordPlusHalf.Checked = false;

                for (int i = 0; i < npcAttributes.Items.Count; i++)
                    npcAttributes.SetItemChecked(i, false);
                for (int i = 0; i < npcAttributesBattle.Items.Count; i++)
                    npcAttributesBattle.SetItemChecked(i, false);

                this.npcEngageTrigger.SelectedIndex = 0;
                this.npcMovement.Value = 0;
                this.npcID.Value = 0;
                this.npcPaletteIndexPlus.Value = 0;
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

            overlay.DrawLevelNPCs(npcs, npcProperties);

            updatingProperties = false;
        }
        private void RefreshNPCProperties()
        {
            updatingLevel = true;

            if (npcs.NumberOfNPCs != 0 && this.npcObjectTree.SelectedNode != null)
            {
                this.npcEngageType.SelectedIndex = npcs.EngageType;
                if (npcs.NumberOfNPCs != 0 && this.npcObjectTree.SelectedNode.Parent != null) // if there are multiple instances
                {
                    this.npcMapHeader.Enabled = true;
                    this.npcRemoveObject.Enabled = false;
                    this.npcInsertObject.Enabled = false;
                    this.npcRemoveInstance.Enabled = true;
                    this.npcInsertInstance.Enabled = true;

                    this.npcEngageType.Enabled = false;

                    this.npcXCoord.Enabled = true;
                    this.npcYCoord.Enabled = true;
                    this.npcZCoord.Enabled = true;
                    this.npcRadialPosition.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcPropertyC.Enabled = true;
                    this.npcsShowNPC.Enabled = true;
                    this.npcsZCoordPlusHalf.Enabled = true;

                    this.npcAttributes.Enabled = false;
                    this.npcAttributesBattle.Enabled = false;
                    this.npcEngageTrigger.Enabled = false;
                    this.npcMovement.Enabled = false;
                    this.npcID.Enabled = false;
                    this.npcPaletteIndexPlus.Enabled = false;
                    this.npcEventORPack.Enabled = false;
                    this.npcSpeedPlus.Enabled = false;

                    this.npcXCoord.Value = npcs.InstanceCoordX;
                    this.npcYCoord.Value = npcs.InstanceCoordY;
                    this.npcZCoord.Value = npcs.InstanceCoordZ;
                    this.npcRadialPosition.SelectedIndex = npcs.InstanceRadialPosition;
                    this.npcsShowNPC.Checked = npcs.InstanceCoordXBit7;
                    this.npcsZCoordPlusHalf.Checked = npcs.InstanceCoordYBit7;

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
                        this.label104.Text = "Star XP";
                        this.label31.Text = "Treasure";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
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
                    this.npcRemoveInstance.Enabled = false;
                    this.npcInsertInstance.Enabled = true;

                    this.npcEngageType.Enabled = true;

                    this.npcXCoord.Enabled = true;
                    this.npcYCoord.Enabled = true;
                    this.npcZCoord.Enabled = true;
                    this.npcRadialPosition.Enabled = true;
                    this.npcPropertyA.Enabled = true;
                    this.npcPropertyB.Enabled = true;
                    this.npcPropertyC.Enabled = true;
                    this.npcsShowNPC.Enabled = true;
                    this.npcsZCoordPlusHalf.Enabled = true;

                    this.npcAttributes.Enabled = true;
                    this.npcAttributesBattle.Enabled = npcs.EngageType == 2;
                    this.npcEngageTrigger.Enabled = true;
                    this.npcMovement.Enabled = true;
                    this.npcID.Enabled = true;
                    this.npcPaletteIndexPlus.Enabled = true;
                    this.npcEventORPack.Enabled = true;
                    this.npcSpeedPlus.Enabled = true;

                    this.npcXCoord.Value = npcs.CoordX;
                    this.npcYCoord.Value = npcs.CoordY;
                    this.npcZCoord.Value = npcs.CoordZ;
                    this.npcRadialPosition.SelectedIndex = npcs.RadialPosition;
                    this.npcsShowNPC.Checked = npcs.CoordXBit7;
                    this.npcsZCoordPlusHalf.Checked = npcs.CoordYBit7;

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
                    this.npcAttributesBattle.SetItemChecked(0, npcs.B8b0);
                    this.npcAttributesBattle.SetItemChecked(1, npcs.B8b1);
                    this.npcAttributesBattle.SetItemChecked(2, npcs.B8b2);
                    this.npcAttributesBattle.SetItemChecked(3, npcs.B8b3);

                    this.npcEngageTrigger.SelectedIndex = npcs.EngageTrigger;
                    this.npcMovement.Value = npcs.Movement;
                    this.npcID.Value = npcs.NPCID;
                    this.npcPaletteIndexPlus.Value = npcs.PaletteIndexPlus;
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
                        this.label104.Text = "Star XP";
                        this.label31.Text = "Treasure";
                        this.buttonGotoA.Text = "Event #";
                        this.label116.Text = "{N/A}";
                        this.npcPropertyA.Maximum = 15;
                        this.npcPropertyB.Maximum = 15;
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
                this.npcRemoveInstance.Enabled = false;
                this.npcRemoveObject.Enabled = false;
                this.npcInsertInstance.Enabled = false;

                this.npcEngageType.Enabled = false;

                this.npcXCoord.Enabled = false;
                this.npcYCoord.Enabled = false;
                this.npcZCoord.Enabled = false;
                this.npcRadialPosition.Enabled = false;
                this.npcPropertyA.Enabled = false;
                this.npcPropertyB.Enabled = false;
                this.npcPropertyC.Enabled = false;
                this.npcsShowNPC.Enabled = false;
                this.npcsZCoordPlusHalf.Enabled = false;

                this.npcAttributes.Enabled = false;
                this.npcAttributesBattle.Enabled = false;
                this.npcEngageTrigger.Enabled = false;
                this.npcMovement.Enabled = false;
                this.npcID.Enabled = false;
                this.npcPaletteIndexPlus.Enabled = false;
                this.npcEventORPack.Enabled = false;
                this.npcSpeedPlus.Enabled = false;

                this.npcXCoord.Value = 0;
                this.npcYCoord.Value = 0;
                this.npcZCoord.Value = 0;
                this.npcRadialPosition.SelectedIndex = 0;
                this.npcsShowNPC.Checked = false;
                this.npcsZCoordPlusHalf.Checked = false;

                for (int i = 0; i < npcAttributes.Items.Count; i++)
                    npcAttributes.SetItemChecked(i, false);
                for (int i = 0; i < npcAttributesBattle.Items.Count; i++)
                    npcAttributesBattle.SetItemChecked(i, false);

                this.npcEngageTrigger.SelectedIndex = 0;
                this.npcMovement.Value = 0;
                this.npcID.Value = 0;
                this.npcPaletteIndexPlus.Value = 0;
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

            updatingLevel = false;
        }

        private bool CalculateFreeNPCSpace(int amt)
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                if (levels[i].LevelNPCs.NumberOfNPCs > 0) used++;   // for the map header
                for (int j = 0; j < levels[i].LevelNPCs.NumberOfNPCs; j++)
                {
                    levels[i].LevelNPCs.CurrentNPC = j;
                    used += 12;

                    for (int k = 0; k < levels[i].LevelNPCs.NumberOfInstances; k++)
                        used += 4;

                    if ((used + amt) > 0x7BFF)
                    {
                        MessageBox.Show("WARNING: Cannot insert the NPC. The total number of NPCs for all levels has exceeded the maximum allotted space.", "TOTAL NPCS LENGTH EXCEEDED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }
            }

            return false;
        }
        private void SetOverNPC()
        {
            int currentNPC = npcs.CurrentNPC;
            int currentInstance = 0;
            bool breakTwice = false;
            for (int i = 0; i < npcObjectTree.Nodes.Count; i++)
            {
                npcs.CurrentNPC = i;
                if (npcs.CoordX == orthCoordX && npcs.CoordY == orthCoordY)
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                    overNPC = i + 1;
                    overInstance = 0;
                    isOverSomething = true;
                    break;
                }
                else
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                    overNPC = 0;
                    isOverSomething = false;
                }

                // for all of the instances
                if (npcs.NumberOfInstances != 0)
                    currentInstance = npcs.CurrentInstance;
                for (int j = 0; j < npcs.NumberOfInstances; j++)
                {
                    npcs.CurrentInstance = j;
                    if (npcs.InstanceCoordX == orthCoordX && npcs.InstanceCoordY == orthCoordY)
                    {
                        this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                        overNPC = i + 1;
                        overInstance = j + 1;
                        breakTwice = true;
                        isOverSomething = true;
                        break;
                    }
                    else
                    {
                        this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                        overInstance = 0;
                        isOverSomething = false;
                    }
                }
                if (npcs.NumberOfInstances != 0)
                    npcs.CurrentInstance = currentInstance;
                if (breakTwice)
                    break;
            }
            npcs.CurrentNPC = currentNPC;
        }

        private void AddNewNPC()
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeNPCSpace(12))
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
                    for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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
                    MessageBox.Show("WARNING: Cannot insert anymore NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.", "WARNING: Cannot insert any more NPCs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AddNewInstance()
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeNPCSpace(4))
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
                    for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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
                    MessageBox.Show("WARNING: Cannot insert anymore NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.", "WARNING: Cannot insert any more NPCs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AddNewNPC(LevelNPCs.NPC e)
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeNPCSpace(12))
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
                    for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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
                    MessageBox.Show("WARNING: Cannot insert anymore NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.", "WARNING: Cannot insert any more NPCs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AddNewInstance(LevelNPCs.NPC.Instance e)
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeNPCSpace(4))
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
                    for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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
                    MessageBox.Show("WARNING: Cannot insert anymore NPCs. The maximum number of NPCs plus instance NPCs allowed is 28.", "WARNING: Cannot insert any more NPCs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Event Handlers

        private void npcObjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (updatingLevel) return;

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

            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (this.npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;

            RefreshNPCProperties();
        }
        private void npcObjectTree_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.C:
                    if (npcObjectTree.SelectedNode != null)
                    {
                        if (npcObjectTree.SelectedNode.Parent != null)
                            npcCopy = npcs.Npc.INSTANCE;
                        else
                            npcCopy = npcs.Npc;
                    }
                    break;
                case Keys.V:
                    switch (npcCopy.GetType().ToString())
                    {
                        case "SMRPGED.LevelNPCs+NPC":
                            AddNewNPC((LevelNPCs.NPC)npcCopy);
                            break;
                        //case "SMRPGED.LevelNPCs+NPC+Instance":
                        //    AddNewInstance((LevelNPCs.NPC.Instance)npcCopy);
                        //    break;
                    }
                    break;
            }
        }
        private void npcInsertObject_Click(object sender, System.EventArgs e)
        {
            AddNewNPC();
        }
        private void npcRemoveObject_Click(object sender, System.EventArgs e)
        {
            this.npcObjectTree.Focus();
            if (this.npcObjectTree.SelectedNode != null && npcs.CurrentNPC == this.npcObjectTree.SelectedNode.Index)
            {
                npcs.RemoveCurrentNPC();

                int reselect = npcObjectTree.SelectedNode.Index;
                if (reselect == npcObjectTree.Nodes.Count - 1)
                    reselect--;

                npcObjectTree.BeginUpdate();

                this.npcObjectTree.Nodes.Clear();

                for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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

                    overlay.DrawLevelNPCs(npcs, npcProperties);
                    pictureBoxLevel.Invalidate();

                    RefreshNPCProperties();
                }

                npcObjectTree.EndUpdate();
            }
        }
        private void npcInsertInstance_Click(object sender, System.EventArgs e)
        {
            AddNewInstance();
        }
        private void npcRemoveInstance_Click(object sender, System.EventArgs e)
        {
            this.npcObjectTree.Focus();
            if (this.npcObjectTree.SelectedNode != null && npcs.CurrentInstance == this.npcObjectTree.SelectedNode.Index)
            {
                npcs.RemoveCurrentInstance();

                int reselectP = npcObjectTree.SelectedNode.Parent.Index;
                int reselectC = npcObjectTree.SelectedNode.Index;
                if (reselectC == npcObjectTree.SelectedNode.Parent.Nodes.Count - 1)
                    reselectC--;

                this.npcObjectTree.BeginUpdate();

                this.npcObjectTree.Nodes.Clear();
                for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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
        }
        
        private void openPartitions_Click(object sender, System.EventArgs e)
        {
            Form openSpritePartitions = new OpenNPCSpritePartitions(npcSpritePartitions, npcs.MapHeader);
            openSpritePartitions.Show();
        }
        private void findNPCNum_Click(object sender, EventArgs e)
        {
            Form findNPCNumber = new SearchNPC(npcProperties, this);
            findNPCNumber.Show();
        }

        private void npcSpeedPlus_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.SpeedPlus = (byte)this.npcSpeedPlus.Value;
        }
        private void npcEventORPack_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.EventORpack = (ushort)this.npcEventORPack.Value;
        }
        private void npcPaletteIndexPlus_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.PaletteIndexPlus = (byte)this.npcPaletteIndexPlus.Value;
        }
        public void npcID_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
            npcs.NPCID = (ushort)this.npcID.Value;

            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcMovement_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.Movement = (ushort)this.npcMovement.Value;
        }
        private void npcEngageTrigger_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.EngageTrigger = (byte)this.npcEngageTrigger.SelectedIndex;
        }
        private void npcPropertyA_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

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

            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcPropertyB_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
                npcs.InstancePropertyB = (byte)this.npcPropertyB.Value;
            else
                npcs.PropertyB = (byte)this.npcPropertyB.Value;
        }
        private void npcPropertyC_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
                npcs.InstancePropertyC = (byte)this.npcPropertyC.Value;
            else
                npcs.PropertyC = (byte)this.npcPropertyC.Value;
        }
        private void npcRadialPosition_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceRadialPosition = (byte)this.npcRadialPosition.SelectedIndex;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.RadialPosition = (byte)this.npcRadialPosition.SelectedIndex;
            }
            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcZCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordZ = (byte)this.npcZCoord.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordZ = (byte)this.npcZCoord.Value;
            }
            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcYCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordY = (byte)this.npcYCoord.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordY = (byte)this.npcYCoord.Value;
            }
            if (!waitBothCoords)
            {
                overlay.DrawLevelNPCs(npcs, npcProperties);
                pictureBoxLevel.Invalidate();
            }

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcXCoord_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordX = (byte)this.npcXCoord.Value;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordX = (byte)this.npcXCoord.Value;
            }
            if (!waitBothCoords)
            {
                overlay.DrawLevelNPCs(npcs, npcProperties);
                pictureBoxLevel.Invalidate();
            }

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcsShowNPC_CheckedChanged(object sender, System.EventArgs e)
        {
            if (npcsShowNPC.Checked) npcsShowNPC.ForeColor = Color.Black;
            else npcsShowNPC.ForeColor = Color.Gray;
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordXBit7 = this.npcsShowNPC.Checked;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordXBit7 = this.npcsShowNPC.Checked;
            }
            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcsZCoordPlusHalf_CheckedChanged(object sender, System.EventArgs e)
        {
            if (npcsZCoordPlusHalf.Checked) npcsZCoordPlusHalf.ForeColor = Color.Black;
            else npcsZCoordPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
                npcs.InstanceCoordYBit7 = this.npcsZCoordPlusHalf.Checked;
            }
            else
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
                npcs.CoordYBit7 = this.npcsZCoordPlusHalf.Checked;
            }
            overlay.DrawLevelNPCs(npcs, npcProperties);
            pictureBoxLevel.Invalidate();

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcEngageType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

            npcs.EngageType = (byte)this.npcEngageType.SelectedIndex;
            updatingProperties = true;
            if (this.npcEngageType.SelectedIndex == 0)
            {
                this.label104.Text = "NPC #+";  //propertyA
                this.label31.Text = "Event #+"; //propertyB
                this.buttonGotoA.Text = "Event #"; //eventorpack
                this.label116.Text = "Action #+";//propertyC
                this.npcPropertyA.Maximum = 7;
                this.npcPropertyB.Maximum = 7;
                this.npcPropertyC.Enabled = true;
                this.npcEventORPack.Maximum = 4095;
                this.npcAttributesBattle.Enabled = false;
            }
            else if (this.npcEngageType.SelectedIndex == 1)
            {
                this.label104.Text = "Star XP"; //propertyA
                this.label31.Text = "Treasure"; //propertyB
                this.buttonGotoA.Text = "Event #"; //eventorpack
                this.label116.Text = "<...>";   //propertyC
                this.npcPropertyA.Maximum = 15;
                this.npcPropertyB.Maximum = 15;
                this.npcPropertyC.Enabled = false;
                this.npcEventORPack.Maximum = 4095;
                this.npcAttributesBattle.Enabled = false;
            }
            else if (this.npcEngageType.SelectedIndex == 2)
            {
                this.label104.Text = "Action #+";   //propertyA
                this.label31.Text = "Pack #+";      //propertyB
                this.buttonGotoA.Text = "Pack #";      //eventorpack
                this.label116.Text = "<...>";       //propertyC
                this.npcPropertyA.Maximum = 15;
                this.npcPropertyB.Maximum = 15;
                this.npcPropertyC.Enabled = false;
                this.npcEventORPack.Maximum = 255;
                this.npcAttributesBattle.Enabled = true;
            }
            updatingProperties = false;
            if (!updatingLevel && state.Objects)
            {
                overlay.DrawLevelNPCs(npcs, npcProperties);
                pictureBoxLevel.Invalidate();
            }

            if (npcObjectTree.SelectedNode.Parent != null)
            {
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Parent.Index;
                npcs.CurrentInstance = this.npcObjectTree.SelectedNode.Index;
            }
            else
                npcs.CurrentNPC = this.npcObjectTree.SelectedNode.Index;
        }
        private void npcMapHeader_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingLevel) return;

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
        }
        private void npcAttributesBattle_SelectedIndexChanged(object sender, EventArgs e)
        {
            npcs.B8b0 = this.npcAttributesBattle.GetItemChecked(0);
            npcs.B8b1 = this.npcAttributesBattle.GetItemChecked(1);
            npcs.B8b2 = this.npcAttributesBattle.GetItemChecked(2);
            npcs.B8b3 = this.npcAttributesBattle.GetItemChecked(3);
        }

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
            for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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

            if (this.npcObjectTree.SelectedNode.Parent != null && npcs.CurrentInstance < npcs.NumberOfInstances - 1)
            {
                instanceSelected = true;
                reselectP = npcObjectTree.SelectedNode.Parent.Index;
                reselectC = npcObjectTree.SelectedNode.Index + 1;
                npcs.ReverseInstance(npcs.CurrentInstance);
            }
            else if (this.npcObjectTree.SelectedNode.Parent == null && npcs.CurrentNPC < npcs.NumberOfNPCs - 1)
            {
                reselectP = npcObjectTree.SelectedNode.Index + 1;
                npcs.ReverseNPC(npcs.CurrentNPC);
            }
            else return;

            this.npcObjectTree.BeginUpdate();

            this.npcObjectTree.Nodes.Clear();
            for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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

        private void buttonGotoA_Click(object sender, EventArgs e)
        {
            if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                model.Program.CreateScriptsWindow();

            model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
            model.Program.Scripts.EventName.SelectedIndex = 0;
            model.Program.Scripts.EventNum.Value = npcEventORPack.Value;
            model.Program.Scripts.BringToFront();
        }
        private void buttonGotoB_Click(object sender, EventArgs e)
        {
            if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                model.Program.CreateScriptsWindow();

            model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
            model.Program.Scripts.EventName.SelectedIndex = 1;
            model.Program.Scripts.EventNum.Value = npcMovement.Value;
            model.Program.Scripts.BringToFront();
        }

        #endregion
    }
}
