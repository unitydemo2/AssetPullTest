#Mesh Collider

The __Mesh Collider__ takes a [Mesh Asset](class-Mesh) and builds its Collider based on that Mesh. It is far more accurate for collision detection than using primitives for complicated Meshes. Mesh Colliders that are marked as __Convex__ can collide with other Mesh Colliders.


![](../uploads/Main/Inspector-MeshCollider.png) 


##Properties

|**_Property_** ||**_Function_** |
|:---|:---|:---|
|__Convex__ ||Tick the checkbox to enable __Convex__. If enabled, this Mesh Collider collides with other Mesh Colliders. __Convex__ Mesh Colliders are limited to 255 triangles. |
|__Is Trigger__ ||If enabled, Unity uses this Collider for triggering events, and the physics engine ignores it. |
|__Cooking Options__ ||Enable or disable the [Mesh cooking](#cooking) options that affect how the physics engine processes Meshes.|
||__None__|Disable all of the __Cooking Options__ listed below.|
||__Everything__|Enable all of the __Cooking Options__ listed below.|
||__Cook for Faster Simulation__|Make the physics engine cook Meshes for faster simulation. When enabled, this runs some extra steps to guarantee the resulting Mesh is optimal for run-time performance. This affects the performance of the physics queries and contacts generation. When this setting is disabled, the physics engine uses a faster cooking time instead, and produces results as fast as possible. Consequently, the cooked Mesh Collider might not be optimal.|
||__Enable Mesh Cleaning__|Make the physics engine clean Meshes. When enabled, the cooking process tries to eliminate [degenerate triangles](https://en.wikipedia.org/wiki/Degeneracy_(mathematics)#Triangle) of the Mesh, as well as other geometrical artifacts. This results in a Mesh that is better suited for use in collision detection and tends to produce more accurate hit points.|
||__Weld Colocated Vertices__|Make the physics engine remove equal vertices in the Meshes. When enabled, the physics engine combines the vertices that have the same position. This is important for the collision feedback that happens at run time.|
|__Material__ ||Reference to the [Physics Material](class-PhysicMaterial) that determines how this Collider interacts with others. |
|__Mesh__ ||Reference to the Mesh to use for collisions. |


##Details

The Mesh Collider builds its collision representation from the [Mesh](class-Mesh) attached to the GameObject, and reads the properties of the attached [Transform](class-Transform) to set its position and scale correctly. The benefit of this is that you can make the shape of the Collider exactly the same as the shape of the visible Mesh for the GameObject, resulting in more precise and authentic collisions. However, this precision comes with a higher processing overhead than collisions involving primitive colliders (such as Sphere, Box, and Capsule) and so it is best to use Mesh Colliders sparingly.

Faces in collision meshes are one-sided. This means objects can pass through them from one direction, but collide with them from the other.

<a name="cooking"></a>
## Mesh cooking

Mesh cooking changes a normal Mesh into a Mesh that you can use in the physics engine. Cooking builds the spatial search structures for the physics queries, such as [Physics.Raycast](ScriptRef:Physics.Raycast.html), as well as supporting structures for the contacts generation. Unity cooks all Meshes before using them in collision detection. This can happen at import time (__Import Settings > Model > Generate Colliders__) or at run time.

When generating Meshes at run time (for example, for procedural surfaces), it's useful to set the __Cooking Options__ to produce results faster, and disable the additional data cleaning steps of cleaning. The downside is that you need to generate no degenerate triangles and no co-located vertices, but the cooking works faster. 

If you disable __Enable Mesh Cleaning__ or __Weld Colocated Vertices__, you need to ensure you aren't using data that those algorithms would otherwise filter. Make sure you don't have any co-located vertices if __Weld Colocated Vertices__ is disabled, and when __Enable Mesh Cleaning__ is enabled, make sure there are no tiny triangles whose area is close to zero, no thin triangles, and no huge triangles whose area is close to infinity.

**Note**: Setting __Cooking Options__ to any other value than the default settings means the Mesh Collider must use a Mesh that has an [isReadable](ScriptRef:Mesh-isReadable.html) value of true.

## Limitations

There are some limitations when using the Mesh Collider:

Mesh Colliders that do not have __Convex__ enabled are only supported on GameObjects without a Rigidbody component. To apply a Mesh Collider to a Rigidbody component, tick the __Convex__ checkbox.

For a Mesh Collider to work properly, the Mesh must be read/write enabled in any of these circumstances:

- The Mesh Collider's Transform has negative scaling (for example, (–1, 1, 1)) and the Mesh is convex.
- The Mesh Collider's transform is skewed or sheared (for example, when a rotated transform has a scaled parent transform).
- The Mesh Collider's Cooking Options flags are set to any value other than the default.


__Optimization tip:__ If a Mesh is used only by a Mesh Collider, you can disable __Normals__ in __Import Settings__, because the physics system doesn’t need them.

---

* <span class="page-history">Updated Mesh Collider limitations in 2018.3</span>

* <span class="page-edit">2018-10-12 <!-- include IncludeTextAmendPageYesEdit --></span>

* <span class="page-history">Mesh Cooking Options added in [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>

* <span class="page-history">Updated functionality in 2018.1</span>

* <span class="page-history">Updated limitations relating to read/write enabled setting in 2017.3</span>

* <span class="page-history">Inflate Convex Mesh deprecated in 2018.3 because the new convex hull computation algorithm (Quickhull) is more tolerant towards imperfections in the input mesh.</span>