using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Magic
{
    [Serializable()]
    public class Spell : Element
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
        public char[] Name { get; set; }

        // Statistics
        public byte FPCost { get; set; }
        public byte MagicPower { get; set; }
        public byte HitRate { get; set; }
        public byte AttackType { get; set; }
        public byte EffectType { get; set; }
        public byte InflictFunction { get; set; }
        public byte InflictElement { get; set; }
        public bool CheckStats { get; set; }
        public bool IgnoreDefense { get; set; }
        public bool CheckMortality { get; set; }
        public bool UsableOverworld { get; set; }
        public bool MaxAttack { get; set; }
        public bool HideDigits { get; set; }
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
        public bool TargetLiveAlly { get; set; }
        public bool TargetEnemy { get; set; }
        public bool TargetAll { get; set; }
        public bool TargetWoundedOnly { get; set; }
        public bool TargetOnePartyOnly { get; set; }
        public bool TargetNotSelf { get; set; }

        // Description
        private Dialogues.ParserReduced parser
        {
            get { return Dialogues.ParserReduced.Instance; }
        }
        public char[] RawDescription { get; set; }
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
        public bool DescriptionError { get; set; }
        public int CaretPosByteView { get; set; }
        public int CaretPosTextView { get; set; }

        // Timing
        public byte OneLevelSpellStart { get; set; }
        public byte OneLevelSpellSpan { get; set; }
        public byte TwoLevelSpellStartLevel1 { get; set; }
        public byte TwoLevelSpellStartLevel2 { get; set; }
        public byte TwoLevelSpellEndLevel2 { get; set; }
        public byte TwoLevelSpellEndLevel1 { get; set; }
        public byte FireballSpellRange { get; set; }
        public byte FireballSpellOrbs { get; set; }
        public byte RotationSpellStart { get; set; }
        public byte RotationSpellMax { get; set; }
        public byte MultipleSpellMax { get; set; }
        public byte[] MultipleSpellRanges { get; set; }
        public byte ChargeSpellStartLevel2 { get; set; }
        public byte ChargeSpellStartLevel3 { get; set; }
        public byte ChargeSpellStartLevel4 { get; set; }
        public byte ChargeSpellOverflow { get; set; }
        public byte RapidSpellMax { get; set; }

        #endregion

        // Constructor
        public Spell(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            // Name
            byte temp = 0;
            Name = new char[15];
            for (int i = 0; i < Name.Length; i++)
                Name[i] = (char)rom[(Index * 15) + 0x3A137F + i];

            // Description
            if (Index <= 0x1A)
                RawDescription = ParseDescription();
            else
                RawDescription = null;

            #region Statistics

            int offset = (Index * 12) + 0x3A20F1;

            // Misc properties
            temp = rom[offset++];
            CheckStats = (temp & 0x01) == 0x01;
            IgnoreDefense = (temp & 0x02) == 0x02;
            CheckMortality = (temp & 0x20) == 0x20;
            UsableOverworld = (temp & 0x80) == 0x80;

            // Type
            temp = rom[offset++];
            AttackType = (byte)(temp & 0x01);
            switch (temp & 0x06)
            {
                case 0x02: EffectType = 0; break;
                case 0x04: EffectType = 1; break;
                default: EffectType = 2; break;
            }
            MaxAttack = (temp & 0x08) == 0x08;

            // FP cost
            FPCost = rom[offset++];

            // Targetting
            Targetting target = (Targetting)rom[offset++];
            TargetLiveAlly = (target & Targetting.LiveAlly) == Targetting.LiveAlly;
            TargetEnemy = (target & Targetting.Enemy) == Targetting.Enemy;
            TargetAll = (target & Targetting.All) == Targetting.All;
            TargetWoundedOnly = (target & Targetting.WoundedOnly) == Targetting.WoundedOnly;
            TargetOnePartyOnly = (target & Targetting.OnePartyOnly) == Targetting.OnePartyOnly;
            TargetNotSelf = (target & Targetting.NotSelf) == Targetting.NotSelf;

            // Inflict element
            temp = rom[offset++];
            switch (temp & 0xF0)
            {
                case 0x10: InflictElement = 0; break; // Ice
                case 0x20: InflictElement = 1; break; // Thunder
                case 0x40: InflictElement = 2; break; // Fire
                case 0x80: InflictElement = 3; break; // Earth
                default: InflictElement = 4; break;
            }
            MagicPower = rom[offset++];
            HitRate = rom[offset++];

            // Status effect
            Status status = (Status)rom[offset++];
            EffectMute = (status & Status.Mute) == Status.Mute;
            EffectSleep = (status & Status.Sleep) == Status.Sleep;
            EffectPoison = (status & Status.Poison) == Status.Poison;
            EffectFear = (status & Status.Fear) == Status.Fear;
            EffectMushroom = (status & Status.Mushroom) == Status.Mushroom;
            EffectScarecrow = (status & Status.Scarecrow) == Status.Scarecrow;
            EffectInvincible = (status & Status.Invincible) == Status.Invincible;

            // Status change
            temp = rom[offset]; offset += 2;
            ChangeMagicAttack = (temp & 0x08) == 0x08;  // Magic Attack
            ChangeAttack = (temp & 0x10) == 0x10;       // Attack
            ChangeMagicDefense = (temp & 0x20) == 0x20; // Magic Defense
            ChangeDefense = (temp & 0x40) == 0x40;      // Defense

            // Inflict function
            temp = rom[offset++];
            switch (temp)
            {
                case 0x00: InflictFunction = 0; break; // Ice
                case 0x01: InflictFunction = 1; break; // Ice
                case 0x02: InflictFunction = 2; break; // Thunder
                case 0x03: InflictFunction = 3; break; // Fire
                case 0x04: InflictFunction = 4; break; // Earth
                default: InflictFunction = 5; break;
            }
            HideDigits = rom[offset] == 4;

            #endregion

            #region Timing

            if (Index == 2)  // super jump
            {
                MultipleSpellRanges = new byte[14];
                for (int i = 0; i < 14; i++)
                {
                    if (i == 0) MultipleSpellRanges[i] = rom[0x35969D];
                    else if (i == 13) MultipleSpellRanges[i] = rom[0x359768];
                    else
                    {
                        offset = ((i - 1) * 11) + 0x3596DE;
                        MultipleSpellRanges[i] = rom[offset];
                    }
                }
                MultipleSpellMax = rom[0x359763];
            }
            if (Index == 4)  // ultra jump
            {
                MultipleSpellRanges = new byte[17];
                for (int i = 0; i < 17; i++)
                {
                    if (i == 0) MultipleSpellRanges[i] = rom[0x359AA6];
                    else if (i == 16) MultipleSpellRanges[i] = rom[0x359B83];
                    else
                    {
                        offset = ((i - 1) * 11) + 0x359AD7;
                        MultipleSpellRanges[i] = rom[offset];
                    }
                }
                MultipleSpellMax = rom[0x359B7E];
            }
            if (Index == 26) // star rain
            {
                MultipleSpellRanges = new byte[1];
                MultipleSpellRanges[0] = rom[0x35C3C5];
                MultipleSpellMax = rom[0x35C407];
            }
            if (Index == 9 || Index == 17 || Index == 18 || Index == 21 || Index == 23)
            {
                if (Index == 9) offset = 0x35A663;        // Come Back
                else if (Index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (Index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (Index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (Index == 23) offset = 0x35C15E;  // Psychopath
                OneLevelSpellStart = rom[offset]; offset += 2;
                OneLevelSpellSpan = rom[offset]; offset += 2;
            }
            if (Index == 0 || Index == 6 || Index == 7 || Index == 14 || Index == 22 || Index == 24)
            {
                if (Index == 0) offset = 0x359305;        // Jump
                else if (Index == 6 || Index == 7) offset = 0x359E47; // Therapy / Group Hug
                else if (Index == 14) offset = 0x35B09A;  // Crusher
                else if (Index == 22) offset = 0x35BFC6;  // HP Rain
                else if (Index == 24) offset = 0x35C2CA;  // Shocker
                TwoLevelSpellStartLevel1 = rom[offset]; offset += 2;
                TwoLevelSpellStartLevel2 = rom[offset++];
                TwoLevelSpellEndLevel2 = rom[offset++];
                TwoLevelSpellEndLevel1 = rom[offset++];
            }
            if (Index == 1 || Index == 3 || Index == 5)
            {
                if (Index == 1) offset = 0x359484;       // Fire Orb
                else if (Index == 3) offset = 0x3598D8;  // Super Flame
                else if (Index == 5) offset = 0x359CF4;  // Ultra Flame
                FireballSpellRange = rom[offset]; offset += 13;
                FireballSpellOrbs = rom[offset];
            }
            if (Index == 8 || Index == 10 || Index == 12 || Index == 13 || Index == 25)
            {
                if (Index == 8) offset = 0x35A423;       // Sleepy Time
                else if (Index == 10) offset = 0x35A86F;  // Mute
                else if (Index == 12) offset = 0x35ACAF;  // Terrorize
                else if (Index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (Index == 25) offset = 0x35C347;  // Snowy
                RotationSpellStart = rom[offset]; offset += 2;
                RotationSpellMax = rom[offset];
            }
            if (Index == 16 || Index == 19 || Index == 20)
            {
                ChargeSpellStartLevel2 = rom[0x35B58D];
                ChargeSpellStartLevel3 = rom[0x35B58E];
                ChargeSpellStartLevel4 = rom[0x35B58F];
                ChargeSpellOverflow = rom[0x35B590];
            }
            if (Index == 11 || Index == 15)
                RapidSpellMax = rom[0x35AA15];

            #endregion
        }
        public void WriteToROM(ref int descriptionOffset)
        {
            // Name
            Bits.SetChars(rom, 0x3A137F + (Index * 15), Name);

            // Description
            int length = 0;
            if (Index <= 0x1A)
            {
                Bits.SetShort(rom, 0x3A2B80 + Index * 2, descriptionOffset);
                if (this.DescriptionError)
                    MessageBox.Show("Unable to save spell #" + this.Index + "'s description.");
                else
                {
                    length = RawDescription.Length;
                    Bits.SetChars(rom, 0x3A0000 + descriptionOffset, RawDescription); // Write the actual description
                }
            }
            descriptionOffset += length;

            #region Statistics

            // Misc properties
            int offset = (Index * 12) + 0x3A20F1;
            Bits.SetBit(rom, offset, 0, CheckStats);
            Bits.SetBit(rom, offset, 1, IgnoreDefense);
            Bits.SetBit(rom, offset, 5, CheckMortality);
            Bits.SetBit(rom, offset++, 7, UsableOverworld);

            // Type
            rom[offset] = AttackType;
            if (EffectType == 0) // Inflict
            {
                Bits.SetBit(rom, offset, 1, true);
                Bits.SetBit(rom, offset, 2, false);
            }
            else if (EffectType == 1) // Nullify
            {
                Bits.SetBit(rom, offset, 1, false);
                Bits.SetBit(rom, offset, 2, true);
            }
            else if (EffectType == 2) // {NONE}
            {
                Bits.SetBit(rom, offset, 1, false);
                Bits.SetBit(rom, offset, 2, false);
            }
            Bits.SetBit(rom, offset++, 3, MaxAttack);

            // FP cost
            rom[offset++] = FPCost;

            // Targetting
            Bits.SetBit(rom, offset, 1, TargetLiveAlly);
            Bits.SetBit(rom, offset, 2, TargetEnemy);
            Bits.SetBit(rom, offset, 4, TargetAll);
            Bits.SetBit(rom, offset, 5, TargetWoundedOnly);
            Bits.SetBit(rom, offset, 6, TargetOnePartyOnly);
            Bits.SetBit(rom, offset++, 7, TargetNotSelf);

            // Inflict element
            switch (InflictElement)
            {
                case 0: rom[offset] = 0x10; break;
                case 1: rom[offset] = 0x20; break;
                case 2: rom[offset] = 0x40; break;
                case 3: rom[offset] = 0x80; break;
                case 4: rom[offset] = 0x00; break;
            }
            offset++;
            rom[offset++] = MagicPower;
            rom[offset++] = HitRate;

            // Effect status
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
            Bits.SetBit(rom, offset, 6, ChangeDefense);
            offset += 2;

            // Inflict function
            switch (InflictFunction)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x01; break;
                case 2: rom[offset] = 0x02; break;
                case 3: rom[offset] = 0x03; break;
                case 4: rom[offset] = 0x04; break;
                default: rom[offset] = 0xFF; break;
            }
            offset++;
            if (HideDigits == true)
                rom[offset] = 0x04;
            else
                rom[offset] = 0x00;

            #endregion

            #region Timing

            if (Index == 2)  // super jump
            {
                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0:
                            rom[0x35969D] = MultipleSpellRanges[i];
                            rom[0x35969F] = MultipleSpellRanges[i];
                            break;
                        case 13:
                            rom[0x359768] = MultipleSpellRanges[i];
                            rom[0x35976A] = MultipleSpellRanges[i];
                            break;
                        default:
                            offset = ((i - 1) * 11) + 0x3596DE;
                            rom[offset] = MultipleSpellRanges[i];
                            rom[offset + 2] = MultipleSpellRanges[i];
                            break;
                    }
                }
                rom[0x359763] = MultipleSpellMax;
            }
            if (Index == 4)  // ultra jump
            {
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            rom[0x359AA6] = MultipleSpellRanges[i];
                            rom[0x359AA8] = MultipleSpellRanges[i]; break;
                        case 16:
                            rom[0x359B83] = MultipleSpellRanges[i];
                            rom[0x359B85] = MultipleSpellRanges[i]; break;
                        default:
                            offset = ((i - 1) * 11) + 0x359AD7;
                            rom[offset] = MultipleSpellRanges[i];
                            rom[offset + 2] = MultipleSpellRanges[i];
                            break;
                    }
                }
                rom[0x359B7E] = MultipleSpellMax;
            }
            if (Index == 26) // star rain
            {
                rom[0x35C3C5] = MultipleSpellRanges[0];
                rom[0x35C3C7] = MultipleSpellRanges[0];
                rom[0x35C407] = MultipleSpellMax;
            }
            if (Index == 9 || Index == 17 || Index == 18 || Index == 21 || Index == 23)
            {
                if (Index == 9) offset = 0x35A663;        // Come Back
                else if (Index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (Index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (Index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (Index == 23) offset = 0x35C15E;  // Psychopath
                rom[offset] = OneLevelSpellSpan; offset += 2;
                rom[offset] = OneLevelSpellSpan; offset += 2;
            }
            if (Index == 0 || Index == 6 || Index == 7 || Index == 14 || Index == 22 || Index == 24)
            {
                if (Index == 0) offset = 0x359305;       // Jump
                else if (Index == 6 || Index == 7)       // Therapy / Group Hug
                    offset = 0x359E47;
                else if (Index == 14) offset = 0x35B09A;  // Crusher
                else if (Index == 22) offset = 0x35BFC6;  // HP Rain
                else if (Index == 24) offset = 0x35C2CA;  // Shocker
                rom[offset] = TwoLevelSpellEndLevel1; offset += 2;
                rom[offset] = TwoLevelSpellStartLevel2; offset++;
                rom[offset] = TwoLevelSpellEndLevel2; offset++;
                rom[offset] = TwoLevelSpellEndLevel1; offset++;
            }
            if (Index == 1 || Index == 3 || Index == 5)
            {
                if (Index == 1) offset = 0x359484;       // Fire Orb
                else if (Index == 3) offset = 0x3598D8;  // Super Flame
                else if (Index == 5) offset = 0x359CF4;  // Ultra Flame
                rom[offset] = FireballSpellRange; offset += 13;
                rom[offset] = FireballSpellOrbs;
            }
            if (Index == 8 || Index == 10 || Index == 12 || Index == 13 || Index == 25)
            {
                if (Index == 8) offset = 0x35A423;        // Sleepy Time
                else if (Index == 10) offset = 0x35A86F;  // Mute
                else if (Index == 12) offset = 0x35ACAF;  // Terrorize
                else if (Index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (Index == 25) offset = 0x35C347;  // Snowy
                rom[offset] = RotationSpellStart; offset += 2;
                rom[offset] = RotationSpellMax;
            }
            if (Index == 16 || Index == 19 || Index == 20)
            {
                rom[0x35B58D] = ChargeSpellStartLevel2;
                rom[0x35B58E] = ChargeSpellStartLevel3;
                rom[0x35B58F] = ChargeSpellStartLevel4;
                rom[0x35B590] = ChargeSpellOverflow;
            }
            if (Index == 11 || Index == 15)
                rom[0x35AA15] = RapidSpellMax;

            #endregion
        }

        /// <summary>
        /// Converts this spell's description from it's data in the ROM buffer to a character array.
        /// </summary>
        /// <returns></returns>
        private char[] ParseDescription()
        {
            int pointer = 0x3A0000 + Bits.GetShort(rom, 0x3A2B80 + Index * 2);
            int counter = pointer;

            // Get length of description
            int length = 0;
            do
            {
                counter++;
                length++;
            }
            while (rom[counter] != 0 && rom[counter] != 6);

            // Get description
            char[] description = new char[length];
            for (int i = 0; i < length; i++)
                description[i] = (char)rom[pointer + i];
            return description;
        }

        // Inherited
        public override void Clear()
        {
            Bits.Fill(Name, '\x20');
            RawDescription = new char[1];
            FPCost = 0;
            MagicPower = 0;
            HitRate = 0;
            AttackType = 0;
            EffectType = 0;
            InflictFunction = 0;
            InflictElement = 0;
            CheckStats = false;
            IgnoreDefense = false;
            CheckMortality = false;
            UsableOverworld = false;
            MaxAttack = false;
            HideDigits = false;
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
            TargetLiveAlly = false;
            TargetEnemy = false;
            TargetAll = false;
            TargetWoundedOnly = false;
            TargetOnePartyOnly = false;
            TargetNotSelf = false;
            // timing
            OneLevelSpellStart = 0;
            OneLevelSpellSpan = 0;
            TwoLevelSpellStartLevel1 = 0;
            TwoLevelSpellStartLevel2 = 0;
            TwoLevelSpellEndLevel2 = 0;
            TwoLevelSpellEndLevel1 = 0;
            FireballSpellRange = 0;
            FireballSpellOrbs = 0;
            RotationSpellStart = 0;
            RotationSpellMax = 0;
            MultipleSpellMax = 0;
            if (MultipleSpellRanges != null)
                MultipleSpellRanges = new byte[MultipleSpellRanges.Length];
            ChargeSpellStartLevel2 = 0;
            ChargeSpellStartLevel3 = 0;
            ChargeSpellStartLevel4 = 0;
            ChargeSpellOverflow = 0;
            RapidSpellMax = 0;
        }

        // Override
        public override string ToString()
        {
            return new string(Name);
        }

        #endregion
    }
}
