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


        if (transform.position.x >= 40.6)
        {
            //  Debug.Log("thing: " + transform.position.x);

            transform.position = new Vector3();
            transform.Translate(-60.9f, 0.0f, 0.0f);

        }
	}
}
