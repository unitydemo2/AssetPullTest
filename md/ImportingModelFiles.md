# Model import workflows

**Note:** This workflow assumes you already have a Model file to import. If you don't have a file already, you can read the [guidelines on how to export an FBX file](HOWTO-exportFBX) before exporting it from your 3D modeling software. For guidelines on how to export *Humanoid* animation from your 3D modeling software, see [Humanoid Asset preparation](UsingHumanoidChars).

Model files can contain a variety of data, such as character Meshes, Animation Rigs and Clips, as well as Materials and Textures. Most likely, your file does not contain all of these elements at once, but you can follow any portion of the workflow that you need to.

**Accessing the Import Settings window**


No matter what kind of data you want to extract from the Model file, you always start the same way:
1. Open the __Project__ window and the __Inspector__ so that you can see both at once.
2. Select the __Model__ file you want to import from the __Asset__ folder in the __Project__ window. The __Import Settings__ window opens in the __Inspector__ showing the __Model tab__ by default.


**Setting Model-specific and general importer options**

Then you can set any of these options on [the Model tab](FBXImporter-Model):

* Use the __Scale Factor__ and __Convert Units__ properties to adjust how Unity interprets units. For example, 3ds Max uses 1 unit to represent 10 centimeters, whereas Unity uses 1 unit to represent 1 meter.
* Use the __Mesh Compression__, __Read/Write Enabled__, __Optimize Mesh__, __Keep Quads__, __Index Format__, or __Weld Vertices__ properties to reduce resources and save memory.
* You can enable the __Import BlendShapes__ option if the Model file came from Maya or 3ds Max, or any other 3d modeling application that supports morph target animation. 
* You can enable the __Generate Colliders__ option for environment geometry.
* You can enable specific FBX settings, such as __Import Visibility__, or __Import Cameras__ and __Import Lights__.
* For Model files that contain only Animation, you can enable the __Preserve Hierarchy__ option to prevent hierarchy mismatch in your skeleton.
* You can set the __Swap UVs__ and __Generate Lightmap UVs__ if you are using a __Lightmap__.
* You can exercise control over how Unity handles the Normals and Tangents in your Model with the __Normals__, __Normals Mode__, __Tangents__, or __Smoothing Angle__ options.


**Setting options for importing Rigs and Animation**

If your file contains Animation data, you can follow the guidelines for setting up the Rig using the [Rig tab](FBXImporter-Rig) and then extracting or defining Animation Clips using the [Animation tab](class-AnimationClip). The workflow differs between Humanoid and Generic (non-Humanoid) animation types because Unity needs the Humanoid's bone structure to be very specific, but only needs to know which bone is the root node for the Generic type:

* [Humanoid-type workflow](ConfiguringtheAvatar) 
* [Generic-type workflow](GenericAnimations)


**Dealing with Materials and Textures**

If your file contains __Material__ or __Texture__, you can define how you want to deal with them:

1. Click [the Materials tab](FBXImporter-Materials) in the __Import Settings__ window.
2. Enable the __Import Materials__ option. Several options appear in the __Materials__ tab, including the __Location__ option, whose value determines what the other options are.
3. Choose the __Use Embedded Materials__ option to [keep the imported Materials inside the imported Asset](FBXImporter-Materials#Embedded).

When you have finished setting the options, click the __Apply__ button at the bottom of the __Import Settings__ window to save them or click the __Revert__ button to cancel.

Finally, you can import the file into your scene:

* If it contains a Mesh, drag the file into the __Scene__ view to instantiate it as a __Prefab__ for a __GameObject__.
* If it contains Animation Clips, you can drag the file into [the Animator window](AnimatorWindow) to use in [the State Machine](StateMachineBasics) or onto an __Animation track__ on [the Timeline window](TimelineEditorWindow). You can also drag the Animation take directly onto an instantiated Prefab in the Scene view. This automatically creates an Animation Controller and connects the animation to the Model.

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2018-09-26  <!-- include IncludeTextAmendPageSomeEdit --></span>
