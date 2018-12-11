# Google VR resources and troubleshooting

## Useful links

Below is a list of useful external links for further reading into Google VR development topics.

* [VR section on Google developer website](https://developers.google.com/vr/)

* [Cocoapods](http://cocoapods.org)

## Troubleshooting guide

This section provides a list of the most common problems you may encounter when developing with the Google VR SDK. The table below lists some common problems along with suggested solutions.

| __Problem__| __Suggestion__ |
|:---|:---| 
| I have a problem with GvrController/GvrViewer/GvrXXXX/Instant Preview. What do I do to resolve this?<br/>| These types are part of the Google VR SDK for Unity and are owned and supported by Google. While the general Unity community may be able to answer your questions, for any technical issues you should visit the [Google VR SDK for Unity](https://github.com/googlevr/gvr-unity-sdk) site on GitHUB.<br/> |
| When is the Daydream Keyboard going to be released?| The Daydream Keyboard for Google VR is a Google technology and will be released in some future version of the core Android system. Access and use of this technology is based solely on Google and the [Google VR SDK for Unity](https://github.com/googlevr/gvr-unity-sdk).<br/> |
| I am trying to build my Cardboard for iOS project, but Xcode is reporting linker errors.| Google distributes the Cardboard Native Development Kit (NDK) for iOS through the Cocoapods library management system. Unity is integrated with a specific version of that Cardboard NDK from the Cocoapods manager and uses the NDK to create your XCode project. The resulting project is generated differently from a standard Unity project. Cocoapods creates a wrapping XCode workspace containing the Unity project as well as a project for the Cardboard NDK library and its dependencies. Always make sure that you open and/or use the workspace and not just the project to avoid getting linker errors due to the missing libraries from Cocoapods. |



See the official Google VR developer website for more troubleshooting information for both [Cardboard](https://support.google.com/cardboard/answer/6295070?hl=en&ref_topic=6295055) and [Daydream](https://support.google.com/daydream/?hl=en-GB#topic=7184600).

---
* <span class="page-edit">2018-03-27 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Google VR documentation updated for Unity XR API in 2017.3</span>