using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

	public float sightCone; 
	public bool canSee(GameObject target)
	{
		Transform targetTrans = target.GetComponent<Transform> ();
		Vector3 targetPosition = targetTrans.position;
		Vector3 playerToTarget = targetPosition - transform.position;
		float faceAngle = Vector3.Angle (playerToTarget, transform.right);

		if (faceAngle < sightCone) 
		{
			RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, playerToTarget);
				
			if (hitInfo.collider.gameObject == null) {

			} else if (hitInfo.collider.gameObject == target) {
				return true;
			}
		}

		return false;
	}
}