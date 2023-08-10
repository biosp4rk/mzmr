Metroid Zero Mission Randomizer

-----------------
Table of Contents
-----------------
1. Overview
2. Usage
3. Items
4. Locations
5. Logic
6. Rules
7. Palettes
8. Misc
9. Links
10. Version History

-----------
1. Overview
-----------
Metroid Zero Mission Randomizer is a program created by biospark (with item placement logic by Dragonfangs) that lets you randomize various aspects of Metroid Zero Mission, primarily item locations. It can also randomize palettes, enemies, and other types of randomization are planned for the future. It is only compatible with the North American (U) version of the game.

Bug reports and questions should be directed to the MZMR thread on the Metroid Construction forums: http://forum.metroidconstruction.com/index.php/topic,4559.0.html
You can also find the latest updates and releases there.

--------
2. Usage
--------
To start, open an unmodified ROM of Metroid Zero Mission. ROMs that have been previously randomized cannot be used. Once the ROM is open, you can select a variety of randomization settings. All of the settings have tooltips if you hover over them, which explain their functions. You can reuse settings by saving them to a file and loading them later. You can also load settings from a string, which can be found after randomization or in a log file.

You can specify the seed to use for randomization, which must be a number between 0 and 2147483647. If left blank, a random seed will be chosen. Unless you're using the same seed and settings as someone else, there's no reason to provide a seed.

--------
3. Items
--------
You can randomize the location of abilities (such as Wave Beam, Hi-Jump, etc.), tanks (Energy, Missile, Super Missile, Power Bomb), or both. You can also remove up to 90 items. Removed items are marked as collected on the minimap.

The "Game Completion" setting places restrictions on where items are located. If "No logic" is selected, there are no restrictions. However, you will immediately get stuck if Morph Ball is not the first item. "Beatable" means enough items can be obtained to beat the game. "100%" means that all items can be obtained.

There are two settings that remove item requirements, since they may be located somewhere inaccessible. One makes Metroids vulnerable to missiles when not frozen, and the other makes black space pirates vulnerable to beams other than Plasma. Neither of these items is required elsewhere.

The "No PBs before Chozodia" setting places restrictions on where Power Bombs are located. No Power Bombs can be obtained to enter Chozodia early, forcing you to fight Mother Brain and do the suitless sequence. Normally the game will softlock if you obtain Power Bombs before Bombs, but the game has been modified to prevent this.

The "Chozo statue hints" setting makes Chozo statues show the new location of each item. For example, the very first Chozo statue in the game will show where Long Beam is. If left unselected, Chozo statues won't show any hints.

------------
4. Locations
------------
You can specify what to do with the item at each location. By default, every item is included in the pool for randomization. For each location, you can leave it as random, remove the item, or set it to a specific item.

Below are all the locations and their original items. You can also find the item numbers on the included map images.
  0   Brinstar  (0, 15)   Morph Ball
  1   Brinstar  (5, 14)   Missile Tank
  2   Brinstar  (6, 6)    Long Beam
  3   Brinstar  (7, 15)   Energy Tank
  4   Brinstar  (9, 11)   Missile Tank
  5   Brinstar  (9, 12)   Super Missile Tank
  6   Brinstar  (11, 3)   Missile Tank
  7   Brinstar  (11, 12)  Missile Tank
  8   Brinstar  (14, 2)   Varia Suit
  9   Brinstar  (14, 12)  Charge Beam
  10  Brinstar  (16, 3)   Energy Tank
  11  Brinstar  (16, 12)  Missile Tank
  12  Brinstar  (17, 7)   Missile Tank
  13  Brinstar  (17, 10)  Missile Tank
  14  Brinstar  (22, 8)   Missile Tank
  15  Brinstar  (23, 4)   Missile Tank
  16  Brinstar  (23, 6)   Missile Tank
  17  Brinstar  (24, 6)   Bomb
  18  Brinstar  (24, 8)   Energy Tank
  19  Kraid     (3, 5)    Missile Tank
  20  Kraid     (6, 6)    Missile Tank
  21  Kraid     (7, 9)    Missile Tank
  22  Kraid     (7, 12)   Missile Tank
  23  Kraid     (7, 14)   Space Jump
  24  Kraid     (8, 8)    Missile Tank
  25  Kraid     (8, 15)   Speed Booster
  26  Kraid     (11, 4)   Missile Tank
  27  Kraid     (11, 6)   Missile Tank
  28  Kraid     (12, 10)  Missile Tank
  29  Kraid     (13, 2)   Energy Tank
  30  Kraid     (13, 7)   Energy Tank
  31  Kraid     (15, 4)   Missile Tank
  32  Norfair   (3, 11)   Power Bomb Tank
  33  Norfair   (4, 12)   Missile Tank
  34  Norfair   (6, 7)    Screw Attack
  35  Norfair   (8, 7)    Missile Tank
  36  Norfair   (10, 5)   Missile Tank
  37  Norfair   (10, 6)   Missile Tank
  38  Norfair   (10, 12)  Wave Beam
  39  Norfair   (11, 6)   Super Missile Tank
  40  Norfair   (11, 13)  Missile Tank
  41  Norfair   (13, 13)  Missile Tank
  42  Norfair   (14, 6)   Missile Tank
  43  Norfair   (15, 10)  Missile Tank
  44  Norfair   (17, 10)  Super Missile Tank
  45  Norfair   (18, 3)   Ice Beam
  46  Norfair   (19, 2)   Missile Tank
  47  Norfair   (19, 8)   Hi-Jump
  48  Norfair   (20, 4)   Missile Tank
  49  Norfair   (21, 1)   Missile Tank
  50  Norfair   (21, 11)  Energy Tank
  51  Norfair   (22, 8)   Missile Tank
  52  Norfair   (22, 11)  Missile Tank
  53  Ridley    (3, 8)    Missile Tank
  54  Ridley    (3, 9)    Missile Tank
  55  Ridley    (4, 6)    Missile Tank
  56  Ridley    (5, 7)    Energy Tank
  57  Ridley    (6, 7)    Gravity Suit
  58  Ridley    (7, 3)    Energy Tank
  59  Ridley    (8, 4)    Missile Tank
  60  Ridley    (8, 5)    Missile Tank
  61  Ridley    (9, 1)    Super Missile Tank
  62  Ridley    (9, 4)    Missile Tank
  63  Ridley    (9, 5)    Super Missile Tank
  64  Ridley    (10, 8)   Missile Tank
  65  Ridley    (12, 5)   Missile Tank
  66  Ridley    (13, 5)   Missile Tank
  67  Ridley    (14, 4)   Super Missile Tank
  68  Ridley    (16, 6)   Missile Tank
  69  Ridley    (17, 7)   Energy Tank
  70  Ridley    (19, 2)   Missile Tank
  71  Ridley    (22, 7)   Missile Tank
  72  Ridley    (24, 5)   Missile Tank
  73  Tourian   (17, 11)  Missile Tank
  74  Tourian   (19, 12)  Power Bomb Tank
  75  Crateria  (9, 4)    Power Bomb Tank
  76  Crateria  (14, 6)   Power Grip
  77  Crateria  (17, 8)   Missile Tank
  78  Crateria  (19, 5)   Missile Tank
  79  Crateria  (20, 5)   Plasma Beam
  80  Crateria  (21, 5)   Missile Tank
  81  Crateria  (22, 2)   Super Missile Tank
  82  Chozodia  (4, 18)   Power Bomb Tank
  83  Chozodia  (4, 21)   Super Missile Tank
  84  Chozodia  (6, 21)   Super Missile Tank
  85  Chozodia  (7, 19)   Super Missile Tank
  86  Chozodia  (10, 7)   Missile Tank
  87  Chozodia  (10, 8)   Super Missile Tank
  88  Chozodia  (10, 9)   Power Bomb Tank
  89  Chozodia  (10, 18)  Energy Tank
  90  Chozodia  (11, 13)  Super Missile Tank
  91  Chozodia  (14, 5)   Power Bomb Tank
  92  Chozodia  (15, 4)   Power Bomb Tank
  93  Chozodia  (15, 13)  Power Bomb Tank
  94  Chozodia  (17, 8)   Energy Tank
  95  Chozodia  (18, 7)   Super Missile Tank
  96  Chozodia  (20, 7)   Super Missile Tank
  97  Chozodia  (21, 15)  Super Missile Tank
  98  Chozodia  (22, 2)   Energy Tank
  99  Chozodia  (26, 14)  Power Bomb Tank

--------
5. Logic
--------
You can choose whether to use default logic for item placement, or use your own custom logic by selecting a file. You can also specify which tricks you want the logic to account for. For example, if you aren't skilled at bomb jumping or wall jumping, you can leave these options unselected. This will ensure that these tricks are never required to beat the game (if you selected "Beatable") or collect all the items (if you selected "100%").

--------
6. Rules
--------
You can specify rules that modify item placement. This allows you to place or exclude items in certain locations or areas. There are also options to change how early or late an item is placed during the randomization process.

-----------
7. Palettes
-----------
You can randomize the colors of tilesets, enemies, Samus, and beams. This works by changing the hue of each palette (much like rotating a color wheel). You can specify the hue rotation range, between 0-180 degrees. For each palette, the hue is randomly rotated clockwise or counter-clockwise by a random amount within the range.

-------
8. Misc
-------
There are a variety of options you can select that affect gameplay, most of which are enhancements. The option "Obtain unknown items" is taken into account by the "Game Completion" setting.

There's also an option to randomize enemies, but it's somewhat limited for now. More enemy randomization features may be added in future updates.

--------
9. Links
--------
MZMR forum thread:
http://forum.metroidconstruction.com/index.php/topic,4559.0.html

MZMR Github repository:
https://github.com/biosp4rk/mzmr

MZM speedrunning Discord:
https://discord.com/invite/0ePDppd9djuPisZp

------------------
10. Version History
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
  - Config strings from previous versions are no longer valid

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
  