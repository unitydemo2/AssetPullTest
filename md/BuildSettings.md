# Build Settings

The Build Settings window allows you to choose your target platform, adjust settings for your build, and start the build process. To access the Build Settings window, select __File__ > __Build Settings...__ . Once you have specified your build settings, you can click __Build__ to create your build, or click the __Build And Run__ to create and run your build on the platform you have specified.

![Build Settings window](../uploads/Main/BuildSettings.png)

## Scenes in Build

This part of the window shows you the scenes from your project that will be included in your build.  If no scenes are shown then you can use the *Add Current* button to add the current scene to the build, or you can drag scene assets into this window from your project window. You can also untick scenes in this list to exclude them from the build without removing it from the list.  If a scene is never needed in the build you can remove it from the list of scenes by pressing the delete key.

Scenes that are ticked and added to the Scenes in Build list will be included in the build. The list of scenes will be used to control the order the scenes are loaded. You can adjust the order of the scenes by dragging them up or down.

## Platform List

The Platform area beneath the Scenes in Build area list all the platforms which are available to your Unity version.  Some platforms may be greyed out to indicate they are not part of your version or invite you to download the platform specific build options.  Selecting one of the platforms will control which platform will be built. If you change the target platform, you need to press the "Switch Platform" button to apply your change.  This may take some time making the switch, because your assets may need to be re-imported in formats that match your target platform.  The currently selected platform is indicated with a Unity icon to the right of the platform name.

The selected platform will show a list of options that can be adjusted for the build.  Each platform may have different options.  These options are listed below.  Options that are common across many platforms are listed at the very bottom of this section under the "Generic items across builds" details.

### PC, Mac & Linux Standalone
|Option |Purpose |
|---|---|
|Target Platform ||
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Windows |Build for Windows|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Mac OS X|Build for Mac|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Linux|Build for Linux|
|Architecture |x86|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;x86|32-bit CPU |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;x86_64|64-bit CPU |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Universal|All CPU devices |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;x86 + x86_64 (Universal) |All CPU devices for Linux |
|Server Build|Build the Player for server use and with no visual elements (headless) without the need for any command line options. When enabled, Unity builds managed scripts with the UNITY_SERVER define, which enables you to write server-specific code for your applications. You can also build to the Windows version as a console app so that `stdin` and `stdout` are accessible (Unity logs go to `stdout` by default).|
|Copy PDB files |(Windows only) Include Microsoft program database (PDB) files in the built Standalone Player. PDB files contain application debugging information that is useful for debugging, but may increase the size of your Player. This setting is disabled by default. |
|Headless Mode |Build game for server use and with no visual elements |


### iOS
|Option ||Purpose |
|---|---|
|Run in Xcode ||Select the version of Xcode to use in the build. When set to Latest version,the build uses the most recent version of Xcode on your machine. |
|Run in Xcode as || |
||Release|Shipping version  |
||Debug|Testing version  |
|Symlink Unity libraries ||Reference to the Unity libraries instead of copying them into the XCode project.  (Reduces the XCode project size.) |

### Android

For information on Android build settings, see [Building apps for Android](android-BuildProcess).

### WebGL
Build Settings for WebGL use the generic settings shown later on this page.

### Samsung TV
Build Settings for Samsung TV use the generic settings shown later on this page.

### Xiaomi 

For information about building projects for Xiaomi Game Center, see [Unity Xiaomi documentation](https://unity3d.com/cn/partners/xiaomi/guide).


### Other platforms

Console platforms and devices which require a Unity license will be documented in the Platform Specific section of the User Guide.

### Generic items across builds

|Option ||Purpose |
|---|---|---|
|Development Build ||Allow the developer to test and work out how the build is coming along.|
|Autoconnect Profiler ||When the Development Build option is selected allow the profiler to connect to the build.|
|Script Debugging ||When the Development Build option is selected allow the script code to be debugged.  Not available on WebGL.|
|Scripts Only Build ||Build just the scripts in the current Project.|
|Compression Method ||Compress the data in your Project when building the Player. This includes [Assets](AssetTypes), [Scenes](CreatingScenes), [Player](class-PlayerSettings) settings and [GI data](GICache). Choose between the following methods:|
||Default | On PC, Mac, Linux Standalone, and iOS, there is no compression by default. On Android, the default compression is ZIP, which gives slightly better compression results than LZ4HC, but data is slower to decompress.|
||LZ4 |A fast compression format that is useful for development builds. For more information, see [BuildOptions.CompressWithLz4](ScriptRef:BuildOptions.CompressWithLz4.html).|
||LZ4HC | A high compression variant of LZ4 that is slower to build but produces better results for release builds. For more information, see [BuildOptions.CompressWithLz4HC](ScriptRef:BuildOptions.CompressWithLz4HC.html).|

---
* <span class="page-edit">2018-09-18  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Xiaomi build target added in [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) <span class="search-words">NewIn20172</span></span>

* <span class="page-history">Tizen support discontinued in [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>

* <span class="page-history">Server Build option added for Standalone Player Build Settings in Unity [2018.3] (https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
