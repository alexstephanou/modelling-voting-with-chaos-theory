using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueStart : MonoBehaviour
{
    private Text val;
    public GameObject go;
    Count count;
    public int blueStart;
    // Start is called before the first frame update
    void Start()
    {
        count = go.GetComponent<Count>();
        

    }

    // Update is called once per frame
    void Update()
    {
        val = GetComponent<Text>();
        blueStart = count.blueStart;
        ShowValue();
    }

    public void ShowValue() {
    
    string Message = (blueStart).ToString() + " people";
    val.text = Message;
  }
}
