# Network Manager HUD

The Network Manager HUD is a simple and quick way to provide the basic functions that players of your game need in order to host a networked game, or find and join an existing networked game. It displays a collection of simple UI buttons which appear in the Game view when the Editor is in Play mode. It is intended as a helpful short term solution to get you started quickly with making your game. You should replace the UI it provides with your own that better suits your game when you are ready.

For a full guide to using the Network Manager HUD component, and the controls that are displayed at runtime, see [Using the Network Manager HUD](UNetManagerHUD).

![The Network Manager HUD component in the Inspector window](../uploads/Main/NetworkManagerHUDComponent.png)

|**Property**|**Function**|
|:---|:---|
|**Show Runtime GUI**|Tick this checkbox to show the Network Manager HUD GUI at run time. This allows you to reveal or hide it for quick debugging.|
|**GUI Horizontal Offset**|Set the horizontal pixel offset of the HUD, measured from the left edge of the screen.|
|**GUI Vertical Offset**|Set the vertical pixel offset of the HUD, measured from the top edge of the screen.|

*Note: the ***_Network Manager HUD _***is designed as a temporary aid to development. It allows you to get your multiplayer game running quickly, but you should replace it with your own UI controls when you are ready.*