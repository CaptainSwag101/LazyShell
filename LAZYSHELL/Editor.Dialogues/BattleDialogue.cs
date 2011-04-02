using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

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
        public override int Index { get { return index; } set { index = value;} }
        private int index;
        private char[] battleDialogue;
        private int battleDialogueOffset;
        private bool error = false;
        private int caretPositionSymbol;
        private int caretPositionNotSymbol;
        [NonSerialized()]
        private TextHelperReduced textHelperReduced;
        private int type;

        /*****************************************************************************
         * Get Methods
         * **************************************************************************/
        public int BattleDialogueNum { get { return index; } set { index = value; } }
        public string GetBattleDialogue(bool symbols) { if (!error) return new string(textHelperReduced.DecodeText(battleDialogue, symbols, 0)); else return new string(battleDialogue); }
        public int BattleDialogueOffset { get { return battleDialogueOffset; } set { battleDialogueOffset = value; } }
        public int BattleDialogueLen { get { return battleDialogue.Length; } }
        public char[] RawBattleDialogue { get { return battleDialogue; } }
        public int GetCaretPosition(bool symbol) { if (symbol) return caretPositionSymbol; else return caretPositionNotSymbol; }

        /*****************************************************************************
         * Set Methods
         * **************************************************************************/
        public bool SetBattleDialogue(string value, bool symbols) // Text with byte values, not symbols
        {
            this.battleDialogue = textHelperReduced.EncodeText(value.ToCharArray(), symbols, 0);
            this.error = textHelperReduced.Error;
            return !error;
        }
        public void SetCaretPosition(int value, bool symbol) { if (symbol) this.caretPositionSymbol = value; else this.caretPositionNotSymbol = value; }


        // Constructor
        public BattleDialogue(byte[] data, int battleDialogueNum, int type)
        {
            this.data = data;
            this.index = battleDialogueNum;
            this.type = type;
            this.textHelperReduced = TextHelperReduced.Instance;
            InitializeBattleDialogue(data);
        }

        // Dissasembler
        private void InitializeBattleDialogue(byte[] data)
        {
            battleDialogue = GetBattleDialogue(data);
        }

        public string GetBattleDialogueStub()
        {
            string temp = this.GetBattleDialogue(true);
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
            if (type == 0)
            {
                Bits.SetShort(data, 0x396554 + index * 2, offset);
                battleDialogueOffset = offset + 0x390000;
            }
            else
            {
                Bits.SetShort(data, 0x3A26F1 + index * 2, offset);
                battleDialogueOffset = offset + 0x3A0000;
            }

            Bits.SetCharArray(data, battleDialogueOffset, battleDialogue);
            return (ushort)battleDialogue.Length;
        }
        private char[] GetBattleDialogue(byte[] data)
        {
            int battleDialoguePtr;

            if (type == 0)
            {
                battleDialoguePtr = Bits.GetShort(data, 0x396554 + index * 2);
                battleDialogueOffset = battleDialoguePtr + 0x390000;
            }
            else
            {
                battleDialoguePtr = Bits.GetShort(data, 0x3A26F1 + index * 2);
                battleDialogueOffset = battleDialoguePtr + 0x3A0000;
            }

            int count = battleDialogueOffset;
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
                battleDialogue[i] = (char)data[battleDialogueOffset + i];
            }

            return battleDialogue;
        }
        public override void Clear()
        {
            battleDialogue = new char[0];
        }
        public override string ToString()
        {
            return "[" + index.ToString("d3") + "]  " + GetBattleDialogue(true);
        }
    }
}