using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nscript : MonoBehaviour
{
	public Slider slider;
	private Text sliderValue;

  	void Update ()
  	{
   		sliderValue = GetComponent<Text>();
    	ShowSliderValue();
  	}

	public void ShowSliderValue () 
	{
    	int val = (int)(slider.value *2 +2);
    	string sliderMessage = val.ToString();
    	sliderValue.text = sliderMessage;
  	}
}