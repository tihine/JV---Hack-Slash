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

public abstract class PlayerManager : MonoBehaviour
{
    protected int health;
    protected int maxHealth;
    protected float cooldown1, cooldown2, cooldown3;
    protected bool onCooldown1, onCooldown2, onCooldown3;
    protected float moveSpeed = 10f;
    protected float horzAxis;
    protected float vertAxis;
    
    protected int maxUpgradeCount = 10;
    protected int[] univUpgradeCounters = new int[5];
    protected int[] specUpgradeCounters = new int[5];
    protected Dictionary<string, string>[] univUpgrades = new Dictionary<string, string>[5];
    protected Dictionary<string, string>[] specUpgrades = new Dictionary<string, string>[5];

    protected Animator animator;
    protected Rigidbody rb;
    protected Vector3 rbVel;
    protected Camera cam;
    protected Vector3 orientRefPt;
    protected Vector3 attackDir;
    [SerializeField] public HealthBar healthbar;

    
    // Start is called before the first frame update
    protected void Start()
    {
        //Character-specific initialisation goes here
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    protected void Update()
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

    protected void FixedUpdate()
    {
        Orient();
        Move();
        LimitMoveSpeed();
    }
    
    
    //Movement controls
    protected void UpdateOrientation()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            orientRefPt = hit.point;
        }
    }

    protected void SetMvmtAxes()
    {
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
    }
    
    protected void Orient()
    {
        transform.LookAt(orientRefPt);
        attackDir = (orientRefPt - transform.position).normalized;
    }
    
    protected void Move()
    {
        rbVel = rb.velocity;
        rbVel.x += horzAxis;
        rbVel.z += vertAxis;
        rb.velocity = rbVel;
    }

    protected void LimitMoveSpeed()
    {
        rbVel = rb.velocity;
        if (rbVel.magnitude > moveSpeed)
        {
            rbVel = moveSpeed * rbVel.normalized;
            rb.velocity = rbVel;
        }

        Vector3 localVel = transform.InverseTransformDirection(rbVel);
        animator.SetFloat("Strafe", localVel.x / moveSpeed);
        animator.SetFloat("ForwardSpeed", localVel.z / moveSpeed);
    }
    
    //Health management

    public void AddDamage(int damage) //TODO change back to "PROTECTED" later!!!
    {
        health -= damage;
        healthbar.SetHealth(health);
        if (health <= 0)
        {
            //TODO Invoke DeathEvent/GameOverEvent (to be coded)
        }
    }
    
    //Action methods

    public Vector3 GetAttackDir()
    {
        return attackDir;
    }
    protected IEnumerator ActionSeq1()
    {
        Action1();
        onCooldown1 = true;
        yield return new WaitForSeconds(cooldown1);
        onCooldown1 = false;
    }

    protected abstract void Action1();

    protected IEnumerator ActionSeq2()
    {
        Action2();
        onCooldown2 = true;
        yield return new WaitForSeconds(cooldown2);
        onCooldown2 = false;
    }

    protected abstract void Action2();
    
    protected IEnumerator ActionSeq3()
    {
        Action3();
        onCooldown3 = true;
        yield return new WaitForSeconds(cooldown3);
        onCooldown3 = false;
    }

    protected abstract void Action3();

    //Upgrade methods
    protected void Upgrade(int upgradeNo) //10 upgrades indexed from 0 to 9
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
