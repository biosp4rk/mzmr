Metroid Zero Mission Randomizer

-----------------
Table of Contents
-----------------
1. Overview
2. Usage
3. Items
4. Palettes
5. Misc
6. Version History

-----------
1. Overview
-----------
Metroid Zero Mission Randomizer is a program created by biospark that lets you randomize various aspects of Metroid Zero Mission, primarily item locations. It can also randomize palettes, and other types of randomization are planned for the future. It is only compatible with the North American (U) version of the game.

Bug reports and questions should be directed to the MZMR thread on the Metroid Construction forums: http://forum.metroidconstruction.com/index.php/topic,4559.0.html
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
You can randomize the location of abilities (such as wave beam, hi-jump, etc.), tanks (energy, missile, super missile, power bomb), or both. Additionally, you can specify items to leave unchanged by entering their numbers (between 0-99) separated by commas. The item numbers can be found in a log file.

The "Game Completion" setting places restrictions on where items are located. If unchanged, there are no restrictions. However, you will immediately get stuck if morph ball is not the first item. "Beatable" means enough items can be obtained to beat the game. "100%" means that all items can be obtained.

There are two settings that remove item requirements, since they may be located somewhere inaccessible. One makes Metroids vulnerable to missiles when not frozen, and the other makes black space pirates vulnerable to beams other than plasma. Neither of these items is required elsewhere.

The "No PBs before Chozodia" setting places restrictions on where power bombs are located. No power bombs can be obtained to enter Chozodia early, forcing you to fight Mother Brain and do the suitless sequence. Normally the game will softlock if you obtain power bombs before bombs, but the game has been modified to prevent this.

The "Chozo statue hints" setting makes Chozo statues show the new location of each item. For example, the very first Chozo statue in the game will show where long beam is. If left unselected, Chozo statues won't show any hints.

If you aren't skilled at bomb jumping or wall jumping, you can leave these options unselected. This will ensure that these tricks are never required to beat the game (if you selected "Beatable") or collect all the items (if you selected "100%").

-----------
4. Palettes
-----------
You can randomize the colors of tilesets, enemies, and beams. This works by changing the hue of each palette (much like rotating a color wheel). You can specify the hue rotation range, between 0-180 degrees. For each palette, the hue is randomly rotated clockwise or counter-clockwise by a random amount within the range.

-------
5. Misc
-------
There are a variety of options you can select that affect gameplay, most of which are enhancements. The option "Obtain unknown items" is taken into account by the "Game Completion" setting.

------------------
6. Version History
------------------
2.0.0 - WIP
  - Fixed probability of space jump replacing morph ball
  - Added option to remove up to 90 items
  - Triggering the alarm in Chozodia never changes the music
  - Fixed music that plays when suitless sequence is skipped
  - Added option to provide custom item assignments
  - Added option to skip door transitions
  - Title screen demos are now disabled
  - Removed option to remove Varia Suit animation (now it is always removed)
  - Removed option to remove Norfair vine (now it is always removed)
  - Fixed bug where Varia Suit's item wouldn't spawn after obtaining fully powered suit
  - Shooting Ruins Test with a non-pistol beam now hurts Samus
  - Fixed bug with hue rotation
  - Removed duplicate versions of rooms in Crateria
  - More fixes to item requirement logic

1.2.1 - 2018-10-13
  - Fixed item requirement logic that caused unbeatable seeds
  - Added potential for space jump to replace morph ball

1.2.0 - 2018-10-11
  - Power bombs can be obtained before bombs without softlocking the game
  - Redefined item requirement logic to account for power bomb fix
  - Modified palette randomization to adjust for brightness
  - Randomizer version, seed, and settings are now provided during the intro cutscene
  - "Remove cutscenes" option removes a few more cutscenes
  - Added "Chozo statue hints" option for item randomization
  - Added "Infinite bomb jump" and "Wall jumping" options for item randomization
  - Added application settings with some time-saving options

1.1.0 - 2018-01-12
  - Fixed power bomb placement when "Obtain unknown items" is selected
  - Settings aren't reset after randomizing
  - Added option to skip suitless sequence
  - Fixed requirements for long beam's item
  - Added automatic conversion for older settings

1.0.0 - 2017-12-21
  - Initial release
  