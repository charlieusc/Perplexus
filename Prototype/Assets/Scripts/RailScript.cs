using UnityEngine;
using System.Collections;
using VirtualController;

public class RailScript : MonoBehaviour 
{
	public float tiltX;
	public float tiltY;
	public float tiltZ;
//
//	void Start ()
//	{
//		transform
//	}
//	
//	void Update() 
//	{
//		float angle = Quaternion.Angle(transform.rotation, target.rotation);
//	}
//	
	void Update ()
	{


	}

	void FixedUpdate () 
	{
		/*Movement Control Start*/
		float moveHorizontal = Joysticks.GetAxis ("Horizontal");
		float moveVertical = Joysticks.GetAxis ("Vertical");
		float moveSide = Joysticks.GetAxis ("Row");
		transform.RotateAround (Vector3.zero, Vector3.up, -moveHorizontal);		
		transform.RotateAround (Vector3.zero, Vector3.right, moveVertical);
		transform.RotateAround (Vector3.zero, Vector3.forward, -moveSide);
		/*Movement Control End*/
	}
}
