# Game-Of-Life-3D
A 3D adaptation of Conway's Game Of Life.

My dad was curious how it would turn out so I decided to put together a version in Unity. Surprisingly, there are hundreds of interesting and unique configurations that only work in 3 dimensions.

I struggled a lot with a very specific issue that was creating frame drops in Unity. I found a few solutions online but none seemed to work for me. I identified the source of the issue as the way Unity was rendering the objects I was creating, and how it only occured when I would move the camera around within the program because the Unity engine was trying to draw the objects in a very inefficient manor.

To combat this, I changed my program from my original sloppy design of simply not displaying cubes that were "dead" but still going through a triple nested for loop each iteration to update every cube, to the more modern approach of only updating neighbors that are directly affected. This helped speed up my program a little bit, but sadly did not resolve the frame stuttering issue.
