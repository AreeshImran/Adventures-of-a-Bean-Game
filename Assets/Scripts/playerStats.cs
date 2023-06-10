using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public float currentHealth;
    public bool playerKilled;
    public float maxHealth;
    public GameObject Player;
    public GameObject DyingScreen;
    public playerHealthBar hb;


    void Start(){
        currentHealth = maxHealth;
        hb.playerMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount){
        Debug.Log("Player has taken " + amount + " damage");
        currentHealth -= amount;
        hb.updateHealthBar(currentHealth);
        if (currentHealth <= 0){
            Die();
            playerKilled = true;
        }

    }

    void Die(){
        Debug.Log("Player dead");
        Player.SetActive(false);
        DyingScreen.SetActive(true);     
    }
}
