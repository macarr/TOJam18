using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateIn : MonoBehaviour {

    public AnimationCurve animateCurve;

    public float lerpAmount;
    public float animationTime;


    public Vector3 animationDirection;
    public Vector3 animationRotation;
    public Vector3 animationScale;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        // Calculate the appropriate pitch (x rotation) for the camera based on current zoom       
        float targetRotX = animateCurve.Evaluate(lerpAmount);

        // The desired yaw (y rotation) is to match that of the target object
        float targetRotY = gameObject.transform.rotation.eulerAngles.y;

        // Create target rotation as quaternion
        // Set z to 0 as we don't want to roll the camera
        Quaternion targetRot = Quaternion.Euler(targetRotX, targetRotY, 0.0f);

        // Calculate in world-aligned axis, how far back we want the camera to be based on current zoom
        Vector3 offset = Vector3.forward * animateCurve.Evaluate(lerpAmount);

        // Then subtract this offset based on the current camera rotation
        Vector3 targetPos = transform.position - targetRot * offset;

        lerpAmount += Time.deltaTime;
        if (lerpAmount > animationTime)
        {
            lerpAmount = animationTime;
        }else
        {
            transform.Translate(animationDirection.x, animationDirection.y, animationDirection.z);
            transform.Rotate(transform.rotation.x + animationRotation.x, transform.rotation.y + animationRotation.y, transform.rotation.z + animationRotation.z);
            transform.localScale += new Vector3(animationScale.x, animationScale.y, animationScale.z);


        }
    }
}
