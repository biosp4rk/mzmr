;2Eh = timer, Y deceleration value
;2Fh = X deceleration value
;30h = X acceleration vlaue, changed to 2C
;31h = Y acceleration value, changed to 2D

CheckNightmareRoom:    ;checks if nightmare is in room with effect A or B
	push	r4,r14
	ldr		r4,=0x3000080
	ldrb	r1,[r4,7h]
	mov		r0,80h
	neg		r0,r0
	and		r0,r1
	mov		r1,1h
	strb	r1,[r4,7h]
	ldr		r0,=CurrentRoomEntries 
	ldrb	r0,[r0,12h]
	cmp		r0,0
	bne		@@Normal
	ldr		r3,=0x300572C
	ldr		r0,=DistortBG + 1
	str		r0,[r3]
	mov		r0,1
	ldr		r3,=0x4000014
	b 		@@Return
@@Normal:
	ldr		r2,=0x300006B
	mov		r0,0
	strb	r0,[r2]
@@Return:
	mov		r2,r4
	pop		r4
	pop		r1
	bx		r1
	

DistortBG:
    push    r4-r7,r14
    mov     r5,0
    ldr     r1,=0x300571C ;300571C might be ZM equal
    ldrh    r0,[r1,8]
    add     r2,r0,1
    strh    r2,[r1,8]
    ldr     r0,=GravityActive ;just a flag for if wavy effect is on
    ldrb    r0,[r0]
    mov     r3,r1
    cmp     r0,1
    bne     @@_806F980
    lsl     r0,r2,0x10
    asr     r0,r0,0x10
    cmp     r0,0xF
    ble     @@_806F994
    strh    r5,[r3,8]
    ldrb    r0,[r3,0xB]
    cmp     r0,3
    bhi     @@_806F994
    add     r0,1
    b       @@_806F992
    .pool
@@_806F980:
    lsl     r0,r2,0x10
    asr     r0,r0,0x10
    cmp     r0,0xF
    ble     @@_806F994
    strh    r5,[r3,8]
    ldrb    r0,[r3,0xB]
    cmp     r0,0
    beq     @@_806F994
    sub     r0,1
@@_806F992:
    strb    r0,[r3,0xB]
@@_806F994:
    mov     r2,r3
    ldrb    r0,[r2,0xB]
    lsl     r0,r0,5
    ldr     r1,=WaveTable  ;834607C
    add     r4,r0,r1
    mov     r0,0x1F
    mov     r12,r0
    mov     r1,0
    strb    r1,[r2,3]
    ldrh    r0,[r2]
    add     r0,1
    strh    r0,[r2]
    lsl     r0,r0,0x10
    asr     r0,r0,0x10
    cmp     r0,7
    ble     @@_806F9BA
    mov     r0,1
    strb    r0,[r2,3]
    strh    r1,[r2]
@@_806F9BA:
    ldr     r0,=0x3005728
    ldrb    r1,[r0]
    ldrb    r2,[r3,3]
    sub     r1,r1,r2
    strb    r1,[r0]
    ldr     r2,=0x2026D00		;2026D00 might be zm equal
    mov     r5,0
    mov     r6,r0
    ldr     r3,=BGPositions
@@_806F9CC:
    ldrh    r0,[r3,6]
    add     r0,r0,r5
    ldrb    r7,[r6]
    add     r1,r0,r7
    mov     r0,r12
    and     r1,r0
    add     r0,r4,r1
    ldrb    r0,[r0]
    lsl     r0,r0,0x18
    asr     r0,r0,0x18
    ldrh    r7,[r3,4]
    add     r1,r0,r7
    strh    r1,[r2]
    add     r2,2
    ldrh    r0,[r3,6]
    strh    r0,[r2]
    add     r2,2
    strh    r1,[r2]
    add     r2,2
    ldrh    r0,[r3,0xA]
    strh    r0,[r2]
    add     r2,2
    ldrh    r0,[r3,0xE]
    add     r0,r0,r5
    ldrb    r7,[r6]
    add     r1,r0,r7
    mov     r0,r12
    and     r1,r0
    add     r0,r4,r1
    ldrb    r0,[r0]
    lsl     r0,r0,0x18
    asr     r0,r0,0x18
    ldrh    r1,[r3,0xC]
    add     r0,r0,r1
    strh    r0,[r2]
    add     r2,2
    ldrh    r0,[r3,0xE]
    strh    r0,[r2]
    add     r2,2
    add     r5,1
    cmp     r5,0x9F
    ble     @@_806F9CC
    pop     r4-r7
    pop     r0
    bx      r0
.pool
	
	;834808A
	
WaveTable:
.byte 00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
.byte 00,00,00,01,01,01,01,01,01,01,01,01,01,01,00,00,00,00,00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF 
.byte 0xFF,0xFF,0xFF,00,00,00,00,01,01,01,02,02,02,02,02,02,02,01,01,01,00,00,00,0xFF,0xFF,0xFF,0xFE,0xFE
.byte 0xFE,0xFE,0xFE,0xFE,0xFE,0xFF,0xFF,0xFF,00,00,01,01,02,02,02,03,03,03,03,03,02,02,02,01,01,00,0xFF
.byte 0xFF,0xFE,0xFE,0xFE,0xFD,0xFD,0xFD,0xFD,0xFD,0xFE,0xFE,0xFE,0xFF,0xFF,00,01,02,02,03,03,04,04,04,04
.byte 04,03,03,02,02,01,00,0xFF,0xFE,0xFE,0xFD,0xFD,0xFC,0xFC,0xFC,0xFC,0xFC,0xFD,0xFD,0xFE,0xFE,0xFF,00
.byte 02,03,04,04,05,05,05,05,05,04,04,03,02,01,00,0xFF,0xFE,0xFD,0xFC,0xFC,0xFB,0xFB,0xFB,0xFB,0xFB,0xFC
.byte 0xFC,0xFD,0xFE,0xFF,00,01,02,03,04,05,06,06,06,06,06,05,04,03,02,01,00,0xFF,0xFE,0xFD,0xFC,0xFB,0xFA 
.byte 0xFA,0xFA,0xFA,0xFA,0xFB,0xFC,0xFD,0xFE,0xFF,00,01,03,04,05,06,06,07,07,07,06,06,05,04,03,01,00,0xFF 
.byte 0xFD,0xFC,0xFB,0xFA,0xFA,0xF9,0xF9,0xF9,0xFA,0xFA,0xFB,0xFC,0xFD,0xFF,00,02,03,04,06,07,07,08,08,08
.byte 07,07,06,04,03,02,00,0xFE,0xFD,0xFC,0xFA,0xF9,0xF9,0xF8,0xF8,0xF8,0xF9,0xF9,0xFA,0xFC,0xFD,0xFE,00



NightmareMovementAI: 				;r0 = Y target r1 = X target r2 = ? r3 = max X accel val, sp = max Y accel
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    add     sp,-4
    ldr     r4,[sp,0x24]
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    mov     r10,r0
    lsl     r1,r1,0x10
    lsr     r5,r1,0x10
    mov     r7,r5
    lsl     r2,r2,0x18
    lsr     r2,r2,0x18
    str     r2,[sp]
    lsl     r3,r3,0x18
    lsr     r6,r3,0x18
    mov     r8,r6
    lsl     r4,r4,0x18
    lsr     r4,r4,0x18
    mov     r0,0
    mov     r9,r0
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    lsl     r0,r0,0x10
    lsr     r3,r0,0x10
    cmp     r3,0				;checks for 200h flag, moving rightward
    beq     @@MovingLeft
    mov     r1,0x2F
    add     r1,r1,r2
    mov     r12,r1
    ldrb    r0,[r1]
    cmp     r0,0				;if not 0 decelerate
    bne     @@CheckMoveRight
    ldr     r3,=CurrBossData
    ldrh    r1,[r3,0xA]
    add     r0,r5,4
    cmp     r1,r0				;checking if X pos is withen Boundary set by the r1 parameter
    ble     @@CheckAcceleration
    mov     r0,r2
    add     r0,0x2C
    ldrb    r0,[r0]
    mov     r2,r12
    strb    r0,[r2]
    b       @@CheckSwitchXDirection
    .pool
@@CheckAcceleration:
    mov     r1,r2
    add     r1,0x2C
    ldrb    r0,[r1]
    cmp     r0,r6
    bcs     @@MoveLeft
    add     r0,1
    strb    r0,[r1]				;add 1 to 30h, used for X movement acceleration
@@MoveLeft:
    ldrb    r0,[r1]
    asr     r0,r4
    ldrh    r5,[r3,0xA]
    add     r0,r0,r5
    strh    r0,[r3,0xA]		 	;moves left based pn accel or decel value
    b       @@CheckSwitchXDirection
@@CheckMoveRight:
    sub     r0,1
    mov     r6,r12
    strb    r0,[r6]
    lsl     r0,r0,0x18
    cmp     r0,0h			;if X acceleration is 0, switch direction
    beq     @@SwitchXDirection
    ldr     r1,=CurrBossData
    ldrb    r0,[r6]
    asr     r0,r4
    ldrh    r2,[r1,0xA]
    add     r0,r0,r2
    strh    r0,[r1,0xA]
    b       @@CheckSwitchXDirection
    .pool
@@MovingLeft:
    mov     r5,0x2F
    add     r5,r5,r2
    mov     r12,r5
    ldrb    r0,[r5]
    mov     r5,r0
    cmp     r5,0				;checks if deceleration should start
    bne     @@DecelerateX
    ldr     r3,=CurrBossData
    ldrh    r1,[r3,0xA]
    sub     r0,r7,4
    cmp     r1,r0				;checking if X pos is withen Boundary set by the r1 parameter
    bge     @@CheckAcceleration2
    mov     r0,r2
    add     r0,0x2C
    ldrb    r0,[r0]
    mov     r6,r12
    strb    r0,[r6]
    b       @@CheckSwitchXDirection
    .pool
@@CheckAcceleration2:
    mov     r1,r2
    add     r1,0x2C
    ldrb    r0,[r1]
    cmp     r0,r8
    bcs     @@UpdateXPos
    add     r0,1
    strb    r0,[r1]
@@UpdateXPos:
    ldrb    r0,[r1]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldrh    r0,[r3,0xA]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0			;not sure what this check is for...if true it switches direction
    beq     @@StoreXPos
    mov     r0,1
    mov     r9,r0			;used as flag to switch movement direction
    mov     r1,r12
    strb    r5,[r1]
    b       @@CheckSwitchXDirection
@@StoreXPos:
    strh    r1,[r3,0xA]
    b       @@CheckSwitchXDirection
@@DecelerateX:
    sub     r0,1
    mov     r2,r12
    strb    r0,[r2]			;decelerating X movement
    lsl     r0,r0,0x18
    cmp     r0,0			;if decel value is 0, switch direction
    beq     @@SetSwitchDirectionFlag
    ldrb    r0,[r2]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldr     r2,=CurrBossData
    ldrh    r0,[r2,0xA]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0
    beq     @@StoreXPos2
    mov     r5,1
    mov     r9,r5 			;used as flag to switch movement direction
    mov     r6,r12
    strb    r3,[r6]
    b       @@CheckSwitchXDirection
    .pool
@@StoreXPos2:
    strh    r1,[r2,0xA]
    b       @@CheckSwitchXDirection
@@SetSwitchDirectionFlag:
    mov     r0,1
    mov     r9,r0    ;used as flag to switch movement direction
@@CheckSwitchXDirection:
    mov     r1,r9
    cmp     r1,0
    beq     @@CheckYDirection
@@SwitchXDirection:
    ldr     r2,=CurrSpriteData
    ldrh    r0,[r2]
    mov     r3,0x80
    lsl     r3,r3,2
    mov     r1,r3
    eor     r0,r1
    strh    r0,[r2]			;toggles 200h flag
    add     r2,0x2C
    mov     r0,1
    strb    r0,[r2]			;1 to X accel
    ldr     r0,=0x170		;whirring when turning around?
    ldr     r1,=PlaySound3 + 1
	bl		WrapperR1
@@CheckYDirection:
    mov     r5,0
    mov     r9,r5
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,3
    and     r0,r1
    lsl     r0,r0,0x10
    lsr     r6,r0,0x10
    cmp     r6,0			;checking 400h flag, moving down?
    beq     @@MovingUp
    mov     r6,0x2E
    add     r6,r6,r2
    mov     r12,r6
    ldrb    r0,[r6]
    cmp     r0,0
    bne     @@DecelDownward
    ldr     r3,=CurrBossData
    ldrh    r1,[r3,8]
    mov     r0,r10
    sub     r0,4
    cmp     r1,r0		;check if within 4 units of Y boundary
    ble     @@CheckYAcceleration
    mov     r0,r2
    add     r0,0x2D
    ldrb    r0,[r0]
    strb    r0,[r6]
    b       @@CheckSwitchYDirection
    .pool
@@CheckYAcceleration:
    mov     r1,r2
    add     r1,0x2D
    ldrb    r0,[r1]
    ldr     r5,[sp]
    cmp     r0,r5		;checking if Y acceleration is at max value
    bcs     @@MoveDown
    add     r0,1
    strb    r0,[r1]
@@MoveDown:
    ldrb    r0,[r1]
    asr     r0,r4
    ldrh    r6,[r3,8]
    add     r0,r0,r6
    strh    r0,[r3,8]
    b       @@CheckSwitchYDirection
@@DecelDownward:
    sub     r0,1
    mov     r1,r12
    strb    r0,[r1]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@SwitchYDirection
    ldr     r1,=CurrBossData
    mov     r3,r12
    ldrb    r0,[r3]
    asr     r0,r4
    ldrh    r5,[r1,8]
    add     r0,r0,r5
    strh    r0,[r1,8]		;move down based on deceleration val
    b       @@CheckSwitchYDirection
    .pool
@@MovingUp:
    mov     r0,0x2E
    add     r0,r0,r2
    mov     r12,r0
    ldrb    r0,[r0]
    mov     r5,r0
    cmp     r5,0
    bne     @@DecelUpward
    ldr     r3,=CurrBossData
    ldrh    r1,[r3,8]
    mov     r0,r10
    add     r0,4
    cmp     r1,r0		
    bge     @@CheckYAcceleration2
    mov     r0,r2
    add     r0,0x2D
    ldrb    r0,[r0]
    mov     r1,r12
    strb    r0,[r1]
    b       @@CheckSwitchYDirection
    .pool
@@CheckYAcceleration2:
    mov     r1,r2
    add     r1,0x2D
    ldrb    r0,[r1]
    ldr     r6,[sp]
    cmp     r0,r6
    bcs     @@CheckMoveUp
    add     r0,1
    strb    r0,[r1]
@@CheckMoveUp:
    ldrb    r0,[r1]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldrh    r0,[r3,8]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0h			;unsure what it is shecking for
    beq     @@StoreYPos
    mov     r0,1
    mov     r9,r0
    mov     r1,r12
    strb    r5,[r1]
    b       @@CheckSwitchYDirection
@@DecelUpward:
    sub     r0,1
    mov     r3,r12
    strb    r0,[r3]
    lsl     r0,r0,0x18
    cmp     r0,0
    beq     @@SetSwitchYDirection
    ldrb    r0,[r3]
    asr     r0,r4
    lsl     r0,r0,0x10
    lsr     r1,r0,0x10
    ldr     r3,=CurrBossData
    ldrh    r0,[r3,8]
    sub     r1,r0,r1
    mov     r0,0x80
    lsl     r0,r0,8
    and     r0,r1
    cmp     r0,0				;unsure what it is shecking for
    beq     @@StoreYPos
    mov     r5,1
    mov     r9,r5
    mov     r0,r12
    strb    r6,[r0]
    b       @@CheckSwitchYDirection
    .pool
@@StoreYPos:
    strh    r1,[r3,8]
    b       @@CheckSwitchYDirection
@@SetSwitchYDirection:
    mov     r1,1
    mov     r9,r1			;flag determines if Y direction should be flipped
@@CheckSwitchYDirection:
    mov     r3,r9
    cmp     r3,0			;checking if Y direction should be flipped
    beq     @@Return
@@SwitchYDirection:
    ldrh    r0,[r2]
    mov     r5,0x80
    lsl     r5,r5,3
    mov     r1,r5
    eor     r0,r1
    strh    r0,[r2]			;toggles 400h, Y direction
    mov     r1,r2
    add     r1,0x2D
    mov     r0,1
    strb    r0,[r1]			;sets Y accel to 1
    ldr     r0,=0x170
    ldr     r1,=PlaySound3 + 1
	bl		WrapperR1
@@Return:
    add     sp,4
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareUpdateOAM:				
    push    r4,r14
    ldr     r4,=CurrBossData
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
    ldrh    r0,[r0,2]
    ldrh    r1,[r4,8]
    add     r0,r0,r1
    strh    r0,[r2,2]
    ldrb    r1,[r2,0x1E]
    lsl     r0,r1,1
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r3
    ldrh    r0,[r0,4]
    ldrh    r4,[r4,0xA]
    add     r0,r0,r4
    strh    r0,[r2,4]
    pop     r4
    pop     r0
    bx      r0
.pool

NightmareRepeatSound:			
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x25
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@Return
    ldr     r0,=CurrBossData
    ldr     r0,[r0,4]
    ldr     r1,=0xFFFFFF
    and     r0,r1
    mov     r1,0xC0
    lsl     r1,r1,0xC
    cmp     r0,r1
    bne     @@Return
;    ldr     r0,=0x2B9
;    bl      PlaySound1
@@Return:
    pop     r0
    bx      r0
.pool

MakeMissileFall:			
    push    r4-r5,r14
    mov     r3,0
    ldr     r4,=ProjectileData
	ldr		r5,=ProjectileAccel
@@Loop:
	mov		r0,0x1C
    mul     r0,r3
    add     r1,r0,r4
    ldrb    r2,[r1]
    mov     r0,1
    and     r0,r2
    cmp     r0,0		;checks if projectile exists
    beq     @@Set0
    mov     r0,0x10
    and     r0,r2
    cmp     r0,0		;checks if can effect environment
    beq     @@Set0
    ldrb    r0,[r1,0xF]
    cmp     r0,0xC		;checks if projectile is missile
    beq     @@MakeFall
	cmp		r0,0Dh		;checks if super missile
	bne		@@Set0
@@MakeFall:
    ldrb    r2,[r5]
    mov     r0,3
    and     r0,r2
    cmp     r0,0
    bne     @@_805DD72
    add     r0,r2,1
    strb    r0,[r5]
@@_805DD72:
    ldrb    r0,[r5]
    mov     r2,0x2A
    cmp     r0,0x29
    bhi     @@MoveDown
    mov     r2,r0
@@MoveDown:
	ldrb	r0,[r5]
	add		r0,1
	strb	r0,[r5]
    ldrh    r0,[r1,8]
    add     r0,r2,r0
    strh    r0,[r1,8]
	b 		@@Increment
@@Set0:
	mov		r0,0
	strb	r0,[r5]
@@Increment:
    add     r0,r3,1
	add		r5,1h
    lsl     r0,r0,0x18
    lsr     r3,r0,0x18
    cmp     r3,0xF
    bls     @@Loop
    pop     r4,r5
    pop     r0
    bx      r0
.pool

NightmareSlowSamus:	
    push    r14
    ldr     r1,=SamusEquipment
    ldrb    r0,[r1,0Fh]
    mov		r2,20h
	and		r0,r2
	cmp		r0,20h
    beq     @@ResetPhis
	mov		r0,1
	strb	r0,[r1,13h]		;slows samus physics if gravity not equipped
    ldr     r2,=SamusData
    ldrh    r3,[r2,0x16]
    mov     r0,0x16
    ldsh    r1,[r2,r0]
    cmp     r1,4
    ble     @@_805DDBC
    sub     r0,r3,2
    b       @@_805DDC6
.pool
@@_805DDBC:
    mov     r0,4
    neg     r0,r0
    cmp     r1,r0
    bge     @@Return
    add     r0,r3,2
@@_805DDC6:
    strh    r0,[r2,0x16]
	b		@@Return
@@ResetPhis:
	mov		r0,0
	strb	r0,[r1,13h]		;slows samus physics
@@Return:
    pop     r0
    bx      r0
	


NightmareInitialize:
    push    r4-r7,r14
    mov     r7,r8
    push    r7
    add     sp,-0xC
    mov		r7,0
	mov		r0,3
	bl		SetnCheckEvent
	cmp		r0,0h
    beq     @@Spawn
    ldr     r1,=CurrSpriteData
    mov     r0,0				;kills sprite
    strh    r0,[r1]
    b       @Return1
    .pool
@@Spawn:
	ldr		r0,=CurrBossDirection
	mov		r1,0
	str		r1,[r0]		;reset boss ram
	ldr		r0,=DoorUnlockTimer
	mov		r1,1
	strb	r1,[r0]			;locks doors
    ldr     r0,=CurrSpriteData
    mov     r8,r0
    mov     r2,0xB0
    lsl     r2,r2,2
    mov     r1,r2
    ldrh    r5,[r0,2]
    add     r1,r1,r5
    mov     r4,0
    strh    r1,[r0,2]
    ldrh    r0,[r0,4]
    add     r0,0x40
    mov     r2,r8
    strh    r0,[r2,4]
    ldr     r3,=CurrBossData
    strh    r1,[r3,8]		;CurrBossData + 8h is Y pos
    strh    r0,[r3,0xA]  	;CurrBossData + Ah is X pos
    mov     r0,0xA
    strb    r0,[r2,0x1E]
    mov     r1,r8
    add     r1,0x22
    mov     r0,0xC
    strb    r0,[r1]   ;draw order
    add     r1,5
    mov     r0,0x50
    strb    r0,[r1]
    add     r1,1
    mov     r0,8
    strb    r0,[r1]
    add     r1,1
    mov     r2,0x40
    mov     r0,0x40
    strb    r0,[r1]   ;drawing boxes
    mov     r0,0xFF
    lsl     r0,r0,8
    mov     r5,r8
    strh    r0,[r5,0xA]
    add     r0,0xE0
    strh    r0,[r5,0xC]
    sub     r0,0x80
    strh    r0,[r5,0xE]
    mov     r0,0xC0
    strh    r0,[r5,0x10]		;hitboxes
    ldrh    r0,[r5]
    mov     r5,0x80
    lsl     r5,r5,8
    mov     r1,r5
    orr     r0,r1
    mov     r1,r8
    strh    r0,[r1]				;8000h to Status
    add     r1,0x32
    ldrb    r0,[r1]
    orr     r2,r0
    strb    r2,[r1]				;40h to properties (Immune to weapons)
    ldr     r2,=PrimarySpriteStats
    mov     r5,r8
    ldrb    r1,[r5,0x1D]
    lsl     r0,r1,3
    add     r0,r0,r1
    lsl     r0,r0,1
    add     r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r5,0x14]		;store health
    ldr     r0,=NightmareSecondaryPosTable 
    str     r0,[r3]
    strb    r4,[r3,6]
    strh    r7,[r3,4]
	ldr		r0,=Nightmare_43
	str		r0,[r5,18h]
	mov     r0,0
    strb    r0,[r5,0x1C]
    strh    r0,[r5,0x16]
    mov     r0,r8
    add     r0,0x25
    strb    r4,[r0]				;0 to Samus collision
    add     r0,8
    strb    r4,[r0]				;0 to 2Dh
    mov     r1,r8
    add     r1,0x24
    mov     r0,0x37
    strb    r0,[r1]			;set pose 37
    mov     r0,r8
    add     r0,0x2E
    mov     r1,0xB4
    strb    r1,[r0]			;B4 to 2Eh, used as a timer
    ldr     r0,=CurrBossDirection
    strb    r1,[r0]
    ldrh    r5,[r3,8]
    ldrh    r6,[r3,0xA]
    mov     r0,r8
    add     r0,0x23
    ldrb    r0,[r0]
    mov     r8,r0
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart1:
    mov     r0,NightmareBodyID			;face
    mov     r1,0
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart2:
    mov     r0,NightmareBodyID			;eye sludge
    mov     r1,1
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart3:
    mov     r0,NightmareBodyID			;eyes
    mov     r1,2
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    mov     r4,r0
    lsl     r4,r4,0x18
    lsr     r4,r4,0x18
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart4:
    mov     r0,NightmareBodyID			;mouth
    mov     r1,3
    mov     r2,0
    mov     r3,r8
    ldr     r7,=SpawnSecondarySprite + 1
	bl		WrapperR7
	mov		r7,0
    ldr     r2,=SpriteData
    lsl     r1,r4,3
    sub     r1,r1,r4
    lsl     r1,r1,3
    add     r1,r1,r2
    add     r1,0x36
    strb    r0,[r1]
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart5:
    mov     r0,NightmareBodyID		;right arm top
    mov     r1,4
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart6:
    mov     r0,NightmareBodyID		;top right turret
    mov     r1,5
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart7:
    mov     r0,NightmareBodyID		;mid right turret
    mov     r1,6
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4	
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart8:
    mov     r0,NightmareBodyID		;bottom right turret
    mov     r1,7
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart9:
    mov     r0,NightmareBodyID		;right hand
    mov     r1,8
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart10:
    mov     r0,NightmareBodyID		;generator
    mov     r1,9
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart11:
    mov     r0,NightmareBodyID		;top left turret
    mov     r1,0xB
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart12:
    mov     r0,NightmareBodyID		;mid left turret
    mov     r1,0xC
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
    str     r5,[sp]
    str     r6,[sp,4]
    str     r7,[sp,8]
NightmarePart13:
    mov     r0,NightmareBodyID		;bottom low turret
    mov     r1,0xD
    mov     r2,0
    mov     r3,r8
    ldr     r4,=SpawnSecondarySprite + 1
	bl		WrapperR4
@Return1:
    add     sp,0xC
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmareStartDelay:      ;pose 37, delay before boss rises from ground
    push    r4,r14
    ldr     r1,=CurrSpriteData
    mov     r4,r1
    add     r4,0x2E
    ldrb    r0,[r4]
    sub     r0,1h
    strb    r0,[r4]
    lsl     r0,r0,0x18
    cmp     r0,0				;timer
    bne     @@Return
    add     r1,0x24
    mov     r0,0x38
    strb    r0,[r1]				;set pose 38
    mov     r0,0x3C
    mov     r1,0x81
    ldr     r2,=HoriScreenShake + 1
	bl		WrapperR2
    mov     r0,0x3C
    mov     r1,0x81
    ldr     r2,=VertScreenShake + 1
	bl		WrapperR2
    mov     r0,0x3C
    strb    r0,[r4]				;3C to 2Eh, timer
  ;  mov     r0,0xA8
 ;   lsl     r0,r0,2
 ;   bl      PlaySound5
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool

NightmareRising:					;pose 38, rising up to start fight
    push    r4,r5,r14
    ldr     r5,=CurrSpriteData
    ldrh    r0,[r5]
    mov     r1,4					;invisible flag
    eor     r0,r1
    strh    r0,[r5]					;makes boss flicker while rising
    mov     r4,r5
    add     r4,0x2E
    ldrb    r0,[r4]
    sub     r0,1
    strb    r0,[r4]
    lsl     r0,r0,0x18
    cmp     r0,0			;timer used to play sound in set intervals
    bne     @@CheckIfRise
    mov     r0,0x3C
    mov     r1,0x81
    ldr     r2,=HoriScreenShake + 1
	bl		WrapperR2
    mov     r0,0x3C
    mov     r1,0x81
    ldr     r2,=VertScreenShake + 1
	bl		WrapperR2
    mov     r0,0x3C
    strb    r0,[r4]
    mov     r0,0x90			;whirring sound when rising
	lsl		r0,r0,2
    ldr     r1,=PlaySound5 + 1
	bl		WrapperR1
@@CheckIfRise:
    ldr     r2,=CurrBossData
    ldrh    r1,[r2,8]
    mov     r0,0x80
    lsl     r0,r0,3
    cmp     r1,r0			;checks if Y pos is at or over 400h
    bls     @@SetPose
    sub     r0,r1,1
    strh    r0,[r2,8]		;increases Y pos
    b       @@Return
    .pool
@@SetPose:
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x39
    strb    r0,[r1]			;sets pose 39
@@Return:
    pop     r4,r5
    pop     r0
    bx      r0
	
NightmareStartSong:		;pose 39
    push    r14
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,0x2F
    mov     r2,0
    strb    r2,[r0]		 ;0 to 2F
    sub     r0,3
    mov     r1,1
    strb    r1,[r0]  	;1 to 2Ch
    add     r0,2
    strb    r2,[r0]		;0 to 2Eh
    sub     r0,1
    strb    r1,[r0]		;1 to 2Dh
    ldrh    r1,[r3]
    ldr     r0,=0x7FFB
    and     r0,r1
    strh    r0,[r3]		;removes invisible flag from status
    mov     r1,r3
    add     r1,0x25
    mov     r0,4
    strb    r0,[r1]		;4h samus collision 
    sub     r1,1
    mov     r0,0x3A
    strb    r0,[r1]		;sets pose 3A
.notice "Nightmare Song---------"
.notice tohex(.)
    mov     r0,0x3E		;song ID
    mov     r1,0
    ldr     r2,=PlaySong + 1
	bl		WrapperR2
    pop     r0
    bx      r0
    .pool

NightmarePhase1:				;pose 3A
    push    r14
    add     sp,-4
    ldr     r1,=SamusData
    ldr     r2,=0xFFFFFF00
    mov     r0,r2
    ldrh    r1,[r1,0x14]       ;Samus Y position 
    add     r0,r0,r1
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    mov		r1,0xD8
	lsl		r1,r1,2		;360h
    mov     r2,2
    str     r2,[sp]
    mov     r2,0x28
    mov     r3,8
    bl      NightmareMovementAI
    add     sp,4
    pop     r0
    bx      r0
.pool

NightmarePrePhase2:			;pose 3Bh, resetting position to start second phase
    push    r4-r7,r14
    mov     r6,0
    mov		r4,0xE0
	lsl		r4,r4,2		;380h, target Y
    mov		r5,0xE8
	lsl		r5,r5,2		;3A0h, target X
    ldr     r0,=CurrBossData
    ldrh    r1,[r0,0xA]
    mov     r3,r0
    cmp     r1,r5			;checking position relative to target X
    bcs     @@MovingLeft
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    mov     r7,0x80
    lsl     r7,r7,2
    mov     r1,r7
    orr     r1,r2			;setting 200h flag, moving right
    b       @@CheckYPos
    .pool
@@MovingLeft:
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    ldr     r1,=0xFDFF
    and     r1,r2			;removing 200h flag, moving left
@@CheckYPos:
    strh    r1,[r0]
    mov     r2,r0
    ldrh    r0,[r3,8]
    cmp     r0,r4			;comparing Y pos relative to target y
    bcs     @@MovingUpward
    ldrh    r1,[r2]
    mov     r7,0x80
    lsl     r7,r7,3
    mov     r0,r7
    orr     r0,r1			;adding 400h flag, moving down
    b       @@CheckTargetY
    .pool
@@MovingUpward:
    ldrh    r1,[r2]
    ldr     r0,=0xFBFF		;removing 400h flag, moving up
    and     r0,r1
@@CheckTargetY:
    strh    r0,[r2]
    ldrh    r1,[r3,8]
    add     r0,r4,6
    cmp     r1,r0			;checking if close to Y target
    bge     @@CheckYStatus
    sub     r0,r4,6
    cmp     r1,r0
    ble     @@CheckYStatus
    add     r0,r6,1			;used to tell if both targets are reached
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckTargetX
    .pool
@@CheckYStatus:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,3
    and     r0,r1
    cmp     r0,0		;checks for Y direction based on 400h flag
    beq     @@MoveUp
    ldrh    r0,[r3,8]
    add     r0,1
    b       @@MoveDown
@@MoveUp:
    ldrh    r0,[r3,8]
    sub     r0,1
@@MoveDown:
    strh    r0,[r3,8]
@@CheckTargetX:
    ldrh    r1,[r3,0xA]
    add     r0,r5,6
    cmp     r1,r0		;check if near target X
    bge     @@CheckXStatus
    sub     r0,r5,6
    cmp     r1,r0
    ble     @@CheckXStatus
    add     r0,r6,1		;used to tell if both targets are reached
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckReachedTargets
@@CheckXStatus:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0			;checking direction based on 200h flag
    beq     @@MoveLeft
    ldrh    r0,[r3,0xA]
    add     r0,1
    b       @@MoveRight
@@MoveLeft:
    ldrh    r0,[r3,0xA]
    sub     r0,1
@@MoveRight:
    strh    r0,[r3,0xA]
@@CheckReachedTargets:
    cmp     r6,2		;true if both targets positions are met
    bne     @@Return
    mov     r1,r2
    add     r1,0x24
    mov     r0,1
    strb    r0,[r1]		;sets pose to 1
    ldrh    r1,[r2]
    ldr     r0,=0xFDFF
    and     r0,r1
    ldr     r1,=0xFBFF
    and     r0,r1
    strh    r0,[r2]		;removes both directional flags
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
.pool

NightmarePhase2Start:			;pose 1, start of phase 2 movement
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,0x24
    mov     r3,0
    mov     r0,2
    strb    r0,[r2]				;sets pose to 2
    mov     r0,0
    strh    r3,[r1,6]			;?
    add     r1,0x2D
    strb    r0,[r1]				;2Dh to 0
    bx      r14
.pool

NightmarePhase2:			;pose 2
    push    r4-r6,r14
    ldr     r2,=CurrSpriteData
    ldrh    r4,[r2,6]		;timer?
    lsl     r1,r4,0x10
	mov		r3,1
    mov     r0,0xCF
    lsl     r0,r0,0x11
    cmp     r1,r0
    bhi     @@SwitchXDirection
    add     r0,r4,1
    strh    r0,[r2,6]
    b       @@CheckXStatus
    .pool
@@SwitchXDirection:
    ldrh    r0,[r2]
    mov     r4,0x80
    lsl     r4,r4,2
    mov     r1,r4
    eor     r0,r1
    mov     r1,0
    strh    r0,[r2]			;toggles 200h flag, switches X direction
    strh    r1,[r2,6]
@@CheckXStatus:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0			;checks X direction to determine which way to move
    beq     @@MovingLeft
    ldr     r1,=CurrBossData
    ldrh    r0,[r1,0xA]
    add     r0,r3,r0
    b       @@MoveX
    .pool
@@MovingLeft:
    ldr     r1,=CurrBossData
    ldrh    r0,[r1,0xA]
    sub     r0,r0,r3
@@MoveX:
    strh    r0,[r1,0xA]
    mov     r6,r1
    ldr     r0,=NightmareYPosTable  		;looks like a table for changing Y pos
    mov     r4,r2
    add     r4,0x2D
    ldrb    r5,[r4]
    lsl     r1,r5,0x18
    lsr     r2,r1,0x18
    lsr     r1,r1,0x1B
    lsl     r1,r1,1
    add     r1,r1,r0
    ldrh    r3,[r1]
    cmp     r2,0xFE			
    bhi     @@ResetTimer
    add     r0,r5,1
    b       @@Return
    .pool
@@ResetTimer:
    mov     r0,0
@@Return:
    strb    r0,[r4]
    ldrh    r0,[r6,8]
    add     r0,r3,r0
    strh    r0,[r6,8]		;changes Y position
    pop     r4-r6
    pop     r0
    bx      r0
	
NightmareEndPhase2:	
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x18
    strb    r1,[r0]			;sets pose 18h
    bx      r14
.pool

NightmarePrePhase3:			;pose 18h
    push    r4-r7,r14
    mov     r6,0
    mov		r4,0x80
	lsl		r4,r4,3		;400h
    mov		r5,0x6C
	lsl		r5,r5,3		;360h
    ldr     r0,=CurrBossData
    ldrh    r1,[r0,0xA]
    mov     r3,r0
    cmp     r1,r5			;checks X position relative to target X
    bcs     @@MovingLeft
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    mov     r7,0x80
    lsl     r7,r7,2
    mov     r1,r7
    orr     r1,r2			;sets 200h flag, moving right
    b       @@CheckTargetY
.pool
@@MovingLeft:
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    ldr     r1,=0xFDFF		;removes 200h flag, moving left
    and     r1,r2
@@CheckTargetY:
    strh    r1,[r0]
    mov     r2,r0
    ldrh    r0,[r3,8]
    cmp     r0,r4			;checking position relative to target Y
    bcs     @@MovingUp
    ldrh    r1,[r2]
    mov     r7,0x80
    lsl     r7,r7,3
    mov     r0,r7
    orr     r0,r1			;sets 400h flag, moving down
    b       @@CheckTargetY2
    .pool
@@MovingUp:
    ldrh    r1,[r2]
    ldr     r0,=0xFBFF		;removes 400h flag, moving up
    and     r0,r1
@@CheckTargetY2:
    strh    r0,[r2]
    ldrh    r1,[r3,8]
    add     r0,r4,6
    cmp     r1,r0			;checks Y position relative to target Y
    bge     @@CheckYStatus
    sub     r0,r4,6
    cmp     r1,r0
    ble     @@CheckYStatus
    add     r0,r6,1			;used to check if target position are met
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckTargetX
    .pool
@@CheckYStatus:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,3
    and     r0,r1
    cmp     r0,0			;checks for 400h, Y direction
    beq     @@MoveUp
    ldrh    r0,[r3,8]
    add     r0,1
    b       @@StoreYPos
@@MoveUp:
    ldrh    r0,[r3,8]
    sub     r0,1
@@StoreYPos:
    strh    r0,[r3,8]
@@CheckTargetX:
    ldrh    r1,[r3,0xA]
    add     r0,r5,6
    cmp     r1,r0			;checks X position relative to target X
    bge     @@CheckXStatus
    sub     r0,r5,6
    cmp     r1,r0
    ble     @@CheckXStatus
    add     r0,r6,1			;used to determine if target positions are met
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckTargetsMet
@@CheckXStatus:
    ldrh    r1,[r2]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0			;checks which direction to move based on 200h flag
    beq     @@MoveLeft
    ldrh    r0,[r3,0xA]
    add     r0,1
    b       @@StoreXPos
@@MoveLeft:
    ldrh    r0,[r3,0xA]
    sub     r0,1
@@StoreXPos:
    strh    r0,[r3,0xA]
@@CheckTargetsMet:
    cmp     r6,2
    bne     @@Return
    mov     r1,r2
    add     r1,0x24
    mov     r0,0x19
    strb    r0,[r1]		;pose 19h
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
	
NightmarePhase3Start:
    bx      r14

NightmareStartSlowMovement:
    bx      r14
	
NightmareSlowMovement:
    push    r4,r5,r14
    mov     r5,0
    ldr     r1,=CurrBossData
    ldrh    r2,[r1,8]
    ldr     r0,=SamusData
    ldrh    r0,[r0,0x14]		;Samus Y pos
    sub     r0,0x80
    mov     r4,r1
    cmp     r2,r0				;checks if Nightmare is above Samus
    bge     @@NotAbove
    add     r0,r2,1
    strh    r0,[r4,8]			;moves downward if above Samus
    b       @@CheckCollision
.pool
@@NotAbove:
    mov     r5,1
@@CheckCollision:
    ldrh    r0,[r4,8]
    ldrh    r1,[r4,0xA]
    sub     r1,0xC0
    ldr     r2,=CheckCollisionXY + 1
	bl		WrapperR2
    ldr     r0,=PrevCollisionCheck
    ldrb    r0,[r0]
    cmp     r0,0
    beq     @@MoveLeft
    add     r0,r5,1
    lsl     r0,r0,0x18
    lsr     r5,r0,0x18
    b       @@CheckSlowPhaseDone
    .pool
@@MoveLeft:
    ldrh    r0,[r4,0xA]
    sub     r0,1
    strh    r0,[r4,0xA]			;moves left if not close to wall
@@CheckSlowPhaseDone:
    cmp     r5,2				;checks if at wall and if below Samus
    bne     @@Return
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    mov     r1,0x1B
    strb    r1,[r0]				;sets pose 1Bh
@@Return:
    pop     r4,r5
    pop     r0
    bx      r0
.pool

NightmarePreFastMove:			;pose 1B
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,0x2F
    mov     r2,0
    strb    r2,[r0]			;0 to 2fh
    sub     r0,3
    mov     r1,1
    strb    r1,[r0]			;1 to 2Ch
    add     r0,2
    strb    r2,[r0]			;0 to 2Eh
    sub     r0,1
    strb    r1,[r0]			;1 to 2Dh
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x1C
    strb    r0,[r1]			;pose 1Ch
    mov     r0,0x96
    lsl     r0,r0,1
    strh    r0,[r3,6]		;timer used for next pose
    bx      r14
.pool

NightmareFastMovement:			;pose 1Ch
    push    r14
    add     sp,-4
    ldr     r0,=CurrSpriteData
    ldrh    r0,[r0,6]
    cmp     r0,0xF0				;timer before actively targeting Samus
    bls     @@TargetSamus
    ldr     r0,=SamusData
    ldrh    r2,[r0,12h]	;Samus X for Y target
    mov		r1,0x6C		;360 for X target
	lsl		r1,r1,3h	;used as boundaies for the movement ai, before actively targeting samus
    b       @@Move
.pool
@@TargetSamus:
    ldr     r1,=SamusData
    ldrh    r0,[r1,0x14]
    sub     r0,0x80
    lsl     r0,r0,0x10
    lsr     r2,r0,0x10
    ldrh    r1,[r1,0x12]		;Samus position is now used as the target for nightmare's movement
@@Move:
    mov     r0,2
    str     r0,[sp]
    mov     r0,r2
    mov     r2,0x30
    mov     r3,0x30
    bl      NightmareMovementAI
    ldr     r3,=CurrSpriteData
    ldrh    r0,[r3,6]
    cmp     r0,0
    beq     @@CheckEndRound
    sub     r0,1h
    strh    r0,[r3,6]			;subtracts from timer
    b       @@Return
    .pool
@@CheckEndRound:
    ldr     r2,=CurrBossData
    ldrh    r0,[r2,0xA]
    lsr     r0,r0,2
    ldr     r1,=BG1XPos
    ldrh    r1,[r1]
    lsr     r1,r1,2
    sub     r0,r0,r1
    lsl     r0,r0,0x10
    ldr     r1,=0xFF730000
    add     r0,r0,r1
    lsr     r0,r0,0x10
    cmp     r0,0x4A
    bhi     @@Return
    ldrh    r0,[r2,8]
    lsr     r0,r0,2
    ldr     r1,=BG1YPos
    ldrh    r1,[r1]
    lsr     r1,r1,2
    sub     r0,r0,r1
    lsl     r0,r0,0x10
    ldr     r1,=0xFFEB0000
    add     r0,r0,r1
    lsr     r0,r0,0x10
    cmp     r0,0x4E
    bhi     @@Return
    ldr     r0,=SamusData
    ldrh    r1,[r0,0x12]
    ldrh    r0,[r2,0xA]
    sub     r0,0x40				;all used to check if the round of fast movement should end, based on the BG position
    cmp     r1,r0				;and positions of Samus and the boss
    bge     @@Return
    mov     r1,r3
    add     r1,0x24
    mov     r0,0x1E
    strb    r0,[r1]		;pose 1Eh
@@Return:
    add     sp,4
    pop     r0
    bx      r0
.pool

NightmareFlashing:			;flashes during death
    push    r14
    ldr     r2,=CurrSpriteData
    mov     r3,r2
    add     r3,0x2F
    ldrb    r0,[r3]
    add     r1,r0,1
    strb    r1,[r3]
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    mov     r0,3
    and     r0,r1
    cmp     r0,0
    bne     @@Return
    mov     r0,4
    and     r0,r1
    lsl     r0,r0,0x18
    lsr     r1,r0,0x18
    cmp     r1,0
    beq     @@_805E504
    mov     r1,0xE
@@_805E504:
    mov     r0,r2
    add     r0,0x20
    strb    r1,[r0]
@@Return:
    pop     r0
    bx      r0
.pool

NightmarePreDeath:			; moves nightmare to death position
    push    r4-r7,r14
    bl      NightmareFlashing
    mov     r6,0
    ldr     r3,=0x400			;400h
    ldr     r4,=0x360		;360h
    ldr     r0,=CurrBossData
    ldrh    r0,[r0,0xA]
    cmp     r0,r4			;checks what side of target X boss is on
    bcs     @@MovingLeft
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    mov     r5,0x80
    lsl     r5,r5,2
    mov     r1,r5
    orr     r1,r2			;sets 200h flag, moving right
    b       @@CheckTargetY
    .pool
@@MovingLeft:
    ldr     r0,=CurrSpriteData
    ldrh    r2,[r0]
    ldr     r1,=0xFDFF		;removes 200h flag, moving left
    and     r1,r2
@@CheckTargetY:
    strh    r1,[r0]
    mov     r5,r0
    ldr     r0,=CurrBossData
    ldrh    r1,[r0,8]
    mov     r2,r0
    cmp     r1,r3			;checks what side of target X boss is on
    bcs     @@MovingUp
    ldrh    r1,[r5]
    mov     r7,0x80
    lsl     r7,r7,3
    mov     r0,r7
    orr     r0,r1			;sets 400h flag, moving down
    b       @@CheckAtTargetY
    .pool
@@MovingUp:
    ldrh    r1,[r5]
    ldr     r0,=0xFBFF
    and     r0,r1			;removes 400h flag, moving up
@@CheckAtTargetY:
    strh    r0,[r5]
    ldrh    r1,[r2,8]
    add     r0,r3,6
    cmp     r1,r0
    bge     @@CheckYStatus
    sub     r0,r3,6
    cmp     r1,r0
    ble     @@CheckYStatus
    add     r0,r6,1			;used to tell if both targets are met
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckAtTargetX
    .pool
@@CheckYStatus:
    ldrh    r1,[r5]
    mov     r0,0x80
    lsl     r0,r0,3
    and     r0,r1
    cmp     r0,0			;moves sprite based on Y direction
    beq     @@MoveUp
    ldrh    r0,[r2,8]
    add     r0,1
    b       @@StoreY
@@MoveUp:
    ldrh    r0,[r2,8]
    sub     r0,1
@@StoreY:
    strh    r0,[r2,8]
@@CheckAtTargetX:
    ldrh    r1,[r2,0xA]
    add     r0,r4,6
    cmp     r1,r0
    bge     @@CheckXStatus
    sub     r0,r4,6
    cmp     r1,r0
    ble     @@CheckXStatus
    add     r0,r6,1			;used to tell if both targets are met
    lsl     r0,r0,0x18
    lsr     r6,r0,0x18
    b       @@CheckMetTargets
@@CheckXStatus:
    ldrh    r1,[r5]
    mov     r0,0x80
    lsl     r0,r0,2
    and     r0,r1
    cmp     r0,0			;moves boss based on X direction
    beq     @@MoveLeft
    ldrh    r0,[r2,0xA]
    add     r0,1
    b       @@StoreX
@@MoveLeft:
    ldrh    r0,[r2,0xA]
    sub     r0,1
@@StoreX:
    strh    r0,[r2,0xA]
@@CheckMetTargets:
    cmp     r6,2			;true if both targets are met
    bne     @@Return
    mov     r2,r5
    add     r2,0x2E
    ldrb    r0,[r2]
    sub     r0,1
    strb    r0,[r2]			;timer to start final pose
    lsl     r0,r0,0x18
    cmp     r0,0
    bne     @@Return
    mov     r1,r5
    add     r1,0x24
    mov     r0,0x22
    strb    r0,[r1]			;pose 22h
    mov     r0,0x3C
    strb    r0,[r2]			;3Ch to 2Eh, timer
;  mov     r0,0xA9
;   lsl     r0,r0,2
;    bl      PlaySound5
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0

NightmareDeath:
	push    r4-r6,r14 								;AI for dying
	add		sp,-4h
	bl		NightmareFlashing
	ldr		r3,=CurrSpriteData
	mov		r1,r3
	add		r1,0x2E
	ldrb	r0,[r1]
	cmp		r0,0
	beq		@@MakeBoomBooms
	sub		r0,1
	strb	r0,[r1]
	cmp		r0,0
	beq		@@SetTimer
	b		@@Return
@@SetTimer:
	mov		r0,0x27
	strh	r0,[r3,6h]
@@MakeBoomBooms:
;	ldr		r6,=SetParticleEffect + 1
	ldrh    r0,[r3,6h]										              
	sub     r0,1h                   
	strh    r0,[r3,6h]								;decrements              
	ldrh    r0,[r3,2h]								;sprite Y              
	sub     r0,80h                 
	lsl     r0,r0,10h               
	lsr     r5,r0,10h               
	ldrh    r4,[r3,4h]								;sprite X              
	ldrh    r0,[r3,8h]              
	mov     r2,r3                   
	cmp     r0,0h                   
	bne     @@TimerCheck                
	b       @@EffectSet2
@@TimerCheck:
	ldrh    r0,[r3,6h]              
	cmp     r0,28h                  
	bls     @@JumpGet                
	b       @@Return
@@JumpGet:
	lsl     r0,r0,2h                
	ldr     r1,=@@JumpTable            
	add     r0,r0,r1                
	ldr     r0,[r0]                 
	mov     r15,r0                  
.pool
@@JumpTable:
	.word @@TimerSet,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect4,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect3,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect2,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect1
@@Effect1:	
	mov     r0,r5                   
	sub     r0,10h                  
	mov     r1,r4                   
	mov     r2,21h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3
	mov     r0,r5                   
	add     r0,10h                  
	mov     r1,r4                   
	b       @@Branch2
@@Effect2:
	mov     r0,r5                   
	sub     r0,1Ah                  
	b       @@Branch
@@Effect3:
	mov     r0,r5                   
	add     r0,40h	
	mov     r1,r4                   
	sub     r1,10h
@@Branch2:	
	mov     r2,27h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                 
	b       @@Return
@@Effect4:
	mov     r0,r5                   
	sub     r0,20h
@@Branch:
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,22h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                
	b       @@Return
@@TimerSet:
	mov     r0,0h                   
	strh    r0,[r2,8h]              
	mov     r0,2Ch                  
	strh    r0,[r2,6h]								;X parasite timer              
	b       @@Return
@@EffectSet2:
	ldrh    r0,[r3,6h]              
	cmp     r0,28h                  
	bls     @@JumpGet2                
	b       @@Return
@@JumpGet2:
	lsl     r0,r0,2h                
	ldr     r1,=@@JumpTable2            
	add     r0,r0,r1                
	ldr     r0,[r0]                 
	mov     r15,r0                  
.pool
@@JumpTable2:
	.word @@KillSprite,@@Return,@@Return,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect8,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect7,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect6,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect5
@@Effect5:	
	mov     r0,r5                   
	sub     r0,30h                  
	sub     r4,10h                  
	mov     r1,r4                   
	mov     r2,1Fh                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                 
	mov     r0,r5                   
	add     r0,20h                  
	mov     r1,r4                   
	b       @@SetEffect
@@Effect6:
	mov     r0,r5                   
	sub     r0,20h                  
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,27h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                
	mov     r0,r5                   
	add     r0,40h                  
	b       @@PreSetEffect
@@Effect7:
	mov     r0,r5                   
	sub     r0,20h                  
	sub     r4,10h                  
	mov     r1,r4                   
	mov     r2,26h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                
	mov     r0,r5                   
	add     r0,40h                  
	mov     r1,r4                   
	b       @@SetEffect
@@Effect8:
	mov     r0,r5                   
	sub     r0,35h
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,21h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                
	mov     r0,r5                   
	add     r0,20h
@@PreSetEffect:
	mov     r1,r4  
	add     r1,20h 
@@SetEffect:
	mov     r2,25h                  
	ldr     r3,=SetParticleEffect + 1
	bl		WrapperR3                 
	b       @@Return
@@KillSprite:
	ldr     r4,=CurrSpriteData            		                          
	ldrh    r1,[r4,2h]		;sprite Y position 
	sub		r1,60h
	ldrh    r2,[r4,4h]		;sprite X position                               
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r4,=SpriteDead + 1
	bl		WrapperR4
	ldr		r1,=DoorUnlockTimer
	mov		r0,3Ch
	neg		r0,r0
	strb	r0,[r1]				;opens doors
	mov		r0,1
	bl		SetnCheckEvent
	mov		r0,0Bh				;boss killed song
	mov		r1,0h
	ldr		r2,=PlaySong + 1
	;bl		WrapperR2
	nop
	nop
	ldr		r0,=CurrBossDirection
	mov		r1,0
	str		r1,[r0]		;reset boss ram
@@Return:
	add		sp,4h
	pop     r4-r6                   
	pop     r0
	bx		r0                    
.pool

NightmareMain:
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,0x24
    ldrb    r0,[r0]
    cmp     r0,0x3B
    bls     @@GetJumpAddress
    b       @@Return
@@GetJumpAddress:
    lsl     r0,r0,2
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .word @@Initialize,@@Phase2Start,@@Phase2,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Phase2End
	.word @@PrePhase3,@@StartPhase3,@@PreSlowMove,@@PreFast
	.word @@FastMove,@@Return,@@SlowMove,@@Return
	.word @@PreDeath,@@Return,@@Death,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@PreFightDelay
	.word @@PreFightRise,@@StartSong,@@Phase1,@@PrePhase2
@@Initialize:
    bl      NightmareInitialize
    b       @@Return
@@PreFightDelay:
    bl      NightmareStartDelay
    b       @@Return
@@PreFightRise:
    bl      NightmareRising
    b       @@Return
@@StartSong:
    bl      NightmareStartSong
@@Phase1:
    bl      NightmarePhase1
    b       @@Return
@@PrePhase2:
    bl      NightmarePrePhase2
    b       @@Return
@@Phase2Start:
    bl      NightmarePhase2Start
    b       @@Return
@@Phase2:
    bl      NightmarePhase2
    b       @@Return
@@Phase2End:
    bl      NightmareEndPhase2
@@PrePhase3:
    bl      NightmarePrePhase3
    b       @@Return
@@StartPhase3:
    bl      NightmarePhase3Start
    b       @@Return
@@PreSlowMove:
    bl      NightmareStartSlowMovement
    b       @@Return
@@PreFast:
    bl      NightmarePreFastMove
@@FastMove:
    bl      NightmareFastMovement
    b       @@Return
@@SlowMove:
    bl      NightmareSlowMovement
    b       @@Return
@@PreDeath:
    bl      NightmarePreDeath
    b       @@Return
@@Death:
    bl      NightmareDeath
@@Return:
    bl      NightmareRepeatSound
    bl      NightmareUpdateAnim			;update boss animation?
    bl      NightmareUpdateOAM
;	bl 		DistortBG
    pop     r0
    bx      r0
	
NightmareUpdateAnim:
    push    r14
    ldr     r2,=CurrBossData
    ldrb    r0,[r2,6]
    add     r0,1
    strb    r0,[r2,6]
    ldrh    r1,[r2,4]
    ldr     r3,[r2]
    lsl     r1,r1,3
    add     r1,r1,r3
    ldrb    r1,[r1,4]
    cmp     r1,r0
    bcs     @@Return
    mov     r0,1
    strb    r0,[r2,6]
    ldrh    r0,[r2,4]
    add     r0,1
    strh    r0,[r2,4]
    ldrh    r0,[r2,4]
    lsl     r0,r0,3
    add     r0,r0,r3
    ldrb    r0,[r0,4]
    cmp     r0,0
    bne     @@Return
    strh    r0,[r2,4]
@@Return:
    pop     r0
    bx      r0
.pool