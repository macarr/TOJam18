using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{

    public GameObject gateRight;
    public GameObject gateLeft;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Skeleton")
        {
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
