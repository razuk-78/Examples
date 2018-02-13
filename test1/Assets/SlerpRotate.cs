using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpRotate : MonoBehaviour {

    // Use this for initialization
    public Transform t;
    public float x, y, z;
    Vector3 relativepos;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        relativepos =(t.position+new Vector3(x,y,z))-transform.position ;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativepos), Time.deltaTime);
      
        transform.Translate(0, 0, 3 * Time.deltaTime);
	}
}
