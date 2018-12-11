# Tilemap

Unity's __Tilemap__ feature allows you to create a variety of 2D levels using __[Tile Assets](https://docs.unity3d.com/2018.2/Documentation/Manual/Tilemap-TileAsset.html)__ arranged on the __Grid__ and __[Tilemap](https://docs.unity3d.com/Manual/Tilemap-CreatingTilemaps.html)__ GameObjects. This also supports specialized types of Tilemaps, such as __[Hexagonal](https://docs.unity3d.com/Manual/Tilemap-Hexagonal.html)__ and __[Isometric Tilemaps](https://docs.unity3d.com/Manual/Tilemap-Isometric.html)__.

Below is the general workflow to follow to create and paint a __Tilemap__:

1. Create a __[Tilemap GameObject](https://docs.unity3d.com/Manual/Tilemap-CreatingTilemaps.html)__
2. Import and prepare Sprites to create __[Tile Assets](https://docs.unity3d.com/Manual/Tilemap-TileAsset.html)__
3. Create a __[Tile Palette](https://docs.unity3d.com/Manual/Tilemap-Palette.html)__ with selected __Tile Assets__
4. 'Paint' on the __Tilemap__ with the __Tile Assets__ and __[Brush Tools](https://docs.unity3d.com/Manual/Tilemap-Painting.html)__ available from the __Tile Palette__
 

Depending on your project, you may want the __Tilemap__ to interact with __[Physics2D](https://docs.unity3d.com/2018.3/Documentation/Manual/Tilemap-Physics2D.html)__. To do so, attach the __[Tilemap Collider](https://docs.unity3d.com/2018.3/Documentation/Manual/Tilemap-Physics2D.html)__ component to your Tilemap to generate a Colider based on the Tiles present on the Tilemap after step 4.

## 2D extras in GitHub

You can download examples of scripted **[Tiles](https://docs.unity3d.com/2018.3/Documentation/Manual/Tilemap-ScriptableTiles.html)** and **[Brushes](https://docs.unity3d.com/2018.3/Documentation/Manual/Tilemap-ScriptableBrushes.html)** from the **[2D Extra](https://github.com/Unity-Technologies/2d-extras)** GitHub repository. Example projects with these scripted GameObjects are availalbe in the **[2D Techdemos](https://github.com/Unity-Technologies/2d-techdemos#2d-techdemos)** Github repository. For descriptions of the different scripts and usage information, refer to the README.md for each repository.

---
* <span class="page-edit"> Isometric Tilemap functionality added in Unity [2018.3](https://docs.unity3d.com/2018.2/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
* <span class="page-edit"> Hexagonal Tilemap functionality added in Unity [2018.2](https://docs.unity3d.com/2018.2/Documentation/Manual/30_search.html?q=newin20182) <span class="search-words">NewIn20182</span></span>
* <span class="page-history">Tilemaps added in [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) <span class="search-words">NewIn20172</span></span> 