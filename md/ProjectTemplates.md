# Project Templates

Project Templates provide preselected settings based on common best practices for different types of Projects. These settings are optimized for 2D and 3D Projects across the full range of platforms that Unity supports.

Templates speed up the process of preparing the initial Project, a target game-type or level of visual fidelity. Using Templates introduces you to settings that you might not have discovered, and to features such as [Scriptable Render Pipelines](https://github.com/Unity-Technologies/ScriptableRenderPipeline/wiki), [Shader Graph](https://github.com/Unity-Technologies/ShaderGraph/wiki), and [Post Processing](https://github.com/Unity-Technologies/PostProcessing/wiki).

When you create a Project, you select a Template with which to initialize your Project.

![Project Templates drop-down selection](../uploads/Main/createprojectwithtemplate182.jpg)

## Template types

Unity provides the following templates, which you can use to initialize your Project.

### 2D

Configures Project settings for 2D apps, including [Texture (Image) Import](class-TextureImporter), [Sprite Packer](SpritePacker), [Scene View](UsingTheSceneView), [Lighting](LightingOverview), and [Orthographic Camera](class-Camera).

### 3D

Configures Project settings for 3D apps that use Unity’s built-in [rendering pipeline](SL-RenderPipeline).

### 3D With Extras (Preview)

Configures Project settings for 3D apps that use Unity’s built-in renderer and post-processing features. This Project type includes the new post-processing stack, several [Presets](Presets) to jump-start development, and example content.

For more information on post-processing, see documentation on [post-processing](https://github.com/Unity-Technologies/PostProcessing/wiki) in the post-processing GitHub repository.

### High Definition RP (Preview)

Configures Project settings for Projects that use high-end platforms that support Shader Model 5.0 (DX11 and above). This template is built using the Scriptable Render Pipeline (SRP), a modern rendering pipeline that includes advanced material types and a configurable hybrid tile/cluster deferred/forward lighting architecture. This Template also includes the new post-processing stack, several Presets to jump start development, and example content.

This Template adds the following features to your Project:

* SRP - For more information, see documentation on the [Scriptable Render Pipeline](https://github.com/Unity-Technologies/ScriptableRenderPipeline/wiki) in the SRP GitHub repository.
* Post-Processing stack - The post-processing Stack enables artists and designers to apply full -screen filters to scenes using an artist-friendly interface. For more information, see documentation on [post-processing](https://github.com/Unity-Technologies/PostProcessing/wiki) in the post-processing GitHub repository.

**Note**: The High Definition RP is currently in development, so consider it incomplete and subject to change (API, UX, scope). As such, it is not covered by regular Unity support. Unity is seeking feedback on the feature. To ask questions about the feature, visit the [Unity preview forum](https://forum.unity.com/forums/graphics-experimental-previews.110/).

### Lightweight RP (Preview)

Configures Project settings for Projects where performance is a primary consideration and projects that use a primarily baked lighting solution. This template is built using the Scriptable Render Pipeline (SRP), a modern rendering pipeline that includes advanced material types and a configurable hybrid tile/cluster deferred/forward lighting architecture. This Template also includes the new post-processing stack, several Presets to jump start development, and example content.

Using the Lightweight pipeline decreases the [draw call](DrawCallBatching) count on your project, providing a solution for lower-end hardware.

This Project Template uses the following features:

* SRP - For more information, see documentation on the [Scriptable Render Pipeline](https://github.com/Unity-Technologies/ScriptableRenderPipeline/wiki) in the SRP GitHub repository.
* Shader Graph tool - This tool allows you to create shaders using a visual node editor instead of writing code. For more information, see documentation on the [Shader Graph](https://github.com/Unity-Technologies/ShaderGraph/wiki) in the Shader Graph GitHub repository.
* Post-processing stack - The post-processing Stack enables artists and designers to apply full -screen filters to scenes using an artist-friendly interface. For more information, see documentation on [post-processing](https://github.com/Unity-Technologies/PostProcessing/wiki) in the post-processing GitHub repository.

**Note**: The Lightweight RP is currently in development, so consider it incomplete and subject to change (API, UX, scope). As such, it is not covered by regular Unity support. Unity is seeking feedback on the feature. To ask questions about the feature, visit the [Unity preview forum](https://forum.unity.com/forums/graphics-experimental-previews.110/).

### [XR] VR Lightweight RP (Preview)

Configures Project settings for Projects where performance is a primary consideration for Virtual Reality (VR) Projects that use a primarily baked lighting solution. This template is built using the Scriptable Render Pipeline (SRP), a modern rendering pipeline that includes advanced material types and a configurable hybrid tile/cluster deferred/forward lighting architecture. This Template also includes the new post-processing stack, several Presets to jump start development, and example content.

To use this Project, you need a device. Ensure that you have the correct SDKs for the device for which you are developing before you use this Template.

This Project Temple uses the following features:

* VR - Unity VR lets you target virtual reality devices directly from Unity, without any external plug-ins in projects. For more information, see [VR overview](VROverview).
* SRP - For more information, see documentation on the [Scriptable Render Pipeline](https://github.com/Unity-Technologies/ScriptableRenderPipeline/wiki) in the SRP GitHub repository.
* Shader Graph tool - This tool allows you to create shaders using a visual node editor instead of writing code. For more information on the shader graph tool, see documentation on the [Shader Graph](https://github.com/Unity-Technologies/ShaderGraph/wiki) in the Shader Graph GitHub repository.
* Post-processing stack - The post-processing Stack enables artists and designers to apply full -screen filters to scenes using an artist-friendly interface. For more information, see documentation on [post-processing](https://github.com/Unity-Technologies/PostProcessing/wiki) in the post-processing GitHub repository.

**Note**: The Lightweight RP is currently in development, so consider it incomplete and subject to change (API, UX, scope). As such, it is not covered by regular Unity support. Unity is seeking feedback on the feature. To ask questions about the feature, visit the [Unity preview forum](https://forum.unity.com/forums/graphics-experimental-previews.110/).

---
* <span class="page-edit">2018-05-22 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Added Project Templates in  [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) <span class="search-words">NewIn20181</span></span>

* <span class="page-history">New Project Templates added in  [2018.2](https://docs.unity3d.com/2018.2/Documentation/Manual/30_search.html?q=newin20182) <span class="search-words">NewIn20182</span></span>