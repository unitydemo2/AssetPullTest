# Dynamic lighting

Dynamically-lit GameObjects, especially large GameObjects, require more tricks than their static counterparts. GameObjects usually require dynamic lighting if they change position in the Scene, so pre-calculated lighting isn’t an option. However, dynamic GameObjects have to work within certain limitations. To improve the quality of dynamic GameObject lighting, consider:

* [Light Probe Proxy Volume (LPPV)](#lppv)
* [Per-object baked Ambient Occlusion Map (AO)](#aoMap)
* [Local Reflection](#reflection)
* [Fake Shadows or occlusion based on assumptions](#assumptions)

<a name="lppv"></a>
## Light Probe Proxy Volume (LPPV)

The surfaces of dynamic GameObjects that aren’t lit by dynamic lighting generally use Light Probe data to fill in their lighting information (in a Scene where Light Probes are not present, Environment Lighting is used). Depending on the lighting strategy used in a Scene, this can range from indirect lighting information to shadowing and baked diffused Light Probe lighting information. This Light Probe strategy usually works fine for small dynamic GameObjects. However, larger GameObjects require a finer granularity of Light Probe lighting. This is where Light Probe Proxy Volumes come in. For more information, see [Light Probe Proxy Volume component](class-LightProbeProxyVolume).

Using Light Probe Proxy Volumes allows a large dynamically-lit GameObject to use more than a single Light Probe, resulting in higher lighting accuracy. The following example shows how the capsule with LPPV demonstrates higher accuracy of Light Probe sampling, despite only using 2x2x2 Volume grid:

![Capsule comparison showing impact of LLPV](../uploads/Main/BelievableVisualsLPPVCapsule.jpg)

<a name="aoMap"></a>
## Per-object baked Ambient Occlusion Map (AO)


Dynamic GameObjects only receive lighting from Light Probes or ambient lights. So you need to pre-calculate an occlusion for the GameObject, especially if the GameObject involves a concave interior, such as the tram in the example. In the example below, the tram on the left without AO is applying Light Probe lighting data without knowing how to differentiate the interior and the exterior surfaces. With the pre-baked AO, this map serves as a guide to reduce the intensity of light and reflection from the exterior, giving a much more grounded look:

![Tram comparison showing impact of AO](../uploads/Main/BelievableVisualsBakedAO.jpg)

Per-GameObject AO offline baking can even give further detailed occlusion by baking from a higher detailed mesh to lower a detailed mesh, in a similar way to how normal map baking works. 

**Note**: Per-GameObject AO doesn’t interact with other dynamic GameObjects. For example, a dynamic GameObject (such as character entering the tram) receives Light Probe data from the Scene and doesn’t necessarily match the occlusion of the tram interior.

<a name="reflection"></a>
## Local reflection

Most dynamic GameObjects don’t need their own reflection. However, for GameObjects that involve concave interiors, attaching a Reflection Probe to the GameObject and allowing it to run in real time can help reduce false reflection hits coming from the environment Reflection Probe.

![Exaggerated material showing reflection issues](../uploads/Main/BelievableVisualsLocalReflection.jpg)

<a name="assumptions"></a>
## Fake shadows or occlusion based on assumptions

If you can make certain assumptions for a GameObject, there are tricks that you can use to improve visual quality. In the sample shown below, the tram should always be on the rails. So to help its ground light occlusion in shaded areas, we can use a "Particle/Multiply" transparent material plane:

![Simple Plane trick using a Particle/Multiply transparent material](../uploads/Main/BelievableVisualsFakeShadows.jpg)

A similar trick is to place a blob shadow projector under a character instead of the character casting real shadows. 

In real-time rendering, if you can find a trick that works, and it’s cheap on performance, it’s usually a viable solution. There are certainly more tips and tricks that improve visual rendering. The above list should give you confidence in thinking of solutions for different kinds of visual requirements.

---

* <span class="page-edit">2018-03-21  <!-- include IncludeTextNewPageSomeEdit --></span>
* <span class="page-history">Making believable visuals Best Practice Guide added in Unity 2017.3</span>