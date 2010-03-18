using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    public sealed class State
    {

        static State instance = null;
        static readonly object padlock = new object();

        // Initial settings
        private bool layer1 = true; public bool Layer1 { get { return layer1; } set { layer1 = value; } }
        private bool layer2 = true; public bool Layer2 { get { return layer2; } set { layer2 = value; } }
        private bool layer3 = true; public bool Layer3 { get { return layer3; } set { layer3 = value; } }
        private bool priority1 = false; public bool Priority1 { get { return priority1; } set { priority1 = value; } }
        private bool bg = true; public bool BG { get { return bg; } set { bg = value; } }
        private bool physicalLayer = false; public bool PhysicalLayer { get { return physicalLayer; } set { physicalLayer = value; } }
        private bool mask = false; public bool Mask { get { return mask; } set { mask = value; } }
        private bool objects = false; public bool Objects { get { return objects; } set { objects = value; } }
        private bool exits = false; public bool Exits { get { return exits; } set { exits = value; } }
        private bool events = false; public bool Events { get { return events; } set { events = value; } }
        private bool overlaps = false; public bool Overlaps { get { return overlaps; } set { overlaps = value; } }
        private bool cartesianGrid = false; public bool CartesianGrid { get { return cartesianGrid; } set { cartesianGrid = value; } }
        private bool orthographicGrid = false; public bool OrthographicGrid { get { return orthographicGrid; } set { orthographicGrid = value; } }
        private bool template = false; public bool Template { get { return template; } set { ClearDrawSelectErase(); template = value; } }
        private bool draw = false; public bool Draw { get { return draw; } set { ClearDrawSelectErase(); draw = value; } }
        private bool select = false; public bool Select { get { return select; } set { ClearDrawSelectErase(); select = value; } }
        private bool erase = false; public bool Erase { get { return erase; } set { ClearDrawSelectErase(); erase = value; } }
        private bool dropper = false; public bool Dropper { get { return dropper; } set { dropper = value; } }
        private bool move = false; public bool Move { get { return move; } set { move = value; } }
        private bool paste = false; public bool Paste { get { return paste; } set { paste = value; } }
        private bool autoPointerUpdate = true; public bool AutoPointerUpdate { get { return this.autoPointerUpdate; } set { this.autoPointerUpdate = value; } }
        private bool showEncryptionWarnings = true; public bool ShowEncryptionWarnings { get { return this.showEncryptionWarnings; } set { this.showEncryptionWarnings = value; } }
        private UniversalVariables universal; public UniversalVariables Universal { get { return this.universal; } set { this.universal = value; } }
        
        private byte[] privateKey = null;
        public byte[] PrivateKey
        {
            get
            {
                if (privateKey == null)
                    return null;
                byte[] temp = new byte[privateKey.Length];
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
        } // Encryption key storage
        State()
        {
            universal = new UniversalVariables();
        }
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
        private void ClearDrawSelectErase()
        {
            template = false;
            draw = false;
            select = false;
            erase = false;
            dropper = false;
            move = false;
        }
        public bool IsDrawingLayer(int layer)
        {
            switch (layer)
            {
                case 0:
                    return layer1;
                case 1:
                    return layer2;
                case 2:
                    return layer3;
                default:
                    return false;
            }
        }

    }
}
