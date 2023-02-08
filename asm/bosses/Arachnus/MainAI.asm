WrapperR8:
	bx		r8

ArachWait:
	push	r4,r14
	ldrh	r0,[r2]						;if not onscreen, don't start battle
	mov		r1,2h
	and		r0,r1
	cmp		r0,0h
	beq		@@Return
	mov		r4,r2
	add		r2,24h
	mov		r0,8h			
	strb    r0,[r2] 				;pose = 8 
.notice "Arach Song---------"
.notice tohex(.)	
	mov     r0,3Fh					;Kiru Giru song ID                                 
	mov     r1,0h
	ldr		r3,=PlaySong + 1
	bl      WrapperR3
@@Return:
	pop 	r4
	pop		r0
	bx		r0

CheckSamusOnLedge:
	ldr		r0,=SamusData
	ldrb	r0,[r0]
	cmp		r0,19h
	bgt		@@NotHanging
	cmp		r0,15h
	blt		@@NotHanging
	mov		r0,1h
	b		@@Return
@@NotHanging:
	mov		r0,0h
@@Return:
	bx		r14
.pool
	
StoreOAMToSprite:
	ldr		r1,=CurrSpriteData
	add		r1,2Fh
	ldrb	r1,[r1]
	ldr		r3,=SpriteSlot0
	mov		r2,38h
	mul		r1,r2
	add		r3,r3,r1
	str		r0,[r3,18h]
	mov		r0,0h
	strb	r0,[r3,1Ch]
	strh	r0,[r3,16h]
	bx		r14
.pool
 
HitboxSet:                                  
	ldr     r2,=CurrSpriteData           
	mov     r0,0h                   
	ldr     r3,=0FF80h              
	strh    r3,[r2,0Ah]							;top hitbox             
	strh    r0,[r2,0Ch] 							;bottom hitbox            
	ldrh    r1,[r2] 								;status                
	mov     r0,40h                  
	and     r0,r1                   
	cmp     r0,0h 								;checking if flipped                  
	beq     @@NotFlipped                
	ldr     r0,=0FFE0h              
	strh    r0,[r2,0Eh]             
	mov     r0,80h                  
	b       @@Return                
.pool               
@@NotFlipped:
	strh    r3,[r2,0Eh]             
	mov     r0,20h
@@Return:
	strh    r0,[r2,10h]             
	bx		r14  

StartFireball:   
	push    r14                    
	ldr     r2,=CurrSpriteData           
	mov     r1,r2                  
	add     r1,24h                 
	mov     r3,0h                  
	mov     r0,40h									;pose = 40, fire attack                 
	strb    r0,[r1]                
	ldr     r0,=ArachOAM_7								;OAM pointer           
	str     r0,[r2,18h]            
	strb    r3,[r2,1Ch]            
	strh    r3,[r2,16h]            
	ldrh    r1,[r2]                
	ldr     r0,=0FBFFh             
	and     r0,r1										;removes 400h flag                  
	mov     r3,80h                 
	lsl     r3,r3,4h               
	mov     r1,r3                  
	eor     r0,r1                  
	strh    r0,[r2]									;toggles 800h flag               
	ldr     r0,=ArachOAM_8								;OAM pointer           
	bl      StoreOAMToSprite    
	pop     r0
	bx		r0                                         
.pool

PreHurtAI:
	push    r14                
	ldr     r1,=CurrSpriteData 							;AI ran when damage is dealt   
	mov     r3,r1              
	add     r3,24h             
	mov     r2,0h              
	mov     r0,3Eh										;pose = 3E             
	strb    r0,[r3]            
	ldr     r0,=ArachOAM_17								;OAM pointer       
	str     r0,[r1,18h]        
	strb    r2,[r1,1Ch]        
	strh    r2,[r1,16h]        
	ldr     r0,=0FF20h         
	strh    r0,[r1,0Ah]									;top hitbox        
	strh    r2,[r1,0Ch] 								;bottom hitbox       
	add     r0,98h             
	strh    r0,[r1,0Eh]									;left hitbox        
	mov     r0,48h             
	strh    r0,[r1,10h]									;right hitbox        
	ldr     r0,=ArachOAM_18 								;OAM pointer      
	bl      StoreOAMToSprite
	mov     r0,0D5h										;hurt roar   
	lsl		r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3          
	pop     r0
	bx		r0                 
.pool

DeadAI:
	push    r4,r14												;ran when sprite health = 0, starts formation to X core             
	ldr     r4,=CurrSpriteData       
	mov     r0,r4              
	add     r0,24h             
	mov     r2,0h              
	mov     r1,42h								;pose = 42, dying AI           
	strb    r1,[r0]            
	ldr     r0,[r4,18h] 							;OAM pointer       
	ldr     r1,=ArachOAM_17      
	cmp     r0,r1									;changes OAM if different 
	beq     @@Branch          
	str     r1,[r4,18h]							        
	strb    r2,[r4,1Ch]        
	strh    r2,[r4,16h]        
	ldr     r0,=0FF20h         
	strh    r0,[r4,0Ah]							;top hitbox        
	strh    r2,[r4,0Ch]							;bottom hitbox        
	add     r0,98h             
	strh    r0,[r4,0Eh]							;left hitbox        
	mov     r0,48h             
	strh    r0,[r4,10h]							;right hitbox        
	ldr     r0,=ArachOAM_18 							;OAM pointer      
	bl      StoreOAMToSprite
@@Branch:
	ldrh    r1,[r4]            
	mov     r2,80h             
	lsl     r2,r2,8h           
	mov     r0,r2              
	mov     r2,0h              
	orr     r0,r1									;8000h, X parasite flag                          
	strh    r0,[r4]								;status            
	mov     r0,r4              
	add     r0,25h             
	strb    r2,[r0]								;0 to samus collision             
	mov     r1,1h              
	strh    r1,[r4,14h]							;stores 1 to health        
	add     r0,6h              
	strb    r2,[r0]								;stun timer            
	sub     r0,0Bh             
	strb    r2,[r0]								;palette row				            
	mov     r0,2Ch             
	strh    r0,[r4,6h]   							;X timer?      
	strh    r1,[r4,8h]         
	ldr     r0,=1BDh            					;death sound
	ldr		r3,=PlaySound + 1
	bl      WrapperR3          
	pop     r4                 
	pop     r0
	bx		r0                 
.pool

StartRoll:
	push    r4,r5,r14                   
	ldr     r4,=CurrSpriteData                
	mov     r1,r4                       
	add     r1,24h                      
	mov     r0,3Ah                      
	strb    r0,[r1]										;pose = 3A, roll attack                     
	ldrh    r1,[r4]                     
	mov		r0,80h
	lsl		r0,r0,8h
	add		r0,4h
	mov     r5,0h                       
	orr     r1,r0 										;setting 8004h flag                      
	strh    r1,[r4]
	mov     r0,r4
	add		r0,25h										;zero's samus collision
	strb	r5,[r0]
	add     r0,10h                      
	strb    r5,[r0]                      
	ldr     r0,=0FFE0h                  
	strh    r0,[r4,0Eh]									;left hitbox                 
	mov     r0,20h                      
	strh    r0,[r4,10h]									;right hitbox                 
	mov     r0,80h                      
	lsl     r0,r0,3h										;checking status for 400h                    
	and     r0,r1                       
	cmp     r0,0h                       
	beq     @@ChangeShell                    
	ldr     r0,=0FBFFh                  
	and     r1,r0 										;removing 400h                      
	mov     r2,80h                      
	lsl     r2,r2,4h                    
	mov     r0,r2                       
	eor     r1,r0                       
	strh    r1,[r4]										;toggle 800h
@@ChangeShell:
	ldr     r0,=ArachOAM_13									;OAM pointer                
	bl      StoreOAMToSprite
	mov     r0,r4                       
	add     r0,2Fh 										;slot for shell sprite                     
	ldrb    r1,[r0]                     
	ldr     r2,=SpriteSlot0                
	lsl     r0,r1,3h                    
	sub     r0,r0,r1                    
	lsl     r0,r0,3h                    
	add     r0,r0,r2										;changing hitbox for shell                    
	ldr     r1,=0FFA0h                  
	strh    r1,[r0,0Ah]									;top hitbox                 
	mov     r1,0h                       
	strh    r1,[r0,0Ch]									;bottom hitbox                 
	ldr     r1,=0FFC0h                  
	strh    r1,[r0,0Eh]									;left hitbox                 
	mov     r1,40h                      
	strh    r1,[r0,10h]									;right hitbox                 
	mov     r0,0B4h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3                   
	pop     r4,r5                       
	pop     r0
	bx		r0                          
.pool
 
StartSwipe:
	push    r14          
	ldr     r1,=CurrSpriteData
	mov     r2,r1        
	add     r2,24h       
	mov     r3,0h        
	mov     r0,38h       
	strb    r0,[r2]									;pose = 38, swipe attack      
	ldr     r0,=ArachOAM_9								;OAM pointer 
	str     r0,[r1,18h]  
	strb    r3,[r1,1Ch]  
	strh    r3,[r1,16h]  
	ldrh    r2,[r1]      
	ldr     r0,=0FBFFh   
	and     r0,r2        
	strh    r0,[r1]									;removing 400h flag      
	ldr     r0,=ArachOAM_10								;OAM pointer 
	bl      StoreOAMToSprite     
	mov     r0,0E4h
	lsl		r0,r0,1h								;pre swipe
	ldr		r3,=PlaySound + 1
	bl      WrapperR3     
	pop     r0
	bx		r0          
.pool

SwipingAI:    
	push    r4-r6,r14          
	add     sp,-0Ch            
	ldr     r0,=CurrSpriteData       
	mov     r12,r0             
	ldrh    r1,[r0]								;status            
	mov     r5,40h             
	mov     r0,r5              
	and     r0,r1              
	lsl     r0,r0,10h          
	lsr     r4,r0,10h          
	cmp     r4,0h									;checking direction, 40h = right               
	beq     @@FacingLeft           
	mov     r2,r12             
	ldrh    r1,[r2,16h]							;current animation         
	cmp     r1,0Fh             
	bhi     @@AnimationCheck           
	mov     r0,0A0h            
	strh    r0,[r2,10h] 							;right hitbox       
	b       @@CheckDone           
.pool
@@AnimationCheck:
	cmp     r1,11h             
	bhi     @@AnimationCheck2          
	mov     r0,60h             
	mov     r1,r12             
	strh    r0,[r1,10h]							;right hibox        
	b       @@CheckDone
@@AnimationCheck2:
	cmp     r1,17h             
	bhi     @@StoreHitbox           
	mov     r0,0C0h            
	mov     r2,r12             
	strh    r0,[r2,10h]							;right hitbox        
	cmp     r1,12h             
	bne     @@CheckDone           
	ldrb    r0,[r2,1Ch]							;animation timer        
	cmp     r0,3h              
	bne     @@CheckDone           
	ldrb    r2,[r2,1Fh] 							;sprite GFX slot       
	mov     r0,r12             
	add     r0,23h             
	ldrb    r3,[r0]								;RAM slot            
	mov     r1,r12             
	ldrh    r0,[r1,2h]							;sprite Y pos         
	add     r0,10h             
	str     r0,[sp]            
	ldrh    r0,[r1,4h]							;sprite X         
	add     r0,8Ch 								;arguments to spawn swipe wave            
	str     r0,[sp,4h]         
	str     r5,[sp,8h]         
	b       @@SpawnShockwave    
@@StoreHitbox:
	mov     r0,80h             
	mov     r2,r12             
	strh    r0,[r2,10h]							;right hitbox        
	b       @@CheckDone 
@@FacingLeft:
	mov     r0,r12             
	ldrh    r1,[r0,16h]					;current animation        
	cmp     r1,0Fh             
	bhi     @@CheckAnimation          
	ldr     r0,=0FF60h         
	mov     r1,r12             
	strh    r0,[r1,0Eh]					;left hitbox        
	b       @@CheckDone           
.pool
@@CheckAnimation:
	cmp		r1,11h             
	bhi		@@CheckAnimation2           
	ldr		r0,=0FFA0h         
	b 		@@StoreLeftHitbox           
.pool
@@CheckAnimation2:
	cmp     r1,17h             
	bhi     @@Branch          
	ldr     r0,=0FF40h         
	mov     r2,r12             
	strh    r0,[r2,0Eh]						;left hitbox        
	cmp     r1,12h             
	bne     @@CheckDone           
	ldrb    r0,[r2,1Ch] 						;animation frame       
	cmp     r0,3h              
	bne     @@CheckDone           
	ldrb    r2,[r2,1Fh]						;GFX row        
	mov     r0,r12             
	add     r0,23h   							;primary sprite RAM slot          
	ldrb    r3,[r0]            
	mov     r1,r12             
	ldrh    r0,[r1,2h]						;sprite Y         
	add     r0,10h             
	str     r0,[sp]            
	ldrh    r0,[r1,4h] 						;Sprite X        
	sub     r0,8Ch 							;arguments for swipe wave spawn            
	str     r0,[sp,4h]         
	str     r4,[sp,8h]
@@SpawnShockwave:
.notice "Arach Swipe"
.notice tohex(.)
	mov     r0,SwipeID 							;16h, is swipe wave            
	mov     r1,0h
	ldr		r6,=SpawnSecondarySprite + 1
	bl      WrapperR6          
	ldr     r0,=1C5h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3           
	b       @@CheckDone           
.pool
@@Branch:
	ldr     r0,=0FF80h
@@StoreLeftHitbox:
	mov     r2,r12             
	strh    r0,[r2,0Eh]						;left hitbox
@@CheckDone:
	ldr		r3,=CheckAlmostEndOfAnimation + 1
	bl      WrapperR3           
	cmp     r0,0h              
	beq     @@Return           
	ldr     r1,=CurrSpriteData       
	mov     r2,r1              
	add     r2,24h             
	mov     r0,1h              
	strb    r0,[r2]							;pose = 1            
	add     r1,2Eh							;cooldown timer            
	mov     r0,78h             
	strb    r0,[r1]
@@Return:
	add     sp,0Ch             
	pop     r4-r6              
	pop     r0
	bx		r0                
.pool

RollingAI:    
	push    r4-r7,r14                                  
	mov     r7,r8                                      
	push    r7                                         
	ldr     r5,=CurrSpriteData                               
	mov     r0,r5                                      
	add     r0,2Fh                                     
	ldrb    r2,[r0]                                    
	ldr     r7,=SpriteSlot0                               
	lsl     r0,r2,3h                                   
	sub     r0,r0,r2                                   
	lsl     r6,r0,3h                                   
	mov     r0,r7                                      
	add     r0,18h                                     
	add     r0,r6,r0                                   
	ldr     r1,[r0]                                    
	ldr     r0,=ArachOAM_13					;OAM pointer, morphing into ball                               
	cmp     r1,r0 						;checking shell OAM                                      
	bne     @@Branch                                   
	mov     r0,r2							;checks if animation for sprite in slot r0 is done                                      
	ldr		r3,=CheckEndOfAnimation2 + 1
	bl      WrapperR3                                   
	cmp     r0,0h                                      
	bne     @@StartRolling                                   
	b       @@Return
@@StartRolling:
	ldr     r0,=ArachOAM_19 						;OAM pointer                              
	bl      StoreOAMToSprite           
	add     r1,r6,r7							;sprite data address for shell                                   
	ldrh    r2,[r1]							;status                                    
	mov     r0,80h                                     
	mov     r3,0h                                      
	orr     r0,r2                                      
	strh    r0,[r1] 							;sets 80h flag, Y flip                                   
	mov     r0,r1                                      
	add     r0,2Ah                                     
	strb    r3,[r0]							;OAM rotation                                    
	mov     r0,80h                                     
	lsl     r0,r0,1h 							;100h                                  
	strh    r0,[r1,12h]						;OAM scaling                                
	b       @@Return                                   
.pool
@@Branch:
	ldr     r0,=RotationTable                               
	mov     r1,35h                                     
	add     r1,r1,r5                                   
	mov     r8,r1                                      
	ldrb    r3,[r1]							;rotation value                                    
	lsl     r1,r3,18h                                  
	lsr     r2,r1,18h                                  
	lsr     r1,r1,1Ah                                  
	lsl     r1,r1,1h                                   
	add     r1,r1,r0                                   
	ldrh    r4,[r1]                                    
	cmp     r2,2Eh                                     
	bhi     @@DirectionCheck                                   
	add     r0,r3,1                                    
	mov     r2,r8                                      
	strb    r0,[r2]                                    
@@DirectionCheck:
	ldrh    r1,[r5]                                    
	mov     r0,40h                                     
	and     r0,r1                                      
	cmp     r0,0h								;checking direction, 40h = right                                      
	beq     @@CheckLeft                                   
	add     r6,r6,r7                                   
	ldrh    r0,[r6,2h] 						;shell Y pos                                
	sub     r0,48h                                    
	mov     r2,10h                                     
	ldsh    r1,[r6,r2]						;shell right hitbox                                 
	ldrh    r2,[r6,4h]						;shell X pos                                 
	add     r1,r1,r2							;shell rightmost position                                    
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                                  
	ldr     r0,=30007F1h                               
	ldrb    r1,[r0] 							;checks if top right is hitting a solid block                                   
	mov     r0,0Fh                                     
	and     r0,r1                                      
	cmp     r0,0h                                      
	beq     @@MoveRight                                   
	b       @@HitWall
@@MoveRight:
	ldrh    r0,[r5,4h]                                 
	add     r0,r4,r0                                   
	strh    r0,[r5,4h]						;move sprite right based on r4                                  
	ldrh    r7,[r5,4h]                                                  
	ldrh    r2,[r5,2h]                        ;sprite x                              
	ldrh    r0,[r6,4h]                        ;sprite y                              
	add     r0,r4,r0                                                                 
	strh    r0,[r6,4h]                        ;move shell right based on r4           
	mov     r1,r8                                                       
	ldrb    r0,[r1]                                                     
	lsr     r4,r0,1h                          ;rotation timer                           
	cmp     r4,10h                                     
	bls     @@StoreRotation                                   
	mov     r4,10h
@@StoreRotation:
	mov     r0,r6                                      
	add     r0,2Ah                                     
	ldrb    r1,[r0]                                    
	add     r1,r1,r4                                   
	strb    r1,[r0] 							;new roation based on r4                                   
	ldr     r0,=SpriteRNG                               
	ldrb    r1,[r0]                                    
	cmp     r1,0Ch 							;if greater than 0Ch, spawn a "rock" projectile behind sprite                                    
	bls     @@PreCheckPlaySound                                   
	mov     r0,1h								;used to determine "rock" type                                      
	and     r0,r1                                      
	cmp     r0,0h                                      
	beq     @@SpawnRock                                  
	sub     r2,10h                                     
	ldr     r0,=FrameCounter                               
	ldrb    r0,[r0]                                    
	mov     r3,1Fh                                     
	and     r3,r0                                      
	add     r3,r7,r3                                   
	mov     r0,0h                                      
	mov     r1,4h
	ldr		r6,=SpawnDebris + 1
	bl      WrapperR6                                   
	b       @@CheckPlaySound                                   
.pool
@@SpawnRock:
	ldr     r0,=FrameCounter                               
	ldrb    r0,[r0]                                    
	mov     r3,1Fh                                     
	and     r3,r0                                      
	add     r3,r7,r3                                   
	mov     r0,0h                                      
	mov     r1,11h                                     
	ldr		r6,=SpawnDebris + 1
	bl      WrapperR6
@@PreCheckPlaySound:	
	b       @@CheckPlaySound                                   
.pool
@@CheckLeft:
	add     r6,r6,r7                                   
	ldrh    r0,[r6,2h]                                 
	sub     r0,48h                                     
	mov     r2,0Eh                                     
	ldsh    r1,[r6,r2]                                 
	ldrh    r2,[r6,4h]                                 
	add     r1,r1,r2
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                              
	ldr     r0,=30007F1h                               
	ldrb    r1,[r0]                                    
	mov     r0,0Fh                                     
	and     r0,r1                                      
	cmp     r0,0h                                      
	bne     @@HitWall                                   
	ldrh    r0,[r5,4h]                                 
	sub     r0,r0,r4					;move sprite left based on r4                                   
	strh    r0,[r5,4h]                                 
	ldrh    r7,[r5,4h]				;sprite x                                 
	ldrh    r2,[r5,2h]				;sprite y                                 
	ldrh    r0,[r6,4h] 				                                
	sub     r0,r0,r4 					;move shell left based on r4                                  
	strh    r0,[r6,4h]                                 
	mov     r1,r8                                      
	ldrb    r0,[r1]					;roation timer                                    
	lsr     r4,r0,1h                                   
	cmp     r4,10h                                     
	bls     @@NewRotation                                   
	mov     r4,10h
@@NewRotation:
	mov     r0,r6                                      
	add     r0,2Ah                                     
	ldrb    r1,[r0]                                    
	sub     r1,r1,r4					;new roation based on r4                                   
	strb    r1,[r0]                                    
	ldr     r0,=SpriteRNG                               
	ldrb    r1,[r0]                                    
	cmp     r1,0Ch                   ;if greater than 0Ch, spawn a "rock" projectile behind sprite                   
	bls     @@CheckPlaySound                                            
	mov     r0,1h                    ;used to determine "rock" type                                                  
	and     r0,r1                                      
	cmp     r0,0h                                      
	beq     @@RockSpawn                                   
	sub     r2,10h                                     
	ldr     r0,=FrameCounter                               
	ldrb    r0,[r0]                                    
	mov     r3,1Fh                                     
	and     r3,r0                                      
	sub     r3,r7,r3                                   
	mov     r0,0h                                      
	mov     r1,13h                                     
	ldr		r6,=SpawnDebris + 1
	bl      WrapperR6                                     
	b       @@CheckPlaySound                                   
.pool
@@RockSpawn:
	ldr     r0,=FrameCounter                               
	ldrb    r0,[r0]                                    
	mov     r3,1Fh                                     
	and     r3,r0                                      
	sub     r3,r7,r3                                   
	mov     r0,0h                                      
	mov     r1,12h                                     
	ldr		r6,=SpawnDebris + 1
	bl      WrapperR6                                       
	b      	@@CheckPlaySound
@@HitWall:
	ldr     r1,=CurrSpriteData                              
	mov     r2,r1                                      
	add     r2,24h                                     
	mov     r3,0h                                      
	mov     r0,3Ch                                     
	strb    r0,[r2]								;pose = 3Ch                                    
	add     r1,2Dh                                     
	strb    r3,[r1]                                    
	mov     r0,28h                                     
	mov     r1,81h
	ldr		r3,=ShakeScreen + 1
	bl      WrapperR3                                   
	ldr     r0,=193h 							;bonk                                   
	ldr		r3,=PlaySound + 1
	bl      WrapperR3                                  
	b       @@Return                                   
.pool
@@CheckPlaySound:                                  
	ldr     r0,=FrameCounter                               
	ldrb    r1,[r0]                                    
	mov     r0,1h                                     
	and     r0,r1                                      
	cmp     r0,0h									;plays sound every 15 frames                                       
	bne     @@Return                                   
	mov     r0,0C8h								;rolling sound   
	lsl		r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3
@@Return:
	pop     r3                                         
	mov     r8,r3                                      
	pop     r4-r7                                      
	pop     r0
	bx		r0                                        
.pool

EndRollAI:
	push    r4-r7,r14 										;handles bonk and unmorphing from roll AI                        
	ldr     r3,=CurrSpriteData        
	mov     r0,r3               
	add     r0,2Fh              
	ldrb    r5,[r0]							;slot shell is in?             
	ldr     r2,=SpriteSlot0        
	lsl     r0,r5,3h            
	sub     r0,r0,r5            
	lsl     r0,r0,3h            
	mov     r1,r2               
	add     r1,18h              
	add     r0,r0,r1            
	ldr     r0,[r0]             
	mov     r4,r3               
	mov     r7,r2               
	ldr     r1,=ArachOAM_15						;OAM, unmorphing         
	mov     r12,r1							              
	cmp     r0,r12              
	bne     @@BonkingAI            
	mov     r0,r5								;routine checks if animation for given sprite slot in r0, being almsot done               
	ldr     r3,=CheckAlmostEndOfAnimation2 + 1
	bl		WrapperR3
	cmp     r0,0h               
	beq     @@Return            
	mov     r1,r4               
	add     r1,24h              
	mov     r0,7h								;pose = 7               
	strb    r0,[r1]             
	add     r1,0Ah              
	mov     r0,0FFh							;cooldown              
	strb    r0,[r1]             
	b       @@Return            
.pool           
@@BonkingAI:
	mov     r6,r4               
	add     r6,2Dh              
	ldrb    r1,[r6]             
	ldr     r2,=BounceTable						;table used for bounce movement       
	lsl     r0,r1,1h            
	add     r0,r0,r2            
	ldrh    r3,[r0]             
	ldr     r0,=7FFFh           
	cmp     r3,r0               
	bne     @@Inc            
	sub     r0,r1,1 							;doesnt look like it's ever run            
	lsl     r0,r0,1h            
	add     r0,r0,r2            
	ldrh    r3,[r0]             
	b       @@Bounce            
.pool
@@Inc:
	add     r0,r1,1             
	strb    r0,[r6]							;bounce "timer," used to determine X movement 
@@Bounce:
	ldrh    r0,[r4,2h]						;Y pos          
	add     r0,r3,r0							;change Y based on r3            
	strh    r0,[r4,2h]          
	lsl     r2,r5,3h            
	sub     r1,r2,r5            
	lsl     r1,r1,3h            
	add     r1,r1,r7            
	ldrh    r0,[r1,2h]						;shell Y          
	add     r0,r3,r0							;change shell Y based on r3            
	strh    r0,[r1,2h]          
	mov     r0,r4               
	add     r0,2Dh              
	ldrb    r0,[r0]             
	mov     r3,8h								;value to affect X pos               
	mov     r6,r2               
	cmp     r0,0Bh							              
	bls     @@DirectionCheck            
	mov     r3,0h								;value to effect X pos               
	cmp     r0,14h              
	bhi     @@DirectionCheck            
	mov     r3,4h								;value to effect X pos
@@DirectionCheck:
	ldrh    r1,[r4]             
	mov     r0,40h              
	and     r0,r1               
	cmp     r0,0h								;40h = facing right               
	beq     @@FacingLeft            		
	ldrh    r0,[r4,4h]						;X pos          
	sub     r0,r0,r3							;bounce left based on r3						            
	strh    r0,[r4,4h]          		
	sub     r1,r6,r5            		
	lsl     r1,r1,3h            		
	add     r1,r1,r7            		
	ldrh    r0,[r1,4h]						;shell X          
	sub     r0,r0,r3							;bounce left based on r3            
	strh    r0,[r1,4h]          		
	add     r1,2Ah              		
	lsr     r2,r3,1h            		
	ldrb    r0,[r1]							;OAM rotaion              
	sub     r0,r0,r2            		
	b       @@StoreRotation 		
@@FacingLeft:		
	ldrh    r0,[r4,4h]          				;X pos          
	add     r0,r3,r0                  		;bounce right based on r3
	strh    r0,[r4,4h]                		
	sub     r1,r6,r5                  		
	lsl     r1,r1,3h                  		
	add     r1,r1,r7                  		
	ldrh    r0,[r1,4h]                		;shell X          
	add     r0,r3,r0                  		;bounce right based on r3 
	strh    r0,[r1,4h]                		
	add     r1,2Ah                    		
	lsr     r0,r3,1h                  		
	ldrb    r2,[r1]                   		;OAM rotaion             
	add     r0,r0,r2		
@@StoreRotation:		
	strb    r0,[r1]             		
	mov     r0,r4               		
	add     r0,2Dh              		
	ldrb    r0,[r0]             		
	cmp     r0,22h							;only bounce for 22h frames               
	bne     @@Return            		
	mov     r0,r12							;switch to unmorph state              
	bl      StoreOAMToSprite 		
	ldr     r0,=SpriteSlot0        		
	sub     r1,r6,r5            		
	lsl     r1,r1,3h            		
	add     r1,r1,r0            		
	ldrh    r2,[r1]             		
	ldr     r0,=0FF7Fh          		
	and     r0,r2               		
	strh    r0,[r1] 							;removing 80h, Y flip            
	ldr     r0,=18Dh							;unmorph	            
	ldr		r3,=PlaySound + 1
	bl      WrapperR3
@@Return:
	pop     r4-r7               
	pop     r0
	bx		r0                 
.pool

CounterAttack:    
	push    r14 									;ran when attack after being damaged                                
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3             
	cmp     r0,0h                 
	beq     @@Return 
.notice "Arach Fire"
.notice tohex(.)	
	mov     r0,FireID									;fireball ID              
	ldr     r3,=CountNumberOfGivenSecondarySprite + 1
	bl		WrapperR3
	cmp     r0,0h										;true if no firball spanwed                 
	beq     @@CheckRNG              
	ldr     r0,=SpriteRNG								;if fireball is active, pick between roll or swipe         
	ldrb    r0,[r0]               
	cmp     r0,7h                 
	bls     @@Swipe              
	b       @@Roll              
.pool
@@CheckRNG:
	ldr     r0,=SpriteRNG         
	ldrb    r0,[r0]               
	cmp     r0,0Ah 								;if larger than 0Ah, swipe               
	bls     @@Check2
@@Swipe:
	bl      StartSwipe            
	b       @@Return              
.pool
@@Check2:            
	cmp     r0,6h									;if less than A but greater than 6, roll                
	bls     @@StartFireball
@@Roll:
	bl      StartRoll             
	b       @@Return
@@StartFireball:
	bl      StartFireball
@@Return:
	pop     r0
	bx		r0             

ArachDying:
	push    r4-r6,r14 								;AI for dying
	add		sp,-4h
	ldr		r6,=SetParticleEffect + 1
	ldr		r3,=CurrSpriteData
	ldrh    r0,[r3,6h]										              
	sub     r0,1h                   
	strh    r0,[r3,6h]								;decrements              
	ldrh    r0,[r3,2h]								;sprite Y              
	sub     r0,80h                 
	lsl     r0,r0,10h               
	lsr     r5,r0,10h               
	ldrh    r4,[r3,4h]								;sprite X              
	ldrh    r0,[r3,8h]              
	mov     r2,r3                   
	cmp     r0,0h                   
	bne     @@TimerCheck                
	b       @@EffectSet2
@@TimerCheck:
	ldrh    r0,[r3,6h]              
	cmp     r0,28h                  
	bls     @@JumpGet                
	b       @@Return
@@JumpGet:
	lsl     r0,r0,2h                
	ldr     r1,=@@JumpTable            
	add     r0,r0,r1                
	ldr     r0,[r0]                 
	mov     r15,r0                  
.pool
@@JumpTable:
	.word @@TimerSet,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect4,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect3,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect2,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect1
@@Effect1:	
	mov     r0,r5                   
	sub     r0,10h                  
	mov     r1,r4                   
	mov     r2,21h                  
	bl      WrapperR6                
	mov     r0,r5                   
	add     r0,10h                  
	mov     r1,r4                   
	b       @@Branch2
@@Effect2:
	mov     r0,r5                   
	sub     r0,1Ah                  
	b       @@Branch
@@Effect3:
	mov     r0,r5                   
	add     r0,40h	
	mov     r1,r4                   
	sub     r1,10h
@@Branch2:	
	mov     r2,27h                  
	bl      WrapperR6                 
	b       @@Return
@@Effect4:
	mov     r0,r5                   
	sub     r0,20h
@@Branch:
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,22h                  
	bl      WrapperR6                
	b       @@Return
@@TimerSet:
	mov     r0,0h                   
	strh    r0,[r2,8h]              
	mov     r0,2Ch                  
	strh    r0,[r2,6h]								;X parasite timer              
	b       @@Return
@@EffectSet2:
	ldrh    r0,[r3,6h]              
	cmp     r0,28h                  
	bls     @@JumpGet2                
	b       @@Return
@@JumpGet2:
	lsl     r0,r0,2h                
	ldr     r1,=@@JumpTable2            
	add     r0,r0,r1                
	ldr     r0,[r0]                 
	mov     r15,r0                  
.pool
@@JumpTable2:
	.word @@KillSprite,@@Return,@@Return,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect8,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect7,@@Return,@@Return,@@Return              
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Effect6,@@Return               
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Effect5
@@Effect5:	
	mov     r0,r5                   
	sub     r0,30h                  
	sub     r4,10h                  
	mov     r1,r4                   
	mov     r2,1Fh                  
	bl      WrapperR6                 
	mov     r0,r5                   
	add     r0,20h                  
	mov     r1,r4                   
	b       @@SetEffect
@@Effect6:
	mov     r0,r5                   
	sub     r0,20h                  
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,27h                  
	bl      WrapperR6                
	mov     r0,r5                   
	add     r0,40h                  
	b       @@PreSetEffect
@@Effect7:
	mov     r0,r5                   
	sub     r0,20h                  
	sub     r4,10h                  
	mov     r1,r4                   
	mov     r2,26h                  
	bl      WrapperR6                 
	mov     r0,r5                   
	add     r0,40h                  
	mov     r1,r4                   
	b       @@SetEffect
@@Effect8:
	mov     r0,r5                   
	sub     r0,35h
	mov     r1,r4                   
	add     r1,1Ch                  
	mov     r2,21h                  
	bl      WrapperR6                
	mov     r0,r5                   
	add     r0,20h
@@PreSetEffect:
	mov     r1,r4  
	add     r1,20h 
@@SetEffect:
	mov     r2,25h                  
	bl      WrapperR6                 
	b       @@Return
@@KillSprite:
	ldr     r4,=CurrSpriteData            		                          
	ldrh    r1,[r4,2h]		;sprite Y position 
	sub		r1,60h
	ldrh    r2,[r4,4h]		;sprite X position                               
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r6,=SpriteDead + 1
	bl      WrapperR6 
	ldr		r1,=UnlockDoors
	mov		r0,0x3C
	neg		r0,r0
	strb	r0,[r1]				;opens doors
	mov		r0,1
	bl		SetnCheckEvent
	mov		r0,0Bh				;boss killed song
	mov		r1,0h
	ldr		r3,=PlaySong + 1
	;bl		WrapperR3
	nop
	nop
@@Return:
	add		sp,4h
	pop     r4-r6                   
	pop     r0
	bx		r0                    
.pool

FireballAttack:
	push    r4,r6,r14            
	add     sp,-0Ch
	ldr		r6,=SpawnSecondarySprite + 1
	ldr     r0,=CurrSpriteData      
	mov     r12,r0            
	ldrh    r0,[r0,16h]									;animation frame       
	cmp     r0,3h             
	bne     @@CheckAlmostEnd          
	mov     r1,r12            
	ldrb    r0,[r1,1Ch]									;animation timer       
	cmp     r0,1h             
	bne     @@CheckAlmostEnd          
	ldrh    r1,[r1]           
	mov     r4,40h 										;checking direction, 40h = right           
	mov     r0,r4             
	and     r0,r1             
	lsl     r0,r0,10h         
	lsr     r1,r0,10h         
	cmp     r1,0h             
	beq     @@FacingLeft          
	mov     r0,r12						;all arguments for function call            
	ldrb    r2,[r0,1Fh]       
	add     r0,23h            
	ldrb    r3,[r0]           
	mov     r1,r12            
	ldrh    r0,[r1,2h]        
	sub     r0,80h            
	str     r0,[sp]           
	ldrh    r0,[r1,4h]        
	add     r0,40h            
	str     r0,[sp,4h]        
	str     r4,[sp,8h]
.notice "Arach Fire"
.notice tohex(.)	
	mov     r0,FireID 						;fireball           
	mov     r1,0h             
	bl      WrapperR6         
	b       @@PlaySound          
.pool
@@FacingLeft:
	mov     r4,r12 						;all arguments for function call           
	ldrb    r2,[r4,1Fh]       
	mov     r0,r12            
	add     r0,23h            
	ldrb    r3,[r0]           
	ldrh    r0,[r4,2h]        
	sub     r0,80h            
	str     r0,[sp]           
	ldrh    r0,[r4,4h]        
	sub     r0,40h            
	str     r0,[sp,4h]        
	str     r1,[sp,8h] 
.notice "Arach Fire"
.notice tohex(.)	
	mov     r0,FireID						;fireball            
	mov     r1,0h             
	bl      WrapperR6
@@PlaySound:
	mov		r0,0A9h
	lsl		r0,r0,1h          				;fire breath
	ldr		r3,=PlaySound + 1
	bl      WrapperR3
@@CheckAlmostEnd:
	ldr     r3,=CheckAlmostEndOfAnimation + 1
	bl		WrapperR3
	cmp     r0,0h             
	beq     @@Return          
	ldr     r1,=CurrSpriteData      
	mov     r2,r1             
	add     r2,24h            
	mov     r0,1h             
	strb    r0,[r2]   					;pose = 1        
	add     r1,2Eh            
	mov     r0,78h						;attack cooldown            
	strb    r0,[r1]
@@Return:
	add     sp,0Ch            
	pop     r4,r6                
	pop     r0
	bx		r0               
.pool
 
CheckAttack:
	push    r4,r5,r14               
	ldr     r5,=CurrSpriteData            
	mov     r4,r5                   
	add     r4,2Eh 							;2E seems to be used as an attack cooldown timer                 
	ldrb    r0,[r4]                 			;as in, it cannot attack if timer is active
	cmp     r0,0h                   
	beq     @@StatusCheck                
	cmp     r0,0FFh							;true after a turn                 
	bne     @@Decrement                
	bl      StartSwipe
@@Decrement:
	ldrb    r0,[r4]							;subtract timer                 
	sub     r0,1h                   
	strb    r0,[r4]                 
	b       @@Return                
.pool
@@StatusCheck:               
	ldrh    r1,[r5]							;status                 
	mov     r0,80h                  
	lsl     r0,r0,3h                
	and     r0,r1                   
	cmp     r0,0h 							;checking for 400h flag, true if shot                  
	beq     @@LedgeCheck
.notice "Arach Fire"
.notice tohex(.)
	mov     r0,FireID							;Secondary sprite 1A, fire wall                  
	ldr		r3,=CountNumberOfGivenSecondarySprite + 1
	bl      WrapperR3				;routine checks the number of the given secondary sprite                
	cmp     r0,0h                   
	bne     @@SetRoll                
	ldrh    r1,[r5]                 
	mov     r0,80h                  
	lsl     r0,r0,4h                
	and     r0,r1 							;checking for 800h                  
	cmp     r0,0h                   
	bne     @@SetRoll                
	bl      StartFireball                
	b       @@Return
@@LedgeCheck:
	bl      CheckSamusOnLedge                
	cmp     r0,0h								;0 if not hanging on ledge                   
	beq     @@DirectionCheck
@@SetRoll:
	bl      StartRoll                
	b       @@Return
@@DirectionCheck:
	ldrh    r1,[r3]      
	mov     r0,40h       
	and     r0,r1        
	cmp     r0,0h							;checking sprite direction, 40h = right          
	beq     @@FacingLeft     
	ldr     r1,=SamusData 
	ldrh    r0,[r3,4h]						;sprite X   
	ldrh    r1,[r1,12h] 					;Samus X 
	cmp     r0,r1        
	bcs     @@Return 						;checking if samus is behind sprite   
	b       @@SwipeRangeCheck     
.pool
@@FacingLeft:
	ldr     r1,=SamusData 
	ldrh    r0,[r3,4h]					;sprite X   
	ldrh    r1,[r1,12h]					;Samus X  
	cmp     r0,r1							;checking if samus is behind sprite        
	bls     @@Return
@@SwipeRangeCheck:
	mov     r2,0C0h                 
	lsl     r2,r2,1h							;180h, 6 blocks	of horizontal range 					               
	mov     r0,0C0h							;3 blocks of vertical range                
	mov     r1,r2								;range for swipe attack                    
	ldr		r3,=CheckNearSprite + 1
	bl      WrapperR3               
	cmp     r0,0h								;true if sprite is in range                   
	beq     @@RollRangeCheck                
	bl      StartSwipe                
	b       @@Return
@@RollRangeCheck: 
	mov     r2,80h                  
	lsl     r2,r2,2h							;200h, 8 blocks of horizontal range                
	mov     r0,0C0h							;3 blocks of horizontal range                 
	mov     r1,r2								;range for roll attack                   
	ldr		r3,=CheckNearSprite + 1
	bl      WrapperR3               
	cmp     r0,0h								;true if in range                   
	beq     @@Return                
	bl      StartRoll
@@Return:
	pop     r4,r5                   
	pop     r0
	bx		r0                

Initialize:    
	push    r4-r7,r14       
	mov     r7,r8           
	push    r7              
	add     sp,-0Ch
	mov		r0,3h
	bl		SetnCheckEvent
	cmp		r0,0h
	beq		@@Spawn
	mov		r0,0h
	ldr     r1,=CurrSpriteData			;kill sprite
	strh	r0,[r1]
	b		@@Return
@@Spawn:
	ldr		r0,=SpawnSecondarySprite + 1
	mov		r8,r0
	ldr		r1,=LockDoors
	mov		r0,1h
	strb	r0,[r1]					;locks doors
	ldr     r0,=CurrSpriteData    
	mov     r12,r0          
	ldrh    r0,[r0]         
	mov     r2,40h          
	mov     r4,0h           
	orr     r0,r2           
	mov     r1,r12          
	strh    r0,[r1]         
	ldr     r3,=PrimarySpriteStats    
	ldrb    r1,[r1,1Dh]     
	lsl     r0,r1,3h        
	add     r0,r0,r1        
	lsl     r0,r0,1h        
	add     r0,r0,r3        
	ldrh    r0,[r0]					;math to get sprite health         
	mov     r1,r12          
	strh    r0,[r1,14h]				;store health     
	mov     r0,r12          
	add     r0,25h          
	mov     r3,4h           
	strb    r3,[r0]					;value 4 (hurts samus) to samus collision          
	add     r0,2h           
	strb    r2,[r0]         
	add     r0,1h           
	strb    r4,[r0]         
	add     r0,1h           
	strb    r2,[r0] 					;all drawing related        
	add     r1,2Eh          
	mov     r0,64h          
	strb    r0,[r1]         
	mov     r2,r12          
	add     r2,24h                 
	mov     r0,43h						          
	strb    r0,[r2]					;pose = 43, waitAI        
	mov     r4,r12
	ldr     r0,=ArachOAM_11				;OAM pointer    
	str     r0,[r4,18h]     
	mov     r0,0h                    
	strb    r0,[r4,1Ch]               
	strh    r0,[r4,16h]     
	bl      HitboxSet        
	ldrb    r1,[r4,1Eh]     
	ldrb    r2,[r4,1Fh]     
	mov     r7,r4           
	add     r7,23h          
	ldrb    r3,[r7]         
	ldrh    r0,[r4,2h]      
	str     r0,[sp]         
	ldrh    r0,[r4,4h]      
	str     r0,[sp,4h]      
	mov     r6,40h          
	str     r6,[sp,8h] 
.notice "Arach Shell"
.notice tohex(.)	
	mov     r0,ShellID 								;shell ID         
	bl      WrapperR8            
	cmp     r0,0FFh 							;check if can't spawn          
	beq     @@CannotSpawn        
	mov     r1,r4           
	add     r1,2Fh          
	strb    r0,[r1]         
	mov		r1,1h     
	ldrb    r2,[r4,1Fh]     
	ldrb    r3,[r7]         
	ldrh    r0,[r4,2h]      
	str     r0,[sp]         
	ldrh    r0,[r4,4h]      
	str     r0,[sp,4h]      
	str     r6,[sp,8h]
.notice "Arach Part"
.notice tohex(.)	
	mov     r0,PartsID 								;head        
	bl      WrapperR8            
	cmp     r0,0FFh 							;check if can't spawn          
	bne     @@SpawnNext        
	mov     r0,0h           
	strh    r0,[r4]							;status = 0, kills sprite         
	b       @@Return        
.pool
@@SpawnNext:
	mov		r1,2h     
	ldrb    r2,[r4,1Fh]     
	ldrb    r3,[r7]         
	ldrh    r0,[r4,2h]      
	str     r0,[sp]         
	ldrh    r0,[r4,4h]      
	str     r0,[sp,4h]      
	str     r6,[sp,8h]
.notice "Arach Part"
.notice tohex(.)	
	mov     r0,PartsID								;front arm         
	bl      WrapperR8            
	cmp     r0,0FFh 							;check if can't spawn          
	bne     @@SpawnNext2 
@@CannotSpawn:
	mov     r1,0h           
	strh    r1,[r4]							;status = 0, kills sprite         
	b       @@Return
@@SpawnNext2:
	mov		r1,3h   
	ldrb    r2,[r5,1Fh]     
	ldrb    r3,[r7]         
	ldrh    r0,[r5,2h]      
	str     r0,[sp]         
	ldrh    r0,[r5,4h]      
	str     r0,[sp,4h]      
	str     r6,[sp,8h] 
.notice "Arach Part"
.notice tohex(.)	
	mov     r0,PartsID								;back arm          
	bl      WrapperR8           
	cmp     r0,0FFh 							;check if can't spawn        
	bne     @@Return
	mov     r0,0h           
	strh    r0,[r5]							;0 to status, kill sprite
@@Return:
	add     sp,0Ch          
	pop     r3              
	mov     r8,r3           
	pop     r4-r7           
	pop     r0
	bx		r0                                     

SetMoveAI:    
	push    r14         
	ldr     r1,=CurrSpriteData
	mov     r2,r1       
	add     r2,24h      
	mov     r3,0h       
	mov     r0,2h       
	strb    r0,[r2]								;pose = 2, Move AI     
	ldr     r0,=ArachOAM_0						;OAM pointer
	str     r0,[r1,18h] 
	strb    r3,[r1,1Ch] 
	strh    r3,[r1,16h] 
	bl      HitboxSet   
	ldr     r0,=ArachOAM_1						;OAM pointer?
	bl      StoreOAMToSprite							;routine seems to store OAM to a sprite     
	pop     r0
	bx		r0         
.pool

MoveAI:    
	push    r4-r6,r14                                    
	mov     r6,0h                                        
	ldr     r4,=CurrSpriteData                                 
	ldrh    r1,[r4]                                      
	mov     r0,40h                                       
	and     r0,r1                                        
	cmp     r0,0h 								;checking if flipped, 40h = facing right                                    
	beq     @@FacingLeft                                     
	ldrh    r0,[r4,2h]							;sprite Y                                   
	mov     r2,10h                                       
	ldsh    r1,[r4,r2]							;right hitbox                                   
	ldrh    r2,[r4,4h]							;sprite X                                   
	add     r1,r1,r2								;sprite rightmost position                                     
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                                     
	ldr     r5,=30007F1h                                 
	ldrb    r1,[r5]                                      
	mov     r0,0F0h                                      
	and     r0,r1                                        
	cmp     r0,0h 								;checking if bottom right has hit a wall                                       
	beq     @@SetPose7                                     
	ldrh    r0,[r4,2h] 							;sprite Y                                  
	sub     r0,48h                                       
	mov     r2,10h                                       
	ldsh    r1,[r4,r2]                                   
	ldrh    r4,[r4,4h]                                   
	add     r1,r1,r4 								;sprite rightmost position                                     
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                                      
	ldrb    r1,[r5]                                      
	mov     r0,0Fh 								;checking if top right is hitting wall                                      
	and     r0,r1                                 ;not sure why the value checks are any different      
	cmp     r0,0h                                        
	beq     @@HitWallCheck                                    
	b       @@SetPose7                                     
.pool
@@FacingLeft:
	ldrh    r0,[r4,2h]							;sprite y                                   
	mov     r2,0Eh                                       
	ldsh    r1,[r4,r2]							;left hitbox                                   
	ldrh    r2,[r4,4h]							;sprite X                                   
	add     r1,r1,r2 								;sprite leftmost position                                    
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                                     
	ldr     r5,=30007F1h                                 
	ldrb    r1,[r5]                                      
	mov     r0,0F0h                                      
	and     r0,r1                                        
	cmp     r0,0h									;checking if bottom left hit wall                                        
	beq     @@SetPose7                                    
	ldrh    r0,[r4,2h]							;sprite Y                                   
	sub     r0,48h                                       
	mov     r2,0Eh                                       
	ldsh    r1,[r4,r2]                                   
	ldrh    r4,[r4,4h]                                   
	add     r1,r1,r4								;sprite leftmost position                                     
	ldr		r3,=CheckClip + 1
	bl      WrapperR3                                      
	ldrb    r1,[r5]                                      
	mov     r0,0Fh                                       
	and     r0,r1									;checking if top left is hitting wall                                        
	cmp     r0,0h 								;not sure why the value checks are any different                                        
	beq     @@HitWallCheck                                     
	mov     r6,1h									;value for hitting wall
@@HitWallCheck:
	cmp     r6,0h									;0 if not hitting wall                                        
	beq     @@AnimationCheck
@@SetPose7:
	ldr     r0,=CurrSpriteData                                 
	add     r0,24h                                       
	mov     r1,7h                                        
	strb    r1,[r0] 								;pose = 7, before turn                                     
	b       @@CheckAttack                                     
.pool
@@AnimationCheck:                                    
	ldr     r1,=CurrSpriteData                                 
	ldrh    r0,[r1,16h]							;current animation frame                                  
	cmp     r0,1h                                        
	beq     @@Speed2                                     
	cmp     r0,1h                                        
	bgt     @@AnimationCheck2                                     
	cmp     r0,0h                                        
	beq     @@AimationTimerCheck                                     
	b       @@NoSpeed                                     
.pool 
@@AnimationCheck2:
	cmp     r0,2h                                        
	beq     @@Speed1                                    
	cmp     r0,3h                                        
	beq     @@Speed2                                     
	b       @@NoSpeed
@@AimationTimerCheck:
	mov     r4,1h									;movement speed value                                        
	ldrb    r0,[r1,1Ch] 							;animation timer                              
	cmp     r0,9h                                        
	bne     @@DirectionCheck                                     
	ldr     r0,=16Bh
	ldr		r3,=PlaySound + 1
	bl      WrapperR3                                     
	b       @@DirectionCheck
@@Speed1:                                    
	mov     r4,3h                                        
	b       @@DirectionCheck
@@Speed2:
	mov     r4,2h                                        
	b       @@DirectionCheck
@@NoSpeed:
	mov     r4,0h
@@DirectionCheck:
	ldr     r3,=CurrSpriteData                                
	ldrh    r1,[r3]                                      
	mov     r0,40h                                       
	and     r0,r1                                        
	cmp     r0,0h									;checking direction, 40h = right                                        
	beq     @@MoveLeft                                     
	ldrh    r0,[r3,4h]                                   
	add     r0,r4,r0                                     
	strh    r0,[r3,4h]							;moves sprite rightward based on r4                                   
	ldr     r2,=SpriteSlot0                                
	mov     r0,r3                                        
	add     r0,2Fh                                       
	ldrb    r1,[r0]                                      
	lsl     r0,r1,3h                                     
	sub     r0,r0,r1                                     
	lsl     r0,r0,3h                                     
	add     r0,r0,r2                                     
	ldrh    r1,[r0,4h]							;moves secondary sprite (shell?) same amount                                   
	add     r1,r4,r1                                     
	b       @@Store                                     
.pool
@@MoveLeft:
	ldrh    r0,[r3,4h]                                   
	sub     r0,r0,r4                                     
	strh    r0,[r3,4h]							;moves sprite leftward based on r4                                    
	ldr     r2,=SpriteSlot0                                 
	mov     r0,r3                                        
	add     r0,2Fh                                       
	ldrb    r1,[r0]                                      
	lsl     r0,r1,3h                                     
	sub     r0,r0,r1                                     
	lsl     r0,r0,3h                                     
	add     r0,r0,r2                                     
	ldrh    r1,[r0,4h]                                   
	sub     r1,r1,r4
@@Store:
	strh    r1,[r0,4h]							;moves secondary sprite (shell?) same amount
@@CheckAttack:
	bl      CheckAttack                                     
	pop     r4-r6                                        
	pop     r0
	bx		r0                                           
.pool

PreIdle:   
	push    r4,r14 								;AI run before going idle (which happens before turning)           
	ldr     r0,=CurrSpriteData       
	mov     r1,r0              
	add     r1,2Fh 							          
	ldrb    r2,[r1]            
	sub     r1,1h              
	ldrb    r1,[r1]            
	mov     r3,r0              
	cmp     r1,0FFh            
	bne     @@NewPose           
	ldrh    r1,[r3] 
	ldr		r0,=7FFBh         
	and     r0,r1              
	mov     r4,0h              
	strh    r0,[r3] 								;removes 8004h
	mov		r1,r3
	add		r1,25h
	mov		r0,4h
	strb	r0,[r1]									;hurt samus
	add		r1,0Dh
	mov		r0,0h
	strb	r0,[r1]
	ldr     r1,=SpriteSlot0       
	lsl     r0,r2,3h           
	sub     r0,r0,r2           
	lsl     r0,r0,3h           
	add     r2,r0,r1           
	ldrh    r0,[r2]            
	ldr     r1,=0FF7Fh         
	and     r1,r0              
	strh    r1,[r2] 							;removes 80h flag from shell           
	ldr     r0,=0FF60h         
	strh    r0,[r2,0Ah]						;top hitbox of shell        
	strh    r4,[r2,0Ch]  						;bottom hitbox of shell      
	mov     r0,40h             
	and     r0,r1              
	lsl     r0,r0,10h          
	lsr     r0,r0,10h 						;checking direction          
	cmp     r0,0h              
	beq     @@FacingLeft           
	ldr     r0,=0FFB0h         
	strh    r0,[r2,0Eh] 						;left hitbox of shell       
	strh    r4,[r2,10h]						;right hitbox of shell        
	b       @@NewPose          
.pool
@@FacingLeft:
	strh    r0,[r2,0Eh] 						;left hitbox of shell       
	mov     r0,50h             
	strh    r0,[r2,10h] 						;right hitbox of shell
@@NewPose:
	mov     r1,r3              
	add     r1,24h             
	mov     r2,0h              
	mov     r0,8h              
	strb    r0,[r1] 							;pose = 8, Idle/pre-turning pose           
	ldr     r0,=ArachOAM_11 						;OAM pointer      
	str     r0,[r3,18h]        
	strb    r2,[r3,1Ch]        
	strh    r2,[r3,16h]        
	bl      HitboxSet          
	ldr     r0,=ArachOAM_12						;OAM pointer       
	bl      StoreOAMToSprite
	pop     r4                 
	pop     r0
	bx		r0                
.pool

IdleAI:
	push    r14                          
	ldr     r3,=CheckAlmostEndOfAnimation + 1
	bl		WrapperR3
	cmp     r0,0h          
	beq     @@Return      
	ldr     r2,=CurrSpriteData   
	ldrh    r1,[r2]							;checking direction, 40h = right        
	mov     r0,40h         
	and     r0,r1          
	cmp     r0,0h          
	beq     @@FacingLeft       
	ldr     r1,=SamusData   
	ldrh    r0,[r2,4h]						;sprite X     
	mov     r3,1h          
	ldrh    r1,[r1,12h]						;Samus X    
	cmp     r0,r1          
	bls     @@StorePose							;checking if Samus is in front of/if sprite should turn      
	b       @@Turn       
.pool
@@FacingLeft:
	ldr     r1,=SamusData   
	ldrh    r0,[r2,4h]						;sprite X     
	mov     r3,1h          
	ldrh    r1,[r1,12h]						;Samus X    
	cmp     r0,r1								;checking if Samus is in front of/if sprite should turn            
	bcs     @@StorePose
@@Turn:
	mov     r3,3h
@@StorePose:
	mov     r0,r2          
	add     r0,24h							;pose = 3 or 1 based on condition         
	strb    r3,[r0]
@@Return:
	pop     r0
	bx		r0          
.pool

StartTurnAI:
	push    r14                       
	ldr     r1,=CurrSpriteData              
	mov     r2,r1                     
	add     r2,24h                    
	mov     r3,0h                     
	mov     r0,4h                     
	strb    r0,[r2]									;pose = 4                   
	ldr     r0,=ArachOAM_5								;OAM pointer              
	str     r0,[r1,18h]               
	strb    r3,[r1,1Ch]               
	strh    r3,[r1,16h]               
	ldr     r0,=0FFE0h                
	strh    r0,[r1,0Eh]								;left hitbox               
	mov     r0,20h                    
	strh    r0,[r1,10h]								;right hitbox               
	ldr     r0,=ArachOAM_6             
	bl      StoreOAMToSprite       
	pop     r0
	bx		r0                       
.pool

TurnAI:
	push    r14									;AI that flips sprite direction                                  
	ldr     r1,=CurrSpriteData 
	mov     r0,r1         
	add     r0,2Fh        
	ldrb    r3,[r0]								;shell slot       
	ldrb    r0,[r1,1Ch]							;animation timer   
	cmp     r0,4h         
	bne     @@CheckAlmostEnd      
	ldrh    r0,[r1,16h]							;current animation   
	cmp     r0,2h         
	bne     @@CheckAlmostEnd      
	ldrh    r0,[r1]       
	mov     r2,40h        
	eor     r0,r2         
	strh    r0,[r1]								;flipping sprite's X direction       
	ldr     r1,=SpriteSlot0  
	lsl     r0,r3,3h      
	sub     r0,r0,r3      
	lsl     r0,r0,3h      
	add     r3,r0,r1      
	ldrh    r0,[r3]       
	eor     r0,r2         
	strh    r0,[r3] 								;flippind shell X direction      
	mov     r1,40h        
	and     r0,r1 								;checking direction, 40h = right        
	lsl     r0,r0,10h     
	lsr     r0,r0,10h     
	cmp     r0,0h			         
	beq     @@StoreLeftHitbox      
	ldr     r0,=0FFB0h    
	strh    r0,[r3,0Eh]							;left hitbox   
	mov     r0,0h         
	b       @@StoreRightHitbox      
.pool 
@@StoreLeftHitbox:
	strh    r0,[r3,0Eh] 							;left hitbox  
	mov     r0,50h
@@StoreRightHitbox:
	strh    r0,[r3,10h] 							;right hitbox
@@CheckAlmostEnd:
	ldr     r3,=CheckAlmostEndOfAnimation + 1
	bl		WrapperR3
	cmp     r0,0h         
	beq     @@Return      
	ldr     r0,=CurrSpriteData  
	add     r0,24h        
	mov     r1,1h         
	strb    r1,[r0]									;pose = 1
@@Return:
	pop     r0
	bx		r0            
.pool

MainAI:   
	push    r14                
	ldr     r2,=CurrSpriteData      
	mov     r0,r2              
	add     r0,24h             
	ldrb    r3,[r0]						;check pose             
	cmp     r3,0h              
	beq     @@PoseCheck         
	ldrh    r0,[r2,14h] 					;check health       
	cmp     r0,0h              
	beq     @@Killed           
	mov     r0,r2              
	add     r0,2Bh             
	ldrb    r0,[r0]    					;stun timer        
	mov     r1,7Fh             
	and     r1,r0              
	cmp     r1,5h              
	bls     @@StunCheck           
	cmp     r3,2h              
	beq     @@CheckPose						;weird spot to branch to           
	cmp     r3,8h              
	bne     @@PoseCheck 
@@CheckPose:
	cmp     r3,3Eh             
	beq     @@PoseCheck           
	bl      PreHurtAI
	b       @@PoseCheck           
.pool
@@StunCheck:
	cmp     r1,2h              
	bls     @@PoseCheck           
	ldrh    r0,[r2]            
	mov     r3,80h             
	lsl     r3,r3,3h           
	mov     r1,r3              
	mov     r3,0h              
	orr     r1,r0              
	strh    r1,[r2] 						;turns on 400h           
	mov     r1,r2              
	add     r1,2Eh 						;attack cooldown             
	ldrb    r0,[r1]            
	cmp     r0,0FFh            
	beq     @@PoseCheck           
	strb    r3,[r1]            
	b       @@PoseCheck
@@Killed:
	bl      DeadAI
@@PoseCheck:
	ldr     r0,=CurrSpriteData       
	add     r0,24h             
	ldrb    r0,[r0]            
	cmp     r0,5Ah             
	bls     @@JumpGet           
	b       @@Return
@@JumpGet:
	lsl     r0,r0,2h           
	ldr     r1,=@@JumpTable       
	add     r0,r0,r1           
	ldr     r0,[r0]            
	mov     r15,r0             
.pool
@@JumpTable:
	.word @@Spawn,@@StartMoving,@@Move
	.word @@PreTurn,@@Turn,@@Return,@@Return         
	.word @@PreIdle,@@Idle,@@Return,@@Return          
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Swipe,@@Return,@@Roll         
	.word @@Return,@@EndRoll,@@Return,@@Counter         
	.word @@Return,@@Fire,@@Return,@@Dying
	.word @@Waiting

@@Spawn:
	bl      Initialize                                 
	b       @@Return
@@StartMoving:
	bl      SetMoveAI
@@Move:
	bl      MoveAI                                     
	b       @@Return
@@PreIdle:
	bl      PreIdle
@@Idle:
	bl      IdleAI                                  
	b       @@Return
@@PreTurn:
	bl      StartTurnAI
@@Turn:
	bl      TurnAI                                  
	b       @@Return
@@Swipe:
	bl      SwipingAI                                  
	b       @@Return
@@Roll:
	bl      RollingAI                                  
	b       @@Return
@@EndRoll:                                  
	bl      EndRollAI                                  
	b       @@Return
@@Counter:
	bl      CounterAttack                                  
	b       @@Return
@@Fire:
	bl      FireballAttack                                  
	b       @@Return
@@Dying:
	bl      ArachDying
	b 		@@Return
@@Waiting:
	bl		ArachWait
@@Return:
	pop     r0
	bx		r0                                        
.pool