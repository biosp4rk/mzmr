; Landing site
; 0 = Before escape (no power bomb, left door leads to exploding room)
; 5 = After escape [now unused]

; [0] Change clipdata for room to add power bomb
.org 0x8343860  ; clipdata pointer for room 0
	.dw 0x86DE1BE  ; clipdata offset for room 5

; [0] Change destination of left door to post-exploded room (15)
.org 0x833FBC2
	.db 0x02

; [0] Remove event based connection at top right
.org 0x833FBC8
	.db 0x54

; [0] Remove event based connection at bottom right
.org 0x833FCDC
	.db 0x14

; [0] Disable hatch lock event for top right and bottom right
; TODO: have ship lock doors during escape
.org 0x836014B
    .db 0

; [0] Add blank room sprite layout after zebes escape
.org 0x8343871
    .db 0x41  ; event for zebes escape


; Large exploding room
; 1 = During escape
; 15 = Not during escape (left door is locked before escape, right door goes to Landing site (5))

; TODO: [1] Lock bottom right door

; [15] Use door lock event from Power Grip (8) on left door to prevent reaching mother brain
.org 0x8360150
    ; destination, event, before/after flag, hatches to lock
	.db 0x15,0x41,0x01,0x04

; [15] Top right door should go to Landing site (0)
.org 0x833FBB6
	.db 0x03


; Power grip
; 8 = Entering (left door doesn't exist, right door locks) [now unused]
; 10 = Leaving [now unused]
; 11 = After

; [11] Add breakable blocks to room
.org 0x86E288C  ; BG1 offset for room 10
    .import "data\crateria_11_bg1.rle"
.org 0x86E260E  ; clipdata offset for room 10
    .import "data\crateria_11_clip.rle"
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
    .dw 0x804897E  ; skip event check for pillar
.org 0x8048B4A
    b       0x8048B56  ; skip event check for platforms


; Glass tube
; 17 = Tube (rain)
; 55 = Tube (sun)
; 62 = Shortcut (rain)
; 9 = Shortcut (sun)

; [55] Redirect right door to sunny version (55)
.org 0x834005A
    .db 0xA5

; [55] Redirect left door to sunny version (55)
.org 0x8340090
    .db 0x46  ; remove event connection
.org 0x8340096
    .db 0xA9  ; connect to door A9

; [9] Redirect top of shortcut to sunny version (9)
.org 0x834093C
    .db 0x02  ; remove event connection
.org 0x8340942
    .db 0xF2  ; connect to door F2
