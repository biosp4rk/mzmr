.definelabel SpriteID,0xD2			;serris main.... 
.definelabel SegmentID,0x28			;unused croco sprite
.definelabel BlockID,0x7			;unused
.definelabel YakID,0x8A				;yakuza main; uses unused croco sprite
.definelabel LegID,0x4D
.definelabel ChunkID,0x4E
.definelabel ProjectileID,0x4F
.definelabel NightmareID,0x6C		;nightmare main; uses unused geki tai sprite
.definelabel NightmareBodyID,0x50
.definelabel NightmareBeamID,0x51
.definelabel NightmareChunkID,0x52
.definelabel BOXSong,0x4D
.definelabel BOXID,0xD3				;BOX Main
.definelabel BoxPartID,0x53
.definelabel BoxMissileID,0x54
.definelabel BoxBrainID,0x55
.definelabel ArachID,0xD4			;arachnus main
.definelabel PartsID,0x56			;secondary body parts
.definelabel ShellID,0x57
.definelabel FireID,0x58
.definelabel SwipeID,0x59
.definelabel VariaXID,0xD5			;VariaX main
.definelabel MegaXID,0x5A
.definelabel CoreXID,0x5B
.definelabel MegaXOrbID,0x5C
.definelabel NettoriSpriteID, 0xD6  ;Nettori main
.definelabel NettoriPartSpriteID, 0x5D 
.definelabel NettoriBeamSpriteID, 0x5E  
.definelabel NettoriHealth, 0x384
.definelabel NettoriPhase1Music, 0x3F   ;Kiru Giru
.definelabel NettoriPhase2Music, 0x3E   ;Kiru Giru
.definelabel SamusEaterSpriteID, 0xD7  ;Samus eater main
.definelabel SamusEaterAlwaysSpawnSporeSpriteID, 0xD8
.definelabel SamusEaterProjectileSpriteID, 0x5F
.definelabel SamusEaterBudSpriteID, 0xD9 

; primary sprite stats
.org PrimarySpriteStats + NightmareID * 0x12
    .halfword 0x1F4   ; health
    .halfword 0x1E   ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb

;secondary sprites
.org SecondarySpriteStats + NightmareBodyID * 0x12
    .halfword 0x190      ; health
    .halfword 0x1E      ; damage
    .halfword 0x1B      ; weakness
    .halfword 0		 ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x100      ; large health
    .halfword 0x100      ; missile
    .halfword 0x80      ; super missile
    .halfword 0x80      ; power bomb

.org SecondarySpriteStats + NightmareBeamID * 0x12
    .halfword 1    		; health
    .halfword 0x20      ; damage
    .halfword 0         ; weakness
    .halfword 0x400     ; no drop
    .halfword 0			; small health
    .halfword 0    		; large health
    .halfword 0    		; missile
    .halfword 0		    ; super missile
    .halfword 0      	; power bomb
	
.org SecondarySpriteStats + NightmareChunkID * 0x12
    .halfword 0    		; health
    .halfword 0      ; damage
    .halfword 0         ; weakness
    .halfword 0x400  ; no drop
    .halfword 0		 ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0	     ; super missile
    .halfword 0      ; power bomb
	
	
; AI pointer
.org SpriteAIPointers + NightmareID * 4
    .word NightmareMain + 1
	
;Body Parts AI pointer
.org SSpriteAIPointers + NightmareBodyID * 4
    .word NightmarePartMain + 1
	
;Beam AI pointer
.org SSpriteAIPointers + NightmareBeamID * 4
    .word NightmareBeamMain + 1
	
;projectile AI pointer
.org SSpriteAIPointers + NightmareChunkID * 4
    .word NightmareChunkMain + 1
	
; graphics pointer
.org SpriteGfxPointers + (NightmareID - 0x10) * 4
    .word NightmareGfx

; palette pointer
.org SpritePalPointers + (NightmareID - 0x10) * 4
    .word NightmarePal


; primary sprite stats
.org PrimarySpriteStats + YakID * 0x12
    .halfword 0x320    ; health
    .halfword 0x1E     ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0       ; no drop
    .halfword 0x100   ; small health
    .halfword 0x150   ;large health
    .halfword 0x100   ; missile
    .halfword 0x66    ; super missile
    .halfword 0x4A    ; power bomb
	
;secondary sprites
.org SecondarySpriteStats + LegID * 0x12
    .halfword 1	 ; health
    .halfword 0x32    ; damage
    .halfword 0      ; weakness
    .halfword 0x400  ; no drop
    .halfword 0	     ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + ChunkID * 0x12
    .halfword 0 	 ; health
    .halfword 0      ; damage
    .halfword 0      ; weakness
    .halfword 0x400  ; no drop
    .halfword 0	     ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + ProjectileID * 0x12
    .halfword 1 	 ; health
    .halfword 0x2D   ; damage
    .halfword 0x1A   ; weakness
    .halfword 0x19A  ; no drop
    .halfword 0x25   ; small health
    .halfword 0x10   ; large health
    .halfword 0x200  ; missile
    .halfword 0x30   ; super missile
    .halfword 1	     ; power bomb

; AI pointer
.org SpriteAIPointers + YakID * 4
    .word Yakuza_Main + 1

.org SSpriteAIPointers + LegID * 4
    .word LegsAI + 1
	
.org SSpriteAIPointers + ChunkID * 4
    .word ChunkAI + 1
	
.org SSpriteAIPointers + ProjectileID * 4
    .word ProjectileAI + 1

; graphics pointer
.org SpriteGfxPointers + (YakID - 0x10) * 4
    .word YakGfx

; palette pointer
.org SpritePalPointers + (YakID - 0x10) * 4
    .word YakPal

; primary sprite stats
.org PrimarySpriteStats + SpriteID * 0x12
    .halfword 0x12C   ; health
    .halfword 0x1E   ; damage
    .halfword 1|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb

;secondary sprites
.org SecondarySpriteStats + BlockID * 0x12
    .halfword 0      ; health
    .halfword 0      ; damage
    .halfword 0      ; weakness
    .halfword 0x400  ; no drop
    .halfword 0	     ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb

.org SecondarySpriteStats + SegmentID * 0x12
    .halfword 1    ; health
    .halfword 0x1E      ; damage
    .halfword 0         ; weakness
    .halfword 0         ; no drop
    .halfword 0x80	; small health
    .halfword 0x80      ; large health
    .halfword 0x200     ; missile
    .halfword 0x100     ; super missile
    .halfword 0      ; power bomb

; AI pointer
.org SpriteAIPointers + SpriteID * 4
    .word SerrisSpriteAI + 1

; projectile AI pointer
.org SSpriteAIPointers + SegmentID * 4
    .word SegmentMainAI + 1

.org SSpriteAIPointers + BlockID * 4
    .word SerrisBlockMainAI + 1

; graphics pointer
.org SpriteGfxPointers + (SpriteID - 0x10) * 4
    .word SpriteGfx

; palette pointer
.org SpritePalPointers + (SpriteID - 0x10) * 4
    .word SpritePal
	
.org PrimarySpriteStats + BOXID * 0x12
    .halfword 0x1    ; health
    .halfword 0x32     ; damage
    .halfword 0    ; weakness
    .halfword 0x400       ; no drop
    .halfword 0   ; small health
    .halfword 0   ;large health
    .halfword 0   ; missile
    .halfword 0    ; super missile
    .halfword 0    ; power bomb
	
;secondary sprites
.org SecondarySpriteStats + BoxPartID * 0x12
    .halfword 0x1F4	 ; health
    .halfword 0x3C    ; damage
    .halfword 0x19      ; weakness
    .halfword 0  ; no drop
    .halfword 0x1A0	     ; small health
    .halfword 0x200      ; large health
    .halfword 0x60      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + BoxMissileID * 0x12
    .halfword 5 	 ; health
    .halfword 0x32      ; damage
    .halfword 0x3B      ; weakness
    .halfword 0  ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x60      ; large health
    .halfword 0x250      ; missile
    .halfword 0x50      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + BoxBrainID * 0x12
    .halfword 1 	 ; health
    .halfword 0x2D   ; damage
    .halfword 0   ; weakness
    .halfword 0  ; no drop
    .halfword 0   ; small health
    .halfword 0   ; large health
    .halfword 0x200  ; missile
    .halfword 0x200   ; super missile
    .halfword 0	     ; power bomb
	
; AI pointer
.org SpriteAIPointers + BOXID * 4
    .word Box2_AI + 1

.org SSpriteAIPointers + BoxPartID * 4
    .word Box2Part_AI + 1
	
.org SSpriteAIPointers + BoxMissileID * 4
    .word Box2Missile_AI + 1
	
.org SSpriteAIPointers + BoxBrainID * 4
    .word Box2BrainTop_AI + 1

; graphics pointer
.org SpriteGfxPointers + (BOXID - 0x10) * 4
    .word BOXGFX

; palette pointer
.org SpritePalPointers + (BOXID - 0x10) * 4
    .word BOXPal
	
; primary sprite stats
.org PrimarySpriteStats + ArachID * 0x12
    .halfword 0x2BC   ; health
    .halfword 0x1E   ; damage
    .halfword 1|2|8|0x10    ; weakness
    .halfword 0      ; no drop
    .halfword 0x200  ; small health
    .halfword 0x200  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
;secondary sprites
.org SecondarySpriteStats + PartsID * 0x12
    .halfword 0      ; health
    .halfword 0      ; damage
    .halfword 0      ; weakness
    .halfword 0		 ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x100      ; large health
    .halfword 0x100      ; missile
    .halfword 0x80      ; super missile
    .halfword 0x80      ; power bomb

.org SecondarySpriteStats + ShellID * 0x12
    .halfword 1    		; health
    .halfword 0x20      ; damage
    .halfword 0         ; weakness
    .halfword 0         ; no drop
    .halfword 0x80	; small health
    .halfword 0x80      ; large health
    .halfword 0x200     ; missile
    .halfword 0x100     ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + FireID * 0x12
    .halfword 0    		; health
    .halfword 0x1A      ; damage
    .halfword 0         ; weakness
    .halfword 0x400  ; no drop
    .halfword 0		 ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0	     ; super missile
    .halfword 0      ; power bomb

.org SecondarySpriteStats + SwipeID * 0x12
    .halfword 0    		; health
    .halfword 0x18      ; damage
    .halfword 0         ; weakness
    .halfword 0x400  ; no drop
    .halfword 0		 ; small health
    .halfword 0      ; large health
    .halfword 0      ; missile
    .halfword 0	     ; super missile
    .halfword 0      ; power bomb
	
; AI pointer
.org SpriteAIPointers + ArachID * 4
    .word MainAI + 1
	
;Body Parts AI pointer
.org SSpriteAIPointers + PartsID * 4
    .word BodyPartsMainAI + 1
	
;Shell AI pointer
.org SSpriteAIPointers + ShellID * 4
    .word ShellAI + 1
	
;projectile AI pointer
.org SSpriteAIPointers + FireID * 4
    .word FireballMainAI + 1
	
;projectile AI pointer
.org SSpriteAIPointers + SwipeID * 4
    .word SwipeMainAI + 1
	
; graphics pointer
.org SpriteGfxPointers + (ArachID - 0x10) * 4
    .word ArachGFX

; palette pointer
.org SpritePalPointers + (ArachID - 0x10) * 4
    .word ArachPal
	
.org PrimarySpriteStats + VariaXID * 0x12
    .halfword 0x1    ; health
    .halfword 0x19     ; damage
    .halfword 0    ; weakness
    .halfword 0  ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x60      ; large health
    .halfword 0x250      ; missile
    .halfword 0x50      ; super missile
    .halfword 0      ; power bomb
	
;secondary sprites
.org SecondarySpriteStats + MegaXID * 0x12
    .halfword 0x32	 ; health
    .halfword 0x40    ; damage
    .halfword 0x9      ; weakness
    .halfword 0  ; no drop
    .halfword 0x1A0	     ; small health
    .halfword 0x200      ; large health
    .halfword 0x60      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + CoreXID * 0x12
    .halfword 0x64	 ; health
    .halfword 0x40      ; damage
    .halfword 0x8      ; weakness
    .halfword 0  ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x60      ; large health
    .halfword 0x250      ; missile
    .halfword 0x50      ; super missile
    .halfword 0      ; power bomb
	
.org SecondarySpriteStats + MegaXOrbID * 0x12
    .halfword 1 	 ; health
    .halfword 0x20   ; damage
    .halfword 9   ; weakness
    .halfword 0  ; no drop
    .halfword 0x100	     ; small health
    .halfword 0x60      ; large health
    .halfword 0x250      ; missile
    .halfword 0x50      ; super missile
    .halfword 0      ; power bomb

; AI pointer
.org SpriteAIPointers + VariaXID * 4
    .word CoreXMain_AI + 1

; graphics pointer
.org SpriteGfxPointers + (VariaXID - 0x10) * 4
    .word MegaXGFX

; palette pointer
.org SpritePalPointers + (VariaXID - 0x10) * 4
    .word MegaXPal
	
.org SpriteAIPointers + NettoriSpriteID * 4
    .word NettoriMainAI + 1

.org SSpriteAIPointers + NettoriPartSpriteID * 4
    .word NettoriPartAI + 1

.org SSpriteAIPointers + NettoriBeamSpriteID * 4
    .word NettoriBeamAI + 1


.org SpriteGfxPointers + (NettoriSpriteID - 0x10) * 4
    .word NettoriGFX

.org SpritePalPointers + (NettoriSpriteID - 0x10) * 4
    .word NettoriPal

.org PrimarySpriteStats + NettoriSpriteID * 0x12
    .halfword NettoriHealth   ; health
    .halfword 20   ; damage
    .halfword 0x19    ; weakness
    .halfword 0      ; no drop
    .halfword 0x100      ; no drop
    .halfword 0x80  ; small health
    .halfword 0x180  ; large health
    .halfword 0x80      ; missile
    .halfword 0x60      ; super missile
    .halfword 0x20      ; power bomb

.org SecondarySpriteStats + NettoriPartSpriteID * 0x12
    .halfword 0   ; health
    .halfword 0   ; damage
    .halfword 0    ; weakness
    .halfword 0x100      ; no drop
    .halfword 0x80  ; small health
    .halfword 0x180  ; large health
    .halfword 0x80      ; missile
    .halfword 0x60      ; super missile
    .halfword 0x20      ; power bomb

.org SecondarySpriteStats + NettoriBeamSpriteID * 0x12
    .halfword 1   ; health
    .halfword 70   ; damage
    .halfword 0    ; weakness
    .halfword 0x400      ; no drop
    .halfword 0  ; small health
    .halfword 0  ; large health
    .halfword 0      ; missile
    .halfword 0      ; super missile
    .halfword 0      ; power bomb
	
.org SpriteAIPointers + SamusEaterSpriteID * 4
    .word SamusEaterMainAI + 1

.org SpriteAIPointers + SamusEaterAlwaysSpawnSporeSpriteID * 4
    .word SamusEaterMainAI + 1

.org SSpriteAIPointers + SamusEaterProjectileSpriteID * 4
    .word SamusEaterProjectileAI + 1

.org SpriteGfxPointers + (SamusEaterSpriteID - 0x10) * 4
    .word NettoriGFX

.org SpritePalPointers + (SamusEaterSpriteID - 0x10) * 4
    .word NettoriPal

.org SpriteGfxPointers + (SamusEaterAlwaysSpawnSporeSpriteID - 0x10) * 4
    .word NettoriGFX

.org SpritePalPointers + (SamusEaterAlwaysSpawnSporeSpriteID - 0x10) * 4
    .word NettoriPal


.org PrimarySpriteStats + SamusEaterSpriteID * 0x12
    .halfword 30   ; health
    .halfword 8   ; damage
    .halfword 0x7A    ; weakness
    .halfword 0x100      ; no drop
    .halfword 0x80  ; small health
    .halfword 0x180  ; large health
    .halfword 0x80      ; missile
    .halfword 0x60      ; super missile
    .halfword 0x20      ; power bomb

.org PrimarySpriteStats + SamusEaterAlwaysSpawnSporeSpriteID * 0x12
    .halfword 30   ; health
    .halfword 8   ; damage
    .halfword 0x7A    ; weakness
    .halfword 0x100      ; no drop
    .halfword 0x80  ; small health
    .halfword 0x180  ; large health
    .halfword 0x80      ; missile
    .halfword 0x60      ; super missile
    .halfword 0x20      ; power bomb

.org SecondarySpriteStats + SamusEaterProjectileSpriteID * 0x12
    .halfword 1   ; health
    .halfword 25   ; damage
    .halfword 0x3A    ; weakness
    .halfword 0x280      ; no drop
    .halfword 0xc0  ; small health
    .halfword 0x40  ; large health
    .halfword 0x50      ; missile
    .halfword 0x20      ; super missile
    .halfword 0x10      ; power bomb

.org SpriteAIPointers + SamusEaterBudSpriteID * 4
    .word SamusEaterBudMainAI + 1

.org SpriteGfxPointers + (SamusEaterBudSpriteID - 0x10) * 4
    .word NettoriGFX

.org SpritePalPointers + (SamusEaterBudSpriteID - 0x10) * 4
    .word NettoriPal

.org PrimarySpriteStats + SamusEaterBudSpriteID * 0x12
    .halfword 30   ; health
    .halfword 20   ; damage
    .halfword 0x7A    ; weakness
    .halfword 0      ; no drop
    .halfword 0x100      ; no drop
    .halfword 0x80  ; small health
    .halfword 0x180  ; large health
    .halfword 0x80      ; missile
    .halfword 0x60      ; super missile
    .halfword 0x20      ; power bomb