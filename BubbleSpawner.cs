using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

	public GameObject bubbles;
	public float delayTimer = 4f;
	float timer;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}

	// Update is called once per frame
	void Update () 
	{

		// instantiate the mines within range of screen and add to mine count
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 bubblePos = new Vector3 (Random.Range (-2.5f, 2.55f), transform.position.y, transform.position.z);

			Instantiate (bubbles, bubblePos, transform.rotation);
			timer = delayTimer;
		}
	}
}