# Animation

This is the **Legacy** Animation component, which was used on GameObjects for animation purposes prior to the introduction of Unity's current animation system.

This component is retained in Unity for backwards-compatibility only. For new projects, please use the [Animator component](class-Animator).

![The Animation Inspector](../uploads/Main/AnimationInspector35.png) 


## Properties

|**_Property:_** ||**_Function:_** |
|:---|:---|:---|
|__Animation__ ||The default animation to play when __Play Automatically__ is enabled. |
|__Animations__ ||A list of animations that you can access from scripts. |
|__Play Automatically__ ||Enable this option to play animation automatically when the game starts. |
|__Animate Physics__ ||Enable this option to have the animation interact with Physics. |
|__Culling Type__||Determine when not to play the animation.|
||__Always Animate__|Always animate.|
||__Based on Renderers__|Cull based on the default animation pose.|
||__Based on Clip Bounds__|Cull based on clip bounds (calculated during import). The animation does not be play when the clip bounds are out of view.|
||__Based on User Bounds__|Cull based on bounds defined by the user. The animation does not be play when the user-defined bounds are out of view.|

See the [Animation Window Guide](AnimationEditorGuide) for more information on how to create animations inside Unity. 
See [Model import workflows](ImportingModelFiles) page on how to import animated characters.

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>
