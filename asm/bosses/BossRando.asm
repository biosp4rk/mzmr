.gba
.open "zm.gba","Serris.gba",0x8000000

.include "Lables.asm"

.org 0x805D5E0
	.word 0x805D600  ;changes a branch table

.org 0x805D17C		;checks if nightmare is in room. Used in effect A and B. Vanilla effect A and B should still work otherwise
	ldr		r2,=CheckNightmareRoom + 1
	bl	BXR2
	cmp		r0,0h
	beq		@@Normal
	mov		r0,0xF0
	lsl		r0,r0,3h
	mov		r1,0xC
	b		@@Store
@@Normal:
	mov		r0,0xA0
	lsl		r3,r0,13h
	lsl		r0,r0,1h
	mov		r1,2h
@@Store:
	strh	r0,[r2,4h]
	strb	r1,[r2,6h]
	str		r3,[r2]
	b 		0x805D3CA
.pool

.org 0x804FFB4
    .dw PlasmaBeamCheckBossSpriteID

.org 0x804FFCC
    .dw ChargedPlasmaBeamCheckBossSpriteID

.include "ExpandedSpriteList.asm"

;.org 0x8763E30
.org  0x8807E00
.include "serris\ai.asm"
.include "Yak\ZMYak.asm"
.include "Yak\Secondaries.asm"
.include "Arachnus\MainAI.asm"
.include "Arachnus\BodyParts.asm"
.include "Arachnus\Projectiles.asm"
.include "Nightmare\MainAI.asm"
.include "Nightmare\BodyParts.asm"
.include "Nightmare\Projectiles.asm"
.include "BOX FILES\BOXMainAI.asm"
.include "BOX FILES\BOX_Secondaries.asm"
.include "MegaX Files\Mega X.asm"
.include "MegaX Files\Mega X Orbs.asm"
.include "MegaX Files\Core X.asm"
.include "MegaX Files\Core X Shell.asm"
.include "Nettori/SamusEater/MainAI.asm"
.include "Nettori/SamusEater/Secondary.asm"
.include "Nettori/SamusEaterBud/MainAI.asm"
.include "Nettori/Nettori/MainAI.asm"
.include "Nettori/Nettori/Secondary.asm"
.include "BOX1/mainAI.asm"

WRapperR0:
    bx      r0
WrapperR1:
	bx		r1
WrapperR2:
	bx		r2
WrapperR3:
	bx		r3	
WRapperR4:
    bx      r4
WRapperR5:
    bx      r5
WrapperR6:
	bx		r6
WRapperR7:
    bx      r7
WrapperR8:
	bx		r8
WrapperR9:
	bx 		r9
WrapperR12:
	bx		r12

.notice "Custom Event Function"
.notice tohex(.)
SetnCheckEvent:
	push	r4-r5,r14	;r0 is 1 if set, 3 if check
	add		sp,-8
	mov		r4,r0
	ldr		r1,=CurrentArea
	ldrb	r1,[r1]
	cmp		r1,1
	bne		@@CheckRidley
	ldr		r1,=CurrentArea + 1 ;room id
	ldrb	r1,[r1]
	cmp		r1,5		;mua room
	beq		@@MuaEvent
	mov		r5,0x1E		;kraid event
	b 		@@CallEvent
@@MuaEvent:
	mov		r5,0x1C		;mua event
	b 		@@CallEvent
@@CheckRidley:
	cmp		r1,3
	bne		@@CheckChozodia
	mov		r5,0x25		;ridley event
	b 		@@CallEvent
@@CheckChozodia:
	cmp		r1,6
	bne		@@Return
	mov		r5,0x4A		;mecha event
@@CallEvent:
	mov		r1,r5
	ldr		r2,=EventFunctions + 1
	bl		WrapperR2
	cmp		r4,1
	bne		@@Return
	cmp		r5,0x4A
	beq		@@SetEscape
	mov		r0,r5
	ldr		r1,=UpdateMinimapChunk + 1
	bl		WrapperR1
	mov		r0,0xB
	mov		r1,0
	b 		@@PlaySong
@@SetEscape:
	mov 	r0,11h
	mov 	r1,22h			;22 for Mecha escape
	mov 	r2,0h			;GFX row
	mov 	r3,0h
	str 	r3,[sp,4h]
	ldr 	r3,=200h
	str 	r3,[sp]
	ldr 	r3,=400h
	ldr 	r4,=SpawnNewPrimarySprite + 1	;escape message set
	bl		WrapperR4
	mov		r0,8				;escape song
	mov		r1,0x40
@@PlaySong:
	ldr		r3,=PlaySong + 1
	bl		WrapperR3
@@Return:
	add		sp,8
	pop		r4-r5
	pop		r15
.pool

PlasmaBeamCheckBossSpriteID:
    bl      CheckBossSpriteID
    ldr     r0, =0x8050098 + 1
    bx      r0
.pool

ChargedPlasmaBeamCheckBossSpriteID:
    bl      CheckBossSpriteID
    ldr     r0, =0x8050216 + 1
    bx      r0
.pool

CheckBossSpriteID:
    ldrb    r2, [r6, 0x1D]
    mov     r1, r6
    add     r1, 0x32
    ldrb    r1, [r1]
    mov     r0, 0x80
    and     r0, r1
    cmp     r0, 0
    bne     @@SecondarySprite
    ldr     r1, =PrimarySpriteIDs
    b       @@Loop
@@SecondarySprite:
    ldr     r1, =SecondarySpriteIDs
@@Loop:
    ldrb    r0, [r1]
    cmp     r0, 0xFF
    beq     @@return
    cmp     r0, r2
    beq     @@RemoveProjectile
    add     r1, 1
    b       @@Loop
@@RemoveProjectile:
    mov     r3, r8
    mov     r0, 0
    strb    r0, [r3]
@@return:
    bx      r14
.pool

PrimarySpriteIDs:
    .db 0x8A, 0xD5, 0xFF
SecondarySpriteIDs:
    .db 0x50, 0x53, 0x57, 0x5A, 0x5C, 0xFF
	
.align
BOXGFX:
.import "BOX Files\BOXGFX.gfx.lz"
.align
NightmareGfx:
.import "Nightmare\graphics.gfx.lz"
.align
YakGfx:
.import "Yak\graphics.gfx.lz"
.align
BOXOAM:
.include "BOX FILES\BOX_OAM.asm"
.align
.include "Arachnus\Tables.asm"
.align
.include "BOX FILES\BOXTables.asm"
.align
.include "Yak\Tables.asm"
.align
.include "serris\table.asm"
.align
.include "Nightmare\Tables.asm"
.align
SpriteOAM:
.include "serris\oam.asm"
.align
.include "Nightmare\OAM.asm"
.align
YakOAM:
.include "Yak\OAM.asm"
.align
.include "Arachnus\OAM.asm"
.align
SpriteGfx:
.import "serris\graphics.gfx.lz"
.align
ArachGFX:
.import "Arachnus\graphics.gfx.lz"
.align
SpritePal:
.import "serris\palette"
.align
Phase2Pal:
.import "serris\palette2"
.align
Phase3Pal:
.import "serris\palette3"
.align
NightmarePal:
.import "Nightmare\pal"
.align
ArachPal:
.import "Arachnus\palette"
.align

BOXPal:
.import "BOX FILES\BOXPal"
.align
YakPal:
.import "Yak\SpritePal"
.align
MouthGlowPalettes:
.import "Yak\MouthGlows"
.align
.include "MegaX Files\OAM.asm"
.include "MegaX Files\Tables.asm"
.align
MegaXGFX:
.import "MegaX Files\Megax.gfx.lz"
.align
MegaXPal:
.import "MegaX Files\MegaxPal"
.align
NettoriGFX:
.import "Nettori/Nettori.gfx.lz" 
.align
NettoriPal:
.import "Nettori/Nettori.pal"
.align    
Pal36A480:
.import "Nettori/Nettori/36A480.pal"
.align
Pal36A4A0:
.import "Nettori/Nettori/36A4A0.pal"
.align
Pal36A4C0:
.import "Nettori/Nettori/36A4C0.pal"
.align
Pal36A4E0:
.import "Nettori/Nettori/36A4E0.pal"
.align
Pal36A500:
.import "Nettori/Nettori/36A500.pal"
.align
.include "Nettori/SamusEater/OAM.asm"
.align
.include "Nettori/SamusEaterBud/OAM.asm"
.align
.include "Nettori/Nettori/OAM.asm"
.align
.include "Nettori/SamusEater/Table.asm"
.align
.include "Nettori/Nettori/Table.asm"
.include "BOX1/OAM.asm"
.include "BOX1/Tables.asm"
.align
BOX1GFX:
.import "BOX1/BOX1.gfx.lz"
.align
BOX1Pal:
.import "BOX1/BOX1.pal"

;repointing sprite data
	.align
SpriteAIPointers:
	.import "New Sprite Data\NewPrimarySpriteAIPtrs.bin"
	.align
SSpriteAIPointers:
	.import "New Sprite Data\NewSecondarySpriteAIPtrs.bin"
	.align
PrimarySpriteStats:
	.import "New Sprite Data\NewPrimarySpriteStats.bin"
	.align
SecondarySpriteStats:
	.import "New Sprite Data\NewSecondarySpriteStats.bin"
	.align
SpriteGfxPointers:
	.import "New Sprite Data\NewSpriteGFXPtrs.bin"
	.align
SpritePalPointers:
	.import "New Sprite Data\NewSpritePalPtrs.bin"
	.align	
	
.include "SpritePtrs.asm"

.close