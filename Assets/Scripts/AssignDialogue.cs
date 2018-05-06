using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignDialogue : MonoBehaviour {

    public GameObject masterCanvas;


    public float moveCounter;
    public int dialogueIndex;

    public bool dialogueOver;


    public float[] moveMilestones;
    public string[] charName;
    public string[] newText;



    private void Awake()
    {
        Debug.Log("test");
        masterCanvas = GameObject.Find("Canvas");

        dialogueOver = true;
    }

    void Update()
    {
        if ((Input.GetAxis("Horizontal") > 0.8 || Input.GetAxis("Horizontal") < -0.8) && dialogueOver)
        {
            moveCounter += Time.deltaTime;
            // increaseSpeedOnConstantSpin(2);
        }

        if (moveCounter >= moveMilestones[dialogueIndex])
        {
            dialogueOver = false;
            masterCanvas.GetComponent<ControlDialogue>().newDialogue(charName[dialogueIndex], newText[dialogueIndex]);
            dialogueIndex++;

            if (dialogueIndex >= moveMilestones.Length)
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            dialogueOver = true;
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
