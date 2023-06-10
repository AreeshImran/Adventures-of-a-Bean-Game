using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            attackEnemy();
        }
    }

    public void attackEnemy(){
        animator.SetTrigger("weapAttack");
    }

    void OnTriggerEnter(Collider enemy){
        if (enemy.tag == "Evil"){
            enemy.GetComponent<enemyChar>().damageTaken(5);
        }
    }

}
