using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Apple : Items
{

    playerInventory inventory;

   [SerializeField]
   public GameObject player;

    public override void interactionPoint()
    {
        inventory = player.GetComponent<playerInventory>();

        if (inventory != null){
            inventory.collectedApples();
        }
        gameObject.SetActive(false);
        Debug.Log("Picked up apple"); 
    }

}
