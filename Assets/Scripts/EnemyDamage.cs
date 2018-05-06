using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    GameObject levelManager;

    // Use this for initialization
    void Awake ()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    public void LoseLevel()
    {
        Camera.main.GetComponent<FollowPlayer>().StopFollowing();
        StartCoroutine(WaitAndLoseLevel());
    }

    IEnumerator WaitAndLoseLevel()
    {
        yield return new WaitForSeconds(Constants.WaitAfterDeath);
        levelManager.GetComponent<LevelManager>().resetLevel();
    }


}
