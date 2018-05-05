using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlDialogue : MonoBehaviour {

    public string upcomingText;
    public string currentText;

    public string characterName;

    public GameObject nameField;
    public GameObject textField;
    public GameObject master;


    public int dialogueIndex;

    public float updateTimer;
    public float updateInterval;


    private Text txtRefName;
    private Text txtRefBody;


    private void Awake()
    {
        txtRefName = nameField.GetComponent<Text>();//or provide from somewhere else (e.g. if you want via find GameObject.Find("CountText").GetComponent<Text>();)
        txtRefBody = textField.GetComponent<Text>();//or provide from somewhere else (e.g. if you want via find GameObject.Find("CountText").GetComponent<Text>();)

    }



    // Use this for initialization
    void Start () {

        dialogueIndex = 0;
        updateInterval = 0.15f;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            newDialogue("bonefred2", "Boneburt, no!");
        }

        updateDialogue();
		
	}

    void newDialogue(string newCharacter, string newText)
    {
        master.SetActive(true);

        dialogueIndex = 0;
        currentText = "";

        txtRefBody.text = "";


        characterName = newCharacter;

        txtRefName.text = newCharacter;

        upcomingText = newText;
    }

    void updateDialogue()
    {
        updateTimer += Time.deltaTime;


        if (updateTimer >= updateInterval)
        {
            if (dialogueIndex < upcomingText.Length)
            {
                currentText += upcomingText[dialogueIndex];
                txtRefBody.text = currentText;
                dialogueIndex++;
                updateTimer -= updateInterval;
            }
            else if (updateTimer >= updateInterval*15)
            {
                master.SetActive(false);
            }
        }

    }
}
