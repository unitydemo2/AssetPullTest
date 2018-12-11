# Spatial Mapping common troubleshooting issues

Spatial Mapping generates a large amount of data. This has an impact on your application’s speed and performance. This section discusses common issues that can arise from using Spatial Mapping, and guidance on how to avoid those issues.

## Collision data generation takes a long time

Generating collision data requires more CPU processing time than any other aspect of Spatial Mapping. Ensuring that collision data is only requested when necessary optimizes usage of CPU resources and increase battery life.

###Best practice solution:

* Only request collision data where necessary. Avoiding collision data requests when they are not necessary decreases the latency for other Spatial Mapping requests, and prolongs battery life.

* Use a __Surface’s__ update time and bounding boxes to prioritize data requests, and only request __Surfaces__ that are high priority. 

## High triangle densities generate large amounts of geometry

High values of [trianglesPerCubicMeter](ScriptRef:XR.WSA.SurfaceData-trianglesPerCubicMeter.html), set through the [SurfaceData](ScriptRef:XR.WSA.SurfaceData.html) struct when requesting __Surface__ data using the [RequestMeshAsync](ScriptRef:XR.WSA.SurfaceObserver.RequestMeshAsync.html) method, generate a very large amount of geometry in your Scene. This is especially true in spaces containing many objects (like a cluttered office). Large amounts of geometry in your Scene increase data generation latency and the memory usage of your application. Higher Mesh densities in your Scene can also slow down run-time systems such as rendering and physics, which can affect performance.

###Best practice solution:

Use the minimum resolution of Spatial Mapping data that your application requires. To do this, you need to test your application and the accuracy of the generated Spatial Mapping mesh, but the result is a balance of accuracy and performance that ultimately offers a much more positive user experience. Lower resolutions of generated Meshes result in less CPU time being spent by your application when the Mesh updates. This reduces the power consumption of your device, increases battery life, and also reduces latency in retrieving Mesh data. Lower resolution Meshes also use less memory and have a less impact on run-time systems such as rendering and physics (which expects low complexity geometry).

## Queuing too many Mesh requests results in unnecessary work

[SurfaceObservers](ScriptRef:XR.WSA.SurfaceObserver) report all added, updated, and removed __Surfaces__ within their volume when you call the [SurfaceObserver.Update](ScriptRef:XR.WSA.SurfaceObserver.Update) method.

This adds a list of all changed __Surfaces__ to the work queue and can result in unused __Surfaces__ remaining in the work queue after Spatial Mapping has removed them. These __Surfaces__ still take up CPU time when moving through the system, but do not generate any Mesh data. This increases the latency of any waiting requests.

###Best practice solution:

Limit the number of __Surfaces__ in the work queue where possible. Querying Meshes is an expensive operation with high latency, so keeping only a single [RequestMeshAsync](ScriptRef:XR.WSA.SurfaceObserver.RequestMeshAsync.html) request in use at any given time minimizes any slowdown that these operations cause. Applications can use a __Surface’s__ reported update time and bounds to prioritize `RequestMeshAsync` calls.

It is also important to prioritize __Surface__ data requests so that your application receives the most important data first. Examples of common ways to prioritize include:

* Prioritizing new __Surfaces__ above updating existing ones.

* Prioritizing __Surfaces__ that are closer to the user over those further away.

## Overlapping SurfaceObserver volumes create duplicate RequestMeshAsync calls

[SurfaceObservers](ScriptRef:XR.WSA.SurfaceObserver.html) report changes for all __Surfaces__ that overlap their volume. A __Surface__ can overlap multiple `SurfaceObserver` volumes if they are close together. This makes it possible for application code to request the same __Surfaces__ multiple times, which can lead to performance issues.

__Best practice solution:__

Use a single work submission queue for requests from `SurfaceObserver`. 

For many applications, a single `SurfaceObserver` is often all you need.  

Using a single `SurfaceObserver` can help you reduce the complexity of developing your application. However, there are several advanced uses for __Spatial Mapping__ that require multiple `SurfaceObserver` members. In these cases, you should use a single work queue for all `SurfaceObserver` members in your Scene in order to uniquely prioritize Mesh requests.

## Updating a SurfaceObserver generates no onSurfaceChanged callbacks

This is a common issue, typically caused by issues in the set-up process.

###Best practice solution:

Set a valid volume on your `SurfaceObserver`, using a method such as [SetVolumeAsAxisAlignedBox](ScriptRef:XR.WSA.SurfaceObserver.SetVolumeAsAxisAlignedBox.html).

You should also make sure that you enable the __Spatial Perception__ capability in __Publishing Settings__ (menu: __File > Build Settings > Player Settings > Publishing Settings)__. 

For more information relating to Capability and Publishing Settings for WMR, see Unity’s [Windows Mixed Reality quick starter guide](wmr_quick_start).

--

* <span class="page-edit">2018-05-01 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Spatial Mapping for Hololens documentation updated in 2017.3</span>