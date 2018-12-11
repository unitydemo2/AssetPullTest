# Custom Events

Custom Events can be any specific in-game action your user performs. They allow you to track the player behavior that Unity Analytics does not track automatically, and for which there is no Standard Event. Each Custom Event can have up to ten parameters. There are no required parameters. 

In general, you should only using Custom Events when no suitable Standard Event is defined. Because Standard Events have a defined context, Unity can provide better analysis and visualization support than for Custom Events.

You can send a Custom Event to the Analytics Service using the [Analytics Event Tracker](class-AnalyticsEventTracker) component. Just select __Custom__ instead of a Standard Event. You can also send Custom Events [using code](UnityAnalyticsCustomEventScripting).

---

* <span class="page-edit">2018-03-02 <!-- include IncludeTextNewPageNoEdit --></span>
<span class="page-edit">2018-03-02 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-history">New feature in 5.2</span>

* <span class="page-history">Standard Events added as Unity package</span>
 

