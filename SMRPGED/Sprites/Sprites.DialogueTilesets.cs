using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Sprites
    {
        #region Variables

        private DialogueTileset dialogueTileset;
        private BattleDialogueTileset battleDialogueTileset;
        private int currentDialogueTile;
        private int currentDialogueSubtile;
        private byte[] bdCopy = new byte[0x100];
        private int bdCopyWidth, bdCopyHeight;

        private Bitmap
            battleDialogueTilesetImage,
            dialogueGraphicImage,
            dialogueTileImage,
            dialogueSubtileImage;

        #endregion

        #region Methods

        // initialize properties
        private void InitializeDialogueTilesetEditor()
        {
            textHelper = TextHelper.Instance;
            textHelperReduced = TextHelperReduced.Instance;

            dialoguePreview = new SMRPGED.Previewer.DialoguePreview();
            battleDialoguePreview = new SMRPGED.Previewer.BattleDialoguePreview();

            model.DialogueGraphics = BitManager.GetByteArray(data, 0x3DF000, 0x700);
            model.BattleDialogueTileset = BitManager.GetByteArray(data, 0x015943, 0x100);

            dialogueTileset = new DialogueTileset(model, GetFontPalette(0));
            battleDialogueTileset = new BattleDialogueTileset(model, GetFontPalette(0));

            InitializeDialogueSubtile();

            SetBattleDialogueTilesetImage();
            SetDialogueGraphicImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();

            SetDialogueBGImage();
        }

        private void InitializeDialogueSubtile()
        {
            updatingFonts = true;

            dialogueSubtile.Value = battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile).TileNum;
            dialogueProperties.SetItemChecked(0, battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile).PriorityOne);
            dialogueProperties.SetItemChecked(1, battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile).Mirrored);
            dialogueProperties.SetItemChecked(2, battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile).Inverted);

            updatingFonts = false;
        }
        private void RefreshDialogueTilesets()
        {
            dialogueTileset = new DialogueTileset(model, GetFontPalette(0));
            battleDialogueTileset = new BattleDialogueTileset(model, GetFontPalette(0));
        }

        // set images
        private void SetBattleDialogueTilesetImage()
        {
            battleDialogueTilesetImage = new Bitmap(DrawImageFromIntArr(battleDialogueTileset.GetTilesetPixelArray(), 256, 32));
            pictureBoxBattle.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxBattle.Invalidate();
            pictureBoxBattleDialogue.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxBattleDialogue.Invalidate();
        }
        private void SetDialogueGraphicImage()
        {
            int[] pixels = new int[128 * 112];
            int[] temp = new int[64 * 56];
            int tileNum;
            Tile8x8 subtile;

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    tileNum = y * 8 + x;
                    subtile = new Tile8x8(tileNum, model.DialogueGraphics, tileNum * 32, GetFontPalette(0), false, false, false, false);
                    CopyOverTile8x8(subtile, temp, 64, x, y);
                }
            }
            for (int y = 0; y < 112; y++)
            {
                for (int x = 0; x < 128; x++)
                    pixels[y * 128 + x] = temp[y / 2 * 64 + (x / 2)];
            }
            if (fontShowGrid.Checked)
            {
                for (int r = 15; r < 112; r += 16)  // draw the horizontal gridlines
                {
                    for (int q = 0; q < 128; q++)
                        pixels[q + (r * 128)] = Color.Gray.ToArgb();
                }

                for (int c = 15; c < 128; c += 16) // draw the vertical gridlines
                {
                    for (int d = 0; d < 112; d++)
                        pixels[c + (d * 128)] = Color.Gray.ToArgb();
                }
            }
            dialogueGraphicImage = new Bitmap(DrawImageFromIntArr(pixels, 128, 112));
            pictureBoxDialogueBG.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxDialogueBG.Invalidate();
        }
        private void SetDialogueTileImage()
        {
            int[] temp = new int[16 * 16];
            int[] dlgTilePixels = new int[32 * 32];

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                    if (battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(y * 2 + x).PriorityOne)
                        CopyOverTile8x8(battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(y * 2 + x), temp, 16, x, y);
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (fontShowGrid.Checked && (x == 16 || y == 16))
                        dlgTilePixels[y * 32 + x] = Color.Gray.ToArgb();
                    else
                        dlgTilePixels[y * 32 + x] = temp[y / 2 * 16 + (x / 2)];
                }
            }
            dialogueTileImage = new Bitmap(DrawImageFromIntArr(dlgTilePixels, 32, 32));
            pictureBoxDialogueTile.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxDialogueTile.Invalidate();
        }
        private void SetDialogueSubtileImage()
        {
            int[] temp = new int[8 * 8];
            int[] dialogueSubtilePixels = new int[32 * 32];

            if (battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile).PriorityOne)
                CopyOverTile8x8(battleDialogueTileset.TilesetLayer[currentDialogueTile].GetSubtile(currentDialogueSubtile), temp, 8, 0, 0);
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    dialogueSubtilePixels[y * 32 + x] = temp[y / 4 * 8 + (x / 4)];
            }

            dialogueSubtileImage = new Bitmap(DrawImageFromIntArr(dialogueSubtilePixels, 32, 32));
            pictureBoxDialogueSubtile.BackColor = Color.FromArgb(paletteRedDialogue[0], paletteGreenDialogue[0], paletteBlueDialogue[0]);
            pictureBoxDialogueSubtile.Invalidate();
        }

        // drawing
        private Tile8x8 CreateNewDialogueSubtile()
        {
            return Draw4bppDialogueTile8x8(
                (byte)dialogueSubtile.Value,
                0,
                0,
                dialogueProperties.GetItemChecked(1),
                dialogueProperties.GetItemChecked(2),
                dialogueProperties.GetItemChecked(0));
        }
        private Tile8x8 Draw4bppDialogueTile8x8(int tile, byte graphicSetIndex, byte paletteSetIndex, bool mirrored, bool inverted, bool priorityOne)
        {
            int offsetChange;
            bool twobpp = false;

            offsetChange = graphicSetIndex * 0x2000;
            int tileDataOffset = (tile * 0x20) + offsetChange;

            if (tileDataOffset >= model.WorldMapGraphics.Length)
                tileDataOffset = 0;

            Tile8x8 temp;
            temp = new Tile8x8(tile, model.DialogueGraphics, tileDataOffset, GetFontPalette(0), mirrored, inverted, priorityOne, twobpp);
            return temp;
        }

        // export / import
        private void ExportDialogueGraphic()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "dialogueGraphic.bin";
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.DialogueGraphics, 0, 0x700);
                bw.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportDialogueGraphic(string path)
        {
            FileStream fs;
            BinaryReader br;
            Bitmap import;

            byte[] graphicBlock = new byte[0x700];

            try
            {
                fs = File.OpenRead(path);
                if (Path.GetExtension(path) == ".jpg" || Path.GetExtension(path) == ".gif" || Path.GetExtension(path) == ".png")
                {
                    import = new Bitmap(Image.FromFile(path));
                    graphicBlock = ArrayTo4bppTile(ImageToArray(import, new Size(64, 56)), import.Width / 8, import.Height / 8, GetFontPalette(0));
                    CopyOverGraphicBlock(
                        graphicBlock, model.DialogueGraphics, new Size(import.Width / 8, import.Height / 8), 8, 0x20,
                        currentDialogueTile % 8, currentDialogueTile / 8, 0);
                }
                else
                {
                    br = new BinaryReader(fs);
                    graphicBlock = br.ReadBytes(0x700);
                    graphicBlock.CopyTo(model.DialogueGraphics, 0);
                    br.Close();
                }
                fs.Close();
                graphicOFfset_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }

        // editing
        private void PasteBattleDialogue()
        {
            if (bdCopy == null) return;
            int offsetA, offsetB, currentA, currentB;
            Point p = overlay.TileSetDragStart;
            for (int y = p.Y / 16, b = 0; y < bdCopyHeight + p.Y && y < 2; y++, b++)
            {
                for (int x = p.X / 16, a = 0; x < bdCopyWidth + p.X && x < 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    if (offsetA >= model.BattleDialogueTileset.Length) break;
                    currentB = b * 16 + a;
                    offsetB = currentB * 4 + (currentB / 16 * 64);
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA, BitManager.GetShort(bdCopy, offsetB));
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 2, BitManager.GetShort(bdCopy, offsetB + 2));
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 64, BitManager.GetShort(bdCopy, offsetB + 64));
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 66, BitManager.GetShort(bdCopy, offsetB + 66));
                }
            }
            battleDialogueTileset = new BattleDialogueTileset(model, GetFontPalette(0));

            InitializeDialogueSubtile();
            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
        }
        private void CutBattleDialogue()
        {
            CopyBattleDialogue();
            DeleteBattleDialogue();
        }
        private void CopyBattleDialogue()
        {
            int offsetA, offsetB, currentA, currentB;
            bdCopyWidth = overlay.TileSetDragStop.X / 16 - overlay.TileSetDragStart.X / 16;
            bdCopyHeight = overlay.TileSetDragStop.Y / 16 - overlay.TileSetDragStart.Y / 16;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    currentB = b * 16 + a;
                    offsetB = currentB * 4 + (currentB / 16 * 64);
                    BitManager.SetShort(bdCopy, offsetB, BitManager.GetShort(model.BattleDialogueTileset, offsetA));
                    BitManager.SetShort(bdCopy, offsetB + 2, BitManager.GetShort(model.BattleDialogueTileset, offsetA + 2));
                    BitManager.SetShort(bdCopy, offsetB + 64, BitManager.GetShort(model.BattleDialogueTileset, offsetA + 64));
                    BitManager.SetShort(bdCopy, offsetB + 66, BitManager.GetShort(model.BattleDialogueTileset, offsetA + 66));
                }
            }
        }
        private void DeleteBattleDialogue()
        {
            int offsetA, currentA;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA, 0x0400);
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 2, 0x0400);
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 64, 0x0400);
                    BitManager.SetShort(model.BattleDialogueTileset, offsetA + 66, 0x0400);
                }
            }
            battleDialogueTileset = new BattleDialogueTileset(model, GetFontPalette(0));

            InitializeDialogueSubtile();
            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
        }

        #endregion

        #region Eventhandlers

        // battle dialogue tileset
        private void pictureBoxBattle_MouseClick(object sender, MouseEventArgs e)
        {
            currentDialogueTile = (e.Y / 16) * 16 + (e.X / 16);
            currentDialogueSubtile = 0;

            InitializeDialogueSubtile();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
        }
        private void pictureBoxBattle_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxBattle.Focus();

            overlay.bdlg = true; overlay.wmap = false;

            overlay.TileSetDragStart = new Point(e.X / 16 * 16, e.Y / 16 * 16);
            overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);

            pictureBoxBattle.Invalidate();
        }
        private void pictureBoxBattle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;

            overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);

            pictureBoxBattle.Invalidate();
        }
        private void pictureBoxBattle_Paint(object sender, PaintEventArgs e)
        {
            if (battleDialogueTilesetImage != null)
                e.Graphics.DrawImage(battleDialogueTilesetImage, 0, 0);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxBattle_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: DeleteBattleDialogue(); break;
                case Keys.Control | Keys.C: CopyBattleDialogue(); break;
                case Keys.Control | Keys.X: CutBattleDialogue(); break;
                case Keys.Control | Keys.V: PasteBattleDialogue(); break;
                case Keys.Control | Keys.D:
                    overlay.TileSetDragStart = new Point(0, 0);
                    overlay.TileSetDragStop = new Point(0, 0);
                    pictureBoxBattle.Invalidate();
                    break;
            }
        }
        private void pictureBoxDialogueTile_MouseClick(object sender, MouseEventArgs e)
        {
            currentDialogueSubtile = e.X / 16 + ((e.Y / 16) * 2);

            InitializeDialogueSubtile();
            SetDialogueSubtileImage();
        }
        private void pictureBoxDialogueTile_Paint(object sender, PaintEventArgs e)
        {
            if (dialogueTileImage != null)
                e.Graphics.DrawImage(dialogueTileImage, 0, 0);
        }
        private void pictureBoxDialogueSubtile_Paint(object sender, PaintEventArgs e)
        {
            if (dialogueSubtileImage != null)
                e.Graphics.DrawImage(dialogueSubtileImage, 0, 0);
        }
        private void dialogueSubtile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            battleDialogueTileset.TilesetLayer[currentDialogueTile].SetSubtile(CreateNewDialogueSubtile(), currentDialogueSubtile);

            int offset = currentDialogueTile * 4;
            if (currentDialogueSubtile % 2 == 1) offset += 2;
            if (currentDialogueSubtile / 2 == 1) offset += 64;
            offset += (currentDialogueTile / 16) * 64;

            model.BattleDialogueTileset[offset] = (byte)dialogueSubtile.Value;

            battleDialogueTilesetImage = new Bitmap(DrawImageFromIntArr(battleDialogueTileset.GetTilesetPixelArray(), 256, 32));

            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
        }
        private void dialogueProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            battleDialogueTileset.TilesetLayer[currentDialogueTile].SetSubtile(CreateNewDialogueSubtile(), currentDialogueSubtile);

            int offset = currentDialogueTile * 4;
            if (currentDialogueSubtile % 2 == 1) offset += 2;
            if (currentDialogueSubtile / 2 == 1) offset += 64;
            offset += (currentDialogueTile / 16) * 64;

            BitManager.SetBit(model.BattleDialogueTileset, offset + 1, 5, dialogueProperties.GetItemChecked(0));
            BitManager.SetBit(model.BattleDialogueTileset, offset + 1, 6, dialogueProperties.GetItemChecked(1));
            BitManager.SetBit(model.BattleDialogueTileset, offset + 1, 7, dialogueProperties.GetItemChecked(2));

            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
            pictureBoxBattleDialogue.BackgroundImage = new Bitmap(DrawImageFromIntArr(battleDialogueTileset.GetTilesetPixelArray(), 256, 32));
        }
        private void pictureBoxDialogueBG_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setAsSubtileToolStripMenuItem_Click(null, null);
        }
        private void pictureBoxDialogueBG_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverSubtile = e.Y / 16 * 8 + (e.X / 16);
            mouseOverControl = pictureBoxDialogueBG.Name;
        }
        private void pictureBoxDialogueBG_Paint(object sender, PaintEventArgs e)
        {
            if (dialogueGraphicImage != null)
                e.Graphics.DrawImage(dialogueGraphicImage, 0, 0);
        }

        #endregion
    }
}
