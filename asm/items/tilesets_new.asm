TilesetEntries:
	.import "data\tileset_entries.bin"			; adds 14 blank tilesets (0x744
AnimTilesetEntries:
	.import "data\anim_tileset_entries.bin"		; adds 14 blank animated tilesets
AnimGfxEntries:
	.import "data\anim_gfx_entries.bin"			; copies existing animated gfx
; new animated gfx
	.byte 4,10,3,0
	.word AnimLongGfx
	.byte 4,10,3,0
	.word AnimChargeGfx
	.byte 4,10,3,0
	.word AnimIceGfx
	.byte 4,10,3,0
	.word AnimWaveGfx
	.byte 4,10,3,0
	.word AnimPlasmaGfx
	.byte 4,10,3,0
	.word AnimBombGfx
	.byte 4,10,3,0
	.word AnimVariaGfx
	.byte 4,10,3,0
	.word AnimGravityGfx
	.byte 4,10,3,0
	.word AnimMorphGfx
	.byte 4,10,3,0
	.word AnimSpeedGfx
	.byte 4,10,3,0
	.word AnimHiGfx
	.byte 4,10,3,0
	.word AnimScrewGfx
	.byte 4,10,3,0
	.word AnimSpaceGfx
	.byte 4,10,3,0
	.word AnimGripGfx
	
AnimLongGfx:
	.import "anim_gfx\anim_long.gfx"
AnimChargeGfx:
	.import "anim_gfx\anim_charge.gfx"
AnimIceGfx:
	.import "anim_gfx\anim_ice.gfx"
AnimWaveGfx:
	.import "anim_gfx\anim_wave.gfx"
AnimPlasmaGfx:
	.import "anim_gfx\anim_plasma.gfx"
AnimBombGfx:
	.import "anim_gfx\anim_bomb.gfx"
AnimVariaGfx:
	.import "anim_gfx\anim_varia.gfx"
AnimGravityGfx:
	.import "anim_gfx\anim_gravity.gfx"
AnimMorphGfx:
	.import "anim_gfx\anim_morph.gfx"
AnimSpeedGfx:
	.import "anim_gfx\anim_speed.gfx"
AnimHiGfx:
	.import "anim_gfx\anim_hi.gfx"
AnimScrewGfx:
	.import "anim_gfx\anim_screw.gfx"
AnimSpaceGfx:
	.import "anim_gfx\anim_space.gfx"
AnimGripGfx:
	.import "anim_gfx\anim_grip.gfx"
