# Razor: CPU Live

**Razor CPU Live** allows you to see profiling data in real time, similar to the real-time views in [Unity CPU profiler](ProfilerCPU) but with additional information provided by the system.

Razor CPU Live is suitable for longer capture sessions, for example an entire gameplay session could be recorded. Use it in cases where, for example, you can not predict when a spike will happen. You can just leave it recording until you get the event you are interested in.

The tool’s UI is simple and relies on Razor CPU for more in-depth data analysis. For that, you select and export a range of the captured data to Razor CPU, where you can examine it as a regular capture. In order to see the Unity profiler markers in one of these exports, make sure to check "Enable user Traces" option in the toolbar before starting a capture. 

The following screenshot shows a noticeable dip in Frames Per Seconds (or a CPU spike) during a gameplay session. A range including the dip is already selected to be exported to Razor CPU for further investigation. 

![](../uploads/Main/PS4ProfilingWithRazor-CPULive-0.png)

For more information, see the [Razor CPU Live User’s Guide](https://ps4.siedev.net/resources/documents/SDK/5.000/Razor_Live-Users_Guide/__document_toc.html).

---

<span class="page-edit"> 2018-02-23  <!-- include IncludeTextAmendPageNoEdit --></span>