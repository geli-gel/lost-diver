using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

	public GameObject mine;
	public float delayTimer = 2.2f;
	float timer;
	int mineCount = 0;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () 
	//	decrease delayTimer every 5 mines
	{		
		delayTimer = Mathf.Clamp (delayTimer, .4f, delayTimer);
		if (mineCount >= 5) {
			delayTimer -= .2f;
			mineCount = 0;
		}


		// instantiate the mines within range of screen and add to mine count
		timer -= Time.deltaTime;
			if (timer <= 0) {
				Vector3 minePos = new Vector3 (Random.Range (-2.5f, 2.55f), transform.position.y, transform.position.z);

				Instantiate (mine, minePos, transform.rotation);
				mineCount += 1;
				timer = delayTimer;
			}
		}
	}