## PKHeX Sprite Plugin
=====

![License](https://img.shields.io/badge/License-GPLv3-blue.svg)

Sprite Pack plugin that changes the default sprites in PKHeX

## Screenshot
<img src="https://i.imgur.com/1cr5dD3.gif">

## Building  
This project requires an IDE that supports compiling .NET based code (Ideally .NET 4.6+). Recommended IDE is Visual Studio 2022.

You should be able to build upon opening the .sln.

To create your own sprite plugin you will need:

1. Make edits to the sprites found in PKHeX/PKHeX.Drawing.PokeSprite/Resources/img
2. Once you are happy with the sprites you created, use a Resource Generator to create a .resources file. 
3. Open the .sln and replace PokeSprite.resources with your own.
4. build/rebuild the solution.
5. You should now see a successful build and the .dll file will be located in bin\debug or bin\release directory.


## Usage  
To use the plugin:

- Place the plugins folder in the same folder as PKHeX. 
- Start PKHeX.exe.
- Enjoy!

## Support Server
Join the Discord server for help with this plugin and anything else PKHeX, SysBot.NET related.

[<img src="https://i.imgur.com/bl0QgF7.png">](https://discord.gg/dvcity)

## Credits

- [@kwsch](https://github.com/kwsch) for providing the IPlugin interface in PKHeX, which allows loading of this project's Plugin DLL file. Also for suggesting I should create a plugin for my sprites.
- [@architdate](https://github.com/architdate) for being helpful and help inspire putting this together.
- [@hp3721](https://github.com/hp3721) for the creating the Resource Generator needed for the .resources
