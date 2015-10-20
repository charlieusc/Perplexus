using UnityEngine;
using System.Collections;

public class ElasticityController : MonoBehaviour
{
	public AudioClip bouncySource;
	public float bouncy = 1.2f;
	public Material bouncyEffect;
	public float maxspeed = 200.0f;
	/***************************/
	private Renderer render;
	private int bouncyOccur = 0;
	private Material oldMaterial;

	void Start ()
	{
		render = GetComponent<Renderer> ();
		oldMaterial = render.material;
	}

	void Update ()
	{
		if (bouncyOccur > 0) {
			--bouncyOccur;
			if (bouncyOccur == 0) {
				render.material = oldMaterial;
			}
		}
	}

	void OnCollisionEnter (Collision other)
	{
		render.material = bouncyEffect;
		Vector3 normal = Vector3.zero;
		foreach (ContactPoint contact in other.contacts) {
			normal += contact.point;
		}
		normal = Vector3.Normalize (other.transform.position * other.contacts.Length - normal);
		float speedtogo = Vector3.Dot (normal, other.relativeVelocity) * (-bouncy);
		if (speedtogo > 0.0f) {
			other.rigidbody.velocity = Vector3.ClampMagnitude (other.rigidbody.velocity + normal * speedtogo, maxspeed);
		}
		bouncyOccur = 5;
		AudioSource.PlayClipAtPoint (bouncySource, other.transform.position);
	}
}