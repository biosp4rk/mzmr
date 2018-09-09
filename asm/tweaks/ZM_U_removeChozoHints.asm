.gba
.open "ZM_U.gba","ZM_U_removeChozoHints.gba",0x8000000

; set statue to sitting position
.org 0x8013E00
	.word 0x8014004
.org 0x8013E08
	.word 0x8014004
.org 0x8013E10
	.word 0x8014004
.org 0x8013E18
	.word 0x8014004
.org 0x8013E20
	.word 0x8014004
.org 0x8013E28
	.word 0x8014004
.org 0x8013E30
	.word 0x8014004
.org 0x8013E38
	.word 0x8014004
	
; fix room with first chozo statue
.org 0x8340B4D
	.byte 0
.org 0x8340B54
	.word 0x8364F4C

.close
