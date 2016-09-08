using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LazyShell.Areas
{
    public partial class SpaceAnalyzer : Controls.NewForm
    {
        #region Variables

        private ListViewColumnSorter lvwColumnSorter;

        #endregion

        // Constructor
        public SpaceAnalyzer()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeControls();
            BuildAnalysisTable();
        }

        #region Methods

        private void InitializeVariables()
        {
            lvwColumnSorter = new ListViewColumnSorter();
        }
        private void InitializeControls()
        {
            this.tilemapListView.ListViewItemSorter = lvwColumnSorter;
            this.collisionmapListView.ListViewItemSorter = lvwColumnSorter;
        }
        //
        private void BuildAnalysisTable()
        {
            ProgressBar pBar = new ProgressBar(Model.ROM, "CALCULATING...", 428);
            pBar.Show();

            #region Tilemaps

            int bank = 0x160000; // Set bank pointer
            int index = 0;       // Set initial index for this bank
            int bankIndex = 0;
            int offset = 0x00DA; // Set initial offset for this bank
            //
            Color bg = Color.White;
            for (; index < 109; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.Tilemaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                tilemapListView.Items.Add(item);
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }
            bank = 0x170000; // Set bank pointer
            index = 109;     // Set initial index for this bank
            bankIndex = 0;
            offset = 0x006C; // Set initial offset for this bank
            bg = Color.FromArgb(240, 240, 240);
            for (; index < 163; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.Tilemaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                tilemapListView.Items.Add(item);
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }
            bank = 0x180000; // Set bank pointer
            index = 163;     // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0070; // Set initial offset for this bank
            bg = Color.FromArgb(224, 224, 224);
            for (; index < 219; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.Tilemaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                tilemapListView.Items.Add(item);
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }
            bank = 0x190000; // Set bank pointer
            index = 219;     // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0070; // Set initial offset for this bank
            bg = Color.FromArgb(240, 240, 240);
            for (; index < 275; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.Tilemaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                tilemapListView.Items.Add(item);
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }
            bank = 0x1A0000; // Set bank pointer
            index = 275;     // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0044; // Set initial offset for this bank
            bg = Color.FromArgb(255, 255, 255);
            for (; index < 309; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.Tilemaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                tilemapListView.Items.Add(item);
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }

            #endregion

            #region Collision Maps

            bank = 0x1B0000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x00A0; // Set initial offset for this bank
            bg = Color.White;
            for (; index < 80; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.CollisionMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                collisionmapListView.Items.Add(item);
                pBar.PerformStep("COLLISION MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }
            bank = 0x1C0000; // Set bank pointer
            index = 80; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0050; // Set initial offset for this bank
            bg = Color.FromArgb(240, 240, 240);
            for (; index < 120; index++, bankIndex++)
            {
                int size = Comp.Compress(Model.CollisionMaps[index], null);
                if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }
                var item = new ListViewItem(new string[]
                {
                    index.ToString(),
                    (bank >> 16).ToString("X2"),
                    (bank + (bankIndex * 2)).ToString("X2"),
                    (bank + offset).ToString("X6"),
                    size.ToString("X"), 
                    (0xFFFF - (offset + size + 1)).ToString("X"),
                });
                item.BackColor = bg;
                collisionmapListView.Items.Add(item);
                pBar.PerformStep("COLLISION MAP #" + index.ToString("d3"));
                offset++;
                offset += size;
            }

            #endregion

            pBar.Close();
        }

        #endregion

        #region Event Handlers

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            listView.Sort();
        }

        #endregion
    }
}