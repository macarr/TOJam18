using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{

    public GameObject gateRight;
    public GameObject gateLeft;
    AudioSource audioSource;
    GameObject animationManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animationManager = GameObject.Find("AnimationManager");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Skeleton")
        {
            animationManager.GetComponent<AnimationManager>().PlayPoofEffect(transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            UnlockDoors();
            gameObject.SetActive(false);
        }
    }

    private void UnlockDoors()
    {
        gateRight.GetComponent<OpenGate>().locked = false;
        gateLeft.GetComponent<OpenGate>().locked = false;
    }
}
