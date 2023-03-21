.gba
.open "ZM_U.gba","ZM_U_removeMidAirBombJump.gba",0x8000000

; make all mid-air bomb jump velocities 0
; Y velocity
.org 0x8006b00
    mov r0, 0x0
	
; X velocity left
.org 0x8006b0c
   .dh 0x0
   
; X velocity right
.org 0x8006ae8
    mov r0, 0x0
	
.close
