# WolvenKit DX

This is a fork of Traderain's Wolven-kit that features a significant user interface overhaul, performance improvements and other changes that I felt were necessary for making Wolven-Kit an overall better program for Witcher 3 mod development. Many of the changes are courtsey of Developer Express' widgets. 

# Downloading / Installing

I intend to create a release for this once I feel it is at a state where it is stable and different enough from Traderain's version to merit releasing it. Once it is at a release state, I will make an installer available for download in the releases section. The installer will most likely be using <a href="https://www.installpackbuilder.com/"> Paquet Builder </a> or some other installer. A zip / installer-less version will also be available.


# What's Different From The Original: 

<i>New Stuff </i>
- Incorporates DevExpress' Windows Forms suite. This means it uses Direct X, Vector Skins, etc.
- Improved loading times due to using DevExpress Splash screen instead of the original WolvenKit splash screen.
- The splash screen is entirely different in appearance and also features a progress bar.
- Uses a different icon from the original WolvenKit to help differentiate the apps.
- Added a new icon for the app to help differentiate it from the regular Wolven Kit.
- Added a new script editor feature, powered by Scintilla Net (the editor used by Notepad++). This is a work in progress. Currently the script editor features syntax highlighting for Witcher Script (uses the C++ lexer), code folding, line numbers and searching. 
- The Main Window now has a ribbon with much larger buttons, built in hot key support and is overall easier to use.
- Stand Alone version of the String Encoder GUI since I have to make a lot of string changes for my own mod.
- The stand alone version of the String Encoder uses DevExpress' controls instead of the bare bones Windows Forms grid, which both looks better and allows for filtering, searching, sorting and an overall better user experience.
- The Main Window uses DevExpress' dock layout manager instead of the one Traderain was using. This includes more docking capabilities, pinning and greater flexability for the user.
- Both the Output view and Mod Explorer view are now user controls which use DevExpress' components instead of their base Windows Forms equivileants.
- Completely reworked how the Mod Explorer interacts with the rest of WolvenKit and how it handles file system changes to the project. Wolvenkit no longer blows away and rebuilds the entire tree list whenever a change occurs. This reduces flickering / freezing and greatly improves the usability of WolvenKit.
- Changed a couple instances of the Folder Selection Dialog that Tradearin was using so that it is using the Vista Folder Browser dialog instead of the old XP style dialog.
- The "Chunk Editor" (the widget that displays when you are editing files like .w2ent files) uses the DevExpress grid instead of Object List View, which means it uses the app theme and allows for better filtering and data shaping.
- Added one click mod build / quick build feature that builds a mod with all default parameters. Can be invoked using the ribbon hot keys as well.
- The build/package window has also been redone using DevExpress and now starts centered, is less narrow and the ok button is focused (in case you quickly want to hit space to build).

<i>Miscellaneous Changes </i>
- "Fixed" a few spots where Wolven-kit throws errors when it should be doing shell executes (I.E. image, witcher script files).
- Cleaned up various spelling mistakes and/or other typographical errors.
- Upgraded to target .NET 4.8, I did not see any reason to leave it on 4.6.x. 
- *If .NET Core 3.X adds full support for the clunky Windows Forms Designer, I will look into the feasability of moving it to .NET Core 3.x.*

<i>Removed Parts</i>
- Removed a lot of dependencies that were not being used, unimplemented and/or rendered obsolete due to the usage of DevExpress.
- Removed the Discord dependencies as well since WolvenKit DX is NOT affiliated with the original WolvenKit team/project. 
- Removed the donation features since again, this project is not affiliated with the original WolvenKit. 
- Removed the (in my opinion) annoying recent files feature; it was buggy and I found it to be a nuisance since it kept reopening files that I had closed on subsequent loads.


# What About Changes Made To The Original Wolven-Kit?

As of 12/2/2019, this repository is current with all of Traderain's changes to the original Wolven-Kit. After that, this repo was broken off from being a fork due to the fact that I felt it was too radically different for the two to stay in sync. I will still try to integrate in any fixes or improvements he makes to the original Wolven-Kit if possible, but please keep in mind that going from 12/2/2019 forward, there is no guarantee that WolvenKit DX will have 100% parity with the original WolvenKit. 

# Note / Shameless Advertisement: 
Since this uses DevExpress, you will need a license for thier controls if you wish to build this solution. I have my own Universal Subscription license and strongly recommend that you get one from DevExpress if you love their components. They provide amazing technical support and offer probably some of the best looking components for desktop/web/mobile that money can buy. It is expensive, but its money well spent. 
