; r0 = BehaviorType
AssignItem:
    push    r4-r6,r14
    add     sp,-8
    mov     r5,0                    ; text flag
    cmp     r0,0xFF                 ; check if removed item
    bne     @@NotRemoved
    ldr     r0,=@@SpawnMessage
    mov     r15,r0
@@NotRemoved:
    sub     r0,0x34
    ldr     r1,=TankCollectionInfo
    lsl     r0,r0,3h
    add     r0,r0,r1
    mov     r6,r0                   ; r6 = TankCollectionInfo (at given tank)
    ldrb    r0,[r0]
    sub     r0,1                    ; r0 = [TankNumber] - 1
    cmp     r0,3
    bhi     @@AssignAbility
    ldr     r1,=NumTanksPerArea
    ldr     r2,=Difficulty
    ldrb    r2,[r2]                 ; r2 = Difficulty
    ldr     r3,=TankIncreaseAmounts
    ldr     r4,=@@JumpTable
    lsl     r0,r0,2
    add     r0,r4,r0
    ldr     r0,[r0]
    ldr     r4,=TankStartingAmounts
    mov     r15,r0
    .pool
@@JumpTable:
    .dw @@AssignMissile
    .dw @@AssignEnergy
    .dw @@AssignSuper
    .dw @@AssignPower

@@AssignMissile:
    ldrb    r0,[r1,0x1D]            ; r1 = MaxNumOfTanks
    lsl     r2,r2,2h
    add     r3,r3,r2
    ldrb    r1,[r3,1]               ; r1 = IncreaseAmount
    mul     r0,r1
    ldrb    r2,[r4,1]               ; r2 = StartingAmount
    add     r0,r0,r2                ; r0 = MaxCapacity
    ldr     r4,=Equipment
    ldrh    r2,[r4,2]               ; r2 = CurrCapacity
    add     r3,r2,r1                ; r3 = NewCapacity
    cmp     r0,r3
    bge     @@ValidMissileCapacity  ; if NewCapacity <= MaxCapacity
    b       @@DisplayMessage
@@ValidMissileCapacity:
    cmp     r2,0
    bne     @@NotFirstMissile
    mov     r5,1
@@NotFirstMissile:
    strh    r3,[r4,2]               ; [CurrCapacity] = [NewCapacity]
    ldrh    r0,[r4,8]
    add     r0,r0,r1
    strh    r0,[r4,8]               ; [CurrAmount] += [IncreaseAmount]
    b       @@DisplayMessage

@@AssignEnergy:
    ldrb    r0,[r1,0x1C]            ; r1 = MaxNumOfTanks
    lsl     r2,r2,2h
    add     r3,r3,r2
    ldrb    r1,[r3]                 ; r1 = IncreaseAmount
    mul     r0,r1
    ldrb    r2,[r4]                 ; r2 = StartingAmount
    add     r0,r0,r2                ; r0 = MaxCapacity
    ldr     r4,=Equipment
    ldrh    r2,[r4]                 ; r2 = CurrCapacity
    add     r3,r2,r1                ; r3 = NewCapacity
    cmp     r0,r3
    bge     @@ValidEnergyCapacity   ; if NewCapacity <= MaxCapacity
    b       @@DisplayMessage
@@ValidEnergyCapacity:
    strh    r3,[r4]
    strh    r3,[r4,6]
    b       @@DisplayMessage

@@AssignSuper:
    ldrb    r0,[r1,0x1E]            ; r1 = MaxNumOfTanks
    lsl     r2,r2,2h
    add     r3,r3,r2
    ldrb    r1,[r3,2]               ; r1 = IncreaseAmount
    mul     r0,r1
    ldrb    r2,[r4,2]               ; r2 = StartingAmount
    add     r0,r0,r2                ; r0 = MaxCapacity
    ldr     r4,=Equipment
    ldrb    r2,[r4,4]               ; r2 = CurrCapacity
    add     r3,r2,r1                ; r3 = NewCapacity
    cmp     r0,r3
    bge     @@ValidSuperCapacity    ; if NewCapacity <= MaxCapacity
    b       @@DisplayMessage
@@ValidSuperCapacity:
    cmp     r2,0
    bne     @@NotFirstSuper
    mov     r5,1
@@NotFirstSuper:
    strb    r3,[r4,4]               ; [CurrCapacity] = [NewCapacity]
    ldrb    r0,[r4,0xA]
    add     r0,r0,r1
    strb    r0,[r4,0xA]             ; [CurrAmount] += [IncreaseAmount]
    b       @@DisplayMessage

@@AssignPower:
    ldrb    r0,[r1,0x1F]            ; r1 = MaxNumOfTanks
    lsl     r2,r2,2h
    add     r3,r3,r2
    ldrb    r1,[r3,3]               ; r1 = IncreaseAmount
    mul     r0,r1
    ldrb    r2,[r4,3]               ; r2 = StartingAmount
    add     r0,r0,r2                ; r0 = MaxCapacity
    ldr     r4,=Equipment
    ldrb    r2,[r4,5]               ; r2 = CurrCapacity
    add     r3,r2,r1                ; r3 = NewCapacity
    cmp     r0,r3
    bge     @@ValidPowerCapacity    ; if NewCapacity <= MaxCapacity
    b       @@DisplayMessage
@@ValidPowerCapacity:
    cmp     r2,0
    bne     @@NotFirstPower
    mov     r5,1
@@NotFirstPower:
    strb    r3,[r4,5]               ; [CurrCapacity] = [NewCapacity]
    ldrb    r0,[r4,0xB]
    add     r0,r0,r1
    strb    r0,[r4,0xB]             ; [CurrAmount] += [IncreaseAmount]
    b       @@DisplayMessage

@@AssignAbility:
    sub     r0,4
    lsl     r1,r0,1
    add     r0,r1,r0                ; multiply r0 by 3
    ldr     r4,=@@AbilityFlags
    add     r4,r4,r0
    ldrb    r0,[r4]                 ; bit flag
    ldrb    r1,[r4,1]               ; RAM offset
    ldr     r2,=Equipment
    ldrb    r3,[r2,r1]
    orr     r3,r0
    strb    r3,[r2,r1]              ; [Status] |= bit flag
    ldrb    r1,[r4,2]               ; hint event
    cmp     r1,0
    beq     @@DisplayMessage
    mov     r0,1
    bl      EventFunctions
    b       @@DisplayMessage

@@AbilityFlags:
    ; bit flag, offset, hint event
    .db 0x01,0xC,8      ; long
    .db 0x10,0xC,0      ; charge
    .db 0x02,0xC,0xA    ; ice
    .db 0x04,0xC,0xE    ; wave
    .db 0x08,0xC,0      ; plasma
    .db 0x80,0xC,9      ; bombs
    .db 0x10,0xE,0xD    ; varia
    .db 0x20,0xE,0      ; gravity
    .db 0x40,0xE,0      ; morph
    .db 0x02,0xE,0xB    ; speed
    .db 0x01,0xE,0xC    ; hi
    .db 0x08,0xE,0xF    ; screw
    .db 0x04,0xE,0      ; space
    .db 0x80,0xE,0      ; grip

@@DisplayMessage:
    mov     r0,r6                   ; r0 = TankCollectionInfo (at given tank)
    ldrb    r0,[r0,2h]
    add     r5,r0,r5                ; r5 = text number
@@SpawnMessage:
    ldr     r0,=SamusData
    ldrh    r3,[r0,14h]
    ldrh    r0,[r0,12h]
    str     r0,[sp]
    mov     r0,0h
    str     r0,[sp,4h]
    mov     r0,11h
    mov     r1,r5
    mov     r2,6h
    bl      SpawnNewPrimarySprite
    add     sp,8
    pop     r4-r6
    pop     r0
    bx      r0
    .pool
