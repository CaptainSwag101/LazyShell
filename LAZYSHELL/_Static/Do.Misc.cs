using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LAZYSHELL.Properties;
using LAZYSHELL.EventScripts;

namespace LAZYSHELL
{
    /// <summary>
    /// Provides a number of functions for drawing and modifying images and writing text.
    /// </summary>
    public static partial class Do
    {
        // Variables
        private static ProgressBar ProgressBar;
        private static Stopwatch StopWatch;

        // Tiles
        public static bool Compare(Subtile subtileA, Subtile subtileB)
        {
            if (Bits.Compare(subtileA.Pixels, subtileB.Pixels) &&
                subtileA.Palette == subtileB.Palette &&
                subtileA.Index == subtileB.Index &&
                subtileA.Priority1 == subtileB.Priority1 &&
                Bits.Compare(subtileA.Colors, subtileB.Colors) &&
                subtileA.Mirror == subtileB.Mirror &&
                subtileA.Invert == subtileB.Invert)
                return true;
            return false;
        }
        public static bool Compare(Tile tileA, Tile tileB)
        {
            for (int i = 0; i < 4; i++)
                if (!Compare(tileA.Subtiles[i], tileB.Subtiles[i]))
                    return false;
            return true;
        }
        public static Tile Contains(Tile[] tileset, Tile tile)
        {
            for (int i = 0; i < tileset.Length; i++)
            {
                if (Compare(tileset[i], tile))
                    return tileset[i];
            }
            return null;
        }

        // Playback WAV
        public static void Play(SoundPlayer soundPlayer, byte[] wav, bool looping)
        {
            if (wav == null)
                return;
            soundPlayer.Stream = new MemoryStream(wav);
            if (looping)
                soundPlayer.PlayLooping();
            else
                soundPlayer.Play();
        }

        // Hex editor
        public static bool Contains(List<HexEditor.Change> items, int offset)
        {
            foreach (var change in items)
                if (change.Offset == offset)
                    return true;
            return false;
        }
        public static HexEditor.Change FindOffset(List<HexEditor.Change> items, int offset)
        {
            foreach (var change in items)
                if (offset >= change.Offset && offset <= change.Offset + change.Values.Length)
                    return change;
            return null;
        }

        /// <summary>
        /// Generates a single checksum value from one or more objects.
        /// </summary>
        /// <param name="OBJECTS">The objects to analyze.</param>
        /// <returns></returns>
        public static long GenerateChecksum(params object[] OBJECTS)
        {
            try
            {
                byte[] bytes;
                int check = 0;
                MemoryStream ms;
                BinaryFormatter bf;
                foreach (object OBJECT in OBJECTS)
                {
                    if (OBJECT is byte[])
                        bytes = (byte[])OBJECT;
                    else if (OBJECT is byte[][])
                    {
                        foreach (byte[] array in (byte[][])OBJECT)
                        {
                            for (int i = 0; array != null && i < array.Length; i++)
                                check += (byte)(array[i] * i + array[i]);
                        }
                        continue;
                    }
                    // Effect animation
                    else if (OBJECT is Effects.Animation[])
                    {
                        foreach (var ea in (Effects.Animation[])OBJECT)
                        {
                            bytes = ea.Buffer;
                            for (int i = 0; i < bytes.Length; i++)
                                check += (byte)(bytes[i] * i + bytes[i]);
                        }
                        continue;
                    }
                    // Event script
                    else if (OBJECT is EventScript[])
                    {
                        foreach (var es in (EventScript[])OBJECT)
                        {
                            bytes = es.Buffer;
                            for (int i = 0; i < bytes.Length; i++)
                                check += (byte)(bytes[i] * i + bytes[i]);
                        }
                        continue;
                    }
                    // Action script
                    else if (OBJECT is ActionScript[])
                    {
                        foreach (var ac in (ActionScript[])OBJECT)
                        {
                            bytes = ac.Buffer;
                            for (int i = 0; i < bytes.Length; i++)
                                check += (byte)(bytes[i] * i + bytes[i]);
                        }
                        continue;
                    }
                    // Sprite animation
                    else if (OBJECT is Sprites.Animation[])
                    {
                        foreach (var sa in (Sprites.Animation[])OBJECT)
                        {
                            bytes = sa.Buffer;
                            for (int i = 0; i < bytes.Length; i++)
                                check += (byte)(bytes[i] * i + bytes[i]);
                        }
                        continue;
                    }
                    else
                    {
                        ms = new MemoryStream();
                        bf = new BinaryFormatter();
                        bf.Serialize(ms, OBJECT);
                        bytes = ms.ToArray();
                    }
                    for (int i = 0; i < bytes.Length; i++)
                        check += (byte)(bytes[i] * i + bytes[i]);
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return 0;
            }
        }

        // StopWatch
        public static void StopWatchStart()
        {
            StopWatch = new Stopwatch();
            StopWatch.Start();
        }
        public static string StopWatchStop(bool showMessage)
        {
            StopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = StopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            if (showMessage)
                MessageBox.Show(elapsedTime);
            return elapsedTime;
        }
        public static string StopWatchStop()
        {
            return StopWatchStop(false);
        }

        // History
        public static void AddHistory(Form form, int index, TreeNode node, string action, bool noreadoffset)
        {
            try
            {
                if (node == null)
                    return;
                string text;
                if (!noreadoffset)
                    text = action + " | index " + index + ", offset 0x" + node.Text.Substring(1, 6) + " | ";
                else
                    text = action + " | index " + index + ", \"" + node.Text.Substring(0, Math.Min(30, node.Text.Length)) + "\" | ";
                text += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString() + "\r\n";
                Model.History = Model.History.Insert(0, text);
            }
            catch { }
        }
        public static void AddHistory(Form form, int index, TreeNode node, string action)
        {
            AddHistory(form, index, node, action, false);
        }
        public static void AddHistory(Form form, int index, string action)
        {
            try
            {
                string text = action + " | index " + index + " | ";
                text += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString();
                Model.History = Model.History.Insert(0, text);
            }
            catch { }
        }
        public static void AddHistory(string message)
        {
            string text = message + "\r\n";// +" | " + DateTime.Now.ToString() + "\r\n";
            Model.History = Model.History.Insert(0, text);
        }

        // Images
        public static void CompareImages()
        {
            // first, open and create directory
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select source directory of images";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string source = folderBrowserDialog1.SelectedPath;
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select source directory of images";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string target = folderBrowserDialog1.SelectedPath;
            var sourceFiles = Directory.GetFiles(source);
            var targetFiles = Directory.GetFiles(target);
            string results = "";
            for (int i = 0; i < sourceFiles.Length && i < targetFiles.Length; i++)
            {
                var sourceFile = File.OpenRead(sourceFiles[i]);
                var targetFile = File.OpenRead(targetFiles[i]);
                var sourceReader = new BinaryReader(sourceFile);
                var targetReader = new BinaryReader(targetFile);
                if (sourceFile.Length != targetFile.Length)
                {
                    results += "Mismatched index: " + i + "\r\n";
                    continue;
                }
                var sourceBytes = sourceReader.ReadBytes((int)sourceFile.Length);
                var targetBytes = targetReader.ReadBytes((int)targetFile.Length);
                if (!Bits.Compare(sourceBytes, targetBytes))
                    results += "Mismatched index: " + i + "\r\n";
            }
            if (results == "")
                MessageBox.Show("Found no mismatched indexes.", "LAZYSHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                NewMessage.Show("MISMATCHED INDEXES", "Found the following mismatched indexes", results);
        }
        public static void CaptureScreens(Form form)
        {
            var bounds = form.Bounds;
            var screen = new Bitmap(bounds.Width, bounds.Height);
            var graphics = Graphics.FromImage(screen);
            graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            screen.Save(form.Name + ".png", ImageFormat.Png);
            // thumbnail
            var resized = ResizeImage(screen, 150, true);
            resized.Save(form.Name + "_thumb.png", ImageFormat.Png);
        }
        private static Bitmap ResizeImage(Bitmap source, int newHeight, bool sharpen)
        {
            double ratio = (double)newHeight / (double)source.Height;
            int newWidth = (int)((double)source.Width * ratio);
            var resized = new Bitmap(newWidth, newHeight);
            var graphics = Graphics.FromImage(resized);
            graphics.DrawImage(source, 0, 0, newWidth, newHeight);
            if (sharpen)
                return SharpenImage(resized, 16.0);
            else
                return resized;
        }

        // Sharpen image
        public static Bitmap SharpenImage(Bitmap image, double weight)
        {
            var matrix = new ConvolutionMatrix(3);
            matrix.SetAll(1);
            matrix.Matrix[0, 0] = 0;
            matrix.Matrix[1, 0] = -2;
            matrix.Matrix[2, 0] = 0;
            matrix.Matrix[0, 1] = -2;
            matrix.Matrix[1, 1] = weight;
            matrix.Matrix[2, 1] = -2;
            matrix.Matrix[0, 2] = 0;
            matrix.Matrix[1, 2] = -2;
            matrix.Matrix[2, 2] = 0;
            matrix.Factor = weight - 8;
            return Convolution3x3(image, matrix);
        }
        private class ConvolutionMatrix
        {
            // Variables
            public int MatrixSize = 3;
            public double[,] Matrix;
            public double Factor = 1;
            public double Offset = 1;

            // Constructor
            public ConvolutionMatrix(int size)
            {
                MatrixSize = 3;
                Matrix = new double[size, size];
            }

            // Methods
            public void SetAll(double value)
            {
                for (int i = 0; i < MatrixSize; i++)
                    for (int j = 0; j < MatrixSize; j++)
                        Matrix[i, j] = value;
            }
        }
        private static Bitmap Convolution3x3(Bitmap b, ConvolutionMatrix m)
        {
            var newImg = (Bitmap)b.Clone();
            var pixelColor = new Color[3, 3];
            int A, R, G, B;
            for (int y = 0; y < b.Height - 2; y++)
            {
                for (int x = 0; x < b.Width - 2; x++)
                {
                    pixelColor[0, 0] = b.GetPixel(x, y);
                    pixelColor[0, 1] = b.GetPixel(x, y + 1);
                    pixelColor[0, 2] = b.GetPixel(x, y + 2);
                    pixelColor[1, 0] = b.GetPixel(x + 1, y);
                    pixelColor[1, 1] = b.GetPixel(x + 1, y + 1);
                    pixelColor[1, 2] = b.GetPixel(x + 1, y + 2);
                    pixelColor[2, 0] = b.GetPixel(x + 2, y);
                    pixelColor[2, 1] = b.GetPixel(x + 2, y + 1);
                    pixelColor[2, 2] = b.GetPixel(x + 2, y + 2);
                    A = pixelColor[1, 1].A;
                    R = (int)((((pixelColor[0, 0].R * m.Matrix[0, 0]) +
                                 (pixelColor[1, 0].R * m.Matrix[1, 0]) +
                                 (pixelColor[2, 0].R * m.Matrix[2, 0]) +
                                 (pixelColor[0, 1].R * m.Matrix[0, 1]) +
                                 (pixelColor[1, 1].R * m.Matrix[1, 1]) +
                                 (pixelColor[2, 1].R * m.Matrix[2, 1]) +
                                 (pixelColor[0, 2].R * m.Matrix[0, 2]) +
                                 (pixelColor[1, 2].R * m.Matrix[1, 2]) +
                                 (pixelColor[2, 2].R * m.Matrix[2, 2]))
                                        / m.Factor) + m.Offset);
                    if (R < 0)
                        R = 0;
                    else if (R > 255)
                        R = 255;
                    G = (int)((((pixelColor[0, 0].G * m.Matrix[0, 0]) +
                                 (pixelColor[1, 0].G * m.Matrix[1, 0]) +
                                 (pixelColor[2, 0].G * m.Matrix[2, 0]) +
                                 (pixelColor[0, 1].G * m.Matrix[0, 1]) +
                                 (pixelColor[1, 1].G * m.Matrix[1, 1]) +
                                 (pixelColor[2, 1].G * m.Matrix[2, 1]) +
                                 (pixelColor[0, 2].G * m.Matrix[0, 2]) +
                                 (pixelColor[1, 2].G * m.Matrix[1, 2]) +
                                 (pixelColor[2, 2].G * m.Matrix[2, 2]))
                                        / m.Factor) + m.Offset);
                    if (G < 0)
                        G = 0;
                    else if (G > 255)
                        G = 255;
                    B = (int)((((pixelColor[0, 0].B * m.Matrix[0, 0]) +
                                 (pixelColor[1, 0].B * m.Matrix[1, 0]) +
                                 (pixelColor[2, 0].B * m.Matrix[2, 0]) +
                                 (pixelColor[0, 1].B * m.Matrix[0, 1]) +
                                 (pixelColor[1, 1].B * m.Matrix[1, 1]) +
                                 (pixelColor[2, 1].B * m.Matrix[2, 1]) +
                                 (pixelColor[0, 2].B * m.Matrix[0, 2]) +
                                 (pixelColor[1, 2].B * m.Matrix[1, 2]) +
                                 (pixelColor[2, 2].B * m.Matrix[2, 2]))
                                        / m.Factor) + m.Offset);
                    if (B < 0)
                        B = 0;
                    else if (B > 255)
                        B = 255;
                    newImg.SetPixel(x + 1, y + 1, Color.FromArgb(A, R, G, B));
                }
            }
            return newImg;
        }

        /// <summary>
        /// Converts an image collection to an animated GIF.
        /// </summary>
        /// <param name="images">The images to compile into the animated GIF.</param>
        /// <param name="durations">The durations of each frame in the GIF.</param>
        /// <param name="filename">The name of the file to save to.</param>
        public static void ImagesToAnimatedGIF(Bitmap[] images, int[] durations, string filename)
        {
            var e = new AnimatedGifEncoder();
            e.Start();
            //-1:no repeat,0:always repeat
            e.SetQuality(1);
            e.SetRepeat(0);
            e.SetTransparent(Color.FromArgb(127, 127, 127));
            for (int i = 0; i < images.Length && i < durations.Length; i++)
            {
                e.SetDelay(durations[i]);
                e.AddFrame(images[i]);
            }
            e.Finish();
            var ms = e.Output();
            var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            fs.Write(ms.ToArray(), 0, (int)ms.Length);
            fs.Close();
        }

        // Math
        public static double PercentIncrease(double percent, double value)
        {
            return value + (value * (percent / 100.0));
        }
        public static double PercentDecrease(double percent, double value)
        {
            return value - (value * (percent / 100.0));
        }
    }
    public struct Frequency
    {
        public int Index, Count;
        public object Tag;

        // ToString
        public override string ToString()
        {
            return "#" + Index + " {" + Count + "}";
        }
    }
}

