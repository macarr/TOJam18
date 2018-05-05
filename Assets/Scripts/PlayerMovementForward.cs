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

    public float bounceDist;
    bool moveCommitted = false;
    public float minimumMoveSeconds;

    public Vector3 previousPosition;
    public float followDistance;


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
            if(!moveCommitted)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    moveCommitted = true;
                    StartCoroutine(MoveMinimum( MoveScale.Positive));
                    // increaseSpeedOnConstantSpin(2);

                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    moveCommitted = true;
                    StartCoroutine(MoveMinimum(MoveScale.Negative));
                    //  increaseSpeedOnConstantSpin(1);

                }
            }

           // Debug.Log(previousPosition);
        }

        if (positionInLine != 0 && inFrontSkeleton != null)
        {

            if (Vector3.Distance(inFrontSkeleton.transform.position, transform.position) > 2f)
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

    private enum MoveScale { Positive, Negative, }

    IEnumerator MoveMinimum(MoveScale moveScale)
    {
        float start = Time.time;
        float end = Time.time + minimumMoveSeconds;
        while (Time.time < end)
        {
            switch (moveScale) {
                case MoveScale.Positive:
                    transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    checkBounce();
                    break;
                case MoveScale.Negative:
                    transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    checkBounce();
                    break;
                default:
                    break;
            }
            yield return null;
        }
        while(Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        {
            yield return null;
        }
        moveCommitted = false;
    }

    void checkBounce()
    {
        Vector3 bounceVector = Bounce();
        if(bounceVector != Vector3.zero)
        {
            transform.rotation = Quaternion.FromToRotation(transform.right, bounceVector);
        }
    }

    Vector3 Bounce()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, bounceDist))
        {
            Vector3 incomingVector = hit.point - transform.position;
            Vector3 reflectVec = Vector3.Reflect(incomingVector, hit.normal);
            Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            Debug.DrawRay(hit.point, reflectVec, Color.green);
            return reflectVec;
        }
        return Vector3.zero;
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

