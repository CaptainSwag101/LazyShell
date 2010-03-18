using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.StatsEditor.Stats
{
    public class Attack
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Attack Stats
        private int attackNum;
        private string name;
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
        public string Name { get { return this.name; } set { this.name = PadString(value, 13); } }
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

            name = ParseName(data);

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
            BitManager.SetByteArray(data, 0x3959F4 + (attackNum * 13), strToByte(name));

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

        private string ParseName(byte[] data)
        {
            int namePtr = 0x3959F4;
            byte[] temp = new byte[13];

            for (int i = 0; i < 13; i++)
            {
                temp[i] = (byte)data[namePtr + (attackNum * 13) + i];
                if (temp[i] == 0x2A) temp[i] = (byte)'.';
                if (temp[i] == 0x7F) temp[i] = (byte)'_';
                if (temp[i] == 0x9C) temp[i] = (byte)'&';
            }

            return byteToStr(temp);

        }

        #region Helper Methods
        private string byteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }
        private byte[] strToByte(string toByte)
        {
            byte[] arr = new byte[toByte.Length];
            char[] str = toByte.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = (byte)str[i];
                if (arr[i] == '.') arr[i] = (byte)0x2A;
                if (arr[i] == ' ' && i == 0) arr[i] = (byte)0x7F;
                if (arr[i] == '_') arr[i] = i == 0 ? (byte)0x7F : (byte)0x20;
                if (arr[i] == '&') arr[i] = (byte)0x9C;
            }
            return arr;
        }
        private string PadString(string source, int maxlen)
        {
            if (source.Length > maxlen)
                return source.Substring(0, maxlen);

            char[] temp = new char[maxlen];
            int len = source.Length;

            source.ToCharArray().CopyTo(temp, 0);

            for (; len < maxlen; len++)
                temp[len] = '\x20';

            return new string(temp);
        }
        #endregion

    }
}
