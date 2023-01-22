using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    private GameObject player;
    private MageManager mageManager;
    private Animator animator;
    
    private Rigidbody rb;
    private SphereCollider sphColl; 
    [SerializeField] private GameObject explosionPrefab;
    private bool exploded;
    private bool explosionVisualDone;
    private float explosionRadius = 15f;
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageManager = player.GetComponent<MageManager>();
        animator = player.GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        sphColl = GetComponent<SphereCollider>();
        Physics.IgnoreCollision(player.GetComponent<Collider>(),sphColl);
        ReleaseFireball();
    }

    // Update is called once per frame
    void Update()
    {
        //Remove fireball from arena after explosion:
        if (exploded && explosionVisualDone)
        {
            Destroy(gameObject);
        }
    }

    void ReleaseFireball()
    {
        Debug.DrawRay(transform.parent.position, 10 * mageManager.GetAttackDir(), Color.green, 5f);
        transform.parent = null;
        rb.Sleep();
        rb.velocity = moveSpeed * mageManager.GetAttackDir();
        animator.SetBool("Fireball", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (exploded) return;
        if (collision.gameObject.CompareTag("Ennemy") || collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided");
            exploded = true;
            StartCoroutine(ExplosionVisual());
            
            //Blast damage:
            Collider[] blastedEntities = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider blasted in blastedEntities)
            {
                if (blasted.CompareTag("Ennemy"))
                {
                    blasted.SendMessage("AddDamage", 5);
                }
            }
            
            //Knockback via physics engine:
            float radius = sphColl.radius;
            int counter = 1;
            while (radius < explosionRadius)
            {
                radius = counter * explosionRadius / 5f;
                counter++;
                sphColl.radius = radius;
            }
        }
    }

    private IEnumerator ExplosionVisual()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform); //or SetActive(true)
        Debug.Log("Explosion!");
        yield return new WaitForSeconds(2);
        Destroy(explosion); //or SetActive(false)
        explosionVisualDone = true;
    }
}
