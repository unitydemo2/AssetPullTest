# Editor

Use the __Editor__ settings (main menu: **Edit** > **Project Settings**, the select the **Editor** category) to apply global settings for working in Unity's Editor.  


![Editor settings](../uploads/Main/EditorSettings173.png)



| Property || Function |
|:---|:---|:---|
| __Unity Remote__|||
| __Device__|| Choose the device type you want to use for Unity Remote testing. <br/>[Unity Remote](UnityRemote5) is a downloadable app designed to help with Android, iOS and tvOS development.  |
| __Compression__|| Choose the type of image compression to use when transmitting the game screen to the device via Unity Remote. Default is _JPEG_. |
|| _JPEG_ | JPEG usually gives higher compression and performance, but the graphics quality is a little lower. This is the default option. |
|| _PNG_ | PNG gives a more accurate representation of the game display, but can result in lower performance. |
| __Resolution__|| Choose the resolution the game should run at on Unity Remote. Default is _Downsize_. |
|| _Downsize_ | Display the game at a lower resolution. This results in better performance, but lower graphical accuracy. This is the default option. |
|| _Normal_ | Display the game at normal resolution. This results in better graphical accuracy, but lower performance. |
| __Joystick Source__|| Choose the connection source for the joysticks you are using. Default is _Remote_. |
|| _Remote_ | Use joysticks that are connected to a device running Unity Remote. This is the default option.  |
|| _Local_ | Use joysticks that are connected to the computer running the Editor. |
| __Version Control__|||
| __Mode__|| Choose the visibility of meta files. You can use Unity in conjunction with most common [version control tools](VersionControl), including Perforce and PlasticSCM. Default is _Hidden Meta Files_. <br/> For more information on showing or hiding meta files, see [Visible or hidden meta files](http://answers.unity3d.com/questions/932348/visible-or-hidden-meta-files-with-git.html) at Unity Answers. |
|| _Hidden Meta Files_ | Hide meta files. This is the default option. |
|| _Visible Meta Files_ | Display meta files. This is useful when using version control, because it allows other users and machines to view these meta files. |
|| _Perforce_ | Use Perforce version control system. |
|| _PlasticSCM_ | Use PlasticSCM version control system. |
| __Asset Serialization__|||
| __Mode__|| Choose which format to use for storing serialized Assets. This is set to _Force Text_ by default. <br/>Unity uses [serialization](script-Serialization-BuiltInUse) to load and save Assets and AssetBundles to and from your computer’s hard drive. To help with version control merges, Unity can store Scene files in a [text-based format](TextSceneFormat). If you are not merging Scenes, Unity can store Scenes in a more space-efficient binary format, or allow both text and binary Scene files to exist at the same time. |
|| _Mixed_ | Assets in Binary mode remain in Binary mode, and Assets in Text mode remain in Text mode. Unity uses Binary mode by default for new Assets. |
|| _Force Binary_ | Convert all Assets to Binary mode, including new Assets. |
|| _Force Text_ | Convert all Assets to Text mode, including new Assets. This is the default option. |
| __Default Behavior Mode__|||
| __Mode__|| Choose the default [2D or 3D development](2DAnd3DModeSettings) mode. Unity sets up the certain default behaviors according to the mode you choose to make development easier. Default is _3D_. |
|| _3D_ | Set Unity up for 3D development. This is the default option. |
|| _2D_ | Set Unity up for 2D development.  |
| __Prefab Editing Environments__ |||
| __Regular Environment__ || Assign a Scene as an editing environment in Prefab Mode for *regular* Prefabs (that is, Prefabs with a regular [Transform](class-Transform) component). This allows you to edit your Prefab against a backdrop of your choosing rather than an empty Scene.<br />See [Editing a Prefab in Prefab Mode](EditingInPrefabMode) for more information. |
|__UI Environment__|| Assign a Scene as an editing environment in Prefab Mode for *UI* Prefabs (that is, Prefabs with a [Rect Transform](class-RectTransform) component). This allows you to edit your Prefab against a backdrop of your choosing rather than an empty Scene.<br />See [Editing a Prefab in Prefab Mode](EditingInPrefabMode) for more information. |
| __Sprite Packer__|||
| __Mode__|| Choose a mode to configure the [Sprite Packer](SpritePacker) tool. The Sprite Packer tool automates the process of generating [sprite atlases](SpriteAtlas) from individual Sprite Textures. Default is _Disabled_. |
|| _Disabled_ | Unity does not pack Atlases. This is the default setting. |
|| _Enabled For Builds(Legacy Sprite Packer)_ | Unity packs Atlases for builds only, and not in-Editor Play mode. This __Legacy Sprite Packer__ option refers to the Tag-based version of the Sprite Packer, rather than the Sprite Atlas version. |
|| _Always Enabled(Legacy Sprite Packer)_ | Unity packs Atlases for builds, and before entering in-Editor Play mode. This __Legacy Sprite Packer__ option refers to the Tag-based version rather than the Sprite Atlas version. |
|| _Enabled For Builds_ | Unity packs Atlases for builds only, and not in-Editor Play mode. |
|| _Always Enabled_ | Unity packs Atlases for builds and before entering in-Editor Play mode. |
| __Padding Power (Legacy Sprite Packer)__|| Choose the value that the packing algorithm uses when calculating the amount of space or "padding" to allocate between packed Sprites, and between Sprites and the edges of the generated atlas. This setting is only available with the Legacy Sprite Packer. |
|| _1_ | Represents the value 2^1. Use this setting to allocate 2 pixels between packed Sprites and atlas edges. This is the default setting. |
|| _2_ | Represents the value 2^2. Use this setting to allocate 4 pixels between packed Sprites and atlas edges. |
|| _3_ | Represents the value 2^3. Use this setting to allocate 8 pixels between packed Sprites and atlas edges. |
| __C# Project Generation__|||
| __Additional extensions to include__|| Include a list of additional file types to add to the C# Project. Separate each file type with a semicolon. By default, this field contains `txt;xml;fnt;cd`. |
| __Root namespace__|| Fill in the namespace to use for the C# project `RootNamespace` property. See [Common MSBuild Project Properties](https://msdn.microsoft.com/en-us/library/bb629394.aspx) for more information. This field is blank by default. |
| __ETC Texture Compressor__|||
| __Behavior__|| Specify the compression tool to use for different compression qualities of ETC Textures.<br/>The compression tools available are [etcpak](https://bitbucket.org/wolfpld/etcpak/wiki/Home), [ETCPACK](https://github.com/Ericsson/ETCPACK) and [Etc2Comp](https://github.com/google/etc2comp). These are all third-party compressor libraries. |
|| __Legacy__ | Use the configuration that was available before ETC Texture compression became configurable. This sets the following properties: <br/> - __Fast__: ETCPACK Fast <br/> - __Normal__: ETCPACK Fast <br/> - __Best__: ETCPACK Best |
|| _Default_ | Use the default configuration for Unity. This sets the following properties: <br/> - __Fast__: etcpack <br/> - __Normal__: ETCPACK Fast <br/> - __Best__: Etc2Comp Best |
|| _Custom_ | Customize the ETC Texture compression configuration. When you choose this option, the __Fast__, __Normal__, and __Best__ properties are enabled. This maps to the __Compressor Quality __setting in the [Texture Importer](class-TextureImporter) for the supported platforms. |
| __Fast__|| Define the compression quality tool to use for Fast compression. |
| __Normal__|| Define the compression quality tool to use for Normal compression. |
| __Best__|| Define the compression quality tool to use for Best compression. |
| __Line Endings For New Scripts__|||
| __Mode__|| Choose the file line endings to apply to new scripts created within the Editor. Note that configuring these settings does not convert existing scripts. |
|| __OS Native__ | Apply line endings based on the operating system the Editor is running on. |
|| __Unix__ | Apply line endings based on the Unix operating system. |
|| __Windows__ | Apply line endings based on the Windows operating system. |
| __Streaming Settings__|||
| __Enable Texture Streaming in Play Mode__||Enable mipmap Texture streaming in Play Mode. <br/>The [Quality](class-QualitySettings) __Texture Streaming__ setting must also be enabled. |





---

* <span class="page-history">2018-09-28 New Unified Settings updates</span>
* <span class="page-history">2017-11-03 Documentation updated to reflect multiple changes since 5.6</span>
* <span class="page-edit"> 2018-09-28  <!-- include IncludeTextAmendPageYesEdit --></span>
