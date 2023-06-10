using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class football : MonoBehaviour
{
    public Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision){
        rb.AddForce(transform.up * 250);
    }


}