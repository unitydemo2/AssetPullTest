# Unity XR input

This section provides information on all Unity supported input devices used to interact in Virtual Reality, Augmented Reality and Mixed Reality applications.

## XR input mappings

You can access XR input features via the legacy input axis and button indices. This table outlines what each feature maps to on each platform. For information about how to use the button/joystick axes, see documentation on [Conventional game input](https://docs.unity3d.com/Manual/ConventionalGameInput.html).

| Feature Usage| FeatureType | Legacy Input Index [L/R] | WMR | Oculus | GearVR | Daydream | OpenVR (Full) | Vive | OpenVR (Oculus) | OpenVR (WMR) |
|:---|:---|:---|:---|:---|:---|:---|:---|:---|:---|:---| 
| Primary2DAxis| 2D Axis | [(1,2)/(4,5)] | Joystick | Joystick | Joystick | Touchpad | [Trackpad/Joystick] | Trackpad | Joystick | Joystick |
| Trigger| Axis | [9/10] | Trigger | Trigger | Trigger | Trigger | Trigger | Trigger | Trigger | Trigger |
| Grip| Axis | [11/12] | Grip | Grip |  | Grip | Grip | Grip | Grip | Grip |
| IndexTouch| Axis | [13/14] |  | Index - Near Touch |  |  |  |  |  |  |
| ThumbTouch| Axis | [15/16] |  | Thumb - Near Touch |  |  |  |  |  |  |
| Secondary2DAxis| 2DAxis | [(17,18)/(19,20)] | Touchpad |  |  |  |  |  |  | Touchpad |
| IndexFinger| Axis | [21/22] |  |  |  |  | Index |  |  |  |
| MiddleFinger| Axis | [23/24] |  |  |  |  | Middle |  |  |  |
| RingFinger| Axis | [25/26] |  |  |  |  | Ring |  |  |  |
| PinkyFinger| Axis | [27/28] |  |  |  |  | Pinky |  |  |  |
| CombinedTrigger| Axis | [3/3] | CombinedTrigger | Combined Trigger | Combined Trigger |  | Combined Trigger | Combined Trigger | Combined Trigger |  |
| PrimaryButton| Button | [2/0] |  | [X/A] |  | App | Primary | Primary | Primary [Y/B] | Menu |
| PrimaryTouch| Button | [12/10] |  | [X/A] - Touch |  |  |  |  |  |  |
| SecondaryButton| Button | [3/1] |  | [Y/B] |  |  | Alternate |  | Alternate [B/A] |  |
| SecondaryTouch| Button | [13/11] |  | [Y/B] - Touch |  |  |  |  |  |  |
| GripButton| Button | [4/5] | Grip - Press | Grip - Press |  | Grip - Press | Grip - Press | Grip - Press | Grip - Press | Grip |
| TriggerButton| Button | [14/15] | Trigger - Press | Index - Touch | Trigger - Press | Trigger - Press | Trigger - Press | Trigger - Press | Trigger - Touch | Trigger-Press |
| MenuButton| Button | [6/7] | Menu | Start (6) |  |  |  |  |  |  |
| Primary2DAxisClick| Button | [8/9] | Joystick - Click | Thumbstick - Click | Touchpad - Click | Touchpad - Click | StickOrPad - Press | StickOrPad - Press | StickOrPad - Press | Touchpad - Click |
| Primary2DAxisTouch| Button | [16/17] | Touchpad - Click | Thumbstick - Touch | Touchpad - Touch | Touchpad - Touch | StickOrPad - Touch | StickOrPad - Touch | StickOrPad - Touch | Touchpad - Touch |
| Thumbrest| Button | [18/19] | Touchpad - Touch | ThumbRest - Touch |  |  |  |  |  |  |



## XR Input through Legacy Input System

You can poll XR input features via the legacy input system, using the appropriate legacy input indices from the table above. Create an axis mapping in __Edit__ > __Settings__ > __Input__ to add the appropriate mapping from the input name to the axis index for the platform device’s feature.  The button or axis value can be retrieved with [Input.GetAxis](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) or [Input.GetButton](https://docs.unity3d.com/ScriptReference/Input.GetButton.html) by passing in the now-mapped axis or button name.

## Haptics

You can retrieve input devices for any currently tracked [XRNode](https://docs.unity3d.com/ScriptReference/XR.XRNode.html). If there is a valid input device at a tracked XRNode, Unity can route haptic data to the corresponding input device to provide the wearer with immersive feedback. Unity can send haptic data either as a simple impulse with amplitude and duration, or as a buffer of data. 

Not all platforms support all types of haptics, but you can query a device for haptic capabilities. The following example gets an input device for the right hand, checks to see if the device is capable of haptics, and then plays back an impulse if it is capable:

    InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    HapticCapabilities capabilities;
    if(device.TryGetHapticCapabilities(out capabilities))
    {
        if(capabilities.supportsImpluse)
        {
            uint channel = 0;
            float amplitude = 0.5f;
            float duration = 1.0f;
            device.SendHapticImpulse(channel, amplitude, duration);
        }
    }
  
  **Note:** this code example uses the `UnityEngine.XR` namespace.
  
  ----
  
 * <span class="page-edit">2018-10-15 <!-- include IncludeTextNewPageYesEdit --></span>

    