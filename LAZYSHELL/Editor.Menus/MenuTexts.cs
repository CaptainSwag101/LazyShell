using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class MenuTexts
    {
        private int index; public int Index { get { return index; } set { index = value; } }
        [NonSerialized()]
        private TextHelperReduced textHelper = TextHelperReduced.Instance;
        public char[] MenuText;
        public bool Error;
        public int Length { get { return MenuText.Length; } }
        public int Offset;
        public string GetMenuString(bool textView)
        {
            if (!this.Error)
                return new string(textHelper.DecodeText(MenuText, !textView, 1, Keystrokes));
            else
                return new string(MenuText);
        }
        public void SetMenuString(string value, bool textView)
        {
            MenuText = textHelper.EncodeText(value.ToCharArray(), !textView, 1, Keystrokes);
        }
        public StringCollection Keystrokes
        {
            get
            {
                if (Dialogue)
                    return Settings.Default.Keystrokes;
                else
                    return Settings.Default.KeystrokesMenu;
            }
        }
        public bool Dialogue
        {
            get
            {
                if (index == 24 ||
                    (index >= 33 && index <= 40) ||
                    index == 53 ||
                    index == 54 ||
                    index == 60 ||
                    index == 61 ||
                    (index >= 64 && index <= 75) ||
                    (index >= 88 && index <= 108) ||
                    index == 117)
                    return true;
                return false;
            }
        }
        public MenuTexts(int index)
        {
            this.index = index;
            int offset = Bits.GetShort(Model.Data, index * 2 + 0x3EEF00) + 0x3EF000;
            List<char> characters = new List<char>();
            while (Model.Data[offset] != 0)
                characters.Add((char)Model.Data[offset++]);
            MenuText = characters.ToArray();
        }
        public Size Size
        {
            get
            {
                int[] palette = Model.FontPaletteMenu.Palette;
                MenuTextPreview preview = new MenuTextPreview();
                int[] pixels = preview.GetPreview(Model.FontMenu, palette, MenuText, false, false);
                Rectangle rectangle = Do.Crop(pixels, 256, 12);
                return new Size(rectangle.Width, rectangle.Height);
            }
        }
        public Rectangle Rectangle(int x, int y)
        {
            Size size = Size;
            return new Rectangle(x, y, size.Width, size.Height);
        }
        public override string ToString()
        {
            return new string(MenuText);
        }
    }
}
