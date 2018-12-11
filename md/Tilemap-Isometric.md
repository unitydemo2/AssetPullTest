# Isometric Tilemaps

In addition to [Hexagonal Tilemaps](Tilemap-Hexagonal), Unity enables you to create **Isometric Tilemaps**. The isometric perspective displays all three X, Y, and Z axes, so you can add pseudo-depth and height to a Tilemap.

Isometric tilemaps are popular in strategy games, as the isometric perspective allows you to simulate 3D gameplay elements such as different elevations and line-of-sight. This lets players make tactical decisions regarding movement and positioning during gameplay.

## Isometric Tilemap workflow

1. [Import and prepare Sprites](#Tilemap-Isometric-SpritesImport) for an Isometric Tilemap.
2. [Create an Isometric Tilemap](#Tilemap-Isometric-CreateIso).
3. [Create an Isometric Tile Palette.](#Tilemap-Isometric-Palette)
    * Adjust the [Z Position Editor](#Tilemap-Isometric-Palette) while painting the Tilemap.
4. Set the [Tilemap Renderer Mode](#Tilemap-Isometric-RenderModes) and settings.
    * Set up [Chunk Mode sorting](#Tilemap-Isometric-RenderModes) with Sprite Atlas.
    * Set the [Custom Axis Sort mode](#Tilemap-Isometric-RenderModes).
5. Customize [Scriptable Brushes](#Tilemap-Isometric-ScriptableBrushes) to handle Z position changes.

---

* <span class="page-history">Isometric Tilemaps added in [2018.3](https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
