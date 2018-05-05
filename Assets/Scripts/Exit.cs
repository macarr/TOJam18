using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public GameObject levelManager;

    private void Awake()
    {
        Debug.Log("test");
        levelManager = GameObject.Find("LevelManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Skeleton"))
        {
            if(levelManager != null)
            {
                Debug.Log("he;pl");
            }
            levelManager.GetComponent<LevelManager>().nextLevel();
        } 
    }
}
