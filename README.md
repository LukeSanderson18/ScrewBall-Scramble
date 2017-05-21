# Screwball Scramble
It's Screwball Scramble!

![1](https://github.com/LukeSanderson18/ScrewBall-Scramble/blob/master/pictures%20for%20git/3.png)

#YouTube Link:
https://www.youtube.com/watch?v=Sqejdbx2yC4&feature=youtu.be

## Brief 

This project is a portrayal of the popular children's game, Screwball Scramble.
The player must manoeuvre the ball through the maze by using the arrow keys and space bar to twist, turn and pop various puzzles throughout.

## Implementation 

I used Unity3D as it has a fully functional Physics system built in.
For the vast majority of puzzles I used Hinge, Distance and Spring joints in order to replicate moving parts.

To emulate the effect of a magnet in the game's magnet crane, I added an inverted explosion force from the ball to the crane when it was
in reach.

The hardest part by far was trying to give the ball appropiate elevation during the 'poppers' section. Physics materials and enlarged
colliders ensured the ball didn't fall off this section too easily.

![2](https://github.com/LukeSanderson18/ScrewBall-Scramble/blob/master/pictures%20for%20git/2.png)

Some assets wre originally going to be handled by animations, such as the final catapult, but I instead opted for a modified hinge joint
with a number of invisible box colliders. The ball consistently flew out of the catapult due to it's intense speed, so I added an extra
collider that de-activated once the player hit the final bell, thus releasing it.
![3](https://github.com/LukeSanderson18/ScrewBall-Scramble/blob/master/pictures%20for%20git/1.png)

The level and its components were all modelled in Blender.
