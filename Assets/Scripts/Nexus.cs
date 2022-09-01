using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{
    public int maxHealth = 50;
    public int currHealth;

    public healthBar hpBar;

    public AudioSource hit1;
    public AudioSource hit2;

    public GameObject system;
    public GameSystem gs;

    void Awake()
    {
        currHealth = maxHealth;
        hpBar.setMaxHealth(maxHealth);

        gs = system.GetComponent<GameSystem>();
    }

    void Update()
    {
        currHealth = currHealth;
        hpBar.setHealth(currHealth);

        if (currHealth == 0)    //If nexus dies, call gamesystem
            gs.GameOver();

    }

    public void TakeDamage(int damage)
    {
        int num = Random.Range(0, 2);
        if (num == 0) hit1.Play();
        if (num == 1) hit2.Play();

        currHealth -= damage;
        hpBar.setHealth(currHealth);
    }

}
