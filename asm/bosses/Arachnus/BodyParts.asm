.notice "Arach Part AI"
.notice tohex(.)
BodyPartsMainAI:
	push	r14
	ldr		r1,=CurrSpriteData
	ldrb	r0,[r1,1Eh]						;part number
	cmp		r0,4h							;safty measure
	bgt		@@Kill
	lsl		r0,r0,2h
	ldr		r1,=@@JumpTable
	add		r0,r0,r1
	ldr		r0,[r0]
	mov		r15,r0
.pool
@@JumpTable:
	.word @@Return,@@Head,@@FrontArm
	.word @@BackArm,@@SwipeBottom
@@Head:
	bl		HeadMainAI
	b		@@Return
@@FrontArm:
	bl		FrontArmMainAI
	b		@@Return
@@BackArm:
	bl		BackArmMainAI
	b 		@@Return
@@SwipeBottom:
	bl		BottomSwipeMainAI
	b		@@Return
@@Kill:
	mov		r0,0h
	strh	r0,[r1]
@@Return:
	pop     r0
	bx		r0

MatchMainSpriteAI:
	push    r4-r6,r14 						;AI matches certain RAM values with it's primary sprite 
	add		sp,-4h
	ldr     r1,=CurrSpriteData
	mov     r2,r1        
	add     r2,26h       
	mov     r0,1h        
	strb    r0,[r2] 					;makes samus unable to interact with sprite     
	mov     r0,r1        
	add     r0,23h					;arachnus primary sprite ram slot       
	ldrb    r5,[r0]      
	ldr     r2,=SpriteSlot0
	lsl     r0,r5,3h     
	sub     r0,r0,r5     
	lsl     r0,r0,3h     
	add     r0,r0,r2 
	str		r0,[sp]					;saves some space later
	add     r0,24h 					;arachnus pose      
	ldrb    r0,[r0]      
	mov     r4,r1        
	mov     r6,r2        
	cmp     r0,2h						;2 = walking         
	beq     @@MoveSprite    
	cmp     r0,2h        
	bgt     @@PoseCheck     
	cmp     r0,1h						;1 = starting to move        
	beq     @@ResetAnimation     
	b       @@SetStatus     
.pool 
@@PoseCheck:
	cmp     r0,7h						;7 = PreIdle         
	beq     @@MoveSprite     
	b       @@SetStatus
@@ResetAnimation:
	ldrh    r1,[r4]      
	ldr		r0,=7FFBh
	and     r0,r1        
	mov     r1,0h        
	strh    r0,[r4]					;removing 8004h flag      
	strb    r1,[r4,1Ch]  
	mov     r0,0h        
	strh    r0,[r4,16h]				;resetting animation  
	b       @@MoveSprite     
.pool 
@@SetStatus:
	mov		r0,80h
	lsl		r0,r0,8h
	add		r0,4h
	ldrh    r1,[r4]      			;sets 8004h flag
	orr     r0,r1
	strh    r0,[r4]
@@MoveSprite:
	ldr		r0,[sp]
	ldrh    r1,[r0,2h]   
	strh    r1,[r4,2h]				;stores Arachnus Y pos to sprite   
	ldrh    r1,[r0,4h]   
	strh    r1,[r4,4h]				;stores Arachnus X pos to sprite   
	mov     r1,r0        
	add     r1,20h       
	ldrb    r2,[r1]					;load palette row of arachnus primary      
	mov     r1,r4        
	add     r1,20h       
	strb    r2,[r1] 					;store to sprite     
	ldrh    r1,[r0]      
	mov     r0,40h       
	and     r0,r1        
	cmp     r0,0h						;checking direction facing, 40h = right       
	beq     @@FacingLeft     
	ldrh    r0,[r4]      
	mov     r1,40h 					;setting 40h flag for sprite      
	orr     r0,r1        
	b       @@StoreStatus
@@FacingLeft:
	ldrh    r1,[r4]      
	ldr     r0,=0FFBFh 				;removing 40h flag 
	and     r0,r1
@@StoreStatus:
	strh    r0,[r4]      
	ldr		r0,[sp]
	ldrh	r1,[r0]
	mov		r2,1h
	and		r1,r2						;checking if sprite is alive 
	cmp		r1,0h						;needed if arachnus doesn't drop a pickup
	beq		@@CheckPart
	ldrb    r0,[r0,1Dh]					;checking if arachnus ID      
	cmp     r0,ArachID					;Arachnus ID, needed if arachnus dropped a pickup      
	beq     @@Return
@@CheckPart:
	ldrh    r1,[r4,2h]		;sprite Y position                                                                 
	ldrh    r2,[r4,4h]		;sprite X position
	ldrb	r0,[r4,1Eh]		;part number
	cmp		r0,1h
	beq		@@HeadDrop
	cmp		r0,2h
	beq		@@FrontArmDrop
	add		r2,20h
	sub		r1,2Bh
	b		@@Kill
@@HeadDrop:
	sub		r2,30h
	sub		r1,10h
	b		@@Kill
@@FrontArmDrop:
	add		r2,26h
	add		r1,40h
@@Kill:	
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r6,=SpriteDead + 1
	bl      WrapperR6
@@Return:
	add		sp,4h
	pop     r4-r6        
	pop     r0
	bx		r0
.pool

HeadMainAI: 
	push    r4,r5,r14							;secondary sprite 17h                    
	ldr     r3,=CurrSpriteData   
	mov     r5,r3          
	add     r5,24h         
	ldrb    r4,[r5]								;checking pose        
	cmp     r4,0h          
	bne     @@MatchPrimary       
	ldrh    r1,[r3]        
	ldr     r0,=0FFFBh     
	and     r0,r1          
	mov     r2,0h          
	strh    r0,[r3]								;remmoves 4h (invisible) flag        
	mov     r1,r3          
	add     r1,22h         
	mov     r0,3h          
	strb    r0,[r1]								;?        
	add     r1,5h          
	mov     r0,30h         
	strb    r0,[r1]        
	mov     r0,r3          
	add     r0,28h         
	strb    r2,[r0]        
	add     r1,2h          
	mov     r0,20h         
	strb    r0,[r1]								;all drawing related        
	ldr     r1,=0FFFCh     
	strh    r1,[r3,0Ah]							;top hitbox    
	mov     r0,4h          
	strh    r0,[r3,0Ch]							;bottom hitbox    
	strh    r1,[r3,0Eh]							;left hitbox    
	strh    r0,[r3,10h]							;right hitbox    
	ldr     r0,=ArachOAM_2 							;OAM pointer  
	str     r0,[r3,18h]    
	strb    r2,[r3,1Ch]    
	strh    r4,[r3,16h]    
	mov     r0,r3          
	add     r0,25h         
	strb    r2,[r0]								;0 to samus collision         
	mov     r0,2h          
	strb    r0,[r5]								;pose = 2
@@MatchPrimary:
	bl      MatchMainSpriteAI       
	pop     r4,r5          
	pop     r0
	bx		r0  
.pool

FrontArmMainAI:					
	push    r4-r6,r14 						;secondary sprite 18h                      
	ldr     r3,=CurrSpriteData 
	mov     r5,r3         
	add     r5,24h        
	ldrb    r4,[r5] 						;check pose      
	cmp     r4,0h         
	bne     @@MatchPrimary     
	ldrh    r1,[r3]       
	ldr     r0,=0FFFBh    
	and     r0,r1         
	mov     r2,0h         
	strh    r0,[r3]			       		;removing 4h (invisible) flag
	mov     r0,r3         
	add     r0,22h        
	mov     r1,4h         
	strb    r1,[r0]       				;?
	mov     r0,27h        
	add     r0,r0,r3      
	mov     r12,r0        
	mov     r0,20h        
	mov     r6,r12        
	strb    r0,[r6]       
	mov     r0,r3         
	add     r0,28h        
	strb    r2,[r0]       
	mov     r0,29h        
	add     r0,r0,r3      
	mov     r12,r0        
	mov     r0,28h        
	mov     r6,r12        
	strb    r0,[r6]						;all drawing related       
	ldr     r0,=0FFFCh    	
	strh    r0,[r3,0Ah]					;top hitbox   
	strh    r1,[r3,0Ch]   				;bottom hitbox
	strh    r0,[r3,0Eh]              		;left hitbox  
	strh    r1,[r3,10h]             	 	;right hitbox 
	ldr     r0,=ArachOAM_4					;OAM pointer  
	str     r0,[r3,18h]   
	strb    r2,[r3,1Ch]   
	strh    r4,[r3,16h]   
	mov     r0,r3         
	add     r0,25h 						     
	strb    r2,[r0] 						;cannot hurt samus      
	mov     r0,2h         
	strb    r0,[r5]						;pose = 2
@@MatchPrimary:
	bl      MatchMainSpriteAI      
	pop     r4-r6         
	pop     r0
	bx		r0            
.pool

BackArmMainAI:    
	push    r4-r6,r14  							;secondary sprite 19h                 
	ldr     r0,=CurrSpriteData  
	mov     r12,r0        
	mov     r5,r12        
	add     r5,24h        
	ldrb    r4,[r5] 						;checking pose      
	cmp     r4,0h         
	bne     @@MatchPrimary      
	mov     r6,r12        
	ldrh    r1,[r6]       
	ldr     r0,=0FFFBh    
	and     r0,r1         
	mov     r2,0h         
	strh    r0,[r6]						;removes 4h (invisible) flag       
	mov     r0,r12        
	add     r0,22h        
	mov     r3,2h         
	strb    r3,[r0]						;?       
	mov     r1,r12        
	add     r1,27h        
	mov     r0,20h        
	strb    r0,[r1]       
	mov     r0,r12        
	add     r0,28h        
	strb    r2,[r0]       
	add     r1,2h         
	mov     r0,28h        
	strb    r0,[r1]							;all drawing related       
	ldr     r1,=0FFFCh    
	strh    r1,[r6,0Ah]						;top hitbox   
	mov     r0,4h         
	strh    r0,[r6,0Ch]						;bottom hitbox   
	strh    r1,[r6,0Eh] 					;left hitbox  
	strh    r0,[r6,10h]						;right hitbox   
	ldr     r0,=ArachOAM_3					;OAM pointer  
	str     r0,[r6,18h]   
	strb    r2,[r6,1Ch]   
	strh    r4,[r6,16h]   
	mov     r0,r12        
	add     r0,25h        
	strb    r2,[r0]						;cannot hurt samus       
	strb    r3,[r5]						;pose = 2
@@MatchPrimary:
	bl      MatchMainSpriteAI     
	pop     r4-r6         
	pop     r0
	bx		r0           
.pool

BottomSwipeMainAI:
	push    r4-r6,r14                  
	ldr     r2,=SpriteSlot0
	ldr     r0,=CurrSpriteData 
	mov     r12,r0       
	add     r0,23h       
	ldrb    r1,[r0]				      
	lsl     r0,r1,3h     
	sub     r0,r0,r1     
	lsl     r0,r0,3h     
	add     r0,r0,r2						;arachnus primary sprite, slot     
	add     r0,24h       
	ldrb    r0,[r0] 						;arachnus pose     
	cmp     r0,42h						;dying pose       
	bne     @@MakeIntangible     
	mov     r0,0h        
	mov     r1,r12       
	strh    r0,[r1]						;kill sprite      
	b       @@Return    
.pool
@@MakeIntangible:   
	mov     r1,r12       
	add     r1,26h       
	mov     r0,1h        
	strb    r0,[r1]						;makes sprite intangible      
	mov     r6,r12       
	add     r6,24h       
	ldrb    r5,[r6]						;checking pose      
	cmp     r5,0h        
	bne     @@Return     
	mov     r3,r12       
	ldrh    r0,[r3]      
	mov     r1,80h       
	lsl     r1,r1,8h     
	mov     r2,r1        
	mov     r4,0h        
	orr     r2,r0							;turns on 8000h  flag  
	add     r3,32h       
	ldrb    r0,[r3]      
	mov     r1,4h        
	orr     r0,r1        
	strb    r0,[r3]						;turns on 4h flag for collision properites      
	ldr     r0,=0FFFBh   
	and     r2,r0        
	mov     r3,r12       
	strh    r2,[r3]						;removes 4h (invisible) flag      
	mov     r0,r12       
	add     r0,22h       
	mov     r2,2h        
	strb    r2,[r0]						;?      
	mov     r1,r12       
	add     r1,27h       
	mov     r0,20h       
	strb    r0,[r1]      
	mov     r0,r12       
	add     r0,28h       
	strb    r4,[r0]      
	add     r1,2h        
	mov     r0,40h       
	strb    r0,[r1] 						;drawing related     
	ldr     r1,=0FFFCh   
	strh    r1,[r3,0Ah]					;top hitbox  
	mov     r0,4h        
	strh    r0,[r3,0Ch] 					;bottom hitbox 
	strh    r1,[r3,0Eh]					;left hitbox  
	strh    r0,[r3,10h] 					;right hitbox 
	ldr     r0,=ProjectileArachOAM_5					;OAM pointer 
	str     r0,[r3,18h]  
	strb    r4,[r3,1Ch]  
	strh    r5,[r3,16h]  
	mov     r0,r12       
	add     r0,25h						       
	strb    r4,[r0]						;cannot hurt samus      
	strb    r2,[r6] 						;pose = 2
@@Return:
	pop     r4-r6        
	pop     r0
	bx		r0           
.pool

.notice "Arach Shell AI"
.notice tohex(.)
ShellAI: 
	push    r4-r6,r14 
	add		sp,-4h
	ldr     r0,=CurrSpriteData 
	mov     r1,r0        
	add     r1,23h       
	ldrb    r5,[r1] 						;primary sprite ram slot     
	mov     r6,r0        
	add     r6,24h       
	ldrb    r2,[r6]						;checking pose      
	mov     r3,r0        
	cmp     r2,0h 						;if 0, initialize       
	bne     @@PoseCheck     
	ldrh    r1,[r3]      
	ldr     r0,=0FFFBh   
	and     r0,r1        
	mov     r4,0h        
	strh    r0,[r3]						;remove 4h (invisible) flag from status      
	mov     r1,r3        
	add     r1,22h       
	mov     r0,5h        
	strb    r0,[r1]      
	ldr     r1,=SecondarySpriteStats 
	ldrb    r2,[r3,1Dh]  
	lsl     r0,r2,3h     
	add     r0,r0,r2
	lsl		r0,r0,1h
	add		r0,r0,r1
	ldrh    r0,[r0]      
	strh    r0,[r3,14h]					;stores sprite health  
	mov     r1,r3        
	add     r1,27h       
	mov     r0,30h       
	strb    r0,[r1]      
	mov     r0,r3        
	add     r0,28h       
	strb    r4,[r0]      
	add     r1,2h        
	mov     r0,18h       
	strb    r0,[r1]						;all drawing related      
	ldr     r0,=0FF60h   
	strh    r0,[r3,0Ah]					;top hitbox
	mov		r2,0h
	strh    r2,[r3,0Ch] 					;bottom hitbox 
	ldr     r0,=ArachOAM_12 					;OAM pointer
	str     r0,[r3,18h]  
	strb    r4,[r3,1Ch]  
	strh    r2,[r3,16h]  
	sub     r1,4h        
    mov		r0,4h 
	strb    r0,[r1]						;4h (hurt samus) to collsion 
	mov     r0,2h  	
	strb    r0,[r6]						;pose = 2      
	ldrh    r1,[r3]      
	mov     r0,40h       
	and     r0,r1        
	lsl     r0,r0,10h    
	lsr     r0,r0,10h    
	cmp     r0,0h							;checking direction, 40h = right        
	beq     @@FacingLeft     
	ldr     r0,=0FFB0h   
	strh    r0,[r3,0Eh] 					;left hitbox 
	strh    r2,[r3,10h]  					;right hitbox
	b       @@PoseCheck     
.pool
@@FacingLeft:
	strh    r0,[r3,0Eh] 					;left hitbox 
	mov     r0,50h       
	strh    r0,[r3,10h]					;right hitbox
@@PoseCheck:
	ldr     r1,=SpriteSlot0 
	lsl     r2,r5,3h						;getting arachnus slot     
	sub     r0,r2,r5     
	lsl     r0,r0,3h     
	add     r0,r0,r1
	str		r0,[sp]						;saves some space later
	add     r0,24h       
	ldrb    r0,[r0]						;checking arachnus pose					      
	mov     r4,r1        
	cmp     r0,2h							;2 = walking pose     
	bne     @@ArachnusDeadCheck     
	mov     r0,r3        
	add     r0,2Bh       
	ldrb    r1,[r0]						;checking shell was shot     
	mov     r0,7Fh       
	and     r0,r1        
	cmp     r0,0h        
	beq     @@ArachnusDeadCheck     
	ldrh    r1,[r3]      
	mov     r0,40h       
	and     r0,r1        
	cmp     r0,0h							;checking sprite direction, 40h = right          
	beq     @@FacingLeft2     
	ldr     r1,=SamusData 
	ldrh    r0,[r3,4h]						;sprite X   
	ldrh    r1,[r1,12h] 					;Samus X 
	cmp     r0,r1        
	bls     @@ArachnusDeadCheck 						;checking if samus is behind sprite   
	b       @@TurnAround     
.pool
@@FacingLeft2:
	ldr     r1,=SamusData 
	ldrh    r0,[r3,4h]					;sprite X   
	ldrh    r1,[r1,12h]					;Samus X  
	cmp     r0,r1							;checking if samus is behind sprite        
	bcs     @@ArachnusDeadCheck 
@@TurnAround:
	ldr		r1,[sp]
	add     r1,24h       
	mov     r0,7h        
	strb    r0,[r1] 					;arachnus pose = 7, PreIdle 
@@ArachnusDeadCheck:
	ldr		r0,[sp]
	add		r0,24h
	ldrb    r0,[r0] 					;arachnus pose            
	cmp     r0,42h						;checking if arachnus is dead        
	bne     @@CheckDead   
	mov		r0,r3
	add		r0,25h
	mov		r1,0h
	strb	r1,[r0]						;no longer hurts samus	
	b       @@CheckDead   
.pool
@@CheckDead:
	ldr		r0,[sp]
	ldrh	r1,[r0]
	mov		r2,1h
	and		r1,r2						;checking if sprite is alive 
	cmp		r1,0h						;needed if arachnus doesn't drop a pickup
	beq		@@Kill
	ldrb    r0,[r0,1Dh]					;checking if arachnus ID      
	cmp     r0,ArachID					;Arachnus ID, needed if arachnus dropped a pickup      
	beq     @@Return 
@@Kill:
	ldrh    r1,[r3,2h]					;sprite Y position 
	sub		r1,36h
	ldrh    r2,[r3,4h]					;sprite X position    
	sub		r2,1Fh
	mov     r0,20h                                  
	str     r0,[sp]                                 
	mov     r0,0h                                   
	mov     r3,1h
	ldr		r6,=SpriteDead + 1
	bl      WrapperR6
@@Return:
	add		sp,4h
	pop     r4-r6        
	pop     r0
	bx		r0           
.pool