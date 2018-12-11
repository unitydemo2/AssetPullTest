# Performance and optimization

This page contains some tips to help you obtain the best performance from [Unity's animation system](AnimationOverview), covering character setup, the animation system and run-time optimizations.


## Character setup
### Number of bones
In some cases you need to create characters with a large number of bones: for example, when you want a lot of customizable attachments. These extra bones increase the size of the build, and may have a relative processing cost for each additional bone. For example, 15 additional bones on a rig that already has 30 bones takes 50% longer to solve in __Generic__ mode. Note that you can have additional bones for [Generic](GenericAnimations) and [Humanoid](ConfiguringtheAvatar) types. When you have no animations playing using the additional bones, the processing cost should be negligible. This cost is even lower if their attachments are non-existent or hidden.

### Multiple skinned Meshes
Combine skinned meshes whenever possible. Splitting a character into two [Skinned Mesh Renderers](class-SkinnedMeshRenderer) reduces performance. It's better if your character has just one Material, but there are some cases when you might require more than one.


## Animation system
### Controllers
The [Animator](class-Animator) doesn't spend time processing when a [Controller](class-AnimatorController) is not set to it.

### Simple animation
Playing a single [Animation Clip](class-AnimationClip) with no blending can make Unity slower than the [legacy animation system](Animations). The old system is very direct, sampling the curve and directly writing into the transform. Unity's current animation system has temporary buffers it uses for blending, and there is additional copying of the sampled curve and other data. The current system layout is optimized for animation blending and more complex setups.

### Scale curves
Animating scale curves is more expensive than animating translation and rotation curves. To improve performance, avoid scale animations.  

**Note:** This does not apply to constant curves (curves that have the same value for the length of the [animation clip](AnimationClips)). Constant curves are optimized, and are less expensive that normal curves. Constant curves that have the same values as the default scene values do not write to the scene every frame.

### Layers
Most of the time Unity is evaluating animations, and keeps the overhead for [animation layers](AnimationLayers) and [Animation State Machines](AnimationStateMachines) to the minimum. The cost of adding another layer to the animator, synchronized or not, depends on what animations and blend trees are played by the layer. When the weight of the layer is zero, Unity skips the layer update.

### Humanoid vs. Generic animation types
These are tips to help you decide between these types:

* When importing Humanoid animation use an Avatar Mask (class-AvatarMask) to remove IK Goals or finger animation if you don't need them.
* When you use Generic, using root motion is more expensive than not using it. If your animations don't use root motion, make sure that you have not specified a root bone.


### Scene-level optimization
There are many optimizations that can be made, some useful tips include:

* Use hashes instead of strings to query the Animator.
* Implement a small AI Layer to control the Animator. You can make it provide simple callbacks for OnStateChange, OnTransitionBegin, and other events.
* Use State Tags to easily match your AI state machine to the Unity state machine.
* Use additional curves to simulate events.
* Use additional curves to mark up your animations; for example, in conjunction with [target matching](TargetMatching).



## Runtime Optimizations
### Visibility and updates
Always optimize animations by setting the animators's [Culling Mode](class-Animator) to __Based on Renderers__, and disable the [skinned mesh renderer's](class-SkinnedMeshRenderer) __Update When Offscreen__ property. This saves Unity from updating animations when the character is not visible.

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-edit"> 2017-05-16  <!-- include IncludeTextAmendPageNoEdit --></span><br/>
