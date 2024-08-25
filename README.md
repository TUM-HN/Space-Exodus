# Story Background
The game is a space escape game. In the story, Earth succumbs to the ever-rising tide of garbage, exceeding its capacity. Forced to find a new home, humanity undergoes rigorous astronaut training. They are then sent into space on a new journey. Unfortunately, the spaceship loses power early on due to Earth’s resource depletion. This leaves humans stranded in the vast universe shortly after boarding. Thousands of humans and animals sleep within the vessel, with only trained personnel taking turns awakening to steer the ship and search for a potential new habitat. Humanity's future rests on efficiently utilizing the remaining energy and navigating through a wormhole.

On Day 117, a glimmer of hope emerges. The AI and the on-duty crew member discover space debris containing enough potential energy to open a wormhole. This wormhole acts as a shortcut to a potentially habitable zone. Humanity's fate now rests on your shoulders. You must manage the limited energy and steer the ship through the wormhole skillfully. Every second counts!
![images](https://github.com/chuuuun/Spacecraft/blob/main/spaceship.png)
## Scene 1: Start Scene (Menu Scene)
The start menu serves as the game's settings panel, allowing players to adjust various options:
+ Turn Mode: Choose between continuous or snap turn modes for camera movement.
+ Subtitles: Enable or disable subtitles for on-screen text.
+ Language: The language offered in the game is English or Spanish
## Scene 2: Spaceship Scene
Stranded in the vast expanse of space, a group of survivors faces a grim reality – their energy reserves are dwindling, and the prospect of finding a new habitable planet remains uncertain. To conserve precious resources, they adopt a strategy of rotational hibernation, with one person remaining awake to search for hope while the others slumber. The story unfolds on the 117th day of this cosmic odyssey. Amidst a shower of meteors, our protagonist stumbles upon a potential energy source – a unique substance embedded within a meteorite. Driven by a desperate resolve to escape their desolate void, they embark on a daring mission to determine whether this newfound power can propel their vessel away from this barren wasteland.

### Task 1 -> Throw the Meteor into the trashcan
- **Mobile elements:** None
- **Elements to interact:** Grab button, Trashcan, meteor
- **Time to pass it / solve it:** 5 mins (including the story narrative time)
- **Difficulty explanation (player perspective):** 
grab and move/teleport to the trashcan → Easy
### Task 2 -> Clean up the mess in the bricks room
- **Mobile elements:** None
- **Elements to interact:** Grab button, bricks recycle cans, bricks, candies
- **Time to pass it / solve it:** 10 mins (including the story narrative time)
- **Difficulty explanation (player perspective):** 
grab and move/teleport to the trashcan several times → Medium
### Task 3 -> Disintegrate the larger meteor
- **Mobile elements:** None
- **Elements to interact:** Grab button, Activate button, energy, meteor, gun
- **Time to pass it / solve it:** 3 mins
- **Difficulty explanation (player perspective):** 
use the gun to decompose the meteor → Easy
### Task 4 -> Put energy source on an analyzer
- **Mobile elements:** None
- **Elements to interact:** Grab button, energy, analyser
- **Time to pass it / solve it:** 5 mins
- **Difficulty explanation (player perspective):** 
put energy on the analyzer, might need time to find which device is the analyzer → Easy
### Task 5 -> Pilot spaceship to the wormhole
- **Mobile elements:** None
- **Elements to interact:** Grab button, wheel, lever, knob, wormhole, Meteors
- **Time to pass it / solve it:** 8 mins
- **Difficulty explanation (player perspective):** 
pilot the spaceship and avoid collision with meteors. → Hard
![images](https://github.com/chuuuun/Spacecraft/blob/main/control%20room.png)
# Controls
The joysticks are always handled in this way↓
![images](https://github.com/chuuuun/Spacecraft/blob/main/controller.png)
Instruction: Grab == Middle finger placement
![images](https://github.com/chuuuun/Spacecraft/blob/main/grab.png)
Instruction: Activate == Grab + Select == Middle finger placement + Index finger placement
![images](https://github.com/chuuuun/Spacecraft/blob/main/select.png)

# Set-up
## How to start the VR equipment
Step 1: Download the Meta Quest app on your phone.
[Apple](https://apps.apple.com/de/app/meta-quest/id1366478176)
[Android](https://play.google.com/store/apps/details?id=com.oculus.twilight&hl=de)

Step 2: Create your own VR account (must use FB account)

Step 3: Follow the instructions to set the play zone without obstacles causing potential harm

Step 4: Connect your account on your phone with VR equipment.
[[Video: How to create an account](https://www.youtube.com/watch?v=z8mU6bCN0H0)]

## How to start the game (Developer)
### Phone
Both Computer and Phone Setup are necessary for testing the game. For Mac users, wireless testing is impossible since VR equipment is an Android device, and wireless connection is not supported officially. For window users, simply download this app; wireless testing is allowed once the Quest Link setup is finished.
[[Set up Meata Quest Link](https://www.meta.com/en-gb/help/quest/articles/headsets-and-accessories/oculus-link/set-up-link/)]
 + Download the Meta Quest app on your phone.
[Apple](https://apps.apple.com/de/app/meta-quest/id1366478176)
[Android](https://play.google.com/store/apps/details?id=com.oculus.twilight&hl=de)
+ Create your own VR account (must use FB account)
+ Connect your account on your phone with VR equipment.
[[Video: How to create an account](https://www.youtube.com/watch?v=z8mU6bCN0H0)]
+ Enable developer mode on the VR equipment.
[[How to enable developer mode](https://www.youtube.com/watch?v=TWHrvQ3VTJQ)]
### Computer
- Step 1: Setup a [developer account](
https://id.unity.com/account/new)
- Step 2: Download [Unity Hub](
https://unity.com/de/products)
- Step 3: Download the [project]( https://github.com/chuuuun/bachelor_thesis)
- Step 4: Open the project with Unity (~ 60 min), recommend Unity version -- 2022.3.24f1
- Step 5: Set the project build and run the specific VR equipment 
Unity → File → Build Settings → Choose Android (Platform) → Change platform (take around 20-30mins)
Once the “change platform” is done, the picture below is what should be shown
![images](https://github.com/chuuuun/Spacecraft/blob/main/buildsetting.png)
- Step 5: run and build (take around 3-4 hours)
## How to escape/close the game 
Press **Universal Menu** button to show the menu bar, **Exit** could be chosen to escape the game.

Press button A on the right controller to access the Pause Menu.
![images](https://arc.net/l/quote/mhpmcrvb)
