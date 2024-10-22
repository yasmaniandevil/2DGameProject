using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 3f;
    // Horizontal range for spawning enemies
    public float spawnRangeX = 7f;
    //defines radius around spawn point
    public float spawnRadius = 5f;

    private float spawnTimer;
    public float maxEnemies = 4;

    public LayerMask enemyLayer;

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

        
        if (isSpawnPosClear(spawnPos))
        {
            Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
            Debug.Log("called");

        }
        else
        {
            Debug.Log("Spawn Pos blocked");
        }
        
    }

    bool isSpawnPosClear(Vector2 position)
    {
        //checks for enemies within spawn radius (their colliders)
        //if no colliders are found it returns true
        Collider2D hitCollider = Physics2D.OverlapCircle(position, spawnRadius, enemyLayer);
        //if no collider is found the position is clear
        return hitCollider == null;
        
    }

    int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
