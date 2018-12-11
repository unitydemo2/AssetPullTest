#Multiplayer Classes Reference

You can create scripts which inherit from these classes to customise the way Unity's networking works.

* The [NetworkBehaviour](class-NetworkBehaviour) class works with GameObjects that have a [Network Identity](class-NetworkIdentity.html) component. These scripts can perform [high-level API](UNetUsingHLAPI.html) functions such as [Commands, ClientRPCs](UNetActions), [SyncEvents](ScriptRef:Networking.SyncEventAttribute.html) and [SyncVars](UNetStateSync).
* The [NetworkClient](class-NetworkClient) class manages a network connection from a client to a server, and can send and receive messages between the client and the server.
* The [NetworkConnection](class-NetworkConnection) encapsulates a network connection. (NetworkClient)[class-NetworkClient] objects have a `NetworkConnection`, and [NetworkServers](class-NetworkServer) have multiple connections - one from each client. NetworkConnections have the ability to send byte arrays, or serialized objects as network messages.
* The [NetworkServer](class-NetworkServer) manages connections from multiple clients, and provides game-related functionality such as spawning, local clients, and player manager.
* The [NetworkServerSimple](class-NetworkServerSimple) is a basic server class with no game-related functionality. While the NetworkServer class handles game-like things such as spawning, local clients, and player manager, and has a static interface, the NetworkServerSimple class is a pure network server with no game related functionality. It also has no static interface or singleton, so more than one instance can exist in a process at a time.
