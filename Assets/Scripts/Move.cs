using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float kineticForce;
	public float kineticTurnForce;
  //  public Transform trans;
	//public Rigidbody2D tRB;
	// Use this for initialization
	void Start () {
        //tRB = GetComponent<Rigidbody2D> ();
       // trans = GetComponent<Transform>();
	}
		

	public void Movement(Dir direction)
	{
		if (direction == Dir.UP)
		{
            transform.position += transform.right * kineticForce * Time.deltaTime;
          //  transform.position += Vector3.up * kineticForce * Time.deltaTime;
			//tRB.AddForce (transform.up * Time.deltaTime * kineticForce, ForceMode2D.Force);
		}
		if (direction == Dir.DOWN)
		{
            transform.position -= transform.right * kineticForce * Time.deltaTime;
          //  transform.position -= Vector3.up * kineticForce * Time.deltaTime;
            //tRB.AddForce (-transform.up * Time.deltaTime * kineticForce, ForceMode2D.Force);
        }
		if (direction == Dir.RIGHT)
		{
			transform.Rotate(-Vector3.forward * Time.deltaTime * kineticTurnForce);
			//  tRB.AddForce (transform.Rotate(Vector3.forward * Time.deltaTime * -kineticTurnForce));
		}
		if (direction == Dir.LEFT)
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * kineticTurnForce);
			//	tRB.AddForce (transform.Rotate(-Vector3.forward * Time.deltaTime * -kineticTurnForce));
		}
	}


	public void RestartCheck()
	{
		//if (GameManager.instance.gameState == "Start") 
		if (GameManager.instance.gameState == GameState.START)
            {
			Destroy (gameObject);
		}
	}
}

public enum Dir
{
    UP,
    DOWN,
    RIGHT,
    LEFT
}
