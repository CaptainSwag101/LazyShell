using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMRPGED
{
    public class PhysicalMap
    {
        private Model model;
        private LevelModel levelModel;
        private LevelMap levelMap; public LevelMap Levelmap { get { return levelMap; } }
        private PhysicalTile[] physicalTiles;

        //private int physicalMapOffset;
        private int[] tileNumAssn = new int[1024 * 1024];

        private int[] physicalMapPixels = new int[1024 * 1024];
        private Bitmap physicalMapImage; public Bitmap PhysicalMapImage { get { return physicalMapImage; } set { physicalMapImage = value; } }

        private byte[] physicalMap; public byte[] ThePhysicalMap { get { return physicalMap; } set { physicalMap = value; } }

        private int[] qBaseOrig = new int[16 * 8];
        private int[] qBlockOrig = new int[16 * 24];
        private int[] hqBlockOrig = new int[16 * 16];
        private int[] stULLoOrig = new int[16 * 24];
        private int[] stULHiOrig = new int[16 * 24];
        private int[] stURLoOrig = new int[16 * 24];
        private int[] stURHiOrig = new int[16 * 24];

        // A tile number is assigned to each pixel (used to display the tile # in the label)
        private int[] orthTileNum = new int[1024 * 1024]; public int[] OrthTileNum { get { return orthTileNum; } set { orthTileNum = value; } }

        // An orthographic coord for both X and Y is assigned to each pixel (used to display the Orth X and Y coords in the label)
        private int[] orthCoordsX = new int[1024 * 1024]; public int[] OrthCoordsX { get { return orthCoordsX; } set { orthCoordsX = value; } }
        private int[] orthCoordsY = new int[1024 * 1024]; public int[] OrthCoordsY { get { return orthCoordsY; } set { orthCoordsY = value; } }

        // A pixel is assigned to each tile number (used for selecting an orthographic tile)
        private int[] orthTilePosX = new int[4194]; public int[] OrthTilePosX { get { return orthTilePosX; } set { orthTilePosX = value; } }
        private int[] orthTilePosY = new int[4194]; public int[] OrthTilePosY { get { return orthTilePosY; } set { orthTilePosY = value; } }

        public PhysicalMap(
            LevelMap levelMap,
            Model model,
            int[] qBaseOrig,
            int[] qBlockOrig,
            int[] hqBlockOrig,
            int[] stULLoOrig,
            int[] stULHiOrig,
            int[] stURLoOrig,
            int[] stURHiOrig)
        {
            this.model = model;
            this.levelMap = levelMap;
            this.qBaseOrig = qBaseOrig;
            this.qBlockOrig = qBlockOrig;
            this.hqBlockOrig = hqBlockOrig;
            this.stULLoOrig = stULLoOrig;
            this.stULHiOrig = stULHiOrig;
            this.stURLoOrig = stURLoOrig;
            this.stURHiOrig = stURHiOrig;

            levelModel = model.LevelModel;
            physicalTiles = levelModel.PhysicalTiles;

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

                tileNum = BitManager.GetShort(physicalMap, offset); offset += 2;
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
                tileNum = BitManager.GetShort(physicalMap, offset);
                currTilePosX = orthTilePosX[offset / 2];
                currTilePosY = orthTilePosY[offset / 2];

                if (tileNum != 0)
                {
                    //tilePixels = physicalTiles[tileNum].PhysicalTilePixels;
                    tilePixels = physicalTiles[tileNum].DrawPhysicalTile(qBaseOrig, qBlockOrig, hqBlockOrig, stULLoOrig, stULHiOrig, stURLoOrig, stURHiOrig);

                    for (int a = 752 - physicalTiles[tileNum].PhysicalTileTotalHeight; a < 784; a++)
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

            physicalMapImage = new Bitmap(DrawImageFromIntArr(physicalMapPixels, 1024, 1024));
        }

        public void SetOrthographic()
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
                    orthTilePosX[tileOffset] = xPixel;
                    orthTilePosY[tileOffset] = yPixel;

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
                    orthTilePosX[tileOffset] = xPixel;
                    orthTilePosY[tileOffset] = yPixel;

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
                currTilePosX = orthTilePosX[offset / 2];
                currTilePosY = orthTilePosY[offset / 2];
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
                        orthTileNum[temp] == 0)
                        orthTileNum[temp] = offset / 2;
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
                        orthTileNum[temp] == 0)
                        orthTileNum[temp] = offset / 2;
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
                        orthCoordsX[temp] = orthX;
                        orthCoordsY[temp] = orthY;
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
                        orthCoordsX[temp] = orthX;
                        orthCoordsY[temp] = orthY;
                    }
                }

                leftEdge += 2;
                rightEdge -= 2;
            }
        }
        public void MakeEdit()
        {
            //BitManager.SetShort(physicalMap, currentPhysTileNum * 2, setIt);

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
                    tileNum = BitManager.GetShort(physicalMap, offset);
                    currTilePosX = orthTilePosX[offset / 2];
                    currTilePosY = orthTilePosY[offset / 2];

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(qBaseOrig, qBlockOrig, hqBlockOrig, stULLoOrig, stULHiOrig, stURLoOrig, stURHiOrig);

                        for (int a = 752 - physicalTiles[tileNum].PhysicalTileTotalHeight; a < 784; a++)
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
                                if (orthTileNum[b * 1024 + a] == offset / 2)
                                    physicalMapPixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 2;

                    if (offset >= physicalMap.Length) break;

                    // ...draw western half of right tile
                    tileNum = BitManager.GetShort(physicalMap, offset);
                    currTilePosX = orthTilePosX[offset / 2];
                    currTilePosY = orthTilePosY[offset / 2];

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(qBaseOrig, qBlockOrig, hqBlockOrig, stULLoOrig, stULHiOrig, stURLoOrig, stURHiOrig);

                        for (int a = 752 - physicalTiles[tileNum].PhysicalTileTotalHeight; a < 784; a++)
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
                                if (orthTileNum[b * 1024 + a] == offset / 2)
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
                    tileNum = BitManager.GetShort(physicalMap, offset);
                    currTilePosX = orthTilePosX[offset / 2];
                    currTilePosY = orthTilePosY[offset / 2];

                    if (tileNum != 0)
                    {
                        tilePixels = physicalTiles[tileNum].DrawPhysicalTile(qBaseOrig, qBlockOrig, hqBlockOrig, stULLoOrig, stULHiOrig, stURLoOrig, stURHiOrig);

                        for (int a = 752 - physicalTiles[tileNum].PhysicalTileTotalHeight; a < 784; a++)
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
                                if (orthTileNum[b * 1024 + a] == offset / 2)
                                    physicalMapPixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 64;

                    if (offset >= physicalMap.Length) break;
                }
                twoTiles = !twoTiles;
            }

            physicalMapImage = new Bitmap(DrawImageFromIntArr(physicalMapPixels, 1024, 1024));
        }
        public ushort GetTileNum(int physTileNum)
        {
            return BitManager.GetShort(physicalMap, physTileNum * 2);
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

        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;
            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }
            return image;
        }
    }
}
