using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	//serialize field makes variables visible in inspector
	private float fillAmount;

	[SerializeField]
	private Image content;

	// property of max value of bar
	public float MaxValue 
	{
		get;
		set;
	}

	//this property will be accessed (set) by the stat script, it doesn't need a get, only a set
	public float Value 
	{
		set
		{
			fillAmount = Map (value, 0, MaxValue, 0, 1);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar();
	}

	private void HandleBar() 
	{
		//only update image fillamount if fillamount is different (ie if Value has been set)
		if (fillAmount != content.fillAmount) 
		{
			//content is of type Image so fillAmount means Fill Amount in the inspector
			content.fillAmount = fillAmount;
		}

	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) 
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

	}
}
