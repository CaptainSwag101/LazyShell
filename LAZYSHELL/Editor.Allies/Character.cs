using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Character : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data
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
        public override int Index { get { return index; } set { index = value; } }
        #region Character Stats
        private int index;
        private byte currentLevel = 2;
        private Level[] levels;
        public Level[] Levels { get { return levels; } }

        private char[] name;
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
        private bool dummy27;
        private bool dummy28;
        private bool dummy29;
        private bool dummy30;
        private bool dummy31;
        private ushort startingCoins;
        private byte startingCurrentFP;
        private byte startingMaximumFP;
        private ushort startingFrogCoins;
        private byte defenseStartLevel1;
        private byte defenseStartLevel2;
        private byte defenseEndLevel2;
        private byte defenseEndLevel1;

        #endregion
        #region Accessors
        public byte CurrentLevel { get { return this.currentLevel; } set { this.currentLevel = value; } }
        public char[] Name { get { return this.name; } set { this.name = value; } }
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
        public bool Dummy27 { get { return this.dummy27; } set { this.dummy27 = value; } }
        public bool Dummy28 { get { return this.dummy28; } set { this.dummy28 = value; } }
        public bool Dummy29 { get { return this.dummy29; } set { this.dummy29 = value; } }
        public bool Dummy30 { get { return this.dummy30; } set { this.dummy30 = value; } }
        public bool Dummy31 { get { return this.dummy31; } set { this.dummy31 = value; } }
        public ushort StartingCoins { get { return this.startingCoins; } set { this.startingCoins = value; } }
        public byte StartingCurrentFP { get { return this.startingCurrentFP; } set { this.startingCurrentFP = value; } }
        public byte StartingMaximumFP { get { return this.startingMaximumFP; } set { this.startingMaximumFP = value; } }
        public ushort StartingFrogCoins { get { return this.startingFrogCoins; } set { this.startingFrogCoins = value; } }
        public byte DefenseStartLevel1 { get { return this.defenseStartLevel1; } set { this.defenseStartLevel1 = value; } }
        public byte DefenseStartLevel2 { get { return this.defenseStartLevel2; } set { this.defenseStartLevel2 = value; } }
        public byte DefenseEndLevel2 { get { return this.defenseEndLevel2; } set { this.defenseEndLevel2 = value; } }
        public byte DefenseEndLevel1 { get { return this.defenseEndLevel1; } set { this.defenseEndLevel1 = value; } }

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
        public Character(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            this.currentLevel = 2;
            InitializeCharacter();
        }
        private void InitializeCharacter()
        {
            byte temp;

            int charStartOffset = (index * 20) + 0x3A002C;

            startingLevel = data[charStartOffset]; charStartOffset++;
            startingCurrentHP = Bits.GetShort(data, charStartOffset); charStartOffset += 2;
            startingMaxHP = Bits.GetShort(data, charStartOffset); charStartOffset += 2;
            startingSpeed = data[charStartOffset]; charStartOffset++;
            startingAttack = data[charStartOffset]; charStartOffset++;
            startingDefense = data[charStartOffset]; charStartOffset++;
            startingMgAttack = data[charStartOffset]; charStartOffset++;
            startingMgDefense = data[charStartOffset]; charStartOffset++;
            startingExperience = Bits.GetShort(data, charStartOffset); charStartOffset += 2;
            startingWeapon = data[charStartOffset]; charStartOffset++;
            startingArmor = data[charStartOffset]; charStartOffset++;
            startingAccessory = data[charStartOffset]; charStartOffset += 2;

            temp = data[charStartOffset]; charStartOffset++;

            Jump = (temp & 0x01) == 0x01;
            FireOrb = (temp & 0x02) == 0x02;
            SuperJump = (temp & 0x04) == 0x04;
            SuperFlame = (temp & 0x08) == 0x08;
            UltraJump = (temp & 0x10) == 0x10;
            UltraFlame = (temp & 0x20) == 0x20;
            Therapy = (temp & 0x40) == 0x40;
            GroupHug = (temp & 0x80) == 0x80;

            temp = data[charStartOffset]; charStartOffset++;

            SleepyTime = (temp & 0x01) == 0x01;
            ComeBack = (temp & 0x02) == 0x02;
            Mute = (temp & 0x04) == 0x04;
            PsychBomb = (temp & 0x08) == 0x08;
            Terrorize = (temp & 0x10) == 0x10;
            PoisonGas = (temp & 0x20) == 0x20;
            Crusher = (temp & 0x40) == 0x40;
            BowserCrush = (temp & 0x80) == 0x80;

            temp = data[charStartOffset]; charStartOffset++;

            GenoBeam = (temp & 0x01) == 0x01;
            GenoBoost = (temp & 0x02) == 0x02;
            GenoWhirl = (temp & 0x04) == 0x04;
            GenoBlast = (temp & 0x08) == 0x08;
            GenoFlash = (temp & 0x10) == 0x10;
            Thunderbolt = (temp & 0x20) == 0x20;
            HPRain = (temp & 0x40) == 0x40;
            Psychopath = (temp & 0x80) == 0x80;

            temp = data[charStartOffset]; charStartOffset++;

            Shocker = (temp & 0x01) == 0x01;
            Snowy = (temp & 0x02) == 0x02;
            StarRain = (temp & 0x04) == 0x04;
            Dummy27 = (temp & 0x08) == 0x08;
            Dummy28 = (temp & 0x10) == 0x10;
            Dummy29 = (temp & 0x20) == 0x20;
            Dummy30 = (temp & 0x40) == 0x40;
            Dummy31 = (temp & 0x80) == 0x80;

            // set up the levels
            byte numberOfLevels = 31;
            levels = new Level[numberOfLevels];
            for (byte i = 2; i < numberOfLevels; i++)
            {
                levels[i] = new Level(data, i, index);
            }

            startingCoins = Bits.GetShort(data, 0x3A00DB);
            startingCurrentFP = data[0x3A00DD];
            startingMaximumFP = data[0x3A00DE];
            startingFrogCoins = Bits.GetShort(data, 0x3A00DF);

            defenseStartLevel1 = data[0x02C9B3];
            defenseStartLevel2 = data[0x02C9B9];
            defenseEndLevel2 = data[0x02C9BF];
            defenseEndLevel1 = data[0x02C9C5];

            name = new char[10];
            for (int i = 0; i < name.Length; i++)
                name[i] = (char)data[(index * 10) + 0x3a134d + i];
        }
        public void Assemble()
        {
            int charStartOffset = (index * 20) + 0x3A002C;

            Bits.SetByte(data, charStartOffset, startingLevel); charStartOffset++;
            Bits.SetShort(data, charStartOffset, startingCurrentHP); charStartOffset += 2;
            Bits.SetShort(data, charStartOffset, startingMaxHP); charStartOffset += 2;
            Bits.SetByte(data, charStartOffset, startingSpeed); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingAttack); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingDefense); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingMgAttack); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingMgDefense); charStartOffset++;
            Bits.SetShort(data, charStartOffset, startingExperience); charStartOffset += 2;
            Bits.SetByte(data, charStartOffset, startingWeapon); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingArmor); charStartOffset++;
            Bits.SetByte(data, charStartOffset, startingAccessory); charStartOffset += 2;

            Bits.SetBit(data, charStartOffset, 0, Jump);
            Bits.SetBit(data, charStartOffset, 1, FireOrb);
            Bits.SetBit(data, charStartOffset, 2, SuperJump);
            Bits.SetBit(data, charStartOffset, 3, SuperFlame);
            Bits.SetBit(data, charStartOffset, 4, UltraJump);
            Bits.SetBit(data, charStartOffset, 5, UltraFlame);
            Bits.SetBit(data, charStartOffset, 6, Therapy);
            Bits.SetBit(data, charStartOffset, 7, GroupHug);
            charStartOffset++;

            Bits.SetBit(data, charStartOffset, 0, SleepyTime);
            Bits.SetBit(data, charStartOffset, 1, ComeBack);
            Bits.SetBit(data, charStartOffset, 2, Mute);
            Bits.SetBit(data, charStartOffset, 3, PsychBomb);
            Bits.SetBit(data, charStartOffset, 4, Terrorize);
            Bits.SetBit(data, charStartOffset, 5, PoisonGas);
            Bits.SetBit(data, charStartOffset, 6, Crusher);
            Bits.SetBit(data, charStartOffset, 7, BowserCrush);
            charStartOffset++;

            Bits.SetBit(data, charStartOffset, 0, GenoBeam);
            Bits.SetBit(data, charStartOffset, 1, GenoBoost);
            Bits.SetBit(data, charStartOffset, 2, GenoWhirl);
            Bits.SetBit(data, charStartOffset, 3, GenoBlast);
            Bits.SetBit(data, charStartOffset, 4, GenoFlash);
            Bits.SetBit(data, charStartOffset, 5, Thunderbolt);
            Bits.SetBit(data, charStartOffset, 6, HPRain);
            Bits.SetBit(data, charStartOffset, 7, Psychopath);
            charStartOffset++;

            Bits.SetBit(data, charStartOffset, 0, Shocker);
            Bits.SetBit(data, charStartOffset, 1, Snowy);
            Bits.SetBit(data, charStartOffset, 2, StarRain);
            Bits.SetBit(data, charStartOffset, 3, Dummy27);
            Bits.SetBit(data, charStartOffset, 4, Dummy28);
            Bits.SetBit(data, charStartOffset, 5, Dummy29);
            Bits.SetBit(data, charStartOffset, 6, Dummy30);
            Bits.SetBit(data, charStartOffset, 7, Dummy31);
            charStartOffset++;

            foreach (Level l in levels)
                if (l != null)
                    l.Assemble();

            if (index == 0)
            {
                Bits.SetShort(data, 0x3A00DB, startingCoins);
                Bits.SetByte(data, 0x3A00DD, startingCurrentFP);
                Bits.SetByte(data, 0x3A00DE, startingMaximumFP);
                Bits.SetShort(data, 0x3A00DF, startingFrogCoins);

                Bits.SetByte(data, 0x02C9B3, defenseStartLevel1);
                Bits.SetByte(data, 0x02C9B9, defenseStartLevel2);
                Bits.SetByte(data, 0x02C9BF, defenseEndLevel2);
                Bits.SetByte(data, 0x02C9C5, defenseEndLevel1);
            }

            Bits.SetCharArray(data, 0x3a134d + (index * 10), name);
        }
        [Serializable()]
        public class Level
        {
            [NonSerialized()]
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte index;
            public byte Index { get { return index; } }
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

            public Level(byte[] data, byte index, int characterOwner)
            {
                this.data = data;
                this.index = index;
                this.characterOwner = (byte)characterOwner;
                InitializeLevel();
            }
            private void InitializeLevel()
            {
                // Initialize all the stats for this level

                byte temp;

                int expNeededOffset = 0x3A1AFF + ((index - 2) * 2);

                expNeeded = Bits.GetShort(data, expNeededOffset);

                int charLevelStatOffset = (characterOwner * 3) + ((index - 2) * 15) + 0x3A1B39;

                hpPlus = data[charLevelStatOffset]; charLevelStatOffset++;
                temp = data[charLevelStatOffset]; attackPlus = (byte)((temp & 0xF0) >> 4);
                temp = data[charLevelStatOffset]; defensePlus = (byte)((temp & 0x0F)); charLevelStatOffset++;
                temp = data[charLevelStatOffset]; mgAttackPlus = (byte)((temp & 0xF0) >> 4);
                temp = data[charLevelStatOffset]; mgDefensePlus = (byte)((temp & 0x0F)); charLevelStatOffset++;

                int charLevelStatBonusOffset = (characterOwner * 3) + ((index - 2) * 15) + 0x3A1CEC;

                hpPlusBonus = data[charLevelStatBonusOffset]; charLevelStatBonusOffset++;
                temp = data[charLevelStatBonusOffset]; attackPlusBonus = (byte)((temp & 0xF0) >> 4);
                temp = data[charLevelStatBonusOffset]; defensePlusBonus = (byte)((temp & 0x0F)); charLevelStatBonusOffset++;
                temp = data[charLevelStatBonusOffset]; mgAttackPlusBonus = (byte)((temp & 0xF0) >> 4);
                temp = data[charLevelStatBonusOffset]; mgDefensePlusBonus = (byte)((temp & 0x0F)); charLevelStatBonusOffset++;

                spellLearned = data[characterOwner + ((index - 2) * 5) + 0x3A42F5];
                if (spellLearned > 0x1F)
                    spellLearned = 0x20;
            }
            public void Assemble()
            {
                int expNeededOffset = ((index - 2) * 2) + 0x3A1AFF;

                if (characterOwner == 0)
                    Bits.SetShort(data, expNeededOffset, expNeeded);

                int charLevelStatOffset = (characterOwner * 3) + ((index - 2) * 15) + 0x3A1B39;

                Bits.SetByte(data, charLevelStatOffset, hpPlus); charLevelStatOffset++;
                Bits.SetByte(data, charLevelStatOffset, (byte)((attackPlus << 4) + defensePlus)); charLevelStatOffset++;
                Bits.SetByte(data, charLevelStatOffset, (byte)((mgAttackPlus << 4) + mgDefensePlus)); charLevelStatOffset++;

                int charLevelStatBonusOffset = (characterOwner * 3) + ((index - 2) * 15) + 0x3A1CEC;

                Bits.SetByte(data, charLevelStatBonusOffset, hpPlusBonus); charLevelStatBonusOffset++;
                Bits.SetByte(data, charLevelStatBonusOffset, (byte)((attackPlusBonus << 4) + defensePlusBonus)); charLevelStatBonusOffset++;
                Bits.SetByte(data, charLevelStatBonusOffset, (byte)((mgAttackPlusBonus << 4) + mgDefensePlusBonus)); charLevelStatBonusOffset++;

                if (spellLearned == 0x20)
                    data[characterOwner + ((index - 2) * 5) + 0x3A42F5] = 0xFF;
                else
                    data[characterOwner + ((index - 2) * 5) + 0x3A42F5] = spellLearned;
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
                spellLearned = 32;
            }
        }
        public override string ToString()
        {
            return new string(name);
        }
        public override void Clear()
        {
            name = new char[10];
            startingLevel = 1;
            startingCurrentHP = 0;
            startingMaxHP = 0;
            startingSpeed = 0;
            startingAttack = 0;
            startingDefense = 0;
            startingMgAttack = 0;
            startingMgDefense = 0;
            startingExperience = 0;
            startingWeapon = 0;
            startingArmor = 0;
            startingAccessory = 0;
            jump = false;
            fireOrb = false;
            superJump = false;
            superFlame = false;
            ultraJump = false;
            ultraFlame = false;
            therapy = false;
            groupHug = false;
            sleepyTime = false;
            comeBack = false;
            mute = false;
            psychBomb = false;
            terrorize = false;
            poisonGas = false;
            crusher = false;
            bowserCrush = false;
            genoBeam = false;
            genoBoost = false;
            genoWhirl = false;
            genoBlast = false;
            genoFlash = false;
            thunderbolt = false;
            hpRain = false;
            psychopath = false;
            shocker = false;
            snowy = false;
            starRain = false;
            dummy27 = false;
            dummy28 = false;
            dummy29 = false;
            dummy30 = false;
            dummy31 = false;
            startingCoins = 0;
            startingCurrentFP = 0;
            startingMaximumFP = 0;
            startingFrogCoins = 0;
            foreach (Level levelUp in levels)
                if (levelUp != null)
                    levelUp.Clear();
        }
    }
}
