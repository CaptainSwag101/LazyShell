using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Formations
{
    public partial class PacksForm : Controls.DockForm
    {
        #region Variables
        
        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Forms
        private OwnerForm ownerForm;
        private FormationsForm formationsForm
        {
            get { return ownerForm.FormationsForm; }
            set { ownerForm.FormationsForm = value; }
        }
        private FindReferences findReferencesForm;
        public Search searchWindow;
        private EditLabel labelWindow;

        // Elements
        private Pack[] packs
        {
            get { return Model.Packs; }
            set { Model.Packs = value; }
        }
        private Pack pack
        {
            get { return packs[Index]; }
            set { packs[Index] = value; }
        }
        public Pack Pack
        {
            get { return pack; }
            set { pack = value; }
        }
        private Formation[] formations
        {
            get { return Model.Formations; }
        }
        private Monsters.Monster[] monsters
        {
            get { return Monsters.Model.Monsters; }
            set { Monsters.Model.Monsters = value; }
        }

        // Images
        private List<Bitmap>[] monsterImages;
        private List<Bitmap>[] shadowImages;

        // Functions
        private delegate void PerformSearchFunction(
            string searchFor, 
            TreeView treeView,
            StringComparison stringComparison,
            bool matchWholeWord);
        private delegate void FindReferencesFunction(
            TreeView treeView);

        #endregion

        // Constructor
        public PacksForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeVariables();
            InitializeComponent();
            CreateHelperForms();
            LoadProperties();
            //
            this.History = new History(this, null, num);
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            monsterImages = new List<Bitmap>[3];
            shadowImages = new List<Bitmap>[3];
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(num, search, new PerformSearchFunction(PerformSearch), typeof(TreeView));
            labelWindow = new EditLabel(null, num, "Packs", false);
        }
        public void LoadProperties()
        {
            if (this.Updating)
                return;
            this.Updating = true;
            //
            this.formation1.Value = pack.Formations[0];
            this.formation2.Value = pack.Formations[1];
            this.formation3.Value = pack.Formations[2];
            //
            SetFormationImages();
            SetFormationNameLists();
            //
            this.Updating = false;
        }
        private void SetFormationNameLists()
        {
            this.formation1Monsters.Text = formations[pack.Formations[0]].GetMonsterNames("\n", "—");
            this.formation2Monsters.Text = formations[pack.Formations[1]].GetMonsterNames("\n", "—");
            this.formation3Monsters.Text = formations[pack.Formations[2]].GetMonsterNames("\n", "—");
        }
        public void SetFormationImages()
        {
            // iterate through the 3 packs
            for (int c = 0; c < 3; c++)
            {
                var formation = formations[pack.Formations[c]];
                monsterImages[c] = new List<Bitmap>();
                shadowImages[c] = new List<Bitmap>();
                // iterate through the pack's 8 monsters
                for (int i = 0; i < 8; i++)
                {
                    int[] pixels = Monsters.Model.Monsters[formation.Monsters[i]].Pixels;
                    monsterImages[c].Add(Do.PixelsToImage(pixels, 256, 256));
                    pixels = Monsters.Model.Monsters[formation.Monsters[i]].Shadow;
                    shadowImages[c].Add(Do.PixelsToImage(pixels, 16, 16));
                }
                formation.PixelIndexes = null;
            }
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
            pictureBox3.Invalidate();
        }

        // Drawing
        private void DrawFormationImage(Formation formation, List<Bitmap> monsterImages, List<Bitmap> shadowImages, Graphics g)
        {
            // sort monsters by individual z (y) coord
            byte[] indexes = new byte[8];
            for (byte i = 0; i < 8; i++)
                indexes[i] = i;
            byte[] keys = Bits.Copy(formation.Y);
            Array.Sort(keys, indexes);

            // iterate through the pack's 8 monsters
            for (int a = 0; a < 8; a++)
            {
                int index = indexes[a];
                if (!formation.Active[index])
                    continue;
                int elevation = monsters[formation.Monsters[index]].Elevation * 16;

                // divide by half squeezes monsters together to conserve space on the drawing canvas
                int x = (int)((double)formation.X[index] / 2) - 8;
                int y = (int)((double)formation.Y[index] / 2) + 14;
                if (elevation > 0)
                    g.DrawImage(shadowImages[index], x, y);

                // divide by half squeezes monsters together to conserve space on the drawing canvas
                x = (int)((double)formation.X[index] / 2) - 128;
                y = (int)((double)formation.Y[index] / 2) - 96 - elevation - 1;
                g.DrawImage(monsterImages[index], x, y);
            }
        }

        // Search
        private void PerformSearch(string searchFor, TreeView treeView, StringComparison stringComparison, bool matchWholeWord)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            if (searchFor == "")
            {
                treeView.EndUpdate();
                return;
            }
            TreeNode tn;
            TreeNode cn;
            foreach (Pack fp in packs)
            {
                if (Do.Contains(
                    formations[fp.Formations[0]].ToString(),
                    searchFor, stringComparison, matchWholeWord) ||
                    Do.Contains(
                    formations[fp.Formations[1]].ToString(),
                    searchFor, stringComparison, matchWholeWord) ||
                    Do.Contains(
                    formations[fp.Formations[2]].ToString(),
                    searchFor, stringComparison, matchWholeWord))
                {
                    tn = treeView.Nodes.Add("PACK #" + fp.Index);
                    tn.Tag = (int)fp.Index;
                    if (Do.Contains(
                        formations[fp.Formations[0]].ToString(),
                        searchFor, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.Formations[0]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.Formations[1]].ToString(),
                        searchFor, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.Formations[1]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                    if (Do.Contains(
                        formations[fp.Formations[2]].ToString(),
                        searchFor, stringComparison, matchWholeWord))
                    {
                        cn = tn.Nodes.Add(formations[fp.Formations[2]].ToString());
                        cn.Tag = (int)fp.Index;
                    }
                }
            }
            treeView.ExpandAll();
            treeView.EndUpdate();
        }
        private void FindReferences(TreeView treeView)
        {

        }

        #endregion

        #region Event Handlers

        // Navigator
        private void num_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
            Settings.Default.LastFormationPack = Index;
        }

        // Properties
        private void formation1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            pack.Formations[0] = (ushort)formation1.Value;
            pictureBox1.Invalidate();
            SetFormationNameLists();
        }
        private void formation2_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            pack.Formations[1] = (ushort)formation2.Value;
            pictureBox2.Invalidate();
            SetFormationNameLists();
        }
        private void formation3_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            pack.Formations[2] = (ushort)formation3.Value;
            pictureBox3.Invalidate();
            SetFormationNameLists();
        }

        // Pictures
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var formation = formations[pack.Formations[0]];
            DrawFormationImage(formation, monsterImages[0], shadowImages[0], e.Graphics);
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            var formation = formations[pack.Formations[1]];
            DrawFormationImage(formation, monsterImages[1], shadowImages[1], e.Graphics);
        }
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            var formation = formations[pack.Formations[2]];
            DrawFormationImage(formation, monsterImages[2], shadowImages[2], e.Graphics);
        }

        // Load formation
        private void load1_Click(object sender, EventArgs e)
        {
            formationsForm.Index = pack.Formations[0];
        }
        private void load2_Click(object sender, EventArgs e)
        {
            formationsForm.Index = pack.Formations[1];
        }
        private void load3_Click(object sender, EventArgs e)
        {
            formationsForm.Index = pack.Formations[2];
        }

        // Search
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        #endregion
    }
}
