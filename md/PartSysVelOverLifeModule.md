#Velocity over Lifetime module

The __Velocity over Lifetime__ module allows you to control the velocity of particles over their lifetime.

![](../uploads/Main/PartSysVelOverLifeInsp.png)

##Properties

|**Property** |**Function** |
|:---|:---|
|__Linear X, Y, Z__ |Linear velocity of particles in the X, Y and Z axes. |
|__Space__ |Specifies whether the __Linear X, Y, Z__ axes refer to local or world space. |
|__Orbital X, Y, Z__ |Orbital velocity of particles around the X, Y and Z axes. |
|__Offset X, Y, Z__ |The position of the center of orbit, for orbiting particles. |
|__Radial__ |Radial velocity of particles away from/towards the center position. |
|__Speed Modifier__ |Applies a multiplier to the speed of particles, along/around their current direction of travel. |

##Details

To create particles that drift in a particular direction, use the Linear X, Y and Z curves.

To create effects with particles that spin around a center position, use the __Orbital__ velocity values. Additionally, you can propel particles towards or away from a center position using the __Radial__ velocity values. You can define a custom center of rotation for each particle by using the __Offset__ value.

You can also use this module to adjust the speed of the particles in the Particle System without affecting their direction, by leaving all the above values at zero and only modifying the __Speed Modifier__ value.

---

* <span class="page-edit">2018-03-28  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Speed Modifier property added to Velocity over Lifetime module in [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) <span class="search-words">NewIn20173</span></span>

* <span class="page-history">Orbital XYZ, Offset XYZ and Radial properties added to Velocity over Lifetime module in [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) <span class="search-words">NewIn20181</span></span>

