using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public static class Bits
    {
        // get functions
        public static bool GetBit(byte[] data, int offset, int bit)
        {
            try
            {
                if ((data[offset] & (byte)(Math.Pow(2, bit))) == (byte)(Math.Pow(2, bit)))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "LAZY SHELL");
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
            catch (Exception ex)
            {
                MessageBox.Show("GetBit error reading from byte[] data at offset " + " \n Data size: " + "\n Please report this", "LAZY SHELL");
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

            catch (Exception ex)
            {
                MessageBox.Show("Error reading short from byte[] data at offset " + offset + " \n data size: " + data.Length, "LAZY SHELL");
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

            catch (Exception ex)
            {
                MessageBox.Show("Error reading short from byte[] data at offset " + offset + " \n data size: " + data.Length, "LAZY SHELL");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error reading int from byte[] data at offset " + offset + " \n data size: " + data.Length, "LAZY SHELL");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error reading int from byte[] data at offset " + offset + " \n data size: " + data.Length, "LAZY SHELL");
                throw new Exception();
            }
            return ret;
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

            catch (Exception ex)
            {
                MessageBox.Show("Error Getting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toGet.Length + "\nPlease report this", "LAZY SHELL");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error Getting ushort[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toGet.Length + "\nPlease report this", "LAZY SHELL");
                throw new Exception();
            }
        }
        public static int[] GetIntArray(int[] data, int offset, int size)
        {
            int[] toGet = new int[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    toGet[i] = data[offset + i];
                }
                return toGet;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Getting int[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toGet.Length + "\nPlease report this", "LAZY SHELL");
                throw new Exception();
            }
        }
        public static string GetString(byte[] data, int offset, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append((char)data[offset++]);
            return sb.ToString();
        }
        public static int GetUInt32(byte[] data, int offset)
        {
            return
                (data[offset + 3] << 24) +
                (data[offset + 2] << 16) +
                (data[offset + 1] << 8) +
                data[offset];
        }
        // set functions
        public static void SetByte(byte[] data, int offset, byte set)
        {
            try
            {
                data[offset] = set;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Writing byte: " + set + " to byte[] data at offset " + offset + " \n data size: " + data.Length + "\n Please report this", "LAZY SHELL");
                throw new Exception();
            }

        }
        public static void SetShort(byte[] data, int offset, int set)
        {
            try
            {
                data[offset] = (byte)(set & 0xff);
                data[offset + 1] = (byte)(set >> 8);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Writing short: " + set + " to byte[] data at offset " + offset + " \n data size: " + data.Length, "LAZY SHELL");
                throw new Exception();
            }

        }
        public static void SetBit(byte[] data, int offset, int bit, bool value)
        {
            try
            {
                if (bit < 8)
                {
                    if (value)
                        data[offset] |= (byte)(Math.Pow(2, bit));
                    else if (!value)
                        data[offset] &= (byte)((byte)(Math.Pow(2, bit)) ^ 0xFF);
                }
                else
                {
                    ushort number = Bits.GetShort(data, offset);
                    if (value)
                        number |= (ushort)(Math.Pow(2, bit));
                    else
                        number &= (ushort)((ushort)(Math.Pow(2, bit)) ^ 0xFFFF);
                    Bits.SetShort(data, offset, number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "LAZY SHELL");
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
            catch (Exception ex)
            {
                MessageBox.Show("SetBit error reading from byte[] data at offset " + offset + " \n Data size: " + data.Length + "\n Please report this", "LAZY SHELL");
                throw new Exception();
            }
        }
        public static void SetByteArray(byte[] data, int offset, byte[] toSet)
        {
            try
            {
                for (int i = 0; i < toSet.Length && i < data.Length; i++)
                {
                    data[offset + i] = toSet[i];
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Setting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toSet.Length + "\nPlease report this", "LAZY SHELL");
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

            catch (Exception ex)
            {
                MessageBox.Show("Error Setting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toSet.Length + "\nPlease report this", "LAZY SHELL");
                throw new Exception();
            }

        }
        public static void SetByteArray(byte[] src, byte value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }
        public static void SetCharArray(byte[] data, int offset, char[] toSet)
        {
            try
            {
                for (int i = 0; i < toSet.Length; i++)
                {
                    data[offset + i] = (byte)toSet[i];
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Setting byte[] at " + offset + "\ndata size: " + data.Length + "\nsubarray size: " + toSet.Length + "\nPlease report this", "LAZY SHELL");
                throw new Exception();
            }

        }
        public static void SetUInt24(byte[] data, int offset, int value)
        {
            data[offset++] = (byte)(value & 0xFF);
            data[offset++] = (byte)((value >> 8) & 0xFF);
            data[offset] = (byte)((value >> 16) & 0xFF);
        }
        public static void SetUInt32(byte[] data, int offset, int value)
        {
            data[offset++] = (byte)(value & 0xFF);
            data[offset++] = (byte)((value >> 8) & 0xFF);
            data[offset++] = (byte)((value >> 16) & 0xFF);
            data[offset] = (byte)((value >> 24) & 0xFF);
        }
        // operation functions
        public static void Clear(IList src)
        {
            for (int i = 0; i < src.Count; i++)
                src[i] = 0;
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
        public static bool Compare(char[] a, char[] b, int loc_a, int loc_b)
        {
            for (int c = loc_a, d = loc_b; c < a.Length && d < b.Length; c++, d++)
            {
                if (a[c] != b[d])
                    return false;
            }

            return true;
        }
        public static bool Compare(int[] a, int[] b)
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
        public static byte[] Copy(byte[] source)
        {
            if (source == null)
                return null;
            byte[] temp = new byte[source.Length];
            source.CopyTo(temp, 0);
            return temp;
        }
        public static int[] Copy(int[] source)
        {
            if (source == null)
                return null;
            int[] temp = new int[source.Length];
            source.CopyTo(temp, 0);
            return temp;
        }
        public static bool Empty(byte[] source)
        {
            for (int i = 0; i < source.Length; i++)
                if (source[i] != 0)
                    return false;
            return true;
        }
        public static void Fill(IList src, int value)
        {
            for (int i = 0; i < src.Count; i++)
                src[i] = value;
        }
        public static void Fill(byte[] src, byte value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }
        public static short ReverseBytes(short value)
        {
            byte a = (byte)(value >> 8);
            byte b = (byte)(value & 255);
            return (short)((b << 8) + a);
        }
        public static int ReverseBytes(int value)
        {
            byte a = (byte)(value >> 24);
            byte b = (byte)(value >> 16);
            byte c = (byte)(value >> 8);
            byte d = (byte)value;
            return (d << 24) + (c << 16) + (b << 8) + a;
        }
        public static int Clamp(int value, int bits)
        {
            int low = -1 << (value - 1);
            int high = (1 << (value - 1)) - 1;
            if (value > high)
                value = high;
            if (value < low)
                value = low;
            return value;
        }
    }
}
