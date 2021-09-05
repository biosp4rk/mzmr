.gba
.open "ZM_U.gba","ZM_U_skipSuitless.gba",0x8000000

.definelabel AreaID,0x3000054
.definelabel RoomID,0x3000055
.definelabel DoorID,0x3000056
.definelabel SetSuitlessStartingRoom,0x80?????


; put player in save room before chozo ghost
.org 0x8060E72
    bl      SetSuitlessStartingRoom
    b       0x8060E82

; fix song that plays
.org 0x8060B08
    mov     r0,3        ; save room music

.close
