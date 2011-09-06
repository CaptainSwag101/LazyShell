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
        private byte[] data;
        private string fileName;
        // constructor
        public Restore()
        {
            InitializeComponent();
            elements.ExpandAll();
        }
        // functions
        public bool ReadRom()
        {
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
                MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + ex.Message,
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        }
        private void elements_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == elements.Nodes["Stats"])
                foreach (TreeNode tn in elements.Nodes["Stats"].Nodes)
                    tn.Checked = elements.Nodes["Stats"].Checked;
            if (e.Node == elements.Nodes["Levels"])
                foreach (TreeNode tn in elements.Nodes["Levels"].Nodes)
                    tn.Checked = elements.Nodes["Levels"].Checked;
            if (e.Node == elements.Nodes["Scripts"])
                foreach (TreeNode tn in elements.Nodes["Scripts"].Nodes)
                    tn.Checked = elements.Nodes["Scripts"].Checked;
            if (e.Node == elements.Nodes["Sprites"])
                foreach (TreeNode tn in elements.Nodes["Sprites"].Nodes)
                    tn.Checked = elements.Nodes["Sprites"].Checked;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            TreeNode stats = elements.Nodes["Stats"];
            TreeNode levels = elements.Nodes["Levels"];
            TreeNode scripts = elements.Nodes["Scripts"];
            TreeNode sprites = elements.Nodes["Sprites"];

            // STATS
            if (stats.Nodes["Monsters"].Checked)
            {
                Buffer.BlockCopy(data, 0x350202, Model.Data, 0x390202, 0x200);  // monster death animation
                Buffer.BlockCopy(data, 0x390026, Model.Data, 0x390026, 0x1120); // monsters
                Buffer.BlockCopy(data, 0x39142A, Model.Data, 0x39142A, 0xE00);  // monster rewards
                Buffer.BlockCopy(data, 0x3992D1, Model.Data, 0x3992D1, 0x2373); // monster names, psycho
                Buffer.BlockCopy(data, 0x39B944, Model.Data, 0x39B944, 0x100);  // monster target cursor
                Buffer.BlockCopy(data, 0x39BB44, Model.Data, 0x39BB44, 0x100);  // monster flower bonus
            }
            if (stats.Nodes["Formations"].Checked)
            {
                Buffer.BlockCopy(data, 0x39222A, Model.Data, 0x39222A, 0x400);  // packs
                Buffer.BlockCopy(data, 0x392AAA, Model.Data, 0x392AAA, 0x600);  // formation stats
                Buffer.BlockCopy(data, 0x39C000, Model.Data, 0x39C000, 0x4000);  // formations
            }
            if (stats.Nodes["Spells"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A137F, Model.Data, 0x3A137F, 0xC00);  // spell names
                Buffer.BlockCopy(data, 0x3A20F1, Model.Data, 0x3A20F1, 0x600);  // spells
                Buffer.BlockCopy(data, 0x3A2B80, Model.Data, 0x3A2B80, 0x3A0);  // spell desc
            }
            if (stats.Nodes["Attacks"].Checked)
            {
                Buffer.BlockCopy(data, 0x391226, Model.Data, 0x391226, 0x204);  // attacks
                Buffer.BlockCopy(data, 0x3959F4, Model.Data, 0x3959F4, 0xB60);  // attack names
            }
            if (stats.Nodes["Items"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A014D, Model.Data, 0x3A014D, 0x1200); // items
                Buffer.BlockCopy(data, 0x3A2F20, Model.Data, 0x3A2F20, 0x13D2); // item desc, prices
                Buffer.BlockCopy(data, 0x3A46EF, Model.Data, 0x3A46EF, 0xF00); // item names
            }
            if (stats.Nodes["Shops"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A44DF, Model.Data, 0x3A44DF, 0x210); // item names
            }
            if (stats.Nodes["LevelUps"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A134D, Model.Data, 0x3A134D, 0x30); // character names
                Buffer.BlockCopy(data, 0x3A1AFF, Model.Data, 0x3A1AFF, 0x3A0); // level-ups
                Buffer.BlockCopy(data, 0x3A42F5, Model.Data, 0x3A42F5, 0x91); // learned spells
            }
            if (stats.Nodes["StartingStats"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A002C, Model.Data, 0x3A002C, 0x120); // all
            }
            if (stats.Nodes["Timings"].Checked)
            {
                Buffer.BlockCopy(data, 0x3A438A, Model.Data, 0x3A438A, 0xA4); // weapons only
                Buffer.BlockCopy(data, 0x02C9B3, Model.Data, 0x02C9B3, 0x14); // defense
            }


            // LEVELS
            if (levels.Nodes["Layers"].Checked)   // layers
            {
                Buffer.BlockCopy(data, 0x1D0000, Model.Data, 0x1D0000, 0X2440);
            }
            if (levels.Nodes["Maps"].Checked)   // maps
            {
                Buffer.BlockCopy(data, 0x1D2440, Model.Data, 0x1D2440, 0x924);
                Buffer.BlockCopy(data, 0x24A000, Model.Data, 0x24A000, 0x6000);   // palettes
            }
            if (levels.Nodes["NPCs"].Checked)   // NPCs
            {
                Buffer.BlockCopy(data, 0x148000, Model.Data, 0x148000, 0x8000);
                Buffer.BlockCopy(data, 0x1DB800, Model.Data, 0x1DB800, 0xE00);
                Buffer.BlockCopy(data, 0x1DDE00, Model.Data, 0x1DDE00, 0x200);
            }
            if (levels.Nodes["Exits"].Checked)   // Exits
            {
                Buffer.BlockCopy(data, 0x1D2D64, Model.Data, 0x1D2D64, 0x1BA1);
            }
            if (levels.Nodes["Events"].Checked)   // events
            {
                Buffer.BlockCopy(data, 0x20E000, Model.Data, 0x20E000, 0x2000);
            }
            if (levels.Nodes["Overlaps"].Checked)   // overlaps
            {
                Buffer.BlockCopy(data, 0x1D4905, Model.Data, 0x1D4905, 0x15B8);
            }
            if (levels.Nodes["Tilemaps"].Checked)   // tilemaps
            {
                Buffer.BlockCopy(data, 0x160000, Model.Data, 0x160000, 0x48000);
            }
            if (levels.Nodes["Tilesets"].Checked)   // tilesets
            {
                Buffer.BlockCopy(data, 0x3B0000, Model.Data, 0x3B0000, 0x2C000);
            }
            if (levels.Nodes["TileMods"].Checked)
            {
                Buffer.BlockCopy(data, 0x1D5EBD, Model.Data, 0x1D5EBD, 0x2EF3);
            }
            if (levels.Nodes["SolidMods"].Checked)
            {
                Buffer.BlockCopy(data, 0x1D8DB0, Model.Data, 0x1D8DB0, 0xCFF);
            }
            if (levels.Nodes["Graphics"].Checked)   // graphics
            {
                Buffer.BlockCopy(data, 0x0A0000, Model.Data, 0x0A0000, 0x60000);
            }
            if (levels.Nodes["SolidityMaps"].Checked)   // physical maps
            {
                Buffer.BlockCopy(data, 0x1B0000, Model.Data, 0x1B0000, 0x18000);
            }
            if (levels.Nodes["Battlefields"].Checked)   // battlefields
            {
                Buffer.BlockCopy(data, 0x39B644, Model.Data, 0x39B644, 0x200);
                Buffer.BlockCopy(data, 0x34D000, Model.Data, 0x34D000, 0x3000); // palettes
            }
            if (levels.Nodes["BattlefieldTilesets"].Checked)   // battlefield tilesets
            {
                Buffer.BlockCopy(data, 0x150000, Model.Data, 0x150000, 0x10000);
            }
            if (levels.Nodes["BattlefieldGraphics"].Checked)   // battlefield graphics
            {
                Buffer.BlockCopy(data, 0x110000, Model.Data, 0x110000, 0x36000);
            }


            // SCRIPTS
            if (scripts.Nodes["EventScripts"].Checked)   // event scripts
            {
                Buffer.BlockCopy(data, 0x1E0000, Model.Data, 0x1E0000, 0x2E000);
            }
            if (scripts.Nodes["ActionScripts"].Checked)   // action scripts
            {
                Buffer.BlockCopy(data, 0x210000, Model.Data, 0x210000, 0xC000);
            }
            if (scripts.Nodes["BattleScripts"].Checked)   // battle scripts
            {
                Buffer.BlockCopy(data, 0x3930AA, Model.Data, 0x3930AA, 0x294A);
            }
            if (scripts.Nodes["AnimationScripts"].Checked)   // animation scripts
            {
                Buffer.BlockCopy(data, 0x350000, Model.Data, 0x350000, 0x10000);
                Buffer.BlockCopy(data, 0x3A6000, Model.Data, 0x3A6000, 0xA000); // battle events
            }


            // SPRITES
            if (sprites.Nodes["Sprites"].Checked)   // sprites
            {
                Buffer.BlockCopy(data, 0x250000, Model.Data, 0x250000, 0x1000);
                Buffer.BlockCopy(data, 0x251800, Model.Data, 0x251800, 0x1400);
                Buffer.BlockCopy(data, 0x253000, Model.Data, 0x253000, 0xDD000);    // everything else
                Buffer.BlockCopy(data, 0x360000, Model.Data, 0x360000, 0x10000);    // everything else
            }
            if (sprites.Nodes["SpellEffects"].Checked)   // spell effects
            {
                Buffer.BlockCopy(data, 0x251000, Model.Data, 0x251000, 0x200);  // effects
                Buffer.BlockCopy(data, 0x252C00, Model.Data, 0x252C00, 0xC0);   // main data pointers
                Buffer.BlockCopy(data, 0x330000, Model.Data, 0x330000, 0x1D000);    // main data
            }
            if (sprites.Nodes["Dialogues"].Checked)   // dialogues
            {
                Buffer.BlockCopy(data, 0x006935, Model.Data, 0x006935, 0x8);    // compression table pointers
                Buffer.BlockCopy(data, 0x220000, Model.Data, 0x220000, 0x29140);    //dialogues
                Buffer.BlockCopy(data, 0x37E000, Model.Data, 0x37E000, 0x2000); // pointers
                Buffer.BlockCopy(data, 0x396554, Model.Data, 0x396554, 0x2D7D); // battle dialogues
            }
            if (sprites.Nodes["FontsBackgrounds"].Checked)   // fonts, backgrounds
            {
                Buffer.BlockCopy(data, 0x249140, Model.Data, 0x249140, 0xEC0);
                Buffer.BlockCopy(data, 0x37C000, Model.Data, 0x37C000, 0x2000);
                Buffer.BlockCopy(data, 0x3DF000, Model.Data, 0x3DF000, 0x1000);
            }
            if (sprites.Nodes["WorldMapTilesets"].Checked)   // world map tilesets
            {
                Buffer.BlockCopy(data, 0x3E0000, Model.Data, 0x3E0000, 0xF800);
            }
            if (sprites.Nodes["WorldMaps"].Checked)   // world maps
            {
                Buffer.BlockCopy(data, 0x3EF800, Model.Data, 0x3EF800, 0x3AF);
                Buffer.BlockCopy(data, 0x3EFD00, Model.Data, 0x3EFD00, 0x220);  // map point names
            }


            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
