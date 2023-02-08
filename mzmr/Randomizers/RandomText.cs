using System;
using mzmr.Utility;
using System.Collections.Generic;

namespace mzmr.Randomizers
{
    class RandomText : RandomAspect
    {
        public RandomText(Rom rom, Settings settings, Random rng) : base(rom, settings, rng)
        {

        }

        #region String Lists
        static private readonly string[] storyList =
{
            "There once was a man from Peru. He\ndreamed he was eating his shoe. He\nawoke with a fright in the middle of the\nnight to find that his dream had come\ntrue.\n            -Samus Aran-",
            "We're in the deepest trenches of\ngaming, producing games for gamers.\nHere is where stuff gets cross-\npollinated. Strange, difficult.\nAverage metroid fans don't play hacks,\nthey have other things to do, other\ngames, other hobbies. We are here for \na reason.    -Ing-Ing-",
            "Greetings, my dearest gamer, for it is\nmy pleasure to pass on to you the\nnotification which states the undoubted\nfact that the 1994 Super Nintendo\nEntertainment Console game Super\nMetroid, is a superior work to the likes\nof the 2004 Game Boy Advance portable\nvideo game, Metroid: Zero Mission.\n               -Jiffy-",
            "We meet again, my companion. My ongoing\nrespect for you allows me to, once\nagain, notify you, as I always do, that\nyou are very much an individual of\nutmost excellence.\n              -Interdpth-",
            "Rise and shine my aquaintance, for it\ngives me feelings of happiness to\nforward the derective, as I do, that the\n1991 Game Boy portable video game,\nMetroid II: Return of Samus, is an\nartistically and technically superior work\nto all subsequent entries in Nintendo's\nMetroid franchise of electronic computer\nentertainment.      -Whalerynth-",
            "A Space Dragon and its metallic\nrecreation decided to lay waste to\nmy poor Zebes. Their motives are unclear\nbut I do not care what they are. I am\nbored. So I will hunt these heatens &\nbrutally kill them to alleviate my boredom.\nThe metal one is my main target, but\nkilling both would be radical.\n         -Samus Aran-",
            "Now this is a story all about how my life\ngot flipped-turned upside down. I'd like\nto take a minute, just sit right there,\nI'll tell you how I became the prince of\na town called Bel Air.",
            "Prepare for trouble and make it double!\nTo protect the world from devastation!\nTo unite all pirates within our nation!\nTo denounce the evils of truth & love!\nTo extend our reach to Zebes above!\n       Kraid!            Ridley!\nThe pirates blast off at the speed of\nlight! Surrender now, or prepare to\nfight!",
            "For time and the world do not stand\nstill. Change...is the law of life. And\nthose who look only into the past or the\npresent, are certain to miss the future.\nI said 'are certain to miss the future!'",
            "It is this fate, I solemnly assure you,\nthat I dread for you, when the time\ncomes that you make your reckoning,\nand realize that there is no longer\nanything that can be done. May you\nnever find yourselves, men of Zebes,\nin such a position! Yet in any case, it\nwere better to die ten thousand deaths\nthan to let Zebes fall to the Hunter.",
            "Spooky scary skeletons\nSend shivers down your spine\nShrieking skulls will shock your soul\nSeal your doom tonight\nSpooky scary skeletons\nSpeak with such a screech\nYou'll shake and shudder in surprise\nWhen you hear these zombies shriek",
            "Hi, I'm Jiffy, President and CEO of\nJiffy's Wacky Waving Inflatable Arm\nFlailing Tube Man Emporium! Thanks to\na shipping error I am now currently\noverstocked on wacky waving inflatable\narm flailing tube men, & I am passing\nthe savings to you! So come on down\nto Jiffy's Wacky Waving Inflatable Arm \nFlailing Tube Man Emporium!",
            "Polio ruined my childhood and now I\nhave to shoot pirates to make myself\nfeel better about being stuck in this\nwalking iron lung.\n                    -Samso Arma-",
            "If you need code, ask Biospark! He will\nlove to make any code you can dream\nof because he's that nice and great.\nAlso, be sure to ask him about when\nFreedom, MAGE, and the MZMR will be\nupdated!\n-Message not sponsored by Cpt.Glitch-",
            "Like and Subscribe!\n                  -ShyGuyExpress-",
            "Ask not what your country can do for\nyou, ask what you've done to Hack\nMetroid today.\n     -An Internet Chat-",
            "Zepone's answer ... Here I have called\na house once, at natural times, before\nthe wrong time leading up to a crime in\nthe lower pits. So let me tell you the\nstory of my first battle here ...\nOperation is different.\n      -Samran Aran- ",
            "We're the Mario Brothers,\nand plumbing's our game\nWe're not like the others\nwho get all the fame\nIf your sink is in trouble,\nyou can call us on the double\nWe're faster than the others,\nyou'll be hooked on the Brothers, uh!",
            "I'm writing a bunch of suggestions for\nsome text randomizer when I should be\ndoing my Physics homework.\n                    -kkzero, 2019-",
            "I AM THE SERVER' says Biospark\nspitting garbled pieces of Samus' suit\nonto the floor, delaying the Samus\nEditor by another month.",
            "Did you ever hear the tragedy of\nDarth Plagueis The Wise? I thought not.\nIt's not a story the Jedi would tell\nyou. It's a Sith legend. Darth Plagueis\nwas a Dark Lord of the Sith, so\npowerful and so wise he could use the\nForce to influence the midichlorians to\ncreate life...",
            "The dark side of the Force is a\npathway to many abilities some consider\nto be unnatural. He became so powerful\nthe only thing he was afraid of was\nlosing his power, which eventually, of\ncourse, he did. Unfortunately, he taught\nhis apprentice everything he knew, then\nhis apprentice killed him in his sleep.\nIronic.",
            "I once again find myself bored and\neager to slay a dragon. In my effotr to\nquell this desire, I found a strange\nrealm with mystical properties. I smell\n a dragon here, so I shall do what I\nmust to reach it. -Samus Aran-",
            "Hold your breath and step forward,\nto the world that just a day will\nlast, for 24 hours it has been built,\nand no more will it dream of existing.",
            "-Adam's Order-\nThe space pirates have requested\nyou to infiltrate their abandoned\nbase that a rouge AI took over! I\ndon't think we can trust them, so\nbe on the lookout for any traps!",
            "The Federation landed on this heated\nplanet. I have to be careful not to\nget burned. I will rest for a while\nin an old Federation station but\nI have to move on...\n  -Metconst contest/WhaleConner-",
            "This appears to be quite a predicament,\nSamus. Data analysis varifies that the\nplanet's inhabitants are indeed troubled\nby pollution. But the pollution itself is\nnot the main problem. Shine Sprites are\nthe source of power on planet Zebes.\nThey used to gather in great numbers\nat Tourian. But the graffiti incident has\ncaused them to flee. -F.L.U.D.D.-",
            "I wondered if this, too, was a result of\nthe power the baby gave me. Not even\na fragment... None of the baby remained\non me. I knew it to be true but still\ncouldn't help looking at my palm for a\nsign. Never again would I encounter the\nbaby. Never. The finality of it struck me\nonce again.",
            "The healthy human mind doesn't wake\nup in the morning thinking this is its\nlast day on Earth. But I think that's a\nluxury, not a curse. To know you're\nclose to the end is a kind of freedom.\nGood time to take...inventory. - Price",
            "We are now posting sketchy memes to \nthe Tetris A theme for the next 10\nhours. Fasten your seatbelts ladies\nand gentlemen.",
            "Samus meets a transgender version of\nSamus, and they have an intersex baby,\nbut then the adult Samus realizes that\nthe bedongled Samus is her biological\ntwin brother.  Then the intersex baby\nthey had grows up, goes back in time\nand impregnates themselves and gives\nbirth to the two original Samus's.\nHence infinite cycle of Samus.",
            "Actually the 2 data points we do have,\nif fit to a curve, make a lot of sense.\nAs the Quote time estimate becomes\nlarger it rapidly becomes more accurate\nto real time. 2 minutes = 2 hours, but\n20 minutes = only 3 hours. If anything\nit actually is logarithmic, so 4 hours is\nalmost exactly four hours.\n -Ozzatron on Quote58 Time Thoery",

        };
        static private readonly string[] itemDescriptions =
        {
             "This item does a thing.",
             "Be careful using this, it gives cancer.",
             "The power of a thousand suns in your\ngrasp!",
             "Shoot long-distance shots with this beam",
             "The last time this was used, the user\ngot stuck in a wall.",
             "Worthless trinket.",
             "A weapon used by the Egyptians to\ncastrate foes.",
             "Unknown device interfacing with suit.\nScans indicate no negative effects.",
             "Unknown device interfacing with suit.\nScans indicate severe faults with this\ndevice. Use caution.",
             "This equipment's previous user is said\nto be rather skilled at basketball.",
             "Never point loaded arm-cannon towards\nthe eyes.",
             "A powerful weapon capable of atomizing\nfoes and certain materials.",
             "Fancy armor piece that has no combat\npotential.",
             "This beam can freeze enemies in place.\nYou can safely stand on frozen enemies.",
             "This beam, which is made up of energy\nwaves, can pass through solid objects.",
             "Increases damage taken by all hazards.\nDecreases damage output of all weapon\nsystems.\nDecreases movement speed by a factor\nof seven.\nIncreases beauty.",
             "A poweful weapon that launches the\nuseless cartridges of the 2004 GBA\ngame, Metroid: Zero Mission.",
             "A mighty tool used by the legendary\nMario Brothers back in their plumbing\ndays.",
             "Weaponized pea shooter.\nNot recommended for combat use.",
             "Scan complete. Scans indicate this\nutility will increase coolness level\nby 12%.",
             "A once useful upgrade until it was\nnerfed by Ing-Ing.",
             "In order to gain full functionality for\nthis item, please pay $39.99.",
             "Hippity hoppity. This item is now your\nproperty.",
             "Subscribe to Captain Glitch on You-\nTube!!! :)",
             "Run until speed boost begins to break\ncertain blocks and damage enemies.",
             "Damage enemies while somersaulting.",
             "Empowering device.",
             "Failed to take screenshot.",
             "Officially endorsed by MetroidMst!",
             "This is what happens when you touch\nyourself.",
             "Find out more at www.google.com",
             "Dumpster dove for this didn't you?",
             "I bet this is one of those Chozo things",
             "Causes intense pain to user.",
             "Scans suggest this might be made of\nJelly.",
             "Sometimes you should aim.",
             "Now it's a dangerous place. Get another\nscreen for the screen.",
             "Transforms your suitcase into a thin\nair door.",
             "Hold the shoulder button to shoot water\nfrom my tank.",
             "If you hold the R-Button all the way\ndown, you can stop and shoot. You can\nthen use the Control Stick to aim in\nany direction.",
             "Press the X-Button to switch to the\nHover Nozzle.",
             "The thumbs-up sign had been used by\n the Galactic Federation for ages. Me,\nI was known for giving the thumbs-down\nduring briefing. I had my reasons, though.\nCommander Adam Malkovich was normally\ncool and not one to joke around, but\nhe would end all of his mission briefings\nby saying, 'Any objections, Lady?'\nHe was joking, but others weren't...\n At the time I felt surrounded by people\nwho treated me like a child or used kid\ngloves because I was a woman.",
             "Have you tried the ",
             "This item was better in Super Metroid.",
             "Technology like this hasn't been seen\nin thousands of years.",
             "Please ensure the Wii Remote strap is\nsecured on your wrist.",
             "This was originally meant to be the Hyper\nBeam. I decided to make it this item\ninstead.",
             "Space Pirate technology. It's quite a \nshock that it even works.",
             "If you knew what the previous owner did\nwith that, you would put it back.",
             "It just works. - Bethesda",
             "Using electromagnetic manipulation,\nthis particle beam can divert electrical\ncurrents. Though the user has little\ncontrol of where the current discharges.",
             "Increases jump height by 0.124%.",
             "This is just a bootleg version of the\n",
             "This ability's full potential is only\nunlocked on ",
             "The core feature of this ability has \nbeen delayed by six months. -343i",
             "It's time to kick ass and chew bubblegum\nand I'm all outta gum.",
             "It's dangerous to go alone! Take this!",
             "Increases survival rating by ",
             "If you're reading this, FEAR never got\nreleased.",
             "Recharges every 10 minutes and is used \nin entering the end game.",
             "Reveals the hidden form of the Carian\nStudy Hall, which connects to the divine\ntower.",
             "A ravenous shell that relentlessly seeks\nthe player in first place.",
             "Causes the user to vomit their own\ninternal organs out at would-be\npredators. Surprisingly effective.",
             "High caliber weapon with recoil so\nextreme it will leave the user immobilized\nfor a time.",
             "CLAIMED",
             "Please be sure to read the \ndocumentation before asking any\nquestions. Violators will be shot.",
             "The Chozo originally used this technology\nto power their cooking devices. ",
             "Chat, if you see this, roast the\nstreamer.",
             "Reduces intellect by a factor of two. \nZero divided by two is still zero.",
             "Gigachad of an item.",
             "This is a beam. No? It's a movement \nrelated ability. Still no? Whatever.",
             "Please refrain from using this equipment\nto cause harm to others.",
             "Refer to the README for more\ninformation.",
             "Transforms the user into a legendary\ncommunist.",
             "This item can be used to create beef\npatties from any creature.",
             "A boomer's favorite item.",
             "Made in "


        };
        static private readonly string[] areaList =
        {
            "BRINSTAR", "PHAAZE", "TEXAS",
            "I SEE YOU", "DEATH ROOM", "TALLON IV",
            "STARSHIP", "#OFFTOPIC", "TOURIAN",
            "RIDLEY", "RESEARCH ROOM", "SAVE ROOM",
            "MAP ROOM", "MEME ZONE", "DIGITAL RECREATION OF HELL",
            "ZARIDIA", "PHENDRANA'S EDGE", "HIVE TOTEM",
            "CHOZO RUINS", "CHOZODIA", "LOVE DUNGEON",
            "FBI SURVEILLANCE VAN", "FINAL DESTINATION", "It feels as if something is watching........",
            "BE GONE", "CRATERIA", "NORFAIR", 
            "ING HIVE", "BRYYO", "SHYGUY'S HOUSE",
            "TACO BELL", "GARDEN", "BALTIMORE",
            "SHAKAZON", "SALT MINE", "DRUG LAB",
            "MEXICO", "K-2L", "FINLAND",
            "EARTHVILLE", "THE VALLEY OF WORSHIP", "CYBER HELL",
            "SALAD PLAIN", "THUNDERWAVE CAVE", "A BRIDE'S PLACE FOR MANY COWS",
            "BUBBLE MOUNTAIN", "RED TOWER", "REKT SHIP",
            "PLANET SR388", "SECTOR 6 (NOX)", "DONUT PLAINS",
            "RAINBOW ROAD", "SNAKELANCERGAME'S HOUSE", "GLITCH'S HIDEOUT",
            "HOME OF THE NAG", "GREEN BRINSTAR", "NOOB BRIDGE",
            "RESET ALLEY", "WACKY ZONE", "TURN BACK!",
            "YOU'RE GOING THE WRONG WAY", "MAP ERROR","BACKROOMS",
            "brinstar, but lowercase", "ROOM 1", "HIVE ROOM",
            "TORVUS", "ENERGY CONTROLLER A", "SEEK HELP",
            "SUBSCRIBE TO GLITCH", "RNG Hell", "THE HUB",
            "LAND OF THE FREE", "INTERSTATE 10", "GAUNTLET",
            "THE END OF THE ROAD", "SECRET AREA", "DEBUG AREA",
            "MONKEY MEADOW", "FLOODED VALLEY", "AREA WITH NO NAME",
            "UNKNOWN", "THE CLUB", "SUBWAY",
            "NAIL SALON", "RINKA CITY", "RNGVILLE",
            "TOUR OF RAIN", "NETHER", "THE END",
            "WORLD 5", "ICE IS NOT HERE", "PLASMA IS HERE",
            "SOFTLOCK INCOMING", "BETWEENLANDS", "Uh Oh..."
        };
        static private readonly string[] prefixList =
        {
            "Plasma ", "Beam ", "Long ",
            "Power ", "Wave ", "Ice ",
            "Short ", "Wide ", "Omega ",
            "Fat ", "Spazer ", "Dark ",
            "Light ", "Super ", "Missile ",
            "Death ", "Wind ", "Earth ",
            "Rocket ", "Grenade ", "Frost ",
            "Christmas ", "Halloween ", "Spooky ",
            "Pumpkin ", "Egg ", "Chainsaw ",
            "Constant ", "Kitten ", "Golf Ball ",
            "Microwave ", "Tickle ", "Rinka ",
            "Metroid ", "Word ", "Zero ",
            "Magic ", "Phase ", "Phazon ",
            "Overweight ", "Waver ", "Paper ",
            "Intellectual ", "Homenag ", "Frost ",
            "Flame ", "Kinetic ", "Shock ",
            "Blazing ", "Overloading ", "Hyper ",
            "Nova ", "Penetration ", "Wee ",
            "Clorox ", "Wide ", "Lengthy ",
            "Skinny ", "Obese ", "Pi ",
            "Fungal ", "Purple ", "Blue ",
            "Green ", "Yellow ", "Orange ",
            "Brown ", "Red ", "Chocolate ",
            "Kappa ", "Varia ", "Gravity ",
            "Hot ", "Cold ", "Fake ",
            "Spear ", "Weed ", "Smartphone ",
            "Space ", "Mending ", "Communist ",
            "Unknown ", "Energy ", "Varia ",
            "Gravity ", "1-Up ", "Repulsion ",
            "Free ", "Mexican ", "Magnet ",
            "Sonic ", "Ether ", "Body ",
            "Shaped ", "Fast ", "Speed ",
            "Shiny ", "Rainbow ", "Fake ",
            "Cheeseburger ", "Calculus ", "Internet ",
            "Hi-", "Nightmare ", "Vomit ",
            "Tallywhacker ", "Shoutout ", "Powerful ",
            "DOOM ", "Potato ", "Back ",
            "Trembler ", "Gumdrop ", "Dweeb ",
            "Unusual ", "Intense ", "Fusion ",
            "Texan ", "Bushy ", "Cannon ",
            "Twitchy ", "Smiling ", "Twisted ",
            "Plunger ", "Instant ", "Embarrassing ",
            "Abstract ", "Ballyhooed ", "Churning ",
            "Double ", "Example ", "Floral ",
            "Giganticus ", "Heckin ", "Illustrious ",
            "Jam ", "Klingon ", "Laughing ",
            "Momma ", "Norwegian ", "Obstactle ",
            "Premature ", "Rapscallion ", "Toy ",
            "Ultima ", "Viscous ", "Wham ",
            "X ", "Zen ", "Toxic ",
            "Spike ", "Big Boy ", "Jiffy ",
            "Crazy ", "Monka ", "Gigachad ",
            "Fire ", "Low-", "False ",
            "Unreal ", "Broken ", "Small ",
            "Quick ", "Zealous ", "Steadfast ",
            "Double ", "Slow ", "True ",
            "Split ", "Electronic ", "Reflective ",
            "Vibro ", "Dormant ", "Awakened ",
            "PP ", "Max ", "Blessed ",
            "Mana ", "Nerfed ", ""
        };
        static private readonly string[] suffixList =
        {
            "Beam", "Shooty", "Laser",
            "Projectile", "Rock", "Missile",
            "Bullet", "Flare", "Rocket",
            "Bolt", "Shot", "Shell",
            "Ball", "Spear", "Weapon",
            "of Pain", "of Doom", "Gun",
            "Blade", "Upgrade", "Bombs",
            "Bomb", "Nuke", "Cannon",
            "Squirter", "Thrower", "Flinger",
            "Launcher", "Propeller", "Torpedo",
            "Blast", "Burst", "Package",
            "Eater", "Rinka", "of Death",
            "Tank", "Arrow", "Glave",
            "Barrage", "Rain", "Radiator",
            "Coil", "Boomer", "Splitter",
            "Core", "Power", "Trash",
            "Goop", "Sludge", "X",
            "Waste", "Buster", "Spreader",
            "Turbine", "Spikes", "Boomerang",
            "Item", "Assault Rifle", "Sniper"

        };
        static private readonly string[] equipSuffix =
        {
            "Suit", "Clone", "Tank",
            "Jump", "Armor", "Boom Boom",
            "Attack", "Hands", "Pants",
            "Ball", "Jump", "Item",
            "Booster", "Orb", "Jump Boots",
            "Boots", "Bomb", "Jetpack",
            "Grip", "Shoes", "Juice",
            "Helm", "Cheat", "Boom",
            "Backpack", "Speaker", "Radio",
            "Scanner", "Array", "Switch",
            "Computer", "Pen", "Vacuum",
            "Noodle", "Trash", "Belt",
            "Cleaner", "Evaluator", "Spike",
            "Headlight", "Visor", "Scope",
            "Reflector", "Repulser", "Hook",
            "Thruster", "Shield", "Sensor",
            "Reader", "Detector", "Greaves",
            "Breastplate", "Drainer", "Regenerator",
            "Item", "Shield", "Flower"
        };
        static private readonly string[] oneLineList =
        {
            "Additional RAM downloaded.",
            "Signal interrupted. Please try again later.",
            "Kraid map data acquired.",
            "Could not download SMILE.EXE",
            "Save Complete.",
            "Save Failed.",
            "Item removal complete.",
            "Tallon Overworld map data acquired.",
            "1.3 TB download complete. (MEME.zip)",
            "Suspicious files downloaded.",
            "Area scan complete. Fat lizard detected.",
            "Brinstar map data acquired.",
            "Norfair map data acquired.",
            "You got your fully powered suit.",
            "E-mail inbox is empty.",
            "Connection not secure. Aborting.",
            "Subscribe to Captain Glitch",
            "You downloaded your first car!",
            "Tourian map data acquired.",
            "Video rendered successfully.",
            "To win $1,000,000.00 you must first. . .",
            "Touch yourself, get aids.",
            "Maps are for the weak.",
            "I need a corporate bailout.",
            "You are in danger.",
            "Avatar State achieved.",
            "500 Internal Server Error",
            "Spaceworld Demo translation released.",
            "Download Western History.",
            "Always blame MAGE!",
            "Gorged? On my grain!?",
            "RUBBER DUCKY MODE ACTIVATED",
            "You have chosen death.",
            "Item placed in cart.",
            "STOP STEALING MY VIEWS!",
            "Your network connection has been lost.",
            "Scan complete. No threats detected.",
            "Scan pulse malfunction. Try again later.",
            "Stop doing that!",
            "War never changes.",
            "...",
            "To reset RNG, please restart game.",
            "System Error. Powering off.",
            "Please make sure to save.",
            "Unable to sync Steam Cloud.",
            "You better win this race.",
            "Softlock detected.",
            "You aren't going to check that item?",
            "Go mode engaged!",
            "Ice Beam is in Chozodia.",
            "Speedbooster is in Area: 3, Room: 4",
            "Area scan complete. Dragon detected.",
            "You will never finish it.",
            "This seed is impossible.",
            "Your group chat has been leaked.",
            "Kraid is off duty today.",
            "Try Metroid Planets!",
            "AM2R Overrated.",
            "Plasma is next to Mecha.",
            "Tourian is now locked.",
            "You've made a grave mistake.",
            "This could be WR!"
        };
        static private readonly string[] twoLineList =
        {
            "Self-destruct mechanism activated!\nEvacuate immediately!",
            "Facility go big boom.\nRun.",
            "Weapon system\nresupply complete.",
            "Biometric scan complete.\nStatus: Corrupted",
            "Hacking attempt failed.\nContact biospark for assistance.",
            "Energy Tank\nrecharge complete.",
            "Weapons and energy\nfully restored.",
            "Activate Easy Sleep?\nPower off game.",
            "Enemy location abnormal.\nCheck message frame position.",
            "Biometric scan complete.\nStatus: Clear",
            "Heh Heh\nYou're in danger.",
            "OMG!\nIt's a countdown timer! Or is it?",
            "Did you know?\nYou could die here.",
            "Metroid Construction!\nYour ultimate hacking resource.",
            "Incompetent player detected.\nActivating 'gitgud' protocol.",
            "Help! I'm stuck in MST's love dungeon!\nThe address is-",
            "Calculating chance of survival...\nResult: ",
            "Change the world.\nMy final message. Goodbye.",
            "Don't wish it were easier.\nWish you were better.",
            "What is better? To be born good?\nOr to overcome your evil?",
            "The item you are looking for is about\ntwenty-seven rooms away.",
            "Routing..........\nHead to the next room.",
            "Attempting to warp to credits...\nAttempt failed.",
            "These items are not for you.\nWhy are you just taking them like that?",
            "I've been watching.\nI am not ammused.",
            "The space pirates are immune to beams.\nThey are also immune to missiles.",
            "Funny message now displayed.\nQueue the laugh track.",
            "Central time zone is the\nonly time zone.",
            "Defeating Kraid will reward you with\n",
            "Defeating Ridley will reward you with\n",
            "Defeating Mecha will reward you with\nthe planet f%&!ing exploding."
        };
        static private readonly string[] diffList =
        {
            "EASY", "NORMAL", "HARD",
            "HYPERMODE", "VERY HARD", "LEGENDARY",
            "HEROIC", "VETERAN", "NOOB",
            "SCRUB", "INSANE", "CASUAL",
            "UBER HARD", "BAD", "SKILL",
            "SPOOKY", "DIFFICULT", "TOUGH",
            "MYTHIC", "ING-ING", "CHINESE HARD",
            "TROLL", "IMPOSSIBLE", "PEACEFUL",
            "HARDCORE", "ADVENTURE", "GOD MODE",
            "EZ", "TRYHARD", "CAKE WALK",
            "FLABBERGHASTING", "PANSY", "WEAK",
            "FLAWLESS", "OLD MAN", "YEET",
            "MIGHTY", "DEATHLESS", "LUNATIC",
            "ULTRA EASY", "CHAD", "UNSTOPPABLE",
            "OK", "BAD", "GOOD",
            "CRAZY HARD", "INTENSE", "NAP TIME",
            "SIMPLE", "EXTREME", "NOT-SO-EASY",
            "PUSHOVER", "PASSABLE", "NIGHTMARE",
            "HELL", "HALF-HACK", "PAINFUL",
            "PROMBLEMATIC", "DEMANDING", "TROUBLESOME",
            "NOT EASY", "CHALLENGING", "BABY",
            "UNFAIR", "RIGGED", "RNG HEAVY",
            "CHUMP", "BOOMER", "ZOOMER",
            "TAS", "GLITCH GATED", "TRAINING",
            "HOMENAG", "ZOOMER", "PRIME 2 HARD",
            "DARK SOULS", "IMPOPPABLE", "REALISTIC",
            "OHKO", "GODMODE", "AFK SIMULATOR",
            "NOVICE", "EXPERT", "INTERMEDIATE",
            "STANDARD", "BEGINNER", "MEDIUM"

        };
        static private readonly string[] aquiredList =
        {
            "acquired.", "acquired!", "got.",
            "get.", "amassed.", "collected.",
            "gathered.", "grabbed.", "taken.",
            "earned.", "secured.", "snagged.",
            "nabbed.", "obtained.", "stolen.",
            "received.", "picked up.", "intercepted.",
            "downloaded.", "won!", "captured.",
            "seized.", "gained."
        };
        static private readonly string[] capticityList =
        {
            "capacity increased.", "capacity decreased.", "capacity reduced.",
            "reserves increased.", "reserves lowered.", "quantity decreased.",
            "size boosted.", "contents boosted.", "space boosted.",
            "quantity expanded.", "size gained.",  "space inflated.",
            "quantity surged.", "capacity enlarged.", "space reduced.",
            "size lessened.", "space declined.", "size lost.",
            "contents gained.", "contents reduced.", "reserves shrank.",
            "dimensions increased.", "magnitude incremented.", "mass decremented."

        };
        #endregion
        private enum MessageType { STORY, ITEM_INFO, AREA, MISC, FILESCREEN };
        public override bool Randomize()
        {
            byte i;
            string newText;
            if (settings.ItemText)
            {
                for (i = 0; i < 0x16; i++)
                {
                    if (!((i == 0) | (i == 0x16)))
                    {
                        newText = CenterText(ItemStr(i));
                        WriteNewText(newText, i, MessageType.MISC);
                    }
                }

                for (i = 0; i < 0x13; i++)
                {
                    newText = DescriptionStr();
                    WriteNewText(newText, i, MessageType.ITEM_INFO);
                }
            }
            
            if (settings.AreaText)
            {
                for (i = 0; i < 14; i++)
                {
                    newText = CenterText(areaList[GetRandVal(areaList.Length)]);
                    WriteNewText(newText, i, MessageType.AREA);
                }
            }

            if (settings.MiscText)
            {
                for (i = 0x16; i < 0x26; i++)
                {
                    if (!((i == 0) | (i == 0x16)))
                    {
                        newText = MiscStr(i);
                        WriteNewText(newText, i, MessageType.MISC);
                    }
                }

                for (i = 0; i < 0x25; i++)
                {
                    if ((i == 0x11) || (i == 0x12))
                    {
                        newText = FilescreenStr(i);
                        WriteNewText(newText, i, MessageType.FILESCREEN);
                    }
                }
            }

            if (settings.CutsceneText)
            {
                for (i = 0; i < 3; i++)
                {
                    newText = storyList[GetRandVal(storyList.Length)];
                    WriteNewText(newText, i, MessageType.STORY);
                }
            }

            return true;
        }

        private void WriteNewText(string str, uint mNum, MessageType type)
        {
            char ch = (char)(0x8100 | (byte)rng.Next(2, 9));
            str = str.Insert(0, ch.ToString()); //color of text
            byte[] values = Text.BytesFromText(str);
            int textAddress = rom.WriteToEnd(values);
            uint[] ptrAddress = { 0x7609F4, 0x7609A8, 0x7606FC, 0x760660, 0x760A0C }; //base address for message types
            uint num = ptrAddress[(int)type] + (mNum * 4);  //math to get message pointer address
            rom.WritePtr((int)num, textAddress);
        }

        private string DescriptionStr()
        {
            string str = itemDescriptions[GetRandVal(itemDescriptions.Length)];
            switch (str)
            {
                case "Have you tried the ":
                    str += ItemStr(0xC) + "\nyet?";
                    break;
                case "This is just a bootleg version of the\n":
                    str += ItemStr(0xC) + ".";
                    break;
                case "This ability's full potential is only\nunlocked on ":
                    str += diffList[GetRandVal(diffList.Length)] + " difficulty.";
                    break;
                case "Increases survival rating by ":
                    str += (rng.Next(1, 201)).ToString() + "%.";
                    break;
                case "Made in ":
                    str += areaList[GetRandVal(areaList.Length)] + ".";
                    break;
                default:
                    break;
            }
            return str;
        }

        private string FilescreenStr(byte mNum)
        {
            string str = "Difficulty Setting\n " + diffList[GetRandVal(diffList.Length)] + "\n " + diffList[GetRandVal(diffList.Length)];
            if (mNum == 0x12)
                str += "\n " + diffList[GetRandVal(diffList.Length)];
            return str;
        }

        private string ItemStr(byte val)
        {

            string str, str2;
            if (val <= 0xB)         //projectile item messages
            {
                if ((val >= 0x7 && val <= 0xB) | (val == 0x3) | (val == 0x5))   //true if beam message or first tank grab
                    return ((prefixList[GetRandVal(prefixList.Length)] + suffixList[GetRandVal(suffixList.Length)]));
                else if ((val == 2) | (val == 4) | (val == 6))              //true if tank grab
                {
                    str2 = ((prefixList[GetRandVal(prefixList.Length)] + suffixList[GetRandVal(suffixList.Length)]));
                    str = str2 + ' ' + aquiredList[GetRandVal(aquiredList.Length)] + '\n';
                    str += str2 + ' ' + capticityList[GetRandVal(capticityList.Length)];
                }
                else                    //true if message 1
                {
                    str2 = ((prefixList[GetRandVal(prefixList.Length)] + equipSuffix[GetRandVal(equipSuffix.Length)]));
                    str = str2 + ' ' + aquiredList[GetRandVal(aquiredList.Length)] + '\n';
                    str += str2 + ' ' +  capticityList[GetRandVal(capticityList.Length)];
                }
                //this allows the tank names to be the same for both lines
                return str;
            }
            else      //other item messages
                return prefixList[GetRandVal(prefixList.Length)] + equipSuffix[GetRandVal(equipSuffix.Length)];
        }

        private string MiscStr(byte val)
        {
            string str;
            if ((val == 0x17) | ((val <= 0x20) && (val >= 0x1B)))  //single line messages
                return CenterText(oneLineList[GetRandVal(oneLineList.Length)]);
            else

            {
                str = twoLineList[GetRandVal(twoLineList.Length)];
                switch (str)
                {
                    case "Calculating chance of survival...\nResult: ":
                        str += Convert.ToString(GetRandVal(101)) + '%';
                        break;
                    case "Defeating Ridley will reward you with\n":
                    case "Defeating Kraid will reward you with\n":
                        str += ItemStr(0xC) + ".";
                        break;
                    default:
                        break;
                }
                return CenterText(str);
            }

        }

        private int GetRandVal(int maxVal) => rng.Next(0, maxVal);

        private string CenterText(string str)
        {
            if (str.Contains("\n"))        //splits two line messages and indents each
            {
                string[] splitStr = str.Split('\n');
                return (CenterText(splitStr[0]) + '\n' + CenterText(splitStr[1]));
            }
            int length = 0;
            foreach (char c in str)
                length += Text.GetCharWidth(rom, c);
            if (length >= 220)          //no indent needed if longer than 220
                return str;
            length = (((length + 220) / 2) - length);   //math to see size of indent
            char ch = (char)(0x8000 | (byte)length); //0x80XX, indent code + indent value
            str = str.Insert(0, ch.ToString());
            return str;

        }

        public override string GetLog()
        {
            var changed = new List<string>();
            if (settings.ItemText)
                changed.Add("Items");
            if (settings.AreaText)
                changed.Add("Areas");
            if (settings.MiscText)
                changed.Add("Misc. Messages");
            if (settings.CutsceneText)
                changed.Add("Cutscene Messages");
            if (changed.Count == 0)
                return "Text: Unchanged" + Environment.NewLine;
            return "Text: " + string.Join(", ", changed) + Environment.NewLine;
        }
    }
}
