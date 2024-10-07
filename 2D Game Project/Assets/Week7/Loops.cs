using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public GameObject fallingObject;
    public int totalWaves = 3;
    public int obstaclesPerWave = 5;
    public float timeBetweenWaves = 3f;

    public int maxGroupsPerWave = 3;
    public int maxObstaclesPerGroup = 4;
    public float timeBetweenGroups = 1f;

    public GameObject powerUp;
    public float powerUpSpawnRate = 5f;
    private float lastPowerUpTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize: var set to zero
        //condition: that has to be met while it is still true will continue 
        //incremeant: what happens at the end of each
        //loop iteration is that it increases the loop var by 1 so it eventually stops
        /*for (int i = 0; i < 10; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-8, 8), 5f);
            Instantiate(fallingObject, spawnPos, Quaternion.identity);
        }*/

        //StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnMoreWaves());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*IEnumerator SpawnWaves() 
    {
        int currentWave = 0;

        //while 0 is less than the total waves (3)
        while(currentWave < totalWaves)
        {
            //spawn a set of obstacles
            for(int i = 0;i < obstaclesPerWave;i++)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-8, 8), 5f);
                Instantiate(fallingObject, spawnPos, Quaternion.identity);
            }

            //wait a few seconds before next wave
            yield return new WaitForSeconds(timeBetweenWaves);

            //incremeant current wave count
            currentWave++;
        }
    
    }*/

    IEnumerator SpawnMoreWaves() 
    {
        //var to track the current wave number
        int currentWave = 0;

        //while loop to keep swpawning until we reach total number of waves
        //while loop will execute a block of code as long as the condition is true
        while(currentWave < totalWaves)
        {
            //prints which wave is being spawned
            //Debug.Log("Current Wave: " + (currentWave + 1));

            //outer loop for groups of obstacles
            //creates multiple groups of obstacles for current wave
            for( int group = 0; group < maxGroupsPerWave; group++)
            {
                //print which group is being spawned
                //Debug.Log("Spawning group: " + (group + 1));

                //inner nested loop for individual obstacles in each group
                //random number of obstacles
                int obstaclesInGroup = Random.Range(1, maxObstaclesPerGroup + 1);

                //inner loop: creates individual obstacles within the current group
                for( int i = 0; i < obstaclesInGroup; i++)
                {
                    //randomly choose a position on the x axis, y axis always 5f
                    Vector2 spawnPos = new Vector2(Random.Range(-8, 8), 5f);
                    //create a falling obj at the chosen spawn pos
                    Instantiate(fallingObject, spawnPos, Quaternion.identity);
                }

                //wait short time between groups within the same wave
                yield return new WaitForSeconds(timeBetweenGroups);
            }

            //check if its time to spawn a powerup
            //time.time gives you total time since game started measure in seconds
            //lastpoeruptime keeps track of the last time a powerup was spawned
            //powerupspawnrate how often you want it to power up
            /*The condition Time.time - lastPowerUpSpawnTime >= powerUpSpawnRate is checking whether 
            the time elapsed since the last power-up was spawned is greater than or equal to the 
            time you want to wait before spawning another power-up.*/
            //If lastPowerUpSpawnTime is 0 (initial value), then this condition will be true
            //when Time.time reaches powerUpSpawnRate.
            if (Time.time - lastPowerUpTime >= powerUpSpawnRate)
            {
                SpawnPowerUp(); //call method
                lastPowerUpTime = Time.time; //update last spawn time
            }

            //wait for a few seconds before starting the next wave
            yield return new WaitForSeconds (timeBetweenWaves);
            currentWave++;
        }

        Debug.Log("All waves spawned");
    
    }

    void SpawnPowerUp()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8, 8), 1f);
        Instantiate(powerUp, spawnPos, Quaternion.identity);
    }
}
