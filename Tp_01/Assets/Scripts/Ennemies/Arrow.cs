using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0;
    private float maxLife = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxLife)
        {
            Destroy(gameObject);
        }
    }
    /*private void OnCollisionEnter(Collision other)
    {
        //fait des dégats au mec
        Destroy(this.gameObject);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        Destroy (this.gameObject);
        if (other.tag == "Player")
        {
            other.SendMessage("AddDamage", 3);
        }
    }
}
