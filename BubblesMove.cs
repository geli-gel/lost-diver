using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesMove : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0,1,0) * speed * Time.deltaTime);
		if (transform.position.y > 6.7f) {
			Destroy (gameObject);
		}


	}
	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}

}