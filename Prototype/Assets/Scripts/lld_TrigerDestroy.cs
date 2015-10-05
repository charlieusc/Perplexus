using UnityEngine;
using System.Collections;

public class lld_TrigerDestroy : MonoBehaviour
{
	void OnDestroy ()
	{
		Destroy (gameObject);
	}
}