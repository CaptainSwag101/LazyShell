using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Attack : Element
    {
        [NonSerialized()]
        private byte[] data; 
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index;} set { index = value;} }

        #region Attack Stats
        private int index;
        private char[] name;
        private byte hitRate;
        private byte attackLevel;
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
        private bool maxAttack;
        private bool noDamageA;
        private bool noDamageB;
        private bool hideDigits;
        #endregion

        #region Accessors
        public char[] Name { get { return this.name; } set { this.name = value; } }
        public byte HitRate { get { return this.hitRate; } set { this.hitRate = value; } }
        public byte AttackLevel { get { return this.attackLevel; } set { this.attackLevel = value; } }
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
        public bool MaxAttack { get { return this.maxAttack; } set { this.maxAttack = value; } }
        public bool NoDamageA { get { return this.noDamageA; } set { this.noDamageA = value; } }
        public bool NoDamageB { get { return this.noDamageB; } set { this.noDamageB = value; } }
        public bool HideDigits { get { return this.hideDigits; } set { this.hideDigits = value; } }
        #endregion

        public Attack(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeAttack();
        }

        private void InitializeAttack()
        {
            byte temp = 0;

            name = new char[13];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(index * 13) + 0x3959F4 + i];

            int offset = (index * 4) + 0x391226;

            temp = data[offset]; offset++;

            attackLevel = (byte)(temp & 0x07);

            maxAttack = (temp & 0x08) == 0x08;
            noDamageA = (temp & 0x10) == 0x10;
            hideDigits = (temp & 0x20) == 0x20;
            noDamageB = (temp & 0x40) == 0x40;

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

            temp = data[offset]; offset++;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense
        }
        public void Assemble()
        {
            Bits.SetCharArray(data, 0x3959F4 + (index * 13), name);

            int offset = (index * 4) + 0x391226;
            Bits.SetByte(data, offset, attackLevel);
            Bits.SetBit(data, offset, 3, maxAttack);
            Bits.SetBit(data, offset, 4, noDamageA);
            Bits.SetBit(data, offset, 5, hideDigits);
            Bits.SetBit(data, offset, 6, noDamageB);
            offset++;

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
        }
        public override void Clear()
        {
            Bits.Fill(name, '\x20');
            hitRate = 0;
            attackLevel = 0;
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
            maxAttack = false;
            noDamageA = false;
            noDamageB = false;
            hideDigits = false;
        }
    }
}
