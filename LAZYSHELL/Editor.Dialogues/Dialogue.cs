using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class Dialogue : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        private int index;
        private char[] rawDialogue;
        private int dialogueOffset;
        private int dialoguePtr;
        private ushort[] dialoguePointer = new ushort[8];
        private bool error = false;
        private int caretPositionSymbol;
        private int caretPositionNotSymbol;
        [NonSerialized()]
        private TextHelper textHelper;

        private int duplicateDialogues; public int DuplicateDialogues { get { return duplicateDialogues; } set { duplicateDialogues = value; } }
        private int withinDialogues; public int WithinDialogues { get { return withinDialogues; } set { withinDialogues = value; } }
        private int withinDialoguesLocation; public int WithinDialoguesLocation { get { return withinDialoguesLocation; } set { withinDialoguesLocation = value; } }

        /*****************************************************************************
         * Get Methods
         * **************************************************************************/
        public char[] RawDialogue { get { return rawDialogue; } set { rawDialogue = value; } }
        public string GetDialogue(bool symbols)
        {
            if (!error)
                return new string(textHelper.DecodeText(rawDialogue, symbols, false));
            else 
                return new string(rawDialogue);
        } // Text with symbols, not byte values - Symbols true = {02} - false = {Line Break (press A)}
        public int DialogueLen { get { return rawDialogue.Length; } }
        public int DialogueOffset { get { return dialogueOffset; } set { dialogueOffset = value; } }
        public int DialoguePtr { get { return Bits.GetShort(data, 0x37E000 + index * 2); } }    // this is used to find duplicates
        public int GetCaretPosition(bool symbol) { if (symbol) return caretPositionSymbol; else return caretPositionNotSymbol; }
        /*****************************************************************************
         * Set Methods
         * **************************************************************************/
        public bool SetDialogue(string value, bool symbols)
        {
            this.rawDialogue = textHelper.EncodeText(value.ToCharArray(), symbols, false);
            this.error = textHelper.Error;
            return !error;
        } // Text with byte values, not symbols
        public void SetCaretPosition(int value, bool symbol) { if (symbol) this.caretPositionSymbol = value; else this.caretPositionNotSymbol = value; }

        // Constructor
        public Dialogue(byte[] data, int dialogueNum)
        {
            this.data = data;
            this.index = dialogueNum;
            this.textHelper = TextHelper.Instance;
            InitializeDialogue(data);
        }

        // Dissasembler
        private void InitializeDialogue(byte[] data)
        {
            rawDialogue = GetDialogue(data);
        }
        public ushort Assemble(ushort offset)
        {
            return SaveDialogue(offset);
        }
        private ushort SaveDialogue(ushort offset)
        {
            if (index >= 0x0800)
                Bits.SetShort(data, 0x37E000 + index * 2, (ushort)(offset - 4));
            else
                Bits.SetShort(data, 0x37E000 + index * 2, (ushort)(offset - 8));

            int dlgOffset = 0;

            // Select bank to save to
            if (index >= 0x0C00)
                dlgOffset = offset + 0x240000;
            else if (index >= 0x0800)
                dlgOffset = offset + 0x230000;
            else
                dlgOffset = offset + 0x220000;

            Bits.SetCharArray(data, dlgOffset, rawDialogue);
            return (ushort)rawDialogue.Length;
        }
        private char[] GetDialogue(byte[] data)
        {
            int secPtr = 0;
            int dlgPtr = 0;
            int numGroup = 0;
            int i = 0;

            if (index >= 0x800) numGroup = 4;
            else numGroup = 8;

            if (index >= 0xC00) secPtr = Bits.GetShort(data, 0x240000 + (((index - 0xC00) >> 8) & 0xFE));
            else if (index >= 0x800) secPtr = Bits.GetShort(data, 0x230000 + (((index - 0x800) >> 8) & 0xFE));
            else secPtr = Bits.GetShort(data, 0x220000 + ((index >> 8) & 0xFE));

            dlgPtr = Bits.GetShort(data, 0x37E000 + (index * 2));
            Bits.SetShort(data, 0x37E000 + (index * 2), (ushort)(dlgPtr + secPtr - numGroup));

            // checks if pointer points to beyond capacity of dialogue in bank
            // if it is, then it sets the pointer to the last dialogue, thus making it a duplicate
            // this fixes the problems with dialogues 3066 to 3071
            dlgPtr = Bits.GetShort(data, 0x37E000 + (index * 2));

            if (index >= 0x800)
            {
                if (dlgPtr >= 0xF2D1 - 4)
                    Bits.SetShort(data, 0x37E000 + (index * 2), (ushort)(Bits.GetShort(data, 0x37E000 + ((index - 1) * 2))));
            }
            else
            {
                if (dlgPtr >= 0xFD18 - 8)
                    Bits.SetShort(data, 0x37E000 + (index * 2), (ushort)(Bits.GetShort(data, 0x37E000 + ((index - 1) * 2))));
            }

            // simplify all of the section pointers
            if (index == 0xFFF)
            {
                Bits.SetShort(data, 0x220002, 0x0008);
                Bits.SetShort(data, 0x220004, 0x0008);
                Bits.SetShort(data, 0x220006, 0x0008);
                Bits.SetShort(data, 0x230002, 0x0004);
                Bits.SetShort(data, 0x240002, 0x0004);
            }
            /*********************************************/

            dialoguePtr = Bits.GetShort(data, 0x37E000 + index * 2); // from pointer table

            if (index >= 0x0C00) dialogueOffset = dialoguePtr + 4 + 0x240000;
            else if (index >= 0x0800) dialogueOffset = dialoguePtr + 4 + 0x230000;
            else dialogueOffset = dialoguePtr + 8 + 0x220000;

            int count = dialogueOffset;
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

            char[] dialogue = new char[len];

            for (i = 0; i < len; i++)
            {
                dialogue[i] = (char)data[dialogueOffset + i];
            }

            return dialogue;
        }

        public bool CompatibleWithGame()
        {
            for (int i = 0; i < rawDialogue.Length; i++)
            {
                if (rawDialogue[i] == '\x0b' || rawDialogue[i] == '\x0d')
                {
                    i += 2;
                }
                if (!IsValidCharTmp(rawDialogue[i]))
                    return false;
            }
            return true;
        }
        private bool IsValidCharTmp(char toTest)
        {
            if (toTest >= '\x00' && toTest <= '\x1C')
                return true;
            if (toTest >= '\x20' && toTest <= '\x5A')
                return true;
            if (toTest >= '\x61' && toTest <= '\x7A')
                return true;
            if (toTest >= '\x8E' && toTest <= '\x9C')
                return true;
            return false;
        }

        public string GetDialogueStub(bool textCodeFormat)
        {
            string temp = GetDialogue(textCodeFormat);
            if (temp.Length > 40)
            {
                temp = temp.Substring(0, 37);
                return temp + "...";
            }
            else
                return temp;
        }
        public override void Clear()
        {
            rawDialogue = new char[0];
        }
        public FileStream Serialize()
        {
            return null;
        }
        public void Deserialize()
        {
        }
    }
}
