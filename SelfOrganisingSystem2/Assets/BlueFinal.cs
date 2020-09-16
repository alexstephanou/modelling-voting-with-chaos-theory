using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueFinal : MonoBehaviour
{
    private Text val;
    public GameObject go;
    Count count;
    public int blueEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        count = go.GetComponent<Count>();
    }

    // Update is called once per frame
    void Update()
    {
        val = GetComponent<Text>();
        blueEnd = count.blueCounter;
        ShowValue();
    }


    //Shows the final blue count of votes
    public void ShowValue() 
    {
        string Message = (blueEnd).ToString() + " people";
        val.text = Message;
    }

}
