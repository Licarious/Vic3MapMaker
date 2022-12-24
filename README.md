# Vic3MapMaker
software designed to edit states, regions, and nationional/pop layout for Vic3

User Guide:

StartPage:
Game Folder: this should be set to a folder that contains vic3 common, map_data, and localization folders. ie "...steamapps\common\Victoria 3\game\"

Output Folder: this is where you want to save the files generated by the program.

After setting those and clicking start the program will begin processing the game files this should take somewhere around 3-5 minutes depending on map size and number of states.



MainPage:
Side Panel: 
First dropdown box: Select the category of what is being worked on. (state, region, country, ect)

Second dropdown box: Selects items for the currently selected category.

Edit button: Brings up the edit page state, region, or country in the second dropdonw box.

refresh button: Refresh map (mostly only useful when using the undo button)


Category specific action box:
State:
Move Prov: Transfers a province from to the selected state when left clicking the map.

Naval Exit: Changes naval exit to clicked naval state ID.

Hubs: Changes hub province.

Clear Selected button: clears selected Naval Exit or Hub.


Region:
Transfer State: Moves state to selected region.

Capital: Changes capital province.


Country:
Transfer Province: Moves a single province to the selected country.

Transfer State: Moves all provinces that the click country owns in the clicked state to the selected country.

Transfer Region: Moves all provinces that the click country owns in the clicked region to the selected country.


Undo button: Undoes previous action.

Save button: Writes files to output folder.




Map Panel: shows graphical representation of selected category.
State, Region, Country, and Terrain: Right click selects clicked Item, Left click applies action.

PrimeLand and Impassable: Click toggles province.

Prov: Click gits province id.
