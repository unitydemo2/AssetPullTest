#NetworkReader and NetworkWriter serializers

Use the [NetworkReader](ScriptRef:Networking.NetworkReader.html) and [NetworkWriter](ScriptRef:Networking.NetworkWriter.html) classes to write data to byte streams. 

The Multiplayer [High Level API](UNetUsingHLAPI) is built using these classes, and uses them extensively. However, you can use them directly if you want to implement your own custom transport functionality. They have specific serialization functions for many Unity types (See [NetworkWriter.Write](ScriptRef:Networking.NetworkWriter.Write.html) for the full list of types).

To use the classes, create a writer instance, and write individual variables into it. These are serialized internally into a byte array, and this can be sent over the network. On the receiving side it’s important that the reader instance for the byte array reads back the variables in exactly the same order they were written in.

This can be used with the [MessageBase](ScriptRef:Networking.MessageBase.html) class to make byte arrays that contain serialized network messages.

```
void SendMessage(short msgType, MessageBase msg, int channelId)
{
    // write the message to a local buffer
    NetworkWriter writer = new NetworkWriter();
    writer.StartMessage(msgType);
    msg.Serialize(writer);
    writer.FinishMessage();

    myClient.SendWriter(writer, channelId);
}
```

This message is correctly formatted so that a message handler function can be invoked for it.

## Using the NetworkReader and NetworkWriter classes with the NetworkServerSimple and NetworkClient classes

The following code sample is a rather low level demonstration, using the lowest level classes from the high-level API for setting up connectivity.

This is the code for connecting the client and server together:

```
using UnityEngine;
using UnityEngine.Networking;
public class Serializer : MonoBehaviour {
    NetworkServerSimple m_Server;
    NetworkClient m_Client;
    const short k_MyMessage = 100;

    // When using a server instance like this it must be pumped manually
    void Update() {
        if (m_Server != null)
            m_Server.Update();
    }

    void StartServer() {
        m_Server = new NetworkServerSimple();
        m_Server.RegisterHandler(k_MyMessage, OnMyMessage);
        if (m_Server.Listen(5555))
            Debug.Log("Started listening on 5555");
    }

    void StartClient() {
        m_Client = new NetworkClient();
        m_Client.RegisterHandler(MsgType.Connect, OnClientConnected);
        m_Client.Connect("127.0.0.1", 5555);
    }

    void OnClientConnected(NetworkMessage netmsg) {
        Debug.Log("Client connected to server");
        SendMessage();
    }
}
```

The next piece of code sends a message using the network reader and network writer, but uses the message handlers built into these classes:

void SendMessage() {
    NetworkWriter writer = new NetworkWriter();
    writer.StartMessage(k_MyMessage);
    writer.Write(42);
    writer.Write("What is the answer");
    writer.FinishMessage();
    m_Client.SendWriter(writer, 0);
}

void OnMyMessage(NetworkMessage netmsg) {
    Debug.Log("Got message, size=" + netmsg.reader.Length);
    var someValue = netmsg.reader.ReadInt32();
    var someString = netmsg.reader.ReadString();
    Debug.Log("Message value=" + someValue + " Message string='" + someString + "'");
}

When setting up messages for the message handlers, you should always use `NetworkWriter.StartMessage()` (with the message type ID) and NetworkWriter.FinishMessage() calls. When not using the byte arrays, you can skip that step.