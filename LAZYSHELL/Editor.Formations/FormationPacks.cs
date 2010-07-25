using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class FormationPacks : Form
    {
        private delegate void Function(TreeView treeView);
        private int index { get { return (int)packNum.Value; } set { packNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        private Model model;
        private FormationPack[] packs { get { return model.FormationPacks; } set { model.FormationPacks = value; } }
        private FormationPack pack { get { return packs[index]; } set { packs[index] = value; } }
        private bool updating = false;
        private Formation[] formations { get { return model.Formations; } }
        private Formations formationsEditor;
        public FormationPacks(Model model, Formations formationsEditor)
        {
            this.model = model;
            this.formationsEditor = formationsEditor;
            InitializeComponent();
            new Search(packNum, packNameTextBox, searchFormationPacks, new Function(LoadSearch), "treeView");
            RefreshFormationPacks();
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            // FORMATION PACKS
            this.packNum.ToolTipText =
                "Set the formation pack to edit by #.\n\n" +
                "A pack is a set of three formations to either randomly or\n" +
                "selectively choose from when a battle is called, through an\n" +
                "event script or through an the property of an NPC in a level.";
            this.formationSet.ToolTipText =
                "The range of formations that are allowed in the pack. All 3\n" +
                "formations in a pack must be either within the range of 0-\n" +
                "255 or 256-511. Formations 256-511 generally include\n" +
                "bosses.";
            toolTip1.SetToolTip(this.packFormation1,
                "The 1st formation in the pack.");
            toolTip1.SetToolTip(this.packFormation2,
                "The 2nd formation in the pack.");
            toolTip1.SetToolTip(this.packFormation3,
                "The 3rd formation in the pack.");
            toolTip1.SetToolTip(this.packFormationButton1,
                "Load the 1st formation into the formation editor.");
            toolTip1.SetToolTip(this.packFormationButton2,
                "Load the 2nd formation into the formation editor.");
            toolTip1.SetToolTip(this.packFormationButton3,
                "Load the 3rd formation into the formation editor.");
            toolTip1.SetToolTip(this.richTextBox2,
                "The list of monsters in the 1st formation.");
            toolTip1.SetToolTip(this.richTextBox3,
                "The list of monsters in the 2nd formation.");
            toolTip1.SetToolTip(this.richTextBox4,
                "The list of monsters in the 3rd formation.");
        }
        public void RefreshFormationPacks()
        {
            if (updating) return;
            updating = true;
            this.formationSet.SelectedIndex = pack.FormationPackSet;
            this.packFormation1.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
            this.packFormation2.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
            this.packFormation3.Maximum = (this.formationSet.SelectedIndex == 0) ? 255 : 511;
            this.packFormation1.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
            this.packFormation2.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
            this.packFormation3.Minimum = (this.formationSet.SelectedIndex == 0) ? 0 : 256;
            if (formationSet.SelectedIndex == 0)
            {
                this.packFormation1.Value = pack.FormationPackForm[0];
                this.packFormation2.Value = pack.FormationPackForm[1];
                this.packFormation3.Value = pack.FormationPackForm[2];
            }
            else
            {
                this.packFormation1.Value = pack.FormationPackForm[0] + 256;
                this.packFormation2.Value = pack.FormationPackForm[1] + 256;
                this.packFormation3.Value = pack.FormationPackForm[2] + 256;
            }
            RefreshFormationPackStrings();
            updating = false;
        }
        private void RefreshFormationPackStrings()
        {
            int a = pack.FormationPackForm[0];
            int b = pack.FormationPackForm[1];
            int c = pack.FormationPackForm[2];
            if (formationSet.SelectedIndex == 1)
            {
                a += 256;
                b += 256;
                c += 256;
            }
            this.richTextBox2.Text = formations[a].FormationListSet;
            this.richTextBox3.Text = formations[b].FormationListSet;
            this.richTextBox4.Text = formations[c].FormationListSet;
        }
        private void LoadSearch(TreeView treeView)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            if (packNameTextBox.Text == "")
            {
                treeView.EndUpdate();
                return;
            }
            TreeNode tn;
            TreeNode cn;
            int set = 0;
            foreach (FormationPack fp in packs)
            {
                set = fp.FormationPackSet == 1 ? 256 : 0;

                if (Do.Contains(
                    formations[fp.FormationPackForm[0] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase) ||
                    Do.Contains(
                    formations[fp.FormationPackForm[1] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase) ||
                    Do.Contains(
                    formations[fp.FormationPackForm[2] + set].ToString(),
                    packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    tn = treeView.Nodes.Add("PACK #" + fp.Index);
                    tn.Tag = (int)fp.Index;

                    if (Do.Contains(
                        formations[fp.FormationPackForm[0] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formations[fp.FormationPackForm[0] + set].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.FormationPackForm[1] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formations[fp.FormationPackForm[1] + set].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.FormationPackForm[2] + set].ToString(),
                        packNameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cn = tn.Nodes.Add(formations[fp.FormationPackForm[2] + set].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                }
            }
            treeView.ExpandAll();
            treeView.EndUpdate();
        }
        private void packNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshFormationPacks();
        }
        private void formationSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.FormationPackSet = (byte)formationSet.SelectedIndex;

            RefreshFormationPacks();
        }
        private void packFormation1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.FormationPackForm[0] = (byte)((ushort)packFormation1.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormation2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.FormationPackForm[1] = (byte)((ushort)packFormation2.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormation3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.FormationPackForm[2] = (byte)((ushort)packFormation3.Value & 0xFF);

            RefreshFormationPackStrings();
        }
        private void packFormationButton1_Click(object sender, EventArgs e)
        {
            formationsEditor.Index = (int)packFormation1.Value;
        }
        private void packFormationButton2_Click(object sender, EventArgs e)
        {
            formationsEditor.Index = (int)packFormation2.Value;
        }
        private void packFormationButton3_Click(object sender, EventArgs e)
        {
            formationsEditor.Index = (int)packFormation3.Value;
        }
    }
}
