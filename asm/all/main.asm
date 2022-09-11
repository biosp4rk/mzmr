.gba
.open "ZM_U.gba","ZM_U_all.gba",0x8000000

; new code
.org 0x
.include "title_graphics_new.asm"

; modifications

.include "title_graphics.asm"

.include "hash_icons.asm"

.close
