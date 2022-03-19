using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardSpawning : MonoBehaviour
{
    public Transform[] spawnpoints;
    public float spawnDelay = 20;
    public GameObject[] prefabs;
    public int spawnCap = 100;

    private List<GameObject> spawnedEnemies;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        spawnedEnemies.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemies.Count < spawnCap && nextSpawn < Time.time)
        {
            SpawnEnemy ();
            nextSpawn = Time.time + spawnDelay;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = spawnpoints[Random.Range(0, spawnpoints.Length - 1)].position;
        GameObject newEnemy = Instantiate(prefabs[Random.Range(0, 1)], spawnPos, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
        newEnemy.transform.parent = transform;
    }

    public void DestroyEnemy(GameObject enemy)
    {
        if(spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
            Destroy(enemy);
        }
    }
}
