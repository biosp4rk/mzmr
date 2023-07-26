.gba
.open "ZM_U.gba","ZM_U_titleGraphics.gba",0x8000000

.org 0x87F8000
.align
TitleGraphics:
    .import "title_gfx.lz"
.align
TitleTilemap:
    .import "title_tm.lz"

.org 0x8077604
    .dw TitleGraphics
.org 0x844F0B4
    .dw TitleTilemap

.close
