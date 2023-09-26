.gba
.open "ZM_U.gba","ZM_U_disableMidAirBombJump.gba",0x8000000

; change jump table so MorphBallMidAir pose jumps to return
.org 0x80069D0
    .dw 0x8006C26
	
.close
