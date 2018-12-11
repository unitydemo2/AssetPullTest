# Using the Transport Layer API

In addition to the [high-level networking API (HLAPI)](UNetUsingHLAPI), Unity also provides access to a lower-level networking API called the **Transport Layer**. The Transport Layer allows you to build your own networking systems with more specific or advanced requirements for your game’s networking.

The Transport Layer is a thin [layer](https://en.wikipedia.org/wiki/Multitier_architecture) working on top of the operating system’s sockets-based networking. It can send and receive messages represented as arrays of bytes, and offers a number of different "[quality of service](ScriptRef:Networking.QosType)" options to suit different scenarios. It is focused on flexibility and performance, and exposes an API within the [NetworkTransport](ScriptRef:Networking.NetworkTransport.html) class.

The Transport Layer supports base services for network communication. These base services include:

* Establishing connections

* Communicating using a variety of "quality of services"

* Flow control

* Base statistics

* Additional services, such as communication via relay server or local discovery


The Transport Layer can use two protocols: UDP for generic communications, and WebSockets for WebGL. To use the Transport Layer directly, the typical workflow is as follows:

1. Initialize the Network Transport Layer

2. Configure network topology

3. Create a host

4. Start communication (handling connections and sending/receiving messages)

5. Shutdown library after use

See the corresponding sections below to learn about the technical details of each section. Each section provides a code snippet to include in your networking script. 

### Step 1: Initialize the Network Transport Layer

When initializing the Network Transport Layer, you can choose between the default initialization demonstrated in the code sample below (with no arguments), or you can provide additional parameters which control the overall behaviour of the network layer, such as the maximum packet size and the thread timeout limit.

To initialize the transport layer with default settings, call [Init()](ScriptRef:Networking.NetworkTransport.Init.html):

```

    // Initializing the Transport Layer with no arguments (default settings)
    NetworkTransport.Init();

To initialize the transport layer with your own configuration just add your configuration as a parameter to Init, as shown below.

    // An example of initializing the Transport Layer with custom settings
    GlobalConfig gConfig = new GlobalConfig();
    gConfig.MaxPacketSize = 500;
    NetworkTransport.Init(gConfig);
```

You should only use custom `Init` values if you have an unusual networking environment and are familiar with the specific settings you need. As a rule of thumb, if you are developing a typical multiplayer game to be played across the internet, the default `Init` settings are enough.

### Step 2: Configure the network topology

The next step is to configure connections between peers. Network topology defines how many connections allowed and what connection configuration will used. If your game needs to send network messages which vary in importance (eg low importance such as incidental sound effects, vs high importance such as whether a player scored a point), you might want to define several communication channels, each with a different quality of service level specified to suit the specific types of messages that you want to send, and their relative importance within your game.

```

    ConnectionConfig config = new ConnectionConfig();
    int myReliableChannelId  = config.AddChannel(QosType.Reliable);
    int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
```

The example above defines two communication channels with different quality of service values. [QosType.Reliable](ScriptRef:Networking.QosType.Reliable.html) delivers a message and ensures that the message is delivered, while [QosType.Unreliable](ScriptRef:Networking.QosType.Unreliable.html) sends a message faster, but without any checks to ensure it was delivered.

You can also adjust properties on [ConnectionConfig](ScriptRef:Networking.ConnectionConfig.html) to specify configuration settings for each connection. However, when making a connection from one client to another, the settings should be the same for both connected peers, or the connection fails with a [CRCMismatch](ScriptRef:Networking.NetworkError.CRCMismatch.html) error.

The final step of network configuration is topology definition.

```

HostTopology topology = new HostTopology(config, 10);
```

This example defines host topology as being able to allow up to 10 connections. These connections are the ones you configured in Step 1. 

### Step 3: Create a host

Now that you have performed the first two preliminary set-up steps, you need to create a host (open socket):

```

int hostId = NetworkTransport.AddHost(topology, 8888);
```

This code example adds a new host on port 8888 and any IP addresses. The host supports up to 10 connections (you configured this in Step 2). These connections are the ones you configured in the Step 1.

### Step 4: Start communicating

In order to start communicating, you need to set up a connection to another host. To do this, call `Connect()`. This sets up a connection between you and the remote host. An event is received to indicate whether the connection is successful.

First, connect to the remote host at 192.168.1.42 with port 8888. The assigned `connectionId` is returned.

```

connectionId = NetworkTransport.Connect(hostId, "192.168.1.42", 8888, 0, out error);

```

When the connection is done, a ConnectEvent is received. Now you can start sending data.

```

NetworkTransport.Send(hostId, connectionId, myReliableChannelId, buffer, bufferLength,  out error);
```

When you are done with a connection,  call `Disconnect()` to disconnect the host.

```
NetworkTransport.Disconnect(hostId, connectionId, out error);
```

To check if your function calls were successful, you can cast the `out error` to a [NetworkError](ScriptRef:Networking.NetworkError.html). [NetworkEror.Ok](ScriptRef:Networking.NetworkError.Ok.html) indicates that no errors have been encountered.

To check host status, you can use two functions:

For polling events off the internal event queue you can call either 

NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);

Or
NetworkTransport.ReceiveFromHost(recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);

Both of these functions return events from the queue; the first function will return events from any host, and the recHostId variable will be assigned with the host id that the message comes from, whereas the second function returns events only from the host specified by the recHostId that you provide.

One way to poll data from `Receive` is to call it in your `Update` function;

```

void Update()
{

    int recHostId; 
    int connectionId; 
    int channelId; 
    byte[] recBuffer = new byte[1024]; 
    int bufferSize = 1024;
    int dataSize;
    byte error;
    NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
    switch (recData)
    {
        case NetworkEventType.Nothing:                     break;
        case NetworkEventType.ConnectEvent:                break;
        case NetworkEventType.DataEvent:                   break;
        case NetworkEventType.DisconnectEvent:            break;

  case NetworkEventType.BroadcastEvent:

       break;
    }
}

```

There are 5 type of events that you can receive.

* [NetworkEventType.Nothing](ScriptRef:Networking.NetworkEventType.Nothing.html): The event queue has nothing to report.

* [NetworkEventType.ConnectEvent](ScriptRef:Networking.NetworkEventType.ConnectEvent.html) : You have received a connect event. This can be either a successful connect request, or a connection response.

```

case NetworkEventType.ConnectEvent: 
    if(myConnectionId == connectionId)
        //my connect request was approved
    else
        //somebody else sent a connect request to me
    break;

```

* [NetworkEventType.DataEvent](ScriptRef:Networking.NetworkEventType.DataEvent.html): You have received a data event. You receive a data event when there is some data ready to be recieved. If the `recBuffer` is big enough to contain data, data is copied into the buffer. If not, the event contains a [MessageToLong](ScriptRef:Networking.NetworkError.MessageToLong.html) network error. If this happens, you need to reallocate the buffer to a larger size and call the `DataEvent` function again.

* [NetworkEventType.DisconnectEvent](ScriptRef:Networking.NetworkEventType.DisconnectEvent.html): Your established connection has disconnected, or your connect request has failed. Check the error code to find out why this has happened.

```

case NetworkEventType. DisconnectEvent: 
    if(myConnectionId == connectionId)
        //cannot connect for some reason, see error
    else
        //one of the established connections has disconnected
    break;
```

* [NetworkEventType.BroadcastEvent](ScriptRef:Networking.NetworkEventType.BroadcastEvent.html): Indicates that you have received a broadcast event, and you can now call [GetBroadcastConnectionInfo](ScriptRef:Networking.NetworkTransport.GetBroadcastConnectionInfo.html) and [GetBroadcastConnectionMessage](ScriptRef:30_search.html?q=GetBroadcastConnectionMessage) to retrieve more information.

### WebGL support

You can use WebSockets on WebGL, however web clients can only connect to hosts, they cannot be a host themselves. This means the host must be a standalone player (Win, Mac or Linux only). For client-side configuration, all steps described above (including topology and configuration) are the same. On the server, call the following:

```

NetworkTransport.AddWebsocketHost(topology, port, ip);

```

The IP address above should be the specific address you want to listen on, or you can pass null as the IP address if you want the host to listen all network interfaces. 

A server can only support only one WebSocket host at a time, but it can handle other generic hosts at the same time:

````

NetworkTransport.AddWebsocketHost(topology, 8887, null);
NetworkTransport.AddHost(topology, 8888);

````
