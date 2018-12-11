#Upgrading to Unity 2018.1

This page lists any changes in 2018.1 which might affect existing projects when you upgrade from earlier versions of Unity

* * *


### Coroutines returned from a MonoBehaviour while its GameObject is being disabled or destroyed are no longer started.

Historically, when a GameObject is disabled or destroyed, it stops all running coroutines on its children MonoBehaviours. In certain cases, however, coroutines started from methods called during these times (for example, `OnBecameInvisible()`) were previously allowed to start. This led to component order-specific behavior and, in some cases, crashes.

In Unity 2018.1, coroutines returned during GameObject disable or destroy are no longer started.

* * *


### BuildPipeline APIs now return a BuildReport object instead of a string

The BuildPipeline APIs, such as `BuildPipeline.BuildPlayer`, and `BuildPipeline.BuildAssetBundles`, previously returned a string. This was empty if the build succeeded and contained an error message if the build failed.

In 2018.1, this has been replaced with the new BuildReport object, which contains much richer information about the build process.

To check whether the build succeeded, retrieve the `summary` property of the report object, and check its *result* property - it will be `BuildResult.Succeeded` for a successful build. For example:

```
var report = BuildPipeline.BuildPlayer(...);

if (report.summary.result != BuildResult.Succeeded)
{
    throw new Exception("Build failed");
}
```

* * *


### Player Quit notifications have changed from messages to Events 

Previously, to be notified when the Unity standalone player was quitting, you would implement the `OnApplicationQuit` method on a MonoBehaviour and to abort the player from quitting you would call `Application.CancelQuit`. 

Two new events have been introduced. These are `Application.wantsToQuit` and `Application.quitting`. You can listen to these events to get notified when the Unity standalone player is quitting. `Application.wantsToQuit` is called when the player is intending to quit, the listener for `wantsToQuit` must return true or false. Return true if you want the player to continue quitting or false to abort the quit. The `Application.quitting` event is called when the player is guaranteed to quit and cannot be aborted. 

`Application.CancelQuit` has been deprecated, please use the `Application.wantsToQuit` instead.

```
using UnityEngine;

public class PlayerQuitExample

{

	static bool WantsToQuit()

	{

		// Do you want the editor to quit?

		return true;

	}

	static void Quit()

	{

		Debug.Log("Quitting the Player");

	}

	[RuntimeInitializeOnLoadMethod]

	static void RunOnStart()

	{

		Application.wantsToQuit += WantsToQuit;

		Application.quit += Quit;

	}

}
```

* * *


### Deprecating AvatarBuilder.BuildHumanAvatar on .Net platform

This change affect the following runtime platform: WSAPlayerX86, WSAPlayerX64, and WSAPlayerARM.

There is no replacement for now.

* * *


### TouchScreenKeyboard.wasCanceled and TouchScreenKeyboard.done have been made obsolete

There is a new TouchScreenKeyboard.status that can be queried to cover the deprecated states and more states.

* * *


### MonoDevelop 5.9.6 removed from Unity Installers and support for it has been deprecated in Unity.

MonoDevelop 5.9.6 has been replaced by Visual Studio for Mac on macOS as the bundle C# script editor in the macOS installer. Visual Studio 2017 Community is now the only C# script editor installed with Unity on Windows.


When it is installed in the default location next to the Unity executable, Unity no longer recognises MonoDevelop as the "MonoDevelop (built-in)" external script editor in preferences. When no C# code editor is installed and selected in preferences, Unity uses the system default application for opening C#  (.cs) scripts.

* * *


### BuildPipeline callback interfaces now take a BuildReport object

The BuildPipeline callback interfaces: `IPreprocessBuild`, `IPostprocessBuild` and `IProcessScene` have been changed so that they now require you to pass in a `BuildReport` object. This replaces the previous parameters for build path / target platform; you will need to change your code if you are implementing these interfaces.

Both the build path and the target platform can be accessed via the `BuildReport` object. The build path is now `report.summary.outputPath` and the target platform is `report.summary.platform`.

* * *


### Assets located in plugin folders will no longer be imported via specialized importers

Previously, assets located in plugin folders (for example, in directories with the extension .bundle, .plugin, or .folder) were imported using specialized importers. Textures were imported via texture importers, AudioClips via the audio importer, etc. Now all those assets will be imported using default importer, that means you won’t be able to reference those assets like you did before, because they no longer have a specialized type (Texture, AudioClip, etc). Plugin folders are contained packages, thus assets inside shouldn’t be accessible externally, except through plugin accessing techniques.

To continue using those assets, you’ll need to move them outside of your plugin folders.

* * *


### Particle System Mesh particles applied the Pivot Offset value incorrectly

The mathematical formula used for applying pivot offsets to Meshes was incorrect, and was inconsistent with how it worked for Billboard particles. To achieve the correct scale, the Pivot Offset should be multiplied by the size of the particle, so a Pivot Offset of 1 is equal to one full width of the particle.

For Meshes, the size was being multiplied twice, meaning the pivot amount was based on the squared particle size. This made it impossible to get consistent results in systems containing varying sized particles. 

For systems using particles of equal size, the formula can be reverse-engineered to decide how much to adjust the pivot offset by, to compensate for this change in behavior:

Old formula: __offset = size * size * pivot__

New formula: __offset = size * pivot__

Therefore, if all particles are of equal size:

__newOffset = pivot / size__

In systems where the size varies between particles, a visual reassessment of the systems in question will be necessary.

* * *


### GPU Instancing supports Global Illumination

From 2018.1, Global Illumination (GI) is supported by GPU Instancing rendering in Unity. Each GPU instance can support GI coming from either different [Light Probes](https://docs.unity3d.com/Manual/LightProbes.html), one [lightmap](https://docs.unity3d.com/Manual/Lightmapping.html) (but different region in the atlas), or one [Light Probe Proxy Volume](https://docs.unity3d.com/Manual/class-LightProbeProxyVolume.html) component (baked for the space volume containing all the instances). Standard shaders and surface shaders come with these changes automatically, but you need to update custom shader code to enable these features.

* * *


### Handle Draw and Size Function Defaults

Complex handles in the UnityEditor.IMGUI.Controls namespace, such as BoxBoundsHandle, CapsuleBoundsHandle, SphereBoundsHandle, ArcHandle, and JointAngularLimitHandle have delegates that can be assigned to, in order to alter the appearance of their control points. Previously, assigning a value of null to these delegates would fall back to a default behavior. Assigning a value of null to them now results in no behavior, making it easier to disable particular control handles. Respectively, each class now has public API points for the default methods if you need to reset the control handles to their default behavior.

* * *


### Compiling ‘unsafe’ C# code in the Unity Editor now requires enabling of option.

Compiling ‘unsafe’ C# code now requires the __Allow ‘unsafe’ code__ option to be enabled in the Player Settings for predefined assemblies (like Assembly-CSharp.dll) and in the inspector for Assembly Definition Files assemblies. Enabling this option will make Unity pass /unsafe option to the C# compiler when compiling scripts.

* * *


### ‘UnityPackageManager’ directory renamed to ‘Packages’

In 2017.2 and 2017.3, the Unity Package Manager introduced the __UnityPackageManager __directory, which was used to store a file named __manifest.json__. Package content could be accessed by scripts using virtual relative paths starting with __Packages__.

In 2018.1, the __UnityPackageManager __directory has been renamed to __Packages__ for consistency with the virtual relative paths of packaged assets. The __manifest.json__ file should automatically be moved to the new directory.

As a result:

* If your project uses a Version Control System (VCS) such as Perforce or Git, it may be necessary to update its configuration to track the __Packages __directory instead of the __UnityPackageManager__ directory.

* If your project uses Nuget (or any external package manager) in a way that makes it use the __Packages__ directory, its configuration should be changed to use a different directory. This is recommended to eliminate the small chance that a package be picked up by the Unity Package Manager, which could result in hard-to-debug issues like compilation errors or import errors.

    * To configure Nuget to use a different directory to store its packages, please refer to [the official Microsoft documentation](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior).

* After migrating to the new directory, the __UnityPackageManager__ directory can safely be deleted.

<br/><br/> For more information about what's new in 2018.1 and for more detailed upgrade notes, see the [2018.1 Release Notes](https://unity3d.com/unity/whats-new/unity-2018.1.0)
