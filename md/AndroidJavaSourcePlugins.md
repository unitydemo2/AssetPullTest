# Using Java or Kotlin source files as plug-ins

Unity supports plug-ins for Android written in Java or Kotlin. This functionality allows you to add .java or .kt files into your Unity Project and they are compiled when you build an Android player. Previously you had to precompile these files as an android library.

Gradle is the only build system that supports this feature so use Gradle as your build system.

To compile the source files as a plug-in:

1. Open the Unity Editor.
2. Select the Project to add the plug-in to.
3. In the Projects window, select the Assets folder and create a folder for your plug-in.
4. Drag and drop your source files into the folder.
5. Select each of the files.
6. In the inspector window, under __Select platforms for plugin__, verify that only __Android__ is selected.
7. Build your Project.

__Note__: You can place your source files in any folder in your Project except in special use locations such as subfolders under Assets/Plugins/Android. If you place files in these locations, the Unity Editor will not display the plug-in inspector. For additional information, see [AAR plug-ins and Android Libraries](AndroidAARPlugins).

Use the [AndroidJavaObject](ScriptRef:AndroidJavaObject.html) class to call methods in your plug-in. For additional information see, the "Using your Java plug-in from C# scripts with helper classes" section in [JAR plug-ins](AndroidJARPlugins.html#javawithhelper). 

---------------
* <span class="page-edit">2018-11-29  <!-- include IncludeTextAmendPageYesEdit --></span>

* <span class="page-edit">2018-09-07 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Added plug-in support in 2018.2 </span>