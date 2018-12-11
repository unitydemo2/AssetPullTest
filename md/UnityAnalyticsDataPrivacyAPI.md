# Unity Analytics DataPrivacy API

The `DataPrivacy` class configures the Unity Analytics service based on the player's data privacy management choices.

NAMESPACE: `UnityEngine.Analytics`

```
    public class DataPrivacy
```

The `DataPrivacy` class automatically fetches the player's data privacy status and configures the Analytics service accordingly.

Use the `FetchPrivacyUrl()` function to fetch the the URL of the player's personal data management page. Open the URL to give the player the option to manage their data privacy settings.

This page details the following functions:

* [Initialize()](#init) - Prepares the Data Privacy API for use (for Unity 5.1 or earlier).
* [FetchPrivacyUrl(Action&lt;String&gt;, Action&lt;String&gt;)](#privacyurl) - Gets the URL of the player's personal data management page.

<a name="init"></a>
## Initialize()

Prepares the Data Privacy API for use.

### Declaration

```
    public static void Initialize()
```

### Details

This function creates a hidden GameObject and adds an instance of the `DataPrivacy` class to it as a component.

On Unity 5.1 or earlier, call `Initialize()` early in your application startup (ideally, right after you call `UnityAnalytics.StartSDK (projectId)`. Newer versions of Unity call `Initialize()` automatically. 


<a name="privacyurl"></a>
## FetchPrivacyUrl(Action&lt;String&gt;, Action&lt;String&gt;)

Gets the URL of the player's personal data management page.

### Declaration

```
    public static void FetchPrivacyUrl(Action<string> success, Action<string> failure = null)
```

### Parameters

* `Action<String> success` — The Action object to invoke when the URL is successfully retrieved. The string passed to the Action contains the URL.

* [optional] `Action<String> failure` — The Action object to invoke when Unity cannot retrieve the URL. The string passed to the Action contains the reason for the failure.

### Details
Open the URL passed to your `success` function in a browser or webview to give the player the opportunity to manage their data protection options. You can use `Application.OpenURL()` to open the page.

The URL is valid for a short period of time. Always fetch the URL immediately before opening it.

---

* <span class="page-edit">2018-11-05  <!-- include IncludeTextNewPageSomeEdit --></span>

* <span class="page-history">Removed Editor menu command for inserting the Data Privacy button. Added the Data Privacy Button prefab.</span>
* <span class="page-history">New feature in Unity 2018.1.</span>
* <span class="page-history">Removed FetchOptOutStatus function in 2018.3.</span>
