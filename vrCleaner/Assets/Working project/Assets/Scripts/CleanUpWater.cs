using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpWater : MonoBehaviour {

    public LayerMask WaterLayer;

    public BoxCollider boxCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 extend = boxCollider.size * 0.7f;
        Collider[] waters =  Physics.OverlapBox(boxCollider.transform.TransformPoint(boxCollider.center), extend,
            boxCollider.transform.rotation, WaterLayer);

        foreach (var v in waters)
        {
            WaterScript water = v.GetComponent<Collider>().gameObject.GetComponent<WaterScript>();
            water.CleanUp(Time.deltaTime);
        }
    }
}
