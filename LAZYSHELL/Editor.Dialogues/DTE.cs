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
    public class DTE : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        private int index;
        private char[] dialogue;
        private int offset;
        private int pointer;
        private bool error = false;
        private int caretPosByteView;
        private int caretPosTextView;
        [NonSerialized()]
        private TextHelper textHelper;
        private int duplicateOfDialogue;
        private int withinDialogue;
        private int indexInDialogue;
        public int DuplicateOfDialogue { get { return duplicateOfDialogue; } set { duplicateOfDialogue = value; } }
        public int WithinDialogue { get { return withinDialogue; } set { withinDialogue = value; } }
        public int IndexInDialogue { get { return indexInDialogue; } set { indexInDialogue = value; } }
        public char[] Dialogue { get { return dialogue; } }
        public string GetDialogue(bool byteView)
        {
            if (!error)
                return new string(textHelper.DecodeText(dialogue, byteView, null));
            else
                return new string(dialogue);
        }
        public int Length { get { return dialogue.Length; } }
        public int Offset { get { return offset; } set { offset = value; } }
        public int Pointer
        {
            get
            {
                return Bits.GetShort(data, 0x249000 + index * 2);
            }
        }    // this is used to find duplicates
        public int GetCaretPosition(bool byteView)
        {
            if (byteView)
                return caretPosByteView;
            else
                return caretPosTextView;
        }
        public bool SetDialogue(string value, bool byteView)
        {
            this.dialogue = textHelper.EncodeText(value.ToCharArray(), byteView, null);
            this.error = textHelper.Error;
            return !error;
        }
        public void SetCaretPosition(int value, bool byteView)
        {
            if (byteView)
                this.caretPosByteView = value;
            else
                this.caretPosTextView = value;
        }
        // Constructor
        public DTE(byte[] data, int dialogueNum)
        {
            this.data = data;
            this.index = dialogueNum;
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
        private ushort SaveDialogue(ushort pointer)
        {
            Bits.SetShort(data, 0x249000 + index * 2, pointer);
            int offset = pointer + 0x249100;
            char[] raw = new char[dialogue.Length + 1]; dialogue.CopyTo(raw, 0);
            Bits.SetCharArray(data, offset, raw);
            return (ushort)raw.Length;
        }
        private char[] GetDialogue(byte[] data)
        {
            this.pointer = Bits.GetShort(data, 0x249000 + index * 2); // from pointer table
            this.offset = pointer + 0x249100;

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
            len--;
            char[] dialogue = new char[len];
            for (int i = 0; i < len; i++)
                dialogue[i] = (char)data[this.offset + i];
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

        public string GetDialogueStub(bool byteView)
        {
            string temp = GetDialogue(byteView);
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
            dialogue = new char[0];
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
