f8035b4c:		;8035b4c
	push		r4,r14
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r4,0x4]
	ldr		r1,[r4]
	lsl		r0,r0,0x3
	add		r0,r0,r1
	ldr		r3,[r0]
	ldr		r2,=CurrSpriteData
	ldrb		r1,[r2,0x1E]	;Room slot/part number
	lsl		r0,r1,0x1
	add		r0,r0,r1
	lsl		r0,r0,0x1
	add		r0,r0,r3
	ldrh		r0,[r0]
	ldr		r1,=BOX1OAMTables
	lsl		r0,r0,0x2
	add		r0,r0,r1
	ldr		r1,[r2,0x18]
	ldr		r0,[r0]
	cmp		r1,r0
	beq		@@_8035b7e
	str		r0,[r2,0x18]
	mov		r0,0x0
	strb		r0,[r2,0x1C]
	strh		r0,[r2,0x16]
@@_8035b7e:		;8035b7e
	ldrb		r1,[r2,0x1E]
	lsl		r0,r1,0x1
	add		r0,r0,r1
	lsl		r0,r0,0x1
	add		r0,r0,r3
	ldrh		r0,[r0,0x2]
	ldrh		r1,[r4,0x6]		;y, was 8
	add		r0,r0,r1
	strh		r0,[r2,0x2]
	ldrb		r1,[r2,0x1E]
	lsl		r0,r1,0x1
	add		r0,r0,r1
	lsl		r0,r0,0x1
	add		r0,r0,r3
	ldrh		r0,[r0,0x4]
	ldrh		r4,[r4,0x8]		;x, was a
	add		r0,r0,r4
	strh		r0,[r2,0x4]
	pop		r4
	pop		r0
	bx		r0
	.pool

f8035bb4:		;8035bb4
	push		r4-r7,r14
	mov		r7,r10
	mov		r6,r9
	mov		r5,r8
	push		r5-r7
	lsl		r0,r0,0x10
	lsr		r7,r0,0x10
	mov		r10,r7
	lsl		r1,r1,0x18
	lsr		r5,r1,0x18
	mov		r9,r5
	mov		r0,0x0
	mov		r8,r0
	ldr		r6,=CurrSpriteData
	ldrh		r1,[r6]			;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8035c12
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r4,0x6]		;y, was 8
	sub		r0,0x10
	ldrh		r1,[r4,0x8]		;x, was a
	add		r1,0x6E
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8035c0c
	mov		r0,r6
	add		r0,0x24				;pose
	strb		r5,[r0]
	mov		r1,0x1
	mov		r8,r1
	b		@@_8035c48
	.pool
@@_8035c0c:		;8035c0c
	ldrh		r0,[r4,0x8]		;x, was a
	add		r0,r7,r0
	b		@@_8035c46
@@_8035c12:		;8035c12
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r4,0x6]		;y, was 8
	sub		r0,0x10
	ldrh		r1,[r4,0x8]		;x, was a
	sub		r1,0x6E
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8035c40
	mov		r0,r6
	add		r0,0x24				;pose
	mov		r1,r9
	strb		r1,[r0]
	mov		r0,0x1
	mov		r8,r0
	b		@@_8035c48
	.pool
@@_8035c40:		;8035c40
	ldrh		r0,[r4,0x8]		;x, was a
	mov		r1,r10
	sub		r0,r0,r1
@@_8035c46:		;8035c46
	strh		r0,[r4,0x8]		;x, was a
@@_8035c48:		;8035c48
	mov		r0,r8
	pop		r3-r5
	mov		r8,r3
	mov		r9,r4
	mov		r10,r5
	pop		r4-r7
	pop		r1
	bx		r1

BOX1Initialize:		;8035c58
	push		r4-r7,r14
	mov		r3, r8
	push		r3
	add		sp,-0xC
	ldr		r3, =SpriteSpawnSecondary+1
	mov		r8, r3
	;bl		f8060d50
	mov		r0, 3
	bl		SetnCheckEvent
	mov		r1,r0
	cmp		r1,0x0
	beq		@@_8035c70
	ldr		r0,=CurrSpriteData
	mov		r1, 0
	strh		r1,[r0]
	b		@@return
	.pool
@@_8035c70:		;8035c70
	ldr		r0, =DoorUnlockTimer
	mov		r1, 1
	strb	r1,[r0]
	ldr		r7,=CurrSpriteData
	mov		r0,r7
	add		r0,0x25		;collision
	mov		r5,0x0
	strb		r5,[r0]
	ldrh		r0,[r7]	;status
	mov		r1,0x80
	lsl		r1,r1,0x8
	mov		r3,r1
	mov		r6,0x0
	orr		r3,r0
	strh		r3,[r7]
	mov		r0,r7
	add		r0,0x27		;Draw distance top offset
	mov		r1,0x10
	strb		r1,[r0]
	add		r0,0x1		;Draw distance bottom offset
	strb		r1,[r0]
	add		r0,0x1		;Draw distance horizontal offset
	strb		r1,[r0]
	ldr		r0,=0xFFD8
	strh		r0,[r7,0xA]	;HitBOX1 top offset
	mov		r0,0x40
	strh		r0,[r7,0xC]
	ldr		r0,=0xFFD0
	strh		r0,[r7,0xE]
	mov		r0,0x30
	strh		r0,[r7,0x10]
	mov		r0,r7
	add		r0,0x2E		;Work Variable, was 2D
	mov		r1,0x7
	strb		r1,[r0]
	mov		r2,r7
	add		r2,0x22		;Draw order
	mov		r0,0xC
	strb		r0,[r2]
	add		r2,0x11		;Frozen palette row offset, was 35
	mov		r0,0x2
	strb		r0,[r2]
	strb		r1,[r7,0x1E]	;Room slot/part number
	ldr		r2,=PrimarySpriteStats
	ldrb		r1,[r7,0x1D]	;Sprite ID
	lsl		r0,r1,0x4
	lsl		r1,r1,0x1
	add		r0, r1
	add		r0,r0,r2
	ldrh		r0,[r0]
	strh		r0,[r7,0x14]	;Health
	mov		r2,r7
	add		r2,0x32		;Property, was 34
	ldrb		r1,[r2]
	mov		r0,0x40
	orr		r0,r1
	strb		r0,[r2]
	ldr		r0,=BOX1OAM31
	str		r0,[r7,0x18]
	strb		r6,[r7,0x1C]	;Animation duration counter
	strh		r5,[r7,0x16]	;Current animation frame
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r7,0x2]		;Y
	strh		r0,[r4,0x6]		;y, was 8
	ldrh		r0,[r7,0x4]		;X
	strh		r0,[r4,0x8]		;x, was a
	ldr		r0,=BOX1SubOAM01
	str		r0,[r4]
	strb		r6,[r4,0xC]		;animationDurationCounter, was 6
	strh		r5,[r4,0x4]		;currentAnimationFrame
	strb		r6,[r4,0xE]		;workVariable2, was e
	mov		r0,r7
	add		r0,0x2D				;Timer 2, was 2F
	strb		r6,[r0]
	ldr		r0,=0xFDFF
	and		r3,r0
	strh		r3,[r7]
	mov		r1,r7
	add		r1,0x24				;pose
	mov		r0,0x3F
	strb		r0,[r1]
	ldrb		r2,[r7,0x1F]	;Spriteset graphics slot
	mov		r6,r7
	add		r6,0x23				;Primary sprite RAM slot
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x0				;Part 0, Left body
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x1				;Part 1, Left foot
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x2				;Part 2, Right body
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x3				;Part 3, Right foot
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x4				;Part 4, Left armor
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x5				;Part 5, Right armor
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x6				;Part 6, Center
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x8
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0x9
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0xA
	bl		WrapperR8
	ldrb		r2,[r7,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x6]		;y, was 8
	str		r0,[sp]
	ldrh		r0,[r4,0x8]		;x, was a
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1PartSpriteID
	mov		r1,0xB
	bl		WrapperR8
@@return:		;8035e02
	add		sp,0xC
	pop		r3
	mov		r8, r3
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1WaitingToEmergeStart:		;8035e2c
	push		r4,r5,r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM02
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r4,0x0
	strh		r0,[r1,0x4]		;currentAnimationFrame
	mov		r2,0x80
	lsl		r2,r2,0x1
	mov		r0,r2
	ldrh		r2,[r1,0x8]		;x, was a
	add		r0,r0,r2
	strh		r0,[r1,0x8]		;x, was a
	ldr		r5,=CurrSpriteData
	mov		r1,r5
	add		r1,0x24				;pose
	mov		r0,0x40
	strb		r0,[r1]
	mov		r0,r5
	add		r0,0x2C				;Timer 1, was 2E
	strb		r4,[r0]
	ldr		r0,=400			;music, was 26d
	ldr		r1, =SoundPlayNotAlreadyPlaying+1
	bl		WRapperR1
	mov		r0,0x28
	mov		r1,0x81
	ldr		r2, =ScreenShakeStartHorizontal+1
	bl		WRapperR2
	mov		r0,r5
	add		r0,0x2F				;was 31
	strb		r4,[r0]
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1WaitingToEmerge:		;8035e84
	push		r4-r6,r14
	ldr		r6,=CurrSpriteData
	mov		r4,r6
	add		r4,0x2F				;was 31
	ldrb		r0,[r4]
	add		r0,0x1
	strb		r0,[r4]
	lsl		r0,r0,0x18
	lsr		r0,r0,0x18
	cmp		r0,0x3C
	bls		@@_8035eac
	ldr		r0,=400			;music, was 26d
	ldr		r1, =SoundPlayNotAlreadyPlaying+1
	bl		WRapperR1
	mov		r0,0x28
	mov		r1,0x81
	ldr		r2, =ScreenShakeStartHorizontal+1
	bl		WRapperR2
	mov		r0,0x0
	strb		r0,[r4]
@@_8035eac:		;8035eac
	ldrh		r5,[r6,0x2]		;y
	ldrh		r4,[r6,0x4]		;x
	mov		r0,r6
	add		r0,0x2C				;Timer 1, was 2E
	ldrb		r0,[r0]
	cmp		r0,0x24
	bls		@@_8035ebc
	b		@@_8035fc2
@@_8035ebc:		;8035ebc
	lsl		r0,r0,0x2
	ldr		r1,=@@Table
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@Table:		;8035ed4
	.dw @@_8035f68
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035f6e
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035f74
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035f7e
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035f88
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035f98
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fa2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035faa
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fc2
	.dw @@_8035fba
@@_8035f68:
	mov     r0,r5
	mov     r1,r4
	b       @@_8035F90
@@_8035f6e:		;8035f6e
	mov		r0,r5
	mov		r1,r4
	b		@@_8035FB2
@@_8035f74:		;8035f74
	mov		r0,r5
	sub		r0,0x1C
	mov		r1,r4
	add		r1,0x1C
	b		@@_8035f90
@@_8035f7e:		;8035f7e
	mov		r0,r5
	add		r0,0x20
	mov		r1,r4
	sub		r1,0x20
	b		@@_8035fb2
@@_8035f88:		;8035f88
	mov		r0,r5
	sub		r0,0x1C
	mov		r1,r4
	sub		r1,0x2E
@@_8035f90:		;8035f90
	mov		r2,0x36			;Tall explosion/smoke, was 2e
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	b		@@_8035fc2
@@_8035f98:		;8035f98
	mov		r0,r5
	add		r0,0x40
	mov		r1,r4
	sub		r1,0x40
	b		@@_8035fb2
@@_8035fa2:		;8035fa2
	mov		r0,r5
	add		r0,0x58
	mov		r1,r4
	b		@@_8035fb2
@@_8035faa:		;8035faa
	mov		r0,r5
	sub		r0,0x5A
	mov		r1,r4
	add		r1,0x10
@@_8035fb2:		;8035fb2
	mov		r2,0x22			;Explosion 6, was 2f
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	b		@@_8035fc2
@@_8035fba:		;8035fba
	ldr		r0,=CurrSpriteData
	add		r0,0x2C				;Timer 1, was 2E
	mov		r1,0xFF
	strb		r1,[r0]
@@_8035fc2:		;8035fc2
	ldr		r6,=CurrSpriteData
	mov		r1,r6
	add		r1,0x2C				;Timer 1, was 2E
	ldrb		r0,[r1]
	add		r0,0x1
	strb		r0,[r1]
	mov		r1,0x80
	lsl		r1,r1,0x2
	mov		r0,r1
	ldr		r2, =SpriteUtilCheckSamusNearSpriteLeftRight+1
	bl		WRapperR2
	cmp		r0,0x4
	bne		@@return
	mov		r0,r6
	add		r0,0x24				;pose
	mov		r1,0x41
	strb		r1,[r0]
	mov		r1,r4
	sub		r1,0xA0
	mov		r0,r5
	mov		r2,0x22			;Explosion 6, was 2f
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	mov		r0,BOX1Music
	mov		r1,0
	ldr		r3, =PlayMusic+1
	bl		WRapperR3
@@return:		;8035ff8
	pop		r4-r6
	pop		r0
	bx		r0
	.pool

BOX1FirstJumpStart:		;8036004
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM03
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r2,0x0
	strh		r0,[r1,0x4]		;currentAnimationFrame
	ldr		r3,=CurrSpriteData
	mov		r1,r3
	add		r1,0x24				;pose
	mov		r0,0x42
	strb		r0,[r1]
	mov		r0,r3
	add		r0,0x2F				;was 31
	strb		r2,[r0]
	ldrh		r1,[r3]			;status
	ldr		r0,=0xFDFF
	and		r0,r1
	strh		r0,[r3]
	ldr		r0,=0x2A0		;music,was 265
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r0
	bx		r0
	.pool
	
BOX1FirstJump:		;803604c
	push		r4,r5,r14
	ldr		r4,=CurrSpriteData
	mov		r0,0x2F				;was 31
	add		r0,r0,r4
	mov		r12,r0
	ldrb		r2,[r0]
	ldr		r1,=BOX1Table1
	lsl		r0,r2,0x1
	add		r0,r0,r1
	ldrh		r3,[r0]
	mov		r5,0x0
	ldsh		r1,[r0,r5]
	ldr		r0,=0x7FFF
	cmp		r1,r0
	bne		@@_80360a4
	mov		r1,r4
	add		r1,0x24			;pose
	mov		r0,0x19
	strb		r0,[r1]
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	ldrh		r1,[r1,0x8]		;x, was a
	add		r1,0xB4
	mov		r2,0x38				;Tall smoke 2, was 35
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	ldr		r0,=0x291		;music,was 266
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	mov		r0,0x3C
	mov		r1,0x81
	ldr		r2, =ScreenShakeStartVertical+1
	bl		WRapperR2
	b		@@return
	.pool
@@_80360a4:		;80360a4
	add		r0,r2,1
	mov		r1,r12
	strb		r0,[r1]
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	add		r0,r0,r3
	strh		r0,[r1,0x6]		;y, was 8
	ldrh		r0,[r1,0x8]		;x, was a
	sub		r0,0xA
	strh		r0,[r1,0x8]		;x, was a
@@return:		;80360b8
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1WaitingToRunStart:		;80360c4
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM04
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r3,0x0
	strh		r0,[r1,0x4]		;currentAnimationFrame
	ldr		r0,=CurrSpriteData
	mov		r2,r0
	add		r2,0x24				;pose
	mov		r1,0x18
	strb		r1,[r2]
	add		r0,0x2C				;Timer 1, was 2E
	strb		r3,[r0]
	ldr		r0,=0x26A			;music??
	ldr		r1, =PlaySound+1
	;bl		WRapperR1
	pop		r0
	bx		r0
	.pool
	
BOX1WaitingToRun:		;80360fc
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036120
	ldr		r1,=CurrSpriteData
	mov		r2,r1
	add		r2,0x2C				;Timer 1, was 2E
	ldrb		r0,[r2]
	add		r0,0x1
	strb		r0,[r2]
	lsl		r0,r0,0x18
	lsr		r0,r0,0x18
	cmp		r0,0x1
	bne		@@_8036120
	add		r1,0x24
	mov		r0,0x19				;pose
	strb		r0,[r1]
@@_8036120:		;8036120
	ldr		r1,=CurrSpriteData
	mov		r0,r1
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@return
	add		r1,0x24				;pose
	mov		r0,0x3B
	strb		r0,[r1]
@@return:		;8036132
	pop		r0
	bx		r0
	.pool

BOX1SlowRunningStart:		;803613c
	push		r14
	ldr		r0, =SpriteUtilMakeSpriteFaceSamusDirection+1
	bl		WRapperR0
	ldr		r0,=CurrSpriteData
	ldrh		r1,[r0]		;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036164
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM05
	b		@@_8036168
	.pool
@@_8036164:		;8036164
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM05
@@_8036168:		;8036168
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r3,0x0
	strh		r0,[r1,0x4]		;currentAnimationFrame
	ldr		r0,=CurrSpriteData
	mov		r2,r0
	add		r2,0x24				;pose
	mov		r1,0x1A
	strb		r1,[r2]
	add		r0,0x2C				;Timer 1, was 2E
	strb		r3,[r0]
	pop		r0
	bx		r0
	.pool

BOX1SlowRunning:		;8036190
	push		r4,r5,r14
	ldr		r0,=SubSpriteData1
	ldrh	r1, [r0, 4]		;currentAnimationFrame
	mov		r2, 3
	cmp		r1, r2
	bne		@@_80361a6
	ldrb	r1, [r0, 0xC]
	mov		r2, 1
	cmp		r1, r2
	bne		@@_80361a6
	;ldr		r0,[r0,0x4]		;currentAnimationFrame+animationDurationCounter
	;ldr		r1,=0x00FFFFFF
	;and		r0,r1
	;ldr		r1,=0x0010003
	;cmp		r0,r1
	;bne		@@_80361a6
	ldr		r0,=0x2A4		;music,was 262
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_80361a6:		;80361a6
	ldr		r5,=CurrSpriteData
	mov		r4,r5
	add		r4,0x2C				;Timer 1, was 2E
	ldrb		r0,[r4]
	mov		r1,0x37
	bl		f8035bb4
	lsl		r0,r0,0x18
	cmp		r0,0x0
	bne		@@_80361ea
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_80361d8
	ldrb		r0,[r4]
	add		r0,0x1
	strb		r0,[r4]
	lsl		r0,r0,0x18
	lsr		r0,r0,0x18
	cmp		r0,0x7
	bne		@@_80361d8
	mov		r1,r5
	add		r1,0x24				;pose
	mov		r0,0x1B
	strb		r0,[r1]
@@_80361d8:		;80361d8
	ldr		r1,=CurrSpriteData
	mov		r0,r1
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_80361ea
	add		r1,0x24				;pose
	mov		r0,0x3B
	strb		r0,[r1]
@@_80361ea:		;80361ea
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1FastRunningStart:		;8036204
	push		r14
	ldr		r2,=CurrSpriteData
	ldrh		r1,[r2]		;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036228
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM06
	b		@@_803622c
	.pool
@@_8036228:		;8036228
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM07
@@_803622c:		;803622c
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x1C
	strb		r0,[r1]
	add		r1,0x8				;Timer 1, was 2E
	mov		r0,0xA
	strb		r0,[r1]
	pop		r0
	bx		r0
	.pool

BOX1FastRunning:		;8036250
	push		r4,r14
	ldr		r4,=SubSpriteData1
	ldr		r0,[r4,0x4]
	ldr		r1,=0xFFFFFF
	and		r0,r1
	ldr		r1,=0x10003
	cmp		r0,r1
	bne		@@_8036266
	ldr		r0,=0x2A4		;music,was 262
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_8036266:		;8036266
	mov		r0,0x8
	mov		r1,0x37
	bl		f8035bb4
	lsl		r0,r0,0x18
	cmp		r0,0x0
	bne		@@_80362cc
	ldr		r2,=CurrSpriteData
	mov		r1,r2
	add		r1,0x2C				;Timer 1, was 2E
	ldrb		r0,[r1]
	cmp		r0,0x0
	beq		@@_8036298
	sub		r0,0x1
	b		@@_80362dc
	.pool
@@_8036298:		;8036298
	ldrh		r1,[r2]			;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_80362b8
	ldrh		r0,[r4,0x8]		;x, was a
	sub		r0,0xC8
	ldr		r1,=SamusData
	ldrh		r1,[r1,0x12]	;X position, was 16
	cmp		r0,r1
	ble		@@_80362cc
	b		@@_80362c4
	.pool
@@_80362b8:		;80362b8
	ldrh		r0,[r4,0x8]		;x, was a
	add		r0,0xC8
	ldr		r1,=SamusData
	ldrh		r1,[r1,0x12]	;X position, was 16
	cmp		r0,r1
	bge		@@_80362cc
@@_80362c4:		;80362c4
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x1D
	strb		r0,[r1]
@@_80362cc:		;80362cc
	ldr		r1,=CurrSpriteData
	mov		r0,r1
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_80362de
	add		r1,0x24
	mov		r0,0x3B
@@_80362dc:		;80362dc
	strb		r0,[r1]
@@_80362de:		;80362de
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1SkiddingStart:		;80362ec
	push		r14
	ldr		r2,=CurrSpriteData
	ldrh		r1,[r2]		;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036310
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM08
	b		@@_8036314
	.pool
@@_8036310:		;8036310
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM09
@@_8036314:		;8036314
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x1E
	strb		r0,[r1]
	add		r1,0x9				;Timer 1, was 2e
	mov		r0,0x20
	strb		r0,[r1]
	ldr		r0,=0x26D		;music,was 263
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1Skidding:		;8036340
	push		r4,r5,r14
	ldr		r4,=CurrSpriteData
	mov		r5,r4
	add		r5,0x2C				;Timer 1, was 2e
	ldrb		r0,[r5]
	lsr		r0,r0,0x2
	mov		r1,0x1F
	cmp		r0,0x5
	bls		@@_8036354
	mov		r1,0x37
@@_8036354:		;8036354
	bl		f8035bb4
	lsl		r0,r0,0x18
	cmp		r0,0x0
	bne		@@_8036384
	ldrb		r0,[r5]
	sub		r0,0x1
	strb		r0,[r5]
	lsl		r0,r0,0x18
	cmp		r0,0x0
	bne		@@_8036372
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x1F
	strb		r0,[r1]
@@_8036372:		;8036372
	mov		r0,r4
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8036384
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x3B
	strb		r0,[r1]
@@_8036384:		;8036384
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1StoppedSkiddingStart:		;8036390
	push		r14
	ldr		r2,=CurrSpriteData
	ldrh		r1,[r2]			;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_80363b4
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM10
	b		@@_80363b8
	.pool
@@_80363b4:		;80363b4
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM11
@@_80363b8:		;80363b8
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x20
	strb		r0,[r1]
	pop		r0
	bx		r0
	.pool

fBOX1StoppedSkidding:		;BOX1StoppedSkidding
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_80363f4
	ldr		r1,=CurrSpriteData
	mov		r2,r1
	add		r2,0x24				;pose
	mov		r0,0x3B
	strb		r0,[r2]
	add		r1,0x2D				;Timer 2, was 2F
	mov		r0,0x3
	b		@@_8036404
	.pool
@@_80363f4:		;80363f4
	ldr		r1,=CurrSpriteData
	mov		r0,r1
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8036406
	add		r1,0x24				;pose
	mov		r0,0x3B
@@_8036404:		;8036404
	strb		r0,[r1]
@@_8036406:		;8036406
	pop		r0
	bx		r0
	.pool

BOX1BonkingStart:		;8036410
	push		r14
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	sub		r0,0x10
	mov		r3,0x0
	mov		r2,0x0
	strh		r0,[r1,0x6]		;y, was 8
	ldr		r0,=BOX1SubOAM03
	str		r0,[r1]
	strb		r3,[r1,0xC]		;animationDurationCounter, was 6
	strh		r2,[r1,0x4]
	ldr		r2,=CurrSpriteData
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x38
	strb		r0,[r1]
	mov		r0,r2
	add		r0,0x2F				;was 31
	strb		r3,[r0]
	ldrh		r0,[r2]			;status
	mov		r3,0x80
	lsl		r3,r3,0x2
	mov		r1,r3
	eor		r0,r1
	strh		r0,[r2]
	ldr		r0,=0x291		;music,was 267
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	mov		r0,0x14
	mov		r1,0x81
	ldr		r2, =ScreenShakeStartHorizontal+1
	bl		WRapperR2
	pop		r0
	bx		r0
	.pool

BOX1Bonking:		;8036464
	push		r4-r7,r14
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r4,0x6]		;y, was 8
	ldrh		r1,[r4,0x8]		;x, was a
	ldr		r2, =SpriteUtilCheckVerticalCollisionAtPositionSlopes+1
	bl		WRapperR2
	mov		r1,r0
	ldr		r0,=PreviousVerticalCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8036494
	strh		r1,[r4,0x6]		;y, was 8
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x4B
	strb		r1,[r0]
	b		@@_80364f8
	.pool
@@_8036494:		;8036494
	ldr		r2,=CurrSpriteData
	mov		r0,0x2F				;was 31
	add		r0,r0,r2
	mov		r12,r0
	ldrb		r3,[r0]
	ldr		r6,=BOX1Table2
	lsl		r0,r3,0x1
	add		r0,r0,r6
	ldrh		r5,[r0]
	mov		r7,0x0
	ldsh		r1,[r0,r7]
	ldr		r0,=0x7FFF
	cmp		r1,r0
	bne		@@_80364cc
	sub		r1,r3,1
	lsl		r1,r1,0x1
	add		r1,r1,r6
	ldrh		r0,[r4,0x6]		;y, was 8
	ldrh		r1,[r1]
	add		r0,r0,r1
	b		@@_80364d6
	.pool
@@_80364cc:		;80364cc
	add		r0,r3,1
	mov		r1,r12
	strb		r0,[r1]
	ldrh		r0,[r4,0x6]		;y, was 8
	add		r0,r0,r5
@@_80364d6:		;80364d6
	strh		r0,[r4,0x6]		;y, was 8
	ldrh		r1,[r2]			;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_80364f0
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x8]		;x, was a
	add		r0,0x6
	b		@@_80364f6
	.pool
@@_80364f0:		;80364f0
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x8]		;x, was a
	sub		r0,0x6
@@_80364f6:		;80364f6
	strh		r0,[r1,0x8]		;x, was a
@@_80364f8:		;80364f8
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1LandingFromBonkStart:		;8036504
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM12
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r2,0x0
	strh		r0,[r1,0x4]
	ldr		r3,=CurrSpriteData
	mov		r1,r3
	add		r1,0x24				;pose
	mov		r0,0x4C
	strb		r0,[r1]
	mov		r0,r3
	add		r0,0x2D				;Timer 2, was 2F
	strb		r2,[r0]
	add		r0,0x2				;was 31
	strb		r2,[r0]
	ldr		r0,=0x1E6			;music, was 266
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1LandingFromBonk:		;8036544
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036556
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x17
	strb		r1,[r0]
@@_8036556:		;8036556
	pop		r0
	bx		r0
	.pool

BOX1LandingStart:		;8036560
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM12
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r3,0x0
	strh		r0,[r1,0x4]
	ldr		r0,=CurrSpriteData
	mov		r2,r0
	add		r2,0x24				;pose
	mov		r1,0x3A
	strb		r1,[r2]
	add		r0,0x2F				;was 31
	strb		r3,[r0]
	ldr		r0,=0x1E6			;music, was 266
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1Landing:		;8036598
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_80365cc
	ldr		r1,=CurrSpriteData
	mov		r3,r1
	add		r3,0x2D				;Timer 2, was 2F
	ldrb		r0,[r3]
	cmp		r0,0x0
	bne		@@_80365b8
	add		r1,0x24				;pose
	mov		r0,0x27
	b		@@_80365ca
	.pool
@@_80365b8:		;80365b8
	sub		r0,0x1
	strb		r0,[r3]
	mov		r2,0x7F
	and		r2,r0
	cmp		r2,0x0
	bne		@@_80365c6
	strb		r2,[r3]
@@_80365c6:		;80365c6
	add		r1,0x24				;pose
	mov		r0,0x3B
@@_80365ca:		;80365ca
	strb		r0,[r1]
@@_80365cc:		;80365cc
	pop		r0
	bx		r0

BOX1FinishedCrawlingStart:		;80365d0
	push		r4,r14
	ldr		r2,=SubSpriteData1
	ldr		r0,=BOX1SubOAM02
	str		r0,[r2]
	ldr		r1,=CurrSpriteData
	mov		r0,0x2C				;Timer 1, was 2E
	add		r0,r0,r1
	mov		r12,r0
	mov		r3,0x0
	mov		r0,0x2
	mov		r4,r12
	strb		r0,[r4]
	strb		r3,[r2,0xC]		;animationDurationCounter, was 6
	strh		r3,[r2,0x4]
	add		r1,0x24				;pose
	mov		r0,0x8
	strb		r0,[r1]
	ldr		r0, =681			;music, was 264
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r4
	pop		r0
	bx		r0
	.pool

CheckHangingFromCeilingLadder:		;127D8
;No ceiling in ZM, change to check hang on ledge or zipline.
	mov		r0, 0
	ldr		r3, =SamusData
	add		r3, 0x24
	ldrb		r1, [r3]
	cmp		r1, 21
	blo		@@return
	cmp		r1, 26
	blo		@@true
	cmp		r1, 40
	blo		@@return
	cmp		r1, 44
	blo		@@true
@@true:
	mov		r0, 1
@@return:
	bx		r14
	.pool

BOX1FinishedCrawling:		;803660c
	push		r4,r5,r14
	ldr		r4,=CurrSpriteData
	mov		r5,r4
	add		r5,0x2C				;Timer 1, was 2E
	ldrb		r0,[r5]
	cmp		r0,0x1
	bls		@@_8036630
	ldr		r0, =SpriteUtilCheckEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036662
	ldrb		r0,[r5]
	sub		r0,0x1
	strb		r0,[r5]
	b		@@_8036662
	.pool
@@_8036630:		;8036630
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036662
	bl		CheckHangingFromCeilingLadder
	cmp		r0,0x0
	beq		@@_8036648
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x3B
	b		@@_8036660
@@_8036648:		;8036648
	mov		r0,r4
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_803665a
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x3B
	b		@@_8036660
@@_803665a:		;803665a
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x19
@@_8036660:		;8036660
	strb		r0,[r1]
@@_8036662:		;8036662
	pop		r4,r5
	pop		r0
	bx		r0

BOX1WaitingToJumpStart:		;8036668
	push		r4,r14
	ldr		r0,=SamusData
	ldrh		r4,[r0,0x12]	;X position, was 16
	ldr		r0,=SubSpriteData1
	ldrh		r2,[r0,0x8]		;x, was a
	mov		r1,r2
	sub		r1,0x78
	mov		r3,r0
	cmp		r1,r4
	bge		@@_8036694
	mov		r0,r2
	add		r0,0x78
	cmp		r0,r4
	ble		@@_8036694
	bl		BOX1StoppingToFireBombStart
	b		@@return
	.pool
@@_8036694:		;8036694
	ldr		r0,=BOX1SubOAM13
	str		r0,[r3]
	mov		r0,0x0
	strb		r0,[r3,0xC]		;animationDurationCounter, was 6
	strh		r0,[r3,0x4]
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x3C
	strb		r1,[r0]
@@return:		;80366a6
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1WaitingToJump:		;80366b4
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_80366c6
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x3D
	strb		r1,[r0]
@@_80366c6:		;80366c6
	pop		r0
	bx		r0
	.pool

BOX1JumpingStart:		;80366d0
	push		r4,r5,r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM03
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	mov		r2,0x0
	strh		r0,[r1,0x4]
	ldr		r3,=CurrSpriteData
	mov		r1,r3
	add		r1,0x24				;pose
	mov		r0,0x3E
	strb		r0,[r1]
	mov		r0,r3
	add		r0,0x2F				;was 31
	strb		r2,[r0]
	sub		r0,0x2				;Timer 2, was 2F
	ldrb		r1,[r0]
	mov		r0,0x80
	and		r0,r1
	cmp		r0,0x0
	bne		@@_803678c
	bl		CheckHangingFromCeilingLadder
	cmp		r0,0x0
	beq		@@_8036718
	ldr		r0, =SpriteUtilMakeSpriteFaceSamusDirection+1
	bl		WRapperR0
	b		@@_803671c
	.pool
@@_8036718:		;8036718
	ldr		r0, =SpriteUtilMakeSpriteFaceAwayFromSamusDirection+1
	bl		WRapperR0
@@_803671c:		;803671c
	ldr		r4,=CurrSpriteData
	ldrh		r1,[r4]			;status
	mov		r5,0x80
	lsl		r5,r5,0x2
	mov		r0,r5
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036764
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	ldr		r2,=0xFFFFFED4
	add		r0,r0,r2
	ldrh		r1,[r1,0x8]		;x, was a
	mov		r2,0x96
	lsl		r2,r2,0x1
	add		r1,r1,r2
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_803678c
	ldrh		r1,[r4]
	ldr		r0,=0xFDFF
	and		r0,r1
	b		@@_8036782
	.pool
@@_8036764:		;8036764
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	ldr		r2,=0xFFFFFED4
	add		r0,r0,r2
	ldrh		r1,[r1,0x8]		;x, was a
	add		r1,r1,r2
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_803678c
	ldrh		r1,[r4]			;status
	mov		r0,r5
	orr		r0,r1
@@_8036782:		;8036782
	strh		r0,[r4]
	mov		r1,r4
	add		r1,0x2D				;Timer 2, was 2F
	mov		r0,0x83
	strb		r0,[r1]
@@_803678c:		;803678c
	ldr		r0,=0x2A0		;music,was 265
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r4,r5
	pop		r0
	bx		r0
	.pool
	
BOX1Jumping:		;80367a8
	push		r4,r5,r14
	ldr		r4,=CurrSpriteData
	mov		r0,0x2F				;was 31
	add		r0,r0,r4
	mov		r12,r0
	ldrb		r2,[r0]
	ldr		r1,=BOX1Table3
	lsl		r0,r2,0x1
	add		r0,r0,r1
	ldrh		r3,[r0]
	mov		r5,0x0
	ldsh		r1,[r0,r5]
	ldr		r0,=0x7FFF
	cmp		r1,r0
	bne		@@_80367dc
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x39
	strb		r0,[r1]
	b		@@_80367f2
	.pool
@@_80367dc:		;80367dc
	add		r0,r2,1
	mov		r1,r12
	strb		r0,[r1]
	ldr		r1,=SubSpriteData1
	ldrh		r0,[r1,0x6]		;y, was 8
	add		r0,r0,r3
	strh		r0,[r1,0x6]		;y, was 8
	mov		r0,0xC
	mov		r1,0x37
	bl		f8035bb4
@@_80367f2:		;80367f2
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1StoppingToFireBombStart:		;80367fc
	push		r4,r14
	ldr		r2,=SubSpriteData1
	ldr		r0,=BOX1SubOAM02
	str		r0,[r2]
	ldr		r1,=CurrSpriteData
	mov		r0,0x2C				;Timer 1, was 2E
	add		r0,r0,r1
	mov		r12,r0
	mov		r3,0x0
	mov		r0,0x3
	mov		r4,r12
	strb		r0,[r4]
	strb		r3,[r2,0xC]		;animationDurationCounter, was 6
	strh		r3,[r2,0x4]
	add		r1,0x24				;pose
	mov		r0,0x28
	strb		r0,[r1]
	ldr		r0, =681			;music, was 264
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1StoppingToFireBomb:		;8036838
	push		r4,r5,r14
	ldr		r5,=CurrSpriteData
	mov		r4,r5
	add		r4,0x2C				;Timer 1, was 2E
	ldrb		r0,[r4]
	cmp		r0,0x1
	bls		@@_803685c
	ldr		r0, =SpriteUtilCheckEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_803686c
	ldrb		r0,[r4]
	sub		r0,0x1
	strb		r0,[r4]
	b		@@_803686c
	.pool
@@_803685c:		;803685c
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_803686c
	mov		r1,r5
	add		r1,0x24				;pose
	mov		r0,0x29
	strb		r0,[r1]
@@_803686c:		;803686c
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1LoweringToFireBombStart:		;8036874
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM14
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x2A
	strb		r1,[r0]
	mov		r0,0x9A
	lsl		r0,r0,0x2
	ldr		r1, =PlaySound+1			;music??
	;bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1LoweringToFireBomb:		;80368a4
	push		r14
	ldr		r0, =SpriteUtilCheckEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_80368c2
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r2,0x0
	mov		r1,0x2C
	strb		r1,[r0]
	ldr		r0,=SubSpriteData1
	ldr		r1,=BOX1SubOAM15
	str		r1,[r0]
	strb		r2,[r0,0xC]		;animationDurationCounter, was 6
	strh		r2,[r0,0x4]
@@_80368c2:		;80368c2
	pop		r0
	bx		r0
	.pool

BOX1DoneFiringBombStart:		;80368d4
	push		r4-r7,r14
	add		sp,-0xC
	ldr		r0, =SpriteUtilCheckEndSubSprite1Anim+1
	bl		WRapperR0
	mov		r6,r0
	cmp		r6,0x0
	beq		@@_8036910
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r2,0x0
	mov		r1,0x2E
	strb		r1,[r0]
	ldr		r0,=SubSpriteData1
	ldr		r1,=BOX1SubOAM16
	str		r1,[r0]
	strb		r2,[r0,0xC]		;animationDurationCounter, was 6
	strh		r2,[r0,0x4]
	ldr		r0,=0x269
	ldr		r1, =PlaySound+1			;music??
	;bl		WRapperR1
	b		@@_803697a
	.pool
@@_8036910:		;8036910
	ldr		r3,=CurrSpriteData
	ldrh		r5,[r3,0x2]		;y
	ldrh		r4,[r3,0x4]		;x
	ldr		r0,=SubSpriteData1

	ldrh	r1, [r0, 4]		;currentAnimationFrame
	mov		r2, 1
	cmp		r1, r2
	bne		@@_803697a
	ldrb	r1, [r0, 0xC]
	mov		r2, 2
	cmp		r1, r2
	bne		@@_803697a

	;ldr		r0,[r0,0x4]
	;ldr		r1,=0xFFFFFF
	;and		r0,r1
	;ldr		r1,=0x20001
	;cmp		r0,r1
	;bne		@@_803697a
	ldr		r0,=SamusData
	ldrh		r0,[r0,0x12]	;X position, was 16
	cmp		r4,r0
	bls		@@_803695c
	ldrb		r2,[r3,0x1F]	;Spriteset graphics slot
	mov		r0,r3
	add		r0,0x23				;Primary sprite RAM slot
	ldrb		r3,[r0]
	mov		r0,r5
	sub		r0,0x64
	str		r0,[sp]
	str		r4,[sp,0x4]
	str		r6,[sp,0x8]
	mov		r0,BOX1FirebombSpriteID
	mov		r1,0x0
	ldr		r7, =SpriteSpawnSecondary+1
	bl		WrapperR7
	b		@@_803697a
	.pool
@@_803695c:		;803695c
	ldrb		r2,[r3,0x1F]
	mov		r0,r3
	add		r0,0x23
	ldrb		r3,[r0]
	mov		r0,r5
	sub		r0,0x64
	str		r0,[sp]
	str		r4,[sp,0x4]
	mov		r0,0x80
	lsl		r0,r0,0x2
	str		r0,[sp,0x8]
	mov		r0,BOX1FirebombSpriteID
	mov		r1,0x0
	ldr		r7, =SpriteSpawnSecondary+1
	bl		WrapperR7
@@_803697a:		;803697a
	add		sp,0xC
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1DoneFiringBomb:		;8036984
	push		r14
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036996
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x17
	strb		r1,[r0]
@@_8036996:		;8036996
	pop		r0
	bx		r0
	.pool

BOX1DyingStart:		;80369a0
	ldr		r1,=CurrSpriteData
	ldr		r0,=BOX1OAM31
	str		r0,[r1,0x18]
	mov		r3,0x0
	strb		r3,[r1,0x1C]	;Animation duration counter
	mov		r2,0x0
	strh		r3,[r1,0x16]	;Current animation frame
	mov		r0,r1
	add		r0,0x2C				;Timer 1, was 2e
	strb		r2,[r0]
	add		r0,0x3				;was 31
	strb		r2,[r0]
	add		r1,0x24				;pose
	mov		r0,0x44
	strb		r0,[r1]
	ldr		r0,=SubSpriteData1
	ldr		r1,=BOX1SubOAM01
	str		r1,[r0]
	strb		r2,[r0,0xC]		;animationDurationCounter, was 6
	strh		r3,[r0,0x4]
	bx		r14
	.pool

BOX1Dying:		;80369dc
	push		r4,r5,r14
	ldr		r1,=CurrSpriteData
	mov		r5,r1
	add		r5,0x2C				;Timer 1, was 2E
	ldrb		r0,[r5]
	cmp		r0,0x0
	bne		@@_8036a1c
	ldr		r4,=SubSpriteData1
	ldrh		r0,[r4,0x6]		;y, was 8
	ldrh		r1,[r4,0x8]		;x, was a
	ldr		r2, =SpriteUtilCheckVerticalCollisionAtPositionSlopes+1
	bl		WRapperR2
	mov		r1,r0
	ldr		r0,=PreviousVerticalCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8036a14
	strh		r1,[r4,0x6]		;y, was 8
	ldrb		r0,[r5]
	add		r0,0x1
	strb		r0,[r5]
	b		@@_8036a2e
	.pool
@@_8036a14:		;8036a14
	ldrh		r0,[r4,0x6]		;y, was 8
	add		r0,0x10
	strh		r0,[r4,0x6]		;y, was 8
	b		@@_8036a2e
@@_8036a1c:		;8036a1c
	add		r0,0x1
	strb		r0,[r5]
	lsl		r0,r0,0x18
	lsr		r0,r0,0x18
	cmp		r0,0x1E
	bls		@@_8036a2e
	add		r1,0x24				;pose
	mov		r0,0x45
	strb		r0,[r1]
@@_8036a2e:		;8036a2e
	pop		r4,r5
	pop		r0
	bx		r0

BOX1MovingToFinalJumpStart:		;8036a34
	push		r4,r14
	ldr		r4,=CurrSpriteData
	ldr		r0,=BOX1OAM31
	str		r0,[r4,0x18]
	mov		r0,0x0
	strb		r0,[r4,0x1C]
	strh		r0,[r4,0x16]
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x46
	strb		r0,[r1]
	ldrh		r1,[r4,0x4]		;X position
	strh		r1,[r4,0x8]		;target X position to start final jump
	mov		r2,r4
	add		r2,0x2D				;Timer 2, was 2F
	strb		r0,[r2]
	ldr		r2,=SubSpriteData1
	ldrh		r0,[r2,0x8]		;x, was a
	lsl		r1,r1,0x10
	lsr		r1,r1,0x10
	cmp		r0,r1
	bls		@@_8036a98
	ldr		r0,=BOX1SubOAM17
	str		r0,[r2]
	ldrh		r1,[r4]			;status
	ldr		r0,=0xFDFF
	and		r0,r1
	b		@@_8036aa6
	.pool
@@_8036a98:		;8036a98
	ldr		r0,=BOX1SubOAM18
	str		r0,[r2]
	ldrh		r0,[r4]
	mov		r2,0x80
	lsl		r2,r2,0x2
	mov		r1,r2
	orr		r0,r1
@@_8036aa6:		;8036aa6
	strh		r0,[r4]
	ldr		r1,=SubSpriteData1
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1MovingToFinalJump:		;8036ac0
	push		r4,r5,r14
	ldr		r0,=SubSpriteData1

	ldrh	r1, [r0, 4]		;currentAnimationFrame
	mov		r2, 3
	cmp		r1, r2
	bne		@@_8036ad6
	ldrb	r1, [r0, 0xC]
	mov		r2, 1
	cmp		r1, r2
	bne		@@_8036ad6
	
	;ldr		r0,[r0,0x4]
	;ldr		r1,=0xFFFFFF
	;and		r0,r1
	;ldr		r1,=0x10003
	;cmp		r0,r1
	;bne		@@_8036ad6
	ldr		r0,=0x262
	ldr		r1, =PlaySound+1			;music??
	;bl		WRapperR1
@@_8036ad6:		;8036ad6
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	ldr		r5,=CurrSpriteData
	cmp		r0,0x0
	bne		@@_8036b1a
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18
	cmp		r1,0x0
	beq		@@_8036b14

	mov		r0, r5
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r5,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r5
	add		r1,0x20			;Palette row
	strb	r2, [r1]
	;mov		r1,r5
	;add		r1,0x20				;Palette row
	;mov		r0,0xB
	;strb		r0,[r1]
	b		@@_8036b1a
	.pool
@@_8036b14:		;8036b14
	mov		r0,r5
	add		r0,0x20				;Palette row
	strb		r1,[r0]
@@_8036b1a:		;8036b1a
	ldr		r4,=SubSpriteData1
	ldrh		r3,[r4,0x8]		;x, was a
	ldr		r0,=0xFFF8
	ldrh		r2,[r5,0x8]		;X position spawn?
	mov		r1,r0
	and		r1,r3
	and		r0,r2
	cmp		r1,r0
	bne		@@_8036b40
	mov		r1,r5
	add		r1,0x24				;pose
	mov		r0,0x47
	strb		r0,[r1]
	b		@@_8036b54
	.pool
@@_8036b40:		;8036b40
	ldrh		r1,[r5]			;status
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036b50
	add		r0,r3,2
	b		@@_8036b52
@@_8036b50:		;8036b50
	sub		r0,r3,2
@@_8036b52:		;8036b52
	strh		r0,[r4,0x8]		;x, was a
@@_8036b54:		;8036b54
	pop		r4,r5
	pop		r0
	bx		r0
	.pool

BOX1WaitingForFinalJumpStart:		;8036b5c
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM01
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x48
	strb		r1,[r0]
	ldr		r0,=0x276
	ldr		r1, =PlaySound+1			;music??
	;bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1WaitingForFinalJump:		;8036b8c
	push		r4,r14
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	ldr		r4,=CurrSpriteData
	cmp		r0,0x0
	bne		@@_8036bc2
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18
	cmp		r1,0x0
	beq		@@_8036bbc

	mov		r0, r4
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r4,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r4
	add		r1,0x20			;Palette row
	strb	r2, [r1]
	;mov		r1,r4
	;add		r1,0x20				;Palette row
	;mov		r0,0xB
	;strb		r0,[r1]
	b		@@_8036bc2
	.pool
@@_8036bbc:		;8036bbc
	mov		r0,r4
	add		r0,0x20				;Palette row
	strb		r1,[r0]
@@_8036bc2:		;8036bc2
	ldrh		r0,[r4,0x4]		;X position
	lsr		r0,r0,0x2
	ldr		r1,=Bg1XPosition
	ldrh		r1,[r1]
	lsr		r1,r1,0x2
	sub		r0,r0,r1
	lsl		r0,r0,0x10
	ldr		r1,=0xFFE70000
	add		r0,r0,r1
	lsr		r0,r0,0x10
	cmp		r0,0xBE
	bhi		@@_8036bea
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036bea
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x49
	strb		r0,[r1]
@@_8036bea:		;8036bea
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1CrouchingForFinalJumpStart:		;8036bf8
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM13
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x4A
	strb		r1,[r0]
	bx		r14
	.pool

BOX1CrouchingForFinalJump:		;8036c1c
	push		r14
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@_8036c4e
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18

	ldr		r3,=CurrSpriteData
	mov		r0, r3
	add		r0,0x20				;palette
	cmp		r1,0x0
	beq		@@_8036c4c
	mov		r1, r3
    add     r1, 0x33			;frozen palette row offset
    ldrb    r1, [r1]
    ldrb    r2, [r3,1Fh]
    add     r1, r1, r2
    mov     r2, 0xE
    sub     r1, r2, r1

@@_8036c4c:		;8036c4c
	strb		r1,[r0]
@@_8036c4e:		;8036c4e
	ldr		r0, =SpriteUtilCheckNearEndSubSprite1Anim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8036c62
	ldr		r0,=CurrSpriteData
	add		r0,0x24				;pose
	mov		r1,0x4D
	strb		r1,[r0]
	ldr		r0, =unk_3a6c+1
	bl		WRapperR0
@@_8036c62:		;8036c62
	pop		r0
	bx		r0
	.pool

BOX1FinalJumpStart:		;8036c6c
	push		r14
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM03
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	ldr		r1,=CurrSpriteData
	mov		r2,r1
	add		r2,0x24				;pose
	mov		r0,0x4E
	strb		r0,[r2]
	add		r1,0x2C				;Timer 1, was 2E
	;mov		r0,0x1E
	;strb		r0,[r1]
	ldr		r0,=0x2A9			;music, was 277
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r0
	bx		r0
	.pool

BOX1FinalJump:		;8036ca4
	push		r4,r14
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	ldr		r4,=CurrSpriteData
	cmp		r0,0x0
	bne		@@_8036cda
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18
	cmp		r1,0x0
	beq		@@_8036cd4
	mov		r0, r4
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r4,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r4
	add		r1,0x20			;Palette row
	strb	r2, [r1]
	;mov		r1,r4
	;add		r1,0x20				;Palette row
	;mov		r0,0xB
	;strb		r0,[r1]
	b		@@_8036cda
	.pool
@@_8036cd4:		;8036cd4
	mov		r0,r4
	add		r0,0x20				;Palette row
	strb		r1,[r0]
@@_8036cda:		;8036cda
	ldr		r0,=SubSpriteData1
	ldrh		r1,[r0,0x6]		;y, was 8
	sub		r1,0x28
	strh		r1,[r0,0x6]		;y, was 8
	mov		r1,r4
	add		r1,0x2C				;Timer 1, was 2E
	ldrb		r0,[r1]
	sub		r0,0x1
	strb		r0,[r1]
	lsl		r0,r0,0x18
	lsr		r3,r0,0x18
	cmp		r3,0x0
	bne		@@_8036d0c	
	strh	r3,[r4]			;kills box
	mov		r0,1
	bl		SetnCheckEvent
	ldr		r0, =DoorUnlockTimer
	mov		r1,0x3C
	neg		r1,r1
	strb	r1,[r0]
	mov		r0,0xB				;Boss killed
	mov		r1,0
	ldr		r3, =PlayMusic+1
	bl		WRapperR3
@@_8036d0c:		;8036d0c
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1CrawlingStart:		;36D1C
	push		r14
	ldr		r2,=CurrSpriteData
	ldrh		r1,[r2]
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8036d40
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM18
	b		@@_8036d44
	.pool
@@_8036d40:		;8036d40
	ldr		r1,=SubSpriteData1
	ldr		r0,=BOX1SubOAM17
@@_8036d44:		;8036d44
	str		r0,[r1]
	mov		r0,0x0
	strb		r0,[r1,0xC]		;animationDurationCounter, was 6
	strh		r0,[r1,0x4]
	mov		r1,r2
	add		r1,0x24				;pose
	mov		r0,0x2
	strb		r0,[r1]
	pop		r0
	bx		r0
	.pool

BOX1Crawling:		;36D60
	push		r14
	mov		r0,0x1
	mov		r1,0x7
	bl		f8035bb4
	pop		r0
	bx		r0

f8036d70:		;8036d70
	push		r14
	lsl		r0,r0,0x18
	lsr		r0,r0,0x18
	lsl		r1,r1,0x18
	lsr		r3,r1,0x18
	ldr		r2,=SpriteData
	lsl		r1,r0,0x3
	sub		r1,r1,r0
	lsl		r1,r1,0x3
	add		r1,r1,r2
	add		r1,0x2D				;Timer 2, was 2F
	ldrb		r0,[r1]
	cmp		r0,r3
	bcs		@@return
	strb		r3,[r1]
@@return:		;8036d8e
	pop		r0
	bx		r0
	.pool

f8036d98:		;8036d98
	push		r14
	lsl		r0,r0,0x18
	lsr		r2,r0,0x18
	ldr		r1,=SpriteData
	lsl		r0,r2,0x3
	sub		r0,r0,r2
	lsl		r0,r0,0x3
	add		r0,r0,r1
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	sub		r0,0x29
	mov		r3,r1
	cmp		r0,0x19
	bhi		@@Pose2B
	lsl		r0,r0,0x2
	ldr		r1,=@@Table
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@Table:		;8036dc8
	.dw @@Pose29
	.dw @@Pose29
	.dw @@Pose2B
	.dw @@Pose29
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose2B
	.dw @@Pose3C
	.dw @@Pose3C
	.dw @@Pose3C
	.dw @@Pose3C
@@Pose29:		;8036e30
	lsl		r0,r2,0x3
	sub		r0,r0,r2
	lsl		r0,r0,0x3
	add		r0,r0,r3
	add		r0,0x2E		;Work Variable, was 2D
	ldrb		r1,[r0]
	mov		r0,0x3
	and		r0,r1
	cmp		r0,0x0
	beq		@@Pose2B
	ldr		r0,=CurrSpriteData
	add		r0,0x32		;Property, was 34
	ldrb		r2,[r0]
	mov		r1,0x40		;Immune to projectiles
	orr		r1,r2
	b		@@_8036e6e
	.pool
@@Pose3C:		;8036e54
	ldr		r0,=CurrSpriteData
	add		r0,0x32		;Property, was 34
	ldrb		r2,[r0]
	mov		r1,0x40		;Immune to projectiles
	orr		r1,r2
	b		@@_8036e6e
	.pool
@@Pose2B:		;8036e64
	ldr		r0,=CurrSpriteData
	add		r0,0x32		;Property, was 34
	ldrb		r2,[r0]
	mov		r1,0xBF
	and		r1,r2
@@_8036e6e:		;8036e6e
	strb		r1,[r0]
	pop		r0
	bx		r0
	.pool

BOX1PartCheckProjectile:
    push    r4-r7, r14
    mov r7, r10
    mov r6, r9
    mov r5, r8
    push    r5-r7
    add sp, -0x14
    ldr r0, =Equipment
    mov r10, r0
    ldr r5, =CurrSpriteData 
    ldrb    r0, [r5, 0x1E]
	lsl		r0, r0, 2
	ldr		r1, =@@PartNumberTable
    cmp r0, 0xC
    blt @@CheckPartNumber
    b @@Return
@@CheckPartNumber:
	add		r0, r1
	mov		r15, r0
	.pool
@@PartNumberTable:
	.dw	@@CheckProjectile, @@Return, @@CheckProjectile, @@Return
	.dw	@@Return, @@Return, @@Return, @@Return
	.dw	@@Return, @@Return, @@Return, @@Return
@@CheckProjectile:
    ldrh    r1, [r5, 2] ;y
    ldrh    r2, [r5, 4] ;x
    ldrh    r0, [r5, 0xA]   ;top
    add r0, r1, r0
    lsl r0, r0, 0x10
    lsr r0, r0, 0x10
    str r0, [sp, 4]  ;hitBOX1 top
    ldrh    r0, [r5, 0xC]   ;botttom
    add r1, r1, r0
    lsl r1, r1, 0x10
    lsr r1, r1, 0x10
    str r1, [sp, 0xC]  ;hitBOX1 bottom
    ldrh    r0, [r5, 0xE]
    add r0, r2
    lsl r0, r0, 0x10
    lsr r0, r0, 0x10
    str r0, [sp, 8]    ;hitBOX1 left
    ldrh    r0, [r5, 0x10]
    add r2, r2, r0
    lsl r2, r2, 0x10
    lsr r2, r2, 0x10
    str r2, [sp, 0x10]    ;hitBOX1 right
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
    ldrb r1, [r6, 0xF]
    cmp r1, 0xC
    beq @@InvMissile
    cmp r1, 0xD
    beq @@InvMissile
    mov r0, 0
    strb    r0, [r6]
    b   @@SetPartical
@@InvMissile:
    mov r0, r6
    ldr r3, =0x8050975
    bl  WRapperR3
@@SetPartical:
    ldrh    r0, [r6, 0xA]
    mov r8, r0   ;proj X
    mov r0, r7
    mov r1, r8
    mov r2, 0x2F
    ldr r3, =ParticleSet+1
    bl  WRapperR3
    b   @@NextProj
@@NextProj:
@@CheckNext:
    add r6, 0x1C
    ldr r0, =ArmCannonY
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


BOX1PartInitialize:		;8036e8c
	push		r14
	ldr		r2,=CurrSpriteData
	ldrh		r1,[r2]	;status
	ldr		r0,=0xFFFB
	and		r0,r1
	strh		r0,[r2]
	mov		r0,r2
	add		r0,0x27		;Draw distance top offset
	mov		r1,0x18
	strb		r1,[r0]
	add		r0,0x1
	strb		r1,[r0]
	mov		r1,r2
	add		r1,0x29
	mov		r0,0x10
	strb		r0,[r1]
	sub		r1,0x5		;pose
	mov		r0,0x2
	strb		r0,[r1]
	ldrb		r0,[r2,0x1E];Room slot/part number
	mov		r3,r2
	cmp		r0,0x6
	bhi		@@_8036ecc
	mov		r1,r3
	add		r1,0x22		;Draw order
	mov		r0,0xB
	b		@@_8036ed2
	.pool
@@_8036ecc:		;8036ecc
	mov		r1,r3
	add		r1,0x22		;Draw order
	mov		r0,0xD
@@_8036ed2:		;8036ed2
	strb		r0,[r1]
	ldrb		r0,[r3,0x1E];Room slot/part number
	cmp		r0,0xB
	bls		@@_8036edc
	b		@@Part7
@@_8036edc:		;8036edc
	lsl		r0,r0,0x2
	ldr		r1,=@@PartNumTable
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@PartNumTable:		;8036eec
	.dw @@Part0
	.dw @@Part1
	.dw @@Part0
	.dw @@Part1
	.dw @@Part1
	.dw @@Part1
	.dw @@Part6
	.dw @@Part7
	.dw @@Part8
	.dw @@Part9
	.dw @@Part1
	.dw @@Part1
@@Part0:		;8036f1c
	ldr		r0,=0xFFB8
	strh		r0,[r3,0xA]
	mov		r0,0x48
	strh		r0,[r3,0xC]
	ldr		r0,=0xFFE0
	strh		r0,[r3,0xE]
	mov		r0,0x20
	strh		r0,[r3,0x10]
	mov		r1,r3
	add		r1,0x33	;Frozen palette row offset, was 35
	mov		r0,0x2
	strb		r0,[r1]
	mov		r0, 4	;Hurts Samus, was 2
	sub		r1,0xE	;collison
	b		@@_8036f7e
	.pool
@@Part6:		;8036f40
	ldr		r0,=0xFFD0
	strh		r0,[r3,0xA]
	mov		r0,0x40
	strh		r0,[r3,0xC]
	ldr		r0,=0xFFE0
	strh		r0,[r3,0xE]
	mov		r0,0x20
	strh		r0,[r3,0x10]
	mov		r1,r3
	add		r1,0x33	;Frozen palette row offset, was 35
	mov		r0,0x1
	strb		r0,[r1]
	sub		r1,0xE	;collison
	mov		r0,4	;Hurts Samus, was 2
	strb		r0,[r1]
	b		@@_8036fc8
	.pool
@@Part9:		;8036f68
	ldr		r0,=0xFFE0
	strh		r0,[r3,0xA]
	mov		r0,0x20
	strh		r0,[r3,0xC]
	ldr		r0,=0xFFC0
	strh		r0,[r3,0xE]
	mov		r0,0x40
	strh		r0,[r3,0x10]
	strb		r0,[r1]
	mov		r1,r3
	add		r1,0x25	;collison
	mov		r0,0x4	;Hurts Samus, was 2
@@_8036f7e:		;8036f7e
	strb		r0,[r1]
	ldr		r1,=SecondarySpriteStats
	ldrb		r0,[r3,0x1D]	;Spirte ID
	lsl		r2,r0,0x4
	lsl		r0, r0, 1
	add		r0, r2
	add		r0,r0,r1
	ldrh		r0,[r0]
	strh		r0,[r3,0x14]	;Health
	mov		r2,r3
	add		r2,0x32		;Property, was 34
	ldrb		r1,[r2]
	mov		r0,0x40
	orr		r0,r1
	strb		r0,[r2]
	b		@@_8036fe4
	.pool
@@Part8:
	mov		r0,r3
	add		r0,0x33			;Frozen palette row offset
	mov		r2, 1
	strb		r2,[r0]
@@Part1:		;8036fa8
	mov		r2,0x0
	ldr		r1,=0xFFFC
	strh		r1,[r3,0xA]
	mov		r0,0x4
	strh		r0,[r3,0xC]
	strh		r1,[r3,0xE]
	strh		r0,[r3,0x10]
	mov		r0,r3
	add		r0,0x25			;Collision
	strb		r2,[r0]
	ldrh		r0,[r3]		;Status
	mov		r2,0x80
	lsl		r2,r2,0x8
	mov		r1,r2
	orr		r0,r1
	strh		r0,[r3]
@@_8036fc8:		;8036fc8
	ldr		r1,=SecondarySpriteStats
	ldrb		r0,[r3,0x1D]
	lsl		r2, r0, 0x4
	lsl		r0, r0, 1
	add		r0, r2
	add		r0,r0,r1
	ldrh		r0,[r0]
	strh		r0,[r3,0x14]
	b		@@_8036fe4
	.pool
@@Part7:		;8036fe0
	mov		r0,0x0
	strh		r0,[r3]
@@_8036fe4:		;8036fe4
	bl		f8035b4c
	pop		r0
	bx		r0

BOX1FrontLeftLeg:		;8036fec
	push		r4-r7,r14
	ldr		r5,=CurrSpriteData
	mov		r0,r5
	add		r0,0x23		;Primary sprite RAM slot
	ldrb		r6,[r0]
	ldr		r0,=SpriteData
	lsl		r1,r6,0x3
	sub		r1,r1,r6
	lsl		r1,r1,0x3
	add		r2,r1,r0
	ldrh		r0,[r2]	;status
	mov		r1,0x1
	and		r1,r0
	cmp		r1,0x0
	bne		@@_8037018
	strh		r1,[r5]
	b		@@_803709a
	.pool
@@_8037018:		;8037018
	ldrh		r1,[r5]
	mov		r0,0x80
	lsl		r0,r0,0x6
	and		r0,r1
	lsl		r0,r0,0x10
	lsr		r4,r0,0x10
	cmp		r4,0x0
	bne		@@_803709a
	ldrh		r3,[r5,0x2]	;y
	ldrh		r1,[r5,0x4]	;x
	mov		r0,r2
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	cmp		r0,0x44
	bne		@@_803704e
	ldr		r0,[r5,0x18]
	ldr		r7,=BOX1OAM03
	cmp		r0,r7
	beq		@@_803704e
	mov		r0,r3
	add		r0,0x3C
	mov		r2,0x21			;Explosion 7, was 30
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	str		r7,[r5,0x18]
	strb		r4,[r5,0x1C]
	strh		r4,[r5,0x16]
@@_803704e:		;803704e
	ldr		r1,=SpriteData
	lsl		r0,r6,0x3
	sub		r0,r0,r6
	lsl		r0,r0,0x3
	add		r0,r0,r1
	add		r0,0x2E		;Work Variable, was 2D
	ldrb		r1,[r0]
	mov		r0,0x4
	and		r0,r1
	cmp		r0,0x0
	bne		@@_803709a
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@_803709a
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18
	
	ldr		r3,=CurrSpriteData
	mov		r0, r3
	add		r0,0x20				;palette
	cmp		r1,0x0
	beq		@@_8037098
	mov		r1, r3
    add     r1, 0x33			;frozen palette row offset
    ldrb    r1, [r1]
    ldrb    r2, [r3,1Fh]
    add     r1, r1, r2
    mov     r2, 0xE
    sub     r1, r2, r1
@@_8037098:		;8037098
	strb		r1,[r0]
@@_803709a:		;803709a
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1FrontRightLeg:		;80370a4
	push		r4-r7,r14
	ldr		r5,=CurrSpriteData
	mov		r0,r5
	add		r0,0x23			;Primary sprite RAM slot
	ldrb		r6,[r0]
	ldr		r0,=SpriteData
	lsl		r1,r6,0x3
	sub		r1,r1,r6
	lsl		r1,r1,0x3
	add		r2,r1,r0
	ldrh		r0,[r2]
	mov		r1,0x1
	and		r1,r0
	cmp		r1,0x0
	bne		@@_80370d0
	strh		r1,[r5]
	b		@@return
	.pool
@@_80370d0:		;80370d0
	ldrh		r1,[r5]
	mov		r0,0x80
	lsl		r0,r0,0x6
	and		r0,r1
	lsl		r0,r0,0x10
	lsr		r4,r0,0x10
	cmp		r4,0x0
	bne		@@return
	ldrh		r3,[r5,0x2]
	ldrh		r1,[r5,0x4]
	mov		r0,r2
	add		r0,0x24
	ldrb		r0,[r0]
	cmp		r0,0x44
	bne		@@_8037106
	ldr		r0,[r5,0x18]
	ldr		r7,=BOX1OAM16
	cmp		r0,r7
	beq		@@_8037106
	mov		r0,r3
	add		r0,0x3C
	mov		r2,0x21			;Explosion 7, was 30
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	str		r7,[r5,0x18]
	strb		r4,[r5,0x1C]
	strh		r4,[r5,0x16]
@@_8037106:		;8037106
	ldr		r1,=SpriteData
	lsl		r0,r6,0x3
	sub		r0,r0,r6
	lsl		r0,r0,0x3
	add		r0,r0,r1
	add		r0,0x2E		;Work Variable, was 2D
	ldrb		r1,[r0]
	mov		r0,0x4
	and		r0,r1
	cmp		r0,0x0
	bne		@@return
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@return
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r1,r0,0x18
	
	ldr		r3,=CurrSpriteData
	mov		r0, r3
	add		r0,0x20				;palette
	cmp		r1,0x0
	beq		@@_8037150
	mov		r1, r3
    add     r1, 0x33			;frozen palette row offset
    ldrb    r1, [r1]
    ldrb    r2, [r3,1Fh]
    add     r1, r1, r2
    mov     r2, 0xE
    sub     r1, r2, r1
@@_8037150:		;8037150
	strb		r1,[r0]
@@return:		;8037152
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1Center:		;803715c
	push		r4-r7,r14
	mov		r6,r8
	mov		r7,r9
	push		r6,r7
	add		sp,-0x8
	ldr		r4,=CurrSpriteData
	mov		r0,r4
	add		r0,0x23			;Primary sprite RAM slot
	ldrb		r0,[r0]
	mov		r9,r0
	ldr		r0,=SpriteData
	mov		r2,r9
	lsl		r1,r2,0x3
	sub		r1,r1,r2
	lsl		r1,r1,0x3
	add		r1,r1,r0
	mov		r8,r1
	ldrh		r0,[r1]
	mov		r1,0x1
	and		r1,r0
	cmp		r1,0x0
	bne		@@_8037194
	strh		r1,[r4]
	b		@@_80372a0
	.pool
@@_8037194:		;8037194
	ldrh		r1,[r4]
	mov		r0,0x80
	lsl		r0,r0,0x6
	and		r0,r1
	lsl		r0,r0,0x10
	lsr		r6,r0,0x10
	cmp		r6,0x0
	beq		@@_80371a6
	b		@@_80372a0
@@_80371a6:		;80371a6
	mov		r7,r8
	add		r7,0x2E		;Work Variable, was 2D
	ldrb		r1,[r7]
	mov		r0,0x4
	and		r0,r1
	cmp		r0,0x0
	bne		@@_80371e0
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@_80372a0
	mov		r0,0x8
	and		r0,r1
	cmp		r0,0x0
	beq		@@_80371d8
	mov		r0, r4
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r4,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r4
	add		r1,0x20			;Palette row
	strb	r2, [r1]
	;mov		r1,r4
	;add		r1,0x20
	;mov		r0,0xC
	;strb		r0,[r1]
	b		@@_80372a0
	.pool
@@_80371d8:		;80371d8
	mov		r0,r4
	add		r0,0x20
	strb		r6,[r0]
	b		@@_80372a0
@@_80371e0:		;80371e0
	ldr		r1,=SecondarySpriteStats
	ldrb		r0,[r4,0x1D]
	lsl		r2, r0, 4
	lsl		r0, r0, 1
	add		r0, r2
	add		r0,r0,r1
	ldrh		r5,[r0]
	ldrh		r2,[r4,0x2]
	ldrh		r3,[r4,0x4]
	mov		r0,r9
	str		r2,[sp]
	str		r3,[sp,0x4]
	bl		f8036d98
	ldrh		r1,[r4,0x14]
	ldr		r2,[sp]
	ldr		r3,[sp,0x4]
	cmp		r1,0x0
	bne		@@_8037224
	ldrb		r1,[r7]
	mov		r0,0xFB
	and		r0,r1
	strb		r0,[r7]
	mov		r0,r2
	add		r0,0x32
	mov		r1,r3
	mov		r2,0x22			;Explosion 6, was 2f
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	mov		r1,r8
	add		r1,0x24
	mov		r0,0x43
	strb		r0,[r1]
	b		@@_8037282
	.pool
@@_8037224:		;8037224
	lsr		r0,r5,0x2
	cmp		r1,r0
	bcs		@@_8037234
	ldr		r0,[r4,0x18]
	ldr		r1,=BOX1OAM30
	b		@@_803723e
	.pool
@@_8037234:		;8037234
	lsr		r0,r5,0x1
	cmp		r1,r0
	bcs		@@_803725c
	ldr		r0,[r4,0x18]
	ldr		r1,=BOX1OAM29
@@_803723e:		;803723e
	cmp		r0,r1
	beq		@@_8037282
	str		r1,[r4,0x18]
	strb		r6,[r4,0x1C]
	strh		r6,[r4,0x16]
	mov		r0,r2
	add		r0,0x24
	mov		r1,r3
	mov		r2,0x21			;Explosion 7, was 30
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	b		@@_8037282
	.pool
@@_803725c:		;803725c
	ldrh		r1,[r4,0x14]
	lsl		r0,r5,0x1
	add		r0,r0,r5
	asr		r0,r0,0x2
	cmp		r1,r0
	bge		@@_8037282
	ldr		r0,[r4,0x18]
	ldr		r1,=BOX1OAM28
	cmp		r0,r1
	beq		@@_8037282
	str		r1,[r4,0x18]
	strb		r6,[r4,0x1C]
	strh		r6,[r4,0x16]
	mov		r0,r2
	add		r0,0x24
	mov		r1,r3
	mov		r2,0x21			;Explosion 7, was 30
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
@@_8037282:		;8037282
	ldr		r0,=CurrSpriteData
	add		r0,0x2B				;Stun/flash timer, was 2c
	ldrb		r1,[r0]
	mov		r0,0x7F
	and		r0,r1
	cmp		r0,0x4
	bne		@@_80372a0
	mov		r0,r9
	mov		r1,0x2
	bl		f8036d70
	;mov		r0,0x9E
	;lsl		r0,r0,0x2
	ldr		r0, =0x1E9				;music, was 278
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_80372a0:		;80372a0
	add		sp,0x8
	pop		r3,r4
	mov		r8,r3
	mov		r9,r4
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

f80372b8:		;80372b8
	push		r14
	ldr		r3,=CurrSpriteData
	mov		r0,r3
	add		r0,0x23			;Primary sprite RAM slot
	ldrb		r1,[r0]
	ldr		r2,=SpriteData
	lsl		r0,r1,0x3
	sub		r0,r0,r1
	lsl		r0,r0,0x3
	add		r2,r0,r2
	ldrh		r0,[r2]
	mov		r1,0x1
	and		r1,r0
	cmp		r1,0x0
	bne		@@_80372e4
	strh		r1,[r3]
	b		@@return
	.pool
@@_80372e4:		;80372e4
	ldrh		r1,[r3]
	mov		r0,0x80
	lsl		r0,r0,0x6
	and		r0,r1
	cmp		r0,0x0
	beq		@@_80372f2
	b		@@return
@@_80372f2:		;80372f2
	mov		r0,r2
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	sub		r0,0x8
	cmp		r0,0x46
	bls		@@_8037300
	b		@@Pose9
@@_8037300:		;8037300
	lsl		r0,r0,0x2
	ldr		r1, =@@PoseTable
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@PoseTable:		;8037310
	.dw @@Pose8
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose8
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose8
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@Pose9
	.dw @@_8037438
	.dw @@_8037438
	.dw @@_8037438
	.dw @@_8037438
	.dw @@_8037438
	.dw @@_8037438
	.dw @@_8037438
	.dw @@Pose9
	.dw @@Pose9
	.dw @@_8037438
	.dw @@_8037438
@@Pose8:		;803742c
	ldr		r0,[r3,0x18]
	ldr		r1,=BOX1OAM35
	b		@@_8037480
	.pool
@@_8037438:		;8037438
	ldr		r0,[r3,0x18]
	ldr		r1,=BOX1OAM35
	cmp		r0,r1
	beq		@@_8037448
	str		r1,[r3,0x18]
	mov		r0,0x0
	strb		r0,[r3,0x1C]
	strh		r0,[r3,0x16]
@@_8037448:		;8037448
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@return
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r2,r0,0x18
	cmp		r2,0x0
	beq		@@_8037474

	mov		r0, r3
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r3,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r3
	add		r1,0x20			;Palette row
	strb	r2, [r1]

	;mov		r1,r3
	;add		r1,0x20			;Palette row
	;mov		r0,0xC
	;strb		r0,[r1]
	b		@@return
	.pool
@@_8037474:		;8037474
	mov		r0,r3
	add		r0,0x20			;Palette row
	strb		r2,[r0]
	b		@@return
@@Pose9:		;803747c
	ldr		r0,[r3,0x18]
	ldr		r1,=BOX1OAM34
@@_8037480:		;8037480
	cmp		r0,r1
	beq		@@return
	str		r1,[r3,0x18]
	mov		r0,0x0
	strb		r0,[r3,0x1C]
	strh		r0,[r3,0x16]
@@return:		;803748c
	pop		r0
	bx		r0
	.pool

BOX1PartDefault:		;8037494
	push		r14
	ldr		r3,=CurrSpriteData
	mov		r0,r3
	add		r0,0x23			;Primary sprite RAM slot
	ldrb		r1,[r0]
	ldr		r2,=SpriteData
	lsl		r0,r1,0x3
	sub		r0,r0,r1
	lsl		r0,r0,0x3
	add		r2,r0,r2
	ldrh		r0,[r2]
	mov		r1,0x1
	and		r1,r0
	cmp		r1,0x0
	bne		@@_80374c0
	strh		r1,[r3]		;status
	b		@@_803750e
	.pool
@@_80374c0:		;80374c0
	ldrh		r1,[r3]
	mov		r0,0x80
	lsl		r0,r0,0x6
	and		r0,r1
	cmp		r0,0x0
	bne		@@_803750e
	mov		r0,r2
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	cmp		r0,0x44
	blt		@@_803750e
	cmp		r0,0x4A
	ble		@@_80374e2
	cmp		r0,0x4E
	bgt		@@_803750e
	cmp		r0,0x4D
	blt		@@_803750e
@@_80374e2:		;80374e2
	ldr		r0,=FrameCounter8Bit
	ldrb		r1,[r0]
	mov		r0,0x7
	and		r0,r1
	cmp		r0,0x0
	bne		@@_803750e
	mov		r0,0x8
	and		r0,r1
	lsl		r0,r0,0x18
	lsr		r2,r0,0x18
	cmp		r2,0x0
	beq		@@_8037508
	mov		r0, r3
    add     r0,0x33			;frozen palette row offset
    ldrb    r0, [r0]
    ldrb    r2, [r3,1Fh]
    add     r0, r0, r2
    mov     r2, 0xE
    sub     r2, r2, r0
	mov		r1,r3
	add		r1,0x20			;Palette row
	strb	r2, [r1]
	;mov		r1,r3
	;add		r1,0x20			;Palette row
	;mov		r0,0xD
	;strb		r0,[r1]
	b		@@_803750e
@@_8037508:		;8037508
	mov		r0,r3
	add		r0,0x20			;Palette row
	strb		r2,[r0]
@@_803750e:		;803750e
	pop		r0
	bx		r0
	.pool

BOX1BombInitialize:		;80376f0
	push		r4,r14
	ldr		r0,=CurrSpriteData
	mov		r12,r0
	ldrh		r1,[r0]			;status
	ldr		r0,=0xFFFB
	and		r0,r1
	mov		r2,0x0
	mov		r3,0x0
	mov		r1,0x80
	orr		r0,r1
	mov		r1,r12
	strh		r0,[r1]
	mov		r0,r12
	add		r0,0x27				;Draw distance top offset
	mov		r1,0x10
	strb		r1,[r0]
	add		r0,0x1
	strb		r1,[r0]
	add		r0,0x1
	strb		r1,[r0]
	ldr		r1,=0xFFE4
	mov		r4,r12
	strh		r1,[r4,0xA]
	mov		r0,0x1C
	strh		r0,[r4,0xC]
	strh		r1,[r4,0xE]
	strh		r0,[r4,0x10]
	ldr		r0,=BOX1OAM45
	str		r0,[r4,0x18]
	strb		r2,[r4,0x1C]
	strh		r3,[r4,0x16]
	ldr		r1,=SecondarySpriteStats
	ldrb		r0,[r4,0x1D]		;ID
	lsl		r3, r0, 4
	lsl		r0,r0, 1
	add		r0, r3
	add		r0,r0,r1
	ldrh		r0,[r0]
	strh		r0,[r4,0x14]		;Health
	mov		r0,r12
	add		r0,0x2A			;OAM rotation, was 2B
	strb		r2,[r0]
	mov		r0,0x80
	lsl		r0,r0,0x1
	strh		r0,[r4,0x12]	;OAM scaling
	mov		r0,r12
	add		r0,0x2D				;Timer 2, was 2F
	strb		r2,[r0]
	mov		r1,r12
	add		r1,0x2E				;was 30 -> 2E
	mov		r0,0x7
	strb		r0,[r1]
	mov		r0,r12
	add		r0,0x2F				;was 31
	strb		r2,[r0]
	sub		r0,0xB				;pose
	mov		r3,0x2
	strb		r3,[r0]
	mov		r2,r12
	add		r2,0x32				;Property, was 34
	ldrb		r1,[r2]
	mov		r0,0x40
	orr		r0,r1
	strb		r0,[r2]
	mov		r0,r12
	add		r0,0x25				;Collision
	mov		r3, 4
	strb		r3,[r0]
	;mov		r0,0x9C
	;lsl		r0,r0,0x2
	ldr		r0, =0x139			;music, was 270
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1BombMoving:		;8037794
	push		r4-r6,r14
	ldr		r1,=CurrSpriteData
	ldrh		r0,[r1,0x14]	;Health
	mov		r5,r1
	cmp		r0,0x0
	bne		@@_80377ac
	add		r1,0x24				;pose
	mov		r0,0x37
	strb		r0,[r1]
	b		@@_8037958
	.pool
@@_80377ac:		;80377ac
	mov		r0,0x2D				;Timer 2, was 2F
	add		r0,r0,r5
	mov		r12,r0
	ldrb		r6,[r0]
	mov		r0,r6
	cmp		r0,0x0
	bne		@@_80377fc
	mov		r3,r5
	add		r3,0x2F				;was 31
	ldrb		r2,[r3]
	ldr		r0,=BOX1Table4
	lsl		r1,r2,0x1
	add		r1,r1,r0
	ldrh		r4,[r1]
	ldr		r0,=0x7FFF
	cmp		r4,r0
	bne		@@_80377e4
	mov		r4,0x0
	add		r0,r6,1
	mov		r1,r12
	strb		r0,[r1]
	strb		r4,[r3]
	b		@@_80377e8
	.pool
@@_80377e4:		;80377e4
	add		r0,r2,1
	strb		r0,[r3]
@@_80377e8:		;80377e8
	mov		r0,r5
	add		r0,0x2F				;was 31
	ldrb		r0,[r0]
	cmp		r0,0x3
	bne		@@_80378d4
	mov		r1,r5
	add		r1,0x2E				;was 30
	mov		r0,0x7
	strb		r0,[r1]
	b		@@_80378d4
@@_80377fc:		;80377fc
	cmp		r0,0x2
	bne		@@_8037828
	mov		r3,r5
	add		r3,0x2F				;was 31
	ldrb		r2,[r3]
	ldr		r0,=BOX1Table5
@@_8037808:		;8037808
	lsl		r1,r2,0x1
	add		r1,r1,r0
	ldrh		r4,[r1]
	ldr		r0,=0x7FFF
	cmp		r4,r0
	bne		@@_803783c
	mov		r4,0x0
	add		r0,r6,1
	mov		r1,r12
	strb		r0,[r1]
	strb		r4,[r3]
	b		@@_80378d4
	.pool
@@_8037828:		;8037828
	cmp		r0,0x4
	bne		@@_8037842
	mov		r3,r5
	add		r3,0x2F				;was 31
	ldrb		r2,[r3]
	ldr		r0,=BOX1Table6
	b		@@_8037808
	.pool
@@_803783c:		;803783c
	add		r0,r2,1
	strb		r0,[r3]
	b		@@_80378d4
@@_8037842:		;8037842
	cmp		r0,0x6
	bne		@@_8037858
	mov		r0,r5
	add		r0,0x24				;pose
	mov		r1,0x18
	strb		r1,[r0]
	mov		r1,r5
	add		r1,0x2C				;Timer 1, was 2E
	mov		r0,0x3C
	strb		r0,[r1]
	b		@@_80378da
@@_8037858:		;8037858
	mov		r3,r5
	add		r3,0x2F				;was 31
	ldrb		r2,[r3]
	ldr		r1,=BOX1Table7
	lsl		r0,r2,0x1
	add		r0,r0,r1
	ldrh		r4,[r0]
	ldr		r0,=0x7FFF
	cmp		r4,r0
	bne		@@_8037880
	sub		r0,r2,1
	lsl		r0,r0,0x1
	add		r0,r0,r1
	ldrh		r4,[r0]
	b		@@_8037884
	.pool
@@_8037880:		;8037880
	add		r0,r2,1
	strb		r0,[r3]
@@_8037884:		;8037884
	ldr		r5,=CurrSpriteData
	ldrh		r0,[r5,0x2]		;y
	add		r0,0x20
	ldrh		r1,[r5,0x4]		;x
	ldr		r2, =SpriteUtilCheckVerticalCollisionAtPositionSlopes+1
	bl		WRapperR2
	mov		r1,r0
	ldr		r0,=PreviousVerticalCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_80378d4
	mov		r0,r1
	sub		r0,0x20
	strh		r0,[r5,0x2]
	mov		r4,r5
	add		r4,0x2D				;Timer 2, was 2F
	ldrb		r0,[r4]
	cmp		r0,0x1
	bne		@@_80378b0
	ldr		r0,=0x1E6			;music, was 271
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_80378b0:		;80378b0
	ldrb		r0,[r4]
	add		r0,0x1
	strb		r0,[r4]
	mov		r1,r5
	add		r1,0x2F				;was 31
	mov		r0,0x0
	strb		r0,[r1]
	sub		r1, 1				;was 30
	ldrb		r0,[r1]
	sub		r0, 2				;Timer 1, was 2E
	strb		r0,[r1]
	b		@@_80378da
	.pool
@@_80378d4:		;80378d4
	ldrh		r0,[r5,0x2]
	add		r0,r4,r0
	strh		r0,[r5,0x2]
@@_80378da:		;80378da
	mov		r4,r5
	ldrh		r1,[r4]
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	beq		@@_8037924
	mov		r2,r4
	add		r2,0x2A				;OAM rotation, was 2B
	mov		r0,r4
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r1,[r0]
	mov		r0,0x6
	sub		r0,r0,r1
	lsl		r0,r0,0x3
	ldrb		r1,[r2]
	add		r0,r0,r1
	strb		r0,[r2]
	ldrh		r0,[r4,0x2]
	ldrh		r1,[r4,0x4]
	add		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	bne		@@_8037958
	mov		r1,r4
	add		r1,0x2E				;was 30
	ldrh		r0,[r4,0x4]
	ldrb		r1,[r1]
	add		r0,r0,r1
	strh		r0,[r4,0x4]
	b		@@_8037958
	.pool
@@_8037924:		;8037924
	mov		r2,r5
	add		r2,0x2A			;OAM rotation, was 2B
	mov		r0,r5
	add		r0,0x2D				;Timer 2, was 2F
	ldrb		r0,[r0]
	mov		r1,0x6
	sub		r1,r1,r0
	lsl		r1,r1,0x3
	ldrb		r0,[r2]
	sub		r0,r0,r1
	strb		r0,[r2]
	ldrh		r0,[r5,0x2]
	ldrh		r1,[r5,0x4]
	sub		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	bne		@@_8037958
	mov		r0,r5
	add		r0,0x2E				;was 30
	ldrb		r1,[r0]
	ldrh		r0,[r5,0x4]
	sub		r0,r0,r1
	strh		r0,[r5,0x4]
@@_8037958:		;8037958
	pop		r4-r6
	pop		r0
	bx		r0
	.pool

BOX1BombLanded:		;8037964
	push		r4-r7,r14
	add		sp,-0xC
	ldr		r4,=CurrSpriteData
	ldrh		r0,[r4,0x14]		;Health
	cmp		r0,0x0
	bne		@@_8037980
	mov		r1,r4
	add		r1,0x24					;pose
	mov		r0,0x37
	strb		r0,[r1]
	b		@@_80379dc
	.pool
@@_8037980:		;8037980
	mov		r1,r4
	add		r1,0x2C					;Timer 1, was 2E
	ldrb		r0,[r1]
	sub		r0,0x1
	strb		r0,[r1]
	lsl		r0,r0,0x18
	lsr		r5,r0,0x18
	cmp		r5,0x0
	bne		@@_80379dc
	ldrb		r2,[r4,0x1F]		;Spriteset graphics slot
	mov		r6,r4
	add		r6,0x23					;Primary sprite RAM slot
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x2]			;y
	add		r0,0x20
	str		r0,[sp]
	ldrh		r0,[r4,0x4]			;x
	str		r0,[sp,0x4]
	str		r5,[sp,0x8]
	mov		r0,BOX1FireSpriteID
	mov		r1,0x0
	ldr		r7, =SpriteSpawnSecondary+1
	bl		WrapperR7
	ldrb		r2,[r4,0x1F]
	ldrb		r3,[r6]
	ldrh		r0,[r4,0x2]
	add		r0,0x20
	str		r0,[sp]
	ldrh		r0,[r4,0x4]
	str		r0,[sp,0x4]
	mov		r0,0x80
	lsl		r0,r0,0x2
	str		r0,[sp,0x8]
	mov		r0,BOX1FireSpriteID
	mov		r1,0x0
	ldr		r7, =SpriteSpawnSecondary+1
	bl		WrapperR7
	ldrh		r0,[r4,0x2]
	ldrh		r1,[r4,0x4]
	mov		r2,0x1F			;Explosion 2, was 22
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	strh		r5,[r4]
	ldr		r0,=0x1E8		;music, was 272
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_80379dc:		;80379dc
	add		sp,0xC
	pop		r4-r7
	pop		r0
	bx		r0
	.pool

BOX1BombExploding:		;80379e8
	push		r4,r14
	ldr		r4,=CurrSpriteData
	ldrh		r0,[r4,0x2]
	add		r0,0x20
	ldrh		r1,[r4,0x4]
	mov		r2,0x1E			;Explosion 8, was 32
	ldr		r3, =ParticleSet+1
	bl		WRapperR3
	mov		r0,0x0
	strh		r0,[r4]
	ldr		r0, =488			;music, was 273
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1FireInitialize:		;8037a10
	push		r4,r14
	ldr		r0,=CurrSpriteData
	mov		r12,r0
	ldrh		r1,[r0]
	ldr		r0,=0xFFFB
	and		r0,r1
	mov		r3,0x0
	mov		r2,0x0
	mov		r1,r12
	strh		r0,[r1]
	add		r1,0x27			;Draw distance top offset
	mov		r0,0x68
	strb		r0,[r1]
	add		r1,0x1
	mov		r0,0x8
	strb		r0,[r1]
	mov		r0,r12
	add		r0,0x29
	mov		r1,0x10
	strb		r1,[r0]
	ldr		r0,=0xFFE0
	mov		r4,r12
	strh		r0,[r4,0xA]	;HitBOX1 top offset
	strh		r2,[r4,0xC]
	add		r0,0x10
	strh		r0,[r4,0xE]
	strh		r1,[r4,0x10]
	ldr		r0,=BOX1OAM46
	str		r0,[r4,0x18]
	strb		r3,[r4,0x1C]
	strh		r2,[r4,0x16]
	ldr		r1,=SecondarySpriteStats
	ldrb		r0,[r4,0x1D]
	lsl		r2, r0, 4
	lsl		r0, r0, 1
	add		r0, r2
	add		r0,r0,r1
	ldrh		r0,[r0]
	strh		r0,[r4,0x14]	;health
	mov		r0,r12
	add		r0,0x24				;pose
	mov		r1,0x2
	strb		r1,[r0]
	add		r0,0x1				;Collision
	mov		r1, 4				;was 2
	strb		r1,[r0]
	pop		r4
	pop		r0
	bx		r0
	.pool

BOX1FireMovingHigh:		;8037a80
	push		r4-r6,r14
	ldr		r0,=CurrSpriteData
	ldrh		r0,[r0,0x16]	;Current animation frame
	cmp		r0,0x23
	bls		@@_8037a8c
	b		@@_8037bb4
@@_8037a8c:		;8037a8c
	lsl		r0,r0,0x2
	ldr		r1,=@@Table
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@Table:		;8037aa0
	.dw @@_8037b30
	.dw @@_8037b30
	.dw @@_8037b30
	.dw @@_8037b38
	.dw @@_8037b40
	.dw @@_8037ba4
	.dw @@_8037b5c
	.dw @@_8037b94
	.dw @@_8037b84
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037bb4
	.dw @@_8037b64
	.dw @@_8037b72
	.dw @@_8037b84
	.dw @@_8037b84
	.dw @@_8037b8c
	.dw @@_8037b94
	.dw @@_8037b9a
	.dw @@_8037ba4
	.dw @@_8037bac
@@_8037b30:		;8037b30
	ldr		r5,=0xFFE0
	b		@@_8037bb6
	.pool
@@_8037b38:		;8037b38
	ldr		r5,=0xFFC0
	b		@@_8037bb6
	.pool
@@_8037b40:		;8037b40
	ldr		r5,=0xFFA0
	ldr		r0,=CurrSpriteData
	ldrb		r0,[r0,0x1C]	;Animation duration counter
	cmp		r0,0x1
	bne		@@_8037bb6
	ldr		r0, =0x1E9			;music, was 274
	ldr		r1, =PlaySound+1
	bl		WRapperR1
	b		@@_8037bb6
	.pool
@@_8037b5c:		;8037b5c
	ldr		r5,=0xFF40
	b		@@_8037bb6
	.pool
@@_8037b64:		;8037b64
	ldr		r0,=CurrSpriteData
	ldrb		r0,[r0,0x1C]	;Animation duration counter
	cmp		r0,0x1
	bne		@@_8037b72
	ldr		r0,=0x1B3					;music, was 275			
	ldr		r1, =PlaySound+1
	bl		WRapperR1
@@_8037b72:		;8037b72
	ldr		r5,=0xFEA0
	b		@@_8037bb6
	.pool
@@_8037b84:		;8037b84
	ldr		r5,=0xFEC0
	b		@@_8037bb6
	.pool
@@_8037b8c:		;8037b8c
	ldr		r5,=0xFEE0
	b		@@_8037bb6
	.pool
@@_8037b94:		;8037b94
	mov		r5,0xFF
	lsl		r5,r5,0x8
	b		@@_8037bb6
@@_8037b9a:		;8037b9a
	ldr		r5,=0xFF20
	b		@@_8037bb6
	.pool
@@_8037ba4:		;8037ba4
	ldr		r5,=0xFF80
	b		@@_8037bb6
	.pool
@@_8037bac:		;8037bac
	ldr		r5,=0xFFA0
	b		@@_8037bb6
	.pool
@@_8037bb4:		;8037bb4
	ldr		r5,=0xFE80
@@_8037bb6:		;8037bb6
	ldr		r4,=CurrSpriteData
	mov		r6,0x0
	strh		r5,[r4,0xA]
	ldr		r0, =SpriteUtilCheckEndCurrentSpriteAnim+1
	bl		WRapperR0
	cmp		r0,0x0
	beq		@@_8037be0
	ldr		r0,=BOX1OAM58
	str		r0,[r4,0x18]
	mov		r0,0x0
	strb		r0,[r4,0x1C]
	strh		r6,[r4,0x16]
	mov		r1,r4
	add		r1,0x24				;pose
	mov		r0,0x18
	strb		r0,[r1]
	add		r1,0x8				;Timer 1, was 2E
	mov		r0,0x3C
	strb		r0,[r1]
	ldr		r0,=0xFFD0
	strh		r0,[r4,0xA]
@@_8037be0:		;8037be0
	ldrh		r1,[r4]
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	bne		@@_8037c1c
	ldrh		r0,[r4,0x2]
	sub		r0,0x40
	ldrh		r1,[r4,0x4]
	sub		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	bne		@@_8037c30
	ldrh		r0,[r4,0x4]
	add		r0,0x3
	b		@@_8037c3c
	.pool
@@_8037c1c:		;8037c1c
	ldrh		r0,[r4,0x2]
	sub		r0,0x40
	ldrh		r1,[r4,0x4]
	add		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8037c38
@@_8037c30:		;8037c30
	strh		r6,[r4]
	b		@@_8037c3e
	.pool
@@_8037c38:		;8037c38
	ldrh		r0,[r4,0x4]
	sub		r0,0x3
@@_8037c3c:		;8037c3c
	strh		r0,[r4,0x4]
@@_8037c3e:		;8037c3e
	pop		r4-r6
	pop		r0
	bx		r0

BOX1FireMovingLow:		;8037c44
	push		r4,r5,r14
	ldr		r4,=CurrSpriteData
	mov		r1,r4
	add		r1,0x2C			;Timer 1, was 2E
	ldrb		r0,[r1]
	sub		r0,0x1
	mov		r5,0x0
	strb		r0,[r1]
	lsl		r0,r0,0x18
	cmp		r0,0x0
	bne		@@_8037c6c
	ldr		r0,=BOX1OAM46
	str		r0,[r4,0x18]
	strb		r5,[r4,0x1C]
	strh		r5,[r4,0x16]
	sub		r1,0x8			;pose
	mov		r0,0x2
	strb		r0,[r1]
	ldr		r0,=0xFFE0
	strh		r0,[r4,0xA]
@@_8037c6c:		;8037c6c
	ldrh		r1,[r4]
	mov		r0,0x80
	lsl		r0,r0,0x2
	and		r0,r1
	cmp		r0,0x0
	bne		@@_8037ca4
	ldrh		r0,[r4,0x2]
	sub		r0,0x40
	ldrh		r1,[r4,0x4]
	sub		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	bne		@@_8037cb8
	ldrh		r0,[r4,0x4]
	add		r0,0x3
	b		@@_8037cc4
	.pool
@@_8037ca4:		;8037ca4
	ldrh		r0,[r4,0x2]
	sub		r0,0x40
	ldrh		r1,[r4,0x4]
	add		r1,0x20
	ldr		r2, =SpriteUtilCheckCollisionAtPosition+1
	bl		WRapperR2
	ldr		r0,=PreviousCollisionCheck
	ldrb		r0,[r0]
	cmp		r0,0x0
	beq		@@_8037cc0
@@_8037cb8:		;8037cb8
	strh		r5,[r4]
	b		@@_8037cc6
	.pool
@@_8037cc0:		;8037cc0
	ldrh		r0,[r4,0x4]
	sub		r0,0x3
@@_8037cc4:		;8037cc4
	strh		r0,[r4,0x4]
@@_8037cc6:		;8037cc6
	pop		r4,r5
	pop		r0
	bx		r0

.notice "BOX1 MainAI"
.notice tohex(.)
BOX1MainAI:		;3854C
	push		r14
	ldr		r0,=CurrSpriteData
	add		r0,0x24		;pose
	ldrb		r0,[r0]
	cmp		r0,0x4E
	bls		@@_803855a
	b		@@Pose43
@@_803855a:		;803855a
	lsl		r0,r0,0x2
	ldr		r1,=@@PoseTable
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
	.pool
@@PoseTable:		;803856c
	.dw @@Pose0
	.dw @@Pose1
	.dw @@Pose2
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Pose7
	.dw @@Pose8
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Pose17
	.dw @@Pose18
	.dw @@Pose19
	.dw @@Pose1A
	.dw @@Pose1B
	.dw @@Pose1C
	.dw @@Pose1D
	.dw @@Pose1E
	.dw @@Pose1F
	.dw @@Pose20
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Pose27
	.dw @@Pose28
	.dw @@Pose29
	.dw @@Pose2A
	.dw @@Return
	.dw @@Pose2C
	.dw @@Return
	.dw @@Pose2E
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Return
	.dw @@Pose37
	.dw @@Pose38
	.dw @@Pose39
	.dw @@Pose3A
	.dw @@_8038712
	.dw @@_8038716
	.dw @@_803871c
	.dw @@_8038720
	.dw @@Pose3F
	.dw @@Pose40
	.dw @@Pose41
	.dw @@Pose42
	.dw @@Pose43
	.dw @@_803875e
	.dw @@_8038764
	.dw @@Pose46
	.dw @@_803876e
	.dw @@_8038772
	.dw @@_8038778
	.dw @@_803877c
	.dw @@_80386fe
	.dw @@_8038702
	.dw @@_8038782
	.dw @@Pose4E
@@Pose0:
	bl      BOX1Initialize
	b       @@Return
@@Pose1:		;80386ae
	bl		BOX1CrawlingStart
@@Pose2:		;80386b2
	bl		BOX1Crawling
	b		@@Return
@@Pose17:		;80386b8
	bl		BOX1WaitingToRunStart
@@Pose18:		;80386bc
	bl		BOX1WaitingToRun
	b		@@Return
@@Pose19:		;80386c2
	bl		BOX1SlowRunningStart
@@Pose1A:		;80386c6
	bl		BOX1SlowRunning
	b		@@Return
@@Pose1B:		;80386cc
	bl		BOX1FastRunningStart
@@Pose1C:		;80386d0
	bl		BOX1FastRunning
	b		@@Return
@@Pose1D:		;80386d6
	bl		BOX1SkiddingStart
@@Pose1E:		;80386da
	bl		BOX1Skidding
	b		@@Return
@@Pose1F:		;80386e0
	bl		BOX1StoppedSkiddingStart
@@Pose20:		;80386e4
	bl		fBOX1StoppedSkidding
	b		@@Return
@@Pose7:		;80386ea
	bl		BOX1FinishedCrawlingStart
@@Pose8:		;80386ee
	bl		BOX1FinishedCrawling
	b		@@Return
@@Pose37:		;80386f4
	bl		BOX1BonkingStart
@@Pose38:		;80386f8
	bl		BOX1Bonking
	b		@@Return
@@_80386fe:		;80386fe
	bl		BOX1LandingFromBonkStart
@@_8038702:		;8038702
	bl		BOX1LandingFromBonk
	b		@@Return
@@Pose39:		;8038708
	bl		BOX1LandingStart
@@Pose3A:		;803870c
	bl		BOX1Landing
	b		@@Return
@@_8038712:		;8038712
	bl		BOX1WaitingToJumpStart
@@_8038716:		;8038716
	bl		BOX1WaitingToJump
	b		@@Return
@@_803871c:		;803871c
	bl		BOX1JumpingStart
@@_8038720:		;8038720
	bl		BOX1Jumping
	b		@@Return
@@Pose27:		;8038726
	bl		BOX1StoppingToFireBombStart
@@Pose28:		;803872a
	bl		BOX1StoppingToFireBomb
	b		@@Return
@@Pose29:		;8038730
	bl		BOX1LoweringToFireBombStart
@@Pose2A:		;8038734
	bl		BOX1LoweringToFireBomb
	b		@@Return
@@Pose2C:		;803873a
	bl		BOX1DoneFiringBombStart
	b		@@Return
@@Pose2E:		;8038740
	bl		BOX1DoneFiringBomb
	b		@@Return
@@Pose3F:		;8038746
	bl		BOX1WaitingToEmergeStart
@@Pose40:		;803874a
	bl		BOX1WaitingToEmerge
	b		@@Return
@@Pose41:		;8038750
	bl		BOX1FirstJumpStart
@@Pose42:		;8038754
	bl		BOX1FirstJump
	b		@@Return
@@Pose43:		;803875a
	bl		BOX1DyingStart
@@_803875e:		;803875e
	bl		BOX1Dying
	b		@@Return
@@_8038764:		;8038764
	bl		BOX1MovingToFinalJumpStart
@@Pose46:		;8038768
	bl		BOX1MovingToFinalJump
	b		@@Return
@@_803876e:		;803876e
	bl		BOX1WaitingForFinalJumpStart
@@_8038772:		;8038772
	bl		BOX1WaitingForFinalJump
	b		@@Return
@@_8038778:		;8038778
	bl		BOX1CrouchingForFinalJumpStart
@@_803877c:		;803877c
	bl		BOX1CrouchingForFinalJump
	b		@@Return
@@_8038782:		;8038782
	bl		BOX1FinalJumpStart
@@Pose4E:		;8038786
	bl		BOX1FinalJump
@@Return:		;803878a
	ldr		r0, =SpriteUtilUpdateSubSprite1Anim+1
	bl		WRapperR0
	ldr		r0, =SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position+1
	bl		WRapperR0
	pop		r0
	bx		r0
	.pool

.notice "BOX1 Part AI"
.notice tohex(.)
BOX1PartAI:		;38798
	push		r4,r14
	bl		BOX1PartCheckProjectile
	ldr		r0,=CurrSpriteData
	mov		r1,r0
	add		r1,0x24
	ldrb		r1,[r1]
	mov		r2,r0
	cmp		r1,0x0
	bne		@@_80387b4
	bl		BOX1PartInitialize
	b		@@return
	.pool
@@_80387b4:		;80387b4
	ldrb		r0,[r2,0x1E]
	cmp		r0,0x2
	beq		@@_80387f4
	cmp		r0,0x2
	bgt		@@_80387c4
	cmp		r0,0x0
	beq		@@_80387ce
	b		@@_803885c
@@_80387c4:		;80387c4
	cmp		r0,0x6
	beq		@@_803881c
	cmp		r0,0x8
	beq		@@_8038834
	b		@@_803885c
@@_80387ce:		;80387ce
	mov		r4,r2
	add		r4,0x2B				;Stun/flash timer, was 2c
	ldrb		r2,[r4]
	mov		r0,0x7F
	ldr		r1,=SubSpriteData1
	ldrb		r3,[r1,0xE]		;workVariable2, was e
	mov		r1,r0
	and		r1,r2
	and		r0,r3
	cmp		r1,r0
	bcs		@@_80387e6
	strb		r3,[r4]
@@_80387e6:		;80387e6
	bl		BOX1FrontLeftLeg
	ldr		r0, =SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position+1
	bl		WRapperR0
	b		@@return
	.pool
@@_80387f4:		;80387f4
	mov		r4,r2
	add		r4,0x2B				;Stun/flash timer, was 2c
	ldrb		r2,[r4]
	mov		r0,0x7F
	ldr		r1,=SubSpriteData1
	ldrb		r3,[r1,0xE]		;workVariable2, was e
	mov		r1,r0
	and		r1,r2
	and		r0,r3
	cmp		r1,r0
	bcs		@@_803880c
	strb		r3,[r4]
@@_803880c:		;803880c
	bl		BOX1FrontRightLeg
	ldr		r0, =SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position+1
	bl		WRapperR0
	b		@@return
	.pool
@@_803881c:		;803881c
	ldr		r0,=SubSpriteData1
	mov		r1,r2
	add		r1,0x2B				;Stun/flash timer, was 2c
	ldrb		r1,[r1]
	strb		r1,[r0,0xE]		;workVariable2, was e
	bl		BOX1Center
	ldr		r0, =SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position+1
	bl		WRapperR0
	b		@@return
	.pool
@@_8038834:		;8038834
	mov		r4,r2
	add		r4,0x2B				;Stun/flash timer, was 2c
	ldrb		r2,[r4]
	mov		r0,0x7F
	ldr		r1,=SubSpriteData1
	ldrb		r3,[r1,0xE]		;workVariable2, was e
	mov		r1,r0
	and		r1,r2
	and		r0,r3
	cmp		r1,r0
	bcs		@@_803884c
	strb		r3,[r4]
@@_803884c:		;803884c
	bl		f80372b8
	ldr		r0, =SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position+1
	bl		WRapperR0
	b		@@return
	.pool
@@_803885c:		;803885c
	mov		r4,r2
	add		r4,0x2B				;Stun/flash timer, was 2c
	ldrb		r2,[r4]
	mov		r0,0x7F
	ldr		r1,=SubSpriteData1
	ldrb		r3,[r1,0xE]		;workVariable2, was e
	mov		r1,r0
	and		r1,r2
	and		r0,r3
	cmp		r1,r0
	bcs		@@_8038874
	strb		r3,[r4]
@@_8038874:		;8038874
	bl		BOX1PartDefault
	bl		f8035b4c
@@return:		;803887c
	pop		r4
	pop		r0
	bx		r0
	.pool

.notice "BOX1 Bomb AI"
.notice tohex(.)
BOX1BombAI:		;388C8
	push		r14
	ldr		r0,=CurrSpriteData
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	cmp		r0,0x2
	beq		@@_80388f4
	cmp		r0,0x2
	bgt		@@_80388e4
	cmp		r0,0x0
	beq		@@_80388ee
	b		@@_8038904
	.pool
@@_80388e4:		;80388e4
	cmp		r0,0x18
	beq		@@_80388fa
	cmp		r0,0x37
	beq		@@_8038900
	b		@@_8038904
@@_80388ee:		;80388ee
	bl		BOX1BombInitialize
	b		@@_8038904
@@_80388f4:		;80388f4
	bl		BOX1BombMoving
	b		@@_8038904
@@_80388fa:		;80388fa
	bl		BOX1BombLanded
	b		@@_8038904
@@_8038900:		;8038900
	bl		BOX1BombExploding
@@_8038904:		;8038904
	pop		r0
	bx		r0
	.pool
.notice "BOX1 Fire AI"
.notice tohex(.)
BOX1FireAI:		;38908
	push		r14
	ldr		r0,=CurrSpriteData
	add		r0,0x24			;pose
	ldrb		r0,[r0]
	cmp		r0,0x2
	beq		@@_803892e
	cmp		r0,0x2
	bgt		@@_8038924
	cmp		r0,0x0
	beq		@@_803892a
	b		@@return
	.pool
@@_8038924:		;8038924
	cmp		r0,0x18
	beq		@@_8038934
	b		@@return
@@_803892a:		;803892a
	bl		BOX1FireInitialize
@@_803892e:		;803892e
	bl		BOX1FireMovingHigh
	b		@@return
@@_8038934:		;8038934
	bl		BOX1FireMovingLow
@@return:		;8038938
	pop		r0
	bx		r0
	.pool
