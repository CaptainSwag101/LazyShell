using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    /// <summary>
    /// Class for accessing the current state of a drawing area's overlay.
    /// </summary>
    public sealed class State
    {
        #region Variables

        // Security
        private static readonly object padlock = new object();
        private byte[] privateKey = null;
        public byte[] PrivateKey
        {
            get
            {
                if (privateKey == null)
                    return null;
                var temp = new byte[privateKey.Length];
                for (int i = 0; i < privateKey.Length; i++)
                    temp[i] = privateKey[i];
                return temp;
            }
            set
            {
                if (value == null)
                {
                    this.privateKey = null;
                    return;
                }
                this.privateKey = new byte[value.Length];
                for (int i = 0; i < value.Length; i++)
                    privateKey[i] = value[i];
            }
        }

        // Tilemap
        public bool Layer1 { get; set; }
        public bool Layer2 { get; set; }
        public bool Layer3 { get; set; }
        public bool BG { get; set; }
        public bool Priority1 { get; set; }
        public bool CollisionMap { get; set; }
        public bool Mask { get; set; }
        public bool NPCs { get; set; }
        public bool Exits { get; set; }
        public bool Events { get; set; }
        public bool Overlaps { get; set; }
        public bool Mushrooms { get; set; }
        public bool Rails { get; set; }
        public bool TileSwitches { get; set; }
        public bool CollisionSwitches { get; set; }
        public bool TileGrid { get; set; }
        public bool IsometricGrid { get; set; }

        // Draw mode
        private bool draw;
        private bool select;
        private bool erase;
        private bool dropper;
        private bool fill;
        private bool chunk;
        public bool Draw
        {
            get { return draw; }
            set
            {
                ClearDrawing();
                draw = value;
            }
        }
        public bool Select
        {
            get { return select; }
            set
            {
                ClearDrawing();
                select = value;
            }
        }
        public bool Erase
        {
            get { return erase; }
            set
            {
                ClearDrawing();
                erase = value;
            }
        }
        public bool Dropper
        {
            get { return dropper; }
            set
            {
                ClearDrawing();
                dropper = value;
            }
        }
        public bool Fill
        {
            get { return fill; }
            set
            {
                ClearDrawing();
                fill = value;
            }
        }
        public bool Chunk
        {
            get { return chunk; }
            set
            {
                ClearDrawing();
                chunk = value;
            }
        }
        public bool Move { get; set; }
        public bool Paste { get; set; }

        // Miscellaneous
        public bool AutoPointerUpdate { get; set; }
        public bool ShowEncryptionWarnings { get; set; }
        public bool ShowBoundaries { get; set; }

        #endregion

        // Constructor
        State()
        {
            Layer1 = true;
            Layer2 = true;
            Layer3 = true;
            BG = true;
            AutoPointerUpdate = true;
            ShowEncryptionWarnings = true;
        }

        #region Instance

        // Instance
        static State instance = null;
        static State instance2 = null;
        public static State Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new State();
                    }
                    return instance;
                }
            }
        }
        public static State Instance2
        {
            get
            {
                lock (padlock)
                {
                    if (instance2 == null)
                    {
                        instance2 = new State();
                    }
                    return instance2;
                }
            }
        }

        #endregion

        // Methods
        public void ClearDrawing()
        {
            chunk = false;
            draw = false;
            select = false;
            erase = false;
            dropper = false;
            fill = false;
            Move = false;
        }
    }
}
