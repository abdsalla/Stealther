using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Move move;

	// Use this for initialization
	void Start () {
		GameManager.instance.player = this;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("up") || Input.GetKey ("w"))
			{
			move.gameObject.GetComponent<Move>().Movement("up");
			}

		if (Input.GetKey ("down") || Input.GetKey ("s"))
			{
			move.gameObject.GetComponent<Move>().Movement("down");
			}

		if (Input.GetKey ("left") || Input.GetKey ("a"))
			{
			move.gameObject.GetComponent<Move>().Movement("left");
			}

		if (Input.GetKey ("right") || Input.GetKey ("d"))
			{
			move.gameObject.GetComponent<Move>().Movement("right");
			}



		if (Input.GetKeyDown (KeyCode.Space) && GameManager.instance.gameState == "Game")
		{
			GameManager.instance.ChangeState ("Pause");
		}

		GameManager.instance.mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.mainCamera.transform.position.z);
		//	RestartCheck();

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals ("Goal")) 
		{
			GameManager.instance.ChangeState ("Win");
		}
	}
}