using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveScriptCopy : MonoBehaviour {

	float directionX;
	public float playerspeed;
	Vector3 position;
	public Animator anim;
	float leftMax;
	float rightMax;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
		position = transform.position;
		leftMax = -2.75f;
		rightMax = 2.85f;

	}

	// Update is called once per frame
	void FixedUpdate () {
		//ex: if player is at far left: do a change only if axis is to right, then do any axis change
		//    else if player is at far right: do a change only if axis is to left, then do any axis

		// if player is at far left and axis is leaning to right, move the player, otherwise, don't
		if (position.x == leftMax && CrossPlatformInputManager.GetAxis ("Horizontal") >= 0) 
		{
			Debug.Log("player is at far left and axis leaning to right");
			position.x += CrossPlatformInputManager.GetAxis ("Horizontal") * playerspeed * Time.deltaTime;
			//directionX = CrossPlatformInputManager.GetAxis ("Horizontal");
			transform.position = position;
			transform.position = new Vector3 (Mathf.Clamp (position.x, leftMax, rightMax), position.y, position.z);
		} 
		else if (position.x == leftMax && CrossPlatformInputManager.GetAxis ("Horizontal") < 0) 
		{
			Debug.Log ("player is at far left and axis leaning to left");
			transform.position = position;		
		}

		// if player is at far right and axis is leaning to left, move the player, otherwise, don't
		else if (position.x == rightMax && CrossPlatformInputManager.GetAxis ("Horizontal") <= 0) 
		{
			position.x += CrossPlatformInputManager.GetAxis ("Horizontal") * playerspeed * Time.deltaTime;
			//directionX = CrossPlatformInputManager.GetAxis ("Horizontal");
			transform.position = position;
			transform.position = new Vector3 (Mathf.Clamp (position.x, leftMax, rightMax), position.y, position.z);
		} 
		else if (position.x == rightMax && CrossPlatformInputManager.GetAxis ("Horizontal") > 0) 
		{
			transform.position = position;		
		} 

		else 
		
		{
			Debug.Log (position.x);
			position.x += CrossPlatformInputManager.GetAxis ("Horizontal") * playerspeed * Time.deltaTime;
			//directionX = CrossPlatformInputManager.GetAxis ("Horizontal");
			transform.position = position;
			transform.position = new Vector3 (Mathf.Clamp (position.x, leftMax, rightMax), position.y, position.z);
		}



		//rb.velocity = new Vector2 (directionX * Time.deltaTime, 0).normalized * 2;
		//rb.velocity = Vector2.ClampMagnitude (rb.velocity, 2);


//		example that uses a different approach
//		Vector3 pos = rb.position;
//		pos.x = Mathf.Clamp(pos.x, -2.75f, 2.85f);
//		rb.position = pos;

		//rb.position = new Vector2 (Mathf.Clamp(rb.position.x,-2.75f, 2.85f), rb.position.y); 

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Obstacle") {
			anim.SetTrigger ("impact");
			Destroy (col.gameObject);  
			// make O2 level go down
		}
			
	}
}
