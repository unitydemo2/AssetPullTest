using UnityEngine;

[ExecuteInEditMode]
public class UIInstructions : MonoBehaviour
{
	private string message = string.Empty;
	private float time = -1000.0f;

	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (2, 2, 350, 120), GUI.skin.box);
		GUILayout.Label ("Press Play and use arrow keys to move camera around. This creates a big texture on the plane, and generates/unloads tiles of it based on camera position.");
		float msgTime = Time.time - time;
		if (msgTime < 1.0f && !string.IsNullOrEmpty(message))
		{
			GUI.color = new Color (1,1,1,1.0f-msgTime);
			GUILayout.Label (message);
			GUI.color = Color.white;
		}
		if (!SystemInfo.supportsSparseTextures)
			GUILayout.Label ("Oh well, looks like your platform/GPU does not support sparse textures :(");
		GUILayout.EndArea ();
	}

	public void SetMessage (string msg)
	{
		message = msg;
		time = Time.time;
	}
}
