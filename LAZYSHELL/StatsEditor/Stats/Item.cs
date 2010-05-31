using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL.StatsEditor.Stats
{
    public class Item
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Item Stats
        private int itemNum;
        private char[] name;
        private char[] description;
        private ushort coinValue;
        private sbyte speed;
        private sbyte attack;
        private sbyte defense;
        private sbyte magicAttack;
        private sbyte magicDefense;
        private byte attackRange;
        private byte attackType;
        private byte elemAttack;
        private bool hideDigits;
        private byte inflictionAmount;
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
        private bool elemIceNull;
        private bool elemFireNull;
        private bool elemThunderNull;
        private bool elemJumpNull;
        private bool elemIceWeak;
        private bool elemFireWeak;
        private bool elemThunderWeak;
        private bool elemJumpWeak;
        private bool equipMario;
        private bool equipToadstool;
        private bool equipBowser;
        private bool equipGeno;
        private bool equipMallow;
        private bool usageBattleMenu;
        private bool usageOverworldMenu;
        private bool usageReusable;
        private bool usageInstantDeath;
        private bool restoreFP;
        private bool restoreHP;
        private bool targetLiveAlly;
        private bool targetEnemy;
        private bool targetAll;
        private bool targetWoundedOnly;
        private bool targetOnePartyOnly;
        private bool targetNotSelf;
        private byte itemType = 0;
        private byte cursorBehavior;
        private byte inflictFunction;
        #endregion
        #region Accessors
        public int ItemNum { get { return this.itemNum; } set { this.itemNum = value; } }
        public char[] Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public bool SetDescription(string value, bool symbols)
        {
            this.description = textHelperReduced.EncodeText(value.ToCharArray(), symbols, 1);
            this.descriptionError = textHelperReduced.Error;
            return !descriptionError;
        }
        public string GetDescription(bool symbols)
        {
            if (!descriptionError) return new string(textHelperReduced.DecodeText(description, symbols, 1));
            else return new string(description);
        }
        public char[] RawDescription { get { return this.description; } set { this.description = value; } }
        public ushort CoinValue { get { return this.coinValue; } set { this.coinValue = value; } }
        public sbyte Speed { get { return this.speed; } set { this.speed = value; } }
        public sbyte Attack { get { return this.attack; } set { this.attack = value; } }
        public sbyte Defense { get { return this.defense; } set { this.defense = value; } }
        public sbyte MagicAttack { get { return this.magicAttack; } set { this.magicAttack = value; } }
        public sbyte MagicDefense { get { return this.magicDefense; } set { this.magicDefense = value; } }
        public byte AttackRange { get { return this.attackRange; } set { this.attackRange = value; } }
        public byte AttackType { get { return this.attackType; } set { this.attackType = value; } }
        public byte ElemAttack { get { return this.elemAttack; } set { this.elemAttack = value; } }
        public bool HideDigits { get { return this.hideDigits; } set { this.hideDigits = value; } }
        public byte InflictionAmount { get { return this.inflictionAmount; } set { this.inflictionAmount = value; } }
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
        public bool ElemIceNull { get { return this.elemIceNull; } set { this.elemIceNull = value; } }
        public bool ElemFireNull { get { return this.elemFireNull; } set { this.elemFireNull = value; } }
        public bool ElemThunderNull { get { return this.elemThunderNull; } set { this.elemThunderNull = value; } }
        public bool ElemJumpNull { get { return this.elemJumpNull; } set { this.elemJumpNull = value; } }
        public bool ElemIceWeak { get { return this.elemIceWeak; } set { this.elemIceWeak = value; } }
        public bool ElemFireWeak { get { return this.elemFireWeak; } set { this.elemFireWeak = value; } }
        public bool ElemThunderWeak { get { return this.elemThunderWeak; } set { this.elemThunderWeak = value; } }
        public bool ElemJumpWeak { get { return this.elemJumpWeak; } set { this.elemJumpWeak = value; } }
        public bool EquipMario { get { return this.equipMario; } set { this.equipMario = value; } }
        public bool EquipToadstool { get { return this.equipToadstool; } set { this.equipToadstool = value; } }
        public bool EquipBowser { get { return this.equipBowser; } set { this.equipBowser = value; } }
        public bool EquipGeno { get { return this.equipGeno; } set { this.equipGeno = value; } }
        public bool EquipMallow { get { return this.equipMallow; } set { this.equipMallow = value; } }
        public bool UsageBattleMenu { get { return this.usageBattleMenu; } set { this.usageBattleMenu = value; } }
        public bool UsageOverworldMenu { get { return this.usageOverworldMenu; } set { this.usageOverworldMenu = value; } }
        public bool UsageReusable { get { return this.usageReusable; } set { this.usageReusable = value; } }
        public bool UsageInstantDeath { get { return this.usageInstantDeath; } set { this.usageInstantDeath = value; } }
        public bool RestoreFP { get { return this.restoreFP; } set { this.restoreFP = value; } }
        public bool RestoreHP { get { return this.restoreHP; } set { this.restoreHP = value; } }
        public bool TargetLiveAlly { get { return this.targetLiveAlly; } set { this.targetLiveAlly = value; } }
        public bool TargetEnemy { get { return this.targetEnemy; } set { this.targetEnemy = value; } }
        public bool TargetAll { get { return this.targetAll; } set { this.targetAll = value; } }
        public bool TargetWoundedOnly { get { return this.targetWoundedOnly; } set { this.targetWoundedOnly = value; } }
        public bool TargetOnePartyOnly { get { return this.targetOnePartyOnly; } set { this.targetOnePartyOnly = value; } }
        public bool TargetNotSelf { get { return this.targetNotSelf; } set { this.targetNotSelf = value; } }
        public byte ItemType { get { return this.itemType; } set { this.itemType = value; } }
        public byte CursorBehavior { get { return this.cursorBehavior; } set { this.cursorBehavior = value; } }
        public byte InflictFunction { get { return this.inflictFunction; } set { this.inflictFunction = value; } }
        #endregion
        public Item(byte[] data, int itemNum)
        {
            this.data = data;
            this.itemNum = itemNum;
            this.textHelperReduced = TextHelperReduced.Instance;
            InitializeItem();
        }

        private void InitializeItem()
        {
            byte temp = 0;

            /***************************************************************
             * Item data
             * ************************************************************/

            name = new char[15];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(itemNum * 15) + 0x3A46EF + i];

            if (itemNum <= 0xB0)
            {
                description = ParseDescription(data);
            }
            else
            {
                description = null;
            }
            int offset = (itemNum * 2) + 0x3A40F2;

            coinValue = BitManager.GetShort(data, offset);

            offset = (itemNum * 18) + 0x3A014D;
            temp = BitManager.GetByte(data, offset); offset++;

            switch (temp & 3)						// ITEM TYPE
            {
                case 0x00: itemType = 0; break;				// Weapon
                case 0x01: itemType = 1; break;				// Armor
                case 0x02: itemType = 2; break;				// Accessory
                case 0x03: itemType = 3; break;				// Item
                default: itemType = 0; break;
            }

            // ITEM USAGE

            usageBattleMenu = (temp & 0x08) == 0x08;		// Usable in battle
            usageOverworldMenu = (temp & 0x10) == 0x10;	// Usable in overworld menu
            usageReusable = (temp & 0x20) == 0x20;	// Reusable
            usageInstantDeath = (temp & 0x80) == 0x80;		// Death protection

            temp = BitManager.GetByte(data, offset); offset++;
            // ATTACK TYPE

            if ((temp & 0x02) == 0x02)
                attackType = 0;		// Inflict
            else if ((temp & 0x01) == 0x01)
                attackType = 1;		// Protect
            else if ((temp & 0x04) == 0x04)
                attackType = 2;		// Nullify
            else
                attackType = 3;     // None

            cursorBehavior = (temp & 0x20) == 0x20 ? (byte)1 : (byte)0;// CURSOR BEHAVIOR

            restoreFP = (temp & 0x40) == 0x40;		// Restore only if FP not maxed out
            restoreHP = (temp & 0x80) == 0x80;		// Restore only if HP not maxed out

            temp = BitManager.GetByte(data, offset); offset++;

            equipMario = (temp & 0x01) == 0x01;		// Mario
            equipToadstool = (temp & 0x02) == 0x02;	// Toadstool
            equipBowser = (temp & 0x04) == 0x04;		// Bowser
            equipGeno = (temp & 0x08) == 0x08;			// Geno
            equipMallow = (temp & 0x10) == 0x10;		// Mallow

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
                case 0x10: elemAttack = 0; break;			// Ice
                case 0x20: elemAttack = 1; break;		// Thunder
                case 0x40: elemAttack = 2; break;		// Fire
                case 0x80: elemAttack = 3; break;		// Earth
                default: elemAttack = 4; break;
            }

            temp = BitManager.GetByte(data, offset); offset++;

            // ELEMENTAL ATTRIBUTES: NULLIFY

            elemIceNull = (temp & 0x10) == 0x10;		// Ice
            elemThunderNull = (temp & 0x20) == 0x20;	// Thunder
            elemFireNull = (temp & 0x40) == 0x40;	// Fire
            elemJumpNull = (temp & 0x80) == 0x80;	// Earth

            temp = BitManager.GetByte(data, offset); offset++;

            // ELEMENTAL ATTRIBUTES: WEAKNESS

            elemIceWeak = (temp & 0x10) == 0x10;		// Ice
            elemThunderWeak = (temp & 0x20) == 0x20;	// Thunder
            elemFireWeak = (temp & 0x40) == 0x40;	// Fire
            elemJumpWeak = (temp & 0x80) == 0x80;	// Earth

            temp = BitManager.GetByte(data, offset); offset++;

            // STATUS EFFECT

            effectMute = (temp & 0x01) == 0x01;		// Mute
            effectSleep = (temp & 0x02) == 0x02;		// Sleep
            effectPoison = (temp & 0x04) == 0x04;		// Poison
            effectFear = (temp & 0x08) == 0x08;		// Fear
            effectMushroom = (temp & 0x20) == 0x20;	// Mushroom
            effectScarecrow = (temp & 0x40) == 0x40;	// Scarecrow
            effectInvincible = (temp & 0x80) == 0x80;	// Invincible

            temp = BitManager.GetByte(data, offset); offset++;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense

            speed = (sbyte)BitManager.GetByte(data, offset); offset++;
            attack = (sbyte)BitManager.GetByte(data, offset); offset++;
            defense = (sbyte)BitManager.GetByte(data, offset); offset++;
            magicAttack = (sbyte)BitManager.GetByte(data, offset); offset++;
            magicDefense = (sbyte)BitManager.GetByte(data, offset); offset++;
            attackRange = BitManager.GetByte(data, offset); offset++;
            inflictionAmount = BitManager.GetByte(data, offset); offset++;

            temp = BitManager.GetByte(data, offset); offset++;
            switch (temp)							// INFLICT FUNCTION
            {
                case 0x00: inflictFunction = 0; break;
                case 0x01: inflictFunction = 1; break;			// Revive
                case 0x02: inflictFunction = 2; break;			// Recover FP
                case 0x04: inflictFunction = 3; break;			// etc...
                case 0x05: inflictFunction = 4; break;
                case 0x06: inflictFunction = 5; break;
                case 0x07: inflictFunction = 6; break;
                case 0xFF: inflictFunction = 7; break;
                default: inflictFunction = 0; break;
            }

            temp = BitManager.GetByte(data, offset); offset++;

            hideDigits = (temp & 0x04) == 0x04;	// Hide Digits

        }
        public ushort Assemble(ushort descOffset)
        {
            ushort retLength = 0;
            byte[] temp = charToByte(name);
            int offset = 0x3A46EF + (itemNum * 15);
            BitManager.SetByteArray(data, offset, charToByte(name));

            if (itemNum <= 0xB0)
            {
                // Write offset to table
                BitManager.SetShort(data, 0x3A2F20 + itemNum * 2, descOffset);

                if (this.descriptionError)
                    System.Windows.Forms.MessageBox.Show("There is an error with Item " + this.itemNum.ToString() + " Item Description, it has not been saved.");
                else
                {
                    retLength = (ushort)description.Length;
                    BitManager.SetByteArray(data, 0x3A0000 + descOffset, charToByte(description)); // Write the actual description
                }
            }

            // COIN VALUE
            offset = (itemNum * 2) + 0x3A40F2;

            BitManager.SetShort(data, offset, coinValue);

            //**** ITEM STATS
            offset = (itemNum * 18) + 0x3A014D;
            BitManager.SetByte(data, offset, itemType);
            BitManager.SetBit(data, offset, 3, usageBattleMenu);
            BitManager.SetBit(data, offset, 4, usageOverworldMenu);
            BitManager.SetBit(data, offset, 5, usageReusable);
            BitManager.SetBit(data, offset, 7, usageInstantDeath);
            offset++;

            switch (attackType)
            {
                case 0: BitManager.SetByte(data, offset, 0x02); break;
                case 1: BitManager.SetByte(data, offset, 0x01); break;
                case 2: BitManager.SetByte(data, offset, 0x04); break;
                case 3: BitManager.SetByte(data, offset, 0x00); break;
            }

            if (cursorBehavior == 1)
                BitManager.SetBit(data, offset, 5, true);

            BitManager.SetBit(data, offset, 6, restoreFP);
            BitManager.SetBit(data, offset, 7, restoreHP);
            offset++;


            BitManager.SetBit(data, offset, 0, equipMario);
            BitManager.SetBit(data, offset, 1, equipToadstool);
            BitManager.SetBit(data, offset, 2, equipBowser);
            BitManager.SetBit(data, offset, 3, equipGeno);
            BitManager.SetBit(data, offset, 4, equipMallow);
            offset++;

            BitManager.SetBit(data, offset, 1, targetLiveAlly);
            BitManager.SetBit(data, offset, 2, targetEnemy);
            BitManager.SetBit(data, offset, 4, targetAll);
            BitManager.SetBit(data, offset, 5, targetWoundedOnly);
            BitManager.SetBit(data, offset, 6, targetOnePartyOnly);
            BitManager.SetBit(data, offset, 7, targetNotSelf);
            offset++;

            switch (elemAttack)
            {
                case 0: BitManager.SetByte(data, offset, 0x10); break;			// Ice
                case 1: BitManager.SetByte(data, offset, 0x20); break;		// Thunder
                case 2: BitManager.SetByte(data, offset, 0x40); break;		// Fire
                case 3: BitManager.SetByte(data, offset, 0x80); break;		// Earth
                case 4: BitManager.SetByte(data, offset, 0x00); break;      // NONE
            }
            offset++;

            // ELEMENTAL ATTRIBUTES: NULLIFY
            BitManager.SetBit(data, offset, 4, elemIceNull);
            BitManager.SetBit(data, offset, 5, elemThunderNull);
            BitManager.SetBit(data, offset, 6, elemFireNull);
            BitManager.SetBit(data, offset, 7, elemJumpNull);
            offset++;

            // ELEMENTAL ATTRIBUTES: WEAKNESS
            BitManager.SetBit(data, offset, 4, elemIceWeak);
            BitManager.SetBit(data, offset, 5, elemThunderWeak);
            BitManager.SetBit(data, offset, 6, elemFireWeak);
            BitManager.SetBit(data, offset, 7, elemJumpWeak);
            offset++;

            // STATUS EFFECT
            BitManager.SetBit(data, offset, 0, effectMute);
            BitManager.SetBit(data, offset, 1, effectSleep);
            BitManager.SetBit(data, offset, 2, effectPoison);
            BitManager.SetBit(data, offset, 3, effectFear);
            BitManager.SetBit(data, offset, 5, effectMushroom);
            BitManager.SetBit(data, offset, 6, effectScarecrow);
            BitManager.SetBit(data, offset, 7, effectInvincible);
            offset++;

            // STATUS CHANGE
            BitManager.SetBit(data, offset, 3, changeMagicAttack);
            BitManager.SetBit(data, offset, 4, changeAttack);
            BitManager.SetBit(data, offset, 5, changeMagicDefense);
            BitManager.SetBit(data, offset, 6, changeDefense);
            offset++;

            BitManager.SetByte(data, offset, (byte)speed); offset++;
            BitManager.SetByte(data, offset, (byte)attack); offset++;
            BitManager.SetByte(data, offset, (byte)defense); offset++;
            BitManager.SetByte(data, offset, (byte)magicAttack); offset++;
            BitManager.SetByte(data, offset, (byte)magicDefense); offset++;
            BitManager.SetByte(data, offset, attackRange); offset++;
            BitManager.SetByte(data, offset, inflictionAmount); offset++;

            switch (inflictFunction)							// INFLICT FUNCTION
            {
                case 0: BitManager.SetByte(data, offset, 0x00); break;			// Revive
                case 1: BitManager.SetByte(data, offset, 0x01); break;			// Recover FP
                case 2: BitManager.SetByte(data, offset, 0x02); break;			// etc...
                case 3: BitManager.SetByte(data, offset, 0x04); break;
                case 4: BitManager.SetByte(data, offset, 0x05); break;
                case 5: BitManager.SetByte(data, offset, 0x06); break;
                case 6: BitManager.SetByte(data, offset, 0x07); break;
                case 7: BitManager.SetByte(data, offset, 0xFF); break;
            }
            offset++;

            BitManager.SetBit(data, offset, 2, hideDigits);

            return retLength;

        }
        public void Clear()
        {
            coinValue = 0;
            speed = 0;
            attack = 0;
            defense = 0;
            magicAttack = 0;
            magicDefense = 0;
            attackRange = 0;
            attackType = 0;
            elemAttack = 0;
            hideDigits = false;
            inflictionAmount = 0;
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
            elemIceNull = false;
            elemFireNull = false;
            elemThunderNull = false;
            elemJumpNull = false;
            elemIceWeak = false;
            elemFireWeak = false;
            elemThunderWeak = false;
            elemJumpWeak = false;
            equipMario = false;
            equipToadstool = false;
            equipBowser = false;
            equipGeno = false;
            equipMallow = false;
            usageBattleMenu = false;
            usageOverworldMenu = false;
            usageReusable = false;
            usageInstantDeath = false;
            restoreFP = false;
            restoreHP = false;
            targetLiveAlly = false;
            targetEnemy = false;
            targetAll = false;
            targetWoundedOnly = false;
            targetOnePartyOnly = false;
            targetNotSelf = false;
            itemType = 0;
            cursorBehavior = 0;
            inflictFunction = 0;
            name = new char[0];
            description = new char[0];
        }

        private char[] ParseDescription(byte[] data)
        {
            int descriptionPtr = 0x3A0000 + BitManager.GetShort(data, 0x3A2F20 + itemNum * 2);

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
        #region Text Helper Code
        private bool descriptionError = false; public bool DescriptionError { get { return this.descriptionError; } set { this.descriptionError = value; } }
        public TextHelperReduced textHelperReduced;
        private int caretPositionSymbol = 0; public int CaretPositionSymbol { get { return this.caretPositionSymbol; } set { this.caretPositionSymbol = value; } }
        private int caretPositionNotSymbol = 0; public int CaretPositionNotSymbol { get { return this.caretPositionNotSymbol; } set { this.caretPositionNotSymbol = value; } }
        #endregion
    }
}
