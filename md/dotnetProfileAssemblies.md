# Referencing additional class library assemblies

If a Unity Project needs access to a part of the .NET class library API that is not compiled by default, the Project can inform the C# compiler in Unity. The behavior depends which .NET profile the Project uses.

## .NET Standard 2.0 profile

If your Projects use the .NET Standard 2.0 __Api Compatibility Level__, you shouldn’t need to take any additional steps to use part of the .NET class library API. If part of the API seems to be missing, it might not be included with .NET Standard 2.0. The Project may need to use the .NET 4.x __Api Compatibility Level__ instead.

## .NET 4.x profile

By default, Unity references the following assemblies when using the .NET 4.x __Api Compatibility Level__:

* mscorlib.dll
* System.dll
* System.Core.dll
* System.Runtime.Serialization.dll
* System.Xml.dll
* System.Xml.Linq.dll

You should reference any other class library assemblies using an _mcs.rsp_ file. You can add this file to the Assets directory of a Unity Project, and use it to pass additional command line arguments to the C# compiler. For example, if a Project uses the `HttpClient` class, which is defined in the _System.Net.Http.dll_ assembly, the C# compiler might produce this initial error message:

```
The type `HttpClient` is defined in an assembly that is not referenced. You must add a reference to assembly 'System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.
```

You can resolve this error by adding the following mcs.rsp file to the Project:

```
-r:System.Net.Http.dll
```

You should reference class library assemblies as described in the example above. Don’t copy them into the Project directory.

## Switching between profiles

Exercise caution when using an _mcs.rsp_ file to reference class library assemblies. If you change the __Api Compatibility Level__ from .NET 4.x to .NET Standard 2.0, and an _mcs.rsp_ like the one in the example above exists in the Project, then C# compilation fails. The _System.Net.Http.dll_ assembly does not exist in the .NET Standard 2.0 profile, so the C# compiler is unable to locate it.

The _mcs.rsp_ file can have parts that are specific to the current .NET profile. If you make changes to the profile, you need to modify the _mcs.rsp_ file.

---

* <span class="page-edit">2018-03-15  <!-- include IncludeTextAmendPageYesEdit --></span>
