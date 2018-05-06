using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour {

    GameObject player;

    public float moveSpeed = 0.5f;
    public float rotateSpeed = 5f;
    public bool onlyMoveWithPlayer = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Skeleton");
	}
	
	// Update is called once per frame
	void Update () {
		if(!onlyMoveWithPlayer || player.GetComponent<PlayerMovement>().IsMoving())
        {
            RotateTowardsPlayer();
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
	}

    void RotateTowardsPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        Quaternion resultRotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed);
        resultRotation = Constants.ClampRotationToY(resultRotation);
        transform.rotation = resultRotation;
    }
}
