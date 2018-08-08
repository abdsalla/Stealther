using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {
    
    public CircleCollider2D aggroCollider;
    public float aggroRange;

    private void Start()
    {
        aggroCollider = this.gameObject.GetComponent<CircleCollider2D>();
        aggroCollider.radius = aggroRange;
    }

    public float sightCone; 
	public bool canSee(GameObject target)
	{
		Transform targetTrans = target.GetComponent<Transform> ();
		Vector3 targetPosition = targetTrans.position;
		Vector3 playerToTarget = targetPosition - transform.position;
		float faceAngle = Vector3.Angle (playerToTarget, transform.right);
        bool enemyFound = false;

		if (faceAngle < sightCone) 
		{
            //Debug.Log("ye bby");
            RaycastHit2D[] hitObjects = new RaycastHit2D[2];
            GetComponent<Collider2D>().Raycast(playerToTarget, hitObjects, 100);
            
            foreach (RaycastHit2D e in hitObjects)
            {
                //Debug.Log(e.collider.gameObject.tag);
                if (e.collider.gameObject == target)
                {
                    enemyFound = true;
                }
            }
		}
		return enemyFound;
	}
}