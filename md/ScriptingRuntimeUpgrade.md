#Scripting Runtime
The default __Scripting Runtime Version__ is .NET 4.6. (.NET 3.5 is marked as deprecated.) This option is a per-Project setting that you specify in the Unity Editor **Player** settings (__Edit &gt; Project Settings__, then select the __Player__ category), in the __Configuration__ section:


![](../uploads/Main/ScriptingRunetimePreview.png)

The equivalent scripting API is the [PlayerSettings.scriptingRuntimeVersion](ScriptRef:PlayerSettings-scriptingRuntimeVersion.html) property. 

**Important**: Changing this property requires an Editor restart because it affects the Editor as well as Players.

By default nothing should change about how Unity behaves or what .NET functionality is available. Once you use .NET 4.6 for a project, you will be able to use C# 6, .NET 4.6 class libraries, and new runtime features in user scripts and precompiled assemblies.

**Note** The .Net 3.5 scripting runtime is deprecated, but it will be available for Unity 2018.3 and 2018.4 LTS. Please migrate or start new Projects with the .NET 4.x runtime.

## FAQ

### What platforms does this affect?

All of them, but in different ways:

- Editor and Standalone use the new version of Mono when this option is enabled.

- All console platforms will only be able to use IL2CPP when targeting the new .NET version.

- iOS and WebGL will continue to be IL2CPP only.

- Android will continue to support both Mono and IL2CPP.

- Other platforms are still undergoing work to support either new Mono or IL2CPP

### What about IL2CPP?

IL2CPP fully supports the new .NET 4.6 APIs and features.

### How stable is the updated Mono/IL2CPP?

The internal, automated tests for Unity pass with the new Mono/IL2CPP. Of course, we still expect you may encounter issues. Please file bugs for any issues you encounter.

### Does this preview include a new GC?

No. This is an upgrade of the class libraries and runtime, but we are still using the Boehm GC. We are targeting a new version of Boehm that we use with IL2CPP (so IL2CPP and Mono will have exact same GC).

### Wait, why don't we have a new GC?

The newer Mono garbage collector (SGen) requires additional work in Unity and will follow once we have stabilized the new runtime and class libraries.

### Can I debug managed code with this new Mono?

VSTU 3.1 is required for our new Mono. Please install it to use the new Mono runtime on Windows.

### Why are my builds larger with the new .NET version?

The .NET 4.6 class libraries are quite larger than our current .NET 3.5 class libraries. We are actively working on improving the managed linker to reduce size further.

Additionally, we are working on a new Unity specific class library API profile (like our current __unity__ profile) that will:

a) be specifically implemented to work on AOT platforms

b) smaller in surface area and internally designed to be strippable/linkable

c) support [netstandard 2.0](https://github.com/dotnet/standard/blob/master/docs/netstandard-20/README.md) (yet to be officially released)

### When I try this new option, something doesn't work. What should I do?

Please file a bug. We will be rapidly fixing them!

----

*  <span class="page-edit">2018-08-02  <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-history">MonoDevelop replaced by Visual Studio from 2018.1</span>

* <span class="page-history">.Net 3.5 scripting runtime deprecated in Unity [2018.3](../Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
