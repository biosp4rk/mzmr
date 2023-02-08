.definelabel Bit16Counter,0x3000002
.definelabel CurrClipdataEffectingAction,0x3000079
.definelabel LockDoors,0x0300007B
.definelabel SpriteData,0x30001AC
;.definelabel CurrSpriteData,0x03000738									
.definelabel SpriteRNG,0x300083C
.definelabel SerrisPhaseCounter,0x300070c
.definelabel SerrisNextPose,0x300070c + 1			;used to tell serris which attack to perform next (only holds the "rising" poses)
.definelabel SerrisAttackDirection,0x300070c + 2	;Side of room for serris to attack from
.definelabel SerrisWaitTimer,0x300070c + 3			;used to tell Serris how long to wait between attacks. Stores to 2Ch of sprite data
.definelabel SerrisBoostTimer,0x300070c + 6
.definelabel SerrisYPosition,0x300070c + 8            ;used for sound AI
.definelabel SerrisYSpawn,0x300070c	+ 0xA
.definelabel SerrisXSpawn,0x300070c + 0x10
.definelabel Bit8Counter,0x3000C77
.definelabel SamusData,0x30013D4
.definelabel SamusEquipment,0x3001530
.definelabel UnlockDoors,0x030054E4

.definelabel PlaySound,0x8002A18
;.definelabel PlaySong,0x80039F4					
.definelabel SpawnNewSecondarySprite,0x800E258
.definelabel SpawnNewPrimarySprite,0x800E31C
.definelabel CheckEndSpriteAnimation,0x800FBC8
.definelabel GetDropType,0x8010EEC
.definelabel DeathRoutine,0x8011084
.definelabel ShakeScreenHori,0x8055378
.definelabel ShakeScreenVert,0x8055344
.definelabel ChangeBlocks,0x8057E7C									
.definelabel SetParticalEffect,0x80540EC
.definelabel EventFunctions,0x80608BC
.definelabel Division,0x808AC34
.definelabel PrimarySpriteStats,0x82B0D68	
.definelabel SecondarySpriteStats,0x82B1BE4
.definelabel CircularMoveTable,0x808C71C 

WrapperR3:
	bx	r3
WrapperR6:
	bx	r6
WrapperR9:
	bx  r9

PhaseShiftAI:
	push    r4-r7,r14
	mov     r6,0h                                  
	ldr     r0,=CurrSpriteData                      
	ldrh    r5,[r0,14h]   				;sprite health                         
	ldr     r2,=PrimarySpriteStats                           
	ldrb    r1,[r0,1Dh] 				;sprite ID                           
	lsl     r0,r1,3h                               
	add     r0,r0,r1                               
	lsl     r0,r0,1h                               
	add     r0,r0,r2                               
	ldrh    r0,[r0] 					;original sprite health from stats                               
	ldr     r4,=SerrisPhaseCounter                         
	ldrb    r1,[r4]                                
	cmp     r1,0h						                                
	beq     @@Phase1Check                               
	cmp     r1,1h						                                
	beq     @@Phase2Check                               
	b       @@ShiftCheck				                              
.pool                             
@@Phase1Check:
	lsl     r0,r0,1h                               
	mov     r1,3h
	ldr		r3,=Division + 1	
	bl		WrapperR3
	cmp     r5,r0						;check if current health above 2/3 original health                                  
	bgt     @@ShiftCheck
	ldr     r7,=Phase2Pal				;palette offset for phase 2                          
	mov     r0,1h                                  
	strb    r0,[r4] 					;stores 1 to phase counter                               
	b       @@SwitchPalette                              
.pool                             
@@Phase2Check:
	mov     r1,3h
	ldr		r3,=Division + 1	
	bl		WrapperR3					                              
	lsl     r0,r0,10h                              
	lsr     r0,r0,10h                              
	cmp     r5,r0 						;check if current health is over 1/3 of original health                                  
	bhi     @@ShiftCheck                               
	ldr     r7,=Phase3Pal				;palette offset for phase 3                           
	mov     r0,2h                                  
	strb    r0,[r4]						;stores 2 to phase counter                                
	mov     r6,1h                                  
@@ShiftCheck:
	cmp     r6,0h						;true if not shifting phases                                 
	beq     @@Return                               
@@SwitchPalette:
	ldr     r1,=40000D4h 				;DMA transfer stuff for palette switch                          
	str     r7,[r1]                                
	ldr     r0,=5000300h                           
	str     r0,[r1,4h]                             
	ldr     r0,=80000020h                          
	str     r0,[r1,8h]                             
	ldr     r0,[r1,8h]                             
@@Return:
	pop     r4-r7                                  
	pop     r0                                     
	bx      r0                                     
.pool  

CheckStartFightAI:
	push    r4,r5,r14                              
	ldr     r0,=SamusData                           
	ldrh    r4,[r0,14h]					;Samus Y                           
	ldrh    r2,[r0,12h] 				;Samus X                           
	ldr     r0,=SerrisYSpawn                          
	ldrh    r3,[r0]                                
	ldr     r0,=SerrisXSpawn                           
	ldrh    r1,[r0]                                
	ldr     r5,=0FFFFFD00h                         
	add     r0,r3,r5                               
	cmp     r4,r0						;Checks if Samus is over Serris Spawn trigger                                 
	ble     @@NullReturn				                               
	add     r5,0C0h                                
	add     r0,r3,r5                               
	cmp     r4,r0     					;Checks if Samus is under Serris spawn trigger                           
	bge     @@NullReturn                               
	ldr     r3,=0FFFFFEC0h                         
	add     r0,r1,r3                               
	cmp     r2,r0						;checks if Samus is left of unused Serris trigger                                  
	ble     @@SpawnCheck                              
	mov     r0,r1                                  
	sub     r0,40h                                 
	cmp     r2,r0						;checks if Samus is right of unused Serris trigger                                   
	bge     @@SpawnCheck                              
	mov     r0,4h						;returns 4, does not start fight                                  
	b       @@Return                               
.pool 
@@SpawnCheck:                             
	ldr     r5,=0FFFFFD40h                         
	add     r0,r1,r5                               
	cmp     r2,r0						;checks if Samus is left of Serris spawn trigger  (narrower?)                                  
	ble     @@Pointless1                               
	ldr     r3,=0FFFFFE40h                         
	add     r0,r1,r3                               
	cmp     r2,r0						;checks if Samus is right of Serris spawn trigger  (narrower?)                                        
	bge     @@Pointless1                              
	mov     r0,3h 						;returns 3, starts fight                                 
	b       @@Return                               
.pool 
@@Pointless1:							;not sure why any further checking is done, as all return values other than 3 do nothing
	ldr     r5,=0FFFFFBC0h                         
	add     r0,r1,r5                               
	cmp     r2,r0  						;checks if Samus is left of unused Serris trigger                                   
	ble     @@Pointless2                               
	ldr     r3,=0FFFFFCC0h                         
	add     r0,r1,r3                               
	cmp     r2,r0						;checks if Samus is right of unused Serris trigger                                     
	bge     @@Pointless2                               
	mov     r0,2h						;returns 2, does not start fight                                  
	b       @@Return                               
.pool  
@@Pointless2:
	ldr     r5,=0FFFFFA40h                         
	add     r0,r1,r5                               
	cmp     r2,r0						;checks if Samus is left of unused Serris trigger                                    
	ble     @@NullReturn                               
	ldr     r3,=0FFFFFB40h                         
	add     r0,r1,r3                               
	cmp     r2,r0  						;checks if Samus is right of unused Serris trigger                                    
	bge     @@NullReturn                              
	mov     r0,1h						;returns 1, does not start fight                                  
	b       @@Return                               
.pool 
@@NullReturn:
	mov     r0,0h 						;returns 0, does not start fight
@@Return:                               
	pop     r4,r5                                  
	pop     r1                                     
	bx      r1  
	
MovementAI:
	push    r4-r7,r14  					;routine seems to deal with the movement of Serris and his parts                            
	mov     r7,r8 		                ;r0,=CurrSpriteData +6h r1,=CurrSpriteData +8h          
	push    r7                          ;r2,=CurrSpriteData +35h r3,=CurrSpriteData +2Fh      
	lsl     r0,r0,10h                              
	lsr     r4,r0,10h                              
	mov     r5,r4                                  
	lsl     r1,r1,10h                              
	lsr     r7,r1,10h                              
	lsl     r2,r2,10h                              
	lsr     r1,r2,10h                              
	lsl     r3,r3,10h                              
	ldr     r0,=CircularMoveTable                         
	lsr     r2,r3,10h                              
	mov     r8,r2                                  
	asr     r3,r3,0Fh                              
	add     r3,r3,r0                               
	mov     r6,0h                                  
	ldsh    r2,[r3,r6]                             
	mov     r12,r0                                 
	cmp     r2,0h                                  
	bge     @@BranchA                              
	neg     r2,r2                                  
	lsl     r1,r1,10h                              
	asr     r0,r1,10h                              
	mul     r0,r2                                  
	mov     r3,r1                                  
	cmp     r0,0h                                  
	bge     @@SkipAdd                              
	add     r0,0FFh                                
@@SkipAdd:
	lsl     r0,r0,8h                               
	ldr     r2,=CurrSpriteData                           
	lsl     r1,r4,10h                              
	asr     r1,r1,10h                              
	asr     r0,r0,10h                              
	sub     r1,r1,r0                               
	b       @@StoreY                              
.pool
@@BranchA:                              
	lsl     r1,r1,10h                              
	asr     r0,r1,10h                              
	mul     r0,r2                                  
	mov     r3,r1                                  
	cmp     r0,0h                                  
	bge     @@SkipAdd2                              
	add     r0,0FFh                                
@@SkipAdd2:
	lsl     r0,r0,8h                               
	ldr     r2,=CurrSpriteData                           
	lsl     r1,r5,10h                              
	asr     r1,r1,10h                              
	asr     r0,r0,10h                              
	add     r1,r1,r0                               
@@StoreY:
	strh    r1,[r2,2h]				;sprite Y                             
	mov     r1,r8                                  
	lsl     r0,r1,10h                              
	asr     r0,r0,0Fh                              
	add     r0,80h                                 
	add     r0,r12                                 
	mov     r4,0h                                  
	ldsh    r1,[r0,r4]                             
	cmp     r1,0h                                  
	bge     @@BranchB                               
	neg     r1,r1                                  
	asr     r0,r3,10h                              
	mul     r0,r1                                  
	cmp     r0,0h                                  
	bge     @@SkipAddition                              
	add     r0,0FFh 
@@SkipAddition:                                
	lsl     r1,r0,8h                               
	lsl     r0,r7,10h                              
	asr     r0,r0,10h                              
	asr     r1,r1,10h                              
	sub     r0,r0,r1                               
	b       StoreX                              
.pool 
@@BranchB:                            
	asr     r0,r3,10h                              
	mul     r0,r1                                  
	cmp     r0,0h                                  
	bge     @@SkipAddition2                               
	add     r0,0FFh
@@SkipAddition2:                                
	lsl     r1,r0,8h                               
	lsl     r0,r7,10h                              
	asr     r0,r0,10h                              
	asr     r1,r1,10h                              
	add     r0,r0,r1                               
StoreX:
	strh    r0,[r2,4h]					;sprite X                             
	pop     r3                                     
	mov     r8,r3                                  
	pop     r4-r7                                 
	pop     r0                                     
	bx      r0 

PreMoveAI:   
	push    r14                                    
	ldr     r1,=CurrSpriteData                           
	mov     r0,r1                                  
	add     r0,35h 						;CurrSpriteData + 35h
	ldrb    r0,[r0]                                
	mov     r2,1h                                  
	mov     r12,r1                                 
	cmp     r0,3h                                  
	beq     @@FlagChecks             
	mov     r2,4h                                  
	cmp     r0,2h                                  
	bne     @@FlagChecks             
	mov     r2,2h                                  
@@FlagChecks:
	mov     r0,r12                                 
	ldrh    r1,[r0]						;sprite status                 
	mov     r0,80h                                 
	lsl     r0,r0,3h                               
	and     r0,r1						;checking for 400h flag, true if upside down           
	cmp     r0,0h                                  
	beq     @@BranchC                       
	mov     r0,80h                                 
	lsl     r0,r0,2h                               
	and     r0,r1 						;checking for 200h flag, true if going right   
	cmp     r0,0h                                  
	bne     @@BranchD                       
	mov     r1,r12                                 
	add     r1,2Fh 						;CurrSpriteData + 2Fh                      
	ldrb    r0,[r1]                                
	sub     r0,r0,r2                               
	strb    r0,[r1]                                
	sub     r1,5h                                  
	ldrb    r0,[r1]						;CurrSpriteData + 2Bh                       
	sub     r0,r0,r2                               
	b       @@BranchE                      
.pool                         
@@BranchC:
	mov     r0,80h                                 
	lsl     r0,r0,2h					;checking for 200h flag                               
	and     r0,r1                                  
	cmp     r0,0h                                  
	beq     @@BranchD                       
	mov     r1,r12                                 
	add     r1,2Fh						;CurrSpriteData + 2Fh                                
	ldrb    r0,[r1]                                
	sub     r0,r0,r2                               
	strb    r0,[r1]                                
	sub     r1,5h                                  
	ldrb    r0,[r1]						;CurrSpriteData + 2Bh                                 
	sub     r0,r0,r2                               
	b       @@BranchE                       
@@BranchD:
	mov     r1,r12                                 
	add     r1,2Fh						;CurrSpriteData + 2Fh                                
	ldrb    r0,[r1]                                
	add     r0,r2,r0                               
	strb    r0,[r1]                                
	sub     r1,5h                                  
	ldrb    r0,[r1]						;CurrSpriteData + 2Bh                                  
	add     r0,r2,r0 
@@BranchE:                  
	strb    r0,[r1]                                
	mov     r1,r12                                 
	mov     r2,6h                                  
	ldsh    r0,[r1,r2]					;CurrSpriteData +6h Argument for MovementAI
	mov     r3,8h                  	                
	ldsh    r1,[r1,r3]					;CurrSpriteData +8h Argument for MovementAI                           
	mov     r2,r12                                 
	add     r2,35h                                 
	ldrb    r3,[r2]						;CurrSpriteData + 35h Argument for MovementAI                              
	lsl     r2,r3,1h                               
	add     r2,r2,r3                               
	lsl     r2,r2,16h                              
	asr     r2,r2,10h                              
	mov     r3,r12                                 
	add     r3,2Fh                                 
	ldrb    r3,[r3] 					;CurrSpriteData + 2Fh Argument for MovementAI                                  
	bl      MovementAI                             
	pop     r0                                     
	bx      r0

LeftRightCheckAI:
	push    r4,r5,r14                              
	lsl     r0,r0,10h                              
	lsr     r5,r0,10h                              
	lsl     r1,r1,10h                              
	lsr     r4,r1,10h                              
	lsl     r2,r2,10h                              
	lsr     r2,r2,10h                              
	ldr     r3,=CurrSpriteData                          
	ldrh    r1,[r3]						;sprite status                                
	mov     r0,80h                                 
	lsl     r0,r0,2h                               
	and     r0,r1                                  
	cmp     r0,0h						;checking for 200h flag, true if going right                                 
	beq     @@NotSet                              
	lsl     r0,r2,1h                               
	add     r0,r0,r2                               
	lsl     r0,r0,6h                               
	add     r0,r4,r0                               
	strh    r0,[r3,8h]                             
	mov     r1,r3                                  
	add     r1,2Fh                                 
	mov     r0,80h                                 
	strb    r0,[r1]                                
	b       @@Return                              
.pool                             
@@NotSet:
	lsl     r0,r2,1h                               
	add     r0,r0,r2                               
	lsl     r0,r0,6h                               
	sub     r0,r4,r0                               
	mov     r1,0h                                  
	strh    r0,[r3,8h] 		                          
	mov     r0,r3                                  
	add     r0,2Fh                                 
	strb    r1,[r0]                                
@@Return:
	strh    r5,[r3,6h]                             
	mov     r0,r3                                  
	add     r0,35h                                 
	strb    r2,[r0]                                
	pop     r4,r5                                  
	pop     r0                                     
	bx      r0   

UpDownCheckAI:
	push    r4,r5,r14                              
	lsl     r0,r0,10h                              
	lsr     r4,r0,10h                              
	lsl     r1,r1,10h                              
	lsr     r5,r1,10h                              
	lsl     r2,r2,10h                              
	lsr     r2,r2,10h                              
	ldr     r3,=CurrSpriteData                           
	ldrh    r1,[r3]					;sprite status                                
	mov     r0,80h                                 
	lsl     r0,r0,3h                               
	and     r0,r1                                  
	mov     r1,r3					;checks for 400h flag, true if serris is upside down                                 
	cmp     r0,0h                                  
	beq     @@NotSet                              
	add     r3,2Fh                                 
	mov     r0,0C0h                                
	strb    r0,[r3]                                
	lsl     r0,r2,1h                               
	add     r0,r0,r2                               
	lsl     r0,r0,6h                               
	add     r0,r4,r0                               
	b       @@Store                               
.pool                             
@@NotSet:
	mov     r3,r1                                  
	add     r3,2Fh                                 
	mov     r0,40h                                 
	strb    r0,[r3]                                
	lsl     r0,r2,1h                               
	add     r0,r0,r2                               
	lsl     r0,r0,6h                               
	sub     r0,r4,r0 
@@Store:                              
	strh    r0,[r1,6h]                             
	strh    r5,[r1,8h]                             
	mov     r0,r1                                  
	add     r0,35h                                 
	strb    r2,[r0]                                
	pop     r4,r5                                  
	pop     r0                                     
	bx      r0 

OAMSwitchAI:		
	push    r14                                    
	ldr     r2,=CurrSpriteData                          
	mov     r0,r2                                  
	add     r0,32h					;collision properites                                  
	ldrb    r1,[r0]                                
	mov     r0,80h                                 
	and     r0,r1                                  
	cmp     r0,0h						;checking for 80h flag                                  
	beq     @@NotSet                               
	ldrb    r0,[r2,1Eh]				;Sprite room slot?                            
	cmp     r0,0h 					                                 
	bne     @@ResetAnimations                              
	ldrh    r1,[r2]					;sprite status                                
	mov     r0,40h					;checking flag 40h, X flip                                 
	and     r0,r1                                  
	cmp     r0,0h                                  
	beq     @@NotFlipped                               
	ldr     r0,=OAM_44				;OAM Pointer                          
	b       @@StoreOAM                               
.pool                              
@@NotFlipped:
	ldr     r0,=OAM_10 				;OAM Pointer                          
	b       @@StoreOAM                               
.pool                              
@@NotSet:
	ldr     r0,=SerrisBoostTimer                           
	ldrh    r0,[r0]                                
	cmp     r0,0h                                  
	beq     @@Branch                               
	ldrh    r1,[r2]                                
	mov     r0,40h                                 
	and     r0,r1                                  
	cmp     r0,0h                                  
	beq     @@NotFlipped2                               
	ldr     r0,=OAM_6				;OAM pointer                          
	b       @@StoreOAM                               
.pool 
@@NotFlipped2:
	ldr     r0,=OAM_5				;OAM pointer                           
	b       @@StoreOAM                               
.pool                             
@@Branch:
	ldrh    r1,[r2]				;sprite status                                
	mov     r0,40h 				;checking for 40h, X flip                                 
	and     r0,r1                                  
	cmp     r0,0h                                  
	beq     @@Pointer                               
	ldr     r0,=OAM_4                          
	b       @@StoreOAM                               
.pool
@@Pointer:                           
	ldr     r0,=OAM_3                           
@@StoreOAM:
	str     r0,[r2,18h] 			;sprite OAM pointer                           
@@ResetAnimations:
	mov     r0,0h                                  
	strb    r0,[r2,1Ch]                            
	strh    r0,[r2,16h]                            
	pop     r0                                     
	bx      r0                                     
.pool


SpawnAI:   
	push    r4-r7,r14
	mov		r7,r9
	push	r7	
	mov     r7,r8                       
	push    r7
	add     sp,-0Ch
	mov		r0,3h
	bl		SetnCheckEvent
	cmp     r0,0h                       
	beq     @@Continue                    
	ldr     r1,=CurrSpriteData          
	mov     r0,0h                       
	strh    r0,[r1]					;kills sprite                     
	b       @Return1                    
.pool
@@Continue:
	ldr		r1,=LockDoors
	mov		r0,1h
	strb	r0,[r1]					;locks doors
	ldr     r5,=CurrSpriteData          
	ldrh    r0,[r5,2h]				;Sprite Y                  
	add     r0,40h					;adds 1 block                      
	strh    r0,[r5,2h]		                  
	ldr     r1,=SerrisYSpawn                
	strh    r0,[r1]					;sprite Y to serris Y spawn                     
	ldr     r1,=SerrisXSpawn               
	ldrh    r0,[r5,4h] 				;Sprite X                 
	strh    r0,[r1]					;sprite X to serris X spawn                     
	ldrh    r1,[r5]					;status                     
	ldr     r2,=880Ch                   
	mov     r0,r2                       
	mov     r3,0h                       
	orr     r0,r1                       
	strh    r0,[r5]					;turing 880Ch flags on in Status                     
	mov     r0,r5                       
	add     r0,2Ah                      
	strb    r3,[r0]					;0                     
	mov     r0,80h                      
	lsl     r0,r0,1h					;100h                    
	strh    r0,[r5,12h]                 
	ldr     r2,=PrimarySpriteStats                
	ldrb    r1,[r5,1Dh]				;sprite ID                 
	lsl     r0,r1,3h                    
	add     r0,r0,r1                    
	lsl     r0,r0,1h                    
	add     r0,r0,r2                    
	ldrh    r0,[r0]                     
	strh    r0,[r5,14h]				;sprite health                 
	mov     r0,r5                       
	add     r0,25h                      
	strb    r3,[r0]					;0                     
	mov     r1,r5                       
	add     r1,27h                      
	mov     r0,10h                      
	strb    r0,[r1]                     
	mov     r0,r5                       
	add     r0,28h                      
	mov     r1,20h                      
	strb    r1,[r0]                     
	add     r0,1h                       
	strb    r1,[r0]                     
	ldr     r1,=0FFD8h                  
	strh    r1,[r5,0Ah] 				;top sprite boundary                 
	mov     r0,28h                      
	strh    r0,[r5,0Ch]				;bottom sprite boundary                 
	strh    r1,[r5,0Eh] 				;left sprite boundary                
	strh    r0,[r5,10h]   			;right sprite boundary              
	mov     r1,r5                       
	add     r1,24h					                      
	mov     r0,55h                      
	strb    r0,[r1]					;sprite pose = 55                     
	ldr     r0,=OAM_3				;OAM Pointer                
	str     r0,[r5,18h]                 
	strb    r3,[r5,1Ch]                 
	strh    r7,[r5,16h]                                    
	ldr     r0,=SerrisPhaseCounter                
	str     r3,[r0]      
	strh	r3,[r0,6h]
	ldrb    r0,[r5,1Fh]				;spriteset GFX slot                 
	mov     r8,r0 
	mov     r0,r5                       
	add     r0,2Dh                      
	strb    r3,[r0]	                    
	sub     r0,0Ah                      
	ldrb    r6,[r0]					;primary sprite RAM slot                     
	ldrh    r4,[r5,2h]				;Sprite Y                  
	ldrh    r5,[r5,4h] 				;sprite X                 
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]    
Segment1:	
	mov     r0,SegmentID 					;5B = serris segment                     
	mov     r1,0h                       
	mov     r2,r8
	ldr		r3,=SpawnNewSecondarySprite + 1
	mov		r9,r3
	mov     r3,r6                       
	bl      WrapperR9                  
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment2:	
	mov     r0,SegmentID                      
	mov     r1,1h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                     
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment3:	
	mov     r0,SegmentID                      
	mov     r1,2h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                     
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h] 
Segment4:	
	mov     r0,SegmentID                      
	mov     r1,3h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                    
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment5:	
	mov     r0,SegmentID                      
	mov     r1,4h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                    
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment6:	
	mov     r0,SegmentID                      
	mov     r1,5h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                     
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment7:	
	mov     r0,SegmentID                      
	mov     r1,6h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                     
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment8:	
	mov     r0,SegmentID                      
	mov     r1,7h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                     
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h]
Segment9:	
	mov     r0,SegmentID                      
	mov     r1,8h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                    
	str     r4,[sp]                     
	str     r5,[sp,4h]                  
	str     r7,[sp,8h] 
Segment10:	
	mov     r0,SegmentID                      
	mov     r1,9h                       
	mov     r2,r8                       
	mov     r3,r6                       
	bl      WrapperR9                   
@Return1:
	add     sp,0Ch                      
	pop     r3                          
	mov     r8,r3
	pop		r3
	mov		r9,r3
	pop     r4-r7                       
	pop     r0                          
	bx      r0                          
.pool

SpawnBlockAI: 
	push    r4-r7,r14
	mov		r7,r9
	push	r7
	mov     r7,r8                     
	push    r7                        
	add     sp,-0Ch
	ldr		r0,=SpawnNewSecondarySprite + 1
	mov		r9,r0
	ldr     r0,=SerrisYSpawn          
	ldr     r1,=0FFFFFD60h            
	mov     r4,r1                     
	ldrh    r0,[r0]                   
	add     r4,r4,r0                  
	lsl     r4,r4,10h                 
	lsr     r4,r4,10h                 
	ldr     r0,=SerrisXSpawn          
	ldrh    r6,[r0]                   
	ldr     r5,=CurrSpriteData          
	ldrb    r2,[r5,1Fh]				;spriteset GFX slot               
	mov     r7,r5                     
	add     r7,23h                    
	ldrb    r3,[r7]					;Primary sprite RAM slot                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFEC0h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,0h                     
	mov     r8,r0                     
	str     r0,[sp,8h]               ;77 = Serris blocks
SerrisBlock1:
	mov     r0,BlockID 						                   
	mov     r1,0h                     
	bl      WrapperR9                   
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFE80h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock2:	
	mov     r0,BlockID                    
	mov     r1,1h                     
	bl      WrapperR9                 
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFE40h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock3:
	mov     r0,BlockID                    
	mov     r1,0h                     
	bl      WrapperR9                    
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFD40h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock4:	
	mov     r0,BlockID                    
	mov     r1,1h                     
	bl      WrapperR9                    
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFD00h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock5:	
	mov     r0,BlockID                    
	mov     r1,0h                     
	bl      WrapperR9                    
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFCC0h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock6:	
	mov     r0,BlockID                    
	mov     r1,1h                     
	bl      WrapperR9                    
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFBC0h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock7:	
	mov     r0,BlockID                    
	mov     r1,0h                     
	bl      WrapperR9                    
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFB80h            
	add     r0,r6,r1                  
	str     r0,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock8:	
	mov     r0,BlockID                    
	mov     r1,1h                     
	bl      WrapperR9                   
	ldrb    r2,[r5,1Fh]               
	ldrb    r3,[r7]                   
	str     r4,[sp]                   
	ldr     r1,=0FFFFFB40h            
	add     r6,r6,r1                  
	str     r6,[sp,4h]                
	mov     r0,r8                     
	str     r0,[sp,8h]
SerrisBlock9:	
	mov     r0,BlockID                    
	mov     r1,0h                     
	bl      WrapperR9                    
	add     r5,24h                    
	mov     r0,56h                    
	strb    r0,[r5]                   
	add     sp,0Ch                    
	pop     r3                        
	mov     r8,r3
	pop		r3
	mov		r9,r3
	pop     r4-r7                     
	pop     r0                        
	bx      r0                        
.pool

PreCheckStartFightAI:    
	push    r14                                     
	bl      CheckStartFightAI
	lsl     r0,r0,18h                               
	lsr     r0,r0,18h                               
	cmp     r0,3h							;3 = start fight
	bne     @@Return                                
	ldr     r0,=CurrSpriteData                            
	add     r0,24h                                  
	mov     r1,1h                                   
	strb    r1,[r0]							;pose = 1                                 
	mov     r0,3Ch                                  
	mov     r1,81h
	ldr		r3,=ShakeScreenHori + 1
	bl      WrapperR3                               
	mov     r0,3Ch                                  
	mov     r1,81h
	ldr		r3,=ShakeScreenVert + 1
	bl      WrapperR3                                
	mov     r0,0C4h                                 						;288h                                
	ldr		r3,=PlaySound + 1
	bl      WrapperR3                              
@@Return:
	pop     r0                                      
	bx      r0  
.pool

SetPose53AI: 
	push    r14                                     
	ldr     r0,=CurrSpriteData                            
	add     r0,24h                                  
	mov     r1,53h 							;pose = 53h                                 
	strb    r1,[r0]                                 
	bl      OAMSwitchAI                             
	pop     r0                                      
	bx      r0                                      
.pool

SetPose54AI:
	push    r14                                     
	bl      SideRiseB4Arc                                
	ldr     r0,=CurrSpriteData                      
	mov     r1,r0                                   
	add     r1,24h                                  
	ldrb    r0,[r1]                                 
	cmp     r0,3Eh 							;check if pose = 3Eh                                 
	bne     @@Return                                
	mov     r0,54h                                  
	strb    r0,[r1]							;pose = 54h    
@@Return:
	pop     r0                                      
	bx      r0                                      
.pool 

SetPose51AI:
	push    r14                                     
	bl      RisingAI                                
	ldr     r0,=CurrSpriteData                      
	mov     r1,r0                                   
	add     r1,24h                                  
	ldrb    r0,[r1]                                 
	cmp     r0,16h						;check if pose = 16h                                  
	bne     @@Return                                
	mov     r0,51h 						;pose = 51h                                 
	strb    r0,[r1]                                 
@@Return:
	pop     r0                                      
	bx      r0                                      
.pool

CheckSerrisEmergeAI:			
	push    r14 						;checks to start song and for serris to rise                                    
	ldr     r2,=CurrSpriteData                      
	ldrh    r1,[r2]						;sprite status                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	mov     r3,r2                                   
	cmp     r0,0h						;checks for 40h flag, X flip                                   
	beq     @@NotFlipped                                
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,40h                                  
	b       @@Store                                
.pool
@@NotFlipped:
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
@@Store:
	strb    r0,[r1]					;CurrSpriteData + 2Bh                                 
	ldrh    r1,[r3,2h]				;sprite Y                              
	ldr     r0,=77Fh                                
	cmp     r1,r0                                   
	bls     @@ChangeY                                
	ldrh    r1,[r3] 				;sprite status                                 
	ldr     r0,=7FFBh			                               
	and     r0,r1                                   
	strh    r0,[r3]					;gets rid of 8004h flags                                 
	mov     r2,r3                                   
	add     r2,32h                                  
	ldrb    r0,[r2]					;sprite collision properties                                 
	mov     r1,40h                                  
	orr     r1,r0                                   
	strb    r1,[r2]                                 
	sub     r2,0Dh    				;USED TO BE SUB F                              
	mov     r0,4h					;used to be 18h                                  
	strb    r0,[r2]					;4 to CurrSpriteData + 25h                                 
	mov     r0,80h                                  
	and     r1,r0                                   
	cmp     r1,0h                                   
	bne     @@SetPose2                                
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,52h                                  
	strb    r0,[r1] 				;pose = 52 
.notice "Serris Song---------"
.notice tohex(.)	
	mov     r0,3Ch					;Serris/Yakuzza song ID                                  
	mov     r1,0h
	ldr		r3,=PlaySong + 1
	bl      WrapperR3                               
	b       @@Return                                
.pool
@@SetPose2:                               
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,2h                                   
	strb    r0,[r1]					;pose = 2                                 
	b       @@Return 
@@ChangeY:
	mov     r0,r1                                   
	add     r0,10h                                  
	strh    r0,[r3,2h]
@@Return:                              
	pop     r0                                      
	bx      r0

FirstDeathPose:	  
	ldr     r3,=CurrSpriteData 		;pose 47h first pose for death animation                          
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,48h                                  
	strb    r0,[r1]					;pose = 48h                                 
	ldrh    r2,[r3] 				;sprite status                                
	mov     r1,80h                                  
	lsl     r1,r1,8h                                
	mov     r0,r1                                   
	mov     r1,0h                                   
	orr     r0,r2                                   
	strh    r0,[r3]                                 
	mov     r0,r3                                   
	add     r0,25h                                  
	strb    r1,[r0]					;0                                 
	add     r0,7h                                   
	strb    r1,[r0]                                 
	mov     r2,r3                                   
	add     r2,2Eh                                  
	mov     r0,0B4h					                                
	strb    r0,[r2] 
	sub		r2,3h
	strb	r0,[r2]					;makes sprite flash white?
	mov     r0,r3	
	add     r0,2Fh                                  
	strb    r1,[r0]					;0                                 
	bx      r14                                     
.pool

DyingAI:    
	push    r14 					;run during death animation                        
	ldr     r2,=CurrSpriteData               
	mov     r1,r2                      
	add     r1,2Fh                     
	ldrb    r0,[r1]                    
	cmp     r0,0FEh                    
	bhi     @@SkipAgain                   
	add     r0,1h                      
	strb    r0,[r1]						;timer?                    
@@SkipAgain:
	mov     r3,r2                      
	add     r3,2Ah                     
	ldrb    r0,[r1]                    
	lsr     r0,r0,2h                   
	ldrb    r1,[r3]                    
	add     r0,r0,r1                   
	strb    r0,[r3]                    
	mov     r1,r2                      
	add     r1,2Eh                     
	ldrb    r0,[r1]                    
	sub     r0,1h                      
	strb    r0,[r1]
	cmp		r0,0A0h
	beq		@@Screech
	cmp		r0,89h
	beq		@@Screech
	cmp		r0,5Ah
	bne		@@Next
	mov		r0,0B0h
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
	b		@@Next
@@Screech:
	mov		r0,0ADh
	ldr		r3,=PlaySound + 1
	bl		WrapperR3
@@Next:
	lsl     r0,r0,18h                  
	cmp     r0,0h                      
	bne     @@Return                   
	sub     r1,0Ah                     
	mov     r0,49h                     
	strb    r0,[r1]
@@Return:                    
	pop     r0                         
	bx      r0                         
.pool

FinalDeathPose:
	ldr     r3,=CurrSpriteData  		;last pose in death animation   
	mov     r1,r3                  
	add     r1,24h                 
	mov     r0,4Ah                 
	strb    r0,[r1]						;pose = 4Ah                
	ldrh    r1,[r3]                
	mov     r2,80h                 
	lsl     r2,r2,8h               
	mov     r0,r2                  
	mov     r2,0h                  
	orr     r0,r1                  
	mov     r1,20h                 
	orr     r0,r1                  
	strh    r0,[r3]                
	mov     r0,r3                  
	add     r0,25h                 
	strb    r2,[r0]                
	mov     r0,1h                  
	strh    r0,[r3,14h]            
	mov     r0,r3                  
	add     r0,2Bh						;stun/flash timer                 
	strb    r2,[r0]                
	sub     r0,0Bh 						;USED TO BE SUB C                
	strb    r2,[r0]                
	mov     r0,2Ch                 
	strh    r0,[r3,6h]             
	bx		r14
.pool

DistortionAI:
	push    r4-r6,r14  					;ran when Serris head begins to get distorted and explodes upon death
	add		sp,-4h
	ldr		r6,=SetParticalEffect + 1
	ldr     r3,=CurrSpriteData                      
	mov     r1,r3                                   
	add     r1,2Ah                                 
	mov     r0,r3                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	lsr     r0,r0,2h                                
	ldrb    r2,[r1]                                 
	add     r0,r0,r2                                
	strb    r0,[r1]                                                         
	ldr     r1,=MosaicTable                           
	ldrh    r0,[r3,6h]                              
	lsl     r0,r0,1h                                
	add     r0,r0,r1                                
	ldrh    r0,[r0]                                                                
	ldrh    r0,[r3,6h]                              
	sub     r0,1h                                   
	strh    r0,[r3,6h]                              
	ldrh    r5,[r3,2h]			;sprite Y                              
	ldrh    r4,[r3,4h]			;Sprite X                              
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
	.word @@ChangeID,@@Return,@@Return,@@Return
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
	add     r0,0Ch                                  
	mov     r1,r4                                   
	add     r1,14h                                  
	mov     r2,22h					;r2,=explosion effect                                  
	bl      WrapperR6                              
	mov     r0,r5                                   
	add     r0,20h                                  
	mov     r1,r4                                   
	sub     r1,10h                                  
	b       @@SecondEffect                                
@@Effect2:
	mov     r0,r5                                   
	sub     r0,20h                                  
	mov     r1,r4                                   
	add     r1,1Ch                                  
	mov     r2,21h                                  
	bl      WrapperR6                                 
	mov     r0,r5                                   
	add     r0,40h                                  
	b       @@PreSecondEffect 
@@Effect3:                              
	mov     r0,r5                                   
	sub     r0,20h                                  
	sub     r4,10h                                  
	mov     r1,r4                                   
	mov     r2,21h                                  
	bl      WrapperR6                                  
	mov     r0,r5                                   
	add     r0,40h                                  
	mov     r1,r4                                   
	b       @@SecondEffect 
@@Effect4:                              
	mov     r0,r5                                   
	sub     r0,0Ch                                  
	mov     r1,r4                                   
	add     r1,14h                                  
	mov     r2,22h                                  
	bl      WrapperR6                                  
	mov     r0,r5                                   
	add     r0,20h                                  
@@PreSecondEffect:
	mov     r1,r4                                   
	add     r1,20h                                  
@@SecondEffect:
	mov     r2,31h                                  
	bl      WrapperR6                                  
	b       @@Return                               
@@ChangeID:
	ldr     r1,=CurrSpriteData
	mov		r0,29h
	str		r0,[sp]
	mov		r0,0h
	mov		r3,1h
	ldrh	r2,[r1,4h]
	ldrh	r1,[r1,2h]
	ldr		r6,=DeathRoutine + 1		
	bl		WrapperR6   	
	ldr		r1,=UnlockDoors
	mov		r0,1h
	strb	r0,[r1]				;opens doors
	bl 		SetnCheckEvent
	mov		r0,0Bh				;boss killed song
	mov		r1,0h
	ldr		r3,=PlaySong + 1
	;bl		WrapperR3  
	nop
	nop
	ldr		r0,=SerrisPhaseCounter
	mov		r1,0
	str		r1,[r0]
	strh	r1,[r0,4h]	;reset boss ram
@@Return:
	add		sp,4h
	pop     r4-r6                                   
	pop     r0                                      
	bx      r0 
.pool 


	
SegmentSpawnAI:                                 
	push    r4,r14                                  
	ldr     r3,=CurrSpriteData                      
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,8h                                
	mov     r0,r2                                   
	mov     r2,0h                                   
	mov     r4,0h                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	mov     r0,r3                                   
	add     r0,25h                                  
	strb    r2,[r0]                                 
	strb    r2,[r3,1Ch]				;reset animations                             
	strh    r4,[r3,16h]                             
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,55h					;pose = 55h                                  
	strb    r0,[r1]                                 
	ldr     r2,=SecondarySpriteStats                            
	ldrb    r1,[r3,1Dh]				;sprite ID                             
	lsl     r0,r1,3h                                
	add     r0,r0,r1
	lsl		r0,r0,1h
	add		r0,r0,r2
	ldrh    r0,[r0] 
	mov		r2,0h
	strh    r0,[r3,14h]				;sprite health                             
	mov     r0,r3                                   
	add     r0,2Ah                                  
	strb    r2,[r0]                                 
	mov     r0,80h                                  
	lsl     r0,r0,1h                                
	strh    r0,[r3,12h]                             
	ldrb    r0,[r3,1Eh]				;sprite room slot                             
	add     r0,1h                                   
	lsl     r1,r0,2h                                
	add     r1,r1,r0                                
	mov     r0,r3                                   
	add     r0,2Ch                                 
	strb    r1,[r0]                                 
	ldrb    r0,[r3,1Eh] 				;sprite room slot                            
	mov     r2,r3                                   
	cmp     r0,9h                                   
	bls     @@JumpGet                                
	b       @@Store 
@@JumpGet:                               
	lsl     r0,r0,2h                                
	ldr     r1,=@@JumpTable                           
	add     r0,r0,r1                                
	ldr     r0,[r0]                                 
	mov     r15,r0                                  
.pool

@@JumpTable: 
	.word @@FirstPiece,@@OtherPieces,@@OtherPieces,@@OtherPieces
	.word @@OtherPieces,@@OtherPieces,@@OtherPieces,@@PieceEight 
	.word @@PieceNine,@@LastPiece                            
@@FirstPiece:
	ldrh    r1,[r2]                                 
	mov     r0,28h                                  
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r1,r2                                   
	add     r1,27h                                  
	mov     r0,10h                                  
	strb    r0,[r1]                                 
	add     r1,1h                                   
	mov     r0,20h                                  
	strb    r0,[r1]                                 
	add     r1,1h                                   
	strb    r0,[r1]                                 
	ldr     r1,=0FFE0h                              
	strh    r1,[r2,0Ah]						;top boundary                             
	strh    r0,[r2,0Ch]						;bottom boundary                             
	strh    r1,[r2,0Eh]						;left boundary                             
	strh    r0,[r2,10h]                   	;right boundary         
	ldr     r0,=OAM_10					;OAM pointer                            
	str     r0,[r2,18h]                             
	b       @@Return                                
.pool
@@OtherPieces:                               
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r2                                   
	add     r0,27h                                  
	mov     r1,10h                                  
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	ldr     r1,=0FFE0h                              
	strh    r1,[r2,0Ah]					;top boundary                             
	mov     r0,20h                                  
	strh    r0,[r2,0Ch]					;bottom boundary                             
	strh    r1,[r2,0Eh] 				;left                             
	strh    r0,[r2,10h]					;right                             
	ldr     r0,=OAM_18 				;OAM pointer                           
	str     r0,[r2,18h]                             
	b       @@Return                                
.pool  
@@PieceEight:                           
	mov     r1,r2                                   
	add     r1,2Ch                                 
	mov     r0,28h                                  
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r2                                   
	add     r0,27h                                  
	mov     r1,10h                                  
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	ldr     r1,=0FFE0h				                              
	strh    r1,[r2,0Ah]  					;top boundary                           
	mov     r0,20h                                  
	strh    r0,[r2,0Ch]						;bottom                             
	strh    r1,[r2,0Eh]						;left                             
	strh    r0,[r2,10h] 					;right                            
	ldr     r0,=OAM_29					;OAM pointer                            
	str     r0,[r2,18h]                             
	b       @@Return                                
.pool
@@PieceNine:                               
	mov     r1,r2                                   
	add     r1,2Ch                                  
	mov     r0,2Bh                                  
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r2                                   
	add     r0,27h                                  
	mov     r1,8h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	ldr     r1,=0FFE8h                              
	strh    r1,[r2,0Ah]						;top boundary                             
	mov     r0,18h                                  
	strh    r0,[r2,0Ch]						;bottom                             
	strh    r1,[r2,0Eh]						;left                             
	strh    r0,[r2,10h] 					;right                            
	ldr     r0,=OAM_32					;OAM pointer                            
	str     r0,[r2,18h]                             
	b       @@Return                                
.pool
@@LastPiece:                              
	mov     r1,r2                                   
	add     r1,2Ch                                  
	mov     r0,2Eh                                  
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r2                                   
	add     r0,27h                                  
	mov     r1,10h                                  
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	ldr     r1,=0FFF4h                              
	strh    r1,[r2,0Ah]					;top boundary                             
	mov     r0,0Ch               		 ;bottom                 
	strh    r0,[r2,0Ch]           		;left                  
	strh    r1,[r2,0Eh]           		;right                  
	strh    r0,[r2,10h]                             
	ldr     r0,=OAM_35 				;OAM pointer                         
	str     r0,[r2,18h]            	                 
	b       @@Return                                
.pool
@@Store:                             
	strh    r4,[r3]						;kills sprite
@@Return:                                 
	pop     r4                                      
	pop     r0                                      
	bx      r0                                      

SetPose1:
	push    r14         
	ldr     r2,=SpriteData
	ldr     r3,=CurrSpriteData
	mov     r0,r3       
	add     r0,23h      
	ldrb    r1,[r0]						;primary sprite RAM slot     
	lsl     r0,r1,3h    
	sub     r0,r0,r1    
	lsl     r0,r0,3h    
	add     r0,r0,r2    
	add     r0,24h      
	ldrb    r1,[r0]						;checks if pose is 1     
	cmp     r1,1h       
	bne     @@Return    
	mov     r0,r3       
	add     r0,24h      
	strb    r1,[r0]						;pose = 1     
@@Return:
	pop     r0          
	bx      r0          
.pool

DecreaseTimerAI:	
	push    r14               
	ldr     r1,=CurrSpriteData
	mov     r2,r1             
	add     r2,2Ch          
	ldrb    r0,[r2]           
	sub     r0,1h             
	strb    r0,[r2]			;timer?           
	lsl     r0,r0,18h         
	cmp     r0,0h             
	bne     @@Return          
	add     r1,24h            
	mov     r0,53h 			;pose = 53h           
	strb    r0,[r1]           
	bl      OAMSwitchAI       
@@Return:
	pop     r0                                      
	bx      r0                                      
.pool

OscillateAI:
	push    r4-r6,r14   				;pose 38. Ran when going in between platforms                             
	mov     r6,0C8h                                 
	lsl     r6,r6,2h                                
	ldr     r2,=CurrSpriteData                      
	ldrh    r4,[r2,2h]					;sprite Y                          
	ldrh    r5,[r2,4h]    				;sprite X                          
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,0h                                   
	bne     @@BranchA                                
	cmp     r4,r6                                   
	bhi     @@Store                                
	b       @@PreMoveAI                               
@@Store:
	mov     r0,1h                                   
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	ldr     r0,=0FBFFh                              
	and     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                        
@@BranchA:
	ldr     r2,=CurrSpriteData                      
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,1h                                   
	bne     @@BranchB                               
	cmp     r4,r6                                   
	bcs     @@PreMoveAI                                
	mov     r0,2h                                   
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	mov     r3,80h                                  
	lsl     r3,r3,3h                                
	mov     r0,r3                                   
	orr     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                        
@@BranchB:
	ldr     r2,=CurrSpriteData                      
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,2h                                   
	bne     @@BranchC                                
	cmp     r4,r6                                   
	bls     @@PreMoveAI                                
	mov     r0,3h                                   
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	ldr     r0,=0FBFFh                              
	and     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                        
@@BranchC:
	ldr     r2,=CurrSpriteData                      
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,3h                                   
	bne     @@BranchD                                
	cmp     r4,r6                                   
	bcs     @@PreMoveAI                                
	mov     r0,4h                                   
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	mov     r3,80h                                  
	lsl     r3,r3,3h                                
	mov     r0,r3                                   
	orr     r0,r1                                   
	mov     r3,80h                                  
	lsl     r3,r3,2h                                
	mov     r1,r3                                   
	eor     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,3h                                   
	bl      LeftRightCheckAI		
@@BranchD:
	ldr     r1,=CurrSpriteData                      
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	mov     r2,r1                                   
	cmp     r0,4h                                   
	bne     @@BranchE                               
	cmp     r4,r6                                   
	bls     @@PreMoveAI                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,16h                                  
	strb    r0,[r1]                                 
@@BranchE:
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,5h                                   
	bne     @@BranchF                                
	ldr     r0,=43Eh                                
	cmp     r4,r0                                   
	bhi     @@Store2                                
	ldrh    r0,[r2,2h]                              
	add     r0,10h                                  
	strh    r0,[r2,2h]                              
	b       @@Return                                
.pool
@@Store2:                                
	mov     r0,6h                                   
	strb    r0,[r1]                                 
	ldrh    r1,[r2]                                 
	ldr     r0,=0FBFFh                              
	and     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                        
@@BranchF:
	ldr     r1,=CurrSpriteData                            
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	mov     r2,r1                                   
	cmp     r0,6h                                   
	bne     @@BranchG                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r1,80h                                  
	cmp     r0,0h                                   
	beq     @@Skip                               
	mov     r1,0h                                   
@@Skip:
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r1                                   
	beq     @@StorePose                               
@@PreMoveAI:
	bl      PreMoveAI                               
	b       @@Return                                                                
.pool
@@StorePose:                              
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,18h						;pose = 18h                                  
	strb    r0,[r1]                                 
@@BranchG:
	mov     r1,r2                                   
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,7h                                   
	bne     @@Return                                
	ldrh    r1,[r1]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r1,80h                                  
	cmp     r0,0h                                   
	beq     @@Continue                                
	mov     r1,0h                                   
@@Continue:
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r1                                   
	bne     @@PreMoveAI2                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,1Ah                                  
	strb    r0,[r1]                                 
	b       @@Return
@@PreMoveAI2:                                
	bl      PreMoveAI                               
@@Return:
	pop     r4-r6                                   
	pop     r0                                      
	bx      r0                                      
	lsl     r0,r0,0h 

StraightChargeAI:	
	push    r4-r7,r14						;pose 3A. Ran when Serris charges straight across all platforms                               			  
	mov     r7,10h                                  
	ldr     r1,=CurrSpriteData                           
	ldrh    r5,[r1,2h]			;sprite Y                              
	ldrh    r4,[r1,4h] 			;sprite X                             
	mov     r3,r1                                   
	add     r3,2Eh                                  
	ldrb    r0,[r3]                                 
	mov     r2,r1                                   
	cmp     r0,0h                                   
	bne     @@Branch1                               
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,0C0h                                 
	beq     @@Store                                
	b       @@PreMoveAI  
@@Store:                              
	mov     r0,1h                                   
	strb    r0,[r3]                                 
@@Branch1:
	mov     r3,r2                                   
	add     r3,2Eh                                  
	ldrb    r0,[r3]                                 
	cmp     r0,1h                                   
	bne     @@Branch3                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch4                                
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	sub     r0,0C0h                                 
	cmp     r0,r4                                   
	bgt     @@Branch5                                
	mov     r0,2h                                   
	strb    r0,[r3]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,1h                                   
	bl      UpDownCheckAI                           
	b       @@Branch3                                
.pool 
@@Branch4:                             
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	ldr     r1,=0FFFFFAC0h                          
	add     r0,r0,r1                                
	cmp     r0,r4                                   
	bge     @@Store2                               
	b       @@MoveLeft 
@@Store2:                              
	mov     r0,2h                                   
	strb    r0,[r3]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,1h                                   
	bl      UpDownCheckAI                           
@@Branch3:
	ldr     r1,=CurrSpriteData                      
	mov     r2,2Eh                                  
	add     r2,r2,r1                                
	mov     r12,r2                                  
	ldrb    r0,[r2]                                 
	cmp     r0,2h                                   
	bne     @@Branch7                                
	ldrh    r2,[r1]                                 
	mov     r6,80h                                  
	lsl     r6,r6,2h                                
	mov     r0,r6                                   
	and     r0,r2                                   
	mov     r3,80h                                  
	cmp     r0,0h                                   
	beq     @@Skip                                
	mov     r3,0h  
@@Skip:                                 
	mov     r0,r1                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r3                                   
	bne     @@PreMoveAI                                
	mov     r0,3h                                   
	mov     r3,r12                                  
	strb    r0,[r3]                                 
	ldr     r0,=0FBFFh                              
	and     r0,r2                                   
	eor     r0,r6                                   
	strh    r0,[r1]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,2h                                   
	bl      LeftRightCheckAI 
@@Branch7:                       
	ldr     r1,=CurrSpriteData                      
	mov     r3,r1                                   
	add     r3,2Eh                                  
	ldrb    r0,[r3]                                 
	mov     r2,r1                                   
	cmp     r0,3h                                   
	bne     @@Branch8                               
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,40h                                  
	bne     @@PreMoveAI                                
	mov     r0,4h                                   
	strb    r0,[r3]
@@Branch8:                                 
	mov     r3,r2                                   
	add     r3,2Eh                                  
	ldrb    r0,[r3]                                 
	cmp     r0,4h                                   
	bne     @@Branch9                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch10                                
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	ldr     r1,=0FFFFFD00h                          
	add     r0,r0,r1                                
	cmp     r0,r4                                   
	bgt     @@Branch5                                
	mov     r0,5h                                   
	strb    r0,[r3]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,2h                                   
	bl      UpDownCheckAI							  
	b       @@Branch9                                
.pool
@@Branch5:                                
	ldrh    r0,[r2,4h]                              
	add     r0,r0,r7                                
	strh    r0,[r2,4h]                              
	b       @@Return
@@Branch10:                                
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	ldr     r1,=0FFFFFD00h                          
	add     r0,r0,r1                                
	cmp     r0,r4                                   
	blt     @@MoveLeft                                
	mov     r0,5h                                   
	strb    r0,[r3]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,2h                                   
	bl      UpDownCheckAI 
@@Branch9:                          
	ldr     r1,=CurrSpriteData                      
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	mov     r2,r1                                   
	cmp     r0,5h                                   
	bne     @@Branch11                               
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	lsl     r0,r0,10h                               
	lsr     r0,r0,10h                               
	neg     r0,r0                                   
	asr     r0,r0,1Fh                               
	mov     r1,80h                                  
	and     r0,r1                                   
	mov     r1,r2                                   
	add     r1,2Fh                                  
	ldrb    r1,[r1]                                 
	cmp     r1,r0                                   
	bne     @@PreMoveAI                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,16h                                  
	strb    r0,[r1]
@@Branch11:                                 
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,6h                                   
	bne     @@Branch12                                
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,40h                                  
	beq     @@Store3                                
@@PreMoveAI:
	bl      PreMoveAI                               
	b       @@Return                                
.pool 
@@Store3:                             
	mov     r0,7h                                   
	strb    r0,[r1] 
@@Branch12:                                
	mov     r3,r2                                   
	mov     r0,2Eh                                  
	add     r0,r0,r3                                
	mov     r12,r0                                  
	ldrb    r0,[r0]                                 
	cmp     r0,7h                                   
	bne     @@Branch13                                
	ldrh    r1,[r3]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch14                                
	ldr     r0,=SerrisXSpawn                           
	ldrh    r0,[r0]                                 
	sub     r0,0C0h                                 
	cmp     r0,r4                                   
	bgt     @@MoveRight                                
	mov     r0,8h                                   
	mov     r1,r12                                  
	strb    r0,[r1]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,1h                                   
	bl      UpDownCheckAI                           
	b       @@Branch13                                
.pool                      
@@MoveRight:        
	ldrh    r0,[r3,4h]                              
	add     r0,r0,r7                                
	strh    r0,[r3,4h]                              
	b       @@Return
@@Branch14:                                
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	ldr     r3,=0FFFFFAC0h                          
	add     r0,r0,r3                                
	cmp     r0,r4                                   
	bge     @@Branch15
@@MoveLeft:                                
	ldrh    r0,[r2,4h]                              
	sub     r0,r0,r7                                
	strh    r0,[r2,4h]                              
	b       @@Return                                
.pool
@@Branch15:                             
	mov     r0,8h                                   
	mov     r1,r12                                  
	strb    r0,[r1]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,1h                                   
	bl      UpDownCheckAI   
@@Branch13:                        
	ldr     r2,=CurrSpriteData                      
	mov     r0,r2                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,8h                                   
	bne     @@Return                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r3,80h                                  
	cmp     r0,0h                                   
	beq     @@Skipp                                
	mov     r3,0h                                   
@@Skipp:
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r3                                   
	bne     @@PreMoveAI2                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,2h                                   
	strb    r0,[r1]                                 
	b       @@Return                                
.pool
@@PreMoveAI2:                              
	bl      PreMoveAI
@@Return:                             
	pop     r4-r7                                   
	pop     r0                                      
	bx      r0  
	lsl     r0,r0,0h 

JumpArcAI:	     
	push    r4-r6,r14					;pose 3Ch. Ran when arcing out and back into the water                             
	mov     r6,10h                                
	ldr     r1,=CurrSpriteData                    
	ldrh    r5,[r1,2h]					;sprite Y                            
	ldrh    r4,[r1,4h]					;sprite X                            
	mov     r0,r1                                 
	add     r0,2Eh                                
	ldrb    r0,[r0]                               
	mov     r2,r1                                 
	cmp     r0,0h                                 
	bne     @@Branch1                              
	ldrh    r1,[r2]                               
	mov     r0,80h                                
	lsl     r0,r0,2h                              
	and     r0,r1                                 
	mov     r1,80h                                
	cmp     r0,0h                                 
	beq     @@Skip                              
	mov     r1,0h 
@@Skip:                                
	mov     r0,r2                                 
	add     r0,2Fh                                
	ldrb    r0,[r0]                               
	cmp     r0,r1                                 
	bne     @@PreMoveAI                              
	mov     r1,r2                                 
	add     r1,24h                                
	mov     r0,16h                                
	strb    r0,[r1] 
@@Branch1:                              
	mov     r1,r2                                 
	add     r1,2Eh                                
	ldrb    r0,[r1]                               
	cmp     r0,1h                                 
	bne     @@Branch2                              
	ldr     r0,=33Eh                              
	cmp     r5,r0                                 
	bhi     @@Branch3                              
	ldrh    r0,[r2,2h]                            
	add     r0,r0,r6                              
	strh    r0,[r2,2h]                            
	b       @@Return                             
.pool 
@@Branch3:                             
	mov     r0,2h                                 
	strb    r0,[r1]                               
	ldrh    r1,[r2]                               
	ldr     r0,=0FBFFh                            
	and     r0,r1                                 
	mov     r3,80h                                
	lsl     r3,r3,2h                              
	mov     r1,r3                                 
	eor     r0,r1                                 
	strh    r0,[r2]                               
	mov     r0,r5                                 
	mov     r1,r4                                 
	mov     r2,2h                                 
	bl      LeftRightCheckAI 
@@Branch2:                     
	ldr     r1,=CurrSpriteData                    
	mov     r3,r1                                 
	add     r3,2Eh                                
	ldrb    r0,[r3]                               
	mov     r2,r1                                 
	cmp     r0,2h                                 
	bne     @@Branch4                              
	mov     r0,r2                                 
	add     r0,2Fh                                
	ldrb    r0,[r0]                               
	cmp     r0,40h                                
	beq     @@Store2
@@PreMoveAI:                              
	bl      PreMoveAI                             
	b       @@Return                              
.pool
@@Store2:                           
	mov     r0,3h                                 
	strb    r0,[r3] 
@@Branch4:                              
	mov     r3,r2                                 
	mov     r0,2Eh                                
	add     r0,r0,r3                              
	mov     r12,r0                                
	ldrb    r0,[r0]                               
	cmp     r0,3h                                 
	bne     @@Branch5                              
	ldrh    r1,[r3]                               
	mov     r0,80h                                
	lsl     r0,r0,2h                              
	and     r0,r1                                 
	cmp     r0,0h                                 
	beq     @@Branch6                              
	ldr     r0,=SerrisXSpawn                          
	ldrh    r0,[r0]                               
	ldr     r1,=0FFFFFE80h                        
	add     r0,r0,r1                              
	cmp     r0,r4                                 
	bgt     @@MoveRight                              
	mov     r0,4h                                 
	mov     r3,r12                                
	strb    r0,[r3]                               
	mov     r0,r5                                 
	mov     r1,r4                                 
	mov     r2,2h                                 
	bl      UpDownCheckAI                                
	b       @@Branch5                                
.pool
@@MoveRight:                               
	ldrh    r0,[r3,4h]                              
	add     r0,r0,r6                                
	strh    r0,[r3,4h]                              
	b       @@Return
@@Branch6:                                
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
	ldr     r1,=0FFFFFB80h                          
	add     r0,r0,r1                                
	cmp     r0,r4                                   
	bge     @@Branch7                                
	ldrh    r0,[r2,4h]                              
	sub     r0,r0,r6                                
	strh    r0,[r2,4h]                              
	b       @@Return                                
.pool
@@Branch7:                                
	mov     r0,4h                                   
	mov     r3,r12                                  
	strb    r0,[r3]                                 
	mov     r0,r5                                   
	mov     r1,r4                                   
	mov     r2,2h                                   
	bl      UpDownCheckAI 
@@Branch5:                               
	ldr     r2,=CurrSpriteData                           
	mov     r0,r2                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,4h                                   
	bne     @@Return                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r1,80h                                  
	cmp     r0,0h                                   
	beq     @@Skip2                               
	mov     r1,0h                                   
@@Skip2:
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r1                                   
	bne     @@PreMoveAI2                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,18h                                  
	strb    r0,[r1]                                 
	b       @@Return                               
.pool
@@PreMoveAI2:                              
	bl      PreMoveAI
@@Return:                                
	pop     r4-r6                                   
	pop     r0                                      
	bx      r0 
	lsl     r0,r0,0h   
 
RisingAI:					
	push    r14 						;pose 54h. Where serris first rises?                                    
	ldr     r1,=CurrSpriteData                           
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	mov     r2,r1                                   
	cmp     r0,0h                                   
	bne     @@Branch1                                
	ldrh    r1,[r2]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r1,80h                                  
	cmp     r0,0h                                   
	beq     @@Skip                                
	mov     r1,0h
@@Skip:                                   
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r1                                   
	beq     @@Branch2                                
	bl      PreMoveAI                                
	b       @@Return                                
.pool  
@@Branch2:                            
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,16h                                  
	strb    r0,[r1]
@@Branch1:                                 
	mov     r1,r2                                   
	mov     r0,r1                                   
	add     r0,2Eh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,1h                                   
	bne     @@Return                                
	ldrh    r1,[r1]                                 
	mov     r0,80h                                  
	lsl     r0,r0,2h                                
	and     r0,r1                                   
	mov     r1,80h                                  
	cmp     r0,0h                                   
	beq     @@Skip2                                
	mov     r1,0h
@@Skip2:                                   
	mov     r0,r2                                   
	add     r0,2Fh                                  
	ldrb    r0,[r0]                                 
	cmp     r0,r1                                   
	bne     @@PreMoveAI                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,18h                                  
	strb    r0,[r1]                                 
	b       @@Return
@@PreMoveAI:                                
	bl      PreMoveAI 
@@Return:                               
	pop     r0                                      
	bx      r0 

RiseB4OscillateAI:	    
	push    r4,r5,r14						;pose 2. Run when rising before OscillateAI                               
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	mov     r3,r2                                   
	cmp     r0,0h                                   
	beq     @@Branch1                                
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
	strb    r0,[r1]                                 
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FFFFFA00h                          
	mov     r0,r2                                   
	ldrh    r1,[r1]                                 
	add     r0,r0,r1                                
	b       @@Branch2                                
.pool
@@Branch1:                           
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,40h                                  
	strb    r0,[r1]                                 
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0] 
@@Branch2:                                
	strh    r0,[r3,4h]                              
	ldrh    r4,[r3,2h]                              
	ldrh    r5,[r3,4h]                              
	ldr     r0,=31Fh                                
	cmp     r4,r0                                   
	bhi     @@Branch3                                
	ldrh    r1,[r3]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch4                                
	mov     r2,80h                                  
	lsl     r2,r2,2h                                
	mov     r0,r2                                   
	orr     r0,r1                                   
	b       @@Store                                
.pool
@@Branch4:                                
	ldr     r0,=0FDFFh                              
	and     r0,r1
@@Store:                                   
	strh    r0,[r3]                                 
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,3h                                
	mov     r0,r2                                   
	mov     r2,0h                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,38h                                  
	strb    r0,[r1]                                 
	mov     r0,r3                                   
	add     r0,2Eh                                  
	strb    r2,[r0]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                               
	b       @@Return                                
.pool 
@@Branch3:                               
	mov     r0,r4                                   
	sub     r0,10h                                  
	strh    r0,[r3,2h]
@@Return:                              
	pop     r4,r5                                   
	pop     r0                                      
	bx      r0

RiseB4StraightChargeAI:	
	push    r4,r5,r14 						;pose 18h. Ran when rising up before StraightChargeAI                            
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	mov     r3,r2                                   
	cmp     r0,0h                                   
	beq     @@Branch1                                
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
	strb    r0,[r1]                                 
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FFFFFA00h                          
	mov     r0,r2                                   
	ldrh    r1,[r1]                                 
	add     r0,r0,r1                                
	b       @@StoreX                                
.pool
@@Branch1:                                
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,40h                                  
	strb    r0,[r1]                                 
	ldr     r0,=SerrisXSpawn                            
	ldrh    r0,[r0]                                 
@@StoreX:
	strh    r0,[r3,4h]                              
	ldrh    r4,[r3,2h]                              
	ldrh    r5,[r3,4h]                              
	ldr     r0,=33Fh                                
	cmp     r4,r0                                   
	bhi     @@StoreY                                
	ldrh    r1,[r3]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch2                                
	mov     r2,80h                                  
	lsl     r2,r2,2h                                
	mov     r0,r2                                   
	orr     r0,r1                                   
	b       @@Skip                                
.pool
@@Branch2:                               
	ldr     r0,=0FDFFh                              
	and     r0,r1
@@Skip:                                   
	strh    r0,[r3]                                 
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,3h                                
	mov     r0,r2                                   
	mov     r2,0h                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,3Ah                                  
	strb    r0,[r1]                                 
	mov     r0,r3                                   
	add     r0,2Eh                                  
	strb    r2,[r0]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,1h                                   
	bl      LeftRightCheckAI                               
	b       @@Return                                
.pool 
@@StoreY:                               
	mov     r0,r4                                   
	sub     r0,10h                                  
	strh    r0,[r3,2h]                              
@@Return:
	pop     r4,r5                                   
	pop     r0                                      
	bx      r0 

MiddleRisingArcAI:	
	push    r4,r5,r14					;pose 1Ah. Ran when Serris rises from the middile platform to an arc.                            
	ldr     r2,=CurrSpriteData                           
	ldrh    r1,[r2]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	mov     r3,r2                                   
	cmp     r0,0h                                   
	beq     @@Branch1                                
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
	b       @@Store                                
.pool
@@Branch1:                              
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,40h
@@Store:                                  
	strb    r0,[r1]                                 
	ldr     r0,=SerrisXSpawn                            
	ldr     r2,=0FFFFFD00h                          
	mov     r1,r2                                   
	ldrh    r0,[r0]                                 
	add     r1,r1,r0                                
	strh    r1,[r3,4h]					;New X pos                              
	ldrh    r4,[r3,2h] 					;sprite Y                            
	ldrh    r5,[r3,4h]                	;sprite X              
	ldr     r0,=2FFh                                
	cmp     r4,r0                                   
	bhi     @@StoreY                                
	ldrh    r1,[r3]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch2                                
	mov     r2,80h                                  
	lsl     r2,r2,2h                                
	mov     r0,r2                                   
	orr     r0,r1                                   
	b       @@Skip                                
.pool  
@@Branch2:                            
	ldr     r0,=0FDFFh                              
	and     r0,r1  
@@Skip:                                 
	strh    r0,[r3]                                 
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,3h                                
	mov     r0,r2                                   
	mov     r2,0h                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,3Ch                                  
	strb    r0,[r1]						;pose = 3Ch                                 
	mov     r0,r3                                   
	add     r0,2Eh                                  
	strb    r2,[r0]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,2h                                   
	bl      LeftRightCheckAI                                
	b       @@Return                               
.pool 
@@StoreY:                              
	mov     r0,r4                                   
	sub     r0,10h                                  
	strh    r0,[r3,2h] 
@@Return:                             
	pop     r4,r5                                   
	pop     r0                                      
	bx      r0 

SideRiseB4Arc:                                       
	push    r4,r5,r14				;pose 53h.ran when risng in between platforms before arcing                                 
	ldr     r2,=CurrSpriteData		;also when Serris Blocks start breaking?	                            
	ldrh    r1,[r2]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	mov     r3,r2                                   
	cmp     r0,0h                                   
	beq     @@Branch1                               
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
	strb    r0,[r1]                                 
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FB80h                              
	b       @@Branch2                                
.pool 
@@Branch1:                              
	mov     r1,r3                                   
	add     r1,2Ah                                  
	mov     r0,40h                                  
	strb    r0,[r1]                                 
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FFFFFE80h
@@Branch2:                          
	mov     r0,r2                                   
	ldrh    r1,[r1]                                 
	add     r0,r0,r1                                
	strh    r0,[r3,4h]					;new Y pos                              
	ldrh    r4,[r3,2h]					;Sprite X                              
	ldrh    r5,[r3,4h]					;sprite Y                              
	ldr     r0,=2FFh                                
	cmp     r4,r0                                   
	bhi     @@Branch3                                
	ldrh    r1,[r3]                                 
	mov     r0,40h                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch4                                
	mov     r2,80h                                  
	lsl     r2,r2,2h                                
	mov     r0,r2                                   
	orr     r0,r1                                   
	b       @@Skip                               
.pool 
@@Branch4:                               
	ldr     r0,=0FDFFh                              
	and     r0,r1  
@@Skip:                                 
	strh    r0,[r3]                                 
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,3h                                
	mov     r0,r2                                   
	mov     r2,0h                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,3Eh                                  
	strb    r0,[r1]                                 
	mov     r0,r3                                   
	add     r0,2Eh                                  
	strb    r2,[r0]                                 
	mov     r0,r4                                   
	mov     r1,r5                                   
	mov     r2,2h                                   
	bl      LeftRightCheckAI
	b 		@@Return
.pool 
@@Branch3:                               
	mov     r0,r4                                   
	sub     r0,10h                                  
	strh    r0,[r3,2h]                              
@@Return:
	pop     r4,r5                                   
	pop     r0                                      
	bx      r0 

NextAttackAI:	    
	push    r14								;pose 8. used to pick next attack.                                      
	mov     r3,0h                                   
	ldr     r2,=SamusData                          
	ldr     r0,=SpriteRNG                            
	ldrb    r1,[r0]                                 
	ldrh    r0,[r2,12h]                                 
	add     r0,r0,r1                                
	mov     r1,0Fh						;makes value 1 digit                                  
	and     r0,r1                                   
	sub     r0,1h                                   
	cmp     r0,0Dh                                  
	bhi     @@Pose1C                                
	lsl     r0,r0,2h 					;RNG that determines next pose                               
	ldr     r1,=@@JumpTable        		;all poses have a 1 out of 4 chance                   
	add     r0,r0,r1                                
	ldr     r0,[r0]                                 
	mov     r15,r0                                  
.pool
@@JumpTable:
	.word @@Pose2,@@Pose2,@@Pose2,@@Pose2                               
	.word @@Pose18,@@Pose18,@@Pose18,@@Pose18                             
	.word @@Pose1A,@@Pose1A,@@Pose1A,@@Pose1A                              
	.word @@Pose1C,@@Pose1C
@@Pose2:	
	mov     r2,2h                                   
	b       @@Next
@@Pose18:                               
	mov     r2,18h                                  
	b       @@Next 
@@Pose1A:                               
	mov     r2,1Ah                                  
	b       @@Next  
@@Pose1C:                              
	mov     r2,1Ch  
@@Next:                                
	ldr     r0,=Bit16Counter                            
	ldrh    r0,[r0]                                 
	ldr     r1,=CurrSpriteData                            
	ldrh    r1,[r1,16h]					;sprite animation                             
	add     r0,r0,r1                                
	mov     r1,1h                                   
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Store                                
	add     r0,r3,1                                 
	lsl     r0,r0,18h                               
	lsr     r3,r0,18h
@@Store:                               
	ldr     r0,=SerrisNextPose                          
	strb    r2,[r0]                                 
	ldr     r0,=SerrisAttackDirection		                            
	strb    r3,[r0]                                 
	pop     r0                                      
	bx      r0                                      
.pool 

NextSpeedAttackAI:
	push    r14 				;pose = 8. Ran when finding new attack, when in speed mode.                                   
	mov     r2,0h                                   
	ldr     r0,=SpriteRNG	                            
	ldrb    r0,[r0]                                 
	mov     r1,7h                                   
	and     r1,r0                                   
	mov     r0,r1                                   
	cmp     r1,1h 				;no value over 7                                  
	bne     @@CompareSet                                
	mov     r1,2h                                   
	b       @@Store                               
.pool                              
@@CompareSet:
	cmp     r1,2h                                   
	bne     @@CheckIf3                               
	mov     r1,2h                                   
	b       @@Branch                                
@@CheckIf3:
	cmp     r1,3h                                   
	bne     @@CheckIf4                                
	mov     r1,18h                                  
	b       @@Store  
@@CheckIf4:                              
	cmp     r1,4h                                   
	bne     @@CheckIf5                                
	mov     r1,18h			                                  
	b       @@Branch                                
@@CheckIf5:
	cmp     r1,5h                                   
	bne     @@CheckIf6                                
	mov     r1,1Ah                                  
	b       @@Store                                
@@CheckIf6:
	cmp     r1,6h                                   
	bne     @@CheckIf7                                
	mov     r1,1Ah                                  
	b       @@Branch                                
@@CheckIf7:
	mov     r1,2h                                   
	cmp     r0,7h                                   
	beq     @@Store                                
@@Branch:
	mov     r2,1h                                   
@@Store:
	ldr     r0,=SerrisNextPose                           
	strb    r1,[r0]                                 
	ldr     r0,=SerrisAttackDirection 			                          
	strb    r2,[r0]                                 
	pop     r0                                      
	bx      r0                                      
.pool 
 
DiveUnderAI: 
	push    r14							;pose 16h. Ran when Serris dives back in the ground                                     
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	mov     r0,40h						;checks for 40h, X flip                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@NotFlipped                                
	mov     r1,r2                                   
	add     r1,2Ah                                  
	mov     r0,40h                                  
	b       @@Store                                
.pool
@@NotFlipped:                             
	mov     r1,r2                                   
	add     r1,2Ah                                  
	mov     r0,0C0h                                 
@@Store:
	strb    r0,[r1]                                 
	ldrh    r1,[r2,2h]                              
	ldr     r0,=77Fh                                
	cmp     r1,r0                                   
	bls     @@Branch                                
	mov     r0,r2                                   
	add     r0,32h                                  
	ldrb    r1,[r0]                                 
	mov     r0,80h                                  
	and     r0,r1                                   
	ldr     r1,=SerrisWaitTimer                            
	cmp     r0,0h                                   
	bne     @@Branch1                                
	ldr     r0,=SpriteRNG                           
	ldrb    r0,[r0]                                 
	lsl     r0,r0,1h                                
	add     r0,41h                                  
	strb    r0,[r1]                                 
@@Branch1:
	ldrb    r0,[r1]                                 
	mov     r1,r2                                   
	add     r1,2Ch                                  
	strb    r0,[r1]                                 
	sub     r1,8h					;used to be sub 0Dh                                  
	mov     r0,8h                                   
	strb    r0,[r1]                                 
	b       @@Return                                
.pool 
@@Branch:                           
	mov     r0,r1                                   
	add     r0,10h                                  
	strh    r0,[r2,2h]				;store new Y pos
@@Return:                              
	pop     r0                                      
	bx      r0                                      
	lsl     r0,r0,0h 

UnderGroundAI:
	push    r14						;pose 1. Ran when serris is going into, coming out of, and while undeground                                  
	ldr     r2,=CurrSpriteData                           
	mov     r1,r2                                   
	add     r1,2Ch					;timer                                  
	ldrb    r0,[r1]                                 
	sub     r0,1h                                   
	strb    r0,[r1]                                 
	lsl     r0,r0,18h                               
	lsr     r0,r0,18h                               
	mov     r3,r2                                   
	cmp     r0,0h                                   
	bne     @@Branch1                                
	ldr     r0,=SerrisNextPose                            
	ldrb    r1,[r0]                                 
	mov     r0,r2                                   
	add     r0,24h                                  
	strb    r1,[r0]                                 
	ldr     r0,=SerrisAttackDirection                            
	ldrb    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@SetY                                
	ldrh    r1,[r2]                                 
	mov     r0,40h                                  
	orr     r0,r1                                   
	b       @@Store                                
.pool
@@SetY:                              
	ldrh    r1,[r2]                                 
	ldr     r0,=0FFBFh                              
	and     r0,r1                                   
@@Store:
	strh    r0,[r2]                                 
	ldr     r0,=SerrisYSpawn                            
	ldrh    r0,[r0]                                 
	strh    r0,[r3,2h]                              
	bl      OAMSwitchAI                               
	b       @@Return                                
.pool 
@@Branch1:
	cmp     r0,28h                                  
	bne     @@Return                                
	mov     r0,r2                                   
	add     r0,32h                                  
	ldrb    r1,[r0]						;collision propeties                                  
	mov     r0,80h                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	bne     @@Return                                
	ldr     r0,=SerrisBoostTimer				                           
	ldrh    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@NotBoosting                                
	bl      NextSpeedAttackAI                                
	b       @@NextPoseCheck                                
.pool
@@NotBoosting:                              
	bl      NextAttackAI
@@NextPoseCheck:
	ldr     r0,=SerrisNextPose                           
	ldrb    r0,[r0]                                 
	cmp     r0,1Ch                                  
	bne     @@CheckIf1A                                
	ldr     r0,=SerrisAttackDirection                            
	ldrb    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@Branch4                                
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FB80h                              
	b       @@Branch2                               
.pool   
@@Branch4:                             
	ldr     r1,=SerrisXSpawn                           
	ldr     r2,=0FFFFFE80h                          
	b       @@Branch2                                
.pool
@@CheckIf1A:                               
	cmp     r0,1Ah                                  
	bne     @@Not1A                                
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FFFFFD00h                          
	b       @@Branch2                                
.pool
@@Not1A:                              
	ldr     r0,=SerrisAttackDirection                            
	ldrb    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@Branch3                                
	ldr     r1,=SerrisXSpawn                            
	ldr     r2,=0FFFFFA00h 
@@Branch2:                         
	mov     r0,r2                                   
	ldrh    r1,[r1]                                 
	add     r0,r0,r1                                
	lsl     r0,r0,10h                               
	lsr     r1,r0,10h                               
	b       @@PreAttack                                
.pool
@@Branch3:                              
	ldr     r0,=SerrisXSpawn                            
	ldrh    r1,[r0]
@@PreAttack:                                
	ldr     r0,=SerrisYSpawn                            
	ldrh    r0,[r0]                                 
	sub     r0,78h                                  
	mov     r2,38h
	ldr		r3,=SetParticalEffect + 1
	bl      WrapperR3                                
	ldr     r0,=269h 					;bubble sound
	ldr		r3,=PlaySound + 1
	bl      WrapperR3 
@@Return:                              
	pop     r0                                      
	bx      r0                                      
.pool

Pose47AI:                                
	ldr     r3,=CurrSpriteData		 ;pose 47h,                            
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r2,0h                                   
	mov     r0,48h                                  
	strb    r0,[r1]					;pose = 48h                                 
	ldrb    r0,[r3,1Eh]				;sprite room slot                             
	add     r0,1h                                   
	lsl     r0,r0,4h                                
	add     r1,0Ah                                  
	strb    r0,[r1]                                 
	mov     r0,r3                                   
	add     r0,2Ch                                  
	strb    r2,[r0]                                 
	sub     r0,7h  					;used to be sub 0Ch                                
	strb    r2,[r0]                                 
	ldrh    r1,[r3]                                 
	mov     r2,80h                                  
	lsl     r2,r2,8h                                
	mov     r0,r2                                   
	orr     r0,r1                                   
	strh    r0,[r3]                                 
	bx      r14                                                                    
.pool
 
SegmentsDyingAI: 	
	push    r4-r7,r14				;pose 48h. Makes segments of serris invisible                                
	ldr     r2,=CurrSpriteData                            
	ldrh    r0,[r2]					;sprite status                                 
	mov     r6,4h                                   
	mov     r1,r0                                   
	eor     r1,r6                                   
	strh    r1,[r2]					;sets and unsets of 4h flag, invisible. Makes sprite flicker                               
	mov     r4,r2                                   
	add     r4,2Eh                                  
	ldrb    r0,[r4]                                 
	cmp     r0,0h                                   
	beq     @@Branch1                                
	sub     r0,1h                                   
	strb    r0,[r4]                                 
	lsl     r0,r0,18h                               
	cmp     r0,0h                                   
	bne     @@Return                                
	mov     r0,2h                                   
	and     r1,r0                                   
	cmp     r1,0h                                   
	beq     @@Return                               
	ldrh    r0,[r2,2h] 					;sprite Y                             
	ldrh    r1,[r2,4h]					;sprite X                              
	mov     r2,22h						;2F = puffs?
	ldr		r3,=SetParticalEffect + 1
	bl      WrapperR3                              
	mov     r0,97h                                 
	lsl     r0,r0,1h
	ldr		r3,=PlaySound + 1
	bl      WrapperR3                                
	b       @@Return                                
.pool 
@@Branch1:                              
	mov     r0,2Ch                                
	add     r0,r0,r2                                
	mov     r12,r0                                  
	ldrb    r3,[r0]                                 
	ldr     r1,=DeathTable				;serris GFX - 2Ah?                          
	lsl     r0,r3,1h                                
	add     r0,r0,r1                                
	ldrh    r5,[r0]                                 
	mov     r7,0h                                   
	ldsh    r1,[r0,r7]                              
	ldr     r0,=7FFFh                               
	cmp     r1,r0                                   
	bne     @@Branch2                                
	mov     r1,r2                                   
	add     r1,24h                                  
	mov     r0,4Ah                                  
	strb    r0,[r1]                                 
	strb    r6,[r4]                                 
	mov     r0,0h                                   
	mov     r1,r12                                  
	strb    r0,[r1]                                 
	ldrh    r0,[r2,2h]                              
	strh    r0,[r2,6h]                              
	b       @@Return                               
.pool
@@Branch2:                                                               
	add     r0,r3,1                                 
	mov     r7,r12                                  
	strb    r0,[r7]                                 
	ldrh    r0,[r2,2h]                              
	add     r0,r0,r5                                
	strh    r0,[r2,2h]                              
@@Return:
	pop     r4-r7                                   
	pop     r0                                      
	bx      r0                                      
 
KillSegmentAI: 					
	push    r4-r6,r14 							;pose 4Ah. Explodes and kills segments 
	add		sp,-4h
	ldr     r2,=CurrSpriteData                            
	ldrh    r0,[r2]								;sprite status                                 
	mov     r1,4h                                   
	eor     r0,r1                                   
	strh    r0,[r2]								;sets and unsets of 4h flag, invisible. Makes sprite flicker                                  
	mov     r1,r2                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	cmp     r0,0h                                   
	beq     @@Branch1                               
	sub     r0,1h                                   
	strb    r0,[r1]                                 
	b       @@Return                                
.pool
@@Branch1:                              
	mov     r0,2Ch                                  
	add     r0,r0,r2                                
	mov     r12,r0                                  
	ldrb    r3,[r0]                                 
	ldr     r5,=DeathTable + 10h				;serris GFX - 1Ah?                            
	lsl     r0,r3,1h                                
	add     r0,r0,r5                                
	ldrh    r4,[r0]                                 
	mov     r6,0h                                   
	ldsh    r1,[r0,r6]                              
	ldr     r0,=7FFFh                               
	cmp     r1,r0                                   
	bne     @@Branch2                                
	sub     r1,r3,1                                 
	lsl     r1,r1,1h                                
	add     r1,r1,r5                                
	ldrh    r0,[r2,2h]                              
	ldrh    r1,[r1]                                 
	add     r0,r0,r1                                
	b       @@Store                                
.pool
@@Branch2:                               
	add     r0,r3,1                                 
	mov     r1,r12                                  
	strb    r0,[r1]                                 
	ldrh    r0,[r2,2h]                              
	add     r0,r0,r4 
@@Store:                               
	strh    r0,[r2,2h]                              
	ldr     r1,=CurrSpriteData                            
	ldrh    r0,[r1,6h]                              
	ldr     r2,=2BFh                                
	cmp     r0,r2                                   
	bhi     @@NoEffects                                
	ldrh    r0,[r1,2h]                              
	cmp     r0,r2                                   
	bls     @@NoEffects                               
	ldrb    r0,[r1,1Eh]                             
	cmp     r0,6h                                   
	bls     @@SoundEffect                                
	ldrh    r0,[r1,2h]                              
	add     r0,44h                                  
	ldrh    r1,[r1,4h]                              
	mov     r2,36h                                  
	ldr		r3,=SetParticalEffect + 1		
	bl		WrapperR3                              
	b       @@PlaySound                                
.pool
@@SoundEffect:                               
	ldrh    r0,[r1,2h]                              
	add     r0,44h                                  
	ldrh    r1,[r1,4h]                              
	mov     r2,22h                                  
	ldr		r3,=SetParticalEffect + 1		
	bl		WrapperR3                                 
@@PlaySound:
	ldr     r0,=1A7h			;boom                                
	ldr		r3,=PlaySound + 1		
	bl		WrapperR3
@@NoEffects:                                
	ldr     r2,=CurrSpriteData                            
	ldrh    r0,[r2,2h]                              
	strh    r0,[r2,6h]                              
	lsl     r0,r0,10h                               
	mov     r1,0B0h                                 
	lsl     r1,r1,12h                               
	cmp     r0,r1                                   
	bls     @@Return                                
	ldrh    r1,[r2]                                 
	mov     r0,2h                                   
	and     r0,r1                                                                
	cmp     r0,0h                                   
	bne     @@Return                                
	ldr     r1,=CurrSpriteData
	mov		r0,29h
	str		r0,[sp]
	mov		r0,0h
	mov		r3,1h
	ldrh	r2,[r1,4h]
	ldrh	r1,[r1,2h]
	ldr		r6,=DeathRoutine + 1		
	bl		WrapperR6   							;kills segment 
@@Return:
	add		sp,4h
	pop     r4-r6                                   
	pop     r0                                      
	bx      r0                                      
.pool

SpawnKillBlockAI:                              							
	push    r14							; Creates and destroys blocks for serris blocks                                     
	ldr     r1,=CurrClipdataEffectingAction                            
	strb    r0,[r1]						;if 0, create. else, destroy                                  
	ldr     r1,=CurrSpriteData                            
	ldrh    r0,[r1,2h]					;sprite Y                              
	ldrh    r1,[r1,4h]					;Sprite X
	ldr		r3,=ChangeBlocks + 1
	bl      WrapperR3				;spawns or destroys block clipdata on serris blocks                                
	pop     r0                                      
	bx      r0                                      
.pool  
 
SerrisBlockSpawnAI:       
	push    r14                                     
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	ldr     r0,=0FFFBh                              
	and     r0,r1                                   
	strh    r0,[r2]                                 
	mov     r0,r2                                   
	add     r0,27h                                  
	mov     r1,8h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	add     r0,1h                                   
	strb    r1,[r0]                                 
	ldr     r1,=0FFFCh                              
	strh    r1,[r2,0Ah]					;top boundary                             
	mov     r0,4h                                   
	strh    r0,[r2,0Ch]					;bottom                             
	strh    r1,[r2,0Eh] 					;left                            
	strh    r0,[r2,10h] 					;right                            
	ldrb    r0,[r2,1Eh]                             
	mov     r3,r2                                   
	cmp     r0,0h                                   
	beq     @@Pointer2                               
	ldr     r0,=OAM_45					;OAM pointer                            
	b       @@StoreOAM                               
.pool
@@Pointer2:                               
	ldr     r0,=OAM_48					;OAM pointer 
@@StoreOAM:                           
	str     r0,[r3,18h]                             
	mov     r0,0h                                   
	strb    r0,[r3,1Ch]                             
	mov     r2,0h                                   
	strh    r0,[r3,16h]                             
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,2h                                   
	strb    r0,[r1]						;pose = 2                                 
	mov     r0,r3                                   
	add     r0,25h                                  
	strb    r2,[r0]                                 
	mov     r0,2h                                   
	bl      SpawnKillBlockAI                             
	pop     r0                                      
	bx      r0                                      
.pool
 
BreakCheckAI: 
	push    r14 					;pose 2, checks if blocks should begin crumbling                                     
	ldr     r2,=SpriteData                           
	ldr     r3,=CurrSpriteData                            
	mov     r0,r3                                   
	add     r0,23h                                  
	ldrb    r1,[r0]				;primary sprite RAM slot                                 
	lsl     r0,r1,3h                                
	sub     r0,r0,r1                                
	lsl     r0,r0,3h                                
	add     r0,r0,r2                                
	add     r0,24h                                  
	ldrb    r0,[r0]                                 
	cmp     r0,1h				;false when serris is triggered                                   
	bne     @@Return                                
	mov     r1,r3                                   
	add     r1,24h                                  
	mov     r0,18h                                  
	strb    r0,[r1]					;pose = 18                                 
	ldr     r0,=SpriteRNG           ;sets up the breakage of blocks                
	ldrb    r0,[r0]                                 
	lsl     r0,r0,1h                                
	add     r0,8h                                   
	add     r1,0Ah                                  
	strb    r0,[r1]                                 
@@Return:
	pop     r0                                      
	bx      r0                                      
.pool 
 
BreakingAI:      
	push    r4,r14					;pose 18h, ran when blocks start crumbling and until they can no longer be stood on                                  
	ldr     r4,=CurrSpriteData                            
	mov     r1,r4                                   
	add     r1,2Eh                                  
	ldrb    r0,[r1]                                 
	mov     r2,r4                                   
	cmp     r0,0h                                   
	beq     @@CheckEndAnimation                                
	sub     r0,1h                                   
	strb    r0,[r1]                                 
	lsl     r0,r0,18h                               
	cmp     r0,0h                                   
	bne     @@Return                               
	ldrb    r0,[r4,1Eh]                             
	cmp     r0,0h                                   
	beq     @@Pointer2                                
	ldr     r0,=OAM_46 				;OAM Pointer                           
	b       @@StoreOAM                               
.pool
@@Pointer2:                               
	ldr     r0,=OAM_46			 ;OAM pointer 
@@StoreOAM:                           
	str     r0,[r4,18h]                             
	mov     r0,0h                                   
	strb    r0,[r2,1Ch]                             
	strh    r0,[r2,16h]                             
	b       @@Return                                
.pool
@@CheckEndAnimation: 
	ldr		r3,=CheckEndSpriteAnimation + 1
	bl      WrapperR3                              
	cmp     r0,0h                                   
	beq     @@CheckIf4                                
	ldrb    r0,[r4,1Eh]                             
	cmp     r0,0h                                   
	beq     @@OtherPointer                                
	ldr     r0,=OAM_47          ;OAM Pointer                  
	b       @@StoreOAM2                                
.pool 
@@OtherPointer:                              
	ldr     r0,=OAM_50 			;OAM pointer 
@@StoreOAM2:                          
	str     r0,[r4,18h]                             
	ldr     r0,=CurrSpriteData                            
	mov     r1,0h                                   
	strb    r1,[r0,1Ch]                             
	strh    r1,[r0,16h]                             
	add     r0,24h                                  
	mov     r1,1Ah                                  
	strb    r1,[r0]                                 
	b       @@Return                                
.pool
@@CheckIf4:                               
	ldrh    r0,[r4,16h]                             
	cmp     r0,4h                                   
	bne     @@Return                               
	ldrb    r0,[r4,1Ch]                             
	cmp     r0,1h                                   
	bne     @@Check                                
	mov     r0,1h                                   
	bl      SpawnKillBlockAI                                
	b       @@Return                                
@@Check:
	cmp     r0,4h                                   
	bne     @@Return                                
	ldrh    r0,[r4,2h]			;sprite Y                              
	add     r0,24h                                  
	ldrh    r1,[r4,4h]			;sprite X                              
	mov     r2,36h
	ldr		r3,=SetParticalEffect + 1
	bl      WrapperR3
@@Return:                                
	pop     r4                                      
	pop     r0                                      
	bx      r0                                      

KillBlockAI:	
	push    r14 					;pose 1Ah, moves blocks down and kills when offscreen                                    
	ldr     r2,=CurrSpriteData                            
	ldrh    r0,[r2,2h]                              
	add     r0,11h                                  
	strh    r0,[r2,2h] 				;new Y pos                             
	lsl     r0,r0,10h                               
	ldr     r1,=4FF0000h                            
	cmp     r0,r1                                   
	bls     @@Return                                
	ldrh    r1,[r2]				;status                                 
	mov     r0,2h                                   
	and     r0,r1                                   
	lsl     r0,r0,10h                               
	lsr     r0,r0,10h                               
	cmp     r0,0h					;checks if offscreen                                   
	bne     @@Return                                
	strh    r0,[r2]				;kills block sprite
@@Return:                                 
	pop     r0			                                      
	bx      r0                                      
.pool

SoundAI:				
	push    r6,r14							;used to play water and speed sounds as well as splash effects
	ldr		r6,=PlaySound + 1
	ldr     r0,=SerrisYPosition              ;not pose dependent. Seems to run every frame Serris is alive.      
	ldr     r3,=CurrSpriteData                            
	ldrh    r0,[r0]                                 
	ldrh    r1,[r3,2h]						;sprite Y                              
	cmp     r0,r1                                   
	bls     @@CheckY                                
	mov     r2,0B0h                                 
	lsl     r2,r2,2h                                
	cmp     r0,r2                                   
	bls     @@Return                                
	cmp     r1,r2                                   
	bhi     @@Return                                
	ldrh    r1,[r3]                                 
	mov     r0,4h                                   
	and     r0,r1                                   
	cmp     r0,0h                                   
	bne     @@SkipPlaySound                                
	ldrh    r0,[r3,2h]                              
	add     r0,40h                                  
	ldrh    r1,[r3,4h]                              
	mov     r2,2h
	ldr		r3,=SetParticalEffect + 1
	bl      WrapperR3                                
	ldr     r0,=SerrisBoostTimer 					                           
	ldrh    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@PlaySound                                
	ldr     r0,=1BBh						;must be speedboosting sound                                 
	bl      WrapperR6                                
	b       @@SkipPlaySound                                
.pool
@@PlaySound:                                
	ldr     r0,=1BBh  						;splash                              
	bl      WrapperR6  
@@SkipPlaySound:                              
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	ldr     r0,=0F7FFh                              
	and     r0,r1                                   
	b       @@Store                                
.pool
@@CheckY:                               
	cmp     r0,r1                                   
	bcs     @@Return                                
	ldr     r2,=2BFh                                
	cmp     r0,r2                                   
	bhi     @@Return                                
	cmp     r1,r2                                   
	bls     @@Return                                
	ldrh    r1,[r3]                                 
	mov     r0,4h                                   
	and     r0,r1                                   
	cmp     r0,0h                                   
	bne     @@SkipSoundPlay                               
	ldrh    r0,[r3,2h]                              
	add     r0,20h                                  
	ldrh    r1,[r3,4h]                              
	mov     r2,2h
	ldr		r3,=SetParticalEffect + 1
	bl      WrapperR3                               
	ldr     r0,=SerrisBoostTimer                           
	ldrh    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@PlaySound2                                
	ldr		r0,=1BBh					;speed splash                                                                 
	bl      WrapperR6                                
	b       @@SkipSoundPlay                               
.pool 
@@PlaySound2:                           
	ldr     r0,=1BBh					;normal splash                                
	bl      WrapperR6
@@SkipSoundPlay:                               
	ldr     r2,=CurrSpriteData                            
	ldrh    r1,[r2]                                 
	mov     r3,80h                                  
	lsl     r3,r3,4h                                
	mov     r0,r3                                   
	orr     r0,r1
@@Store:                                   
	strh    r0,[r2]
@@Return:
	pop		r6
	pop     r0                                      
	bx      r0                                      
.pool

CheckSpawnAmmo:
	push	r6,r14
	add		sp,-8h
	mov		r6,r0
	ldr		r1,=SamusEquipment
	ldrh	r0,[r1,8h]					;checks for missiles being 0
	cmp		r0,0h
	bne		@@Return
	ldrb	r0,[r1,0Ah]					;checks for supers being 0
	cmp		r0,0h
	bne		@@Return
	mov		r1,r6
	add		r1,36h						;timer
	ldrb	r0,[r1]
	cmp		r0,0h
	beq		@@Set
	sub		r0,1h
	strb	r0,[r1]
	cmp		r0,0h
	bne		@@Return
	ldr		r3,=GetDropType + 1
	bl		WrapperR3
	cmp		r0,0h
	beq		@@Return
	mov		r1,0h
	mov		r2,0h
	ldrh	r3,[r6,4h]
	str		r3,[sp]
	str		r2,[sp,4h]
	ldrh	r3,[r6,2h]
	ldr		r6,=SpawnNewPrimarySprite + 1
	bl		WrapperR6
	b		@@Return
.pool	
@@Set:
	mov		r0,96h					;2.5 second timer
	strb	r0,[r1]
@@Return:
	add		sp,8h
	pop		r6
	pop		r0
	bx		r0
	
	
SerrisSpriteAI: 
	push    r4,r6,r14
	ldr		r6,=PlaySound + 1	
	ldr     r2,=CurrSpriteData      		                     
	mov     r0,r2                                   
	add     r0,2Bh 						;stun timer                                
	ldrb    r1,[r0]                                 
	mov     r0,7Fh                                  
	and     r0,r1                                   
	cmp     r0,10h                                  
	bne     @@Branch1                               
	ldrh    r0,[r2,14h]                             
	cmp     r0,0h                                   
	beq     @@Branch1                                
	mov     r1,r2                                   
	add     r1,2Dh                                  
	mov     r0,1Eh                                  
	strb    r0,[r1]                                 
	add     r2,32h                                  
	ldrb    r1,[r2]                                 
	mov     r0,40h                                  
	orr     r0,r1                                   
	strb    r0,[r2]                                 
	mov     r0,0ADh                          					;seris hurt                              
	bl      WrapperR6			
@@Branch1:                              
	ldr     r4,=CurrSpriteData                            
	mov     r1,r4
	add		r1,24h
	ldrb	r0,[r1]
	add		r1,9h				;2Dh
	cmp		r0,0h
	bne		@@NoReset
	strb	r0,[r1]				;sets 2Dh to 0 when spawning because it is not auto reset
@@NoReset:                                 
	ldrb    r0,[r1]                                 
	cmp     r0,0h                                   
	beq     @@Branch2                                
	sub     r0,1h                                   
	strb    r0,[r1]                                 
	lsl     r0,r0,18h                               
	cmp     r0,0h                                   
	beq     @@Branch3                                
	b       @@Return                                
@@Branch3:
	ldr     r1,=SerrisBoostTimer                            
	mov     r2,0E1h                                 
	lsl     r2,r2,1h                                
	mov     r0,r2                                   
	strh    r0,[r1]                                 
	bl      OAMSwitchAI                                
@@Branch2:
	ldrh    r0,[r4,14h]                             
	cmp     r0,0h                                   
	bne     @@Branch4                               
	mov     r1,r4                                   
	add     r1,24h                                  
	ldrb    r0,[r1]                                 
	cmp     r0,0h                                   
	beq     @@Branch5                               
	cmp     r0,62h						;modified to check for ZM death pose                                
	beq     @@PlaySound                               
	b       @@Branch5 
@@PlaySound:                               
	mov     r0,47h                                  
	strb    r0,[r1]                                 
	mov		r0,0ADh						;death roar                               
	bl      WrapperR6                               
	b       @@Branch5                               
.pool   
@@Branch4:                           
	ldr     r4,=CurrSpriteData                           
	mov     r1,r4                                   
	add     r1,24h                                  
	ldrb    r0,[r1]				;pose                                 
	cmp     r0,52h                                  
	bne     @@SkipThings                                
	mov     r0,2h       			;pose = 2                            
	strb    r0,[r1]                                 
	ldr     r1,=SerrisBoostTimer                            
	mov     r0,78h                                  
	strh    r0,[r1]                                 
	bl      OAMSwitchAI                               
	mov		r0,0ADh 				;Serris roar                               
	bl      WrapperR6
@@SkipThings:                               
	ldr     r0,=SerrisBoostTimer                            
	ldrh    r2,[r0]                                 
	cmp     r2,0h                                   
	beq     @@Branch6                               
	ldr     r2,=Bit8Counter 	                          
	ldrb    r1,[r2]                                 
	mov     r0,8h                                   
	and     r0,r1                                   
	cmp     r0,0h                                   
	beq     @@Branch7                                
	mov     r1,r4                                   
	add     r1,20h                                  
	mov     r0,4h                                   
	b       @@Branch8                               
.pool       
@@Branch7:                      
	mov     r1,r4                                   
	add     r1,20h                                  
	mov     r0,5h 
@@Branch8:                                
	strb    r0,[r1]                                 
	ldrb    r1,[r2]                                 
	mov     r0,0Fh                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	bne     @@Branch9                                
	ldr     r0,=CurrSpriteData                           
	add     r0,24h      			;pose                            
	ldrb    r0,[r0]                                 
	cmp     r0,8h                                   
	beq     @@Branch9                              
	mov		r0,8Dh 				;speed sound                               
	bl      WrapperR6                               
@@Branch9:
	ldr     r1,=SerrisBoostTimer                            
	ldrh    r0,[r1]                                 
	sub     r0,1h                                   
	strh    r0,[r1]                                 
	lsl     r0,r0,10h                               
	cmp     r0,0h                                   
	bne     @@Branch11                               
	ldr     r0,=CurrSpriteData                           
	add     r0,32h 			                                 
	ldrb    r2,[r0]                                 
	mov     r1,0BFh                                 
	and     r1,r2                                   
	strb    r1,[r0]                                 
	bl      OAMSwitchAI                               
	b       @@Branch11                               
.pool
@@Branch6:
	mov     r0,r4                                   
	add     r0,20h                                  
	strb    r2,[r0]                                 
@@Branch11:
	ldr     r2,=CurrSpriteData                            
	ldrh    r0,[r2]                                 
	ldr     r1,=804h                                
	and     r1,r0                                   
	mov     r0,80h                                  
	lsl     r0,r0,4h                                
	cmp     r1,r0                                   
	bne     @@Branch5                                
	ldr     r0,=Bit8Counter                            
	ldrb    r1,[r0]                                 
	mov     r0,1Fh                                  
	and     r0,r1                                   
	cmp     r0,0h                                   
	bne     @@Branch5                                
	mov     r0,r2                                   
	add     r0,24h                                  
	ldrb    r0,[r0]                                 
	cmp     r0,8h                                   
	beq     @@Branch5                                
	ldr     r0,=SerrisBoostTimer                            
	ldrh    r0,[r0]                                 
	cmp     r0,0h                                   
	beq     @@PlaySound2                                
	;ldr     r0,=1BBh 				;splash?                               
	;bl      PlaySound                               
	b       @@Branch5                                
.pool
@@PlaySound2:                            
		nop							;used to be annoying sound  
@@Branch5:                              
	ldr     r0,=SerrisYPosition                           
	ldr     r1,=CurrSpriteData                            
	ldrh    r2,[r1,2h]                              
	strh    r2,[r0]                                 
	add     r1,24h  				;pose                                
	ldrb    r0,[r1]                                 
	cmp     r0,56h                                  
	bls     @@JumpGet                                
	b       @@SoundPhase 
@@JumpGet:                               
	lsl     r0,r0,2h                                
	ldr     r1,=@@JumpTable                          
	add     r0,r0,r1                                
	ldr     r0,[r0]                                 
	mov     r15,r0                                  
.pool                              
@@JumpTable:
	.word @@Spawn,@@Set53,@@RiseOscillate,@@SoundPhase                              
	.word @@SoundPhase,@@SoundPhase,@@SoundPhase,@@SoundPhase                         
	.word @@Underground,@@SoundPhase,@@SoundPhase,@@SoundPhase                            
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase                              
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase                             
	.word @@SoundPhase,@@SoundPhase,@@Dive,@@SoundPhase                             
	.word @@RiseCharge,@@SoundPhase,@@RiseArc,@@SoundPhase                            
	.word @@RiseArc2,@@SoundPhase,@@SoundPhase,@@SoundPhase                              
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase                            
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase                              
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase                                         
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase
	.word @@Oscillate,@@SoundPhase,@@Charge,@@SoundPhase
	.word @@Arc,@@SoundPhase,@@Rise,@@SoundPhase
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase
	.word @@SoundPhase,@@SoundPhase,@@SoundPhase,@@Killed                             
	.word @@Dying,@@NearlyDead,@@Distort,@@SoundPhase
	.word @@SoundPhase ,@@SoundPhase,@@SoundPhase,@@SoundPhase
	.word @@SoundPhase,@@CheckEmerge,@@SoundPhase,@@Set54                             
	.word @@Set51,@@SpawnBlocks,@@CheckStart 

@@Spawn:	
	bl      SpawnAI                                
	b       @@SoundPhase 
@@Killed:                               
	bl      FirstDeathPose                               
	b       @@SoundPhase
@@Dying:                                
	bl      DyingAI                                
	b       @@SoundPhase
@@NearlyDead:                                
	bl      FinalDeathPose
@@Distort:                                
	bl      DistortionAI                                
	b       @@SoundPhase
@@SpawnBlocks:                                
	bl      SpawnBlockAI                                
	b       @@SoundPhase
@@CheckStart:                                
	bl      PreCheckStartFightAI                                
	b       @@SoundPhase
@@Set53:                                
	bl      SetPose53AI                                
	b       @@SoundPhase
@@Set54:                                
	bl      SetPose54AI                                
	b       @@SoundPhase
@@Set51:                                
	bl      SetPose51AI                                
	b       @@SoundPhase
@@CheckEmerge:                                
	bl      CheckSerrisEmergeAI                                
	b       @@SoundPhase
@@Underground:                                
	bl      UnderGroundAI                                
	b       @@SoundPhase
@@Dive:                                
	bl      DiveUnderAI                                
	b       @@SoundPhase
@@RiseOscillate:                                
	bl      RiseB4OscillateAI                                
	b       @@SoundPhase
@@RiseCharge:                                
	bl      RiseB4StraightChargeAI                                
	b       @@SoundPhase
@@RiseArc:                                
	bl      MiddleRisingArcAI                                
	b       @@SoundPhase
@@RiseArc2:                                
	bl      SideRiseB4Arc                                
	b       @@SoundPhase
@@Oscillate:                                
	bl      OscillateAI                               
	b       @@SoundPhase
@@Charge:                                
	bl      StraightChargeAI                                
	b       @@SoundPhase
@@Arc:                                
	bl      JumpArcAI                               
	b       @@SoundPhase 
@@Rise:                               
	bl      RisingAI                                
@@SoundPhase:
	bl      SoundAI                                
	bl      PhaseShiftAI                                
	ldr     r0,=SerrisBoostTimer                            
	ldrh    r0,[r0]                                 
	cmp     r0,0h                                   
	bne     @@Branch10                                
	b       @@Return   
@@Branch10:                             
	ldr     r2,=SerrisYPosition                            
	ldr     r0,=CurrSpriteData                            
	ldrh    r1,[r0,2h]                              
	strh    r1,[r2]                                 
	add     r0,24h                                  
	ldrb    r0,[r0]                                 
	sub     r0,2h                                   
	cmp     r0,3Ch                                  
	bls     @@GetJump                                
	b       @@Sound
@@GetJump:                               
	lsl     r0,r0,2h                                
	ldr     r1,=@@JumpTable5                            
	add     r0,r0,r1                                
	ldr     r0,[r0]                                 
	mov     r15,r0                                  
.pool
@@JumpTable5: 
	.word @@RiseOscillate2,@@Sound,@@Sound,@@Sound                             
	.word @@Sound,@@Sound,@@Underground2,@@Sound                             
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Dive2,@@Sound,@@RiseCharge2,@@Sound                              
	.word @@RiseArcA,@@Sound,@@RiseArcB,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Sound,@@Sound
	.word @@Sound,@@Sound,@@Oscillate2,@@Sound                               
	.word @@Charge2,@@Sound,@@Arc2,@@Sound
	.word @@Rise2
@@Underground2:	
	bl      UnderGroundAI                                
	b       @@Sound 
@@Dive2:                              
	bl      DiveUnderAI                                
	b       @@Sound 
@@RiseOscillate2:                            
	bl      RiseB4OscillateAI                                
	b       @@Sound
@@RiseCharge2:                                
	bl      RiseB4StraightChargeAI                                
	b       @@Sound 
@@RiseArcA:                               
	bl      MiddleRisingArcAI                               
	b       @@Sound 
@@RiseArcB:                               
	bl      SideRiseB4Arc                              
	b       @@Sound
@@Oscillate2:                                
	bl      OscillateAI                                
	b       @@Sound
@@Charge2:                                
	bl      StraightChargeAI                                
	b       @@Sound
@@Arc2:                                
	bl      JumpArcAI                                
	b       @@Sound
@@Rise2:                                
	bl      RisingAI                                
@@Sound:
	bl      SoundAI
@@Return:                                
	pop     r4,r6                                      
	pop     r0                                      
	bx      r0

SegmentMainAI:
.notice "SerrisSegment AI"
.notice tohex(.)
	push    r14                               
	ldr     r3,=CurrSpriteData                      
	mov     r0,r3                             
	add     r0,23h                            
	ldrb    r1,[r0]                           
	ldr     r2,=SpriteData                      
	lsl     r0,r1,3h                          
	sub     r0,r0,r1                          
	lsl     r0,r0,3h                          
	add     r1,r0,r2                          
	mov     r0,r1                             
	add     r0,2Dh                            
	ldrb    r0,[r0]                           
	mov     r2,r3                             
	cmp     r0,0h                             
	beq     @@CheckPose                          
	b       @@Return
@@CheckPose:                          
	mov     r0,r1                             
	add     r0,24h                            
	ldrb    r0,[r0]					;pose                           
	cmp     r0,48h                            
	bne     @@Branch1                          
	mov     r1,r2                             
	add     r1,24h                            
	ldrb    r0,[r1]                           
	cmp     r0,46h                            
	bhi     @@CheckPose2                          
	mov     r0,47h                            
	strb    r0,[r1]                           
	b       @@CheckPose2                          
.pool
@@Branch1:
	ldr     r0,=SerrisBoostTimer                      
	ldrh    r1,[r0]                           
	cmp     r1,0h                             
	beq     @@Store                         
	ldr     r0,=Bit8Counter                      
	ldrb    r1,[r0]                           
	mov     r0,4h                             
	and     r0,r1                             
	cmp     r0,0h                             
	beq     @@Store2                          
	mov     r1,r2                             
	add     r1,20h                            
	mov     r0,5h					;sprite palette                             
	strb    r0,[r1]                           
	b       @@CheckPose2                          
.pool 
@@Store2:                        
	mov     r1,r2                             
	add     r1,20h				;sprite palette                            
	mov     r0,6h                             
	strb    r0,[r1]                           
	b       @@CheckPose2
@@Store:                          
	mov     r0,r2                             
	add     r0,20h                            
	strb    r1,[r0]				;sprite palette
@@CheckPose2:                           
	mov     r0,r2                             
	add     r0,24h                            
	ldrb    r0,[r0]					;pose                           
	cmp     r0,55h                            
	bls     @@GetJump                          
	b       @@Next
@@GetJump:                          
	lsl     r0,r0,2h                          
	ldr     r1,=@@JumpTable                     
	add     r0,r0,r1                          
	ldr     r0,[r0]                           
	mov     r15,r0                            
.pool
@@JumpTable:
	.word @@Spawn,@@Timer,@@RiseOscillate,@@Next                         
	.word @@Next,@@Next,@@Next,@@Next                       
	.word @@Underground,@@Next,@@Next,@@Next                       
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Dive,@@Next                       
	.word @@RiseCharge,@@Next,@@RiseArc,@@Next                       
	.word @@RiseArc2,@@Next,@@Next,@@Next                       
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Next	
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Oscillate,@@Next,@@Charge,@@Next                        
	.word @@Arc,@@Next,@@Rise,@@Next                         
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@Next,@@Next,@@Pose47                        
	.word @@Dying,@@Next,@@Kill,@@Next                         
	.word @@Next,@@Next,@@Next,@@Next
	.word @@Next,@@CheckEmerge,@@Next,@@Pose54                        
	.word @@Pose51,@@Pose1
@@Spawn:	
	bl      SegmentSpawnAI                          
	b       @@Next
@@Pose1:                          
	bl      SetPose1                          
	b       @@Next 
@@Timer:                         
	bl      DecreaseTimerAI                          
	b       @@Next 
@@Pose54:                         
	bl      SetPose54AI                         
	b       @@Next
@@Pose51:                          
	bl      SetPose51AI                         
	b       @@Next
@@Pose47:                          
	bl      Pose47AI                          
	b       @@Next
@@Dying:                          
	bl      SegmentsDyingAI                          
	b       @@Next
@@Kill:                          
	bl      KillSegmentAI                         
	b       @@Next
@@CheckEmerge:                          
	bl      CheckSerrisEmergeAI                          
	b       @@Next
@@Underground:                          
	bl      UnderGroundAI                          
	b       @@Next
@@Dive:                          
	bl      DiveUnderAI                          
	b       @@Next
@@RiseOscillate:                          
	bl      RiseB4OscillateAI                          
	b       @@Next
@@RiseCharge:                        
	bl      RiseB4StraightChargeAI                         
	b       @@Next
@@RiseArc:                          
	bl      MiddleRisingArcAI                          
	b       @@Next
@@RiseArc2:                         
	bl      SideRiseB4Arc                          
	b       @@Next
@@Oscillate:                          
	bl      OscillateAI                          
	b       @@Next
@@Charge:                          
	bl      StraightChargeAI                          
	b       @@Next
@@Arc:                          
	bl      JumpArcAI                         
	b       @@Next
@@Rise:                          
	bl		RisingAI
@@Next:                          
	ldr     r0,=SerrisBoostTimer                      
	ldrh    r0,[r0]                           
	cmp     r0,0h                             
	bne     @@PoseCheck                          
	b       @@Return
@@PoseCheck:                           
	ldr     r0,=CurrSpriteData                      
	add     r0,24h                            
	ldrb    r0,[r0]                           
	sub     r0,2h                             
	cmp     r0,4Fh                            
	bls     @@JumpGet                          
	b       @@Return
@@JumpGet:                          
	lsl     r0,r0,2h                          
	ldr     r1,=@@JumpTable2                      
	add     r0,r0,r1                          
	ldr     r0,[r0]                           
	mov     r15,r0                            
.pool
@@JumpTable2:
	.word @@RiseOscillate2,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Underground2,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Dive2,@@Return,@@RiseCharge2,@@Return                        
	.word @@RiseArcA,@@Return,@@RiseArcB,@@Return                         
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Oscillate2,@@Return                     
	.word @@Charge2,@@Return,@@Arc2,@@Return                         
	.word @@Rise2,@@Return,@@Return,@@Return                        
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@Return
	.word @@Return,@@Return,@@Return,@@CheckEmerge2
@@CheckEmerge2:                        
	bl      CheckSerrisEmergeAI                         
	b       @@Return
@@Underground2:                          
	bl      UnderGroundAI                          
	b       @@Return
@@Dive2:                          
	bl      DiveUnderAI                          
	b       @@Return
@@RiseOscillate2:                          
	bl      RiseB4OscillateAI                          
	b       @@Return 
@@RiseCharge2:                         
	bl      RiseB4StraightChargeAI                          
	b       @@Return
@@RiseArcA:                          
	bl      MiddleRisingArcAI                          
	b       @@Return 
@@RiseArcB:                         
	bl      SideRiseB4Arc                          
	b       @@Return
@@Oscillate2:                          
	bl      OscillateAI                          
	b       @@Return
@@Charge2:                          
	bl      StraightChargeAI                          
	b       @@Return
@@Arc2:                         
	bl      JumpArcAI                          
	b       @@Return
@@Rise2:                          
	bl      RisingAI
@@Return: 
	ldr		r0,=CurrSpriteData
	ldrb	r1,[r0,1Eh]
	cmp		r1,8h   				;tail
	bne		@@Leave
	bl		CheckSpawnAmmo
.pool	
@@Leave:
	pop r0                                
	bx	r0

SerrisBlockMainAI:
.notice "Serris Block AI"
.notice tohex(.)
	push    r14                             
	ldr     r0,=CurrSpriteData          
	mov     r2,r0                       
	add     r2,26h 					;prevents Samus interaction with sprite                    
	mov     r1,1h                       
	strb    r1,[r2]                     
	add     r0,24h                      
	ldrb    r0,[r0]					;pose                     
	cmp     r0,2h                       
	beq     @@CheckBreak                    
	cmp     r0,2h                       
	bgt     @@CheckPoses                    
	cmp     r0,0h                       
	beq     @@Spawn                    
	b       @@Return                    
.pool
@@CheckPoses:                  
	cmp     r0,18h                      
	beq     @@Break
	cmp     r0,1Ah                      
	beq     @@Kill                    
	b       @@Return 
@@Spawn:                   
	bl      SerrisBlockSpawnAI                    
	b       @@Return
@@CheckBreak:                    
	bl      BreakCheckAI                    
	b       @@Return 
@@Break:                   
	bl      BreakingAI                    
	b       @@Return 
@@Kill:                   
	bl      KillBlockAI
@@Return:                    
	pop     r0                          
	bx      r0                          	

