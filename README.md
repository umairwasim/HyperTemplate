# HyperTemplate

 A flexible hyper casual project template including some useful stuff.

### Installation

 - Clone this project.
 - Open it via Unity Hub (recommended versions: 2021.1.4f1 or higher)
 - Enjoy!

### Dependencies
All dependencies are auto-installing via Unity Package Manager, you don't need to do anything. 

 - [MyBox](https://github.com/Deadcows/MyBox) by [Deadcows](http://deadcow.ru/)
 - [Naughty Attributes](https://github.com/dbrizov/NaughtyAttributes) by [Denis Rizov](https://denisrizov.com/)
 - [DOTween](https://github.com/Demigiant/dotween) by [Demigiant](http://demigiant.com/)
 - [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) by [Newtonsoft](https://www.newtonsoft.com/json)
 - And some other Unity registries.

### Main Features & Workflow
HyperTemplate uses one-scene setup. There are 2 main workflow that I am using:

 1. Unique Levels
 2. Unique Mechanics
 
 Unique Levels workflow allows you to make every level unique - different mechanics, different obstacles for every level. Every level must be made by hand and must be stored as prefab. Place your mechanic inside that prefab and store your levels inside LevelManager.
 
 Unique Mechanics workflow allows you to simply create mechanics, add some randomness factor and every level would be created randomly during runtime. Add your mechanics to scene and store them inside MechanicManager.
 
### To-do list
  
 - [ ] Add working chest system
 - [ ] Add simple shaders such as toon shader, toon with outer lines etc.
 - [ ] Add some VFX such as confettis, particles, glares etc.
 - [ ] Complete documentation(add detailed description for every utility)
