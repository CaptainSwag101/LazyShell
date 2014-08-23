using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.LevelUps
{
    [Serializable()]
    public class LevelUp : Element
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
        // Properties
        public int ExpNeeded { get; set; }
        public Ally[] Allies { get; set; }

        #endregion

        // Constructor
        public LevelUp(int index)
        {
            this.Index = index;
            //
            ReadFromROM();
        }

        #region Methods

        // Assembler
        private void ReadFromROM()
        {
            int offset = 0x3A1AFF + ((Index - 2) * 2);
            ExpNeeded = Bits.GetShort(rom, offset);
            //
            this.Allies = new Ally[5];
            for (int i = 0; i < this.Allies.Length; i++)
                this.Allies[i] = new Ally(this.Index, i);
        }
        public void WriteToROM()
        {
            int offset = ((Index - 2) * 2) + 0x3A1AFF;
            Bits.SetShort(rom, offset, ExpNeeded);
            foreach (var ally in Allies)
                ally.WriteToROM();
        }
        // Inherited
        public override void Clear()
        {
            ExpNeeded = 0;
            foreach (var ally in Allies)
                ally.Clear();
        }

        #endregion

        [Serializable()]
        public class Ally
        {
            #region Variables

            // ROM buffer
            private byte[] rom
            {
                get { return Model.ROM; }
                set { Model.ROM = value; }
            }

            // Index
            public int IndexLevelUp { get; set; }
            public int IndexAlly { get; set; }

            // Properties - Status increments
            public byte HpPlus { get; set; }
            public byte AttackPlus { get; set; }
            public byte DefensePlus { get; set; }
            public byte MgAttackPlus { get; set; }
            public byte MgDefensePlus { get; set; }

            // Properties - Bonus increments
            public byte HpPlusBonus { get; set; }
            public byte AttackPlusBonus { get; set; }
            public byte DefensePlusBonus { get; set; }
            public byte MgAttackPlusBonus { get; set; }
            public byte MgDefensePlusBonus { get; set; }

            // Properties - Spell learned
            public byte SpellLearned { get; set; }

            #endregion

            // Constructor
            public Ally(int indexLevelUp, int indexAlly)
            {
                this.IndexLevelUp = indexLevelUp;
                this.IndexAlly = indexAlly;
                //
                ReadFromROM();
            }

            #region Methods

            // Read/write ROM
            private void ReadFromROM()
            {
                int offset = (IndexAlly * 3) + ((IndexLevelUp - 2) * 15) + 0x3A1B39;
                HpPlus = rom[offset++];
                AttackPlus = (byte)((rom[offset] & 0xF0) >> 4);
                DefensePlus = (byte)((rom[offset++] & 0x0F));
                MgAttackPlus = (byte)((rom[offset] & 0xF0) >> 4);
                MgDefensePlus = (byte)((rom[offset++] & 0x0F));
                //
                offset = (IndexAlly * 3) + ((IndexLevelUp - 2) * 15) + 0x3A1CEC;
                HpPlusBonus = rom[offset++];
                AttackPlusBonus = (byte)((rom[offset] & 0xF0) >> 4);
                DefensePlusBonus = (byte)((rom[offset++] & 0x0F));
                MgAttackPlusBonus = (byte)((rom[offset] & 0xF0) >> 4);
                MgDefensePlusBonus = (byte)((rom[offset++] & 0x0F));
                //
                SpellLearned = rom[IndexAlly + ((IndexLevelUp - 2) * 5) + 0x3A42F5];
                if (SpellLearned > 0x1F)
                    SpellLearned = 0x20;
            }
            public void WriteToROM()
            {
                int offset = (IndexAlly * 3) + ((IndexLevelUp - 2) * 15) + 0x3A1B39;
                Bits.SetByte(rom, offset++, HpPlus); offset++;
                Bits.SetByte(rom, offset++, (byte)((AttackPlus << 4) + DefensePlus));
                Bits.SetByte(rom, offset++, (byte)((MgAttackPlus << 4) + MgDefensePlus));
                //
                offset = (IndexAlly * 3) + ((IndexLevelUp - 2) * 15) + 0x3A1CEC;
                Bits.SetByte(rom, offset, HpPlusBonus); offset++;
                Bits.SetByte(rom, offset++, (byte)((AttackPlusBonus << 4) + DefensePlusBonus));
                Bits.SetByte(rom, offset++, (byte)((MgAttackPlusBonus << 4) + MgDefensePlusBonus));
                //
                if (SpellLearned == 0x20)
                    rom[IndexAlly + ((IndexLevelUp - 2) * 5) + 0x3A42F5] = 0xFF;
                else
                    rom[IndexAlly + ((IndexLevelUp - 2) * 5) + 0x3A42F5] = SpellLearned;
            }

            // Inherited
            public void Clear()
            {
                HpPlus = 0;
                AttackPlus = 0;
                DefensePlus = 0;
                MgAttackPlus = 0;
                MgDefensePlus = 0;
                HpPlusBonus = 0;
                AttackPlusBonus = 0;
                DefensePlusBonus = 0;
                MgAttackPlusBonus = 0;
                MgDefensePlusBonus = 0;
                SpellLearned = 32;
            }

            #endregion
        }
    }
}
