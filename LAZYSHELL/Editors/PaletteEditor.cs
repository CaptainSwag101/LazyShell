﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class PaletteEditor : Form
    {
        #region Variables
        private bool updating = false;
        private Delegate update;
        private PaletteSet paletteSet;
        private PaletteSet paletteSetBackup;
        private PaletteSet paletteSetBackup2;
        private Bitmap paletteImage, colorMapImage;
        private int[] palettePixels, colorMapPixels;
        private int currentSwatchColor = Color.FromArgb(248, 248, 248).ToArgb();
        private int count;
        private int start;
        private int currentColor = 0;
        public int CurrentColor
        {
            get { return currentColor; }
            set
            {
                currentColor = value;
                InitializeColor();
                pictureBoxPalette.Invalidate();
            }
        }
        private Overlay overlay = new Overlay();
        #endregion
        public PaletteEditor(Delegate update, PaletteSet paletteSet, int count, int start)
        {
            this.update = update;
            this.paletteSetBackup2 = paletteSet.Copy();
            this.paletteSetBackup = paletteSet.Copy();
            this.paletteSet = paletteSet;
            this.count = count;
            this.start = start;
            this.currentColor = start * 16;

            InitializeComponent();

            this.pictureBoxPalette.Height = (count * 8) - (start * 8);
            this.panel7.Height = (count * 8 + 4) - (start * 8);

            InitializeColor();
            SetColorMapImage();
            SetPaletteImage();
            this.BringToFront();
        }
        public void Reload(Delegate update, PaletteSet paletteSet, int count, int start)
        {
            this.update = update;
            this.paletteSetBackup2 = paletteSet.Copy();
            this.paletteSetBackup = paletteSet.Copy();
            this.paletteSet = paletteSet;
            this.count = count;
            this.start = start;

            this.pictureBoxPalette.Height = (count * 8) - (start * 8);
            this.panel7.Height = (count * 8 + 4) - (start * 8);

            InitializeColor();
            SetColorMapImage();
            SetPaletteImage();
            this.BringToFront();
        }
        #region Functions
        private void InitializeColor()
        {
            updating = true;
            pictureBoxCurrentColor.Invalidate();

            currentRed.Value = paletteSet.Reds[currentColor];
            currentGreen.Value = paletteSet.Greens[currentColor];
            currentBlue.Value = paletteSet.Blues[currentColor];

            currentHTML.Text = paletteSet.Reds[currentColor].ToString("X2");
            currentHTML.Text += paletteSet.Greens[currentColor].ToString("X2");
            currentHTML.Text += paletteSet.Blues[currentColor].ToString("X2");
            updating = false;
        }
        private void SetColorMapImage()
        {
            colorMapPixels = new int[186 * 186];
            int r = 248, g = 0, b = 0;
            int l = -248;
            for (int y = 0; y < 186; y++, l += y % 3 == 0 ? 8 : 0)
            {
                int x = 0;
                for (int a = 0; a < 31; a++, x++, g += 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
                for (int a = 0; a < 31; a++, x++, r -= 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
                for (int a = 0; a < 31; a++, x++, b += 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
                for (int a = 0; a < 31; a++, x++, g -= 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
                for (int a = 0; a < 31; a++, x++, r += 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
                for (int a = 0; a < 31; a++, x++, b -= 8)
                    colorMapPixels[y * 186 + x] = Color.FromArgb(
                        Math.Min(Math.Max(r + l, 0), 248),
                        Math.Min(Math.Max(g + l, 0), 248),
                        Math.Min(Math.Max(b + l, 0), 248)).ToArgb();
            }
            colorMapImage = new Bitmap(Do.PixelsToImage(colorMapPixels, 186, 186), 186, 186);
            pictureBoxColorMap.Invalidate();
        }
        private void SetPaletteImage()
        {
            palettePixels = Do.PaletteToPixels(paletteSet.Palettes, 8, 8, 16, count, start);
            paletteImage = new Bitmap(Do.PixelsToImage(palettePixels, 128, (count * 8) - (start * 8)));
            pictureBoxPalette.Invalidate();
        }
        //
        private void DoAdjustment()
        {
            if (updating) return;
            for (int i = start * 16; i < paletteSetBackup.Palette.Length; i++)
            {
                paletteSet.Reds[i] = paletteSetBackup.Reds[i];
                paletteSet.Greens[i] = paletteSetBackup.Greens[i];
                paletteSet.Blues[i] = paletteSetBackup.Blues[i];
            }
            DoColorBalance();
            DoColorSwitch();
            DoColorEquate();
            DoGreyscale();
            DoNegative();
            DoBrightness();
            DoContrast();
            DoThreshold();
            DoColorize();

            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetColorMapImage();
            SetPaletteImage();
        }
        private void DoColorBalance()
        {
            for (int i = start * 16; i < paletteSet.Palette.Length; i++)
            {
                int r = paletteSet.Reds[i];
                int g = paletteSet.Greens[i];
                int b = paletteSet.Blues[i];
                r += (int)(r * ((double)levelsReds.Value / 100.0));
                r = Math.Min(248, r); r &= 0xF8;
                g += (int)(g * ((double)levelsGreens.Value / 100.0));
                g = Math.Min(248, g); g &= 0xF8;
                b += (int)(b * ((double)levelsBlues.Value / 100.0));
                b = Math.Min(248, b); b &= 0xF8;
                paletteSet.Reds[i] = r;
                paletteSet.Greens[i] = g;
                paletteSet.Blues[i] = b;
            }
        }
        private void DoColorSwitch()
        {
            int[] rgbA, rgbB;

            if (switchRedsA.Checked)
                rgbA = paletteSet.Reds;
            else if (switchGreensA.Checked)
                rgbA = paletteSet.Greens;
            else
                rgbA = paletteSet.Blues;

            if (switchRedsB.Checked)
                rgbB = paletteSet.Reds;
            else if (switchGreensB.Checked)
                rgbB = paletteSet.Greens;
            else
                rgbB = paletteSet.Blues;

            for (int c = start * 16; c < rgbA.Length; c++)
            {
                int a = rgbA[c];
                int b = rgbB[c];
                rgbA[c] = b;
                rgbB[c] = a;
            }
        }
        private void DoColorEquate()
        {
            int[] rgbA, rgbB;

            if (equateRedsA.Checked)
                rgbA = paletteSet.Reds;
            else if (equateGreensA.Checked)
                rgbA = paletteSet.Greens;
            else
                rgbA = paletteSet.Blues;

            if (equateRedsB.Checked)
                rgbB = paletteSet.Reds;
            else if (equateGreensB.Checked)
                rgbB = paletteSet.Greens;
            else
                rgbB = paletteSet.Blues;

            for (int c = start * 16; c < rgbA.Length; c++)
            {
                int b = rgbB[c];
                rgbA[c] = b;
            }
        }
        private void DoGreyscale()
        {
            if (greyscale.Checked)
            {
                for (int i = start * 16; i < paletteSet.Palette.Length; i++)
                {
                    int r = paletteSet.Reds[i];
                    int g = paletteSet.Greens[i];
                    int b = paletteSet.Blues[i];
                    if (r == g && r == b) continue;
                    double grey = (r * 0.3) + (g * 0.59) + (b * 0.11);
                    paletteSet.Reds[i] = (int)Math.Round(grey, MidpointRounding.ToEven);
                    paletteSet.Greens[i] = (int)Math.Round(grey, MidpointRounding.ToEven);
                    paletteSet.Blues[i] = (int)Math.Round(grey, MidpointRounding.ToEven);
                }
            }
        }
        private void DoNegative()
        {
            if (negative.Checked)
            {
                for (int i = start * 16; i < paletteSet.Palette.Length; i++)
                {
                    paletteSet.Reds[i] ^= 248;
                    paletteSet.Greens[i] ^= 248;
                    paletteSet.Blues[i] ^= 248;
                }
            }
        }
        private void DoBrightness()
        {
            if (brightness.Value == 0) return;
            for (int i = start * 16; i < paletteSet.Palette.Length; i++)
            {
                int r = paletteSet.Reds[i];
                int g = paletteSet.Greens[i];
                int b = paletteSet.Blues[i];
                paletteSet.Reds[i] = Math.Min(248, Math.Max(0, r + (int)brightness.Value));
                paletteSet.Greens[i] = Math.Min(248, Math.Max(0, g + (int)brightness.Value));
                paletteSet.Blues[i] = Math.Min(248, Math.Max(0, b + (int)brightness.Value));
            }
        }
        private void DoContrast()
        {
            if (this.contrast.Value == 0) return;
            double contrast = ((double)this.contrast.Value + 100) / 100.0;
            for (int i = start * 16; i < paletteSet.Palette.Length; i++)
            {
                double r = paletteSet.Reds[i];
                double g = paletteSet.Greens[i];
                double b = paletteSet.Blues[i];

                r = Math.Max(0, Math.Min(248, (r - 128) * contrast + 128));
                g = Math.Max(0, Math.Min(248, (g - 128) * contrast + 128));
                b = Math.Max(0, Math.Min(248, (b - 128) * contrast + 128));

                paletteSet.Reds[i] = (int)r & 0xF8;
                paletteSet.Greens[i] = (int)g & 0xF8;
                paletteSet.Blues[i] = (int)b & 0xF8;
            }
        }
        private void DoThreshold()
        {
            if (!thresholdApply.Checked) return;
            for (int i = start * 16; i < paletteSet.Palette.Length; i++)
            {
                int r = paletteSet.Reds[i];
                int g = paletteSet.Greens[i];
                int b = paletteSet.Blues[i];
                int brightness = (int)Math.Sqrt(
                    (r * r * .241) +
                    (g * g * .691) +
                    (b * b * .068));
                paletteSet.Reds[i] = brightness >= threshold.Value ? 248 : 0;
                paletteSet.Greens[i] = brightness >= threshold.Value ? 248 : 0;
                paletteSet.Blues[i] = brightness >= threshold.Value ? 248 : 0;
            }
        }
        private void DoColorize()
        {
            if (!colorizeApply.Checked) return;

            double h = (double)colorizeHue.Value / 255.0;
            double s = (double)colorizeSaturation.Value / 255.0;
            for (int i = start * 16; i < paletteSet.Palette.Length; i++)
            {
                Color color = Color.FromArgb(paletteSet.Reds[i], paletteSet.Greens[i], paletteSet.Blues[i]);
                double l = color.GetBrightness();
                double r = 0, g = 0, b = 0;
                double temp1, temp2;
                if (l == 0)
                {
                    r = g = b = 0;
                }
                else
                {
                    if (s == 0)
                    {
                        r = g = b = l;
                    }
                    else
                    {
                        temp2 = ((l <= 0.5) ? l * (1.0 + s) : l + s - (l * s));
                        temp1 = 2.0 * l - temp2;
                        double[] t3 = new double[] { h + 1.0 / 3.0, h, h - 1.0 / 3.0 };
                        double[] clr = new double[] { 0, 0, 0 };
                        for (int a = 0; a < 3; a++)
                        {
                            if (t3[a] < 0)
                                t3[a] += 1.0;
                            if (t3[a] > 1)
                                t3[a] -= 1.0;
                            if (6.0 * t3[a] < 1.0)
                                clr[a] = temp1 + (temp2 - temp1) * t3[a] * 6.0;
                            else if (2.0 * t3[a] < 1.0)
                                clr[a] = temp2;
                            else if (3.0 * t3[a] < 2.0)
                                clr[a] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[a]) * 6.0);
                            else
                                clr[a] = temp1;
                        }
                        r = clr[0];
                        g = clr[1];
                        b = clr[2];
                    }
                }
                paletteSet.Reds[i] = (int)(r * 255.0) & 0xF8;
                paletteSet.Greens[i] = (int)(g * 255.0) & 0xF8;
                paletteSet.Blues[i] = (int)(b * 255.0) & 0xF8;
            }
        }
        //private void importPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string path = SelectFile("Select the file to import", "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*");

        //    FileStream fs;
        //    BinaryReader br;

        //    byte[] buffer = new byte[1024];

        //    try
        //    {
        //        fs = File.OpenRead(path);

        //        if (Path.GetExtension(path) == ".pal")
        //        {
        //            br = new BinaryReader(fs);
        //            if (fs.Length > buffer.Length)
        //                buffer = br.ReadBytes(buffer.Length);
        //            else
        //                br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

        //            for (int i = 0; i < 7; i++) // 7 palettes in set
        //            {
        //                for (int j = 0; j < 16; j++) // 16 colors in palette
        //                {
        //                    if (contextMenuStrip3.SourceControl == palettePictureBox)
        //                    {
        //                        paletteSet.Reds[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
        //                        paletteSet.Greens[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
        //                        paletteSet.Blues[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
        //                    }
        //                    else
        //                    {
        //                        paletteSetBF.Reds[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
        //                        paletteSetBF.Greens[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
        //                        paletteSetBF.Blues[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            br = new BinaryReader(fs);
        //            if (fs.Length > buffer.Length)
        //                buffer = br.ReadBytes(buffer.Length);
        //            else
        //                br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

        //            double multiplier = 8; // 8;
        //            ushort color = 0;

        //            for (int i = 0; i < 7; i++) // 7 palettes in set
        //            {
        //                for (int j = 0; j < 16; j++) // 16 colors in palette
        //                {
        //                    color = Bits.GetShort(buffer, (i * 30) + (j * 2));

        //                    if (contextMenuStrip3.SourceControl == palettePictureBox)
        //                    {
        //                        paletteSet.Reds[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
        //                        paletteSet.Greens[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
        //                        paletteSet.Blues[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
        //                    }
        //                    else
        //                    {
        //                        paletteSetBF.Reds[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
        //                        paletteSetBF.Greens[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
        //                        paletteSetBF.Blues[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
        //                    }
        //                }
        //            }
        //        }
        //        if (contextMenuStrip3.SourceControl == palettePictureBox)
        //            mapNum_ValueChanged(null, null);
        //        else
        //            battlefieldNum_ValueChanged(null, null);

        //        fs.Close();
        //        br.Close();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
        //        return;
        //    }
        //}
        //private void exportPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*";
        //    saveFileDialog.FilterIndex = 0;
        //    if (contextMenuStrip3.SourceControl == palettePictureBox)
        //        saveFileDialog.FileName = "paletteSet." + ((int)(mapPaletteSetNum.Value)).ToString("d3");
        //    else
        //        saveFileDialog.FileName = "paletteSetBat." + ((int)(battlefieldPaletteSetNum.Value)).ToString("d3");
        //    saveFileDialog.RestoreDirectory = true;

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        FileStream fs;
        //        BinaryWriter bw;
        //        byte[] buffer = new byte[1024];

        //        if (saveFileDialog.FilterIndex == 2)
        //        {
        //            byte[] temp = new byte[]
        //            {
        //                0x52, 0x49, 0x46, 0x46, 0x14, 0x04, 0x00, 0x00, 
        //                0x50, 0x41, 0x4C, 0x20, 0x64, 0x61, 0x74, 0x61
        //            };
        //            temp.CopyTo(buffer, 0);

        //            Bits.SetShort(buffer, 0x10, 448 + 3);

        //            for (int i = 0; i < 7; i++) // 7 palettes in set
        //            {
        //                for (int j = 0; j < 16; j++) // 16 colors in palette
        //                {
        //                    if (contextMenuStrip3.SourceControl == palettePictureBox)
        //                    {
        //                        buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)paletteSet.Reds[(i * 16) + j];
        //                        buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)paletteSet.Greens[(i * 16) + j];
        //                        buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)paletteSet.Blues[(i * 16) + j];
        //                    }
        //                    else
        //                    {
        //                        buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)paletteSetBF.Reds[(i * 16) + j];
        //                        buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)paletteSetBF.Greens[(i * 16) + j];
        //                        buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)paletteSetBF.Blues[(i * 16) + j];
        //                    }
        //                }
        //            }

        //            fs = new FileStream(saveFileDialog.FileName + ".pal", FileMode.Create, FileAccess.ReadWrite);
        //            bw = new BinaryWriter(fs);
        //            bw.Write(buffer, 0, 448 + 0x17);
        //            bw.Close();
        //            fs.Close();
        //        }
        //        else
        //        {
        //            ushort color = 0;
        //            int r, g, b;

        //            for (int i = 0; i < 7; i++) // 7 palettes in set
        //            {
        //                for (int j = 0; j < 16; j++) // 16 colors in palette
        //                {
        //                    if (contextMenuStrip3.SourceControl == palettePictureBox)
        //                    {
        //                        r = (int)(paletteSet.Reds[(i * 16) + j] / 8);
        //                        g = (int)(paletteSet.Greens[(i * 16) + j] / 8);
        //                        b = (int)(paletteSet.Blues[(i * 16) + j] / 8);
        //                    }
        //                    else
        //                    {
        //                        r = (int)(paletteSetBF.Reds[(i * 16) + j] / 8);
        //                        g = (int)(paletteSetBF.Greens[(i * 16) + j] / 8);
        //                        b = (int)(paletteSetBF.Blues[(i * 16) + j] / 8);
        //                    }
        //                    color = (ushort)((b << 10) | (g << 5) | r);
        //                    Bits.SetShort(buffer, (i * 30) + (j * 2), color);
        //                }
        //            }

        //            fs = new FileStream(saveFileDialog.FileName + ".bin", FileMode.Create, FileAccess.ReadWrite);
        //            bw = new BinaryWriter(fs);
        //            bw.Write(buffer, 0, 0xE0);
        //            bw.Close();
        //            fs.Close();
        //        }
        //    }
        //}
        #endregion
        #region Event Handlers
        private void PaletteEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset_Click(null, null);
        }
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0, 128, (count * 8) - (start * 8));

            Point p = new Point(currentColor % 16 * 8, currentColor / 16 * 8 - (start * 8));
            e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(p.X, p.Y, 7, 7));
        }
        private void pictureBoxPalette_MouseClick(object sender, MouseEventArgs e)
        {
            currentColor = (e.Y / 8 * 16) + (e.X / 8) + (start * 16);
            InitializeColor();
            pictureBoxPalette.Invalidate();
        }
        private void pictureBoxCurrentColor_Paint(object sender, PaintEventArgs e)
        {
            int color = paletteSet.Palettes[currentColor / 16][currentColor % 16];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 64, 64));
        }
        private void pictureBoxColorMap_Paint(object sender, PaintEventArgs e)
        {
            if (colorMapImage != null)
                e.Graphics.DrawImage(new Bitmap(colorMapImage), 0, 0, 186, 186);
        }
        private void pictureBoxColorMap_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void pictureBoxColorMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int x = Math.Min(186, Math.Max(0, e.X));
            int y = Math.Min(186, Math.Max(0, e.Y));
            int color = colorMapPixels[y * 186 + x];
            Color c = Color.FromArgb(color);
            currentSwatchColor = c.ToArgb();
            pictureBoxSwatchColor.BackColor = c;
        }
        private void pictureBoxColorMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (e.X >= 186 || e.Y >= 186)
                return;
            int x = Math.Min(186, Math.Max(0, e.X));
            int y = Math.Min(186, Math.Max(0, e.Y));
            int color = colorMapPixels[y * 186 + x];
            Color c = Color.FromArgb(color);
            currentSwatchColor = c.ToArgb();
            pictureBoxSwatchColor.BackColor = c;
        }
        private void pictureBoxColorMap_MouseUp(object sender, MouseEventArgs e)
        {
        }
        //
        private void currentRed_ValueChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "currentRed")
                trackBar1.Value = (int)currentRed.Value & 0xF8;
            else if (((Control)sender).Name == "trackBar1")
                currentRed.Value = trackBar1.Value & 0xF8;
            if (updating) return;
            paletteSet.Reds[currentColor] = (int)currentRed.Value & 0xF8;
            paletteSetBackup.Reds[currentColor] = paletteSet.Reds[currentColor];
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
            currentRed.Focus();
        }
        private void currentGreen_ValueChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "currentGreen")
                trackBar2.Value = (int)currentGreen.Value & 0xF8;
            else if (((Control)sender).Name == "trackBar2")
                currentGreen.Value = trackBar2.Value & 0xF8;
            if (updating) return;
            paletteSet.Greens[currentColor] = (int)currentGreen.Value & 0xF8;
            paletteSetBackup.Greens[currentColor] = paletteSet.Greens[currentColor];
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
            currentGreen.Focus();
        }
        private void currentBlue_ValueChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "currentBlue")
                trackBar3.Value = (int)currentBlue.Value & 0xF8;
            else if (((Control)sender).Name == "trackBar3")
                currentBlue.Value = trackBar3.Value & 0xF8;
            if (updating) return;
            paletteSet.Blues[currentColor] = (int)currentBlue.Value & 0xF8;
            paletteSetBackup.Blues[currentColor] = paletteSet.Blues[currentColor];
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
            currentBlue.Focus();
        }
        private void currentHTML_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (currentHTML.Text.Length != 6) return;
            paletteSet.Reds[currentColor] = Int32.Parse(currentHTML.Text.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            paletteSet.Greens[currentColor] = Int32.Parse(currentHTML.Text.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            paletteSet.Blues[currentColor] = Int32.Parse(currentHTML.Text.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            paletteSetBackup.Reds[currentColor] = paletteSet.Reds[currentColor];
            paletteSetBackup.Greens[currentColor] = paletteSet.Greens[currentColor];
            paletteSetBackup.Blues[currentColor] = paletteSet.Blues[currentColor];
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
        }
        //
        private void levelsReds_ValueChanged(object sender, EventArgs e)
        {
            levelsRedsBar.Value = (int)levelsReds.Value;
            DoAdjustment();
        }
        private void levelsGreens_ValueChanged(object sender, EventArgs e)
        {
            levelsGreensBar.Value = (int)levelsGreens.Value;
            DoAdjustment();
        }
        private void levelsBlues_ValueChanged(object sender, EventArgs e)
        {
            levelsBluesBar.Value = (int)levelsBlues.Value;
            DoAdjustment();
        }
        private void levelsRedsBar_Scroll(object sender, EventArgs e)
        {
            levelsReds.Value = levelsRedsBar.Value;
        }
        private void levelsGreensBar_Scroll(object sender, EventArgs e)
        {
            levelsGreens.Value = levelsGreensBar.Value;
        }
        private void levelsBluesBar_Scroll(object sender, EventArgs e)
        {
            levelsBlues.Value = levelsBluesBar.Value;
        }
        private void switchRedsA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void switchGreensA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void switchBluesA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void switchRedsB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void switchGreensB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void switchBluesB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateRedsA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateGreensA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateBluesA_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateRedsB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateGreensB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void equateBluesB_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void contrast_ValueChanged(object sender, EventArgs e)
        {
            trackBarContrast.Value = (int)contrast.Value;
            DoAdjustment();
        }
        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            contrast.Value = trackBarContrast.Value;
        }
        private void brightness_ValueChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = (int)brightness.Value;
            DoAdjustment();
        }
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            brightness.Value = trackBarBrightness.Value;
        }
        private void thresholdApply_CheckedChanged(object sender, EventArgs e)
        {
            threshold.Enabled = trackBarThreshold.Enabled = thresholdApply.Checked;
            DoAdjustment();
        }
        private void threshold_ValueChanged(object sender, EventArgs e)
        {
            trackBarThreshold.Value = (int)threshold.Value;
            DoAdjustment();
        }
        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            threshold.Value = trackBarThreshold.Value;
        }
        private void negative_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void greyscale_CheckedChanged(object sender, EventArgs e)
        {
            DoAdjustment();
        }
        private void colorizeApply_CheckedChanged(object sender, EventArgs e)
        {
            colorizeHue.Enabled =
                colorizeHueBar.Enabled =
                colorizeSaturation.Enabled =
                colorizeSaturationBar.Enabled = colorizeApply.Checked;
            DoAdjustment();
        }
        private void colorizeHue_ValueChanged(object sender, EventArgs e)
        {
            colorizeHueBar.Value = (int)colorizeHue.Value;
            DoAdjustment();
            pictureBox1.Invalidate();
        }
        private void colorizeSaturation_ValueChanged(object sender, EventArgs e)
        {
            colorizeSaturationBar.Value = (int)colorizeSaturation.Value;
            pictureBox1.Invalidate();
            DoAdjustment();
        }
        private void colorizeHueBar_Scroll(object sender, EventArgs e)
        {
            colorizeHue.Value = colorizeHueBar.Value;
        }
        private void colorizeSaturationBar_Scroll(object sender, EventArgs e)
        {
            colorizeSaturation.Value = colorizeSaturationBar.Value;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            double increment = 197.0 / 255.0;
            int x = 0;
            for (double i = 0; i < 197; i += increment, x++)
            {
                Pen pen = new Pen(Do.HSLtoRGBColor(x / 255.0, (double)colorizeSaturation.Value / 255.0, 0.5));
                e.Graphics.DrawLine(pen, (float)i, 0, (float)i, 17);
            }
            double ratio = (double)pictureBox1.Width / 255.0;
            x = Math.Min(pictureBox1.Width, Math.Max(0, (int)((double)colorizeHue.Value * ratio)));
            e.Graphics.DrawLine(new Pen(Color.Black), x, 0, x, 17);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!colorizeApply.Checked) return;
            int x = Math.Min(pictureBox1.Width, Math.Max(0, e.X));
            colorizeHue.Value = (int)((double)x * (255.0 / (double)pictureBox1.Width));
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!colorizeApply.Checked) return;
            if (e.Button != MouseButtons.Left)
                return;
            int x = Math.Min(pictureBox1.Width, Math.Max(0, e.X));
            colorizeHue.Value = (int)((double)x * (255.0 / (double)pictureBox1.Width));
        }
        //
        private void buttonOK_Click(object sender, EventArgs e)
        {
            paletteSet.CopyTo(paletteSetBackup);
            paletteSet.CopyTo(paletteSetBackup2);
            this.Close();
            if (!autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            updating = true;
            levelsReds.Value = levelsRedsBar.Value = 0;
            levelsGreens.Value = levelsGreensBar.Value = 0;
            levelsBlues.Value = levelsBluesBar.Value = 0;
            switchRedsA.Checked = true; switchGreensA.Checked = false; switchBluesA.Checked = false;
            switchRedsB.Checked = true; switchGreensB.Checked = false; switchBluesB.Checked = false;
            equateRedsA.Checked = true; equateGreensA.Checked = false; equateBluesA.Checked = false;
            equateRedsB.Checked = true; equateGreensB.Checked = false; equateBluesB.Checked = false;
            greyscale.Checked = false; negative.Checked = false;
            brightness.Value = trackBarBrightness.Value = 0;
            contrast.Value = trackBarContrast.Value = 0;
            thresholdApply.Checked = false;
            threshold.Value = trackBarThreshold.Value = 128;
            colorizeApply.Checked = false;
            colorizeHue.Value = colorizeHueBar.Value = 128;
            colorizeSaturation.Value = colorizeSaturationBar.Value = 128;
            updating = false;
            paletteSetBackup2.CopyTo(paletteSetBackup);
            DoAdjustment();
            paletteSetBackup2.CopyTo(paletteSet);
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update.DynamicInvoke();
        }
        //
        private void buttonSetToColor_Click(object sender, EventArgs e)
        {
            paletteSet.Reds[currentColor] = Color.FromArgb(currentSwatchColor).R;
            paletteSet.Greens[currentColor] = Color.FromArgb(currentSwatchColor).G;
            paletteSet.Blues[currentColor] = Color.FromArgb(currentSwatchColor).B;
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
        }
        //
        private void importPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin|Microsoft palette files (*.pal)|*.pal|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            FileStream fs = File.OpenRead(openFileDialog.FileName);
            BinaryReader br = new BinaryReader(fs);
            byte[] buffer = new byte[1024];
            try
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".pal")
                {
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    for (int i = 0; i < paletteSet.Reds.Length; i++) // 16 colors in palette
                    {
                        paletteSet.Reds[i] = buffer[(i * 4) + 1 + 0x17];
                        paletteSet.Greens[i] = buffer[(i * 4) + 2 + 0x17];
                        paletteSet.Blues[i] = buffer[(i * 4) + 3 + 0x17];
                    }
                }
                else
                {
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    double multiplier = 8; // 8;
                    ushort color = 0;

                    for (int i = 0; i < paletteSet.Reds.Length; i++) // 16 colors in palette
                    {
                        color = Bits.GetShort(buffer, (i * 2));

                        paletteSet.Reds[i] = (byte)((color % 0x20) * multiplier);
                        paletteSet.Greens[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                        paletteSet.Blues[i] = (byte)(((color >> 10) % 0x20) * multiplier);
                    }
                }
                br.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            InitializeColor();
            SetPaletteImage();
        }
        private void exportPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "paletteSet.bin";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                BinaryWriter bw;
                byte[] buffer = new byte[1024];

                if (saveFileDialog.FilterIndex == 2)
                {
                    byte[] temp = new byte[]
                    {
                        0x52, 0x49, 0x46, 0x46, 0x14, 0x04, 0x00, 0x00, 
                        0x50, 0x41, 0x4C, 0x20, 0x64, 0x61, 0x74, 0x61
                    };
                    temp.CopyTo(buffer, 0);

                    Bits.SetShort(buffer, 0x10, 448 + 3);

                    for (int i = 0; i < paletteSet.Reds.Length; i++) // 16 colors in palette
                    {
                        buffer[(i * 4) + 1 + 0x17] = (byte)paletteSet.Reds[i];
                        buffer[(i * 4) + 2 + 0x17] = (byte)paletteSet.Greens[i];
                        buffer[(i * 4) + 3 + 0x17] = (byte)paletteSet.Blues[i];
                    }

                    fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 448 + 0x17);
                    bw.Close();
                    fs.Close();
                }
                else
                {
                    ushort color = 0;
                    int r, g, b;

                    for (int i = 0; i < paletteSet.Reds.Length; i++) // 16 colors in palette
                    {
                        r = (int)(paletteSet.Reds[i] / 8);
                        g = (int)(paletteSet.Greens[i] / 8);
                        b = (int)(paletteSet.Blues[i] / 8);
                        color = (ushort)((b << 10) | (g << 5) | r);
                        Bits.SetShort(buffer, (i * 2), color);
                    }

                    fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 0xE0);
                    bw.Close();
                    fs.Close();
                }
            }
        }
        #endregion
    }
}