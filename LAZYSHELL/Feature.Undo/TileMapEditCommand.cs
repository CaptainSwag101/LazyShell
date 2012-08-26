using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Undo
{
    class TilemapEditCommand : Command
    {
        private Levels updater;
        private Tilemap tilemap;
        public Tilemap Tilemap { get { return tilemap; } set { tilemap = value; } }
        private Point topLeft, bottomRight;
        private State state;
        private int[][] changes = new int[3][];
        private bool allLayers;
        private int layer;
        private bool pasting;
        private bool transparent;
        private bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }
        public TilemapEditCommand(Levels updater, Tilemap tilemap, int layer, Point topLeft, Point bottomRight, int[][] changes, bool pasting, bool transparent, bool allLayers)
        {
            if (updater != null)
                state = State.Instance;
            else
                state = State.Instance2;
            this.updater = updater;
            this.tilemap = tilemap;
            this.allLayers = allLayers;
            if (topLeft.Y < bottomRight.Y)
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else if (topLeft == bottomRight && topLeft.X <= bottomRight.X)
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else if (bottomRight.Y < topLeft.Y)
            {
                this.topLeft = bottomRight;
                this.bottomRight = topLeft;
            }
            this.layer = layer;
            for (int i = 0; i < 3; i++)
            {
                if (changes[i] == null) continue;
                this.changes[i] = new int[changes[i].Length];
                changes[i].CopyTo(this.changes[i], 0);
            }
            this.pasting = pasting;
            this.transparent = transparent;
            Execute();
        }
        public void Execute()
        {
            int deltaX = (bottomRight.X / 16) - (topLeft.X / 16);
            int deltaY = (bottomRight.Y / 16) - (topLeft.Y / 16);
            int tileX, tileY, temp;
            bool empty;
            for (int y = 0; y < deltaY; y++)
            {
                for (int x = 0; x < deltaX; x++)
                {
                    tileX = topLeft.X + (x * 16);
                    tileY = topLeft.Y + (y * 16);
                    if (allLayers)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (l == 2 && updater.LevelMap.GraphicSetL3 == 0xFF)
                                break;
                            if (changes[l] == null) continue;
                            temp = tilemap.GetTileNum(l, tileX, tileY); // Save the current tileNum for later undo
                            empty = changes[l][x + y * deltaX] == 0;
                            if (temp != changes[l][x + y * deltaX])
                            {
                                tilemap.SetTileNum(changes[l][x + y * deltaX], l, tileX, tileY); // Set the tile to the new tileNum
                                changes[l][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                            }
                            if (pasting && transparent && empty && state.Move)
                                tilemap.SetTileNum(temp, l, tileX, tileY);
                        }
                    }
                    else
                    {
                        if (changes[layer] == null) continue;
                        temp = tilemap.GetTileNum(layer, tileX, tileY); // Save the current tileNum for later undo
                        empty = changes[layer][x + y * deltaX] == 0;
                        if (temp != changes[layer][x + y * deltaX])
                        {
                            tilemap.SetTileNum(changes[layer][x + y * deltaX], layer, tileX, tileY); // Set the tile to the new tileNum
                            changes[layer][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                        }
                        if (pasting && transparent && empty && state.Move)
                            tilemap.SetTileNum(temp, layer, tileX, tileY);
                    }
                }
            }
        }
    }
}
