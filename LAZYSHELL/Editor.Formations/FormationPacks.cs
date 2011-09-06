using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class FormationPacks : Form
    {
        #region Variables
        
        private delegate void Function(TreeView treeView, StringComparison stringComparison, bool matchWholeWord);
        private int index { get { return (int)packNum.Value; } set { packNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        private FormationPack[] packs { get { return Model.FormationPacks; } set { Model.FormationPacks = value; } }
        private FormationPack pack { get { return packs[index]; } set { packs[index] = value; } }
        public FormationPack Pack { get { return pack; } set { pack = value; } }
        private bool updating = false;
        private Formation[] formations { get { return Model.Formations; } }
        private Formations formationsEditor;
        public Search searchWindow;
        #endregion
        // constructor
        public FormationPacks(Formations formationsEditor)
        {
            this.formationsEditor = formationsEditor;
            InitializeComponent();
            searchWindow = new Search(packNum, packNameTextBox, searchFormationPacks, new Function(LoadSearch), "treeView");
            RefreshFormationPacks();
        }
        // functions
        public void SetToolTips(ToolTip toolTip1)
        {
            // FORMATION PACKS
            this.packNum.ToolTipText =
                "Set the formation pack to edit by #.\n\n" +
                "A pack is a set of three formations to either randomly or\n" +
                "selectively choose from when a battle is called, through an\n" +
                "event script or through an the property of an NPC in a level.";
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
            this.packFormation1.Value = pack.PackFormations[0];
            this.packFormation2.Value = pack.PackFormations[1];
            this.packFormation3.Value = pack.PackFormations[2];
            RefreshFormationPackStrings();
            updating = false;
        }
        private void RefreshFormationPackStrings()
        {
            this.richTextBox2.Text = formations[pack.PackFormations[0]].FormationListSet;
            this.richTextBox3.Text = formations[pack.PackFormations[1]].FormationListSet;
            this.richTextBox4.Text = formations[pack.PackFormations[2]].FormationListSet;
        }
        private void LoadSearch(TreeView treeView, StringComparison stringComparison, bool matchWholeWord)
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
            foreach (FormationPack fp in packs)
            {
                if (Do.Contains(
                    formations[fp.PackFormations[0]].ToString(),
                    packNameTextBox.Text, stringComparison, matchWholeWord) ||
                    Do.Contains(
                    formations[fp.PackFormations[1]].ToString(),
                    packNameTextBox.Text, stringComparison, matchWholeWord) ||
                    Do.Contains(
                    formations[fp.PackFormations[2]].ToString(),
                    packNameTextBox.Text, stringComparison, matchWholeWord))
                {
                    tn = treeView.Nodes.Add("PACK #" + fp.Index);
                    tn.Tag = (int)fp.Index;

                    if (Do.Contains(
                        formations[fp.PackFormations[0]].ToString(),
                        packNameTextBox.Text, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.PackFormations[0]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.PackFormations[1]].ToString(),
                        packNameTextBox.Text, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.PackFormations[1]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.PackFormations[2]].ToString(),
                        packNameTextBox.Text, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.PackFormations[2]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                }
            }
            treeView.ExpandAll();
            treeView.EndUpdate();
        }
        // event handlers
        private void packNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshFormationPacks();
            Settings.Default.LastFormationPack = index;
        }
        private void packFormation1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.PackFormations[0] = (ushort)packFormation1.Value;

            RefreshFormationPackStrings();
        }
        private void packFormation2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.PackFormations[1] = (ushort)packFormation2.Value;

            RefreshFormationPackStrings();
        }
        private void packFormation3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            pack.PackFormations[2] = (ushort)packFormation3.Value;

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
