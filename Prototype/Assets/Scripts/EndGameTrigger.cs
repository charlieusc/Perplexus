using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "Ball") {
			if (Application.loadedLevelName == "MariaTest") {
				Application.LoadLevel ("Menu 3D");
			} 
			else {
				Application.LoadLevel ("MariaTest");
			}
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
