using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Restore : Form
    {
        private Settings settings = Settings.Default;
        private byte[] data { get { return Model.ROM; } set { Model.ROM = value; } }
        private string fileName;
        // constructor
        public Restore()
        {
            InitializeComponent();
        }
        // functions
        public bool ReadRom()
        {
        Retry:
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
                br.Close();
                fStream.Close();

                return true;

            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + ex.Message,
                    "LAZY SHELL", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) != DialogResult.Cancel)
                    goto Retry;

                fileName = "Invalid File";
                return false;
            }

        }
        // event handlers
        private void browseFreshRom_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Select a SMRPG ROM";
            openFileDialog1.Filter = "SMC files (*.SMC)|*.SMC|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
            Retry:
                try
                {
                    FileInfo fInfo = new FileInfo(openFileDialog1.FileName);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);
                    byte[] temp = br.ReadBytes((int)numBytes);
                    br.Close();
                    fStream.Close();

                    // Check if valid rom
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    if (encoding.GetString(Bits.GetByteArray(temp, 0x7FB2, 4)) != "ARWE")
                    {
                        MessageBox.Show("The game code for this ROM is invalid.", "LAZY SHELL");
                        return;
                    }
                    data = temp;
                    freshRomTextBox.Text = openFileDialog1.FileName;
                    buttonOK.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + ex.Message,
                        "LAZY SHELL", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) != DialogResult.Cancel)
                        goto Retry;
                }
            }
        }
        private void elements_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            foreach (TreeNode tn in e.Node.Nodes)
                tn.Checked = e.Node.Checked;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Allies
            if (elements.Nodes["Allies"].Nodes["LevelUps"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A134D, Model.ROM, 0x3A134D, 0x30); // character names
                Buffer.BlockCopy(data, 0x3A1AFF, Model.ROM, 0x3A1AFF, 0x3A0); // level-ups
                Buffer.BlockCopy(data, 0x3A42F5, Model.ROM, 0x3A42F5, 0x91); // learned spells
            }
            if (elements.Nodes["Allies"].Nodes["StartingStats"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A002C, Model.ROM, 0x3A002C, 0x120); // all
            }
            if (elements.Nodes["Allies"].Nodes["Timings"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A438A, Model.ROM, 0x3A438A, 0xA4); // weapons only
                Buffer.BlockCopy(data, 0x02C9B3, Model.ROM, 0x02C9B3, 0x14); // defense
            }
            // Animations
            if (elements.Nodes["Animations"].Checked)   // animation scripts
            {
                Buffer.BlockCopy(data, 0x350000, Model.ROM, 0x350000, 0x10000);
                Buffer.BlockCopy(data, 0x3A6000, Model.ROM, 0x3A6000, 0xA000); // battle events
            }
            // Attacks
            if (elements.Nodes["Attacks"].Nodes["Attacks"].Checked)
            {
                Buffer.BlockCopy(data, 0x391226, Model.ROM, 0x391226, 0x204);  // attacks
                Buffer.BlockCopy(data, 0x3959F4, Model.ROM, 0x3959F4, 0xB60);  // attack names
            }
            if (elements.Nodes["Attacks"].Nodes["Spells"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A137F, Model.ROM, 0x3A137F, 0xC00);  // spell names
                Buffer.BlockCopy(data, 0x3A20F1, Model.ROM, 0x3A20F1, 0x600);  // spells
                Buffer.BlockCopy(data, 0x3A2B80, Model.ROM, 0x3A2B80, 0x3A0);  // spell desc
            }
            // Audio
            if (elements.Nodes["Audio"].Nodes["Samples"].Checked)
            {
                Buffer.BlockCopy(data, 0x042333, Model.ROM, 0x042333, 116 * 3);    // audio sample pointers
                Buffer.BlockCopy(data, 0x060939, Model.ROM, 0x060939, 0x094000 - 0x060939);    // audio samples
                Buffer.BlockCopy(data, 0x146000, Model.ROM, 0x146000, 0x148000 - 0x146000);    // audio samples
                Buffer.BlockCopy(data, 0x1C8000, Model.ROM, 0x1C8000, 0x1CEA00 - 0x1C8000);    // audio samples
            }
            if (elements.Nodes["Audio"].Nodes["SPCTracks"].Checked)
            {
                Buffer.BlockCopy(data, 0x042748, Model.ROM, 0x042748, 73 * 3);    // spc track pointers
                Buffer.BlockCopy(data, 0x045526, Model.ROM, 0x045526, 0x1B413);    // spc track data
            }
            if (elements.Nodes["Audio"].Nodes["EventSoundFX"].Checked)
            {
                Buffer.BlockCopy(data, 0x042826, Model.ROM, 0x042826, 0x1600);    // event sound fx
            }
            if (elements.Nodes["Audio"].Nodes["BattleSoundFX"].Checked)
            {
                Buffer.BlockCopy(data, 0x043E26, Model.ROM, 0x043E26, 0x1600);    // battle sound fx
            }
            // Battlefields
            if (elements.Nodes["Battlefields"].Nodes["Battlefields"].Checked)   // battlefields
            {
                Buffer.BlockCopy(data, 0x39B644, Model.ROM, 0x39B644, 0x200);
                Buffer.BlockCopy(data, 0x34D000, Model.ROM, 0x34D000, 0x3000); // palettes
            }
            if (elements.Nodes["Battlefields"].Nodes["Tilesets"].Checked)   // battlefield tilesets
            {
                Buffer.BlockCopy(data, 0x150000, Model.ROM, 0x150000, 0x10000);
            }
            if (elements.Nodes["Battlefields"].Nodes["Graphics"].Checked)   // battlefield graphics
            {
                Buffer.BlockCopy(data, 0x110000, Model.ROM, 0x110000, 0x36000);
            }
            // Dialogues
            if (elements.Nodes["Dialogues"].Nodes["Dialogues"].Checked)   // dialogues
            {
                Buffer.BlockCopy(data, 0x006935, Model.ROM, 0x006935, 0x8);    // compression table pointers
                Buffer.BlockCopy(data, 0x220000, Model.ROM, 0x220000, 0x29140);    //dialogues
                Buffer.BlockCopy(data, 0x37E000, Model.ROM, 0x37E000, 0x2000); // pointers
            }
            if (elements.Nodes["Dialogues"].Nodes["BattleDialogues"].Checked)
            {
                Buffer.BlockCopy(data, 0x396554, Model.ROM, 0x396554, 0x2D7D); // battle dialogues
            }
            if (elements.Nodes["Dialogues"].Nodes["FontsBackgrounds"].Checked)   // fonts, backgrounds
            {
                Buffer.BlockCopy(data, 0x249140, Model.ROM, 0x249140, 0xEC0);
                Buffer.BlockCopy(data, 0x37C000, Model.ROM, 0x37C000, 0x2000);
                Buffer.BlockCopy(data, 0x3DF000, Model.ROM, 0x3DF000, 0x1000);
            }
            // Effects
            if (elements.Nodes["Effects"].Checked)   // spell effects
            {
                Buffer.BlockCopy(data, 0x251000, Model.ROM, 0x251000, 0x200);  // effects
                Buffer.BlockCopy(data, 0x252C00, Model.ROM, 0x252C00, 0xC0);   // main data pointers
                Buffer.BlockCopy(data, 0x330000, Model.ROM, 0x330000, 0x1D000);    // main data
            }
            // Event Scripts
            if (elements.Nodes["EventScripts"].Nodes["EventScripts"].Checked)   // event scripts
            {
                Buffer.BlockCopy(data, 0x1E0000, Model.ROM, 0x1E0000, 0x2E000);
            }
            if (elements.Nodes["EventScripts"].Nodes["ActionScripts"].Checked)   // action scripts
            {
                Buffer.BlockCopy(data, 0x210000, Model.ROM, 0x210000, 0xC000);
            }
            // Formations
            if (elements.Nodes["Formations"].Nodes["Formations"].Checked)
            {
                Buffer.BlockCopy(data, 0x392AAA, Model.ROM, 0x392AAA, 0x600);  // formation stats
                Buffer.BlockCopy(data, 0x39C000, Model.ROM, 0x39C000, 0x4000);  // formations
            }
            if (elements.Nodes["Formations"].Nodes["Packs"].Checked)
            {
                Buffer.BlockCopy(data, 0x39222A, Model.ROM, 0x39222A, 0x400);  // packs
            }
            // Items
            if (elements.Nodes["Items"].Nodes["Items"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A014D, Model.ROM, 0x3A014D, 0x1200); // items
                Buffer.BlockCopy(data, 0x3A2F20, Model.ROM, 0x3A2F20, 0x13D2); // item desc, prices
                Buffer.BlockCopy(data, 0x3A46EF, Model.ROM, 0x3A46EF, 0xF00); // item names
            }
            if (elements.Nodes["Items"].Nodes["Shops"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A44DF, Model.ROM, 0x3A44DF, 0x210); // item names
            }
            // Levels
            if (elements.Nodes["Levels"].Nodes["Layers"].Checked)   // layers
            {
                Buffer.BlockCopy(data, 0x1D0000, Model.ROM, 0x1D0000, 0X2440);
            }
            if (elements.Nodes["Levels"].Nodes["Maps"].Checked)   // maps
            {
                Buffer.BlockCopy(data, 0x1D2440, Model.ROM, 0x1D2440, 0x924);
                Buffer.BlockCopy(data, 0x24A000, Model.ROM, 0x24A000, 0x6000);   // palettes
            }
            if (elements.Nodes["Levels"].Nodes["NPCs"].Checked)   // NPCs
            {
                Buffer.BlockCopy(data, 0x148000, Model.ROM, 0x148000, 0x8000);
                Buffer.BlockCopy(data, 0x1DB800, Model.ROM, 0x1DB800, 0xE00);
                Buffer.BlockCopy(data, 0x1DDE00, Model.ROM, 0x1DDE00, 0x200);
            }
            if (elements.Nodes["Levels"].Nodes["Exits"].Checked)   // Exits
            {
                Buffer.BlockCopy(data, 0x1D2D64, Model.ROM, 0x1D2D64, 0x1BA1);
            }
            if (elements.Nodes["Levels"].Nodes["Events"].Checked)   // events
            {
                Buffer.BlockCopy(data, 0x20E000, Model.ROM, 0x20E000, 0x2000);
            }
            if (elements.Nodes["Levels"].Nodes["Overlaps"].Checked)   // overlaps
            {
                Buffer.BlockCopy(data, 0x1D4905, Model.ROM, 0x1D4905, 0x15B8);
            }
            if (elements.Nodes["Levels"].Nodes["Tilemaps"].Checked)   // tilemaps
            {
                Buffer.BlockCopy(data, 0x160000, Model.ROM, 0x160000, 0x48000);
            }
            if (elements.Nodes["Levels"].Nodes["Tilesets"].Checked)   // tilesets
            {
                Buffer.BlockCopy(data, 0x3B0000, Model.ROM, 0x3B0000, 0x2C000);
            }
            if (elements.Nodes["Levels"].Nodes["TileMods"].Checked)
            {
                Buffer.BlockCopy(data, 0x1D5EBD, Model.ROM, 0x1D5EBD, 0x2EF3);
            }
            if (elements.Nodes["Levels"].Nodes["SolidMods"].Checked)
            {
                Buffer.BlockCopy(data, 0x1D8DB0, Model.ROM, 0x1D8DB0, 0xCFF);
            }
            if (elements.Nodes["Levels"].Nodes["Graphics"].Checked)   // graphics
            {
                Buffer.BlockCopy(data, 0x0A0000, Model.ROM, 0x0A0000, 0x60000);
            }
            if (elements.Nodes["Levels"].Nodes["SolidityMaps"].Checked)   // physical maps
            {
                Buffer.BlockCopy(data, 0x1B0000, Model.ROM, 0x1B0000, 0x18000);
            }
            // Main Title
            if (elements.Nodes["MainTitle"].Checked)
            {
                Buffer.BlockCopy(data, 0x3F216F, Model.ROM, 0x3F216F, 0x3FA000 - 0x3F216F);    // compressed data
                Buffer.BlockCopy(data, 0x3F0088, Model.ROM, 0x3F0088, 0x3F0228 - 0x3F0088);    // palettes
            }
            // Menus
            if (elements.Nodes["Menus"].Checked)
            {
                Model.ROM[0x03462D] = data[0x03462D]; // music track
                Buffer.BlockCopy(data, 0x03327A, Model.ROM, 0x03327A, 0x03328F - 0x03327A);    // X coord of some texts
                Buffer.BlockCopy(data, 0x0340AA, Model.ROM, 0x0340AA, 0x035023 - 0x0340AA);    // game select sprite sequences
                Buffer.BlockCopy(data, 0x3E0002, Model.ROM, 0x3E0002, 0x3E000E - 0x3E0002);    // pointers of compressed data
                Buffer.BlockCopy(data, 0x3E0E68, Model.ROM, 0x3E0E68, 0x3E2C80 - 0x3E0E68);    // compressed data
                Buffer.BlockCopy(data, 0x3E99E0, Model.ROM, 0x3E99E0, 0x3EB94A - 0x3E99E0);    // compressed data
                Buffer.BlockCopy(data, 0x3EEF00, Model.ROM, 0x3EEF00, 0x3EF700 - 0x3EEF00);    // menu texts
            }
            // Mini-games
            if (elements.Nodes["MiniGames"].Nodes["MineCarts"].Checked)
            {
                Buffer.BlockCopy(data, 0x388000, Model.ROM, 0x388000, 0x8000);
            }
            // Monsters
            if (elements.Nodes["Monsters"].Nodes["Monsters"].Checked)
            {
                Buffer.BlockCopy(data, 0x350202, Model.ROM, 0x350202, 0x200);  // monster death animation
                Buffer.BlockCopy(data, 0x390026, Model.ROM, 0x390026, 0x1120); // monsters
                Buffer.BlockCopy(data, 0x39142A, Model.ROM, 0x39142A, 0xE00);  // monster rewards
                Buffer.BlockCopy(data, 0x3992D1, Model.ROM, 0x3992D1, 0x2373); // monster names, psycho
                Buffer.BlockCopy(data, 0x39B944, Model.ROM, 0x39B944, 0x100);  // monster target cursor
                Buffer.BlockCopy(data, 0x39BB44, Model.ROM, 0x39BB44, 0x100);  // monster flower bonus
            }
            if (elements.Nodes["Monsters"].Nodes["BattleScripts"].Checked)   // battle scripts
            {
                Buffer.BlockCopy(data, 0x3930AA, Model.ROM, 0x3930AA, 0x294A);
            }
            // Sprites
            if (elements.Nodes["Sprites"].Checked)   // sprites
            {
                Buffer.BlockCopy(data, 0x250000, Model.ROM, 0x250000, 0x1000);
                Buffer.BlockCopy(data, 0x251800, Model.ROM, 0x251800, 0x1400);
                Buffer.BlockCopy(data, 0x253000, Model.ROM, 0x253000, 0xDD000);    // everything else
                Buffer.BlockCopy(data, 0x360000, Model.ROM, 0x360000, 0x10000);    // everything else
            }
            // World Maps
            if (elements.Nodes["WorldMaps"].Nodes["WorldMaps"].Checked)   // world maps
            {
                Buffer.BlockCopy(data, 0x3EF800, Model.ROM, 0x3EF800, 0x30); // world map data
            }
            if (elements.Nodes["WorldMaps"].Nodes["Locations"].Checked)   // locations
            {
                Buffer.BlockCopy(data, 0x3EF830, Model.ROM, 0x3EF830, 0x380);  // location data
                Buffer.BlockCopy(data, 0x3EFD00, Model.ROM, 0x3EFD00, 0x220);  // location names
            }
            if (elements.Nodes["WorldMaps"].Nodes["Tilesets"].Checked)   // world map tilesets
            {
                Buffer.BlockCopy(data, 0x3E0000, Model.ROM, 0x3E0000, 0x0E68); // world map logo, banners
                Buffer.BlockCopy(data, 0x3E2E82, Model.ROM, 0x3E2E82, 0x69B6); // world map graphics, tilesets
            }
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in elements.Nodes)
                node.Checked = true;
        }
        private void deselectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in elements.Nodes)
                node.Checked = false;
        }
    }
}
