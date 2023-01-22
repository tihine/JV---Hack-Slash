using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 5f;
    private float countdown = 5f;
    private float speed = 8f;
    private float damage = 3f;

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

    public void Shoot()
    {
        // nombre aléatoire de flèches entre 1 et 5
        // faire spawn une fléche avec une vitesse vers le joueur
        Debug.Log("Shoot");

    }
}
