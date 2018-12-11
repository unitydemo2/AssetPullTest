# Camera

__Cameras__ are the devices that capture and display the world to the player. By customizing and manipulating cameras, you can make the presentation of your game truly unique. You can have an unlimited number of cameras in a scene. They can be set to render in any order, at any place on the screen, or only certain parts of the screen.

![](../uploads/Main/InspectorCamera35.png) 

## Properties

|**_Property:_** |**_Function:_** |
|:---|:---|
|__Clear Flags__ |Determines which parts of the screen will be cleared. This is handy when using multiple Cameras to draw different game elements. |
|__Background__ |The color applied to the remaining screen after all elements in view have been drawn and there is no skybox. |
|__Culling Mask__ |Includes or omits layers of objects to be rendered by the Camera. Assigns layers to your objects in the Inspector. |
|__Projection__ |Toggles the camera's capability to simulate perspective. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Perspective_ |Camera will render objects with perspective intact. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Orthographic_ |Camera will render objects uniformly, with no sense of perspective. **NOTE:** Deferred rendering is not supported in Orthographic mode. Forward rendering is always used. |
|__Size__ (when Orthographic is selected) |The viewport size of the Camera when set to Orthographic. |
|__Field of view__ (when Perspective is selected) |The width of the Camera's view angle, measured in degrees along the local Y axis. |
|__Physical Camera__ |Tick this box to enable the [Physical Camera](PhysicalCameras) properties for this camera. <br/><br/> When the Physical Camera properties are enabled, Unity calculates the **Field of View** using the properties that simulate real-world camera attributes: **Focal Length**, **Sensor Size**, and **Lens Shift**. <br/><br/>Physical Camera properties are not visible in the Inspector until you tick this box.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Focal Length_ |Set the distance, in millimeters, between the camera sensor and the camera lens.<br/><br/>Lower values result in a wider **Field of View**, and vice versa. <br/><br/>When you change this value, Unity automatically updates the **Field of View** property accordingly.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Sensor Type_ |Specify the real-world camera format you want the camera to simulate. Choose the desired format from the list. <br/><br/>When you choose a camera format, Unity sets the the **Sensor Size > X** and **Y** properties to the correct values automatically. <br/><br/>If you change the **Sensor Size** values manually, Unity automatically sets this property to **Custom**.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Sensor Size_ |Set the size, in millimeters, of the camera sensor. <br/><br/>Unity sets the **X** and **Y** values automatically when you choose the **Sensor Type**. You can enter custom values if needed.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_X_ |The width of the sensor. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Y_ |The height of the sensor. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Lens Shift_ |Shift the lens horizontally or vertically from center. Values are multiples of the sensor size; for example, a shift of 0.5 along the X axis offsets the sensor by half its horizontal size. <br/><br/>You can use lens shifts to correct distortion that occurs when the camera is at an angle to the subject (for example, converging parallel lines). <br/><br/>Shift the lens along either axis to make the camera frustum [oblique](ObliqueFrustum). |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_X_ |The horizontal sensor offset. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Y_ |The vertical sensor offset. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Gate Fit_ |Options for changing the size of the **resolution gate** (size/aspect ratio of the game view) relative to the **film gate** (size/aspect ratio of the Physical Camera sensor). <br/><br/>For further information about resolution gate and film gate, see documentation on [Physical Cameras](PhysicalCameras).|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Vertical_ |Fits the resolution gate to the height of the film gate. <br/><br/>If the sensor aspect ratio is larger than the game view aspect ratio, Unity crops the rendered image at the sides. <br/><br/>If the sensor aspect ratio is smaller than the game view aspect ratio, Unity overscans the rendered image at the sides. <br/><br/>When you choose this setting, changing the sensor width (**Sensor Size > X property**) has no effect on the rendered image.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Horizontal_ |Fits the resolution gate to the width of the film gate. <br/><br/>If the sensor aspect ratio is larger than the game view aspect ratio, Unity overscans the rendered image on the top and bottom. <br/><br/>If the sensor aspect ratio is smaller than the game view aspect ratio, Unity crops the rendered image on the top and bottom. <br/><br/>When you choose this setting, changing the sensor height (**Sensor Size > Y** property) has no effect on the rendered image.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Fill_ |Fits the resolution gate to either the width or height of the film gate, whichever is smaller. This crops the rendered image.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Overscan_ |Fits the resolution gate to either the width or height of the film gate, whichever is larger. This overscans the rendered image.|
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_None_ |Ignores the resolution gate and uses the film gate only. This stretches the rendered image to fit the game view aspect ratio.|
|__Clipping Planes__ |Distances from the camera to start and stop rendering. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Near_ |The closest point relative to the camera that drawing will occur. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Far_ |The furthest point relative to the camera that drawing will occur. |
|__Viewport Rect__ |Four values that indicate where on the screen this camera view will be drawn. Measured in Viewport Coordinates (values 0-1). |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_X_ |The beginning horizontal position that the camera view will be drawn. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Y_ |The beginning vertical position that the camera view will be drawn. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_W_ (Width) |Width of the camera output on the screen. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_H_ (Height) |Height of the camera output on the screen. |
|__Depth__ |The camera's position in the draw order. Cameras with a larger value will be drawn on top of cameras with a smaller value. |
|__Rendering Path__ |Options for defining what rendering methods will be used by the camera. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Use Player Settings_ |This camera will use whichever Rendering Path is set in the Player Settings. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Vertex Lit_ |All objects rendered by this camera will be rendered as Vertex-Lit objects. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Forward_ |All objects will be rendered with one pass per material. |
|&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;_Deferred Lighting_ |All objects will be drawn once without lighting, then lighting of all objects will be rendered together at the end of the render queue. **NOTE:** *If the camera's projection mode is set to Orthographic, this value is overridden, and the camera will always use Forward rendering.* |
|__Target Texture__ |Reference to a [Render Texture](class-RenderTexture) that will contain the output of the Camera view. Setting this reference will disable this Camera's capability to render to the screen. |
|__Occlusion Culling__|Enables High Dynamic Range rendering for this camera. See [Occlusion Culling](OcclusionCulling) for details|
|__Allow HDR__|Enables High Dynamic Range rendering for this camera. See [High Dynamic Range Rendering](HDR) for details. |
|__Allow MSAA__|Enables multi sample antialiasing for this camera.|
|__Allow Dynamic Resolution__|Enables Dynamic Resolution rendering for this camera. See [Dynamic Resolution](DynamicResolution) for details. |
|__Target Display__|Defines which external device to render to.  Between 1 and 8.|

##Details


Cameras are essential for displaying your game to the player. They can be customized, scripted, or parented to achieve just about any kind of effect imaginable. For a puzzle game, you might keep the Camera static for a full view of the puzzle. For a first-person shooter, you would parent the Camera to the player character, and place it at the character's eye level. For a racing game, you'd probably have the Camera follow your player's vehicle.

You can create multiple Cameras and assign each one to a different __Depth__. Cameras are drawn from low __Depth__ to high __Depth__. In other words, a Camera with a __Depth__ of 2 will be drawn on top of a Camera with a depth of 1. You can adjust the values of the __Normalized View Port Rectangle__ property to resize and position the Camera's view onscreen. This can create multiple mini-views like missile cams, map views, rear-view mirrors, etc.

###Render path
Unity supports different rendering paths. You should choose which one you use depending on your game content and target platform / hardware. Different rendering paths have different features and performance characteristics that mostly affect lights and shadows. 
The rendering path used by your Project is chosen in the __Player__ settings. Additionally, you can override it for each Camera.

For more information on rendering paths, check the [rendering paths](RenderingPaths) page.


###Clear Flags

Each Camera stores color and depth information when it renders its view. The portions of the screen that are not drawn in are empty, and will display the skybox by default. When you are using multiple Cameras, each one stores its own color and depth information in buffers, accumulating more data as each Camera renders. As any particular Camera in your scene renders its view, you can set the __Clear Flags__ to clear different collections of the buffer information. To do this, choose one of the following four options:


####Skybox

This is the default setting. Any empty portions of the screen will display the current Camera's skybox. If the current Camera has no skybox set, it will default to the skybox chosen in the [Lighting Window](GlobalIllumination) (menu: __Window__ &gt; __Rendering__ &gt; __Lighting Settings__). It will then fall back to the __Background Color__. Alternatively a [Skybox component](class-Skybox) can be added to the camera. If you want to create a new Skybox, [you can use this guide](HOWTO-UseSkybox).


####Solid color

Any empty portions of the screen will display the current Camera's __Background Color__.


####Depth only

If you want to draw a player's gun without letting it get clipped inside the environment,  set one Camera at __Depth__ 0 to draw the environment, and another Camera at __Depth__ 1 to draw the weapon alone. Set the weapon Camera's __Clear Flags__ to __depth only__. This will keep the graphical display of the environment on the screen, but discard all information about where each object exists in 3-D space. When the gun is drawn, the opaque parts will completely cover anything drawn, regardless of how close the gun is to the wall.


![The gun is drawn last, after clearing the depth buffer of the cameras before it](../uploads/Main/Camera-ClearFlags.jpg) 


####Don't clear

This mode does not clear either the color or the depth buffer. The result is that each frame is drawn over the next, resulting in a smear-looking effect. This isn't typically used in games, and would more likely be used with a custom shader.

Note that on some GPUs (mostly mobile GPUs), not clearing the screen might result in the contents of it being undefined in the next frame. On some systems, the screen may contain the previous frame image, a solid black screen, or random colored pixels.


###Clip Planes

The __Near__ and __Far Clip Plane__ properties determine where the Camera's view begins and ends. The planes are laid out perpendicular to the Camera's direction and are measured from its position. The __Near plane__ is the closest location that will be rendered, and the __Far plane__ is the furthest.

The clipping planes also determine how depth buffer precision is distributed over the scene. In general, to get better precision you should move the __Near plane__ as far as possible.

Note that the near and far clip planes together with the planes defined by the field of view of the camera describe what is popularly known as the camera _frustum_. Unity ensures that when rendering your objects those which are completely outside of this frustum are not displayed. This is called Frustum Culling. Frustum Culling happens irrespective of whether you use Occlusion Culling in your game.

For performance reasons, you might want to cull small objects earlier. For example, small rocks and debris could be made invisible at much smaller distance than large buildings. To do that, put small objects into a [separate layer](Layers) and set up per-layer cull distances using [Camera.layerCullDistances](ScriptRef:Camera-layerCullDistances.html) script function.

###Culling Mask

The __Culling Mask__ is used for selectively rendering groups of objects using Layers. More information on using layers can be found [here](Layers).


###Normalized Viewport Rectangles

__Normalized Viewport Rectangle__ is specifically for defining a certain portion of the screen that the current camera view will be drawn upon. You can put a map view in the lower-right hand corner of the screen, or a missile-tip view in the upper-left corner. With a bit of design work, you can use __Viewport Rectangle__ to create some unique behaviors.

It's easy to create a two-player split screen effect using __Normalized Viewport Rectangle__. After you have created your two cameras, change both camera's H values to be 0.5 then set player one's Y value to 0.5, and player two's Y value to 0. This will make player one's camera display from halfway up the screen to the top, and player two's camera start at the bottom and stop halfway up the screen.


![Two-player display created with the Normalized Viewport Rectangle property](../uploads/Main/Camera-Viewport.jpg) 


###Orthographic

Marking a Camera as __Orthographic__ removes all perspective from the Camera's view. This is mostly useful for making isometric or 2D games.

Note that fog is rendered uniformly in orthographic camera mode and may therefore not appear as expected. This is because the Z coordinate of the post-perspective space is used for the fog "depth". This is not strictly accurate for an orthographic camera but it is used for its performance benefits during rendering.


![Perspective camera.](../uploads/Main/Camera-Non-Ortho-FPS.jpg) 


![Orthographic camera. Objects do not get smaller with distance here!](../uploads/Main/Camera-Ortho-FPS.jpg) 

###Render Texture

This will place the camera's view onto a [Texture](class-RenderTexture) that can then be applied to another object. This makes it easy to create sports arena video monitors, surveillance cameras, reflections etc.


![A Render Texture used to create a live arena-cam](../uploads/Main/Camera-RenderTexture.jpg) 


###Target display
A camera has up to 8 target display settings. The camera can be controlled to render to one of up to 8 monitors.  This is supported only on PC, Mac and Linux.  In Game View the chosen display in the Camera Inspector will be shown.



##Hints



* Cameras can be instantiated, parented, and scripted just like any other GameObject.
* To increase the sense of speed in a racing game, use a high __Field of View__.
* Cameras can be used in physics simulation if you add a __Rigidbody__ Component.
* There is no limit to the number of Cameras you can have in your scenes.
* Orthographic cameras are great for making 3D user interfaces.
* If you are experiencing depth artifacts (surfaces close to each other flickering), try setting __Near Plane__ to as large as possible.
* Cameras cannot render to the Game Screen and a Render Texture at the same time, only one or the other.
* There's an option of rendering a Camera's view to a texture, called Render-to-Texture, for even more interesting effects.
* Unity comes with pre-installed Camera scripts, found in __Components &gt; Camera Control__. Experiment with them to get a taste of what's possible.
* 
----
* <span class="page-edit">2018-10-05 <!-- include IncludeTextAmendPageSomeEdit --></span>
* <span class="page-history">Physical Camera options added in Unity 2018.2</span>
* <span class="page-history">Gate Fit options added in Unity 2018.3</span>
