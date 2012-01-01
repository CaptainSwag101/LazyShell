using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Spell : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index;} set { index = value;} }

        #region Spell Stats
        private int index;
        private char[] name;
        private char[] description;
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
        private byte multipleSpellInstanceMax;
        private byte[] multipleSpellInstanceRange;
        private byte chargeSpellStartLevel2;
        private byte chargeSpellStartLevel3;
        private byte chargeSpellStartLevel4;
        private byte chargeSpellOverflow;
        private byte rapidSpellMax;

        #endregion
        #region Accessors
        public char[] Name { get { return this.name; } set { this.name = value; } }
        private bool descriptionError = false; public bool DescriptionError { get { return this.descriptionError; } set { this.descriptionError = value; } }
        private TextHelperReduced textHelperReduced { get { return TextHelperReduced.Instance; } }
        private int caretPositionSymbol = 0; public int CaretPositionSymbol { get { return this.caretPositionSymbol; } set { this.caretPositionSymbol = value; } }
        private int caretPositionNotSymbol = 0; public int CaretPositionNotSymbol { get { return this.caretPositionNotSymbol; } set { this.caretPositionNotSymbol = value; } }

        public bool SetDescription(string value, bool symbols)
        {
            this.description = textHelperReduced.EncodeText(value.ToCharArray(), symbols, 1);
            this.descriptionError = textHelperReduced.Error;

            return !descriptionError;
        }
        public string GetDescription(bool symbols) { if (!descriptionError) return new string(textHelperReduced.DecodeText(description, symbols, 1)); else return new string(description); }
        public char[] RawDescription { get { return this.description; } set { this.description = value; } }
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
        public byte MultipleSpellInstanceMax { get { return this.multipleSpellInstanceMax; } set { this.multipleSpellInstanceMax = value; } }
        public byte[] MultipleSpellInstanceRange { get { return this.multipleSpellInstanceRange; } set { this.multipleSpellInstanceRange = value; } }
        public byte ChargeSpellStartLevel2 { get { return this.chargeSpellStartLevel2; } set { this.chargeSpellStartLevel2 = value; } }
        public byte ChargeSpellStartLevel3 { get { return this.chargeSpellStartLevel3; } set { this.chargeSpellStartLevel3 = value; } }
        public byte ChargeSpellStartLevel4 { get { return this.chargeSpellStartLevel4; } set { this.chargeSpellStartLevel4 = value; } }
        public byte ChargeSpellOverflow { get { return this.chargeSpellOverflow; } set { this.chargeSpellOverflow = value; } }
        public byte RapidSpellMax { get { return this.rapidSpellMax; } set { this.rapidSpellMax = value; } }
        #endregion

        public Spell(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeSpell(data);
        }
        private void InitializeSpell(byte[] data)
        {
            byte temp = 0;

            name = new char[15];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(index * 15) + 0x3A137F + i];

            if (index <= 0x1A)
            {
                description = ParseDescription(data);
            }
            else
            {
                description = null;
            }
            int offset = (index * 12) + 0x3A20F1;
            temp = data[offset]; offset++;

            checkStats = (temp & 0x01) == 0x01;
            ignoreDefense = (temp & 0x02) == 0x02;
            checkMortality = (temp & 0x20) == 0x20;
            usableOverworld = (temp & 0x80) == 0x80;

            temp = data[offset]; offset++;

            attackType = (byte)(temp & 0x01);
            switch (temp & 0x06)
            {
                case 0x02: effectType = 0; break;
                case 0x04: effectType = 1; break;
                default: effectType = 2; break;
            }

            maxAttack = (temp & 0x08) == 0x08;

            fpCost = data[offset]; offset++;

            temp = data[offset]; offset++;

            targetLiveAlly = (temp & 0x02) == 0x02;			// Usable on any ally
            targetEnemy = (temp & 0x04) == 0x04;		// Usable on any enemy
            targetAll = (temp & 0x10) == 0x10;			// Usable on on all
            targetWoundedOnly = (temp & 0x20) == 0x20;			// Usable on wounded
            targetOnePartyOnly = (temp & 0x40) == 0x40;		// Usable in one party only
            targetNotSelf = (temp & 0x80) == 0x80;		// Cannot use on self

            temp = data[offset]; offset++;

            switch (temp & 0xF0)
            {
                case 0x10: inflictElement = 0; break;			// Ice
                case 0x20: inflictElement = 1; break;		// Thunder
                case 0x40: inflictElement = 2; break;		// Fire
                case 0x80: inflictElement = 3; break;		// Earth
                default: inflictElement = 4; break;
            }

            magicPower = data[offset]; offset++;
            hitRate = data[offset]; offset++;

            temp = data[offset]; offset++;

            // STATUS EFFECT

            effectMute = (temp & 0x01) == 0x01;		// Mute
            effectSleep = (temp & 0x02) == 0x02;		// Sleep
            effectPoison = (temp & 0x04) == 0x04;		// Poison
            effectFear = (temp & 0x08) == 0x08;		// Fear
            effectMushroom = (temp & 0x20) == 0x20;	// Mushroom
            effectScarecrow = (temp & 0x40) == 0x40;	// Scarecrow
            effectInvincible = (temp & 0x80) == 0x80;	// Invincible

            temp = data[offset]; offset += 2;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense

            temp = data[offset]; offset++;

            switch (temp)
            {
                case 0x00: inflictFunction = 0; break;			// Ice
                case 0x01: inflictFunction = 1; break;			// Ice
                case 0x02: inflictFunction = 2; break;		// Thunder
                case 0x03: inflictFunction = 3; break;		// Fire
                case 0x04: inflictFunction = 4; break;		// Earth
                default: inflictFunction = 5; break;
            }

            hideDigits = data[offset] == 4;

            // timing
            if (index == 2)  // super jump
            {
                multipleSpellInstanceRange = new byte[14];
                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0: multipleSpellInstanceRange[i] = data[0x35969D]; break;
                        case 13: multipleSpellInstanceRange[i] = data[0x359768]; break;
                        default:
                            offset = ((i - 1) * 11) + 0x3596DE;
                            multipleSpellInstanceRange[i] = data[offset];
                            break;
                    }

                }
                multipleSpellInstanceMax = data[0x359763];
            }
            if (index == 4)  // ultra jump
            {
                multipleSpellInstanceRange = new byte[17];
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0: multipleSpellInstanceRange[i] = data[0x359AA6]; break;
                        case 16: multipleSpellInstanceRange[i] = data[0x359B83]; break;
                        default:
                            offset = ((i - 1) * 11) + 0x359AD7;
                            multipleSpellInstanceRange[i] = data[offset];
                            break;
                    }
                }
                multipleSpellInstanceMax = data[0x359B7E];
            }
            if (index == 26) // star rain
            {
                multipleSpellInstanceRange = new byte[1];
                multipleSpellInstanceRange[0] = data[0x35C3C5];
                multipleSpellInstanceMax = data[0x35C407];
            }
            if (index == 9 || index == 17 || index == 18 || index == 21 || index == 23)
            {
                if (index == 9) offset = 0x35A663;        // Come Back
                else if (index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (index == 23) offset = 0x35C15E;  // Psychopath
                oneLevelSpellStart = data[offset]; offset += 2;
                oneLevelSpellSpan = data[offset]; offset += 2;
            }
            if (index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24)
            {
                if (index == 0) offset = 0x359305;        // Jump
                else if (index == 6 || index == 7)     // Therapy / Group Hug
                    offset = 0x359E47;
                else if (index == 14) offset = 0x35B09A;  // Crusher
                else if (index == 22) offset = 0x35BFC6;  // HP Rain
                else if (index == 24) offset = 0x35C2CA;  // Shocker
                twoLevelSpellStartLevel1 = data[offset]; offset += 2;
                twoLevelSpellStartLevel2 = data[offset]; offset++;
                twoLevelSpellEndLevel2 = data[offset]; offset++;
                twoLevelSpellEndLevel1 = data[offset]; offset++;
            }
            if (index == 1 || index == 3 || index == 5)
            {
                if (index == 1) offset = 0x359484;       // Fire Orb
                else if (index == 3) offset = 0x3598D8;  // Super Flame
                else if (index == 5) offset = 0x359CF4;  // Ultra Flame
                fireballSpellRange = data[offset]; offset += 13;
                fireballSpellOrbs = data[offset];
            }
            if (index == 8 || index == 10 || index == 12 || index == 13 || index == 25)
            {
                if (index == 8) offset = 0x35A423;       // Sleepy Time
                else if (index == 10) offset = 0x35A86F;  // Mute
                else if (index == 12) offset = 0x35ACAF;  // Terrorize
                else if (index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (index == 25) offset = 0x35C347;  // Snowy
                rotationSpellStart = data[offset]; offset += 2;
                rotationSpellMax = data[offset];
            }
            if (index == 16 || index == 19 || index == 20)
            {
                chargeSpellStartLevel2 = data[0x35B58D];
                chargeSpellStartLevel3 = data[0x35B58E];
                chargeSpellStartLevel4 = data[0x35B58F];
                chargeSpellOverflow = data[0x35B590];
            }
            if (index == 11 || index == 15)
                rapidSpellMax = data[0x35AA15];
        }
        public ushort Assemble(ushort descOffset)
        {
            ushort retLength = 0;

            Bits.SetCharArray(data, 0x3A137F + (index * 15), name);

            if (index <= 0x1A)
            {
                // Write offset to table
                Bits.SetShort(data, 0x3A2B80 + index * 2, descOffset);


                if (this.descriptionError)
                    System.Windows.Forms.MessageBox.Show("There is an error with Spell " + this.index.ToString() + " Description, it has not been saved.");
                else
                {
                    retLength = (ushort)description.Length;
                    Bits.SetCharArray(data, 0x3A0000 + descOffset, description); // Write the actual description
                }
            }

            int offset = (index * 12) + 0x3A20F1;

            Bits.SetBit(data, offset, 0, checkStats);
            Bits.SetBit(data, offset, 1, ignoreDefense);
            Bits.SetBit(data, offset, 5, checkMortality);
            Bits.SetBit(data, offset, 7, usableOverworld);
            offset++;

            Bits.SetByte(data, offset, attackType);
            if (effectType == 0) // Inflict
            {
                Bits.SetBit(data, offset, 1, true);
                Bits.SetBit(data, offset, 2, false);
            }
            else if (effectType == 1) // Nullify
            {
                Bits.SetBit(data, offset, 1, false);
                Bits.SetBit(data, offset, 2, true);
            }
            else if (effectType == 2) // {NONE}
            {
                Bits.SetBit(data, offset, 1, false);
                Bits.SetBit(data, offset, 2, false);
            }

            Bits.SetBit(data, offset, 3, maxAttack);
            offset++;

            Bits.SetByte(data, offset, fpCost); offset++;

            Bits.SetBit(data, offset, 1, targetLiveAlly);
            Bits.SetBit(data, offset, 2, targetEnemy);
            Bits.SetBit(data, offset, 4, targetAll);
            Bits.SetBit(data, offset, 5, targetWoundedOnly);
            Bits.SetBit(data, offset, 6, targetOnePartyOnly);
            Bits.SetBit(data, offset, 7, targetNotSelf);
            offset++;

            switch (inflictElement)
            {
                case 0: Bits.SetByte(data, offset, 0x10); break;
                case 1: Bits.SetByte(data, offset, 0x20); break;
                case 2: Bits.SetByte(data, offset, 0x40); break;
                case 3: Bits.SetByte(data, offset, 0x80); break;
                case 4: Bits.SetByte(data, offset, 0x00); break;
            }
            offset++;

            Bits.SetByte(data, offset, magicPower); offset++;
            Bits.SetByte(data, offset, hitRate); offset++;

            Bits.SetBit(data, offset, 0, effectMute);
            Bits.SetBit(data, offset, 1, effectSleep);
            Bits.SetBit(data, offset, 2, effectPoison);
            Bits.SetBit(data, offset, 3, effectFear);
            Bits.SetBit(data, offset, 5, effectMushroom);
            Bits.SetBit(data, offset, 6, effectScarecrow);
            Bits.SetBit(data, offset, 7, effectInvincible);
            offset++;

            Bits.SetBit(data, offset, 3, changeMagicAttack);
            Bits.SetBit(data, offset, 4, changeAttack);
            Bits.SetBit(data, offset, 5, changeMagicDefense);
            Bits.SetBit(data, offset, 6, changeDefense);
            offset += 2;

            switch (inflictFunction)
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;
                case 1: Bits.SetByte(data, offset, 0x01); break;
                case 2: Bits.SetByte(data, offset, 0x02); break;
                case 3: Bits.SetByte(data, offset, 0x03); break;
                case 4: Bits.SetByte(data, offset, 0x04); break;
                default: Bits.SetByte(data, offset, 0xFF); break;
            }
            offset++;
            if (hideDigits == true)
                Bits.SetByte(data, offset, 0x04);
            else
                Bits.SetByte(data, offset, 0x00);

            // timing
            if (index == 2)  // super jump
            {
                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Bits.SetByte(data, 0x35969D, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, 0x35969F, multipleSpellInstanceRange[i]);
                            break;
                        case 13:
                            Bits.SetByte(data, 0x359768, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, 0x35976A, multipleSpellInstanceRange[i]);
                            break;
                        default:
                            offset = ((i - 1) * 11) + 0x3596DE;
                            Bits.SetByte(data, offset, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, offset + 2, multipleSpellInstanceRange[i]);
                            break;
                    }
                }
                Bits.SetByte(data, 0x359763, multipleSpellInstanceMax);
            }
            if (index == 4)  // ultra jump
            {
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Bits.SetByte(data, 0x359AA6, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, 0x359AA8, multipleSpellInstanceRange[i]); break;
                        case 16:
                            Bits.SetByte(data, 0x359B83, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, 0x359B85, multipleSpellInstanceRange[i]); break;
                        default:
                            offset = ((i - 1) * 11) + 0x359AD7;
                            Bits.SetByte(data, offset, multipleSpellInstanceRange[i]);
                            Bits.SetByte(data, offset + 2, multipleSpellInstanceRange[i]);
                            break;
                    }
                }
                Bits.SetByte(data, 0x359B7E, multipleSpellInstanceMax);
            }
            if (index == 26) // star rain
            {
                Bits.SetByte(data, 0x35C3C5, multipleSpellInstanceRange[0]);
                Bits.SetByte(data, 0x35C3C7, multipleSpellInstanceRange[0]);
                Bits.SetByte(data, 0x35C407, multipleSpellInstanceMax);
            }
            if (index == 9 || index == 17 || index == 18 || index == 21 || index == 23)
            {
                if (index == 9) offset = 0x35A663;       // Come Back
                else if (index == 17) offset = 0x35B9DB;  // Geno Boost
                else if (index == 18) offset = 0x35BAE2;  // Geno Whirl
                else if (index == 21) offset = 0x35BEDA;  // Thunderbolt
                else if (index == 23) offset = 0x35C15E;  // Psychopath
                Bits.SetByte(data, offset, oneLevelSpellSpan); offset += 2;
                Bits.SetByte(data, offset, oneLevelSpellSpan); offset += 2;
            }
            if (index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24)
            {
                if (index == 0) offset = 0x359305;       // Jump
                else if (index == 6 || index == 7)    // Therapy / Group Hug
                    offset = 0x359E47;
                else if (index == 14) offset = 0x35B09A;  // Crusher
                else if (index == 22) offset = 0x35BFC6;  // HP Rain
                else if (index == 24) offset = 0x35C2CA;  // Shocker
                Bits.SetByte(data, offset, twoLevelSpellEndLevel1); offset += 2;
                Bits.SetByte(data, offset, twoLevelSpellStartLevel2); offset++;
                Bits.SetByte(data, offset, twoLevelSpellEndLevel2); offset++;
                Bits.SetByte(data, offset, twoLevelSpellEndLevel1); offset++;
            }
            if (index == 1 || index == 3 || index == 5)
            {
                if (index == 1) offset = 0x359484;       // Fire Orb
                else if (index == 3) offset = 0x3598D8;  // Super Flame
                else if (index == 5) offset = 0x359CF4;  // Ultra Flame
                Bits.SetByte(data, offset, fireballSpellRange); offset += 13;
                Bits.SetByte(data, offset, fireballSpellOrbs);
            }
            if (index == 8 || index == 10 || index == 12 || index == 13 || index == 25)
            {
                if (index == 8) offset = 0x35A423;       // Sleepy Time
                else if (index == 10) offset = 0x35A86F;  // Mute
                else if (index == 12) offset = 0x35ACAF;  // Terrorize
                else if (index == 13) offset = 0x35AE3A;  // Poison Gas
                else if (index == 25) offset = 0x35C347;  // Snowy
                Bits.SetByte(data, offset, rotationSpellStart); offset += 2;
                Bits.SetByte(data, offset, rotationSpellMax);
            }
            if (index == 16 || index == 19 || index == 20)
            {
                Bits.SetByte(data, 0x35B58D, chargeSpellStartLevel2);
                Bits.SetByte(data, 0x35B58E, chargeSpellStartLevel3);
                Bits.SetByte(data, 0x35B58F, chargeSpellStartLevel4);
                Bits.SetByte(data, 0x35B590, chargeSpellOverflow);
            }
            if (index == 11 || index == 15)
                Bits.SetByte(data, 0x35AA15, rapidSpellMax);
            return retLength;
        }
        private char[] ParseDescription(byte[] data)
        {

            int descriptionPtr = 0x3A0000 + Bits.GetShort(data, 0x3A2B80 + index * 2);

            int count = descriptionPtr;
            int len = 0;
            byte ptr = 0x01;

            while (ptr != 0x00 && ptr != 0x06)
            {
                ptr = data[count];
                len++;
                count++;
            }

            char[] descriptionMsg = new char[len];

            for (int i = 0; i < len; i++)
            {
                descriptionMsg[i] = (char)data[descriptionPtr + i];
            }

            return descriptionMsg;

        }
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
            multipleSpellInstanceMax = 0;
            if (multipleSpellInstanceRange != null)
                multipleSpellInstanceRange = new byte[multipleSpellInstanceRange.Length];
            chargeSpellStartLevel2 = 0;
            chargeSpellStartLevel3 = 0;
            chargeSpellStartLevel4 = 0;
            chargeSpellOverflow = 0;
            rapidSpellMax = 0;
        }
    }
}
