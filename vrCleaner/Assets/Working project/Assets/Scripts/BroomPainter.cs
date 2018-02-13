using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPainter : MonoBehaviour {
    public GameObject SprayImpact;
    public Transform RaycastOrigin;
    public float SprayRange;
    public LayerMask ImpactMask;
    public AudioSource audio;
    public GameObject Broom;
    // Update is called once per frame

    private void Awake()
    {
        
    }
    void FixedUpdate () {
        Ray ray = new Ray(RaycastOrigin.position, RaycastOrigin.forward);
        RaycastHit hit;
        Debug.DrawRay(RaycastOrigin.position, RaycastOrigin.forward * SprayRange, Color.blue);
        if (Physics.Raycast(ray, out hit, SprayRange, ImpactMask))
        {
            WaterScript water = hit.collider.gameObject.GetComponent<WaterScript>();
            if (water)
            {
                water.Rewater();

            }
            else
            {
                GameObject spray = Instantiate(SprayImpact, hit.point, Quaternion.LookRotation(Vector3.forward, hit.normal));
            }
            //PlayAudio2();
            PlayAudioIfBroomMove();
        } else
        {
            audio.Stop();
        }
            
        
    }
    

    private Vector3 oldPos;
    public float tolerance;

    public void PlayAudio2()
    {
        float d = (transform.position - oldPos).magnitude / Time.fixedDeltaTime;
        if (d >= tolerance)
        {
            if (!audio.isPlaying)
                audio.Play();
        } else {
            audio.Stop();
        }
        oldPos = transform.position;
    }
    
    float oldx = -1000, oldz;float counter = 0;
    private void PlayAudioIfBroomMove()
    {
        
        if (oldx == -1000)
        {
            if (!audio.isPlaying)
                audio.Play();
            oldx = gameObject.transform.position.x; oldz = gameObject.transform.position.z;
            return ;

        }

        if (Mathf.Abs(oldx - Broom.transform.position.x) > 0.01 || Mathf.Abs(oldz - Broom.transform.position.z) > 0.01)
        {
            Debug.Log("X : "+Mathf.Abs(oldx - Broom.transform.position.x));
            Debug.Log("Z : "+Mathf.Abs(oldz - Broom.transform.position.z));

            if (!audio.isPlaying)
               audio.Play();
            oldx = Broom.transform.position.x;
            oldz= Broom.transform.position.z;
            counter = 0;
            return ;
        } else 
        {
            counter += Time.fixedDeltaTime;
            if (counter > 0.5)
            {

                Debug.Log("stop..................................................stop ");
                Debug.Log("X : " + Mathf.Abs(oldx - Broom.transform.position.x));
                Debug.Log("Z : " + Mathf.Abs(oldz - Broom.transform.position.z));
                Debug.Log("stop A..................................................stop A");
                audio.Stop();
                counter = 0;
            }

            
        }
        return ;
    }
}
