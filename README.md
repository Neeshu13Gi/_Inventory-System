Movement Controls:

Use the W button for moving the player character forward.
Use the A button for moving the player character left.
Use the S button for moving the player character backward.
Use the D button for moving the player character right.
Picking Up Items:

Assign a specific button (e.g., E button) as the pick-up button.
When the player character is near an item, pressing the E button will add the item to the player's inventory.
Viewing Inventory:

Assign a specific button (e.g., I button) as the inventory button.
Pressing the I button will open the inventory screen, displaying all items the player has picked up.
Dropping Items:

Within the inventory screen, provide a "Drop" button next to each item.
Clicking the "Drop" button will remove the item from the inventory and place it back in the game world.
Detailed Steps
1. Setting Up Movement Controls
Map the W button to move the player character forward.
Map the A button to move the player character left.
Map the S button to move the player character backward.
Map the D button to move the player character right.
2. Picking Up Items
Define an interaction radius around the player character.
When the player character is within this radius and the E button is pressed:
Add the item to the player's inventory.
Remove the item from the game world.
3. Viewing Inventory
Create an inventory UI that can be toggled on and off.
When the I button is pressed:
Display the inventory UI with all the items the player has collected.
4. Dropping Items
In the inventory UI, add a "Drop" button next to each item.
When the "Drop" button is clicked:
Remove the item from the player's inventory.
Place the item back into the game world at the player's current location or a specified drop zone.
