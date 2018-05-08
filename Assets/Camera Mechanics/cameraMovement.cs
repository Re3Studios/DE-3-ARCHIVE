using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float panSpeed = 20f;
	public float rotSpeed = 80f;

	public Vector2 panLimit;
	private float mouseX;


	void Start() {
		
	}

	// Update is called once per frame
	void Update () {

		Rotate();

		float horizontal = Input.GetAxis ("Horizontal") * panSpeed * Time.deltaTime;
		float vertical = Input.GetAxis ("Vertical") * panSpeed * Time.deltaTime;

        transform.Translate (Vector3.forward * vertical);
		transform.Translate (Vector3.right * horizontal);

		mouseX = Input.mousePosition.x;

	}

	public void Rotate() {

		var easeFactor = 10f;

		if (Input.GetMouseButton(2)) {
			if (Input.mousePosition.x != mouseX) {
				var cameraRotationY = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
				transform.Rotate(0, cameraRotationY, 0);
			}
		}
	}		
}
