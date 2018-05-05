using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BobUpAndDown : MonoBehaviour {

    public float bobTween;

    public float bobSpeed;
    public float offset;

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

        transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Cos(bobTween + offset)*0.02f), transform.position.z);
		
	}
}
