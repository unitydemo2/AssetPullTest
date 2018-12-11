# Using the Network Manager HUD

Note: This documentation assumes that you understand fundamental networking concepts such as the relationship between a host, server and client. To learn more about these concepts, see documentation on [Network System Concepts](UNetConcepts). 


![The Network Manager HUD component, as viewed in the inspector](../uploads/Main/NetworkManagerHUDComponent.png)

|**_Property:_** |**_Function:_** |
|:---|:---|
|__Show Runtime GUI__ | Tick this checkbox to show the Network Manager HUD GUI at run time. This allows you to reveal or hide it for quick debugging. |
|__GUI Horizontal Offset__ | Set the horizontal pixel offset of the HUD, measured from the left edge of the screen. |
|__GUI Vertical Offset__ | Set the vertical pixel offset of the HUD, measured from the top edge of the screen. |


The **Network Manager HUD** ("heads-up display") provides the basic functions so that people playing your game can start hosting a networked game, or find and join an existing networked game. Unity displays the Network Manager HUD as a collection of simple UI buttons in the Game view.

![The Network Manager HUD UI, as viewed in the Game view](../uploads/Main/NetworkManagerHUDUI.png)

The Network Manager HUD is a quick-start tool to help you start building your multiplayer game straight away, without first having to build a user interface for game creation/connection/joining. It allows you to jump straight into your gameplay programming, and means you can build your own version of these controls later in your development schedule.

It is not, however, intended to be included in finished games. The idea is that these controls are useful to get you started, but you should create your own UI later on, to allow your players to find and join games in a way that suits your game. For example, you might want to stylize the design of the screens, buttons and list of available games to match the overall style of your game.

To start using the Network Manager HUD, create an empty GameObject in your Scene (menu: **GameObject** > **Create Empty**) and add the Network Manager HUD component to the new GameObject.

For a description of the properties shown in the inspector for the Network Manager HUD, see the Network Manager HUD reference page.

## Using the HUD

The Network Manager HUD has two basic modes: **LAN** (Local Area Network) mode and **Matchmaker** mode. These modes match the two common types of multiplayer games. **LAN** mode is for creating or joining games hosted on a local area network (that is, multiple computers connected to the same network), and **Matchmaker** mode is for creating, finding and joining games across the internet (multiple computers connected to separate networks).

The Network Manager HUD starts in **LAN** mode, and displays buttons relating to hosting and joining a LAN-based multiplayer game. To switch the HUD to **Matchmaker** mode, click the **Enable Match Maker (M)** button.

**Note**: Remember that the Network Manager HUD feature is a temporary aid to development. It allows you to get your multiplayer game running quickly, but you should replace it with your own UI controls when you are ready.
