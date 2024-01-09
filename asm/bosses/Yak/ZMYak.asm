
;SpriteRam Replacements
;Old -> New
;2Bh -> 2Ah			rotation
;2Ch -> 2Bh			stun timer
;2Dh -> 2Dh			rounds left
;2Eh -> 2Eh			timer
;2Fh -> 2Fh			flag
;30h -> 35h			x speed for phase 2
;31h -> 2Ch			some kind of timer
;34h -> 32h			properties
;35h -> 34h			frozen palette offset

;.definelabel LockDoors,0x300007B
;.definelabel BG1XPos,0x30000E8
.definelabel SpriteDataSlot0,0x30001AC
;.definelabel CurrSpriteData,0x3000738
.definelabel FloorClipValue,0x30007F0
.definelabel ClipValue,0x30007F1
.definelabel YakuzaPalCounter,0x300070c
.definelabel StartSongFlag,0x300070c + 1
.definelabel GrabbedFlag,0x300070c + 2
.definelabel EscapeThreshold,0x300070c + 3
.definelabel EscapeValue,0x300070c + 4
.definelabel Phase1Flag,0x300070c + 5
;.definelabel SpriteRNG,0x300083C
;.definelabel Bit8Counter,0x3000C77
;.definelabel SamusData,0x30013D4
.definelabel ChangedInput,0x3001380
.definelabel ScrewAttackFlag,0x3001528
.definelabel Equipment,0x3001530
.definelabel SamusHitboxes,0x30015F6
.definelabel DMA3SourceAddress,0x40000D4

;.definelabel PlaySound,0x8002A18

;.definelabel PlaySong,0x80039F4
.definelabel InitializeSecondarySprite,0x800E258
;.definelabel SpawnNewPrimarySprite,0x800E31C
.definelabel DamageSamus,0x800E634
.definelabel CheckSamusTouchSprite,0x800E6F8
.definelabel CheckHitFloor,0x800F47C
.definelabel CheckClip,0x800F688
;.definelabel CheckEndSpriteAnimation,0x800FBC8
.definelabel CheckNearEndAnimation,0x800FC00
;.definelabel GetDropType,0x8010EEC
;.definelabel SpriteDead,0x8011084
.definelabel SetGFXEffect,0x80540EC
.definelabel VerticalScreenShake,0x8055344
.definelabel HorizontalScreenShake,0x8055378
;.definelabel EventFunctions,0x80608BC
;.definelabel Division,0x808AC34

;need to find or recreate

;WrapperR3:
;	bx		r3
WrapperR7:
	bx		r7
WrapperR12:
	bx		r12

StoreOAMToLegSprite:			;r0 is OAM
	ldr		r3,=SpriteDataSlot0
	mov		r2,38h
	mov		r1,2h				;this must be slot of leg secondary sprite
	mul		r1,r2
	add		r3,r3,r1
	ldr		r1,[r3,18h]
	cmp		r1,r0				;checks if OAM is already set
	beq		@@Return
	str		r0,[r3,18h]
	mov		r0,0h
	strb	r0,[r3,1Ch]
	strh	r0,[r3,16h]
@@Return:
	bx		r14
.pool

CheckGrabAI:
	push	r4-r7,r14
	add		sp,-10h
	ldr     r4,=CurrSpriteData
    ldrh    r0,[r4,2h]
    add     r0,90h
    ldrh    r1,[r4,4h]
    ldr     r3,=CheckClip + 1
	bl		WrapperR3
	ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h						;used to prevent grab right after a slam (clipping issues possible otherwise)
	bne		@@Return
	ldr		r5,=SamusData
	ldrh	r0,[r4,2h]					;all setup for function call
	ldrh	r1,[r4,4h]
	ldrh	r2,[r4,0Ah]
	add		r2,r2,r0
	lsl		r2,r2,10h
	lsr		r2,r2,10h
	str		r2,[sp]
	ldrh	r2,[r4,0Ch]
	add		r2,r2,r0
	lsl		r2,r2,10h
	lsr		r2,r2,10h
	str		r2,[sp,4h]
	ldrh	r2,[r4,0Eh]
	add		r2,r2,r1
	lsl		r2,r2,10h
	lsr		r2,r2,10h
	str		r2,[sp,8h]
	ldrh	r2,[r4,10h]
	add		r2,r2,r1
	lsl		r2,r2,10h
	lsr		r2,r2,10h
	str		r2,[sp,0Ch]
	ldrh	r1,[r5,12h]
	ldrh	r2,[r5,14h]
	ldr		r0,=SamusHitboxes
	ldrh	r3,[r0,2h]
	add		r3,r3,r2
	lsl		r3,r3,10h
	lsr		r3,r3,10h
	mov		r6,r3
	ldrh	r3,[r0,6h]
	add		r3,r3,r2
	lsl		r3,r3,10h
	lsr		r3,r3,10h
	mov		r7,r3
	ldrh	r3,[r0]
	add		r3,r3,r1
	lsl		r3,r3,10h
	lsr		r3,r3,10h
	mov		r2,r3
	ldrh	r3,[r0,4h]
	add		r3,r3,r1
	lsl		r3,r3,10h
	lsr		r3,r3,10h
	mov		r0,r6
	mov		r1,r7
	ldr		r7,=CheckSamusTouchSprite + 1
	bl		WrapperR7
	cmp		r0,0h
	beq		@@Return
	ldr		r0,=GrabbedFlag
	mov		r1,1h
	strb	r1,[r0]
	add		r4,24h
	mov		r0,27h
	strb	r0,[r4]
@@Return:
	add		sp,10h
	pop		r4-r7
	pop		r0
	bx		r0
.pool

CheckEscapeGrab:
	ldr		r0,=ChangedInput
	ldrh	r0,[r0]
	mov		r1,30h
	and		r0,r1
	cmp		r0,0h					;only checks for left and right inputs
	beq		@@Return
	ldr		r0,=EscapeValue
	ldrb	r1,[r0]
	add		r1,4h
	strb	r1,[r0]
	ldr		r2,=EscapeThreshold
	ldrb	r2,[r2]
	cmp		r1,r2
	bcc		@@Return
	mov		r1,0h
	strb	r1,[r0]					;0's escape value
	ldr		r0,=GrabbedFlag			;0's grab flag, Samus escaped
	strb	r1,[r0]
@@Return:
	bx		r14
.pool

CheckDamageSamus:
	push	r14
	ldr		r0,=Bit8Counter
	ldrb	r0,[r0]
	mov		r1,0Fh
	and		r0,r1
	cmp		r0,0h
	bne		@@Return
	ldr		r0,=Equipment
	ldrh	r1,[r0,6h]
	cmp		r1,7h
	bhi		@@DealDamge
	mov		r1,0h
	strh	r1,[r0,6h]				;kills Samus if health is less than damage being dealt
	b		@@Return
@@DealDamge:
	sub		r1,7h
	strh	r1,[r0,6h]
	ldr		r0,=SamusData
	mov		r1,8h
	strb	r1,[r0,6h]				;purple flash timer
	mov		r0,80h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@Return:
	pop		r0
	bx		r0
.pool

SetXDirectionTowardsSamus:
	ldr     r0,=SamusData
	ldr		r2,=CurrSpriteData
    ldrh    r0,[r0,12h]
    ldrh    r1,[r2,4h]				;checks which side of Yak Samus is on
    cmp     r0,r1
    bcs     @@SetMoveRightFlag
    ldrh    r1,[r2]
    ldr     r0,=0xFDFF
    and     r0,r1					;removes 200h flag
    b       @@Return
.pool
@@SetMoveRightFlag:
    ldrh    r1,[r2]
    mov     r3,80h
    lsl     r3,r3,2h
    mov     r0,r3
    orr     r0,r1					;sets 200h flag
@@Return:
    strh    r0,[r2]
	bx		r14
.pool

CheckChangePal:								;checks and modifies Yak's palette based on health
    push    r4-r7,r14
    mov     r6,0h
    ldr     r0,=CurrSpriteData
    ldrh    r5,[r0,14h]					;current health
    ldr     r2,=PrimarySpriteStats
    ldrb    r1,[r0,1Dh]
    lsl     r0,r1,3h
    add     r0,r0,r1
    lsl     r0,r0,1h
    add     r0,r0,r2
    ldrh    r0,[r0]						;max health
    ldr     r4,=YakuzaPalCounter				;specifies palette Yakuza should be
    ldrb    r1,[r4]
    cmp     r1,0h
    beq     @@CheckTwoThirdsHealth
    cmp     r1,1h
    beq     @@CheckOneFourthHealth
    b       @@CheckChangePalette
    .pool
@@CheckTwoThirdsHealth:
    lsl     r0,r0,1h
    mov     r1,3h
	ldr		r3,=Division + 1
	bl		WrapperR3					
    cmp     r5,r0						;checks if at 2/3rds of max health
    bgt     @@CheckChangePalette
    ldr     r7,=YakPal + 40h			;purplish palette
    mov     r0,1h
    strb    r0,[r4]							
    b       @@ChangePallete
    .pool
@@CheckOneFourthHealth:
    lsr     r0,r0,2h
    cmp     r5,r0						;checks if at 1/4th max health
    bhi     @@CheckChangePalette
    ldr     r7,=YakPal + 60h			;red palette
    mov     r0,2h
    strb    r0,[r4]
    mov     r6,1h						;flag to change palette
@@CheckChangePalette:
    cmp     r6,0h
    beq     @@Return
@@ChangePallete:
    ldr     r1,=DMA3SourceAddress
    str     r7,[r1]
    ldr     r0,=0x5000300
    str     r0,[r1,4h]
    ldr     r0,=0x80000010
    str     r0,[r1,8h]
    ldr     r0,[r1,8h]
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
.pool

ForceGrabbedPosition:								;nearly converted
    push    r14
    ldr     r2,=SamusData
	ldr		r1,=GrabbedFlag
    ldrb    r0,[r1]						
    cmp     r0,1h						;checks if Samus is grabbed by Yakuza
    beq     @@Grabbed
    mov     r0,0h
    b       @@Return
    .pool
@@Grabbed:
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    add     r1,0C0h
    strh    r1,[r2,14h]					;forces Samus to be 3 blocks under Yakuza
    ldrh    r0,[r0,4h]
    strh    r0,[r2,12h]					;matches Samus' X to Yakuza's X
	mov		r0,4h
	strb	r0,[r2,2h]					;forces Samus to look downwards
	mov		r0,8h
	strb	r0,[r2]
	mov		r0,0h
	strb	r0,[r2,1Dh]
	strb	r0,[r2,1Ch]
	ldr		r2,=ScrewAttackFlag
	strb	r0,[r2]
	strb	r0,[r2,1h]
	strb	r0,[r2,2h]					;reseting several animation related values
    bl      CheckDamageSamus
    mov     r0,1h
@@Return:
    pop     r1
    bx      r1
.pool

CheckHitRightWall:							;converted
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r0,[r2,2h]
    ldrh    r1,[r2,4h]
	add		r1,40h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
	ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h						
    bne     @@True
    mov     r0,0h
    b       @@Return
.pool
@@True:
    mov     r0,1h
@@Return:
    pop     r1
    bx      r1
	
CheckHitLeftWall:						;converted
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r0,[r2,2h]
    ldrh    r1,[r2,4h]
	sub		r1,40h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
	ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h						
    bne     @@True				;checks peak left X position (left wall)
    mov     r0,0h
    b       @@Return
    .pool
@@True:
    mov     r0,1h
@@Return:
    pop     r1
    bx      r1
	
CheckMinYPos:						;converted
    push    r14
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    ldr     r0,=73Eh
    cmp     r1,r0				;checks if Yakuza has hit lowest Y position for wall-crawling phase
    bhi     @@True				;techically checks for highest Y value, but minimum relative to floor
    mov     r0,0h
    b       @@Return
    .pool
@@True:
    mov     r0,1h
@@Return:
    pop     r1
    bx      r1
	
CheckMaxYPos:						;nearly converted
    push    r14
    ldr     r0,=GrabbedFlag
    ldrb    r0,[r0]					
    cmp     r0,1h					;checks if Samus is grabbed by Yakuza
    bne     @@CheckCrawlPeak
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    ldr     r0,=3FFh				;peak Y position for when Yakuza grabs Samus
    b       @@CompareValues			;techically checks for lowest Y value, but maximum relative to floor
    .pool
@@CheckCrawlPeak:
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0,2h]
    ldr     r0,=5FFh				;peak Y position for crawling
@@CompareValues:
    cmp     r1,r0
    bhi     @@True
    mov     r0,1h
    b       @@Return
    .pool
@@True:
    mov     r0,0h
@@Return:
    pop     r1
    bx      r1
	
ChangeXPos:							;moves Yakuza's X position
    push    r4,r5,r14
    mov		r5,r0
    ldr     r4,=CurrSpriteData
    ldrh    r1,[r4]
    mov     r0,80h
    lsl     r0,r0,2h
    and     r0,r1
    cmp     r0,0h					;checking if moving right, 200h flag
    beq     @@MoveLeft
    bl      CheckHitRightWall
    mov		r2,r0
    cmp     r2,0h
    bne     @@Return
    ldrh    r0,[r4,4h]
    add     r0,r5,r0
    b       @@ChangeX
.pool
@@MoveLeft:
    bl      CheckHitLeftWall
    mov		r2,r0
    cmp     r2,0h
    bne     @@Return
    ldrh    r0,[r4,4h]
    sub     r0,r0,r5
@@ChangeX:
    strh    r0,[r4,4h]		
@@Return:
    mov     r0,r2
    pop     r4,r5
    pop     r1
    bx      r1
.pool

ChangeYPos:			;moves Yakuza's Y position
    push    r4-r5,r14
    mov		r5,r0
    ldr     r4,=CurrSpriteData
    ldrh    r1,[r4]
    mov     r0,80h
    lsl     r0,r0,3h
    and     r0,r1
    cmp     r0,0h				;checks if yakuza is moving downward, 400h flag
    beq     @@CheckPeakY
    bl      CheckMinYPos
    mov		r2,r0
    cmp     r2,0h				;true if Yakuza is close to floor of vanilla room
    bne     @@FlipVertDirection
    ldrh    r0,[r4,2h]
    add     r0,r5,r0
    b       @@ChangePosition
 .pool
@@FlipVertDirection:
    ldrh    r1,[r4]
    ldr     r0,=0FBFFh
    and     r0,r1
    strh    r0,[r4]				;removes 400h flag, flipping vertical direction
    mov     r2,0h
    b       @@Return
    .pool
@@CheckPeakY:
    bl      CheckMaxYPos
    mov		r2,r0
    cmp     r2,0h				;true if yakuza meets on of vertical hight thresholds
    bne     @@Return
    ldrh    r0,[r4,2h]
    sub     r0,r0,r5
@@ChangePosition:
    strh    r0,[r4,2h]
@@Return:
    mov     r0,r2
    pop     r4-r5
    pop     r1
    bx      r1
.pool

StartGrabAI:							;pose 27
    push    r14
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_0		;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    mov     r2,0h
    strb    r0,[r1,1Ch]
    mov		r3,r1
    add     r1,24h
    mov     r0,28h
    strb    r0,[r1]					;sets pose 28, Grab Samus pose
    mov     r0,r3
    add     r0,2Fh
    strb    r2,[r0]					;flag used in next pose
    ldrh    r1,[r3]
    ldr     r0,=0xFBFF
    and     r0,r1
    strh    r0,[r3]					;removes 400h flag (moving downward flag)
    ldr     r0,=0x1CB
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
	ldr		r0,=SpriteRNG
	ldrb	r0,[r0]
	lsr		r0,r0,2h
	add		r0,14h
	lsl		r0,r0,2h				;min of 20 inputs, max of 27 to escape
	ldr		r1,=EscapeThreshold
	strb	r0,[r1]
	ldr		r0,=YakOAM_16
	bl		StoreOAMToLegSprite
    pop     r0
    bx      r0
.pool

GrabSamusAI:						;pose 28
    push    r4-r6,r14
    bl      ForceGrabbedPosition
    cmp     r0,0h				;returns 0 if Samus is not grabbed
    bne     @@Grabbed
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,2Fh				;sets pose 2Fh
    strb    r1,[r0]
    b       @@Return
    .pool
@@Grabbed:
    ldr     r6,=CurrSpriteData
    mov     r5,r6
    add     r5,2Fh
    ldrb    r4,[r5]					;flag set after grab is complete, then reset after second animation finishes
    cmp     r4,0h
    bne     @@CheckStartCrawlingUpward
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h					;checks if grabbing animation is complete
    beq     @@Return
    ldr     r1,=YakOAM_1			;OAM
    str     r1,[r6,18h]
    strh    r4,[r6,16h]
    strb    r4,[r6,1Ch]
	ldr		r0,=YakOAM_20
	bl		StoreOAMToLegSprite
    ldrb    r0,[r5]
    add     r0,1h
    b       @@Store
    .pool
@@CheckStartCrawlingUpward:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h					;checks if start of crawling animation is done
    beq     @@Return
	ldr		r0,=YakOAM_21
	bl		StoreOAMToLegSprite
    mov     r1,r6
    add     r1,24h
    mov     r2,0h
    mov     r0,2Ah				;sets pose 2Ah, crawling upward with Samus
    strb    r0,[r1]
    ldr     r0,=YakOAM_0		;OAM
    str     r0,[r6,18h]
    strh    r2,[r1,16h]
    strb    r2,[r1,1Ch]
	mov		r0,0h
@@Store:
    strb    r0,[r5]
@@Return:
    pop     r4-r6
    pop     r0
    bx      r0
.pool

CarrySamusUpwards:								;pose 2A
    push    r4,r14
    bl      ForceGrabbedPosition
    cmp     r0,0h						;0 if Samus escaped grab
    bne     @@StillGrabbed
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,2Fh
    strb    r1,[r0]						;sets pose 2Fh
    b       @@Return
.pool
@@StillGrabbed:
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,2Fh
    ldrb    r0,[r0]
    cmp     r0,0h						;1 if Yakuza reached maximum height 
    bne     @@PrepareSlam
    ldrh    r0,[r4,16h]
    cmp     r0,0h
    bne     @@MoveYakUpward
    ldrb    r0,[r4,1Ch]
    cmp     r0,1h						;couple checks to play sound on proper animation frame
    bne     @@MoveYakUpward
    ldr		r0,=18Fh					;crawling sound
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@MoveYakUpward:
    mov     r0,4h						;value to move Yakuza
    bl      ChangeYPos
    cmp     r0,0h						;returns 1 if at max height 
    beq     @@Return
    ldr     r0,=YakOAM_1				;OAM
    str     r0,[r4,18h]
    mov     r0,0h
    strh    r0,[r4,16h]
    strb    r0,[r4,1Ch]
    mov		r1,r4
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]						;flag for when Yakuza reached max height
	ldr		r0,=YakOAM_22
	bl		StoreOAMToLegSprite
    b       @@Return
.pool
@@PrepareSlam:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    mov     r1,r4
    add     r1,24h
    mov     r2,0h
    mov     r0,2Ch
    strb    r0,[r1]						;sets pose 2Ch, slamming down
    ldr     r1,=YakOAM_1				;OAM
    str     r1,[r4,18h]
    strh    r2,[r0,16h]
    strb    r2,[r0,1Ch]
    mov     r1,r4
    add     r1,2Eh
    mov     r0,3Ch						;timer value
    strb    r0,[r1]
    ldrh    r1,[r4]
    mov     r2,80h
    lsl     r2,r2,3h
    mov     r0,r2
    orr     r0,r1
    strh    r0,[r4]						;sets 400h flag, moving downward
	ldr		r0,=YakOAM_19
	bl		StoreOAMToLegSprite
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool

PreSlamAI:								;pose 2Ch
    push    r14
    bl      ForceGrabbedPosition
    cmp     r0,0h						;0 if Samus escaped grab
    bne     @@DecreaseTimer
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,2Fh
    strb    r1,[r0]						;sets pose 2Fh
    b       @@Return
.pool
@@DecreaseTimer:
    ldr     r2,=CurrSpriteData
    mov     r1,r2
    add     r1,2Eh
    ldrb    r0,[r1]
    sub     r0,1h
    strb    r0,[r1]
    mov		r3,r0
    cmp     r3,0h
    bne     @@Return
    mov     r0,r2
    add     r0,24h
    mov     r1,2Eh
    strb    r1,[r0]						;set pose 2Eh, Slam
    add     r0,0Dh
    strb    r3,[r0]
@@Return:
    pop     r0
    bx      r0
.pool

SlamAI:								;pose 2Eh
    push    r4-r7,r14
    bl      ForceGrabbedPosition
    mov		r6,r0
    ldr     r0,=CurrSpriteData
    mov     r5,r0
    add     r5,2Eh
    ldrb    r2,[r5]						;acceleration index
    ldr     r3,=AccelerationTable		;table for falling acceleration?
    lsl     r0,r2,1h
    add     r0,r0,r3
    ldrh    r4,[r0]
    mov     r7,0h
    ldsh    r1,[r0,r7]
    ldr     r0,=0x7FFF
    cmp     r1,r0						;true at max velocity
    bne     @@ChangeY
    sub     r0,r2,1h
    lsl     r0,r0,1h
    add     r0,r0,r3
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2,2h]
    ldrh    r0,[r0]
    add     r1,r1,r0
    strh    r1,[r2,2h]					;changing Y position based on table
    b       @@CheckDamageSamus
    .pool
@@ChangeY:
    add     r0,r2,1h
    strb    r0,[r5]
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,2h]
    add     r0,r0,r4
    strh    r0,[r1,2h]
@@CheckDamageSamus:
    cmp     r6,0h						;true if Samus escaped Yakuza's Clutches
    beq     @@CheckYakuzaHitGround
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,2h]
    add     r0,0C0h						;checks 3 blocks below sprite (where Samus is)
    ldrh    r1,[r1,4h]					;only checks this if Samus is in grasp
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h
    beq     @@CheckYakuzaHitGround
	mov		r0,1h
	ldr		r1,=CurrSpriteData
	mov		r2,0h
	ldr		r3,=DamageSamus + 1
	bl		WrapperR3					;damage from slaming into the ground
	ldr		r0,=GrabbedFlag
	mov		r1,0h
	strb	r1,[r0]
	strb	r1,[r0,2h]					;zero's escape value and grabbed flag
@@CheckYakuzaHitGround:
    ldr     r5,=CurrSpriteData
    ldrh    r0,[r5,2h]
    add     r0,48h
    ldrh    r1,[r5,4h]
	ldr		r3,=CheckHitFloor + 1
	bl		WrapperR3
    mov     r4,r0						;returns Y value of top of block
    ldr     r0,=FloorClipValue			
    ldrb    r1,[r0]
    mov     r0,0Fh
    and     r0,r1
    cmp     r0,0h					;false if hit solid tile
    beq     @@Return
    mov     r0,r4
    sub     r0,48h					;makes yakuza about 1 block above ground
    strh    r0,[r5,2h]
    mov		r0,r5
    add     r0,24h
    mov     r1,2Fh
    strb    r1,[r0]					;sets pose 2Fh
    mov     r0,3Ch
    mov     r1,81h
	ldr		r3,=VerticalScreenShake + 1
	bl		WrapperR3
    ldrh    r1,[r5,4h]
    mov     r0,r4
    mov     r2,0Ah					;effect ID
	ldr		r3,=SetGFXEffect + 1
	bl		WrapperR3
    mov     r0,r4
    add     r0,3Ch
    ldrh    r1,[r5,4h]
    mov     r2,0Ah
	ldr		r3,=SetGFXEffect + 1
	bl		WrapperR3
    mov     r0,0A7h					;hitting ground sound
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@Return:
    pop     r4-r7
    pop     r0
    bx      r0
.pool

LetGoAI:							;pose 2F, lets go of Samus after being grabbed
	push	r14
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_0			;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,24h					;sets pose 30h
    mov     r0,30h
    strb    r0,[r1]
	ldr		r0,=YakOAM_17
	bl		StoreOAMToLegSprite
    pop		r0
	bx		r0
.pool

ResetAfterGrab:							;pose 30, resetting after Grabbing Samus
    push    r14
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h						;watis for grab release animation to finish
    beq     @@Return
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,9h
    strb    r1,[r0]					;sets pose 9
@@Return:
    pop     r0
    bx      r0
.pool

AnimationAfterGrab:					;pose 9, sets the short crawl animation after a grab
	push	r14
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_0			;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,24h
    mov     r0,0Ah
    strb    r0,[r1]					;sets pose Ah
	ldr		r0,=YakOAM_12
	bl		StoreOAMToLegSprite
	pop		r0
	bx		r0
.pool

SetGrabState2:					;pose A, allows them to grab Samus
    push    r14
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,1h					;sets pose 1
    strb    r1,[r0]
    bl      SetXDirectionTowardsSamus
@@Return:
    pop     r0
    bx      r0
.pool

YakSpawnAI:					;pose 0
    push    r4-r7,r14
    add     sp,-0Ch
    mov		r0,3h
	bl		SetnCheckEvent
    mov		r6,r0		
    cmp     r6,0h			;checking if Yakuza event is already set
    beq     @@Spawn
    ldr     r1,=CurrSpriteData
    mov     r0,0h
    strh    r0,[r1]			;kills sprite if true
    b       @Return1
.pool
@@Spawn:
    ldr     r0,=YakuzaPalCounter		;specifies palette Yak should be
    str     r6,[r0]			;0's values for yakuza
	strb	r6,[r0,4h]					;zero's escape value
	mov		r3,1h
	strb	r3,[r0,5h]					;sets phase 1 flag
	ldr		r0,=LockDoors
	mov		r1,1h
	strb	r1,[r0]						;locks doors
    ldr     r4,=CurrSpriteData
    ldr     r1,=-200h
    mov     r0,r1
    ldrh    r2,[r4,2h]
    add     r0,r0,r2
    mov     r5,0h
    mov     r1,r4
    strh    r0,[r1,2h]		;Yakuza Y position
    ldrh    r0,[r1,4h]		;Yakuza X position
    mov     r0,r4
    add     r0,27h			;sprite draw size
    mov     r1,24h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]
    add     r0,1h
    strb    r1,[r0]
    ldr     r0,=0FFC0h
    strh    r0,[r4,0Ah]		;top hitbox
    mov     r0,60h
    strh    r0,[r4,0Ch]		;bottom hitbox
    ldr     r0,=0FFB8h
    strh    r0,[r4,0Eh]		;left hitbox
    mov     r0,48h
    strh    r0,[r4,10h]		;right hitbox
	mov		r2,r4
    add     r2,32h			;sprite properties
    strb    r6,[r2]			
    mov     r1,r4
    add     r1,22h			;draw order
    mov     r0,0Ch
    strb    r0,[r1]
	strb	r3,[r4,1Eh]		;needed as secondary sprite AI makes use of this
    ldr     r2,=PrimarySpriteStats
    ldrb    r1,[r4,1Dh]		;sprite ID
    lsl     r0,r1,3h
    add     r0,r0,r1
    lsl     r0,r0,1h
    add     r0,r0,r2
    ldrh    r0,[r0]
    strh    r0,[r4,14h]		;stores health
    strh    r3,[r4,0Ch]
    ldr     r0,=YakOAM_2 	;OAM?
    str     r0,[r4,18h]
    strh    r5,[r4,16h]
    strb    r6,[r4,1Ch]
	mov		r1,r4
    add     r1,25h
    mov     r0,0h
    strb    r0,[r1]			;0 to Samus Collision
    ldrh    r0,[r4]
    ldr		r1,=8404h		
    orr     r0,r1
    strh    r0,[r4]			;8404h to sprite status
    mov     r0,r4
    add     r0,2Fh
    strb    r5,[r0]			;0 to rounds left (causes fire attack at the start)
	mov		r1,r4
    add     r1,24h
    mov     r0,37h
    strb    r0,[r1]			;set pose 37 (Waiting before battle) 
    mov     r5,r4
    add     r5,23h
    ldrb    r3,[r5]			;arguments for secondary sprite spawn
    ldrh    r0,[r4,2h]
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    str     r6,[sp,8h]
YakuzaLeg1:
    mov     r0,LegID			;sprite 28h, Yakuza legs
    mov     r1,0h
    mov     r2,0h
	ldr		r7,=InitializeSecondarySprite + 1
    bl      WrapperR7
    ldrb    r3,[r5]
    ldrh    r0,[r4,2h]
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    str     r6,[sp,8h]
YakuzaLeg2:
    mov     r0,LegID			;sprite 28h, Yakuza legs
    mov     r1,2h
    mov     r2,0h
    bl      WrapperR7
@Return1:
    add     sp,0Ch
    pop     r4-r7
    pop     r0
    bx      r0
.pool

WaitAI:						;pose 37
    push    r14
    ldr     r0,=SamusData
    ldrh    r1,[r0,14h]		
    ldr     r0,=6FFh
    cmp     r1,r0			;checks Samus' Y position to start battle
    bls     @@Return
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,24h
    mov     r0,38h
    strb    r0,[r2]		;sets pose 38, Pre-Battle Pose
    add     r1,2Eh
    mov     r0,3Ch
    strb    r0,[r1]		;timer to start battle
@@Return:
    pop     r0
    bx      r0
.pool

Pre_BattleAI:				;pose 38
    push    r14
    ldr     r2,=CurrSpriteData
    mov     r1,r2
    add     r1,2Eh
    ldrb    r0,[r1]
    sub     r0,1h
    strb    r0,[r1]
    cmp     r0,0h			;reducing timer to start battle
    bne     @@Return
    sub     r1,0Ah
    mov     r0,7h
    strb    r0,[r1]			;stores pose 7
	mov		r0,40h
	add		r1,0Eh
	ldrb	r3,[r1]
	orr		r0,r3
	strb	r0,[r1]			;makes immune to projectiles
	strb	r0,[r1]
    ldrh    r1,[r2]
    ldr     r0,=07FFBh
    and     r0,r1
    strh    r0,[r2]			;removes 8004h flags from status
    mov     r0,3Ch
    mov     r1,81h
	ldr		r3,=HorizontalScreenShake + 1
	bl		WrapperR3
    mov     r0,3Ch
    mov     r1,81h
	ldr		r3,=VerticalScreenShake + 1
	bl		WrapperR3
    ldr     r1,=StartSongFlag
    mov     r0,1h
    strb    r0,[r1]			;flag used later to set boss music
    mov		r0,0C4h			;rubbling sound
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@Return:
    pop     r0
    bx      r0
.pool

SetGrabState:					;pose 7, allows them to grab Samus
	push	r14
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_0		;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,24h
	strb	r0,[r1,1h]		;0 to Samus collision
    mov     r0,8h
    strb    r0,[r1]			;stores pose 8	
	ldr		r0,=YakOAM_12
	bl		StoreOAMToLegSprite	
	pop		r0
    bx      r0
.pool

CheckEndRound:					;pose 8
    push    r14
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h			;0 if animation is not over
    beq     @@Return
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,2Dh			;rounds left
    ldrb    r0,[r2]
    cmp     r0,0h			
    beq     @@SetFlameAttack
    sub     r0,1h
    strb    r0,[r2]			;reduces rounds left by 1
    add     r1,24h
    mov     r0,1h
    strb    r0,[r1]			;sets pose 1
    bl      SetXDirectionTowardsSamus		;changes Yakuza's sprite status regarding X direction to go toward Samus
    b       @@Return
.pool
@@SetFlameAttack:
    add     r1,24h
    mov     r0,31h			;sets pose 31h (about to shoot fireballs)
    strb    r0,[r1]
@@Return:
    pop     r0
    bx      r0
	
SetPauseAnimation: 					;pose 1 sets animation for short pause between rounds
	push	r14
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_1		;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,24h
    mov     r0,2h				;sets pose 2, PreCrawl
    strb    r0,[r1]
	ldr		r0,=YakOAM_13
	bl		StoreOAMToLegSprite
    pop		r0
	bx		r0
.pool

PreCrawlAI:						;pose 2, animation right before wall-crawling
    push    r14
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_0		;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,24h
    mov     r0,18h
    strb    r0,[r1]				;set pose 18h, wall crawl pose
	ldr		r0,=YakOAM_14
	bl		StoreOAMToLegSprite
@@Return:
    pop     r0
    bx      r0
.pool

WallCrawlAI:					;pose 18 wall-crawling
    push    r4,r14
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,16h]
    cmp     r0,0h
    bne     @@BeginMovement
    ldrb    r0,[r1,1Ch]
    cmp     r0,1h				;several checks to play sound on certain animation and frame
    bne     @@BeginMovement
    ldr		r0,=18Fh
	ldr		r3,=PlaySound + 1
	bl		WrapperR3			;sound that plays when crawling
@@BeginMovement:
    mov     r0,3h
    bl      ChangeYPos			;returns 1 if Max Y position is met
    cmp     r0,0h					
    beq     @@ContinueMovement
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r3,80h
    lsl     r3,r3,3h
    mov     r0,r3
    mov     r3,0h
    mov     r4,0h
    orr     r0,r1
    strh    r0,[r2]
    ldr     r1,=YakOAM_1		;OAM
    str     r1,[r2,18h]
    strh    r3,[r0,16h]
    strb    r4,[r0,1Ch]
    add     r2,24h
    mov     r0,1Ah
    strb    r0,[r2]				;sets pose 1Ah
	ldr		r0,=YakOAM_15
	bl		StoreOAMToLegSprite
    b       @@Return
.pool
@@ContinueMovement:
    mov     r0,8h
    bl      ChangeXPos			;returns 1 if direction needs to change
    cmp     r0,0h
    beq     @@Return
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r0]
    mov     r3,80h
    lsl     r3,r3,2h
    mov     r2,r3
    eor     r1,r2
    strh    r1,[r0]				;toggles 200h flag, horizontal direction
@@Return:
    pop     r4
    pop     r0
    bx      r0
.pool

StartEndRound:						;pose 1A
    push    r14
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @@Return
    ldr     r0,=CurrSpriteData
    add     r0,24h
    mov     r1,7h
    strb    r1,[r0]			;sets pose 7
@@Return:
    pop     r0
    bx      r0
.pool

Pre_FireballAI:							;pose 31
    push    r14
    ldr     r0,=CurrSpriteData
    ldr     r1,=YakOAM_2			;OAM
    str     r1,[r0,18h]
    mov     r2,0h
    strh    r2,[r0,16h]
    strb    r2,[r0,1Ch]
    mov     r3,r0
    add     r0,2Eh
    strb    r2,[r0]					;zeros timer
    strb    r2,[r0,1h]				;zeros a flag used in next pose			
    mov     r1,r3
    add     r1,24h
    mov     r0,32h					;sets pose 32
    strb    r0,[r1]
    add     r1,1h
    mov     r0,4h
    strb    r0,[r1]					;stores 4 to Samus collision (hurts samus normally)
    mov     r0,40h
    strh    r0,[r3,0Ch]				;bottom hitbox
    ldr     r0,=0xFFDC
    strh    r0,[r3,0Eh]				;left hitbox
    mov     r0,24h
    strh    r0,[r3,10h]				;right hitbox
    mov     r2,r3
    add     r2,32h
    ldrb    r1,[r2]
    mov     r0,0BFh					;removes 40h flag from properties, makes Yakuza Vulnerable 
    and     r0,r1
    strb    r0,[r2]
    ldr     r0,=0x18D
	ldr		r3,=PlaySound + 1
	bl		WrapperR3				;opening mouth sound
    pop     r0
    bx      r0
.pool

ShootFireballAI:							;pose 32
    push    r4-r7,r14
    add     sp,-0Ch
    ldr     r1,=CurrSpriteData
    mov     r0,r1
    add     r0,2Fh					;determines the "stage" of shooting fireball process
    ldrb    r0,[r0]
    mov     r4,r1
    cmp     r0,6h
    bls     @@Continue
    b       @Return2
@@Continue:
    lsl     r0,r0,2h
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
.pool

@@JumpTable:
    .word @@OpeningMouth,@@OpeningMouth2,@@Charging,@@AboutToShoot
	.word @Post_Shot,@Deglow,@ClosingMouth
	
@@OpeningMouth:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h							;waits for opening mouth animation to finish
    bne     @@MouthOpened
    b       @Return2
@@MouthOpened:
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_6					;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]					;sets next phase of shooting fireballs
    mov     r0,9Ch
    lsl     r0,r0,1h				;second part of charging sound before fire is shot
    ;	ldr		r3,=PlaySound + 1
	;bl		WrapperR3
    b       @Return2
.pool

@@OpeningMouth2:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h				;waits for second part of opening mouth animation
    bne     @@StartGlow
    b       @Return2
@@StartGlow:
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_7			;OAM
    str     r0,[r1,18h]
    mov     r3,0h
    strh    r3,[r1,16h]
    strb    r0,[r1,1Ch]
    mov		r4,r1
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]					;sets next phase of shooting fireballs
    ldr     r0,=GlowTable			;table?
    ldrb    r0,[r0]
    sub     r0,8h
    lsl     r0,r0,5h
    ldr     r2,=DMA3SourceAddress
    ldr     r1,=MouthGlowPalettes	
    add     r0,r0,r1
    str     r0,[r2]
    ldr     r0,=0x5000320			;palette row that will be modified to create glow effect
    str     r0,[r2,4h]
    ldr     r0,=0x80000010
    str     r0,[r2,8h]
    ldr     r0,[r2,8h]
    mov     r0,r4
    add     r0,35h					
    strb    r3,[r0]
    mov     r1,r4
    add     r1,2Eh
    mov     r0,3h
    b       @StoreTimer
.pool

@@Charging:
    mov     r6,r4
    add     r6,2Eh
    ldrb    r0,[r6]
    sub     r0,1h
    strb    r0,[r6]
    mov		r2,r0
    cmp     r2,0h				;decrements timer 
    beq     @@CheckCounter
    b       @Return2
@@CheckCounter:
    mov     r5,r4
    add     r5,35h
    ldrb    r0,[r5]				;counts number of times glow is changed
    cmp     r0,10h
    bhi     @@NextPhase
    add     r0,1h
    strb    r0,[r5]				;increases counter
    mov     r0,3h
    strb    r0,[r6]				;3 to timer
    ldr     r1,=GlowTable
    ldrb    r0,[r5]
    b       @ModifyGlow
.pool
@@NextPhase:
    mov		r1,r4
    ldr     r0,=YakOAM_8		;OAM
    str     r0,[r1,18h]
    strh    r2,[r1,16h]
    mov     r3,0h
    strb    r2,[r1,1Ch]
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]
    ldr     r0,=GlowTable2
    ldrb    r0,[r0]
    sub     r0,8h
    lsl     r0,r0,5h
    ldr     r2,=DMA3SourceAddress
    ldr     r1,=MouthGlowPalettes
    add     r0,r0,r1
    str     r0,[r2]
    ldr     r0,=0x5000320
    str     r0,[r2,4h]
    ldr     r0,=0x80000010
    str     r0,[r2,8h]
    ldr     r0,[r2,8h]
    strb    r3,[r5]
    mov     r0,4h
    strb    r0,[r6]
    b       @Return2
.pool
@@AboutToShoot:
    mov     r1,r4
    add     r1,2Eh
    ldrb    r0,[r1]
    sub     r0,1h
    strb    r0,[r1]
    mov		r5,r0
    cmp     r5,0h					;checks and decrements timer
    beq     @@CheckCounter2
    b       @Return2
@@CheckCounter2:
    mov     r2,r4
    add     r2,35h
    ldrb    r0,[r2]					;counter for times glow changes
    cmp     r0,0Ah
    bhi     @@SpawnFireballs
    add     r0,1h
    strb    r0,[r2]
    mov     r0,4h
    strb    r0,[r1]					;4h to timer
    ldr     r1,=GlowTable2
    ldrb    r0,[r2]
    b       @ModifyGlow
.pool
@@SpawnFireballs:
    ldr     r1,=YakOAM_9			;OAM
    str     r1,[r4,18h]
    strh    r5,[r4,16h]
    strb    r5,[r4,1Ch]
    mov     r1,r4
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]
    mov     r6,r4
    add     r6,23h
    ldrb    r3,[r6]					;arguments for secondary sprite spawning
    ldrh    r0,[r4,2h]
    add     r0,94h
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    str     r5,[sp,8h]
YakuzaFire1:
    mov     r0,ProjectileID					;fireball ID
    mov     r1,0h
    mov     r2,0h
	ldr		r7,=InitializeSecondarySprite + 1
    bl      WrapperR7
    ldrb    r3,[r6]
    ldrh    r0,[r4,2h]
    add     r0,9Ch
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    str     r5,[sp,8h]
YakuzaFire2:
    mov     r0,ProjectileID							;fireball ID
    mov     r1,1h
    mov     r2,0h
    bl      WrapperR7
    ldrb    r3,[r6]
    ldrh    r0,[r4,2h]
    add     r0,9Ch
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    mov     r0,40h
    str     r0,[sp,8h]
YakuzaFire3:
    mov     r0,ProjectileID							;fireball ID
    mov     r1,1h
    mov     r2,0h
    bl      WrapperR7
    ldr     r1,=StartSongFlag
    ldrb    r0,[r1]
    cmp     r0,0h				;false if shooting fireballs when spawning
    beq     @@FireSound
    mov     r0,0h
    strb    r0,[r1]
.notice "-----Yukuza SONG------"
.notice tohex(.)
    mov     r0,3Fh
    mov     r1,0h				;boss theme
	ldr		r3,=PlaySong + 1
	bl		WrapperR3
    mov     r0,0CDh
    lsl     r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3			;screech sound at start of battle, should be playsound 2
    b       @Return2
.pool
@@FireSound:
    ldr     r0,=0x2B4
	ldr		r3,=PlaySound + 1
	bl		WrapperR3			;fire sound, plays every time fireballs are shot, except when spawning
    b       @Return2
.pool
@Post_Shot:
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl		WrapperR3
    cmp     r0,0h				;waits for shooting fireball animation to finish
    bne     @@StartDeglow
    b       @Return2
@@StartDeglow:
    ldr     r4,=CurrSpriteData
    ldr     r0,=YakOAM_7				;OAM
    str     r0,[r4,18h]
    mov     r0,0h
    strh    r0,[r4,16h]
    mov     r3,0h
    strb    r0,[r4,1Ch]
    mov     r1,r4
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    strb    r0,[r1]
    ldr     r0,=DeglowTable
    ldrb    r0,[r0]
    sub     r0,8h
    lsl     r0,r0,5h
    ldr     r2,=DMA3SourceAddress
    ldr     r1,=MouthGlowPalettes
    add     r0,r0,r1
    str     r0,[r2]
    ldr     r0,=0x5000320
    str     r0,[r2,4h]
    ldr     r0,=0x80000010
    str     r0,[r2,8h]
    ldr     r0,[r2,8h]
    mov     r0,r4
    add     r0,35h
    strb    r3,[r0]
    mov     r1,r4
    add     r1,2Eh
    mov     r0,2h
    b       @StoreTimer
.pool
@Deglow:
    mov     r1,r4
    mov     r5,r1
    add     r5,2Eh
    ldrb    r0,[r5]
    sub     r0,1h
    strb    r0,[r5]
    mov		r2,r0
    cmp     r2,0h				;checks and decrements timer
    bne     @Return2
    mov     r3,r1
    add     r3,35h
    ldrb    r0,[r3]
    cmp     r0,5h
    bhi     @NextPhase2
    add     r0,1h
    strb    r0,[r3]
    mov     r0,2h
    strb    r0,[r5]
    ldr     r1,=DeglowTable
    ldrb    r0,[r3]
@ModifyGlow:
    add     r0,r0,r1
    ldrb    r0,[r0]
    sub     r0,8h
    lsl     r0,r0,5h
    ldr     r2,=DMA3SourceAddress
    ldr     r1,=MouthGlowPalettes
    add     r0,r0,r1
    str     r0,[r2]
    ldr     r0,=0x5000320
    str     r0,[r2,4h]
    ldr     r0,=0x80000010
    str     r0,[r2,8h]
    ldr     r0,[r2,8h]
    b       @Return2
.pool
@NextPhase2:
    ldr     r1,=YakOAM_10
    str     r1,[r4,18h]
    strh    r2,[r4,16h]
    strb    r2,[r4,1Ch]
    mov     r1,r4
    add     r1,2Fh
    ldrb    r0,[r1]
    add     r0,1h
    b       @StoreTimer
.pool
@ClosingMouth:
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h
    beq     @Return2
    ldr     r2,=PrimarySpriteStats
    ldr     r3,=CurrSpriteData
    ldrb    r1,[r3,1Dh]
    lsl     r0,r1,3h
    add     r0,r0,r1
    lsl     r0,r0,1h
    add     r0,r0,r2
    ldrh    r0,[r0]
    lsr     r1,r0,1h
    ldrh    r0,[r3,14h]
    cmp     r0,r1			;checks if Yakuza is at half health
    bcs     @@ChangePose
    strh    r1,[r3,14h]		;forces Yak to be at half health
    mov     r1,r3
    add     r1,24h
    mov     r0,1Fh
    strb    r0,[r1]			;set pose 1Fh, starts second phase of fight
    mov     r2,r3
    add     r2,32h
    ldrb    r1,[r2]
    mov     r0,40h
    orr     r0,r1
    strb    r0,[r2]			;restores sprite immunity
    b       @Return2
 .pool
@@ChangePose:
    mov     r1,r3
    add     r1,24h
    mov     r0,1Bh			;pose 1Bh
@StoreTimer:
    strb    r0,[r1]			;timer used throughout, also stores pose in one case
@Return2:
    add     sp,0Ch
    pop     r4-r7
    pop     r0
    bx      r0
	
Post_Fireball:							;pose 1Bh
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_4				;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    mov     r2,r1
    add     r2,24h
    mov     r0,1Ch
    strb    r0,[r2]					;sets pose 1Ch
    add     r1,2Eh
    mov     r0,14h
    strb    r0,[r1]					;14h frame timer
    bx      r14
.pool

PostFireballWait:							;pose 1Ch
    push    r14
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,2Eh
    ldrb    r0,[r2]
    sub     r0,1h
    strb    r0,[r2]
    cmp     r0,0h					;checks and decrements timer
    bne     @@Return
    add     r1,24h
    mov     r0,1Dh					;sets pose 1Dh
    strb    r0,[r1]
@@Return:
    pop     r0
    bx      r0
.pool

PostFireballReset:						;pose 1Dh reseting proprties to wall-crawl state
    ldr     r1,=CurrSpriteData
    ldr     r0,=YakOAM_5		;OAM
    str     r0,[r1,18h]
    mov     r0,0h
    strh    r0,[r1,16h]
    strb    r0,[r1,1Ch]
    mov     r2,r1
    add     r2,24h
    mov     r0,1Eh				;sets pose 1Eh
    strb    r0,[r2]
    mov     r0,60h
    strh    r0,[r1,0Ch]			;bottom hitbox
    ldr     r0,=0xFFB8
    strh    r0,[r1,0Eh]			;left hitbox
    mov     r0,48h
    strh    r0,[r1,10h]			;right hitbox
    add     r1,32h
    ldrb    r2,[r1]
    mov     r0,40h	
    orr     r0,r2
    strb    r0,[r1]				;sets 40h flag in properties, immune to projectiles
    bx      r14
.pool

SetRoundNumber:						;pose 1Eh
    push    r14
	ldr		r3,=CheckNearEndAnimation + 1
	bl		WrapperR3
    cmp     r0,0h				;waits for mouth to close
    beq     @@Return
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,24h
    mov     r0,7h				;stores pose 7
    strb    r0,[r2]
    ldr     r0,=SpriteRNG
    ldrb    r0,[r0]
    lsr     r0,r0,2h
    add     r0,1h
    add     r1,2Dh
    strb    r0,[r1]				;stores number of rounds befor next fireball attack
@@Return:
    pop     r0
    bx      r0
.pool

Phase1Ending:								;pose 1Fh, 805C52C
    push    r14
    ldr     r3,=CurrSpriteData
    ldr     r0,=YakOAM_11				;OAM
    str     r0,[r3,18h]
    mov     r0,0h
    strh    r0,[r3,16h]
    strb    r0,[r3,1Ch]
    mov		r1,r3
    mov     r2,r1
    add     r2,24h
    mov     r0,20h						;sets pose 20
    strb    r0,[r2]
    add     r1,2Eh
    mov     r0,78h						;78h frame timer
    strb    r0,[r1]
    ldrh    r0,[r3,2h]					;arguments for GFX effect function
    ldrh    r1,[r3,4h]
    mov     r2,1Fh						;effect ID
	ldr		r3,=SetGFXEffect + 1
	bl		WrapperR3
    mov     r0,99h
    lsl     r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3					;should be play sound2
    pop     r0
    bx      r0
.pool
	
PhaseTransition:							;pose 20h transition to phase 2
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2,2h]
    ldr     r0,=0x63E
    cmp     r1,r0					;checks Y position
    bhi     @@CheckChangePal
    add     r0,r1,4h
    strh    r0,[r2,2h]				;moves sprite downward if above 63Eh
@@CheckChangePal:
    mov     r0,r2
    add     r0,2Eh
    ldrb    r1,[r0]
    mov     r0,3h
    and     r0,r1
    cmp     r0,0h				;checks various bits of the timer to determine when to change palette
    bne     @@CheckTimer
    mov     r0,4h
    and     r1,r0
    cmp     r1,0h				;checks another bit of the timer to determine when to change palette
    beq     @@ChangePal
    mov     r0,r2
    add     r0,34h				;frozen palette offset
    ldrb    r0,[r0]
    ldrb    r1,[r2,1Fh]
    add     r0,r0,r1
    mov     r1,0Eh
    sub     r1,r1,r0
@@ChangePal:
    mov     r0,r2
    add     r0,20h
    strb    r1,[r0]					;changes palette row, used for flashing
@@CheckTimer:
    mov     r1,r2
    add     r1,2Eh
    ldrb    r0,[r1]
    sub     r0,1h
    strb    r0,[r1]
    mov		r3,r0
    cmp     r3,0h					;checks and decrements timer
    bne     @@Return
    mov     r0,r2
    add     r0,24h
    mov     r1,21h					;sets pose 21h
    strb    r1,[r0]
    sub     r0,4h
    strb    r3,[r0]					;restores palette to normal
@@Return:
    pop     r0
    bx      r0
.pool

ChangeHitbox:						;changes hitbox during second phase of fight
    push    r14
    ldr     r2,=CurrSpriteData
    ldrh    r1,[r2]
    mov     r0,8h
    and     r0,r1
    cmp     r0,0h					;checks for rotation flag
    beq     @@NotSpinning
    ldr     r1,=0xFF80
    strh    r1,[r2,0Ah]
    mov     r0,80h
    strh    r0,[r2,0Ch]
    strh    r1,[r2,0Eh]
    strh    r0,[r2,10h]				;hitbox values while spinning
    add     r2,32h
    ldrb    r1,[r2]
    mov     r0,40h
    orr     r0,r1					;makes sprite immune to projectiles while spinning
    b       @@Return
    .pool
@@NotSpinning:
    ldr     r0,=0xFF80
    strh    r0,[r2,0Ah]
    mov     r1,40h
    strh    r1,[r2,0Ch]
    add     r0,40h
    strh    r0,[r2,0Eh]
    strh    r1,[r2,10h]				;hitbox values when not spinning
    add     r2,32h
    ldrb    r1,[r2]
    mov     r0,0BFh
    and     r0,r1					;makes sprite vulnerable 
@@Return:
    strb    r0,[r2]
    pop     r0
    bx      r0
.pool

DestroyArms:									;pose 21
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    add     sp,-0Ch
    ldr     r4,=CurrSpriteData
    ldr     r0,=YakOAM_4					;OAM
    str     r0,[r4,18h]
    mov     r3,0h
    strh    r3,[r4,16h]
    mov     r5,0h
    strb    r3,[r4,1Ch]
    mov     r1,r4
    add     r1,24h
    mov     r0,22h
    strb    r0,[r1]							;sets pose 22h
    add     r1,0Ah
    mov     r0,1Eh
    strb    r0,[r1]							;1E to timer
    add     r0,0E2h
    strh    r0,[r4,12h]						;100h to OAM scaling
    mov     r0,r4
    add     r0,2Ah
    strb    r5,[r0]							;0 to OAM rotation
    ldr     r0,=SpriteRNG
    ldrb    r0,[r0]
    add     r0,1h
    add     r1,7h
    strb    r0,[r1]
    sub     r1,9h
    mov     r0,20h
    strb    r0,[r1]
    ldr     r0,=SamusData
    ldrh    r0,[r0,12h]						;Samus' X
    mov     r3,r4
    ldrh    r2,[r2,4h]						;Yakuza X
    cmp     r0,r2							;checks which direction Samus is relative to Yak
    bcs     @@GoRight
    ldrh    r1,[r3]
    ldr     r0,=0xFDFF
    and     r0,r1							;removes 200h (facing right) flag
    b       @@SpawnSSprites
.pool
@@GoRight:
    ldrh    r0,[r3]
    mov     r2,80h
    lsl     r2,r2,2h
    mov     r1,r2
    orr     r0,r1							;sets 200h flag (moving right)
@@SpawnSSprites:
    strh    r0,[r3]
	ldr		r0,=Phase1Flag
	mov		r1,0h
	strb	r1,[r0]
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    mov     r0,r3
    add     r0,23h
    ldrb    r0,[r0]
    mov     r9,r0
    ldrh    r6,[r3,2h]
    ldrh    r3,[r3,4h]
    mov     r8,r3
    mov     r7,r6
    sub     r7,10h
    str     r7,[sp]
    mov     r4,r8							;arguments for Sprite spawning
    sub     r4,40h
    str     r4,[sp,4h]
    mov     r5,0h
    str     r5,[sp,8h]
YakuzaChunk1:
    mov     r0,ChunkID							;sprite ID, falling chunks of arms
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    mov     r0,20h
    neg     r0,r0
    add     r0,r0,r6
    mov     r10,r0
    str     r0,[sp]
    str     r4,[sp,4h]
    str     r5,[sp,8h]
YakuzaChunk2:
    mov     r0,ChunkID							;sprite ID, falling chunks of arms
    mov     r1,1h
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    sub     r6,40h
    str     r6,[sp]
    str     r4,[sp,4h]
    str     r5,[sp,8h]
YakuzaChunk3:
    mov     r0,ChunkID							;sprite ID, falling chunks of arms
    mov     r1,2h
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    str     r7,[sp]
    mov     r2,40h
    add     r8,r2
    mov     r0,r8
    str     r0,[sp,4h]
    str     r5,[sp,8h]
YakuzaChunk4:
    mov     r0,ChunkID							;sprite ID, falling chunks of arms
    mov     r1,3h
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    mov     r2,r10
    str     r2,[sp]
    mov     r0,r8
    str     r0,[sp,4h]
    str     r5,[sp,8h]
YakuzaChunk5:
    mov     r0,ChunkID							;sprite ID, falling chunks of arms
    mov     r1,4h
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=InitializeSecondarySprite + 1
	mov		r12,r0
    str     r6,[sp]
    mov     r2,r8
    str     r2,[sp,4h]
    str     r5,[sp,8h]
YakuzaChunk6:
    mov     r0,ChunkID						;sprite ID, falling chunks of arms
    mov     r1,5h
    mov     r2,0h
    mov     r3,r9
    bl      WrapperR12
	ldr		r0,=YakOAM_18
	bl		StoreOAMToLegSprite
    add     sp,0Ch
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
	
PauseB4Phase2:								;pose 22h
    push    r14
    ldr     r1,=CurrSpriteData
    mov     r2,r1
    add     r2,2Eh
    ldrb    r0,[r2]
    sub     r0,1h
    strb    r0,[r2]							;checks and decrements timer
    cmp     r0,0h
    bne     @@Return
    add     r1,24h
    mov     r0,24h						;sets pose 24h
    strb    r0,[r1]
@@Return:
    bl      ChangeHitbox				
    pop     r0
    bx      r0
.pool
	
Phase2Main:							;pose 24h
    push    r4-r7,r14
    mov     r7,r8
    push    r7
    add     sp,-0Ch
    mov     r0,0h
    mov     r8,r0					;flag used to check if Yakuza should check to change X direction
    ldr     r4,=CurrSpriteData
    mov     r0,r4
    add     r0,35h
    ldrb    r6,[r0]					;determines horizontal movement speed
    sub     r0,0Ah
    ldrb    r1,[r0]					;stun timer
    mov     r0,7Fh
    and     r0,r1
    cmp     r0,4h
    bhi     @@GetYMovementValue
    ldrh    r1,[r4]
    mov     r0,80h
    lsl     r0,r0,7h
    and     r0,r1
    cmp     r0,0h					;checks for 4000h flag
    beq     @@GetYMovementValue
    mov     r7,80h
    lsl     r7,r7,2h
    mov     r0,r7
    and     r0,r1
    cmp     r0,0h					;checks for 200h flag (facing right)
    beq     @@CheckLeftSide
    ldrh    r0,[r4,2h]
    ldrh    r1,[r4,4h]
    add     r1,40h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,11h					;checks if right side of Yak has hit a wall
    bne     @@MoveRight
    ldrh    r1,[r4]
    ldr     r0,=0xFDFF
    and     r0,r1
    strh    r0,[r4]					;removes 200h flag is a wall was hit
    b       @@GetYMovementValue
    .pool
@@MoveRight:
    ldrh    r0,[r4,4h]
    add     r0,r0,r6
    b       @@ChangeX
@@CheckLeftSide:
    ldrh    r0,[r4,2h]
    ldrh    r1,[r4,4h]
    sub     r1,40h
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,11h					;checks if left side of Yak hit a wall
    bne     @@MoveLeft
    ldrh    r1,[r4]
    mov     r0,r7
    orr     r0,r1
    strh    r0,[r4]					;sets 200h flag is a wall was hit
    b       @@GetYMovementValue
    .pool
@@MoveLeft:
    ldrh    r0,[r4,4h]
    sub     r0,r0,r6
@@ChangeX:
    strh    r0,[r4,4h]
@@GetYMovementValue:
    ldr     r0,=YMoveMentTable			;Determines Y position movement
    add     r4,2Ch
    ldrb    r3,[r4]					;some sort of timer, maxes out at 3Fh. when at 0, starts spinning attack
    lsl     r1,r3,18h
    lsr     r2,r1,18h
    lsr     r1,r1,1Ah
    lsl     r1,r1,1h
    add     r1,r1,r0
    ldrh    r6,[r1]					;value to increase Y pos by
    cmp     r2,3Eh
    bhi     @@ModifyYPos
    add     r0,r3,1h
    strb    r0,[r4]
@@ModifyYPos:
    ldr     r4,=CurrSpriteData
    ldrh    r0,[r4,2h]
    add     r0,r0,r6
    mov     r3,0h
    strh    r0,[r4,2h]			
    lsl		r0,r6,10h
    cmp     r0,0h
    bgt     @@CheckRotation
    b       @SetSpinAttack
@@CheckRotation:
    mov     r2,r4
    add     r2,2Ah
    ldrb    r0,[r2]
    mov     r1,r0
    cmp     r1,0h				;checks if sprite is rotated at all
    beq     @@CheckDropGunk
    add     r0,20h
    strb    r0,[r2]				;changes rotation by 20h
    b       @CheckHitFloor
.pool
@@CheckDropGunk:
    ldrh    r2,[r4]
    mov     r0,8h
    and     r0,r2
    cmp     r0,0h				;checks for rotation flag (8h)
    beq     @CheckHitFloor
    ldr     r0,=YakOAM_4		;OAM
    str     r0,[r4,18h]
    strh    r3,[r4,16h]
    strb    r1,[r4,1Ch]
    ldr     r0,=0xFFF7
    and     r0,r2
    strh    r0,[r4]				;removes rotation flag (8h)
    mov     r0,r4				;arguments for sprite spawning
    add     r0,23h
    ldrb    r3,[r0]
    ldrh    r0,[r4,2h]
    add     r0,94h
    str     r0,[sp]
    ldrh    r0,[r4,4h]
    str     r0,[sp,4h]
    str     r1,[sp,8h]
YakuzaFire4:
    mov     r0,ProjectileID				;Sprite ID, gunk
    mov     r1,0h
    mov     r2,0h
	ldr		r7,=InitializeSecondarySprite + 1
    bl      WrapperR7
    ldr     r0,=0x15B			;noise when dropping gunk
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@CheckHitFloor:
    ldr     r4,=CurrSpriteData
    ldrh    r0,[r4,2h]
    add     r0,80h
    ldrh    r1,[r4,4h]
	ldr		r3,=CheckHitFloor + 1
	bl		WrapperR3
    mov     r1,r0				;r0 is Y pos of top of tile checked
    ldr     r0,=FloorClipValue
    ldrb    r5,[r0]
    cmp     r5,0h				;checks if solid tile is 2 blocks below sprite
    beq     @@CheckIfBelowSamus
    mov     r0,r1
    sub     r0,80h
    mov     r1,0h
    strh    r0,[r4,2h]			;makes Yak exactly 2 tiles above the ground
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,2Ch
    strb    r1,[r0]				;sets 2Ch to 0, starts spinning attack
    mov     r0,r8				
    add     r0,1h				;sets "try change X direction flag"
    mov     r8,r0
    b       @@CheckChangeDirection
 .pool
@@CheckIfBelowSamus:
    ldr     r0,=SamusData
    ldrh    r0,[r0,14h]
    ldrh    r3,[r4,2h]			;comparing Y pos of Samus and Yak
    cmp     r0,r3				;checks if Samus is above Yak while he isn't spinning
    bcs     @@CheckIfCloseToFloor
    ldr     r0,=CurrSpriteData
    add     r0,2Ch
    strb    r5,[r0]				;2Ch to 0, starts spin attack
    mov     r0,r8
    add     r0,1h				;sets "try change X direction flag"
    mov     r8,r0
@@CheckIfCloseToFloor:
    ldrh    r0,[r4,2h]
    mov     r1,0A0h
    lsl     r1,r1,1h
    add     r0,r0,r1			;checks 5 blocks below Yakuza
    ldrh    r1,[r4,4h]
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h
    beq     @@CheckNearFloor
    ldr     r0,=SpriteRNG
    ldrb    r0,[r0]
    cmp     r0,8h
    beq     @@CheckSetFlag
    ldrh    r1,[r4]
    mov     r0,80h
    lsl     r0,r0,7h
    and     r0,r1
    cmp     r0,0h				;checks for 4000h flag
    bne     @@CheckNearFloor
@@CheckSetFlag:
    mov     r2,r4
    add     r2,2Ch
    ldrb    r1,[r2]
    mov     r0,1h
    and     r0,r1
    cmp     r0,0h						;50% change to check to change direction if RNG is 8 
    beq     @@ZeroAttackTimer2			;or 4000h is set, and is 5 blocks above ground
    mov     r0,r8
    add     r0,1h						;sets "try change X direction flag"
    mov     r8,r0
@@ZeroAttackTimer2:
    strb    r5,[r2]						;starts spin attack if 5 blocks above ground, and 4000h is set
@@CheckNearFloor:
    ldr     r4,=CurrSpriteData
    ldrh    r0,[r4,2h]
    add     r0,0E0h				;checks 3 blocks below Yakuza
    ldrh    r1,[r4,4h]
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h
    beq     @@CheckIfShot
    ldr     r0,=SpriteRNG
    ldrb    r0,[r0]
    cmp     r0,0Eh
    bne     @@CheckIfShot
    mov     r2,r4
    add     r2,2Ch
    ldrb    r1,[r2]
    mov     r0,1h
    and     r0,r1
    cmp     r0,0h					;50% change to try to change direction if RNG is 0Eh
    beq     @@ZeroAttackTimer		;and is three blocks from the ground
    mov     r0,r8
    add     r0,1h					;sets "try change X direction flag"
    mov     r8,r0
@@ZeroAttackTimer:
    mov     r0,0h
    strb    r0,[r2]					;starts spin attack if RNG is E and and is 3 blocks from ground
@@CheckIfShot:
    ldr     r2,=CurrSpriteData
    mov     r0,r2
    add     r0,2Bh
    ldrb    r1,[r0]
    mov     r0,7Fh
    and     r0,r1
    cmp     r0,10h					;only 10h if shot with projectile that deals damage
    bne     @@CheckChangeDirection
    ldrh    r1,[r2,2h]
    ldr     r0,=0x57E
    cmp     r1,r0					;checks if above tile 15h
    bls     @@CheckChangeDirection
    mov     r0,r8
    add     r0,1h					;allows for change in X direction
    mov     r8,r0
    mov     r1,r2
    add     r1,2Ch
    mov     r0,0h
    strb    r0,[r1]					;sets 2Ch to 0, starts spin attack
@@CheckChangeDirection:
    mov     r3,r8
    cmp     r3,0h					
    beq     @@CheckPlaySound2
    ldr     r0,=SamusData
    ldrh    r0,[r0,12h]
    ldrh    r1,[r2,4h]				;checks which side of Yak Samus is on
    cmp     r0,r1
    bcs     @@SetMoveRightFlag
    ldrh    r1,[r2]
    ldr     r0,=0xFDFF
    and     r0,r1					;removes 200h flag
    b       @@GetXSpeed
.pool
@@SetMoveRightFlag:
    ldrh    r1,[r2]
    mov     r3,80h
    lsl     r3,r3,2h
    mov     r0,r3
    orr     r0,r1					;sets 200h flag
@@GetXSpeed:
    strh    r0,[r2]
    ldr     r0,=SpriteRNG
    ldrb    r0,[r0]
    add     r0,1h
    mov     r1,r2
    add     r1,35h
    strb    r0,[r1]					;stores RNG + 1 to 35h, which determines horizontal speed
@@CheckPlaySound2:
    mov     r0,r2
    add     r0,2Ch
    ldrb    r0,[r0]
    cmp     r0,0h					;checking if begining spin attack
    bne     @ReturnS
    mov		r0,6Bh					;spinjump sound.
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
    b       @ReturnS
 .pool
@SetSpinAttack:
    ldr		r4,=CurrSpriteData
    ldrh    r0,[r4]
    ldr     r2,=0x4008
    mov     r1,r2
    orr     r0,r1					;sets rotation flag and 4000h
    strh    r0,[r4]
    mov     r1,r4
    add     r1,2Ah
    ldrb    r0,[r1]
    add     r0,20h					;adds to rotation + 20h
    strb    r0,[r1]
    ldrh    r0,[r4,2h]
    sub     r0,80h
    ldrh    r1,[r4,4h]				;checks 2 blocks above Yak
	ldr		r3,=CheckClip + 1
	bl		WrapperR3
    ldr     r0,=ClipValue
    ldrb    r0,[r0]
    cmp     r0,0h
    bne     @@MoveUpwards
    ldrh    r1,[r4,2h]
    ldr     r0,=0x57E
    cmp     r1,r0
    bhi     @@CheckPlaySound
@@MoveUpwards:
    ldrh    r0,[r4,2h]
    sub     r0,r0,r6
	lsl		r0,r0,10h
	lsr		r0,r0,10h
    strh    r0,[r4,2h]				;moves Yakuza upwards by value in r6
@@CheckPlaySound:
    add     r4,2Ch
    ldrb    r1,[r4]
    mov     r0,0Fh
    and     r0,r1
    cmp     r0,0h					;check to see when to play spinjump sound
    bne     @ReturnS
    mov     r0,6Bh				;spinjump sound
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@ReturnS:
    bl      ChangeHitbox
    add     sp,0Ch
    pop     r3
    mov     r8,r3
    pop     r4-r7
    pop     r0
    bx      r0
.pool

PreDeathAI:							;pose 47
    push    r4
    ldr     r3,=CurrSpriteData
    ldr     r0,=YakOAM_5			;OAM
    str     r0,[r3,18h]
    mov     r0,0h
    strh    r0,[r3,16h]
    mov     r2,0h
    strb    r0,[r3,1Ch]
    mov     r1,r3
    add     r1,24h
    mov     r0,48h
    strb    r0,[r1]					;sets pose 48h
    add     r1,0Ah
    mov     r0,3Ch
    strb    r0,[r1]					;3Ch to timer 
    ldrh    r1,[r3]
    ldr     r0,=0xBFFF
    and     r0,r1					;removes 4000h flag
    mov     r0,r3
    add     r0,25h
    strb    r2,[r0]					;0 to Samus collision
    add     r0,6h
    strb    r2,[r0]					;stun timer to 0
    sub     r0,0Bh
    strb    r2,[r0]					;0 to palette row
    mov     r0,1h
    strh    r0,[r3,14h]				;sets health to 1
    pop     r4
    bx      r14
.pool

YakDyingAI:						;pose 48
    push    r4,r7,r14
    ldr     r1,=CurrSpriteData
	ldr		r7,=SetGFXEffect + 1
    ldrh    r2,[r1,2h]
    ldr     r0,=0x63E
    cmp     r2,r0				;checks if Yakuza is above block 18h
    bhi     @@CheckTimer
    add     r0,r2,4h
    strh    r0,[r1,2h]			;slowly moves Yak downwards
@@CheckTimer:
    ldrh    r2,[r1,2h]
    ldrh    r3,[r1,4h]
    mov     r0,2Eh
    add     r0,r0,r1
    mov     r12,r0
    ldrb    r0,[r0]
    sub     r0,1h
    mov     r4,r12
    strb    r0,[r4]
    ldrb    r0,[r4]
    mov     r4,r1
    cmp     r0,28h				;checks and decrements timer
    bls     @@Jump
    b       @@Return
@@Jump:
    lsl     r0,r0,2h
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
.pool
@@JumpTable:
    .word @@NextPose,@@Return,@@Return,@@Return
	.word @@Return,@@EighthExplosion,@@Return,@@Return 
	.word @@Return,@@Return,@@SeventhExplosion,@@Return
	.word @@Return,@@Return,@@Return,@@SixthExplosion
	.word @@Return,@@Return,@@Return,@@Return
	.word @@FifthExplosion,@@Return,@@Return,@@Return
	.word @@Return,@@FourthExplosion,@@Return,@@Return
	.word @@Return,@@Return,@@ThirdExplosion,@@Return
	.word @@Return,@@Return,@@Return,@@SecondExplosion
	.word @@Return,@@Return,@@Return,@@Return,@@FirstExplosion
@@FirstExplosion:
    mov     r0,r2
    sub     r0,40h
    mov     r1,r3
    sub     r1,10h
    mov     r2,1Fh				;effect ID
	bl		WrapperR7
    mov     r0,9Ah
    lsl     r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3			;dying sound?
    b       @@Return
@@SecondExplosion:
    mov     r0,r2
    add     r0,20h
    mov     r1,r3
    sub     r1,10h
    b       @@ExplosionTypeA
@@ThirdExplosion:
    mov     r0,r2
    sub     r0,20h
    mov     r1,r3
    add     r1,1Ch
    b       @@ExplosionTypeB
@@FourthExplosion:
    mov     r0,r2
    add     r0,40h
    mov     r1,r3
    add     r1,20h
    b       @@ExplosionTypeA
@@FifthExplosion:
    mov     r0,r2
    sub     r0,20h
    mov     r1,r3
    sub     r1,10h
    mov     r2,21h
    bl      WrapperR7
    b       @@Return
@@SixthExplosion:
    mov     r0,r2
    add     r0,0x40
    mov     r1,r3
    sub     r1,0x10
@@ExplosionTypeB:
    mov     r2,22h
    bl      WrapperR7
    b       @@Return
@@SeventhExplosion:
    mov     r0,r2
    sub     r0,40h
    mov     r1,r3
    add     r1,1Ch
@@ExplosionTypeA:
    mov     r2,27h				;effect ID
    bl      WrapperR7
    b       @@Return
@@EighthExplosion:
    mov     r0,r2
    add     r0,10h
    mov     r1,r3
    mov     r2,3Ah
    bl      WrapperR7
    b       @@Return
@@NextPose:
    mov     r1,r4
    add     r1,24h
    mov     r0,49h
    strb    r0,[r1]				;sets pose 49
	mov		r0,5h
	add		r1,0Ah
	strb	r0,[r1]				;timer
	ldrh	r0,[r4]
	mov		r1,4h
	orr		r1,r0
	strh	r1,[r0]				;makes sprite invisible 
@@Return:
    pop     r4,r7
    pop     r0
    bx      r0
	
DropsAI:
	push	r4-r7,r14			;pose 49
	add		sp,-8h
    ldr     r4,=CurrSpriteData
	ldrh	r5,[r4,2h]
	ldrh	r6,[r4,4h]
	ldr		r3,=GetDropType + 1
	bl		WrapperR3			;returns values of drop
    mov     r1,r4
    add     r1,2Eh
	ldrb	r2,[r1]
	sub		r2,1h
	strb	r2,[r1]
	cmp		r2,0h
	beq		@@KillSprite
	lsl     r2,r2,2h
    ldr     r1,=@@JumpTable
    add     r2,r2,r1
    ldr     r2,[r2]
    mov     r15,r2
.pool

@@JumpTable:
	.word	@@Return, @@Drop1,@@Drop2,@@Drop3,@@Drop4

@@Drop1:
	ldrh	r3,[r4,2h]
	ldrh	r1,[r4,4h]
	sub		r1,44h
	add		r3,12h
	b		@@Spawn
@@Drop2:
	ldrh	r3,[r4,2h]
	ldrh	r1,[r4,4h]
	add		r1,19h
	sub		r3,37h
	b		@@Spawn
@@Drop3:
	ldrh	r3,[r4,2h]
	ldrh	r1,[r4,4h]
	add		r3,3Bh
	sub		r1,12h
	b		@@Spawn
@@Drop4:
	ldrh	r3,[r4,2h]
	ldrh	r1,[r4,4h]
	sub		r3,10h
	add		r1,35h
	b		@@Spawn
@@KillSprite:
	str		r0,[sp]
	mov		r0,0Bh				;boss killed song
	mov		r1,0h
	ldr		r3,=PlaySong + 1
	;bl		WrapperR3
	nop
	nop
	mov		r1,0h
	strh	r1,[r4]				;kills sprite
	ldr		r2,=YakuzaPalCounter
	str		r1,[r2]
	str		r1,[r2,4h]
	ldr		r1,=LockDoors
	mov		r2,20h
	neg		r2,r2
	strb	r2,[r1]				;unlocks doors after 20h frames
	ldrh	r3,[r4,2h]
	ldrh	r1,[r4,4h]
	mov		r0,1h
	bl		SetnCheckEvent
	ldr		r0,=YakuzaPalCounter
	mov		r1,0h
	str		r1,[r0]		;reset boss ram
	ldr		r0,[sp]
@@Spawn:
	cmp		r0,0h
	beq		@@Return
	str		r1,[sp]
	mov		r1,0h
	mov		r2,0h
	str		r1,[sp,4h]			;spawns drop
	ldr		r7,=SpawnNewPrimarySprite + 1
	bl		WrapperR7
@@Return:
	add		sp,8h
	pop		r4-r7
	pop		r0
    bx      r0
.pool

Yakuza_Main:				;converted
    push    r4,r14
	bl 		BlockPlasma
    ldr     r1,=CurrSpriteData
    ldrh    r0,[r1,14h]
    mov     r4,r1
    cmp     r0,0h				;checking if health is 0
    bne     @@CheckIfHurt
    add     r1,24h
    ldrb    r0,[r1]				;checking for pose 0 (initialize)
    cmp     r0,0h
    beq     @@GoToPoseFunction
	ldr		r2,=Phase1Flag
	ldrb	r2,[r2]
	cmp		r2,0h
	beq		@@SetDyingPose
	ldr     r2,=PrimarySpriteStats
    ldrb    r3,[r4,1Dh]
    lsl     r0,r3,3h
    add     r0,r0,r3
    lsl     r0,r0,1h
    add     r0,r0,r2
    ldrh    r0,[r0]
	lsr		r0,r0,1h
	strh	r0,[r4,14h]
	mov		r0,1Fh				;forces second phase
	b		@@StorePose
@@SetDyingPose:
    mov     r0,47h
@@StorePose:
    strb    r0,[r1]				;sets pose 47 when health is 0 and not on pose 0
@@CheckIfHurt:
    mov     r0,r4
    add     r0,2Bh				;stun/flash timer
    ldrb    r1,[r0]
    mov     r0,7Fh
    and     r0,r1
    cmp     r0,4h				;checks if sound should play
    bne     @@CheckIfDead
    mov     r0,67h			;hurt sound
	lsl		r0,r0,2h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@CheckIfDead:
    mov     r0,r4
    add     r0,24h
    ldrb    r0,[r0]
    cmp     r0,4Ah			;checking if over max pose (aka sprite is in death pose)
    bls     @@GoToPoseFunction
    b       @@Return
@@GoToPoseFunction:
    lsl     r0,r0,2h
    ldr     r1,=@@JumpTable
    add     r0,r0,r1
    ldr     r0,[r0]
    mov     r15,r0
.pool
@@JumpTable:
    .word @@Initialize,@@PauseAnimation,@@PreCrawl,@@Return
	.word @@Return,@@Return,@@Return,@@ColReset
	.word @@EndRound,@@PostGrabAnim,@@ColReset2,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Crawling,@@Return,@@RoundEnding,@@PostFire
	.word @@PostFireWait,@@PostFireReset,@@SetRounds,@@HalfDead
	.word @@PrePhase2,@@ArmsGoBoom,@@Phase2Pause,@@Return
	.word @@Phase2,@@Return,@@Return,@@StartGrab
	.word @@Grab,@@Return,@@CarrySamus,@@Return
	.word @@PreSlam,@@Return,@@Slamming,@@LetGo
	.word @@GrabReset,@@PreFire,@@ShootFire,@@Return
	.word @@Return,@@Return,@@Return,@@Waiting
	.word @@PreBattle,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@PreDeath
	.word @@Dying,@@Drops
@@Initialize:
    bl      YakSpawnAI
    b       @@Return
@@Waiting:
    bl      WaitAI
    b       @@Return
@@PreBattle:
    bl      Pre_BattleAI
    b       @@Return
@@PauseAnimation:
    bl      SetPauseAnimation
@@PreCrawl:
    bl      PreCrawlAI
    b       @@CheckGrab
@@Crawling:
    bl      WallCrawlAI
    b       @@CheckGrab
@@RoundEnding:
    bl      StartEndRound
    b       @@Return
@@ColReset:
    bl      SetGrabState
@@EndRound:
    bl      CheckEndRound
    b       @@CheckGrab
@@StartGrab:
    bl      StartGrabAI
@@Grab:
    bl      GrabSamusAI		
    b       @@CheckEscape
@@CarrySamus:
    bl      CarrySamusUpwards
    b       @@CheckEscape
@@PreSlam:
    bl      PreSlamAI
    b       @@CheckEscape
@@Slamming:
    bl      SlamAI
    b       @@CheckEscape
@@LetGo:
    bl      LetGoAI
@@GrabReset:
    bl      ResetAfterGrab
    b       @@Return
@@PostGrabAnim:
    bl      AnimationAfterGrab
@@ColReset2:
    bl      SetGrabState2
    b       @@Return
@@PreFire:
    bl      Pre_FireballAI
@@ShootFire:
    bl      ShootFireballAI
    b       @@Return
@@PostFire:
    bl      Post_Fireball
@@PostFireWait:
    bl      PostFireballWait
    b       @@Return
@@PostFireReset:
    bl      PostFireballReset
@@SetRounds:
    bl      SetRoundNumber
    b       @@Return
@@HalfDead:
    bl      Phase1Ending
@@PrePhase2:
    bl      PhaseTransition
    b       @@Return
@@ArmsGoBoom:
    bl      DestroyArms
@@Phase2Pause:
    bl      PauseB4Phase2
    b       @@Return
@@Phase2:
    bl      Phase2Main
    b       @@Return
@@PreDeath:
    bl      PreDeathAI
@@Dying:
    bl      YakDyingAI
    b       @@Return
@@Drops:
    bl      DropsAI
	b		@@Return
@@CheckEscape:
	bl		CheckEscapeGrab
	b		@@Return
@@CheckGrab:
	bl 		CheckGrabAI
@@Return:
    bl      CheckChangePal
    pop     r4
    pop     r0
    bx      r0