using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LAZYSHELL
{
    public partial class SpaceAnalyzer : Form
    {
        Model model = State.Instance.Model;
        public SpaceAnalyzer()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            InitTileMaps();
        }

        private void InitTileMaps()
        {
            ProgressBar pBar = new ProgressBar(model.Data, "CALCULATING...", 428);
            pBar.Show();

            int bank, index, size, bankIndex;
            int offset;
            Color bg;

            bank = 0x160000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x00DA; // Set initial offset for this bank
            bg = Color.LightGreen;

            for (; index < 109; index++, bankIndex++)
            {
                size = Comp.Compress(model.TileMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                tileMapListBox.Items.Add(new TileMapItem(index, 0, bg));
                bankListBox.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += size;

                sizeLeftListBox.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
            }

            bank = 0x170000; // Set bank pointer
            index = 109; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x006C; // Set initial offset for this bank
            bg = Color.LightBlue;

            for (; index < 163; index++, bankIndex++)
            {
                size = Comp.Compress(model.TileMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                tileMapListBox.Items.Add(new TileMapItem(index, 0, bg));
                bankListBox.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
            }

            bank = 0x180000; // Set bank pointer
            index = 163; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0070; // Set initial offset for this bank
            bg = Color.LightSeaGreen;

            for (; index < 219; index++, bankIndex++)
            {
                size = Comp.Compress(model.TileMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                tileMapListBox.Items.Add(new TileMapItem(index, 0, bg));
                bankListBox.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
            }

            bank = 0x190000; // Set bank pointer
            index = 219; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0070; // Set initial offset for this bank
            bg = Color.LightSteelBlue;

            for (; index < 275; index++, bankIndex++)
            {
                size = Comp.Compress(model.TileMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                tileMapListBox.Items.Add(new TileMapItem(index, 0, bg));
                bankListBox.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
            }

            bank = 0x1A0000; // Set bank pointer
            index = 275; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0044; // Set initial offset for this bank
            bg = Color.LightSlateGray;

            for (; index < 309; index++, bankIndex++)
            {
                size = Comp.Compress(model.TileMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                tileMapListBox.Items.Add(new TileMapItem(index, 0, bg));
                bankListBox.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("TILE MAP #" + index.ToString("d3"));
            }


            /****PHYSICAL MAPS****/
            bank = 0x1B0000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x00A0; // Set initial offset for this bank
            bg = Color.Khaki;

            for (; index < 80; index++, bankIndex++)
            {
                size = Comp.Compress(model.SolidityMaps[index], null);
                if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                physMapListBox.Items.Add(new TileMapItem(index, 1, bg));
                bankListBox1.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox1.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox1.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox1.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox1.Items.Add(new SizeLeft(0xFFFF - offset, bg));
                pBar.PerformStep("SOLIDITY MAP #" + index.ToString());
            }

            bank = 0x1C0000; // Set bank pointer
            index = 80; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x0050; // Set initial offset for this bank
            bg = Color.DarkKhaki;

            for (; index < 120; index++, bankIndex++)
            {
                size = Comp.Compress(model.SolidityMaps[index], null);
                if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                {
                    bg = Color.Red;
                }

                physMapListBox.Items.Add(new TileMapItem(index, 1, bg));
                bankListBox1.Items.Add(new Bank(bank, bg));
                pointerOffsetListBox1.Items.Add(new PointerOffset((bank + (bankIndex * 2)), bg));
                dataOffsetListBox1.Items.Add(new DataOffset(bank + offset, bg));
                compressedDataSizeListBox1.Items.Add(new CompressedDataSize(size, bg));

                offset++;
                offset += (ushort)size;

                sizeLeftListBox1.Items.Add(new SizeLeft(0x7FFF - offset, bg));
                pBar.PerformStep("SOLIDITY MAP #" + index.ToString("d3"));
            }

            pBar.Close();
        }

        interface NewListBoxItem
        {
            Color GetBgColor();
        }
        private class TileMapItem : NewListBoxItem
        {
            private int num; public int Num { get { return num; } }
            private int type; public int Type { get { return type; } }
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public TileMapItem(int num, int type, Color bg)
            {
                this.bgColor = bg;
                this.num = num;
                this.type = type;
            }
            public override string ToString()
            {
                if (type == 0)
                    return "Tile Map " + num.ToString("d3");
                else
                    return "Solidity Map " + num.ToString("d3");
            }
        }
        private class Bank : NewListBoxItem
        {
            private int bankNum; public int BankNum { get { return bankNum; } }
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public Bank(int bankNum, Color bg)
            {
                this.bgColor = bg;
                this.bankNum = bankNum;
            }
            public override string ToString()
            {
                return "0x" + bankNum.ToString("X");
            }
        }
        private class PointerOffset : NewListBoxItem
        {
            private int pointer; public int Pointer { get { return pointer; } }
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public PointerOffset(int pointer, Color bg)
            {
                this.bgColor = bg;
                this.pointer = pointer;
            }
            public override string ToString()
            {
                return "0x" + Pointer.ToString("X");
            }
        }
        private class DataOffset : NewListBoxItem
        {
            private int dataOffset;
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public DataOffset(int dataOffset, Color bg)
            {
                this.bgColor = bg;
                this.dataOffset = dataOffset;
            }
            public override string ToString()
            {
                return "0x" + dataOffset.ToString("X");
            }
        }
        private class CompressedDataSize : NewListBoxItem
        {
            private int dataSize; public int DataSize { get { return dataSize; } }
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public CompressedDataSize(int dataSize, Color bg)
            {
                this.bgColor = bg;
                this.dataSize = dataSize;
            }
            public override string ToString()
            {
                return dataSize.ToString() + " Bytes";
            }
        }
        private class SizeLeft : NewListBoxItem
        {
            private int sizeLeft;
            private Color bgColor;
            public Color GetBgColor() { return bgColor; }

            public SizeLeft(int sizeLeft, Color bg)
            {
                this.bgColor = bg;
                this.sizeLeft = sizeLeft;
            }
            public override string ToString()
            {
                return sizeLeft.ToString();
            }
        }


        private class NewListBox : ListBox
        {
            public NewListBox()
            {
                DrawMode = DrawMode.OwnerDrawFixed;
            }

            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                if (this.Items.Count == 0) return;
                NewListBoxItem i = (NewListBoxItem)this.Items[e.Index];
                Color col = i.GetBgColor();
                //Draw the background
                e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);
                //Draw the text
                e.Graphics.DrawString(Items[e.Index].ToString(), this.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
                //Draw the focus rectangle
                e.DrawFocusRectangle();
            }
        }

        private void tileMapListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bankListBox.SelectedIndex = tileMapListBox.SelectedIndex;
            this.pointerOffsetListBox.SelectedIndex = tileMapListBox.SelectedIndex;
            this.dataOffsetListBox.SelectedIndex = tileMapListBox.SelectedIndex;
            this.compressedDataSizeListBox.SelectedIndex = tileMapListBox.SelectedIndex;
            this.sizeLeftListBox.SelectedIndex = tileMapListBox.SelectedIndex;
        }
        private void bankListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tileMapListBox.SelectedIndex = bankListBox.SelectedIndex;
            this.pointerOffsetListBox.SelectedIndex = bankListBox.SelectedIndex;
            this.dataOffsetListBox.SelectedIndex = bankListBox.SelectedIndex;
            this.compressedDataSizeListBox.SelectedIndex = bankListBox.SelectedIndex;
            this.sizeLeftListBox.SelectedIndex = bankListBox.SelectedIndex;

        }
        private void pointerOffsetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tileMapListBox.SelectedIndex = pointerOffsetListBox.SelectedIndex;
            this.bankListBox.SelectedIndex = pointerOffsetListBox.SelectedIndex;
            this.dataOffsetListBox.SelectedIndex = pointerOffsetListBox.SelectedIndex;
            this.compressedDataSizeListBox.SelectedIndex = pointerOffsetListBox.SelectedIndex;
            this.sizeLeftListBox.SelectedIndex = pointerOffsetListBox.SelectedIndex;

        }
        private void dataOffsetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tileMapListBox.SelectedIndex = dataOffsetListBox.SelectedIndex;
            this.bankListBox.SelectedIndex = dataOffsetListBox.SelectedIndex;
            this.pointerOffsetListBox.SelectedIndex = dataOffsetListBox.SelectedIndex;
            this.compressedDataSizeListBox.SelectedIndex = dataOffsetListBox.SelectedIndex;
            this.sizeLeftListBox.SelectedIndex = dataOffsetListBox.SelectedIndex;

        }
        private void compressedDataSizeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tileMapListBox.SelectedIndex = compressedDataSizeListBox.SelectedIndex;
            this.bankListBox.SelectedIndex = compressedDataSizeListBox.SelectedIndex;
            this.pointerOffsetListBox.SelectedIndex = compressedDataSizeListBox.SelectedIndex;
            this.dataOffsetListBox.SelectedIndex = compressedDataSizeListBox.SelectedIndex;
            this.sizeLeftListBox.SelectedIndex = compressedDataSizeListBox.SelectedIndex;

        }
        private void sizeLeftListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tileMapListBox.SelectedIndex = sizeLeftListBox.SelectedIndex;
            this.bankListBox.SelectedIndex = sizeLeftListBox.SelectedIndex;
            this.pointerOffsetListBox.SelectedIndex = sizeLeftListBox.SelectedIndex;
            this.dataOffsetListBox.SelectedIndex = sizeLeftListBox.SelectedIndex;
            this.compressedDataSizeListBox.SelectedIndex = sizeLeftListBox.SelectedIndex;

        }
        //***************************//
        private void physMapListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bankListBox1.SelectedIndex = physMapListBox.SelectedIndex;
            this.pointerOffsetListBox1.SelectedIndex = physMapListBox.SelectedIndex;
            this.dataOffsetListBox1.SelectedIndex = physMapListBox.SelectedIndex;
            this.compressedDataSizeListBox1.SelectedIndex = physMapListBox.SelectedIndex;
            this.sizeLeftListBox1.SelectedIndex = physMapListBox.SelectedIndex;
        }
        private void bankListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.physMapListBox.SelectedIndex = bankListBox1.SelectedIndex;
            this.pointerOffsetListBox1.SelectedIndex = bankListBox1.SelectedIndex;
            this.dataOffsetListBox1.SelectedIndex = bankListBox1.SelectedIndex;
            this.compressedDataSizeListBox1.SelectedIndex = bankListBox1.SelectedIndex;
            this.sizeLeftListBox1.SelectedIndex = bankListBox1.SelectedIndex;
        }
        private void pointerOffsetListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.physMapListBox.SelectedIndex = pointerOffsetListBox1.SelectedIndex;
            this.bankListBox1.SelectedIndex = pointerOffsetListBox1.SelectedIndex;
            this.dataOffsetListBox1.SelectedIndex = pointerOffsetListBox1.SelectedIndex;
            this.compressedDataSizeListBox1.SelectedIndex = pointerOffsetListBox1.SelectedIndex;
            this.sizeLeftListBox1.SelectedIndex = pointerOffsetListBox1.SelectedIndex;
        }
        private void dataOffsetListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.physMapListBox.SelectedIndex = dataOffsetListBox1.SelectedIndex;
            this.bankListBox1.SelectedIndex = dataOffsetListBox1.SelectedIndex;
            this.pointerOffsetListBox1.SelectedIndex = dataOffsetListBox1.SelectedIndex;
            this.compressedDataSizeListBox1.SelectedIndex = dataOffsetListBox1.SelectedIndex;
            this.sizeLeftListBox1.SelectedIndex = dataOffsetListBox1.SelectedIndex;
        }
        private void compressedDataSizeListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.physMapListBox.SelectedIndex = compressedDataSizeListBox1.SelectedIndex;
            this.bankListBox1.SelectedIndex = compressedDataSizeListBox1.SelectedIndex;
            this.pointerOffsetListBox1.SelectedIndex = compressedDataSizeListBox1.SelectedIndex;
            this.dataOffsetListBox1.SelectedIndex = compressedDataSizeListBox1.SelectedIndex;
            this.sizeLeftListBox1.SelectedIndex = compressedDataSizeListBox1.SelectedIndex;
        }
        private void sizeLeftListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.physMapListBox.SelectedIndex = sizeLeftListBox1.SelectedIndex;
            this.bankListBox1.SelectedIndex = sizeLeftListBox1.SelectedIndex;
            this.pointerOffsetListBox1.SelectedIndex = sizeLeftListBox1.SelectedIndex;
            this.dataOffsetListBox1.SelectedIndex = sizeLeftListBox1.SelectedIndex;
            this.compressedDataSizeListBox1.SelectedIndex = sizeLeftListBox1.SelectedIndex;
        }
    }
}