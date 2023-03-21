.gba
.open "ZM_U.gba","ZM_U_removeChozoHints.gba",0x8000000

; set statue to sitting position
.org 0x8013E00      ; long beam
    .dw 0x8014004
.org 0x8013E08      ; ice beam
    .dw 0x8014004
.org 0x8013E10      ; wave beam
    .dw 0x8014004
.org 0x8013E18      ; bombs
    .dw 0x8014004
.org 0x8013E20      ; speed
    .dw 0x8014004
.org 0x8013E28      ; hi-jump
    .dw 0x8014004
.org 0x8013E30      ; screw
    .dw 0x8014004
.org 0x8013E38      ; varia
    .dw 0x8014004

; fix room with first chozo statue
.org 0x8340B4D
    .db 0
.org 0x8340B54
    .dw 0x8364F4C

.close
