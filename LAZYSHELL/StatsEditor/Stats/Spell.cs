using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL.StatsEditor.Stats
{
    public class Spell
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Spell Stats
        private int spellNum;
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
        #endregion
        #region Accessors
        public int SpellNum { get { return this.spellNum; } set { this.spellNum = value; } }
        public char[] Name { get { return this.name; } set { this.name = value; } }
        private bool descriptionError = false; public bool DescriptionError { get { return this.descriptionError; } set { this.descriptionError = value; } }
        private TextHelperReduced textHelperReduced; public TextHelperReduced TextHelperReduced { get { return this.textHelperReduced; } set { this.textHelperReduced = value; } }
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
        #endregion

        public Spell(byte[] data, int spellNum)
        {
            this.data = data;
            this.spellNum = spellNum;
            textHelperReduced = TextHelperReduced.Instance;
            InitializeSpell(data);
        }
        private void InitializeSpell(byte[] data)
        {
            byte temp = 0;

            name = new char[15];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(spellNum * 15) + 0x3A137F + i];

            if (spellNum <= 0x1A)
            {
                description = ParseDescription(data);
            }
            else
            {
                description = null;
            }
            int offset = (spellNum * 12) + 0x3A20F1;
            temp = BitManager.GetByte(data, offset); offset++;

            checkStats = (temp & 0x01) == 0x01;
            ignoreDefense = (temp & 0x02) == 0x02;
            checkMortality = (temp & 0x20) == 0x20;
            usableOverworld = (temp & 0x80) == 0x80;

            temp = BitManager.GetByte(data, offset); offset++;

            attackType = (byte)(temp & 0x01);
            switch (temp & 0x06)
            {
                case 0x02: effectType = 0; break;
                case 0x04: effectType = 1; break;
                default: effectType = 2; break;
            }

            maxAttack = (temp & 0x08) == 0x08;

            fpCost = BitManager.GetByte(data, offset); offset++;

            temp = BitManager.GetByte(data, offset); offset++;

            targetLiveAlly = (temp & 0x02) == 0x02;			// Usable on any ally
            targetEnemy = (temp & 0x04) == 0x04;		// Usable on any enemy
            targetAll = (temp & 0x10) == 0x10;			// Usable on on all
            targetWoundedOnly = (temp & 0x20) == 0x20;			// Usable on wounded
            targetOnePartyOnly = (temp & 0x40) == 0x40;		// Usable in one party only
            targetNotSelf = (temp & 0x80) == 0x80;		// Cannot use on self

            temp = BitManager.GetByte(data, offset); offset++;

            switch (temp & 0xF0)
            {
                case 0x10: inflictElement = 0; break;			// Ice
                case 0x20: inflictElement = 1; break;		// Thunder
                case 0x40: inflictElement = 2; break;		// Fire
                case 0x80: inflictElement = 3; break;		// Earth
                default: inflictElement = 4; break;
            }

            magicPower = BitManager.GetByte(data, offset); offset++;
            hitRate = BitManager.GetByte(data, offset); offset++;

            temp = BitManager.GetByte(data, offset); offset++;

            // STATUS EFFECT

            effectMute = (temp & 0x01) == 0x01;		// Mute
            effectSleep = (temp & 0x02) == 0x02;		// Sleep
            effectPoison = (temp & 0x04) == 0x04;		// Poison
            effectFear = (temp & 0x08) == 0x08;		// Fear
            effectMushroom = (temp & 0x20) == 0x20;	// Mushroom
            effectScarecrow = (temp & 0x40) == 0x40;	// Scarecrow
            effectInvincible = (temp & 0x80) == 0x80;	// Invincible

            temp = BitManager.GetByte(data, offset); offset += 2;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense

            temp = BitManager.GetByte(data, offset); offset++;

            switch (temp)
            {
                case 0x00: inflictFunction = 0; break;			// Ice
                case 0x01: inflictFunction = 1; break;			// Ice
                case 0x02: inflictFunction = 2; break;		// Thunder
                case 0x03: inflictFunction = 3; break;		// Fire
                case 0x04: inflictFunction = 4; break;		// Earth
                default: inflictFunction = 5; break;
            }

            hideDigits = BitManager.GetByte(data, offset) == 4;
        }
        public ushort Assemble(ushort descOffset)
        {
            ushort retLength = 0;

            BitManager.SetByteArray(data, 0x3A137F + (spellNum * 15), charToByte(name));

            if (spellNum <= 0x1A)
            {
                // Write offset to table
                BitManager.SetShort(data, 0x3A2B80 + spellNum * 2, descOffset);


                if (this.descriptionError)
                    System.Windows.Forms.MessageBox.Show("There is an error with Spell " + this.spellNum.ToString() + " Description, it has not been saved.");
                else
                {
                    retLength = (ushort)description.Length;
                    BitManager.SetByteArray(data, 0x3A0000 + descOffset, charToByte(description)); // Write the actual description
                }
            }

            int offset = (spellNum * 12) + 0x3A20F1;

            BitManager.SetBit(data, offset, 0, checkStats);
            BitManager.SetBit(data, offset, 1, ignoreDefense);
            BitManager.SetBit(data, offset, 5, checkMortality);
            BitManager.SetBit(data, offset, 7, usableOverworld);
            offset++;

            BitManager.SetByte(data, offset, attackType);
            if (effectType == 0) // Inflict
            {
                BitManager.SetBit(data, offset, 1, true);
                BitManager.SetBit(data, offset, 2, false);
            }
            else if (effectType == 1) // Nullify
            {
                BitManager.SetBit(data, offset, 1, false);
                BitManager.SetBit(data, offset, 2, true);
            }
            else if (effectType == 2) // {NONE}
            {
                BitManager.SetBit(data, offset, 1, false);
                BitManager.SetBit(data, offset, 2, false);
            }

            BitManager.SetBit(data, offset, 3, maxAttack);
            offset++;

            BitManager.SetByte(data, offset, fpCost); offset++;

            BitManager.SetBit(data, offset, 1, targetLiveAlly);
            BitManager.SetBit(data, offset, 2, targetEnemy);
            BitManager.SetBit(data, offset, 4, targetAll);
            BitManager.SetBit(data, offset, 5, targetWoundedOnly);
            BitManager.SetBit(data, offset, 6, targetOnePartyOnly);
            BitManager.SetBit(data, offset, 7, targetNotSelf);
            offset++;

            switch (inflictElement)
            {
                case 0: BitManager.SetByte(data, offset, 0x10); break;
                case 1: BitManager.SetByte(data, offset, 0x20); break;
                case 2: BitManager.SetByte(data, offset, 0x40); break;
                case 3: BitManager.SetByte(data, offset, 0x80); break;
                case 4: BitManager.SetByte(data, offset, 0x00); break;
            }
            offset++;

            BitManager.SetByte(data, offset, magicPower); offset++;
            BitManager.SetByte(data, offset, hitRate); offset++;

            BitManager.SetBit(data, offset, 0, effectMute);
            BitManager.SetBit(data, offset, 1, effectSleep);
            BitManager.SetBit(data, offset, 2, effectPoison);
            BitManager.SetBit(data, offset, 3, effectFear);
            BitManager.SetBit(data, offset, 5, effectMushroom);
            BitManager.SetBit(data, offset, 6, effectScarecrow);
            BitManager.SetBit(data, offset, 7, effectInvincible);
            offset++;

            BitManager.SetBit(data, offset, 3, changeMagicAttack);
            BitManager.SetBit(data, offset, 4, changeAttack);
            BitManager.SetBit(data, offset, 5, changeMagicDefense);
            BitManager.SetBit(data, offset, 6, changeDefense);
            offset += 2;

            switch (inflictFunction)
            {
                case 0: BitManager.SetByte(data, offset, 0x00); break;
                case 1: BitManager.SetByte(data, offset, 0x01); break;
                case 2: BitManager.SetByte(data, offset, 0x02); break;
                case 3: BitManager.SetByte(data, offset, 0x03); break;
                case 4: BitManager.SetByte(data, offset, 0x04); break;
                default: BitManager.SetByte(data, offset, 0xFF); break;
            }
            offset++;

            if (hideDigits == true)
                BitManager.SetByte(data, offset, 0x04);

            else
                BitManager.SetByte(data, offset, 0x00);

            return retLength;
        }

        private char[] ParseDescription(byte[] data)
        {

            int descriptionPtr = 0x3A0000 + BitManager.GetShort(data, 0x3A2B80 + spellNum * 2);

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
        private byte[] charToByte(char[] toByte)
        {
            byte[] arr = new byte[toByte.Length];
            for (int i = 0; i < toByte.Length; i++)
            {
                arr[i] = (byte)toByte[i];
            }
            return arr;
        }
    }
}
