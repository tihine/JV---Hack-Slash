using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CharacterManager.characterPrefab, transform.position, Quaternion.identity);
    }
}
