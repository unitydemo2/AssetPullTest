# The Event System

UIElements includes an event system that communicates user interactions to visual elements. Inspired by HTML events, the UIElements events system shares many of the same terminology and event naming. The UlElement event system is comprised of the following:

- Event dispatcher: UIElements listens to events, coming from the operating system or scripts, and dispatches these events with the [Event dispatcher](UIE-Events-Dispatching). The Event dispatcher also determines the dispatching strategy used to send events to visual elements and other supporting classes. 
- Event handler: When an event occurs inside a panel, the event is sent to the VisualElement tree within the panel. You can add event handlers to visual elements to respond to certain event types when they occur. See [Responding to events](UIE-Events-Handling).
- Event synthesizer: The operating system is not the only source of events. Scripts can also create and dispatch events through the dispatcher. See [Synthesizing Events](UIE-Events-Synthesizing) for more on creating and dispatching events.
- Event types: The different event types are organized into a hierarchy based on `EventBase` and grouped into families. Each family of events implements an interface that defines the common characteristics for all  events of the same family. For example, `MouseUpEvent`, `MouseDownEvent` and other mouse events implement the `IMouseEvent` inteface. This interface specifies that each mouse event has a position, a pressed button, a set of modifers, and other mouse-related event types. See [Event type reference](UIE-Events-Reference) for a description of each event family and their UIElement event types.

You can also use events to communicate other types of messages to visual elements. For example, the `ContextualMenuManager` uses the `ContextualMenuPopulateEvent` to add items to a contextual menu. See [built-in controls](UIE-Controls).

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
