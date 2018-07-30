using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour {

	public float enemyRotation;
	// Use this for initialization

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals ("Enemy") && !collision.isTrigger)
		{
			collision.gameObject.GetComponent<Enemy> ().transform.Rotate (0, 0, enemyRotation);
		}
	}
}