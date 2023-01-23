using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Liche : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 15;
    private float cooldown = 10f;
    private float speed = 2f;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    [SerializeField] ParticleSystem healthzone;
    private bool isAlive = true;
    private bool timeToShoot = true;
    private float timer = 0f;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
        healthzone.Stop();
    }

    // Update is called once per frame
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

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            //Debug.Log("I can shoot");
            timeToShoot = true;
            //timer = 0f;
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 5f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
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

        if (Vector3.Distance(transform.position, player.transform.position) < 5.2f && timeToShoot)
        {
            animator.SetBool("isPunching", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", false);
            timeToShoot = false;
            timer = 0f;

        }
    }
    public void Sort()
    {
        //Debug.Log("Sort");
        ParticleSystem sort = Instantiate(healthzone, transform);
        //sort.Play();

    }
    public void AddDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isAlive = false;
        }
    }
    public void AddLife(int life)
    {
        if (health < 10 && isAlive)
        {
            health += life;
        }
    }
}
