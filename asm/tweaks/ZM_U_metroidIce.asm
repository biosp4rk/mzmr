.gba
.open "ZM_U.gba","ZM_U_metroidIce.gba",0x8000000

; make unfrozen metroids vulnerable to missiles
.org 0x82B1474
    .db 0x48

.close
