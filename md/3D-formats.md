# Model file formats

Unity supports importing [Meshes](class-Mesh) and [animation](AnimationClips) from two different types of files:

* [Exported 3D file formats](#Exported3DFiles), such as .fbx or .obj. You can export files from 3D modeling software in generic formats that can be imported and edited by a wide variety of different software. 

* [Proprietary 3D or DCC (Digital Content Creation) application files](#Proprietary3DappFiles), such as .max and .blend file formats from [Autodesk® 3ds Max®](https://www.autodesk.com/products/3ds-max/overview) or [Blender](https://www.blender.org/), for example. You can only edit proprietary files in the software that created them. Proprietary files are generally not directly editable by other software without first being converted and imported. An exception to this is [SketchUp](https://www.sketchup.com/) .skp files, which both SketchUp and Unity can read.

Unity can import and use both types of files, and each come with their own advantages and disadvantages.


<a name="Exported3DFiles"></a>
## Exported 3D files

Unity can read [.fbx](https://www.autodesk.com/products/fbx/overview), [.dae (Collada)](https://www.khronos.org/collada/), .3ds, .dxf, .obj, and .skp files. For information about exporting 3D files, see [Exporting from other applications](HOWTO-exportFBX) or read the documentation for your 3D modeling software.

**Advantages:**

* You can import only the parts of the model you need instead of importing the whole model into Unity.
* Exported generic files are often smaller than the proprietary equivalent.
* Using exported generic files encourages a modular approach (for example, using different components for collision types or interactivity).
* You can import these files from software that Unity does not directly support.
* You can re-import exported 3D files (.fbx, .obj) into 3D modeling software after exporting, to ensure that all of the information has been exported correctly.

**Disadvantages:**

* You must re-import models manually if the original file changes.
* You need to keep track of versions between the source file and the files imported into Unity.


<a name="Proprietary3DappFiles"></a>
## Proprietary 3D application files

Unity can import proprietary files from the following 3D modeling software: 

* [Autodesk® 3ds Max®](https://www.autodesk.com/products/3ds-max/overview)
* [Autodesk® Maya®](https://www.autodesk.com/products/maya/overview)
* [Blender](https://www.blender.org/)
* [Cinema4D](https://www.maxon.net/en/products/cinema-4d/overview/)
* [Modo](https://www.foundry.com/products/modo)
* [LightWave](https://www.lightwave3d.com/)
* [Cheetah3D](https://www.cheetah3d.com/)

**Warning:** Unity converts proprietary files to .fbx files as part of the import process. However, it is recommended that you export to FBX instead of directly saving your application files in the Project. It is not recommended to use native file formats directly in production.

**Advantages:**

* Unity automatically re-imports the file if the original model changes.
* This is initially simple; however it can become more complex later in development.

**Disadvantages:**

* A licensed copy of the software used must be installed on each machine that uses the Unity Project.
* Software versions should be the same on each machine using the Unity Project. Using a different software version can cause errors or unexpected behavior when importing 3D models.
* Files can become bloated with unnecessary data.
* Big files can slow down Unity Project imports or Asset re-imports, because you have to run the 3D modeling software you use as a background process when you import the model into Unity.
* Unity exports proprietary files to .fbx internally, during the import process. This makes it difficult to verify the .fbx data and troubleshoot problems.

***Note:*** Assets saved as .ma, .mb, .max, .c4d, or .blend files fail to import unless you have the corresponding 3D modeling software installed on your computer. This means that everybody working on your Unity Project must have the correct software installed. For example, if you use [the Autodesk® Maya LT™ license](https://www.autodesk.com/products/maya-lt/overview) to create `ExampleModel.mb` and copy it into your Project, anyone else opening that Project also needs to have Autodesk® Maya LT™ installed on their computer too. 

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>
