using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider N_slider;
    public Slider R_slider;
    public Slider t_slider;
    public GameObject go;
    Copy val;

     
    //sets fixed limits on sliders for R and time
    void Start()
    {
        val = go.gameObject.GetComponent<Copy>();
        N_slider.minValue = 99;
        N_slider.maxValue = 199;

        R_slider.minValue = 0;
        

        t_slider.minValue = 9;
        t_slider.maxValue = 180;
    }

    //sets dynamic limit on R based on N
    void Update()
    {
        R_slider.maxValue = val.numberOfFriends *2 + 2;
    }
}
