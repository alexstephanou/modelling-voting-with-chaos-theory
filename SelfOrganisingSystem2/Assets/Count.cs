using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Count : MonoBehaviour
{
    public int blueCounter;
    public int redCounter;
    public int blueStart;
    public int redStart;
    public float electionTime;
    public float time;
    public GameManager gameManager;
    public List<int> myList = new List<int>();
    public float R;
    public float timer;
    public float day;
    public int currentOpinion;
    public GameObject currentGo;
    public int sizeOfList;
    public GameObject friendOrPlayer;
    public List<int> list = new List<int>();  
    Copy copy;


    void Start()
    {
        copy = friendOrPlayer.GetComponent<Copy>();
        sizeOfList = (int)copy.numberOfFriends*2 + 2;
        
        for (int n = 0; n < sizeOfList; n++)    //  Populate random list with how many players there are
        {
            list.Add(n);
        }
    }

    // Update is called once per frame
    void Update()
    {
        blueCounter = 0;
        redCounter = 0;

        //Gets all people and puts them into an array in order to count how many blue and red votes there are
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        gos = gos.Concat(GameObject.FindGameObjectsWithTag("Friend")).ToArray();
        
        foreach(GameObject go in gos)
        {
            if(go.GetComponent<Renderer>().material.color == Color.blue)
            {
                blueCounter++;
            }

            if(go.GetComponent<Renderer>().material.color == Color.red)
            {
                redCounter++;
            }
        }

        
        //Gets the inital count of votes
        if(myList.Count < 4)
        {
            myList.Add(blueCounter);
            myList.Add(redCounter);
        }

        if(myList.Count > 2)
        {
            redStart = myList[3];
            blueStart = myList[2];
        }


        //Stops the simulation if the time reaches the elction time
        time += Time.deltaTime;
        if(time >= electionTime)
        {
            gameManager.GameOver();
            Time.timeScale = 0;
        }

        timer +=Time.deltaTime;
        
        //Allows a fixed number R random people out of the whole simulation change their opinion each 'day'
        if(timer>=day)
        {
            
            for (int k=0; k<R; k++)
            {
                int index = Random.Range(0, (int)list.Count);    //  Pick random indexex 
                int i = list[index];    //  i = the number that was randomly picked
                Debug.Log(i);
                currentGo = gos[i];
                list.RemoveAt(index); // remove i from the list so you cant get the same person again in one day

                Movement movement = currentGo.gameObject.GetComponent<Movement>();
                currentOpinion = movement.threshold;
                
                movement.threshold = -currentOpinion; // Change the threshold to the opposite side
            }
            
            timer = 0;
            list.Clear();
            for (int n = 0; n < sizeOfList; n++)    //  repopulate list for the next day
            {
                list.Add(n);
            }
        }
    }


    //functions for UI sliders
    public void ChangeR(float newR)
    {
        R = newR;
    }

    public void ChangeTau(float newTau)
    {
        electionTime = newTau;
    }
}
