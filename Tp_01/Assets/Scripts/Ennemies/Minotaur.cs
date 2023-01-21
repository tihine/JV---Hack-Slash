using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minotaur : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 20f;
    private float cooldown = 1f;
    private float speed = 3f;
    private float damage = 10f;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    [SerializeField] GameObject sphere;
    private bool isAlive = true;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent.speed = speed;
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
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("DamageTaken", true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
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

    public void CheckDamageEvent()
    {
        //mettre une overlapsed sphere
        Collider[] hitColliders = Physics.OverlapSphere(sphere.transform.position, 2.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "PlayerCollider")
            {
                Debug.Log("BAM mino");
            }
            //hitCollider.SendMessage("AddDamage");

        }

    }
}

