Universal Windows Platform: Profiler
=======================


You can connect Unity's profiler to running Universal Windows Application. 
Perform the following steps:

* Open the __Player__ &gt; window and then go to the  __Capabilities__ section on the __Publishing Settings__ panel.
* Enable Private Networks (Client & Server)
* Build Universal Windows App Visual Studio solution from Unity.
* Build and run the application
* If you've checked __Autoconnect Profiler__ checkbox, the profiler should connect automatically to Universal Windows App, if not, you have to explicitly pick it in Unity (__Window__ &gt; __Analysis__ &gt; __Profiler__ &gt; __Active Profiler__), for ex., MetroPlayerX86 (MyDevice)

__Note__: Profiler doesn't work on _Master_ configuration

__Note__: Due Universal Windows Platform restrictions, you won't be able to connect the profiler if the application is running on the same machine. For ex., if you're running Unity editor and Universal Windows Platform on the same PC, you won't able to connect. You have to run Unity editor on one machine, and Universal Windows Platform on another machine. The only exception to this rule is "Autoconnect Profiler" build option, which makes the application connect to the editor instead.

__Note__: Also ensure that machine where Unity Editor is running and machine where Universal Windows App is running - __are on the same subnet__.

---
<span class="page-edit">• 2017-05-16  <!-- include IncludeTextAmendPageNoEdit --></span><br/>