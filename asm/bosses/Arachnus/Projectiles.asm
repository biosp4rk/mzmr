;.notice "Arach Fire AI"
;.notice tohex(.)
FireballMainAI:   
	push    r4-r7,r14          
	add     sp,-0Ch            
	ldr     r3,=CurrSpriteData       
	mov     r0,r3              
	add     r0,23h             
	ldrb    r1,[r0]            
	ldr     r2,=SpriteSlot0       
	lsl     r0,r1,3h           
	sub     r0,r0,r1           
	lsl     r0,r0,3h           
	add     r0,r0,r2 						;arachnus sprite slot          
	add     r0,24h             
	ldrb    r0,[r0]						;arachnus pose            
	mov     r4,r3              
	cmp     r0,42h						;dying pose             
	bne     @@PoseCheck           
	mov     r1,r4              
	add     r1,24h             
	ldrb    r0,[r1]            
	cmp     r0,2Dh             
	beq     @@PoseCheck           
	mov     r0,2Dh             
	strb    r0,[r1]						;pose = 38, phase out             
	add     r1,0Ah             
	mov     r0,28h						;phase out timer             
	strb    r0,[r1]
@@PoseCheck:
	mov     r0,r4              
	add     r0,24h             
	ldrb    r0,[r0] 						;pose           
	cmp     r0,2Dh             
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
	.word @@Initialize,@@Return,@@Falling,@@Return
	.word @@Return,@@Return,@@Return,@@Return          
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@SpawnPillars,@@Return,@@Grow,@@Return         
	.word @@Shrink1,@@Return,@@Return,@@Return         
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Shrink2,@@Return          
	.word @@Done,@@PhaseOut
@@Initialize:	
	mov     r2,r4              
	add     r2,32h             
	ldrb    r1,[r2]            
	mov     r0,4h              
	mov     r5,0h              
	orr     r0,r1              
	strb    r0,[r2]  					;4h to collision properties          
	ldrh    r1,[r4]            
	ldr     r0,=0FFFBh         
	and     r0,r1              
	mov     r3,0h              
	strh    r0,[r4] 					;removes 4h (invisible flag) from status           
	mov     r0,r4              
	add     r0,22h             
	mov     r2,2h              
	strb    r2,[r0]            
	mov     r1,r4              
	add     r1,27h             
	mov     r0,28h             
	strb    r0,[r1]            
	mov     r0,r4              
	add     r0,28h             
	strb    r3,[r0]            
	add     r1,2h              
	mov     r0,8h              
	strb    r0,[r1]					;drawing related            
	strh    r5,[r4,0Ch]				;bottom hitbox        
	ldr     r0,=0FFE8h         
	strh    r0,[r4,0Eh]   			;left hitbox     
	mov     r0,18h             
	strh    r0,[r4,10h] 				;right hitbox       
	mov     r0,r4              
	add     r0,2Eh             
	strb    r3,[r0] 					;0 to timer           
	ldrb    r0,[r4,1Eh]        
	cmp     r0,0h              
	bne     @@Pillar          
	ldr     r0,=ProjectileArachOAM_3 				;OAM pointer      
	str     r0,[r4,18h]        
	strb    r3,[r4,1Ch]        
	strh    r5,[r4,16h]        
	mov     r0,r4              
	add     r0,24h             
	strb    r2,[r0] 					;pose = 2          
	add     r0,1h 
	mov		r2,4h
	strb    r2,[r0]					;hurt samus            
	ldr     r0,=0FFD0h         
	strh    r0,[r4,0Ah]     			;top hitbox   
	b       @@Return           
.pool
@@Pillar:											;ran for the flame pillars spawned by initial flame
	ldr     r0,=ProjectileArachOAM_2 				;OAM pointer      
	str     r0,[r4,18h]        
	strb    r3,[r4,1Ch]        
	strh    r5,[r4,16h]        
	mov     r0,r4              
	add     r0,25h 
	mov		r2,4h
	strb    r2,[r0]					;hurts Samus            
	mov     r1,r4              
	add     r1,24h             
	mov     r0,18h             
	strb    r0,[r1] 					;pose = 18h           
	b       @@HitboxSet
.pool

@@Falling:
	ldrh    r0,[r4,2h]				;AI that moves fireball downward to ground         
	ldrh    r1,[r4,4h]				;checking if fireball hit floor         
	ldr		r3,=CheckClip + 1
	bl      WrapperR3           
	ldr     r0,=30007F1h       
	ldrb    r0,[r0]            
	cmp     r0,0h              
	beq     @@MoveDown          
	mov     r1,r4              
	add     r1,24h             
	mov     r2,0h              
	mov     r0,18h             
	strb    r0,[r1]					;pose = 18            
	add     r1,1h              
	mov     r0,4h              
	strb    r0,[r1]					;hurts samus            
	ldr     r0,=ProjectileArachOAM_2 				;OAM pointer      
	str     r0,[r4,18h]        
	strb    r2,[r4,1Ch]        
	strh    r2,[r4,16h]
@@HitboxSet:
	ldr     r0,=0FFC0h         
	strh    r0,[r4,0Ah]				;top hitbox        
	ldr     r0,=1F1h            	;fire rise
	ldr		r3,=PlaySound + 1
	bl      WrapperR3
	b		@@Return
.pool
@@MoveDown:
	ldrh    r0,[r4,2h]         
	add     r0,5h              
	strh    r0,[r4,2h]				;sprite Y, moving downwards         
	ldrh    r1,[r4]            
	mov     r0,40h             
	and     r0,r1              
	cmp     r0,0h 					;checking direction, 40h = right             
	beq     @@MoveLeft           
	ldrh    r0,[r4,4h]         
	add     r0,6h              
	strh    r0,[r4,4h]				;sprite X, moving right         
	b       @@Return
@@MoveLeft:
	ldrh    r0,[r4,4h]         
	sub     r0,6h              
	strh    r0,[r4,4h] 				;;sprite X, moving left        
	b       @@Return
@@SpawnPillars:
	ldr		r6,=SpawnSecondarySprite + 1
	mov     r1,r4						;AI that spawns additional pillars of fire              
	add     r1,2Eh             
	ldrb    r0,[r1]            
	add     r0,1h              
	strb    r0,[r1]					;timer                     
	cmp     r0,8h              
	bne     @@CheckAnimationOver          
	ldrb    r0,[r4,1Eh]				;part number        
	cmp     r0,6h						;spawn no more than 6 pillars              
	bhi     @@CheckAnimationOver           
	ldrh    r1,[r4]            
	mov     r7,40h             
	mov     r0,r7              
	and     r0,r1						;checking direction, 40 = right              
	lsl     r0,r0,10h          
	lsr     r5,r0,10h          
	cmp     r5,0h              
	beq     @@SpawnLeft          
	ldrb    r1,[r4,1Eh]        
	add     r1,1h              
	ldrb    r2,[r4,1Fh]        
	mov     r0,r4              
	add     r0,23h             
	ldrb    r3,[r0]            
	ldrh    r0,[r4,2h]         
	str     r0,[sp]            
	ldrh    r0,[r4,4h]         
	add     r0,38h             
	str     r0,[sp,4h]         
	str     r7,[sp,8h]						;arguments for spawning next fire pillar 
;.notice "Arach Fire"
;.notice tohex(.)	
	mov     r0,FireID							;fireball ID             
	bl      WrapperR6           
	b       @@CheckAnimationOver 
@@SpawnLeft:
	ldrb    r1,[r4,1Eh]        
	add     r1,1h              
	ldrb    r2,[r4,1Fh]        
	mov     r0,r4              
	add     r0,23h             
	ldrb    r3,[r0]            
	ldrh    r0,[r4,2h]         
	str     r0,[sp]            
	ldrh    r0,[r4,4h]         
	sub     r0,38h             
	str     r0,[sp,4h]         
	str     r5,[sp,8h] 					;arguments for spawning next fire pillar 
;.notice "Arach Fire"
;.notice tohex(.)	
	mov     r0,FireID           			 	;fireball ID              
	bl      WrapperR6
@@CheckAnimationOver:
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3          
	cmp     r0,0h              
	bne     @@GetPose           
	b       @@Return
@@GetPose:
	ldr     r1,=CurrSpriteData       
	mov     r2,r1              
	add     r2,24h             
	mov     r3,0h              
	mov     r0,1Ah             
	b       @@StorePose           
.pool

@@Grow:
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3 		;AI increases fire pillar size           
	cmp     r0,0h              
	beq     @@Return           
	ldr     r1,=CurrSpriteData       
	mov     r2,r1              
	add     r2,24h             
	mov     r3,0h              
	mov     r0,1Ch 					;pose = 1C            
	strb    r0,[r2]            
	ldr     r0,=ProjectileArachOAM_0				;OAM pointer       
	str     r0,[r1,18h]        
	strb    r3,[r1,1Ch]        
	strh    r3,[r1,16h]        
	ldr     r0,=0FF80h         
	strh    r0,[r1,0Ah]				;top hitbox        
	b       @@Return           
.pool

@@Shrink1:
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3 			;AI increases fire pillar size            
	cmp     r0,0h              
	beq     @@Return           
	ldr     r1,=CurrSpriteData       
	mov     r2,r1              
	add     r2,24h             
	mov     r3,0h              
	mov     r0,2Ah 
@@StorePose:
	strb    r0,[r2]					;pose = 2Ah            
	ldr     r0,=ProjectileArachOAM_1				;OAM pointer       
	str     r0,[r1,18h]        
	strb    r3,[r1,1Ch]        
	strh    r3,[r1,16h]        
	ldr     r0,=0FFA0h         
	strh    r0,[r1,0Ah]				;top hitbox        
	b       @@Return           
.pool

@@Shrink2:
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3 			;AI decreases fire pillar size          
	cmp     r0,0h              
	beq     @@Return           
	ldr     r1,=CurrSpriteData       
	mov     r2,r1              
	add     r2,24h             
	mov     r3,0h              
	mov     r0,2Ch             
	strb    r0,[r2]						;pose = 2C            
	ldr     r0,=ProjectileArachOAM_2					;OAM pointer       
	str     r0,[r1,18h]        
	strb    r3,[r1,1Ch]        
	strh    r3,[r1,16h]        
	ldr     r0,=0FFC0h         
	strh    r0,[r1,0Ah] 					;top hitbox       
	b       @@Return           
.pool
@@Done:
	ldr		r3,=CheckEndOfAnimation + 1
	bl      WrapperR3 			;AI ran when fire is done burning          
	cmp     r0,0h              
	beq     @@Return           
	ldr     r1,=CurrSpriteData       
	mov     r0,0h              
	strh    r0,[r1]						;kill sprite            
	ldrh    r0,[r1,2h]					;sprite Y         
	ldrh    r1,[r1,4h]					;sprite X         
	mov     r2,1Fh             
	ldr		r3,=SetParticleEffect + 1
	bl      WrapperR3 
	b       @@Return           
.pool
 
@@PhaseOut:
	mov     r1,r4              
	add     r1,26h             
	mov     r0,1h              
	strb    r0,[r1]						;sprite is made intangible             
	ldr     r1,=FrameCounter       
	ldrb    r1,[r1]            
	and     r0,r1              
	cmp     r0,0h 						;check that makes code below run every other frame             
	bne     @@Decrement           
	ldrh    r0,[r4]            
	mov     r1,4h              
	eor     r0,r1              
	strh    r0,[r4]						;toggles 4h (invisible flag) to give phasing out look 
@@Decrement:
	mov     r1,r4              
	add     r1,2Eh             
	ldrb    r0,[r1]            
	sub     r0,1h              
	strb    r0,[r1]						;phase out timer            
	lsl     r0,r0,18h          
	lsr     r0,r0,18h          
	cmp     r0,0h              
	bne     @@Return           
	strh    r0,[r4] 						;kill sprite           
	b       @@Return           
.pool
@@Return:
	add     sp,0Ch             
	pop     r4-r7              
	pop     r0
	bx		r0                 

;.notice "Arach Swipe AI"
;.notice tohex(.)
SwipeMainAI:
	push    r4-r7,r14                        
	add     sp,-0Ch            
	ldr     r2,=SpriteSlot0       
	ldr     r3,=CurrSpriteData       
	mov     r0,r3              
	add     r0,23h             
	ldrb    r1,[r0]						;Arachnus' sprite slot            
	lsl     r0,r1,3h           
	sub     r0,r0,r1           
	lsl     r0,r0,3h           
	add     r0,r0,r2           
	add     r0,24h             
	ldrb    r0,[r0] 						;arachnus pose           
	mov     r2,r3              
	cmp     r0,42h						;dying pose             
	bne     @@PoseCheck           
	mov     r1,r2              
	add     r1,24h             
	ldrb    r0,[r1]						;checking pose		            
	cmp     r0,38h             
	beq     @@PoseCheck           
	mov     r0,38h             
	strb    r0,[r1]							;pose = 38            
	add     r1,0Ah							;2Eh             
	mov     r0,28h             
	strb    r0,[r1] 						;timer for phasing out           
@@PoseCheck:
	mov     r5,r2              
	mov     r7,r5              
	add     r7,24h             
	ldrb    r6,[r7]						;pose            
	cmp     r6,2h							;pose 2 = moving pose              
	beq     @@CheckHitWall          
	cmp     r6,2h              
	bgt     @@PoseCheck2          
	cmp     r6,0h              
	beq     @@Initialize           
	b       @@Return           
.pool
@@PoseCheck2:
	cmp     r6,38h             
	bne     @@PreReturn						;should just branch to @@Return	           
	b       @@PhaseOut
@@PreReturn:
	b       @@Return					
@@Initialize: 
	ldrh    r0,[r5]            
	mov     r1,80h             
	lsl     r1,r1,8h 							;turing on 8000h flag          
	mov     r2,r1              
	mov     r4,0h              
	orr     r2,r0              
	mov     r3,r5              
	add     r3,32h             
	ldrb    r1,[r3]            
	mov     r0,4h              
	orr     r0,r1              
	strb    r0,[r3]							;turing 4h on collision property            
	ldr     r0,=0FFFBh 						;removes 4h (invisibility flag) from status        
	and     r2,r0              
	strh    r2,[r5]            
	mov     r1,r5              
	add     r1,22h             
	mov     r0,3h              
	strb    r0,[r1]							;?            
	add     r1,5h              
	mov     r0,30h             
	strb    r0,[r1]            
	mov     r0,r5              
	add     r0,28h             
	strb    r4,[r0]            
	add     r1,2h              
	mov     r0,38h             
	strb    r0,[r1]							;all drawing related            
	ldr     r0,=0FF40h         
	strh    r0,[r5,0Ah]						;top hitbox        
	strh    r6,[r5,0Ch]						;bottom hitbox        
	add     r0,0A0h            
	strh    r0,[r5,0Eh]						;left hitbox        
	mov     r0,20h             
	strh    r0,[r5,10h] 						;right hitbox       
	ldr     r0,=ProjectileArachOAM_4						;OAM pointer       
	str     r0,[r5,18h]        
	strb    r4,[r5,1Ch]        
	strh    r6,[r5,16h]        
	sub     r1,4h              
	mov     r0,4h              
	strb    r0,[r1]							;hurts Samus
	mov		r0,2h
	strb    r0,[r7] 						;pose = 2           
	mov     r4,40h             
	and     r2,r4              
	lsl     r2,r2,10h          
	lsr     r1,r2,10h          
	cmp     r1,0h								;checking direction, 40h = right              
	beq     @@LeftArguments           
	ldrb    r2,[r5,1Fh]        
	mov     r0,r5              
	add     r0,23h             
	ldrb    r3,[r0]            
	ldrh    r0,[r5,2h]         
	sub     r0,0Ch             
	str     r0,[sp]            
	ldrh    r0,[r5,4h]         
	str     r0,[sp,4h]         
	str     r4,[sp,8h]					;arguments for spawning facing right
	b       @@SpawnBottom        
.pool          
@@LeftArguments:  
	ldrb    r2,[r5,1Fh]        
	mov     r0,r5              
	add     r0,23h             
	ldrb    r3,[r0]            
	ldrh    r0,[r5,2h]         
	sub     r0,0Ch             
	str     r0,[sp]            
	ldrh    r0,[r5,4h]         
	str     r0,[sp,4h]         
	str     r1,[sp,8h]					;arguments for spawning facing right 
@@SpawnBottom:
;.notice "Arach Part"
;.notice tohex(.)
	mov     r0,PartsID 						;bottom of slash ID            
	mov     r1,4h
	ldr		r6,=SpawnSecondarySprite + 1
	bl      WrapperR6
	mov		r1,r0
	cmp     r1,0FFh 						;true if cannot spawn           
	bne     @@StoreSlot           
	ldr     r1,=CurrSpriteData       
	mov     r0,0h              
	strh    r0,[r1]						;kills sprite             
	b       @@Return           
.pool
@@StoreSlot:
	ldr     r0,=CurrSpriteData       
	add     r0,2Fh             
	strb    r1,[r0]						;stores slot number for bottom of slash            
	b       @@Return           
.pool
@@CheckHitWall:
	ldrh    r0,[r5,2h]					;sprite Y        
	sub     r0,60h             
	ldrh    r1,[r5,4h]					;sprite X        
	ldr		r3,=CheckClip + 1
	bl      WrapperR3 						;checking if top of sprite is in a wall           
	ldr     r0,=30007F1h       
	ldrb    r0,[r0]            
	cmp     r0,0h							;0 = in air              
	beq     @@DirectionCheck           
	mov     r2,0h              
	strh    r2,[r5]						;kills swipe            
	ldr     r3,=SpriteSlot0       
	mov     r0,r5              
	add     r0,2Fh             
	ldrb    r1,[r0]            
	lsl     r0,r1,3h           
	sub     r0,r0,r1           
	lsl     r0,r0,3h           
	add     r0,r0,r3 						;slot for bottom of wave          
	strh    r2,[r0]						;kills bottom sprite            
	ldrh    r0,[r5,2h]         
	sub     r0,60h             
	ldrh    r1,[r5,4h]         
	mov     r2,1Fh 						;middle
	ldr		r6,=SetParticleEffect + 1
	bl      WrapperR6         
	ldrh    r0,[r5,2h]         
	sub     r0,20h             
	ldrh    r1,[r5,4h]         
	mov     r2,1Fh      					;bottom       
	bl      WrapperR6            
	ldrh    r0,[r5,2h]         
	sub     r0,0A0h            
	ldrh    r1,[r5,4h]  					;top       
	mov     r2,1Fh             
	bl      WrapperR6           
	mov     r0,96h
	lsl		r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3          
	b       @@Return           
.pool
@@DirectionCheck:
	ldrh    r1,[r5]            
	mov     r0,40h             
	and     r0,r1              
	cmp     r0,0h							;checking direction, 40h = right              
	beq     @@MoveLeft           
	ldrh    r0,[r5,4h]					;sprite X         
	add     r0,0Ch             
	b       @@StoreX
@@MoveLeft:
	ldrh    r0,[r5,4h]					;sprite X         
	sub     r0,0Ch
@@StoreX:
	strh    r0,[r5,4h]         
	ldr     r3,=SpriteSlot0       
	ldr     r2,=CurrSpriteData       
	mov     r0,r2              
	add     r0,2Fh             
	ldrb    r1,[r0]            
	lsl     r0,r1,3h           
	sub     r0,r0,r1           
	lsl     r0,r0,3h           
	add     r0,r0,r3						;swipe bottom, slot           
	ldrh    r1,[r2,4h]         
	strh    r1,[r0,4h]					;matches bottom X pos with swipe's X      
	b       @@Return           
.pool
@@PhaseOut:
	mov     r1,r5							;run if arachnus is killed while swipe is active              
	add     r1,26h             
	mov     r0,1h              
	strb    r0,[r1]						;makes sprite intangible             
	ldr     r1,=FrameCounter       
	ldrb    r1,[r1]            
	and     r0,r1              
	cmp     r0,0h 						;used to make below code run every other frame             
	bne     @@Decrement           
	ldrh    r0,[r5]            
	mov     r1,4h              
	eor     r0,r1              
	strh    r0,[r5]						;toggles 4h (invisible flag) every other frame
@@Decrement:
	mov     r1,r2              
	add     r1,2Eh             
	ldrb    r0,[r1]            
	sub     r0,1h              
	strb    r0,[r1]						;death timer, when 0, kill            
	lsl     r0,r0,18h          
	lsr     r0,r0,18h          
	cmp     r0,0h              
	bne     @@Return           
	strh    r0,[r2]						;kills swipe wave
@@Return:
	add     sp,0Ch             
	pop     r4-r7              
	pop     r0
	bx		r0                 
.pool