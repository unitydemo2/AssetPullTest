# Styles and Unity style sheets

Each `VisualElement` includes style properties that set the dimensions of the element and how the element is drawn on screen, such as `backgroundColor` or `borderColor`.

Style properties are either set in C# or from a style sheet. Style properties are regrouped in their own data structure (`IStyle` interface). 

UIElements supports style sheets written in USS (Unity style sheet). USS files are text files inspired by Cascading Style Sheets (CSS) from HTML. The USS format is similar to CSS, but USS includes overrides and customizations to work better with Unity. 

This section includes details on USS, its syntax, and its differences when compared to CSS.

## Definition of a Unity style sheet

The fundamental building blocks of a Unity style sheet (USS) are as follows :

- A USS is a text file recognized as an asset. The text file must have the  `.uss` extension.
- A USS only supports style rules.
- A style rule is composed of a selector and a declaration block.
- The selector identifies which visual element the style rule affects.
- The declaration block, enclosed by curly braces, contains one or more style declarations. Each style declaration is comprised of a property and a value. Each style declaration ends with a semi-colon.
- The value for each style property is a literal which, when parsed, must match the target property name.

The general syntax of a style rule is :

```css
selector {
  property1:value;
  property2:value;
}
```

The USS syntax matches the W3C specifications for CSS3. UIElements uses the [ExCSS open source parser](https://github.com/Unity-Technologies/ExCSS) to parse USS declarations. The ExCSS open source parser has its own test suite.



## Attaching USS to visual elements

You can attach a Unity style sheet (USS) to any visual element. Style rules apply to the visual element and all of its descendants. Style sheets are also re-applied automatically when necessary.

Use the `AddStyleSheetPath()` method to associate a USS to a visual element. You must also provide the `AddStyleSheetPath()` method with the relative path to the enclosing folder. For Unity to recognize the USS file, it must be placed in the `Resources` or `Editor Default Resources` folder, within the `Assets` folder.

If you modify a USS file while the `EditorWindow` is running, style changes are applied immediately.

## Style matching with rules

Once a style sheet is defined, it can be applied to a UIElements tree of visual elements. 

During this process, selectors are matched against elements to resolve which properties are applied from the USS file. If a selector matches an element, the style declarations are applied to the element.

For example, the following rule matches any `Button` object:

```css
Button {
  width: 200px;
}
```

You attach style sheets to a subtree with the `VisualElement.AddStyleSheetPath()` method.

## VisualElement matching

UIElements use the following criteria to match a visual element with its style rule:

- Its C# class name (always the most derived class)
- A `name` property that is a string
- A class list represented as a set of strings
- The ancestry and position of the VisualElement in the visual tree.

These traits can be used in selectors in the style sheet.

If you are familiar with CSS you can see the similarity with the HTML tag name, the `id` attribute and `class` attribute.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

