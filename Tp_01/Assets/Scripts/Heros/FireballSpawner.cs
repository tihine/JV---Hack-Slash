﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    private GameObject player;
    private MageManager mageMgr;
    [SerializeField] private GameObject fireballPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageMgr = player.GetComponent<MageManager>();
        mageMgr.OnShootFireball.AddListener(ShootFireball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootFireball()
    {
        Instantiate(fireballPrefab, transform);
    }
}
