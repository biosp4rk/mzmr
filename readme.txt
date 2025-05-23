Metroid Zero Mission Randomizer Plus

-----------------
Table of Contents
-----------------
1. Overview
2. Usage
3. Items
4. Locations
5. Palettes
6. Text
7. Music
8. Stats
9. Misc
10. Hack Specific Notes
11. Version History (MZMR+)
12. Version History (MZMR)
13. Links

-----------
1. Overview
-----------
Metroid Zero Mission Randomizer Plus is a program created by biospark (with item placement logic by Dragonfangs) and expanded on by Captain Glitch that lets you randomize various aspects of Metroid Zero Mission, primarily item locations. It can also randomize palettes, enemies, text, music, bosses, and enemy stats. It is only compatible with the North American (U) version of the game.

The program can also randomize certain ROM hacks. As of right now, the supported hacks include: 
	Deep Freeze (logic by Captain Glitch)
	Scrolls Six (logic by Captain Glitch) 
	Spooky Mission (logic by Captain Glitch)
	Spooky Mission 2 (logic by Conner, Jiffy, and Whalerynth)
	SR387 (logic by OneOf99)
	Winter Mission (logic by Ing-Ing) 
Certain options are disabled when randomizing hacks. 

Bug reports and questions should be directed to the MZMR+ thread on the Metroid Construction forums: https://forum.metroidconstruction.com/index.php/topic,5051.msg66266.html#msg66266
You can also find the latest updates and releases there.

--------
2. Usage
--------
To start, open an unmodified ROM of Metroid Zero Mission. ROMs that have been previously randomized cannot be used. Once the ROM is open, you can select a variety of randomization settings. All of the settings have tooltips if you hover over them, which explain their functions. You can reuse settings by saving them to a file and loading them later. You can also load settings from a string, which can be found after randomization or in a log file.

You can specify the seed to use for randomization, which must be a number between 0 and 2147483647. If left blank, a random seed will be chosen. Unless you're using the same seed and settings as someone else, there's no reason to provide a seed.

Click on the gear icon to bring up application settings. Here, you can enable some time-saving options, including automatically loading the previous ROM and randomization settings, and always saving a log file and map images.

--------
3. Items
--------
You can randomize the location of abilities (such as Wave Beam, Hi-Jump, etc.), tanks (Energy, Missile, Super Missile, Power Bomb), or both. You can also remove up to 90 items. Removed items are marked as collected on the minimap.

The "Game Completion" setting places restrictions on where items are located. If "No logic" is selected, there are no restrictions. However, you will immediately get stuck if Morph Ball is not the first item. "Beatable" means enough items can be obtained to beat the game. "100%" means that all items can be obtained.

There are two settings that remove item requirements, since they may be located somewhere inaccessible. One makes Metroids vulnerable to missiles when not frozen, and the other makes black space pirates vulnerable to beams other than Plasma. Neither of these items is required elsewhere.

The "No PBs before Chozodia" setting places restrictions on where Power Bombs are located. No Power Bombs can be obtained to enter Chozodia early, forcing you to fight Mother Brain and do the suitless sequence. Normally the game will softlock if you obtain Power Bombs before Bombs, but the game has been modified to prevent this.

The "Chozo statue hints" setting makes Chozo statues show the new location of each item. For example, the very first Chozo statue in the game will show where Long Beam is. If left unselected, Chozo statues won't show any hints.

The "Power Bomb Jumping" option enables power bomb jumping and allows power bombs to activate morph cannons.

If you aren't skilled at bomb jumping or wall jumping, you can leave these options unselected. This will ensure that these tricks are never required to beat the game (if you selected "Beatable") or collect all the items (if you selected "100%").

------------
4. Locations
------------
You can specify what to do with the item at each location. By default, every item is included in the pool for randomization. For each location, you can leave it as random, remove the item, or set it to a specific item.

You can see the location list of each game by going to the "Locations" tab. 

-----------
5. Palettes
-----------
You can randomize the colors of tilesets, enemies, Samus, and beams. This works by changing the hue of each palette (much like rotating a color wheel). You can specify the hue rotation range, between 0-180 degrees. For each palette, the hue is randomly rotated clockwise or counter-clockwise by a random amount within the range.

-----------
6. Text
-----------
You can randomize various text throughout the game. The text is read from the files in the Text folder. To create custom strings, simply edit one of the files.
Each string must be on it's own line. Special bracketed expressions are allowed for formatting control (invalid expressions will be ignored):
[NEWLINE] - creates a line break
[WEAPON] - inserts a random weapon name 
[EQUIPMENT] - inserts a random equipment name 
[AREA] - inserts random area name
[DIFFICULTY] - inserts random difficulty name
[NUMBER] - inserts a random number from 0-100
[UP] - inserts the respective GBA button icon
[DOWN]
[LEFT]
[RIGHT]
[A]
[B]
[L]
[R]
[COLOR] - sets text to random color
[GREY] - sets text to respective colors
[LIGHTGREY]
[WHITE]
[YELLOW]
[RED]
[PINK]
[GREEN]
[BLUE]
[TEAL]
[MECHA] - inserts the name of the boss in mecha's room. 
[RIDLEY] - inserts the name of the boss in ridley's room. 
[KRAID]  - inserts the name of the boss in kraid's room. 
[LONG]	- inserts the location name the specified item is found in. If not found, inserts "Another Seed"
[ICE]
[WAVE]
[CHARGE]
[PLASMA]
[VARIA]
[GRAVITY]
[HIJUMP]
[SPEEDBOOSTER]
[SPACEJUMP]
[MORPH]
[POWERGRIP]
[SCREWATTACK]
[BOMB]
[WEAPONLOC]	- inserts location of random weapon, includes all beams, missiles, and bombs
[EQUIPMENTLOC]	- inserts location of random ability, does not include beams and bombs
[MAJORITEM]	- inserts location of random major item


Items will change the item names and descriptions. It will not change the status screen. Areas will change the location messages. 

Cutscene will change the long messages seen at the start of the game and the ones at the start of the Zero Suit section.

Misc. will change file-screen and misc. messages such as save messages.

-----------
7. Music
-----------

You can randomize the room and boss music in the game. You can also choose to enable custom music. (Credit to JRP and Xl for creating the tracks).

Each option has a "No Logic" and "With own pool" setting. No Logic will assign any valid track randomly, and will often result in each room having a different song.
With own pool will ensure that each song is replaced with only one other song. 

-----------
8. Stats
-----------
Randomizes the stats of various enemies throughout the game. You must specify a range for health and damage randomization. 

Health and Damage stats are randomized based on a range that you define. Note that the ranges are percentages.

Drop stats are randomized to give enemies different drop values than they normally would.

Certain enemies are excluded from certain stat changes especially when related to vulnerabilities to prevent potential softlocks.  

Keep in mind that softlocks may still be possible in rare situations and that the difficulty caused by the stat changes may be unbalanced. 

-------
9. Misc
-------
There are a variety of options you can select that affect gameplay, most of which are enhancements. The option "Obtain unknown items" is taken into account by the "Game Completion" setting.

There's an option to randomize enemies, but it's somewhat limited for now. More enemy randomization features will be added in future updates.

There is also an option to randomize bosses. This option will choose between a small pool of fusion and vanilla bosses to replace Mua, Kraid, Ridley, and Mecha. These bosses are affected by the stat and palette randomization options.

Boss health is scaled based on which location the boss is chosen to reside in. More bosses will be added to the pool in future updates. The current supported bosses are listed below:

Arachnus
BOX
BOX2
Kraid
Mecha
Mua
Nettori
Nightmare
Ridley
Serris
Varia-X
Yakuza

------------------
10. Hack Specific Notes
------------------

DEEP FREEZE: In order to access the GITGUD and Kraid areas, the player must first kill Imago then the Barisute in the spawn room, or first kill Ridley and then the Barisute in the large room by the GITGUD room.

SPOOKY MISSION: You can force a seed that requires all 3 spooks by using either the "Locations" or "Rules" tab. Simply force Screw Attack to be located in the pumpkin using one of those tabs.

SPOOKY MISSION 2: The "Force Early Morph Jump" option forces either springball, bombs, or 2 power bombs (if PB jumping is enabled) in the Crypt to help prevent seeds that have several softlock/point-of-no-return item locations.
The "Hard Tricks" option includes various challenging and niche tricks ranging from mid-air morphing in a three tile gap to hard shinespark chains.


------------------
11. Version History (MZMR+)
------------------
V 1.7
- Mua's boss location is now included in the boss randomizer.
- Reworked how the boss randomizer imports new boss rooms. Will make adding new bosses easier down the line.
- Credits will not show all item locations if items are not randomized.
- Fixed bug that would corrupt ROM Hacks if items were not randomized.
- Actually fixed the issue in Spooky Mission 2 where two different item locations were always the same item.
- Changed how bosses check to block plasma pierce, removing lag for them. (Courtesy of jasinchen).

V 1.6 2024-12-15s
- Added Power Bomb Jumping option.
- Changed how custom music is added in music rando. Allows for hacks to have the custom music option.
- Changed how randomizing room music within own pool works. Should work better with hacks.
- Fixed Scrolls VI logic not having a couple one-way connections in Mons.
- Added missing bomb locks in Deep Freeze logic.
- Fixed broken animated tileset in Scrolls VI.
- Fixed Varia-X getting stuck in a wall...again.
- Added patch to allow credits to use more ASCII characters.
- Credits now show seed settings as well as credits for MZMR and item placement logic.
- Credits theme is now randomized with random music option.
- Fixed issue in Spooky Mission 2 where two different item locations were always the same item.
- Lowered music volume for the SMB Underground theme.
- Fixed an issue that stopped the program from opening when attempting to load an out-of-date settings string when updating to a new version.
 

V 1.5 2024-06-10
- Added Spooky Mission 2 and Winter Mission randomizer.
- Made Spooky Mission's secret ending image unobtainable.
- Fixed issue with Spooky Mission logic not accounting for random enemies.
- Fixed issue with SR387 logic not accounting for bomb requirement in multiple places.
- Fixed issue with Deep Freeze logic not accounting for morph ball requirement for a powerbomb door.
- Fixed issue where randomizing enemies in Deep Freeze could prevent access to certain rooms.
- Fixed some potential tiling errors when items replace certain tiles in Deep Freeze.
- Fixed issue in Scrolls VI where animated graphics would corrupt.
- Changed Spooky Mission and Scrolls VI tilesets to show correct palettes and animated GFX for items.
- Random names for tank items are now consistent. 
- Added a few more text strings.
- Credits now show item locations.

V 1.4 2024-05-13
- Added Metroid Scrolls VI and SR387 randomizer.
- Can now randomize music for Spooky Mission.
- Item Log now shows proper area names for hacks.
- Disabled the "Remove cutscene" and "skip suitless" options for hacks.

V 1.3.1 2024-03-24
- Fixed crashes related to Varia X and Ridley.

V 1.3 2024-03-19
- Unified item prefix text to one file. 
- Boss rando now repoints sprite data to ease adding new bosses later.
- Added Nettori and BOX 1 to Boss rando.
- Internal revisions to Music and Stat rando code.

V 1.2 2023-10-24
- Merged MZMR 1.5 version with MZMRR, renamed to MZMR+. 
- Added option to randomize Metroid: Deep Freeze and Spooky Mission ROM hacks.
- Removed "Misc 2" tab, replaced with "Enemies" tab.
- Changed text rando to read from file to allow for user input.
- Modified text rando code to auto format strings based on bracketed expressions and length.
- Added Mega Core X to boss rando.
- B.O.X.'s body, Yakuza's head, and most of Nightmare now blocks plasma beam pierce. Adds difficulty though can cause some lag as a result.
- Serris will only splash if it touches a liquid. 
- Fixed Nightmare Body Damage

V 1.1 2023-02-26
-Added boss randomization
-Optimized freespace usage in rom.
-Added aditional text strings.
-Adjusted vulnerability randomization to make beam weakness more likely.
-Adjusted music randomizer to account for custom bosses.
-General code cleanup.  


V 1.0 2022-09-20
-Integrated Random Randomizer with current released version of biospark's item randomizer.
-Text alignment will now always be centered for message-type texts.
-Added a few more strings to text pools.
-Added a custom music option for music randomization.
-Added a stat randomizer for enemies.

V 0.5 2020-11-08
-Recoded program to use some more acceptable practices and made some optimizations.
-Tweaked enemy randomization. (Needs to be tweaked once more to remove some unused
refill bugs that don't work properly.)
-Added a couple more strings to difficulty names, item descriptions, and prefixes.
-Added randomization for most boss music triggers and a couple other situations.
-Added new music randomization options: Structured and Dumb.

V 0.4 2020-01-26
-Code cleanup
-Added a couple extra text pools for things like "capacity increased" and "acquired" messages.
-Made tank pickup messages one name rather than two.
-Added spriteset randomization.

V 0.3 2022-01-??
-Fixed a crash caused by overwriting opened rom.
-Added music randomization for rooms. Effects all rooms other than debug rooms in Chozodia.
-Added more strings.

V 0.2 2019-11-10
-Optimized freespace searching.
-Increased various string pools.
-Output file no longer sticks around if randomization fails.
-Fixed an issue where the seed could be larger than the max value.

V 0.1 2019-11-06
-Release

------------------
12. Version History (biospark's randomizer)
------------------
1.5.0 - 2023-08-10
  - New item placement system with customizable logic by Dragonfangs
  - Added options to disable wall jumping and infinite bomb jumping
  - Fixed "Skip suitless sequence" when "Remove cutscenes" is also enabled
  - Improved palette randomization by using CIELAB color space
  - Fixed bug where user settings from previous version could prevent program from loading
  - Fixed bug where loading a config string wouldn't reset custom item assignments
  - Fixed bug where manually removing items at locations wouldn't update the minimap
  - Simplified program settings
  - Moved config string settings to separate window
  - Added reset button to "Locations" tab
  - Added item numbers to included map images

1.4.0 - 2021-07-05
  - Added option to randomize abilities and tanks separately
  - Added option to specify number of abilities to remove
  - Added option to randomize Samus palettes
  - Improved performance of Locations tab
  - Under Game Completion, renamed "Unchanged" to "No logic"
  - "Remove cutscenes" option removes a couple more cutscenes
  - Doubled map image sizes
  - Floating-eye sensors are now always vulnerable
  - Customized title screen graphics

1.3.2 - 2020-12-01
  - Config strings from version 1.3.0 and later are now compatible
  - Fixed bug where enemies were always randomized

1.3.1 - 2020-11-27
  - Fixed bug where selecting "Unchanged" for game completion would crash the program
  - Fixed extra long config strings in the intro text
  - Added warning when trying to overwrite the original ROM file
  - Minor item logic fixes

1.3.0 - 2020-11-24
  - Added option to remove up to 90 items
  - Added option to provide custom item assignments
  - Added option to randomize enemies
  - Added option to skip door transitions
  - Removed option to remove Varia Suit animation (now it is always removed)
  - Removed option to remove Norfair vine (now it is always removed)
  - Fixed bug with hue rotation
  - Fixed probability of Space Jump replacing Morph Ball (was too low before)
  - Added hash icons to file select screen
  - Title screen demos are now disabled
  - Shooting Ruins Test with a non-pistol beam now hurts Samus
  - Triggering the alarm in Chozodia never changes the music
  - Removed duplicate versions of rooms in Crateria
  - Fixed bug where Varia Suit's item wouldn't spawn after obtaining fully powered suit
  - Fixed music that plays when suitless sequence is skipped
  - Config strings from previous versions are no longer valid

1.2.1 - 2018-10-13
  - Improvements to item requirement logic
  - Added potential for Space Jump to replace Morph Ball

1.2.0 - 2018-10-11
  - Power Bombs can be obtained before Bombs without softlocking the game
  - Redefined item requirement logic to account for Power Bomb fix
  - Modified palette randomization to adjust for brightness
  - Randomizer version, seed, and settings are now provided during the intro cutscene
  - "Remove cutscenes" option removes a few more cutscenes
  - Added "Chozo statue hints" option for item randomization
  - Added "Infinite bomb jump" and "Wall jumping" options for item randomization
  - Added application settings with some time-saving options

1.1.0 - 2018-01-12
  - Fixed Power Bomb placement when "Obtain unknown items" is selected
  - Settings aren't reset after randomizing
  - Added option to skip suitless sequence
  - Fixed requirements for Long Beam's item
  - Added automatic conversion for older settings

1.0.0 - 2017-12-21
  - Initial release

--------
13. Links
--------
MZMR forum thread:
http://forum.metroidconstruction.com/index.php/topic,4559.0.html

MZMR Github repository:
https://github.com/biosp4rk/mzmr

MZM speedrunning Discord:
https://discord.com/invite/0ePDppd9djuPisZp
