# Attributes

__Attributes__ are markers that can be placed above a class, property or function in a script to indicate special behaviour. For example, you can add the `HideInInspector` attribute above a property declaration to prevent the Inspector from showing the property, even if it is public. C# contains attribute names within square brackets, like so:

````
[HideInInspector]
public float strength;
````

Unity provides a number of attributes which are listed in the API Reference documentation:

* For UnityEngine attributes, see [AddComponentMenu](ScriptRef:AddComponentMenu.html) and sibling pages
* For UnityEditor attributes, see [CallbackOrderAttribute](ScriptRef:CallbackOrderAttribute.html) and sibling pages

There are also attributes defined in the .NET libraries which might sometimes be useful in Unity code. See [Microsoft's documentation on Attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/) for more information.

**Note:** Do not use the [ThreadStatic](http://msdn.microsoft.com/en-us/library/system.threadstaticattribute.aspx) attribute defined in the .NET library; it causes a crash if you add it to a Unity script.

