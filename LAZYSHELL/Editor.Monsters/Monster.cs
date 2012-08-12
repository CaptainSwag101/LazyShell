using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Monster : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        #region Monster Stats
        private int index;
        private char[] name;
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
        public char[] Name { get { return this.name; } set { this.name = value; } }
        public bool SetPsychoMsg(string value, bool byteView)
        {
            this.psychoMsg = textHelperReduced.EncodeText(value.ToCharArray(), byteView, 0, Settings.Default.Keystrokes);
            this.psychoMsgError = textHelperReduced.Error;
            return !psychoMsgError;
        }
        public string GetPsychoMsg(bool byteView)
        {
            if (!psychoMsgError)
                return new string(textHelperReduced.DecodeText(psychoMsg, byteView, 0, Settings.Default.Keystrokes));
            else
                return new string(psychoMsg);
        }
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
        public bool MortalityProtection { get { return this.protectAgainstInstantDeath; } set { this.protectAgainstInstantDeath = value; } }
        public bool DisableAutoDeath { get { return this.letBattleScriptRemove; } set { this.letBattleScriptRemove = value; } }
        public bool Palette2bpp { get { return this.usedByCrystals; } set { this.usedByCrystals = value; } }
        public byte MorphSuccessRate { get { return this.morphSuccessRate; } set { this.morphSuccessRate = value; } }
        public byte FlowerBonus { get { return this.flowerBonus; } set { this.flowerBonus = value; } }
        public byte FlowerOdds { get { return this.flowerOdds; } set { this.flowerOdds = value; } }
        public byte EntranceStyle { get { return this.entranceStyle; } set { this.entranceStyle = value; } }
        public byte CoinSize { get { return this.coinSize; } set { this.coinSize = value; } }
        public byte Elevation { get { return this.elevation; } set { this.elevation = value; } }
        public byte SpriteBehavior { get { return this.deathAnimation; } set { this.deathAnimation = value; } }
        public byte StrikeSound { get { return this.strikeSound; } set { this.strikeSound = value; } }
        public byte OtherSound { get { return this.otherSound; } set { this.otherSound = value; } }

        public byte CursorX { get { return this.cursorX; } set { this.cursorX = value; } }
        public byte CursorY { get { return this.cursorY; } set { this.cursorY = value; } }

        #endregion

        public Monster(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeMonster();
        }
        private void InitializeMonster()
        {
            name = new char[13];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(index * 13) + 0x3992d1 + i];

            psychoMsg = ParsePsychoMsg(data);

            byte temp;

            int pointer = Bits.GetShort(data, 0x390026 + index * 2);
            int offset = 0x390000 + pointer; //ByteManage.GetShort(data, monsterStatPtrA);


            hp = Bits.GetShort(data, offset); offset += 2;
            speed = data[offset]; offset++;
            attack = data[offset]; offset++;
            defense = data[offset]; offset++;
            magicAttack = data[offset]; offset++;
            magicDefense = data[offset]; offset++;
            fp = data[offset]; offset++;
            evadePercent = data[offset]; offset++;
            magicEvadePercent = data[offset]; offset++;

            // Byte 10
            temp = data[offset]; offset++;
            // DOUBLE CHECK THIS            
            if ((temp & 0x01) == 1) letBattleScriptRemove = true; else letBattleScriptRemove = false;
            if ((temp & 0x02) == 2) usedByCrystals = true; else usedByCrystals = false;
            // DOUBLE CHECK THIS          
            // Byte 11
            temp = data[offset]; offset++;
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
            temp = data[offset]; offset++;
            elemIceNull = (temp & 0x10) == 0x10;
            elemThunderNull = (temp & 0x20) == 0x20;
            elemFireNull = (temp & 0x40) == 0x40;
            elemJumpNull = (temp & 0x80) == 0x80;

            // Byte 13
            temp = data[offset]; offset++;
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
            temp = data[offset]; offset++;
            effectMuteNull = (temp & 0x01) == 0x01;
            effectSleepNull = (temp & 0x02) == 0x02;
            effectPoisonNull = (temp & 0x04) == 0x04;
            effectFearNull = (temp & 0x08) == 0x08;
            effectMushroomNull = (temp & 0x20) == 0x20;
            effectScarecrowNull = (temp & 0x40) == 0x40;
            effectInvincibleNull = (temp & 0x80) == 0x80;

            // Byte 15
            temp = data[offset]; offset++;
            entranceStyle = (byte)(temp & 0x0F);
            elevation = (byte)((temp & 0x30) >> 4);

            if ((temp & 0x40) == 0x40) coinSize = 1;				// [checkbox] Small coin
            else if ((temp & 0x80) == 0x80) coinSize = 2;			// [checkbox] Big coin
            else coinSize = 0;

            int monsterStatPtrB = Bits.GetShort(data, 0x39142a + index * 2);
            int monsterStatOffsetB = 0x390000 + monsterStatPtrB; // ByteManage.GetShort(data, monsterStatPtrB);

            experience = Bits.GetShort(data, monsterStatOffsetB); monsterStatOffsetB += 2;
            // Byte 2
            coins = data[monsterStatOffsetB]; monsterStatOffsetB++;
            yoshiCookie = data[monsterStatOffsetB]; monsterStatOffsetB++;
            itemWinA = data[monsterStatOffsetB]; monsterStatOffsetB++;
            itemWinB = data[monsterStatOffsetB]; monsterStatOffsetB++;

            int flowerBonusOffset = index + 0x39BB44;

            // Byte 1
            temp = data[flowerBonusOffset];
            switch (temp & 0x0F)							// FLOWER BONUS
            {
                case 0x01: flowerBonus = 0; break;		// [radiobutton] attack Up
                case 0x02: flowerBonus = 1; break;		// [radiobutton] defense Up
                case 0x03: flowerBonus = 2; break;		// [radiobutton] hp Max
                case 0x04: flowerBonus = 3; break;		// [radiobutton] Once Again
                case 0x05: flowerBonus = 4; break;		// [radiobutton] Lucky
                default: flowerBonus = 0; break;
            }

            flowerOdds = (byte)Math.Min(10, (temp & 0xF0) >> 4);			// Odds			[numericUpDown]

            int deathAnimationOffset = index * 2 + 0x350202;

            switch (Bits.GetShort(data, deathAnimationOffset))								// DEATH ANIMATION
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

            cursorX = (byte)((data[0x39B944 + index] & 0xF0) >> 4);
            cursorY = (byte)(data[0x39B944 + index] & 0x0F);
        }
        public ushort Assemble(ushort psychoOffset)
        {
            ushort retLength = 0;

            Bits.SetCharArray(data, 0x3992d1 + (index * 13), name);
            Bits.SetShort(data, 0x399FD1 + index * 2, psychoOffset);
            if (this.psychoMsgError)
                System.Windows.Forms.MessageBox.Show("There is an error with Monster " + this.index.ToString() + " Psychopath Message, it has not been saved.");
            else
            {
                retLength = (ushort)psychoMsg.Length;
                Bits.SetCharArray(data, 0x390000 + psychoOffset, psychoMsg);
            }
            int monsterStatPtrA = Bits.GetShort(data, 0x390026 + index * 2);
            int monsterStatOffsetA = 0x390000 + monsterStatPtrA; //ByteManage.SetShort(data, monsterStatPtrA);

            Bits.SetShort(data, monsterStatOffsetA, hp); monsterStatOffsetA += 2;
            Bits.SetByte(data, monsterStatOffsetA, speed); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, attack); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, defense); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, magicAttack); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, magicDefense); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, fp); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, evadePercent); monsterStatOffsetA++;
            Bits.SetByte(data, monsterStatOffsetA, magicEvadePercent); monsterStatOffsetA++;

            // Byte 10
            // DOUBLE CHECK THIS            
            Bits.SetBit(data, monsterStatOffsetA, 0, letBattleScriptRemove);
            Bits.SetBit(data, monsterStatOffsetA, 1, usedByCrystals);
            monsterStatOffsetA++;

            // DOUBLE CHECK THIS          
            // Byte 11

            Bits.SetByte(data, monsterStatOffsetA, (byte)((strikeSound << 4) + (morphSuccessRate << 2)));

            Bits.SetBit(data, monsterStatOffsetA, 0, invincible);
            Bits.SetBit(data, monsterStatOffsetA, 1, protectAgainstInstantDeath);

            monsterStatOffsetA++;

            // Byte 12
            Bits.SetBit(data, monsterStatOffsetA, 4, elemIceNull);
            Bits.SetBit(data, monsterStatOffsetA, 5, elemThunderNull);
            Bits.SetBit(data, monsterStatOffsetA, 6, elemFireNull);
            Bits.SetBit(data, monsterStatOffsetA, 7, elemJumpNull);

            monsterStatOffsetA++;

            // Byte 13
            Bits.SetByte(data, monsterStatOffsetA, otherSound);
            Bits.SetBit(data, monsterStatOffsetA, 4, elemIceWeak);
            Bits.SetBit(data, monsterStatOffsetA, 5, elemThunderWeak);
            Bits.SetBit(data, monsterStatOffsetA, 6, elemFireWeak);
            Bits.SetBit(data, monsterStatOffsetA, 7, elemJumpWeak);

            monsterStatOffsetA++;

            // Byte 14
            Bits.SetBit(data, monsterStatOffsetA, 0, effectMuteNull);
            Bits.SetBit(data, monsterStatOffsetA, 1, effectSleepNull);
            Bits.SetBit(data, monsterStatOffsetA, 2, effectPoisonNull);
            Bits.SetBit(data, monsterStatOffsetA, 3, effectFearNull);
            Bits.SetBit(data, monsterStatOffsetA, 5, effectMushroomNull);
            Bits.SetBit(data, monsterStatOffsetA, 6, effectScarecrowNull);
            Bits.SetBit(data, monsterStatOffsetA, 7, effectInvincibleNull);

            monsterStatOffsetA++;

            // Byte 15
            Bits.SetByte(data, monsterStatOffsetA, (byte)(entranceStyle + (elevation << 4) + (coinSize << 6)));


            // MONSTER STATS B
            int monsterStatPtrB = Bits.GetShort(data, 0x39142a + index * 2);
            int monsterStatOffsetB = 0x390000 + monsterStatPtrB; // ByteManage.GetShort(data, monsterStatPtrB);

            Bits.SetShort(data, monsterStatOffsetB, experience); monsterStatOffsetB += 2;
            // Byte 2
            Bits.SetByte(data, monsterStatOffsetB, coins); monsterStatOffsetB++;
            Bits.SetByte(data, monsterStatOffsetB, yoshiCookie); monsterStatOffsetB++;
            Bits.SetByte(data, monsterStatOffsetB, itemWinA); monsterStatOffsetB++;
            Bits.SetByte(data, monsterStatOffsetB, itemWinB); monsterStatOffsetB++;

            int flowerBonusOffset = index + 0x39BB44;

            // Byte 1
            Bits.SetByte(data, flowerBonusOffset, (byte)((flowerBonus + 1) + (flowerOdds << 4)));

            int deathAnimationOffset = index * 2 + 0x350202;

            switch (deathAnimation)								// DEATH ANIMATION
            {
                case 0: Bits.SetShort(data, deathAnimationOffset, 0x058A); break;	// no movement for "Escape"
                case 1: Bits.SetShort(data, deathAnimationOffset, 0x0596); break;	// slide backward when hit
                case 2: Bits.SetShort(data, deathAnimationOffset, 0x05A2); break;	// etc...
                case 3: Bits.SetShort(data, deathAnimationOffset, 0x05AE); break;
                case 4: Bits.SetShort(data, deathAnimationOffset, 0x05BA); break;
                case 5: Bits.SetShort(data, deathAnimationOffset, 0x0898); break;
                case 6: Bits.SetShort(data, deathAnimationOffset, 0x0985); break;
                case 7: Bits.SetShort(data, deathAnimationOffset, 0x0991); break;
                case 8: Bits.SetShort(data, deathAnimationOffset, 0x0AD3); break;
                case 9: Bits.SetShort(data, deathAnimationOffset, 0x0ADF); break;
                case 10: Bits.SetShort(data, deathAnimationOffset, 0x0AEB); break;
                case 11: Bits.SetShort(data, deathAnimationOffset, 0x0CF2); break;
                case 12: Bits.SetShort(data, deathAnimationOffset, 0x0CFE); break;
                case 13: Bits.SetShort(data, deathAnimationOffset, 0x0D0A); break;
                case 14: Bits.SetShort(data, deathAnimationOffset, 0x0D16); break;
                case 15: Bits.SetShort(data, deathAnimationOffset, 0x0E60); break;
                case 16: Bits.SetShort(data, deathAnimationOffset, 0x0E6C); break;
                case 17: Bits.SetShort(data, deathAnimationOffset, 0x0E78); break;
            }

            data[0x39B944 + index] = (byte)(cursorX << 4);
            data[0x39B944 + index] |= cursorY;

            return retLength;
        }
        public override void Clear()
        {
            Bits.Fill(name, '\x20');
            psychoMsg = new char[0];
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
        }

        private char[] ParsePsychoMsg(byte[] data)
        {
            int psychoPtr = 0x390000 + Bits.GetShort(data, 0x399FD1 + index * 2);

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
        #region Text Helper Code
        private TextHelperReduced textHelperReduced { get { return TextHelperReduced.Instance; } }
        private int caretPositionByteView = 0;
        public int CaretPositionByteView
        {
            get
            {
                return this.caretPositionByteView;
            }
            set
            {
                this.caretPositionByteView = value;
            }
        }
        private int caretPositionTextView = 0;
        public int CaretPositionTextView
        {
            get
            {
                return this.caretPositionTextView;
            }
            set
            {
                this.caretPositionTextView = value;
            }
        }
        #endregion
        #region Monster Image Code
        private int currentFrame = 0;
        private int maxFrame = 0;
        private int moldX = 0;
        private int moldY = 0;
        public Image Image { get { return new Bitmap(CreateImage(currentFrame)); } }
        public int MoldGridPlaneWidth { get { return moldX; } }
        public int MoldGridPlaneHeight { get { return moldY; } }
        public void nextFrame() { if (currentFrame >= maxFrame) { return; } currentFrame++; }
        public void previousFrame() { if (currentFrame <= 0) { return; } currentFrame--; }
        private Image CreateImage(int frame)
        {
            Bitmap image = null;

            Mold tMold;
            int num = index + 0x100;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = Bits.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (data[offset] & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(Bits.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)Bits.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }

            //
            int animationNum = Bits.GetShort(data, num * 4 + 0x250002);
            int animationOffset = Bits.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = Bits.GetShort(data, animationOffset);
            maxFrame = data[animationOffset + 7] - 1;

            byte[] sm = Bits.GetByteArray(data, animationOffset, animationLength);
            offset = Bits.GetShort(sm, 4); offset += frame * 2;
            tMold = new Mold();
            tMold.InitializeMold(sm, offset, new List<Mold.Tile>(), animationNum, animationOffset);
            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(Bits.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
            }

            int[] pixels = tMold.MoldPixels();

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
        public int[] Pixels()
        {
            int[] pixels = new int[256 * 256];
            Mold tMold;
            int num = index + 0x100;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = Bits.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (data[offset] & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(Bits.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)Bits.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }

            //
            int animationNum = Bits.GetShort(data, num * 4 + 0x250002);
            int animationOffset = Bits.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = Bits.GetShort(data, animationOffset);
            maxFrame = data[animationOffset + 7] - 1;

            byte[] sm = Bits.GetByteArray(data, animationOffset, animationLength);
            offset = Bits.GetShort(sm, 4);
            tMold = new Mold();
            tMold.InitializeMold(sm, offset, new List<Mold.Tile>(), animationNum, animationOffset);
            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(Bits.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
            }
            return tMold.MoldPixels();
        }
        public int[] Shadow()
        {
            int num = index + 0x100;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = Bits.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (data[offset] & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(Bits.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)Bits.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }
            return Do.GetPixelRegion(Model.NumeralGraphics, 0x20, palette, 16, 14, 0, 2, 2, 0);
        }
        private int[] CursorPixels()
        {
            // draw the cursor
            int offset = 0, r, g, b;
            int[] palette = new int[16];
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 4 colors in palette
            {
                color = Bits.GetShort(data, 0x03FC00 + (i * 2));

                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);

                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }
            Subtile temp;
            Tile cursor = new Tile(0);
            for (int i = 0; i < 4; i++)
            {
                offset = 0x03F980 + ((i % 2) * 0x20);
                if (i > 1)
                    offset += 0x200;
                temp = new Subtile(i, Bits.GetByteArray(data, offset, 0x20), 0, palette, false, false, false, false);
                cursor.Subtiles[i] = temp;
            }
            return cursor.Pixels;
        }

        #endregion
    }
}
