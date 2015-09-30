using UnityEngine;
using System.Collections;

public class MagnetEvent : MonoBehaviour {

	bool inside;
	Transform magnet;
	float radius = 5f;
	float force = 15f;
	Rigidbody ballRb;

	void Start(){
		magnet = GameObject.Find("Magnet").GetComponent<Transform>();
		inside = false;
		ballRb = GameObject.Find ("Ball").GetComponent<Rigidbody> ();
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Ball") {
			inside = true;
			//Debug.Log("Enter meg zone!");
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Ball") {
			inside = false;
		}
	}

	void FixedUpdate(){
		if(inside){
			Vector3 magnetField = magnet.position - ballRb.position;
			float index = (radius - magnetField.magnitude)/radius;
			ballRb.AddForce(force*magnetField*index);
		}
	}
}
