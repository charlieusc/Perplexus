using UnityEngine;
using System.Collections;

public class MagnetforBall : MonoBehaviour {

	bool inside;
	Transform magnet;
	float radius = 5f;
	float force = 15f;
	public Rigidbody ball;
	void Start(){
		magnet = GameObject.Find("Magnet").GetComponent<Transform>();
		inside = false;
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Magnet") {
			inside = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Magnet") {
			inside = false;
		}
	}

	void FixedUpdate(){
		if(inside){
			Vector3 magnetField = magnet.position - transform.position;
			float index = (radius - magnetField.magnitude)/radius;
			ball.AddForce(force*magnetField*index);
		}
	}
}
