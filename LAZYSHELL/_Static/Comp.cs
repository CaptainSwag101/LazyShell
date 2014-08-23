using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    /// <summary>
    /// Class for decompressing and compressing data in the Mario RPG ROM using the Lunar Compress.dll library.
    /// </summary>
    public static class Comp
    {
        #region Variables

        [DllImport("Lunar Compress.dll")]
        static extern int LunarOpenRAMFile(
            [MarshalAs(UnmanagedType.LPArray)] byte[] data, 
            int fileMode, 
            int size);
        [DllImport("Lunar Compress.dll")]
        static extern int LunarDecompress(
            [MarshalAs(UnmanagedType.LPArray)] byte[] destination, 
            int addressToStart, 
            int maxDataSize, 
            int format1, 
            int format2, 
            int DoNotUseThisYet); // int * to save end addr for calculating size
        [DllImport("Lunar Compress.dll")]
        static extern int LunarSaveRAMFile(string fileName);
        [DllImport("Lunar Compress.dll")]
        static extern int LunarRecompress(
            [MarshalAs(UnmanagedType.LPArray)] byte[] source, 
            [MarshalAs(UnmanagedType.LPArray)] byte[] destination, 
            uint dataSize, 
            uint maxDataSize, 
            uint format, 
            uint format2);

        #endregion

        #region Methods

        #region Single array

        /// <summary>
        /// Compresses a source array using the Lunar Compress.dll library and stores the output to a destination array.
        /// </summary>
        /// <param name="src">The source array to compress.</param>
        /// <param name="dst">The destination array to store the output to.</param>
        /// <returns></returns>
        public static int Compress(byte[] src, byte[] dst)
        {
            if (!LunarCompressExists())
                return -1;
            if (dst == null)
                return LunarRecompress(src, dst, (uint)src.Length, 0, 3, 3);
            else
                return LunarRecompress(src, dst, (uint)src.Length, (uint)dst.Length, 3, 3);
        }

        /// <summary>
        /// Decompresses a source array using the Lunar Compress.dll library and returns the decompressed output.
        /// </summary>
        /// <param name="src">The source array to decompress.</param>
        /// <param name="offset">The offset of the source array to begin the decompression routine.</param>
        /// <param name="maxSize">The maximum size of the decompressed output.</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] src, int offset, int maxSize)
        {
            if (!LunarCompressExists())
                return null;
            //
            byte[] ram = new byte[maxSize];
            byte[] dst = new byte[maxSize];
            for (int i = 0; ((i < ram.Length) && ((offset + i) < src.Length)); i++)
                ram[i] = src[offset + i]; // Copy over all the source data
            if (LunarOpenRAMFile(ram, 0, ram.Length) == 0) // Load source data as RAMFile
                return null;
            int size = LunarDecompress(dst, 0, dst.Length, 3, 0, 0);
            if (size != 0)
                return dst;
            return null;
        }
        /// <summary>
        /// Decompresses a source array using the Lunar Compress.dll library and stores its value to a specified array. 
        /// Returns the total size of the decompressed output.
        /// </summary>
        /// <param name="src">The source array to decompress.</param>
        /// <param name="dst">The array to store the decompressed output to.</param>
        /// <param name="offset">The offset of the source array to begin the decompression routine.</param>
        /// <param name="maxSize">The maximum size of the decompressed output.</param>
        /// <returns></returns>
        public static int Decompress(byte[] src, byte[] dst, int offset, int maxSize)
        {
            if (!LunarCompressExists())
                return 0;
            //
            byte[] ram = new byte[maxSize];
            for (int i = 0; ((i < ram.Length) && ((offset + i) < src.Length)); i++)
                ram[i] = src[offset + i]; // Copy over all the source data
            if (LunarOpenRAMFile(ram, 0, ram.Length) == 0) // Load source data as RAMFile
                return 0;
            int size = LunarDecompress(dst, 0, dst.Length, 3, 0, 0);
            return size;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">The source ROM.</param>
        /// <param name="pointerOffset">The offset of the pointer.</param>
        /// <param name="baseOffset">The offset to add the pointer to for the final offset.</param>
        /// <param name="maxSize">The uncompressed size of the array.</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] src, int pointerOffset, int baseOffset, int maxSize)
        {
            int offset = Bits.GetShort(src, pointerOffset) + baseOffset;
            return Decompress(src, offset + 1, maxSize);
        }

        #endregion

        #region Multiple arrays

        /// <summary>
        /// Decompresses data to a collection of byte arrays.
        /// </summary>
        /// <param name="arrays">The byte arrays to store the decompressed data to.</param>
        /// <param name="bankStart">The bank where the compressed data begins.</param>
        /// <param name="bankEnd">The bank where the compressed data ends. bank is NOT included in the data.</param>
        /// <param name="decompressedSizeA">The decompressed size of each byte array.</param>
        /// <param name="decompressedSizeB">The second optional decompressed size of all byte arrays starting at indexB.</param>
        /// <param name="label">The label to use in the progress bar. All caps and singular.</param>
        /// <param name="indexB">The starting index of the arrays where decompressedSizeB will start being used.</param>
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSizeA, int decompressedSizeB, string label, int indexB,
            int start, int end, bool showProgressBar)
        {
            var progressBar = new ProgressBar(Model.ROM, "DECOMPRESSING " + label + "S...", arrays.Length);
            if (showProgressBar)
                progressBar.Show();
            int bank = 0;
            for (int i = start, j = start; i < arrays.Length && i < end; i++)
            {
                j = i * 2;
                for (int k = bankStart; k < bankEnd; k += 0x010000)
                {
                    ushort temp = Bits.GetShort(Model.ROM, k);
                    if (j >= temp)
                        j -= temp;
                    else
                    {
                        bank = k; break;
                    }
                }
                int pointer = Bits.GetShort(Model.ROM, bank + j);
                int offset = bank + pointer + 1;
                if (i < indexB)
                    arrays[i] = Comp.Decompress(Model.ROM, offset, decompressedSizeA);
                else
                    arrays[i] = Comp.Decompress(Model.ROM, offset, decompressedSizeB);
                if (arrays[i] == null)
                    arrays[i] = new byte[decompressedSizeA];
                progressBar.PerformStep("DECOMPRESSING " + label + " #" + i.ToString("d" + arrays.Length.ToString().Length));
            }
            progressBar.Close();
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSizeA, int decompressedSizeB, string label, int indexB, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSizeA, decompressedSizeB, label, indexB, 0, arrays.Length, showProgressBar);
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSize, string label, int start, int end, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSize, decompressedSize, label, 0, start, end, showProgressBar);
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSize, string label, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSize, decompressedSize, label, 0, 0, arrays.Length, showProgressBar);
        }

        /// <summary>
        /// Compresses a collection of arrays and stores the compressed results to the ROM.
        /// </summary>
        /// <param name="arrays">The arrays to compress.</param>
        /// <param name="edit">The conditions which determine whether or not to recompress an array.</param>
        /// <param name="bankStart">The bank where the compressed data begins.</param>
        /// <param name="lastOffset">The final offset in the ROM of the allocated data containing the compressed arrays.</param>
        /// <param name="label">The label to use in the progress bar. All caps and singular.</param>
        /// <param name="bankIndexes">Each parameter is the index at which the collection of arrays begins writing to that respective bank.
        /// ie. the first parameter is always 0, the second parameter is where the index begins in the second bank, etc.</param>
        public static void Compress(byte[][] arrays, bool[] edit, int bankStart, int lastOffset, string label, params int[] bankIndexes)
        {
            // store original
            int bank = bankStart; // Set bank pointer
            int size = 0;
            var original = new byte[arrays.Length][];
            ushort temp = Bits.GetShort(Model.ROM, bankStart);
            for (int i = 0, a = 0; i < arrays.Length; i++)
            {
                a = i * 2;
                for (int b = bankStart; b < lastOffset; b += 0x010000)
                {
                    temp = Bits.GetShort(Model.ROM, b);
                    if (a >= temp)
                        a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(Model.ROM, bank))
                {
                    if (bank < (lastOffset & 0xFF0000))
                    {
                        size = 0x010000 - Bits.GetShort(Model.ROM, bank + a);
                        for (int o = 0xFFFF; Model.ROM[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = (lastOffset & 0xFFFF) - Bits.GetShort(Model.ROM, bank + a);
                        for (int o = (lastOffset & 0xFFFF) - 1; Model.ROM[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(Model.ROM, bank + a + 2) - Bits.GetShort(Model.ROM, bank + a);
                original[i] = Bits.GetBytes(Model.ROM, bank + Bits.GetShort(Model.ROM, bank + a), size);
            }
            // create a progress bar
            var progressBar = new ProgressBar(Model.ROM, "COMPRESSING " + label + "S", arrays.Length);
            progressBar.Show();
            // now start compressing the data and storing to ROM
            bank = bankStart;
            for (int indexBank = 0; indexBank < bankIndexes.Length; indexBank++, bank += 0x010000)
            {
                // the index in the array collection to start at
                int index = bankIndexes[indexBank];
                // the index within the current bank
                int bankIndex = 0;
                // is where the pointers end and the compressed data begins
                ushort offset;
                // the maximum index in the current bank
                int endIndex;
                // the maximum offset that can be written to in the current bank
                ushort bounds = bank == (lastOffset & 0xFF0000) ? (ushort)lastOffset : (ushort)0xFFFF;
                if (indexBank + 1 < bankIndexes.Length)
                {
                    offset = (ushort)((bankIndexes[indexBank + 1] - bankIndexes[indexBank]) * 2);
                    endIndex = bankIndexes[indexBank + 1];
                }
                // if at last bank
                else
                {
                    offset = (ushort)((arrays.Length - bankIndexes[indexBank]) * 2);
                    endIndex = arrays.Length;
                }
                for (; index < endIndex; index++, bankIndex++)
                {
                    byte[] compressed = new byte[arrays[index].Length];
                    // Write pointer offset
                    Bits.SetShort(Model.ROM, bank + (bankIndex * 2), offset);
                    // write new if edit flag set
                    if (edit[index])
                    {
                        edit[index] = false;
                        // Compress data
                        size = Comp.Compress(arrays[index], compressed);
                        if (offset + size > bounds) // Do we pass the bounds of bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Comp.Compress(new byte[arrays[index].Length], compressed);
                        }
                        // Write data to rom
                        Model.ROM[bank + offset] = 1; offset++;
                    }
                    else
                    {
                        size = original[index].Length; original[index].CopyTo(compressed, 0);
                        if (offset + size > bounds) // Do we pass the bounds of bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Comp.Compress(new byte[arrays[index].Length], compressed);
                        }
                    }
                    Bits.SetBytes(Model.ROM, bank + offset, compressed, 0, size);
                    offset += (ushort)size; // Move forward in bank
                    progressBar.PerformStep(
                        "COMPRESSING BANK 0x" + (bank >> 32).ToString("X2") + " " + label + " #" + index.ToString("d3"));
                }
                // fill up the rest of the bank with 0x00's
                if (bank < (lastOffset & 0xFF0000))
                    Bits.SetBytes(Model.ROM, bank + offset, new byte[0x010000 - offset]);
                else
                    Bits.SetBytes(Model.ROM, bank + offset, new byte[(lastOffset & 0xFFFF) - offset]);
            }
            progressBar.Close();
        }
        /// <summary>
        /// Compress and store single array to ROM. Returns success of compression function. Includes 0x01 at start.
        /// </summary>
        /// <param name="src">The array in the Model class to compress.</param>
        /// <param name="offset">The offset in the ROM to store at.</param>
        /// <param name="maxDecomp">The maximum/standard size of the decompressed data.</param>
        /// <param name="maxComp">The maximum size of the compressed data.</param>
        /// <param name="label">The name/label of the data, title-case.</param>
        /// <returns></returns>
        public static bool Compress(byte[] src, int offset, int maxDecomp, int maxComp, string label)
        {
            byte[] comp = new byte[maxDecomp];
            int size = Comp.Compress(src, comp);
            int totalSize = size + 1;
            if (totalSize > maxComp)
            {
                MessageBox.Show(
                    label + " recompressed data exceeds allotted ROM space by " +
                    (totalSize - maxComp).ToString() + " bytes.\n" + label + " was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Model.ROM[offset] = 0x01;
            Bits.SetBytes(Model.ROM, offset + 1, comp, 0, size);
            return true;
        }
        /// <summary>
        /// Compress and store single array to another array. Returns success of compression function. Includes 0x01 at start.
        /// </summary>
        /// <param name="src">The array in the Model class to compress.</param>
        /// <param name="dst">The array to store the compressed data to.</param>
        /// <param name="offset">The offset in the ROM to store at.</param>
        /// <param name="maxComp">The maximum size of the compressed data.</param>
        /// <param name="label">The name/label of the data, title-case.</param>
        /// <returns></returns>
        public static bool Compress(byte[] src, byte[] dst, ref int offset, int maxComp, string label)
        {
            byte[] comp = new byte[maxComp];
            int size = Comp.Compress(src, comp) + 1;
            if (offset + size >= maxComp)
            {
                MessageBox.Show(
                    label + " recompressed data exceeds allotted ROM space by " +
                    (size - maxComp).ToString() + " bytes.\n" + label + " was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            dst[offset] = 0x01;
            Buffer.BlockCopy(comp, 0, dst, offset + 1, size - 1);
            offset += size;
            return true;
        }

        #endregion

        /// <summary>
        /// Determines whether the Lunar Compress.dll file exists.
        /// </summary>
        /// <returns></returns>
        public static bool LunarCompressExists()
        {
            if (!File.Exists("Lunar Compress.dll"))
            {
                byte[] lc = Resources.Lunar_Compress;
                File.WriteAllBytes(Path.GetDirectoryName(Application.ExecutablePath) + '\\' + "Lunar Compress.dll", lc);
            }
            return true;
        }

        #endregion
    }
}
