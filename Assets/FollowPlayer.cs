using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    public float cameraLimitTop;
    public float cameraLimitBottom;
    public float distanceFromPlayer;


    public GameObject leadSkeleton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (leadSkeleton != null)
        {
            transform.LookAt(leadSkeleton.transform);

            transform.position = new Vector3(transform.position.x, transform.position.y, leadSkeleton.transform.position.z - distanceFromPlayer);

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
}
