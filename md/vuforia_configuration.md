# Vuforia platform configuration settings

This section provides information about the important XR platform settings affecting development of Vuforia Augmented/Mixed Reality applications with Unity.

Here is a list of important **XR Settings** used in Vuforia's Unity integration. To access these, open the **Player** settings (__Edit__ &gt; __Project Settings__, then select the __Player__ category), then select the tab for the device you are building to):

* __Vuforia Augmented Reality support__: Enables Vuforia Augmented Reality support in your application

* __Virtual Reality SDKs__: Allows Vuforia features to be integrated into VR applications. This menu is displayed when you select the Virtual Reality Supported checkbox.

![Vuforia Augmented Reality Support and Virtual Reality SDKs list in XR Settings](../uploads/Main/vuforia_ar_support.png)

Vuforia supports the following XR SDKs:

* [Google Cardboard through Google VR SDK](https://developers.google.com/vr/cardboard/overview)

* [Google Daydream through Google VR SDK](https://developers.google.com/vr/cardboard/overview)

* [Microsoft HoloLens through Windows 10 SDK](https://developer.microsoft.com/en-us/windows/mixed-reality/install_the_tools)

* [Vuforia SDK](https://library.vuforia.com/content/vuforia-library/en/articles/Best_Practices/Best-practices-for-hybrid-VRAR-experiences.html)

The __Vuforia VR SDK__ (in the __Virtual Reality SDKs__ list) is a stand-alone VR configuration with no external dependencies. It provides stereo rendering and distortion correction, along with head and hand tracking (with positional tracking available for Tango), and viewer profile support to define parameters of various VR headwear.

## Stereo rendering method

The stereo rendering method is only relevant when using the Vuforia Virtual Reality SDK. Android, iOS, and Windows Mixed Reality devices support Multi-Pass instancing, Single-Pass Instancing and non-instancing.

When using Vuforia Augmented Reality with another Virtual Reality SDK, stereo rendering support is determined by the Virtual Reality SDK being used.

## Supported graphics APIs

__Recommendation:__ In Unity's **Player** settings (menu: __Edit__ &gt; __Project Settings__, then select the __Player__ category), select the tab for the device you are building to open the __Other Settings__ panel and enable __Use Auto Graphics API__.


| __Android__| __iOS__ | __Windows__ |
|:---|:---|:---|
| OpenGL ES 2.0<br/>OpenGL ES 3.x| OpenGL ES 2.0<br/>OpenGL ES 3.x <br/>Metal (iOS 8+) | DirectX 11 on Windows 10 |

## Supported features

Vuforia provides a number of features to allow development of AR/MR applications.

The table below lists these features along with the OS and device types supporting them.

| **Feature**| **Description** | **OS** | **Handhelds** | **Eyewear** |
|:---|:---|:---|:---|:---|
| Image Targets| Tracks planar images | Android, iOS, UPW | Yes | Yes |
| Multi Targets| Tracks geometric arrangements of images | Android, iOS, UPW | Yes | Yes |
| Cylinder Targets| Tracks images wrapped on cylinders and cones | Android, iOS, UPW | Yes | Yes |
| User Defined Targets| Tracks images captured by users at runtime | Android, iOS, UPW | Yes | Not recommended |
| Cloud Recognition| Cloud-based Image Targets | Android, iOS, UPW | Yes | Yes |
| Device Tracking| 3 DoF & 6 DoF positional tracking*  | Android, iOS, UPW | Yes ( Limited to 6 DoF ) | Yes ( Limited to 6 DoF ) |
| VuMark| Customizable encodable AR markers | Android, iOS, UPW | Yes | Yes |
| Object Reco| Tracks 3D objects from scans | Android, iOS, UPW | Yes | Yes |
| Model Targets**| Track 3D objects from 3D models | Android, iOS, UPW | Yes | Yes |
| Smart Terrain| Track surfaces and geometry in the user’s environment | Android, iOS, UPW | Yes | Limited |
| AR + VR| AR feature support for VR apps | Android, iOS, UPW | Yes | Yes |

__*__ 6 degrees of freedom tracking is available for Tango and HoloLens devices

__**__ Model Targets are available through the Vuforia Early Access Program and public in Unity 2017.3

---
