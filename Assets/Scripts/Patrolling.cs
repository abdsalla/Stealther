using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour {

    // Use this for initialization
    public TextMesh textMesh;
    private Vision vision;

    void Start()
    {
        vision = gameObject.GetComponent<Vision>();
        textMesh = GetComponent(typeof(TextMesh)) as TextMesh;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag.Equals("Player") && !collision.isTrigger && vision.canSee(collidedObject))
        {
            Debug.Log("In View");
            transform.right = collidedObject.transform.position - transform.position;
            GameManager.instance.ChangeAIState(AiState.FOUND);
            textMesh.text = "Hello Transform";
        }

    }
}