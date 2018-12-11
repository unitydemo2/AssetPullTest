# UQuery

UQuery provides a set of extension methods for retrieving elements from any UIElements visual tree. UQuery is based on JQuery or Linq, but UQuery is designed to limit dynamic memory allocation as much as possible. This allows for optimal performance on moble platforms.

To use UQuery to retrieve elements, use the `UQueryExtensions.Q` or initialize a `QueryBuilder` with `UQueryExtensions.Query`.

For example, the following UQuery starts at the root and finds the first `Button` with the name `foo`:

```
root.Query<Button>("foo").First();
```

The following UQuery iterates, in the same group, on each `Button` named `foo`:

```
root.Query("foo").Children<Button>().ForEach(//do stuff);
```

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
