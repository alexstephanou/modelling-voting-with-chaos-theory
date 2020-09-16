using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedStart : MonoBehaviour
{
    private Text val;
    public GameObject go;
    Count count;
    public int redStart;


    void Start()
    {
        count = go.GetComponent<Count>();
    }

    //Gets inital value of red votes
    void Update()
    {
        val = GetComponent<Text>();
        redStart = count.redStart;
        ShowValue();
    }

    //prints value to UI
    public void ShowValue() 
    {
        string Message = (redStart).ToString() + " people";
        val.text = Message;
    }
}
