CheckNightmareDead:  ;made this outside of nightmarehtmare ai to be lazy so i dont have to redo the pointers in my VS code
	ldr		r3,=CurrSpriteData + 0x23
	ldrb	r3,[r3]
	ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
	ldrb    r1,[r0,0x1D]
    cmp     r1,NightmareID
	beq		@@CheckStatus
	mov		r0,1
	b 		@@Return
@@CheckStatus:
	ldrh	r1,[r0]
	mov		r0,1
	and		r1,r0
	cmp		r1,0
	beq		@@Return
	mov		r0,0
@@Return:
	bx		r14
.pool

UpdateSecondarySpritePos:
    push    r4,r14
    ldr     r3,=CurrBossData
    ldrh    r0,[r3,4]
    ldr     r1,[r3]
    lsl     r0,r0,3
    add     r0,r0,r1
    ldr     r4,[r0]
    ldr     r2,=CurrSpriteData
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r4
    ldrh    r0,[r0,2]
    ldrh    r1,[r3,8]
    add     r0,r0,r1
    strh    r0,[r2,2]
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r4
    ldrh    r0,[r0,4]
    ldrh    r3,[r3,0xA]
    add     r0,r0,r3
    strh    r0,[r2,4]
    pop     r4
    pop     r0
    bx      r0
    .pool

NightmarePartInit:
    push    r4,r14
    ldr     r3,=CurrSpriteData
    ldrh    r1,[r3]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r2,0
    strh    r0,[r3]			;removes invisible flag
    mov     r1,r3
    add     r1,0x24
    mov     r0,2
    strb    r0,[r1]			;sets pose 2
    mov     r0,r3
    add     r0,0x2D
    strb    r2,[r0]
    ldrb    r0,[r3,0x1E]
    mov     r12,r3
    cmp     r0,0xD			;part number
    bls     @@GetJump
    b       @@KillSprite
@@GetJump:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@NightmareFace,@@NightmareEyeSludge,@@NightmareEyes,@@NightmareMouth
    .dw @@RightArmTop,@@RightTurretTop,@@RightTurretMid,@@RightTurretLow
    .dw @@RightHand,@@Generator,@@KillSprite,@@LeftTurretTop
    .dw @@LeftTurretMid,@@LeftTurretLow
@@NightmareFace:
    mov     r2,r12
	ldr		r0,=Nightmare_43
	str		r0,[r2,18h]
	mov     r0,0
    strb    r0,[r2,0x1C]
    strh    r0,[r2,0x16]
    add     r2,0x22
    mov     r1,0
    mov     r0,9
    strb    r0,[r2]		;draw order
    add     r2,5
    mov     r0,0x10
    strb    r0,[r2]
    mov     r0,r12
    add     r0,0x28
    strb    r1,[r0]
    mov     r1,r12
    add     r1,0x29
    mov     r0,0x28
    strb    r0,[r1]		;draw boxes
    ldr     r1,=0xFFFC
    mov     r0,r12
    strh    r1,[r0,0xA]
    mov     r2,4
    mov     r0,4
    mov     r3,r12
    strh    r0,[r3,0xC]
    strh    r1,[r3,0xE]
    strh    r0,[r3,0x10]			;hitboxes
    ldrh    r0,[r3]
    orr     r0,r2
    mov     r2,0
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    strh    r0,[r3]					;adds 8004h flags to status
    b       @@SamusCollision
.pool
@@NightmareEyeSludge:
    mov     r1,r12
	ldr		r0,=Nightmare_41
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r2,0
    mov     r0,9
    strb    r0,[r1]			;draw order
    mov     r0,r12
    add     r0,0x27
    mov     r1,0x30
    strb    r1,[r0]
    add     r0,1
    strb    r2,[r0]
    add     r0,1
    strb    r1,[r0]			;draw boxes
    ldr     r1,=0xFFFC
    mov     r0,r12
    strh    r1,[r0,0xA]
    mov     r2,4
    mov     r0,4
    mov     r3,r12
    strh    r0,[r3,0xC]
    strh    r1,[r3,0xE]
    strh    r0,[r3,0x10]		;hitboxes
    ldrh    r0,[r3]
    orr     r0,r2
    mov     r2,0
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    strh    r0,[r3]				;adds 8004h to status
    b       @@SamusCollision
    .pool
@@NightmareEyes:
    mov     r1,r12
	ldr		r0,=Nightmare_10
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r2,0
    mov     r0,0xA
    strb    r0,[r1]				;draw order
    add     r1,5
    mov     r0,0x38
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x28
    strb    r2,[r0]
    add     r1,2
    mov     r0,0x28
    strb    r0,[r1]				;draw boxes
    mov     r3,0
    ldr     r1,=0xFF60
    mov     r0,r12
    strh    r1,[r0,0xA]
    ldr     r0,=0xFFB0
    mov     r4,r12
    strh    r0,[r4,0xC]
    strh    r1,[r4,0xE]
    strh    r2,[r4,0x10]		;hitboxes
    ldrh    r0,[r4]
    mov     r1,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,0x32
	ldrb	r0,[r4]
	mov		r1,0x40
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,r12
    add     r0,0x25
    strb    r3,[r0]				;0 to Samus Collision
    b       @@Return
.pool
@@NightmareMouth:
    mov     r2,r12
	ldr		r0,=Nightmare_10
	str		r0,[r2,18h]
	mov     r0,0
    strb    r0,[r2,0x1C]
    strh    r0,[r2,0x16]
    add     r2,0x22
    mov     r1,0
    mov     r0,0xB
    strb    r0,[r2]
    add     r2,5
    mov     r0,0x38
    strb    r0,[r2]
    mov     r0,r12
    add     r0,0x28
    strb    r1,[r0]
    mov     r1,r12
    add     r1,0x29
    mov     r0,0x30
    strb    r0,[r1]
    ldr     r1,=0xFFFC
    mov     r3,r12
    strh    r1,[r3,0xA]
    mov     r0,4
    strh    r0,[r3,0xC]
    strh    r1,[r3,0xE]
    strh    r0,[r3,0x10]
    ldrh    r0,[r3]
    mov     r1,0x80
    lsl     r1,r1,8
	add		r1,4
    orr     r0,r1			;adds 8004h flags to Status
    strh    r0,[r3]
	add		r3,0x32
	mov		r0,0x40
	ldrb	r1,[r3]
	orr		r0,r1
	strb	r0,[r3]
    mov     r2,0
@@SamusCollision:
    mov     r0,r12
    add     r0,0x25
    strb    r2,[r0]			;0 to Samus collision
    b       @@Return
    .pool
@@RightArmTop:
    mov     r1,r12
	ldr		r0,=Nightmare_18
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,4
    strb    r0,[r1]
    add     r1,5
    mov     r0,0x18
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x28
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r2,0
    ldr     r0,=0xFFC0
    mov     r1,r12
    strh    r0,[r1,0xA]
    mov     r1,0x20
    mov     r3,r12
    strh    r1,[r3,0xC]
    add     r0,0x20
    strh    r0,[r3,0xE]
    strh    r1,[r3,0x10]
    mov     r0,r12
    add     r0,0x25
    strb    r2,[r0]
    b       @@MakeImmune
    .pool
@@RightTurretTop:
    mov     r1,r12
	ldr		r0,=Nightmare_19
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,5
    strb    r0,[r1]
    add     r1,5
    mov     r0,0x1A
    strb    r0,[r1]
    add     r1,1
    mov     r0,0xA
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x18
    strb    r0,[r1]
    mov     r1,0
    ldr     r0,=0xFFA0
    mov     r2,r12
    strh    r0,[r2,0xA]
    mov     r0,8
    strh    r0,[r2,0xC]
    ldr     r0,=0xFFE8
    strh    r0,[r2,0xE]
    mov     r0,0x30
    b       @@MakeImmune2
    .pool
@@RightTurretMid:
    mov     r1,r12
	ldr		r0,=Nightmare_20
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,6
    strb    r0,[r1]
    add     r1,5
    mov     r0,0x20
    strb    r0,[r1]
    add     r1,1
    mov     r0,0xA
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x18
    strb    r0,[r1]
    mov     r1,0
    ldr     r0,=0xFFA0
    mov     r2,r12
    strh    r0,[r2,0xA]
    mov     r0,8
    strh    r0,[r2,0xC]
    ldr     r0,=0xFFE8
    strh    r0,[r2,0xE]
    mov     r0,0x40
    b       @@MakeImmune2
    .pool
@@RightTurretLow:
    mov     r1,r12
	ldr		r0,=Nightmare_21
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,7
    strb    r0,[r1]
    add     r1,5
    mov     r0,0x1A
    strb    r0,[r1]
    add     r1,1
    mov     r0,0xA
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x18
    strb    r0,[r1]
    mov     r1,0
    ldr     r0,=0xFFA0
    mov     r2,r12
    strh    r0,[r2,0xA]
    mov     r0,0x10
    strh    r0,[r2,0xC]
    ldr     r0,=0xFFFC
    strh    r0,[r2,0xE]
    mov     r0,0x40
    b       @@MakeImmune2
    .pool
@@RightHand:
    mov     r1,r12
	ldr		r0,=Nightmare_22
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,8
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r1,0x10
    strb    r1,[r0]
    add     r0,1
    strb    r1,[r0]
    mov     r1,r12
    add     r1,0x29
    mov     r0,0x18
    strb    r0,[r1]
    mov     r1,0
    ldr     r0,=0xFFC0
    mov     r2,r12
    strh    r0,[r2,0xA]
    mov     r0,0x30
    strh    r0,[r2,0xC]
    ldr     r0,=0xFFD0
    strh    r0,[r2,0xE]
    mov     r0,0x48
    b       @@MakeImmune2
    .pool
@@Generator:
    mov     r1,r12
	ldr		r0,=Nightmare_11
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,0xB
    strb    r0,[r1]
    add     r1,5
    mov     r0,4
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x20
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x28
    strb    r0,[r1]
    mov     r2,0
    ldr     r1,=0xFFFC
    mov     r0,r12
    strh    r1,[r0,0xA]
    mov     r0,0x60
    mov     r3,r12
    strh    r0,[r3,0xC]
    strh    r1,[r3,0xE]
    mov     r0,0x80
    strh    r0,[r3,0x10]
    mov     r1,r12
    add     r1,0x33
    mov     r0,3
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x25
    strb    r2,[r0]
    ldrh    r0,[r3]
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    strh    r0,[r3]
    ldr     r2,=SecondarySpriteStats
    ldrb    r1,[r3,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r2
    ldrh    r1,[r0]
    strh    r1,[r3,0x14]
    ldr     r0,=CurrBossData
    strh    r1,[r0,0xC]
    mov     r0,r12
    add     r0,0x2E
	mov		r2,0
    strb    r2,[r0]
    add     r0,1
    strb    r2,[r0]
    mov     r1,r12
    add     r1,0x24
    mov     r0,1
    strb    r0,[r1]
    b       @@Return
    .pool
@@LeftTurretTop:
    mov     r1,r12
	ldr		r0,=Nightmare_23
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,0xD
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    add     r1,6
    mov     r0,8
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x29
    strb    r2,[r0]
    mov     r2,0
    ldr     r0,=0xFFA0
    mov     r1,r12
    strh    r0,[r1,0xA]
    mov     r1,0x20
    mov     r3,r12
    strh    r1,[r3,0xC]
    add     r0,0x50
    strh    r0,[r3,0xE]
    strh    r1,[r3,0x10]
    mov     r0,r12
    add     r0,0x25
    strb    r2,[r0]
    b       @@MakeImmune
    .pool
@@LeftTurretMid:
    mov     r1,r12
	ldr		r0,=Nightmare_24
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,0xE
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    add     r1,6
    mov     r0,8
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x29
    strb    r2,[r0]
    mov     r1,0
    ldr     r0,=0xFFA0
    mov     r2,r12
    strh    r0,[r2,0xA]
    mov     r0,0x10
    strh    r0,[r2,0xC]
    ldr     r0,=0xFFF0
    strh    r0,[r2,0xE]
    mov     r0,0x20
@@MakeImmune2:
    strh    r0,[r2,0x10]
    mov     r0,r12
    add     r0,0x25
    strb    r1,[r0]
    ldrh    r0,[r2]
    mov     r3,0x80
    lsl     r3,r3,8
    mov     r1,r3
    orr     r0,r1
    strh    r0,[r2]
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]
    mov     r0,1
    mov     r4,r12
    strh    r0,[r4,0x14]
    b       @@Return
    .pool
@@LeftTurretLow:
    mov     r1,r12
	ldr		r0,=Nightmare_25
	str		r0,[r1,18h]
	mov     r0,0
    strb    r0,[r1,0x1C]
    strh    r0,[r1,0x16]
    add     r1,0x22
    mov     r0,0xF
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x27
    mov     r2,0x18
    strb    r2,[r0]
    add     r1,6
    mov     r0,0x10
    strb    r0,[r1]
    mov     r0,r12
    add     r0,0x29
    strb    r2,[r0]
    mov     r1,0
    ldr     r0,=0xFFC0
    mov     r3,r12
    strh    r0,[r3,0xA]
    strh    r2,[r3,0xC]
    add     r0,0x30
    strh    r0,[r3,0xE]
    mov     r0,0x20
    strh    r0,[r3,0x10]
    mov     r0,r12
    add     r0,0x25
    strb    r1,[r0]
@@MakeImmune:
    ldrh    r0,[r3]
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    strh    r0,[r3]		;adds 8000h flag to status
    mov     r2,r12
    add     r2,0x32
    ldrb    r1,[r2]
    mov     r0,0x40
    orr     r0,r1
    strb    r0,[r2]			;40h flag to properties, immune to projectiles
    mov     r0,1
    strh    r0,[r3,0x14]	;health = 1
    b       @@Return
    .pool
@@KillSprite:
    mov     r0,0
    mov     r1,r12
    strh    r0,[r1]
@@Return:
    bl      NightmareUpdateOAM
    pop     r4
    pop     r0
    bx      r0
	
NightmarePartMatchPal:
    push    r4,r14
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    ldr     r2,=CurrSpriteData
    ldrh    r3,[r2]
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    mov     r4,0
    orr     r1,r3
    strh    r1,[r2]
    mov     r1,r2
    add     r1,0x25
    strb    r4,[r1]
    ldr     r3,=SpriteData
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r3
    add     r1,0x20
    ldrb    r0,[r1]
    add     r2,0x20
    strb    r0,[r2]
    pop     r4
    pop     r0
    bx      r0
.pool

CheckFireLaser:
    push    r4,r14
    add     sp,-0xC
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,0x16]
    cmp     r0,0xB
    bne     @_805EB44
    ldrb    r0,[r1,0x1C]
    cmp     r0,3			;fires laser based on animation
    bne     @_805EB44
    ldrb    r2,[r1,0x1F]
    mov     r0,r1
    add     r0,0x23
    ldrb    r3,[r0]
    ldrh    r0,[r1,2]
    str     r0,[sp]
    ldrh    r0,[r1,4]
    sub     r0,0x20
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareBeam:
    mov     r0,NightmareBeamID			;laser beam
    mov     r1,0
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
@_805EB44:
    add     sp,0xC
	pop		r4
    pop     r0
    bx      r0
    .pool
.notice tohex(.)	
NightmareRightArmTopAI:
    push    r4-r6,r14
    add     sp,-0xC
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r5,r4
    add     r5,0x24
    ldrb    r0,[r5]
    cmp     r0,2			;checking pose
    beq     @@PrePhase1
    cmp     r0,0x18
    beq     @@CheckIfDead
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return1
	mov		r0,0x64
	add		r4,0x24
	strb	r0,[r4]
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,23h
	ldrh    r2,[r0,4h]		;sprite X position  
	add		r2,30h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
    b       @Return1
.pool
@@PrePhase1:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]			;toggles invisible flag
    ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A			;checks if nightmare is in phase 1 pose
    bne     @Return1
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]			;removes invisible flag
    mov     r1,r4
    add     r1,0x25
    mov     r0,0x4
    strb    r0,[r1]			;18h to samus collision
	mov		r0,0x18
    strb    r0,[r5]			;sets pose 18h
    b       @Return1
    .pool
@@CheckIfDead:
    ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x22			;checks if nightmare is dead, pose 22
    bne     @CheckIfDying1
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk1:
    mov     r0,NightmareChunkID			;arm chunk
    mov     r1,0
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]	;makes invisible
	add		r4,0x32
	mov		r0,0xBF
	ldrb	r1,[r4]
	and		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r5]		;pose 1Eh
    b       @Return1
    .pool
@CheckIfDying1:
    cmp     r0,0x20			;check if nightmare is dying, pose 20h
    bne     @Return1
    mov     r0,r3
    bl      NightmarePartMatchPal
@Return1:
    add     sp,0xC
    pop     r4-r6
    pop     r0
    bx      r0

NightmareRightArmLowAI:			;copy of the above function, (it even works the same if the other one is called in this ones place)
    push    r4-r6,r14
    add     sp,-0xC
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,0x23
    ldrb    r3,[r0]
    mov     r5,r4
    add     r5,0x24
    ldrb    r0,[r5]
    cmp     r0,2
    beq     @@_805EC54
    cmp     r0,0x18
    beq     @@_805EC8C
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return2
	mov		r0,0x64
	add		r4,0x24
	strb	r0,[r4]
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,50h
	ldrh    r2,[r0,4h]		;sprite X position  
	sub		r2,40h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
    b       @Return2
    .pool
@@_805EC54:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    bne     @Return2
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r1,r4
    add     r1,0x25
    mov     r0,4
    strb    r0,[r1]
	mov     r0,0x18
    strb    r0,[r5]
    b       @Return2
    .pool
@@_805EC8C:
    ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x22
    bne     @_805ECCC
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk2:
    mov     r0,NightmareChunkID
    mov     r1,4			;only difference between the two functions?
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,0x32
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r5]		;pose 1Eh
    b       @Return2
    .pool
@_805ECCC:
    cmp     r0,0x20
    bne     @Return2
    mov     r0,r3
    bl      NightmarePartMatchPal
@Return2:
    add     sp,0xC
    pop     r4-r6
    pop     r0
    bx      r0

NightmareRightTurret1:
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18			;checking pose
    beq     @@_805ED54
    cmp     r1,0x18
    bgt     @@_805ED08
    cmp     r1,2
    beq     @@PrePhase1
    b       @CheckKill3
    .pool
@@_805ED08:
    cmp     r1,0x1A
    beq     @@CheckDying
    cmp     r1,0x1C
    bne     @@_805ED12
    b       @@_805EE1C
@@_805ED12:
    b       @CheckKill3
@@PrePhase1:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]			;toggles invisible flag
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A			;checks if nightmare has started phase 1
    beq     @@Phase1Started
    b       @Return3
@@Phase1Started:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]			;removes invisible flag
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]			;4 to Samus collision
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x6C
    strb    r0,[r1]			;6Ch to 2Eh
	mov     r2,0x18
    strb    r2,[r7]			;18h to pose
    b       @Return3
.pool
@@_805ED54:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20			;checks if nightmare is dying
    beq     @@_805EDC2
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0			;timer
    beq     @@_805ED78
    b       @Return3
@@_805ED78:
    ldrb    r1,[r1]
    cmp     r1,2
    bne     @@_805ED8C
    ldr     r0,=Nightmare_34
    b       @@StoreOAM
    .pool
@@_805ED8C:
    cmp     r1,0x1C
    bne     @@_805ED98
    ldr     r0,=Nightmare_34
    b       @@StoreOAM
    .pool
@@_805ED98:
    ldr     r0,=Nightmare_26
@@StoreOAM:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]		;sets pose 1Ah
    b       @Return3
    .pool
@@CheckDying:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20			;checking if dying
    bne     @@CheckFireLaser
@@_805EDC2:
    ldr     r0,=Nightmare_19
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5			;matches palette of main sprite when dying (used for the flashing)
    bl      NightmarePartMatchPal
    b       @Return3
    .pool
@@CheckFireLaser:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_26
    cmp     r1,r0		
    bne     @@_805EDEC
    bl      CheckFireLaser
@@_805EDEC:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return3
    ldr     r0,=Nightmare_19
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r0,=CurrBossPattern
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]		;18h to pose
    b       @Return3
    .pool
@@_805EE1C:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22			;checking if nightmare is in last pose
    bne     @Return3
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk3:
    mov     r0,NightmareChunkID
    mov     r1,1
    mov     r2,0			;arm chunk
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return3
.pool
@CheckKill3:
	mov		r0,0x64
	strb	r0,[r7]
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return3
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,24h
	ldrh    r2,[r0,4h]		;sprite X position  
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return3:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareRightTurret2:				;literally the same as above with different OAM addresses
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18
    beq     @@_805EEFC
    cmp     r1,0x18
    bgt     @@_805EEB0
    cmp     r1,2
    beq     @@_805EEBC
    b       @_805F00C
    .pool
@@_805EEB0:
    cmp     r1,0x1A
    beq     @@_805EF58
    cmp     r1,0x1C
    bne     @@_805EEBA
    b       @@_805EFC4
@@_805EEBA:
    b       @_805F00C
@@_805EEBC:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    beq     @@_805EEDA
    b       @Return4
@@_805EEDA:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x68
    strb    r0,[r1]
	mov     r2,0x18
    strb    r2,[r7]
    b       @Return4
    .pool
@@_805EEFC:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    beq     @@_805EF6A
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_805EF20
    b       @Return4
@@_805EF20:
    ldrb    r1,[r1]
    cmp     r1,2
    bne     @@_805EF34
    ldr     r0,=Nightmare_35
    b       @@_805EF42
    .pool
@@_805EF34:
    cmp     r1,0x1C
    bne     @@_805EF40
    ldr     r0,=Nightmare_35
    b       @@_805EF42
    .pool
@@_805EF40:
    ldr     r0,=Nightmare_27
@@_805EF42:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]
    b       @Return4
    .pool
@@_805EF58:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    bne     @@_805EF88
@@_805EF6A:
    ldr     r0,=Nightmare_20
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5
    bl      NightmarePartMatchPal
    b       @Return4
    .pool
@@_805EF88:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_27
    cmp     r1,r0
    bne     @@_805EF94
    bl      CheckFireLaser
@@_805EF94:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return4
    ldr     r0,=Nightmare_20		
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r0,=CurrBossPattern
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]
    b       @Return4
    .pool
@@_805EFC4:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22
    bne     @Return4
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk4:
    mov     r0,NightmareChunkID
    mov     r1,2
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return4
    .pool
@_805F00C:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return4
	mov		r0,0x64
	strb	r0,[r7]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position  
	sub		r2,20h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return4:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareRightTurret3:			;basically the same as above
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18
    beq     @@_805F0A4
    cmp     r1,0x18
    bgt     @@_805F058
    cmp     r1,2
    beq     @@_805F064
    b       @_805F1B0
    .pool
@@_805F058:
    cmp     r1,0x1A
    beq     @@_805F0F4
    cmp     r1,0x1C
    bne     @@_805F062
    b       @@_805F168
@@_805F062:
    b       @_805F1B0
@@_805F064:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    beq     @@_805F082
    b       @Return5
@@_805F082:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x64
    strb    r0,[r1]
	mov     r2,0x18
    strb    r2,[r7]
    b       @Return5
    .pool
@@_805F0A4:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    beq     @@_805F106
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_805F0C8
    b       @Return5
@@_805F0C8:
    ldrb    r0,[r1]
    cmp     r0,0x1C
    bne     @@_805F0DC
    ldr     r0,=Nightmare_36
    b       @@_805F0DE
    .pool
@@_805F0DC:
    ldr     r0,=Nightmare_28
@@_805F0DE:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]
    b       @Return5
    .pool
@@_805F0F4:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    bne     @@_805F124
@@_805F106:
    ldr     r0,=Nightmare_21
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5
    bl      NightmarePartMatchPal
    b       @Return5
    .pool
@@_805F124:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_28
    cmp     r1,r0
    bne     @@_805F130
    bl      CheckFireLaser
@@_805F130:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return5
    ldr     r0,=Nightmare_21
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r2,=CurrBossPattern
    ldr     r0,=CurrBossDirection
    ldrb    r1,[r0]
    strb    r1,[r2]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]
    b       @Return5
    .pool
@@_805F168:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22
    bne     @Return5
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk5:
    mov     r0,NightmareChunkID
    mov     r1,3
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return5
    .pool
@_805F1B0:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return5
	mov		r0,0x64
	strb	r0,[r7]
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,30h
	ldrh    r2,[r0,4h]		;sprite X position  
	sub 	r2,10h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return5:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareLeftTurret1:
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18
    beq     @@_805F248
    cmp     r1,0x18
    bgt     @@_805F1FC
    cmp     r1,2
    beq     @@_805F208
    b       @_805F358
    .pool
@@_805F1FC:
    cmp     r1,0x1A
    beq     @@_805F2A4
    cmp     r1,0x1C
    bne     @@_805F206
    b       @@_805F310
@@_805F206:
    b       @_805F358
@@_805F208:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    beq     @@_805F226
    b       @Return6
@@_805F226:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x78
    strb    r0,[r1]
	mov     r2,0x18
    strb    r2,[r7]
    b       @Return6
    .pool
@@_805F248:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    beq     @@_805F2B6
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_805F26C
    b       @Return6
@@_805F26C:
    ldrb    r1,[r1]
    cmp     r1,2
    bne     @@_805F280
    ldr     r0,=Nightmare_37
    b       @@_805F28E
    .pool
@@_805F280:
    cmp     r1,0x1C
    bne     @@_805F28C
    ldr     r0,=Nightmare_37
    b       @@_805F28E
    .pool
@@_805F28C:
    ldr     r0,=Nightmare_29
@@_805F28E:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]
    b       @Return6
    .pool
@@_805F2A4:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    bne     @@_805F2D4
@@_805F2B6:
    ldr     r0,=Nightmare_23
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5
    bl      NightmarePartMatchPal
    b       @Return6
    .pool
@@_805F2D4:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_29
    cmp     r1,r0
    bne     @@_805F2E0
    bl      CheckFireLaser
@@_805F2E0:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return6
    ldr     r0,=Nightmare_23
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r0,=CurrBossPattern
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]
    b       @Return6
    .pool
@@_805F310:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22
    bne     @Return6
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk6:
    mov     r0,NightmareChunkID
    mov     r1,5
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return6
    .pool
@_805F358:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return6
	mov		r0,0x64
	strb	r0,[r7]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position  
	add		r2,30h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return6:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareLeftTurret2:
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18
    beq     @@_805F3F0
    cmp     r1,0x18
    bgt     @@_805F3A4
    cmp     r1,2
    beq     @@_805F3B0
    b       @_805F500
    .pool
@@_805F3A4:
    cmp     r1,0x1A
    beq     @@_805F44C
    cmp     r1,0x1C
    bne     @@_805F3AE
    b       @@_805F4B8
@@_805F3AE:
    b       @_805F500
@@_805F3B0:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    beq     @@_805F3CE
    b       @Return7
@@_805F3CE:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x74
    strb    r0,[r1]
	mov     r2,0x18
    strb    r2,[r7]
    b       @Return7
    .pool
@@_805F3F0:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    beq     @@_805F45E
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_805F414
    b       @Return7
@@_805F414:
    ldrb    r1,[r1]
    cmp     r1,2
    bne     @@_805F428
    ldr     r0,=Nightmare_38
    b       @@_805F436
    .pool
@@_805F428:
    cmp     r1,0x1C
    bne     @@_805F434
    ldr     r0,=Nightmare_38
    b       @@_805F436
    .pool
@@_805F434:
    ldr     r0,=Nightmare_30
@@_805F436:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]
    b       @Return7
    .pool
@@_805F44C:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    bne     @@_805F47C
@@_805F45E:
    ldr     r0,=Nightmare_24
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5
    bl      NightmarePartMatchPal
    b       @Return7
    .pool
@@_805F47C:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_30
    cmp     r1,r0
    bne     @@_805F488
    bl      CheckFireLaser
@@_805F488:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return7
    ldr     r0,=Nightmare_24
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r0,=CurrBossPattern
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]
    b       @Return7
    .pool
@@_805F4B8:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22
    bne     @Return7
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk7:
    mov     r0,NightmareChunkID
    mov     r1,6
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return7
    .pool
@_805F500:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return7
	mov		r0,0x64
	strb	r0,[r7]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position  
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return7:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareLeftTurret3:
    push    r4-r7,r14
    add     sp,-0xC
    ldr     r0,=CurrSpriteData
    mov     r6,r0
    add     r6,0x23
    ldrb    r5,[r6]
    mov     r7,r0
    add     r7,0x24
    ldrb    r1,[r7]
    mov     r4,r0
    cmp     r1,0x18
    beq     @@_805F598
    cmp     r1,0x18
    bgt     @@_805F54C
    cmp     r1,2
    beq     @@_805F558
    b       @_805F69C
    .pool
@@_805F54C:
    cmp     r1,0x1A
    beq     @@_805F5E8
    cmp     r1,0x1C
    bne     @@_805F556
    b       @@_805F654
@@_805F556:
    b       @_805F69C
@@_805F558:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]
    ldr     r1,=SpriteData
    lsl     r0,r5,3
    sub     r0,r0,r5
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A
    beq     @@_805F576
    b       @Return8
@@_805F576:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]
    mov     r0,r4
    add     r0,0x25
    mov     r2,4
    strb    r2,[r0]
    mov     r1,r4
    add     r1,0x2E
    mov     r0,0x70
    strb    r0,[r1]
    mov     r2,0x18
    strb    r2,[r7]
    b       @Return8
    .pool
@@_805F598:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    beq     @@_805F5FA
    mov     r2,r4
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@_805F5BC
    b       @Return8
@@_805F5BC:
    ldrb    r0,[r1]
    cmp     r0,0x1C
    bne     @@_805F5D0
    ldr     r0,=Nightmare_39
    b       @@_805F5D2
    .pool
@@_805F5D0:
    ldr     r0,=Nightmare_31
@@_805F5D2:
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]
    b       @Return8
    .pool
@@_805F5E8:
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x20
    bne     @@_805F618
@@_805F5FA:
    ldr     r0,=Nightmare_25
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    mov     r0,0x1C
    strb    r0,[r7]
    mov     r0,r5
    bl      NightmarePartMatchPal
    b       @Return8
    .pool
@@_805F618:
    ldr     r1,[r4,0x18]
    ldr     r0,=Nightmare_31
    cmp     r1,r0
    bne     @@_805F624
    bl      CheckFireLaser
@@_805F624:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    beq     @Return8
    ldr     r0,=Nightmare_25
    str     r0,[r4,0x18]
    mov     r0,0
    strb    r0,[r4,0x1C]
    strh    r0,[r4,0x16]
    ldr     r0,=CurrBossPattern
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x2E
    strb    r1,[r0]
    mov     r0,0x18
    strb    r0,[r7]
    b       @Return8
    .pool
@@_805F654:
    mov     r0,r5
    bl      NightmarePartMatchPal
    ldr     r0,=SpriteData
    lsl     r1,r5,3
    sub     r1,r1,r5
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x22
    bne     @Return8
    ldrb    r3,[r6]
    ldrh    r0,[r4,2]
    str     r0,[sp]
    ldrh    r0,[r4,4]
    str     r0,[sp,4]
    mov     r0,0
    str     r0,[sp,8]
NightmareChunk8:
    mov     r0,NightmareChunkID
    mov     r1,7
    mov     r2,0
    ldr     r6,=SpawnSecondarySprite + 1
	bl		WrapperR6
    ldrh    r1,[r4]
    mov     r0,4
    orr     r0,r1
    strh    r0,[r4]
	add		r4,32h
	mov		r0,0x40
	ldrb	r1,[r4]
	orr		r0,r1
	strb	r0,[r4]
    mov     r0,0x1E
    strb    r0,[r7]		;pose 1Eh
    b       @Return8
    .pool
@_805F69C:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @Return8
	mov		r0,0x64
	strb	r0,[r7]
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,10h
	ldrh    r2,[r0,4h]		;sprite X position  
	add		r2,2Ah
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@Return8:
    add     sp,0xC
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareEyeAI:
    push    r4-r7,r14
    mov     r7,r9
    mov     r6,r8
    push    r6,r7
	add		sp,-4
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x23
    ldrb    r6,[r0]
    add     r0,0x13
    ldrb    r4,[r0]
    ldr     r1,=SpriteData
    lsl     r0,r6,3
    sub     r0,r0,r6
    lsl     r0,r0,3
    add     r0,r0,r1
    ldrh    r7,[r0,0x14]
    mov     r0,r2
    add     r0,0x2B
    ldrb    r0,[r0]
    mov     r1,0x7F
    and     r1,r0
    cmp     r1,0x10
    bne     @@_805F704
    mov		r0,0C3h		;hurt sound (when face exposed)
    ldr     r1,=PlaySound3 + 1
	bl		WrapperR1
    b       @@CheckPose
    .pool
@@_805F704:
 ;   cmp     r1,5
 ;   bne     @@CheckPose
 ;  mov		r0,94h   
 ;  bl      PlaySound3
@@CheckPose:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,2
    mov     r5,r1
    cmp     r0,0x20
    bls     @@GetJump
    b       @@CheckIfDead
@@GetJump:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@CheckBreakPlate,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@Return,@@Return
    .dw @@Return,@@Return,@@CheckChangeOAM,@@Return
    .dw @@CheckAnimationDone,@@Return,@@CheckChangeOAM2,@@Return
    .dw @@CheckAnimationDone2,@@Return,@@CheckIfDead,@@Return
    .dw @@_805FA40
@@CheckBreakPlate:
    ldr     r0,=SpriteData
    lsl     r1,r6,3
    sub     r1,r1,r6
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]			;check pose of nightmare
    cmp     r0,0x1A			;pose when starting phase 3
    beq     @@BreakPlate
    b       @@Return
@@BreakPlate:
    ldrh    r1,[r5]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r5]
	mov		r0,r5
	add		r0,0x32
	mov		r2,0xBF
	ldrb	r1,[r0]
	and		r1,r2
	strb	r1,[r0]
    mov     r1,0
    mov     r2,0
    ldr     r0,=Nightmare_2
    str     r0,[r5,0x18]
    strb    r1,[r5,0x1C]
    strh    r2,[r5,0x16]	;OAM
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x18
    strb    r0,[r1]			;pose 18h
    strh    r7,[r5,0x14]	;gives face health of nightmare
    ldr     r0,=CurrBossData
    strh    r7,[r0,0xC]
    ldrh    r0,[r5,2]
    sub     r0,0x80
    ldrh    r1,[r5,4]
    sub     r1,0x50
    mov     r2,0x1E
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov		r0,0C5h		;faceplate explosion 
    ldr     r1,=PlaySound5 + 1
	bl		WrapperR1
    b       @@Return
 .pool
@@CheckChangeOAM:
    ldr     r1,=SpriteData
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r6,r0,r1
    mov     r0,r5
    add     r0,0x20
    ldrb    r1,[r0]
    mov     r0,r6
    add     r0,0x20
    strb    r1,[r0]			;matches palette
    ldr     r1,=CurrBossData
    ldrh    r0,[r5,0x14]
    strh    r0,[r1,0xC]
    ldrh    r4,[r1,0xC]
    lsl     r0,r7,1
    mov     r1,3
    ldr     r2,=DivideSigned + 1		;check if at 2/3rds health
	bl		WrapperR2
    cmp     r4,r0
    blt     @@ChangeOAM
    b       @@Return
@@ChangeOAM:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x1A
    strb    r0,[r1]			;pose 1A and change OAM
    ldr     r0,=Nightmare_8
    b       @@OAMChanged
.pool
@@CheckAnimationDone:
    ldr     r0,=SpriteData
    mov     r9,r0
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r6,r0,3
    mov     r1,r9
    add     r4,r6,r1
    mov     r0,r5
    add     r0,0x20
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x20
    mov     r2,0
    mov     r8,r2
    strb    r1,[r0]			;makes palette same
    ldr     r1,=CurrBossData
    ldrh    r0,[r5,0x14]
    mov     r7,0
    strh    r0,[r1,0xC]
    ldrh    r0,[r5,0x16]
    cmp     r0,0
    beq     @@CheckAnimationOver
    mov     r1,r5
    add     r1,0x33
    mov     r0,1
    strb    r0,[r1]
@@CheckAnimationOver:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    bne     @@ChangeOAM2
    b       @@Return
@@ChangeOAM2:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x1C
    strb    r0,[r1]		;pose 1C
    ldr     r0,=Nightmare_4
    str     r0,[r5,0x18]
    strb    r7,[r5,0x1C]
    mov     r0,r8
    strh    r0,[r5,0x16]
    mov     r0,r9
    add     r0,0x18
    add     r0,r6,r0
    ldr     r1,=Nightmare_5
    str     r1,[r0]
    strb    r7,[r4,0x1C]
    mov     r1,r8
    strh    r1,[r4,0x16]
    ldrh    r1,[r4]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r4]		;removes invisible flag
    mov     r1,r4
    add     r1,0x33
    mov     r0,1
    strb    r0,[r1]
    b       @@Return
.pool
@@CheckChangeOAM2:
    ldr     r1,=SpriteData
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r6,r0,r1
    mov     r0,r5
    add     r0,0x20
    ldrb    r1,[r0]
    mov     r0,r6
    add     r0,0x20
    strb    r1,[r0]		;updates palette
    ldr     r0,=CurrBossData
    ldrh    r4,[r5,0x14]
    strh    r4,[r0,0xC]
    mov     r0,r7
    mov     r1,3
    ldr     r2,=DivideUnsigned + 1
	bl		WrapperR2
    lsl     r4,r4,0x10
    lsl     r0,r0,0x10
    cmp     r4,r0			;checks if at 1/3rd health
    bcc     @@ChangeOAM3
    b       @@Return
@@ChangeOAM3:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x1E
    strb    r0,[r1]			;pose 1E
    ldr     r0,=Nightmare_9
@@OAMChanged:
    str     r0,[r5,0x18]
    mov     r0,0
    strb    r0,[r5,0x1C]
    mov     r0,0
    strh    r0,[r5,0x16]
    ldrh    r0,[r6]
    mov     r1,4
    orr     r0,r1
    strh    r0,[r6]
    ldr     r0,=0x12C		;resets animation and plays face degrading sound
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    b       @@Return
.pool
@@CheckAnimationDone2:
    ldr     r2,=SpriteData
    mov     r9,r2
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r6,r0,3
    add     r4,r6,r2
    mov     r0,r5
    add     r0,0x20
    ldrb    r1,[r0]
    mov     r0,r4
    add     r0,0x20
    mov     r2,0
    mov     r8,r2
    strb    r1,[r0]
    ldr     r1,=CurrBossData
    ldrh    r0,[r5,0x14]
    mov     r7,0
    strh    r0,[r1,0xC]
    ldrh    r0,[r5,0x16]
    cmp     r0,0
    beq     @@CheckAnimationOver2
    mov     r1,r5
    add     r1,0x33
    mov     r0,2
    strb    r0,[r1]
@@CheckAnimationOver2:
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    bne     @@ChangeOAM4
    b       @@Return
@@ChangeOAM4:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x20
    strb    r0,[r1]		;pose 20h
    ldr     r0,=Nightmare_6
    str     r0,[r5,0x18]
    strb    r7,[r5,0x1C]
    mov     r0,r8
    strh    r0,[r5,0x16]
    mov     r0,r9
    add     r0,0x18
    add     r0,r6,r0
    ldr     r1,=Nightmare_7
    str     r1,[r0]
    strb    r7,[r4,0x1C]
    mov     r1,r8
    strh    r1,[r4,0x16]
    ldrh    r1,[r4]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r4]
    mov     r1,r4
    add     r1,0x33
    mov     r0,2
    strb    r0,[r1]
    b       @@Return
.pool
@@CheckIfDead:
    ldr     r2,=SpriteData
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r0,r0,r2
    mov     r1,r5
    add     r1,0x20
    ldrb    r1,[r1]
    add     r0,0x20
    strb    r1,[r0]
    ldr     r1,=CurrBossData
    ldrh    r0,[r5,0x14]
    mov     r3,0
    strh    r0,[r1,0xC]
    lsl     r0,r0,0x10
    cmp     r0,0		;checks if health is 0
    bne     @@Return
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x22
    strb    r0,[r1]		;pose 22
    mov     r0,r5
    add     r0,0x2E
    strb    r3,[r0]		;0 to 2Eh
    sub     r0,2		
    strb    r3,[r0]		;0 to 2Ch
    lsl     r0,r6,3
    sub     r0,r0,r6
    lsl     r0,r0,3
    add     r2,r0,r2
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x20
    strb    r0,[r1]		;sets dying pose to nightmare
    ldrh    r0,[r2]
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    strh    r0,[r2]		;adds 8000h flag to nightmare
    mov     r0,r2
    add     r0,0x25
    strb    r3,[r0]		;0 to nightmare's Samus Collision
    mov     r1,r2
    add     r1,0x2E
    mov     r0,0x50
    strb    r0,[r1]
    mov     r0,r2
    add     r0,0x2F
    strb    r3,[r0]
    b       @@Return
    .pool
@@_805FA40:
    mov     r2,r5
    add     r2,0x2E
    ldrb    r0,[r2]
    add     r1,r0,1
    strb    r1,[r2]
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    bne     @@_805FA76
    mov     r0,4
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_805FA70
    mov     r0,r5
    add     r0,0x33
    ldrb    r0,[r0]
    ldrb    r1,[r5,0x1F]
    add     r0,r0,r1
    mov     r1,0xE
    sub     r1,r1,r0
@@_805FA70:
    mov     r0,r5
    add     r0,0x20
    strb    r1,[r0]
@@_805FA76:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @@MatchPalette
    ldr		r0,=CurrSpriteData
	mov		r1,r0
	add		r1,0x24
	mov		r2,0x64
	strb	r2,[r1]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position
	sub		r2,0x1A
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
	b		@@Return
@@MatchPalette:
	ldr		r2,=SpriteData
    lsl     r0,r4,3
    sub     r0,r0,r4
    lsl     r0,r0,3
    add     r0,r0,r2
    mov     r1,r5
    add     r1,0x20
    ldrb    r1,[r1]
    add     r0,0x20
    strb    r1,[r0]
    b       @@Return
.pool
@@Return:
	add		sp,4
    pop     r3,r4
    mov     r8,r3
    mov     r9,r4
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareMouthAI:
    push    r4,r5,r14
	add		sp,-4
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,0x23
    ldrb    r4,[r0]
    mov     r5,r3
    add     r5,0x24
    ldrb    r0,[r5]
    cmp     r0,2
    beq     @@CheckBreakPlate
    b 		@@CheckDead
.pool
@@CheckBreakPlate:
    ldr     r0,=SpriteData
    lsl     r1,r4,3
    sub     r1,r1,r4
    lsl     r1,r1,3
    add     r1,r1,r0
    mov     r4,r1
    add     r4,0x24
    ldrb    r0,[r4]
    cmp     r0,0x1A		;check if nightmare starts phase 3
    bne     @@Return
    ldrh    r1,[r3]
    ldr     r0,=0xFFFB
    and     r0,r1
    strh    r0,[r3]	
	mov		r0,r3
	add		r0,32h
	mov		r1,0xBF
	ldrb	r2,[r0]
	and		r1,r2
	strb	r1,[r0]
    mov     r1,0
    mov     r2,0
    ldr     r0,=Nightmare_3
    str     r0,[r3,0x18]
    strb    r1,[r3,0x1C]
    strh    r2,[r3,0x16]
    mov     r0,0x18
    strb    r0,[r5]		;pose 18h
    mov     r0,0x1E
    strb    r0,[r4]		;sets pose 1Eh for nightmare?
    b       @@Return
.pool
@@CheckDead:
    ldrh    r0,[r3,0x16]
    cmp     r0,0
    bne     @@CheckMosaic
    ldrb    r0,[r3,0x1C]
    cmp     r0,1
    bne     @@CheckMosaic
 ;   mov     r0,0xAB
 ;   lsl     r0,r0,2
 ;  bl      PlaySound1
@@CheckMosaic:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @@Return
	ldr		r0,=CurrSpriteData
	add		r0,0x24
	mov		r1,0x64
	strb	r1,[r0]
    ldrh    r1,[r3,2h]		;sprite Y position 
	ldrh    r2,[r3,4h]		;sprite X position
	add		r2,0x15
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@@Return:
	add		sp,4
    pop     r4,r5
    pop     r0
    bx      r0
.pool

NightmareEyeSludgeAI:
    push    r4-r6,r14
	add		sp,-4
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x23
    ldrb    r4,[r0]
    ldr     r3,=SecondarySpriteStats
    ldrb    r1,[r2,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r3
    ldrh    r3,[r0]
    mov     r0,r2
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,2
    mov     r5,r2
    cmp     r0,0x1C
    bls     @@_805FBC8
    b       @@CheckDead
@@_805FBC8:
    lsl     r0,r0,2
    ldr     r1,=@@_805FBE0
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@_805FBE0:
    .dw @@_805FC54,@@CheckDead,@@CheckDead,@@CheckDead
    .dw @@CheckDead,@@CheckDead,@@CheckDead,@@CheckDead
    .dw @@CheckDead,@@CheckDead,@@CheckDead,@@CheckDead
    .dw @@CheckDead,@@CheckDead,@@CheckDead,@@CheckDead
    .dw @@CheckDead,@@CheckDead,@@CheckDead,@@CheckDead
    .dw @@CheckDead,@@CheckDead,@@_805FC90,@@CheckDead
    .dw @@_805FCC8,@@CheckDead,@@_805FD10,@@CheckDead
    .dw @@_805FD58
@@_805FC54:
    ldr     r0,=CurrBossData
    ldrh    r4,[r0,0xC]
    lsl     r0,r3,1
    mov     r1,3
    ldr     r2,=DivideSigned + 1
	bl		WrapperR2
    cmp     r4,r0
    blt     @@_805FC66
    b       @@Return
@@_805FC66:
    ldrh    r1,[r5]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r1,0
    mov     r2,0
    strh    r0,[r5]
    ldr     r0,=Nightmare_40
    str     r0,[r5,0x18]
    strb    r1,[r5,0x1C]
    strh    r2,[r5,0x16]
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x18
    b       @@_805FD00
    .pool
@@_805FC90:
    ldr     r4,=CurrBossData
    mov     r0,r3
    mov     r1,3
    ldr     r2,=DivideUnsigned + 1
	bl		WrapperR2
    ldrh    r1,[r4,0xC]
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    cmp     r1,r0
    bcc     @@_805FCA6
    b       @@Return
@@_805FCA6:
    ldr     r0,=Nightmare_41
    str     r0,[r5,0x18]
    mov     r0,0
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]
    mov     r1,r5
    add     r1,0x2E
    mov     r0,0x78
    strb    r0,[r1]
    sub     r1,0xA
    mov     r0,0x1A
    b       @@_805FD00
    .pool
@@_805FCC8:
    ldr     r0,=CurrBossData
    ldrh    r0,[r0,0xC]
    cmp     r0,0
    bne     @@_805FCE8
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]
    mov     r1,r5
    add     r1,0x2E
    mov     r0,0x50
    strb    r0,[r1]
    sub     r1,0xA
    mov     r0,0x1C
    b       @@_805FD00
    .pool
@@_805FCE8:
    mov     r1,r5
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,0
    bne     @@Return
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]
    mov     r0,0x78
@@_805FD00:
    strb    r0,[r1]
    mov     r0,0x94	;bubbly sound when ooze leaks from face
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    b       @@Return
    .pool
@@_805FD10:
    mov     r6,r5
    add     r6,0x2E
    ldrb    r0,[r6]
    sub     r0,1
    strb    r0,[r6]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,0
    bne     @@_805FD30
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]
    mov     r0,0x50
    strb    r0,[r6]
;    ldr     r0,=0x12E
 ;   bl      PlaySound1
@@_805FD30:
    ldr     r0,=SpriteData
    lsl     r1,r4,3
    sub     r1,r1,r4
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x19
    bne     @@Return
    mov     r0,r5
    add     r0,0x24
    mov     r1,0x1E
    strb    r1,[r0]
    mov     r0,0x50
    strb    r0,[r6]
    b       @@Return
    .pool
@@_805FD58:
    ldrh    r0,[r5]
    mov     r1,4
    eor     r0,r1
    strh    r0,[r5]
    mov     r1,r5
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@Return
    ldrh    r0,[r5]
    mov     r1,4
    orr     r0,r1
    strh    r0,[r5]
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x20
    strb    r0,[r1]
    b       @@Return
@@CheckDead:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @@Return
	ldr		r0,=CurrSpriteData
	add		r0,0x24
	mov		r1,0x64
	strb	r1,[r0]
    ldrh    r1,[r0,2h]		;sprite Y position 
	sub		r1,1Ah
	ldrh    r2,[r0,4h]		;sprite X position  
	sub		r2,20h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@@Return:
	add		sp,4
    pop     r4-r6
    pop     r0
    bx      r0
.pool

NightmareChinSludge:
    push    r4-r6,r14
	add		sp,-4
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,0x23
    ldrb    r3,[r0]
    ldr     r4,=SecondarySpriteStats
    ldrb    r1,[r2,0x1D]
    lsl     r0,r1,3
	add		r0,r0,r1
	lsl		r0,r0,1
    add     r0,r0,r4
    ldrh    r0,[r0]		;health of generator
    mov     r6,r2
    add     r6,0x24
    ldrb    r1,[r6]
    mov     r5,r2
    cmp     r1,0x18
    beq     @@CheckTimer
    cmp     r1,0x18
    bgt     @@_805FDDC
    cmp     r1,2
    beq     @@CheckHealth
    b       @@CheckKill
    .pool
@@_805FDDC:
    cmp     r1,0x1A
    beq     @@CheckTimer2
    cmp     r1,0x1C
    beq     @@CheckTimer3
    b       @@CheckKill
@@CheckHealth:
    ldr     r4,=CurrBossData
    mov     r1,3
    ldr     r2,=DivideUnsigned + 1
	bl		WrapperR2
    ldrh    r1,[r4,0xC]
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    cmp     r1,r0		;checks if generator is at 1/3rd health
    bcs     @@Return
    mov     r0,r5
    add     r0,0x2E
    mov     r1,0x78
    strb    r1,[r0]		;78h to 2Eh
    mov     r0,0x18
    strb    r0,[r6]		;pose 18h
    b       @@Return
    .pool
@@CheckTimer:
    mov     r3,r5
    add     r3,0x2E
    ldrb    r0,[r3]
    sub     r0,1
    strb    r0,[r3]
    lsl     r0,r0,0x18
    lsr     r2,r0,0x18
    cmp     r2,0			;check and decrement timer
    bne     @@Return
    ldrh    r1,[r5]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r1,0
    strh    r0,[r5]			;remove invisible flag
    ldr     r0,=Nightmare_42
    str     r0,[r5,0x18]
    strb    r1,[r5,0x1C]
    strh    r2,[r5,0x16]
    mov     r0,0x1A
    strb    r0,[r6]			;pose 1Ah
    mov     r0,0x64
    strb    r0,[r3]			;64h to 2Eh
    b       @@Return
.pool
@@CheckTimer2:
    mov     r2,r5
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,0		;check timer
    bne     @@CheckNightmarePose
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]	;reset animation
    mov     r0,0x64
    strb    r0,[r2]			;64h to 2Eh
@@CheckNightmarePose:
    ldr     r0,=SpriteData
    lsl     r1,r3,3
    sub     r1,r1,r3
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x19		;checking if nightmare is starting phase3
    bne     @@Return
    mov     r0,0x1C
    strb    r0,[r6]		;set pose 1C
    mov     r0,0x50
    strb    r0,[r2]
    b       @@Return
    .pool
@@CheckTimer3:
    ldrh    r0,[r5]
    mov     r1,4
    eor     r0,r1
    strh    r0,[r5]		;toggling invisible flag
    mov     r1,r5
    add     r1,0x2E
    ldrb    r0,[r1]
    sub     r0,1
    strb    r0,[r1]
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@Return
    ldrh    r0,[r5]
    mov     r1,4h
    orr     r0,r1
    strh    r0,[r5]
	add		r5,0x32
	mov		r1,0x40
	ldrb	r0,[r5]
	orr		r0,r1
	strb	r0,[r5]
    mov     r0,0x1E
    strb    r0,[r6]		;pose 1Eh
    ldr     r1,=SpriteData
    lsl     r0,r3,3
    sub     r0,r0,r3
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    mov     r1,0x1A
    strb    r1,[r0]		;pose 1A to nightmare?
    b       @@Return
.pool
@@CheckKill:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @@Return
	ldr		r0,=CurrSpriteData
	mov		r1,r0
	add		r1,0x24
	mov		r2,0x64
	strb	r1,[r2]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position  
	add		r2,20h
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
@@Return:
	add		sp,4
    pop     r4-r6
    pop     r0
    bx      r0
.pool

UpdateGeneratorPal:
    push    r4,r5,r14
    ldr     r3,=CurrSpriteData
    mov     r0,0x2E
    add     r0,r0,r3
    mov     r12,r0
    ldrb    r1,[r0]
    mov     r4,7
    mov     r0,r4
    and     r0,r1
    cmp     r0,0
    bne     @@Return
    ldr     r2,=PalTable
    mov     r5,r3
    add     r5,0x2F
    ldrb    r1,[r5]
    mov     r0,r4
    and     r0,r1
    add     r0,r0,r2
    ldrb    r2,[r0]
    mov     r0,r3
    add     r0,0x20
    strb    r2,[r0]
    add     r1,1
    strb    r1,[r5]
@@Return:
    mov     r1,r12
    ldrb    r0,[r1]
    add     r0,1
    strb    r0,[r1]
    pop     r4,r5
    pop     r0
    bx      r0
    .pool
	
PalTable:
	.db 0,1,2,3,4,3,2,1

GeneratorDyingUpdatePal:
    push    r14
    ldr     r2,=CurrSpriteData
    mov     r3,r2
    add     r3,0x2E
    ldrb    r0,[r3]
    add     r1,r0,1
    strb    r1,[r3]
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    bne     @@_805FF66
    mov     r0,4
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_805FF60
    mov     r0,r2
    add     r0,0x33
    ldrb    r0,[r0]	
    ldrb    r1,[r2,0x1F]
    add     r0,r0,r1
    mov     r1,0xE
    sub     r1,r1,r0
@@_805FF60:
    mov     r0,r2
    add     r0,0x20
    strb    r1,[r0]		;palette
@@_805FF66:
    pop     r0
    bx      r0
.pool

NightmareGeneratorAI:
    push    r4-r7,r14
	add		sp,-4
    ldr     r0,=CurrSpriteData
    mov     r1,r0
    add     r1,0x23
    ldrb    r6,[r1]
    add     r0,0x2B
    ldrb    r0,[r0]
    mov     r1,0x7F
    and     r1,r0
    cmp     r1,0x10
    bne     @@_805FF98
    mov		r0,0C3h
    ldr     r1,=PlaySound3 + 1	;hurt generator sound?
	bl		WrapperR1
    b       @@_805FFA2
    .pool
@@_805FF98:
    cmp     r1,5
    bne     @@_805FFA2
;    ldr     r0,=0x12D
;    bl      PlaySound3
@@_805FFA2:
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    sub     r0,1
    mov     r4,r1
    cmp     r0,0x1F
    bls     @@GetJump
	b		@@_8060188
@@GetJump:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@CheckStartPhase1,@@CheckStartPhase2,@@CheckKill,@@CheckKill
    .dw @@CheckKill,@@CheckKill,@@CheckKill,@@CheckKill
    .dw @@CheckKill,@@CheckKill,@@CheckKill,@@CheckKill
    .dw @@CheckKill,@@CheckKill,@@CheckKill,@@CheckKill
    .dw @@CheckKill,@@CheckKill,@@CheckKill,@@CheckKill
    .dw @@CheckKill,@@CheckKill,@@CheckKill,@@_806010C
    .dw @@CheckKill,@@_8060188,@@CheckKill,@@_80601F4
    .dw @@CheckKill,@@_806029C,@@CheckKill,@@_80602C4
@@CheckStartPhase1:
    ldrh    r1,[r4]
    mov     r0,4
    mov     r2,r1
    eor     r2,r0
    strh    r2,[r4]		;toggle invisible flag
    ldr     r1,=SpriteData
    lsl     r0,r6,3
    sub     r0,r0,r6
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3A		;checks if nightmare started phase 1
    beq     @@StartPhase1
    b       @@CheckSlowSamus
@@StartPhase1:
    ldr     r0,=0x7FFB
    and     r2,r0
    strh    r2,[r4]		;removes invisible flag
    mov     r1,r4
    add     r1,0x25
    mov     r0,4
    strb    r0,[r1]		;18h to SamusCollision
    sub     r1,1
    mov     r0,2
    strb    r0,[r1]		;pose 2
    b       @@CheckSlowSamus
.pool
@@CheckStartPhase2:
    bl      UpdateGeneratorPal
    ldr     r2,=CurrBossData
    ldr     r5,=CurrSpriteData
    ldrh    r0,[r5,0x14]
    mov     r7,0
    strh    r0,[r2,0xC]
    ldr     r3,=SecondarySpriteStats
    ldrb    r1,[r5,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
	lsl		r0,r0,1
	add		r0,r0,r3
    ldrh    r0,[r0]
    ldrh    r4,[r2,0xC]
    lsl     r0,r0,2
    mov     r1,5
    ldr     r2,=DivideSigned + 1
	bl		WrapperR2
    cmp     r4,r0			;check if at 4/5ths health
    blt     @@StartPhase2
    b       @@CheckSlowSamus
@@StartPhase2:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x18
    strb    r0,[r1]		;pose 18h
    ldr     r0,=Nightmare_17
    str     r0,[r5,0x18]
    strb    r7,[r5,0x1C]
    mov     r0,0
    strh    r0,[r5,0x16]
    mov     r0,r5
    add     r0,0x2D
    strb    r7,[r0]		;0 to 2Dh
    ldr     r1,=GravityActive
    mov     r0,0x1
    strb    r0,[r1]
    ldr     r1,=SpriteData
    lsl     r0,r6,3
    sub     r0,r0,r6
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    mov     r1,0x3B
    strb    r1,[r0]			;sets phase 2 to nightmare
    ldr     r1,=CurrBossDirection
    mov     r0,0x3C
    strb    r0,[r1]
    ldr     r0,=0x2A5
    ldr     r1,=PlaySound1 + 1
	bl		WrapperR1
    b       @@CheckSlowSamus
.pool
@@_806010C:
    bl      MakeMissileFall
    bl      UpdateGeneratorPal
    ldr     r0,=CurrBossData
    ldr     r4,=CurrSpriteData
    ldrh    r1,[r4,0x14]
    strh    r1,[r0,0xC]
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    bne     @@_8060126
    b       @@CheckSlowSamus
@@_8060126:
    mov     r0,0
    strb    r0,[r4,0x1C]
    mov     r0,0
    strh    r0,[r4,0x16]	;reset animation
    mov     r0,r4
    add     r0,0x2D
    ldrb    r0,[r0]
    cmp     r0,0
    bne     @@_8060148
    ldr     r0,=Nightmare_16
    b       @@StoreOAM
.pool
@@_8060148:
    cmp     r0,1
    bne     @@_8060154
    ldr     r0,=Nightmare_15
    b       @@StoreOAM
    .pool
@@_8060154:
    cmp     r0,2
    bne     @@_8060160
    ldr     r0,=Nightmare_14
    b       @@StoreOAM
    .pool
@@_8060160:
    cmp     r0,3
    beq     @@_8060178
    mov     r0,r4
    add     r0,0x24
    mov     r1,0x1A
    strb    r1,[r0]		;pose 1Ah
    ldr     r0,=Nightmare_12
    str     r0,[r4,0x18]
    b       @@CheckSlowSamus
.pool
@@_8060178:
    ldr     r0,=Nightmare_13
@@StoreOAM:
    str     r0,[r4,0x18]
    ldr     r1,=CurrSpriteData
    b       @@_806028E
    .pool
@@_8060188:
    bl      MakeMissileFall
    bl      UpdateGeneratorPal
    ldr     r1,=CurrBossData
    ldr     r2,=CurrSpriteData
    ldrh    r0,[r2,0x14]
    mov     r3,0
    strh    r0,[r1,0xC]
    lsl     r0,r0,0x10
    lsr     r4,r0,0x10
    cmp     r4,0
    beq     @@_80601A4
    b       @@CheckSlowSamus
@@_80601A4:
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x1C
    strb    r0,[r1]
    mov     r0,r2
    add     r0,0x2E
    strb    r3,[r0]
    sub     r0,1
    strb    r3,[r0]
    ldr     r0,=Nightmare_13
    str     r0,[r2,0x18]
    strb    r3,[r2,0x1C]
    strh    r4,[r2,0x16]
   ; ldr     r2,=0x80A8CDC
    ;ldr     r0,=0x80A8D3C	;sound data entries?
    ;ldr     r1,=0x152C
    ;add     r0,r0,r1
    ;ldrh    r1,[r0]
    ;lsl     r0,r1,1
    ;add     r0,r0,r1
    ;lsl     r0,r0,2
    ;add     r0,r0,r2
    ;ldr     r0,[r0]
    ;mov     r1,0x78
    ;bl      0x80029A8		;looks like it fades out the whirring sound
    b       @@CheckSlowSamus
    .pool
@@_80601F4:
    bl      MakeMissileFall
    bl      GeneratorDyingUpdatePal
    ldr     r1,=CheckEndOfSpriteAnimation + 1
	bl		WrapperR1
    cmp     r0,0
    bne     @@_8060206
    b       @@CheckSlowSamus
@@_8060206:
    ldr     r1,=CurrSpriteData
    mov     r0,0
    strb    r0,[r1,0x1C]
    mov     r3,0
    strh    r0,[r1,0x16]
    mov     r2,r1
    add     r2,0x2D
    ldrb    r0,[r2]
    mov     r4,r1
    cmp     r0,0
    bne     @@_8060228
    ldr     r0,=Nightmare_14
    b       @@_806028A
    .pool
@@_8060228:
    cmp     r0,1
    bne     @@_8060234
    ldr     r0,=Nightmare_15
    b       @@_806028A
    .pool
@@_8060234:
    cmp     r0,2
    bne     @@_8060240
    ldr     r0,=Nightmare_16
    b       @@_806028A
    .pool
@@_8060240:
    cmp     r0,3
    beq     @@_8060288
    mov     r1,r4
    add     r1,0x24
    mov     r0,0x1E
    strb    r0,[r1]
    ldr     r0,=Nightmare_11
    str     r0,[r4,0x18]
    mov     r0,0x3C
    strb    r0,[r2]
    mov     r0,r4
    add     r0,0x25
    strb    r3,[r0]		;0 to Samus collision
	ldr		r1,=GravityActive
	strb	r3,[r1]
	ldr		r1,=SamusEquipment
	strb	r3,[r1,13h]
    ldr     r1,=SpriteData
    lsl     r0,r6,3
    sub     r0,r0,r6
    lsl     r0,r0,3
    add     r0,r0,r1
    add     r0,0x24
    mov     r1,0x17
    strb    r1,[r0]		;pose 17 to nightmare
    ldr     r0,=SamusEquipment
    strb    r3,[r0,13h]
	strb	r3,[r0,15h]
    ldr     r1,=CurrBossDirection
    mov     r0,0x64
    strb    r0,[r1]
    b       @@CheckSlowSamus
    .pool
@@_8060288:
    ldr     r0,=Nightmare_17
@@_806028A:
    str     r0,[r4,0x18]
    mov     r1,r4
@@_806028E:
    add     r1,0x2D
    ldrb    r0,[r1]
    add     r0,1
    strb    r0,[r1]
    b       @@CheckSlowSamus
    .pool
@@_806029C:
    bl      GeneratorDyingUpdatePal
    ldr     r0,=SpriteData
    lsl     r1,r6,3
    sub     r1,r1,r6
    lsl     r1,r1,3
    add     r1,r1,r0
    add     r1,0x24
    ldrb    r0,[r1]
    cmp     r0,0x19
    bne     @@CheckSlowSamus
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x20
    strb    r1,[r0]
    b       @@CheckSlowSamus
.pool
@@_80602C4:
    mov     r2,r4
    add     r2,0x2D
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]
    lsl     r0,r0,0x18
    lsr     r0,r0,0x18
    cmp     r0,0x1D
    bhi     @@_8060306
    ldrh    r0,[r4]
    mov     r1,4
    eor     r1,r0
    strh    r1,[r4]
    ldrb    r0,[r2]
    cmp     r0,0
    bne     @@CheckSlowSamus
    mov     r2,4h
    orr     r1,r2
    strh    r1,[r4]	;invisible flag
	mov     r1,r4
    add     r1,0x32
	mov		r0,0xBF
	ldrb	r2,[r0]
	and		r0,r2
	strb	r0,[r1]
    mov     r1,r4
    add     r1,0x24
    mov     r0,4
    strb    r0,[r1]
    ldrh    r0,[r4,2]
    add     r0,0x40
    ldrh    r1,[r4,4]
    add     r1,0x50
    mov     r2,0x21
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    b       @@CheckSlowSamus
@@_8060306:
    cmp     r0,0x1E
    bne     @@_806032A
    ldrh    r0,[r4,2]
    add     r0,0x40
    ldrh    r1,[r4,4]
    add     r1,0x40
    mov     r2,0x21
    ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
    mov     r1,r4
    add     r1,0x20
    mov     r0,0
    strb    r0,[r1]
 ;   mov     r0,0xAA
 ;   lsl     r0,r0,2
 ;   bl      PlaySound5
    b       @@CheckSlowSamus
@@_806032A:
    bl      GeneratorDyingUpdatePal
    b       @@CheckSlowSamus
@@CheckKill:
    bl		CheckNightmareDead
    cmp     r0,0
    beq     @@Return
	ldr		r0,=CurrSpriteData
	mov		r1,r0
	add		r1,0x24
	mov		r2,0x64
	strb	r2,[r1]
    ldrh    r1,[r0,2h]		;sprite Y position 
	ldrh    r2,[r0,4h]		;sprite X position  
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
	b 		@@Return
@@CheckSlowSamus:
    ldr     r0,=GravityActive
    ldrb    r0,[r0]
    cmp     r0,01
    bne     @@Return
    bl      NightmareSlowSamus
@@Return:
	add		sp,4
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmarePartMain:
.notice "NightmarePart AI"
.notice tohex(.)
    push    r14
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0
    bne     @@GetJump
    bl      NightmarePartInit
    b       @@Return
    .pool
@@GetJump:
    ldrb    r0,[r1,0x1E]
    cmp     r0,0xD
    bhi     @@Return
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@ChinSludge,@@EyeSludge,@@NightmareEye,@@NightmareMouth
    .dw @@TopArmAI,@@RightTurret1,@@RightTurret2,@@RightTurret3
    .dw @@LowerArmAI,@@Generator,@@Return,@@LeftTurret1
    .dw @@LeftTurret2,@@LeftTurret3
@@Generator:
    bl      NightmareGeneratorAI
    bl      UpdateSecondarySpritePos   ;updates positions of secondaries based on Nightmare's animation and secondary number
    b       @@Return
@@EyeSludge:
    bl      NightmareEyeSludgeAI
    bl      UpdateSecondarySpritePos
    b       @@Return
@@ChinSludge:
    bl      NightmareChinSludge
    bl      UpdateSecondarySpritePos
    b       @@Return
@@NightmareEye:
    bl      NightmareEyeAI
    bl      UpdateSecondarySpritePos
    b       @@Return
@@NightmareMouth:
    bl      NightmareMouthAI
    bl      UpdateSecondarySpritePos
    b       @@Return
@@RightTurret1:
    bl      NightmareRightTurret1
    bl      UpdateSecondarySpritePos
    b       @@Return
@@RightTurret2:
    bl      NightmareRightTurret2
    bl      UpdateSecondarySpritePos
    b       @@Return
@@RightTurret3:
    bl      NightmareRightTurret3
    bl      UpdateSecondarySpritePos
    b       @@Return
@@LeftTurret1:
    bl      NightmareLeftTurret1
    bl      UpdateSecondarySpritePos
    b       @@Return
@@LeftTurret2:
    bl      NightmareLeftTurret2
    bl      UpdateSecondarySpritePos
    b       @@Return
@@LeftTurret3:
    bl      NightmareLeftTurret3
    bl      UpdateSecondarySpritePos
    b       @@Return
@@TopArmAI:
    bl      NightmareRightArmTopAI
    bl      NightmareUpdateOAM
    b       @@Return
@@LowerArmAI:
    bl      NightmareRightArmLowAI
    bl      NightmareUpdateOAM
@@Return:
    pop     r0
    bx      r0