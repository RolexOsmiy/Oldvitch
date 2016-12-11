using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{
	public Transform target;
	public float distance = 6.0f;
	public float maxDistance = 6.0f;
	float tmpDistance = 6.0f;

	public float rotateSpeed = 10;

	public float bufferup = 1.5f;
	public float bufferright = 0.75f;

	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -50f;
	public float yMaxLimit = 50f;

	private float x = 0.0f;
	private float y = 0.0f;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}

	void Update ()
	{
		if(Input.GetMouseButton(1))
		{
			distance -= 20*Time.deltaTime;
		}
		else
		{
			if(distance <= tmpDistance)
			{
				distance += 20*Time.deltaTime;
			}
		}
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if (target)
		{
			//distance -= .5f * Input.mouseScrollDelta.y;
			if (distance < 3)
			{
				distance = 3;
			}
			if (distance > maxDistance)
			{
				distance = maxDistance;
			}
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(bufferright, 0.0f, -distance) + target.position + new Vector3(0.0f, bufferup, 0.0f);

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
}