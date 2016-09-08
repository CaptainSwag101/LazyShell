using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Sprites
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

        // Elements
        private static Sprite[] sprites;
        private static ImagePacket[] imagePackets;
        private static Animation[] animations;
        private static PaletteSet[] paletteSets;
        private static byte[] graphics;
        public static Sprite[] Sprites
        {
            get
            {
                if (sprites == null)
                {
                    sprites = new Sprite[1024];
                    for (int i = 0; i < sprites.Length; i++)
                        sprites[i] = new Sprite(i);
                }
                return sprites;
            }
            set { sprites = value; }
        }
        public static ImagePacket[] ImagePackets
        {
            get
            {
                if (imagePackets == null)
                {
                    imagePackets = new ImagePacket[512];
                    for (int i = 0; i < imagePackets.Length; i++)
                        imagePackets[i] = new ImagePacket(i);
                }
                return imagePackets;
            }
            set { imagePackets = value; }
        }
        public static Animation[] Animations
        {
            get
            {
                if (animations == null)
                {
                    animations = new Animation[444];
                    for (int i = 0; i < animations.Length; i++)
                        animations[i] = new Animation(i);
                }
                return animations;
            }
            set { animations = value; }
        }
        public static PaletteSet[] PaletteSets
        {
            get
            {
                if (paletteSets == null)
                {
                    paletteSets = new PaletteSet[819];
                    for (int i = 0; i < paletteSets.Length; i++)
                        paletteSets[i] = new PaletteSet(ROM, i, 0x252FFE + (i * 30), 1, 16, 30);
                }
                return paletteSets;
            }
            set { paletteSets = value; }
        }
        public static byte[] Graphics
        {
            get
            {
                if (graphics == null)
                    graphics = Bits.GetBytes(ROM, 0x280000, 0xB4000);
                return graphics;
            }
            set { graphics = value; }
        }

        // NPC packets
        private static NPCPacket[] npcPackets;
        public static NPCPacket[] NPCPackets
        {
            get
            {
                if (npcPackets == null)
                {
                    npcPackets = new NPCPacket[80];
                    for (int i = 0; i < npcPackets.Length; i++)
                        npcPackets[i] = new NPCPacket(i);
                }
                return npcPackets;
            }
            set { npcPackets = value; }
        }

        #endregion

        #region Methods

        // Free space
        public static int FreeAnimationBytes(int animationPacket)
        {
            int totalSize, min, max;
            int length = 0;
            if (animationPacket < 42)
            {
                totalSize = 0x7000; min = 0; max = 42;
            }
            else if (animationPacket < 107)
            {
                totalSize = 0xFFFF; min = 42; max = 107;
            }
            else if (animationPacket < 249)
            {
                totalSize = 0xFFFF; min = 107; max = 249;
            }
            else
            {
                totalSize = 0xFFFF; min = 249; max = 444;
            }
            for (int i = min; i < max; i++)
                length += animations[i].Buffer.Length;
            return totalSize - length;
        }

        // Data management
        public static void ClearAll()
        {
            animations = null;
            imagePackets = null;
            graphics = null;
            paletteSets = null;
            sprites = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Animations;
            dummy = ImagePackets;
            dummy = Graphics;
            dummy = PaletteSets;
            dummy = Sprites;
        }

        #endregion
    }
}
