#Upgrading to Unity 2018.3


This page lists any changes in 2018.3 which might affect existing projects when you upgrade from earlier versions of Unity

***

###Improved Prefabs

* Prefabs automatically upgrade to the [new Prefabs system](https://unity3d.com/prefabs).
* To support prefab nesting, the prefab workflow has changed. To edit Prefabs, you now need to open them in Prefab Mode. You can no longer edit Prefabs in the Project Browser.
* You also make structural changes in Prefab Mode, such as deleting GameObjects, reparenting GameObjects, or replacing a Transform with a RectTransform. Alternatively, you can unpack a Prefab instance if you want to entirely remove its link to its Prefab Asset and thus be able to restructure the resulting plain GameObjects as necessary. You can no longer disconnect a Prefab instance.
* The Editor tooling that creates GameObjects should use [ObjectFactory.CreateGameObject](ScriptRef:ObjectFactory.CreateGameObject.html) to make sure that the GameObject ends up in the Prefab Scene if a Prefab Asset is currently being edited in Prefab Mode.
* As a safety precaution, scripts with the [ExecuteInEditMode] attribute cause the Editor to exit Prefab Mode when going into Play Mode, if any script on the open Prefab has that attribute. For details on how to make such scripts compatible with Prefab Mode, see the Scripting Reference pages for [ExecuteInEditMode](ScriptRef:ExecuteInEditMode.html) and the new [ExecuteAlways](ScriptRef:ExecuteAlways.html) attribute.
* It's no longer possible to make arbitrary modifications to Prefab Assets from scripts because Prefabs are now imported assets. Instead you need to use [PrefabUtility.LoadPrefabContents](ScriptRef:PrefabUtility.LoadPrefabContents.html), [PrefabUtility.SaveAsPrefabAsset](ScriptRef:PrefabUtility.SaveAsPrefabAsset.html) and [PrefabUtility.UnloadPrefabContents](ScriptRef:PrefabUtility.UnloadPrefabContents.html).
* If you use [AssetDatabase.AddObjectToAsset](ScriptRef:AssetDatabase.AddObjectToAsset) to add additional assets to Prefabs, you must now call [PrefabUtility.SavePrefabAsset](PrefabUtility.SavePrefabAsse.html) after adding the requisite objects.

***

###USS flex shorthand expansion now follows CSS standard

* The USS flex directive now accepts up to three parameters representing `flex-grow`, `flex-shrink` and `flex-basis`. The flex-shrink and flex-basis parameters are optional. If omitted, flex-basis defaults to 0 and flex-shrink defaults to 1.
* Before 2018.3, `flex: N` was equivalent to `flex N 0 auto`. This now follows the CSS standard by making it equivalent to `flex: N 1 0`. To preserve the old semantic, you should replace all `flex: N` directives with `flex: N 0 auto` in your USS files.

***

###Support for logging unhandled exceptions in managed user threads

* Before 2018.3, the Unity Editor did not log unhandled exceptions thrown in managed user threads. From 2018.3 onwards, unhandled exceptions thrown in managed user threads are logged on the Unity Editor console.
* Because logging now includes all managed user threads, you may see exceptions that have always been thrown in your Projects, but were never emitted to the console until now. 

***

###The VFACE shader variable is now inverted in DirectX (11 & 12)

* The VFACE shader variable was not coherent between DirectX and other graphics APIs when rendering to a cubemap. Now it has the same behavior.
* If you are using a VFACE bool shader variable in a DirectX shader to render a cubemap, then you have to flip the logic in your code.
* See [Issue ID 1027670](https://issuetracker.unity3d.com/issues/the-vface-variable-is-incorrect-in-shaders-when-rendered-from-a-reflection-probe).

***

###Upgraded PhysX from 3.3.1 to 3.4.2

Physics behaviour has changed and some Projects may behave differently with the new version. In particular:

* The contact patches now contain up to 6 contacts in the __Persistent Contact Manifold__ mode. This is an increase from 5 contacts per patch in previous versions. There is new code that merges patches in the manifold, and new code that selects contacts. Collisions appear to be a lot more accurate than before. You may need to work on Projects that rely on a particular arrangement of contacts to make them compatible with the new code. You are most likely to notice this when convex bodies collide with meshes and primitives.
* A new algorithm is now used to compute __contacts with terrains__. It used to be special-cased, but now it’s the same mesh-primitive code that is used with MeshColliders. It’s robust, more accurate and performs well. However, it doesn’t support TerrainData.thickness, which means the tunneling effect with terrains is now possible. To avoid this, you need to enable continuous collision detection on the fast moving objects. Before that, if a body was discovered to be no deeper than TerrainData.thickness under the terrain, it was popped up automatically, but the normals were never correct. To get the old behaviour, uncheck the __Enable Unified Heightmaps__ option in the Physics settings.
* **Negative mesh scaling** no longer leads directly to mesh baking in all the cases. Concave meshes are not baked any more. However, Convex meshes still need to have scaling to be baked. With this change, negative scaling inverts the mesh normals when scale.x * scale.y * scale.z < 0. Additionally, non-trivial scaling like skew and shear still have to be baked, as before.
* __Convex mesh inflation__ is deprecated because it doesn’t seem to be needed with the new convex hull computation algorithm (Quickhull) that is more tolerant towards all sorts of imperfections in the input mesh. 

***

###The AssetBundle.mainAsset property has been marked Obsolete

* In Unity versions prior to 5.0, users had to build asset bundles using the AssetBundleBuildAssetBundle API which required providing an Object that would be returned when loaded using the AssetBundle’s mainAsset property.
* The AssetBundle.BuildAssetBundle API was marked obsolete in Unity 5.0 and was replaced by AssetBundle.BuildAssetBundles, which changed how you get Assets from an AssetBundle.
* You now need to get the Asset’s name, or path with the AssetBundle.LoadAsset API to get content from the AssetBundle. See documentation on Building AssetBundles, Using AssetBundles Natively, and the AssetBundle Scripting API.
 
***

###Upgrading Projects that use NavMesh components

* If you are moving a Project from 2018.2 or earlier to 2018.3b and it uses NavMesh components obtained from Unity’s GitHub repository, you now need to use this [branch](https://github.com/Unity-Technologies/NavMeshComponents/tree/2018.3).

***

###Particle System bug fixes

Unity 2018.3 includes some particle bugs fixes and this can affect your projects that were created in a previous version.

* When using non-uniform Transform scale on billboard particles, the Y and Z axes were inverted. This has now been fixed.
* When using non-uniform Transform scale on mesh particles, rotation was applied after scaling. This was a regression in 2017.x. It behaved correctly in 5.6 and earlier, but was broken in the 2017 cycle. Fixing this bug corrects content created in 5.6 and earlier, but changes content created in 2017.x.
* Spherical wind zones had the opposite effect on particles compared to trees. This has been corrected so the spherical wind zones now repel particles instead of attracting them. You can restore the previous behavior by negating the External Forces Multiplier, or the Wind Zone strength. Unity can’t change this automatically as Scenes with trees or directional wind zones could be incorrectly affected.

***

###C# compiler upgrade to Roslyn

Before 2018.3, the Unity Editor used the mono C# compiler (mcs) when compiling C# files in a project. From 2018.3 onwards, the Roslyn C# compiler (csc) is used for projects targeting the new scripting runtime (.NET 4.x Equivalent). Different behavior may be noticed from the switch to Roslyn:

* C# 7.3 is the supported
* Additional warnings may be reported
* Response files for the Roslyn compiler should be named `csc.rsp`. See [PlatformDependentCompilation](PlatformDependentCompilation).

***

###The UnityScript and Boo scripts compiler has been removed

UnityScript (.js) and Boo (.boo) script files can no longer be compiled in the Editor.

For more information see this [blog post](https://blogs.unity3d.com/2017/08/11/unityscripts-long-ride-off-into-the-sunset/) from August 2017 and you can use the [unityscript2csharp](https://github.com/Unity-Technologies/unityscript2csharp) tool to convert UnityScript to C#.