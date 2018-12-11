# Working with Google VR for Unity

This section covers important considerations you should keep in mind when creating Google VR content in Unity. 

When working with Google VR for Unity, note the following:

* Use the device names daydream and cardboard to load a specific device when you want to enable XR for that device. To do this, call [XRSettings.LoadDeviceByName](ScriptRef:XR.XRSettings.LoadDeviceByName.html) and pass in the string name of the device.

* Integration of Daydream for Unity takes over the Unity activity’s view hierarchy. This means that any modification made to the view hierarchy before initializing Daydream for Unity, is removed while in XR mode.

## Daydream and Cardboard

__Daydream__ and __Cardboard__ have separate entries in the __Virtual Reality SDKs__ list (__Edit__ > __Project Settings__, then select the __Player__ category, and navigate to the __XR Settings__ section). Unity reads the list from top to bottom until it finds a device configuration that works. 

Removing or reordering the SDKs in the list affects the functionality of your final built application, as detailed below:

* If both __Daydream__ and __Cardboard__ are in the __Virtual Reality SDKs__ list, asynchronous reprojection is enabled if running on hardware that supports it. __Sustained Performance Mode__ is enabled if running on hardware that supports it, and if you have enabled it in the __Player__ settings (see previous section on targeting Daydream). The app appears in all Google Play Stores.

* If __Cardboard__ is above __Daydream__ in the __Virtual Reality SDKs__ list, the application might not run in Daydream mode, even on Daydream hardware.

* If __Daydream__ is the only item in the __Virtual Reality SDKs__ list, Unity adds XR Android manifest entries so that the app appears in the XR-specific Google Play store. Daydream requires asynchronous reprojection, so all devices which support Daydream also support asynchronous reprojection.

* If __Cardboard__ is the only item in the __Virtual Reality SDKs__ list, the app does not appear in the Google VR Play store. Asynchronous reprojection and __Sustained Performance Mode__ are disabled, even on capable hardware.

* If you plan to support GearVR as well as Daydream and Cardboard, place __Oculus__ at the top of the list. Phones that support GearVR run through the GearVR SDK, and phones that don’t support it fall back to __Daydream__ or __Cardboard__.

* If you add __None__ as the first device in the list, Unity starts as a normal application and you can toggle XR through script. See API documentation on [XRSettings.enabled](ScriptRef:XR.XRSettings-enabled.html) and [XRSettings.LoadDeviceByName](ScriptRef:XR.XRSettings.LoadDeviceByName.html) for more information.

## __Cardboard for iOS__

Google distributes the __Cardboard Native Development Kit__ (NDK) for iOS through the [Cocoapods library management system](https://cocoapods.org). The Unity integration of Google VR uses a specific version of the __Cardboard NDK__ from the Cocoapods manager and this NDK is also used to create your XCode project.

This means the resulting project is generated differently from a standard Unity project. Cocoapods creates a wrapping __XCode__ workspace containing the Unity project as well as a project for the __Cardboard__ __NDK__ library and its dependencies. Always make sure that you open and/or use the workspace and not just the project to avoid linker errors due to the missing libraries in Cocoapods.

## __Magic Window mode__

During development, you may want to have a __non-stereoscopic view__ which still utilizes headtracking. This is useful if you require the user to view a 2D image in __XR__, or to provide 2D previews of your __XR application__. This can also be useful for promotional materials. To achieve this, you can access __head tracking data__ when the [XRSettings.enabled](ScriptRef:XR.XRSettings-enabled.html) property is false and the [XRSettings.loadedDeviceName](ScriptRef:XR.XRSettings-loadedDeviceName.html) is set to __daydream__ or __cardboard__.

The following example C# code rotates the main camera in a scene by using XR head tracking while disabling stereoscopic view using __XR Settings__:

```
UnityEngine.XR.XRSettings.enabled = false;
Camera.main.GetComponent<Transform>().localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(XRNode.CenterEye);
```

For more information on the above, see the API documentation on [XRSettings.LoadDeviceByName](ScriptRef:XR.XRSettings.LoadDeviceByName.html).

## __Hardware volume controls__

The Daydream SDK for Unity prevents the native Operating System (OS) from accessing the device’s volume controls. This prevents the OS from displaying the volume user interface (UI) when in XR mode. To access the device’s volume controls manually, extend the standard __UnityPlayerActivity __(the primary Java class for the Unity Player on Android) and override the onKeyDown and onKeyLongPress key event functions yourself.

For more information on this process, see the Unity documentation on [extending the UnityPlayerActivity class](AndroidUnityPlayerActivity) through Java.

__Note:__ Unity does not block the volume controls on __Daydream__ controller, so if you only intend to use the controller in your game you may decide not to extend the __UnityPlayerActivity__ at all.

## __Overriding Daydream Android libraries__

The __Daydream SDK__ for Unity provides two libraries to support development for Daydream devices:

* Daydream native library: *gvr.aar*

* [Google Protobuf](https://developers.google.com/protocol-buffers/) Nano Java library: *libprotobuf-java-nano.jar*

You can replace either of these libraries by placing different versions of the library files in the **_Assets/Plugins/Android_** folder in your project. Library file names must match exactly in order for them to be correctly overridden.

## __Stereo Rendering methods__

Multi Pass rendering is supported on all Google VR platforms. [Single Pass rendering](Android-SinglePassStereoRendering) is supported only by Daydream on platforms that support driver level instancing.


