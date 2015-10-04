using UnityEngine;
using System.Collections;

public class BeltController : MonoBehaviour
{
	public GameObject father;
	private float speed;
	private float friction;

	void Start ()
	{
		float distance = father.transform.localScale.x;
		float radian = Mathf.Min (distance, father.transform.localScale.z);
		transform.localScale = new Vector3 (2.0f - radian / distance, transform.localScale.y, 1.0f);
		speed = father.GetComponent<ConveyorSpeed> ().speed;
		friction = father.GetComponent<ConveyorSpeed> ().friction;
	}

	static float ValueMap (float value)
	{
		return value / (value + 1.0f);
	}

	private void HandleCollision (Collision other)
	{
		int count = 0;
		Vector3 normal = Vector3.zero;
		foreach (ContactPoint dot in other.contacts) {
			normal += dot.point;
			++count;
		}
		normal = Vector3.Normalize ((normal / count) - gameObject.transform.position);
		Vector3 direct = (Vector3.Dot (normal, transform.forward) > 0.0f) ? transform.right : (-transform.right);
		float speedtogo = speed - Vector3.Dot (direct, other.relativeVelocity);
		if (speedtogo != 0.0f) {
			float impulse = Vector3.Dot (normal, other.impulse) * friction / (other.rigidbody.mass * Mathf.Abs (speed));
			other.rigidbody.velocity += direct * speedtogo * Mathf.Min (1.0f, impulse);
		}
	}
	
	void OnCollisionEnter (Collision other)
	{
		HandleCollision (other);
	}
	
	void OnCollisionStay (Collision other)
	{
		if (!other.impulse.Equals (Vector3.zero)) {
			HandleCollision (other);
		}
	}
}