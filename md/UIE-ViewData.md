# ViewData persistence

Use the ViewData API to persist UI-specific state data after a domain reloads or when the Editor restarts. Persistent data is stored on each `EditorWindow`. Each `VisualElement` has a `persistenceKey` that must be set in order to enable `ViewData` persistence. 

This topic provides examples on how to enable ViewData persistence for implemented controls and new objects.

## Usage for implemented controls

If an element already supports persistence, set the `persistenceKey` to tell the system that it needs to save data. The `persistenceKey` must be unique compared against the keys for other visual elements.

## Usage with VisualElement object inheritance

If you create a new `VisualElement`, you can have it support persistent data. The first step is to encapsulate your persistent data within one or more `Serializable` classes inside your element class:

``` csharp
[Serializable]
public class ExtraData
{
    public int m_Value = 0;
}
public ExtraData m_ExtraData;
```

The second step is to call the `SavePersistentData()`  method whenever the persistent data changes. This ensures that the data is saved properly:

``` csharp
public int value
{
    get { return m_Value; }
    set
    {
        // do stuff
        SavePersistentData();
    }
}
```

The last step is to override `OnPersistentDataReady()`:

``` csharp
// We do our real initial work here, once we know we can access our
// persistent data store.
protected override void OnPersistentDataReady()
{
    base.OnPersistentDataReady();

    // Optionally get a more unique key based on current parents.
    // This includes our own `persistenceKey`.
    var key = GetFullHierarchicalPersistenceKey();

    // Get or create a new ExtraData objects.
    m_ExtraData = GetOrCreatePersistentData<ExtraData>(m_ExtraData, key);
}
```

The example above also demonstrates how to generate and assign a unique key. Once the key is assigned, `GetOrCreatePersistentData()` returns the object with the persistence state, or as-is.

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>

