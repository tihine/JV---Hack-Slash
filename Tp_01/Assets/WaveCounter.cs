using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    public TMPro.TMP_Text waveText;
    void Start() 
    {
        waveText.text = Spawner.current_wave.ToString();
        DisplayWave(Spawner.current_wave.ToString());
    }
        
    void DisplayWave(string waveToDisplay)
    {
        waveText.text = "Wave : "+waveToDisplay;
    }
    private void LateUpdate()
    {
        DisplayWave(Spawner.current_wave.ToString());
    }
}
