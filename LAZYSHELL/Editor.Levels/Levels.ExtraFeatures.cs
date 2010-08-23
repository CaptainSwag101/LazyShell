using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.ComponentModel;

namespace LAZYSHELL
{
    public partial class Levels
    {
        private bool CreateDir(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            try
            {
                if (!di.Exists)
                {
                    di.Create();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was an error trying to create the directory : " + dir, "LAZY SHELL");
                return false;
            }
        }

        private void ExportLevelImages_DoWork(object sender, DoWorkEventArgs e)
        {
            fullPath += "\\" + model.GetFileNameWithoutPath() + " - Level Images\\";

            // Create Level Data directory
            if (!CreateDir(fullPath))
                return;

            fullPath += "levelImage.";

            LevelLayer layr;
            TileSet set;
            TileMap map;
            LevelMap lmap;
            PaletteSet palSet;
            int[] pixels;
            Image image = null;
            int i = 0;

            for (i = 0; i < 510; i++)
            {
                if (ExportLevelImages.CancellationPending) break;

                lmap = levelMaps[levels[i].LevelMap];
                palSet = paletteSets[levelMaps[levels[i].LevelMap].PaletteSet];

                set = new TileSet(lmap, palSet);
                map = new TileMap(levels[i], set);

                pixels = map.Mainscreen;

                unsafe
                {
                    fixed (void* firstPixel = &pixels[0])
                    {
                        IntPtr ip = new IntPtr(firstPixel);
                        if (image != null)
                            image.Dispose();
                        image = new Bitmap(1024, 1024, 1024 * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                    }
                }
                levelsTilemap.Picture.CreateGraphics().DrawImage(new Bitmap(image), 0, 0);
                image.Save(fullPath + i.ToString("d3") + ".png", System.Drawing.Imaging.ImageFormat.Png);

                ExportLevelImages.ReportProgress(i);
            }
        }
        private void ExportLevelImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            levelsTilemap.Picture.Invalidate();
            this.Update();
            this.Enabled = true;
        }
        private void ExportLevelImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("SAVING LEVEL IMAGE FOR LEVEL #" + e.ProgressPercentage.ToString("d3"));
        }

        private string GetDirectoryPath(string caption)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.SelectedPath = settings.LastDirectory;
            folderBrowserDialog1.Description = caption;

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.LastDirectory = folderBrowserDialog1.SelectedPath;
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return null;
        }
        public void RefreshLevelName()
        {
            updating = true;
            levelName.BeginUpdate();
            levelName.Items.Clear();
            levelName.Items.AddRange(Lists.Numerize(Lists.Convert(settings.LevelNames)));
            levelName.SelectedIndex = index;
            levelName.EndUpdate();
            updating = false;
        }
    }
}
