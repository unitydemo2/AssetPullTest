# Requesting Permissions

On Android 6 (API level 23) and above, the [Android.Permission](ScriptRef:Android.Permission.html) API allows you to request permission to use some commonly needed system features, such as the camera, microphone, or location, when they are needed rather than when the application starts up. You can request each individual permission when needed and show the user a message that explains the reason why you are asking. 

The standard method Android uses for permissions is to show the user a list of the permissions that the app needs when it starts up, providing no explanation as to why or in what context these permissions are used. This can be confusing and some users might deny the permissions even if they are necessary to the operation of the application. 

Google’s guideline for requesting permissions recommends that, if the user has denied your permission request once, you should display the reason for the request and give them the opportunity to allow you to present the request again. 

You can use the [Permission.HasUserAuthorizedPermission](ScriptRef:Android.Permission.HasUserAuthorizedPermission.html) function to check whether a permission has been authorized by the user. If it has not, you can request the permission again, explaining why your app needs the permission. Once you have the user's approval, call [Permission.RequestUserPermission](ScriptRef:Android.Permission.RequestUserPermission.html) to request the permission again. When you call this function, Android opens the system permission dialog to allow the user to approve (or deny) the permission. 

If the user still denies the permission request, you should disable the related functionality in your app, or, if the app cannot work without it, inform the user. Note that if the user previously checked the "Do not ask me again" option on the system permission dialog, `RequestUserPermission()` does not open the system dialog. The user must go into the application permission settings and manually turn on the permission in this case.

You can add the `unityplayer.SkipPermissionsDialog` meta-data to your Android manifest to suppress the permissions dialog normally shown when the app starts up. If you do, you must call [Permission.RequestUserPermission](ScriptRef:Android.Permission.RequestUserPermission.html) at an appropriate time to gain access to each protected feature. See [Android Manifest](android-manifest) for more information. 

For additional information on requesting Android permissions, see [App permissions best practices](https://developer.android.com/training/permissions/usage-notes) in the Android developer guide.

The following sample code shows how to check whether a permission has been granted for a specific permission and present a dialog in the case where the user has denied the permission:

## MicrophoneTest.cs

```
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class MicrophoneTest : MonoBehaviour 
{
    GameObject dialog = null;
    
    void Start ()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            dialog = new GameObject();
            }
        #endif
    }

    void OnGUI ()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user denied permission to use the microphone.
            // Display a message explaining why you need it with Yes/No buttons.
            // If the user says yes then present the request again
            // Display a dialog here.
            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
        #endif

        // Now you can do things with the microphone
    }
}
```

## PermissionsRationaleDialog.cs

```
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class PermissionsRationaleDialog : MonoBehaviour
{
    const int kDialogWidth = 300;
    const int kDialogHeight = 100;
    private bool windowOpen = true;

    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10, 20, kDialogWidth - 20, kDialogHeight - 50), "Please let me use the microphone.");
        GUI.Button(new Rect(10, kDialogHeight - 30, 100, 20), "No");
        if (GUI.Button(new Rect(kDialogWidth - 110, kDialogHeight - 30, 100, 20), "Yes"))
        {
            #if PLATFORM_ANDROID
            Permission.RequestUserPermission(Permission.Microphone);
            #endif
            windowOpen = false;
        }
    }

    void OnGUI ()
    {
        if (windowOpen)
        {
            Rect rect = new Rect((Screen.width / 2) - (kDialogWidth / 2), (Screen.height / 2) - (kDialogHeight / 2), kDialogWidth, kDialogHeight);
            GUI.ModalWindow(0, rect, DoMyWindow, "Permissions Request Dialog");
        }
    }
}
```

**Note:** Add `MicrophoneTest` to a GameObject as a component, but not `PermissionsRationaleDialog`. `MicrophoneTest` automatically creates a GameObject and adds `PermissionsRationaleDialog` when it needs to show the dialog. Also note that your app must use the Microphone class for Unity to add the microphone permission. 

------

* <span class="page-edit">2018-10-03  <!-- include IncludeTextNewPageYesEdit --></span>
* <span class="page-history">New feature in 2018.3</span>
