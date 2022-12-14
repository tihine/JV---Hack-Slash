using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    private int health;
    private float cooldown1, cooldown2, cooldown3;
    private float moveSpeed = 10f;
    private float horzAxis;
    private float vertAxis;
    private int maxUpgradeCount = 10;
    private int univUpgradeCounter1, univUpgradeCounter2, univUpgradeCounter3, univUpgradeCounter4, univUpgradeCounter5;
    private int specUpgradeCounter1, specUpgradeCounter2, specUpgradeCounter3, specUpgradeCounter4, specUpgradeCounter5;
    private Rigidbody rb;
    private Vector3 rbVel;
    private Camera cam;
    private Vector3 orientRefPt;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOrientation();
        SetMvmtAxes();
    }

    private void FixedUpdate()
    {
        Orient();
        Move();
        LimitMoveSpeed();
    }

    private void UpdateOrientation()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            orientRefPt = hit.point;
        }
    }

    private void SetMvmtAxes()
    {
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
    }
    
    private void Orient()
    {
        transform.LookAt(orientRefPt);
    }
    
    private void Move()
    {
        rbVel = rb.velocity;
        rbVel.x += horzAxis;
        rbVel.z += vertAxis;
        rb.velocity = rbVel;
    }

    private void LimitMoveSpeed()
    {
        rbVel = rb.velocity;
        if (rbVel.magnitude > moveSpeed)
        {
            rbVel = moveSpeed * rbVel.normalized;
            rb.velocity = rbVel;
        }
    }
}
