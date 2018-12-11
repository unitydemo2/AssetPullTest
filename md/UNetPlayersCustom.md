# Custom Player Spawning

The Network Manager offers a built-in simple player spawning feature, however you may want to customize the player spawning process - for example to assign a colour to each new player spawned.

To do this you need to override the default behaviour of the Network Manager with your own script.


When the Network Manager adds a player, it also instantiates a GameObject from the Player Prefab and associates it with the connection. To do this, the Network Manager calls [NetworkServer.AddPlayerForConnection](ScriptRef:Networking.NetworkServer.AddPlayerForConnection.html). You can modify this behaviour by overriding [NetworkManager.OnServerAddPlayer](ScriptRef:Networking.NetworkManager.OnServerAddPlayer.html). The default implementation of `OnServerAddPlayer` instantiates a new player instance from the player Prefab and calls [NetworkServer.AddPlayerForConnection](ScriptRef:Networking.NetworkServer.AddPlayerForConnection.html) to spawn the new player instance. Your custom implementation of `OnServerAddPlayer` must also call `NetworkServer.AddPlayerForConnection`, but your are free to perform any other initialization you require in that method too. 

The example below customizes the color of a player. First, add the color script to the player prefab:

```
using UnityEngine;
using UnityEngine.Networking;
class Player : NetworkBehaviour
{
	[SyncVar]
	public Color color;
}
```

Next, create a [NetworkManager](ScriptRef:Networking.NetworkManager.html) to handle spawning.

```
using UnityEngine;
using UnityEngine.Networking;
public class MyNetworkManager : NetworkManager
{
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		player.GetComponent<Player>().color = Color.red;
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
```

The function `NetworkServer.AddPlayerForConnection` does not have to be called from within `OnServerAddPlayer`. As long as the correct connection object and `playerControllerId` are passed in, it can be called after `OnServerAddPlayer` has returned. This allows asynchronous steps to happen in between, such as loading player data from a remote data source.

Although in most multiplayer games, you typically want one player for each client, the [HLAPI](UNetUsingHLAPI) treats players and clients as separate concepts.This is because, in some situations (for example, if you have multiple controllers connected to a console system), you might need multiple player GameObjects for a single connection. When there are multiple players on one connection, you should use the `playerControllerId` property to tell them apart. This identifier is scoped to the connection, so that it maps to the ID of the controller associated with the player on that client.

The system automatically spawns the player GameObject passed to `NetworkServer.AddPlayerForConnection` on the server, so you don’t need to call [NetworkServer.Spawn](ScriptRef:Networking.NetworkServer.Spawn.html) for the player. Once a player is ready, the active networked GameObjects (that is, GameObjects with an associated [NetworkIdentity](UNetSpawning)) in the Scene spawn on the player’s client. All networked GameObjects in the game are created on that client with their latest state, so they are in sync with the other participants of the game.

You don’t need to use [playerPrefab](ScriptRef:Networking.NetworkManager-playerPrefab.html) on the `NetworkManager` to create player GameObjects. You could use different methods of creating different players.

## Ready state

In addition to players, client connections also have a "ready" state. The host sends clients that are ready information about spawned GameObjects and state synchronization updates; clients which are not ready are not sent these updates. When a client initially connects to a server, it is not ready. While in this non-ready state, the client can do things that don’t require real-time interactions with the game state on the server, such as loading Scenes, allowing the player to choose an avatar, or fill in log-in boxes. Once a client has completed all its pre-game work, and all its Assets are loaded, it can call [ClientScene.Ready](ScriptRef:Networking.ClientScene-ready.html) to enter the “ready” state. The simple example above demonstrates implementation of ready states; because adding a player with `NetworkServer.AddPlayerForConnection` also puts the client into the ready state if it is not already in that state.

Clients can send and receive network messages without being ready, which also means they can do so without having an active player GameObject. So a client at a menu or selection screen can connect to the game and interact with it, even though they have no player GameObject. See documentation on [Network messages](UNetMessages) for more details about  sending messages without using commands and RPC calls.

## Switching players

To replace the player GameObject for a connection, use [NetworkServer.ReplacePlayerForConnection](ScriptRef:Networking.NetworkServer.ReplacePlayerForConnection.html). This is useful for restricting the commands that players can issue at certain times, such as in a pre-game lobby screen. This function takes the same arguments as `AddPlayerForConnection`, but allows there to already be a player for that connection. The old player GameObject does not have to be destroyed. The [NetworkLobbyManager](ScriptRef:Networking.NetworkLobbyManager.html) uses this technique to switch from the [NetworkLobbyPlayer](ScriptRef:Networking.NetworkLobbyPlayer.html) GameObject to a gameplay player GameObject when all the players in the lobby are ready.

You can also use `ReplacePlayerForConnection` to respawn a player after their GameObject is destroyed. In some cases it is better to just disable a GameObject and reset its game attributes on respawn. The following code sample demonstrates how to actually replace the destroyed GameObject with a new GameObject:

```
class GameManager
{
    public void PlayerWasKilled(Player player)
    {
        var conn = player.connectionToClient;
        var newPlayer = Instantiate<GameObject>(playerPrefab);
        Destroy(player.gameObject);
        NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);
    }
}
```

If the player GameObject for a connection is destroyed, then that client cannot execute Commands. They can, however, still send network messages.

To use `ReplacePlayerForConnection` you must have the [NetworkConnection](ScriptRef:Networking.NetworkConnection.html) GameObject for the player’s client to establish the relationship between the GameObject and the client. This is usually the property [connectionToClient](ScriptRef:Networking.NetworkBehaviour-connectionToClient.html) on the [NetworkBehaviour](ScriptRef:Networking.NetworkBehaviour.html) class, but if the old player has already been destroyed, then that might not be readily available.

To find the connection, there are some lists available. If using the `NetworkLobbyManager`, then the lobby players are available in [lobbySlots](ScriptRef:Networking.NetworkLobbyManager-lobbySlots.html). The [NetworkServer](ScriptRef:Networking.NetworkServer.html) also has lists of [connections](ScriptRef:Networking.NetworkServer-connections.html) and [localConnections](ScriptRef:Networking.NetworkServer-localConnections.html).