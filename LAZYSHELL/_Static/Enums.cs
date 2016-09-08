using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    #region Types

    /// <summary>
    /// Class types that appear in multiple namespaces.
    /// </summary>
    public enum CommonType
    {
        Animation, Sequence, Mold, Tilemap, Tileset, Tile, Subtile, Command
    }

    /// <summary>
    /// Component types of the Mario RPG ROM read by the application.
    /// </summary>
    public enum ElementType
    {
        ActionScript,
        AnimationScript,
        Area,
        Attack,
        Battlefield,
        BattleDialogue,
        BattleScript,
        BRRSample,
        Dialogue,
        Effect,
        EffectAnimation,
        EventScript,
        Formation,
        Item,
        MineCart,
        Monster,
        NewGame,
        NewGameAlly,
        Pack,
        Shop,
        SPCBattle,
        SPCEvent,
        SPCTrack,
        Spell,
        Sprite,
        SpriteAnimation,
        WAVSample,
        WorldMap
    }

    /// <summary>
    /// Various types in the menus component.
    /// </summary>
    public enum MenuType
    {
        GameSelect, 
        OverworldMain, 
        OverworldItem, 
        OverworldStatus,
        OverworldSpecial, 
        OverworldEquip, 
        OverworldSpecialItem,
        OverworldSwitch, 
        Shop, 
        ShopBuy, 
        ShopSellItems, 
        ShopSellWeapons
    }

    /// <summary>
    /// Various types in the fonts component.
    /// </summary>
    public enum FontType
    {
        Dialogue, Menu, Description, Triangles, FlowerBonus, BattleMenu
    }

    /// <summary>
    /// Various tileset types used in the Mario RPG ROM.
    /// </summary>
    public enum TilesetType
    {
        Area, SideScrolling, Mode7, Title, WorldMap, WorldMapLogo, Opening
    }
    
    /// <summary>
    /// Various tilemap types used in the Mario RPG ROM.
    /// </summary>
    public enum TilemapType
    {
        None, Area, TileSwitch, Chunk
    }
    
    #endregion

    /// <summary>
    /// Mode for exporting or importing data.
    /// </summary>
    public enum IOMode
    {
        Export, Import
    }

    /// <summary>
    /// Status flags for battle-related elements.
    /// </summary>
    [Flags]
    public enum Status
    {
        Mute = 1, Sleep = 2, Poison = 4, Fear = 8,
        Mushroom = 32, Scarecrow = 64, Invincible = 128
    }

    /// <summary>
    /// Targetting flags for battle-related elements.
    /// </summary>
    [Flags]
    public enum Targetting
    {
        LiveAlly = 2, Enemy = 4, All = 16, WoundedOnly = 32, OnePartyOnly = 64, NotSelf = 128
    }

    /// <summary>
    /// Type of control in which the results of a search query are displayed.
    /// </summary>
    public enum ResultWindow
    {
        TextBox, TreeView, ListBox
    }

    /// <summary>
    /// Icon used by the custom message box.
    /// </summary>
    public enum MessageIcon
    {
        None,
        Error,
        Info,
        Warning
    }

    /// <summary>
    /// Drawing mode in a paint interface.
    /// </summary>
    public enum EditMode
    {
        None, Draw, Erase, Fill, FillAll, ReplaceColor, Dropper, Select
    }

    /// <summary>
    /// Mode for flipping a region in a map.
    /// </summary>
    public enum FlipType
    {
        Horizontal, Vertical
    }
    //
    public class EnumValueDataAttribute : Attribute
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
