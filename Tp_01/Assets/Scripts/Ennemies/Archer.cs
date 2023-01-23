using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    private int maxhealth = 5;
    private float cooldown = 5f;
    private float speed = 8f;
    //private int damage = 3;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject arrowStart;
    [SerializeField] private HealthBar healthbar;
    private bool isAlive = true;
    private bool canShoot = true;
    private bool timeToShoot = true;
    private float timer = 0f;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
        health = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
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
            //envoie un rayon en direction du joueur
            RaycastHit hit;
            //si le truc touché est le joueur ou un ennemi: mettre canShoot true
            if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward), out hit, 40))
            {
                if (hit.collider.tag == "Player" || hit.collider.tag == "Ennemy")
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
            //Debug.Log("I can shoot");
            timeToShoot = true;
            timer = 0f;
        }

        if (canShoot)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 20f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
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

            if (Vector3.Distance(transform.position, player.transform.position) < 20.1f && canShoot && timeToShoot)
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


        /*
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("DamageTaken", true);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }*/
    }

    public void Shoot()
    {
        // nombre aléatoire de flèches entre 1 et 5

        // faire spawn une fléche avec une vitesse vers le joueur
        GameObject shot = Instantiate(arrow, arrowStart.transform.position, new Quaternion(0,-90,0,0));
        shot.transform.LookAt(new Vector3(player.transform.position.x, shot.transform.position.y,player.transform.position.z));
        shot.transform.Rotate(new Vector3(90,0,0));
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.velocity = shot.transform.up * 20f;
        //Debug.Log("Shoot");

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
            healthbar.SetHealth(health);
        }
    }
}
