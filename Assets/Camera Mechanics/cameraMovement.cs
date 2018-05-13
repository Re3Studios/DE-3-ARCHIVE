using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float panSpeed = 20f;
	public float rotSpeed;

	public Vector2 panLimit;
	private float mouseX;

	void Update () {

		Rotate();

		float horizontal = Input.GetAxis ("Horizontal") * panSpeed * Time.deltaTime;
		float vertical = Input.GetAxis ("Vertical") * panSpeed * Time.deltaTime;

        transform.Translate (Vector3.forward * vertical);
		transform.Translate (Vector3.right * horizontal);

	}

	public void Rotate() {

		if (Input.GetMouseButton(2)) {
				var cameraRotationY = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
                transform.Rotate(0, cameraRotationY, 0);
		}
	}		
}
