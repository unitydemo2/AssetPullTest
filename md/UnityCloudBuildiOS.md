#Building for iOS

Unity Cloud Build helps you automate the process of building your Unity Project for iOS devices.

This article describes the prerequisites necessary to build your Project for iOS  and how to create the supporting components to configure Cloud Build. Topics covered include:

* Joining the Apple Developer Program
* Creating an iOS certificate and and p12 file
* Adding devices to your profile
* Creating a provisioning profile
* Configuring your app to build for iOS


## Joining the Apple Developer Program

To develop iOS apps, you must be a member of the iOS Developer Program. The cost is currently $99 per year, and allows you to build, test, and eventually release your apps in the Apple App Store.

**Note**: You must have an Intel-based Mac running OS X Yosemite (v10.10) or later to develop and distribute iOS apps and Mac apps.

To join the iOS Developer program:

1. Log in to the [Apple Developer Program](https://developer.apple.com/programs/) page.

    **Important**: Use the Safari browser. You might encounter issues if you use the Chrome or Firefox browsers.

1. Click the **Enroll** button.
1. Read the information on the **What You Need To Enroll** page and then click the **Start Your Enrollment** button.
1. Log in with your Apple ID, or create a new Apple ID if you don't have one
1. Choose whether to enroll for an Individual/Sole Proprietor/Single Person Business or as a Company/Organization
    1. **Individual/Sole Proprietor/Single Person Business**: Select this option if you are an individual or sole proprietor/single person company.
    1. **Company/Organization**: Select this option if you are a company, non-profit organization, joint venture, partnership, or government organization.
1. Enter your contact information and any requested business information.
1. Read the license agreement. If you agree to the terms, check the acceptance checkbox and click the **Continue** button.
1. Purchase the program

    **Note**: You cannot access the Apple Developer Program until your membership has been approved. Apple typically takes around 24 hours to approve your membership.

1. Activate the Program

After you sign in to the Apple Program Developer portal, you'll see a list labeled **Program Resources** on the left. **Click Certificates, IDs & Profiles** to manage the certificates, identifiers, profiles, and devices you need to develop and distribute apps.

## Provisioning profiles

A provisioning profile ties developers and devices to an authorized Development Team and enables you to use a device for testing. You must install a *Development Provisioning Profile* on each device on which you plan to run your application code.

Each Development Provisioning Profile contains a set of *Development Certificates, Unique Device Identifiers (UDID)* and an App ID.

To use a device for testing,  you must also include your Development Certificate in the profile. A single device can contain multiple provisioning profiles.

## Components of a provisioning profile

Certificates determine whether your app is development-only or a release candidate for the App Store. You should use an Ad Hoc Production Certificate so that you can test all the features of your game (like GameCenter, etc).

Identifiers are the unique IDs that you use to identify your project. For basic projects, or if this is your first iOS project, you'll probably want to make an App ID. This is often the same as your Unity3D Project's Bundle ID.

**Tip**: For more information on signing identities and certificates, see [Maintaining Your Signing Identities and Certificates](https://help.apple.com/xcode/mac/current/#/dev3a05256b8) on the Apple developer website.

Devices are the hardware, such as an iPhone, iPad, or iPod on which you plan to test your project. You must retrieve the UDID for each device on which you plan to test your game. You then add the UDID to the Devices section in the iOS developer portal.

**Note**: Each year, you’re allowed to register a fixed number of devices. The maximum number of devices you can register is 100 devices per product family per membership year. For more information see, [Registering Devices Using Your Developer Account](https://help.apple.com/xcode/mac/current/#/dev8b4250b57) in the **Maintaining Identifiers, Devices, and Profiles** topic on the Apple developer website.

## Creating an iOS certificate and p12 file

When you create a certificate, you must decide whether to create a *Development Certificate* (used only for testing), or a *Production Certificate*, which you use to distribute your app via the App Store.

**Tip**: Create a Production Certificate. While either certificate type  works for development, using a Production certificate makes the process of releasing your app to the Apple store easier.

### Create a certificate

1. Sign in to your [Apple Developer Program](https://developer.apple.com/programs/).
1. Click **Member Center** > **Certificates** > **Identifiers & Profiles** > **Certificates**.
1. In the left-hand column, under **Certificates**, click **All**.
1. In the screen labeled **What type of certificate do you need**, choose the type of certificate to generate. Typically, if you're just starting off, you want to pick an **App Store and Ad Hoc certificate production certificate**.
1. Next, use the *Keychain Access* program on your Mac (open up your Finder and find it in *Applications/Utilities*) to generate a Certificate Signing Request (CSR) file. Follow the instructions in the iOS portal to complete this step. Make a note of where you save the CSR file, as you'll need it for the next step.
1. From the **Generate your certificate** screen, upload your CSR file (which might have the extension *.certSigningRequest*). Click the **Choose File** button and select your CSR file, and then click the **Generate** button.
1. To download your certificate to your Mac, click the **Download** button on the **Your Certificate is Ready** screen. Make sure to store this file somewhere safe, and back it up.

To add the certificate to a keychain, locate the certificate file and double-click it. This opens the Keychain Access program. If you get a popup with the message "Do you want to add the certificate to a keychain?", choose login and click the **Add** button.

### Export a p12 file

To create apps using Unity Cloud Build, you must convert your certificate file to a p12 file. A p12 file is a file that contains your private key and certificate and is used to sign your code. Typically, if you are developing a project in native Xcode, this process is handled for you behind the scenes.

To generate a p12 file:

1. On your Mac, open up your Finder and in Applications/Utilities, open the Keychain Access program.
1. In the left-hand column, under keychains verify that **Login** is selected.
1. In the left-hand column, under **Category** verify that **My Certificates** is selected. In the main **Keychain Access** pane, select your certificate. 
    
    **Note**: Typically your certificate is located under **My Certificates**. If you do not find it there, check under **Certificates**.
1. From the **File menu**, select **File** > **Export Items**, or right-click and select **Export**.
1. Select Personal Information Exchange (.p12) from the File Format drop-down menu. 
    
    **Note**: If **Login** under **Keychains and My Certificates** under **Category** is not selected, the p12 option is greyed out.
1. You are asked to create a password for the p12 file. 
    
    **Important**: Record the password somewhere safe. You must supply the password when setting up iOS builds on Unity Cloud Build.

## Adding devices

Apple requires the UDID for each device on which you intend to install your app. This is only required for development purposes. Once your app is accepted into the App Store, it is available for anyone to download and install; provided they have the correct version of iOS and meet any other necessary requirements.

## Finding your UDIDs

You can use iTunes to retrieve the UDID of your device. For a thorough walkthrough of the retrieval process, see [WhatsMyUDID.com](http://whatsmyudid.com/).

The basic steps are:

1. Open *iTunes* on your Mac.
1. Connect the device (iPhone, iPad, etc) to the computer.
1. In *iTunes*, select the device.
1. You should see a screen with the device name, capacity, and other details about the device. To display the UDID, click the **Serial #** field.
1. Copy and paste the UDID into a document where you can retrieve it later.
1. Close *iTunes* and disconnect your device.

## Add the UDID in the Apple developer portal

Now that you have your device UDID(s), you're ready to add them to the Apple Developer Portal:

1. Click the **All** section under **Devices** in the left column of the iOS Developer Portal.
1. To add a new UDID, click the Add button (**+**) in the upper-right corner
1. Give the device a name you will recognize, and copy-paste the UDID you got from *iTunes* into the UDID field.
1. Click **Continue**.

Repeat the steps for each of your devices.

## Create App ID

Now that you've created your iOS Certificate, you can create an App ID which is used to create an App ID:

1. In the left-hand column of the Apple Developer Portal, click **App ID**.
1. In the **Register iOS App IDs** pane, at the top right, click the Add button (**+**).
1. In the **Registering an App ID** pane, enter the following information:
    1. **App ID Description**: The name of your app, without any special characters.
    1. **App ID Suffix**: If you intend to incorporate specific services such as Game Center or In-App Purchases, create an Explicit ID. If you don't need these services, then create a **Wildcard App ID**. A Wildcard App ID allows you to re-use the App ID for multiple projects.
    1. **App Services**: Optional. Indicate whether you plan on using any of the App Services provided by Apple.

    For more information on registering an App ID, see [Maintaining Identifiers, Devices, and Profiles](https://help.apple.com/xcode/mac/current/#/dev8b4250b57).

1. Click the **Continue** button.
1. On the **Confirm your App ID** page, check the information you've provided and then click the **Submit** button.

## Create a provisioning profile

The next step is to generate a *.mobileprovision* file. The *.mobileprovision* file combines your p12 certificate, App ID, and identifies the UDIDs of the devices on which you are testing your app.

1. In the Apple Developer portal, click **Certificates, IDs & Profiles**.
1. In the left-hand column of the Apple Developer Portal, under **Provisioning Profiles**, select **All**.
1. To add a new Provisioning Profile, click the Add button (**+**) in the upper-right corner.
1. Under **Development**, select the type of provisioning profile to create and click **Continue**. 
    **Note**: If you're just getting started, you should use a **Distribution** > **Ad Hoc certificate**, as this allows you to build your game and test it on devices.
1. Select the App ID you want to use for development, and click the **Continue** button.
1. Select one or more development certificates, and click the **Continue** button.
1. Select one or more devices, and click the **Continue** button.
1. Enter a profile name, and click the **Generate** button.
1. Click the **Done** button.

Download the generated *.mobileprovision* file to your desktop machine.

## Configuring your app to build for iOS

To configure your iOS Cloud Build, you need the following items:

* Your provisioning profile (.mobileprovision)
* Your .p12 file
* The password that you used to protect your .p12 file

For basic iOS usage this process should be sufficient. For projects that include Xcode frameworks, you must perform some additional configuration.

## Using Xcode Frameworks

To add Xcode frameworks manually, use the [Xcode Manipulation API](ScriptRef:iOS.Xcode.PBXProject.html). The API is maintained by the Unity iOS team and API allows you to manage external Xcode frameworks.

For an example of a Unity Project that uses the API, see the [UpdateXcodeProject](https://bitbucket.org/Unity-Technologies/iosnativecodesamples/src/4bf7fa2fe42037e324fd322d615c4194b0317731/NativeIntegration/Misc/UpdateXcodeProject/?at=stable) example Project on BitBucket. You can use the example to experiment and to learn from.

One of the plugins of the example Project is an external Xcode project manipulation DLL. The DLL is the build product of the source available in Unity's Bitbucket repository. A preferred way to include Xcode project manipulation functionality is to copy the C# source code files to the Assets/Editor folder in your Project.

There are two ways you can use the Xcode Manipulation API:

* Use the built-in Unity [PostProcessBuildAttribute](ScriptRef:Callbacks.PostProcessBuildAttribute.html), which is executed before the Unity Cloud Build Post-Export method runs.
* Use the Unity Cloud Build [Post-Export](UnityCloudBuildPreAndPostExportMethods) method (requires access to advanced settings).