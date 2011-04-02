using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.ScriptsEditor
{
    [Serializable()]
    public class BattleScript : Element
    {
        //pointers are stored 0x3930AA - 0x3932A9
        //battlescripts are stored 0x3932AA - 0x3959F3 cannot go past 0x3959F3 - 0x274A in total len
        [NonSerialized()]
        private byte[] data; 
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index; } set { index = value;} }
        private byte[] script; public byte[] Script { get { return script; } set { script = value; } }
        public int ScriptLength { get { return script.Length; } }
        
        private int index; public int MonsterNum { get { return index; } }

        private int commandIndex = 0; public int CommandIndex { get { return commandIndex; } set { commandIndex = value; } }
        public byte[] NextCommand()
        {
            try
            {
                int len = GetOpcodeLength(script[commandIndex]);
                commandIndex += len;

                return Bits.GetByteArray(script, commandIndex - len, len);
            }
            catch
            {
                throw new Exception("No Battle Commands Left");
            }
        }
        public BattleScript(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            InitializeBattleScript(index);
        }
        private void InitializeBattleScript(int index)
        {
            int bank = 0x390000;
            ushort offset = Bits.GetShort(data, bank + 0x30AA + (index * 2));

            int length = CalculateScriptLength(bank + offset);

            script = Bits.GetByteArray(data, bank + offset, length);
        }

        private int CalculateScriptLength(int offset)
        {
            int len = 0;
            int totalLength = 0;
            bool endAll = false;
            bool endIf = false;
            byte opcode;

            while (!endAll)
            {
                opcode = data[offset];
                if (opcode == 0xFF)
                {
                    if (!endIf)
                        endIf = true;
                    else
                        endAll = true;
                }

                len = GetOpcodeLength(opcode);
                
                totalLength += len;
                offset += len;
            }

            return totalLength;
        }
        private static int GetOpcodeLength(byte opcode)
        {
            if (opcode < 0xE0 ||
                opcode == 0xEC ||
                opcode == 0xFB ||
                opcode == 0xFD ||
                opcode == 0xFE ||
                opcode == 0xFF)
                return 1;
            else if (opcode == 0xE2 ||
                opcode == 0xE3 ||
                opcode == 0xE5 ||
                opcode == 0xE8 ||
                opcode == 0xED ||
                opcode == 0xEF ||
                opcode == 0xF1)
                return 2;
            else if (opcode == 0xE6 ||
                opcode == 0xEB ||
                opcode == 0xF2 ||
                opcode == 0xF3)
                return 3;
            else if (opcode == 0xE0 ||
                opcode == 0xE7 ||
                opcode == 0xEA ||
                opcode == 0xF0 ||
                opcode == 0xF4 ||
                opcode == 0xFC)
                return 4;
            else
                MessageBox.Show("Invalid Opcode: " + opcode.ToString());

            throw new Exception("Invalid Opcode: " + opcode.ToString());
        }

        public ushort Assemble(int offset)
        {
            Bits.SetByteArray(data, offset, script);
            return (ushort)script.Length;
        }
        public override void Clear()
        {
            script = new byte[2] { 0xFF, 0xFF };
        }
    }
}