using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonProjectice : MonoBehaviour
{
    public Rigidbody rb;
    public float projectileForce = 50f;
    private float destroyTime = 5f;
    private int damage = 5;
    public GameObject Player;

    void Start(){
        rb.velocity = transform.forward*projectileForce;
    }

    void Update(){
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Player"){
            playerStats H = other.transform.GetComponent<playerStats>();
            H.TakeDamage(damage);
        }
        
    }
}
