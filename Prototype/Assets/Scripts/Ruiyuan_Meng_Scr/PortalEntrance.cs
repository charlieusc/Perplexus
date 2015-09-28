using UnityEngine;
using System.Collections;

public class PortalEntrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            other.gameObject.transform.position = GameObject.Find("Des").gameObject.transform.position + GameObject.Find("Des").gameObject.transform.up * 0.5f;
        }
    }
}
