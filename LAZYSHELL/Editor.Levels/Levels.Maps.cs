using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        private LevelMap[] levelMaps; public LevelMap[] LevelMaps { get { return levelMaps; } }
        private LevelMap levelMap; public LevelMap LevelMap { get { return levelMap; } }

        private PaletteSet[] paletteSets;
        private PaletteSet paletteSet; public PaletteSet PaletteSet { get { return paletteSet; } }

        private TileMap tileMap; public TileMap TileMap { get { return tileMap; } }
        private TileSet tileSet; public TileSet TileSet { get { return tileSet; } }

        private LevelSolidMap physicalMap; public LevelSolidMap PhysicalMap { get { return physicalMap; } }
        #endregion
        #region Methods

        private void InitializeMapProperties()
        {
            updatingProperties = true;

            levelMap = levelMaps[level.LevelMap];
            paletteSet = paletteSets[levelMaps[level.LevelMap].PaletteSet];

            this.mapNum.Value = level.LevelMap;

            this.mapGFXSet1Num.Value = levelMap.GraphicSetA;
            this.mapGFXSet1Name.SelectedIndex = levelMap.GraphicSetA;
            this.mapGFXSet2Num.Value = levelMap.GraphicSetB;
            this.mapGFXSet2Name.SelectedIndex = levelMap.GraphicSetB;
            this.mapGFXSet3Num.Value = levelMap.GraphicSetC;
            this.mapGFXSet3Name.SelectedIndex = levelMap.GraphicSetC;
            this.mapGFXSet4Num.Value = levelMap.GraphicSetD;
            this.mapGFXSet4Name.SelectedIndex = levelMap.GraphicSetD;
            this.mapGFXSet5Num.Value = levelMap.GraphicSetE;
            this.mapGFXSet5Name.SelectedIndex = levelMap.GraphicSetE;
            if (levelMap.GraphicSetL3 > 0x1b)
            {
                this.mapGFXSetL3Num.Value = 0x1c;
                this.mapGFXSetL3Name.SelectedIndex = 0x1c;
            }
            else
            {
                this.mapGFXSetL3Num.Value = levelMap.GraphicSetL3;
                this.mapGFXSetL3Name.SelectedIndex = levelMap.GraphicSetL3;
            }
            this.mapTilesetL1Num.Value = levelMap.TileSetL1;
            this.mapTilesetL1Name.SelectedIndex = levelMap.TileSetL1;
            this.mapTilesetL2Num.Value = levelMap.TileSetL2;
            this.mapTilesetL2Name.SelectedIndex = levelMap.TileSetL2;
            this.mapTilesetL3Num.Value = levelMap.TileSetL3;
            this.mapTilesetL3Name.SelectedIndex = levelMap.TileSetL3;

            this.mapTilemapL1Num.Value = levelMap.TileMapL1;
            this.mapTilemapL1Name.SelectedIndex = levelMap.TileMapL1;
            this.mapTilemapL2Num.Value = levelMap.TileMapL2;
            this.mapTilemapL2Name.SelectedIndex = levelMap.TileMapL2;
            this.mapTilemapL3Num.Value = levelMap.TileMapL3;
            this.mapTilemapL3Name.SelectedIndex = levelMap.TileMapL3;
            this.mapPhysicalMapNum.Value = levelMap.PhysicalMap;
            this.mapPhysicalMapName.SelectedIndex = levelMap.PhysicalMap;
            this.mapBattlefieldNum.Value = levelMap.Battlefield;
            this.mapBattlefieldName.SelectedIndex = levelMap.Battlefield;

            if (levelMap.GraphicSetL3 > 0x1b)
            {
                this.mapTilesetL3Num.Enabled = false;
                this.mapTilesetL3Name.Enabled = false;
                this.mapTilemapL3Num.Enabled = false;
                this.mapTilemapL3Name.Enabled = false;
            }
            else
            {
                this.mapTilesetL3Num.Enabled = true;
                this.mapTilesetL3Name.Enabled = true;
                this.mapTilemapL3Num.Enabled = true;
                this.mapTilemapL3Name.Enabled = true;
            }

            this.mapSetL3Priority.Checked = levelMap.TopPriorityL3;

            this.mapPaletteSetNum.Value = levelMap.PaletteSet;
            this.mapPaletteSetName.SelectedIndex = levelMap.PaletteSet;

            updatingProperties = false;

        }

        // set images
        private Image SetPaletteOverlay(Size s, Size u, int index)  // s = palette dimen, u = color dimen
        {
            Point p = new Point();
            int colspan = s.Width / u.Width;
            int color;

            p.X = index % colspan * u.Width;
            p.Y = index / colspan * u.Height;

            int[] pixels = new int[s.Width * s.Height];
            for (int x = p.X; x < p.X + u.Width - 1; x++)
            {
                color = x % 2 == 0 ? Color.White.ToArgb() : Color.Black.ToArgb();
                pixels[p.Y * s.Width + x] = color;
                pixels[(p.Y + u.Height - 2) * s.Width + x] = color;
                color = x % 2 == 0 ? Color.Black.ToArgb() : Color.White.ToArgb();
                pixels[(p.Y + 1) * s.Width + x] = color;
                pixels[(p.Y + u.Height - 3) * s.Width + x] = color;
            }
            for (int y = p.Y; y < p.Y + u.Height - 1; y++)
            {
                color = y % 2 == 0 ? Color.White.ToArgb() : Color.Black.ToArgb();
                pixels[y * s.Width + p.X] = color;
                pixels[y * s.Width + u.Width - 2 + p.X] = color;
                color = y % 2 == 0 ? Color.Black.ToArgb() : Color.White.ToArgb();
                pixels[y * s.Width + 1 + p.X] = color;
                pixels[y * s.Width + u.Width - 3 + p.X] = color;
            }
            return Do.PixelsToImage(pixels, s.Width, s.Height);
        }

        private void RecompressLevelData()
        {
            progressBar = new ProgressBar(model.Data, "COMPRESSING AND SAVING LEVEL DATA...", 890); // + whatever else
            progressBar.Show();

            int bank, index, size, bankIndex, temp;
            ushort offset;
            byte[] compressed = new byte[0x2000];
            byte[] data = model.Data;

            #region Graphic Sets
            // GRAPHIC SETS //

            // store original
            bank = 0x0A0000; // Set bank pointer
            byte[][] original = new byte[model.GraphicSets.Length][];
            temp = Bits.GetShort(model.Data, 0x0A0000);
            for (int i = 0, a = 0; i < 272; i++)
            {
                a = i * 2;
                for (int b = 0x0A0000; b < 0x150000; b += 0x010000)
                {
                    temp = Bits.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(model.Data, bank))
                {
                    if (bank < 0x140000)
                    {
                        size = 0x10000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x6000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0x5FFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(model.Data, bank + a + 2) - Bits.GetShort(model.Data, bank + a);

                original[i] = Bits.GetByteArray(model.Data, bank + Bits.GetShort(model.Data, bank + a), size);
            }

            // Graphic Sets - bank 0x0A

            bank = 0x0A0000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x009C; // Set initial offset for this bank

            for (; index < 78; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0A Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0A Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0A GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0B
            bank = 0x0B0000;
            index = 78; // To 163
            bankIndex = 0;
            offset = 0x20;

            for (; index < 94; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0B Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0B Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0B GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0C
            bank = 0x0C0000;
            index = 94; // To 163
            bankIndex = 0;
            offset = 0x22;

            for (; index < 111; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0C Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0C Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0C GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0D
            bank = 0x0D0000;
            index = 111; // To 163
            bankIndex = 0;
            offset = 0x24;

            for (; index < 129; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0D Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0D Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0D GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0E
            bank = 0x0E0000;
            index = 129; // To 163
            bankIndex = 0;
            offset = 0x24;

            for (; index < 147; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0E Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0E Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0E GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0F
            bank = 0x0F0000;
            index = 147; // To 163
            bankIndex = 0;
            offset = 0x28;

            for (; index < 167; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0F Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0F Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x0F GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x10
            bank = 0x100000;
            index = 167; // To 163
            bankIndex = 0;
            offset = 0x22;

            for (; index < 184; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x10 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x10 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x10 GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x11
            bank = 0x110000;
            index = 184; // To 163
            bankIndex = 0;
            offset = 0x28;

            for (; index < 204; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x11 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x11 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x11 GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x12
            bank = 0x120000;
            index = 204; // To 163
            bankIndex = 0;
            offset = 0x40;

            for (; index < 236; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x12 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x12 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x12 GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x13
            bank = 0x130000;
            index = 236; // To 163
            bankIndex = 0;
            offset = 0x32;

            for (; index < 261; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x13 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x13 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x13 GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x14
            bank = 0x140000;
            index = 261; // To 163
            bankIndex = 0;
            offset = 0x16;

            for (; index < 272; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = Comp.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0x5FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x14 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x5FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x14 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x14 GRAPHIC SET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x6000 - offset]);
            #endregion

            tileMap.AssembleIntoModel();

            #region Tile Maps
            // TILEMAPS //

            // Bank 0x16 - 109 tilemaps Pointers 160000 - 1600D9 ENDS AT 16FFFF
            // store original
            bank = 0x160000; // Set bank pointer
            original = new byte[model.TileMaps.Length][];
            temp = Bits.GetShort(model.Data, 0x160000);
            for (int i = 0, a = 0; i < 309; i++)
            {
                a = i * 2;
                for (int b = 0x160000; b < 0x1B0000; b += 0x010000)
                {
                    temp = Bits.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(model.Data, bank))
                {
                    if (bank < 0x1A0000)
                    {
                        size = 0x10000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x8000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0x7FFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(model.Data, bank + a + 2) - Bits.GetShort(model.Data, bank + a);

                original[i] = Bits.GetByteArray(model.Data, bank + Bits.GetShort(model.Data, bank + a), size);
            }

            compressed = new byte[0x2000];
            bank = 0x160000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x00DA; // Set initial offset for this bank
            size = 0;

            for (; index < 109; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = Comp.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x16 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x16 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x16 TILEMAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x17 - 54 tilemaps Pointers 170000 - 17006B ENDS AT 17FFFF
            bank = 0x170000;
            index = 109; // To 163
            bankIndex = 0;
            offset = 0x6C;
            size = 0;

            for (; index < 163; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = Comp.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x17 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x17 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x17 TILEMAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x18 - 56 tilemaps Pointers 180000 - 18006F ENDS AT 18FFFF
            bank = 0x180000;
            index = 163; // To 219
            bankIndex = 0;
            offset = 0x70;
            size = 0;

            for (; index < 219; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = Comp.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x18 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x18 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x18 TILEMAP #" + index.ToString("d3"));

            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x19 - 56 tilemaps Pointers 190000 - 19006F ENDS AT 19FFFF
            bank = 0x190000;
            index = 219; // To 275
            bankIndex = 0;
            offset = 0x70;
            size = 0;

            for (; index < 275; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = Comp.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x19 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x19 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x19 TILEMAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x1A - 34 tilemaps Pointers 1A0000 - 1A0043 ENDS at 1A7FFF
            bank = 0x1A0000;
            index = 275; // to 309
            bankIndex = 0;
            offset = 0x44;
            size = 0;

            for (; index < 309; index++, bankIndex++)
            {
                // Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = Comp.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1A TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1A TileMaps too large to save \n Stopped saving at TileMap " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x1A TILEMAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x8000 - offset]);
            #endregion

            #region Physical Maps
            /****PHYSICAL MAPS****/
            // store original
            bank = 0x1B0000;
            original = new byte[model.SolidityMaps.Length][];
            temp = Bits.GetShort(model.Data, 0x1B0000);
            for (int i = 0, a = 0; i < model.SolidityMaps.Length; i++)
            {
                a = i * 2;
                for (int b = 0x1B0000; b < 0x1D0000; b += 0x010000)
                {
                    temp = Bits.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(model.Data, bank))
                {
                    if (bank < 0x1C0000)
                    {
                        size = 0x10000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x8000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0x7FFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(model.Data, bank + a + 2) - Bits.GetShort(model.Data, bank + a);

                original[i] = Bits.GetByteArray(model.Data, bank + Bits.GetShort(model.Data, bank + a), size);
            }

            compressed = new byte[0x20C2];
            bank = 0x1B0000;
            index = 0;
            bankIndex = 0;
            offset = 0xA0;

            for (; index < 80; index++, bankIndex++)
            {
                //Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditPhysicalMaps[index])
                {
                    model.EditPhysicalMaps[index] = false;

                    //Compress data
                    size = Comp.Compress(model.SolidityMaps[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x1B Solidity Maps too large to save \n Stopped saving at Physical Map " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.SolidityMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x20C2)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1B Solidity Maps too large to save \n Stopped saving at Physical Map " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.SolidityMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x20C2], compressed);
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x1B SOLIDITY MAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x1C0000;
            index = 80;
            bankIndex = 0;
            offset = 0x50;

            for (; index < 120; index++, bankIndex++)
            {
                //Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditPhysicalMaps[index])
                {
                    model.EditPhysicalMaps[index] = false;

                    //Compress data
                    size = Comp.Compress(model.SolidityMaps[index], compressed);
                    if (offset + size > 0x7FFF)
                    {
                        MessageBox.Show("Bank 0x1C Solidity Maps too large to save \n Stopped saving at Physical Map " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.SolidityMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x20C2)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1C Solidity Maps too large to save \n Stopped saving at Physical Map " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.SolidityMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = Comp.Compress(new byte[0x20C2], compressed);
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x1C SOLIDITY MAP #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x8000 - offset]);
            #endregion

            #region Tile Sets
            /****TILESETS****/
            // store original
            bank = 0x3B0000;
            original = new byte[model.TileSets.Length][];
            temp = Bits.GetShort(model.Data, 0x3B0000);
            for (int i = 0, a = 0; i < model.TileSets.Length; i++)
            {
                a = i * 2;
                for (int b = 0x3B0000; b < 0x3E0000; b += 0x010000)
                {
                    temp = Bits.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(model.Data, bank))
                {
                    if (bank < 0x3D0000)
                    {
                        size = 0x10000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0xC000 - Bits.GetShort(model.Data, bank + a);
                        for (int o = 0xBFFF; model.Data[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(model.Data, bank + a + 2) - Bits.GetShort(model.Data, bank + a);

                original[i] = Bits.GetByteArray(model.Data, bank + Bits.GetShort(model.Data, bank + a), size);
            }

            compressed = new byte[0x1000];
            bank = 0x3B0000;
            index = 0;
            bankIndex = 0;
            offset = 0x74;

            for (; index < 58; index++, bankIndex++)
            {
                //Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = Comp.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x3B Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3B Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x3B TILESET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x3C0000;
            index = 58;
            bankIndex = 0;
            offset = 0x42;

            for (; index < 91; index++, bankIndex++)
            {
                //Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = Comp.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x3C Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3C Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x3C TILESET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x3D0000;
            index = 91;
            bankIndex = 0;
            offset = 0x44;

            for (; index < 125; index++, bankIndex++)
            {
                //Write pointer offset
                Bits.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = Comp.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xBFFF)
                    {
                        MessageBox.Show("Bank 0x3D Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    Bits.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xBFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3D Tilesets too large to save \n Stopped saving at Tileset " + index.ToString(), "LAZY SHELL");
                        size = Comp.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                progressBar.PerformStep("COMPRESSING BANK 0x3D TILESET #" + index.ToString("d3"));
            }
            // fill up the rest of the bank with 0x00's
            Bits.SetByteArray(data, bank + offset, new byte[0xC000 - offset]);
            #endregion

            progressBar.Close();
        }

        // import / export
        private void graphicSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryWriter binWriter;
            string path = GetDirectoryPath("Where do you want to save the graphic sets?");

            path += "\\" + model.GetFileNameWithoutPath() + " - Graphic Sets\\";

            if (!CreateDir(path))
                return;
            if (path == null)
                return;

            try
            {
                for (int i = 0; i < model.GraphicSets.Length; i++)
                {
                    binWriter = new BinaryWriter(File.Open(path + "graphicSet." + i.ToString("d3") + ".bin", FileMode.Create));
                    binWriter.Write(model.GraphicSets[i]);
                    binWriter.Close();
                }
            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to save the graphic sets.\n\n" + ioexc.Message, "LAZY SHELL");
            }

        }
        private void graphicSetsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Import graphic set";
            openFileDialog1.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                filename = openFileDialog1.FileName;
            else
                return;

            string num = filename.Substring(filename.LastIndexOf('.') - 2, 2);

            int index = Int32.Parse(num, System.Globalization.NumberStyles.HexNumber);

            try
            {
                FileInfo fInfo = new FileInfo(filename);

                if (fInfo.Length != 8192)
                {
                    MessageBox.Show("File is incorrect size, Graphic Sets are 8192 bytes", "LAZY SHELL");
                    return;
                }

                FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                model.GraphicSets[index] = br.ReadBytes((int)fInfo.Length);
                model.EditGraphicSets[index] = true;
                br.Close();
                fStream.Close();

                fullUpdate = true;
                RefreshLevel();

                return;

            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to Import the Graphic Set.\n\n" + ioexc.Message, "LAZY SHELL");
                return;
            }

        }

        #endregion
        #region Event Handlers

        // MAPS tab
        private void mapNum_ValueChanged(object sender, EventArgs e)
        {
            //SaveMapProperties(); // Save any changes must save changes prior to this point
            // Every property has to save itself

            tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

            level.LevelMap = (int)mapNum.Value; // Set the levels mapNum to the new value

            InitializeMapProperties(); // Load the new Map properties
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet1Name.SelectedIndex = (int)mapGFXSet1Num.Value;
            levelMap.GraphicSetA = (byte)this.mapGFXSet1Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet1Num.Value = mapGFXSet1Name.SelectedIndex;
        }
        private void mapGFXSet2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet2Name.SelectedIndex = (int)mapGFXSet2Num.Value;
            levelMap.GraphicSetB = (byte)this.mapGFXSet2Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet2Num.Value = mapGFXSet2Name.SelectedIndex;
        }
        private void mapGFXSet3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet3Name.SelectedIndex = (int)mapGFXSet3Num.Value;
            levelMap.GraphicSetC = (byte)this.mapGFXSet3Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet3Num.Value = mapGFXSet3Name.SelectedIndex;
        }
        private void mapGFXSet4Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet4Name.SelectedIndex = (int)mapGFXSet4Num.Value;
            levelMap.GraphicSetD = (byte)this.mapGFXSet4Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet4Num.Value = mapGFXSet4Name.SelectedIndex;
        }
        private void mapGFXSet5Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet5Name.SelectedIndex = (int)mapGFXSet5Num.Value;
            levelMap.GraphicSetE = (byte)this.mapGFXSet5Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet5Num.Value = mapGFXSet5Name.SelectedIndex;
        }
        private void mapGFXSetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSetL3Name.SelectedIndex = (int)mapGFXSetL3Num.Value;
            if (this.mapGFXSetL3Num.Value > 0x1b)
            {
                levelMap.GraphicSetL3 = (byte)0xff;
                this.mapTilesetL3Num.Enabled = false;
                this.mapTilesetL3Name.Enabled = false;
                this.mapTilemapL3Num.Enabled = false;
                this.mapTilemapL3Name.Enabled = false;
                if (levelsTileset.Layer == 2)
                    levelsTileset.Layer = 0;
            }
            else
            {
                levelMap.GraphicSetL3 = (byte)this.mapGFXSetL3Num.Value;
                this.mapTilesetL3Num.Enabled = true;
                this.mapTilesetL3Name.Enabled = true;
                this.mapTilemapL3Num.Enabled = true;
                this.mapTilemapL3Name.Enabled = true;
            }
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSetL3Num.Value = mapGFXSetL3Name.SelectedIndex;
        }
        private void mapTilesetL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL1Name.SelectedIndex = (int)mapTilesetL1Num.Value;
            levelMap.TileSetL1 = (byte)this.mapTilesetL1Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL1Num.Value = mapTilesetL1Name.SelectedIndex;
        }
        private void mapTilesetL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL2Name.SelectedIndex = (int)mapTilesetL2Num.Value;
            levelMap.TileSetL2 = (byte)this.mapTilesetL2Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL2Num.Value = mapTilesetL2Name.SelectedIndex;
        }
        private void mapTilesetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL3Name.SelectedIndex = (int)mapTilesetL3Num.Value;
            levelMap.TileSetL3 = (byte)this.mapTilesetL3Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL3Num.Value = mapTilesetL3Name.SelectedIndex;
        }
        private void mapTilemapL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL1Name.SelectedIndex = (int)mapTilemapL1Num.Value;
            levelMap.TileMapL1 = (byte)this.mapTilemapL1Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL1Num.Value = mapTilemapL1Name.SelectedIndex;
        }
        private void mapTilemapL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL2Name.SelectedIndex = (int)mapTilemapL2Num.Value;
            levelMap.TileMapL2 = (byte)this.mapTilemapL2Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL2Num.Value = mapTilemapL2Name.SelectedIndex;
        }
        private void mapTilemapL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL3Name.SelectedIndex = (int)mapTilemapL3Num.Value;
            levelMap.TileMapL3 = (byte)this.mapTilemapL3Num.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL3Num.Value = mapTilemapL3Name.SelectedIndex;
        }
        private void mapBattlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            levelMap.Battlefield = (byte)this.mapBattlefieldNum.Value;
            mapBattlefieldName.SelectedIndex = (int)mapBattlefieldNum.Value;
        }
        private void mapBattlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapBattlefieldNum.Value = mapBattlefieldName.SelectedIndex;
        }
        private void mapPhysicalMapNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPhysicalMapName.SelectedIndex = (int)mapPhysicalMapNum.Value;
            levelMap.PhysicalMap = (byte)this.mapPhysicalMapNum.Value;
            if (!updating)
            {
                fullUpdate = true;
                physicalMap = new LevelSolidMap(levelMap);
                physicalMap.Image = null;
                LoadTilemapEditor();
            }
        }
        private void mapPhysicalMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPhysicalMapNum.Value = mapPhysicalMapName.SelectedIndex;
        }
        private void mapSetL3Priority_CheckedChanged(object sender, EventArgs e)
        {
            mapSetL3Priority.ForeColor = mapSetL3Priority.Checked ? Color.Black : Color.Gray;
            levelMap.TopPriorityL3 = mapSetL3Priority.Checked;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapPaletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPaletteSetName.SelectedIndex = (int)mapPaletteSetNum.Value;
            levelMap.PaletteSet = (byte)this.mapPaletteSetNum.Value;
            if (!updating)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapPaletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPaletteSetNum.Value = mapPaletteSetName.SelectedIndex;
        }
        #endregion
    }
}
