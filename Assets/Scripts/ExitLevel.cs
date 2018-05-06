using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {
    public float delayToLoadLevel = 1f;

    GameObject levelManager;
    GameObject animationManager;
    public GameObject winEffect;
    public float winEffectDistanceFromCamera = 10f;
    public float winEffectVerticalOffset = -2f;
    private bool initiated = false;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager");
        animationManager = GameObject.Find("AnimationManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skeleton")
        {
            if(!initiated)
            {
                GameObject camera = Camera.main.gameObject;
                Debug.Log("Finished level");
                Camera.main.GetComponent<FollowPlayer>().StopFollowing();
                animationManager.GetComponent<AnimationManager>().PlayWinAnimation();
                StartCoroutine(WinLevel());
                initiated = true;
            }
            other.gameObject.SetActive(false);
        }
    }


    IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(delayToLoadLevel);
        levelManager.GetComponent<LevelManager>().nextLevel();
    }
}
