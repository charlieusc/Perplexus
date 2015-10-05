using UnityEngine;
using System.Collections;
using VirtualController;

public class lld_RotateFollow : MonoBehaviour
{
	void Update ()
	{
		float rotate = Joysticks.GetAxis ("ViewRotate");
		if (Mathf.Abs (rotate) > 0.5f) {
			rotate += (rotate > 0.0f) ? -0.5f : 0.5f;
			transform.Rotate (rotate + rotate, 0.0f, 0.0f);
		}
	}
}