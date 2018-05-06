using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyButton : MonoBehaviour {

    GameObject levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find(Constants.LevelManager);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
        {
            levelManager.GetComponent<LevelManager>().nextLevel();
        }
	}
}
