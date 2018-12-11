# Importing and activating the Target Database in Unity

In the Unity Editor, navigate to __Asset__ &gt; __Import Package__ &gt; __Custom Package__ and find the package on your hard drive. In the __Import Unity Package__ window, click the __Import__ button.

Select the __ARCamera__ from the __Hierarchy window__ and, in the __Inspector window__, navigate to the __Vuforia Behaviour (Script)__ component and click on the __Open Vuforia configuration__ button. 

![Accessing Vuforia configuration settings](../uploads/Main/vuforia_config_settings.jpg)

In the __Vuforia Configuration__ window, under __Datasets__, select and check both the __Load [DatabaseName] Database__ and __Activate__ checkboxes. This activates your Image Target database for use with Unity.

![Activating imported Image Target database](../uploads/Main/activate_database.png)

---
* <span class="page-edit">2018-03-28 <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Vuforia documentation updated for Unity XR API in 2017.3</span>