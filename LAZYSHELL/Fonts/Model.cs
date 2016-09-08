using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Fonts
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LazyShell.Model.ROM; }
            set { LazyShell.Model.ROM = value; }
        }

        // Font tables
        private static Glyph[] dialogues;
        private static Glyph[] menu;
        private static Glyph[] description;
        private static Glyph[] triangle;
        private static Glyph[] battleMenu;
        private static Glyph[] flowerBonus;
        public static Glyph[] Dialogue
        {
            get
            {
                if (dialogues == null)
                {
                    dialogues = new Glyph[128];
                    for (int i = 0; i < dialogues.Length; i++)
                        dialogues[i] = new Glyph(i, FontType.Dialogue);
                }
                return dialogues;
            }
            set { dialogues = value; }
        }
        public static Glyph[] Menu
        {
            get
            {
                if (menu == null)
                {
                    menu = new Glyph[128];
                    for (int i = 0; i < menu.Length; i++)
                        menu[i] = new Glyph(i, FontType.Menu);
                }
                return menu;
            }
            set { menu = value; }
        }
        public static Glyph[] Description
        {
            get
            {
                if (description == null)
                {
                    description = new Glyph[128];
                    for (int i = 0; i < description.Length; i++)
                        description[i] = new Glyph(i, FontType.Description);
                }
                return description;
            }
            set { description = value; }
        }
        public static Glyph[] Triangle
        {
            get
            {
                if (triangle == null)
                {
                    triangle = new Glyph[14];
                    for (int i = 0; i < triangle.Length; i++)
                        triangle[i] = new Glyph(i, FontType.Triangles);
                }
                return triangle;
            }
            set { triangle = value; }
        }
        public static Glyph[] BattleMenu
        {
            get
            {
                if (battleMenu == null)
                {
                    battleMenu = new Glyph[64];
                    for (int i = 0; i < battleMenu.Length; i++)
                        battleMenu[i] = new Glyph(i, FontType.BattleMenu);
                }
                return battleMenu;
            }
            set { battleMenu = value; }
        }
        public static Glyph[] FlowerBonus
        {
            get
            {
                if (flowerBonus == null)
                {
                    flowerBonus = new Glyph[32];
                    for (int i = 0; i < flowerBonus.Length; i++)
                        flowerBonus[i] = new Glyph(i, FontType.FlowerBonus);
                }
                return flowerBonus;
            }
            set { flowerBonus = value; }
        }

        // Palettes
        private static PaletteSet palette_Dialogue;
        private static PaletteSet palette_Battle;
        private static PaletteSet palette_Menu;
        private static PaletteSet palette_BattleMenu;
        private static PaletteSet palette_Numerals;
        public static PaletteSet Palette_Dialogue
        {
            get
            {
                if (palette_Dialogue == null)
                    palette_Dialogue = new PaletteSet(ROM, 0, 0x3DFEE0, 2, 16, 32);
                return palette_Dialogue;
            }
            set { palette_Dialogue = value; }
        }
        public static PaletteSet Palette_Battle
        {
            get
            {
                if (palette_Battle == null)
                    palette_Battle = new PaletteSet(ROM, 0, 0x01EF40, 1, 16, 32);
                return palette_Battle;
            }
            set { palette_Battle = value; }
        }
        public static PaletteSet Palette_Menu
        {
            get
            {
                if (palette_Menu == null)
                    palette_Menu = new PaletteSet(Menus.Model.Menu_Palette_Bytes, 0, 0, 2, 16, 32);
                return palette_Menu;
            }
            set { palette_Menu = value; }
        }
        public static PaletteSet Palette_BattleMenu
        {
            get
            {
                if (palette_BattleMenu == null)
                    palette_BattleMenu = new PaletteSet(ROM, 0, 0x01EF20, 1, 16, 32);
                return palette_BattleMenu;
            }
            set { palette_BattleMenu = value; }
        }
        public static PaletteSet Palette_Numerals
        {
            get
            {
                if (palette_Numerals == null)
                    palette_Numerals = new PaletteSet(ROM, 0, 0x03FC00, 2, 16, 32);
                return palette_Numerals;
            }
            set { palette_Numerals = value; }
        }

        // Graphics
        private static byte[] graphics_numerals;
        private static byte[] graphics_battleMenu;
        private static byte[] graphics_bonus;
        public static byte[] Graphics_Numerals
        {
            get
            {
                if (graphics_numerals == null)
                    graphics_numerals = Bits.GetBytes(ROM, 0x03F800, 0x400);
                return graphics_numerals;
            }
            set { graphics_numerals = value; }
        }
        public static byte[] Graphics_BattleMenu
        {
            get
            {
                if (graphics_battleMenu == null)
                {
                    graphics_battleMenu = new byte[0x800];
                    Buffer.BlockCopy(ROM, 0x1F200, graphics_battleMenu, 0, 0x600);
                    Buffer.BlockCopy(ROM, 0x1ED00, graphics_battleMenu, 0x600, 0x140);
                }
                return graphics_battleMenu;
            }
            set { graphics_battleMenu = value; }
        }
        public static byte[] Graphics_Bonus
        {
            get
            {
                if (graphics_bonus == null)
                {
                    graphics_bonus = Bits.GetBytes(Sprites.Model.Sprites[520].Graphics, 0, 0x400);
                }
                return graphics_bonus;
            }
            set { graphics_bonus = value; }
        }

        #endregion

        #region Methods

        // Data management
        public static void ClearAll()
        {
            graphics_battleMenu = null;
            palette_BattleMenu = null;
            description = null;
            dialogues = null;
            menu = null;
            palette_Battle = null;
            palette_Dialogue = null;
            triangle = null;
            graphics_numerals = null;
            palette_Numerals = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Graphics_BattleMenu;
            dummy = Palette_BattleMenu;
            dummy = Description;
            dummy = Dialogue;
            dummy = Menu;
            dummy = Palette_Battle;
            dummy = Palette_Dialogue;
            dummy = Palette_Menu;
            dummy = Triangle;
            dummy = Graphics_Numerals;
            dummy = Palette_Numerals;
        }

        #endregion
    }
}
