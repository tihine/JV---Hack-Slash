using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TroupFactory troupFactory;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private float waveDelay = 5f;
    [SerializeField] private int numberOfWaves = 10;
    private float timer =0f;
    private float wave_pause_timer = 0f;
    int current_wave = 1;
    public TMPro.TMP_Text waveText;

    /*int last_enemies = 0;
    int last2_enemies = 0;
    int total_enemies_number = 10; 
    int enemies_number; */

    private int wave_enemies_number = 0;
    private int wave_max_number;
    private int wavebefore_maxnumber = 1;
    private int wave2before_maxnumber = 0;

    float counter = 0f;

    private void Start()
    {
        //    StartCoroutine(waveSpawner());
        wave_max_number = wavebefore_maxnumber + wave2before_maxnumber;
        DisplayWave(current_wave.ToString());
    }
    private void Update()
    {
        if (current_wave <= numberOfWaves)
        {
            
            if (wave_enemies_number < wave_max_number)
            {
                timer += Time.deltaTime;
                if (timer > spawnDelay)
                {
                    Debug.Log(current_wave);
                    troupFactory.SpawnTroup();
                    wave_enemies_number++;
                    timer = 0f;
                }
            }
            if (wave_enemies_number >= wave_max_number)
            {
                wave_pause_timer += Time.deltaTime;
                if (wave_pause_timer > waveDelay) // pause entre les vagues
                {
                    current_wave++;
                    DisplayWave(current_wave.ToString());
                    wave2before_maxnumber = wavebefore_maxnumber;
                    wavebefore_maxnumber = wave_max_number;
                    wave_max_number = wavebefore_maxnumber + wave2before_maxnumber;
                    wave_enemies_number = 0;
                    wave_pause_timer = 0f;
                }
            }
        }
        /*
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
        */
    }

    void DisplayWave(string waveToDisplay)
    {
        waveText.text = waveToDisplay;
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

