using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomSprite : MonoBehaviour {

    public Sprite[] availableSprites;
    public int lastSprite;
    public float spriteTransitionTime;
    float lastTransition;

	// Use this for initialization
	void Start () {
        lastTransition = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastTransition >= spriteTransitionTime)
        {
            int nextSprite;
            do
            {
                nextSprite = Random.Range(0, availableSprites.Length - 1);
            } while (nextSprite == lastSprite);
            gameObject.GetComponent<SpriteRenderer>().sprite = availableSprites[nextSprite];
            lastTransition = Time.time;
            lastSprite = nextSprite;
        }
    }
}
