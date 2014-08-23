using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.Undo;

namespace LAZYSHELL.Formations
{
    public partial class FormationsForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private PacksForm packsForm
        {
            get { return ownerForm.PacksForm; }
            set { ownerForm.PacksForm = value; }
        }
        public Search searchWindow;
        private EditLabel labelWindow;

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        private int selectedMonster
        {
            get { return listBox1.SelectedIndex; }
            set { listBox1.SelectedIndex = value; }
        }

        // Elements
        private Battlefields.Battlefield[] battlefields
        {
            get { return Battlefields.Model.Battlefields; }
        }
        private PaletteSet[] paletteSets
        {
            get { return Battlefields.Model.PaletteSets; }
        }
        private Formation[] formations
        {
            get { return Model.Formations; }
            set { Model.Formations = value; }
        }
        private Formation formation
        {
            get { return formations[Index]; }
            set { formations[Index] = value; }
        }
        public Formation Formation
        {
            get { return formation; }
            set { formation = value; }
        }
        private SortedList monsterNames
        {
            get { return Monsters.Model.Names; }
            set { Monsters.Model.Names = value; }
        }
        private Fonts.Glyph[] fontMenu
        {
            get { return Fonts.Model.Menu; }
        }
        private int[] palette
        {
            get { return Fonts.Model.Palette_Battle.Palette; }
        }
        private Monsters.Monster[] monsters
        {
            get { return Monsters.Model.Monsters; }
        }

        // Picture
        public PictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private List<Bitmap> monsterImages;
        private List<Bitmap> shadowImages;
        private Bitmap[] allyImages;
        private Bitmap[] statImages;
        private Bitmap[] portraits;

        // Selection
        private bool move = false;
        private List<SelectedObject> selectedObjects;
        private Overlay overlay;
        private Bitmap bgImage;

        // Mouse behavior
        private bool waitBothCoords = false;
        private int mouseOverMonster = -1;
        private int mouseDownMonster = -1;
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool mouseWithinSameBounds = false;
        private int diffX, diffY;

        // Miscellaneous
        private UndoStack commandStack;
        private byte[] originalX;
        private byte[] originalY;

        #endregion

        // Constructor
        public FormationsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            CreateHelperForms();
            SetBattlefieldImage();
            LoadProperties();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            mouseDownPosition = new Point(-1, -1);
            monsterImages = new List<Bitmap>();
            shadowImages = new List<Bitmap>();
            commandStack = new UndoStack();
        }
        private void InitializeListControls()
        {
            this.Updating = true;

            // Reload monster names
            Monsters.Model.Names = new SortedList(monsters);
            Monsters.Model.Names.SortAlphabetically();

            // Formations
            this.name.Items.Clear();
            this.name.Items.AddRange(Lists.Numerize(formations));
            this.name.SelectedIndex = Index;
            this.name.SelectedIndex = 0;

            // Battlefield
            this.battlefieldName.Items.AddRange(Lists.Battlefields);
            this.battlefieldName.SelectedIndex = 7;

            // Monster
            this.monsterName.Items.AddRange(monsterNames.Names);
            this.monsterName.DropDownHeight = this.monsterName.ItemHeight * 20 + 2;

            // Miscellaneous
            this.startEvent.Items.AddRange(Lists.Numerize(Lists.BattleEvents));
            this.musicTrack.Items.AddRange(Lists.SPCTracks);

            // Finished
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(num, search, name.Items);
            labelWindow = new EditLabel(name, num, "Formations", false);
        }
        public void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Updating = true;

            // Build listBox
            BuildMonsterListBox();

            // Load properties
            this.musicTheme.SelectedIndex = formation.MusicTheme;
            this.startEvent.SelectedIndex = formation.StartEvent;
            this.unknown.Value = formation.Unknown;
            this.cantRun.Checked = formation.CantRun;
            this.musicTrack.Enabled = musicTheme.SelectedIndex != 8;
            if (musicTheme.SelectedIndex != 8)
                this.musicTrack.SelectedIndex = Model.Musics[musicTheme.SelectedIndex];
            else
                this.musicTrack.SelectedIndex = 0;

            // Load monster properties
            LoadMonsterProperties();

            // Set image
            SetMonsterImages();

            // Finished
            this.Updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void LoadMonsterProperties()
        {
            this.Updating = true;
            //
            monsterName.SelectedIndex = monsterNames.GetSortedIndex(formation.Monsters[selectedMonster]);
            x.Value = formation.X[selectedMonster];
            y.Value = formation.Y[selectedMonster];
            hide.Checked = formation.Hide[selectedMonster];
            active.Checked = formation.Active[selectedMonster];
            //
            this.Updating = false;
        }
        private void BuildMonsterListBox()
        {
            this.listBox1.Items.Clear();
            for (int i = 0; i < 8; i++)
            {
                if (formation.Active[i])
                    this.listBox1.Items.Add(monsterNames.GetUnsortedName(formation.Monsters[i]));
                else
                    this.listBox1.Items.Add("—");
            }
            this.listBox1.SelectedIndex = 0;
        }

        #endregion

        #region Pictures

        /// <summary>
        /// Draws the monster images to the pictureBox.
        /// </summary>
        /// <param name="g">The drawing surface of the pictureBox.</param>
        private void DrawFormation(Graphics g)
        {
            byte[] items = new byte[8];
            for (byte i = 0; i < 8; i++)
                items[i] = i;
            byte[] keys = Bits.Copy(formation.Y);
            Array.Sort(keys, items);
            for (int a = 0; a < 8; a++)
            {
                int i = items[a];
                if (!formation.Active[i]) continue;
                int elevation = monsters[formation.Monsters[i]].Elevation * 16;
                int x = formation.X[i] - 8;
                int y = formation.Y[i] + 14;
                if (elevation > 0)
                    g.DrawImage(shadowImages[i], x, y);
                //
                x = formation.X[i] - 128;
                y = formation.Y[i] - 96 - elevation - 1;
                g.DrawImage(monsterImages[i], x, y);
            }
            if (toggleAllies.Checked)
            {
                if (allyImages == null || portraits == null)
                    SetAllyImages();
                g.DrawImage(allyImages[0], Model.ROM[0x0296BD] - 128, Model.ROM[0x0296BE] - 96 - 1);
                g.DrawImage(allyImages[2], Model.ROM[0x0296BF] - 128, Model.ROM[0x0296C0] - 96 - 1);
                g.DrawImage(allyImages[3], Model.ROM[0x0296C1] - 128, Model.ROM[0x0296C2] - 96 - 1);
                // draw HPs
                g.DrawImage(statImages[0], 24, 94);
                g.DrawImage(statImages[2], 48, 70);
                g.DrawImage(statImages[3], 72, 46);
                // draw portraits
                g.DrawImage(portraits[0], 20 - 128, 82 - 96 - 1);
                g.DrawImage(portraits[2], 44 - 128, 58 - 96 - 1);
                g.DrawImage(portraits[3], 68 - 128, 34 - 96 - 1);
            }
        }
        public void SetMonsterImages()
        {
            // Create images
            monsterImages = new List<Bitmap>();
            shadowImages = new List<Bitmap>();
            for (int i = 0; i < 8; i++)
            {
                int[] pixels = Monsters.Model.Monsters[formation.Monsters[i]].Pixels;
                monsterImages.Add(Do.PixelsToImage(pixels, 256, 256));
                pixels = Monsters.Model.Monsters[formation.Monsters[i]].Shadow;
                shadowImages.Add(Do.PixelsToImage(pixels, 16, 16));
            }
            formation.PixelIndexes = null;

            // Set pack images
            if (packsForm != null)
            {
                // Only set images in packs form if current pack contains this formation
                if (packsForm.Pack.Formations[0] == this.Index ||
                    packsForm.Pack.Formations[1] == this.Index ||
                    packsForm.Pack.Formations[2] == this.Index)
                    packsForm.LoadProperties();
            }

            // Finished
            picture.Invalidate();
        }
        private void SetBattlefieldImage()
        {
            var paletteSet = paletteSets[battlefields[battlefieldName.SelectedIndex].PaletteSet];
            var tileSet = new Battlefields.Tileset(battlefields[battlefieldName.SelectedIndex], paletteSet);
            int[] quadrant1 = Do.TilesetToPixels(tileSet.Tileset_tiles, 16, 16, 0, false);
            int[] quadrant2 = Do.TilesetToPixels(tileSet.Tileset_tiles, 16, 16, 256, false);
            int[] quadrant3 = Do.TilesetToPixels(tileSet.Tileset_tiles, 16, 16, 512, false);
            int[] quadrant4 = Do.TilesetToPixels(tileSet.Tileset_tiles, 16, 16, 768, false);
            int[] pixels = new int[512 * 512];
            Do.PixelsToPixels(quadrant1, pixels, 512, new Rectangle(0, 0, 256, 256));
            Do.PixelsToPixels(quadrant2, pixels, 512, new Rectangle(256, 0, 256, 256));
            Do.PixelsToPixels(quadrant3, pixels, 512, new Rectangle(0, 256, 256, 256));
            Do.PixelsToPixels(quadrant4, pixels, 512, new Rectangle(256, 256, 256, 256));
            bgImage = Do.PixelsToImage(pixels, 512, 512);
            picture.Invalidate();
        }
        private void SetAllyImages()
        {
            allyImages = new Bitmap[5];
            statImages = new Bitmap[5];
            portraits = new Bitmap[5];
            for (int i = 0; i < allyImages.Length; i++)
            {
                Size size = new Size(0, 0);
                var sprite = Sprites.Model.Sprites[Areas.Model.NPCProperties[i].Sprite];
                int[] pixels = sprite.GetPixels(false, true, 0, 7, false, false, ref size);
                allyImages[i] = Do.PixelsToImage(pixels, size.Width, size.Height);
                //
                pixels = new int[128 * 24];
                int[] palette = Fonts.Model.Palette_BattleMenu.Palette;
                char[] HP = new char[] { '2', '0', '9' }; // Mario
                if (i == 1) HP = new char[] { '2', '1', '1' }; // Toadstool
                if (i == 2) HP = new char[] { '2', '4', '0' }; // Bowser
                if (i == 3) HP = new char[] { '1', '9', '5' }; // Mallow
                if (i == 4) HP = new char[] { '2', '0', '3' }; // Geno
                char[] text = new char[]
                {
                    '\x01','\x01','\x01','\x01','\x01','\x01','\x01','\x01','\x02','\n' ,
                    '\x00',HP[0],HP[1],HP[2],'\x16',HP[0],HP[1],HP[2],'\x10','\n',
                    '\x11','\x11','\x11','\x11','\x11','\x11','\x11','\x11','\x12'
                };
                Do.DrawText(pixels, 128, text, 0, 0, 8, Fonts.Model.BattleMenu, palette);
                statImages[i] = Do.PixelsToImage(pixels, 128, 24);
                //
                palette = Sprites.Model.Sprites[Areas.Model.NPCProperties[i].Sprite].Palette;
                pixels = Sprites.Model.Sprites[i + 40].GetPixels(true, false, 0, 0, palette, true, false, ref size);
                portraits[i] = Do.PixelsToImage(pixels, 256, 256);
            }
        }

        #endregion

        /// <summary>
        /// Switches the slots of two monsters in the formation.
        /// </summary>
        /// <param name="index1">The first slot's index.</param>
        /// <param name="index2">The second slot's index.</param>
        private void SwitchMonster(int index1, int index2)
        {
            this.Updating = true;
            //
            byte x = formation.X[index1];
            byte y = formation.Y[index1];
            byte monster = formation.Monsters[index1];
            bool active = formation.Active[index1];
            bool hide = formation.Hide[index1];
            //
            formation.X[index1] = formation.X[index2];
            formation.Y[index1] = formation.Y[index2];
            formation.Monsters[index1] = formation.Monsters[index2];
            formation.Active[index1] = formation.Active[index2];
            formation.Hide[index1] = formation.Hide[index2];
            //
            formation.X[index2] = x;
            formation.Y[index2] = y;
            formation.Monsters[index2] = monster;
            formation.Active[index2] = active;
            formation.Hide[index2] = hide;
            //
            int selectedMonster = this.selectedMonster;
            var selectedMonsterA = listBox1.Items[index1];
            listBox1.Items[index1] = listBox1.Items[index2];
            listBox1.Items[index2] = selectedMonsterA;
            listBox1.SelectedIndex = selectedMonster;
            this.name.Items[Index] = Lists.Numerize(formation.ToString(), Index, 3);
            //
            this.Updating = false;
        }

        // Object moving
        private void Drag()
        {
            if (overlay.Select.Empty)
                return;
            selectedObjects = new List<SelectedObject>();
            for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    if (y < 0 || y >= 256 ||
                        x < 0 || x >= 256)
                        continue;
                    int index = this.formation.PixelIndexes[y * 256 + x];
                    var result = selectedObjects.Find(param => param.Index == index);
                    // only if empty pixel and object not already in list
                    if (index != -1 && result == null)
                        selectedObjects.Add(new SelectedObject(index,
                            (int)formation.X[index] - mousePosition.X,
                            (int)formation.Y[index] - mousePosition.Y));
                }
            }
        }
        private void Undo()
        {
            this.Updating = true;
            commandStack.UndoCommand();
            this.Updating = false;
            LoadMonsterProperties();
            overlay.Select.Clear();
            selectedObjects = null;
            formation.PixelIndexes = null;
            picture.Invalidate();
            Cursor.Position = Cursor.Position;
        }
        private void Redo()
        {
            this.Updating = true;
            commandStack.RedoCommand();
            this.Updating = false;
            LoadMonsterProperties();
            overlay.Select.Clear();
            selectedObjects = null;
            formation.PixelIndexes = null;
            picture.Invalidate();
            Cursor.Position = Cursor.Position;
        }

        #endregion

        #region Event Handlers

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            LoadProperties();
            Settings.Default.LastFormation = Index;
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.num.Value = this.name.SelectedIndex;
        }

        // Formation properties
        private void musicTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            formation.MusicTheme = (byte)musicTheme.SelectedIndex;
            this.Updating = true;
            this.musicTrack.Enabled = musicTheme.SelectedIndex != 8;
            if (musicTheme.SelectedIndex != 8)
                this.musicTrack.SelectedIndex = Model.Musics[musicTheme.SelectedIndex];
            else
                this.musicTrack.SelectedIndex = 0;
            this.Updating = false;
        }
        private void unknown_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            formation.Unknown = (byte)unknown.Value;
        }
        private void cantRun_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            formation.CantRun = cantRun.Checked;
        }
        private void startEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            formation.StartEvent = (byte)startEvent.SelectedIndex;
        }
        private void musicTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Model.Musics[musicTheme.SelectedIndex] = (byte)musicTrack.SelectedIndex;
        }

        // ToolStrip
        private void saveImage_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(256, 256);
            var graphics = Graphics.FromImage(image);
            DrawFormation(graphics);
            Do.Export(image, "formation-" + Index + ".png");
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void battlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            SetBattlefieldImage();
        }
        private void toggleAllies_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void isometricGrid_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void select_Click(object sender, EventArgs e)
        {
            picture.Cursor = select.Checked ? Cursors.Cross : Cursors.Arrow;
            picture.Invalidate();
        }
        private void undo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        // Picture
        private void picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownMonster = -1;
            mouseDownPosition = new Point(-1, -1);
            mouseDownObject = null;
            //
            int x = e.X; int y = e.Y;
            #region Selecting
            if (select.Checked)
            {
                // if we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != "selection")
                {
                    selectedObjects = null;
                    overlay.Select.Reload(1, x, y, 1, 1, picture);
                }
                // otherwise, start dragging current selection
                else if (mouseOverObject == "selection")
                {
                    mouseDownObject = "selection";
                    mouseDownPosition = overlay.Select.MousePosition(x, y);
                    originalX = new byte[8];
                    originalY = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        originalX[i] = formation.X[i];
                        originalY[i] = formation.Y[i];
                    }
                    if (!move)    // only do this if the current selection has not been initially moved
                    {
                        move = true;
                        Drag();
                    }
                }
                return;
            }
            #endregion
            // dragging
            if (e.Button == MouseButtons.Left)
            {
                if (mouseOverMonster < 0 || mouseOverMonster > 7)
                    return;
                move = true;
                mouseDownMonster = mouseOverMonster;
                selectedMonster = mouseDownMonster; // select the monster in the listBox
                diffX = (int)(x - this.x.Value);
                diffY = (int)(y - this.y.Value);
                originalX = new byte[8];
                originalY = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    originalX[i] = formation.X[i];
                    originalY[i] = formation.Y[i];
                }
            }
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            int x = Math.Min(255, Math.Max(0, e.X));
            int y = Math.Min(255, Math.Max(0, e.Y));
            labelCoords.Text = "(x: " + x + ", y: " + y + ")";
            //
            mouseWithinSameBounds = mousePosition == new Point(x, y);
            mousePosition = new Point(x, y);
            mouseOverMonster = -1;
            mouseOverObject = null;
            picture.Focus();
            //
            #region Selecting
            if (select.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x, y))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Min(x, 256),
                        Math.Min(y, 256));
                }
                // if dragging the current selection
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection" && !mouseWithinSameBounds)
                {
                    overlay.Select.Location = new Point(
                        x - mouseDownPosition.X,
                        y - mouseDownPosition.Y);
                    foreach (var selectedObject in selectedObjects)
                    {
                        int index = selectedObject.Index;
                        if (index == selectedMonster)
                        {
                            this.x.Value = (byte)(x + selectedObject.DiffX);
                            this.y.Value = (byte)(y + selectedObject.DiffY);
                        }
                        else
                        {
                            formation.X[index] = (byte)(x + selectedObject.DiffX);
                            formation.Y[index] = (byte)(y + selectedObject.DiffY);
                        }
                    }
                    picture.Invalidate();
                    return;
                }
                // if mouse not clicked and within the current selection
                else if (e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    picture.Cursor = Cursors.SizeAll;
                }
                else
                    picture.Cursor = Cursors.Cross;
                picture.Invalidate();
                return;
            }
            #endregion
            #region Dragging
            if (e.Button == MouseButtons.Left)
            {
                x = e.X - diffX;
                y = e.Y - diffY;
                x = Math.Min(255, Math.Max(0, x));
                y = Math.Min(255, Math.Max(0, y));
                if (snapIsometricLeft.Checked && snapIsometricRight.Checked)
                {
                    x = x / 16 * 16;
                    if ((x / 2) - y < 0)
                    {
                        if (Math.Abs((x / 2) - y) % 16 >= 8)
                            y += 16 - (Math.Abs((x / 2) - y) % 16);
                        else
                            y -= Math.Abs((x / 2) - y) % 16;
                    }
                    else
                    {
                        if (Math.Abs((x / 2) - y) % 16 >= 8)
                            y -= 16 - (Math.Abs((x / 2) - y) % 16);
                        else
                            y += Math.Abs((x / 2) - y) % 16;
                    }
                }
                else if (snapIsometricLeft.Checked)
                {
                    x = x / 2 * 2;
                    if ((x / 2) - y < 0)
                    {
                        if (Math.Abs((x / 2) - y) % 16 >= 8)
                            y += 16 - (Math.Abs((x / 2) - y) % 16);
                        else
                            y -= Math.Abs((x / 2) - y) % 16;
                    }
                    else
                    {
                        if (Math.Abs((x / 2) - y) % 16 >= 8)
                            y -= 16 - (Math.Abs((x / 2) - y) % 16);
                        else
                            y += Math.Abs((x / 2) - y) % 16;
                    }
                }
                else if (snapIsometricRight.Checked)
                {
                    x = x / 2 * 2;
                    if (((1024 - x) / 2) - y < 0)
                    {
                        if (Math.Abs(((1024 - x) / 2) - y) % 16 >= 8)
                            y += 16 - (Math.Abs(((1024 - x) / 2) - y) % 16);
                        else
                            y -= Math.Abs(((1024 - x) / 2) - y) % 16;
                    }
                    else
                    {
                        if (Math.Abs(((1024 - x) / 2) - y) % 16 >= 8)
                            y -= 16 - (Math.Abs(((1024 - x) / 2) - y) % 16);
                        else
                            y += Math.Abs(((1024 - x) / 2) - y) % 16;
                    }
                }
                x = Math.Min(255, Math.Max(0, x));
                y = Math.Min(255, Math.Max(0, y));
                //
                if (mouseDownMonster >= 0 && mouseDownMonster <= 7)
                {
                    if (this.x.Value != x &&
                        this.y.Value != y)
                        waitBothCoords = true;
                    this.x.Value = x;
                    waitBothCoords = false;
                    this.y.Value = y;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (e.X > 0 && e.X < 256 && e.Y > 0 && e.Y < 256 &&
                        this.formation.PixelIndexes[e.Y * 256 + e.X] == i)
                    {
                        picture.Cursor = Cursors.Hand;
                        mouseOverMonster = i;
                        break;
                    }
                    else
                    {
                        picture.Cursor = Cursors.Arrow;
                        mouseOverMonster = -1;
                    }
                }
            }
            #endregion
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            mouseDownPosition = new Point(-1, -1);
            mouseDownObject = null;
            formation.PixelIndexes = null;
            //
            if (originalX != null && originalY != null)
                commandStack.Push(new MoveEdit(formation, originalX, originalY));
            originalX = null;
            originalY = null;
            //
            picture.Invalidate();
        }
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (toggleBG.Checked && bgImage != null)
                e.Graphics.DrawImage(bgImage, -8, 26);
            if (isometricGrid.Checked)
                new Overlay().DrawIsometricGrid(e.Graphics, Color.Gray, picture.Size, new Size(16, 16), 1);
            DrawFormation(e.Graphics);
            if (select.Checked && overlay.Select != null)
                overlay.Select.DrawSelectionBox(e.Graphics, 1);
        }
        private void picture_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.G: isometricGrid.PerformClick(); break;
                case Keys.S: select.PerformClick(); break;
                case Keys.Control | Keys.Z: undo.PerformClick(); break;
                case Keys.Control | Keys.Y: redo.PerformClick(); break;
            }
        }

        // Monsters
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            LoadMonsterProperties();
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, new MenuTextPreview(), formation.GetMonsterNames(""), fontMenu, palette, true, Menus.Model.MenuBG_256x255);
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (selectedMonster < 0)
            {
                MessageBox.Show("Must select a monster property before moving.");
                return;
            }
            if (selectedMonster == 0)
                return;
            SwitchMonster(selectedMonster, selectedMonster - 1);
            selectedMonster--;
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (selectedMonster < 0)
            {
                MessageBox.Show("Must select a monster property before moving.");
                return;
            }
            if (selectedMonster == 7)
                return;
            SwitchMonster(selectedMonster, selectedMonster + 1);
            selectedMonster++;
        }
        private void active_CheckedChanged(object sender, EventArgs e)
        {
            this.active.Image = active.Checked ? Resources.apply : Resources.inactive;
            this.x.Enabled = active.Checked;
            this.y.Enabled = active.Checked;
            this.monsterName.Enabled = active.Checked;
            this.monsterNum.Enabled = active.Checked;
            //
            if (this.Updating)
                return;
            this.formation.Active[selectedMonster] = active.Checked;
            this.name.Items[Index] = Lists.Numerize(formation.ToString(), Index, 3);
            listBox1.Invalidate();
            picture.Invalidate();
        }
        private void hide_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.formation.Hide[selectedMonster] = hide.Checked;
            picture.Invalidate();
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (monsterName.Enabled)
                Do.DrawName(sender, e, new MenuTextPreview(), monsterNames, fontMenu, palette, true, Menus.Model.MenuBG_256x255);
        }
        private void monsterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            monsterNum.Value = monsterNames.GetUnsortedIndex(monsterName.SelectedIndex);
        }
        private void monsterNum_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.Updating = true;
            int selectedMonster = this.selectedMonster;
            formation.Monsters[selectedMonster] = (byte)monsterNum.Value;
            monsterName.SelectedIndex = monsterNames.GetSortedIndex(formation.Monsters[selectedMonster]);
            this.name.Items[Index] = Lists.Numerize(formation.ToString(), Index, 3);
            this.listBox1.Items[selectedMonster] = monsterNames.Names[monsterName.SelectedIndex];
            this.listBox1.SelectedIndex = selectedMonster;
            SetMonsterImages();
            this.Updating = false;
        }
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            //
            if (!move)
            {
                byte[] X = Bits.Copy(formation.X);
                X[selectedMonster] = (byte)x.Value;
                commandStack.Push(new MoveEdit(formation, X, Bits.Copy(formation.Y)));
            }
            this.formation.X[selectedMonster] = (byte)x.Value;
            //
            if (waitBothCoords)
                return;
            if (!move)
                formation.PixelIndexes = null;
            picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            //
            if (!move)
            {
                byte[] Y = Bits.Copy(formation.Y);
                Y[selectedMonster] = (byte)y.Value;
                commandStack.Push(new MoveEdit(formation, Bits.Copy(formation.X), Y));
            }
            this.formation.Y[selectedMonster] = (byte)y.Value;
            //
            if (waitBothCoords)
                return;
            if (!move)
                formation.PixelIndexes = null;
            picture.Invalidate();
        }

        #endregion

        /// <summary>
        /// Contains the information of a selected object in the formation image.
        /// </summary>
        private class SelectedObject
        {
            #region Variables

            /// <summary>
            ///  The X difference from where mouse was clicked
            /// </summary>
            public int DiffX;
            /// <summary>
            ///  The Y difference from where mouse was clicked
            /// </summary>
            public int DiffY;
            /// <summary>
            ///  The index of the selected object
            /// </summary>
            public int Index;

            #endregion

            // Constructor
            public SelectedObject(int index, int diffX, int diffY)
            {
                this.Index = index;
                this.DiffX = diffX;
                this.DiffY = diffY;
            }
        }

        /// <summary>
        /// Contains the data and information of a move edit when 
        /// a monster has been moved in the formation image.
        /// </summary>
        public class MoveEdit : Undo.Edit
        {
            #region Variables

            private Formation formation;
            private byte[] x = new byte[8];
            private byte[] y = new byte[8];
            public bool AutoRedo { get; set; }

            #endregion

            // Constructor
            public MoveEdit(Formation formation, byte[] x, byte[] y)
            {
                this.formation = formation;
                this.x = x;
                this.y = y;
            }

            // Execute
            public void Execute()
            {
                for (int i = 0; i < 8; i++)
                {
                    byte tempX = formation.X[i];
                    byte tempY = formation.Y[i];
                    formation.X[i] = x[i];
                    formation.Y[i] = y[i];
                    x[i] = tempX;
                    y[i] = tempY;
                }
            }
        }
    }
}
