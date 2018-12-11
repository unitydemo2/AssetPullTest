How to do Stereoscopic Rendering
================================

Stereoscopic rendering for DirectX11.1's stereoscopic 3d support.
----------------------------------------------------------------

The minimum requirements are:

* Windows 10
* Graphic card that supports DirectX 11.
* The graphics card driver needs to be set up with stereo support, and you need to use a dual DVI or DisplayPort cable; a single DVI is not enough. 

The Stereoscopic checkbox in the **Player** settings is strictly for DirectX 11.1's stereoscopic 3d support. It doesn't currently use AMD's quad buffer extension. Make sure that [this sample](https://code.msdn.microsoft.com/windowsapps/Direct3D-111-Simple-Stereo-9b2b61aa) works on your machine. Stereo support works both in fullscreen and windowed mode.

When you launch the game, hold shift to bring up the resolution dialog. There will be a checkbox in the resolution dialog for Stereo3D if a capable display is detected. Regarding the API, there are a few options on Camera: stereoEnabled, stereoSeparation, stereoConvergence. Use these to tweak the effect. You will need only one camera in the scene, the rendering of the two eyes is handled by those parameters.

Note that this checkbox is not for VR headsets.
​     

1. Check your setup using [this sample](https://code.msdn.microsoft.com/windowsapps/Direct3D-111-Simple-Stereo-9b2b61aa).
2. Check the Stereoscopic Rendering and Use Direct3D 11 checkboxes in the **Player** settings.
3. Publish it as 32-bit and 64-bit applications.
4. Try it with single camera and double cameras.
5. Hold Shift when launching the application to see Stereo 3D checkbox in the resolution dialog. The resolution dialog might be suppressed or always enabled depending on the Project's **Player** settings. 

Note: Currently, setting Unity to render in linear color space breaks stereoscopic rendering.  This appears to be a Direct3D limitation. It also appears that the ``camera.stereoconvergence`` param has no effect at all if you have some realtime shadows enabled (in forward rendering). In Deferred Lighting, you will get some shadows, but insconsistent between left & right eye.
