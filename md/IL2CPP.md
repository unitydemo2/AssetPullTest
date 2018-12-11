#IL2CPP

IL2CPP (Intermediate Language To C++) is a Unity-developed scripting backend which you can use as an alternative to Mono when building projects for various platforms. When building a project using IL2CPP, Unity converts IL code from scripts and assemblies to C++, before creating a native binary file (.exe, apk, .xap, for example) for your chosen platform. Some of the uses for IL2CPP include increasing the performance, security, and platform compatibility of your Unity projects. 

For more information about using IL2CPP, refer to the [The Unity IL2CPP blog series](https://blogs.unity3d.com/2015/05/06/an-introduction-to-ilcpp-internals/) and the following Unity Manual pages. 

* [Building a project using IL2CPP](IL2CPP-BuildingProject)
* [How IL2CPP works](IL2CPP-HowItWorks)
* [Optimising IL2CPP build times](IL2CPP-OptimizingBuildTimes)

See the [Scripting Restrictions](ScriptingRestrictions) page for details about which platforms support IL2CPP.

IL2CPP supports debugging of managed code in the same way as the Mono scripting backend.

---
<span class="page-edit">• 2018-05-15  <!-- include IncludeTextAmendPageSomeEdit --></span><br/>