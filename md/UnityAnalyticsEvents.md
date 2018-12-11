# Analytics events

Unity collects Analytics data by dispatching events when someone uses your application or game. Unity dispatches a set of core events automatically. You can dispatch additional events to collect richer and deeper information about how users play your game or use your application.

The types of Analytics events include:

* [Core Events](UnityAnalyticsCoreEvents): Session-based and device-based events.
* [Standard Events](UnityAnalyticsStandardEvents): Behavioral events with standard names and parameters for tracking user experience and player behavior.
* [Custom Events](UnityAnalyticsCustomEvents): Fully-customizable events whose names, purposes and parameters you define as needed.
* [Transaction Events](UnityAnalyticsMonetization): Specialized events you can use to track in-app purchase (IAP) transactions made through 3rd-party IAP APIs.
* Other: Specialized events, like [Heatmap](https://bitbucket.org/Unity-Technologies/heatmaps/wiki/v2.md) events, intended for a specific purpose. Such events are usually based on Custom Events, but the APIs for sending them control the event names and parameters.

Unity dispatches Core Events automatically. You must dispatch the other types of events at the appropriate times. You can dispatch Standard and Custom Events from an [Analytics Event Tracker Component](class-AnalyticsEventTracker) or from a script.

Your Unity game or app sends Analytics events to a Unity web service. The Analytics system collects the raw events and processes them for display on your project’s Analytics Dashboard. If the computer or device running the application cannot connect to the web service, Unity caches the events locally until the connection becomes available.

Note: If you have a Unity Pro subscription, you can [download the raw event data](UnityAnalyticsRawDataExport) directly. You can import this raw data into your own analytics tools and perform ad-hoc analyses that may not be supported by the Unity Analytics Dashboard.

## Standard Events versus Custom Events

Standard Events are a form of Custom Event. The difference is that Standard Events are standardized. Each Standard Event has a predefined event name and a set of required parameters. Standardization provides several benefits:

* Helps avoid easy-to-make coding errors, such as using slightly different names and parameters for what should be the same event.
* Provides a guide for useful places in your application to dispatch an Analytics event.
* Provides a known context for an event, which the Unity Analytics system can use to provide more meaningful Analytics reports.

Because of these benefits, you should use Standard Events rather than Custom Events whenever possible. Only use Custom Events when no Standard Event is appropriate.

---

* <span class="page-edit">2018-03-02 <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-edit">2018-06-04 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-history">New feature in 5.2</span>

* <span class="page-history">2018-06-04 - Demographics event removed</span>
