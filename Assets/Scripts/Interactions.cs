using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {

    public GameObject poofEffect;

	// Use this for initialization
	void Start ()
    {
        Instantiate(poofEffect, gameObject.transform) ;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
