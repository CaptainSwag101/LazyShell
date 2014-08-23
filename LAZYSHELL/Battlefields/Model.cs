using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Battlefields
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        // Compressed data
        private static byte[][] tilesets = new byte[64][];
        public static byte[][] Tilesets
        {
            get
            {
                if (tilesets[0] == null)
                    Comp.Decompress(tilesets, 0x150000, 0x160000, 0x2000, "BATTLEFIELD TILE SET", true);
                return tilesets;
            }
            set { tilesets = value; }
        }

        // Modification flags
        public static bool[] EditTilesets = new bool[64];

        // Elements
        private static Battlefield[] battlefields;
        private static PaletteSet[] paletteSets;
        public static Battlefield[] Battlefields
        {
            get
            {
                if (battlefields == null)
                {
                    battlefields = new Battlefield[64];
                    for (int i = 0; i < battlefields.Length; i++)
                        battlefields[i] = new Battlefield(i);
                }
                return battlefields;
            }
            set { battlefields = value; }
        }
        public static PaletteSet[] PaletteSets
        {
            get
            {
                if (paletteSets == null)
                {
                    paletteSets = new PaletteSet[57];
                    for (int i = 0; i < paletteSets.Length; i++)
                        paletteSets[i] = new PaletteSet(ROM, i, (i * 0xB6) + 0x34CFC4, 8, 16, 30);
                }
                return paletteSets;
            }
            set { paletteSets = value; }
        }

        #endregion

        #region Methods

        // IO elements
        public static void ExportBattlefield(int index, string fullPath)
        {

            var battlefield = battlefields[index];
                var serialized = new Serialized(Tilesets[battlefield.Tileset],
                    paletteSets[battlefield.PaletteSet], battlefield);
                Do.Export(serialized, null, fullPath);


        }
        public static void ExportBattlefields(string fullPath)
        {

            var battlefields = Battlefields;
                var serialized = new Serialized[battlefields.Length];
                PaletteSet[] paletteSets = PaletteSets;
                for (int i = 0; i < battlefields.Length; i++)
                {
                    serialized[i] = new Serialized(Tilesets[battlefields[i].Tileset],
                        paletteSets[battlefields[i++].PaletteSet], battlefields[i]);
                }
                Do.Export(serialized,
                    fullPath + "\\" + LAZYSHELL.Model.GetFileNameWithoutPath() + " - Battlefields\\" + "battlefield",
                    "BATTLEFIELD", true);

        }
        public static bool ImportBattlefield(int index, string fullPath)
        {
            var battlefield = new Battlefields.Serialized();
            try
            {
                battlefield = (Battlefields.Serialized)Do.Import(battlefield, fullPath);
            }
            catch
            {
                MessageBox.Show("File not a battlefield data file.", 
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            Tilesets[battlefields[index].Tileset] = battlefield.Tileset;
            battlefields[index].GraphicSetA = battlefield.GraphicSetA;
            battlefields[index].GraphicSetB = battlefield.GraphicSetB;
            battlefields[index].GraphicSetC = battlefield.GraphicSetC;
            battlefields[index].GraphicSetD = battlefield.GraphicSetD;
            battlefields[index].GraphicSetE = battlefield.GraphicSetE;
            PaletteSets[battlefields[index].PaletteSet] = battlefield.PaletteSet;
            battlefields[index].Index = index;
            //
            return true;
        }
        public static bool ImportBattlefields(string fullPath)
        {
            var battlefield = new Battlefields.Serialized[battlefields.Length];
            for (int i = 0; i < battlefield.Length; i++)
                battlefield[i] = new Battlefields.Serialized();
            try
            {
                Do.Import(battlefield, fullPath + "\\" + "battlefield", "BATTLEFIELD", true);
            }
            catch
            {
                MessageBox.Show("One or more files not a battlefield data file.", 
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            for (int i = 0; i < battlefield.Length; i++)
            {
                Tilesets[battlefields[i].Tileset] = battlefield[i].Tileset;
                battlefields[i].GraphicSetA = battlefield[i].GraphicSetA;
                battlefields[i].GraphicSetB = battlefield[i].GraphicSetB;
                battlefields[i].GraphicSetC = battlefield[i].GraphicSetC;
                battlefields[i].GraphicSetD = battlefield[i].GraphicSetD;
                battlefields[i].GraphicSetE = battlefield[i].GraphicSetE;
                PaletteSets[battlefields[i].PaletteSet] = battlefield[i].PaletteSet;
                battlefields[i].Index = i;
            }
            return true;
        }

        // Model management
        public static void ClearAll()
        {
            battlefields = null;
            paletteSets = null;
            tilesets[0] = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = PaletteSets;
            dummy = Battlefields;
            dummy = Tilesets[0];
        }

        #endregion
    }
}
