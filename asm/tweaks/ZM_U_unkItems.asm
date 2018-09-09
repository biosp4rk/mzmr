.gba
.open "ZM_U.gba","ZM_U_unkItems.gba",0x8000000

.org 0x8044098		; Crocomire AI
StartFullSuit:
	strh    r0,[r1]
	strh    r0,[r1,6]
	mov     r0,1
	strb    r0,[r1,0x12]
	bx      r14
	
; start with full suit
.org 0x800BD7E
	bl      StartFullSuit

.close
