using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rscript : MonoBehaviour
{
	public Slider slider;
	private Text sliderValue;
	public GameObject go;
	Copy copy;
	int N;
	int Rpercent;

	void Start()
	{
		copy = go.GetComponent<Copy>();
		N = (int)copy.numberOfFriends*2 +2;
		
	}
	
	void Update ()
	{
		sliderValue = GetComponent<Text>();
		ShowSliderValue();	
	}

	//Shoes value of R as a percent of N in UI
	public void ShowSliderValue () 
	{
		Rpercent = (int)((slider.value/slider.maxValue) * 100);    
		string sliderMessage = Rpercent.ToString() + "%";
		sliderValue.text = sliderMessage;
	}
}