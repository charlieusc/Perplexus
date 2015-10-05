using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VirtualController;

public class lld_PlayerController : MonoBehaviour
{
	public float speed = 0.5f;
	public Text winText;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		speed *= rb.mass * 9.8f;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Joysticks.GetAxis ("Horizontal") * speed;
		float moveVertical = Joysticks.GetAxis ("Vertical") * speed;
		rb.AddForce (moveHorizontal, moveVertical, 0.0f);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Win")) {
			winText.text = "You Win!";
			Destroy (other.gameObject);
			Application.LoadLevel ("Menu 3D");
		}
	}
}