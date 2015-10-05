using UnityEngine;
using System.Collections;
using VirtualController;

public class lld_CameraFollow : MonoBehaviour
{
	public Transform tracing;
	private Vector3 offset;

	void Start ()
	{
		offset = new Vector3 (0.0f, 0.0f, -40.0f);
	}

	void Update ()
	{
		float zoom = Joysticks.GetAxis ("ViewZoom");
		zoom = 1.0f - (zoom / 60.0f);
		offset *= zoom;
		transform.position = tracing.position + offset;
	}
}