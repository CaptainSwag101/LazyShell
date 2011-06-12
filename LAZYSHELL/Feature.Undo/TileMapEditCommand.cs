using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Undo
{
    class TileMapEditCommand : Command
    {
        private Levels updater;
        private TileMap tileMap;
        public TileMap Tilemap { get { return tileMap; } set { tileMap = value; } }
        private Point topLeft, bottomRight;
        private State state = State.Instance;
        private int[][] changes = new int[3][];
        private bool allLayers;
        private int layer;
        private bool pasting;
        private bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }
        public TileMapEditCommand(Levels updater, TileMap tileMap, int layer, Point topLeft, Point bottomRight, int[][] changes, bool pasting, bool allLayers)
        {
            this.updater = updater;
            this.tileMap = tileMap;
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
                        for (int i = 0; i < 3; i++)
                        {
                            if (i == 2 && updater.LevelMap.GraphicSetL3 == 0xFF)
                                break;
                            if (changes[i] == null) continue;
                            temp = tileMap.GetTileNum(i, tileX, tileY); // Save the current tileNum for later undo

                            empty = changes[i][x + y * deltaX] == 0;
                            if (temp != changes[i][x + y * deltaX])
                            {
                                tileMap.MakeEdit(changes[i][x + y * deltaX], i, tileX, tileY); // Set the tile to the new tileNum
                                changes[i][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                            }
                            if (pasting && empty && state.Move)
                                tileMap.MakeEdit(temp, i, tileX, tileY);
                        }
                    }
                    else
                    {
                        if (changes[layer] == null) continue;
                        temp = tileMap.GetTileNum(layer, tileX, tileY); // Save the current tileNum for later undo
                        empty = changes[layer][x + y * deltaX] == 0;
                        if (temp != changes[layer][x + y * deltaX])
                        {
                            tileMap.MakeEdit(changes[layer][x + y * deltaX], layer, tileX, tileY); // Set the tile to the new tileNum
                            changes[layer][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                        }
                        if (pasting && empty && state.Move)
                            tileMap.MakeEdit(temp, layer, tileX, tileY);
                    }
                }
            }
        }
    }
}
