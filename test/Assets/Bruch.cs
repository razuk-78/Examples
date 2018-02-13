using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Bruch : MonoBehaviour {
    int i=0;
    public Camera c;
    public Camera c1;
    public GameObject o;
    float distance=1;public GameObject T;
    public RenderTexture tex;
    public Material material;
    // Use this for initialization
    Vector3 UVp;
	void Start () {
        
	}
    Ray r;
    RaycastHit hit;
	// Update is called once per frame
	void Update () {
        zoom();
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Ray cursorRay = c.ScreenPointToRay(cursorPos);
        transform.position =UVp+T.transform.position;
        Debug.DrawRay(cursorPos, transform.forward*1000, Color.red);
        Physics.Raycast(cursorRay, out hit, 1000);
        if (hit.collider.gameObject.name == "whale") {
            UVp = new Vector3( (hit.textureCoord.x)-c1.orthographicSize, ( hit.textureCoord.y) - c1.orthographicSize, 2f);
            if (Input.GetKey(KeyCode.Mouse0)) {
                Instantiate(o,T.transform).transform.localPosition = UVp;
              
            }
            Debug.Log("------------------x" + hit.textureCoord.x);
            Debug.Log("------------------y" + hit.textureCoord.y);

        }
       
	}
    void zoom() {
        if (Input.GetKey(KeyCode.C)) {
            distance+=0.1f;
        }
        if (Input.GetKey(KeyCode.Z)) {
            distance -= 0.1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            save();
        }

    }
    void save() {

   RenderTexture.active = tex;
        Texture2D txt = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
        txt.ReadPixels(new Rect( 0,0, 1024, 1024),0,0);
        txt.Apply();
      RenderTexture.active = null;
       material.mainTexture = txt;
    foreach(Transform  g in  GameObject.Find("bruchContainer").transform) {
            Destroy(g.gameObject);
        }
    }


}
