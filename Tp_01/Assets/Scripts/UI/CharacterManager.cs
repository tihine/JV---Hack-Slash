using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase CharacterDB;
    public TMPro.TMP_Text nameText;
    public SpriteRenderer characterSprite;
    private int selectedOption = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption= 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= CharacterDB.characterCount) 
        {
            selectedOption= 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption=CharacterDB.characterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character= CharacterDB.GetCharacter(selectedOption);
        characterSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

}
