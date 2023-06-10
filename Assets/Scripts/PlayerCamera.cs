using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform camtarget;
    public Vector3 Offset;
    public float speed = 5.0f;


    void Update(){

        transform.position = camtarget.position + Offset;

        
    }


}
