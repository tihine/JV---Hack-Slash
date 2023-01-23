using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxhealth = 10;
    private int health;
    //private float countdown = 1f;
    private float speed = 5f;
    private int damage = 5;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    [SerializeField] GameObject sphere;
    [SerializeField] private HealthBar healthbar;
    private bool isAlive = true;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
        health = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
    }

    void Update()
    {
        if (!isAlive)
        {
            animator.SetBool("isDead", true);
            //fais disparaitre l'ennemi
            //détruit l'ennemi
        }

        //look at the player
        if (Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
        {
            transform.LookAt(player.transform);
        }
        


        if (Vector3.Distance(transform.position, player.transform.position) > 3f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
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
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("DamageTaken", true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 4f)
        {
            animator.SetBool("isPunching", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", false);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }

    }

    //this method is called from the attack animation
    public void CheckDamageEvent()
    {
        //mettre une overlapsed sphere
        Collider[] hitColliders = Physics.OverlapSphere(sphere.transform.position, 2.5f );
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "PlayerCollider")
            {
                //Debug.Log("BAM chevalier");
                //hitCollider.SendMessage("AddDamage", damage);
            }
            
            
        }
        
    }
    public void AddDamage(int damage)
    {
        health -= damage;
        healthbar.SetMaxHealth(health);
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
}

