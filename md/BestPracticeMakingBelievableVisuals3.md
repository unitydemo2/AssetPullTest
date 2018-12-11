# Lighting strategy

Before starting to create final Assets and approach lighting for a Scene, you need to figure out your lighting strategy. Altering your lighting strategy late in development has a high impact on your workflow. Taking the time to get this right before you enter production saves time overall, and allows you to achieve better performance and higher visual fidelity.

As with all development, there’s almost always a trade-off between the benefits and impacts of one setup over another. There are times, however, where certain technologies give you options to mitigate these trade-offs within specific constraints. Knowing each feature’s trade-offs allows you to choose what’s best for your project. 

A typical daytime Scene with outdoor areas has the following lighting components:

* Hemisphere lighting (sky contribution)
* Direct lights (Sun + local lights)
* Indirect lights (bounced and reflected lighting)

![](../uploads/Main/BelievableVisualsHemisphereLighting.png)

This seems like three simple components. But because you can mix and match __Realtime__ lights, __Mixed__ lights, __Baked__ lights, static GameObjects and dynamic GameObjects, you can end up with a diverse range of lighting options.

Unity caters to lots of different lighting strategies and project scenarios. To understand lighting modes and setup, see documentation on [Lighting Modes](LightModes).

For newcomers, it can be overwhelming to figure out which setup works best for their Scene, and what the trade-offs are. So let’s consider the most commonly used lighting setups:

* [Basic real-time lighting](#realtime): The specular highlights from the light are visible, but there is no indirect lighting.
* [Baked lighting](#baked): Soft baked shadows are visible, and static indirect lighting is visible in high resolution, but there are no specular highlights from lights, and dynamically lit GameObjects don’t cast shadows.
* [Mixed lighting](#mixed): Similar to __Baked__ lighting, but there is specular response from lights, and dynamically lit GameObjects do cast shadows.
* [Real-time lighting and GI](#realtimeGI): Proper indirect lighting response and specular response are visible, lights are all moveable and updateable, but there’s no angular soft shadow.
* [All options enabled](#all)): Depending on the settings of each light, you can achieve the combination of all the above options.

The following images show the notable differences between these setups:

![Five different lighting modes without Ambient Occlusion or Baked lighting enabled](../uploads/Main/BelievableVisuals5LightModes.gif)


![Four different lighting modes with Ambient Occlusion and Baked lighting enabled](../uploads/Main/BelievableVisuals4LightModes.gif)


__Note__: __Realtime GI__ can’t bake static ambient occlusion, so it’s not included.

<a name="realtime"></a>
## Basic real-time lighting and ambient (with no Realtime GI or Baked GI)

Basic real-time lighting is generally used in stylistic visual projects and prototype phases.

![Basic real-time lighting](../uploads/Main/BelievableVisualsBaked.gif)

**Typical platform target**: Console and PC

**Advantages**:

* All direct lights and shadows are applied in real time, and are therefore movable.
* Allows for fast iteration, because there is no precomputation, baking, or mesh preparation.
* Dynamic and Static GameObjects are lit using the same method, so Light Probes are not required.

**Disadvantages**:

* No hemisphere occlusion, just skybox/ambient value, and the color in the area is not lit by direct lighting.
* Without GI or indirect lighting component, the Scene might not give the best visual outcome.

<a name="baked"></a>
## All baked lighting and Light Probes

Baked lighting is generally useful for games where run-time performance is an issue but there’s room in memory, such as top-down isometric mobile games and high frame-rate VR games.

![Comparison for full baked lighting with and without Ambient Occlusion](../uploads/Main/BelievableVisualsBakedLightProbes.gif)

**Typical platform target**: Mobile platform, VR, console and low end PC

**Advantages**:

* All lights are baked for static GameObjects. They produce ambient occlusion and indirect lighting.
* Unity can bake area light bake support and soft shadow angles onto statically lit GameObjects.
* Fastest run-time performance among the common setups listed here.

**Disadvantages**:

* Can slow down lighting iteration because lights are baked, which means Unity needs to re-compute lights whenever the Scene changes (unless you’re using Progressive Lightmapper)
* Dynamically lit GameObjects are only lit using Light Probes.
* Specular highlights only rely on cubemaps and reflections, not on light sources.
* There is no shadowing from dynamic GameObjects.
* Can require a lot of run-time memory, depending on how many light map textures are used in the Scene.
* Might require authoring texture coordinates channel 2 (UV2 for light map) if GameObjects texture charts overlap.

<a name="mixed"></a>
## Mixed lighting with Shadowmask and Light Probes

Mixed lighting is often useful in games where time-of-day lighting (such as sun movement) is not important.

![Comparison for __Shadowmask__ __Mixed__ Lighting with and without Ambient Occlusion](../uploads/Main/BelievableVisualsShadowmaskLightProbes.gif)

**Typical platform target**: VR, console and PC

**Advantages**:

* Similar to all Baked lighting, but in Mixed lighting, Dynamic GameObjects get real-time specular lighting and cast real-time shadows, while static GameObjects get baked shadowmasking, resulting in better visual quality.

**Disadvantages**:

* GameObjects have a limit of 4 Shadowmasks. Additional shadow casting lights gets baked.
* Rendering real-time lights at run time is more resource-intensive.
* Mixed lights can drastically affect performance in certain setups.

For more information on Shadowmask lighting, see [Shadowmask](LightMode-Mixed-Shadowmask).

<a name="realtimeGI"></a>
## Real-time lighting with Realtime GI and Light Probes

This setup is useful in open area games where you need time-of-day lighting updates (such as the sun moving) and dynamic lighting effects.

![Realtime GI, showcasing indirect lighting updates as the directional light changes](../uploads/Main/BelievableVisualsRealtimeGILightProbes.gif)

**Typical platform target**: Console and PC

**Advantages**:

* This allows for fast lighting iteration with real-time indirect lighting.
* Dynamic and static GameObjects get real-time specular lighting and shadows.
* Can use less memory than Baked lighting for indirect lighting.
* Has a fixed CPU performance impact for updating global illumination.

**Disadvantages**:

* Occlusion isn’t as detailed as Baked lighting, and usually must be augmented by Screen Space Ambient Occlusion (SSAO) and per-object texture baked AO.
* No area/light angle soft shadows for static GameObjects.
* Real-time lights can drastically affect performance in certain setups.
* Precompute times can take a significant amount of time if there are too many GameObjects contributing to the static lighting, especially without an optimized UV setup. For more information, see [Global Illumination UVs](LightingGiUvs).

For in-depth information on optimizing __Realtime GI__, see Unity’s tutorial on [Introduction to Precomputed Realtime GI](https://unity3d.com/learn/tutorials/topics/graphics/introduction-precomputed-realtime-gi).

<a name="all"></a>
## All options enabled

You would only want to generally enable all lighting options in games with high fidelity requirements that have tightly controlled memory usage and performance limits. You should only do this if you fully understand each individual system, and know how to handle each lighting combination.

![All options enabled, allowing all possible lighting techniques available in Unity](../uploads/Main/BelievableVisualsAllLightOptions.gif)

**Typical platform target**: Console and PC

**Advantages**:

* This is the complete set of lighting features, giving you full functionality.

**Disadvantages**:

* Has high performance requirements at run time, with high memory usage.
* Increases the workflow time, by requiring more UV authoring and baking time.

To help you learn about lighting, the Spotlight Tunnel Sample Scene uses real-time lighting with Realtime GI. This provides a diverse range of specular responses, good bounce lighting, and allows you to quickly iterate on lighting.

---

* <span class="page-edit">2018-03-21  <!-- include IncludeTextNewPageSomeEdit --></span>
* <span class="page-history">Making believable visuals Best Practice Guide added in Unity 2017.3</span>