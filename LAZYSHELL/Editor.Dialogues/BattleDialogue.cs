using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class BattleDialogue : Element
    {
        /*****************************************************************************
         * Variables
         ****************************************************************************/
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        private int index;
        private char[] text;
        private int offset;
        private bool error = false;
        private int caretPositionSymbol;
        private int caretPositionNotSymbol;
        [NonSerialized()]
        private TextHelperReduced textHelperReduced;
        private int pointerOffset;
        private int baseOffset;

        /*****************************************************************************
         * Get Methods
         * **************************************************************************/
        public string GetText(bool symbols)
        {
            if (!error)
                return new string(textHelperReduced.DecodeText(text, symbols, 0, Settings.Default.Keystrokes));
            else
                return new string(text);
        }
        public int Offset { get { return offset; } set { offset = value; } }
        public int Length { get { return text.Length; } }
        public char[] Text { get { return text; } }
        public int GetCaretPosition(bool symbol)
        {
            if (symbol)
                return caretPositionSymbol;
            else
                return caretPositionNotSymbol;
        }

        /*****************************************************************************
         * Set Methods
         * **************************************************************************/
        public bool SetText(string value, bool symbols) // Text with byte values, not symbols
        {
            this.text = textHelperReduced.EncodeText(value.ToCharArray(), symbols, 0, Settings.Default.Keystrokes);
            this.error = textHelperReduced.Error;
            return !error;
        }
        public void SetCaretPosition(int value, bool symbol)
        {
            if (symbol)
                this.caretPositionSymbol = value;
            else
                this.caretPositionNotSymbol = value;
        }


        // Constructor
        public BattleDialogue(byte[] data, int index, int pointerOffset, int baseOffset)
        {
            this.data = data;
            this.index = index;
            this.pointerOffset = pointerOffset;
            this.baseOffset = baseOffset;
            this.textHelperReduced = TextHelperReduced.Instance;
            Initialize(data);
        }

        // Dissasembler
        private void Initialize(byte[] data)
        {
            text = GetText(data);
        }

        public string GetStub()
        {
            string temp = this.GetText(true);
            if (temp.Length > 40)
            {
                temp = temp.Substring(0, 37);
                return temp + "...";
            }
            else
                return temp;
        }
        public ushort Assemble(ushort offset)
        {
            Bits.SetShort(data, pointerOffset + index * 2, offset);
            this.offset = offset + baseOffset;
            //
            Bits.SetCharArray(data, this.offset, text);
            return (ushort)text.Length;
        }
        private char[] GetText(byte[] data)
        {
            this.offset = Bits.GetShort(data, pointerOffset + index * 2) + baseOffset;

            int count = this.offset;
            int len = 0;
            byte ptr = 0x01;

            while (ptr != 0x00 && ptr != 0x06)
            {
                ptr = data[count];
                if (ptr == 0x0B || ptr == 0x0D || ptr == 0x1C)
                {
                    len++;
                    count++;
                }
                len++;
                count++;
            }

            char[] battleDialogue = new char[len];

            for (int i = 0; i < len; i++)
            {
                battleDialogue[i] = (char)data[this.offset + i];
            }

            return battleDialogue;
        }
        public override void Clear()
        {
            text = new char[0];
        }
        public override string ToString()
        {
            return "[" + index.ToString("d3") + "]  " + GetText(true);
        }
    }
}