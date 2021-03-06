﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BobUpAndDown : MonoBehaviour {

    public float bobTween;

    public float bobSpeed;
    public float offset;
    public float scale = 1f;

    public bool goingUp;
    //true = bobbing up
    //false = bobbing down


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        bobTween += bobSpeed;
        if (bobTween > 360)
            bobTween -= 360;

        transform.position = new Vector3(transform.position.x, transform.position.y + scale * (Mathf.Cos(bobTween + offset)*Time.deltaTime*0.5f), transform.position.z);
		
	}
}
