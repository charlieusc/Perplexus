using UnityEngine;
using System.Collections;

public class BoltLife : MonoBehaviour
{
	public float liveLife = 40.0f;
	public float dieLife = 30.0f;
	private float startdieTime;
	private int count = 0;
	private float mass;

	void Start ()
	{
		startdieTime = Time.time + liveLife;
		mass = GetComponent<Rigidbody> ().mass;
	}

	void Update ()
	{
		if (++count != 25) {
			return;
		}
		count = 0;
		if (Time.time > startdieTime) {
			float percent = 1.0f - (Time.time - startdieTime) / dieLife;
			if (percent < 0.1f) {
				Destroy (gameObject);
				return;
			}
			transform.localScale = new Vector3 (percent, percent, percent);
			GetComponent<Rigidbody> ().mass = mass * percent;
		}
	}
}