using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    // stats
    [Flags]
    public enum Status
    {
        Mute = 1, Sleep = 2, Poison = 4, Fear = 8,
        Mushroom = 32, Scarecrow = 64, Invincible = 128
    }
    [Flags]
    public enum Targetting
    {
        LiveAlly = 2, Enemy = 4, All = 16, WoundedOnly = 32, OnePartyOnly = 64, NotSelf = 128
    }
    // scripts
    public enum EventCategory
    {
        Objects, Joypad, PartyMembers, Inventory,
        Battle, Levels, Menus, Dialogues,
        Events, JumpTo, ScreenEffects, AudioPlayback,
        Memory, Memory7000, PauseScript, Return
    }
    public enum ActionCategory
    {
        Properties, Palette, SpriteSequence, SpriteAnimation,
        Shift1xStep, ShiftIsometric, Shift1pxUnit, FaceDirection,
        ShiftToCoords, AudioPlayback, Memory, Memory700C,
        JumpTo, ObjectMemory, PauseScript, Return
    }
    public enum EventObjects
    {
        ActionQueue, FreezeAllObjects, UnfreezeAllObjects,
        IfObjectPresent, IfMarioOnTop, IfDistanceBetween,
        IfDistanceBetweenZEQ, IfMarioInAir, CreateNPCatObject,
        CreateNPCatMario, IfMarioOnTopAnyObject, SetObjPresence,
        SetObjEventTrigger, SetObjMem70A8PresenceTrue, SetObjMem70A8PresentFalse,
        SetObjMem70A8EventTriggerTrue, SetObjMem70A8EventTriggerFalse,
        IfObjectInLevel, RememberLastObject, IfRunningAction, IfUnderwater,
        IfInAir, CreateNPCatMarioEvent, MarioGlows
    }
    // other
    public enum MenuType
    {
        GameSelect, OverworldMain, OverworldItem, OverworldStatus,
        OverworldSpecial, OverworldEquip, OverworldSpecialItem,
        OverworldSwitch, Shop, ShopBuy, ShopSellItems, ShopSellWeapons
    }
    public enum FontType
    {
        Dialogue, Menu, Description, Triangles, FlowerBonus, BattleMenu
    }
    // Audio
    public enum Pitch
    {
        C, Cs, D, Ds, E, F, Fs, G, Gs, A, As, B, Rest, Tie, NULL
    }
    public enum Accidental
    {
        None, Flat, Natural, Sharp
    }
    public enum Key
    {
        CMajor, GMajor, DMajor, AMajor, EMajor, BMajor, FsMajor, CsMajor, // Sharps
        FMajor, BbMajor, EbMajor, AbMajor, DbMajor, GbMajor, CbMajor, // Flats
        AMinor, EMinor, BMinor, FsMinor, CsMinor, GsMinor, DsMinor, AsMinor, // Sharps
        DMinor, GMinor, CMinor, FMinor, BbMinor, EbMinor, AbMinor // Flats
    }
    public enum Beat
    {
        Whole,
        HalfDotted,
        Half,
        QuarterDotted,
        Quarter,
        EighthDotted,
        QuarterTriplet,
        Eighth,
        EighthTriplet,
        Sixteenth,
        SixteenthTriplet,
        ThirtySecond,
        SixtyFourth,
        NULL
    }
    public enum SPCType
    {
        SPCTrack, EventSFX, BattleSFX
    }
    public enum NativeSPC
    {
        SMRPG,
        SMWLevel,
        SMWOverworld,
        Custom
    }
    //
    public enum EType
    {
        ActionScript,
        AnimationScript,
        BattleScript,
        EventScript,
        Level,
        MineCart,
        SPCBattle,
        SPCEvent,
        SPCTrack
    }
    public enum MessageIcon
    {
        None,
        Error,
        Info,
        Warning
    }
    public enum TilesetType
    {
        Level, SideScrolling, Mode7, Title, WorldMap, WorldMapLogo, Opening
    }
    public enum TilemapType
    {
        Level, Mod, Template, None
    }
}
