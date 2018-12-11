#Upgrading to Unity 2018.2

This page lists any changes in 2018.2 which might affect existing projects when you upgrade from earlier versions of Unity
***
###UIElements.ContextualMenu changes

The `UIElements.ContextualMenu` menu action callbacks now takes a `ContextualMenu.MenuAction` parameter instead of an `EventBase` parameter.

`ContextualMenu.InsertSeparator` takes an additional `string` parameter.

***

###Multiplayer: The deprecated legacy networking APIs have been removed (RakNet based)

This feature was deprecated in Unity 5.1 and has now been removed. You can no longer use it in your projects in Unity 2018.2.

See the [Multiplayer and Networking](UNet) section for more information on networking in Unity.

***

###Photoshop Data file (PSD) import using transparency

When having actual transparency, Photoshop will tweak pixel colors to blend them with matte (background) color. The process of preparing alpha channels properly is described in our  [how to prepare alpha channels](https://docs.unity3d.com/Manual/HOWTO-alphamaps.html) documentation.

You can ignore dilation in this document, the important part is the note that states that you want to have an “opaque” image with a separate alpha channel/mask (instead of having transparency). Unity tweaked colors to “remove” matte, but this has ceased as of 2018.2. If you had PSD with transparency you might start seeing white color on the edges. To fix this, consult the manual link above and make an actual alpha channel (instead of transparency).

***

For more information about what's new in 2018.2 and for more detailed upgrade notes, see the [2018.2 Release Notes](https://unity3d.com/unity/whats-new/unity-2018.2.0).|