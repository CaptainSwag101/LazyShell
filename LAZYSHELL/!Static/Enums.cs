using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    // Audio
    public enum Pitch
    {
        C, Cs, D, Ds, E, F, Fs, G, Gs, A, As, B, Rest, Tie, NULL
    }
    public enum MenuType
    {
        GameSelect, OverworldMain, OverworldItem, OverworldStatus,
        OverworldSpecial, OverworldEquip, OverworldSpecialItem,
        OverworldSwitch, Shop, ShopBuy, ShopSellItems, ShopSellWeapons
    }
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
    public enum Accidental
    {
        None, Flat, Natural, Sharp
    }
    public enum FontType
    {
        Menu, Dialogue, Description, Triangles, BattleMenu, FlowerBonus
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
    public enum NativeSPC
    {
        SMRPG,
        SMWLevel,
        SMWOverworld,
        Custom
    }
    //
    public enum PreviewType
    {
        Event,
        Level,
        Action,
        Battle,
        Animation,
        MineCart,
        SPCTrack,
        SPCEvent,
        SPCBattle
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
        Level, SideScrolling, Mode7, Title, WorldMap, WorldMapLogo
    }
    public enum TilemapType
    {
        Level, Mod, Template, None
    }
    public enum SPCType
    {
        SPCTrack, EventSFX, BattleSFX
    }
    public enum ScriptEnum_Option
    {
        Op_00, Op_01, Op_02, Op_03, Op_04, Op_05, Op_06, Op_07,
        Op_08, Op_09, Op_0A, Op_0B, Op_0C, Op_0D, Op_0E, Op_0F,

        Op_10, Op_11, Op_12, Op_13, Op_14, Op_15, Op_16, Op_17,
        Op_18, Op_19, Op_1A, Op_1B, Op_1C, Op_1D, Op_1E, Op_1F,

        Op_20, Op_21, Op_22, Op_23, Op_24, Op_25, Op_26, Op_27,
        Op_28, Op_29, Op_2A, Op_2B, Op_2C, Op_2D, Op_2E, Op_2F,

        Op_30, Op_31, Op_32, Op_33, Op_34, Op_35, Op_36, Op_37,
        Op_38, Op_39, Op_3A, Op_3B, Op_3C, Op_3D, Op_3E, Op_3F,

        Op_40, Op_41, Op_42, Op_43, Op_44, Op_45, Op_46, Op_47,
        Op_48, Op_49, Op_4A, Op_4B, Op_4C, Op_4D, Op_4E, Op_4F,

        Op_50, Op_51, Op_52, Op_53, Op_54, Op_55, Op_56, Op_57,
        Op_58, Op_59, Op_5A, Op_5B, Op_5C, Op_5D, Op_5E, Op_5F,

        Op_60, Op_61, Op_62, Op_63, Op_64, Op_65, Op_66, Op_67,
        Op_68, Op_69, Op_6A, Op_6B, Op_6C, Op_6D, Op_6E, Op_6F,

        Op_70, Op_71, Op_72, Op_73, Op_74, Op_75, Op_76, Op_77,
        Op_78, Op_79, Op_7A, Op_7B, Op_7C, Op_7D, Op_7E, Op_7F,

        Op_80, Op_81, Op_82, Op_83, Op_84, Op_85, Op_86, Op_87,
        Op_88, Op_89, Op_8A, Op_8B, Op_8C, Op_8D, Op_8E, Op_8F,

        Op_90, Op_91, Op_92, Op_93, Op_94, Op_95, Op_96, Op_97,
        Op_98, Op_99, Op_9A, Op_9B, Op_9C, Op_9D, Op_9E, Op_9F,

        Op_A0, Op_A1, Op_A2, Op_A3, Op_A4, Op_A5, Op_A6, Op_A7,
        Op_A8, Op_A9, Op_AA, Op_AB, Op_AC, Op_AD, Op_AE, Op_AF,

        Op_B0, Op_B1, Op_B2, Op_B3, Op_B4, Op_B5, Op_B6, Op_B7,
        Op_B8, Op_B9, Op_BA, Op_BB, Op_BC, Op_BD, Op_BE, Op_BF,

        Op_C0, Op_C1, Op_C2, Op_C3, Op_C4, Op_C5, Op_C6, Op_C7,
        Op_C8, Op_C9, Op_CA, Op_CB, Op_CC, Op_CD, Op_CE, Op_CF,

        Op_D0, Op_D1, Op_D2, Op_D3, Op_D4, Op_D5, Op_D6, Op_D7,
        Op_D8, Op_D9, Op_DA, Op_DB, Op_DC, Op_DD, Op_DE, Op_DF,

        Op_E0, Op_E1, Op_E2, Op_E3, Op_E4, Op_E5, Op_E6, Op_E7,
        Op_E8, Op_E9, Op_EA, Op_EB, Op_EC, Op_ED, Op_EE, Op_EF,

        Op_F0, Op_F1, Op_F2, Op_F3, Op_F4, Op_F5, Op_F6, Op_F7,
        Op_F8, Op_F9, Op_FA, Op_FB, Op_FC, Op_FD, Op_FE, Op_FF,

    }
    public enum ScriptEnum
    {
        S_00, S_01, S_02, S_03, S_04, S_05, S_06, S_07,
        S_08, S_09, S_0A, S_0B, S_0C, S_0D, S_0E, S_0F,

        S_10, S_11, S_12, S_13, S_14, S_15, S_16, S_17,
        S_18, S_19, S_1A, S_1B, S_1C, S_1D, S_1E, S_1F,

        S_20, S_21, S_22, S_23, S_24, S_25, S_26, S_27,
        S_28, S_29, S_2A, S_2B, S_2C, S_2D, S_2E, S_2F,

        S_30, S_31, S_32, S_33, S_34, S_35, S_36, S_37,
        S_38, S_39, S_3A, S_3B, S_3C, S_3D, S_3E, S_3F,

        S_40, S_41, S_42, S_43, S_44, S_45, S_46, S_47,
        S_48, S_49, S_4A, S_4B, S_4C, S_4D, S_4E, S_4F,

        S_50, S_51, S_52, S_53, S_54, S_55, S_56, S_57,
        S_58, S_59, S_5A, S_5B, S_5C, S_5D, S_5E, S_5F,

        S_60, S_61, S_62, S_63, S_64, S_65, S_66, S_67,
        S_68, S_69, S_6A, S_6B, S_6C, S_6D, S_6E, S_6F,

        S_70, S_71, S_72, S_73, S_74, S_75, S_76, S_77,
        S_78, S_79, S_7A, S_7B, S_7C, S_7D, S_7E, S_7F,

        S_80, S_81, S_82, S_83, S_84, S_85, S_86, S_87,
        S_88, S_89, S_8A, S_8B, S_8C, S_8D, S_8E, S_8F,

        S_90, S_91, S_92, S_93, S_94, S_95, S_96, S_97,
        S_98, S_99, S_9A, S_9B, S_9C, S_9D, S_9E, S_9F,

        S_A0, S_A1, S_A2, S_A3, S_A4, S_A5, S_A6, S_A7,
        S_A8, S_A9, S_AA, S_AB, S_AC, S_AD, S_AE, S_AF,

        S_B0, S_B1, S_B2, S_B3, S_B4, S_B5, S_B6, S_B7,
        S_B8, S_B9, S_BA, S_BB, S_BC, S_BD, S_BE, S_BF,

        S_C0, S_C1, S_C2, S_C3, S_C4, S_C5, S_C6, S_C7,
        S_C8, S_C9, S_CA, S_CB, S_CC, S_CD, S_CE, S_CF,

        S_D0, S_D1, S_D2, S_D3, S_D4, S_D5, S_D6, S_D7,
        S_D8, S_D9, S_DA, S_DB, S_DC, S_DD, S_DE, S_DF,

        S_E0, S_E1, S_E2, S_E3, S_E4, S_E5, S_E6, S_E7,
        S_E8, S_E9, S_EA, S_EB, S_EC, S_ED, S_EE, S_EF,

        S_F0, S_F1, S_F2, S_F3, S_F4, S_F5, S_F6, S_F7,
        S_F8, S_F9, S_FA, S_FB, S_FC, S_FD, S_FE, S_FF,
    }
}
