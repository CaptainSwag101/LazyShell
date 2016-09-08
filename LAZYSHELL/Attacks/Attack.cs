using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LazyShell.Properties;

namespace LazyShell.Attacks
{
    [Serializable()]
    public class Attack : Element
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
        public char[] Name { get; set; }
        public byte HitRate { get; set; }
        public byte AttackLevel { get; set; }
        public bool EffectMute { get; set; }
        public bool EffectSleep { get; set; }
        public bool EffectPoison { get; set; }
        public bool EffectFear { get; set; }
        public bool EffectMushroom { get; set; }
        public bool EffectScarecrow { get; set; }
        public bool EffectInvincible { get; set; }
        public bool UpAttack { get; set; }
        public bool UpDefense { get; set; }
        public bool UpMagicAttack { get; set; }
        public bool UpMagicDefense { get; set; }
        public bool InstantDeath { get; set; }
        public bool NoDamageA { get; set; }
        public bool NoDamageB { get; set; }
        public bool HideDigits { get; set; }

        #endregion

        // Constructor
        public Attack(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            Name = new char[13];
            for (int i = 0; i < Name.Length; i++)
                Name[i] = (char)rom[(Index * 13) + 0x3959F4 + i];
            int offset = (Index * 4) + 0x391226;
            int temp = rom[offset++];
            AttackLevel = (byte)(temp & 0x07);
            InstantDeath = (temp & 0x08) == 0x08;
            NoDamageA = (temp & 0x10) == 0x10;
            HideDigits = (temp & 0x20) == 0x20;
            NoDamageB = (temp & 0x40) == 0x40;
            HitRate = rom[offset++];
            // status effect
            Status status = (Status)rom[offset++];
            EffectMute = (status & Status.Mute) == Status.Mute;
            EffectSleep = (status & Status.Sleep) == Status.Sleep;
            EffectPoison = (status & Status.Poison) == Status.Poison;
            EffectFear = (status & Status.Fear) == Status.Fear;
            EffectMushroom = (status & Status.Mushroom) == Status.Mushroom;
            EffectScarecrow = (status & Status.Scarecrow) == Status.Scarecrow;
            EffectInvincible = (status & Status.Invincible) == Status.Invincible;
            // status change
            temp = rom[offset++];
            UpMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            UpAttack = (temp & 0x10) == 0x10;			// Attack
            UpMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            UpDefense = (temp & 0x40) == 0x40;			// Defense
        }
        public void WriteToROM()
        {
            Bits.SetChars(rom, 0x3959F4 + (Index * 13), Name);
            //
            int offset = (Index * 4) + 0x391226;
            rom[offset] = AttackLevel;
            Bits.SetBit(rom, offset, 3, InstantDeath);
            Bits.SetBit(rom, offset, 4, NoDamageA);
            Bits.SetBit(rom, offset, 5, HideDigits);
            Bits.SetBit(rom, offset++, 6, NoDamageB);
            //
            rom[offset++] = HitRate;
            Bits.SetBit(rom, offset, 0, EffectMute);
            Bits.SetBit(rom, offset, 1, EffectSleep);
            Bits.SetBit(rom, offset, 2, EffectPoison);
            Bits.SetBit(rom, offset, 3, EffectFear);
            Bits.SetBit(rom, offset, 5, EffectMushroom);
            Bits.SetBit(rom, offset, 6, EffectScarecrow);
            Bits.SetBit(rom, offset++, 7, EffectInvincible);
            //
            Bits.SetBit(rom, offset, 3, UpMagicAttack);
            Bits.SetBit(rom, offset, 4, UpAttack);
            Bits.SetBit(rom, offset, 5, UpMagicDefense);
            Bits.SetBit(rom, offset, 6, UpDefense);
        }
        // Inherited
        public override void Clear()
        {
            Bits.Fill(Name, '\x20');
            HitRate = 0;
            AttackLevel = 0;
            EffectMute = false;
            EffectSleep = false;
            EffectPoison = false;
            EffectFear = false;
            EffectMushroom = false;
            EffectScarecrow = false;
            EffectInvincible = false;
            UpAttack = false;
            UpDefense = false;
            UpMagicAttack = false;
            UpMagicDefense = false;
            InstantDeath = false;
            NoDamageA = false;
            NoDamageB = false;
            HideDigits = false;
        }

        #endregion
    }
}
