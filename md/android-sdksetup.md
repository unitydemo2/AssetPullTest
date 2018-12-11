# Android environment setup

Whether you’re building an Android application in Unity or programming it from scratch, you must set up the Android Software Development Kit (SDK) before you can build and run any code on your Android device. By default, Unity installs a Java Development Kit based on [OpenJDK](http://openjdk.java.net/).

## 1. Download the Android SDK

You can install the Android SDK using command line tools or through Android Studio. Android Studio provides an easy to use GUI based tool but installs additional software on your computer. Using the command line tools is a smaller download and does not install additional software, but it can be more challenging to use.

### 1a. Install the Android SDK using the command line tools

Install or unpack the Android SDK. After installing, open the Android SDK Manager and add at least one Android SDK Platform, the Platform Tools, the Build Tools, and the USB drivers if you’re using Windows.

To install an Android platform SDK and the associated tools:

1. Download the [Android Software command line tool](https://developer.android.com/studio/index.html#downloads).
2. Unzip the *tools* folder to a location on your hard drive.
3. Open a command-prompt window.
4. Navigate to the *bin* folder in the location where you unzipped the *tools* folder:

*install folder &gt; tools &gt; bin*

5. Use the [sdkmanager](https://developer.android.com/studio/command-line/sdkmanager.html) command line tool to retrieve the list of packages that you can install. The installable packages include the Platform SDKs, Build Tools, Platform tools, and other tools.

*sdkmanager --list*

6. Select a version of the Platform SDK to install. Platform SDKs take the following form in the list: *platforms;android-xx*. The *xx* indicates the SDK level. The larger the number, the newer the package. Typically, you can install the latest available version. However, there might be cases where Google has released a new version of the SDK that causes errors when you build your Unity Project. In that case, you must uninstall the SDK and install an earlier version. The general format of the command for package installation is *sdkmanager &lt;package name&gt;*. You can install the corresponding Platform Tools and Build Tools at the same time.

Example: *sdkmanager "platform-tools" "platforms;android-27" "build-tools;27.0.3"*

7. If you are running on Windows, install the USB device drivers:

*sdkmanager "extras;google;usb_driver"*

This installs the SDK to a directory named *platforms* in the same directory you unzipped the *tools* folder to.

Example:

*c:**&lt;**install folder&gt;\platforms*

### 1b. Install the SDK using Android Studio

Install Android studio from the [Android developer portal](https://developer.android.com/index.html). The Android developer portal provides detailed installation instructions.

__Note__: Android Studio provides some ease of use benefits, but it is not fully tested for compatibility with Unity installs. If you encounter errors, Unity recommends using the command line method.

When installing the Android platform SDK and other tools, you can typically install the latest available version. There might be cases in which Google has released a new version of the SDK that causes errors when you build your Unity Project. In that case, uninstall the SDK and install an earlier version.

Install the associated Platform and Build tools at the same time. If you are running on Windows, install the USB device drivers.

### 2. Enable USB debugging on your device

To enable USB debugging, you must first enable Developer options on your device. To do this, find the build number in your device’s __Settings__ menu. The location of the build number varies between devices; for stock Android, it’s usually in __Settings &gt; About phone &gt; Build number__. For specific information on your device and Android version, refer to your hardware manufacturer.

After you navigate to the build number using the instructions above, tap on the build number seven times. A pop-up notification saying "You are now X steps away from being a developer" appears, with "X" being a number that counts down with every additional tap. On the seventh tap, Developer options are unlocked.

__Note__: On Android versions prior to 4.2 (Jelly Bean), the Developer options are enabled by default. 

Go to __Settings &gt; Developer options__, then enable __USB debugging__. Android now enters debug mode when it is connected to a computer via USB.

Connect your device to your computer using a USB cable. If you are developing on a Windows computer, you might need to install the device-specific USB driver. See the manufacture website for your device for additional information.

The setup process differs for Windows and macOS and is explained in detail on the Android developer website. For more information on connecting your Android device to the SDK, refer to the [Running Your App](https://developer.android.com/training/basics/firstapp/running-app.html#Emulator) section of the Android Developer documentation.

### 3. Configure the Android SDK path in Unity

The first time you create a Project for Android (or if Unity later fails to locate the SDK), Unity asks you to locate the folder in which you installed the Android SDK.

If you installed the SDK using the sdkmanager, you can find the folder in *&lt;android tools install location&gt;\platforms&lt;android sdk folder&gt;*.

Example:

*c:&lt;android tools install location&gt;\platforms\android-27*

If you installed the SDK when you installed Android Studio, you can find the location in the Android Studio SDK Manager. To open the SDK Manager from Android Studio, go to __Tools &gt; Android &gt; SDK Manager__ or select __SDK Manager__ in the toolbar.

To change the location of the Android SDK, in the Unity menu bar go to __Unity &gt; Preferences &gt; External Tools__.

### 4. Download and set up the Android NDK

If you are using the [IL2CPP](https://docs.unity3d.com/Manual/IL2CPP.html) scripting backend for Android, you need the Android Native Development Kit (NDK). It contains the toolchains (such as compiler and linker) needed to build the necessary libraries and produce the output package (APK). If you are not targeting the IL2CPP backend, you can skip this step.

Download Android NDK version r16b (64-bit) from the [NDK Downloads](https://developer.android.com/ndk/downloads/older_releases) web page. Extract the *android-ndk-r16b* folder to a directory on your computer and note the location.

The first time you build a Project for Android using IL2CPP, Unity asks you to locate the folder in which you installed the Android NDK. Select the root folder of your NDK installation. To change the location of the Android NDK, in the Unity Editor, navigate to the menu: __Unity &gt; Preferences__ to display the Unity Preferences dialog box. Here, click __External Tools__.

## Using an alternate Java Development Kit

Unity recommends that you use the JDK installed with the Android build tools, to ensure that you receive the correct version and configuration.

If you have manually installed the JDK and do not want to duplicate the installation, you can specify the location in the Unity Preferences window. To do this, go to __Preferences &gt; External tools __and enter the directory path in the __JDK__ field:

![Preferences for Android external tools](../uploads/Main/PreferencesExternalToolsAndroid83.png)

__Warning__: The Android tools do not support JDK 9 or later; an alternate JDK must be version 8. Unity does not officially support versions of the JDK other than the one embedded in the Android Build Tools.

To change the JDK that Unity uses to build Android apps:

1. Open the Project.
2. Open the Preferences window:
    * In the Editor for Windows, navigate to __Edit__ &gt; __Preferences__.
    * In the Editor for the macOS, navigate to __Unity &gt; Preferences__.

3. In the left navigation column, select __External Tools__.
4. Uncheck __JDK Installed with Unity (recommended)__.
5. In the __JDK__ field enter the path to the JDK or use the __Browse__ button to locate it.

-------

<span class="page-edit">2018-11-21  <!-- include IncludeTextAmendPageYesEdit --></span>
