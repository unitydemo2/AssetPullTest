# Lightmap Parameters

A Lightmap Parameters Asset stores a set of values for the parameters which control Unity’s [Global Illumination](GIIntro) (GI) features. These Assets allow you to define and save different sets of values for lighting, for use in different situations. 

To create a new Lightmap Parameters Asset, right-click in the Project window and go to __Create__ &gt; __New Parameters Asset__. Unity stores this in your Project folder.

![A Lightmap Parameters Asset called __New LightmapParameters__, shown in the Project window](../uploads/Main/LightmapParameters1.png)

Lightmap Parameters Assets allow you to quickly create presets optimized for different types of GameObjects, or for different platforms and different Scene types (for example, indoor or outdoor Scenes).

When you click on a Lightmap Parameters Asset in the Project window, the Inspector window displays the values defined in that Asset. The parameters and their descriptions are listed in the table below.

![](../uploads/Main/LightmapParameters2.png)

## Precomputed Realtime GI

| __Property__| __Function__ | 
|:---|:---|
| __Resolution__| This value scales the __Realtime Resolution__ value in the Scene tab of the Lighting Window (menu: __Window__ &gt; __Rendering__ &gt; __Lighting Settings__ &gt; __Scene__) to give the final resolution of the lightmap in texels per unit of distance. | 
| __Cluster Resolution__| The ratio of the cluster resolution (the resolution at which the light bounces are calculated internally) to the final lightmap resolution. See documentation on [GI Visualizations in the Scene view](GIVis) for more information. | 
| __Irradiance Budget__| This value determines the precision of the incoming light data used to light each texel in the lightmap. Each texel’s lighting is obtained by sampling a "view" of the Scene from the texel’s position. Lower values of irradiance budget result in a more blurred sample. Higher values increase the sharpness of the sample. A higher irradiance budget improves the lighting, but this increases run-time memory usage and might increase CPU usage. | 
| __Irradiance Quality__| Use the slider to define the number of rays that are cast and used to compute which clusters affect a given output lightmap texel. Higher values offer visual improvements in the lightmap, but increase precomputing time in the Unity Editor. The value does not affect runtime performance. | 
| __Modelling Tolerance__| This value controls the minimum size of gaps in Mesh geometry that allows light to pass through. Make this value lower to allow light to pass through smaller gaps in your environment. | 
| __Edge Stitching__| If enabled, this property indicates that UV charts in the lightmap should be joined together seamlessly, to avoid unwanted visual artifacts. | 
| __Is Transparent__| If enabled, the object appears transparent during the Global Illumination calculations. Back-faces do not contribute to these calculations, and light travels through the surface. This is useful for invisible emissive surfaces. | 
| __System Tag__| A group of objects whose lightmap Textures are combined in the same lightmap atlas is known as a “system”. The Unity Editor automatically defines additional systems and their accompanying atlases if all the objects can’t be fitted into a single atlas. However, it is sometimes useful to define separate systems yourself (for example, to ensure that objects inside different rooms are grouped into one system per room). Change the __System Tag__ number to force new system and lightmap creation. The exact numeric sequence values of the tag are not significant. | 

## Baked GI

| __Property__| __Function__ |  |
|:---|:---|:---| 
| | __Enlighten__ | __Progressive Lightmapper__ |
| __Blur Radius__| The radius of the blur filter that is applied to direct lighting during post-processing in texels. The radius is essentially the distance over which neighboring texels are averaged out. A larger radius gives a more blurred effect. Higher levels of blur tend to reduce visual artifacts but also soften the edges of shadows. | __Blur Radius__ is not available when you use Progressive Lightmapper. |
| __Anti-aliasing Samples__| The degree of anti-aliasing (the reduction of "blocky" artifacts) that is applied. Higher numbers increase quality and bake time. | The number of times to supersample a texel to reduce aliasing. Samples [1;3] disables supersampling, samples [4;8] give 2x supersampling, and samples [9;256] give 4x supersampling. This mostly affects the amount of memory used for the positions and normals buffers (2x uses four times the amount of memory, 4x uses 16 times the amount of memory). |
| __Direct Light Quality__| The number of rays used to evaluate direct lighting. A higher number of rays tends to produce more accurate soft shadows but increases bake time. | __Direct Light Quality__ is not available when you use Progressive Lightmapper. |
| __Backface Tolerance__| The structure of a Mesh sometimes causes some texels to have a “view” that includes back-facing geometry. Incoming light from a backface is meaningless in any Scene. Because of this, this property lets you select a percentage threshold of light that must come from front-facing geometry in order for a texel to be considered valid. Invalid texels have their lighting approximated from their neighbors’ values. Lowering this value can solve lighting problems caused by incoming light from backfaces. | The percentage of rays shot from an output texel that must hit front faces to be considered usable. Allows a texel to be invalidated if too many of the rays cast from it hit backfaces (the texel is inside some geometry). In that case artefacts are avoided by cloning valid values from surrounding texels. For example, if backface tolerance is 0.0, the texel is rejected only if it sees nothing but backfaces. If it is 1.0, the ray origin is rejected if it has even one ray that hits a backface. In the Baked Texel Validity scene view mode one case see valid (green) and invalid (red) texels. If you have a single sided mesh in your scene, you may want to disable this feature by setting it to zero. A two-sided flag will later be added in the editor to address this. |
| __Baked Tag__| Similar to the __System Tag__ property above, this number lets you group specific sets of objects together in separate baked lightmaps. As with the System Tag, the exact numeric value is not significant. Objects with different Baked Tag values are never put in the same atlas; however, there is no guarantee that objects with the same tag end up in the same atlas, because those objects might not necessarily fit into one lightmap (see image A, below, for an example of this). You don’t have to set this when using the multi-scene bake API, because grouping is done automatically (use the __Baked Tag__ to replicate some of the behavior of the __Lock Atlas__ option). See [Baked Tags: Details](#BakedTags), below, for more information. ||
| __Pushoff__| The distance to push away from the surface geometry before starting to trace rays in modelling units. It is applied to all baked lightmaps, so it affects direct light, indirect light, and AO. __Pushoff__ is useful for getting rid of unwanted AO or shadowing. Use this setting to solve problems where the surface of an object is shadowing itself, causing speckled shadow patterns to appear on the surface with no apparent source. You can also use this setting to remove unwanted artifacts on huge objects, where floating point precision isn’t high enough to accurately ray-trace fine detail. | The amount to push off ray origins away from geometry along the normal for ray tracing, in modelling units. It is applied to all baked lightmaps, so it affects direct light, indirect light and ambient occlusion. It is useful for getting rid of unwanted occlusion/shadowing. |

<a name="BakedTags"> </a>

### Baked Tags: Details

![](../uploads/Main/LightmapParameters.jpg)

The image above shows two views of the same Scene:

1. __Left:__ Everything is in one atlas because all the GameObjects have the same __Baked Tag__.

2. __Right:__ One GameObject is assigned a different __Baked Tag__, and forced into a second lightmap.

## Baked AO

| __Property__| __Function__ |
|:---|:---|
| __Quality__| The number of rays cast when evaluating ambient occlusion (AO). A higher numbers of rays increases AO quality but also increases bake time.|
| __Anti-aliasing Samples__| The number of samples to take when doing anti-aliasing of AO. A higher number of samples increases the AO quality but also increases the bake time.|



## General GI

| __Property__| __Function__ |
|:---|:---|
| __Backface Tolerance__| The percentage of rays shot from an output texel that must hit front faces for the lighting system to consider them usable. This allows Unity to invalidate a texel if too many of the rays cast from it hit back faces ( (for example, if the texel is inside some geometry). The lighting system clones valid values from the surrounding texels to avoid unintended artifacts.<br/><br/>If __Backface Tolerance__ is 0.0, the lighting system rejects the texel only if it sees nothing but backfaces. If it is 1.0, the lighting system rejects the ray origin if it has even one ray that hits a backface. |



## Assigning Lightmap Parameters Assets

### Scenes

To assign a Lightmap Parameters Asset to the whole Scene, open the [Lighting window](GlobalIllumination) (__Window__ &gt; __rendering__ &gt; __Lighting Settings__), click the __Scene__ tab, and navigate to the __General GI__ settings.

![](../uploads/Main/LightmapParameters3.png)

Use the __Default Parameters__ drop-down to assign a default Lightmap Parameters Asset. This drop-down lists all available Lightmap Parameters Assets.

![](../uploads/Main/LightmapParameters4.png)

### GameObjects

To assign a Lightmap Parameters Asset to a single GameObject, ensure the GameObject has a Mesh Renderer or Terrain component attached. 

![](../uploads/Main/LightmapParameters5.png)

To assign a Lightmap Parameters Asset to a Mesh Renderer, tick the component’s __Lightmap Static__ checkbox and select an option from __Lightmap Parameters __under __Lightmap Settings__. Choose __Scene Default Parameter__ to use the same Lightmap Parameters Asset that is assigned to the whole Scene.

![](../uploads/Main/LightmapParameters6.png)

To assign a Lightmap Parameters Asset to a Terrain, tick the Terrain’s __Lightmap Static__ checkbox and select an option from __Advanced Parameters__. Choose __Scene Default Parameters__ to use the same Lightmap Parameters Asset that is assigned to the whole Scene.

---

<span class="page-edit"> 2018-03-28  <!-- include IncludeTextAmendPageSomeEdit --></span>

<span class="page-history">Progressive Lightmapper added in [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) <span class="search-words">NewIn20181</span></span>