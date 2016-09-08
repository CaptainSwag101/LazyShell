using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace LazyShell.Dialogues
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

        // Tileset
        private static byte[] graphics;
        private static byte[] tileset_bytes;
        private static Tileset tileset;
        private static Bitmap tilesetImage;
        public static byte[] Graphics
        {
            get
            {
                if (graphics == null)
                    graphics = Bits.GetBytes(ROM, 0x3DF000, 0x700);
                return graphics;
            }
            set { graphics = value; }
        }
        public static byte[] Tileset_bytes
        {
            get
            {
                if (tileset_bytes == null)
                    tileset_bytes = Bits.GetBytes(ROM, 0x015943, 0x100);
                return tileset_bytes;
            }
            set { tileset_bytes = value; }
        }
        public static Tileset Tileset
        {
            get
            {
                if (tileset == null)
                    tileset = new Tileset();
                return tileset;
            }
            set { tileset = value; }
        }
        public static Bitmap TilesetImage
        {
            get
            {
                if (tilesetImage == null)
                    tilesetImage = Do.PixelsToImage(
                        Do.TilesetToPixels(Tileset.Tileset_tiles,
                        16, 2, 0, false), 256, 32);
                return tilesetImage;
            }
            set
            {
                tilesetImage = value;
            }
        }

        // Elements
        private static DTE[] dte;
        private static Dialogue[] dialogues;
        private static BattleDialogue[] battleDialogues;
        private static BattleDialogue[] battleMessages;
        private static BonusMessage[] bonusMessages;
        public static DTE[] DTE
        {
            get
            {
                if (dte == null)
                {
                    // create dialogues
                    dte = new DTE[12];
                    for (int i = 0; i < dte.Length; i++)
                        dte[i] = new DTE(i);
                }
                return dte;
            }
            set { dte = value; }
        }
        public static Dialogue[] Dialogues
        {
            get
            {
                if (dialogues == null)
                {
                    // Set the charcode to read from table
                    ROM[0x6935] = 0xEF;
                    ROM[0x6937] = 0xEF;

                    // Create dialogues
                    dialogues = new Dialogue[4096];
                    for (int i = 0; i < dialogues.Length; i++)
                        dialogues[i] = new Dialogue(i);
                }
                return dialogues;
            }
            set { dialogues = value; }
        }
        public static BattleDialogue[] BattleDialogues
        {
            get
            {
                if (battleDialogues == null)
                {
                    battleDialogues = new BattleDialogue[256];
                    for (int i = 0; i < battleDialogues.Length; i++)
                        battleDialogues[i] = new BattleDialogue(i, 0x396554, 0x390000);
                }
                return battleDialogues;
            }
            set { battleDialogues = value; }
        }
        public static BattleDialogue[] BattleMessages
        {
            get
            {
                if (battleMessages == null)
                {
                    battleMessages = new BattleDialogue[46];
                    for (int i = 0; i < battleMessages.Length; i++)
                        battleMessages[i] = new BattleDialogue(i, 0x3A26F1, 0x3A0000);
                }
                return battleMessages;
            }
            set { battleMessages = value; }
        }
        public static BonusMessage[] BonusMessages
        {
            get
            {
                if (bonusMessages == null)
                {
                    bonusMessages = new BonusMessage[7];
                    for (int i = 0; i < bonusMessages.Length; i++)
                        bonusMessages[i] = new BonusMessage(i);
                }
                return bonusMessages;
            }
            set
            {
                bonusMessages = value;
            }
        }

        #endregion

        #region Methods

        // Calculate free bytes
        public static int FreeDTESpace()
        {
            int used = 0;
            for (int i = 0; i < dte.Length; i++)
                used += dte[i].Length + 1;
            return 0x40 - used;
        }
        public static int FreeDialogueSpace(int start)
        {
            int used = 0;
            int size = 0;
            int end = 0;
            if (start >= 3072)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                start = 3072;
                end = 4096;
            }
            else if (start >= 2048)
            {
                size = 0xF2D5;
                start = 2048;
                end = 3072;
            }
            else
            {
                size = 0xFD18;
                start = 0;
                end = 2048;
            }
            for (int i = start; i < end; i++)
            {
                used += FreeDialogueSpace(start, i);
            }

            // Finished
            return size - used;
        }
        private static int FreeDialogueSpace(int start, int index)
        {
            // First check if current dialogue can reference another or another's substring
            for (int i = start; i < index; i++)
            {
                // Write to ROM at offset of reference
                if (Bits.Compare(dialogues[index].Text, dialogues[i].Text))
                    return 0;
                else if (Bits.EndsWith(dialogues[i].Text, dialogues[index].Text))
                    return 0;
            }
            return dialogues[index].Length;
        }
        public static int FreeBattleDialogueSpace()
        {
            int used = 0;
            int size = (0x92D1 - 0x6754) + (0x2AA9 - 0x260A) + (0xBFFF - 0xBC58);
            for (int i = 0; i < Model.BattleDialogues.Length - 1; i++)
                used += Model.BattleDialogues[i].Length;
            return size - used;
        }
        public static int FreeBattleMessageSpace()
        {
            int used = 0;
            int size = (0x2A00 - 0x274D);
            for (int i = 0; i < Model.BattleMessages.Length; i++)
                used += Model.BattleMessages[i].Length;
            return size - used;
        }

        // Data retrieval
        public static Dialogue[] GetDialogues(int start, int end)
        {
            if (dialogues != null)
                return dialogues;
            // create dialogues
            var temp = new Dialogue[end - start];
            for (int i = start; i < end; i++)
                temp[i] = new Dialogue(i);
            return temp;
        }
        /// <summary>
        /// Converts the compression table to a string array.
        /// </summary>
        /// <param name="byteView">Indicates whether unparsed symbols will be displayed as
        /// byte values in hexadecimal or as descriptive text tags.</param>
        /// <returns></returns>
        public static string[] DTEStr(bool byteView)
        {
            string[] tables = new string[DTE.Length];
            for (int i = 0; i < tables.Length; i++)
                tables[i] = DTE[i].GetText(byteView);
            return tables;
        }

        // Data management
        public static void ClearAll()
        {
            // Dialogue
            battleDialogues = null;
            battleMessages = null;
            bonusMessages = null;
            graphics = null;
            dialogues = null;
            tileset = null;
            tilesetImage = null;
            dte = null;

            // Fonts
            Fonts.Model.Description = null;
            Fonts.Model.Dialogue = null;
            Fonts.Model.Menu = null;
            Fonts.Model.Triangle = null;
            Fonts.Model.Palette_Battle = null;
            Fonts.Model.Palette_Dialogue = null;
            Fonts.Model.Palette_Menu = null;
            Fonts.Model.Graphics_Numerals = null;
            Fonts.Model.Palette_Numerals = null;
            Fonts.Model.Graphics_BattleMenu = null;
            Fonts.Model.Palette_BattleMenu = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = BattleDialogues;
            dummy = BattleMessages;
            dummy = BonusMessages;
            dummy = Graphics;
            dummy = Dialogues;
            dummy = Tileset;
            dummy = TilesetImage;
        }

        #endregion
    }
}
