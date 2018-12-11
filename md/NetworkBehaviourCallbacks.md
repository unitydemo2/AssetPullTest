# NetworkBehaviour callbacks

Like the [Network Manager callbacks](https://docs.unity3d.com/Manual/NetworkManagerCallbacks.html), there are a number of events relating to network behaviours that can occur over the course of a normal multiplayer game. These include events such as the host starting up, a player joining, or a player leaving. Each of these possible events has an associated **callback **that you can implement in your own code to take action when the event occurs.

When you create a script which **inherits** from [NetworkBehaviour](ScriptRef:Networking.NetworkBehaviour), you can write your own implementation of what should happen when these events occur. To do this, you [override](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override) the virtual methods on the `NetworkBehaviour` class with your own implementation of what should happen when the given event occurs. 

This page lists all the virtual methods (the callbacks) that you can implement on Network Behaviour, and when they occur. A game can run in one of three modes, **host**, **client**, or **server-only**. The callbacks for each mode are listed below:

### Callbacks in server mode

**When a client connects:**

* `OnStartServer`

* `OnRebuildObservers`

* `Start()` function is called

### Callbacks in client mode

**When a client connects:**

* `OnStartClient`

* `OnStartLocalPlayer`

* `OnStartAuthority`

* `Start()` function is called

### Callbacks in host mode

These are only called on the **Player GameObjects** when a client connects:

* `OnStartServer`

* `OnStartClient`

* `OnRebuildObservers`

* `OnStartAuthority`

* `OnStartLocalPlayer`

* `Start()` function is called

* `OnSetLocalVisibility`

**On any remaining clients, when a client disconnects:**

* `OnNetworkDestroy`
