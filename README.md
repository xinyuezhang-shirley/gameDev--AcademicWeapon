# Academic Weapon Instructions
Screens/Scenes:
In the screens folder under scenes are multiple scenes that point to one another
Start- starting screen of the game (Please start at the start scene) Game- the actual game scene
Lost- losing screen of the game
Win-winning screen of the game

Controls:
Left key- moves the player object left at a fixed velocity
Right key- moves the player object right at a fixed velocity
Space key- shoots a sand glass/orb if enough time has passed since the last one was shot

Win/Lose/Score:
Score/GPA +0.10 if orb/sand glass collides with an enemy/code 
Score/GPA -0.10 if the player exits the screen
Score/GPA -0.10 if an enemy/code collides with the deadline/finish line
Win- when GPA reaches or gets below 4.00 
Lose- when GPA reaches or gets below 0.00

Behavior of Elements:
Shirley/Player: 
person icon holding a computer representing the player
- holding the left/right buttons moves the player at a fixed velocity toward that direction
- pressing the space bar shoots a sand glass upwards linearly at a fixed speed
- Produces “keyboard” sound
- Sandglass can only be shot once per designated time interval (.3 s)
- spawns an enemy once every designated time interval at a random x-point from the top of
the screen
- exiting the screen causes the icon to respawn in the middle with the same y-altitude
- GPA goes down by 0.10 upon this behavior
- Produces “oh no” sound”
  
Sand Glass/ Orb: 
icon shot out from the player that destroys the enemy icon upon collision
- Upon collision with the enemy, it produces a “tadaa” sound and then destructs
- GPA goes up by 0.10 done by the colliding enemy upon this destruction
- Produces “Tadaa” sound
- Upon exiting the screen, it destructs
  
Code/ Enemy: 
enemy randomly spawned from the top of the screen that the user needs to destroy
- Upon spawn, the enemy moves from the top of the screen to the bottom at a fixed velocity
- Upon collision with an orb, it destructs
- Increases GPA by 0.10 upon this destruction
- “Tadaa” sound produced by the colliding orb
- Upon collision with the deadline, it destructs
- Increases GPA by 0.10 upon this destruction
- “ohno” sound produced by the colliding finish line
  
Deadline/ Finishline: 
The green line represents the deadline that the assignments cannot pass
- Upon collision with an enemy, produces “ohno” sound
