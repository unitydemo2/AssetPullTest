# Unity licenses for PS4 development

Unity has a licensing model for PS4 that uses specific Unity license keys for Sony platforms, because you cannot use regular Unity license keys to develop on Sony systems. Sony provides these license keys free of charge.

## Types of license key

There are two types of Unity licenses for PS4: __development__ and __publishing__. The development license is designed for you to use while developing and testing your game. The publishing license is designed for you to use only when submitting your game to Sony’s Global Format Quality Assurance (GFQA).

The main differences are:

| | __Development license__ | __Publishing license__ |
|:---|:---|:---| 
| __Behavior when creating a Unity PS4 package build__| You cannot create the files required for final submission; only the PKG file. | You can create a PKG file, and the final submission files *spec.xml* and *submission-materials.zip*. |
| __Behavior when running on a PS4 devkit__| A *Trial Version *watermark appears on the lower-right corner of the screen.  | No on-screen watermark appears on the screen. |
| __Expiry__| Development licenses have no deactivation limits and renew yearly. | Publishing licenses have a limited short-term use, after which they deactivate. If your publishing license expires, you must request an extension or a new license key through your Sony Account Manager. |

## Requesting a Unity license for PS4

To request development or publishing license keys, contact your Sony Account Manager directly. Alternatively, follow the steps below to request a key from PS4 Private Support.

### Request through PS4 Private Support

To request a Unity license key for PS4 through the Sony PS4 Private Support system on DevNet:

1. From the main [PS4 development homepage](https://ps4.siedev.net/), go to __Support__ > __Private support __

2. Click __+Post new Issue__ 

3. Click __Post an issue to your default support group (SIEE/SIEA Support)__

4. Fill out the form as follows:

    * __Issue type__: Support Request

    * __Categories__: Unity Licensing

    * __Summary__: Unity License Key request

    * __Project__: The name of the project you are working on. 

    * __Message__: Specify whether you want a development or publishing license key.

5. Send the request. Sony should email you with your key after processing your application. 

## Activating a Unity license for PS4

You can activate a Unity license for PS4 just like any other Unity license. This overrides any other license key you have on your machine. There is no way to carry out a manual activation for a Unity license for PS4; you must be connected to the internet.

To activate a Unity license for PS4, follow the procedure described in the documentation on [Online Activation](OnlineActivationGuide). Unity licenses for PS4 work on their own and are not connected to any specific Unity ID account. License keys work on multiple machines; you do not need to tie them to an account, and they do not appear in your Unity ID account system.

## Switching between PS4 and other platform licenses

A Unity license for PS4 can only build projects for PS4 and for Standalone platforms (PC, OSX, and Linux). 

To build your project on a different platform, you need to switch your PS4 license key to another license. To do this, return the Unity license for PS4, and activate another, following the procedure described in the documentation on [Managing your Unity License](ManagingYourUnityLicense). You can also automate this process with[ Command Line Arguments](CommandLineArguments), using the commands `–returnLicense` and `–serial <key>`.

