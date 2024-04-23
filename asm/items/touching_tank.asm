.org 0x805AB4C  
; modified portion of CheckTouchingTransitionOrTank
    ldr     r0,=GettingTankFlag
    ldrb    r0,[r0]
    cmp     r0,0h
    beq     @@NotGettingTank    ; if already getting tank
    b       @@Return                ; return
@@NotGettingTank:
    mov     r2,0h
    mov     r10,r2              ; r10 = 0
    mov     r4,3h               ; r4 = 3
    add     r3,sp,14h
    mov     r8,r3               ; r8 = sp+14
    ldr     r0,=NumTanksPerArea
    mov     r9,r0               ; r9 = NumTanksPerArea
@@Loop:
    mov     r1,r8               ; for each BehaviorType from sp[14] to sp[08]
    ldr     r0,[r1]             ; r0 = [BehaviorType]
    cmp     r0,0h
    bne     @@NotTouchingAir    ; if touching air
    b       @@Continue              ; continue
@@NotTouchingAir:
    sub     r0,34h
    cmp     r0,0Bh
    bls     @@ValidType
    ldr     r0,[r1]
    sub     r0,60h
    cmp     r0,20h
    bls     @@ValidType         ; if not a valid tank type
    b       @@Continue              ; continue
@@ValidType:
    ldr     r0,[r1]
    sub     r0,34h
    ldr     r1,=TankCollectionInfo
    lsl     r0,r0,3h
    add     r0,r0,r1            ; TankCollectionInfo + [BehaviorType] * 8
    ldrb    r5,[r0]             ; r5 = [TankNumber]
    cmp     r5,0
    bne     @@TankNotHidden
    b       @@CheckAssigned
@@TankNotHidden:
    ldr     r2,=8345CEEh
    lsl     r1,r4,1h
    add     r0,r2,1
    add     r0,r1,r0
    ldrb    r0,[r0]
    lsl     r0,r0,2h
    mov     r7,r13
    add     r7,r7,r0
    add     r7,24h
    ldrb    r0,[r7]             ; r0 = [XPos]
    add     r1,r1,r2
    ldrb    r1,[r1]
    lsl     r1,r1,2h
    mov     r6,r13
    add     r6,r6,r1
    add     r6,18h
    ldrb    r1,[r6]             ; r1 = [YPos]
    bl      806CC68h            ; check if minimap tile is explored?
    cmp     r0,0h
    bne     @@MapTileExplored   ; if minimap tile explored
    b       @@CheckAssigned
@@MapTileExplored:
    ldr     r1,=GettingTankFlag
    mov     r0,1h
    strb    r0,[r1]                 ; [GettingTankFlag] = 1
    ldr     r1,=3001606h
    mov     r2,0FAh
    lsl     r2,r2,2h
    mov     r0,r2
    strh    r0,[r1]                 ; [3001606] = 3E8
    ldr     r1,=30056A8h
    mov     r3,r8
    ldr     r0,[r3]
    strh    r0,[r1]                 ; [30056A8] = [ClipBehavior]
    ldr     r0,[r7]
    strb    r0,[r1,2h]              ; [30056AA] = [XPos]
    ldr     r0,[r6]
    strb    r0,[r1,3h]              ; [30056AB] = [YPos]
; call new function
    mov     r0,r8
    ldrb    r0,[r0]                 ; r0 = [BehaviorType]
    bl      AssignItem

@@CheckAssigned:
    ldr     r0,=GettingTankFlag
    ldrb    r0,[r0]
    cmp     r0,0h
    bne     @@Return
@@Continue:
    mov     r2,4h
    neg     r2,r2
    add     r8,r2
    sub     r4,1h
    cmp     r4,0h
    blt     @@Return
    b       @@Loop
@@Return:
    add     sp,30h
    pop     r3-r5
    mov     r8,r3
    mov     r9,r4
    mov     r10,r5
    pop     r4-r7
    pop     r0
    bx      r0
    .pool
