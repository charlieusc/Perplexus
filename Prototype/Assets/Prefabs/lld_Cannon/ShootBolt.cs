using UnityEngine;
using System.Collections;

public class ShootBolt : MonoBehaviour
{
	public float minfireInterval = 2.0f;
	public float maxfireInterval = 3.0f;
	public float boltSpeed = 50.0f;
	public Transform SpawnPos;
	public GameObject bolt;
	/*********************/
	private float nextFire = 0.0f;
	private bool pause = false;
	private int count = 0;

	void Update ()
	{
		if ((++count != 10) || (pause)) {
			return;
		}
		count = 0;
		if (Time.time >= nextFire) {
			nextFire = Time.time + Random.Range (minfireInterval, maxfireInterval);
			GameObject newbolt = Instantiate (bolt, SpawnPos.position, SpawnPos.rotation) as GameObject;
			newbolt.transform.parent = SpawnPos;
			newbolt.GetComponent<Rigidbody> ().velocity = newbolt.transform.up * boltSpeed;
		}
	}
}