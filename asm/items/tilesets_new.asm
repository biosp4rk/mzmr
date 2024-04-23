TilesetEntries:
    .import "data\tileset_entries.bin"          ; adds 14 blank tilesets (0x744)
AnimTilesetEntries:
    .import "data\anim_tileset_entries.bin"     ; adds 14 blank animated tilesets
AnimGfxEntries:
    .import "data\anim_gfx_entries.bin"         ; copies existing animated gfx
; new animated gfx
    .db 4,10,3,0
    .dw AnimLongGfx
    .db 4,10,3,0
    .dw AnimChargeGfx
    .db 4,10,3,0
    .dw AnimIceGfx
    .db 4,10,3,0
    .dw AnimWaveGfx
    .db 4,10,3,0
    .dw AnimPlasmaGfx
    .db 4,10,3,0
    .dw AnimBombGfx
    .db 4,10,3,0
    .dw AnimVariaGfx
    .db 4,10,3,0
    .dw AnimGravityGfx
    .db 4,10,3,0
    .dw AnimMorphGfx
    .db 4,10,3,0
    .dw AnimSpeedGfx
    .db 4,10,3,0
    .dw AnimHiGfx
    .db 4,10,3,0
    .dw AnimScrewGfx
    .db 4,10,3,0
    .dw AnimSpaceGfx
    .db 4,10,3,0
    .dw AnimGripGfx

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
