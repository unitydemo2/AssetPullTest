# Setting Up Analytics
Once you have [set up your project for Unity Services](https://docs.unity3d.com/Manual/SettingUpProjectServices.html), you can enable the Analytics service.

To do this, in the Services window, select __Analytics__ and then click the __OFF__ button to toggle it __ON__. If you haven’t already done so, at this stage you will need to complete the mandatory __Age Designation__ field for your project. (Again, you may have already done this for a different Unity Service, such as Ads). This age designation selection will appear in the Services window.

 
![](../uploads/Main/AnalyticsSetup1.png)

## Enabling Analytics within your project

You must then hit __Play__ in your project to validate the connection to Unity Analytics.
The Unity Editor acts as a test environment to validate your Analytics integration. With Analytics enabled, when you press the __Play__ button, the Editor sends data (an “App Start” event) to the analytics service. This means you can test your analytics without having to build and publish your game.
Once you have pressed play, you can check that your project was validated by going to the Analytics Dashboard for this project. To get there, in the services window, click Services -> Analytics -> Go To Dashboard.


![](../uploads/Main/AnalyticsSetup2.png)

 
The __Go to Dashboard__ button in the Analytics section of the Services window opens the dashboard in a web browser. The dashboard contains tools for visualizing, analyzing, and taking action based on your Analytics data. See [Analytics Dashboard](UnityAnalyticsDashboard). 

---
* <span class="page-edit">2017-08-29  <!-- include IncludeTextNewPageYesEdit --></span>
* <span class="page-history">New feature in Unity 2017.1</span>


