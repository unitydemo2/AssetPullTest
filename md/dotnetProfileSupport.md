# .NET profile support

Unity supports a number of .NET profiles. Each profile provides a different API surface for C# code which interacts with the .NET class libraries. You can change the .NET Profile in the **Player** settings (go to __Edit__ > __Project Settings__, then select the __Player__ category) using the __Api Compatibility Level__ option in the __Other Settings__ panel.

## Legacy scripting runtime

The legacy scripting runtime supports two different profiles: .NET 2.0 Subset and .NET 2.0. Both of these are closely aligned with the .NET 2.0 profile from Microsoft. The .NET 2.0 Subset profile is smaller than the .NET 4.x profile, and it allows access to the class library APIs that most Unity projects use. It is the ideal choice for size-constrained platforms, such as mobile, and it provides a set of portable APIs for multiplatform support. By default, most Unity projects should use the .NET Standard 2.0 profile.

## Stable scripting runtime

The stable scripting runtime supports two different profiles: .NET Standard 2.0 and .NET 4.x.
The name of the .NET Standard 2.0 profile can be a bit misleading because it is not related to the .NET 2.0 and .NET 2.0 Subset profile from the legacy scripting runtime. Instead, Unity’s support for the .NET Standard 2.0 profile matches the profile of the same name published by the .NET Foundation. The .NET 4.x profile in Unity matches the .NET 4 series (.NET 4.5, .NET 4.6, .NET 4.7, and so on) of profiles from the .NET Framework.

Only use the .NET 4.x profile for compatibility with external libraries, or when you require functionality that is not available in .NET Standard 2.0.

## Cross-platform compatibility

Unity aims to support the vast majority of the APIs in the .NET Standard 2.0 profile on all platforms. While  not all platforms fully support the .NET Standard, libraries which aim for cross-platform compatibility should target the .NET Standard 2.0 profile. The .NET 4.x profile includes a much larger API surface, including parts which may work on few or no platforms.

## Managed plugins
Managed code plugins compiled outside of Unity can work with either the .NET Standard 2.0 profile or the .NET 4.x profile in Unity. The following table describes configurations Unity supports:


||API Compatibility Level:||
||**.NET Standard 2.0** |**.NET 4.x** |
|:---|:---|:---|:---|
|Managed plugin compiled against:| | |
|__.NET Standard__|Supported| Supported |
|__.NET Framework__ |Limited| Supported |
|__.NET Core__ |Not Supported| Not Supported |

**Note**:

* Managed plugins compiled against any version of the .NET Standard work with Unity.
* Limited support indicates that Unity supports the configuration if all APIs used from the .NET Framework are present in the .NET Standard 2.0 profile. However, the .NET Framework API is a superset of the .NET Standard 2.0 profile, so some APIs are not available.

## Transport Layer Security (TLS) 1.2
From 2018.2, Unity provides full TLS 1.2 support on all platforms except WebGL. It does this via the UnityWebRequest API and all .NET 4.x APIs.

Certificate verification is done automatically via the platform specific certificate store if available. Where access to the certificate store is not possible, Unity uses an embedded root certificate store.

TLS support for .NET 3.5 and below varies per platform and there are no guarantees on which features are supported.

---

* <span class="page-edit">2018-03-15  <!-- include IncludeTextAmendPageYesEdit --></span>

* <span class="page-history">.NET profile support added in [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) <span class="search-words">NewIn20181</span></span>
