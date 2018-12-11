# Tilemap Renderer

The __Tilemap Renderer__ component is part of a __Tilemap__. It renders the __Tiles__ set on the Tilemap.


![](../uploads/Main/2D_Tilemap_Render_properties.png)


| Property                                         | Function                                                     |
| ------------------------------------------------ | ------------------------------------------------------------ |
| __Material__                                     | Define the Material used to render the Sprite texture.   |
| **Sort Order**                                       | Set the direction that Tiles on the selected Tilemap are sorted from. |
| **Mode**                                             | Set the rendering mode of the Renderer.                  |
| &nbsp;&nbsp;Chunk                                            | The Renderer groups Tiles by location, and batches their Sprites together for rendering. Select this mode for the best rendering performance with Tilemap. |
| &nbsp;&nbsp;Individual                                       | The Renderer renders each Tile individually, taking into account their location and sorting order as well. This mode enables the Sprites on the Tiles to interact with other Renderers in the scene or with a [Custom Sorting Axis](https://docs.unity3d.com/Manual/Tilemap-Isometric-RenderModes.html#CustomAxis).  |
| **Detect Chunk Culling Bounds**                      | Determines how the Render detects the [bounds](https://docs.unity3d.com/ScriptReference/Tilemaps.TilemapRenderer-chunkCullingBounds.html) used for the culling of [Tilemap chunks](https://docs.unity3d.com/ScriptReference/Tilemaps.TilemapRenderer-chunkSize.html). These bounds expand the boundary of Tilemap chunks to ensure that oversized Sprites will not be clipped during culling. |
| &nbsp;&nbsp;Auto                                             | The Renderer automatically inspects the Sprites used by the Tiles  to determine the expanded culling bounds to use. |
| &nbsp;&nbsp;Manual                                           |The values used to extend the bounds for culling of the Tilemap chunks are manually set instead of with the Editor's automatic detection. |
| **Chunk Culling Bounds (when ‘Manual’ is selected)** | Input the values (in Unity units) that the culling bounds are extended by.|
| **Sorting Layer**                                    | Set the [Sorting Layer](https://docs.unity3d.com/Manual/class-TagManager.html) of the Tilemap. Select an existing Sorting Layer from the drop-down box, or create a new Sorting Layer. |
| **Order in Layer**                                   | Set the render priority of the Tilemap within its Sorting Layer. Lower numbered layers are rendered first. Higher numbered layers overlap those below. |
| **Mask Interaction**                                 | Set how the Tilemap Renderer behaves when it interactswith a [Sprite Mask](https://docs.unity3d.com/Manual/class-SpriteMask.html). |
| &nbsp;&nbsp;None                                             | The Tilemap Renderer does not interact with any Sprite Mask in the Scene. This is the default option. |
| &nbsp;&nbsp;Visible Inside Mask                              | The Tilemap is visible where the Sprite Mask overlays it, but not outside of it. |
| &nbsp;&nbsp;Visible Outside Mask                             | The Tilemap is visible outside the Sprite Mask, but not inside it. The Sprite Mask hides the sections of the Sprite it overlays. |

---
* <span class="page-history">Tilemaps added in [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) <span class="search-words">NewIn20172</span></span> 