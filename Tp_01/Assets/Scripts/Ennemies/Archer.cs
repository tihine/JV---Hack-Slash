using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 5f;
    private float cooldown = 5f;
    private float speed = 8f;
    private float damage = 3f;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    private bool isAlive = true;
    private bool canShoot = true;
    private bool timeToShoot = false;
    private float timer = 0f;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //look at the player
        if (Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
        {
            transform.LookAt(player.transform);
            //envoie un rayon en direction du joueur
            RaycastHit hit;
            //si le truc touché est le joueur ou un ennemi: mettre canShoot true
            if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward), out hit, 40))
            {
                if (hit.collider.tag == "PlayerCollider" || hit.collider.tag == "Ennemy")
                {
                    canShoot = true;
                }
                else
                {
                    canShoot = false;
                }
            }
        }

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            Debug.Log("I can shoot");
            timeToShoot = true;
            timer = 0f;
        }

        if (canShoot)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 10f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
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

            if (Vector3.Distance(transform.position, player.transform.position) < 11f && canShoot && timeToShoot)
            {
                animator.SetBool("isPunching", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdling", false);
                timeToShoot = false;

            }
        }
        else
        {
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

            if (Vector3.Distance(transform.position, player.transform.position) < 4f && canShoot && timeToShoot)
            {
                animator.SetBool("isPunching", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdling", false);
                timeToShoot = false;

            }
        }



        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("DamageTaken", true);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }
    }

    public void Shoot()
    {
        // nombre aléatoire de flèches entre 1 et 5
        // faire spawn une fléche avec une vitesse vers le joueur
        Debug.Log("Shoot");

    }
}
