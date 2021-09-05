.gba
.open "ZM_U.gba","ZM_U_randomItems.gba",0x8000000

; RAM addresses
.definelabel Difficulty,0x300002C
.definelabel GettingTankFlag,0x3000044
.definelabel MessageInfo,0x3000C0C
.definelabel SamusData,0x30013D4
.definelabel Equipment,0x3001530

; ROM addresses
.definelabel PlaySound,0x8002A18
.definelabel _16BitFill,0x80032B4
.definelabel SpawnNewPrimarySprite,0x800E31C
.definelabel LoadBeamGfx,0x804F670
.definelabel SetBG1BlockValue,0x805A55C
.definelabel SetClipdataBlockValue,0x805A64C
.definelabel SetItemAsCollected,0x805B0A0
.definelabel EventFunctions,0x80608BC
.definelabel GetItemUpdateMinimap,0x806CBD8

.definelabel NumTanksPerArea,0x83459A0
.definelabel TankStartingAmounts,0x83459C0
.definelabel TankIncreaseAmounts,0x83459C4

; Item events
.definelabel LongEvent,     0x4F  ; new
.definelabel ChargeEvent,   0x14
.definelabel IceEvent,      0x50  ; new
.definelabel WaveEvent,     0x51  ; new
.definelabel PlasmaEvent,   0x18
.definelabel BombEvent,     0x52  ; new
.definelabel VariaEvent,    0x13
.definelabel GravityEvent,  0x17
.definelabel MorphEvent,    0x53  ; new
.definelabel SpeedEvent,    0x54  ; new
.definelabel HiEvent,       0x12
.definelabel ScrewEvent,    0x15
.definelabel SpaceEvent,    0x16
.definelabel GripEvent,     0x10


;----------
; New Data
;----------
.org 0x8760D38

; new (animated) tileset entries
.include "tilesets_new.asm"

; new tables for clipdata behavior/collision
.include "clipdata_new.asm"

; fix pointers for tilesets and clipdata
.include "pointer_fixes.asm"

; area, room, door, and music after zebes escape
; 0x8760???
.db 6,0,0,0x10
;.db 6,0x28,0x56,3

;----------
; New Code
;----------
.org 0x8304054      ; Crocomire graphics

; check item clipdata, spawn/assign items
.include "items_new.asm"

; unknown items
.include "unk_items\unk_items_new.asm"

; ?
SetEscapedZebesEvent:
    push    r14
    mov     r0,1
    mov     r1,0x43     ; full suit obtained
    bl      EventFunctions
    mov     r0,1
    mov     r1,0x41     ; escaped zebes
    bl      EventFunctions
    pop     r0
    bx      r0

; ?
SetSuitlessStartingRoom:
    ldr     r2,=SuitlessStart
    ldr     r1,=AreaID
    ldrb    r0,[r2]
    strb    r0,[r1]
    ldr     r1,=RoomID
    ldrb    r0,[r2,1]
    strb    r0,[r1]
    ldr     r1,=DoorID
    ldrb    r0,[r2,2]
    strb    r0,[r1]
    bx      r14
    .pool

;---------------
; Modifications
;---------------

; modified portion of CheckTouchingTransitionOrTank
.include "touching_tank.asm"

; unknown items
.include "unk_items\unk_items.asm"

; obtaining and checking abilities
.include "abilities.asm"

; miscellaneous tweaks/fixes
.include "misc.asm"

; room fixes
.include "room_fixes.asm"

.close
