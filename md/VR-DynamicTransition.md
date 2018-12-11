# Dynamic transition between VR and non-VR

It is possible to transition into and out of VR mode dynamically at run time. Transitioning in or out of VR is a two-step process via script. The following sections outline the steps and some sample code for performing both transitions.

## Transitioning from non-VR to VR

1. First, load the requested device, and then wait at least one frame for that device to successfully load. 
1. After the devide has loaded, set `XRSettings.enabled` to true to enable VR. 

```
IEnumerator EnterVR(string deviceName)
{	

	// If already loaded, no need to do anything.
	if (UnityEngine.XR.XRSettings.enabled && 
String.Compare(VRSettings.loadedDeviceName, deviceName, true) == 0)
		return;

	int deviceLoadAttemptCount = 0;
	bool didLoadDevice = true;

	// Otherwise, load the requested device.
	UnityEngine.XR.XRSettings.LoadDeviceByName(deviceName);
	do
	{
		if (deviceLoadAttemptCount > 10)
		{	
			Debug.Log(“Unable to load VR Device “ + deviceName);
			didLoadDevice = false;
			break;
		}

		// Wait at least one frame for the new device to be loaded.
		yield return null;
		deviceLoadAttemptCount++;
	} while (String.Compare(UnityEngine.XR.XRSettings.loadedDeviceName, deviceName, true) != 0);

	// Now that device is loaded, enable VR
	if (didLoadDevice)
UnityEngine.XR.XRSettings.enabled = true;
}
```

## Transitioning from VR to non-VR

First, load the `None` device, and then wait at least one frame for the XR device to successfully unload. Loading the `None` device automatically sets `XRSettings.enabled` to false.

```
IEnumerator LeaveVR()
{
	// If not enabled, no need to do anything.
	if (!UnityEngine.XR.XRSettings.enabled)
		return;

	int deviceUnloadAttemptCount = 0;
	// Otherwise load the None device to disable VR.
	UnityEngine.XR.XRSettings.LoadDeviceByName(“None”);
	do
	{
		if (deviceUnloadAttemptCount > 10)
		{	
			Debug.Log(“Unable to unload VR Device“);
			break;
		}

		yield return null;
		deviceUnloadAttemptCount++;
	} while (UnityEngine.XR.XRSettings.enabled); 

	// No need to set enabled to false as loading the None device does that by default.
}
```

---

* <span class="page-edit"> 2018-09-18  <!-- include IncludeTextNewPageYesEdit --></span>