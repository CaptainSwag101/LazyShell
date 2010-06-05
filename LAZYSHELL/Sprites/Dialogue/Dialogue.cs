using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class Dialogue
    {
        private byte[] data; public byte[] Data { get { return data; } set { data = value; } }
        private int dialogueNum;
        private char[] dialogue;
        private int dialogueOffset;
        private int dialoguePtr;
        private ushort[] dialoguePointer = new ushort[8];
        private bool error = false;
        private int caretPositionSymbol;
        private int caretPositionNotSymbol;
        private TextHelper textHelper;

        private int duplicateDialogues; public int DuplicateDialogues { get { return duplicateDialogues; } set { duplicateDialogues = value; } }
        private int withinDialogues; public int WithinDialogues { get { return withinDialogues; } set { withinDialogues = value; } }
        private int withinDialoguesLocation; public int WithinDialoguesLocation { get { return withinDialoguesLocation; } set { withinDialoguesLocation = value; } }

        /*****************************************************************************
         * Get Methods
         * **************************************************************************/
        public int DialogueNum { get { return dialogueNum; } set { dialogueNum = value; } }
        public char[] RawDialogue { get { return dialogue; } }
        public string GetDialogue(bool symbols) { if (!error) return new string(textHelper.DecodeText(dialogue, symbols)); else return new string(dialogue); } // Text with symbols, not byte values - Symbols true = {02} - false = {Line Break (press A)}
        public int DialogueLen { get { return dialogue.Length; } }
        public int DialogueOffset { get { return dialogueOffset; } set { dialogueOffset = value; } }
        public int DialoguePtr { get { return BitManager.GetShort(data, 0x37E000 + dialogueNum * 2); } }    // this is used to find duplicates
        public int GetCaretPosition(bool symbol) { if (symbol) return caretPositionSymbol; else return caretPositionNotSymbol; }
        /*****************************************************************************
         * Set Methods
         * **************************************************************************/
        public bool SetDialogue(string value, bool symbols) { this.dialogue = textHelper.EncodeText(value.ToCharArray(), symbols); this.error = textHelper.Error; return !error; } // Text with byte values, not symbols
        public void SetCaretPosition(int value, bool symbol) { if (symbol) this.caretPositionSymbol = value; else this.caretPositionNotSymbol = value; }

        // Constructor
        public Dialogue(byte[] data, int dialogueNum)
        {
            this.data = data;
            this.dialogueNum = dialogueNum;
            this.textHelper = TextHelper.Instance;
            InitializeDialogue(data);
        }

        // Dissasembler
        private void InitializeDialogue(byte[] data)
        {
            dialogue = GetDialogue(data);
        }
        public ushort Assemble(ushort offset)
        {
            return SaveDialogue(offset);
        }
        private ushort SaveDialogue(ushort offset)
        {
            if (dialogueNum >= 0x0800) 
                BitManager.SetShort(data, 0x37E000 + dialogueNum * 2, (ushort)(offset - 4));
            else 
                BitManager.SetShort(data, 0x37E000 + dialogueNum * 2, (ushort)(offset - 8));

            int dlgOffset = 0;

            // Select bank to save to
            if (dialogueNum >= 0x0C00) 
                dlgOffset = offset + 0x240000;
            else if (dialogueNum >= 0x0800) 
                dlgOffset = offset + 0x230000;
            else 
                dlgOffset = offset + 0x220000;

            BitManager.SetByteArray(data, dlgOffset, strToByte(new string(dialogue)));
            return (ushort)dialogue.Length;
        }
        private char[] GetDialogue(byte[] data)
        {
            int secPtr = 0;
            int dlgPtr = 0;
            int numGroup = 0;
            int i = 0;

            if (dialogueNum >= 0x800) numGroup = 4;
            else numGroup = 8;

            if (dialogueNum >= 0xC00) secPtr = BitManager.GetShort(data, 0x240000 + (((dialogueNum - 0xC00) >> 8) & 0xFE));
            else if (dialogueNum >= 0x800) secPtr = BitManager.GetShort(data, 0x230000 + (((dialogueNum - 0x800) >> 8) & 0xFE));
            else secPtr = BitManager.GetShort(data, 0x220000 + ((dialogueNum >> 8) & 0xFE));

            dlgPtr = BitManager.GetShort(data, 0x37E000 + (dialogueNum * 2));
            BitManager.SetShort(data, 0x37E000 + (dialogueNum * 2), (ushort)(dlgPtr + secPtr - numGroup));

            // checks if pointer points to beyond capacity of dialogue in bank
            // if it is, then it sets the pointer to the last dialogue, thus making it a duplicate
            // this fixes the problems with dialogues 3066 to 3071
            dlgPtr = BitManager.GetShort(data, 0x37E000 + (dialogueNum * 2));

            if (dialogueNum >= 0x800)
            {
                if (dlgPtr >= 0xF2D1 - 4)
                    BitManager.SetShort(data, 0x37E000 + (dialogueNum * 2), (ushort)(BitManager.GetShort(data, 0x37E000 + ((dialogueNum - 1) * 2))));
            }
            else
            {
                if (dlgPtr >= 0xFD18 - 8)
                    BitManager.SetShort(data, 0x37E000 + (dialogueNum * 2), (ushort)(BitManager.GetShort(data, 0x37E000 + ((dialogueNum - 1) * 2))));
            }

            // simplify all of the section pointers
            if (dialogueNum == 0xFFF)
            {
                BitManager.SetShort(data, 0x220002, 0x0008);
                BitManager.SetShort(data, 0x220004, 0x0008);
                BitManager.SetShort(data, 0x220006, 0x0008);
                BitManager.SetShort(data, 0x230002, 0x0004);
                BitManager.SetShort(data, 0x240002, 0x0004);
            }
            /*********************************************/

            dialoguePtr = BitManager.GetShort(data, 0x37E000 + dialogueNum * 2); // from pointer table

            if (dialogueNum >= 0x0C00) dialogueOffset = dialoguePtr + 4 + 0x240000;
            else if (dialogueNum >= 0x0800) dialogueOffset = dialoguePtr + 4 + 0x230000;
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
            for (int i = 0; i < dialogue.Length; i++)
            {
                if (dialogue[i] == '\x0b' || dialogue[i] == '\x0d')
                {
                    i += 2;
                }
                if (!IsValidCharTmp(dialogue[i]))
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
        private string ByteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }
        private byte[] strToByte(string toByte)
        {
            byte[] arr = new byte[toByte.Length];
            char[] str = toByte.ToCharArray();

            for (int i = 0; i < str.Length; i++)
                arr[i] = (byte)str[i];
            return arr;
        }

        public void Clear()
        {
            dialogue = new char[0];
        }
    }
}
