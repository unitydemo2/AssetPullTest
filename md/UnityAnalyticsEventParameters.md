# Analytics event parameters

Both Standard and Custom events allow you to send additional information to the Analytics Service as part of an event. The only difference between Standard and Custom Events is that most Standard Events have required or optional parameters which take precedence over any custom parameters. 

Pass your custom parameters to the appropriate [AnalyticsEvent](ScriptRef:Analytics.AnalyticsEvent.html) function in the form of a `Dictionary<string, object>` instance. The keys of this dictionary are the parameter names, and the values are the parameter values. When creating this dictionary, maintain consistent key names and data types for each parameter in your event data, both within a single version of your game as well as from version to version. For example, don’t send a level name parameter as a number sometimes and as a string at other times. Doing this can make your data difficult to interpret. 

**Note:** Do not begin the key names of the custom parameter dictionary with the prefix "unity", which is reserved for internal Unity Analytics events.

Unity serializes values sent to the Analytics service. It parses number characters as numbers even if the data type you add to the dictionary is a string. In other words, adding the string "_51_" to the parameter dictionary is equivalent to adding the number _51_.

You can pass up to ten parameters with an event. For Standard Events, this limit includes the required parameters and any optional parameters to which you assign a value (unused optional parameters don’t count against this limit). In addition, the length of an individual key name and string value passed to the event must not exceed 100 characters and the total length of all key names and string values must not exceed 500 characters.

For efficiency, you can create the parameter dictionary instance as a class member and reuse the dictionary each time you dispatch the event. Reusing the dictionary object avoids allocating memory each time you send the event. This reduces the memory allocations that the C# garbage collector needs to clean up. The more frequently you dispatch an event in a Scene, the more benefit this technique provides. The following example defines a class that dispatches a Custom event. The class defines a parameter dictionary as an instance variable and sets the parameter values each time it sends an event. 

````
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MyCustomAnalyticsEvent : MonoBehaviour {
    private const string Name = "my_custom_event";

    private Dictionary<string, object> parameters 
        = new Dictionary<string, object>();

    void Start(){
        // Define parameters with default values
        parameters.Add("character_class", "Unknown");
        parameters.Add("health", 0);
        parameters.Add("xp", 0);
        parameters.Add("world_x", 0);
        parameters.Add("world_y", 0);
        parameters.Add("world_z", 0);
    }

    public bool Dispatch(string characterClass, 
                         int health, 
                         int experience, 
                         Vector3 location){
                         
        // Set parameter values for a specific event
        parameters["character_class"] = characterClass;
        parameters["health"] = health;
        parameters["xp"] = experience;
        parameters["world_x"] = location.x;
        parameters["world_y"] = location.y;
        parameters["world_z"] = location.z;

        // Send event
        AnalyticsResult result 
            = AnalyticsEvent.Custom(Name, parameters);
        if(result == AnalyticsResult.Ok){
            return true;
        } else {
            return false;
        }
    }
}
````

You can use the same technique for the custom parameters you send with Standard events.

---

* <span class="page-edit">2018-03-02 <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-edit">2018-03-02 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-history">New feature in 5.2</span>

