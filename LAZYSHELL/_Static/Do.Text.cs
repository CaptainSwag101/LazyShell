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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public static partial class Do
    {
        #region Contains

        /// <summary>
        /// Returns a value indicating whether a collection of objects contains a specific object.
        /// </summary>
        /// <param name="value">The object to search for.</param>
        /// <param name="collection">The collection of objects to search.</param>
        /// <returns></returns>
        public static bool Contains(object value, object[] collection)
        {
            foreach (var item in collection)
                if (item is ArrayList)
                {
                    foreach (object arrayItem in (ArrayList)item)
                        if (arrayItem == value)
                            return true;
                }
                else if (item == value)
                    return true;
            return false;
        }
        public static bool Contains(object value, ArrayList collection)
        {
            foreach (var item in collection)
                if (item is ArrayList)
                {
                    foreach (object arrayItem in (ArrayList)item)
                        if (arrayItem == value)
                            return true;
                }
                else if (item == value)
                    return true;
            return false;
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }
        public static bool Contains(string original, string value, StringComparison comparisionType, out int index)
        {
            index = original.IndexOf(value, comparisionType);
            return index >= 0;
        }
        public static bool Contains(string original, string value, StringComparison comparisionType, bool matchWholeWord)
        {
            int index = original.IndexOf(value, comparisionType);
            if (!matchWholeWord)
                return index >= 0;
            else if (index >= 0)
            {
                if (index + value.Length < original.Length && Char.IsLetter(original, index + value.Length))
                    return false;
                if (index - 1 >= 0 && Char.IsLetter(original, index - 1))
                    return false;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Searches for an occurrence of a tile within a tileset and returns the index of the occurrence if found.
        /// Otherwise it returns the index of the tile being searched for.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static int Contains(Tile value, Tile[] collection)
        {
            foreach (var item in collection)
                if (item == value)
                    return value.Index;
                else if (Bits.Compare(item.Pixels, value.Pixels))
                    return item.Index;
            return value.Index;
        }

        #endregion

        #region ASCII conversion

        /// <summary>
        /// Converts an ASCII format string into a raw char array using a keystroke table.
        /// </summary>
        /// <param name="text">The ASCII string to convert.</param>
        /// <param name="keystrokes">The keystroke table to use.</param>
        /// <param name="length">The maximum length of the converted char array.</param>
        /// <returns></returns>
        public static char[] ASCIIToRaw(string text, string[] keystrokes, int length)
        {
            var temp = new char[length];
            int i = 0;
            for (; i < temp.Length && i < text.Length; i++)
            {
                for (int a = 0; a < keystrokes.Length; a++)
                {
                    if (keystrokes[a] == text.Substring(i, 1))
                        temp[i] = (char)a;
                }
            }
            // pad with spaces
            for (; i < temp.Length; i++)
                temp[i] = '\x20';
            return temp;
        }
        public static char[] ASCIIToRaw(string text, string[] keystrokes)
        {
            return ASCIIToRaw(text, keystrokes, text.Length);
        }
        /// <summary>
        /// Convert a raw char array to viewable ASCII format using a table of keystrokes.
        /// </summary>
        /// <param name="chars">The char array to convert.</param>
        /// <param name="keystrokes">The keystroke table to use.</param>
        /// <returns></returns>
        public static string RawToASCII(char[] chars, string[] keystrokes)
        {
            string temp = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= keystrokes.Length)
                    continue;
                if (keystrokes[chars[i]] == "")
                    temp += "_";
                temp += keystrokes[chars[i]];
            }
            return temp;
        }

        #endregion

        #region Search

        /// <summary>
        /// Search for a string in an array of string, and add every instance to a specified listbox.
        /// Each item in the listbox will be tagged with the respective index;
        /// </summary>
        /// <param name="names">The list of names to search.</param>
        /// <param name="name">The string to search for.</param>
        /// <param name="listBox">The listbox to write to.</param>
        /// <param name="ignoreCase">Specifies whether to ignore case when searching.</param>
        public static void Search(ComboBox.ObjectCollection names, string name, ListBox listBox, bool ignoreCase)
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            if (name == "")
            {
                listBox.EndUpdate();
                return;
            }
            for (int i = 0; i < names.Count; i++)
            {
                if (((string)names[i]).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    listBox.Items.Add(names[i]);
            }
            listBox.EndUpdate();
            listBox.BringToFront();
        }
        public static void Search(object listControl, string name, bool ignoreCase)
        {
        }
        public static int IndexOf(string[] collection, string item)
        {
            for (int i = 0; i < collection.Length; i++)
                if (item == collection[i])
                    return i;
            return -1;
        }

        #endregion

        #region Word Wrap

        public static string WordWrap(string text, int width)
        {
            return WordWrap(text, width, 0);
        }
        public static string WordWrap(string text, int width, int indent)
        {
            int pos, next;
            string pad = String.Empty.PadLeft(indent, ' ');
            var sb = new StringBuilder();
            // Lucidity check
            if (width < 1)
                return text;
            // Parse each line of text
            for (pos = 0; pos < text.Length; pos = next)
            {
                // Find end of line
                int eol = text.IndexOf(Environment.NewLine, pos);
                if (eol == -1)
                    next = eol = text.Length;
                else
                    next = eol + Environment.NewLine.Length;
                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;
                        if (len > width)
                            len = BreakLine(text, pos, width);
                        sb.Append(text, pos, len);
                        sb.Append(Environment.NewLine + pad);
                        // Trim whitespace following break
                        pos += len;
                        while (pos < eol && Char.IsWhiteSpace(text[pos]))
                            pos++;
                    }
                    while (eol > pos);
                }
                else
                    sb.Append(Environment.NewLine + pad); // Empty line
            }
            // Removes extra line
            sb.Remove(sb.Length - indent - Environment.NewLine.Length, indent + Environment.NewLine.Length);
            return sb.ToString();
        }
        private static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;
            // If no whitespace found, break at maximum length
            if (i < 0)
                return max;
            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;
            // Return length of text before whitespace
            return i + 1;
        }

        #endregion

        #region String drawing

        public static void DrawString(Graphics g, Point p, string text, Color forecolor, Color backcolor, Font font)
        {
            var rdst = new RectangleF(new PointF(p.X, p.Y),
                g.MeasureString(text, font, new PointF(0, 0), StringFormat.GenericDefault));
            g.FillRectangle(new SolidBrush(Color.FromArgb(192, backcolor)), rdst);
            g.DrawString(text, font,
                new SolidBrush(forecolor), new PointF(rdst.X, rdst.Y));
        }
        public static string BitArrayToString(byte[] array, int bytesperline, bool tagoffset, bool tagsuboffset, int offsetstart)
        {
            string text = "ROM    | ANIM   | DATA\r\n-------+--------+-------------------------------------------------\r\n";
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0 && i % bytesperline == 0)
                    text += "\r\n";
                if (i % bytesperline == 0 && tagoffset)
                    text += (i + offsetstart).ToString("X6") + " | ";
                if (i % bytesperline == 0 && tagsuboffset)
                    text += i.ToString("X6") + " | ";
                text += array[i].ToString("X2") + " ";
            }
            return text;
        }
        public static int GetStringHeight(string text, int containerWidth, Font font)
        {
            int height = 0;
            return height;
        }

        #endregion
    }
}
