.align 2

;table used for positioning of secondaries relative to main sprite
;3B77D2 is first used
;3B787A,3B78CE,3B7922,

Animation1:
	.dh 0x0003,0x0008,0x0000,0x0002,0x0008,0x0000,0x000E,0x0008
	.dh 0x0000,0x000E,0x0008,0x0000,0x0016,0xFFB4,0x0054,0x0017
	.dh 0x0018,0x0084,0x0018,0x0064,0x0098,0x0019,0x00B4,0x009C
	.dh 0x001A,0x00F8,0x00AC,0x000F,0x0008,0xFFF8,0x0000,0x0008
	.dh 0x0000,0x001B,0x004C,0xFF50,0x001C,0x0098,0xFF5C,0x001D
	.dh 0x00CC,0xFF6C
Animation2:
	.dh	0x0003,0x0004,0x0000,0x0002,0x0004,0x0000,0x000E,0x0004
	.dh 0x0000,0x000E,0x0004,0x0000,0x0016,0xFFB0,0x0054,0x0017
	.dh 0x000C,0x0080,0x0018,0x0054,0x0094,0x0019,0x00A0,0x0094
	.dh 0x001A,0x00E0,0x00A4,0x000F,0x0004,0xFFF8,0x0000,0x0004 
	.dh 0x0000,0x001B,0x0048,0xFF50,0x001C,0x0090,0xFF5C,0x001D
	.dh 0x00C4,0xFF70
Animation3:
	.dh 0x0003,0x0000,0x0000,0x0002,0x0000,0x0000,0x000E,0x0000   
	.dh 0x0000,0x000E,0x0000,0x0000,0x0016,0xFFAC,0x0054,0x0017
	.dh 0x0008,0x007C,0x0018,0x0050,0x008C,0x0019,0x0094,0x0084
	.dh 0x001A,0x00D0,0x0090,0x000F,0x0000,0xFFF8,0x0000,0x0000
	.dh 0x0000,0x001B,0x0044,0xFF50,0x001C,0x0084,0xFF5C,0x001D
	.dh 0x00B0,0xFF70
Animation4:
	.dh 0x0003,0x0000,0x0000,0x0002,0x0000,0x0000,0x000E,0x0000 
	.dh 0x0000,0x000E,0x0000,0x0000,0x0016,0xFFAC,0x0054,0x0017
	.dh 0x0000,0x0074,0x0018,0x0044,0x007C,0x0019,0x0084,0x0070
	.dh 0x001A,0x00B4,0x0074,0x000F,0x0000,0xFFF8,0x0000,0x0000
	.dh 0x0000,0x001B,0x003C,0xFF50,0x001C,0x0078,0xFF5C,0x001D
	.dh 0x009C,0xFF6C
Animation5:	
	.dh 0x0003,0x0000,0x0000,0x0002,0x0000,0x0000,0x000E,0x0000
	.dh 0x0000,0x000E,0x0000,0x0000,0x0016,0xFFAC,0x0054,0x0017
	.dh 0x0004,0x0078,0x0018,0x0048,0x0084,0x0019,0x008C,0x0078
	.dh 0x001A,0x00C0,0x007C,0x000F,0x0000,0xFFF8,0x0000,0x0000
	.dh 0x0000,0x001B,0x0040,0xFF50,0x001C,0x0080,0xFF5C,0x001D
	.dh 0x00A4,0xFF70



NightmareSecondaryPosTable:  ; 3B83BC
    .dw Animation1
    .dw 12
    .dw Animation2
    .dw 8
    .dw Animation3
    .dw 8
    .dw Animation4
    .dw 8
    .dw Animation5
    .dw 12
    .dw Animation4
    .dw 8
    .dw Animation3
    .dw 8
    .dw Animation2
    .dw 8
    .dw 0,0

NightmareYPosTable:
	.dh 0x0001,0x0002,0x0003,0x0004,0x0005,0x0006,0x0005,0x0004
	.dh 0x0003,0x0002,0x0001,0x0000,0xFFFF,0xFFFE,0xFFFD,0xFFFC
	.dh 0xFFFB,0xFFFA,0xFFFB,0xFFFC,0xFFFD,0xFFFE,0xFFFF,0x0000
	.dh 0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000