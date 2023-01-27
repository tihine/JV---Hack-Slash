using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(CharacterManager.characterPrefab, transform.position, Quaternion.identity);
    }
}
