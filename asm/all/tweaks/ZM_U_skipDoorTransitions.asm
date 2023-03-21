.gba
.open "ZM_U.gba","ZM_U_skipDoorTransitions.gba",0x8000000

; pretend SkipDoorTransition flag is always set
.org 0x805EF8A
    b       0x805EF94

.close
