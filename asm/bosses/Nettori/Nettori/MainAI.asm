NettoriCCAA:    ;f43a88
    push    r4-r7, r14
    mov     r6, 1
    ldr     r0, =CurrSpriteData
    ldrh    r7, [r0, 0x2]
    ldrh    r4, [r0, 0x4]
    ldr     r5, =CurrClipdataEffectingAction
    strb    r6, [r5]
    mov     r0, r7
    sub     r0, 0x20
    add     r4, 0x20
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    mov     r0, r7
    sub     r0, 0x60
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    mov     r0, r7
    sub     r0, 0xA0
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    mov     r0, r7
    sub     r0, 0xE0
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    ldr     r1, =#0xFFFFFEE0
    add     r0, r7, r1
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    ldr     r1, =#0xFFFFFEA0
    add     r0, r7, r1
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    ldr     r1, =#0xFFFFFE60
    add     r0, r7, r1
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    strb    r6, [r5]
    ldr     r1, =#0xFFFFFE20
    add     r0, r7, r1
    mov     r1, r4
    ldr     r3, =ChangeBlocks+1
    bl      WRapperR3
    pop     r4-r7
    pop     r0
    bx      r0

f43BC4:
    push    r14
    ldr     r1, =BossWork
    ldrh    r0, [r1, 6]
    sub     r0, 1
    strh    r0, [r1, 6]
    lsl     r0, r0, 0x18
    lsr     r2, r0, 0x18
    cmp     r2, 0
    bne     @@Return
    mov     r0, 0x10
    strh    r0, [r1, 6]
    ldrh    r0, [r1, 4]
    add     r0, 1
    strh    r0, [r1, 4]
    lsl     r0, r0, 0x18
    lsr     r0, r0, 0x18
    cmp     r0, 5
    bls     @@f43BEC
    strh    r2, [r1, 4]
@@f43BEC:
    ldrh    r0, [r1, 4]
    cmp     r0, 5
    bhi     @@f43C3A
    lsl     r0, r0, 2
    ldr     r1, =@@JumpTable
    add     r0, r0, r1
    ldr     r0, [r0]
    mov     r15, r0
.pool
@@JumpTable:
    .dw  @@f43c20, @@f43c38, @@f43c30, @@f43c28
    .dw  @@f43c30, @@f43c38
@@f43c20:
    ldr     r3, =NettoriPal
    b       @@f43C3A
@@f43c28:
    ldr     r3, =Pal36A500
    b       @@f43C3A
@@f43c30:
    ldr     r3, =Pal36A4E0
    b       @@f43C3A
@@f43c38:
    ldr     r3, =Pal36A4C0
@@f43C3A:
    ldr     r1, =0x40000D4
    str     r3, [r1]
    ldr     r0, =0x5000300
    str     r0, [r1, 0x4]
    ldr     r0, =0x80000008
    str     r0, [r1, 0x8]
    ldr     r0, [r1, 0x8]
@@Return:
    pop     r0
    bx      r0
    .pool


f43C5C:
    push    r4-r7, r14
    mov     r7, 0x0
    ldr     r0, =CurrSpriteData
    ldrh    r5, [r0, 0x14]
    ldr     r2, =PrimarySpriteStats
    ldrb    r1, [r0, 0x1D]
    lsl     r0, r1, 3
    add     r0, r0, r1
    lsl     r0, r0, 1
    add     r0, r0, r2
    ldrh    r0, [r0]
    ldr     r4, =BossWork
    ldrh    r1, [r4, 2]
    cmp     r1, 1
    beq     @@f43CC0
    cmp     r1, 1
    bgt     @@f43C90
    cmp     r1, 0
    beq     @@f43C96
    b       @@f43CF2
    .pool
@@f43C90:
    cmp     r1, 2
    beq     @@f43CDC
    b       @@f43CF2
@@f43C96:
    ldr     r6, =NettoriPal
    ldr     r1, =0x40000D4
    str     r6, [r1]
    ldr     r0, =0x5000300
    str     r0, [r1, 0x4]
    ldr     r0, =0x80000008
    str     r0, [r1, 0x8]
    ldr     r0, [r1, 0x8]
    ldrh    r0, [r4, 2]
    add     r0, 0x1
    strh    r0, [r4, 2]
    b       @@f43CF2
    .pool
@@f43CC0:
    mov     r1, 3
    ldr     r3, =DivideUnsigned+1
    bl      WRapperR3
    lsl     r0, r0, 0x10
    lsr     r0, r0, 0x10
    cmp     r5, r0
    bhi     @@f43CF2
    ldr     r6, =Pal36A480
    mov     r0, 2
    strh    r0, [r4, 2]
    b       @@f43CF6
    .pool
@@f43CDC:
    mov     r1, 6
    ldr     r3, =DivideUnsigned+1
    bl      WRapperR3
    lsl     r0, r0, 0x10
    lsr     r0, r0, 0x10
    cmp     r5, r0
    bhi     @@f43CF2
    ldr     r6, =Pal36A4A0
    mov     r0, 3
    strh    r0, [r4, 2]
    mov     r7, 1
@@f43CF2:
    cmp     r7, 0
    beq     @@Return
@@f43CF6:
    ldr     r1, =0x40000D4
    str     r6, [r1]
    ldr     r0, =0x5000300
    str     r0, [r1, 0x4]
    ldr     r0, =0x80000010
    str     r0, [r1, 0x8]
    ldr     r0, [r1, 0x8]
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
    .pool

NettoriInit:    ;43d1c
    push    r4-r7, r14
    mov     r4, r8
    mov     r5, r9
    push    r4-r5
    add     sp, -0xC
    ldr     r6, =CurrSpriteData
    mov     r0, 3
    bl      SetnCheckEvent
    lsl     r0, r0, 0x18
    lsr     r7, r0, 0x18
    cmp     r7, 0
    beq     @@f43D44
    mov     r0, 0
    strh    r0, [r6]
    b       @@Return
    .pool
@@f43D44:
    ldr     r1, =SpawnNewSecondarySprite+1
    mov     r9, r1
    ldr     r1, =BossWork
    ldrh    r0, [r1, 2] ;boss work 1
    strh    r7, [r0]
    ldrh    r0, [r1, 4] ;boss work 2
    strb    r7, [r0]
    ldrh    r0, [r1, 6] ;boss work 3
    mov     r0, 0x10
    strh    r0, [r1]
    ldr     r2, =PrimarySpriteStats
    ldrb    r1, [r6, 0x1D]
    lsl     r0, r1, 3
    add     r0, r0, r1
    lsl     r0, r0, 1
    add     r0, r0, r2
    ldrh    r0, [r0]
    mov     r1, 0x0
    strh    r0, [r6, 0x14]  ;health
    mov     r0, r6
    add     r0, 0x25    ;samus collision
    mov     r2, 0x4
    strb    r2, [r0]
    mov     r3, r6
    add     r3, 0x27    ;Draw distance top offset
    mov     r0, 0x60
    strb    r0, [r3]
    mov     r0, r6
    add     r0, 0x28
    strb    r1, [r0]
    add     r3, 0x2
    mov     r0, 0x20
    strb    r0, [r3]
    ldr     r0, =0xFE90
    strh    r0, [r6, 0xA]   ;Hitbox top offset
    strh    r7, [r6, 0xC]
    ldr     r0, =0xFFC0
    strh    r0, [r6, 0xE]
    mov     r0, 0x10
    strh    r0, [r6, 0x10]
    mov     r0, r6
    mov     r2, 1
    add     r0, 0x24    ;pose
    strb    r2, [r0]
    add     r0, 0xA     ;work variable
    strb    r1, [r0]
    ldr     r0, =NettoriOAM0
    str     r0, [r6, 0x18]
    strb    r1, [r6, 0x1C]
    strh    r7, [r6, 0x16]
    mov     r1, r6
    add     r1, 0x22    ;Draw order
    mov     r0, 0x6
    strb    r0, [r1]
    ldrh    r0, [r6, 0x4]   ;x
    add     r0, 0x20
    strh    r0, [r6, 0x4]
    ldrh    r4, [r6, 0x2]   ;y
    ldrh    r5, [r6, 0x4]
    ldrb    r2, [r6, 0x1F]  ;Spriteset graphics slot
    mov     r0, 0x23        ;Primary sprite RAM slot
    add     r0, r0, r6
    mov     r8, r0
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x0
    bl      WRapperR9
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x1
    bl      WRapperR9
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x2
    bl      WRapperR9
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x3
    bl      WRapperR9   
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x4
    bl      WRapperR9
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x5
    bl      WRapperR9
    ldrb    r2, [r6, 0x1F]
    mov     r0, r8
    ldrb    r3, [r0]
    str     r4, [sp]
    str     r5, [sp, 0x4]
    str     r7, [sp, 0x8]
    mov     r0, NettoriPartSpriteID
    mov     r1, 0x6
    bl      WRapperR9
    ldr     r0, =LockDoors
    mov     r1, 1
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

NettoriWait:
    push    r14
    ldr     r2, =CurrSpriteData
    ldrh    r0, [r2]
    mov     r1, 2
    and     r1, r0
    cmp     r1, 0
    beq     @@Return
    add     r2, 0x24
    mov     r0, 2
    strb    r0, [r2]
    ldr     r3, =PlayMusic+1
.notice "Netorri song 1"
.notice tohex(.)
    mov     r0, NettoriPhase1Music
    mov     r1, 0
    bl      WRapperR3
@@Return:
    pop     r0
    bx      r0
.pool

NettoriIdle:    ;43E70
    push    r4, r14
    ldr     r0, =CurrSpriteData
    mov     r2, r0
    add     r2, 0x2E    ;work variable
    ldrb    r2, [r2]
    mov     r3, r0
    cmp     r2, 0
    beq     @@f43EA0
    ldr     r1, [r3, 0x18]
    ldr     r0, =NettoriOAM0
    cmp     r1, r0
    bne     @@f43EB0
    ldr     r0, =NettoriOAM1
    str     r0, [r3, 0x18]
    mov     r0, 0
    strb    r0, [r3, 0x1C]
    strh    r0, [r3, 0x16]
    b       @@f43EB0
   .pool
@@f43EA0:
    ldr     r1, [r3, 0x18]
    ldr     r0, =NettoriOAM1
    cmp     r1, r0
    bne     @@f43EB0
    ldr     r0, =NettoriOAM0
    str     r0, [r3, 0x18]
    strb    r2, [r3, 0x1C]
    strh    r2, [r3, 0x16]
@@f43EB0:
    ldrh    r0, [r3, 0x14]
    cmp     r0, 0
    bne     @@Return
    mov     r1, r3
    add     r1, 0x24
    mov     r0, 0x45
    strb    r0, [r1]
@@Return:
    pop     r4
    pop     r0
    bx      r0

NettoriDeathInit:   ;43f24
    push    r4, r14
    ldr     r3, =CurrSpriteData
    mov     r1, r3
    add     r1, 0x24    ;pose
    mov     r0, 0x46
    strb    r0, [r1]
    ldrh    r1, [r3]    ;status
    ldr     r0, =0x8020
    orr     r0, r1
    strh    r0, [r3]
    mov     r0, r3
    add     r0, 0x25    ;samus collision
    mov     r2, 0
    strb    r2, [r0]
    add     r0, 7       ;Timer 1
    mov     r1, 0x60
    strb    r1, [r0]
    mov     r0, 0x2C
    strh    r0, [r3, 6]
    bl      NettoriCCAA

    mov     r3, 0x0
    ldr     r4, =SpriteData
@@f43EC2:
    lsl     r0, r3, 3
    sub     r0, r0, r3
    lsl     r0, r0, 3
    add     r2, r0, r4
    ldrh    r1, [r2]
    mov     r0, 0x1
    and     r0, r1
    cmp     r0, 0x0
    beq     @@f43F14
    mov     r0, r2
    add     r0, 0x32    ;prop
    ldrb    r1, [r0]
    mov     r0, 0x80
    and     r0, r1
    cmp     r0, 0x0
    bne     @@isSecondary
    ldrb    r0, [r2, 0x1D]
    cmp     r0, SamusEaterBudSpriteID
    beq     @@isSamusEaster
    cmp     r0, SamusEaterSpriteID
    beq     @@isSamusEaster
    b       @@f43F14
@@isSamusEaster:
    mov     r1, r2
    add     r1, 0x24    ;pose
    mov     r0, 0x45
    strb    r0, [r1]
    b       @@f43F14
    .pool
@@isSecondary:
    ldrb    r0, [r2, 0x1D]
    cmp     r0, SamusEaterProjectileSpriteID
    beq     @@isNettoriSubSprite
    cmp     r0, NettoriBeamSpriteID
    beq     @@isNettoriSubSprite
    b       @@f43F14
@@isNettoriSubSprite:
    mov     r0, 0
    strh    r0, [r2]
@@f43F14:
    add     r0, r3, 1
    lsl     r0, r0, 0x18
    lsr     r3, r0, 0x18
    cmp     r3, 0x17
    bls     @@f43EC2
    pop     r4
    pop     r0
    bx      r0
    .pool

NettoriDeath:   ;43F60
    push    r4, r14
	ldr     r4, =CurrSpriteData
    mov     r0, r4
    add     r0, 0x2C
    ldrb    r1, [r0]
    sub     r1, 1
    strb    r1, [r0]
    cmp     r1, 0
    beq     @@Death
    mov     r0, 7
    and     r0, r1
    cmp     r0, 0
    bne     @@Return
    ldr     r3, =SpriteRNG
    ldrb    r3, [r3]
    ldrh    r0, [r4, 2]
    ldrh    r1, [r4, 4]
    lsl     r3, r3, 2
    sub     r1, r3
    lsl     r2, r3, 2
    add     r3, r2
    sub     r0, r3
    mov     r2, 0x22
    ldr     r3, =SetParticleEffect+1
    bl      WRapperR3
    b       @@Return
@@Death:
	mov		r0, 29h
	str		r0,[sp]
	mov		r0,0h
	mov		r3,0x27
	ldrh	r2,[r1,4h]
	ldrh	r1,[r1,2h]
    sub     r1, 0xC0
	ldr		r4, =DeathRoutine + 1		
	bl		WrapperR4 	
	ldr		r1,=UnlockDoors
	mov		r0,1h
	strb	r0,[r1]				;opens doors
	mov		r0,1
	bl		SetnCheckEvent
    mov     r0, 0xB    ;boss kill
    mov     r1, 0
    ldr     r3, =PlayMusic+1
    bl      WRapperR3
@@Return:
    pop     r4
    pop     r0
    bx      r0
    .pool

NettoriMainAI:
    push    r4, r14
    ldr     r4, =CurrSpriteData
    mov     r0, r4
    add     r0, 0x24    ;pose
    ldrb    r0, [r0]
    cmp     r0, 1
    beq     @@pose1
    cmp     r0, 2
    beq     @@f45000
    cmp     r0, 2
    bgt     @@f44FF0
    cmp     r0, 0
    beq     @@f44FFA
    b       @@CheckHealth
@@f44FF0:
    cmp     r0, 0x45
    beq     @@f45006
    cmp     r0, 0x61
    bgt     @@f45006
    cmp     r0, 0x46
    beq     @@f4500A
    b       @@CheckHealth
@@f44FFA:
    bl      NettoriInit
    b       @@CheckHealth
@@pose1:
    bl      NettoriWait
    b       @@Return
@@f45000:
    bl      NettoriIdle
    b       @@CheckHealth
@@f45006:
    bl      NettoriDeathInit
@@f4500A:
    bl      NettoriDeath
@@CheckHealth:
    ldr     r0, =PrimarySpriteStats
    ldrb    r1, [r4, 0x1D]
    lsl     r2, r1, 3
    add     r1, r2
    lsl     r1, r1, 1
    add     r0, r1
    ldrh    r0, [r0]
    lsr     r0, r0, 1
    ldrh    r1, [r4, 0x14]  ;health
    cmp     r1, r0
    bcc     @@f45030
    bl      f43BC4
    b       @@Return
@@f45030:
    bl      f43C5C
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool