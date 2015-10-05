using UnityEngine;
using System.Collections;

public class ScaleController : MonoBehaviour
{
	public float Scale = 2.0f;
	public float scaleTime = 10.0f;
	public float stopTime = 2.0f;
	/*************************/
	private int scaleupcount;
	private int scalestaycount;
	private int scaledowncount;
	private float scaleperframe;

	void Start ()
	{
		scaleupcount = (int)(scaleTime * 25.0f);
		scalestaycount = (int)(stopTime * 50.0f);
		scaledowncount = scaleupcount;
		scaleperframe = Scale / scaleupcount;
	}

	void Update ()
	{
		if (scaleupcount != 0) {
			--scaleupcount;
			transform.position += transform.up * scaleperframe * 0.5f;
			transform.localScale += new Vector3 (0.0f, scaleperframe, 0.0f);
			return;
		}
		if (scalestaycount != 0) {
			--scalestaycount;
			return;
		}
		if (scaledowncount != 0) {
			--scaledowncount;
			transform.position -= transform.up * scaleperframe * 0.5f;
			transform.localScale -= new Vector3 (0.0f, scaleperframe, 0.0f);
			return;
		}
		scaleupcount = (int)(scaleTime * 25.0f);
		scalestaycount = (int)(stopTime * 50.0f);
		scaledowncount = scaleupcount;
	}
}