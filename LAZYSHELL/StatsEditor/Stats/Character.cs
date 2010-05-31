using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.StatsEditor.Stats
{
    public class Character
    {
        private byte[] data;
        public byte[] Data
        {
            get { return this.data; }
            set
            {
                this.data = value;
                foreach (Level l in levels)
                    if (l != null)
                        l.Data = value;
            }
        }

        #region Character Stats
        private int characterNum;
        private byte currentLevel = 2;
        private Level[] levels;

        private string name;
        private byte startingLevel;
        private ushort startingCurrentHP;
        private ushort startingMaxHP;
        private byte startingSpeed;
        private byte startingAttack;
        private byte startingDefense;
        private byte startingMgAttack;
        private byte startingMgDefense;
        private ushort startingExperience;
        private byte startingWeapon;
        private byte startingArmor;
        private byte startingAccessory;
        private bool jump;
        private bool fireOrb;
        private bool superJump;
        private bool superFlame;
        private bool ultraJump;
        private bool ultraFlame;
        private bool therapy;
        private bool groupHug;
        private bool sleepyTime;
        private bool comeBack;
        private bool mute;
        private bool psychBomb;
        private bool terrorize;
        private bool poisonGas;
        private bool crusher;
        private bool bowserCrush;
        private bool genoBeam;
        private bool genoBoost;
        private bool genoWhirl;
        private bool genoBlast;
        private bool genoFlash;
        private bool thunderbolt;
        private bool hpRain;
        private bool psychopath;
        private bool shocker;
        private bool snowy;
        private bool starRain;
        private ushort startingCoins;
        private byte startingCurrentFP;
        private byte startingMaximumFP;
        private ushort startingFrogCoins;

        #endregion

        #region Accessors
        public byte CurrentLevel { get { return this.currentLevel; } set { this.currentLevel = value; } }
        public string Name { get { return this.name; } set { this.name = PadString(value, 10); } }
        public byte StartingLevel { get { return this.startingLevel; } set { this.startingLevel = value; } }
        public ushort StartingCurrentHP { get { return this.startingCurrentHP; } set { this.startingCurrentHP = value; } }
        public ushort StartingMaxHP { get { return this.startingMaxHP; } set { this.startingMaxHP = value; } }
        public byte StartingSpeed { get { return this.startingSpeed; } set { this.startingSpeed = value; } }
        public byte StartingAttack { get { return this.startingAttack; } set { this.startingAttack = value; } }
        public byte StartingDefense { get { return this.startingDefense; } set { this.startingDefense = value; } }
        public byte StartingMgAttack { get { return this.startingMgAttack; } set { this.startingMgAttack = value; } }
        public byte StartingMgDefense { get { return this.startingMgDefense; } set { this.startingMgDefense = value; } }
        public ushort StartingExperience { get { return this.startingExperience; } set { this.startingExperience = value; } }
        public byte StartingWeapon { get { return this.startingWeapon; } set { this.startingWeapon = value; } }
        public byte StartingArmor { get { return this.startingArmor; } set { this.startingArmor = value; } }
        public byte StartingAccessory { get { return this.startingAccessory; } set { this.startingAccessory = value; } }
        public bool Jump { get { return this.jump; } set { this.jump = value; } }
        public bool FireOrb { get { return this.fireOrb; } set { this.fireOrb = value; } }
        public bool SuperJump { get { return this.superJump; } set { this.superJump = value; } }
        public bool SuperFlame { get { return this.superFlame; } set { this.superFlame = value; } }
        public bool UltraJump { get { return this.ultraJump; } set { this.ultraJump = value; } }
        public bool UltraFlame { get { return this.ultraFlame; } set { this.ultraFlame = value; } }
        public bool Therapy { get { return this.therapy; } set { this.therapy = value; } }
        public bool GroupHug { get { return this.groupHug; } set { this.groupHug = value; } }
        public bool SleepyTime { get { return this.sleepyTime; } set { this.sleepyTime = value; } }
        public bool ComeBack { get { return this.comeBack; } set { this.comeBack = value; } }
        public bool Mute { get { return this.mute; } set { this.mute = value; } }
        public bool PsychBomb { get { return this.psychBomb; } set { this.psychBomb = value; } }
        public bool Terrorize { get { return this.terrorize; } set { this.terrorize = value; } }
        public bool PoisonGas { get { return this.poisonGas; } set { this.poisonGas = value; } }
        public bool Crusher { get { return this.crusher; } set { this.crusher = value; } }
        public bool BowserCrush { get { return this.bowserCrush; } set { this.bowserCrush = value; } }
        public bool GenoBeam { get { return this.genoBeam; } set { this.genoBeam = value; } }
        public bool GenoBoost { get { return this.genoBoost; } set { this.genoBoost = value; } }
        public bool GenoWhirl { get { return this.genoWhirl; } set { this.genoWhirl = value; } }
        public bool GenoBlast { get { return this.genoBlast; } set { this.genoBlast = value; } }
        public bool GenoFlash { get { return this.genoFlash; } set { this.genoFlash = value; } }
        public bool Thunderbolt { get { return this.thunderbolt; } set { this.thunderbolt = value; } }
        public bool HPRain { get { return this.hpRain; } set { this.hpRain = value; } }
        public bool Psychopath { get { return this.psychopath; } set { this.psychopath = value; } }
        public bool Shocker { get { return this.shocker; } set { this.shocker = value; } }
        public bool Snowy { get { return this.snowy; } set { this.snowy = value; } }
        public bool StarRain { get { return this.starRain; } set { this.starRain = value; } }
        public ushort StartingCoins { get { return this.startingCoins; } set { this.startingCoins = value; } }
        public byte StartingCurrentFP { get { return this.startingCurrentFP; } set { this.startingCurrentFP = value; } }
        public byte StartingMaximumFP { get { return this.startingMaximumFP; } set { this.startingMaximumFP = value; } }
        public ushort StartingFrogCoins { get { return this.startingFrogCoins; } set { this.startingFrogCoins = value; } }

        public ushort LevelExpNeeded { get { return this.levels[currentLevel].ExpNeeded; } set { this.levels[currentLevel].ExpNeeded = value; } }
        public byte LevelHpPlus { get { return this.levels[currentLevel].HpPlus; } set { this.levels[currentLevel].HpPlus = value; } }
        public byte LevelAttackPlus { get { return this.levels[currentLevel].AttackPlus; } set { this.levels[currentLevel].AttackPlus = value; } }
        public byte LevelDefensePlus { get { return this.levels[currentLevel].DefensePlus; } set { this.levels[currentLevel].DefensePlus = value; } }
        public byte LevelMgAttackPlus { get { return this.levels[currentLevel].MgAttackPlus; } set { this.levels[currentLevel].MgAttackPlus = value; } }
        public byte LevelMgDefensePlus { get { return this.levels[currentLevel].MgDefensePlus; } set { this.levels[currentLevel].MgDefensePlus = value; } }
        public byte LevelHpPlusBonus { get { return this.levels[currentLevel].HpPlusBonus; } set { this.levels[currentLevel].HpPlusBonus = value; } }
        public byte LevelAttackPlusBonus { get { return this.levels[currentLevel].AttackPlusBonus; } set { this.levels[currentLevel].AttackPlusBonus = value; } }
        public byte LevelDefensePlusBonus { get { return this.levels[currentLevel].DefensePlusBonus; } set { this.levels[currentLevel].DefensePlusBonus = value; } }
        public byte LevelMgAttackPlusBonus { get { return this.levels[currentLevel].MgAttackPlusBonus; } set { this.levels[currentLevel].MgAttackPlusBonus = value; } }
        public byte LevelMgDefensePlusBonus { get { return this.levels[currentLevel].MgDefensePlusBonus; } set { this.levels[currentLevel].MgDefensePlusBonus = value; } }

        public byte LevelSpellLearned { get { return this.levels[currentLevel].SpellLearned; } set { this.levels[currentLevel].SpellLearned = value; } }

        #endregion



        public Character(byte[] data, int characterNum)
        {
            this.data = data;
            this.characterNum = characterNum;
            this.currentLevel = 2;
            InitializeCharacter();
        }
        private void InitializeCharacter()
        {
            byte temp;

            int charStartOffset = (characterNum * 20) + 0x3A002C;

            startingLevel = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingCurrentHP = BitManager.GetShort(data, charStartOffset); charStartOffset += 2;
            startingMaxHP = BitManager.GetShort(data, charStartOffset); charStartOffset += 2;
            startingSpeed = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingAttack = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingDefense = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingMgAttack = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingMgDefense = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingExperience = BitManager.GetShort(data, charStartOffset); charStartOffset += 2;
            startingWeapon = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingArmor = BitManager.GetByte(data, charStartOffset); charStartOffset++;
            startingAccessory = BitManager.GetByte(data, charStartOffset); charStartOffset += 2;

            temp = BitManager.GetByte(data, charStartOffset); charStartOffset++;

            Jump = (temp & 0x01) == 0x01;
            FireOrb = (temp & 0x02) == 0x02;
            SuperJump = (temp & 0x04) == 0x04;
            SuperFlame = (temp & 0x08) == 0x08;
            UltraJump = (temp & 0x10) == 0x10;
            UltraFlame = (temp & 0x20) == 0x20;
            Therapy = (temp & 0x40) == 0x40;
            GroupHug = (temp & 0x80) == 0x80;

            temp = BitManager.GetByte(data, charStartOffset); charStartOffset++;

            SleepyTime = (temp & 0x01) == 0x01;
            ComeBack = (temp & 0x02) == 0x02;
            Mute = (temp & 0x04) == 0x04;
            PsychBomb = (temp & 0x08) == 0x08;
            Terrorize = (temp & 0x10) == 0x10;
            PoisonGas = (temp & 0x20) == 0x20;
            Crusher = (temp & 0x40) == 0x40;
            BowserCrush = (temp & 0x80) == 0x80;

            temp = BitManager.GetByte(data, charStartOffset); charStartOffset++;

            GenoBeam = (temp & 0x01) == 0x01;
            GenoBoost = (temp & 0x02) == 0x02;
            GenoWhirl = (temp & 0x04) == 0x04;
            GenoBlast = (temp & 0x08) == 0x08;
            GenoFlash = (temp & 0x10) == 0x10;
            Thunderbolt = (temp & 0x20) == 0x20;
            HPRain = (temp & 0x40) == 0x40;
            Psychopath = (temp & 0x80) == 0x80;

            temp = BitManager.GetByte(data, charStartOffset); charStartOffset++;

            Shocker = (temp & 0x01) == 0x01;
            Snowy = (temp & 0x02) == 0x02;
            StarRain = (temp & 0x04) == 0x04;

            // set up the levels
            byte numberOfLevels = 31;
            levels = new Level[numberOfLevels];
            for (byte i = 2; i < numberOfLevels; i++)
            {
                levels[i] = new Level(data, i, characterNum);
            }

            startingCoins = BitManager.GetShort(data, 0x3A00DB);
            startingCurrentFP = BitManager.GetByte(data, 0x3A00DD);
            startingMaximumFP = BitManager.GetByte(data, 0x3A00DE);
            startingFrogCoins = BitManager.GetShort(data, 0x3A00DF);

            this.name = byteToStr(BitManager.GetByteArray(data, 0x3a134d + (characterNum * 10), 10));
        }
        public void Assemble()
        {
            int charStartOffset = (characterNum * 20) + 0x3A002C;

            BitManager.SetByte(data, charStartOffset, startingLevel); charStartOffset++;
            BitManager.SetShort(data, charStartOffset, startingCurrentHP); charStartOffset += 2;
            BitManager.SetShort(data, charStartOffset, startingMaxHP); charStartOffset += 2;
            BitManager.SetByte(data, charStartOffset, startingSpeed); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingAttack); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingDefense); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingMgAttack); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingMgDefense); charStartOffset++;
            BitManager.SetShort(data, charStartOffset, startingExperience); charStartOffset += 2;
            BitManager.SetByte(data, charStartOffset, startingWeapon); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingArmor); charStartOffset++;
            BitManager.SetByte(data, charStartOffset, startingAccessory); charStartOffset += 2;

            BitManager.SetBit(data, charStartOffset, 0, Jump);
            BitManager.SetBit(data, charStartOffset, 1, FireOrb);
            BitManager.SetBit(data, charStartOffset, 2, SuperJump);
            BitManager.SetBit(data, charStartOffset, 3, SuperFlame);
            BitManager.SetBit(data, charStartOffset, 4, UltraJump);
            BitManager.SetBit(data, charStartOffset, 5, UltraFlame);
            BitManager.SetBit(data, charStartOffset, 6, Therapy);
            BitManager.SetBit(data, charStartOffset, 7, GroupHug);
            charStartOffset++;

            BitManager.SetBit(data, charStartOffset, 0, SleepyTime);
            BitManager.SetBit(data, charStartOffset, 1, ComeBack);
            BitManager.SetBit(data, charStartOffset, 2, Mute);
            BitManager.SetBit(data, charStartOffset, 3, PsychBomb);
            BitManager.SetBit(data, charStartOffset, 4, Terrorize);
            BitManager.SetBit(data, charStartOffset, 5, PoisonGas);
            BitManager.SetBit(data, charStartOffset, 6, Crusher);
            BitManager.SetBit(data, charStartOffset, 7, BowserCrush);
            charStartOffset++;

            BitManager.SetBit(data, charStartOffset, 0, GenoBeam);
            BitManager.SetBit(data, charStartOffset, 1, GenoBoost);
            BitManager.SetBit(data, charStartOffset, 2, GenoWhirl);
            BitManager.SetBit(data, charStartOffset, 3, GenoBlast);
            BitManager.SetBit(data, charStartOffset, 4, GenoFlash);
            BitManager.SetBit(data, charStartOffset, 5, Thunderbolt);
            BitManager.SetBit(data, charStartOffset, 6, HPRain);
            BitManager.SetBit(data, charStartOffset, 7, Psychopath);
            charStartOffset++;

            BitManager.SetBit(data, charStartOffset, 0, Shocker);
            BitManager.SetBit(data, charStartOffset, 1, Snowy);
            BitManager.SetBit(data, charStartOffset, 2, StarRain);
            charStartOffset++;

            foreach (Level l in levels)
                if (l != null)
                    l.Assemble();

            if (characterNum == 0)
            {
                BitManager.SetShort(data, 0x3A00DB, startingCoins);
                BitManager.SetByte(data, 0x3A00DD, startingCurrentFP);
                BitManager.SetByte(data, 0x3A00DE, startingMaximumFP);
                BitManager.SetShort(data, 0x3A00DF, startingFrogCoins);
            }

            BitManager.SetByteArray(data, 0x3a134d + (characterNum * 10), strToByte(this.name));
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

        class Level
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte levelNum;
            private int characterOwner;

            private ushort expNeeded; public ushort ExpNeeded { get { return this.expNeeded; } set { this.expNeeded = value; } }
            private byte hpPlus; public byte HpPlus { get { return this.hpPlus; } set { this.hpPlus = value; } }
            private byte attackPlus; public byte AttackPlus { get { return this.attackPlus; } set { this.attackPlus = value; } }
            private byte defensePlus; public byte DefensePlus { get { return this.defensePlus; } set { this.defensePlus = value; } }
            private byte mgAttackPlus; public byte MgAttackPlus { get { return this.mgAttackPlus; } set { this.mgAttackPlus = value; } }
            private byte mgDefensePlus; public byte MgDefensePlus { get { return this.mgDefensePlus; } set { this.mgDefensePlus = value; } }
            private byte hpPlusBonus; public byte HpPlusBonus { get { return this.hpPlusBonus; } set { this.hpPlusBonus = value; } }
            private byte attackPlusBonus; public byte AttackPlusBonus { get { return this.attackPlusBonus; } set { this.attackPlusBonus = value; } }
            private byte defensePlusBonus; public byte DefensePlusBonus { get { return this.defensePlusBonus; } set { this.defensePlusBonus = value; } }
            private byte mgAttackPlusBonus; public byte MgAttackPlusBonus { get { return this.mgAttackPlusBonus; } set { this.mgAttackPlusBonus = value; } }
            private byte mgDefensePlusBonus; public byte MgDefensePlusBonus { get { return this.mgDefensePlusBonus; } set { this.mgDefensePlusBonus = value; } }

            private byte spellLearned; public byte SpellLearned { get { return this.spellLearned; } set { this.spellLearned = value; } }

            public Level(byte[] data, byte levelNum, int characterOwner)
            {
                this.data = data;
                this.levelNum = (byte)levelNum;
                this.characterOwner = (byte)characterOwner;
                InitializeLevel();
            }
            private void InitializeLevel()
            {
                // Initialize all the stats for this level

                byte temp;

                int expNeededOffset = 0x3A1AFF + ((levelNum - 2) * 2);

                expNeeded = BitManager.GetShort(data, expNeededOffset);

                int charLevelStatOffset = (characterOwner * 3) + ((levelNum - 2) * 15) + 0x3A1B39;

                hpPlus = BitManager.GetByte(data, charLevelStatOffset); charLevelStatOffset++;
                temp = BitManager.GetByte(data, charLevelStatOffset); attackPlus = (byte)((temp & 0xF0) >> 4);
                temp = BitManager.GetByte(data, charLevelStatOffset); defensePlus = (byte)((temp & 0x0F)); charLevelStatOffset++;
                temp = BitManager.GetByte(data, charLevelStatOffset); mgAttackPlus = (byte)((temp & 0xF0) >> 4);
                temp = BitManager.GetByte(data, charLevelStatOffset); mgDefensePlus = (byte)((temp & 0x0F)); charLevelStatOffset++;

                int charLevelStatBonusOffset = (characterOwner * 3) + ((levelNum - 2) * 15) + 0x3A1CEC;

                hpPlusBonus = BitManager.GetByte(data, charLevelStatBonusOffset); charLevelStatBonusOffset++;
                temp = BitManager.GetByte(data, charLevelStatBonusOffset); attackPlusBonus = (byte)((temp & 0xF0) >> 4);
                temp = BitManager.GetByte(data, charLevelStatBonusOffset); defensePlusBonus = (byte)((temp & 0x0F)); charLevelStatBonusOffset++;
                temp = BitManager.GetByte(data, charLevelStatBonusOffset); mgAttackPlusBonus = (byte)((temp & 0xF0) >> 4);
                temp = BitManager.GetByte(data, charLevelStatBonusOffset); mgDefensePlusBonus = (byte)((temp & 0x0F)); charLevelStatBonusOffset++;

                spellLearned = data[characterOwner + ((levelNum - 2) * 5) + 0x3A42F5];
                if (spellLearned > 0x1F)
                    spellLearned = 0x20;
            }
            public void Assemble()
            {
                int expNeededOffset = ((levelNum - 2) * 2) + 0x3A1AFF;

                if (characterOwner == 0)
                    BitManager.SetShort(data, expNeededOffset, expNeeded);

                int charLevelStatOffset = (characterOwner * 3) + ((levelNum - 2) * 15) + 0x3A1B39;

                BitManager.SetByte(data, charLevelStatOffset, hpPlus); charLevelStatOffset++;
                BitManager.SetByte(data, charLevelStatOffset, (byte)((attackPlus << 4) + defensePlus)); charLevelStatOffset++;
                BitManager.SetByte(data, charLevelStatOffset, (byte)((mgAttackPlus << 4) + mgDefensePlus)); charLevelStatOffset++;

                int charLevelStatBonusOffset = (characterOwner * 3) + ((levelNum - 2) * 15) + 0x3A1CEC;

                BitManager.SetByte(data, charLevelStatBonusOffset, hpPlusBonus); charLevelStatBonusOffset++;
                BitManager.SetByte(data, charLevelStatBonusOffset, (byte)((attackPlusBonus << 4) + defensePlusBonus)); charLevelStatBonusOffset++;
                BitManager.SetByte(data, charLevelStatBonusOffset, (byte)((mgAttackPlusBonus << 4) + mgDefensePlusBonus)); charLevelStatBonusOffset++;

                if (spellLearned == 0x20)
                    data[characterOwner + ((levelNum - 2) * 5) + 0x3A42F5] = 0xFF;
                else
                    data[characterOwner + ((levelNum - 2) * 5) + 0x3A42F5] = spellLearned;
            }
            public void Clear()
            {
                expNeeded = 0;
                hpPlus = 0;
                attackPlus = 0;
                defensePlus = 0;
                mgAttackPlus = 0;
                mgDefensePlus = 0;
                hpPlusBonus = 0;
                attackPlusBonus = 0;
                defensePlusBonus = 0;
                mgAttackPlusBonus = 0;
                mgDefensePlusBonus = 0;
                spellLearned = 0;
            }
        }
    }
}
