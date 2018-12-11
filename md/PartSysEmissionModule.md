# Emission module

The properties in this module affect the rate and timing of [Particle System](PartSysWhatIs) emissions.

![](../uploads/Main/PartSysEmissionModule-0.png)

## Properties 

| **Property**| **Function** |
|:---|:---| 
| __Rate over Time__| The number of particles emitted per unit of time. |
| __Rate over Distance__| The number of particles emitted per unit of distance moved. |
| __Bursts__| A burst is an event which spawns particles. These settings allow particles to be emitted at specified times. |
|&nbsp;&nbsp;&nbsp;&nbsp;*Time*| Set the time (in seconds, after the Particle System begins playing) at which to emit the burst. |
|&nbsp;&nbsp;&nbsp;&nbsp;*Count*| Set a value for the number of particles that may be emitted. |
|&nbsp;&nbsp;&nbsp;&nbsp;*Cycles*| Set a value for how many times to play the burst. |
|&nbsp;&nbsp;&nbsp;&nbsp;*Interval*| Set a value for the time (in seconds) between when each cycle of the burst is triggered. |
|&nbsp;&nbsp;&nbsp;&nbsp;*Probability*| Controls how likely it is that each burst event spawns particles. A higher value makes the system produce more particles, and a value of 1 guarantees that the system produces particles. |

## Details

The rate of emission can be constant or can vary over the lifetime of the system according to a curve. If __Rate over Distance__ mode is active, a certain number of particles are released per unit of distance moved by the parent object. This is very useful for simulating particles that are actually created by the motion of the object (for example, dust from a car’s wheels on a dirt track).

If __Rate over Time__ is active, then the desired number of particles are emitted each second regardless of how the parent object moves. Additionally, you can add bursts of extra particles that appear at specific times (for example, a steam train chimney that produces puffs of smoke).

---

* <span class="page-edit"> 2018-10-19  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">Burst probability added to Particle System Emission module in Unity  [2018.3](../Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>