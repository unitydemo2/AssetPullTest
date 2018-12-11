# Model tab

The __Import Settings__ for a Model file appear in the __Model__ tab of the Inspector window when you select the Model. These settings affect various elements and properties stored inside the Model. Unity uses these settings to import each Asset, so you can adjust any settings to apply to different Assets in your Project.

![Import settings for the Model](../uploads/Main/FBXImporter-Model.png) 

This section provides information about each of the sections on the Model tab:

![A](../uploads/Main/LetterCircle_A.png) [Scene](#sceneprops)-level properties, such as whether to import Lights and Cameras, and what scale factor to use. 

![B](../uploads/Main/LetterCircle_B.png) Properties specific to [Meshes](#meshprops).

![C](../uploads/Main/LetterCircle_C.png) [Geometry](#geoprops)-related properties, for dealing with topology, UVs, and normals.



<a name="sceneprops"></a>

## Scene

|**_Property_** |**_Function_** |
|:---|:---|
|__Scale Factor__ |Set this value to apply a global scale on the imported Model whenever the original file scale (from the Model file) does not fit the intended scale in your Project. Unity's physics system expects 1 meter in the game world to be 1 unit in the imported file. |
|__Convert Units__ |Enable this option to convert the [Model scaling](HOWTO-ImportObjectsFrom3DApps#Scaling) defined in the Model file to Unity's scale. |
|__Import BlendShapes__ |Allow Unity to import BlendShapes with your Mesh.<br/><br/>**Note** Importing blendshape normals requires smoothing groups in the FBX file.|
|__Import Visibility__ |Import the FBX settings that define whether or not MeshRenderer components are enabled (visible). See [Importing Visibility](#VisibilityImportProperties) below for details.|
|__Import Cameras__ |Import cameras from your .FBX file. See [Importing Cameras](#CameraImportProperties) below for details.|
|__Import Lights__ |Import lights from your .FBX file. See [Importing Lights](#LightImportProperties) below for details.|
|__Preserve Hierarchy__ |Always create an explicit prefab root, even if this model only has a single root. Normally, the FBX Importer strips any empty root nodes from the model as an optimization strategy. However, if you have multiple FBX files with portions of the same hierarchy you can use this option to preserve the original hierarchy. <br/><br/>For example, file1.fbx contains a rig and a Mesh and file2.fbx contains the same rig but only the animation for that rig. If you import file2.fbx without enabling this option, Unity strips the root node, the hierarchies don't match, and the animation breaks. |



<a name="VisibilityImportProperties"></a>

### Importing visibility 
Unity can read visibility properties from FBX files with the **Import Visibility** property. Values and animation curves can enable or disable MeshRenderer components by controlling the [Renderer.enabled](ScriptRef:Renderer-enabled.html) property.

Visibility inheritance is true by default but can be overridden. For example, if the visibility on a parent Mesh is set to 0, all of the renderers on its children are also disabled. In this case, one animation curve is created for each child's `Renderer.enabled` property.

Some 3D modeling applications either do not support or have limitations regarding visibility properties. For more information, see:

 - [Importing objects from Autodesk® Maya®](HOWTO-ImportObjectsFrom3DApps#Maya)
 - [Importing objects from Cinema 4D](HOWTO-ImportObjectsFrom3DApps#Cinema4D)
 - [Importing objects from Blender](HOWTO-ImportObjectsFrom3DApps#Blender)



<a name="CameraImportProperties"></a>

### Importing cameras
Unity supports the following properties when importing Cameras from an .FBX file:


|**Property:** |**Function:** |
|:---|:---|
|__Projection__ mode|Orthographic or perspective. Does not support animation.|
|__Field of View__ |Supports animation.|
|All __Physical Camera__ properties |If you import a Camera with Physical Properties (for example, from from Maya), Unity creates a Camera with the __Physical Camera__ property enabled and the __Focal Length__, __Sensor Type__, __Sensor Size__, __Lens Shift__, and __Gate Fit__ values from the FBX file.<br />***Note:*** Not all 3D modeling applications have a concept of *Gate Fit*. When not supported by the 3D modeling application, the default value in Unity is **None**.|
|__Near__ and __Far__ __Clipping Plane__ distance |Unity does not import any animation on these properties. When exporting from 3ds Max, enable the __Clip Manually__ setting; otherwise the default values are applied on import.|
|__Target Cameras__ |If you import a Target Camera, Unity creates a camera with a [LookAt](class-LookAtConstraint) constraint using the target object as the source.|



<a name="LightImportProperties"></a>

### Importing lights

The following Light types are supported: 

* Omni
* Spot
* Directional
* Area

The following Light properties are supported:


|**Property:** |**Function:** |
|:---|:---|
|__Range__|The __FarAttenuationEndValue__ is used if __UseFarAttenuation__ is enabled. __FarAttenuationEndValue__ does not support animation.|
|__Color__|Supports animation.|
|__Intensity__|Supports animation.|
|__Spot Angle__|Supports animation. Only available for Spot lights.|

**Note**: In 3ds Max, the exported default value is the value of the property at the current selected frame. To avoid confusion, move the playhead to frame 0 when exporting.


#### Limitations
Some 3D modeling applications apply scaling on light properties. For instance, you can scale a spot light by its hierarchy and affect the light cone. Unity does not do this, which may cause lights to look different in Unity.  

The FBX format does not define the width and height of area lights. Some 3D modeling applications don't have this property and only allow you to use scaling to define the rectangle area. Because of this, area lights always have a size of 1 when imported.

Targeted light animations are not supported unless their animation is baked.



<a name="meshprops"></a>
## Meshes property section

|**_Property_** ||**_Function_** |
|:---|:---|:---|
|__Mesh Compression__ ||Set the level of compression ratio to reduce the file size of the Mesh. Increasing the compression ratio lowers the precision of the Mesh by using the mesh bounds and a lower bit depth per component to compress the mesh data.<br/><br/>It’s best to turn it up as high as possible without the Mesh looking too different from the uncompressed version. This is useful for [optimizing game size](ReducingFilesize).|
||__Off__|Don't use compression.|
||__Low__|Use a low compression ratio.|
||__Medium__|Use a medium compression ratio.|
||__High__|Use a high compression ratio.|
|__Read/Write Enabled__ ||When this option is enabled, Unity uploads the Mesh data to GPU-addressable memory, but also keeps it in CPU-addressable memory. This means that Unity can access the mesh data at run time, and you can access it from your scripts. For example, if you're generating a mesh procedurally, or if you want to copy some data from a mesh. When this option is disabled, Unity uploads the Mesh data to GPU-addressable memory, and then removes it from CPU-addressable memory. <br/><br/>In most cases, you should disable this option to save runtime memory usage. For information on when to enable Read/Write Enabled, see [Mesh.isReadable](ScriptRef:Mesh-isReadable).|
|__Optimize Mesh__ ||Let Unity determine the order in which triangles are listed in the Mesh. Unity reorders the vertices and indices for better GPU performance.|
|__Generate Colliders__ ||Enable to import your Meshes with Mesh Colliders automatically attached. This is useful for quickly generating a collision Mesh for environment geometry, but should be avoided for geometry you are moving. |



<a name="geoprops"></a>
## Geometry properties section

|**_Property_** ||**_Function_** |
|:---|:---|:---|
| __Keep Quads__ || Enable this to stop Unity from converting polygons that have four vertices to triangles. For example, if you are using [Tessellation Shaders](SL-SurfaceShaderTessellation), you may want to enable this option because tessellating quads may be more efficient than tessellating polygons. <br/><br/>Unity can import any type of polygon (triangle to N-gon). Polygons that have *more* than four vertices are always converted to triangles regardless of this setting. However, if a mesh has quads and triangles (or N-gons that get converted to triangles), Unity creates two submeshes to separate quads and triangles. Each submesh contains either triangles only or quads only. <br/><br/>**Tip:** If you want to import quads into Unity from 3ds Max, you have to [export it as an Editable Poly](HOWTO-exportFBX#Quads). |
|__Weld Vertices__ ||Combine vertices that share the same position in space, provided that they share the same properties overall (including, UVs, Normals, Tangents, and VertexColor). <br /><br />This optimizes the vertex count on Meshes by reducing their overall number. This option is enabled by default. <br/><br/>In some cases, you might need to switch this optimization off when importing your Meshes. For example, if you intentionally have duplicate vertices which occupy the same position in your Mesh, you may prefer to use scripting to read or manipulate the individual vertex and triangle data. |
|__Index Format__ ||Define the size of the Mesh index buffer. <br/><br/>**Note:** For bandwidth and memory storage size reasons, you generally want to keep __16 bit__ indices as default, and only use __32 bit__ when necessary, which is what the __Auto__ option uses. |
||__Auto__ |Let Unity decide whether to use 16 or 32 bit indices when importing a Mesh, depending on the Mesh vertex count. This is the default for Assets added in Unity 2017.3 and onwards. |
||__16 bit__ |Use 16 bit indices when importing a Mesh. If the Mesh is larger, then it is split into <64k vertex chunks. This was the default setting for Projects made in Unity 2017.2 or previous.|
||__32 bit__ |Use 32 bit indices when importing a Mesh. If you are using GPU-based rendering pipelines (for example with compute shader triangle culling), using 32 bit indices ensures that all Meshes use the same index format. This reduces shader complexity, because they only need to handle one format. |
|__Normals__ ||Defines if and how normals should be calculated. This is useful for [optimizing game size](ReducingFilesize). |
||__Import__ |Import normals from the file. This is the default option.|
||__Calculate__ |Calculate normals based on __Normals Mode__, __Smoothness Source__, and __Smoothing Angle__ (below). |
||__None__ |Disable normals. Use this option if the Mesh is neither normal mapped nor affected by realtime lighting. |
|__Blend Shape Normals__ ||Defines if and how normals should be calculated for blend shapes. Use the same values as for the __Normals__ property. |
|__Normals Mode__ || Define how the normals are calculated by Unity. This is only available when __Normals__ is set to __Calculate__. |
||__Unweighted Legacy__ | The legacy method of computing the normals (prior to version 2017.1).  In some cases it gives slightly different results compared to the current implementation. It is the default for all FBX prefabs imported before the migration of the Project to the latest version of Unity. |
||__Unweighted__ | The normals are not weighted. |
||__Area Weighted__ | The normals are weighted by face area. |
||__Angle Weighted__ | The normals are weighted by the vertex angle on each face. |
||__Area and Angle Weighted__ | The normals are weighted by both the face area and the vertex angle on each face. This is the default option.|
|__Smoothness Source__ ||Set how to determine the smoothing behavior (which edges should be smooth and which should be hard). |
||__Prefer Smoothing Groups__ | Use smoothing groups from the Model file, where possible. |
||__From Smoothing Groups__ | Use smoothing groups from the Model file only. |
||__From Angle__ | Use the __Smoothing Angle__ value to determine which edges should be smooth. |
||__None__ | Don't split any vertices at hard edges. |
|__Smoothing Angle__ ||Control whether vertices are split for hard edges: typically higher values result in fewer vertices. <br/><br/>**Note:** Use this setting only on very smooth organics or very high poly models. Otherwise, you are better off manually smoothing inside your 3D modeling software and then importing with the __Normals__ option set to __Import__ (above). Since Unity bases hard edges on a single angle and nothing else, you might end up with smoothing on some parts of the Model by mistake.<br/><br/>Only available if __Normals__ is set to __Calculate__. |
|__Tangents__ ||Define how vertex tangents should be imported or calculated. This is only available when __Normals__ is set to __Calculate__ or __Import__. |
||__Import__ |Import vertex tangents from FBX files if __Normals__ is set to __Import__. If the Mesh has no tangents, it won't work with normal-mapped shaders.|
||__Calculate Tangent Space__ |Calculate tangents using MikkTSpace. This is the default option if __Normals__ is set to __Calculate__. |
||__Calculate Legacy__ |Calculate tangents with legacy algorithm.|
||__Calculate Legacy - Split Tangent__ |Calculate tangents with legacy algorithm, with splits across UV charts. Use this if normal map lighting is broken by seams on your Mesh. This usually only applies to characters. |
||__None__ |Don't import vertex tangents. The Mesh has no tangents, so this doesn't work with normal-mapped shaders. |
|__Swap UVs__ ||Swap UV channels in your Meshes. Use this option if your diffuse Texture uses UVs from the lightmap. Unity supports up to eight UV channels but not all 3D modeling applications export more than two. |
|__Generate Lightmap UVs__ ||Creates a second UV channel for Lightmapping. See documentation on [Lightmapping](GIIntro) for more information.|

---

* <span class="page-edit"> 2018-09-26  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2018-08-23  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2017-12-05  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2017-09-04  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Existing (pre Unity 5.6) functionality of __Keep Quads__ first documented in User Manual 5.6</span>

* <span class="page-history">__Normals Mode__, __Light__ and __Camera__ import options added in Unity [2017.1](../Manual/30_search.html?q=newin20171) <span class="search-words">NewIn20171</span></span>

* <span class="page-history">__Materials__ tab added in [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) <span class="search-words">NewIn20172</span></span>

* <span class="page-history">__Index Format__ property added in [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>

* <span class="page-history">Updated description of read/write enabled setting and reorganized properties table, to match improvements in Unity [2017.3](../Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>
