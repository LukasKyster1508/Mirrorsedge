![Visual](Cityscape.png)

# Mirrorsedge

This project aims to replicate the movement mechanics of Mirror's Edge, albeit in a less refined manner.

## Game Overview

The main components of the game include:

- **Player:** A capsule controlled with WASD, capable of jumping with the spacebar and sprinting for increased speed.
- **Camera:** Follows the player's movements, rotatable via mouse input.
- **Wall Running:** Enables the player to run or slide on walls by pressing the A or D keys, with the camera tilting to visualize the wall run.
- **Pedestrians:** Capsule objects that roam around the city.

## Game Features

- **Timer:** Displays the time played during the current session.
- **Sprint Effect:** Activating sprint changes the camera's field of view (FOV) to create a sense of increased speed.
- **Pedestrian Interaction:** Colliding with pedestrians causes them to react.

## Scripts

- **Movement:** Handles player movement, implements CameraShake function, and applies physics to the player.
- **Wallrun:** Allows the player to run on walls by detecting nearby surfaces.
- **PlayerLook:** Rotates the camera with mouse input.
- **CameraHolder:** Positions the camera correctly.
- **CameraShake:** Creates a camera shake effect, triggered when the player lands.
- **TimerCountdown:** Displays a live counter of the player's game time.
- **PedestrianSpawn:** Spawns pedestrians around the city.
- **WalkingObject:** Controls the movement of spawned objects.

## Assets

- **New York City Package:** Downloaded from [Unity Asset Store](https://assetstore.unity.com/packages/3d/environments/urban/real-new-york-city-vol-1-208247).
- **Skybox HDRI:** Downloaded from [HDRI Haven](https://hdri-haven.com/hdri/factory-sunset-sky-dome).

## Scenes

- The game consists of a single scene.

## Testing

- The game has been tested on Windows within the Unity editor.
- There is a slight issue with the New York Asset's hitboxes, causing the wall run to toggle while in the air.

## Music

- Game music downloaded from [Pixabay](https://pixabay.com/sound-effects/city-ambience-9272/).

## Used Resources

- [Rigidbody FPS Controller (w/WallRunning) | Tutorial Series](https://youtube.com/playlist?list=PLRiqz5jhNfSo-Fjsx3vv2kvYbxUDMBZ0u&si=KsNc9dTrVmcOhQrf)
- [Real New York City Vol. 1](https://assetstore.unity.com/packages/3d/environments/urban/real-new-york-city-vol-1-208247)
- [OpenAI – Chat GPT](https://www.openai.com/)
- [City Ambience Sound](https://pixabay.com/sound-effects/city-ambience-9272/)

