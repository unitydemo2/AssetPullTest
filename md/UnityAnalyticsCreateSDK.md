Create Game Script
==================

Create Script to Start a Player Session 
---------------------------------------

In the Unity Editor, create a new C# script by going to:  
__Assets-&gt;Create-&gt;C# Script__  
Name the newly created script: __UnityAnalyticsIntegration__ (naming must be exact for the script to work correctly)

![](../uploads/Main/AnalyticsBasicCreateGameScript.gif)

Open Script and Copy Code
-------------------------

Double-click on the script to open your script in your external script editor. Completely replace the default generated code with the code below and save the file in the script editor. The Unity Project ID that you see in the sample code below is unique to your game. It is used to link your Editor project to your Analytics dashboard. 

[Go to the Analytics Dashboard to get your unique, functional Project ID](http://analytics.unity3d.com)

````
using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {

    // Use this for initialization
    void Start () {

        const string projectId = "SAMPLE-UNITY-PROJECT-ID";
        UnityAnalytics.StartSDK (projectId);

    }

}
````
---
* <span class="page-edit">2018-03-19  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">MonoDevelop replaced by Visual Studio from 2018.1</span>

