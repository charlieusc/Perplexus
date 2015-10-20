using UnityEngine;
using System.Collections;

public class ChangeWorldTrigger : MonoBehaviour
{
	public AudioClip victorySource;
	public GameObject mcamera;
	public Transform newWorld;

	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			mcamera.GetComponent<lld_MainController> ().world = newWorld;
			AudioSource.PlayClipAtPoint (victorySource, other.transform.position, 0.5f);
		}
	}
}