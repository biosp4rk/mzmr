; fix fake tanks
.include "fake_tanks.asm"

; write lengths of all tile tables
.include "tile_table_lengths.asm"
	
; allow getting power bombs before bombs
.include "pbs_before_bombs.asm"

; imago door unlock
.org 0x8043178
	b       0x804318C		; skip code that checks for super missile
	
; fix escape timer
.org 0x8053980
	beq     0x8053986		; check both events
	
; allow power bomb tube to be broken any time
.org 0x8046476
	b       0x8046482
	
; fix discolored super missile (near varia)
.org 0x8606DEA
	.halfword 0x4D,0x4E,0x4F,0x50
	
; add blank row to tileset palette 47
.org 0x872CF3A
	.halfword 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	
; fix power bomb space pirate OAM
.org 0x82E404A
	.halfword 0x51E1
.org 0x82E40A6
	.halfword 0x51E1
.org 0x82E4102
	.halfword 0x51E1
.org 0x82E415E
	.halfword 0x51E1
.org 0x82E41BA
	.halfword 0x51E1
.org 0x82E4216
	.halfword 0x51E1
.org 0x82E4272
	.halfword 0x51E1
.org 0x82E42CE
	.halfword 0x51E1
