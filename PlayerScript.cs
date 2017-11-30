using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public uiManager ui;
	public int mineHitCount;
	public int bubblesHitCount;

	[SerializeField]
	private Stat oxygen;
	// Using Awake() rather than Start() to call Stat's initialization function because barscript might need info from awake not from start
	private void Awake()
	{
		oxygen.Initialize ();
	}

	void Start ()
	{
		InvokeRepeating ("oxygenDecrease", 1.1f, 1.1f);
		mineHitCount = 0;
		bubblesHitCount = 0;
	}

	
	// Update is called once per frame
	void Update () 
	{
			
		//test example!!!!
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			oxygen.CurrentVal -= 10;		
		}
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			oxygen.CurrentVal += 10;		
		}

		if (oxygen.CurrentVal == 0) 
		{
			ui.gameOverActivated ();
			Destroy (gameObject);
		}		
	
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag == "Obstacle") {
			oxygen.CurrentVal -= 10;
			mineHitCount += 1;
		}
		if (col.gameObject.tag == "Bubbles") {
			oxygen.CurrentVal += 7;
			bubblesHitCount += 1;
		}

	}

	void oxygenDecrease ()
	{
		if (Time.timeScale == 1) 
		{
			oxygen.CurrentVal -= 1;
		} 
	}

}
