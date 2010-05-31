using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL.StatsEditor.Stats
{
    public class Attack
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Attack Stats
        private int attackNum;
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
        public int AttackNum { get { return this.attackNum; } set { this.attackNum = value; } }
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

        public Attack(byte[] data, int attackNum)
        {
            this.data = data;
            this.attackNum = attackNum;
            InitializeAttack();
        }

        private void InitializeAttack()
        {
            byte temp = 0;

            name = new char[13];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(attackNum * 13) + 0x3959F4 + i];
            
            int offset = (attackNum * 4) + 0x391226;

            temp = BitManager.GetByte(data, offset); offset++;

            attackLevel = (byte)(temp & 0x07);

            maxAttack = (temp & 0x08) == 0x08;
            noDamageA = (temp & 0x10) == 0x10;
            hideDigits = (temp & 0x20) == 0x20;
            noDamageB = (temp & 0x40) == 0x40;

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

            temp = BitManager.GetByte(data, offset); offset++;

            // STATUS CHANGE

            changeMagicAttack = (temp & 0x08) == 0x08;		// Magic Attack
            changeAttack = (temp & 0x10) == 0x10;			// Attack
            changeMagicDefense = (temp & 0x20) == 0x20;		// Magic Defense
            changeDefense = (temp & 0x40) == 0x40;			// Defense
        }
        public void Assemble()
        {
            BitManager.SetByteArray(data, 0x3959F4 + (attackNum * 13), charToByte(name));

            int offset = (attackNum * 4) + 0x391226;
            BitManager.SetByte(data, offset, attackLevel);
            BitManager.SetBit(data, offset, 3, maxAttack);
            BitManager.SetBit(data, offset, 4, noDamageA);
            BitManager.SetBit(data, offset, 5, hideDigits);
            BitManager.SetBit(data, offset, 6, noDamageB);
            offset++;

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
