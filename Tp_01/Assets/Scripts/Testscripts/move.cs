using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float speed = 2f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h_input = 0;
        float v_input = 0;
       
        if (Input.GetKey(KeyCode.Z))
        {
            
            v_input += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            v_input -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            h_input += 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            
            h_input -= 1;
        }
        rb.velocity += new Vector3(h_input,0,v_input).normalized * speed;
    }
}
