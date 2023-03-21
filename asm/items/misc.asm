; fix fake tanks
.include "fake_tanks.asm"

; write lengths of all tile tables
.include "tile_table_lengths.asm"

; allow getting power bombs before bombs
.include "pbs_before_bombs.asm"

; disable title screen demos
.org 0x8077108
    mov     r5,r0
    b       0x807711C

; skip varia suit animation
.org 0x8055FA8
    b       0x8056074

; don't change varia's map tile with full suit
.org 0x806B212
    b       0x806B22E

; modify code that checks for hidden tanks
.org 0x80590BC
    bl      IsBreakableOrTank
    cmp     r0,0
    bne     0x80590C6       ; if not breakable or tank
.org 0x80591F4
    bl      IsHiddenTank
    nop

; fix call to RemoveCollectedAbility
.org 0x806F3D8
    bl      RemoveCollectedAbility
    nop
    nop

; imago door unlock
.org 0x8043178
    b       0x804318C       ; skip code that checks for super missile

; fix escape timer
.org 0x8053980
    beq     0x8053986       ; check both events

; allow power bomb tube to be broken any time
.org 0x8046476
    b       0x8046482       ; skip ???

; allow using more events
.org 0x80608CE
    cmp     r0,0x54

; getting full suit sets zebes escaped event
.org 0x8039748
    bl      SetEscapedZebesEvent
    nop
    nop

; fix discolored super missile in tilemap (near varia)
.org 0x8606DEA
    .dh 0x4D,0x4E,0x4F,0x50

; add blank row to tileset palette 47
.org 0x872CF3A
    .dh 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0

; fix pirate alarm music
; pirate AI
.org 0x8028856
    b       0x802886A       ; skip setting
.org 0x8028812
    b       0x8028822       ; skip removing

; remove vine in norfair
; room 04 (remove from enemy list)
.org 0x866DA19
    .db 0x16,0x42,0x15
    .db 0xFF,0xFF,0xFF
.org 0x866D556
    .db 0x16,0x42,0x15
    .db 0xFF,0xFF,0xFF
.org 0x866D4ED
    .db 0x16,0x42,0x15
    .db 0xFF,0xFF,0xFF

; remove vines near varia
; room 15 (remove from enemy list)
.org 0x8613DB4
    .db 0xFF,0xFF,0xFF
.org,0x861399A
    .db 0xFF,0xFF,0xFF
; room 1C (always use default enemy list)
.org 0x8341189
    .db 0
    .align
    .word 0x833DFD8
    .db 0,0
    .align
    .word 0x833DFD8
    .db 0

; fix power bomb space pirate OAM
.org 0x82E404A
    .dh 0x51E1
.org 0x82E40A6
    .dh 0x51E1
.org 0x82E4102
    .dh 0x51E1
.org 0x82E415E
    .dh 0x51E1
.org 0x82E41BA
    .dh 0x51E1
.org 0x82E4216
    .dh 0x51E1
.org 0x82E4272
    .dh 0x51E1
.org 0x82E42CE
    .dh 0x51E1

; make hitting ruins test with a beam hurt samus
.org 0x8038CB8
    cmp     r0,0xB
    bls     0x8038CC0

; make floating-eye sensors vulnerable
.org 0x804414C
    b       0x8044164
