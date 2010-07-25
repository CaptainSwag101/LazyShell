using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    public class AnimationScript
    {
        private int type; public int Type { get { return this.type; } }
        private int index; 
        public int Index { get { return this.index; } set { this.index = value; } }
        private int baseOffset; public int BaseOffset { get { return this.baseOffset; } set { this.baseOffset = value; } }

        private ArrayList commands; public ArrayList Commands { get { if (this.commands == null) this.commands = new ArrayList(); return this.commands; } set { this.commands = value; } }

        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        public byte aMem = 0;
        public byte AMem
        {
            get { return this.aMem; }
            set
            {
                //byte temp = aMem;
                this.aMem = value;
                //this.aMem = temp;
            }
        }

        #region Behavior Offsets
        private int[] behaviorOffsets = new int[]
        {
            0x3505C6,0x3505DA,0x350635,0x350669,0x3506A7,0x350737,0x350790,0x350796,
            0x3507A2,0x3507E9,0x350830,0x35086A,0x3508A4,0x3508BA,0x350916,0x35091C,
            0x350928,0x35096F,0x35099D,0x35099F,0x3509D5,0x350A38,0x350A3E,0x350A55,
            0x350A9C,0x350ABD,0x350AF7,0x350B2D,0x350BB7,0x350BF3,0x350BF9,0x350BFD,
            0x350C14,0x350C5B,0x350C9E,0x350CDC,0x350D22,0x350D36,0x350D72,0x350D9D,
            0x350DA3,0x350DAF,0x350DED,0x350E38,0x350E4A,0x350E84,0x350E98,0x350EEE,
            0x350F1A,0x350F44,0x350F4A,0x350F56,0x350F6B,0x350F7A
        };
        #endregion

        public AnimationScript(byte[] data, int index, int type)
        {
            this.data = data;
            this.index = index;
            this.type = type;

            InitializeAnimationScript(index, type);
        }
        private void InitializeAnimationScript(int animationNum, int type)
        {
            int bank = 0x350000, start = 0;
            switch (type)
            {
                case 1: start = 0x1026; break;
                case 2: start = 0x2128; break;
                case 3: start = 0x1493; break;
                case 4: start = 0xC761; break;
                case 5: start = 0xC992; break;
                case 6: start = 0xECA2; break;
                case 7: start = 0x6004; bank = 0x3A0000; break;
            }
            if (type == 0)
                baseOffset = behaviorOffsets[animationNum];
            else
                baseOffset = bank + Bits.GetShort(data, bank + start + animationNum * 2);
            ParseAnimationScript(data);
        }
        private void ParseAnimationScript(byte[] data)
        {
            int offset = baseOffset, len = 0;
            AnimationScriptCommand temp;
            if (type == 7)
            {
                offset = baseOffset + 2;
                if (index == 22) offset = baseOffset + 4;
                if (index == 70) offset = baseOffset + 6;
                if (index == 85) offset = baseOffset + 6;
            }

            if (this.commands == null)
                this.commands = new ArrayList();

            while (offset < data.Length)
            {
                if (offset == 0x3A6BA1)   // another annoying rare case
                    break;

                len = GetAnimationOpcodeLength(data, offset);
                temp = new AnimationScriptCommand(data, Bits.GetByteArray(data, offset, len), offset, this, null);

                switch (temp.Opcode)
                {
                    case 0x20:
                    case 0x21: if ((temp.Option & 0x0F) == 0) aMem = temp.AnimationData[2]; break;
                    case 0x2C:
                    case 0x2D: if ((temp.Option & 0x0F) == 0) aMem += temp.AnimationData[2]; break;
                    case 0x2E:
                    case 0x2F: if ((temp.Option & 0x0F) == 0) aMem -= temp.AnimationData[2]; break;
                    case 0x30:
                    case 0x31: if ((temp.Option & 0x0F) == 0) aMem++; break;
                    case 0x32:
                    case 0x33: if ((temp.Option & 0x0F) == 0) aMem--; break;
                    case 0x34:
                    case 0x35: if ((temp.Option & 0x0F) == 0) aMem = 0; break;
                    case 0x6A:
                    case 0x6B: if ((temp.Option & 0x0F) == 0) aMem = (byte)(temp.AnimationData[2] - 1); break;
                }

                commands.Add(temp);

                if (data[offset] == 0x07 || // end animation packet
                    data[offset] == 0x09 || // jump directly to address (thus ending this)
                    data[offset] == 0x11 || // end subroutine
                    data[offset] == 0x5E)   // end sprite subroutine
                    break;

                offset += len;
            }
        }
        public void RefreshAnimationScript()
        {
            this.commands = null;
            InitializeAnimationScript(this.index, this.type);
        }
        public int GetAnimationOpcodeLength(byte[] data, int offset)
        {
            byte opcode, option;
            int len;

            opcode = data[offset];
            if (data.Length - offset > 1)
                option = data[offset + 1];
            else
                option = 0;

            len = A_ScriptEnums.GetAnimationOpcodeLength(opcode, option);

            return len;
        }
        private int StrChr(int offset, byte chr, int maxLen, byte[] data)
        {
            int i = 0;

            while (data[offset + i] != chr && i < maxLen)
                i++;

            return i;
        }
        private int StrShrt(int offset, ushort chr, int maxLen, byte[] data)
        {
            int i = 0;

            while (Bits.GetShort(data, offset + i) != chr && i < maxLen)
                i++;

            return i;
        }
        #region Management Methods
        public void Modify(AnimationScriptCommand asc)
        {
            AnimationScriptCommand cmd;
            for (int i = 0; i < this.commands.Count; i++)
            {
                cmd = (AnimationScriptCommand)this.commands[i];
                if (asc.InternalOffset == cmd.InternalOffset)
                {
                    byte[] temp = new byte[asc.AnimationData.Length];
                    asc.AnimationData.CopyTo(temp, 0);
                    cmd = new AnimationScriptCommand(data, temp, asc.Offset, this, null);
                }
                cmd.Modify(asc);
            }
        }
        public void Add(AnimationScriptCommand asc)
        {
            commands.Add(asc);
        }
        #endregion
    }
}
