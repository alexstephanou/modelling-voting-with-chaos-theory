using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Graph : MonoBehaviour
{
    [SerializeField] public Sprite circleSprite;
    private RectTransform graphContainer;
    public int blue;
    public int red;
    public List<int> list = new List<int>(); 
    public int listVal;
    Count count;
    public GameObject gameo;

    //Finds the graph and calls Get function every second
    void Start()
    {
        graphContainer = GameObject.Find("graphContainer").GetComponent<RectTransform>();
        count = gameo.GetComponent<Count>();
        
        InvokeRepeating("Get", 1, 1);

    }

    //Counts the number of blue and red votes in the simulation and puts the total vote (blue-red) into a list, then plots the list value
    void Get()
    {

        blue = 0;
        red = 0;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        gos = gos.Concat(GameObject.FindGameObjectsWithTag("Friend")).ToArray();
        
        foreach(GameObject go in gos)
        {
            if(go.GetComponent<Renderer>().material.color == Color.blue)
            {
                blue++; //positive
            }

            if(go.GetComponent<Renderer>().material.color == Color.red)
            {
                red++; //negative
            }

        }

        listVal = blue - red;
        list.Add(listVal);
        ShowGraph(list);

    }


    //Creates the dots for the graph and sets the start position to be the middle left of the graph
    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("ButtonResetSprite", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTrasform = gameObject.GetComponent<RectTransform>();
        rectTrasform.anchoredPosition = anchoredPosition;
        rectTrasform.sizeDelta = new Vector2(5,5);
        rectTrasform.anchorMin = new Vector2(0,0.5f);
        rectTrasform.anchorMax = new Vector2(0,0.5f);
    }


    //Sets the separation between points (ie. calculates how many points there will be based on the election time and separates
    //the graph points using this information)

    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 400f;
        float xSize = (graphContainer.sizeDelta.x-20f)/count.electionTime;
        
        for(int i = 0; i<valueList.Count; i++)
        {
            float xPosition = 10f + i*xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight; 
            CreateCircle(new Vector2(xPosition, yPosition));
        }
    }


}
