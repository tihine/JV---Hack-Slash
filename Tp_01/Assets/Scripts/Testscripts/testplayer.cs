using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    //float speed = 2f;
    public int health = 5;
    private bool isAlive = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }

    public void AddDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isAlive = false;
        }
    }
}
