using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class FindReferences : Controls.NewForm
    {
        #region Variables

        private Delegate performSearch;
        private Delegate loadResult;

        #endregion

        /// <summary>
        /// Class for finding references to an element index, displaying the results categorically in a TreeView control.
        /// </summary>
        /// <param name="loadResult">The function to execute when a search result has been selected in the TreeView.</param>
        public FindReferences(Delegate performSearch, Delegate loadResult)
        {
            this.performSearch = performSearch;
            this.loadResult = loadResult;
            InitializeComponent();
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y - 10;
            if (this.performSearch != null)
                performSearch.DynamicInvoke(this.treeView1);
            this.treeView1.ExpandAll();
        }
        public void Reload()
        {
            treeView1.Nodes.Clear();
            if (this.performSearch != null)
                performSearch.DynamicInvoke(this.treeView1);
        }

        // Methods
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // don't load result if node is just a category or has no data associated
            if (e.Node.Parent == null || e.Node.Tag == null)
                return;
            // run the function in the target form
            if (loadResult != null)
                loadResult.DynamicInvoke(e.Node.Tag);
        }
    }
}
