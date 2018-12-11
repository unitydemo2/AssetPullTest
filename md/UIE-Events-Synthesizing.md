# Synthesizing Events

Before you synthesize and send custom events, you should understand how UIElement allocates and sends operating system events. 

UIElements uses a pool of events to avoid allocating event objects repeatedly. To synthesize and send your own events, you should allocate and send events by following the same steps:

1. Get an event object from the pool of events.
2. Fill in the event properties.
3. Enclose the event in a `using` block to ensure it is returned to the event pool.
4. Pass the event to  `element.SendEvent()`.

If you want to send events that usually come from the operating system, such as keyboard events and some mouse events, use a `UnityEngine.Event` to initialize the UIElements event.

The following example demonstrates how to synthesize and send events: 

```csharp
void SynthesizeAndSendKeyDownEvent(IPanel panel, KeyCode code,
     char character = '\0', EventModifiers modifiers = EventModifiers.None)
{
    // Create a UnityEngine.Event to hold initialization data.
    // Also, this event will be forwarded to IMGUIContainer.m_OnGUIHandler
    var evt = new Event() {
        type = EventType.KeyDownEvent,
        keyCode = code,
        character = character,
        modifiers = modifiers
    };

    using (KeyDownEvent keyDownEvent = KeyDownEvent.GetPooled(evt))
    {
        UIElementsUtility.eventDispatcher.DispatchEvent(keyDownEvent, panel);
    }
}

```

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

