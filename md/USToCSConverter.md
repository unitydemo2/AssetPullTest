# UnityScript to C# converter tool

Unity stopped supporting UnityScript in version 2018.2. This tool helps you to convert your codebase (the scripts within your project) from __UnityScript__ to __C#__. 

The tool handles the majority of the work required to convert your codebase to __C#__ but, it may not handle the entirety of your code base due to some [Limitations](#Limitations). This tool supports Unity 2017.3 ~ 2018.1; you should use 2018.1 for maximum effectiveness.

## Using the converter tool

1. Download the tool [here](https://github.com/Unity-Technologies/unityscript2csharp/releases/latest).

2. Make a backup of your Project.

3. Launch the Unity Editor and allow the APIUpdater to run and update any obsolete API usages. This avoids compilation errors during the conversion.

4. Install the latest Editor Integration Package (You can find the *.**unitypackage* on the release page linked in step 1. See [here](https://docs.unity3d.com/Manual/AssetPackages.html) for instructions on how to install *.unitypackage* files).

5. Navigate to your __Console __window (__Window &gt; General &gt; Console__) and click __Clear__ to remove previous logs, warnings, and errors from the Console.

6. In the Editor, select __Tools &gt; Convert Project from UnityScript to C#__

7. Follow the instructions shown.

8. If there are any remaining compilation errors, manually fix them. Note that any unsupported language construct (an AST node type), will inject a comment in the converted source that includes the piece of code that is not supported and its related source/line information.


Tips:

* You will achieve the best results, and a smoother conversion process, if your codebase scripts have #pragma strict applied to them.

* If your Project targets multiple platforms, you may need to run the conversion for each target platform and manually merge the converted code, wrapping the code with conditional code accordingly. 




### Command line arguments

If you need more control over the conversion options, you can use various command line arguments when running the __UnityScript2CSharp.exe__ application (download the UnityScript2CSharp_xxx.zip file from the [release page](https://github.com/Unity-Technologies/unityscript2csharp/releases/latest)). In this case, you need to pass in the path to the Project (-p), the Unity root installation folder (-u), and any additional assembly references (-r) used by the UnityScript scripts. Here’s a list of the valid command line arguments:

| Argument| Details |
|:---|:---|
| -u, --unityPath| The Unity installation path. This argument is required.  |
| -p, --projectPath| The path of the Project to be converted. This argument is required.  |
| -r, --references| A space-separated list of assembly references that the scripts require. |
| -g, --gameassemblies| A boolean flag to indicate whether the tools should look for previously built assembly references (Assembly-*-firstpass.dll under Library/). |
| -s, –symbols| A comma-separated list of custom symbols to be defined. |
| -o, –deleteOriginals| Delete the original files. By default, the tool renames the original file to .js.old. |
| -d| Dump out the list of scripts being processed. |
| -i| Ignore compilation errors. This allows the conversion process to continue instead of aborting. |
| --skipcomments| The tool will not attempt to preserve comments. Use this option if processing comments causes any issues. The default value is false. |
| --showorphancomments| Show a list of comments that were not written to the converted sources. This helps identify issues with the comment processing code. |
| -v, –verbose| Show verbose messages. |
| -n, –dry-run| Run the conversion but do not change/create any files on disk. |
| –help| Display this help screen. |



### Example use case

Here is an example of running __UnityScript2CSharp.exe on__ a Windows machine with .Net installed:

UnityScript2CSharp.exe -p m:\Work\4-0_AngryBots -u M:\Work\unity -g -s UNITY_ANDROID,UNITY_EDITOR

On Mac OS, you need to install version of [Mono](https://www.mono-project.com/docs/getting-started/install/mac/) and run the tool as:

*myuser$ mono /path/to/converter/UnityScript2CSharp.exe -p ~/AngryBots/ --unityPath /Applications/Unity/*

<a name="Limitations"></a>
## Limitations

* This tool may misplace or not preserve some comments.

* UnityScript parser ignores guarded code (#if …) when the condition evaluates to false, leaving no traces of the original code when you visit the generated AST. The alternative is to run the tool multiple times to make sure it processes all guarded code eventually. Each time you execute the tool, you must merge the generated code manually.

* Type inference in anonymous function declarations are inaccurate in some scenarios and may infer the wrong parameter / return type.

* Converting local variable scope sometimes fails due to the way UnityScript scope works.

* Types with hyphens in the name (for example, `This-Is-Invalid`) are converted without change, which generates errors in C# as they are invalid.

* This tool does not inject missing return values automatically (for example, on a __non void method__, a __return;__ statement will cause a compilation error in the converted code).

* This tool does not support conversion from object to int/long/float/bool, although this is limited support for int to bool conversion in conditional expressions.

* This tool converts `for( init; condition; increment)` to a while loop equivalent.

* Methods with the same name as the declaring class are converted without change and must be manually altered  because they are invalid in C#.

* The C# compiler considers invalid casts using the __as__ keyword as errors.

* Equality comparison against null used as statement expressions generate errors in C# (for example, __foo == null; __in a single statement).

* This tool converts code that changes foreach loop variables (which is not allowed in C#) directly, without any alteration. This means that resulting code will not compile cleanly.

* Unsupported features

    * Property / Event definition

    * Macros

    * Literals

        * Regular expressions

    * Exception handling

    * Format preservation

    * This tool does not support UnityScript.Lang.Array (Array) methods. It converts this type to object[]. This means that, if your scripts rely on the Array methods, you will need to replace the variable declarations / instantiation with some other type, such as a List or a Stack, and then fix the code.

## Questions / Suggestions

If you have questions or suggestions, use this forum thread to comment: [https://forum.unity.com/threads/unityscript-2-csharp-conversion-tool.487753/](https://forum.unity.com/threads/unityscript-2-csharp-conversion-tool.487753/)

## More resources / Information

* [Original Announcement](https://blogs.unity3d.com/pt/2017/08/11/unityscripts-long-ride-off-into-the-sunset/).

* [Tool repository](https://github.com/Unity-Technologies/unityscript2csharp)

---

* <span class="page-edit">2018-10-12  <!-- include IncludeTextNewPageYesEdit --></span>

