using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScript : MonoBehaviour
{
	private Text time;
	Count count;
	public double timeLeft;
	public double timeLeft1;
	public GameObject go;

	void Start()
	{
		count = go.GetComponent<Count>();
		timeLeft = count.electionTime/3;
	}

	//Counts down from the election time to 0
	void Update ()
	{
		double dt = Math.Round(Time.deltaTime, 2);
		if(timeLeft > 0)
		{
			timeLeft -= Time.deltaTime/3;
		}

		time = GetComponent<Text>();
		ShowTime();
	}

	//Shows countdown in UI
	public void ShowTime () {
		
		timeLeft1 = Math.Round(timeLeft, 1);
		string Message = "Time Until Election: " + ((timeLeft1)).ToString() + " days";
		time.text = Message;
	}
}