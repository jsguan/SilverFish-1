# For User
1. Download the HearthBuddy from internet.  
2. Unzip the [DotNetCompilerPlatform.zip](https://github.com/ChuckHearthBuddy/SilverFish/releases/download/2019.8.11.10/DotNetCompilerPlatform.zip) to root folder of above program
3. Replace the HearthBuddy.exe with latest [version](https://github.com/ChuckHearthBuddy/SilverFish/releases) 
4. Delete all files under DefaultRoutine folder, then put the [files](https://github.com/ChuckHearthBuddy/SilverFish/archive/master.zip) in this repository under DefaultRoutine folder.  
   Or you can run the PowerShell [move files script](https://github.com/ChuckHearthBuddy/SilverFish/blob/master/MoveFiles.ps1) to move files.(You must replace the target folder in script and backup previous routine folder)

## Plugins
[AutoConcede](https://github.com/ChuckHearthBuddy/Plugins/tree/master/AutoConcede) is used to reduce the win rate, and you can modify the [win rate threshold](https://github.com/ChuckHearthBuddy/Plugins/blob/master/AutoConcede/AutoConcede.cs#L20).

## Tools
[CardQuery](https://github.com/ChuckHearthBuddy/CardQuery) is used to get the card id with Chinese name or English name.  
[Online mulligan editor](https://magician333.github.io/hbmulligan/) is used to generate the mulligan easily.  

# For Developer
Make sure you have the following four files under packages folder  
1.GreyMagic.dll  
2.Hearthbuddy.exe  
3.IronPython.dll  
4.IronPython.Modules.dll  
5.Microsoft.Scripting.dll  
Build the project under x86 platform.

## Ai Test  
Please refer to the wiki documentation [Ai Test](https://github.com/ChuckHearthBuddy/SilverFish/wiki/Ai-Test)  


# Community
[Chatroom](https://gitter.im/ChuckLu/Lobby)  