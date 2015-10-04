using UnityEngine;
using System.Collections;

public class Accelerator : MonoBehaviour
{
	public float force = 8.0f;

	void OnTriggerStay (Collider other)
	{
		other.attachedRigidbody.AddForce (transform.right * other.attachedRigidbody.mass * force);
	}
}