using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    private GameObject player;
    private MageManager mageManager;
    private Animator animator;
    
    private Rigidbody rb;
    private int hitCounter;
    private int maxHits = 5;
    private float lifespan = 5f;
    private bool orbiting;
    private bool deactivated;
    private float angularVel = 1000f;
    private float orbitRadius;
    private int orbDamage = 5;
    
    /* May be useful for upgrades
    private SphereCollider sphColl;
    private bool exploded;
    private bool explosionVisualDone;
    private float explosionRadius = 15f;
    */

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageManager = player.GetComponent<MageManager>();
        animator = player.GetComponent<Animator>();
        orbitRadius = Vector3.Distance(player.transform.position, transform.position);
        
        rb = GetComponent<Rigidbody>();
        //sphColl = GetComponent<SphereCollider>();
        //Physics.IgnoreCollision(player.GetComponent<Collider>(),sphColl);
        StartCoroutine(DestructionTimer());
        StartOrbit();
    }

    // Update is called once per frame
    void Update()
    {
        if (orbiting)
        {
            transform.RotateAround(player.transform.position, Vector3.up, angularVel * Time.deltaTime);
            Vector3 towardsPlayer = player.transform.position - transform.position;
            if (towardsPlayer.magnitude > orbitRadius)
            {
                transform.position += towardsPlayer.normalized * 0.1f;
            }
            if (towardsPlayer.magnitude < orbitRadius)
            {
                transform.position -= towardsPlayer.normalized * 0.1f;
            }
        }
        //Remove orb from arena after maxHits hits or lifespan seconds:
        if (hitCounter >= maxHits || deactivated)
        {
            Destroy(gameObject);
        }
    }

    void StartOrbit()
    {
        transform.parent = null;
        orbiting = true;
        animator.SetBool("Orb", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hitCounter >= maxHits) return;
        if (other.CompareTag("Ennemy"))
        {
            hitCounter++;
            other.SendMessage("AddDamage", orbDamage);
        }
    }

    //TODO Code for repulsion upgrade (isTrigger = false)
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") || collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided");

            //Blast damage:
            Collider[] blastedEntities = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider blasted in blastedEntities)
            {
                if (blasted.CompareTag("Ennemy"))
                {
                    blasted.SendMessage("AddDamage", 5);
                }
            }
            
            //Knockback via physics engine:
            float radius = sphColl.radius;
            int counter = 1;
            while (radius < explosionRadius)
            {
                radius = counter * explosionRadius / 5f;
                counter++;
                sphColl.radius = radius;
            }
        }
    }
    */

    private IEnumerator DestructionTimer()
    {
        yield return new WaitForSeconds(lifespan);
        deactivated = true;
    }
}
