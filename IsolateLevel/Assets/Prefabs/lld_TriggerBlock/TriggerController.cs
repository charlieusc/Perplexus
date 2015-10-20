using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerController : MonoBehaviour
{
	public AudioClip triggerSource;
	public List<GameObject> tasks;
	public List<string> startEvents;
	public List<string> enterEvents;
	public List<string> exitEvents;

	void Start ()
	{
		for (int i = 0; i < startEvents.Count; ++i) {
			if (startEvents [i] != "") {
				tasks [i].SendMessage (startEvents [i], SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (!other.CompareTag ("Player")) {
			return;
		}
		for (int i = 0; i < enterEvents.Count; ++i) {
			if (enterEvents [i] != "") {
				tasks [i].SendMessage (enterEvents [i], SendMessageOptions.DontRequireReceiver);
			}
		}
		AudioSource.PlayClipAtPoint (triggerSource, other.transform.position);
	}

	void OnTriggerExit (Collider other)
	{
		if (!other.CompareTag ("Player")) {
			return;
		}
		for (int i = 0; i < exitEvents.Count; ++i) {
			if (exitEvents [i] != "") {
				tasks [i].SendMessage (exitEvents [i], SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}