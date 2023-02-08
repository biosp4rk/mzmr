Metroid Zero Mission Random Randomizer

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
10. Version History (MZMR)
11 Version History (MZMRR)

-----------
1. Overview
-----------
Metroid Zero Mission Randomizer is a program created by biospark and expaned on by Captain Glitch that lets you randomize various aspects of Metroid Zero Mission, primarily item locations. It can also randomize palettes, enemies, text, music, bosses, and enemy stats. It is only compatible with the North American (U) version of the game.

Bug reports and questions should be directed to the MZMRR thread on the Metroid Construction forums: https://forum.metroidconstruction.com/index.php/topic,5051.msg66266.html#msg66266
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

If you aren't skilled at bomb jumping or wall jumping, you can leave these options unselected. This will ensure that these tricks are never required to beat the game (if you selected "Beatable") or collect all the items (if you selected "100%").

------------
4. Locations
------------
You can specify what to do with the item at each location. By default, every item is included in the pool for randomization. For each location, you can leave it as random, remove the item, or set it to a specific item.

-----------
5. Palettes
-----------
You can randomize the colors of tilesets, enemies, Samus, and beams. This works by changing the hue of each palette (much like rotating a color wheel). You can specify the hue rotation range, between 0-180 degrees. For each palette, the hue is randomly rotated clockwise or counter-clockwise by a random amount within the range.

-----------
6. Text
-----------
You can randomize a large portion of text seen throughout the game. The text is chosen from an internal pool of strings. This may be changed in the future to allow for user submitted strings.

"Areas" is for location banners. "Cutscenes" is for the three major text walls seen at the start of the game and after beating Tourian. "Items" randomize the item banners and description texts. "Misc." will randomize difficulty names and a few other random messages.

-----------
7. Music
-----------

Randomizes room and boss music. The structured options will keep each music type within their own pool and will also replace room music identically to how the game does. No Logic will allow any track to be chosen and will randomize every room's track. 
The Custom Tracks box will allow for various custom made tracks to be in the pool of tracks.

-----------
8. Stats
-----------
Randomizes the stats of various enemies throughout the game. You must specify a range for health and damage randomization. 

Certain enemies are excluded from certain stat changes especially when related to vulnerabilities to prevent potential softlocks.  

Keep in mind that softlocks may still be possible in rare situations and that the difficulty caused by the stat changes may be unbalanced. 

-------
9. Misc
-------
There are a variety of options you can select that affect gameplay, most of which are enhancements. The option "Obtain unknown items" is taken into account by the "Game Completion" setting.

There's an option to randomize enemies, but it's somewhat limited for now. More enemy randomization features will be added in future updates.

This is also an option to randomize bosses. This option will choose between a small pool of fusion and vanilla bosses to replace Kraid, Ridley, and Mecha. These bosses are affected by the stat and palette randomization options.

Boss health is scaled based on which location the boss is chosen to reside in. More bosses will be added to the pool in future updates.

------------------
10. Version History (biospark's randomizer)
------------------
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

------------------
11. Version History (Random Randomizer)
------------------
V 1.1
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
