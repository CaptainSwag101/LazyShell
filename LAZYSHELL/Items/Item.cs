using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Items
{
    [Serializable()]
    public class Item : Element
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

        #region Properties

        public char[] Name { get; set; }
        public ushort Price { get; set; }
        public sbyte Speed { get; set; }
        public sbyte Attack { get; set; }
        public sbyte Defense { get; set; }
        public sbyte MagicAttack { get; set; }
        public sbyte MagicDefense { get; set; }
        public byte AttackRange { get; set; }
        public byte AttackType { get; set; }
        public byte ElemAttack { get; set; }
        public bool HideDigits { get; set; }
        public byte InflictionAmount { get; set; }
        public bool EffectMute { get; set; }
        public bool EffectSleep { get; set; }
        public bool EffectPoison { get; set; }
        public bool EffectFear { get; set; }
        public bool EffectMushroom { get; set; }
        public bool EffectScarecrow { get; set; }
        public bool EffectInvincible { get; set; }
        public bool ChangeAttack { get; set; }
        public bool ChangeDefense { get; set; }
        public bool ChangeMagicAttack { get; set; }
        public bool ChangeMagicDefense { get; set; }
        public bool ElemNullIce { get; set; }
        public bool ElemNullFire { get; set; }
        public bool ElemNullThunder { get; set; }
        public bool ElemNullJump { get; set; }
        public bool ElemWeakIce { get; set; }
        public bool ElemWeakFire { get; set; }
        public bool ElemWeakThunder { get; set; }
        public bool ElemWeakJump { get; set; }
        public bool EquipMario { get; set; }
        public bool EquipToadstool { get; set; }
        public bool EquipBowser { get; set; }
        public bool EquipGeno { get; set; }
        public bool EquipMallow { get; set; }
        public bool UsageBattleMenu { get; set; }
        public bool UsageOverworldMenu { get; set; }
        public bool UsageReusable { get; set; }
        public bool UsageInstantDeath { get; set; }
        public bool RestoreFP { get; set; }
        public bool RestoreHP { get; set; }
        public bool TargetLiveAlly { get; set; }
        public bool TargetEnemy { get; set; }
        public bool TargetAll { get; set; }
        public bool TargetWoundedOnly { get; set; }
        public bool TargetOnePartyOnly { get; set; }
        public bool TargetNotSelf { get; set; }
        public byte ItemType { get; set; }
        public byte CursorBehavior { get; set; }
        public byte InflictFunction { get; set; }
        public byte WeaponStartLevel1 { get; set; }
        public byte WeaponStartLevel2 { get; set; }
        public byte WeaponEndLevel2 { get; set; }
        public byte WeaponEndLevel1 { get; set; }

        #endregion

        #region Description

        public char[] RawDescription { get; set; }
        public bool DescriptionError { get; set; }
        public Dialogues.ParserReduced parser
        {
            get { return Dialogues.ParserReduced.Instance; }
        }
        public int CaretPositionByteView { get; set; }
        public int CaretPositionTextView { get; set; }
        public bool SetDescription(string value, bool byteView)
        {
            this.RawDescription = parser.Encode(value.ToCharArray(), byteView, 1, Lists.KeystrokesDesc);
            this.DescriptionError = parser.Error;
            return !DescriptionError;
        }
        public string GetDescription(bool byteView)
        {
            if (!DescriptionError)
                return new string(parser.Decode(RawDescription, byteView, 1, Lists.KeystrokesDesc));
            else
                return new string(RawDescription);
        }

        #endregion

        #endregion

        // Constructor
        public Item(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            // Name
            Name = new char[15];
            for (int i = 0; i < Name.Length; i++)
                Name[i] = (char)rom[(Index * 15) + 0x3A46EF + i];

            // Description
            if (Index <= 0xB0)
                RawDescription = ParseDescription();
            else
                RawDescription = null;

            // Price
            int offset = (Index * 2) + 0x3A40F2;
            Price = Bits.GetShort(rom, offset);

            // Stats
            offset = (Index * 18) + 0x3A014D;
            byte temp = rom[offset++];
            ItemType = (byte)(temp & 3);

            // Item usage
            UsageBattleMenu = (temp & 0x08) == 0x08;	// Usable in battle
            UsageOverworldMenu = (temp & 0x10) == 0x10;	// Usable in overworld menu
            UsageReusable = (temp & 0x20) == 0x20;	    // Reusable
            UsageInstantDeath = (temp & 0x80) == 0x80;	// Death protection

            // Attack type
            temp = rom[offset++];
            if ((temp & 0x02) == 0x02)
                AttackType = 0;		// Inflict
            else if ((temp & 0x01) == 0x01)
                AttackType = 1;		// Protect
            else if ((temp & 0x04) == 0x04)
                AttackType = 2;		// Nullify
            else
                AttackType = 3;     // None

            // Cursor behavior
            CursorBehavior = (temp & 0x20) == 0x20 ? (byte)1 : (byte)0;
            //
            RestoreFP = (temp & 0x40) == 0x40; // Restore only if FP not maxed out
            RestoreHP = (temp & 0x80) == 0x80; // Restore only if HP not maxed out

            // Equip
            temp = rom[offset++];
            EquipMario = (temp & 0x01) == 0x01;		// Mario
            EquipToadstool = (temp & 0x02) == 0x02;	// Toadstool
            EquipBowser = (temp & 0x04) == 0x04;		// Bowser
            EquipGeno = (temp & 0x08) == 0x08;			// Geno
            EquipMallow = (temp & 0x10) == 0x10;		// Mallow

            // Targetting
            temp = rom[offset++];
            TargetLiveAlly = (temp & 0x02) == 0x02;			// Usable on any ally
            TargetEnemy = (temp & 0x04) == 0x04;		// Usable on any enemy
            TargetAll = (temp & 0x10) == 0x10;			// Usable on on all
            TargetWoundedOnly = (temp & 0x20) == 0x20;			// Usable on wounded
            TargetOnePartyOnly = (temp & 0x40) == 0x40;		// Usable in one party only
            TargetNotSelf = (temp & 0x80) == 0x80;		// Cannot use on self

            //
            temp = rom[offset++];
            switch (temp & 0xF0)
            {
                case 0x10: ElemAttack = 0; break;			// Ice
                case 0x20: ElemAttack = 1; break;		// Thunder
                case 0x40: ElemAttack = 2; break;		// Fire
                case 0x80: ElemAttack = 3; break;		// Earth
                default: ElemAttack = 4; break;
            }

            // Elemental attributes: nullify
            temp = rom[offset++];
            ElemNullIce = (temp & 0x10) == 0x10;		// Ice
            ElemNullThunder = (temp & 0x20) == 0x20;	// Thunder
            ElemNullFire = (temp & 0x40) == 0x40;	// Fire
            ElemNullJump = (temp & 0x80) == 0x80;	// Earth

            // Elemental attributes: weakness
            temp = rom[offset++];
            ElemWeakIce = (temp & 0x10) == 0x10;		// Ice
            ElemWeakThunder = (temp & 0x20) == 0x20;	// Thunder
            ElemWeakFire = (temp & 0x40) == 0x40;	// Fire
            ElemWeakJump = (temp & 0x80) == 0x80;	// Earth

            // Status effect
            temp = rom[offset++];
            EffectMute = (temp & 0x01) == 0x01;		// Mute
            EffectSleep = (temp & 0x02) == 0x02;		// Sleep
            EffectPoison = (temp & 0x04) == 0x04;		// Poison
            EffectFear = (temp & 0x08) == 0x08;		// Fear
            EffectMushroom = (temp & 0x20) == 0x20;	// Mushroom
            EffectScarecrow = (temp & 0x40) == 0x40;	// Scarecrow
            EffectInvincible = (temp & 0x80) == 0x80;	// Invincible

            // Status change
            temp = rom[offset++];
            ChangeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            ChangeAttack = (temp & 0x10) == 0x10;			// Attack
            ChangeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            ChangeDefense = (temp & 0x40) == 0x40;			// Defense

            //
            Speed = (sbyte)rom[offset++];
            Attack = (sbyte)rom[offset++];
            Defense = (sbyte)rom[offset++];
            MagicAttack = (sbyte)rom[offset++];
            MagicDefense = (sbyte)rom[offset++];
            AttackRange = rom[offset++];
            InflictionAmount = rom[offset++];

            // Inflict function
            temp = rom[offset++];
            switch (temp)
            {
                case 0x00: InflictFunction = 0; break; // None
                case 0x01: InflictFunction = 1; break; // Revive
                case 0x02: InflictFunction = 2; break; // Recover FP
                case 0x04: InflictFunction = 3; break; // etc...
                case 0x05: InflictFunction = 4; break;
                case 0x06: InflictFunction = 5; break;
                case 0x07: InflictFunction = 6; break;
                case 0xFF: InflictFunction = 7; break;
                default: InflictFunction = 0; break;
            }
            HideDigits = (rom[offset] & 0x04) == 0x04;

            // Timing
            if (Index < 37)
            {
                offset = (Index * 4) + 0x3A438A;
                WeaponStartLevel1 = rom[offset++];
                WeaponStartLevel2 = rom[offset++];
                WeaponEndLevel2 = rom[offset++];
                WeaponEndLevel1 = rom[offset++];
            }
        }
        public void WriteToROM(ref int descriptionOffset)
        {
            int offset = 0x3A46EF + (Index * 15);
            Bits.SetChars(rom, offset, Name);

            // Description
            int length = 0;
            if (Index <= 0xB0)
            {
                Bits.SetShort(rom, 0x3A2F20 + Index * 2, descriptionOffset);
                if (this.DescriptionError)
                    MessageBox.Show("Unable to save item #" + this.Index + "'s description.");
                else
                {
                    length = (ushort)RawDescription.Length;
                    Bits.SetChars(rom, 0x3A0000 + descriptionOffset, RawDescription); // Write the actual description
                }
            }
            descriptionOffset += length;

            // Price
            Bits.SetShort(rom, (Index * 2) + 0x3A40F2, Price);

            // Stats
            offset = (Index * 18) + 0x3A014D;
            rom[offset] = ItemType;
            Bits.SetBit(rom, offset, 3, UsageBattleMenu);
            Bits.SetBit(rom, offset, 4, UsageOverworldMenu);
            Bits.SetBit(rom, offset, 5, UsageReusable);
            Bits.SetBit(rom, offset++, 7, UsageInstantDeath);
            //
            switch (AttackType)
            {
                case 0: rom[offset] = 0x02; break;
                case 1: rom[offset] = 0x01; break;
                case 2: rom[offset] = 0x04; break;
                case 3: rom[offset] = 0x00; break;
            }

            // Cursor
            if (CursorBehavior == 1)
                Bits.SetBit(rom, offset, 5, true);
            Bits.SetBit(rom, offset, 6, RestoreFP);
            Bits.SetBit(rom, offset++, 7, RestoreHP);

            //
            Bits.SetBit(rom, offset, 0, EquipMario);
            Bits.SetBit(rom, offset, 1, EquipToadstool);
            Bits.SetBit(rom, offset, 2, EquipBowser);
            Bits.SetBit(rom, offset, 3, EquipGeno);
            Bits.SetBit(rom, offset++, 4, EquipMallow);

            //
            Bits.SetBit(rom, offset, 1, TargetLiveAlly);
            Bits.SetBit(rom, offset, 2, TargetEnemy);
            Bits.SetBit(rom, offset, 4, TargetAll);
            Bits.SetBit(rom, offset, 5, TargetWoundedOnly);
            Bits.SetBit(rom, offset, 6, TargetOnePartyOnly);
            Bits.SetBit(rom, offset++, 7, TargetNotSelf);

            //
            switch (ElemAttack)
            {
                case 0: rom[offset++] = 0x10; break; // Ice
                case 1: rom[offset++] = 0x20; break; // Thunder
                case 2: rom[offset++] = 0x40; break; // Fire
                case 3: rom[offset++] = 0x80; break; // Earth
                case 4: rom[offset++] = 0x00; break;
            }

            // Elemental attributes: nullify
            Bits.SetBit(rom, offset, 4, ElemNullIce);
            Bits.SetBit(rom, offset, 5, ElemNullThunder);
            Bits.SetBit(rom, offset, 6, ElemNullFire);
            Bits.SetBit(rom, offset++, 7, ElemNullJump);

            // Elemental attributes: weakness
            Bits.SetBit(rom, offset, 4, ElemWeakIce);
            Bits.SetBit(rom, offset, 5, ElemWeakThunder);
            Bits.SetBit(rom, offset, 6, ElemWeakFire);
            Bits.SetBit(rom, offset++, 7, ElemWeakJump);

            // Status effect
            Bits.SetBit(rom, offset, 0, EffectMute);
            Bits.SetBit(rom, offset, 1, EffectSleep);
            Bits.SetBit(rom, offset, 2, EffectPoison);
            Bits.SetBit(rom, offset, 3, EffectFear);
            Bits.SetBit(rom, offset, 5, EffectMushroom);
            Bits.SetBit(rom, offset, 6, EffectScarecrow);
            Bits.SetBit(rom, offset++, 7, EffectInvincible);

            // Status change
            Bits.SetBit(rom, offset, 3, ChangeMagicAttack);
            Bits.SetBit(rom, offset, 4, ChangeAttack);
            Bits.SetBit(rom, offset, 5, ChangeMagicDefense);
            Bits.SetBit(rom, offset++, 6, ChangeDefense);

            //
            rom[offset++] = (byte)Speed;
            rom[offset++] = (byte)Attack;
            rom[offset++] = (byte)Defense;
            rom[offset++] = (byte)MagicAttack;
            rom[offset++] = (byte)MagicDefense;
            rom[offset++] = AttackRange;
            rom[offset++] = InflictionAmount;

            // Inflict function
            switch (InflictFunction)
            {
                case 0: rom[offset++] = 0x00; break; // Revive
                case 1: rom[offset++] = 0x01; break; // Recover FP
                case 2: rom[offset++] = 0x02; break; // etc...
                case 3: rom[offset++] = 0x04; break;
                case 4: rom[offset++] = 0x05; break;
                case 5: rom[offset++] = 0x06; break;
                case 6: rom[offset++] = 0x07; break;
                case 7: rom[offset++] = 0xFF; break;
            }
            Bits.SetBit(rom, offset, 2, HideDigits);

            // Timing
            if (Index < 37)
            {
                offset = (Index * 4) + 0x3A438A;
                rom[offset++] = WeaponStartLevel1;
                rom[offset++] = WeaponStartLevel2;
                rom[offset++] = WeaponEndLevel2;
                rom[offset++] = WeaponEndLevel1;
            }
        }

        /// <summary>
        /// Converts this item's description from it's data in the ROM buffer to a character array.
        /// </summary>
        /// <returns></returns>
        private char[] ParseDescription()
        {
            int offset = 0x3A0000 + Bits.GetShort(rom, 0x3A2F20 + Index * 2);
            int counter = 0;
            int length = 0;
            int letter = -1;
            while (letter != 0 && letter != 6)
            {
                letter = rom[offset + counter++];
                length++;
            }
            char[] description = new char[length];
            for (int i = 0; i < length; i++)
                description[i] = (char)rom[offset + i];
            return description;
        }

        // Inherited
        public override void Clear()
        {
            Bits.Fill(Name, '\x20');
            RawDescription = new char[0];
            Price = 0;
            Speed = 0;
            Attack = 0;
            Defense = 0;
            MagicAttack = 0;
            MagicDefense = 0;
            AttackRange = 0;
            AttackType = 0;
            ElemAttack = 0;
            HideDigits = false;
            InflictionAmount = 0;
            EffectMute = false;
            EffectSleep = false;
            EffectPoison = false;
            EffectFear = false;
            EffectMushroom = false;
            EffectScarecrow = false;
            EffectInvincible = false;
            ChangeAttack = false;
            ChangeDefense = false;
            ChangeMagicAttack = false;
            ChangeMagicDefense = false;
            ElemNullIce = false;
            ElemNullFire = false;
            ElemNullThunder = false;
            ElemNullJump = false;
            ElemWeakIce = false;
            ElemWeakFire = false;
            ElemWeakThunder = false;
            ElemWeakJump = false;
            EquipMario = false;
            EquipToadstool = false;
            EquipBowser = false;
            EquipGeno = false;
            EquipMallow = false;
            UsageBattleMenu = false;
            UsageOverworldMenu = false;
            UsageReusable = false;
            UsageInstantDeath = false;
            RestoreFP = false;
            RestoreHP = false;
            TargetLiveAlly = false;
            TargetEnemy = false;
            TargetAll = false;
            TargetWoundedOnly = false;
            TargetOnePartyOnly = false;
            TargetNotSelf = false;
            ItemType = 0;
            CursorBehavior = 0;
            InflictFunction = 0;
        }

        // Override
        public override string ToString()
        {
            return new string(Name);
        }

        #endregion
    }
}
