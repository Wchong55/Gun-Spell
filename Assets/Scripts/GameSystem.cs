using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    //Conditions to lose
    public float timer = 0.0f;

    //Access script
    public GameObject target;
    public Nexus nexus;

    public GameObject screen;

    void Update()
    {
        //Timer
        timer += Time.deltaTime;
    }

    public void GameOver()
    {
        screen.GetComponent<Canvas>().enabled = true;
    }
}
