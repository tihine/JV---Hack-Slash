using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Liche : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 15f;
    private float cooldown = 10f;
    private float speed = 2f;

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float vision;
    private bool isAlive = true;
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
        }
    }
}
