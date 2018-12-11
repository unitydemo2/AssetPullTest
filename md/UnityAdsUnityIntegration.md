# Unity developer integration

<a name="overview"></a>
## Overview
This guide covers integration for implementing Unity Ads in your made-with-Unity game.

* If you are an iOS developer using Objective-C, [click here](https://unityads.unity3d.com/help/ios/integration-guide-ios). 
* If you are an Android developer using Java, [click here](https://unityads.unity3d.com/help/android/integration-guide-android). 

Unity’s monetization platform provides you with powerful revenue tools. If your game uses in-app purchases as well as ads, Unity’s machine learning data model can seamlessly blend content types for an optimized monetization strategy. To learn more about how Unity helps you optimize revenue, see documentation on [**Personalized Placements**](https://unityads.unity3d.com/help/monetization/placements). 

In this guide:

* Basic ads implementation
* [Rewarded ads implementation](#implementing-rewarded-ads)
* [Banner ads implementation](#implementing-banner-ads)
* [Testing your implementation](#testing)
* [Advanced monetization suggestions](#optimizing-your-revenue)
* [API reference](#unity-api-reference)

<a name="basic-implementation"></a>
## Basic implementation
<a name="configuring-your-projects"></a>
### Configuring your Project
<a name="Setting-build-targets"></a>
#### Setting build targets
Configure your Project for a supported platform using the [Build Settings window](https://docs.unity3d.com/2018.1/Documentation/Manual/BuildSettings.html). Set the platform to **iOS** or **Android**, then click **Switch Platform**.

![Setting build targets in the Unity Editor](https://github.com/Applifier/unity-ads/wiki/unity/BuildTargets.png)

<a name="installing-unity-ads"></a>
#### Installing Unity Ads
To ensure the latest version of Unity Ads, [download](https://assetstore.unity.com/packages/add-ons/services/unity-ads-66123) it from the Asset store. The Monetization API requires SDK 3.0 or later. For information on downloading and installing Asset packages, see [Asset packages documentation](https://docs.unity3d.com/2018.1/Documentation/Manual/AssetPackages.html).

<a name="creating-a-placement"></a>
### Creating a Placement
[Placements](https://unityads.unity3d.com/help/monetization/placements) are triggered events within your game that display monetization content. Manage Placements from the **Operate** tab of the [Developer Dashboard](https://operate.dashboard.unity3d.com/) by selecting your Project, then selecting **Monetization** > **Placements** from the left navigation bar.

Click the **ADD PLACEMENT** button to bring up the Placement creation prompt. Name your Placement and select its type:

* Select **Non-rewarded** to show basic interstitial ads or promotional content. Non-rewarded Placements allow players to skip the ad after a specified period of time.
* Select **Rewarded** to allow players to opt-in to viewing ads in exchange for incentives. Rewarded Placements do not allow the player to skip the ad.
* Select **Banner** to create a dedicated Banner ad Placement. 

Every Unity Ads-enabled project has a (non-rewarded) ‘```video```’ and (rewarded) ‘```rewardedVideo```’ Placement by default. Feel free to use one of these for your first implementation if they suit your needs, or create your own.

<a name="initializing-the-sdk"></a>
### Initializing the SDK
To initialize the SDK, you must reference your Project’s Game ID for the appropriate platform. You can locate the ID on the **Operate** tab of the [Developer Dashboard](https://operate.dashboard.unity3d.com/) by selecting the Project, then selecting **Monetization** > **Platforms** from the left navigation bar. 

![Locating your Game ID in the Developer Dashboard](https://github.com/Applifier/unity-ads/wiki/unity/GameID.png)

In your game script header, include the [```UnityEngine.Monetization```](#monetization) namespace. Initialize the SDK early in the game’s run-time life cycle, preferably at launch, using the [```Initialize```](#initialize) function. For example:

```
using UnityEngine.Monetization;

public class UnityAdsScript : MonoBehaviour { 

    string gameId = "1234567";
    bool testMode = true;

    void Start () {
        Monetization.Initialize (gameId, testMode);
    }
}
```

### Implementing basic (non-rewarded) ads
[```PlacementContent```](#placementcontent) is an object representing monetization content that your Placement can display (for more information, see documentation on [Content types](https://unityads.unity3d.com/help/monetization/content-types) and [Personalized Placements](https://unityads.unity3d.com/help/monetization/placements#personalized-placements)). Use the [```GetPlacementContent```](#getplacementcontent) function to retrieve content when it’s ready to display, and the [```Show```](#show) function to display it. For example:

```
using UnityEngine.Monetization;

public class UnityAdsPlacement : MonoBehaviour {

    public string placementId = "video";

    public void ShowAd () {
        StartCoroutine (ShowAdWhenReady ());
    }

    private IEnumerator ShowAdWhenReady () {
        while (!Monetization.IsReady (placementId)) {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;

        if(ad != null) {
            ad.Show ();
        }
    }
}
```

In this example, the coroutine checks the passed Placement ID for available ```PlacementContent``` using the [```IsReady```](#isready) function. If content is available, it’s stored as a variable and executed with the Show function. 
<a name="implementing-rewarded-ads"></a>
### Implementing rewarded ads
Rewarding players for watching ads increases user engagement, resulting in higher revenue. For example, games may reward players with in-game currency, consumables, additional lives, or experience-multipliers. For more information on how to effectively design your rewarded ads, see documentation on [Ads best practices](https://unityads.unity3d.com/help/resources/best-practices).

To reward players for watching ads, follow the same steps as detailed in the basic implementation section, but show the ad using a reward callback method with custom logic for players completing the ad.

<a name="selecting-a-placement"></a>
#### Selecting a Placement
You must display rewarded ads through [Rewarded Placements](https://unityads.unity3d.com/help/monetization/placements#placement-types). Every Unity Ads-enabled Project also has a ‘```rewardedVideo```’ Placement by default. Feel free to use this for your implementation, or [create your own](https://unityads.unity3d.com/help/monetization/placements#creating-new-placements) (but make sure your Placement is configured as Rewarded).

<a name="adding-a-callback-method-to-your-script"></a>
#### Adding a callback method to your script
The ```Show``` function accepts a callback that the SDK uses to return a [```ShowResult```](#showadcallbacks) enum. This result indicates whether the player finished or skipped the ad. Use this information to write a custom function for how to handle each scenario. For example: 

```
using UnityEngine.Monetization;

public class RewardedAdsPlacement : MonoBehaviour {

    public string placementId = "rewardedVideo";

    public void ShowAd () {
        StartCoroutine (WaitForAd ());
    }

    IEnumerator WaitForAd () {
        while (!Monetization.IsReady (placementId)) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;

        if (ad != null) {
            ad.Show (AdFinished);
        }
    }

    void AdFinished (ShowResult result) {
        if (result == ShowResult.Finished) {
            // Reward the player
        }
    }
}
```

<a name="rewarded-ads-button-code-example"></a>
#### Rewarded ads button code example
Rewarded ads usually use a button that prompts players to opt in to watching the ad. The following describes how to create a rewarded ads button that displays an ad when pressed, as long as content is available.

1. In the Unity Editor, select **Game Object** > **UI** > **Button** to add a Button to your Scene.
2. With the Button selected, in the Inspector, click **Add Component** > **New Script** to add a script component to it. Name the script *UnityAdsButton* to match the class name.
3. Open the script and add the following example code: 

```
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;

[RequireComponent (typeof (Button))]
public class UnityAdsButton : MonoBehaviour {

    public string placementId = "rewardedVideo";
    private Button adButton;

#if UNITY_IOS
   private string gameId = "1234567";
#elif UNITY_ANDROID
    private string gameId = "7654321";
#endif

    void Start () {
        adButton = GetComponent<Button> ();
        if (adButton) {
            adButton.onClick.AddListener (ShowAd);
        }

        if (Monetization.isSupported) {
            Monetization.Initialize (gameId, true);
        }
    }
  
    void Update () {
        if (adButton) {
            adButton.interactable = Monetization.IsReady (placementId);
        }
    }

    void ShowAd () {
        ShowAdCallbacks options = new ShowAdCallbacks ();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
        ad.Show (options);
    }

    void HandleShowResult (ShowResult result) {
        if (result == ShowResult.Finished) {
            // Reward the player
        } else if (result == ShowResult.Skipped) {
            Debug.LogWarning ("The player skipped the video - DO NOT REWARD!");
        } else if (result == ShowResult.Failed) {
            Debug.LogError ("Video failed to show");
        }
    }
}
```

**Note**: This example checks at a specific point in the game whether PlacementContent is ready to display. As an alternate method, you can implement a listener to notify you when content is available.

<a name="implementing-banner-ads"></a>
### Implementing Banner ads
<a name="placement-configuration"></a>
#### Placement configuration
Banner ads require a specific type of dedicated banner Placement. Banners currently display anchored on the bottom-center of the screen. 

![Example of a banner ad in-game](https://github.com/Applifier/unity-ads/wiki/unity/BannerExample.png)

<a name="script-implementation"></a>
#### Script implementation
In your Placement script header, declare the [```UnityEngine.Advertisement```](https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Advertisements.Advertisement.html) namespace, which contains the [```Banner```](#banner) class. Next, initialize the SDK and use ```Advertisement.Banner.Show ()``` to display a banner ad. For example:

```
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour {

    public string bannerPlacement = "banner";
    public bool testMode = false;

#if UNITY_IOS
    public const string gameID = "1234567";
#elif UNITY_ANDROID
    public const string gameID = "1234568";
#elif UNITY_EDITOR
    public const string gameID = "1111111";
#endif

    void Start () {
        Advertisement.Initialize (gameID, testMode);
        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady ("banner")) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.Show (bannerPlacement);
    }
}
```

<a name="testing"></a>
## Testing
Prior to publishing your game, enable test mode by following these steps: 

1. From the **Operate** tab of the [Developer Dashboard](https://operate.dashboard.unity3d.com/), select your Project.
2. Select **Monetization** > **Platforms** from the left navigation bar.
3. Select the desired platform, then select the **SETTINGS** tab.
4. Scroll down to the **TEST MODE** section and toggle override client test mode, then select the **Force test mode ON** radio button.

In the Unity Editor, click the play button to run your Project and test your ads implementation.

**Note**: You must enable test mode before testing ads integration, to avoid getting flagged for fraud.

## Optimizing your revenue
Congratulations on implementing Unity Ads! Our goal is to make it easy for you to maximize your revenue. With that in mind, consider these next steps:

* Does your game use in-app purchasing (IAP)?
    * If yes, implement [IAP Promo](https://docs.unity3d.com/2018.1/Documentation/Manual/IAPPromo.html) to promote your in-app offers.
    * If no, create an in-app store with [Unity IAP](https://docs.unity3d.com/2018.1/Documentation/Manual/UnityIAP.html).
* When you have Ads and IAP Promo set up, use [Personalized Placements](https://unityads.unity3d.com/help/monetization/placements#personalized-placements) to turbocharge your ads and IAP strategy and provide revenue lift for your entire game.
* Review our [Best practices](https://unityads.unity3d.com/help/resources/best-practices) guide for insight on how to design effective ad mechanics.

[Back to top](#overview)

<a name="unity-api-reference"></a>
## Unity API reference
<a name="monetization"></a>
### ```Monetization```
<a name="initialize"></a>
#### ```Initialize```
Initializes the SDK for your Project.

```
public static void Initialize (string gameID, bool testMode)
```

The ```gameId``` parameter is the Project’s Game ID, which you can [find on the Developer Dashboard](#initializing-the-sdk). The ```testMode``` parameter indicates whether the game is in test mode. When ```testMode``` is ```true```, you will only see test ads. When ```testMode``` is ```false```, you will see live ads. It is important to use test mode prior to launching your game, to avoid being flagged for fraud.

<a name="isready"></a>
#### ```IsReady```
Checks if ```PlacementContent``` is ready for the given Placement. 

```
public static boolean IsReady (string placementId);
```

The ```placementId``` parameter is the [Placement ID as configured in the Developer Dashboard](https://unityads.unity3d.com/help/monetization/placements#creating-new-placements). The function returns ```true``` if the ```PlacementContent``` is ready, or ```false``` if it isn’t.

<a name="getplacementcontent"></a>
#### ```GetPlacementContent```
Returns the ```PlacementContent``` object for the given Placement.

```
public static PlacementContent GetPlacementContent (string placementId);
```

The ```placementId``` parameter is the [Placement ID as configured in the Developer Dashboard](https://unityads.unity3d.com/help/monetization/placements#creating-new-placements). The function returns a ```PlacementContent``` object if one is available, or null if it isn’t.

**Note**: When setting the ```PlacementContent``` as a variable, you must cast it as the correct type ([```ShowAdPlacementContent```](#showadplacementcontent) or [```PromoAdPlacementContent```](#promoadplacementcontent)). For more information, see documentation on [content types](https://unityads.unity3d.com/help/monetization/content-types).

<a name="imonetizationlistener"></a>
### ```IMonetizationListener```
An interface that you implements and pass to the SDK.

```
public interface IMonetizationListener {   
    void OnPlacementContentReady (string placementId, PlacementContent placementContent);   
    void OnPlacementContentStateChange (string placementId, PlacementContent placementContent, Monetization.PlacementContentState previousState, Monetization.PlacementContentState newState);
}
```

<a name="onplacementcontentready"></a>
#### ```OnPlacementContentReady```
Takes a Placement ID and ```PlacementContent``` object, and dictates how the SDK handles content that is ready to show.

<a name="onplacementcontentstatechange"></a>
#### ```OnPlacementContentStateChange```
Dictates how the SDK handles a state change in the passed ```PlacementContent```.  

<a name="setlistener"></a>
#### ```SetListener```
Sets the listener for ```PlacementContent``` events. The listener parameter is the listener for event callbacks.

```
public static void SetListener (IMonetizationListener listener);
```

<a name="getlistener"></a>
#### ```GetListener```
Returns the current Monetization listener. The listener object is the listener for event callbacks.
   
```
public static IMonetizationListener GetListener ();
```

<a name="placementcontent"></a>
### ```PlacementContent```
An object representing monetization content that your Placement can display. 

<a name="rewardableplacementcontent"></a>
#### ```RewardablePlacementContent``` 
Extends the ```PlacementContent``` class, providing extensions for rewardable content.

<a name="showadplacementcontent"></a>
#### ```ShowAdPlacementContent```
Extends the ```RewardablePlacementContent``` class, providing functionality for video ad content.

<a name="show"></a>
#### ```Show```
When ```PlacementContent``` is cast as ```ShowAdPlacementContent```, display it using the ```Show``` function. You may pass a [callback method](#showadcallbacks) indicating whether the ad was finished, skipped, or failed to display, in order to handle in-game rewards.

```
public void Show (ShowAdCallbacks showAdCallbacks)

public void Show (ShowAdFinishCallback finishCallback)
```

For rewarded ```PlacementContent```, use listeners to check if the content completes and handle the desired behavior.

<a name="showadcallbacks"></a>
#### ```ShowAdCallbacks```
A ```ShowResult``` enum is passed to ```[[ShowOptions.resultCallback]]``` after the ad runs.

| Value | Description |
| ----- | ----------- |
| ```Finished``` | Indicates that the player watched the ad to completion. |
| ```Skipped``` | Indicates that the player did not allow the ad to complete. |
| ```Failed``` | Indicates that the ad failed to display. |

```
public delegate void ShowAdFinishCallback (ShowResult finishState);

public delegate void ShowAdStartCallback ();

public struct ShowAdCallbacks {
    public ShowAdFinishCallback finishCallback;
    public ShowAdStartCallback startCallback;
}
```

<a name="promoadplacementcontent"></a>
#### ```PromoAdPlacementContent``` 
Extends the ```ShowAdPlacementContent``` class, providing functionality for [IAP Promo](https://docs.unity3d.com/2018.1/Documentation/Manual/IAPPromo.html) content. For more information, see documentation on [**Native Promo**](https://unityads.unity3d.com/help/beta/native-promo).

<a name="banner"></a>
### ```Banner```
<a name="load"></a>
#### ```Load```
The basic method for loading banner ad content. You can adjust this function with several parameters, depending on your needs.

| Method | Description |
| ------ | ----------- |
| ```public static void Load ()``` | Loads the banner ad with the default Placement ID and no callbacks. |
| ```public static void Load (BannerLoadOptions options)``` | Loads the banner ad with the default Placement ID, but fires the [```loadCallback```](#bannerloadoptions) callback on successful load, and the [```errorCallback```](#bannerloadoptions) callback on failure to load. |
| ```public static void Load (string placementID)``` | Loads the banner ad with a specific Placement ID, with no callbacks. |
| ```public static void Load (string placementID, BannerLoadOptions options)``` | Loads the banner ad with a specific Placement ID, but fires the [```loadCallback```](#bannerloadoptions) callback on successful load, and the [```errorCallback```](#bannerloadoptions) callback on failure to load. |
| ```public static bool isLoaded ()``` | Checks to see if the content successfully loaded and is ready to display. |

<a name="bannerloadoptions"></a>
##### ```BannerLoadOptions```
Pass these options back to the SDK to notify it of events when loading the banner.

| Callback | Description |
| -------- | ----------- |
| ```public LoadCallback loadCallback { get; set; }```  | Fires when the banner ad is loaded and available to show. |
| ```public ErrorCallback errorCallback { get; set; }``` | This callback fires when an error occurs during the banner ad loading process. If this callback is invoked, assume the banner did not load. You may attempt to call Load again at a later time. |

#### ```Show```
The basic method for displaying Banner ad content. You can adjust this function with several parameters, depending on your needs.

| Method | Description |
| ------ | ----------- |
| ```public static void Show ()``` | Shows the banner ad with the default Placement ID and no callbacks. |
| ```public static void Show (BannerOptions options)``` | Shows the banner ad with the default Placement ID, but fires the [```showCallback```](#banneroptions) callback when the content is visible, and the [```hideCallback```]((#banneroptions) callback when the content is hidden. |
| ```public static void Show (string placementID)``` | Shows the banner ad with a specific Placement ID, with no callbacks. |
| ```public static void Show (string placementID, BannerLoadOptions options)``` | Shows the banner ad with a specific Placement ID, but fires the [```showCallback```](#banneroptions) callback when the content is visible, and the [```hideCallback```]((#banneroptions) callback when the content is hidden. |

<a name="banneroptions"></a>
##### ```BannerOptions```
Pass these options back to the SDK to notify it of events within the banner.

| Callback | Description |
| -------- | ----------- |
| ```public BannerCallback showCallback { get; set; }```  | This callback fires when the banner ad is visible to the player. |
| ```public BannerCallback hideCallback { get; set; }``` | This callback fires when the banner ad is hidden from the player. |

<a name="hide"></a>
#### ```Hide```
This function allows you to hide a banner ad, instead of destroying it altogether.

```
public static void Hide (bool destroy = false);
```

[Back to top](#overview)

-----
* <span class="page-edit">2018-11-13  <!-- include IncludeTextNewPageYesEdit --></span>

