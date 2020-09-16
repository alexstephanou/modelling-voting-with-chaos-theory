using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public float numberOfFriends;
    public GameObject player;
    public GameObject canvas;
    
    // Start is called before the first frame update
    //Copies the players so that there are the chosen number of people in the simulation
    void Start()
    {
        for (int i = 0; i < (int)numberOfFriends; i++)
        {
            Instantiate(player, new Vector3(Random.Range(0,300), 3, Random.Range(0,300)), Quaternion.identity);
        }
        
    }

    //Function for UI slider
    public void AdjustFriends(float amountOfFriends)
    {
        numberOfFriends = amountOfFriends;
    }
}
