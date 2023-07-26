.gba
.open "ZM_U.gba","ZM_U_skipSuitless.gba",0x8000000

; put player in save room before chozo ghost
.org 0x8060E78
    mov     r0,0x28     ; save room number
    strb    r0,[r1,1]
    mov     r1,0x56     ; door number

; fix song that plays
.org 0x8060B08
    mov     r0,3        ; save room music

.close
