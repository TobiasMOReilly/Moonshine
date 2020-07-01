Resources:

--Fonts
HillBilly
	https://www.fontsplace.com/hillbilly-free-font-download.html
Burnstown Dam
	https://www.dafont.com/burnstown-dam.font
Docktrin
	https://www.dafont.com/docktrin.font
Vintage Warehouse
	https://www.dafont.com/vintage-warehouse.font
Alpha Wood
	https://www.dafont.com/alpha-wood.font

--Texture
	PBR Materials - Wood & Metal
		https://assetstore.unity.com/packages/2d/textures-materials/pbr-materials-wood-metal-50290
	PBR Ground Materials #1 [Dirt & Grass]
		https://assetstore.unity.com/packages/2d/textures-materials/floors/pbr-ground-materials-1-dirt-grass-85402
Ceramic
	http://freeseamlesstexture.blogspot.com/2014/03/ceramic-seamless-texture.html
Cork
	https://www.sketchuptextureclub.com/textures/architecture/wood/cork/cork-texture-seamless-04093
--Models
	Realistic Tree 9 [Rainbow Tree]
		https://assetstore.unity.com/packages/3d/vegetation/trees/realistic-tree-9-rainbow-tree-54622
--SkyBox
	Free HDR Sky
		https://assetstore.unity.com/packages/2d/textures-materials/sky/free-hdr-sky-61217

--Audio
	engine
		https://freesound.org/people/InspectorJ/sounds/345557/
	plate
		https://freesound.org/people/edwar64896/sounds/381259/
	drinking
		https://freesound.org/people/dersuperanton/sounds/433645/

	Music
		http://freemusicarchive.org/genre/Bluegrass/
	Yeah
		https://freesound.org/people/juliandmc4/sounds/443539/

--TUTS
	CineMachine Dolly
		https://unity3d.com/learn/tutorials/topics/animation/using-cinemachine-track-dolly
	Wheel Collider tutorial
		https://www.youtube.com/watch?v=j1lPUXhEB08
	Pause Menu
		https://www.youtube.com/watch?v=JivuXdrIHK0
	TextMeshPro
		https://www.youtube.com/watch?v=xfo0NrLJe_k

Deviations:

--Camera
	Cinemachine was used instead of the camera sytem idea mentioned in the design document.
		Cinimachine provided a cleaner and more visualy pleasing result.
		Tracks leading player, moving alog a dolly system.

--Player Obstacles
	Gates and holes were not included - Avoiding the mountain edge, not falling behind
						and co operating seemed like enough of a challange.
--Player Resets
	Resets were increased to 3. Reset point was changed from the point they fell off the track.
		Players reset to other players/ checkpoints depending on state of the game

--Player Controls
	Pause button added ( button Y 360 controller)
	Reset button added ( button B 360 controller)

--Audio
	Crash Sound not implemented, was not needed.
	Smashing sample added to weapon, ontriggerEnter

--PickUps/Weapons
	Flip type changed to bomb, although can have that effect!

--Player Stats
	Displayed on race completion only

--Menus
	Pause, Win, GameOver menus added

Bugs:

--Menu
	When reseting the scence from one of the menus in race;
		 player scriptable objects not reseting properly
			works when return to main menu then start race again

--Players
	Can get stuck on terrain sometimes (walls/edges)
	Reset to checkpoint can be buggy, player upside down

--Camera
	can get lost on dolly track after player reset