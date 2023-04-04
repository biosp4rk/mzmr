
.notice "MegaX Shell AI"
.notice tohex(.)
CoreXShell_Varia_AI:
    push    r4-r7,r14
    mov     r7,r8
    push    r7
    add     sp,-0x10
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x23
    ldrb    r0,[r0]
    mov     r8,r0
    ldr     r1,=SecondarySpriteStats
    ldrb    r0,[r2,0x1D]
    lsl     r3,r0,4
	lsl		r0,r0,1
	add		r0,r3,r0
    add     r0,r0,r1
    ldrh    r6,[r0]
    mov     r4,r2
    add     r4,0x24
    ldrb    r3,[r4]
    mov     r5,r2
    cmp     r3,0
    beq     @@_8058198
    cmp     r3,0x18
    bne     @@_8058206
    mov     r1,r5
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldr     r0,=CheckEndOfSpriteAnim_Curr + 1
	bl		WrapperR0
    cmp     r0,0
    bne     @@_805818A
    b       @@_80584FC
@@_805818A:
	mov		r0,20h
	str     r0,[sp] 
	mov		r0,0
	mov		r3,0
	ldrh	r1,[r4,2h]
	ldrh	r2,[r4,4h]
	ldr		r4,=SpriteDeath + 1
	bl		WrapperR4
    b       @@_80584FC
    .pool
@@_8058198:
    ldrh    r1,[r5]
    mov     r2,0x80
    lsl     r2,r2,8
    mov     r0,r2
    mov     r2,0
    orr     r0,r1
    strh    r0,[r5]
    mov     r1,r5
    add     r1,0x35
    mov     r0,1
    strb    r0,[r1]
    sub     r1,0x13
    mov     r0,5
    strb    r0,[r1]
    ldr     r0,=BackupOfIORegisters
    ldrb    r1,[r0,0xA]
    mov     r0,3
    and     r0,r1
    mov     r1,r5
    add     r1,0x21
    strb    r0,[r1]
    strh    r6,[r5,0x14]
    mov     r0,r5
    add     r0,0x27
    mov     r1,0x30
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r1,=0xFFB0
    strh    r1,[r5,0xA]
    mov     r0,0x50
    strh    r0,[r5,0xC]
    strh    r1,[r5,0xE]
    strh    r0,[r5,0x10]
    ldr     r0,=CoreXOAM_0
    str     r0,[r5,0x18]
    strb    r2,[r5,0x1C]
    strh    r3,[r5,0x16]
    mov     r0,r5
    add     r0,0x25
    strb    r2,[r0]
    mov     r0,2
    strb    r0,[r4]
    ldrh    r0,[r5]
    ldr     r3,=0x4008
    mov     r1,r3
    orr     r0,r1
    strh    r0,[r5]
    mov     r0,0x10
    strh    r0,[r5,0x12]
    mov     r0,r5
    add     r0,0x2A
    strb    r2,[r0]
@@_8058206:
    ldr     r2,=SpriteData
    mov     r0,r8
    lsl     r3,r0,3
    sub     r0,r3,r0
    lsl     r0,r0,3
    add     r0,r0,r2
    ldrh    r1,[r0,2]
    strh    r1,[r5,2]
    ldrh    r1,[r0,4]
    strh    r1,[r5,4]
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,0x37
    mov     r12,r2
    mov     r7,r3
    cmp     r0,9
    bls     @@_805822A
    b       @@_80584FC
@@_805822A:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@_8058274,@@_805827E,@@_80584FC,@@_80584FC
    .dw @@_80582A0,@@_80584FC,@@_80584FC,@@_80584FC
    .dw @@_8058300,@@_8058310
@@_8058274:
    mov     r1,r5
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    b       @@_80584FC
@@_805827E:
    mov     r1,r5
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldrh    r1,[r5]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r5]
    mov     r1,r8
    sub     r0,r7,r1
    lsl     r0,r0,3
    add     r0,r12
    ldrh    r0,[r0,0x12]
    strh    r0,[r5,0x12]
    b       @@_80584FC
    .pool
@@_80582A0:
    mov     r1,r5
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    mov     r2,r8
    sub     r0,r7,r2
    lsl     r0,r0,3
    add     r0,r12
    ldrh    r0,[r0,0x12]
    strh    r0,[r5,0x12]
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    mov     r0,0x80
    lsl     r0,r0,1
    cmp     r1,r0
    bhi     @@_80582E0
    ldrh    r1,[r5]
    ldr     r0,=0xBFF7
    and     r0,r1
    strh    r0,[r5]
    mov     r0,r5
    add     r0,0x27
    mov     r1,0x18
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    b       @@_80584FC
    .pool
@@_80582E0:
    ldr     r0,=0x17F
    cmp     r1,r0
    bls     @@_80582E8
    b       @@_80584FC
@@_80582E8:
    mov     r1,r5
    add     r1,0x27
    mov     r0,0x22
    strb    r0,[r1]
    add     r1,1
    strb    r0,[r1]
    add     r1,1
    strb    r0,[r1]
    b       @@_80584FC
    .pool
@@_8058300:
    ldrh    r0,[r5]
    ldr     r1,=0x7FFF
    and     r1,r0
    strh    r1,[r5]
    mov     r1,r5
    add     r1,0x25
    mov     r0,0x4
    strb    r0,[r1]
@@_8058310:
    ldrh    r4,[r5,0x14]
    cmp     r4,0
    bne     @@_805834C
    mov     r0,r5
    add     r0,0x25
    strb    r4,[r0]
    ldr     r0,=MegaXOAM_7
    str     r0,[r5,0x18]
    strb    r4,[r5,0x1C]
    strh    r4,[r5,0x16]
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x18
    strb    r0,[r1]
    mov     r3,r8
    sub     r0,r7,r3
    lsl     r0,r0,3
    add     r0,r12
    add     r0,0x24
    mov     r1,0x5C
    strb    r1,[r0]
    mov     r0,0xC1
    ldr     r1,=PlaySound + 1	;shell breaking?
	bl		WrapperR1
    b       @@_80584FC
    .pool
@@_805834C:
    mov     r0,r6
    mov     r1,3
    ldr     r2,=Divide_Unsigned + 1
	bl		WrapperR2
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    cmp     r4,r0
    bhi     @@_805836C
    ldr     r0,=CoreXOAM_2
    str     r0,[r5,0x18]
    mov     r1,r5
    add     r1,0x35
    mov     r0,3
    b       @@_8058384
    .pool
@@_805836C:
    ldrh    r4,[r5,0x14]
    lsl     r0,r6,1
    mov     r1,3
    ldr     r2,=Divide_Signed + 1
	bl		WrapperR2
    cmp     r4,r0
    bgt     @@_8058386
    ldr     r0,=CoreXOAM_1
    str     r0,[r5,0x18]
    mov     r1,r5
    add     r1,0x35
    mov     r0,2
@@_8058384:
    strb    r0,[r1]
@@_8058386:
    mov     r6,r5
    mov     r0,r6
    add     r0,0x2B
    ldrb    r0,[r0]
    mov     r1,0x7F
    and     r1,r0
    cmp     r1,1
    bne     @@_80583CC
    mov     r0,0x1B		;small energy
    ldr     r1,=CountPrimarySprites + 1
	bl		WrapperR1
    mov		r4,r0
	mov     r0,0x1C		;missile
    ldr     r1,=CountPrimarySprites + 1
	bl		WrapperR1
	add		r4,r4,r0
    cmp     r4,5
    bhi     @@_8058482
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
	ldr		r2,=CurrSpriteData
	mov		r1,0h
	ldrh	r3,[r2,4h]
	str		r3,[sp]
	ldrh	r3,[r2,2h]
	mov		r2,0h
	str		r2,[sp,4h]
	ldr		r4,=SpawnNewPrimarySprite + 1		;spawn drop when shot
	bl		WrapperR4
    b       @@_8058482
    .pool
@@_80583CC:
    cmp     r1,0x10
    bne     @@_8058482
    mov     r0,0xB9
	lsl		r0,r0,1		;hurt sound
    ldr     r1,=PlaySound + 1
	bl		WrapperR1
    mov     r2,r5
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]
    ldr     r1,=SpriteData
    mov     r2,r8
    sub     r0,r7,r2
    lsl     r0,r0,3
    add     r3,r0,r1
    mov     r1,r3
    add     r1,0x2D
    mov     r0,0xB4
    strb    r0,[r1]
    ldrh    r1,[r5,2]
    ldr     r0,=SamusData
    ldrh    r0,[r0,0x14]
    sub     r0,0x40
    cmp     r1,r0
    ble     @@_8058414
    ldrh    r1,[r3]
    mov     r2,0x80
    lsl     r2,r2,3
    mov     r0,r2
    orr     r0,r1
    b       @@_805841A
    .pool
@@_8058414:
    ldrh    r1,[r3]
    ldr     r0,=0xFBFF
    and     r0,r1
@@_805841A:
    strh    r0,[r3]
    ldr     r0,=CurrSpriteData
    ldr     r1,=SamusData
    ldrh    r0,[r0,4]
    ldrh    r1,[r1,0x12]
    cmp     r0,r1
    bls     @@_8058450
    ldr     r0,=SpriteData
    mov     r3,r8
    sub     r1,r7,r3
    lsl     r1,r1,3
    add     r1,r1,r0
    ldrh    r2,[r1]
    mov     r3,0x80
    lsl     r3,r3,2
    mov     r0,r3
    orr     r0,r2
    b       @@_8058460
    .pool
@@_8058450:
    ldr     r0,=SpriteData
    mov     r2,r8
    sub     r1,r7,r2
    lsl     r1,r1,3
    add     r1,r1,r0
    ldrh    r2,[r1]
    ldr     r0,=0xFDFF
    and     r0,r2
@@_8058460:
    strh    r0,[r1]
    ldr     r1,=SpriteData
    mov     r3,r8
    sub     r0,r7,r3
    lsl     r0,r0,3
    add     r2,r0,r1
    mov     r0,r2
    add     r0,0x2F
    mov     r1,0x28
    strb    r1,[r0]
    sub     r0,3
    strb    r1,[r0]
    add     r0,2
    mov     r1,0x1C
    strb    r1,[r0]
    add     r0,8
    strb    r1,[r0]
@@_8058482:
    ldr     r1,=SpriteData
    mov     r2,r8
    sub     r0,r7,r2
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x2D
    ldrb    r4,[r0]
    mov     r12,r1
    cmp     r4,0
    beq     @@_80584FC
    mov     r0,3
    and     r0,r4
    cmp     r0,0
    bne     @@_80584D2
    mov     r0,4
    and     r4,r0
    lsl     r0,r4,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_80584CC
    ldr     r0,=CurrSpriteData
    mov     r1,r0
    add     r1,0x35
    ldrb    r1,[r1]
    ldrb    r3,[r0,0x1F]
    add     r1,r1,r3
    mov     r2,0xE
    sub     r2,r2,r1
    add     r0,0x20
    strb    r2,[r0]
    b       @@_80584D2
    .pool
@@_80584CC:
    ldr     r0,=CurrSpriteData
    add     r0,0x20
    strb    r1,[r0]
@@_80584D2:
    mov     r1,r8
    sub     r0,r7,r1
    lsl     r0,r0,3
    add     r0,r12
    add     r0,0x2D
    ldrb    r1,[r0]
    sub     r1,1
    strb    r1,[r0]
    lsl     r1,r1,0x18
    lsr     r4,r1,0x18
    cmp     r4,0
    bne     @@_80584FC
    ldr     r1,=CurrSpriteData
    mov     r3,r1
    add     r3,0x32
    ldrb    r2,[r3]
    mov     r0,0xBF
    and     r0,r2
    strb    r0,[r3]
    add     r1,0x20
    strb    r4,[r1]
@@_80584FC:
    add     sp,0x10
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
    .pool