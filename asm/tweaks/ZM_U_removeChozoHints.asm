.gba
.open "ZM_U.gba","ZM_U_removeChozoHints.gba",0x8000000

; set statue to sitting position
.org 0x8013E00		; long beam
	.word 0x8014004
.org 0x8013E08		; ice beam
	.word 0x8014004
.org 0x8013E10		; wave beam
	.word 0x8014004
.org 0x8013E18		; bombs
	.word 0x8014004
.org 0x8013E20		; speed
	.word 0x8014004
.org 0x8013E28		; hi-jump
	.word 0x8014004
.org 0x8013E30		; screw
	.word 0x8014004
.org 0x8013E38		; varia
	.word 0x8014004
	
; fix room with first chozo statue
.org 0x8340B4D
	.byte 0
.org 0x8340B54
	.word 0x8364F4C

.close
