#Low-level native plugin rendering extensions

On top of the [low-level native plugin interface](NativePluginInterface), Unity also supports low level rendering extensions that can receive callbacks when certain events happen. This is mostly used to implement and control low-level rendering in your plugin and enable it to work with Unity’s multithreaded rendering.

Due to the low-level nature of this extension the plugin might need to be preloaded before the devices get created. Currently the convention is name-based; the plugin name must begin _GfxPlugin_ (for example: _GfxPluginMyNativePlugin_).

The rendering extension definition exposed by Unity is in the file _IUnityRenderingExtensions.h_, provided with the Editor (see file path _Unity\Editor\Data\PluginAPI_).

All platforms supporting native plugins support these extensions.

##Rendering extensions API

To take advantage of the rendering extension, a plugin should export _UnityRenderingExtEvent_ and optionally _UnityRenderingExtQuery_. There is a lot of documentation provided inside the include file.

##Plugin callbacks on the rendering thread

A plugin gets called via _UnityRenderingExtEvent_ whenever Unity triggers one of the built-in events. The callbacks can also be added to CommandBuffers via [CommandBuffer.IssuePluginEventAndData](ScriptRef:Rendering.CommandBuffer.IssuePluginEventAndData.html) or [CommandBuffer.IssuePluginCustomBlit](ScriptRef:Rendering.CommandBuffer.IssuePluginCustomBlit.html) from scripts.

-----

* <span class="page-history">New feature in Unity [2017.1](https://docs.unity3d.com/2017.1/Documentation/Manual/30_search.html?q=newin20171) <span class="search-words">NewIn20171</span></span>

* <span class="page-edit">2017-07-04 <!-- include IncludeTextNewPageNoEdit --></span>
