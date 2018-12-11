# Writing UXML Templates

UXML templates are text files written using XML markup that define the logical structure of the user interface. The following code example shows how to define a simple panel that prompts the user to make a choice:

```xml
<?xml version="1.0" encoding="utf-8"?>
<engine:UXML
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:engine="UnityEngine.Experimental.UIElements"
    xsi:noNamespaceSchemaLocation="../UIElementsSchema/UIElements.xsd"
    xsi:schemaLocation="UnityEngine.Experimental.UIElements ../UIElementsSchema/UnityEngine.Experimental.UIElements.xsd">

    <engine:Label text="Select something to remove from your suitcase:"/>
    <engine:Box>
        <engine:Toggle name="boots" label="Boots" value="false" />
        <engine:Toggle name="helmet" label="Helmet" value="false" />
        <engine:Toggle name="cloak" label="Cloak of invisibility" value="false"/>
    </engine:Box>
    <engine:Box>
        <engine:Button name="cancel" text="Cancel" />
        <engine:Button name="ok" text="OK" />
    </engine:Box>
</engine:UXML>
```

The first line of the file is the XML declaration. The declaration is optional, but if it is included, it must be on the first line and no other content or white space can appear before it. The `version` attribute is required, but the `encoding` is optional. If `version` is included, it must represent the character encoding of the file.

The next line defines the document root, `<UXML>`. The  `<UXML>` element includes attributes for the namespace prefix definitions and the location of schema definition files. You can specify these attributes in no partiular order.

In UIElements, each element is defined in either the `UnityEngine.Experimental.UIElements` or the `UnityEditor.Experimental.UIElements` namespace:

- The `UnityEngine.Experimental.UIElements` namespace contains elements that are defined as  part of the Unity Runtime. 
- The `UnityEditor.Experimental.UIElements` namespace contains elements that are available in the Unity Editor. To fully specify an element, you must  prefix it with its namespace. 

For example, if you want to use the `Button` element in your UXML template, you must specify `<UnityEngine.Experimental.UIElements:Button />`. 

To make specifying namespaces easier, you can define a namespace prefix. For example, the line  `xmlns:engine="UnityEngine.Experimental.UIElements"` defines the `engine` prefix as the same as specifying `UnityEngine.Experimental.UIElements`. 

Once this shortened prefix is defined, the text   `<engine:Button />` is equivalent to `<UnityEngine.Experimental.UIElements:Button />`.

If you define your own elements, these elements are probably defined in their own namespace. If you want to use these elements in your UXML template, you must include the namespace definition and schema file location in the `<UXML>` tag, along with the Unity namespaces. 

The Unity Editor does this automatically for you when you create a new UXML template asset from the `Asset/Create/UIElements View` menu.

The definition of the UI is within the `<UXML>` root. The UI defintition is a series of nested XML elements, each representing a `VisualElement`. 

The element name corresponds to the C# class name of the element to instantiate. Most elements have attributes and their values are mapped to corresponding class properties in C#. Each element inherits the attributes of its parent class type, to which it can add its own set of attributes. `VisualElement` being the base class for all elements, it provides the following attributes for all elements:

- `name`: an identifier for the element. The name should be unique.
- `picking-mode`: set to either `Position` to respond to mouse events or `Ignore` to
  ignore mouse events.
- `focus-index`: used to determine focus order when tabbing. The focus ring  (see
  [The focus ring](/events/event-dispatch/index.html#the-focus-ring))
- `class`: a space-separated list of identifiers that characterize the element. Use classes to assign visual styles to elements. You can also use classes to select a set of elements in UQuery.
- `slot-name` and `slot`: Slots act as placehoders which insert other visual elements when a UXML component is instantiated. See [Slots](#slots) below. 
- `tooltip`: a string that displays as a tooltip when the mouse hovers over the element.

The UXML template example does not define the visual aspect of the user interface. As a best practice, you should define style information, such as the dimensions, fonts, and colors for drawing the UI with a separate file with style rules written in USS (see [Styles](/styles/styles/)).

## Reusing UXML

You can create components by simply defining it in a UXML file
and import it using the `<Template>` and `<Instance>` elements in another UXML file.

When designing a large user interface, you can create template UXML files that define parts of the UI.

You could use the same UI definitions in many places. For example, say that you have a portrait UI element that has an image, name, and a label. You can create a UXML template file to resuse the portrait UI elment in other UXML files.

For example, say that you have a _Portrait_ component in the file `Assets/Portrait.uxml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<engine:UXML ...>
    <engine:VisualElement class="portrait">
        <engine:Image name="portaitImage" image="a.png"/>
        <engine:Label name="nameLabel" text="Name"/>
        <engine:Label name="levelLabel" text="42"/>
    </engine:VisualElement>
</engine:UXML>
```

You can embed the _Portrait_ component into other UXML templates like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<engine:UXML ...>
    <engine:Template path="Assets/Portrait.uxml" name="Portrait">
    <engine:VisualElement name="players">
        <engine:Instance template="Portrait" name="player1"/>
        <engine:Instance template="Portrait" name="player2"/>
    </engine:VisualElement>
</engine:UXML>
```

## Slots

A UXML component can define slots that insert elements when the component is instantiated.  Slots act as placehoders which insert other visual elements when a UXML component is instantiated.

Use the `slot-name` attribute to define a slot. For example, a window component, defined in _Window.uxml_, could further define two slots named `title` and `content`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<engine:UXML ...>
    <engine:VisualElement>
        <engine:VisualElement slot-name="title"/>
        <engine:ScrollView slot-name="content"/>
    </engine:VisualElement>
</engine:UXML>
```

A template could then use this window by importing the template file, instantiating its content and filling the slots with its own elements, binding visual elements to `slot-name` by adding them the `slot` attribute:

```xml
<?xml version="1.0" encoding="utf-8"?>
<engine:UXML ...>
    <engine:Template path="Assets/Window.uxml" name="window"/>
    <engine:Instance template="window">
        <engine:Label slot="title">
        <engine:TextBox slot="content"/>
    </engine:Instance>
</Window>
```

The resulting visual element hierarchy would be:

```
VisualElement
    VisualElement slot-name="title"
        Label slot="title"
    ScrollView slot-name="content"
        TextBox slot="content"
```

In the visual element above, the `Label`, which has a `slot="title"` attribute, has been added as a child of the `VisualElement` with a the `slot-name="title"`attribute.

It is also possible to fill slots in C#, from a `VisualTreeAsset` of the component:

```
var slots = new Dictionary<string, VisualElement>();
VisualElement t = visualTreeAsset.CloneTree(slots);
slots["title"].add(new Label());
```

After calling `CloneTree`, the `slots` dictionary holds a mapping of slot name to slot `VisualElement`. You can use it to add visual elements as children of the slot.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

