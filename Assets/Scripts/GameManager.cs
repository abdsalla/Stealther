using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public string gameState = "Start";
	public string aiState = "Patrol";

	public Camera mainCamera;

	public Player player;
	public Player playerPrefab;
	public Enemy enemy;
	public List<GameObject> enemySpawn;
	public GameObject playerSpawn;
	public GameObject game;
	public GameObject characters;
	public GameObject startScreen;
	public GameObject gameOverScreen;
	public GameObject gameVictoryScreen;
	public GameObject exit;

	//public Button startButton;
	//public Button exitButton;



	void Awake() 
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		gameState = "Start";
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState == "Start") 
		{
			AStart ();
		}
		if (gameState == "Game") 
		{
			AGame ();
		}
		if (gameState == "GameOver") 
		{
			AGameOver ();
		}
		if (gameState == "Pause") 
		{
			APause ();
		}
		if (gameState == "Win") 
		{
			AWin ();
		}
	}



	public void AStart()
	{

	}

	public void AGame()
	{

	}

	public void AGameOver()
	{

	}

	public void APause()
	{

	}

	public void AWin()
	{

	}
		


	//FSM
	public void ChangeState(string newState)
	{
		gameState = newState;
	}

	public void ChangeAIState(string newState)
	{
		aiState = newState;
	}
}
