using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SMRPGED
{
    public class LCDecomp
    {
        private byte[] data;

        [DllImport("Lunar Compress.dll")]
        static extern int LunarOpenRAMFile([MarshalAs(UnmanagedType.LPArray)] byte[] data, int fileMode, int size);
        [DllImport("Lunar Compress.dll")]
        static extern int LunarDecompress([MarshalAs(UnmanagedType.LPArray)] byte[] destination, int addressToStart, int maxDataSize, int format1, int format2, int DoNotUseThisYet); // int * to save end addr for calculating size
        [DllImport("Lunar Compress.dll")]
        static extern int LunarSaveRAMFile(string fileName);
        [DllImport("Lunar Compress.dll")]
        static extern int LunarRecompress([MarshalAs(UnmanagedType.LPArray)] byte[] source, [MarshalAs(UnmanagedType.LPArray)] byte[] destination, uint dataSize, uint maxDataSize, uint format, uint format2);

        public LCDecomp(byte[] data)
        {
            this.data = data;
        }

        /*
         * Returns the size of compressed data
         * 
         * Source and Destination can be the same array
         */
        public int Compress(byte[] source, byte[] dest)
        {
            if(dest == null)
                return LunarRecompress(source, dest, (uint)source.Length, 0, 3, 3);
            else
                return LunarRecompress(source, dest, (uint)source.Length, (uint)dest.Length, 3, 3);
        }

        public byte[] Decompress(int offset, int maxSize)
        {
            byte[] source; // Load as RAMFile
            byte[] dest; // Destination for decompressed tilemap

            source = new byte[maxSize];
            dest = new byte[maxSize];
            
            for (int i = 0; ((i < source.Length) && ((offset + i) < data.Length)); i++)
                source[i] = data[offset + i]; // Copy over all the source data

            if(LunarOpenRAMFile(source, 0, source.Length)== 0) // Load source data as RAMFile
                return null;

            int size = LunarDecompress(dest, 0, dest.Length, 3, 0, 0);
            
            if(size != 0)
                return dest;
            return null;
        }
    }
}
