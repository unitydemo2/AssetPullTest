#Player settings for the Apple TV platform

This page details the __Player__ settings specific to tvOS. For a  description of the general __Player__ settings, see [Player](class-PlayerSettings#general).

![Player settings for the tvOS platform](../uploads/Main/class-PlayerSettingstvOS.png)

You can find documentation for the properties in the following sections:

* [Icon](#Icon)
* [Resolution and Presentation](#Resolution)
* [Splash Image](#Splash)
* [Debugging and crash reporting](#Debugging)
* [Other Settings](#Other)



<a name="Icon"></a>

##Icon

Use the **Icon** settings to customize the branding for your Apple TV app. 

![](../uploads/Main/PlayerSettvOSIcon.png) 

Apple TV images consist of between two and five layers. Unity provides two layers for Apple TV icons.

**Note**: For more information on layering images for Apple TV, see the Apple Developer documentation on [Layered Images](https://developer.apple.com/design/human-interface-guidelines/tvos/icons-and-images/layered-images/).

|**Setting** |**Function** |
|:---|:---|
|__App icons__ |Build the custom icon that you would like to appear on your [AppleTV home screen](https://developer.apple.com/design/human-interface-guidelines/tvos/overview/home-screen/) for each resolution (1280x768, 800x480, and 400x240). |
|__Top Shelf icons__ |Build the custom icon that you would like to appear on the [AppleTV top shelf](https://developer.apple.com/design/human-interface-guidelines/tvos/overview/top-shelf/) for each aspect and resolution (4640x1440, 2320x720, 3840x1440, and 1920x720).|



<a name="Resolution"></a>

##Resolution and Presentation

![Resolution Scaling player settings for the tvOS platform](../uploads/Main/PlayerSettvOSResPres.png)

Enable the __Disable Depth and Stencil__ option to disable the depth and stencil buffers.



<a name="Splash"></a>

##Splash Image

In addition to the [common Splash Screen](class-PlayerSettingsSplashScreen) settings, there are two additional settings for the tvOS platform:

![Splash Settings for the tvOS platform](../uploads/Main/PlayerSettvOSSplash.png)

Use the __AppleTV (1x)__ and __AppleTV (2x)__ properties to set [Apple TV static splash screens](https://developer.apple.com/design/human-interface-guidelines/tvos/app-architecture/loading/).



<a name="Debugging"></a>

##Debugging and crash reporting

![Debugging and crash reporting on the tvOS platform](../uploads/Main/PlayerSetiOSDebugCrash.png)

|**Setting** |**Function** |
|:---|:---|
|**Enable Internal Profiler (Deprecated)**|Enables an internal profiler which collects performance data of the application and prints a report to the console. The report contains the number of milliseconds that it took for each Unity subsystem to execute on each frame. The data is averaged across 30 frames.|
|__On .Net UnhandledException__|The action taken on .NET unhandled exception. The options are _Crash_ (the application crashes hardly and forces tvOS to generate a crash report that can be submitted to iTunes by app users and inspected by developers), _Silent Exit_ (the application exits gracefully).|
|__Log Obj-C Uncaught Exceptions__|Enables a custom Objective-C Uncaught Exception handler, which prints exception information to console.|
|__Enable Crash Report API__|Enables a custom crash reporter to capture crashes. Crash logs are available to scripts via CrashReport API.|



<a name="Other"></a>

##Other Settings

This section allows you to customize a range of options organized into the following groups:

* [Rendering](#Rendering)
* [Identification](#Identification)
* [Configuration](#Configuration)
* [Optimization](#Optimization)
* [Logging](#Logging) 
* [Legacy](#Legacy)



<a name="Rendering"></a>

### Rendering

Use these settings to customize how Unity renders your game for Standalone platforms.

![Rendering Player settings for the tvOS platform](../uploads/Main/PlayerSetiOSOther-Rendering.png)

|**Setting**||**Function** |
|:---|:---|:---|
|__Color Space__||Choose which color space should be used for rendering: _Gamma_ or _Linear_. <br />See the [Linear rendering overview](LinearLighting) for an explanation of the difference between the two. |
|__Auto Graphics API__||Disable this option to manually pick and reorder the graphics APIs. By default this option is enabled, and Unity includes Metal, and GLES2 as a fallback for devices where Metal is not supported. |
|__Color Gamut__||You can add or remove [color gamuts](https://color.viewsonic.com/zh-cn/explore/content/Color-gamut_6.html) for the iOS platform to use for rendering. Click the plus (+) icon to see a list of available gamuts. A color gamut defines a possible range of colors available for a given device (such as a monitor or screen). The sRGB gamut is the default (and required) gamut.<br />When targeting recent tvOS devices with wide color gamut displays, use _DisplayP3_ to utilize full display capabilities. Use _Metal Editor Support_ as a fallback for older devices. |
|__Metal Editor Support__||Enable this option to use the Metal API in the Unity Editor and unlock faster Shader iteration for targeting the Metal API. |
|__Metal API Validation__||Enable this option when you need to debug Shader issues.<br />**Note:** Validation increases CPU usage, so use it only for debugging. |
|__Metal Write-Only Backbuffer__||Allow improved performance in non-default device orientation. This sets the frameBufferOnly flag on the back buffer, which prevents readback from the back buffer but enables some driver optimization. |
|__Force hard shadows on Metal__||Enable this option to force Unity to use point sampling for shadows on Metal. This reduces shadow quality, which should give better performance. |
|__Memoryless Depth__||Choose when to use [memoryless render textures](ScriptRef:RenderTextureMemoryless.Depth.html). Memoryless render textures are temporarily stored in the on-tile memory when rendered, not in CPU or GPU memory. This reduces memory usage of your app but you cannot read or write to these render textures.<br />**Note:** Memoryless render textures are only supported on tvOS, tvOS 10.0+ Metal and Vulkan. Render textures are read/write protected and stored in CPU or GPU memory on other platforms. |
||__Unused__|Never use memoryless framebuffer depth.                     |
||__Forced__|Always use memoryless framebuffer depth.                    |
||__Automatic__|Let Unity decide when to use memoryless framebuffer depth.|
|__Multithreaded Rendering__|| Enable this option to use multithreaded rendering. This is only supported on Metal. |
|__Static Batching__||Enable this option to use Static batching.|
|__Dynamic Batching__||Check this box to use [Dynamic Batching](DrawCallBatching) on your build (enabled by default).|
|__GPU Skinning__||Enable this option to use DX11/ES3 GPU skinning.|
|__Graphics Jobs (Experimental)__||Enable this option to instruct Unity to offload graphics tasks (render loops) to worker threads running on other CPU cores. This is intended to reduce the time spent in `Camera.Render` on the main thread, which is often a bottleneck. <br />**Note:** This feature is experimental. It may not deliver a performance improvement for your project, and may introduce new crashes.|
|__Lightmap Streaming Enabled__||Enable this option to load only the lightmap mip maps as needed to render the current game Cameras. This value applies to the lightmap textures as they are generated.<br />**Note:** To use this setting, you must enable the [Texture Streaming Quality](class-QualitySettings#texStream) setting.|
|__Streaming Priority__||Set the lightmap mip map streaming priority to resolve resource conflicts. These values are applied to the light map textures as they are generated.<br />Positive numbers give higher priority. Valid values range from -128 to 127.|
|__Enable Frame Timing Stats__||Enable this option to gather CPU/GPU frame timing statistics.|



<a name="Identification"></a>

### Identification

![Identification settings for the tvOS platform](../uploads/Main/PlayerSetiOSOther-Identification.png)

|**Setting** |**Function** |
|:---|:---|
|__Bundle Identifier__ |Enter the provisioning profile of the game or product you are building. The basic structure of the identifier is __com.CompanyName.ProductName__. This structure may vary internationally based on where you live, so always default to the string provided to you by Apple for your Developer Account. Your ProductName is set up in your provisioning certificates.<br />This value appears as `CFBundleIdentifier` in the associated *info.plist* file. See the Apple developer documentation on [CFBundleIdentifier](https://developer.apple.com/library/content/documentation/General/Reference/InfoPlistKeyReference/Articles/CoreFoundationKeys.html#/apple_ref/doc/uid/20001431-102070) to learn more. <br />**Note:** This is shared between iOS, tvOS and Android. |
|__Version__ |Enter the release-version-number string for the bundle (for example, 4.3.6). This appears as `CFBundleShortVersionString` in the associated *info.plist* file.<br/>See the Apple developer documentation on [CFBundleShortVersionString](https://developer.apple.com/library/archive/documentation/General/Reference/InfoPlistKeyReference/Articles/CoreFoundationKeys.html#//apple_ref/doc/uid/20001431-102364) to learn more. |
|__Build__ |Enter the build number for this version of your app. This appears as `CFBundleVersion` in the associated *info.plist* file.<br/> See the Apple developer documentation on [CFBundleVersion](https://developer.apple.com/library/archive/documentation/General/Reference/InfoPlistKeyReference/Articles/CoreFoundationKeys.html#//apple_ref/doc/uid/20001431-102364) to learn more. |
|__Signing Team ID__ |Enter your Apple Developer Team ID. You can find this on the Apple Developer website under [Xcode Help](https://help.apple.com/xcode/mac/current/#/devaf282080a?sub=dev8877b4398). This sets the Team ID for the generated Xcode project, allowing developers to use the Build and Run functionality. An Apple Developer Team ID must be set here for automatic signing of your app. For more information, see [Creating Your Team Provisioning Profile](https://help.apple.com/xcode/mac/current/#/dev60b6fbbc7).|
|__Automatically Sign__ |Enable this option to allow Xcode to automatically sign your build.|



<a name="Configuration"></a>

### Configuration

![Configuration settings for the tvOS platform](../uploads/Main/PlayerSettvOSOther-Configuration.png)




|**Setting** ||**Function** |
|:---|:---|:---|
|__Scripting Runtime Version__ ||Choose which .NET runtime to use in your project. For more details, see Microsoft's [.NET documentation](https://docs.microsoft.com/en-us/dotnet/).|
||_.NET 3.5 Equivalent (Deprecated)_|A .NET runtime which implements the .NET 3.5 API. This functionality is deprecated, and should no longer be used. Please use .NET 4.|
||_.NET 4.x Equivalent_|A .NET runtime which implements the .NET 4 API. This API is newer than .NET 3.5, and as such, it offers access to more APIs, is compatible with more external libraries, and supports C# 6. This is the default scripting runtime.|
|<a name="backend"></a>__Scripting Backend__ ||Choose the scripting backend you want to use.  This setting is not enabled for tvOS.|
|__API Compatibility Level__ ||There are two options for API compatibility level: _.NET 4.0_, or _.NET Standard 2.0_.<br />**Tip:** If you are having problems with a third-party assembly, you can try the suggestion in the [API Compatibility Level](#apiComp) section below.|
|__C++ Compiler Configuration__ ||Choose the C++ compiler configuration used when compiling IL2CPP generated code.  This setting is not enabled for tvOS.|
|<a name="on-demand"></a>__Use on Demand Resource__ ||Enable this option to use on-demand resources.<br />This setting has no effect for tvOS.|
|<a name="Accelerometer"></a>__Accelerometer Frequency__||Define how often to sample the accelerometer. If you choose _Disabled_, then no samples are taken. Otherwise, you can choose from _15Hz_, _30Hz_, _60Hz_ and _100Hz_ frequencies. |
|__Camera Usage Description__ ||Enter the reason for accessing the camera on the tvOS device.|
|__Location Usage Description__ ||Enter the reason for accessing the location of the tvOS device.|
|__Microphone Usage Description__ ||Enter the reason for accessing the microphone on the tvOS device.|
|__Mute Other Audio Sources__||Enable this option if you want your Unity application to stop Audio from applications running in the background. Otherise, Audio from background applications continues to play alongside your Unity application.|
|__Requires Persistent WiFi__ ||Enable this option to require a Wi-Fi connection. tvOS maintains the active Wi-Fi connection while the application is running.|
|__Allow downloads over HTTP (nonsecure)__||Enable this option to allow downloading content over HTTP. Default and recommended is HTTPS.|
|__Supported URL schemes__||A list of [supported URL schemes](https://developer.apple.com/library/ios/documentation/iPhone/Conceptual/iPhoneOSProgrammingGuide/Inter-AppCommunication/Inter-AppCommunication.html#/apple_ref/doc/uid/TP40007072-CH6-SW1).<br />To add new schemes, increase the value of the __Size__ property and then set a reference to the Asset to load in the new __Element__ box that appears. |
|__Disable HW Statistics__ ||Enable this option to instruct the application not to send information about the hardware to Unity. For more details, see [Unity Hardware Statistics](http://hwstats.unity3d.com/).|
|__Target SDK__ ||Select which SDK the game targets. The choices are _Device SDK_ and _Simulator SDK_.<br />**Note:** Be sure to select the correct SDK. For example, if you select the Device SDK but then target the Simulator in Xcode then the build will fail with a lot of error messages. |
|__Target minimum tvOS Version__ ||Defines the minimum version of tvOS that the game works on.|
|__Architecture__||Choose which architecture to target. This setting is not enabled for tvOS because it changes automatically depending on the value set for the __Target SDK__ property.|
|__Require Exended Game Controller__||Enable this if your app requires a game controller. For more information, see the Apple Developer documentation on [Game Controllers](https://developer.apple.com/design/human-interface-guidelines/tvos/remote-and-controllers/game-controllers/).|
|__Scripting Define Symbols__||Set custom compilation flags. For more details, see [Platform dependent compilation](PlatformDependentCompilation).|
|__Allow 'unsafe' Code__|| Enable support for compiling [‘unsafe’ C# code](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe) in a pre-defined assembly (for example, `Assembly-CSharp.dll`). <br />For Assembly Definition Files (`.asmdef`), click on one of your `.asmdef` files and enable the option in the Inspector window that appears. |
|__Active Input Handling__|| Choose how you want to handle input from users. |
||__Input Manager__| Use the traditional [Input](#class-InputManager) window. |
||__Input System (Preview)__| Use the newer [Input](ScriptRef:Input.html) system. The Input System is under development. To try an early preview of the Input System, install the [InputSystem package](https://github.com/Unity-Technologies/InputSystem). If you select the __Input System (Preview)__ option without having that package installed, nothing happens except for some extra processing.|
||__Both__| Use both systems side by side. |



<a name="apiComp"></a>

##### API Compatibility Level

You can choose your mono API compatibility level for all targets. Sometimes a 3rd-party .NET library uses functionality that is outside of your .NET compatibility level. In order to understand what is going on in such cases, and how to best fix it, try following these suggestions: 

1. Install [Reflector](http://www.airsquirrels.com/reflector/) for Windows. 
2. Drag the .NET assemblies for the API compatilibity level you are having issues with into Reflector. You can find these under `Frameworks/Mono/lib/mono/YOURSUBSET/`.
3. Drag in your 3rd-party assembly.
4. Right-click your 3rd-party assembly and select **Analyze**.
5. In the analysis report, inspect the **Depends on** section. The report highlights anything that the 3rd-party assembly depends on, but that is not available in the .NET compatibility level of your choice in red.




<a name="Optimization"></a>

### Optimization

![Optimization settings for the tvOS platform](../uploads/Main/PlayerSetiOSOther-Optimization.png)

|**Setting** ||**Function** |
|:---|:---|:---|
|**Prebake Collision Meshes**||Enable this option to add collision data to Meshes at build time. |
|**Keep Loaded Shaders Alive**||Enable this option to prevent shaders from being unloaded. |
|__Preloaded Assets__||Set an array of Assets for the player to load on startup. <br />To add new Assets, increase the value of the __Size__ property and then set a reference to the Asset to load in the new __Element__ box that appears.|
|__AOT compilation options__ ||Additional options for Ahead of Time (AOT) compilation. This helps [optimize the size of the built tvOS player](iphone-playerSizeOptimization).|
|__Strip Engine Code__ ||Enable code stripping. This setting is only available with the _IL2CPP_ [Scripting Backend](#backend). <br/>Most games don't use all necessary DLLs. With the __Strip Engine Code__ option enabled, you can strip out unused parts to reduce the size of the built player on tvOS devices. If your game is using classes that would normally be stripped out by the option you currently have selected, you'll be presented with a Debug message when you make a build.|
|__Managed Stripping Level__||Choose how aggressively Unity strips unused managed (C#) code.|
||_Normal_|Remove unreachable managed code to reduce build size and .NET/IL2CPP build times.|
||__Aggressive__|Run UnityLinker in a less conservative mode than normal, reducing code size even further than what Normal can achieve. However, this additional reduction may come with tradeoffs. For more information, see [ManagedStrippingLevel](ScriptRef:ManagedStrippingLevel.html). |
|<a name="scriptCallOpt"></a>__Script Call Optimization__ ||Choose how to optionally disable exception handling for a speed boost at runtime. See [iOS Optimization](iphone-iOS-Optimization) for details.|
||__Slow and Safe__ |Use full exception handling (with some performance impact on the device when using the Mono scripting backend). |
||__Fast but no Exceptions__ |No data provided for exceptions on the device (the game runs faster when using the Mono scripting backend).<br />**Note**: Using this option with the _IL2CPP_ [Scripting Backend](#backend) does not impact performance; however, using it can avoid undefined behavior on release builds. |
|__Vertex Compression__||Set vertex compression per channel. For example, you can enable compression for everything except positions and lightmap UVs. Whole Mesh compression set per imported object overrides where vertex compression is set on objects. Everything else obeys these vertex compression settings. |
|__Optimize Mesh Data__||Enable this option to remove any data from Meshes that is not required by the Material applied to them (such as tangents, normals, colors, and UVs).|



<a name="Logging"></a>

### Logging

Select what type of logging to allow in specific contexts.

![Logging settings for the tvOS platform](../uploads/Main/PlayerSetPCOther-Logging.png)

 Check one box that corresponds to each Log Type (__Error__, __Assert__, __Warning__, __Log__, and __Exception__) when running scripts (__ScriptOnly__) , all the time (__Full__), or never (__None__).



<a name="Legacy"></a>

### Legacy

Enable the __Clamp BlendShapes (Deprecated)__ option to clamp the range of Blend Shape weights in [SkinnedMeshRenderers](class-SkinnedMeshRenderer).

![Legacy settings for the tvOS platform](../uploads/Main/PlayerSetPCOther-Legacy.png)



<br/>

---
* <span class="page-edit">2018-08-16  <!-- include IncludeTextAmendPageYesEdit --></span>

