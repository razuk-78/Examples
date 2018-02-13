using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {
    public float DecayTime;
    private int DecayLevel;
    public Material[] WaterMaterials;
    private Renderer renderer;

    public float CleanUpRemain;

	// Use this for initialization
	void Start () {
        renderer = GetComponentInChildren<Renderer>();
        Invoke("Decay", DecayTime);
	}

    public void Rewater()
    {
        CancelInvoke("Decay");
        DecayLevel = 0;
        renderer.material = WaterMaterials[0];
        Invoke("Decay", DecayTime);
    }

    public void CleanUp(float cleaningTime)
    {
        CleanUpRemain -= cleaningTime;
        if (CleanUpRemain <= 0)
        {
           // renderer.material = WaterMaterials[WaterMaterials.Length-1];
            CancelInvoke("Decay");
            Destroy(gameObject);
        }
    }

    public void Decay()
    {
        DecayLevel++;
        if (DecayLevel >= WaterMaterials.Length) {
            Destroy(gameObject);
        } else {
            renderer.material = WaterMaterials[DecayLevel];
            Invoke("Decay", DecayTime);
        }
    }
	
	
}
