using UnityEngine;
using System.Collections;

public class BouncyElementEvent : MonoBehaviour {


	public float bouncyness = 1000;
	ContactPoint finalContact;
	//Raugh version
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			finalContact = contact;
		}
		collision.rigidbody.AddForce(finalContact.normal * bouncyness);
	}
	/*
	void OnCollisionExit(Collision collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
	}*/
}
