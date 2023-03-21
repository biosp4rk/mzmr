.gba
.open "ZM_U.gba","ZM_U_itemToggle.gba",0x8000000

.definelabel BeamBombActivation,0x300153D

; enable item toggle
.org 0x8071C1A
    b       0x8071C36

; allow bombs to be toggled
.org 0x8071BAC
    beq     0x8071C36
    mov     r6,0x80
    ldr     r5,=BeamBombActivation
    b       0x8071C36
    .pool

; allow suits to be toggled
.org 0x8071BE6
    b       0x8071C36

; always draw on/off
.org 0x8071D5A
    b       0x8071D7A

.close
