; Landing site
; 0 = Before escape (no power bomb, left door leads to exploding room)
; 5 = After escape

; [0] Change clipdata for room to add power bomb
.org 0x8343860  ; clipdata pointer for room 0
	.dw 0x86DE1BE  ; clipdata offset for room 5

; [0] Change destination of left door to post-exploded room
.org 0x833FBC2
	.db 0x02

; [0] Remove event based connection at top right
.org 0x833FBC8
	.db 0x54

; [0] Remove event based connection at bottom right
.org 0x833FCDC
	.db 0x14


; Large exploding room
; 1 = During escape
; 15 = Not during escape (left door should lock before escape, right door goes to Landing site (5))

; [15] Use door lock event from Power Grip (8) on left door to prevent reaching mother brain
.org 0x8360150
	.db 0x15,0x27,0x01,0x04

; [15] Top right door should go to Landing site (0)
.org 0x833FBB6
	.db 0x03


; Power grip
; 8 = Entering (left door doesn't exist, right door locks)
; 10 = Leaving (now unused)
; 11 = After

; [11] Add breakable blocks to room
.org 0x86E288C  ; BG1 offset for room 10
    .import "crateria_11_bg1.rle"
.org 0x86E260E  ; clipdata offset for room 10
    .import "crateria_11_clip.rle"
.org 0x8343C54  ; BG1 pointer for room 11
    .dw 0x86E288C
.org 0x8343C5C  ; clipdata pointer for room 11
    .dw 0x86E260E

; [11] Put bottom left door from room 8 in room 11
.org 0x833FD6D
    .db 0x11

; [11] Remove event connection at bottom left
.org 0x833FD00
    .db 0x12

; [11] Redirect top right door to room 11
.org 0x833FC7C
    .db 0x14  ; remove event based connection
.org 0x833FC82
    .db 0x2F  ; connect to door 2F

; Set "pillar raised" event right away
.org 0x80488D4
    .db 0x804897E  ; skip event check for pillar
.org 0x8048B4A
    b       0x8048B56  ; skip event check for block


; Glass tube

; fix doors near glass tube
.org 0x834005A
    .db 0xA5    ; tube right side
.org 0x8340090
    .db 0x46    ; remove event connection
.org 0x8340096
    .db 0xA9    ; tube left side
.org 0x834093C
    .db 0x02    ; remove event connection
.org 0x8340942
    .db 0xF2    ; top of shortcut

