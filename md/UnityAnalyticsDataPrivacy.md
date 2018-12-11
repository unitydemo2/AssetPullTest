# Unity Analytics and the EU General Data Protection Regulation (GDPR)

The General Data Protection Regulation (GDPR) is a European Union law regulating the data privacy of EU citizens. 

* For more information about EU GDPR, see [https://www.eugdpr.org](https://www.eugdpr.org)

* For information about Unity and GDPR, see[ https://unity3d.com/legal/gdpr](https://unity3d.com/legal/gdpr)

* For Unity’s own privacy policy, see [https://unity3d.com/legal/privacy-policy](https://unity3d.com/legal/privacy-policy)

Maintaining compliance with GDPR when you use Unity Analytics is a shared responsibility. Unity collects data to help you improve the player experience with ads and gameplay. Some of that data includes personally identifiable information (PII) regulated under GDPR. Unity provides the tools to allow a player to opt out of the PII collection, and to manage the personal data that Unity collects about them, as required by the GDPR. Your responsibilities include adding an opt-out button to your app, and providing a link to Unity’s privacy policy from your own privacy policy. 

When your app uses Unity Ads, Unity displays a notice to the player the first time an ad is shown on their phone giving them the option to opt in or out of personally identifiable information collection. Subsequent ads also display a button that users can use to manage their data privacy options. For more information about GDPR and the Unity Ads SDK, see [Unity Ads Knowledge Base: GDPR Compliance](https://unityads.unity3d.com/help/legal/gdpr).

If you use both Unity Ads and Analytics, the Unity Ads opt-out mechanism applies to both services.

If you do not use Unity Ads, but do use other Unity services, such as Unity Analytics, IAP, Multiplayer, or Performance Reporting, then you must use the __Unity Analytics Data Privacy__ plug-in to provide an opt-out choice to your players. The plug-in provides a button you can add to your game that opens a Unity web page where players can manage their privacy settings. Players manage their preferences on a per-game, per-device basis. Unity Analytics does not track whether the same player plays more than one game made with Unity, or plays the same game on multiple devices.

The above options cover any data collected by Unity for customizing Ads and player services. However, if you collect personally identifiable information data on your own, you are responsible for protecting and managing that data. 

Best practices:

* Solicit your own legal advice. Nothing in this document should be construed as legal advice.

* Read and understand the [Data Processing Addendum (DPA)](https://unity3d.com/profiles/unity3d/themes/unity/images/pages/gdpr/Controller-Controller-DPA-5-2-2018.pdf) [PDF]

* List Unity as a third-party which collects data in your privacy policy, and include a link to Unity’s [privacy policy](https://unity3d.com/legal/privacy-policy) in your privacy policy.

* Do not send personally identifiable information to Unity Analytics in Standard or Custom Events.

* Do not use the `Analytics.SetUserGender()` or `Analytics.SetUserBirthYear()` to send gender and age information to Unity Analytics. These APIs are deprecated.

## The Unity Analytics Data Privacy Plug-in

If you do not use Unity Ads, then you must use the Unity Analytics Data Privacy plug-in to give your players control over Unity Analytics data collection.

The Data Privacy plug-in is part of the Unity **Analytics Library** package. You can use the Unity Package Manager (menu: **Window** > **Package Manager**) to double-check that the package is enabled in a project. 

The plug-in does **not** support the following platforms:

* Linux
* Windows Phone
* Tizen
* Apple TV
* Blackberry

The Unity Analytics service deletes personally identifiable information sent from games running on those platforms automatically. Contact [DPO@unity3d.com](mailto:DPO@unity3d.com) if you have questions.

If your game displays ads from the Unity Ad network, the Unity Ads SDK already displays a data collection opt-out choice to the player, and configures Unity Analytics based on the player’s data privacy choice.  You only need to use the Unity Analytics Data Privacy plug-in when you do not use the Unity Ads service.

**Note:** For versions of Unity prior to 2018.3, you must use the Unity Analytics Data Privacy asset package from the [Unity Asset Store](https://www.assetstore.unity3d.com/#!/content/118922). The Asset Store version can be used with Unity 4.7, 5.1+, 2017.1+, 2018.1, and 2018.2. 


### Presenting the opt-out choice to the player

The Data Privacy plug-in includes a Unity UI button prefab, which you can place in a suitable location of your user interface. When a player clicks this button, it opens the Player Data Privacy page in a web browser. Players can opt-out of Unity’s data collection on this page as well as view the data that Unity has collected in the past. You can also provide your own user interface and open the Player Data Privacy page using the [API](UnityAnalyticsDataPrivacyAPI).

**Important:** If a player has a browser pop-up blocker enabled, their browser can prevent the data privacy page from opening. Some browsers note that a page has been blocked, but others provide no notice at all. Consider adding a message in your user interface that warns players that a pop-up blocker might prevent the page from opening.

**Method 1: Using Unity UI**

1. If you do not already have a [Canvas](UICanvas) GameObject in the Scene, add one. Unity automatically adds an [EventSystem](script-EventSystem) when you add the **Canvas**.

2. Drag the  **DataPrivacyButton** prefab to the __Canvas__ GameObject in the Scene. Find the prefab in the Project window, in the **Packages/Analytics Library/DataPrivacy** folder.

3. Adjust the position, graphics, and text of the button to suit.

4. The button is already connected to the Data Privacy API, so that it opens the player’s personal data management page when the player clicks it. The page opens in a web browser.

**Note:** The version of the button prefab under the **Packages** folder is read-only. You can make changes to the instance of the button in the **Scene** hierarchy, but you cannot save those changes back to the original prefab.


**Method 2: Using you own UI**

To use your own user interface for the button, you can request the URL of the user’s data opt-out page and then open that URL in a browser or web view:

1. Create your own UI control that informs the player of their ability to opt-out of data collection.

    **Note:** The Data Privacy plug-in includes an icon in the *Packages/Analytics Library/DataPrivacy* folder. Unity encourages you to use this icon on your data privacy button (or similar control) to provide a consistent graphical cue to players encountering data privacy controls in Unity games.

2. In response to the player’s click or interaction with this control, call the `DataPrivacy.FetchPrivacyUrl()` function. This function takes an `Action<string>` object that it invokes when the network request completes. You can optionally pass in a second `Action<string>` function to handle cases where the network request fails.

3. In your handler for the `FetchPrivacyUrl()` request, use `Application.OpenURL()` to open the URL received in a browser.

For example, the following script opens the Player Data Privacy page in response to a click on a GameObject:

```
using System;
using UnityEngine;
using UnityEngine.Analytics;
    
public class OptOutHandler : MonoBehaviour {

    static void OnFailure(string reason)
    {
        Debug.LogWarning(String.Format("Failed to get data privacy page URL: {0}", reason));
    }

    void OnURLReceived(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenDataURL()
    {
        DataPrivacy.FetchPrivacyUrl(OnURLReceived, OnFailure);
    }
    
    void OnMouseOver(){
        if(Input.GetMouseButtonUp(0)){
            OpenDataURL();
        }
    }
}
```

See [Unity Analytics DataPrivacy API](UnityAnalyticsDataPrivacyAPI) for more information.

---
* <span class="page-edit">2018-09-21  <!-- include IncludeTextNewPageSomeEdit --></span>
* <span class="page-history">Data Privacy plugin incorporated into Analytics package in 2018.3+.</span>
* <span class="page-history">Removed Editor menu command for inserting the Data Privacy button. Added the Data Privacy Button prefab.</span>
* <span class="page-history">New feature in Unity 2018.1</span>