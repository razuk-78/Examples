using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VaccumCleaner : VRTK_InteractableObject
{

    public WindZone Wind;

    public Collider Killbox;
    public AudioSource StartSound;
    public AudioSource RunningSound;
    public AudioSource StopSound;

    protected override void Awake()
    {
        base.Awake();
        foreach (var dust in GameObject.FindGameObjectsWithTag("Dust"))
        {
            var particles = dust.GetComponent<ParticleSystem>();
            if (particles)
            {
                var trigger = particles.trigger;
                trigger.SetCollider(0, Killbox);
            }
        }
        //StopSuccing();
    }
    

    public void StartSuccing()
    {
        Wind.gameObject.SetActive(true);
        Killbox.gameObject.SetActive(true);
        StartSound.Play();
        StopSound.Stop();
        RunningSound.PlayDelayed(2);
    }

    public void StopSuccing()
    {
        Wind.gameObject.SetActive(false);
        Killbox.gameObject.SetActive(false);
        StopSound.Play();
        RunningSound.Stop();
        StartSound.Stop();
    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        StartSuccing();
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    {
        base.StopUsing(previousUsingObject);
        StopSuccing();
    }
    
}
