using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalInitial : MonoBehaviour
{
    private Text val;
    public GameObject goRed;
    public GameObject goBlue;
    BlueStart blueStart;
    RedStart redStart;
    public int red;
    public int blue;
    public int total;
    
    // Start is called before the first frame update
    void Start()
    {
        blueStart = goBlue.GetComponent<BlueStart>();
        redStart = goRed.GetComponent<RedStart>();

    }

    // Update is called once per frame
    void Update()
    {
        val = GetComponent<Text>();
        red =redStart.redStart;
        blue=blueStart.blueStart;
        ShowValue();
    }

    public void ShowValue() 
    {
        total = blue - red;
        string Message = (total).ToString() + " people";
        val.text = Message;
    }
}
