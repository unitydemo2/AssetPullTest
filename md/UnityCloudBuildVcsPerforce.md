# Using the Unity Developer Dashboard to configure Unity Cloud Build for Perforce

Unity Cloud Build supports Projects stored in [Perforce](https://www.perforce.com/) repositories.

**Note**: This feature requires a subscription to Unity Teams Advanced. For more information, see the [Unity Teams](https://unity3d.com/teams) page.

This topic covers:

* [Configuring Perforce in the Dashboard](http://localhost:8090/#configure)
* [Setting up a target build platform](http://localhost:8090/#target)

## Configuring Perforce on the Dashboard

To configure Cloud Build to build your Project from a Perforce repository:

1. Sign in to the [Unity Developer Dashboard](https://developer.cloud.unity3d.com/).
2. On the __Projects__ page, select your Project.
3. In the dashboard __Overview__ window, on the __Cloud Build__ tile, click __OPEN CLOUD BUILD DASHBOARD__.
4. In the __Build History__ window, click __Set up Cloud Build__.
5. In the __Source Control__ window, click the __MANUAL__ tab.
6. In the __SCM URL__ field, enter the URL of your Perforce server in either of the following formats:

    * Non-SSL: host:port
    * SSL: ssl:host:port

7. To connect to your repository, you must specify the URL to your Perforce server. For information on the format of the URL, see the __URL syntax__ section below.
8. From the __SCM Types__ drop-down menu, select __Perforce__.
9. Click the __NEXT: ACCESS__ button. When Unity Cloud Build connects to the hosting site, it automatically detects whether your repository is public or private. If your repository is public, Cloud Build automatically connects to it and you can skip to [Setting up a target build platform](#targetplatforms).
10. On the the __Grant us access to your source control__ window, enter the user __Username__ and __Password__ for your Perforce repository.
11. Click __NEXT: TARGET SETUP__.

**URL syntax**

To connect to your repository, you must specify the URL to your Perforce server. You can specify the URL to use the following protocols:

* HTTPS
* SSL

The following are examples of valid URLs:

* https://127.0.0.1:1667
* ssl:127.0.0.1:167

<a name="targetplatforms"></a>
## Setting up a target build platform

In the dashboard, on the __NEW BUILD TARGET: BASIC INFO__ window:

1. In the __Target Label__ field, enter a name for the build.
2. From the __Client Workspace__ drop-down menu, select the workspace from which to build your Project.
3. If the root folder of your repository doesn't contain your Assets and Project settings, in the __Project Subfolder__ field, enter the URL of the folder that contains your Assets and Project settings.
4. From the __Unity Version__ drop-down menu, select the version of Unity with which to build the Project.
5. If you do not want the Project to automatically build whenever your repository is updated, click the __Auto-build__ toggle to disable this feature. If you are building for the iOS or Android platforms, your next step is to enter credentials for the build. Click __Next: Credentials__. For all other platforms, click __Next: Build__ to complete the configuration and start the initial build.

**Android credentials**

In the Android __SIGNING CREDS__ window supply the following information:

* A __Bundle ID__ to uniquely identify your app on the device and in Google Play Store.
* Enter your Android keystore credentials or select __Auto Generated Debug Keystore__ to use a development keystore. For more information on Android keystores, see [Android Keystore System](https://developer.android.com/training/articles/keystore.html).

**iOS Credentials**

In the iOS __SIGNING CREDS__ window supply the following information:

* A __Bundle ID__ to uniquely identify your app on the device.
* The Xcode version with which to build the app.
* Enter your iOS credentials. For more information on iOS credentials, see [Building for iOS](UnityCloudBuildiOS).