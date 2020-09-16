using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float timer;
    public int newTargetTime;
    public float speed;
    public UnityEngine.AI.NavMeshAgent nav;
    //public Vector3 Target;
    public string character;
    public GameObject player;
    public GameObject otherPlayer;
    public bool isCollision = false;
    public Vector3 randomTarget; 
    public bool hitting;
    public int sphereDistance;
    public float separation;
    public bool opinionChanged;
    public string playerName;
    public int threshold;
    public int otherthreshold;
    public bool neverDone;
    public GameObject gmObject;

    
    // Start is called before the first frame update, after Awake
    //Sets up the speed that the people walk at and gives everyone a random initial threshold (opinion) =! 0
    void Start()
    {
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.speed = speed; 
        threshold = Random.Range(-10, 10);
        
        if(threshold == 0)
        {
            threshold = Random.Range(-10,10);
        }
        
        neverDone = true;
        hitting = false;
        opinionChanged = false;
        randomTarget = new Vector3(Random.Range(0, 300), 3, Random.Range(0, 300));
    }

    // Update is called once per frame
    void Update()
    {   

        GameManager gm = gmObject.GetComponent<GameManager>();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gm.GameOver();
            Time.timeScale = 0;
        }
        
        //updates the colours of the players based on their opinions as they fluctuate: blue for positive, red for negative
        var playerRenderer = player.GetComponent<Renderer>(); 

        if(threshold == 0)
        {
            threshold = Random.Range(-10,10);
        }

        if(threshold < 0)
        {
            playerRenderer.material.SetColor("_Color", Color.red);
        }
        if(threshold > 0)
        {
            playerRenderer.material.SetColor("_Color", Color.blue);
        }    

    
        //Makes friends move towards each other if they are within a certain radius of each other (ie. they 'see' each other), otherwise 
        //people will walk in a random direction for 5 seconds before choosing a new random direction until they see a friend       
        Collider[] hits = Physics.OverlapSphere(transform.position, sphereDistance);
        foreach (Collider hit in hits)
        {
            if(hit.tag==character && isCollision == false)
            {
                hitting = true;
                float step = speed* 0.1f  * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, step);
                NewTarget(hit.transform.position);
            }

            //Sets a timer for how long each person should walk randomly for
            timer += Time.deltaTime;
            if(timer>=newTargetTime )
            {
                timer = 0;
                randomTarget = new Vector3(Random.Range(0, 300), 3, Random.Range(0, 300));   
            }

            if(hitting == false)
            {
                NewTarget(randomTarget);         
            }

            separation = Vector3.Distance(transform.position, GameObject.Find(character).GetComponent<Transform>().position);
           
        }

    }

    //Gives the players a target to move towards--either a friend if they see each other or a random position on the grid
    void NewTarget(Vector3 aTarget)
    {
        nav.SetDestination(aTarget);

    }

    //Sets the collision bool back to false when called
    private void SetBoolBack()
    {
        isCollision = false;
    }
    
    //Sets the neverDone bool back to true when called
    private void SetDoneBack()
    {
        neverDone = true;
    }

    


    //When people collide, this function is automatically called
    //If the people have the same opinion (ie. red and red or blue and blue), each person will add their threshold onto the other
    //If they have opposing views, they will subtract from each others thresholds (ie. both thresholds will end up closer to 0 -- 'weaker')
    //If a threshold passes 0, the opinion changes from red to blue or vice versa
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == character || collision.gameObject.tag == playerName)
        {
            hitting = false;
            isCollision = true;
            Invoke("SetBoolBack", 2);
            
            Movement movement = collision.gameObject.GetComponent<Movement>();                      
            otherthreshold = movement.threshold;
            
            if(neverDone == true && Mathf.Abs(threshold) < 1000)
            {
                threshold = threshold + otherthreshold;
                neverDone = false;
                Invoke("SetDoneBack", 3);
            }

            if(Mathf.Abs(threshold) > 1000)
            {
                if(threshold<0)
                {
                    threshold = -100;
                }

                if(threshold>0)
                {
                    threshold = 100;
                }
            }
            
        }
    }


}



