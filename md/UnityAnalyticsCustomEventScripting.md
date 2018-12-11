# Custom Event scripting

As an alternative to using the [AnalyticsEventTracker](class-AnalyticsEventTracker) component, you can send Custom Events directly via script by calling [AnalyticsEvent.Custom](Scriptref:AnalyticsEvent.Custom.html):

```
// Reference the Unity Analytics namespace
using UnityEngine.Analytics;

//  Use this call for wherever a player triggers a custom event
AnalyticsEvent.Custom(string customEventName, IDictionary<string, object> eventData);
```

## Analytics.CustomEvent Input Parameters

|**_Name_** |**_Type_** |**_Description_** |
|:---|:---|:---|
|__customEventName__ |string |Name of the custom event. The name cannot include the prefix "unity", which is reserved for internal Unity Analytics events. |
|__eventData__ |dictionary |Additional parameters sent to Unity Analytics at the time the custom event was triggered. eventData keys cannot include the prefix "unity", which is reserved for internal Unity Analytics events.|

The following example sends a Custom Event when a player finds a secret location in a level:

```
public void ReportSecretFound(int secretID){
    AnalyticsEvent.Custom("secret_found", new Dictionary<string, object>
    {
        { "secret_id", secretID },
        { "time_elapsed", Time.timeSinceLevelLoad }
    });
}
```

---

* <span class="page-edit">2018-03-02 <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-edit">2018-03-02 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-history">New feature in 5.2</span>

* <span class="page-history">Standard Events added as Unity package.</span>
 
