using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCube : MonoBehaviour
{
    private AudioSource hit;

    public UnityEngine.AI.NavMeshAgent _agent;

    void Awake()
    {
        hit = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Projectile")
            hit.Play();
            Destroy(this.gameObject); 
    }
}
