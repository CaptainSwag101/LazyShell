using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Battlefields
{
    [Serializable()]
    public class Serialized
    {
        #region Variables

        // Properties
        public Battlefield Battlefield { get; set; }
        public byte[] Tileset { get; set; }
        public byte GraphicSetA { get; set; }
        public byte GraphicSetB { get; set; }
        public byte GraphicSetC { get; set; }
        public byte GraphicSetD { get; set; }
        public byte GraphicSetE { get; set; }
        public PaletteSet PaletteSet { get; set; }

        #endregion

        // Constructors
        public Serialized(byte[] tileset, PaletteSet paletteSet, Battlefield battlefield)
        {
            this.Tileset = tileset;
            this.PaletteSet = paletteSet;
            this.Battlefield = battlefield;
            this.GraphicSetA = battlefield.GraphicSetA;
            this.GraphicSetB = battlefield.GraphicSetB;
            this.GraphicSetC = battlefield.GraphicSetC;
            this.GraphicSetD = battlefield.GraphicSetD;
            this.GraphicSetE = battlefield.GraphicSetE;
        }
        public Serialized()
        {
        }
    }
}
