using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace LazyShell.Patches
{
    public class IPSPatch
    {
        #region Variables

        public bool Verified { get; set; }
        private List<IPSRecord> records = new List<IPSRecord>();

        #endregion

        // Constructor
        public IPSPatch(byte[] patch)
        {
            ReadFromBuffer(patch);
        }

        #region Methods

        // Read/write patch
        private void ReadFromBuffer(byte[] patch)
        {
            int index = 0;
            try
            {
                index += ParseHeader(patch);
                while (!EndOfPatch(patch, index))
                    index += ParseRecord(patch, index);
                Verified = true;
            }
            catch
            {
                Verified = false;
            }
        }

        // Parse patch data
        private int ParseHeader(byte[] patch)
        {
            byte[] header = Bits.GetBytes(patch, 0, 5);
            if (header[0] == 'P' &&
                header[1] == 'A' &&
                header[2] == 'T' &&
                header[3] == 'C' &&
                header[4] == 'H')
                return 5; // Size of header
            else
                throw new Exception(); // Not a patch
        }
        private bool EndOfPatch(byte[] patch, int index)
        {
            if (patch[index] == 'E' &&
                patch[index + 1] == 'O' &&
                patch[index + 2] == 'F')
                return true;
            else
                return false;
        }
        private int ParseRecord(byte[] patch, int index)
        {
            IPSRecord record = new IPSRecord();
            record.offset = Bits.GetInt24Reversed(patch, index); index += 3;
            record.size = Bits.GetShortReversed(patch, index); index += 2;
            // RLE encoded
            if (record.size == 0)
            {
                record.size = Bits.GetShortReversed(patch, index); index += 2;
                record.recordData = new Byte[record.size];
                byte value = patch[index]; index++;
                for (int i = 0; i < record.recordData.Length; i++)
                    record.recordData[i] = value;
                this.records.Add(record); // Save the record
                // Return 
                return 8;
            }
            // Not RLE encoded
            record.recordData = Bits.GetBytes(patch, index, record.size); index += record.size;
            // Save the record
            this.records.Add(record);
            // Return 
            return record.size + 5;
        }

        // Apply patch to ROM
        public bool ApplyToROM(byte[] rom)
        {
            try
            {
                foreach (IPSRecord record in records)
                    ApplyIPSRecord(record, rom);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void ApplyIPSRecord(IPSRecord record, byte[] data)
        {
            Bits.SetBytes(data, record.offset, record.recordData);
        }
        /// <summary>
        /// Represents a single chunk of an IPS patch.
        /// </summary>
        private struct IPSRecord
        {
            public int offset, size;
            public byte[] recordData;
        }

        #endregion
    }
}
