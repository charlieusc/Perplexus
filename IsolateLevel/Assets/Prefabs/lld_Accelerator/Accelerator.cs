using UnityEngine;
using System.Collections;

public class Accelerator : MonoBehaviour
{
	public float force = 8.0f;
	private AudioSource windSound;

	void Start ()
	{
		windSound = GetComponent<AudioSource> ();
		windSound.Pause ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			windSound.UnPause ();
		}
	}

	void OnTriggerStay (Collider other)
	{
		other.attachedRigidbody.AddForce (transform.right * other.attachedRigidbody.mass * force);
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			windSound.Pause ();
		}
	}
}