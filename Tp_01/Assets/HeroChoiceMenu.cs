using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroChoiceMenu : MonoBehaviour
{
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
