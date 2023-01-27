﻿using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;
using UnityEngine.AI;

public class Minotaur : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxhealth = 20;
    private int health;
    //private float countdown = 1f;
    private float speed = 3f;
    private int damage = 10;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    [SerializeField] GameObject sphere;
    [SerializeField] private HealthBar healthbar;
    private bool isAlive = true;
    private float deathTime = 2f;
    
    //For Ninja smokescreen functions:
    private NinjaManager ninjaMgr;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
        health = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        
        //For Ninja smokescreen functions:
        if (player.name == "Ninja")
        {
            ninjaMgr = player.GetComponent<NinjaManager>();
            ninjaMgr.OnStartInvisibility.AddListener(StartNinjaInvisibility);
            ninjaMgr.OnEndInvisibility.AddListener(EndNinjaInvisibility);
        }
    }

    void Update()
    {
        
        //look at the player
        if (Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
        {
            transform.LookAt(player.transform);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 2f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
        {
             navMeshAgent.isStopped = false;
             navMeshAgent.SetDestination(player.transform.position);
             animator.SetBool("isIdling", false);
            animator.SetBool("isPunching", false);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isPunching", false);
            animator.SetBool("isIdling", true);
            navMeshAgent.isStopped = true;

        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("DamageTaken", true);
        }
        */
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            animator.SetBool("isPunching", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", false);
        }
        /*
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }*/
        if (!isAlive)
        {
            deathTime -= Time.time;
            animator.SetBool("isDead", true);
            if (deathTime < 0)
            {
                Destroy(gameObject);
            }
            //fais disparaitre l'ennemi
            //détruit l'ennemi
        }
    }

    public void CheckDamageEvent()
    {
        //mettre une overlapsed sphere
        Collider[] hitColliders = Physics.OverlapSphere(sphere.transform.position, 2.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                //Debug.Log("BAM mino");
                //hitCollider.SendMessage("AddDamage", damage);
            }
            

        }

    }
    public void AddDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
        animator.SetBool("DamageTaken", true);
        if (health <= 0)
        {
            isAlive = false;
        }
    }
    public void AddLife(int life)
    {
        if (health < maxhealth && isAlive)
        {
            health += life;
            healthbar.SetMaxHealth(health);
        }
    }
    
    //To make Ninja visible or invisible by enabling/disabling NavMeshAgent – enemies will not move when Ninja is invisible:
    private void StartNinjaInvisibility()
    {
        navMeshAgent.enabled = false;
    }
    
    private void EndNinjaInvisibility()
    {
        navMeshAgent.enabled = true;
    }
}

