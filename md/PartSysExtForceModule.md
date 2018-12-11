#External Forces module

This property modifies the effect of __wind zones__ and [Particle System Force Fields](class-ParticleSystemForceField) on particles emitted by the system.

![](../uploads/Main/PartSysExtForcesInsp.png)

![](../uploads/Main/PartSysExtForcesInspList.png)

##Properties

|**_Property_** |**_Function_** |
|:---|:---|
|__Multiplier__ |Scale value applied to wind zone forces. |
|__Influence Filter__ |Choose whether to include Force Fields based on a __Layer Mask__, or via an explicit __List__. |
|__List__ |Define an explicit list of Force Fields that can affect this Particle System. This appears when the __Influence Filter__ is set to __List__.|
|__Influence Mask__ |Use a Layer Mask to determine which Force Fields affect this Particle System. This appears when the __Influence Filter__ is set to __Layer Mask__. <br/> This is set to __Everything__ by default, but you can enable or disable the following options individually:<br/>- __Nothing__ (automatically unticks all other options, turning them off)<br/>- __Everything__ (automatically ticks all other options, turning them on)<br/>- __Default__ <br/>- __TransparentFX__ <br/>- __Ignore [Raycast](Raycasters)__<br/> - __Water__ <br/> - __UI__ <br/> - __[PostProcessing](PostProcessingOverview)__ ||


##Details

To get the best results out of this feature, create separate GameObjects with [ParticleSystemForceFields](class-ParticleSystemForceField) components.

A __Terrain__ can incorporate _wind zones_ which affect the movement of trees on the landscape. Enabling this section allows the wind zones to blow particles from the system. The _Multiplier_ value lets you scale the effect of the wind on the particles, since they will often be blown more strongly than tree branches.

---

* <span class="page-edit"> 2018-10-19  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Influence Filter and Influence Mask added to Particle System in   [2018.3](../Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>