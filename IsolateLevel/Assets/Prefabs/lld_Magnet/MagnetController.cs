using UnityEngine;
using System.Collections;

public class MagnetController : MonoBehaviour
{
	public AudioClip magnetSource;
	public float force = 100f;
	private float sqrRange;

	void Start ()
	{
		sqrRange = GetComponent<SphereCollider> ().radius * Mathf.Max (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		sqrRange = sqrRange * sqrRange;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (magnetSource, other.transform.position);
		}
	}

	void OnTriggerStay (Collider other)
	{
		Vector3 normal = transform.position - other.transform.position;
		float ratio = Mathf.Max (0f, (sqrRange / normal.sqrMagnitude - 1f) / (sqrRange - 1f));
		other.attachedRigidbody.AddForce (other.attachedRigidbody.mass * force * ratio * normal);
	}
}