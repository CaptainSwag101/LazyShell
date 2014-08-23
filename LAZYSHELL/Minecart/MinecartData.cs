using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Minecart
{
    [Serializable()]
    public class MinecartData
    {
        #region Variables

        // Buffer
        public byte[] Buffer { get; set; }

        // Collections
        public MinecartObject[] Mode7ObjectsA { get; set; }
        public MinecartObject[] Mode7ObjectsB { get; set; }
        public List<int> L1Screens { get; set; }
        public List<int> L2Screens { get; set; }
        public List<int> RailScreens { get; set; }
        public List<MinecartObject> SSObjectsA { get; set; }
        public List<MinecartObject> SSObjectsB { get; set; }
        public int WidthA { get; set; }
        public int WidthB { get; set; }

        // Images
        [NonSerialized()]
        private Bitmap mushroom;
        public Bitmap Mushroom
        {
            get
            {
                if (mushroom == null)
                {
                    int[] pixels = Do.GetPixelRegion(Model.ObjectGraphics, 0x20, Model.ObjectPaletteSet.Palettes[1], 16, 0, 0, 2, 2, 0);
                    mushroom = Do.PixelsToImage(pixels, 16, 16);
                }
                return mushroom;
            }
            set { mushroom = value; }
        }
        [NonSerialized()]
        private Bitmap coin;
        public Bitmap Coin
        {
            get
            {
                if (coin == null)
                {
                    int[] pixels = Do.GetPixelRegion(Model.ObjectGraphics, 0x20, Model.ObjectPaletteSet.Palettes[0], 16, 2, 0, 2, 2, 0);
                    coin = Do.PixelsToImage(pixels, 16, 16);
                }
                return coin;
            }
            set { coin = value; }
        }

        #endregion

        // Constructor
        public MinecartData(byte[] buffer)
        {
            this.Buffer = buffer;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            // mode7 objects
            int offset = Bits.GetShort(Buffer, 0);
            Mode7ObjectsA = new MinecartObject[8];
            Mode7ObjectsB = new MinecartObject[8];
            for (int i = 0; i < 8; i++)
                Mode7ObjectsA[i] = new MinecartObject(Buffer[offset++], Buffer[offset++]);
            for (int i = 0; i < 8; i++)
                Mode7ObjectsB[i] = new MinecartObject(Buffer[offset++], Buffer[offset++]);

            // side-scrolling objects A
            SSObjectsA = new List<MinecartObject>();
            offset = Bits.GetShort(Buffer, 2);
            WidthA = Bits.GetShort(Buffer, offset); offset += 2;
            while (Bits.GetShort(Buffer, offset) != 0xFFFF)
            {
                int x = Bits.GetShort(Buffer, offset) + 256; offset += 2;
                int type = Buffer[offset++];
                int size = Buffer[offset++];
                int y = Buffer[offset++];
                SSObjectsA.Add(new MinecartObject(type, x, y, size));
            }

            // side-scrolling objects B
            SSObjectsB = new List<MinecartObject>();
            offset = Bits.GetShort(Buffer, 4);
            WidthB = Bits.GetShort(Buffer, offset); offset += 2;
            while (Bits.GetShort(Buffer, offset) != 0xFFFF)
            {
                int x = Bits.GetShort(Buffer, offset) + 256; offset += 2;
                int type = Buffer[offset++];
                int size = Buffer[offset++];
                int y = Buffer[offset++];
                SSObjectsB.Add(new MinecartObject(type, x, y, size));
            }

            // side-scrolling L1 screens
            L1Screens = new List<int>();
            offset = Bits.GetShort(Buffer, 6);
            while (offset != Bits.GetShort(Buffer, 8))
                L1Screens.Add(Buffer[offset++]);

            // side-scrolling L2 screens
            L2Screens = new List<int>();
            offset = Bits.GetShort(Buffer, 8);
            while (offset != Bits.GetShort(Buffer, 10))
                L2Screens.Add(Buffer[offset++]);

            // side-scrolling rail screens (2nd map)
            RailScreens = new List<int>();
            offset = Bits.GetShort(Buffer, 10);
            while (offset < Buffer.Length)
                RailScreens.Add(Buffer[offset++]);
        }
        public void WriteToROM()
        {
            byte[] data = new byte[0x10000];
            int offset = 0xC;

            // mode7 objects
            Bits.SetShort(data, 0, offset);
            for (int i = 0; i < 8; i++)
            {
                data[offset++] = (byte)Mode7ObjectsA[i].X;
                data[offset++] = (byte)Mode7ObjectsA[i].Y;
            }
            for (int i = 0; i < 8; i++)
            {
                data[offset++] = (byte)Mode7ObjectsB[i].X;
                data[offset++] = (byte)Mode7ObjectsB[i].Y;
            }

            // side-scrolling objects A
            Bits.SetShort(data, 2, offset);
            Bits.SetShort(data, offset, WidthA); offset += 2;
            foreach (MinecartObject ssobject in SSObjectsA)
            {
                Bits.SetShort(data, offset, ssobject.X - 256); offset += 2;
                data[offset++] = (byte)ssobject.Type;
                data[offset++] = (byte)ssobject.Count;
                data[offset++] = (byte)ssobject.Y;
            }
            Bits.SetShort(data, offset, 0xFFFF); offset += 2;

            // side-scrolling objects B
            Bits.SetShort(data, 4, offset);
            Bits.SetShort(data, offset, WidthB); offset += 2;
            foreach (MinecartObject ssobject in SSObjectsB)
            {
                Bits.SetShort(data, offset, ssobject.X - 256); offset += 2;
                data[offset++] = (byte)ssobject.Type;
                data[offset++] = (byte)ssobject.Count;
                data[offset++] = (byte)ssobject.Y;
            }
            Bits.SetShort(data, offset, 0xFFFF); offset += 2;

            // side-scrolling L1 screens
            Bits.SetShort(data, 6, offset);
            foreach (int screen in L1Screens)
                data[offset++] = (byte)screen;

            // side-scrolling L2 screens
            Bits.SetShort(data, 8, offset);
            foreach (int screen in L2Screens)
                data[offset++] = (byte)screen;

            // side-scrolling rail screens (2nd map)
            Bits.SetShort(data, 10, offset);
            foreach (int screen in RailScreens)
                data[offset++] = (byte)screen;

            //
            Model.Objects = new byte[offset];
            System.Buffer.BlockCopy(data, 0, Model.Objects, 0, Model.Objects.Length);
        }

        #endregion
    }

    [Serializable()]
    public class MinecartObject
    {
        #region Variables

        public Point Location;
        public int Type;
        public int X;
        public int Y;
        public int Count;
        public int Width
        {
            get { return Count * 32 - 16; }
        }

        #endregion

        // Constructors
        public MinecartObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        public MinecartObject(int type, int x, int y, int count)
        {
            Type = type;
            X = x;
            Y = y;
            Count = count;
        }

        #region Methods

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public MinecartObject Copy()
        {
            MinecartObject copy = new MinecartObject(Type, X, Y, Count);
            copy.Location = Location;
            return copy;
        }

        #endregion
    }
}
