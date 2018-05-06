using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class swapSpriteAfterTime : MonoBehaviour {

    public float timeCounter;
    public float swapTime;


    public Sprite newSprite;


    public AudioSource source;

    public AudioClip swapSound;


    // Use this for initialization
    void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        timeCounter += Time.deltaTime;
        if (timeCounter >= swapTime)
        {
            GetComponent<AudioSource>().clip = swapSound;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = newSprite;
            Destroy(this);
        }
		
	}
}
