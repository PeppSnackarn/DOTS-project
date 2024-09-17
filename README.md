# DOTS project

# Instructions
Create a small space shooter game with the following features:
**Simple movement**,
**Shooting**,
**Waves of enemies**

# **How?**
The game needs to be programmed in a data-oriented way with the hardware in mind. In particular we are looking for submissions that:
Are efficient in their heap allocations and memory usage
Use algorithms and loops that are smartly done and minimize negative impact in the user experience when employed at scale
 
# **README**
This project is created with Unity DOTS. Using Unity's entity component system (ECS). It features a simple player character that can move in X,Y and can shoot "bullets" along with enemies that spawn periodically and move down the screen.
Enemies spawning, enemy movement, player movement, player shooting is all handled through ECS and are using smartly allocated memory trying to keep as much as possible in the stack memory rather than heap.
