using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent playernavMeshAgent;
    

    // Start is called before the first frame update
    void Start()
    {
        playernavMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        PlayerInteraction();
        
    }

    void PlayerInteraction()
    {
        Ray interactRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionDetails;
        if (Physics.Raycast(interactRay, out interactionDetails, Mathf.Infinity))
        {
            playernavMeshAgent.updateRotation = true;
            GameObject objectInteracted = interactionDetails.collider.gameObject;
            if (objectInteracted.tag == "Evil"){
                Debug.Log("Enemy Detected");
                objectInteracted.GetComponent<Items>().itemInteract(playernavMeshAgent);
            }
            else if(objectInteracted.tag == "Interactable")
            {
                objectInteracted.GetComponent<Items>().itemInteract(playernavMeshAgent);
            }
            else
            {
                playernavMeshAgent.stoppingDistance = 0;
                playernavMeshAgent.destination = interactionDetails.point;
            }

        }
    }


}
