using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 3f;
    public float spawnRangeX = 7f; // Horizontal range for spawning enemies

    private float spawnTimer;
    public float maxEnemies = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnInterval && GetEnemyCount() < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = (Random.Range(0, enemyPrefabs.Length));

        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 4);

        Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }

    int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
