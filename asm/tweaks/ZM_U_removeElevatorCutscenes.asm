.gba
.open "ZM_U.gba","ZM_U_removeElevatorCutscenes.gba",0x8000000

.definelabel EventFunctions,0x80608BC

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
