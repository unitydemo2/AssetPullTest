<!-- THE GLOSSARY ONLY APPLIES TO 2018.2 AND ABOVE -->

#Glossary

* [2D terms](#Section2D)
* [2D Physics terms](#Section2DPhysics)
* [AI terms](#SectionAI)
* [Analytics terms](#SectionAnalytics)
* [Animation terms](#SectionAnimation)
* [Assets terms](#SectionAssets)
* [Audio terms](#SectionAudio)
* [Core terms](#SectionCore)
* [Editor terms](#SectionEditor)
* [General terms](#SectionGeneral)
* [Graphics terms](#SectionGraphics)
* [Lighting terms](#SectionLighting)
* [Multiplayer terms](#SectionMultiplayer)
* [Physics terms](#SectionPhysics)
* [Platforms terms](#SectionPlatforms)
* [Scripting terms](#SectionScripting)
* [Services terms](#SectionServices)
* [Timeline terms](#SectionTimeline)
* [UI terms](#SectionUI)

<div class="Glossary" title="2D"><a name="Section2D"></a>
##2D terms

####2D Object*:
A 2D GameObject such as a tilemap or sprite. [More info](Overview2D)

####dimetric projection:
A form of parallel projection where the dimensions of a 3D object are projected onto a 2D plane, and only two of the three angles between the axes are equal to each other. This form of projection is commonly used in isometric video games to simulate three-dimensional depth. [More info](IsometricTilemap)

####isometric projection:
A form of parallel projection where the dimensions of a 3D object are projected onto a 2D plane, and the angles betwen all three axes are equal to each other. This form of projection is commonly used in isometric video games to simulate three-dimensional depth. [More info](IsometricTilemap)

####sprite atlas*:
A texture that is composed of several smaller textures. Also referred as a texture atlas, image sprite, sprite sheet or packed texture. [Sprite Atlas](SpriteAtlas)

</div>

<div class="Glossary" title="2D Physics"><a name="Section2DPhysics"></a>
##2D physics terms

####Body Type*:
Defines a fixed behavior for a 2D rigid body. Can be Dynamic (the body moves under simulation and is affected by forces like gravity), Kinematic (the body moves under simulation, but and isn't affected by forces like gravity) or Static (the body doesn't move under simulation). [More info](class-Rigidbody2D)

####Fixed Joint 2D*:
A 2D joint type which is completely constrained, allowing two objects to be held together. Implemented as a spring so some small motion may still occur. [More info](class-FixedJoint2D)

####Physics Material 2D*:
Use to adjust the friction and bounce that occurs between 2D physics objects when they collide [More info](class-PhysicsMaterial2D)

####Relative Joint 2D*:
A 2D joint that allows two game objects controlled by rigidbody physics to maintain in a position based on each other's location. Use this joint to keep two objects offset from each other, at a position and angle you decide [More info](class-RelativeJoint2D)


</div>

<div class="Glossary" title="AI"><a name="SectionAI"></a>
##AI terms

####NavMesh*:
A mesh that Unity generates to approximate the walkable areas and obstacles in your environment for path finding and AI-controlled navigation. [More info](nav-BuildingNavMesh)


</div>

<div class="Glossary" title="Analytics"><a name="SectionAnalytics"></a>
##Analytics terms

####Active Users:
Players who recently played your game. Unity Analytics defines an active player as someone who has played within the last 90 calendar days. [More info](UnityAnalyticsTerminology)

####Ad ARP*:
(Average Revenue Per User) Average Unity Ads revenue per player. [More info](UnityAnalyticsTerminology)

####Ad Revenue:
Total Unity Ads revenue. [More info](UnityAnalyticsTerminology)

####Ad Starts:
The number of video ads that started playing. [More info](UnityAnalyticsTerminology)

####Ads per DAU*:
The number of ads started per active player on a given day. [More info](UnityAnalyticsTerminology)

####Age 14 and Under:
By default, Unity does not breakout analytics data for players under the age of 14. See COPPA Compliance. [More info](UnityAnalyticsTerminology)

####All Spenders:
Players who have made any verified or unverified in-app purchases in their lifetime. [More info](UnityAnalyticsTerminology)

####Analytics*:
A data platform that provides analytics for your Unity game. [More info](UnityAnalytics)

####Analytics Events*:
Events dispatched to the Analytics Service by instances of your applications. Analytics events contain the data that is processed and aggregated to provide insights into player behavior. [More info](UnityAnalyticsCustomEvents)

####Application version:
Player segments based on application version or bundleid. [More info](UnityAnalyticsTerminology)

####ARPDAU *:
(Average Revenue Per Daily Active User) The average revenue per user who played on a given day. [More info](UnityAnalyticsTerminology)

####ARPPU*:
(Average Revenue Per Paying User) Average verified IAP revenue per user who completed a verified IAP transaction. [More info](UnityAnalyticsTerminology)

####Churn:
The rate at which users are leaving your game during a specified period. Your user churn is important in estimating the lifetime value of your users. Mathematically, churn is the complement of retention (in other words: Churn + Retention = 100%). [More info](UnityAnalyticsTerminology)

####Cohort:
A group of players with at least one similar characteristic. You can define and analyze different cohorts of your user base with segments. [More info](UnityAnalyticsTerminology)

####Conversion Rate:
The percentage of users who complete an action or sequence of actions.  [More info](UnityAnalyticsTerminology)

####COPPA*:
(Children's Online Privacy Protection Act) COPPA is a US law that applies to apps that collect personal information and are targeted to children under the age of 14.  [More info](UnityAnalyticsCOPPA)

####Core Events:
Core events are the basic events dispatched by the Unity Analytics code in your game. These events, and the analytics based on them, become available simply by turning on Unity Analytics for a Project. Core events include: app running, app start, and device info. [More info](UnityAnalyticsDashboardEventManager)

####CTR*:
(Click Through Rate) The percentage of players who click a link in an ad displayed in your game. [More info](UnityAnalyticsTerminology)

####Custom Events:
Custom events are freeform events that you can dispatch when an appropriate standard event is not available. Custom events can have any name and up to ten parameters. Use standard events in preference to custom events where possible. [More info](UnityAnalyticsCustomEvents)

####Data Explorer*:
A Unity Analytics Dashboard page that allows you to build, view and export reports on your Analytics metrics and events. You can also see how metrics and custom events change over time. [More info](UnityAnalyticsDataExplorer)

####DAU*:
(Daily Active Users) The number of different players who started a session on a given day. DAU includes both new and returning players. [More info](UnityAnalyticsTerminology)

####DAU per MAU*:
(DAU/MAU) The percentage of monthly active users who play on a given day. Also known as Sticky Factor in the analytics and game industries, this metric is often used as one estimate of player engagement. [More info](UnityAnalyticsTerminology)

####Day 1 Retention*:
The percentage of players who returned to your game one day after playing the first time. [More info](UnityAnalyticsTerminology)

####Day 30 Retention*:
The percentage of players who returned to your game thirty days after playing the first time. [More info](UnityAnalyticsTerminology)

####Day 7 Retention*:
The percentage of players who returned to your game seven days after playing the first time. [More info](UnityAnalyticsTerminology)

####Demographics:
Player segments based on reported demographics. [More info](UnityAnalyticsTerminology)

####Dolphins:
Players who have spent between $5 and $19.99. [More info](UnityAnalyticsTerminology)

####eCPM*:
(estimated Cost Per Mille) The estimated revenue for 1000 ad impressions for your app. See [What is ECPM](https://support.unity3d.com/hc/en-us/articles/115000564306-What-is-eCPM-). [More info](UnityAnalyticsTerminology)

####Engagement:
Engagement is a broad measure of how players enjoy, or are otherwise invested, in your game. Impossible to measure directly, the following metrics are frequently used to estimate engagement: Retention, DAU, MAU, DAU/MAU, number of sessions, and session length. [More info](UnityAnalyticsTerminology)

####F2P*:
(Free to Play) A business model that offers users free access to a fully functional game and a significant portion of app content. Monetization strategies for these titles generally include microtransactions that allow users to access premium features and virtual goods. [More info](UnityAnalyticsTerminology)

####Fill Rate:
The rate at which ads are available when you request one. [More info](UnityAnalyticsTerminology)

####Funnel:
In Analytics, a funnel is a linear sequence of standard or custom events that you expect a player to complete in order. [More info](UnityAnalyticsFunnels)

####Geography:
Player segments based on country. [More info](UnityAnalyticsTerminology)

####Heatmaps*:
Heatmaps are a spatial visualization of analytics data. [More info](UnityAnalyticsOverview.html#Heatmaps)

####IAP,In App Purchase*:
(In-app Purchase) Revenue from "micro-transactions" within a game. [More info](UnityIAP)

####Impressions:
The number of times ads are seen in your game. An impression is counted even if the ad is not completed. [More info](UnityAnalyticsTerminology)

####LTV*:
(Lifetime Value) The estimated value of an average player over their lifetime with your application or game. [More info](UnityAnalyticsTerminology)

####MAU*:
(Monthly Active Users) The number of players who started a session within the last 30 days. [More info](UnityAnalyticsTerminology)

####Minnow:
A player who has spent less than $5 in their lifetime. [More info](UnityAnalyticsTerminology)

####Never Monetized:
Players who have never spent real currency. [More info](UnityAnalyticsTerminology)

####New Users:
Users who played your game for the first time. [More info](UnityAnalyticsTerminology)

####Number of Unverified Transactions*:
The total number of IAP transactions, whether or not they have been verified. [More info](UnityAnalyticsTerminology)

####Number of Users:
The cumulative number of unique players over the last 90 days. Users who have not played in more than 90 days are removed from the count. [More info](UnityAnalyticsTerminology)

####Number of Verified Transactions:
IAP transactions that have been verified through the appropriate app store. IAP verification is currently supported by the Apple App Store and the Google Play Store. [More info](UnityAnalyticsTerminology)

####Percentage of Population:
Your player population as a percentage. Typically only useful when combined with a segment. Calculated as the percentage of the Number of Users metric who are members of a specified segment. [More info](UnityAnalyticsTerminology)

####Remote Settings:
Remote settings are game variables that you can set remotely on your Analytics Dashboard. See Remote Settings. [More info](UnityAnalyticsRemoteSettings)

####Segment:
Segments are subsets of your player base, split apart by key differentiators. Viewing metrics and events by segment can reveal differences in-game behavior between different groups. [More info](UnityAnalyticsTerminology)

####Session:
A single play or usage period. A new session is counted when a player launches your game or brings a suspended game to the foreground after 30 minutes of inactivity. [More info](UnityAnalyticsTerminology)

####Sessions per User:
The average number of sessions per person playing on a given day. Also known as Average Number of Sessions per DAU. [More info](UnityAnalyticsTerminology)

####Standard event*:
Standard events are application-specific events that you dispatch in response to important player actions or milestones. Standard events have standardized names and defined parameter lists. [More info](UnityAnalyticsCustomEvents)

####Sticky Factor*:
An estimate of how compelling a game is to its players. A high "sticky factor" means that players stick with an app over time. [More info](UnityAnalyticsTerminology)

####Total Daily Playing Time*:
The cumulative playing time of all people playing on a given day. [More info](UnityAnalyticsTerminology)

####Total Daily Playing Time per Active User*:
The average playing time of people playing on a given day. [More info](UnityAnalyticsTerminology)

####Total IAP Revenue*:
The total IAP revenue, including revenue from both verified and unverified transactions. [More info](UnityAnalyticsTerminology)

####Total Sessions Today:
The total number of sessions by all people playing on a given day. Also known as Total Sessions. [More info](UnityAnalyticsTerminology)

####Total Verified Revenue:
Revenue from Unity Ads and verified IAP transactions. IAP verification is currently supported by the Apple App Store and the Google Play Store. [More info](UnityAnalyticsTerminology)

####Unity Analytics*:
See Analytics [More info](UnityAnalytics)

####Unity IAP*:
See IAP [More info](UnityIAP)

####Universal Windows Platform*:
An IAP feature that supports Microsoft's In App Purchase simulator, which allows you to test IAP purchase flows on devices before publishing your application. [More info](UnityIAPUniversalWindows)

####Unknown Gender:
Players to whom you have assigned Gender.Unknown. (Players whose gender has not been reported at all are not included in this segment.) [More info](UnityAnalyticsTerminology)

####Unverified IAP Revenue*:
IAP revenue from sources that do not support verification and from transactions that failed verification. Transactions can fail verification because they are fraudulent or because of missing or malformed information.  [More info](UnityAnalyticsTerminology)

####Verified IAP Revenue*:
Revenue from verified IAP transactions. IAP verification is currently supported by the Apple App Store and the Google Play Store. [More info](UnityAnalyticsTerminology)

####Verified Paying Users:
Players who made verified IAP purchases. IAP verification is currently supported by the Apple App Store and the Google Play Store. [More info](UnityAnalyticsTerminology)

####Whales:
Players who have spent at least $20 in their lifetime. [More info](UnityAnalyticsTerminology)


</div>

<div class="Glossary" title="Animation"><a name="SectionAnimation"></a>
##Animation terms

####1D Blend Tree*:
A Blend Tree for 1D blending, which blends motion according to a single Animation Parameter. [More info](BlendTree-1DBlending)

####2D Blend Tree*:
A Blend Tree for 2D blending, which blends motion according to two Animation Parameters. [More info](BlendTree-2DBlending)

####3D Object*:
A 3D GameObject such as a cube, terrain or ragdoll. [More info](GameObjects)

####Animation Blend Shape*:
Enables you to make an object change its form by blending between two separate meshes. [More info](BlendShapes)

####Animation Blend Tree*:
Used for continuous blending between similar Animation Clips based on float Animation Parameters. [More info](class-BlendTree)

####Animation Clip*:
Animation data that can be used for animated characters or simple animations. It is a simple "unit" piece of motion, such as (one specific instance of) "Idle", "Walk" or "Run". [More info](class-AnimationClip)

####Animation Clip Node*:
A node in a Blend Tree graph that contains an animation clip, such as a run or walk animation. [More info](class-BlendTree.html#AnimationClipNode)

####animation compression*:
The method of compressing animation data to significantly reduce file sizes without causing a noticable reduction in motion quality. Animation compression is a trade off between saving on memory and image quality. [More info](class-AnimationClip#AssetProperties)

####Animation Curves*:
Allows you to add data to an imported clip so you can animate the timings of other items based on the state of an animator. For example, for a game set in icy conditions, you could use an extra animation curve to control the emission rate of a particle system to show the player's condensing breath in the cold air. [More info](AnimationCurvesOnImportedClips)

####Animation Event*:
Allows you to add data to an imported clip which determines when certain actions should occur in time with the animation. For example, for an animated character you might want to add events to walk and run cycles to indicate when the footstep sounds should play. [More info](AnimationEventsOnImportedClips)

####Animation Layer*:
An Animation Layer contains an Animation State Machine that controls animations of a model or part of it. An example of this is if you have a full-body layer for walking or jumping and a higher layer for upper-body motions such as throwing an object or shooting. The higher layers take precedence for the body parts they control. [More info](AnimationLayers)

####Animation Parameters*:
Used to communicate between scripting and the Animator Controller. Some parameters can be set in scripting and used by the controller, while other parameters are based on Custom Curves in Animation Clips and can be sampled using the scripting API. [More info](AnimationParameters)

####Animation State Machine*:
A graph within an Animator Controller that controls the interaction of Animation States. Each state references an Animation Blend Tree or a single Animation Clip. [More info](AnimationStateMachines)

####Animation Transition*:
Allows a state machine to switch or blend from one animation state to another. Transitions define how long a blend between states should take, and the conditions that activate them. [More info](StateMachineTransitions)

####Animator Component*:
A component on a model that animates that model using the Animation system. The component has a reference to an Animator Controller asset that controls the animation. [More info](class-AnimatorController)

####Animator Controller*:
Controls animation through Animation Layers with Animation State Machines and Animation Blend Trees, controlled by Animation Parameters. The same Animator Controller can be referenced by multiple models with Animator components. [More info](class-AnimatorController)

####Animator Override Controller*:
Allows you to create multiple variants of an Animator Controller, with each variant using a different set of animations, while retaining the original Controller's structure, parameters and logic. [More info](AnimatorOverrideController)

####Animator Window*:
The window where the Animator Controller is visualized and edited. [More info](AnimatorWindow)

####Avatar*:
An interface for retargeting animation from one rig to another. [More info](ConfiguringtheAvatar)

####Avatar Mask*:
A specification for which body parts to include or exclude for an animation rig. Used in Animation Layers and in the importer. [More info](class-AvatarMask)

####Bind-pose*:
The pose at which the character was modelled. 

####blend:
Transition from one animation to another animation smoothly and seamlessly, such as blending a character's walking and running animations according to the character's speed. 

####Blend Node*:
A node in a Blend Tree graph that blends animation clip nodes. [More info](class-BlendTree#BlendNodes)

####Body Transform:
The mass center of the character. It is used in for animation retargeting and provides the most stable displacement model. [More info](RootMotion)

####Direct Blend Tree*:
A Blend Tree that allows you to map animator parameters directly to the weight of a Blend Tree child. This is useful when you want to have exact control over the  animations that are being blended rather than blend them indirectly using one or two parameters (in the case of 1D and 2D blend trees). [More info](BlendTree-DirectBlending)

####forward kinematics*:
A method of posing a skeleton for animation by rotating the joint angles to predetermined values. The position of a child joint changes according to the rotation of its parent and so the end point of a chain of joints can be determined from the angles and relative positions of the individual joints it contains. 

####Human template*:
A pre-defined bone-mapping. Used for matching bones from FBX files to the Avatar. [More info](class-HumanTemplate)

####Humanoid animation*:
An animation using humanoid skeletons. Humanoid models generally have the same basic structure, representing the major articulate parts of the body, head and limbs. This makes it easy to map animations from one humanoid skeleton to another, allowing retargeting and inverse kinematics. [More info](ConfiguringtheAvatar)

####inverse kinematics (IK)*:
The automatic calculation of joint angles (eg. the shoulder and elbow joint of an arm) so that the end point (eg. the hand) reaches a desired point in space. In contrast to __Forward Kinematics__ [More info](InverseKinematics)

####keyframe*:
A frame that marks the start or end point of a transition in an animation.  Frames in between the keyframes are called inbetweens. 

####Keyframe Reduction*:
A process that removes redundant keyframes. [More info](class-AnimationClip.html#AssetProperties)

####kinematics*:
The geometry that describes the position and orientation of a character's joints and bodies. Used by inverse kinematics to control character movement. 

####Loop Pose*:
An animation clip setting that blends the end and start of an animation to create a seamless join. [More info](class-AnimationClip)

####Muscle definition*:
This allows you to have more intuitive control over the character's skeleton. When an Avatar is in place, the Animation system works in muscle space, which is more intuitive than bone space. [More info](MuscleDefinitions)

####Ping Pong:
To repeatedly play an animation to the end, then in reverse back to the beginning, in a loop. 

####Playable Graph*:
An API for controlling Playables. Playable Graphs allow you to create, connect and destroy playables. [More info](Playables-Graph.html)

####Playables*:
An API that provides a way to create tools, effects or other gameplay mechanisms by organizing and evaluating data sources in a tree-like structure known as the PlayableGraph. [More info](Playables.html)

####Retargeting*:
Applying animations created for one model to another. [More info](Retargeting)

####Rigging*:
The process of building a skeleton hierarchy of joints for your mesh. Performed with an external tool, such as Blender or Autodesk Maya. [More info](UsingHumanoidChars)

####Root Motion*:
Motion of character's root node, whether it's controlled by the animation itself or externally. [More info](RootMotion)

####Root node*:
A transform in an animation hierarchy that allows Unity to establish consistency between Animation clips for a generic model. It also enables Unity to properly blend between Animations that have not been authored "in place" (that is, where the whole Model moves its world position while animating). [More info](AnimationRootMotionNodeOnImportedClips)

####Root Transform*:
The Transform at the top of a hierarchy of Transforms. In a Prefab, the Root Transform is the topmost Transform in the Prefab. In an animated humanoid character, the Root Transform is a projection on the Y plane of the Body Transform and is computed at run time. At every frame, a change in the Root Transform is computed, and then this is applied to the GameObject to make it move. [More info](RootMotion.html)

####Scene*:
A Scene contains the environments and menus of your game. Think of each unique Scene file as a unique level. In each Scene, you place your environments, obstacles, and decorations, essentially designing and building your game in pieces. [More info](CreatingScenes.html)

####Skinning*:
The process of binding bone joints to the vertices of a character's mesh or 'skin'. Performed with an external tool, such as Blender or Autodesk Maya. [More info](UsingHumanoidChars)

####State Machine*:
The set of states in an Animator Controller that a character or animated GameObject can be in, along with a set of transitions between those states and a variable to remember the current state. The states available will depend on the type of gameplay, but typical states include things like idling, walking, running and jumping. [More info](StateMachineBasics.html)

####State Machine Behaviour*:
A script that attaches to a state within a state machine to control what happens when the state machine enters, exits or remains within a state, such as play sounds as states are entered. [More info](StateMachineBehaviours)

####T-pose*:
The pose in which the character has their arms straight out to the sides, forming a "T". The required pose for the character to be in, in order to make an Avatar. 

####Target matching:
A scripting function that allows you to move characters in such a way that a hand or foot lands in a certain place at a certain time. For example, the character may need to jump across stepping stones or jump and grab an overhead beam. [More info](TargetMatching.html)

####Transition:
The blend from one state to another in a state machine, such as transitioning a character from a walk to a jog animation. Transitions define how long the blend between states should take, and the conditions that activate the blend. [More info](class-Transition.html)

####Translate DoF*:
The three degrees-of-freedom associated with translation (movement in X,Y & Z) as opposed to rotation. 


</div>

<div class="Glossary" title="Assets"><a name="SectionAssets"></a>
##Asset terms

####Asset*:
Any media or data that can be used in your game or Project. An asset may come from a file created outside of Unity, such as a 3D model, an audio file or an image. You can also create some asset types in Unity, such as an Animator Controller, an Audio Mixer or a Render Texture. [More info](AssetWorkflow)

####Asset Package*:
A collection of files and data from Unity Projects, or elements of Projects, which are compressed and stored in one file, similar to Zip files. Packages are a handy way of sharing and re-using Unity Projects and collections of assets.  [More info](AssetPackages)

####Asset Server*:
Legacy - An asset and version control system with a graphical user interface integrated into Unity. Enables team members to work together on a Project on different computers. [More info](AssetServer)

####Asset Store*:
A growing library of free and commercial assets created by Unity and members of the community. Offers a wide variety of assets, from textures, models and animations to whole Project examples, tutorials and Editor extensions. [More info](AssetStore)

####Billboard Asset*:
An asset that is a collection of pre-rendered images of a more complicated Mesh intended for use with the Billboard Renderer, in order to render an object at some distance from a Camera at a lower level of detail (LOD) to save on rendering time. [More info](class-BillboardAsset)

####Billboard Renderer*:
Renders Billboard Assets, either from a pre-made Asset (exported from SpeedTree) or from a custom-created file that you create using a script at runtime or from a custom editor, for example.  [More info](class-BillboardRenderer)

####Cache Server*:
A standalone app that you can run on your local computer that stores the imported Asset data to reduce the time it takes to import Assets. [More info](CacheServer.html)

####Model:
A 3D model representation of an object, such as a character, a building, or a piece of furniture. [More info](3D-formats)

####Model file*:
A file containing a 3D data, which may include definitions for meshes, bones, animation, materials and textures. [More info](3D-formats)

####Prefab*:
An asset type that allows you to store a GameObject complete with components and properties. The prefab acts as a template from which you can create new object instances in the scene.  [More info](Prefabs.html)

####Standard Asset*:
A collection of useful assets supplied with Unity. Unity ships with multiple Standard Asset such as 2D, Cameras, Characters, CrossPlatformInput, Effects, Environment, ParticleSystems, Prototyping, Utility, and Vehicles.  [More info](AssetTypes#Standard)

####Unity unit*:
The unit size used in Unity Projects. By default, 1 Unity unit is 1 meter. To use a different scale, set the Scale Factor in the Import Settings when importing Assets. 

</div>

<div class="Glossary" title="Audio"><a name="SectionAudio"></a>
##Audio terms

####Audio Clip*:
A container for audio data in Unity. Unity supports mono, stereo and multichannel audio assets (up to eight channels). Unity can import .aif, .wav, .mp3, and .ogg audio file format, and .xm, .mod, .it, and .s3m tracker module formats. [More info](class-AudioClip)

####Audio Distortion Filter*:
An audio filter that distorts the sound from an Audio Source or sounds reaching the Audio Listener by simulating the sound of a low quality radio transmission.  [More info](class-AudioDistortionFilter)

####Audio Effect*:
Any effect that can modify the output of Audio Mixer components, such as filtering frequency ranges of a sound or applying reverb. [More info](class-AudioEffectMixer)

####Audio Filter*:
Any audio filter that distorts the sound from an Audio Source or sounds reaching the Audio Listener.  [More info](class-AudioEffect)

####Audio High Pass Filter*:
An audio filter that passes high frequencies of an AudioSource and cuts off signals with frequencies lower than the Cutoff Frequency. [More info](class-AudioHighPassFilter.html)

####Audio Listener*:
A component that acts like a microphone, receiving sound from Audio Sources in the scene and outputting to the computer speakers. [More info](class-AudioListener.html)

####Audio Low Pass Filter*:
An audio filter that passes low frequencies of an Audio Source or all sound reaching an Audio Listener while removing frequencies higher than the Cutoff Frequency. [More info](class-AudioLowPassFilter.html)

####Audio Source*:
A component which plays back an Audio Clip in the scene to an audio listener or through an audio mixer.  [More info](class-AudioSource.html)

####Audio Spatializer*:
A plug-in that changes the way audio is transmitted from an audio source into the surrounding space. It takes the source and regulates the gains of the left and right ear contributions based on the distance and angle between the AudioListener and the AudioSource. [More info](AudioSpatializerSDK)

####Distortion Effect*:
An audio effect that modifies the sound by squashing and clipping the waveform to produce a rough, harsh result. [More info](class-AudioDistortionFilter.html)

####Doppler Factor*:
An audio setting that allows you to control how much the velocity of an object (relative to the audio listener) affects the pitch of any audio sources attached to it. [More info](class-AudioManager.html)

####Dry Level:
An audio setting that allows you to set the mix level of unprocessed signal in output in mB. 

####Dry Mix:
An audio setting that allows you to set the volume of the original signal to pass to output. 

####Play On Awake*:
Set this to true to make an Audio Source start playing on awake [More info](class-AudioClip.html)


</div>

<div class="Glossary" title="Core"><a name="SectionCore"></a>
##Core terms

####build:
The process of compiling your Project into a format that is ready to run on a specific platform or platforms. [More info](BuildSettings)

####Managed plug-in*:
A managed .NET assembly that is created with tools like Visual Studio for use in Unity. [More info](Plugins.html)

####Native plug-in*:
A platform-specific native code library that is created outside of Unity for use in Unity. Allows you can access features like OS calls and third-party code libraries that would otherwise not be available to Unity. [More info](Plugins.html)

####Perforce*:
A version control system for file change management. [More info](perForceIntegration)

####Development Build*:
A development build includes debug symbols and enables the Profiler. [More info](UnityCloudBuildDevelopmentBuilds.html)


</div>

<div class="Glossary" title="Editor"><a name="SectionEditor"></a>
##Editor terms

####Anchor:
A UI layout tool that fixes a UI element to a parent element. Anchors are shown as four small triangular handles in the Scene View and anchor information is also shown in the Inspector. [More info](UIBasicLayout.html)

####Console window*:
A Unity Editor window that shows errors, warnings and other messages generated by Unity, or your own scripts. [More info](Console)

####Input Manager*:
Settings where you can define all the different input axes, buttons and controls for your Project. [More info](ConventionalGameInput)

####Inspector*:
A Unity window that displays information about the currently selected GameObject, Asset or Project Settings, alowing you to inspect and edit the values. [More info](UsingTheInspector)

####Player Settings*:
Settings that let you set various player-specific options for the final game built by Unity. [More info](class-PlayerSettings.html)

####Project View*:
A view that shows the contents of your Assets folder (Project tab) [More info](ProjectView.html)

####Property Drawer*:
A Unity feature that allows you to customize the look of certain controls in the Inspector window by using attributes on your scripts, or by controlling how a specific Serializable class should look [More info](editor-PropertyDrawers.html)

####Scene View*:
An interactive view into the world you are creating. You use the Scene View to select and position scenery, characters, cameras, lights, and all other types of Game Object. [More info](UsingTheSceneView.html)

####Time Manager*:
A Unity Settings Manager that lets you set a number of properties that control timing within your game. [More info](class-TimeManager.html)

####zoom:
A camera control that lets you scale the view on your screen. To zoom a camera in the Unity Editor, press Alt + right click and drag. [More info](SceneViewNavigation)


</div>

<div class="Glossary" title="General"><a name="SectionGeneral"></a>
##General terms

####Animation Key*:
The value of an animatable property, set at a specific point in time. Setting at least two keys for the same property creates an animation. [More info](animeditor-AnimationCurves)

####Billboard*:
A textured 2D object that rotates as it, or the Camera, moves so that it always faces the Camera. See [Billboard Renderer](class-BillboardRenderer)

####Billboarding*:
The process of constantly altering the 2D object's rotation so that it always faces the Camera. Billboarding is often used as a level-of-detail method for objects far away from the Camera. See [Billboard Renderer](class-BillboardRenderer)

####compression*:
A method of storing data that reduces the amount of storage space it requires. See [Texture Compression](class-TextureImporterOverride), [Animation Compression](class-AnimationClip#AssetProperties), [Audio Compression](class-AudioClip), [Build Compression](ReducingFilesize). 

####console:
See game console 

####Deferred shading*:
A rendering path that places no limit on the number of lights that can affect a GameObject. All lights are evaluated per-pixel, which means that they all interact correctly with normal maps and so on. Additionally, all lights can have cookies and shadows. [More info](RenderTech-DeferredShading)

####Extrapolate, Extrapolation*:
The process of storing the last few known values and using them to predict future values. Used in animation, physics and multiplayer. 

####first person shooter*:
A common game genre, featuring a first-person view of a 3D world, and gun-based combat with other players or NPCs. 

####FBX:
See Model File [More info](3D-formats)

####FPS*:
See first person shooter, frames per second. 

####game console*:
A device that runs and displays video games. 

####game controller*:
A device to control objects and characters in a game. 

####GameObject*:
The fundamental object in Unity scenes, which can represent characters, props, scenery, cameras, waypoints, and more. A GameObject's functionality is defined by the Components attached to it. [More info](class-GameObject)

####Input Key*:
A key on a keyboard relating to the Input class. [More info](ScriptRef:KeyCode)

####Interpolate, Interpolation*:
The process of calculating values in-between two defined values. Used in animation (between keyframes), physics (between physics time-steps), and multiplayer (between network updates) 

####Joy Num:
An Input Manager property that defines which joystick will be used.  [More info](ConventionalGameInput)

####Layer Mask*:
A value defining which layers to include or exclude from an operation, such as rendering, collision or your own code. [More info](Layers)

####Mask:
Can refer to a Sprite Mask, a UI Mask, or a Layer Mask [More info](script-Mask.html)

####Object:
See GameObject. 

####Parent:
An object that contains child objects in a hierarchy. When a GameObject is a Parent of another GameObject, the Child GameObject will move, rotate, and scale exactly as its Parent does. You can think of parenting as being like the relationship between your arms and your body; whenever your body moves, your arms also move along with it. [More info](Transforms.html#parent)

####Profiler*:
A window that helps you to optimize your game. It shows how much time is spent in the various areas of your game. For example, it can report the percentage of time spent rendering, animating or in your game logic. [More info](Profiler)

####Project:
In Unity, you use a Project to design and develop a game. A Project stores all of the files that are related to a game, such as the Asset and Scene files. [More info](2Dor3D)

####Project Settings*:
A broad collection of settings which allow you to configure how Physics, Audio, Networking, Graphics, Input and many other areas of your Project behave. [More info](comp-ManagerGroup.html)

####Plug-in*:
A set of code created outside of Unity that creates functionality in Unity. There are two kinds of plug-ins you can use in Unity: Managed plug-ins (managed .NET assemblies created with tools like Visual Studio) and Native plug-ins (platform-specific native code libraries). [More info](Plugins)

####Sprite Mask*:
A texture which defines which areas of an underlying image to reveal or hide. [More info](class-SpriteMask)

####Transform Component*:
A Transform component determines the Position, Rotation, and Scale of each object in the scene. Every GameObject has a Transform. [More info](Transforms)

####Tree:
A GameObject and associated Component that allows you to add tree assets to your scene. You can add branch levels and leaves to trees in the Tree Inspector window. [More info](class-Tree)

####Velocity:
A vector that defines the speed and direction of motion of a Rigidbody 

####Version Control*:
A system for managing file changes. You can use Unity in conjunction with most common version control tools, including Perforce, Git, Mercurial and PlasticSCM. [More info](VersionControl.html)

####Viewport*:
The user's visible area of an app on their screen. 

####World:
The area in your scene in which all objects reside. Often used to specify that coordinates are world-relative, as opposed to object-relative. 

</div>

<div class="Glossary" title="Graphics"><a name="SectionGraphics"></a>
##Graphics terms

####Ambient GI*:
A ambient light source generated by the Global Illumination (GI) system that provides omni-directional light to all objects in the scene equally. [More info](GlobalIllumination)

####Ambient occlusion*:
A method to approximate how much ambient lighting (lighting not coming from a specific direction) can hit a point on a surface. [More info](PostProcessing-AmbientOcclusion.html)

####Aniso Level*:
The anisotropic filtering (AF) level of a texture. Allows you to increase  texture quality when viewing a texture at a steep angle. Good for floor and ground textures. [More info](TextureTypes)

####Antialiasing*:
A technique for decreasing artifacts, like jagged lines (jaggies), in images to make them appear smoother. [More info](PostProcessing-Antialiasing.html)

####Aspect Ratio*:
The relationship of an image's proportional dimensions, such as its width and height. 

####ASTC*:
Adaptive Scalable Texture Compression (ASTC) A block-based texture format that compresses textures to significantly reduce file sizes without cau  sing a noticable reduction in image quality. [More info](class-TextureImporterOverride.html)

####ATC*:
AMD's texture compression format for handheld devices to save on power, memory and bandwidth 

####Baked Lights*:
A Light Mode for creating local ambience, rather than fully featured lights for increasing brightness in dark areas without needing to adjust all of the lighting within a Scene. Unity pre-calculates the illumination from these lights before run time, and does not include them in any run-time lighting calculations. [More info](LightMode-Baked.html)

####blit*:
A shorthand term for "bit block transfer". A blit operation is the process of transferring blocks of data from one place in memory to another. 

####Bloom:
A post-processing effect used to reproduce an imaging artifact of real-world cameras. The effect produces fringes of light extending from the borders of bright areas in an image, contributing to the illusion of an extremely bright light overwhelming the camera or eye capturing the scene. 

####Bounds:
The coordinates that define the bounding volume. Bounds are pre-calculated on import from the Mesh and animations in the model file, and are displayed as a wireframe around the model in the Scene View. 

####Branch Group*:
A tree node that generates branches and fronds. Its properties appear when you have selected a branch or leaf node. [More info](tree-Branches.html)

####Bump map*:
An image texture used to represent geometric detail across the surface of a mesh, for example bumps and grooves. Can be represented as a height map or a normal map. [More info](StandardShaderMaterialParameterNormalMap.html)

####Camera*:
A component which creates an image of a particular viewpoint in your scene. The output is either drawn to the screen or captured as a texture. [More info](CamerasOverview)

####CGPROGRAM*:
A block of shader code for controlling shaders using NVIDIA's Cg (C for graphics) programming language. [More info](SL-BuiltinIncludes.html)

####clipping plane*:
A plane that limits how far or close a camera can see from its current position. A camera's viewable range is between the far and near clipping planes. See far clipping plane and near clipping plane. [More info](class-Camera.html)

####Color Animation*:
Any color property of a component can be animated. Also particle system colors can be animated using the "Color over lifetime" module. 

####component:
A functional part of a GameObject. A GameObject can contain any number of components. Unity has many built-in components, and you can create your own by writing scripts that inherit from MonoBehaviour. [More info](UsingComponents)

####Content:
The objects being rendered in your scene. [More info](StandardShaderContextAndContent.html)

####Context:
The lighting that exists in the scene which affects the object being lit. [More info](StandardShaderContextAndContent.html)

####Cubemap*:
A collection of six square textures that can represent the reflections in an environment or the skybox drawn behind your geometry. The six squares form the faces of an imaginary cube that surrounds an object; each face represents the view along the directions of the world axes (up, down, left, right, forward and back). [More info](class-Cubemap.html)

####Culling Mask*:
Allows you to includes or omit objects to be rendered by a Camera, by Layer.

####depth buffer*:
A memory store that holds the z-value depth of each pixel in an image, where the z-value is the depth for each rendered pixel from the projection plane. [More info](class-RenderTexture)

####Depth of Field*:
A post-processing effect that simulates the focus properties of a camera lens. [More info](PostProcessing-DepthOfField.html)

####Diffuse shader*:
A old type of shader used in earlier versions of Unity. Replaced by the Standard Shader from Unity 5 onwards. [More info](shader-StandardShader.html)

####Distance Shadowmask*:
A version of the Shadowmask lighting mode that includes high quality shadows cast from static GameObjects onto dynamic GameObjects.  [More info](LightMode-Mixed-DistanceShadowmask.html)

####Dynamic Batching*:
An automatic Unity process which attempts to render multiple meshes as if they were a single mesh for optimized graphics performance. The technique transforms all of the GameObject vertices on the CPU and groups many similar vertices together. [More info](DrawCallBatching)

####dynamic receiver*:
A dynamic GameObject that is receiving a shadow from another static or dynamic GameObject [More info](LightMode-Mixed-BakedIndirect.html)

####dynamic resolution*:
A Camera setting that allows you to dynamically scale individual render targets, to reduce workload on the GPU. [More info](DynamicResolution)

####Enlighten*:
The lighting system by Geomerics used in Unity for computing global illumination (GI). [More info](https://www.siliconstudio.co.jp/en/products-service/enlighten/)

####ETC*:
(Ericsson Texture Compression) A block-based texture format that compresses textures to significantly reduce file sizes without causing a noticable reduction in image quality. [More info](class-TextureImporterOverride.html)

####Exponential fog*:
A fog model that emulates realistic fog behaviour by simulating light absorption over distance by a certain attenuation factor.

####Exposure value*:
A value that represents a combination of a camera's shutter speed and f-number. It is essentially a measurement of exposure such that all combinations of shutter speed and f-number that yield the same level of exposure have the same EV.

####Extrude Edges*:
A Texture property that enables you to define how much area to leave around a sprite in a generated mesh. 

####Far clipping plane*:
The maximum draw distance for a camera. Geometry beyond the plane defined by this value is not rendered. The plane is perpendicular to the camera's forward (Z) direction. 

####Flare:
The source asset used by Lens Flare Components. The Flare itself is a combination of a texture file and specific information that determines how the Flare behaves. [More info](class-Flare)

####Flare Fade Speed*:
A Lighting window property that allows you to set the time (in seconds) over which lens flares fade from view after initially appearing. [More info](class-LensFlare.html)

####Flare Layer*:
A component that you can attach to Cameras to make Lens Flares appear in the image. By default, a Flare Layer is already attached to a Camera. 

####Flare Texture*:
A texture containing images used by a Flare asset. It must be arranged according to one of the TextureLayout options. 

####Fog:
A post-processing effect that overlays a color onto objects depending on the distance from the camera. Use this to simulate fog or mist in outdoor environments, or to hide clipping of objects near the camera's far clip plane. [More info](PostProcessing-Fog.html)

####Forward Rendering*:
A rendering path that renders each object in one or more passes, depending on lights that affect the object. Lights themselves are also treated differently by Forward Rendering, depending on their settings and intensity. [More info](RenderTech-ForwardRendering.html)

####fragment shader*:
The "per-pixel" part of shader code, performed every pixel that an object occupies on-screen. The fragment shader part is usually used to calculate and output the color of each pixel. [More info](ShaderTut2)

####frame:
A single image from a sequence of images that represent moving graphics. While you game is running, the camera in your game renders frames to the screen as fast as possible. May also refer to a frame from a video clip, or sprite animation frames. See: frames per second (FPS). 

####frames per second*:
The frequency at which consecutive frames are displayed in a running game.  [More info](RenderingStatistics)

####Fresnel Effect*:
An effect representing the increase in reflectivity on objects when light hits at grazing angles. In Unity, the Standard Shader handles this indirectly, depending on a material's smoothness. Smooth surfaces have a stronger Fresnel, totally rough surfaces have no Fresnel. [More info](StandardShaderFresnel)

####Frustum:
The region of 3D space that a perspective camera can see and render. In the Scene view, the frustum is represented by a truncated rectangular pyramid with its top at the camera’s near clipping plane and its base at the camera’s far clipping plane. [More info](UnderstandingFrustum)

####GI Cache*:
The cached intermediate files used when Unity precomputes real-time GI, and when baking Static Lightmaps, Light Probes and Reflection Probes. Unity keeps this cache to speed up computation. [More info](GICache)

####Gizmo*:
A graphic overlay associated with a GameObject in a Scene, and displayed in the Scene View. Built-in scene tools such as the move tool are Gizmos, and you can create custom Gizmos using textures or scripting. Some Gizmos are only drawn when the GameObject is selected, while other Gizmos are drawn by the Editor regardless of which GameObjects are selected.  [More info](GizmosMenu#gizmos)

####Gravity Modifier*:
A Particle System property that scales the gravity value set in the physics manager. A value of zero switches gravity off.  [More info](PartSysMainModule)

####Group Seed*:
A tree property that varies the procedural generation of branch and leaf groups. [More info](tree-Branches)

####Growth Angle*:
A tree property that sets the initial angle of branch or leaf group growth relative to the parent. [More info](tree-Branches)

####Growth Scale*:
A tree property that sets the scale of branch and leaf group nodes along the parent node. [More info](tree-Branches)

####Halo:
The glowing light areas around light sources, used to give the impression of small dust particles in the air. [More info](class-Halo)

####Hard Shadows:
A shadow property that produces shadows with a sharp edge. Hard shadows are not particularly realistic compared to Soft Shadows but they involve less processing, and are acceptable for many purposes. [More info](ShadowOverview)

####HDR*:
high dymanic range 

####HDRI*:
high dynamic range image 

####Irradiance Budget*:
A lightmap property that determines the precision of the incoming light data used to light each texel in the lightmap [More info](class-LightmapParameters)

####Irradiance Quality*:
A lightmap property that sets the number of rays that are cast and used to compute which clusters affect a given output lightmap texel.  [More info](class-LightmapParameters)

####Layer:
Layers in Unity can be used to selectively opt groups of GameObjects in or out of certain processes or calculations. This includes camera rendering, lighting, physics collisions, or custom calculations in your own code. [More info](Layers)

####Lens Dirt*:
A Bloom effect property that applies a fullscreen layer of smudges or dust to diffract the Bloom effect. This is commonly used in modern first person shooters. [More info](PostProcessing-Bloom.html#lensDirt)

####Lens Flare*:
A component that simulates the effect of lights refracting inside a camera lens. Use a Lens Flare to represent very bright lights or add atmosphere to your scene. [More info](class-LensFlare)

####Light Mode*:
A Light property that defines the use of the Light. Can be set to Realtime, Baked and Mixed. [More info](LightModes.html)

####Light Probe*:
Light probes store information about how light passes through space in your scene. A collection of light probes arranged within a given space can improve lighting on moving objects and static LOD scenery within that space. [More info](LightProbes)

####Light Probe Group*:
A component that enables you to add Light Probes to GameObjects in your scene. [More info](class-LightProbeGroup)

####Light Probe Proxy Volume*:
A component that allows you to use more lighting information for large dynamic GameObjects that cannot use baked lightmaps (for example, large Particle Systems or skinned Meshes). [More info](class-LightProbeProxyVolume)

####Lightmap*:
A pre-rendered texture that contains the effects of light sources on static objects in the scene. Lightmaps are overlaid on top of scene geometry to create the effect of lighting. [More info](Lightmapping.html)

####Lightmapper*:
A tool in Unity that bakes lightmaps according to the arrangement of lights and geometry in your scene. [More info](Lightmapping.html)

####Line Renderer*:
A component that takes an array of two or more points in 3D space and draws a straight line between each one. You can use a single Line Renderer component to draw anything from a simple straight line to a complex spiral. [More info](class-LineRenderer)

####LOD*:
See level of detail [More info](LevelOfDetail.html)

####LOD Group*:
A component to manage level of detail (LOD) for GameObjects. [More info](class-LODGroup.html)

####material:
An asset that defines how a surface should be rendered, by including references to the Textures it uses, tiling information, Color tints and more. The available options for a Material depend on which Shader the Material is using. [More info](class-Material)

####Mesh*:
The main graphics primitive of Unity. Meshes make up a large part of your 3D worlds. Unity supports triangulated or Quadrangulated polygon meshes. Nurbs, Nurms, Subdiv surfaces must be converted to polygons. [More info](comp-MeshGroup)

####Mesh Filter*:
A mesh component that takes a mesh from your assets and passes it to the Mesh Renderer for rendering on the screen. [More info](class-MeshFilter)

####Mesh Renderer*:
A mesh component that takes the geometry from the Mesh Filter and renders it at the position defined by the object's Transform component. [More info](class-MeshRenderer)

####Motion Blur*:
A common post-processing effect that simulates the blurring of an image when objects filmed by a camera are moving faster than the camera's exposure time. [More info](PostProcessing-MotionBlur)

####Near clipping plane*:
A plane that limits how close a camera can see from its current position. The  plane is perpendicular to the camera's forward (Z) direction. [More info](CamerasOverview)

####Normal:
The direction perpendicular to the surface of a mesh, represented by a Vector. Unity uses normals to determine object orientation and apply shading.  [More info](ComputingNormalPerpendicularVector)

__Normal map__ :
A type of Bump Map texture that allows you to add surface detail such as bumps, grooves, and scratches to a model which catch the light as if they are represented by real geometry. [More info](StandardShaderMaterialParameterNormalMap)

####Occlusion Area*:
A component which defines a 3D space within which to apply Occlusion Culling to moving objects. [More info](class-OcclusionArea)

####Occlusion Culling*:
A Unity feature that disables rendering of objects when they are not currently seen by the camera because they are obscured (occluded) by other objects. [More info](OcclusionCulling)

####Occlusion Portal*:
An occlusion primitive that acts as an occluder, but can be switched on or off. Commonly used to represent opaque doors in games. [More info](class-OcclusionPortal)

####OpenGL Core*:
The back-end Unity uses to support the latest OpenGL features on Windows, MacOS X and Linux. [More info](OpenGLCoreDetails)

####Orthographic 3D*:
A common type of camera view used in games that give you a bird's-eye view of the action, and is sometimes called "2.5D". [More info](2Dor3D.html)

####particle:
A small, simple image or mesh that is emitted by a particle system. A particle system can display and move particles in great numbers to represent a fluid or amorphous entity. The effect of all the particles together creates the impression of the complete entity, such as smoke. [More info](class-ParticleSystem)

####particle system*:
A component that simulates fluid entities such as liquids, clouds and flames by generating and animating large numbers of small 2D images in the scene.  [More info](class-ParticleSystem)

####Physically Based Shading*:
An advanced lighting model that simulates the interactions between materials and light in a way that mimics reality. [More info](shader-StandardShader.html)

####pixel*:
The smallest unit in a computer image. Pixel size depends on your screen resolution. Pixel lighting is calculated at every screen pixel. [More info](LightPerformance)

####Player Log*:
The .log file created by a Standalone Player that contains a record of events, such as script execution times, the compiler version, and AssetImport time. Log files can help diagnose problems. [More info](LogFiles.html#Player)

####post processing*:
A process that improves product visuals by applying filters and effects before the image appears on screen. You can use post-processing effects to simulate physical camera and film properties, for example Bloom and Depth of Field. [More info](PostProcessingOverview)

####pseudo-depth:
A visual simulation of three-dimensional characteristics on a two-dimensional object or environment. This effect is sometimes called "2.5D". [More info](IsometricTilemap)

####PVRTC*:
PowerVR Texture Compression (PVRTC) is a fixed-rate texture format that compresses textures to significantly reduce file sizes without causing a noticable reduction in image quality. [More info](class-TextureImporterOverride.html)

####Quad*:
A primitive object that resembles a plane but its edges are only one unit long, it uses only 4 vertices, and the surface is oriented in the XY plane of the local coordinate space. [More info](PrimitiveObjects.html)

####Quaternion*:
Unity's standard way of representing rotations as data. When writing code that deals with rotations, you should usually use the Quaternion class and its methods. [More info](QuaternionAndEulerRotationsInUnity)

####Real-time light*:
A Lighting Mode for Lights that need to change their properties or which are spawned via scripts during gameplay. Unity calculates and updates the lighting of these Lights every frame at run time. They can change in response to actions taken by the player, or events which take place in the Scene. [More info](LightMode-Realtime.html)

####Reflection Probe*:
A rendering component that captures a spherical view of its surroundings in all directions, rather like a camera. The captured image is then stored as a Cubemap that can be used by objects with reflective materials. [More info](class-ReflectionProbe.html)

####Render Texture*:
A special type of Texture that is created and updated at runtime. To use them, first create a new Render Texture and designate one of your Cameras to render into it. Then you can use the Render Texture in a Material just like a regular Texture. [More info](class-RenderTexture.html)

####Rendering*:
The process of drawing graphics to the screen (or to a render texture). By default, the main camera in Unity renders its view to the screen. [More info](GraphicsOverview)

####Rendering Mode*:
A Standard Shader Material parameter that allows you to choose whether the object uses transparency, and if so, which type of blending mode to use. [More info](StandardShaderMaterialParameterRenderingMode)

####Rendering Path*:
The technique Unity uses to render graphics. Choosing a different path affects the performance of your game, and how lighting and shading are calculated. Some paths are more suited to different platforms and hardware than others. [More info](RenderingPaths)

####Ribbon:
A particle system property that connects particles together to create a ribbon effect. [More info](PartSysTrailsModule.html)

####shader*:
A small script that contains the mathematical calculations and algorithms for calculating the Color of each pixel rendered, based on the lighting input and the Material configuration.  [More info](Shaders)

####ShaderLab*:
Unity's declarative language for writing shaders. [More info](SL-Shader)

####Shadowmask*:
A Texture that shares the same UV layout and resolution with its corresponding lightmap. [More info](LightMode-Mixed-Shadowmask)

####Skybox*:
A special type of Material used to represent skies. Usually six-sided. [More info](class-Skybox)

####Soft Shadows:
A shadow property that produces shadows with a soft edge. Soft shadows are more realistic compared to Hard Shadows and tend to reduce the "blocky" aliasing effect from the shadow map, but they require more processing. [More info](ShadowOverview)

####Sorting Fudge*:
A Particle System property that sets the bias of the particle system sort ordering. Lower values increase the relative chance that particle systems are drawn over other transparent GameObjects, including other particle systems. [More info](PartSysRendererModule.html#fudge)

####Spatial Mapping*:
The process of mapping real-world surfaces into the virtual world. [More info](SpatialMapping.html)

####Sprite*:
A 2D graphic objects. If you are used to working in 3D, Sprites are essentially just standard textures but there are special techniques for combining and managing sprite textures for efficiency and convenience during development. [More info](Sprites.html)

####Sprite Packer*:
A facility that packs graphics from several sprite textures tightly together within a single texture known as an atlas. Unity provides a Sprite Packer utility to automate the process of generating atlases from the individual sprite textures. [More info](SpritePacker.html)

####Sprite Renderer*:
A component that lets you display images as Sprites for use in both 2D and 3D scenes. [More info](class-SpriteRenderer.html)

####Standard Shader*:
A built-in shader for rendering real-world objects such as stone, wood, glass, plastic and metal. Supports a wide range of shader types and combinations. [More info](shader-StandardShader.html)

####Static Batching*:
A technique Unity uses to draw GameObjects on the screen that combines static (non-moving) GameObjects into big Meshes, and renders them in a faster way. [More info](DrawCallBatching)

####Static receiver*:
A static GameObject that is receiving a shadow from another static or dynamic GameObject [More info](StaticObjects)

####stencil buffer*:
A memory store that holds an 8-bit per-pixel value. In Unity, you can use a stencil buffer to flag pixels, and then only render to pixels that pass the stencil operation. [More info](class-RenderTexture)

####subshader*:
Each shader in Unity consists of a list of subshaders. When Unity has to display a mesh, it will find the shader to use, and pick the first subshader that runs on the user's graphics card. [More info](SL-SubShader)

####surface shader*:
Unity's code generation approach that makes it much easier to write lit shaders than using low level vertex/pixel shader programs. [More info](SL-SurfaceShaders.html)

####Terrain*:
The landscape in your scene. A Terrain GameObject adds a large flat plane to your scene and you can use the Terrain's Inspector window to create a detailed landscape. [More info](terrain-UsingTerrains.html)

####Text Mesh*:
A Mesh component that displays a Text string [More info](class-TextMesh.html)

####texture:
An image used when rendering a GameObject, Sprite, or UI element. Textures are often applied to the surface of a mesh to give it visual detail. [More info](class-TextureImporter.html)

####Texture Compression*:
3D Graphics hardware requires Textures to be compressed in specialised formats which are optimised for fast Texture sampling. [More info](class-TextureImporterOverride.html)

####Texture Import Inspector*:
An Inspector that allows you to define how your images are imported from your Project's Assets folder into the Unity Editor. [More info](class-TextureImporter.html)

####Texture Overrides*:
Platform-specific settings that allow you to set the resolution, file size with associated memory size requirements, pixel dimensions, and quality of your Textures for each target platform. [More info](class-TextureImporterOverride.html)

####Tile:
A simple class that allows a sprite to be rendered on a Tilemap. [More info](Tilemap-ScriptableTiles-Tile.html)

####Tilemap*:
A GameObject that allows you to quickly create 2D levels using tiles and a grid overlay. [More info](Tilemap.html)

####Tonemapping*:
The process of remapping HDR values of an image into a range suitable to be displayed on screen.  [More info](PostProcessing-ColorGrading.html)

####Trail Renderer*:
A visual effect that lets you to make trails behind GameObjects in the Scene as they move. [More info](class-TrailRenderer)

####vector field:
A 3D texture, where each value represents a directional force that is applied to particles as they move through the field. A vector field is created in 3D animation software, such as Houdini. [More info](https://en.wikipedia.org/wiki/Vector_field)

####vertex shader*:
A program that runs on each vertex of a 3D model when the model is being rendered. [More info](SL-ShaderPrograms.html)

####VideoCapture*:
A Unity API that allows you to record videos directly to the file system in the MP4 format.  [More info](windowsholographic-videocapture.html)

####Voxel*:
A 3D pixel. [More info](nav-AdvancedSettings)

####Web Camera*:
A Unity asynchronous API that provides the ability to take pictures and record videos. [More info](windowsholographic-webcamera)

####WebGL*:
A JavaScript API that renders 2D and 3D graphics in a web browser. The Unity WebGL build option allows Unity to publish content as JavaScript programs which use HTML5 technologies and the WebGL rendering API to run Unity content in a web browser. [More info](webgl-gettingstarted.html)

####wind zone*:
A GameObject that adds the effect of wind to your terrain. For instance, Trees within a wind zone will bend in a realistic animated fashion and the wind itself will move in pulses to create natural patterns of movement among the tree. [More info](terrain-WindZones.html)

####level of detail, LOD*:
A rendering optimisation technique that allows you to reduce the number of triangles rendered for an object in stages as its distance from the camera increases. As long as your objects aren't all close to the camera at the same time, LOD will reduce the load on the hardware and improve rendering performance. [More info](class-LODGroup)


</div>

<div class="Glossary" title="Lighting"><a name="SectionLighting"></a>
##Lighting terms

####Mixed Lighting:
A Light Mode for creating indirect lighting, shadowmasks and subtractive lighting. Indirect lighting gets baked into lightmaps and light probes. Shadowmasks and light probes occlusion get generated for baked shadows. [More info](LightMode-Mixed.html)


</div>

<div class="Glossary" title="Multiplayer"><a name="SectionMultiplayer"></a>
##Multiplayer terms

####High Level API, LOD*:
A system for building multiplayer capabilities for Unity games. It is built on top of the lower level transport real-time communication layer, and handles many of the common tasks that are required for multiplayer games. [More info](UNetUsingHLAPI.html)

####Host:
In a multiplayer network game without a dedicated server, one of the peers in the game acts as the center of authority for the game. This peer is called the "host". It runs a server and a "local client", while the other peers each run a "remote client". [More info](UNetHostMigration)

####Player Object*:
A High Level API (HPAPI) object that represents the player on the server and has the ability to run commands (which are secure client-to-server remote procedure calls) from the player's client. [More info](UNetPlayers.html)

####netId*:
A unique identifier given to an object instance to track it between networked clients and the server.  [More info](class-NetworkBehaviour)

####Network Manager*:
A Networking component that manages the network state of a Project. [More info](class-NetworkManager)

####NetworkIdentity*:
A Networking component that allows you to assign an identity to your GameObject for the network to recognise it as a Local Player GameObject or a Server Only GameObject.  [More info](class-NetworkIdentity)

####Networking*:
The Unity system that enables multiplayer gaming across a computer network. [More info](UNetOverview.html)

####NetworkManagerHUD*:
A Networking component that creates a UI menu that allows you to control the network state of your game using your Network Manager. [More info](class-NetworkManagerHUD)

####NetworkTransform*:
A Networking component that allows you to synchronise the movements of GameObjects across the network. [More info](class-NetworkTransform)


</div>

<div class="Glossary" title="Physics"><a name="SectionPhysics"></a>
##Physics terms

####Bounding volume*:
A closed shape representing the edges and faces of a collider or trigger. [More info](SpatialMappingComponentsGeneralSettings)

####box collider*:
A cube-shaped collider component that handles collisions for GameObjects like dice and ice cubes. [More info](class-BoxCollider)

####broad-phase collision detection*:
A collision detection phase that computes pairs of potentially overlapping objects by judging only their respective bounding volumes. [More info](http://planning.cs.uiuc.edu/node214.html)

####capsule collider*:
A capsule-shaped collider component that handles collisions for GameObjects like barrels and character limbs. [More info](class-CapsuleCollider)

####Center of Mass*:
Represents the average position of all mass in a rigidbody for the purposes of physics calculations. By default it is computed from all colliders belonging to the rigidbody, but can be modified via script. [More info](ScriptRef:Rigidbody-centerOfMass.html)

####Character Controller*:
A simple, capsule-shaped collider component with specialized features for behaving as a character in a game. Unlike true collider components, a rigidbody is not needed and the momentum effects are not realistic. [More info](class-CharacterController)

####Character Joint*:
An extended ball-socket joint which allows a joint to be limited on each axis. Mainly used for Ragdoll effects. [More info](class-CharacterJoint)

####Cloth:
A component that works with the Skinned Mesh Renderer to provide a physics-based solution for simulating fabrics. [More info](class-Cloth)

####Collider*:
An invisible shape that is used to handle physical collisions for an object. A collider doesn't need to be exactly the same shape as the object's mesh - a rough approximation is often more efficient and indistinguishable in gameplay. [More info](CollidersOverview)

####Collision*:
A collision occurs when the physics engine detects that the colliders of two GameObjects make contact or overlap, when at least one has a rigidbody component and is in motion. [More info](CollidersOverview)

####Collision Detection*:
An automatic process performed by Unity which determines whether a moving GameObject with a rigidbody and collider component has come into contact with any other colliders. [More info](CollidersOverview)

####Configurable Joint*:
An extremely customisable joint that other joint types are derived from. It can be used to create anything from adapted versions of existing joints to custom designed and highly specialised joints. [More info](class-ConfigurableJoint.html)

####Constant Force*:
A simple component for adding a constant force or torque to game objects with a Rigidbody. [More info](class-ConstantForce)

####Constraints:
Settings on Joint components which limit movement or rotation. The type and number of constraints vary depending on the type of Joint. [More info](Joints2D.html#constraints)

####Contact Distance*:
A joint limit property that sets the minimum distance tolerance between the joint position and the limit at which the limit will be enforced. [More info](class-CharacterJoint)

####continuous collision detection*:
A collision detection method that calculates and resolves collisions over the entire physics simulation step. This can prevent fast-moving objects from tunnelling through walls during a simulation step.  [More info](ContinuousCollisionDetection.html)

####Damping Ratio*:
A joint setting to control spring oscillation. A higher damping ratio means the spring will come to rest faster. [More info](class-FixedJoint2D)

####discrete collision detection*:
A collision detection method that calculates and resolves collisions based on the pose of objects at the end of each physics simulation step. [More info](class-Rigidbody)

####Dynamic Friction*:
A Physic Material property that defines the friction for a Rigidbody when it's in motion. Lower values mean less friction, so a setting of zero represents slipping on ice. [More info](class-PhysicMaterial)

####Fixed Joint*:
A joint type that is completely constrained, allowing two objects to be held together. Implemented as a spring so some motion may still occur. [More info](class-FixedJoint.html)

####Fixed Timestep*:
A customizable framerate-independent interval that dictates when physics calculations and FixedUpdate() events are performed. [More info](class-TimeManager)

####High Twist Limit*:
The higher limit of a Character Joint. [More info](class-CharacterJoint)

####Hinge Joint*:
A joint that groups together two Rigidbodies, constraining them to move like they are connected by a hinge. It is perfect for doors, but can also be used to model chains, pendulums and so on. [More info](class-HingeJoint)

####joint*:
A physics component allowing a dynamic connection between rigidbodies, usually allowing some degree of movement such as a hinge. [More info](joints)

####Low Twist Limit*:
A joint property that sets the lower limit of a joint. [More info](class-CharacterJoint)

####Mesh Collider*:
A free-form collider component which accepts a mesh reference to define its collision surface shape. [More info](class-MeshCollider)

####narrow-phase collision detection*:
A collision detection phase that determines whether the pairs of objects found in the broad phase will actually collide. It then computes the contact points for those pairs and gives them to the solver to use when solving collisions. [More info](http://planning.cs.uiuc.edu/node214.html)

####Physic Material*:
A physics asset for adjusting the friction and bouncing effects of colliding objects. [More info](class-PhysicMaterial)

####Physics Engine*:
A system that simulates aspects of physical systems so that objects can accelerate correctly and be affected by collisions, gravity and other forces. [More info](PhysicsSection)

####Rig:
A skeletal hierarchy of joints for a mesh. [More info](FBXImporter-Rig)

####Rigidbody*:
A component that allows a GameObject to be affected by simulated gravity and other forces. [More info](class-Rigidbody)

####Self Collision*:
A cloth property that prevents cloth from penetrating itself. [More info](class-Cloth.html)

####Soft Particles*:
Particles that create semi-transparent effects like smoke, fog or fire. Soft particles fade out as they approach an opaque object, to prevent intersections with the geometry. [More info](shader-StandardParticleShaders)

####speculative continuous collision detection*:
A collision detection method that inflates broad-phase AABB  of moving objects according to their velocities. This enables support for effects like rotations. [More info](ContinuousCollisionDetection.html)

####Sphere Collider*:
A sphere-shaped collider component that handles collisions for GameObjects like balls or other things that can be roughly approximated as a sphere for the purposes of physics. [More info](class-SphereCollider)

####Spring Joint*:
A joint type that connects two Rigidbodies together but allows the distance between them to change as though they were connected by a spring. [More info](class-SpringJoint.html)

####Swing Axis*:
A joint property that defines the axis around which the joint can swing. [More info](class-CharacterJoint)

####Swing Limit*:
A joint property that limits the rotation around one element of the defined Swing Axis. [More info](class-CharacterJoint)

####Target Position*:
A joint property to set the target position that the joint's drive force should move it to. [More info](class-ConfigurableJoint)

####Target Velocity*:
A joint property to set the desired velocity with which the joint should move to the Target Position under the drive force. [More info](class-ConfigurableJoint)

####Terrain Collider*:
A terrain-shaped collider component that handles collisions for collision surface with the same shape as the Terrain object it is attached to. [More info](class-TerrainCollider)

####Wheel Collider*:
A special collider for grounded vehicles. It has built-in collision detection, wheel physics, and a slip-based tire friction model. It can be used for objects other than wheels, but it is specifically designed for vehicles with wheels. [More info](class-WheelCollider)


</div>

<div class="Glossary" title="Platforms"><a name="SectionPlatforms"></a>
##Platforms terms

####ADB*:
An Android Debug Bridge (ADB). You can use an ADB to deploy an Android package (APK) manually after building. [More info](https://developer.android.com/studio/command-line/adb.html)

####ADT*:
An Android project type that is no longer supported by Google and is considered obsolete. [More info](android-BuildProcess)

####AOT Compilation*:
Ahead of Time (AOT) compilation is an iOS optimization method for optimizing the size of the built iOS player [More info](iphone-playerSizeOptimization)

####APK*:
The Android Package format output by Unity. An APK is automatically deployed to your device when you select File > Build & Run. [More info](android-BuildProcess)

####AR*:
Augmented Reality (AR) uses computer graphics or video composited on top of a live video feed to augment the view and create interaction with real and virtual objects. 

####Cardboard:
See Google Cardboard 

####Gesture:
A HoloLens input type that uses hand signals to signify commands to the system. [More info](wmr_input_types)

####Google Cardboard*:
Google's virtual reality (VR) platform for smartphones. [More info](googlevr_sdk_overview)

####Gradle*:
An Android build system that automates several build processes. This automation means that many common build errors are less likely to occur. [More info](android-gradle-overview)

####Holographic*:
The former name for Windows Mixed Reality. [More info](wmr_sdk_overview)

####HoloLens*:
An XR headset for using apps made for the Windows Mixed Reality platform. [More info](wmr_sdk_overview)

####iOS*:
Apple's mobile operating system. [More info](iphone)

####Keystore*:
An Android system that lets you store cryptographic key entries for enhanced device security. [More info](class-PlayerSettingsAndroid.html#keystore)

####Oculus*:
A VR platform for making applications for Rift and mobile VR devices. [More info](OculusControllers)

####Oculus Rift*:
A VR headset for using apps made for the Oculus platform. [More info](OculusControllers)

####ODR*:
On-demand resources (ODR) is a feature available for the iOS and tvOS platforms, from version 9.0 of iOS and tvOS onwards. It allows you to reduce the size of your application by separating the core Assets (those that are needed from application startup) from Assets which may be optional, or which appear in later levels of your game. [More info](AppThinning)

####PhotoCapture*:
An API that enables you to take photos from a HoloLens web camera and store them in memory or on disk. [More info](windowsholographic-photocapture)

####PlayStation 4, PS4*:
Sony's eighth generation video game console.

####Razor*:
A CPU/GPU chip set used in PS4 hardware. [More info](BestPracticeUnderstandingPerformanceInUnity1)

####Rift:
See Oculus Rift. 

####Unity Remote*:
A downloadable app designed to help with Android, iOS and tvOS development. The app connects with Unity while you are running your Project in Play Mode from the Unity Editor. [More info](UnityRemote5)

####Virtual Reality*:
A system that immerses users in an artificial 3D world of realistic images and sounds, using a headset and motion tracking. [More info](VROverview)

####VR Trace*:
A virtual reality diagnostic tool by Sony Interactive Entertainment for PlayStation 4. [More info](BestPracticeUnderstandingPerformanceInUnity1)

####Wii U*:
Nintendo's eighth generation video game console.

####Windows Holographic*:
The former name for Windows Mixed Reality. [More info](wmr_sdk_overview)

####Windows Mixed Reality*:
A mixed reality platform developed by Microsoft, built around the API of Windows 10. [More info](mr-devices)

####Xbox One*:
Microsoft's eighth generation video game console.

####XR*:
An umbrella term encompassing Virtual Reality (VR), Augmented Reality (AR) and Mixed Reality (MR) applications. Devices supporting these forms of interactive applications can be referred to as XR devices. [More info](XR)


</div>

<div class="Glossary" title="Scripting"><a name="SectionScripting"></a>
##Scripting terms

####Event System*:
A way of sending events to objects in the application based on input, be it keyboard, mouse, touch, or custom input. The Event System consists of a few components that work together to send events. [More info](EventSystem)

####IL2CPP*:
A Unity-developed scripting back-end which you can use as an alternative to Mono when building Projects for some platforms.  [More info](IL2CPP)

####mcs*:
The Mono C# compiler file format. [More info](PlatformDependentCompilation)

####Mono:
A scripting backend used in Unity. [More info](windowsstore-scriptingbackends)

####MonoDevelop*:
An integrated development environment (IDE) supplied with Unity 2017.3 and previous versions. From Unity 2018.1 onwards, MonoDevelop is replaced by Visual Studio. [More info](https://www.monodevelop.com/)

####Scripting Backend*:
A framework that powers scripting in Unity. Unity supports three different scripting backends depending on target platform: Mono, .NET and IL2CPP. Universal Windows Platform, however, supports only two: .NET and IL2CPP. [More info](windowsstore-scriptingbackends)

####Scripting Event*:
A way of allowing a user-driven callback to persist from edit time to run time without the need for additional programming and script configuration [More info](EventSystem)

####Scripts*:
A piece of code that allows you to create your own Components, trigger game events, modify Component properties over time and respond to user input in any way you like. [More info](CreatingAndUsingScripts)

####Tag:
A reference word which you can assign to one or more GameObjects to help you identify GameObjects for scripting purposes. For example, you might define and "Edible" Tag for any item the player can eat in your game. [More info](Tags)

####Test Runner*:
A Unity tool that tests your code in both Edit mode and Play mode, and also on target platforms such as Standalone, Android, or iOS. [More info](testing-editortestsrunner)

####Texture Format*:
A file format for handling textures during realtime rendering by 3D graphics hardware, such as a graphics card or mobile device. [More info](class-TextureImporterOverride)


</div>

<div class="Glossary" title="Services"><a name="SectionServices"></a>
##Services terms

####Client RSA Public Key*:
An optional security layer that Unity can use when communicating between Unity and Xiaomi servers. Use it to receive server callbacks for client-side receipt validation, or to integrate with Unity server APIs.  [More info](UnityIAPXiaomi.html#rsa)

####Cloud Build*:
A continuous integration service for Unity Projects that automates the process of creating builds on Unity's servers. [More info](UnityCloudBuild)

####Collaborate:
A Unity cloud-hosted service that provides a simple way for teams to save, share, and contribute to their Unity Project. [More info](UnityCollaborate)

####Performance Reporting:
A Unity Service that captures and aggregates exception data, to help you understand what's happening during run time and to optimize your Project faster. [More info](UnityPerformanceReporting)

####Services:
A Unity facility that provides a growing range of complimentary services to help you make games and engage, retain and monetize audiences. [More info](UnityServices)

####Unity Cloud Build*:
See Cloud Build [More info](UnityCloudBuild)


</div>

<div class="Glossary" title="Timeline"><a name="SectionTimeline"></a>
##Timeline terms

####animatable property*:
A property belonging to a GameObject, or belonging to a component added to a GameObject, that can have different values over time. [More info](animeditor-AnimatingAGameObject)

####animation:
A collection of images that create a moving image when played sequentially. In Unity, an animation is the result of adding two different animation keys, at two different times, for the same __animatable property__. [More info](AnimationSection)

####animation curve*:
The curve drawn between keys set for the same animatable property, at different frames or seconds. The position of the tangents and the selected interpolation mode for each key determines the shape of the animation curve. [More info](AnimationCurvesOnImportedClips)

####binding or Track binding:
Refers to the link between Timeline Asset tracks and the GameObjects in the scene. When you link a GameObject to a track, the track animates the GameObject. Bindings are stored as part of the Timeline instance. [More info](class-PlayableDirector.html#binding)

####blend area*:
The area where two Animation clips, Audio clips, or Control clips overlap. The overlap creates a transition that is referred to as a blend. The duration of the overlap is referred to as the blend area. The blend area sets the duration of the transition. [More info](TimelineBlendingClips)

####Blend In curve*:
In a blend between two Animation clips, Audio clips, or Control clips, there are two blend curves. The blend curve for the incoming clip is referred to as the Blend In curve. [More info](TimelineBlendingClips)

####Blend Out curve*:
In a blend between two Animation clips, Audio clips, or Control clips, there are two blend curves. The blend curve for the out-going clip is referred to as the Blend Out curve. [More info](TimelineBlendingClips)

####Blend Type*:
A Blend Tree property that allows you to configure the Blend Tree for 1D, 2D or Direct blending. [More info](class-BlendTree)

####clip:
A generic term that refers to any clip within the Clips view of the Timeline Editor window. [More info](TimelineClipsView)

####Clips view*:
The area in the Timeline Editor window where you add, position, and manipulate clips. [More info](TimelineClipsView)

####Control:
A function for displaying text, buttons, checkboxes, scrollbars and other features on the user interface. [More info](gui-Controls)

####Curves view*:
The area in the Timeline Editor window that shows the animation curves for Infinite clips or for Animation clips that have been converted from Infinite clips. The Curves view is similar to Curves mode in the Animation window. [More info](TimelineCurvesView)

####field:
A generic term that describes an editable box that the user clicks to enter a value. Editable fields in the inspector are also commonly referred to as fields. [More info](script-InputField)

####Gap extrapolation*:
How an Animation track approximates animation data in the gaps before and after an Animation clip. [More info](TimelineGapExtrapolation)

####incoming clip*:
The second clip in a blend between two clips. The first clip, the out-going clip, transitions to the second clip, the incoming clip. [More info](TimelineBlendingClips)

####infinite clip*:
A special animation clip that contains basic key animation recorded directly to an Animation track within the Timeline Editor window. An Infinite clip cannot be positioned, trimmed, or split because it does not have a defined duration: it spans the entirety of an Animation track. [More info](TimelineWorkflowRecordingBasicAnimation)

####interpolation*:
The estimation of values that determine the shape of an animation curve between two keys. [More info](TimelineChangingInterpolation)

####interpolation mode*:
The interpolation algorithm that draws the animation curve between two keys. The interpolation mode also joins or breaks left and right tangents. [More info](TimelineChangingInterpolation)

####key:
Can refer to an Input Key or an Animation Key 

####out-going clip*:
The first clip in a blend between two clips. The first clip, the out-going clip, transitions to the second clip, the incoming clip. [More info](TimelineBlendingClips)

####Playhead Location field*:
The field that expresses the location of the Timeline Playhead in either frames or seconds, depending on the Timeline Settings. [More info](TimelinePlaybackControls)

####property:
A generic term for the editable fields, buttons, checkboxes, or menus that comprise a component. An editable property is also referred to as a field. [More info](editor-PropertyDrawers)

####tangent:
One of two handles that controls the shape of the animation curve before and after a key. Tangents appear when a key is selected in the Curves view, or when a key is selected in the Curve Editor. 

####tangent mode*:
The selected interpolation mode used by the left tangent, right tangent, or both tangents. 

####Timeline Asset*:
Refers to the tracks, clips, and recorded animation that comprise a cinematic, cut-scene, game-play sequence, or other effect created with the Timeline Editor window. A Timeline Asset does not include bindings to the GameObjects animated by the Timeline Asset. The bindings to scene GameObjects are stored in the Timeline instance. The Timeline Asset is Project-based. [More info](TimelineOverview)

####Timeline Editor window*:
The name of the window where you create, modify, and preview a Timeline instance. Modifications to a Timeline instance also affects the Timeline Asset. [More info](TimelineEditorWindow)

####Timeline instance*:
Refers to the link between a Timeline Asset and the GameObjects that the Timeline Asset animates in the scene. You create a Timeline instance by associating a Timeline Asset to a GameObject through a Playable Director component. The Timeline instance is scene-based. [More info](TimelineOverview)

####Timeline*:
Generic term within Unity that refers to all features, windows, editors, and components related to creating, modifying, or reusing cut-scenes, cinematics, and game-play sequences. [More info](TimelineSection)

####Timeline Playback Controls*:
The row of buttons and fields in the Timeline Editor window that controls playback of the Timeline instance. The Timeline Playback Controls affect the location of the Timeline Playhead. [More info](TimelinePlaybackControls)

####Timeline Playback mode*:
The mode that previews the Timeline instance in the Timeline Editor window. Timeline Playback mode is a simulation of Play mode. Timeline Playback mode does not support audio playback. [More info](TimelinePlaybackControls)

####Timeline Playhead*:
The white marker and line that indicates the exact point in time being previewed in the Timeline Editor window. [More info](TimelinePositioningClips)

####Timeline Selector*:
The name of the menu in the Timeline Editor window that selects the Timeline instance to be previewed or modified. [More info](TimelinePreviewSelector)

####track:
A generic term that refers to any track within the Track list of the Timeline Editor window. [More info](TimelineTrackList)

####Track group*:
The term for a series of tracks organized in an expandable and collapse collection of tracks. [More info](TimelineOrganizingTrackGroups)

####Track list*:
The area in the Timeline Editor window where you add, group, and modify tracks. [More info](TimelineTrackList)


</div>

<div class="Glossary" title="UI"><a name="SectionUI"></a>
##UI terms

####Canvas:
The area that contains all UI elements in a scene. The Canvas area is shown as a rectangle in the Scene View. [More info](UICanvas)

####Canvas Group*:
A group of UI elements within a Canvas. Use a Canvas Group to control a group of UI elements collectively without needing to handle them each individually.  [More info](class-CanvasGroup)

####Canvas Renderer*:
Renders a graphical UI object contained within a Canvas. [More info](class-CanvasRenderer)

####Canvas Scaler*:
Controls the overall scale and pixel density of all UI elements in the Canvas, including font sizes and image borders. [More info](script-CanvasScaler)

####Image control:
An Image control displays a non-interactive image to the user, such as a decoration and icon. You can change the image from a script to reflect changes in other controls. [More info](script-Image)

####Interactable:
A UI component property that detemines whether the component can accept input. [More info](script-Selectable)

####UI Mask*:
A visual component that lets you restrict images from view to only a small section of an image. For instance, you can apply a Mask to a Panel UI element to block all child images from view. [More info](script-Mask)

####Raw image:
A Visual UI Component that displays a non-interactive image to the user. This can be used for decoration, icons, etc, and the image can also be changed from a script to reflect changes in other controls.  [More info](script-RawImage)

####ScrollView*:
A UI Control which displays a large set of Controls in a viewable area that you can see by using a scrollbar. [More info](gui-Controls)

####Shadow:
A UI component that adds a simple outline effect to graphic components such as Text or Image. It must be on the same GameObject as the graphic component. [More info](script-Shadow)

####Text:
A non-interactive piece of text to the user. This can be used to provide captions or labels for other GUI controls or to display instructions or other text. [More info](script-Text)

####TextField control*:
A TextField control displays a non-interactive piece of text to the user, such as a caption, label for other GUI controls, or instruction. [More info](gui-Controls)

####Text Input Field*:
A field that allows the user to input a Text string [More info](script-InputField)

####Toggle:
A checkbox that allows the user to switch an option on or off. [More info](script-Toggle)

####Toolbar*:
A row of buttons and basic controls at the top of the Unity Editor that allows you to interact with the Editor in various ways (e.g. scaling, translation).  [More info](Toolbar)

####UI*:
(User Interface) Allows a user to interact with your application. [More info](UISystem)

####Visual Component*:
A component that enables you to easily create GUI-specific functionality. [More info](UIVisualComponents)


</div>