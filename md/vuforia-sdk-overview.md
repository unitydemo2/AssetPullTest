# Vuforia

![](../uploads/Main/vuforia_logo.png)

Vuforia is a cross-platform Augmented Reality (AR) and Mixed Reality (MR) application development platform, with robust tracking and performance on a variety of hardware (including mobile devices and mixed reality Head Mounted Displays (HMD) such as the Microsoft HoloLens). Unity’s integration of Vuforia allows you to create vision apps and games for Android and iOS using a drag-and-drop authoring workflow. A [Vuforia AR+VR samples package](https://www.assetstore.unity3d.com/en/#!/content/101547) is available on the Unity Asset Store, with several useful examples demonstrating the most important features of the platform.

Vuforia supports many third-party devices (such as AR/MR glasses), and VR devices with back-facing cameras (such as the Gear VR). See the Vuforia page on [Devices](https://www.vuforia.com/Devices) for a full list of supported devices. See the [Vuforia API reference](https://library.vuforia.com/content/vuforia-library/en/reference/unity/index.html) for more information about classes, properties and functions used in the SDK.

You can use any device with a camera to test AR/MR games and applications built in Unity with Vuforia.

## Important concepts

Before learning more about Vuforia and its supported features, you need to understand a number of important concepts. Among these concepts are forms of tracking and marker types commonly used in Vuforia applications.

### Marker-based tracking 

In AR or MR, markers are images or objects registered with the application which act as information triggers in your application. When your device’s camera recognizes these markers in the real world (while running an AR or MR application), this triggers the display of virtual content over the world position of the marker in the camera view. Marker-based tracking can use a variety of different marker types, including QR codes, physical reflective markers, Image Targets and 2D tags. The simplest and most common type of marker in game applications is an Image Target.

![Common Image Target types](../uploads/Main/target_types.png)


#### Image Targets

Image Targets are a specific type of marker used in Marker-based tracking. They are images you manually register with the application, and act as triggers that display virtual content. For Image Targets, use images containing distinct shapes with complex outlines. This makes it easier for image recognition and tracking algorithms to recognize them. 

### Markerless tracking

Applications using Markerless tracking are more commonly location-based or position-based Augmented or Mixed Reality. This form of tracking relies on technologies such as GPS, accelerometer, gyroscope and more complex image processing algorithms, to place virtual objects or information in the environment. The VR hardware and software then treats these objects as if they are anchored or connected to specific real-world locations or objects.

---
* <span class="page-edit">2018-03-28 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Vuforia documentation updated for Unity XR API in 2017.3</span>