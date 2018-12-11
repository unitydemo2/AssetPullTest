# Spatial Mapping low level API

The Spatial Mapping Renderer and Collider components allow you to use the features of Spatial Mapping easily without worrying about the finer details of the system. If you want to have finer control over the Spatial Mapping in your application then use the low level API that Unity provides for Spatial Mapping.

The API provides a number of data structures and object types for accessing the Spatial Mapping information that the HoloLens gathers.

## SurfaceObserver

You can access Spatial Mapping data using a [SurfaceObserver](ScriptRef:XR.WSA.SurfaceObserver.html) . A `SurfaceObserver` is an API class which monitors a volume of real-world space for which the application requires Spatial Mapping data. The `SurfaceObserver` describes a physical area in the real-world and reports on the set of spatial Surfaces it intersects with that have been added, changed, or removed by the Spatial Mapping system.

Use of `SurfaceObservers` is only necessary if you wish to interact with Spatial Mapping directly through the Unity scripting API.

Unity provides its own Spatial Mapping Renderer and Collider components, built on the `SurfaceObserver` API to allow easy access to Spatial Mapping functionality. See documentation on [Spatial Mapping components](#SpatialMappingComponents) for more details on these. 

Using `SurfaceObserver`, applications can asynchronously request Mesh data with or without physics collision data. When the request is complete, another callback informs the application that the data is ready to use.

`SurfaceObserver` provides the following functionality to your application:

1. Issues [callbacks](https://en.wikipedia.org/wiki/Callback_(computer_programming)) upon request for Surface changes such as additions, removals, and updates.

2. Provides an interface for requesting Mesh data corresponding to a known Surface.

3. Issues [callbacks](https://en.wikipedia.org/wiki/Callback_(computer_programming)) when the Mesh data it requests is ready for use.

4. Provides ways of defining the location and volume of the `SurfaceObserver`.

## SurfaceData

[SurfaceData](ScriptRef:XR.WSA.SurfaceData.html) is a class which contains all the information required by the Spatial Mapping system to build and report on a __Surface’s__ Mesh data.

You must pass a populated `SurfaceData` object to the Spatial Mapping system using the [RequestMeshAsync](ScriptRef:XR.WSA.SurfaceObserver.RequestMeshAsync) method. When you initially call the [RequestMeshAsync](ScriptRef:XR.WSA.SurfaceObserver.RequestMeshAsync) method, you need to pass it a `SurfaceDataReadyDelegate`. When the Mesh data is ready the `SurfaceDataReadyDelegate` reports a matching `SurfaceData` object.

This allows the application to determine precisely which Surface the data corresponds to.

You should populate the `SurfaceData` GameObject using the information your application requires. This includes the following components and data:

* A [WorldAnchor](ScriptRef:XR.WSA.WorldAnchor) component

* A [MeshFilter](class-MeshFilter) component

* A [MeshCollider](class-MeshCollider) component (if physics data is required in your application)

* The triangles per cubic meter of the generated Mesh that you want

* The Surface ID

The system throws argument exceptions when you call the [RequestMeshAsync](ScriptRef:XR.WSA.SurfaceObserver.RequestMeshAsync) method with an incorrectly configured [SurfaceData](ScriptRef:XR.WSA.SurfaceData.html) object. Even if a `RequestMeshAsync` method call does not throw argument exceptions, there is no other way to check whether Spatial Mapping is creating and returning Mesh data successfully. We recommend that you keep track of the Mesh data you create manually through script.

## API usage example

The sample script below shows basic examples of using the important parts of the API.

```

using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA;
using UnityEngine.Rendering;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

public enum BakedState 
{
    NeverBaked = 0,
    Baked = 1,
    UpdatePostBake = 2
}

// This class holds data that is kept by the system to prioritize Surface baking.
class SurfaceEntry 
{
    public GameObject  m_Surface; // the GameObject corresponding to this Surface
    public int         m_Id; // ID for this Surface
    public DateTime    m_UpdateTime; // update time as reported by the system
    public BakedState  m_BakedState;
    public const float c_Extents = 5.0f;
}

public class SMSample : MonoBehaviour 
{
    // This observer is the window into the Spatial Mapping world.  
    SurfaceObserver m_Observer;

    // This dictionary contains the set of known Spatial Mapping Surfaces.
    // Surfaces are updated, added, and removed by the system on a regular basis.
    Dictionary<int, SurfaceEntry> m_Surfaces;

    // This is the material with which the system draws baked Surfaces.  
    public Material m_drawMat;

    // This flag is used by the Spatial Mapping system to postpone requests if a bake is in progress. 
    // Baking mesh data can take multiple frames.  This sample prioritizes baking request
    // order based on Surface data Surfaces and only issues a new request
    // if there are currently no requests being processed by the system.
    bool m_WaitingForBake;

    // This is the last time the SurfaceObserver was updated by the system. It updates no 
    // more than every two seconds
    float m_lastUpdateTime;

    void Start () 
    {
        m_Observer = new SurfaceObserver ();
        m_Observer.SetVolumeAsAxisAlignedBox (new Vector3(0.0f, 0.0f, 0.0f), 
            new Vector3 (SurfaceEntry.c_Extents, SurfaceEntry.c_Extents, SurfaceEntry.c_Extents));
        m_Surfaces = new Dictionary<int, SurfaceEntry> ();
        m_WaitingForBake = false;
        m_lastUpdateTime = 0.0f;
    }
    
    void Update () 
    {
        // Avoid calling Update on a SurfaceObserver too frequently.
        if (m_lastUpdateTime + 2.0f < Time.realtimeSinceStartup) 
        {
            // This block makes the observation volume follow the camera.
            Vector3 extents;
            extents.x = SurfaceEntry.c_Extents;
            extents.y = SurfaceEntry.c_Extents;
            extents.z = SurfaceEntry.c_Extents;
            m_Observer.SetVolumeAsAxisAlignedBox (Camera.main.transform.position, extents);

            try 
            {
                m_Observer.Update (SurfaceChangedHandler);
            } 
            catch 
            {
                // Update can throw an exception if the specified callback is bad.
                Debug.Log ("Observer update failed unexpectedly!");
            }

            m_lastUpdateTime = Time.realtimeSinceStartup;
        }
        if (!m_WaitingForBake) 
        {
            // Prioritize older adds over other adds over updates.
            SurfaceEntry bestSurface = null;
            foreach (KeyValuePair<int, SurfaceEntry> surface in m_Surfaces) 
            {
                if (surface.Value.m_BakedState != BakedState.Baked) 
                {
                    if (bestSurface == null) 
                    {
                        bestSurface = surface.Value;
                    } 
                    else 
                    {
                        if (surface.Value.m_BakedState < bestSurface.m_BakedState) 
                        {
                            bestSurface = surface.Value;
                        } 
                        else if (surface.Value.m_UpdateTime < bestSurface.m_UpdateTime) 
                        {
                            bestSurface = surface.Value;
                        }
                    }
                }
            }
            if (bestSurface != null) 
            {
                // Fill out and dispatch the request.
                SurfaceData sd;
                sd.id.handle = bestSurface.m_Id;
                sd.outputMesh = bestSurface.m_Surface.GetComponent<MeshFilter> ();
                sd.outputAnchor = bestSurface.m_Surface.GetComponent<WorldAnchor> ();
                sd.outputCollider = bestSurface.m_Surface.GetComponent<MeshCollider> ();
                sd.trianglesPerCubicMeter = 300.0f;
                sd.bakeCollider = true;
                try 
                {
                    if (m_Observer.RequestMeshAsync(sd, SurfaceDataReadyHandler)) 
                    {
                        m_WaitingForBake = true;
                    } 
                    else 
                    {
                        // A return value of false when requesting meshes 
                        // typically indicates that the specified
                        // Surface ID is invalid.
                        Debug.Log(System.String.Format ("Bake request for {0} failed.  Is {0} a valid Surface ID?", bestSurface.m_Id));
                    }
                }
                catch 
                {
                    // Requests can fail you do not fill out the data struct properly
                    Debug.Log (System.String.Format("Bake for id {0} failed unexpectedly!", bestSurface.m_Id));
                }
            }
        }
    }

    // This handler receives events when surfaces change, and propagates those events
    // using the SurfaceObserver’s Update method  
    void SurfaceChangedHandler (SurfaceId id, SurfaceChange changeType, Bounds bounds, DateTime updateTime) 
    {
        SurfaceEntry entry;
        switch (changeType) 
        {
            case SurfaceChange.Added:
            case SurfaceChange.Updated:
            if (m_Surfaces.TryGetValue(id.handle, out entry)) 
            {
                // If the system as already baked this Surface, mark it as needing to be baked
                // in addition to the update time so the "next Surface to bake" 
                // logic orders it correctly.  
                if (entry.m_BakedState == BakedState.Baked) 
                {
                    entry.m_BakedState = BakedState.UpdatePostBake;
                    entry.m_UpdateTime = updateTime;
                }
            } 
            else 
            {
                // This is a brand new Surface so create an entry for it.
                entry = new SurfaceEntry ();
                entry.m_BakedState = BakedState.NeverBaked;
                entry.m_UpdateTime = updateTime;
                entry.m_Id = id.handle;
                entry.m_Surface = new GameObject (System.String.Format("Surface-{0}", id.handle));
                entry.m_Surface.AddComponent<MeshFilter> ();
                entry.m_Surface.AddComponent<MeshCollider> ();
                MeshRenderer mr = entry.m_Surface.AddComponent<MeshRenderer> ();
                mr.shadowCastingMode = ShadowCastingMode.Off;
                mr.receiveShadows = false;
                entry.m_Surface.AddComponent<WorldAnchor> ();
                entry.m_Surface.GetComponent<MeshRenderer> ().sharedMaterial = m_drawMat;
                m_Surfaces[id.handle] = entry;
            }
            break;

            case SurfaceChange.Removed:
            if (m_Surfaces.TryGetValue(id.handle, out entry)) 
            {
                m_Surfaces.Remove (id.handle);
                Mesh mesh = entry.m_Surface.GetComponent<MeshFilter> ().mesh;
                if (mesh) 
                {
                    Destroy (mesh);
                }
                Destroy (entry.m_Surface);
            }
            break;
        }
    }

    void SurfaceDataReadyHandler(SurfaceData sd, bool outputWritten, float elapsedBakeTimeSeconds) 
    {
        m_WaitingForBake = false;
        SurfaceEntry entry;
        if (m_Surfaces.TryGetValue(sd.id.handle, out entry)) 
        {
            // These two asserts check that the returned filter and WorldAnchor
            // are the same as those used by the system to request the data. This should always
            // be true unless you have changed code to replace or destroy them.
            Assert.IsTrue (sd.outputMesh == entry.m_Surface.GetComponent<MeshFilter>());
            Assert.IsTrue (sd.outputAnchor == entry.m_Surface.GetComponent<WorldAnchor>());
            entry.m_BakedState = BakedState.Baked;
        } 
        else 
        {
            Debug.Log (System.String.Format("Paranoia:  Couldn't find surface {0} after a bake!", sd.id.handle));
            Assert.IsTrue (false);
        }
    }
}
```

__Note:__ Calling the [SurfaceObserver’s Update](ScriptRef:XR.WSA.SurfaceObserver.Update) method can be resource-intensive, so you should try not to do it more than an application requires. Calling this method once every three seconds should be enough for most applications.

--

* <span class="page-edit">2018-05-01 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Spatial Mapping for Hololens documentation updated in 2017.3</span>