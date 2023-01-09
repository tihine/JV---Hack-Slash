using UnityEngine;
public class TroupFactory:MonoBehaviour
{
    [SerializeField] Transform[] spawnZones;
    Transform selectedSpawn;
    int index;
    [SerializeField] GameObject[] enemies;
    GameObject enemy;
    int index2;

    void Start()
    {
        index = Random.Range(0, spawnZones.Length);
        selectedSpawn = spawnZones[index];
        index2 = Random.Range(0, enemies.Length);
        enemy = enemies[index2];
    }

    public void SpawnTroup()
    {
        Instantiate(enemy, selectedSpawn.position, selectedSpawn.rotation);
    }
}
