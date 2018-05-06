using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    GameObject levelManager;
    GameObject camera;

    // Use this for initialization
    void Awake ()
    {
        levelManager = GameObject.Find("LevelManager");
        camera = GameObject.Find("Main Camera");
    }

    public void LoseLevel()
    {
        camera.GetComponent<FollowPlayer>().StopFollowing();
        StartCoroutine(WaitAndLoseLevel());
    }

    IEnumerator WaitAndLoseLevel()
    {
        yield return new WaitForSeconds(Constants.WaitAfterDeath);
        levelManager.GetComponent<LevelManager>().resetLevel();
    }


}
