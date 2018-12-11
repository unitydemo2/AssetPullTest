# Responding to Events

You can make a visual element react to an event that it receives in two ways:

- by registering an event callback,
- by implementing a default action.

Whether you should register an event callback or implement default actions depends on many factors.

For example, if you instantiate objects from an existing class and you want the instance to react in a specific way when it receive events, your only option is to register callbacks on this instance.

However, if you derive a new class from VisualElement and you want all instances of this class to react to events in the same way, you can either register callbacks on all instances of this class in the constructor, or implement default actions for the class.

The fundamental differences between callbacks and default actions are as follows:

- Callbacks must be registered on instances of the class. Default actions are implemented as virtual functions on the class.
- Callbacks are executed for all elements along the propagation path. Default actions are executed for the event target only.

You can prevent default actions from executing by calling `event.PreventDefault()`. Some event types cannot be cancelled which means that their default actions cannot be cancelled. You can prevent callbacks from executing by calling `event.StopPropagation()` or `event.StopImmediatePropagation()`, even for events that are not cancellable.

You should view default actions as the behaviors that an element of a specific type should have when it receives an event. 

For example, a checkbox should respond to a click event by toggling its state. This behavior should be implemented by overriding a default action virtual function rather than registering callbacks on all checkboxes. 

In general, you should prefer implementing the behaviors that are naturally expected from your element with default actions. This ensures that default element behaviors can be cancelled on an instance by instance basis by calling `PreventDefault()` in a callback attached to an instance.

Additional benefits of implementing behaviors as default actions are that their execution do not require a lookup in the callback registry and instances without callbacks are optimized out of the trickle down/bubble-up propagation process.

For greater flexibility, default actions of the event target can be executed at two moments during the event dispatch process:

- between the trickle down and the bubble up propagation phase, immediately after the target callbacks are executed, by overriding `ExecuteDefaultActionsAtTarget()`;
- at the end of the event dispatch process, by overriding `ExecuteDefaultActions()`.

Whenever possible, implement your class default actions in `ExecuteDefaultActions()`. This gives the users of your class more options to override them: they can call `PreventDefault()` either during the trickle down phase or the bubble up phase of the event propagation process.

Sometimes, however, you must enforce that an event executing a default action on your class is not propagated to the parent of the element. For example, a text field receives key down events that modifies its value. These key down events are not propagated to the parent that might, for example, use the Delete key to delete content. In this case, implement your default action using `ExecuteDefaultActionsAtTarget()` and call `StopPropagation()`. This ensures that the event is not processed by callbacks during the bubble up phase.

Default actions are only executed for the target of an event. They are not executed when the element receives the event as a result of the event propagation process. If you want your class to react to events targeted at their children or at their parents, you must register a callback on each instance of your class. This is sometimes necessary, but for better expandability and better performance, try to avoid registering callbacks on every instance of your class.

## Registering an event callback

To add a custom behavior to a specific instance of a visual element, you must register a callback for the event that triggers the custom behavior. 

The advantage of registering an event callback is that it lets you customize the behavior of an individual instance of an existing class. The disadvantage of registering an event callback is that it is less performant because it takes longer to execute. It takes longer to execute because, whenever an event is received, the registered event is checked to determine which callback should be executed. 

For example, the following code registers two callbacks for the `MouseDownEvent`:

```csharp
    // Register a callback on a mouse down event
    myElement.RegisterCallback<MouseDownEvent>(MyCallback);
    // Same, but also send some user data to the callback
    myElement.RegisterCallback<MouseDownEvent, MyType>(MyCallbackWithData, myData);
```

Your callback signature should look like this:

```csharp
void MyCallback(MouseDownEvent evt) { /* ... */ }
void MyCallbackWithData(MouseDownEvent evt, MyType data) { /* ... */ }
```

You can register as many callbacks as you wish for an event. However, the callback registration system prevents you from registering the same callback function more than once on a given event and propagation phase. You can remove a callback from a `VisualElement` by calling the `myElement.UnregisterCallback()` method.

Each element along the propagation path, except the target, receives the event twice: once during the trickle down phase and once during the bubble-up phase. To avoid executing a registered callback twice, use the optional `RegisterCallback` to specify during which phase a callback is executed.

By default, a registered callback is executed during the target phase and the bubble-up phase. This default behavior ensures that a parent element reacts after its children. If, for example, you want a parent to react first, to override the behaviour of its children, you would register your callback with the `TrickleDown.TrickleDown` option:

```csharp
    // Register a callback for the trickle down phase
    myElement.RegisterCallback<MouseDownEvent>(MyCallback, TrickleDown.TrickleDown);
```

This informs the dispatcher to execute the callback at the target phase and the trickle down phase.

## Implementing a default action

A default action applies to all instances of the class. This means that one or both methods are called for every event the element receives.  

A class that implements default actions can also have callbacks registered on its instances.

An event class implements behaviors that are executed either before or after processing an event. The events class does this by overriding the `PreDispatch()` of `PostDispatch()` method of the `EventBase` class. Since events are queued, these methods can update the state or perform tasks when the event is handled instead of when the event is emitted. For example, the `BlurEvent`changes the currently focused element before it proceses the element.

Implementing a default action requires deriving a new subclass of `VisualElement` and implementing either the `ExecuteDefaultActionAtTarget()` method, the `ExecuteDefaultAction()` method, or both. 

Default actions are actions that are executed by each instance of a visual element sub-class when it receives an event. You can customize default actions by overriding `ExecuteDefaultActionAtTarget()` and `ExecuteDefaultAction()`:

```csharp
override void ExecuteDefaultActionAtTarget(EventBase evt)
{
    // Do not forget to call the base function.
    base.ExecuteDefaultActionAtTarget(evt);

    if (evt.GetEventTypeId() == MouseDownEvent.TypeId())
    {
        // ...
    }
    else if (evt.GetEventTypeId() == MouseUpEvent.TypeId())
    {
        // ...
    }
    // More event types
}
```

For greater flexibility, you should implement your default actions in `ExecuteDefaultAction()`. This allows users to stop or prevent the execution of a default action, if needed. 

If you want the target default action to be executed before its parent callback, implement the default actions in  `ExecuteDefaultActionAtTarget()`.



# The event handling sequence

When an event occurs, it is sent along the propagation path in the visual element tree. Assuming that the event type demands that all phases of event propagation be followed, the event is sent to each visual element. The event handling sequence is a follows:

1. Execute event callbacks on elements from the root element down to the parent of the event target. This is the *trickle down phase* of the dispatch process.
2. Execute event callbacks on the event target. This is the *target phase* of the dispatch process.
3. Call the target `ExecuteDefaultActionAtTarget()`.
4. Execute event callbacks on elements from the event target parent up to the root. This is the *bubble-up phase* of the dispatch process.
5. Call the target `ExecuteDefaultAction()`.

As an event is sent along the propagation path, `Event.currentTarget` is updated to the element currently handling the event. This means that within an event callback function, `Event.currentTarget` is the element on which the callback was registered and `Event.target` is the element on which the event occured.

## Stopping event propagation and cancelling default actions

You can use callbacks to stop, prevent, and cancel actions from being executed. However, you cannot prevent the `EventBase.PreDispatch()` and `EventBase.PostDispatch()`methods from being executed.

The following methods affect event propagation and default actions: 

- `StopImmediatePropagation()` stops the event propagation process immediately. No other callbacks are executed for this event. However, the `ExecuteDefaultActionAtTarget()` and `ExecuteDefaultAction()` default actions are still executed.
- `StopPropagation()` stops the event propagation process after the last callback on the current element. This ensure that all callbacks on the current element are executed, but that no further elements react to the event. The `ExecuteDefaultActionAtTarget()` and `ExecuteDefaultAction()` default actions are still be executed.
- `PreventDefaultAction()` prevents the  `ExecuteDefaultActionAtTarget()` and
  `ExecuteDefaultAction()` default actions from being called. `PreventDefaultAction()`  does not prevent other callbacks from being executed. In addition, if you call `PreventDefaultAction()` during the bubble-up phase, the `ExecuteDefaultActionAtTarget()` default action is not prevented because it has already been executed. The `ExecuteDefaultActionAtTarget()` default action is executed during the trickle down phase.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
