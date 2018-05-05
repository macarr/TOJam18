using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {
    public float delayToLoadLevel = 1f;

    GameObject levelManager;
    public GameObject poofEffect;
    private bool initiated = false;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skeleton")
        {
            if(!initiated)
            {
                Debug.Log("Finished level");
                StartCoroutine(WinLevel());
                initiated = true;
            }
            //Instantiate(poofEffect, other.transform);
            other.gameObject.SetActive(false);
        }
    }


    IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(delayToLoadLevel);
        levelManager.GetComponent<LevelManager>().nextLevel();
    }
}
