using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class SearchPlayer : MonoBehaviour
{
    //Enemy attributes
    public NavMeshAgent _agent;
    private int damage = 1;

    //Access other scripts
    public Nexus nexus;
    public GameObject target;

    private GameObject enemySpawner;
    private EnemySpawner spawn;

    //Audio
    private AudioSource run;

    //Animation
    public Animation anim;

    void Awake()
    {
        this.run = GetComponent<AudioSource>();

        GameObject target = GameObject.FindGameObjectWithTag("Nexus");
        nexus = target.GetComponent<Nexus>();

        enemySpawner = GameObject.FindGameObjectWithTag("Spawner");
        spawn = enemySpawner.GetComponent<EnemySpawner>();

        anim = gameObject.GetComponent<Animation>();
    }

    void Start()
    {
        this.run.Play();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Walk");
        this._agent.SetDestination(target.transform.position);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Nexus")
        {
            //other.GetComponent<Player>().TakeDamage(damage);    //Do damage to Nexus
            nexus.TakeDamage(damage);

            this.run.Stop();

            //Destroy this object instance and from the list
            spawn.enemies.Remove(gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Projectile")
        {
            this.run.Stop();

            spawn.enemies.Remove(gameObject);
            Destroy(this.gameObject);

            Destroy(other.gameObject);
        }
    }
}
