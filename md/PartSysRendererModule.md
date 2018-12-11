# Renderer module

The Renderer module’s settings determine how a particle’s image or [Mesh](class-Mesh) is transformed, shaded and overdrawn by other particles.

![](../uploads/Main/PartSysRendererModule-0.png)


## Properties

| **Property**| **Function** |
|:---|:---| 
| __Render Mode__| How the rendered image is produced from the graphic image (or Mesh). See [Details](#Details), below, for more information. |
|&nbsp;&nbsp;&nbsp;&nbsp;Billboard| The particle always faces the Camera. |
|&nbsp;&nbsp;&nbsp;&nbsp;Stretched Billboard| The particle faces the Camera but with various scaling applied (see below). |
|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Camera Scale| Stretches particles according to Camera movement. Set this to 0 to disable Camera movement stretching. |
|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Velocity Scale| Stretches particles proportionally to their speed. Set this to 0 to disable stretching based on speed. |
|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Length Scale| Stretches particles proportionally to their current size along the direction of their velocity. Setting this to 0 makes the particles disappear, having effectively 0 length. |
|&nbsp;&nbsp;&nbsp;&nbsp;Horizontal Billboard| The particle plane is parallel to the XZ "floor" plane. |
|&nbsp;&nbsp;&nbsp;&nbsp;Vertical Billboard| The particle is upright on the world Y-axis, but turns to face the Camera. |
|&nbsp;&nbsp;&nbsp;&nbsp;Mesh| The particle is rendered from a 3D Mesh instead of a Texture. |
|&nbsp;&nbsp;&nbsp;&nbsp;None| This can be useful when using the [Trails](PartSysTrailsModule) module, if you want to only render the trails and hide the default rendering. |
| __Normal Direction__| Bias of lighting normals used for the particle graphics. A value of 1.0 points the normals at the Camera, while a value of 0.0 points them towards the center of the screen (Billboard modes only). |
| __Material__| Material used to render the particles. |
| __Trail Material__| Material used to render particle trails. This option is only available when the __Trails__ module is enabled. |
| __Sort Mode__| The order in which particles are drawn (and therefore overlaid). The possible values are __By Distance (from the Camera__), __Oldest in Front__, and __Youngest in Front__. Each particle within a system will be sorted according to this setting. |
| __Sorting Fudge__| Bias of particle system sort ordering. Lower values increase the relative chance that particle systems are drawn over other transparent GameObjects, including other particle systems. This setting only affects where an entire system appears in the scene - it does not perform sorting on individual particles within a system. |
| __Min Particle Size__| The smallest particle size (regardless of other settings), expressed as a fraction of viewport size. Note that this setting is only applied when the __Rendering Mode__ is set to __Billboard__. |
| __Max Particle Size__| The largest particle size (regardless of other settings), expressed as a fraction of viewport size. Note that this setting is only applied when the __Rendering Mode__ is set to __Billboard__. |
| __Render Alignment__| Use the drop-down to choose which direction particle billboards face. |
|&nbsp;&nbsp;&nbsp;&nbsp;View| Particles face the Camera plane. |
|&nbsp;&nbsp;&nbsp;&nbsp;World| Particles are aligned with the world axes. |
|&nbsp;&nbsp;&nbsp;&nbsp;Local| Particles are aligned to the Transform component of their GameObject.|
|&nbsp;&nbsp;&nbsp;&nbsp;Facing| Particles face the direct position of the Camera GameObject. |
| __Enable GPU Instancing__| Control whether the Particle System will be rendered using GPU Instancing. Requires using the Mesh Render Mode, and using a compatible shader. See [Particle Mesh GPU Instancing](PartSysInstancing) for more details. |
| __Flip__| Mirror a proportion of the particles across the specified axes. A higher value flips more particles. |
| __Allow Roll__| Control whether camera-facing particles can rotate around the Z-axis of the camera. Disabling this can be particularly useful for VR applications, where HMD roll can give undesirable results for Particle Systems. |
| __Pivot__| Modify the central pivot point for rotating particles. The value is a multiplier of the particle size. |
| __Visualize Pivot__| Preview the particle pivot points in the Scene View. |
| __Masking__| Set how the particles rendered by the Particle System behave when interacting with a Sprite Mask. |
|&nbsp;&nbsp;&nbsp;&nbsp;No Masking| The Particle System does not interact with any Sprite Masks in the Scene. This is the default option.  |
|&nbsp;&nbsp;&nbsp;&nbsp;Visible Inside Mask| The particles are visible where the Sprite Mask overlays them, but not outside of it. |
|&nbsp;&nbsp;&nbsp;&nbsp;Visible Outside Mask| The particles are visible outside of the Sprite Mask, but not inside it. The Sprite Mask hides the sections of the particles it overlays. |
| __Apply Active Color Space__| When rendering in Linear Color Space, the system converts particle colors from Gamma Space before uploading them to the GPU. |
| __Custom Vertex Streams__| Configure which particle properties are available in the Vertex Shader of your Material. See [Particle Vertex Streams](PartSysVertexStreams) for more details. |
| __Cast Shadows__| If enabled, the particle system creates shadows when a shadow-casting Light shines on it. |
|&nbsp;&nbsp;&nbsp;&nbsp;On| Select __On__ to enable shadows.  |
|&nbsp;&nbsp;&nbsp;&nbsp;Off| Select __Off__ to disable shadows. |
|&nbsp;&nbsp;&nbsp;&nbsp;Two-Sided| Select __Two Sided__ to allow shadows to be cast from either side of the Mesh (meaning backface culling is not taken into account). |
|&nbsp;&nbsp;&nbsp;&nbsp;Shadows Only| Select __Shadows Only__ to make it so that the shadows are visible, but the Mesh itself is not. |
| __Shadow Bias__| Move the shadows along the direction of the light, in order to remove shadowing artifacts caused by approximating volumes with billboards. |
| __Receive Shadows__| Dictates whether shadows can be cast onto particles. Only opaque materials can receive shadows. |
| __Sorting Layer__| Name of the Renderer’s sorting layer. |
| __Order in Layer__| This Renderer’s order within a sorting layer. |
| __Light Probes__| Probe-based lighting interpolation mode. |
| __Reflection Probes__| If enabled and reflection probes are present in the Scene, a reflection texture is picked for this GameObject and set as a built-in Shader uniform variable. |
| __Anchor Override__| A Transform used to determine the interpolation position when the [Light Probe](LightProbes) or [Reflection Probe](ReflectionProbes) systems are used. |

<a name="Details"> </a>
## Details

The __Render Mode__ lets you choose between several 2D Billboard graphic modes and Mesh mode. Using 3D Meshes gives particles extra authenticity when they represent solid GameObjects, such as rocks, and can also improve the sense of volume for clouds, fireballs and liquids. Meshes must be read/write enabled to work on the Particle System. If you assign them in the editor Unity handles this for you but if you want to assign different meshes at runtime you need to handle this setting yourself.

When 2D billboard graphics are used, the different options can be used for a variety of effects:

1. __Billboard mode__ is good for particles representing volumes that look much the same from any direction (such as clouds).

2. __Horizontal Billboard__ mode can be used when the particles cover the ground (such as target indicators and magic spell effects) or when they are flat objects that fly or float parallel to the ground (for example, shurikens).

3. __Vertical Billboard__ mode keeps each particle upright and perpendicular to the XZ plane, but allows it to rotate around its y-axis. This can be helpful when you are using an orthographic Camera and want particle sizes to stay consistent.

4. __Stretched Billboard__ mode accentuates the apparent speed of particles in a similar way to the "stretch and squash" techniques used by traditional animators. Note that in Stretched Billboard mode, particles are aligned to face the Camera and also aligned to their velocity. This alignment occurs regardless of the Velocity Scale value - even if Velocity Scale is set to 0, particles in this mode still align to the velocity.

The Normal Direction can be used to create spherical shading on the flat rectangular billboards. This can help create the illusion of 3D particles if you are using a Material that applies lighting to your particles. This setting is only used with the Billboard render modes.

---
* <span class="page-edit">2018-10-16  <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">GPU instancing added in Unity  2018.1</span>
* <span class="page-history">New particle system options added to Renderer module in [2018.3] (https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>

