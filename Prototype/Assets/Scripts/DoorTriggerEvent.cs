using UnityEngine;
using System.Collections;

public class DoorTriggerEvent : MonoBehaviour {

	public GameObject a;
	bool inTriggerZone = false;
	public float doorMaxSize = 13;
	public float doorMinSize = 1;
	public int doorDir = 0;

	void OnTriggerEnter(Collider other) {
		Debug.Log("Enter the trigger zone!");
		inTriggerZone = true;
	}

	/*unity bug
	void OnTriggerStay(Collider other) {
		Debug.Log("Stay in the trigger zone!");
		doorChange = true;
	}
	*/

	void OnTriggerExit(Collider other) {
		Debug.Log("Exit the trigger zone!");
		inTriggerZone = false;
	}


	
	void Update ()
	{
		if (inTriggerZone == true) {
			doorClose ();
		} else {
			doorOpen ();
		}

	}

	void doorClose(){
		switch(doorDir) 
		{
			case 0:
				if (a.transform.localScale.x < doorMaxSize) {
					a.transform.localPosition += new Vector3 (0.05f, 0, 0);
					a.transform.localScale += new Vector3 (0.1f, 0, 0);	
				}
				break;
			case 1:
				if (a.transform.localScale.y < doorMaxSize) {
					a.transform.localPosition += new Vector3 (0, 0.05f, 0);
					a.transform.localScale += new Vector3 (0, 0.1f, 0);
				}
				break;
			case 2:
				if (a.transform.localScale.z < doorMaxSize){
					a.transform.localPosition += new Vector3 (0, 0, 0.05f);
					a.transform.localScale += new Vector3 (0, 0, 0.1f);
				}
				break;
			default:
				break;
		}
	}

	void doorOpen(){
		switch(doorDir) 
		{
		case 0:
			if (a.transform.localScale.x > doorMinSize) {
				a.transform.localPosition -= new Vector3 (0.05f, 0, 0);
				a.transform.localScale -= new Vector3 (0.1f, 0, 0);	
			}
			break;
		case 1:
			if (a.transform.localScale.y > doorMinSize) {
				a.transform.localPosition -= new Vector3 (0, 0.05f, 0);
				a.transform.localScale -= new Vector3 (0, 0.1f, 0);
			}
			break;
		case 2:
			if (a.transform.localScale.z > doorMinSize){
				a.transform.localPosition -= new Vector3 (0, 0, 0.05f);
				a.transform.localScale -= new Vector3 (0, 0, 0.1f);
			}
			break;
		default:
			break;
		}
	}
}
