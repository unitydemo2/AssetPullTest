# Managed code stripping

Managed code stripping removes unused code from a build, which can significantly decrease the final build size. When using the IL2CPP scripting backend, managed code stripping can also decrease build time because less code needs to be converted to C++ and compiled. Managed code stripping removes code from managed assemblies, including assemblies built from the C# scripts in your Project, assemblies that are part of packages and plugins, and assemblies in the .NET frameworks. 

Managed code stripping works by statically analyzing the code in a Project to detect classes, members of classes, and even portions of functions that can never be reached during execution. You can control how aggressive Unity prunes unreachable code with the __Managed Stripping Level__ setting on the __Player Settings__ window (in the __Optimization__ section).

__Important:__ When your code (or code in a plugin) looks up classes or members dynamically using reflection, the code stripping tool cannot always detect that the Project is using those classes or members, and might remove them. To declare that a Project is using such code, use [link.xml files](#LinkXML) or  [Preserve](#PreserveAttribute) attributes.

<a name="ManagedStrippingLevels"></a>
## Managed stripping levels

Control how aggressively Unity prunes unused code with the __Managed Stripping Level__ option in the project __Player Settings__.

![Managed Stripping Level setting](../uploads/Main/mgc_StripLevel.png)

__Note:__ The default value of this option varies based on the current __Scripting Backend__ setting. 

| **Property** | **Function** |
|:---|:---| 
| **Disabled**| No code is removed. <br/><br/>This option is the default stripping level for the Mono scripting backend. The Disabled option is not available when the IL2CPP scripting backend is selected because of the impact it has on build times. More managed code means more C++ code for IL2CPP to generate, which means more C++ code to compile. The result is a much longer time between making a code change and seeing that change in action. |
| **Low**| Removes code according to a conservative set of rules that should remove the majority of unreachable code while minimizing the possibility of stripping code that is actually used. Low stripping level favors usability over size reduction.<br/><br/>This option is the default stripping level for IL2CPP (and has been used for many releases of the Unity Editor). |
| **Medium**| Removes code according to a set of rules that strike a balance between Low and High stripping levels. Medium stripping level is less cautious than Low stripping level, but not to the same extreme as High stripping level. As such, the risk of undesirable side effects from removing code is greater than Low stripping level, but lesser than High stripping level.<br/><br/>Use Medium stripping level with the IL2CPP scripting backend to further reduce the iteration time between making a code change and testing it. <br/><br/>Medium stripping level is not available when you use the .NET 3.5 Scripting Runtime Version setting. |
| **High**| Removes as much unreachable code as possible and produces smaller builds than Medium stripping level. High stripping level prioritizes size reduction over usability; you might need add link.xml files, Preserve attributes, or rewrite problematic sections of code.<br/><br/>High stripping level performs a more time-consuming analysis to achieve these additional size reductions, so build and iterations times can be longer than under Medium stripping level.<br/><br/>High stripping level is not available when you use the .NET 3.5 Scripting Runtime Version setting. |

__Note:__ The __Managed Stripping Level__ options do not affect the process that removes unused Unity Engine code (which is available when using the __IL2CPP Scripting Backend__ setting). 

# Understanding managed code stripping

This section describes the details of managed code stripping and how to identify and correct any associated problems that can arise.

When you build a Project in Unity, the build process compiles your C# code to a .NET bytecode format called Common Intermediate Language (CIL). This CIL byte code is packaged into files called assemblies. Likewise, the .NET framework libraries and any C# libraries in the plugins you use in the Project are also pre-packaged as assemblies of CIL bytecode. Ordinarily, the build process includes the entire assembly file, no matter how much or how little of the code in an assembly your Project uses. 

The managed code stripping process analyzes the assemblies in your Project to find and remove code that is not actually used. The analysis uses a set of rules to determine what code to keep and what code to throw away. These rules trade off build size (including too much code) with risk (removing too much code). The [Managed Stripping Level](#ManagedStrippingLevel) setting lets you control how aggressively to remove code.

## UnityLinker

The Unity build process uses a tool called the *UnityLinker* to strip managed code. The UnityLinker is a version of the [Mono IL Linker](https://github.com/mono/linker) customized to work with Unity. The UnityLinker is built on top of our [fork](https://github.com/Unity-Technologies/linker) of the Project, which closely tracks the upstream IL Linker project. (Note that the custom Unity Engine specific parts of the UnityLinker are not maintained in the fork.)

### How the UnityLinker works

The UnityLinker analyzes all the assemblies in your Project. First, it marks the top-level, root types, methods, properties, fields and so on, for example MonoBehaviour-derived classes you add to GameObjects in a Scene are root types. The UnityLinker then analyzes the roots it has marked to identify, and marks any managed code that these roots depend upon. Upon completion of this static analysis, any remaining unmarked code is unreachable by any execution path through your application code and is deleted from the assembly.

Note that this process does not obfuscate code.

## Reflection and code stripping

The UnityLinker cannot always detect instances where code in your Project references other code through [reflection](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection), and can mistakenly remove code that is actually in use. As you raise the __Managed Stripping Level__ from __Low__ to __High__, the risk that code stripping causes an unintended behavior change in your game also increases. Such behavior changes can range from subtle logic changes to a crash caused by calling a missing method.

The UnityLinker can detect and handle some reflection patterns. For examples of the latest patterns that it can handle, see the Mono IL Linker [reflection test suite](https://github.com/mono/linker/tree/master/linker/Tests/Mono.Linker.Tests.Cases/Reflection). However, when you move beyond trivial reflection usage, you must give the UnityLinker some hints about which classes shouldn’t be touched. You can provide these hints in the form of __link.xml__ files and __Preserve__ attributes:

* Preserve attribute — mark elements to preserve directly in source code.
* link.xml file — declare how elements in assemblies should be preserved.

The UnityLinker treats each element preserved with an attribute or link.xml file as a root when it analyzes the assembly for unused code.

<a name="PreserveAttribute"></a>
### Preserve attribute

Use the [[Preserve](ScriptRef:PreserveAttribute.html)] attribute in source code to prevent the UnityLinker from stripping that code. The following list describes what entities the UnityLinker preserves when Preserve is applied to different code elements:


* __Assembly__: Preserves all types in the assembly (as if you put a [Preserve] attribute on each type). To assign the Preserve attribute to an assembly, place the attribute declaration in any C# file included in the assembly, outside any namespace declarations:


        using System;
        using UnityEngine.Scripting;
        
        [assembly: Preserve]
        
        namespace Example
        {
            public class Foo {}
        }

* __Type__: Preserves the type and its default constructor.

* __Method__: Preserves the method, it’s declaring type, return type, and the types of all of its arguments.

* __Property__: Preserves the property, it’s declaring type, value type, the getter method, and the setter method.

* __Field__: Preserves the field, it’s declaring type, and the field type.

* __Event__: Preserves the event, it’s declaring type, return type, the add method, and the remove method.

* __Delegate__: Preserves the delegate type and all of it’s methods.

Note that marking a code entity in a link.xml file gives you a bit more control than when using a Preserve attribute. For example, decorating a class with the Preserve attribute preserves both the type and the default constructor. With a link.xml file, you can choose to keep only the type (without the default constructor). 

You can define the Preserve attribute in any assembly and in any namespace. So, you can use the UnityEngine.Scripting.PreserveAttribute class, subclass it, or create your own [PreserveAttribute](ScriptRef:PreserveAttribute.html) class, for example:

    class Foo
    {
        [UnityEngine.Scripting.Preserve]
        public void UsingUnityPreserve(){}
    
        [CustomPreserve]
        public void UsingCustomPreserve(){}
    
        [Preserve]
        public void UsingOwnPreserve(){}
    }
    
    class CustomPreserveAttribute : UnityEngine.Scripting.PreserveAttribute {}
    
    class PreserveAttribute : System.Attribute {}

### AlwaysLinkAssembly attribute

Use the [assembly: UnityEngine.Scripting.AlwaysLinkAssembly] attribute to force the UnityLinker to process the assembly regardless of whether or not the assembly is referenced by another assembly that is included in the build. The [AlwaysLinkAssembly](ScriptRef:AlwaysLinkAssemblyAttribute.html) attribute can only be defined on an assembly.

This attribute only instructs the UnityLinker to apply its __Root Marking Rules__ to the assembly. The attribute itself does not directly cause code within the assembly to be preserved.  If no code elements match the root marking rules for the assembly, the UnityLinker still removes the assembly from the build.

Use this attribute on package or precompiled assemblies that contain one or more methods with the [RuntimeInitializeOnLoadMethod] attribute, but which may not contain types used directly or indirectly in any Scenes in a project.

If an assembly defines [assembly: AlwaysLinkAssembly] and is also referenced by another assembly included in the build, the attribute has no effect on the output.

<a name="LinkXML"></a>
### Link XML

A link.xml file is a per-Project list that declares how to preserve assemblies and the types and other code entities within them. To use a link.xml file, create it (see the example below) and place it into the Project Assets folder (or any subdirectory of Assets). You can use any number of link.xml files in a Project, so plugins can provide their own preservation declarations. The UnityLinker treats any assembly, type, or member preserved in a link.xml file as a root type.

Note that link.xml files are not supported inside packages, but you can reference package assemblies from non-package link.xml files.

The following example illustrates the different ways that you can declare the root types of a Project’s assemblies using a link.xml file:


```xml
<linker>
  <!--
  Preserve types and members in an assembly
  -->
  <assembly fullname="Assembly1">
    <!--Preserve an entire type-->
    <type fullname="Assembly1.A" preserve="all"/>

    <!--No "preserve" attribute and no members specified 
        means preserve all members-->
    <type fullname="Assembly1.B"/>

    <!--Preserve all fields on a type-->
    <type fullname="Assembly1.C" preserve="fields"/>

    <!--Preserve all fields on a type-->
    <type fullname="Assembly1.D" preserve="methods"/>

    <!--Preserve the type only-->
    <type fullname="Assembly1.E" preserve="nothing"/>

    <!--Preserving only specific members of a type-->
    <type fullname="Assembly1.F">
        
      <!--
      Fields
      -->
      <field signature="System.Int32 field1" />

      <!--Preserve a field by name rather than signature-->
      <field name="field2" />
      
      <!--
      Methods
      -->
      <method signature="System.Void Method1()" />

      <!--Preserve a method with parameters-->
      <method signature="System.Void Method2(System.Int32,System.String)" />

      <!--Preserve a method by name rather than signature-->
      <method name="Method3" />

      <!--
      Properties
      -->

      <!--Preserve a property, it's backing field (if present), 
          getter, and setter methods-->
      <property signature="System.Int32 Property1" />

      <property signature="System.Int32 Property2" accessors="all" />

      <!--Preserve a property, it's backing field (if present), and getter method-->
      <property signature="System.Int32 Property3" accessors="get" />

      <!--Preserve a property, it's backing field (if present), and setter method-->
      <property signature="System.Int32 Property4" accessors="set" />

      <!--Preserve a property by name rather than signature-->
      <property name="Property5" />

      <!--
      Events
      -->

      <!--Preserve an event, it's backing field (if present), 
          add, and remove methods-->
      <event signature="System.EventHandler Event1" />

      <!--Preserve an event by name rather than signature-->
      <event name="Event2" />

    </type>

    <!--Examples with generics-->
    <type fullname="Assembly1.G`1">

      <!--Preserve a field with generics in the signature-->
      <field signature="System.Collections.Generic.List`1&lt;System.Int32&gt; field1" />

      <field signature="System.Collections.Generic.List`1&lt;T&gt; field2" />

      <!--Preserve a method with generics in the signature-->
      <method signature="System.Void Method1(System.Collections.Generic.List`1&lt;System.Int32&gt;)" />

      <!--Preserve an event with generics in the signature-->
      <event signature="System.EventHandler`1&lt;System.EventArgs&gt; Event1" />

    </type>

    <!--Preserve a nested type-->
    <type fullname="Assembly1.H/Nested" preserve="all"/>

    <!--Preserve all fields of a type if the type is used.  If the type is not 
        used it will be removed-->
    <type fullname="Assembly1.I" preserve="fields" required="0"/>

    <!--Preserve all methods of a type if the type is used.  
        If the type is not used it will be removed-->
    <type fullname="Assembly1.J" preserve="methods" required="0"/>

    <!--Preserve all types in a namespace-->
    <type fullname="Assembly1.SomeNamespace*" />

    <!--Preserve all types with a common prefix in their name-->
    <type fullname="Prefix*" />

  </assembly>
  
  <!--Preserve an entire assembly-->
  <assembly fullname="Assembly2" preserve="all"/>

  <!--No "preserve" attribute and no types specified means preserve all-->
  <assembly fullname="Assembly3"/>

  <!--Fully qualified assembly name-->
  <assembly fullname="Assembly4, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null">
    <type fullname="Assembly4.Foo" preserve="all"/>
  </assembly>

  <!--Force an assembly to be processed for roots but don’t explicitly preserve 
      anything in particular.  Useful when the assembly is not referenced.-->
  <assembly fullname="Assembly5" preserve="nothing"/>

</linker>
```

#### Special Assembly XML attributes

The &lt;assembly&gt; element of the link.xml file has three special-purpose attributes:

* __ignoreIfMissing__
    By default, the UnityLinker aborts the build if an assembly referenced in a link.xml file cannot be found. If you need to declare preservations for an assembly that does not exist during all Player builds, use the ignoreIfMissing attribute on the  &lt;assembly&gt; element in the link.xml file:

    ```xml
    <linker>
      <assembly fullname="Foo" ignoreIfMissing="1">
        <type name="Type1"/>
      </assembly>
    </linker>
    ```

* __ignoreIfUnreferenced__

    In some cases, you might want to preserve entities in an assembly only when that assembly is referenced by another assembly. Use the ignoreIfUnreferenced attribute on the &lt;assembly&gt; element in the link.xml file to only preserve the entities in an assembly when at least one type is referenced in an assembly.

    ```xml
    <linker>
      <assembly fullname="Bar" ignoreIfUnreferenced="1">
        <type name="Type2"/>
      </assembly>
    </linker>
    ```

    __Note:__ It does not matter whether the code in the referencing assembly was itself stripped or not, the specified elements of the referenced assembly with this attribute are still preserved.

* __windowsruntime__

    When defining preservations for a Windows Runtime Metadata (.winmd) assembly, you must add the windowsruntime="true" attribute to the &lt;assembly&gt; element in the link.xml file:

    ```xml
    <linker>
      <assembly fullname="Windows" windowsruntime="true">
        <type name="Type3"/>
      </assembly>
    </linker>
    ```

## How the UnityLinker strips assemblies

The Unity Editor colates a list of the assemblies containing types used in any of the Scenes in your Unity Project and passes it to the UnityLinker. The UnityLinker then process those assemblies, any references of those assemblies, any assemblies declared in a link.xml file, and any assembly with the AlwaysLinkAssembly attribute. In general, any assembly included in the Project that does not fall under one of these categories will not be processed by the UnityLinker and not included in the Player build.

For each assembly the UnityLinker processes, it follows a set of rules based on the classification of the assembly, whether the assembly contains types used in a Scene, and the __Managed Stripping Level__ you have selected for the build. 

For the purpose of these rules, assemblies fall into the following classifications:


* __.NET Class Library assemblies__ — Includes the Mono class libraries such as mscorlib.dll and System.dll, as well as .NET class library facade assemblies like netstandard.dll.

* __Platform SDK assemblies__ — Includes the managed assemblies specific to a platform SDK. For example, the windows.winmd assembly that is part of the Universal Windows Platform SDK.

* __Unity Engine Module assemblies__ — Includes the managed assemblies that make up the Unity Engine, such as UnityEngine.Core.dll.

* __Project assemblies__ — Includes the assemblies specific to a project such as:

    * Script assemblies such as Assembly-CSharp.dll

    * Precompiled assemblies

    * [Assembly Definition Assemblies](ScriptCompilationAssemblyDefinitionFiles)

    * Package assemblies

The following sections detail how the UnityLinker marks and preserves or strips assembly code for each __Managed Stripping Level__ setting:

* [Low Stripping Level](#LowStrippingLevel)
* [Medium Stripping Level](#MediumStrippingLevel)
* [High Stripping Level](#HighStrippingLevel)

<a name="LowStrippingLevel"></a>
## Low Stripping Level

When you select the __Low__ __Managed Stripping Level,__ the UnityLinker removes code according to a conservative set of rules that should remove the majority of unreachable code while minimizing the possibility of stripping code that is actually used. __Low__ stripping level favors usability over size reduction.

### Low root marking rules

The root marking rules determine how the UnityLinker identifies the top-level types in an assembly.

| **Assembly Type**| **Action** | **Root Marking Rules** |
|:---|:---|:---| 
| .NET Class & Platform SDK| Strip | Apply precautionary preservations |
| |  | Preservations defined in any link.xml |
| Assemblies containing types used in a scene| Copy | Marks all types and members in the assembly  |
| All other | Strip | Marks all public types |
| |  | Marks all public members of public types |
| |  | Marks methods which have the [RuntimeInitializeOnLoadMethod] attribute |
| |  | Marks types and members which have the [Preserve] attribute |
| |  | Preservations defined in any link.xml |
| |  | Marks all types derived from MonoBehaviour and ScriptableObject in:<br/><br/>Precompiled Assemblies<br/><br/>Package Assemblies<br/><br/>Assembly Definition Assemblies<br/><br/>Unity Script Assemblies |
| Test | Strip | Marks methods with any Attribute defined in the NUnit.Framework.  For example: [Test] |
| |  | Marks methods with the [UnityTest] attribute |


__Note:__ The __Strip__ action means that the UnityLinker analyzes the assembly for code that can be removed. The __Copy__ action means that the UnityLinker copies the entire assembly to the final build (as well as marking all types within it as root types).

### Low dependency marking rules

Once the root types have been marked, UnityLinker performs a static analysis to identify any code that these roots depend on.

| **Rule Target** | **Description** |
|:---|:---| 
| Unity Types| When the UnityLinker marks a type derived from MonoBehaviour, it also marks all the members of the type. |
| | When the UnityLinker marks a type derived from ScriptableObject, it also marks all the members of the type. |
| Attributes| The UnityLinker marks any attributes on all marked assemblies, types, methods, fields, properties, and so on. |
| Debugging Attributes| When you enable script debugging, the UnityLinker marks any members having the [DebuggerDisplay] attribute, even if there is no code path that makes use of the member. |
| .NET Facade Class Library Assembly| Facade assemblies are assemblies in the .NET class libraries that forward type definitions to another assembly.  For example, the `netstandard.dll`, part of the .NET Standard 2.0 API Compatibility Level, is a facade assembly that defines the .NET interface, but forwards the implementation of that interface to other .NET assemblies.<br/><br/>Facade assemblies are not strictly necessary at run time, however, since you can write reflection code that depends on them, the Low stripping level retains these assemblies. |

#### DebugDisplay Attribute example

In the following example, assume you do not use the property,  `Foo.UnusedProperty` anywhere in your code. Normally, the UnityLinker would strip the property, but when you enable script debugging, it marks `Foo.UnusedProperty` and preserves it because of the [DebuggerDisplay] attribute on `Foo`.


```
[DebuggerDisplay("{UnusedProperty}")]
class Foo
{
    public int UnusedProperty { get; set; }
}
```

<a name="MediumStrippingLevel"></a>
## Medium Stripping Level

When you select the __Medium__ __Managed Stripping Level,__ UnityLinker removes code according to a set of rules that strike a balance between __Low__ and __High__ stripping levels. __Medium__ stripping level is less cautious than __Low__ stripping level, but not to the same extreme as __High__ stripping level. As such, the risk of undesirable side effects from removing code is greater than __Low__ stripping level, but lesser than __High__ stripping level.

### Medium root marking rules

| **Assembly Type** | **Action** | **Root Marking Rules** |
|:---|:---|:---| 
| .NET Class & Platform SDK| Strip | Same as Low stripping level except: Does NOT apply precautionary preservations |
| Assemblies with types referenced in a scene| Strip | Does NOT automatically mark all types and members in the assembly |
| |  | Marks methods which have the [RuntimeInitializeOnLoadMethod] attribute |
| |  | Marks types and members which have the [Preserve] attribute |
| |  | Preservations defined in any link.xml |
| |  | Marks all types derived from MonoBehaviour and ScriptableObject in:<br/><br/>Precompiled Assemblies<br/><br/>Package Assemblies<br/><br/>Assembly Definition Assemblies<br/><br/>Unity Script Assemblies |
| All other| Strip | Same as Low stripping level except:<br/><br/>Public types are NOT automatically marked<br/><br/>Public members of public types are NOT automatically marked |
| Test| Strip | Same as Low stripping level |


### Medium dependency marking rules

| **Rule Target** | **Description** |
|:---|:---| 
| Unity Types| Same as Low stripping level |
| Attributes| Same as Low stripping level |
| Debugging Attributes| Same as Low stripping level |
| .NET Facade Class Library Assembly| Same as Low stripping level |


<a name="HighStrippingLevel"></a>
## High Stripping Level

When you select the __High__ __Managed Stripping Level,__ UnityLinker removes as much unreachable code as possible and produces smaller builds than __Medium__ stripping level. __High__ stripping level prioritizes size reduction over usability; you might need add link.xml files, __Preserve__ attributes, or even rewrite problematic sections of code.

### High root marking rules

| **Assembly Type** | **Action** | **Root Marking Rules** |
|:---|:---|:---| 
| .NET Class & Platform SDK| Strip | Same as Medium stripping level |
| Assemblies with types referenced in a scene| Strip | Same as Medium stripping level |
| All other| Strip | Same as Medium stripping level |
| Test| Strip | Same as Low stripping level |


#### Link XML feature tag exclusions

[Link.xml](#LinkXML) files support an uncommonly used "features" XML attribute. For the example, the mscorlib.xml file embedded in mscorlib.dll uses this attribute, but you can use it in any link.xml file, when appropriate. 

During __High__ level stripping, the UnityLinker excludes preservations for features that are not supported based on the settings for the current build:

* remoting — Excluded when targeting the IL2CPP scripting backend.
* sre — Excluded when targeting the IL2CPP scripting backend.
* com — Excluded when targeting platforms that do not support COM.

For example, the following link.xml file preserves one method of a type on platforms that support COM, and one method on all platforms:


```xml

<linker>
    <assembly fullname="Foo">
        <type fullname="Type1">
            <!--Preserve FeatureOne on platforms that support COM-->
            <method signature="System.Void FeatureOne()" feature="com"/>
            <!--Preserve FeatureTwo on all platforms-->
            <method signature="System.Void FeatureTwo()"/>
        </type>
    </assembly>
</linker>

```

### High dependency marking rules

| **Rule Target** | **Description** |
|:---|:---| 
| Unity Types| Same as Low stripping level |
| Attributes| On all marked assemblies, types, and members, the UnityLinker marks attributes if the attribute type was also marked.<br/><br/>Note that the UnityLinker always preserves certain attributes because the runtime requires them.<br/><br/>The UnityLinker removes Security related attributes such as System.Security.Permissions.SecurityPermissionAttribute from all assemblies, types, and members. |
| Debugging Attributes| The UnityLinker always removes debugging attributes such as DebuggerDisplayAttribute and DebuggerTypeProxyAttribute. |
| .NET Facade Class Library Assembly| Unlike the Low and Medium stripping levels, which retain all .NET facade assemblies, High stripping level removes all facades since they are not needed at runtime.<br/><br/>Reflection code that assumes facade assemblies exist after stripping will not work. |



### Editing of method bodies

When you set the __High__ stripping level, the UnityLinker edits method bodies in order to further reduce code size. This section summarizes some of the notable edits that the UnityLinker makes to method bodies. 

The UnityLinker currently only edits method bodies in the .NET Class Library assemblies. Note that after method body editing, the source code of the assembly no longer matches the compiled code in the assembly, which can make debugging more difficult.

#### Remove unreachable branches

The UnityLinker removes If-statement blocks that check `System.Environment.OSVersion.Platform` and are not reachable for the currently targeted platform.

#### Inlining - Field access only methods

The UnityLinker replaces calls to methods that get or set a field with direct access to the field. This often makes it possible to strip away the method entirely, helping to reduce size.

When targeting the Mono backend, the UnityLinker only makes this change when the caller of the method is allowed to directly access the field, based on the field’s visibility.  For IL2CPP, visibility rules do not apply, so the UnityLinker makes this change where appropriate.

#### Inlining - Const return value methods

The UnityLinker inlines calls to methods that simply return a const value.

<a name="EmptyCalls"></a>
#### Empty non-returning call removal

The UnityLinker removes calls to methods that are empty and have a `void` return type.

#### Empty scope removal

The UnityLinker removes Try/Finally blocks when the Finally block is empty. Removing [empty calls](#EmptyCalls) can create empty Finally blocks. When that happens during method editing, UnityLinker removes the entire Try/Finally block.  One scenario where this can occur is when the compiler generates Try/Finally blocks as part of foreach loops in order to call `Dispose()`.

