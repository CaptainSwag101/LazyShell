using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SMRPGED.Patches
{
    public class IPSPatch
    {
        private bool verified = false; public bool Verified { get { return this.verified; } }
        private ArrayList records = new ArrayList();

        // Represents one chunk of an IPS Patch
        private struct IPSRecord
        {
            public int offset, size;
            public byte[] recordData;
        }

        public IPSPatch(byte[] patch)
        {
            Dissassemble(patch);
        }
        public bool ApplyTo(byte[] data)
        {
            try
            {
                foreach (IPSRecord record in records)
                    ApplyIPSRecord(record, data);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        private void Dissassemble(byte[] patch)
        {
            int index = 0;
            try
            {
                index += ParseHeader(patch);

                while (!EndOfPatch(patch, index))
                {
                    index += ParseRecord(patch, index);
                }
                verified = true;
            }
            catch
            {
                verified = false;
            }
        }

        private int ParseHeader(byte[] patch)
        {
            byte[] header = BitManager.GetByteArray(patch, 0, 5);
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
                patch[index+1] == 'O' &&
                patch[index+2] == 'F')
                return true;
            else
                return false;
        }
        private int ParseRecord(byte[] patch, int index)
        {
            IPSRecord record = new IPSRecord();

            record.offset = BitManager.Get24BitBigEndian(patch, index); index += 3;
            record.size = BitManager.GetShortBigEndian(patch, index); index += 2;

            if (record.size == 0) // RLE encoded
            {
                record.size = BitManager.GetShortBigEndian(patch, index); index += 2;
                record.recordData = new Byte[record.size];
                byte value = BitManager.GetByte(patch, index); index++;

                for (int i = 0; i < record.recordData.Length; i++)
                    record.recordData[i] = value;
                this.records.Add(record); // Save the record

                return 8; // Return 

            }

            // Not RLE encoded
            record.recordData = BitManager.GetByteArray(patch, index, record.size); index += record.size;
            this.records.Add(record); // Save the record

            return record.size + 5; // Return 
        }

        private void ApplyIPSRecord(IPSRecord record, byte[] data)
        {
            BitManager.SetByteArray(data, record.offset, record.recordData);
        }
    }
}
