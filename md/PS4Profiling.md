# PS4 profiling

This page provides information on how to connect your PS4 build to the Unity profiler, and other ways of profiling your build. See documentation on the [Unity Profiler](https://docs.unity3d.com/Manual/Profiler.html) for a comprehensive overview of the built-in profiler.

Connect your build to the Unity Profiler via the following steps:

1. Build and run a development build on the target machine (see documentation on [Building and running PS4 builds](PS4BuildingampRunning) to learn how to do this). Profiling can only be carried out on development builds; master builds cannot be profiled.

2. In the Unity Editor, navigate to __Windows__ &gt; __Analysis__ &gt; __Profiler__.

3. Open the __Active Profiler__ drop-down and select __PS4 Player__. Multiple listings of this appear if you have several devkits active on your network, so make sure you choose the IP address appropriate to your target.

The Profiler is now connected to the build, and you can begin profiling.

As an alternative to step 3, you can tick the __Autoconnect Profiler__ checkbox in __Build Settings__. This automatically connects the profiler as soon as the build is launched on the target machine.

For help connecting the Unity Profiler to a PS4 device, see [Troubleshooting connection issues](PS4TroubleShooting#profiler).

## PlayStation 4 SDK tools

PlayStation 4 development gives you access to several high quality tools to allow you to profile your title during development. We highly recommend that you use these tools during PS4 development.

### Razor CPU

This tool allows you to perform captures of your build’s CPU activity, and then store and re-read that data. Because the information is not displayed in real-time during profiling, there is very little overhead in the captured data, resulting in a more accurate assessment of where CPU time is being spent. For more information, see documentation on [Profiling with Razor](PS4ProfilingWithRazor) and the [Razor CPU user's guide](https://ps4.siedev.net/resources/documents/SDK/latest/Razor_CPU-Users_Guide/__document_toc.html) ([https://ps4.siedev.net](https://ps4.siedev.net)).

### Razor GPU

This is a performance analysis and debugging tool that allows you to analyze GPU captures. For more information, see the [Razor GPU user's guide](https://ps4.siedev.net/resources/documents/SDK/latest/Razor_GPU-Users_Guide/__document_toc.html) ([https://ps4.siedev.net](https://ps4.siedev.net)).

### Memory Analyzer

The PlayStation 4 Memory Analyzer allows the tracking of allocations and de-allocations of memory to help in finding areas within your title where memory usage may be high, and also help find any potential memory leaks. For more information, see the [Memory Analyzer User's Guide](https://ps4.siedev.net/resources/documents/SDK/latest/Memory_Analyzer-Users_Guide/__document_toc.html) ([https://ps4.siedev.net](https://ps4.siedev.net)).

---
<span class="page-edit"> 2018-02-28  <!-- include IncludeTextNewPageSomeEdit --></span>