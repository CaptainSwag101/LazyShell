LAZY SHELL - Super Mario RPG Editor
Version: 3.5 ALPHA
Date: January 11, 2011
Home Page: http://home.comcast.net/~giangurgolo/smrpg/
Written by giangurgolo and Omega

______________________________________________________________________

INTRODUCTION
______________________________________________________________________

Lazy Shell is a third party .NET application written in the C#
programming language which is capable of editing a wide range of 
elements within the Super Mario RPG (US) ROM image file.

______________________________________________________________________

PROGRAM REQUIREMENTS
______________________________________________________________________

Microsoft .NET Framework 2.0 or higher must be installed on the 
system for the application to run at all.

Minimal system requirements: 512MB of RAM (1GB recommended)
                             10MB HD space (more if ROM back-ups used)

______________________________________________________________________

MAIN FEATURES
______________________________________________________________________

The editor is comprised of 15 individual editors.

Various status editors include modification capabilities for the
statuses of monsters, formations, formation packs, items, spells, 
attacks, shops, new game properties, level-ups, and timing properties.

The Levels portion allows the user to modify the maps of areas (aka 
locations) using a paint-like interface, the NPCs (ie the sprites in 
the maps), the exit fields (aka entrances), event fields, overlaps, 
and the basic layering properties. A template creator/editor lets the 
user to store a separate portion of the map composed of all 3 layers 
and the physical layer into a single file.

The three scripts editors in Lazy Shell enable the user to modify
the event scripts, battle scripts, and animations scripts. Commands 
within event scripts and battle scripts may be added, modified, 
deleted, moved, or copied and pasted. Commands within animation 
scripts may be modified or moved, but adding or deleting commands 
within animations is not supported.

The Sprites editor is able to modify a sprite's graphics, palette, and 
animations. The effects editor allows the user to edit spell effects 
and their respective graphics, palettes, and animations. 

In the Dialogue editor, the user may view and edit the dialogues (aka 
the game script) as well as the dialogues which appear in battles and 
the graphics of the dialogue background tiles. Fonts, font colors, 
and a new font generator will let the user create an entirely new 
font table based upon manual editing or a supportive font installed 
on the OS.

In the World Maps editor World maps, world map palettes, and the 
locations that appear on world maps can be modified.

The Audio editor can export, import, clear, and playback the audio
samples used by the ROM's SPC engine. Importing/exporting features
are limited to .wav files, which can be edited in a third party 
freeware application such as Audacity.

______________________________________________________________________

EXTRA FEATURES
______________________________________________________________________

The portions of the editor have tooltips for almost every single
control. Just press F1 (or click the ? buttons found in most editors)
and move the mouse over a control to see what that property is for. 
There is also a conversion tooltip for showing the hexadecimal or 
decimal value for the value in the control when moving the mouse 
cursor over it. Press F2 to enable this feature, or click the base
conversion button found in most editors.

Users are also able to import and export many elements from previously
exported .dat, .bin, or .pal files in all portions of the editor as a
means of backing up or inter-changing elements. Clearing/erasing data
is managed as well so as to free up space for new scripts or dialogues.

The notes database manager was written for the editor to aid the user
aiming to create a full or partial hack. Indexes for elements such as
monsters, levels, etc. can be added and a user-defined description
provided as well. Adding new indexes is simplified with an option for
adding a specific index within a portion of the editor by right-
clicking the name list or index number. The user can also load a 
selected index in the notes database manager into its respective 
portion of the editor where it can be modified there.

The patch feature reads a list of patches from the currently defined
patch server http:// or ftp:// location and can apply those patches to
the currently loaded ROM image.

A previewer for levels, event scripts and battle scripts lets the user
load a temporary ROM created from the current modifications in the
currently loaded ROM image into an emulator of choice (the only options
so far are ZSNES and SNES9X). Lazy Shell will create a save state 
which, when loaded, will immediately enter the current level or 
initiate the current event or battle script.

There are many more smaller features which are too numerous to list
here, and are scattered throughout the editor with the purpose of
easing the use of Lazy Shell and reducing the amount of work required
to complete a task.

That's what all of these extra features are here for. Not as bells and
whistles, but for making the hacking process less headache-inducing.

______________________________________________________________________

UNSUPPORTED FEATURES
______________________________________________________________________

Lazy Shell can NOT edit the Moleville Mountain tracks, raw SPC music/sfx 
data, menu graphics, the new game intro sequence and graphics, or the end 
credits. It cannot make any changes to 65c816 assembly code in the ROM 
image (with the exception of defense timing). Additionally, ROM expansion 
is also not supported by the application due to the complications of the 
SA-1 chip in the game's engine.

______________________________________________________________________

USING THE PREVIEWER
______________________________________________________________________

Before using the previewer, do the following:

1. Make sure all editor files are in the same folder.
2. Move the emulators into the same folder as the editor files.
3. Configure the emulators to read and save into the same folder that
   the emulators and the editor files are in.

Choose either the SNES9X or ZSNES emulator file to use when opening the
previewer. ZSNES will automatically load the generated save state when 
the emulator is loaded from the previewer, but for SNES9X the F1 key 
must be pressed manually to load the generated save state. If the
emulator has problems loading the save state, make sure the 3 steps
above have been completed.

______________________________________________________________________

FILES IN ARCHIVE
______________________________________________________________________

*** Make sure all files stay within the same directory as each other, 
or there will be problems running Lazy Shell ***


"LAZYSHELL.exe"

The application.


"Lunar Compress.dll"

Generates automatically when needed.
This file is essential to Lazy Shell's functionality. It decompresses 
and compresses the data that Lazy Shell modifies. It is needed to run 
the Stats, Levels, and Sprites editors and must be in the exact same 
directory as LAZYSHELL.exe. Without it, the program is almost 
completely functionless.


"RomPreviewBaseSave.000"
"RomPreviewBaseSave.zst"

These generate automatically when needed.
Base savestates for SNES9X and ZSNES, respectively. These are needed 
for previewing levels, event scripts, and battle scripts using either 
ZSNES or SNES9X. To avoid complications, make sure the emulators are 
in the same directory as everything else and that their save 
directories are configured likewise.


"changes.txt"

All of the fixes, modifications, and additions since the earliest 
versions are chronicled here.


"readme.txt"

This file.