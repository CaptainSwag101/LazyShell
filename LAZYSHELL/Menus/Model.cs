using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Menus
{
    public static class Model
    {
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        #region Status and shop menus

        // Compressed data
        private static byte[] menu_bg_graphics;
        private static byte[] menu_bg_tileset_bytes;
        private static byte[] unk3E2C80_tileset_bytes;
        private static byte[] menu_frame_graphics;
        private static byte[] menu_cursor_graphics;
        private static byte[] menu_palette_bytes;
        public static byte[] Menu_BG_Graphics
        {
            get
            {
                if (menu_bg_graphics == null)
                    menu_bg_graphics = Comp.Decompress(ROM, 0x3E0002, 0x3E0000, 0x2000);
                return menu_bg_graphics;
            }
            set { menu_bg_graphics = value; }
        }
        public static byte[] Menu_Frame_Graphics
        {
            get
            {
                if (menu_frame_graphics == null)
                    menu_frame_graphics = Comp.Decompress(ROM, 0x3E0004, 0x3E0000, 0x200);
                return menu_frame_graphics;
            }
            set { menu_frame_graphics = value; }
        }
        public static byte[] Menu_Cursor_Graphics
        {
            get
            {
                if (menu_cursor_graphics == null)
                    menu_cursor_graphics = Comp.Decompress(ROM, 0x3E0006, 0x3E0000, 0x400);
                return menu_cursor_graphics;
            }
            set { menu_cursor_graphics = value; }
        }
        public static byte[] Menu_BG_Tileset_Bytes
        {
            get
            {
                if (menu_bg_tileset_bytes == null)
                    menu_bg_tileset_bytes = Comp.Decompress(ROM, 0x3E0008, 0x3E0000, 0x800);
                return menu_bg_tileset_bytes;
            }
            set { menu_bg_tileset_bytes = value; }
        }
        public static byte[] UNK3E2C80_Tileset_Bytes
        {
            get
            {
                if (unk3E2C80_tileset_bytes == null)
                    unk3E2C80_tileset_bytes = Comp.Decompress(ROM, 0x3E000A, 0x3E0000, 0x800);
                return unk3E2C80_tileset_bytes;
            }
            set { unk3E2C80_tileset_bytes = value; }
        }
        public static byte[] Menu_Palette_Bytes
        {
            get
            {
                if (menu_palette_bytes == null)
                    menu_palette_bytes = Comp.Decompress(ROM, 0x3E000C, 0x3E0000, 0x200);
                return menu_palette_bytes;
            }
            set { menu_palette_bytes = value; }
        }

        // Modification flags
        public static bool Modify_MenuTileset;
        private static MenuText[] menu_texts;
        public static MenuText[] Menu_Texts
        {
            get
            {
                if (menu_texts == null)
                {
                    menu_texts = new MenuText[118];
                    for (int i = 0; i < menu_texts.Length; i++)
                        menu_texts[i] = new MenuText(i);
                }
                return menu_texts;
            }
            set { menu_texts = value; }
        }

        // Palettes
        private static PaletteSet menu_cursor_paletteSet;
        private static PaletteSet menu_bg_paletteSet;
        private static PaletteSet shop_bg_paletteSet;
        public static PaletteSet Menu_BG_PaletteSet
        {
            get
            {
                if (menu_bg_paletteSet == null)
                    menu_bg_paletteSet = new PaletteSet(ROM, 0, 0x3E9A28, 1, 16, 32);
                return menu_bg_paletteSet;
            }
            set { menu_bg_paletteSet = value; }
        }
        public static PaletteSet Shop_BG_PaletteSet
        {
            get
            {
                if (shop_bg_paletteSet == null)
                    shop_bg_paletteSet = new PaletteSet(ROM, 0, 0x3E9A05, 1, 16, 32);
                return shop_bg_paletteSet;
            }
            set { shop_bg_paletteSet = value; }
        }
        public static PaletteSet Menu_Cursor_PaletteSet
        {
            get
            {
                if (menu_cursor_paletteSet == null)
                    menu_cursor_paletteSet = new PaletteSet(Menu_Palette_Bytes, 8, 0x100, 1, 16, 32);
                return menu_cursor_paletteSet;
            }
            set { menu_cursor_paletteSet = value; }
        }

        // Bitmaps
        private static Bitmap menuBG;
        private static Bitmap shopBG;
        private static Bitmap gameBG;
        public static Bitmap MenuBG_256x256
        {
            get
            {
                if (menuBG == null)
                    menuBG = Do.PixelsToImage(
                        Do.TilesetToPixels(
                        new Tileset(Menu_BG_PaletteSet, Menu_BG_Tileset_Bytes, Menu_BG_Graphics).Tileset_tiles, 16, 16, 0, false), 256, 256);
                return menuBG;
            }
            set { menuBG = value; }
        }
        public static Bitmap ShopBG
        {
            get
            {
                if (shopBG == null)
                {
                    var tileset = new Tileset(Shop_BG_PaletteSet, Menu_BG_Tileset_Bytes, Menu_BG_Graphics);
                    int[] pixels = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 0, false);
                    shopBG = Do.PixelsToImage(pixels, 256, 256);
                }
                return shopBG;
            }
            set { shopBG = value; }
        }
        public static Bitmap GameBG
        {
            get
            {
                if (gameBG == null)
                    gameBG = Do.PixelsToImage(
                        Do.TilesetToPixels(
                        new Tileset(GameSelect_BGPaletteSet, Menu_BG_Tileset_Bytes, Menu_BG_Graphics).Tileset_tiles, 16, 16, 0, false), 256, 256);
                return gameBG;
            }
            set { gameBG = value; }
        }
        public static Bitmap MenuBG_256x255
        {
            get
            {
                return MenuBG_256x256.Clone(new Rectangle(0, 0, 256, 255), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public static Bitmap MenuBG(int width, int height)
        {
            if (width > 256) width = 256;
            if (height > 256) height = 256;
            return MenuBG_256x256.Clone(new Rectangle(0, 0, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        #endregion

        #region Game select menus

        private static byte[] gameSelect_graphics;
        private static byte[] gameSelect_palette_bytes;
        private static PaletteSet gameSelect_paletteSet;
        public static PaletteSet gameSelect_bgPaletteSet;
        private static byte[] gameSelect_tileset_bytes;
        private static byte[] gameSelect_speakers_graphics;
        public static byte[] GameSelect_Graphics
        {
            get
            {
                if (gameSelect_graphics == null)
                    gameSelect_graphics = Comp.Decompress(ROM, 0x3E9A4A, 0x2000);
                return gameSelect_graphics;
            }
            set { gameSelect_graphics = value; }
        }
        public static byte[] GameSelect_Palette_Bytes
        {
            get
            {
                if (gameSelect_palette_bytes == null)
                    gameSelect_palette_bytes = Comp.Decompress(ROM, 0x3EB510, 0x200);
                return gameSelect_palette_bytes;
            }
            set { gameSelect_palette_bytes = value; }
        }
        public static byte[] GameSelect_Tileset_Bytes
        {
            get
            {
                if (gameSelect_tileset_bytes == null)
                    gameSelect_tileset_bytes = Comp.Decompress(ROM, 0x3EB2CE, 0x800);
                return gameSelect_tileset_bytes;
            }
            set { gameSelect_tileset_bytes = value; }
        }
        public static PaletteSet GameSelect_PaletteSet
        {
            get
            {
                if (gameSelect_paletteSet == null)
                    gameSelect_paletteSet = new PaletteSet(GameSelect_Palette_Bytes, 0, 0, 16, 16, 32);
                return gameSelect_paletteSet;
            }
            set { gameSelect_paletteSet = value; }
        }
        public static PaletteSet GameSelect_BGPaletteSet
        {
            get
            {
                if (gameSelect_bgPaletteSet == null)
                    gameSelect_bgPaletteSet = new PaletteSet(ROM, 0, 0x3E99E2, 1, 16, 32);
                return gameSelect_bgPaletteSet;
            }
            set { gameSelect_bgPaletteSet = value; }
        }
        public static byte[] GameSelect_Speakers_Graphics
        {
            get
            {
                if (gameSelect_speakers_graphics == null)
                    gameSelect_speakers_graphics = Comp.Decompress(ROM, 0x3EB625, 0x600);
                return gameSelect_speakers_graphics;
            }
            set { gameSelect_speakers_graphics = value; }
        }

        // Cursors
        private static CursorSprite[] cursorSprites;
        public static CursorSprite[] CursorSprites
        {
            get
            {
                if (cursorSprites == null)
                {
                    cursorSprites = new CursorSprite[5];
                    for (int i = 0; i < cursorSprites.Length; i++)
                        cursorSprites[i] = new CursorSprite(i);
                }
                return cursorSprites;
            }
            set { cursorSprites = value; }
        }

        #endregion

        #region Methods

        // Free space calculation
        public static int FreeMenuTextSpace()
        {
            int used = 0;
            MenuText lastMenuText = null;
            foreach (var text in Model.Menu_Texts)
            {
                if (lastMenuText != null && text.Length != 0 && Bits.Compare(text.Text, lastMenuText.Text))
                    continue;
                lastMenuText = text;
                used += text.Length + 1;
            }
            return 0x700 - used;
        }

        // Data management
        public static void ClearAll()
        {
            menu_cursor_paletteSet = null;
            gameSelect_graphics = null;
            gameSelect_palette_bytes = null;
            gameSelect_paletteSet = null;
            gameSelect_speakers_graphics = null;
            gameSelect_tileset_bytes = null;
            menuBG = null;
            menu_bg_paletteSet = null;
            shop_bg_paletteSet = null;
            menu_frame_graphics = null;
            menu_bg_graphics = null;
            menu_bg_tileset_bytes = null;
            menu_palette_bytes = null;
            menu_texts = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = GameSelect_Graphics;
            dummy = GameSelect_Palette_Bytes;
            dummy = GameSelect_PaletteSet;
            dummy = GameSelect_Speakers_Graphics;
            dummy = GameSelect_Tileset_Bytes;
            dummy = MenuBG_256x256;
            dummy = Menu_BG_PaletteSet;
            dummy = Shop_BG_PaletteSet;
            dummy = Menu_Frame_Graphics;
            dummy = Menu_BG_Graphics;
            dummy = Menu_BG_Tileset_Bytes;
            dummy = Menu_Cursor_Graphics;
            dummy = Menu_Texts;
        }

        #endregion
    }

    [Serializable()]
    public class CursorSprite
    {
        #region Variables

        private int index;
        public int Sprite;
        public int Sequence;

        #endregion

        // Constructor
        public CursorSprite(int index)
        {
            this.index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            switch (index)
            {
                case 0:
                    Sprite = Bits.GetShort(Model.ROM, 0x034757);
                    Sequence = Bits.GetShort(Model.ROM, 0x03475C);
                    break;
                case 1:
                    Sprite = Bits.GetShort(Model.ROM, 0x03489A);
                    Sequence = Bits.GetShort(Model.ROM, 0x03489F);
                    break;
                case 2:
                    Sprite = Bits.GetShort(Model.ROM, 0x034EE7);
                    Sequence = Bits.GetShort(Model.ROM, 0x034EEC);
                    break;
                case 3:
                    Sprite = Bits.GetShort(Model.ROM, 0x0340AA);
                    Sequence = Bits.GetShort(Model.ROM, 0x0340AF);
                    break;
                case 4:
                    Sprite = Bits.GetShort(Model.ROM, 0x03501E);
                    Sequence = Bits.GetShort(Model.ROM, 0x035021);
                    break;
            }
        }
        public void WriteToROM()
        {
            switch (index)
            {
                case 0:
                    Bits.SetShort(Model.ROM, 0x034757, Sprite);
                    Bits.SetShort(Model.ROM, 0x03475C, Sequence);
                    break;
                case 1:
                    Bits.SetShort(Model.ROM, 0x03489A, Sprite);
                    Bits.SetShort(Model.ROM, 0x03489F, Sequence);
                    break;
                case 2:
                    Bits.SetShort(Model.ROM, 0x034EE7, Sprite);
                    Bits.SetShort(Model.ROM, 0x034EEC, Sequence);
                    break;
                case 3:
                    Bits.SetShort(Model.ROM, 0x0340AA, Sprite);
                    Bits.SetShort(Model.ROM, 0x0340AF, Sequence);
                    break;
                case 4:
                    Bits.SetShort(Model.ROM, 0x03501E, Sprite);
                    Bits.SetShort(Model.ROM, 0x035021, Sequence);
                    break;
            }
        }

        #endregion
    }
}
