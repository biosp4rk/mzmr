;Secondaries AI

MatchPositions:
	ldr		r3,=CurrSpriteData
	ldr		r2,=SpriteDataSlot0
	mov		r1,r3
	add		r1,23h
	ldrb	r1,[r1]
	lsl		r0,r1,1h
	add		r0,r0,r1
	lsl		r0,r0,1h
	add		r2,r0,r2
	ldrb	r0,[r3,1Eh]
	cmp		r0,0h
	beq		@@EyePos
	cmp		r0,2h
	bne		@@Return
	ldrh	r0,[r2,2h]
	strh	r0,[r3,2h]
	ldrh	r0,[r2,4h]
	strh	r0,[r3,4h]
	b 		@@Return
@@EyePos:
	ldrh	r0,[r2,2h]
	ldr		r1,=0FFF4h
	add		r0,r0,r1
	strh	r0,[r3,2h]
	ldrh	r0,[r2,4h]
	sub		r1,34h			;FFC0
	add		r0,r0,r1
	strh	r0,[r3,4h]
@@Return:
	bx		r14
.pool

LegSpawnAI:						;pose 0, 5CD24
    push    r4,r5,r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r5,0h
    strh    r0,[r2]				;removes 4h flag
    mov     r1,r2
    add     r1,24h
    mov     r0,2h
    strb    r0,[r1]
    ldrb    r4,[r2,1Eh]
    mov     r3,r2
    cmp     r4,0h
    beq     @@Eye
    cmp     r4,2h
    beq     @@Legs
    mov     r0,0h
    strh    r0,[r3]				;kills sprite if not in matching slot
    b       @@Return
.pool
@@Eye:
    mov     r1,r3
    add     r1,22h
    mov     r0,0Bh
    strb    r0,[r1]				;draw order
    mov     r0,r3
    add     r0,27h
    mov     r1,8h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]				;all drawing related
    ldr     r1,=0xFFFC
    strh    r1,[r3,0Ah]			;top hitbox
    mov     r2,4h				
    mov     r0,4h
    strh    r0,[r3,0Ch]			;bottom hitbox
    strh    r1,[r3,0Eh]			;left hitbox
    strh    r0,[r3,10h]			;right hitbox
    ldrh    r0,[r3]
    orr     r0,r2
    mov     r2,80h
    lsl     r2,r2,8h
    mov     r1,r2
    orr     r0,r1
    strh    r0,[r3]			;set's 8004h
    mov     r0,r3
    add     r0,2Eh
    strb    r5,[r0]			;0's timer
    add     r0,1h
    strb    r5,[r0]			;0 to 2Fh
    b       @@Return
.pool
@@Legs:
    mov     r1,r3
    add     r1,22h
    mov     r0,0Dh
    strb    r0,[r1]					;draw order
    mov     r0,r3
    add     r0,27h
    mov     r1,28h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]
    mov     r1,r3
    add     r1,29h
    mov     r0,38h
    strb    r0,[r1]				;all drawing related
	ldr		r0,=YakOAM_12
	str		r0,[r3,18h]
    ldr     r0,=0xFF80
    strh    r0,[r3,0Ah]				;top hitbox
    mov     r0,10h
    strh    r0,[r3,0Ch]				;bottom hitbox
    ldr     r0,=0xFF60
    strh    r0,[r3,0Eh]				;left hitbox
    mov     r0,0A0h
    strh    r0,[r3,10h]				;right hitbox
    mov     r0,r3
    mov     r0,1h
    strh    r0,[r3,14h]				;health
@@Return:
    ldrh    r1,[r3]
    ldr	    r0,=8004h
    orr     r0,r1
    strh    r0,[r3]				;sets 8004h flag
	mov		r0,r3
	add		r0,25h
	mov		r1,0h
	strb	r1,[r0]				;0's Samus collision
    bl      MatchPositions		;updates Y and X position (matches Yakuza's)
    pop     r4,r5
    pop     r0
    bx      r0
.pool

Phase1LegsAI:						;5CDF0, pose 2 for Legs during phase 1
    push    r4-r6,r14
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,23h
    ldrb    r3,[r0]
    ldrh    r4,[r1]
    mov     r5,4h
    mov     r0,r5
    and     r0,r4				;checks for 4h
    mov     r2,r1
    ldr     r6,=SpriteDataSlot0
    cmp     r0,0h
    beq     @@CheckIfGrabbed
    lsl     r0,r3,3h
    sub     r0,r0,r3
    lsl     r0,r0,3h
    add     r0,r0,r6
    ldrh    r1,[r0]
    mov     r0,r5
    and     r0,r1				;checks if Yakuza also have 4h flag set (only ture when awaiting start of fight)
    cmp     r0,0h
    bne     @@Return
	mov		r0,r2
	add		r0,25h
	mov		r1,4h
	strb	r1,[r0]
    ldr     r0,=0x7FFB
    and     r0,r4
    strh    r0,[r2]				;removes 8004h
@@CheckIfGrabbed:
    ldr     r0,=SamusData
    ldrb    r0,[r0,1h]
    cmp     r0,40h				;checks if grabbed
    bne     @@SetHurtSamus
    mov     r1,r2
    add     r1,25h				;if grabbed, do not hurt samus
    mov     r0,0h
    b       @@ChangeHitbox
.pool
@@SetHurtSamus:
    mov     r1,r2
    add     r1,25h
    mov     r0,4h				;can hurt samus
@@ChangeHitbox:
    strb    r0,[r1]
    lsl     r0,r3,3h
    sub     r0,r0,r3
    lsl     r0,r0,3h
    add     r0,r0,r6
    mov     r1,0Ch
    ldsh    r0,[r0,r1]
    cmp     r0,60h
    bne     @@BottomHitboxValue
    mov     r0,10h
    b       @@ChangeBottomHitbox
@@BottomHitboxValue:
    mov     r0,2Ch
@@ChangeBottomHitbox:
    strh    r0,[r2,0Ch]
@@Return:
    pop     r4-r6
    pop     r0
    bx      r0
	
Phase2LegsAI:						;pose 2, 5CE6C Legs ai for second phase
    push    r4,r5,r14
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,23h
    ldrb    r1,[r0]
    ldr     r2,=SpriteDataSlot0
    lsl     r0,r1,3h
    sub     r0,r0,r1
    lsl     r0,r0,3h
    add     r4,r0,r2
    mov		r1,r4
    add     r1,24h
    ldrb	r0,[r1]
    cmp     r0,49h					;checks if Yakuza is on last pose
    bne     @@CheckMakeVisible
    mov     r0,0h
    strh    r0,[r3]					;if so kill sprite
    b       @@Return
    .pool
@@CheckMakeVisible:
    mov     r1,r3
    add     r1,26h
    mov     r0,1h
    strb    r0,[r1]					;prevents interaction with Samus
    ldrh    r1,[r3]
    mov     r2,80h
    lsl     r2,r2,8h
    mov     r0,r2
    mov     r5,0h
    mov     r2,r0
    orr     r2,r1
    strh    r2,[r3]					;sets 8000h
    ldrh    r1,[r4]
    mov     r0,8h
    and     r0,r1
    cmp     r0,0h					;checks if Yak has its rotation flag set 
    beq     @@MakeVisible
    mov     r0,4h
    orr     r2,r0					;sets 4h flag
    b       @@StoreStatus
@@MakeVisible:
    ldr     r0,=0xFFFB
    and     r2,r0					;removes 4h flag
@@StoreStatus:
    strh    r2,[r3]
@@Return:
    pop     r4,r5
    pop     r0
    bx      r0
.pool

BlinkAI:					;5CED0
    push    r4-r7,r14
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,23h
    ldrb    r1,[r0]
    add     r0,3h
    mov     r7,1h
    strb    r7,[r0]			;makes sprite not interact with Samus
    ldr     r2,=SpriteDataSlot0
    lsl     r0,r1,3h
    sub     r0,r0,r1
    lsl     r0,r0,3h
    add     r2,r0,r2
    ldrh    r1,[r2]
    mov     r0,8h
    and     r0,r1
    cmp     r0,0h			;checks for rotation flag
    beq     @@CheckShowEye
    mov     r1,r4
    add     r1,24h
    mov     r0,18h
    strb    r0,[r1]			;sets pose 18h
	mov		r0,r4
	add		r0,25h
	mov		r1,0h
	strb	r1,[r0]			;cannot hurt samus
    ldrh    r1,[r4]
    mov     r2,4h			;sets 4h flag
    b       @@ChangeStatus
.pool
@@CheckShowEye:
    ldrh    r3,[r4]
    mov     r5,4h
    mov     r0,r5
    and     r0,r3	
    cmp     r0,0h			;checks if 4h is set
    beq     @@MatchPalette
    mov     r0,r5
    and     r0,r1
    cmp     r0,0h			;checks is Yak also has 4h set
    bne     @@Return
	mov		r0,r4
	add		r0,25h
	mov		r1,4h
	strb	r1,[r0]			;can hurt Samus
@@MatchPalette:
    mov     r0,r2
    add     r0,20h
    ldrb    r1,[r0]			;check palette of Yakuza
    mov     r0,r4
    add     r0,20h
    strb    r1,[r0]			;makes same palette as Yak
    mov     r6,r4
    add     r6,2Fh
    ldrb    r5,[r6]
    mov     r3,r5
    cmp     r3,0h
    bne     @@CheckStun
    mov     r0,r2
    add     r0,2Bh
    ldrb    r1,[r0]
    mov     r0,7Fh
    and     r0,r1
    cmp     r0,10h					;checking if yak was hit
    bne     @@CheckPose
    mov     r1,r4
    add     r1,2Eh
    mov     r0,2h
    strb    r0,[r1]					;timer
    add     r0,r5,1h
    strb    r0,[r6]
    ldr     r0,=YakOAM_24			;OAM
    str     r0,[r4,18h]
    strb    r3,[r4,1Ch]
    strh    r3,[r4,16h]
    ldrh    r1,[r4]
    ldr     r0,=0xFFFB
    and     r0,r1					;removes 4h, making sprite visable is Yak was hit
    b       @@StoreStatus
    .pool
@@CheckPose:
    mov     r0,r2
    add     r0,24h
    ldrb    r0,[r0]
    cmp     r0,7h
    beq     @@CheckMakeVisible
    cmp     r0,9h
    bne     @@Return
@@CheckMakeVisible:
    ldr     r0,=SpriteRNG
    ldrb    r1,[r0]
    mov     r0,3h
    and     r0,r1
    cmp     r0,2h
    bhi     @@Return
    mov     r0,r7
    and     r0,r1
    mov     r1,r4
    add     r1,2Eh
    strb    r0,[r1]
    add     r0,r5,1h
    strb    r0,[r6]
    ldr     r0,=YakOAM_24			;OAM
    str     r0,[r4,18h]
    strb    r3,[r4,1Ch]
    strh    r3,[r4,16h]
    ldrh    r1,[r4]
    ldr     r0,=0xFFFB
    and     r0,r1				;removes 4h flag
    b       @@StoreStatus
    .pool
@@CheckStun:
    mov     r0,r2
    add     r0,2Bh
    ldrb    r1,[r0]
    mov     r0,7Fh
    and     r0,r1
    cmp     r0,0h				;check yakuza stun value
    beq     @@CheckTimer
    ldrb    r0,[r4,1Ch]
    add     r0,2h
    strb    r0,[r4,1Ch]			;adds two to animation counter
@@CheckTimer:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    mov     r2,r4
    add     r2,2Eh
    ldrb    r0,[r2]
    mov     r1,r0
    cmp     r1,0h
    beq     @@MakeInvisible
    sub     r0,1h
    strb    r0,[r2]
    b       @@Return
@@MakeInvisible:
    strb    r1,[r6]
    ldrh    r1,[r4]
    mov     r0,4h				;sets 4h
@@ChangeStatus:
    orr     r0,r1
@@StoreStatus:
    strh    r0,[r4]
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
	
CheckKillEye:
    push    r14
    ldr     r3,=CurrSpriteData
    mov     r0,r3
    add     r0,23h	
    ldrb    r1,[r0]
    mov     r2,r3
    add     r2,26h
    mov     r0,1h
    strb    r0,[r2]					;prevents interaction with Samus
    ldr     r2,=SpriteDataSlot0
    lsl     r0,r1,3h
    sub     r0,r0,r1
    lsl     r0,r0,3h
    add     r0,r0,r2
    add		r0,24h
    ldrb	r0,[r0]
    cmp     r0,49h					;checks if Yakuza is on last pose
    bne     @@Return
    mov     r0,0h
    strh    r0,[r3]					;kills sprite
@@Return:
    pop     r0
    bx      r0
.pool	

LegsAI:
;.notice "Yakuza Legs"
;.notice tohex(.)
    push    r14
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,24h
    ldrb    r1,[r0]
    cmp     r1,0h					;checks pose
    bne     @@CheckRoomSlot
    bl      LegSpawnAI
    b       @@Return
    .pool
@@CheckRoomSlot:
    ldrb    r0,[r2,1Eh]
    cmp     r0,2h					;legs
    bne     @@CheckRoomSlot2
    ldr     r0,=Phase1Flag
    ldrh    r0,[r0]
    cmp     r0,0h
    beq     @@LegsAI2
    bl      Phase1LegsAI
    b       @@UpdatePosition
.pool
@@LegsAI2:
    bl      Phase2LegsAI
	b 		@@UpdatePosition
@@CheckRoomSlot2:
    cmp     r0,0h				;0h is eye
    bne     @@Return
    cmp     r1,2h				;checks pose
    bne     @@CheckKill
    bl      BlinkAI
    b       @@UpdatePosition
@@CheckKill:
    bl      CheckKillEye
@@UpdatePosition:
    bl      MatchPositions			;updates X and Y position to match yakuza's 
    b       @@Return
@@Return:
    pop     r0
    bx      r0
	
ChunkSpawnAI:						;pose 0, 805D3B4
    push    r4,r5,r14
    ldr     r0,=CurrSpriteData
    mov     r12,r0
    ldrh    r1,[r0]
    ldr     r0,=0xFFFB
    and     r0,r1
    mov     r3,0h
    mov     r4,0h
    mov     r1,r12
    strh    r0,[r1]					;removes 4h flag
    mov     r0,r12
    add     r0,22h
    mov     r2,2h
    strb    r2,[r0]					;draw order
    mov		r0,1h
    mov     r1,r12
    add     r1,21h
    strb    r0,[r1]					;background priority
    mov     r0,r12
    add     r0,25h
    strb    r3,[r0]					;no samus collision
    ldr     r1,=0xFFFC
    mov     r5,r12
    strh    r1,[r5,0Ah]				;top hitbox
    mov     r0,44h
    strh    r0,[r5,0Ch]				;bottom hitbox
    strh    r1,[r5,0Eh]				;left hitbox
    strh    r0,[r5,10h]				;right hitbox
    strb    r3,[r5,1Ch]				;zeros animation data
    strh    r4,[r5,16h]
    mov     r0,r12
    add     r0,24h
    strb    r2,[r0]					;sets pose 2
    add     r0,8h
    strb    r3,[r0]					;0 to 2Ch
    strh    r4,[r5,14h]				;health to 0
    ldrb    r0,[r5,1Eh]
    mov     r3,r12
    cmp     r0,5h					;checks slot number
    bls     @@GetJump
    b       @@KillSprite
@@GetJump:
    lsl     r0,r0,2h
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
.pool
@@JumpTable:
    .word @@Chunk1,@@Chunk2,@@Chunk3,@@Chunk4,@@Chunk5,@@Chunk6
	
@@Chunk1:
    ldr     r0,=YakOAM_30
    str     r0,[r3,18h]				;OAM 
    mov     r1,r3
    add     r1,27h
    mov     r2,0h
    mov     r0,8h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,20h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,18h
    strb    r0,[r1]					;drawing related
    add     r1,4h
    mov     r0,2h
    strb    r0,[r1]					;2 to 2Dh
    mov     r0,r3
    add     r0,2Eh
    strb    r2,[r0]					;0 to timer
    mov     r0,3Ch
    mov     r1,81h
	ldr		r3,=VerticalScreenShake + 1
	bl		WrapperR3
    ldr     r0,=0x1F0
	ldr		r3,=PlaySound + 1
	bl		WrapperR3				;explosion noise
    b       @@Return
.pool
@@Chunk2:
    ldr     r0,=YakOAM_31
    str     r0,[r3,18h]				;OAM
    mov     r0,r3
    add     r0,27h
    mov     r2,8h
    strb    r2,[r0]
    add     r0,1h
    mov     r1,20h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]					;drawing related
    mov     r1,r3
    add     r1,2Dh
    mov     r0,6h
    strb    r0,[r1]
    mov     r0,r3
    add     r0,2Eh
    strb    r2,[r0]					;8h to timer
    b       @@Return
    .pool
@@Chunk3:
    ldr     r0,=YakOAM_32
    str     r0,[r3,18h]				;OAM
    mov     r1,r3
    add     r1,27h
    mov     r0,10h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,8h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,28h
    strb    r0,[r1]					;drawing related
    add     r1,4h
    mov     r0,0Ah
    strb    r0,[r1]					;0Ah to 2Dh
    add     r1,1h
    mov     r0,6h
    strb    r0,[r1]					;6 to timer
    b       @@Return
    .pool
@@Chunk4:
    ldr     r0,=YakOAM_33
    str     r0,[r3,18h]			;OAM
    mov     r1,r3
    add     r1,27h
    mov     r0,8h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,20h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,18h					;drawing related
    strb    r0,[r1]
    add     r1,4h
    mov     r0,4h
    strb    r0,[r1]					;4h to 2Dh
    add     r1,1h
    mov     r0,0Ah
    strb    r0,[r1]					;0A to timer
    b       @@Return
    .pool
@@Chunk5:
    ldr     r0,=YakOAM_34
    str     r0,[r3,18h]
    mov     r1,r3
    add     r1,27h
    mov     r0,8h
    strb    r0,[r1]
    mov     r0,r3
    add     r0,28h
    mov     r1,20h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]					;drawing related
    mov     r1,r3
    add     r1,2Dh
    mov     r0,6h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,2h
    strb    r0,[r1]					;2h to timer
    b       @@Return
    .pool
@@Chunk6:
    ldr     r0,=YakOAM_35
    str     r0,[r3,18h]
    mov     r1,r3
    add     r1,27h
    mov     r0,10h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,8h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,28h
    strb    r0,[r1]					;drawing related
    add     r1,4h
    mov     r0,0Ah
    strb    r0,[r1]					;0A to 2Dh
    add     r1,1h
    mov     r0,4h
    strb    r0,[r1]					;4 to timer
    b       @@Return
    .pool
@@KillSprite:
    mov     r0,r12
    strh    r4,[r0]					;kills sprite if over slot number 5
@@Return:
    pop     r4,r5
    pop     r0
    bx      r0
	
MoveChunks:							;pose 2, 5D578
    push    r4-r6,r14
    ldr     r1,=CurrSpriteData
    mov     r3,r1
    add     r3,2Eh
    ldrb    r0,[r3]
    mov     r2,r1
    cmp     r0,0h
    beq     @@GetMovementValue
    sub     r0,1h
    strb    r0,[r3]
    cmp     r0,0h				;checks and decrements timer
    bne     @@Return
    ldrh    r0,[r2,2h]
    ldrh    r1,[r2,4h]
    mov     r2,25h				;effect when arm blows off
	ldr		r3,=SetGFXEffect + 1
	bl		WrapperR3
    b       @@Return
    .pool
@@GetMovementValue:
    mov     r0,2Ch
    add     r0,r0,r2
    mov     r12,r0
    ldrb    r3,[r0]
    ldr     r5,=LegChunkTable		;table used for arcing movement
    lsl     r0,r3,1h
    add     r0,r0,r5
    ldrh    r4,[r0]				;unsigned value
    mov     r6,0h
    ldsh    r1,[r0,r6]			;loads signed value
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@NotMaxSpeed
	ldrh	r0,[r2]
	mov		r1,2h
	and		r0,r1
	cmp		r0,0h				;checks to kill sprite if offsecreen and falling at max speed
	beq		@@KillSprite
    sub     r1,r3,1h
    lsl     r1,r1,1h
    add     r1,r1,r5
    ldrh    r0,[r2,2h]
    ldrh    r1,[r1]
    add     r0,r0,r1
    b       @@ChangeY
    .pool
@@NotMaxSpeed:
    add     r0,r3,1h
    mov     r1,r12
    strb    r0,[r1]		
    ldrh    r0,[r2,2h]
    add     r0,r0,r4
@@ChangeY:
    strh    r0,[r2,2h]
    ldrb    r0,[r2,1Eh]			;checks slot
    cmp     r0,2h				;if above 2h, then it's a leg on the right			
    bhi     @@MoveRight
    mov     r0,r2
    add     r0,2Dh
    ldrb    r1,[r0]
    ldrh    r0,[r2,4h]			;moving the legs on the left
    sub     r0,r0,r1
    b       @@ChangeX
@@MoveRight:
    mov     r1,r2
    add     r1,2Dh
    ldrh    r0,[r2,4h]			;moving legs on the right
    ldrb    r1,[r1]
    add     r0,r0,r1
@@ChangeX:
    strh    r0,[r2,4h]
	b 		@@Return
@@KillSprite:
	strh	r0,[r2]
@@Return:
    pop     r4-r6
    pop     r0
    bx      r0	

ChunkAI:						;5D9CC
;.notice "YakuzaChunk"
;.notice tohex(.)
    push    r14
    ldr     r0,=CurrSpriteData
    mov     r2,r0
    add     r2,26h
    mov     r1,1h
    strb    r1,[r2]					;prevents interaction with Samus
    add     r0,24h
    ldrb    r0,[r0]
    cmp     r0,0h
    beq     @@Spawn					;checks pose
    cmp     r0,2h
    beq     @@MoveAI
    b       @@Return
.pool
@@Spawn:
    bl      ChunkSpawnAI
    b       @@Return
@@MoveAI:
    bl      MoveChunks
@@Return:
    pop     r0
    bx      r0
	
ProjectileSpawnAI:						;pose 0, 805D038
    push    r4,r5,r14
    ldr     r3,=CurrSpriteData
    ldrh    r0,[r3]
    ldr     r1,=0xFFFB
    and     r1,r0
    mov     r5,0h
    mov     r4,0h
    strh    r1,[r3]						;removes 4h
    mov     r0,r3
    add     r0,22h
    mov     r1,4h
    strb    r1,[r0]						;draw order
    ldr     r0,=Phase1Flag
    ldrb	r2,[r0]					 ;phase 1 flag
    cmp     r2,0h						;0 if on phase 2
    beq     @@SpawnGunk
    mov     r0,r3						;spawing fireball
    add     r0,25h
    mov     r1,4h
    strb    r1,[r0]						;hurts samus
    mov     r2,r3
    add     r2,27h
    mov     r0,28h
    strb    r0,[r2]
    mov     r0,r3
    add     r0,28h
    strb    r5,[r0]
    add     r2,2h
    mov     r0,10h
    strb    r0,[r2]						;all drawing related
    ldr     r0,=0xFFA0
    strh    r0,[r3,0Ah]					;top hitbox
    strh    r4,[r3,0Ch]					;bottom hitbox
    add     r0,48h
    strh    r0,[r3,0Eh]
    mov     r0,18h
    strh    r0,[r3,10h]
    ldr     r0,=YakOAM_27
    str     r0,[r3,18h]
    strb    r5,[r3,1Ch]
    strh    r4,[r3,16h]
    mov     r0,r3
    add     r0,24h
	mov		r1,1h
    strb    r1,[r0]						;pose 1
    strh    r4,[r3,14h]					;0 to health
    b       @@Return
    .pool
@@SpawnGunk:
    mov     r0,r3
    add     r0,25h
	mov		r1,13h
    strb    r1,[r0]						;13h (hurts samus, dies when hit) to collision
    mov     r1,r3
    add     r1,27h
    mov     r0,18h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,8h
    strb    r0,[r1]
    add     r1,1h
    mov     r0,10h
    strb    r0,[r1]						;drawing related
    ldr     r0,=0xFFE0
    strh    r0,[r3,0Ah]					;top hitbox
    strh    r2,[r3,0Ch]					;bottom hitbox
    add     r0,4h
    strh    r0,[r3,0Eh]					;left hitbox
    mov     r0,1Ch
    strh    r0,[r3,10h]					;right hitbox
    ldr     r0,=YakOAM_26
    str     r0,[r3,18h]
    strb    r5,[r3,1Ch]
    strh    r2,[r3,16h]
    sub     r1,5h
    mov     r0,6h
    strb    r0,[r1]						;sets pose 6h
    mov     r2,r3
    add     r2,34h
    ldrb    r0,[r2]
    mov     r1,4h
    orr     r0,r1
    strb    r0,[r2]
    mov     r0,1h
    strh    r0,[r3,14h]					;sets health to 1
@@Return:
    pop     r4,r5
    pop     r0
    bx      r0
.pool

KillGunk:							;pose 7				
    push    r4,r7,r14
	add		sp,-4h
	ldr		r4,=CurrSpriteData
    ldrh    r1,[r4,2h]		;sprite Y position 
	ldrh    r2,[r4,4h]		;sprite X position                               
	mov     r0,21h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h                                   
	ldr		r7,=SpriteDead + 1
	bl		WrapperR7
	add		sp,4h
    pop     r4,r7
    pop     r0
    bx      r0
 .pool
 
GunkMainAI:						;pose 6
    push    r14
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    add     r1,0Ch
    strh    r1,[r0,2h]			;moves sprite downwards
	ldrh	r1,[r0]
	mov		r2,2h
	and		r1,r2
	cmp		r1,0h
	bne		@@Return
	strh	r1,[r0]				;kills sprite if offscreen 
@@Return:
    pop     r0
    bx      r0
.pool

MoveFireballAI:							;pose 1
    push    r4,r14
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    add     r1,0Ch
    strh    r1,[r0,2h]				;moves sprite downwards
    ldrb    r1,[r0,1Eh]
    mov     r4,r0
    cmp     r1,0h					;checks flag to move along X-axis
    beq     @@CheckHitFloor				
    ldrh    r1,[r4]
    mov     r0,40h
    and     r0,r1					;checks for 40h flag, X-flip
    cmp     r0,0h					;used to check which direction the fireball should move
    beq     @@MoveLeft
    ldrh    r0,[r4,4h]
    add     r0,0Ch
    strh    r0,[r4,4h]				;moves fireball to the right
    ldrh    r0,[r4,2h]
    ldrh    r1,[r4,4h]
    add     r1,24h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    b       @@CheckHitWall
    .pool
@@MoveLeft:
    ldrh    r0,[r4,4h]
    sub     r0,0Ch
    strh    r0,[r4,4h]				;move fireball to the left
    ldrh    r0,[r4,2h]
    ldrh    r1,[r4,4h]
    sub     r1,24h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
@@CheckHitWall:
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    ldr     r4,=CurrSpriteData
    cmp     r0,0h				;false if hitting a wall
    beq     @@CheckHitFloor
    mov     r0,0h
    strb    r0,[r4,1Eh]			;sets sprite data to 0 (no longer moves along X axis)
@@CheckHitFloor:
    ldrh    r0,[r4,2h]
    ldrh    r1,[r4,4h]
	ldr		r3,=CheckHitFloor + 1
	bl		WrapperR3
    mov     r1,r0				;returns Y pos of top of block
    ldr     r0,=FloorClipValue
    ldrb    r0,[r0]
    cmp     r0,0h				;false if hit floor
    beq     @@Return
    mov     r2,0h
    strh    r1,[r4,2h]			;places fire on top of block
    mov     r1,r4
    add     r1,24h
    mov     r0,2h
    strb    r0,[r1]				;sets pose 2h
    add     r1,0Ah
    mov     r0,78h
    strb    r0,[r1]				;78h to timer
    mov     r0,r4
    add     r0,2Ch
    strb    r2,[r0]				;0
    ;mov     r0,9Eh
    ;lsl     r0,r0,1h
	;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
@@Return:
    pop     r4
    pop     r0
    bx		r0
	
FirstShrinkAI:						;pose 2h
    push    r4-r7,r14
    ldr     r2,=CurrSpriteData
    mov     r6,r2
    add     r6,2Ch
    ldrb    r3,[r6]
    ldr     r5,=FireballTable			;table used for slight left and right movement
    lsl     r0,r3,1h
    add     r0,r0,r5
    ldrh    r4,[r0]
    mov     r7,0h
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0				;false if at end of table
    bne     @@CheckTimer
    ldrh    r4,[r5]
    mov     r3,0h
@@CheckTimer:
    add     r0,r3,1h
    strb    r0,[r6]
    ldrh    r0,[r2,4h]
    add     r0,r0,r4
    strh    r0,[r2,4h]				;moves sprite based on table
    mov     r3,r2
    add     r3,2Eh
    ldrb    r0,[r3]
    sub     r1,r0,1h
    strb    r1,[r3]
    mov		r4,r1
    cmp     r4,0h					;checks and decrements timer
    bne     @@CheckPlaySound
    mov     r0,50h
    strb    r0,[r3]					;50h to timer
    mov     r1,r2
    add     r1,24h
    mov     r0,3h
    strb    r0,[r1]					;pose 3
    ldr     r0,=YakOAM_28
    str     r0,[r2,18h]
    mov     r0,0h
    strb    r0,[r2,1Ch]
    strh    r4,[r2,16h]
    ldr     r0,=0xFFC0
    strh    r0,[r2,0Ah]				;top hitbox
    add     r0,30h
    strh    r0,[r2,0Eh]				;left hitbox
    mov     r0,10h
    strh    r0,[r2,10h]				;right hitbox
    ;ldr     r0,=0x13D
    ;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
    b       @@Return
    .pool
@@CheckPlaySound:
    ;mov     r0,0Fh
    ;and     r1,r0
    ;cmp     r1,0h
    ;bne     @@Return
    ;mov     r0,0x9E					;burning sound
    ;lsl     r0,r0,1
    ;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
	
SecondShrinkAI:							;pose 3, pretty much exactly the same as the function above
    push    r4-r7,r14				;not going to comment much of this one as a result
    ldr     r2,=CurrSpriteData
    mov     r6,r2
    add     r6,2Ch
    ldrb    r3,[r6]
    ldr     r5,=FireballTable
    lsl     r0,r3,1h
    add     r0,r0,r5
    ldrh    r4,[r0]
    mov     r7,0h
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@CheckTimer
    ldrh    r4,[r5]
    mov     r3,0h
@@CheckTimer:
    add     r0,r3,1h
    strb    r0,[r6]
    ldrh    r0,[r2,4h]
    add     r0,r0,r4
    strh    r0,[r2,4h]
    mov     r3,r2
    add     r3,2Eh
    ldrb    r0,[r3]
    sub     r1,r0,1h
    strb    r1,[r3]
    mov		r4,r1
    cmp     r4,0h
    bne     @@CheckPlaySound
    mov     r0,3Ch
    strb    r0,[r3]					;3Ch to timer
    mov     r1,r2
    add     r1,24h
    mov     r0,4h					;pose 4
    strb    r0,[r1]
    ldr     r0,=YakOAM_29
    str     r0,[r2,18h]
    mov     r0,0h
    strb    r0,[r2,1Ch]
    strh    r4,[r2,16h]
    ldr     r0,=0xFFE0
    strh    r0,[r2,0Ah]
    add     r0,14h
    strh    r0,[r2,0Eh]
    mov     r0,0Ch
    strh    r0,[r2,10h]
    ;mov     r0,9Fh
    ;lsl     r0,r0,1h			
    ;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
    b       @@Return
    .pool
@@CheckPlaySound:
    ;mov     r0,0Fh
    ;and     r1,r0
    ;cmp     r1,0h
    ;bne     @@Return
    ;ldr     r0,=0x13D
    ;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
.pool

ThirdShrinkAI:					;pose 4h, nearly identical to above functon
    push    r4-r7,r14
    ldr     r3,=CurrSpriteData
    mov     r6,r3
    add     r6,2Ch
    ldrb    r2,[r6]
    ldr     r5,=FireballTable
    lsl     r0,r2,1h
    add     r0,r0,r5
    ldrh    r4,[r0]
    mov     r7,0h
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0
    bne     @@CheckTimer
    ldrh    r4,[r5]
    mov     r2,0h
@@CheckTimer:
    add     r0,r2,1h
    strb    r0,[r6]
    ldrh    r0,[r3,4h]
    add     r0,r0,r4
    strh    r0,[r3,4h]
    mov     r2,r3
    add     r2,2Eh
    ldrb    r0,[r2]
    sub     r0,1h
    strb    r0,[r2]
    cmp     r0,0h
    bne     @@CheckPlaySound
    mov     r0,3Ch
    strb    r0,[r2]				;3C to timer
    mov     r1,r3
    add     r1,24h
    mov     r0,5h				;pose 5
    strb    r0,[r1]
@@CheckPlaySound:
    ;ldrb    r1,[r2]
    ;mov     r0,0Fh
    ;and     r0,r1
    ;cmp     r0,0h
    ;bne     @@Return
    ;mov     r0,9Fh
    ;lsl     r0,r0,1h
    ;ldr	r3,=PlaySound + 1
	;bl		WrapperR3
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
.pool

KillFireAI:					;pose 5h 
    push    r7,r14
	add		sp,-8h
    ldr     r0,=CurrSpriteData
    mov     r1,r0
    add     r1,2Eh
    ldrb    r3,[r1]
    mov     r2,r0
    cmp     r3,1Dh			;checks if timer is above 1Dh
    bhi     @@CheckTimer
    mov     r1,r2
    add     r1,26h
    mov     r0,1h
    strb    r0,[r1]			;no longer interacts with Samus
    and     r0,r3
    cmp     r0,0h
    bne     @@CheckTimer
    ldrh    r0,[r2]
    mov     r1,4h
    eor     r0,r1
    strh    r0,[r2]			;causes sprite to flicker
@@CheckTimer:
    mov     r1,r2
    add     r1,2Eh
    ldrb    r0,[r1]
    sub     r0,1h
    strb    r0,[r1]
    cmp     r0,0h					;decrements and checks timer
    bne     @@Return
    strh    r0,[r2]					;kills sprite when timer hits 0
	ldr		r3,=GetDropType + 1
	bl		WrapperR3
	cmp		r0,0h
	beq		@@Return
	ldr		r2,=CurrSpriteData
	ldrh	r1,[r2,4h]
	str		r1,[sp]
	ldrh	r3,[r2,2h]
	sub		r3,20h
	mov		r1,0h
	mov		r2,r1
	str		r1,[sp,4h]				;spawns drop
	ldr		r7,=SpawnNewPrimarySprite + 1
	bl		WrapperR7
@@Return:
	add		sp,8h
	pop		r7
    pop     r0
    bx      r0
.pool	
	
ProjectileAI:					;5D898
;.notice "YakProjectile"
;.notice tohex(.)
    push    r14
    ldr     r0,=CurrSpriteData
    add     r0,24h
    ldrb    r0,[r0]
    cmp     r0,7h				;checks pose
    bls     @@GetJump
    b       @@KillGunk
@@GetJump:
    lsl     r0,r0,2h
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
    .pool
@@JumpTable:
    .word @@Spawn,@@MoveFireball,@@ShrinkFire,@@ShrinkFire2
	.word @@ShrinkFire3,@@KillFire,@@MoveGunk,@@KillGunk
@@Spawn:
    bl      ProjectileSpawnAI
    b       @@Return
@@MoveGunk:
    bl      GunkMainAI
    b       @@Return
@@KillGunk:
    bl      KillGunk
    b       @@Return
@@MoveFireball:
    bl      MoveFireballAI
    b       @@Return
@@ShrinkFire:
    bl      FirstShrinkAI
    b       @@Return
@@ShrinkFire2:
    bl      SecondShrinkAI
    b       @@Return
@@ShrinkFire3:
    bl      ThirdShrinkAI
    b       @@Return
@@KillFire:
    bl      KillFireAI
@@Return:
    pop     r0
    bx      r0	
	