﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MageManager : PlayerManager
{
    public UnityEvent OnShootFireball = new UnityEvent();
    public UnityEvent OnSummonOrb = new UnityEvent();
    public UnityEvent OnRaiseWall = new UnityEvent();
    
    // Start is called before the first frame update
    private new void Start()
    {
        maxHealth = 40;
        cooldown1 = 2f;
        cooldown2 = 10f;
        cooldown3 = 10f;
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }

    protected override void Action1()
    {
        animator.SetBool("Fireball", true);
    }

    protected override void EndAction1()
    {
        EndFireballAnimation();
    }

    //Fireball generation triggered by animation event:
    void PlayerReleaseFireball()
    {
        OnShootFireball?.Invoke();
    }

    void EndFireballAnimation()
    {
        animator.SetBool("Fireball", false);
    }

    protected override void Action2()
    {
        animator.SetBool("Orb", true);
    }

    void PlayerReleaseOrb()
    {
        OnSummonOrb?.Invoke();
    }
    
    void EndOrbAnimation()
    {
        animator.SetBool("Orb", false);
    }

    protected override void Action3()
    {
        animator.SetBool("Wall", true);
    }
    
    void PlayerRaiseWall()
    {
        OnRaiseWall?.Invoke();
    }
    
    void EndWallAnimation()
    {
        animator.SetBool("Wall", false);
    }
}
