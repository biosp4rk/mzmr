Contents:
1)Files
2)How To Use
3)Notes
4)Credits

1). FILES
"AI.asm" is the main bulk of this patch. It contains all of the AI for Serris and his secondary sprites.
There are some comments provided in easily modified functions for reference. Any major changes will likely
break the AI. Know what you are doing before modifying.

"MFBoss.asm" is the file that is used to compile everything. The file also includes weakness and drop values 
for each sprite. 

The palette files are seperated in order to make writting the AI easier. 
"palette.pal" Contains the main sprite palettes for Serris.
"palette2.pal" Contains phase 2 palette for Serris.
"palette3.pal" Contains phase 3 palette for Serris.

"graphics.gfx.lz" Is the graphics used for everything.

2)HOW TO USE
Keep the directories set up the same way upon extraction. There must be a ZM rom named "zm.gba" in the direcotry.
Drag the "MFBoss.asm" file on to armips and if set up properly, it will compile and output a rom named "Serris.gba"
I also provided a basic room and tileset along side for a guidline on how serris' room must look. His attacks will not
look right if the room is not set up in a similar fasion. Also, Serris will drop ammo only if the player has no 
ammunition for either missile type. This is to prevent potential soft-locks. 

3)Notes
Serris only drops health when he dies. If you modify his drops, he will only choose only one drop type to spawn.
However his special "player has no ammo" drops can drop anything. 
Sound effects are as best as I could manage. Speedbooster sound effects wouldn't work, so don't ask please.
Same thing with the music. Importing his song is very possible, but it isn't worth the effort for me.

4)
I, CaptGlitch, have preformed all of this process myself. However biospark was a large help in testing and
gave advice and potential solutions for problems I encountered. The dude is awesome.