using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMove : MonoBehaviour {

	public GameObject ExplosionGO;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0,-1,0) * speed * Time.deltaTime);
		
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			PlayExplosion ();
		}
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);
		explosion.transform.position = transform.position;
	}
}