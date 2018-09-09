.gba
.open "ZM_U.gba","ZM_U_blackPiratePlasma.gba",0x8000000
	
; skip check for plasma beam
.org 0x802CC16
	b       0x802CC36

.close
