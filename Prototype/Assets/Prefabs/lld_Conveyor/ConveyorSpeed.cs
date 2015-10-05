using UnityEngine;
using System.Collections;

public class ConveyorSpeed : MonoBehaviour
{
	public float speed = 5.0f;
	public float friction = 0.8f;
	private float oldspeed = 0.0f;

	void OnPaused ()
	{
		oldspeed = speed;
		speed = 0.0f;
	}

	void OnRestart ()
	{
		speed = oldspeed;
	}
}