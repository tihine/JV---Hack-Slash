using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallSpawner : MonoBehaviour
{
    private GameObject player;
    private MageManager mageMgr;
    [SerializeField] private GameObject iceWallPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mageMgr = player.GetComponent<MageManager>();
        mageMgr.OnRaiseWall.AddListener(RaiseWall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RaiseWall()
    {
        Instantiate(iceWallPrefab, transform);
    }
}
