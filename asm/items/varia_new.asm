SetVariaPosition:
    push    r14
    ldr     r4,=SamusData
    ldrb    r0,[r4]
    cmp     r0,0x22         ; check if shinesparking
    beq     @@ReturnFalse
    cmp     r0,0x26         ; check if ballsparking
    beq     @@ReturnFalse
    mov     r0,0x1E
    bl      0x80074E8       ; set pose to facing forward
    ldr     r0,=0x278       ; X position
    strh    r0,[r4,0x12]
    ldr     r0,=0x1FF       ; Y position
    strh    r0,[r4,0x14]
    mov     r0,1
    b       @@Return
@@ReturnFalse:
    mov     r0,0
@@Return:
    pop     r1
    bx      r1
    .pool


FixVariaAnimation:
    push    r14
    add     sp,-4
; set 500001E to 2DF
    ldr     r0,=0x500001E
    ldr     r1,=0x2DF
    strh    r1,[r0]
; fill tile 51 with FFFF
    ldr     r1,=0xFFFF
    ldr     r2,=0x6004A20
    mov     r3,0x20
    mov     r0,0x10
    str     r0,[sp]
    mov     r0,3
    bl      _16BitFill
; fill BG0 with 0051
    ldr     r1,=0x0051
    ldr     r2,=0x6000800
    mov     r3,0x80
    lsl     r3,r3,4
    mov     r0,0x10
    str     r0,[sp]
    mov     r0,3
    bl      _16BitFill
    add     sp,4
    pop     r0
    bx      r0
    .pool
