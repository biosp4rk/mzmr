.gba
.open "ZM_U.gba","ZM_U_removeCutscenes.gba",0x8000000

.definelabel DisablePauseFlag,0x3000049
.definelabel AreaID,0x3000054
.definelabel RoomID,0x3000055
.definelabel DoorID,0x3000056
.definelabel DoorUnlockTimer,0x300007B
.definelabel SpriteDataSlot0,0x30001AC
.definelabel CurrSpriteData,0x3000738
.definelabel SubGameMode1,0x3000C72
.definelabel SamusData,0x30013D4
.definelabel SamusWeaponInfo,0x3001414
.definelabel Equipment,0x3001530
.definelabel MusicInfo,0x3001D00


.definelabel SetSamusPose,0x80074E8
.definelabel SpawnNewSecondarySprite,0x800E258
.definelabel LoadBeamGfx,0x804F670
.definelabel EventFunctions,0x80608BC
.definelabel UpdateSuitType,0x806FEE4

.definelabel PrimarySpriteStats,0x82B0D68

; skip kraid death statue cutscene
.org 0x8019C8A
    b       0x8019C9E

; skip ridley spawning cutscene
.org 0x803252E
    strh    r0,[r6,0x12]
    ; play music
    mov     r0,0x35
    mov     r1,0
    bl      0x80039F4

; skip ridley death statue cutscene
; TODO: fix ridley scream volume?
.org 0x8033B3C
    b       0x8033B56

; skip kraid spawning cutscene
.org 0x805F780
    b       0x805F7EA

; skip chozo ghost cutscene
; TODO: fade music
.org 0x805F7A8
    b       0x805F7EA

; set event for entering mothership
.org 0x805F7C4
    mov     r0,1
    mov     r1,6
    bl      EventFunctions
    b       0x805F7EA

; set event for entering norfair
.org 0x805F83C
    mov     r0,1
    mov     r1,3
    bl      EventFunctions
    b       0x805F8EC

; set event for exiting kraid
.org 0x805F860
    mov     r0,1
    mov     r1,4
    bl      EventFunctions
    b       0x805F8EC

; set event for entering kraid
.org 0x805F88C
    mov     r0,1
    mov     r1,5
    bl      EventFunctions
    b       0x805F8EC

; set event for entering tourian
.org 0x805F8C4
    mov     r0,1
    mov     r1,7
    bl      EventFunctions
    b       0x805F8EC


; skip escaped zebes cutscene
.org 0x8045734
    bl      SkipZebesEscape
    nop

; skip full suit cutscene
.org 0x8039758
    nop
    bl      SkipFullSuit

.org 0x83763A4
SkipZebesEscape:
    push    r14
    ; update room
    ldr     r2,=SuitlessStart
    ldr     r1,=AreaID
    ldrb    r0,[r2]
    strb    r0,[r1]
    ldr     r1,=RoomID
    ldrb    r0,[r2,1]
    strb    r0,[r1]
    ldr     r1,=DoorID
    ldrb    r0,[r2,2]
    strb    r0,[r1]
    ; update equipment
    mov     r0,2
    bl      UpdateSuitType
    ; update samus data
    ldr     r1,=SamusData
    mov     r0,0x1E
    strb    r0,[r1]         ; Samus.Pose = 1E
    mov     r0,0x20
    strh    r0,[r1,0xE]     ; Direction = Left
    mov     r0,0
    strb    r0,[r1,0x1D]    ; Animation = 0
    strh    r0,[r1,0xC]     ; LastWall = 0
    ; update SubGameMode1
    mov     r0,3
    ldr     r1,=SubGameMode1
    strb    r0,[r1]
    ; update MusicInfo[21]
    ldr     r1,=MusicInfo
    add     r1,0x21
    mov     r0,0x10
    strb    r0,[r1]
    ; return
    pop     r0
    bx      r0
    .pool

SkipFullSuit:
    push    r14
    ; set full suit
    ldr     r1,=Equipment
    mov     r0,1
    strb    r0,[r1,0x12]
    ; set ammo full
    ldrh    r0,[r1]
    strh    r0,[r1,6]
    ldrh    r0,[r1,2]
    strh    r0,[r1,8]
    ldrb    r0,[r1,4]
    strb    r0,[r1,0xA]
    ldrb    r0,[r1,5]
    strb    r0,[r1,0xB]
    ; activate items
    ldrb    r0,[r1,0xC]
    strb    r0,[r1,0xD]
    ldrb    r0,[r1,0xE]
    strb    r0,[r1,0xF]
    ; set samus pose to facing foreground
    mov     r0,0x1E
    bl      SetSamusPose
    ; set samus position (removed)
    ldr     r1,=0x300019C
    mov     r0,0
    strb    r0,[r1,2]       ; 300019E = 0
    mov     r0,0xA
    strb    r0,[r1,4]       ; 30001A0 = A
    bl      0x806041C       ; copy prev value to 30001BF
    ; disable pausing
    ldr     r1,=DisablePauseFlag
    mov     r0,1
    strb    r0,[r1]
    ; ??? (set Samus[0C] = 1)
    ldr     r1,=SamusData
    mov     r0,1
    strh    r0,[r1,0xC]
    ; ??? (set [3000BF2] = F)
    ldr     r1,=0x3000BF2
    mov     r0,0xF
    strb    r0,[r1]
    ; reset charge counter
    ldr     r1,=SamusWeaponInfo
    mov     r0,0
    strb    r0,[r1,5]
    ; reload beam gfx
    bl      LoadBeamGfx
    ; set some value that the reflection AI checks
    ldr     r1,=0x300070C
    mov     r0,6
    strb    r0,[r1,0xF]
    ; return
    pop     r0
    bx      r0
    .pool


; modify kraid pose 0 to start music
.org 0x8019370
.area 0x22C
    push    r4-r7,r14
    mov     r7,r10
    mov     r6,r9
    mov     r5,r8
    push    r5-r7
    ; new code
    mov     r0,0x34
    mov     r1,0
    bl      0x80039F4
    ; end of new code
    add     sp,-0xC
    ldr     r1,=DoorUnlockTimer
    mov     r0,1
    strb    r0,[r1]
    ldr     r3,=CurrSpriteData
    ldrh    r1,[r3,2]
    sub     r1,0x28
    mov     r2,0
    mov     r6,0
    strh    r1,[r3,2]
    ldrh    r0,[r3,4]
    sub     r0,0x20
    strh    r0,[r3,4]
    ldr     r4,=0x300070C
    mov     r8,r4
    strh    r1,[r4,6]
    strh    r0,[r4,8]
    ldrh    r0,[r4,6]
    mov     r9,r0
    ldrh    r1,[r4,8]
    mov     r10,r1
    strh    r0,[r3,6]
    strh    r1,[r3,8]
    mov     r1,r3
    add     r1,0x27
    mov     r0,0x30
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x1A
    strb    r0,[r1]
    add     r1,1
    mov     r0,0x38
    strb    r0,[r1]
    ldr     r0,=0xFF90
    strh    r0,[r3,0xA]
    mov     r1,0x70
    strh    r1,[r3,0xC]
    sub     r0,0x30
    strh    r0,[r3,0xE]
    strh    r1,[r3,0x10]
    mov     r1,r3
    add     r1,0x2C
    mov     r0,0x78
    strb    r0,[r1]
    mov     r0,r3
    add     r0,0x2D
    strb    r2,[r0]
    sub     r1,7
    mov     r0,0xA
    strb    r0,[r1]
    ldrh    r0,[r3]
    mov     r4,0x80
    lsl     r4,r4,8
    mov     r1,r4
    orr     r0,r1
    orr     r0,r2
    mov     r4,0x80
    lsl     r4,r4,2
    mov     r1,r4
    orr     r0,r1
    mov     r1,0x20
    orr     r0,r1
    strh    r0,[r3]
    ldr     r0,=PrimarySpriteStats
    ldr     r1,=0x7CE
    add     r0,r0,r1
    ldrh    r0,[r0]
    strh    r0,[r3,0x14]
    mov     r4,r8
    strh    r0,[r4,0xA]
    strb    r2,[r4,0xF]
    strb    r2,[r4,0xE]
    strb    r2,[r4,0xD]
    ldr     r0,=0x82C61F0
    str     r0,[r4]
    strb    r2,[r4,0xC]
    strh    r6,[r4,4]
    ldr     r0,=0x82CAC1C
    str     r0,[r3,0x18]
    strb    r2,[r3,0x1C]
    strh    r6,[r3,0x16]
    mov     r1,r3
    add     r1,0x24
    mov     r0,1
    strb    r0,[r1]
    mov     r0,6
    strb    r0,[r3,0x1E]
    ldrb    r5,[r3,0x1F]
    mov     r0,r3
    add     r0,0x23
    ldrb    r4,[r0]
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,0
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,1
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,2
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    ; remove these instructions for extra space
    ;lsl     r0,r0,0x18
    ;lsr     r0,r0,0x18
    ldr     r7,=SpriteDataSlot0
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r7
    add     r1,0x2D
    strb    r0,[r1]
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,3
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,4
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    ; remove these instructions for extra space
    ;lsl     r0,r0,0x18
    ;lsr     r0,r0,0x18
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r7
    add     r1,0x2D
    strb    r0,[r1]
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,5
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,7
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    ; remove these instructions for extra space
    ;lsl     r0,r0,0x18
    ;lsr     r0,r0,0x18
    lsl     r1,r0,3
    sub     r1,r1,r0
    lsl     r1,r1,3
    add     r1,r1,r7
    add     r1,0x2D
    strb    r0,[r1]
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,8
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,9
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,0xA
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r0,r9
    str     r0,[sp]
    mov     r1,r10
    str     r1,[sp,4]
    str     r6,[sp,8]
    mov     r0,3
    mov     r1,0xB
    mov     r2,r5
    mov     r3,r4
    bl      SpawnNewSecondarySprite
    mov     r4,r8
    ldrh    r0,[r4,6]
    add     r0,0x80
    strh    r0,[r4,6]
    ldr     r1,=0x30000FC
    ldrh    r0,[r1,2]
    sub     r0,0x80
    strh    r0,[r1,2]
    add     sp,0xC
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
.endarea

.close
