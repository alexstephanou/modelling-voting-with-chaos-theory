using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public GameObject gameOverCanvas;
	public GameObject gameStartCanvas;
	public GameObject gameCanvas;
	public bool started;
	public GameObject go1;
	public GameObject go2;
	public GameObject goCount;
	public GameObject goMovement1;
	public GameObject goMovement2;
	Copy copy1;
	Copy copy2;
	Count count;
	Movement movement1;
	Movement movement2;

	
	//Is called before any Start function, disables those scripts which need to wait until after the user inputs values into UI sliders
	public void Awake()
	{
		gameOverCanvas.SetActive(false);
		gameStartCanvas.SetActive(true);
		gameCanvas.SetActive(false);
		Time.timeScale = 0;
		started = false;
		copy1 = go1.GetComponent<Copy>();
		copy1.enabled = false;
		copy2 = go2.GetComponent<Copy>();
		copy2.enabled = false;
		count = goCount.GetComponent<Count>();
		count.enabled = false;
		movement1 = goMovement1.GetComponent<Movement>();
		movement1.enabled = false;
		movement2 = goMovement2.GetComponent<Movement>();
		movement2.enabled = false;
	}


	//Ends the simulation if GameOver is called
	public void GameOver()
	{
		if (gameOverCanvas != null)
		{
			gameOverCanvas.SetActive(true);
			Time.timeScale = 0;
		}
	}


	//Activates the scripts after the user has inputted start variables and starts the simulation
	public void StartSimulation()
	{
		gameStartCanvas.SetActive(false);
		gameCanvas.SetActive(true);
		Time.timeScale = 1;
		started = true;
		copy1.enabled = true;
		copy2.enabled = true;
		count.enabled = true;
		movement1.enabled = true;
		movement2.enabled = true;
	}
	
	public void Replay()
	{
		SceneManager.LoadScene(0);
	}
}