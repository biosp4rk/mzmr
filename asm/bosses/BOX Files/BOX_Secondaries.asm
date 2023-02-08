UpdateBOX2SubSprite:		;519AC
    push    r4,r14
    ldr     r4,=SubSpriteData
    ldrh    r0,[r4,4]
    ldr     r1,[r4]
    lsl     r0,r0,3
    add     r0,r0,r1
    ldr     r3,[r0]
    ldr     r2,=CurrSpriteData
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r3
    ldrh    r0,[r0]
    ldr     r1,=BOXOAMTable		;table of OAM pointers?
    lsl     r0,r0,2
    add     r0,r0,r1
    ldr     r1,[r2,0x18]
    ldr     r0,[r0]
    cmp     r1,r0
    beq     @@_80519DE
    str     r0,[r2,0x18]
    mov     r0,0
    strb    r0,[r2,0x1C]
    strh    r0,[r2,0x16]
@@_80519DE:
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r3
    ldrh    r0,[r0,2]
    ldrh    r1,[r4,6]
    add     r0,r0,r1
    strh    r0,[r2,2]
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r3
    ldrh    r0,[r0,4]
    ldrh    r4,[r4,8]
    add     r0,r0,r4
    strh    r0,[r2,4]
    pop     r4
    pop     r0
    bx      r0
.pool

sub_8052B38:		;52B38
    push    r14
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    lsl     r1,r1,0x18
    lsr     r3,r1,0x18
    ldr     r2,=SpriteData
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r2
    add     r1,0x2F
    ldrb    r0,[r1]
    cmp     r0,r3
    bcs     @@_8052B56
    strb    r3,[r1]
@@_8052B56:
    pop     r0
    bx      r0
    .pool

Box2Part_UpdateImmunity:		;52B60
    push    r14
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    ldr     r1,=SpriteData
    lsl     r0,r2,3
    sub     r0,r0,r2
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,0x29
    mov     r3,r1
    cmp     r0,0x19
    bhi     @@_8052C2C
    lsl     r0,r0,2
    ldr     r1,=@@_8052B90
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_8052B90:
    .dw @@_8052BF8,@@_8052BF8,@@_8052C2C,@@_8052BF8
    .dw @@_8052C2C,@@_8052BF8,@@_8052C2C,@@_8052C2C
    .dw @@_8052C2C,@@_8052C2C,@@_8052C2C,@@_8052C2C
    .dw @@_8052C2C,@@_8052C2C,@@_8052C2C,@@_8052C2C
    .dw @@_8052C2C,@@_8052C2C,@@_8052C2C,@@_8052C2C
    .dw @@_8052C2C,@@_8052C2C,@@_8052C1C,@@_8052C1C
    .dw @@_8052C1C,@@_8052C1C
@@_8052BF8:
    lsl     r0,r2,3
    sub     r0,r0,r2
    lsl     r0,r0,3
    add     r0,r0,r3
    add     r0,0x2D
    ldrb    r1,[r0]
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    beq     @@_8052C2C
    ldr     r0,=CurrSpriteData
    add     r0,0x32
    ldrb    r2,[r0]
    mov     r1,0x40
    orr     r1,r2		;;make immune to projectiles
    b       @@_8052C36
    .pool
@@_8052C1C:
    ldr     r0,=CurrSpriteData
    add     r0,0x32
    ldrb    r2,[r0]
    mov     r1,0x40
    orr     r1,r2		;make immune to projectiles
    b       @@_8052C36
    .pool
@@_8052C2C:
    ldr     r0,=CurrSpriteData
    add     r0,0x32
    ldrb    r2,[r0]
    mov     r1,0xBF		;remove immunity to projectiles
    and     r1,r2
@@_8052C36:
    strb    r1,[r0]
    pop     r0
    bx      r0
    .pool

Remove8000hStatus:		;52C40
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    ldr     r0,=0x7FFF
    and     r0,r1
    strh    r0,[r2]
    bx      r14
    .pool

Box2Part_Init:		;52C54
    push    r4,r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r2]
    mov     r0,r2
    add     r0,0x27
    mov     r1,0x18
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r2
    add     r1,0x29
    mov     r0,0x10
    strb    r0,[r1]
    sub     r1,5
    mov     r0,2
    strb    r0,[r1]
    ldrb    r0,[r2,0x1E]
    mov     r4,r2
    cmp     r0,6
    bhi     @@_8052C94
    mov     r1,r4
    add     r1,0x22
    mov     r0,0xB
    b       @@_8052C9A
    .pool
@@_8052C94:
    mov     r1,r4
    add     r1,0x22
    mov     r0,0xD
@@_8052C9A:
    strb    r0,[r1]
    ldrb    r0,[r4,0x1E]
    cmp     r0,0xB
    bls     @@_8052CA4
    b       @@_8052E00
@@_8052CA4:
    lsl     r0,r0,2
    ldr     r1,=@@_8052CB4
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_8052CB4:
    .dw @@_8052CE4,@@_8052DC4,@@_8052CE4,@@_8052DC4
    .dw @@_8052DC4,@@_8052DC4,@@_8052D34,@@_8052E00
    .dw @@_8052DC4,@@_8052D80,@@_8052DC4,@@_8052DC4
@@_8052CE4:
    ldr     r0,=0xFFB8
    strh    r0,[r4,0xA]
    mov     r0,0x48
    strh    r0,[r4,0xC]
    ldr     r0,=0xFFE0
    strh    r0,[r4,0xE]
    mov     r0,0x20
    strh    r0,[r4,0x10]
    mov     r1,r4
    add     r1,0x33		;was 35
    mov     r0,2
    strb    r0,[r1]
	mov		r0,4
    sub     r1,0xE
    strb    r0,[r1]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    mov     r2,r4
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]
    bl      UpdateBOX2SubSprite
    ldrb    r0,[r4,0x1E]
    cmp     r0,2
    bne     @@_8052E04
    mov     r0,7
    strh    r0,[r4,0x16]
    b       @@_8052E04
    .pool
@@_8052D34:
    mov     r3,0
    ldr     r0,=0xFFD0
    strh    r0,[r4,0xA]
    mov     r0,0x40
    strh    r0,[r4,0xC]
    ldr     r0,=0xFFE0
    strh    r0,[r4,0xE]
    mov     r0,0x20
    strh    r0,[r4,0x10]
    mov     r1,r4
    add     r1,0x33		;was 35
    mov     r0,1
    strb    r0,[r1]
    sub     r1,0xE
	mov		r0,4
    strb    r0,[r1]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
	mov     r2,0
    ldr     r0,=BoxOAM_44
    str     r0,[r4,0x18]
    strb    r2,[r4,0x1C]
    strh    r3,[r4,0x16]
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    b       @@_8052E04
    .pool
@@_8052D80:
    ldr     r0,=0xFFE0
    strh    r0,[r4,0xA]
    mov     r0,0x20
    strh    r0,[r4,0xC]
    ldr     r0,=0xFFC0
    strh    r0,[r4,0xE]
    mov     r0,0x40
    strh    r0,[r4,0x10]
    mov     r1,r4
    add     r1,0x25
    mov     r0,4
    strb    r0,[r1]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    mov     r2,r4
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]
    bl      UpdateBOX2SubSprite
    b       @@_8052E04
    .pool
@@_8052DC4:
    mov     r2,0
    ldr     r1,=0xFFFC
    strh    r1,[r4,0xA]
    mov     r0,4
    strh    r0,[r4,0xC]
    strh    r1,[r4,0xE]
    strh    r0,[r4,0x10]
    mov     r0,r4
    add     r0,0x25
    strb    r2,[r0]
    ldrh    r0,[r4]
    mov     r2,0x80
    lsl     r2,r2,8
    mov     r1,r2
    orr     r0,r1
    strh    r0,[r4]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    bl      UpdateBOX2SubSprite
    b       @@_8052E04
    .pool
@@_8052E00:
    mov     r0,0
    strh    r0,[r4]
@@_8052E04:
    pop     r4
    pop     r0
    bx      r0
	


Box2_Part0AI:			;52E0C
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
	add		sp,-4h
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r0,[r0]
    mov     r9,r0
    mov     r10,r9
    ldr     r0,=SpriteData
    mov     r2,r9
    lsl     r1,r2,3
    sub     r1,r1,r2
    lsl     r1,r1,3
    add     r1,r1,r0
    mov     r8,r1
    ldrh    r0,[r1]
    ldrh    r2,[r4]
    ldr     r3,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r3
    ldrh    r5,[r0]
    ldrh    r6,[r4,2]
    ldrh    r7,[r4,4]
    mov     r0,r8
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x46			;exploding pose for BOX main sprite
    bne     @@_8052E7C
    mov		r0,0
    strh    r0,[r4]			;kill 
    b       @@_8052ED2
    .pool
@@_8052E7C:
    mov     r0,r9
    bl      Remove8000hStatus		;pointless? could do without function call
    mov     r0,r4
    add     r0,0x32
    ldrb    r1,[r0]
    mov     r0,0x10
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    cmp     r2,0
    beq     @@_8052EE0
    ldrh    r0,[r4,0x14]
    cmp     r0,0
    beq     @@_8052EE6
    mov     r0,r8
    add     r0,0x2D
    ldrb    r1,[r0]
    mov     r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8052EC8
    mov     r0,r4
    add     r0,0x2E
    ldrb    r1,[r0]
    add     r1,1
    strb    r1,[r0]
    mov     r0,0x1F
    and     r1,r0
    cmp     r1,0
    bne     @@_8052F96
    mov     r0,r6
    add     r0,0x30
    mov     r1,r7
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8052F96
@@_8052EC8:
    mov		r1,0
    strh    r1,[r4]
@@_8052ED2:
    mov     r0,r6
    add     r0,0x32
    mov     r1,r7
    mov     r2,0x2F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8052F96
@@_8052EE0:
    ldrh    r1,[r4,0x14]
    cmp     r1,0
    bne     @@_8052F28
@@_8052EE6:
    ldr     r1,=SpriteData
    mov     r2,r10
    lsl     r0,r2,3
    sub     r0,r0,r2
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x2D
    ldrb    r2,[r0]
    mov     r1,0xFE
    and     r1,r2
    strb    r1,[r0]
    ldr     r1,=CurrSpriteData
    ldrh    r2,[r1]
    mov     r0,4
    mov     r3,0
    orr     r0,r2
    strh    r0,[r1]
    mov     r0,0xFF
    strh    r0,[r1,0x14]
    add     r1,0x25
    strb    r3,[r1]		;cant hurt samus
	strb	r3,[r1,9] 
    mov     r0,r6
    add     r0,0x32
    mov     r1,r7
    mov     r2,0x2F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,r10
    b       @@_8052F5A
    .pool
@@_8052F28:
    lsr     r0,r5,2
    cmp     r1,r0
    bcs     @@_8052F38
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_4
    b       @@_8052F42
    .pool
@@_8052F38:
    lsr     r0,r5,1
    cmp     r1,r0
    bcs     @@_8052F68
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_3
@@_8052F42:
    cmp     r0,r1
    beq     @@_8052F96
    str     r1,[r4,0x18]
    strb    r2,[r4,0x1C]
    strh    r2,[r4,0x16]
    mov     r0,r6
    add     r0,0x24
    mov     r1,r7
    mov     r2,0x1F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,r9
@@_8052F5A:
    mov     r1,1
    bl      sub_8052B38
    b       @@_8052F96
    .pool
@@_8052F68:
    ldrh    r1,[r4,0x14]
    lsl     r0,r5,1
    add     r0,r0,r5
    asr     r0,r0,2
    cmp     r1,r0
    bge     @@_8052F96
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_2
    cmp     r0,r1
    beq     @@_8052F96
    str     r1,[r4,0x18]
    strb    r2,[r4,0x1C]
    strh    r2,[r4,0x16]
    mov     r0,r6
    add     r0,0x24
    mov     r1,r7
    mov     r2,0x1F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,r10
    mov     r1,1
    bl      sub_8052B38
@@_8052F96:
	add		sp,4
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
Box2_Part2AI:		;52FA8
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    add     sp,-4
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r0,[r0]
    mov     r9,r0
    str     r0,[sp]
    ldr     r0,=SpriteData
    mov     r2,r9
    lsl     r1,r2,3
    sub     r1,r1,r2
    lsl     r1,r1,3
    add     r1,r1,r0
    mov     r8,r1
    ldr     r3,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r3
    ldrh    r5,[r0]
    ldrh    r6,[r4,2]
    ldrh    r7,[r4,4]
    mov     r0,r8
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x46		;BOX main sprite exloding
    bne     @@_8053018
    mov     r0,0
    strh    r0,[r4]
    b       @@_805306C
    .pool
@@_8053018:
    mov     r0,r9
    bl      Remove8000hStatus
    mov     r0,r4
    add     r0,0x32
    ldrb    r1,[r0]
    mov     r0,0x10
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    cmp     r2,0
    beq     @@_805307A
    ldrh    r0,[r4,0x14]
    cmp     r0,0
    beq     @@_8053080
    mov     r0,r8
    add     r0,0x2D
    ldrb    r1,[r0]
    mov     r0,1
    and     r0,r1
    cmp     r0,0
    beq     @@_8053064
    mov     r0,r4
    add     r0,0x2E
    ldrb    r1,[r0]
    add     r1,1
    strb    r1,[r0]
    mov     r0,0x1F
    and     r1,r0
    cmp     r1,0
    bne     @@_8053132
    mov     r0,r6
    add     r0,0x30
    mov     r1,r7
    mov     r2,0x37
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8053132
@@_8053064:
    mov    r1,0
    strh   r1,[r4]
@@_805306C:
    mov     r0,r6
    add     r0,0x32
    mov     r1,r7
    mov     r2,0x2F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8053132
@@_805307A:
    ldrh    r1,[r4,0x14]
    cmp     r1,0
    bne     @@_80530C4
@@_8053080:
    ldr     r1,=SpriteData
    ldr     r2,[sp]
    lsl     r0,r2,3
    sub     r0,r0,r2
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x2D
    ldrb    r2,[r0]
    mov     r1,0xFD
    and     r1,r2
    strb    r1,[r0]
    ldr     r1,=CurrSpriteData
    ldrh    r2,[r1]
    mov     r0,4
    mov     r3,0
    orr     r0,r2
    strh    r0,[r1]
    mov     r0,0xFF
    strh    r0,[r1,0x14]
    add     r1,0x25
    strb    r3,[r1]
	strb	r3,[r1,9]
    mov     r0,r6
    add     r0,0x32
    mov     r1,r7
    mov     r2,0x2F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldr     r0,[sp]
    b       @@_80530F6
    .pool
@@_80530C4:
    lsr     r0,r5,2
    cmp     r1,r0
    bcs     @@_80530D4
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_17
    b       @@_80530DE
    .pool
@@_80530D4:
    lsr     r0,r5,1
    cmp     r1,r0
    bcs     @@_8053104
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_16
@@_80530DE:
    cmp     r0,r1
    beq     @@_8053132
    str     r1,[r4,0x18]
    strb    r2,[r4,0x1C]
    strh    r2,[r4,0x16]
    mov     r0,r6
    add     r0,0x24
    mov     r1,r7
    mov     r2,0x1F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,r9
@@_80530F6:
    mov     r1,1
    bl      sub_8052B38
    b       @@_8053132
    .pool
@@_8053104:
    ldrh    r1,[r4,0x14]
    lsl     r0,r5,1
    add     r0,r0,r5
    asr     r0,r0,2
    cmp     r1,r0
    bge     @@_8053132
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_15
    cmp     r0,r1
    beq     @@_8053132
    str     r1,[r4,0x18]
    strb    r2,[r4,0x1C]
    strh    r2,[r4,0x16]
    mov     r0,r6
    add     r0,0x24
    mov     r1,r7
    mov     r2,0x1F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    ldr     r0,[sp]
    mov     r1,1
    bl      sub_8052B38
@@_8053132:
    add     sp,4
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
Box2_Part3AI:		;53148
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    add     sp,-4
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r0,[r0]
    mov     r9,r0
    ldr     r0,=SpriteData
    mov     r2,r9
    lsl     r1,r2,3
    sub     r1,r1,r2
    lsl     r1,r1,3
    add     r7,r1,r0
    mov		r5,0
    ldr     r3,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r3
    ldrh    r6,[r0]
    ldrh    r3,[r4,2]
    ldrh    r2,[r4,4]
    mov     r8,r2
    mov     r0,r9
    str     r3,[sp]
    bl      Box2Part_UpdateImmunity
    ldrh    r1,[r4,0x14]
    ldr     r3,[sp]
    cmp     r1,0
    bne     @@_80531E0
    mov     r2,r7
    add     r2,0x2D
    ldrb    r1,[r2]
    mov     r0,0xFB
    and     r0,r1
    strb    r0,[r2]
    mov     r0,r3
    add     r0,0x32
    mov     r1,r8
    mov     r2,0x2F
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,0
    strh    r0,[r4]
    mov     r1,r7
    add     r1,0x24
    mov     r0,0x43
    strb    r0,[r1]
    b       @@_8053252
    .pool
@@_80531E0:
    lsr     r0,r6,2
    cmp     r1,r0
    bcs     @@_80531F0
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_29
    b       @@_8053210
    .pool
@@_80531F0:
    lsr     r0,r6,1
    cmp     r1,r0
    bcs     @@_8053200
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_28
    b       @@_8053210
    .pool
@@_8053200:
    ldrh    r1,[r4,0x14]
    lsl     r0,r6,1
    add     r0,r0,r6
    asr     r0,r0,2
    cmp     r1,r0
    bge     @@_805322C
    ldr     r0,[r4,0x18]
    ldr     r1,=BoxOAM_27
@@_8053210:
    cmp     r0,r1
    beq     @@_8053252
    str     r1,[r4,0x18]
    strb    r5,[r4,0x1C]
    strh    r5,[r4,0x16]
    mov     r0,r3
    add     r0,0x24
    mov     r1,r8
    mov     r2,0x34
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@_8053252
    .pool
@@_805322C:
    cmp     r1,r6
    bcs     @@_8053252
    ldr     r0,[r4,0x18]
    ldr     r2,=BoxOAM_26
    cmp     r0,r2
    beq     @@_8053252
    mov     r1,r4
    add     r1,0x33		;was 35
    mov     r0,2
    strb    r0,[r1]
    str     r2,[r4,0x18]
    strb    r5,[r4,0x1C]
    strh    r5,[r4,0x16]
    mov     r0,r3
    add     r0,0x24
    mov     r1,r8
    mov     r2,0x34
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@_8053252:
    ldr     r0,=CurrSpriteData
    add     r0,0x2B		;was 2Ch
    ldrb    r1,[r0]
    mov     r0,0x7F
    and     r0,r1
    cmp     r0,4
    bne     @@_8053270
    mov     r0,r9
    mov     r1,2
    bl      sub_8052B38
    mov     r0,0x9E
    lsl     r0,r0,2
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
@@_8053270:
    add     sp,4
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
	
Box2_Part4AI:		;53288
    push    r4,r5,r14
	add		sp,-4
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,0x23
    ldrb    r1,[r0]
    ldr     r2,=SpriteData
    lsl     r0,r1,3
    sub     r0,r0,r1
    lsl     r0,r0,3
    add     r2,r0,r2
    mov     r0,r2
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3C
    beq     @@_80532E8
    cmp     r0,0x3C
    bgt     @@_80532DE
    cmp     r0,8
    beq     @@_80532E8
    cmp     r0,0x18
    beq     @@_80532E8
    b       @@_8053330
@@_80532DE:
    cmp     r0,0x46
    beq     @@_80532F4
    cmp     r0,0x48
    beq     @@_8053328
    b       @@_8053330
@@_80532E8:
    ldr     r0,[r3,0x18]
    ldr     r1,=BoxOAM_34
    b       @@_8053334
    .pool
@@_80532F4:
    ldr     r0,[r3,0x18]
    ldr     r2,=BoxOAM_34
    cmp     r0,r2
    beq     @@_8053302
    str     r2,[r3,0x18]
    strb    r1,[r3,0x1C]
    strh    r1,[r3,0x16]
@@_8053302:
	mov		r0,r3
	add		r0,0x25
	mov		r1,0
	strb	r1,[r0]
    ldr     r0,=FrameCounter8Bit
    ldrb    r0,[r0]
    mov     r1,7
    and     r1,r0
    cmp     r1,0
    bne     @@_8053340
    add     r3,0x20
    ldrb    r0,[r3]
    cmp     r0,0xD
    bne     @@_8053324
	mov		r0,r3
    add     r0,14h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r2,[r3,1Fh]
    add     r0,r0,r2
    mov     r2,0Fh
    sub     r2,r2,r0
	strb	r2,[r3]
    b       @@_8053340
    .pool
@@_8053324:
	mov		r1,0xD
    strb    r1,[r3]
    b       @@_8053340
@@_8053328:
    mov     r0,0
    strh    r0,[r3]
    b       @@_8053340
@@_8053330:
    ldr     r0,[r3,0x18]
    ldr     r1,=BoxOAM_33
@@_8053334:
    cmp     r0,r1
    beq     @@_8053340
    str     r1,[r3,0x18]
    mov     r0,0
    strb    r0,[r3,0x1C]
    strh    r0,[r3,0x16]
@@_8053340:
	add 	sp,4
    pop     r4,r5
    pop     r0
    bx      r0
    .pool

Box2_Part1AI:			
    push    r4-r6,r14
	add		sp,-4
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r1,[r0]
    ldr     r2,=SpriteData
    lsl     r0,r1,3
    sub     r0,r0,r1
    lsl     r0,r0,3
    add     r5,r0,r2
    ldrh    r0,[r5]
    mov     r6,1
    mov		r3,0
	ldrh	r2,[r4]
    mov     r0,r5
    add     r0,0x24
    ldrb    r0,[r0]		;check pose of main sprite
    cmp     r0,0x47
    beq     @@_80533CC
    cmp     r0,0x47
    bgt     @@_805339E
    cmp     r0,0x46
    beq     @@_80533A8
    b       @@_80533F2
@@_805339E:
    cmp     r0,0x48
    beq     @@_80533D4
    cmp     r0,0x49
    beq     @@_80533EC
    b       @@_80533F2
@@_80533A8:
	mov		r1,r4
	add		r1,0x25
	mov		r0,0
	strb	r0,[r1]
    ldr     r0,=FrameCounter8Bit
    ldrb    r1,[r0]
    mov     r0,7
    and     r0,r1
    cmp     r0,0
    bne     @@_80533F2
    mov     r1,r4
    add     r1,0x20
    ldrb    r0,[r1]
    cmp     r0,0xE
    bne     @@_80533C8
	mov		r0,r4
    add     r0,34h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r2,[r4,1Fh]
    add     r0,r0,r2
    mov     r2,10h
    sub     r2,r2,r0
	strb	r2,[r1]
    b       @@_80533F2
    .pool
@@_80533C8:
	mov		r3,0xE
    strb    r3,[r1]
    b       @@_80533F2
@@_80533CC:
    mov     r0,r4
    add     r0,0x20
    strb    r3,[r0]
    b       @@_80533F2
@@_80533D4:
    ldr     r0,=FrameCounter8Bit
    ldrb    r1,[r0]
    mov     r0,r6
    and     r0,r1
    cmp     r0,0
    bne     @@_80533F2
    mov     r0,4
    eor     r0,r2
	strh    r0,[r4]
    b       @@_80533F2
    .pool
@@_80533EC:
    mov		r0,20h
	str     r0,[sp] 
	mov		r0,0
	mov		r3,1
	ldrh	r1,[r4,2h]
	ldrh	r2,[r4,4h]
	ldr		r6,=SpriteDead + 1
	bl		WrapperR6
@@_80533F2:
	add		sp,4
    pop     r4-r6
    pop     r0
    bx      r0

Box2Missile_Init:	;533F8
    push    r4,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r1,[r0]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0
    mov     r2,0
    mov     r1,0x80
    orr     r0,r1
    mov     r1,r12
    strh    r0,[r1]
    ldr     r0,=BackupOfIORegisters
    ldrb    r1,[r0,0xA]
    mov     r0,3
    and     r0,r1
    mov     r1,r12
    add     r1,0x21
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r1,=0xFFF8
    mov     r4,r12
    strh    r1,[r4,0xA]
    mov     r0,8
    strh    r0,[r4,0xC]
    strh    r1,[r4,0xE]
    strh    r0,[r4,0x10]
    ldr     r0,=BoxOAM_42
    str     r0,[r4,0x18]
    strb    r3,[r4,0x1C]
    strh    r2,[r4,0x16]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r4,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    mov     r1,r12
    add     r1,0x2A
    mov     r0,0xC0
    strb    r0,[r1]
    add     r0,0x40
    strh    r0,[r4,0x12]
    add     r1,2		;was 2E
    mov     r0,0x24
    strb    r0,[r1]
    mov     r0,0x96
    lsl     r0,r0,1
    strh    r0,[r4,6]
    sub     r1,8
    mov     r0,2
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x36  ;was 2D
    strb    r3,[r0]
    add     r1,1
    mov     r0,4
    strb    r0,[r1]
    mov     r0,0xF8
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r4
    pop     r0
    bx      r0
    .pool
	
Box2Missile_Launching:		;534A4
    push    r4-r7,r14
    mov     r7,r8
    push    r7
    add     sp,-4
    ldr     r5,=CurrSpriteData
    ldrh    r0,[r5,0x14]
    cmp     r0,0
    bne     @@_80534BC
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x37
    strb    r0,[r1]
@@_80534BC:
    mov     r6,r5
    add     r6,0x2C  ;was 2E
    ldrb    r1,[r6]
    lsr     r1,r1,1
    ldrh    r0,[r5,2]
    sub     r0,r0,r1
    mov     r2,0
    mov     r8,r2
    strh    r0,[r5,2]
    cmp     r1,2
    bhi     @@_80534EC
    mov     r7,r5
    add     r7,0x2A
    ldrb    r0,[r7]
    ldr     r2,=SamusData
    ldrh    r1,[r2,0x14]
    sub     r1,0x40
    ldrh    r2,[r2,0x12]
    ldrh    r3,[r5,2]
    ldrh    r4,[r5,4]
    str     r4,[sp]
    ldr     r4,=RotateSpriteTowardsSamus + 1
	bl		WrapperR4
    strb    r0,[r7]
@@_80534EC:
    ldrb    r0,[r6]
    sub     r0,2
    strb    r0,[r6]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,1
    bhi     @@_8053518
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x18
    strb    r0,[r1]
    mov     r0,r5
    add     r0,0x36  ;was 2D
    mov     r1,r8
    strb    r1,[r0]
    sub     r0,8
    mov     r1,1
    strb    r1,[r0]
    mov     r2,r8
    strb    r2,[r6]
    add     r0,1
    strb    r1,[r0]
@@_8053518:
    add     sp,4
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
.pool	
	
Box2Missile_MovingTowardSamus:	;5352C
    push    r4-r7,r14
    add     sp,-4
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,6]
    sub     r0,1
    strh    r0,[r1,6]
    lsl     r0,r0,0x10
    cmp     r0,0
    beq     @@_8053544
    ldrh    r0,[r1,0x14]
    cmp     r0,0
    bne     @@_8053550
@@_8053544:
    add     r1,0x24
    mov     r0,0x37
    strb    r0,[r1]
    b       @@_80535F8
    .pool
@@_8053550:
    ldrb    r1,[r1,0x1E]
    mov     r2,8
    cmp     r1,3  
    beq     @@_8053566
    mov     r2,0x28
    cmp     r1,2
    beq     @@_8053566
    mov     r2,0x68
    cmp     r1,1
    bne     @@_8053566
    mov     r2,0x48
@@_8053566:
    ldr     r4,=SamusData
    ldrh    r0,[r4,0x14]
    sub     r0,r0,r2
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    ldrh    r1,[r4,0x12]
    mov     r2,2
    str     r2,[sp]
    mov     r2,0x18
    mov     r3,0x28
    ldr     r6,=MoveBOXMissile + 1
	bl		WrapperR6
    ldr     r5,=CurrSpriteData
    mov     r6,r5
    add     r6,0x2A
    ldrb    r0,[r6]
    ldrh    r1,[r4,0x14]
    sub     r1,0x40
    ldrh    r2,[r4,0x12]
    ldrh    r3,[r5,2]
    ldrh    r4,[r5,4]
    str     r4,[sp]
    ldr     r4,=RotateSpriteTowardsSamus + 1
	bl		WrapperR4
    strb    r0,[r6]
    ldrh    r0,[r5,2]
    ldrh    r1,[r5,4]
    ldr     r2,=CheckCollisionAtPosition + 1
	bl		WrapperR2
    ldr     r0,=PrevCollisionCheck1
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_80535B0
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x37
    strb    r0,[r1]
@@_80535B0:
    ldr     r0,=CurrentAffectingClip
    ldrh    r4,[r0,2]
    cmp     r4,5
    bcs     @@_80535E0
	cmp		r0,0		;checks if in a liquid
	beq		@@_80535E0
    mov     r6,r5
    add     r6,0x36		;was 2D
    ldrb    r0,[r6]
    cmp     r0,0
    bne     @@_80535F8
    ldrh	r0,[r5,2]
	ldrh	r1,[r5,4]
	mov		r3,1		;small splash
	ldr		r7,=SetSpriteSplashEffect + 1
	bl		WrapperR7
    strb    r4,[r6]
    b       @@_80535F8
    .pool
@@_80535E0:
    mov     r4,r5
    add     r4,0x36			;was 2D
    ldrb    r0,[r4]
    cmp     r0,0
    beq     @@_80535F8
    ldrh    r0,[r5,2]
	add		r0,40h
    ldrh    r1,[r5,4]
    mov     r2,0x39
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r0,0
    strb    r0,[r4]
@@_80535F8:
    add     sp,4
    pop     r4-r7
    pop     r0
    bx      r0	
	
Box2Missile_Exploding:		;53600
    push    r4,r14
	add		sp,-4
    ldr     r1,=CurrSpriteData
    ldrh	r0,[r1,0x14]
	cmp		r0,0
	beq		@@DeadByDamage
	mov		r0,0
	strh	r0,[r1]
	b		@@PlayEffect
@@DeadByDamage:	
	mov		r0,0
	str     r0,[sp] 
	mov		r0,0
	ldrh    r2,[r1,4]
    ldrh    r1,[r1,2]
	mov		r3,1
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@@PlayEffect:
	ldr		r1,=CurrSpriteData
	ldrh	r0,[r1,2]
	ldrh	r1,[r1,4]
	mov		r2,0x30
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
@@Return:
	add		sp,4
	pop		r4
    pop     r0
    bx      r0
    .pool

Box2BrainTop_Init:		;53624
    push    r4,r5,r14
    add     sp,-0xC
    ldr     r5,=CurrSpriteData
    ldrh    r1,[r5]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0
    mov     r4,0
    strh    r0,[r5]
    ldr     r0,=BackupOfIORegisters
    ldrb    r1,[r0,0xA]
    mov     r0,3
    and     r0,r1
    mov     r1,r5
    add     r1,0x21
    strb    r0,[r1]
    mov     r0,r5
    add     r0,0x27
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    mov     r2,0x20
    strb    r2,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r1,=0xFFE0
    strh    r1,[r5,0xA]
    mov     r0,0x40
    strh    r0,[r5,0xC]
    strh    r1,[r5,0xE]
    strh    r2,[r5,0x10]
    ldr     r0,=BoxOAM_43
    str     r0,[r5,0x18]
    strb    r3,[r5,0x1C]
    strh    r4,[r5,0x16]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r5,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r5,0x14]
    mov     r1,r5
    add     r1,0x2E
    mov     r0,0x5A
    strb    r0,[r1]
    mov     r0,r5
    add     r0,0x24
    mov     r1,2
    strb    r1,[r0]
	mov		r1,0
    add     r0,1
    strb    r1,[r0]
    ldrb    r2,[r5,0x1F]
    sub     r0,2
    ldrb    r3,[r0]
    ldrh    r0,[r5,2]
    str     r0,[sp]
    ldrh    r0,[r5,4]
    str     r0,[sp,4]
    str     r4,[sp,8]
BoxBrain2:
    mov     r0,BoxBrainID
    mov     r1,1
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    mov     r1,r5
    add     r1,0x2F
    strb    r0,[r1]
    add     sp,0xC
    pop     r4,r5
    pop     r0
    bx      r0
    .pool

Box2BrainTop_Rising:		;536C8
    push    r14
    ldr     r0,=FrameCounter8Bit
    ldrb    r0,[r0]
    mov     r2,7
    and     r2,r0
    ldr     r3,=CurrSpriteData
    cmp     r2,0
    bne     @@_805370C
    mov     r1,r3
    add     r1,0x20
    ldrb    r0,[r1]
    cmp     r0,0xC
    bne     @@_80536F0
	mov     r0,r3
    add     r0,34h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r1,[r3,1Fh]
    add     r0,r0,r1
    mov     r1,0Eh
    sub     r1,r1,r0
    mov     r0,r3
    add     r0,20h
    strb    r1,[r0]					;changes palette row, used for flashing
    b       @@_80536F2
    .pool
@@_80536F0:
	mov		r2,0xC
    strb    r2,[r1]
@@_80536F2:
    ldr     r2,=SpriteData
    mov     r0,r3
    add     r0,0x2F
    ldrb    r1,[r0]
    lsl     r0,r1,3
    sub     r0,r0,r1
    lsl     r0,r0,3
    add     r0,r0,r2
    mov     r1,r3
    add     r1,0x20
    ldrb    r1,[r1]
    add     r0,0x20
    strb    r1,[r0]
@@_805370C:
    mov     r0,0x2E
    add     r0,r0,r3
    mov     r12,r0
    ldrb    r0,[r0]
    sub     r0,1
    mov     r1,r12
    strb    r0,[r1]
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    cmp     r2,0
    bne     @@_805373C
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x18
    strb    r0,[r1]
    mov     r0,0x3C
    mov     r1,r12
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2C
    strb    r2,[r0]
    b       @@_8053742
    .pool
@@_805373C:
    ldrh    r0,[r3,2]
    sub     r0,2
    strh    r0,[r3,2]
@@_8053742:
    pop     r0
    bx      r0	

Box2BrainTop_Floating:
    push    r4-r6,r14
	add 	sp,-4
    ldr     r0,=FrameCounter8Bit
    ldrb    r0,[r0]
    mov     r2,7
    and     r2,r0
    ldr     r3,=CurrSpriteData
    cmp     r2,0
    bne     @@_805378C
    mov     r1,r3
    add     r1,0x20
    ldrb    r0,[r1]
    cmp     r0,0xC
    bne     @@_8053770
	mov		r0,r3
    add     r0,34h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r2,[r3,1Fh]
    add     r0,r0,r2
    mov     r2,0Eh
    sub     r2,r2,r0
	strb	r2,[r1]
    b       @@_8053772
    .pool
@@_8053770:
	mov		r2,0xC
    strb    r2,[r1]
@@_8053772:
    ldr     r2,=SpriteData
    mov     r0,r3
    add     r0,0x2F
    ldrb    r1,[r0]
    lsl     r0,r1,3
    sub     r0,r0,r1
    lsl     r0,r0,3
    add     r0,r0,r2
    mov     r1,r3
    add     r1,0x20
    ldrb    r1,[r1]
    add     r0,0x20
    strb    r1,[r0]
@@_805378C:
    mov     r0,0x2C
    add     r0,r0,r3
    mov     r12,r0
    ldrb    r2,[r0]
    ldr     r5,=BOXBrainFloatTable
    lsl     r0,r2,1
    add     r0,r0,r5
    ldrh    r4,[r0]
    mov     r6,0
    ldsh    r1,[r0,r6]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@_80537AA
    ldrh    r4,[r5]
    mov     r2,0
@@_80537AA:
    add     r0,r2,1
    mov     r1,r12
    strb    r0,[r1]
    ldrh    r0,[r3,2]
    add     r0,r0,r4
    mov     r4,0
    strh    r0,[r3,2]
    mov     r1,r3
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@_80537E6
    sub     r1,0xA
    mov     r0,0x45
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x20
    strb    r4,[r0]
    ldr     r2,=SpriteData
    add     r0,0xF
    ldrb    r1,[r0]
    lsl     r0,r1,3
    sub     r0,r0,r1
    lsl     r0,r0,3
    add     r0,r0,r2
    add     r0,0x20
    strb    r4,[r0]
	mov		r0,20h
	str     r0,[sp] 
	mov		r0,0
	ldrh	r1,[r3,2h]
	ldrh	r2,[r3,4h]
	mov		r3,1
	ldr		r6,=SpriteDead + 1
	bl		WrapperR6
@@_80537E6:
	add		sp,4
    pop     r4-r6
    pop     r0
    bx      r0
    .pool

Box2BrainBottom_Init:	;5389C
    push    r4,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r1,[r0]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0
    mov     r4,0
    mov     r2,0x80
    lsl     r2,r2,8
    mov     r1,r2
    orr     r0,r1
    mov     r1,r12
    strh    r0,[r1]
    ldr     r0,=BackupOfIORegisters
    ldrb    r1,[r0,0xA]
    mov     r2,3
    mov     r0,r2
    and     r0,r1
    mov     r1,r12
    add     r1,0x21
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x22
    strb    r2,[r0]
    add     r0,5
    strb    r3,[r0]
    add     r1,7
    mov     r0,0x20
    strb    r0,[r1]
    add     r1,1
    mov     r0,8
    strb    r0,[r1]
    ldr     r1,=0xFFFC
    mov     r2,r12
    strh    r1,[r2,0xA]
    mov     r0,4
    strh    r0,[r2,0xC]
    strh    r1,[r2,0xE]
    strh    r0,[r2,0x10]
    ldr     r0,=BoxOAM_46
    str     r0,[r2,0x18]
    strb    r3,[r2,0x1C]
    strh    r4,[r2,0x16]
    mov     r1,r12
    add     r1,0x24
    mov     r0,2
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x25
    strb    r3,[r0]
    pop     r4
    pop     r0
    bx      r0
    .pool

Box2BrainBottom_Idle:		;5391C
    push    r4,r14
	add		sp,-4
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x23
    ldrb    r4,[r0]
    ldr     r3,=SpriteData
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r0,r0,r3
    ldrh    r1,[r0,2]
    strh    r1,[r2,2]
    ldrh    r1,[r0,4]
    strh    r1,[r2,4]
    ldrh    r1,[r0]
    mov     r0,0x20
    and     r0,r1
    cmp     r0,0
    beq     @@_8053954
    ldrh    r0,[r2]
    mov     r1,0x20
    orr     r0,r1
    b       @@_805395A
    .pool
@@_8053954:
    ldrh    r1,[r2]
    ldr     r0,=0xFFDF
    and     r0,r1
@@_805395A:
    strh    r0,[r2]
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r0,r0,r3
    ldrh    r1,[r0]
    mov		r3,1
	and		r1,r3
	cmp		r1,0h		;if top brain dead, kill
	beq		@@Kill
	ldrb	r0,[r0,1Dh]
	cmp		r0,BoxBrainID	;if top brain ID changed to drop, kill
    beq     @@_8053970
@@Kill:
    mov		r0,20h
	str     r0,[sp] 
	mov		r0,0
	mov		r3,1
	ldrh	r1,[r2,2h]
	add		r1,0x20
	ldrh	r2,[r2,4h]
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@@_8053970:
	add		sp,4
    pop     r4
    pop     r0
    bx      r0
    .pool

.notice "BOX Part AI"
.notice tohex(.)
Box2Part_AI:		;53B9C
    push    r4,r14
    ldr     r0,=CurrSpriteData
    mov     r1,r0
    add     r1,0x24
    ldrb    r1,[r1]
    mov     r2,r0
    cmp     r1,0
    bne     @@_8053BB8
    bl      Box2Part_Init
    b       @@_8053C80
    .pool
@@_8053BB8:
    ldrb    r0,[r2,0x1E]		;part number
    cmp     r0,2
    beq     @@_8053BF8
    cmp     r0,2
    bgt     @@_8053BC8
    cmp     r0,0
    beq     @@_8053BD2
    b       @@_8053C60
@@_8053BC8:
    cmp     r0,6
    beq     @@_8053C20
    cmp     r0,8
    beq     @@_8053C38
    b       @@_8053C60
@@_8053BD2:
    mov     r4,r2
    add     r4,0x2B		;was 2Ch
    ldrb    r2,[r4]
    mov     r0,0x7F
    ldr     r1,=SubSpriteData
    ldrb    r3,[r1,0xF]
    mov     r1,r0
    and     r1,r2
    and     r0,r3
    cmp     r1,r0
    bcs     @@_8053BEA
    strb    r3,[r4]
@@_8053BEA:
    bl      Box2_Part0AI
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    b       @@_8053C80
    .pool
@@_8053BF8:
    mov     r4,r2
    add     r4,0x2B		;was 2C
    ldrb    r2,[r4]
    mov     r0,0x7F
    ldr     r1,=SubSpriteData
    ldrb    r3,[r1,0xF]
    mov     r1,r0
    and     r1,r2
    and     r0,r3
    cmp     r1,r0
    bcs     @@_8053C10
    strb    r3,[r4]
@@_8053C10:
    bl      Box2_Part2AI
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    b       @@_8053C80
    .pool
@@_8053C20:
    ldr     r0,=SubSpriteData
    mov     r1,r2
    add     r1,0x2B		;was 2C
    ldrb    r1,[r1]
    strb    r1,[r0,0xF]
    bl      Box2_Part3AI
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    b       @@_8053C80
    .pool
@@_8053C38:
    mov     r4,r2
    add     r4,0x2B		;was 2C
    ldrb    r2,[r4]
    mov     r0,0x7F
    ldr     r1,=SubSpriteData
    ldrb    r3,[r1,0xF]
    mov     r1,r0
    and     r1,r2
    and     r0,r3
    cmp     r1,r0
    bcs     @@_8053C50
    strb    r3,[r4]
@@_8053C50:
    bl      Box2_Part4AI
    ldr     r1,=SyncCurrandSubspritePos + 1
	bl		WrapperR1
    b       @@_8053C80
    .pool
@@_8053C60:
    mov     r4,r2
    add     r4,0x2B		;was 2C
    ldrb    r2,[r4]
    mov     r0,0x7F
    ldr     r1,=SubSpriteData
    ldrb    r3,[r1,0xF]
    mov     r1,r0
    and     r1,r2
    and     r0,r3
    cmp     r1,r0
    bcs     @@_8053C78
    strb    r3,[r4]
@@_8053C78:
    bl      Box2_Part1AI
    bl      UpdateBOX2SubSprite
@@_8053C80:
    pop     r4
    pop     r0
    bx      r0
.pool

.notice "BOX Missile AI"
.notice tohex(.)
Box2Missile_AI:
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,2
    beq     @@_8053CB8
    cmp     r0,2
    bgt     @@_8053CA8
    cmp     r0,0
    beq     @@_8053CB2
    b       @@_8053CC8
    .pool
@@_8053CA8:
    cmp     r0,0x18
    beq     @@_8053CBE
    cmp     r0,0x37
    beq     @@_8053CC4
    b       @@_8053CC4
@@_8053CB2:
    bl      Box2Missile_Init
    b       @@_8053CC8
@@_8053CB8:
    bl      Box2Missile_Launching
    b       @@_8053CC8
@@_8053CBE:
    bl      Box2Missile_MovingTowardSamus
    b       @@_8053CC8
@@_8053CC4:
    bl      Box2Missile_Exploding
@@_8053CC8:
    pop     r0
    bx      r0

.notice "BOX BrainAI"
.notice tohex(.)
Box2BrainTop_AI:		;53CCC
    push    r14
    ldr     r0,=CurrSpriteData
	ldrb	r1,[r0,1Eh]
	cmp		r1,1h
	bne		@@TopHalf
	ldr		r0,=Box2BrainBottom_AI + 1
	bx		r0
@@TopHalf:
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x18
    beq     @@_8053D02
    cmp     r0,0x18
    bgt     @@_8053CEC
    cmp     r0,0
    beq     @@_8053CF6
    cmp     r0,2
    beq     @@_8053CFC
    b       @@_8053D10
    .pool
@@_8053CEC:
    cmp     r0,0x45
    beq     @@_8053D08
    cmp     r0,0x46
    beq     @@_8053D0C
    b       @@_8053D10
@@_8053CF6:
    bl      Box2BrainTop_Init
    b       @@_8053D10
@@_8053CFC:
    bl      Box2BrainTop_Rising
    b       @@_8053D10
@@_8053D02:
    bl      Box2BrainTop_Floating
    b       @@_8053D10
@@_8053D08:
;    bl      Box2BrainTop_TransformationStart
@@_8053D0C:
;    bl      Box2BrainTop_Transformation
@@_8053D10:
    pop     r0
    bx      r0
	
Box2BrainBottom_AI:		;53D14
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,0x26
    mov     r1,1
    strb    r1,[r2]
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0
    bne     @@_8053D2C
    bl      Box2BrainBottom_Init
@@_8053D2C:
    bl      Box2BrainBottom_Idle
    pop     r0
    bx      r0
    .pool