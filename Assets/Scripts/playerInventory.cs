using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour
{
    public int appleCollection { get; set; }
    public UnityEvent<playerInventory> OnAppleCollected;
    
    public void collectedApples(){
        appleCollection++;

        OnAppleCollected.Invoke(this);
    }
}
