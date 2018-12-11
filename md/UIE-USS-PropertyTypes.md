# Properties types

## Built-in vs Custom properties

When using USS, you can specify values for built-in `VisualElement` properties or for custom properties in your UI code.

In addition of reading their values from USS files, built-in property values can be assigned to in C#, using the C# properties of `VisualElement`. Values assigned in C# override values from a Unity style sheet (USS). 

You can extend USS with the Custom Properties API. 

## Property values

This section lists the supported types.

### Keywords

The following keywords have special meaning:

- `auto`
- `inherit`
- `unset`
- `true`
- `false`
- `none`

Limitation: The keywords  `auto`, `inherit`, and `unset` are imported correctly, but are not supported at runtime. 

### Numeric properties

UIElements does not support units. All property types are assumed to be specified in pixels.

Numeric values are floating points or integer literals. For example: `flex:1.0` or `width:200`. Numeric values are stored as floating-point numbers, including integer literals.

### Enumeration

Enumerations are only supported for enum-based, built-in properties. Enumerations provide a readable name instead of a number. For example: `position-type:absolute`.

### Color

UIElements supports the following literal color values and functions:

- A Hexadecimal value : `#FFFF00` (rgba one byte per channel), `#0F0` (rgb)
- The RGB function : `rgb(255, 255, 0)`
- The RGBA function : `rgba(255, 255, 0, 1.0)`
- The HSL function : `hsl(0, 100%, 50%)`

### Assets

You can reference assets with either the  `resource()` or `url()` functions. For example, specify `background-image: resource("Images/img.png")` to specify the `img.png` in the `Images` directory as the background image. Referenced assets are resolved during import.

The  `resource()` function accepts files located under either the `Resources` folder or the `Editor Default Resources` folder, with the following caveats:

- If the file is located under the `Resources` folder, do not include the file extension. For example: `background-image: resource("Images/my-image")`.
- If the file is located under `Editor Default Resources`, you must include the file extension. For example: `background-image: resource("Images/default-image.png")`.

The `url()` function expects the file path to be relative to either the project root or the folder containing the USS file. You must include the file extension. For example: `background-image: url("Images/my-image.png")`.

For textures, if a file has a version with a `@2x` suffix, this file is automatically loaded for retina or High DPI screens.

### Strings

Use quotes to specify a string value. For example: `my-property: "foo"`.

---
* <span class="page-edit">2018-11-16  <!-- include IncludeTextAmendPageSomeEdit --></span>
