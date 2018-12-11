# Building apps for Android

There are two locations to configure settings that affect how your app is built:

* Player settings - Allows you to configure runtime settings for the app.  For more information on Player settings, see [Player settings for the Android platform](class-PlayerSettingsAndroid).
* Build settings - Allows you to configure build system parameters and build the app.

The output package includes an APK, and an APK expansion file (OBB) if the __Split Application Binary__ option is selected in the [Player](class-PlayerSettings) settings.  For more information on OBB files, see  [OBB Support](android-OBBsupport).

To optimize for download and installation size, enable the  __Split APKs by target architecture__ option in the [Player](class-PlayerSettingsAndroid) settings.  The __Split APKs by target architecture__ option produces one set of APKs and OBBs for each device architecture selected in the __Target Architecture__ list in the __Player__ settings. You can upload this set of APKs (and OBBs, if enabled) to the Google Play, or other, store instead of a FAT APK  in which all of the selected architectures are included into a single APK.   For more information on this feature, see Multiple APK support on the[ Android Developer](https://developer.android.com/google/play/publishing/multiple-apks) website. 

## Configuring Build Settings

To configure and build apps for Android, access the Build Settings window, select __File__ &gt; __Build Setting__. In __Platforms__, select __Android__. 

To set Android as your default build platform, click the __Switch Platform__ button.

When you have specified your build settings, click the __Build__ button to create your build. To build the app, click __Build And Run__ to create and run your build on the platform you have specified. In Platform, select __Android__.

| Option| Purpose |
|:---|:---|
| Texture Compression| The Unity Android build system supports the following texture compression format options: Don't override, DXT (Tegra), PVRTC (PowerVR), ETC (default), ETC2 (GLES 3.0), and ASTC.  For advice on using these formats, see the Texture Compression section. |
| ETC2 fallback| 32-bit, 16-bit, and 32-bit, half resolution. |
| Build System|  |
|         | Internal (deprecated) - Generate the output package (APK) using the internal Unity build process, based on Android SDK utilities. Selecting Internal hides the Export Project checkbox. |
|         | Gradle - Generate the output package (APK) using the Gradle build system. Supports direct Build and Run and exporting the Project to a directory. This is the default Build System for Unity. |
| Export Project| Export the Project as a Gradle project that you can import into Android Studio. |
|Build AppBundle (Google play)| Build an [Android App Bundle](https://developer.android.com/platform/technology/app-bundle/) for distribution on Google Play. |
|Run Device | A drop-down list of attached devices on which you can test your build. If you connect a new device or or you don't see an attached device in the list, click the **Refresh** button to reload the list. |
| Development Build| A development build includes debug symbols and enables the Profiler. Selecting Development Build allows you to select the Autoconnect Profiler, Script Debugging, and Scripts Only Build options. |
| Autoconnect Profiler| Allows the Profiler to automatically connect  to the build. Selectable when the Development Build option is selected. For more information on the Profiler, see Profiler Overview. |
| Script Debugging| Allow script debuggers to attach to the Player remotely. Enabled when the Development Build option is selected. |
| Scripts Only Build| Check this option to build just the scripts in the current Project. Enabled when the Development Build option is selected. |
| Compression Method| Compress the data in your Project at build time. Choose between the following methods: |
| | Default - The default compression is ZIP, which gives slightly better compression results than LZ4 and LZ4HC, but data is slower to decompress. |
| | LZ4 - A fast compression format that is useful for development builds.  Using LZ4 compression can significantly improve loading time of games/apps built with Unity. For more information, see BuildOptions.CompressWithLz4. |
| | LZ4HC - A high compression variant of LZ4 that is slower to build but produces better results for release builds. Using LZ4HC compression can significantly improve loading time of games/apps built with Unity. For more information, see [BuildOptions.CompressWithLz4HC](ScriptRef:BuildOptions.CompressWithLz4HC.html). |
| SDKs for App Stores| Select which third party app stores to integrate with. To include an integration, click Add next to an App Store name. The Unity Package Manager automatically downloads and includes the relevant integration package. |

## Texture compression

Unity uses the Ericsson Texture Compression (ETC) format for textures that don’t have individual texture format overrides. When building an APK to target specific hardware, use the __Texture Compression__ option to override this default behavior. __Texture Compression__ is a global setting for the Project. If a texture has a specific override on it, that texture is not affected by the __Texture Compression__ setting. For additional information, see [Textures](https://docs.unity3d.com/Manual/class-TextureImporter.html).

For additional information on textures and texture compression, see [Android 2D Textures Overrides](https://docs.unity3d.com/Manual/class-TextureImporterAndroid.html).

For additional information on the texture compression formats, see [Texture compression formats for platform-specific overrides](class-TextureImporterOverride). In particular, see the __Notes on Android__ at the end of the topic.

**Note**: __Texture Compression__ is a global setting. Individual textures override the global setting. 

## ETC2 fallback

For Android devices that don't support ETC2 (which don’t support GL ES3), you can override the default ETC2 texture decompression by choosing from 32-bit, 16-bit, or 32-bit with half the resolution formats.

This option allows you to choose between the uncompressed image quality and the amount of memory the uncompressed texture occupies. 32-bit RGBA texture is the highest quality format, and takes twice the required disk space as the 16-bit format, but a texture in 16-bit might lose some valuable color information. 32-bit half-resolution reduces the memory requirement further, but the texture is likely to become blurry.

## Build system

Unity supports two Android build systems: __Gradle__ and __Internal__.

The steps involved with building for Android are:

* Preparing and building the Unity Assets.
* Compiling scripts.
* Processing the plug-ins.
* Splitting the resources into the parts that go to the APK and the OBB, if __Split Application Binary__ is selected.
* Building the Android resources using the AAPT utility (internal build only.)
* Generating the Android manifest.
* Merging the library manifests into the Android manifest (internal build only.)
* Compiling the Java code into the Dalvik Executable format (DEX) (internal build only.)
* Building the [IL2CPP](IL2CPP) library, if __IL2CPP Scripting Backend__ is selected.

* Building and optimizing the APK and OBB packages.

__Gradle build system__

The Gradle build system uses Gradle to build an APK or export a Project in Gradle format, which can then be imported to Android Studio. When you select this build system, Unity goes through the same steps as the __Internal__ build system excluding resource compilation with AAPT, merging manifests, and running DEX. Unity then generates the *build.gradle* file (along with the other required configuration files) and invokes the Gradle executable, passing it the task name and the working directory. Finally, the APK is built by Gradle.

For more details, see [Gradle for Android](android-gradle-overview).

__Internal build system__

The __Internal__ build system creates an APK using the Android SDK utilities to build and optimize the APK and OBB packages. For more information about OBB files, see [OBB Support](android-OBBsupport). 

## Exporting the Project

If you need more control over the build pipeline, or to make changes that Unity does not normally allow (for example, fine tuning the manifest files that are automatically generated by Unity), you can export your Project and import it into Android Studio. Exporting a Project is only available when you have selected __Gradle__ as your __Build System__.

To export the Project:

1. From the __Build System__ drop-down menu, select __Gradle__.
2. Check the __Export Project__ checkbox. When __Export Project__ is checked, the __Build__ button is relabeled __Export__ and the __Build And Run__ button is disabled.
3. Click the __Export__ button and select a destination folder for the roject.

When the export finishes, open Android Studio and import your project. For more information on importing projects to Android Studio, see the [Migrate to Android Studio](https://developer.android.com/studio/intro/migrate.html) section of the Android Developer documentation.

## Build or Build and Run

The __Build Settings__ window offers two options: __Build__ and __Build and Run__. Using either option saves the output packages (APK and OBB, if enabled) to the path that you select. You can publish these packages to the Google Play Store, or install them on your device manually with the help of Android Debug Bridge (ADB). For further information about installing apps manually, see the [Run your app](https://developer.android.com/training/basics/firstapp/running-app.html) section of the Android Developer documentation. For information on __ADB__ commands, see the [Android Debug Bridge](https://developer.android.com/studio/command-line/adb.html) section of the Android Developer documentation.

Selecting __Build and Run__ saves the output packages to the file path you specify, while also installing your app on the Android device connected to your computer.

If the __Split Application Binary__ option is enabled, the OBB file is pushed to the correct location on your device. If __Development Build__ is checked, Unity also sets up a Profiler tunnel and enables __CheckJNI__. After that, the app is launched. The __Split Application Binary__ setting is located in the __Publishing Settings__ section of the [Player](class-PlayerSettingsAndroid#Publishing) settings.

__Tip__: Specify the output path for the packages and then use the __Ctrl+B__ (Windows) or __Cmd+B__ (macOS) keyboard shortcut to __Build and Run__ using the saved output path.

----
* <span class="page-edit">2018-11-19 <!-- include IncludeTextAmendPageYesEdit --></span>

* <span class="page-history">Updated functionality in 5.5</span>
* <span class="page-history">Updated the Build Settings Configuration options</span>
