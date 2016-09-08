using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.EventScripts;

namespace LazyShell
{
    public partial class ClearElements : Controls.NewForm
    {
        #region Variables

        private object element;
        private int currentIndex;
        private int start = 0;
        private int end = 0;

        #endregion

        // Constructor
        public ClearElements(object element, int currentIndex, string title)
        {
            this.Text = title;
            this.element = element;
            this.currentIndex = currentIndex;
            //
            InitializeComponent();
            SetIndexBoundaries();
        }

        // Methods
        private void SetIndexBoundaries()
        {
            if (element != null)
                toIndex.Value = toIndex.Maximum = (element as object[]).Length - 1;
            else if (this.Text == "CLEAR AREA DATA...")
                toIndex.Value = toIndex.Maximum = Areas.Model.Areas.Length - 1;
            else if (this.Text == "CLEAR TILESETS...")
                toIndex.Value = toIndex.Maximum = Areas.Model.Tilesets.Length - 1;
            else if (this.Text == "CLEAR TILEMAPS...")
                toIndex.Value = toIndex.Maximum = Areas.Model.Tilemaps.Length - 1;
            else if (this.Text == "CLEAR COLLISION MAPS...")
                toIndex.Value = toIndex.Maximum = Areas.Model.CollisionMaps.Length - 1;
            else if (this.Text == "CLEAR BATTLEFIELD TILESETS...")
                toIndex.Value = toIndex.Maximum = Battlefields.Model.Tilesets.Length - 1;
            this.start = this.end = this.currentIndex;
        }

        #region Event Handlers

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                fromIndex.Enabled = false;
                toIndex.Enabled = false;
                start = end = currentIndex;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                fromIndex.Enabled = true;
                toIndex.Enabled = true;
                start = (int)fromIndex.Value;
                end = (int)toIndex.Value;
            }
        }
        private void fromDialogue_ValueChanged(object sender, EventArgs e)
        {
            toIndex.Minimum = fromIndex.Value;
            start = (int)fromIndex.Value;
        }
        private void toDialogue_ValueChanged(object sender, EventArgs e)
        {
            fromIndex.Maximum = toIndex.Value;
            end = (int)toIndex.Value;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            for (int i = start; element != null && i <= end; i++)
                (element as Element[])[i].Clear();
            if (element == null && this.Text == "CLEAR AREA DATA...")
            {
                for (int i = start; i <= end; i++)
                {
                    Areas.Model.Areas[i].Layering.Clear();
                    Areas.Model.Areas[i].EventTriggers.Clear();
                    Areas.Model.Areas[i].ExitTriggers.Clear();
                    Areas.Model.Areas[i].NPCObjects.Clear();
                    Areas.Model.Areas[i].Overlaps.Clear();
                    int levelMap = Areas.Model.Areas[i].Map;
                    Areas.Model.Maps[levelMap].Clear();
                }
            }
            if (element == null && this.Text == "CLEAR TILESETS...")
            {
                for (int i = start; i <= end; i++)
                {
                    if (i < 0x20)
                        Areas.Model.Tilesets[i] = new byte[0x1000];
                    else
                        Areas.Model.Tilesets[i] = new byte[0x2000];
                    Areas.Model.Modify_Tilesets[i] = true;
                }
            }
            if (element == null && this.Text == "CLEAR TILEMAPS...")
            {
                for (int i = start; i <= end; i++)
                {
                    if (i < 0x40)
                        Areas.Model.Tilemaps[i] = new byte[0x1000];
                    else
                        Areas.Model.Tilemaps[i] = new byte[0x2000];
                    Areas.Model.Modify_Tilemaps[i] = true;
                }
            }
            if (element == null && this.Text == "CLEAR COLLISION MAPS...")
            {
                for (int i = start; i <= end; i++)
                {
                    Areas.Model.CollisionMaps[i] = new byte[0x20C2];
                    Areas.Model.Modify_CollisionMaps[i] = true;
                }
            }
            if (element == null && this.Text == "CLEAR BATTLEFIELD TILESETS...")
            {
                for (int i = start; i <= end; i++)
                {
                    Battlefields.Model.Tilesets[i] = new byte[0x2000];
                    Battlefields.Model.EditTilesets[i] = true;
                }
            }
            this.Tag = new Point(start, end);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
