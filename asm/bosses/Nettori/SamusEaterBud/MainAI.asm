SamusEaterBudUpdateHitbox:    ;44a24
    push    r14
    ldr     r2, =CurrSpriteData
    ldrh    r1, [r2]
    mov     r0, 0x40
    and     r0, r1
    cmp     r0, 0
    beq     @@f44a44
    ldr     r0, =0xFFF0
    strh    r0, [r2, 0xE]
    mov     r0, 0x38
@@f44a44:
    ldr     r0, =0xFFC8
    strh    r0, [r2, 0xE]
    mov     r0, 0x10
    strh    r0, [r2, 0x10]
    pop     r0
    bx      r0
.pool

SamusEaterBudInit:      ;44A54
    push    r4-r7, r14
    ldr     r7, =CurrSpriteData

    mov     r3, 0x0
    ldr     r4, =SpriteData
@@StartLoop:
    lsl     r0, r3, 0x3
    sub     r0, r0, r3
    lsl     r0, r0, 0x3
    add     r2, r0, r4
    ldrh    r1, [r2]
    mov     r0, 0x1
    and     r0, r1
    cmp     r0, 0x0
    beq     @@Next
    mov     r0, r2
    add     r0, 0x32    ;prop
    ldrb    r1, [r0]
    mov     r0, 0x80
    and     r0, r1
    cmp     r0, 0x0
    bne     @@Next
    ldrb    r0, [r2, 0x1D]  ;id
    cmp     r0, NettoriSpriteID
    bne     @@Next
    mov     r1, r7
    add     r1, 0x32
    ldrb    r0, [r1]
    mov     r2, 0x40
    orr     r2, r0
    strb    r2, [r1]
    b       @@LoopOver
    .pool
@@Next:
    add     r0, r3, 1
    lsl     r0, r0, 0x18
    lsr     r3, r0, 0x18
    cmp     r3, 0x17
    bls     @@StartLoop
@@LoopOver:

    ldrh    r0, [r7, 0x2] ;y
    sub     r0, 0x40
    mov     r5, 0x0
    mov     r6, 0x0
    strh    r0, [r7, 0x2]
    ldrh    r0, [r7, 0x4]
    add     r0, 0x20
    strh    r0, [r7, 0x4]
    ldr     r3, =SpriteUtilMakeSpriteFaceSamusXFlip+1
    bl      WRapperR3
    ldr     r2, =PrimarySpriteStats
    ldrb    r1, [r7, 0x1D]    ;ID
    lsl     r0, r1, 0x3
    add     r0, r0, r1
    lsl     r0, r0, 0x1
    add     r0, r0, r2
    ldrh    r0, [r0]
    strh    r0, [r7, 0x14]    ;health
    mov     r0, r7
    add     r0, 0x25  ;samus collision
    mov     r4, 0x4
    strb    r4, [r0]
    add     r0, 0x2
    mov     r1, 0x10
    strb    r1, [r0]
    add     r0, 0x1
    strb    r1, [r0]
    mov     r1, r7
    add     r1, 0x29
    mov     r0, 0x18
    strb    r0, [r1]
    ldr     r0, =0xFFE0
    strh    r0, [r7, 0xA]
    mov     r0, 0x28
    strh    r0, [r7, 0xC]
    bl      SamusEaterBudUpdateHitbox
    mov     r0, r7
    add     r0, 0x24  ;pose
    mov     r4, 2
    strb    r4, [r0]
    ldr     r0, =SamusEaterBudOAM0
    str     r0, [r7, 0x18]
    strb    r5, [r7, 0x1C]
    strh    r6, [r7, 0x16]
    mov     r1, r7
    add     r1, 0x33  ;Frozen palette row offset
    mov     r0, 0x1
    strb    r0, [r1]
    ldr     r3, =SpriteUtilMakeSpriteFaceSamusXFlip+1
    bl      WRapperR3
    pop     r4-r7
    pop     r0
    bx      r0
    .pool

SamusEaterBudIdleInit:    ;44AD4
    push    r14
    ldr     r1, =CurrSpriteData
    mov     r2, r1
    add     r2, 0x24  ;pose
    mov     r3, 0x0
    mov     r0, 0x2
    strb    r0, [r2]
    ldr     r0, =SamusEaterBudOAM0
    str     r0, [r1, 0x18]
    strb    r3, [r1, 0x1C]
    strh    r3, [r1, 0x16]
    bl      SamusEaterBudUpdateHitbox
    pop     r0
    bx      r0
    .pool

SamusEaterBudIdle:    ;44AFC
    push    r4, r14
    ldr     r3, =CurrSpriteData
    mov     r4, 0x0
    ldrh    r1, [r3, 2]
    add     r1, 0x40
    ldr     r2, =SamusData
    ldrh    r0, [r2, 0x14]
    cmp     r1, r0
    bhi     @@f44B52
    mov     r0, 0xA0
    lsl     r0, r0, 0x2
    mov     r1, 0x80
    lsl     r1, r1, 0x2
    ldr     r3, =CheckNearSprite+1
    bl      WRapperR3
    mov     r2, r0
    ldr     r3, =CurrSpriteData
    ldrh    r1, [r3]
    mov     r0, 0x40
    and     r0, r1
    cmp     r0, 0x0
    beq     @@f44B34
    cmp     r2, 0x0
    beq     @@f44B52
    ldr     r1, =SamusData
    ldrh    r0, [r3, 0x4]
    ldrh    r1, [r1, 0x12]    ;X position
    cmp     r0, r1
    bls     @@f44B56
    b       @@f44B42
.pool
@@f44B34:
    cmp     r2, 0x0
    beq     @@f44B52
    ldr     r1, =SamusData
    ldrh    r0, [r3, 0x4]
    ldrh    r1, [r1, 0x12]    ;X position
    cmp     r0, r1
    bcs     @@f44B50
@@f44B42:
    mov     r1, r3
    add     r1, 0x24  ;pose
    mov     r0, 0x3
    strb    r0, [r1]
    b       @@f44B52
.pool
@@f44B50:
    mov     r4, 0x1
@@f44B52:
    cmp     r4, 0x0
    beq     @@Return
@@f44B56:
    ldr     r4, =CurrSpriteData
    mov     r0, r4
    add     r0, 0x23    ;Primary sprite RAM slot
    ldrb    r1, [r0]
    mov     r0, SamusEaterProjectileSpriteID
    ldr     r3, =SpriteUtilCountSecondarySpritesWithCurrentSpriteRAMSlot+1
    bl      WRapperR3
    cmp     r0, 0x1
    bgt     @@Return
    mov     r1, r4
    add     r1, 0x24  ;pose
    mov     r2, 0x0
    mov     r0, 0x2A
    strb    r0, [r1]
    ldr     r0, =SamusEaterBudOAM1
    str     r0, [r4, 0x18]
    strb    r2, [r4, 0x1C]
    strh    r2, [r4, 0x16]
    ldr     r0, =0x296
    ldr     r3, =SoundPlayNotAlreadyPlaying+1
    ;bl      WRapperR3
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool

SamusEaterBudTurningInit:      ;44B94 
    ldr     r1, =CurrSpriteData
    ldr     r0, =SamusEaterBudOAM2
    str     r0, [r1, 0x18]
    mov     r0, 0x0
    strb    r0, [r1, 0x1C]
    strh    r0, [r1, 0x16]
    mov     r2, r1
    add     r2, 0x24  ;pose
    mov     r0, 0x4
    strb    r0, [r2]
    ldr     r0, =0xFFEC
    strh    r0, [r1, 0xE]
    mov     r0, 0x14
    strh    r0, [r1, 0x10]
    bx      r14
.pool

SamusEaterBudTurning:   ;44BC0
    push    r14
    ldr     r0, =SpriteUtilCheckEndCurrentSpriteAnim+1
    bl      WRapperR0
    cmp     r0, 0x0
    beq     @@Return
    ldr     r2, =CurrSpriteData
    ldrh    r0, [r2]
    mov     r1, 0x40
    eor     r0, r1
    strh    r0, [r2]
    add     r2, 0x24  ;pose
    mov     r0, 0x5
    strb    r0, [r2]
@@Return:
    pop     r0
    bx      r0
.pool

SamusEaterBudTurningOver:   ;44BE4
    push    r14
    ldr     r0, =CheckNearEndAnimation+1
    bl      WRapperR0
    cmp     r0, 0x0
    beq     @@Return
    ldr     r0, =CurrSpriteData
    add     r0, 0x24
    mov     r1, 0x1
    strb    r1, [r0]
@@Return:
    pop     r0
    bx      r0
.pool

SamusEaterBudShooting:   ;44C00
    push    r4-r5, r14
    add     sp, -0xC
    ldr     r0, =CurrSpriteData
    ldr     r5, =SpawnNewSecondarySprite+1
    mov     r12, r0
    ldrh    r0, [r0, 0x16]
    cmp     r0, 0x3
    bne     @@f44C6C
    mov     r1, r12
    ldrb    r0, [r1, 0x1C]
    cmp     r0, 0x4
    bne     @@f44C6C
    ldrh    r1, [r1]
    mov     r4, 0x40
    mov     r0, r4
    and     r0, r1
    lsl     r0, r0, 0x10
    lsr     r1, r0, 0x10
    cmp     r1, 0x0
    beq     @@f44C4C
    mov     r0, r12
    ldrb    r2, [r0, 0x1F]    ;Spriteset graphics slot
    add     r0, 0x23  ;Primary sprite RAM slot
    ldrb    r3, [r0]
    mov     r1, r12
    ldrh    r0, [r1, 0x2] ;y
    add     r0, 0x20  ;pal row
    str     r0, [sp]
    ldrh    r0, [r1, 0x4]
    add     r0, 0x2C
    str     r0, [sp, 0x4]
    str     r4, [sp, 0x8]
    mov     r0, SamusEaterProjectileSpriteID
    mov     r1, 0x0
    bl      WRapperR5
    b       @@f44C6C
@@f44C4C:
    mov     r4, r12
    ldrb    r2, [r4, 0x1F]
    mov     r0, r12
    add     r0, 0x23
    ldrb    r3, [r0]
    ldrh    r0, [r4, 0x2]
    add     r0, 0x20
    str     r0, [sp]
    ldrh    r0, [r4, 0x4]
    sub     r0, 0x2C
    str     r0, [sp, 0x4]
    str     r1, [sp, 0x8]
    mov     r0, SamusEaterProjectileSpriteID
    mov     r1, 0x0
    bl      WRapperR5
@@f44C6C:
    ldr     r0, =CheckNearEndAnimation+1
    bl      WRapperR0
    cmp     r0, 0x0
    beq     @@Return
    ldr     r0, =CurrSpriteData
    add     r0, 0x24  ;pose
    mov     r1, 0x1
    strb    r1, [r0]
@@Return:
    add     sp, 0xC
    pop     r4-r5
    pop     r0
    bx      r0
.pool

SamusEaterBudDying:     ;44C88
    ldr     r3, =CurrSpriteData
    mov     r1, r3
    add     r1, 0x24  ;pose
    mov     r2, 0x0
    mov     r0, 0x62
    strb    r0, [r1]
    mov     r0, r3
    add     r0, 0x25  ;samus collision
    strb    r2, [r0]
    add     r1, 0x8   ;Timer 1
    mov     r0, 0x8
    strb    r0, [r1]
    ldrh    r1, [r3]
    mov     r2, 0x80
    lsl     r2, r2, 0x8
    mov     r0, r2
    orr     r0, r1
    strh    r0, [r3]
    bx      r14
.pool

SamusEaterBudDeath:     ;44CB4
    push    r4, r14
    add     sp, -4
    ldr     r2, =CurrSpriteData
    mov     r1, r2
    add     r1, 0x26  ;Ignore Samus collision timer
    mov     r0, 0x1
    strb    r0, [r1]
    mov     r3, r2
    add     r3, 0x2C  ;Timer 1
    ldrb    r1, [r3]
    and     r0, r1
    cmp     r0, 0x0
    bne     @@f44CD4
    ldrh    r0, [r2]  ;status
    mov     r1, 0x4
    eor     r0, r1
    strh    r0, [r2]
@@f44CD4:
    ldrb    r0, [r3]
    sub     r0, 0x1
    strb    r0, [r3]
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    cmp     r0, 0x0
    bne     @@Return
    mov     r0, 0x1F
    str     r0, [sp]
    mov     r0, 0
    ldrh    r1, [r2, 0x2]
    ldrh    r2, [r2, 0x4]
    mov     r3, 1
    ldr     r4, =DeathRoutine+1
    bl      WRapperR4
@@Return:
    add     sp, 4
    pop     r4
    pop     r0
    bx      r0
.pool

SamusEaterBudMainAI:     ;45150
    push    r14
    ldr     r1, =CurrSpriteData
    mov     r3, r1
    add     r3, 0x30  ;Freeze Timer
    ldrb    r0, [r3]
    mov     r2, r1
    cmp     r0, 0
    beq     @@f4517E
    mov     r0, r2
    add     r0, 0x24  ;pose
    ldrb    r0, [r0]
    cmp     r0, 0x45
    beq     @@f45174
    ldr     r0, =SpriteUtilUpdateFreezeTimer+1
    bl      WRapperR0
    b       @@Return
    .pool
@@f45174:
    mov     r1, r2
    add     r1, 0x20  ;pal row
    mov     r0, 0x0
    strb    r0, [r1]
    strb    r0, [r3]
@@f4517E:
    mov     r0, r2
    add     r0, 0x24  ;pose
    ldrb    r0, [r0]
    cmp     r0, 0x2A
    bls     @@f4518A
    b       @@CheckDeath
@@f4518A:
    lsl     r0, r0, 0x2
    ldr     r1, =@@pose
    add     r0, r0, r1
    ldr     r0, [r0]
    mov     r15, r0
.pool
@@pose:
    .dw @@pose0, @@pose1, @@pose2, @@pose3
    .dw @@pose4, @@pose5, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@Return, @@Return
    .dw @@Return, @@Return, @@pose2A
@@pose0:
    bl      SamusEaterBudInit
    b       @@Return
@@pose1:
    bl      SamusEaterBudIdleInit
@@pose2:
    bl      SamusEaterBudIdle
    b       @@Return
@@pose3:
    bl      SamusEaterBudTurningInit
@@pose4:
    bl      SamusEaterBudTurning
    b       @@Return
@@pose5:
    bl      SamusEaterBudTurningOver
    b       @@Return
@@pose2A:
    bl      SamusEaterBudShooting
    b       @@Return
@@CheckDeath:
    cmp     r0, 0x45
    bne     @@Death
    bl      SamusEaterBudDying
    b       @@Return
@@Death:
    bl      SamusEaterBudDeath
@@Return:
    pop     r0
    bx      r0
.pool