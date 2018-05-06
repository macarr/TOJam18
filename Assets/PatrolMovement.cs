using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour {

    public enum Path
    {
        Horizontal,
        Vertical,
    }

    Vector3 startPos;
    public Path path;
    public float leashDistance = 3f;
    public float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(gameObject.transform.position, startPos) > leashDistance)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
