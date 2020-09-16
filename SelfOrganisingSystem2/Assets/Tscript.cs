using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tscript : MonoBehaviour
{
	public Slider slider;
	private Text sliderValue;

	void Update ()
	{
		sliderValue = GetComponent<Text>();
		ShowSliderValue();
	}

	//Shows election time in UI in days
	public void ShowSliderValue () {
		int val = (int)slider.value/3;
		string sliderMessage = val.ToString();
		sliderValue.text = sliderMessage;
	}
}