using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace LazyShell.Areas
{
    [Serializable()]
    public class NPCObjectCollection : IList<NPCObject>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public int AreaIndex { get; set; }

        // Collection
        public List<NPCObject> NPCObjects { get; set; }

        // Properties
        public byte Partition { get; set; }

        #endregion

        // Constructor
        public NPCObjectCollection(int index)
        {
            this.AreaIndex = index;
            this.NPCObjects = new List<NPCObject>();
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int pointerOffset = (AreaIndex * 2) + 0x148000;
            int offsetStart = Bits.GetShort(rom, pointerOffset);
            int offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (AreaIndex == 0x1FF)
                offsetEnd = 0;
            // no npc fields for area
            if (offsetStart >= offsetEnd)
                return;
            // 
            int offset = offsetStart + 0x140000;
            this.Partition = rom[offset++];
            while (offset < offsetEnd + 0x140000)
            {
                var npcObject = new NPCObject();
                npcObject.ReadFromROM(NPCObjects, ref offset);
                NPCObjects.Add(npcObject);
            }
        }
        public void WriteToROM(ref int offsetStart)
        {
            int pointerOffset = (AreaIndex * 2) + 0x148000;
            Bits.SetShort(rom, pointerOffset, offsetStart);
            if (NPCObjects.Count == 0)
                return;
            int offset = offsetStart + 0x140000;
            rom[offset++] = Partition;
            //
            foreach (var npcObject in NPCObjects)
                npcObject.WriteToROM(NPCObjects, ref offset);
            offsetStart = (ushort)(offset - 0x140000);
        }
        /// <summary>
        /// Returns the total size of the NPCObjectCollection's binary data.
        /// </summary>
        /// <returns></returns>
        public int GetTotalSize()
        {
            if (this.Count == 0)
                return 0;

            int totalSize = 1;

            // Add total size of each NPCObject
            for (int i = 0; i < NPCObjects.Count; i++)
            {
                // 12 bytes per npc
                totalSize += 12;

                // Get reference info for npc
                var referenceInfo = NPCObjects[i].GetReferenceInfo(NPCObjects, i);
                int referenceCount = referenceInfo.Count;

                // 4 bytes per reference
                totalSize += referenceCount * 4;

                // Skip siblings that are references
                i += referenceCount;
            }

            // Finished
            return totalSize;
        }

        #endregion

        #region Enumeration

        // Collection members
        public NPCObject this[int index]
        {
            get { return this.NPCObjects[index]; }
            set { this.NPCObjects[index] = value; }
        }
        public void Add(NPCObject value)
        {
            this.NPCObjects.Add(value);
        }
        public void Clear()
        {
            NPCObjects.Clear();
        }
        public bool Contains(NPCObject value)
        {
            foreach (var npcObject in NPCObjects)
            {
                if (npcObject == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(NPCObject[] triggers, int arrayIndex)
        {
            NPCObjects.CopyTo(triggers, arrayIndex);
        }
        public int Count
        {
            get { return NPCObjects.Count; }
        }
        public int IndexOf(NPCObject value)
        {
            for (int i = 0; i < NPCObjects.Count; i++)
            {
                if (NPCObjects[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, NPCObject value)
        {
            if (index < NPCObjects.Count)
                NPCObjects.Insert(index, value);
            else
                NPCObjects.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var e = new NPCObject();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < NPCObjects.Count)
                NPCObjects.Insert(index, e);
            else
                NPCObjects.Add(e);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(NPCObject value)
        {
            for (int i = 0; i < NPCObjects.Count; i++)
            {
                if (NPCObjects[i] == value)
                {
                    NPCObjects.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            NPCObjects.RemoveAt(index);
        }
        public void Reverse(int index, int count)
        {
            NPCObjects.Reverse(index, count);
        }
        // Enumerator
        public IEnumerator<NPCObject> GetEnumerator()
        {
            return new NPCObjectEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NPCObjectEnumerator(this);
        }

        #endregion
    }
    [Serializable()]
    public class NPCObject
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // NPC properties
        public EngageType EngageType { get; set; }
        public byte SpeedPlus { get; set; }
        public ushort NPCID { get; set; }
        public ushort Action { get; set; }
        public ushort Event { get; set; }
        public byte Pack { get; set; }
        public byte EngageTrigger { get; set; }
        public byte AfterBattle { get; set; }

        // Unknown bits
        public bool B2b3 { get; set; }
        public bool B2b4 { get; set; }
        public bool B2b5 { get; set; }
        public bool B2b6 { get; set; }
        public bool B2b7 { get; set; }
        public bool B3b0 { get; set; }
        public bool B3b1 { get; set; }
        public bool B3b2 { get; set; }
        public bool B3b3 { get; set; }
        public bool B3b4 { get; set; }
        public bool B3b5 { get; set; }
        public bool B3b6 { get; set; }
        public bool B3b7 { get; set; }
        public bool B4b0 { get; set; }
        public bool B4b1 { get; set; }
        public bool B7b6 { get; set; }
        public bool B7b7 { get; set; }

        // Coordinates
        public byte X { get; set; }
        public byte Y { get; set; }
        public byte Z { get; set; }
        public byte F { get; set; }

        // Coordinate bits
        public bool ShowNPC { get; set; }
        public bool ZHalf { get; set; }

        // Relative reference properties
        public byte Mem70A7 { get; set; }

        #endregion

        #region Methods

        // Read/write ROM
        public void ReadFromROM(List<NPCObject> NPCObjects, ref int offset)
        {
            ReferenceInfo referenceInfo = new ReferenceInfo();

            byte temp = rom[offset++];

            //
            referenceInfo.Count = temp & 0x0F;

            //
            EngageType = (EngageType)((temp & 0x30) >> 4);
            temp = rom[offset++];
            SpeedPlus = (byte)(temp & 0x07);

            //
            B2b3 = (temp & 0x08) == 0x08;
            B2b4 = (temp & 0x10) == 0x10;
            B2b5 = (temp & 0x20) == 0x20;
            B2b6 = (temp & 0x40) == 0x40;
            B2b7 = (temp & 0x80) == 0x80;

            //
            temp = rom[offset++];
            B3b0 = (temp & 0x01) == 0x01;
            B3b1 = (temp & 0x02) == 0x02;
            B3b2 = (temp & 0x04) == 0x04;
            B3b3 = (temp & 0x08) == 0x08;
            B3b4 = (temp & 0x10) == 0x10;
            B3b5 = (temp & 0x20) == 0x20;
            B3b6 = (temp & 0x40) == 0x40;
            B3b7 = (temp & 0x80) == 0x80;

            //
            B4b0 = (rom[offset] & 0x01) == 0x01;
            B4b1 = (rom[offset] & 0x02) == 0x02;

            //
            referenceInfo.BaseNPCID = (Bits.GetShort(rom, offset++) & 0x0FFF) >> 2;
            referenceInfo.BaseAction = (Bits.GetShort(rom, offset++) & 0x3FF0) >> 4;

            //
            B7b6 = (rom[offset] & 0x40) == 0x40;
            B7b7 = (rom[offset++] & 0x80) == 0x80;

            //
            ushort tempShort = Bits.GetShort(rom, offset++);
            if (EngageType == EngageType.Battle)
                referenceInfo.BasePack = tempShort & 0xFF;
            else
                referenceInfo.BaseEvent = tempShort & 0xFFF;

            //
            temp = rom[offset++];
            if (EngageType == EngageType.Battle)
                AfterBattle = (byte)((temp >> 1) & 0x07);
            EngageTrigger = (byte)Math.Min((temp & 0xF0) >> 4, 12);

            // Add references to collection
            ReadReference(ref offset, referenceInfo);
            int count = referenceInfo.Count;
            while (count-- > 0)
            {
                NPCObject reference = this.Copy();
                reference.ReadReference(ref offset, referenceInfo);
                NPCObjects.Add(reference);
            }
        }
        private void ReadReference(ref int offset, ReferenceInfo referenceInfo)
        {
            byte temp = rom[offset++];
            if (EngageType == EngageType.Event)
            {
                NPCID = (ushort)(referenceInfo.BaseNPCID + (temp & 0x07));         // NPC ID+
                Action = (ushort)(referenceInfo.BaseAction + ((temp & 0x18) >> 3)); // Action+
                Event = (ushort)(referenceInfo.BaseEvent + ((temp & 0xE0) >> 5));  // Event+
            }
            else if (EngageType == EngageType.Treasure)
            {
                NPCID = (ushort)referenceInfo.BaseNPCID;
                Action = (ushort)referenceInfo.BaseAction;
                Event = (ushort)referenceInfo.BaseEvent;
                Mem70A7 = temp;                          // $70A7
            }
            else if (EngageType == EngageType.Battle)
            {
                NPCID = (ushort)referenceInfo.BaseNPCID;
                Action = (ushort)(referenceInfo.BaseAction + (temp & 0x0F));        // Action+
                Pack = (byte)(referenceInfo.BasePack + ((temp & 0xF0) >> 4));   // Pack+
            }
            //
            temp = rom[offset++];
            X = (byte)(temp & 0x7F);
            ShowNPC = (temp & 0x80) == 0x80;
            temp = rom[offset++];
            Y = (byte)(temp & 0x7F);
            ZHalf = (temp & 0x80) == 0x80;
            temp = rom[offset++];
            Z = (byte)(temp & 0x1F);
            F = (byte)((temp & 0xF0) >> 5);
        }
        public void WriteToROM(List<NPCObject> NPCObjects, ref int offset)
        {
            // Declare index of this instance in a collection
            int index = NPCObjects.IndexOf(this);

            // Get the reference info for this instance
            var referenceInfo = GetReferenceInfo(NPCObjects, index);

            // Write the reference count
            rom[offset] = (byte)referenceInfo.Count;

            // Start writing base data
            Bits.SetBitsByByte(rom, offset++, (byte)((int)EngageType << 4), true);

            // Speed plus
            rom[offset] = SpeedPlus;

            // B2 unknown bits
            Bits.SetBit(rom, offset, 3, B2b3);
            Bits.SetBit(rom, offset, 4, B2b4);
            Bits.SetBit(rom, offset, 5, B2b5);
            Bits.SetBit(rom, offset, 6, B2b6);
            Bits.SetBit(rom, offset++, 7, B2b7);

            // B3 unknown bits
            Bits.SetBit(rom, offset, 0, B3b0);
            Bits.SetBit(rom, offset, 1, B3b1);
            Bits.SetBit(rom, offset, 2, B3b2);
            Bits.SetBit(rom, offset, 3, B3b3);
            Bits.SetBit(rom, offset, 4, B3b4);
            Bits.SetBit(rom, offset, 5, B3b5);
            Bits.SetBit(rom, offset, 6, B3b6);
            Bits.SetBit(rom, offset++, 7, B3b7);

            // NPCID
            Bits.SetShort(rom, offset, referenceInfo.BaseNPCID << 2);

            // B4b0,1
            Bits.SetBit(rom, offset, 0, B4b0);
            Bits.SetBit(rom, offset++, 1, B4b1);

            // Action
            Bits.SetBitsByByte(rom, offset++, (byte)((referenceInfo.BaseAction << 4) & 0xF0), true); // lower 4 bits
            rom[offset] = (byte)(referenceInfo.BaseAction >> 4); // lower 6 bits

            // B7b6,7
            Bits.SetBit(rom, offset, 6, B7b6);
            Bits.SetBit(rom, offset++, 7, B7b7);

            // Event / Pack
            if (EngageType != EngageType.Battle)
                Bits.SetShort(rom, offset, referenceInfo.BaseEvent);
            else
                rom[offset] = (byte)referenceInfo.BasePack;
            offset++;

            // Engage trigger
            rom[offset] &= 0x0F;
            rom[offset] |= (byte)(EngageTrigger << 4);

            // After battle
            if (EngageType == EngageType.Battle)
            {
                rom[offset] &= 0xF0;
                rom[offset] |= (byte)(AfterBattle << 1);
            }
            offset++;

            // Write any references to ROM
            int count = referenceInfo.Count;
            while (count-- >= 0)
                WriteReference(referenceInfo, ref offset);
        }
        private void WriteReference(ReferenceInfo referenceInfo, ref int offset)
        {
            if (EngageType == EngageType.Event)
            {
                rom[offset] = (byte)((NPCID - referenceInfo.BaseNPCID));
                rom[offset] |= (byte)((Action - referenceInfo.BaseAction) << 3);
                rom[offset] |= (byte)((Event - referenceInfo.BaseEvent) << 5);
            }
            else if (EngageType == EngageType.Treasure)
                rom[offset] = Mem70A7;
            else if (EngageType == EngageType.Battle)
            {
                rom[offset] = (byte)(Pack - referenceInfo.BasePack);
                rom[offset] |= (byte)((Action - referenceInfo.BaseAction) << 4);
            }
            offset++;
            //
            rom[offset] = X;
            Bits.SetBit(rom, offset++, 7, ShowNPC);
            rom[offset] = Y;
            Bits.SetBit(rom, offset++, 7, ZHalf);
            rom[offset] = Z;
            Bits.SetBitsByByte(rom, offset++, (byte)(F << 5), true);
        }
        /// <summary>
        /// Gets the reference information for a set of NPCs which can reference
        /// a specified index in an NPCObject collection.
        /// </summary>
        /// <param name="NPCObjects"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public ReferenceInfo GetReferenceInfo(List<NPCObject> NPCObjects, int index)
        {
            ReferenceInfo referenceInfo = new ReferenceInfo();

            // Cancel if specified index at end of collection
            if (index >= NPCObjects.Count - 1)
                return referenceInfo;

            // Determine maximum number of references based on specified index
            int maxReferenceCount = NPCObjects.Count - (index + 1);
            if (maxReferenceCount > 15)
                maxReferenceCount = 15;

            // Declare the specified index and the siblings after the specified index
            var npcObject = NPCObjects[index];
            var nextSiblings = NPCObjects.GetRange(index + 1, maxReferenceCount);

            #region Compare base variables

            // First, compare referenced variables and trim sibling list accordingly
            for (int i = 0; i < nextSiblings.Count; i++)
            {
                NPCObject sibling = nextSiblings[i];

                // Compare all base variables
                if (sibling.SpeedPlus != npcObject.SpeedPlus ||
                    sibling.EngageTrigger != npcObject.EngageTrigger ||
                    sibling.AfterBattle != npcObject.AfterBattle ||
                    sibling.B2b3 != npcObject.B2b3 ||
                    sibling.B2b4 != npcObject.B2b4 ||
                    sibling.B2b5 != npcObject.B2b5 ||
                    sibling.B2b6 != npcObject.B2b6 ||
                    sibling.B2b7 != npcObject.B2b7 ||
                    sibling.B3b0 != npcObject.B3b0 ||
                    sibling.B3b1 != npcObject.B3b1 ||
                    sibling.B3b2 != npcObject.B3b2 ||
                    sibling.B3b3 != npcObject.B3b3 ||
                    sibling.B3b4 != npcObject.B3b4 ||
                    sibling.B3b5 != npcObject.B3b5 ||
                    sibling.B3b6 != npcObject.B3b6 ||
                    sibling.B3b7 != npcObject.B3b7 ||
                    sibling.B4b0 != npcObject.B4b0 ||
                    sibling.B4b1 != npcObject.B4b1 ||
                    sibling.B7b6 != npcObject.B7b6 ||
                    sibling.B7b7 != npcObject.B7b7)
                {
                    // If comparison failed, remove current and all subsequent siblings
                    nextSiblings.RemoveRange(i, nextSiblings.Count - i);
                    break;
                }

                // Cancel whole operation if no siblings left
                if (nextSiblings.Count == 0)
                    return referenceInfo;

                // If treasure, don't need to execute following code
                if (npcObject.EngageType == EngageType.Treasure)
                    continue;

                // Compare all referenced variables using boundaries
                // (Treasure engage type does not reference anything)
                if (npcObject.EngageType == EngageType.Event)
                {
                    if (sibling.NPCID > npcObject.NPCID + 7 ||
                        sibling.NPCID < npcObject.NPCID - 7 ||
                        sibling.Action > npcObject.Action + 3 ||
                        sibling.Action < npcObject.Action - 3 ||
                        sibling.Event > npcObject.Event + 7 ||
                        sibling.Event < npcObject.Event - 7)
                    {
                        // If comparison failed, remove current and all subsequent siblings
                        nextSiblings.RemoveRange(i, nextSiblings.Count - i);
                        break;
                    }
                }
                else if (npcObject.EngageType == EngageType.Battle)
                {
                    if (sibling.Action > npcObject.Action + 15 ||
                        sibling.Action < npcObject.Action - 15 ||
                        sibling.Pack > npcObject.Pack + 15 ||
                        sibling.Pack < npcObject.Pack - 15)
                    {
                        // If comparison failed, remove current and all subsequent siblings
                        nextSiblings.RemoveRange(i, nextSiblings.Count - i);
                        break;
                    }
                }

                // Cancel whole operation if no siblings left
                if (nextSiblings.Count == 0)
                    return referenceInfo;
            }

            #endregion

            // Cancel whole operation if no siblings left
            if (nextSiblings.Count == 0)
                return referenceInfo;

            // If treasure, don't need to execute following code
            if (npcObject.EngageType == EngageType.Treasure)
                return referenceInfo;

            #region Calculate lowest values

            // Declare a floor and ceiling value for the variables
            int lowestNPCID = npcObject.NPCID;
            int lowestAction = npcObject.Action;
            int lowestEvent = npcObject.Event;
            int lowestPack = npcObject.Pack;
            int highestNPCID = npcObject.NPCID;
            int highestAction = npcObject.Action;
            int highestEvent = npcObject.Event;
            int highestPack = npcObject.Pack;

            // Trim siblings based on their variables' extension beyond the floor and ceiling boundaries
            for (int i = 0; i < nextSiblings.Count; i++)
            {
                NPCObject sibling = nextSiblings[i];

                // Check if variables too high or low
                if (npcObject.EngageType == EngageType.Event)
                {
                    if (sibling.NPCID > lowestNPCID + 7 ||
                        sibling.NPCID < highestNPCID - 7 ||
                        sibling.Action > lowestAction + 3 ||
                        sibling.Action < highestAction - 3 ||
                        sibling.Event > lowestEvent + 7 ||
                        sibling.Event < highestEvent - 7)
                    {
                        // If comparison failed, remove current and all subsequent siblings
                        nextSiblings.RemoveRange(i, nextSiblings.Count - i);
                        break;
                    }
                }
                else if (npcObject.EngageType == EngageType.Battle)
                {
                    if (sibling.Action > lowestAction + 15 ||
                        sibling.Action < highestAction - 15 ||
                        sibling.Pack > lowestPack + 15 ||
                        sibling.Pack < highestPack - 15)
                    {
                        // If comparison failed, remove current and all subsequent siblings
                        nextSiblings.RemoveRange(i, nextSiblings.Count - i);
                        break;
                    }
                }

                // If lower than lowest
                if (sibling.NPCID < lowestNPCID) lowestNPCID = sibling.NPCID;
                if (sibling.Action < lowestAction) lowestAction = sibling.Action;
                if (sibling.Event < lowestEvent) lowestEvent = sibling.Event;
                if (sibling.Pack < lowestPack) lowestPack = sibling.Pack;

                // If higher than highest
                if (sibling.NPCID > highestNPCID) highestNPCID = sibling.NPCID;
                if (sibling.Action > highestAction) highestAction = sibling.Action;
                if (sibling.Event > highestEvent) highestEvent = sibling.Event;
                if (sibling.Pack > highestPack) highestPack = sibling.Pack;
            }

            #endregion

            // Cancel whole operation if no siblings left
            if (nextSiblings.Count == 0)
                return referenceInfo;

            //if (optimize)
            //{
            //    // Check each sibling to see if it can contain more references
            //    for (int i = 0; i < nextSiblings.Count; i++)
            //    {
            //        var siblingReferenceInfo = GetReferenceInfo(NPCObjects, index + 1 + i, false);

            //        // If so, remove following siblings so current sibling can contain them later
            //        if (siblingReferenceInfo.Count > nextSiblings.Count - i)
            //            nextSiblings.RemoveRange(i, nextSiblings.Count - i);
            //    }

            //    // Cancel whole operation if no siblings left
            //    if (nextSiblings.Count == 0)
            //        return referenceInfo;
            //}

            referenceInfo.Count = nextSiblings.Count;
            referenceInfo.BaseEvent = lowestEvent;
            referenceInfo.BaseNPCID = lowestNPCID;
            referenceInfo.BaseAction = lowestAction;
            referenceInfo.BasePack = lowestPack;

            // We have the full reference count
            return referenceInfo;
        }

        /// <summary>
        /// Contains the data for writing an NPCObject reference to ROM.
        /// </summary>
        public struct ReferenceInfo
        {
            public int Count { get; set; }
            public int BaseNPCID { get; set; }
            public int BaseAction { get; set; }
            public int BaseEvent { get; set; }
            public int BasePack { get; set; }
        }

        // List managers
        public void Clear()
        {
            EngageType = 0;
            SpeedPlus = 0;
            B2b3 = false;
            B2b4 = false;
            B2b5 = false;
            B2b6 = true;
            B2b7 = false;
            B3b0 = false;
            B3b1 = false;
            B3b2 = false;
            B3b3 = false;
            B3b4 = false;
            B3b5 = false;
            B3b6 = true;
            B3b7 = false;
            B4b0 = false;
            B4b1 = false;
            NPCID = 0;
            Action = 0;
            Event = 0;
            Pack = 0;
            EngageTrigger = 0;
            B7b6 = true;
            B7b7 = true;
            AfterBattle = 0;
            X = 0;
            Y = 0;
            Z = 0;
            ShowNPC = true;
            ZHalf = false;
            F = 0;
            Mem70A7 = 0;
        }
        public NPCObject Copy()
        {
            NPCObject copy = new NPCObject();
            copy.EngageType = EngageType;
            copy.SpeedPlus = SpeedPlus;
            copy.B2b3 = B2b3;
            copy.B2b4 = B2b4;
            copy.B2b5 = B2b5;
            copy.B2b6 = B2b6;
            copy.B2b7 = B2b7;
            copy.B3b0 = B3b0;
            copy.B3b1 = B3b1;
            copy.B3b2 = B3b2;
            copy.B3b3 = B3b3;
            copy.B3b4 = B3b4;
            copy.B3b5 = B3b5;
            copy.B3b6 = B3b6;
            copy.B3b7 = B3b7;
            copy.B4b0 = B4b0;
            copy.B4b1 = B4b1;
            copy.NPCID = NPCID;
            copy.Action = Action;
            copy.Event = Event;
            copy.Pack = Pack;
            copy.EngageTrigger = EngageTrigger;
            copy.B7b6 = B7b6;
            copy.B7b7 = B7b7;
            copy.AfterBattle = AfterBattle;
            //
            copy.X = X;
            copy.Y = Y;
            copy.Z = Z;
            copy.ShowNPC = ShowNPC;
            copy.ZHalf = ZHalf;
            copy.F = F;
            //
            copy.Mem70A7 = Mem70A7;
            //
            return copy;
        }

        #endregion
    }
    public class NPCObjectEnumerator : IEnumerator<NPCObject>
    {
        private NPCObjectCollection collection;
        private NPCObject currentNPCObject;
        private int currentIndex;
        public NPCObjectEnumerator(NPCObjectCollection collection)
        {
            this.collection = collection;
            this.currentNPCObject = default(NPCObject);
            this.currentIndex = -1;
        }
        public NPCObject Current
        {
            get { return currentNPCObject; }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        void IDisposable.Dispose() { }
        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection. 
            if (++currentIndex >= collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                currentNPCObject = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
