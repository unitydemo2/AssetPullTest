# C# compiler

To compile C# source code in a Unity Project, the Unity Editor uses a C# compiler. The C# compiler that Unity uses depends on the __Scripting Runtime Version__ option in the Player Settings (menu: __Edit__ > __Project Settings__ > __Player__ > __Other Settings__).

| __Scripting Runtime Version__ | **C# compiler** | **C# language version** |
| :------------- |:-------------| :-----|
|.NET 3.5 equivalent | [mcs](https://www.mono-project.com/docs/about-mono/languages/csharp/) | [C# 4](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-40) |
|.NET 4.6 equivalent | [Roslyn](https://github.com/dotnet/roslyn) | [C# 7.3](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-3) |

The Editor passes a default set of options to the C# compiler. To pass additional options in your project, see the documentation for [Platform Dependent Compilation](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html).

---

* <span class="page-edit">2018-11-07  <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Roslyn compiler exposed in [2018.3](https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>

<span class="search-words">C# compiler</span>
<span class="search-words">Roslyn compiler</span>
<span class="search-words">NewIn20183</span>