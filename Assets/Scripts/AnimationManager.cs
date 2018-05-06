using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    GameObject _instance = null;
    public float effectDistFromCamera;
    public float effectVerticalOffset;
    public GameObject winEffect;
    public GameObject loseEffect;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        if (_instance != gameObject)
            Destroy(gameObject);

    }

    public void PlayWinAnimation()
    {
        GameObject gameCamera = Camera.main.gameObject;
        Vector3 animationPosition = gameCamera.transform.position + gameCamera.transform.forward * effectDistFromCamera;
        animationPosition.y = animationPosition.y + effectVerticalOffset;
        Quaternion animationRotation = new Quaternion(gameCamera.transform.rotation.x, gameCamera.transform.rotation.y, 0.0f, gameCamera.transform.rotation.w);
        GameObject.Find("Canvas").SetActive(false);
        Instantiate(winEffect, animationPosition, animationRotation);
    }

    public void PlayLoseAnimation()
    {
        GameObject gameCamera = Camera.main.gameObject;
        Vector3 animationPosition = gameCamera.transform.position + gameCamera.transform.forward * effectDistFromCamera;
        animationPosition.y = animationPosition.y + effectVerticalOffset;
        Quaternion animationRotation = new Quaternion(gameCamera.transform.rotation.x, gameCamera.transform.rotation.y, 0.0f, gameCamera.transform.rotation.w);
        GameObject.Find("Canvas").SetActive(false);
        Instantiate(loseEffect, animationPosition, animationRotation);

    }
}
