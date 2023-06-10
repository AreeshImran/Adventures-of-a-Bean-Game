using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class portal : Items
{

    public GameObject Win;

    public override void interactionPoint(){

        Win.SetActive(true);

        Debug.Log("You win!");
        
    }
}
