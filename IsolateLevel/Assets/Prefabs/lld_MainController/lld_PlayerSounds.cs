using UnityEngine;
using System.Collections;

public class lld_PlayerSounds : MonoBehaviour
{
	public Transform mCamera;
	public Transform listener;
	public AudioClip collisionSource;
	
	void OnCollisionEnter (Collision other)
	{
		if (!other.gameObject.CompareTag ("NoSound")) {
			AudioSource.PlayClipAtPoint (collisionSource, transform.position, Mathf.Abs (other.impulse.magnitude) * 0.04f);
		}
	}

	void Update ()
	{
		listener.position = transform.position * 0.9f + mCamera.position * 0.1f;
	}
}