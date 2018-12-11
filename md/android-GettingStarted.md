# Getting started with Android development

The [Android environment setup](android-sdksetup) topic of the Unity Manual contains a basic outline of the tasks that you must complete before you are able to run code on your Android device, or in the Android emulator. For more in-depth information on setting your Android development environment, see the step-by-step  instructions on the [Android developer portal](http://developer.android.com/sdk).

If you miss installing some necessary item during set-up, Unity verifies your development environment when building for Android and prompts you to upgrade or download missing components.

Unity provides scripting APIs that allow you to access various input data and settings from Android devices.

Refer to the [Android scripting page](android-API) of the Manual for more information.

## Exposing native C, C++ or Java code to scripts

Use plug-ins to call Android functions written in C/C++ directly from C# scripts (Java functions can be called indirectly).

To find out how to make these functions accessible from within Unity, visit the [Android plug-ins page](PluginsForAndroid).

## Occlusion culling

Unity includes support for occlusion culling, which is a valuable optimization method for mobile platforms.

Refer to the [Occlusion Culling](OcclusionCulling) Manual page for more information.

## Splash screen customization

You can customize the splash screen that displays while the game launches on Android.

Refer to the [Customizing an Android Splash Screen](AndroidMobileCustomizeSplashScreen) Manual page for more information.

## Troubleshooting and bug reports

The [Android troubleshooting guide](TroubleShootingAndroid) helps you discover the cause of bugs as quickly as possible. If, after consulting the guide, you suspect the problem is being caused by Unity, file a bug report following the Unity bug reporting guidelines.

See the [Android bug reporting page](android-bugreporting) for details about filing bug reports.

<a name="compression"></a>
## Texture compression

Ericsson Texture Compression (ETC) is the standard texture compression format on Android.

ETC1 is supported on all current Android devices, but it does not support textures that have an alpha channel. ETC2 is supported on all Android devices that support OpenGL ES 3.0. It provides improved quality for RGB textures, and also supports textures with an alpha channel.

By default, Unity uses ETC1 for compressed RGB textures and ETC2 for compressed RGBA textures. If ETC2 is not supported by an Android device, the texture is decompressed at run time. This has an impact on memory usage, and also affects rendering speed.

DXT, PVRTC, ATC, and ASTC are all support textures with an alpha channel. These formats also support higher compression rates and/or better image quality, but they are only supported on a subset of Android devices.

It is possible to create separate Android distribution archives (.apk) for each of these formats and let the Android Market’s filtering system select the correct archives for different devices.

## Movie/Video playback

We recommend you use the [Video Player](VideoPlayer) to play video files. This supersedes the earlier Movie Texture feature.

---

* <span class="page-history">Video Player component added in Unity 5.6</span>
