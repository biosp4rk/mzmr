ChangeSuit:
	ldr     r6,=Equipment
	ldrb    r0,[r6,0x12]
	push    r0
	cmp     r0,1
	bne     @@Return
	; if full suit
	ldrb    r0,[r6,0xF]
	mov     r1,0x20
	and     r0,r1
	cmp     r0,0
	bne     @@Return
	; and not have gravity
	strb    r0,[r6,0x12]
@@Return:
	add     sp,-4h
	bx      r14
	.pool
	
RestoreSuit:
	add     sp,4h
	pop     r0
	ldr     r1,=Equipment
	strb    r0,[r1,0x12]
    pop     r3-r5
	bx      r14
	.pool

StatusScreen:
	ldr     r0,=Equipment
	ldrb    r2,[r0,0x12]
	cmp     r2,2
	beq     @@Return		; return r2 = 2 if suitless
	ldrb    r2,[r0,0xF]
	mov     r1,0x20
	and     r2,r1
	cmp     r2,0
	beq     @@Return		; return r2 = 0 if no gravity
	; if have gravity
	mov     r2,1			; return r2 = 1 if gravity
@@Return:
	bx      r14
	.pool
	
SwitchText:
	push    r14
	; check for full suit
	ldr     r0,=Equipment
	ldrb    r0,[r0,0x12]
	cmp     r0,1
	beq     @@ReplacedCode
	; check if unknown item
	mov     r0,r8
	cmp     r0,0xC
	beq     @@IsUnknown
	cmp     r0,0xF
	beq     @@IsUnknown
	cmp     r0,0x14
	bne     @@ReplacedCode
@@IsUnknown:
	ldr     r0,=MessageInfo
	ldrb    r1,[r0,0xC]
	cmp     r1,2
	bne     @@ReplacedCode
	mov     r1,0x23
	strb    r1,[r0,0xA]
@@ReplacedCode:
	bl      0x806F28C
	ldr     r1,=MessageInfo
	mov     r2,r8
	strb    r2,[r1,0xA]
	pop     r1
	bx      r1
	.pool

GetJingleNumber:
	ldr     r0,=Equipment
	ldrb    r0,[r0,0x12]
	cmp     r0,1
	beq     @@FullSuit
	mov     r0,0x42
	b       @@Return
@@FullSuit:
	mov     r0,0x37
@@Return:
	bx      r14
	.pool

GetSoundNumber:
	ldr     r0,=Equipment
	ldrb    r0,[r0,0x12]
	cmp     r0,1
	beq     @@FullSuit
	ldr     r0,=0x20F
	b       @@Return
@@FullSuit:
	ldr     r0,=0x1F7
@@Return:
	bx      r14
	.pool
