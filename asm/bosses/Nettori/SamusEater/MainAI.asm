SamusEaterCheckBossHalfHealth:    ;43b6c
    push    {r4, r5, r14}
    mov     r3, 0x0
    ldr     r4, =SpriteData
@@f43B74:
    lsl     r0, r3, 0x3
    sub     r0, r0, r3
    lsl     r0, r0, 0x3
    add     r2, r0, r4
    ldrh    r1, [r2]
    mov     r0, 0x1
    and     r0, r1
    cmp     r0, 0x0
    beq     @@f43BB0
    mov     r0, r2
    add     r0, 0x32    ;prop
    ldrb    r1, [r0]
    mov     r0, 0x80
    and     r0, r1
    cmp     r0, 0x0
    bne     @@f43BB0
    ldrb    r0, [r2, 0x1D]  ;id
    cmp     r0, NettoriSpriteID
    bne     @@f43BB0
    ldr     r0, =NettoriHealth
    ldrh    r1, [r2, 0x14]  ;health
    lsr     r0, r0, 1
    cmp     r1, r0
    bcs     @@f43BBA
    mov     r0, 1
    b       @@Return
    .pool
@@f43BB0:
    add     r0, r3, 1
    lsl     r0, r0, 0x18
    lsr     r3, r0, 0x18
    cmp     r3, 0x17
    bls     @@f43B74
@@f43BBA:
    mov     r0, 0
@@Return:
    pop     {r4, r5}
    pop     {r1}
    bx      r1

SamusEaterInit: ;447e0
    push    r4-r5, r14
    ldr     r5, =CurrSpriteData

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
    mov     r1, r5
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
    ldr     r2, =PrimarySpriteStats
    ldrb    r1, [r5, 0x1D]
    lsl     r0, r1, 3
    add     r0, r1
    lsl     r0, r0, 1
    add     r0, r2
    ldrh    r0, [r0]
    mov     r2, 0
    strh    r0, [r5, 0x14]  ;health
    mov     r1, r5
    add     r1, 0x25
    mov     r0, 9   ;was B
    strb    r0, [r1]
    mov     r0, r5
    add     r0, 0x27    ;Draw distance top offset
    mov     r1, 0x20
    strb    r1, [r0]
    add     r0, 0x1     ;Draw distance bottom offset
    strb    r2, [r0]
    add     r0, 0x1     ;Draw distance horizontal offset
    strb    r1, [r0]
    ldr     r1, =0xFFA0
    strh    r1, [r5, 0xA]   ;Hitbox top offset
    mov     r0, 0x10
    strh    r0, [r5, 0xC]
    strh    r1, [r5, 0xE]
    mov     r0, 0x60
    strh    r0, [r5, 0x10]
    mov     r1, r5
    add     r1, 0x24    ;pose
    mov     r0, 2
    strb    r0, [r1]
    ldr     r0, =SamusEaterOAM0
    str     r0, [r5, 0x18]  ;oam
    strb    r2, [r5, 0x1C]  ;Animation duration counter
    ldr     r4, =SpriteRNG
    ldrb    r2, [r4]
    mov     r1, 3
    mov     r0, r1
    and     r0, r2
    strh    r0, [r5, 0x16]  ;Current animation frame
    ldr     r0, =BackupOfIORegisters
    ldrb    r0, [r0, 0xA]
    and     r1, r0
    mov     r0, r5
    add     r0, 0x21    ;Background priority
	mov		r1,1
    strb    r1, [r0]
    mov     r1, r5
    add     r1, 0x33    ;Frozen palette row offset
    mov     r0, 1
    strb    r0, [r1]
    ldr     r0, =SpriteUtilChooseRandomXFlip+1
    bl      WRapperR0
    ldrb    r0, [r4]
    lsl     r0, r0, 2
    add     r0, 0x5A
    mov     r1, r5
    add     r1, 0x2C    ;Timer1
    strb    r0, [r1]
    pop     r4, r5
    pop     r0
    bx      r0
.pool

Pose1:  ;f44878
    ldr     r1, =CurrSpriteData
    mov     r2, r1
    add     r2, 0x24    ;pose
    mov     r3, 0
    mov     r0, 2
    strb    r0, [r2]
    ldr     r0, =SamusEaterOAM0
    str     r0, [r1, 0x18]  ;OAM
    strb    r3, [r1, 0x1C]  ;Animation duration counter
    strh    r3, [r1, 0x16]  ;Current animation frame
    bx      r14
    .pool

pose2:  ;44898
    push    r4-r7, r14
    add     sp, -0xC
    ldr     r4, =CurrSpriteData
    ldrh    r1, [r4]    ;status
    mov     r0, 0x80
    lsl     r0, r0, 4
    and     r0, r1
    cmp     r0, 0
    beq     @@f448C8
    mov     r1, r4
    add     r1, 0x24    ;pose
    mov     r2, 0
    mov     r0, 0x2A
    strb    r0, [r1]
    ldr     r0, =SamusEaterOAM2
    str     r0, [r4, 0x18]
    strb    r2, [r4, 0x1C]
    strh    r2, [r4, 0x16]
    b       @@Return
    .pool
@@f448C8:
    ldrb    r0, [r4, 0x1D]
    cmp     r0, SamusEaterAlwaysSpawnSporeSpriteID
    beq     @@SpawnSpore
    bl      SamusEaterCheckBossHalfHealth
    lsl     r0, r0, 0x18
    cmp     r0, 0
    beq     @@Return
@@SpawnSpore:
    mov     r1, r4
    add     r1, 0x2C    ;Timer 1
    ldrb    r0, [r1]
    sub     r0, 1
    strb    r0, [r1]
    lsl     r0, r0, 0x18
    lsr     r5, r0, 0x18
    cmp     r5, 0
    bne     @@Return
    ldr     r0, =SpriteRNG
    ldrb    r0, [r0]
    lsl     r0, r0, 2
    add     r0, 0x5A
    strb    r0, [r1]
    ldrb    r2, [r4, 0x1F]  ;Spriteset graphics slot
    mov     r6, r4
    add     r6, 0x23        ;Primary sprite RAM slot
    ldrb    r3, [r6]
    ldrh    r0, [r4, 2]     ;y
    sub     r0, 0x60
    str     r0, [sp]
    ldrh    r0, [r4, 4]
    str     r0, [sp, 4]
    mov     r0, 0x40
    str     r0, [sp, 8]
    mov     r0, SamusEaterProjectileSpriteID
    mov     r1, 0x1
    ldr     r7, =SpawnNewSecondarySprite+1
    bl      WRapperR7
    ldrb    r2, [r4, 0x1F]
    ldrb    r3, [r6]
    ldrh    r0, [r4, 2]
    sub     r0, 0x60
    str     r0, [sp]
    ldrh    r0, [r4, 4]
    str     r0, [sp, 4]
    str     r5, [sp, 8]
    mov     r0, SamusEaterProjectileSpriteID
    mov     r1, 0x1
    ldr     r7, =SpawnNewSecondarySprite+1
    bl      WRapperR7
    ldr     r0, =0x1A0
    ldr     r3, =SoundPlayNotAlreadyPlaying+1
    ;bl      WRapperR3
@@Return:
    add     sp, 0xC
    pop     {r4-r7}
    pop     {r0}
    bx      r0
    .pool

pose2A:     ;44938
    push    r14
    ldr     r1, =CurrSpriteData
    ldrh    r0, [r1, 0x16]  ;Current animation frame
    cmp     r0, 0
    bne     @@f4494E
    ldrb    r0, [r1, 0x1C]  ;Animation duration counter
    cmp     r0, 0x2
    bne     @@f4494E
    ldr     r0, =0x16D
    ldr     r3, =PlaySound1+1
    bl      WRapperR3
@@f4494E:
    ldr     r0, =CurrSpriteData
    ldrh    r2, [r0, 4]   ;x
    sub     r0, r2, 4
    ldr     r3, =SamusData
    ldrh    r1, [r3, 0x12]  ;X position
    cmp     r0, r1
    ble     @@f4496C
    add     r0, r1, 4
    b       @@f44974
    .pool
@@f4496C:
    add     r0, r2, 4
    cmp     r0, r1
    bge     @@f44976
    sub     r0, r1, 4
@@f44974:
    strh    r0, [r3, 0x12]
@@f44976:
    mov     r0, 0xA0
    mov     r1, 0x80
    ldr     r3, =CheckNearSprite+1
    bl      WRapperR3
    mov     r2, r0
    ldr     r3, =CurrSpriteData
    ldrh    r1, [r3]
    mov     r0, 0x80
    lsl     r0, r0, 4
    and     r0, r1
    cmp     r0, 0
    bne     @@Return
    cmp     r2, 0
    bne     @@Return
    mov     r0, r3
    add     r0, 0x24
    mov     r1, 0x1
    strb    r1, [r0]
    ldr     r0, =0x16D
    ldr     r3, =StopSound+1
    bl      WRapperR3
@@Return:
    pop     r0
    bx      r0
    .pool

SamusEaterDeathInit:   ;449AC
    ldr     r3, =CurrSpriteData
    mov     r1, r3
    add     r1, 0x24    ;pose
    mov     r2, 0
    mov     r0, 0x46
    strb    r0, [r1]
    mov     r0, r3
    add     r0, 0x25    ;samus collision
    strb    r2, [r0]
    add     r1, 8       ;Timer 1
    mov     r2, r3
    add     r2, 0x32
    ldrb    r2, [r2]
    mov     r0, 0x40
    and     r2, r0
    cmp     r2, 0
    beq     @@Normal
    mov     r0, 0x40
    b       @@SetTimer
@@Normal:
    mov     r0, 1
@@SetTimer:
    strb    r0, [r1]
    ldrh    r1, [r3]    ;status
    mov     r2, 0x60
    lsl     r2, r2, 8
    mov     r0, r2
    orr     r0, r1
    strh    r0, [r3]
    bx      r14
    .pool

SamusEaterDeath:     ;449d8
    push    r4, r14
    add     sp, -4
    ldr     r2, =CurrSpriteData
    mov     r1, r2
    add     r1, 0x26    ;Ignore Samus collision timer
    mov     r0, 1
    strb    r0, [r1]
    mov     r3, r2
    add     r3, 0x2C    ;Timer 1
    ldrb    r1, [r3]
    and     r0, r1
    cmp     r0, 0x0
    bne     @@f449F8
    ldrh    r0, [r2]    ;status
    mov     r1, 4
    eor     r0, r1
    strh    r0, [r2]
@@f449F8:
    ldrb    r0, [r3]
    sub     r0, 1
    strb    r0, [r3]
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    cmp     r0, 0
    bne     @@Return
    
    strh    r0, [r2]
    ldrh    r1, [r2, 2]   ;y
    sub     r1, 0x40
    ldrh    r2, [r2, 4]   ;x
    mov     r3, 0x21    ;was 2d
    str     r3, [sp]
    mov     r3, 1
    ldr     r4, =DeathRoutine+1
    bl      WRapperR4
@@Return:
    add     sp, 4
    pop     r4
    pop     r0
    bx      r0
    .pool

SamusEaterMainAI:
    push    r4, r14
    ldr     r4, =CurrSpriteData
    mov     r2, r4
    add     r2, 0x30    ;freeze timer
    ldrb    r0, [r2]
    cmp     r0, 0
    beq     @@f450EC
    mov     r0, r4
    add     r0, 0x24    ;pose
    ldrb    r0, [r0]
    cmp     r0, 0x45
    beq     @@f450E4
    ldr     r0, =SpriteUtilUpdateFreezeTimer+1
    bl      WRapperR0
    b       @@Return
    .pool
@@f450E4:
    mov     r1, r4
    add     r1, 0x20    ;Palette row
    mov     r0, 0x0
    strb    r0, [r1]
    strb    r0, [r2]
@@f450EC:
    mov     r0, r4
    add     r0, 0x24    ;pose
    ldrb    r0, [r0]
    cmp     r0, 2
    beq     @@f45126
    cmp     r0, 2
    bgt     @@f45108
    cmp     r0, 0
    beq     @@f4511C
    cmp     r0, 1
    beq     @@f45122
    b       @@f4513A
    .pool
@@f45108:
    cmp     r0, 0x45
    beq     @@f45132
    cmp     r0, 0x45
    bgt     @@f44116
    cmp     r0, 0x2A
    beq     @@f4512C
    b       @@f45132
@@f44116:
    cmp     r0, 0x46
    beq     @@f45136
    b       @@f45132
@@f4511C:
    bl      SamusEaterInit
    b       @@f4513A
@@f45122:
    bl      Pose1
@@f45126:
    bl      pose2
    b       @@f4513A
@@f4512C:
    bl      pose2A
    b       @@f4513A
@@f45132:
    bl      SamusEaterDeathInit
@@f45136:
    bl      SamusEaterDeath
@@f4513A:
    mov     r2, r4
    ldrh    r1, [r2]
    ldr     r0, =0xF7FF
    and     r0, r1
    strh    r0, [r2]
@@Return:
    pop     r4
    pop     {r0}
    bx      r0
.pool