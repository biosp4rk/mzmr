BOXSplash:
	push	r4-r6,r14
	mov		r5,r0 		
	ldr		r4,=SubSpriteData
	ldrh	r1,[r4,6]
	ldrh	r2,[r4,8]
	add		r2,0x40
	mov		r3,0
	ldr		r6,=SpriteCheckOutOfRoomEffect + 1
	bl		WrapperR6
	cmp		r0,0
	bne		@@Splashes
	mov		r0,r5
	ldrh	r1,[r4,6]
	ldrh	r2,[r4,8]
	sub		r2,0x80
	mov		r3,0
	ldr		r6,=SpriteCheckInRoomEffect + 1
	bl		WrapperR6
	cmp		r0,0
	beq		@@Return
@@Splashes:
	ldrh	r0,[r4,6]		;makes two more big splashes
	ldrh	r1,[r4,8]
	sub		r1,0x40
	mov		r3,3		;med splash
	ldr		r6,=SetSpriteSplashEffect + 1
	bl		WrapperR6
	ldrh	r0,[r4,6]
	ldrh	r1,[r4,8]
	add		r1,0x80
	mov		r3,3		;med splash
	bl		WrapperR6
@@Return:
	pop		r4-r6
	pop		r0
	bx		r0


Box2_Movement:		;8051A14
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    lsl     r0,r0,0x10
    lsr     r7,r0,0x10
    mov     r10,r7
    lsl     r1,r1,0x18
    lsr     r5,r1,0x18
    mov     r9,r5
    mov     r0,0
    mov     r8,r0
    ldr     r6,=CurrSpriteData
    ldrh    r1,[r6]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051A72
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    sub     r0,0x10
    ldrh    r1,[r4,8]
    add     r1,0x6E
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldr     r0,=PrevCollisionCheck1
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051A6C
    mov     r0,r6
    add     r0,0x24
    strb    r5,[r0]
    mov     r1,1
    mov     r8,r1
    b       @@_8051AA8
    .pool
@@_8051A6C:
    ldrh    r0,[r4,8]
    add     r0,r7,r0
    b       @@_8051AA6
@@_8051A72:
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    sub     r0,0x10
    ldrh    r1,[r4,8]
    sub     r1,0x6E
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldr     r0,=PrevCollisionCheck1
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051AA0
    mov     r0,r6
    add     r0,0x24
    mov     r1,r9
    strb    r1,[r0]
    mov     r0,1
    mov     r8,r0
    b       @@_8051AA8
    .pool
@@_8051AA0:
    ldrh    r0,[r4,8]
    mov     r1,r10
    sub     r0,r0,r1
@@_8051AA6:
    strh    r0,[r4,8]
@@_8051AA8:
    mov     r0,r8
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r1
    bx      r1

Box2_Initialize:
    push    r4-r7,r14
    add     sp,-0xC
    mov		r0,3
	bl		SetnCheckEvent
	cmp		r0,0
    beq     @@_8051ADC
    ldr     r1,=CurrSpriteData
    mov     r0,0
    strh    r0,[r1]
    b       @_8051C82
    .pool
@@_8051ADC:
	ldr		r0,=DoorUnlockTimer
	mov		r1,1
	strb	r1,[r0]		;lock doors
	mov		r7,0
    ldr     r6,=CurrSpriteData
    mov     r0,r6
    add     r0,0x25
    strb    r7,[r0]
    ldrh    r0,[r6]
    mov     r1,0x80
    lsl     r1,r1,8
    mov     r3,r1
    mov     r5,0
    orr     r3,r0
    strh    r3,[r6]
    mov     r0,r6
    add     r0,0x27
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r0,=0xFFD8
    strh    r0,[r6,0xA]
    mov     r0,0x40
    strh    r0,[r6,0xC]
    ldr     r0,=0xFFD0
    strh    r0,[r6,0xE]
    mov     r0,0x30
    strh    r0,[r6,0x10]
    mov     r0,r6
    add     r0,0x2D
    mov     r1,7
    strb    r1,[r0]
    mov     r2,r6
    add     r2,0x22
    mov     r0,0xC
    strb    r0,[r2]
    add     r2,0x13
    mov     r0,2
    strb    r0,[r2]
    strb    r1,[r6,0x1E]
    ldr     r2,=PrimarySpriteStats
    ldrb    r1,[r6,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r6,0x14]
    mov     r2,r6
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]
    ldr     r0,=BoxOAM_30
    str     r0,[r6,0x18]
    strb    r5,[r6,0x1C]
    strh    r7,[r6,0x16]
    ldr     r4,=SubSpriteData
    ldrh    r0,[r6,2]
    strh    r0,[r4,6]
    ldrh    r0,[r6,4]
    strh    r0,[r4,8]
    ldr     r0,=BOXPartPosOffsets_0
    str     r0,[r4]
    strb    r5,[r4,0xC]
    strh    r7,[r4,4]
    strb    r5,[r4,0xE]
    mov     r0,r6
    add     r0,0x2F
    strb    r5,[r0]
    ldr     r0,=0xFDFF
    and     r3,r0
    strh    r3,[r6]
    mov     r1,r6
    add     r1,0x24
    mov     r0,0x17
    strb    r0,[r1]
    ldrb    r2,[r6,0x1F]
    mov     r5,r6
    add     r5,0x23
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    str     r7,[sp,8]
BoxPart1:
    mov     r0,BoxPartID
    mov     r1,0
    ldr     r7,=SpawnSecondarySprite + 1
	bl		WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart2:
    mov     r0,BoxPartID
    mov     r1,1
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart3:
    mov     r0,BoxPartID
    mov     r1,2
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart4:
    mov     r0,BoxPartID
    mov     r1,3
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart5:
    mov     r0,BoxPartID
    mov     r1,4
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart6:
    mov     r0,BoxPartID
    mov     r1,5
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart7:
    mov     r0,BoxPartID
    mov     r1,6
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart8:
    mov     r0,BoxPartID
    mov     r1,8
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart9:
    mov     r0,BoxPartID
    mov     r1,9
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
	mov		r0,0
    str     r0,[sp,8]
BoxPart10:
    mov     r0,BoxPartID
    mov     r1,0xA
    bl      WrapperR7
    ldrb    r2,[r6,0x1F]
    ldrb    r3,[r5]
    ldrh    r0,[r4,6]
    str     r0,[sp]
    ldrh    r0,[r4,8]
    str     r0,[sp,4]
    mov		r0,0
    str     r0,[sp,8]
BoxPart11:
    mov     r0,BoxPartID
    mov     r1,0xB
    bl      WrapperR7
@_8051C82:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
 .pool

Box2_WaitingToRunStart:		;51CAC
    push    r14
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_8
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    mov     r3,0
    strh    r0,[r1,4]
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,0x24
    mov     r1,0x18
    strb    r1,[r2]
    add     r0,0x2E
    strb    r3,[r0]
    ldr     r0,=0x26A
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r0
    bx      r0
    .pool
	
Box2_WaitingToRun:	;51CE4
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8051D08
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,0x2E
    ldrb    r0,[r2]
    add     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,1
    bne     @@_8051D08
    add     r1,0x24
    mov     r0,0x19
    strb    r0,[r1]
@@_8051D08:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051D1A
    add     r1,0x24
    mov     r0,0x3B
    strb    r0,[r1]
@@_8051D1A:
    pop     r0
    bx      r0
    .pool

Box2_SlowRunningStart:	;51D24
    push    r14
    ldr     r1,=MakeSpriteFaceSamusDirection + 1
	bl		WrapperR1
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051D4C
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_5
    b       @@_8051D50
    .pool
@@_8051D4C:
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_2
@@_8051D50:
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    mov     r3,0
    strh    r0,[r1,4]
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,0x24
    mov     r1,0x1A
    strb    r1,[r2]
    add     r0,0x2E
    strb    r3,[r0]
    pop     r0
    bx      r0
    .pool

Box2_SlowRunning:	;51D78
    push    r4,r5,r14
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,4]
	ldrb	r1,[r4,0xC]
	lsl		r1,r1,10h
	orr		r0,r1
    ldr     r1,=0xFFFFFF
    and     r0,r1
    ldr     r1,=0x10003
    cmp     r0,r1
    bne     @@_8051DCE
    ldr     r0,=0x271
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051DC0
    ldrh    r0,[r4,6]
    sub     r0,0x28
    ldrh    r1,[r4,8]
    add     r1,0x78
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8051DCE
    .pool
@@_8051DC0:
    ldrh    r0,[r4,6]
    sub     r0,0x28
    ldrh    r1,[r4,8]
    sub     r1,0x78
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@_8051DCE:
    ldr     r5,=CurrSpriteData
    mov     r4,r5
    add     r4,0x2E
    ldrb    r0,[r4]
    mov     r1,0x37
    bl      Box2_Movement
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_8051E12
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8051E00
    ldrb    r0,[r4]
    add     r0,1
    strb    r0,[r4]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,7
    bne     @@_8051E00
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x1B
    strb    r0,[r1]
@@_8051E00:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051E12
    add     r1,0x24
    mov     r0,0x3B
    strb    r0,[r1]
@@_8051E12:
    pop     r4,r5
    pop     r0
    bx      r0
    .pool

Box2_FastRunningStart:		;51E1C
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051E40
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_6
    b       @@_8051E44
    .pool
@@_8051E40:
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_3
@@_8051E44:
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    strh    r0,[r1,4]
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x1C
    strb    r0,[r1]
    add     r1,0xA
    mov     r0,0xA
    strb    r0,[r1]
    pop     r0
    bx      r0
    .pool

Box2_FastRunning:		;51E68
    push    r4,r14
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,4]
	ldrb	r1,[r4,0xC]
	lsl		r1,r1,0x10
	orr		r0,r1
    ldr     r1,=0xFFFFFF
    and     r0,r1
    ldr     r1,=0x10003
    cmp     r0,r1
    bne     @@_8051EBE
    ldr     r0,=0x271
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051EB0
    ldrh    r0,[r4,6]
    sub     r0,0x3C
    ldrh    r1,[r4,8]
    add     r1,0xA0
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8051EBE
    .pool
@@_8051EB0:
    ldrh    r0,[r4,6]
    sub     r0,0x3C
    ldrh    r1,[r4,8]
    sub     r1,0xA0
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@_8051EBE:
    mov     r0,8
    mov     r1,0x37
    bl      Box2_Movement
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_8051F1A
    ldr     r2,=CurrSpriteData
    mov     r1,r2
    add     r1,0x2E
    ldrb    r0,[r1]
    cmp     r0,0
    beq     @@_8051EE0
    sub     r0,1
    b       @@_8051F2A
    .pool
@@_8051EE0:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051F04
    ldr     r0,=SubSpriteData
    ldrh    r0,[r0,8]
    sub     r0,0xC8
    ldr     r1,=SamusData
    ldrh    r1,[r1,0x12]
    cmp     r0,r1
    ble     @@_8051F1A
    b       @@_8051F12
    .pool
@@_8051F04:
    ldr     r0,=SubSpriteData
    ldrh    r0,[r0,8]
    add     r0,0xC8
    ldr     r1,=SamusData
    ldrh    r1,[r1,0x12]
    cmp     r0,r1
    bge     @@_8051F1A
@@_8051F12:
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x1D
    strb    r0,[r1]
@@_8051F1A:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051F2C
    add     r1,0x24
    mov     r0,0x3B
@@_8051F2A:
    strb    r0,[r1]
@@_8051F2C:
    pop     r4
    pop     r0
    bx      r0
    .pool

Box2_SkiddingStart:		;51F40
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8051F64
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_11
    b       @@_8051F68
    .pool
@@_8051F64:
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_9
@@_8051F68:
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    strh    r0,[r1,4]
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x1E
    strb    r0,[r1]
    add     r1,0xA
    mov     r0,0x20
    strb    r0,[r1]
    ldr     r0,=0x261		;skidding
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r0
    bx      r0

Box2_Skidding:		;51F94
    push    r4,r5,r14
    ldr     r4,=CurrSpriteData
    mov     r5,r4
    add     r5,0x2E
    ldrb    r0,[r5]
    lsr     r0,r0,2
    mov     r1,0x1F
    cmp     r0,5
    bls     @@_8051FA8
    mov     r1,0x37
@@_8051FA8:
    bl      Box2_Movement
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_8051FD8
    ldrb    r0,[r5]
    sub     r0,1
    strb    r0,[r5]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_8051FC6
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1F
    strb    r0,[r1]
@@_8051FC6:
    mov     r0,r4
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8051FD8
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x3B
    strb    r0,[r1]
@@_8051FD8:
    pop     r4,r5
    pop     r0
    bx      r0
    .pool

Box2_StoppedSkiddingStart:		;51FE4
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8052008
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_12
    b       @@_805200C
    .pool
@@_8052008:
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_10
@@_805200C:
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    strh    r0,[r1,4]
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x20
    strb    r0,[r1]
    pop     r0
    bx      r0
    .pool

Box2_StoppedSkidding:		;52028
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8052048
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,0x24
    mov     r0,0x3B
    strb    r0,[r2]
    add     r1,0x2F
    mov     r0,3
    b       @@_8052058
    .pool
@@_8052048:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_805205A
    add     r1,0x24
    mov     r0,0x3B
@@_8052058:
    strb    r0,[r1]
@@_805205A:
    pop     r0
    bx      r0
    .pool

Box2_BonkingStart:		;52064
    push    r14
    ldr     r1,=SubSpriteData
    ldrh    r0,[r1,6]
    sub     r0,0x10
    mov     r3,0
    mov     r2,0
    strh    r0,[r1,6]
    ldr     r0,=BOXPartPosOffsets_16
    str     r0,[r1]
    strb    r3,[r1,0xC]
    strh    r2,[r1,4]
    ldr     r2,=CurrSpriteData
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x38
    strb    r0,[r1]
    mov     r0,r2
    add     r0,0x2C		;was 31
    strb    r3,[r0]
    ldrh    r0,[r2]
    mov     r3,0x80
    lsl     r3,r3,2
    mov     r1,r3
    eor     r0,r1
    strh    r0,[r2]
    ldr     r0,=0x18E
    ldr     r1,=PlaySound1 + 1	;bonk?
	bl		WrapperR1
    mov     r0,0x14
    mov     r1,0x81
    ldr     r2,=StartHorizontalScreenShake + 1
	bl		WrapperR2
    pop     r0
    bx      r0
    .pool
	
Box2_Bonking:		;520B8
    push    r4-r7,r14
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    ldr     r2,=CheckVerticalCollisionAtPositionSlopes + 1
	bl		WrapperR2
    mov     r1,r0
    ldr     r0,=PrevCollisionCheck1
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_80520E8
    strh    r1,[r4,6]
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x4B
    strb    r1,[r0]
    b       @@_80521A0
    .pool
@@_80520E8:
    ldr     r6,=CurrSpriteData
    mov     r0,0x2C		;31
    add     r0,r0,r6
    mov     r12,r0
    ldrb    r2,[r0]
    ldr     r5,=BOXBonkTable
    lsl     r0,r2,1
    add     r0,r0,r5
    ldrh    r3,[r0]
    mov     r7,0
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@_8052120
    sub     r1,r2,1
    lsl     r1,r1,1
    add     r1,r1,r5
    ldrh    r0,[r4,6]
    ldrh    r1,[r1]
    add     r2,r0,r1
    strh    r2,[r4,6]
	bl		BOXSplash
    b       @@_805217A
    .pool
@@_8052120:
    add     r0,r2,1
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    mov     r0,r12
    strb    r2,[r0]
	mov		r5,r2
    ldrh    r0,[r4,6]
    add     r1,r0,r3
    strh    r1,[r4,6]
	bl		BOXSplash
    cmp     r5,0x10
    bne     @@_805217A
    ldrh    r1,[r6]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_805215E
    ldrh    r0,[r4,6]
    sub     r0,0x34
    ldrh    r1,[r4,8]
    sub     r1,0x40
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldrh    r0,[r4,6]
    sub     r0,0x34
    ldrh    r1,[r4,8]
    add     r1,0x80
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_805217A
@@_805215E:
    ldrh    r0,[r4,6]
    sub     r0,0x34
    ldrh    r1,[r4,8]
    sub     r1,0x80
    mov     r2,0x37
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldrh    r0,[r4,6]
    sub     r0,0x34
    ldrh    r1,[r4,8]
    add     r1,0x40
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@_805217A:
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8052198
    ldr     r1,=SubSpriteData
    ldrh    r0,[r1,8]
    add     r0,6
    b       @@_805219E
    .pool
@@_8052198:
    ldr     r1,=SubSpriteData
    ldrh    r0,[r1,8]
    sub     r0,6
@@_805219E:
    strh    r0,[r1,8]
@@_80521A0:
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
Box2_LandingFromBonkStart:	;521AC
    push    r14
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_17
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    mov     r2,0
    strh    r0,[r1,4]
    ldr     r3,=CurrSpriteData
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x4C
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2F
    strb    r2,[r0]
    sub     r0,3
    strb    r2,[r0]
    ldr     r0,=0x26F
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r0
    bx      r0
    .pool
	
Box2_LandingFromBonk:		;521EC
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8052240
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8052220
    ldr     r1,=SamusData
    ldrh    r0,[r2,4]
    ldrh    r1,[r1,0x12]
    cmp     r0,r1
    bls     @@_8052238
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x3B
    b       @@_805223E
    .pool
@@_8052220:
    ldr     r1,=SamusData
    ldrh    r0,[r2,4]
    ldrh    r1,[r1,0x12]
    cmp     r0,r1
    bcs     @@_8052238
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x3B
    b       @@_805223E
    .pool
@@_8052238:
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x17
@@_805223E:
    strb    r0,[r1]
@@_8052240:
    pop     r0
    bx      r0
	
Box2_LandingStart:		;52244
    push    r14
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_17
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    mov     r3,0
    strh    r0,[r1,4]
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,0x24
    mov     r1,0x3A
    strb    r1,[r2]
    add     r0,0x2C		;31
    strb    r3,[r0]
    ldr     r0,=0x26F
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r0
    bx      r0
    .pool
	
Box2_Landing:			;5227C
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_80522B0
    ldr     r1,=CurrSpriteData
    mov     r3,r1
    add     r3,0x2F
    ldrb    r0,[r3]
    cmp     r0,0
    bne     @@_805229C
    add     r1,0x24
    mov     r0,0x27
    b       @@_80522AE
    .pool
@@_805229C:
    sub     r0,1
    strb    r0,[r3]
    mov     r2,0x7F
    and     r2,r0
    cmp     r2,0
    bne     @@_80522AA
    strb    r2,[r3]
@@_80522AA:
    add     r1,0x24
    mov     r0,0x3B
@@_80522AE:
    strb    r0,[r1]
@@_80522B0:
    pop     r0
    bx      r0
	
Box2_FinishedCrawlingStart:		;522B4
    push    r4,r14
    ldr     r2,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_7
    str     r0,[r2]
    ldr     r1,=CurrSpriteData
    mov     r0,0x2E
    add     r0,r0,r1
    mov     r12,r0
    mov     r3,0
    mov     r0,2
    mov     r4,r12
    strb    r0,[r4]
    strb    r3,[r2,0xC]
    strh    r3,[r2,4]
    add     r1,0x24
    mov     r0,8
    strb    r0,[r1]
    mov     r0,0x99
    lsl     r0,r0,2 ;?
    ldr     r1,= PlaySound1 + 1
	bl		WrapperR1
    pop     r4
    pop     r0
    bx      r0
    .pool
	
Box2_FinishedCrawling:		;522F0
    push    r4,r5,r14
    ldr     r4,=CurrSpriteData
    mov     r5,r4
    add     r5,0x2E
    ldrb    r0,[r5]
    cmp     r0,1
    bls     @@_8052314
    ldr     r1,=CheckEndSubspriteAnim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8052346
    ldrb    r0,[r5]
    sub     r0,1
    strb    r0,[r5]
    b       @@_8052346
    .pool
@@_8052314:
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_8052346
    bl      CheckSamusOnLedge
    cmp     r0,0
    beq     @@_805232C
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x3B
    b       @@_8052344
@@_805232C:
    mov     r0,r4
    add     r0,0x2F
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_805233E
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x3B
    b       @@_8052344
@@_805233E:
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x19
@@_8052344:
    strb    r0,[r1]
@@_8052346:
    pop     r4,r5
    pop     r0
    bx      r0

Box2_WaitingToJumpStart:		;5234C
    push    r4,r14
    ldr     r0,=SamusData
    ldrh    r4,[r0,0x12]
    ldr     r0,=SubSpriteData
    ldrh    r2,[r0,8]
    mov     r1,r2
    sub     r1,0x78
    mov     r3,r0
    cmp     r1,r4
    bge     @@_8052378
    mov     r0,r2
    add     r0,0x78
    cmp     r0,r4
    ble     @@_8052378
    bl      Box2_StoppingToFireMissileStart
    b       @@_805238A
    .pool
@@_8052378:
    ldr     r0,=BOXBlankOAM_2
    str     r0,[r3]
    mov     r0,0
    strb    r0,[r3,0xC]
    strh    r0,[r3,4]
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x3C
    strb    r1,[r0]
@@_805238A:
    pop     r4
    pop     r0
    bx      r0
    .pool
	
Box2_WaitingToJump:		;52398
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_80523AA
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x3D
    strb    r1,[r0]
@@_80523AA:
    pop     r0
    bx      r0
    .pool
	
Box2_JumpingStart:		;523B4
    push    r4-r7,r14
    mov     r7,r8
    push    r7
    mov     r5,0
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_16
    str     r0,[r1]
    strb    r5,[r1,0xC]
    mov     r2,0
    strh    r5,[r1,4]
    ldr     r3,=CurrSpriteData
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x3E
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2C	
    strb    r2,[r0]
    add     r0,3	
    ldrb    r1,[r0]
    mov     r0,0x80
    and     r0,r1
    cmp     r0,0
    bne     @@_80524B2
	bl		CheckSamusOnLedge
    cmp     r0,0
    beq     @@_8052400
    ldr     r1,=MakeSpriteFaceSamusDirection + 1
    b       @@_8052404
    .pool
@@_8052400:
    ldr     r1,=MakeSpriteFaceAwayFromSamusDirection + 1
@@_8052404:
	bl		WrapperR1
    ldr     r6,=CurrSpriteData
    ldrh    r1,[r6]
    mov     r0,0x80
    lsl     r0,r0,2
    mov     r8,r0
    and     r0,r1
    cmp     r0,0
    beq     @@_8052468
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    sub     r0,0x20
    ldrh    r1,[r4,8]
    mov     r2,0xAF
    lsl     r2,r2,1
    add     r1,r1,r2
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldr     r7,=PrevCollisionCheck1
    ldrb    r0,[r7]
    cmp     r0,0
    beq     @@_8052434
    add     r0,r5,1
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
@@_8052434:
    ldrh    r0,[r4,6]
    sub     r0,0x20
    ldrh    r1,[r4,8]
    add     r1,0x78
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldrb    r0,[r7]
    cmp     r0,0
    beq     @@_805244C
    add     r0,r5,1
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
@@_805244C:
    cmp     r5,0
    beq     @@_80524B2
    ldrh    r1,[r6]
    ldr     r0,=0xFDFF
    and     r0,r1
    b       @@_80524A8
    .pool
@@_8052468:
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    sub     r0,0x20
    ldrh    r1,[r4,8]
    ldr     r2,=0xFFFFFEA2
    add     r1,r1,r2
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldr     r7,=PrevCollisionCheck1
    ldrb    r0,[r7]
    cmp     r0,0
    beq     @@_8052486
    add     r0,r5,1
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
@@_8052486:
    ldrh    r0,[r4,6]
    sub     r0,0x20
    ldrh    r1,[r4,8]
    sub     r1,0x78
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldrb    r0,[r7]
    cmp     r0,0
    beq     @@_805249E
    add     r0,r5,1
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
@@_805249E:
    cmp     r5,0
    beq     @@_80524B2
    ldrh    r1,[r6]
    mov     r0,r8
    orr     r0,r1
@@_80524A8:
    strh    r0,[r6]
    mov     r1,r6
    add     r1,0x2F
    mov     r0,0x82
    strb    r0,[r1]
@@_80524B2:
    ldr     r0,=0x1C8
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
Box2_Jumping:		;524D4
    push    r4-r6,r14
    ldr     r3,=CurrSpriteData
    mov     r4,r3
    add     r4,0x2C
    ldrb    r2,[r4]
    ldr     r1,=BOXJumpingTable
    lsl     r0,r2,1
    add     r0,r0,r1
    ldrh    r5,[r0]
    mov     r6,0
    ldsh    r1,[r0,r6]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@_8052508
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x39
    strb    r0,[r1]
    b       @@_8052570
    .pool
@@_8052508:
    add     r0,r2,1
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    strb    r2,[r4]
    ldr     r4,=SubSpriteData
	mov		r6,r2
    ldrh    r0,[r4,6]
    add     r1,r0,r5
    strh    r1,[r4,6]
	bl		BOXSplash
    cmp     r6,0x17
    bne     @@_8052568
	ldr		r3,=CurrSpriteData
    ldrh    r1,[r3]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_805254C
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    sub     r1,0x40
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    add     r1,0x80
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8052568
    .pool
@@_805254C:
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    sub     r1,0x80
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    add     r1,0x40
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@_8052568:
    mov     r0,0xC
    mov     r1,0x37
    bl      Box2_Movement
@@_8052570:
    pop     r4-r6
    pop     r0
    bx      r0
	
Box2_StoppingToFireMissileStart:		;52578
    push    r4,r14
    ldr     r2,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_7
    str     r0,[r2]
    ldr     r1,=CurrSpriteData
    mov     r0,0x2E
    add     r0,r0,r1
    mov     r12,r0
    mov     r3,0
    mov     r0,3
    mov     r4,r12
    strb    r0,[r4]
    strb    r3,[r2,0xC]
    strh    r3,[r2,4]
    add     r1,0x24
    mov     r0,0x28
    strb    r0,[r1]
    ldr     r0,=0x270
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r4
    pop     r0
    bx      r0
    .pool
	
Box2_StoppingToFireMissile:		;525B4
    push    r4,r5,r14
    ldr     r5,=CurrSpriteData
    mov     r4,r5
    add     r4,0x2E
    ldrb    r0,[r4]
    cmp     r0,1
    bls     @@_80525D8
    ldr     r1,=CheckEndSubspriteAnim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_80525E8
    ldrb    r0,[r4]
    sub     r0,1
    strb    r0,[r4]
    b       @@_80525E8
    .pool
@@_80525D8:
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_80525E8
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x29
    strb    r0,[r1]
@@_80525E8:
    pop     r4,r5
    pop     r0
    bx      r0
	
Box2_LoweringToFireMissileStart:		;525F0
    push    r14
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_13
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    strh    r0,[r1,4]
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x2A
    strb    r1,[r0]
    mov     r0,0x9A
    lsl     r0,r0,2
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r0
    bx      r0
    .pool
	
Box2_LoweringToFireMissile:		;52620
    push    r14
    ldr     r1,=CheckEndSubspriteAnim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_805263E
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r2,0
    mov     r1,0x2C
    strb    r1,[r0]
    ldr     r0,=SubSpriteData
    ldr     r1,=BOXPartPosOffsets_14
    str     r1,[r0]
    strb    r2,[r0,0xC]
    strh    r2,[r0,4]
@@_805263E:
    pop     r0
    bx      r0
    .pool
	
Box2_FiringMissile:		;52650
    push    r4-r7,r14
    add     sp,-0xC
	ldr		r7,=SpawnSecondarySprite + 1
    ldr     r1,=CheckEndSubspriteAnim + 1
	bl		WrapperR1
    mov     r6,r0
    cmp     r6,0
    beq     @@_805268C
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r2,0
    mov     r1,0x2E
    strb    r1,[r0]
    ldr     r0,=SubSpriteData
    ldr     r1,=BOXPartPosOffsets_15
    str     r1,[r0]
    strb    r2,[r0,0xC]
    strh    r2,[r0,4]
    mov     r0,0xF8	;missile firing
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    b       @_805274C
    .pool
@@_805268C:
    ldr     r3,=CurrSpriteData
    ldrh    r4,[r3,2]
    ldrh    r5,[r3,4]
    ldr     r0,=SubSpriteData
    ldrh    r1,[r0,4]
	ldrb	r0,[r0,0xC]
	lsl		r0,r0,0x10
	orr		r1,r0
    ldr     r0,=0xFFFFFF
    and     r1,r0
    mov     r0,0x80
    lsl     r0,r0,0xC		
    cmp     r1,r0
    bne     @_80526D0
    ldrb    r2,[r3,0x1F]
    mov     r0,r3
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r0,r4
    sub     r0,0x8C
    str     r0,[sp]
    mov     r0,r5
    sub     r0,0x30
    str     r0,[sp,4]
    str     r6,[sp,8]
BoxMissile1:
    mov     r0,BoxMissileID
    mov     r1,0
    bl      WrapperR7
    b       @_805274C
    .pool
@_80526D0:
    ldr     r0,=0x80003
    cmp     r1,r0
    bne     @_80526FC
    ldrb    r2,[r3,0x1F]
    mov     r0,r3
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r0,r4
    sub     r0,0x90
    str     r0,[sp]
    mov     r0,r5
    sub     r0,0x18
    str     r0,[sp,4]
    str     r6,[sp,8]
BoxMissile2:
    mov     r0,BoxMissileID
    mov     r1,1
    bl      WrapperR7
    b       @_805274C
    .pool
@_80526FC:
    ldr     r0,=0x80006
    cmp     r1,r0
    bne     @_8052728
    ldrb    r2,[r3,0x1F]
    mov     r0,r3
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r0,r4
    sub     r0,0x90
    str     r0,[sp]
    mov     r0,r5
    add     r0,0x18
    str     r0,[sp,4]
    str     r6,[sp,8]
BoxMissile3:
    mov     r0,BoxMissileID
    mov     r1,2
    bl      WrapperR7
    b       @_805274C
    .pool
@_8052728:
    ldr     r0,=0x80009
    cmp     r1,r0
    bne     @_805274C
    ldrb    r2,[r3,0x1F]
    mov     r0,r3
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r0,r4
    sub     r0,0x8C
    str     r0,[sp]
    mov     r0,r5
    add     r0,0x30
    str     r0,[sp,4]
    str     r6,[sp,8]
BoxMissile4:
    mov     r0,BoxMissileID
    mov     r1,3
    bl      WrapperR7
@_805274C:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
    .pool

Box2_DoneFiringMissile:		;52758
    push    r14
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_805276A
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x17
    strb    r1,[r0]
@@_805276A:
    pop     r0
    bx      r0
    .pool

Box2_DyingStart:			;52774
    ldr     r0,=CurrSpriteData
    ldr     r1,=BoxOAM_30
    str     r1,[r0,0x18]
    mov     r2,0
    strb    r2,[r0,0x1C]
    mov     r3,0
    strh    r2,[r0,0x16]
    mov     r1,r0
    add     r1,0x2C		;31
    strb    r3,[r1]
    add     r0,0x24
    mov     r1,0x44
    strb    r1,[r0]
    ldr     r0,=SubSpriteData
    ldr     r1,=BOXPartPosOffsets_0
    str     r1,[r0]
    strb    r3,[r0,0xC]
    strh    r2,[r0,4]
    bx      r14
    .pool

Box2_Dying:		;527AC
    push    r4,r14
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,6]
    ldrh    r1,[r4,8]
    ldr     r2,=CheckVerticalCollisionAtPositionSlopes + 1
	bl		WrapperR2
    mov     r1,r0
    ldr     r0,=PrevCollisionCheck1
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_80527DC
    strh    r1,[r4,6]
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x45
    strb    r1,[r0]
    b       @@_80527E2
    .pool
@@_80527DC:
    ldrh    r0,[r4,6]
    add     r0,0x10
    strh    r0,[r4,6]
@@_80527E2:
    pop     r4
    pop     r0
    bx      r0

Box2_ExplodingStart:		;527E8
    ldr     r1,=CurrSpriteData
    ldr     r0,=BoxOAM_31
    str     r0,[r1,0x18]
    mov     r2,0
    strb    r2,[r1,0x1C]
    mov     r3,0
    strh    r2,[r1,0x16]
    add     r1,0x24
    mov     r0,0x46			;exploding
    strb    r0,[r1]
    ldr     r0,=SubSpriteData
    ldr     r1,=BOXPartPosOffsets_0
    str     r1,[r0]
    strb    r3,[r0,0xC]
    strh    r2,[r0,4]
    bx      r14
    .pool

Box2_Exploding:		;52818
    push    r4,r14
    ldr     r0,=FrameCounter8Bit
    ldrb    r0,[r0]
    mov     r2,7
    and     r2,r0
    ldr     r4,=CurrSpriteData
    cmp     r2,0
    bne     @@_8052842
    mov     r1,r4
    add     r1,0x20
    ldrb    r0,[r1]
    cmp     r0,0xC
    bne     @@_8052840
	mov		r0,r4
    add     r0,34h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r3,[r4,1Fh]
    add     r0,r0,r3
    mov     r3,0Eh
    sub     r3,r3,r0
	strb	r3,[r1]
    b       @@_8052842
    .pool
@@_8052840:
	mov		r2,0xC
    strb    r2,[r1]
@@_8052842:
    ldrh    r0,[r4,4]
    lsr     r0,r0,2
    ldr     r1,=BG1XPosition
    ldrh    r1,[r1]
    lsr     r1,r1,2
    sub     r0,r0,r1
    lsl     r0,r0,0x10
    ldr     r1,=0xFFE70000
    add     r0,r0,r1
    lsr     r0,r0,0x10
    cmp     r0,0xBE
    bhi     @@_805286A
    ldr     r1,=CheckNearEndOfSubSpriteData1Anim + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @@_805286A
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x47
    strb    r0,[r1]
@@_805286A:
    pop     r4
    pop     r0
    bx      r0
    .pool
	
Box2_CrawlingStart:		;52AE4
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8052B08
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_4
    b       @@_8052B0C
    .pool
@@_8052B08:
    ldr     r1,=SubSpriteData
    ldr     r0,=BOXPartPosOffsets_1
@@_8052B0C:
    str     r0,[r1]
    mov     r0,0
    strb    r0,[r1,0xC]
    strh    r0,[r1,4]
    mov     r1,r2
    add     r1,0x24
    mov     r0,2
    strb    r0,[r1]
    pop     r0
    bx      r0
    .pool
	
Box2_BrainRisingStart:		;52878
    push    r14
    ldr     r3,=CurrSpriteData
    ldr     r0,=BoxOAM_45
    str     r0,[r3,0x18]
    mov     r0,0
    strb    r0,[r3,0x1C]
    mov     r2,0
    strh    r0,[r3,0x16]
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x48
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x20
    strb    r2,[r0]
    add     r0,0xE
    strb    r2,[r0]
 ;   mov     r0,3
 ;   bl      SetEventBasedEffectBit7
    pop     r0
    bx      r0
    .pool

Box2_BrainRising:		;528AC
    push    r4-r6,r14
    add     sp,-0xC
    ldr     r0,=FrameCounter8Bit
    ldrb    r1,[r0]
    mov     r0,1
    and     r0,r1
    ldr     r2,=CurrSpriteData
    cmp     r0,0
    bne     @@_80528C6
    ldrh    r0,[r2]
    mov     r1,4
    eor     r0,r1
    strh    r0,[r2]
@@_80528C6:
    ldrh    r4,[r2,2]
    ldrh    r5,[r2,4]
    mov     r0,r2
    add     r0,0x2E
    ldrb    r0,[r0]
    cmp     r0,0x42
    bls     @@_80528D6
    b       @_8052AAC
@@_80528D6:
    lsl     r0,r0,2
    ldr     r1,=@@_80528EC
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_80528EC:
    .dw @@_80529F8,@_8052A44,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052A4C,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052A56,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052A66,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052A76,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052A80,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052AAC,@_8052AAC
    .dw @_8052AAC,@_8052AAC,@_8052A90
@@_80529F8:
    ldr     r0,=CurrSpriteData
    ldrb    r2,[r0,0x1F]
    add     r0,0x23
    ldrb    r3,[r0]
    str     r4,[sp]
    str     r5,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
BoxBrain1:
    mov     r0,BoxBrainID
    mov     r1,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    ldr     r2,=SpriteData
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r2
    add     r1,0x23
    strb    r0,[r1]
    mov     r0,r4
    add     r0,0x48
    mov     r1,r5
    mov     r2,0x21
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
 ;   ldr     r0,=0x26E
 ;  bl      0x8003B1C  ;play sound?
    b       @_8052AAC
    .pool
@_8052A44:
    mov     r1,r5
    add     r1,0x50
    mov     r0,r4
    b       @_8052A6E
@_8052A4C:
    mov     r0,r4
    add     r0,0x86
    mov     r1,r5
    add     r1,0x70
    b       @_8052A5E
@_8052A56:
    mov     r0,r4
    add     r0,0x86
    mov     r1,r5
    sub     r1,0x70
@_8052A5E:
    mov     r2,0x1E
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @_8052AAC
@_8052A66:
    mov     r0,r4
    add     r0,0x14
    mov     r1,r5
    sub     r1,0xA
@_8052A6E:
    mov     r2,0x21
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @_8052AAC
@_8052A76:
    mov     r0,r4
    add     r0,0x5C
    mov     r1,r5
    add     r1,0x90
    b       @_8052A88
@_8052A80:
    mov     r0,r4
    add     r0,0x5C
    mov     r1,r5
    sub     r1,0x90
@_8052A88:
    mov     r2,0x20
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @_8052AAC
@_8052A90:
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x49
    strb    r0,[r1]
    add     r1,0xA
    mov     r0,0x3C
    strb    r0,[r1]
    ldrh    r1,[r2]
    ldr     r3,=0x8004
    mov     r0,r3
    orr     r0,r1
    strh    r0,[r2]
    b       @_8052AB6
@_8052AAC:
    ldr     r1,=CurrSpriteData
    add     r1,0x2E
    ldrb    r0,[r1]
    add     r0,1
    strb    r0,[r1]
@_8052AB6:
    add     sp,0xC
    pop     r4-r6
    pop     r0
    bx      r0
    .pool	
	
Box2_BrainFloating:		;52AC4
    push    r14
    ldr     r2,=CurrSpriteData
    mov     r1,r2
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,0
    bne     @@_8052ADC
    strh    r0,[r2]
	ldr		r0,=DoorUnlockTimer
	mov		r1,0x3C
	neg		r1,r1
	strb	r1,[r0]
	mov		r0,1h
	bl		SetnCheckEvent
	mov		r0,0xB		;boss defeated song
	mov		r1,0
	ldr		r2,=PlaySong + 1
	;bl		WrapperR2
	nop 
	nop
@@_8052ADC:
    pop     r0
    bx      r0
    .pool		
	
Box2_Crawling:	
    push    r14
    mov     r0,1
    mov     r1,7
    bl      Box2_Movement
    pop     r0
    bx      r0	


CheckStartMusic:
	push	r14
	ldr		r2,=CurrSpriteData
	ldrh	r1,[r2]
	mov		r0,1
	and		r0,r1
	cmp		r0,0		;if sprite dead, skip
	beq		@@Return
	ldr		r0,=CurrentMusicTrack
	ldrh	r0,[r0]
	cmp		r0,BOXSong	;if BOX theme already playing, skip
	beq		@@Return
	mov		r0,2		;if not on screen, skip
	and		r0,r1
	cmp		r0,0h
	beq		@@Return
.notice "BOX Song---------"
.notice tohex(.)
	mov		r0,BOXSong
	mov		r1,0
	ldr		r2,=PlaySong + 1
	bl		WrapperR2
@@Return:
	pop		r0
	bx		r0

Box2_AI:	;
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x4C
    bls     @@_805398A
    b       @@_8053B90
@@_805398A:
    lsl     r0,r0,2
    ldr     r1,=@@_805399C
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_805399C:
    .dw @@_8053AD0,@@_8053AD6,@@_8053ADA,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B12
    .dw @@_8053B16,@@_8053B90,@@_8053B90,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053AE0
    .dw @@_8053AE4,@@_8053AEA,@@_8053AEE,@@_8053AF4
    .dw @@_8053AF8,@@_8053AFE,@@_8053B02,@@_8053B08
    .dw @@_8053B0C,@@_8053B90,@@_8053B90,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B4E
    .dw @@_8053B52,@@_8053B58,@@_8053B5C,@@_8053B90
    .dw @@_8053B62,@@_8053B90,@@_8053B68,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B1C
    .dw @@_8053B20,@@_8053B30,@@_8053B34,@@_8053B3A
    .dw @@_8053B3E,@@_8053B44,@@_8053B48,@@_8053B90
    .dw @@_8053B90,@@_8053B90,@@_8053B90,@@_8053B6E
    .dw @@_8053B72,@@_8053B78,@@_8053B7C,@@_8053B82
    .dw @@_8053B86,@@_8053B8C,@@_8053B90,@@_8053B26
    .dw @@_8053B2A
@@_8053AD0:
    bl      Box2_Initialize
    b       @@_8053B90
@@_8053AD6:
    bl      Box2_CrawlingStart
@@_8053ADA:
    bl      Box2_Crawling
    b       @@_8053B90
@@_8053AE0:
    bl      Box2_WaitingToRunStart
@@_8053AE4:
    bl      Box2_WaitingToRun
    b       @@_8053B90
@@_8053AEA:
    bl      Box2_SlowRunningStart
@@_8053AEE:
    bl      Box2_SlowRunning
    b       @@_8053B90
@@_8053AF4:
    bl      Box2_FastRunningStart
@@_8053AF8:
    bl      Box2_FastRunning
    b       @@_8053B90
@@_8053AFE:
    bl      Box2_SkiddingStart
@@_8053B02:
    bl      Box2_Skidding
    b       @@_8053B90
@@_8053B08:
    bl      Box2_StoppedSkiddingStart
@@_8053B0C:
    bl      Box2_StoppedSkidding
    b       @@_8053B90
@@_8053B12:
    bl      Box2_FinishedCrawlingStart
@@_8053B16:
    bl      Box2_FinishedCrawling
    b       @@_8053B90
@@_8053B1C:
    bl      Box2_BonkingStart
@@_8053B20:
    bl      Box2_Bonking
    b       @@_8053B90
@@_8053B26:
    bl      Box2_LandingFromBonkStart
@@_8053B2A:
    bl      Box2_LandingFromBonk
    b       @@_8053B90
@@_8053B30:
    bl      Box2_LandingStart
@@_8053B34:
    bl      Box2_Landing
    b       @@_8053B90
@@_8053B3A:
    bl      Box2_WaitingToJumpStart
@@_8053B3E:
    bl      Box2_WaitingToJump
    b       @@_8053B90
@@_8053B44:
    bl      Box2_JumpingStart
@@_8053B48:
    bl      Box2_Jumping
    b       @@_8053B90
@@_8053B4E:
    bl      Box2_StoppingToFireMissileStart
@@_8053B52:
    bl      Box2_StoppingToFireMissile
    b       @@_8053B90
@@_8053B58:
    bl      Box2_LoweringToFireMissileStart
@@_8053B5C:
    bl      Box2_LoweringToFireMissile
    b       @@_8053B90
@@_8053B62:
    bl      Box2_FiringMissile
    b       @@_8053B90
@@_8053B68:
    bl      Box2_DoneFiringMissile
    b       @@_8053B90
@@_8053B6E:
    bl      Box2_DyingStart
@@_8053B72:
    bl      Box2_Dying
    b       @@_8053B90
@@_8053B78:
    bl      Box2_ExplodingStart
@@_8053B7C:
    bl      Box2_Exploding
    b       @@_8053B90
@@_8053B82:
    bl      Box2_BrainRisingStart
@@_8053B86:
    bl      Box2_BrainRising
    b       @@_8053B90
@@_8053B8C:
    bl      Box2_BrainFloating
@@_8053B90:
	bl		CheckStartMusic
    ldr     r1,=UpdateSubspriteAnim + 1
	bl		WrapperR1
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    pop     r0
    bx      r0