using UnityEngine;
using System.Collections;

public class ConveyorBeltEvent : MonoBehaviour {

	public float BeltSpeed = 1;
	ContactPoint finalContact;
	Vector3 beltDir;
	bool onBelt = false;
	Rigidbody ballRb;
	Transform belt, wheel1;

	void Start(){
		ballRb = GameObject.Find ("Ball").GetComponent<Rigidbody> ();
		onBelt = false;
		belt = GameObject.Find ("Belt").GetComponent<Transform> ();
		wheel1 = GameObject.Find ("Wheel1").GetComponent<Transform> ();
	}
	/*
	//Raugh version
	*/
	void OnCollisionEnter(Collision collision) {
		onBelt = true;
	}
	void OnCollisionExit(Collision collision) {
		onBelt = false;
	}

	void FixedUpdate(){
		if (onBelt == true) {
			//Debug.Log("moving!");
			Vector3 beltDir = wheel1.position - belt.position;
			if(belt.up.y > 0){
				ballRb.AddForce(beltDir*BeltSpeed);
			}
			else{
				ballRb.AddForce(-beltDir*BeltSpeed);
			}
		}
	}
}
