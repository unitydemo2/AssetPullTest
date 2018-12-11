# Analytics Event limits

To maintain an efficient and responsive service, Analytics imposes limits on the Standard and Custom Events a given instance of your game or application can send. These limits include:

* 100 events per hour (per instance of your game).
* 10 parameters per event.
* 500 bytes or characters of data sent in a single event, including the string length of parameter names and the byte size or string length of the parameter values.
* 100 characters in the name of a custom event .
* The Analytics Dashboard shows only the 5,000 most frequent event, parameter, parameter value combinations (for categorizable parameter values) in a given day.

All of the [AnalyticsEvent](AnalyticsEvent) functions that send events, return a value from the [AnalyticsResult](Scriptref:AnalyticsResult.html) enumeration. If an application exceeds one of the limits, the `AnalyticsResult` value identifies the specific error encountered:

| **`AnalyticsResult`** | **Limit Exceeded** |
|:---|:---| 
| `AnalyticsResult.TooManyRequests`| 100 events per hour |
| `AnalyticsResult.TooManyItems`| 10 parameters per event |
| `AnalyticsResult.SizeLimitReached`| 500 bytes of data or 100 characters in the event name |

__Note:__ The 100 events per instance limit is a default that suits the majority of Unity Analytics users. If you need a higher event limit for a game or application, contact the [Analytics support team](https://analytics.cloud.unity3d.com/support/) to work out a limit suitable to your requirements.


## Single Event data limit

You can send up to 500 characters or bytes of data as part of a single Custom or Standard Event. This limit counts the combined string lengths of all the parameter names and the following sizes for parameter values (depending on data type):

| C# Data Type| Size |
|:---|:---| 
| byte, ubyte| 1 |
| short, ushort| 4 (converted to int) |
| Int, uint| 4 |
| long, ulong| 8 |
| float| 8 (converted to double) |
| double| 8 |
| decimal| 8 (converted to double) |
| string| String length |
| object| String length after calling `ToString()` |

For example, the following event uses 67 bytes/characters of the data length limit:

        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("int_param", 32); // 9 characters + 4 bytes
        data.Add("bool_param", true); // 10 characters + 1 byte
        data.Add("float_param", 3.3f); // 11 characters + 8 bytes
        data.Add("string_param", "String value"); // 12 characters + 12 characters
        AnalyticsResult result = AnalyticsEvent.Custom("custom_event", data);

When you send a Standard Event that defines its own required or optional parameters, the lengths of names and values of the required parameters, and those of any optional parameters, are included in the 500 byte limit, along with any custom data. 

The length of the name of an event itself cannot exceed 100 characters in length, but this length is not counted against the 500 byte limit for the event data. 

---

* <span class="page-history">Page added 10/14/2018</span>