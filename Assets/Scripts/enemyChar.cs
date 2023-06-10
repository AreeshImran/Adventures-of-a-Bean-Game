using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyChar : Items
{
    public LayerMask playerLayerMask;
    private NavMeshAgent enemyNav;
    private Collider[] withinPlayerCollider;
    public playerStats player;
    public playerHealthBar hb;
    public float currentHealth;
    public bool enemyKilled;
    public float maxHealth;
    public Transform[] projectileSpawnPoint;
    public GameObject projectileItem;
    private float countBeforeProjectile = 0f;
    public float fireTime = 2f;



    void Start(){
        enemyNav = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        hb.playerMaxHealth(maxHealth);
    }

    void FixedUpdate(){
        withinPlayerCollider = Physics.OverlapSphere(transform.position, 10, playerLayerMask);
        if (withinPlayerCollider.Length > 0){
            ChasePlayer(withinPlayerCollider[0].GetComponent<playerStats>());
        }
    }

    public void PerformAttack(){
        if (countBeforeProjectile <= 0){
            foreach (Transform SpawnPoints in projectileSpawnPoint){
            Instantiate(projectileItem, SpawnPoints.position, transform.rotation);
            }

            countBeforeProjectile = 1f/fireTime;
        }

        countBeforeProjectile -= Time.deltaTime;
        
    }


    public void damageTaken(int amount){

        currentHealth -= amount;
        hb.updateHealthBar(currentHealth);
        if (currentHealth <= 0){
            Die();
            enemyKilled = true;
        }

    }

    void ChasePlayer(playerStats player){
        enemyNav.SetDestination(player.transform.position);
        this.player = player;
        if (enemyNav.remainingDistance <= enemyNav.stoppingDistance){
            PerformAttack();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    public override void interactionPoint(){
        Debug.Log("Attacking");

    }

}
