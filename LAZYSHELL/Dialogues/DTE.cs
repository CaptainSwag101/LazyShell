using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LazyShell.Dialogues
{
    [Serializable()]
    public class DTE : Element
    {
        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Inherited
        public override int Index { get; set; }
        // Private fields
        [NonSerialized()]
        private ParserMain parser;
        private bool error = false;
        private int caretPosByteView;
        private int caretPosTextView;
        // Properties
        public char[] Text { get; set; }
        public int Length
        {
            get { return Text.Length; }
        }
        public int Offset { get; set; }
        public int Pointer
        {
            get
            {
                return Bits.GetShort(rom, 0x249000 + Index * 2);
            }
        }
        public int Reference { get; set; }
        public int Parent { get; set; }
        public int Position { get; set; }
        // Constructor
        public DTE(int index)
        {
            this.Index = index;
            this.parser = ParserMain.Instance;
            ReadFromROM();
        }
        // Assemblers
        private void ReadFromROM()
        {
            this.Offset = Pointer + 0x249100;
            //
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
            length--;
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
                text[i] = (char)rom[this.Offset + i];
            this.Text = text;
        }
        public void WriteToROM(ref int pointer)
        {
            Bits.SetShort(rom, 0x249000 + Index * 2, pointer);
            int offset = pointer + 0x249100;
            char[] raw = new char[Text.Length + 1]; Text.CopyTo(raw, 0);
            Bits.SetChars(rom, offset, raw);
            pointer += raw.Length;
        }
        // class functions
        public string GetText(bool byteView)
        {
            if (!error)
                return new string(parser.Decode(Text, byteView, null));
            else
                return new string(Text);
        }
        public string GetStub(bool byteView)
        {
            string text = GetText(byteView);
            if (text.Length > 40)
            {
                text = text.Substring(0, 37);
                return text + "...";
            }
            else
                return text;
        }
        public int GetCaretPosition(bool byteView)
        {
            if (byteView)
                return caretPosByteView;
            else
                return caretPosTextView;
        }
        public bool SetText(string value, bool byteView)
        {
            this.Text = parser.Encode(value.ToCharArray(), byteView, null);
            this.error = parser.Error;
            return !error;
        }
        public void SetCaretPosition(int value, bool byteView)
        {
            if (byteView)
                this.caretPosByteView = value;
            else
                this.caretPosTextView = value;
        }
        // Universal functions
        public override void Clear()
        {
            Text = new char[0];
        }
    }
}
