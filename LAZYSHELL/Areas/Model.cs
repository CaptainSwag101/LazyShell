using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        // Compressed data
        private static byte[][] graphicSets = new byte[272][];
        private static byte[][] tilesets = new byte[125][];
        private static byte[][] tilemaps = new byte[309][];
        private static byte[][] collisionMaps = new byte[120][];
        public static byte[][] GraphicSets
        {
            get
            {
                if (graphicSets[0] == null)
                    Comp.Decompress(graphicSets, 0x0A0000, 0x150000, 0x2000, "GRAPHIC SET", true);
                return graphicSets;
            }
            set { graphicSets = value; }
        }
        public static byte[][] Tilesets
        {
            get
            {
                if (tilesets[0] == null)
                    Comp.Decompress(tilesets, 0x3B0000, 0x3E0000, 0x1000, "TILE SET", true);
                return tilesets;
            }
            set { tilesets = value; }
        }
        public static byte[][] Tilemaps
        {
            get
            {
                if (tilemaps[0] == null)
                    Comp.Decompress(tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "TILE MAP", 0x40, true);
                return tilemaps;
            }
            set { tilemaps = value; }
        }
        public static byte[][] CollisionMaps
        {
            get
            {
                if (collisionMaps[0] == null)
                    Comp.Decompress(collisionMaps, 0x1B0000, 0x1D0000, 0x20C2, "COLLISION MAP", true);
                return collisionMaps;
            }
            set { collisionMaps = value; }
        }

        // Modification flags
        public static bool[] Modify_GraphicSets = new bool[272];
        public static bool[] Modify_Tilesets = new bool[125];
        public static bool[] Modify_Tilemaps = new bool[309];
        public static bool[] Modify_CollisionMaps = new bool[120];

        // Elements
        private static Area[] areas;
        private static Map[] maps;
        private static PaletteSet[] paletteSets;
        private static CollisionTile[] collisionTiles;
        private static PrioritySet[] prioritySets;
        private static NPCProperties[] npcProperties;
        private static SpritePartitioning[] spritePartitions;
        private static OverlapTileset overlapTileset;
        public static Area[] Areas
        {
            get
            {
                if (areas == null)
                {
                    areas = new Area[512];
                    for (int i = 0; i < areas.Length; i++)
                        areas[i] = new Area(i);
                }
                return areas;
            }
            set { areas = value; }
        }
        public static Map[] Maps
        {
            get
            {
                if (maps == null)
                {
                    maps = new Map[156];
                    for (int i = 0; i < maps.Length; i++)
                        maps[i] = new Map(i);
                }
                return maps;
            }
            set { maps = value; }
        }
        public static PaletteSet[] PaletteSets
        {
            get
            {
                if (paletteSets == null)
                {
                    paletteSets = new PaletteSet[94];
                    for (int i = 0; i < paletteSets.Length; i++)
                        paletteSets[i] = new PaletteSet(ROM, i, (i * 0xD4) + 0x249FE2, 8, 16, 30);
                }
                return paletteSets;
            }
            set { paletteSets = value; }
        }
        public static CollisionTile[] CollisionTiles
        {
            get
            {
                if (collisionTiles == null)
                {
                    collisionTiles = new CollisionTile[1024];
                    for (int i = 0; i < collisionTiles.Length; i++)
                        collisionTiles[i] = new CollisionTile(i);
                }
                return collisionTiles;
            }
            set { collisionTiles = value; }
        }
        public static PrioritySet[] PrioritySets
        {
            get
            {
                if (prioritySets == null)
                {
                    prioritySets = new PrioritySet[16];
                    for (int i = 0; i < prioritySets.Length; i++)
                        prioritySets[i] = new PrioritySet(i);
                }
                return prioritySets;
            }
            set { prioritySets = value; }
        }
        public static NPCProperties[] NPCProperties
        {
            get
            {
                if (npcProperties == null)
                {
                    npcProperties = new NPCProperties[512];
                    for (int i = 0; i < npcProperties.Length; i++)
                        npcProperties[i] = new NPCProperties(i);
                }
                return npcProperties;
            }
            set { npcProperties = value; }
        }
        public static SpritePartitioning[] SpritePartitions
        {
            get
            {
                if (spritePartitions == null)
                {
                    spritePartitions = new SpritePartitioning[120];
                    for (int i = 0; i < spritePartitions.Length; i++)
                        spritePartitions[i] = new SpritePartitioning(i);
                }
                return spritePartitions;
            }
        }
        public static OverlapTileset OverlapTileset
        {
            get
            {
                if (overlapTileset == null)
                    overlapTileset = new OverlapTileset();
                return overlapTileset;
            }
        }

        #endregion

        #region Methods

        // Free space
        public static int FreeNPCSpace()
        {
            int used = 0;
            foreach (var area in areas)
                used += area.NPCObjects.GetTotalSize();
            return 0x7BFF - used;
        }
        public static int FreeExitSpace()
        {
            int used = 0;
            foreach (var area in areas)
            {
                foreach (var trigger in area.ExitTriggers)
                    used += trigger.Size;
            }
            return 0x179F - used;
        }
        public static int FreeEventSpace()
        {
            int used = 0;
            foreach (var area in areas)
            {
                used += 3; // for the music and initial event
                foreach (var trigger in area.EventTriggers)
                    used += trigger.Size;
            }
            return 0x1BFF - used;
        }
        public static int FreeOverlapSpace()
        {
            int used = 0;
            foreach (var area in areas)
            {
                foreach (var overlap in area.Overlaps)
                    used += 4;
            }
            return 0x11B8 - used;
        }
        public static int FreeTileSwitchSpace()
        {
            int used = 0;
            for (int i = 0; i < 512; i++)
            {
                foreach (var mod in areas[i].TileSwitches)
                    used += mod.Length;
            }
            return 0x2AF3 - used;
        }
        public static int FreeCollisionSwitchSpace()
        {
            int used = 0;
            for (int i = 0; i < 512; i++)
            {
                foreach (var collisionSwitch in areas[i].CollisionSwitches)
                    used += collisionSwitch.Length;
            }
            return 0x08FF - used;
        }
        public static string MaximumSpaceExceeded(string name)
        {
            return
                "The total number of " + name + " for all areas has exceeded the maximum allotted space.\n\n" +
                "Try removing some " + name + " to increase the amount of free space for new " + name + ".";
        }

        // Mask objects
        public static bool IsMaskObject(MapObject mapObject)
        {
            if (mapObject == MapObject.MaskE ||
                mapObject == MapObject.MaskN ||
                mapObject == MapObject.MaskNE ||
                mapObject == MapObject.MaskNW ||
                mapObject == MapObject.MaskS ||
                mapObject == MapObject.MaskSE ||
                mapObject == MapObject.MaskSW ||
                mapObject == MapObject.MaskW)
                return true;
            return false;
        }

        // IO elements
        public static void ExportArea(int index, string fullPath)
        {
            // create the serialized level
            var sLevel = new Serialized();
            sLevel.Layering = Areas[index].Layering;
            sLevel.MapNum = Areas[index].Map;
            var lMap = Maps[Areas[index].Map];
            sLevel.Map = lMap;// Add it to serialized level data object
            sLevel.TilesetL1 = Tilesets[lMap.TilesetL1 + 0x20];
            sLevel.TilesetL2 = Tilesets[lMap.TilesetL2 + 0x20];
            sLevel.TilesetL3 = Tilesets[lMap.TilesetL3];
            sLevel.TilemapL1 = Tilemaps[lMap.TilemapL1 + 0x40];
            sLevel.TilemapL2 = Tilemaps[lMap.TilemapL2 + 0x40];
            sLevel.TilemapL3 = Tilemaps[lMap.TilemapL3];
            sLevel.CollisionMap = CollisionMaps[lMap.CollisionMap];
            sLevel.NPCs = Areas[index].NPCObjects;
            sLevel.Exits = Areas[index].ExitTriggers;
            sLevel.Events = Areas[index].EventTriggers;
            sLevel.Overlaps = Areas[index].Overlaps;
            // finally export the serialized levels
            Do.Export(sLevel, null, fullPath);
        }
        public static void ExportAreas(string fullPath)
        {
            // create the serialized level
            var sLevels = new Serialized[510];
            for (int i = 0; i < sLevels.Length; i++)
            {
                sLevels[i] = new Serialized();
                sLevels[i].Layering = Areas[i].Layering;
                sLevels[i].MapNum = Areas[i].Map;
                var map = Maps[Areas[i].Map];
                sLevels[i].Map = map;// Add it to serialized level data object
                sLevels[i].TilesetL1 = Tilesets[map.TilesetL1 + 0x20];
                sLevels[i].TilesetL2 = Tilesets[map.TilesetL2 + 0x20];
                sLevels[i].TilesetL3 = Tilesets[map.TilesetL3];
                sLevels[i].TilemapL1 = Tilemaps[map.TilemapL1 + 0x40];
                sLevels[i].TilemapL2 = Tilemaps[map.TilemapL2 + 0x40];
                sLevels[i].TilemapL3 = Tilemaps[map.TilemapL3];
                sLevels[i].CollisionMap = CollisionMaps[map.CollisionMap];
                sLevels[i].NPCs = Areas[i].NPCObjects;
                sLevels[i].Exits = Areas[i].ExitTriggers;
                sLevels[i].Events = Areas[i].EventTriggers;
                sLevels[i].Overlaps = Areas[i].Overlaps;
            }
            // finally export the serialized levels
            Do.Export(sLevels,
                fullPath + "\\" + LAZYSHELL.Model.GetFileNameWithoutPath() + " - Areas\\" + "area", "AREA", true);
        }
        public static bool ImportArea(int index, string fullPath)
        {
            var sLevel = new Areas.Serialized();
            try
            {
                sLevel = (Areas.Serialized)Do.Import(sLevel, fullPath);
            }
            catch
            {
                MessageBox.Show("File not an area data file.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            Areas[index].Layering = sLevel.Layering;
            Areas[index].Layering.Index = index;
            Areas[index].Map = sLevel.MapNum;
            var map = sLevel.Map;
            Maps[Areas[index].Map] = map;
            Tilesets[map.TilesetL1 + 0x20] = sLevel.TilesetL1;
            Tilesets[map.TilesetL2 + 0x20] = sLevel.TilesetL2;
            Tilesets[map.TilesetL3] = sLevel.TilesetL3;
            Modify_Tilesets[map.TilesetL1 + 0x20] = true;
            Modify_Tilesets[map.TilesetL2 + 0x20] = true;
            Modify_Tilesets[map.TilesetL3] = true;
            Tilemaps[map.TilemapL1 + 0x40] = sLevel.TilemapL1;
            Tilemaps[map.TilemapL2 + 0x40] = sLevel.TilemapL2;
            Tilemaps[map.TilemapL3] = sLevel.TilemapL3;
            Modify_Tilemaps[map.TilemapL1 + 0x40] = true;
            Modify_Tilemaps[map.TilemapL2 + 0x40] = true;
            Modify_Tilemaps[map.TilemapL3] = true;
            CollisionMaps[map.CollisionMap] = sLevel.CollisionMap;
            Modify_CollisionMaps[map.CollisionMap] = true;
            Areas[index].NPCObjects = sLevel.NPCs;
            Areas[index].ExitTriggers = sLevel.Exits;
            Areas[index].EventTriggers = sLevel.Events;
            Areas[index].Overlaps = sLevel.Overlaps;
            Areas[index].NPCObjects.AreaIndex = index;
            Areas[index].ExitTriggers.AreaIndex = index;
            Areas[index].EventTriggers.AreaIndex = index;
            Areas[index].Overlaps.AreaIndex = index;
            //
            return true;
        }
        public static bool ImportAreas(string fullPath)
        {
            var sLevels = new Areas.Serialized[510];
            for (int i = 0; i < sLevels.Length; i++)
                sLevels[i] = new Areas.Serialized();
            try
            {
                Do.Import(sLevels, fullPath + "\\" + "area", "AREA", true);
            }
            catch
            {
                MessageBox.Show("One or more files not an area data file.", 
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            for (int i = 0; i < sLevels.Length; i++)
            {
                Areas[i].Layering = sLevels[i].Layering;
                Areas[i].Layering.Index = i;
                Areas[i].Map = sLevels[i].MapNum;
                var map = sLevels[i].Map;
                Maps[Areas[i].Map] = map;
                Tilesets[map.TilesetL1 + 0x20] = sLevels[i].TilesetL1;
                Tilesets[map.TilesetL2 + 0x20] = sLevels[i].TilesetL2;
                Tilesets[map.TilesetL3] = sLevels[i].TilesetL3;
                Modify_Tilesets[map.TilesetL1 + 0x20] = true;
                Modify_Tilesets[map.TilesetL2 + 0x20] = true;
                Modify_Tilesets[map.TilesetL3] = true;
                Tilemaps[map.TilemapL1 + 0x40] = sLevels[i].TilemapL1;
                Tilemaps[map.TilemapL2 + 0x40] = sLevels[i].TilemapL2;
                Tilemaps[map.TilemapL3] = sLevels[i].TilemapL3;
                Modify_Tilemaps[map.TilemapL1 + 0x40] = true;
                Modify_Tilemaps[map.TilemapL2 + 0x40] = true;
                Modify_Tilemaps[map.TilemapL3] = true;
                CollisionMaps[map.CollisionMap] = sLevels[i].CollisionMap;
                Modify_CollisionMaps[map.CollisionMap] = true;
                Areas[i].NPCObjects = sLevels[i].NPCs;
                Areas[i].ExitTriggers = sLevels[i].Exits;
                Areas[i].EventTriggers = sLevels[i].Events;
                Areas[i].Overlaps = sLevels[i].Overlaps;
                Areas[i].NPCObjects.AreaIndex = i;
                Areas[i].ExitTriggers.AreaIndex = i;
                Areas[i].EventTriggers.AreaIndex = i;
                Areas[i].Overlaps.AreaIndex = i;
            }
            return true;
        }

        // Model management
        public static void ClearAll()
        {
            areas = null;
            collisionMaps[0] = null;
            collisionTiles = null;
            graphicSets[0] = null;
            maps = null;
            npcProperties = null;
            overlapTileset = null;
            paletteSets = null;
            prioritySets = null;
            spritePartitions = null;
            tilemaps[0] = null;
            tilesets[0] = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Areas;
            dummy = CollisionMaps[0];
            dummy = CollisionTiles;
            dummy = GraphicSets[0];
            dummy = Maps;
            dummy = NPCProperties;
            dummy = OverlapTileset;
            dummy = PaletteSets;
            dummy = PrioritySets;
            dummy = SpritePartitions;
            dummy = Tilemaps[0];
            dummy = Tilesets[0];
        }

        #endregion
    }
    /// <summary>
    /// An NPC's engage type category.
    /// </summary>
    public enum EngageType
    {
        Event = 0, Treasure = 1, Battle = 2
    }
    /// <summary>
    /// Specifies a type of object on the tilemap that the user can interact with.
    /// </summary>
    public enum MapObject
    {
        None,
        CollisionSwitch,
        CollisionTile,
        EventTrigger,
        ExitTrigger,
        NPCObject,
        Overlap,
        TileSwitch,
        MaskN,
        MaskE,
        MaskS,
        MaskW,
        MaskNE,
        MaskNW,
        MaskSW,
        MaskSE,
        Mushroom,
        Selection
    }
}
