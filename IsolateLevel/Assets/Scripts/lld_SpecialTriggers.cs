using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lld_SpecialTriggers : MonoBehaviour
{
	void OnDestroy ()
	{
		Destroy (gameObject);
	}

	void OnWin ()
	{
		Text winText = GetComponent<Text> ();
		winText.text = "You Win!";
	}
}