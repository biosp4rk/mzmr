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
To start, open an unmodified ROM of Metroid Zero Mission. ROMs that have been previously randomized cannot be used. Once the ROM is open, you can select a variety of randomization settings. All of the settings have tooltips, which explain their functions. You can reuse settings by saving them to a file and loading them later. You can also load settings from a string, which can be found after randomization or in a log file.

You can specify the seed to use for randomization, which must be a number between 0 and 2147483647. If left blank, a random seed will be chosen. Unless you're using the same seed and settings as someone else, there's no reason to provide a seed.

--------
3. Items
--------
You can randomize the location of abilities (such as wave beam, hi-jump, etc.), tanks (energy, missile, super missile, power bomb), or both. Additionally, you can specify items to leave unchanged by entering their numbers (between 0-99) separated by commas. The item numbers can be found in a log file.

There are two settings that remove item requirements, since they may be located somewhere inaccessible. One makes Metroids vulnerable to missile when not frozen, and the other makes black space pirates vulnerable to beams other than plasma. Neither of these items is required elsewhere.

The "Game Completion" setting places restrictions on where items are located. If unchanged, there are no restrictions. However, you will immediately get stuck if morph ball is not the first item. "Beatable" means enough items can be obtained to beat the game. "100%" means that all items can be obtained.

The "Power Bombs" setting places restrictions on where power bombs are located. You shouldn't select "unchanged", because obtaining power bombs before bombs will softlock the game. "None before Chozodia" means no power bombs can be obtained to enter Chozodia early, forcing you to fight Mother Brain and do the suitless sequence.

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
1.2.0 - 2018-??-??
  - Fixed requirements for "Beatable" when "Ice beam not required" is selected
  - <Power bombs before bombs>
  - <Modified random palettes>
  - <Info on start screen>

1.1.0 - 2018-01-12
  - Fixed Power Bomb placement when "Obtain unknown items" is selected
  - Settings aren't reset after randomizing
  - Added option to skip suitless sequence
  - Fixed requirements for Long Beam's item
  - Added automatic conversion for older settings

1.0.0 - 2017-12-21
  - Initial release
  