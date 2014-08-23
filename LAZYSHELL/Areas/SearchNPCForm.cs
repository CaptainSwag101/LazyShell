using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Areas;

namespace LAZYSHELL.Areas
{
    public partial class SearchNPCForm : Controls.NewForm
    {
        #region Variables

        private NPCEditor ownerForm;
        private Search searchWindow;
        private NPCProperties[] npcProperties
        {
            get { return Model.NPCProperties; }
            set { Model.NPCProperties = value; }
        }

        #endregion

        // Constructor
        public SearchNPCForm(NPCEditor ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeListControls();
            InitializeForms();
        }

        #region Methods

        private void InitializeListControls()
        {
            spriteName.Items.AddRange(Lists.Numerize(Lists.Sprites));
            spriteName.SelectedIndex = 0;
        }
        private void InitializeForms()
        {
            searchWindow = new Search(spriteName, search, spriteName.Items);
        }
        //
        private void PerformSearch()
        {
            searchResults.BeginUpdate();
            searchResults.Items.Clear();
            for (int i = 0; i < npcProperties.Length; i++)
            {
                if (spriteName.SelectedIndex == npcProperties[i].Sprite)
                    searchResults.Items.Add(npcProperties[i]);
            }
            searchResults.EndUpdate();
        }

        #endregion

        #region Event Handlers

        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchResults.SelectedItem == null)
                return;
            var npcID = searchResults.SelectedItem as NPCProperties;
            ownerForm.Index = Convert.ToInt32(npcID.Index);
        }

        #endregion
    }
}
