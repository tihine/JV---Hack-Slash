using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroChoiceMenu : MonoBehaviour
{

    public void BackMainMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PlayGame()
    {
        int nbr_scene = Random.Range(1, 4); 
        string scene = "Arene "+ nbr_scene;
        Debug.Log(scene);
        SceneManager.LoadSceneAsync(scene);
        SceneManager.LoadSceneAsync("UIGame", LoadSceneMode.Additive);
    }
}
