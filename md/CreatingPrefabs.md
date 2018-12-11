# Creating Prefabs

In Unity's Prefab system, __Prefab Assets__ act as templates. You create Prefab Assets in the Editor, and they are saved as an Asset in the Project window. From __Prefab Assets__, you can create any number of __Prefab instances__. Prefab instances can either be created in the editor and saved as part of your Scenes, or instantiated at runtime.

<a name="Assets"></a>
## Creating Prefab Assets

To create a Prefab Asset, drag a GameObject from the Hierarchy window into the Project window. The GameObject, and all its components and child GameObjects, becomes a new Asset in your Project window. Prefabs Assets in the Project window are shown with a thumbnail view of the GameObject, or the blue cube Prefab icon, depending on how you have set up your Project window.

![Two prefabs ("LeafyTree" and “Vegetation”) shown in the Project window in two-column view (left) and one-column view (right)](../uploads/Main/PrefabsInProjectWindow.png)

This process of creating the Prefab Asset also turns the original GameObject into a Prefab instance. It is now an instance of the newly created Prefab Asset. Prefab instances are shown in the Hierarchy in blue text, and the root GameObject of the Prefab is shown with the blue cube Prefab icon, instead of the red, green and blue GameObject icon.

![A Prefab instance (LeafyTree) in the scene](../uploads/Main/PrefabInstanceInScene.png)

<a name="Instances"></a>
## Creating Prefab instances

You can create instances of the Prefab Asset in the Editor by dragging the Prefab Asset from the Project view to the Hierarchy or Scene view.

![Dragging a Prefab "RedPlant" into the Scene](../uploads/Main/PrefabsDragIntoScene.png)

You can also create instances of Prefabs at runtime using scripting. For more information, see [Instantiating Prefabs](https://docs.unity3d.com/Manual/InstantiatingPrefabs.html).

--------------------

* <span class="page-edit">2018-07-31  <!-- include IncludeTextNewPageSomeEdit --></span>

* <span class="page-history">Nested Prefabs and Prefab Variants added in 2018.3</span>