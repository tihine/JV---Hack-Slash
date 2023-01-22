using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
 * Upgrade array structure: each element is a dictionary containing, for each upgrade,
 * name, description, default value
 */

//TODO Character data for each character

public class PlayerManager : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private float cooldown1, cooldown2, cooldown3;
    private bool onCooldown1, onCooldown2, onCooldown3;
    private float moveSpeed = 10f;
    private float horzAxis;
    private float vertAxis;
    
    private int maxUpgradeCount = 10;
    private int[] univUpgradeCounters = new int[5];
    private int[] specUpgradeCounters = new int[5];
    private Dictionary<string, string>[] univUpgrades = new Dictionary<string, string>[5];
    private Dictionary<string, string>[] specUpgrades = new Dictionary<string, string>[5];

    private Rigidbody rb;
    private Vector3 rbVel;
    private Camera cam;
    private Vector3 orientRefPt;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOrientation();
        SetMvmtAxes();
        if (!onCooldown1 && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ActionSeq1());
        }
        if (!onCooldown2 && Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ActionSeq2());
        }
        if (!onCooldown3 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ActionSeq3());
        }
    }

    private void FixedUpdate()
    {
        Orient();
        Move();
        LimitMoveSpeed();
    }
    
    
    //Movement controls
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
    
    //Action methods
    private IEnumerator ActionSeq1()
    {
        Action1();
        onCooldown1 = true;
        yield return new WaitForSeconds(cooldown1);
        onCooldown1 = false;
    }

    private void Action1()
    {
        
    }
    
    private IEnumerator ActionSeq2()
    {
        Action2();
        onCooldown2 = true;
        yield return new WaitForSeconds(cooldown1);
        onCooldown2 = false;
    }
    
    private void Action2()
    {
        
    }
    
    private IEnumerator ActionSeq3()
    {
        Action3();
        onCooldown3 = true;
        yield return new WaitForSeconds(cooldown1);
        onCooldown3 = false;
    }
    
    private void Action3()
    {
        
    }
    
    //Upgrade methods
    private void Upgrade(int upgradeNo) //10 upgrades indexed from 0 to 9
    {
        if (upgradeNo / 5 == 0)
        {
            univUpgradeCounters[upgradeNo % 5]++;
            //TODO Functions applying upgrades
        }
        else
        {
            specUpgradeCounters[upgradeNo % 5]++;
            //TODO Functions applying upgrades
        }
    }
    
}
