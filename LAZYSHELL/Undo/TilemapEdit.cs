using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Undo
{
    class TilemapEdit : Edit
    {
        #region Variables

        private Areas.OwnerForm updater;
        private Point start, stop;
        private State state;
        private int[][] changes;
        private bool allLayers;
        private int layer;
        private bool pasting;
        private bool transparent;
        public Tilemap Tilemap { get; set; }
        public bool AutoRedo { get; set; }

        #endregion

        // Constructor
        public TilemapEdit(Areas.OwnerForm updater, Tilemap tilemap, int layer, Point start, Point stop,
            int[][] changes, bool pasting, bool transparent, bool allLayers)
        {
            if (updater != null)
                state = State.Instance;
            else
                state = State.Instance2;
            this.updater = updater;
            this.Tilemap = tilemap;
            this.allLayers = allLayers;
            if (start.Y < stop.Y)
            {
                this.start = start;
                this.stop = stop;
            }
            else if (start == stop && start.X <= stop.X)
            {
                this.start = start;
                this.stop = stop;
            }
            else if (stop.Y < start.Y)
            {
                this.start = stop;
                this.stop = start;
            }
            this.layer = layer;
            this.changes = new int[3][];
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

        // Execute
        public void Execute()
        {
            int deltaX = (stop.X / 16) - (start.X / 16);
            int deltaY = (stop.Y / 16) - (start.Y / 16);
            for (int y = 0; y < deltaY; y++)
            {
                for (int x = 0; x < deltaX; x++)
                {
                    int temp;
                    bool empty;
                    int tileX = start.X + (x * 16);
                    int tileY = start.Y + (y * 16);
                    if (allLayers)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (l == 2 && updater.Map.GraphicSetL3 == 0xFF)
                                break;
                            if (changes[l] == null)
                                continue;
                            temp = Tilemap.GetTileNum(l, tileX, tileY); // Save the current tileNum for later undo
                            empty = changes[l][x + y * deltaX] == 0;
                            if (temp != changes[l][x + y * deltaX])
                            {
                                Tilemap.SetTileNum(changes[l][x + y * deltaX], l, tileX, tileY); // Set the tile to the new tileNum
                                changes[l][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                            }
                            if (pasting && transparent && empty && state.Move)
                                Tilemap.SetTileNum(temp, l, tileX, tileY);
                        }
                    }
                    else
                    {
                        if (layer == 2 && updater.Map.GraphicSetL3 == 0xFF)
                            break;
                        if (changes[layer] == null)
                            continue;
                        temp = Tilemap.GetTileNum(layer, tileX, tileY); // Save the current tileNum for later undo
                        empty = changes[layer][x + y * deltaX] == 0;
                        if (temp != changes[layer][x + y * deltaX])
                        {
                            Tilemap.SetTileNum(changes[layer][x + y * deltaX], layer, tileX, tileY); // Set the tile to the new tileNum
                            changes[layer][x + y * deltaX] = temp; // Replace the change with the old tileNum, so that all we have to do is Execute to undo this command
                        }
                        if (pasting && transparent && empty && state.Move)
                            Tilemap.SetTileNum(temp, layer, tileX, tileY);
                    }
                }
            }
        }
    }
}
