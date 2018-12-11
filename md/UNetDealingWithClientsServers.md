# Dealing with clients and servers

When you are making your multipayer game, you will need to implement a way for players to find each other, join existing matches or create new ones. You will also need to decide how to deal with common network problems, such as what happens if the person hosting the game quits.

This section provides information on how to build these important parts of your game, including:

* [Host migration](UNetHostMigration), for when the player hosting a peer-hosted game quits.

* [Network discovery](UNetDiscovery), to help your players connect to each other on a LAN

* [Multiplayer lobby](UNetLobby), to help your players create or join matches across the internet

* [Custom network client and server code](UNetClientServer) - when you have custom requirements and want to write your own connection code rather than using Unity’s [Network Manager](UNetManager).
