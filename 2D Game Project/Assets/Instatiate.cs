using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instatiate : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject misslePrefab;
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {

            //Vector3 randomPos = new Vector3(Random.Range(-6, 6), Random.Range(-3, 3));
            //Vector3 randomScale = new Vector3(Random.Range(.5f, 2), Random.Range(2, .5f), 1);
            InstantiateSpawn(bulletPrefab, new Vector3 (0, 0, 0), new Vector3 (.5f, .5f, .5f), Color.green);


            //InstantiateSpawn(randomPos, randomScale);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InstantiateSpawn(misslePrefab, new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color.blue);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            InstantiateSpawn(laserPrefab, new Vector3(0, 0, 0), new Vector3(3f, .5f, .5f), Color.red);
        }

    }

    private void InstantiateSpawn(GameObject prefab, Vector3 position, Vector3 scale, Color color)
    {
        GameObject newObj = Instantiate(prefab, position, Quaternion.identity);
        newObj.transform.localScale = scale;
        newObj.GetComponent<SpriteRenderer>().material.color = color;
    }
}
