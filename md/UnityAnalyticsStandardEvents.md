# Standard Events

Use Standard Events to track user experience and player behavior across five major areas:

* __Application__: Track the usage of basic elements in your application user interface
* __Progression__: Track player progress through your application or game
* __Onboarding__: Track the earliest interactions players have with your application or game
* __Engagement__: Track important actions related to social sharing, achievements
* __Monetization__: Track revenue-related events as well as your in-game economies

The list of Standard Events covers a set of things that you might find useful to track in your games and applications. For example, most games have a concept of player progress, which could mean puzzles completed, matches played, RPG-type experience earned, or some other notion. By tracking standard progression events, you can better understand where players stop progressing and, ultimately, where they stop playing.

Most Standard Events define required and optional parameters that provide additional information about the state of your game when an Analytics event is sent. You can also define your own custom parameters. Setting parameters on your event allows you to filter data collected at the time the event occurred. Visualization tools for Standard and Custom Events can be viewed on the [Analytics Dashboard](UnityAnalyticsDashboard), including Data Explorer, Funnel Analyzer, and Segment Builder.

Unity Analytics limits the number of Standard and Custom Events it accepts to 100 per hour, per user. In other words, if a single user playing your game manages to trigger more than 100 Standard or Custom Events within an hour, Analytics discards the additional events. 


**Note**: To use Standard Events prior to Unity 2017.3, first download and import the [Standard Events SDK](https://assetstore.unity.com/packages/add-ons/services/analytics/unity-analytics-standard-events-91846) from the Unity Asset store. 

## Application events

Application events track player interaction with the application outside of the game itself (for example, in the menu or cut-scene screens before or after a level). You can analyze application events to see whether players use the basic parts of your user interface as often as you expect. 

| **Event name** | **Purpose** |
| :--- | :--- |
| screen_visit | Player opened a screen in the UI, such as a high score or settings screen. |
| cutscene_start | Player began watching a cinematic cutscene. |
| cutscene_skip | Player skipped past a cinematic cutscene. |

## Progression events
Progression events track players as they advance through your game. Analyze standard progression events to monitor player progress in your game. 

| **Event name** | **Purpose** |
| :--- | :--- |
| game_start | Player began a new game (useful for games with a distinct beginning and ending). |
| game_over | Player ended the game (useful for games with a distinct beginning and ending). |
| level_start | Player started a level. |
| level_complete | Player successfully completed a level. |
| level_fail | Player lost a level. |
| level_quit | Player quit out of a level. |
| level_skip | Player skipped past a level. |
| level_up | Player increased in rank or RPG-style experience level. |

## Onboarding events
Onboarding events track the first-time user experience (FTUE). Analyze standard onboarding events to monitor the effectiveness of your tutorials.

| **Event name** | **Purpose** |
| :--- | :--- |
| first_interaction | Player completed any interaction after opening the game for the first time. |
| tutorial_start | Player began a tutorial. |
| tutorial_step | Player passed a milestone in a tutorial. |
| tutorial_complete | Player completed a tutorial. |
| tutorial_skip | Player skipped a tutorial. |

 
## Engagement events
Engagement events help you understand whether your players are engaging with your game, and whether they're performing actions highly correlated with retention and virality. 

| **Event name** | **Purpose** |
| :--- | :--- |
| push_notification_enable | Player enabled push notifications. |
| push_notification_click | Player responded to a pushed message. |
| chat_msg_sent | Player sent a chat message. |
| achievement_unlocked | Player completed an achievement. |
| achievement_step | Player completed a milestone towards an achievement. |
| user_signup | Player connected with a social network. |
| social_share | Player shared something such as an invite or gift through a social network. |
| social_accept | Player accepted something shared through a social network. |

## Monetization events

Monetization events track income and game economy to help you balance your resources and improve sources of revenue.

| **Event name** | **Purpose** |
| :--- | :--- |
| store_opened | Player opened a store. |
| store_item_click | Player selected an item in a store. |
| iap_transaction | Player spent real-world money to make an in-app purchase. | 
| item_acquired | Player acquired a resource within the game. | 
| item_spent | Player expended an item within the game. |
| ad_offer | Player had an opportunity to watch an ad. | 
| ad_start | Player started watching an ad. |
| ad_complete | Player finished watching an ad. |
| ad_skip | Player skipped an ad before completion. |
| post_ad_action | Player completed an action prompted by an ad. |

## Scripting Standard Events

To dispatch a Standard event from a script, add the following namespace:

    using UnityEngine.Analytics;

Note: When using the Standard Events SDK from the Unity Asset store, use the namespace `UnityEngine.Analytics.Experimental` instead.

Now you can dispatch Standard Events using the [AnalyticsEvent](ScriptRef:Analytics.AnalyticsEvent.html) class. Each Standard Event has a corresponding static function. For example, to send the game_start event, call the following function:

```
AnalyticsEvent.GameStart();
```

Many Standard Events have required parameters, and several have optional parameters. You can also add your own additional parameters in a dictionary. For example, if you wanted to track what screens players visit using the ScreenVisit event, but also wanted to track which screen they visited from, you can pass that information in a dictionary object:

```
public static void ReportScreenVisit(string screenName, string currentScreenName)
{
    AnalyticsEvent.ScreenVisit(screenName, new Dictionary<string, object>
    {
        { "from_screen", currentScreenName }
    });
}
```

The total number of required parameters, optional parameters (only counting those that you use) and additional parameters cannot exceed ten. In other words, if an event function has 2 required parameters and you set 1 out of 2 optional parameters, you can pass a dictionary containing up to seven additional key-value pairs to the function. If you set both of the optional parameters in the same event, then your dictionary could only contain six key-value pairs. 

**Standard Event code example**

The following class provides an example that uses the standard MonoBehaviour event functions to dispatch the Standard Events related to starting and ending levels. 

The [Awake](ScriptRef:MonoBehaviour.Start.html) function dispatches the level_start event. The example provides both the level name and the level index, but only one is required. The example also uses the name and index from the [Scene](ScriptRef:SceneManagement.Scene.html) object, but you can use different values. 

The [OnDestroy](ScriptRef:MonoBehaviour.OnDestroy.html) function dispatches a level_complete, level_fail, level_skip, or level_quit event, based on the current level state value (which, in a real game, would be set by other code in the level using the `SetLevelPlayState()` function defined in this example). The example adds some additional parameters to these events using a dictionary called “customParams”. 

```
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LevelEventManager : MonoBehaviour {
    public enum LevelPlayState {InProgress, Won, Lost, Skip, Quit}

    private Scene thisScene;
    private LevelPlayState state = LevelPlayState.InProgress;
    private int score = 0;
    private float secondsElapsed = 0;
    private int deaths = 0;

    void Awake () {
        thisScene = SceneManager.GetActiveScene();
        AnalyticsEvent.LevelStart(thisScene.name, 
                                      thisScene.buildIndex);
    }

    public void SetLevelPlayState(LevelPlayState newState){
        this.state = newState;
    }

    public void IncreaseScore(int points){
        score += points;
    }

    public void IncrementDeaths(){
        deaths++;
    }

    void Update(){
        secondsElapsed += Time.deltaTime;
    }

    void OnDestroy(){
        Dictionary<string, object> customParams = new Dictionary<string, object>();
        customParams.Add("seconds_played", secondsElapsed);
        customParams.Add("points", score);
        customParams.Add("deaths", deaths);

        switch(this.state){
        case LevelPlayState.Won:
            AnalyticsEvent.LevelComplete(thisScene.name,
                                             thisScene.buildIndex, 
                                             customParams);
            break;
        case LevelPlayState.Lost:
            AnalyticsEvent.LevelFail(thisScene.name,
                                         thisScene.buildIndex, 
                                         customParams);
            break;
        case LevelPlayState.Skip:
            AnalyticsEvent.LevelSkip(thisScene.name,
                                         thisScene.buildIndex, 
                                         customParams);
            break;
        case LevelPlayState.InProgress:
        case LevelPlayState.Quit:
        default:
            AnalyticsEvent.LevelQuit(thisScene.name,
                                         thisScene.buildIndex, 
                                         customParams);
            break;
        }
    }
}
```

Note that this example only uses the custom parameter dictionary created in `OnDestroy()` once. However, when you dispatch an event that uses such a dictionary frequently, you should create a single instance of the dictionary and reuse it rather than creating a new dictionary each time. Reusing the dictionary object reduces memory allocations that must be garbage collected in a future frame. See [Analytics Event Parameters](UnityAnalyticsEventParameters) for more information.

---

* <span class="page-edit">2018-03-02 <!-- include IncludeTextNewPageNoEdit --></span>

* <span class="page-edit">2018-03-02 - Service compatible with Unity 5.2 onwards at this date but version compatibility may be subject to change</span>

* <span class="page-history">New feature in 5.2</span>

