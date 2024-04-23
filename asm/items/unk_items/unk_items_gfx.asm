; replace chozo statue gfx
.org 0x82C15F0
    .import "unk_items\gfx\gravity.gfx.lz"
.org 0x82BF534
    .import "unk_items\gfx\space.gfx.lz"
.org 0x82C2BC4
    .import "unk_items\gfx\plasma.gfx.lz"

; change secondary sprites
.org 0x801528A
    mov     r0,1
.org 0x80152AE
    mov     r0,1
.org 0x80152D0
    mov     r0,1
.org 0x80152EC
    mov     r0,1

; change chozo statue OAM
.org 0x8015114
    .dw 0x875F4E4 

; change ability OAM
; opening
.org 0x80163D4
    .dw 0x82B5890
.org 0x80163E4
    .dw 0x82B5890
.org 0x80163F4
    .dw 0x82B5890
; opened
.org 0x8016438
    .dw 0x82B58B0
.org 0x8016448
    .dw 0x82B58B0
.org 0x8016458
    .dw 0x82B58B0
