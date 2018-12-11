# Importing objects from FBX files

When Unity imports a proprietary file, it launches the 3D modeling software in the background. Unity then communicates with that proprietary software to convert the native file into a format Unity can read. 

The first time you import a proprietary file into Unity, the 3D modeling software has to launch in a command-line process. This can take a while, but subsequent imports are very quick.

## Requirements

You need to have the 3D modeling software installed to import proprietary files directly into Unity. 
If you don't have the software installed, use the FBX format instead. 
For more information about importing FBX files, see [Importing models](class-FBXImporter).

## Application-specific issues

You [import files](class-FBXImporter) in the same way, regardless of whether they are generic or proprietary files. However, there are some differences between which features are supported. For more information on the limitations with a specific 3D application, see:

* [Importing objects from Autodesk® Maya®](#Maya)
* [Importing objects from Cinema 4D](#Cinema4D)
* [Importing objects from Autodesk® 3ds Max®](#Max)
* [Importing objects from Cheetah3D](#Cheetah3D)
* [Importing objects from Modo](#Modo)
* [Importing objects from LightWave](#Lightwave)
* [Importing objects from Blender](#Blender)
* [Importing objects from SketchUp](HOWTO-ImportObjectSketchUp)


<a name="Maya"></a>
## Importing objects from Autodesk® Maya®

Unity imports Autodesk® Maya® files (*.mb* and *.ma*) through the FBX format, supporting the following:

* All nodes with position, rotation and scale; pivot points and names are also imported
* Meshes with vertex colors, normals and up to 2 UV sets
* Materials with texture and diffuse color; multiple materials per mesh
* Animation 
* Joints
* Blendshapes
* Lights and Cameras
* Visibilty
* Custom property animation

*Tip*: To optimize importing your Autodesk® Maya® file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).

### Limitations

Unity does not support Autodesk® Maya®'s _Rotate Axis_ (pre-rotation).

Joint limitations include: 

* _Joint Orient_ (joint only post-rotation)
* _Segment Scale Compensate_ (joint only option)

Unity imports and supports any _Rotate Order_ you specify in Autodesk® Maya®; however, once imported, you cannot change that order again inside Unity. 
If you import a Model that uses a different rotation order from Unity's, Unity [displays that rotation order](AnimationEulerCurveImport#RotationOrder) in the __Inspector__ beside the __Rotation__ property.

### Tips and troubleshooting

* Keep your scene simple: only export the objects you need in Unity when exporting.
* Unity only supports polygons, so convert any patches or NURBS surfaces into polygons before exporting; see [Autodesk® Maya® documentation](https://knowledge.autodesk.com/support/maya/learn-explore/caas/CloudHelp/cloudhelp/2015/ENU/Maya/files/Polygon-selection-and-creation-Convert-NURBS-surfaces-to-a-polygon-mesh-htm.html) for instructions.
* If your model did not export correctly, the node history in Autodesk® Maya® might be causing a problem. In Autodesk® Maya®, select **Edit** &gt; **Delete by Type** &gt; **Non-Deformer History** and then re-export the model.
* The Autodesk® Maya® FBX Exporter bakes un-supported complex animations constraints, such as Set Driven Keys, in order to import the animation into Unity properly. If you are using Set Driven Keys in Autodesk® Maya®, make sure to set keys on your drivers in order for the animation to be baked properly. For more information, see the Autodesk® Maya® documentation on Keyframe Animation.
* In Autodesk® Maya®, the visibility value is present on each shape but can't be animated and is not exported to the FBX file. Always set the visibility value on a node and not on a shape. 


<a name="Cinema4D"></a>
## Importing objects from Cinema 4D

Unity imports Cinema 4D files (*.c4d*) through the FBX format, supporting the following:

 * All objects with position, rotation and scale; pivot points and names are also imported
 * Meshes with UVs and normals
 * Materials with texture and diffuse color; multiple materials per mesh
 * Animations FK (IK needs to be baked manually)
 * Bone-based animations

*Tip*: To optimize importing your Cinema 4D file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).


### Limitations

Unity does not import Cinema 4D's Point Level Animations (PLA). Use bone-based animations instead.

Cinema 4D does not export visibility inheritance. Set the Renderer to ‘Default' or ‘Off' in Cinema 4D to avoid any difference in the visibility animation between Cinema4D and Unity.



<a name="Max"></a>
## Importing Objects From Autodesk® 3ds Max®

Unity imports Autodesk® 3ds Max® files (*.max*) through the FBX format, supporting the following:

* All nodes with position, rotation and scale; pivot points and names are also imported
* Meshes with vertex colors, normals and one or more UV sets
* Materials with diffuse texture and color. Multiple materials per mesh
* Animations
* Bone-based animations
* Morphing (Blendshapes)
* Visibility

**Note**: Saving a Autodesk® 3ds Max® file (.max) or exporting a generic 3D file type (.fbx) each has advantages and disadvantages see [class-Mesh](class-Mesh).

*Tip*: To optimize importing your Autodesk® 3ds Max® file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).



<a name="Cheetah3D"></a>
## Importing objects from Cheetah3D

Unity imports Cheetah3D files (*.jas*) through the FBX format, supporting the following:

* All nodes with position, rotation and scale; pivot points and names are also imported
* Meshes with vertices, polygons, triangles, UVs, and normals
* Animations
* Materials with diffuse color and textures

*Tip*: To optimize importing your Cheetah3D file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).



<a name="Modo"></a>
## Importing objects from Modo

Unity imports Modo files (*.lxo*) through the FBX format, supporting the following:

* All nodes with position, rotation and scale; pivot points and names are also imported
* Meshes with vertices, normals and UVs.
* Materials with Texture and diffuse color; multiple Materials per mesh
* Animations

To get started, save your **.lxo** file in your Project's Assets folder. In Unity, the file appears in the Project View.

Unity re-imports the Asset when it detects a change in the .lxo file.

*Tip*: To optimize importing your Modo file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).



<a name="Lightwave"></a>
## Importing objects from Lightwave

Unity imports Lightwave files through the FBX format, supporting the following:

 * All nodes with position, rotation and scale; pivot points and names are also imported
 * Meshes with up to 2 UV channels
 * Normals
 * Materials with Texture and diffuse color; multiple materials per mesh
 * Animations
 * Bone-based animations

You can also configure the Lightwave AppLink plug-in which automatically saves the FBX export settings you use the first time you import your Lightwave scene file into Unity. 
For more information, see the [Lightwave Unity Interchange documentation](https://docs.lightwave3d.com/display/LW2018/Unity).

*Tip*: To optimize importing your Lightwave file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).

### Limitations

Bake your Lightwave-specific materials as textures so that Unity can read them. For information on doing this using a non-destructive pipeline, see [Node system in Lightwave](https://www.lightwave3d.com/learn/article/using-lightwave-to-create-uv-maps-for-military-assets/).

Unity does not support splines or patches. Convert all splines and patches to polygons before saving and exporting to Unity. For more information, see [Lightwave documentation](https://docs.lightwave3d.com/display/LW2018/Patch).



<a name="Blender"></a>
## Importing objects from Blender

Unity imports [Blender](https://docs.blender.org/) (*.blend*) files through the FBX format, supporting the following:

* All nodes with position, rotation and scale; pivot points and names are also imported
* Meshes with vertices, polygons, triangles, UVs, and normals
* Bones
* Skinned Meshes
* Animations

For information on how to optimize importing your Blender file into Unity, see [Optimizing FBX files](HOWTO-exportFBX).

### Limitations

Textures and diffuse color are not assigned automatically. You can manually assign them by dragging the texture onto the mesh in the __Scene View__ in Unity.

Blender does not export the visibility value inside animations in the FBX file.

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>
