# Core Events

Core Events are session-based and device-based Analytics events. When you enable Unity Analytics for your project, Unity dispatches Core Events automatically. Core Events provide the basis for several metrics computed by the Analytics system, including:

* New installs
* Daily active users (DAU)
* Monthly active users (MAU)
* Total sessions
* Sessions per user
* Time spent in app
* User Segments for country and platform
* Revenue (when using Unity Ads and/or Unity IAP)

See [Analytics Metrics, Segments, and Terminology](UnityAnalyticsTerminology) for the definitions of these metrics.

Core Events include:

* __AppStart__: Dispatched at the start of a new session. A new session starts when the user first launches an app or brings an app to the foreground after more than 30 minutes of inactivity. 
* __AppRunning__: Dispatched periodically while an app runs.
* __DeviceInfo__: Dispatched the first time a user launches an app and whenever device information changes. 

In addition to viewing the metrics based on core events in the Analytics Dashboard, you can download the events themselves using Raw Data Export. Note that Raw Data Export requires a Unity Pro subscription.

**Note:** Analytics uses other Core Events, such as __AppStop__, __AppUpdate__, and __AppInstall__, to calculate metrics, but does not expose them through [Raw Data Export](UnityAnalyticsRawDataExport).



---

* <span class="page-edit">2018-06-22 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-edit">2018-03-02 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-edit">2018-06-04 - Removed UserInfo core event.</span>

* <span class="page-history">New feature in 5.2</span>