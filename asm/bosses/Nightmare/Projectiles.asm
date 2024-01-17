NightmareBeamSpawn:				;8060364
    push    r4,r5,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r0,[r0]
    ldr     r1,=0xFFFB
    and     r1,r0
    mov     r4,0
    mov     r5,0
    mov     r3,r12
    add     r3,0x34
    ldrb    r2,[r3]
    mov     r0,4
    orr     r0,r2
    strb    r0,[r3]
    mov     r2,0x80
    lsl     r2,r2,8
    mov     r0,r2
    orr     r1,r0
    mov     r0,r12
    strh    r1,[r0]
    add     r0,0x27
    mov     r1,8
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r2,r12
    add     r2,0x29
    mov     r0,0x10
    strb    r0,[r2]
    ldr     r0,=0xFFF8
    mov     r2,r12
    strh    r0,[r2,0xA]
    strh    r1,[r2,0xC]
    sub     r0,0x18
    strh    r0,[r2,0xE]
    mov     r0,0x20
    strh    r0,[r2,0x10]
    ldr     r0,=Nightmare_0
    str     r0,[r2,0x18]
    strb    r4,[r2,0x1C]
    strh    r5,[r2,0x16]
    mov     r0,r12
    add     r0,0x24
    mov     r1,2
    strb    r1,[r0]
    add     r2,0x22
    mov     r0,3
    strb    r0,[r2]
    add     r2,3
    mov     r0,4
    strb    r0,[r2]
    mov     r0,r12
    add     r0,0x33
    strb    r1,[r0]
    ldr     r0,=0x168  ;laser shot
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    pop     r4,r5
    pop     r0
    bx      r0
.pool

NightmareBeamMove:
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,4]
    sub     r0,0x14
    strh    r0,[r1,4]
	ldrh	r0,[r1]
	mov		r2,2h
	and		r0,r2
	cmp		r0,0h
	bne		@@Return
	strh	r0,[r1]	;kills sprite if offscreen
@@Return:
    bx      r14
.pool

NightmareBeamMain:
;.notice "NightmareBeam AI"
;.notice tohex(.)
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@Spawn
    cmp     r0,2
    beq     @@Move
    b       @@Return
    .pool
@@Spawn:
    bl      NightmareBeamSpawn
    b       @@Return
@@Move:
    bl      NightmareBeamMove
@@Return:
    pop     r0
    bx      r0

NightmareChunkSpawn:
    push    r4,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r1,[r0]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0
    mov     r4,0
    mov     r1,r12
    strh    r0,[r1]
    mov     r2,r12
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,1
    orr     r0,r1
    strb    r0,[r2]
    mov     r1,r12
    add     r1,0x22
    mov     r0,1
    strb    r0,[r1]
    mov		r0,0
    mov     r1,r12
    add     r1,0x21
    strb    r0,[r1]			;0 to BG priority?
    mov     r0,r12
    add     r0,0x25
    strb    r3,[r0]
    ldr     r1,=0xFFFC
    mov     r2,r12
    strh    r1,[r2,0xA]
    mov     r0,4
    strh    r0,[r2,0xC]
    strh    r1,[r2,0xE]
    strh    r0,[r2,0x10]
    strb    r3,[r2,0x1C]
    strh    r4,[r2,0x16]
    mov     r1,r12
    add     r1,0x24
    mov     r0,2
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x2D
    strb    r3,[r0]
    strh    r4,[r2,0x14]
    ldrb    r0,[r2,0x1E]
    mov     r3,r12
    cmp     r0,7
    bls     @@_8060468
    b       @@Kill
@@_8060468:
    lsl     r0,r0,2
    ldr     r1,=@@_8060488
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_8060488:
    .dw @@_80604A8,@@_80604D4,@@_80604DC,@@_80604FC
    .dw @@_806051C,@@_8060548,@@_8060574,@@_80605A0
@@_80604A8:
    ldr     r0,=Nightmare_18
    str     r0,[r3,0x18]
    mov     r1,r3
    add     r1,0x27
    mov     r0,0x18
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x28
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r3
    add     r1,0x2C
    mov     r0,2
    strb    r0,[r1]
    add     r1,2
    mov     r0,0xA
    strb    r0,[r1]
    b       @@Return
    .pool
@@_80604D4:
    ldr     r0,=Nightmare_19
    b       @@_806054A
    .pool
@@_80604DC:
    ldr     r0,=Nightmare_20
    str     r0,[r3,0x18]
    mov     r1,r3
    add     r1,0x27
    mov     r0,0x20
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x10
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x18
    strb    r0,[r1]
    add     r1,3
    b       @@_8060590
    .pool
@@_80604FC:
    ldr     r0,=Nightmare_21
    str     r0,[r3,0x18]
    mov     r1,r3
    add     r1,0x27
    mov     r0,0x1C
    strb    r0,[r1]
    add     r1,1
    mov     r0,8
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x20
    strb    r0,[r1]
    add     r1,3
    b       @@_80605BC
    .pool
@@_806051C:
    ldr     r0,=Nightmare_22
    str     r0,[r3,0x18]
    mov     r0,r3
    add     r0,0x27
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r3
    add     r1,0x29
    mov     r0,0x18
    strb    r0,[r1]
    add     r1,3
    mov     r0,6
    strb    r0,[r1]
    add     r1,2
    mov     r0,2
    strb    r0,[r1]
    b       @@Return
    .pool
@@_8060548:
    ldr     r0,=Nightmare_23
@@_806054A:
    str     r0,[r3,0x18]
    mov     r0,r3
    add     r0,0x27
    mov     r1,0x18
    strb    r1,[r0]
    add     r0,1
    mov     r2,8
    strb    r2,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r3
    add     r1,0x2C
    mov     r0,3
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2E
    strb    r2,[r0]
    b       @@Return
    .pool
@@_8060574:
    ldr     r0,=Nightmare_24
    str     r0,[r3,0x18]
    mov     r0,r3
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    mov     r1,r3
    add     r1,0x28
    mov     r0,8
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x29
    strb    r2,[r0]
    add     r1,4
@@_8060590:
    mov     r0,4
    strb    r0,[r1]
    add     r1,2
    mov     r0,6
    strb    r0,[r1]
    b       @@Return
    .pool
@@_80605A0:
    ldr     r0,=Nightmare_25
    str     r0,[r3,0x18]
    mov     r0,r3
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    mov     r1,r3
    add     r1,0x28
    mov     r0,0xA
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x29
    strb    r2,[r0]
    add     r1,4
@@_80605BC:
    mov     r0,5
    strb    r0,[r1]
    add     r1,2
    mov     r0,4
    strb    r0,[r1]
    b       @@Return
    .pool
@@Kill:
    mov     r0,r12
    strh    r4,[r0]
@@Return:
    pop     r4
    pop     r0
    bx      r0
	
NightmareChunkMove:
    push    r4-r6,r14
    ldr     r1,=CurrSpriteData
    mov     r3,r1
    add     r3,0x2E
    ldrb    r0,[r3]
    mov     r2,r1
    cmp     r0,0
    beq     @@_806061E
    sub     r0,1
    strb    r0,[r3]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@Return
    ldrb    r0,[r2,0x1E]
    cmp     r0,0
    beq     @@_80605FC
    cmp     r0,5
    bne     @@_8060610
@@_80605FC:
    ldrh    r0,[r2,2]
    sub     r0,0x50
    ldrh    r1,[r2,4]
    mov     r2,0x3A
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@Return
    .pool
@@_8060610:
    ldrh    r0,[r2,2]
    sub     r0,0x50
    ldrh    r1,[r2,4]
    mov     r2,0x22
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@Return
@@_806061E:
    mov     r0,0x2D			;31h is Y accel
    add     r0,r0,r2
    mov     r12,r0
    ldrb    r3,[r0]
    ldr     r5,=0x82B0D04  ;2B0D04 in ZM
    lsl     r0,r3,1
    add     r0,r0,r5
    ldrh    r4,[r0]
    mov     r6,0
    ldsh    r1,[r0,r6]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@_8060650
    sub     r1,r3,1
    lsl     r1,r1,1
    add     r1,r1,r5
    ldrh    r0,[r2,2]
    ldrh    r1,[r1]
    add     r0,r0,r1
    b       @@StoreY
    .pool
@@_8060650:
    add     r0,r3,1
    mov     r1,r12
    strb    r0,[r1]
    ldrh    r0,[r2,2]
    add     r0,r0,r4
@@StoreY:
    strh    r0,[r2,2]
    ldrb    r0,[r2,0x1E]
    cmp     r0,4
    bhi     @@_806066E
    mov     r1,r2
    add     r1,0x2C
    ldrh    r0,[r2,4]
    ldrb    r1,[r1]
    add     r0,r0,r1
    b       @@StoreX
@@_806066E:
    mov     r0,r2
    add     r0,0x2C		;30h is X accel
    ldrb    r1,[r0]
    ldrh    r0,[r2,4]
    sub     r0,r0,r1
@@StoreX:
    strh    r0,[r2,4]
@@Return:
    pop     r4-r6
    pop     r0
    bx      r0

	
NightmareChunkMain:
;.notice "NightmareChunk AI"
;.notice tohex(.)
    push    r14
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,0x26
    mov     r1,1
    strb    r1,[r2]
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@Spawn
    cmp     r0,2
    beq     @@Move
    b       @@Return
    .pool
@@Spawn:
    bl      NightmareChunkSpawn
    b       @@Return
@@Move:
    bl      NightmareChunkMove
@@Return:
    pop     r0
    bx      r0
	
	