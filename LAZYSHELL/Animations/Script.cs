using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Animations
{
    public class Script
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public int Index { get; set; }

        // Properties
        /// <summary>
        /// The set of animation scripts this belongs to.
        /// </summary>
        public Set Set { get; set; }
        public List<Command> Commands { get; set; }

        /// <summary>
        /// Some commands that point to a subroutine use a pointer table to locate the subroutine's data. This value specifies 
        /// the index in the pointer table of the pointer whose value can be used to locate the subroutine's data.
        /// </summary>
        public byte AMEM { get; set; }
        public int BaseOffset { get; set; }

        /// <summary>
        /// The behavior offsets must be declared manually as there is no 
        /// pointer table referencing their locations in the ROM data.
        /// </summary>
        private readonly int[] behaviorOffsets = new int[]
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

        // Constructor
        public Script(int index, Set set)
        {
            this.Index = index;
            this.Set = set;
            ParseScript();
        }

        #region Methods

        /// <summary>
        /// Builds this script's command collection from the ROM buffer.
        /// </summary>
        public void ParseScript()
        {
            int bank = 0x350000;
            int start = 0;
            switch (Set)
            {
                case Set.MonsterSpell:
                    start = 0x1026; break;
                case Set.MonsterEntrance:
                    start = 0x2128; break;
                case Set.MonsterAttack:
                    start = 0x1493; break;
                case Set.Item:
                    start = 0xC761; break;
                case Set.AllySpell:
                    start = 0xC992; break;
                case Set.Weapon:
                    start = 0xECA2; break;
                case Set.BattleEvent:
                    start = 0x6004; bank = 0x3A0000; break;
            }
            if (Set == Set.MonsterBehavior)
                this.BaseOffset = this.behaviorOffsets[Index];
            else
                this.BaseOffset = bank + Bits.GetShort(rom, bank + start + Index * 2);
            //
            int offset = BaseOffset, length = 0;
            if (Set == Set.BattleEvent)
            {
                offset = BaseOffset + 2;
                if (Index == 22) offset = BaseOffset + 4;
                if (Index == 70) offset = BaseOffset + 6;
                if (Index == 85) offset = BaseOffset + 6;
            }
            this.Commands = new List<Command>();
            while (offset < rom.Length)
            {
                if (offset == 0x3A6BA1)   // Another annoying rare case
                    break;
                //
                if (offset + 1 < rom.Length)
                    length = ScriptEnums.GetCommandLength(rom[offset], rom[offset + 1]);
                else
                    length = ScriptEnums.GetCommandLength(rom[offset], 0);
                var command = new Command(Bits.GetBytes(rom, offset, length), offset, this, null);
                // Memory modification commands
                switch (command.Opcode)
                {
                    case 0x20:
                    case 0x21: if ((command.Param1 & 0x0F) == 0) AMEM = command.Data[2]; break;
                    case 0x2C:
                    case 0x2D: if ((command.Param1 & 0x0F) == 0) AMEM += command.Data[2]; break;
                    case 0x2E:
                    case 0x2F: if ((command.Param1 & 0x0F) == 0) AMEM -= command.Data[2]; break;
                    case 0x30:
                    case 0x31: if ((command.Param1 & 0x0F) == 0) AMEM++; break;
                    case 0x32:
                    case 0x33: if ((command.Param1 & 0x0F) == 0) AMEM--; break;
                    case 0x34:
                    case 0x35: if ((command.Param1 & 0x0F) == 0) AMEM = 0; break;
                    case 0x6A:
                    case 0x6B: if ((command.Param1 & 0x0F) == 0) AMEM = (byte)(command.Data[2] - 1); break;
                }
                Commands.Add(command);
                // Termination commands
                if (rom[offset] == 0x07 || // end animation packet
                    rom[offset] == 0x09 || // jump directly to address (thus ending this)
                    rom[offset] == 0x11 || // end subroutine
                    rom[offset] == 0x5E)   // end sprite subroutine
                    break;
                //
                offset += length;
            }
        }

        #endregion
    }
}
