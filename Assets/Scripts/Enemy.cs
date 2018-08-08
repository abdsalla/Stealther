using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
	public Vision vision;
    public float patrolDist;


    

	private Move move;
	private Vector3 aiMovement;
    //private Vector3 startLoc;

    
	void Start () {
		vision = gameObject.GetComponent<Vision> ();
		move = GetComponent<Move> ();
        GameManager.instance.enemyCount++;
        //startLoc = transform.position;
        
    }
	
	void Update ()  {
        Regulate();
        Move();
        
		//if (GameManager.instance.gameState == GameState.START)
  //      {
		//	GameManager.instance.ChangeAIState (AiState.SEARCH);
		//}
	}


    public void Regulate()
    {
        if (GameManager.instance.enemyCount >= 5)
        {
            GameManager.instance.enemyCount -= 1;
            Debug.Log("Hello master, i'm ready to serv-- OOMF");
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        if (GameManager.instance.gameState == GameState.GAME)
        {
            switch (GameManager.instance.aiState)
            {
                case AiState.SEARCH:
                    move.Movement(Dir.UP);
                    //transform.position += transform.right * move.kineticForce * Time.deltaTime;
                    break;
                case AiState.FOUND:
                    aiMovement = GameManager.instance.player.transform.position - transform.position;
                    aiMovement.Normalize();
                    transform.right = aiMovement;
                    transform.position += aiMovement * Time.deltaTime * move.kineticForce;
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Sound other = collision.GetComponent<Sound>();

        //if (collision == other.volume)
        //{
        //    GameManager.instance.ChangeAIState("Found");
        //}
        if ( collision.tag == "Boundary")
        {
            transform.Rotate(0, 0, 180);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals ("Player")) 
		{
			GameManager.instance.ChangeState (GameState.GAMEOVER);
		}
	}
}
