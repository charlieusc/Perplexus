using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrigerController : MonoBehaviour
{
	public List<GameObject> destinations;
	public List<string> triggerEvents;
	public List<string> startEvents;
	public bool destoryself = true;

	void Start ()
	{
		for (int i = 0; i < destinations.Count; ++i) {
			if (startEvents [i] == "") {
				continue;
			}
			destinations [i].SendMessage (startEvents [i], SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (!other.CompareTag ("Player")) {
			return;
		}
		for (int i = 0; i < destinations.Count; ++i) {
			if (triggerEvents [i] == "") {
				continue;
			}
			destinations [i].SendMessage (triggerEvents [i], SendMessageOptions.DontRequireReceiver);
		}
		if (destoryself) {
			Destroy (gameObject);
		}
	}
}