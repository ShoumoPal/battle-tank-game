# Battle Tank 3D

* A tank 3D game utilizing various programming patterns
* Use Bullets to kill Enemies and survive!

<img src = "https://github.com/ShoumoPal/battle-tank-game/assets/46050414/86851b12-ec27-45b6-9512-f117f0207858" width=50% height=50%>

## Design Patterns and Features:
* Android game using joystick controls
* MVC Pattern : For Player Tank, Enemy and Bullets
* Object pooling : For the Bullets using a Generic Object pool
* Observer Pattern : To implement the achievement system( Customized UI with animations that pops up whenever Player has shot a number of bullets )
* NavMesh and NavMeshAgent: Used for creating the Enemy AI
* State Machines: For implementing various states of the Enemies including Idle, Patrol, Chase and Attack
* Services: Singletons used for Tank and Enemy Spawners, as well as for the Object pools.
* Documentation: Properly documented code.
