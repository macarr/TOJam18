using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementForward : MonoBehaviour
{

    public int positionInLine;

    public int previousDirection;
    //0 = no input
    //1 = left
    //2 = right


    public float baseMoveSpeed;

    public float moveSpeed;
    public float maxMoveSpeed;

    public float rotateSpeed;
    public float baseRotateSpeed;
    public float maxRotateSpeed;



    public Vector3 previousPosition;


    public GameObject inFrontSkeleton;
    public GameObject behindSkeleton;

    // Use this for initialization
    void Start()
    {
        baseMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(RecordPositionLater());

        if (positionInLine == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
               // increaseSpeedOnConstantSpin(2);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
              //  increaseSpeedOnConstantSpin(1);

            }
            else
            {
               // increaseSpeedOnConstantSpin(0);
            }

           // Debug.Log(previousPosition);
        }

        if (positionInLine != 0)
        {
            if (inFrontSkeleton != null)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                  //  transform.LookAt(inFrontSkeleton.GetComponent<PlayerMovementForward>().previousPosition);
                    transform.LookAt(inFrontSkeleton.transform.position);

                    //Was trting some stuff... ignore the 'dist' stuff for now

                    //float dist = Vector3.Distance(transform.position, inFrontSkeleton.transform.position);
                    //print("Distance to other: " + dist);


                    
                        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
                }
            }
        }

    }


    public IEnumerator RecordPositionLater()
    {
        yield return new WaitForSeconds(1.5f);
        previousPosition = transform.position;
    }

    void increaseSpeedOnConstantSpin(int direction)
    {
        if (direction == previousDirection)
        {
            moveSpeed *= 1.01f;
            if (moveSpeed > maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }

            rotateSpeed *= 1.01f;
           if (rotateSpeed > maxRotateSpeed)
           {
                rotateSpeed = maxRotateSpeed;
          }
        }
        else
        {
            moveSpeed = baseMoveSpeed;
            rotateSpeed = baseRotateSpeed;
        }
        previousDirection = direction;
    }
}

