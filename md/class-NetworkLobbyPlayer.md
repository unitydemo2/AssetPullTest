#Network Lobby Player

The Network Lobby Player stores per-player state for the Network Lobby Manager while in the lobby. When using this component, you need to write a script which allows players to indicate they are ready to begin playing, which sets the [readyToBegin](ScriptRef:Networking.NetworkLobbyPlayer-readyToBegin.html) property. See documentation on the [Network Lobby Manager](class-NetworkLobbyManager.html) for full details on how to use this component.

A GameObject with a Network Lobby Player component must also have a [Network Identity](class-NetworkIdentity.html) component. When you create a Network Lobby Player component on a GameObject, Unity also creates a Network Identity component on that GameObject if it does not already have one.

![The Network Lobby Player component](../uploads/Main/NetworkLobbyPlayer.png)

|**Property**|**Function**|
|:---|:---|
|**Show Lobby GUI**|Enable this to show the developer GUI for players in the lobby. This UI is only intended to be used for ease of development. This is enabled by default.|
|Network Channel|The [network channel](ScriptRef:Networking.Channels.html) used by the Network Lobby Player|
|Network Send Interval|The rate at which information is sent from the Network Lobby Player to the server. See [GetNetworkSendInterval()](ScriptRef:Networking.NetworkBehaviour.GetNetworkSendInterval.html)|

