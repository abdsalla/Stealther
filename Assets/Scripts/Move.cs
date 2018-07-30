using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float kineticForce;
	public float kineticTurnForce;
//	public Rigidbody2D tRB;
	// Use this for initialization
	void Start () {
		//tRB = GetComponent<Rigidbody2D> ();
	}
		

	public void Movement(string direction)
	{
		if (direction == "up")
		{
			transform.position += transform.right * Time.deltaTime * kineticForce;
		//	tRB.AddForce (transform.up * Time.deltaTime * kineticForce, ForceMode2D.Force);
		}
		if (direction == "down")
		{
			transform.position -= transform.right * Time.deltaTime * kineticForce;
			//tRB.AddForce (-transform.up * Time.deltaTime * kineticForce, ForceMode2D.Force);
		}
		if (direction == "right")
		{
			transform.Rotate(-Vector3.forward * Time.deltaTime * kineticTurnForce);
			//  tRB.AddForce (transform.Rotate(Vector3.forward * Time.deltaTime * -kineticTurnForce));
		}
		if (direction == "left")
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * kineticTurnForce);
			//	tRB.AddForce (transform.Rotate(-Vector3.forward * Time.deltaTime * -kineticTurnForce));
		}
	}


	public void RestartCheck()
	{
		if (GameManager.instance.gameState == "Start") 
		{
			Destroy (gameObject);
		}
	}
}
