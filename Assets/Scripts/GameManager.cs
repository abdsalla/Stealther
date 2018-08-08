using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
    
    public GameState gameState;
    public AiState aiState = AiState.PATROL;

	public Camera mainCamera;

	public Player player;
	public GameObject playerPrefab;
	public Enemy enemy;
	public List<GameObject> enemySpawn;
	public GameObject playerSpawn;
	public GameObject game;
	public GameObject characters;
	public GameObject startScreen;
	public GameObject gameOverScreen;
	public GameObject gameVictoryScreen;
    public int enemyCount = 0;
    public GameObject activePlayer;
	//public GameObject exit;

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
        gameState = GameState.GAME;
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.START:
                AStart();
                break;
            case GameState.GAME:
                AGame();
                break;
            case GameState.GAMEOVER:
                AGameOver();
                break;
            case GameState.PAUSE:
                //	APause ();
                break;
            case GameState.WIN:
                AWin();
                break;
            default:
                //Debug.Log("Why is the " + gameState +" GameState not defined?");
                break;
        }
        SpawnPlayer();
	}

	public void AStart()
	{
        if(!startScreen.activeSelf)
        {
            characters.SetActive(false);
            startScreen.SetActive(true);
            game.SetActive(false);
            gameOverScreen.SetActive(false);
            //exit.SetActive(false);
            gameVictoryScreen.SetActive(false);
        }
	}

	public void AGame()
	{
        if (game.activeSelf)
        {
            game.SetActive(true);
            characters.SetActive(true);
            startScreen.SetActive(false);
            gameOverScreen.SetActive(false);
            gameVictoryScreen.SetActive(false);
            //exit.SetActive(false);

            if (enemyCount < 4)
            {
                //Debug.Log("Making Enemies");
                int i = 0;
                foreach (GameObject o in enemySpawn)
                {
                    Instantiate(enemy, enemySpawn[i++].transform.position, GetComponent<Transform>().rotation, characters.transform);
                }
            }
            aiState = AiState.SEARCH;
        }

    }


    public void SpawnPlayer()
    {
        if (activePlayer == null)
        {
            activePlayer = Instantiate(playerPrefab, playerSpawn.transform.position, GetComponent<Transform>().rotation, characters.transform) as GameObject;
        }
    }



	public void AGameOver()
	{
        if (!gameOverScreen.activeSelf)
        {
            gameOverScreen.SetActive(true);
            game.SetActive(false);
            startScreen.SetActive(false);
            //exit.SetActive(false);
            gameVictoryScreen.SetActive(false);
            characters.SetActive(false);
        }
    }

	/*public void APause()
	{
        if ((!exit.activeSelf))
        {
            exit.SetActive(true);
            characters.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exit.SetActive(false); 
            characters.SetActive(true);
            ChangeState("Game");
        }
	}*/

	public void AWin()
	{
        if (!gameVictoryScreen.activeSelf)
        {
            gameVictoryScreen.SetActive(true);
            gameOverScreen.SetActive(false);
            game.SetActive(false);
            startScreen.SetActive(false);
          //  exit.SetActive(false);
            characters.SetActive(false);
        }
	}

	//FSM
	public void ChangeState(GameState newState)
	{
        gameState = newState;
	}

	public void ChangeAIState(AiState newState)
	{
		aiState = newState;
	}
}

public enum GameState
{
    START,
    GAME,
    GAMEOVER,
    PAUSE,
    WIN
}

public enum AiState
{
    PATROL,
    SEARCH,
    FOUND
}