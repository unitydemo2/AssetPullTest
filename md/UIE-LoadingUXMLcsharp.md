# Loading UXML from C&#35;

To build user interface from a UXML template, you must first load the template into a `VisualTreeAsset`:

```
var template = EditorGUIUtility.Load("path/to/file.uxml") as VisualTreeAsset;
```

You can then build the visual tree that this represents and attach it to a parent element:

```
template.CloneTree(parentElement, slots);
```

In the statement above, the `<UXML>` element in the template is not translated to a`VisualElement`. Instead, all of its children are attached to the element specified by `parentElement`.

Once the template is instantiated, you can retrieve specific elements from the visual element tree with UQuery: Unity's implementation of JQuery/Linq.

For example, the following code demonstrates how to create a new `EditorWindow` and load a UXML file as its content:

```
public class MyWindow : EditorWindow  {
    [MenuItem ("Window/My Window")]
    public static void  ShowWindow () {
        EditorWindow w = EditorWindow.GetWindow(typeof(MyWindow));

        VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/MyWindow.uxml");
        VisualElement ui = uiAsset.CloneTree(null);

        w.GetRootVisualContainer().Add(ui);
    }

    void OnGUI () {
        // Nothing to do here, unless you need to also handle IMGUI stuff.
    }
}
```

---
* <span class="page-edit">2018-11-02  <!-- include IncludeTextAmendPageSomeEdit --></span>
