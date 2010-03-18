using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private LevelMap[] levelMaps;
        private LevelMap levelMap; public LevelMap LevelMap { get { return levelMap; } }

        private PaletteSet[] paletteSets;
        private PaletteSet paletteSet;

        private TileMap tileMap;
        private PhysicalMap physicalMap;

        private int currentColor;

        private int[] paletteSetPixels;
        private Bitmap paletteSetImage;

        // palette effects
        private Stack<int[]> colorReds = new Stack<int[]>();
        private Stack<int[]> colorGreens = new Stack<int[]>();
        private Stack<int[]> colorBlues = new Stack<int[]>();
        private Stack<int[]> redoColorReds = new Stack<int[]>();
        private Stack<int[]> redoColorGreens = new Stack<int[]>();
        private Stack<int[]> redoColorBlues = new Stack<int[]>();

        private string[] graphicSetNames = new string[]
        {
            "{NONE}",
            "Keep walls",
            "Keep wall decor",
            "Keep doormat, doors",
            "Rope bridge, lava",
            "Keep window grates",
            "Gargoyles and pillars",
            "Barrel Volcano",
            "Royal Bus",
            "Kingdom houses",
            "Castle exterior",
            "Castle doors, fireplace",
            "Keep turrets",
            "Keep gargoyle hill",
            "Keep ground",
            "Keep body",
            "Keep body edges",
            "House interior",
            "Grates, stoves",
            "Crates, boxes",
            "Beds",
            "Shacks interior",
            "House exterior",
            "House doors",
            "Mines plywood",
            "Mines crates, lanterns",
            "Town decor",
            "Castle walls",
            "Castle wall decor",
            "Castle interior",
            "Tower wall decor",
            "Tower curtains",
            "Casino interior",
            "Tower floor",
            "____",
            "Forest terrain",
            "Forest tree trunks",
            "Forest battlefield",
            "Forest dirt",
            "Seashells",
            "Ship walls,doors",
            "Ship interior",
            "Ship pipes",
            "Shark emblem",
            "Doors",
            "Desert decor",
            "____",
            "Temple floors",
            "Temple walls",
            "Temple pillars",
            "Temple steps",
            "Shacks",
            "Mountain",
            "Mountain decor",
            "Mines floor",
            "Mines railing",
            "Stalactites/stalagmites",
            "Molten lava",
            "Arrow signs",
            "Palm trees, hills 1",
            "Palm trees, seat",
            "Seashore rocks",
            "Seashore cliffs",
            "Dojo walls, floor",
            "Grassland hills",
            "Grassland grass",
            "Grassland ground",
            "Pipehouse roof",
            "Pipehouse porch",
            "Tower, exterior",
            "Tower, entrance 1",
            "____",
            "Palm trees, hills 2",
            "Tower, entrance 2",
            "Seashore Ship",
            "Yo’ster Isle",
            "Marrymore Scene",
            "Ground puddle",
            "Plains hills, trees",
            "Plains ground, rock",
            "Rotating flowers",
            "Countryside",
            "____",
            "Plains escarpment",
            "Booster Hill sand",
            "Booster Hill cactus",
            "Booster Hill BG",
            "Nimbus Castle, exterior",
            "Nimbus leaves",
            "Nimbus leaves, briar",
            "Exor Battlefield",
            "Exor's hilt",
            "Exor's head",
            "Exor's face",
            "Exor's arms",
            "Ground/Mist",
            "“Hollow” sign",
            "Nimbus exterior",
            "Nimbus Castle walls",
            "Nimbus Castle interior 1",
            "Nimbus Castle interior 2",
            "Smithy Factory, floor",
            "Smithy Factory, pillar top",
            "Smithy Factory, pillar lower",
            "Smithy Factory, pillar floor",
            "Conveyor belts",
            "Seashore Ship, seafloor",
            "Sanctuary walls",
            "Sanctuary organ",
            "Nimbus house interior 1",
            "Nimbus house interior 2",
            "The Blade",
            "Shelly, nest",
            "Birdo's egg, nest",
            "Keep, throne walls",
            "Keep, throne steps",
            "Keep, throne floor",
            "Keep, throne gargoyles",
            "Chandeliers",
            "____",
            "River water",
            "Star Hill exterior",
            "Star Hill decor",
            "Vista Hill Keep",
            "Beanstalks",
            "Seashore Sunset",
            "Factory floor, crane",
            "Factory structures",
            "Stump battlefield top",
            "Stump battlefield lower",
            "Factory conveyor belts",
            "Mist/clouds",
            "Beanstalk leaf (top)",
            "Beanstalk leaf (lower)",
            "Beanstalk vine (top)",
            "Beanstalk leaf (right)",
            "Ship cellar (top)",
            "Ship cellar (bottom)",
            "Ship, barrels",
            "Mines interior",
            "Factory walls",
            "Keep repairs",
            "Czar Dragon gargoyles",
            "Grasslands grass",
            "Grasslands hills",
            "Mountain bushes",
            "House interior corners",
            "Tower, backdoor",
            "Water sewer walls",
            "Tower balcony clouds",
            "Beanstalk leaf (left)",
            "Castle candle holders",
            "Beanstalk clouds",
            "Dirt mountains",
            "Dirt mountains",
            "Tower balcony top",
            "Tower balcony lower",
            "Countdown",
            "Sewers back wall",
            "____palette tiles",
            "Nimbus Castle interior 3",
            "Birdo's nest egg",
            "Birdo's nest",
            "Nimbus briar",
            "Nimbus leaves",
            "____forest vines",
            "____unknown",
            "Town 2, exterior",
            "Keep carpet, walls",
            "Town 2, decor",
            "Forest path",
            "Level-Up FG",
            "Menu BG 1",
            "Menu BG 2",
            "Plains palm trees",
            "Sea Enclave",
            "Sanctuary organ",
            "Level-Up BG",
            "Star Hill",
            "Beach rocks, sunset",
            "Blade Roof",
            "Blade Roof, BG",
            "Blade Roof, BG",
            "Giant snake body",
            "Desert cactus, floor",
            "Factory floor/walls",
            "Factory chains/bolts",
            "Factory structure",
            "Smithy 2, head/pipes",
            "Smithy 2, small heads",
            "Smithy 2, big heads",
            "Culex battlefield BG",
            "Factory metals",
            "Factory chains/bolts",
            "Nimbus throne",
            "Yo’ster Isle flowers",
            "Desk, floors, boxes",
            "Count Down",
            "____",
            "Vista Hill Exor"
        };
        private string[] tileSetNames = new string[]
        {
            "Houses, inside  (L1)",
            "Houses, inside  (L2)",
            "--------",
            "Keep, puzzles (L2)",
            "Towns 1 (L1)",
            "Towns 1 (L2)",
            "Grasslands 1 (L1)",
            "Towns 2 (L1)",
            "Towns 2 (L2)",
            "Sewers (L1)",
            "Sewers (L2)",
            "Keep, outside (L1)",
            "--------",
            "--------",
            "Tower, entrance (L1)",
            "Tower, entrance (L2)",
            "Keep, puzzles (L1)",
            "Keep, inside (L1,2)",
            "Pipe Rooms (L1,2)",
            "Mansion (L1)",
            "Mansion (L2)",
            "Forest Maze (L1)",
            "Forest Maze (L2)",
            "Sunken Ship (L1)",
            "Sunken Ship (L2)",
            "Mountains (L1)",
            "Mountains (L2)",
            "Underground (L1,2)",
            "Underground (L1,2)",
            "Tower, inside (L1)",
            "Tower, inside (L2)",
            "Seashore (L1)",
            "Seashore (L2)",
            "Plains (L1,2)",
            "Underground 2 (L1)",
            "Underground 2 (L2)",
            "Riverside (L1)",
            "Riverside (L2)",
            "Clouds (L1)",
            "Clouds (L2)",
            "--------",
            "Culex (L1)",
            "Culex (L2)",
            "Grasslands 2 (L1)",
            "Grasslands 2 (L2)",
            "Waterfall (L1)",
            "Waterfall (L2)",
            "Nimbus Castle (L1)",
            "Nimbus Castle (L2)",
            "Yo'ster Isle (L1)",
            "Yo'ster Isle (L2)",
            "Smithy Factory (L1,2)",
            "--------",
            "--------",
            "Count Down (L1)",
            "--------",
            "Sanctuary (L1)",
            "Sanctuary (L2)",
            "Keep, inside (L1,2)",
            "--------",
            "--------",
            "Shacks (L1)",
            "Grasslands 1 (L2)",
            "Keep, outside (L2)",
            "Keep, throne (L1)",
            "Keep, throne (L2)",
            "Keep, inside (L1)",
            "Keep, inside (L2)",
            "Midas River (L2)",
            "Water Tunnels (L1)",
            "Water Tunnels (L2)",
            "Suite (L1)",
            "Volcano Map (L1)",
            "Star Hill (L1,2)",
            "Vista Hill (L1,2)",
            "Marrymore Scene (L1,2)",
            "Tower Balcony (L1,2)",
            "Bean Valley (L1)",
            "Bean Valley (L2)",
            "Nimbus Land (L1)",
            "Nimbus Land (L2)",
            "Volcano, Map (L2)",
            "Jinx's Dojo (L1,2)",
            "Factory Grounds (L1,2)",
            "--------",
            "Ending, Seashore (L1,2)",
            "Ending, Keep (L1,2)",
            "Ending, Toadofsky (L1)",
            "Ending, Toadofsky (L2)",
            "--------",
            "Ending, Yo'ster Isle (L1)",
            "Ending, Yo'ster Isle (L2)",
            "--------"
        };
        private string[] tileMapNames = new string[]
        {
            "Bowser’s Keep, outside (L2)",
            "--------",
            "Chapel Kitchen (L1)",
            "Chapel Kitchen (L2)",
            "Land's End 1 (L1)",
            "Land's End 1 (L2)",
            "Booster Tower 1 (L1)",
            "Booster Tower 1 (L2)",
            "--------",
            "--------",
            "Mushroom Kingdom houses (L1)",
            "Mushroom Kingdom houses (L2)",
            "Mario's Pad, outside (L1)",
            "Mario's Pad, outside (L2)",
            "Grate Guy's Casino, outside (L1)",
            "Grate Guy's Casino, outside (L2)",
            "Bowser's Keep 1 (L1)",
            "Bowser's Keep 1 (L2)",
            "Forest Maze 1 (L1)",
            "Forest Maze 1 (L2)",
            "--------",
            "--------",
            "Rose Town (L1)",
            "Rose Town (L2)",
            "Kero Sewers 1 (L1)",
            "Kero Sewers 1 (L2)",
            "--------",
            "--------",
            "Tadpole Pond 1 (L1)",
            "Tadpole Pond 1 (L2)",
            "Beach (L1)",
            "Beach (L2)",
            "Castle Rooms (L1)",
            "Castle Rooms (L2)",
            "Sunken Ship 1 (L1)",
            "Sunken Ship 1 (L2)",
            "Forest Maze 1 (L1)",
            "Forest Maze 1 (L2)",
            "Forest Maze 2 (L1)",
            "Forest Maze 2 (L2)",
            "Forest Maze 3 (L1)",
            "Forest Maze 3 (L2)",
            "--------",
            "--------",
            "Sunken Ship 2 (L1)",
            "Sunken Ship 2 (L2)",
            "Debug Room (L1)",
            "Debug Room (L2)",
            "Barrel Volcano 1 (L1)",
            "Barrel Volcano 1 (L2)",
            "Barrel Volcano 2 (L1)",
            "Barrel Volcano 2 (L2)",
            "Kero Sewers 2 (L1)",
            "Kero Sewers 2 (L2)",
            "Rose Town houses (L1)",
            "Rose Town houses (L2)",
            "Booster Pass secret (L1)",
            "Booster Pass secret (L2)",
            "Booster Tower entrance (L1)",
            "Booster Tower entrance (L2)",
            "Seashore (L1)",
            "Seashore (L2)",
            "Booster Tower 1 (L1)",
            "Booster Tower 1 (L2)",
            "Mushroom Kingdom (L1)",
            "Mushroom Kingdom (L2)",
            "Bowser's Keep outside(L1)",
            "--------",
            "Seaside Town houses (L1)",
            "Seaside Town houses (L2)",
            "Moleville shacks (L1)",
            "Moleville shacks (L2)",
            "Forest Maze underground (L1)",
            "Forest Maze underground (L2)",
            "Forest Maze, area 7 (L1)",
            "Forest Maze, area 7 (L2)",
            "Land's End underground (L1)",
            "Land's End underground (L2)",
            "Moleville Mines 1 (L1)",
            "Moleville Mines 1 (L2)",
            "--------",
            "--------",
            "--------",
            "--------",
            "Land's End grasslands (L1)",
            "Land's End grasslands (L2)",
            "Moleville Mines 2 (L1)",
            "Moleville Mines 2 (L2)",
            "Moleville Mines 3 (L1)",
            "Moleville Mines 3 (L2)",
            "--------",
            "--------",
            "Plains (L1)",
            "Plains (L2)",
            "Booster Hill (L1)",
            "Booster Hill (L2)",
            "Tadpole Pond 2 (L1)",
            "Tadpole Pond 2 (L2)",
            "Clouds (L1)",
            "Clouds (L2)",
            "--------",
            "--------",
            "Bowser's Keep 2 (L1)",
            "Bowser's Keep 2 (L2)",
            "___forest (L1)",
            "___forest (L2)",
            "Midas River (L1)",
            "Midas River (L2)",
            "Yo'ster Isle (L1)",
            "Yo'ster Isle (L2)",
            "Suite (L1)",
            "Suite (L2)",
            "Waterfall (L1)",
            "Waterfall (L2)",
            "___underground (L1)",
            "___underground (L2)",
            "Rose Way (L1)",
            "Rose Way (L2)",
            "--------",
            "--------",
            "Marrymore (L1)",
            "Marrymore (L2)",
            "Nimbus Castle 1 (L1)",
            "Nimbus Castle 1 (L2)",
            "Nimbus Castle 2 (L1)",
            "Nimbus Castle 2 (L2)",
            "Bowser's Keep Bridge (L1)",
            "Bowser's Keep Bridge (L2)",
            "Sea (L1)",
            "Sea (L2)",
            "Pipe Vault (L1)",
            "Pipe Vault (L2)",
            "--------",
            "--------",
            "Booster Tower balcony (L1)",
            "Beanstalks (L1)",
            "Smithy Factory 1 (L1)",
            "Smithy Factory 1 (L2)",
            "Smithy Factory 2 (L1)",
            "Smithy Factory 2 (L2)",
            "Smithy Factory 3 (L1)",
            "Smithy Factory 3 (L2)",
            "Nimbus Land houses (L1)",
            "Nimbus Land houses (L2)",
            "Star Hill 2 (L1)",
            "Star Hill 2 (L2)",
            "Bean Valley pipes (L1)",
            "Bean Valley pipes (L2)",
            "--------",
            "--------",
            "Chapel, main hall (L1)",
            "Chapel, main hall (L2)",
            "Chapel sanctuary (L1)",
            "Chapel sanctuary (L2)",
            "Belome Temple 1 (L1)",
            "Belome Temple 1 (L2)",
            "--------",
            "--------",
            "--------",
            "--------",
            "Bandit's Way 1 (L1)",
            "Bandit's Way 1 (L2)",
            "Bandit's Way 2 (L1)",
            "Bandit's Way 2 (L2)",
            "Mario's Pipehouse (L1)",
            "Mario's Pipehouse (L2)",
            "Mushroom Way 1 (L1)",
            "Mushroom Way 1 (L2)",
            "--------",
            "--------",
            "Kero Sewers, area 1 (L1)",
            "Kero Sewers, area 1 (L2)",
            "Rose Way, area 1 (L1)",
            "Rose Way, area 2 (L2)",
            "Midas River tunnels (L1)",
            "Midas River tunnels (L2)",
            "Booster Pass 1 (L1)",
            "Booster Pass 1 (L2)",
            "Moleville (L1)",
            "Moleville (L2)",
            "Volcano Map (L1)",
            "Volcano Map (L2)",
            "Sunken Ship 3 (L1)",
            "Sunken Ship 3 (L2)",
            "Vista Hill (L1)",
            "Vista Hill (L2)",
            "Marrymore Scene (L1)",
            "Marrymore Scene (L2)",
            "Bean Valley (L1)",
            "Bean Valley (L2)",
            "Beanstalks (L2)",
            "Land's End Underground 2 (L1)",
            "Land's End Underground 2 (L2)",
            "Land's End Desert (L1)",
            "Land's End Desert (L2)",
            "Barrel Volcano 1 (L1)",
            "Barrel Volcano 1 (L2)",
            "Jinx's Dojo (L1)",
            "Factory Grounds 1 (L1)",
            "Monstro Town houses (L1)",
            "Monstro Town houses (L2)",
            "Monstro Town (L1)",
            "Monstro Town (L2)",
            "Bowser's Keep 6-doors 1 (L1)",
            "Bowser's Keep 6-doors 1 (L2)",
            "Culex's Room (L1)",
            "Culex's Room (L2)",
            "Bowser's Keep 6-doors 2 (L1)",
            "Bowser's Keep 6-doors 2 (L2)",
            "Bowser's Keep 3 (L1)",
            "Bowser's Keep 3 (L2)",
            "Bowser's Keep 6-doors 3 (L1)",
            "Bowser's Keep 6-doors 3 (L2)",
            "Bowser's Keep, Magikoopa (L1)",
            "Bowser's Keep, Magikoopa (L1)",
            "Bowser's Keep 6-doors 4 (L1)",
            "Bowser's Keep 6-doors 4 (L2)",
            "Bowser's Keep 6-doors 5 (L1)",
            "Bowser's Keep 6-doors 5 (L2)",
            "Ending: Seashore (L1 & 2)",
            "Factory Grounds 1 (L2)",
            "Factory Grounds 2 (L1)",
            "Factory Grounds 2 (L2)",
            "Ending: Keep repairs (L1)",
            "Ending: Keep repairs (L2)",
            "Ending: Toadofsky (L1)",
            "Ending: Toadofsky (L2)",
            "Bowser's Keep 4 (L1)",
            "Bowser's Keep 4 (L2)",
            "Nimbus clouds 2 (L1)",
            "Nimbus clouds 2 (L2)",
            "Smithy Factory 4 (L1)",
            "Smithy Factory 4 (L2)",
            "--------",
            "Ending: Yo'ster Isle (L1)",
            "Ending: Yo'ster Isle (L2)",
            "--------",
            "___nothing (L1)",
            "___nothing (L2)",
            "Grate Guy's Casino (L1)",
            "Grate Guy's Casino (L2)",
            "Star Hill 1 (L1)",
            "Star Hill 1 (L2)",
            "--------",
            "--------"
        };

        #endregion

        #region Methods

        private void InitializeMapProperties()
        {
            updatingProperties = true;
            currentColor = (int)numericUpDown8.Value;

            levelMap = levelMaps[levels[currentLevel].LevelMap];
            paletteSet = paletteSets[levelMaps[levels[currentLevel].LevelMap].PaletteSet];

            this.mapNum.Value = levels[currentLevel].LevelMap;

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

            this.mapPaletteRedNum.Value = paletteSet.PaletteColorRed[currentColor];
            this.mapPaletteGreenNum.Value = paletteSet.PaletteColorGreen[currentColor];
            this.mapPaletteBlueNum.Value = paletteSet.PaletteColorBlue[currentColor];

            this.mapPaletteRedBar.Value = paletteSet.PaletteColorRed[currentColor];
            this.mapPaletteGreenBar.Value = paletteSet.PaletteColorGreen[currentColor];
            this.mapPaletteBlueBar.Value = paletteSet.PaletteColorBlue[currentColor];

            this.pictureBoxColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(mapPaletteRedNum.Value)))), ((int)(((byte)(mapPaletteGreenNum.Value)))), ((int)(((byte)(mapPaletteBlueNum.Value)))));

            updatingProperties = false;

        }
        private void UpdateCurrentColor()
        {
            currentColor = (int)numericUpDown8.Value;

            this.mapPaletteRedNum.Value = paletteSet.PaletteColorRed[currentColor];
            this.mapPaletteGreenNum.Value = paletteSet.PaletteColorGreen[currentColor];
            this.mapPaletteBlueNum.Value = paletteSet.PaletteColorBlue[currentColor];

            this.mapPaletteRedBar.Value = paletteSet.PaletteColorRed[currentColor];
            this.mapPaletteGreenBar.Value = paletteSet.PaletteColorGreen[currentColor];
            this.mapPaletteBlueBar.Value = paletteSet.PaletteColorBlue[currentColor];

            this.pictureBoxColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(mapPaletteRedNum.Value)))), ((int)(((byte)(mapPaletteGreenNum.Value)))), ((int)(((byte)(mapPaletteBlueNum.Value)))));
        }

        // set images
        private void PaletteChange()
        {
            if (paletteAutoUpdate.Checked)
            {
                fullUpdate = true;
                UpdateLevel();
            }
            else
                UpdateCurrentColor();
        }
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
            return DrawImageFromIntArr(pixels, s.Width, s.Height);
        }

        private void DecompressLevelData()
        {
            pBar = new ProgressBar(this.model, model.Data, "DECOMPRESSING LEVEL DATA...", 890);
            pBar.Show();

            int bank = 0;
            int pointer = 0;
            int offset = 0;
            int temp = 0;
            int length = 0;
            string labelText;

            temp = BitManager.GetShort(model.Data, 0x0A0000);
            for (int i = 0, j = 0; i < 272; i++)
            {
                j = i * 2;
                for (int k = 0x0A0000; k < 0x150000; k += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, k);
                    if (j >= temp) j -= temp;
                    else { bank = k; break; }
                }

                pointer = BitManager.GetShort(model.Data, bank + j);
                offset = bank + pointer + 1;

                model.GraphicSets[i] = model.Decompress(offset, 0x2000);

                if (model.GraphicSets[i] == null)
                {
                    model.GraphicSets[i] = new byte[0x2000];
                    //MessageBox.Show("Graphic Set " + i.ToString() + " is null. Using empty array to accord.");
                }

                labelText = "DECOMPRESSING GRAPHIC SET 0x" + i.ToString("X3");
                pBar.PerformStep(labelText);
            }

            temp = BitManager.GetShort(model.Data, 0x3B0000);
            for (int i = 0, j = 0; i < 125; i++)
            {
                j = i * 2;
                for (int k = 0x3B0000; k < 0x3E0000; k += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, k);
                    if (j >= temp) j -= temp;
                    else { bank = k; break; }
                }

                pointer = BitManager.GetShort(model.Data, bank + j);
                offset = bank + pointer + 1;

                model.TileSets[i] = model.Decompress(offset, 0x1000);

                if (model.TileSets[i] == null)
                {
                    model.TileSets[i] = new byte[0x1000];
                    //MessageBox.Show("Tile Set " + i.ToString() + " is null. Using empty array to accord.");
                }

                labelText = "DECOMPRESSING TILE SET 0x" + i.ToString("X3");
                pBar.PerformStep(labelText);
            }

            for (int i = 0; i < 64; i++)
            {
                bank = 0x150000;

                pointer = BitManager.GetShort(model.Data, bank + (i * 2));
                offset = bank + pointer + 1;

                model.TileSetsBF[i] = model.Decompress(offset, 0x2000);

                if (model.TileSetsBF[i] == null)
                {
                    model.TileSetsBF[i] = new byte[0x2000];
                    //MessageBox.Show("Battlefield " + i.ToString() + " is null. Using empty array to accord.");
                }

                labelText = "DECOMPRESSING BATTLEFIELD 0x" + i.ToString("X3");
                pBar.PerformStep(labelText);
            }

            temp = BitManager.GetShort(model.Data, 0x160000);
            for (int i = 0, j = 0; i < 309; i++)
            {
                if (i < 0x40) length = 0x1000;
                else length = 0x2000;

                j = i * 2;
                for (int k = 0x160000; k < 0x1B0000; k += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, k);
                    if (j >= temp) j -= temp;
                    else { bank = k; break; }
                }

                pointer = BitManager.GetShort(model.Data, bank + j);
                offset = bank + pointer + 1;

                model.TileMaps[i] = model.Decompress(offset, length);

                if (model.TileMaps[i] == null)
                {
                    model.TileMaps[i] = new byte[i < 0x40 ? 0x1000 : 0x2000];
                    //MessageBox.Show("Tile Map " + i.ToString() + " is null. Using empty array to accord.");
                }

                labelText = "DECOMPRESSING TILE MAP 0x" + i.ToString("X3");
                pBar.PerformStep(labelText);
            }

            temp = BitManager.GetShort(model.Data, 0x1B0000);
            for (int i = 0, j = 0; i < 120; i++)
            {
                j = i * 2;
                for (int k = 0x1B0000; k < 0x1D0000; k += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, k);
                    if (j >= temp) j -= temp;
                    else { bank = k; break; }
                }

                pointer = BitManager.GetShort(model.Data, bank + j);
                offset = bank + pointer + 1;

                model.PhysicalMaps[i] = model.Decompress(offset, 0x20C2);

                if (model.PhysicalMaps[i] == null)
                {
                    model.PhysicalMaps[i] = new byte[0x20C2];
                    //MessageBox.Show("Physical Map " + i.ToString() + " is null. Using empty array to accord.");
                }

                labelText = "DECOMPRESSING PHYSICAL MAP 0x" + i.ToString("X3");
                pBar.PerformStep(labelText);
            }

            pBar.Close();
        }
        private void RecompressLevelData()
        {
            pBar = new ProgressBar(this.model, model.Data, "COMPRESSING AND SAVING LEVEL DATA...", 890); // + whatever else
            pBar.Show();

            int bank, index, size, bankIndex, temp;
            ushort offset;
            byte[] compressed = new byte[0x2000];
            byte[] data = model.Data;

            #region Graphic Sets
            // GRAPHIC SETS //

            // store original
            bank = 0x0A0000; // Set bank pointer
            byte[][] original = new byte[model.GraphicSets.Length][];
            temp = BitManager.GetShort(model.Data, 0x0A0000);
            for (int i = 0, a = 0; i < 272; i++)
            {
                a = i * 2;
                for (int b = 0x0A0000; b < 0x150000; b += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == BitManager.GetShort(model.Data, bank))
                {
                    if (bank < 0x140000)
                    {
                        size = 0x10000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x6000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0x5FFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = BitManager.GetShort(model.Data, bank + a + 2) - BitManager.GetShort(model.Data, bank + a);

                original[i] = BitManager.GetByteArray(model.Data, bank + BitManager.GetShort(model.Data, bank + a), size);
            }

            // Graphic Sets - bank 0x0A

            bank = 0x0A0000; // Set bank pointer
            index = 0; // Set initial index for this bank
            bankIndex = 0;
            offset = 0x009C; // Set initial offset for this bank

            for (; index < 78; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0A Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0A Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0A GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0B
            bank = 0x0B0000;
            index = 78; // To 163
            bankIndex = 0;
            offset = 0x20;

            for (; index < 94; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0B Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0B Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0B GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0C
            bank = 0x0C0000;
            index = 94; // To 163
            bankIndex = 0;
            offset = 0x22;

            for (; index < 111; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0C Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0C Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0C GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0D
            bank = 0x0D0000;
            index = 111; // To 163
            bankIndex = 0;
            offset = 0x24;

            for (; index < 129; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0D Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0D Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0D GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0E
            bank = 0x0E0000;
            index = 129; // To 163
            bankIndex = 0;
            offset = 0x24;

            for (; index < 147; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0E Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0E Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0E GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x0F
            bank = 0x0F0000;
            index = 147; // To 163
            bankIndex = 0;
            offset = 0x28;

            for (; index < 167; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0F Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x0F Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x0F GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x10
            bank = 0x100000;
            index = 167; // To 163
            bankIndex = 0;
            offset = 0x22;

            for (; index < 184; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x10 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x10 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x10 GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x11
            bank = 0x110000;
            index = 184; // To 163
            bankIndex = 0;
            offset = 0x28;

            for (; index < 204; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x11 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x11 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x11 GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x12
            bank = 0x120000;
            index = 204; // To 163
            bankIndex = 0;
            offset = 0x40;

            for (; index < 236; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x12 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x12 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x12 GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x13
            bank = 0x130000;
            index = 236; // To 163
            bankIndex = 0;
            offset = 0x32;

            for (; index < 261; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x13 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x13 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x13 GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Graphic Sets - Bank 0x14
            bank = 0x140000;
            index = 261; // To 163
            bankIndex = 0;
            offset = 0x16;

            for (; index < 272; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditGraphicSets[index])
                {
                    model.EditGraphicSets[index] = false;

                    // Compress data
                    size = model.Compress(model.GraphicSets[index], compressed);
                    if (offset + size > 0x5FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x14 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x5FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x14 Graphic Sets too large to save \n Stopped saving at Graphic Set " + index.ToString());
                        size = model.Compress(new byte[model.GraphicSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x14 GRAPHIC SET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x6000 - offset]);
            #endregion

            tileMap.AssembleIntoModel();

            #region Tile Maps
            // TILEMAPS //

            // Bank 0x16 - 109 tilemaps Pointers 160000 - 1600D9 ENDS AT 16FFFF
            // store original
            bank = 0x160000; // Set bank pointer
            original = new byte[model.TileMaps.Length][];
            temp = BitManager.GetShort(model.Data, 0x160000);
            for (int i = 0, a = 0; i < 309; i++)
            {
                a = i * 2;
                for (int b = 0x160000; b < 0x1B0000; b += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == BitManager.GetShort(model.Data, bank))
                {
                    if (bank < 0x1A0000)
                    {
                        size = 0x10000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x8000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0x7FFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = BitManager.GetShort(model.Data, bank + a + 2) - BitManager.GetShort(model.Data, bank + a);

                original[i] = BitManager.GetByteArray(model.Data, bank + BitManager.GetShort(model.Data, bank + a), size);
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
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = model.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x16 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x16 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x16 TILEMAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x17 - 54 tilemaps Pointers 170000 - 17006B ENDS AT 17FFFF
            bank = 0x170000;
            index = 109; // To 163
            bankIndex = 0;
            offset = 0x6C;
            size = 0;

            for (; index < 163; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = model.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x17 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x17 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x17 TILEMAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x18 - 56 tilemaps Pointers 180000 - 18006F ENDS AT 18FFFF
            bank = 0x180000;
            index = 163; // To 219
            bankIndex = 0;
            offset = 0x70;
            size = 0;

            for (; index < 219; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = model.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x18 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x18 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x18 TILEMAP 0x" + index.ToString("X3"));

            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x19 - 56 tilemaps Pointers 190000 - 19006F ENDS AT 19FFFF
            bank = 0x190000;
            index = 219; // To 275
            bankIndex = 0;
            offset = 0x70;
            size = 0;

            for (; index < 275; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = model.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x19 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x19 TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x19 TILEMAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // Bank 0x1A - 34 tilemaps Pointers 1A0000 - 1A0043 ENDS at 1A7FFF
            bank = 0x1A0000;
            index = 275; // to 309
            bankIndex = 0;
            offset = 0x44;
            size = 0;

            for (; index < 309; index++, bankIndex++)
            {
                // Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileMaps[index])
                {
                    model.EditTileMaps[index] = false;

                    // Compress data
                    size = model.Compress(model.TileMaps[index], compressed);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1A TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x2000)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1A TileMaps too large to save \n Stopped saving at TileMap " + index.ToString());
                        size = model.Compress(new byte[model.TileMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x2000], compressed);
                    //MessageBox.Show("Could not save TileMap " + index.ToString() + " because it is greater than 0x2000 bytes.");
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x1A TILEMAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x8000 - offset]);
            #endregion

            #region Physical Maps
            /****PHYSICAL MAPS****/
            // store original
            bank = 0x1B0000;
            original = new byte[model.PhysicalMaps.Length][];
            temp = BitManager.GetShort(model.Data, 0x1B0000);
            for (int i = 0, a = 0; i < model.PhysicalMaps.Length; i++)
            {
                a = i * 2;
                for (int b = 0x1B0000; b < 0x1D0000; b += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == BitManager.GetShort(model.Data, bank))
                {
                    if (bank < 0x1C0000)
                    {
                        size = 0x10000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0x8000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0x7FFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = BitManager.GetShort(model.Data, bank + a + 2) - BitManager.GetShort(model.Data, bank + a);

                original[i] = BitManager.GetByteArray(model.Data, bank + BitManager.GetShort(model.Data, bank + a), size);
            }

            compressed = new byte[0x20C2];
            bank = 0x1B0000;
            index = 0;
            bankIndex = 0;
            offset = 0xA0;

            for (; index < 80; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditPhysicalMaps[index])
                {
                    model.EditPhysicalMaps[index] = false;

                    //Compress data
                    size = model.Compress(model.PhysicalMaps[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x1B Physical Maps too large to save \n Stopped saving at Physical Map " + index.ToString());
                        size = model.Compress(new byte[model.PhysicalMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x20C2)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1B Physical Maps too large to save \n Stopped saving at Physical Map " + index.ToString());
                        size = model.Compress(new byte[model.PhysicalMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x20C2], compressed);
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x1B PHYSICAL MAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x1C0000;
            index = 80;
            bankIndex = 0;
            offset = 0x50;

            for (; index < 120; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditPhysicalMaps[index])
                {
                    model.EditPhysicalMaps[index] = false;

                    //Compress data
                    size = model.Compress(model.PhysicalMaps[index], compressed);
                    if (offset + size > 0x7FFF)
                    {
                        MessageBox.Show("Bank 0x1C Physical Maps too large to save \n Stopped saving at Physical Map " + index.ToString());
                        size = model.Compress(new byte[model.PhysicalMaps[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else if (original[index].Length <= 0x20C2)
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0x7FFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x1C Physical Maps too large to save \n Stopped saving at Physical Map " + index.ToString());
                        size = model.Compress(new byte[model.PhysicalMaps[index].Length], compressed);
                    }
                }
                else
                {
                    // Compress data
                    size = model.Compress(new byte[0x20C2], compressed);
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x1C PHYSICAL MAP 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x8000 - offset]);
            #endregion

            #region Tile Sets
            /****TILESETS****/
            // store original
            bank = 0x150000;
            original = new byte[model.TileSetsBF.Length][];
            temp = BitManager.GetShort(model.Data, 0x150000);
            for (int i = 0, a = 0; i < model.TileSetsBF.Length; i++)
            {
                a = i * 2;
                if (a + 2 == BitManager.GetShort(model.Data, bank))
                {
                    size = 0x10000 - BitManager.GetShort(model.Data, bank + a);
                    for (int o = 0xFFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                        size--;
                }
                else
                    size = BitManager.GetShort(model.Data, bank + a + 2) - BitManager.GetShort(model.Data, bank + a);

                original[i] = BitManager.GetByteArray(model.Data, bank + BitManager.GetShort(model.Data, bank + a), size);
            }

            //Battlefields
            compressed = new byte[0x2000];
            bank = 0x150000;
            index = 0;
            bankIndex = 0;
            offset = 0x7A;

            for (; index < 61; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSetsBF[index])
                {
                    model.EditTileSetsBF[index] = false;

                    //Compress data
                    size = model.Compress(model.TileSetsBF[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x15 Battlefields too large to save \n Stopped saving at Battlefield " + index.ToString());
                        size = model.Compress(new byte[model.TileSetsBF[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x15 Battlefields too large to save \n Stopped saving at Battlefield " + index.ToString());
                        size = model.Compress(new byte[model.TileSetsBF[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x15 BATTLEFIELD 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            // store original
            bank = 0x3B0000;
            original = new byte[model.TileSets.Length][];
            temp = BitManager.GetShort(model.Data, 0x3B0000);
            for (int i = 0, a = 0; i < model.TileSets.Length; i++)
            {
                a = i * 2;
                for (int b = 0x3B0000; b < 0x3E0000; b += 0x010000)
                {
                    temp = BitManager.GetShort(model.Data, b);
                    if (a >= temp) a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == BitManager.GetShort(model.Data, bank))
                {
                    if (bank < 0x3D0000)
                    {
                        size = 0x10000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0xFFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = 0xC000 - BitManager.GetShort(model.Data, bank + a);
                        for (int o = 0xBFFF; BitManager.GetByte(model.Data, bank + o) != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = BitManager.GetShort(model.Data, bank + a + 2) - BitManager.GetShort(model.Data, bank + a);

                original[i] = BitManager.GetByteArray(model.Data, bank + BitManager.GetShort(model.Data, bank + a), size);
            }

            compressed = new byte[0x1000];
            bank = 0x3B0000;
            index = 0;
            bankIndex = 0;
            offset = 0x74;

            for (; index < 58; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = model.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x3B Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3B Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x3B TILESET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x3C0000;
            index = 58;
            bankIndex = 0;
            offset = 0x42;

            for (; index < 91; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = model.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xFFFF)
                    {
                        MessageBox.Show("Bank 0x3C Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xFFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3C Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x3C TILESET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0x10000 - offset]);

            bank = 0x3D0000;
            index = 91;
            bankIndex = 0;
            offset = 0x44;

            for (; index < 125; index++, bankIndex++)
            {
                //Write pointer offset
                BitManager.SetShort(data, bank + (bankIndex * 2), offset);

                // write new if edit flag
                if (model.EditTileSets[index])
                {
                    model.EditTileSets[index] = false;

                    //Compress data
                    size = model.Compress(model.TileSets[index], compressed);
                    if (offset + size > 0xBFFF)
                    {
                        MessageBox.Show("Bank 0x3D Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                    // Write data to rom
                    BitManager.SetByte(data, bank + offset, 1); offset++;
                }
                else
                {
                    size = original[index].Length; original[index].CopyTo(compressed, 0);
                    if (offset + size > 0xBFFF) // Do we pass the bounds of this bank?
                    {
                        MessageBox.Show("Bank 0x3D Tilesets too large to save \n Stopped saving at Tileset " + index.ToString());
                        size = model.Compress(new byte[model.TileSets[index].Length], compressed);
                    }
                }

                BitManager.SetByteArray(data, bank + offset, compressed, 0, size);
                offset += (ushort)size; // Move forward in bank
                pBar.PerformStep("COMPRESSING BANK 0x3D TILESET 0x" + index.ToString("X3"));
            }
            // fill up the rest of the bank with 0x00's
            BitManager.SetByteArray(data, bank + offset, new byte[0xC000 - offset]);
            #endregion

            pBar.Close();
        }

        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 8;
            y *= 8;

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
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
                    binWriter = new BinaryWriter(File.Open(path + "graphicSet." + i.ToString("X2") + ".bin", FileMode.Create));
                    binWriter.Write(model.GraphicSets[i]);
                    binWriter.Close();
                }
            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to save the graphic sets.\n\n" + ioexc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void graphicSetsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename = OpenDialogFile("Select the graphic set to import");

            if (filename == null)
                return;
            string num = filename.Substring(filename.LastIndexOf('.') - 2, 2);

            int index = Int32.Parse(num, System.Globalization.NumberStyles.HexNumber);

            try
            {
                FileInfo fInfo = new FileInfo(filename);

                if (fInfo.Length != 8192)
                {
                    MessageBox.Show("File is incorrect size, Graphic Sets are 8192 bytes");
                    return;
                }

                FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                model.GraphicSets[index] = br.ReadBytes((int)fInfo.Length);
                model.EditGraphicSets[index] = true;
                br.Close();
                fStream.Close();

                fullUpdate = true;
                UpdateLevel();

                return;

            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to Import the Graphic Set.\n\n" + ioexc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            levels[currentLevel].LevelMap = (int)mapNum.Value; // Set the levels mapNum to the new value

            InitializeMapProperties(); // Load the new Map properties
            if (!updatingLevel)
            {
                fullUpdate = true;
                UpdateLevel();
            }
        }
        private void mapGFXSet1Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet1Name.SelectedIndex == (int)mapGFXSet1Num.Value)
                {
                    levelMap.GraphicSetA = (byte)this.mapGFXSet1Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet1Name.SelectedIndex = (int)mapGFXSet1Num.Value;
                }
        }
        private void mapGFXSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet1Name.SelectedIndex == (int)mapGFXSet1Num.Value)
                {
                    levelMap.GraphicSetA = (byte)this.mapGFXSet1Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet1Num.Value = mapGFXSet1Name.SelectedIndex;
                }
        }
        private void mapGFXSet2Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet2Name.SelectedIndex == (int)mapGFXSet2Num.Value)
                {
                    levelMap.GraphicSetB = (byte)this.mapGFXSet2Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet2Name.SelectedIndex = (int)mapGFXSet2Num.Value;
                }
        }
        private void mapGFXSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet2Name.SelectedIndex == (int)mapGFXSet2Num.Value)
                {
                    levelMap.GraphicSetB = (byte)this.mapGFXSet2Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet2Num.Value = mapGFXSet2Name.SelectedIndex;
                }
        }
        private void mapGFXSet3Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet3Name.SelectedIndex == (int)mapGFXSet3Num.Value)
                {
                    levelMap.GraphicSetC = (byte)this.mapGFXSet3Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet3Name.SelectedIndex = (int)mapGFXSet3Num.Value;
                }
        }
        private void mapGFXSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet3Name.SelectedIndex == (int)mapGFXSet3Num.Value)
                {
                    levelMap.GraphicSetC = (byte)this.mapGFXSet3Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet3Num.Value = mapGFXSet3Name.SelectedIndex;
                }
        }
        private void mapGFXSet4Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet4Name.SelectedIndex == (int)mapGFXSet4Num.Value)
                {
                    levelMap.GraphicSetD = (byte)this.mapGFXSet4Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet4Name.SelectedIndex = (int)mapGFXSet4Num.Value;
                }
        }
        private void mapGFXSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet4Name.SelectedIndex == (int)mapGFXSet4Num.Value)
                {
                    levelMap.GraphicSetD = (byte)this.mapGFXSet4Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet4Num.Value = mapGFXSet4Name.SelectedIndex;
                }
        }
        private void mapGFXSet5Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet5Name.SelectedIndex == (int)mapGFXSet5Num.Value)
                {
                    levelMap.GraphicSetE = (byte)this.mapGFXSet5Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet5Name.SelectedIndex = (int)mapGFXSet5Num.Value;
                }
        }
        private void mapGFXSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSet5Name.SelectedIndex == (int)mapGFXSet5Num.Value)
                {
                    levelMap.GraphicSetE = (byte)this.mapGFXSet5Num.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSet5Num.Value = mapGFXSet5Name.SelectedIndex;
                }
        }
        private void mapGFXSetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSetL3Name.SelectedIndex == (int)mapGFXSetL3Num.Value)
                {
                    if (this.mapGFXSetL3Num.Value > 0x1b)
                    {
                        levelMap.GraphicSetL3 = (byte)0xff;
                        this.mapTilesetL3Num.Enabled = false;
                        this.mapTilesetL3Name.Enabled = false;
                        this.mapTilemapL3Num.Enabled = false;
                        this.mapTilemapL3Name.Enabled = false;
                        if (tabControl2.SelectedIndex == 2)
                            tabControl2.SelectedIndex = 0;
                    }
                    else
                    {
                        levelMap.GraphicSetL3 = (byte)this.mapGFXSetL3Num.Value;
                        this.mapTilesetL3Num.Enabled = true;
                        this.mapTilesetL3Name.Enabled = true;
                        this.mapTilemapL3Num.Enabled = true;
                        this.mapTilemapL3Name.Enabled = true;
                    }
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSetL3Name.SelectedIndex = (int)mapGFXSetL3Num.Value;
                }
        }
        private void mapGFXSetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapGFXSetL3Name.SelectedIndex == (int)mapGFXSetL3Num.Value)
                {
                    if (this.mapGFXSetL3Num.Value > 0x1b)
                    {
                        levelMap.GraphicSetL3 = (byte)0xff;
                        this.mapTilesetL3Num.Enabled = false;
                        this.mapTilesetL3Name.Enabled = false;
                        this.mapTilemapL3Num.Enabled = false;
                        this.mapTilemapL3Name.Enabled = false;
                    }
                    else
                    {
                        levelMap.GraphicSetL3 = (byte)this.mapGFXSetL3Num.Value;
                        this.mapTilesetL3Num.Enabled = true;
                        this.mapTilesetL3Name.Enabled = true;
                        this.mapTilemapL3Num.Enabled = true;
                        this.mapTilemapL3Name.Enabled = true;
                    }
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapGFXSetL3Num.Value = mapGFXSetL3Name.SelectedIndex;
                }
        }
        private void mapTilesetL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL1Name.SelectedIndex == (int)mapTilesetL1Num.Value)
                {
                    levelMap.TileSetL1 = (byte)this.mapTilesetL1Num.Value;

                    if (state.Layer1)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL1Name.SelectedIndex = (int)mapTilesetL1Num.Value;
                }
        }
        private void mapTilesetL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL1Name.SelectedIndex == (int)mapTilesetL1Num.Value)
                {
                    levelMap.TileSetL1 = (byte)this.mapTilesetL1Num.Value;
                    if (state.Layer1)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL1Num.Value = mapTilesetL1Name.SelectedIndex;
                }
        }
        private void mapTilesetL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL2Name.SelectedIndex == (int)mapTilesetL2Num.Value)
                {
                    levelMap.TileSetL2 = (byte)this.mapTilesetL2Num.Value;

                    if (state.Layer2)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL2Name.SelectedIndex = (int)mapTilesetL2Num.Value;
                }
        }
        private void mapTilesetL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL2Name.SelectedIndex == (int)mapTilesetL2Num.Value)
                {
                    levelMap.TileSetL2 = (byte)this.mapTilesetL2Num.Value;
                    if (state.Layer2)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL2Num.Value = mapTilesetL2Name.SelectedIndex;
                }
        }
        private void mapTilesetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL3Name.SelectedIndex == (int)mapTilesetL3Num.Value)
                {
                    levelMap.TileSetL3 = (byte)this.mapTilesetL3Num.Value;

                    if (state.Layer3)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL3Name.SelectedIndex = (int)mapTilesetL3Num.Value;
                }
        }
        private void mapTilesetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilesetL3Name.SelectedIndex == (int)mapTilesetL3Num.Value)
                {
                    levelMap.TileSetL3 = (byte)this.mapTilesetL3Num.Value;
                    if (state.Layer3)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilesetL3Num.Value = mapTilesetL3Name.SelectedIndex;
                }
        }
        private void mapTilemapL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL1Name.SelectedIndex == (int)mapTilemapL1Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL1 = (byte)this.mapTilemapL1Num.Value;

                    if (state.Layer1)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL1Name.SelectedIndex = (int)mapTilemapL1Num.Value;
                }
        }
        private void mapTilemapL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL1Name.SelectedIndex == (int)mapTilemapL1Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL1 = (byte)this.mapTilemapL1Num.Value;
                    if (state.Layer1)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL1Num.Value = mapTilemapL1Name.SelectedIndex;
                }

        }
        private void mapTilemapL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL2Name.SelectedIndex == (int)mapTilemapL2Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL2 = (byte)this.mapTilemapL2Num.Value;

                    if (state.Layer2)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL2Name.SelectedIndex = (int)mapTilemapL2Num.Value;
                }
        }
        private void mapTilemapL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL2Name.SelectedIndex == (int)mapTilemapL2Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL2 = (byte)this.mapTilemapL2Num.Value;
                    if (state.Layer2)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL2Num.Value = mapTilemapL2Name.SelectedIndex;
                }
        }
        private void mapTilemapL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL3Name.SelectedIndex == (int)mapTilemapL3Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL3 = (byte)this.mapTilemapL3Num.Value;

                    if (state.Layer3)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL3Name.SelectedIndex = (int)mapTilemapL3Num.Value;
                }
        }
        private void mapTilemapL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapTilemapL3Name.SelectedIndex == (int)mapTilemapL3Num.Value)
                {
                    tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

                    levelMap.TileMapL3 = (byte)this.mapTilemapL3Num.Value;
                    if (state.Layer3)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            UpdateLevel();
                        }
                }
                else
                {
                    mapTilemapL3Num.Value = mapTilemapL3Name.SelectedIndex;
                }
        }
        private void mapBattlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapBattlefieldName.SelectedIndex == (int)mapBattlefieldNum.Value)
                {
                    levelMap.Battlefield = (byte)this.mapBattlefieldNum.Value;
                }
                else
                {
                    mapBattlefieldName.SelectedIndex = (int)mapBattlefieldNum.Value;
                }
        }
        private void mapBattlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapBattlefieldName.SelectedIndex == (int)mapBattlefieldNum.Value)
                {
                    levelMap.Battlefield = (byte)this.mapBattlefieldNum.Value;
                }
                else
                {
                    mapBattlefieldNum.Value = mapBattlefieldName.SelectedIndex;
                }
        }
        private void mapPhysicalMapNum_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapPhysicalMapName.SelectedIndex == (int)mapPhysicalMapNum.Value)
                {
                    levelMap.PhysicalMap = (byte)this.mapPhysicalMapNum.Value;
                    if (state.PhysicalLayer)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            physicalMap = new PhysicalMap(levelMap,
                                    model,
                                    quadBasePixels,
                                    quadBlockPixels,
                                    halfQuadBlockPixels,
                                    stairsUpLeftLowPixels,
                                    stairsUpLeftHighPixels,
                                    stairsUpRightLowPixels,
                                    stairsUpRightHighPixels);
                            physicalMap.SetOrthographic();
                            physicalMap.DrawPhysicalMap();
                            pictureBoxLevel.Invalidate();
                        }
                }
                else
                {
                    mapPhysicalMapName.SelectedIndex = (int)mapPhysicalMapNum.Value;
                }
        }
        private void mapPhysicalMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapPhysicalMapName.SelectedIndex == (int)mapPhysicalMapNum.Value)
                {
                    levelMap.PhysicalMap = (byte)this.mapPhysicalMapNum.Value;
                    if (state.PhysicalLayer)
                        if (!updatingLevel)
                        {
                            fullUpdate = true;
                            physicalMap = new PhysicalMap(levelMap,
                                    model,
                                    quadBasePixels,
                                    quadBlockPixels,
                                    halfQuadBlockPixels,
                                    stairsUpLeftLowPixels,
                                    stairsUpLeftHighPixels,
                                    stairsUpRightLowPixels,
                                    stairsUpRightHighPixels);
                            physicalMap.SetOrthographic();
                            physicalMap.DrawPhysicalMap();
                            pictureBoxLevel.Invalidate();
                        }
                }
                else
                {
                    mapPhysicalMapNum.Value = mapPhysicalMapName.SelectedIndex;
                }
        }
        private void mapSetL3Priority_CheckedChanged(object sender, EventArgs e)
        {
            levelMap.TopPriorityL3 = mapSetL3Priority.Checked;
            if (!updatingLevel)
            {
                fullUpdate = true;
                UpdateLevel();
            }
            if (mapSetL3Priority.Checked) mapSetL3Priority.ForeColor = Color.Black;
            else mapSetL3Priority.ForeColor = Color.Gray;
        }
        private void mapPaletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            colorReds.Clear();
            colorGreens.Clear();
            colorBlues.Clear();
            redoColorReds.Clear();
            redoColorGreens.Clear();
            redoColorBlues.Clear();

            if (!updatingProperties)
                if (mapPaletteSetName.SelectedIndex == (int)mapPaletteSetNum.Value)
                {
                    levelMap.PaletteSet = (byte)this.mapPaletteSetNum.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapPaletteSetName.SelectedIndex = (int)mapPaletteSetNum.Value;
                }
        }
        private void mapPaletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                if (mapPaletteSetName.SelectedIndex == (int)mapPaletteSetNum.Value)
                {
                    levelMap.PaletteSet = (byte)this.mapPaletteSetNum.Value;
                    if (!updatingLevel)
                    {
                        fullUpdate = true;
                        UpdateLevel();
                    }
                }
                else
                {
                    mapPaletteSetNum.Value = mapPaletteSetName.SelectedIndex;
                }
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            updatingProperties = true;
            UpdateCurrentColor();
            palettePictureBox.Invalidate();
            updatingProperties = false;
        }
        private void mapPaletteRedBar_Scroll(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteRedBar.Value -= mapPaletteRedBar.Value % 8;

            if (mapPaletteRedNum.Value == mapPaletteRedBar.Value)
                {
                    paletteSet.PaletteColorRed[currentColor] = (byte)this.mapPaletteRedBar.Value;

                    if (currentColor < 111 && (currentColor & 15) == 15)
                        paletteSet.PaletteColorRed[currentColor + 1] = paletteSet.PaletteColorRed[currentColor];
                    if (currentColor != 0 && currentColor % 16 == 0)
                        paletteSet.PaletteColorRed[currentColor - 1] = paletteSet.PaletteColorRed[currentColor];

                    if (!updatingLevel)
                    {
                        PaletteChange();
                    }
                }
                else
                {
                    mapPaletteRedNum.Value = mapPaletteRedBar.Value;
                }
        }
        private void mapPaletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteRedNum.Value -= mapPaletteRedNum.Value % 8;

            if (mapPaletteRedBar.Value == (int)mapPaletteRedNum.Value)
            {
                paletteSet.PaletteColorRed[currentColor] = (byte)this.mapPaletteRedNum.Value;

                if (currentColor < 111 && (currentColor & 15) == 15)
                    paletteSet.PaletteColorRed[currentColor + 1] = paletteSet.PaletteColorRed[currentColor];
                if (currentColor != 0 && currentColor % 16 == 0)
                    paletteSet.PaletteColorRed[currentColor - 1] = paletteSet.PaletteColorRed[currentColor];

                if (!updatingLevel)
                {
                    PaletteChange();
                }
            }
            else
            {
                mapPaletteRedBar.Value = (int)mapPaletteRedNum.Value;
                mapPaletteRedBar_Scroll(null, null);
            }
        }
        private void mapPaletteGreenBar_Scroll(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteGreenBar.Value -= mapPaletteGreenBar.Value % 8;

            if (mapPaletteGreenNum.Value == mapPaletteGreenBar.Value)
                {
                    paletteSet.PaletteColorGreen[currentColor] = (byte)this.mapPaletteGreenBar.Value;

                    if (currentColor < 111 && (currentColor & 15) == 15)
                        paletteSet.PaletteColorGreen[currentColor + 1] = paletteSet.PaletteColorGreen[currentColor];
                    if (currentColor != 0 && currentColor % 16 == 0)
                        paletteSet.PaletteColorGreen[currentColor - 1] = paletteSet.PaletteColorGreen[currentColor];

                    if (!updatingLevel)
                    {
                        PaletteChange();
                    }
                }
                else
                {
                    mapPaletteGreenNum.Value = mapPaletteGreenBar.Value;
                }
        }
        private void mapPaletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteGreenNum.Value -= mapPaletteGreenNum.Value % 8;

            if (mapPaletteGreenBar.Value == (int)mapPaletteGreenNum.Value)
            {
                paletteSet.PaletteColorGreen[currentColor] = (byte)this.mapPaletteGreenNum.Value;

                if (currentColor < 111 && (currentColor & 15) == 15)
                    paletteSet.PaletteColorGreen[currentColor + 1] = paletteSet.PaletteColorGreen[currentColor];
                if (currentColor != 0 && currentColor % 16 == 0)
                    paletteSet.PaletteColorGreen[currentColor - 1] = paletteSet.PaletteColorGreen[currentColor];

                if (!updatingLevel)
                {
                    PaletteChange();
                }
            }
            else
            {
                mapPaletteGreenBar.Value = (int)mapPaletteGreenNum.Value;
                mapPaletteGreenBar_Scroll(null, null);
            }
        }
        private void mapPaletteBlueBar_Scroll(object sender, System.EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteBlueBar.Value -= mapPaletteBlueBar.Value % 8;

            if (mapPaletteBlueNum.Value == mapPaletteBlueBar.Value)
                {
                    paletteSet.PaletteColorBlue[currentColor] = (byte)this.mapPaletteBlueBar.Value;

                    if (currentColor < 111 && (currentColor & 15) == 15)
                        paletteSet.PaletteColorBlue[currentColor + 1] = paletteSet.PaletteColorBlue[currentColor];
                    if (currentColor != 0 && currentColor % 16 == 0)
                        paletteSet.PaletteColorBlue[currentColor - 1] = paletteSet.PaletteColorBlue[currentColor];

                    if (!updatingLevel)
                    {
                        PaletteChange();
                    }
                }
                else
                {
                    mapPaletteBlueNum.Value = mapPaletteBlueBar.Value;
                }
        }
        private void mapPaletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            mapPaletteBlueNum.Value -= mapPaletteBlueNum.Value % 8;

            if (mapPaletteBlueBar.Value == (int)mapPaletteBlueNum.Value)
            {
                paletteSet.PaletteColorBlue[currentColor] = (byte)this.mapPaletteBlueNum.Value;

                if (currentColor < 111 && (currentColor & 15) == 15)
                    paletteSet.PaletteColorBlue[currentColor + 1] = paletteSet.PaletteColorBlue[currentColor];
                if (currentColor != 0 && currentColor % 16 == 0)
                    paletteSet.PaletteColorBlue[currentColor - 1] = paletteSet.PaletteColorBlue[currentColor];

                if (!updatingLevel)
                {
                    PaletteChange();
                }
            }
            else
            {
                mapPaletteBlueBar.Value = (int)mapPaletteBlueNum.Value;
                mapPaletteBlueBar_Scroll(null, null);
            }
        }

        private void palettePictureBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            currentColor = (e.X / 15) + ((e.Y / 15) * 16);
            numericUpDown8.Value = currentColor;
        }
        private void palettePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (paletteSetImage == null)
                return;

            e.Graphics.DrawImage(paletteSetImage, 0, 0);

            Point p = new Point(currentColor % 16 * 15, currentColor / 16 * 15);
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 14, p.Y + 14), p, 1);
        }
        private void paletteUpdate_Click(object sender, EventArgs e)
        {
            fullUpdate = true;
            UpdateLevel();
        }

        private void importPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select the file to import", "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*");

            FileStream fs;
            BinaryReader br;

            byte[] buffer = new byte[1024];

            try
            {
                fs = File.OpenRead(path);

                if (Path.GetExtension(path) == ".pal")
                {
                    br = new BinaryReader(fs);
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    for (int i = 0; i < 7; i++) // 7 palettes in set
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            if (contextMenuStrip3.SourceControl == palettePictureBox)
                            {
                                paletteSet.PaletteColorRed[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
                                paletteSet.PaletteColorGreen[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
                                paletteSet.PaletteColorBlue[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
                            }
                            else
                            {
                                paletteSetBF.PaletteColorRedBF[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
                                paletteSetBF.PaletteColorGreenBF[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
                                paletteSetBF.PaletteColorBlueBF[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
                            }
                        }
                    }
                }
                else
                {
                    br = new BinaryReader(fs);
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    double multiplier = 8; // 8;
                    ushort color = 0;

                    for (int i = 0; i < 7; i++) // 7 palettes in set
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            color = BitManager.GetShort(buffer, (i * 30) + (j * 2));

                            if (contextMenuStrip3.SourceControl == palettePictureBox)
                            {
                                paletteSet.PaletteColorRed[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                                paletteSet.PaletteColorGreen[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                                paletteSet.PaletteColorBlue[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                            }
                            else
                            {
                                paletteSetBF.PaletteColorRedBF[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                                paletteSetBF.PaletteColorGreenBF[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                                paletteSetBF.PaletteColorBlueBF[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                            }
                        }
                    }
                }
                if (contextMenuStrip3.SourceControl == palettePictureBox)
                    mapNum_ValueChanged(null, null);
                else
                    battlefieldNum_ValueChanged(null, null);

                fs.Close();
                br.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.");
                return;
            }
        }
        private void exportPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            if (contextMenuStrip3.SourceControl == palettePictureBox)
                saveFileDialog.FileName = "paletteSet." + ((int)(mapPaletteSetNum.Value)).ToString("X3");
            else
                saveFileDialog.FileName = "paletteSetBat." + ((int)(battlefieldPaletteSetNum.Value)).ToString("X3");
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                BinaryWriter bw;
                byte[] buffer = new byte[1024];

                if (saveFileDialog.FilterIndex == 2)
                {
                    byte[] temp = new byte[]
                    {
                        0x52, 0x49, 0x46, 0x46, 0x14, 0x04, 0x00, 0x00, 
                        0x50, 0x41, 0x4C, 0x20, 0x64, 0x61, 0x74, 0x61
                    };
                    temp.CopyTo(buffer, 0);

                    BitManager.SetShort(buffer, 0x10, 448 + 3);

                    for (int i = 0; i < 7; i++) // 7 palettes in set
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            if (contextMenuStrip3.SourceControl == palettePictureBox)
                            {
                                buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)paletteSet.PaletteColorRed[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)paletteSet.PaletteColorGreen[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)paletteSet.PaletteColorBlue[(i * 16) + j];
                            }
                            else
                            {
                                buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)paletteSetBF.PaletteColorRedBF[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)paletteSetBF.PaletteColorGreenBF[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)paletteSetBF.PaletteColorBlueBF[(i * 16) + j];
                            }
                        }
                    }

                    fs = new FileStream(saveFileDialog.FileName + ".pal", FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 448 + 0x17);
                    bw.Close();
                    fs.Close();
                }
                else
                {
                    ushort color = 0;
                    int r, g, b;

                    for (int i = 0; i < 7; i++) // 7 palettes in set
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            if (contextMenuStrip3.SourceControl == palettePictureBox)
                            {
                                r = (int)(paletteSet.PaletteColorRed[(i * 16) + j] / 8);
                                g = (int)(paletteSet.PaletteColorGreen[(i * 16) + j] / 8);
                                b = (int)(paletteSet.PaletteColorBlue[(i * 16) + j] / 8);
                            }
                            else
                            {
                                r = (int)(paletteSetBF.PaletteColorRedBF[(i * 16) + j] / 8);
                                g = (int)(paletteSetBF.PaletteColorGreenBF[(i * 16) + j] / 8);
                                b = (int)(paletteSetBF.PaletteColorBlueBF[(i * 16) + j] / 8);
                            }
                            color = (ushort)((b << 10) | (g << 5) | r);
                            BitManager.SetShort(buffer, (i * 30) + (j * 2), color);
                        }
                    }

                    fs = new FileStream(saveFileDialog.FileName + ".bin", FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 0xE0);
                    bw.Close();
                    fs.Close();
                }
            }
        }

        private void colorBalance_Click(object sender, EventArgs e)
        {
            panelColorBalance.Visible = !panelColorBalance.Visible;
        }
        private void coleditSelectCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            colEditComboBoxA.Enabled = false;
            colEditComboBoxB.Enabled = false;
            colEditValueA.Enabled = false;
            colEditReds.Enabled = false;
            colEditGreens.Enabled = false;
            colEditBlues.Enabled = false;
            colEditLabelA.Text = "";
            colEditLabelB.Text = "";
            colEditLabelC.Text = "";
            colEditLabelD.Text = "";

            switch (coleditSelectCommand.SelectedIndex)
            {
                case 0:
                    colEditComboBoxA.Enabled = true;
                    colEditComboBoxB.Enabled = true;
                    if (coleditSelectCommand.SelectedIndex == 0)
                        colEditLabelA.Text = "Switch";
                    colEditLabelB.Text = "with";
                    colEditComboBoxA.SelectedIndex = 0;
                    colEditComboBoxB.SelectedIndex = 0;
                    break;
                case 1: colEditLabelC.Text = "Add"; goto case 4;
                case 2: colEditLabelC.Text = "Subtract"; goto case 4;
                case 3: colEditLabelC.Text = "Multiply by"; goto case 4;
                case 4:
                    if (coleditSelectCommand.SelectedIndex == 4)
                        colEditLabelC.Text = "Divide by";
                    colEditLabelD.Text = "for";
                    colEditValueA.Enabled = true;
                    colEditReds.Enabled = true;
                    colEditGreens.Enabled = true;
                    colEditBlues.Enabled = true;
                    break;
                case 5: colEditLabelA.Text = "Equate"; goto case 0;
                case 6: colEditLabelC.Text = "Set to"; goto case 4;
            }
        }
        private void colEditReds_CheckedChanged(object sender, EventArgs e)
        {
            colEditReds.ForeColor = colEditReds.Checked ? Color.Black : Color.Gray;
        }
        private void colEditGreens_CheckedChanged(object sender, EventArgs e)
        {
            colEditGreens.ForeColor = colEditGreens.Checked ? Color.Black : Color.Gray;
        }
        private void colEditBlues_CheckedChanged(object sender, EventArgs e)
        {
            colEditBlues.ForeColor = colEditBlues.Checked ? Color.Black : Color.Gray;
        }
        private void colEditSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colEditColors.Items.Count; i++)
                colEditColors.SetItemChecked(i, false);
        }
        private void colEditSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colEditColors.Items.Count; i++)
                colEditColors.SetItemChecked(i, true);
        }
        private void colEditRowSelectAll_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = e.Index < 7 ? e.Index : (e.Index - 7), o = 0; o < 16; i += 7, o++)
                colEditColors.SetItemChecked(i, e.Index < 7);
            e.NewValue = CheckState.Unchecked;
        }
        private void colEditApply_Click(object sender, EventArgs e)
        {
            int[] temp;
            int[] reds, greens, blues;
            if (colEditBF)
            {
                reds = paletteSetBF.PaletteColorRedBF;
                greens = paletteSetBF.PaletteColorGreenBF;
                blues = paletteSetBF.PaletteColorBlueBF;
            }
            else
            {
                reds = paletteSet.PaletteColorRed;
                greens = paletteSet.PaletteColorGreen;
                blues = paletteSet.PaletteColorBlue;
            }
            temp = new int[reds.Length];
            reds.CopyTo(temp, 0);
            if (colEditBF)
                colorRedsBF.Push(temp);
            else colorReds.Push(temp);
            temp = new int[greens.Length];
            greens.CopyTo(temp, 0);
            if (colEditBF)
                colorGreensBF.Push(temp);
            else colorGreens.Push(temp);
            temp = new int[blues.Length];
            blues.CopyTo(temp, 0);
            if (colEditBF)
                colorBluesBF.Push(temp);
            else colorBlues.Push(temp);

            int tempA = 0;
            int tempB = 0;
            for (int i = 0; i < 112; i++)
            {
                int index = ((i & 15) * 7) + (i / 16);
                if (colEditColors.GetItemChecked(index))
                {
                    switch (coleditSelectCommand.SelectedIndex)
                    {
                        case 0:
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: tempA = reds[i]; break;
                                case 1: tempA = greens[i]; break;
                                case 2: tempA = blues[i]; break;
                            }
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: tempB = reds[i]; break;
                                case 1: tempB = greens[i]; break;
                                case 2: tempB = blues[i]; break;
                            }
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: reds[i] = tempB; break;
                                case 1: greens[i] = tempB; break;
                                case 2: blues[i] = tempB; break;
                            }
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: reds[i] = tempA; break;
                                case 1: greens[i] = tempA; break;
                                case 2: blues[i] = tempA; break;
                            }
                            break;
                        case 1:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Min(248, reds[i] + colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Min(248, greens[i] + colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Min(248, blues[i] + colEditValueA.Value);
                            break;
                        case 2:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Max(0, reds[i] - colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Max(0, greens[i] - colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Max(0, blues[i] - colEditValueA.Value);
                            break;
                        case 3:
                            if (colEditReds.Checked)
                                reds[i] = (int)Math.Min(248, reds[i] * colEditValueA.Value);
                            if (colEditGreens.Checked)
                                greens[i] = (int)Math.Min(248, greens[i] * colEditValueA.Value);
                            if (colEditBlues.Checked)
                                blues[i] = (int)Math.Min(248, blues[i] * colEditValueA.Value);
                            break;
                        case 4:
                            if (colEditReds.Checked)
                                reds[i] /= (int)colEditValueA.Value;
                            if (colEditGreens.Checked)
                                greens[i] /= (int)colEditValueA.Value;
                            if (colEditBlues.Checked)
                                blues[i] /= (int)colEditValueA.Value;
                            break;
                        case 5:
                            switch (colEditComboBoxB.SelectedIndex)
                            {
                                case 0: tempA = reds[i]; break;
                                case 1: tempA = greens[i]; break;
                                case 2: tempA = blues[i]; break;
                            }
                            switch (colEditComboBoxA.SelectedIndex)
                            {
                                case 0: reds[i] = tempA; break;
                                case 1: greens[i] = tempA; break;
                                case 2: blues[i] = tempA; break;
                            }
                            break;
                        case 6:
                            if (colEditReds.Checked)
                                reds[i] = (int)colEditValueA.Value;
                            if (colEditGreens.Checked)
                                greens[i] = (int)colEditValueA.Value;
                            if (colEditBlues.Checked)
                                blues[i] = (int)colEditValueA.Value;
                            break;
                    }
                }
            }
            if (colEditBF)
                battlefieldNum_ValueChanged(null, null);
            else
                PaletteChange();
        }
        private void colEditReset_Click(object sender, EventArgs e)
        {
            if (colEditBF)
            {
                if (colorRedsBF.Count == 0)
                    return;
                for (int i = 0; i < colorRedsBF.Count; i++)
                {
                    redoColorRedsBF.Push(paletteSetBF.PaletteColorRedBF);
                    redoColorGreensBF.Push(paletteSetBF.PaletteColorGreenBF);
                    redoColorBluesBF.Push(paletteSetBF.PaletteColorBlueBF);

                    paletteSetBF.PaletteColorRedBF = colorRedsBF.Peek();
                    paletteSetBF.PaletteColorGreenBF = colorGreensBF.Peek();
                    paletteSetBF.PaletteColorBlueBF = colorBluesBF.Peek();

                    colorRedsBF.Pop();
                    colorGreensBF.Pop();
                    colorBluesBF.Pop();
                }

                battlefieldNum_ValueChanged(null, null);
            }
            else
            {
                if (colorReds.Count == 0)
                    return;
                for (int i = 0; i < colorReds.Count; i++)
                {
                    redoColorReds.Push(paletteSet.PaletteColorRed);
                    redoColorGreens.Push(paletteSet.PaletteColorGreen);
                    redoColorBlues.Push(paletteSet.PaletteColorBlue);

                    paletteSet.PaletteColorRed = colorReds.Peek();
                    paletteSet.PaletteColorGreen = colorGreens.Peek();
                    paletteSet.PaletteColorBlue = colorBlues.Peek();

                    colorReds.Pop();
                    colorGreens.Pop();
                    colorBlues.Pop();
                }

                PaletteChange();
            }
        }
        private void colEditUndo_Click(object sender, EventArgs e)
        {
            if (colEditBF)
            {
                if (colorRedsBF.Count == 0)
                    return;

                redoColorRedsBF.Push(paletteSetBF.PaletteColorRedBF);
                redoColorGreensBF.Push(paletteSetBF.PaletteColorGreenBF);
                redoColorBluesBF.Push(paletteSetBF.PaletteColorBlueBF);

                paletteSetBF.PaletteColorRedBF = colorRedsBF.Peek();
                paletteSetBF.PaletteColorGreenBF = colorGreensBF.Peek();
                paletteSetBF.PaletteColorBlueBF = colorBluesBF.Peek();

                colorRedsBF.Pop();
                colorGreensBF.Pop();
                colorBluesBF.Pop();

                battlefieldNum_ValueChanged(null, null);
            }
            else
            {
                if (colorReds.Count == 0)
                    return;

                redoColorReds.Push(paletteSet.PaletteColorRed);
                redoColorGreens.Push(paletteSet.PaletteColorGreen);
                redoColorBlues.Push(paletteSet.PaletteColorBlue);

                paletteSet.PaletteColorRed = colorReds.Peek();
                paletteSet.PaletteColorGreen = colorGreens.Peek();
                paletteSet.PaletteColorBlue = colorBlues.Peek();

                colorReds.Pop();
                colorGreens.Pop();
                colorBlues.Pop();

                PaletteChange();
            }
        }
        private void colEditRedo_Click(object sender, EventArgs e)
        {
            if (colEditBF)
            {
                if (redoColorRedsBF.Count == 0)
                    return;

                colorRedsBF.Push(paletteSetBF.PaletteColorRedBF);
                colorGreensBF.Push(paletteSetBF.PaletteColorGreenBF);
                colorBluesBF.Push(paletteSetBF.PaletteColorBlueBF);

                paletteSetBF.PaletteColorRedBF = redoColorRedsBF.Peek();
                paletteSetBF.PaletteColorGreenBF = redoColorGreensBF.Peek();
                paletteSetBF.PaletteColorBlueBF = redoColorBluesBF.Peek();

                redoColorRedsBF.Pop();
                redoColorGreensBF.Pop();
                redoColorBluesBF.Pop();

                battlefieldNum_ValueChanged(null, null);
            }
            else
            {
                if (redoColorReds.Count == 0)
                    return;

                colorReds.Push(paletteSet.PaletteColorRed);
                colorGreens.Push(paletteSet.PaletteColorGreen);
                colorBlues.Push(paletteSet.PaletteColorBlue);

                paletteSet.PaletteColorRed = redoColorReds.Peek();
                paletteSet.PaletteColorGreen = redoColorGreens.Peek();
                paletteSet.PaletteColorBlue = redoColorBlues.Peek();

                redoColorReds.Pop();
                redoColorGreens.Pop();
                redoColorBlues.Pop();

                PaletteChange();
            }
        }

        #endregion
    }
}
