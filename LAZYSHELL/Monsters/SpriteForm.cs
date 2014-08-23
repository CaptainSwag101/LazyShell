using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Monsters
{
    public partial class SpriteForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;

        // Elements
        private Monster monster
        {
            get { return ownerForm.Monster; }
            set { ownerForm.Monster = value; }
        }

        // Picture
        private Bitmap monsterImage;
        private bool waitBothCoords = false;
        private bool overTarget = false;

        #endregion

        /// <summary>
        /// Loads the monster's sprite properties form
        /// </summary>
        public SpriteForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeComponent();
            InitializeListControls();
            LoadProperties();
        }

        #region Methods

        private void InitializeListControls()
        {
            this.entranceStyle.Items.AddRange(Lists.BattleEntrances);
        }
        public void LoadProperties()
        {
            this.targetArrowX.Value = monster.CursorX;
            this.targetArrowY.Value = monster.CursorY;
            monsterImage = new Bitmap(monster.Image);
            pictureBox.Invalidate();
            //
            this.coinSize.SelectedIndex = monster.CoinSize;
            this.spriteBehavior.SelectedIndex = monster.SpriteBehavior;
            this.entranceStyle.SelectedIndex = monster.EntranceStyle;
            this.elevation.Value = monster.Elevation;
        }

        #endregion

        #region Event Handlers

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = 15 - (e.X / 8); int y = 15 - (e.Y / 8);
            if (x > 15) x = 15; if (x < 0) x = 0;
            if (y > 15) y = 15; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left)
            {
                if (overTarget)
                {
                    if (targetArrowX.Value != x && targetArrowY.Value != y)
                        waitBothCoords = true;
                    targetArrowX.Value = x;
                    waitBothCoords = false;
                    targetArrowY.Value = y;
                }
            }
            else
            {
                if ((128 - (targetArrowX.Value * 8) > e.X && 128 - (targetArrowX.Value * 8) < e.X + 16) &&
                    (128 - (targetArrowY.Value * 8) > e.Y && 128 - (targetArrowY.Value * 8) < e.Y + 16))
                {
                    pictureBox.Cursor = Cursors.Hand;
                    overTarget = true;
                }
                else
                {
                    pictureBox.Cursor = Cursors.Arrow;
                    overTarget = false;
                }
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            monsterImage = new Bitmap(monster.Image);
            pictureBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (monsterImage != null)
                e.Graphics.DrawImage(monsterImage, 0, 0);
        }
        private void targetArrowX_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorX = (byte)targetArrowX.Value;
            //
            if (waitBothCoords)
                return;
            monsterImage = new Bitmap(monster.Image);
            pictureBox.Invalidate();
        }
        private void targetArrowY_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorY = (byte)targetArrowY.Value;
            //
            if (waitBothCoords)
                return;
            monsterImage = new Bitmap(monster.Image);
            pictureBox.Invalidate();
        }
        private void coinSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.CoinSize = (byte)coinSize.SelectedIndex;
        }
        private void entranceStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.EntranceStyle = (byte)entranceStyle.SelectedIndex;
        }
        private void spriteBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.SpriteBehavior = (byte)spriteBehavior.SelectedIndex;
        }
        private void elevation_ValueChanged(object sender, EventArgs e)
        {
            monster.Elevation = (byte)elevation.Value;
        }

        #endregion
    }
}
