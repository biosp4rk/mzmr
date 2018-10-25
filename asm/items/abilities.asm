; morph ball
.org 0x8013084
	mov     r0,8
	bl      CheckSpawnAbility
	mov     r4,0
	nop
	nop
	cmp     r0,0

.org 0x801316C
	mov     r0,0x78			; replace with new BehaviorType
	bl      AssignItem
	mov     r0,1			; set event
	mov     r1,MorphEvent
	bl      EventFunctions
	b       0x801318A
	
	
; power grip
.org 0x80132FA
	mov     r0,0xD
	mov     r4,r3			; keep r3 intact
	bl      CheckSpawnAbility
	mov     r3,r4
	mov     r4,0
	cmp     r0,0
	beq     0x8013314
	strh    r4,[r5]

.org 0x80133AA
	mov     r0,0x7D
	bl      AssignItem
	mov     r0,1
	mov     r1,GripEvent
	bl      EventFunctions
	b       0x8013400

	
; charge beam
.org 0x801349A
	mov     r0,1
	bl      CheckSpawnAbility
	mov     r4,0
	nop
	nop
	cmp     r0,0
	
.org 0x8013650
	mov     r0,0x71
	bl      AssignItem
	mov     r0,1
	mov     r1,ChargeEvent
	bl      EventFunctions
	b       0x8013674

	
; chozo statues
.org 0x80138D8
    push    r4,r14
    sub     r0,0x22
    cmp     r0,0x72
    bls     @@ValidChozo
    b       @@Return
@@ValidChozo:
    lsl     r0,r0,1
    ldr     r4,=@@ItemTable
    add     r4,r4,r0
    ldrb    r0,[r4]
	cmp     r0,0
	beq     @@SetEvent
	bl      AssignItem
@@SetEvent:
    mov     r0,1
	ldrb    r1,[r4,1]
	bl      EventFunctions
    b       @@Return
    .pool
@@ItemTable:
	.byte 0,8				; long hint
	.byte 0x70,LongEvent	; long
	.byte 0,0xA				; ice hint
	.byte 0x72,IceEvent		; ice
	.byte 0,0xE				; wave hint
	.byte 0x73,WaveEvent	; wave
	.byte 0,9				; bomb hint
	.byte 0x75,BombEvent	; bomb
    .byte 0,0xB				; speed hint
	.byte 0x79,SpeedEvent	; speed
	.byte 0,0xC				; hi hint
	.byte 0x7A,0x12			; hi
	.byte 0,0xF				; screw hint
	.byte 0x7B,0x15			; screw
	.byte 0,0xD				; varia hint
	.byte 0x76,0x13			; varia
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0x77,0x17			; gravity
	.byte 0x7C,0x16			; space
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0x74,0x18			; plasma
@@Return:
    pop     r4
    pop     r0
    bx      r0
	
	
; check if chozo statue item was obtained
.org 0x8014008
	mov     r0,0			; long
	b       CheckForAbility
.org 0x8014014
	mov     r0,2			; ice
	b       CheckForAbility
.org 0x8014020
	mov     r0,3			; wave
	b       CheckForAbility
.org 0x801402C
	mov     r0,4			; plasma
	b       CheckForAbility
.org 0x8014038
	mov     r0,5			; bomb
	b       CheckForAbility
.org 0x8014044
	mov     r0,9			; speed
	b       CheckForAbility
.org 0x8014050
	mov     r0,0xA			; hi
	b       CheckForAbility
.org 0x801405C
	mov     r0,0xB			; screw
	b       CheckForAbility
.org 0x8014068
	mov     r0,6			; varia
	b       CheckForAbility
.org 0x8014074
	mov     r0,0xC			; space
	b       CheckForAbility
.org 0x8014080
	mov     r0,7			; gravity
	b       CheckForAbility
	
.org 0x8014086
CheckForAbility:
	bl      CheckSpawnAbility
	pop     r1
	bx      r1
	

; prevent chozo statue from displaying message
.org 0x80165E6
	nop
	nop
	nop

; add text for removed item
.org 0x8442560		; Removed Item
	.halfword 0x804C,0x0092,0x00C5,0x00CD,0x00CF,0x00D6,0x00C5,0x00C4,0x0040,0x0089,0x00D4,0x00C5,0x00CD,0xFF00
