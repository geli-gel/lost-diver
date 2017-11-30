using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Button[] buttons;
	public Text distanceText;
	public Text scoreText;
	float distance;
	float endDistance;
	float endScore;
	float endBubblesHitCount;
	float endMineHitCount;
	public PlayerScript player;

	// Use this for initialization
	void Start () {
		distance = 0f;
		InvokeRepeating ("distanceUpdate", 1.1f, 1.1f);
	}

	// Update is called once per frame
	void Update () {
		distanceText.text = "Distance: " + distance + " m"; 

	}

	void distanceUpdate() {
		distance += 1.0f;
	}

	public void Play(){
		Application.LoadLevel ("Level1"); // Application.LoadLevel obsolete, use SceneManager.load level????
	}
	public void Pause () {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} 
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}

	
	}

	public void gameOverActivated ()
	{
		endDistance = distance;
		endBubblesHitCount = player.bubblesHitCount;
		endMineHitCount = player.mineHitCount;
		endScore = endDistance + endBubblesHitCount - endMineHitCount;

		//text that will be for total score at end
		scoreText.text = "You Drowned \nDistance: " + endDistance + "\nBubbles hit: " + endBubblesHitCount + "\nMines hit: " + endMineHitCount + "\nScore: " + endScore;

		foreach (Button button in buttons) 
		{
			button.gameObject.SetActive (true);
		} 
	}

	public void Menu() 
	{
		Application.LoadLevel ("menuScene");
	}
}
