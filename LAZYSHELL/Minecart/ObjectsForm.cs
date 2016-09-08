using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Minecart
{
    public partial class ObjectsForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private ScreensForm screensForm
        {
            get { return ownerForm.ScreensForm; }
            set { ownerForm.ScreensForm = value; }
        }

        // Index
        private int Index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }
        
        // Elements
        private MinecartData MinecartData
        {
            get { return ownerForm.MinecartData; }
            set { ownerForm.MinecartData = value; }
        }
        private List<MinecartObject> minecartObjects
        {
            get { return screensForm.MinecartObjects; }
            set { screensForm.MinecartObjects = value; }
        }
        private MinecartObject minecartObject
        {
            get { return screensForm.MinecartObject; }
            set { screensForm.MinecartObject = value; }
        }
        private PictureBox picture
        {
            get { return screensForm.Picture; }
            set { screensForm.Picture = value; }
        }
        public NumericUpDown X
        {
            get { return x; }
            set { x = value; }
        }
        public NumericUpDown Y
        {
            get { return y; }
            set { y = value; }
        }
        public int ObjectIndex
        {
            get { return listBoxObjects.SelectedIndex; }
            set { listBoxObjects.SelectedIndex = value; }
        }

        #endregion

        // Constructor
        public ObjectsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
        }

        #region Methods

        public void InitializeObjects()
        {
            listBoxObjects.Items.Clear();
            for (int i = 0; i < minecartObjects.Count; i++)
                listBoxObjects.Items.Add("Object " + i);
            if (minecartObjects.Count > 0)
                ObjectIndex = 0;
        }
        private void RefreshObject()
        {
            this.Updating = true;
            type.SelectedIndex = minecartObject.Type;
            count.Value = minecartObject.Count;
            x.Value = minecartObject.X;
            y.Value = minecartObject.Y;
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // ListBox
        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshObject();
            picture.Invalidate();
        }

        // Collection editing
        private void newObject_Click(object sender, EventArgs e)
        {
            if (minecartObjects.Count >= 255)
            {
                MessageBox.Show("Cannot have more than 255 objects.");
                return;
            }
            int index = ObjectIndex;
            int x = Math.Abs(screensForm.ScreensPanel.AutoScrollPosition.X);
            MinecartObject newObject = new MinecartObject(1, Math.Max(272, x + 16), 16, 1);
            minecartObjects.Insert(ObjectIndex + 1, newObject);
            listBoxObjects.Items.Clear();
            for (int i = 0; i < minecartObjects.Count; i++)
                listBoxObjects.Items.Add("Object " + i);
            ObjectIndex = index + 1;
        }
        private void deleteObject_Click(object sender, EventArgs e)
        {
            int index = ObjectIndex;
            minecartObjects.RemoveAt(index);
            listBoxObjects.Items.Clear();
            for (int i = 0; i < minecartObjects.Count; i++)
                listBoxObjects.Items.Add("Object " + i);
            if (index < listBoxObjects.Items.Count)
                ObjectIndex = index;
            else
                ObjectIndex = index - 1;
        }
        private void duplicateObject_Click(object sender, EventArgs e)
        {
            if (minecartObjects.Count >= 255)
            {
                MessageBox.Show("Cannot have more than 255 objects.");
                return;
            }
            int index = ObjectIndex;
            minecartObjects.Insert(ObjectIndex, minecartObject.Copy());
            listBoxObjects.Items.Clear();
            for (int i = 0; i < minecartObjects.Count; i++)
                listBoxObjects.Items.Add("Object " + i);
            ObjectIndex = index + 1;
        }
        private void moveObjectBack_Click(object sender, EventArgs e)
        {
            if (ObjectIndex == 0)
                return;
            minecartObjects.Reverse(ObjectIndex - 1, 2);
            ObjectIndex--;
        }
        private void moveObjectForward_Click(object sender, EventArgs e)
        {
            if (ObjectIndex == listBoxObjects.Items.Count - 1)
                return;
            minecartObjects.Reverse(ObjectIndex, 2);
            ObjectIndex++;
        }

        // Object properties
        private void objectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            minecartObject.Type = (int)type.SelectedIndex;
            picture.Invalidate();
        }
        private void rowSize_ValueChanged(object sender, EventArgs e)
        {
            minecartObject.Count = (int)count.Value;
            picture.Invalidate();
        }
        private void objectX_ValueChanged(object sender, EventArgs e)
        {
            minecartObject.X = (int)x.Value;
            picture.Invalidate();
        }
        private void objectY_ValueChanged(object sender, EventArgs e)
        {
            minecartObject.Y = (int)y.Value;
            picture.Invalidate();
        }

        #endregion
    }
}
