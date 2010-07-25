using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    public class PhysicalMap
    {
        private Model model;
        private LevelMap levelMap; public LevelMap Levelmap { get { return levelMap; } }
        private PhysicalTile[] physicalTiles;

        //private int physicalMapOffset;
        private int[] tileNumAssn = new int[1024 * 1024];

        private int[] physicalMapPixels = new int[1024 * 1024];
        private Bitmap physicalMapImage; public Bitmap PhysicalMapImage { get { return physicalMapImage; } set { physicalMapImage = value; } }

        private byte[] physicalMap; public byte[] ThePhysicalMap { get { return physicalMap; } set { physicalMap = value; } }

        private SolidTilePixels solids;

        private int[] pixelTiles = new int[1024 * 1024];
        /// <summary>
        /// A tile number is assigned to each pixel (used to display the tile # in the label).
        /// </summary> 
        public int[] PixelTiles { get { return pixelTiles; } set { pixelTiles = value; } }
        private Point[] pixelCoords = new Point[1024 * 1024];
        /// <summary>
        /// An orthographic coord for both X and Y is assigned to each pixel (used to display the Orth X and Y coords in the label).
        /// </summary>
        public Point[] PixelCoords { get { return pixelCoords; } set { pixelCoords = value; } }
        private Point[] tileCoords = new Point[4194];
        /// <summary>
        /// A pixel is assigned to each tile number (used for selecting an orthographic tile).
        /// </summary>
        public Point[] TileCoords { get { return tileCoords; } set { tileCoords = value; } }

        public PhysicalMap(LevelMap levelMap, Model model, SolidTilePixels solids)
        {
            this.model = model;
            this.levelMap = levelMap;
            this.solids = solids;

            physicalTiles = model.PhysicalTiles;

            DecompressLevelData();
            FillGrid();
        }

        private void DecompressLevelData()
        {
            physicalMap = model.PhysicalMaps[levelMap.PhysicalMap];
        }

        private void FillGrid()
        {
            int offset = 0;
            ushort tileNum;

            ushort[] mapPhys = new ushort[physicalMap.Length / 2];
            for (int i = 0; i < physicalMap.Length / 2; i++)
            {

                tileNum = Bits.GetShort(physicalMap, offset); offset += 2;
                mapPhys[i] = tileNum;

            }
        }

        public void DrawPhysicalMap()
        {
            /*********DRAW THE PHYSICAL MAP FROM BUFFER*********/
            physicalMapPixels = new int[1024 * 1024];
            int[] tilePixels = new int[32 * 784];
            ushort tileNum;
            int currTilePosX = 0;
            int currTilePosY = 0;
            int offset = 0;
            int xPixel = 0;
            int yPixel = 0;
            while (offset < physicalMap.Length)
            {
                tileNum = Bits.GetShort(physicalMap, offset);
                currTilePosX = tileCoords[offset / 2].X;
                currTilePosY = tileCoords[offset / 2].Y;

                if (tileNum != 0)
                {
                    //tilePixels = physicalTiles[tileNum].PhysicalTilePixels;
                    tilePixels = physicalTiles[tileNum].DrawPhysicalTile(solids);

                    for (int a = 752 - physicalTiles[tileNum].TotalHeight; a < 784; a++)
                    {
                        for (int b = 0; b < 32; b++)
                        {
                            xPixel = currTilePosX + b;
                            yPixel = currTilePosY + a - 768;

                            if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                            {
                                if (tilePixels[b + (a * 32)] != 0)
                                {
                                    physicalMapPixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    tileNumAssn[xPixel + (yPixel * 1024)] = offset / 2;
                                }
                            }
                        }
                    }
                }
                offset += 2;
            }
            physicalMapImage = new Bitmap(Do.PixelsToImage(physicalMapPixels, 1024, 1024));
        }

        public void SetIsometric()
        {
            /*********ASSIGN AN INITIAL TOP-LEFT PIXEL X,Y COORD TO EACH TILE NUMBER*********/
            int tileOffset = 0;
            int counter = 0;
            int xPixel = 0;
            int yPixel = 0;

            // Do the odd rows
            for (int y = 0; y < 65; y++)
            {
                for (int x = 0; x < 33; x++)
                {
                    xPixel = (x * 32) - 16;
                    yPixel = (y * 16) - 8;
                    tileCoords[tileOffset].X = xPixel;
                    tileCoords[tileOffset].Y = yPixel;

                    tileOffset++;
                }
                counter += 65;
                tileOffset = counter;
            }

            // Do the even rows
            tileOffset = 33;
            counter = 0;
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    xPixel = (x * 32);
                    yPixel = (y * 16);
                    tileCoords[tileOffset].X = xPixel;
                    tileCoords[tileOffset].Y = yPixel;

                    tileOffset++;
                }
                counter += 65;
                tileOffset = counter + 33;
            }

            int currTilePosX = 0;
            int currTilePosY = 0;
            int offset = 0;

            /*********ASSIGN EACH PIXEL (1024 * 1024) A TILE NUMBER*********/
            while (offset < 0x20C2)
            {
                currTilePosX = tileCoords[offset / 2].X;
                currTilePosY = tileCoords[offset / 2].Y;
                GetOrthTileNum(offset, currTilePosX, currTilePosY);
                offset += 2;
            }

            /*********ASSIGN EACH PIXEL (1024 * 1024) X,Y ORTHOGRAPHIC COORDS*********/
            int[] orthCoord = new int[32 * 128];
            int[] orthCoordX = new int[32];
            int[] orthCoordY = new int[128];

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    orthCoordX[x] = (((x & 127) * 32) + (16 * (y & 1))) - 16;
                    orthCoordY[y] = (y * 8) - 8;
                    GetOrthCoords(x, y, orthCoordX[x], orthCoordY[y]);
                }
            }
        }
        private void GetOrthTileNum(int offset, int currTilePosX, int currTilePosY)
        {
            int leftEdge = 14;
            int rightEdge = 18;
            int temp = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) &&
                        (x + currTilePosX) < 1024 &&
                        (x + currTilePosX) >= 0 &&
                        pixelTiles[temp] == 0)
                        pixelTiles[temp] = offset / 2;
                }

                leftEdge -= 2;
                rightEdge += 2;
            }

            leftEdge = 0;
            rightEdge = 32;

            for (int y = 8; y < 16; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) &&
                        (x + currTilePosX) < 1024 &&
                        (x + currTilePosX) >= 0 &&
                        pixelTiles[temp] == 0)
                        pixelTiles[temp] = offset / 2;
                }

                leftEdge += 2;
                rightEdge -= 2;
            }
        }
        private void GetOrthCoords(int orthX, int orthY, int currTilePosX, int currTilePosY)
        {
            int leftEdge = 14;
            int rightEdge = 18;
            int temp = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) && (x + currTilePosX) < 1024 && (x + currTilePosX) >= 0)
                    {
                        pixelCoords[temp].X = orthX;
                        pixelCoords[temp].Y = orthY;
                    }
                }

                leftEdge -= 2;
                rightEdge += 2;
            }

            leftEdge = 0;
            rightEdge = 32;

            for (int y = 8; y < 16; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) && (x + currTilePosX) < 1024 && (x + currTilePosX) >= 0)
                    {
                        pixelCoords[temp].X = orthX;
                        pixelCoords[temp].Y = orthY;
                    }
                }

                leftEdge += 2;
                rightEdge -= 2;
            }
        }
        public void MakeEdit()
        {
            //Bits.SetShort(physicalMap, currentPhysTileNum * 2, setIt);

            model.EditPhysicalMaps[levelMap.PhysicalMap] = true;
        }
        public void RedrawPhysicalTile(int offset)
        {
            int[] tilePixels = new int[32 * 784];
            ushort tileNum;
            int currTilePosX = 0;
            int currTilePosY = 0;
            int xPixel = 0;
            int yPixel = 0;

            bool twoTiles = false;
            // initialize offset based on column of tile to change
            offset /= 2;
            offset = offset % 65;
            // determine if we start with two or one tile
            if (offset >= 33 && offset <= 64)
            {
                offset -= 33;
                twoTiles = true;
            }
            offset *= 2;
            // do the loop
            while (offset < physicalMap.Length)
            {
                if (twoTiles)
                {
                    // ...draw eastern half of left tile
                    tileNum = Bits.GetShort(physicalMap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(solids);

                        for (int a = 752 - physicalTiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 16; b < 32; b++)    // b = 16, ie. start at eastern half
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        physicalMapPixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0) + 16; a < Math.Min(Math.Max(currTilePosX, 0) + 32, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    physicalMapPixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 2;

                    if (offset >= physicalMap.Length) break;

                    // ...draw western half of right tile
                    tileNum = Bits.GetShort(physicalMap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(solids);

                        for (int a = 752 - physicalTiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 0; b < 16; b++)    // b < 16, ie. stop when western half done drawing
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        physicalMapPixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0); a < Math.Min(Math.Max(currTilePosX, 0) + 16, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    physicalMapPixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 64;

                    if (offset >= physicalMap.Length) break;
                }
                else
                {
                    // ...draw full tile
                    tileNum = Bits.GetShort(physicalMap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(solids);

                        for (int a = 752 - physicalTiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 0; b < 32; b++)
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        physicalMapPixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0); a < Math.Min(Math.Max(currTilePosX, 0) + 32, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    physicalMapPixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 64;

                    if (offset >= physicalMap.Length) break;
                }
                twoTiles = !twoTiles;
            }

            physicalMapImage = new Bitmap(Do.PixelsToImage(physicalMapPixels, 1024, 1024));
        }
        public ushort GetTileNum(int physTileNum)
        {
            return Bits.GetShort(physicalMap, physTileNum * 2);
        }

        public void Clear(int count)
        {
            if (count == 1)
            {
                model.PhysicalMaps[levelMap.PhysicalMap] = physicalMap = new byte[0x20C2];
                model.EditPhysicalMaps[levelMap.PhysicalMap] = true;
            }
            else
            {
                physicalMap = new byte[0x20C2];
                for (int i = 0; i < count; i++)
                {
                    model.PhysicalMaps[i] = new byte[0x20C2];
                    model.EditPhysicalMaps[i] = true;
                }
            }
        }

        public int[] GetRangePixels(int x, int y, int width, int height)
        {
            int[] pixels = new int[width * height];
            return pixels;
        }
        public int[] GetRangePixels(Point location, Size size)
        {
            return GetRangePixels(location.X, location.Y, size.Width, size.Height);
        }
    }
}
