using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    GameObject levelManager;
    GameObject animationManager;

    // Use this for initialization
    void Awake ()
    {
        levelManager = GameObject.Find("LevelManager");
        animationManager = GameObject.Find("AnimationManager");
    }

    public void LoseLevel()
    {
        Camera.main.GetComponent<FollowPlayer>().StopFollowing();
        animationManager.GetComponent<AnimationManager>().PlayLoseAnimation();
        StartCoroutine(WaitAndLoseLevel());
    }

    IEnumerator WaitAndLoseLevel()
    {
        yield return new WaitForSeconds(Constants.WaitAfterDeath);
        levelManager.GetComponent<LevelManager>().resetLevel();
    }


}
