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
			if (Application.loadedLevelName == "Level_2") {
				Application.LoadLevel ("Level_3");
			} 
			else {
				Application.LoadLevel ("Level_2");
			}
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
