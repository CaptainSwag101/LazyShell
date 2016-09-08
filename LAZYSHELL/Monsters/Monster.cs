using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Monsters
{
    [Serializable()]
    public class Monster : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Name
        public char[] Name { get; set; }

        #region Statistics

        public ushort HP { get; set; }
        public byte Speed { get; set; }
        public byte Attack { get; set; }
        public byte Defense { get; set; }
        public byte MagicAttack { get; set; }
        public byte MagicDefense { get; set; }
        public byte FP { get; set; }
        public byte Evade { get; set; }
        public byte MagicEvade { get; set; }
        public bool ElemNullIce { get; set; }
        public bool ElemNullThunder { get; set; }
        public bool ElemNullFire { get; set; }
        public bool ElemNullJump { get; set; }
        public bool ElemWeakIce { get; set; }
        public bool ElemWeakThunder { get; set; }
        public bool ElemWeakFire { get; set; }
        public bool ElemWeakJump { get; set; }
        public bool EffectNullMute { get; set; }
        public bool EffectNullSleep { get; set; }
        public bool EffectNullPoison { get; set; }
        public bool EffectNullFear { get; set; }
        public bool EffectNullMushroom { get; set; }
        public bool EffectNullScarecrow { get; set; }
        public bool EffectNullInvincible { get; set; }
        public bool Invincible { get; set; }
        public bool MortalityProtection { get; set; }
        public bool DisableAutoDeath { get; set; }
        public bool Palette2bpp { get; set; }
        public byte MorphSuccess { get; set; }
        public byte FlowerBonus { get; set; }
        public byte FlowerOdds { get; set; }
        public byte EntranceStyle { get; set; }
        public byte CoinSize { get; set; }
        public byte Elevation { get; set; }
        public byte SpriteBehavior { get; set; }
        public byte StrikeSound { get; set; }
        public byte OtherSound { get; set; }

        #endregion

        #region Misc properties

        // Rewards
        public ushort Experience { get; set; }
        public byte Coins { get; set; }
        public byte YoshiCookie { get; set; }
        public byte ItemWinA { get; set; }
        public byte ItemWinB { get; set; }

        // Cursor
        public byte CursorX { get; set; }
        public byte CursorY { get; set; }

        // Psychopath
        public bool SetPsychopath(string value, bool byteView)
        {
            this.RawPsychopath = parserReduced.Encode(value.ToCharArray(), byteView, 0, Lists.Keystrokes);
            this.PsychopathError = parserReduced.Error;
            return !PsychopathError;
        }
        public string GetPsychopath(bool byteView)
        {
            if (!PsychopathError)
                return new string(parserReduced.Decode(RawPsychopath, byteView, 0, Lists.Keystrokes));
            else
                return new string(RawPsychopath);
        }
        public char[] RawPsychopath { get; set; }
        public bool PsychopathError { get; set; }
        private Dialogues.ParserReduced parserReduced
        {
            get { return Dialogues.ParserReduced.Instance; }
        }

        #endregion

        // Image accessors
        public Image Image
        {
            get
            {
                int[] pixels = Pixels;
                int[] palette = Fonts.Model.Palette_Numerals.Palette;
                int[] cursor = Do.GetPixelRegion(Fonts.Model.Graphics_Numerals, 0x20, palette, 16, 12, 0, 2, 2, 0);
                for (int y = 112 - (CursorY * 8), n = 0; n < 16; y++, n++)
                {
                    for (int x = 112 - (CursorX * 8), m = 0; m < 16; x++, m++)
                    {
                        if (cursor[n * 16 + m] != 0 &&
                            y >= 0 && y < 256 && x >= 0 && x < 256)
                            pixels[y * 256 + x] = cursor[n * 16 + m];
                    }
                }
                return Do.PixelsToImage(pixels, 256, 256);
            }
        }
        public int[] Pixels
        {
            get
            {
                return Sprites.Model.Sprites[this.Index + 256].GetPixels();
            }
        }
        public int[] Shadow
        {
            get
            {
                int[] palette = Sprites.Model.Sprites[this.Index + 256].Palette;
                return Do.GetPixelRegion(Fonts.Model.Graphics_Numerals, 0x20, palette, 16, 14, 0, 2, 2, 0);
            }
        }

        #endregion

        // Constructor
        public Monster(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            // Name
            Name = new char[13];
            for (int i = 0; i < Name.Length; i++)
                Name[i] = (char)rom[(Index * 13) + 0x3992d1 + i];

            // Psychopath
            RawPsychopath = ParsePsychopath(rom);

            // Stats offset
            int offset = Bits.GetShort(rom, 0x390026 + Index * 2) + 0x390000;

            // Byte 0,1
            HP = Bits.GetShort(rom, offset); offset += 2;

            // Byte 2-9
            Speed = rom[offset++];
            Attack = rom[offset++];
            Defense = rom[offset++];
            MagicAttack = rom[offset++];
            MagicDefense = rom[offset++];
            FP = rom[offset++];
            Evade = rom[offset++];
            MagicEvade = rom[offset++];

            // Byte 10
            byte temp = rom[offset++];
            DisableAutoDeath = (temp & 0x01) == 1;
            Palette2bpp = (temp & 0x02) == 2;

            // Byte 11
            temp = rom[offset++];
            Invincible = (temp & 0x01) == 1;
            MortalityProtection = (temp & 0x02) == 2;
            MorphSuccess = (byte)((temp & 0x0C) >> 2);
            StrikeSound = (byte)(temp >> 4);

            // Byte 12
            temp = rom[offset++];
            ElemNullIce = (temp & 0x10) == 0x10;
            ElemNullThunder = (temp & 0x20) == 0x20;
            ElemNullFire = (temp & 0x40) == 0x40;
            ElemNullJump = (temp & 0x80) == 0x80;

            // Byte 13
            temp = rom[offset];
            OtherSound = (byte)(rom[offset++] & 7);
            ElemWeakIce = (temp & 0x10) == 0x10;
            ElemWeakThunder = (temp & 0x20) == 0x20;
            ElemWeakFire = (temp & 0x40) == 0x40;
            ElemWeakJump = (temp & 0x80) == 0x80;

            // Byte 14
            Status status = (Status)rom[offset++];
            EffectNullMute = (status & Status.Mute) == Status.Mute;
            EffectNullSleep = (status & Status.Sleep) == Status.Sleep;
            EffectNullPoison = (status & Status.Poison) == Status.Poison;
            EffectNullFear = (status & Status.Fear) == Status.Fear;
            EffectNullMushroom = (status & Status.Mushroom) == Status.Mushroom;
            EffectNullScarecrow = (status & Status.Scarecrow) == Status.Scarecrow;
            EffectNullInvincible = (status & Status.Invincible) == Status.Invincible;

            // Byte 15
            temp = rom[offset++];
            EntranceStyle = (byte)(temp & 0x0F);
            Elevation = (byte)((temp & 0x30) >> 4);
            CoinSize = (byte)(temp >> 6);

            // Rewards
            offset = Bits.GetShort(rom, 0x39142a + Index * 2) + 0x390000;
            Experience = Bits.GetShort(rom, offset); offset += 2;
            Coins = rom[offset++];
            YoshiCookie = rom[offset++];
            ItemWinA = rom[offset++];
            ItemWinB = rom[offset++];

            // Flower bonus
            offset = Index + 0x39BB44;
            FlowerBonus = (byte)(rom[offset] & 0x0F);
            FlowerOdds = (byte)Math.Min(10, (temp & 0xF0) >> 4);

            // Death animation
            offset = Index * 2 + 0x350202;
            switch (Bits.GetShort(rom, offset))
            {
                case 0x058A: SpriteBehavior = 0; break;  // no movement for "Escape"
                case 0x0596: SpriteBehavior = 1; break;  // slide backward when hit
                case 0x05A2: SpriteBehavior = 2; break;  // Bowser Clone sprite
                case 0x05AE: SpriteBehavior = 3; break;  // Mario Clone sprite
                case 0x05BA: SpriteBehavior = 4; break;  // no reaction when hit
                case 0x0898: SpriteBehavior = 5; break;  // sprite shadow
                case 0x0985: SpriteBehavior = 6; break;  // floating, sprite shadow
                case 0x0991: SpriteBehavior = 7; break;  // floating
                case 0x0AD3: SpriteBehavior = 8; break;  // floating, slide backward when hit
                case 0x0ADF: SpriteBehavior = 9; break;  // floating, slide backward when hit
                case 0x0AEB: SpriteBehavior = 10; break;  // fade out death, floating
                case 0x0CF2: SpriteBehavior = 11; break;  // fade out death
                case 0x0CFE: SpriteBehavior = 12; break;  // fade out death
                case 0x0D0A: SpriteBehavior = 13; break;  // fade out death, Smithy spell cast
                case 0x0D16: SpriteBehavior = 14; break;  // fade out death, no "Escape" movement
                case 0x0E60: SpriteBehavior = 15; break;  // fade out death, no "Escape" transition
                case 0x0E6C: SpriteBehavior = 16; break;  // (normal)
                case 0x0E78: SpriteBehavior = 17; break;  // no reaction when hit
                default: SpriteBehavior = 0; break;
            }

            // Cursor
            CursorX = (byte)((rom[0x39B944 + Index] & 0xF0) >> 4);
            CursorY = (byte)(rom[0x39B944 + Index] & 0x0F);
        }
        public void WriteToROM(ref int psychopathOffset)
        {
            // Name
            Bits.SetChars(rom, 0x3992d1 + (Index * 13), Name);

            // Psychopath
            int length = 0;
            Bits.SetShort(rom, 0x399FD1 + Index * 2, psychopathOffset);
            if (this.PsychopathError)
                MessageBox.Show("There was a problem saving monster #" + this.Index + "'s psychopath message.");
            else
            {
                length = RawPsychopath.Length;
                Bits.SetChars(rom, 0x390000 + psychopathOffset, RawPsychopath);
            }
            psychopathOffset += length;

            // Stats offset
            int offset = Bits.GetShort(rom, 0x390026 + Index * 2) + 0x390000;

            // Byte 0
            Bits.SetShort(rom, offset, HP); offset += 2;

            // Byte 1-8
            rom[offset++] = Speed;
            rom[offset++] = Attack;
            rom[offset++] = Defense;
            rom[offset++] = MagicAttack;
            rom[offset++] = MagicDefense;
            rom[offset++] = FP;
            rom[offset++] = Evade;
            rom[offset++] = MagicEvade;

            // Byte 9
            Bits.SetBit(rom, offset, 0, DisableAutoDeath);
            Bits.SetBit(rom, offset++, 1, Palette2bpp);

            // Byte 10
            rom[offset] = (byte)((StrikeSound << 4) + (MorphSuccess << 2));
            Bits.SetBit(rom, offset, 0, Invincible);
            Bits.SetBit(rom, offset++, 1, MortalityProtection);

            // Byte 11
            Bits.SetBit(rom, offset, 4, ElemNullIce);
            Bits.SetBit(rom, offset, 5, ElemNullThunder);
            Bits.SetBit(rom, offset, 6, ElemNullFire);
            Bits.SetBit(rom, offset++, 7, ElemNullJump);

            // Byte 12
            rom[offset] = OtherSound;
            Bits.SetBit(rom, offset, 4, ElemWeakIce);
            Bits.SetBit(rom, offset, 5, ElemWeakThunder);
            Bits.SetBit(rom, offset, 6, ElemWeakFire);
            Bits.SetBit(rom, offset++, 7, ElemWeakJump);

            // Byte 13
            Bits.SetBit(rom, offset, 0, EffectNullMute);
            Bits.SetBit(rom, offset, 1, EffectNullSleep);
            Bits.SetBit(rom, offset, 2, EffectNullPoison);
            Bits.SetBit(rom, offset, 3, EffectNullFear);
            Bits.SetBit(rom, offset, 5, EffectNullMushroom);
            Bits.SetBit(rom, offset, 6, EffectNullScarecrow);
            Bits.SetBit(rom, offset++, 7, EffectNullInvincible);

            // Byte 14
            rom[offset] = (byte)(EntranceStyle + (Elevation << 4) + (CoinSize << 6));

            // Rewards
            offset = Bits.GetShort(rom, 0x39142a + Index * 2) + 0x390000;
            Bits.SetShort(rom, offset, Experience); offset += 2;
            rom[offset++] = Coins;
            rom[offset++] = YoshiCookie;
            rom[offset++] = ItemWinA;
            rom[offset++] = ItemWinB;

            // Flower bonus
            offset = Index + 0x39BB44;
            rom[offset] = (byte)(FlowerBonus + (FlowerOdds << 4));

            // Death animation
            offset = Index * 2 + 0x350202;
            switch (SpriteBehavior)								// DEATH ANIMATION
            {
                case 0: Bits.SetShort(rom, offset, 0x058A); break;	// no movement for "Escape"
                case 1: Bits.SetShort(rom, offset, 0x0596); break;	// slide backward when hit
                case 2: Bits.SetShort(rom, offset, 0x05A2); break;	// etc...
                case 3: Bits.SetShort(rom, offset, 0x05AE); break;
                case 4: Bits.SetShort(rom, offset, 0x05BA); break;
                case 5: Bits.SetShort(rom, offset, 0x0898); break;
                case 6: Bits.SetShort(rom, offset, 0x0985); break;
                case 7: Bits.SetShort(rom, offset, 0x0991); break;
                case 8: Bits.SetShort(rom, offset, 0x0AD3); break;
                case 9: Bits.SetShort(rom, offset, 0x0ADF); break;
                case 10: Bits.SetShort(rom, offset, 0x0AEB); break;
                case 11: Bits.SetShort(rom, offset, 0x0CF2); break;
                case 12: Bits.SetShort(rom, offset, 0x0CFE); break;
                case 13: Bits.SetShort(rom, offset, 0x0D0A); break;
                case 14: Bits.SetShort(rom, offset, 0x0D16); break;
                case 15: Bits.SetShort(rom, offset, 0x0E60); break;
                case 16: Bits.SetShort(rom, offset, 0x0E6C); break;
                case 17: Bits.SetShort(rom, offset, 0x0E78); break;
            }

            // Cursor
            rom[0x39B944 + Index] = (byte)(CursorX << 4);
            rom[0x39B944 + Index] |= CursorY;
        }

        // Inherited
        public override void Clear()
        {
            Bits.Fill(Name, '\x20');
            RawPsychopath = new char[0];
            HP = 0;
            Speed = 0;
            Attack = 0;
            Defense = 0;
            MagicAttack = 0;
            MagicDefense = 0;
            FP = 0;
            Evade = 0;
            MagicEvade = 0;
            Experience = 0;
            Coins = 0;
            YoshiCookie = 0;
            ItemWinA = 0;
            ItemWinB = 0;
            ElemNullIce = false;
            ElemNullThunder = false;
            ElemNullFire = false;
            ElemNullJump = false;
            ElemWeakIce = false;
            ElemWeakThunder = false;
            ElemWeakFire = false;
            ElemWeakJump = false;
            EffectNullMute = false;
            EffectNullSleep = false;
            EffectNullPoison = false;
            EffectNullFear = false;
            EffectNullMushroom = false;
            EffectNullScarecrow = false;
            EffectNullInvincible = false;
            Invincible = false;
            MortalityProtection = false;
            DisableAutoDeath = false;
            Palette2bpp = false;
            MorphSuccess = 0;
            FlowerBonus = 0;
            FlowerOdds = 0;
            EntranceStyle = 0;
            CoinSize = 0;
            Elevation = 0;
            SpriteBehavior = 0;
            StrikeSound = 0;
            OtherSound = 0;
        }

        // Text
        private char[] ParsePsychopath(byte[] data)
        {
            int offset = 0x390000 + Bits.GetShort(data, 0x399FD1 + Index * 2);
            int counter = offset;
            int length = 0;
            int letter = -1;
            while (letter != 0)
            {
                letter = data[counter++];
                length++;
            }
            char[] psychopath = new char[length];
            for (int i = 0; i < length; i++)
                psychopath[i] = (char)data[offset + i];
            return psychopath;
        }

        #endregion
    }
}
