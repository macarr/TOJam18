using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    public bool locked;

    public bool inverse;

    public float lockedAmount;

    AudioSource audioSource;
    public GameObject rotateAroundThis;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (!locked && lockedAmount < 200)
        {
            if (lockedAmount == 50)
            {
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            }
            if (inverse)
            {
                transform.RotateAround(rotateAroundThis.transform.position, Vector3.up, -40 * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(rotateAroundThis.transform.position, Vector3.up, 40 * Time.deltaTime);
            }

            lockedAmount += 1;
        }
	}
}
