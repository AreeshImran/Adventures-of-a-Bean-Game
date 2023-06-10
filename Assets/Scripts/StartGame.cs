using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject screen;

    public void CloseScreen(){
        screen.SetActive(false);
    }
}
