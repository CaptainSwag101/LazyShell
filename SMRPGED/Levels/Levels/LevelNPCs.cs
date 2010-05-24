using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace SMRPGED
{
    [Serializable()]
    public class LevelNPCs
    {
        // Local Variables
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        public int startingOffset; public int StartingOffset { get { return this.startingOffset; } }

        public ArrayList npcs = new ArrayList();
        private int currentNPC = 0;
        public int CurrentNPC
        {
            get
            {
                return this.currentNPC;
            }
            set
            {
                if (this.npcs.Count > value)
                {
                    npc = (NPC)npcs[value];
                    this.currentNPC = value;
                }
            }
        }
        private int selectedNPC; public int SelectedNPC { get { return this.selectedNPC; } set { selectedNPC = value; } }
        private NPC npc; public NPC Npc { get { return npc; } }

        private int levelNum; public int LevelNum { get { return levelNum; } set { levelNum = value; } }

        public int NumberOfNPCs { get { return npcs.Count; } }
        public void RemoveCurrentNPC()
        {
            if (currentNPC < npcs.Count)
            {
                npcs.Remove(npcs[currentNPC]);
                this.currentNPC = 0;
            }
        }
        public void Clear()
        {
            npcs.Clear();
            currentNPC = 0;
        }
        public void AddNewNPC(int index, Point p)
        {
            NPC e = new NPC();
            e.NullNPC();
            e.CoordX = (byte)p.X;
            e.CoordY = (byte)p.Y;
            e.CoordXBit7 = true;
            if (index < npcs.Count)
                npcs.Insert(index, e);
            else
                npcs.Add(e);
        }
        public void AddNewNPC(int index, NPC copy)
        {
            NPC e = new NPC();
            e.CopyOverNPC(copy);
            if (index < npcs.Count)
                npcs.Insert(index, e);
            else
                npcs.Add(e);
        }
        public void ReverseNPC(int index)
        {
            npcs.Reverse(index, 2);
        }

        public bool IsInstanceSelected { get { return npc.IsInstanceSelected; } set { npc.IsInstanceSelected = value; } }

        public int CurrentInstance { get { return npc.CurrentInstance; } set { npc.CurrentInstance = value; } }
        public int SelectedInstance { get { return npc.SelectedInstance; } set { npc.SelectedInstance = value; } }
        public int NumberOfInstances { get { return npc.NumberOfInstances; } }
        public void RemoveCurrentInstance()
        {
            npc.RemoveCurrentInstance();
        }
        public void AddNewInstance(int index, Point p)
        {
            npc.AddNewInstance(index, p);
        }
        public void AddNewInstance(int index, NPC.Instance e)
        {
            npc.AddNewInstance(index, e);
        }
        public void ReverseInstance(int index)
        {
            npc.ReverseInstance(index);
        }

        private byte mapHeader; public byte MapHeader { get { return mapHeader; } set { mapHeader = value; } }

        public byte InstanceAmount { get { return npc.InstanceAmount; } set { npc.InstanceAmount = value; } }
        public byte EngageType { get { return npc.EngageType; } set { npc.EngageType = value; } }

        public byte SpeedPlus { get { return npc.SpeedPlus; } set { npc.SpeedPlus = value; } }

        public bool B2b3 { get { return npc.B2b3; } set { npc.B2b3 = value; } } // face on trigger
        public bool B2b4 { get { return npc.B2b4; } set { npc.B2b4 = value; } }
        public bool B2b5 { get { return npc.B2b5; } set { npc.B2b5 = value; } }
        public bool B2b6 { get { return npc.B2b6; } set { npc.B2b6 = value; } } // set sequence
        public bool B2b7 { get { return npc.B2b7; } set { npc.B2b7 = value; } } // no floating

        public bool B3b0 { get { return npc.B3b0; } set { npc.B3b0 = value; } }
        public bool B3b1 { get { return npc.B3b1; } set { npc.B3b1 = value; } } // can't walk under
        public bool B3b2 { get { return npc.B3b2; } set { npc.B3b2 = value; } }
        public bool B3b3 { get { return npc.B3b3; } set { npc.B3b3 = value; } } // can't jump on
        public bool B3b4 { get { return npc.B3b4; } set { npc.B3b4 = value; } }
        public bool B3b5 { get { return npc.B3b5; } set { npc.B3b5 = value; } }
        public bool B3b6 { get { return npc.B3b6; } set { npc.B3b6 = value; } } // can't walk through
        public bool B3b7 { get { return npc.B3b7; } set { npc.B3b7 = value; } }

        public bool B4b0 { get { return npc.B4b0; } set { npc.B4b0 = value; } }
        public bool B4b1 { get { return npc.B4b1; } set { npc.B4b1 = value; } }

        public ushort NPCID { get { return npc.NPCID; } set { npc.NPCID = value; } }
        public ushort Movement { get { return npc.Movement; } set { npc.Movement = value; } }
        public ushort EventORpack { get { return npc.EventORpack; } set { npc.EventORpack = value; } }

        public bool B7b6 { get { return npc.B7b6; } set { npc.B7b6 = value; } }
        public bool B7b7 { get { return npc.B7b7; } set { npc.B7b7 = value; } }

        public byte EngageTrigger { get { return npc.EngageTrigger; } set { npc.EngageTrigger = value; } }

        public byte AfterBattle { get { return npc.AfterBattle; } set { npc.AfterBattle = value; } }

        public byte CoordX { get { return npc.CoordX; } set { npc.CoordX = value; } }
        public byte CoordY { get { return npc.CoordY; } set { npc.CoordY = value; } }
        public byte CoordZ { get { return npc.CoordZ; } set { npc.CoordZ = value; } }
        public byte RadialPosition { get { return npc.RadialPosition; } set { npc.RadialPosition = value; } }
        public byte PropertyA { get { return npc.PropertyA; } set { npc.PropertyA = value; } }
        public byte PropertyB { get { return npc.PropertyB; } set { npc.PropertyB = value; } }
        public byte PropertyC { get { return npc.PropertyC; } set { npc.PropertyC = value; } }
        public bool CoordXBit7 { get { return npc.CoordXBit7; } set { npc.CoordXBit7 = value; } }
        public bool CoordYBit7 { get { return npc.CoordYBit7; } set { npc.CoordYBit7 = value; } }

        public byte InstanceCoordX { get { return npc.InstanceCoordX; } set { npc.InstanceCoordX = value; } }
        public byte InstanceCoordY { get { return npc.InstanceCoordY; } set { npc.InstanceCoordY = value; } }
        public byte InstanceCoordZ { get { return npc.InstanceCoordZ; } set { npc.InstanceCoordZ = value; } }
        public byte InstanceRadialPosition { get { return npc.InstanceRadialPosition; } set { npc.InstanceRadialPosition = value; } }
        public byte InstancePropertyA { get { return npc.InstancePropertyA; } set { npc.InstancePropertyA = value; } }
        public byte InstancePropertyB { get { return npc.InstancePropertyB; } set { npc.InstancePropertyB = value; } }
        public byte InstancePropertyC { get { return npc.InstancePropertyC; } set { npc.InstancePropertyC = value; } }
        public bool InstanceCoordXBit7 { get { return npc.InstanceCoordXBit7; } set { npc.InstanceCoordXBit7 = value; } }
        public bool InstanceCoordYBit7 { get { return npc.InstanceCoordYBit7; } set { npc.InstanceCoordYBit7 = value; } }

        public LevelNPCs(byte[] data, int levelNum)
        {
            this.data = data;
            this.levelNum = levelNum;
            InitializeLevel(data);
        }

        // Dissasembler goes here
        // Initializes all local properties for this class
        private void InitializeLevel(byte[] data)
        {
            int offset;
            ushort offsetStart = 0;
            ushort offsetEnd = 0;
            NPC tNPC;

            int pointerOffset = (levelNum * 2) + 0x148000;

            offsetStart = BitManager.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = BitManager.GetShort(data, pointerOffset);

            if (levelNum == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no npc fields for level

            offset = offsetStart + 0x140000;
            startingOffset = offset;

            mapHeader = BitManager.GetByte(data, offset); offset++;

            while (offset < offsetEnd + 0x140000)
            {
                tNPC = new NPC();
                tNPC.InitializeNPC(data, offset);
                npcs.Add(tNPC);

                offset += 12;

                for (int i = 0; i < tNPC.InstanceAmount; i++)
                {
                    offset += 4;
                }
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (levelNum * 2) + 0x148000;

            BitManager.SetShort(data, pointerOffset, offsetStart);

            if (npcs.Count == 0) return offsetStart;

            offset = offsetStart + 0x140000;

            BitManager.SetByte(data, offset, mapHeader); offset++;

            for (int i = 0; i < npcs.Count; i++)
            {
                this.CurrentNPC = i;
                offset = npc.AssembleNPC(data, offset);
            }

            offsetStart = (ushort)(offset - 0x140000);

            return offsetStart;
        }

        [Serializable()]
        public class NPC
        {
            public ArrayList Instances = new ArrayList();
            private int currentInstance = 0;
            public int CurrentInstance
            {
                get
                {
                    return this.currentInstance;
                }
                set
                {
                    instance = (Instance)Instances[value];
                    this.currentInstance = value;
                }
            }

            private int selectedInstance; public int SelectedInstance { get { return this.selectedInstance; } set { selectedInstance = value; } }

            private Instance instance;
            public Instance INSTANCE;

            public int NumberOfInstances { get { return Instances.Count; } }
            public void RemoveCurrentInstance()
            {
                if (currentInstance < Instances.Count)
                {
                    Instances.Remove(Instances[currentInstance]);
                    this.currentInstance = 0;
                    instanceAmount--;
                }
            }
            public void AddNewInstance(int index, Point p)
            {
                Instance e = new Instance();
                e.NullInstance();
                e.CoordX = (byte)p.X;
                e.CoordY = (byte)p.Y;
                if (index < Instances.Count)
                    Instances.Insert(index, e);
                else
                    Instances.Add(e);
                instanceAmount++;
            }
            public void AddNewInstance(int index, Instance copy)
            {
                Instance e = new Instance();
                e.CopyOverInstance(copy);
                if (index < Instances.Count)
                    Instances.Insert(index, e);
                else
                    Instances.Add(e);
                instanceAmount++;
            }
            public void ReverseInstance(int index)
            {
                Instances.Reverse(index, 2);
            }

            private bool isInstanceSelected; public bool IsInstanceSelected { get { return isInstanceSelected; } set { isInstanceSelected = value; } }

            private byte instanceAmount; public byte InstanceAmount { get { return instanceAmount; } set { instanceAmount = value; } }
            private byte engageType; public byte EngageType { get { return engageType; } set { engageType = value; } }

            private byte speedPlus; public byte SpeedPlus { get { return speedPlus; } set { speedPlus = value; } }

            private bool b2b3; public bool B2b3 { get { return b2b3; } set { b2b3 = value; } }
            private bool b2b4; public bool B2b4 { get { return b2b4; } set { b2b4 = value; } }
            private bool b2b5; public bool B2b5 { get { return b2b5; } set { b2b5 = value; } }
            private bool b2b6; public bool B2b6 { get { return b2b6; } set { b2b6 = value; } }
            private bool b2b7; public bool B2b7 { get { return b2b7; } set { b2b7 = value; } }

            private bool b3b0; public bool B3b0 { get { return b3b0; } set { b3b0 = value; } }
            private bool b3b1; public bool B3b1 { get { return b3b1; } set { b3b1 = value; } }
            private bool b3b2; public bool B3b2 { get { return b3b2; } set { b3b2 = value; } }
            private bool b3b3; public bool B3b3 { get { return b3b3; } set { b3b3 = value; } }
            private bool b3b4; public bool B3b4 { get { return b3b4; } set { b3b4 = value; } }
            private bool b3b5; public bool B3b5 { get { return b3b5; } set { b3b5 = value; } }
            private bool b3b6; public bool B3b6 { get { return b3b6; } set { b3b6 = value; } }
            private bool b3b7; public bool B3b7 { get { return b3b7; } set { b3b7 = value; } }

            private bool b4b0; public bool B4b0 { get { return b4b0; } set { b4b0 = value; } }
            private bool b4b1; public bool B4b1 { get { return b4b1; } set { b4b1 = value; } }

            private ushort npcID; public ushort NPCID { get { return npcID; } set { npcID = value; } }
            private ushort movement; public ushort Movement { get { return movement; } set { movement = value; } }
            private ushort eventORpack; public ushort EventORpack { get { return eventORpack; } set { eventORpack = value; } }

            private bool b7b6; public bool B7b6 { get { return b7b6; } set { b7b6 = value; } }
            private bool b7b7; public bool B7b7 { get { return b7b7; } set { b7b7 = value; } }

            private byte engageTrigger; public byte EngageTrigger { get { return engageTrigger; } set { engageTrigger = value; } }

            private byte afterBattle; public byte AfterBattle { get { return afterBattle; } set { afterBattle = value; } }

            // for the root NPC
            private byte coordX; public byte CoordX { get { return coordX; } set { coordX = value; } }
            private byte coordY; public byte CoordY { get { return coordY; } set { coordY = value; } }
            private byte coordZ; public byte CoordZ { get { return coordZ; } set { coordZ = value; } }
            private byte radialPosition; public byte RadialPosition { get { return radialPosition; } set { radialPosition = value; } }
            private byte propertyA; public byte PropertyA { get { return propertyA; } set { propertyA = value; } }
            private byte propertyB; public byte PropertyB { get { return propertyB; } set { propertyB = value; } }
            private byte propertyC; public byte PropertyC { get { return propertyC; } set { propertyC = value; } }
            private bool coordXBit7; public bool CoordXBit7 { get { return coordXBit7; } set { coordXBit7 = value; } }
            private bool coordYBit7; public bool CoordYBit7 { get { return coordYBit7; } set { coordYBit7 = value; } }

            // for the child NPC instance
            public byte InstanceCoordX { get { return instance.CoordX; } set { instance.CoordX = value; } }
            public byte InstanceCoordY { get { return instance.CoordY; } set { instance.CoordY = value; } }
            public byte InstanceCoordZ { get { return instance.CoordZ; } set { instance.CoordZ = value; } }
            public byte InstanceRadialPosition { get { return instance.RadialPosition; } set { instance.RadialPosition = value; } }
            public byte InstancePropertyA { get { return instance.PropertyA; } set { instance.PropertyA = value; } }
            public byte InstancePropertyB { get { return instance.PropertyB; } set { instance.PropertyB = value; } }
            public byte InstancePropertyC { get { return instance.PropertyC; } set { instance.PropertyC = value; } }
            public bool InstanceCoordXBit7 { get { return instance.CoordXBit7; } set { instance.CoordXBit7 = value; } }
            public bool InstanceCoordYBit7 { get { return instance.CoordYBit7; } set { instance.CoordYBit7 = value; } }

            public void NullNPC()
            {
                instanceAmount = 0;
                engageType = 0;
                speedPlus = 0;
                b2b3 = false;
                b2b4 = false;
                b2b5 = false;
                b2b6 = true;
                b2b7 = false;
                b3b0 = false;
                b3b1 = false;
                b3b2 = false;
                b3b3 = false;
                b3b4 = false;
                b3b5 = false;
                b3b6 = true;
                b3b7 = false;
                b4b0 = false;
                b4b1 = false;
                npcID = 0;
                movement = 0;
                eventORpack = 0;
                engageTrigger = 0;
                b7b6 = true;
                b7b7 = true;
                afterBattle = 0;
                coordX = 0;
                coordY = 0;
                coordZ = 0;
                coordXBit7 = true;
                coordYBit7 = false;
                radialPosition = 0;
                propertyA = 0;
                propertyB = 0;
                propertyC = 0;
            }
            public void CopyOverNPC(NPC copy)
            {
                instanceAmount = copy.InstanceAmount;
                engageType = copy.EngageType;
                speedPlus = copy.SpeedPlus;
                b2b3 = copy.B2b3;
                b2b4 = copy.B2b4;
                b2b5 = copy.B2b5;
                b2b6 = copy.B2b6;
                b2b7 = copy.B2b7;
                b3b0 = copy.B3b0;
                b3b1 = copy.B3b1;
                b3b2 = copy.B3b2;
                b3b3 = copy.B3b3;
                b3b4 = copy.B3b4;
                b3b5 = copy.B3b5;
                b3b6 = copy.B3b6;
                b3b7 = copy.B3b7;
                b4b0 = copy.B4b0;
                b4b1 = copy.B4b1;
                npcID = copy.NPCID;
                movement = copy.Movement;
                eventORpack = copy.EventORpack;
                engageTrigger = copy.EngageTrigger;
                b7b6 = copy.B7b6;
                b7b7 = copy.B7b7;
                afterBattle = copy.AfterBattle;
                coordX = copy.CoordX;
                coordY = copy.CoordY;
                coordZ = copy.CoordZ;
                coordXBit7 = copy.CoordXBit7;
                coordYBit7 = copy.CoordYBit7;
                radialPosition = copy.RadialPosition;
                propertyA = copy.PropertyA;
                propertyB = copy.PropertyB;
                propertyC = copy.PropertyC;
                Instance tInstance;
                foreach (Instance i in copy.Instances)
                {
                    tInstance = new Instance();
                    tInstance.CopyOverInstance(i);
                    Instances.Add(tInstance);
                }
            }

            public void InitializeNPC(byte[] data, int offset)
            {
                byte temp = 0;
                ushort tempShort = 0;

                Instance tInstance;

                temp = BitManager.GetByte(data, offset); offset++;
                instanceAmount = (byte)(temp & 0x0F);
                engageType = (byte)((temp & 0x30) >> 4);
                temp = BitManager.GetByte(data, offset); offset++;
                speedPlus = (byte)(temp & 0x07);

                if ((temp & 0x08) == 0x08) b2b3 = true;
                if ((temp & 0x10) == 0x10) b2b4 = true;
                if ((temp & 0x20) == 0x20) b2b5 = true;
                if ((temp & 0x40) == 0x40) b2b6 = true;
                if ((temp & 0x80) == 0x80) b2b7 = true;

                temp = BitManager.GetByte(data, offset); offset++;

                if ((temp & 0x01) == 0x01) b3b0 = true;
                if ((temp & 0x02) == 0x02) b3b1 = true;
                if ((temp & 0x04) == 0x04) b3b2 = true;
                if ((temp & 0x08) == 0x08) b3b3 = true;
                if ((temp & 0x10) == 0x10) b3b4 = true;
                if ((temp & 0x20) == 0x20) b3b5 = true;
                if ((temp & 0x40) == 0x40) b3b6 = true;
                if ((temp & 0x80) == 0x80) b3b7 = true;

                b4b0 = (data[offset] & 0x01) == 0x01;
                b4b1 = (data[offset] & 0x02) == 0x02;

                tempShort = BitManager.GetShort(data, offset);
                npcID = (ushort)((tempShort & 0x0FFF) >> 2);
                offset++;

                tempShort = BitManager.GetShort(data, offset);
                movement = (ushort)((tempShort & 0x3FF0) >> 4);
                offset++;

                b7b6 = (data[offset] & 0x40) == 0x40;
                b7b7 = (data[offset] & 0x80) == 0x80;
                offset++;

                tempShort = BitManager.GetShort(data, offset);
                if (engageType == 2) eventORpack = (ushort)(tempShort & 0xFF);
                else eventORpack = (ushort)(tempShort & 0xFFF);
                offset++;

                temp = BitManager.GetByte(data, offset);

                if (engageType == 2)
                    afterBattle = (byte)((temp >> 1) & 0x07);

                engageTrigger = Math.Min((byte)((temp & 0xF0) >> 4), (byte)12); offset++;

                temp = BitManager.GetByte(data, offset); offset++;

                if (engageType == 0) propertyA = (byte)(temp & 0x07);       // npc id+
                else if (engageType == 1) propertyA = temp;  // 00:70A7
                else if (engageType == 2) propertyA = (byte)(temp & 0x0F);  // movement+

                if (engageType == 0) propertyB = (byte)((temp & 0xF0) >> 5);         // event id+
                else if (engageType == 2) propertyB = (byte)((temp & 0xF0) >> 4);    // pack+

                if (engageType == 0) propertyC = (byte)((temp & 0x18) >> 3);

                temp = BitManager.GetByte(data, offset); offset++;
                coordX = (byte)(temp & 0x7F);
                if ((temp & 0x80) == 0x80) coordXBit7 = true;
                temp = BitManager.GetByte(data, offset); offset++;
                coordY = (byte)(temp & 0x7F);
                if ((temp & 0x80) == 0x80) coordYBit7 = true;
                temp = BitManager.GetByte(data, offset); offset++;
                coordZ = (byte)(temp & 0x1F);
                radialPosition = (byte)((temp & 0xF0) >> 5);

                for (int i = 0; i < instanceAmount; i++)
                {
                    tInstance = new Instance();
                    tInstance.InitializeInstance(data, offset, engageType);
                    Instances.Add(tInstance);

                    offset += 4;
                }
            }
            public int AssembleNPC(byte[] data, int offset)
            {
                BitManager.SetByte(data, offset, instanceAmount);
                BitManager.SetBitsByByte(data, offset, (byte)(engageType << 4), true); offset++;

                BitManager.SetByte(data, offset, speedPlus);
                BitManager.SetBit(data, offset, 3, b2b3);
                BitManager.SetBit(data, offset, 4, b2b4);
                BitManager.SetBit(data, offset, 5, b2b5);
                BitManager.SetBit(data, offset, 6, b2b6);
                BitManager.SetBit(data, offset, 7, b2b7); offset++;

                BitManager.SetBit(data, offset, 0, b3b0);
                BitManager.SetBit(data, offset, 1, b3b1);
                BitManager.SetBit(data, offset, 2, b3b2);
                BitManager.SetBit(data, offset, 3, b3b3);
                BitManager.SetBit(data, offset, 4, b3b4);
                BitManager.SetBit(data, offset, 5, b3b5);
                BitManager.SetBit(data, offset, 6, b3b6);
                BitManager.SetBit(data, offset, 7, b3b7); offset++;

                BitManager.SetShort(data, offset, (ushort)(npcID << 2));
                BitManager.SetBit(data, offset, 0, b4b0);
                BitManager.SetBit(data, offset, 1, b4b1);
                offset++;

                BitManager.SetBitsByByte(data, offset, (byte)((movement << 4) & 0xF0), true); offset++; // lower 4 bits
                BitManager.SetByte(data, offset, (byte)(movement >> 4)); // lower 6 bits
                BitManager.SetBit(data, offset, 6, b7b6);
                BitManager.SetBit(data, offset, 7, b7b7);
                offset++;

                if (engageType == 2) BitManager.SetByte(data, offset, (byte)eventORpack); // if pack (1 byte)
                else BitManager.SetShort(data, offset, eventORpack);    //if event (1 short)
                offset++;

                data[offset] &= 0x0F;
                data[offset] |= (byte)(engageTrigger << 4);
                if (engageType == 2)
                {
                    data[offset] &= 0xF0;
                    data[offset] |= (byte)(afterBattle << 1);
                }

                offset++;

                BitManager.SetByte(data, offset, propertyA);
                if (engageType == 0)
                    BitManager.SetBitsByByte(data, offset, (byte)(propertyB << 5), true);
                else if (engageType == 2)
                    BitManager.SetBitsByByte(data, offset, (byte)(propertyB << 4), true);
                if (engageType == 0)
                    BitManager.SetBitsByByte(data, offset, (byte)(propertyC << 3), true);
                offset++;

                BitManager.SetByte(data, offset, coordX);
                BitManager.SetBit(data, offset, 7, coordXBit7); offset++;
                BitManager.SetByte(data, offset, coordY);
                BitManager.SetBit(data, offset, 7, coordYBit7); offset++;
                BitManager.SetByte(data, offset, coordZ);
                BitManager.SetBitsByByte(data, offset, (byte)(radialPosition << 5), true); offset++;

                for (int i = 0; i < instanceAmount; i++)
                {
                    this.CurrentInstance = i;
                    offset = instance.AssembleInstance(data, offset, engageType);
                }

                return offset;
            }

            [Serializable()]
            public class Instance
            {
                private byte coordX; public byte CoordX { get { return coordX; } set { coordX = value; } }
                private byte coordY; public byte CoordY { get { return coordY; } set { coordY = value; } }
                private byte coordZ; public byte CoordZ { get { return coordZ; } set { coordZ = value; } }
                private byte radialPosition; public byte RadialPosition { get { return radialPosition; } set { radialPosition = value; } }
                private byte propertyA; public byte PropertyA { get { return propertyA; } set { propertyA = value; } }
                private byte propertyB; public byte PropertyB { get { return propertyB; } set { propertyB = value; } }
                private byte propertyC; public byte PropertyC { get { return propertyC; } set { propertyC = value; } }
                private bool coordXBit7; public bool CoordXBit7 { get { return coordXBit7; } set { coordXBit7 = value; } }
                private bool coordYBit7; public bool CoordYBit7 { get { return coordYBit7; } set { coordYBit7 = value; } }

                public void NullInstance()
                {
                    coordX = 0;
                    coordY = 0;
                    coordZ = 0;
                    coordXBit7 = true;
                    coordYBit7 = false;
                    radialPosition = 0;
                    propertyA = 0;
                    propertyB = 0;
                    propertyC = 0;
                }
                public void CopyOverInstance(Instance copy)
                {
                    coordX = copy.CoordX;
                    coordY = copy.CoordY;
                    coordZ = copy.CoordZ;
                    coordXBit7 = copy.coordXBit7;
                    coordYBit7 = copy.coordYBit7;
                    radialPosition = copy.RadialPosition;
                    propertyA = copy.PropertyA;
                    propertyB = copy.PropertyB;
                    propertyC = copy.PropertyC;
                }

                public void InitializeInstance(byte[] data, int offset, int engageType)
                {
                    byte temp = 0;
                    temp = BitManager.GetByte(data, offset); offset++;

                    if (engageType == 0) propertyA = (byte)(temp & 0x07);       // npc id+
                    else if (engageType == 1) propertyA = temp;  // 00:70A7
                    else if (engageType == 2) propertyA = (byte)(temp & 0x0F);  // movement+

                    if (engageType == 0) propertyB = (byte)((temp & 0xF0) >> 5);         // event id+
                    else if (engageType == 2) propertyB = (byte)((temp & 0xF0) >> 4);    // pack+

                    if (engageType == 0) propertyC = (byte)((temp & 0x18) >> 3); // movement+

                    temp = BitManager.GetByte(data, offset); offset++;
                    coordX = (byte)(temp & 0x7F);
                    if ((temp & 0x80) == 0x80) coordXBit7 = true;
                    temp = BitManager.GetByte(data, offset); offset++;
                    coordY = (byte)(temp & 0x7F);
                    if ((temp & 0x80) == 0x80) coordYBit7 = true;
                    temp = BitManager.GetByte(data, offset); offset++;
                    coordZ = (byte)(temp & 0x1F);
                    radialPosition = (byte)((temp & 0xF0) >> 5);
                }
                public int AssembleInstance(byte[] data, int offset, int engageType)
                {
                    BitManager.SetByte(data, offset, propertyA);
                    if (engageType == 0)
                        BitManager.SetBitsByByte(data, offset, (byte)(propertyB << 5), true);
                    else if (engageType == 2)
                        BitManager.SetBitsByByte(data, offset, (byte)(propertyB << 4), true);
                    if (engageType == 0)
                        BitManager.SetBitsByByte(data, offset, (byte)(propertyC << 3), true);
                    offset++;

                    BitManager.SetByte(data, offset, coordX);
                    BitManager.SetBit(data, offset, 7, coordXBit7); offset++;
                    BitManager.SetByte(data, offset, coordY);
                    BitManager.SetBit(data, offset, 7, coordYBit7); offset++;
                    BitManager.SetByte(data, offset, coordZ);
                    BitManager.SetBitsByByte(data, offset, (byte)(radialPosition << 5), true); offset++;

                    return offset;
                }
            }
        }
    }
}
