using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S)) {
        Debug.Log("localPos"+transform.localPosition.x);
        Debug.Log("Position"+transform.position.x);
        }
       
    }
}
