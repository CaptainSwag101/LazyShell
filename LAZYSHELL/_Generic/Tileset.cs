using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LazyShell
{
    [Serializable()]
    public class Tileset
    {
        #region Variables

        private Areas.Map areaMap;
        private int tileSize;

        // Properties
        public int Width { get; set; }
        public int Height { get; set; }
        public int HeightL3 { get; set; }
        public TilesetType Type { get; set; }
        public PaletteSet PaletteSet { get; set; }

        // Properties
        public byte[] Tileset_bytes
        {
            get { return Tilesets_bytes[0]; }
            set { Tilesets_bytes[0] = value; }
        }
        public byte[][] Tilesets_bytes { get; set; }
        public byte[] Graphics { get; set; }
        public byte[] GraphicsL3 { get; set; }
        public Tile[] Tileset_tiles
        {
            get { return Tilesets_tiles[0]; }
            set { Tilesets_tiles[0] = value; }
        }
        public Tile[][] Tilesets_tiles { get; set; }

        // Mode7
        public byte[] Subtile_bytes { get; set; }
        public byte[] Palette_bytes { get; set; }

        #endregion

        #region Constructors

        // Default
        public Tileset(byte[] tileset_bytes, byte[] graphics, PaletteSet paletteSet, int width, int height, TilesetType type)
        {
            this.Type = type;
            this.Width = width;
            this.Height = height;
            this.tileSize = 2;
            //
            this.Graphics = graphics;
            this.PaletteSet = paletteSet;
            this.Tilesets_bytes = new byte[3][];
            this.Tilesets_bytes[0] = tileset_bytes;
            //
            InitializeTilesetTiles();
            BuildTilesetTiles();
        }
        // Area
        public Tileset(Areas.Map areaMap, PaletteSet paletteSet)
        {
            this.Type = TilesetType.Area;
            this.Width = 16;
            this.Height = 32;
            this.HeightL3 = 16;
            this.tileSize = 2;
            //
            this.areaMap = areaMap;
            this.PaletteSet = paletteSet;
            InitializeGraphics();
            InitializeTilesetBytes();
            InitializeTilesetTiles();
            BuildTilesetTiles();
        }
        // Title screen, Minecart M7
        public Tileset(PaletteSet paletteSet, TilesetType type)
        {
            this.Type = type;
            if (this.Type == TilesetType.Title)
            {
                this.Width = 16;
                this.Height = 32;
                this.HeightL3 = 6;
                this.tileSize = 2;
            }
            if (this.Type == TilesetType.Mode7)
            {
                this.Width = 16;
                this.Height = 16;
                this.tileSize = 1;
            }
            //
            this.PaletteSet = paletteSet;
            InitializeGraphics();
            InitializeTilesetBytes();
            InitializeTilesetTiles();
            BuildTilesetTiles();
        }

        #endregion

        #region Methods

        #region Tileset creation

        public void InitializeGraphics()
        {
            if (this.Type == TilesetType.Area)
            {
                Graphics = new byte[0x6000];
                Buffer.BlockCopy(Areas.Model.GraphicSets[areaMap.GraphicSet1 + 0x48], 0, Graphics, 0, 0x2000);
                Buffer.BlockCopy(Areas.Model.GraphicSets[areaMap.GraphicSet2 + 0x48], 0, Graphics, 0x2000, 0x1000);
                Buffer.BlockCopy(Areas.Model.GraphicSets[areaMap.GraphicSet3 + 0x48], 0, Graphics, 0x3000, 0x1000);
                Buffer.BlockCopy(Areas.Model.GraphicSets[areaMap.GraphicSet4 + 0x48], 0, Graphics, 0x4000, 0x1000);
                Buffer.BlockCopy(Areas.Model.GraphicSets[areaMap.GraphicSet5 + 0x48], 0, Graphics, 0x5000, 0x1000);
                if (areaMap.GraphicSetL3 != 0xFF)
                    GraphicsL3 = Areas.Model.GraphicSets[areaMap.GraphicSetL3];
            }
            else if (this.Type == TilesetType.Title)
            {
                Graphics = Bits.GetBytes(Intro.Model.Title_Data, 0x6C00, 0x4FE0);
                GraphicsL3 = Bits.GetBytes(Intro.Model.Title_Data, 0xBEA0, 0x1BC0);
            }
            else if (this.Type == TilesetType.Mode7)
            {
                Graphics = Minecart.Model.M7Graphics;
            }
        }
        private void InitializeTilesetBytes()
        {
            Tilesets_bytes = new byte[3][];
            if (this.Type == TilesetType.Area)
            {
                Tilesets_bytes[0] = Areas.Model.Tilesets[areaMap.TilesetL1 + 0x20];
                Tilesets_bytes[1] = Areas.Model.Tilesets[areaMap.TilesetL2 + 0x20];
                Tilesets_bytes[2] = Areas.Model.Tilesets[areaMap.TilesetL3];
            }
            else if (this.Type == TilesetType.Title)
            {
                Tilesets_bytes[0] = Bits.GetBytes(Intro.Model.Title_Data, 0x0000, 0x1000);
                Tilesets_bytes[1] = Bits.GetBytes(Intro.Model.Title_Data, 0x1000, 0x1000);
                Tilesets_bytes[2] = Bits.GetBytes(Intro.Model.Title_Data, 0xBBE0, 0x300);
            }
            else if (this.Type == TilesetType.Mode7)
            {
                Subtile_bytes = Minecart.Model.M7TilesetSubtiles;
                Palette_bytes = Minecart.Model.M7TilesetPalettes;
            }
        }
        private void InitializeTilesetBytes(int layer)
        {
            if (this.Type == TilesetType.Area)
            {
                if (layer == 0)
                    Tilesets_bytes[0] = Areas.Model.Tilesets[areaMap.TilesetL1 + 0x20];
                else if (layer == 1)
                    Tilesets_bytes[1] = Areas.Model.Tilesets[areaMap.TilesetL2 + 0x20];
                else if (layer == 2)
                    Tilesets_bytes[2] = Areas.Model.Tilesets[areaMap.TilesetL3];
            }
            else if (this.Type == TilesetType.Title)
            {
                if (layer == 0)
                    Tilesets_bytes[0] = Bits.GetBytes(Intro.Model.Title_Data, 0x0000, 0x1000);
                else if (layer == 1)
                    Tilesets_bytes[1] = Bits.GetBytes(Intro.Model.Title_Data, 0x1000, 0x1000);
                else if (layer == 2)
                    Tilesets_bytes[2] = Bits.GetBytes(Intro.Model.Title_Data, 0xBBE0, 0x300);
            }
            else if (this.Type == TilesetType.Mode7)
            {
                Subtile_bytes = Minecart.Model.M7TilesetSubtiles;
                Palette_bytes = Minecart.Model.M7TilesetPalettes;
            }
        }
        private void InitializeTilesetTiles()
        {
            Tilesets_tiles = new Tile[3][];
            if (this.Type == TilesetType.Area)
            {
                Tilesets_tiles[0] = new Tile[Width * Height];
                Tilesets_tiles[1] = new Tile[Width * Height];
                if (areaMap.GraphicSetL3 != 0xFF)
                    Tilesets_tiles[2] = new Tile[Width * HeightL3];
                for (int l = 0; l < 3; l++)
                {
                    if (Tilesets_tiles[l] == null)
                        continue;
                    for (int i = 0; i < Tilesets_tiles[l].Length; i++)
                        Tilesets_tiles[l][i] = new Tile(i);
                }
            }
            else if (this.Type == TilesetType.Title)
            {
                Tilesets_tiles[0] = new Tile[16 * 32];
                Tilesets_tiles[1] = new Tile[16 * 32];
                Tilesets_tiles[2] = new Tile[16 * 6];
                for (int i = 0; i < Tilesets_tiles[0].Length; i++)
                    Tilesets_tiles[0][i] = new Tile(i);
                for (int i = 0; i < Tilesets_tiles[1].Length; i++)
                    Tilesets_tiles[1][i] = new Tile(i);
                for (int i = 0; i < Tilesets_tiles[2].Length; i++)
                    Tilesets_tiles[2][i] = new Tile(i);
            }
            else
            {
                Tileset_tiles = new Tile[Width * Height];
                for (int i = 0; i < Tileset_tiles.Length; i++)
                    Tileset_tiles[i] = new Tile(i);
            }
        }
        private void InitializeTilesetTiles(int layer)
        {
            if (this.Type == TilesetType.Area)
            {
                if (layer == 0)
                    Tilesets_tiles[0] = new Tile[Width * Height];
                else if (layer == 1)
                    Tilesets_tiles[1] = new Tile[Width * Height];
                else if (layer == 2 && areaMap.GraphicSetL3 != 0xFF)
                    Tilesets_tiles[2] = new Tile[Width * HeightL3];
            }
            else if (this.Type == TilesetType.Title)
            {
                if (layer == 0)
                    Tilesets_tiles[0] = new Tile[16 * 32];
                else if (layer == 1)
                    Tilesets_tiles[1] = new Tile[16 * 32];
                else if (layer == 2)
                    Tilesets_tiles[2] = new Tile[16 * 6];
            }
            else
            {
                Tileset_tiles = new Tile[Width * Height];
            }
        }
        public void BuildTilesetTiles()
        {
            if (this.Type == TilesetType.Area)
            {
                BuildTilesetTiles(Tilesets_bytes[0], Tilesets_tiles[0], Graphics, 0x20);
                BuildTilesetTiles(Tilesets_bytes[1], Tilesets_tiles[1], Graphics, 0x20);
                if (areaMap.GraphicSetL3 != 0xFF)
                    BuildTilesetTiles(Tilesets_bytes[2], Tilesets_tiles[2], GraphicsL3, 0x10);
            }
            else if (this.Type == TilesetType.Title)
            {
                BuildTilesetTiles(Tilesets_bytes[0], Tilesets_tiles[0], Graphics, 0x20);
                BuildTilesetTiles(Tilesets_bytes[1], Tilesets_tiles[1], Graphics, 0x20);
                BuildTilesetTiles(Tilesets_bytes[2], Tilesets_tiles[2], GraphicsL3, 0x20);
            }
            else if (this.Type == TilesetType.Mode7)
            {
                BuildTilesetTiles(Subtile_bytes, Tileset_tiles, Graphics, 0x20);
            }
            else if (this.Type == TilesetType.Opening)
            {
                BuildTilesetTiles(Tileset_bytes, Tileset_tiles, Graphics, 0x10);
            }
            else
            {
                BuildTilesetTiles(Tileset_bytes, Tileset_tiles, Graphics, 0x20);
            }
        }
        public void BuildTilesetTiles(int layer)
        {
            if (this.Type == TilesetType.Area)
            {
                if (layer < 2)
                    BuildTilesetTiles(Tilesets_bytes[layer], Tilesets_tiles[layer], Graphics, 0x20);
                else if (areaMap.GraphicSetL3 != 0xFF)
                    BuildTilesetTiles(Tilesets_bytes[layer], Tilesets_tiles[layer], GraphicsL3, 0x10);
            }
            else if (this.Type == TilesetType.Title)
            {
                if (layer < 2)
                    BuildTilesetTiles(Tilesets_bytes[layer], Tilesets_tiles[layer], Graphics, 0x20);
                else
                    BuildTilesetTiles(Tilesets_bytes[layer], Tilesets_tiles[layer], GraphicsL3, 0x20);
            }
            else if (this.Type == TilesetType.Mode7)
            {
                BuildTilesetTiles(Subtile_bytes, Tileset_tiles, Graphics, 0x20);
            }
            else if (this.Type == TilesetType.Opening)
            {
                BuildTilesetTiles(Tileset_bytes, Tileset_tiles, Graphics, 0x10);
            }
            else
            {
                BuildTilesetTiles(Tileset_bytes, Tileset_tiles, Graphics, 0x20);
            }
        }
        /// <summary>
        /// Converts a tileset's binary data to a manageable tile collection.
        /// </summary>
        /// <param name="src">The tileset's binary data.</param>
        /// <param name="dst">The tile collection to write to from the binary data.</param>
        /// <param name="graphics">The graphics to use for creating the subtile pixels.</param>
        /// <param name="format">The size of a single subtile's graphics, 0x10 or 0x20.</param>
        public void BuildTilesetTiles(byte[] src, Tile[] dst, byte[] graphics, byte format)
        {
            int offset = 0;
            for (int i = 0; i < Width / 16; i++)
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = i * 16; x < i * 16 + 16; x++)
                    {
                        int index = y * Width + x;
                        if (index >= dst.Length)
                            continue;
                        dst[index] = new Tile(index);
                        for (int z = 0; z < 4; z++)
                        {
                            if (z == 2)
                                offset += this.tileSize * 30;
                            ushort tilenum = 0;
                            byte status = 0;
                            if (this.tileSize == 2)
                            {
                                tilenum = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                                status = src[offset++];
                            }
                            else
                            {
                                tilenum = src[offset++];
                                status = (byte)(Palette_bytes[tilenum] << 2);
                            }
                            var subtile = Do.DrawSubtile(tilenum, status, graphics, PaletteSet.Palettes, format);
                            dst[index].Subtiles[z] = subtile;
                        }
                        if (x < i * 16 + 15)
                            offset -= this.tileSize * 32;
                    }
                }
            }
        }

        #endregion

        #region Tileset modification

        /// <summary>
        /// Converts a tileset's tile collection into raw binary format.
        /// </summary>
        /// <param name="src">The tileset's tile collection.</param>
        /// <param name="dst">The binary data to write to from the tile collection.</param>
        public void ParseTileset(Tile[] src, byte[] dst)
        {
            int offset = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int index = y * Width + x;
                    if (index >= src.Length)
                        continue;
                    for (int z = 0; z < 4; z++)
                    {
                        if (z == 2)
                            offset += tileSize * 30;
                        var subtile = src[index].Subtiles[z];
                        if (tileSize == 2)
                        {
                            int tilenum = (ushort)subtile.Index;
                            Bits.SetShort(dst, offset, tilenum); offset++;
                            dst[offset] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(dst, offset, 5, subtile.Priority1);
                            Bits.SetBit(dst, offset, 6, subtile.Mirror);
                            Bits.SetBit(dst, offset, 7, subtile.Invert); offset++;
                        }
                        else if (this.Type == TilesetType.Mode7)
                        {
                            int tilenum = (byte)subtile.Index;
                            Subtile_bytes[offset++] = (byte)tilenum;
                            Palette_bytes[tilenum] = (byte)subtile.Palette;
                        }
                    }
                    if (x < 15)
                        offset -= tileSize * 32;
                }
            }
        }
        /// <summary>
        /// Reinitializes the tileset's source data and rebuilds the tile collections.
        /// </summary>
        public void RedrawTilesets()
        {
            InitializeTilesetBytes();
            InitializeTilesetTiles();
            BuildTilesetTiles();
        }
        /// <summary>
        /// Reinitializes the tileset's source data for a single layer and rebuilds its tile collection.
        /// </summary>
        /// <param name="layer">The layer to rebuild the tile collection for.</param>
        public void RedrawTilesets(int layer)
        {
            InitializeTilesetBytes(layer);
            InitializeTilesetTiles(layer);
            BuildTilesetTiles(layer);
        }
        public void Clear(int count)
        {
            if (Type == TilesetType.Area)
            {
                if (count == 1)
                {
                    Areas.Model.Tilesets[areaMap.TilesetL1 + 0x20] = new byte[0x2000];
                    Areas.Model.Tilesets[areaMap.TilesetL2 + 0x20] = new byte[0x2000];
                    Areas.Model.Tilesets[areaMap.TilesetL3] = new byte[0x1000];
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL1 + 0x20] = true;
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL2 + 0x20] = true;
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL3] = true;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (i < 0x20)
                            Areas.Model.Tilesets[i] = new byte[0x1000];
                        else
                            Areas.Model.Tilesets[i] = new byte[0x2000];
                        Areas.Model.Modify_Tilesets[i] = true;
                    }
                }
            }
            else if (Type == TilesetType.Mode7)
            {
                // Minecart tileset
                for (int i = 0; i < 0x400; i++)
                    Subtile_bytes[i] = Minecart.Model.M7TilesetSubtiles[i] = 0;
                for (int i = 0; i < 0x100; i++)
                    Palette_bytes[i] = Minecart.Model.M7TilesetPalettes[i] = 0;
            }
            //
            RedrawTilesets();
        }

        #endregion

        #region Write to model

        /// <summary>
        /// Writes this tileset's tile data of a specified layer to the elements in the global Model.
        /// NOTE: The ROM buffer is not modified during this operation.
        /// </summary>
        /// <param name="width">The width, in 16x16 tile units, of the tileset.</param>
        /// <param name="layer">The layer to read the tile data from.</param>
        public void WriteToModel(int width, int layer)
        {
            if (Tilesets_tiles[layer] == null)
                return;
            //
            int offset = 0;
            if (Type == TilesetType.Area || Type == TilesetType.Title)
            {
                for (int y = 0; y < Tilesets_tiles[layer].Length / width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int index = y * width + x;
                        if (index >= Tilesets_tiles[layer].Length)
                            continue;
                        Tile tile = Tilesets_tiles[layer][index];
                        for (int s = 0; s < 4; s++)
                        {
                            offset = y * (width * 8) + (x * 4);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 4);
                            Subtile subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(Tilesets_bytes[layer], offset, (ushort)subtile.Index);
                            Tilesets_bytes[layer][offset + 1] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(Tilesets_bytes[layer], offset + 1, 5, subtile.Priority1);
                            Bits.SetBit(Tilesets_bytes[layer], offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(Tilesets_bytes[layer], offset + 1, 7, subtile.Invert);
                        }
                    }
                }
                if (Type == TilesetType.Area)
                {
                    if (layer == 0)
                        Areas.Model.Modify_Tilesets[areaMap.TilesetL1 + 0x20] = true;
                    if (layer == 1)
                        Areas.Model.Modify_Tilesets[areaMap.TilesetL2 + 0x20] = true;
                    if (layer == 2)
                        Areas.Model.Modify_Tilesets[areaMap.TilesetL3] = true;
                    //
                    Buffer.BlockCopy(Graphics, 0, Areas.Model.GraphicSets[areaMap.GraphicSet1 + 0x48], 0, 0x2000);
                    Buffer.BlockCopy(Graphics, 0x2000, Areas.Model.GraphicSets[areaMap.GraphicSet2 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x3000, Areas.Model.GraphicSets[areaMap.GraphicSet3 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x4000, Areas.Model.GraphicSets[areaMap.GraphicSet4 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x5000, Areas.Model.GraphicSets[areaMap.GraphicSet5 + 0x48], 0, 0x1000);
                    //
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet1 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet2 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet3 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet4 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet5 + 0x48] = true;
                }
                else if (Type == TilesetType.Title)
                {
                    Buffer.BlockCopy(Tilesets_bytes[0], 0, Intro.Model.Title_Data, 0, 0x1000);
                    Buffer.BlockCopy(Tilesets_bytes[1], 0, Intro.Model.Title_Data, 0x1000, 0x1000);
                    Buffer.BlockCopy(Tilesets_bytes[2], 0, Intro.Model.Title_Data, 0xBBE0, 0x300);
                    Buffer.BlockCopy(Graphics, 0, Intro.Model.Title_Data, 0x6C00, 0x4FE0);
                    Buffer.BlockCopy(GraphicsL3, 0x40, Intro.Model.Title_Data, 0xBEE0, 0x1B80);
                }
            }
            else
                WriteToModel(width);
        }
        /// <summary>
        /// Writes this tileset's tile data to the elements in the global Model.
        /// NOTE: The ROM buffer is not modified during this operation.
        /// <param name="width">The width, in 16x16 tile units, of the tileset.</param>
        public void WriteToModel(int width)
        {
            int offset = 0;
            if (Type != TilesetType.Mode7)
            {
                for (int l = 0; l < Tilesets_tiles.Length; l++)
                {
                    if (Tilesets_tiles[l] == null) continue;
                    for (int y = 0; y < Tilesets_tiles[l].Length / width; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Tile tile = Tilesets_tiles[l][y * width + x];
                            for (int s = 0; s < 4; s++)
                            {
                                offset = y * (width * 8) + (x * 4);
                                offset += (s % 2) * 2;
                                offset += (s / 2) * (width * 4);
                                Subtile subtile = tile.Subtiles[s];
                                if (subtile == null) continue;
                                Bits.SetShort(Tilesets_bytes[l], offset, (ushort)subtile.Index);
                                Tilesets_bytes[l][offset + 1] |= (byte)(subtile.Palette << 2);
                                Bits.SetBit(Tilesets_bytes[l], offset + 1, 5, subtile.Priority1);
                                Bits.SetBit(Tilesets_bytes[l], offset + 1, 6, subtile.Mirror);
                                Bits.SetBit(Tilesets_bytes[l], offset + 1, 7, subtile.Invert);
                            }
                        }
                    }
                }
                if (Type == TilesetType.Area)
                {
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL1 + 0x20] = true;
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL2 + 0x20] = true;
                    Areas.Model.Modify_Tilesets[areaMap.TilesetL3] = true;
                    //
                    Buffer.BlockCopy(Graphics, 0, Areas.Model.GraphicSets[areaMap.GraphicSet1 + 0x48], 0, 0x2000);
                    Buffer.BlockCopy(Graphics, 0x2000, Areas.Model.GraphicSets[areaMap.GraphicSet2 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x3000, Areas.Model.GraphicSets[areaMap.GraphicSet3 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x4000, Areas.Model.GraphicSets[areaMap.GraphicSet4 + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(Graphics, 0x5000, Areas.Model.GraphicSets[areaMap.GraphicSet5 + 0x48], 0, 0x1000);
                    //
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet1 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet2 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet3 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet4 + 0x48] = true;
                    Areas.Model.Modify_GraphicSets[areaMap.GraphicSet5 + 0x48] = true;
                }
                else if (Type == TilesetType.SideScrolling)
                {
                    Buffer.BlockCopy(Graphics, 0, Minecart.Model.SSGraphics, 0, Graphics.Length);
                }
                else if (Type == TilesetType.Title)
                {
                    Buffer.BlockCopy(Tilesets_bytes[0], 0, Intro.Model.Title_Data, 0, 0x1000);
                    Buffer.BlockCopy(Tilesets_bytes[1], 0, Intro.Model.Title_Data, 0x1000, 0x1000);
                    Buffer.BlockCopy(Tilesets_bytes[2], 0, Intro.Model.Title_Data, 0xBBE0, 0x300);
                    Buffer.BlockCopy(Graphics, 0, Intro.Model.Title_Data, 0x6C00, 0x4FE0);
                    Buffer.BlockCopy(GraphicsL3, 0x40, Intro.Model.Title_Data, 0xBEE0, 0x1B80);
                }
                else if (Type == TilesetType.Opening)
                {
                    Buffer.BlockCopy(Tilesets_bytes[0], 0, Intro.Model.Cast_Data, 0, 0x480);
                    Buffer.BlockCopy(Graphics, 0, Intro.Model.Cast_Data, 0x480, 0x1340);
                }
            }
            else
            {
                if (Tileset_tiles == null)
                    return;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        int i = y * 16 + x;
                        for (int z = 0; z < 4; z++)
                        {
                            offset = y * (width * 4) + (x * 2);
                            offset += z % 2;
                            offset += (z / 2) * (width * 2);
                            Subtile subtile = Tileset_tiles[i].Subtiles[z];
                            byte tilenum = (byte)subtile.Index;
                            Subtile_bytes[offset] = tilenum;
                            Palette_bytes[tilenum] = (byte)subtile.Palette;
                        }
                    }
                }
                Buffer.BlockCopy(Graphics, 0, Minecart.Model.M7Graphics, 0, Graphics.Length);
            }
        }

        #endregion

        public int GetTileNum(int layer, int x, int y)
        {
            if (layer < 3)
                return Tilesets_tiles[layer][y * Width + x].Index;
            else return 0;
        }

        #endregion
    }
}
