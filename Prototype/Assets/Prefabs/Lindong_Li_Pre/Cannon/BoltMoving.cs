using UnityEngine;
using System.Collections;

public class BoltMoving : MonoBehaviour
{
	public float speed = 20.0f;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("Bolt Terminal")) {
			Destroy (gameObject);
		}
	}
}
