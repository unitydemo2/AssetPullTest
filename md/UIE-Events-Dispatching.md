# Dispatching Events

UIElements listens to events, coming from the operating system or scripts, and dispatches these events to visual elements using the `EventDispatcher`. The event dispatcher determines an appropriate dispatching strategy for each event it sends. Once determined, the dispatcher executes the strategy. 

Visual elements, and other supporting classes, implement default behaviors for several events. Sometimes, this involves creating and sending additional events. For example, a `MouseMoveEvent` could generate an additional `MouseEnterEvent` and a `MouseLeaveEvent`. These additional events are placed in a queue and are processed after the current event is completed. For example, the `MouseMoveEvent` is completed before processing the `MouseEnterEvent` and  `MouseLeaveEvent` events. 

## Event target

The first task of `EventDispatcher.DispatchEvent()` is to find the target of the event. 

This is sometimes easy because the event `target` property has already been set. However, this is not the case for most events that originate from the operating system.

The target of an event depends on the event type. For mouse events, the target is usually the topmost pickable element, directly under the mouse. For keyboard events, the target is the currently focused element. 

When the target is found, it is stored in `EventBase.target` which does not change for the duration of the dispatch process. The property `Event.currentTarget` is updated to the element that is currently handling the event.

### Picking mode and custom shapes

Most mouse events use the picking mode to determine their target. The `VisualElement` class has a `pickingMode` property which supports the following values:

- `PickingMode.Position` (default): performs picking based on the position rectangle.
- `PickingMode.Ignore`: prevents picking as the result of a mouse event.

You can override the `VisualElement.ContainsPoint()` method to perform custom intersection logic.

### Capturing the mouse

Sometimes, after a mouse down, an element must capture the mouse position to ensure that all subsequent mouse events are sent exclusively to itself, even when the pointer is no longer hovering over the element. This is typical for a control that reacts to a mouse down and mouse up sequence where a mouse move might occur between the mouse down and the mouse up events. For example, when you click on a button, slider, or a scroll bar.

To capture the mouse, call `element.CaptureMouse()` or `MouseCaptureController.CaptureMouse()`.

To release the mouse, call `MouseCaptureController.ReleaseMouse()`. If another element is already capturing the mouse when you call `CaptureMouse()`, the element receives a `MouseCaptureOutEvent`
and loses the capture. 

Only one element in the application can have the capture at any moment. While an element has the capture, it is the target of all subsequent mouse events except mouse wheel events. 

Note: This only applies to mouse events that do not have their target already set.

### Focus ring and the focus order

Each UIElement panel has a focus ring that defines the focus order of elements. By default, the focus order of elements is determined by performing a depth-first search (DFS) on the visual element tree. For example, the focus order for the tree depicted below would be F, B, A, D, C, E, G, I, H.

![Focus order](../uploads/Main/focus-order.png)

Some events use the focus order to determine which element holds the focus. For example, the target for a keyboard event is the element currently holding the focus.

Use the the `focus-index` property to control the focus order as follows:

- If the `focus-index` is negative, the element is not focusable. By default, `VisualElements` are not focusable, but some subclasses, such as `TextField`, might be focusable by default.
- If the `focus-index` is zero, the element keeps its default focus order, as determined by the focus ring algorithm.
- If the `focus-index` is positive, the element is placed in front of all elements that have their `focus-index = 0` and of all elements that have a higher `focus-index`.

## Event propagation

After selecting the event target, the dispatcher computes the propagation path of the event. The propagation path is an ordered list of visual elements which receive the event. 

The list of elements are obtained by starting at the root of the visual element tree, descending towards the target, and then ascending the tree towards the root.

![Propagation path](../uploads/Main/UIElementsEvents.png)


The first phase of the propagation path descends from the root to the target parent. This is called the *trickle down phase*.

The last phase of the propagation path ascends from the target parent to the root. This is referred to as the *bubble-up phase*. 

The event target is in the middle of the propagation path.

Most event types are sent to all of the elements along the propagation path. However, some event types skip the bubble-up phase. In addition, some event types are only sent to the event target.

If an element is hidden or disabled, it will not receive events. Events are still propagated to the ancestors and descendants of a hidden or disabled element.

As an event is sent along the propagation path, `Event.currentTarget` is updated to the element currently handling the event. This means that within an event callback function, `Event.currentTarget` is the element on which the callback was registered and `Event.target` is the element on which the event occured.

## Dispatch behavior of event types

Each event type has its own dispatch behavior. The following table summarizes the behavior of each event type into three columns:

- Trickles down: Events of this type are sent to elements during the trickle down phase.
- Bubbles up: Events of this type are sent to elements during the bubble-up phase.
- Cancellable: Events of this type can have their default action execution cancelled, stopped, or prevented.

|                             | Trickles down | Bubbles up | Cancellable |
| --------------------------- | :-----------: | :--------: | :---------: |
| MouseCaptureOutEvent        |   &#x2714;    |  &#x2714;  |             |
| MouseCaptureEvent           |   &#x2714;    |  &#x2714;  |             |
| ChangeEvent                 |   &#x2714;    |  &#x2714;  |             |
| ValidateCommandEvent        |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| ExecuteCommandEvent         |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| DragExitedEvent             |   &#x2714;    |  &#x2714;  |             |
| DragUpdatedEvent            |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| DragPerformEvent            |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| DragEnterEvent              |   &#x2714;    |            |             |
| DragLeaveEvent              |   &#x2714;    |            |             |
| FocusOutEvent               |   &#x2714;    |  &#x2714;  |             |
| BlurEvent                   |   &#x2714;    |            |             |
| FocusInEvent                |   &#x2714;    |  &#x2714;  |             |
| FocusEvent                  |   &#x2714;    |            |             |
| InputEvent                  |   &#x2714;    |  &#x2714;  |             |
| KeyDownEvent                |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| KeyUpEvent                  |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| GeometryChangedEvent        |               |            |             |
| MouseDownEvent              |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| MouseUpEvent                |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| MouseMoveEvent              |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| ContextClickEvent           |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| WheelEvent                  |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| MouseEnterEvent             |   &#x2714;    |            |             |
| MouseLeaveEvent             |   &#x2714;    |            |             |
| MouseEnterWindowEvent       |               |            |  &#x2714;   |
| MouseLeaveWindowEvent       |               |            |  &#x2714;   |
| MouseOverEvent              |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| MouseOutEvent               |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| ContextualMenuPopulateEvent |   &#x2714;    |  &#x2714;  |  &#x2714;   |
| AttachToPanelEvent          |               |            |             |
| DetachFromPanelEvent        |               |            |             |
| TooltipEvent                |   &#x2714;    |  &#x2714;  |             |
| IMGUIEvent                  |   &#x2714;    |  &#x2714;  |  &#x2714;   |

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

