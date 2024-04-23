; fix tileset pointers
.org 0x8056250
    .dw TilesetEntries
.org 0x805E200
    .dw AnimTilesetEntries
.org 0x805E1F8
    .dw AnimGfxEntries

; fix data pointers
.org 0x8056310
    .dw ClipdataCollisionTypes
    .dw ClipdataBehaviorTypes
    .dw TileTable400
.org 0x8056320
    .dw ClipdataCollisionTypes400
.org 0x8056328
    .dw ClipdataBehaviorTypes400
.org 0x80592C0
    .dw TankCollectionInfo
.org 0x805AC20
    .dw TankCollectionInfo
.org 0x805AD80
    .dw TankCollectionInfo
.org 0x805ADE4
    .dw TankCollectionInfo
