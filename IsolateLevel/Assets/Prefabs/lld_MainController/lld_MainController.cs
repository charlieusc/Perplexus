using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VirtualController;

public class lld_MainController : MonoBehaviour
{
	public Transform world;
	public Transform player;
	public float gravityTheta = 0f;
	public float cameraMaxLen = 40f;
	/**************************/
	private Vector3 currentup;
	private Vector3 currentlook;
	private float zoomval = 0.0f;
	private float maxzoom = 0.9f;
	private bool gyroexist = false;

	void Start ()
	{
		transform.position = world.position + cameraMaxLen * world.up;
		currentup = world.forward * Mathf.Cos (gravityTheta) + world.right * Mathf.Sin (gravityTheta);
		transform.LookAt (world.position, currentup);
		gyroexist = Input.gyro.enabled;
	}

	void FixedUpdate ()
	{
		float xcache = Joysticks.GetAxis ("ViewRotate");
		if (Mathf.Abs (xcache) <= 0.1f) {
			xcache = 0f;
		} else {
			xcache = ((xcache < 0f) ? (xcache + 0.2f) : (xcache - 0.2f)) * 0.03f;
			gravityTheta -= xcache;
		}

		float ycache = Joysticks.GetAxis ("ViewZoom");
		if (Mathf.Abs (ycache) <= 0.2f) {
			ycache = 0f;
		} else {
			ycache = ((ycache < 0f) ? (ycache + 0.2f) : (ycache - 0.2f)) * 0.01f;
			zoomval = Mathf.Min (Mathf.Max (0.0f, zoomval + ycache), maxzoom);
		}

		float scaledzoomval = zoomval / maxzoom;
		Vector3 desirePos = (1.0f - scaledzoomval) * world.position + scaledzoomval * player.position + (1.0f - zoomval) * cameraMaxLen * world.up;
		if (!desirePos.Equals (transform.position)) {
			transform.position += Vector3.ClampMagnitude (desirePos - transform.position, 0.5f);
		}
		Vector3 desireUp = world.forward * Mathf.Cos (gravityTheta) + world.right * Mathf.Sin (gravityTheta);
		if (!desireUp.Equals (currentup)) {
			currentup += Vector3.ClampMagnitude (desireUp - currentup, 0.07f);
		}
		Vector3 desirelook = (1.0f - scaledzoomval) * world.position + scaledzoomval * player.position;
		if (!desirelook.Equals (currentlook)) {
			currentlook += Vector3.ClampMagnitude (desirelook - currentlook, 0.5f);
		}
		transform.LookAt (currentlook, currentup);

		if (gyroexist) {
			Vector3 realgravity = Input.gyro.gravity;
			Physics.gravity = (transform.right * realgravity.x + transform.up * realgravity.y) * 9.8f;
		} else {
			Physics.gravity = currentup * -9.8f;
		}
	}
}