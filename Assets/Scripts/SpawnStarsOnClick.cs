using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStarsOnClick : MonoBehaviour {

    public GameObject starParticles;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(starParticles, transform);
        }
		
	}
}
