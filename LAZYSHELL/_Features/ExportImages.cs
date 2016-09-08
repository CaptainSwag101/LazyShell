using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell
{
    public partial class ExportImages : Controls.NewForm
    {
        #region Variables

        private int currentIndex;
        private ElementType element;

        // Elements
        private Sprites.Sprite[] sprites
        {
            get { return Sprites.Model.Sprites; }
        }
        private Sprites.Animation[] animations
        {
            get { return Sprites.Model.Animations; }
        }
        private PaletteSet[] palettes
        {
            get { return Sprites.Model.PaletteSets; }
        }
        private Sprites.ImagePacket[] images
        {
            get { return Sprites.Model.ImagePackets; }
        }
        private byte[] spriteGraphics
        {
            get { return Sprites.Model.Graphics; }
        }
        private Areas.Area[] areas
        {
            get { return Areas.Model.Areas; }
        }
        private Areas.Map[] maps
        {
            get { return Areas.Model.Maps; }
        }
        private PaletteSet[] paletteSets
        {
            get { return Areas.Model.PaletteSets; }
            set { Areas.Model.PaletteSets = value; }
        }
        private Areas.PrioritySet[] prioritySets
        {
            get { return Areas.Model.PrioritySets; }
            set { Areas.Model.PrioritySets = value; }
        }
        
        // Forms
        private ProgressBar progressBar;

        #endregion

        // Constructor
        public ExportImages(int currentIndex, ElementType element)
        {
            this.currentIndex = currentIndex;
            this.element = element;
            //
            InitializeComponent();
            InitializeControls();
        }

        #region Methods

        // Initialization
        private void InitializeControls()
        {
            if (this.element == ElementType.Area)
            {
                this.Text = "EXPORT AREA IMAGES - Lazy Shell";
                this.current.Text = "Export current area image";
                this.range.Text = "Export area images within area index range";
                this.oneImageDefault.Text = "One image per area, default size (all areas will be 1024x1024!)";
                this.oneImageCropped.Text = "One image per area, cropped to mask edges";
                this.fromIndex.Maximum = 509;
                this.toIndex.Maximum = 509;
                this.maximumWidth.Visible = false;
                this.label2.Visible = false;
                this.oneSpriteSheet.Visible = false;
                this.oneAnimatedGIF.Visible = false;
            }
        }

        // Export
        private void Export()
        {
            bool gif = oneAnimatedGIF.Checked;
            bool crop = oneImageCropped.Checked || oneSpriteSheet.Checked;
            bool contact = oneSpriteSheet.Checked;
            int maxwidth = (int)maximumWidth.Value;
            int start;
            int end;
            string fullPath;
            if (current.Checked)
            {
                start = currentIndex;
                end = currentIndex + 1;
                if (element == ElementType.Area || (element == ElementType.Sprite && oneSpriteSheet.Checked))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Image file (*.png)|*.png";
                    if (element == ElementType.Area)
                        saveFileDialog.FileName = "Level #" + start.ToString("d3");
                    else
                        saveFileDialog.FileName = "Sprite #" + start.ToString("d4");
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.Title = "Save Image";
                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    else
                        Settings.Default.LastDirectory = saveFileDialog.FileName;
                    fullPath = saveFileDialog.FileName;
                }
                else
                {
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
                    folderBrowserDialog1.Description = "Select directory to export to";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
                    else
                        return;
                    fullPath = folderBrowserDialog1.SelectedPath + "\\";
                }
            }
            else
            {
                start = (int)fromIndex.Value;
                end = (int)(toIndex.Value + 1);
                // first, open and create directory
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
                folderBrowserDialog1.Description = "Select directory to export to";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
                else
                    return;
                if (element == ElementType.Area)
                    fullPath = folderBrowserDialog1.SelectedPath + "\\" + Model.GetFileNameWithoutPath() + " - Level Images\\";
                else
                    fullPath = folderBrowserDialog1.SelectedPath + "\\" + Model.GetFileNameWithoutPath() + " - Sprite Mold Images\\";
                DirectoryInfo di = new DirectoryInfo(fullPath);
                if (!di.Exists)
                    di.Create();
            }

            // Set the backgroundworker properties
            Export_Worker.DoWork += (s, e) => Export_Worker_DoWork(s, e, fullPath, crop, contact, gif, maxwidth, start, end, current.Checked);
            Export_Worker.ProgressChanged += new ProgressChangedEventHandler(Export_Worker_ProgressChanged);
            Export_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Export_Worker_RunWorkerCompleted);
            if (element == ElementType.Area)
                progressBar = new ProgressBar("EXPORTING AREA IMAGES...", areas.Length, Export_Worker);
            else
                progressBar = new ProgressBar("EXPORTING SPRITE MOLD IMAGES...", sprites.Length, Export_Worker);
            progressBar.Show();
            Export_Worker.RunWorkerAsync();
            this.Enabled = false;
            while (Export_Worker.IsBusy)
                Application.DoEvents();
            this.Enabled = true;
        }
        private void Export_Worker_DoWork(object sender, DoWorkEventArgs e, string fullPath,
            bool crop, bool contact, bool gif, int maxwidth, int start, int end, bool current)
        {
            for (int a = start; a < end; a++)
            {
                if (Export_Worker.CancellationPending)
                    break;
                Sprites.Sprite s = null;
                if (element == ElementType.Area)
                    Export_Worker.ReportProgress(a);
                else
                {
                    s = sprites[a];
                    Export_Worker.ReportProgress(s.Index);
                }
                // if NOT sprite sheet or animated gif (ie. if NOT single image for each element)
                if (!contact && element == ElementType.Sprite)
                {
                    DirectoryInfo di = new DirectoryInfo(fullPath + "Sprite #" + s.Index.ToString("d4"));
                    if (!di.Exists)
                        di.Create();
                }
                int index = 0;
                int x = 0, y = 0;
                if (this.element == ElementType.Area)
                {
                    var map = maps[areas[a].Map];
                    var layering = areas[a].Layering;
                    var paletteSet = paletteSets[maps[areas[a].Map].PaletteSet];
                    var tileset = new Tileset(map, paletteSet);
                    var tilemap = new Areas.AreaTilemap(areas[a], tileset);
                    int[] pixels;
                    Rectangle region;
                    if (crop)
                    {
                        region = new Rectangle(
                                layering.MaskLowX * 16, layering.MaskLowY * 16,
                                (layering.MaskHighX - layering.MaskLowX) * 16 + 16,
                                (layering.MaskHighY - layering.MaskLowY) * 16 + 16);
                        pixels = Do.GetPixelRegion(tilemap.Pixels, region, 1024, 1024);
                    }
                    else
                    {
                        region = new Rectangle(0, 0, 1024, 1024);
                        pixels = tilemap.Pixels;
                    }
                    Bitmap image = Do.PixelsToImage(pixels, region.Width, region.Height);
                    if (!current)
                        image.Save(fullPath + "Level #" + a.ToString("d3") + ".png", ImageFormat.Png);
                    else
                        image.Save(fullPath, ImageFormat.Png);
                    continue;
                }
                // sprites
                if (gif)
                {
                    var animation = animations[s.AnimationPacket];
                    foreach (var m in animation.Molds)
                    {
                        foreach (var t in m.Tiles)
                            t.DrawSubtiles(s.Graphics, s.Palette, m.Gridplane);
                    }
                    foreach (var sequence in animation.Sequences)
                    {
                        List<int> durations = new List<int>();
                        Bitmap[] croppedFrames = sequence.GetSequenceImages(animation, ref durations);
                        //
                        string path = fullPath + "Sprite #" + s.Index.ToString("d4") + "\\sequence-" + index.ToString("d2") + ".gif";
                        if (croppedFrames.Length > 0)
                            Do.ImagesToAnimatedGIF(croppedFrames, durations.ToArray(), path);
                        index++;
                    }
                    continue;
                }
                int[][] molds = new int[animations[s.AnimationPacket].Molds.Count][];
                int[] sheet;
                int biggestHeight = 0;
                int biggestWidth = 0;
                List<Rectangle> sheetRegions = new List<Rectangle>();
                foreach (var m in animations[s.AnimationPacket].Molds)
                {
                    foreach (var t in m.Tiles)
                        t.DrawSubtiles(
                            images[s.ImageNum].Graphics(spriteGraphics),
                            palettes[images[s.ImageNum].PaletteNum + s.PaletteIndex].Palette,
                            m.Gridplane);
                    Rectangle region;
                    if (crop)
                    {
                        if (m.Gridplane)
                            region = Do.Crop(m.GridplanePixels(), out molds[index], 32, 32);
                        else
                            region = Do.Crop(m.MoldPixels(), out molds[index], 256, 256);
                        m.MoldTilesPerPixel = null;
                        if (x + region.Width < maxwidth && biggestWidth < x + region.Width)
                            biggestWidth = x + region.Width;
                        // if reached far right boundary of a row, add current row's height
                        if (x + region.Width >= maxwidth)
                        {
                            x = region.Width;  // reset width counter
                            y += biggestHeight;
                            sheetRegions.Add(new Rectangle(x - region.Width, y, region.Width, region.Height));
                            biggestHeight = 0; // start next row
                        }
                        else
                        {
                            sheetRegions.Add(new Rectangle(x, y, region.Width, region.Height));
                            x += region.Width;
                        }
                        if (biggestHeight < region.Height)
                            biggestHeight = region.Height;
                    }
                    else
                    {
                        region = new Rectangle(new Point(0, 0), m.Gridplane ? new Size(32, 32) : new Size(256, 256));
                        molds[index] = m.Gridplane ? m.GridplanePixels() : m.MoldPixels();
                    }
                    if (!contact)
                        Do.PixelsToImage(molds[index], region.Width, region.Height).Save(
                            fullPath + "Sprite #" + s.Index.ToString("d4") + "\\mold-" + index.ToString("d2") + ".png", ImageFormat.Png);
                    index++;
                }
                if (contact)
                {
                    sheet = new int[biggestWidth * (y + biggestHeight)];
                    for (int i = 0; i < molds.Length; i++)
                        Do.PixelsToPixels(molds[i], sheet, biggestWidth, sheetRegions[i]);
                    string path = fullPath + (current ? "" : "Sprite #" + s.Index.ToString("d4") + ".png");
                    Do.PixelsToImage(sheet, biggestWidth, y + biggestHeight).Save(path, ImageFormat.Png);
                }
            }
        }
        private void Export_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar != null && progressBar.Visible)
                if (element == ElementType.Area)
                    progressBar.PerformStep("EXPORTING LEVEL #" + e.ProgressPercentage + " IMAGE");
                else
                    progressBar.PerformStep("EXPORTING SPRITE #" + e.ProgressPercentage + " MOLD IMAGES");
        }
        private void Export_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (progressBar != null && progressBar.Visible)
                progressBar.Close();
        }

        #endregion

        #region Event Handlers

        // RadioButtons
        private void range_CheckedChanged(object sender, EventArgs e)
        {
            fromIndex.Enabled = range.Checked;
            toIndex.Enabled = range.Checked;
        }
        private void oneSpriteSheet_CheckedChanged(object sender, EventArgs e)
        {
            maximumWidth.Enabled = oneSpriteSheet.Checked;
        }

        // Buttons
        private void ok_button_Click(object sender, EventArgs e)
        {
            Export();
            this.Close();
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
