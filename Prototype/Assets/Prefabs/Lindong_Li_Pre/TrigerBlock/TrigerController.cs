using UnityEngine;
using System.Collections;

public class TrigerController : MonoBehaviour
{
	public string trigerName;
	public bool destoryself = true;

	void OnTriggerEnter (Collider other)
	{
		SendMessage (trigerName, SendMessageOptions.DontRequireReceiver);
		if (destoryself) {
			Destroy (gameObject);
		}
	}
}