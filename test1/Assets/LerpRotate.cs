using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotate : MonoBehaviour {
    public float x, y, z,a;
    // Use this for initialization
    public Transform t;
	void Start () {
        
	}
	
	// Update is called once per frame

	void Update () {

        transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(t.position),Time.time*0.001f);
	}
}
