.gba
.open "ZM_U.gba","ZM_U_disableWallJump.gba",0x8000000

; skip over code that checks wall jump conditions
.org 0x8008F92
    b       0x8008FE6

; to include code that sets X acceleration to 1, use this instead
;.org 0x8008FA6
;    b       0x8008FE4

.close
