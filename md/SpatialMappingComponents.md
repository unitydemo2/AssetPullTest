# Spatial Mapping components

To facilitate Spatial Mapping in Unity and allow easy access to its features, Unity provides two Spatial Mapping XR [components](UsingComponents): 

* [Spatial Mapping Renderer](#SpatialMappingRenderer)

* [Spatial Mapping Collider](#SpatialMappingCollider)

You can use these components together or independently. Each Spatial Mapping component uses its own `SurfaceObserver` to understand changes to the physical world. Each Spatial Mapping component periodically queries the Spatial Mapping system to understand what changes have occurred in the physical environment (how often they perform these queries depends on how you configure them). When the system notifies the component of relevant changes, the component prioritizes baking the various changed Surfaces. 

The baking process involves generating a Mesh Filter with a Mesh that corresponds to the physical Surface. The components use this Mesh Filter in their own specific ways.

Each Spatial Mapping component is independent of other Spatial Mapping components. This means that each component maintains its own list of Surfaces, even if multiple components see the same Surface. We recommend that you limit the number of Spatial Mapping components you use, in order to optimize performance.

---

* <span class="page-edit">2018-05-01 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Spatial Mapping for Hololens documentation updated in 2017.3</span>