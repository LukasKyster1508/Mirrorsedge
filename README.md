![Visual](Cityscape.png)
# Mirrorsedge
This Project is trying to imitate the mirror's edge movement, but in a worse way.
The main parts of the game are:
•	Player – Capsule which can be moved with WASD and can jump using the spacebar. The player also has the ability to sprint to increase the speed.
•	Camera – It moves with the player as it moves and can be rotated using a mouse input.
•	Wall running – Allows for the player to run/slide on the wall when pressing the A or D key depending which side you are. The camera is also affected by the wallrun by tilting the camera to visualize the wall run.

The main parts of the game are:
•	Player – Capsule which can be moved with WASD and can jump using the spacebar. The player also has the ability to sprint to increase the speed.
•	Camera – It moves with the player as it moves and can be rotated using a mouse input.
•	Wall running – Allows for the player to run/slide on the wall when pressing the A or D key depending which side you are. The camera is also affected by the wallrun by tilting the camera to visualize the wall run.
•	Pedestrians – Capsule object that walk around the city.

Game features:
•	A Timer that shows the player how long they have played the game during that session.
•	Using the sprint changes the camera FOV to make it look faster.
•	Colliding with the pedestrian make them freak out.

•	Scripts:
o	Movement – used for moving the player and implementing the Camerashake function as well as applying physics on the player.
o	Wallrun – Used for making the player able to run on the wall. It detect if there a nearby walls.
o	PlayerLook – Used for making the camera rotate along with the mouse input.
o	CameraHolder – Used to set the cameras position in the correct position.
o	CameraShake – Used to make a camera shake effect this is called in the Movement script when a player lands on the ground.
o	TimerCountdown – Used to make a live counter of how long the player has been in the game.
o	PedestrianSpawn – Spawns pedestrians around the city
o	WalkingObject – Makes the spawned objects walk around the city.

  •	A package of New York downloaded from the unity asset store - https://assetstore.unity.com/packages/3d/environments/urban/real-new-york-city-vol-1-208247

•	Materials:
  o	Skybox HDRI downloaded from - https://hdri-haven.com/hdri/factory-sunset-sky-dome
  
•	Scenes:
  o	Game consists of one scene
  
•	Testing:
  o	The game has only been played on windows in the unity editor. There is a slight problem with the New York  Asset due to the models hitboxes so the wall run toggles while in the air at times.
  
•	Music:
  o	The music used in the game has been downloaded from - https://pixabay.com/sound-effects/city-ambience-9272/

Used Resources
•	Rigidbody FPS Controller (w/WallRunning) | Tutorial Series -  https://youtube.com/playlist?list=PLRiqz5jhNfSo-Fjsx3vv2kvYbxUDMBZ0u&si=KsNc9dTrVmcOhQrf

•	Real New York City Vol. 1 -https://assetstore.unity.com/packages/3d/environments/urban/real-new-york-city-vol-1-208247

•	OpenAI – Chat GPT

•	City ambience - https://pixabay.com/sound-effects/city-ambience-9272/
