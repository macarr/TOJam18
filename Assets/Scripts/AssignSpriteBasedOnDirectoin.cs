using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSpriteBasedOnDirectoin : MonoBehaviour {

    public GameObject associatedSkeleton;

    public Sprite[] directionSprites;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (associatedSkeleton.GetComponent<PlayerMovementForward>().positionInLine == 0)
         Debug.Log(associatedSkeleton.GetComponent<DetermineDirection>().direction + " , " + directionSprites[associatedSkeleton.GetComponent<DetermineDirection>().direction]);

        if (associatedSkeleton != null)
        {
            GetComponent<SpriteRenderer>().sprite = directionSprites[associatedSkeleton.GetComponent<DetermineDirection>().direction];
        }
	}
}
