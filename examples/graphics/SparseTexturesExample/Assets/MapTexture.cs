using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public class MapTexture : MonoBehaviour {

	public int width = 8192;
	public int height = 8192;
	public int visibleTileRadius = 2;

	private int tileWidth;
	private int tileHeight;
	private int tileCountX;
	private int tileCountY;
	private Bounds bounds;
	private List<Vector2> tilesPresent = new List<Vector2> ();

	private SparseTexture texture;
	private Color32[] tileColors; // color buffer to generate a single tile

	void PositionToTileCoord (Vector3 pos, out int tileX, out int tileY)
	{
		// calculate position in [0..1) range over floor bounds
		float px = Mathf.Clamp (Mathf.InverseLerp (bounds.min.x, bounds.max.x, pos.x), 0.0f, 0.9999f);
		float py = Mathf.Clamp (Mathf.InverseLerp (bounds.min.z, bounds.max.z, pos.z), 0.0f, 0.9999f);
		// calculate coordinate in tiles
		tileX = (int)(px * width / tileWidth);
		tileY = (int)(py * height / tileHeight);
	}

	// Compute list of tile positions that need to be visible, based on camera position.
	// This is quick-n-dirty code that just creates a List each time. In production you might want to avoid that.
	List<Vector2> GetTilesThatNeedToBePresent (Vector3 pos)
	{
		int tx, ty;
		PositionToTileCoord (pos, out tx, out ty);
		List<Vector2> res = new List<Vector2> ();
		// Basically it's a square grid of tiles centered around camera. Need to make sure it
		// does not go outside of valid tile range, when we're near the edges of the world.
		for (var y = Mathf.Max(ty-visibleTileRadius,0); y <= Mathf.Min(ty+visibleTileRadius,tileCountY-1); ++y)
		{
			for (var x = Mathf.Max(tx-visibleTileRadius,0); x <= Mathf.Min(tx+visibleTileRadius,tileCountX-1); ++x)
			{
				res.Add (new Vector2 (x, y));
			}
		}
		return res;
	}

	// Generate all tiles from the coordinate and upload them to the texture.
	// In a real world scenario this would probably stream in some texture data from disk or network.
	// Here we just generate a simple procedural pattern.
	void GenerateTiles (List<Vector2> tiles)
	{
		for (var i = 0; i < tiles.Count; ++i)
		{
			var pos = tiles[i];
			GenerateSingleTile ((int)pos.x, (int)pos.y);
		}
	}

	// Generates a single tile filled with a simple procedural pattern.
	void GenerateSingleTile (int tx, int ty)
	{
		Color32 col = new Color32 (0, 0, 0, 0);
		int idx = 0;
		for (int y = 0; y < tileHeight; ++y)
		{
			int py = ty * tileHeight + y;
			for (int x = 0; x < tileWidth; ++x)
			{
				int px = tx * tileWidth + x;

				// The pattern here isn't nice looking or clever, just
				// something based on px,py coordinates.
				col.r = (byte)((px ^ py) & 255);
				col.g = (byte)((py & 1) << 7);
				col.g += (byte)(px / 13);
				col.b = (byte)((px & py) == 0 ? 255 : 32);
				col.b += (byte)(py / 19);
				col.a = (byte)((px ^ py) & 255);

				tileColors[idx] = col;
				++idx;
			}
		}
		texture.UpdateTile (tx, ty, 0, tileColors);
	}

	void OnDisable ()
	{
		renderer.sharedMaterial.mainTexture = null;
		DestroyImmediate (texture);
	}

	void InitializeThings ()
	{
		DestroyImmediate (texture);
		texture = new SparseTexture (width, height, TextureFormat.RGB24, 1);
		texture.hideFlags = HideFlags.HideAndDontSave;
		tileWidth = texture.tileWidth;
		tileHeight = texture.tileHeight;
		tileCountX = (width + tileWidth - 1) / tileWidth;
		tileCountY = (height + tileHeight - 1) / tileHeight;

		bounds = renderer.bounds;

		tileColors = new Color32[tileWidth * tileHeight];

		tilesPresent = new List<Vector2> ();
	}
	
	void LateUpdate ()
	{
		if (!SystemInfo.supportsSparseTextures)
			return;

		if (!texture || !texture.isCreated)
			InitializeThings ();
		renderer.sharedMaterial.mainTexture = texture;

		Vector3 camPos = Camera.main.transform.position;
		var newTilesPresent = GetTilesThatNeedToBePresent (camPos);
		// quick-n-dirty linq to calculate differences between the "were present before" and "should be present now"
		// tile lists.
		List<Vector2> tilesToUnload = tilesPresent.Except (newTilesPresent).ToList();
		List<Vector2> tilesToGenerate = newTilesPresent.Except (tilesPresent).ToList();

		foreach (var t in tilesToUnload)
			texture.UnloadTile ((int)t.x, (int)t.y, 0);
		GenerateTiles (tilesToGenerate);

		if (tilesToUnload.Count > 0 || tilesToGenerate.Count > 0)
		{
			UIInstructions ui = GetComponent<UIInstructions> ();
			if (ui)
				ui.SetMessage (string.Format ("Tiles: generated {0} & removed {1} tiles", tilesToGenerate.Count, tilesToUnload.Count));
		}

		tilesPresent = newTilesPresent;
	}

}
