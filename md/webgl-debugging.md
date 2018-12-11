#Debugging and troubleshooting WebGL builds

Visual Studio does not support debugging Unity WebGL content. To help you to find out exactly what's going on with your content, here are some tips on how to get information out of your build.

## The browser's JavaScript console

Unity WebGL does not have access to your file system, so it does not write a log file like other platforms. However, it does write all logging information (such as `Debug.Log`, `Console.WriteLine` or Unity's internal logging) to the browser's JavaScript console.

To open the JavaScript console:

* In Firefox, press Ctrl-Shift-K on Windows or Command-Option-K on a Mac.
* In Chrome, press Ctrl-Shift-J on Windows or Command-Option-J on a Mac.
* In Safari, go to Preferences &gt; Advanced &gt; Develop, and press Command-Option-C.
* In Microsoft Edge or Internet Explorer, press F12.

## Development builds

For debugging purposes, you might want to make a development build in Unity (open the [Build Settings window](PublishingBuilds) and click the __Development Build__ checkbox). Development builds allow you to connect the profiler, and Unity does not [minify](https://en.wikipedia.org/wiki/Minification_%28programming%29) them, so the emitted JavaScript code still contains human-readable (though [C++-mangled](https://en.wikipedia.org/wiki/Name_mangling#Name_mangling_in_C.2B.2B)) function names. The browser can use these to display stack traces when you run into a browser error, when using `Debug.LogError, or when you throw an exception and exception support is disabled`. Unlike the managed stack traces that can occur when you have full exception support (see below), these stack traces have mangled names, and contain not only managed code, but also the internal UnityEngine code.

## Exception support

WebGL has different levels of exception support (see documentation on [Building for WebGL](webgl-building)). By default, Unity WebGL only supports explicitly thrown exceptions. You can enable __Full__ exception support, which emits additional checks in the IL2CPP-generated code, to catch access to null references and out-of-bounds array elements in your managed code. These additional checks significantly impact performance and increase code size and load times, so you should only use it for debugging.

__Full__ exception support also emits function names to generate stack traces for your managed code. For this reason, stack traces appear in the console for uncaught exceptions and for `Debug.Log` statements. Use `System.Environment.Stacktrace` to get a stack trace string.

## Troubleshooting

### Problem: The build runs out of memory
This is a common problem, especially on 32-bit browsers. For more information on WebGL memory issues and how to fix them, see documentation on [Memory in WebGL](webgl-memory).


### Problem: Files saved to Application.persistentDataPath do not persist
Unity WebGL stores all files that must persist between sessions (such as PlayerPrefs or files saved in persistentDataPath) to the browser IndexedDB. This is an asynchronous API, so you don't know when it's going to complete.

Call the following code to make sure Unity flushes all pending file system write operations to the IndexedDB file system from memory:

```
FS.syncfs(false, function (err) {
    console.log('Error: syncfs failed!');
 });
```

### Error message: Incorrect header check
The browser console log usually prints this error as a result of incorrect server configuration. For more information on how to deploy a release build, see documentation on [Deploying compressed builds](webgl-deploying).

### Error message: Decompressing this format (1) is not supported on this platform
The browser console log prints this error when the content tries to load an AssetBundle compressed using LZMA, which Unity WebGL does not support. Re-compress the AssetBundle using LZ4 compression to solve this problem. For more information on compression for WebGL, see documentation on [WebGL building](https://docs.unity3d.com/Manual/webgl-building.html), particularly the **AssetBundles** section.

 
---

* <span class="page-edit">2018-09-03 <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">MonoDevelop replaced with Visual Studio from 2018.1</span>
