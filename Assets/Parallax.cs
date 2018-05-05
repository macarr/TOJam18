using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float parallaxSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(parallaxSpeed*Time.deltaTime, 0.0f, 0.0f);


        if (transform.position.x >= 203.0f)
        {
            //  Debug.Log("thing: " + transform.position.x);

            transform.position = new Vector3(transform.position.x - 406.0f, transform.position.y, transform.position.z);
           // transform.Translate(-40.6f, 0.0f, 0.0f);

        }
	}
}
