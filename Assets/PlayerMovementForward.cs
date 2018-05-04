using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementForward : MonoBehaviour {

    public int positionInLine;

    public float moveSpeed;
    public float rotateSpeed;



    public GameObject inFrontSkeleton;
    public GameObject behindSkeleton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (positionInLine == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0,rotateSpeed,0);
                transform.Translate(Vector3.forward * moveSpeed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -rotateSpeed, 0);
                transform.Translate(Vector3.forward * moveSpeed);
            }
        }

        if (positionInLine != 0)
        {
            if (inFrontSkeleton != null)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.LookAt(inFrontSkeleton.transform);
                    transform.Translate(Vector3.forward * (moveSpeed * 1.0f));
                }
            }
        }

    }
}
