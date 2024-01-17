MegaXShield_Init:
    push    r4,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r1,[r0]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0
    mov     r2,0
    mov     r1,r12
    strh    r0,[r1]
    add     r1,0x22
    mov     r0,3
    strb    r0,[r1]
    ldr     r1,=BackupOfIORegisters
    ldrb    r1,[r1,0xA]
    and     r0,r1
    mov     r1,r12
    add     r1,0x21
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r1,0xC
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    ldr     r1,=0xFFE0
    mov     r4,r12
    strh    r1,[r4,0xA]
    mov     r0,0x20
    strh    r0,[r4,0xC]
    strh    r1,[r4,0xE]
    strh    r0,[r4,0x10]
    ldr     r0,=CoreXOAM_5
    str     r0,[r4,0x18]
    strb    r3,[r4,0x1C]
    strh    r2,[r4,0x16]
    mov     r0,r12
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    ldr     r1,=SecondarySpriteStats
    ldrb    r0,[r4,0x1D]
    lsl     r2,r0,4
	lsl		r0,r0,1
	add		r0,r0,r2
    add     r0,r0,r1
    ldrh    r0,[r0]
    strh    r0,[r4,0x14]
    mov     r0,r12
    add     r0,0x24
	mov		r2,2
    strb    r2,[r0]
    mov     r0,0x80
    lsl     r0,r0,1
    strh    r0,[r4,0x12]
    mov     r0,r12
    add     r0,0x2C
    strb    r3,[r0]
    ldrb    r0,[r4,0x1E]
    lsl     r0,r0,5
    mov     r1,r12
    add     r1,0x2F
    strb    r0,[r1]
    pop     r4
    pop     r0
    bx      r0
    .pool


MegaXShield_Alive:
    push    r4-r7,r14
    mov     r7,r8
    push    r7
	add		sp,-4
	bl		BlockPlasma
    ldr     r0,=CurrSpriteData
    ldrh    r5,[r0,0x14]
    mov     r4,r0
    cmp     r5,0
    bne     @@_8057ADC
    mov		r0,20h
	str     r0,[sp] 
	mov		r0,0
	mov		r3,1
	ldrh	r1,[r4,2h]
	ldrh	r2,[r4,4h]
	ldr		r4,=SpriteDeath + 1
	bl		WrapperR4
    b       @@_8057BD6
    .pool
@@_8057ADC:
    mov     r1,r4
    add     r1,0x2F
    ldrb    r0,[r1]
    add     r0,3
    strb    r0,[r1]
    mov     r2,r4
    add     r2,0x2C
    ldrb    r0,[r2]
    cmp     r0,0
    beq     @@_8057B08
    ldrh    r1,[r4,0x12]
    ldr     r0,=0x13F
    cmp     r1,r0
    bhi     @@_8057B04
    add     r0,r1,2
    strh    r0,[r4,0x12]
    b       @@_8057B18
    .pool
@@_8057B04:
    mov     r0,0
    b       @@_8057B16
@@_8057B08:
    ldrh    r0,[r4,0x12]
    cmp     r0,0xC0
    bls     @@_8057B14
    sub     r0,2
    strh    r0,[r4,0x12]
    b       @@_8057B18
@@_8057B14:
    mov     r0,1
@@_8057B16:
    strb    r0,[r2]
@@_8057B18:
    mov     r0,r4
    add     r0,0x23
    ldrb    r6,[r0]
    ldrh    r3,[r4,0x12]
    add     r0,0xC
    ldrb    r7,[r0]
    ldr     r1,=SineYValues
    lsl     r0,r7,1
    add     r0,r0,r1
    mov     r5,0
    ldsh    r2,[r0,r5]
    mov     r8,r1
    cmp     r2,0
    bge     @@_8057B64
    neg     r2,r2
    lsl     r1,r3,0x10
    asr     r0,r1,0x10
    mul     r0,r2
    mov     r5,r1
    cmp     r0,0
    bge     @@_8057B44
    add     r0,0xFF
@@_8057B44:
    lsl     r0,r0,8
    lsr     r3,r0,0x10
    ldr     r1,=SpriteData
    lsl     r2,r6,3
    sub     r0,r2,r6
    lsl     r0,r0,3
    add     r0,r0,r1
    ldrh    r0,[r0,2]
    sub     r0,r0,r3
    strh    r0,[r4,2]
    mov     r12,r1
    b       @@_8057B8A
    .pool
@@_8057B64:
    lsl     r1,r3,0x10
    asr     r0,r1,0x10
    mul     r2,r0
    mov     r5,r1
    cmp     r2,0
    bge     @@_8057B72
    add     r2,0xFF
@@_8057B72:
    lsl     r1,r2,8
    ldr     r2,=SpriteData
    lsl     r3,r6,3
    sub     r0,r3,r6
    lsl     r0,r0,3
    add     r0,r0,r2
    lsr     r1,r1,0x10
    ldrh    r0,[r0,2]
    add     r1,r1,r0
    strh    r1,[r4,2]
    mov     r12,r2
    mov     r2,r3
@@_8057B8A:
    mov     r0,r7
    add     r0,0x40
    lsl     r0,r0,1
    add     r0,r8
    mov     r3,0
    ldsh    r1,[r0,r3]
    cmp     r1,0
    bge     @@_8057BBC
    neg     r1,r1
    asr     r0,r5,0x10
    mul     r0,r1
    cmp     r0,0
    bge     @@_8057BA6
    add     r0,0xFF
@@_8057BA6:
    lsl     r0,r0,8
    lsr     r1,r0,0x10
    sub     r0,r2,r6
    lsl     r0,r0,3
    add     r0,r12
    ldrh    r0,[r0,4]
    sub     r0,r0,r1
    strh    r0,[r4,4]
    b       @@_8057BD6
    .pool
@@_8057BBC:
    asr     r0,r5,0x10
    mul     r0,r1
    cmp     r0,0
    bge     @@_8057BC6
    add     r0,0xFF
@@_8057BC6:
    lsl     r1,r0,8
    sub     r0,r2,r6
    lsl     r0,r0,3
    add     r0,r12
    lsr     r1,r1,0x10
    ldrh    r0,[r0,4]
    add     r1,r1,r0
    strh    r1,[r4,4]
@@_8057BD6:
	add		sp,4
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0

;.notice "MegaX Orb AI"
;.notice tohex(.)
MegaXShield_AI:
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@_8058524
    b		@@_805852A
    .pool
@@_8058524:
    bl      MegaXShield_Init
    b       @@_805852E
@@_805852A:
    bl      MegaXShield_Alive
@@_805852E:
    pop     r0
    bx      r0