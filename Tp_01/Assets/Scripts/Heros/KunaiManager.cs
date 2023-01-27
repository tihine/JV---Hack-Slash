using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiManager : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    private int wallLayerID;
    
    private Rigidbody rb;
    private Collider kunaiColl;
    private int kunaiDamage = 5;
    private float moveSpeed = 10f;
    private Vector3 throwDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();

        wallLayerID = LayerMask.NameToLayer("Wall");
        
        throwDir = (transform.position - player.transform.position).normalized;
        throwDir.y = 0;
        transform.forward = throwDir;
        rb = GetComponent<Rigidbody>();
        kunaiColl = GetComponent<Collider>();
        Physics.IgnoreCollision(player.GetComponent<Collider>(), kunaiColl);
        ThrowKunai();
    }

    void ThrowKunai()
    {
        rb.velocity = moveSpeed * throwDir;
        animator.SetBool("Kunai", false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ennemy") || collider.gameObject.layer == wallLayerID)
        {
            Debug.Log("Kunai collided");

            if (collider.CompareTag("Ennemy"))
            {
                collider.SendMessage("AddDamage", kunaiDamage);
            }
            
            Destroy(gameObject);
        }
    }
}
