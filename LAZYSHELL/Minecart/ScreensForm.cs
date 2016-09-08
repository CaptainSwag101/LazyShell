using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.Areas;

namespace LazyShell.Minecart
{
    public partial class ScreensForm : Controls.DockForm
    {
        #region Variables

        // Index
        public int Index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }

        // Forms
        private OwnerForm ownerForm;
        private ObjectsForm objectsForm
        {
            get { return ownerForm.ObjectsForm; }
            set { ownerForm.ObjectsForm = value; }
        }

        private delegate void Function();
        private Settings settings = Settings.Default;
        private PaletteSet paletteSet
        {
            get { return ownerForm.PaletteSet; }
            set { ownerForm.PaletteSet = value; }
        }
        public Tileset Tileset
        {
            get { return ownerForm.Tileset; }
            set { ownerForm.Tileset = value; }
        }
        public Tileset BGTileset;
        private State state = State.Instance2;

        // Picture
        public PictureBox Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }
        private int objectIndex
        {
            get { return objectsForm.ObjectIndex; }
            set { objectsForm.ObjectIndex = value; }
        }
        public MinecartData MinecartData
        {
            get { return ownerForm.MinecartData; }
            set { ownerForm.MinecartData = value; }
        }
        public MinecartObject MinecartObject
        {
            get
            {
                return MinecartObjects[objectIndex];
            }
            set
            {
                MinecartObjects[objectIndex] = value;
            }
        }
        public List<MinecartObject> MinecartObjects
        {
            get
            {
                if (Index == 2)
                    return MinecartData.SSObjectsA;
                if (Index == 3)
                    return MinecartData.SSObjectsB;
                return null;
            }
            set
            {
                if (Index == 2)
                    MinecartData.SSObjectsA = value;
                if (Index == 3)
                    MinecartData.SSObjectsB = value;
            }
        }
        public Panel ScreensPanel
        {
            get { return this.screensPanel; }
            set { this.screensPanel = value; }
        }
        private List<Bitmap> screenImages;
        public Bitmap ScreenBGImage;
        private int screenIndex
        {
            get
            {
                if (screensPanel.Tag != null)
                    return (int)screensPanel.Tag;
                else
                    return 0;
            }
            set
            {
                if (value >= L1Indexes.Count)
                    value = 0;
                if (value < 0)
                    value = L1Indexes.Count - 1;
                if (L1Indexes.Count > 0)
                {
                    screensPanel.Tag = value;
                    this.Updating = true;
                    this.Updating = false;
                    RefreshScreen();
                }
                foreach (PictureBox picture in screensPanel.Controls)
                    picture.Invalidate();
            }
        }
        private List<int> L1Indexes
        {
            get
            {
                if (Index == 2)
                    return MinecartData.L1Screens;
                else
                    return MinecartData.RailScreens;
            }
            set
            {
                if (Index == 2)
                    MinecartData.L1Screens = value;
                else
                    MinecartData.RailScreens = value;
            }
        }
        private List<int> L2Indexes
        {
            get
            {
                if (Index == 2)
                    return MinecartData.L2Screens;
                return null;
            }
            set
            {
                if (Index == 2)
                    MinecartData.L2Screens = value;
            }
        }
        public Label RailColorKey
        {
            get { return railColorKey; }
            set { railColorKey = value; }
        }

        // Mouse behavior
        private int diffX, diffY;
        private int mouseOverObject = -1;
        private int mouseDownObject = -1;

        // Windows messages
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        #endregion

        // Constructor
        public ScreensForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();

            //
            this.objectsForm.ToggleButton = toggleObjects;
        }

        #region Methods

        public void LoadScreens()
        {
            // if mode7 map
            if (Index < 2)
            {
                // Screen properties
                screensPanel.Hide();
            }
            // if side-scrolling map
            else
            {
                BGTileset = new Tileset(Model.SSBGTileset, Model.SSGraphics, paletteSet, 32, 16, TilesetType.SideScrolling);

                // Screen properties
                if (Index == 2)
                    screenWidth.Value = MinecartData.WidthA;
                else
                    screenWidth.Value = MinecartData.WidthB;
                screensPanel.Show();
                InitializeScreens();
            }

            // Rails properties
            railColorKey.Visible = state.Rails && Index < 2;
        }
        private void InitializeScreens()
        {
            this.Updating = true;

            //
            picture.Width = L1Indexes.Count * 256;
            screensPanel.AutoScrollPosition = new Point(0, 0);
            if (L1Indexes.Count > 0)
            {
                screenIndex = 0;
                this.screenL1Number.Value = L1Indexes[screenIndex];
                if (Index == 2)
                    this.screenL2Number.Value = L2Indexes[screenIndex];
                this.screenL2Number.Enabled = Index == 2;
            }

            //
            this.Updating = false;
            SetScreenImages();
        }
        private void RefreshScreen()
        {
            this.Updating = true;
            if (L1Indexes != null && L1Indexes.Count != 0)
            {
                this.screenL1Number.Enabled = true;
                this.screenL1Number.Value = L1Indexes[screenIndex];
            }
            else
            {
                screenL1Number.Enabled = false;
                screenL1Number.Value = 0;
            }
            if (Index == 2)
            {
                this.screenL2Number.Enabled = true;
                this.screenL2Number.Value = L2Indexes[screenIndex];
            }
            else
            {
                screenL2Number.Enabled = false;
                screenL2Number.Value = 0;
            }
            this.Updating = false;
        }
        public void SetScreenImage()
        {
            if (MinecartData == null)
                return;
            if (screenIndex >= L1Indexes.Count)
                return;
            if (L1Indexes[screenIndex] < 16)
            {
                byte[] tilemapL1 = Bits.GetBytes(Model.SSTilemap, L1Indexes[screenIndex] * 256, 256);
                byte[] tilemapL2;
                if (Index == 2)
                    tilemapL2 = Bits.GetBytes(Model.SSTilemap, L2Indexes[screenIndex] * 256, 256);
                else
                    tilemapL2 = new byte[256];
                SideTilemap tilemap = new SideTilemap(tilemapL1, tilemapL2, Tileset, paletteSet);
                screenImages[screenIndex] = Do.PixelsToImage(tilemap.Pixels, 256, 256);
            }
            else
            {
                screenImages[screenIndex] = new Bitmap(256, 256);
            }
            picture.Invalidate();
        }
        public void SetScreenImages()
        {
            if (MinecartData == null)
                return;
            screenImages = new List<Bitmap>();
            for (int i = 0; i < L1Indexes.Count; i++)
            {
                if (L1Indexes[i] < 16)
                {
                    byte[] tilemapL1 = Bits.GetBytes(Model.SSTilemap, L1Indexes[i] * 256, 256);
                    byte[] tilemapL2;
                    if (Index == 2)
                        tilemapL2 = Bits.GetBytes(Model.SSTilemap, L2Indexes[i] * 256, 256);
                    else
                        tilemapL2 = new byte[256];
                    SideTilemap tilemap = new SideTilemap(tilemapL1, tilemapL2, Tileset, paletteSet);
                    Bitmap screenImage = Do.PixelsToImage(tilemap.Pixels, 256, 256);
                    screenImages.Add(new Bitmap(screenImage));
                }
                else
                {
                    screenImages.Add(new Bitmap(256, 256));
                }
            }
            picture.Invalidate();
        }

        #endregion

        #region Event Handlers

        // Toggle
        private void toggleObjects_Click(object sender, EventArgs e)
        {
            objectsForm.Top = this.Top;
            objectsForm.Left = this.Right;
            objectsForm.Visible = toggleObjects.Checked;
            picture.Invalidate();
        }

        // Picture
        private void pictureBoxScreens_Paint(object sender, PaintEventArgs e)
        {
            if (L1Indexes.Count == 0)
                return;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            Rectangle dst;
            Rectangle src;
            // Draw screens
            for (int i = 0; i < L1Indexes.Count; i++)
            {
                dst = new Rectangle(i * 256, 0, 256, 256);
                if (L1Indexes[i] < L1Indexes.Count)
                {
                    src = new Rectangle(0, 0, 256, 256);
                    if (screenIndex < screenImages.Count)
                    {
                        if (Index == 3 && i % 2 == 0)
                        {
                            if (ScreenBGImage == null)
                            {
                                int[] BGPixels = Do.TilesetToPixels(BGTileset.Tileset_tiles, 32, 16, 0, false);
                                ScreenBGImage = Do.PixelsToImage(BGPixels, 512, 256);
                            }
                            dst.Width = 512;
                            src.Width = 512;
                            e.Graphics.DrawImage(ScreenBGImage, dst, src, GraphicsUnit.Pixel);
                            dst.Width = 256;
                            src.Width = 256;
                        }
                        e.Graphics.DrawImage(screenImages[i], dst, src, GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    Font font = new Font("Tahoma", 10F, FontStyle.Bold);
                    SizeF size = e.Graphics.MeasureString("(INVALID SCREEN INDEX)", font, new PointF(0, 0), StringFormat.GenericDefault);
                    Point point = new Point(((256 - (int)size.Width) / 2) + (i * 256), (256 - (int)size.Height) / 2);
                    Do.DrawString(e.Graphics, point, "(INVALID SCREEN INDEX)", Color.Black, Color.Red, font);
                }
                if (this.screenIndex == i)
                {
                    Pen pen = new Pen(new SolidBrush(Color.Gray), 2);
                    pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawRectangle(pen, new Rectangle(i * 256, 0, 256 - 1, 256 - 1));
                }
            }
            // Draw objects
            for (int i = 0; toggleObjects.Checked && i < MinecartObjects.Count; i++)
            {
                MinecartObject obj = MinecartObjects[i];
                Pen pen;
                if (objectIndex == i)
                    pen = new Pen(Color.Red, 2);
                else
                    pen = new Pen(Color.Red, 1);
                e.Graphics.DrawRectangle(pen, new Rectangle(obj.X - 1, obj.Y - 1, obj.Count * 32 - 16 + 2, 16 + 2));
                Bitmap image = obj.Type == 1 ? MinecartData.Coin : MinecartData.Mushroom;
                for (int x = 0; x < obj.Count; x++)
                    e.Graphics.DrawImage(image, x * 32 + obj.X, obj.Y, 16, 16);
            }
        }
        private void pictureBoxScreens_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - diffX; int y = e.Y - diffY;
            if (x > picture.Width - 1) x = picture.Width - 1;
            if (x < 0) x = 0;
            if (y > picture.Height - 1) y = picture.Height - 1;
            if (y < 0) y = 0;
            //
            if (mouseDownObject >= 0 && e.Button == MouseButtons.Left)
            {
                objectsForm.X.Value = Math.Max(256, x);
                objectsForm.Y.Value = y;
            }
            else if (toggleObjects.Checked)
            {
                for (int i = 0; i < MinecartObjects.Count; i++)
                {
                    MinecartObject mco = MinecartObjects[i];
                    if (x >= mco.X && x < mco.X + mco.Width &&
                        y >= mco.Y && y < mco.Y + 16)
                    {
                        picture.Cursor = Cursors.Hand;
                        mouseOverObject = i;
                        break;
                    }
                    else
                    {
                        picture.Cursor = Cursors.Arrow;
                        mouseOverObject = -1;
                    }
                }
            }
        }
        private void pictureBoxScreens_MouseDown(object sender, MouseEventArgs e)
        {
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            //
            int x = e.X;
            int y = e.Y;
            if (toggleObjects.Checked && mouseOverObject >= 0 && e.Button == MouseButtons.Left)
            {
                mouseDownObject = mouseOverObject;
                objectIndex = mouseDownObject;
                diffX = (int)(x - MinecartObject.X);
                diffY = (int)(y - MinecartObject.Y);
            }
            //
            screenIndex = e.X / 256;
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX, autoScrollPosY);
            picture.Invalidate();
        }
        private void pictureBoxScreens_MouseUp(object sender, MouseEventArgs e)
        {
            diffX = 0;
            diffY = 0;
        }
        private void pictureBoxScreens_MouseEnter(object sender, EventArgs e)
        {
            //if (GetForegroundWindow() == MiniGames.Handle)
            //    pictureBoxScreens.Focus();
            //pictureBoxScreens.Invalidate();
        }
        private void pictureBoxScreens_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Down)
                screenIndex++;
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Up)
                screenIndex--;
        }
        private void screens_Scroll(object sender, ScrollEventArgs e)
        {
            picture.Invalidate();
            screensPanel.Invalidate();
        }

        // Screen properties
        private void screenWidth_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (Index == 2)
                MinecartData.WidthA = (int)screenWidth.Value;
            else
                MinecartData.WidthB = (int)screenWidth.Value;
        }
        private void screenL1Number_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            L1Indexes[screenIndex] = (int)screenL1Number.Value;
            SetScreenImage();
        }
        private void screenL2Number_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            L2Indexes[screenIndex] = (int)screenL2Number.Value;
            SetScreenImage();
        }
        private void newScreen_Click(object sender, EventArgs e)
        {
            if (L1Indexes.Count >= 255)
            {
                MessageBox.Show("Cannot have more than 255 screens.");
                return;
            }
            L1Indexes.Insert(screenIndex, 0);
            if (Index == 2)
                L2Indexes.Insert(screenIndex, 0);
            screenImages.Insert(screenIndex, new Bitmap(256, 256));
            screenIndex++;
            //
            picture.Width = L1Indexes.Count * 256;
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX + 256, autoScrollPosY);
            //
            SetScreenImage();
        }
        private void deleteScreen_Click(object sender, EventArgs e)
        {
            if (L1Indexes.Count == 0)
                return;
            int index = screenIndex;
            L1Indexes.RemoveAt(screenIndex);
            if (Index == 2)
                L2Indexes.RemoveAt(screenIndex);
            screenImages.RemoveAt(screenIndex);
            if (index >= L1Indexes.Count)
                screenIndex--;
            //
            picture.Width = L1Indexes.Count * 256;
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX - 256, autoScrollPosY);
        }
        private void duplicateScreen_Click(object sender, EventArgs e)
        {
            if (L1Indexes.Count >= 255)
            {
                MessageBox.Show("Cannot have more than 255 screens.");
                return;
            }
            L1Indexes.Insert(screenIndex, L1Indexes[screenIndex]);
            if (Index == 2)
                L2Indexes.Insert(screenIndex, L2Indexes[screenIndex]);
            screenImages.Insert(screenIndex, screenImages[screenIndex]);
            screenIndex++;
            //
            picture.Width = L1Indexes.Count * 256;
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX + 256, autoScrollPosY);
            //
            SetScreenImage();
        }
        private void moveScreenBack_Click(object sender, EventArgs e)
        {
            if (screenIndex <= 0)
                return;
            L1Indexes.Reverse(screenIndex - 1, 2);
            if (Index == 2)
                L2Indexes.Reverse(screenIndex - 1, 2);
            screenImages.Reverse(screenIndex - 1, 2);
            screenIndex--;
            //
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX - 256, autoScrollPosY);
            //
            picture.Invalidate();
        }
        private void moveScreenFoward_Click(object sender, EventArgs e)
        {
            if (screenIndex >= L1Indexes.Count - 1)
                return;
            L1Indexes.Reverse(screenIndex, 2);
            if (Index == 2)
                L2Indexes.Reverse(screenIndex, 2);
            screenImages.Reverse(screenIndex, 2);
            screenIndex++;
            //
            int autoScrollPosX = Math.Abs(screensPanel.AutoScrollPosition.X);
            int autoScrollPosY = Math.Abs(screensPanel.AutoScrollPosition.Y);
            screensPanel.AutoScrollPosition = new Point(autoScrollPosX + 256, autoScrollPosY);
            //
            picture.Invalidate();
        }

        #endregion
    }
}
