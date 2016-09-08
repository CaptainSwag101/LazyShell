using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Menus
{
    public partial class MenuCursorForm : Controls.NewForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;

        // Index
        public int Index
        {
            get { return name.SelectedIndex; }
            set { name.SelectedIndex = value; }
        }

        // Elements
        public CursorSprite[] CursorSprites
        {
            get { return Model.CursorSprites; }
            set { Model.CursorSprites = value; }
        }
        public CursorSprite CursorSprite
        {
            get { return CursorSprites[Index]; }
            set { CursorSprites[Index] = value; }
        }

        #endregion

        // Constructor
        public MenuCursorForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            InitializeListControls();
        }

        #region Methods

        // Initialization
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            spriteName.Items.AddRange(Lists.Resize(Lists.Numerize(3, Lists.Sprites), 256));
            name.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void InvalidateImage()
        {
            ownerForm.CursorImage = null;
            ownerForm.Picture.Invalidate();
        }

        // Saving
        public void WriteToROM()
        {
            for (int i = 0; i < CursorSprites.Length; i++)
                CursorSprites[i].WriteToROM();
        }

        #endregion

        #region Event Handlers

        // MenuCursorForm
        private void MenuCursorForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
        }

        // Navigator
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            spriteName.SelectedIndex = CursorSprite.Sprite;
            sequenceNum.Value = CursorSprite.Sequence;
            InvalidateImage();
        }

        // Properties
        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursorSprite.Sprite = spriteName.SelectedIndex;
            InvalidateImage();
        }
        private void sequenceNum_ValueChanged(object sender, EventArgs e)
        {
            CursorSprite.Sequence = (int)sequenceNum.Value;
            InvalidateImage();
        }

        #endregion
    }
}
