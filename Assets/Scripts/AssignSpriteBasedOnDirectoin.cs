using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSpriteBasedOnDirectoin : MonoBehaviour {

    public GameObject associatedSkeleton;

    public Sprite[] directionSprites1;
    public Sprite[] directionSprites2;
    public Sprite[] directionSprites3;
    public Sprite[] directionSprites4;

    public float animCycleCounter;
    public float animCycleInterval;





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        animCycleCounter += Time.deltaTime;

       // if (associatedSkeleton.GetComponent<PlayerMovementForward>().positionInLine == 0)
       //Debug.Log(associatedSkeleton.GetComponent<DetermineDirection>().direction + " , " + directionSprites1[associatedSkeleton.GetComponent<DetermineDirection>().direction]);

        if (associatedSkeleton != null)
        {

            if (animCycleCounter < animCycleInterval * 1)
            {
                GetComponent<SpriteRenderer>().sprite = directionSprites1[associatedSkeleton.GetComponent<DetermineDirection>().direction];
            }
            else if (animCycleCounter < animCycleInterval * 2)
            {
                GetComponent<SpriteRenderer>().sprite = directionSprites2[associatedSkeleton.GetComponent<DetermineDirection>().direction];
            }
            else if (animCycleCounter < animCycleInterval * 3)
            {
                GetComponent<SpriteRenderer>().sprite = directionSprites3[associatedSkeleton.GetComponent<DetermineDirection>().direction];
            }
            else if (animCycleCounter < animCycleInterval * 4)
            {
                GetComponent<SpriteRenderer>().sprite = directionSprites4[associatedSkeleton.GetComponent<DetermineDirection>().direction];
            }
            else
            {
                animCycleCounter -= animCycleInterval * 4;
                GetComponent<SpriteRenderer>().sprite = directionSprites1[associatedSkeleton.GetComponent<DetermineDirection>().direction];
            }

        }
	}
}
