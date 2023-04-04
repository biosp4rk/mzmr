;Sprite ram replacements
;2f = 2f
;30 = 2C
;31 = 2D
;2e = 2e

MegaXKillOrbs:
    push    r4,r14
    mov     r3,0
    ldr     r4,=SpriteData
@@_8057496:
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r2,r0,r4
    ldrh    r1,[r2]
    mov     r0,1
    and     r0,r1
    cmp     r0,0
    beq     @@_80574C6
    mov     r0,r2
    add     r0,0x32
    ldrb    r1,[r0]
    mov     r0,0x80
    and     r0,r1
    cmp     r0,0
    beq     @@_80574C6
    ldrb    r0,[r2,0x1D]
    cmp     r0,MegaXOrbID
    bne     @@_80574C6
    ldrh    r0,[r2,0x14]
    cmp     r0,0
    beq     @@_80574C6
    mov     r0,0
    strh    r0,[r2,0x14]
@@_80574C6:
    add     r0,r3,1
    lsl     r0,r0,0x18
    lsr     r3,r0,0x18
    cmp     r3,0x17
    bls     @@_8057496
    pop     r4
    pop     r0
    bx      r0
    .pool
	
MegaXUpdatePal:
    push    r4-r7,r14
    mov     r6,0
    ldr     r0,=CurrSpriteData
    ldrh    r5,[r0,0x14]
    ldr     r1,=SecondarySpriteStats
    ldrb    r0,[r0,0x1D]
    lsl     r2,r0,4
	lsl		r0,r0,1
	add		r0,r2,r0
    add     r0,r0,r1
    ldrh    r0,[r0]
    ldr     r4,=BossWork
    ldrb    r1,[r4]
    cmp     r1,0
    beq     @@_8057438
    cmp     r1,1
    beq     @@_8057450
    b       @@_8057466
    .pool
@@_8057438:
    lsl     r0,r0,1
    mov     r1,3
    ldr     r2,=Divide_Signed + 1
	bl		WrapperR2
    cmp     r5,r0
    bgt     @@_8057466
    ldr     r7,=MegaXPal + 0xA0	;second pal
    mov     r0,1
    strb    r0,[r4]
    b       @@_805746A
    .pool
@@_8057450:
    mov     r1,3
    ldr     r2,=Divide_Unsigned + 1
	bl		WrapperR2
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    cmp     r5,r0
    bhi     @@_8057466
    ldr     r7,=MegaXPal + 0xC0	;third pal
    mov     r0,2
    strb    r0,[r4]
    mov     r6,1
@@_8057466:
    cmp     r6,0
    beq     @@_8057478
@@_805746A:
    ldr     r1,=0x40000D4
    str     r7,[r1]
    ldr     r0,=0x5000380
    str     r0,[r1,4]
    ldr     r0,=0x80000010
    str     r0,[r1,8]
    ldr     r0,[r1,8]
@@_8057478:
    pop     r4-r7
    pop     r0
    bx      r0
    .pool

.notice "MegaX AI"
.notice tohex(.)
MegaX_AI:
    push    r4-r7,r14
    mov     r7,r8
    push    r7
	add		sp,-8
    ldr     r0,=CurrSpriteData
    mov     r1,r0
    add     r1,0x23
    ldrb    r7,[r1]
    mov     r5,r0
    add     r5,0x24
    ldrb    r3,[r5]
    mov     r4,r0
    cmp     r3,0
    beq     @@_8057E38
    cmp     r3,0x18
    bne     @@_8057EB0
    mov     r1,r4
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldrh    r0,[r4]
    mov     r1,4
    eor     r0,r1
    strh    r0,[r4]
    mov     r1,r4
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    cmp     r2,0
    beq     @@_8057E1A
    b       @@_805813E
@@_8057E1A:
    ldr     r0,=SpriteData
    lsl     r1,r7,3
    sub     r1,r1,r7
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    mov     r0,0x3D
    strb    r0,[r1]
    strh    r2,[r4]
    b       @@_805813E
    .pool
@@_8057E38:
    ldrh    r1,[r4]
    mov     r2,0x80
    lsl     r2,r2,8
    mov     r0,r2
    orr     r0,r1
    strh    r0,[r4]
    mov     r1,r4
    add     r1,0x35
    mov     r0,4
    strb    r0,[r1]
    sub     r1,0x13
    mov     r0,3
    strb    r0,[r1]
    ldr     r1,=BackupOfIORegisters
    ldrb    r1,[r1,0xA]
    and     r0,r1
    mov     r1,r4
    add     r1,0x21
    strb    r0,[r1]
    ldr     r1,=SecondarySpriteStats
    ldrb    r0,[r4,0x1D]
    lsl     r2,r0,4
	lsl		r0,r0,1
	add		r0,r2,r0
    add     r0,r0,r1
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    mov     r0,r4
    add     r0,0x27
    mov     r1,0x30
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r1,=0xFF70
    strh    r1,[r4,0xA]
    mov     r0,0x90
    strh    r0,[r4,0xC]
    strh    r1,[r4,0xE]
    strh    r0,[r4,0x10]
    ldr     r0,=CoreXOAM_3
    str     r0,[r4,0x18]
	mov		r2,0
    strb    r2,[r4,0x1C]
    strh    r3,[r4,0x16]
    mov     r1,r4
    add     r1,0x25
    mov     r0,0x4
    strb    r0,[r1]
    mov     r0,2
    strb    r0,[r5]
    ldrh    r0,[r4]
    ldr     r3,=0x4008
    mov     r1,r3
    orr     r0,r1
    strh    r0,[r4]
    mov     r0,0x10
    strh    r0,[r4,0x12]
    mov     r0,r4
    add     r0,0x2A
    strb    r2,[r0]
@@_8057EB0:
    ldr     r2,=SpriteData
    lsl     r3,r7,3
    sub     r0,r3,r7
    lsl     r0,r0,3
    add     r0,r0,r2
    ldrh    r1,[r0,2]
    strh    r1,[r4,2]
    ldrh    r1,[r0,4]
    strh    r1,[r4,4]
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,0x37
    mov     r8,r2
    mov     r6,r3
    cmp     r0,4
    bls     @@_8057ED2
    b       @@_805813A
@@_8057ED2:
    lsl     r0,r0,2
    ldr     r1,=@@_8057EF8
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_8057EF8:
    .dw @@_8057F0C,@@_8057F16,@@_8057FE4,@@_8057FEC
    .dw @@_8057F38
@@_8057F0C:
    mov     r1,r4
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    b       @@_805813A
@@_8057F16:
    mov     r1,r4
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldrh    r1,[r4]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r4]
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    ldrh    r0,[r0,0x12]
    strh    r0,[r4,0x12]
    b       @@_805813A
    .pool
@@_8057F38:
    mov     r1,r4
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldr     r0,=FrameCounter8Bit
    ldrb    r1,[r0]
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    bne     @@_8057F6C
    mov     r0,4
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_8057F66
    mov     r0,r4
    add     r0,0x35
    ldrb    r0,[r0]
    ldrb    r1,[r4,0x1F]
    add     r0,r0,r1
    mov     r1,0xE
    sub     r1,r1,r0
@@_8057F66:
    mov     r0,r4
    add     r0,0x20
    strb    r1,[r0]
@@_8057F6C:
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    ldrh    r0,[r0,0x12]
    strh    r0,[r4,0x12]
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    mov     r0,0x80
    lsl     r0,r0,1
    cmp     r1,r0
    bhi     @@_8057FC4
    mov     r0,r4
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    add     r0,1
    strb    r2,[r0]
    add     r0,1
    strb    r2,[r0]
    ldrh    r1,[r4]
    ldr     r0,=0xBFF7
    and     r0,r1
    strh    r0,[r4]
    mov     r0,r4
    add     r0,0x24
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x3C
    strb    r0,[r1]
    sub     r1,0xE
    mov     r0,0
    strb    r0,[r1]
    ldrh    r0,[r4,2]
    add     r0,0x18
    ldrh    r1,[r4,4]
    mov     r2,0x1F
    ldr     r4,=SetParticleEffect + 1
	bl		WrapperR4
    b       @@_805813A
    .pool
@@_8057FC4:
    ldr     r0,=0x17F
    cmp     r1,r0
    bls     @@_8057FCC
    b       @@_805813A
@@_8057FCC:
    mov     r1,r4
    add     r1,0x27
    mov     r0,0x22
    strb    r0,[r1]
    add     r1,1
    strb    r0,[r1]
    add     r1,1
    strb    r0,[r1]
    b       @@_805813A
    .pool
@@_8057FE4:
    ldrh    r1,[r4]
    ldr     r0,=0x7FFF
    and     r0,r1
    strh    r0,[r4]
@@_8057FEC:
    mov     r0,r4
    add     r0,0x2B
    ldrb    r1,[r0]
    mov     r0,0x7F
    and     r0,r1
    cmp     r0,0x10
    beq     @@Hurt
	cmp		r0,4
	bne		@@jump
	mov     r0,0x1B		;small energy
    ldr     r1,=CountPrimarySprites + 1
	bl		WrapperR1
    mov		r4,r0
	mov     r0,0x1C		;missile
    ldr     r1,=CountPrimarySprites + 1
	bl		WrapperR1
	add		r4,r4,r0
    cmp     r4,5
    bhi     @@jump
    ldr		r0,=SpriteRNG
	ldrb	r0,[r0]
	mov		r1,1
	and		r0,r1
	cmp		r0,1
	beq		@@SmallNRG
	mov		r0,0x1C	;missile drop id
	b 		@@SpawnDrop
@@SmallNRG:
	mov		r0,0x1B	;small energy id
@@SpawnDrop:
	ldr		r4,=CurrSpriteData
	mov		r1,0h
	ldrh	r3,[r4,4h]
	str		r3,[sp]
	ldrh	r3,[r4,2h]
	mov		r2,0h
	str		r2,[sp,4h]
	ldr		r4,=SpawnNewPrimarySprite + 1		;spawn drop when shot
	bl		WrapperR4
@@jump:
	b 		@@_80580DC
@@Hurt:
    ldr		r0,=0x171			;hurt sound
    ldr     r1,=PlaySound + 1
	bl		WrapperR1
    mov     r2,r4
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    mov     r3,0
    orr     r0,r1
    strb    r0,[r2]
    ldr     r0,=CoreXOAM_4
    str     r0,[r4,0x18]
    strb    r3,[r4,0x1C]
    mov     r2,0
    mov     r12,r2
    strh    r3,[r4,0x16]
    ldrh    r0,[r4,0x14]
    cmp     r0,0
    bne     @@_805804C
    mov     r0,r4
    add     r0,0x25
    mov     r3,r12
    strb    r3,[r0]
    ldr     r1,=SpriteData
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    mov     r1,0x3B
    strb    r1,[r0]
    bl      MegaXKillOrbs
    b       @@_805813E
    .pool
@@_805804C:
    ldr     r3,=SpriteData
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r5,r0,r3
    mov     r1,r5
    add     r1,0x2D
    mov     r0,0x3C
    strb    r0,[r1]
    ldrh    r2,[r4,2]
    ldr     r1,=SamusData
    ldrh    r0,[r1,0x14]
    sub     r0,0x40
    mov     r8,r3
    mov     r3,r1
    cmp     r2,r0
    ble     @@_8058080
    ldrh    r0,[r5]
    mov     r2,0x80
    lsl     r2,r2,3
    mov     r1,r2
    orr     r0,r1
    b       @@_8058086
    .pool
@@_8058080:
    ldrh    r1,[r5]
    ldr     r0,=0xFBFF
    and     r0,r1
@@_8058086:
    strh    r0,[r5]
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,4]
    mov     r4,r1
    ldrh    r3,[r3,0x12]
    cmp     r0,r3
    bls     @@_80580B0
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    ldrh    r2,[r0]
    mov     r3,0x80
    lsl     r3,r3,2
    mov     r1,r3
    orr     r1,r2
    b       @@_80580BC
    .pool
@@_80580B0:
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    ldrh    r2,[r0]
    ldr     r1,=0xFDFF
    and     r1,r2
@@_80580BC:
    strh    r1,[r0]
    sub     r0,r6,r7
    lsl     r0,r0,3
    mov     r1,r8
    add     r2,r0,r1
    mov     r0,r2
    add     r0,0x2F
    mov     r1,0x50
    strb    r1,[r0]
    sub     r0,3
    strb    r1,[r0]
    add     r0,2
    mov     r1,0x38
    strb    r1,[r0]
    add     r0,8
    strb    r1,[r0]
@@_80580DC:
	ldr		r4,=CurrSpriteData
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    add     r0,0x2D
    ldrb    r1,[r0]
    cmp     r1,0
    beq     @@_805813A
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    bne     @@_8058112
    mov     r0,4
    and     r1,r0
    lsl     r0,r1,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_805810C
    mov     r0,r4
    add     r0,0x35
    ldrb    r0,[r0]
    ldrb    r2,[r4,0x1F]
    add     r0,r0,r2
    mov     r1,0xE
    sub     r1,r1,r0
@@_805810C:
    mov     r0,r4
    add     r0,0x20
    strb    r1,[r0]
@@_8058112:
    sub     r0,r6,r7
    lsl     r0,r0,3
    add     r0,r8
    add     r0,0x2D
    ldrb    r1,[r0]
    sub     r1,1
    strb    r1,[r0]
    lsl     r1,r1,0x18
    lsr     r3,r1,0x18
    cmp     r3,0
    bne     @@_805813A
    mov     r2,r4
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0xBF
    and     r0,r1
    strb    r0,[r2]
    mov     r0,r4
    add     r0,0x20
    strb    r3,[r0]
@@_805813A:
    bl      MegaXUpdatePal
@@_805813E:
	add		sp,8
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
    .pool