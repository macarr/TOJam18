﻿using System.Collections;
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

    public GameObject skullSprite;


    public Sprite[] character1Sprites;
    public Sprite[] character2Sprites;
    public Sprite[] character3Sprites;
    public Sprite[] character4Sprites;
    public Sprite[] character5Sprites;

    public int spriteIndex;


    public int dialogueIndex;

    public float updateTimer;
    public float updateInterval;


    private Text txtRefName;
    private Text txtRefBody;
    public Image imageRef;



    private void Awake()
    {
        txtRefName = nameField.GetComponent<Text>();//or provide from somewhere else (e.g. if you want via find GameObject.Find("CountText").GetComponent<Text>();)
        txtRefBody = textField.GetComponent<Text>();//or provide from somewhere else (e.g. if you want via find GameObject.Find("CountText").GetComponent<Text>();)

        imageRef = textField.GetComponent<Image>();
    }



    // Use this for initialization
    void Start () {

        dialogueIndex = 0;
        spriteIndex = 0;

        updateInterval = 0.15f;
		
	}
	
	// Update is called once per frame
	void Update () {

       /*
         if (Input.anyKeyDown)
        {
            newDialogue("bonefred", "Boneburt, no!");
        }
       */

        updateDialogue();
		
	}

    public void newDialogue(string newCharacter, string newText)
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

       // updateTimer += 0.01f;


        if (updateTimer >= updateInterval)
        {
            if (dialogueIndex < upcomingText.Length)
            {
                currentText += upcomingText[dialogueIndex];

                if (upcomingText[dialogueIndex]!= ' ' && upcomingText[dialogueIndex] != ',' 
                    && upcomingText[dialogueIndex] != '.' && upcomingText[dialogueIndex] != '.')
                    GetComponent<AudioSource>().Play();

                txtRefBody.text = currentText;
                dialogueIndex++;

                spriteIndex++;

               

                if (characterName.Contains("Bonesly"))
                {
                    GameObject.Find("SkullSprite").GetComponent<Image>().sprite = character2Sprites[spriteIndex % character2Sprites.Length];
                }
                else
                {
                    GameObject.Find("SkullSprite").GetComponent<Image>().sprite = character1Sprites[spriteIndex % character1Sprites.Length];
                }

                //GameObject.Find("SkullSprite").GetComponent<RectTransform>().rotation.SetEulerRotation(0,0,90);

                //imageRef.sprite = character1Sprites[1];

                updateTimer -= updateInterval;
            }
            else if (updateTimer >= (updateInterval*15 + 5.0f))
            {
                master.SetActive(false);
            }
        }

    }
}
