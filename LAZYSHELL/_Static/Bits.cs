using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LAZYSHELL
{
    /// <summary>
    /// Class for managing, converting, and modifying the values of various integer types.
    /// </summary>
    public static class Bits
    {
        public static readonly string[] BitNames = new string[] 
        { 
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" 
        };
        
        #region Get methods

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
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static bool GetBit(byte data, int bit)
        {
            try
            {
                if ((data & (byte)Math.Pow(2, bit)) == (byte)Math.Pow(2, bit))
                    return true;
                return false;
            }
            catch
            {
                throw new Exception();
            }
        }
        public static bool GetBit(int data, int bit)
        {
            try
            {
                if ((data & (int)Math.Pow(2, bit)) == (int)Math.Pow(2, bit))
                    return true;
                return false;
            }
            catch
            {
                throw new Exception();
            }
        }
        public static int GetByte(ref string text)
        {
            string number = "";
            while (text.StartsWith("\n"))
                text = text.Remove(0, 1);
            while (text.StartsWith("$"))
                text = text.Remove(0, 1);
            number = text.Substring(0, 2);
            text = text.Remove(0, 2);
            return Convert.ToInt32(number, 16);
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
            return ret;
        }
        public static ushort GetShortReversed(byte[] data, int offset)
        {
            ushort ret = 0;
            try
            {
                ret += (ushort)(data[offset] << 8);
                ret += (ushort)(data[offset + 1]);
            }
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
            return ret;
        }
        public static int GetInt24(byte[] data, int offset)
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
            return ret;
        }
        public static int GetInt24Reversed(byte[] data, int offset)
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
            return ret;
        }
        public static int GetInt32(byte[] data, int offset)
        {
            return
                (data[offset + 3] << 24) +
                (data[offset + 2] << 16) +
                (data[offset + 1] << 8) +
                data[offset];
        }

        // Arrays
        public static byte[] GetBytes(byte[] data, int offset)
        {
            byte[] toGet = new byte[data.Length - offset];
            try
            {
                for (int i = 0; i < data.Length && i < toGet.Length; i++)
                {
                    toGet[i] = data[offset + i];
                }
                return toGet;
            }
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static byte[] GetBytes(byte[] data, int offset, int size)
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static ushort[] GetShorts(byte[] data, int offset, int size)
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static int[] GetInts(int[] data, int offset, int size)
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
            catch
            {
                ShowError(offset, data.Length);
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
        /// <summary>
        /// Converts a value's bits to a string of fields separated by commas. Fields are included in the output if the respected bit is set.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="names"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetString(int bits, string[] names, int length)
        {
            string output = "";
            string[] fields = new string[length];
            bool pre = false;
            for (int b = 1, i = 0; i < length; b *= 2, i++)
            {
                if ((bits & b) == b)
                {
                    if (pre && i > 0)
                        fields[i] = ",";
                    if (names != null)
                        fields[i] += names[i];
                    else
                        fields[i] += i;
                    pre = true;
                }
                else fields[i] = "";
            }
            for (int i = 0; i < fields.Length; i++)
                output += fields[i];
            return output;
        }

        // String readers
        public static int GetShort(ref string text)
        {
            string number = "";
            if (text.StartsWith("$"))
                text = text.Remove(0, 1);
            number += text.Substring(0, 2);
            text = text.Remove(0, 2);
            if (text.StartsWith("$"))
                text = text.Remove(0, 1);
            number += text.Substring(0, 2);
            text = text.Remove(0, 2);
            return Convert.ToInt16(number, 16);
        }
        public static int GetInt32(ref string text)
        {
            // find first occurence of number
            string number = "";
            int index = 0;
            string pattern = "[0-9\\-]";
            while (index < text.Length)
                if (Regex.IsMatch(text[index].ToString(), pattern))
                    break;
                else
                    index++;
            while (index < text.Length && Regex.IsMatch(text[index].ToString(), pattern))
            {
                number += text[index].ToString();
                index++;
            }
            text = text.Remove(0, index);
            return Convert.ToInt32(number, 10);
        }
        public static int GetInt32(ref string text, int start)
        {
            int index = start;
            string number = "";
            while (index < text.Length && Regex.IsMatch(text[index].ToString(), "[0-9]"))
            {
                number += text[index].ToString();
                index++;
            }
            return Convert.ToInt32(number, 10);
        }
        public static int GetInt32(string text)
        {
            return GetInt32(ref text);
        }

        #endregion

        #region Set methods

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
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetBit(ref byte data, int bit, bool value)
        {
            try
            {
                if (value)
                    data |= (byte)(Math.Pow(2, bit));
                else if (!value)
                    data &= (byte)((byte)(Math.Pow(2, bit)) ^ 0xFF);
            }
            catch
            {
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
                ShowError(offset, data.Length);
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetByteBits(byte[] data, int offset, byte set, byte bits)
        {
            // "check" are the bits to set exclusively
            try
            {
                // clear the bits to set
                data[offset] &= (byte)(bits ^ 0xFF);
                // set the byte bits
                data[offset] |= (byte)set;
            }
            catch
            {
            }
        }
        public static void SetShort(byte[] data, int offset, int set)
        {
            try
            {
                data[offset] = (byte)(set & 0xff);
                data[offset + 1] = (byte)(set >> 8);
            }
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetInt24(byte[] data, int offset, int value)
        {
            data[offset++] = (byte)(value & 0xFF);
            data[offset++] = (byte)((value >> 8) & 0xFF);
            data[offset] = (byte)((value >> 16) & 0xFF);
        }
        public static void SetInt32(byte[] data, int offset, int value)
        {
            data[offset++] = (byte)(value & 0xFF);
            data[offset++] = (byte)((value >> 8) & 0xFF);
            data[offset++] = (byte)((value >> 16) & 0xFF);
            data[offset] = (byte)((value >> 24) & 0xFF);
        }

        // Arrays
        public static void SetBytes(byte[] data, int offset, byte[] src)
        {
            try
            {
                for (int i = 0; i < src.Length && i < data.Length; i++)
                {
                    data[offset + i] = src[i];
                }
            }
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetBytes(byte[] data, int offset, byte[] toSet, int copyStart, int copyEnd)
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
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetBytes(byte[] src, byte value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }
        public static void SetChars(byte[] data, int offset, char[] toSet)
        {
            try
            {
                for (int i = 0; i < toSet.Length; i++)
                {
                    data[offset + i] = (byte)toSet[i];
                }
            }
            catch
            {
                ShowError(offset, data.Length);
                throw new Exception();
            }
        }
        public static void SetChars(char[] dst, int offset, char[] src)
        {
            try
            {
                for (int i = 0; i < src.Length; i++)
                {
                    dst[offset + i] = src[i];
                }
            }
            catch
            {
                ShowError(offset, dst.Length);
                throw new Exception();
            }
        }

        #endregion

        #region Converting

        // Clear
        public static void Clear(IList src)
        {
            for (int i = 0; i < src.Count; i++)
                src[i] = 0;
        }
        public static void Clear(byte[] src, int offset)
        {
            for (int i = offset; i < src.Length; i++)
                src[i] = 0;
        }

        // Compare
        public static bool Compare(byte[] srcA, byte[] srcB)
        {
            if (srcA.Length != srcB.Length)
                return false;
            for (int i = 0; i < srcA.Length; i++)
            {
                if (srcA[i] != srcB[i])
                    return false;
            }
            return true;
        }
        public static bool Compare(byte[] srcA, byte[] srcB, int start, int end)
        {
            if (srcA.Length != srcB.Length)
                return false;
            for (int i = start; i < srcA.Length && i < end; i++)
            {
                if (srcA[i] != srcB[i])
                    return false;
            }
            return true;
        }
        public static bool Compare(char[] srcA, char[] srcB)
        {
            if (srcA.Length != srcB.Length)
                return false;
            return Compare(srcA, srcB, 0, 0);
        }
        /// <summary>
        /// Compares the substrings of two character arrays, starting at a specified location in each array.
        /// </summary>
        /// <param name="srcA">The </param>
        /// <param name="srcB"></param>
        /// <param name="startA"></param>
        /// <param name="startB"></param>
        /// <returns></returns>
        public static bool Compare(char[] srcA, char[] srcB, int startA, int startB)
        {
            for (int a = startA, b = startB; a < srcA.Length && b < srcB.Length; a++, b++)
            {
                if (srcA[a] != srcB[b])
                    return false;
            }
            return true;
        }
        public static bool Compare(int[] srcA, int[] srcB)
        {
            if (srcA.Length != srcB.Length)
                return false;
            for (int i = 0; i < srcA.Length; i++)
            {
                if (srcA[i] != srcB[i])
                    return false;
            }
            return true;
        }
        public static bool Compare(ushort[] srcA, ushort[] srcB)
        {
            if (srcA.Length != srcB.Length)
                return false;
            for (int i = 0; i < srcA.Length; i++)
            {
                if (srcA[i] != srcB[i])
                    return false;
            }
            return true;
        }

        // Copy
        public static byte[] Copy(byte[] source)
        {
            if (source == null)
                return null;
            byte[] temp = new byte[source.Length];
            source.CopyTo(temp, 0);
            return temp;
        }
        public static ushort[] Copy(ushort[] source)
        {
            if (source == null)
                return null;
            ushort[] temp = new ushort[source.Length];
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
        public static bool[] Copy(bool[] source)
        {
            if (source == null)
                return null;
            bool[] temp = new bool[source.Length];
            source.CopyTo(temp, 0);
            return temp;
        }

        // Empty
        public static bool Empty(ushort[] source)
        {
            for (int i = 0; i < source.Length; i++)
                if (source[i] != 0)
                    return false;
            return true;
        }
        public static bool Empty(byte[] source)
        {
            for (int i = 0; i < source.Length; i++)
                if (source[i] != 0)
                    return false;
            return true;
        }
        public static bool Empty(int[] source)
        {
            for (int i = 0; i < source.Length; i++)
                if (source[i] != 0)
                    return false;
            return true;
        }

        // EndsWith
        public static bool EndsWith(char[] source, char[] value)
        {
            if (value.Length > source.Length)
                return false;
            for (int a = source.Length - 1, b = value.Length - 1; a >= 0 && b >= 0; a--, b--)
            {
                if (source[a] != value[b])
                    return false;
            }
            return true;
        }

        // Fill
        public static void Fill(int[] src, int value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }
        public static void Fill(int[] src, int value, bool onlyEmpty)
        {
            for (int i = 0; i < src.Length; i++)
                if (!onlyEmpty || (onlyEmpty && src[i] == 0))
                    src[i] = value;
        }
        public static void Fill(byte[] src, byte value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }
        public static void Fill(byte[] src, byte value, int start, int size)
        {
            for (int i = start; i < size + start; i++)
                src[i] = value;
        }
        public static void Fill(char[] src, char value)
        {
            for (int i = 0; i < src.Length; i++)
                src[i] = value;
        }

        // Find
        public static int Find(byte[] src, byte[] value, int startOffset)
        {
            for (int i = startOffset; i < src.Length; i++)
            {
                if (value.Length + i > src.Length)
                    return -1;
                if (Compare(value, GetBytes(src, i, value.Length)))
                    return i;
            }
            return -1;
        }

        // Resize
        public static byte[] Resize(byte[] src, int newSize)
        {
            byte[] output = new byte[newSize];
            for (int i = 0; i < output.Length && i < src.Length; i++)
                output[i] = src[i];
            return output;
        }

        /// <summary>
        /// Returns true if specified index >= to 0 and less than specified overflow index.
        /// </summary>
        /// <param name="max">Overflow index, or maximum index plus one.</param>
        /// <param name="index">The index to check for a valid range.</param>
        /// <returns></returns>
        public static bool Range(int overflow, int index)
        {
            if (index >= overflow || index < 0)
                return false;
            return true;
        }

        // Reverse
        public static short Reverse(short value)
        {
            byte a = (byte)(value >> 8);
            byte b = (byte)(value & 255);
            return (short)((b << 8) + a);
        }
        public static int Reverse(int value)
        {
            byte a = (byte)(value >> 24);
            byte b = (byte)(value >> 16);
            byte c = (byte)(value >> 8);
            byte d = (byte)value;
            return (d << 24) + (c << 16) + (b << 8) + a;
        }

        // Miscellaneous
        public static byte StringToByte(string value, int index)
        {
            string substring = value.Substring(index * 2, 2);
            byte equipment = Convert.ToByte(substring, 16);
            return equipment;
        }
        public static void Switch(ref int valueA, ref int valueB)
        {
            int temp = valueA;
            valueA = valueB;
            valueB = temp;
        }

        #endregion

        private static void ShowError(int offset, int length)
        {
            MessageBox.Show(
                "Error accessing data at $" + offset + " in " + length + " byte array.\n\n" + "Please report this.",
                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
