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
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public static partial class Do
    {
        #region Conversion

        public static void RGBtoHSL(double r, double g, double b, out double h, out double s, out double l)
        {
            h = s = l = 0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            l = (min + max) / 2.0;
            if (l <= 0.0)
                return;
            double dif = max - min; s = dif;
            if (s > 0.0)
                s /= (l <= 0.5) ? (max + min) : (2.0 - max - min);
            else return;
            double r2 = (max - r) / dif;
            double g2 = (max - g) / dif;
            double b2 = (max - b) / dif;
            if (r == max)
                h = (g == min ? 5.0 + b2 : 1.0 - g2);
            else if (g == max)
                h = (b == min ? 1.0 + r2 : 3.0 - b2);
            else
                h = (r == min ? 3.0 + g2 : 5.0 - r2);
            h /= 6.0;
        }
        public static void HSLtoRGB(double h, double s, double l, out double r, out double g, out double b)
        {
            r = g = b = l;   // default to gray
            double v = (l <= 0.5) ? (l * (1.0 + s)) : (l + s - l * s);
            if (v > 0)
            {
                double m = l + l - v;
                double sv = (v - m) / v;
                h *= 6.0;
                int sextant = (int)h;
                double fract = h - sextant;
                double vsf = v * sv * fract;
                double mid1 = m + vsf;
                double mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
        }
        public static int HSLtoRGB(double h, double sl, double l)
        {
            double r = l;
            double g = l;
            double b = l;   // default to gray
            double v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m = l + l - v;
                double sv = (v - m) / v;
                h *= 6.0;
                int sextant = (int)h;
                double fract = h - sextant;
                double vsf = v * sv * fract;
                double mid1 = m + vsf;
                double mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            return Color.FromArgb((int)r & 0xF8, (int)g & 0xF8, (int)b & 0xF8).ToArgb();
        }
        public static void RGBtoHSL(int[] r, int[] g, int[] b, out double[] h, out double[] s, out double[] l)
        {
            h = new double[r.Length];
            s = new double[r.Length];
            l = new double[r.Length];
            for (int i = 0; i < h.Length; i++)
            {
                double r_ = r[i];
                double g_ = g[i];
                double b_ = b[i];
                h[i] = s[i] = l[i] = 0;
                double max = Math.Max(r_, Math.Max(g_, b_));
                double min = Math.Min(r_, Math.Min(g_, b_));
                l[i] = (min + max) / 2.0;
                if (l[i] <= 0.0)
                    return;
                double dif = max - min; s[i] = dif;
                if (s[i] > 0.0)
                    s[i] /= (l[i] <= 0.5) ? (max + min) : (2.0 - max - min);
                else return;
                double r2 = (max - r_) / dif;
                double g2 = (max - g_) / dif;
                double b2 = (max - b_) / dif;
                if (r_ == max)
                    h[i] = (g_ == min ? 5.0 + b2 : 1.0 - g2);
                else if (g[i] == max)
                    h[i] = (b_ == min ? 1.0 + r2 : 3.0 - b2);
                else
                    h[i] = (r_ == min ? 3.0 + g2 : 5.0 - r2);
                h[i] /= 6.0;
            }
        }
        public static Color HSLtoRGBColor(double h, double s, double l)
        {
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
                    var t3 = new double[] { h + 1.0 / 3.0, h, h - 1.0 / 3.0 };
                    var clr = new double[] { 0, 0, 0 };
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
            return Color.FromArgb((int)(r * 255.0) & 0xF8, (int)(g * 255.0) & 0xF8, (int)(b * 255.0) & 0xF8);
        }
        /// <summary>
        /// Converts an array of color indexes to an RGB pixel array.
        /// </summary>
        /// <param name="src">The source array of color indexes.</param>
        /// <param name="palette">The palette to use.</param>
        /// <returns></returns>
        public static int[] ColorsToPixels(int[] src, int[] palette)
        {
            return ColorsToPixels(src, palette, 0);
        }
        /// <summary>
        /// Converts an array of color indexes to an array of pixels.
        /// </summary>
        /// <param name="src">The source array of color indexes.</param>
        /// <param name="palette">The palette to use.</param>
        /// <param name="index">The color index offset.</param>
        /// <returns></returns>
        public static int[] ColorsToPixels(int[] src, int[] palette, int index)
        {
            int[] pixels = new int[src.Length];
            for (int i = 0; i < src.Length; i++)
                if (src[i] < palette.Length && src[i] != 0)
                    pixels[i] = palette[src[i] + index];
            return pixels;
        }

        #endregion

        #region Color effects

        /// <summary>
        /// Performs a color math operation by applying the values of an RGB pixel array to another.
        /// The result is drawn over a specified destination pixel array, ignoring transparent pixels.
        /// All arrays must be the same size.
        /// </summary>
        /// <param name="src">The pixels to apply to the operand array.</param>
        /// <param name="operand">The RGB pixel array to perform the operation on.
        /// The original referenced array is not modified during the operation.</param>
        /// <param name="dst">The RGB pixel array draw the result over.</param>
        /// <param name="width">The width, in pixels, of the pixel maps.</param>
        /// <param name="height">The height, in pixels, of the pixel maps.</param>
        /// <param name="halfIntensity">Indicates whether to add the pixels at half their RGB value.</param>
        /// <param name="minusSubscreen">Indicates whether to subtract the pixels instead of adding them.</param>
        public static void ColorMath(int[] src, int[] operand, int[] dst, int width, int height, bool halfIntensity, bool minusSubscreen)
        {
            if (src == null || operand == null || dst == null)
                return;
            int[] pixels = Bits.Copy(operand);
            // Apply subscreen to priority layer pixels using color math
            Do.ColorMath(src, pixels, width, height, halfIntensity, minusSubscreen);
            // Draw color math result to this instance's RGB pixel array
            Do.PixelsToPixels(pixels, dst, true);
        }
        /// <summary>
        /// Performs a color math operation by applying the values of an RGB pixel array to another.
        /// Both arrays must be the same size.
        /// </summary>
        /// <param name="src">The pixels to apply to the destination array.</param>
        /// <param name="dst">The RGB pixel array to perform the operation on.</param>
        /// <param name="width">The width, in pixels, of the pixel maps.</param>
        /// <param name="height">The height, in pixels, of the pixel maps.</param>
        /// <param name="halfIntensity">Indicates whether to add the pixels at half their RGB value.</param>
        /// <param name="minusSubscreen">Indicates whether to subtract the pixels instead of adding them.</param>
        public static void ColorMath(int[] src, int[] dst, int width, int height, bool halfIntensity, bool minusSubscreen)
        {
            if (src == null || dst == null)
                return;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (src[y * width + x] != 0 && dst[y * width + x] != 0)
                    {
                        dst[y * width + x] = Do.ColorMath(dst[y * width + x], src[y * width + x], halfIntensity, minusSubscreen);
                    }
                }
            }
        }
        /// <summary>
        /// Performs color math on a pixel.
        /// </summary>
        /// <param name="src">The pixel to draw onto.</param>
        /// <param name="dst">The pixel being drawn.</param>
        /// <returns></returns>
        public static int ColorMath(int src, int dst, bool halfIntensity, bool minusSubscreen)
        {
            int rsrc = Color.FromArgb(src).R;
            int gsrc = Color.FromArgb(src).G;
            int bsrc = Color.FromArgb(src).B;
            int rdst = Color.FromArgb(dst).R;
            int gdst = Color.FromArgb(dst).G;
            int bdst = Color.FromArgb(dst).B;
            if (minusSubscreen)
            {
                if (halfIntensity)
                {
                    rsrc /= 2; gsrc /= 2; bsrc /= 2;
                    rsrc -= rdst / 2;
                    gsrc -= gdst / 2;
                    bsrc -= bdst / 2;
                }
                else
                {
                    rsrc -= rdst;
                    gsrc -= gdst;
                    bsrc -= bdst;
                }
                if (rsrc < 0) rsrc = 0;
                if (gsrc < 0) gsrc = 0;
                if (bsrc < 0) bsrc = 0;
            }
            else
            {
                if (halfIntensity)
                {
                    rsrc /= 2; gsrc /= 2; bsrc /= 2;
                    rsrc += rdst / 2;
                    gsrc += gdst / 2;
                    bsrc += bdst / 2;
                }
                else
                {
                    rsrc += rdst;
                    gsrc += gdst;
                    bsrc += bdst;
                }
                if (rsrc > 255) rsrc = 255;
                if (gsrc > 255) gsrc = 255;
                if (bsrc > 255) bsrc = 255;
            }
            return Color.FromArgb(rsrc, gsrc, bsrc).ToArgb();
        }
        /// <summary>
        /// Reduces the color depth of a pixel array. Returns a newly created palette.
        /// </summary>
        /// <param name="src">The pixel array.</param>
        /// <param name="depth">The new color depth.</param>
        /// <param name="transparent">The transparent color.</param>
        public static int[] ReduceColorDepth(int[] src, int depth, int transparent)
        {
            var colors = new List<int>();
            var darkest = Color.FromArgb(255, 255, 255, 255);
            var lightest = Color.FromArgb(255, 0, 0, 0);
            foreach (int pixel in src)
            {
                Color color = Color.FromArgb(pixel);
                // skip if opacity not full
                if (color.A < 255)
                    continue;
                // find the brightest and darkest colors, the new palette needs them
                if (color.GetBrightness() > lightest.GetBrightness())
                    lightest = color;
                if (color.GetBrightness() < darkest.GetBrightness())
                    darkest = color;
                if (!colors.Contains(pixel))
                    colors.Add(color.ToArgb());
            }
            var palette = new int[depth];
            // if color amount less than depth, simply add all colors to palette and return
            if (colors.Count < depth)
            {
                palette[0] = transparent;
                for (int i = 1, a = 0; a < colors.Count; i++, a++)
                    palette[i] = colors[a];
            }
            // find the median colors in the list of colors for a total based on the depth
            else
            {
                colors.Sort();
                int increment = colors.Count / (depth - 1);
                for (int i = 0, p = 2; i < colors.Count && p < palette.Length - 1; i += increment, p++)
                    palette[p] = colors[i];
                palette[0] = transparent;
                palette[1] = lightest.ToArgb();
                palette[depth - 1] = darkest.ToArgb();
            }
            for (int i = 0; i < palette.Length; i++)
                palette[i] &= unchecked((int)0xFFF8F8F8);
            return palette;
        }
        /// <summary>
        /// Colorize a pixel array.
        /// </summary>
        /// <param name="src">The pixel array to colorize.</param>
        /// <param name="h">Hue (ie. the color).</param>
        /// <param name="s">Saturation (ie. intensity of color).</param>
        /// <param name="alpha">The opacity of the array.</param>
        public static void Colorize(int[] src, double h, double s, double l_, int alpha)
        {
            h /= 360.0;
            l_ /= 255.0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == 0)
                    continue;
                var color = Color.FromArgb(src[i]);
                double l = Math.Max(0, color.GetBrightness() + l_);
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
                        var t3 = new double[] { h + 1.0 / 3.0, h, h - 1.0 / 3.0 };
                        var clr = new double[] { 0, 0, 0 };
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
                src[i] = Color.FromArgb(alpha, (byte)(r * 255), (byte)(g * 255), (byte)(b * 255)).ToArgb();
            }
        }
        public static void Colorize(int[] src, double h, double s)
        {
            Colorize(src, h, s, 0.0, 255);
        }
        public static Bitmap Fill(Bitmap image, Color fill)
        {
            var pixels = ImageToPixels(image);
            for (int i = 0; i < pixels.Length; i++)
                if (pixels[i] >> 24 != 0)
                    pixels[i] = fill.ToArgb();
            return PixelsToImage(pixels, image.Width, image.Height);
        }
        public static void Border(int[] src, int width, int height, int size, Color color)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (src[y * width + x] == 0)
                        continue;
                    //Color c = Color.FromArgb(src[y * width + x]);
                    //int r = Math.Min(255, c.R + 32);
                    //int g = Math.Min(255, c.G + 32);
                    //int b = Math.Min(255, c.B + 32);
                    //int n = Color.FromArgb(r, g, b).ToArgb();
                    int n = color.ToArgb();
                    for (int e = size; e > 0; e--)
                    {
                        if (x - e < 0 || src[y * width + x - e] == 0)
                            src[y * width + x] = n;
                        if (x + e >= width || src[y * width + x + e] == 0)
                            src[y * width + x] = n;
                        if (y - e < 0 || src[(y - e) * width + x] == 0)
                            src[y * width + x] = n;
                        if (y + e >= height || src[(y + e) * width + x] == 0)
                            src[y * width + x] = n;
                    }
                }
            }
        }
        public static void Opacity(int[] src, int width, int height, byte opacity)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (src[y * width + x] == 0)
                        continue;
                    src[y * width + x] &= 0xFFFFFF;
                    src[y * width + x] |= opacity << 24;
                }
            }
        }
        public static void Stipple(int[] src, int width, int height)
        {
            int e = 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (src[y * width + x] == 0)
                        continue;
                    if (x - e >= 0 && src[y * width + x - e] != 0 &&
                        x + e < width && src[y * width + x + e] != 0 &&
                        y - e >= 0 && src[(y - e) * width + x] != 0 &&
                        y + e < height && src[(y + e) * width + x] != 0)
                        src[y * width + x] = 0;
                    //else if (x + e >= width || src[y * width + x + e] == 0)
                    //    src[y * width + x] = 0;
                    //else if (y - e < 0 || src[(y - e) * width + x] == 0)
                    //    src[y * width + x] = 0;
                    //else if (y + e >= height || src[(y + e) * width + x] == 0)
                    //    src[y * width + x] = 0;
                }
            }
        }
        public static void Tint(int[] src, Color tint)
        {
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == 0) continue;
                var color = Color.FromArgb(src[i]);
                int r = Math.Min(255, color.R + (tint.R / 2));
                int g = Math.Min(255, color.G + (tint.G / 2));
                int b = Math.Min(255, color.B + (tint.B / 2));
                src[i] = Color.FromArgb(r, g, b).ToArgb();
            }
        }
        public static Bitmap Hilite(Bitmap image, int width, int height)
        {
            int[] src = Do.ImageToPixels(image);
            int[] dst = Hilite(src, width, height);
            return Do.PixelsToImage(dst, width, height);
        }
        public static int[] Hilite(int[] src, int width, int height)
        {
            int[] dst = new int[src.Length];
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == 0) continue;
                var color = Color.FromArgb(src[i]);
                int l = (int)(color.GetBrightness() * 255);
                int r = Math.Min(255, 255 + l);
                int g = Math.Min(255, l);
                int b = Math.Min(255, 255 + l);
                dst[i] = Color.FromArgb(r, g, b).ToArgb();
            }
            return dst;
        }
        /// <summary>
        /// Apply a gradient effect to a pixel array.
        /// </summary>
        /// <param name="src">The pixel array to modify.</param>
        /// <param name="width">Width, in pixels, of the array.</param>
        /// <param name="height">Height, in pixels, of the array.</param>
        /// <param name="lo">Brightness level to start at.</param>
        /// <param name="hi">Brightness level to end at.</param>
        /// <param name="vert">If set, gradient moves vertically; otherwise horizontally.</param>
        /// <param name="dark">If set, gradient darkens; otherwise lightens.</param>
        public static void Gradient(int[] src, int width, int height, double lo, double hi, bool vert)
        {
            double range = Math.Abs(hi - lo);
            double l = lo;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (src[y * width + x] == 0)
                        continue;
                    var c = Color.FromArgb(src[y * width + x]);
                    int r = (int)Math.Min(255, Math.Max(0, c.R + l));
                    int g = (int)Math.Min(255, Math.Max(0, c.G + l));
                    int b = (int)Math.Min(255, Math.Max(0, c.B + l));
                    src[y * width + x] = Color.FromArgb((byte)r, (byte)g, (byte)b).ToArgb();
                    if (!vert)
                        GradientAdjust(ref l, width, lo > hi, range);
                }
                if (vert)
                    GradientAdjust(ref l, height, lo > hi, range);
                else
                    l = 0;
            }
        }
        private static void GradientAdjust(ref double l, int unit, bool dark, double range)
        {
            if (dark)
                l -= range / (double)unit;
            else
                l += range / (double)unit;
        }

        #endregion
    }
}
