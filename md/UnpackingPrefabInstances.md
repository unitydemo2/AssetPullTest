#Unpacking Prefab instances

To return the contents of a Prefab instance into a regular GameObject, you unpack the Prefab instance. This is exactly the reverse operation of creating (packing) a Prefab, except that it doesn’t destroy the Prefab Asset but only affects the Prefab instance.

You can unpack a Prefab instance by right-clicking on it in the Hierarchy and selecting __Unpack Prefab__. The resulting GameObject in the Scene no longer has any link to its former Prefab Asset. The Prefab Asset itself is not affected by this operation and there may still be other instances of it in your Project.

If you had any overrides on your Prefab instance before you unpacked it, those will be "baked" onto the resulting GameObjects. That is, the values will stay the same, but will no longer have status as overrides, since there’s no Prefab to override.

If you unpack a Prefab that has nested Prefabs inside, the nested Prefabs remain Prefab instances and still have links to their respective Prefab Assets. Similarly, if you unpack a Prefab Variant, there will be a new Prefab instance at the root which is an instance of the base Prefab.

In general, unpacking a Prefab instance will give you the same objects you see if you go into Prefab Mode for that Prefab. This is because Prefab Mode shows the contents that is inside of a Prefab, and unpacking a Prefab instance unpacks the contents of a Prefab.

If you have a Prefab instance that you want to replace with plain GameObjects and completely remove all links to any Prefab Assets, you can right-click on it in the Hierarchy and select __Unpack Prefab Completely__. This is equivalent to unpacking the Prefab, and keeping on unpacking any Prefab instances that appear as a result because they were nested Prefabs or base Prefabs.

You can unpack Prefab instances that exist in Scenes, or which exist inside other Prefabs.

--------------------

* <span class="page-edit">2018-07-31  <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-history">Nested Prefabs and Prefab Variants added in 2018.3</span>