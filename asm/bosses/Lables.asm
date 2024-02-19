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
.definelabel SamusPhysics,0x3001588
.definelabel DoorUnlockTimer,0x300007B
.definelabel SubSpriteData,0x300070C
.definelabel FrameCounter8Bit,0x3000C77
.definelabel BG1XPosition,0x30013B8
.definelabel CurrentMusicTrack,0x3001D1C
.definelabel SpriteSlot0,0x30001AC
.definelabel FrameCounter,0x3000C77
.definelabel SamusOnTopOfBackgroundsFlag, 0x300002B
.definelabel BackupOfIORegisters, 0x3000088  ;3000070
.definelabel CurrentAffectingClip, 0x30000DC
.definelabel ProjectileData,0x3000A2C
.definelabel BG0Movement, 0x30054F4
.definelabel PreviousVerticalCollisionCheck, 0x30007F0  ;30007A4
.definelabel PreviousSideCollisionCheck, 0x30007F1  ;30007A5
.definelabel SpriteDrawOrder, 0x30007F3 ;30007A7
.definelabel BossWork,0x300080C
.definelabel saxpalette, 0x3000822  ;3004D90
.definelabel OAMData, 0x3000E7C
.definelabel NextOAMSlot, 0x3001382
.definelabel BG1XPos,0x30013B8      ;3001228
.definelabel BG1YPos,0x30013BA
.definelabel Equipment, 0x3001530   ;3001310
.definelabel SAXData, 0x3001670    ;3001458
.definelabel MusicInfo, 0x30001D00
.definelabel Bit16Counter,0x3000002
.definelabel CurrClipdataEffectingAction,0x3000079
.definelabel LockDoors,0x0300007B
.definelabel RoomEffectYPos,0x300006C
.definelabel SpriteData,0x30001AC							
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
.definelabel SpriteDataSlot0,0x30001AC
.definelabel FloorClipValue,0x30007F0
.definelabel ClipValue,0x30007F1
.definelabel YakuzaPalCounter,0x300070c
.definelabel StartSongFlag,0x300070c + 1
.definelabel GrabbedFlag,0x300070c + 2
.definelabel EscapeThreshold,0x300070c + 3
.definelabel EscapeValue,0x300070c + 4
.definelabel Phase1Flag,0x300070c + 5
.definelabel ChangedInput,0x3001380
.definelabel ScrewAttackFlag,0x3001528
.definelabel SamusHitboxes,0x30015F6
.definelabel DMA3SourceAddress,0x40000D4
.definelabel CurrentClipdataAffectingAction, 0x3000079      ;3000053
.definelabel IoRegistersBackup, 0x3000088                   ;3000070
.definelabel SubSpriteData1, 0x300070C                      ;3000784
.definelabel PreviousCollisionCheck, 0x30007F1              ;30007A5
.definelabel ArmCannonY, 0x3000BEC                          ;3000B80

.definelabel InitializeSecondarySprite,0x800E258
.definelabel DamageSamus,0x800E634
.definelabel CheckSamusTouchSprite,0x800E6F8
.definelabel CheckHitFloor,0x800F47C
.definelabel CheckClip,0x800F688
.definelabel SetGFXEffect,0x80540EC
.definelabel VerticalScreenShake,0x8055344
.definelabel HorizontalScreenShake,0x8055378
.definelabel PlaySound,0x8002A18					
.definelabel SpawnNewPrimarySprite,0x800E31C
.definelabel CheckEndSpriteAnimation,0x800FBC8
.definelabel GetDropType,0x8010EEC
.definelabel ShakeScreenHori,0x8055378
.definelabel ShakeScreenVert,0x8055344								
.definelabel SetParticalEffect,0x80540EC
.definelabel Division,0x808AC34
.definelabel CircularMoveTable,0x808C71C 
.definelabel StopSound, 0x8002A28
.definelabel SoundPlayNotAlreadyPlaying, 0x8002b20
.definelabel SpriteUtilChooseRandomXFlip, 0x800f80c     ;11498
.definelabel SpriteUtilMakeSpriteFaceSamusXFlip, 800F8B0h
.definelabel SpriteUtilCheckEndCurrentSpriteAnim, 0x800fbc8 ;11934
.definelabel CheckNearEndAnimation, 0x800FC00   ;1196C
.definelabel SpriteUtilUpdateFreezeTimer, 0x800ffe8  ;11E44
.definelabel SpawnNewSecondarySprite, 0x800E258
.definelabel SpriteUtilCheckVerticalCollisionAtPosition, 0x800F360  ;11058
.definelabel SpriteUtilCheckVerticalCollisionAtPositionSlopes, 0x800F47C    ;11174
.definelabel SpriteUtilCheckCollisionAtPosition, 0x800F688  ;11390
.definelabel unk_f594, 0x800f594    ;1129c
.definelabel SpriteUtilMakeSpriteFaceSamusDirection, 0x800F8E0
.definelabel unk_f978, 0x800f978    ;11604
.definelabel SpriteUtilCheckCrouchingOrMorphed, 0x801036c
.definelabel SpriteUtilCountSecondarySpritesWithCurrentSpriteRAMSlot,0x8010738	
.definelabel DeathRoutine, 0x8011084
.definelabel ChangeBlocks, 0x8057E7C
.definelabel EventFunctions, 0x80608BC
.definelabel METROID4USA_AMTE_TABLE,0x808f2c0
.definelabel EnemyFallSpeed, 0x82B0D04
.definelabel SpawnSecondarySprite,0x800E258
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
.definelabel unk_3a6c, 0x8003A6C                                    ;80036C4
.definelabel unk_42bc, 0x80042BC                                    ;8003B1C
.definelabel SpriteSpawnSecondary, 0x800E258                        ;800FAE0
.definelabel SpriteUtilChooseRandomXDirection, 0x800f844            ;80114d0
.definelabel SpriteUtilMakeSpriteFaceAwayFromSamusDirection, 0x800F944  ;80115D0
.definelabel SpriteUtilMakeSpriteFaceSamusRotation, 0x800FA78       ;8011734
.definelabel SpriteUtilCheckEndSubSprite1Anim, 0x800FCD0            ;8011a3c
.definelabel SpriteUtilCheckNearEndSubSprite1Anim, 0x800FD08        ;8011a74
.definelabel SpriteUtilCheckSamusNearSpriteLeftRight, 0x800FDE0     ;8011B24
.definelabel SpriteUtilFindPrimary, 0x80107F8                       ;80128F8
.definelabel SpriteUtilMoveSpriteTowardsSamus, 0x8010944            ;80131E8
.definelabel SpriteUtilSpriteDeath, 0x8011084
.definelabel SpriteUtilUpdateSubSprite1Anim, 0x8011330              ;8035ACC
.definelabel SpriteUtilSyncCurrentSpritePositionWithSubSprite1Position, 0x801136C   ;8035B08
.definelabel ParticleSet, 0x80540EC                         ;80730E4
.definelabel ScreenShakeStartVertical, 0x8055344            ;806258C
.definelabel ScreenShakeStartHorizontal, 0x8055378          ;80625C0
.definelabel ClipdataProcess, 0x8057e7c                     ;8068bc0