using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    private bool isAlive = true;
    void Start()
    {
        if (!navMeshAgent) navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 4f && Vector3.Distance(transform.position, player.transform.position) < vision && isAlive)
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
        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
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
}

