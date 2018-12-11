## Support for custom Menu Item and Editor features

In your Editor scripts, use the [ObjectFactory](ScriptRef:ObjectFactory.html) class to create new GameObjects, components and Assets. When creating these items, the `ObjectFactory` class automatically uses default Presets. Your script does not have to search for and apply default [Presets](Presets), because `ObjectFactory` handles this for you.

## Support for new types 

To support and enable Presets by default, your class must inherit from one of the following:

* [UnityEngine.Monobehaviour](ScriptRef:MonoBehaviour.html)
* [UnityEngine.ScriptableObject](ScriptRef:ScriptableObject.html)
* [UnityEngine.ScriptedImporter](ScriptRef:Experimental.AssetImporters.ScriptedImporter.html)

The Preset Inspector creates a temporary instance of your class, so that users can modify its values, so make sure your class does not affect or rely on other objects such as static values, Project Assets or Scene instances.

**Tip**: Using a [CustomEditor](ScriptRef:CustomEditor.html) attribute is optional.

## Use case example: Preset settings in a custom Editor window

When setting up a custom [EditorWindow](ScriptRef:EditorWindow.html) class with settings that could use Presets:

* Use a [ScriptableObject](ScriptRef:ScriptableObject.html) to store a copy of your settings. It can have a [CustomEditor](ScriptRef:CustomEditor.html) attribute too. The Preset system handles this object.

* Always use this temporary `ScriptableObject` Inspector to show the Preset settings in your UI. This allows your users to have the same UI in your `EditorWindow` and when editing saved Presets.

* Expose a Preset button and use your own [PresetSelectorReceiver](ScriptRef:Presets.PresetSelectorReceiver.html) implementation to keep your `EditorWindow` settings up-to-date when a Preset is selected in the __Select Preset__ window.

The following script examples demonstrate how to add Preset settings to a simple `EditorWindow`.

This script example demonstrates a ScriptableObject that keeps and shows settings in a custom window (saved to a file called *Editor/MyWindowSettings.cs*):

```
using UnityEngine;

// Temporary ScriptableObject used by the Preset system

public class MyWindowSettings : ScriptableObject
{
    [SerializeField]
    string m_SomeSettings;
    
    public void Init(MyEditorWindow window)
    {
        m_SomeSettings = window.someSettings;
    }
    
    public void ApplySettings(MyEditorWindow window)
    {
        window.someSettings = m_SomeSettings;
        window.Repaint();
    }
}
```

Script example of a `PresetSelectorReceiver` that updates the `ScriptableObject` used in the custom window (saved to a file called *Editor/MySettingsReceiver.cs)*:

```
using UnityEditor.Presets;

// PresetSelector receiver to update the EditorWindow with the selected values.

public class MySettingsReceiver : PresetSelectorReceiver
{
    Preset initialValues;
    MyWindowSettings currentSettings;
    MyEditorWindow currentWindow;
    
    public void Init(MyWindowSettings settings, MyEditorWindow window)
    {
        currentWindow = window;
        currentSettings = settings;
        initialValues = new Preset(currentSettings);
    }
    
    public override void OnSelectionChanged(Preset selection)
    {
        if (selection != null)
        {
            // Apply the selection to the temporary settings
            selection.ApplyTo(currentSettings);
        }
        else
        {
            // None have been selected. Apply the Initial values back to the temporary selection.
            initialValues.ApplyTo(currentSettings);
        }
        
        // Apply the new temporary settings to our manager instance
        currentSettings.ApplySettings(currentWindow);
    }
    
    public override void OnSelectionClosed(Preset selection)
    {
        // Call selection change one last time to make sure you have the last selection values.
        OnSelectionChanged(selection);
        // Destroy the receiver here, so you don't need to keep a reference to it.
        DestroyImmediate(this);
    }
}
```

Script example of an [EditorWindow](ScriptRef:EditorWindow.html) that shows custom settings using a temporary ScriptableObject Inspector and its Preset button (saved to a file called *Editor/MyEditorWindow.cs)*:

```
using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;

public class MyEditorWindow : EditorWindow

{
    // get the Preset icon and a style to display it
    private static class Styles
    {
        public static GUIContent presetIcon = EditorGUIUtility.IconContent("Preset.Context");
        public static GUIStyle iconButton = new GUIStyle("IconButton");

    }

    Editor m_SettingsEditor;
    MyWindowSettings m_SerializedSettings;
    
    public string someSettings
    {
        get { return EditorPrefs.GetString("MyEditorWindow_SomeSettings"); }
        set { EditorPrefs.SetString("MyEditorWindow_SomeSettings", value); }
    }
   
    // Method to open the window
    [MenuItem("Window/MyEditorWindow")]
    static void OpenWindow()
    {
        GetWindow<MyEditorWindow>();
    }

    void OnEnable()
    {
        // Create your settings now and its associated Inspector
        // that allows to create only one custom Inspector for the settings in the window and the Preset.
        m_SerializedSettings = ScriptableObject.CreateInstance<MyWindowSettings>();
        m_SerializedSettings.Init(this);
        m_SettingsEditor = Editor.CreateEditor(m_SerializedSettings);
    }

    void OnDisable()
    {
        Object.DestroyImmediate(m_SerializedSettings);
        Object.DestroyImmediate(m_SettingsEditor);
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("My custom settings", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        // create the Preset button at the end of the "MyManager Settings" line.
        var buttonPosition = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight, Styles.iconButton);

        if (EditorGUI.DropdownButton(buttonPosition, Styles.presetIcon, FocusType.Passive, Styles.iconButton))
        {
            // Create a receiver instance. This destroys itself when the window appears, so you don't need to keep a reference to it.
            var presetReceiver = ScriptableObject.CreateInstance<MySettingsReceiver>();
            presetReceiver.Init(m_SerializedSettings, this);
            // Show the PresetSelector modal window. The presetReceiver updates your data.
            PresetSelector.ShowSelector(m_SerializedSettings, null, true, presetReceiver);
        }
        EditorGUILayout.EndHorizontal();
        
        // Draw the settings default Inspector and catch any change made to it.
        EditorGUI.BeginChangeCheck();
        m_SettingsEditor.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
        {
            // Apply changes made in the settings editor to our instance.
            m_SerializedSettings.ApplySettings(this);
        }
    }
}
```

---

<span class="page-edit"> 2017-03-27  <!-- include IncludeTextNewPageSomeEdit --></span>
<span class="page-history">New feature in [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) <span class="search-words">NewIn20181</span></span>

