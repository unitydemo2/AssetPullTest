#WebGL Graphics

[WebGL](https://www.khronos.org/webgl/) is an API for rendering graphics in web browsers, which is based on the functionality of the OpenGL ES graphics library. WebGL 1.0 roughly matches OpenGL ES 2.0 functionality, and WebGL 2.0 roughly matches OpenGL ES 3.0 functionality.

## Deferred Rendering

Unity WebGL only supports [Deferred Rendering Path](RenderTech-DeferredShading) if WebGL2.0 is available. On WebGL1.0, Unity WebGL runtime will fallback to [Forward Rendering](RenderTech-ForwardRendering).

## Global Illumination

Unity WebGL only supports [baked GI](GIIntro). Realtime GI is not currently supported in WebGL. Furthermore, only Non-Directional lightmaps are supported.


## Linear Rendering

Unity WebGL only supports [linear color space rendering](LinearLighting) with WebGL 2.0. Linear color space rendering doesn't have fallback support for WebGL 1.0. To build a WebGL player using linear color space rendering, you need to remove WebGL 1.0 API in the __Player__ settings, open the __Other Settings__ panel, disable the __Automatic Graphics API__ setting.

Some web browsers don't support [sRGB DXT texture compression](class-TextureImporterOverride). This can decrease the quality of rendering performance when using linear rendering, due to runtime decompression of all the DXT textures.

## MovieTextures

WebGL does not support playing Video using the MovieTexture class. However, you can efficiently play back video in your WebGL content using the HTML5 video element. Download this [Asset Store package](https://www.assetstore.unity3d.com/en/#!/content/38369) for an example of how to do so.

## WebGL Shader code restrictions

The [WebGL 1.0 specification](https://www.khronos.org/registry/webgl/specs/1.0/) imposes some limitations on GLSLS shader code, which are more restrictive than many OpenGL ES 2.0 implementations. This is mostly relevant when you write your own shaders.

Specifically, WebGL has restriction on which values can be used to index arrays or matrices: WebGL only allows dynamic indexing with constant expressions, loop indices or a combination. The only exception is for uniform access in vertex shaders, which can be indexed using any expression.

Also, restrictions apply on control structures. The only type of loops which are allowed are counting _for_ loops, where the initializer initializes a variable to a constant, the update adds a constant to or subtracts a constant from the variable, and the continuation test compares the variable to a constant. _for_ loops which don't match those criteria and _while_ loops are not allowed.

## Font rendering

Unity WebGL supports dynamic font rendering like all Unity platforms. However, it does not have access to the fonts installed on the user's machine, so any fonts used must be included in the project folder (including any fallback fonts for international characters, or bold/italic versions of fonts), and [set up as fallback font names](class-Font).

## Anti-Aliasing

WebGL supports anti-aliasing on most (but not on all) combinations of browsers and GPUs. To use it, anti-aliasing must be enabled in the default [Quality](class-QualitySettings) setting for the WebGL platform.

Note that on WebGL1.0 there are several limitations:

* Switching **Quality** settings at runtime will not enable or disable anti-aliasing. It has to be set up in the default **Quality** setting loaded at player start up. 

* The different multi sampling levels (2x, 4x, etc..) have no effect in WebGL, it's either on or off.

* Any [post-processing effect](PostProcessingOverview) applied to the camera disables the built-in Anti-Aliasing.

* HDR is not compatible with anti-aliasing so make sure the **Allow HDR** camera option is disabled.

There are no such limitations on WebGL2.0.

## Reflection Probes

Reflection probes are supported in WebGL, but due to limitations in the WebGL specification about rendering to specific mipmaps, smooth realtime reflection probes are not supported (so realtime reflection probes will always generate sharp reflections, which may appear very low-resolution). Smooth realtime reflection probes will require WebGL 2.0.

## WebGL 2.0 support

Unity includes support for the [WebGL 2.0 API](https://www.khronos.org/registry/webgl/specs/latest/2.0/), which brings OpenGL ES 3.0-level rendering capabilities to the web. 

By default, Unity WebGL builds support both WebGL 1.0 and WebGL 2.0 APIs, This can be configured in the WebGL __Player__ settings under the __Other Settings__ panel by disabling the __Automatic Graphics API__ property.

When WebGL 2.0 is supported in browsers, content can benefit from a better quality in the Standard Shader, [GPU Instancing](GPUInstancing) support, directional lightmap support, no restrictions on indexing and loops in shader code, and better performance.

You can use [SystemInfo.graphicsDeviceType](ScriptRef:SystemInfo-graphicsDeviceType.html) at run time to determine whether the Unity instance is rendering with OpenGLES3 (WebGL2.0) or OpenGLES2 (WebGL1.0).
---

* <span class="page-edit"> 2018-10-26  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Linear rendering for WebGL 2.0 added in [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) <span class="search-words">NewIn20172</span></span>