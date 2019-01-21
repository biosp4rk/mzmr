; set varia position
.org 0x8055FBE
    bl      SetVariaPosition
    cmp     r0,0
    beq     0x8056074           ; skip animation code if necessary
    b       0x8055FD2

; force varia animation to play
.org 0x8055FDA
    strb    r0,[r1,3]
    nop

; fix varia animation
.org 0x805FF94
    bl      FixVariaAnimation
    b       0x805FFA6

; don't change varia's map tile with full suit
.org 0x806B212
    b       0x806B22E
