using UnityEngine;
using System.Collections;

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
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveSide = Input.GetAxis ("Side");
		transform.RotateAround (Vector3.zero, Vector3.up, moveHorizontal);		
		transform.RotateAround (Vector3.zero, Vector3.right, moveVertical);
		transform.RotateAround (Vector3.zero, Vector3.forward, moveSide);
		/*Movement Control End*/
	}
}
