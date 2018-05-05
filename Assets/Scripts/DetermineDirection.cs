using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineDirection : MonoBehaviour {


    public int direction;
    //0 = up
    //1 = up-right
    //2 = right
    //3 = down-right
    //4 = down
    //5 = down-left
    //6 = left
    //7 = up-left

    public float degreeOfRotation;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        degreeOfRotation = transform.rotation.eulerAngles.y;
        //Debug.Log(degreeOfRotation);

        if (degreeOfRotation >= 22.5 && degreeOfRotation < 67.5)
        {
            direction = 1;
        }
        else if (degreeOfRotation >= 67.5 && degreeOfRotation < 112.5)
        {
            direction = 2;
        }
        else if (degreeOfRotation >= 112.5 && degreeOfRotation < 157.5)
        {
            direction = 3;
        }
        else if (degreeOfRotation >= 157.5 && degreeOfRotation < 202.5)
        {
            direction = 4;
        }
        else if(degreeOfRotation >= 202.5 && degreeOfRotation < 247.5)
        {
            direction = 5;
        }
        else if (degreeOfRotation >= 247.5 && degreeOfRotation < 292.5)
        {
            direction = 6;
        }
        else if(degreeOfRotation >= 292.5 && degreeOfRotation < 337.5)
        {
            direction = 7;
        }
        else
        {
            direction = 0;
        }


    }
}
