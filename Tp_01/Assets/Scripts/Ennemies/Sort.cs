using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.1f)
        {
            CheckEntities();
            timer = 0f;
        }
    }

    public void CheckEntities()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                Debug.Log("Touché");
                hitCollider.SendMessage("AddDamage", 1);
            }
            if (hitCollider.tag == "Ennemy")
            {
                Debug.Log("Heal" + hitCollider.gameObject.name);
                hitCollider.SendMessage("AddLife", 1);
            }


        }
    }
}
