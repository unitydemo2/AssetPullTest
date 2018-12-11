#Nested Prefabs

You can include Prefab instances inside other Prefabs. This is called **nesting** Prefabs. Nested Prefabs retain their links to their own Prefab Assets, while also forming part of another Prefab Asset.

<a name="Adding"></a>
##Adding a nested Prefab in Prefab Mode

In Prefab Mode, you can add and work with Prefab instances just like you would do in Scenes. You can drag a Prefab Asset from the Project window to the Hierarchy window or Scene view to create a Prefab instance from that Asset inside the Prefab you have open.

**Note**: The root GameObject of the Prefab that is open in Prefab Mode is not shown with the blue cube Prefab icon, however any instances of other Prefabs are. You can also add overrides to these Prefab instances, just like with Prefab instances in scenes.

![Left: "Oil Can" Prefab included (nested) in the “Robot” Prefab in Prefab Mode. Right: The “Robot” Prefab instance in the Scene with the “Oil Can” included.](../uploads/Main/PrefabsNestedPrefab.png)

<a name="Nesting"></a>
##Nesting Prefabs via their instances

You can also add a Prefab instance as a child to another Prefab instance in the Scene without going into Prefab Mode, just like you can add any other GameObject. Such an added Prefab instance has a plus badge overlayed on the icon in the Hierarchy which indicates that it's an override on that specific instance of the outer Prefab.

The added Prefab can be reverted or applied to the outer Prefab in the same way as other overrides (either via the Overrides drop-down window, or via the context menu on the GameObject in the Hierarchy), as described in [Editing a Prefab via its instances](EditingPrefabViaInstance). The Overrides drop-down button is only on the outer Prefab. Once applied, the Prefab no longer shows the plus badge, since it is no longer an override, but is nested in the outer Prefab Asset itself. It does however retain its blue cube icon because it is a Prefab instance in its own right, and retains its connection to its own Prefab Asset.

![Left: An "Oil Can" Prefab added to an instance of the “Robot” Prefab as an override. Right: The “Oil Can” Prefab has been applied to “Robot” Prefab, and is now a nested Prefab in the “Robot” Prefab Asset.](../uploads/Main/PrefabsOverrideVsNested.png)

--------------------

* <span class="page-edit">2018-07-31  <!-- include IncludeTextNewPageSomeEdit --></span>

* <span class="page-history">Nested Prefabs and Prefab Variants added in 2018.3</span>