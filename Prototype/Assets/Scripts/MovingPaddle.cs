using UnityEngine;
using System.Collections;

public class MovingPaddle : MonoBehaviour {

    bool right;

	// Use this for initialization
	void Start () {
        right = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (right)
        {
            transform.Translate(new Vector3(1,0,0) * Time.deltaTime);

        }
        else
        {
            transform.Translate(new Vector3(-1,0,0) * Time.deltaTime);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Ball" && !collision.gameObject.name.Contains("Z"))
        {
            right = !right;
        }
    }
}
