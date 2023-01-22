using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallManager : MonoBehaviour
{
    //TODO Make sure arrows (and other projectiles) can't pass through this wall
    private GameObject player;
    private MageManager mageManager;
    private Animator animator;
    
    private Rigidbody rb;
    private int hitCounter;
    private int maxHits = 5;
    private float lifespan = 5f;
    private bool deactivated;

    /* May be useful for upgrades
    private SphereCollider sphColl;
    private bool exploded;
    private bool explosionVisualDone;
    private float explosionRadius = 15f;
    */

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageManager = player.GetComponent<MageManager>();
        animator = player.GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        //sphColl = GetComponent<SphereCollider>();
        //Physics.IgnoreCollision(player.GetComponent<Collider>(),sphColl);
        StartCoroutine(DestructionTimer());
        FixWall();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Add condition to check if mouse is over pit
        //TODO Optional: make wall rise out of ground to target height
        //Remove wall from arena after lifespan seconds:
        if (deactivated)
        {
            Destroy(gameObject);
        }
    }

    void FixWall()
    {
        transform.parent = null;
        animator.SetBool("Wall", false);
    }

    //TODO Code for AoE damage upgrade
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") || collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided");

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
    */

    private IEnumerator DestructionTimer()
    {
        yield return new WaitForSeconds(lifespan);
        deactivated = true;
    }
}
