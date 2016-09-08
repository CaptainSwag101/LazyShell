using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Battlefields
{
    [Serializable()]
    class Tileset
    {
        #region Variables

        // Properties
        public Battlefield Battlefield { get; set; }
        public byte[] Graphics { get; set; }
        public byte[] Tileset_bytes { get; set; }
        public Tile[] Tileset_tiles { get; set; }
        public PaletteSet Palettes { get; set; }

        #endregion

        // Constructors
        public Tileset(Battlefield battlefield, PaletteSet palettes)
        {
            this.Battlefield = battlefield;
            this.Palettes = palettes;
            // compile graphics
            Graphics = new byte[0x6000];
            if (battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetA + 0x48], 0, Graphics, 0, 0x2000);
            if (battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetB + 0x48], 0, Graphics, 0x2000, 0x1000);
            if (battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetC + 0x48], 0, Graphics, 0x3000, 0x1000);
            if (battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetD + 0x48], 0, Graphics, 0x4000, 0x1000);
            if (battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetE + 0x48], 0, Graphics, 0x5000, 0x1000);
            // create tileset
            Tileset_bytes = Model.Tilesets[battlefield.Tileset];
            Tileset_tiles = new Tile[32 * 32];
            for (int i = 0; i < Tileset_tiles.Length; i++)
                Tileset_tiles[i] = new Tile(i);
            ParseTileset(Tileset_bytes, Tileset_tiles);
        }
        public Tileset(Battlefield battlefield, PaletteSet palettes, Tile[] tileset_tiles)
        {
            this.Battlefield = battlefield;
            this.Palettes = palettes;
            this.Tileset_bytes = new byte[0x2000];
            this.Tileset_tiles = tileset_tiles;
            Graphics = new byte[0x6000];
            if (battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetA + 0x48], 0, Graphics, 0, 0x2000);
            if (battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetB + 0x48], 0, Graphics, 0x2000, 0x1000);
            if (battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetC + 0x48], 0, Graphics, 0x3000, 0x1000);
            if (battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetD + 0x48], 0, Graphics, 0x4000, 0x1000);
            if (battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(Areas.Model.GraphicSets[battlefield.GraphicSetE + 0x48], 0, Graphics, 0x5000, 0x1000);
            ParseTileset(tileset_tiles, Tileset_bytes);
        }
        public Tileset()
        {
        }

        #region Methods

        /// <summary>
        /// Writes this tileset's tile data to the elements in the global Model.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void WriteToModel(int width, int height)
        {
            // Iterate through each quadrant
            for (int q = 0; q < 4; q++)
            {
                // Iterate through each row of tiles
                for (int y = 0; y < height; y++)
                {
                    // Iterate through each tile in row
                    for (int x = 0; x < width; x++)
                    {
                        var tile = Tileset_tiles[(y * width + x) + (q * 256)];
                        if (tile == null)
                            continue;
                        for (int s = 0; s < 4; s++)
                        {
                            int offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 2 * 2);
                            offset += (q * 256) * 8;
                            Subtile subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(Tileset_bytes, offset, (ushort)subtile.Index);
                            Tileset_bytes[offset + 1] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(Tileset_bytes, offset + 1, 5, subtile.Priority1);
                            Bits.SetBit(Tileset_bytes, offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(Tileset_bytes, offset + 1, 7, subtile.Invert);
                        }
                    }
                }
            }
            Model.EditTilesets[Battlefield.Tileset] = true;
            if (Battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(Graphics, 0, Areas.Model.GraphicSets[Battlefield.GraphicSetA + 0x48], 0, 0x2000);
            if (Battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(Graphics, 0x2000, Areas.Model.GraphicSets[Battlefield.GraphicSetB + 0x48], 0, 0x1000);
            if (Battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(Graphics, 0x3000, Areas.Model.GraphicSets[Battlefield.GraphicSetC + 0x48], 0, 0x1000);
            if (Battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(Graphics, 0x4000, Areas.Model.GraphicSets[Battlefield.GraphicSetD + 0x48], 0, 0x1000);
            if (Battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(Graphics, 0x5000, Areas.Model.GraphicSets[Battlefield.GraphicSetE + 0x48], 0, 0x1000);
        }
        /// <summary>
        /// Convert a tileset's binary data to a Tile collection.
        /// </summary>
        /// <param name="src">The binary data to convert.</param>
        /// <param name="dst">The Tile collection to store the converted data to.</param>
        public void ParseTileset(byte[] src, Tile[] dst)
        {
            byte temp;
            ushort tile;
            Subtile source;
            int offset = 0;
            //
            for (int i = 0; i < dst.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset++];
                    source = Do.DrawSubtile(tile, temp, Graphics, Palettes.Palettes, 0x20);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset++];
                    source = Do.DrawSubtile(tile, temp, Graphics, Palettes.Palettes, 0x20);
                    dst[i].Subtiles[a] = source; ;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        /// <summary>
        /// Convert a tileset's Tile collection to binary format.
        /// </summary>
        /// <param name="src">The Tile collection to convert.</param>
        /// <param name="dst">The byte array to store the converted data to.</param>
        public void ParseTileset(Tile[] src, byte[] dst)
        {
            ushort tile;
            Subtile source;
            int offset = 0;
            for (int i = 0; i < src.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RefreshTileset()
        {
            ParseTileset(Tileset_bytes, Tileset_tiles);
        }

        #endregion
    }
}
