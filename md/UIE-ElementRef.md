# UXML Elements Reference

This topic details the UXML elements available in the `UnityEngine.Experimental.UIElements` and `UnityEditor.Experimental.UIElements` namespaces.

## Base elements

### `VisualElement`

Base class for all visual elements.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - `class`: a list of space separated names
    - `style`: USS directives for styling the element
    - `name`: a unique string identifier for this element
    - `focus-index`: an integer used to determine the focus order when tabbing; default value is `-1` meaning that the element is not focusable
    - `picking-mode`: `Position` or `Ignore`; default value is `Position`
    - `tooltip`: a string displayed when the mouse hovers the element
    - `slot-name`: defines this elements as a slot
    - `slot`: when the element is inside an `<Instance>`, move the element inside the slot referenced by this attribute
    - also accept any other attribute

### `BindableElement`

An element that can be bound to a `SerializedProperty`. The value of the property and the value displayed are synchronized.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `VisualElement`
    - `binding-path`: the path of the property this element is bound to

## Utilities

### `Box`

Similar to `VisualElement` but draws a box around its content.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `VisualElement`

### `TextElement`

An element that displays text.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
    - `text`: the text displayed by the element

### `Label`

A text label.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `TextElement`

### `Image`

Displays an image.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`

### `IMGUIContainer`

Elements that draws IMGUI content.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
        + `focus-index` default value is `0`

### `Foldout`

Element that has a toggle button to show or hide its content.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `BindableElement`

## Templates

### `Template`

A reference to another UXML template that can be instantiated using the `Instance` element.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - `name`: a unique string identifier for this element
    - `path`: the path of the UXML file to load

### `Instance`

Instance of a `Template`.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - `template`: the `name` of the `Template` to instantiate

## Controls

### `Button`

A standard push button.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `TextElement`

### `RepeatButton`

A button that executes an action repeatedly while pressed.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `TextElement`
    - `delay`: the initial delay in milliseconds before the action is executed;
       default value is `0`
    - `interval`: the interval in milliseconds between each action repetition;
       default value is `0`

### `Toggle`

A toggle button (checkbox).

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `label`: the text label for the toggle
    - `value`: a boolean indicating whether the toggle in on or off.

### `Scroller`

A scroll bar.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
    - `low-value`: minimum value of the scroller
    - `high-value`: maximum value of the scroller
    - `direction`: `Horizontal` or `Vertical`; default is `Vertical`
    - `value`: the position of the scroller cursor

### `ScrollerButton`

A button at the end of a scroll bar.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
    - `delay`: the initial delay in milliseconds before the action is executed;
       default value is `0`
    - `interval`: the interval in milliseconds between each action repetition;
       default value is `0`

### `Slider`

A slider.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
    - `low-value`: minimum value of the slider
    - `high-value`: maximum value of the slider
    - `direction`: `Horizontal` or `Vertical`; default is `Vertical`
    - `page-size`: page size of the slider
    - `value`: the position of the slider cursor

### `SliderInt`

A slider for integer values.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
    - `low-value`: minimum value of the slider
    - `high-value`: maximum value of the slider
    - `direction`: `Horizontal` or `Vertical`; default is `Vertical`
    - `page-size`: page size of the slider
    - `value`: the position of the slider cursor

### `MinMaxSlider`

A slider that let the user specify a minimum and a maximum value.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
    - `low-limit`: minimum value of the scroller
    - `high-limit`: maximum value of the scroller
    - `min-value`: the minimum value of the slider cursor
    - `max-value`: the maximum value of the slider cursor

### `EnumField`

A field that can only take the string values of an underlying `Enum`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `type`: required, a string representing the C# type of the underlying `Enum`
    - `value`: a string representing the value of the field

### `MaskField`

A popup menu that enables the user to select a group of values.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `choices`: a comma separated list of up to 32 choices to display in the popup menu
    - `value`: an integer representing the value of the field as a 32 bits mask.

### `LayerField`

A popup menu that enables the user to select a [layer](Layers).

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: an integer representing the value of the field (the selected layer number).

### `LayerMaskField`

A popup menu that enables the user to select a group of [layers](Layers).

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `MaskField`

### `TagField`

A popup menu that enables the user to select a [tag](Tags).

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: a string representing the value of the field (the selected tag name).

## Text input

### `TextField`

An editable text field.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `text`: the text value of the field
    - `max-length`: the maximum number of characters that the field can contains. Default value of `-1` sets no limits on the text length.
    - `password`: a boolean indicating whether the field content should be
      shown (`false`, the default) or displayed using the `maskCharacter` character.
    - `mask-character`: character used to display the field content when `password` is `true`. Default is the character `*`.
    - `multiline`: a boolean indicating whether the text field displays its text on multiple lines (`true`) or on a single line, ignoring any line break in the text (`false`, the default).

### `IntegerField`

A text field accepting an integer (32 bits) value.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: the value of the field
    - `text`: the text value of the field
    - `max-length`: the maximum number of characters that the field can contains.
      Default value of `-1` sets no limits on the text length.
    - `password`: a boolean indicating whether the field content should be
      shown (`false`, the default) or displayed using the `maskCharacter` character.
    - `mask-character`: character used to display the field content when `password` is  `true`. Default is the character `*`.

### `LongField`

A text field accepting a long integer (64 bits) value.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: the value of the field
    - `text`: the text value of the field
    - `max-length`: the maximum number of characters that the field can contains.
      Default value of `-1` sets no limits on the text length.
    - `password`: a boolean indicating whether the field content should be
      shown (`false`, the default) or displayed using the `maskCharacter` character.
    - `mask-character`: character used to display the field content when `password` is
      `true`. Default is the character `*`.

### `FloatField`

A text field accepting a single precision floating point value.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: the value of the field
    - `text`: the text value of the field
    - `max-length`: the maximum number of characters that the field can contains.
      Default value of `-1` sets no limits on the text length.
    - `password`: a boolean indicating whether the field content should be
      shown (`false`, the default) or displayed using the `maskCharacter` character.
    - `mask-character`: character used to display the field content when `password` is
      `true`. Default is the character `*`.

### `DoubleField`

A text field accepting a double precision floating point value.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: the value of the field
    - `text`: the text value of the field
    - `max-length`: the maximum number of characters that the field can contains.
      Default value of `-1` sets no limits on the text length.
    - `password`: a boolean indicating whether the field content should be
      shown (`false`, the default) or displayed using the `maskCharacter` character.
    - `mask-character`: character used to display the field content when `password` is
      `true`. Default is the character `*`.

### `Vector2Field`

A set of two text fields accepting floating point values to
edit the value of a `Vector2`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the X coordinate
    - `y`: the value of the Y coordinate

### `Vector2IntField`

A set of two text fields accepting integer values to
edit the value of a `Vector2Int`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the X coordinate
    - `y`: the value of the Y coordinate

### `Vector3Field`

A set of three text fields accepting floating point values to
edit the value of a `Vector3`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the X coordinate
    - `y`: the value of the Y coordinate
    - `z`: the value of the Z coordinate

### `Vector3IntField`

A set of three text fields accepting integer values to
edit the value of a `Vector3Int`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the X coordinate
    - `y`: the value of the Y coordinate
    - `z`: the value of the Z coordinate

### `Vector4Field`

A set of four text fields accepting floating point values to
edit the value of a `Vector4`.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the X coordinate
    - `y`: the value of the Y coordinate
    - `z`: the value of the Z coordinate
    - `w`: the value of the W coordinate

### `RectField`

A set of four text fields accepting floating point values to
edit the value of a rectangle.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the top left corner X coordinate
    - `y`: the value of the top left corner Y coordinate
    - `w`: the width of the rectangle
    - `h`: the height of the rectangle

### `RectIntField`

A set of four text fields accepting integer values to
edit the value of a rectangle.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `x`: the value of the top left corner X coordinate
    - `y`: the value of the top left corner Y coordinate
    - `w`: the width of the rectangle
    - `h`: the height of the rectangle

### `BoundsField`

A set of six text fields accepting floating point values to
edit the value of a bounding rectangle.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `cx`: the value of the center X coordinate
    - `cy`: the value of the center Y coordinate
    - `cz`: the value of the center Z coordinate
    - `ex`: the value of the extent X coordinate
    - `ey`: the value of the extent Y coordinate
    - `ez`: the value of the extent Z coordinate

### `BoundsIntField`

A set of six text fields accepting integer values to
edit the value of a bounding rectangle.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `px`: the value of the center X coordinate
    - `py`: the value of the center Y coordinate
    - `pz`: the value of the center Z coordinate
    - `sx`: the value of the extent X coordinate
    - `sy`: the value of the extent Y coordinate
    - `sz`: the value of the extent Z coordinate

## Complex widgets

### `PropertyField`

A label and a field to edit a value.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
        + `focus-index` default value is `0`
    - `binding-path`: the path of the property this element is bound to
    - `label`: the label for the field

### `ColorField`

A color picker field.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `value`: the color value, as a `Color`
    - `show-eye-dropper`: a boolean indicating whether to show (`true`, the default) the eye dropper or not (`false`).
    - `show-alpha`: a boolean indicating whether to show the alpha control (`true`, the default) or not (`false`)
    - `hdr`: a boolean indicating whether to use the high dynamic range color picker (`true`) or the normal one (`false`, the default)

### `CurveField`

A curve editor field.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`

### `GradientField`

A gradient editor field.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`

### `ObjectField`

An object selector field.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `BindableElement`
        + `focus-index` default value is `0`
    - `allow-scene-objects`: a boolean indicating whether objects from the scene can be selected (`true`, the default) or not (`false`)

### `InspectorElement`

An element that displays a property in an inspector window.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `BindableElement`

## Toolbar

### `Toolbar`

A container to hold toolbar items.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: any `VisualElement`
* Attributes:
    - all attributes of `VisualElement`

### `ToolbarButton`

A button for the toolbar.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `Button`

### `ToolbarToggle`

A toggle for the toolbar.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `Toggle`

### `ToolbarMenu`

A drop down menu for the toolbar. The menu has a single arrow pointing down.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `TextElement`

### `ToolbarPopup`

A popup menu for the toolbar. The menu has a two arrows pointing up and down.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `TextElement`

### `ToolbarSearchField`

A search field for the toolbar.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`

### `ToolbarPopupSearchField`

A search field with a popup menu of search options.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `ToolbarSearchField`

### `ToolbarSpacer`

An element that insert a fixed amount of whitespace between toolbar buttons.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`

### `ToolbarFlexSpacer`

Elements that insert a flexible whitespace between toolbar buttons.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`

## Views and windows

### `ListView`

Displays a list of elements.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: none
* Attributes:
    - all attributes of `VisualElement`
    - `item-height`: the height in pixel of each item in the list

### `ScrollView`

A scrollable view, with horizontal and vertical scrollers.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `VisualElement`
    - `show-horizontal-scroller`: a boolean indicating whether to show the
       horizontal scroller; default `false`
    - `show-vertical-scroller`: a boolean indicating whether to show the vertical scroller; default `false
    - `horizontal-page-size`: page size value of the horizontal scroller
    - `vertical-page-size`: page size of the vertical scroller
    - `stretch-content-width`: a boolean indicating whether the content should stretch to the width of the view

### `PopupWindow`

A UIElements window, displayed on top of other content.

* In `UnityEngine.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `TextElement`

### `VisualSplitter`

A container that allow user to resize its children by dragging a split bar.

* In `UnityEditor.Experimental.UIElements`
* Permitted child elements: any number of `VisualElement`
* Attributes:
    - all attributes of `VisualElement`

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
