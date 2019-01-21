; r0 = BehaviorType - 10
IsBreakableOrTank:
    cmp     r0,0x2F
    bls     @@ReturnTrue
    sub     r0,0x50
    cmp     r0,0x1D
    bls     @@ReturnTrue
    mov     r0,0
    b       @@Return
@@ReturnTrue:
    mov     r0,1
@@Return:
    bx      r14
    .align


; r0 = BehaviorType - 10
; r1 = 83459F0
IsHiddenTank:
    cmp     r0,0x50
    bcs     @@HiddenAbility
    lsl     r0,r0,2
    add     r0,r0,r1
    ldrb    r1,[r0]
    b       @@Return
@@HiddenAbility:
    mov     r1,4
@@Return:
    bx      r14


; r0 = ability number   
CheckSpawnAbility:
    push    r14
    ldr     r1,=@@EventTable
    add     r1,r1,r0
    ldrb    r1,[r1]         ; event number
    mov     r0,3
    bl      EventFunctions  ; check if event set
    pop     r1
    bx      r1
    .pool
@@EventTable:
    .db LongEvent
    .db ChargeEvent
    .db IceEvent
    .db WaveEvent
    .db PlasmaEvent
    .db BombEvent
    .db VariaEvent
    .db GravityEvent
    .db MorphEvent
    .db SpeedEvent
    .db HiEvent
    .db ScrewEvent
    .db SpaceEvent
    .db GripEvent
    .align


; give item, display message
.include "assign_item.asm"


RemoveCollectedAbility:
    push    r4,r14
    ldr     r4,=GettingTankFlag
    ldrb    r0,[r4]
    cmp     r0,0
    bne     @@Return        ; return if getting a tank
; get proper item type for SetItemAsCollected
    ldr     r4,=@@ItemTypes
    add     r2,r4,r1
    ldrb    r2,[r2]
; original code
    ldr     r4,=SamusData
    ldrh    r0,[r4,0x12]
    lsr     r0,r0,6
    ldrh    r1,[r4,0x14]
    lsr     r1,r1,6
    bl      SetItemAsCollected
    ldrh    r0,[r4,0x12]
    lsr     r0,r0,6
    ldrh    r1,[r4,0x14]
    lsr     r1,r1,6
    bl      GetItemUpdateMinimap
@@Return:
    pop     r4
    pop     r0
    bx      r0
@@ItemTypes:
    .db 0,2,1,1,3,3,4,4
    .db 0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80,0x80
    .pool
