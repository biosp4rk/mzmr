SamusEaterProjectileInit:   ;44D00
    push    r4, r14
    ldr     r0, =CurrSpriteData
    mov     r12, r0
    ldrh    r1, [r0]    ;status
    ldr     r0, =0xFFFB
    and     r0, r1
    mov     r4, 0
    mov     r1, r12
    strh    r0, [r1]
    mov     r2, r12
    add     r2, 0x32    ;Properties
    ldrb    r1, [r2]
    mov     r0, 0x4
    orr     r0, r1
    strb    r0, [r2]
    mov     r0, r12
    add     r0, 0x27    ;Draw distance top offset
    mov     r1, 0x8
    strb    r1, [r0]
    add     r0, 0x1
    strb    r1, [r0]
    add     r0, 0x1
    strb    r1, [r0]
    ldr     r0, =0xFFF8
    mov     r2, r12
    strh    r0, [r2, 0xA]   ;Hitbox top offset
    strh    r1, [r2, 0xC]
    strh    r0, [r2, 0xE]
    strh    r1, [r2, 0x10]
    ldr     r1, =SecondarySpriteStats
    ldrb    r0, [r2, 0x1D]  ;ID
    lsl     r3, r0, 3
    add     r0, r3
    lsl     r0, r0, 1
    add     r0, r0, r1
    ldrh    r0, [r0]
    strh    r0, [r2, 0x14]
    ldr     r0, =SamusEaterOAMProjectileOAM1
    str     r0, [r2, 0x18]
    strb    r4, [r2, 0x1C]
    strh    r4, [r2, 0x16]
    mov     r0, r12
    add     r0, 0x2D    ;Timer 2
    strb    r4, [r0]
    sub     r0, 0x1     ;Timer 1
    strb    r4, [r0]
    mov     r1, r12
    add     r1, 0x22    ;Draw order
    mov     r0, 0x3
    strb    r0, [r1]
    ldr     r1, =BackupOfIORegisters
    ldrb    r1, [r1, 0xA]
    and     r0, r1
    mov     r1, r12
    add     r1, 0x21    ;Background priority
    strb    r0, [r1]
    add     r1, 4       ;samus collision
    mov     r0, 6
    strb    r0, [r1]
    mov     r0, r12
    add     r0, 0x2E    ;work variable, was 2f
    strb    r4, [r0]
    ldrb    r0, [r2, 0x1E]  ;Room slot/part number
    cmp     r0, 0
    beq     @@f44DA0
    sub     r1, 1       ;pose
    mov     r0, 0x18
    b       @@f44DA6
@@f44DA0:
    mov     r1, r12
    add     r1, 0x24
    mov     r0, 0x2
@@f44DA6:
    strb    r0, [r1]
    pop     r4
    pop     r0
    bx      r0
.pool

SamusEaterProjectilePose2:  ;8044db0
    push    r4-r7, r14
    mov     r7, r8
    push    r7
    ldr     r3, =CurrSpriteData
    mov     r6, r3
    add     r6, 0x2D    ;Timer 2
    ldrb    r2, [r6]
    ldr     r5, =SamusEaterProjectileYMoveTable
    lsl     r0, r2, 1
    add     r0, r0, r5
    ldrh    r4, [r0]
    mov     r7, 0x0
    ldsh    r1, [r0, r7]
    ldr     r0, =0x7FFF
    cmp     r1, r0
    bne     @@f44DD4
    ldrh    r4, [r5]
    mov     r2, 0
@@f44DD4:
    add     r0, r2, 1
    strb    r0, [r6]
    ldrh    r0, [r3, 2] ;y
    add     r1, r0, r4
    strh    r1, [r3, 2]
    mov     r0, r3
    add     r0, 0x2E    ;work variable
    ldrb    r0, [r0]
    cmp     r0, 0
    beq     @@f44DF8
    add     r0, r1, 2
    b       @@f44DFA
    .pool
@@f44DF8:
    add     r0, r1, 1
@@f44DFA:
    strh    r0, [r3, 2]
    mov     r4, r3
    ldrh    r1, [r4]    ;status
    mov     r0, 0x40
    mov     r8, r0
    mov     r0, 0x40
    and     r0, r1
    cmp     r0, 0x0
    beq     @@f44E48

    mov     r6, r4
    add     r6, 0x2C    ;Timer 1
    ldrb    r2, [r6]
    ldr     r5, =SamusEaterProjectileX1MoveTable
    lsl     r0, r2, 1
    add     r0, r0, r5
    ldrh    r3, [r0]
    mov     r7, 0
    ldsh    r1, [r0, r7]
    ldr     r0, =0x7FFF
    cmp     r1, r0
    bne     @@f44E28
    ldrh    r3, [r5]
    mov     r2, 0
@@f44E28:
    add     r0, r2, 1
    strb    r0, [r6]
    ldrh    r0, [r4, 4]   ;x
    add     r0, r0, r3
    add     r0, 3
    strh    r0, [r4, 4]
    ldrh    r0, [r4, 2]
    ldrh    r1, [r4, 4]
    add     r1, 0x10
    b       @@f44E76
    .pool
@@f44E48:
    mov     r6, r4
    add     r6, 0x2C    ;Timer 1
    ldrb    r2, [r6]
    ldr     r5, =SamusEaterProjectileX2MoveTable
    lsl     r0, r2, 0x1
    add     r0, r0, r5
    ldrh    r3, [r0]
    mov     r7, 0
    ldsh    r1, [r0, r7]
    ldr     r0, =0x7FFF
    cmp     r1, r0
    bne     @@f44E64
    ldrh    r3, [r5]
    mov     r2, 0
@@f44E64:
    add     r0, r2, 1
    strb    r0, [r6]
    ldrh    r0, [r4, 4]
    add     r0, r0, r3
    sub     r0, 0x3
    strh    r0, [r4, 4]
    ldrh    r0, [r4, 2]
    ldrh    r1, [r4, 4]
    sub     r1, 0x10
@@f44E76:
    ldr     r3, =SpriteUtilCheckCollisionAtPosition+1
    bl      WRapperR3
    ldr     r0, =PreviousSideCollisionCheck
    ldrb    r0, [r0]
    cmp     r0, 0
    beq     @@f44E96
    ldrh    r0, [r4]
    mov     r1, r8
    eor     r0, r1
    strh    r0, [r4]
    mov     r0, 0
    strb    r0, [r6]
    mov     r1, r4
    add     r1, 0x2E    ;Work variable
    mov     r0, 1
    strb    r0, [r1]
@@f44E96:
    ldr     r4, =CurrSpriteData
    ldrh    r0, [r4, 2]
    add     r0, 0x10
    ldrh    r1, [r4, 4]
    ldr     r3, =SpriteUtilCheckCollisionAtPosition+1
    bl      WRapperR3
    ldr     r0, =CurrentAffectingClip
    ldrh    r0, [r0, 0x2]
    cmp     r0, 1
    beq     @@f44EB8
    ldr     r0, =PreviousSideCollisionCheck
    ldrb    r0, [r0]
    cmp     r0, 0x0
    bne     @@f44EB8
    b       @@Return
@@f44EB8:
    ldr     r0,=CurrSpriteData
    add     r0, 0x24    ;pose
    mov     r1, 0x37
    strb    r1, [r0]
@@Return:
    pop     r3
    mov     r8, r3
    pop     r4-r7
    pop     r0
    bx      r0
.pool

pose18: ;44ee0
    push    r4-r6, r14
    ldr     r2, =CurrSpriteData
    mov     r0, 0x2D    ;Timer 2
    add     r0, r0, r2
    mov     r12, r0
    ldrb    r3, [r0]
    ldr     r6, =SamusEaterProjectileYMoveTable2
    lsl     r0, r3, 0x1
    add     r0, r0, r6
    ldrh    r5, [r0]
    mov     r4, 0
    ldsh    r1, [r0, r4]
    ldr     r0, =0x7FFF
    mov     r4, r2
    cmp     r1, r0
    bne     @@f44F1C
    sub     r1, r3, 1
    lsl     r1, r1, 1
    add     r1, r1, r6
    ldrh    r0, [r4, 2] ;y
    ldrh    r1, [r1]
    add     r0, r0, r1
    b       @@f44F26
    .pool
@@f44F1C:
    add     r0, r3, 1
    mov     r1, r12
    strb    r0, [r1]
    ldrh    r0, [r4, 2]
    add     r0, r0, r5
@@f44F26:
    strh    r0, [r4, 2]
    ldrh    r1, [r4]
    mov     r0, 0x40
    and     r0, r1
    cmp     r0, 0
    beq     @@f44F38
    ldrh    r0, [r4, 4] ;x
    add     r0, 4
    b       @@f44F3C
@@f44F38:
    ldrh    r0, [r4, 4]
    sub     r0, 4
@@f44F3C:
    strh    r0, [r4, 4]
    ldrh    r0, [r4, 2]
    ldrh    r1, [r4, 4]
    ldr     r3, =SpriteUtilCheckCollisionAtPosition+1
    bl      WRapperR3
    ldr     r0, =CurrentAffectingClip
    ldrh    r0, [r0, 2]
    cmp     r0, 1
    beq     @@f44F5C
    ldr     r0, =PreviousSideCollisionCheck
    ldrb    r0, [r0]
    cmp     r0, 0
    bne     @@f44F5C
    b       @@f44F64
@@f44F5C:
    ldr     r0,=CurrSpriteData
    add     r0, 0x24
    mov     r1, 0x37
    strb    r1, [r0]
@@f44F64:
    pop     r4-r6
    pop     r0
    bx      r0
    .pool

SamusEaterProjectileDeathInit:    ;44f78
    ldr     r0, =CurrSpriteData
    mov     r12, r0
    mov     r1, r12
    add     r1, 0x24    ;pose
    mov     r3, 0
    mov     r0, 0x38
    strb    r0, [r1]
    mov     r0, r12
    add     r0, 0x25    ;samus collision
    strb    r3, [r0]
    mov     r2, r12
    ldrh    r1, [r2]
    mov     r2, 0x80
    lsl     r2, r2, 8
    mov     r0, r2
    mov     r2, 0x0
    orr     r0, r1
    mov     r1, r12
    strh    r0, [r1]
    ldr     r0, =SamusEaterOAMProjectileOAM2
    str     r0, [r1, 0x18]
    strb    r2, [r1, 0x1C]
    strh    r3, [r1, 0x16]
    bx      r14
.pool

SamusEaterProjectileDeath:     ;44fb0
    push    r4, r14
    ldr     r4, =CurrSpriteData
    mov     r1, r4
    add     r1, 0x26
    mov     r0, 1
    strb    r0, [r1]
    ldr     r0, =SpriteUtilCheckEndCurrentSpriteAnim+1
    bl      WRapperR0
    cmp     r0, 0
    beq     @@Return
    mov     r0, 0
    strh    r0, [r4]
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool

SamusEaterProjectileAI:   ;452E8
    push    r4-r5, r14
    add     sp, -4
    ldr     r4, =CurrSpriteData
    mov     r0, r4
    add     r0, 0x24    ;pose
    ldrb    r0, [r0]
    cmp     r0, 2
    beq     @@f45314
    cmp     r0, 2
    bgt     @@f45304
    cmp     r0, 0
    beq     @@f4530E
    b       @@f45326
    .pool
@@f45304:
    cmp     r0, 0x18
    beq     @@f4531A
    cmp     r0, 0x37
    beq     @@f45320
    cmp     r0, 0x42
    beq     @@f45320
    cmp     r0, 0x38
    beq     @@f45326
    b       @@Dead
@@f4530E:
    bl      SamusEaterProjectileInit
    b       @@Return
@@f45314:
    bl      SamusEaterProjectilePose2
    b       @@Return
@@f4531A:
    bl      pose18
    b       @@Return
@@f45320:
    bl      SamusEaterProjectileDeathInit
    b       @@Return
@@f45326:
    bl      SamusEaterProjectileDeath
    b       @@Return
@@Dead:
    ldr     r5, =DeathRoutine+1
    mov     r0, 0x1F
    str     r0, [sp]
    ldrh    r1, [r4, 2]
    ldrh    r2, [r4, 4]
    mov     r0, 0
    mov     r3, 1
    bl      WRapperR5
@@Return:
    add     sp, 4
    pop     r4-r5
    pop     r0
    bx      r0
.pool