.gba
.open "ZM_U.gba","ZM_U_fixChargeOAM.gba",0x8000000

; skip spawning orb
.org 0x801355A
    b       0x801357C

; skip despawning orb
.org 0x801360C
    b       0x8013622

; use power grip's OAM
.org 0x80135C4
    .dw 0x82B310C

.close
