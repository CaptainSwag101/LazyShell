LAZY SHELL - Super Mario RPG Editor
Version: 3.9.3
Date: April 27, 2012
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
The monsters editor contains a battle script editor for each monster.

The Levels portion allows the user to modify the maps of areas (aka 
locations) using a paint-like interface, the NPCs (ie the sprites in 
the maps), the exit fields (aka entrances), event fields, overlaps, 
and the basic layering properties. A template creator/editor lets the 
user to store a separate portion of the map composed of all 3 layers 
and the physical layer into a single file.

The two scripts editors in Lazy Shell enable the user to modify
the event scripts, action scripts, and animations scripts. Commands 
within event scripts and action scripts may be added, modified, 
deleted, moved, or copied and pasted. Commands within animation 
scripts may be modified, moved, or replaced with new commands of
the same or smaller length, but adding/deleting entirely new commands 
within animations is not supported and never will be due to the 
fickle and erratic nature of the animation script engine.

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

______________________________________________________________________

BUGS, ERRORS, EXCEPTIONS AND COMPLICATIONS IN FUNCTIONALITY
______________________________________________________________________

The editor may occasionally crash or not function properly due to 
certain errors in the code (although with each new bugfix I am aiming 
to completely remove the possibility of this ever happening). Please 
remember that this is almost certainly the programmer's fault and NOT 
yours, the user's. As often is the case, when an error surfaces or the 
program behaves in a buggy fashion, the user tends to immediately feel 
that they are to blame or the programmer is blaming them for the error. 
This is not correct: almost all of the time, it's the programmer's 
fault. Incidences when it might be the fault of the user may be due to 
a corrupt ROM being loaded (a corrupt ROM basically means any SMRPG 
rom which has been modified in any way, shape or form). This includes 
a ROM edited by Lazy Shell, but errors may occur if a ROM has been 
modified outside of Lazy Shell (ie. a hex editor), or often times in 
much older versions of Lazy Shell (v2.5 seems to be popular among 
users who find problems with v3.x).

If the editor crashes, make sure it is the latest version of Lazy 
Shell by clicking the "(i)" button in the main window and comparing 
the version there to the version posted on the home page 
(http://home.comcast.net/~giangurgolo/smrpg/).

If you are using the latest version, make a new post in this thread:
http://acmlm.kafuka.org/board/thread.php?id=6770
Explain exactly what you did to produce this error or cause this 
disfunctionality to occur, what editor it was in, what order you did 
your actions to produce this error or disfunctionality, etc. Also, 
when the editor bugs out, an exception prompt appears. If you can 
manage to copy no more than the FIRST TEN LINES following this line:
************** Exception Text **************
and include this in your post, it will definitely help. But most 
importantly, you must explain in your post what you did. Only 
posting the exception text alone will not be adequate enough.

The suggestions above are only suggestions. Sometimes only five 
words might be enough for me to quickly locate the bug and fix it. 
Remember, an error or bug is most likely NOT YOUR FAULT. Don't be
afraid to report an error should it occur. I do notice and try to fix
every bug that is reported, so your post won't be in vain (unless 
you're making a request for an addition to the editor, which I am
now ignoring due to how time-consuming it can be).

______________________________________________________________________

SPECIAL THANKS
______________________________________________________________________

Yakibomb - discovered many bugs with later versions
ElementalPowerStar - feedback, discovered several bugs
Bregalad - source code for BRR encoding and decoding
FuSoYa - for permission to use Lunar Compress.dll
KP9000 - beta testing, discovered many bugs with pre-release version
MathOnNapkins - helped with some coding
Alex Farber - MRU list manager
spel werdz rite - resolution for running program under a 64-bit OS
romhacking community - various feedback

______________________________________________________________________

F.A.Q. (Frequently Asked Questions)
______________________________________________________________________

Q: I have no idea what _____ means!
A: Enable the help feature in the editor. If this feature is enabled, 
   you'll be able to see a description of the property and what it 
   does by moving the mouse over it. Click the (?) icon at the top of 
   most editors or press F1 to enable/disable the help feature.

Q: How do I add a new _____?
A: You cannot add new indexes of any element, but you can replace the
   properties of existing elements. That is the basic rule of hacking
   SMRPG. Many elements, like sprites, have dummied or unused indexes
   which you may edit or modify to "add" new stuff. Lazy Shell should
   not be viewed as an expansion tool but as a modification tool.

Q: I'm looking specifically for the _____.
A: Most of the editors have a search field to the right of the index
   list, tagged with a magnifying glass icon. Use that to search for a
   specific index with a general description, name, or whatever.

Q: The editor crashed and I lost my work!
A: First, try clicking "Ignore Error" and saving as a separate ROM.
   Then, try exporting the indexes that didn't glitch out into .dat 
   files and import those into a fresh, uncorrupted ROM. In the 
   future, enable the back-up feature in the settings: click 
   the grey cog icon in the main window to open the settings. There 
   are two types of back-ups: you can back-up on load and/or save.
   Thus you can roll back to an earlier edit before the ROM got
   corrupted by the program. 
   
Q: What do these "B#,b#" things mean?
A: These are unknown bits. "B0,b0" means "Byte 0, bit 0" and refers
   to bit 0 in the first byte of the index's property data chunk.
   If you're confident you have discovered exactly what these bits
   do, feel free to post it in the bug report thread:
   http://acmlm.kafuka.org/board/thread.php?id=6770

Q: What are Lazy Shell's most powerful features?
A: 1. The "Import Image(s)" functions in the sprites and effects
      editors allow the user to replace existing sprites with entirely
	  new sprite animations from external image files. These were 
	  quite difficult to write the code for, but very rewarding in
	  that they ultimately added a lot more muscle to the editor.
   2. The palette editor's "Adjust RGB" and "Effects" features let
      the user apply all kinds of effects to the colors, from RGB
	  swapping, grayscale, contrast/brightness, colorizing, and more.
	  You can create your own palette swaps of sprites, levels, etc.
   3. The "New Font Table" feature in the dialogues editor in the
      font editor panel lets you replace the SMRPG font with any font
	  installed on your system.
   4. You can flip entire battlefields by just selecting the whole
      battlefield, right-click, and click "mirror" or "invert".
   5. A built-in hex editor lets the user edit the raw hex data of
      several elements in the game.
________________
ANIMATION EDITOR
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
Q: I want to add new commands.
A: You cannot do this, you can only replace or edit commands.

Q: Where's the list of command opcodes for animations?
A: Download the documents archive at:
   http://home.comcast.net/~giangurgolo/smrpg/smrpg_docs.zip
   The docs_ani-code.txt file contains all opcodes decoded thus far.

Q: I want to change a sprite in an animation to something else.
A: You'll want to modify the "Current object = sprite: whatever" 
   commands. Modify its properties in the "CURRENT COMMAND PROPERTIES"
   panel on the right and click apply when you are finished.
   Alternatively you can change the hex values below.
_____________
LEVELS EDITOR
¯¯¯¯¯¯¯¯¯¯¯¯¯
Q: Some tiles keep overlapping the NPCs.
A: Those tiles most likely have priority 1 enabled on one or more of
   their subtiles. To stop this, replace the solidity tile at that
   spot with a corresponding solidity tile with the "Priority 1
   enabled for objects on tile" checked. Otherwise, it could be an
   overlap tile. To stop this, delete the overlap at that spot.

Q: My custom level just appears black in-game, music playing.
A: Make sure the layer mask's boundaries are within those of your
   new custom level.

Q: How do I add something like an NPC to a level?
A: The tabs on the left panel, ex: the "NPCs" tab, contain buttons
   at the top of the tab window that let you insert, delete, copy,
   etc. NPCs, events, exits, overlaps, or mods.

Q: The NPC graphics are glitchy in-game.
A: You'll want to try changing the "Partition" property. You can
   look for the best partition index for the level by using the
   parition searcher (accessible with the "Partition" button).
   Keep in mind the game only has so much video memory to store the
   sprites to, so too many large NPCs may just be impossible to show.
______________
SPRITES EDITOR
¯¯¯¯¯¯¯¯¯¯¯¯¯¯
Q: I want to make a new sprite animation from image files.
A: Use the mold import feature: the black down arrow and white box [v]
   icon directly over the mold list tagged "Import Image(s)". You may 
   import one or more images over the current molds or append to the 
   current molds.
   
______________________________________________________________________

GLOSSARY
______________________________________________________________________

"2bpp" and "4bpp"
These mean "2 bits per pixel" and "4 bits per pixel", and refer to the
format that graphics are in. Graphics in 2bpp format can only use a
maximum of 4 colors, whereas 4bpp graphics can use up to 16 colors.
The Big Boo in Bowser's Terrorize spell only needs 4 colors, thus
the graphics are in 2bpp format to conserve ROM space.

"bit"
One-eighth of a byte. Sort of like sub-slots in a memory address.
Generally, bytes are either read as a single value from 0 to 255, or
as a set of 8 bits. Example: the item slots are single byte values and
are not read bit-wise. Conversely, the new game ally spells known are 
individual bits that not read byte-wise and require four bytes (32
bits) for their data. Bits are either "set" or "clear". For instance,
the "Jump" bit (bit 0) for new game ally spells known for Mario is set
but "Fire Orb" and the rest are not.

"command"
Example: in the first encounter with Terrapins, the script contains a
command "Engage battle, pack: 1, battlefield: [07]" which initiates
the battle with the Terrapins.

"element"
Generally a part of the ROM that has multiple indexes. Monsters are
an element that has 256 indexes (0 to 255). Levels are another
element that contains 510 indexes, etc.

"event"
A script that can be initiated a number of ways. Mainly through event
fields.

"exit field"
A field which, when Mario touches it, will load a new level. Other
ROM editors sometimes call these "entrances".

"field"
An invisible thing in a level that triggers an event or operation when
Mario touches it. Event and exit fields, for example.

"hex" or "hexadecimal"
A numeric system who's places are based on 16's and not 10's like in
"decimal". With just one decimal place, you can count up to 9, but
in just one hexadecimal place you can go up to 15. This is because
the numbers 10-15 are A-F respectively. Thus in just two hexadecimal
places the numbers can go up to 255, which is why this number is so
common throughout the editor. With three hex places, 4096 is highest.
The editor displays only memory addresses in hex format (eg. 00:709F)
with all other elements being in decimal.

"index"
Example: TERRAPIN is an index in the monster element (index 0). The
level for Mario's Pad is index 16 in the levels element, etc. You 
can modify the properties of each index by switching to or among 
them in the editors using either its drop down list or immediately 
with its numeric up/down.

"layer"
SMRPG uses five layers: L1, L2, L3, NPCs, BG. By default, NPCs
appear on top of all other layers (excluding priority 1 tiles). After
that, L1 appears on top, followed by L2, L3, and BG. The BG is simply
the solid background color behind everything else.

"level"
The places and areas you can enter in-game. Many ROM editors also 
refer to these as "locations".

"memory address"
A "slot" where the game stores information that it needs to access
later. Example: the 30 slots for items (7F:F882 to 7F:F89F) have 
memory addresses. The memory addresses  are the items. Completed 
events, like defeating the Hammer Bros (00:7052, bit 6), are stored as
a bit in a memory address. A memory address has 8 bits.

"mods"
These can change the tiles or solidity tiles of a level. In the levels
editor, there are two types of mods: tile mods and solidity mods.
Example: Croco blowing up the wall in Moleville Mines.
Example: the green button in Rose Town removing/adding stairs outside.

"npc"
Abbreviation for "non-playable character". They are basically the
sprites seen in-game in a level, excluding battles, but with a number
of properties all described by the help tags in the levels editor.
An NPC is not the same as a sprite, it merely has a sprite index
assigned to it among a bunch of other attributes.

"palette"
A set of colors used to draw something. Almost all palettes are 16
colors, except for layer 3 graphics, fonts, and some effect graphics.
SNES games like SMRPG are somewhat limited in the number of colors
they can display, which is why imported image files can decrease
dramatically in quality.

"script"
Examples: event scripts, action scripts, battle scripts, animations.
A list of 0 or more commands that carry out an action on screen
in the game, such as Toad running into Mario near the beginning of
the game, or Bowser using "Crusher" in battle, or randomly 
selecting either "Lighting Orb" or "Bolt" used by THE BIG BOO.

"tilemap"
An example: Levels are 64 rows of tiles, each row is 64 tiles.
Many sprites are "tilemaps" themselves, but here each tile would
have its own coordinate instead of being placed in a grid like
levels. Do not mistake tilemaps with tilesets.
   
"tileset"
A collection or "palette" of tiles used to draw to a tilemap.

"trigger"
To cause something to happen, such as an event, when Mario comes into
contact with something.