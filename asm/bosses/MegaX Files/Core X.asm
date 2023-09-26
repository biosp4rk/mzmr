;Sprite ram replacements
;2f = 2f
;30 = 2C
;31 = 36
;2e = 2e

CoreXMovement:
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    add     sp,-0xC
    ldr     r4,[sp,0x2C]
    ldr     r5,[sp,0x30]
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    str     r0,[sp]
    lsl     r1,r1,0x10
    lsr     r6,r1,0x10
    mov     r8,r6
    lsl     r2,r2,0x18
    lsr     r2,r2,0x18
    str     r2,[sp,4]
    lsl     r3,r3,0x18
    lsr     r7,r3,0x18
    mov     r10,r7
    lsl     r4,r4,0x18
    lsr     r4,r4,0x18
    lsl     r5,r5,0x10
    lsr     r5,r5,0x10
    str     r5,[sp,8]
    mov     r0,0
    mov     r9,r0
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    lsl     r0,r0,0x10
    lsr     r3,r0,0x10
    cmp     r3,0
    beq     @@_80613FA
    mov     r1,0x2F
    add     r1,r1,r2
    mov     r12,r1
    ldrb    r0,[r1]
    cmp     r0,0
    bne     @@_80613E2
    ldrh    r1,[r2,4]
    sub     r0,r6,4
    cmp     r1,r0
    ble     @@_80613C8
    mov     r0,r2
    add     r0,0x2C
    ldrb    r0,[r0]
    mov     r3,r12
    strb    r0,[r3]
    b       @@_806147A
    .pool
@@_80613C8:
    mov     r1,r2
    add     r1,0x2C
    ldrb    r0,[r1]
    cmp     r0,r7
    bcs     @@_80613D6
    add     r0,1
    strb    r0,[r1]
@@_80613D6:
    ldrb    r0,[r1]
    asr     r0,r4
    ldrh    r6,[r2,4]
    add     r0,r0,r6
    strh    r0,[r2,4]
    b       @@_806147A
@@_80613E2:
    sub     r0,1
    mov     r1,r12
    strb    r0,[r1]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_8061480
    ldrb    r0,[r1]
    asr     r0,r4
    ldrh    r3,[r2,4]
    add     r0,r0,r3
    strh    r0,[r2,4]
    b       @@_806147A
@@_80613FA:
    mov     r6,0x2F
    add     r6,r6,r2
    mov     r12,r6
    ldrb    r0,[r6]
    mov     r5,r0
    cmp     r5,0
    bne     @@_8061448
    ldrh    r3,[r2,4]
    mov     r0,r8
    add     r0,4
    cmp     r3,r0
    bge     @@_806141C
    mov     r0,r2
    add     r0,0x2C
    ldrb    r0,[r0]
    strb    r0,[r6]
    b       @@_806147A
@@_806141C:
    mov     r1,r2
    add     r1,0x2C
    ldrb    r0,[r1]
    cmp     r0,r10
    bcs     @@_806142A
    add     r0,1
    strb    r0,[r1]
@@_806142A:
    ldrb    r0,[r1]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    sub     r1,r3,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0
    beq     @@_8061472
    mov     r0,1
    mov     r9,r0
    mov     r1,r12
    strb    r5,[r1]
    b       @@_806147A
@@_8061448:
    sub     r0,1
    mov     r6,r12
    strb    r0,[r6]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_8061476
    ldrb    r0,[r6]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldrh    r0,[r2,4]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0
    beq     @@_8061472
    mov     r0,1
    mov     r9,r0
    strb    r3,[r6]
    b       @@_806147A
@@_8061472:
    strh    r1,[r2,4]
    b       @@_806147A
@@_8061476:
    mov     r1,1
    mov     r9,r1
@@_806147A:
    mov     r3,r9
    cmp     r3,0
    beq     @@_806149A
@@_8061480:
    ldr     r2,=CurrSpriteData
    ldrh    r0,[r2]
    mov     r6,0x80
    lsl     r6,r6,2
    mov     r1,r6
    eor     r0,r1
    strh    r0,[r2]
    add     r2,0x2C
    mov     r0,1
    strb    r0,[r2]
    ldr     r0,[sp,8]
    ldr     r1,=PlaySoundIfNotPlaying + 1
	bl		WrapperR1
@@_806149A:
    mov     r0,0
    mov     r9,r0
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,3
    and     r0,r1
    lsl     r0,r0,0x10
    lsr     r3,r0,0x10
    cmp     r3,0
    beq     @@_8061506
    mov     r3,r2
    add     r3,0x2E
    ldrb    r0,[r3]
    cmp     r0,0
    bne     @@_80614F0
    ldrh    r1,[r2,2]
    ldr     r0,[sp]
    sub     r0,4
    cmp     r1,r0
    ble     @@_80614D4
    mov     r0,r2
    add     r0,0x36
    ldrb    r0,[r0]
    strb    r0,[r3]
    b       @@_8061588
    .pool
@@_80614D4:
    mov     r1,r2
    add     r1,0x36
    ldrb    r0,[r1]
    ldr     r3,[sp,4]
    cmp     r0,r3
    bcs     @@_80614E4
    add     r0,1
    strb    r0,[r1]
@@_80614E4:
    ldrb    r0,[r1]
    asr     r0,r4
    ldrh    r6,[r2,2]
    add     r0,r0,r6
    strh    r0,[r2,2]
    b       @@_8061588
@@_80614F0:
    sub     r0,1
    strb    r0,[r3]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_806158E
    ldrb    r0,[r3]
    asr     r0,r4
    ldrh    r1,[r2,2]
    add     r0,r0,r1
    strh    r0,[r2,2]
    b       @@_8061588
@@_8061506:
    mov     r6,0x2E
    add     r6,r6,r2
    mov     r12,r6
    ldrb    r0,[r6]
    mov     r5,r0
    cmp     r5,0
    bne     @@_8061556
    ldrh    r3,[r2,2]
    ldr     r0,[sp]
    add     r0,4
    cmp     r3,r0
    bge     @@_8061528
    mov     r0,r2
    add     r0,0x36
    ldrb    r0,[r0]
    strb    r0,[r6]
    b       @@_8061588
@@_8061528:
    mov     r1,r2
    add     r1,0x36
    ldrb    r0,[r1]
    ldr     r6,[sp,4]
    cmp     r0,r6
    bcs     @@_8061538
    add     r0,1
    strb    r0,[r1]
@@_8061538:
    ldrb    r0,[r1]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    sub     r1,r3,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0
    beq     @@_8061580
    mov     r0,1
    mov     r9,r0
    mov     r1,r12
    strb    r5,[r1]
    b       @@_8061588
@@_8061556:
    sub     r0,1
    mov     r6,r12
    strb    r0,[r6]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_8061584
    ldrb    r0,[r6]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldrh    r0,[r2,2]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0
    beq     @@_8061580
    mov     r0,1
    mov     r9,r0
    strb    r3,[r6]
    b       @@_8061588
@@_8061580:
    strh    r1,[r2,2]
    b       @@_8061588
@@_8061584:
    mov     r1,1
    mov     r9,r1
@@_8061588:
    mov     r3,r9
    cmp     r3,0
    beq     @@_80615A8
@@_806158E:
    ldrh    r0,[r2]
    mov     r6,0x80
    lsl     r6,r6,3
    mov     r1,r6
    eor     r0,r1
    strh    r0,[r2]
    mov     r1,r2
    add     r1,0x36
    mov     r0,1
    strb    r0,[r1]
    ldr     r0,[sp,8]
    ldr     r1,=PlaySoundIfNotPlaying + 1
	bl		WrapperR1
@@_80615A8:
    add     sp,0xC
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
.pool


CoreXMainInit:
    push    r4-r7,r14
    add     sp,-0xC
	mov		r0,3
	bl		SetnCheckEvent
	cmp		r0,1
	bne		@@_8057588
    ldr     r1,=CurrSpriteData
    mov     r0,0
    strh    r0,[r1]
    b       @_8057694
@@_8057588:
    ldr     r0,=DoorUnlockTimer
	mov		r1,1
	strb	r1,[r0]
	mov		r7,0x10
	mov		r6,0
    ldr     r0,=BossWork
    strb    r6,[r0]
    ldr     r5,=CurrSpriteData
    mov     r1,r5
    add     r1,0x26
    mov     r0,1
    strb    r0,[r1]
    ldr     r0,=0xFFFFFF00
    mov     r1,r0
    ldrh    r0,[r5,2]
    add     r1,r1,r0
    mov     r4,0
    strh    r1,[r5,2]
    ldrh    r0,[r5,4]
    sub     r0,0x80
    strh    r0,[r5,4]
    strh    r1,[r5,6]
    strh    r0,[r5,8]
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x37
    strb    r0,[r1]
	add		r1,0x12
	strb	r4,[r1]
    ldrh    r2,[r5]
    mov     r0,4
    orr     r2,r0
    orr     r2,r4
    strh    r2,[r5]
    ldr     r3,=PrimarySpriteStats
    ldrb    r1,[r5,0x1D]
    lsl     r0,r1,4
    lsl     r0,r0,1
	add		r0,r0,r1
    add     r0,r0,r3
    ldrh    r0,[r0]
    strh    r0,[r5,0x14]
    mov     r1,r5
    add     r1,0x22
    mov     r0,6
    strb    r0,[r1]
    ldr     r0,=BackupOfIORegisters
    ldrb    r1,[r0,0xA]
    mov     r0,3
    and     r0,r1
    mov     r1,r5
    add     r1,0x21
    strb    r0,[r1]
    mov     r0,r5
    add     r0,0x25
    strb    r4,[r0]
    mov     r1,0x80
    lsl     r1,r1,8
    mov     r0,r1
    orr     r2,r0
    strh    r2,[r5]
    mov     r0,r5
    add     r0,0x27
    strb    r7,[r0]
    add     r0,1
    strb    r7,[r0]
    add     r0,1
    strb    r7,[r0]
    ldr     r1,=0xFFE0
    strh    r1,[r5,0xA]
    mov     r0,0x20
    strh    r0,[r5,0xC]
    strh    r1,[r5,0xE]
    strh    r0,[r5,0x10]
    ldr     r0,=MegaXOAM_0
    str     r0,[r5,0x18]
    strb    r4,[r5,0x1C]
    strh    r6,[r5,0x16]
    mov     r0,r5
    add     r0,0x2A
    strb    r4,[r0]
    strh    r7,[r5,0x12]
    add     r0,3
    strb    r4,[r0]
    ldrb    r1,[r5,0x1E]
    ldrb    r2,[r5,0x1F]
    mov     r4,r5
    add     r4,0x23
    ldrb    r3,[r4]
    ldrh    r0,[r5,2]
    str     r0,[sp]
    ldrh    r0,[r5,4]
    str     r0,[sp,4]
    str     r6,[sp,8]
BIGX:
    mov     r0,MegaXID
    ldr     r7,=SpawnNewSecondarySprite + 1
	bl		WrapperR7
    ldrb    r1,[r5,0x1E]
    ldrb    r2,[r5,0x1F]
    ldrb    r3,[r4]
    ldrh    r0,[r5,2]
    str     r0,[sp]
    ldrh    r0,[r5,4]
    str     r0,[sp,4]
    str     r6,[sp,8]
CoreX:
    mov     r0,CoreXID
    bl      WrapperR7
@_8057694:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
CoreXMainCheckSpawnOrbs:
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r3,=CurrSpriteData
    mov     r0,0x36
    add     r0,r0,r3
    mov     r12,r0
    ldrb    r2,[r0]
    ldr     r6,=MegaXYTable
    lsl     r0,r2,1
    add     r0,r0,r6
    ldrh    r5,[r0]
    mov     r4,0
    ldsh    r1,[r0,r4]
    ldr     r0,=0x7FFF
    mov     r4,r3
    cmp     r1,r0
    bne     @@_8057730
    sub     r1,r2,1
    lsl     r1,r1,1
    add     r1,r1,r6
    ldrh    r0,[r4,2]
    ldrh    r1,[r1]
    add     r0,r0,r1
    b       @@_805773A
    .pool
@@_8057730:
    add     r0,r2,1
    mov     r7,r12
    strb    r0,[r7]
    ldrh    r0,[r4,2]
    add     r0,r0,r5
@@_805773A:
    strh    r0,[r4,2]
    mov     r6,r4
    add     r6,0x2C
    ldrb    r2,[r6]
    ldr     r5,=MegaXXTable
    lsl     r0,r2,1
    add     r0,r0,r5
    ldrh    r3,[r0]
    mov     r7,0
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@_805776C
    sub     r1,r2,1
    lsl     r1,r1,1
    add     r1,r1,r5
    ldrh    r0,[r4,4]
    ldrh    r1,[r1]
    add     r0,r0,r1
    b       @@_8057774
    .pool
@@_805776C:
    add     r0,r2,1
    strb    r0,[r6]
    ldrh    r0,[r4,4]
    add     r0,r0,r3
@@_8057774:
    strh    r0,[r4,4]
    mov     r1,r4
    mov     r3,r1
    add     r3,0x2E
    ldrb    r0,[r3]
    cmp     r0,0
    bne     @@_80577A4
    ldrh    r2,[r1,0x12]
    ldr     r0,=0x1FF
    cmp     r2,r0
    bhi     @@_8057798
    mov     r0,r2
    add     r0,0x10
    strh    r0,[r1,0x12]
    b       @_8057870
    .pool
@@_8057798:
    mov     r0,1
    strb    r0,[r3]
    add     r1,0x2F
    mov     r0,0x3C
    strb    r0,[r1]
    b       @_8057870
@@_80577A4:
    mov     r1,r4
    add     r1,0x2F
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
    cmp     r5,0
    bne     @_8057870
    sub     r1,0xB
    mov     r0,0x39
    strb    r0,[r1]
    ldrb    r2,[r4,0x1F]
    mov     r6,r4
    add     r6,0x23
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb1:
    mov     r0,MegaXOrbID
    mov     r1,0
    ldr     r7,=SpawnNewSecondarySprite + 1
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb2:
    mov     r0,MegaXOrbID
    mov     r1,1
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb3:
    mov     r0,MegaXOrbID
    mov     r1,2
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb4:
    mov     r0,MegaXOrbID
    mov     r1,3
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb5:
    mov     r0,MegaXOrbID
    mov     r1,4
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb6:
    mov     r0,MegaXOrbID
    mov     r1,5
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb7:
    mov     r0,MegaXOrbID
    mov     r1,6
	bl		WrapperR7
    ldrb    r2,[r4,0x1F]
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    str     r5,[sp,8]
XOrb8:
    mov     r0,MegaXOrbID
    mov     r1,7
	bl		WrapperR7
@_8057870:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0

CoreXMainCheckStartFight:
    push    r14
    mov     r1,0x80
    lsl     r1,r1,1
    mov     r0,r1
    ldr     r2,=CheckSamusNearSprite_LeftRight + 1
	bl		WrapperR2
    cmp     r0,0
    beq     @@_80576EA
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x2E
    mov     r1,0
    strb    r1,[r0]
    add     r0,2
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x38
    strb    r0,[r1]
.notice "MegaX Song"
.notice tohex(.)
    mov     r0,0x40
    mov     r1,0
    ldr     r2,=PlayMusic + 1
	bl		WrapperR2
@@_80576EA:
    pop     r0
    bx      r0
    .pool
	
CoreXMainSetMovePose:
    ldr     r3,=CurrSpriteData
    mov     r1,r3
    add     r1,0x24
    mov     r2,0
    mov     r0,0x3A
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2F
    strb    r2,[r0]
    sub     r0,3
    mov     r1,1
    strb    r1,[r0]
    add     r0,2
    strb    r2,[r0]
    add     r0,0xE
    strb    r1,[r0]
    bx      r14
    .pool
	
CoreXMainMoveMegaX:
    push    r14
    add     sp,-8
    ldr     r0,=FrameCounter8Bit
    ldrb    r1,[r0]
    mov     r0,0x80
    and     r0,r1
    cmp     r0,0
    beq     @@_80578C8
    ldr     r1,=SamusData
    ldr     r2,=0xFFFFFEC0
    mov     r0,r2
    ldrh    r2,[r1,0x14]
    add     r0,r0,r2
    b       @@_80578CE
    .pool
@@_80578C8:
    ldr     r1,=SamusData
    ldrh    r0,[r1,0x14]
    sub     r0,0x48
@@_80578CE:
    lsl     r0,r0,0x10
    lsr     r2,r0,0x10
    ldrh    r1,[r1,0x12]
    mov     r0,2
    str     r0,[sp]
    ldr     r0,=0x262		;moving sound
    str     r0,[sp,4]
    mov     r0,r2
    mov     r2,0x38
    mov     r3,0x50
    bl      CoreXMovement		;moves mega X
    add     sp,8
    pop     r0
    bx      r0
    .pool
	
CoreXMainMegaXDead:
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2,0x12]
    mov     r0,0x80
    lsl     r0,r0,1
    cmp     r1,r0
    bls     @@_805790C
    mov     r0,r1
    sub     r0,0x10
    strh    r0,[r2,0x12]
    b       @@_8057922
    .pool
@@_805790C:
    ldrh    r1,[r2]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r2]
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x3C
    strb    r0,[r1]
    add     r1,0xA
    mov     r0,9
    strb    r0,[r1]
@@_8057922:
    pop     r0
    bx      r0
    .pool
	
CoreXMainWait:
    push    r14
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_805794A
    add     r1,0x24
    mov     r0,0x3F
    strb    r0,[r1]
@@_805794A:
    pop     r0
    bx      r0
.pool	
	
CoreXMainSetMoveCoreX:
    ldr     r3,=CurrSpriteData
    mov     r1,r3
    add     r1,0x24
    mov     r2,0
    mov     r0,0x40
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2F
    strb    r2,[r0]
    sub     r0,3
    mov     r1,1
    strb    r1,[r0]
    add     r0,2
    strb    r2,[r0]
    add     r0,0xE
    strb    r1,[r0]
    bx      r14
    .pool
	
CoreXMainDead:
	push	r4,r14
	add		sp,-4
	ldr     r0,=DoorUnlockTimer
	mov		r1,0x3C
	neg		r1,r1
	strb	r1,[r0]
	mov		r0,1
	bl		SetnCheckEvent
	mov		r0,0xB
	mov		r1,0
	ldr		r2,=PlayMusic + 1
	bl		WrapperR2
	ldr		r2,=CurrSpriteData
	mov		r0,21h
	str     r0,[sp] 
	mov		r0,0
	mov		r3,1
	ldrh	r1,[r2,2h]
	ldrh	r2,[r2,4h]
	ldr		r4,=SpriteDeath + 1
	bl		WrapperR4
	add		sp,4
	pop		r4
	pop		r0
	bx		r0
	
CoreXMainMoveCoreX:
    push    r14
    add     sp,-8
    ldr     r1,=SamusData
    ldrh    r0,[r1,0x14]
    sub     r0,0x48
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    ldrh    r1,[r1,0x12]
    mov     r2,2
    str     r2,[sp]
    ldr     r2,=0x262		;move sound
    str     r2,[sp,4]
    mov     r2,0x1C
    mov     r3,0x28
    bl      CoreXMovement		;move core X
    add     sp,8
    pop     r0
    bx      r0
    .pool
	
CoreXMainWaitStartCoreXFight:
	bx		r14

CoreXMain_AI:
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x5C
    bls     @@_8057BEE
    b       @@Return
@@_8057BEE:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@Init,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@CheckStart
    .dw @@SpawnOrbs,@@_8057D92,@@MoveToSamus,@@MegaXDied
    .dw @@WaitStartCoreFight,@@LoadGFX,@@Return,@@SetMoveCoreX
    .dw @@MoveCoreX,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@CoreXDead
@@Init:
    bl      CoreXMainInit
    b       @@Return
@@CheckStart:
    bl      CoreXMainCheckStartFight
    b       @@Return
@@SpawnOrbs:
    bl      CoreXMainCheckSpawnOrbs
    b       @@Return
@@_8057D92:
    bl      CoreXMainSetMovePose
    b       @@Return
@@MoveToSamus:
    bl      CoreXMainMoveMegaX
    b       @@Return
@@MegaXDied:
    bl      CoreXMainMegaXDead
    b       @@Return
@@WaitStartCoreFight:
    bl      CoreXMainWaitStartCoreXFight
    b       @@Return
@@LoadGFX:
    bl      CoreXMainWait
    b       @@Return
@@SetMoveCoreX:
    bl      CoreXMainSetMoveCoreX
    b       @@Return
@@MoveCoreX:
    bl      CoreXMainMoveCoreX
    b       @@Return
@@CoreXDead:
   bl      CoreXMainDead
@@Return:
    pop     r0
    bx      r0