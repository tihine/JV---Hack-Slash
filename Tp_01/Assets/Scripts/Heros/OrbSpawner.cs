using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    private GameObject player;
    private MageManager mageMgr;
    [SerializeField] private GameObject orbPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageMgr = player.GetComponent<MageManager>();
        mageMgr.OnSummonOrb.AddListener(SummonOrb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SummonOrb()
    {
        Instantiate(orbPrefab, transform);
    }
}
