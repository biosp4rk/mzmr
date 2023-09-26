.gba
.open "test.gba","Serris.gba",0x8000000

.definelabel SpriteID,0x49			;unused 
.definelabel SegmentID,0x28			;unused croco sprite
.definelabel BlockID,0x7			;unused
.definelabel YakID,0x8A
.definelabel LegID,0x28
.definelabel ChunkID,0x35
.definelabel ProjectileID,0x3A
.definelabel NightmareID,0x6C
.definelabel NightmareBodyID,0x1
.definelabel NightmareBeamID,0x2
.definelabel NightmareChunkID,0x4
.definelabel BOXSong,0x4D
.definelabel BOXID,0x3C
.definelabel BoxPartID,0x1
.definelabel BoxMissileID,0x2
.definelabel BoxBrainID,0x4
.definelabel ArachID,0x39			;arachnus ID
.definelabel PartsID,0x28			;secondary body parts
.definelabel ShellID,0x35
.definelabel FireID,0x3A
.definelabel SwipeID,0x1E
.definelabel VariaXID,0x9C
.definelabel MegaXID,0x1
.definelabel CoreXID,0x2
.definelabel MegaXOrbID,0x4

.definelabel CurrentArea,0x3000054
.definelabel CurrentRoomEntries,0x30000BC
.definelabel BGPositions,0x30000E4
.definelabel CurrSpriteData,0x3000738
.definelabel ProjectileAccel,0x3001610
.definelabel CurrBossData,0x3001630   ;seems to house OAM, and position information for bosses. Also used for Yakuza
.definelabel PrevCollisionCheck,0x30007F1
.definelabel PrevCollisionCheck1,0x30007F0
.definelabel CurrBossPattern,0x3000831
.definelabel CurrBossDirection,0x3000832
.definelabel GravityActive,0x3000833
.definelabel ProjectileData,0x3000A2C
.definelabel BG1XPos,0x30013B8
.definelabel BG1YPos,0x30013BA
.definelabel SamusPhysics,0x3001588
.definelabel DoorUnlockTimer,0x300007B
.definelabel BackupOfIORegisters,0x3000088
.definelabel CurrentAffectingClip,0x30000DC
.definelabel SubSpriteData,0x300070C
.definelabel FrameCounter8Bit,0x3000C77
.definelabel BG1XPosition,0x30013B8
.definelabel CurrentMusicTrack,0x3001D1C
.definelabel SpriteSlot0,0x30001AC
.definelabel FrameCounter,0x3000C77
.definelabel BossWork,0x300080C




.definelabel SpawnSecondarySprite,0x800E258
;.definelabel CheckClip,0x800F688
.definelabel CheckEndOfAnimation,0x800FBC8
.definelabel CheckAlmostEndOfAnimation,0x800FC00
.definelabel CheckEndOfAnimation2,0x800FC3C
.definelabel CheckAlmostEndOfAnimation2,0x800FC84
.definelabel CheckNearSprite,0x800FDE0
.definelabel SpriteDead,0x8011084
.definelabel CountNumberOfGivenSecondarySprite,0x8010738	
.definelabel SpawnDebris,0x8011E48
.definelabel ShakeScreen,0x8055378
.definelabel PlaySound1,0x8002A18
.definelabel PlaySong,0x80039F4
.definelabel CheckCollisionAtPosition,0x800F360
.definelabel CheckVerticalCollisionAtPositionSlopes,0x800F47C
.definelabel MakeSpriteFaceSamusDirection,0x800F8E0
.definelabel MakeSpriteFaceAwayFromSamusDirection,0x800F944
.definelabel RotateSpriteTowardsSamus,0x800FA78
.definelabel CheckEndSubspriteAnim,0x800FCD0
.definelabel CheckNearEndOfSubSpriteData1Anim,0x800FD08
.definelabel MoveBOXMissile,0x8010944
.definelabel SyncCurrandSubspritePos,0x801136C
.definelabel SetSpriteSplashEffect,0x8011620
.definelabel SpriteCheckOutOfRoomEffect,0x80116CC
.definelabel PlaySoundIfNotPlaying,0x8002B20
.definelabel PlayMusic,0x80039F4
.definelabel SpriteCheckInRoomEffect,0x8011718
.definelabel SyncCurrandSubspritePosandOAM,0x80113B0
.definelabel UpdateSubspriteAnim,0x8011330
.definelabel SetParticleEffect,0x80540EC
.definelabel UpdateMinimapChunk,0x806CD84
.definelabel StartHorizontalScreenShake,0x8055378
.definelabel PlaySound3,0x8002A18; ?
.definelabel PlaySound5,0x8002A18; ?
.definelabel CheckCollisionXY,0x800F688
.definelabel CheckEndOfSpriteAnimation,0x800FBC8
.definelabel VertScreenShake,0x8055344
.definelabel HoriScreenShake,0x8055378
.definelabel DivideSigned,0x808AC34
.definelabel DivideUnsigned,0x808ADE0
.definelabel Divide_Signed,0x808AC34
.definelabel Divide_Unsigned,0x808ADE0
.definelabel SpriteDeath,0x8011084
.definelabel SineYValues,0x808C71C
.definelabel CheckEndOfSpriteAnim_Curr,0x800FBC8
.definelabel CheckSamusNearSprite_LeftRight,0x800FDE0
.definelabel CountPrimarySprites,0x80106E8
.definelabel ProjectileHitSprite,0x80505AC
.definelabel ChargedBeamHitSprite,0x8050654
.definelabel IceBeamHitSprite,0x8050724
.definelabel ChargedIceBeamHitSprite,0x8050828
.definelabel CheckObjectsTouching,0x800E6F8
.definelabel BXR2,0x808AC00
.definelabel SpriteAIPointers,0x875E8C0
.definelabel SSpriteAIPointers,0x875F1E8
.definelabel SpriteGfxPointers,0x875EBF8
.definelabel SpritePalPointers,0x875EEF0


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


;.org 0x8763E30
.org  0x8800000
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
WrapperR0:
	bx	r0
WrapperR1:
	bx	r1
WrapperR2:
	bx	r2
WrapperR4:
	bx	r4	
.notice tohex(.)
SetnCheckEvent:
	push	r4-r5,r14	;r0 is 1 if set, 3 if check
	add		sp,-8
	mov		r4,r0
	ldr		r1,=CurrentArea
	ldrb	r1,[r1]
	cmp		r1,1
	bne		@@CheckRidley
	mov		r5,0x1E		;kraid event
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
BlockPlasma:
	push    r4-r7,r14
    add     sp,-0x14
    ldr     r5,=CurrSpriteData
	ldrh	r0,[r5]
	mov		r1,0x80
	lsl		r1,r1,8
	and		r0,r1
	cmp		r0,0		;skip if ignore projectiles flag is on
	beq		@@NotIgnoring
	add		sp,0x14
	pop		r4-r7
	pop		r0
	bx		r0
.pool
@@NotIgnoring:
    ldrh    r1,[r5,2]
    ldrh    r2,[r5,4]
    ldrh    r0,[r5,0xA]
    add     r0,r1,r0
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10		
    str     r0,[sp,0x10]
    ldrh    r0,[r5,0xC]
    add     r1,r1,r0
    lsl     r1,r1,0x10
    lsr     r1,r1,0x10
    str     r1,[sp,0x4]
    ldrh    r0,[r5,0xE]
    add     r0,r2,r0
    lsl     r0,r0,0x10
    lsr     r0,r0,0x10
    str     r0,[sp,8]
    ldrh    r0,[r5,0x10]
    add     r2,r2,r0
    lsl     r2,r2,0x10
    lsr     r2,r2,0x10
    str     r2,[sp,0xC]
    ldr     r4,=ProjectileData
	mov		r0,0xE0
	lsl		r1,r1,1
	add		r6,r4,r1
@@Loop:
	ldrh	r0,[r4]
	mov		r1,1
	and		r0,r1
	cmp		r0,0
	beq		@@Inc1
	ldrb	r0,[r4,0xF]
	cmp		r0,4		;plasma
	beq		@@CheckTouch
	cmp		r0,0xA		;charged plasma
	bne		@@Inc1
@@CheckTouch:
	ldr		r0,[sp,0x10]
	str		r0,[sp]
	ldrh	r1,[r4,8]
	ldrh	r3,[r4,0xA]
	ldrh	r0,[r4,0x14]
	add		r0,r1,r0
	lsl		r0,r0,0x10
	lsr		r0,r0,0x10
	ldrh	r2,[r4,0x16]
	add		r1,r1,r2
	lsl		r1,r1,0x10
	lsr		r1,r1,0x10
	ldrh	r2,[r4,0x18]
	add		r2,r2,r3
	lsl		r2,r2,0x10
	lsr		r2,r2,0x10
	ldrh	r7,[r4,0x1A]
	add		r3,r3,r7
	lsl		r3,r3,0x10
	lsr		r3,r3,0x10
	ldr		r7,=CheckObjectsTouching + 1
	bl		WrapperR7
	cmp		r0,0
	beq		@@Inc1
	ldrb	r0,[r4,0xF]
	cmp		r0,0xA
	beq		@@ChargedPlasma
    ldr     r0,=Equipment	;uncharged plasma
    ldrb    r1,[r0,0xD]
    mov     r0,1
    and     r0,r1
    cmp     r0,0
    beq     @@_80500E0
    mov     r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_80500C6
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_80500F0
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,6
    ldr     r7,=IceBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_80500C6:
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_805011C
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,5
    ldr     r7,=ProjectileHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_80500E0:
    mov     r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8050114
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_8050102
@@_80500F0:
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,5
    ldr     r7,=IceBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_8050102:
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,4
    ldr     r7,=IceBeamHitSprite + 1
    b       @@KillProjectile
@@_8050114:
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_805012E
@@_805011C:
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,4
    ldr     r7,=ProjectileHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_805012E:
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,3
    ldr     r7,=ProjectileHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@Loop1:
	b 		@@Loop
@@Inc1:
	b 		@@Inc
.pool
@@ChargedPlasma:
	ldr     r0,=Equipment
    ldrb    r1,[r0,0xD]
    mov     r0,1
    and     r0,r1
    cmp     r0,0
    beq     @@_805025E
    mov     r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8050244
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_805026E
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0x18
    ldr     r7,=ChargedIceBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_8050244:
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_805029A
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0x14
    ldr     r7,=ChargedBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_805025E:
    mov     r0,2
    and     r0,r1
    cmp     r0,0
    beq     @@_8050292
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_8050280
@@_805026E:
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0x14
    ldr     r7,=ChargedIceBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_8050280:
    mov     r0,0x33
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0x10
    ldr     r7,=ChargedIceBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_8050292:
    mov     r0,4
    and     r0,r1
    cmp     r0,0
    beq     @@_80502AC
@@_805029A:
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0x10
    ldr     r7,=ChargedBeamHitSprite + 1
	bl		WrapperR7
    b       @@KillProjectile
@@_80502AC:
    mov     r0,0x2E
    str     r0,[sp]
    ldr     r0,=CurrSpriteData
    ldrh    r1,[r4,8]
    ldrh    r2,[r4,0xA]
    mov     r3,0xC
    ldr     r7,=ChargedBeamHitSprite + 1
	bl		WrapperR7
@@KillProjectile:
	mov		r0,0
	strb	r0,[r4]	;kill projectile
@@Inc:
	add		r4,0x1C
	cmp		r4,r6
	bls		@@Loop1
@@Return:
	add		sp,0x14
	pop		r4-r7
	pop		r0
	bx		r0
.pool
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

; primary sprite stats
.org PrimarySpriteStats + NightmareID * 0x12
    .halfword 0x320   ; health
    .halfword 0x1E   ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb

;secondary sprites
;.org SecondarySpriteStats + NightmareBodyID * 0x12
;    .halfword 0x2C0      ; health
;    .halfword 0      ; damage
;    .halfword 6      ; weakness
;    .halfword 0		 ; no drop
;    .halfword 0x100	     ; small health
;    .halfword 0x100      ; large health
;    .halfword 0x100      ; missile
;    .halfword 0x80      ; super missile
;    .halfword 0x80      ; power bomb
;
;.org SecondarySpriteStats + NightmareBeamID * 0x12
;    .halfword 1    		; health
;    .halfword 0x20      ; damage
;    .halfword 0         ; weakness
;    .halfword 0x400     ; no drop
;    .halfword 0			; small health
;    .halfword 0    		; large health
;    .halfword 0    		; missile
;    .halfword 0		    ; super missile
;    .halfword 0      	; power bomb
;	
;.org SecondarySpriteStats + NightmareChunkID * 0x12
;    .halfword 0    		; health
;    .halfword 0      ; damage
;    .halfword 0         ; weakness
;    .halfword 0x400  ; no drop
;    .halfword 0		 ; small health
;    .halfword 0      ; large health
;    .halfword 0      ; missile
;    .halfword 0	     ; super missile
;    .halfword 0      ; power bomb
	
	
; AI pointer
.org SpriteAIPointers + NightmareID * 4
    .word NightmareMain + 1
	
;Body Parts AI pointer
;.org SSpriteAIPointers + NightmareBodyID * 4
;    .word NightmarePartMain + 1
	
;Beam AI pointer
;.org SSpriteAIPointers + NightmareBeamID * 4
;    .word NightmareBeamMain + 1
	
;projectile AI pointer
;.org SSpriteAIPointers + NightmareChunkID * 4
;    .word NightmareChunkMain + 1
	
; graphics pointer
.org SpriteGfxPointers + (NightmareID - 0x10) * 4
    .word NightmareGfx

; palette pointer
.org SpritePalPointers + (NightmareID - 0x10) * 4
    .word NightmarePal


; primary sprite stats
.org PrimarySpriteStats + YakID * 0x12
    .halfword 0x3E8    ; health
    .halfword 0x1E     ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0       ; no drop
    .halfword 0x100   ; small health
    .halfword 0x150   ;large health
    .halfword 0x100   ; missile
    .halfword 0x66    ; super missile
    .halfword 0x4A    ; power bomb
	
;secondary sprites
;.org SecondarySpriteStats + LegID * 0x12
;    .halfword 1	 ; health
;    .halfword 0x41    ; damage
;    .halfword 0      ; weakness
;    .halfword 0x400  ; no drop
;    .halfword 0	     ; small health
;    .halfword 0      ; large health
;    .halfword 0      ; missile
;    .halfword 0      ; super missile
;    .halfword 0      ; power bomb
;	
;.org SecondarySpriteStats + ChunkID * 0x12
;    .halfword 0 	 ; health
;    .halfword 0      ; damage
;    .halfword 0      ; weakness
;    .halfword 0x400  ; no drop
;    .halfword 0	     ; small health
;    .halfword 0      ; large health
;    .halfword 0      ; missile
;    .halfword 0      ; super missile
;    .halfword 0      ; power bomb
;	
;.org SecondarySpriteStats + ProjectileID * 0x12
;    .halfword 1 	 ; health
;    .halfword 0x2D   ; damage
;    .halfword 0x1A   ; weakness
;    .halfword 0x19A  ; no drop
;    .halfword 0x25   ; small health
;    .halfword 0x10   ; large health
;    .halfword 0x200  ; missile
;    .halfword 0x30   ; super missile
;    .halfword 1	     ; power bomb

; AI pointer
.org SpriteAIPointers + YakID * 4
    .word Yakuza_Main + 1

;.org SSpriteAIPointers + LegID * 4
;    .word LegsAI + 1
	
;.org SSpriteAIPointers + ChunkID * 4
;    .word ChunkAI + 1
	
;.org SSpriteAIPointers + ProjectileID * 4
 ;   .word ProjectileAI + 1

; graphics pointer
.org SpriteGfxPointers + (YakID - 0x10) * 4
    .word YakGfx

; palette pointer
.org SpritePalPointers + (YakID - 0x10) * 4
    .word YakPal

; primary sprite stats
.org PrimarySpriteStats + SpriteID * 0x12
    .halfword 0xC9   ; health
    .halfword 0x1E   ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb

;secondary sprites
;.org SecondarySpriteStats + BlockID * 0x12
;    .halfword 0      ; health
;    .halfword 0      ; damage
;    .halfword 0      ; weakness
;    .halfword 0x400  ; no drop
;    .halfword 0	     ; small health
;    .halfword 0      ; large health
;    .halfword 0      ; missile
;    .halfword 0      ; super missile
;    .halfword 0      ; power bomb
;
;.org SecondarySpriteStats + SegmentID * 0x12
;    .halfword 1    ; health
;    .halfword 0x1E      ; damage
;    .halfword 0         ; weakness
;    .halfword 0         ; no drop
;    .halfword 0x80	; small health
;    .halfword 0x80      ; large health
;    .halfword 0x200     ; missile
;    .halfword 0x100     ; super missile
;    .halfword 0      ; power bomb

; AI pointer
.org SpriteAIPointers + SpriteID * 4
    .word SerrisSpriteAI + 1

; projectile AI pointer
;.org SSpriteAIPointers + SegmentID * 4
;    .word SegmentMainAI + 1

;.org SSpriteAIPointers + BlockID * 4
;    .word SerrisBlockMainAI + 1

; graphics pointer
.org SpriteGfxPointers + (SpriteID - 0x10) * 4
    .word SpriteGfx

; palette pointer
.org SpritePalPointers + (SpriteID - 0x10) * 4
    .word SpritePal
	
.org PrimarySpriteStats + BOXID * 0x12
    .halfword 0x1    ; health
    .halfword 0x0     ; damage
    .halfword 0    ; weakness
    .halfword 0x400       ; no drop
    .halfword 0   ; small health
    .halfword 0   ;large health
    .halfword 0   ; missile
    .halfword 0    ; super missile
    .halfword 0    ; power bomb
	
; graphics pointer
.org SpriteGfxPointers + (BOXID - 0x10) * 4
    .word BOXGFX

; palette pointer
.org SpritePalPointers + (BOXID - 0x10) * 4
    .word BOXPal
	
.org SpriteAIPointers + BOXID * 4
    .word Box2_AI + 1
	
; primary sprite stats
.org PrimarySpriteStats + ArachID * 0x12
    .halfword 0xC9   ; health
    .halfword 0x1E   ; damage
    .halfword 1|2|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
; graphics pointer
.org SpriteGFXPointers + (ArachID - 0x10) * 4
    .word ArachGFX

; palette pointer
.org SpritePalPointers + (ArachID - 0x10) * 4
    .word ArachPal
	
; AI pointer
.org SpriteAIPointers + ArachID * 4
    .word MainAI + 1
	
.org PrimarySpriteStats + VariaXID * 0x12
    .halfword 0x1    ; health
    .halfword 0x1     ; damage
    .halfword 0    ; weakness
    .halfword 0  ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x60      ; large health
    .halfword 0x250      ; missile
    .halfword 0x50      ; super missile
    .halfword 0      ; power bomb
	
;secondary sprites
;.org SecondarySpriteStats + MegaXID * 0x12
;    .halfword 0x64	 ; health
;    .halfword 0x40    ; damage
;    .halfword 0x1      ; weakness
;    .halfword 0  ; no drop
;    .halfword 0x1A0	     ; small health
;    .halfword 0x200      ; large health
;    .halfword 0x60      ; missile
;    .halfword 0      ; super missile
;    .halfword 0      ; power bomb
;	
;.org SecondarySpriteStats + CoreXID * 0x12
;    .halfword 0xB4	 ; health
;    .halfword 0x40      ; damage
;    .halfword 0x8      ; weakness
;    .halfword 0  ; no drop
;    .halfword 0x100	     ; small health
;    .halfword 0x60      ; large health
;    .halfword 0x250      ; missile
;    .halfword 0x50      ; super missile
;    .halfword 0      ; power bomb
;	
;.org SecondarySpriteStats + MegaXOrbID * 0x12
;    .halfword 1 	 ; health
;    .halfword 0x20   ; damage
;    .halfword 1   ; weakness
;    .halfword 0  ; no drop
;    .halfword 0x100	     ; small health
;    .halfword 0x60      ; large health
;    .halfword 0x250      ; missile
;    .halfword 0x50      ; super missile
;    .halfword 0      ; power bomb

; AI pointer
.org SpriteAIPointers + VariaXID * 4
    .word CoreXMain_AI + 1

; graphics pointer
.org SpriteGfxPointers + (VariaXID - 0x10) * 4
    .word MegaXGFX

; palette pointer
.org SpritePalPointers + (VariaXID - 0x10) * 4
    .word MegaXPal
	
.notice "Serris Segment iDOffsets = new int[] { " + tohex(Segment1) + ", " + tohex(Segment2) + ", "+ tohex(Segment3) + ", "+ tohex(Segment4) + ", "+ tohex(Segment5) + ", "+ tohex(Segment6) + ", "+ tohex(Segment7) + ", "+ tohex(Segment8) + ", "+ tohex(Segment9) + ", "+ tohex(Segment10) + " }"
.notice "Serris Block iDOffsets = new int[] { " + tohex(SerrisBlock1) + ", " + tohex(SerrisBlock2) + ", " + tohex(SerrisBlock3) + ", " + tohex(SerrisBlock4) + ", " + tohex(SerrisBlock5) + ", " + tohex(SerrisBlock6) + ", " + tohex(SerrisBlock7) + ", " + tohex(SerrisBlock8) + ", " +tohex(SerrisBlock9) + " }"
.notice "Yakuza Leg iDOffsets = new int[] { " + tohex(YakuzaLeg1) + ", " + tohex(YakuzaLeg2) + " }"
.notice "Yakuza Projectile iDOffsets = new int[] { " + tohex(YakuzaFire1) + ", " + tohex(YakuzaFire2) + ", " + tohex(YakuzaFire3) + ", " + tohex(YakuzaFire4) + " }"
.notice "Yakuza Chunk iDOffsets = new int[] { " + tohex(YakuzaChunk1) + ", " + tohex(YakuzaChunk2) + ", " + tohex(YakuzaChunk3) + ", "+ tohex(YakuzaChunk4) + ", " + tohex(YakuzaChunk5) + ", " + tohex(YakuzaChunk6) + " }"
.notice "Nightmare Part iDOffsets = new int[] { " + tohex(NightmarePart1) + ", " + tohex(NightmarePart2) + ", " + tohex(NightmarePart3) + ", " + tohex(NightmarePart4) + ", " + tohex(NightmarePart5) + ", " + tohex(NightmarePart6) + ", " + tohex(NightmarePart7) + ", " + tohex(NightmarePart8) + ", " + tohex(NightmarePart9) + ", " + tohex(NightmarePart10) + ", " + tohex(NightmarePart11) + ", "+ tohex(NightmarePart12) + ", "+ tohex(NightmarePart13) + " }"
.notice "Nightmare Beam iDOffsets = new int[] { " + tohex(NightmareBeam) + " }"
.notice "Nightmare Chunk iDOffsets = new int[] { " + tohex(NightmareChunk1) + ", " + tohex(NightmareChunk2) + ", " + tohex(NightmareChunk3) + ", " + tohex(NightmareChunk4) + ", " + tohex(NightmareChunk5) + ", " + tohex(NightmareChunk6) + ", " + tohex(NightmareChunk7) + ", " + tohex(NightmareChunk8) + " }"
.notice "BOX Part iDOffsets = new int[] { " + tohex(BoxPart1) + ", " + tohex(BoxPart2) + ", " + tohex(BoxPart3) + ", " + tohex(BoxPart4) + ", " + tohex(BoxPart5) + ", " + tohex(BoxPart6) + ", " + tohex(BoxPart7) + ", " + tohex(BoxPart8) + ", " + tohex(BoxPart9) + ", " + tohex(BoxPart10) + ", " + tohex(BoxPart11) + " }"
.notice "BOX Missile iDOffsets = new int[] { " + tohex(BoxMissile1) + ", " + tohex(BoxMissile2) + ", " + tohex(BoxMissile3) + ", " + tohex(BoxMissile4) + " }"
.notice "BOX Brain iDOffsets = new int[] { " + tohex(BoxBrain1) + ", " + tohex(BoxBrain2) + " }"
.notice "MEGAX Shell iDOffsets = new int[] { " + tohex(CoreX) + " }"
.notice "MEGAX iDOffsets = new int[] { " + tohex(BIGX) + " }"
.notice "MEGAX Orb iDOffsets = new int[] { " + tohex(XOrb1) + ", " + tohex(XOrb2) + ", " + tohex(XOrb3) + ", " + tohex(XOrb4) + ", " + tohex(XOrb5) + ", " + tohex(XOrb6) + ", " + tohex(XOrb7) + ", " + tohex(XOrb8) + " }"


.close