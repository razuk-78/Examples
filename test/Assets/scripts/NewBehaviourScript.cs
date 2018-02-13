using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    float x;
	void Start () {
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
          


            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*100);
        }
       



    }
}
