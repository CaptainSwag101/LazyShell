using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Spell : Element
    {
        private byte[] rom { get { return Model.ROM; } set { Model.ROM = value; } }
        public override int Index { get { return index; } set { index = value; } }
        #region class variables
        private int index;
        private char[] name;
        private char[] description;
        private bool descriptionError = false;
        private int caretPosByteView = 0;
        private int caretPosTextView = 0;
        private byte fpCost;
        private byte magicPower;
        private byte hitRate;
        private byte attackType;
        private byte effectType;
        private byte inflictFunction;
        private byte inflictElement;
        private bool checkStats;
        private bool ignoreDefense;
        private bool checkMortality;
        private bool usableOverworld;
        private bool maxAttack;
        private bool hideDigits;
        private bool effectMute;
        private bool effectSleep;
        private bool effectPoison;
        private bool effectFear;
        private bool effectMushroom;
        private bool effectScarecrow;
        private bool effectInvincible;
        private bool changeAttack;
        private bool changeDefense;
        private bool changeMagicAttack;
        private bool changeMagicDefense;
        private bool targetLiveAlly;
        private bool targetEnemy;
        private bool targetAll;
        private bool targetWoundedOnly;
        private bool targetOnePartyOnly;
        private bool targetNotSelf;
        // timing
        private byte oneLevelSpellStart;
        private byte oneLevelSpellSpan;
        private byte twoLevelSpellStartLevel1;
        private byte twoLevelSpellStartLevel2;
        private byte twoLevelSpellEndLevel2;
        private byte twoLevelSpellEndLevel1;
        private byte fireballSpellRange;
        private byte fireballSpellOrbs;
        private byte rotationSpellStart;
        private byte rotationSpellMax;
        private byte multipleSpellMax;
        private byte[] multipleSpellRanges;
        private byte chargeSpellStartLevel2;
        private byte chargeSpellStartLevel3;
        private byte chargeSpellStartLevel4;
        private byte chargeSpellOverflow;
        private byte rapidSpellMax;
        #endregion
        #region public accessors
        public char[] Name { get { return this.name; } set { this.name = value; } }
        // description
        private TextHelperReduced textHelperReduced { get { return TextHelperReduced.Instance; } }
        public char[] RawDescription { get { return this.description; } set { this.description = value; } }
        public bool SetDescription(string value, bool byteView)
        {
            this.description = textHelperReduced.Encode(value.ToCharArray(), byteView, 1, Lists.KeystrokesDesc);
            this.descriptionError = textHelperReduced.Error;
            return !descriptionError;
        }
        public string GetDescription(bool byteView)
        {
            if (!descriptionError)
                return new string(textHelperReduced.Decode(description, byteView, 1, Lists.KeystrokesDesc));
            else
                return new string(description);
        }
        public bool DescriptionError { get { return this.descriptionError; } set { this.descriptionError = value; } }
        public int CaretPosByteView { get { return this.caretPosByteView; } set { this.caretPosByteView = value; } }
        public int CaretPosTextView { get { return this.caretPosTextView; } set { this.caretPosTextView = value; } }
        // stats
        public byte FPCost { get { return this.fpCost; } set { this.fpCost = value; } }
        public byte MagicPower { get { return this.magicPower; } set { this.magicPower = value; } }
        public byte HitRate { get { return this.hitRate; } set { this.hitRate = value; } }
        public byte AttackType { get { return this.attackType; } set { this.attackType = value; } }
        public byte EffectType { get { return this.effectType; } set { this.effectType = value; } }
        public byte InflictFunction { get { return this.inflictFunction; } set { this.inflictFunction = value; } }
        public byte InflictElement { get { return this.inflictElement; } set { this.inflictElement = value; } }
        public bool CheckStats { get { return this.checkStats; } set { this.checkStats = value; } }
        public bool IgnoreDefense { get { return this.ignoreDefense; } set { this.ignoreDefense = value; } }
        public bool CheckMortality { get { return this.checkMortality; } set { this.checkMortality = value; } }
        public bool UsableOverworld { get { return this.usableOverworld; } set { this.usableOverworld = value; } }
        public bool MaxAttack { get { return this.maxAttack; } set { this.maxAttack = value; } }
        public bool HideDigits { get { return this.hideDigits; } set { this.hideDigits = value; } }
        public bool EffectMute { get { return this.effectMute; } set { this.effectMute = value; } }
        public bool EffectSleep { get { return this.effectSleep; } set { this.effectSleep = value; } }
        public bool EffectPoison { get { return this.effectPoison; } set { this.effectPoison = value; } }
        public bool EffectFear { get { return this.effectFear; } set { this.effectFear = value; } }
        public bool EffectMushroom { get { return this.effectMushroom; } set { this.effectMushroom = value; } }
        public bool EffectScarecrow { get { return this.effectScarecrow; } set { this.effectScarecrow = value; } }
        public bool EffectInvincible { get { return this.effectInvincible; } set { this.effectInvincible = value; } }
        public bool ChangeAttack { get { return this.changeAttack; } set { this.changeAttack = value; } }
        public bool ChangeDefense { get { return this.changeDefense; } set { this.changeDefense = value; } }
        public bool ChangeMagicAttack { get { return this.changeMagicAttack; } set { this.changeMagicAttack = value; } }
        public bool ChangeMagicDefense { get { return this.changeMagicDefense; } set { this.changeMagicDefense = value; } }
        public bool TargetLiveAlly { get { return this.targetLiveAlly; } set { this.targetLiveAlly = value; } }
        public bool TargetEnemy { get { return this.targetEnemy; } set { this.targetEnemy = value; } }
        public bool TargetAll { get { return this.targetAll; } set { this.targetAll = value; } }
        public bool TargetWoundedOnly { get { return this.targetWoundedOnly; } set { this.targetWoundedOnly = value; } }
        public bool TargetOnePartyOnly { get { return this.targetOnePartyOnly; } set { this.targetOnePartyOnly = value; } }
        public bool TargetNotSelf { get { return this.targetNotSelf; } set { this.targetNotSelf = value; } }
        // timing
        public byte OneLevelSpellStart { get { return this.oneLevelSpellStart; } set { this.oneLevelSpellStart = value; } }
        public byte OneLevelSpellSpan { get { return this.oneLevelSpellSpan; } set { this.oneLevelSpellSpan = value; } }
        public byte TwoLevelSpellStartLevel1 { get { return this.twoLevelSpellStartLevel1; } set { this.twoLevelSpellStartLevel1 = value; } }
        public byte TwoLevelSpellStartLevel2 { get { return this.twoLevelSpellStartLevel2; } set { this.twoLevelSpellStartLevel2 = value; } }
        public byte TwoLevelSpellEndLevel2 { get { return this.twoLevelSpellEndLevel2; } set { this.twoLevelSpellEndLevel2 = value; } }
        public byte TwoLevelSpellEndLevel1 { get { return this.twoLevelSpellEndLevel1; } set { this.twoLevelSpellEndLevel1 = value; } }
        public byte FireballSpellRange { get { return this.fireballSpellRange; } set { this.fireballSpellRange = value; } }
        public byte FireballSpellOrbs { get { return this.fireballSpellOrbs; } set { this.fireballSpellOrbs = value; } }
        public byte RotationSpellStart { get { return this.rotationSpellStart; } set { this.rotationSpellStart = value; } }
        public byte RotationSpellMax { get { return this.rotationSpellMax; } set { this.rotationSpellMax = value; } }
        public byte MultipleSpellInstanceMax { get { return this.multipleSpellMax; } set { this.multipleSpellMax = value; } }
        public byte[] MultipleSpellInstanceRange { get { return this.multipleSpellRanges; } set { this.multipleSpellRanges = value; } }
        public byte ChargeSpellStartLevel2 { get { return this.chargeSpellStartLevel2; } set { this.chargeSpellStartLevel2 = value; } }
        public byte ChargeSpellStartLevel3 { get { return this.chargeSpellStartLevel3; } set { this.chargeSpellStartLevel3 = value; } }
        public byte ChargeSpellStartLevel4 { get { return this.chargeSpellStartLevel4; } set { this.chargeSpellStartLevel4 = value; } }
        public byte ChargeSpellOverflow { get { return this.chargeSpellOverflow; } set { this.chargeSpellOverflow = value; } }
        public byte RapidSpellMax { get { return this.rapidSpellMax; } set { this.rapidSpellMax = value; } }
        #endregion
        // constructor
        public Spell(int index)
        {
            this.index = index;
            Disassemble();
        }
        // assemblers
        private void Disassemble()
        {
            byte temp = 0;
            name = new char[15];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)rom[(index * 15) + 0x3A137F + i];
            if (index <= 0x1A)
                description = ParseDescription();
            else
                description = null;
            //
            int offset = (index * 12) + 0x3A20F1;
            //
            temp = rom[offset++];
            checkStats = (temp & 0x01) == 0x01;
            ignoreDefense = (temp & 0x02) == 0x02;
            checkMortality = (temp & 0x20) == 0x20;
            usableOverworld = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            attackType = (byte)(temp & 0x01);
            switch (temp & 0x06)
            {
                case 0x02: effectType = 0; break;
                case 0x04: effectType = 1; break;
                default: effectType = 2; break;
            }
            maxAttack = (temp & 0x08) == 0x08;
            //
            fpCost = rom[offset++];
            //
            Targetting target = (Targetting)rom[offset++];
            targetLiveAlly = (target & Targetting.LiveAlly) == Targetting.LiveAlly;
            targetEnemy = (target & Targetting.Enemy) == Targetting.Enemy;
            targetAll = (target & Targetting.All) == Targetting.All;
            targetWoundedOnly = (target & Targetting.WoundedOnly) == Targetting.WoundedOnly;
            targetOnePartyOnly = (target & Targetting.OnePartyOnly) == Targetting.OnePartyOnly;
            targetNotSelf = (target & Targetting.NotSelf) == Targetting.NotSelf;
            //
            temp = rom[offset++];
            switch (temp & 0xF0)
            {
                case 0x10: inflictElement = 0; break;			// Ice
                case 0x20: inflictElement = 1; break;		// Thunder
                case 0x40: inflictElement = 2; break;		// Fire
                case 0x80: inflictElement = 3; break;		// Earth
                default: inflictElement = 4; break;
            }
            magicPower = rom[offset++];
            hitRate = rom[offset++];
            // status effect
            Status status = (Status)rom[offset++];
            effectMute = (status & Status.Mute) == Status.Mute;
            effectSleep = (status & Status.Sleep) == Status.Sleep;
            effectPoison = (status & Status.Poison) == Status.Poison;
            effectFear = (status & Status.Fear) == Status.Fear;
            effectMushroom = (status & Status.Mushroom) == Status.Mushroom;
            effectScarecrow = (status & Status.Scarecrow) == Status.Scarecrow;
            effectInvincible = (status & Status.Invincible) == Status.Invincible;
            // status change
            temp = rom[offset]; offset += 2;
            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense
            //
            temp = rom[offset++];
            switch (temp)
            {
                case 0x00: inflictFunction = 0; break;			// Ice
                case 0x01: inflictFunction = 1; break;			// Ice
                case 0x02: inflictFunction = 2; break;		// Thunder
                case 0x03: inflictFunction = 3; break;		// Fire
                case 0x04: inflictFunction = 4; break;		// Earth
                default: inflictFunction = 5; break;
            }
            hideDigits = rom[offset] == 4;
            // timing
            if (index == 2)  // super jump
            {
                multipleSpellRanges = new byte[14];
                for (int i = 0; i < 14; i++)
                {
                    if (i == 0) multipleSpellRanges[i] = rom[0x35969D];
                    else if (i == 13) multipleSpellRanges[i] = rom[0x359768];
                    else
                    {
                        offset = ((i - 1) * 11) + 0x3596DE;
                        multipleSpellRanges[i] = rom[offset];
                    }
                }
                multipleSpellMax = rom[0x359763];
            }
            if (index == 4)  // ultra jump
            {
                multipleSpellRanges = new byte[17];
                for (int i = 0; i < 17; i++)
                {
                    if (i == 0) multipleSpellRanges[i] = rom[0x359AA6];
                    else if (i == 16) multipleSpellRanges[i] = rom[0x359B83];
                    else
                    {
                        offset = ((i - 1) * 11) + 0x359AD7;
                        multipleSpellRanges[i] = rom[offset];
                    }
                }
                multipleSpellMax = rom[0x359B7E];
            }
            if (index == 26) // star rain
            {
                multipleSpellRanges = new byte[1];
                multipleSpellRanges[0] = rom[0x35C3C5];
                multipleSpellMax = rom[0x35C407];
            }
            if (index == 9 || index == 17 || index == 18 || index == 21 || index == 23)
            {
                if (index == 9) offset = 0x35A663;        // Come Back
                else if (index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (index == 23) offset = 0x35C15E;  // Psychopath
                oneLevelSpellStart = rom[offset]; offset += 2;
                oneLevelSpellSpan = rom[offset]; offset += 2;
            }
            if (index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24)
            {
                if (index == 0) offset = 0x359305;        // Jump
                else if (index == 6 || index == 7) offset = 0x359E47; // Therapy / Group Hug
                else if (index == 14) offset = 0x35B09A;  // Crusher
                else if (index == 22) offset = 0x35BFC6;  // HP Rain
                else if (index == 24) offset = 0x35C2CA;  // Shocker
                twoLevelSpellStartLevel1 = rom[offset]; offset += 2;
                twoLevelSpellStartLevel2 = rom[offset++];
                twoLevelSpellEndLevel2 = rom[offset++];
                twoLevelSpellEndLevel1 = rom[offset++];
            }
            if (index == 1 || index == 3 || index == 5)
            {
                if (index == 1) offset = 0x359484;       // Fire Orb
                else if (index == 3) offset = 0x3598D8;  // Super Flame
                else if (index == 5) offset = 0x359CF4;  // Ultra Flame
                fireballSpellRange = rom[offset]; offset += 13;
                fireballSpellOrbs = rom[offset];
            }
            if (index == 8 || index == 10 || index == 12 || index == 13 || index == 25)
            {
                if (index == 8) offset = 0x35A423;       // Sleepy Time
                else if (index == 10) offset = 0x35A86F;  // Mute
                else if (index == 12) offset = 0x35ACAF;  // Terrorize
                else if (index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (index == 25) offset = 0x35C347;  // Snowy
                rotationSpellStart = rom[offset]; offset += 2;
                rotationSpellMax = rom[offset];
            }
            if (index == 16 || index == 19 || index == 20)
            {
                chargeSpellStartLevel2 = rom[0x35B58D];
                chargeSpellStartLevel3 = rom[0x35B58E];
                chargeSpellStartLevel4 = rom[0x35B58F];
                chargeSpellOverflow = rom[0x35B590];
            }
            if (index == 11 || index == 15)
                rapidSpellMax = rom[0x35AA15];
        }
        public void Assemble(ref int descriptionOffset)
        {
            Bits.SetCharArray(rom, 0x3A137F + (index * 15), name);
            // description
            int length = 0;
            if (index <= 0x1A)
            {
                Bits.SetShort(rom, 0x3A2B80 + index * 2, descriptionOffset);
                if (this.descriptionError)
                    MessageBox.Show("Unable to save spell #" + this.index + "'s description.");
                else
                {
                    length = description.Length;
                    Bits.SetCharArray(rom, 0x3A0000 + descriptionOffset, description); // Write the actual description
                }
            }
            descriptionOffset += length;
            // stats
            int offset = (index * 12) + 0x3A20F1;
            Bits.SetBit(rom, offset, 0, checkStats);
            Bits.SetBit(rom, offset, 1, ignoreDefense);
            Bits.SetBit(rom, offset, 5, checkMortality);
            Bits.SetBit(rom, offset++, 7, usableOverworld);
            //
            rom[offset] = attackType;
            if (effectType == 0) // Inflict
            {
                Bits.SetBit(rom, offset, 1, true);
                Bits.SetBit(rom, offset, 2, false);
            }
            else if (effectType == 1) // Nullify
            {
                Bits.SetBit(rom, offset, 1, false);
                Bits.SetBit(rom, offset, 2, true);
            }
            else if (effectType == 2) // {NONE}
            {
                Bits.SetBit(rom, offset, 1, false);
                Bits.SetBit(rom, offset, 2, false);
            }
            Bits.SetBit(rom, offset++, 3, maxAttack);
            //
            rom[offset++] = fpCost;
            Bits.SetBit(rom, offset, 1, targetLiveAlly);
            Bits.SetBit(rom, offset, 2, targetEnemy);
            Bits.SetBit(rom, offset, 4, targetAll);
            Bits.SetBit(rom, offset, 5, targetWoundedOnly);
            Bits.SetBit(rom, offset, 6, targetOnePartyOnly);
            Bits.SetBit(rom, offset++, 7, targetNotSelf);
            //
            switch (inflictElement)
            {
                case 0: rom[offset] = 0x10; break;
                case 1: rom[offset] = 0x20; break;
                case 2: rom[offset] = 0x40; break;
                case 3: rom[offset] = 0x80; break;
                case 4: rom[offset] = 0x00; break;
            }
            offset++;
            //
            rom[offset++] = magicPower;
            rom[offset++] = hitRate;
            Bits.SetBit(rom, offset, 0, effectMute);
            Bits.SetBit(rom, offset, 1, effectSleep);
            Bits.SetBit(rom, offset, 2, effectPoison);
            Bits.SetBit(rom, offset, 3, effectFear);
            Bits.SetBit(rom, offset, 5, effectMushroom);
            Bits.SetBit(rom, offset, 6, effectScarecrow);
            Bits.SetBit(rom, offset++, 7, effectInvincible);
            //
            Bits.SetBit(rom, offset, 3, changeMagicAttack);
            Bits.SetBit(rom, offset, 4, changeAttack);
            Bits.SetBit(rom, offset, 5, changeMagicDefense);
            Bits.SetBit(rom, offset, 6, changeDefense);
            offset += 2;
            //
            switch (inflictFunction)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x01; break;
                case 2: rom[offset] = 0x02; break;
                case 3: rom[offset] = 0x03; break;
                case 4: rom[offset] = 0x04; break;
                default: rom[offset] = 0xFF; break;
            }
            offset++;
            if (hideDigits == true)
                rom[offset] = 0x04;
            else
                rom[offset] = 0x00;
            // timing
            if (index == 2)  // super jump
            {
                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0:
                            rom[0x35969D] = multipleSpellRanges[i];
                            rom[0x35969F] = multipleSpellRanges[i];
                            break;
                        case 13:
                            rom[0x359768] = multipleSpellRanges[i];
                            rom[0x35976A] = multipleSpellRanges[i];
                            break;
                        default:
                            offset = ((i - 1) * 11) + 0x3596DE;
                            rom[offset] = multipleSpellRanges[i];
                            rom[offset + 2] = multipleSpellRanges[i];
                            break;
                    }
                }
                rom[0x359763] = multipleSpellMax;
            }
            if (index == 4)  // ultra jump
            {
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            rom[0x359AA6] = multipleSpellRanges[i];
                            rom[0x359AA8] = multipleSpellRanges[i]; break;
                        case 16:
                            rom[0x359B83] = multipleSpellRanges[i];
                            rom[0x359B85] = multipleSpellRanges[i]; break;
                        default:
                            offset = ((i - 1) * 11) + 0x359AD7;
                            rom[offset] = multipleSpellRanges[i];
                            rom[offset + 2] = multipleSpellRanges[i];
                            break;
                    }
                }
                rom[0x359B7E] = multipleSpellMax;
            }
            if (index == 26) // star rain
            {
                rom[0x35C3C5] = multipleSpellRanges[0];
                rom[0x35C3C7] = multipleSpellRanges[0];
                rom[0x35C407] = multipleSpellMax;
            }
            if (index == 9 || index == 17 || index == 18 || index == 21 || index == 23)
            {
                if (index == 9) offset = 0x35A663;       // Come Back
                else if (index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (index == 23) offset = 0x35C15E;  // Psychopath
                rom[offset] = oneLevelSpellSpan; offset += 2;
                rom[offset] = oneLevelSpellSpan; offset += 2;
            }
            if (index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24)
            {
                if (index == 0) offset = 0x359305;       // Jump
                else if (index == 6 || index == 7)    // Therapy / Group Hug
                    offset = 0x359E47;
                else if (index == 14) offset = 0x35B09A;  // Crusher
                else if (index == 22) offset = 0x35BFC6;  // HP Rain
                else if (index == 24) offset = 0x35C2CA;  // Shocker
                rom[offset] = twoLevelSpellEndLevel1; offset += 2;
                rom[offset] = twoLevelSpellStartLevel2; offset++;
                rom[offset] = twoLevelSpellEndLevel2; offset++;
                rom[offset] = twoLevelSpellEndLevel1; offset++;
            }
            if (index == 1 || index == 3 || index == 5)
            {
                if (index == 1) offset = 0x359484;       // Fire Orb
                else if (index == 3) offset = 0x3598D8;  // Super Flame
                else if (index == 5) offset = 0x359CF4;  // Ultra Flame
                rom[offset] = fireballSpellRange; offset += 13;
                rom[offset] = fireballSpellOrbs;
            }
            if (index == 8 || index == 10 || index == 12 || index == 13 || index == 25)
            {
                if (index == 8) offset = 0x35A423;       // Sleepy Time
                else if (index == 10) offset = 0x35A86F;  // Mute
                else if (index == 12) offset = 0x35ACAF;  // Terrorize
                else if (index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (index == 25) offset = 0x35C347;  // Snowy
                rom[offset] = rotationSpellStart; offset += 2;
                rom[offset] = rotationSpellMax;
            }
            if (index == 16 || index == 19 || index == 20)
            {
                rom[0x35B58D] = chargeSpellStartLevel2;
                rom[0x35B58E] = chargeSpellStartLevel3;
                rom[0x35B58F] = chargeSpellStartLevel4;
                rom[0x35B590] = chargeSpellOverflow;
            }
            if (index == 11 || index == 15)
                rom[0x35AA15] = rapidSpellMax;
        }
        // universal functions
        public override string ToString()
        {
            return new string(name);
        }
        public override void Clear()
        {
            Bits.Fill(name, '\x20');
            description = new char[1];
            fpCost = 0;
            magicPower = 0;
            hitRate = 0;
            attackType = 0;
            effectType = 0;
            inflictFunction = 0;
            inflictElement = 0;
            checkStats = false;
            ignoreDefense = false;
            checkMortality = false;
            usableOverworld = false;
            maxAttack = false;
            hideDigits = false;
            effectMute = false;
            effectSleep = false;
            effectPoison = false;
            effectFear = false;
            effectMushroom = false;
            effectScarecrow = false;
            effectInvincible = false;
            changeAttack = false;
            changeDefense = false;
            changeMagicAttack = false;
            changeMagicDefense = false;
            targetLiveAlly = false;
            targetEnemy = false;
            targetAll = false;
            targetWoundedOnly = false;
            targetOnePartyOnly = false;
            targetNotSelf = false;
            // timing
            oneLevelSpellStart = 0;
            oneLevelSpellSpan = 0;
            twoLevelSpellStartLevel1 = 0;
            twoLevelSpellStartLevel2 = 0;
            twoLevelSpellEndLevel2 = 0;
            twoLevelSpellEndLevel1 = 0;
            fireballSpellRange = 0;
            fireballSpellOrbs = 0;
            rotationSpellStart = 0;
            rotationSpellMax = 0;
            multipleSpellMax = 0;
            if (multipleSpellRanges != null)
                multipleSpellRanges = new byte[multipleSpellRanges.Length];
            chargeSpellStartLevel2 = 0;
            chargeSpellStartLevel3 = 0;
            chargeSpellStartLevel4 = 0;
            chargeSpellOverflow = 0;
            rapidSpellMax = 0;
        }
        // class functions
        private char[] ParseDescription()
        {
            int pointer = 0x3A0000 + Bits.GetShort(rom, 0x3A2B80 + index * 2);
            int counter = pointer;
            int length = 0;
            int letter = -1;
            while (letter != 0 && letter != 6)
            {
                letter = rom[counter++];
                length++;
            }
            char[] description = new char[length];
            for (int i = 0; i < length; i++)
                description[i] = (char)rom[pointer + i];
            return description;
        }
    }
}
