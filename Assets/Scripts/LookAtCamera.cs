using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LookAtCamera : MonoBehaviour {

    public GameObject camMain;

    public bool dontSkew;


    // Use this for initialization
    void Start () {
		if (camMain == null)
        {
            camMain = GameObject.Find("Main Camera");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (dontSkew)
        {
            transform.forward = camMain.transform.forward;
        }
        else
        {
            transform.LookAt(2 * transform.position - camMain.transform.position, Vector3.up);
        }
       
    }
}
