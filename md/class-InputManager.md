#Input

Use the __Input__ settings (top menu: **Edit** &gt; **Project Settings**, then select the **Input** category) to [define the input axes and game actions](Input) for your Project.

![Input settings](../uploads/Main/InputSetAll.png) 

To add more input axes, increase the value in the __Size__ property.

Each input axis provides the following list of properties:

|**Property** ||**Function** |
|:---|:---|:---|
|__Name__ ||Enter the string that refers to the axis in the game launcher and through scripting. |
|__Descriptive Name__ ||Enter a detailed definition of the __Positive Button__ function that appears in the game launcher. |
|__Descriptive Negative Name__ ||Enter a detailed definition of the __Negative Button__ function that appears in the game launcher. |
|__Negative Button__ ||Enter the name of the button that sends a negative value to the axis. |
|__Positive Button__ ||Enter the name of the button that sends a positive value to the axis. |
|__Alt Negative Button__ ||Enter the name of the secondary button that sends a negative value to the axis. |
|__Alt Positive Button__ ||Enter the name of the secondary button that sends a positive value to the axis. |
|__Gravity__ ||Set how fast the input re-centers. This property applies only when the __Type__ is __key / mouse button__. |
|__Dead__ ||Any positive or negative values that are less than this number register as zero. Useful for joysticks. |
|__Sensitivity__ ||For keyboard input, a larger value results in faster response time. A lower value is smoother. For the mouse delta, this value scales the actual mouse delta. |
|__Snap__ ||Enable this option to immediately reset the axis value to zero after it receives opposite inputs. This property applies only when the __Type__ is __key / mouse button__. |
|__Invert__ ||Enable this option to make the positive buttons send negative values to the axis, and vice versa. |
|__Type__ ||Choose what kind of input this axis can expect. |
||_Key / Mouse Button_ |Any kind of button. |
||_Mouse Movement_ |Mouse delta and scrollwheels. |
||_Window Movement_ |User shakes the window. |
||_Joystick Axis_ |Analog joystick axes. |
|__Axis__ ||Choose the axis of input from the device (joystick, mouse, gamepad, etc.). Defaults to the X-axis. |
|__Joy Num__ ||Choose which joystick should be used. Defaults to retrieving the input from all joysticks. <br />**Note:** This is only used for input axes and not buttons. |



## Using axes during Game Play

All the axes that you set up in the **Input** settings serve two purposes:

* They allow you to reference your inputs by axis name in scripting.
* They allow the players of your game to customize the controls to their liking.

The game launcher presents all defined axes, where it displays the name, detailed description, and default buttons for each. From here, they can change any of the buttons defined in the axes. Therefore, it is best to write your scripts making use of axes instead of individual buttons, as the player may want to customize the buttons for your game.


![The game launcher's Input settings are displayed when your game runs](../uploads/Main/Input-GameLauncher.jpg) 
