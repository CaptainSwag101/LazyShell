using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Dialogues
{
    [Serializable()]
    public class BattleDialogue : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Parsing
        [NonSerialized()]
        private ParserReduced parser;
        private bool error = false;

        // Properties        
        private int baseOffset;
        private int pointerOffset;
        public int Offset { get; set; }
        public char[] Text { get; set; }
        public int Length
        {
            get { return Text.Length; }
        }

        #endregion

        // Constructor
        public BattleDialogue(int index, int pointerOffset, int baseOffset)
        {
            this.Index = index;
            this.pointerOffset = pointerOffset;
            this.baseOffset = baseOffset;
            this.parser = ParserReduced.Instance;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            this.Offset = Bits.GetShort(rom, pointerOffset + Index * 2) + baseOffset;
            int counter = this.Offset;
            int length = 0;
            int letter = -1;
            while (letter != 0x00 && letter != 0x06)
            {
                letter = rom[counter];
                if (letter == 0x0B || letter == 0x0D || letter == 0x1C)
                {
                    length++;
                    counter++;
                }
                length++;
                counter++;
            }
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
                text[i] = (char)rom[this.Offset + i];
            this.Text = text;
        }
        public void WriteToROM(ref int offset)
        {
            Bits.SetShort(rom, pointerOffset + Index * 2, offset);
            this.Offset = offset + baseOffset;
            //
            Bits.SetChars(rom, this.Offset, Text);
            offset += Text.Length;
        }

        // Text retrieval/modification
        public string GetText(bool byteView)
        {
            if (!error)
                return new string(parser.Decode(Text, byteView, 0, Lists.Keystrokes));
            else
                return new string(Text);
        }
        public string GetStub()
        {
            string text = this.GetText(true);
            if (text.Length > 40)
            {
                text = text.Substring(0, 37);
                return text + "...";
            }
            else
                return text;
        }
        public bool SetText(string value, bool byteView)
        {
            this.Text = parser.Encode(value.ToCharArray(), byteView, 0, Lists.Keystrokes);
            this.error = parser.Error;
            return !error;
        }

        // Inherited
        public override void Clear()
        {
            Text = new char[0];
        }

        // Override
        public override string ToString()
        {
            return "[" + Index.ToString("d3") + "]  " + GetText(true);
        }

        #endregion
    }
}