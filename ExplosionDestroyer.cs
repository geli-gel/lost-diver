using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExplosionDestroyer : MonoBehaviour 
{
	public float speed = 1.5f;

	void Update() 
	{
		transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	} 
}
