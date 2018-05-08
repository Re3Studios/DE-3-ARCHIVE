using UnityEngine;

public class Zoom : MonoBehaviour {

	public GameObject Sphere;
	public GameObject Camera;

	public float scrollSpeed = 10f;
	public float minY = 10f;
	public float maxY = 10f;

	// Update is called once per frame
	void Update () {

		Vector3 area = transform.position;

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		area.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        area.y = Mathf.Clamp (area.y, minY, maxY);

        transform.position = area;

		Camera.transform.LookAt(Sphere.transform.position);
	}
}
