# DOTS project
 
# **Contents**
This project is created with Unity DOTS. Using Unity's entity component system (ECS). It features a simple player character that can move in X,Y and can shoot "bullets" along with enemies that spawn periodically and move down the screen.

- Unity ECS was used for all game components; bullets, enemies and the player are all Entities and are using a data oriented approach in handling all of their seperate functions.
- Unity's Burst compiler was also used in certain places where apliccable to compile the code into more efficient machine code that speeds up performance.
- Unity Job system allows me as a developer to assign certain functions to different threads and cores; this was used to move the player and the enemies
- The EntityCommandBuffer was used to queue entity changes and execute them together in groups and was used to spawn bullets

  # **Process**
  The goal of this project was to create a "performance aware space shooter" using Unity DOTS. A data oriented approach to coding which differs from standard OOP. This project had the following requirements:
  - Simple movement
  - Shooting
  - Waves of enemies

  This is not a finished game; there is no gameplay loop, no collision, no score, no health. It is simply a showcase of unity DOTS.

  After having completed all requirements for the assignment I created a build and tested out the performance. Both by profiling the code in engine and through checking FPS in a build, my results where as followed:
  - Almost no frametime spent on any of my code on average spending 0.01 -0.03 ms on my systems (profiler mostly showed engine functions and the playerloop taking frametime)
  - Reaching almost 2400 fps in a build, leaving it on for a couple minutes letting around a hundred of enemies spawn didn't change this framerate at all, thus proving its pretty stable.
  - Using the memory profiler I looked through my heap usage where I could see that it started out at 22 mb and after having been left to idle for a minute it only grew to 25 mb (objects are currently not being deleted) which shows a pretty efficient heap usage. Profiling 
    a development build I saw almost no change in allocated memory over a 3 minute idle phase, although in editor this changes. In editor a assembly known as "malloc(persistent)" grows and allocates more and more memory as the editor is in playmode. This seems to be 
    connected to the Burst compiler & job's but also seems to be a self allocating function within C# code.

 # **Reflection**
 - If I were to add the functionality to remove and despawn objects after a certain lifetime, it would shrink memory growth significantly and possibly solve the issue i explained before.
 - Using Jobs was an effective way to achieve multihreading and allows utilizing a CPU to its fullest.
 - Using entities instead of regular GameObjects was a data oriented workflow and allowed for more performance at the cost of boilerplate and more advanced code.

 
