# Aim Constraints

An Aim Constraint rotates a GameObject to face its source GameObjects.

At the same time the Aim Constraint rotates a GameObject to follow its source GameObjects, it can also maintain a consistent orientation for another axis. For example, you add an Aim Constraint to a Camera. To keep the Camera upright while the Constraint aims it, specify the up axis of the Camera and an up direction to align it to.

Use the __Up Vector__ to specify the up axis of the constrained GameObject. Use the __World Up Vector__ to specify the upward direction. As the Aim Constraint rotates the GameObject to face its source GameObjects, the Constraint also aligns the up axis of the constrained GameObject with the upward direction.

![Aim Constraint component](../uploads/Main/AimConstraint.png)

### Properties

| **Property:** || **Function:** |
|:---|:---|
|__Activate__||After you rotate the constrained GameObject and move its source GameObjects, click __Activate__ to save this information. __Activate__ saves the current offset from the source GameObjects in __Rotation At Rest__ and __Rotation Offset__, then checks __Is Active__ and __Lock__.|
|__Zero__||Sets the rotation of the constrained GameObject to the source GameObjects. Zero resets the __Rotation At Rest__ and __Rotation Offset__ fields, then checks __Is Active__ and __Lock__.|
|__Is Active__||Toggles whether or not to evaluate the Constraint. To also apply the Constraint, make sure __Lock__ is checked.|
|__Weight__||The strength of the Constraint. A weight of 1 causes the Constraint to rotate this GameObject at the same rate that its source GameObjects move. A weight of 0 removes the effect of the Constraint completely. This weight affects all source GameObjects. Each GameObject in the __Sources__ list also has a weight.|
|__Aim Vector__||Specifies the axis which faces the direction of its source GameObjects. For example, to specify that the GameObject should orient only its positive Z axis to face the source GameObjects, enter an __Aim Vector__ of 0, 0, 1 for the X, Y, and Z axes, respectively.|
|__Up Vector__||Specifies the up axis of this GameObject. For example, to specify that the GameObject should always keep its positive Y axis pointing upward, enter an __Up Vector__ of 0, 1, 0 for the X, Y, and Z axes, respectively.|
|__World Up Type__||Specifies the axis for the upward direction. The Aim Constraint uses this vector to align the up axis of the GameObject the upward direction. |
||Scene Up|The Y axis of the scene.|
||Object Up|The Y axis of the GameObject referred to by __World Up Object__.|
||Object Up Rotation|The axis specified by __World Up Vector__ of the GameObject referred to by __World Up Object__.|
||Vector|The World Up Vector.|
||None|Do not use a World Up vector.|
|__World Up Vector__||Specifies the vector to use for the __Object Up Rotation__ and __Vector__ choices in __World Up Type__.|
|__World Up Object__||Specifies the GameObject to use for the __Object Up__ and __Object Up Rotation__ choices in __World Up Type__.|
|__Constraint Settings__||&nbsp;|
||Lock|Toggle to let the Constraint rotate the GameObject. Uncheck this property to edit the rotation of this GameObject. You can also edit the Rotation At Rest and Rotation Offset properties. If Is Active is checked, the Constraint updates the Rotation At Rest or Rotation Offset properties for you as you rotate the GameObject or its source GameObjects. When you are satisfied with your changes, check Lock to let the Constraint control this GameObject. This property has no effect in Play Mode.|
||Rotation At Rest|The X, Y, and Z values to use when Weight is 0 or when the corresponding Freeze Rotation Axes are not checked. To edit these fields, uncheck Lock.|
||Rotation Offset|The X, Y, and Z offset from the rotation that is calculated by the Constraint. To edit these fields, uncheck Lock.|
||Freeze Rotation Axes|Check X, Y, or Z to allow the Constraint to control the corresponding axes. Uncheck an axis to stop the Constraint from controlling it. This allows you to edit, animate, or script the unfrozen axis.|
|__Sources__||The list of GameObjects that constrain this GameObject. Unity evaluates source GameObjects in the order that they appear in this list. This order affects how this Constraint rotates the constrained GameObject. To get the result you want, drag and drop items in this list. Each source has a weight from 0 to 1. |

---

* <span class="page-edit"> 2018-03-13  <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Constraints added in 2018.1</span>