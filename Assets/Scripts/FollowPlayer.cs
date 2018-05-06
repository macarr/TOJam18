using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public bool lookAtPlayer;

    public float cameraLimitTop;
    public float cameraLimitBottom;

    public float distanceFromPlayer;

    public float minDistanceFromPlayer;
    public float maxDistanceFromPlayer;



    public GameObject leadSkeleton;

    // Use this for initialization
    void Start () {

        if (leadSkeleton == null)
        {
            leadSkeleton = GameObject.Find("Skeleton");
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (leadSkeleton != null)
        {
            if (lookAtPlayer)
            {
                transform.LookAt(leadSkeleton.transform);
            }

            Vector3 dist = transform.position - leadSkeleton.transform.position;
            //print("Distance from player: " + dist);


            if (Mathf.Abs(dist.z) > maxDistanceFromPlayer)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, leadSkeleton.transform.position.z - maxDistanceFromPlayer);
            }
            else if (Mathf.Abs(dist.z) < minDistanceFromPlayer)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, leadSkeleton.transform.position.z - minDistanceFromPlayer);
            }

            if (transform.position.z < cameraLimitBottom)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, cameraLimitBottom);
            }

            if (transform.position.z > cameraLimitTop)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, cameraLimitTop);
            }
        }
    }

    public void StopFollowing()
    {
        Destroy(this);
    }
}
