# Physics

Use the __Physics__ settings (main menu: **Edit** > **Project Settings**, then select the **Physics** category) to apply global settings for 3D physics. 

**Note:** To manage global settings for 2D physics, use the [Physics 2D](class-Physics2DManager) settings instead.

![3D Physics settings](../uploads/Main/PhysicsSet.png)



These settings define limits on the accuracy of the physical simulation. Generally speaking, a more accurate simulation requires more processing overhead, so these settings offer a way to trade off accuracy against performance. For more information, see the [Physics](PhysicsSection) section of the manual.

| **Property** || **Function** |
|:---|:---|:---|
| __Gravity__ || Use the x, y and z axes to set the amount of gravity applied to all Rigidbody components. For realistic gravity settings, apply a negative number to the y axis. Gravity is defined in world units per seconds squared. <br/>**Note**: If you increase the gravity, you might need to also increase the **Default Solver Iterations** value to maintain stable contacts. |
| __Default Material__ || Set a reference to the default Physics Material to use if none has been assigned to an individual Collider. |
| __Bounce Threshold__ || Set a velocity value. If two colliding objects have a relative velocity below this value, they do not bounce off each other. This value also reduces jitter, so it is not recommended to set it to a very low value. |
| __Sleep Threshold__ || Set a global energy threshold, below which a non-kinematic Rigidbody (that is, one that is not controlled by the physics system) may go to sleep. When a Rigidbody is sleeping, it is not updated every frame, making it less resource-intensive. If a Rigidbody’s kinetic energy divided by its mass is below this threshold, it is a candidate for sleeping. |
| __Default Contact Offset__ || Set the distance the collision detection system uses to generate collision contacts. The value must be positive, and if set too close to zero, it can cause jitter. This is set to 0.01 by default. Colliders only generate collision contacts if their distance is less than the sum of their contact offset values.  |
| __Default Solver Iterations__ || Define how many solver processes Unity runs on every physics frame. Solvers are small physics engine tasks which determine a number of physics interactions, such as the movements of joints or managing contact between overlapping Rigidbody components. <br />This affects the quality of the solver output and it’s advisable to change the property in case non-default `Time.fixedDeltaTime` is used, or the configuration is extra demanding. Typically, it’s used to reduce the jitter resulting from joints or contacts. |
| __Default Solver Velocity Iterations__ || Set how many velocity processes a solver performs in each physics frame. The more processes the solver performs, the higher the accuracy of the resulting exit velocity after a Rigidbody bounce. If you experience problems with jointed Rigidbody components or Ragdolls moving too much after collisions, try increasing this value. |
| __Queries Hit Backfaces__ || Enable this option if you want physics queries (such as `Physics.Raycast`) to detect hits with the backface triangles of MeshColliders. By default, this setting is disabled. |
| __Queries Hit Triggers__ || Enable this option if you want physics hit tests (such as Raycasts, SphereCasts and SphereTests) to return a hit when they intersect with a Collider marked as a Trigger. Individual raycasts can override this behavior. By default, this setting is enabled. |
| __Enable Adaptive Force__ || Enable this option to enable the adaptive force. The adaptive force affects the way forces are transmitted through a pile or stack of objects, to give more realistic behaviour. By default, this setting is disabled. |
|__Contacts Generation__||Choose a contact generation method.|
||_Legacy Contacts Generation_|Before Unity 5.5, Unity used a contacts generation method based on the separating axis theorem ([SAT](http://www.dyn4j.org/2010/01/sat/).<br/><br/>PCM is more efficient, but for older projects, you might find it easier to continue using SAT, to avoid needing to retweak physics slightly. PCM can result in a slightly different bounce, and fewer useless contacts end up in the contacts buffers (that is, the arrays you get in the [Collision](ScriptRef:Collision.html) instance passed to `OnCollisionEnter`, `OnCollisionStay`, and `OnCollisionExit`).<br/><br/>**Upgrade advice**: To migrate a Project made with Unity 2018.2 or lower, you might need to update your scripts to work with the code that merges patches in the manifold, and selects contacts.|
||_Persistent Contacts Manifold (PCM)_|Generates fewer contacts every physics frame, and more contact data is shared across frames. The PCM contacts generation path is also more accurate, and usually produces better collision feedback in most of the cases. For more information, see [Nvidia documentation on Persistent Contact Manifold](https://docs.nvidia.com/gameworks/content/gameworkslibrary/physx/guide/Manual/AdvancedCollisionDetection.html#persistent-contact-manifold-pcm).<br />This is the default value.|
| __Auto Simulation__ || Enable this option to run the physics simulation automatically or allow explicit control over it. |
| __Auto Sync Transforms__ || Enable this option to automatically sync transform changes with the physics system whenever a Transform component changes. |
| __Contact Pairs Mode__ || Choose the type of contact pair generation to use. |
||_Default Contact Pairs_|Receive collision and trigger events from all contact pairs except kinematic-kinematic and kinematic-static pairs.|
||_Enable Kinematic Kinematic Pairs_|Receive collision and trigger events from kinematic-kinematic contact pairs.|
||_Enable Kinematic Static Pairs_|Receive collision and trigger events from kinematic-static contact pairs.|
||_Enable All Contact Pairs_|Receive collision and trigger events from all contact pairs. |
| __Broadphase Type__ || Choose which [broad-phase algorithm](https://docs.nvidia.com/gameworks/content/gameworkslibrary/physx/guide/3.3.4/Manual/RigidBodyCollision.html#broad-phase-algorithms) to use in the physics simulation. See NVIDIA’s documentation on [PhysX SDK](https://docs.nvidia.com/gameworks/content/gameworkslibrary/physx/apireference/files/structPxBroadPhaseType.html) and [Rigid Body Collision](https://docs.nvidia.com/gameworks/content/gameworkslibrary/physx/guide/Manual/RigidBodyCollision.html). |
||_Sweep and Prune Broadphase__|Use the sweep-and-prune broad phase collision method (that is, sorting objects along a single axis to rule out having to check pairs that are far apart).|
||__Multibox Pruning Broadphase_|Multi-box pruning uses a grid, and each grid cell performs sweep-and-prune. This usually helps improve performance if, for example, there are many GameObjects in a flat world.|
| __World Bounds__ || Define the 2D grid that encloses the world to prevent far away objects from affecting each other when using the __Multibox Pruning Broadphase__ algorithm. <br />This option is only used when you set __Broadphase Type__ to __Multibox Pruning Broadphase__. |
| __World Subdivisions__ || The number of cells along the x and z axis in the 2D grid algorithm. <br />This option is only used when you set __Broadphase Type__ to __Multibox Pruning Broadphase__. |
|__Friction Type__||Choose the friction algorithm used for simulation.|
||_Patch Friction Type_|A basic strong friction algorithm which typically leads to the most stable results at low solver iteration counts. This method uses only up to four scalar solver constraints per pair of touching objects.|
||_One Directional Friction Type_|A simplification of the Coulomb friction model, in which the friction for a given point of contact is applied in the alternating tangent directions of the contact's normal. Reduces the number of iterations required for convergence but is not as accurate as the two-directional model.|
||_Two Directional Friction Type_|Like the one-directional model, but applies friction in both tangent directions simultaneously. This requires more solver iterations but is more accurate. More expensive than patch friction for scenarios with many contact points because it is applied at every contact point.|
|__Enable Enhanced Determinism__||Simulation in the scene is consistent regardless the actors present, provided that the game inserts the actors in a deterministic order. This mode sacrifices some performance to ensure this additional determinism. |
|__Enable Unified Heightmaps__||Enable this option to process Terrain collisions in the same way as Mesh collisions.|
| __Layer Collision Matrix__ || Define how the [layer-based collision](LayerBasedCollision) detection system behaves. Select which layers on the Collision Matrix interact with the other layers by checking them. |
| __Cloth Inter-Collision__ |||
| __Distance__ || Define the diameter of a sphere around each [intercolliding Cloth](class-Cloth#intercollision) particle. Unity ensures that these spheres do not overlap during simulations. Distance should be smaller than the smallest distance between two particles in the configuration. If the distance is larger, cloth collision may violate some distance constraints and result in jittering. |
| __Stiffness__ || How strong the separating impulse between [intercolliding Cloth](class-Cloth#intercollision) particles should be. The cloth solver calculates this and it should be enough to keep the particles separated.|


<br/>

---
* <span class="page-edit"> 2018-10-12  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Settings added in 5.5: Default Solver Iterations, Default Solver Velocity Iterations, Queries Hit Backfaces, Enable PCM</span>

* <span class="page-history">Physics Manager settings documentation updated in 2017.4</span>

* <span class="page-history">Friction Type, Enhanced Determinism and Unified Heightmaps physics settings added in [2018.3] (https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
