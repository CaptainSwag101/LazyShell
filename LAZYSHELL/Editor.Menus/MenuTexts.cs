using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public string GetMenuString(bool textCodeFormat)
        {
            if (!this.Error)
                return new string(textHelper.DecodeText(MenuText, !textCodeFormat, 1, Keystrokes));
            else
                return new string(MenuText);
        }
        public void SetMenuString(string value, bool textCodeFormat)
        {
            MenuText = textHelper.EncodeText(value.ToCharArray(), !textCodeFormat, 1, Keystrokes);
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
        public override string ToString()
        {
            return new string(MenuText);
        }
    }
}
