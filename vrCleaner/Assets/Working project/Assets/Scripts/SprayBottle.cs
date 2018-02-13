using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SprayBottle : VRTK_InteractableObject
{
    public GameObject SprayImpact;
    public Transform RaycastOrigin;
    public float SprayRange;
    public AudioSource audio;
    public ParticleSystem particles;
    public LayerMask ImpactMask;
    

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        FireBullet();
    }

    private void FireBullet()
    {
        audio.Play();
        particles.Emit(50);

        Debug.Log("Spray!");
        Ray ray = new Ray(RaycastOrigin.position, RaycastOrigin.forward);
        RaycastHit hit;
        Debug.DrawRay(RaycastOrigin.position, RaycastOrigin.forward * SprayRange, Color.blue);
        if (Physics.Raycast(ray, out hit, SprayRange, ImpactMask)) {
            WaterScript water = hit.collider.gameObject.GetComponent<WaterScript>();
            if (water)
            {
                    water.Rewater();
            }
            else
            {

                GameObject spray = Instantiate(SprayImpact, hit.point, Quaternion.LookRotation(Vector3.forward, hit.normal));
            }
        }
    }
}
