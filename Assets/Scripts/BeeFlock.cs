using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFlock : MonoBehaviour
{

    public GameObject bee;
    public GameObject beeGoal;
    public static int flockSize = 5;
    static int beeNum = 10;
    public static GameObject[] allBees = new GameObject[beeNum];
    public static Vector3 goalPos = Vector3.zero;

    void Start()
    {
        for(int i = 0; i < beeNum; i++){
            Vector3 pos = new Vector3(Random.Range(-flockSize,flockSize),
                                      Random.Range(-flockSize,flockSize),
                                      Random.Range(-flockSize,flockSize));
            allBees[i] = (GameObject) Instantiate(bee, pos, Quaternion.identity);                          
        }
        
    }

    
    void Update()
    {
        if(Random.Range(0,1000) < 50){
            goalPos = new Vector3(Random.Range(-flockSize,flockSize),
                                  Random.Range(-flockSize,flockSize),
                                  Random.Range(-flockSize,flockSize));
            beeGoal.transform.position = goalPos;
        }
        
    }
}
