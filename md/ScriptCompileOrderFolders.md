#Special folders and script compilation order

Unity reserves some project folder names to indicate that the contents have a special purpose. Some of these folders have an effect on the order of script compilation. These folder names are: 

* Assets
* Editor
* Editor default resources
* Gizmos
* Plugins
* Resources
* Standard Assets
* StreamingAssets

See [Special folder names](SpecialFolders) for more information about these folders.

## Predefined assemblies

Unity compiles scripts in four separate phases, based on where the script file is located within the project folder structure. Unity creates a separate CSharp project file (.csproj) and a predefined assembly for each phase. (If there are no scripts eligible for a compilation phase, Unity does not create the corresponding project file or assembly.)

Compilation order is significant when a script references a class compiled in a different phase (and therefore located in a different assembly). The basic rule is that anything that is compiled in a phase *after* the current one cannot be referenced. Anything that is compiled in the current phase or an earlier phase is fully available.

The phases of compilation are as follows:

| **Phase** | **Assembly name** | **Script files** |
|:--- |:--- |:--- |
| 1 | Assembly-CSharp-firstpass | Runtime scripts in folders called Standard Assets, Pro Standard Assets and Plugins. |
| 2 | Assembly-CSharp-Editor-firstpass | Editor scripts in folders called Editor that are anywhere inside top-level folders called Standard Assets, Pro Standard Assets and Plugins.|
| 3 | Assembly-CSharp | All other scripts that are not inside a folder called Editor.|
| 4 | Assembly-CSharp-Editor | All remaining scripts (those that are inside a folder called Editor. |

**Note:** Standard Assets work only in the __Assets__ root folder.

You can organize the scripts in your project using your own assemblies by creating assembly definition files. Defining your own assemblies can reduce the amount of code that needs to be recompiled when you make an unrelated code change and can provide more control over dependencies to other assemblies. See [Script Compilation - Assembly Definition Files](ScriptCompilationAssemblyDefinitionFiles.html) for more information.

