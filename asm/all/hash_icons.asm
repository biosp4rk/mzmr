; copy extra palettes for file screen hash icons
.org 0x807C69E
    mov     r3,0xA0
.org 0x807C6A0
    lsl     r4,r3,0x13
.org 0x807C6A8
    add     r3,0xC0
; fix flicker of bottom row
.org 0x807D7A6
    mov     r0,0x18
