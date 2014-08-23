using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Monsters
{
    [Serializable()]
    public class BattleScript : Element
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

        // Binary data
        public byte[] Buffer { get; set; }

        // Commands
        public List<Command> Commands { get; set; }

        /// <summary>
        /// The total length of the script's binary data.
        /// </summary>
        public int Length
        {
            get { return Buffer.Length; }
        }

        #endregion

        // Constructor
        public BattleScript(int index)
        {
            this.Index = index;
            ReadFromROM(index);
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM(int index)
        {
            int bank = 0x390000;
            int offset = Bits.GetShort(rom, bank + 0x30AA + (index * 2));
            int length = GetLength(bank + offset);
            this.Buffer = Bits.GetBytes(rom, bank + offset, length);
            //
            ParseScript();
        }
        public void WriteToROM(ref int offset)
        {
            Bits.SetBytes(rom, offset, Buffer);
            offset += Buffer.Length;
        }

        // class functions and accessors
        public void ParseScript()
        {
            int offset = 0, length = 0;
            if (Buffer.Length > 0 && this.Commands == null)
                this.Commands = new List<Command>();
            //
            while (offset < Buffer.Length)
            {
                length = Lists.BattleLengths[Buffer[offset]];
                var bsc = new Command(Bits.GetBytes(Buffer, offset, length));
                Commands.Add(bsc);
                offset += length;
            }
        }
        private int GetLength(int offset)
        {
            int totalLength = 0;
            bool endAll = false;
            bool endIf = false;
            while (!endAll)
            {
                byte opcode = rom[offset];
                if (opcode == 0xFF)
                {
                    if (!endIf)
                        endIf = true;
                    else
                        endAll = true;
                }
                int length = Lists.BattleLengths[opcode];
                totalLength += length;
                offset += length;
            }
            return totalLength;
        }
        public void Add(Command bsc)
        {
            this.Commands.Add(bsc);
        }
        public void Insert(int index, Command bsc)
        {
            this.Commands.Insert(index, bsc);
        }
        public void RemoveAt(int index)
        {
            this.Commands.RemoveAt(index);
        }
        public void Reverse(int index, int count)
        {
            this.Commands.Reverse(index, count);
        }

        // Universal functions
        public override void Clear()
        {
            this.Commands.Clear();
            Command bsc = new Command(new byte[] { 0xFF });
            this.Commands.Add(bsc);
            this.Commands.Add(bsc);
            Buffer = new byte[2] { 0xFF, 0xFF };
        }

        #endregion
    }
}