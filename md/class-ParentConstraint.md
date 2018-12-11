# Parent Constraints 

A Parent Constraint moves and rotates a GameObject as if it is the child of another GameObject in the Hierarchy window. However, it offers certain advantages that are not possible when you make one GameObject the parent of another:

* A Parent Constraint does not affect scale. 

* A Parent Constraint can link to multiple GameObjects.

* A GameObject does not have to be a child of the GameObjects that the Parent Constraint links to.

* You can vary the effect of the Constraint by specifying a weight, as well as weights for each of its source GameObjects.

For example, to place a sword in the hand of a character, add a Parent Constraint component to the sword GameObject. In the __Sources__ list of the Parent Constraint, link to the character’s hand. This way, the movement of the sword is constrained to the position and rotation of the hand.

![Parent Constraint component](../uploads/Main/ParentConstraint.png)

### Properties

| **Property:** || **Function:** |
|:---|:---|
|__Activate__||After you move and rotate the constrained GameObject and its source GameObjects, click __Activate__ to save this information. __Activate__ saves the current offset from the source GameObjects in __Rotation At Rest__, __Position At Rest__, __Position Offset__, and __Rotation Offset__, then checks __Is Active__ and __Lock__. |
|__Zero__||Sets the position and rotation of the constrained GameObject to the source GameObjects. __Zero__ resets the __Rotation At Rest__, __Position At Rest__, __Position Offset__, and __Rotation Offset__ fields then checks __Is Active__ and __Lock__.|
|__Is Active__||Toggles whether or not to evaluate the Constraint. To also apply the Constraint, make sure __Lock__ is checked.|
|__Weight__||The strength of the Constraint. A weight of 1 causes the Constraint to move and rotate this GameObject at the same rate as its source GameObjects. A weight of 0 removes the effect of the Constraint completely. This weight affects all source GameObjects. Each GameObject in the __Sources__ list also has a weight.|
|__Constraint Settings__||&nbsp;|
||Lock|Toggle to let the Constraint move and rotate the GameObject. Uncheck this property to edit the position and rotation of this GameObject. You can also edit the Rotation At Rest, Position At Rest, Position Offset, and Rotation Offset properties. If Is Active is checked, the Constraint updates the Rotation At Rest, Position At Rest, Position Offset, or Rotation Offset properties for you as you move and rotate the GameObject or its Source GameObjects. When you are satisfied with your changes, check Lock to let the Constraint to control this GameObject. This property has no effect in Play Mode.|
||Position At Rest|The X, Y, and Z values to use when Weight is 0 or when the corresponding __Freeze Position Axes__ are not checked. To edit these fields, uncheck __Lock__.|
||Rotation At Rest|The X, Y, and Z values to use when Weight is 0 or when the corresponding __Freeze Rotation Axes__ are not checked. To edit these fields, uncheck __Lock__.|
||Position Offset|The X, Y, and Z position offset from the Transform that the Constraint imposes. To edit these fields, uncheck __Lock__.|
||Rotation Offset|The X, Y, and Z rotation offset from the Transform that the Constraint imposes. To edit these fields, uncheck __Lock__.|
||Freeze Position Axes|Check X, Y, or Z to allow the Constraint to control the corresponding position axes. Uncheck an axis to stop the Constraint from controlling it, which allows you to edit, animate, or script it.|
||Freeze Rotation Axes|Check X, Y, or Z to allow the Constraint to control the corresponding rotation axes. Uncheck an axis to stop the Constraint from controlling it, which allows you to edit, animate, or script it.|
|__Sources__||The list of GameObjects that constrain this GameObject. Unity evaluates source GameObjects in the order they appear in this list. This order affects how this Constraint moves and rotates the constrained GameObject. To get the result you want, drag and drop items in this list. Each source has a weight from 0 to 1. |

---

* <span class="page-edit"> 2018-03-13  <!-- include IncludeTextNewPageYesEdit --></span>

* <span class="page-history">Constraints added in 2018.1</span>
