using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    float walk;
	void Start () {
    

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.K)) {
            GetComponent<Animator>().SetTrigger("exit");
            GetComponent<Animator>().SetTrigger("kick");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
            GetComponent<Animator>().SetTrigger("exit");
            if (Input.GetKey(KeyCode.UpArrow)) {
           
            GetComponent<Animator>().SetTrigger("walk");

            if (Input.GetKey(KeyCode.P)) {
               GetComponent<Animator>().SetFloat("speed",walk);
                walk += 0.1f;
              
        }
        if (Input.GetKey(KeyCode.M)) {
                    GetComponent<Animator>().SetFloat("speed", 0);walk -= 0.1f;
                
                }
           
        }

         if (Input.GetKey(KeyCode.U)) {
                GetComponent<Rigidbody>().AddForce(0f, 10f, 0f,ForceMode.Acceleration);
                                      }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(transform.rotation.x, -2, transform.rotation.z);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(transform.rotation.x, 2, transform.rotation.z);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(transform.rotation.x, 2, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<Rigidbody>().AddForce(0f, 300f,0f, ForceMode.Acceleration);
    }


    private void OnCollisionEnter(Collision collision) {
      
    }
}
