# Known limitations of IL2CPP

## Access to the MarshalAs attribute via reflection

In other .NET runtimes, you can use the [GetCustomAttributes](https://msdn.microsoft.com/en-us/library/system.attribute.getcustomattributes(v=vs.110).aspx) method to access information about the `MarshalAs` attribute that is applied to a field. IL2CPP does not support access to the attribute via reflection, which prevents Unity from storing additional metadata that would increase the final project build size.

If your project needs to reflect on data stored in a `MarshalAs` attribute, modify your game scripts to store that data in an [actual custom attribute](https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes), in addition to `MarshalAs`. Then you can access the data via reflection with IL2CPP.

## Use of CharSet.Auto in DLLImport attributes

When `CharSet.Auto` is the value used for a `DllImport` attribute, the default behavior in C# is to use `CharSet.Ansi`. On Windows Vista and above, that default becomes `CharSet.Unicode` (See all of the details [here](https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.charset(v=vs.110).aspx)).

The behavior of `CharSet.Auto` with IL2CPP is the same on all platforms: `CharSet.Ansi`. This means calls into a Win32 API, like [`GetClassName`](https://msdn.microsoft.com/en-us/library/windows/desktop/ms633582(v=vs.85).aspx), will not work properly. Work around this issue by explicitly using `CharSet.Unicode`, which will work on Mono and IL2CPP.

---

* <span class="page-edit"> 2018-08-08  <!-- include IncludeTextAmendPageNoEdit --></span>

* <span class="page-edit"> 2018-12-01  <!-- include IncludeTextNewPageSomeEdit --></span>

* <span class="page-history">Windows XP support in Standalone Player removed in 2018.1</span>
