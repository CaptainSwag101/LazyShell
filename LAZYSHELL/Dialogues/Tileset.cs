using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Dialogues
{
    [Serializable()]
    public class DialogueTileset
    {
        #region Variables

        [NonSerialized()]
        private byte[] graphics;
        private PaletteSet palettes;

        // Properties
        public Tile[] Tileset_tiles { get; set; }

        #endregion

        // Constructor
        public DialogueTileset(PaletteSet palettes)
        {
            this.palettes = palettes;
            //
            InitializeGraphics();
            InitializeTilesetTiles();
            BuildTilesetTiles(Tileset_tiles);
        }

        #region Methods

        private void InitializeGraphics()
        {
            this.graphics = Model.Graphics;
        }
        private void InitializeTilesetTiles()
        {
            Tileset_tiles = new Tile[16 * 4];
            for (int i = 0; i < Tileset_tiles.Length; i++)
                Tileset_tiles[i] = new Tile(i);
        }
        public void BuildTilesetTiles(Tile[] tileset_tiles)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        // for palette index 1
                        byte status = 0x04;
                        byte index = (byte)(y * 16 + (x * 2) + (z % 2));
                        index += z >= 2 ? (byte)8 : (byte)0;
                        Subtile source = Do.DrawSubtile(index, status, graphics, palettes.Palettes, 0x20);
                        tileset_tiles[y * 16 + x].Subtiles[z] = source;
                        tileset_tiles[y * 16 + x + 8].Subtiles[z] = source;
                        // for palette index 1
                        status = 0x44;
                        index ^= 7;
                        source = Do.DrawSubtile(index, status, graphics, palettes.Palettes, 0x20);
                        tileset_tiles[y * 16 + x + 4].Subtiles[z] = source;
                        tileset_tiles[y * 16 + x + 12].Subtiles[z] = source;
                    }
                }
            }
        }
        public void RedrawTileset()
        {
            InitializeGraphics();
            InitializeTilesetTiles();
            BuildTilesetTiles(Tileset_tiles);
        }

        #endregion
    }
}
