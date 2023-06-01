# Jump of Fate
A unity platforming game, featuring ugprades and differing levels. Made by Edison Ying and Tony Lin. 
## Installation Instructions
### Playing 
1. Download and install both [Unity Hub](https://unity.com/download) and Unity (version: 2021.3.21f1).
2. Register for a unity license. 
3. [Clone](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository) this repository using `git clone https://github.com/justapotato213/Jump-of-Fate.git` inside a git terminal, or clone using an alternative method of your choice. 
4. Open the project in Unity.
5. [Build](https://docs.unity3d.com/Manual/PublishingBuilds.html) the project using unity for your desired platform, and run the executable unity builds. 
### Editing
#### Game
1. Follow steps 1-4 in [playing](https://github.com/justapotato213/Jump-of-Fate/edit/main/README.md#playing). 
2. [Download Visual Studio](https://visualstudio.microsoft.com/), making sure to install the unity workload within the installer. 
3. With the unity project open, click on edit -> preferences. 
4. Click on external tools, and make sure Visual Studio is selected. 
5. Under the section labeled "Generate .csproj files for", make sure all checkmarks are ticked. 
6. Click the "Regenerate project files".
7. Within Visual Studio, click on open and locate the .sln file within your project. 
8. Open the .sln file, and begin editing!
9. The overall scene can be edited within unity. 
#### Level Generator
1. Follow steps 1-4 in [playing](https://github.com/justapotato213/Jump-of-Fate/edit/main/README.md#playing). 
2. Open [LevelGenerator/imageGenerator.py](LevelGenerator/imageGenerator.py).
3. Edit the code (imageGenerator.py) using an IDE of your choice. 
4. Add slices in the form of .jpg images inside (Input_Images) folder.
5. Once you run (imageGenerator.py), generated levels will be saved in the (Levels) folder.
## Notes
### Game
- The level generation is handled by the WorldGen.cs file. 
  - This functions by looking at a level image, and looking pixel by pixel at its RGB codes. 
    - These images are located under [Assets/Resources/Level](Assets/Resources/Level).
  - It then places the corresponding prefabs and tiles, as determined in unity. 
    - This can be edited by opening the Tile Map game object, and changing the settings within "Color Tile Mapping" and "Color Prefab Mapping" 
  - When a level gets deleted, every child of Tile Map gets deleted, and therefore cannot be used to store information between levels. 
- Player movement is within the PlayerController.cs file.
- Save data is saved under the [PersistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html) of unity, inside sav.dat. 
  - This is simply stored as a JSON format.
- There are two scenes, MainMenu and SampleScene, where the MainMenu is the beginning menu, and SampleScene is the main game itself. 
### Level Generator
- imageGenerator.py is the Python file used to generate the levels
  - Note: In order to run this file, you will need to have the PILLOW library installed in Python. Installation instructions can be found here: https://pillow.readthedocs.io/en/stable/installation.html
  - It works by randomly combining the slices (images) horizontally and adds the start and the end to each level.

