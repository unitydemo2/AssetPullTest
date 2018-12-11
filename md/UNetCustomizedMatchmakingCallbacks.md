##Customized Matchmaking callbacks

When using the **Network Manager** with the [Network Manager HUD](class-NetworkManagerHUD.html), the [NetworkManager.StartMatchmaker](ScriptRef:Networking.NetworkManager.StartMatchMaker.html) method enables matchmaking, and populates the [NetworkManager.matchMaker](ScriptRef:Networking.NetworkManager-matchMaker.html) property with a [NetworkMatch](ScriptRef:Networking.Match.NetworkMatch.html) object. Once this is active, the Network Manager HUD uses it and calls methods on [NetworkManager](ScriptRef:Networking.NetworkManager.html) to let you perform simple matchmaking.

There are virtual functions on `NetworkManager` that you can customize by deriving your own class from `NetworkManager`. You can then customize the way your new `NetworkManager` class responds to Matchmaker callbacks.

Here are the callbacks and their default implementations. If you override them, there are some methods which require that you call the base implementation, otherwise the functionality with the Network Manager HUD breaks. For example, the default implementation of `OnMatchCreate`, starts the host.

```
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomManager : NetworkManager {

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchCreate Success:{0}, ExtendedInfo:{1}, matchInfo:{2}", success, extendedInfo, matchInfo); }
        if(success)
            StartHost(matchInfo);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchJoined Success:{0}, ExtendedInfo:{1}, matchInfo:{2}", success, extendedInfo, matchInfo); }
        if(success)
            StartClient(matchInfo);
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchList Success:{0}, ExtendedInfo:{1}, matchList.Count:{2}", success, extendedInfo, matchList.Count); }
        matches = matchList;
    }

    public override void OnDestroyMatch(bool success, string extendedInfo) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnDestroyMatch Success:{0}, ExtendedInfo:{1}", success, extendedInfo); }
    }

    public override void OnDropConnection(bool success, string extendedInfo) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnDestroyMatch Success:{0}, ExtendedInfo:{1}", success, extendedInfo); }
    }

    public override void OnSetMatchAttributes(bool success, string extendedInfo) {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnDestroyMatch Success:{0}, ExtendedInfo:{1}", success, extendedInfo); }
    }
}
```