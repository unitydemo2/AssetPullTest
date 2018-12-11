# Remote Settings scripting

Use the Unity Scripting API [RemoteSettings](ScriptRef:RemoteSettings.html) class to access your remote settings in code. The `RemoteSettings` class provides functions to access your remote settings, like `RemoteSettings.GetString()`, as well as events that you can use to trigger functions when your settings are fetched or updated.

| Event| Purpose |
|:---|:---| 
| BeforeFetchFromServer| Dispatched immediately before the `RemoteSettings` class makes its network request to retrieve your remote settings. |
| Completed| Dispatched when the network request is complete. `Completed` is always dispatched, even when the network request fails and when there are no changes to the remote settings. You can use the `serverResponse` code passed to your delegate function to determine whether the request succeeded or failed. The parameter contains one of the standard HTTP response codes, such as 200 for success. |
| Updated| Dispatched after the network request completes successfully, but ONLY when your remote settings have changed since the previous check.<br/><br/>Note: Prior to Unity 2018.1, the `Updated` event was always dispatched, even when there were no settings changes. If you rely on a delegate function to apply settings in your game whether or not there have been changes, you must use the `Completed` event rather than the `Updated` event. |


You should register your handler functions for these events as early as possible during application launch, such as in the `Awake()` function of a MonoBehaviour loaded in your first Unity scene.

Because fetching the settings requires a [network transaction](UnityAnalyticsRemoteSettingsNetRequests), the `RemoteSettings` object dispatches its events asynchronously. Your handler functions might not be called in the same order relative to other events on every platform or even on every launch of the same platform. Always initialize your configuration variables with reasonable default values, and allow for the possibility that your event handlers can be called at different times during application startup.

__Code example__

The following example shows a class that defines a number of properties for tuning game difficulty and updates these properties based on remote settings:

    using UnityEngine;
    
    public class RemoteTuningVariables : MonoBehaviour {
    
        public float DefaultSpawnRateFactor = 1.0f;
        public float DefaultEnemySpeedFactor = 1.0f;
        public float DefaultEnemyStrengthFactor = 1.0f;
        public static float SpawnRateFactor{ get; private set; }
        public static float EnemySpeedFactor{ get; private set; }
        public static float EnemyStrengthFactor{ get; private set; }
    
        void Start () {
            SpawnRateFactor = DefaultSpawnRateFactor;
            EnemySpeedFactor = DefaultEnemySpeedFactor;
            EnemyStrengthFactor = DefaultEnemyStrengthFactor;
        
            RemoteSettings.Completed += HandleRemoteSettings;
        }
    
        private void HandleRemoteSettings(bool wasUpdatedFromServer, bool settingsChanged, int serverResponse){
            SpawnRateFactor 
                = RemoteSettings.GetFloat ("SpawnRateFactor", DefaultSpawnRateFactor);
            EnemySpeedFactor
                = RemoteSettings.GetFloat ("EnemySpeedFactor", DefaultEnemySpeedFactor);
            EnemyStrengthFactor 
                = RemoteSettings.GetFloat ("EnemyStrengthFactor", DefaultEnemyStrengthFactor);
        }
    } 


Notice that the class provides default values in the `RemoteSettings.GetFloat()` method calls. If the `RemoteSettings` object cannot find the specified key (if you misspell a key name, for example), then the method still assigns your default values to the tuning variables. Otherwise, the `GetFloat()` and `GetInt()` methods assign zero to numbers, `GetString()` assigns an empty string to strings, and `GetBool()` assigns false to boolean variables.

The class also assigns the same default values to the properties in the `Start()` method in case another class accesses the settings before the remote settings are fetched and no previously cached configuration is available locally. Assigning the default values in the `Start()` method ensures that the properties always have reasonable values.

## Ensuring setting consistency

If you have several classes in your game that access remote settings at different times, it is possible that some objects will access your settings before the asynchronous network request completes and some will access the settings afterwards, possibly resulting in inconsistent setting values. To avoid this inconsistency problem, you either have to wait for the asynchronous network request to complete before accessing any settings or you can simply use the existing settings you have at the start of the current session. In this latter case, the local settings are updated in the background and a player will see them in the next session. 

| Method| Benefits | Drawbacks |
|:---|:---|:---| 
| Wait for request completion| - Setting values are consistent<br/>- Always using latest settings | - Indeterminate delay in setting availability<br/>- Asynchronous code complexity |
| Use current settings| - Setting values are consistent<br/>- Settings are available immediately | - New setting values not used until the second session<br/>- The first time a player runs the game, no settings are available. (Use default values.) |


The following example illustrates a provider class that assigns its properties based on the last version of your remote settings fetched from the Analytics service. The `RemoteSettings` class still updates the settings in the background, so any settings changes are used in the next session (rather than the current session). The following example uses a singleton pattern so that all parts of your game that use these settings get the same values no matter when the `RemoteSettings` class receives the remote update.

    using UnityEngine;
    
    public class RemoteSettingProvider : MonoBehaviour {
        public float DefaultSpawnRateFactor = 1.0f;
        public float DefaultEnemySpeedFactor = 1.0f;
        public float DefaultEnemyStrengthFactor = 1.0f;
        public float SpawnRateFactor{ get; private set; }
        public float EnemySpeedFactor{ get; private set; }
        public float EnemyStrengthFactor{ get; private set; }
        
        // Singleton pattern
        private static RemoteSettingProvider _instance;
        public static RemoteSettingProvider Instance
        {
            get { return _instance; }
        }
        
        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            
            //Use the current settings, before remote update, or default values if
            //the settings don't exist (yet)
            SpawnRateFactor
                = RemoteSettings.GetFloat("SpawnRateFactor", DefaultSpawnRateFactor);
            EnemySpeedFactor
                = RemoteSettings.GetFloat("EnemySpeedFactor", DefaultEnemySpeedFactor);
            EnemyStrengthFactor
                = RemoteSettings.GetFloat("EnemyStrengthFactor", DefaultEnemyStrengthFactor);
        }
    } 

Using this method, the default settings are always used the first time a player runs your game after installation. 

You can also use a hybrid approach that checks whether local settings exist using `RemoteSettings.GetCount()`. If the settings exist locally, you can use them immediately, but if not then you add an event handler to wait for the settings `Updated` event:

    SpawnRateFactor
        = RemoteSettings.GetFloat("SpawnRateFactor", DefaultSpawnRateFactor);
    EnemySpeedFactor
        = RemoteSettings.GetFloat("EnemySpeedFactor", DefaultEnemySpeedFactor);
    EnemyStrengthFactor
        = RemoteSettings.GetFloat("EnemyStrengthFactor", DefaultEnemyStrengthFactor);
                
        
    if(RemoteSettings.GetCount() == 0){
        //If there are no settings, get them from remote
        RemoteSettings.Updated += HandleRemoteSettings;
        Ready = false;
    } else {
        Ready = true;
    }


Other classes that use your remote settings must check the `Ready` property of your provider class to determine whether it is safe to access the settings. The following example illustrates a class that waits for the settings and also uses a configurable timeout:

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RemoteSettingConsumer : MonoBehaviour {
        public float SpeedFactor = 0;
        public float StrengthFactor = 0;
        public float SpawnRateFactor = 0;
        public float Timeout = 0.125f;
        
        void Start () {
            StartCoroutine(GetRemoteSettings(Time.time));
        }
    
        IEnumerator GetRemoteSettings(float startTime){
        
            while(!RemoteSettingProvider.Instance.Ready && (Time.time - startTime) < Timeout)
                yield return null;
                
            SpeedFactor = RemoteSettingProvider.Instance.EnemySpeedFactor;
            StrengthFactor = RemoteSettingProvider.Instance.EnemyStrengthFactor;
            SpawnRateFactor = RemoteSettingProvider.Instance.SpawnRateFactor;
        }
    }
 

If the timeout elapses before the remote settings become available, then your default values are used. Using a timeout allows the game to get the latest settings in the normal case where the network transaction completes in a very short amount of time, while not delaying startup unduly by waiting for the request itself to timeout in the case of network failure.


---

* <span class="page-edit">2018-08-23 <!-- include IncludeTextNewPageYesEdit --></span>
* <span class="page-history">New feature in 2017.1</span> 
* <span class="page-history">2018-08-23 - Updated event no longer dispatched every session as of 2018.1.</span>
* <span class="page-history">2018-08-23 - Service compatible with Unity 5.5 onwards at this date but version compatibility may be subject to change.</span>
 

