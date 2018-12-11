# Built-in Controls

The following standard controls are built into UIElements :

- Button
- Contextual menu
- EditorTextField
- Label
- ScrollView
- TextField 
- Toggle


## Contextual menu

The Contextual Menu control is a standard control that displays a set of choices or actions, depending on the context. This context is usually the current selection, but the context can be anything. 

This topic demonstrates how to add a contextual menu, explains its callbacks, and shows how to respond to user selection.

### Adding a contextual menu to visual elements

To display a contextual menu, call `ContextualMenuManager.DisplayMenu()` in the callback for the event that triggers displaying the contextual menu. 

For example, to display a contextual menu when the right mouse click is released, add the following code to the callback for the `OnMouseUpEvent`:

```csharp
// In a VisualElement subclass
void OnMouseUpEvent(MouseUpEvent evt)
{
    if (elementPanel == null || elementPanel.contextualMenuManager == null)
        return;

    if (evt.button != MouseButton.RightMouse || evt.modifiers != EventModifiers.None)
        return;

    elementPanel.contextualMenuManager.DisplayMenu(evt, this);
    evt.StopPropagation();
    evt.PreventDefault();
}
```

In the above example, `ContextualMenuManager.DisplayMenu()` sends the  `ContextualMenuPopulateEvent` event targert as the second argument of `DisplayMenu()`. This event is propagated to the visual element tree, along the propagation path: from the root of the visual tree to the event target, then back up the visual tree to the root. Along the propagation path, the elements with a callback for the `ContextualMenuPopulateEvent` event can add, remove, or modify items in the contextual menu. 

The above example also shows how to use  `StopPropagation`, and how to prevent an element from being displayed with  `PreventDefault()`.

To add a contextual menu, attach the `ContextualMenuManipulator` manipulator to a visual element. This manipulator adds a callback that displays a contextual menu after either a right button mouse up event, or a menu key up event. The `ContextualMenuManipulator` manipulator also adds a callback that responds to a  `ContextualMenuPopulateEvent`. 

This installed callback also calls the delegate to populate the contextual menu. You provide the delegate when you instantiate the manipulator. The following code example shows how to do this: 

```csharp
void InstallManipulator(VisualElement element)
{
    ContextualMenuManipulator m = new ContextualMenuManipulator(MyDelegate);
    m.target = element;
}

void MyDelegate(ContextualMenuPopulateEvent event)
{
    // Modify event.menu
    event.menu.AppendAction("Properties", DisplayProperties, DropdownMenu.MenuAction.AlwaysEnabled);
}

void DisplayProperties(DropdownMenu.MenuAction menuItem)
{
    // ...
}
```

### Responding to the user selection

When an element receives a `ContextualMenuPopulateEvent`, it adds menu items to the contextual menu by calling either `DropdownMenu.InsertAction()`or `DropdownMenu.AppendAction()`. 

Each of these functions take two callbacks as parameters. The first callback is executed when the user selects the item in the menu. The second callback is executed before displaying the menu. The second callback also checks whether the menu item is enabled.

Both callbacks receive a `MenuAction` as a parameter. The `MenuAction` represents the menu item and has the following other useful properties: 

-  `MenuAction.userData` contains a reference to user data that might have been used with  `AppendAction()` or `InsertAction()`.
- `MenuAction.eventInfo` contains information about the event that triggered
  the display of the contextual menu. Use  `MenuAction.eventInfo`  in the action that responds to the event. For example, you can use the mouse position to create and place an object based on the selected contextual menu item.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

