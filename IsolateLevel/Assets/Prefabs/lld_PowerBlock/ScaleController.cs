using UnityEngine;
using System.Collections;

public class ScaleController : MonoBehaviour
{
	public bool auto = true;
	public float Scale = 2f;
	public float TimeHalt = 2f;
	public float TimeDoScale = 5f;
	/*************************/
	private float minScale;
	private float maxScale;
	private float ScaleVel;
	private float Haltcount;

	void Start ()
	{
		minScale = Mathf.Min (transform.localScale.z, Scale);
		maxScale = Mathf.Max (transform.localScale.z, Scale);
		ScaleVel = (maxScale - minScale) / TimeDoScale;
		Haltcount = TimeHalt;
		Scale = transform.localScale.z;
	}

	void Update ()
	{
		if (transform.localScale.z != Scale) {
			float cache = ScaleVel * Time.deltaTime;
			cache = Mathf.Max (Mathf.Min (Scale - transform.localScale.z, cache), -cache);
			transform.position += transform.forward * cache * 0.5f;
			transform.localScale += new Vector3 (0f, 0f, cache);
		} else if (auto) {
			if (Haltcount <= 0f) {
				Scale = (Scale == minScale) ? maxScale : minScale;
				Haltcount = TimeHalt;
			} else {
				Haltcount -= Time.deltaTime;
			}
		}
	}

	void OnReverse ()
	{
		Scale = (Scale == minScale) ? maxScale : minScale;
	}
}