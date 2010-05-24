using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.StatsEditor.Stats
{
    public class Timing
    {
        private byte[] data;
        public byte[] Data
        {
            get { return this.data; }
            set
            {
                this.data = value;
                foreach (WTiming x in wTimings)
                    x.Data = value;
                foreach (LevelOneSpellTiming x in levelOneSpellTimings)
                    x.Data = value;
                foreach (LevelTwoSpellTiming x in levelTwoSpellTimings)
                    x.Data = value;
                foreach (FireballSpellTiming x in fireballSpellTimings)
                    x.Data = value;
                foreach (RotationSpellTiming x in rotationSpellTimings)
                    x.Data = value;
                multipleTiming.Data = value;
            }

        }

        #region Timing stats and accessors
        private WTiming[] wTimings;
        private LevelOneSpellTiming[] levelOneSpellTimings;
        private LevelTwoSpellTiming[] levelTwoSpellTimings;
        private FireballSpellTiming[] fireballSpellTimings;
        private RotationSpellTiming[] rotationSpellTimings;
        private MultipleTiming multipleTiming;

        private byte currentWeapon = 0; public byte CurrentWeapon { get { return this.currentWeapon; } set { this.currentWeapon = value; } }
        private byte currentLevelOneSpellTiming = 0; public byte CurrentLevelOneSpellTiming { get { return this.currentLevelOneSpellTiming; } set { this.currentLevelOneSpellTiming = value; } }
        private byte currentLevelTwoSpellTiming = 0; public byte CurrentLevelTwoSpellTiming { get { return this.currentLevelTwoSpellTiming; } set { this.currentLevelTwoSpellTiming = value; } }
        private byte currentFireballSpellTiming = 0; public byte CurrentFireballSpellTiming { get { return this.currentFireballSpellTiming; } set { this.currentFireballSpellTiming = value; } }
        private byte currentRotationSpellTiming = 0; public byte CurrentRotationSpellTiming { get { return this.currentRotationSpellTiming; } set { this.currentRotationSpellTiming = value; } }

        private byte defenseStartLevel1; public byte DefenseStartLevel1 { get { return this.defenseStartLevel1; } set { this.defenseStartLevel1 = value; } }
        private byte defenseStartLevel2; public byte DefenseStartLevel2 { get { return this.defenseStartLevel2; } set { this.defenseStartLevel2 = value; } }
        private byte defenseEndLevel2; public byte DefenseEndLevel2 { get { return this.defenseEndLevel2; } set { this.defenseEndLevel2 = value; } }
        private byte defenseEndLevel1; public byte DefenseEndLevel1 { get { return this.defenseEndLevel1; } set { this.defenseEndLevel1 = value; } }
        private byte chargeSpellStartLevel2; public byte ChargeSpellStartLevel2 { get { return this.chargeSpellStartLevel2; } set { this.chargeSpellStartLevel2 = value; } }
        private byte chargeSpellStartLevel3; public byte ChargeSpellStartLevel3 { get { return this.chargeSpellStartLevel3; } set { this.chargeSpellStartLevel3 = value; } }
        private byte chargeSpellStartLevel4; public byte ChargeSpellStartLevel4 { get { return this.chargeSpellStartLevel4; } set { this.chargeSpellStartLevel4 = value; } }
        private byte chargeSpellOverflow; public byte ChargeSpellOverflow { get { return this.chargeSpellOverflow; } set { this.chargeSpellOverflow = value; } }
        private byte rapidSpellMax; public byte RapidSpellMax { get { return this.rapidSpellMax; } set { this.rapidSpellMax = value; } }

        public byte WeaponNum { get { return wTimings[currentWeapon].WeaponNum; } set { wTimings[currentWeapon].WeaponNum = value; } }
        public byte WeaponStartLevel1
        {
            get
            {
                return wTimings[currentWeapon].WeaponStartLevel1;
            }
            set
            {
                wTimings[currentWeapon].WeaponStartLevel1 = value;
            }
        }
        public byte WeaponStartLevel2
        {
            get
            {
                return wTimings[currentWeapon].WeaponStartLevel2;
            }
            set
            {
                wTimings[currentWeapon].WeaponStartLevel2 = value;
            }
        }
        public byte WeaponEndLevel1 { get { return wTimings[currentWeapon].WeaponEndLevel1; } set { wTimings[currentWeapon].WeaponEndLevel1 = value; } }
        public byte WeaponEndLevel2 { get { return wTimings[currentWeapon].WeaponEndLevel2; } set { wTimings[currentWeapon].WeaponEndLevel2 = value; } }

        public byte OneLevelSpellNum { get { return this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellNum; } set { this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellNum = value; } }
        public byte OneLevelSpellStart { get { return this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellStart; } set { this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellStart = value; } }
        public byte OneLevelSpellSpan { get { return this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellSpan; } set { this.levelOneSpellTimings[currentLevelOneSpellTiming].OneLevelSpellSpan = value; } }

        public byte TwoLevelSpellNum { get { return levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellNum; } set { levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellNum = value; } }
        public byte TwoLevelSpellStartLevel1 { get { return levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellStartLevel1; } set { levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellStartLevel1 = value; } }
        public byte TwoLevelSpellStartLevel2 { get { return levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellStartLevel2; } set { levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellStartLevel2 = value; } }
        public byte TwoLevelSpellEndLevel2 { get { return levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellEndLevel2; } set { levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellEndLevel2 = value; } }
        public byte TwoLevelSpellEndLevel1 { get { return levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellEndLevel1; } set { levelTwoSpellTimings[currentLevelTwoSpellTiming].TwoLevelSpellEndLevel1 = value; } }

        public byte CurrentFireball { get { return this.currentFireballSpellTiming; } set { this.currentFireballSpellTiming = value; } }
        public byte FireballSpellNum { get { return fireballSpellTimings[currentFireballSpellTiming].FireballSpellNum; } set { fireballSpellTimings[currentFireballSpellTiming].FireballSpellNum = value; } }
        public byte FireballSpellRange { get { return fireballSpellTimings[currentFireballSpellTiming].FireballSpellRange; } set { fireballSpellTimings[currentFireballSpellTiming].FireballSpellRange = value; } }
        public byte FireballSpellOrbs { get { return fireballSpellTimings[currentFireballSpellTiming].FireballSpellOrbs; } set { fireballSpellTimings[currentFireballSpellTiming].FireballSpellOrbs = value; } }

        public byte CurrentRotationSpell { get { return this.currentRotationSpellTiming; } set { this.currentRotationSpellTiming = value; } }
        public byte RotationSpellNum { get { return rotationSpellTimings[currentRotationSpellTiming].RotationSpellNum; } set { rotationSpellTimings[currentRotationSpellTiming].RotationSpellNum = value; } }
        public byte RotationSpellStart { get { return rotationSpellTimings[currentRotationSpellTiming].RotationSpellStart; } set { rotationSpellTimings[currentRotationSpellTiming].RotationSpellStart = value; } }
        public byte RotationSpellMax { get { return rotationSpellTimings[currentRotationSpellTiming].RotationSpellMax; } set { rotationSpellTimings[currentRotationSpellTiming].RotationSpellMax = value; } }

        public byte MultipleSpellNum { get { return multipleTiming.MultipleSpellNum; } set { multipleTiming.MultipleSpellNum = value; } }
        public byte NumberOfMultipleInstances { get { return multipleTiming.NumberOfMultipleInstances; } set { multipleTiming.NumberOfMultipleInstances = value; } }
        public byte TimeFrameStart { get { return multipleTiming.TimeFrameStart; } set { multipleTiming.TimeFrameStart = value; } }
        public byte SaveIndex { get { return multipleTiming.SaveIndex; } set { multipleTiming.SaveIndex = value; } }
        #endregion

        public Timing(byte[] data)
        {
            this.data = data;
            InitializeTiming(data);
        }
        private void InitializeTiming(byte[] data)
        {
            //Create weapon timings
            wTimings = new WTiming[37];
            for (byte i = 0; i < wTimings.Length; i++)
            {
                wTimings[i] = new WTiming(data, i);
            }
            // Get Universal Defense timing
            defenseStartLevel1 = BitManager.GetByte(data, 0x02C9B3);
            defenseStartLevel2 = BitManager.GetByte(data, 0x02C9B9);
            defenseEndLevel2 = BitManager.GetByte(data, 0x02C9BF);
            defenseEndLevel1 = BitManager.GetByte(data, 0x02C9C5);

            levelOneSpellTimings = new LevelOneSpellTiming[5];
            for (byte i = 0; i < levelOneSpellTimings.Length; i++)
            {
                levelOneSpellTimings[i] = new LevelOneSpellTiming(data, i);
            }

            levelTwoSpellTimings = new LevelTwoSpellTiming[5];
            for (byte i = 0; i < levelTwoSpellTimings.Length; i++)
            {
                levelTwoSpellTimings[i] = new LevelTwoSpellTiming(data, i);
            }

            chargeSpellStartLevel2 = BitManager.GetByte(data, 0x35B58D);
            chargeSpellStartLevel3 = BitManager.GetByte(data, 0x35B58E);
            chargeSpellStartLevel4 = BitManager.GetByte(data, 0x35B58F);
            chargeSpellOverflow = BitManager.GetByte(data, 0x35B590);

            this.fireballSpellTimings = new FireballSpellTiming[3];
            for (byte i = 0; i < fireballSpellTimings.Length; i++)
            {
                fireballSpellTimings[i] = new FireballSpellTiming(data, i);
            }

            this.rotationSpellTimings = new RotationSpellTiming[5];
            for (byte i = 0; i < rotationSpellTimings.Length; i++)
            {
                rotationSpellTimings[i] = new RotationSpellTiming(data, i);
            }

            this.multipleTiming = new MultipleTiming(data);

            rapidSpellMax = BitManager.GetByte(data, 0x35AA15);

        }
        public void Assemble()
        {
            foreach (WTiming w in wTimings)
                w.Assemble(); // Save Weapon timings

            // Save Universal Defense timing
            BitManager.SetByte(data, 0x02C9B3, defenseStartLevel1);
            BitManager.SetByte(data, 0x02C9B9, defenseStartLevel2);
            BitManager.SetByte(data, 0x02C9BF, defenseEndLevel2);
            BitManager.SetByte(data, 0x02C9C5, defenseEndLevel1);

            foreach (LevelOneSpellTiming l in levelOneSpellTimings)
                l.Assemble();
            foreach (LevelTwoSpellTiming l in levelTwoSpellTimings)
                l.Assemble();

            BitManager.SetByte(data, 0x35B58D, chargeSpellStartLevel2);
            BitManager.SetByte(data, 0x35B58E, chargeSpellStartLevel3);
            BitManager.SetByte(data, 0x35B58F, chargeSpellStartLevel4);
            BitManager.SetByte(data, 0x35B590, chargeSpellOverflow);

            foreach (FireballSpellTiming f in fireballSpellTimings)
                f.Assemble();

            foreach (RotationSpellTiming r in rotationSpellTimings)
                r.Assemble();

            this.multipleTiming.Assemble();

            BitManager.SetByte(data, 0x35AA15, rapidSpellMax);
        }
        public void Clear()
        {
            foreach (WTiming w in wTimings)
                w.Clear();

            defenseStartLevel1 = 0;
            defenseStartLevel2 = 0;
            defenseEndLevel2 = 0;
            defenseEndLevel1 = 0;

            foreach (LevelOneSpellTiming lo in levelOneSpellTimings)
                lo.Clear();
            foreach (LevelTwoSpellTiming lt in levelTwoSpellTimings)
                lt.Clear();

            chargeSpellStartLevel2 = 0;
            chargeSpellStartLevel3 = 0;
            chargeSpellStartLevel4 = 0;
            chargeSpellOverflow = 0;

            foreach (FireballSpellTiming f in fireballSpellTimings)
                f.Clear();
            foreach (RotationSpellTiming r in rotationSpellTimings)
                r.Clear();

            this.multipleTiming.Clear();

            rapidSpellMax = 0;
        }

        #region Inner Classes
        class WTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte weaponNum; public byte WeaponNum { get { return this.weaponNum; } set { this.weaponNum = value; } }

            private byte weaponStartLevel1; public byte WeaponStartLevel1 { get { return this.weaponStartLevel1; } set { this.weaponStartLevel1 = value; } }
            private byte weaponStartLevel2; public byte WeaponStartLevel2 { get { return this.weaponStartLevel2; } set { this.weaponStartLevel2 = value; } }
            private byte weaponEndLevel2; public byte WeaponEndLevel2 { get { return this.weaponEndLevel2; } set { this.weaponEndLevel2 = value; } }
            private byte weaponEndLevel1; public byte WeaponEndLevel1 { get { return this.weaponEndLevel1; } set { this.weaponEndLevel1 = value; } }

            public WTiming(byte[] data, byte weaponNum)
            {
                this.data = data;
                this.weaponNum = weaponNum;
                InitializeWTiming();
            }

            private void InitializeWTiming()
            {
                int offset = (weaponNum * 4) + 0x3A438A;

                weaponStartLevel1 = BitManager.GetByte(data, offset); offset++;
                weaponStartLevel2 = BitManager.GetByte(data, offset); offset++;
                weaponEndLevel2 = BitManager.GetByte(data, offset); offset++;
                weaponEndLevel1 = BitManager.GetByte(data, offset); offset++;
            }
            public void Assemble()
            {
                int offset = (weaponNum * 4) + 0x3A438A;

                BitManager.SetByte(data, offset, weaponStartLevel1); offset++;
                BitManager.SetByte(data, offset, weaponStartLevel2); offset++;
                BitManager.SetByte(data, offset, weaponEndLevel2); offset++;
                BitManager.SetByte(data, offset, weaponEndLevel1); offset++;

            }
            public void Clear()
            {
                weaponStartLevel1 = 0;
                weaponStartLevel2 = 0;
                weaponEndLevel2 = 0;
                weaponEndLevel1 = 0;
            }

        }
        class LevelOneSpellTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte oneLevelSpellNum; public byte OneLevelSpellNum { get { return this.oneLevelSpellNum; } set { this.oneLevelSpellNum = value; } }
            private byte oneLevelSpellStart; public byte OneLevelSpellStart { get { return this.oneLevelSpellStart; } set { this.oneLevelSpellStart = value; } }
            private byte oneLevelSpellSpan; public byte OneLevelSpellSpan { get { return this.oneLevelSpellSpan; } set { this.oneLevelSpellSpan = value; } }

            public LevelOneSpellTiming(byte[] data, byte oneLevelSpellNum)
            {
                this.data = data;
                this.oneLevelSpellNum = oneLevelSpellNum;
                InitializeSpell();
            }

            private void InitializeSpell()
            {
                int offset = 0;

                if (oneLevelSpellNum == 0) offset = 0x35A663;       // Come Back
                else if (oneLevelSpellNum == 1) offset = 0x35B9DB;  // Geno Boost
                else if (oneLevelSpellNum == 2) offset = 0x35BAE2;  // Geno Whirl
                else if (oneLevelSpellNum == 3) offset = 0x35BEDA;  // Thunderbolt
                else if (oneLevelSpellNum == 4) offset = 0x35C15E;  // Psychopath

                oneLevelSpellStart = BitManager.GetByte(data, offset); offset += 2;
                oneLevelSpellSpan = BitManager.GetByte(data, offset); offset += 2;
            }
            public void Assemble()
            {
                int offset = 0;

                if (oneLevelSpellNum == 0) offset = 0x35A663;       // Come Back
                else if (oneLevelSpellNum == 1) offset = 0x35B9DB;  // Geno Boost
                else if (oneLevelSpellNum == 2) offset = 0x35BAE2;  // Geno Whirl
                else if (oneLevelSpellNum == 3) offset = 0x35BEDA;  // Thunderbolt
                else if (oneLevelSpellNum == 4) offset = 0x35C15E;  // Psychopath

                BitManager.SetByte(data, offset, oneLevelSpellSpan); offset += 2;
                BitManager.SetByte(data, offset, oneLevelSpellSpan); offset += 2;

            }
            public void Clear()
            {
                oneLevelSpellNum = 0;
                oneLevelSpellStart = 0;
                oneLevelSpellSpan = 0;
            }

        }
        class LevelTwoSpellTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte twoLevelSpellNum; public byte TwoLevelSpellNum { get { return this.twoLevelSpellNum; } set { this.twoLevelSpellNum = value; } }
            private byte twoLevelSpellStartLevel1; public byte TwoLevelSpellStartLevel1 { get { return this.twoLevelSpellStartLevel1; } set { this.twoLevelSpellStartLevel1 = value; } }
            private byte twoLevelSpellStartLevel2; public byte TwoLevelSpellStartLevel2 { get { return this.twoLevelSpellStartLevel2; } set { this.twoLevelSpellStartLevel2 = value; } }
            private byte twoLevelSpellEndLevel2; public byte TwoLevelSpellEndLevel2 { get { return this.twoLevelSpellEndLevel2; } set { this.twoLevelSpellEndLevel2 = value; } }
            private byte twoLevelSpellEndLevel1; public byte TwoLevelSpellEndLevel1 { get { return this.twoLevelSpellEndLevel1; } set { this.twoLevelSpellEndLevel1 = value; } }

            public LevelTwoSpellTiming(byte[] data, byte twoLevelSpellNum)
            {
                this.data = data;
                this.twoLevelSpellNum = twoLevelSpellNum;
                InitializeSpell();
            }

            private void InitializeSpell()
            {
                int offset = 0;

                if (twoLevelSpellNum == 0) offset = 0x359305;       // Jump
                else if (twoLevelSpellNum == 1) offset = 0x359E47;  // Therapy / Group Hug
                else if (twoLevelSpellNum == 2) offset = 0x35B09A;  // Crusher
                else if (twoLevelSpellNum == 3) offset = 0x35BFC6;  // HP Rain
                else if (twoLevelSpellNum == 4) offset = 0x35C2CA;  // Shocker

                twoLevelSpellStartLevel1 = BitManager.GetByte(data, offset); offset += 2;
                twoLevelSpellStartLevel2 = BitManager.GetByte(data, offset); offset++;
                twoLevelSpellEndLevel2 = BitManager.GetByte(data, offset); offset++;
                twoLevelSpellEndLevel1 = BitManager.GetByte(data, offset); offset++;
            }
            public void Assemble()
            {
                int offset = 0;

                if (twoLevelSpellNum == 0) offset = 0x359305;       // Jump
                else if (twoLevelSpellNum == 1) offset = 0x359E47;  // Therapy / Group Hug
                else if (twoLevelSpellNum == 2) offset = 0x35B09A;  // Crusher
                else if (twoLevelSpellNum == 3) offset = 0x35BFC6;  // HP Rain
                else if (twoLevelSpellNum == 4) offset = 0x35C2CA;  // Shocker

                BitManager.SetByte(data, offset, twoLevelSpellEndLevel1); offset += 2;
                BitManager.SetByte(data, offset, twoLevelSpellStartLevel2); offset++;
                BitManager.SetByte(data, offset, twoLevelSpellEndLevel2); offset++;
                BitManager.SetByte(data, offset, twoLevelSpellEndLevel1); offset++;
            }
            public void Clear()
            {
                twoLevelSpellNum = 0;
                twoLevelSpellStartLevel1 = 0;
                twoLevelSpellStartLevel2 = 0;
                twoLevelSpellEndLevel2 = 0;
                twoLevelSpellEndLevel1 = 0;
            }

        }
        class FireballSpellTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte fireballSpellNum; public byte FireballSpellNum { get { return this.fireballSpellNum; } set { this.fireballSpellNum = value; } }
            private byte fireballSpellRange; public byte FireballSpellRange { get { return this.fireballSpellRange; } set { this.fireballSpellRange = value; } }
            private byte fireballSpellOrbs; public byte FireballSpellOrbs { get { return this.fireballSpellOrbs; } set { this.fireballSpellOrbs = value; } }

            public FireballSpellTiming(byte[] data, byte fireballSpellNum)
            {
                this.data = data;
                this.fireballSpellNum = fireballSpellNum;
                InitializeSpell();
            }

            private void InitializeSpell()
            {
                int offset = 0;

                if (fireballSpellNum == 0) offset = 0x359484;       // Fire Orb
                else if (fireballSpellNum == 1) offset = 0x3598D8;  // Super Flame
                else if (fireballSpellNum == 2) offset = 0x359CF4;  // Ultra Flame

                fireballSpellRange = BitManager.GetByte(data, offset); offset += 13;
                fireballSpellOrbs = BitManager.GetByte(data, offset);
            }
            public void Assemble()
            {
                int offset = 0;

                if (fireballSpellNum == 0) offset = 0x359484;       // Fire Orb
                else if (fireballSpellNum == 1) offset = 0x3598D8;  // Super Flame
                else if (fireballSpellNum == 2) offset = 0x359CF4;  // Ultra Flame

                BitManager.SetByte(data, offset, fireballSpellRange); offset += 13;
                BitManager.SetByte(data, offset, fireballSpellOrbs);
            }
            public void Clear()
            {
                fireballSpellNum = 0;
                fireballSpellRange = 0;
                fireballSpellOrbs = 0;
            }

        }
        class RotationSpellTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
            private byte rotationSpellNum; public byte RotationSpellNum { get { return this.rotationSpellNum; } set { this.rotationSpellNum = value; } }
            private byte rotationSpellStart; public byte RotationSpellStart { get { return this.rotationSpellStart; } set { this.rotationSpellStart = value; } }
            private byte rotationSpellMax; public byte RotationSpellMax { get { return this.rotationSpellMax; } set { this.rotationSpellMax = value; } }

            public RotationSpellTiming(byte[] data, byte rotationSpellNum)
            {
                this.data = data;
                this.rotationSpellNum = rotationSpellNum;
                InitializeSpell();
            }

            private void InitializeSpell()
            {
                int offset = 0;

                if (rotationSpellNum == 0) offset = 0x35A423;       // Sleepy Time
                else if (rotationSpellNum == 1) offset = 0x35A86F;  // Mute
                else if (rotationSpellNum == 1) offset = 0x35ACAF;  // Terrorize
                else if (rotationSpellNum == 1) offset = 0x35AE3A;  // Poison Gas
                else if (rotationSpellNum == 1) offset = 0x35C347;  // Snowy

                rotationSpellStart = BitManager.GetByte(data, offset); offset += 2;
                rotationSpellMax = BitManager.GetByte(data, offset);
            }
            public void Assemble()
            {
                int offset = 0;

                if (rotationSpellNum == 0) offset = 0x35A423;       // Sleepy Time
                else if (rotationSpellNum == 1) offset = 0x35A86F;  // Mute
                else if (rotationSpellNum == 1) offset = 0x35ACAF;  // Terrorize
                else if (rotationSpellNum == 1) offset = 0x35AE3A;  // Poison Gas
                else if (rotationSpellNum == 1) offset = 0x35C347;  // Snowy

                BitManager.SetByte(data, offset, rotationSpellStart); offset += 2;
                BitManager.SetByte(data, offset, rotationSpellMax);
            }
            public void Clear()
            {
                rotationSpellNum = 0;
                rotationSpellStart = 0;
                rotationSpellMax = 0;
            }

        }
        class MultipleTiming
        {
            private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

            private byte multipleSpellNum = 0; public byte MultipleSpellNum { get { return this.multipleSpellNum; } set { this.multipleSpellNum = value; } }
            private byte[] multipleSpellInstanceMax;
            private byte[,] multipleSpellInstanceRange;
            private byte[] saveIndex = new byte[3];

            public byte NumberOfMultipleInstances { get { return this.multipleSpellInstanceMax[multipleSpellNum]; } set { this.multipleSpellInstanceMax[multipleSpellNum] = value; } }
            public byte TimeFrameStart
            {
                get
                {
                    return this.multipleSpellInstanceRange[multipleSpellNum, this.saveIndex[multipleSpellNum]];
                }
                set
                {
                    this.multipleSpellInstanceRange[multipleSpellNum, saveIndex[multipleSpellNum]] = value;
                }
            }
            public byte SaveIndex
            {
                get
                {
                    return this.saveIndex[multipleSpellNum];
                }
                set
                {
                    this.saveIndex[multipleSpellNum] = value;
                }
            }

            public MultipleTiming(byte[] data)
            {
                this.data = data;
                InitializeSpell();
            }

            private void InitializeSpell()
            {
                saveIndex[0] = 0;
                saveIndex[1] = 0;
                saveIndex[2] = 0;

                // Super Jump
                multipleSpellInstanceMax = new byte[3]; // 0 = Super Jump, 1 = Ultra Jump, 2 = Star Rain
                multipleSpellInstanceRange = new byte[3, 17];

                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0: multipleSpellInstanceRange[0, i] = BitManager.GetByte(data, 0x35969D); break;
                        case 13: multipleSpellInstanceRange[0, i] = BitManager.GetByte(data, 0x359768); break;
                        default:
                            int offset = ((i - 1) * 11) + 0x3596DE;
                            multipleSpellInstanceRange[0, i] = BitManager.GetByte(data, offset);
                            break;
                    }

                }
                multipleSpellInstanceMax[0] = BitManager.GetByte(data, 0x359763);

                // Ultra Jump

                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0: multipleSpellInstanceRange[1, i] = BitManager.GetByte(data, 0x359AA6); break;
                        case 16: multipleSpellInstanceRange[1, i] = BitManager.GetByte(data, 0x359B83); break;
                        default:
                            int offset = ((i - 1) * 11) + 0x359AD7;
                            multipleSpellInstanceRange[1, i] = BitManager.GetByte(data, offset);
                            break;
                    }
                }
                multipleSpellInstanceMax[1] = BitManager.GetByte(data, 0x359B7E);


                // Star Rain
                multipleSpellInstanceRange[2, 0] = BitManager.GetByte(data, 0x35C3C5);
                multipleSpellInstanceMax[2] = BitManager.GetByte(data, 0x35C407);


            }
            public void Assemble()
            {
                for (int i = 0; i < 14; i++)
                {
                    switch (i)
                    {
                        case 0:
                            BitManager.SetByte(data, 0x35969D, multipleSpellInstanceRange[0, i]);
                            BitManager.SetByte(data, 0x35969F, multipleSpellInstanceRange[0, i]);
                            break;
                        case 13: 
                            BitManager.SetByte(data, 0x359768, multipleSpellInstanceRange[0, i]);
                            BitManager.SetByte(data, 0x35976A, multipleSpellInstanceRange[0, i]);
                            break;
                        default:
                            int offset = ((i - 1) * 11) + 0x3596DE;
                            BitManager.SetByte(data, offset, multipleSpellInstanceRange[0, i]);
                            BitManager.SetByte(data, offset + 2, multipleSpellInstanceRange[0, i]);
                            break;
                    }
                }
                BitManager.SetByte(data, 0x359763, multipleSpellInstanceMax[0]);

                // Ultra Jump

                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            BitManager.SetByte(data, 0x359AA6, multipleSpellInstanceRange[1, i]);
                            BitManager.SetByte(data, 0x359AA8, multipleSpellInstanceRange[1, i]); break;
                        case 16:
                            BitManager.SetByte(data, 0x359B83, multipleSpellInstanceRange[1, i]);
                            BitManager.SetByte(data, 0x359B85, multipleSpellInstanceRange[1, i]); break;
                        default:
                            int offset = ((i - 1) * 11) + 0x359AD7;
                            BitManager.SetByte(data, offset, multipleSpellInstanceRange[1, i]);
                            BitManager.SetByte(data, offset + 2, multipleSpellInstanceRange[1, i]);
                            break;
                    }
                }
                BitManager.SetByte(data, 0x359B7E, multipleSpellInstanceMax[1]);

                // Star Rain
                BitManager.SetByte(data, 0x35C3C5, multipleSpellInstanceRange[2, 0]);
                BitManager.SetByte(data, 0x35C3C7, multipleSpellInstanceRange[2, 0]);
                BitManager.SetByte(data, 0x35C407, multipleSpellInstanceMax[2]);
            }

            public void Clear()
            {
                for (int i = 0; i < 17; i++)
                {
                    if (i < 14) multipleSpellInstanceRange[0, i] = 0;
                    multipleSpellInstanceRange[1, i] = 0;
                }
                multipleSpellInstanceRange[2, 0] = 0;

                multipleSpellInstanceMax[0] = 0;
                multipleSpellInstanceMax[1] = 0;
                multipleSpellInstanceMax[2] = 0;
            }

        }
        #endregion
    }
}
