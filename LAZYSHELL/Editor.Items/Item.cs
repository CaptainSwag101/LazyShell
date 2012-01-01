using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Item : Element
    {
        [NonSerialized()]
        private byte[] data; 
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index;} set { index = value;} }

        #region Item Stats
        private int index;
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
        private byte weaponStartLevel1;
        private byte weaponStartLevel2;
        private byte weaponEndLevel2;
        private byte weaponEndLevel1;
        #endregion
        #region Accessors
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
        public byte WeaponStartLevel1 { get { return this.weaponStartLevel1; } set { this.weaponStartLevel1 = value; } }
        public byte WeaponStartLevel2 { get { return this.weaponStartLevel2; } set { this.weaponStartLevel2 = value; } }
        public byte WeaponEndLevel2 { get { return this.weaponEndLevel2; } set { this.weaponEndLevel2 = value; } }
        public byte WeaponEndLevel1 { get { return this.weaponEndLevel1; } set { this.weaponEndLevel1 = value; } }
        #endregion
        public Item(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
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
                name[i] = (char)data[(index * 15) + 0x3A46EF + i];

            if (index <= 0xB0)
            {
                description = ParseDescription(data);
            }
            else
            {
                description = null;
            }
            int offset = (index * 2) + 0x3A40F2;

            coinValue = Bits.GetShort(data, offset);

            offset = (index * 18) + 0x3A014D;
            temp = data[offset]; offset++;

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

            temp = data[offset]; offset++;
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

            temp = data[offset]; offset++;

            equipMario = (temp & 0x01) == 0x01;		// Mario
            equipToadstool = (temp & 0x02) == 0x02;	// Toadstool
            equipBowser = (temp & 0x04) == 0x04;		// Bowser
            equipGeno = (temp & 0x08) == 0x08;			// Geno
            equipMallow = (temp & 0x10) == 0x10;		// Mallow

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
                case 0x10: elemAttack = 0; break;			// Ice
                case 0x20: elemAttack = 1; break;		// Thunder
                case 0x40: elemAttack = 2; break;		// Fire
                case 0x80: elemAttack = 3; break;		// Earth
                default: elemAttack = 4; break;
            }

            temp = data[offset]; offset++;

            // ELEMENTAL ATTRIBUTES: NULLIFY

            elemIceNull = (temp & 0x10) == 0x10;		// Ice
            elemThunderNull = (temp & 0x20) == 0x20;	// Thunder
            elemFireNull = (temp & 0x40) == 0x40;	// Fire
            elemJumpNull = (temp & 0x80) == 0x80;	// Earth

            temp = data[offset]; offset++;

            // ELEMENTAL ATTRIBUTES: WEAKNESS

            elemIceWeak = (temp & 0x10) == 0x10;		// Ice
            elemThunderWeak = (temp & 0x20) == 0x20;	// Thunder
            elemFireWeak = (temp & 0x40) == 0x40;	// Fire
            elemJumpWeak = (temp & 0x80) == 0x80;	// Earth

            temp = data[offset]; offset++;

            // STATUS EFFECT

            effectMute = (temp & 0x01) == 0x01;		// Mute
            effectSleep = (temp & 0x02) == 0x02;		// Sleep
            effectPoison = (temp & 0x04) == 0x04;		// Poison
            effectFear = (temp & 0x08) == 0x08;		// Fear
            effectMushroom = (temp & 0x20) == 0x20;	// Mushroom
            effectScarecrow = (temp & 0x40) == 0x40;	// Scarecrow
            effectInvincible = (temp & 0x80) == 0x80;	// Invincible

            temp = data[offset]; offset++;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense

            speed = (sbyte)data[offset]; offset++;
            attack = (sbyte)data[offset]; offset++;
            defense = (sbyte)data[offset]; offset++;
            magicAttack = (sbyte)data[offset]; offset++;
            magicDefense = (sbyte)data[offset]; offset++;
            attackRange = data[offset]; offset++;
            inflictionAmount = data[offset]; offset++;

            temp = data[offset]; offset++;
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

            temp = data[offset]; offset++;

            hideDigits = (temp & 0x04) == 0x04;	// Hide Digits

            // timing
            if (index < 37)
            {
                offset = (index * 4) + 0x3A438A;
                weaponStartLevel1 = data[offset]; offset++;
                weaponStartLevel2 = data[offset]; offset++;
                weaponEndLevel2 = data[offset]; offset++;
                weaponEndLevel1 = data[offset]; offset++;
            }
        }
        public ushort Assemble(ushort descOffset)
        {
            ushort retLength = 0;
            int offset = 0x3A46EF + (index * 15);
            Bits.SetCharArray(data, offset, name);

            if (index <= 0xB0)
            {
                // Write offset to table
                Bits.SetShort(data, 0x3A2F20 + index * 2, descOffset);

                if (this.descriptionError)
                    System.Windows.Forms.MessageBox.Show("There is an error with Item " + this.index.ToString() + " Item Description, it has not been saved.");
                else
                {
                    retLength = (ushort)description.Length;
                    Bits.SetCharArray(data, 0x3A0000 + descOffset, description); // Write the actual description
                }
            }

            // COIN VALUE
            offset = (index * 2) + 0x3A40F2;

            Bits.SetShort(data, offset, coinValue);

            //**** ITEM STATS
            offset = (index * 18) + 0x3A014D;
            Bits.SetByte(data, offset, itemType);
            Bits.SetBit(data, offset, 3, usageBattleMenu);
            Bits.SetBit(data, offset, 4, usageOverworldMenu);
            Bits.SetBit(data, offset, 5, usageReusable);
            Bits.SetBit(data, offset, 7, usageInstantDeath);
            offset++;

            switch (attackType)
            {
                case 0: Bits.SetByte(data, offset, 0x02); break;
                case 1: Bits.SetByte(data, offset, 0x01); break;
                case 2: Bits.SetByte(data, offset, 0x04); break;
                case 3: Bits.SetByte(data, offset, 0x00); break;
            }

            if (cursorBehavior == 1)
                Bits.SetBit(data, offset, 5, true);

            Bits.SetBit(data, offset, 6, restoreFP);
            Bits.SetBit(data, offset, 7, restoreHP);
            offset++;


            Bits.SetBit(data, offset, 0, equipMario);
            Bits.SetBit(data, offset, 1, equipToadstool);
            Bits.SetBit(data, offset, 2, equipBowser);
            Bits.SetBit(data, offset, 3, equipGeno);
            Bits.SetBit(data, offset, 4, equipMallow);
            offset++;

            Bits.SetBit(data, offset, 1, targetLiveAlly);
            Bits.SetBit(data, offset, 2, targetEnemy);
            Bits.SetBit(data, offset, 4, targetAll);
            Bits.SetBit(data, offset, 5, targetWoundedOnly);
            Bits.SetBit(data, offset, 6, targetOnePartyOnly);
            Bits.SetBit(data, offset, 7, targetNotSelf);
            offset++;

            switch (elemAttack)
            {
                case 0: Bits.SetByte(data, offset, 0x10); break;			// Ice
                case 1: Bits.SetByte(data, offset, 0x20); break;		// Thunder
                case 2: Bits.SetByte(data, offset, 0x40); break;		// Fire
                case 3: Bits.SetByte(data, offset, 0x80); break;		// Earth
                case 4: Bits.SetByte(data, offset, 0x00); break;      // NONE
            }
            offset++;

            // ELEMENTAL ATTRIBUTES: NULLIFY
            Bits.SetBit(data, offset, 4, elemIceNull);
            Bits.SetBit(data, offset, 5, elemThunderNull);
            Bits.SetBit(data, offset, 6, elemFireNull);
            Bits.SetBit(data, offset, 7, elemJumpNull);
            offset++;

            // ELEMENTAL ATTRIBUTES: WEAKNESS
            Bits.SetBit(data, offset, 4, elemIceWeak);
            Bits.SetBit(data, offset, 5, elemThunderWeak);
            Bits.SetBit(data, offset, 6, elemFireWeak);
            Bits.SetBit(data, offset, 7, elemJumpWeak);
            offset++;

            // STATUS EFFECT
            Bits.SetBit(data, offset, 0, effectMute);
            Bits.SetBit(data, offset, 1, effectSleep);
            Bits.SetBit(data, offset, 2, effectPoison);
            Bits.SetBit(data, offset, 3, effectFear);
            Bits.SetBit(data, offset, 5, effectMushroom);
            Bits.SetBit(data, offset, 6, effectScarecrow);
            Bits.SetBit(data, offset, 7, effectInvincible);
            offset++;

            // STATUS CHANGE
            Bits.SetBit(data, offset, 3, changeMagicAttack);
            Bits.SetBit(data, offset, 4, changeAttack);
            Bits.SetBit(data, offset, 5, changeMagicDefense);
            Bits.SetBit(data, offset, 6, changeDefense);
            offset++;

            Bits.SetByte(data, offset, (byte)speed); offset++;
            Bits.SetByte(data, offset, (byte)attack); offset++;
            Bits.SetByte(data, offset, (byte)defense); offset++;
            Bits.SetByte(data, offset, (byte)magicAttack); offset++;
            Bits.SetByte(data, offset, (byte)magicDefense); offset++;
            Bits.SetByte(data, offset, attackRange); offset++;
            Bits.SetByte(data, offset, inflictionAmount); offset++;

            switch (inflictFunction)							// INFLICT FUNCTION
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;			// Revive
                case 1: Bits.SetByte(data, offset, 0x01); break;			// Recover FP
                case 2: Bits.SetByte(data, offset, 0x02); break;			// etc...
                case 3: Bits.SetByte(data, offset, 0x04); break;
                case 4: Bits.SetByte(data, offset, 0x05); break;
                case 5: Bits.SetByte(data, offset, 0x06); break;
                case 6: Bits.SetByte(data, offset, 0x07); break;
                case 7: Bits.SetByte(data, offset, 0xFF); break;
            }
            offset++;

            Bits.SetBit(data, offset, 2, hideDigits);

            // timing
            if (index < 37)
            {
                offset = (index * 4) + 0x3A438A;
                Bits.SetByte(data, offset, weaponStartLevel1); offset++;
                Bits.SetByte(data, offset, weaponStartLevel2); offset++;
                Bits.SetByte(data, offset, weaponEndLevel2); offset++;
                Bits.SetByte(data, offset, weaponEndLevel1); offset++;
            }
            return retLength;
        }
        public override void Clear()
        {
            Bits.Fill(name, '\x20');
            description = new char[0];
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
        }

        private char[] ParseDescription(byte[] data)
        {
            int descriptionPtr = 0x3A0000 + Bits.GetShort(data, 0x3A2F20 + index * 2);

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
        #region Text Helper Code
        private bool descriptionError = false; public bool DescriptionError { get { return this.descriptionError; } set { this.descriptionError = value; } }
        public TextHelperReduced textHelperReduced { get { return TextHelperReduced.Instance; } }
        private int caretPositionSymbol = 0; public int CaretPositionSymbol { get { return this.caretPositionSymbol; } set { this.caretPositionSymbol = value; } }
        private int caretPositionNotSymbol = 0; public int CaretPositionNotSymbol { get { return this.caretPositionNotSymbol; } set { this.caretPositionNotSymbol = value; } }
        #endregion
    }
}
