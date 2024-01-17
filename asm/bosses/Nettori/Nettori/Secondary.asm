NettoriBeamCheckProjectile:
    push    r4-r7, r14
    mov r7, r10
    mov r6, r9
    mov r5, r8
    push    r5-r7
    add sp, -0x14
    ldr r0, =Equipment
    ldr r4, =SetParticleEffect+1
    mov r10, r0
    ldr r5, =CurrSpriteData
    ldrh    r1, [r5, 2] ;y
    ldrh    r2, [r5, 4] ;x
    ldrh    r0, [r5, 0xA]   ;top
    add r0, r1, r0
    lsl r0, r0, 0x10
    lsr r0, r0, 0x10
    str r0, [sp, 4]  ;hitbox top
    ldrh    r0, [r5, 0xC]   ;botttom
    add r1, r1, r0
    lsl r1, r1, 0x10
    lsr r1, r1, 0x10
    str r1, [sp, 0xC]  ;hitbox bottom
    ldrh    r0, [r5, 0xE]
    add r0, r2
    lsl r0, r0, 0x10
    lsr r0, r0, 0x10
    str r0, [sp, 8]    ;hitbox left
    ldrh    r0, [r5, 0x10]
    add r2, r2, r0
    lsl r2, r2, 0x10
    lsr r2, r2, 0x10
    str r2, [sp, 0x10]    ;hitbox right
    ldr r6, =ProjectileData
    mov r1, 0xE0
    lsl r1, r1, 1
    add r0, r6, r1
    cmp r6, r0
    bcc @@Next
    b   @@Return
@@Next:
    mov r0, 1
    mov r9, r0
@@StartCheckProj:
    ldrb    r1, [r6]
    mov r0, r9
    and r0, r1
    cmp r0, 0
    bne @@StatusExist
    b   @@CheckNext
@@StatusExist:
    mov r0, 0x10
    and r0, r1
    cmp r0, 0
    bne @@StatusAffectEnv
    b   @@CheckNext
@@StatusAffectEnv:
    ldrb    r0, [r6, 0x11]
    cmp r0, 1
    bhi @@MoveStageBigger1
    b   @@CheckNext
@@MoveStageBigger1:
    ldrh    r0, [r6, 0xA]
    ldr r1, [sp, 8]
    sub r1, 0x20
    cmp r0, r1
    bhi @@xBiggerLeft
    b   @@CheckNext
@@xBiggerLeft:
    ldr r1, [sp, 0x10]
    cmp r0, r1
    bcc @@unkown
    b   @@CheckNext
@@unkown:
    ldrh    r0, [r6, 8]
    ldr r1, [sp, 4]
    cmp r0, r1
    bhi @@yBiggerTop
    b   @@CheckNext
@@yBiggerTop:
    ldr r1, [sp, 0xC]
    cmp r0, r1
    bcc @@ySmallerBottom
    b   @@CheckNext
@@ySmallerBottom:
    mov r7, r0  ;proj y
    ldrh    r0, [r6, 0xA]
    mov r8, r0   ;proj X
    b   @@Inv
    ldrb    r1, [r6, 0xF]
    cmp r1, 0xD
    bgt @@Inv
    lsl r1, r1, 2
    ldr r0, =@@AllProjectile
    add r0, r1
    ldr r0, [r0]
    mov r15, r0
    .pool
@@AllProjectile:
    .dw @@Inv, @@Inv, @@Inv, @@Inv
    .dw @@Inv, @@Inv, @@Charge, @@LongCharge
    .dw @@IceCharge, @@WaveCharge, @@PlasmaCharge, @@Inv
    .dw @@Missile, @@SuperMissile
@@Charge:
    mov r2, 0x2A
    mov r3, 1
    b   @@SetProjectile
@@LongCharge:
    mov r2, 0x2B
    mov r3, 1
    b   @@SetProjectile
@@IceCharge:
    mov r2, 0x2C
    mov r3, 1
    b   @@SetProjectile
@@WaveCharge:
    mov r0, r10
    ldrb    r0, [r0, 0xD]
    mov r1, 2
    and r0, r1
    cmp r0, 0
    mov r3, 1
    beq @@WavenoIce
    mov r2, 0x2D
    b   @@SetProjectile
@@WavenoIce:
    mov r2, 0x32
    b   @@SetProjectile
@@PlasmaCharge:
    mov r0, r10
    ldrb    r0, [r0, 0xD]
    mov r1, 6
    and r1, r0
    cmp r1, 6
    mov r3, 2
    beq @@FullPlasma
    mov r2, 0x2E
    b   @@SetProjectile
@@FullPlasma:
    mov r2, 0x33
    b   @@SetProjectile
@@Missile:
    mov r2, 0x30
    mov r3, 2
    b   @@SetProjectile
@@SuperMissile:
    mov r2, 0x31
    mov r3, 4
    b   @@SetProjectile
@@SetProjectile:
    mov r0, r5
    add r0, 0x2E
    strb    r3, [r0]
    mov r0, r7
    mov r1, r8
    bl  WRapperR4
    mov r0, 0
    strb    r0, [r6]
    mov r2, r5
    add r2, 0x24
    mov r1, 4
    strb    r1, [r2]
    add r2, 0x7
    ldrb    r0, [r2]
    mov r1, 0x80
    and r0, r1
    mov r1, 0x11
    orr r0, r1
    strb    r0, [r2]

    b   @@NextProj
@@Inv:
    ldrb r1, [r6, 0xF]
    cmp r1, 0xC
    beq @@InvMissile
    cmp r1, 0xD
    beq @@InvMissile

    mov r0, 0
    strb    r0, [r6]
    b   @@InvParticle
@@InvMissile:
    mov r0, r6
    ldr r3, =0x8050975
    bl  WRapperR3
@@InvParticle:
    mov r0, r7
    mov r1, r8
    mov r2, 0x2F
    bl  WRapperR4
@@NextProj:
@@CheckNext:
    add r6, 0x1C
    ldr r0, =0x3000bec
    cmp r6, r0
    bcs @@Return
    b   @@StartCheckProj
@@Return:
    add sp, 0x14
    pop r3-r5
    mov r8, r3
    mov r9, r4
    mov r10, r5
    pop r4-r7
    pop r0
    bx  r0
.pool

RemoveSamusEaterBudsAndSpores:  ;43b14
    push    r4, r14
    mov     r3, 0x0
    ldr     r4, =SpriteData
@@f43B1A:
    lsl     r0, r3, 3
    sub     r0, r0, r3
    lsl     r0, r0, 3
    add     r2, r0, r4
    ldrh    r1, [r2]
    mov     r0, 1
    and     r0, r1
    cmp     r0, 0
    beq     @@f43B5A
    mov     r0, r2
    add     r0, 0x32    ;prop
    ldrb    r1, [r0]
    mov     r0, 0x80
    and     r0, r1
    cmp     r0, 0
    bne     @@f43B50
    ldrb    r0, [r2, 0x1D]
    cmp     r0, SamusEaterBudSpriteID
    bne     @@f43B5A
    mov     r1, r2
    add     r1, 0x24    ;pose
    mov     r0, 0x45
    strb    r0, [r1]
    b       @@f43B5A
    .pool
@@f43B50:
    ldrb    r0, [r2, 0x1D]
    cmp     r0, SamusEaterProjectileSpriteID
    bne     @@f43B5A
    mov     r0, 0
    strh    r0, [r2]
@@f43B5A:
    add     r0, r3, 1
    lsl     r0, r0, 0x18
    lsr     r3, r0, 0x18
    cmp     r3, 0x17
    bls     @@f43B1A
    pop     r4
    pop     r0
    bx      r0

NettoriPartInit:    ;43FD4
    push    r4, r14
    ldr     r0, =CurrSpriteData
    mov     r12, r0
    ldrh    r1, [r0]    ;status
    ldr     r0, =0xFFFB
    and     r0, r1
    mov     r2, 0x0
    mov     r4, 0x0
    mov     r1, r12
    strh    r0, [r1]
    ldr     r1, =0xFFFC
    mov     r3, r12
    strh    r1, [r3, 0xA]
    mov     r0, 0x4
    strh    r0, [r3, 0xC]
    strh    r1, [r3, 0xE]
    strh    r0, [r3, 0x10]
    mov     r0, r12
    add     r0, 0x25    ;samus collision
    strb    r2, [r0]
    strb    r2, [r3, 0x1C]
    strh    r4, [r3, 0x16]
    mov     r1, r12
    add     r1, 0x24    ;pose
    mov     r0, 0x2
    strb    r0, [r1]
    ldrb    r0, [r3, 0x1E]  ;Room slot/part number
    cmp     r0, 0x6
    bls     @@f44010
    b       @@f44164
@@f44010:
    lsl     r0, r0, 2
    ldr     r1, =@@JumpTable
    add     r0, r0, r1
    ldr     r0, [r0]
    mov     r15, r0
    .pool
@@JumpTable:
    .dw @@f44048, @@f4406C, @@f44084, @@f440AC
    .dw @@f440D4, @@f440FC, @@f44124
@@f44048:
    ldr     r0, =NettoriPartOAM0
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x27    ;Draw distance top offset
    mov     r1, 0x0
    mov     r0, 0xA0
    strb    r0, [r2]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x30
    strb    r0, [r1]
    b       @@Return
    .pool
@@f4406C:
    ldr     r0, =NettoriPartOAM1
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x22    ;Draw order
    mov     r1, 0x0
    mov     r0, 0x3
    strb    r0, [r2]
    add     r2, 0x5
    mov     r0, 0x30
    b       @@f440BE
    .pool
@@f44084:
    ldr     r0, =NettoriPartOAM2
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x22
    mov     r1, 0x0
    mov     r0, 0x5
    strb    r0, [r2]
    add     r2, 0x5
    mov     r0, 0x38
    strb    r0, [r2]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x28
    strb    r0, [r1]
    b       @@Return
    .pool
@@f440AC:
    ldr     r0, =NettoriPartOAM3
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x22
    mov     r1, 0x0
    mov     r0, 0x2
    strb    r0, [r2]
    add     r2, 0x5
    mov     r0, 0x40
@@f440BE:
    strb    r0, [r2]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x18
    strb    r0, [r1]
    b       @@Return
    .pool
@@f440D4:
    ldr     r0, =NettoriPartOAM4
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x22
    mov     r1, 0x0
    mov     r0, 0x2
    strb    r0, [r2]
    add     r2, 0x5
    mov     r0, 0x60
    strb    r0, [r2]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x20
    strb    r0, [r1]
    b       @@Return
    .pool
@@f440FC:
    ldr     r0, =NettoriPartOAM5
    str     r0, [r3, 0x18]
    mov     r2, r3
    add     r2, 0x22
    mov     r1, 0x0
    mov     r0, 0x1
    strb    r0, [r2]
    add     r2, 0x5
    mov     r0, 0x30
    strb    r0, [r2]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x10
    strb    r0, [r1]
    b       @@Return
    .pool
@@f44124:
    ldr     r0, =NettoriPartOAM6
    str     r0, [r3, 0x18]
    mov     r0, r3
    add     r0, 0x22
    mov     r1, 0x0
    mov     r2, 0x3
    strb    r2, [r0]
    mov     r4, 0x27
    mov     r0, 0x60
    strb    r0, [r4, r3]
    mov     r0, r3
    add     r0, 0x28
    strb    r1, [r0]
    mov     r1, r3
    add     r1, 0x29
    mov     r0, 0x20
    strb    r0, [r1]
    mov     r0, r3
    add     r0, 0x33    ;Frozen palette row offset
    strb    r2, [r0]
    ldrh    r1, [r3]
    mov     r0, 0x4
    mov     r2, 0x0
    orr     r0, r1
    strh    r0, [r3]
    mov     r0, r3
    add     r0, 0x2C    ;	Timer 1
    strb    r2, [r0]
    b       @@Return
    .pool
@@f44164:
    mov     r0, r12
    strh    r4, [r0]
@@Return:
    pop     r4
    pop     r0
    bx      r0

NettoriPartPose2:   ;44170
    push    r4-r7, r14
    mov     r3, r8
    mov     r4, r9
    push    r3-r4
    add     sp, -0xC
    mov     r0, 0x0
    mov     r8, r0
    ldr     r2, =SpawnNewSecondarySprite+1
    mov     r9, r2
    ldr     r2, =CurrSpriteData
    mov     r0, r2
    add     r0, 0x23    ;Primary sprite RAM slot+

    ldrb    r5, [r0]
    ldr     r0, =PrimarySpriteStats
    mov     r1, NettoriSpriteID
    lsl     r3, r1, 3
    add     r3, r1
    lsl     r3, r3, 1
    add     r0, r3
    ldrh    r3, [r0]
    ldr     r1, =SpriteData
    lsl     r0, r5, 3
    sub     r0, r0, r5
    lsl     r0, r0, 3
    add     r0, r0, r1
    ldrh    r6, [r0, 0x14]
    ldrb    r0, [r2, 0x1E]
    mov     r4, r2
    mov     r7, r1
    cmp     r0, 6
    bls     @@f441A6
    b       @@f444E8
@@f441A6:
    lsl     r0, r0, 2
    ldr     r1, =@@RoomSlot
    add     r0, r0, r1
    ldr     r0, [r0]
    mov     r15, r0
    .pool
@@RoomSlot:
    .dw @@f441dc, @@f44206, @@f4421e, @@f44238
    .dw @@f44268, @@f442c0, @@f44338
@@f441dc:
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r0, r0, r7
    add     r0, 0x20
    ldrb    r1, [r0]
    mov     r0, r4
    add     r0, 0x20    ;Palette row
    strb    r1, [r0]
    lsr     r0, r3, 1
    cmp     r6, r0
    bcc     @@f441F6
    b       @@f444EC
@@f441F6:
    mov     r0, r8
    add     r0, 0x1
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    mov     r8, r0
    bl      RemoveSamusEaterBudsAndSpores
    mov     r0, NettoriPhase2Music
    mov     r1, 0
    ldr     r3, =PlayMusic+1
    bl      WRapperR3
    b       @@f444EC
@@f44206:
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r0, r0, r7
    add     r0, 0x20
    ldrb    r1, [r0]
    mov     r0, r4
    add     r0, 0x20
    strb    r1, [r0]
    lsl     r0, r3, 2
    add     r0, r0, r3
    b       @@f44254
@@f4421e:
    lsl     r0, r5, 3
    sub     r0, r0, r5
    lsl     r0, r0, 3
    add     r0, r0, r7
    add     r0, 0x20
    ldrb    r1, [r0]
    mov     r0, r4
    add     r0, 0x20
    strb    r1, [r0]
    lsl     r0, r3, 0x1
    add     r0, r0, r3
    lsl     r0, r0, 0x1
    b       @@f44254
@@f44238:
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r0, r0, r7
    add     r0, 0x20
    ldrb    r1, [r0]
    mov     r0, r4
    add     r0, 0x20
    strb    r1, [r0]
    lsl     r0, r3, 0x3
    sub     r0, r0, r3
    cmp     r0, 0x0
    bge     @@f44254
    add     r0, 0x7
@@f44254:
    asr     r0, r0, 0x3
    cmp     r6, r0
    blt     @@f4425C
    b       @@f444EC
@@f4425C:
    mov     r0, r8
    add     r0, 0x1
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    mov     r8, r0
    b       @@f444EC
@@f44268:
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r1, r0, r7
    mov     r0, r1
    add     r0, 0x20
    ldrb    r0, [r0]
    mov     r2, r4
    add     r2, 0x20
    mov     r3, 0
    strb    r0, [r2]
    cmp     r6, 0
    beq     @@f442DA
    mov     r0, r1
    add     r0, 0x2E    ;work variable
    ldrb    r2, [r0]
    cmp     r2, 0x1
    bne     @@f442A4
    ldr     r1, [r4, 0x18]
    ldr     r0, =NettoriPartOAM4
    cmp     r1, r0
    beq     @@f44296
    b       @@f444EC
@@f44296:
    ldr     r0, =NettoriPartOAM7
    b       @@f44302
    .pool
@@f442A4:
    cmp     r2, 0x0
    beq     @@f442AA
    b       @@f444EC
@@f442AA:
    ldr     r1, [r4, 0x18]
    ldr     r0, =NettoriPartOAM7
    cmp     r1, r0
    beq     @@f442B4
    b       @@f444EC
@@f442B4:
    ldr     r0, =NettoriPartOAM4
    b       @@f44326
    .pool
@@f442c0:
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r1, r0, r7
    mov     r0, r1
    add     r0, 0x20
    ldrb    r0, [r0]
    mov     r2, r4
    add     r2, 0x20
    mov     r3, 0x0
    strb    r0, [r2]
    cmp     r6, 0x0
    bne     @@f442EC
@@f442DA:
    mov     r1, r4
    add     r1, 0x24
    mov     r0, 0x3A
    strb    r0, [r1]
    add     r1, 8       ;Timer1
    mov     r0, 0x1E
    strb    r0, [r1]
    strb    r6, [r2]
    b       @@f444EC
@@f442EC:
    mov     r0, r1
    add     r0, 0x2E    ;work variable
    ldrb    r2, [r0]
    cmp     r2, 0x2
    bne     @@f44314
    ldr     r1, [r4, 0x18]
    ldr     r0, =NettoriPartOAM5
    cmp     r1, r0
    beq     @@f44300
    b       @@f444EC
@@f44300:
    ldr     r0, =NettoriPartOAM8
@@f44302:
    str     r0, [r4, 0x18]
    strb    r3, [r4, 0x1C]
    strh    r3, [r4, 0x16]
    b       @@f444EC
    .pool
@@f44314:
    cmp     r2, 0x0
    beq     @@f4431A
    b       @@f444EC
@@f4431A:
    ldr     r1, [r4, 0x18]
    ldr     r0, =NettoriPartOAM8
    cmp     r1, r0
    beq     @@f44324
    b       @@f444EC
@@f44324:
    ldr     r0, =NettoriPartOAM5
@@f44326:
    str     r0, [r4, 0x18]
    strb    r2, [r4, 0x1C]
    strh    r2, [r4, 0x16]
    b       @@f444EC
    .pool
@@f44338:
    cmp     r6, 0
    bne     @@f44340
    strh    r6, [r4]
    b       @@f444EC
@@f44340:
    lsr     r0, r3, 0x1
    cmp     r6, r0
    bcc     @@f44348
    b       @@f44494
@@f44348:
    mov     r0, r4
    add     r0, 0x2C    ;Timer 1
    ldrb    r0, [r0]
    cmp     r0, 0x14
    bne     @@f443E4
    mov     r0, 0x0
    strb    r0, [r4, 0x1C]
    strh    r0, [r4, 0x16]
    ldrh    r1, [r4]
    ldr     r0, =0xFFFB
    and     r0, r1
    strh    r0, [r4]
    ldr     r0, [r4, 0x18]
    ldr     r2, =NettoriPartOAM6
    cmp     r0, r2
    bne     @@f44380
    lsl     r0, r5, 3
    sub     r0, r0, r5
    lsl     r0, r0, 3
    add     r0, r0, r7
    add     r0, 0x2E    ;work variable
    mov     r1, 1
    b       @@f4438C
    .pool
@@f44380:
    lsl     r0, r5, 3
    sub     r0, r0, r5
    lsl     r0, r0, 3
    add     r0, r0, r7
    add     r0, 0x2E    ;work variable
    mov     r1, 2
@@f4438C:
    strb    r1, [r0]
    ldr     r1, =CurrSpriteData
    ldr     r0, [r1, 0x18]
    cmp     r0, r2
    bne     @@f443C4
    ldrb    r2, [r1, 0x1F]  ;Spriteset graphics slot
    mov     r0, r1
    add     r0, 0x23    ;Primary sprite RAM slot
    ldrb    r3, [r0]
    ldrh    r0, [r1, 0x2]
    ldr     r4, =0xFFFFFEE8
    add     r0, r0, r4
    str     r0, [sp]
    ldrh    r0, [r1, 0x4]
    sub     r0, 0x48
    str     r0, [sp, 0x4]
    mov     r0, 0x0
    str     r0, [sp, 0x8]
    mov     r0, NettoriBeamSpriteID
    mov     r1, 0x0
    bl      WRapperR9
    b       @@f443E4
    .pool
@@f443C4:
    ldrb    r2, [r1, 0x1F]
    mov     r0, r1
    add     r0, 0x23
    ldrb    r3, [r0]
    ldrh    r0, [r1, 0x2]
    sub     r0, 0xA8
    str     r0, [sp]
    ldrh    r0, [r1, 0x4]
    sub     r0, 0x20
    str     r0, [sp, 0x4]
    mov     r0, 0x0
    str     r0, [sp, 0x8]
    mov     r0, NettoriBeamSpriteID
    mov     r1, 0x0
    bl      WRapperR9
@@f443E4:
    ldr     r1, =CurrSpriteData
    ldrh    r0, [r1, 0x16]
    mov     r4, r1
    cmp     r0, 0x0
    beq     @@f443F2
    cmp     r0, 0x2
    bne     @@f44400
@@f443F2:
    mov     r1, r4
    add     r1, 0x20
    mov     r0, 0x1
    strb    r0, [r1]
    b       @@f44484
    .pool
@@f44400:
    cmp     r0, 0x4
    beq     @@f44408
    cmp     r0, 0x6
    bne     @@f44412
@@f44408:
    mov     r1, r4
    add     r1, 0x20
    mov     r0, 0x2
    strb    r0, [r1]
    b       @@f44484
@@f44412:
    cmp     r0, 0x8
    beq     @@f4441E
    cmp     r0, 0xA
    beq     @@f4441E
    cmp     r0, 0xC
    bne     @@f44428
@@f4441E:
    mov     r1, r4
    add     r1, 0x20
    mov     r0, 0x3
    strb    r0, [r1]
    b       @@f44484
@@f44428:
    cmp     r0, 0xE
    bne     @@f44484
    mov     r0, r4
    add     r0, 0x20
    mov     r1, 0x0
    strb    r1, [r0]
    mov     r3, r4
    add     r3, 0x2C    ;Timer 1
    ldrb    r0, [r3]
    cmp     r0, 0x5A
    bne     @@f44484
    ldrh    r1, [r4]
    mov     r0, 0x4
    mov     r2, 0x0
    orr     r0, r1
    strh    r0, [r4]
    ldr     r1, =SpriteData
    lsl     r0, r5, 0x3
    sub     r0, r0, r5
    lsl     r0, r0, 0x3
    add     r0, r0, r1
    add     r0, 0x2E    ;work variable
    strb    r2, [r0]
    strb    r2, [r3]
    ldr     r0, =SpriteUtilCheckCrouchingOrMorphed+1
    bl      WRapperR0
    cmp     r0, 0
    beq     @@f4446C
    ldr     r0, =NettoriPartOAM9
    b       @@f44482
    .pool
@@f4446C:
    ldr     r0, =SpriteRNG
    ldrb    r0, [r0]
    cmp     r0, 0x9
    bls     @@f44480
    ldr     r0, =NettoriPartOAM9
    b       @@f44482
    .pool
@@f44480:
    ldr     r0, =NettoriPartOAM6
@@f44482:
    str     r0, [r4, 0x18]
@@f44484:
    mov     r1, r4
    add     r1, 0x2C    ;Timer 1
    ldrb    r0, [r1]
    add     r0, 0x1
    strb    r0, [r1]
    b       @@f444EC
    .pool
@@f44494:
    ldr     r0, =SpriteUtilCheckCrouchingOrMorphed+1
    bl      WRapperR0
    cmp     r0, 0x0
    beq     @@f444AC
    ldr     r1, =CurrSpriteData
    ldr     r0, =NettoriPartOAM9
    str     r0, [r1, 0x18]
    b       @@f444EC
    .pool
@@f444AC:
    ldr     r0, =SamusData
    ldrh    r1, [r0, 0x14]  ;Y position
    ldr     r2, =CurrSpriteData
    ldrh    r0, [r2, 0x2]
    sub     r0, 0xE0
    cmp     r1, r0
    blt     @@f444DC
    ldr     r0, =SpriteRNG
    ldrb    r1, [r0]
    mov     r0, 0x1
    and     r0, r1
    cmp     r0, 0x0
    beq     @@f444DC
    ldr     r0, =NettoriPartOAM9
    str     r0, [r2, 0x18]
    b       @@f444EC
    .pool
@@f444DC:
    ldr     r0, =NettoriPartOAM6
    str     r0, [r2, 0x18]
    b       @@f444EC
    .pool
@@f444E8:
    mov     r0, r8
    strh    r0, [r2]
@@f444EC:
    mov     r1, r8
    cmp     r1, 0x0
    beq     @@Return
    ldr     r0, =CurrSpriteData
    mov     r2, r0
    add     r2, 0x2F    ;array
    mov     r1, 0x0
    strb    r1, [r2]
    add     r0, 0x24
    mov     r1, 0x38
    strb    r1, [r0]
@@Return:
    add     sp, 0xC
    pop     r3-r4
    mov     r8, r3
    mov     r9, r4
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NettoriPartPose38:  ;44514
    push    r4-r7, r14
    mov     r7, r8
    push    r7
    ldr     r0, =CurrSpriteData
    ldrh    r4, [r0, 0x2]
    ldrh    r5, [r0, 0x4]
    ldrb    r1, [r0, 0x1E]
    mov     r8, r0
    cmp     r1, 0x1
    beq     @@RoomSlot1
    cmp     r1, 0x1
    bgt     @@f44538
    cmp     r1, 0x0
    beq     @@f44542
    b       @@f445C4
    .pool
@@f44538:
    cmp     r1, 0x2
    beq     @@RoomSlot2
    cmp     r1, 0x3
    beq     @@RoomSlot3
    b       @@f445C4
@@f44542:
    ldr     r1, =0xFFFFFF00
    add     r0, r4, r1
    lsl     r0, r0, 0x10
    mov     r1, r5
    sub     r1, 0x60
    lsl     r1, r1, 0x10
    lsr     r4, r0, 0x10
    ldr     r2, =0xFFE00000
    add     r0, r0, r2
    lsr     r3, r0, 0x10
    lsr     r5, r1, 0x10
    mov     r0, 0x80
    lsl     r0, r0, 0xE
    b       @@f445BA
    .pool
@@RoomSlot1:
    mov     r0, r4
    sub     r0, 0x80
    lsl     r0, r0, 0x10
    lsr     r4, r0, 0x10
    mov     r0, r5
    sub     r0, 0x28
    lsl     r0, r0, 0x10
    lsr     r5, r0, 0x10
    mov     r3, r4
    mov     r2, r5
    b       @@f445CA
@@RoomSlot2:
    mov     r0, r4
    sub     r0, 0x80
    lsl     r0, r0, 0x10
    mov     r1, r5
    sub     r1, 0x70
    lsl     r1, r1, 0x10
    lsr     r4, r0, 0x10
    ldr     r2, =0xFFC00000
    add     r0, r0, r2
    lsr     r3, r0, 0x10
    lsr     r5, r1, 0x10
    mov     r0, 0x80
    lsl     r0, r0, 0xD
    b       @@f445BA
    .pool
@@RoomSlot3:
    mov     r0, r4
    sub     r0, 0x80
    lsl     r0, r0, 0x10
    mov     r1, r5
    sub     r1, 0x40
    lsl     r1, r1, 0x10
    lsr     r4, r0, 0x10
    ldr     r2, =0xFFA00000
    add     r0, r0, r2
    lsr     r3, r0, 0x10
    lsr     r5, r1, 0x10
    mov     r0, 0xC0
    lsl     r0, r0, 0xD
@@f445BA:
    add     r1, r1, r0
    lsr     r2, r1, 0x10
    b       @@f445CA
    .pool
@@f445C4:
    mov     r0, 0x0
    mov     r1, r8
    strh    r0, [r1]
@@f445CA:
    mov     r6, r8
    mov     r7, r6
    add     r7, 0x2F    ;array
    ldrb    r1, [r7]
    mov     r0, 7
    and     r0, r1
    cmp     r0, 0x0
    bne     @@f445E4
    mov     r0, r3
    mov     r1, r2
    mov     r2, 0x22        ;??
    ldr     r3, =SetParticleEffect+1
    bl      WRapperR3
@@f445E4:
    mov     r0, r4
    mov     r1, r5
    ldr     r3, =SpriteUtilCheckVerticalCollisionAtPositionSlopes+1
    bl      WRapperR3
    ldr     r0, =PreviousVerticalCollisionCheck
    ldrb    r0, [r0]
    cmp     r0, 0x0
    beq     @@f44620
    mov     r1, r6
    add     r1, 0x20
    mov     r0, 0x0
    strb    r0, [r1]
    add     r1, 0x4     ;pose
    mov     r0, 0x3A
    strb    r0, [r1]
    add     r1, 0x8     ;Timer 1
    mov     r0, 0x1E
    strb    r0, [r1]
    mov     r0, r4
    mov     r1, r5
    mov     r2, 0x22    ;??
    ldr     r3, =SetParticleEffect+1
    bl      WRapperR3
    ldr     r0, =0x1B8
    ldr     r3, =PlaySound1+1
    bl      WRapperR3
    b       @@Return
    .pool
@@f44620:
    ldrb    r2, [r7]
    ldr     r4, =NettoriPartTable0
    lsl     r0, r2, 0x1
    add     r0, r0, r4
    ldrh    r3, [r0]
    mov     r5, 0x0
    ldsh    r1, [r0, r5]
    ldr     r0, =0x7FFF
    cmp     r1, r0
    bne     @@f4464C
    sub     r1, r2, 1
    lsl     r1, r1, 0x1
    add     r1, r1, r4
    ldrh    r0, [r6, 0x2]
    ldrh    r1, [r1]
    add     r0, r0, r1
    strh    r0, [r6, 0x2]
    b       @@Return
    .pool
@@f4464C:
    add     r0, r2, 1
    strb    r0, [r7]
    mov     r1, r8
    ldrh    r0, [r1, 0x2]
    add     r0, r0, r3
    strh    r0, [r1, 0x2]
@@Return:
    pop     r3
    mov     r8, r3
    pop     r4-r7
    pop     r0
    bx      r0

NettoriPartPose3A:  ;44664
    push    r14
    ldr     r3, =CurrSpriteData
    mov     r2, r3
    add     r2, 0x2C    ;Timer 1
    ldrb    r1, [r2]
    mov     r0, 0x1
    and     r0, r1
    cmp     r0, 0x0
    bne     @@f4467E
    ldrh    r0, [r3]
    mov     r1, 0x4
    eor     r0, r1
    strh    r0, [r3]
@@f4467E:
    ldrb    r0, [r2]
    sub     r0, 1
    strb    r0, [r2]
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    cmp     r0, 0
    bne     @@Return
    strh    r0, [r3]
@@Return:
    pop     r0
    bx      r0
    .pool

NettoriPartAI:  ;45038
    push    r14
    ldr     r0, =CurrSpriteData
    mov     r2, r0
    add     r2, 0x26    ;Ignore Samus collision timer
    mov     r1, 1
    strb    r1, [r2]
    add     r0, 0x24  ;pose
    ldrb    r0, [r0]
    cmp     r0, 2
    beq     @@f4506C
    cmp     r0, 2
    bgt     @@f4505C
    cmp     r0, 0
    beq     @@f45066
    b       @@Return
@@f4505C:
    cmp     r0, 0x38
    beq     @@f45072
    cmp     r0, 0x3A
    beq     @@f45078
    b       @@Return
@@f45066:
    bl      NettoriPartInit
    b       @@Return
@@f4506C:
    bl      NettoriPartPose2
    b       @@Return
@@f45072:
    bl      NettoriPartPose38
    b       @@Return
@@f45078:
    bl      NettoriPartPose3A
@@Return:
    pop     r0
    bx      r0
.pool

NettoriBeamInit:    ;44698
    push    r4, r14
    ldr     r0, =CurrSpriteData
    mov     r12, r0
    ldrh    r1, [r0]
    ldr     r2, =0xFFFB
    and     r1, r2
    mov     r2, 0x80
    lsl     r2, r2, 8
    orr     r1, r2
    strh    r1, [r0]
    mov     r3, 0x0
    mov     r4, 0x0
    mov     r2, r12
    add     r2, 0x32
    ldrb    r1, [r2]
    mov     r0, 2
    orr     r0, r1
    strb    r0, [r2]
    mov     r0, r12
    add     r0, 0x27
    mov     r1, 0x10
    strb    r1, [r0]
    add     r0, 0x1
    strb    r1, [r0]
    add     r0, 0x1
    strb    r1, [r0]
    ldr     r0, =0xFFE4
    mov     r2, r12
    strh    r0, [r2, 0xA]
    mov     r0, 0x1C
    strh    r0, [r2, 0xC]
    ldr     r0, =0xFFCC
    strh    r0, [r2, 0xE]
    mov     r0, 0x34
    strh    r0, [r2, 0x10]
    ldr     r0, =NettoriBeamOAM0
    str     r0, [r2, 0x18]
    strb    r3, [r2, 0x1C]
    strh    r4, [r2, 0x16]
    mov     r0, r12
    add     r0, 0x24
    mov     r1, 0x2
    strb    r1, [r0]
    add     r2, 0x22
    mov     r0, 0x3
    strb    r0, [r2]
    mov     r0, r12
    add     r0, 0x25
    strb    r3, [r0]
    mov     r0, 0x1
    mov     r2, r12
    strh    r0, [r2, 0x14]
    mov     r0, r12
    add     r0, 0x33
    strb    r1, [r0]
    mov     r0, 0xE2
    ldr     r3, =PlaySound1+1
    bl      WRapperR3
    pop     r4
    pop     r0
    bx      r0
.pool

f44728:
    push    r14
    ldr     r0, =SpriteUtilCheckEndCurrentSpriteAnim+1
    bl      WRapperR0
    cmp     r0, 0x0
    beq     @@f4475A
    ldr     r3, =CurrSpriteData
    ldr     r0, =NettoriBeamOAM1
    str     r0, [r3, 0x18]
    mov     r0, 0x0
    strb    r0, [r3, 0x1C]
    strh    r0, [r3, 0x16]
    mov     r0, r3
    add     r0, 0x2C  ;Timer 1
    mov     r2, 0x2
    strb    r2, [r0]
    mov     r1, r3
    add     r1, 0x24  ;pose
    mov     r0, 0x18
    strb    r0, [r1]
    mov     r0, r3
    add     r0, 0x25
    mov     r2, 4
    strb    r2, [r0]
    mov     r0, 0xF1    ;beam sound?
    ldr     r3, =PlaySound1+1
    bl      WRapperR3
@@f4475A:
    pop     r0
    bx      r0
    .pool

f4476C:
    push    r14
    ldr     r2, =CurrSpriteData
    mov     r1, r2
    add     r1, 0x2C  ;Timer 1
    ldrb    r0, [r1]
    sub     r0, 1
    strb    r0, [r1]
    lsl     r0, r0, 0x18
    cmp     r0, 0x0
    bne     @@f4478A
    ldr     r0, =NettoriBeamOAM2
    str     r0, [r2, 0x18]
    mov     r1, r2
    add     r1, 0x24
    mov     r0, 0x1A
    strb    r0, [r1]
@@f4478A:
    ldrh    r0, [r2, 0x4]
    sub     r0, 0x14
    strh    r0, [r2, 0x4]
    pop     r0
    bx      r0
    .pool

NettoriplasmabeamShooting:   ;4479c:
    push    r4, r14
    ldr     r4, =CurrSpriteData
    ldrh    r0, [r4, 0x2]
    ldrh    r1, [r4, 0x4]
    ldr     r3, =SpriteUtilCheckCollisionAtPosition+1
    bl      WRapperR3
    ldr     r0, =PreviousSideCollisionCheck
    ldrb    r0, [r0]
    cmp     r0, 0x0
    beq     @@f447D4
    ldrh    r0, [r4, 0x2]
    ldrh    r1, [r4, 0x4]
    mov     r2, 0x2E
    ldr     r3, =SetParticleEffect+1
    bl      WRapperR3 
    mov     r0, 0x0
    strh    r0, [r4]
    
    b       @@Return
    .pool
@@f447D4:
    ldrh    r0, [r4, 0x4]
    sub     r0, 0x14
    strh    r0, [r4, 0x4]
@@Return:
    pop     r4
    pop     r0
    bx      r0


NettoriBeamAI:  ;45080
    push    r14
    bl      NettoriBeamCheckProjectile
    ldr     r0, =CurrSpriteData
    add     r0, 0x24
    ldrb    r0, [r0]
    cmp     r0, 0x2
    beq     @@f450AC
    cmp     r0, 0x2
    bgt     @@f4509C
    cmp     r0, 0x0
    beq     @@f450A6
    b       @@Return
    .pool
@@f4509C:
    cmp     r0, 0x18
    beq     @@f450B2
    cmp     r0, 0x1A
    beq     @@f450B8
    b       @@Return
@@f450A6:
    bl      NettoriBeamInit
    b       @@Return
@@f450AC:
    bl      f44728
    b       @@Return
@@f450B2:
    bl      f4476C
    b       @@Return
@@f450B8:
    bl      NettoriplasmabeamShooting
@@Return:
    pop     r0
    bx      r0