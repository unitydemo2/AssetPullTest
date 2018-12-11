# The UXML format

UXML files are text files that define the logical structure of the user interface. The format used in UXML files is inspired by HTML (HyperText Markup Language), XAML (eXtensible Application Markup Language), and XML (eXtensible Markup Language). If you are familiar with these recognized formats, you should notice lots of similarities in UXML. However, the UXML format includes small differences to provide an efficient way to work with Unity.

This section describes the UXML format supported by Unity and provides details on writing, loading, and defining UXML templates. It also includes information on defining new elements, and how to use UQuery.

UXML makes it is easier for less technical users to build user interface within Unity. UXML allows you to: 

- define the structure of the user interface (UI) in XML
- define the UI layout with USS stylesheets

This leaves developers to do technical tasks, such as importing assets, defining logic, and processing data.

# Defining new elements

UIElements is extensible. You can define your own user interface components and elements.

But before you can use UXML files to define new elements, you must derive a new class from `VisualElement` or one of its subclass, then implement the appropriate functionnality within this new class. Your new class must implement a default constructor.

For example, the following code derives the new `StatusBar` class and implements its default constructor:

```
class StatusBar : VisualElement
{
    public StatusBar()
    {
        m_Status = String.Empty;
    }

    string m_Status;
    public string status { get; }
}
```

In order for the UIElements to be able to instantiate a new class when reading a UXML file, you must define a factory for your class. Unless your factory needs to do something special, you can derive the factory from `UxmlFactoy<T>`. It is also recommended that you put the factory class within your component class.

For example, the following code demonstrates how to define a factory for the `StatusBar` class by deriving its factory from `UxmlFactory<T>`. The factory is named `Factory`: 

```
class StatusBar : VisualElement
{
    public new class Factory : UxmlFactory<StatusBar> {}

    // ...
}
```

With this factory defined, you are able to use the `<StatusBar>` element in UXML files.

**Note**: Factories were improved in 2018.2. If you defined factories in prior versions, you should port them to 2018.3 to avoid APIs that are now obsolete.

## Defining attributes on elements

You can define UXML traits for a new class and set its factory to use these traits.

For example, the follow code demonstrates how to define a UXML traits class to initialize the `status` property as a property of the `StatusBar` class. The status property is initialized from XML data.

```
class StatusBar : VisualElement
{
    public new class Factory : UxmlFactory<StatusBar, UxmlTraits> {}

    public new class Traits : base.UxmlTraits
    {
        UxmlStringAttributeDescription m_Status = new UxmlStringAttributeDescription { name = "status" };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break; }
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            ((StatusBar)ve).status = m_Status.GetValueFromBag(bag, cc);
        }
    }

    // ...
}
```

The `UxmlTraits` serves two purposes: 

- It is used by the factory to initialize the newly created object.

- It is analyzed by the schema generation process to get information about the element. This information is translated into XML schema directives.


The code example above does the following:  

- The declaration of `m_Status` defines an XML attribute named `status`.
- The `uxmlChildElementsDescription` returns an empty `IEnumerable` which indicates that `StatusBar` element has no child,
- The `Init()` member reads the value of the `status` attribute in a property bag from the XML parser and sets the `StatusBar.status` property to this value. 
- By placing the `UxmlTraits` class inside the `StatusBar` class allows the `Init()` method to access the private members of `StatusBar`.
- The new `UxmlTraits` class inherits from the base class `UxmlTraits`, so it shares the attributes of the base class.
- `Init()` calls `base.Init()` to initialize the base class properties.

The code example above declares a string attribute with the `UxmlStringAttributeDescription` class. UIElements supports the following types of attributes and each links a C# type to an XML type:

- `UxmlStringAttributeDescription`: the attribute value is a string
- `UxmlFloatAttributeDescription`: the attribute value must be a single precision floating point value in the range of the C# `float` type.
- `UxmlDoubleAttributeDescription`: the attribute value must be a double precision floating point value in the range of the C# `double` type.
- `UxmlIntAttributeDescription`: the attribute value must be a
  integer value in the range of the C# `int` type.
- `UxmlLongAttributeDescription`: the attribute value must be a
  long integer value in the range of the C# `long` type.
- `UxmlBoolAttributeDescription`: the attribute value must be
  `true` or `false`.
- `UxmlColorAttributeDescription`: the attribute value must be a string
  representing a color (`#FFFFFF`).
- `UxmlEnumAttributeDescription<T>` the attribute value must be a string
  representing one of the values for the `Enum` type `T`.

In the code example above, the `uxmlChildElementsDescription` returns an empty `IEnumerable` which indicates that the `StatusBar` element does not accept children.

To have an element accept children of any type, you must override the  `uxmlChildElementsDescription` property. For example, for the `StatusBar` element to accept children of any type, the
 `uxmlChildElementsDescription` property must be specified as follows:

```
public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
{
    get
    {
        yield return new UxmlChildElementDescription(typeof(VisualElement));
    }
}
```



## Defining a namespace prefix

Once you have defined a new element in C#, you can start using the element in your UXML files. If your new element is defined in a new namespace, you should define a prefix for the namespace. Namespace prefixes are declared as attributes to the root `<UXML>` element and replace the full namespace name when scoping elements.

To define a namespace prefix, add a `UxmlNamespacePrefix` attribute to your assembly for each namespace prefix you want to define.

```
[assembly: UxmlNamespacePrefix("My.First.Namespace", "first")]
[assembly: UxmlNamespacePrefix("My.Second.Namespace", "second")]
```

This can be done at the root level (outside any namespace) of any C# file of the assembly.

The schema generation system does the following:

- checks for these attributes and uses them to generate the schema. 
- adds the namespace prefix definition as an attribute of the `<UXML>` element in newly created UXML files
- includes the schema file location for the namespace in its `xsi:schemaLocation` attribute.

You should update the UXML schema of your project. Select Assets > Update UIElements Schema to ensure that your text editor recognizes the new element.



## Advanced usage

### Customizing a UXML name

You can customize a UXML name by overrriding its `IUxmlFactory.uxmlName` and `IUXmlFactory.uxmlQualifiedName` properties. Make sure the `uxmlName` is unique within your namespace and that the `uxmlQualifiedName` is unique in your project. 

If both names are not unique, an exception is thrown when you attempt to load your assembly.

The following code example demonstrates how to override and custom the UXML name:

```
public class FactoryWithCustomName : UxmlFactory<..., ...>
{
    public override string uxmlName
    {
        get { return "UniqueName"; }
    }

    public override string uxmlQualifiedName
    {
        get { return uxmlNamespace + "." + uxmlName; }
    }
}
```



### Selecting a factory for an element

By default, the `IUxmlFactory` instantiates an element and selects the element using the name of the element. 

You can make the selection process consider attribute values on the element by overriding `IUXmlFactory.AcceptsAttributeBag`. The factory will then examine the element attributes to decide if it can instantiate an object for the UXML element. 

This is useful if, for example, your `VisualElement` class is generic. In this case, the class factory for a specialization of your class could examine the value of a XML `type` attribute. Depending on the value, instantiation could be accepted or refused. See the implemenatation of `PropertyControl<T>` for an example.

In the case where more than one factory can instantiate an element, the first registered factory is selected.

### Overriding the default value of a base class attribute

You can change the default value of an attribute declared in a base class by setting its `defaultValue` in the derived `UxmlTraits` class.

For example, the following code shows how to set the change the default value of `m_focusIndex`:

```
class MyElementTraits : VisualElementUxmlTraits
    {
        public Traits()
        {
            m_focusIndex.defaultValue = 0;
        }
    }
```

### Accepting any attribute

By default, the generated XML schema states that an element can have any attribute. 

Values of attributes, other than those declared in the `UxmlTraits` class, are not restricted. This is in contrast to XML validators that check that the value of a declared attribute matches its declaration.

Additional attributes are included in the `IUxmlAttributes` bag that is passed to the `IUxmlFactory.AcceptsAttributBag()` and `IUxmlFactory.Init()` functions. It is up to the factory implementation whether to use these additional attributes. The default behavior is to discard additonal attributes. 

This means that these additional attributes are not attached to the instantiated `VisualElement` and these atttibutes are not queryable with `UQuery`.

When defining a new element, you can restrict the accepted attributes to those explicitly declared by setting the `UxmlTraits.canHaveAnyAttribute` property to `false` in your `UxmlTraits` constructor.


# Using Schema definitions

Schema definition files specify the attributes and which child elements each UXML element can contain. Use schema definition files as a guide for writing correct documents and to validate your documents. 

In the UXML template file, the `xsi:noNamespaceSchemaLocation` and `xsi:schemaLocation` attributes of the `<UXML>` root element specify where the schema definition files are located. 

Select **Assets** > **Create** > **UIElements View** menu item to automatically update your schema definition with the latest information gathered from the `VisualElement` sub-classes used by your project. To force an update of the UXML schema files, select **Assets** > **Update UIElements Schema**.

**Note**: Some text editors do not recognize the  `xsi:noNamespaceSchemaLocation`  attribute. If your text editor cannot find the schema definition files, you should also specify the `xsi:schemaLocation` attribute.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>


