# PlayStation VR post-reprojection

Sometimes you have graphic elements in your VR game that are totally fixed to the camera. A good example is a reticle or crosshair in a shooter game, which you might want to be always fixed exactly at the center of the screen. If you render those elements to the eye textures, the PlayStation VR reprojection causes an undesired judder effect. Instead, you need to use a special rendering overlay in Unity called post-reprojection. 

After reprojection, post-reprojection creates additional render textures that combine with the main eye textures. Unity does this with standard [alpha blending](https://en.wikipedia.org/wiki/Alpha_compositing), using the post-reprojection textures as sources (with color in the RGB channels and blending factor in the alpha channel) and the eye textures as the destination.

To use post-reprojection in your project:

1. Set `PlayStationVRSettings.postReprojectionType` to the desired type to enable post-reprojection, or `None` to disable it. You need to set it before loading the XR device with [UnityEngine.XR.XRSettings.LoadDeviceByName](ScriptRef:XR.XRSettings.LoadDeviceByName.html).

2. Call `PlayStationVR.GetCurrentFramePostReprojectionEyeTexture` every frame to get the corresponding post-reprojection render texture for the frame, and draw to it.

Unity allocates the required additional post-reprojection render textures when the XR device loads. The textures remain allocated until the device shuts down. Internally, Unity allocates several render textures for buffering. This is why you need to call `GetCurrentFramePostReprojectionEyeTexture` frame-by-frame, so that you get the correct buffered texture for each frame. 

Unity does not automatically clear post-reprojection textures. If you stop drawing to the textures frame-by-frame, the last content drawn to the textures remains on screen until you update it again. However, you can use this to your advantage: for example, if you have static content that doesn’t need to be updated every frame, you can draw to the post-reprojection textures only for enough frames to update all buffered textures, and skip the updates from then on.

You can’t enable or disable post-reprojection after the XR device has loaded with [UnityEngine.XR.XRSettings.LoadDeviceByName](ScriptRef:XR.XRSettings.LoadDeviceByName.html). If you need to do so, then shut down and re-load the device.

Likewise, there is no way to temporarily pause or stop the post-reprojection alpha blending operation that happens every frame. If you have a specific section in your game that does not need post-reprojection, the only way to hide the post-reprojection overlay is to make the post-reprojection render textures fully transparent (for example, by copying a Texture.blackTexture to them using a Graphics.Blit), so that it doesn’t affect the alpha blending. Note that when you do this, your game still pays the GPU cost of the alpha blend every frame.

## Post-reprojection types

You can set the `PlayStationVRSettings.postReprojectionType` property to one of two types of post-reprojection: `Shared` and `PerEye`. The effect of each of these types depends on which [Stereo Rendering Method](https://blogs.unity3d.com/2017/11/21/how-to-maximize-ar-and-vr-performance-with-advanced-stereo-rendering/) you use (__Single-Pass__ or __Multi-Pass__).

### Shared

Use `Shared` to blend the same post-reprojection image on both eyes. Unity creates a single texture, and blends it with each eye. Call `PlayStationVR.GetCurrentFramePostReprojectionEyeTexture` with `LeftEye` as the parameter to share this texture. __Single-Pass__ and __Single-Pass Instanced__ rendering always use a shared texture, regardless of the type you set in `PlayStationVRSettings.postReprojectionType`. This type also works with __Multi-Pass__ rendering.

### PerEye

Use `PerEye` to use an individual post-reprojection texture for each eye. For this, your script code needs to get multiple textures and draw to them individually. To get those textures, call `PlayStationVR.GetCurrentFramePostReprojectionEyeTexture` twice (one call for each eye). This is more resource-heavy than `Shared`, and only works with __Multi-Pass__ rendering.

## Example code

The following are minimal example scripts for drawing to the post-reprojection textures. These code samples work with a multi-camera Scene set-up.

```
using UnityEngine;
using UnityEngine.PS4.VR;
public class VRPostReprojection : MonoBehaviour
{
    private int currentEye = 0;
    void Update()
    {
        // Reset which eye we're adjusting at the start of every frame
        currentEye = 0;
    }
    void OnPostRender()
    {
        UnityEngine.XR.XRNode eye = (currentEye == 0) ? UnityEngine.XR.XRNode.LeftEye : UnityEngine.XR.XRNode.RightEye;
        RenderTexture postReprojectionTexture = PlayStationVR.GetCurrentFramePostReprojectionEyeTexture(eye);
        if (RenderTexture.active.antiAliasing > 1)
        {
            // The same scale value needs to be assigned to UnityEngine.XR.XRSettings.eyeTextureResolutionScale and 
            // PlayStationVRSettings.postReprojectionRenderScale for this to work.
            RenderTexture.active.ResolveAntiAliasedSurface(postReprojectionTexture);
        }
        else
        {
            Graphics.Blit(RenderTexture.active, postReprojectionTexture);
        }
        currentEye++;
    }
}
```

Alternatively, if you want to keep different scale values for `UnityEngine.XR.XRSettings.eyeTextureResolutionScale` and `PlayStationVRSettings.postReprojectionRenderScale`, you can try a script similar to the following:

```
using UnityEngine;
using UnityEngine.PS4.VR;
public class VRPostReprojection : MonoBehaviour
{
    private int currentEye = 0;
    void Update()
    {
        // Reset which eye we're adjusting at the start of every frame
        currentEye = 0;
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        UnityEngine.XR.XRNode eye = (currentEye == 0) ? UnityEngine.XR.XRNode.LeftEye : UnityEngine.XR.XRNode.RightEye;
        RenderTexture postReprojectionTexture = PlayStationVR.GetCurrentFramePostReprojectionEyeTexture(eye);
        Graphics.Blit(source, postReprojectionTexture);
        currentEye++;
        // We don't care about filling out ‘destination’ as we are not going to
        // use the results for anything. 
        Graphics.SetRenderTarget(destination);
    }
}
```

Add either of the above code snippets to a VR camera that is set up to render the content of the post-reprojection textures. That way, [RenderTexture.active](ScriptRef:RenderTexture-active.html) contains the required content, and the script copies it to the textures (using `Resolve` or `Blit`). In addition, make sure the Scene has a normal VR camera that draws the Scene.

The code samples work for both Multi-Pass and Single-Pass rendering:

* With __Multi-Pass__ rendering, the script calls [OnPostRender](ScriptRef:MonoBehaviour.OnPostRender.html) twice per frame (once for each eye), first for the left eye and then for the right one. The code draws to the corresponding post-reprojection texture each time. You must set `PlayStationVRSettings.postReprojectionType` to `PerEye` for this code to work.

* With __Single-Pass__ rendering, the script calls [OnPostRender](ScriptRef:MonoBehaviour.OnPostRender.html) once per frame, because it shares a single post-reprojection texture between both eyes. The post-reprojection camera in the Scene renders to a single target texture for both eyes (like any VR camera in Single-Pass), meaning you can copy it to the post-reprojection texture.

These code examples are only two of many possible approaches for rendering to the post-reprojection textures. You can find a complete example of post-reprojection usage in our [PlayStation VR Unity Example Project (Devnet)](https://ps4.siedev.net/forums/thread/118216/). It uses the same multi-camera approach described above.

__Note__: when using [Graphics.Blit](ScriptRef:Graphics.Blit.html) for __Single-Pass Instanced__ rendering, the active render texture ([RenderTexture.active](ScriptRef:RenderTexture-active.html)) is actually a render target array, which requires different code to copy the image. The above example code doesn’t support this rendering method; see the [PlayStation VR Unity Example Project (Devnet)](https://ps4.siedev.net/forums/thread/118216/) for a complete example.

## Troubleshooting

* Use `PlayStationVRSettings.postReprojectionAntiAliasing` and `PlayStationVRSettings.postReprojectionRenderScale` to set up the properties of the post-reprojection render textures. You can get better performance or less memory usage with these properties.

* You can use post-reprojection to prevent the "Hall-Of-Mirrors" effect, where artifacts appear at the edges of the display during Scene loading, due to reprojection with low frame rates. You need to set a fully opaque image (set alpha to 1) in the post-reprojection render textures, so that it fully covers the eye textures when compositing.

* Use the Razor GPU profiling tool to make sure everything is working as expected. In particular, look at the Render Targets view and confirm that all of them make sense.

---

* <span class="page-edit"> 2018-03-13  <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">New functionality in [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>
