using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignDialogue : MonoBehaviour {

    public GameObject masterCanvas;


    public float moveCounter;
    public int dialogueIndex;


    public float[] moveMilestones;
    public string[] charName;
    public string[] newText;



    private void Awake()
    {
        Debug.Log("test");
        masterCanvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.8 || Input.GetAxis("Horizontal") < -0.8)
        {
            moveCounter += Time.deltaTime;
            // increaseSpeedOnConstantSpin(2);
        }

        if (moveCounter >= moveMilestones[dialogueIndex])
        {
            masterCanvas.GetComponent<ControlDialogue>().newDialogue(charName[dialogueIndex], newText[dialogueIndex]);
            dialogueIndex++;

            if (dialogueIndex >= moveMilestones.Length)
            {
                Destroy(gameObject);
            }
        }

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
                masterCanvas.GetComponent<ControlDialogue>().newDialogue(charName[0],newText[0]);
                Destroy(gameObject);
            }
        } 
    }
}
