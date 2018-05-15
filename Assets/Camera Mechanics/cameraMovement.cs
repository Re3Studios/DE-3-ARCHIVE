using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float panSpeed;
	public float rotSpeed;
    public float boostSpeed;

	public Vector2 panLimit;
	private float mouseX;

	void Update () {

		Rotate();

        if (Input.GetKey(KeyCode.LeftShift))
        {

            float horizontal = Input.GetAxis("Horizontal") * boostSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * boostSpeed * Time.deltaTime;

            transform.Translate(Vector3.forward * vertical);
            transform.Translate(Vector3.right * horizontal);
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;

            transform.Translate(Vector3.forward * vertical);
            transform.Translate(Vector3.right * horizontal);
        }
    }

	public void Rotate() {

		if (Input.GetMouseButton(2)) {
				var cameraRotationY = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
                transform.Rotate(0, cameraRotationY, 0);
		}
	}		
}
