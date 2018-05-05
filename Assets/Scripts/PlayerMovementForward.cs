using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementForward : MonoBehaviour
{

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
    bool directionCommitted = false;
    public float minimumMoveSeconds;
    
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
        if(!directionCommitted)
        {
            if (Input.GetAxis("Horizontal") > 0.8)
            {
                directionCommitted = true;
                StartCoroutine(DoMovement(MoveScale.Positive));
                // increaseSpeedOnConstantSpin(2);
            }
            else if (Input.GetAxis("Horizontal") < -0.8)
            {
                directionCommitted = true;
                StartCoroutine(DoMovement(MoveScale.Negative));
                //  increaseSpeedOnConstantSpin(1);
            }
        }
    }

    private enum MoveScale { Positive, Negative, }

    private void HandlePlayerMovement(MoveScale moveScale)
    {
        if(inFrontSkeleton != null)
        {
            Debug.LogError("Follower tried to call player movement :(");
            return;
        }
        switch (moveScale)
        {
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
    }

    private void HandleFollowerMovement() {
        if (inFrontSkeleton == null)
        {
            Debug.LogError("Follower movement called by player :(");
            return;
        }
        if (Vector3.Distance(inFrontSkeleton.transform.position, transform.position) > followDistance)
        {
            //transform.LookAt(inFrontSkeleton.GetComponent<PlayerMovementForward>().previousPosition);
            transform.LookAt(inFrontSkeleton.transform.position);

            //Was trting some stuff... ignore the 'dist' stuff for now

            //float dist = Vector3.Distance(transform.position, inFrontSkeleton.transform.position);
            //print("Distance to other: " + dist);
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
        }
        
    }

    IEnumerator DoMovement(MoveScale moveScale)
    {
        float start = Time.time;
        float end = start + minimumMoveSeconds;
        while (Time.time < end || 
            (moveScale == MoveScale.Positive && Input.GetAxis("Horizontal") > 0.8 ||
            moveScale == MoveScale.Negative && Input.GetAxis("Horizontal") < -0.8))
        {
            if (inFrontSkeleton == null)
                HandlePlayerMovement(moveScale);
            else
                HandleFollowerMovement();
            yield return null;
        }
        directionCommitted = false;
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


    /*public IEnumerator RecordPositionLater()
    {
        yield return new WaitForSeconds(1f);
        previousPosition = transform.position;
    }*/

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

