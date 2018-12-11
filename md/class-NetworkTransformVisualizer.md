# Network Transform Visualizer

The Network Transform Visualizer is a utility component that allows you to visualize the interpolation of GameObjects that use the [Network Transform](ScriptRef:Networking.NetworkTransform.html) component. To use it, add it to a GameObject that already has a Network Transform component, and assign a Prefab in the Inspector. The Prefab can be anything you choose, it will be used as a visual representation of the incoming transform data for GameObject.

GameObjects with [local authority](UNetAuthority) (such as the local player) are not interpolated, and therefore won't show a visualizer GameObject. The visualizer will only show other Networked GameObjects controlled by other computers on the network (such as other players).

![The Network Transform Visualizer component](../uploads/Main/NetworkTransformVisualizer.png)

The Network Transform Visualizer component in the Inspector window

|**Property**|**Function**|
|:---|:---|
|**Visualizer Prefab**|Define the Prefab used to visualize the target position of the network transform.|

When the game is playing, the Prefab is instantiated as the "visualizer" GameObject. When the Network Transform GameObject moves, the visualizer GameObject is displayed at the target position of the Network Transform.

You can choose whatever you like to be the visualizer prefab. In the example below, a semi-transparent magenta cube is used.

![In this image the Network Transform Visualizer is showing the incoming transform data for a remote player in the game, represented by the magenta cube.](../uploads/Main/NetworkTransformVisualizerExample.jpg)

It usually appears to be moving a little ahead of - but less smoothly than - the Network Transform GameObject. This is because it is showing you the raw positional data coming in directly from the network, rather than using interpolation to smoothly reach each new target position.

![This animation shows that the incoming network tranform data is slightly ahead but less smooth than the interpolated position of the networked GameObject](../uploads/Main/NetworkTransformVisualizerExample2.gif)

A GameObject with a Network Transform Visualizer component must also have a [Network Identity](class-NetworkIdentity.html) component. When you create a Network Transform Visualizer component on a GameObject, Unity also creates a Network Transform component and a Network Identity component on that GameObject if it does not already have one.

**Note:** Make sure the prefab you choose to use as your visualization GameObject does not have a collider attached, or anything else that could affect the gameplay of your game!