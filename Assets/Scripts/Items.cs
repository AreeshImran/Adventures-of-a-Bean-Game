using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Items : MonoBehaviour
{
    [HideInInspector]
    
    public NavMeshAgent playernavMeshAgent;

    private bool interactionDone;

    bool tagEnemy;

    public virtual void itemInteract(NavMeshAgent playernavMeshAgent)
    {

        tagEnemy = gameObject.tag == "Evil";

        interactionDone = false;

        this.playernavMeshAgent = playernavMeshAgent;

        playernavMeshAgent.stoppingDistance = 3f;

        playernavMeshAgent.destination = this.transform.position;

    }

    void Update(){
        if (!interactionDone && playernavMeshAgent != null && !playernavMeshAgent.pathPending){
            if (playernavMeshAgent.stoppingDistance >= playernavMeshAgent.remainingDistance){

                if (!tagEnemy){
                    interactionPoint();
                }
                lookatEnemy();
                interactionDone = true;
            }
        }
    }

    void lookatEnemy(){
        playernavMeshAgent.updateRotation = false;
        Vector3 lookEnemy = new Vector3(transform.position.x, playernavMeshAgent.transform.position.y, transform.position.z);
        playernavMeshAgent.transform.LookAt(lookEnemy);
        playernavMeshAgent.updateRotation = true;
    }

    public virtual void interactionPoint()
    {
        Debug.Log("Interacting with item");
    }

}
