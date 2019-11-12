# Wolven-kit

This is a fork of Traderain's Wolven-kit that contains several tweaks/modifications that which are to my own liking. This is not intended to be merged back with the main branch.

Examples of changes include:

- Hot key(s) for packing mods since I prefer to use Wolven-Kit for packing and wanted to expedite the process.
- Stand Alone version of the String Encoder GUI since I have to make a lot of string changes for my own mod.
- The stand alone version of the String Encoder uses DevExpress' controls instead of the bare bones Windows Forms grid, which both looks better and allows for filtering, searching, sorting and an overall better user experience.
- Refactored some of the code for String Encoder (stand alone only) so that it is easier to read and/or simplifed some of the logic.
- Changed a couple instances of the Folder Selection Dialog that Tradearin was using so that it is using the Vista Folder Browser dialog instead of the old XP style dialog.
- "Fixed" a few spots where Wolven-kit throws errors when it should be doing shell executes (I.E. image, witcher script files).
- Upgraded to target .NET 4.8, I did not see any reason to leave it on 4.6.x. 