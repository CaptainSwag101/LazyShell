using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMRPGED.StatsEditor.Stats
{
    [Serializable()]
    public class Monster
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Monster Stats
        private int monsterNum;
        private string name;
        private char[] psychoMsg;
        private bool psychoMsgError = false;
        private ushort hp;
        private byte speed;
        private byte attack;
        private byte defense;
        private byte magicAttack;
        private byte magicDefense;
        private byte fp;
        private byte evadePercent;
        private byte magicEvadePercent;
        private ushort experience;
        private byte coins;
        private byte yoshiCookie;
        private byte itemWinA;
        private byte itemWinB;
        private bool elemIceNull;
        private bool elemThunderNull;
        private bool elemFireNull;
        private bool elemJumpNull;
        private bool elemIceWeak;
        private bool elemThunderWeak;
        private bool elemFireWeak;
        private bool elemJumpWeak;
        private bool effectMuteNull;
        private bool effectSleepNull;
        private bool effectPoisonNull;
        private bool effectFearNull;
        private bool effectMushroomNull;
        private bool effectScarecrowNull;
        private bool effectInvincibleNull;
        private bool invincible;
        private bool protectAgainstInstantDeath;
        private bool letBattleScriptRemove;
        private bool usedByCrystals;
        private byte morphSuccessRate;
        private byte flowerBonus;
        private byte flowerOdds;
        private byte entranceStyle;
        private byte coinSize;
        private byte elevation;
        private byte deathAnimation;
        private byte strikeSound;
        private byte otherSound;

        private byte cursorX;
        private byte cursorY;

        #endregion
        #region Accessors
        public int MonsterNum { get { return this.monsterNum; } set { this.monsterNum = value; } }
        public string Name { get { return this.name; } set { this.name = PadString(value, 13); } }
        public bool SetPsychoMsg(string value, bool symbols)
        {
            this.psychoMsg = textHelperReduced.EncodeText(value.ToCharArray(), symbols, 0);
            this.psychoMsgError = textHelperReduced.Error;
            return !psychoMsgError;
        }
        public string GetPsychoMsg(bool symbols) { if (!psychoMsgError) return new string(textHelperReduced.DecodeText(psychoMsg, symbols)); else return new string(psychoMsg); }
        public char[] RawPsychoMsg { get { return this.psychoMsg; } }
        public bool PsychoMsgError { get { return this.psychoMsgError; } set { this.psychoMsgError = value; } }
        public ushort HP { get { return this.hp; } set { this.hp = value; } }
        public byte Speed { get { return this.speed; } set { this.speed = value; } }
        public byte Attack { get { return this.attack; } set { this.attack = value; } }
        public byte Defense { get { return this.defense; } set { this.defense = value; } }
        public byte MagicAttack { get { return this.magicAttack; } set { this.magicAttack = value; } }
        public byte MagicDefense { get { return this.magicDefense; } set { this.magicDefense = value; } }
        public byte FP { get { return this.fp; } set { this.fp = value; } }
        public byte EvadePercent { get { return this.evadePercent; } set { this.evadePercent = value; } }
        public byte MagicEvadePercent { get { return this.magicEvadePercent; } set { this.magicEvadePercent = value; } }
        public ushort Experience { get { return this.experience; } set { this.experience = value; } }
        public byte Coins { get { return this.coins; } set { this.coins = value; } }
        public byte YoshiCookie
        {
            get { return this.yoshiCookie; }
            set { this.yoshiCookie = value; }
        }
        public byte ItemWinA { get { return this.itemWinA; } set { this.itemWinA = value; } }
        public byte ItemWinB { get { return this.itemWinB; } set { this.itemWinB = value; } }
        public bool ElemIceNull { get { return this.elemIceNull; } set { this.elemIceNull = value; } }
        public bool ElemThunderNull { get { return this.elemThunderNull; } set { this.elemThunderNull = value; } }
        public bool ElemFireNull { get { return this.elemFireNull; } set { this.elemFireNull = value; } }
        public bool ElemJumpNull { get { return this.elemJumpNull; } set { this.elemJumpNull = value; } }
        public bool ElemIceWeak { get { return this.elemIceWeak; } set { this.elemIceWeak = value; } }
        public bool ElemThunderWeak { get { return this.elemThunderWeak; } set { this.elemThunderWeak = value; } }
        public bool ElemFireWeak { get { return this.elemFireWeak; } set { this.elemFireWeak = value; } }
        public bool ElemJumpWeak { get { return this.elemJumpWeak; } set { this.elemJumpWeak = value; } }
        public bool EffectMuteNull { get { return this.effectMuteNull; } set { this.effectMuteNull = value; } }
        public bool EffectSleepNull { get { return this.effectSleepNull; } set { this.effectSleepNull = value; } }
        public bool EffectPoisonNull { get { return this.effectPoisonNull; } set { this.effectPoisonNull = value; } }
        public bool EffectFearNull { get { return this.effectFearNull; } set { this.effectFearNull = value; } }
        public bool EffectMushroomNull { get { return this.effectMushroomNull; } set { this.effectMushroomNull = value; } }
        public bool EffectScarecrowNull { get { return this.effectScarecrowNull; } set { this.effectScarecrowNull = value; } }
        public bool EffectInvincibleNull { get { return this.effectInvincibleNull; } set { this.effectInvincibleNull = value; } }
        public bool Invincible { get { return this.invincible; } set { this.invincible = value; } }
        public bool ProtectAgainstInstantDeath { get { return this.protectAgainstInstantDeath; } set { this.protectAgainstInstantDeath = value; } }
        public bool LetBattleScriptRemove { get { return this.letBattleScriptRemove; } set { this.letBattleScriptRemove = value; } }
        public bool UsedByCrystals { get { return this.usedByCrystals; } set { this.usedByCrystals = value; } }
        public byte MorphSuccessRate { get { return this.morphSuccessRate; } set { this.morphSuccessRate = value; } }
        public byte FlowerBonus { get { return this.flowerBonus; } set { this.flowerBonus = value; } }
        public byte FlowerOdds { get { return this.flowerOdds; } set { this.flowerOdds = value; } }
        public byte EntranceStyle { get { return this.entranceStyle; } set { this.entranceStyle = value; } }
        public byte CoinSize { get { return this.coinSize; } set { this.coinSize = value; } }
        public byte Elevation { get { return this.elevation; } set { this.elevation = value; } }
        public byte DeathAnimation { get { return this.deathAnimation; } set { this.deathAnimation = value; } }
        public byte StrikeSound { get { return this.strikeSound; } set { this.strikeSound = value; } }
        public byte OtherSound { get { return this.otherSound; } set { this.otherSound = value; } }

        public byte CursorX { get { return this.cursorX; } set { this.cursorX = value; } }
        public byte CursorY { get { return this.cursorY; } set { this.cursorY = value; } }

        #endregion

        public Monster(byte[] data, int monsterNum)
        {
            this.data = data;
            this.monsterNum = monsterNum;
            this.textHelperReduced = TextHelperReduced.Instance;
            InitializeMonster();
        }
        private void InitializeMonster()
        {
            name = ParseMonsterName(data);
            psychoMsg = ParsePsychoMsg(data);

            byte temp;

            int monsterStatPtrA = BitManager.GetShort(data, 0x390026 + monsterNum * 2);
            int monsterStatOffsetA = 0x390000 + monsterStatPtrA; //ByteManage.GetShort(data, monsterStatPtrA);


            hp = BitManager.GetShort(data, monsterStatOffsetA); monsterStatOffsetA += 2;
            speed = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            attack = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            defense = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            magicAttack = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            magicDefense = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            fp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            evadePercent = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            magicEvadePercent = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;

            // Byte 10
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            // DOUBLE CHECK THIS            
            if ((temp & 0x01) == 1) letBattleScriptRemove = true; else letBattleScriptRemove = false;
            if ((temp & 0x02) == 2) usedByCrystals = true; else usedByCrystals = false;
            // DOUBLE CHECK THIS          
            // Byte 11
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            if ((temp & 0x01) == 1) invincible = true; else invincible = false;
            if ((temp & 0x02) == 2) protectAgainstInstantDeath = true; else protectAgainstInstantDeath = false;
            switch (temp & 0x0C)						// MORPH SUCCESS RATE
            {
                case 0x00: morphSuccessRate = 0; break;
                case 0x04: morphSuccessRate = 1; break;		// [radiobutton] 25% success
                case 0x08: morphSuccessRate = 2; break;		// [radiobutton] 75% success
                case 0x0C: morphSuccessRate = 3; break;		// [radiobutton] 100% success
                default: morphSuccessRate = 0; break;		// [radiobutton] 0% success
            }
            switch (temp & 0xF0) // Need to figure out		// STRIKE SOUND
            {
                case 0x00: strikeSound = 0; break;	// bite
                case 0x10: strikeSound = 1; break;	// pierce
                case 0x20: strikeSound = 2; break;	// claw strike
                case 0x30: strikeSound = 3; break;	// etc...
                case 0x40: strikeSound = 4; break;
                case 0x50: strikeSound = 5; break;
                case 0x60: strikeSound = 6; break;
                case 0x70: strikeSound = 7; break;
                case 0x80: strikeSound = 8; break;
                case 0x90: strikeSound = 9; break;
                case 0xA0: strikeSound = 10; break;
                case 0xB0: strikeSound = 11; break;
                case 0xC0: strikeSound = 12; break;
                case 0xD0: strikeSound = 13; break;
                default: strikeSound = 0; break;
            }

            // Byte 12
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            elemIceNull = (temp & 0x10) == 0x10;
            elemThunderNull = (temp & 0x20) == 0x20;
            elemFireNull = (temp & 0x40) == 0x40;
            elemJumpNull = (temp & 0x80) == 0x80;

            // Byte 13
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            switch (temp & 0x0F)						// OTHER SOUND
            {
                case 0x00: otherSound = 0; break;			// none
                case 0x01: otherSound = 1; break;			// Starslap, Spikey, Enigma
                case 0x02: otherSound = 2; break;			// etc...
                case 0x03: otherSound = 3; break;
                case 0x04: otherSound = 4; break;
                case 0x05: otherSound = 5; break;
                case 0x06: otherSound = 6; break;
                case 0x07: otherSound = 7; break;
                default: otherSound = 0; break;
            }

            elemIceWeak = (temp & 0x10) == 0x10;
            elemThunderWeak = (temp & 0x20) == 0x20;
            elemFireWeak = (temp & 0x40) == 0x40;
            elemJumpWeak = (temp & 0x80) == 0x80;

            // Byte 14
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            effectMuteNull = (temp & 0x01) == 0x01;
            effectSleepNull = (temp & 0x02) == 0x02;
            effectPoisonNull = (temp & 0x04) == 0x04;
            effectFearNull = (temp & 0x08) == 0x08;
            effectMushroomNull = (temp & 0x20) == 0x20;
            effectScarecrowNull = (temp & 0x40) == 0x40;
            effectInvincibleNull = (temp & 0x80) == 0x80;

            // Byte 15
            temp = BitManager.GetByte(data, monsterStatOffsetA); monsterStatOffsetA++;
            entranceStyle = (byte)(temp & 0x0F);
            elevation = (byte)((temp & 0x30) >> 4);

            if ((temp & 0x40) == 0x40) coinSize = 1;				// [checkbox] Small coin
            else if ((temp & 0x80) == 0x80) coinSize = 2;			// [checkbox] Big coin
            else coinSize = 0;

            int monsterStatPtrB = BitManager.GetShort(data, 0x39142a + monsterNum * 2);
            int monsterStatOffsetB = 0x390000 + monsterStatPtrB; // ByteManage.GetShort(data, monsterStatPtrB);

            experience = BitManager.GetShort(data, monsterStatOffsetB); monsterStatOffsetB += 2;
            // Byte 2
            coins = BitManager.GetByte(data, monsterStatOffsetB); monsterStatOffsetB++;
            yoshiCookie = BitManager.GetByte(data, monsterStatOffsetB); monsterStatOffsetB++;
            itemWinA = BitManager.GetByte(data, monsterStatOffsetB); monsterStatOffsetB++;
            itemWinB = BitManager.GetByte(data, monsterStatOffsetB); monsterStatOffsetB++;

            int flowerBonusOffset = monsterNum + 0x39BB44;

            // Byte 1
            temp = BitManager.GetByte(data, flowerBonusOffset);
            switch (temp & 0x0F)							// FLOWER BONUS
            {
                case 0x01: flowerBonus = 0; break;		// [radiobutton] attack Up
                case 0x02: flowerBonus = 1; break;		// [radiobutton] defense Up
                case 0x03: flowerBonus = 2; break;		// [radiobutton] hp Max
                case 0x04: flowerBonus = 3; break;		// [radiobutton] Once Again
                case 0x05: flowerBonus = 4; break;		// [radiobutton] Lucky
                default: flowerBonus = 0; break;
            }

            flowerOdds = (byte)((temp & 0xF0) >> 4);			// Odds			[numericUpDown]

            int deathAnimationOffset = monsterNum * 2 + 0x350202;

            switch (BitManager.GetShort(data, deathAnimationOffset))								// DEATH ANIMATION
            {
                case 0x058A: deathAnimation = 0; break;	// no movement for "Escape"
                case 0x0596: deathAnimation = 1; break;	// slide backward when hit
                case 0x05A2: deathAnimation = 2; break;	// etc...
                case 0x05AE: deathAnimation = 3; break;
                case 0x05BA: deathAnimation = 4; break;
                case 0x0898: deathAnimation = 5; break;
                case 0x0985: deathAnimation = 6; break;
                case 0x0991: deathAnimation = 7; break;
                case 0x0AD3: deathAnimation = 8; break;
                case 0x0ADF: deathAnimation = 9; break;
                case 0x0AEB: deathAnimation = 10; break;
                case 0x0CF2: deathAnimation = 11; break;
                case 0x0CFE: deathAnimation = 12; break;
                case 0x0D0A: deathAnimation = 13; break;
                case 0x0D16: deathAnimation = 14; break;
                case 0x0E60: deathAnimation = 15; break;
                case 0x0E6C: deathAnimation = 16; break;
                case 0x0E78: deathAnimation = 17; break;
                default: deathAnimation = 0; break;
            }

            cursorX = (byte)((data[0x39B944 + monsterNum] & 0xF0) >> 4);
            cursorY = (byte)(data[0x39B944 + monsterNum] & 0x0F);
        }
        public ushort Assemble(ushort psychoOffset)
        {
            ushort retLength = 0;

            BitManager.SetByteArray(data, 0x3992d1 + (monsterNum * 13), strToByte(name));
            BitManager.SetShort(data, 0x399FD1 + monsterNum * 2, psychoOffset);
            if (this.psychoMsgError)
                System.Windows.Forms.MessageBox.Show("There is an error with Monster " + this.monsterNum.ToString() + " Psychopath Message, it has not been saved.");
            else
            {
                retLength = (ushort)psychoMsg.Length;
                BitManager.SetByteArray(data, 0x390000 + psychoOffset, charToByte(psychoMsg));
            }
            int monsterStatPtrA = BitManager.GetShort(data, 0x390026 + monsterNum * 2);
            int monsterStatOffsetA = 0x390000 + monsterStatPtrA; //ByteManage.SetShort(data, monsterStatPtrA);

            BitManager.SetShort(data, monsterStatOffsetA, hp); monsterStatOffsetA += 2;
            BitManager.SetByte(data, monsterStatOffsetA, speed); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, attack); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, defense); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, magicAttack); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, magicDefense); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, fp); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, evadePercent); monsterStatOffsetA++;
            BitManager.SetByte(data, monsterStatOffsetA, magicEvadePercent); monsterStatOffsetA++;

            // Byte 10
            // DOUBLE CHECK THIS            
            BitManager.SetBit(data, monsterStatOffsetA, 0, letBattleScriptRemove);
            BitManager.SetBit(data, monsterStatOffsetA, 1, usedByCrystals);
            monsterStatOffsetA++;

            // DOUBLE CHECK THIS          
            // Byte 11

            BitManager.SetByte(data, monsterStatOffsetA, (byte)((strikeSound << 4) + (morphSuccessRate << 2)));

            BitManager.SetBit(data, monsterStatOffsetA, 0, invincible);
            BitManager.SetBit(data, monsterStatOffsetA, 1, protectAgainstInstantDeath);

            monsterStatOffsetA++;

            // Byte 12
            BitManager.SetBit(data, monsterStatOffsetA, 4, elemIceNull);
            BitManager.SetBit(data, monsterStatOffsetA, 5, elemThunderNull);
            BitManager.SetBit(data, monsterStatOffsetA, 6, elemFireNull);
            BitManager.SetBit(data, monsterStatOffsetA, 7, elemJumpNull);

            monsterStatOffsetA++;

            // Byte 13
            BitManager.SetByte(data, monsterStatOffsetA, otherSound);
            BitManager.SetBit(data, monsterStatOffsetA, 4, elemIceWeak);
            BitManager.SetBit(data, monsterStatOffsetA, 5, elemThunderWeak);
            BitManager.SetBit(data, monsterStatOffsetA, 6, elemFireWeak);
            BitManager.SetBit(data, monsterStatOffsetA, 7, elemJumpWeak);

            monsterStatOffsetA++;

            // Byte 14
            BitManager.SetBit(data, monsterStatOffsetA, 0, effectMuteNull);
            BitManager.SetBit(data, monsterStatOffsetA, 1, effectSleepNull);
            BitManager.SetBit(data, monsterStatOffsetA, 2, effectPoisonNull);
            BitManager.SetBit(data, monsterStatOffsetA, 3, effectFearNull);
            BitManager.SetBit(data, monsterStatOffsetA, 5, effectMushroomNull);
            BitManager.SetBit(data, monsterStatOffsetA, 6, effectScarecrowNull);
            BitManager.SetBit(data, monsterStatOffsetA, 7, effectInvincibleNull);

            monsterStatOffsetA++;

            // Byte 15
            BitManager.SetByte(data, monsterStatOffsetA, (byte)(entranceStyle + (elevation << 4) + (coinSize << 6)));


            // MONSTER STATS B
            int monsterStatPtrB = BitManager.GetShort(data, 0x39142a + monsterNum * 2);
            int monsterStatOffsetB = 0x390000 + monsterStatPtrB; // ByteManage.GetShort(data, monsterStatPtrB);

            BitManager.SetShort(data, monsterStatOffsetB, experience); monsterStatOffsetB += 2;
            // Byte 2
            BitManager.SetByte(data, monsterStatOffsetB, coins); monsterStatOffsetB++;
            BitManager.SetByte(data, monsterStatOffsetB, yoshiCookie); monsterStatOffsetB++;
            BitManager.SetByte(data, monsterStatOffsetB, itemWinA); monsterStatOffsetB++;
            BitManager.SetByte(data, monsterStatOffsetB, itemWinB); monsterStatOffsetB++;

            int flowerBonusOffset = monsterNum + 0x39BB44;

            // Byte 1
            BitManager.SetByte(data, flowerBonusOffset, (byte)((flowerBonus + 1) + (flowerOdds << 4)));

            int deathAnimationOffset = monsterNum * 2 + 0x350202;

            switch (deathAnimation)								// DEATH ANIMATION
            {
                case 0: BitManager.SetShort(data, deathAnimationOffset, 0x058A); break;	// no movement for "Escape"
                case 1: BitManager.SetShort(data, deathAnimationOffset, 0x0596); break;	// slide backward when hit
                case 2: BitManager.SetShort(data, deathAnimationOffset, 0x05A2); break;	// etc...
                case 3: BitManager.SetShort(data, deathAnimationOffset, 0x05AE); break;
                case 4: BitManager.SetShort(data, deathAnimationOffset, 0x05BA); break;
                case 5: BitManager.SetShort(data, deathAnimationOffset, 0x0898); break;
                case 6: BitManager.SetShort(data, deathAnimationOffset, 0x0985); break;
                case 7: BitManager.SetShort(data, deathAnimationOffset, 0x0991); break;
                case 8: BitManager.SetShort(data, deathAnimationOffset, 0x0AD3); break;
                case 9: BitManager.SetShort(data, deathAnimationOffset, 0x0ADF); break;
                case 10: BitManager.SetShort(data, deathAnimationOffset, 0x0AEB); break;
                case 11: BitManager.SetShort(data, deathAnimationOffset, 0x0CF2); break;
                case 12: BitManager.SetShort(data, deathAnimationOffset, 0x0CFE); break;
                case 13: BitManager.SetShort(data, deathAnimationOffset, 0x0D0A); break;
                case 14: BitManager.SetShort(data, deathAnimationOffset, 0x0D16); break;
                case 15: BitManager.SetShort(data, deathAnimationOffset, 0x0E60); break;
                case 16: BitManager.SetShort(data, deathAnimationOffset, 0x0E6C); break;
                case 17: BitManager.SetShort(data, deathAnimationOffset, 0x0E78); break;
            }

            data[0x39B944 + monsterNum] = (byte)(cursorX << 4);
            data[0x39B944 + monsterNum] |= cursorY;

            return retLength;
        }
        public void Clear()
        {
            hp = 0;
            speed = 0;
            attack = 0;
            defense = 0;
            magicAttack = 0;
            magicDefense = 0;
            fp = 0;
            evadePercent = 0;
            magicEvadePercent = 0;
            experience = 0;
            coins = 0;
            yoshiCookie = 0;
            itemWinA = 0;
            itemWinB = 0;
            elemIceNull = false;
            elemThunderNull = false;
            elemFireNull = false;
            elemJumpNull = false;
            elemIceWeak = false;
            elemThunderWeak = false;
            elemFireWeak = false;
            elemJumpWeak = false;
            effectMuteNull = false;
            effectSleepNull = false;
            effectPoisonNull = false;
            effectFearNull = false;
            effectMushroomNull = false;
            effectScarecrowNull = false;
            effectInvincibleNull = false;
            invincible = false;
            protectAgainstInstantDeath = false;
            letBattleScriptRemove = false;
            usedByCrystals = false;
            morphSuccessRate = 0;
            flowerBonus = 0;
            flowerOdds = 0;
            entranceStyle = 0;
            coinSize = 0;
            elevation = 0;
            deathAnimation = 0;
            strikeSound = 0;
            otherSound = 0;
            psychoMsg = new char[0];
            name = "             ";
        }

        private string ParseMonsterName(byte[] data)
        {
            int namePtr = 0x3992d1;
            byte[] temp = new byte[13];

            for (int i = 0; i <= 12; i++)
            {
                temp[i] = (byte)data[namePtr + (monsterNum * 13) + i];
                if (temp[i] == 0x2A) temp[i] = (byte)'.';
                if (temp[i] == 0x7B) temp[i] = (byte)'!';
                if (temp[i] == 0x7D) temp[i] = (byte)'-';
                if (temp[i] == 0x7E) temp[i] = (byte)'\'';
            }

            return byteToStr(temp);
        }
        private char[] ParsePsychoMsg(byte[] data)
        {
            int psychoPtr = 0x390000 + BitManager.GetShort(data, 0x399FD1 + monsterNum * 2);

            int count = psychoPtr;
            int len = 0;
            byte ptr = 0x01;

            while (ptr != 0x00)
            {
                ptr = data[count];
                len++;
                count++;
            }

            char[] psychoMsg = new char[len];

            for (int i = 0; i < len; i++)
            {
                psychoMsg[i] = (char)data[psychoPtr + i];
            }

            return psychoMsg;

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
                if (arr[i] == '!') arr[i] = (byte)0x7B;
                if (arr[i] == '-') arr[i] = (byte)0x7D;
                if (arr[i] == '\'') arr[i] = (byte)0x7E;
            }
            return arr;
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
        #region Text Helper Code
        private TextHelperReduced textHelperReduced; public TextHelperReduced TextHelperReduced { get { return this.textHelperReduced; } set { this.textHelperReduced = value; } }
        private int caretPositionSymbol = 0; public int CaretPositionSymbol { get { return this.caretPositionSymbol; } set { this.caretPositionSymbol = value; } }
        private int caretPositionNotSymbol = 0; public int CaretPositionNotSymbol { get { return this.caretPositionNotSymbol; } set { this.caretPositionNotSymbol = value; } }
        #endregion
        #region Monster Image Code
        private int currentFrame = 0;
        private int maxFrame = 0;
        private int moldX = 0;
        private int moldY = 0;
        public Image Image { get { return new Bitmap(CreateImage(currentFrame)); } }
        public int[,] PixelBuffer { get { return CreatePixelBuffer(0); } }
        public int MoldGridPlaneWidth { get { return moldX; } }
        public int MoldGridPlaneHeight { get { return moldY; } }
        public void nextFrame() { if (currentFrame >= maxFrame) { return; } currentFrame++; }
        public void previousFrame() { if (currentFrame <= 0) { return; } currentFrame--; }
        private Image CreateImage(int frame)
        {
            Bitmap image = null;

            Mold tMold;
            int num = monsterNum + 0x100;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = BitManager.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (BitManager.GetByte(data, offset) & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((BitManager.GetByte(data, offset) & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((BitManager.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(BitManager.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)BitManager.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }

            //
            int animationNum = BitManager.GetShort(data, num * 4 + 0x250002);
            int animationOffset = BitManager.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = BitManager.GetShort(data, animationOffset);
            maxFrame = BitManager.GetByte(data, animationOffset + 7) - 1;

            byte[] sm = BitManager.GetByteArray(data, animationOffset, animationLength);
            offset = BitManager.GetShort(sm, 4); offset += frame * 2;
            tMold = new Mold();
            tMold.InitializeMold(sm, offset);
            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(BitManager.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
                foreach (Mold.Tile c in t.Copies)
                    c.Set8x8Tiles(BitManager.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
            }

            int[] pixels = tMold.MoldPixels(false);

            int[] cursorPixels = CursorPixels();
            for (int y = 112 - (cursorY * 8), n = 0; n < 16; y++, n++)
            {
                for (int x = 112 - (cursorX * 8), m = 0; m < 16; x++, m++)
                {
                    if (cursorPixels[n * 16 + m] != 0 &&
                        y >= 0 && y < 256 && x >= 0 && x < 256)
                        pixels[y * 256 + x] = cursorPixels[n * 16 + m];
                }
            }

            // set the image
            unsafe
            {
                fixed (void* firstPixel = &pixels[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(256, 256, 256 * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);
                }
            }
            return (Image)image;
        }
        private int[,] CreatePixelBuffer(int frame)
        {
            int[,] pixels = new int[256, 256];
            Mold tMold;
            int num = monsterNum + 0x100;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = BitManager.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (BitManager.GetByte(data, offset) & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((BitManager.GetByte(data, offset) & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((BitManager.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(BitManager.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)BitManager.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }

            //
            int animationNum = BitManager.GetShort(data, num * 4 + 0x250002);
            int animationOffset = BitManager.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = BitManager.GetShort(data, animationOffset);
            maxFrame = BitManager.GetByte(data, animationOffset + 7) - 1;

            byte[] sm = BitManager.GetByteArray(data, animationOffset, animationLength);
            offset = BitManager.GetShort(sm, 4); offset += frame * 2;
            tMold = new Mold();
            tMold.InitializeMold(sm, offset);
            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(BitManager.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
                foreach (Mold.Tile c in t.Copies)
                    c.Set8x8Tiles(BitManager.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
            }

            int[] temp = tMold.MoldPixels(false);
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                    pixels[x, y] = temp[y * 256 + x];
            }
            return pixels;
        }
        private int[] CursorPixels()
        {
            // draw the cursor
            int offset = 0, r, g, b;
            int[] palette = new int[16];
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 4 colors in palette
            {
                color = BitManager.GetShort(data, 0x03FC00 + (i * 2));

                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);

                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }
            Tile8x8 temp;
            Tile16x16 cursor = new Tile16x16(0);
            for (int i = 0; i < 4; i++)
            {
                offset = 0x03F980 + ((i % 2) * 0x20);
                if (i > 1)
                    offset += 0x200;
                temp = new Tile8x8(i, BitManager.GetByteArray(data, offset, 0x20), 0, palette, false, false, false, false);
                cursor.SetSubtile(temp, i);
            }
            return cursor.Pixels();
        }

        #endregion

    }
}
