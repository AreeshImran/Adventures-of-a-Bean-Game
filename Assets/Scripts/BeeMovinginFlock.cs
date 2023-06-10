using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovinginFlock : MonoBehaviour
{
    public float speed = 0.5f;
    float rotateSpeed= 4.0f;
    Vector3 averageDir;
    Vector3 averagePos;
    float distanceFromBee = 10.0f;

    bool turning = false;
    
    void Start()
    {
        speed = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Vector3.zero) >= BeeFlock.flockSize){
            turning = true;
        }
        else{
            turning = false;
        }
        if(turning){
            Vector3 dir = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),
            rotateSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        else{
            if(Random.Range(0,5) < 1){
                FlockBee();
            }
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void FlockBee(){
        GameObject[] bos;
        bos = BeeFlock.allBees;

        Vector3 centre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float bSpeed = 0.1f;

        Vector3 goalPos = BeeFlock.goalPos;

        float distance;

        int flockSize = 0;
        foreach (GameObject bo in bos){
            if(bo != this.gameObject){
                distance = Vector3.Distance(bo.transform.position,this.transform.position);
                if(distance <= distanceFromBee){
                    centre += bo.transform.position;
                    flockSize++;

                    if (distance < 1.0f){
                        vavoid = vavoid + (this.transform.position - bo.transform.position);
                    }

                    BeeMovinginFlock anotherFlock = bo.GetComponent<BeeMovinginFlock>();
                    bSpeed = bSpeed + anotherFlock.speed;
                }
            }
        }

        if(flockSize > 0){
            centre = centre/flockSize + (goalPos - this.transform.position);
            speed = bSpeed/flockSize;

            Vector3 direction = (centre + vavoid) - transform.position;
            if(direction != Vector3.zero){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                rotateSpeed * Time.deltaTime);
            }
        }
    }
}
