SamusEaterOAM0: ;836A238
	.dw	SamusEaterFrame1
	.dw	0x10
	.dw	SamusEaterFrame2
	.dw	0x10
	.dw	SamusEaterFrame3
	.dw	0x14
	.dw	SamusEaterFrame2
	.dw	0x10
	.dw	0, 0
	.align

SamusEaterOAM2: ;0x836a260
	.dw	SamusEaterFrame4
	.dw	0x4
	.dw	SamusEaterFrame5
	.dw	0x4
	.dw	SamusEaterFrame6
	.dw	0x4
	.dw	SamusEaterFrame7
	.dw	0xa
	.dw	SamusEaterFrame6
	.dw	0xa
	.dw	SamusEaterFrame7
	.dw	0xa
	.dw	SamusEaterFrame6
	.dw	0xa
	.dw	SamusEaterFrame7
	.dw	0xa
	.dw	SamusEaterFrame6
	.dw	0xa
	.dw	SamusEaterFrame7
	.dw	0xa
	.dw	SamusEaterFrame6
	.dw	0xa
	.dw	SamusEaterFrame5
	.dw	0x6
	.dw	SamusEaterFrame4
	.dw	0x6
	.dw	0, 0
	.align

SamusEaterOAMProjectileOAM1: ;0x836a350
	.dw	SamusEaterProjectileFrame1
	.dw	0x2
	.dw	SamusEaterProjectileFrame2
	.dw	0x2
	.dw	SamusEaterProjectileFrame3
	.dw	0x2
	.dw	SamusEaterProjectileFrame4
	.dw	0x2
	.dw	0, 0
	.align

SamusEaterOAMProjectileOAM2:    ;836a378:
	.dw	SamusEaterProjectileFrame5
	.dw	0x5
	.dw	SamusEaterProjectileFrame6
	.dw	0x5
	.dw	SamusEaterProjectileFrame7
	.dw	0x5
	.dw	0, 0
	.align

SamusEaterFrame1:
	.dh	0x1
	.dh	0x40e0, 0xc1e0, 0x9290
.align
SamusEaterFrame2:
	.dh	0x1
	.dh	0x40e0, 0xc1e0, 0x9288
.align
SamusEaterFrame3:
	.dh	0x1
	.dh	0x40e0, 0xc1e0, 0x9280
.align
SamusEaterFrame4:
	.dh	0x2
	.dh	0x00e0, 0x81e8, 0x9380
	.dh	0x80e0, 0x8008, 0x9384
.align
SamusEaterFrame5:
	.dh	0x2
	.dh	0x00e0, 0x81e8, 0x9386
	.dh	0x80e0, 0x8008, 0x938a
.align
SamusEaterFrame6:
	.dh	0x2
	.dh	0x00e1, 0x81e8, 0x938c
	.dh	0x80e1, 0x8008, 0x9390
.align
SamusEaterFrame7:
	.dh	0x2
	.dh	0x00e0, 0x81e8, 0x9392
	.dh	0x80e0, 0x8008, 0x9396
.align
SamusEaterProjectileFrame1:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9258
.align
SamusEaterProjectileFrame2:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9259
.align
SamusEaterProjectileFrame3:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9278
.align
SamusEaterProjectileFrame4:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9279
.align
SamusEaterProjectileFrame5:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9360
.align
SamusEaterProjectileFrame6:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9361
.align
SamusEaterProjectileFrame7:
	.dh	0x1
	.dh	0x00fc, 0x01fc, 0x9238
.align