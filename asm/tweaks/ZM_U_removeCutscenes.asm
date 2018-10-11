.gba
.open "ZM_U.gba","ZM_U_removeCutscenes.gba",0x8000000

.definelabel EventFunctions,0x80608BC

; skip kraid statue cutscene
.org 0x8019C8A
	b       0x8019C9E

; skip ridley statue cutscene
; TODO: fix ridley scream volume?
.org 0x8033B3C
	b       0x8033B56

; skip chozo ghost cutscene
; TODO: fade music
.org 0x805F778
	.word 0x805F7C0

; set event for entering mothership
.org 0x805F7C4
	mov     r0,1
	mov     r1,6
	bl      EventFunctions
	b       0x805F7EA

; set event for entering norfair
.org 0x805F83C
	mov     r0,1
	mov     r1,3
	bl      EventFunctions
	b       0x805F8EC

; set event for exiting kraid
.org 0x805F860
	mov     r0,1
	mov     r1,4
	bl      EventFunctions
	b       0x805F8EC
	
; set event for entering kraid
.org 0x805F88C
	mov     r0,1
	mov     r1,5
	bl      EventFunctions
	b       0x805F8EC

; set event for entering tourian
.org 0x805F8C4
	mov     r0,1
	mov     r1,7
	bl      EventFunctions
	b       0x805F8EC

.close
