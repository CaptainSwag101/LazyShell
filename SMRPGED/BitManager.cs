using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public static class BitManager
    {
        public static void SetBit(byte[] data, int offset, int bit, bool value)
        {
            try
            {
                if (value)
                    data[offset] |= (byte)(Math.Pow(2, bit));
                else if (!value)
                    data[offset] &= (byte)((byte)(Math.Pow(2, bit)) ^ 0xFF);
            }
            catch
            {
                MessageBox.Show("SetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static void SetBitsByByte(byte[] data, int offset, byte bits, bool value)
        {
            try
            {
                if (value)
                    data[offset] |= bits;
                else if (!value)
                    data[offset] &= (byte)(bits ^ 0xFF);
            }
            catch
            {
                MessageBox.Show("SetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static bool GetBit(byte[] data, int offset, int bit)
        {
            try
            {
                if ((data[offset] & (byte)(Math.Pow(2, bit))) == (byte)(Math.Pow(2, bit)))
                    return true;
                return false;
            }
            catch
            {
                MessageBox.Show("GetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static bool GetBit(byte data, int bit)
        {
            try
            {
                if ((data & (byte)(Math.Pow(2, bit))) == (byte)(Math.Pow(2, bit)))
                    return true;
                return false;
            }
            catch
            {
                MessageBox.Show("GetBit error reading from byte[] data at offset " + " \n Data size: " + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static byte GetByte(byte[] data, int offset)
        {
            try
            {
                return data[offset];
            }
            catch
            {
                MessageBox.Show("Error reading from byte[] data at offset " + offset + " \n data size: " + data.Length + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }

        public static void SetByte(byte[] data, int offset, byte set)
        {
            try
            {
                data[offset] = set;
            }

            catch
            {
                MessageBox.Show("Error Writing byte: " + set + " to byte[] data at offset " + offset + " \n data size: " + data.Length + "\n Please report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }

        }
        public static void SetShort(byte[] data, int offset, ushort set)
        {
            try
            {
                data[offset] = (byte)(set & 0xff);
                data[offset + 1] = (byte)(set >> 8);
            }

            catch
            {
                MessageBox.Show("Error Writing short: " + set + " to byte[] data at offset " + offset + " \n data size: " + data.Length, "Error", MessageBoxButtons.OK);
                throw new Exception();
            }

        }
        public static ushort GetShort(byte[] data, int offset)
        {
            ushort ret = 0;
            try
            {
                ret += (ushort)(data[offset + 1] << 8);
                ret += (ushort)(data[offset]);
            }

            catch
            {
                MessageBox.Show("Error reading short from byte[] data at offset " + offset + " \n data size: " + data.Length, "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
            return ret;
        }
        public static ushort GetShortBigEndian(byte[] data, int offset)
        {
            ushort ret = 0;
            try
            {
                ret += (ushort)(data[offset] << 8);
                ret += (ushort)(data[offset + 1]);
            }

            catch
            {
                MessageBox.Show("Error reading short from byte[] data at offset " + offset + " \n data size: " + data.Length, "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
            return ret;
        }

        public static int Get24Bit(byte[] data, int offset)
        {
            int ret = 0;
            try
            {
                ret += (int)(data[offset + 2] << 16);
                ret += (int)(data[offset + 1] << 8);
                ret += (int)data[offset];
            }
            catch
            {
                MessageBox.Show("Error reading int from byte[] data at offset " + offset + " \n data size: " + data.Length, "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
            return ret;
        }
        public static int Get24BitBigEndian(byte[] data, int offset)
        {
            int ret = 0;
            try
            {
                ret += (int)(data[offset] << 16);
                ret += (int)(data[offset + 1] << 8);
                ret += (int)data[offset + 2];
            }
            catch
            {
                MessageBox.Show("Error reading int from byte[] data at offset " + offset + " \n data size: " + data.Length, "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
            return ret;
        }

        public static void SetByteArray(byte[] data, int offset, byte[] toSet)
        {
            try
            {
                for (int i = 0; i < toSet.Length; i++)
                {
                    data[offset + i] = toSet[i];
                }
            }

            catch
            {
                MessageBox.Show("Error Setting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toSet.Length + "\nPlease report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }

        }
        public static void SetByteArray(byte[] data, int offset, byte[] toSet, int copyStart, int copyEnd)
        {
            try
            {
                for (int i = copyStart; i < toSet.Length && i <= copyEnd; i++)
                {
                    data[offset + i] = toSet[i];
                }
            }

            catch
            {
                MessageBox.Show("Error Setting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toSet.Length + "\nPlease report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }

        }

        public static byte[] GetByteArray(byte[] data, int offset, int size)
        {
            byte[] toGet = new byte[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    toGet[i] = data[offset + i];
                }
                return toGet;
            }

            catch
            {
                MessageBox.Show("Error Getting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toGet.Length + "\nPlease report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static ushort[] GetShortArray(byte[] data, int offset, int size)
        {
            ushort[] toGet = new ushort[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    toGet[i] = (ushort)(data[offset + 1 + (i * 2)] << 16);
                    toGet[i] += data[offset + (i * 2)];
                }
                return toGet;
            }
            catch
            {
                MessageBox.Show("Error Getting ushort[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toGet.Length + "\nPlease report this", "Error", MessageBoxButtons.OK);
                throw new Exception();
            }
        }
        public static bool Compare(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }

    }
}
