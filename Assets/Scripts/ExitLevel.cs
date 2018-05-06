using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {
    public float delayToLoadLevel = 1f;

    GameObject levelManager;
    public GameObject winEffect;
    public float winEffectDistanceFromCamera = 10f;
    public float winEffectVerticalOffset = -2f;
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
                GameObject camera = Camera.main.gameObject;
                Debug.Log("Finished level");
                Camera.main.GetComponent<FollowPlayer>().StopFollowing();
                Vector3 animationPosition = camera.transform.position + camera.transform.forward * winEffectDistanceFromCamera;
                animationPosition.y = animationPosition.y + winEffectVerticalOffset;
                Quaternion animationRotation = new Quaternion(camera.transform.rotation.x, camera.transform.rotation.y, 0.0f, camera.transform.rotation.w);
                GameObject.Find("Canvas").SetActive(false);
                Instantiate(winEffect, animationPosition, animationRotation);
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
