# Vuforia hardware and software requirements

This page provides an overview of both hardware and software requirements for using the Vuforia SDK with Unity.

## Mobile devices

The table below lists the supported mobile device operating system (OS) versions required for running applications created with the Vuforia SDK. The table also includes supported OS and Unity versions for developing applications with Vuforia.

| **Device OS**|  | **Development OS **|  | **Unity Version**|  |
|:---|:---|:---|:---|:---|:---| 
| Android (1)| 4.1.x+ | Windows (2) | 7+ | Windows (2) | 2017.2+ |
| iOS (2) | 9+ | OS X | 10.11+ | OS X | 2017.2+ |
| Windows (2)| 10 UWP |  |  |  |  |

1. 32-bit only 
2. 32 & 64-bit

## Optical see-through digital eyewear

The Vuforia SDK supports a range of optical see-through digital eyewear devices. The table below lists supported devices, along with their required operating system (OS) versions. The table also includes supported OS and Unity versions for developing applications with Vuforia for these devices.

| **Device**|  | **Device OS** |  | **Development OS** |  | **Unity Version** |  |
|:---|:---|:---|:---|:---|:---|:---|:---| 
| HoloLens| Current version | Android (1)(2) | 4.0.3+ | Windows (3) | 7+ | Windows (3) | 2017.2+ |
| ODG| R7+ | Windows (1) | 10 UWP | OS X | 10.11+ | OS X   | 2017.2 |
| Epson| BT-200 |  |  |  |  |  |  |

1. 32-bit only
2. 4.0.3 Native only support for Epson BT-200
3. 32 & 64-bit


## Vuforia tools

Some Vuforia tools are only supported on specific hardware. The table below lists these tools, along with their supported devices and required OS versions. 

| **App**| **Devices** | **OS Version** |
|:---|:---|:---| 
| Calibration Assistant| Moverio BT-200<br/>ODG R-7 | Android 4.0.3+ |
| Object Scanner| Samsung Galaxy S8+<br/>Samsung Galaxy S8 <br/>Samsung Galaxy S7<br/>Samsung Galaxy S6 | Latest supported OS on the device |

For more detailed information on these tools, see the [Vuforia Calibration Assistant](https://library.vuforia.com/articles/Training/Vuforia-Calibration-App) and [Object Scanner](https://library.vuforia.com/articles/Training/Vuforia-Object-Scanner-Users-Guide) pages in the [Vuforia developer library](https://library.vuforia.com/).

### Virtual Reality SDK integration support

Below is a list of VR SDKs fully integrated into the Unity Editor, along with the release version of the Editor where they were first integrated.

| __VR SDK__| __Versions__ |
|:---|:---| 
| Google VR SDK| Unity  2017.2 |
| Cardboard Android SDK| Unity 2017.2 |
| Windows Mixed Reality (HoloLens only)| Unity 2017.2 |

### Graphics API support

The table below lists all the Graphics APIs supported by Vuforia when developing applications on supported operating systems.

| __Android__| __iOS__ | __Windows__ |
|:---|:---|:---| 
| OpenGL ES 2.0<br/>OpenGL ES 3.x| OpenGL ES 2.0<br/>OpenGL ES 3.x <br/>Metal (iOS 8+) | DirectX 11 on Windows 10 |

* For more information on using Vuforia with digital eyewear (such as the ODG R7+ and Epson BT-200), see Vuforia documentation on [Vuforia for digital eyewear](https://library.vuforia.com/content/vuforia-library/en/articles/Training/Vuforia-for-Digital-Eyewear.html)

* For more information on using Vuforia with HoloLens, see Vuforia documentation on [working with the Hololens sample in Unity](https://library.vuforia.com/content/vuforia-library/en/articles/Solution/Working-with-the-HoloLens-sample-in-Unity.html)

* For more information on using Vuforia with the Google VR SDK, see Vuforia documentation on [Developing for Google Cardboard](https://library.vuforia.com/content/vuforia-library/en/articles/Solution/Developing-for-Google-Cardboard.html)

---
* <span class="page-edit">2018-03-28 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Vuforia documentation updated for Unity XR API in 2017.3</span>
