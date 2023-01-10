using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TroupFactory troupFactory;
    [SerializeField] private float SpawnDelay = 0.5f;
    private float timer;
    int current_wave = 1;
    int last_enemies = 0;
    int last2_enemies = 0;
    int total_enemies_number = 1;
    int enemies_number = 1;
    float counter = 0f;

    //private void Start()
    //{
    //    StartCoroutine(waveSpawner());
    //}
    // Update is called once per frame
    private void Update()
    {
        while (current_wave != 11)
        {
            enemies_number = total_enemies_number;
            while (enemies_number > 0)
            {
                timer += Time.deltaTime;
                if (timer > SpawnDelay)
                {
                    Debug.Log(timer);
                    troupFactory.SpawnTroup();
                    timer = 0f;
                    enemies_number -= 1;

                }
            }
            last2_enemies = last_enemies;
            last_enemies = total_enemies_number;
            total_enemies_number = last_enemies + last2_enemies;
            current_wave += 1;
        }
    }
}

            //il manque la temporisationde 5sec
            //}
        
    //IEnumerator waveSpawner()
    //{
    //    while (current_wave != 11)
    //    {
    //        enemies_number = total_enemies_number;
    //        while (enemies_number > 0)
    //        {
    //            timer += Time.deltaTime;
    //            if (timer > SpawnDelay)
    //            {
    //                Debug.Log(timer);
    //                troupFactory.SpawnTroup();
    //                timer = 0f;
    //                enemies_number -= 1;

    //            }
    //        }
    //        last2_enemies = last_enemies;
    //        last_enemies = total_enemies_number;
    //        total_enemies_number = last_enemies + last2_enemies;
    //        current_wave += 1;
    //        yield return new WaitForSeconds(5f);
    //    }
    //}

