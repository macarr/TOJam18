using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {
    public float delayToLoadLevel = 1f;

    GameObject levelManager;
    GameObject animationManager;
    private bool initiated = false;

    private void Awake()
    {
        levelManager = GameObject.Find(Constants.LevelManager);
        animationManager = GameObject.Find(Constants.AnimationManager);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.Skeleton)
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
        levelManager.GetComponent<LevelManager>().NextLevel();
    }
}
