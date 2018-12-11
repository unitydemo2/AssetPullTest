using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float speed = 3.0f;

	void Update () {
		var pos = transform.position;
		pos.x -= Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		pos.z -= Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		transform.position = pos;
	}
}
