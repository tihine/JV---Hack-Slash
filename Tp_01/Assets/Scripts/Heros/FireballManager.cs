using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private GameObject explosionPrefab;
    private float moveSpeed = 5f;
    private float timeTillFire = 2.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Invoke("ReleaseFireball", timeTillFire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReleaseFireball()
    {
        transform.parent = null;
        rb.velocity = moveSpeed * player.transform.forward;
        animator.SetBool("Fireball", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private IEnumerator Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab); //or SetActive(true)
        yield return new WaitForSeconds(2);
        Destroy(explosion); //or SetActive(false)
    }
}
