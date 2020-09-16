using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedFinal : MonoBehaviour
{
    private Text val;
    public GameObject go;
    Count count;
    public int redEnd;


    void Start()
    {
        count = go.GetComponent<Count>();
    }

    //gets the final value of red votes
    void Update()
    {
        val = GetComponent<Text>();
        redEnd = count.redCounter;
        ShowValue();
    }

    //prints value to UI
    public void ShowValue() 
    {
        string Message = (redEnd).ToString() + " people";
        val.text = Message;
    }
}
