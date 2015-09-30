using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (Time.time < nextFire)
			return;
		nextFire += fireRate;
		rb.AddForce (transform.up * -50.0f);
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}

	void LateUpdate()
	{
		transform.Rotate (0.0f, 0.0f, 0.5f);
	}
}