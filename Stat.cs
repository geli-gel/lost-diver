using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to make class serializable so viewable when serialized fields are accessed via PlayerScript
using System;

// Don't need it to be a MonoBehaviour
//to view stat in inspector when PlayerScript is applied to player
[Serializable] // the public class Stat means you can call private class Stat and it will have all these functions/properties w whatever name you give it (02, health, etc)
public class Stat
{
	//every stat should be bound to a bar, so here's bar script
	[SerializeField]
	private BarScript bar;

	[SerializeField]
	private float maxVal;

	//current value of stat
	[SerializeField]
	private float currentVal;

	//property for getters and setters of currentVal:
	public float CurrentVal
	{
		get
		{
			return currentVal;			
		}
		set
		{
			//set current value, then tell bar to update it's Value to stat's currentVal
			this.currentVal = Mathf.Clamp(value,0,MaxVal);
			bar.Value = currentVal;
		}
	}

	//property for getters and setters of maxVal:
	public float MaxVal
	{
		get
		{
			return maxVal;			
		}
		set
		{
			//you can also do it like this for same result:
			//bar.MaxValue = value;
			//this.maxVal = value;
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	//create the initialize function, which is called in Awake() (not Start()) of the PlayerScript
	//set the maxVal to something in order for barScript.Value to work
	public void Initialize()
	{
		//since maxVal is set when we set MaxVal in the inspector, we just have to call maxVal
		//so that bar.MaxValue gets set as well
		this.MaxVal = maxVal;
		//same with current value, just need to update bar
		this.CurrentVal = currentVal;

	}



}
