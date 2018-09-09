; fix tileset pointers
.org 0x8056250
	.word TilesetEntries
.org 0x805E200
	.word AnimTilesetEntries
.org 0x805E1F8
	.word AnimGfxEntries
	
; fix data pointers
.org 0x8056310
	.word ClipdataCollisionTypes
	.word ClipdataBehaviorTypes
	.word TileTable400
.org 0x8056320
	.word ClipdataCollisionTypes400
.org 0x8056328
	.word ClipdataBehaviorTypes400
.org 0x80592C0
	.word TankCollectionInfo
.org 0x805AC20
	.word TankCollectionInfo
.org 0x805AD80
	.word TankCollectionInfo
.org 0x805ADE4
	.word TankCollectionInfo