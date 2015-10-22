using UnityEngine;
using System.Collections;

public class ChangeWorldTrigger : MonoBehaviour
{
	public AudioClip victorySource;
	public GameObject mcamera;
	public Transform newWorld;
	private bool todo = true;

	void OnCollisionExit (Collision other)
	{
		if (todo && other.gameObject.CompareTag ("Player")) {
			todo = false;
			mcamera.GetComponent<lld_MainController> ().world = newWorld;
			AudioSource.PlayClipAtPoint (victorySource, other.transform.position, 0.5f);
		}
	}
}