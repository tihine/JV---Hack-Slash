using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TroupFactory troupFactory;
    [SerializeField] private float SpawnDelay = 0.5f;
    private float timer;

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > SpawnDelay) {
            troupFactory.SpawnTroup();
            timer = 0f;
        }
    }
}
