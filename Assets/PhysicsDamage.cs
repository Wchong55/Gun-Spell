using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    [SerializeField] private GameObject spawner;
    private EnemySpawner spawnerScript;
    [SerializeField] private float selfDestructTimer, destructTime;

    private Rigidbody rigidBody;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Enemy Spawner");
        spawnerScript = spawner.GetComponent<EnemySpawner>();
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        rigidBody.AddForce(projectile.transform.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Projectile")
            Destroy(gameObject);
            
    }
}
