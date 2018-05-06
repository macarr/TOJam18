using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : EnemyDamage {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.Skeleton)
        {
            other.gameObject.GetComponent<PlayerMovement>().Explode();
            LoseLevel();
        }
    }
}
