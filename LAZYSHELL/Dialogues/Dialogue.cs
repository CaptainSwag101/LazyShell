using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LAZYSHELL.Dialogues
{
    [Serializable()]
    public class Dialogue : Element
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
        private ParserMain parser;
        private bool error = false;

        // Properties
        public char[] Text { get; set; }
        public int Length
        {
            get { return Text.Length; }
        }
        public int Offset { get; set; }
        /// <summary>
        /// The dialogue's unmodified pointer in the ROM buffer.
        /// </summary>
        public int Pointer
        {
            get { return Bits.GetShort(rom, 0x37E000 + Index * 2); }
        }

        #endregion

        // Constructor
        public Dialogue(int index)
        {
            this.Index = index;
            this.parser = ParserMain.Instance;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int pointer = Bits.GetShort(rom, 0x37E000 + (Index * 2));

            /* This operation checks if pointer points to beyond capacity of the dialogue in the bank.
             * If it is, then it sets the pointer to the last dialogue, thus making it a duplicate.
             * This fixes the problems with dialogues 3066 to 3071. */

            // Get pointer to dialogue in bank
            int secPtr;
            if (Index >= 0xC00)
                secPtr = Bits.GetShort(rom, 0x240000 + (((Index - 0xC00) >> 8) & 0xFE));
            else if (Index >= 0x800)
                secPtr = Bits.GetShort(rom, 0x230000 + (((Index - 0x800) >> 8) & 0xFE));
            else
                secPtr = Bits.GetShort(rom, 0x220000 + ((Index >> 8) & 0xFE));

            // Total size of the pointer table in the respective bank
            int ptrTblSize = Index >= 0x800 ? 4 : 8;


            // Set pointer of dialogue
            pointer = pointer + secPtr - ptrTblSize;
            Bits.SetShort(rom, 0x37E000 + (Index * 2), (ushort)pointer);

            //
            if (Index >= 0x800)
            {
                if (pointer >= 0xF2D1 - 4)
                    Bits.SetShort(rom, 0x37E000 + (Index * 2), (ushort)(Bits.GetShort(rom, 0x37E000 + ((Index - 1) * 2))));
            }
            else
            {
                if (pointer >= 0xFD18 - 8)
                    Bits.SetShort(rom, 0x37E000 + (Index * 2), (ushort)(Bits.GetShort(rom, 0x37E000 + ((Index - 1) * 2))));
            }

            // Simplify all of the section pointers
            if (Index == 0xFFF)
            {
                Bits.SetShort(rom, 0x220002, 0x0008);
                Bits.SetShort(rom, 0x220004, 0x0008);
                Bits.SetShort(rom, 0x220006, 0x0008);
                Bits.SetShort(rom, 0x230002, 0x0004);
                Bits.SetShort(rom, 0x240002, 0x0004);
            }

            // Set this offset
            if (Index >= 0x0C00)
                this.Offset = this.Pointer + 4 + 0x240000;
            else if (Index >= 0x0800)
                this.Offset = this.Pointer + 4 + 0x230000;
            else
                this.Offset = this.Pointer + 8 + 0x220000;

            // Get total length of text
            int offset = this.Offset;
            int length = 0;
            byte symbol = 0x01;
            while (symbol != 0x00 && symbol != 0x06)
            {
                symbol = rom[offset];

                // Values with a parameter
                if (symbol == 0x0B || symbol == 0x0D || symbol == 0x1C)
                {
                    length++;
                    offset++;
                }
                length++;
                offset++;
            }

            // Finally, initialize the text
            this.Text = new char[length];
            for (int i = 0; i < length; i++)
                this.Text[i] = (char)rom[this.Offset + i];
        }
        public void WriteToROM(int offset)
        {
            WriteToROM(ref offset);
        }
        public void WriteToROM(ref int offset)
        {
            if (Index >= 2048)
                Bits.SetShort(rom, 0x37E000 + Index * 2, (ushort)(offset - 4));
            else
                Bits.SetShort(rom, 0x37E000 + Index * 2, (ushort)(offset - 8));
            this.Offset = offset;

            // Write the dialogue to ROM
            Bits.SetChars(rom, this.Offset, Text);

            // Add dialogue length to offset
            offset += Text.Length;
        }

        // Text retrieval/modification
        public string GetText(bool byteView, string[] tables)
        {
            if (!error)
                return new string(parser.Decode(Text, byteView, tables));
            else
                return new string(Text);
        }
        public string GetStub(bool byteView, string[] tables)
        {
            string temp = GetText(byteView, tables);
            if (temp.Length > 40)
            {
                temp = temp.Substring(0, 37);
                return temp + "...";
            }
            else
                return temp;
        }
        public bool SetText(string value, bool byteView, string[] tables)
        {
            this.Text = parser.Encode(value.ToCharArray(), byteView, tables);
            this.error = parser.Error;
            return !error;
        }

        // Inherited
        public override void Clear()
        {
            Text = new char[0];
        }

        #endregion
    }
}
