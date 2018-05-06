using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignDialogue : MonoBehaviour {

    public GameObject masterCanvas;

    public string charName;
    public string newText;



    private void Awake()
    {
        Debug.Log("test");
        masterCanvas = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Skeleton"))
        {
            if (masterCanvas == null)
            {
                Debug.Log("he;pl");
            }
            else
            {
                masterCanvas.GetComponent<ControlDialogue>().newDialogue(charName,newText);
                Destroy(gameObject);
            }
        } 
    }
}
