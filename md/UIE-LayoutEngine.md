# The Layout Engine

UIElements includes a layout engine that positions visual elements based on layout and styling properties. The layout engine is the [Yoga open source project](https://github.com/facebook/yoga) that implements a subset of *Flexbox*: a HTML/CSS layout system.

To get started with Yoga and Flexbox, consult the following external resources:

- [Yoga official documentation](https://yogalayout.com/): the mapping of properties is almost 1-to-1
- [CSS-Tricks guide to Flexbox](https://css-tricks.com/snippets/css/a-guide-to-flexbox/): most properties are supported with some minor differences

By default, all visual elements are part of the layout. The layout has the following default behaviours:

- A container distributes its children vertically.
- The position of a container rectangle includes its children rectangles. This behaviour can be restricted by other layout properties.
- A visual element with text uses the text size in its size calculations. This behaviour can be restricted by other layout properties.

UIElements include [built-in controls](UIE-Controls) for standard UI controls such as button, toggle, text field, or label. These built-in controls have styles that affect their layout.

The following list provides tips on how to use the layout engine:

- Set the `width` and `height` to define the size of an element.

- Use the `flexGrow` property (in USS: `flex-grow: <value>;`) to assign a flexible size to an element. The value of the `flexGrow` property acts as weighting when the size of an element is determined by its siblings.

- Set the `flexDirection`  property to `row` (in USS: `flex-direction: row;`) to switch to a horizontal layout.

- Use relative positioning to offset an element based on its original layout position.

- Use absolute positioning to place an element relative to its parent position rectangle. In this case, it does not affect the layout of its siblings or parent

- If an element has its  `layout.position` property assigned by the API, the element is automatically set to `absolute`.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

