using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public CircleCollider2D aggroCollider;
	public float aggroRange;
	public Vision vision;
	//public Text text;

	private Move move;
	private Vector3 aiMovement;

	// Use this for initialization
	void Start () {
		aggroCollider.radius = aggroRange;
		vision = gameObject.GetComponent<Vision> ();
		move = GetComponent<Move> ();
	//	text.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
	//	RestartCheck();

		if (GameManager.instance.gameState == "Game") 
		{
			if (vision.canSee (GameManager.instance.player.gameObject)) 
			{
				GameManager.instance.ChangeAIState ("Found");
			}

			if (GameManager.instance.aiState == "Search") 
			{
		//		text.text = "";
			//	Movement ("up");
			}

			if (GameManager.instance.aiState == "Found")
			{
		//		text.text = "!!";
				aiMovement = GameManager.instance.player.transform.position - transform.position;
				aiMovement.Normalize ();
				transform.right = aiMovement;
				transform.position += aiMovement * Time.deltaTime * move.kineticForce;
			}

		}
			
		if (GameManager.instance.gameState == "Start") 
		{
			GameManager.instance.ChangeAIState ("Search");
		}
			
	}


	public void OnTriggerEnter2D(Collider2D collision)
	{
		Sound other = collision.GetComponent<Sound> ();
		if (other == null) 
		{

		} 
		else if (collision == other.volume) 
		{
			GameManager.instance.ChangeAIState("");
		}
	


	}

	public void OnTCollisionEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals ("Player")) 
		{

			GameManager.instance.ChangeState ("GameOver");

		}





	}
}
