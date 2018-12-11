#Customizing an iOS Splash Screen

If you use Unity Personal Edition to make your project, a default splash screen displays while your game loads. It is oriented according to the __Default Screen Orientation__ option in the [Player Settings](class-PlayerSettings). You cannot change this splash screen.

Unity Professional Edition users can change the splash screen. You can use any texture in the project as a splash screen. 

The size of the texture depends on the target device:

* 320x480 pixels for 1-3rd gen devices
* 1024x768 for iPad mini/iPad 1st/2nd gen
* 2048x1536 for iPad 3th/4th gen
* 640x960 for 4th gen iPhone / iPod devices 
* 640x1136 for 5th gen devices
* 750x1334 for 6th gen regular models
* 1242x2208 for iPhone Plus models
* 1125x2436 for iPhone X


The texture you supply is scaled to fit if necessary. 

You can set the splash screen textures using the [iOS Player Settings](class-PlayerSettings).

---

* <span class="page-edit">2018-06-14 <!-- include IncludeTextAmendPageSomeEdit --></span>