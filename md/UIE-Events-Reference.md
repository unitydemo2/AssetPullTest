
# Event Type Reference

This topic provides a summary of each event type. Consult the API documentation for a complete description of each event member and its purpose.

## Capture events

Events implementing `IMouseCaptureEvent`.

### MouseCaptureEvent

`MouseCaptureEvent`  is sent when an element takes the mouse capture.

`target`: The element that takes the capture.

### MouseCaptureOutEvent

`MouseCaptureOutEvent`  is sent when an element releases or otherwise loses the mouse capture.

`target`: The element that loses the capture.

## Change events

Events implementing `IChangeEvent`.

### ChangeEvent

`ChangeEvent<T>` is a generic event sent when the value of an element changes. This is typically sent when a control changes. For the `InputEvent` control, this event is not sent for every input event in the control, but only when the value changes. This is usually when either the control loses focus, or the `Enter` key is pressed.

`<T>`
:    The type of the value.

`target`
:    The element for which the change of value occured.

`previousValue`
:    The old control value.

`newValue`
:    The new control value.

## Command events

Events implementing `ICommandEvent`.

`target`
:    The element with keyboard focus. This is null if no element has focus.

`commandName`
:    The command to validate or execute.

### ValidateCommandEvent

This event is sent by IMGUI while it determines whether the command will be handled by an element in the panel.

### ExecuteCommandEvent

This event is sent by IMGUI when an element in the panel should execute a command.

## Drag and drop events

Events sent during a drag and drop operation.

### DragExitedEvent

The drag and drop operation was cancelled. The drop target did not accept the dragged element.

### DragUpdatedEvent

The dragged element moved over a drop target.

### DragPerformEvent

The dragged element was dropped on a target that accepted them. The drag and drop operation is now finished.

### DragEnterEvent

The dragged element entered a new drop target.

### DragLeaveEvent

The dragged element exited the drop target area.

## Layout events

### GeometryChangedEvent

Event sent when either the position or the dimensions of an element changes. Events of this type are only sent to the event target. They are not propagated.

`target`
:    The element with a new geometry.

`oldRect`
:    The former position and dimensions of the element.

`newRect`
:    The new position and dimensions of the element.

## Focus events

Events implementing `IFocusEvent`.

These events are sent when an element is given or loses keyboard focus. There are two sets of focus events:

- `FocusOutEvent` and `FocusInEvent` are sent along the propagation path just before the focus change occurs.
- `FocusEvent` and `BlurEvent` are sent to the event target only, immediately after the focus change.

### FocusOutEvent

Event sent when an element is about to lose the focus.

`target`
:    The element that will lose the focus.

`relatedTarget`
:    The element that will gain the focus.

### FocusInEvent

Event sent when an element is about to gain the focus.

`target`
:    The element that will gain the focus.

`relatedTarget`
:    The element that will lose the focus.

### BlurEvent

Event sent after an element lost the focus.

`target`
:    The element that lost the focus.

`relatedTarget`
:    The element that gained the focus.

### FocusEvent

Event sent after an element gained the focus.

`target`
:    The element that gained the focus.

`relatedTarget`
:    The element that lost the focus.

## Input events

### InputEvent

Event sent when data is input to a visual element, typically a control. This event differs from `ChangeEvent` in that it is sent for every input event in the control, even if the value of the control did not changed.

`target`
:    The element where the input occured.

`previousData`
:    The former data.

`newData`
:    The new data.

## Keyboard events

Events implementing `IKeyboardEvent`.

### KeyDownEvent

Event sent when the user presses a key on the keyboard.

`target`
:    The element that has the keyboard focus. If no element has keyboard focus, this is the root element of the panel.

### KeyUpEvent

Event sent when the user releases a key on the keyboard.

`target`
:    The element that has the keyboard focus. If no element has keyboard focus, this is the root element of the panel.

## Mouse events

Events implementing `IKeyboardEvent`.

While an element is capturing the mouse, mouse events are only be sent to the capturing elements. There is no propagation.

### MouseDownEvent

Event sent when the user presses one of the mouse buttons.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is the topmost pickable element under the cursor.

### MouseUpEvent

Event sent when the user releases one of the mouse buttons.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is the topmost pickable element under the cursor.

### MouseMoveEvent

Event went when the user moves the mouse.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is the topmost pickable element under the cursor.

### ContextClickEvent (obsolete)

Event sent when the user presses and releases the third mouse button. This event only exists for backward compatibility with IMGUI.

### WheelEvent

Event sent when the user activates the mouse wheel.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is the topmost pickable element under the cursor.

### MouseEnterWindowEvent

Event sent when the mouse enters an window.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is the topmost pickable element under the cursor.

### MouseLeaveWindowEvent

Event sent when the mouse leaves an window.

`target`
:    If an element took the mouse capture, this is the element capturing the mouse. Otherwise, this is null because the cursor is not over an element.

### MouseEnterEvent

Event sent when the mouse enters an element or one of its descendant. This event differs from `MouseOverEvent` in that this event is sent to each element being entered by the mouse. This event does not propagate.

`target`
:    The element, or one of its decendants, under the mouse cursor.

### MouseLeaveEvent

Event sent when the mouse leaves an element or one of its descendant. This event differs from `MouseOutEvent` in that this event is sent to each element being exited by the mouse. This event does not propagate.

`target`
:    The element has just been exited by the mouse cursor, or that has one of its descendant exited by the mouse cursor.

### MouseOverEvent

Event sent when the mouse enters an element. This event differs from `MouseEnterEvent` in that this event is only sent to the entered element. . This event does not propagate.

`target`
:    The element that is now under the mouse cursor.

### MouseOutEvent

Event sent when the mouse leaves an element. This event differs from `MouseLeaveEvent` in that this event is only sent to the exited element and that it propagates.

`target`
:    The element that has just been exited by the mouse cursor.

### ContextualMenuPopulateEvent

Event sent by the `ContextualMenuManager` when the contextual menu needs to be populated with menu items.

`target`
:    The element for which the contextual menu is being built.

## Panel events

### AttachToPanelEvent

Event sent immediately after an element is attached to a `IPanel`. Since
setting the panel is recursive, all descendants of the element also
receive the event.

`target`
:    The element being attached to a panel.

### DetachFromPanelEvent

Event sent just before an element is detached to a `IPanel`. Since
setting the panel is recursive, all descendants of the element also
receive the event.

`target`
:    The element being detached from a panel.

## Tooltip event

Event sent just before a tooltip is displayed. The handler should set the  `TooltipEvent.tooltip` string and the `TooltipEvent.rect`.

`target`
:    The element for which a tooltip needs to be displayed.

## IMGUI events

Event used to encapsulate IMGUI-specifc events.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
