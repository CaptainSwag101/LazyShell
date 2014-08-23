using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using LAZYSHELL.Properties;
using LAZYSHELL.Dialogues;

namespace LAZYSHELL.Menus
{
    [Serializable()]
    public class MenuText
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public int Index { get; set; }

        // Parsing
        [NonSerialized()]
        private ParserReduced parserReduced;
        public bool Error { get; set; }
        public string[] Keystrokes
        {
            get
            {
                if (Dialogue)
                    return Lists.Keystrokes;
                else
                    return Lists.KeystrokesMenu;
            }
        }

        // Properties
        public int X { get; set; }
        public char[] Text { get; set; }
        public int Offset { get; set; }

        // public accessors
        public int Length
        {
            get { return Text.Length; }
        }
        public bool Dialogue
        {
            get
            {
                if (Index == 24 ||
                    (Index >= 33 && Index <= 40) ||
                    Index == 53 ||
                    Index == 54 ||
                    Index == 60 ||
                    Index == 61 ||
                    (Index >= 64 && Index <= 75) ||
                    (Index >= 88 && Index <= 108) ||
                    Index == 117)
                    return true;
                return false;
            }
        }
        public Size Size
        {
            get
            {
                int[] palette = Fonts.Model.Palette_Menu.Palette;
                MenuTextPreview preview = new MenuTextPreview();
                int[] pixels = preview.GetPreview(Fonts.Model.Menu, palette, Text, false, false);
                Rectangle rectangle = Do.Crop(pixels, 256, 12);
                return new Size(rectangle.Width, rectangle.Height);
            }
        }

        #endregion

        // Constructor
        public MenuText(int index)
        {
            this.Index = index;
            this.parserReduced = ParserReduced.Instance;
            //
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = Bits.GetShort(rom, Index * 2 + 0x3EEF00) + 0x3EF000;
            List<char> characters = new List<char>();
            while (rom[offset] != 0)
                characters.Add((char)rom[offset++]);
            Text = characters.ToArray();
            //
            switch (Index)
            {
                case 14: X = (rom[0x03328E] & 0x3F) / 2; break;
                case 15: X = (rom[0x03327E] & 0x3F) / 2; break;
                case 16: X = (rom[0x033282] & 0x3F) / 2; break;
                case 17: X = (rom[0x033286] & 0x3F) / 2; break;
                case 18: X = (rom[0x03328A] & 0x3F) / 2; break;
                case 19: X = (rom[0x03327A] & 0x3F) / 2; break;
            }
        }

        // Text modification
        public string GetText(bool textView)
        {
            if (!this.Error)
                return new string(parserReduced.Decode(Text, !textView, 0, Keystrokes));
            else
                return new string(Text);
        }
        public void SetText(string value, bool textView)
        {
            Text = parserReduced.Encode(value.ToCharArray(), !textView, 0, Keystrokes);
        }

        /// <summary>
        /// Returns a rectangle created from this text's image size and
        /// a specified coordinate pair.
        /// </summary>
        /// <param name="x">The X coord of the rectangle.</param>
        /// <param name="y">The Y coord of the rectangle.</param>
        /// <returns></returns>
        public Rectangle Rectangle(int x, int y)
        {
            Size size = Size;
            return new Rectangle(x, y, size.Width, size.Height);
        }

        // Override
        public override string ToString()
        {
            return new string(Text);
        }

        #endregion
    }
}
